namespace BOC_BATCH_TOOL.VisualParts
{
    partial class ElecTicketRemitItemsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketRemitItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clnRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeOpenBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeOpenBankNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeOpenBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeOpenBankNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCanChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAutoTipExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAutoTipReceiveTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnQuery = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.tbQueryContent = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblItemsDesc = new System.Windows.Forms.Label();
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
            // clnTicketType
            // 
            this.clnTicketType.DataPropertyName = "TicketTypeString";
            resources.ApplyResources(this.clnTicketType, "clnTicketType");
            this.clnTicketType.Name = "clnTicketType";
            this.clnTicketType.ReadOnly = true;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle1;
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
            // clnExchangeName
            // 
            this.clnExchangeName.DataPropertyName = "ExchangeName";
            resources.ApplyResources(this.clnExchangeName, "clnExchangeName");
            this.clnExchangeName.Name = "clnExchangeName";
            this.clnExchangeName.ReadOnly = true;
            this.clnExchangeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeAccount
            // 
            this.clnExchangeAccount.DataPropertyName = "ExchangeAccount";
            resources.ApplyResources(this.clnExchangeAccount, "clnExchangeAccount");
            this.clnExchangeAccount.Name = "clnExchangeAccount";
            this.clnExchangeAccount.ReadOnly = true;
            this.clnExchangeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeOpenBank
            // 
            this.clnExchangeOpenBank.DataPropertyName = "ExchangeOpenBankName";
            resources.ApplyResources(this.clnExchangeOpenBank, "clnExchangeOpenBank");
            this.clnExchangeOpenBank.Name = "clnExchangeOpenBank";
            this.clnExchangeOpenBank.ReadOnly = true;
            this.clnExchangeOpenBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeOpenBankNo
            // 
            this.clnExchangeOpenBankNo.DataPropertyName = "ExchangeOpenBankNo";
            resources.ApplyResources(this.clnExchangeOpenBankNo, "clnExchangeOpenBankNo");
            this.clnExchangeOpenBankNo.Name = "clnExchangeOpenBankNo";
            this.clnExchangeOpenBankNo.ReadOnly = true;
            this.clnExchangeOpenBankNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeName
            // 
            this.clnPayeeName.DataPropertyName = "PayeeName";
            resources.ApplyResources(this.clnPayeeName, "clnPayeeName");
            this.clnPayeeName.Name = "clnPayeeName";
            this.clnPayeeName.ReadOnly = true;
            // 
            // clnPayeeAccount
            // 
            this.clnPayeeAccount.DataPropertyName = "PayeeAccount";
            resources.ApplyResources(this.clnPayeeAccount, "clnPayeeAccount");
            this.clnPayeeAccount.Name = "clnPayeeAccount";
            this.clnPayeeAccount.ReadOnly = true;
            // 
            // clnPayeeOpenBank
            // 
            this.clnPayeeOpenBank.DataPropertyName = "PayeeOpenBankName";
            resources.ApplyResources(this.clnPayeeOpenBank, "clnPayeeOpenBank");
            this.clnPayeeOpenBank.Name = "clnPayeeOpenBank";
            this.clnPayeeOpenBank.ReadOnly = true;
            // 
            // clnPayeeOpenBankNo
            // 
            this.clnPayeeOpenBankNo.DataPropertyName = "PayeeOpenBankNo";
            resources.ApplyResources(this.clnPayeeOpenBankNo, "clnPayeeOpenBankNo");
            this.clnPayeeOpenBankNo.Name = "clnPayeeOpenBankNo";
            this.clnPayeeOpenBankNo.ReadOnly = true;
            // 
            // clnCanChange
            // 
            this.clnCanChange.DataPropertyName = "CanChangeString";
            resources.ApplyResources(this.clnCanChange, "clnCanChange");
            this.clnCanChange.Name = "clnCanChange";
            this.clnCanChange.ReadOnly = true;
            // 
            // clnAutoTipExchange
            // 
            this.clnAutoTipExchange.DataPropertyName = "AutoTipExchangeString";
            resources.ApplyResources(this.clnAutoTipExchange, "clnAutoTipExchange");
            this.clnAutoTipExchange.Name = "clnAutoTipExchange";
            this.clnAutoTipExchange.ReadOnly = true;
            // 
            // clnAutoTipReceiveTicket
            // 
            this.clnAutoTipReceiveTicket.DataPropertyName = "AutoTipReceiveTicketString";
            resources.ApplyResources(this.clnAutoTipReceiveTicket, "clnAutoTipReceiveTicket");
            this.clnAutoTipReceiveTicket.Name = "clnAutoTipReceiveTicket";
            this.clnAutoTipReceiveTicket.ReadOnly = true;
            // 
            // clnNote
            // 
            this.clnNote.DataPropertyName = "Note";
            resources.ApplyResources(this.clnNote, "clnNote");
            this.clnNote.Name = "clnNote";
            this.clnNote.ReadOnly = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnQuery);
            this.pnlHeader.Controls.Add(this.tbQueryContent);
            this.pnlHeader.Controls.Add(this.lblTransferDetailHeader_P);
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Controls.Add(this.lblItemsDesc);
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.Name = "pnlHeader";
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
            // lblHeaderInfo
            // 
            resources.ApplyResources(this.lblHeaderInfo, "lblHeaderInfo");
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            // 
            // lblItemsDesc
            // 
            resources.ApplyResources(this.lblItemsDesc, "lblItemsDesc");
            this.lblItemsDesc.Name = "lblItemsDesc";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnRowNo,
            this.clnError,
            this.clnTicketType,
            this.clnAmount,
            this.clnRemitDate,
            this.clnEndDate,
            this.clnRemitAccount,
            this.clnExchangeName,
            this.clnExchangeAccount,
            this.clnExchangeOpenBank,
            this.clnExchangeOpenBankNo,
            this.clnPayeeName,
            this.clnPayeeAccount,
            this.clnPayeeOpenBank,
            this.clnPayeeOpenBankNo,
            this.clnCanChange,
            this.clnAutoTipExchange,
            this.clnAutoTipReceiveTicket,
            this.clnNote});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(dgv, "dgv");
            dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ElecTicketRemitItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ElecTicketRemitItemsPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        BOC_BATCH_TOOL.Controls.ThemedDataGridView dgv;
        private Controls.ThemedButton btnQuery;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblItemsDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeOpenBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeOpenBankNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeOpenBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeOpenBankNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCanChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAutoTipExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAutoTipReceiveTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNote;
    }
}
