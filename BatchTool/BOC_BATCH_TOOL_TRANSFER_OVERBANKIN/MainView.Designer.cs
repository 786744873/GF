using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_TRANSFER_OVERBANKIN
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
            this.p_OverBankIn = new System.Windows.Forms.Panel();
            this.transferOverBankItemPanelIn = new CommonClient.VisualParts2.TransferOverBankItemPanel();
            this.fileOperatePanel7 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter11 = new CommonClient.Controls.SnapSplitter();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.payeePnl_OverBankIn = new CommonClient.VisualParts2.PayeeSelector();
            this.transferEditor_OverBankIn = new CommonClient.VisualParts2.TransferEditor();
            this.payerPnl_OverBankIn = new CommonClient.VisualParts2.PayerSelector();
            this.rowIndexPanel_OverBankIn = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel7 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_OverBankIn.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_OverBankIn
            // 
            this.p_OverBankIn.BackColor = System.Drawing.Color.Transparent;
            this.p_OverBankIn.Controls.Add(this.transferOverBankItemPanelIn);
            this.p_OverBankIn.Controls.Add(this.fileOperatePanel7);
            this.p_OverBankIn.Controls.Add(this.snapSplitter11);
            this.p_OverBankIn.Controls.Add(this.panel9);
            this.p_OverBankIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_OverBankIn.Location = new System.Drawing.Point(0, 24);
            this.p_OverBankIn.Name = "p_OverBankIn";
            this.p_OverBankIn.Size = new System.Drawing.Size(1000, 476);
            this.p_OverBankIn.TabIndex = 1;
            // 
            // transferOverBankItemPanelIn
            // 
            this.transferOverBankItemPanelIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankIn;
            this.transferOverBankItemPanelIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferOverBankItemPanelIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferOverBankItemPanelIn.Location = new System.Drawing.Point(0, 0);
            this.transferOverBankItemPanelIn.Name = "transferOverBankItemPanelIn";
            this.transferOverBankItemPanelIn.Size = new System.Drawing.Size(520, 426);
            this.transferOverBankItemPanelIn.TabIndex = 1;
            // 
            // fileOperatePanel7
            // 
            this.fileOperatePanel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel7.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel7.Name = "fileOperatePanel7";
            this.fileOperatePanel7.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel7.TabIndex = 2;
            this.fileOperatePanel7.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel7.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel7.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel7.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel7.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel7.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel7.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel7.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter11
            // 
            this.snapSplitter11.AnimationDelay = 20;
            this.snapSplitter11.AnimationStep = 20;
            this.snapSplitter11.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter11.ControlToHide = this.panel9;
            this.snapSplitter11.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter11.ExpandParentForm = false;
            this.snapSplitter11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter11.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter11.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter11.Name = "snapSplitter11";
            this.snapSplitter11.Size = new System.Drawing.Size(20, 476);
            this.snapSplitter11.TabIndex = 18;
            this.snapSplitter11.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Controls.Add(this.dataOperatePanel7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(540, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(460, 476);
            this.panel9.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoScroll = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel7.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.payeePnl_OverBankIn, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.transferEditor_OverBankIn, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.payerPnl_OverBankIn, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.rowIndexPanel_OverBankIn, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(443, 505);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 262);
            this.label4.TabIndex = 4;
            this.label4.Text = "交易信息";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 138);
            this.label5.TabIndex = 2;
            this.label5.Text = "付款人";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 52);
            this.label6.TabIndex = 0;
            this.label6.Text = "收款人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // payeePnl_OverBankIn
            // 
            this.payeePnl_OverBankIn.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payeePnl_OverBankIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankIn;
            this.payeePnl_OverBankIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payeePnl_OverBankIn.BankType = CommonClient.EnumTypes.AccountBankType.OtherBankAccount;
            this.payeePnl_OverBankIn.CurrentPayee = null;
            this.payeePnl_OverBankIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payeePnl_OverBankIn.Location = new System.Drawing.Point(61, 97);
            this.payeePnl_OverBankIn.Margin = new System.Windows.Forms.Padding(4);
            this.payeePnl_OverBankIn.Name = "payeePnl_OverBankIn";
            this.payeePnl_OverBankIn.Size = new System.Drawing.Size(378, 136);
            this.payeePnl_OverBankIn.TabIndex = 5;
            // 
            // transferEditor_OverBankIn
            // 
            this.transferEditor_OverBankIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankIn;
            this.transferEditor_OverBankIn.AutoScroll = true;
            this.transferEditor_OverBankIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.transferEditor_OverBankIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferEditor_OverBankIn.Location = new System.Drawing.Point(61, 241);
            this.transferEditor_OverBankIn.Margin = new System.Windows.Forms.Padding(4);
            this.transferEditor_OverBankIn.Name = "transferEditor_OverBankIn";
            this.transferEditor_OverBankIn.Size = new System.Drawing.Size(378, 260);
            this.transferEditor_OverBankIn.TabIndex = 6;
            this.transferEditor_OverBankIn.Transfer = null;
            // 
            // payerPnl_OverBankIn
            // 
            this.payerPnl_OverBankIn.AccountType = CommonClient.EnumTypes.AccountCategoryType.Personal;
            this.payerPnl_OverBankIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankIn;
            this.payerPnl_OverBankIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payerPnl_OverBankIn.CurrentPayer = null;
            this.payerPnl_OverBankIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_OverBankIn.Location = new System.Drawing.Point(61, 39);
            this.payerPnl_OverBankIn.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_OverBankIn.Name = "payerPnl_OverBankIn";
            this.payerPnl_OverBankIn.Size = new System.Drawing.Size(378, 50);
            this.payerPnl_OverBankIn.TabIndex = 7;
            // 
            // rowIndexPanel_OverBankIn
            // 
            this.rowIndexPanel_OverBankIn.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverBankIn;
            this.rowIndexPanel_OverBankIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel7.SetColumnSpan(this.rowIndexPanel_OverBankIn, 2);
            this.rowIndexPanel_OverBankIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_OverBankIn.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_OverBankIn.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_OverBankIn.Name = "rowIndexPanel_OverBankIn";
            this.rowIndexPanel_OverBankIn.Size = new System.Drawing.Size(435, 27);
            this.rowIndexPanel_OverBankIn.TabIndex = 8;
            // 
            // dataOperatePanel7
            // 
            this.dataOperatePanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel7.HasLock = false;
            this.dataOperatePanel7.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel7.Name = "dataOperatePanel7";
            this.dataOperatePanel7.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel7.TabIndex = 2;
            this.dataOperatePanel7.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel7.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel7.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel7.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
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
            this.label1.Size = new System.Drawing.Size(421, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作跨行速汇(收款)功能批量交易信息文件";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMinSize = new System.Drawing.Size(0, 505);
            this.panel3.Controls.Add(this.tableLayoutPanel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 426);
            this.panel3.TabIndex = 3;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_OverBankIn);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_OverBankIn.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_OverBankIn;
        private TransferOverBankItemPanel transferOverBankItemPanelIn;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel7;
        private SnapSplitter snapSplitter11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private PayeeSelector payeePnl_OverBankIn;
        private TransferEditor transferEditor_OverBankIn;
        private PayerSelector payerPnl_OverBankIn;
        private RowIndexPanel rowIndexPanel_OverBankIn;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}
