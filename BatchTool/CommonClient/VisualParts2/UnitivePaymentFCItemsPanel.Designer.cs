using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class UnitivePaymentFCItemsPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnQuery = new CommonClient.Controls.ThemedButton();
            this.tbQueryContent = new CommonClient.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblItemsDesc = new System.Windows.Forms.Label();
            this.clnRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayerAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNominalPayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNominalPayerAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCashType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSendPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayFeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnrealPayAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNominalPayerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOrgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeOpenBankType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeOpenBankAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFSwiftCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCorrespendentBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCSwiftCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCorrespendentBankAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAccountInCorrespondentBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeCodeofCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAccountBankType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPaymentCountryOrArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDealSerialNoF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDealSerialNoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIPPSMoneyTypeAmount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIPPSMoneyTypeAmount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDealNoteF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDealNoteS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIsPayOffLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBillSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBatchNoOrTNoOrSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProposerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPaymentPropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIsNoSavePay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAssumeFeePayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgv = new CommonClient.Controls.ThemedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnQuery);
            this.pnlHeader.Controls.Add(this.tbQueryContent);
            this.pnlHeader.Controls.Add(this.lblTransferDetailHeader_P);
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Controls.Add(this.lblItemsDesc);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 36);
            this.pnlHeader.TabIndex = 9;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Image = null;
            this.btnQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuery.Location = new System.Drawing.Point(735, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(45, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查找";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // tbQueryContent
            // 
            this.tbQueryContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQueryContent.DvDataField = null;
            this.tbQueryContent.DvEditorValueChanged = false;
            this.tbQueryContent.DvErrorProvider = this.errorProvider1;
            this.tbQueryContent.DvLinkedLabel = null;
            this.tbQueryContent.DvMaxLength = 0;
            this.tbQueryContent.DvMinLength = 0;
            this.tbQueryContent.DvRegCode = null;
            this.tbQueryContent.DvRequired = false;
            this.tbQueryContent.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbQueryContent.DvValidateEnabled = true;
            this.tbQueryContent.DvValidator = null;
            this.tbQueryContent.Location = new System.Drawing.Point(612, 8);
            this.tbQueryContent.Name = "tbQueryContent";
            this.tbQueryContent.Size = new System.Drawing.Size(117, 21);
            this.tbQueryContent.TabIndex = 7;
            // 
            // lblTransferDetailHeader_P
            // 
            this.lblTransferDetailHeader_P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransferDetailHeader_P.AutoSize = true;
            this.lblTransferDetailHeader_P.Font = new System.Drawing.Font("SimSun-ExtB", 9F, System.Drawing.FontStyle.Bold);
            this.lblTransferDetailHeader_P.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTransferDetailHeader_P.Location = new System.Drawing.Point(535, 12);
            this.lblTransferDetailHeader_P.Name = "lblTransferDetailHeader_P";
            this.lblTransferDetailHeader_P.Size = new System.Drawing.Size(70, 12);
            this.lblTransferDetailHeader_P.TabIndex = 6;
            this.lblTransferDetailHeader_P.Text = "快速定位：";
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.AutoSize = true;
            this.lblHeaderInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeaderInfo.Location = new System.Drawing.Point(80, 12);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(149, 12);
            this.lblHeaderInfo.TabIndex = 1;
            this.lblHeaderInfo.Text = "总笔数 0 笔；总金额 0 元";
            // 
            // lblItemsDesc
            // 
            this.lblItemsDesc.AutoSize = true;
            this.lblItemsDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblItemsDesc.Location = new System.Drawing.Point(3, 12);
            this.lblItemsDesc.Name = "lblItemsDesc";
            this.lblItemsDesc.Size = new System.Drawing.Size(77, 12);
            this.lblItemsDesc.TabIndex = 0;
            this.lblItemsDesc.Text = "批量文件清单";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeight = 35;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnRowNo,
            this.clnError,
            this.clnPayerAccount,
            this.clnPayerName,
            this.clnNominalPayerName,
            this.clnNominalPayerAccount,
            this.clnCashType,
            this.clnPayDate,
            this.clnSendPriority,
            this.clnPayFeeType,
            this.clnRemitAmount,
            this.clnrealPayAddress,
            this.clnNominalPayerAddress,
            this.clnCustomerRef,
            this.clnOrgCode,
            this.clnRemitNote,
            this.clnPayeeAccount,
            this.clnPayeeName,
            this.clnPayeeAddress,
            this.clnPayeeOpenBankType,
            this.clnPayeeOpenBankAddress,
            this.clnFSwiftCode,
            this.clnCorrespendentBankName,
            this.clnCSwiftCode,
            this.clnCorrespendentBankAddress,
            this.clnPayeeAccountInCorrespondentBank,
            this.clnPayeeCodeofCountry,
            this.clnAccountBankType,
            this.clnPaymentCountryOrArea,
            this.clnDealSerialNoF,
            this.clnDealSerialNoS,
            this.clnIPPSMoneyTypeAmount1,
            this.clnIPPSMoneyTypeAmount2,
            this.clnDealNoteF,
            this.clnDealNoteS,
            this.clnIsPayOffLine,
            this.clnContactNo,
            this.clnBillSerialNo,
            this.clnBatchNoOrTNoOrSerialNo,
            this.clnProposerName,
            this.clnTelephone,
            this.clnPaymentPropertyType,
            this.clnIsNoSavePay,
            this.clnAssumeFeePayType,
            this.clnPurpose});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle5;
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Location = new System.Drawing.Point(0, 36);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 4;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new System.Drawing.Size(800, 424);
            dgv.TabIndex = 10;
            // 
            // clnRowNo
            // 
            this.clnRowNo.DataPropertyName = "RowIndex";
            this.clnRowNo.HeaderText = "序号";
            this.clnRowNo.Name = "clnRowNo";
            this.clnRowNo.ReadOnly = true;
            this.clnRowNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnRowNo.Width = 64;
            // 
            // clnError
            // 
            this.clnError.DataPropertyName = "ErrorReason";
            this.clnError.HeaderText = "错误原因";
            this.clnError.Name = "clnError";
            this.clnError.ReadOnly = true;
            this.clnError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnError.Visible = false;
            this.clnError.Width = 88;
            // 
            // clnPayerAccount
            // 
            this.clnPayerAccount.DataPropertyName = "PayerAccount";
            this.clnPayerAccount.HeaderText = "实际付款人账号";
            this.clnPayerAccount.Name = "clnPayerAccount";
            this.clnPayerAccount.ReadOnly = true;
            this.clnPayerAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayerAccount.Width = 124;
            // 
            // clnPayerName
            // 
            this.clnPayerName.DataPropertyName = "PayerName";
            this.clnPayerName.HeaderText = "实际付款人名称";
            this.clnPayerName.Name = "clnPayerName";
            this.clnPayerName.ReadOnly = true;
            this.clnPayerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayerName.Width = 124;
            // 
            // clnNominalPayerName
            // 
            this.clnNominalPayerName.DataPropertyName = "NominalPayerName";
            this.clnNominalPayerName.HeaderText = "名义付款人名称";
            this.clnNominalPayerName.Name = "clnNominalPayerName";
            this.clnNominalPayerName.ReadOnly = true;
            this.clnNominalPayerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnNominalPayerName.Width = 124;
            // 
            // clnNominalPayerAccount
            // 
            this.clnNominalPayerAccount.DataPropertyName = "NominalPayerAccount";
            this.clnNominalPayerAccount.HeaderText = "名义付款人账号";
            this.clnNominalPayerAccount.Name = "clnNominalPayerAccount";
            this.clnNominalPayerAccount.ReadOnly = true;
            this.clnNominalPayerAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnNominalPayerAccount.Width = 124;
            // 
            // clnCashType
            // 
            this.clnCashType.DataPropertyName = "CashTypeString";
            this.clnCashType.HeaderText = "货币类型";
            this.clnCashType.Name = "clnCashType";
            this.clnCashType.ReadOnly = true;
            this.clnCashType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnCashType.Width = 88;
            // 
            // clnPayDate
            // 
            this.clnPayDate.DataPropertyName = "OrderPayDate";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.clnPayDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnPayDate.HeaderText = "指定付款日期";
            this.clnPayDate.Name = "clnPayDate";
            this.clnPayDate.ReadOnly = true;
            this.clnPayDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayDate.Width = 112;
            // 
            // clnSendPriority
            // 
            this.clnSendPriority.DataPropertyName = "SendPriorityString";
            this.clnSendPriority.HeaderText = "发电等级";
            this.clnSendPriority.Name = "clnSendPriority";
            this.clnSendPriority.ReadOnly = true;
            this.clnSendPriority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnSendPriority.Width = 88;
            // 
            // clnPayFeeType
            // 
            this.clnPayFeeType.DataPropertyName = "UnitivePaymentTypeString";
            this.clnPayFeeType.HeaderText = "付款方式";
            this.clnPayFeeType.Name = "clnPayFeeType";
            this.clnPayFeeType.ReadOnly = true;
            this.clnPayFeeType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayFeeType.Width = 88;
            // 
            // clnRemitAmount
            // 
            this.clnRemitAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.clnRemitAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.clnRemitAmount.HeaderText = "汇款金额";
            this.clnRemitAmount.Name = "clnRemitAmount";
            this.clnRemitAmount.ReadOnly = true;
            this.clnRemitAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnRemitAmount.Width = 88;
            // 
            // clnrealPayAddress
            // 
            this.clnrealPayAddress.DataPropertyName = "realPayAddress";
            this.clnrealPayAddress.HeaderText = "实际付款人地址";
            this.clnrealPayAddress.Name = "clnrealPayAddress";
            this.clnrealPayAddress.ReadOnly = true;
            this.clnrealPayAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnrealPayAddress.Width = 124;
            // 
            // clnNominalPayerAddress
            // 
            this.clnNominalPayerAddress.DataPropertyName = "NominalPayerAddress";
            this.clnNominalPayerAddress.HeaderText = "名义付款人地址";
            this.clnNominalPayerAddress.Name = "clnNominalPayerAddress";
            this.clnNominalPayerAddress.ReadOnly = true;
            this.clnNominalPayerAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnNominalPayerAddress.Width = 124;
            // 
            // clnCustomerRef
            // 
            this.clnCustomerRef.DataPropertyName = "CustomerBusinissNo";
            this.clnCustomerRef.HeaderText = "客户业务编号";
            this.clnCustomerRef.Name = "clnCustomerRef";
            this.clnCustomerRef.ReadOnly = true;
            this.clnCustomerRef.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnCustomerRef.Width = 112;
            // 
            // clnOrgCode
            // 
            this.clnOrgCode.DataPropertyName = "OrgCode";
            this.clnOrgCode.HeaderText = "组织机构代码";
            this.clnOrgCode.Name = "clnOrgCode";
            this.clnOrgCode.ReadOnly = true;
            this.clnOrgCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnOrgCode.Width = 112;
            // 
            // clnRemitNote
            // 
            this.clnRemitNote.DataPropertyName = "Addtion";
            this.clnRemitNote.HeaderText = "汇款附言";
            this.clnRemitNote.Name = "clnRemitNote";
            this.clnRemitNote.ReadOnly = true;
            this.clnRemitNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnRemitNote.Width = 88;
            // 
            // clnPayeeAccount
            // 
            this.clnPayeeAccount.DataPropertyName = "PayeeAccount";
            this.clnPayeeAccount.HeaderText = "收款人账号";
            this.clnPayeeAccount.Name = "clnPayeeAccount";
            this.clnPayeeAccount.ReadOnly = true;
            this.clnPayeeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeName
            // 
            this.clnPayeeName.DataPropertyName = "PayeeName";
            this.clnPayeeName.HeaderText = "收款人名称";
            this.clnPayeeName.Name = "clnPayeeName";
            this.clnPayeeName.ReadOnly = true;
            this.clnPayeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeAddress
            // 
            this.clnPayeeAddress.DataPropertyName = "Address";
            this.clnPayeeAddress.HeaderText = "收款人地址";
            this.clnPayeeAddress.Name = "clnPayeeAddress";
            this.clnPayeeAddress.ReadOnly = true;
            this.clnPayeeAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeOpenBankType
            // 
            this.clnPayeeOpenBankType.DataPropertyName = "PayeeOpenBankName";
            this.clnPayeeOpenBankType.HeaderText = "收款人开户银行名称";
            this.clnPayeeOpenBankType.Name = "clnPayeeOpenBankType";
            this.clnPayeeOpenBankType.ReadOnly = true;
            this.clnPayeeOpenBankType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayeeOpenBankType.Width = 148;
            // 
            // clnPayeeOpenBankAddress
            // 
            this.clnPayeeOpenBankAddress.DataPropertyName = "OpenBankAddress";
            this.clnPayeeOpenBankAddress.HeaderText = "收款人开户银行地址";
            this.clnPayeeOpenBankAddress.Name = "clnPayeeOpenBankAddress";
            this.clnPayeeOpenBankAddress.ReadOnly = true;
            this.clnPayeeOpenBankAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayeeOpenBankAddress.Width = 148;
            // 
            // clnFSwiftCode
            // 
            this.clnFSwiftCode.DataPropertyName = "PayeeOpenBankSwiftCode";
            this.clnFSwiftCode.HeaderText = "收款人开户行swift code";
            this.clnFSwiftCode.Name = "clnFSwiftCode";
            this.clnFSwiftCode.ReadOnly = true;
            this.clnFSwiftCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnFSwiftCode.Width = 172;
            // 
            // clnCorrespendentBankName
            // 
            this.clnCorrespendentBankName.DataPropertyName = "CorrespondentBankName";
            this.clnCorrespendentBankName.HeaderText = "收款银行之代理行名称";
            this.clnCorrespendentBankName.Name = "clnCorrespendentBankName";
            this.clnCorrespendentBankName.ReadOnly = true;
            this.clnCorrespendentBankName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnCorrespendentBankName.Width = 160;
            // 
            // clnCSwiftCode
            // 
            this.clnCSwiftCode.DataPropertyName = "CorrespondentBankSwiftCode";
            this.clnCSwiftCode.HeaderText = "收款行之代理行swift code";
            this.clnCSwiftCode.Name = "clnCSwiftCode";
            this.clnCSwiftCode.ReadOnly = true;
            this.clnCSwiftCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnCSwiftCode.Width = 184;
            // 
            // clnCorrespendentBankAddress
            // 
            this.clnCorrespendentBankAddress.DataPropertyName = "CorrespondentBankAddress";
            this.clnCorrespendentBankAddress.HeaderText = "收款银行之代理行地址";
            this.clnCorrespendentBankAddress.Name = "clnCorrespendentBankAddress";
            this.clnCorrespendentBankAddress.ReadOnly = true;
            this.clnCorrespendentBankAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnCorrespendentBankAddress.Width = 160;
            // 
            // clnPayeeAccountInCorrespondentBank
            // 
            this.clnPayeeAccountInCorrespondentBank.DataPropertyName = "PayeeAccountInCorrespondentBank";
            this.clnPayeeAccountInCorrespondentBank.HeaderText = "收款人开户银行在其代理行账号";
            this.clnPayeeAccountInCorrespondentBank.Name = "clnPayeeAccountInCorrespondentBank";
            this.clnPayeeAccountInCorrespondentBank.ReadOnly = true;
            this.clnPayeeAccountInCorrespondentBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayeeAccountInCorrespondentBank.Width = 208;
            // 
            // clnPayeeCodeofCountry
            // 
            this.clnPayeeCodeofCountry.DataPropertyName = "CodeofCountry";
            this.clnPayeeCodeofCountry.HeaderText = "收款人常驻国家代码";
            this.clnPayeeCodeofCountry.Name = "clnPayeeCodeofCountry";
            this.clnPayeeCodeofCountry.ReadOnly = true;
            this.clnPayeeCodeofCountry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPayeeCodeofCountry.Width = 148;
            // 
            // clnAccountBankType
            // 
            this.clnAccountBankType.DataPropertyName = "FCPayeeAccountTypeString";
            this.clnAccountBankType.HeaderText = "收款人账号类型";
            this.clnAccountBankType.Name = "clnAccountBankType";
            this.clnAccountBankType.ReadOnly = true;
            this.clnAccountBankType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnAccountBankType.Width = 124;
            // 
            // clnPaymentCountryOrArea
            // 
            this.clnPaymentCountryOrArea.DataPropertyName = "PaymentCountryOrAreaString";
            this.clnPaymentCountryOrArea.HeaderText = "汇往国家或地区";
            this.clnPaymentCountryOrArea.Name = "clnPaymentCountryOrArea";
            this.clnPaymentCountryOrArea.ReadOnly = true;
            this.clnPaymentCountryOrArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPaymentCountryOrArea.Width = 124;
            // 
            // clnDealSerialNoF
            // 
            this.clnDealSerialNoF.DataPropertyName = "TransactionCode1";
            this.clnDealSerialNoF.HeaderText = "交易编码1";
            this.clnDealSerialNoF.Name = "clnDealSerialNoF";
            this.clnDealSerialNoF.ReadOnly = true;
            this.clnDealSerialNoF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnDealSerialNoF.Width = 94;
            // 
            // clnDealSerialNoS
            // 
            this.clnDealSerialNoS.DataPropertyName = "TransactionCode2";
            this.clnDealSerialNoS.HeaderText = "交易编码2";
            this.clnDealSerialNoS.Name = "clnDealSerialNoS";
            this.clnDealSerialNoS.ReadOnly = true;
            this.clnDealSerialNoS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnDealSerialNoS.Width = 94;
            // 
            // clnIPPSMoneyTypeAmount1
            // 
            this.clnIPPSMoneyTypeAmount1.DataPropertyName = "IPPSMoneyTypeAmount1";
            this.clnIPPSMoneyTypeAmount1.HeaderText = "相应货币及金额1";
            this.clnIPPSMoneyTypeAmount1.Name = "clnIPPSMoneyTypeAmount1";
            this.clnIPPSMoneyTypeAmount1.ReadOnly = true;
            this.clnIPPSMoneyTypeAmount1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnIPPSMoneyTypeAmount1.Width = 130;
            // 
            // clnIPPSMoneyTypeAmount2
            // 
            this.clnIPPSMoneyTypeAmount2.DataPropertyName = "IPPSMoneyTypeAmount2";
            this.clnIPPSMoneyTypeAmount2.HeaderText = "相应货币及金额2";
            this.clnIPPSMoneyTypeAmount2.Name = "clnIPPSMoneyTypeAmount2";
            this.clnIPPSMoneyTypeAmount2.ReadOnly = true;
            this.clnIPPSMoneyTypeAmount2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnIPPSMoneyTypeAmount2.Width = 130;
            // 
            // clnDealNoteF
            // 
            this.clnDealNoteF.DataPropertyName = "TransactionAddtion1";
            this.clnDealNoteF.HeaderText = "交易附言1";
            this.clnDealNoteF.Name = "clnDealNoteF";
            this.clnDealNoteF.ReadOnly = true;
            this.clnDealNoteF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnDealNoteF.Width = 94;
            // 
            // clnDealNoteS
            // 
            this.clnDealNoteS.DataPropertyName = "TransactionAddtion2";
            this.clnDealNoteS.HeaderText = "交易附言2";
            this.clnDealNoteS.Name = "clnDealNoteS";
            this.clnDealNoteS.ReadOnly = true;
            this.clnDealNoteS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnDealNoteS.Width = 94;
            // 
            // clnIsPayOffLine
            // 
            this.clnIsPayOffLine.DataPropertyName = "IsPayOffLineString";
            this.clnIsPayOffLine.HeaderText = "本笔款项是否为保税货物项下付款";
            this.clnIsPayOffLine.Name = "clnIsPayOffLine";
            this.clnIsPayOffLine.ReadOnly = true;
            this.clnIsPayOffLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnIsPayOffLine.Width = 220;
            // 
            // clnContactNo
            // 
            this.clnContactNo.DataPropertyName = "ContractNo";
            this.clnContactNo.HeaderText = "合同号";
            this.clnContactNo.Name = "clnContactNo";
            this.clnContactNo.ReadOnly = true;
            this.clnContactNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnContactNo.Width = 76;
            // 
            // clnBillSerialNo
            // 
            this.clnBillSerialNo.DataPropertyName = "InvoiceNo";
            this.clnBillSerialNo.HeaderText = "发票号";
            this.clnBillSerialNo.Name = "clnBillSerialNo";
            this.clnBillSerialNo.ReadOnly = true;
            this.clnBillSerialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnBillSerialNo.Width = 76;
            // 
            // clnBatchNoOrTNoOrSerialNo
            // 
            this.clnBatchNoOrTNoOrSerialNo.DataPropertyName = "BatchNoOrTNoOrSerialNo";
            this.clnBatchNoOrTNoOrSerialNo.HeaderText = "外汇局批件号/备案表号/业务编码";
            this.clnBatchNoOrTNoOrSerialNo.Name = "clnBatchNoOrTNoOrSerialNo";
            this.clnBatchNoOrTNoOrSerialNo.ReadOnly = true;
            this.clnBatchNoOrTNoOrSerialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnBatchNoOrTNoOrSerialNo.Width = 220;
            // 
            // clnProposerName
            // 
            this.clnProposerName.DataPropertyName = "ApplicantName";
            this.clnProposerName.HeaderText = "申请人姓名";
            this.clnProposerName.Name = "clnProposerName";
            this.clnProposerName.ReadOnly = true;
            this.clnProposerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnTelephone
            // 
            this.clnTelephone.DataPropertyName = "Contactnumber";
            this.clnTelephone.HeaderText = "联系电话";
            this.clnTelephone.Name = "clnTelephone";
            this.clnTelephone.ReadOnly = true;
            this.clnTelephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnTelephone.Width = 88;
            // 
            // clnPaymentPropertyType
            // 
            this.clnPaymentPropertyType.DataPropertyName = "PaymentNatureString";
            this.clnPaymentPropertyType.HeaderText = "付款性质";
            this.clnPaymentPropertyType.Name = "clnPaymentPropertyType";
            this.clnPaymentPropertyType.ReadOnly = true;
            this.clnPaymentPropertyType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPaymentPropertyType.Width = 88;
            // 
            // clnIsNoSavePay
            // 
            this.clnIsNoSavePay.DataPropertyName = "IsImportCancelAfterVerificationTypeString";
            this.clnIsNoSavePay.HeaderText = "是否进口核销付款";
            this.clnIsNoSavePay.Name = "clnIsNoSavePay";
            this.clnIsNoSavePay.ReadOnly = true;
            this.clnIsNoSavePay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnIsNoSavePay.Width = 136;
            // 
            // clnAssumeFeePayType
            // 
            this.clnAssumeFeePayType.DataPropertyName = "AssumeFeeTypeString";
            this.clnAssumeFeePayType.HeaderText = "国内外费用承担方式";
            this.clnAssumeFeePayType.Name = "clnAssumeFeePayType";
            this.clnAssumeFeePayType.ReadOnly = true;
            this.clnAssumeFeePayType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnAssumeFeePayType.Width = 148;
            // 
            // clnPurpose
            // 
            this.clnPurpose.DataPropertyName = "Purpose";
            this.clnPurpose.HeaderText = "用途";
            this.clnPurpose.Name = "clnPurpose";
            this.clnPurpose.ReadOnly = true;
            this.clnPurpose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clnPurpose.Width = 64;
            // 
            // UnitivePaymentFCItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UnitivePaymentFCItemsPanel";
            this.Size = new System.Drawing.Size(800, 460);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        CommonClient.Controls.ThemedDataGridView dgv;
        private System.Windows.Forms.Panel pnlHeader;
        private ThemedButton btnQuery;
        private Controls.TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblItemsDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayerAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNominalPayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNominalPayerAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCashType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSendPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayFeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnrealPayAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNominalPayerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOrgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeOpenBankType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeOpenBankAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFSwiftCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCorrespendentBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCSwiftCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCorrespendentBankAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAccountInCorrespondentBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeCodeofCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAccountBankType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPaymentCountryOrArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDealSerialNoF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDealSerialNoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIPPSMoneyTypeAmount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIPPSMoneyTypeAmount2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDealNoteF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDealNoteS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIsPayOffLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBillSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBatchNoOrTNoOrSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProposerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPaymentPropertyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIsNoSavePay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAssumeFeePayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPurpose;
    }
}
