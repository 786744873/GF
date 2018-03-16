using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class BatchMappingItemsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchMappingItemsPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPreView = new ThemedButton();
            this.tbFileContent = new TextBoxCanValidate();
            this.label6 = new System.Windows.Forms.Label();
            this.tbStartRowIndex = new TextBoxCanValidate();
            this.tbMaxCount = new TextBoxCanValidate();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInfoType = new System.Windows.Forms.GroupBox();
            this.rbSingal = new System.Windows.Forms.RadioButton();
            this.rbBatch = new System.Windows.Forms.RadioButton();
            this.lboxFields = new System.Windows.Forms.ListBox();
            this.btnCancel = new ThemedButton();
            this.btnSetting = new ThemedButton();
            this.llTemplate = new System.Windows.Forms.LinkLabel();
            this.dgv = new ThemedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSeparator = new TextBoxCanValidate();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbInfoType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnPreView);
            this.groupBox5.Controls.Add(this.tbFileContent);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.tbStartRowIndex);
            this.groupBox5.Controls.Add(this.tbMaxCount);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.gbInfoType);
            this.groupBox5.Controls.Add(this.lboxFields);
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Controls.Add(this.btnSetting);
            this.groupBox5.Controls.Add(this.llTemplate);
            this.groupBox5.Controls.Add(this.dgv);
            this.groupBox5.Controls.Add(this.tbSeparator);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnPreView
            // 
            resources.ApplyResources(this.btnPreView, "btnPreView");
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.UseVisualStyleBackColor = false;
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // tbFileContent
            // 
            this.tbFileContent.DvEditorValueChanged = false;
            resources.ApplyResources(this.tbFileContent, "tbFileContent");
            this.tbFileContent.DvErrorProvider = errorProvider1;
            this.tbFileContent.Name = "tbFileContent";
            this.tbFileContent.DvValidateEnabled =true;
            this.tbFileContent.DvMaxLength = 0;
            this.tbFileContent.DvMinLength = 0;
            this.tbFileContent.DvRequired = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Name = "label6";
            // 
            // tbStartRowIndex
            // 
            this.tbStartRowIndex.DvEditorValueChanged = true;
            this.tbStartRowIndex.DvErrorProvider = errorProvider1;
            resources.ApplyResources(this.tbStartRowIndex, "tbStartRowIndex");
            this.tbStartRowIndex.Name = "tbStartRowIndex";
            this.tbStartRowIndex.DvValidateEnabled =true;
            this.tbStartRowIndex.DvMaxLength = 0;
            this.tbStartRowIndex.DvMinLength = 0;
            this.tbStartRowIndex.DvRequired = false;
            this.tbStartRowIndex.TextChanged += new System.EventHandler(this.tbStartRowIndex_TextChanged);
            // 
            // tbMaxCount
            // 
            this.tbMaxCount.DvEditorValueChanged = false;
            this.tbMaxCount.DvErrorProvider = errorProvider1;
            resources.ApplyResources(this.tbMaxCount, "tbMaxCount");
            this.tbMaxCount.Name = "tbMaxCount";
            this.tbMaxCount.ReadOnly = true;
            this.tbMaxCount.DvValidateEnabled =true;
            this.tbMaxCount.DvMaxLength = 0;
            this.tbMaxCount.DvMinLength = 0;
            this.tbMaxCount.DvRequired = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gbInfoType
            // 
            this.gbInfoType.Controls.Add(this.rbSingal);
            this.gbInfoType.Controls.Add(this.rbBatch);
            resources.ApplyResources(this.gbInfoType, "gbInfoType");
            this.gbInfoType.Name = "gbInfoType";
            this.gbInfoType.TabStop = false;
            // 
            // rbSingal
            // 
            resources.ApplyResources(this.rbSingal, "rbSingal");
            this.rbSingal.Name = "rbSingal";
            this.rbSingal.TabStop = true;
            this.rbSingal.UseVisualStyleBackColor = true;
            this.rbSingal.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbBatch
            // 
            resources.ApplyResources(this.rbBatch, "rbBatch");
            this.rbBatch.Name = "rbBatch";
            this.rbBatch.TabStop = true;
            this.rbBatch.UseVisualStyleBackColor = true;
            this.rbBatch.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // lboxFields
            // 
            resources.ApplyResources(this.lboxFields, "lboxFields");
            this.lboxFields.FormattingEnabled = true;
            this.lboxFields.Name = "lboxFields";
            this.lboxFields.DoubleClick += new System.EventHandler(this.lboxFields_DoubleClick);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSetting
            // 
            resources.ApplyResources(this.btnSetting, "btnSetting");
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // llTemplate
            // 
            resources.ApplyResources(this.llTemplate, "llTemplate");
            this.llTemplate.Name = "llTemplate";
            this.llTemplate.TabStop = true;
            this.llTemplate.Click += new System.EventHandler(this.llTemplate_Click);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Value";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // tbSeparator
            // 
            this.tbSeparator.DvEditorValueChanged = false;
            this.tbSeparator.DvErrorProvider = errorProvider1;
            resources.ApplyResources(this.tbSeparator, "tbSeparator");
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.DvValidateEnabled =true;
            this.tbSeparator.DvMaxLength = 0;
            this.tbSeparator.DvMinLength = 0;
            this.tbSeparator.DvRequired = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // BatchMappingItemsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Name = "BatchMappingItemsPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbInfoType.ResumeLayout(false);
            this.gbInfoType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private ThemedButton btnPreView;
        private TextBoxCanValidate tbFileContent;
        private TextBoxCanValidate tbMaxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInfoType;
        private System.Windows.Forms.RadioButton rbSingal;
        private System.Windows.Forms.RadioButton rbBatch;
        private System.Windows.Forms.ListBox lboxFields;
        private ThemedButton btnCancel;
        private ThemedButton btnSetting;
        private System.Windows.Forms.LinkLabel llTemplate;
        private ThemedDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private TextBoxCanValidate tbSeparator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private TextBoxCanValidate tbStartRowIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
