using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class PayeeSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayeeSelector));
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.lblPayeeName = new System.Windows.Forms.Label();
            this.lblPayeeEmail = new System.Windows.Forms.Label();
            this.cmbPayeeAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.edtPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.edtPayeeBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.edtPayeeEmail = new CommonClient.Controls.TextBoxCanValidate();
            this.edtPayeePhone = new CommonClient.Controls.TextBoxCanValidate();
            this.btnQueryBank = new CommonClient.Controls.ThemedButton();
            this.btnQueryAccount = new CommonClient.Controls.ThemedButton();
            this.lbcnaps = new System.Windows.Forms.Label();
            this.cmbBankType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbpayeeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcnaps = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOpenBankType = new System.Windows.Forms.Label();
            this.lblcnaps = new System.Windows.Forms.Label();
            this.lbOpenBank = new System.Windows.Forms.Label();
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPayeeAccount
            // 
            resources.ApplyResources(this.lblPayeeAccount, "lblPayeeAccount");
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            // 
            // lblPayeeName
            // 
            resources.ApplyResources(this.lblPayeeName, "lblPayeeName");
            this.lblPayeeName.Name = "lblPayeeName";
            // 
            // lblPayeeEmail
            // 
            resources.ApplyResources(this.lblPayeeEmail, "lblPayeeEmail");
            this.lblPayeeEmail.Name = "lblPayeeEmail";
            // 
            // cmbPayeeAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayeeAccount, this.ambiguityInputAgent1);
            this.cmbPayeeAccount.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccount.DvDataField = null;
            this.cmbPayeeAccount.DvEditorValueChanged = false;
            this.cmbPayeeAccount.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccount.DvLinkedLabel = this.lblPayeeAccount;
            this.cmbPayeeAccount.DvMaxLength = 32;
            this.cmbPayeeAccount.DvMinLength = 1;
            this.cmbPayeeAccount.DvRegCode = "";
            this.cmbPayeeAccount.DvRequired = true;
            this.cmbPayeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccount.DvValidateEnabled = true;
            this.cmbPayeeAccount.DvValidator = this.validatorList1;
            this.cmbPayeeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccount, "cmbPayeeAccount");
            this.cmbPayeeAccount.Name = "cmbPayeeAccount";
            // 
            // edtPayeeName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.edtPayeeName, null);
            this.edtPayeeName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeName.DvDataField = null;
            this.edtPayeeName.DvEditorValueChanged = false;
            this.edtPayeeName.DvErrorProvider = this.errorProvider1;
            this.edtPayeeName.DvLinkedLabel = this.lblPayeeName;
            this.edtPayeeName.DvMaxLength = 76;
            this.edtPayeeName.DvMinLength = 1;
            this.edtPayeeName.DvRegCode = "";
            this.edtPayeeName.DvRequired = false;
            this.edtPayeeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeName.DvValidateEnabled = true;
            this.edtPayeeName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeName, "edtPayeeName");
            this.edtPayeeName.Name = "edtPayeeName";
            // 
            // edtPayeeBankName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.edtPayeeBankName, null);
            this.edtPayeeBankName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeBankName.DvDataField = null;
            this.edtPayeeBankName.DvEditorValueChanged = false;
            this.edtPayeeBankName.DvErrorProvider = this.errorProvider1;
            this.edtPayeeBankName.DvLinkedLabel = null;
            this.edtPayeeBankName.DvMaxLength = 140;
            this.edtPayeeBankName.DvMinLength = 0;
            this.edtPayeeBankName.DvRegCode = "";
            this.edtPayeeBankName.DvRequired = false;
            this.edtPayeeBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeBankName.DvValidateEnabled = true;
            this.edtPayeeBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeBankName, "edtPayeeBankName");
            this.edtPayeeBankName.Name = "edtPayeeBankName";
            // 
            // edtPayeeEmail
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.edtPayeeEmail, null);
            this.edtPayeeEmail.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeEmail.DvDataField = null;
            this.edtPayeeEmail.DvEditorValueChanged = false;
            this.edtPayeeEmail.DvErrorProvider = this.errorProvider1;
            this.edtPayeeEmail.DvLinkedLabel = this.lblPayeeEmail;
            this.edtPayeeEmail.DvMaxLength = 0;
            this.edtPayeeEmail.DvMinLength = 0;
            this.edtPayeeEmail.DvRegCode = "";
            this.edtPayeeEmail.DvRequired = false;
            this.edtPayeeEmail.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeEmail.DvValidateEnabled = true;
            this.edtPayeeEmail.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeEmail, "edtPayeeEmail");
            this.edtPayeeEmail.Name = "edtPayeeEmail";
            // 
            // edtPayeePhone
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.edtPayeePhone, null);
            resources.ApplyResources(this.edtPayeePhone, "edtPayeePhone");
            this.edtPayeePhone.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeePhone.DvDataField = null;
            this.edtPayeePhone.DvEditorValueChanged = false;
            this.edtPayeePhone.DvErrorProvider = this.errorProvider1;
            this.edtPayeePhone.DvLinkedLabel = null;
            this.edtPayeePhone.DvMaxLength = 0;
            this.edtPayeePhone.DvMinLength = 0;
            this.edtPayeePhone.DvRegCode = "";
            this.edtPayeePhone.DvRequired = false;
            this.edtPayeePhone.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeePhone.DvValidateEnabled = true;
            this.edtPayeePhone.DvValidator = null;
            this.edtPayeePhone.Name = "edtPayeePhone";
            // 
            // btnQueryBank
            // 
            resources.ApplyResources(this.btnQueryBank, "btnQueryBank");
            this.btnQueryBank.Name = "btnQueryBank";
            this.btnQueryBank.UseVisualStyleBackColor = true;
            this.btnQueryBank.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // btnQueryAccount
            // 
            resources.ApplyResources(this.btnQueryAccount, "btnQueryAccount");
            this.btnQueryAccount.Name = "btnQueryAccount";
            this.btnQueryAccount.UseVisualStyleBackColor = true;
            this.btnQueryAccount.Click += new System.EventHandler(this.btnQueryAccount_Click);
            // 
            // lbcnaps
            // 
            resources.ApplyResources(this.lbcnaps, "lbcnaps");
            this.lbcnaps.Name = "lbcnaps";
            // 
            // cmbBankType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbBankType, null);
            this.cmbBankType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankType.DvDataField = null;
            this.cmbBankType.DvEditorValueChanged = false;
            this.cmbBankType.DvErrorProvider = this.errorProvider1;
            this.cmbBankType.DvLinkedLabel = null;
            this.cmbBankType.DvMaxLength = 0;
            this.cmbBankType.DvMinLength = 0;
            this.cmbBankType.DvRegCode = "";
            this.cmbBankType.DvRequired = true;
            this.cmbBankType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbBankType.DvValidateEnabled = true;
            this.cmbBankType.DvValidator = this.validatorList1;
            this.cmbBankType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbBankType, "cmbBankType");
            this.cmbBankType.Name = "cmbBankType";
            this.cmbBankType.SelectedIndexChanged += new System.EventHandler(this.cmbBankType_SelectedIndexChanged);
            // 
            // lbpayeeName
            // 
            resources.ApplyResources(this.lbpayeeName, "lbpayeeName");
            this.lbpayeeName.ForeColor = System.Drawing.Color.Red;
            this.lbpayeeName.Name = "lbpayeeName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // tbcnaps
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbcnaps, null);
            this.tbcnaps.BackColor = System.Drawing.SystemColors.Window;
            this.tbcnaps.DvDataField = null;
            this.tbcnaps.DvEditorValueChanged = false;
            this.tbcnaps.DvErrorProvider = this.errorProvider1;
            this.tbcnaps.DvLinkedLabel = this.lbcnaps;
            this.tbcnaps.DvMaxLength = 12;
            this.tbcnaps.DvMinLength = 0;
            this.tbcnaps.DvRegCode = "";
            this.tbcnaps.DvRequired = false;
            this.tbcnaps.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbcnaps.DvValidateEnabled = true;
            this.tbcnaps.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbcnaps, "tbcnaps");
            this.tbcnaps.Name = "tbcnaps";
            // 
            // lbOpenBankType
            // 
            resources.ApplyResources(this.lbOpenBankType, "lbOpenBankType");
            this.lbOpenBankType.Name = "lbOpenBankType";
            // 
            // lblcnaps
            // 
            resources.ApplyResources(this.lblcnaps, "lblcnaps");
            this.lblcnaps.ForeColor = System.Drawing.Color.Red;
            this.lblcnaps.Name = "lblcnaps";
            // 
            // lbOpenBank
            // 
            resources.ApplyResources(this.lbOpenBank, "lbOpenBank");
            this.lbOpenBank.ForeColor = System.Drawing.Color.Red;
            this.lbOpenBank.Name = "lbOpenBank";
            // 
            // chbSave
            // 
            resources.ApplyResources(this.chbSave, "chbSave");
            this.chbSave.Checked = true;
            this.chbSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSave.Name = "chbSave";
            this.chbSave.UseVisualStyleBackColor = true;
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::CommonClient.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.MouseHover += new System.EventHandler(this.pbTip_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbPayeeAccount);
            this.panel1.Controls.Add(this.pbTip);
            this.panel1.Controls.Add(this.lbOpenBank);
            this.panel1.Controls.Add(this.btnQueryAccount);
            this.panel1.Controls.Add(this.lbOpenBankType);
            this.panel1.Controls.Add(this.chbSave);
            this.panel1.Controls.Add(this.lblPayeeName);
            this.panel1.Controls.Add(this.cmbBankType);
            this.panel1.Controls.Add(this.lblPayeeAccount);
            this.panel1.Controls.Add(this.lbpayeeName);
            this.panel1.Controls.Add(this.edtPayeeName);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.edtPayeeBankName);
            this.panel3.Controls.Add(this.btnQueryBank);
            this.panel3.Controls.Add(this.lblPayeeEmail);
            this.panel3.Controls.Add(this.edtPayeeEmail);
            this.panel3.Controls.Add(this.lbcnaps);
            this.panel3.Controls.Add(this.tbcnaps);
            this.panel3.Controls.Add(this.lblcnaps);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // ambiguityInputAgent1
            // 
            this.ambiguityInputAgent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent1.ImageList = null;
            this.ambiguityInputAgent1.Items = new string[0];
            this.ambiguityInputAgent1.MinFragmentLength = 2;
            this.ambiguityInputAgent1.SearchPattern = "[0-9a-zA-Z]";
            this.ambiguityInputAgent1.TargetControlPacker = null;
            // 
            // PayeeSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.edtPayeePhone);
            resources.ApplyResources(this, "$this");
            this.Name = "PayeeSelector";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label lblPayeeName;
        private System.Windows.Forms.Label lblPayeeEmail;
        private ComboBoxCanValidate cmbPayeeAccount;
        private TextBoxCanValidate edtPayeeName;
        private TextBoxCanValidate edtPayeeBankName;
        private TextBoxCanValidate edtPayeeEmail;
        private TextBoxCanValidate edtPayeePhone;
        private ThemedButton btnQueryBank;
        private ThemedButton btnQueryAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbpayeeName;
        private System.Windows.Forms.Label lbOpenBank;
        private ComboBoxCanValidate cmbBankType;
        private System.Windows.Forms.Label lbOpenBankType;
        private System.Windows.Forms.Label lbcnaps;
        private TextBoxCanValidate tbcnaps;
        private System.Windows.Forms.Label lblcnaps;
        private System.Windows.Forms.CheckBox chbSave;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private AmbiguityInputAgent ambiguityInputAgent1;
    }
}
