using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_TRANSFER_CORPORATION
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
            CommonClient.Entities.GovermentInfo govermentInfo1 = new CommonClient.Entities.GovermentInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.p_Ent = new System.Windows.Forms.Panel();
            this.govermentPanel1 = new CommonClient.VisualParts2.GovermentPanel();
            this.fileOperatePanel2 = new CommonClient.VisualParts.FileOperatePanel();
            this._snapSplitter6 = new CommonClient.Controls.SnapSplitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransferInfo2 = new System.Windows.Forms.Label();
            this.lblPayer2 = new System.Windows.Forms.Label();
            this.payeePnl_E = new CommonClient.VisualParts2.PayeeSelector();
            this.payerPnl_Ent = new CommonClient.VisualParts2.PayerSelector();
            this.lblPayee2 = new System.Windows.Forms.Label();
            this.rowIndexPanel_Crop = new CommonClient.VisualParts2.RowIndexPanel();
            this.theCentralGoverment1 = new CommonClient.VisualParts2.TheCentralGoverment();
            this.dataOperatePanel2 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_Ent.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Ent
            // 
            this.p_Ent.BackColor = System.Drawing.Color.Transparent;
            this.p_Ent.Controls.Add(this.govermentPanel1);
            this.p_Ent.Controls.Add(this.fileOperatePanel2);
            this.p_Ent.Controls.Add(this._snapSplitter6);
            this.p_Ent.Controls.Add(this.panel4);
            this.p_Ent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Ent.Location = new System.Drawing.Point(0, 24);
            this.p_Ent.Name = "p_Ent";
            this.p_Ent.Size = new System.Drawing.Size(1000, 476);
            this.p_Ent.TabIndex = 1;
            // 
            // govermentPanel1
            // 
            this.govermentPanel1.AppType = CommonClient.EnumTypes.AppliableFunctionType.TheCentralGoverment;
            this.govermentPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.govermentPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.govermentPanel1.Location = new System.Drawing.Point(0, 0);
            this.govermentPanel1.Name = "govermentPanel1";
            this.govermentPanel1.Size = new System.Drawing.Size(520, 426);
            this.govermentPanel1.TabIndex = 13;
            // 
            // fileOperatePanel2
            // 
            this.fileOperatePanel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel2.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel2.Name = "fileOperatePanel2";
            this.fileOperatePanel2.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel2.TabIndex = 10;
            this.fileOperatePanel2.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel2.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel2.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel2.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel2.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel2.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel2.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel2.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // _snapSplitter6
            // 
            this._snapSplitter6.AnimationDelay = 20;
            this._snapSplitter6.AnimationStep = 20;
            this._snapSplitter6.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this._snapSplitter6.ControlToHide = this.panel4;
            this._snapSplitter6.Dock = System.Windows.Forms.DockStyle.Right;
            this._snapSplitter6.ExpandParentForm = false;
            this._snapSplitter6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._snapSplitter6.Location = new System.Drawing.Point(520, 0);
            this._snapSplitter6.MinimumSize = new System.Drawing.Size(20, 20);
            this._snapSplitter6.Name = "_snapSplitter6";
            this._snapSplitter6.Size = new System.Drawing.Size(20, 476);
            this._snapSplitter6.TabIndex = 12;
            this._snapSplitter6.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Controls.Add(this.dataOperatePanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(540, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(460, 476);
            this.panel4.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel1.Controls.Add(this.lblTransferInfo2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPayer2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.payeePnl_E, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.payerPnl_Ent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPayee2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rowIndexPanel_Crop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.theCentralGoverment1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 426);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblTransferInfo2
            // 
            this.lblTransferInfo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblTransferInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTransferInfo2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTransferInfo2.Location = new System.Drawing.Point(3, 244);
            this.lblTransferInfo2.Margin = new System.Windows.Forms.Padding(3);
            this.lblTransferInfo2.Name = "lblTransferInfo2";
            this.lblTransferInfo2.Size = new System.Drawing.Size(53, 179);
            this.lblTransferInfo2.TabIndex = 4;
            this.lblTransferInfo2.Text = "交易信息";
            this.lblTransferInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayer2
            // 
            this.lblPayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblPayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPayer2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPayer2.Location = new System.Drawing.Point(3, 38);
            this.lblPayer2.Margin = new System.Windows.Forms.Padding(3);
            this.lblPayer2.Name = "lblPayer2";
            this.lblPayer2.Size = new System.Drawing.Size(53, 52);
            this.lblPayer2.TabIndex = 0;
            this.lblPayer2.Text = "付款人";
            this.lblPayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // payeePnl_E
            // 
            this.payeePnl_E.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payeePnl_E.AppType = CommonClient.EnumTypes.AppliableFunctionType.TheCentralGoverment;
            this.payeePnl_E.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payeePnl_E.BankType = CommonClient.EnumTypes.AccountBankType.Empty;
            this.payeePnl_E.CurrentPayee = null;
            this.payeePnl_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payeePnl_E.Location = new System.Drawing.Point(63, 97);
            this.payeePnl_E.Margin = new System.Windows.Forms.Padding(4);
            this.payeePnl_E.Name = "payeePnl_E";
            this.payeePnl_E.Size = new System.Drawing.Size(393, 140);
            this.payeePnl_E.TabIndex = 5;
            // 
            // payerPnl_Ent
            // 
            this.payerPnl_Ent.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payerPnl_Ent.AppType = CommonClient.EnumTypes.AppliableFunctionType.TheCentralGoverment;
            this.payerPnl_Ent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.payerPnl_Ent.CurrentPayer = null;
            this.payerPnl_Ent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_Ent.Location = new System.Drawing.Point(63, 39);
            this.payerPnl_Ent.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_Ent.Name = "payerPnl_Ent";
            this.payerPnl_Ent.Size = new System.Drawing.Size(393, 50);
            this.payerPnl_Ent.TabIndex = 7;
            // 
            // lblPayee2
            // 
            this.lblPayee2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lblPayee2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPayee2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPayee2.Location = new System.Drawing.Point(3, 96);
            this.lblPayee2.Margin = new System.Windows.Forms.Padding(3);
            this.lblPayee2.Name = "lblPayee2";
            this.lblPayee2.Size = new System.Drawing.Size(53, 142);
            this.lblPayee2.TabIndex = 2;
            this.lblPayee2.Text = "收款人";
            this.lblPayee2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_Crop
            // 
            this.rowIndexPanel_Crop.AppType = CommonClient.EnumTypes.AppliableFunctionType.TheCentralGoverment;
            this.rowIndexPanel_Crop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel1.SetColumnSpan(this.rowIndexPanel_Crop, 2);
            this.rowIndexPanel_Crop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_Crop.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_Crop.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_Crop.Name = "rowIndexPanel_Crop";
            this.rowIndexPanel_Crop.Size = new System.Drawing.Size(452, 27);
            this.rowIndexPanel_Crop.TabIndex = 8;
            // 
            // theCentralGoverment1
            // 
            this.theCentralGoverment1.AppType = CommonClient.EnumTypes.AppliableFunctionType.TheCentralGoverment;
            this.theCentralGoverment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.theCentralGoverment1.Dock = System.Windows.Forms.DockStyle.Fill;
            govermentInfo1.Addition = null;
            govermentInfo1.CNAPSNo = null;
            govermentInfo1.CustomerRef = null;
            govermentInfo1.ErrorReason = null;
            govermentInfo1.OddNumber = null;
            govermentInfo1.PayAmount = null;
            govermentInfo1.PayDatetime = null;
            govermentInfo1.PayeeAccount = null;
            govermentInfo1.PayeeCode = null;
            govermentInfo1.PayeeName = null;
            govermentInfo1.PayeeOpenBank = null;
            govermentInfo1.PayerAccount = null;
            govermentInfo1.RowIndex = 0;
            this.theCentralGoverment1.Goverment = govermentInfo1;
            this.theCentralGoverment1.Location = new System.Drawing.Point(62, 244);
            this.theCentralGoverment1.Name = "theCentralGoverment1";
            this.theCentralGoverment1.Size = new System.Drawing.Size(395, 179);
            this.theCentralGoverment1.TabIndex = 9;
            // 
            // dataOperatePanel2
            // 
            this.dataOperatePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel2.HasLock = true;
            this.dataOperatePanel2.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel2.Name = "dataOperatePanel2";
            this.dataOperatePanel2.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel2.TabIndex = 2;
            this.dataOperatePanel2.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel2.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel2.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel2.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.dataOperatePanel2.ButtonLockClicked += new System.EventHandler(this.dataOperatePanel1_ButtonLockClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(18, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 16);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作对公汇款功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_Ent);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_Ent.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Ent;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel2;
        private SnapSplitter _snapSplitter6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTransferInfo2;
        private System.Windows.Forms.Label lblPayer2;
        private PayeeSelector payeePnl_E;
        private PayerSelector payerPnl_Ent;
        private System.Windows.Forms.Label lblPayee2;
        private RowIndexPanel rowIndexPanel_Crop;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private TheCentralGoverment theCentralGoverment1;
        private GovermentPanel govermentPanel1;
    }
}
