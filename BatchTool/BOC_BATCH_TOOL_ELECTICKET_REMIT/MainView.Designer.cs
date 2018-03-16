using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_ELECTICKET_REMIT
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
            this.p_ElecTicketRemit = new System.Windows.Forms.Panel();
            this.elecTicketRemitItemsPanel = new CommonClient.VisualParts2.ElecTicketRemitItemsPanel();
            this.fileOperatePanel9 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter1 = new CommonClient.Controls.SnapSplitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ettiRemit = new CommonClient.VisualParts2.ElecTicketTypeInfo();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rowIndexPanel_Remit = new CommonClient.VisualParts2.RowIndexPanel();
            this.payerPnl_Remit = new CommonClient.VisualParts2.PayerSelector();
            this.label7 = new System.Windows.Forms.Label();
            this.etrasExchange = new CommonClient.VisualParts2.ElecTicketRelateAccountSelector();
            this.etrasPayee = new CommonClient.VisualParts2.ElecTicketRelateAccountSelector();
            this.etoeRemit = new CommonClient.VisualParts2.ElecTicketOtherPanel();
            this.dataOperatePanel9 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_ElecTicketRemit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_ElecTicketRemit
            // 
            this.p_ElecTicketRemit.Controls.Add(this.elecTicketRemitItemsPanel);
            this.p_ElecTicketRemit.Controls.Add(this.fileOperatePanel9);
            this.p_ElecTicketRemit.Controls.Add(this.snapSplitter1);
            this.p_ElecTicketRemit.Controls.Add(this.panel1);
            this.p_ElecTicketRemit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_ElecTicketRemit.Location = new System.Drawing.Point(0, 24);
            this.p_ElecTicketRemit.Name = "p_ElecTicketRemit";
            this.p_ElecTicketRemit.Size = new System.Drawing.Size(1000, 476);
            this.p_ElecTicketRemit.TabIndex = 25;
            // 
            // elecTicketRemitItemsPanel
            // 
            this.elecTicketRemitItemsPanel.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.elecTicketRemitItemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketRemitItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketRemitItemsPanel.Location = new System.Drawing.Point(0, 0);
            this.elecTicketRemitItemsPanel.Name = "elecTicketRemitItemsPanel";
            this.elecTicketRemitItemsPanel.Size = new System.Drawing.Size(520, 426);
            this.elecTicketRemitItemsPanel.TabIndex = 1;
            // 
            // fileOperatePanel9
            // 
            this.fileOperatePanel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel9.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel9.Name = "fileOperatePanel9";
            this.fileOperatePanel9.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel9.TabIndex = 2;
            this.fileOperatePanel9.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel9.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel9.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel9.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel9.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel9.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel9.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel9.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter1
            // 
            this.snapSplitter1.AnimationDelay = 20;
            this.snapSplitter1.AnimationStep = 20;
            this.snapSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter1.ControlToHide = this.panel1;
            this.snapSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter1.ExpandParentForm = false;
            this.snapSplitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter1.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter1.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter1.Name = "snapSplitter1";
            this.snapSplitter1.TabIndex = 2;
            this.snapSplitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.dataOperatePanel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(540, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 476);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel8.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel8.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.ettiRemit, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.rowIndexPanel_Remit, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.payerPnl_Remit, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.etrasExchange, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.etrasPayee, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.etoeRemit, 1, 5);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 6;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(443, 550);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(3, 430);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 117);
            this.label11.TabIndex = 14;
            this.label11.Text = "其他信息";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(3, 317);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 107);
            this.label10.TabIndex = 12;
            this.label10.Text = "收款人";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ettiRemit
            // 
            this.ettiRemit.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.ettiRemit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.ettiRemit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ettiRemit.Location = new System.Drawing.Point(60, 71);
            this.ettiRemit.Name = "ettiRemit";
            this.ettiRemit.Remit = null;
            this.ettiRemit.Size = new System.Drawing.Size(380, 127);
            this.ettiRemit.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(3, 204);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 107);
            this.label9.TabIndex = 6;
            this.label9.Text = "承兑人";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(3, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 127);
            this.label8.TabIndex = 3;
            this.label8.Text = "票据信息";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_Remit
            // 
            this.rowIndexPanel_Remit.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.rowIndexPanel_Remit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel8.SetColumnSpan(this.rowIndexPanel_Remit, 2);
            this.rowIndexPanel_Remit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_Remit.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_Remit.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_Remit.Name = "rowIndexPanel_Remit";
            this.rowIndexPanel_Remit.Size = new System.Drawing.Size(435, 27);
            this.rowIndexPanel_Remit.TabIndex = 0;
            // 
            // payerPnl_Remit
            // 
            this.payerPnl_Remit.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payerPnl_Remit.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.payerPnl_Remit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payerPnl_Remit.CurrentPayer = null;
            this.payerPnl_Remit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_Remit.Location = new System.Drawing.Point(61, 39);
            this.payerPnl_Remit.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_Remit.Name = "payerPnl_Remit";
            this.payerPnl_Remit.Size = new System.Drawing.Size(378, 25);
            this.payerPnl_Remit.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 27);
            this.label7.TabIndex = 2;
            this.label7.Text = "出票人";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // etrasExchange
            // 
            this.etrasExchange.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.etrasExchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.etrasExchange.CurrentRelateAccount = null;
            this.etrasExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etrasExchange.Location = new System.Drawing.Point(60, 204);
            this.etrasExchange.Name = "etrasExchange";
            this.etrasExchange.RelateType = CommonClient.EnumTypes.RelatePersonType.Exchange;
            this.etrasExchange.Size = new System.Drawing.Size(380, 107);
            this.etrasExchange.TabIndex = 11;
            // 
            // etrasPayee
            // 
            this.etrasPayee.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.etrasPayee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.etrasPayee.CurrentRelateAccount = null;
            this.etrasPayee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etrasPayee.Location = new System.Drawing.Point(60, 317);
            this.etrasPayee.Name = "etrasPayee";
            this.etrasPayee.RelateType = CommonClient.EnumTypes.RelatePersonType.Payee;
            this.etrasPayee.Size = new System.Drawing.Size(380, 107);
            this.etrasPayee.TabIndex = 13;
            // 
            // etoeRemit
            // 
            this.etoeRemit.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketRemit;
            this.etoeRemit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.etoeRemit.BackNote = null;
            this.etoeRemit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etoeRemit.Location = new System.Drawing.Point(60, 430);
            this.etoeRemit.Name = "etoeRemit";
            this.etoeRemit.PayMoney = null;
            this.etoeRemit.Remit = null;
            this.etoeRemit.Size = new System.Drawing.Size(380, 117);
            this.etoeRemit.TabIndex = 15;
            this.etoeRemit.TipExchange = null;
            // 
            // dataOperatePanel9
            // 
            this.dataOperatePanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel9.HasLock = false;
            this.dataOperatePanel9.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel9.Name = "dataOperatePanel9";
            this.dataOperatePanel9.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel9.TabIndex = 2;
            this.dataOperatePanel9.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel9.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel9.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel9.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 24);
            this.panel2.TabIndex = 4;
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
            this.label1.Size = new System.Drawing.Size(389, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作电票出票功能批量交易信息文件";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.AutoScrollMinSize = new System.Drawing.Size(0, 550);
            this.panel4.Controls.Add(this.tableLayoutPanel8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(460, 426);
            this.panel4.TabIndex = 3;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_ElecTicketRemit);
            this.Controls.Add(this.panel2);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_ElecTicketRemit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_ElecTicketRemit;
        private ElecTicketRemitItemsPanel elecTicketRemitItemsPanel;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel9;
        private SnapSplitter snapSplitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private ElecTicketTypeInfo ettiRemit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private RowIndexPanel rowIndexPanel_Remit;
        private PayerSelector payerPnl_Remit;
        private System.Windows.Forms.Label label7;
        private ElecTicketRelateAccountSelector etrasExchange;
        private ElecTicketRelateAccountSelector etrasPayee;
        private ElecTicketOtherPanel etoeRemit;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
    }
}
