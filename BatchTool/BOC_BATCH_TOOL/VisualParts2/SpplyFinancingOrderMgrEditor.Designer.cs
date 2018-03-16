namespace BOC_BATCH_TOOL.VisualParts
{
    partial class SpplyFinancingOrderMgrEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpplyFinancingOrderMgrEditor));
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbAmount = new System.Windows.Forms.Label();
            this.tbOrderNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbOrderNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Name = "label11";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // tbAmount
            // 
            this.tbAmount.EditorValueChanged = false;
            this.tbAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbAmount, "tbAmount");
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.ValidateEnabled = true;
            this.tbAmount.ValidateRule.MaxLength = 0;
            this.tbAmount.ValidateRule.MinLength = 0;
            this.tbAmount.ValidateRule.RegexValue = null;
            this.tbAmount.ValidateRule.Required = true;
            // 
            // lbAmount
            // 
            resources.ApplyResources(this.lbAmount, "lbAmount");
            this.lbAmount.Name = "lbAmount";
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.EditorValueChanged = false;
            this.tbOrderNo.ErrorProvider = null;
            resources.ApplyResources(this.tbOrderNo, "tbOrderNo");
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.ValidateEnabled = true;
            this.tbOrderNo.ValidateRule.MaxLength = 0;
            this.tbOrderNo.ValidateRule.MinLength = 0;
            this.tbOrderNo.ValidateRule.RegexValue = null;
            this.tbOrderNo.ValidateRule.Required = true;
            // 
            // lbOrderNo
            // 
            resources.ApplyResources(this.lbOrderNo, "lbOrderNo");
            this.lbOrderNo.Name = "lbOrderNo";
            // 
            // SpplyFinancingOrderMgrEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.tbOrderNo);
            this.Controls.Add(this.lbOrderNo);
            this.Name = "SpplyFinancingOrderMgrEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbAmount;
        private System.Windows.Forms.Label lbAmount;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbOrderNo;
        private System.Windows.Forms.Label lbOrderNo;
    }
}
