namespace BOC_BATCH_TOOL_FINANCIALSERVER_REIMBURSEMENT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            CommonClient.Entities.BatchReimbursement batchReimbursement1 = new CommonClient.Entities.BatchReimbursement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.batchReimbursementSelector1 = new CommonClient.VisualParts.BatchReimbursementSelector();
            this.dataOperatePanel1 = new CommonClient.VisualParts.DataOperatePanel();
            this.rowIndexPanel_BatchReimbursement = new CommonClient.VisualParts2.RowIndexPanel();
            this.snapSplitter1 = new CommonClient.Controls.SnapSplitter();
            this.fileOperatePanel1 = new CommonClient.VisualParts.FileOperatePanel();
            this.batchReimbursementItemsPanel1 = new CommonClient.VisualParts2.BatchReimbursementItemsPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(18, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 16);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作批量报销功能批量交易信息文件";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.batchReimbursementSelector1);
            this.panel3.Controls.Add(this.dataOperatePanel1);
            this.panel3.Controls.Add(this.rowIndexPanel_BatchReimbursement);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(540, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 476);
            this.panel3.TabIndex = 6;
            // 
            // batchReimbursementSelector1
            // 
            this.batchReimbursementSelector1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.batchReimbursementSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchReimbursementSelector1.Location = new System.Drawing.Point(0, 28);
            this.batchReimbursementSelector1.Name = "batchReimbursementSelector1";
            this.batchReimbursementSelector1.Reimbursement = null;
            this.batchReimbursementSelector1.Size = new System.Drawing.Size(460, 398);
            this.batchReimbursementSelector1.TabIndex = 2;
            // 
            // dataOperatePanel1
            // 
            this.dataOperatePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel1.HasLock = false;
            this.dataOperatePanel1.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel1.Name = "dataOperatePanel1";
            this.dataOperatePanel1.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel1.TabIndex = 1;
            this.dataOperatePanel1.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel1.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel1.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            // 
            // rowIndexPanel_BatchReimbursement
            // 
            this.rowIndexPanel_BatchReimbursement.AppType = CommonClient.EnumTypes.AppliableFunctionType.BatchReimbursement;
            this.rowIndexPanel_BatchReimbursement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_BatchReimbursement.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_BatchReimbursement.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_BatchReimbursement.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_BatchReimbursement.Name = "rowIndexPanel_BatchReimbursement";
            this.rowIndexPanel_BatchReimbursement.Size = new System.Drawing.Size(460, 28);
            this.rowIndexPanel_BatchReimbursement.TabIndex = 0;
            // 
            // snapSplitter1
            // 
            this.snapSplitter1.AnimationDelay = 20;
            this.snapSplitter1.AnimationStep = 20;
            this.snapSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter1.ControlToHide = this.panel3;
            this.snapSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter1.ExpandParentForm = false;
            this.snapSplitter1.Location = new System.Drawing.Point(520, 24);
            this.snapSplitter1.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter1.Name = "snapSplitter1";
            this.snapSplitter1.Size = new System.Drawing.Size(20, 476);
            this.snapSplitter1.TabIndex = 7;
            this.snapSplitter1.TabStop = false;
            // 
            // fileOperatePanel1
            // 
            this.fileOperatePanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel1.Location = new System.Drawing.Point(0, 450);
            this.fileOperatePanel1.Name = "fileOperatePanel1";
            this.fileOperatePanel1.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel1.TabIndex = 8;
            this.fileOperatePanel1.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel1.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel1.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel1.ButtonMergErrorFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergErrorFileClicked);
            this.fileOperatePanel1.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel1.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel1.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // batchReimbursementItemsPanel1
            // 
            this.batchReimbursementItemsPanel1.AppType = CommonClient.EnumTypes.AppliableFunctionType.BatchReimbursement;
            this.batchReimbursementItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            batchReimbursement1.CardNo = null;
            batchReimbursement1.ErrorReason = null;
            batchReimbursement1.PayAmount = null;
            batchReimbursement1.PayDateTime = null;
            batchReimbursement1.PayPassword = null;
            batchReimbursement1.ReimburseAmount = null;
            batchReimbursement1.RowIndex = 0;
            batchReimbursement1.Usage = null;
            this.batchReimbursementItemsPanel1.CurrentBatchReimbursement = batchReimbursement1;
            this.batchReimbursementItemsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchReimbursementItemsPanel1.Location = new System.Drawing.Point(0, 24);
            this.batchReimbursementItemsPanel1.Name = "batchReimbursementItemsPanel1";
            this.batchReimbursementItemsPanel1.Size = new System.Drawing.Size(520, 426);
            this.batchReimbursementItemsPanel1.TabIndex = 9;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.batchReimbursementItemsPanel1);
            this.Controls.Add(this.fileOperatePanel1);
            this.Controls.Add(this.snapSplitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private CommonClient.VisualParts.BatchReimbursementSelector batchReimbursementSelector1;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel1;
        private CommonClient.VisualParts2.RowIndexPanel rowIndexPanel_BatchReimbursement;
        private CommonClient.Controls.SnapSplitter snapSplitter1;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel1;
        private CommonClient.VisualParts2.BatchReimbursementItemsPanel batchReimbursementItemsPanel1;
    }
}
