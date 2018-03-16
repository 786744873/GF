using CommonClient.Controls;
using CommonClient.VisualParts;

namespace CommonClient
{
    partial class wndPayeeQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wndPayeeQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.edtPayeeSerial = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeSerial = new System.Windows.Forms.Label();
            this.edtPayeeAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.edtPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.lblPayeeName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.batchPagesPanel = new CommonClient.VisualParts.BatchPagesPanel();
            this.dgv = new CommonClient.Controls.ThemedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnReset = new CommonClient.Controls.ThemedButton();
            this.btnQuery = new CommonClient.Controls.ThemedButton();
            this.btnCancel = new CommonClient.Controls.ThemedButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // edtPayeeSerial
            // 
            this.edtPayeeSerial.DvDataField = null;
            this.edtPayeeSerial.DvEditorValueChanged = false;
            this.edtPayeeSerial.DvErrorProvider = null;
            this.edtPayeeSerial.DvLinkedLabel = null;
            this.edtPayeeSerial.DvMaxLength = 0;
            this.edtPayeeSerial.DvMinLength = 0;
            this.edtPayeeSerial.DvRegCode = null;
            this.edtPayeeSerial.DvRequired = false;
            this.edtPayeeSerial.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeSerial.DvValidateEnabled = true;
            this.edtPayeeSerial.DvValidator = null;
            resources.ApplyResources(this.edtPayeeSerial, "edtPayeeSerial");
            this.edtPayeeSerial.Name = "edtPayeeSerial";
            // 
            // lblPayeeSerial
            // 
            resources.ApplyResources(this.lblPayeeSerial, "lblPayeeSerial");
            this.languageList1.SetDvLangId(this.lblPayeeSerial, null);
            this.lblPayeeSerial.Name = "lblPayeeSerial";
            // 
            // edtPayeeAccount
            // 
            this.edtPayeeAccount.DvDataField = null;
            this.edtPayeeAccount.DvEditorValueChanged = false;
            this.edtPayeeAccount.DvErrorProvider = null;
            this.edtPayeeAccount.DvLinkedLabel = null;
            this.edtPayeeAccount.DvMaxLength = 0;
            this.edtPayeeAccount.DvMinLength = 0;
            this.edtPayeeAccount.DvRegCode = null;
            this.edtPayeeAccount.DvRequired = false;
            this.edtPayeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeAccount.DvValidateEnabled = true;
            this.edtPayeeAccount.DvValidator = null;
            resources.ApplyResources(this.edtPayeeAccount, "edtPayeeAccount");
            this.edtPayeeAccount.Name = "edtPayeeAccount";
            // 
            // edtPayeeName
            // 
            this.edtPayeeName.DvDataField = null;
            this.edtPayeeName.DvEditorValueChanged = false;
            this.edtPayeeName.DvErrorProvider = null;
            this.edtPayeeName.DvLinkedLabel = null;
            this.edtPayeeName.DvMaxLength = 0;
            this.edtPayeeName.DvMinLength = 0;
            this.edtPayeeName.DvRegCode = null;
            this.edtPayeeName.DvRequired = false;
            this.edtPayeeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeName.DvValidateEnabled = true;
            this.edtPayeeName.DvValidator = null;
            resources.ApplyResources(this.edtPayeeName, "edtPayeeName");
            this.edtPayeeName.Name = "edtPayeeName";
            // 
            // lblPayeeAccount
            // 
            resources.ApplyResources(this.lblPayeeAccount, "lblPayeeAccount");
            this.languageList1.SetDvLangId(this.lblPayeeAccount, null);
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            // 
            // lblPayeeName
            // 
            resources.ApplyResources(this.lblPayeeName, "lblPayeeName");
            this.languageList1.SetDvLangId(this.lblPayeeName, null);
            this.lblPayeeName.Name = "lblPayeeName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtPayeeSerial);
            this.groupBox1.Controls.Add(this.edtPayeeAccount);
            this.groupBox1.Controls.Add(this.edtPayeeName);
            this.groupBox1.Controls.Add(this.lblPayeeSerial);
            this.groupBox1.Controls.Add(this.lblPayeeAccount);
            this.groupBox1.Controls.Add(this.lblPayeeName);
            this.languageList1.SetDvLangId(this.groupBox1, null);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.languageList1.SetDvLangId(this.label2, null);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Name = "label2";
            // 
            // batchPagesPanel
            // 
            this.batchPagesPanel.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.batchPagesPanel, "batchPagesPanel");
            this.batchPagesPanel.Name = "batchPagesPanel";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.colSelect});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SerialNo";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Account";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "OpenBankName";
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // colSelect
            // 
            resources.ApplyResources(this.colSelect, "colSelect");
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = true;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.Text = "选择";
            this.colSelect.UseColumnTextForLinkValue = true;
            // 
            // btnReset
            // 
            this.languageList1.SetDvLangId(this.btnReset, null);
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnQuery
            // 
            this.languageList1.SetDvLangId(this.btnQuery, null);
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.languageList1.SetDvLangId(this.btnCancel, null);
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // wndPayeeQuery
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.batchPagesPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnCancel);
            this.languageList1.SetDvLangId(this, null);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wndPayeeQuery";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxCanValidate edtPayeeSerial;
        private System.Windows.Forms.Label lblPayeeSerial;
        private TextBoxCanValidate edtPayeeAccount;
        private TextBoxCanValidate edtPayeeName;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label lblPayeeName;
        private ThemedButton btnQuery;
        private ThemedButton btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private ThemedDataGridView dgv;
        private System.Windows.Forms.Label label2;
        private VisualParts.BatchPagesPanel batchPagesPanel;
        private ThemedButton btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn colSelect;
    }
}