using System;
using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_AGENTEXPRESSIN
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
        [STAThread]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.bchpnlFastAgentIn = new CommonClient.VisualParts2.BatchAgentExpressHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransferInfo4 = new System.Windows.Forms.Label();
            this.rowIndexPanel_ExpressIn = new CommonClient.VisualParts2.RowIndexPanel();
            this.srAgentExpressIn = new CommonClient.VisualParts2.AgentExpressEditor();
            this.dataOperatePanel1 = new CommonClient.VisualParts.DataOperatePanel();
            this.snapSplitter1 = new CommonClient.Controls.SnapSplitter();
            this.agentExpressPanel_In = new CommonClient.VisualParts2.AgentExpressItemsPanel();
            this.fileOperatePanel1 = new CommonClient.VisualParts.FileOperatePanel();
            this.p_ExpressIn = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.p_ExpressIn.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bchpnlFastAgentIn
            // 
            this.bchpnlFastAgentIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentExpressIn;
            this.bchpnlFastAgentIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.bchpnlFastAgentIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.bchpnlFastAgentIn.IsFileConvert = false;
            this.bchpnlFastAgentIn.Location = new System.Drawing.Point(0, 0);
            this.bchpnlFastAgentIn.Margin = new System.Windows.Forms.Padding(5);
            this.bchpnlFastAgentIn.Name = "bchpnlFastAgentIn";
            this.bchpnlFastAgentIn.Size = new System.Drawing.Size(1000, 109);
            this.bchpnlFastAgentIn.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.dataOperatePanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(540, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 409);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel2.Controls.Add(this.lblTransferInfo4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.rowIndexPanel_ExpressIn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.srAgentExpressIn, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(460, 355);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lblTransferInfo4
            // 
            this.lblTransferInfo4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblTransferInfo4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTransferInfo4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTransferInfo4.Location = new System.Drawing.Point(3, 41);
            this.lblTransferInfo4.Margin = new System.Windows.Forms.Padding(3);
            this.lblTransferInfo4.Name = "lblTransferInfo4";
            this.lblTransferInfo4.Size = new System.Drawing.Size(53, 311);
            this.lblTransferInfo4.TabIndex = 1;
            this.lblTransferInfo4.Text = "笔信息";
            this.lblTransferInfo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_ExpressIn
            // 
            this.rowIndexPanel_ExpressIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentExpressIn;
            this.rowIndexPanel_ExpressIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel2.SetColumnSpan(this.rowIndexPanel_ExpressIn, 2);
            this.rowIndexPanel_ExpressIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_ExpressIn.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_ExpressIn.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_ExpressIn.Name = "rowIndexPanel_ExpressIn";
            this.rowIndexPanel_ExpressIn.Size = new System.Drawing.Size(452, 30);
            this.rowIndexPanel_ExpressIn.TabIndex = 0;
            // 
            // srAgentExpressIn
            // 
            this.srAgentExpressIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentExpressIn;
            this.srAgentExpressIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.srAgentExpressIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srAgentExpressIn.Location = new System.Drawing.Point(62, 41);
            this.srAgentExpressIn.Name = "srAgentExpressIn";
            this.srAgentExpressIn.Size = new System.Drawing.Size(395, 311);
            this.srAgentExpressIn.TabIndex = 2;
            // 
            // dataOperatePanel1
            // 
            this.dataOperatePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel1.HasLock = false;
            this.dataOperatePanel1.Location = new System.Drawing.Point(0, 355);
            this.dataOperatePanel1.Name = "dataOperatePanel1";
            this.dataOperatePanel1.Size = new System.Drawing.Size(460, 54);
            this.dataOperatePanel1.TabIndex = 0;
            this.dataOperatePanel1.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel1.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel1.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel1.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // snapSplitter1
            // 
            this.snapSplitter1.AnimationDelay = 20;
            this.snapSplitter1.AnimationStep = 20;
            this.snapSplitter1.BackColor = System.Drawing.SystemColors.Control;
            this.snapSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter1.ControlToHide = this.panel1;
            this.snapSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter1.ExpandParentForm = false;
            this.snapSplitter1.Location = new System.Drawing.Point(520, 109);
            this.snapSplitter1.MinimumSize = new System.Drawing.Size(20, 22);
            this.snapSplitter1.Name = "snapSplitter1";
            this.snapSplitter1.TabIndex = 8;
            this.snapSplitter1.TabStop = false;
            // 
            // agentExpressPanel_In
            // 
            this.agentExpressPanel_In.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentExpressIn;
            this.agentExpressPanel_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.agentExpressPanel_In.CurrentAgentExpress = null;
            this.agentExpressPanel_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentExpressPanel_In.Location = new System.Drawing.Point(0, 109);
            this.agentExpressPanel_In.Name = "agentExpressPanel_In";
            this.agentExpressPanel_In.Size = new System.Drawing.Size(520, 355);
            this.agentExpressPanel_In.TabIndex = 9;
            // 
            // fileOperatePanel1
            // 
            this.fileOperatePanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel1.Location = new System.Drawing.Point(0, 464);
            this.fileOperatePanel1.Name = "fileOperatePanel1";
            this.fileOperatePanel1.Size = new System.Drawing.Size(520, 54);
            this.fileOperatePanel1.TabIndex = 10;
            this.fileOperatePanel1.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel1.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel1.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel1.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel1.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel1.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel1.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel1.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // p_ExpressIn
            // 
            this.p_ExpressIn.Controls.Add(this.agentExpressPanel_In);
            this.p_ExpressIn.Controls.Add(this.fileOperatePanel1);
            this.p_ExpressIn.Controls.Add(this.snapSplitter1);
            this.p_ExpressIn.Controls.Add(this.panel1);
            this.p_ExpressIn.Controls.Add(this.bchpnlFastAgentIn);
            this.p_ExpressIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_ExpressIn.Location = new System.Drawing.Point(0, 24);
            this.p_ExpressIn.Name = "p_ExpressIn";
            this.p_ExpressIn.Size = new System.Drawing.Size(1000, 518);
            this.p_ExpressIn.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 24);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(18, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(16, 16);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作快捷代收功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.p_ExpressIn);
            this.Controls.Add(this.panel2);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 542);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.p_ExpressIn.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BatchAgentExpressHeader bchpnlFastAgentIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTransferInfo4;
        private RowIndexPanel rowIndexPanel_ExpressIn;
        private AgentExpressEditor srAgentExpressIn;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel1;
        private SnapSplitter snapSplitter1;
        private AgentExpressItemsPanel agentExpressPanel_In;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel1;
        private System.Windows.Forms.Panel p_ExpressIn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;

    }
}
