using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualParts
{
    partial class TransferOverBankItemPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferOverBankItemPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProtecolNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBusinessType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnClearBankNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayerAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayFeeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAddtion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOperatorOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuery = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.tbQueryContent = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransferDetailHeaderInfo_P = new System.Windows.Forms.Label();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            dgv = new BOC_BATCH_TOOL.Controls.ThemedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // clnIndex
            // 
            resources.ApplyResources(this.clnIndex, "clnIndex");
            this.clnIndex.Name = "clnIndex";
            this.clnIndex.ReadOnly = true;
            this.clnIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnError
            // 
            this.clnError.DataPropertyName = "ErrorReason";
            resources.ApplyResources(this.clnError, "clnError");
            this.clnError.Name = "clnError";
            this.clnError.ReadOnly = true;
            this.clnError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "PayAmount";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.clnAmount, "clnAmount");
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            this.clnAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnProtecolNo
            // 
            this.clnProtecolNo.DataPropertyName = "PayProtecolNo";
            resources.ApplyResources(this.clnProtecolNo, "clnProtecolNo");
            this.clnProtecolNo.Name = "clnProtecolNo";
            this.clnProtecolNo.ReadOnly = true;
            this.clnProtecolNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnBusinessType
            // 
            this.clnBusinessType.DataPropertyName = "BusinessTypeString";
            resources.ApplyResources(this.clnBusinessType, "clnBusinessType");
            this.clnBusinessType.Name = "clnBusinessType";
            this.clnBusinessType.ReadOnly = true;
            this.clnBusinessType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeName
            // 
            this.clnPayeeName.DataPropertyName = "PayeeName";
            resources.ApplyResources(this.clnPayeeName, "clnPayeeName");
            this.clnPayeeName.Name = "clnPayeeName";
            this.clnPayeeName.ReadOnly = true;
            this.clnPayeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeAcount
            // 
            this.clnPayeeAcount.DataPropertyName = "PayeeAccount";
            resources.ApplyResources(this.clnPayeeAcount, "clnPayeeAcount");
            this.clnPayeeAcount.Name = "clnPayeeAcount";
            this.clnPayeeAcount.ReadOnly = true;
            this.clnPayeeAcount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeBankName
            // 
            this.clnPayeeBankName.DataPropertyName = "PayeeOpenBank";
            resources.ApplyResources(this.clnPayeeBankName, "clnPayeeBankName");
            this.clnPayeeBankName.Name = "clnPayeeBankName";
            this.clnPayeeBankName.ReadOnly = true;
            this.clnPayeeBankName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnClearBankNo
            // 
            this.clnClearBankNo.DataPropertyName = "PayBankNo";
            resources.ApplyResources(this.clnClearBankNo, "clnClearBankNo");
            this.clnClearBankNo.Name = "clnClearBankNo";
            this.clnClearBankNo.ReadOnly = true;
            this.clnClearBankNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayerAccount
            // 
            this.clnPayerAccount.DataPropertyName = "PayerAccount";
            resources.ApplyResources(this.clnPayerAccount, "clnPayerAccount");
            this.clnPayerAccount.Name = "clnPayerAccount";
            this.clnPayerAccount.ReadOnly = true;
            this.clnPayerAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnCustomerNo
            // 
            this.clnCustomerNo.DataPropertyName = "CustomerRef";
            resources.ApplyResources(this.clnCustomerNo, "clnCustomerNo");
            this.clnCustomerNo.Name = "clnCustomerNo";
            this.clnCustomerNo.ReadOnly = true;
            this.clnCustomerNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayFeeAccount
            // 
            this.clnPayFeeAccount.DataPropertyName = "PayFeeNo";
            resources.ApplyResources(this.clnPayFeeAccount, "clnPayFeeAccount");
            this.clnPayFeeAccount.Name = "clnPayFeeAccount";
            this.clnPayFeeAccount.ReadOnly = true;
            this.clnPayFeeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnAddtion
            // 
            this.clnAddtion.DataPropertyName = "Addition";
            resources.ApplyResources(this.clnAddtion, "clnAddtion");
            this.clnAddtion.Name = "clnAddtion";
            this.clnAddtion.ReadOnly = true;
            this.clnAddtion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnEmail
            // 
            this.clnEmail.DataPropertyName = "Email";
            resources.ApplyResources(this.clnEmail, "clnEmail");
            this.clnEmail.Name = "clnEmail";
            this.clnEmail.ReadOnly = true;
            this.clnEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnOperatorOrder
            // 
            this.clnOperatorOrder.DataPropertyName = "TChanelString";
            resources.ApplyResources(this.clnOperatorOrder, "clnOperatorOrder");
            this.clnOperatorOrder.Name = "clnOperatorOrder";
            this.clnOperatorOrder.ReadOnly = true;
            this.clnOperatorOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnDateTime
            // 
            this.clnDateTime.DataPropertyName = "PayDateTime";
            resources.ApplyResources(this.clnDateTime, "clnDateTime");
            this.clnDateTime.Name = "clnDateTime";
            this.clnDateTime.ReadOnly = true;
            this.clnDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.tbQueryContent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTransferDetailHeaderInfo_P);
            this.panel1.Controls.Add(this.lblTransferDetailHeader_P);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            this.tbQueryContent.TextChanged += new System.EventHandler(this.tbQueryContent_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblTransferDetailHeaderInfo_P
            // 
            resources.ApplyResources(this.lblTransferDetailHeaderInfo_P, "lblTransferDetailHeaderInfo_P");
            this.lblTransferDetailHeaderInfo_P.Name = "lblTransferDetailHeaderInfo_P";
            // 
            // lblTransferDetailHeader_P
            // 
            resources.ApplyResources(this.lblTransferDetailHeader_P, "lblTransferDetailHeader_P");
            this.lblTransferDetailHeader_P.Name = "lblTransferDetailHeader_P";
            this.lblTransferDetailHeader_P.Click += new System.EventHandler(this.lblTransferDetailHeader_P_Click);
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
            this.clnIndex,
            this.clnError,
            this.clnAmount,
            this.clnProtecolNo,
            this.clnBusinessType,
            this.clnPayeeName,
            this.clnPayeeAcount,
            this.clnPayeeBankName,
            this.clnClearBankNo,
            this.clnPayerAccount,
            this.clnCustomerNo,
            this.clnPayFeeAccount,
            this.clnAddtion,
            this.clnEmail,
            this.clnOperatorOrder,
            this.clnDateTime});
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
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // TransferOverBankItemPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.panel1);
            this.Name = "TransferOverBankItemPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        BOC_BATCH_TOOL.Controls.ThemedDataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private ThemedButton btnQuery;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeaderInfo_P;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProtecolNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBusinessType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnClearBankNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayerAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayFeeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAddtion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOperatorOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDateTime;
    }
}
