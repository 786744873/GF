namespace BOC_BATCH_TOOL.VisualParts
{
    partial class InitiativeAllotItemsPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitiativeAllotItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new BOC_BATCH_TOOL.Controls.ThemedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBankCustomerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnQuery = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.tbQueryContent = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblItemsDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clnError,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn7,
            this.clnAmount,
            this.clnBankCustomerNo,
            this.clnCustomerName,
            this.clnPayDate,
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnError
            // 
            this.clnError.DataPropertyName = "ErrorReason";
            resources.ApplyResources(this.clnError, "clnError");
            this.clnError.Name = "clnError";
            this.clnError.ReadOnly = true;
            this.clnError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountOut";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NameOut";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "AccountIn";
            resources.ApplyResources(this.clnAmount, "clnAmount");
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            this.clnAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnBankCustomerNo
            // 
            this.clnBankCustomerNo.DataPropertyName = "NameIn";
            resources.ApplyResources(this.clnBankCustomerNo, "clnBankCustomerNo");
            this.clnBankCustomerNo.Name = "clnBankCustomerNo";
            this.clnBankCustomerNo.ReadOnly = true;
            this.clnBankCustomerNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnCustomerName
            // 
            this.clnCustomerName.DataPropertyName = "CashTypeString";
            resources.ApplyResources(this.clnCustomerName, "clnCustomerName");
            this.clnCustomerName.Name = "clnCustomerName";
            this.clnCustomerName.ReadOnly = true;
            this.clnCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayDate
            // 
            this.clnPayDate.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Format = "N2";
            this.clnPayDate.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.clnPayDate, "clnPayDate");
            this.clnPayDate.Name = "clnPayDate";
            this.clnPayDate.ReadOnly = true;
            this.clnPayDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Addition";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // InitiativeAllotItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlHeader);
            this.Name = "InitiativeAllotItemsPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ThemedDataGridView dgv;
        private System.Windows.Forms.Panel pnlHeader;
        private Controls.ThemedButton btnQuery;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblItemsDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBankCustomerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
