namespace CryptoTransceiverUtil
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonReadKey = new System.Windows.Forms.Button();
            this.buttonNewKey = new System.Windows.Forms.Button();
            this.buttonSaveKey = new System.Windows.Forms.Button();
            this.textBoxKeyHash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirmwarePath = new System.Windows.Forms.TextBox();
            this.buttonOpenFirmware = new System.Windows.Forms.Button();
            this.buttonWriteFirmware = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReadKey
            // 
            this.buttonReadKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonReadKey.Location = new System.Drawing.Point(102, 51);
            this.buttonReadKey.Name = "buttonReadKey";
            this.buttonReadKey.Size = new System.Drawing.Size(84, 35);
            this.buttonReadKey.TabIndex = 4;
            this.buttonReadKey.Text = "Read Key From SD";
            this.buttonReadKey.UseVisualStyleBackColor = true;
            this.buttonReadKey.Click += new System.EventHandler(this.buttonReadKey_Click);
            // 
            // buttonNewKey
            // 
            this.buttonNewKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonNewKey.Location = new System.Drawing.Point(12, 51);
            this.buttonNewKey.Name = "buttonNewKey";
            this.buttonNewKey.Size = new System.Drawing.Size(84, 35);
            this.buttonNewKey.TabIndex = 3;
            this.buttonNewKey.Text = "New Key";
            this.buttonNewKey.UseVisualStyleBackColor = true;
            this.buttonNewKey.Click += new System.EventHandler(this.buttonNewKey_Click);
            // 
            // buttonSaveKey
            // 
            this.buttonSaveKey.Enabled = false;
            this.buttonSaveKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSaveKey.Location = new System.Drawing.Point(192, 51);
            this.buttonSaveKey.Name = "buttonSaveKey";
            this.buttonSaveKey.Size = new System.Drawing.Size(84, 35);
            this.buttonSaveKey.TabIndex = 5;
            this.buttonSaveKey.Text = "Save Key To SD";
            this.buttonSaveKey.UseVisualStyleBackColor = true;
            this.buttonSaveKey.Click += new System.EventHandler(this.buttonSaveKey_Click);
            // 
            // textBoxKeyHash
            // 
            this.textBoxKeyHash.Enabled = false;
            this.textBoxKeyHash.Location = new System.Drawing.Point(12, 25);
            this.textBoxKeyHash.Name = "textBoxKeyHash";
            this.textBoxKeyHash.ReadOnly = true;
            this.textBoxKeyHash.Size = new System.Drawing.Size(429, 20);
            this.textBoxKeyHash.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key Hash:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Firmware Path:";
            // 
            // textBoxFirmwarePath
            // 
            this.textBoxFirmwarePath.Enabled = false;
            this.textBoxFirmwarePath.Location = new System.Drawing.Point(12, 126);
            this.textBoxFirmwarePath.Name = "textBoxFirmwarePath";
            this.textBoxFirmwarePath.ReadOnly = true;
            this.textBoxFirmwarePath.Size = new System.Drawing.Size(385, 20);
            this.textBoxFirmwarePath.TabIndex = 7;
            // 
            // buttonOpenFirmware
            // 
            this.buttonOpenFirmware.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOpenFirmware.Location = new System.Drawing.Point(403, 126);
            this.buttonOpenFirmware.Name = "buttonOpenFirmware";
            this.buttonOpenFirmware.Size = new System.Drawing.Size(38, 20);
            this.buttonOpenFirmware.TabIndex = 8;
            this.buttonOpenFirmware.Text = "...";
            this.buttonOpenFirmware.UseVisualStyleBackColor = true;
            this.buttonOpenFirmware.Click += new System.EventHandler(this.buttonOpenFirmware_Click);
            // 
            // buttonWriteFirmware
            // 
            this.buttonWriteFirmware.Enabled = false;
            this.buttonWriteFirmware.Location = new System.Drawing.Point(12, 152);
            this.buttonWriteFirmware.Name = "buttonWriteFirmware";
            this.buttonWriteFirmware.Size = new System.Drawing.Size(84, 35);
            this.buttonWriteFirmware.TabIndex = 9;
            this.buttonWriteFirmware.Text = "Write to SD";
            this.buttonWriteFirmware.UseVisualStyleBackColor = true;
            this.buttonWriteFirmware.Click += new System.EventHandler(this.buttonWriteFirmware_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 207);
            this.Controls.Add(this.buttonWriteFirmware);
            this.Controls.Add(this.buttonOpenFirmware);
            this.Controls.Add(this.textBoxFirmwarePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxKeyHash);
            this.Controls.Add(this.buttonSaveKey);
            this.Controls.Add(this.buttonNewKey);
            this.Controls.Add(this.buttonReadKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CryptoTransceiver SD Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReadKey;
        private System.Windows.Forms.Button buttonNewKey;
        private System.Windows.Forms.Button buttonSaveKey;
        private System.Windows.Forms.TextBox textBoxKeyHash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirmwarePath;
        private System.Windows.Forms.Button buttonOpenFirmware;
        private System.Windows.Forms.Button buttonWriteFirmware;
    }
}

