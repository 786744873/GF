using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_TRANSFER_INDIVIDUAL
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
            this.p_Ind = new System.Windows.Forms.Panel();
            this.transferItemsPanelInvid = new CommonClient.VisualParts2.TransferItemsPanel();
            this.fileOperatePanel1 = new CommonClient.VisualParts.FileOperatePanel();
            this._snapSplitter5 = new CommonClient.Controls.SnapSplitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataOperatePanel16 = new CommonClient.VisualParts.DataOperatePanel();
            this.layPnlTransferE = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransferInfo1 = new System.Windows.Forms.Label();
            this.lblPayee1 = new System.Windows.Forms.Label();
            this.lblPayer1 = new System.Windows.Forms.Label();
            this.payeePnl_P = new CommonClient.VisualParts2.PayeeSelector();
            this.transferEditor_P = new CommonClient.VisualParts2.TransferEditor();
            this.payerPnl_Ind = new CommonClient.VisualParts2.PayerSelector();
            this.rowIndexPanel_Ind = new CommonClient.VisualParts2.RowIndexPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_Ind.SuspendLayout();
            this.panel3.SuspendLayout();
            this.layPnlTransferE.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Ind
            // 
            this.p_Ind.BackColor = System.Drawing.Color.Transparent;
            this.p_Ind.Controls.Add(this.transferItemsPanelInvid);
            this.p_Ind.Controls.Add(this.fileOperatePanel1);
            this.p_Ind.Controls.Add(this._snapSplitter5);
            this.p_Ind.Controls.Add(this.panel3);
            this.p_Ind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Ind.Location = new System.Drawing.Point(0, 24);
            this.p_Ind.Name = "p_Ind";
            this.p_Ind.Size = new System.Drawing.Size(1000, 476);
            this.p_Ind.TabIndex = 1;
            // 
            // transferItemsPanelInvid
            // 
            this.transferItemsPanelInvid.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferWithIndiv;
            this.transferItemsPanelInvid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferItemsPanelInvid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferItemsPanelInvid.Location = new System.Drawing.Point(0, 0);
            this.transferItemsPanelInvid.Name = "transferItemsPanelInvid";
            this.transferItemsPanelInvid.Size = new System.Drawing.Size(520, 426);
            this.transferItemsPanelInvid.TabIndex = 1;
            // 
            // fileOperatePanel1
            // 
            this.fileOperatePanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel1.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel1.Name = "fileOperatePanel1";
            this.fileOperatePanel1.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel1.TabIndex = 2;
            this.fileOperatePanel1.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel1.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel1.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel1.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel1.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel1.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel1.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel1.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // _snapSplitter5
            // 
            this._snapSplitter5.AnimationDelay = 20;
            this._snapSplitter5.AnimationStep = 20;
            this._snapSplitter5.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this._snapSplitter5.ControlToHide = this.panel3;
            this._snapSplitter5.Dock = System.Windows.Forms.DockStyle.Right;
            this._snapSplitter5.ExpandParentForm = false;
            this._snapSplitter5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._snapSplitter5.Location = new System.Drawing.Point(520, 0);
            this._snapSplitter5.MinimumSize = new System.Drawing.Size(20, 20);
            this._snapSplitter5.Name = "_snapSplitter1";
            this._snapSplitter5.TabIndex = 13;
            this._snapSplitter5.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataOperatePanel16);
            this.panel3.Controls.Add(this.layPnlTransferE);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(540, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 476);
            this.panel3.TabIndex = 3;
            // 
            // dataOperatePanel16
            // 
            this.dataOperatePanel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel16.HasLock = true;
            this.dataOperatePanel16.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel16.Name = "dataOperatePanel16";
            this.dataOperatePanel16.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel16.TabIndex = 15;
            this.dataOperatePanel16.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel16.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel16.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel16.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.dataOperatePanel16.ButtonLockClicked += new System.EventHandler(this.dataOperatePanel1_ButtonLockClicked);
            // 
            // layPnlTransferE
            // 
            this.layPnlTransferE.AutoScroll = true;
            this.layPnlTransferE.ColumnCount = 2;
            this.layPnlTransferE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.layPnlTransferE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.layPnlTransferE.Controls.Add(this.lblTransferInfo1, 0, 3);
            this.layPnlTransferE.Controls.Add(this.lblPayee1, 0, 2);
            this.layPnlTransferE.Controls.Add(this.lblPayer1, 0, 1);
            this.layPnlTransferE.Controls.Add(this.payeePnl_P, 1, 2);
            this.layPnlTransferE.Controls.Add(this.transferEditor_P, 1, 3);
            this.layPnlTransferE.Controls.Add(this.payerPnl_Ind, 1, 1);
            this.layPnlTransferE.Controls.Add(this.rowIndexPanel_Ind, 0, 0);
            this.layPnlTransferE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layPnlTransferE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.layPnlTransferE.Location = new System.Drawing.Point(0, 0);
            this.layPnlTransferE.Name = "layPnlTransferE";
            this.layPnlTransferE.RowCount = 4;
            this.layPnlTransferE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layPnlTransferE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.layPnlTransferE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.layPnlTransferE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layPnlTransferE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layPnlTransferE.Size = new System.Drawing.Size(460, 476);
            this.layPnlTransferE.TabIndex = 1;
            // 
            // lblTransferInfo1
            // 
            this.lblTransferInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblTransferInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTransferInfo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTransferInfo1.Location = new System.Drawing.Point(3, 248);
            this.lblTransferInfo1.Margin = new System.Windows.Forms.Padding(3);
            this.lblTransferInfo1.Name = "lblTransferInfo1";
            this.lblTransferInfo1.Size = new System.Drawing.Size(53, 225);
            this.lblTransferInfo1.TabIndex = 4;
            this.lblTransferInfo1.Text = "交易信息";
            this.lblTransferInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayee1
            // 
            this.lblPayee1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblPayee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPayee1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPayee1.Location = new System.Drawing.Point(3, 96);
            this.lblPayee1.Margin = new System.Windows.Forms.Padding(3);
            this.lblPayee1.Name = "lblPayee1";
            this.lblPayee1.Size = new System.Drawing.Size(53, 146);
            this.lblPayee1.TabIndex = 2;
            this.lblPayee1.Text = "收款人";
            this.lblPayee1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayer1
            // 
            this.lblPayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblPayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPayer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPayer1.Location = new System.Drawing.Point(3, 38);
            this.lblPayer1.Margin = new System.Windows.Forms.Padding(3);
            this.lblPayer1.Name = "lblPayer1";
            this.lblPayer1.Size = new System.Drawing.Size(53, 52);
            this.lblPayer1.TabIndex = 0;
            this.lblPayer1.Text = "付款人";
            this.lblPayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // payeePnl_P
            // 
            this.payeePnl_P.AccountType = CommonClient.EnumTypes.AccountCategoryType.Personal;
            this.payeePnl_P.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferWithIndiv;
            this.payeePnl_P.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payeePnl_P.BankType = CommonClient.EnumTypes.AccountBankType.Empty;
            this.payeePnl_P.CurrentPayee = null;
            this.payeePnl_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payeePnl_P.Location = new System.Drawing.Point(63, 97);
            this.payeePnl_P.Margin = new System.Windows.Forms.Padding(4);
            this.payeePnl_P.Name = "payeePnl_P";
            this.payeePnl_P.Size = new System.Drawing.Size(393, 144);
            this.payeePnl_P.TabIndex = 5;
            // 
            // transferEditor_P
            // 
            this.transferEditor_P.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferWithIndiv;
            this.transferEditor_P.AutoScroll = true;
            this.transferEditor_P.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferEditor_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferEditor_P.Location = new System.Drawing.Point(63, 249);
            this.transferEditor_P.Margin = new System.Windows.Forms.Padding(4);
            this.transferEditor_P.Name = "transferEditor_P";
            this.transferEditor_P.Size = new System.Drawing.Size(393, 223);
            this.transferEditor_P.TabIndex = 6;
            this.transferEditor_P.Transfer = null;
            // 
            // payerPnl_Ind
            // 
            this.payerPnl_Ind.AccountType = CommonClient.EnumTypes.AccountCategoryType.Personal;
            this.payerPnl_Ind.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferWithIndiv;
            this.payerPnl_Ind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payerPnl_Ind.CurrentPayer = null;
            this.payerPnl_Ind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_Ind.Location = new System.Drawing.Point(63, 39);
            this.payerPnl_Ind.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_Ind.Name = "payerPnl_Ind";
            this.payerPnl_Ind.Size = new System.Drawing.Size(393, 50);
            this.payerPnl_Ind.TabIndex = 7;
            // 
            // rowIndexPanel_Ind
            // 
            this.rowIndexPanel_Ind.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferWithIndiv;
            this.rowIndexPanel_Ind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.layPnlTransferE.SetColumnSpan(this.rowIndexPanel_Ind, 2);
            this.rowIndexPanel_Ind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_Ind.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_Ind.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_Ind.Name = "rowIndexPanel_Ind";
            this.rowIndexPanel_Ind.Size = new System.Drawing.Size(452, 27);
            this.rowIndexPanel_Ind.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 14;
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
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作对私汇款功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_Ind);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_Ind.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.layPnlTransferE.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Ind;
        private TransferItemsPanel transferItemsPanelInvid;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel1;
        private SnapSplitter _snapSplitter5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel layPnlTransferE;
        private System.Windows.Forms.Label lblTransferInfo1;
        private System.Windows.Forms.Label lblPayee1;
        private System.Windows.Forms.Label lblPayer1;
        private PayeeSelector payeePnl_P;
        private TransferEditor transferEditor_P;
        private PayerSelector payerPnl_Ind;
        private RowIndexPanel rowIndexPanel_Ind;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
