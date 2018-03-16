namespace BOC_BATCH_TOOL.VisualParts
{
    partial class UnitivePaymentOther
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitivePaymentOther));
            this.lblAccount = new System.Windows.Forms.Label();
            this.tbAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbPurpose = new System.Windows.Forms.Label();
            this.cmbPaymentType = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.tbPurpose = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbPaymentType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPayDate = new System.Windows.Forms.Label();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.lbCustomerBusinessNo = new System.Windows.Forms.Label();
            this.tbCustomerBusinessNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbOperatorOrder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOperatorOrder = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lbTipPayee = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTipPayeePhone = new System.Windows.Forms.Label();
            this.tbTipPayeePhone = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cmbTime = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccount
            // 
            resources.ApplyResources(this.lblAccount, "lblAccount");
            this.lblAccount.ForeColor = System.Drawing.Color.Red;
            this.lblAccount.Name = "lblAccount";
            // 
            // tbAmount
            // 
            this.tbAmount.EditorValueChanged = true;
            this.tbAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbAmount, "tbAmount");
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.ValidateEnabled = false;
            this.tbAmount.ValidateRule.MaxLength = 0;
            this.tbAmount.ValidateRule.MinLength = 0;
            this.tbAmount.ValidateRule.RegexValue = null;
            this.tbAmount.ValidateRule.Required = false;
            // 
            // lbAmount
            // 
            resources.ApplyResources(this.lbAmount, "lbAmount");
            this.lbAmount.Name = "lbAmount";
            // 
            // lbPurpose
            // 
            resources.ApplyResources(this.lbPurpose, "lbPurpose");
            this.lbPurpose.Name = "lbPurpose";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.EditorValueChanged = true;
            this.cmbPaymentType.ErrorProvider = null;
            this.cmbPaymentType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPaymentType, "cmbPaymentType");
            this.cmbPaymentType.MatchStrFlag = false;
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.ValidateEnabled = false;
            this.cmbPaymentType.ValidateRule.MaxLength = 0;
            this.cmbPaymentType.ValidateRule.MinLength = 0;
            this.cmbPaymentType.ValidateRule.RegexValue = null;
            this.cmbPaymentType.ValidateRule.Required = false;
            // 
            // tbPurpose
            // 
            this.tbPurpose.EditorValueChanged = true;
            this.tbPurpose.ErrorProvider = null;
            resources.ApplyResources(this.tbPurpose, "tbPurpose");
            this.tbPurpose.Name = "tbPurpose";
            this.tbPurpose.ValidateEnabled = false;
            this.tbPurpose.ValidateRule.MaxLength = 0;
            this.tbPurpose.ValidateRule.MinLength = 0;
            this.tbPurpose.ValidateRule.RegexValue = null;
            this.tbPurpose.ValidateRule.Required = false;
            // 
            // lbPaymentType
            // 
            resources.ApplyResources(this.lbPaymentType, "lbPaymentType");
            this.lbPaymentType.Name = "lbPaymentType";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // lbPayDate
            // 
            resources.ApplyResources(this.lbPayDate, "lbPayDate");
            this.lbPayDate.Name = "lbPayDate";
            // 
            // dtpPayDate
            // 
            resources.ApplyResources(this.dtpPayDate, "dtpPayDate");
            this.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.ValueChanged += new System.EventHandler(this.dtpPayDate_ValueChanged);
            // 
            // lbCustomerBusinessNo
            // 
            resources.ApplyResources(this.lbCustomerBusinessNo, "lbCustomerBusinessNo");
            this.lbCustomerBusinessNo.Name = "lbCustomerBusinessNo";
            // 
            // tbCustomerBusinessNo
            // 
            this.tbCustomerBusinessNo.EditorValueChanged = true;
            this.tbCustomerBusinessNo.ErrorProvider = null;
            resources.ApplyResources(this.tbCustomerBusinessNo, "tbCustomerBusinessNo");
            this.tbCustomerBusinessNo.Name = "tbCustomerBusinessNo";
            this.tbCustomerBusinessNo.ValidateEnabled = false;
            this.tbCustomerBusinessNo.ValidateRule.MaxLength = 0;
            this.tbCustomerBusinessNo.ValidateRule.MinLength = 0;
            this.tbCustomerBusinessNo.ValidateRule.RegexValue = null;
            this.tbCustomerBusinessNo.ValidateRule.Required = false;
            // 
            // lbOperatorOrder
            // 
            resources.ApplyResources(this.lbOperatorOrder, "lbOperatorOrder");
            this.lbOperatorOrder.Name = "lbOperatorOrder";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // cmbOperatorOrder
            // 
            this.cmbOperatorOrder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOperatorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperatorOrder.EditorValueChanged = true;
            this.cmbOperatorOrder.ErrorProvider = null;
            this.cmbOperatorOrder.FormattingEnabled = true;
            resources.ApplyResources(this.cmbOperatorOrder, "cmbOperatorOrder");
            this.cmbOperatorOrder.MatchStrFlag = false;
            this.cmbOperatorOrder.Name = "cmbOperatorOrder";
            this.cmbOperatorOrder.ValidateEnabled = false;
            this.cmbOperatorOrder.ValidateRule.MaxLength = 0;
            this.cmbOperatorOrder.ValidateRule.MinLength = 0;
            this.cmbOperatorOrder.ValidateRule.RegexValue = null;
            this.cmbOperatorOrder.ValidateRule.Required = false;
            // 
            // lbTipPayee
            // 
            resources.ApplyResources(this.lbTipPayee, "lbTipPayee");
            this.lbTipPayee.Name = "lbTipPayee";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // lbTipPayeePhone
            // 
            resources.ApplyResources(this.lbTipPayeePhone, "lbTipPayeePhone");
            this.lbTipPayeePhone.Name = "lbTipPayeePhone";
            // 
            // tbTipPayeePhone
            // 
            this.tbTipPayeePhone.EditorValueChanged = true;
            this.tbTipPayeePhone.ErrorProvider = null;
            resources.ApplyResources(this.tbTipPayeePhone, "tbTipPayeePhone");
            this.tbTipPayeePhone.Name = "tbTipPayeePhone";
            this.tbTipPayeePhone.ValidateEnabled = false;
            this.tbTipPayeePhone.ValidateRule.MaxLength = 0;
            this.tbTipPayeePhone.ValidateRule.MinLength = 0;
            this.tbTipPayeePhone.ValidateRule.RegexValue = null;
            this.tbTipPayeePhone.ValidateRule.Required = false;
            // 
            // rbYes
            // 
            resources.ApplyResources(this.rbYes, "rbYes");
            this.rbYes.Name = "rbYes";
            this.rbYes.UseVisualStyleBackColor = true;
            this.rbYes.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
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
            // lblPhone
            // 
            resources.ApplyResources(this.lblPhone, "lblPhone");
            this.lblPhone.ForeColor = System.Drawing.Color.Red;
            this.lblPhone.Name = "lblPhone";
            // 
            // cmbTime
            // 
            this.cmbTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.EditorValueChanged = true;
            resources.ApplyResources(this.cmbTime, "cmbTime");
            this.cmbTime.ErrorProvider = null;
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.MatchStrFlag = false;
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.ValidateEnabled = false;
            this.cmbTime.ValidateRule.MaxLength = 0;
            this.cmbTime.ValidateRule.MinLength = 0;
            this.cmbTime.ValidateRule.RegexValue = null;
            this.cmbTime.ValidateRule.Required = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // UnitivePaymentOther
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbOperatorOrder);
            this.Controls.Add(this.rbNo);
            this.Controls.Add(this.rbYes);
            this.Controls.Add(this.dtpPayDate);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.cmbOperatorOrder);
            this.Controls.Add(this.cmbPaymentType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.tbCustomerBusinessNo);
            this.Controls.Add(this.tbPurpose);
            this.Controls.Add(this.tbTipPayeePhone);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.lbPayDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCustomerBusinessNo);
            this.Controls.Add(this.lbTipPayeePhone);
            this.Controls.Add(this.lbPaymentType);
            this.Controls.Add(this.lbTipPayee);
            this.Controls.Add(this.lbPurpose);
            this.Controls.Add(this.lbAmount);
            this.Name = "UnitivePaymentOther";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccount;
        private Controls.TextBoxCanValidate tbAmount;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbPurpose;
        private Controls.ComboBoxCanValidate cmbPaymentType;
        private Controls.TextBoxCanValidate tbPurpose;
        private System.Windows.Forms.Label lbPaymentType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPayDate;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.Label lbCustomerBusinessNo;
        private Controls.TextBoxCanValidate tbCustomerBusinessNo;
        private System.Windows.Forms.Label lbOperatorOrder;
        private System.Windows.Forms.Label label7;
        private Controls.ComboBoxCanValidate cmbOperatorOrder;
        private System.Windows.Forms.Label lbTipPayee;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTipPayeePhone;
        private Controls.TextBoxCanValidate tbTipPayeePhone;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Label lblPhone;
        private Controls.ComboBoxCanValidate cmbTime;
        private System.Windows.Forms.Label label1;
    }
}
