namespace CommonClient
{
    partial class frmNetPassword
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
            this.fileEncryptionSettings1 = new CommonClient.VisualParts2.FileEncryptionSettings();
            this.btnCancel = new CommonClient.Controls.ThemedButton();
            this.SuspendLayout();
            // 
            // fileEncryptionSettings1
            // 
            this.fileEncryptionSettings1.AppType = CommonClient.EnumTypes.AppliableFunctionType._Empty;
            this.fileEncryptionSettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.fileEncryptionSettings1.Location = new System.Drawing.Point(61, 29);
            this.fileEncryptionSettings1.Name = "fileEncryptionSettings1";
            this.fileEncryptionSettings1.Size = new System.Drawing.Size(410, 174);
            this.fileEncryptionSettings1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.languageList1.SetDvLangId(this.btnCancel, null);
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(277, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNetPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(534, 262);
            this.Controls.Add(this.fileEncryptionSettings1);
            this.Controls.Add(this.btnCancel);
            this.languageList1.SetDvLangId(this, null);
            this.Name = "frmNetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置加密密码";
            this.ResumeLayout(false);

        }

        #endregion

        private VisualParts2.FileEncryptionSettings fileEncryptionSettings1;
        private Controls.ThemedButton btnCancel;
    }
}