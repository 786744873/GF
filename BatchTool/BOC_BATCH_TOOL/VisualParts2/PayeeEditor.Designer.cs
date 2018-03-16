using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualElements
{
    partial class PayeeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayeeEditor));
            this.lblSeperator1 = new System.Windows.Forms.Label();
            this.rbIsOtherAccount = new System.Windows.Forms.RadioButton();
            this.rbIsBocAccount = new System.Windows.Forms.RadioButton();
            this.lblPayeeAccountType = new System.Windows.Forms.Label();
            this.edtPayeeSerial = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblPayeeSerial = new System.Windows.Forms.Label();
            this.edtPayeeAccount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.edtPayeeName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.lblPayeeName = new System.Windows.Forms.Label();
            this.lblPayeeBankName = new System.Windows.Forms.Label();
            this.lblPayeeClearBank = new System.Windows.Forms.Label();
            this.edtPayeeClearBank = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.edtPayeeBankName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.cmbPayeeAccountCategoryType = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lblRequired3 = new System.Windows.Forms.Label();
            this.lblRequired1 = new System.Windows.Forms.Label();
            this.lblRequired2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.tbRowIndex = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label5 = new System.Windows.Forms.Label();
            this.panelOtherBank = new System.Windows.Forms.Panel();
            this.buttonQueryC = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.buttonQueryO = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonReset = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnEdit = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.buttonSubmit = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.pCertify = new System.Windows.Forms.Panel();
            this.cmbCertifyType = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.tbCertifyNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.edtPayeeEmail = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.edtPayeePhone = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.edtPayeeAddress = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.edtPayeeFax = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblPayeeFax = new System.Windows.Forms.Label();
            this.lblPayeePhone = new System.Windows.Forms.Label();
            this.lblPayeeEmail = new System.Windows.Forms.Label();
            this.lblPayeeAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.panelOtherBank.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pCertify.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSeperator1
            // 
            resources.ApplyResources(this.lblSeperator1, "lblSeperator1");
            this.lblSeperator1.ForeColor = System.Drawing.Color.Silver;
            this.lblSeperator1.Name = "lblSeperator1";
            // 
            // rbIsOtherAccount
            // 
            resources.ApplyResources(this.rbIsOtherAccount, "rbIsOtherAccount");
            this.rbIsOtherAccount.Name = "rbIsOtherAccount";
            this.rbIsOtherAccount.UseVisualStyleBackColor = true;
            this.rbIsOtherAccount.CheckedChanged += new System.EventHandler(this.rbIsBoccAccount_CheckedChanged);
            // 
            // rbIsBocAccount
            // 
            resources.ApplyResources(this.rbIsBocAccount, "rbIsBocAccount");
            this.rbIsBocAccount.Checked = true;
            this.rbIsBocAccount.Name = "rbIsBocAccount";
            this.rbIsBocAccount.TabStop = true;
            this.rbIsBocAccount.UseVisualStyleBackColor = true;
            this.rbIsBocAccount.CheckedChanged += new System.EventHandler(this.rbIsBoccAccount_CheckedChanged);
            // 
            // lblPayeeAccountType
            // 
            resources.ApplyResources(this.lblPayeeAccountType, "lblPayeeAccountType");
            this.lblPayeeAccountType.Name = "lblPayeeAccountType";
            // 
            // edtPayeeSerial
            // 
            this.edtPayeeSerial.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeSerial.EditorValueChanged = false;
            this.edtPayeeSerial.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeSerial, "edtPayeeSerial");
            this.edtPayeeSerial.Name = "edtPayeeSerial";
            this.edtPayeeSerial.ValidateEnabled = true;
            this.edtPayeeSerial.ValidateRule.MaxLength = 0;
            this.edtPayeeSerial.ValidateRule.MinLength = 0;
            this.edtPayeeSerial.ValidateRule.RegexValue = null;
            this.edtPayeeSerial.ValidateRule.Required = false;
            // 
            // lblPayeeSerial
            // 
            resources.ApplyResources(this.lblPayeeSerial, "lblPayeeSerial");
            this.lblPayeeSerial.Name = "lblPayeeSerial";
            // 
            // edtPayeeAccount
            // 
            this.edtPayeeAccount.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeAccount.EditorValueChanged = false;
            this.edtPayeeAccount.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeAccount, "edtPayeeAccount");
            this.edtPayeeAccount.Name = "edtPayeeAccount";
            this.edtPayeeAccount.ValidateEnabled = true;
            this.edtPayeeAccount.ValidateRule.MaxLength = 0;
            this.edtPayeeAccount.ValidateRule.MinLength = 0;
            this.edtPayeeAccount.ValidateRule.RegexValue = null;
            this.edtPayeeAccount.ValidateRule.Required = true;
            // 
            // edtPayeeName
            // 
            this.edtPayeeName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeName.EditorValueChanged = false;
            this.edtPayeeName.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeName, "edtPayeeName");
            this.edtPayeeName.Name = "edtPayeeName";
            this.edtPayeeName.ValidateEnabled = true;
            this.edtPayeeName.ValidateRule.MaxLength = 0;
            this.edtPayeeName.ValidateRule.MinLength = 0;
            this.edtPayeeName.ValidateRule.RegexValue = null;
            this.edtPayeeName.ValidateRule.Required = true;
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
            // lblPayeeBankName
            // 
            resources.ApplyResources(this.lblPayeeBankName, "lblPayeeBankName");
            this.lblPayeeBankName.Name = "lblPayeeBankName";
            // 
            // lblPayeeClearBank
            // 
            resources.ApplyResources(this.lblPayeeClearBank, "lblPayeeClearBank");
            this.lblPayeeClearBank.Name = "lblPayeeClearBank";
            // 
            // edtPayeeClearBank
            // 
            this.edtPayeeClearBank.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeClearBank.EditorValueChanged = false;
            this.edtPayeeClearBank.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeClearBank, "edtPayeeClearBank");
            this.edtPayeeClearBank.Name = "edtPayeeClearBank";
            this.edtPayeeClearBank.ValidateEnabled = false;
            this.edtPayeeClearBank.ValidateRule.MaxLength = 0;
            this.edtPayeeClearBank.ValidateRule.MinLength = 0;
            this.edtPayeeClearBank.ValidateRule.RegexValue = null;
            this.edtPayeeClearBank.ValidateRule.Required = false;
            // 
            // edtPayeeBankName
            // 
            this.edtPayeeBankName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeBankName.EditorValueChanged = false;
            this.edtPayeeBankName.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeBankName, "edtPayeeBankName");
            this.edtPayeeBankName.Name = "edtPayeeBankName";
            this.edtPayeeBankName.ValidateEnabled = false;
            this.edtPayeeBankName.ValidateRule.MaxLength = 0;
            this.edtPayeeBankName.ValidateRule.MinLength = 0;
            this.edtPayeeBankName.ValidateRule.RegexValue = null;
            this.edtPayeeBankName.ValidateRule.Required = false;
            // 
            // cmbPayeeAccountCategoryType
            // 
            this.cmbPayeeAccountCategoryType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccountCategoryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPayeeAccountCategoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeAccountCategoryType.EditorValueChanged = false;
            this.cmbPayeeAccountCategoryType.ErrorProvider = null;
            this.cmbPayeeAccountCategoryType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccountCategoryType, "cmbPayeeAccountCategoryType");
            this.cmbPayeeAccountCategoryType.MatchStrFlag = false;
            this.cmbPayeeAccountCategoryType.Name = "cmbPayeeAccountCategoryType";
            this.cmbPayeeAccountCategoryType.ValidateEnabled = true;
            this.cmbPayeeAccountCategoryType.ValidateRule.MaxLength = 0;
            this.cmbPayeeAccountCategoryType.ValidateRule.MinLength = 0;
            this.cmbPayeeAccountCategoryType.ValidateRule.RegexValue = null;
            this.cmbPayeeAccountCategoryType.ValidateRule.Required = true;
            // 
            // lblRequired3
            // 
            resources.ApplyResources(this.lblRequired3, "lblRequired3");
            this.lblRequired3.ForeColor = System.Drawing.Color.Red;
            this.lblRequired3.Name = "lblRequired3";
            // 
            // lblRequired1
            // 
            resources.ApplyResources(this.lblRequired1, "lblRequired1");
            this.lblRequired1.ForeColor = System.Drawing.Color.Red;
            this.lblRequired1.Name = "lblRequired1";
            // 
            // lblRequired2
            // 
            resources.ApplyResources(this.lblRequired2, "lblRequired2");
            this.lblRequired2.ForeColor = System.Drawing.Color.Red;
            this.lblRequired2.Name = "lblRequired2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSeperator1);
            this.panel1.Controls.Add(this.rbIsBocAccount);
            this.panel1.Controls.Add(this.rbIsOtherAccount);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbTip);
            this.panel2.Controls.Add(this.edtPayeeName);
            this.panel2.Controls.Add(this.cmbPayeeAccountCategoryType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblPayeeName);
            this.panel2.Controls.Add(this.lblRequired1);
            this.panel2.Controls.Add(this.lblRequired2);
            this.panel2.Controls.Add(this.edtPayeeAccount);
            this.panel2.Controls.Add(this.tbRowIndex);
            this.panel2.Controls.Add(this.edtPayeeSerial);
            this.panel2.Controls.Add(this.lblPayeeAccount);
            this.panel2.Controls.Add(this.lblPayeeAccountType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblPayeeSerial);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::BOC_BATCH_TOOL.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.MouseHover += new System.EventHandler(this.pbTip_MouseHover);
            // 
            // tbRowIndex
            // 
            this.tbRowIndex.BackColor = System.Drawing.SystemColors.Window;
            this.tbRowIndex.EditorValueChanged = false;
            this.tbRowIndex.ErrorProvider = null;
            resources.ApplyResources(this.tbRowIndex, "tbRowIndex");
            this.tbRowIndex.Name = "tbRowIndex";
            this.tbRowIndex.ValidateEnabled = true;
            this.tbRowIndex.ValidateRule.MaxLength = 0;
            this.tbRowIndex.ValidateRule.MinLength = 0;
            this.tbRowIndex.ValidateRule.RegexValue = null;
            this.tbRowIndex.ValidateRule.Required = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panelOtherBank
            // 
            this.panelOtherBank.Controls.Add(this.buttonQueryC);
            this.panelOtherBank.Controls.Add(this.buttonQueryO);
            this.panelOtherBank.Controls.Add(this.edtPayeeClearBank);
            this.panelOtherBank.Controls.Add(this.edtPayeeBankName);
            this.panelOtherBank.Controls.Add(this.lblPayeeClearBank);
            this.panelOtherBank.Controls.Add(this.label2);
            this.panelOtherBank.Controls.Add(this.lblPayeeBankName);
            this.panelOtherBank.Controls.Add(this.lblRequired3);
            resources.ApplyResources(this.panelOtherBank, "panelOtherBank");
            this.panelOtherBank.Name = "panelOtherBank";
            // 
            // buttonQueryC
            // 
            resources.ApplyResources(this.buttonQueryC, "buttonQueryC");
            this.buttonQueryC.Name = "buttonQueryC";
            this.buttonQueryC.UseVisualStyleBackColor = true;
            this.buttonQueryC.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonQueryO
            // 
            resources.ApplyResources(this.buttonQueryO, "buttonQueryO");
            this.buttonQueryO.Name = "buttonQueryO";
            this.buttonQueryO.UseVisualStyleBackColor = true;
            this.buttonQueryO.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonReset);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.buttonSubmit);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // buttonSubmit
            // 
            resources.ApplyResources(this.buttonSubmit, "buttonSubmit");
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // pCertify
            // 
            this.pCertify.Controls.Add(this.cmbCertifyType);
            this.pCertify.Controls.Add(this.tbCertifyNo);
            this.pCertify.Controls.Add(this.label4);
            this.pCertify.Controls.Add(this.label3);
            resources.ApplyResources(this.pCertify, "pCertify");
            this.pCertify.Name = "pCertify";
            // 
            // cmbCertifyType
            // 
            this.cmbCertifyType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCertifyType.EditorValueChanged = false;
            this.cmbCertifyType.ErrorProvider = null;
            this.cmbCertifyType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCertifyType, "cmbCertifyType");
            this.cmbCertifyType.MatchStrFlag = false;
            this.cmbCertifyType.Name = "cmbCertifyType";
            this.cmbCertifyType.ValidateEnabled = false;
            this.cmbCertifyType.ValidateRule.MaxLength = 0;
            this.cmbCertifyType.ValidateRule.MinLength = 0;
            this.cmbCertifyType.ValidateRule.RegexValue = null;
            this.cmbCertifyType.ValidateRule.Required = false;
            // 
            // tbCertifyNo
            // 
            this.tbCertifyNo.BackColor = System.Drawing.SystemColors.Window;
            this.tbCertifyNo.EditorValueChanged = false;
            this.tbCertifyNo.ErrorProvider = null;
            resources.ApplyResources(this.tbCertifyNo, "tbCertifyNo");
            this.tbCertifyNo.Name = "tbCertifyNo";
            this.tbCertifyNo.ValidateEnabled = false;
            this.tbCertifyNo.ValidateRule.MaxLength = 0;
            this.tbCertifyNo.ValidateRule.MinLength = 0;
            this.tbCertifyNo.ValidateRule.RegexValue = null;
            this.tbCertifyNo.ValidateRule.Required = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.edtPayeeEmail);
            this.panel5.Controls.Add(this.edtPayeePhone);
            this.panel5.Controls.Add(this.edtPayeeAddress);
            this.panel5.Controls.Add(this.edtPayeeFax);
            this.panel5.Controls.Add(this.lblPayeeFax);
            this.panel5.Controls.Add(this.lblPayeePhone);
            this.panel5.Controls.Add(this.lblPayeeEmail);
            this.panel5.Controls.Add(this.lblPayeeAddress);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // edtPayeeEmail
            // 
            this.edtPayeeEmail.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeEmail.EditorValueChanged = false;
            this.edtPayeeEmail.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeEmail, "edtPayeeEmail");
            this.edtPayeeEmail.Name = "edtPayeeEmail";
            this.edtPayeeEmail.ValidateEnabled = false;
            this.edtPayeeEmail.ValidateRule.MaxLength = 0;
            this.edtPayeeEmail.ValidateRule.MinLength = 0;
            this.edtPayeeEmail.ValidateRule.RegexValue = null;
            this.edtPayeeEmail.ValidateRule.Required = false;
            // 
            // edtPayeePhone
            // 
            this.edtPayeePhone.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeePhone.EditorValueChanged = false;
            this.edtPayeePhone.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeePhone, "edtPayeePhone");
            this.edtPayeePhone.Name = "edtPayeePhone";
            this.edtPayeePhone.ValidateEnabled = false;
            this.edtPayeePhone.ValidateRule.MaxLength = 0;
            this.edtPayeePhone.ValidateRule.MinLength = 0;
            this.edtPayeePhone.ValidateRule.RegexValue = null;
            this.edtPayeePhone.ValidateRule.Required = false;
            // 
            // edtPayeeAddress
            // 
            this.edtPayeeAddress.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeAddress.EditorValueChanged = false;
            this.edtPayeeAddress.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeAddress, "edtPayeeAddress");
            this.edtPayeeAddress.Name = "edtPayeeAddress";
            this.edtPayeeAddress.ValidateEnabled = false;
            this.edtPayeeAddress.ValidateRule.MaxLength = 0;
            this.edtPayeeAddress.ValidateRule.MinLength = 0;
            this.edtPayeeAddress.ValidateRule.RegexValue = null;
            this.edtPayeeAddress.ValidateRule.Required = false;
            // 
            // edtPayeeFax
            // 
            this.edtPayeeFax.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeFax.EditorValueChanged = false;
            this.edtPayeeFax.ErrorProvider = null;
            resources.ApplyResources(this.edtPayeeFax, "edtPayeeFax");
            this.edtPayeeFax.Name = "edtPayeeFax";
            this.edtPayeeFax.ValidateEnabled = false;
            this.edtPayeeFax.ValidateRule.MaxLength = 0;
            this.edtPayeeFax.ValidateRule.MinLength = 0;
            this.edtPayeeFax.ValidateRule.RegexValue = null;
            this.edtPayeeFax.ValidateRule.Required = false;
            // 
            // lblPayeeFax
            // 
            resources.ApplyResources(this.lblPayeeFax, "lblPayeeFax");
            this.lblPayeeFax.Name = "lblPayeeFax";
            // 
            // lblPayeePhone
            // 
            resources.ApplyResources(this.lblPayeePhone, "lblPayeePhone");
            this.lblPayeePhone.Name = "lblPayeePhone";
            // 
            // lblPayeeEmail
            // 
            resources.ApplyResources(this.lblPayeeEmail, "lblPayeeEmail");
            this.lblPayeeEmail.Name = "lblPayeeEmail";
            // 
            // lblPayeeAddress
            // 
            resources.ApplyResources(this.lblPayeeAddress, "lblPayeeAddress");
            this.lblPayeeAddress.Name = "lblPayeeAddress";
            // 
            // PayeeEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pCertify);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelOtherBank);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            resources.ApplyResources(this, "$this");
            this.Name = "PayeeEditor";
            this.Load += new System.EventHandler(this.PayeeEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.panelOtherBank.ResumeLayout(false);
            this.panelOtherBank.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pCertify.ResumeLayout(false);
            this.pCertify.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSeperator1;
        private System.Windows.Forms.RadioButton rbIsOtherAccount;
        private System.Windows.Forms.RadioButton rbIsBocAccount;
        private System.Windows.Forms.Label lblPayeeAccountType;
        private TextBoxCanValidate edtPayeeSerial;
        private System.Windows.Forms.Label lblPayeeSerial;
        private TextBoxCanValidate edtPayeeAccount;
        private TextBoxCanValidate edtPayeeName;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label lblPayeeName;
        private System.Windows.Forms.Label lblPayeeBankName;
        private System.Windows.Forms.Label lblPayeeClearBank;
        private TextBoxCanValidate edtPayeeClearBank;
        private TextBoxCanValidate edtPayeeBankName;
        private ComboBoxCanValidate cmbPayeeAccountCategoryType;
        private System.Windows.Forms.Label lblRequired3;
        private System.Windows.Forms.Label lblRequired1;
        private System.Windows.Forms.Label lblRequired2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelOtherBank;
        private ThemedButton buttonQueryC;
        private ThemedButton buttonQueryO;
        private System.Windows.Forms.Panel panel3;
        private ThemedButton buttonSubmit;
        private System.Windows.Forms.Panel pCertify;
        private ThemedButton buttonReset;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbCertifyType;
        private TextBoxCanValidate tbCertifyNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ThemedButton btnEdit;
        private System.Windows.Forms.Label label5;
        private TextBoxCanValidate tbRowIndex;
        private System.Windows.Forms.Panel panel5;
        private TextBoxCanValidate edtPayeeEmail;
        private TextBoxCanValidate edtPayeePhone;
        private TextBoxCanValidate edtPayeeAddress;
        private TextBoxCanValidate edtPayeeFax;
        private System.Windows.Forms.Label lblPayeeFax;
        private System.Windows.Forms.Label lblPayeePhone;
        private System.Windows.Forms.Label lblPayeeEmail;
        private System.Windows.Forms.Label lblPayeeAddress;
        private System.Windows.Forms.PictureBox pbTip;
    }
}
