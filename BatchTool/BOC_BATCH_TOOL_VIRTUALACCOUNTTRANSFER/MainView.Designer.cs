using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_TRANSFER_VIRTUALACCOUNT
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
            this.p_VirtualAccountSelector = new System.Windows.Forms.Panel();
            this.virtualAccountItemsPanel1 = new CommonClient.VisualParts2.VirtualAccountItemsPanel();
            this.fileOperatePanel30 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter28 = new CommonClient.Controls.SnapSplitter();
            this.panel56 = new System.Windows.Forms.Panel();
            this.virtualAccountSelector1 = new CommonClient.VisualParts2.VirtualAccountSelector();
            this.rowIndexPanel_VirtualAccount = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel30 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_VirtualAccountSelector.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_VirtualAccountSelector
            // 
            this.p_VirtualAccountSelector.Controls.Add(this.virtualAccountItemsPanel1);
            this.p_VirtualAccountSelector.Controls.Add(this.fileOperatePanel30);
            this.p_VirtualAccountSelector.Controls.Add(this.snapSplitter28);
            this.p_VirtualAccountSelector.Controls.Add(this.panel56);
            this.p_VirtualAccountSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_VirtualAccountSelector.Location = new System.Drawing.Point(0, 24);
            this.p_VirtualAccountSelector.Name = "p_VirtualAccountSelector";
            this.p_VirtualAccountSelector.Size = new System.Drawing.Size(1000, 476);
            this.p_VirtualAccountSelector.TabIndex = 6;
            // 
            // virtualAccountItemsPanel1
            // 
            this.virtualAccountItemsPanel1.AppType = CommonClient.EnumTypes.AppliableFunctionType.VirtualAccountTransfer;
            this.virtualAccountItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.virtualAccountItemsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualAccountItemsPanel1.Location = new System.Drawing.Point(0, 0);
            this.virtualAccountItemsPanel1.Name = "virtualAccountItemsPanel1";
            this.virtualAccountItemsPanel1.Size = new System.Drawing.Size(520, 426);
            this.virtualAccountItemsPanel1.TabIndex = 7;
            // 
            // fileOperatePanel30
            // 
            this.fileOperatePanel30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel30.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel30.Name = "fileOperatePanel30";
            this.fileOperatePanel30.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel30.TabIndex = 6;
            this.fileOperatePanel30.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel30.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel30.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel30.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel30.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel30.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel30.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel30.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter28
            // 
            this.snapSplitter28.AnimationDelay = 20;
            this.snapSplitter28.AnimationStep = 20;
            this.snapSplitter28.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter28.ControlToHide = this.panel56;
            this.snapSplitter28.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter28.ExpandParentForm = false;
            this.snapSplitter28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter28.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter28.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter28.Name = "snapSplitter15";
            this.snapSplitter28.TabIndex = 5;
            this.snapSplitter28.TabStop = false;
            // 
            // panel56
            // 
            this.panel56.Controls.Add(this.virtualAccountSelector1);
            this.panel56.Controls.Add(this.rowIndexPanel_VirtualAccount);
            this.panel56.Controls.Add(this.dataOperatePanel30);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel56.Location = new System.Drawing.Point(540, 0);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(460, 476);
            this.panel56.TabIndex = 4;
            // 
            // virtualAccountSelector1
            // 
            this.virtualAccountSelector1.AppType = CommonClient.EnumTypes.AppliableFunctionType.VirtualAccountTransfer;
            this.virtualAccountSelector1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.virtualAccountSelector1.CanAddIn = false;
            this.virtualAccountSelector1.CanAddOut = false;
            this.virtualAccountSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualAccountSelector1.InitiativeAllot = null;
            this.virtualAccountSelector1.Location = new System.Drawing.Point(0, 28);
            this.virtualAccountSelector1.Name = "virtualAccountSelector1";
            this.virtualAccountSelector1.Size = new System.Drawing.Size(460, 398);
            this.virtualAccountSelector1.TabIndex = 2;
            // 
            // rowIndexPanel_VirtualAccount
            // 
            this.rowIndexPanel_VirtualAccount.AppType = CommonClient.EnumTypes.AppliableFunctionType.VirtualAccountTransfer;
            this.rowIndexPanel_VirtualAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_VirtualAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_VirtualAccount.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_VirtualAccount.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_VirtualAccount.Name = "rowIndexPanel_VirtualAccount";
            this.rowIndexPanel_VirtualAccount.Size = new System.Drawing.Size(460, 28);
            this.rowIndexPanel_VirtualAccount.TabIndex = 1;
            // 
            // dataOperatePanel30
            // 
            this.dataOperatePanel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel30.HasLock = false;
            this.dataOperatePanel30.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel30.Name = "dataOperatePanel30";
            this.dataOperatePanel30.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel30.TabIndex = 0;
            this.dataOperatePanel30.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel30.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel30.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel30.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 8;
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
            this.label1.Size = new System.Drawing.Size(389, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作内部转账功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_VirtualAccountSelector);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_VirtualAccountSelector.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_VirtualAccountSelector;
        private VirtualAccountItemsPanel virtualAccountItemsPanel1;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel30;
        private SnapSplitter snapSplitter28;
        private System.Windows.Forms.Panel panel56;
        private VirtualAccountSelector virtualAccountSelector1;
        private RowIndexPanel rowIndexPanel_VirtualAccount;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel30;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
