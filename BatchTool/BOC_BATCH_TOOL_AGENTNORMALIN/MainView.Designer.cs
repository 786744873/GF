using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_AGENTNORMALIN
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.p_NormalIn = new System.Windows.Forms.Panel();
            this.agentNormalPanel_In = new CommonClient.VisualParts2.AgentNormalItemsPanel();
            this.fileOperatePanel6 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter10 = new CommonClient.Controls.SnapSplitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransferInfo6 = new System.Windows.Forms.Label();
            this.rowIndexPanel_NormalIn = new CommonClient.VisualParts2.RowIndexPanel();
            this.srAgentNormalIn = new CommonClient.VisualParts2.AgentNormalEditor();
            this.dataOperatePanel6 = new CommonClient.VisualParts.DataOperatePanel();
            this.bchpnlNormalAgentIn = new CommonClient.VisualParts2.BatchAgentNormalHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_NormalIn.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_NormalIn
            // 
            this.p_NormalIn.BackColor = System.Drawing.Color.Transparent;
            this.p_NormalIn.Controls.Add(this.agentNormalPanel_In);
            this.p_NormalIn.Controls.Add(this.fileOperatePanel6);
            this.p_NormalIn.Controls.Add(this.snapSplitter10);
            this.p_NormalIn.Controls.Add(this.panel8);
            this.p_NormalIn.Controls.Add(this.bchpnlNormalAgentIn);
            this.p_NormalIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_NormalIn.Location = new System.Drawing.Point(0, 24);
            this.p_NormalIn.Name = "p_NormalIn";
            this.p_NormalIn.Size = new System.Drawing.Size(1000, 476);
            this.p_NormalIn.TabIndex = 1;
            // 
            // agentNormalPanel_In
            // 
            this.agentNormalPanel_In.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentNormalIn;
            this.agentNormalPanel_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.agentNormalPanel_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentNormalPanel_In.Location = new System.Drawing.Point(0, 90);
            this.agentNormalPanel_In.Name = "agentNormalPanel_In";
            this.agentNormalPanel_In.Size = new System.Drawing.Size(520, 336);
            this.agentNormalPanel_In.TabIndex = 3;
            // 
            // fileOperatePanel6
            // 
            this.fileOperatePanel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel6.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel6.Name = "fileOperatePanel6";
            this.fileOperatePanel6.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel6.TabIndex = 4;
            this.fileOperatePanel6.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel6.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel6.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel6.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel6.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel6.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel6.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter10
            // 
            this.snapSplitter10.AnimationDelay = 20;
            this.snapSplitter10.AnimationStep = 20;
            this.snapSplitter10.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter10.ControlToHide = this.panel8;
            this.snapSplitter10.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter10.ExpandParentForm = false;
            this.snapSplitter10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter10.Location = new System.Drawing.Point(520, 90);
            this.snapSplitter10.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter10.Name = "snapSplitter10";
            this.snapSplitter10.TabIndex = 18;
            this.snapSplitter10.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tableLayoutPanel5);
            this.panel8.Controls.Add(this.dataOperatePanel6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(540, 90);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(460, 386);
            this.panel8.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel5.Controls.Add(this.lblTransferInfo6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.rowIndexPanel_NormalIn, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.srAgentNormalIn, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(460, 336);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // lblTransferInfo6
            // 
            this.lblTransferInfo6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblTransferInfo6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTransferInfo6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTransferInfo6.Location = new System.Drawing.Point(3, 38);
            this.lblTransferInfo6.Margin = new System.Windows.Forms.Padding(3);
            this.lblTransferInfo6.Name = "lblTransferInfo6";
            this.lblTransferInfo6.Size = new System.Drawing.Size(53, 295);
            this.lblTransferInfo6.TabIndex = 0;
            this.lblTransferInfo6.Text = "笔信息";
            this.lblTransferInfo6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_NormalIn
            // 
            this.rowIndexPanel_NormalIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentNormalIn;
            this.rowIndexPanel_NormalIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel5.SetColumnSpan(this.rowIndexPanel_NormalIn, 2);
            this.rowIndexPanel_NormalIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_NormalIn.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_NormalIn.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_NormalIn.Name = "rowIndexPanel_NormalIn";
            this.rowIndexPanel_NormalIn.Size = new System.Drawing.Size(452, 27);
            this.rowIndexPanel_NormalIn.TabIndex = 1;
            // 
            // srAgentNormalIn
            // 
            this.srAgentNormalIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentNormalIn;
            this.srAgentNormalIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.srAgentNormalIn.CanAdd = false;
            this.srAgentNormalIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srAgentNormalIn.Location = new System.Drawing.Point(62, 38);
            this.srAgentNormalIn.Name = "srAgentNormalIn";
            this.srAgentNormalIn.Size = new System.Drawing.Size(395, 295);
            this.srAgentNormalIn.TabIndex = 2;
            // 
            // dataOperatePanel6
            // 
            this.dataOperatePanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel6.HasLock = false;
            this.dataOperatePanel6.Location = new System.Drawing.Point(0, 336);
            this.dataOperatePanel6.Name = "dataOperatePanel6";
            this.dataOperatePanel6.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel6.TabIndex = 2;
            this.dataOperatePanel6.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel6.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel6.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel6.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // bchpnlNormalAgentIn
            // 
            this.bchpnlNormalAgentIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentNormalIn;
            this.bchpnlNormalAgentIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.bchpnlNormalAgentIn.BatchInfo = null;
            this.bchpnlNormalAgentIn.CanAddAddition = false;
            this.bchpnlNormalAgentIn.CanAddPayer = false;
            this.bchpnlNormalAgentIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.bchpnlNormalAgentIn.IsFileConvert = false;
            this.bchpnlNormalAgentIn.Location = new System.Drawing.Point(0, 0);
            this.bchpnlNormalAgentIn.Margin = new System.Windows.Forms.Padding(4);
            this.bchpnlNormalAgentIn.Name = "bchpnlNormalAgentIn";
            this.bchpnlNormalAgentIn.Size = new System.Drawing.Size(1000, 90);
            this.bchpnlNormalAgentIn.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 19;
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
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作普通代收功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_NormalIn);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_NormalIn.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_NormalIn;
        private AgentNormalItemsPanel agentNormalPanel_In;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel6;
        private SnapSplitter snapSplitter10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblTransferInfo6;
        private RowIndexPanel rowIndexPanel_NormalIn;
        private AgentNormalEditor srAgentNormalIn;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel6;
        private BatchAgentNormalHeader bchpnlNormalAgentIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
