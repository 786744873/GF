namespace BOC_BATCH_TOOL_Converter
{
    partial class MainView
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
            this.fileConverter1 = new CommonClient.VisualParts2.FileConverter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileConverter1
            // 
            this.fileConverter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.fileConverter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileConverter1.Location = new System.Drawing.Point(0, 0);
            this.fileConverter1.Name = "fileConverter1";
            this.fileConverter1.Size = new System.Drawing.Size(817, 413);
            this.fileConverter1.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileConverter1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(817, 413);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonClient.VisualParts2.FileConverter fileConverter1;
    }
}
