using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class SpplyFinancingApplyEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpplyFinancingApplyEditor));
            this.tbContractOrOrderNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbContractOrOrderNo = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.cmbContractOrOrderCashType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbContractOrOrderCashType = new System.Windows.Forms.Label();
            this.tbOrderAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOrderAmount = new System.Windows.Forms.Label();
            this.lbDeliveryDate = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lbSettlementType = new System.Windows.Forms.Label();
            this.cmbSettlementType = new CommonClient.Controls.ComboBoxCanValidate();
            this.tbTaxInvoiceNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbTaxInvoiceNo = new System.Windows.Forms.Label();
            this.tbReceiptNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbReceiptNo = new System.Windows.Forms.Label();
            this.tbRiskTakingLetterNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbRiskTakingLetterNo = new System.Windows.Forms.Label();
            this.tbGoodsDesc = new CommonClient.Controls.TextBoxCanValidate();
            this.lbGoodsDesc = new System.Windows.Forms.Label();
            this.tbApplyAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbApplyAmount = new System.Windows.Forms.Label();
            this.tbApplyDays = new CommonClient.Controls.TextBoxCanValidate();
            this.lbApplyDays = new System.Windows.Forms.Label();
            this.tbAgrementNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAgrementNo = new System.Windows.Forms.Label();
            this.lbInterestFloatType = new System.Windows.Forms.Label();
            this.cmbInterestFloatType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbInterestFloatingPercent = new System.Windows.Forms.Label();
            this.tbInterestFloatingPercent = new CommonClient.Controls.TextBoxCanValidate();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTaxBillNo = new System.Windows.Forms.Label();
            this.lblGoodNo = new System.Windows.Forms.Label();
            this.lbAmountDescO = new System.Windows.Forms.Label();
            this.lbAmountDescA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbContractOrOrderNo
            // 
            this.tbContractOrOrderNo.DvDataField = null;
            this.tbContractOrOrderNo.DvEditorValueChanged = false;
            this.tbContractOrOrderNo.DvErrorProvider = this.errorProvider1;
            this.tbContractOrOrderNo.DvLinkedLabel = this.lbContractOrOrderNo;
            this.tbContractOrOrderNo.DvMaxLength = 0;
            this.tbContractOrOrderNo.DvMinLength = 0;
            this.tbContractOrOrderNo.DvRegCode = "";
            this.tbContractOrOrderNo.DvRequired = false;
            this.tbContractOrOrderNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbContractOrOrderNo.DvValidateEnabled = true;
            this.tbContractOrOrderNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbContractOrOrderNo, "tbContractOrOrderNo");
            this.tbContractOrOrderNo.Name = "tbContractOrOrderNo";
            // 
            // lbContractOrOrderNo
            // 
            resources.ApplyResources(this.lbContractOrOrderNo, "lbContractOrOrderNo");
            this.lbContractOrOrderNo.Name = "lbContractOrOrderNo";
            // 
            // lbOrderDate
            // 
            resources.ApplyResources(this.lbOrderDate, "lbOrderDate");
            this.lbOrderDate.Name = "lbOrderDate";
            // 
            // dtpOrderDate
            // 
            resources.ApplyResources(this.dtpOrderDate, "dtpOrderDate");
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Name = "dtpOrderDate";
            // 
            // cmbContractOrOrderCashType
            // 
            this.cmbContractOrOrderCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractOrOrderCashType.DvDataField = null;
            this.cmbContractOrOrderCashType.DvEditorValueChanged = false;
            this.cmbContractOrOrderCashType.DvErrorProvider = this.errorProvider1;
            this.cmbContractOrOrderCashType.DvLinkedLabel = this.lbContractOrOrderCashType;
            this.cmbContractOrOrderCashType.DvMaxLength = 0;
            this.cmbContractOrOrderCashType.DvMinLength = 0;
            this.cmbContractOrOrderCashType.DvRegCode = "";
            this.cmbContractOrOrderCashType.DvRequired = true;
            this.cmbContractOrOrderCashType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbContractOrOrderCashType.DvValidateEnabled = true;
            this.cmbContractOrOrderCashType.DvValidator = this.validatorList1;
            this.cmbContractOrOrderCashType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbContractOrOrderCashType, "cmbContractOrOrderCashType");
            this.cmbContractOrOrderCashType.Name = "cmbContractOrOrderCashType";
            // 
            // lbContractOrOrderCashType
            // 
            resources.ApplyResources(this.lbContractOrOrderCashType, "lbContractOrOrderCashType");
            this.lbContractOrOrderCashType.Name = "lbContractOrOrderCashType";
            // 
            // tbOrderAmount
            // 
            this.tbOrderAmount.DvDataField = null;
            this.tbOrderAmount.DvEditorValueChanged = false;
            this.tbOrderAmount.DvErrorProvider = this.errorProvider1;
            this.tbOrderAmount.DvLinkedLabel = this.lbOrderAmount;
            this.tbOrderAmount.DvMaxLength = 0;
            this.tbOrderAmount.DvMinLength = 0;
            this.tbOrderAmount.DvRegCode = "";
            this.tbOrderAmount.DvRequired = false;
            this.tbOrderAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOrderAmount.DvValidateEnabled = true;
            this.tbOrderAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOrderAmount, "tbOrderAmount");
            this.tbOrderAmount.Name = "tbOrderAmount";
            this.tbOrderAmount.TextChanged += new System.EventHandler(this.tbOrderAmount_TextChanged);
            // 
            // lbOrderAmount
            // 
            resources.ApplyResources(this.lbOrderAmount, "lbOrderAmount");
            this.lbOrderAmount.Name = "lbOrderAmount";
            // 
            // lbDeliveryDate
            // 
            resources.ApplyResources(this.lbDeliveryDate, "lbDeliveryDate");
            this.lbDeliveryDate.Name = "lbDeliveryDate";
            // 
            // dtpDeliveryDate
            // 
            resources.ApplyResources(this.dtpDeliveryDate, "dtpDeliveryDate");
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            // 
            // lbSettlementType
            // 
            resources.ApplyResources(this.lbSettlementType, "lbSettlementType");
            this.lbSettlementType.Name = "lbSettlementType";
            // 
            // cmbSettlementType
            // 
            this.cmbSettlementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSettlementType.DvDataField = null;
            this.cmbSettlementType.DvEditorValueChanged = false;
            this.cmbSettlementType.DvErrorProvider = this.errorProvider1;
            this.cmbSettlementType.DvLinkedLabel = this.lbSettlementType;
            this.cmbSettlementType.DvMaxLength = 0;
            this.cmbSettlementType.DvMinLength = 0;
            this.cmbSettlementType.DvRegCode = "";
            this.cmbSettlementType.DvRequired = true;
            this.cmbSettlementType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbSettlementType.DvValidateEnabled = true;
            this.cmbSettlementType.DvValidator = this.validatorList1;
            this.cmbSettlementType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSettlementType, "cmbSettlementType");
            this.cmbSettlementType.Name = "cmbSettlementType";
            // 
            // tbTaxInvoiceNo
            // 
            this.tbTaxInvoiceNo.DvDataField = null;
            this.tbTaxInvoiceNo.DvEditorValueChanged = false;
            this.tbTaxInvoiceNo.DvErrorProvider = this.errorProvider1;
            this.tbTaxInvoiceNo.DvLinkedLabel = this.lbTaxInvoiceNo;
            this.tbTaxInvoiceNo.DvMaxLength = 0;
            this.tbTaxInvoiceNo.DvMinLength = 0;
            this.tbTaxInvoiceNo.DvRegCode = "";
            this.tbTaxInvoiceNo.DvRequired = false;
            this.tbTaxInvoiceNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbTaxInvoiceNo.DvValidateEnabled = true;
            this.tbTaxInvoiceNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbTaxInvoiceNo, "tbTaxInvoiceNo");
            this.tbTaxInvoiceNo.Name = "tbTaxInvoiceNo";
            // 
            // lbTaxInvoiceNo
            // 
            resources.ApplyResources(this.lbTaxInvoiceNo, "lbTaxInvoiceNo");
            this.lbTaxInvoiceNo.Name = "lbTaxInvoiceNo";
            // 
            // tbReceiptNo
            // 
            this.tbReceiptNo.DvDataField = null;
            this.tbReceiptNo.DvEditorValueChanged = false;
            this.tbReceiptNo.DvErrorProvider = this.errorProvider1;
            this.tbReceiptNo.DvLinkedLabel = this.lbReceiptNo;
            this.tbReceiptNo.DvMaxLength = 0;
            this.tbReceiptNo.DvMinLength = 0;
            this.tbReceiptNo.DvRegCode = "";
            this.tbReceiptNo.DvRequired = false;
            this.tbReceiptNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbReceiptNo.DvValidateEnabled = true;
            this.tbReceiptNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbReceiptNo, "tbReceiptNo");
            this.tbReceiptNo.Name = "tbReceiptNo";
            // 
            // lbReceiptNo
            // 
            resources.ApplyResources(this.lbReceiptNo, "lbReceiptNo");
            this.lbReceiptNo.Name = "lbReceiptNo";
            // 
            // tbRiskTakingLetterNo
            // 
            this.tbRiskTakingLetterNo.DvDataField = null;
            this.tbRiskTakingLetterNo.DvEditorValueChanged = false;
            this.tbRiskTakingLetterNo.DvErrorProvider = this.errorProvider1;
            this.tbRiskTakingLetterNo.DvLinkedLabel = this.lbRiskTakingLetterNo;
            this.tbRiskTakingLetterNo.DvMaxLength = 0;
            this.tbRiskTakingLetterNo.DvMinLength = 0;
            this.tbRiskTakingLetterNo.DvRegCode = "";
            this.tbRiskTakingLetterNo.DvRequired = false;
            this.tbRiskTakingLetterNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRiskTakingLetterNo.DvValidateEnabled = true;
            this.tbRiskTakingLetterNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRiskTakingLetterNo, "tbRiskTakingLetterNo");
            this.tbRiskTakingLetterNo.Name = "tbRiskTakingLetterNo";
            // 
            // lbRiskTakingLetterNo
            // 
            resources.ApplyResources(this.lbRiskTakingLetterNo, "lbRiskTakingLetterNo");
            this.lbRiskTakingLetterNo.Name = "lbRiskTakingLetterNo";
            // 
            // tbGoodsDesc
            // 
            this.tbGoodsDesc.DvDataField = null;
            this.tbGoodsDesc.DvEditorValueChanged = false;
            this.tbGoodsDesc.DvErrorProvider = this.errorProvider1;
            this.tbGoodsDesc.DvLinkedLabel = this.lbGoodsDesc;
            this.tbGoodsDesc.DvMaxLength = 0;
            this.tbGoodsDesc.DvMinLength = 0;
            this.tbGoodsDesc.DvRegCode = "";
            this.tbGoodsDesc.DvRequired = false;
            this.tbGoodsDesc.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbGoodsDesc.DvValidateEnabled = true;
            this.tbGoodsDesc.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbGoodsDesc, "tbGoodsDesc");
            this.tbGoodsDesc.Name = "tbGoodsDesc";
            // 
            // lbGoodsDesc
            // 
            resources.ApplyResources(this.lbGoodsDesc, "lbGoodsDesc");
            this.lbGoodsDesc.Name = "lbGoodsDesc";
            // 
            // tbApplyAmount
            // 
            this.tbApplyAmount.DvDataField = null;
            this.tbApplyAmount.DvEditorValueChanged = false;
            this.tbApplyAmount.DvErrorProvider = this.errorProvider1;
            this.tbApplyAmount.DvLinkedLabel = this.lbApplyAmount;
            this.tbApplyAmount.DvMaxLength = 0;
            this.tbApplyAmount.DvMinLength = 0;
            this.tbApplyAmount.DvRegCode = "";
            this.tbApplyAmount.DvRequired = false;
            this.tbApplyAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbApplyAmount.DvValidateEnabled = true;
            this.tbApplyAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbApplyAmount, "tbApplyAmount");
            this.tbApplyAmount.Name = "tbApplyAmount";
            this.tbApplyAmount.TextChanged += new System.EventHandler(this.tbApplyAmount_TextChanged);
            // 
            // lbApplyAmount
            // 
            resources.ApplyResources(this.lbApplyAmount, "lbApplyAmount");
            this.lbApplyAmount.Name = "lbApplyAmount";
            // 
            // tbApplyDays
            // 
            this.tbApplyDays.DvDataField = null;
            this.tbApplyDays.DvEditorValueChanged = false;
            this.tbApplyDays.DvErrorProvider = this.errorProvider1;
            this.tbApplyDays.DvLinkedLabel = this.lbApplyDays;
            this.tbApplyDays.DvMaxLength = 0;
            this.tbApplyDays.DvMinLength = 0;
            this.tbApplyDays.DvRegCode = "";
            this.tbApplyDays.DvRequired = false;
            this.tbApplyDays.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbApplyDays.DvValidateEnabled = true;
            this.tbApplyDays.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbApplyDays, "tbApplyDays");
            this.tbApplyDays.Name = "tbApplyDays";
            // 
            // lbApplyDays
            // 
            resources.ApplyResources(this.lbApplyDays, "lbApplyDays");
            this.lbApplyDays.Name = "lbApplyDays";
            // 
            // tbAgrementNo
            // 
            this.tbAgrementNo.DvDataField = null;
            this.tbAgrementNo.DvEditorValueChanged = false;
            this.tbAgrementNo.DvErrorProvider = this.errorProvider1;
            this.tbAgrementNo.DvLinkedLabel = this.lbAgrementNo;
            this.tbAgrementNo.DvMaxLength = 0;
            this.tbAgrementNo.DvMinLength = 0;
            this.tbAgrementNo.DvRegCode = "";
            this.tbAgrementNo.DvRequired = false;
            this.tbAgrementNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbAgrementNo.DvValidateEnabled = true;
            this.tbAgrementNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbAgrementNo, "tbAgrementNo");
            this.tbAgrementNo.Name = "tbAgrementNo";
            // 
            // lbAgrementNo
            // 
            resources.ApplyResources(this.lbAgrementNo, "lbAgrementNo");
            this.lbAgrementNo.Name = "lbAgrementNo";
            // 
            // lbInterestFloatType
            // 
            resources.ApplyResources(this.lbInterestFloatType, "lbInterestFloatType");
            this.lbInterestFloatType.Name = "lbInterestFloatType";
            // 
            // cmbInterestFloatType
            // 
            this.cmbInterestFloatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterestFloatType.DvDataField = null;
            this.cmbInterestFloatType.DvEditorValueChanged = false;
            this.cmbInterestFloatType.DvErrorProvider = this.errorProvider1;
            this.cmbInterestFloatType.DvLinkedLabel = this.lbInterestFloatType;
            this.cmbInterestFloatType.DvMaxLength = 0;
            this.cmbInterestFloatType.DvMinLength = 0;
            this.cmbInterestFloatType.DvRegCode = "";
            this.cmbInterestFloatType.DvRequired = true;
            this.cmbInterestFloatType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbInterestFloatType.DvValidateEnabled = true;
            this.cmbInterestFloatType.DvValidator = this.validatorList1;
            this.cmbInterestFloatType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbInterestFloatType, "cmbInterestFloatType");
            this.cmbInterestFloatType.Name = "cmbInterestFloatType";
            // 
            // lbInterestFloatingPercent
            // 
            resources.ApplyResources(this.lbInterestFloatingPercent, "lbInterestFloatingPercent");
            this.lbInterestFloatingPercent.Name = "lbInterestFloatingPercent";
            // 
            // tbInterestFloatingPercent
            // 
            this.tbInterestFloatingPercent.DvDataField = null;
            this.tbInterestFloatingPercent.DvEditorValueChanged = false;
            this.tbInterestFloatingPercent.DvErrorProvider = this.errorProvider1;
            this.tbInterestFloatingPercent.DvLinkedLabel = this.lbInterestFloatingPercent;
            this.tbInterestFloatingPercent.DvMaxLength = 0;
            this.tbInterestFloatingPercent.DvMinLength = 0;
            this.tbInterestFloatingPercent.DvRegCode = "";
            this.tbInterestFloatingPercent.DvRequired = false;
            this.tbInterestFloatingPercent.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbInterestFloatingPercent.DvValidateEnabled = true;
            this.tbInterestFloatingPercent.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbInterestFloatingPercent, "tbInterestFloatingPercent");
            this.tbInterestFloatingPercent.Name = "tbInterestFloatingPercent";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Name = "label18";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Name = "label19";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Name = "label20";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Name = "label22";
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
            // lblTaxBillNo
            // 
            resources.ApplyResources(this.lblTaxBillNo, "lblTaxBillNo");
            this.lblTaxBillNo.ForeColor = System.Drawing.Color.Red;
            this.lblTaxBillNo.Name = "lblTaxBillNo";
            // 
            // lblGoodNo
            // 
            resources.ApplyResources(this.lblGoodNo, "lblGoodNo");
            this.lblGoodNo.ForeColor = System.Drawing.Color.Red;
            this.lblGoodNo.Name = "lblGoodNo";
            // 
            // lbAmountDescO
            // 
            resources.ApplyResources(this.lbAmountDescO, "lbAmountDescO");
            this.lbAmountDescO.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescO.Name = "lbAmountDescO";
            // 
            // lbAmountDescA
            // 
            resources.ApplyResources(this.lbAmountDescA, "lbAmountDescA");
            this.lbAmountDescA.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescA.Name = "lbAmountDescA";
            // 
            // SpplyFinancingApplyEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblGoodNo);
            this.Controls.Add(this.lblTaxBillNo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbInterestFloatType);
            this.Controls.Add(this.cmbSettlementType);
            this.Controls.Add(this.cmbContractOrOrderCashType);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.tbInterestFloatingPercent);
            this.Controls.Add(this.tbAgrementNo);
            this.Controls.Add(this.tbApplyDays);
            this.Controls.Add(this.tbApplyAmount);
            this.Controls.Add(this.tbGoodsDesc);
            this.Controls.Add(this.tbRiskTakingLetterNo);
            this.Controls.Add(this.tbReceiptNo);
            this.Controls.Add(this.tbTaxInvoiceNo);
            this.Controls.Add(this.tbOrderAmount);
            this.Controls.Add(this.tbContractOrOrderNo);
            this.Controls.Add(this.lbInterestFloatType);
            this.Controls.Add(this.lbDeliveryDate);
            this.Controls.Add(this.lbSettlementType);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbInterestFloatingPercent);
            this.Controls.Add(this.lbAmountDescA);
            this.Controls.Add(this.lbAmountDescO);
            this.Controls.Add(this.lbContractOrOrderCashType);
            this.Controls.Add(this.lbAgrementNo);
            this.Controls.Add(this.lbApplyDays);
            this.Controls.Add(this.lbApplyAmount);
            this.Controls.Add(this.lbGoodsDesc);
            this.Controls.Add(this.lbRiskTakingLetterNo);
            this.Controls.Add(this.lbReceiptNo);
            this.Controls.Add(this.lbTaxInvoiceNo);
            this.Controls.Add(this.lbOrderAmount);
            this.Controls.Add(this.lbContractOrOrderNo);
            this.Name = "SpplyFinancingApplyEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxCanValidate tbContractOrOrderNo;
        private System.Windows.Forms.Label lbContractOrOrderNo;
        private System.Windows.Forms.Label lbOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private ComboBoxCanValidate cmbContractOrOrderCashType;
        private System.Windows.Forms.Label lbContractOrOrderCashType;
        private TextBoxCanValidate tbOrderAmount;
        private System.Windows.Forms.Label lbOrderAmount;
        private System.Windows.Forms.Label lbDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label lbSettlementType;
        private ComboBoxCanValidate cmbSettlementType;
        private TextBoxCanValidate tbTaxInvoiceNo;
        private System.Windows.Forms.Label lbTaxInvoiceNo;
        private TextBoxCanValidate tbReceiptNo;
        private System.Windows.Forms.Label lbReceiptNo;
        private TextBoxCanValidate tbRiskTakingLetterNo;
        private System.Windows.Forms.Label lbRiskTakingLetterNo;
        private TextBoxCanValidate tbGoodsDesc;
        private System.Windows.Forms.Label lbGoodsDesc;
        private TextBoxCanValidate tbApplyAmount;
        private System.Windows.Forms.Label lbApplyAmount;
        private TextBoxCanValidate tbApplyDays;
        private System.Windows.Forms.Label lbApplyDays;
        private TextBoxCanValidate tbAgrementNo;
        private System.Windows.Forms.Label lbAgrementNo;
        private System.Windows.Forms.Label lbInterestFloatType;
        private ComboBoxCanValidate cmbInterestFloatType;
        private System.Windows.Forms.Label lbInterestFloatingPercent;
        private TextBoxCanValidate tbInterestFloatingPercent;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTaxBillNo;
        private System.Windows.Forms.Label lblGoodNo;
        private System.Windows.Forms.Label lbAmountDescO;
        private System.Windows.Forms.Label lbAmountDescA;
    }
}
