using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_SPPLYFINANCING_BILLOFDEBTRECEIVABLEPURCHASER
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
            this.p_BillofDebtReceivablePurchaser = new System.Windows.Forms.Panel();
            this.spplyFinancingBillItemsPanel_Purchase = new CommonClient.VisualParts2.SpplyFinancingBillItemsPanel();
            this.fileOperatePanel22 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter20 = new CommonClient.Controls.SnapSplitter();
            this.panel31 = new System.Windows.Forms.Panel();
            this.spplyFinancingBill_Purchase = new CommonClient.VisualParts2.SpplyFinancingBillEditor();
            this.dataOperatePanel22 = new CommonClient.VisualParts.DataOperatePanel();
            this.rowIndexPanel_BillPurchase = new CommonClient.VisualParts2.RowIndexPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_BillofDebtReceivablePurchaser.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_BillofDebtReceivablePurchaser
            // 
            this.p_BillofDebtReceivablePurchaser.Controls.Add(this.spplyFinancingBillItemsPanel_Purchase);
            this.p_BillofDebtReceivablePurchaser.Controls.Add(this.fileOperatePanel22);
            this.p_BillofDebtReceivablePurchaser.Controls.Add(this.snapSplitter20);
            this.p_BillofDebtReceivablePurchaser.Controls.Add(this.panel31);
            this.p_BillofDebtReceivablePurchaser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_BillofDebtReceivablePurchaser.Location = new System.Drawing.Point(0, 24);
            this.p_BillofDebtReceivablePurchaser.Name = "p_BillofDebtReceivablePurchaser";
            this.p_BillofDebtReceivablePurchaser.Size = new System.Drawing.Size(1000, 476);
            this.p_BillofDebtReceivablePurchaser.TabIndex = 5;
            // 
            // spplyFinancingBillItemsPanel_Purchase
            // 
            this.spplyFinancingBillItemsPanel_Purchase.AppType = CommonClient.EnumTypes.AppliableFunctionType.BillofDebtReceivablePurchaser;
            this.spplyFinancingBillItemsPanel_Purchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.spplyFinancingBillItemsPanel_Purchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spplyFinancingBillItemsPanel_Purchase.Location = new System.Drawing.Point(0, 0);
            this.spplyFinancingBillItemsPanel_Purchase.Name = "spplyFinancingBillItemsPanel_Purchase";
            this.spplyFinancingBillItemsPanel_Purchase.Size = new System.Drawing.Size(520, 426);
            this.spplyFinancingBillItemsPanel_Purchase.TabIndex = 3;
            // 
            // fileOperatePanel22
            // 
            this.fileOperatePanel22.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel22.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel22.Name = "fileOperatePanel22";
            this.fileOperatePanel22.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel22.TabIndex = 2;
            this.fileOperatePanel22.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel22.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel22.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel22.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel22.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel22.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel22.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter20
            // 
            this.snapSplitter20.AnimationDelay = 20;
            this.snapSplitter20.AnimationStep = 20;
            this.snapSplitter20.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter20.ControlToHide = this.panel31;
            this.snapSplitter20.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter20.ExpandParentForm = false;
            this.snapSplitter20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter20.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter20.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter20.Name = "snapSplitter20";
            this.snapSplitter20.TabIndex = 1;
            this.snapSplitter20.TabStop = false;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.spplyFinancingBill_Purchase);
            this.panel31.Controls.Add(this.dataOperatePanel22);
            this.panel31.Controls.Add(this.rowIndexPanel_BillPurchase);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel31.Location = new System.Drawing.Point(540, 0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(460, 476);
            this.panel31.TabIndex = 0;
            // 
            // spplyFinancingBill_Purchase
            // 
            this.spplyFinancingBill_Purchase.AppType = CommonClient.EnumTypes.AppliableFunctionType.BillofDebtReceivablePurchaser;
            this.spplyFinancingBill_Purchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.spplyFinancingBill_Purchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spplyFinancingBill_Purchase.Location = new System.Drawing.Point(0, 28);
            this.spplyFinancingBill_Purchase.Name = "spplyFinancingBill_Purchase";
            this.spplyFinancingBill_Purchase.Size = new System.Drawing.Size(460, 398);
            this.spplyFinancingBill_Purchase.TabIndex = 2;
            // 
            // dataOperatePanel22
            // 
            this.dataOperatePanel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel22.HasLock = false;
            this.dataOperatePanel22.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel22.Name = "dataOperatePanel22";
            this.dataOperatePanel22.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel22.TabIndex = 1;
            this.dataOperatePanel22.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel22.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel22.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel22.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // rowIndexPanel_BillPurchase
            // 
            this.rowIndexPanel_BillPurchase.AppType = CommonClient.EnumTypes.AppliableFunctionType.BillofDebtReceivablePurchaser;
            this.rowIndexPanel_BillPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_BillPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_BillPurchase.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_BillPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_BillPurchase.Name = "rowIndexPanel_BillPurchase";
            this.rowIndexPanel_BillPurchase.Size = new System.Drawing.Size(460, 28);
            this.rowIndexPanel_BillPurchase.TabIndex = 0;
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
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作应收账款买方发票(应收账款保理池融资)功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_BillofDebtReceivablePurchaser);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_BillofDebtReceivablePurchaser.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_BillofDebtReceivablePurchaser;
        private SpplyFinancingBillItemsPanel spplyFinancingBillItemsPanel_Purchase;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel22;
        private SnapSplitter snapSplitter20;
        private System.Windows.Forms.Panel panel31;
        private SpplyFinancingBillEditor spplyFinancingBill_Purchase;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel22;
        private RowIndexPanel rowIndexPanel_BillPurchase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
