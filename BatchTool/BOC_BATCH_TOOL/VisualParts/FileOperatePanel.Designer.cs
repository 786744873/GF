using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualParts
{
    partial class FileOperatePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOperatePanel));
            this.btnOpen = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnNew = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnMergError = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnImportFromFile = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnSaveAs = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnSave = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnPrint = new BOC_BATCH_TOOL.Controls.ThemedButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnMergError
            // 
            resources.ApplyResources(this.btnMergError, "btnMergError");
            this.btnMergError.Name = "btnMergError";
            this.btnMergError.UseVisualStyleBackColor = true;
            this.btnMergError.Click += new System.EventHandler(this.btnMergError_Click);
            this.btnMergError.MouseHover += new System.EventHandler(this.btnMergError_MouseHover);
            // 
            // btnImportFromFile
            // 
            resources.ApplyResources(this.btnImportFromFile, "btnImportFromFile");
            this.btnImportFromFile.Name = "btnImportFromFile";
            this.btnImportFromFile.UseVisualStyleBackColor = true;
            this.btnImportFromFile.Click += new System.EventHandler(this.btnImportFromFile_Click);
            this.btnImportFromFile.MouseHover += new System.EventHandler(this.btnImportFromFile_MouseHover);
            // 
            // btnSaveAs
            // 
            resources.ApplyResources(this.btnSaveAs, "btnSaveAs");
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseHover += new System.EventHandler(this.btnMergError_MouseHover);
            // 
            // FileOperatePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnMergError);
            this.Controls.Add(this.btnImportFromFile);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnSave);
            this.Name = "FileOperatePanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ThemedButton btnOpen;
        private ThemedButton btnNew;
        private ThemedButton btnMergError;
        private ThemedButton btnImportFromFile;
        private ThemedButton btnSaveAs;
        private ThemedButton btnSave;
        private ThemedButton btnPrint;
    }
}
