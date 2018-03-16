using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_ELECTICKET_POOL
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
            this.p_ElecTicketPool = new System.Windows.Forms.Panel();
            this.elecTicketPoolItemsPanel = new CommonClient.VisualParts2.ElecTicketPoolItemsPanel();
            this.fileOperatePanel14 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter6 = new CommonClient.Controls.SnapSplitter();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.elecTicketPoolOtherPanel = new CommonClient.VisualParts2.ElecTicketPoolOtherPanel();
            this.panel37 = new System.Windows.Forms.Panel();
            this.elecTicketPoolRelateAccountSelector = new CommonClient.VisualParts2.ElecTicketPoolRelateAccountSelector();
            this.panel36 = new System.Windows.Forms.Panel();
            this.elecTicketPoolEdit = new CommonClient.VisualParts2.ElecTicketPoolEditor();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.rbElecTicketPool_Business = new System.Windows.Forms.RadioButton();
            this.rbElecTicketPool_Bank = new System.Windows.Forms.RadioButton();
            this.rowIndexPanel_Pool = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel14 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_ElecTicketPool.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel38.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_ElecTicketPool
            // 
            this.p_ElecTicketPool.Controls.Add(this.elecTicketPoolItemsPanel);
            this.p_ElecTicketPool.Controls.Add(this.fileOperatePanel14);
            this.p_ElecTicketPool.Controls.Add(this.snapSplitter6);
            this.p_ElecTicketPool.Controls.Add(this.panel15);
            this.p_ElecTicketPool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_ElecTicketPool.Location = new System.Drawing.Point(0, 24);
            this.p_ElecTicketPool.Name = "p_ElecTicketPool";
            this.p_ElecTicketPool.Size = new System.Drawing.Size(1000, 476);
            this.p_ElecTicketPool.TabIndex = 6;
            // 
            // elecTicketPoolItemsPanel
            // 
            this.elecTicketPoolItemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketPoolItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketPoolItemsPanel.ElecTicketType = CommonClient.EnumTypes.ElecTicketType.AC02;
            this.elecTicketPoolItemsPanel.Location = new System.Drawing.Point(0, 0);
            this.elecTicketPoolItemsPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.elecTicketPoolItemsPanel.Name = "elecTicketPoolItemsPanel";
            this.elecTicketPoolItemsPanel.Size = new System.Drawing.Size(480, 426);
            this.elecTicketPoolItemsPanel.TabIndex = 3;
            // 
            // fileOperatePanel14
            // 
            this.fileOperatePanel14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel14.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel14.Name = "fileOperatePanel14";
            this.fileOperatePanel14.Size = new System.Drawing.Size(480, 50);
            this.fileOperatePanel14.TabIndex = 2;
            this.fileOperatePanel14.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel14.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel14.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel14.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel14.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel14.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel14.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel14.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter6
            // 
            this.snapSplitter6.AnimationDelay = 20;
            this.snapSplitter6.AnimationStep = 20;
            this.snapSplitter6.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter6.ControlToHide = this.panel15;
            this.snapSplitter6.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter6.ExpandParentForm = false;
            this.snapSplitter6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter6.Location = new System.Drawing.Point(480, 0);
            this.snapSplitter6.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter6.Name = "snapSplitter5";
            this.snapSplitter6.TabIndex = 1;
            this.snapSplitter6.TabStop = false;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel38);
            this.panel15.Controls.Add(this.panel14);
            this.panel15.Controls.Add(this.rowIndexPanel_Pool);
            this.panel15.Controls.Add(this.dataOperatePanel14);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(500, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(500, 476);
            this.panel15.TabIndex = 0;
            // 
            // panel38
            // 
            this.panel38.AutoScroll = true;
            this.panel38.AutoScrollMinSize = new System.Drawing.Size(0, 545);
            this.panel38.Controls.Add(this.elecTicketPoolOtherPanel);
            this.panel38.Controls.Add(this.panel37);
            this.panel38.Controls.Add(this.elecTicketPoolRelateAccountSelector);
            this.panel38.Controls.Add(this.panel36);
            this.panel38.Controls.Add(this.elecTicketPoolEdit);
            this.panel38.Controls.Add(this.tableLayoutPanel13);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel38.Location = new System.Drawing.Point(0, 48);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(500, 378);
            this.panel38.TabIndex = 11;
            // 
            // elecTicketPoolOtherPanel
            // 
            this.elecTicketPoolOtherPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketPoolOtherPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketPoolOtherPanel.ElecTicketType = CommonClient.EnumTypes.ElecTicketType.AC02;
            this.elecTicketPoolOtherPanel.Location = new System.Drawing.Point(60, 464);
            this.elecTicketPoolOtherPanel.Name = "elecTicketPoolOtherPanel";
            this.elecTicketPoolOtherPanel.Size = new System.Drawing.Size(423, 81);
            this.elecTicketPoolOtherPanel.TabIndex = 19;
            // 
            // panel37
            // 
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(60, 458);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(423, 6);
            this.panel37.TabIndex = 18;
            // 
            // elecTicketPoolRelateAccountSelector
            // 
            this.elecTicketPoolRelateAccountSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketPoolRelateAccountSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.elecTicketPoolRelateAccountSelector.ElecTicketType = CommonClient.EnumTypes.ElecTicketType.AC02;
            this.elecTicketPoolRelateAccountSelector.Location = new System.Drawing.Point(60, 194);
            this.elecTicketPoolRelateAccountSelector.Name = "elecTicketPoolRelateAccountSelector";
            this.elecTicketPoolRelateAccountSelector.Size = new System.Drawing.Size(423, 264);
            this.elecTicketPoolRelateAccountSelector.TabIndex = 17;
            // 
            // panel36
            // 
            this.panel36.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel36.Location = new System.Drawing.Point(60, 188);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(423, 6);
            this.panel36.TabIndex = 16;
            // 
            // elecTicketPoolEdit
            // 
            this.elecTicketPoolEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketPoolEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.elecTicketPoolEdit.ElecTicketType = CommonClient.EnumTypes.ElecTicketType.AC02;
            this.elecTicketPoolEdit.Location = new System.Drawing.Point(60, 0);
            this.elecTicketPoolEdit.Name = "elecTicketPoolEdit";
            this.elecTicketPoolEdit.Size = new System.Drawing.Size(423, 188);
            this.elecTicketPoolEdit.TabIndex = 15;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel13.Controls.Add(this.label22, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.label23, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.label24, 0, 2);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 3;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.Size = new System.Drawing.Size(60, 545);
            this.tableLayoutPanel13.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(3, 3);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 185);
            this.label22.TabIndex = 1;
            this.label22.Text = "票据基本信息";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(3, 194);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 263);
            this.label23.TabIndex = 3;
            this.label23.Text = "票据关系人";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(3, 463);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 79);
            this.label24.TabIndex = 5;
            this.label24.Text = "其他信息";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.panel14.Controls.Add(this.rbElecTicketPool_Business);
            this.panel14.Controls.Add(this.rbElecTicketPool_Bank);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 26);
            this.panel14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(500, 22);
            this.panel14.TabIndex = 8;
            // 
            // rbElecTicketPool_Business
            // 
            this.rbElecTicketPool_Business.AutoSize = true;
            this.rbElecTicketPool_Business.Checked = true;
            this.rbElecTicketPool_Business.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbElecTicketPool_Business.Location = new System.Drawing.Point(185, 4);
            this.rbElecTicketPool_Business.Name = "rbElecTicketPool_Business";
            this.rbElecTicketPool_Business.Size = new System.Drawing.Size(49, 17);
            this.rbElecTicketPool_Business.TabIndex = 0;
            this.rbElecTicketPool_Business.TabStop = true;
            this.rbElecTicketPool_Business.Text = "商承";
            this.rbElecTicketPool_Business.UseVisualStyleBackColor = true;
            // 
            // rbElecTicketPool_Bank
            // 
            this.rbElecTicketPool_Bank.AutoSize = true;
            this.rbElecTicketPool_Bank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbElecTicketPool_Bank.Location = new System.Drawing.Point(60, 4);
            this.rbElecTicketPool_Bank.Name = "rbElecTicketPool_Bank";
            this.rbElecTicketPool_Bank.Size = new System.Drawing.Size(49, 17);
            this.rbElecTicketPool_Bank.TabIndex = 0;
            this.rbElecTicketPool_Bank.Text = "银承";
            this.rbElecTicketPool_Bank.UseVisualStyleBackColor = true;
            this.rbElecTicketPool_Bank.CheckedChanged += new System.EventHandler(this.rbElecTicketPool_CheckedChanged);
            // 
            // rowIndexPanel_Pool
            // 
            this.rowIndexPanel_Pool.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketPool;
            this.rowIndexPanel_Pool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_Pool.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_Pool.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_Pool.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_Pool.Name = "rowIndexPanel_Pool";
            this.rowIndexPanel_Pool.Size = new System.Drawing.Size(500, 26);
            this.rowIndexPanel_Pool.TabIndex = 3;
            // 
            // dataOperatePanel14
            // 
            this.dataOperatePanel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel14.HasLock = false;
            this.dataOperatePanel14.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel14.Name = "dataOperatePanel14";
            this.dataOperatePanel14.Size = new System.Drawing.Size(500, 50);
            this.dataOperatePanel14.TabIndex = 1;
            this.dataOperatePanel14.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel14.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel14.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel14.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 4;
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
            this.label1.Size = new System.Drawing.Size(379, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作票据池功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_ElecTicketPool);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_ElecTicketPool.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_ElecTicketPool;
        private ElecTicketPoolItemsPanel elecTicketPoolItemsPanel;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel14;
        private SnapSplitter snapSplitter6;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel38;
        private ElecTicketPoolOtherPanel elecTicketPoolOtherPanel;
        private System.Windows.Forms.Panel panel37;
        private ElecTicketPoolRelateAccountSelector elecTicketPoolRelateAccountSelector;
        private System.Windows.Forms.Panel panel36;
        private ElecTicketPoolEditor elecTicketPoolEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.RadioButton rbElecTicketPool_Business;
        private System.Windows.Forms.RadioButton rbElecTicketPool_Bank;
        private RowIndexPanel rowIndexPanel_Pool;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;

    }
}
