namespace BOC_BATCH_TOOL.VisualParts
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
            this.tbCustomerRef = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbPaymentType = new System.Windows.Forms.Label();
            this.tbPaymentType = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbSendPriority = new System.Windows.Forms.Label();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbExpress = new System.Windows.Forms.RadioButton();
            this.lbRemitCashType = new System.Windows.Forms.Label();
            this.cmbRemitCashType = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRemitAmount = new System.Windows.Forms.Label();
            this.tbRemitAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbSpotAccount = new System.Windows.Forms.Label();
            this.cmbSpotAccount = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lbPurchaseAccount = new System.Windows.Forms.Label();
            this.cmbPurchaseAccount = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lbOtherAccount = new System.Windows.Forms.Label();
            this.cmbOtherAccount = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lbPayFeeAccount = new System.Windows.Forms.Label();
            this.lbSpotAmount = new System.Windows.Forms.Label();
            this.tbSpotAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbPurchaseAmount = new System.Windows.Forms.Label();
            this.tbPurchaseAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbOtherAmount = new System.Windows.Forms.Label();
            this.tbOtherAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label17 = new System.Windows.Forms.Label();
            this.lbOrgCode = new System.Windows.Forms.Label();
            this.tbOrgPre = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label19 = new System.Windows.Forms.Label();
            this.lbRemittorName = new System.Windows.Forms.Label();
            this.tbRemittorName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbRemittorAddress = new System.Windows.Forms.Label();
            this.tbRemittorAddress = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label22 = new System.Windows.Forms.Label();
            this.tbOrgEnd = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.cmbPayFeeAccount = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lblsendtype = new System.Windows.Forms.Label();
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
            this.tbCustomerRef.EditorValueChanged = false;
            this.tbCustomerRef.ErrorProvider = null;
            resources.ApplyResources(this.tbCustomerRef, "tbCustomerRef");
            this.tbCustomerRef.Name = "tbCustomerRef";
            this.tbCustomerRef.ValidateEnabled = false;
            this.tbCustomerRef.ValidateRule.MaxLength = 0;
            this.tbCustomerRef.ValidateRule.MinLength = 0;
            this.tbCustomerRef.ValidateRule.RegexValue = null;
            this.tbCustomerRef.ValidateRule.Required = false;
            // 
            // lbPaymentType
            // 
            resources.ApplyResources(this.lbPaymentType, "lbPaymentType");
            this.lbPaymentType.Name = "lbPaymentType";
            // 
            // tbPaymentType
            // 
            this.tbPaymentType.EditorValueChanged = true;
            this.tbPaymentType.ErrorProvider = null;
            resources.ApplyResources(this.tbPaymentType, "tbPaymentType");
            this.tbPaymentType.Name = "tbPaymentType";
            this.tbPaymentType.ReadOnly = true;
            this.tbPaymentType.ValidateEnabled = false;
            this.tbPaymentType.ValidateRule.MaxLength = 0;
            this.tbPaymentType.ValidateRule.MinLength = 0;
            this.tbPaymentType.ValidateRule.RegexValue = null;
            this.tbPaymentType.ValidateRule.Required = false;
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
            this.cmbRemitCashType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRemitCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemitCashType.EditorValueChanged = false;
            this.cmbRemitCashType.ErrorProvider = null;
            this.cmbRemitCashType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbRemitCashType, "cmbRemitCashType");
            this.cmbRemitCashType.MatchStrFlag = false;
            this.cmbRemitCashType.Name = "cmbRemitCashType";
            this.cmbRemitCashType.ValidateEnabled = true;
            this.cmbRemitCashType.ValidateRule.MaxLength = 0;
            this.cmbRemitCashType.ValidateRule.MinLength = 0;
            this.cmbRemitCashType.ValidateRule.RegexValue = null;
            this.cmbRemitCashType.ValidateRule.Required = true;
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
            this.tbRemitAmount.EditorValueChanged = false;
            this.tbRemitAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbRemitAmount, "tbRemitAmount");
            this.tbRemitAmount.Name = "tbRemitAmount";
            this.tbRemitAmount.ValidateEnabled = true;
            this.tbRemitAmount.ValidateRule.MaxLength = 0;
            this.tbRemitAmount.ValidateRule.MinLength = 0;
            this.tbRemitAmount.ValidateRule.RegexValue = null;
            this.tbRemitAmount.ValidateRule.Required = true;
            // 
            // lbSpotAccount
            // 
            resources.ApplyResources(this.lbSpotAccount, "lbSpotAccount");
            this.lbSpotAccount.Name = "lbSpotAccount";
            // 
            // cmbSpotAccount
            // 
            this.cmbSpotAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSpotAccount.EditorValueChanged = false;
            this.cmbSpotAccount.ErrorProvider = null;
            this.cmbSpotAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSpotAccount, "cmbSpotAccount");
            this.cmbSpotAccount.MatchStrFlag = false;
            this.cmbSpotAccount.Name = "cmbSpotAccount";
            this.cmbSpotAccount.ValidateEnabled = true;
            this.cmbSpotAccount.ValidateRule.MaxLength = 0;
            this.cmbSpotAccount.ValidateRule.MinLength = 0;
            this.cmbSpotAccount.ValidateRule.RegexValue = null;
            this.cmbSpotAccount.ValidateRule.Required = false;
            // 
            // lbPurchaseAccount
            // 
            resources.ApplyResources(this.lbPurchaseAccount, "lbPurchaseAccount");
            this.lbPurchaseAccount.Name = "lbPurchaseAccount";
            // 
            // cmbPurchaseAccount
            // 
            this.cmbPurchaseAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPurchaseAccount.EditorValueChanged = false;
            this.cmbPurchaseAccount.ErrorProvider = null;
            this.cmbPurchaseAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPurchaseAccount, "cmbPurchaseAccount");
            this.cmbPurchaseAccount.MatchStrFlag = false;
            this.cmbPurchaseAccount.Name = "cmbPurchaseAccount";
            this.cmbPurchaseAccount.ValidateEnabled = false;
            this.cmbPurchaseAccount.ValidateRule.MaxLength = 0;
            this.cmbPurchaseAccount.ValidateRule.MinLength = 0;
            this.cmbPurchaseAccount.ValidateRule.RegexValue = null;
            this.cmbPurchaseAccount.ValidateRule.Required = false;
            // 
            // lbOtherAccount
            // 
            resources.ApplyResources(this.lbOtherAccount, "lbOtherAccount");
            this.lbOtherAccount.Name = "lbOtherAccount";
            // 
            // cmbOtherAccount
            // 
            this.cmbOtherAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOtherAccount.EditorValueChanged = false;
            this.cmbOtherAccount.ErrorProvider = null;
            this.cmbOtherAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbOtherAccount, "cmbOtherAccount");
            this.cmbOtherAccount.MatchStrFlag = false;
            this.cmbOtherAccount.Name = "cmbOtherAccount";
            this.cmbOtherAccount.ValidateEnabled = false;
            this.cmbOtherAccount.ValidateRule.MaxLength = 0;
            this.cmbOtherAccount.ValidateRule.MinLength = 0;
            this.cmbOtherAccount.ValidateRule.RegexValue = null;
            this.cmbOtherAccount.ValidateRule.Required = false;
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
            this.tbSpotAmount.EditorValueChanged = false;
            this.tbSpotAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbSpotAmount, "tbSpotAmount");
            this.tbSpotAmount.Name = "tbSpotAmount";
            this.tbSpotAmount.ValidateEnabled = false;
            this.tbSpotAmount.ValidateRule.MaxLength = 0;
            this.tbSpotAmount.ValidateRule.MinLength = 0;
            this.tbSpotAmount.ValidateRule.RegexValue = null;
            this.tbSpotAmount.ValidateRule.Required = false;
            // 
            // lbPurchaseAmount
            // 
            resources.ApplyResources(this.lbPurchaseAmount, "lbPurchaseAmount");
            this.lbPurchaseAmount.Name = "lbPurchaseAmount";
            // 
            // tbPurchaseAmount
            // 
            this.tbPurchaseAmount.EditorValueChanged = false;
            this.tbPurchaseAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbPurchaseAmount, "tbPurchaseAmount");
            this.tbPurchaseAmount.Name = "tbPurchaseAmount";
            this.tbPurchaseAmount.ValidateEnabled = false;
            this.tbPurchaseAmount.ValidateRule.MaxLength = 0;
            this.tbPurchaseAmount.ValidateRule.MinLength = 0;
            this.tbPurchaseAmount.ValidateRule.RegexValue = null;
            this.tbPurchaseAmount.ValidateRule.Required = false;
            // 
            // lbOtherAmount
            // 
            resources.ApplyResources(this.lbOtherAmount, "lbOtherAmount");
            this.lbOtherAmount.Name = "lbOtherAmount";
            // 
            // tbOtherAmount
            // 
            this.tbOtherAmount.EditorValueChanged = false;
            this.tbOtherAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbOtherAmount, "tbOtherAmount");
            this.tbOtherAmount.Name = "tbOtherAmount";
            this.tbOtherAmount.ValidateEnabled = false;
            this.tbOtherAmount.ValidateRule.MaxLength = 0;
            this.tbOtherAmount.ValidateRule.MinLength = 0;
            this.tbOtherAmount.ValidateRule.RegexValue = null;
            this.tbOtherAmount.ValidateRule.Required = false;
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
            this.tbOrgPre.EditorValueChanged = false;
            this.tbOrgPre.ErrorProvider = null;
            resources.ApplyResources(this.tbOrgPre, "tbOrgPre");
            this.tbOrgPre.Name = "tbOrgPre";
            this.tbOrgPre.ValidateEnabled = true;
            this.tbOrgPre.ValidateRule.MaxLength = 0;
            this.tbOrgPre.ValidateRule.MinLength = 0;
            this.tbOrgPre.ValidateRule.RegexValue = null;
            this.tbOrgPre.ValidateRule.Required = true;
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
            this.tbRemittorName.EditorValueChanged = false;
            this.tbRemittorName.ErrorProvider = null;
            resources.ApplyResources(this.tbRemittorName, "tbRemittorName");
            this.tbRemittorName.Name = "tbRemittorName";
            this.tbRemittorName.ValidateEnabled = true;
            this.tbRemittorName.ValidateRule.MaxLength = 0;
            this.tbRemittorName.ValidateRule.MinLength = 0;
            this.tbRemittorName.ValidateRule.RegexValue = null;
            this.tbRemittorName.ValidateRule.Required = true;
            // 
            // lbRemittorAddress
            // 
            resources.ApplyResources(this.lbRemittorAddress, "lbRemittorAddress");
            this.lbRemittorAddress.Name = "lbRemittorAddress";
            // 
            // tbRemittorAddress
            // 
            this.tbRemittorAddress.EditorValueChanged = false;
            this.tbRemittorAddress.ErrorProvider = null;
            resources.ApplyResources(this.tbRemittorAddress, "tbRemittorAddress");
            this.tbRemittorAddress.Name = "tbRemittorAddress";
            this.tbRemittorAddress.ValidateEnabled = false;
            this.tbRemittorAddress.ValidateRule.MaxLength = 0;
            this.tbRemittorAddress.ValidateRule.MinLength = 0;
            this.tbRemittorAddress.ValidateRule.RegexValue = null;
            this.tbRemittorAddress.ValidateRule.Required = false;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label22.Name = "label22";
            // 
            // tbOrgEnd
            // 
            this.tbOrgEnd.EditorValueChanged = false;
            this.tbOrgEnd.ErrorProvider = null;
            resources.ApplyResources(this.tbOrgEnd, "tbOrgEnd");
            this.tbOrgEnd.Name = "tbOrgEnd";
            this.tbOrgEnd.ValidateEnabled = true;
            this.tbOrgEnd.ValidateRule.MaxLength = 0;
            this.tbOrgEnd.ValidateRule.MinLength = 0;
            this.tbOrgEnd.ValidateRule.RegexValue = null;
            this.tbOrgEnd.ValidateRule.Required = true;
            // 
            // cmbPayFeeAccount
            // 
            this.cmbPayFeeAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPayFeeAccount.EditorValueChanged = false;
            this.cmbPayFeeAccount.ErrorProvider = null;
            this.cmbPayFeeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayFeeAccount, "cmbPayFeeAccount");
            this.cmbPayFeeAccount.MatchStrFlag = false;
            this.cmbPayFeeAccount.Name = "cmbPayFeeAccount";
            this.cmbPayFeeAccount.ValidateEnabled = false;
            this.cmbPayFeeAccount.ValidateRule.MaxLength = 0;
            this.cmbPayFeeAccount.ValidateRule.MinLength = 0;
            this.cmbPayFeeAccount.ValidateRule.RegexValue = null;
            this.cmbPayFeeAccount.ValidateRule.Required = false;
            // 
            // lblsendtype
            // 
            resources.ApplyResources(this.lblsendtype, "lblsendtype");
            this.lblsendtype.ForeColor = System.Drawing.Color.Red;
            this.lblsendtype.Name = "lblsendtype";
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
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbCustomerRef;
        private System.Windows.Forms.Label lbPaymentType;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbPaymentType;
        private System.Windows.Forms.Label lbSendPriority;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbExpress;
        private System.Windows.Forms.Label lbRemitCashType;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbRemitCashType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRemitAmount;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbRemitAmount;
        private System.Windows.Forms.Label lbSpotAccount;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbSpotAccount;
        private System.Windows.Forms.Label lbPurchaseAccount;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbPurchaseAccount;
        private System.Windows.Forms.Label lbOtherAccount;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbOtherAccount;
        private System.Windows.Forms.Label lbPayFeeAccount;
        private System.Windows.Forms.Label lbSpotAmount;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbSpotAmount;
        private System.Windows.Forms.Label lbPurchaseAmount;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbPurchaseAmount;
        private System.Windows.Forms.Label lbOtherAmount;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbOtherAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbOrgCode;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbOrgPre;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbRemittorName;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbRemittorName;
        private System.Windows.Forms.Label lbRemittorAddress;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbRemittorAddress;
        private System.Windows.Forms.Label label22;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbOrgEnd;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbPayFeeAccount;
        private System.Windows.Forms.Label lblsendtype;
    }
}
