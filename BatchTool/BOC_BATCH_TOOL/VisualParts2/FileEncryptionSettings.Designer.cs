namespace BOC_BATCH_TOOL.VisualParts
{
    partial class FileEncryptionSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileEncryptionSettings));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveEncryption = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.lbGroupDescription = new System.Windows.Forms.Label();
            this.txtNewPWD = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.txtEnSurePWD = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveEncryption);
            this.groupBox2.Controls.Add(this.panel11);
            this.groupBox2.Controls.Add(this.txtNewPWD);
            this.groupBox2.Controls.Add(this.txtEnSurePWD);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnSaveEncryption
            // 
            resources.ApplyResources(this.btnSaveEncryption, "btnSaveEncryption");
            this.btnSaveEncryption.Name = "btnSaveEncryption";
            this.btnSaveEncryption.ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            this.btnSaveEncryption.UseVisualStyleBackColor = false;
            this.btnSaveEncryption.Click += new System.EventHandler(this.btnSaveEncryption_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Window;
            this.panel11.Controls.Add(this.rbNo);
            this.panel11.Controls.Add(this.rbYes);
            this.panel11.Controls.Add(this.lbGroupDescription);
            resources.ApplyResources(this.panel11, "panel11");
            this.panel11.Name = "panel11";
            // 
            // rbNo
            // 
            resources.ApplyResources(this.rbNo, "rbNo");
            this.rbNo.Checked = true;
            this.rbNo.Name = "rbNo";
            this.rbNo.TabStop = true;
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbYes
            // 
            resources.ApplyResources(this.rbYes, "rbYes");
            this.rbYes.Name = "rbYes";
            this.rbYes.UseVisualStyleBackColor = true;
            this.rbYes.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // lbGroupDescription
            // 
            resources.ApplyResources(this.lbGroupDescription, "lbGroupDescription");
            this.lbGroupDescription.Name = "lbGroupDescription";
            // 
            // txtNewPWD
            // 
            this.txtNewPWD.EditorValueChanged = false;
            this.txtNewPWD.ErrorProvider = null;
            resources.ApplyResources(this.txtNewPWD, "txtNewPWD");
            this.txtNewPWD.Name = "txtNewPWD";
            this.txtNewPWD.ReadOnly = true;
            this.txtNewPWD.UseSystemPasswordChar = true;
            this.txtNewPWD.ValidateEnabled = false;
            this.txtNewPWD.ValidateRule.MaxLength = 0;
            this.txtNewPWD.ValidateRule.MinLength = 0;
            this.txtNewPWD.ValidateRule.RegexValue = null;
            this.txtNewPWD.ValidateRule.Required = false;
            // 
            // txtEnSurePWD
            // 
            this.txtEnSurePWD.EditorValueChanged = false;
            this.txtEnSurePWD.ErrorProvider = null;
            resources.ApplyResources(this.txtEnSurePWD, "txtEnSurePWD");
            this.txtEnSurePWD.Name = "txtEnSurePWD";
            this.txtEnSurePWD.ReadOnly = true;
            this.txtEnSurePWD.UseSystemPasswordChar = true;
            this.txtEnSurePWD.ValidateEnabled = false;
            this.txtEnSurePWD.ValidateRule.MaxLength = 0;
            this.txtEnSurePWD.ValidateRule.MinLength = 0;
            this.txtEnSurePWD.ValidateRule.RegexValue = null;
            this.txtEnSurePWD.ValidateRule.Required = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // FileEncryptionSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox2);
            this.Name = "FileEncryptionSettings";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lbGroupDescription;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.Label label16;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate txtNewPWD;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate txtEnSurePWD;
        private System.Windows.Forms.Label label15;
        private Controls.ThemedButton btnSaveEncryption;
    }
}
