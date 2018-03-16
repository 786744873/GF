namespace BOC_BATCH_TOOL.VisualParts
{
    partial class ElecTicketPoolItemsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketPoolItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clnRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnElecTicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnElecTicketSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeBankNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeOpenBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeOpenBankNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeOpenBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPreBackNotedPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOperate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBusinessType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblItemsDesc = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.btnQuery = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.tbQueryContent = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            dgv = new BOC_BATCH_TOOL.Controls.ThemedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // clnRowNo
            // 
            resources.ApplyResources(this.clnRowNo, "clnRowNo");
            this.clnRowNo.Name = "clnRowNo";
            this.clnRowNo.ReadOnly = true;
            this.clnRowNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnError
            // 
            this.clnError.DataPropertyName = "ErrorReason";
            resources.ApplyResources(this.clnError, "clnError");
            this.clnError.Name = "clnError";
            this.clnError.ReadOnly = true;
            this.clnError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnCustomerRef
            // 
            this.clnCustomerRef.DataPropertyName = "CustomerRef";
            resources.ApplyResources(this.clnCustomerRef, "clnCustomerRef");
            this.clnCustomerRef.Name = "clnCustomerRef";
            this.clnCustomerRef.ReadOnly = true;
            this.clnCustomerRef.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnElecTicketType
            // 
            this.clnElecTicketType.DataPropertyName = "ElecTicketTypeString";
            resources.ApplyResources(this.clnElecTicketType, "clnElecTicketType");
            this.clnElecTicketType.Name = "clnElecTicketType";
            this.clnElecTicketType.ReadOnly = true;
            this.clnElecTicketType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeBank
            // 
            this.clnExchangeBank.DataPropertyName = "BankTypeString";
            resources.ApplyResources(this.clnExchangeBank, "clnExchangeBank");
            this.clnExchangeBank.Name = "clnExchangeBank";
            this.clnExchangeBank.ReadOnly = true;
            this.clnExchangeBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnElecTicketSerialNo
            // 
            this.clnElecTicketSerialNo.DataPropertyName = "ElecTicketSerialNo";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.clnElecTicketSerialNo.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.clnElecTicketSerialNo, "clnElecTicketSerialNo");
            this.clnElecTicketSerialNo.Name = "clnElecTicketSerialNo";
            this.clnElecTicketSerialNo.ReadOnly = true;
            this.clnElecTicketSerialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.clnAmount, "clnAmount");
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            this.clnAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnRemitDate
            // 
            this.clnRemitDate.DataPropertyName = "RemitDate";
            resources.ApplyResources(this.clnRemitDate, "clnRemitDate");
            this.clnRemitDate.Name = "clnRemitDate";
            this.clnRemitDate.ReadOnly = true;
            this.clnRemitDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnEndDate
            // 
            this.clnEndDate.DataPropertyName = "EndDate";
            resources.ApplyResources(this.clnEndDate, "clnEndDate");
            this.clnEndDate.Name = "clnEndDate";
            this.clnEndDate.ReadOnly = true;
            this.clnEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnRemitAccount
            // 
            this.clnRemitAccount.DataPropertyName = "RemitAccount";
            resources.ApplyResources(this.clnRemitAccount, "clnRemitAccount");
            this.clnRemitAccount.Name = "clnRemitAccount";
            this.clnRemitAccount.ReadOnly = true;
            this.clnRemitAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnRemitName
            // 
            this.clnRemitName.DataPropertyName = "RemitName";
            resources.ApplyResources(this.clnRemitName, "clnRemitName");
            this.clnRemitName.Name = "clnRemitName";
            this.clnRemitName.ReadOnly = true;
            this.clnRemitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeAccount
            // 
            this.clnExchangeAccount.DataPropertyName = "ExchangeAccount";
            resources.ApplyResources(this.clnExchangeAccount, "clnExchangeAccount");
            this.clnExchangeAccount.Name = "clnExchangeAccount";
            this.clnExchangeAccount.ReadOnly = true;
            this.clnExchangeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeName
            // 
            this.clnExchangeName.DataPropertyName = "ExchangeName";
            resources.ApplyResources(this.clnExchangeName, "clnExchangeName");
            this.clnExchangeName.Name = "clnExchangeName";
            this.clnExchangeName.ReadOnly = true;
            this.clnExchangeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeBankNo
            // 
            this.clnExchangeBankNo.DataPropertyName = "ExchangeBankNo";
            resources.ApplyResources(this.clnExchangeBankNo, "clnExchangeBankNo");
            this.clnExchangeBankNo.Name = "clnExchangeBankNo";
            this.clnExchangeBankNo.ReadOnly = true;
            this.clnExchangeBankNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeOpenBankName
            // 
            this.clnExchangeOpenBankName.DataPropertyName = "ExchangeBankName";
            resources.ApplyResources(this.clnExchangeOpenBankName, "clnExchangeOpenBankName");
            this.clnExchangeOpenBankName.Name = "clnExchangeOpenBankName";
            this.clnExchangeOpenBankName.ReadOnly = true;
            this.clnExchangeOpenBankName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeDate
            // 
            this.clnExchangeDate.DataPropertyName = "ExchangeDate";
            resources.ApplyResources(this.clnExchangeDate, "clnExchangeDate");
            this.clnExchangeDate.Name = "clnExchangeDate";
            this.clnExchangeDate.ReadOnly = true;
            this.clnExchangeDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeName
            // 
            this.clnPayeeName.DataPropertyName = "PayeeName";
            resources.ApplyResources(this.clnPayeeName, "clnPayeeName");
            this.clnPayeeName.Name = "clnPayeeName";
            this.clnPayeeName.ReadOnly = true;
            this.clnPayeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeAccount
            // 
            this.clnPayeeAccount.DataPropertyName = "PayeeAccount";
            resources.ApplyResources(this.clnPayeeAccount, "clnPayeeAccount");
            this.clnPayeeAccount.Name = "clnPayeeAccount";
            this.clnPayeeAccount.ReadOnly = true;
            this.clnPayeeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeOpenBankNo
            // 
            this.clnPayeeOpenBankNo.DataPropertyName = "PayeeOpenBankNo";
            resources.ApplyResources(this.clnPayeeOpenBankNo, "clnPayeeOpenBankNo");
            this.clnPayeeOpenBankNo.Name = "clnPayeeOpenBankNo";
            this.clnPayeeOpenBankNo.ReadOnly = true;
            this.clnPayeeOpenBankNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeOpenBankName
            // 
            this.clnPayeeOpenBankName.DataPropertyName = "PayeeOpenBankName";
            resources.ApplyResources(this.clnPayeeOpenBankName, "clnPayeeOpenBankName");
            this.clnPayeeOpenBankName.Name = "clnPayeeOpenBankName";
            this.clnPayeeOpenBankName.ReadOnly = true;
            this.clnPayeeOpenBankName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPreBackNotedPerson
            // 
            this.clnPreBackNotedPerson.DataPropertyName = "PreBackNotedPerson";
            resources.ApplyResources(this.clnPreBackNotedPerson, "clnPreBackNotedPerson");
            this.clnPreBackNotedPerson.Name = "clnPreBackNotedPerson";
            this.clnPreBackNotedPerson.ReadOnly = true;
            this.clnPreBackNotedPerson.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnOperate
            // 
            this.clnOperate.DataPropertyName = "EndDateOperateString";
            resources.ApplyResources(this.clnOperate, "clnOperate");
            this.clnOperate.Name = "clnOperate";
            this.clnOperate.ReadOnly = true;
            this.clnOperate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnBusinessType
            // 
            this.clnBusinessType.DataPropertyName = "BusinessTypeString";
            resources.ApplyResources(this.clnBusinessType, "clnBusinessType");
            this.clnBusinessType.Name = "clnBusinessType";
            this.clnBusinessType.ReadOnly = true;
            this.clnBusinessType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblItemsDesc);
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Controls.Add(this.btnQuery);
            this.pnlHeader.Controls.Add(this.tbQueryContent);
            this.pnlHeader.Controls.Add(this.lblTransferDetailHeader_P);
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.Name = "pnlHeader";
            // 
            // lblItemsDesc
            // 
            resources.ApplyResources(this.lblItemsDesc, "lblItemsDesc");
            this.lblItemsDesc.Name = "lblItemsDesc";
            // 
            // lblHeaderInfo
            // 
            resources.ApplyResources(this.lblHeaderInfo, "lblHeaderInfo");
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbQueryContent
            // 
            resources.ApplyResources(this.tbQueryContent, "tbQueryContent");
            this.tbQueryContent.EditorValueChanged = false;
            this.tbQueryContent.ErrorProvider = null;
            this.tbQueryContent.Name = "tbQueryContent";
            this.tbQueryContent.ValidateEnabled = false;
            this.tbQueryContent.ValidateRule.MaxLength = 0;
            this.tbQueryContent.ValidateRule.MinLength = 0;
            this.tbQueryContent.ValidateRule.RegexValue = null;
            this.tbQueryContent.ValidateRule.Required = false;
            // 
            // lblTransferDetailHeader_P
            // 
            resources.ApplyResources(this.lblTransferDetailHeader_P, "lblTransferDetailHeader_P");
            this.lblTransferDetailHeader_P.Name = "lblTransferDetailHeader_P";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnRowNo,
            this.clnError,
            this.clnCustomerRef,
            this.clnElecTicketType,
            this.clnExchangeBank,
            this.clnElecTicketSerialNo,
            this.clnAmount,
            this.clnRemitDate,
            this.clnEndDate,
            this.clnRemitAccount,
            this.clnRemitName,
            this.clnExchangeAccount,
            this.clnExchangeName,
            this.clnExchangeBankNo,
            this.clnExchangeOpenBankName,
            this.clnExchangeDate,
            this.clnPayeeName,
            this.clnPayeeAccount,
            this.clnPayeeOpenBankNo,
            this.clnPayeeOpenBankName,
            this.clnPreBackNotedPerson,
            this.clnOperate,
            this.clnBusinessType});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(dgv, "dgv");
            dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ElecTicketPoolItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ElecTicketPoolItemsPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        BOC_BATCH_TOOL.Controls.ThemedDataGridView dgv;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblItemsDesc;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private Controls.ThemedButton btnQuery;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnElecTicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnElecTicketSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeBankNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeOpenBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeOpenBankNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeOpenBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPreBackNotedPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOperate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBusinessType;
    }
}
