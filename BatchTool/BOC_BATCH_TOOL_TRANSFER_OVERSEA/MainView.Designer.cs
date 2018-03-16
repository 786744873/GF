using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_TRANSFER_OVERSEA
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
            this.p_TransferOverCountry = new System.Windows.Forms.Panel();
            this.transferGlobalItemsPanel_Country = new CommonClient.VisualParts2.TransferGlobalItemsPanel();
            this.fileOperatePanel15 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter13 = new CommonClient.Controls.SnapSplitter();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.transferGlobalOtherEditor_OverCountry = new CommonClient.VisualParts2.TransferGlobalOtherSelector();
            this.panel23 = new System.Windows.Forms.Panel();
            this.transferGlobalPayeeEditor_OverCountry = new CommonClient.VisualParts2.TransferGlobalPayeeSelector();
            this.panel24 = new System.Windows.Forms.Panel();
            this.transferGlobalRemitEditor_OverCountry = new CommonClient.VisualParts2.TransferGlobalRemitSelector();
            this.panel25 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.rowIndexPanel_OverCountry = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel15 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_TransferOverCountry.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_TransferOverCountry
            // 
            this.p_TransferOverCountry.Controls.Add(this.transferGlobalItemsPanel_Country);
            this.p_TransferOverCountry.Controls.Add(this.fileOperatePanel15);
            this.p_TransferOverCountry.Controls.Add(this.snapSplitter13);
            this.p_TransferOverCountry.Controls.Add(this.panel16);
            this.p_TransferOverCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_TransferOverCountry.Location = new System.Drawing.Point(0, 24);
            this.p_TransferOverCountry.Name = "p_TransferOverCountry";
            this.p_TransferOverCountry.Size = new System.Drawing.Size(1000, 476);
            this.p_TransferOverCountry.TabIndex = 5;
            // 
            // transferGlobalItemsPanel_Country
            // 
            this.transferGlobalItemsPanel_Country.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverCountry;
            this.transferGlobalItemsPanel_Country.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalItemsPanel_Country.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferGlobalItemsPanel_Country.Location = new System.Drawing.Point(0, 0);
            this.transferGlobalItemsPanel_Country.Name = "transferGlobalItemsPanel_Country";
            this.transferGlobalItemsPanel_Country.Size = new System.Drawing.Size(440, 426);
            this.transferGlobalItemsPanel_Country.TabIndex = 3;
            // 
            // fileOperatePanel15
            // 
            this.fileOperatePanel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel15.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel15.Name = "fileOperatePanel15";
            this.fileOperatePanel15.Size = new System.Drawing.Size(440, 50);
            this.fileOperatePanel15.TabIndex = 2;
            this.fileOperatePanel15.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel15.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel15.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel15.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel15.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel15.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel15.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel15.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter13
            // 
            this.snapSplitter13.AnimationDelay = 20;
            this.snapSplitter13.AnimationStep = 20;
            this.snapSplitter13.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter13.ControlToHide = this.panel16;
            this.snapSplitter13.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter13.ExpandParentForm = false;
            this.snapSplitter13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter13.Location = new System.Drawing.Point(440, 0);
            this.snapSplitter13.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter13.Name = "snapSplitter13";
            this.snapSplitter13.TabIndex = 1;
            this.snapSplitter13.TabStop = false;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.rowIndexPanel_OverCountry);
            this.panel16.Controls.Add(this.dataOperatePanel15);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel16.Location = new System.Drawing.Point(460, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(540, 476);
            this.panel16.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.AutoScroll = true;
            this.panel17.AutoScrollMinSize = new System.Drawing.Size(0, 950);
            this.panel17.Controls.Add(this.transferGlobalOtherEditor_OverCountry);
            this.panel17.Controls.Add(this.panel23);
            this.panel17.Controls.Add(this.transferGlobalPayeeEditor_OverCountry);
            this.panel17.Controls.Add(this.panel24);
            this.panel17.Controls.Add(this.transferGlobalRemitEditor_OverCountry);
            this.panel17.Controls.Add(this.panel25);
            this.panel17.Controls.Add(this.tableLayoutPanel15);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 28);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(3);
            this.panel17.Size = new System.Drawing.Size(540, 398);
            this.panel17.TabIndex = 2;
            // 
            // transferGlobalOtherEditor_OverCountry
            // 
            this.transferGlobalOtherEditor_OverCountry._UnitivePaymentForeignMoney = null;
            this.transferGlobalOtherEditor_OverCountry.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverCountry;
            this.transferGlobalOtherEditor_OverCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalOtherEditor_OverCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferGlobalOtherEditor_OverCountry.Location = new System.Drawing.Point(33, 611);
            this.transferGlobalOtherEditor_OverCountry.Name = "transferGlobalOtherEditor_OverCountry";
            this.transferGlobalOtherEditor_OverCountry.SaveRemitNote = false;
            this.transferGlobalOtherEditor_OverCountry.Size = new System.Drawing.Size(487, 336);
            this.transferGlobalOtherEditor_OverCountry.TabIndex = 11;
            this.transferGlobalOtherEditor_OverCountry.TransferGlobal = null;
            // 
            // panel23
            // 
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(33, 604);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(487, 7);
            this.panel23.TabIndex = 10;
            // 
            // transferGlobalPayeeEditor_OverCountry
            // 
            this.transferGlobalPayeeEditor_OverCountry._UnitivePaymentForeignMoney = null;
            this.transferGlobalPayeeEditor_OverCountry.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverCountry;
            this.transferGlobalPayeeEditor_OverCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalPayeeEditor_OverCountry.Dock = System.Windows.Forms.DockStyle.Top;
            this.transferGlobalPayeeEditor_OverCountry.Location = new System.Drawing.Point(33, 304);
            this.transferGlobalPayeeEditor_OverCountry.Name = "transferGlobalPayeeEditor_OverCountry";
            this.transferGlobalPayeeEditor_OverCountry.Size = new System.Drawing.Size(487, 300);
            this.transferGlobalPayeeEditor_OverCountry.TabIndex = 9;
            this.transferGlobalPayeeEditor_OverCountry.TransferGlobal = null;
            // 
            // panel24
            // 
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(33, 298);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(487, 6);
            this.panel24.TabIndex = 8;
            // 
            // transferGlobalRemitEditor_OverCountry
            // 
            this.transferGlobalRemitEditor_OverCountry.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverCountry;
            this.transferGlobalRemitEditor_OverCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferGlobalRemitEditor_OverCountry.Dock = System.Windows.Forms.DockStyle.Top;
            this.transferGlobalRemitEditor_OverCountry.Location = new System.Drawing.Point(33, 6);
            this.transferGlobalRemitEditor_OverCountry.Margin = new System.Windows.Forms.Padding(6);
            this.transferGlobalRemitEditor_OverCountry.Name = "transferGlobalRemitEditor_OverCountry";
            this.transferGlobalRemitEditor_OverCountry.Size = new System.Drawing.Size(487, 292);
            this.transferGlobalRemitEditor_OverCountry.TabIndex = 7;
            this.transferGlobalRemitEditor_OverCountry.TransferGlobal = null;
            // 
            // panel25
            // 
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(33, 3);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(487, 3);
            this.panel25.TabIndex = 3;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Controls.Add(this.label28, 0, 2);
            this.tableLayoutPanel15.Controls.Add(this.label29, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.label30, 0, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 3;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 297F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(30, 944);
            this.tableLayoutPanel15.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(3, 607);
            this.label28.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 337);
            this.label28.TabIndex = 4;
            this.label28.Text = "其他信息";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(3, 300);
            this.label29.Margin = new System.Windows.Forms.Padding(3);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(24, 301);
            this.label29.TabIndex = 2;
            this.label29.Text = "收款人信息";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(3, 3);
            this.label30.Margin = new System.Windows.Forms.Padding(3);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 291);
            this.label30.TabIndex = 0;
            this.label30.Text = "汇款信息";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_OverCountry
            // 
            this.rowIndexPanel_OverCountry.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverCountry;
            this.rowIndexPanel_OverCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_OverCountry.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_OverCountry.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_OverCountry.Margin = new System.Windows.Forms.Padding(6);
            this.rowIndexPanel_OverCountry.Name = "rowIndexPanel_OverCountry";
            this.rowIndexPanel_OverCountry.Size = new System.Drawing.Size(540, 28);
            this.rowIndexPanel_OverCountry.TabIndex = 1;
            // 
            // dataOperatePanel15
            // 
            this.dataOperatePanel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel15.HasLock = false;
            this.dataOperatePanel15.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel15.Name = "dataOperatePanel15";
            this.dataOperatePanel15.Size = new System.Drawing.Size(540, 50);
            this.dataOperatePanel15.TabIndex = 0;
            this.dataOperatePanel15.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel15.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel15.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel15.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
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
            this.label1.Size = new System.Drawing.Size(389, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作跨境汇款功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_TransferOverCountry);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_TransferOverCountry.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_TransferOverCountry;
        private TransferGlobalItemsPanel transferGlobalItemsPanel_Country;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel15;
        private SnapSplitter snapSplitter13;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private TransferGlobalOtherSelector transferGlobalOtherEditor_OverCountry;
        private System.Windows.Forms.Panel panel23;
        private TransferGlobalPayeeSelector transferGlobalPayeeEditor_OverCountry;
        private System.Windows.Forms.Panel panel24;
        private TransferGlobalRemitSelector transferGlobalRemitEditor_OverCountry;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private RowIndexPanel rowIndexPanel_OverCountry;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
