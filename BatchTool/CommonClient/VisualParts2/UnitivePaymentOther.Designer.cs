using CommonClient.Controls;

namespace CommonClient.VisualParts2
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
            this.tbAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbPurpose = new System.Windows.Forms.Label();
            this.cmbPaymentType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbPaymentType = new System.Windows.Forms.Label();
            this.tbPurpose = new CommonClient.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPayDate = new System.Windows.Forms.Label();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.lbCustomerBusinessNo = new System.Windows.Forms.Label();
            this.tbCustomerBusinessNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOperatorOrder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOperatorOrder = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbTipPayee = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTipPayeePhone = new System.Windows.Forms.Label();
            this.tbTipPayeePhone = new CommonClient.Controls.TextBoxCanValidate();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cmbTime = new CommonClient.Controls.ComboBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAmountDesc = new System.Windows.Forms.Label();
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
            this.tbAmount.DvDataField = null;
            this.tbAmount.DvEditorValueChanged = true;
            this.tbAmount.DvErrorProvider = this.errorProvider1;
            this.tbAmount.DvLinkedLabel = this.lbAmount;
            this.tbAmount.DvMaxLength = 0;
            this.tbAmount.DvMinLength = 0;
            this.tbAmount.DvRegCode = null;
            this.tbAmount.DvRequired = false;
            this.tbAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbAmount.DvValidateEnabled = true;
            this.tbAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbAmount, "tbAmount");
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
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
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.DvDataField = null;
            this.cmbPaymentType.DvEditorValueChanged = true;
            this.cmbPaymentType.DvErrorProvider = this.errorProvider1;
            this.cmbPaymentType.DvLinkedLabel = this.lbPaymentType;
            this.cmbPaymentType.DvMaxLength = 0;
            this.cmbPaymentType.DvMinLength = 0;
            this.cmbPaymentType.DvRegCode = null;
            this.cmbPaymentType.DvRequired = true;
            this.cmbPaymentType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPaymentType.DvValidateEnabled = true;
            this.cmbPaymentType.DvValidator = this.validatorList1;
            this.cmbPaymentType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPaymentType, "cmbPaymentType");
            this.cmbPaymentType.Name = "cmbPaymentType";
            // 
            // lbPaymentType
            // 
            resources.ApplyResources(this.lbPaymentType, "lbPaymentType");
            this.lbPaymentType.Name = "lbPaymentType";
            // 
            // tbPurpose
            // 
            this.tbPurpose.DvDataField = null;
            this.tbPurpose.DvEditorValueChanged = true;
            this.tbPurpose.DvErrorProvider = this.errorProvider1;
            this.tbPurpose.DvLinkedLabel = this.lbPurpose;
            this.tbPurpose.DvMaxLength = 0;
            this.tbPurpose.DvMinLength = 0;
            this.tbPurpose.DvRegCode = null;
            this.tbPurpose.DvRequired = false;
            this.tbPurpose.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPurpose.DvValidateEnabled = true;
            this.tbPurpose.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPurpose, "tbPurpose");
            this.tbPurpose.Name = "tbPurpose";
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
            this.tbCustomerBusinessNo.DvDataField = null;
            this.tbCustomerBusinessNo.DvEditorValueChanged = true;
            this.tbCustomerBusinessNo.DvErrorProvider = this.errorProvider1;
            this.tbCustomerBusinessNo.DvLinkedLabel = this.lbCustomerBusinessNo;
            this.tbCustomerBusinessNo.DvMaxLength = 0;
            this.tbCustomerBusinessNo.DvMinLength = 0;
            this.tbCustomerBusinessNo.DvRegCode = null;
            this.tbCustomerBusinessNo.DvRequired = false;
            this.tbCustomerBusinessNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCustomerBusinessNo.DvValidateEnabled = true;
            this.tbCustomerBusinessNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCustomerBusinessNo, "tbCustomerBusinessNo");
            this.tbCustomerBusinessNo.Name = "tbCustomerBusinessNo";
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
            this.cmbOperatorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperatorOrder.DvDataField = null;
            this.cmbOperatorOrder.DvEditorValueChanged = true;
            this.cmbOperatorOrder.DvErrorProvider = this.errorProvider1;
            this.cmbOperatorOrder.DvLinkedLabel = this.lbOperatorOrder;
            this.cmbOperatorOrder.DvMaxLength = 0;
            this.cmbOperatorOrder.DvMinLength = 0;
            this.cmbOperatorOrder.DvRegCode = null;
            this.cmbOperatorOrder.DvRequired = true;
            this.cmbOperatorOrder.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbOperatorOrder.DvValidateEnabled = true;
            this.cmbOperatorOrder.DvValidator = this.validatorList1;
            this.cmbOperatorOrder.FormattingEnabled = true;
            resources.ApplyResources(this.cmbOperatorOrder, "cmbOperatorOrder");
            this.cmbOperatorOrder.Name = "cmbOperatorOrder";
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
            this.tbTipPayeePhone.DvDataField = null;
            this.tbTipPayeePhone.DvEditorValueChanged = true;
            this.tbTipPayeePhone.DvErrorProvider = this.errorProvider1;
            this.tbTipPayeePhone.DvLinkedLabel = this.lbTipPayeePhone;
            this.tbTipPayeePhone.DvMaxLength = 0;
            this.tbTipPayeePhone.DvMinLength = 0;
            this.tbTipPayeePhone.DvRegCode = null;
            this.tbTipPayeePhone.DvRequired = false;
            this.tbTipPayeePhone.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbTipPayeePhone.DvValidateEnabled = true;
            this.tbTipPayeePhone.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbTipPayeePhone, "tbTipPayeePhone");
            this.tbTipPayeePhone.Name = "tbTipPayeePhone";
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
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.DvDataField = null;
            this.cmbTime.DvEditorValueChanged = true;
            this.cmbTime.DvErrorProvider = this.errorProvider1;
            this.cmbTime.DvLinkedLabel = null;
            this.cmbTime.DvMaxLength = 0;
            this.cmbTime.DvMinLength = 0;
            this.cmbTime.DvRegCode = null;
            this.cmbTime.DvRequired = false;
            this.cmbTime.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbTime.DvValidateEnabled = true;
            this.cmbTime.DvValidator = this.validatorList1;
            resources.ApplyResources(this.cmbTime, "cmbTime");
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Name = "cmbTime";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbAmountDesc
            // 
            resources.ApplyResources(this.lbAmountDesc, "lbAmountDesc");
            this.lbAmountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDesc.Name = "lbAmountDesc";
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
            this.Controls.Add(this.lbAmountDesc);
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
        private System.Windows.Forms.Label lbAmountDesc;
    }
}
