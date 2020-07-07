using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace CryptoTransceiverUtil
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static SHA256 hasher = SHA256.Create();

        private const int KEY_LENGTH = 131;

        private byte[] _key;
        private byte[] Key
        {
            get
            {
                return (byte[])_key.Clone();
            }
            set
            {
                if (value == null)
                {
                    _key = null;
                    buttonSaveKey.Enabled = false;
                    textBoxKeyHash.Text = string.Empty;
                }
                else if (value.Length == KEY_LENGTH)
                {
                    _key = value;
                    byte[] hash = hasher.ComputeHash(_key);
                    textBoxKeyHash.Text = BitConverter.ToString(hash).Replace("-", "");
                    buttonSaveKey.Enabled = true;
                }
                else if (value.Length != KEY_LENGTH)
                {
                    throw new ArgumentOutOfRangeException("Key.Length", value.Length, string.Format("Key Must be exactly {0} bytes", KEY_LENGTH));
                }
            }
        }

        private void buttonNewKey_Click(object sender, EventArgs e)
        {
            byte[] newKey = new byte[KEY_LENGTH];
            rng.GetBytes(newKey);

            Key = newKey;
        }

        private string GetConfigDirPath(string sdRootDir)
        {
            return Path.Combine(sdRootDir, "config");
        }

        private string GetKeyPath(string sdRootDir)
        {
            return Path.Combine(GetConfigDirPath(sdRootDir), "key");
        }

        private string GetKeyPathNew(string sdRootDir)
        {
            return Path.Combine(GetConfigDirPath(sdRootDir), "key.new");
        }

        private string GetKeyPathOld(string sdRootDir)
        {
            return Path.Combine(GetConfigDirPath(sdRootDir), "key.old");
        }

        private string GetFirmwarePath(string sdRootDir)
        {
            return Path.Combine(sdRootDir, "zImage");
        }

        private string GetFirmwarePathNew(string sdRootDir)
        {
            return Path.Combine(sdRootDir, "zImage.new");
        }

        private string GetFirmwarePathOld(string sdRootDir)
        {
            return Path.Combine(sdRootDir, "zImage.old");
        }

        private void EnsureConfigDirExists(string sdRootDir)
        {
            string configDir = GetConfigDirPath(sdRootDir);
            Directory.CreateDirectory(configDir);
        }

        private void buttonReadKey_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string keyPath = GetKeyPath(fbd.SelectedPath);
                    try
                    {
                        using (FileStream f = File.OpenRead(keyPath))
                        {
                            long length = f.Length;
                            if (length == KEY_LENGTH)
                            {
                                byte[] key = new byte[length];
                                int read = f.Read(key, 0, KEY_LENGTH);

                                if (read != KEY_LENGTH)
                                {
                                    MessageBox.Show("Error reading key",
                                                    "Error reading key",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                }
                                else
                                {
                                    Key = key;
                                }
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Invalid key length: {0}", length),
                                                "Invalid Key",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show(string.Format("Could not read key from SD card in directory {0}", fbd.SelectedPath),
                                        "Key Not Found",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("An exception occurred: {0}", ex.ToString()),
                                        "Exception Occurred",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSaveKey_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string keyPathNew = GetKeyPathNew(fbd.SelectedPath);
                    string keyPath = GetKeyPath(fbd.SelectedPath);
                    string keyPathOld = GetKeyPathOld(fbd.SelectedPath);
                    try
                    {
                        EnsureConfigDirExists(fbd.SelectedPath);

                        using (FileStream f = File.OpenWrite(keyPathNew))
                        {
                            byte[] key = Key;
                            Debug.Assert(key.Length == KEY_LENGTH);

                            f.Write(key, 0, key.Length);
                            f.Flush();
                        }

                        if (File.Exists(keyPath))
                        {
                            File.Replace(keyPathNew, keyPath, keyPathOld, true);
                        }
                        else
                        {
                            File.Move(keyPathNew, keyPath);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show(string.Format("Could not read key from SD card in directory {0}", fbd.SelectedPath),
                                        "Key Not Found",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(string.Format("An error occurred when writing the key: {0}", ex.ToString()),
                                        "I/O Error Occurred",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("An exception occurred: {0}", ex.ToString()),
                                        "Exception Occurred",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonOpenFirmware_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                DialogResult result = fd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fd.FileName))
                {
                    textBoxFirmwarePath.Text = fd.FileName;
                    buttonWriteFirmware.Enabled = true;
                }
            }
        }

        private void buttonWriteFirmware_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string firmwarePathNew = GetFirmwarePathNew(fbd.SelectedPath);
                    string firmwarePathOld = GetFirmwarePathOld(fbd.SelectedPath);
                    string firmwarePath = GetFirmwarePath(fbd.SelectedPath);
                    try
                    {
                        File.Copy(textBoxFirmwarePath.Text, firmwarePathNew, true);
                        File.Replace(firmwarePathNew, firmwarePath, firmwarePathOld, true);
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show(string.Format("Could not read key from SD card in directory {0}", fbd.SelectedPath),
                                        "Key Not Found",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(string.Format("An error occurred when writing the key: {0}", ex.ToString()),
                                        "I/O Error Occurred",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("An exception occurred: {0}", ex.ToString()),
                                        "Exception Occurred",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
