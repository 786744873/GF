namespace BOC_BATCH_TOOL
{
    partial class frmOpenBankQuery
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenBankQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.batchPagesPanel = new BOC_BATCH_TOOL.VisualParts.BatchPagesPanel();
            this.tbNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.tbBankName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.dgv = new BOC_BATCH_TOOL.Controls.ThemedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnQuery = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // batchPagesPanel
            // 
            this.batchPagesPanel.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.batchPagesPanel, "batchPagesPanel");
            this.batchPagesPanel.Name = "batchPagesPanel";
            // 
            // tbNo
            // 
            this.tbNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNo.EditorValueChanged = false;
            this.tbNo.ErrorProvider = null;
            resources.ApplyResources(this.tbNo, "tbNo");
            this.tbNo.Name = "tbNo";
            this.tbNo.ValidateEnabled = false;
            this.tbNo.ValidateRule.MaxLength = 0;
            this.tbNo.ValidateRule.MinLength = 0;
            this.tbNo.ValidateRule.RegexValue = null;
            this.tbNo.ValidateRule.Required = false;
            // 
            // tbBankName
            // 
            this.tbBankName.EditorValueChanged = false;
            this.tbBankName.ErrorProvider = null;
            resources.ApplyResources(this.tbBankName, "tbBankName");
            this.tbBankName.Name = "tbBankName";
            this.tbBankName.ValidateEnabled = false;
            this.tbBankName.ValidateRule.MaxLength = 0;
            this.tbBankName.ValidateRule.MinLength = 0;
            this.tbBankName.ValidateRule.RegexValue = null;
            this.tbBankName.ValidateRule.Required = false;
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
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.StandardTab = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Code";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Addr";
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::BOC_BATCH_TOOL.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.MouseHover += new System.EventHandler(this.pbTip_MouseHover);
            // 
            // frmOpenBankQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pbTip);
            this.Controls.Add(this.batchPagesPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNo);
            this.Controls.Add(this.tbBankName);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOpenBankQuery";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisualParts.BatchPagesPanel batchPagesPanel;
        private System.Windows.Forms.Label label3;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbNo;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbBankName;
        private Controls.ThemedButton btnCancel;
        private Controls.ThemedButton btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.ThemedDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}