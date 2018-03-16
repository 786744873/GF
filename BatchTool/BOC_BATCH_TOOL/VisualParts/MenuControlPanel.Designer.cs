using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualParts
{
    partial class MenuControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuControlPanel));
            this.menuListPanel1 = new BOC_BATCH_TOOL.VisualParts.MenuListPanel();
            this.pCBack = new System.Windows.Forms.Panel();
            this.pBack = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pCPre = new System.Windows.Forms.Panel();
            this.pPre = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pCBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pCPre.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuListPanel1
            // 
            resources.ApplyResources(this.menuListPanel1, "menuListPanel1");
            this.menuListPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuListPanel1.Name = "menuListPanel1";
            // 
            // pCBack
            // 
            resources.ApplyResources(this.pCBack, "pCBack");
            this.pCBack.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.middlebg;
            this.pCBack.Controls.Add(this.pBack);
            this.pCBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pCBack.Name = "pCBack";
            this.pCBack.Click += new System.EventHandler(this.pBack_Click);
            // 
            // pBack
            // 
            this.pBack.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.grayright;
            resources.ApplyResources(this.pBack, "pBack");
            this.pBack.Name = "pBack";
            this.pBack.Click += new System.EventHandler(this.pBack_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.settingred;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.InitialImage = global::BOC_BATCH_TOOL.Properties.Resources.settingred;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // pCPre
            // 
            resources.ApplyResources(this.pCPre, "pCPre");
            this.pCPre.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.middlebg;
            this.pCPre.Controls.Add(this.pPre);
            this.pCPre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pCPre.Name = "pCPre";
            this.pCPre.Click += new System.EventHandler(this.pPre_Click);
            // 
            // pPre
            // 
            this.pPre.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.grayleft;
            resources.ApplyResources(this.pPre, "pPre");
            this.pPre.Name = "pPre";
            this.pPre.Click += new System.EventHandler(this.pPre_Click);
            // 
            // MenuControlPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.menuListPanel1);
            this.Controls.Add(this.pCPre);
            this.Controls.Add(this.pCBack);
            this.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this, "$this");
            this.Name = "MenuControlPanel";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pCBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pCPre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MenuListPanel menuListPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pCBack;
        private System.Windows.Forms.Panel pBack;
        private System.Windows.Forms.Panel pCPre;
        private System.Windows.Forms.Panel pPre;
    }
}
