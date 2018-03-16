using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualParts
{
    partial class RowIndexPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowIndexPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRowIndex = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.btnQuery = new BOC_BATCH_TOOL.Controls.ThemedButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            resources.ApplyResources(this.errorProvider1, "errorProvider1");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider1.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider1.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // txtRowIndex
            // 
            resources.ApplyResources(this.txtRowIndex, "txtRowIndex");
            this.txtRowIndex.EditorValueChanged = false;
            this.errorProvider1.SetError(this.txtRowIndex, resources.GetString("txtRowIndex.Error"));
            this.txtRowIndex.ErrorProvider = null;
            this.errorProvider1.SetIconAlignment(this.txtRowIndex, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtRowIndex.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.txtRowIndex, ((int)(resources.GetObject("txtRowIndex.IconPadding"))));
            this.txtRowIndex.Name = "txtRowIndex";
            this.toolTip1.SetToolTip(this.txtRowIndex, resources.GetString("txtRowIndex.ToolTip"));
            this.txtRowIndex.ValidateEnabled = false;
            this.txtRowIndex.ValidateRule.MaxLength = 0;
            this.txtRowIndex.ValidateRule.MinLength = 0;
            this.txtRowIndex.ValidateRule.RegexValue = null;
            this.txtRowIndex.ValidateRule.Required = false;
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.errorProvider1.SetError(this.btnQuery, resources.GetString("btnQuery.Error"));
            this.errorProvider1.SetIconAlignment(this.btnQuery, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnQuery.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnQuery, ((int)(resources.GetObject("btnQuery.IconPadding"))));
            this.btnQuery.Name = "btnQuery";
            this.toolTip1.SetToolTip(this.btnQuery, resources.GetString("btnQuery.ToolTip"));
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // RowIndexPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtRowIndex);
            this.Controls.Add(this.label1);
            this.errorProvider1.SetError(this, resources.GetString("$this.Error"));
            this.errorProvider1.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.Name = "RowIndexPanel";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate txtRowIndex;
        private ThemedButton btnQuery;
    }
}
