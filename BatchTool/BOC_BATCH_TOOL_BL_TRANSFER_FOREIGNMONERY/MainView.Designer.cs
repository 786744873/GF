using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_BL_TRANSFER_FOREIGNMONERY
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
            this.p_TransferForeignMoney_Bar = new System.Windows.Forms.Panel();
            this.transferGlobalItemsPanel_ForeignMoneyBar = new CommonClient.VisualParts2.TransferGlobalItemsPanel();
            this.fileOperatePanel27 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter25 = new CommonClient.Controls.SnapSplitter();
            this.panel47 = new System.Windows.Forms.Panel();
            this.panel48 = new System.Windows.Forms.Panel();
            this.transferGlobalOtherSelector_ForeignMoneyBar = new CommonClient.VisualParts2.TransferGlobalOtherSelector();
            this.panel49 = new System.Windows.Forms.Panel();
            this.transferGlobalPayeeSelector_ForeignMoneyBar = new CommonClient.VisualParts2.TransferGlobalPayeeSelector();
            this.panel50 = new System.Windows.Forms.Panel();
            this.transferGlobalRemitSelector_ForeignMoneyBar = new CommonClient.VisualParts2.TransferGlobalRemitSelector();
            this.panel51 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.rowIndexPanel_ForeignMoneyBar = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel27 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_TransferForeignMoney_Bar.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel48.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_TransferForeignMoney_Bar
            // 
            this.p_TransferForeignMoney_Bar.Controls.Add(this.transferGlobalItemsPanel_ForeignMoneyBar);
            this.p_TransferForeignMoney_Bar.Controls.Add(this.fileOperatePanel27);
            this.p_TransferForeignMoney_Bar.Controls.Add(this.snapSplitter25);
            this.p_TransferForeignMoney_Bar.Controls.Add(this.panel47);
            this.p_TransferForeignMoney_Bar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_TransferForeignMoney_Bar.Location = new System.Drawing.Point(0, 24);
            this.p_TransferForeignMoney_Bar.Name = "p_TransferForeignMoney_Bar";
            this.p_TransferForeignMoney_Bar.Size = new System.Drawing.Size(1000, 476);
            this.p_TransferForeignMoney_Bar.TabIndex = 7;
            // 
            // transferGlobalItemsPanel_ForeignMoneyBar
            // 
            this.transferGlobalItemsPanel_ForeignMoneyBar.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferForeignMoney4Bar;
            this.transferGlobalItemsPanel_ForeignMoneyBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalItemsPanel_ForeignMoneyBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferGlobalItemsPanel_ForeignMoneyBar.Location = new System.Drawing.Point(0, 0);
            this.transferGlobalItemsPanel_ForeignMoneyBar.Name = "transferGlobalItemsPanel_ForeignMoneyBar";
            this.transferGlobalItemsPanel_ForeignMoneyBar.Size = new System.Drawing.Size(440, 426);
            this.transferGlobalItemsPanel_ForeignMoneyBar.TabIndex = 3;
            // 
            // fileOperatePanel27
            // 
            this.fileOperatePanel27.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel27.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel27.Name = "fileOperatePanel27";
            this.fileOperatePanel27.Size = new System.Drawing.Size(440, 50);
            this.fileOperatePanel27.TabIndex = 2;
            this.fileOperatePanel27.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel27.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel27.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel27.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel27.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel27.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel27.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel27.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter25
            // 
            this.snapSplitter25.AnimationDelay = 20;
            this.snapSplitter25.AnimationStep = 20;
            this.snapSplitter25.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter25.ControlToHide = this.panel47;
            this.snapSplitter25.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter25.ExpandParentForm = false;
            this.snapSplitter25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter25.Location = new System.Drawing.Point(440, 0);
            this.snapSplitter25.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter25.Name = "snapSplitter13";
            this.snapSplitter25.TabIndex = 1;
            this.snapSplitter25.TabStop = false;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.panel48);
            this.panel47.Controls.Add(this.rowIndexPanel_ForeignMoneyBar);
            this.panel47.Controls.Add(this.dataOperatePanel27);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel47.Location = new System.Drawing.Point(460, 0);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(540, 476);
            this.panel47.TabIndex = 0;
            // 
            // panel48
            // 
            this.panel48.AutoScroll = true;
            this.panel48.AutoScrollMinSize = new System.Drawing.Size(0, 900);
            this.panel48.Controls.Add(this.transferGlobalOtherSelector_ForeignMoneyBar);
            this.panel48.Controls.Add(this.panel49);
            this.panel48.Controls.Add(this.transferGlobalPayeeSelector_ForeignMoneyBar);
            this.panel48.Controls.Add(this.panel50);
            this.panel48.Controls.Add(this.transferGlobalRemitSelector_ForeignMoneyBar);
            this.panel48.Controls.Add(this.panel51);
            this.panel48.Controls.Add(this.tableLayoutPanel17);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel48.Location = new System.Drawing.Point(0, 28);
            this.panel48.Margin = new System.Windows.Forms.Padding(0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(3);
            this.panel48.Size = new System.Drawing.Size(540, 398);
            this.panel48.TabIndex = 2;
            // 
            // transferGlobalOtherSelector_ForeignMoneyBar
            // 
            this.transferGlobalOtherSelector_ForeignMoneyBar._UnitivePaymentForeignMoney = null;
            this.transferGlobalOtherSelector_ForeignMoneyBar.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferForeignMoney4Bar;
            this.transferGlobalOtherSelector_ForeignMoneyBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalOtherSelector_ForeignMoneyBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferGlobalOtherSelector_ForeignMoneyBar.Location = new System.Drawing.Point(33, 561);
            this.transferGlobalOtherSelector_ForeignMoneyBar.Name = "transferGlobalOtherSelector_ForeignMoneyBar";
            this.transferGlobalOtherSelector_ForeignMoneyBar.SaveRemitNote = false;
            this.transferGlobalOtherSelector_ForeignMoneyBar.Size = new System.Drawing.Size(487, 336);
            this.transferGlobalOtherSelector_ForeignMoneyBar.TabIndex = 11;
            this.transferGlobalOtherSelector_ForeignMoneyBar.TransferGlobal = null;
            // 
            // panel49
            // 
            this.panel49.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel49.Location = new System.Drawing.Point(33, 554);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(487, 7);
            this.panel49.TabIndex = 10;
            // 
            // transferGlobalPayeeSelector_ForeignMoneyBar
            // 
            this.transferGlobalPayeeSelector_ForeignMoneyBar._UnitivePaymentForeignMoney = null;
            this.transferGlobalPayeeSelector_ForeignMoneyBar.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferForeignMoney4Bar;
            this.transferGlobalPayeeSelector_ForeignMoneyBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalPayeeSelector_ForeignMoneyBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.transferGlobalPayeeSelector_ForeignMoneyBar.Location = new System.Drawing.Point(33, 224);
            this.transferGlobalPayeeSelector_ForeignMoneyBar.Name = "transferGlobalPayeeSelector_ForeignMoneyBar";
            this.transferGlobalPayeeSelector_ForeignMoneyBar.Size = new System.Drawing.Size(487, 330);
            this.transferGlobalPayeeSelector_ForeignMoneyBar.TabIndex = 9;
            this.transferGlobalPayeeSelector_ForeignMoneyBar.TransferGlobal = null;
            // 
            // panel50
            // 
            this.panel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel50.Location = new System.Drawing.Point(33, 218);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(487, 6);
            this.panel50.TabIndex = 8;
            // 
            // transferGlobalRemitSelector_ForeignMoneyBar
            // 
            this.transferGlobalRemitSelector_ForeignMoneyBar.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferForeignMoney4Bar;
            this.transferGlobalRemitSelector_ForeignMoneyBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalRemitSelector_ForeignMoneyBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.transferGlobalRemitSelector_ForeignMoneyBar.Location = new System.Drawing.Point(33, 6);
            this.transferGlobalRemitSelector_ForeignMoneyBar.Margin = new System.Windows.Forms.Padding(6);
            this.transferGlobalRemitSelector_ForeignMoneyBar.Name = "transferGlobalRemitSelector_ForeignMoneyBar";
            this.transferGlobalRemitSelector_ForeignMoneyBar.Size = new System.Drawing.Size(487, 212);
            this.transferGlobalRemitSelector_ForeignMoneyBar.TabIndex = 7;
            this.transferGlobalRemitSelector_ForeignMoneyBar.TransferGlobal = null;
            // 
            // panel51
            // 
            this.panel51.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel51.Location = new System.Drawing.Point(33, 3);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(487, 3);
            this.panel51.TabIndex = 3;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(this.label36, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.label37, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.label38, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 3;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 336F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 334F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(30, 894);
            this.tableLayoutPanel17.TabIndex = 1;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(3, 557);
            this.label36.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 337);
            this.label36.TabIndex = 4;
            this.label36.Text = "其他信息";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(3, 221);
            this.label37.Margin = new System.Windows.Forms.Padding(3);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(24, 330);
            this.label37.TabIndex = 2;
            this.label37.Text = "收款人信息";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(3, 3);
            this.label38.Margin = new System.Windows.Forms.Padding(3);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(24, 212);
            this.label38.TabIndex = 0;
            this.label38.Text = "汇款信息";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_ForeignMoneyBar
            // 
            this.rowIndexPanel_ForeignMoneyBar.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferForeignMoney4Bar;
            this.rowIndexPanel_ForeignMoneyBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_ForeignMoneyBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_ForeignMoneyBar.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_ForeignMoneyBar.Margin = new System.Windows.Forms.Padding(6);
            this.rowIndexPanel_ForeignMoneyBar.Name = "rowIndexPanel_ForeignMoneyBar";
            this.rowIndexPanel_ForeignMoneyBar.Size = new System.Drawing.Size(540, 28);
            this.rowIndexPanel_ForeignMoneyBar.TabIndex = 1;
            // 
            // dataOperatePanel27
            // 
            this.dataOperatePanel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel27.HasLock = false;
            this.dataOperatePanel27.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel27.Name = "dataOperatePanel27";
            this.dataOperatePanel27.Size = new System.Drawing.Size(540, 50);
            this.dataOperatePanel27.TabIndex = 0;
            this.dataOperatePanel27.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel27.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel27.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel27.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
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
            this.label1.Size = new System.Drawing.Size(415, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作境内外币汇划功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_TransferForeignMoney_Bar);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_TransferForeignMoney_Bar.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_TransferForeignMoney_Bar;
        private TransferGlobalItemsPanel transferGlobalItemsPanel_ForeignMoneyBar;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel27;
        private SnapSplitter snapSplitter25;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Panel panel48;
        private TransferGlobalOtherSelector transferGlobalOtherSelector_ForeignMoneyBar;
        private System.Windows.Forms.Panel panel49;
        private TransferGlobalPayeeSelector transferGlobalPayeeSelector_ForeignMoneyBar;
        private System.Windows.Forms.Panel panel50;
        private TransferGlobalRemitSelector transferGlobalRemitSelector_ForeignMoneyBar;
        private System.Windows.Forms.Panel panel51;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private RowIndexPanel rowIndexPanel_ForeignMoneyBar;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel27;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
