using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class TransferGlobalRemitSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferGlobalRemitSelector));
            this.lbRemitDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpRemitDate = new System.Windows.Forms.DateTimePicker();
            this.lbCustomerRef = new System.Windows.Forms.Label();
            this.tbCustomerRef = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPaymentType = new System.Windows.Forms.Label();
            this.tbPaymentType = new CommonClient.Controls.TextBoxCanValidate();
            this.lbSendPriority = new System.Windows.Forms.Label();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbExpress = new System.Windows.Forms.RadioButton();
            this.lbRemitCashType = new System.Windows.Forms.Label();
            this.cmbRemitCashType = new CommonClient.Controls.ComboBoxCanValidate();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRemitAmount = new System.Windows.Forms.Label();
            this.tbRemitAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbSpotAccount = new System.Windows.Forms.Label();
            this.cmbSpotAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbPurchaseAccount = new System.Windows.Forms.Label();
            this.cmbPurchaseAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbOtherAccount = new System.Windows.Forms.Label();
            this.cmbOtherAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbPayFeeAccount = new System.Windows.Forms.Label();
            this.lbSpotAmount = new System.Windows.Forms.Label();
            this.tbSpotAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPurchaseAmount = new System.Windows.Forms.Label();
            this.tbPurchaseAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOtherAmount = new System.Windows.Forms.Label();
            this.tbOtherAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.label17 = new System.Windows.Forms.Label();
            this.lbOrgCode = new System.Windows.Forms.Label();
            this.tbOrgPre = new CommonClient.Controls.TextBoxCanValidate();
            this.label19 = new System.Windows.Forms.Label();
            this.lbRemittorName = new System.Windows.Forms.Label();
            this.tbRemittorName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbRemittorAddress = new System.Windows.Forms.Label();
            this.tbRemittorAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.label22 = new System.Windows.Forms.Label();
            this.tbOrgEnd = new CommonClient.Controls.TextBoxCanValidate();
            this.cmbPayFeeAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lblsendtype = new System.Windows.Forms.Label();
            this.lbAmountDescR = new System.Windows.Forms.Label();
            this.lbAmountDescS = new System.Windows.Forms.Label();
            this.lbAmountDescP = new System.Windows.Forms.Label();
            this.lbAmountDescO = new System.Windows.Forms.Label();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent2 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent3 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRemitDate
            // 
            resources.ApplyResources(this.lbRemitDate, "lbRemitDate");
            this.lbRemitDate.Name = "lbRemitDate";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // dtpRemitDate
            // 
            resources.ApplyResources(this.dtpRemitDate, "dtpRemitDate");
            this.dtpRemitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRemitDate.Name = "dtpRemitDate";
            // 
            // lbCustomerRef
            // 
            resources.ApplyResources(this.lbCustomerRef, "lbCustomerRef");
            this.lbCustomerRef.Name = "lbCustomerRef";
            // 
            // tbCustomerRef
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbCustomerRef, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbCustomerRef, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbCustomerRef, null);
            this.tbCustomerRef.DvDataField = null;
            this.tbCustomerRef.DvEditorValueChanged = false;
            this.tbCustomerRef.DvErrorProvider = this.errorProvider1;
            this.tbCustomerRef.DvLinkedLabel = this.lbCustomerRef;
            this.tbCustomerRef.DvMaxLength = 0;
            this.tbCustomerRef.DvMinLength = 0;
            this.tbCustomerRef.DvRegCode = "";
            this.tbCustomerRef.DvRequired = false;
            this.tbCustomerRef.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCustomerRef.DvValidateEnabled = true;
            this.tbCustomerRef.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCustomerRef, "tbCustomerRef");
            this.tbCustomerRef.Name = "tbCustomerRef";
            // 
            // lbPaymentType
            // 
            resources.ApplyResources(this.lbPaymentType, "lbPaymentType");
            this.lbPaymentType.Name = "lbPaymentType";
            // 
            // tbPaymentType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPaymentType, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbPaymentType, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbPaymentType, null);
            this.tbPaymentType.DvDataField = null;
            this.tbPaymentType.DvEditorValueChanged = true;
            this.tbPaymentType.DvErrorProvider = this.errorProvider1;
            this.tbPaymentType.DvLinkedLabel = this.lbPaymentType;
            this.tbPaymentType.DvMaxLength = 0;
            this.tbPaymentType.DvMinLength = 0;
            this.tbPaymentType.DvRegCode = "";
            this.tbPaymentType.DvRequired = false;
            this.tbPaymentType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPaymentType.DvValidateEnabled = true;
            this.tbPaymentType.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPaymentType, "tbPaymentType");
            this.tbPaymentType.Name = "tbPaymentType";
            this.tbPaymentType.ReadOnly = true;
            // 
            // lbSendPriority
            // 
            resources.ApplyResources(this.lbSendPriority, "lbSendPriority");
            this.lbSendPriority.Name = "lbSendPriority";
            // 
            // rbNormal
            // 
            resources.ApplyResources(this.rbNormal, "rbNormal");
            this.rbNormal.Checked = true;
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.TabStop = true;
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbExpress
            // 
            resources.ApplyResources(this.rbExpress, "rbExpress");
            this.rbExpress.Name = "rbExpress";
            this.rbExpress.UseVisualStyleBackColor = true;
            // 
            // lbRemitCashType
            // 
            resources.ApplyResources(this.lbRemitCashType, "lbRemitCashType");
            this.lbRemitCashType.Name = "lbRemitCashType";
            // 
            // cmbRemitCashType
            // 
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbRemitCashType, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbRemitCashType, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbRemitCashType, null);
            this.cmbRemitCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemitCashType.DvDataField = null;
            this.cmbRemitCashType.DvEditorValueChanged = false;
            this.cmbRemitCashType.DvErrorProvider = this.errorProvider1;
            this.cmbRemitCashType.DvLinkedLabel = this.lbRemitCashType;
            this.cmbRemitCashType.DvMaxLength = 0;
            this.cmbRemitCashType.DvMinLength = 0;
            this.cmbRemitCashType.DvRegCode = "";
            this.cmbRemitCashType.DvRequired = true;
            this.cmbRemitCashType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbRemitCashType.DvValidateEnabled = true;
            this.cmbRemitCashType.DvValidator = this.validatorList1;
            this.cmbRemitCashType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbRemitCashType, "cmbRemitCashType");
            this.cmbRemitCashType.Name = "cmbRemitCashType";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Name = "label8";
            // 
            // lbRemitAmount
            // 
            resources.ApplyResources(this.lbRemitAmount, "lbRemitAmount");
            this.lbRemitAmount.Name = "lbRemitAmount";
            // 
            // tbRemitAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbRemitAmount, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbRemitAmount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbRemitAmount, null);
            this.tbRemitAmount.DvDataField = null;
            this.tbRemitAmount.DvEditorValueChanged = false;
            this.tbRemitAmount.DvErrorProvider = this.errorProvider1;
            this.tbRemitAmount.DvLinkedLabel = this.lbRemitAmount;
            this.tbRemitAmount.DvMaxLength = 0;
            this.tbRemitAmount.DvMinLength = 0;
            this.tbRemitAmount.DvRegCode = "";
            this.tbRemitAmount.DvRequired = false;
            this.tbRemitAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRemitAmount.DvValidateEnabled = true;
            this.tbRemitAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRemitAmount, "tbRemitAmount");
            this.tbRemitAmount.Name = "tbRemitAmount";
            this.tbRemitAmount.TextChanged += new System.EventHandler(this.tbRemitAmount_TextChanged);
            // 
            // lbSpotAccount
            // 
            resources.ApplyResources(this.lbSpotAccount, "lbSpotAccount");
            this.lbSpotAccount.Name = "lbSpotAccount";
            // 
            // cmbSpotAccount
            // 
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbSpotAccount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbSpotAccount, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbSpotAccount, this.ambiguityInputAgent1);
            this.cmbSpotAccount.DvDataField = null;
            this.cmbSpotAccount.DvEditorValueChanged = false;
            this.cmbSpotAccount.DvErrorProvider = this.errorProvider1;
            this.cmbSpotAccount.DvLinkedLabel = this.lbSpotAccount;
            this.cmbSpotAccount.DvMaxLength = 0;
            this.cmbSpotAccount.DvMinLength = 0;
            this.cmbSpotAccount.DvRegCode = "";
            this.cmbSpotAccount.DvRequired = false;
            this.cmbSpotAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbSpotAccount.DvValidateEnabled = true;
            this.cmbSpotAccount.DvValidator = this.validatorList1;
            this.cmbSpotAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSpotAccount, "cmbSpotAccount");
            this.cmbSpotAccount.Name = "cmbSpotAccount";
            this.cmbSpotAccount.TextChanged += new System.EventHandler(this.cmbSpotAccount_TextChanged_1);
            // 
            // lbPurchaseAccount
            // 
            resources.ApplyResources(this.lbPurchaseAccount, "lbPurchaseAccount");
            this.lbPurchaseAccount.Name = "lbPurchaseAccount";
            // 
            // cmbPurchaseAccount
            // 
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbPurchaseAccount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbPurchaseAccount, this.ambiguityInputAgent2);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPurchaseAccount, null);
            this.cmbPurchaseAccount.DvDataField = null;
            this.cmbPurchaseAccount.DvEditorValueChanged = false;
            this.cmbPurchaseAccount.DvErrorProvider = this.errorProvider1;
            this.cmbPurchaseAccount.DvLinkedLabel = this.lbPurchaseAccount;
            this.cmbPurchaseAccount.DvMaxLength = 0;
            this.cmbPurchaseAccount.DvMinLength = 0;
            this.cmbPurchaseAccount.DvRegCode = "";
            this.cmbPurchaseAccount.DvRequired = false;
            this.cmbPurchaseAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPurchaseAccount.DvValidateEnabled = true;
            this.cmbPurchaseAccount.DvValidator = this.validatorList1;
            this.cmbPurchaseAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPurchaseAccount, "cmbPurchaseAccount");
            this.cmbPurchaseAccount.Name = "cmbPurchaseAccount";
            this.cmbPurchaseAccount.TextChanged += new System.EventHandler(this.cmbPurchaseAccount_TextChanged_1);
            // 
            // lbOtherAccount
            // 
            resources.ApplyResources(this.lbOtherAccount, "lbOtherAccount");
            this.lbOtherAccount.Name = "lbOtherAccount";
            // 
            // cmbOtherAccount
            // 
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbOtherAccount, this.ambiguityInputAgent3);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbOtherAccount, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbOtherAccount, null);
            this.cmbOtherAccount.DvDataField = null;
            this.cmbOtherAccount.DvEditorValueChanged = false;
            this.cmbOtherAccount.DvErrorProvider = this.errorProvider1;
            this.cmbOtherAccount.DvLinkedLabel = this.lbOtherAccount;
            this.cmbOtherAccount.DvMaxLength = 0;
            this.cmbOtherAccount.DvMinLength = 0;
            this.cmbOtherAccount.DvRegCode = "";
            this.cmbOtherAccount.DvRequired = false;
            this.cmbOtherAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbOtherAccount.DvValidateEnabled = true;
            this.cmbOtherAccount.DvValidator = this.validatorList1;
            this.cmbOtherAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbOtherAccount, "cmbOtherAccount");
            this.cmbOtherAccount.Name = "cmbOtherAccount";
            this.cmbOtherAccount.TextChanged += new System.EventHandler(this.cmbOtherAccount_TextChanged);
            // 
            // lbPayFeeAccount
            // 
            resources.ApplyResources(this.lbPayFeeAccount, "lbPayFeeAccount");
            this.lbPayFeeAccount.Name = "lbPayFeeAccount";
            // 
            // lbSpotAmount
            // 
            resources.ApplyResources(this.lbSpotAmount, "lbSpotAmount");
            this.lbSpotAmount.Name = "lbSpotAmount";
            // 
            // tbSpotAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbSpotAmount, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbSpotAmount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbSpotAmount, null);
            this.tbSpotAmount.DvDataField = null;
            this.tbSpotAmount.DvEditorValueChanged = false;
            this.tbSpotAmount.DvErrorProvider = this.errorProvider1;
            this.tbSpotAmount.DvLinkedLabel = this.lbSpotAmount;
            this.tbSpotAmount.DvMaxLength = 0;
            this.tbSpotAmount.DvMinLength = 0;
            this.tbSpotAmount.DvRegCode = "";
            this.tbSpotAmount.DvRequired = false;
            this.tbSpotAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbSpotAmount.DvValidateEnabled = true;
            this.tbSpotAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbSpotAmount, "tbSpotAmount");
            this.tbSpotAmount.Name = "tbSpotAmount";
            this.tbSpotAmount.TextChanged += new System.EventHandler(this.tbSpotAmount_TextChanged);
            // 
            // lbPurchaseAmount
            // 
            resources.ApplyResources(this.lbPurchaseAmount, "lbPurchaseAmount");
            this.lbPurchaseAmount.Name = "lbPurchaseAmount";
            // 
            // tbPurchaseAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPurchaseAmount, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbPurchaseAmount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbPurchaseAmount, null);
            this.tbPurchaseAmount.DvDataField = null;
            this.tbPurchaseAmount.DvEditorValueChanged = false;
            this.tbPurchaseAmount.DvErrorProvider = this.errorProvider1;
            this.tbPurchaseAmount.DvLinkedLabel = this.lbPurchaseAmount;
            this.tbPurchaseAmount.DvMaxLength = 0;
            this.tbPurchaseAmount.DvMinLength = 0;
            this.tbPurchaseAmount.DvRegCode = "";
            this.tbPurchaseAmount.DvRequired = false;
            this.tbPurchaseAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPurchaseAmount.DvValidateEnabled = true;
            this.tbPurchaseAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPurchaseAmount, "tbPurchaseAmount");
            this.tbPurchaseAmount.Name = "tbPurchaseAmount";
            this.tbPurchaseAmount.TextChanged += new System.EventHandler(this.tbPurchaseAmount_TextChanged);
            // 
            // lbOtherAmount
            // 
            resources.ApplyResources(this.lbOtherAmount, "lbOtherAmount");
            this.lbOtherAmount.Name = "lbOtherAmount";
            // 
            // tbOtherAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbOtherAmount, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbOtherAmount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbOtherAmount, null);
            this.tbOtherAmount.DvDataField = null;
            this.tbOtherAmount.DvEditorValueChanged = false;
            this.tbOtherAmount.DvErrorProvider = this.errorProvider1;
            this.tbOtherAmount.DvLinkedLabel = this.lbOtherAmount;
            this.tbOtherAmount.DvMaxLength = 0;
            this.tbOtherAmount.DvMinLength = 0;
            this.tbOtherAmount.DvRegCode = "";
            this.tbOtherAmount.DvRequired = false;
            this.tbOtherAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOtherAmount.DvValidateEnabled = true;
            this.tbOtherAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOtherAmount, "tbOtherAmount");
            this.tbOtherAmount.Name = "tbOtherAmount";
            this.tbOtherAmount.TextChanged += new System.EventHandler(this.tbOtherAmount_TextChanged);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Name = "label17";
            // 
            // lbOrgCode
            // 
            resources.ApplyResources(this.lbOrgCode, "lbOrgCode");
            this.lbOrgCode.Name = "lbOrgCode";
            // 
            // tbOrgPre
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbOrgPre, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbOrgPre, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbOrgPre, null);
            this.tbOrgPre.DvDataField = null;
            this.tbOrgPre.DvEditorValueChanged = false;
            this.tbOrgPre.DvErrorProvider = this.errorProvider1;
            this.tbOrgPre.DvLinkedLabel = this.lbOrgCode;
            this.tbOrgPre.DvMaxLength = 8;
            this.tbOrgPre.DvMinLength = 8;
            this.tbOrgPre.DvRegCode = "reg57";
            this.tbOrgPre.DvRequired = true;
            this.tbOrgPre.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOrgPre.DvValidateEnabled = true;
            this.tbOrgPre.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOrgPre, "tbOrgPre");
            this.tbOrgPre.Name = "tbOrgPre";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Name = "label19";
            // 
            // lbRemittorName
            // 
            resources.ApplyResources(this.lbRemittorName, "lbRemittorName");
            this.lbRemittorName.Name = "lbRemittorName";
            // 
            // tbRemittorName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbRemittorName, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbRemittorName, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbRemittorName, null);
            this.tbRemittorName.DvDataField = null;
            this.tbRemittorName.DvEditorValueChanged = false;
            this.tbRemittorName.DvErrorProvider = this.errorProvider1;
            this.tbRemittorName.DvLinkedLabel = this.lbRemittorName;
            this.tbRemittorName.DvMaxLength = 0;
            this.tbRemittorName.DvMinLength = 0;
            this.tbRemittorName.DvRegCode = "";
            this.tbRemittorName.DvRequired = false;
            this.tbRemittorName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRemittorName.DvValidateEnabled = true;
            this.tbRemittorName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRemittorName, "tbRemittorName");
            this.tbRemittorName.Name = "tbRemittorName";
            // 
            // lbRemittorAddress
            // 
            resources.ApplyResources(this.lbRemittorAddress, "lbRemittorAddress");
            this.lbRemittorAddress.Name = "lbRemittorAddress";
            // 
            // tbRemittorAddress
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbRemittorAddress, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbRemittorAddress, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbRemittorAddress, null);
            this.tbRemittorAddress.DvDataField = null;
            this.tbRemittorAddress.DvEditorValueChanged = false;
            this.tbRemittorAddress.DvErrorProvider = this.errorProvider1;
            this.tbRemittorAddress.DvLinkedLabel = this.lbRemittorAddress;
            this.tbRemittorAddress.DvMaxLength = 0;
            this.tbRemittorAddress.DvMinLength = 0;
            this.tbRemittorAddress.DvRegCode = "";
            this.tbRemittorAddress.DvRequired = false;
            this.tbRemittorAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRemittorAddress.DvValidateEnabled = true;
            this.tbRemittorAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRemittorAddress, "tbRemittorAddress");
            this.tbRemittorAddress.Name = "tbRemittorAddress";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label22.Name = "label22";
            // 
            // tbOrgEnd
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbOrgEnd, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbOrgEnd, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbOrgEnd, null);
            this.tbOrgEnd.DvDataField = null;
            this.tbOrgEnd.DvEditorValueChanged = false;
            this.tbOrgEnd.DvErrorProvider = this.errorProvider1;
            this.tbOrgEnd.DvLinkedLabel = this.lbOrgCode;
            this.tbOrgEnd.DvMaxLength = 1;
            this.tbOrgEnd.DvMinLength = 1;
            this.tbOrgEnd.DvRegCode = "reg57";
            this.tbOrgEnd.DvRequired = true;
            this.tbOrgEnd.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOrgEnd.DvValidateEnabled = true;
            this.tbOrgEnd.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOrgEnd, "tbOrgEnd");
            this.tbOrgEnd.Name = "tbOrgEnd";
            // 
            // cmbPayFeeAccount
            // 
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbPayFeeAccount, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbPayFeeAccount, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayFeeAccount, null);
            this.cmbPayFeeAccount.DvDataField = null;
            this.cmbPayFeeAccount.DvEditorValueChanged = false;
            this.cmbPayFeeAccount.DvErrorProvider = this.errorProvider1;
            this.cmbPayFeeAccount.DvLinkedLabel = this.lbPayFeeAccount;
            this.cmbPayFeeAccount.DvMaxLength = 0;
            this.cmbPayFeeAccount.DvMinLength = 0;
            this.cmbPayFeeAccount.DvRegCode = "";
            this.cmbPayFeeAccount.DvRequired = false;
            this.cmbPayFeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayFeeAccount.DvValidateEnabled = true;
            this.cmbPayFeeAccount.DvValidator = this.validatorList1;
            this.cmbPayFeeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayFeeAccount, "cmbPayFeeAccount");
            this.cmbPayFeeAccount.Name = "cmbPayFeeAccount";
            this.cmbPayFeeAccount.TextChanged += new System.EventHandler(this.cmbPayFeeAccount_TextChanged);
            // 
            // lblsendtype
            // 
            resources.ApplyResources(this.lblsendtype, "lblsendtype");
            this.lblsendtype.ForeColor = System.Drawing.Color.Red;
            this.lblsendtype.Name = "lblsendtype";
            // 
            // lbAmountDescR
            // 
            resources.ApplyResources(this.lbAmountDescR, "lbAmountDescR");
            this.lbAmountDescR.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescR.Name = "lbAmountDescR";
            // 
            // lbAmountDescS
            // 
            resources.ApplyResources(this.lbAmountDescS, "lbAmountDescS");
            this.lbAmountDescS.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescS.Name = "lbAmountDescS";
            // 
            // lbAmountDescP
            // 
            resources.ApplyResources(this.lbAmountDescP, "lbAmountDescP");
            this.lbAmountDescP.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescP.Name = "lbAmountDescP";
            // 
            // lbAmountDescO
            // 
            resources.ApplyResources(this.lbAmountDescO, "lbAmountDescO");
            this.lbAmountDescO.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescO.Name = "lbAmountDescO";
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
            // ambiguityInputAgent2
            // 
            this.ambiguityInputAgent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent2.ImageList = null;
            this.ambiguityInputAgent2.Items = new string[0];
            this.ambiguityInputAgent2.MinFragmentLength = 2;
            this.ambiguityInputAgent2.SearchPattern = "[0-9a-zA-Z]";
            this.ambiguityInputAgent2.TargetControlPacker = null;
            // 
            // ambiguityInputAgent3
            // 
            this.ambiguityInputAgent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent3.ImageList = null;
            this.ambiguityInputAgent3.Items = new string[0];
            this.ambiguityInputAgent3.MinFragmentLength = 2;
            this.ambiguityInputAgent3.SearchPattern = "[0-9a-zA-Z]";
            this.ambiguityInputAgent3.TargetControlPacker = null;
            // 
            // TransferGlobalRemitSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblsendtype);
            this.Controls.Add(this.tbRemittorAddress);
            this.Controls.Add(this.tbOrgEnd);
            this.Controls.Add(this.tbOrgPre);
            this.Controls.Add(this.lbRemittorAddress);
            this.Controls.Add(this.lbOrgCode);
            this.Controls.Add(this.tbRemittorName);
            this.Controls.Add(this.lbRemittorName);
            this.Controls.Add(this.cmbPayFeeAccount);
            this.Controls.Add(this.cmbOtherAccount);
            this.Controls.Add(this.cmbPurchaseAccount);
            this.Controls.Add(this.cmbSpotAccount);
            this.Controls.Add(this.tbOtherAmount);
            this.Controls.Add(this.tbPurchaseAmount);
            this.Controls.Add(this.lbOtherAmount);
            this.Controls.Add(this.tbSpotAmount);
            this.Controls.Add(this.lbPurchaseAmount);
            this.Controls.Add(this.tbRemitAmount);
            this.Controls.Add(this.lbSpotAmount);
            this.Controls.Add(this.cmbRemitCashType);
            this.Controls.Add(this.lbRemitAmount);
            this.Controls.Add(this.lbRemitCashType);
            this.Controls.Add(this.rbExpress);
            this.Controls.Add(this.rbNormal);
            this.Controls.Add(this.lbSendPriority);
            this.Controls.Add(this.tbPaymentType);
            this.Controls.Add(this.lbPaymentType);
            this.Controls.Add(this.tbCustomerRef);
            this.Controls.Add(this.lbCustomerRef);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtpRemitDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAmountDescO);
            this.Controls.Add(this.lbAmountDescP);
            this.Controls.Add(this.lbAmountDescS);
            this.Controls.Add(this.lbAmountDescR);
            this.Controls.Add(this.lbRemitDate);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbSpotAccount);
            this.Controls.Add(this.lbPurchaseAccount);
            this.Controls.Add(this.lbOtherAccount);
            this.Controls.Add(this.lbPayFeeAccount);
            this.Name = "TransferGlobalRemitSelector";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRemitDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpRemitDate;
        private System.Windows.Forms.Label lbCustomerRef;
        private TextBoxCanValidate tbCustomerRef;
        private System.Windows.Forms.Label lbPaymentType;
        private TextBoxCanValidate tbPaymentType;
        private System.Windows.Forms.Label lbSendPriority;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbExpress;
        private System.Windows.Forms.Label lbRemitCashType;
        private ComboBoxCanValidate cmbRemitCashType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRemitAmount;
        private TextBoxCanValidate tbRemitAmount;
        private System.Windows.Forms.Label lbSpotAccount;
        private ComboBoxCanValidate cmbSpotAccount;
        private System.Windows.Forms.Label lbPurchaseAccount;
        private ComboBoxCanValidate cmbPurchaseAccount;
        private System.Windows.Forms.Label lbOtherAccount;
        private ComboBoxCanValidate cmbOtherAccount;
        private System.Windows.Forms.Label lbPayFeeAccount;
        private System.Windows.Forms.Label lbSpotAmount;
        private TextBoxCanValidate tbSpotAmount;
        private System.Windows.Forms.Label lbPurchaseAmount;
        private TextBoxCanValidate tbPurchaseAmount;
        private System.Windows.Forms.Label lbOtherAmount;
        private TextBoxCanValidate tbOtherAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbOrgCode;
        private TextBoxCanValidate tbOrgPre;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbRemittorName;
        private TextBoxCanValidate tbRemittorName;
        private System.Windows.Forms.Label lbRemittorAddress;
        private TextBoxCanValidate tbRemittorAddress;
        private System.Windows.Forms.Label label22;
        private TextBoxCanValidate tbOrgEnd;
        private ComboBoxCanValidate cmbPayFeeAccount;
        private System.Windows.Forms.Label lblsendtype;
        private System.Windows.Forms.Label lbAmountDescR;
        private System.Windows.Forms.Label lbAmountDescS;
        private System.Windows.Forms.Label lbAmountDescP;
        private System.Windows.Forms.Label lbAmountDescO;
        private AmbiguityInputAgent ambiguityInputAgent1;
        private AmbiguityInputAgent ambiguityInputAgent3;
        private AmbiguityInputAgent ambiguityInputAgent2;
    }
}
