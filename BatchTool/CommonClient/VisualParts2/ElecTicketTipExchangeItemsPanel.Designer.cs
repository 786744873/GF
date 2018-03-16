﻿using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class ElecTicketTipExchangeItemsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketTipExchangeItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblItemsDesc = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.btnQuery = new CommonClient.Controls.ThemedButton();
            this.tbQueryContent = new CommonClient.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            this.clnRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemitAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExchangeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayeeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgv = new CommonClient.Controls.ThemedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            this.SuspendLayout();
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
            this.clnTicketType,
            this.clnAmount,
            this.clnRemitDate,
            this.clnEndDate,
            this.clnRemitAccount,
            this.clnExchangeName,
            this.clnPayeeName,
            this.clnPayeeAccount,
            this.clnNote});
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
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // clnRowNo
            // 
            this.clnRowNo.DataPropertyName = "RowIndex";
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
            this.clnTicketType.DataPropertyName = "RemitAccount";
            resources.ApplyResources(this.clnTicketType, "clnTicketType");
            this.clnTicketType.Name = "clnTicketType";
            this.clnTicketType.ReadOnly = true;
            this.clnTicketType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "ElecTicketSerialNo";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.clnAmount, "clnAmount");
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            this.clnAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnRemitDate
            // 
            this.clnRemitDate.DataPropertyName = "ExchangeAccount";
            resources.ApplyResources(this.clnRemitDate, "clnRemitDate");
            this.clnRemitDate.Name = "clnRemitDate";
            this.clnRemitDate.ReadOnly = true;
            this.clnRemitDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnEndDate
            // 
            this.clnEndDate.DataPropertyName = "ExchangeName";
            resources.ApplyResources(this.clnEndDate, "clnEndDate");
            this.clnEndDate.Name = "clnEndDate";
            this.clnEndDate.ReadOnly = true;
            this.clnEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnRemitAccount
            // 
            this.clnRemitAccount.DataPropertyName = "ExchangeOpenBankName";
            resources.ApplyResources(this.clnRemitAccount, "clnRemitAccount");
            this.clnRemitAccount.Name = "clnRemitAccount";
            this.clnRemitAccount.ReadOnly = true;
            this.clnRemitAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnExchangeName
            // 
            this.clnExchangeName.DataPropertyName = "ExchangeOpenBankNo";
            resources.ApplyResources(this.clnExchangeName, "clnExchangeName");
            this.clnExchangeName.Name = "clnExchangeName";
            this.clnExchangeName.ReadOnly = true;
            this.clnExchangeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeName
            // 
            this.clnPayeeName.DataPropertyName = "BillSerialNo";
            resources.ApplyResources(this.clnPayeeName, "clnPayeeName");
            this.clnPayeeName.Name = "clnPayeeName";
            this.clnPayeeName.ReadOnly = true;
            this.clnPayeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayeeAccount
            // 
            this.clnPayeeAccount.DataPropertyName = "ContractNo";
            resources.ApplyResources(this.clnPayeeAccount, "clnPayeeAccount");
            this.clnPayeeAccount.Name = "clnPayeeAccount";
            this.clnPayeeAccount.ReadOnly = true;
            this.clnPayeeAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnNote
            // 
            this.clnNote.DataPropertyName = "Note";
            resources.ApplyResources(this.clnNote, "clnNote");
            this.clnNote.Name = "clnNote";
            this.clnNote.ReadOnly = true;
            this.clnNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ElecTicketTipExchangeItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ElecTicketTipExchangeItemsPanel";
            resources.ApplyResources(this, "$this");
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
        private TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.Label lblItemsDesc;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemitAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayeeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNote;
    }
}
