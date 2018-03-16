using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class TransferItemsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTransferHeader_P = new System.Windows.Forms.Panel();
            this.btnQuery = new CommonClient.Controls.ThemedButton();
            this.tbQueryContent = new CommonClient.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransferDetailHeaderInfo_P = new System.Windows.Forms.Label();
            this.clnRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayeeOpenBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCNAPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayerAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayFeeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNotice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnlCustomerRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayingCurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgv = new CommonClient.Controls.ThemedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlTransferHeader_P.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTransferHeader_P
            // 
            this.pnlTransferHeader_P.Controls.Add(this.btnQuery);
            this.pnlTransferHeader_P.Controls.Add(this.tbQueryContent);
            this.pnlTransferHeader_P.Controls.Add(this.label1);
            this.pnlTransferHeader_P.Controls.Add(this.lblTransferDetailHeaderInfo_P);
            this.pnlTransferHeader_P.Controls.Add(this.lblTransferDetailHeader_P);
            resources.ApplyResources(this.pnlTransferHeader_P, "pnlTransferHeader_P");
            this.pnlTransferHeader_P.Name = "pnlTransferHeader_P";
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
            this.tbQueryContent.DvDataField = null;
            this.tbQueryContent.DvEditorValueChanged = false;
            this.tbQueryContent.DvErrorProvider = this.errorProvider1;
            this.tbQueryContent.DvLinkedLabel = this.lblTransferDetailHeader_P;
            this.tbQueryContent.DvMaxLength = 0;
            this.tbQueryContent.DvMinLength = 0;
            this.tbQueryContent.DvRegCode = null;
            this.tbQueryContent.DvRequired = false;
            this.tbQueryContent.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbQueryContent.DvValidateEnabled = true;
            this.tbQueryContent.DvValidator = null;
            this.tbQueryContent.Name = "tbQueryContent";
            // 
            // lblTransferDetailHeader_P
            // 
            resources.ApplyResources(this.lblTransferDetailHeader_P, "lblTransferDetailHeader_P");
            this.lblTransferDetailHeader_P.Name = "lblTransferDetailHeader_P";
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
            resources.ApplyResources(dgv, "dgv");
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnRowNo,
            this.clnError,
            this.colPayingAmount,
            this.colPayeeName,
            this.clnPayeeAccount,
            this.colPayeeOpenBank,
            this.clnCNAPS,
            this.clnPayerAccount,
            this.clnPayFeeNo,
            this.clnPayDatetime,
            this.clnNotice,
            this.clnOrder,
            this.clnEmail,
            this.cnlCustomerRef,
            this.clnPayerName,
            this.clnPayingCurr});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle4;
            dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTransfer_MouseDoubleClick);
            // 
            // clnRowNo
            // 
            this.clnRowNo.DataPropertyName = "RowIndex";
            this.clnRowNo.FillWeight = 10.20178F;
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
            // colPayingAmount
            // 
            this.colPayingAmount.DataPropertyName = "PayAmount";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colPayingAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPayingAmount.FillWeight = 24.50053F;
            resources.ApplyResources(this.colPayingAmount, "colPayingAmount");
            this.colPayingAmount.Name = "colPayingAmount";
            this.colPayingAmount.ReadOnly = true;
            this.colPayingAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colPayeeName
            // 
            this.colPayeeName.DataPropertyName = "PayeeName";
            this.colPayeeName.FillWeight = 48.36049F;
            resources.ApplyResources(this.colPayeeName, "colPayeeName");
            this.colPayeeName.Name = "colPayeeName";
            this.colPayeeName.ReadOnly = true;
            this.colPayeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeAccount
            // 
            this.clnPayeeAccount.DataPropertyName = "PayeeAccount";
            this.clnPayeeAccount.FillWeight = 242.4684F;
            resources.ApplyResources(this.clnPayeeAccount, "clnPayeeAccount");
            this.clnPayeeAccount.Name = "clnPayeeAccount";
            this.clnPayeeAccount.ReadOnly = true;
            this.clnPayeeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colPayeeOpenBank
            // 
            this.colPayeeOpenBank.DataPropertyName = "PayeeOpenBank";
            this.colPayeeOpenBank.FillWeight = 864.9748F;
            resources.ApplyResources(this.colPayeeOpenBank, "colPayeeOpenBank");
            this.colPayeeOpenBank.Name = "colPayeeOpenBank";
            this.colPayeeOpenBank.ReadOnly = true;
            this.colPayeeOpenBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnCNAPS
            // 
            this.clnCNAPS.DataPropertyName = "CNAPSNo";
            this.clnCNAPS.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnCNAPS, "clnCNAPS");
            this.clnCNAPS.Name = "clnCNAPS";
            this.clnCNAPS.ReadOnly = true;
            this.clnCNAPS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayerAccount
            // 
            this.clnPayerAccount.DataPropertyName = "PayerAccount";
            this.clnPayerAccount.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnPayerAccount, "clnPayerAccount");
            this.clnPayerAccount.Name = "clnPayerAccount";
            this.clnPayerAccount.ReadOnly = true;
            this.clnPayerAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayFeeNo
            // 
            this.clnPayFeeNo.DataPropertyName = "PayFeeNo";
            this.clnPayFeeNo.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnPayFeeNo, "clnPayFeeNo");
            this.clnPayFeeNo.Name = "clnPayFeeNo";
            this.clnPayFeeNo.ReadOnly = true;
            this.clnPayFeeNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayDatetime
            // 
            this.clnPayDatetime.DataPropertyName = "PayDatetime";
            this.clnPayDatetime.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnPayDatetime, "clnPayDatetime");
            this.clnPayDatetime.Name = "clnPayDatetime";
            this.clnPayDatetime.ReadOnly = true;
            this.clnPayDatetime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnNotice
            // 
            this.clnNotice.DataPropertyName = "Addition";
            this.clnNotice.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnNotice, "clnNotice");
            this.clnNotice.Name = "clnNotice";
            this.clnNotice.ReadOnly = true;
            this.clnNotice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnOrder
            // 
            this.clnOrder.DataPropertyName = "TChanelString";
            this.clnOrder.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnOrder, "clnOrder");
            this.clnOrder.Name = "clnOrder";
            this.clnOrder.ReadOnly = true;
            this.clnOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnEmail
            // 
            this.clnEmail.DataPropertyName = "Email";
            this.clnEmail.FillWeight = 1.356373F;
            resources.ApplyResources(this.clnEmail, "clnEmail");
            this.clnEmail.Name = "clnEmail";
            this.clnEmail.ReadOnly = true;
            this.clnEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cnlCustomerRef
            // 
            this.cnlCustomerRef.DataPropertyName = "CustomerRef";
            resources.ApplyResources(this.cnlCustomerRef, "cnlCustomerRef");
            this.cnlCustomerRef.Name = "cnlCustomerRef";
            this.cnlCustomerRef.ReadOnly = true;
            this.cnlCustomerRef.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayerName
            // 
            resources.ApplyResources(this.clnPayerName, "clnPayerName");
            this.clnPayerName.Name = "clnPayerName";
            this.clnPayerName.ReadOnly = true;
            this.clnPayerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayingCurr
            // 
            resources.ApplyResources(this.clnPayingCurr, "clnPayingCurr");
            this.clnPayingCurr.Name = "clnPayingCurr";
            this.clnPayingCurr.ReadOnly = true;
            this.clnPayingCurr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TransferItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.pnlTransferHeader_P);
            this.Name = "TransferItemsPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlTransferHeader_P.ResumeLayout(false);
            this.pnlTransferHeader_P.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        CommonClient.Controls.ThemedDataGridView dgv;
        private System.Windows.Forms.Panel pnlTransferHeader_P;
        private System.Windows.Forms.Label lblTransferDetailHeaderInfo_P;
        private ThemedButton btnQuery;
        private TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayeeOpenBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCNAPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayerAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayFeeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNotice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnlCustomerRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayingCurr;
    }
}
