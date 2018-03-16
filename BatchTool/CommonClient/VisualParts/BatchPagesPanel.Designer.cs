using CommonClient.Controls;

namespace CommonClient.VisualParts
{
    partial class BatchPagesPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchPagesPanel));
            this.btnGoto = new ThemedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPageNo = new TextBoxCanValidate();
            this.label2 = new System.Windows.Forms.Label();
            this.llNext = new System.Windows.Forms.LinkLabel();
            this.llPre = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbtotlecount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            resources.ApplyResources(this.errorProvider1, "errorProvider1");
            // 
            // btnGoto
            // 
            resources.ApplyResources(this.btnGoto, "btnGoto");
            this.errorProvider1.SetError(this.btnGoto, resources.GetString("btnGoto.Error"));
            this.errorProvider1.SetIconAlignment(this.btnGoto, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnGoto.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnGoto, ((int)(resources.GetObject("btnGoto.IconPadding"))));
            this.btnGoto.Name = "btnGoto";
            this.toolTip1.SetToolTip(this.btnGoto, resources.GetString("btnGoto.ToolTip"));
            this.btnGoto.UseVisualStyleBackColor = false;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
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
            // tbPageNo
            // 
            resources.ApplyResources(this.tbPageNo, "tbPageNo");
            this.tbPageNo.DvEditorValueChanged = false;
            this.errorProvider1.SetError(this.tbPageNo, resources.GetString("tbPageNo.Error"));
            this.tbPageNo.DvErrorProvider = errorProvider1;
            this.errorProvider1.SetIconAlignment(this.tbPageNo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbPageNo.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbPageNo, ((int)(resources.GetObject("tbPageNo.IconPadding"))));
            this.tbPageNo.Name = "tbPageNo";
            this.toolTip1.SetToolTip(this.tbPageNo, resources.GetString("tbPageNo.ToolTip"));
            this.tbPageNo.DvValidateEnabled =true;
            this.tbPageNo.DvMaxLength = 0;
            this.tbPageNo.DvMinLength = 0;
            this.tbPageNo.DvRequired = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider1.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider1.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // llNext
            // 
            resources.ApplyResources(this.llNext, "llNext");
            this.errorProvider1.SetError(this.llNext, resources.GetString("llNext.Error"));
            this.errorProvider1.SetIconAlignment(this.llNext, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("llNext.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.llNext, ((int)(resources.GetObject("llNext.IconPadding"))));
            this.llNext.Name = "llNext";
            this.llNext.TabStop = true;
            this.toolTip1.SetToolTip(this.llNext, resources.GetString("llNext.ToolTip"));
            this.llNext.Click += new System.EventHandler(this.ll_Click);
            // 
            // llPre
            // 
            resources.ApplyResources(this.llPre, "llPre");
            this.errorProvider1.SetError(this.llPre, resources.GetString("llPre.Error"));
            this.errorProvider1.SetIconAlignment(this.llPre, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("llPre.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.llPre, ((int)(resources.GetObject("llPre.IconPadding"))));
            this.llPre.Name = "llPre";
            this.llPre.TabStop = true;
            this.toolTip1.SetToolTip(this.llPre, resources.GetString("llPre.ToolTip"));
            this.llPre.Click += new System.EventHandler(this.ll_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider1.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider1.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // lbtotlecount
            // 
            resources.ApplyResources(this.lbtotlecount, "lbtotlecount");
            this.errorProvider1.SetError(this.lbtotlecount, resources.GetString("lbtotlecount.Error"));
            this.errorProvider1.SetIconAlignment(this.lbtotlecount, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lbtotlecount.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.lbtotlecount, ((int)(resources.GetObject("lbtotlecount.IconPadding"))));
            this.lbtotlecount.Name = "lbtotlecount";
            this.toolTip1.SetToolTip(this.lbtotlecount, resources.GetString("lbtotlecount.ToolTip"));
            // 
            // BatchPagesPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbtotlecount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.llPre);
            this.Controls.Add(this.llNext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPageNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoto);
            this.errorProvider1.SetError(this, resources.GetString("$this.Error"));
            this.errorProvider1.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.Name = "BatchPagesPanel";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThemedButton btnGoto;
        private System.Windows.Forms.Label label1;
        private TextBoxCanValidate tbPageNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llNext;
        private System.Windows.Forms.LinkLabel llPre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbtotlecount;
    }
}
