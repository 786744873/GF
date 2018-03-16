using CommonClient.Controls;

namespace CommonClient.VisualParts2
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
            this.btnSaveEncryption = new CommonClient.Controls.ThemedButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.lbGroupDescription = new System.Windows.Forms.Label();
            this.txtNewPWD = new CommonClient.Controls.TextBoxCanValidate();
            this.txtEnSurePWD = new CommonClient.Controls.TextBoxCanValidate();
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
            this.btnSaveEncryption.ThemeName = CommonClient.Controls.ThemeName.Corp_Red;
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
            this.txtNewPWD.DvDataField = null;
            this.txtNewPWD.DvEditorValueChanged = false;
            this.txtNewPWD.DvErrorProvider = this.errorProvider1;
            this.txtNewPWD.DvFixLength = false;
            this.txtNewPWD.DvLinkedLabel = null;
            this.txtNewPWD.DvMaxLength = 0;
            this.txtNewPWD.DvMinLength = 0;
            this.txtNewPWD.DvRegCode = null;
            this.txtNewPWD.DvRequired = false;
            this.txtNewPWD.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.txtNewPWD.DvValidateEnabled = true;
            this.txtNewPWD.DvValidator = null;
            resources.ApplyResources(this.txtNewPWD, "txtNewPWD");
            this.txtNewPWD.Name = "txtNewPWD";
            this.txtNewPWD.ReadOnly = true;
            this.txtNewPWD.UseSystemPasswordChar = true;
            // 
            // txtEnSurePWD
            // 
            this.txtEnSurePWD.DvDataField = null;
            this.txtEnSurePWD.DvEditorValueChanged = false;
            this.txtEnSurePWD.DvErrorProvider = this.errorProvider1;
            this.txtEnSurePWD.DvFixLength = false;
            this.txtEnSurePWD.DvLinkedLabel = null;
            this.txtEnSurePWD.DvMaxLength = 0;
            this.txtEnSurePWD.DvMinLength = 0;
            this.txtEnSurePWD.DvRegCode = null;
            this.txtEnSurePWD.DvRequired = false;
            this.txtEnSurePWD.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.txtEnSurePWD.DvValidateEnabled = true;
            this.txtEnSurePWD.DvValidator = null;
            resources.ApplyResources(this.txtEnSurePWD, "txtEnSurePWD");
            this.txtEnSurePWD.Name = "txtEnSurePWD";
            this.txtEnSurePWD.ReadOnly = true;
            this.txtEnSurePWD.UseSystemPasswordChar = true;
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
        private TextBoxCanValidate txtNewPWD;
        private TextBoxCanValidate txtEnSurePWD;
        private System.Windows.Forms.Label label15;
        private ThemedButton btnSaveEncryption;
    }
}
