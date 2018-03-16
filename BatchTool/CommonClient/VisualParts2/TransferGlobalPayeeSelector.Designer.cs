using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class TransferGlobalPayeeSelector
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferGlobalPayeeSelector));
            this.p_FC = new System.Windows.Forms.Panel();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cmbPayeeAccountType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbPayeeAccountType = new System.Windows.Forms.Label();
            this.cmbRemitCountry = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbRemitCountry = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.p_ForeignMoneyBar = new System.Windows.Forms.Panel();
            this.cbNoticeType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbNoticeType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPayeeCertPaperType = new CommonClient.Controls.ComboBoxCanValidate();
            this.cmbPayeeAccountProvince = new CommonClient.Controls.ComboBoxCanValidate();
            this.edtCertPaperNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCertiCardNo = new System.Windows.Forms.Label();
            this.lbCertiCardType = new System.Windows.Forms.Label();
            this.lbProvince = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.p_swiftc = new System.Windows.Forms.Panel();
            this.tbCSwiftCode = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCSwiftCode = new System.Windows.Forms.Label();
            this.tbPayeeOpenBankAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeOpenBankAddress = new System.Windows.Forms.Label();
            this.btnQueryCorrespondentBank = new CommonClient.Controls.ThemedButton();
            this.tbPayeeAccountInCorrespondentBank = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeAccountInCorrespondentBank = new System.Windows.Forms.Label();
            this.lbCorrespondentBankName = new System.Windows.Forms.Label();
            this.tbCorrespondentBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCorrespondentBankAddress = new System.Windows.Forms.Label();
            this.lblOpenBankAddress = new System.Windows.Forms.Label();
            this.tbCorrespondentBankAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.p_BankCode = new System.Windows.Forms.Panel();
            this.lbFSwiftCode = new System.Windows.Forms.Label();
            this.tbOSwiftCode = new CommonClient.Controls.TextBoxCanValidate();
            this.p_OtherBank = new System.Windows.Forms.Panel();
            this.tbFPayeeOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.btnFPayeeOpenBankName = new CommonClient.Controls.ThemedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbPayeeAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbPayeeAccount = new System.Windows.Forms.Label();
            this.p_OverCountry = new System.Windows.Forms.Panel();
            this.tbPayeeOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeOpenBankName = new System.Windows.Forms.Label();
            this.btnQueryOpenBank = new CommonClient.Controls.ThemedButton();
            this.p_ForeignMoney = new System.Windows.Forms.Panel();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.rbBOC = new System.Windows.Forms.RadioButton();
            this.btnQueryPayee = new CommonClient.Controls.ThemedButton();
            this.tbCountry = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCountry = new System.Windows.Forms.Label();
            this.btnQueryCountry = new CommonClient.Controls.ThemedButton();
            this.tbPayeeAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeAddress = new System.Windows.Forms.Label();
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbPayeeName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_FC.SuspendLayout();
            this.p_ForeignMoneyBar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.p_swiftc.SuspendLayout();
            this.p_BankCode.SuspendLayout();
            this.p_OtherBank.SuspendLayout();
            this.panel2.SuspendLayout();
            this.p_OverCountry.SuspendLayout();
            this.p_ForeignMoney.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_FC
            // 
            this.p_FC.Controls.Add(this.lblAccountType);
            this.p_FC.Controls.Add(this.cmbPayeeAccountType);
            this.p_FC.Controls.Add(this.cmbRemitCountry);
            this.p_FC.Controls.Add(this.lbPayeeAccountType);
            this.p_FC.Controls.Add(this.lbRemitCountry);
            this.p_FC.Controls.Add(this.label6);
            resources.ApplyResources(this.p_FC, "p_FC");
            this.p_FC.Name = "p_FC";
            // 
            // lblAccountType
            // 
            resources.ApplyResources(this.lblAccountType, "lblAccountType");
            this.lblAccountType.ForeColor = System.Drawing.Color.Red;
            this.lblAccountType.Name = "lblAccountType";
            // 
            // cmbPayeeAccountType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayeeAccountType, null);
            this.cmbPayeeAccountType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeAccountType.DvDataField = null;
            this.cmbPayeeAccountType.DvEditorValueChanged = false;
            this.cmbPayeeAccountType.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccountType.DvLinkedLabel = this.lbPayeeAccountType;
            this.cmbPayeeAccountType.DvMaxLength = 0;
            this.cmbPayeeAccountType.DvMinLength = 0;
            this.cmbPayeeAccountType.DvRegCode = "";
            this.cmbPayeeAccountType.DvRequired = false;
            this.cmbPayeeAccountType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccountType.DvValidateEnabled = true;
            this.cmbPayeeAccountType.DvValidator = this.validatorList1;
            this.cmbPayeeAccountType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccountType, "cmbPayeeAccountType");
            this.cmbPayeeAccountType.Name = "cmbPayeeAccountType";
            // 
            // lbPayeeAccountType
            // 
            resources.ApplyResources(this.lbPayeeAccountType, "lbPayeeAccountType");
            this.lbPayeeAccountType.Name = "lbPayeeAccountType";
            // 
            // cmbRemitCountry
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbRemitCountry, null);
            this.cmbRemitCountry.BackColor = System.Drawing.SystemColors.Window;
            this.cmbRemitCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemitCountry.DvDataField = null;
            this.cmbRemitCountry.DvEditorValueChanged = false;
            this.cmbRemitCountry.DvErrorProvider = this.errorProvider1;
            this.cmbRemitCountry.DvLinkedLabel = this.lbRemitCountry;
            this.cmbRemitCountry.DvMaxLength = 0;
            this.cmbRemitCountry.DvMinLength = 0;
            this.cmbRemitCountry.DvRegCode = "";
            this.cmbRemitCountry.DvRequired = false;
            this.cmbRemitCountry.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbRemitCountry.DvValidateEnabled = true;
            this.cmbRemitCountry.DvValidator = this.validatorList1;
            this.cmbRemitCountry.FormattingEnabled = true;
            resources.ApplyResources(this.cmbRemitCountry, "cmbRemitCountry");
            this.cmbRemitCountry.Name = "cmbRemitCountry";
            // 
            // lbRemitCountry
            // 
            resources.ApplyResources(this.lbRemitCountry, "lbRemitCountry");
            this.lbRemitCountry.Name = "lbRemitCountry";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // p_ForeignMoneyBar
            // 
            this.p_ForeignMoneyBar.Controls.Add(this.cbNoticeType);
            this.p_ForeignMoneyBar.Controls.Add(this.lbNoticeType);
            this.p_ForeignMoneyBar.Controls.Add(this.label2);
            this.p_ForeignMoneyBar.Controls.Add(this.cmbPayeeCertPaperType);
            this.p_ForeignMoneyBar.Controls.Add(this.cmbPayeeAccountProvince);
            this.p_ForeignMoneyBar.Controls.Add(this.edtCertPaperNo);
            this.p_ForeignMoneyBar.Controls.Add(this.lbCertiCardNo);
            this.p_ForeignMoneyBar.Controls.Add(this.lbCertiCardType);
            this.p_ForeignMoneyBar.Controls.Add(this.lbProvince);
            this.p_ForeignMoneyBar.Controls.Add(this.lblProvince);
            resources.ApplyResources(this.p_ForeignMoneyBar, "p_ForeignMoneyBar");
            this.p_ForeignMoneyBar.Name = "p_ForeignMoneyBar";
            // 
            // cbNoticeType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cbNoticeType, null);
            this.cbNoticeType.BackColor = System.Drawing.SystemColors.Window;
            this.cbNoticeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoticeType.DvDataField = null;
            this.cbNoticeType.DvEditorValueChanged = false;
            this.cbNoticeType.DvErrorProvider = this.errorProvider1;
            this.cbNoticeType.DvLinkedLabel = null;
            this.cbNoticeType.DvMaxLength = 0;
            this.cbNoticeType.DvMinLength = 0;
            this.cbNoticeType.DvRegCode = "";
            this.cbNoticeType.DvRequired = false;
            this.cbNoticeType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cbNoticeType.DvValidateEnabled = true;
            this.cbNoticeType.DvValidator = this.validatorList1;
            this.cbNoticeType.FormattingEnabled = true;
            resources.ApplyResources(this.cbNoticeType, "cbNoticeType");
            this.cbNoticeType.Name = "cbNoticeType";
            // 
            // lbNoticeType
            // 
            resources.ApplyResources(this.lbNoticeType, "lbNoticeType");
            this.lbNoticeType.Name = "lbNoticeType";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // cmbPayeeCertPaperType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayeeCertPaperType, null);
            this.cmbPayeeCertPaperType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeCertPaperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeCertPaperType.DvDataField = null;
            this.cmbPayeeCertPaperType.DvEditorValueChanged = false;
            this.cmbPayeeCertPaperType.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeCertPaperType.DvLinkedLabel = null;
            this.cmbPayeeCertPaperType.DvMaxLength = 0;
            this.cmbPayeeCertPaperType.DvMinLength = 0;
            this.cmbPayeeCertPaperType.DvRegCode = "";
            this.cmbPayeeCertPaperType.DvRequired = false;
            this.cmbPayeeCertPaperType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeCertPaperType.DvValidateEnabled = true;
            this.cmbPayeeCertPaperType.DvValidator = this.validatorList1;
            this.cmbPayeeCertPaperType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeCertPaperType, "cmbPayeeCertPaperType");
            this.cmbPayeeCertPaperType.Name = "cmbPayeeCertPaperType";
            // 
            // cmbPayeeAccountProvince
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayeeAccountProvince, null);
            this.cmbPayeeAccountProvince.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccountProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeAccountProvince.DvDataField = null;
            this.cmbPayeeAccountProvince.DvEditorValueChanged = false;
            this.cmbPayeeAccountProvince.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccountProvince.DvLinkedLabel = null;
            this.cmbPayeeAccountProvince.DvMaxLength = 0;
            this.cmbPayeeAccountProvince.DvMinLength = 0;
            this.cmbPayeeAccountProvince.DvRegCode = "";
            this.cmbPayeeAccountProvince.DvRequired = false;
            this.cmbPayeeAccountProvince.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccountProvince.DvValidateEnabled = true;
            this.cmbPayeeAccountProvince.DvValidator = this.validatorList1;
            this.cmbPayeeAccountProvince.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccountProvince, "cmbPayeeAccountProvince");
            this.cmbPayeeAccountProvince.Name = "cmbPayeeAccountProvince";
            // 
            // edtCertPaperNo
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.edtCertPaperNo, null);
            this.edtCertPaperNo.BackColor = System.Drawing.SystemColors.Window;
            this.edtCertPaperNo.DvDataField = null;
            this.edtCertPaperNo.DvEditorValueChanged = false;
            this.edtCertPaperNo.DvErrorProvider = this.errorProvider1;
            this.edtCertPaperNo.DvLinkedLabel = this.lbCertiCardNo;
            this.edtCertPaperNo.DvMaxLength = 0;
            this.edtCertPaperNo.DvMinLength = 0;
            this.edtCertPaperNo.DvRegCode = "";
            this.edtCertPaperNo.DvRequired = false;
            this.edtCertPaperNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtCertPaperNo.DvValidateEnabled = true;
            this.edtCertPaperNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtCertPaperNo, "edtCertPaperNo");
            this.edtCertPaperNo.Name = "edtCertPaperNo";
            // 
            // lbCertiCardNo
            // 
            resources.ApplyResources(this.lbCertiCardNo, "lbCertiCardNo");
            this.lbCertiCardNo.Name = "lbCertiCardNo";
            // 
            // lbCertiCardType
            // 
            resources.ApplyResources(this.lbCertiCardType, "lbCertiCardType");
            this.lbCertiCardType.Name = "lbCertiCardType";
            // 
            // lbProvince
            // 
            resources.ApplyResources(this.lbProvince, "lbProvince");
            this.lbProvince.Name = "lbProvince";
            // 
            // lblProvince
            // 
            resources.ApplyResources(this.lblProvince, "lblProvince");
            this.lblProvince.ForeColor = System.Drawing.Color.Red;
            this.lblProvince.Name = "lblProvince";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.p_swiftc);
            this.panel3.Controls.Add(this.tbPayeeOpenBankAddress);
            this.panel3.Controls.Add(this.btnQueryCorrespondentBank);
            this.panel3.Controls.Add(this.lbPayeeOpenBankAddress);
            this.panel3.Controls.Add(this.tbPayeeAccountInCorrespondentBank);
            this.panel3.Controls.Add(this.lbCorrespondentBankName);
            this.panel3.Controls.Add(this.lbPayeeAccountInCorrespondentBank);
            this.panel3.Controls.Add(this.tbCorrespondentBankName);
            this.panel3.Controls.Add(this.lbCorrespondentBankAddress);
            this.panel3.Controls.Add(this.lblOpenBankAddress);
            this.panel3.Controls.Add(this.tbCorrespondentBankAddress);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // p_swiftc
            // 
            this.p_swiftc.Controls.Add(this.tbCSwiftCode);
            this.p_swiftc.Controls.Add(this.lbCSwiftCode);
            resources.ApplyResources(this.p_swiftc, "p_swiftc");
            this.p_swiftc.Name = "p_swiftc";
            // 
            // tbCSwiftCode
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbCSwiftCode, null);
            this.tbCSwiftCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCSwiftCode.DvDataField = null;
            this.tbCSwiftCode.DvEditorValueChanged = false;
            this.tbCSwiftCode.DvErrorProvider = this.errorProvider1;
            this.tbCSwiftCode.DvLinkedLabel = this.lbCSwiftCode;
            this.tbCSwiftCode.DvMaxLength = 0;
            this.tbCSwiftCode.DvMinLength = 0;
            this.tbCSwiftCode.DvRegCode = "";
            this.tbCSwiftCode.DvRequired = false;
            this.tbCSwiftCode.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCSwiftCode.DvValidateEnabled = true;
            this.tbCSwiftCode.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCSwiftCode, "tbCSwiftCode");
            this.tbCSwiftCode.Name = "tbCSwiftCode";
            // 
            // lbCSwiftCode
            // 
            resources.ApplyResources(this.lbCSwiftCode, "lbCSwiftCode");
            this.lbCSwiftCode.Name = "lbCSwiftCode";
            // 
            // tbPayeeOpenBankAddress
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeOpenBankAddress, null);
            this.tbPayeeOpenBankAddress.DvDataField = null;
            this.tbPayeeOpenBankAddress.DvEditorValueChanged = false;
            this.tbPayeeOpenBankAddress.DvErrorProvider = this.errorProvider1;
            this.tbPayeeOpenBankAddress.DvLinkedLabel = this.lbPayeeOpenBankAddress;
            this.tbPayeeOpenBankAddress.DvMaxLength = 0;
            this.tbPayeeOpenBankAddress.DvMinLength = 0;
            this.tbPayeeOpenBankAddress.DvRegCode = "";
            this.tbPayeeOpenBankAddress.DvRequired = false;
            this.tbPayeeOpenBankAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeOpenBankAddress.DvValidateEnabled = true;
            this.tbPayeeOpenBankAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeOpenBankAddress, "tbPayeeOpenBankAddress");
            this.tbPayeeOpenBankAddress.Name = "tbPayeeOpenBankAddress";
            // 
            // lbPayeeOpenBankAddress
            // 
            resources.ApplyResources(this.lbPayeeOpenBankAddress, "lbPayeeOpenBankAddress");
            this.lbPayeeOpenBankAddress.Name = "lbPayeeOpenBankAddress";
            // 
            // btnQueryCorrespondentBank
            // 
            resources.ApplyResources(this.btnQueryCorrespondentBank, "btnQueryCorrespondentBank");
            this.btnQueryCorrespondentBank.Name = "btnQueryCorrespondentBank";
            this.btnQueryCorrespondentBank.UseVisualStyleBackColor = true;
            this.btnQueryCorrespondentBank.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // tbPayeeAccountInCorrespondentBank
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeAccountInCorrespondentBank, null);
            this.tbPayeeAccountInCorrespondentBank.DvDataField = null;
            this.tbPayeeAccountInCorrespondentBank.DvEditorValueChanged = false;
            this.tbPayeeAccountInCorrespondentBank.DvErrorProvider = this.errorProvider1;
            this.tbPayeeAccountInCorrespondentBank.DvLinkedLabel = this.lbPayeeAccountInCorrespondentBank;
            this.tbPayeeAccountInCorrespondentBank.DvMaxLength = 0;
            this.tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
            this.tbPayeeAccountInCorrespondentBank.DvRegCode = "";
            this.tbPayeeAccountInCorrespondentBank.DvRequired = false;
            this.tbPayeeAccountInCorrespondentBank.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeAccountInCorrespondentBank.DvValidateEnabled = true;
            this.tbPayeeAccountInCorrespondentBank.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeAccountInCorrespondentBank, "tbPayeeAccountInCorrespondentBank");
            this.tbPayeeAccountInCorrespondentBank.Name = "tbPayeeAccountInCorrespondentBank";
            // 
            // lbPayeeAccountInCorrespondentBank
            // 
            resources.ApplyResources(this.lbPayeeAccountInCorrespondentBank, "lbPayeeAccountInCorrespondentBank");
            this.lbPayeeAccountInCorrespondentBank.Name = "lbPayeeAccountInCorrespondentBank";
            // 
            // lbCorrespondentBankName
            // 
            resources.ApplyResources(this.lbCorrespondentBankName, "lbCorrespondentBankName");
            this.lbCorrespondentBankName.Name = "lbCorrespondentBankName";
            // 
            // tbCorrespondentBankName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbCorrespondentBankName, null);
            this.tbCorrespondentBankName.DvDataField = null;
            this.tbCorrespondentBankName.DvEditorValueChanged = false;
            this.tbCorrespondentBankName.DvErrorProvider = this.errorProvider1;
            this.tbCorrespondentBankName.DvLinkedLabel = this.lbCorrespondentBankName;
            this.tbCorrespondentBankName.DvMaxLength = 0;
            this.tbCorrespondentBankName.DvMinLength = 0;
            this.tbCorrespondentBankName.DvRegCode = "";
            this.tbCorrespondentBankName.DvRequired = false;
            this.tbCorrespondentBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCorrespondentBankName.DvValidateEnabled = true;
            this.tbCorrespondentBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCorrespondentBankName, "tbCorrespondentBankName");
            this.tbCorrespondentBankName.Name = "tbCorrespondentBankName";
            // 
            // lbCorrespondentBankAddress
            // 
            resources.ApplyResources(this.lbCorrespondentBankAddress, "lbCorrespondentBankAddress");
            this.lbCorrespondentBankAddress.Name = "lbCorrespondentBankAddress";
            // 
            // lblOpenBankAddress
            // 
            resources.ApplyResources(this.lblOpenBankAddress, "lblOpenBankAddress");
            this.lblOpenBankAddress.ForeColor = System.Drawing.Color.Red;
            this.lblOpenBankAddress.Name = "lblOpenBankAddress";
            // 
            // tbCorrespondentBankAddress
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbCorrespondentBankAddress, null);
            this.tbCorrespondentBankAddress.DvDataField = null;
            this.tbCorrespondentBankAddress.DvEditorValueChanged = false;
            this.tbCorrespondentBankAddress.DvErrorProvider = this.errorProvider1;
            this.tbCorrespondentBankAddress.DvLinkedLabel = this.lbCorrespondentBankAddress;
            this.tbCorrespondentBankAddress.DvMaxLength = 0;
            this.tbCorrespondentBankAddress.DvMinLength = 0;
            this.tbCorrespondentBankAddress.DvRegCode = "";
            this.tbCorrespondentBankAddress.DvRequired = false;
            this.tbCorrespondentBankAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCorrespondentBankAddress.DvValidateEnabled = true;
            this.tbCorrespondentBankAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCorrespondentBankAddress, "tbCorrespondentBankAddress");
            this.tbCorrespondentBankAddress.Name = "tbCorrespondentBankAddress";
            // 
            // p_BankCode
            // 
            this.p_BankCode.Controls.Add(this.lbFSwiftCode);
            this.p_BankCode.Controls.Add(this.tbOSwiftCode);
            resources.ApplyResources(this.p_BankCode, "p_BankCode");
            this.p_BankCode.Name = "p_BankCode";
            // 
            // lbFSwiftCode
            // 
            resources.ApplyResources(this.lbFSwiftCode, "lbFSwiftCode");
            this.lbFSwiftCode.Name = "lbFSwiftCode";
            // 
            // tbOSwiftCode
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbOSwiftCode, null);
            this.tbOSwiftCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbOSwiftCode.DvDataField = null;
            this.tbOSwiftCode.DvEditorValueChanged = false;
            this.tbOSwiftCode.DvErrorProvider = this.errorProvider1;
            this.tbOSwiftCode.DvLinkedLabel = this.lbFSwiftCode;
            this.tbOSwiftCode.DvMaxLength = 0;
            this.tbOSwiftCode.DvMinLength = 0;
            this.tbOSwiftCode.DvRegCode = "";
            this.tbOSwiftCode.DvRequired = false;
            this.tbOSwiftCode.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOSwiftCode.DvValidateEnabled = true;
            this.tbOSwiftCode.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOSwiftCode, "tbOSwiftCode");
            this.tbOSwiftCode.Name = "tbOSwiftCode";
            // 
            // p_OtherBank
            // 
            this.p_OtherBank.Controls.Add(this.tbFPayeeOpenBankName);
            this.p_OtherBank.Controls.Add(this.btnFPayeeOpenBankName);
            resources.ApplyResources(this.p_OtherBank, "p_OtherBank");
            this.p_OtherBank.Name = "p_OtherBank";
            // 
            // tbFPayeeOpenBankName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbFPayeeOpenBankName, null);
            this.tbFPayeeOpenBankName.DvDataField = null;
            this.tbFPayeeOpenBankName.DvEditorValueChanged = false;
            this.tbFPayeeOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbFPayeeOpenBankName.DvLinkedLabel = null;
            this.tbFPayeeOpenBankName.DvMaxLength = 0;
            this.tbFPayeeOpenBankName.DvMinLength = 0;
            this.tbFPayeeOpenBankName.DvRegCode = "";
            this.tbFPayeeOpenBankName.DvRequired = false;
            this.tbFPayeeOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbFPayeeOpenBankName.DvValidateEnabled = true;
            this.tbFPayeeOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbFPayeeOpenBankName, "tbFPayeeOpenBankName");
            this.tbFPayeeOpenBankName.Name = "tbFPayeeOpenBankName";
            // 
            // btnFPayeeOpenBankName
            // 
            resources.ApplyResources(this.btnFPayeeOpenBankName, "btnFPayeeOpenBankName");
            this.btnFPayeeOpenBankName.Name = "btnFPayeeOpenBankName";
            this.btnFPayeeOpenBankName.UseVisualStyleBackColor = true;
            this.btnFPayeeOpenBankName.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbPayeeAccount);
            this.panel2.Controls.Add(this.p_OverCountry);
            this.panel2.Controls.Add(this.lbPayeeAccount);
            this.panel2.Controls.Add(this.p_ForeignMoney);
            this.panel2.Controls.Add(this.btnQueryPayee);
            this.panel2.Controls.Add(this.tbCountry);
            this.panel2.Controls.Add(this.btnQueryCountry);
            this.panel2.Controls.Add(this.tbPayeeAddress);
            this.panel2.Controls.Add(this.chbSave);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lbPayeeName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbPayeeName);
            this.panel2.Controls.Add(this.lbCountry);
            this.panel2.Controls.Add(this.lbPayeeOpenBankName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lbPayeeAddress);
            this.panel2.Controls.Add(this.label4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // cmbPayeeAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayeeAccount, this.ambiguityInputAgent1);
            this.cmbPayeeAccount.DvDataField = null;
            this.cmbPayeeAccount.DvEditorValueChanged = false;
            this.cmbPayeeAccount.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccount.DvLinkedLabel = this.lbPayeeAccount;
            this.cmbPayeeAccount.DvMaxLength = 0;
            this.cmbPayeeAccount.DvMinLength = 0;
            this.cmbPayeeAccount.DvRegCode = "";
            this.cmbPayeeAccount.DvRequired = true;
            this.cmbPayeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccount.DvValidateEnabled = true;
            this.cmbPayeeAccount.DvValidator = this.validatorList1;
            this.cmbPayeeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccount, "cmbPayeeAccount");
            this.cmbPayeeAccount.Name = "cmbPayeeAccount";
            // 
            // lbPayeeAccount
            // 
            resources.ApplyResources(this.lbPayeeAccount, "lbPayeeAccount");
            this.lbPayeeAccount.Name = "lbPayeeAccount";
            // 
            // p_OverCountry
            // 
            this.p_OverCountry.Controls.Add(this.tbPayeeOpenBankName);
            this.p_OverCountry.Controls.Add(this.btnQueryOpenBank);
            resources.ApplyResources(this.p_OverCountry, "p_OverCountry");
            this.p_OverCountry.Name = "p_OverCountry";
            // 
            // tbPayeeOpenBankName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeOpenBankName, null);
            this.tbPayeeOpenBankName.DvDataField = null;
            this.tbPayeeOpenBankName.DvEditorValueChanged = false;
            this.tbPayeeOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbPayeeOpenBankName.DvLinkedLabel = this.lbPayeeOpenBankName;
            this.tbPayeeOpenBankName.DvMaxLength = 0;
            this.tbPayeeOpenBankName.DvMinLength = 0;
            this.tbPayeeOpenBankName.DvRegCode = "";
            this.tbPayeeOpenBankName.DvRequired = false;
            this.tbPayeeOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeOpenBankName.DvValidateEnabled = true;
            this.tbPayeeOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeOpenBankName, "tbPayeeOpenBankName");
            this.tbPayeeOpenBankName.Name = "tbPayeeOpenBankName";
            // 
            // lbPayeeOpenBankName
            // 
            resources.ApplyResources(this.lbPayeeOpenBankName, "lbPayeeOpenBankName");
            this.lbPayeeOpenBankName.Name = "lbPayeeOpenBankName";
            // 
            // btnQueryOpenBank
            // 
            resources.ApplyResources(this.btnQueryOpenBank, "btnQueryOpenBank");
            this.btnQueryOpenBank.Name = "btnQueryOpenBank";
            this.btnQueryOpenBank.UseVisualStyleBackColor = true;
            this.btnQueryOpenBank.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // p_ForeignMoney
            // 
            this.p_ForeignMoney.Controls.Add(this.rbOther);
            this.p_ForeignMoney.Controls.Add(this.rbBOC);
            resources.ApplyResources(this.p_ForeignMoney, "p_ForeignMoney");
            this.p_ForeignMoney.Name = "p_ForeignMoney";
            // 
            // rbOther
            // 
            resources.ApplyResources(this.rbOther, "rbOther");
            this.rbOther.Name = "rbOther";
            this.rbOther.UseVisualStyleBackColor = true;
            // 
            // rbBOC
            // 
            resources.ApplyResources(this.rbBOC, "rbBOC");
            this.rbBOC.Checked = true;
            this.rbBOC.Name = "rbBOC";
            this.rbBOC.TabStop = true;
            this.rbBOC.UseVisualStyleBackColor = true;
            // 
            // btnQueryPayee
            // 
            resources.ApplyResources(this.btnQueryPayee, "btnQueryPayee");
            this.btnQueryPayee.Name = "btnQueryPayee";
            this.btnQueryPayee.UseVisualStyleBackColor = true;
            this.btnQueryPayee.Click += new System.EventHandler(this.btnQueryPayee_Click);
            // 
            // tbCountry
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbCountry, null);
            this.tbCountry.DvDataField = null;
            this.tbCountry.DvEditorValueChanged = false;
            this.tbCountry.DvErrorProvider = this.errorProvider1;
            this.tbCountry.DvLinkedLabel = this.lbCountry;
            this.tbCountry.DvMaxLength = 0;
            this.tbCountry.DvMinLength = 0;
            this.tbCountry.DvRegCode = "";
            this.tbCountry.DvRequired = false;
            this.tbCountry.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCountry.DvValidateEnabled = true;
            this.tbCountry.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCountry, "tbCountry");
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.ReadOnly = true;
            // 
            // lbCountry
            // 
            resources.ApplyResources(this.lbCountry, "lbCountry");
            this.lbCountry.Name = "lbCountry";
            // 
            // btnQueryCountry
            // 
            resources.ApplyResources(this.btnQueryCountry, "btnQueryCountry");
            this.btnQueryCountry.Name = "btnQueryCountry";
            this.btnQueryCountry.UseVisualStyleBackColor = true;
            this.btnQueryCountry.Click += new System.EventHandler(this.btnQueryCountry_Click);
            // 
            // tbPayeeAddress
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeAddress, null);
            this.tbPayeeAddress.DvDataField = null;
            this.tbPayeeAddress.DvEditorValueChanged = false;
            this.tbPayeeAddress.DvErrorProvider = this.errorProvider1;
            this.tbPayeeAddress.DvLinkedLabel = this.lbPayeeAddress;
            this.tbPayeeAddress.DvMaxLength = 0;
            this.tbPayeeAddress.DvMinLength = 0;
            this.tbPayeeAddress.DvRegCode = "";
            this.tbPayeeAddress.DvRequired = false;
            this.tbPayeeAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeAddress.DvValidateEnabled = true;
            this.tbPayeeAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeAddress, "tbPayeeAddress");
            this.tbPayeeAddress.Name = "tbPayeeAddress";
            // 
            // lbPayeeAddress
            // 
            resources.ApplyResources(this.lbPayeeAddress, "lbPayeeAddress");
            this.lbPayeeAddress.Name = "lbPayeeAddress";
            // 
            // chbSave
            // 
            resources.ApplyResources(this.chbSave, "chbSave");
            this.chbSave.Checked = true;
            this.chbSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSave.Name = "chbSave";
            this.chbSave.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // lbPayeeName
            // 
            resources.ApplyResources(this.lbPayeeName, "lbPayeeName");
            this.lbPayeeName.Name = "lbPayeeName";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // tbPayeeName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeName, null);
            this.tbPayeeName.DvDataField = null;
            this.tbPayeeName.DvEditorValueChanged = false;
            this.tbPayeeName.DvErrorProvider = this.errorProvider1;
            this.tbPayeeName.DvLinkedLabel = this.lbPayeeName;
            this.tbPayeeName.DvMaxLength = 0;
            this.tbPayeeName.DvMinLength = 0;
            this.tbPayeeName.DvRegCode = "";
            this.tbPayeeName.DvRequired = false;
            this.tbPayeeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeName.DvValidateEnabled = true;
            this.tbPayeeName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeName, "tbPayeeName");
            this.tbPayeeName.Name = "tbPayeeName";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
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
            // TransferGlobalPayeeSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.p_ForeignMoneyBar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.p_BankCode);
            this.Controls.Add(this.p_OtherBank);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.p_FC);
            this.Name = "TransferGlobalPayeeSelector";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_FC.ResumeLayout(false);
            this.p_FC.PerformLayout();
            this.p_ForeignMoneyBar.ResumeLayout(false);
            this.p_ForeignMoneyBar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.p_swiftc.ResumeLayout(false);
            this.p_swiftc.PerformLayout();
            this.p_BankCode.ResumeLayout(false);
            this.p_BankCode.PerformLayout();
            this.p_OtherBank.ResumeLayout(false);
            this.p_OtherBank.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.p_OverCountry.ResumeLayout(false);
            this.p_OverCountry.PerformLayout();
            this.p_ForeignMoney.ResumeLayout(false);
            this.p_ForeignMoney.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_FC;
        private System.Windows.Forms.Panel p_ForeignMoneyBar;
        private Controls.ComboBoxCanValidate cbNoticeType;
        private System.Windows.Forms.Label lbNoticeType;
        private System.Windows.Forms.Label label2;
        private Controls.ComboBoxCanValidate cmbPayeeCertPaperType;
        private Controls.ComboBoxCanValidate cmbPayeeAccountProvince;
        private Controls.TextBoxCanValidate edtCertPaperNo;
        private System.Windows.Forms.Label lbCertiCardNo;
        private System.Windows.Forms.Label lbCertiCardType;
        private System.Windows.Forms.Label lbProvince;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel p_swiftc;
        private Controls.TextBoxCanValidate tbCSwiftCode;
        private System.Windows.Forms.Label lbCSwiftCode;
        private TextBoxCanValidate tbPayeeOpenBankAddress;
        private ThemedButton btnQueryCorrespondentBank;
        private System.Windows.Forms.Label lbPayeeOpenBankAddress;
        private Controls.TextBoxCanValidate tbPayeeAccountInCorrespondentBank;
        private System.Windows.Forms.Label lbCorrespondentBankName;
        private System.Windows.Forms.Label lbPayeeAccountInCorrespondentBank;
        private Controls.TextBoxCanValidate tbCorrespondentBankName;
        private System.Windows.Forms.Label lbCorrespondentBankAddress;
        private System.Windows.Forms.Label lblOpenBankAddress;
        private Controls.TextBoxCanValidate tbCorrespondentBankAddress;
        private System.Windows.Forms.Panel p_BankCode;
        private System.Windows.Forms.Label lbFSwiftCode;
        private Controls.TextBoxCanValidate tbOSwiftCode;
        private System.Windows.Forms.Panel p_OtherBank;
        private Controls.TextBoxCanValidate tbFPayeeOpenBankName;
        private ThemedButton btnFPayeeOpenBankName;
        private System.Windows.Forms.Panel panel2;
        private Controls.ComboBoxCanValidate cmbPayeeAccount;
        private System.Windows.Forms.Panel p_OverCountry;
        private Controls.TextBoxCanValidate tbPayeeOpenBankName;
        private ThemedButton btnQueryOpenBank;
        private System.Windows.Forms.Label lbPayeeAccount;
        private System.Windows.Forms.Panel p_ForeignMoney;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.RadioButton rbBOC;
        private ThemedButton btnQueryPayee;
        private Controls.TextBoxCanValidate tbCountry;
        private ThemedButton btnQueryCountry;
        private Controls.TextBoxCanValidate tbPayeeAddress;
        private System.Windows.Forms.CheckBox chbSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbPayeeName;
        private System.Windows.Forms.Label label5;
        private Controls.TextBoxCanValidate tbPayeeName;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label lbPayeeOpenBankName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPayeeAddress;
        private System.Windows.Forms.Label label4;
        private Controls.ComboBoxCanValidate cmbPayeeAccountType;
        private Controls.ComboBoxCanValidate cmbRemitCountry;
        private System.Windows.Forms.Label lbPayeeAccountType;
        private System.Windows.Forms.Label lbRemitCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAccountType;
        private AmbiguityInputAgent ambiguityInputAgent1;

    }
}
