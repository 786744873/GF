﻿using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class BatchReimbursementItemsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchReimbursementItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnQuery = new CommonClient.Controls.ThemedButton();
            this.tbQueryContent = new CommonClient.Controls.TextBoxCanValidate();
            this.lblTransferDetailHeader_P = new System.Windows.Forms.Label();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblItemsDesc = new System.Windows.Forms.Label();
            this.clnRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnReimburseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tbQueryContent.DvDataField = null;
            this.tbQueryContent.DvEditorValueChanged = false;
            this.tbQueryContent.DvErrorProvider = this.errorProvider1;
            this.tbQueryContent.DvFixLength = false;
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
            this.clnCardNo,
            this.clnPayAmount,
            this.clnPayDate,
            this.clnPayPassword,
            this.clnReimburseAmount,
            this.clnUsage});
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
            dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
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
            // clnCardNo
            // 
            this.clnCardNo.DataPropertyName = "CardNo";
            dataGridViewCellStyle3.NullValue = null;
            this.clnCardNo.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.clnCardNo, "clnCardNo");
            this.clnCardNo.Name = "clnCardNo";
            this.clnCardNo.ReadOnly = true;
            this.clnCardNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayAmount
            // 
            this.clnPayAmount.DataPropertyName = "PayAmount";
            resources.ApplyResources(this.clnPayAmount, "clnPayAmount");
            this.clnPayAmount.Name = "clnPayAmount";
            this.clnPayAmount.ReadOnly = true;
            this.clnPayAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayDate
            // 
            this.clnPayDate.DataPropertyName = "PayDateTime";
            resources.ApplyResources(this.clnPayDate, "clnPayDate");
            this.clnPayDate.Name = "clnPayDate";
            this.clnPayDate.ReadOnly = true;
            this.clnPayDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnPayPassword
            // 
            this.clnPayPassword.DataPropertyName = "PayPassword";
            resources.ApplyResources(this.clnPayPassword, "clnPayPassword");
            this.clnPayPassword.Name = "clnPayPassword";
            this.clnPayPassword.ReadOnly = true;
            this.clnPayPassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnReimburseAmount
            // 
            this.clnReimburseAmount.DataPropertyName = "ReimburseAmount";
            resources.ApplyResources(this.clnReimburseAmount, "clnReimburseAmount");
            this.clnReimburseAmount.Name = "clnReimburseAmount";
            this.clnReimburseAmount.ReadOnly = true;
            this.clnReimburseAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clnUsage
            // 
            this.clnUsage.DataPropertyName = "Usage";
            resources.ApplyResources(this.clnUsage, "clnUsage");
            this.clnUsage.Name = "clnUsage";
            this.clnUsage.ReadOnly = true;
            this.clnUsage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // BatchReimbursementItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(dgv);
            this.Controls.Add(this.pnlHeader);
            this.Name = "BatchReimbursementItemsPanel";
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
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblItemsDesc;
        private ThemedButton btnQuery;
        private TextBoxCanValidate tbQueryContent;
        private System.Windows.Forms.Label lblTransferDetailHeader_P;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReimburseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUsage;
    }
}