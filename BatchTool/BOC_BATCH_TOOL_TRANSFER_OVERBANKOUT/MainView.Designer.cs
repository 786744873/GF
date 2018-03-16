using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_TRANSFER_OVERBANKOUT
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
            this.p_OverBankOut = new System.Windows.Forms.Panel();
            this.transferOverBankItemPanelOut = new CommonClient.VisualParts2.TransferOverBankItemPanel();
            this.fileOperatePanel8 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter12 = new CommonClient.Controls.SnapSplitter();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.payeePnl_OverBankOut = new CommonClient.VisualParts2.PayeeSelector();
            this.transferEditor_OverBankOut = new CommonClient.VisualParts2.TransferEditor();
            this.payerPnl_OverBankOut = new CommonClient.VisualParts2.PayerSelector();
            this.rowIndexPanel_OverBankOut = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel8 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_OverBankOut.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_OverBankOut
            // 
            this.p_OverBankOut.BackColor = System.Drawing.Color.Transparent;
            this.p_OverBankOut.Controls.Add(this.transferOverBankItemPanelOut);
            this.p_OverBankOut.Controls.Add(this.fileOperatePanel8);
            this.p_OverBankOut.Controls.Add(this.snapSplitter12);
            this.p_OverBankOut.Controls.Add(this.panel10);
            this.p_OverBankOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_OverBankOut.Location = new System.Drawing.Point(0, 24);
            this.p_OverBankOut.Name = "p_OverBankOut";
            this.p_OverBankOut.Size = new System.Drawing.Size(1000, 476);
            this.p_OverBankOut.TabIndex = 1;
            // 
            // transferOverBankItemPanelOut
            // 
            this.transferOverBankItemPanelOut.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankOut;
            this.transferOverBankItemPanelOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferOverBankItemPanelOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferOverBankItemPanelOut.Location = new System.Drawing.Point(0, 0);
            this.transferOverBankItemPanelOut.Name = "transferOverBankItemPanelOut";
            this.transferOverBankItemPanelOut.Size = new System.Drawing.Size(520, 426);
            this.transferOverBankItemPanelOut.TabIndex = 1;
            // 
            // fileOperatePanel8
            // 
            this.fileOperatePanel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel8.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel8.Name = "fileOperatePanel8";
            this.fileOperatePanel8.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel8.TabIndex = 2;
            this.fileOperatePanel8.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel8.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel8.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel8.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel8.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel8.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel8.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel8.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter12
            // 
            this.snapSplitter12.AnimationDelay = 20;
            this.snapSplitter12.AnimationStep = 20;
            this.snapSplitter12.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter12.ControlToHide = this.panel10;
            this.snapSplitter12.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter12.ExpandParentForm = false;
            this.snapSplitter12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter12.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter12.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter12.Name = "snapSplitter12";
            this.snapSplitter12.TabIndex = 21;
            this.snapSplitter12.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tableLayoutPanel6);
            this.panel10.Controls.Add(this.dataOperatePanel8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(540, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(460, 476);
            this.panel10.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoScroll = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.payeePnl_OverBankOut, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.transferEditor_OverBankOut, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.payerPnl_OverBankOut, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.rowIndexPanel_OverBankOut, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(460, 426);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 264);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 159);
            this.label1.TabIndex = 4;
            this.label1.Text = "交易信息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 162);
            this.label2.TabIndex = 2;
            this.label2.Text = "收款人";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 52);
            this.label3.TabIndex = 0;
            this.label3.Text = "付款人";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // payeePnl_OverBankOut
            // 
            this.payeePnl_OverBankOut.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payeePnl_OverBankOut.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankOut;
            this.payeePnl_OverBankOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payeePnl_OverBankOut.BankType = CommonClient.EnumTypes.AccountBankType.OtherBankAccount;
            this.payeePnl_OverBankOut.CurrentPayee = null;
            this.payeePnl_OverBankOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payeePnl_OverBankOut.Location = new System.Drawing.Point(63, 97);
            this.payeePnl_OverBankOut.Margin = new System.Windows.Forms.Padding(4);
            this.payeePnl_OverBankOut.Name = "payeePnl_OverBankOut";
            this.payeePnl_OverBankOut.Size = new System.Drawing.Size(393, 160);
            this.payeePnl_OverBankOut.TabIndex = 5;
            // 
            // transferEditor_OverBankOut
            // 
            this.transferEditor_OverBankOut.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankOut;
            this.transferEditor_OverBankOut.AutoScroll = true;
            this.transferEditor_OverBankOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferEditor_OverBankOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferEditor_OverBankOut.Location = new System.Drawing.Point(63, 265);
            this.transferEditor_OverBankOut.Margin = new System.Windows.Forms.Padding(4);
            this.transferEditor_OverBankOut.Name = "transferEditor_OverBankOut";
            this.transferEditor_OverBankOut.Size = new System.Drawing.Size(393, 157);
            this.transferEditor_OverBankOut.TabIndex = 6;
            this.transferEditor_OverBankOut.Transfer = null;
            // 
            // payerPnl_OverBankOut
            // 
            this.payerPnl_OverBankOut.AccountType = CommonClient.EnumTypes.AccountCategoryType.Personal;
            this.payerPnl_OverBankOut.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankOut;
            this.payerPnl_OverBankOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payerPnl_OverBankOut.CurrentPayer = null;
            this.payerPnl_OverBankOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_OverBankOut.Location = new System.Drawing.Point(63, 39);
            this.payerPnl_OverBankOut.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_OverBankOut.Name = "payerPnl_OverBankOut";
            this.payerPnl_OverBankOut.Size = new System.Drawing.Size(393, 50);
            this.payerPnl_OverBankOut.TabIndex = 7;
            // 
            // rowIndexPanel_OverBankOut
            // 
            this.rowIndexPanel_OverBankOut.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankOut;
            this.rowIndexPanel_OverBankOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel6.SetColumnSpan(this.rowIndexPanel_OverBankOut, 2);
            this.rowIndexPanel_OverBankOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_OverBankOut.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_OverBankOut.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_OverBankOut.Name = "rowIndexPanel_OverBankOut";
            this.rowIndexPanel_OverBankOut.Size = new System.Drawing.Size(452, 27);
            this.rowIndexPanel_OverBankOut.TabIndex = 8;
            // 
            // dataOperatePanel8
            // 
            this.dataOperatePanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel8.HasLock = false;
            this.dataOperatePanel8.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel8.Name = "dataOperatePanel8";
            this.dataOperatePanel8.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel8.TabIndex = 2;
            this.dataOperatePanel8.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel8.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel8.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel8.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 22;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(425, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "通过该功能您可以逐笔填写的方式，制作跨行速汇(付款)功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_OverBankOut);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_OverBankOut.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_OverBankOut;
        private TransferOverBankItemPanel transferOverBankItemPanelOut;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel8;
        private SnapSplitter snapSplitter12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private PayeeSelector payeePnl_OverBankOut;
        private TransferEditor transferEditor_OverBankOut;
        private PayerSelector payerPnl_OverBankOut;
        private RowIndexPanel rowIndexPanel_OverBankOut;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}
