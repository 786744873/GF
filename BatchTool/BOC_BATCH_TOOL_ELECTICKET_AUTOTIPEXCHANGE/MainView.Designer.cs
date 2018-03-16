using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_ELECTICKET_AUTOTIPEXCHANGE
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
            this.p_ElecticketTipExchange = new System.Windows.Forms.Panel();
            this.elecTicketTipExchangeItemsPanel = new CommonClient.VisualParts2.ElecTicketTipExchangeItemsPanel();
            this.fileOperatePanel10 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter2 = new CommonClient.Controls.SnapSplitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rowIndexPanel_TipExchange = new CommonClient.VisualParts2.RowIndexPanel();
            this.payerPnl_TipExchange = new CommonClient.VisualParts2.PayerSelector();
            this.elecTicketRealteAccount_TipExchange = new CommonClient.VisualParts2.ElecTicketRelateAccountSelector();
            this.elecTicketOtherEditor_TipExchange = new CommonClient.VisualParts2.ElecTicketOtherPanel();
            this.dataOperatePanel10 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_ElecticketTipExchange.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_ElecticketTipExchange
            // 
            this.p_ElecticketTipExchange.Controls.Add(this.elecTicketTipExchangeItemsPanel);
            this.p_ElecticketTipExchange.Controls.Add(this.fileOperatePanel10);
            this.p_ElecticketTipExchange.Controls.Add(this.snapSplitter2);
            this.p_ElecticketTipExchange.Controls.Add(this.panel2);
            this.p_ElecticketTipExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_ElecticketTipExchange.Location = new System.Drawing.Point(0, 24);
            this.p_ElecticketTipExchange.Name = "p_ElecticketTipExchange";
            this.p_ElecticketTipExchange.Size = new System.Drawing.Size(1000, 476);
            this.p_ElecticketTipExchange.TabIndex = 6;
            // 
            // elecTicketTipExchangeItemsPanel
            // 
            this.elecTicketTipExchangeItemsPanel.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketTipExchange;
            this.elecTicketTipExchangeItemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketTipExchangeItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketTipExchangeItemsPanel.Location = new System.Drawing.Point(0, 0);
            this.elecTicketTipExchangeItemsPanel.Name = "elecTicketTipExchangeItemsPanel";
            this.elecTicketTipExchangeItemsPanel.Size = new System.Drawing.Size(520, 426);
            this.elecTicketTipExchangeItemsPanel.TabIndex = 1;
            // 
            // fileOperatePanel10
            // 
            this.fileOperatePanel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel10.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel10.Name = "fileOperatePanel10";
            this.fileOperatePanel10.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel10.TabIndex = 2;
            this.fileOperatePanel10.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel10.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel10.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel10.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel10.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel10.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel10.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel10.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter2
            // 
            this.snapSplitter2.AnimationDelay = 20;
            this.snapSplitter2.AnimationStep = 20;
            this.snapSplitter2.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter2.ControlToHide = this.panel2;
            this.snapSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter2.ExpandParentForm = false;
            this.snapSplitter2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter2.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter2.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter2.Name = "snapSplitter2";
            this.snapSplitter2.TabIndex = 1;
            this.snapSplitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel9);
            this.panel2.Controls.Add(this.dataOperatePanel10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(540, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 476);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel9.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.rowIndexPanel_TipExchange, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.payerPnl_TipExchange, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.elecTicketRealteAccount_TipExchange, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.elecTicketOtherEditor_TipExchange, 1, 3);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(460, 426);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(3, 96);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 107);
            this.label14.TabIndex = 5;
            this.label14.Text = "承兑人";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(3, 209);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 214);
            this.label13.TabIndex = 4;
            this.label13.Text = "其他信息";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_TipExchange
            // 
            this.rowIndexPanel_TipExchange.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketTipExchange;
            this.rowIndexPanel_TipExchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel9.SetColumnSpan(this.rowIndexPanel_TipExchange, 2);
            this.rowIndexPanel_TipExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_TipExchange.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_TipExchange.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_TipExchange.Name = "rowIndexPanel_TipExchange";
            this.rowIndexPanel_TipExchange.Size = new System.Drawing.Size(452, 27);
            this.rowIndexPanel_TipExchange.TabIndex = 0;
            // 
            // payerPnl_TipExchange
            // 
            this.payerPnl_TipExchange.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payerPnl_TipExchange.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketTipExchange;
            this.payerPnl_TipExchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel9.SetColumnSpan(this.payerPnl_TipExchange, 2);
            this.payerPnl_TipExchange.CurrentPayer = null;
            this.payerPnl_TipExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_TipExchange.Location = new System.Drawing.Point(4, 39);
            this.payerPnl_TipExchange.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_TipExchange.Name = "payerPnl_TipExchange";
            this.payerPnl_TipExchange.Size = new System.Drawing.Size(452, 50);
            this.payerPnl_TipExchange.TabIndex = 2;
            // 
            // elecTicketRealteAccount_TipExchange
            // 
            this.elecTicketRealteAccount_TipExchange.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketTipExchange;
            this.elecTicketRealteAccount_TipExchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketRealteAccount_TipExchange.CurrentRelateAccount = null;
            this.elecTicketRealteAccount_TipExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketRealteAccount_TipExchange.Location = new System.Drawing.Point(62, 96);
            this.elecTicketRealteAccount_TipExchange.Name = "elecTicketRealteAccount_TipExchange";
            this.elecTicketRealteAccount_TipExchange.RelateType = CommonClient.EnumTypes.RelatePersonType.Exchange;
            this.elecTicketRealteAccount_TipExchange.Size = new System.Drawing.Size(395, 107);
            this.elecTicketRealteAccount_TipExchange.TabIndex = 6;
            // 
            // elecTicketOtherEditor_TipExchange
            // 
            this.elecTicketOtherEditor_TipExchange.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketTipExchange;
            this.elecTicketOtherEditor_TipExchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketOtherEditor_TipExchange.BackNote = null;
            this.elecTicketOtherEditor_TipExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketOtherEditor_TipExchange.Location = new System.Drawing.Point(62, 209);
            this.elecTicketOtherEditor_TipExchange.Name = "elecTicketOtherEditor_TipExchange";
            this.elecTicketOtherEditor_TipExchange.PayMoney = null;
            this.elecTicketOtherEditor_TipExchange.Remit = null;
            this.elecTicketOtherEditor_TipExchange.Size = new System.Drawing.Size(395, 214);
            this.elecTicketOtherEditor_TipExchange.TabIndex = 7;
            this.elecTicketOtherEditor_TipExchange.TipExchange = null;
            // 
            // dataOperatePanel10
            // 
            this.dataOperatePanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel10.HasLock = false;
            this.dataOperatePanel10.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel10.Name = "dataOperatePanel10";
            this.dataOperatePanel10.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel10.TabIndex = 2;
            this.dataOperatePanel10.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel10.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel10.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel10.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 4;
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
            this.label1.Size = new System.Drawing.Size(415, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作电票提示承兑功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_ElecticketTipExchange);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_ElecticketTipExchange.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_ElecticketTipExchange;
        private ElecTicketTipExchangeItemsPanel elecTicketTipExchangeItemsPanel;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel10;
        private SnapSplitter snapSplitter2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private RowIndexPanel rowIndexPanel_TipExchange;
        private PayerSelector payerPnl_TipExchange;
        private ElecTicketRelateAccountSelector elecTicketRealteAccount_TipExchange;
        private ElecTicketOtherPanel elecTicketOtherEditor_TipExchange;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;

    }
}
