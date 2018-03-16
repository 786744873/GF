using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_SPPLYFINANCING_PAYMENTORRECEIPTOFDEBTRECEIVABLE
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
            this.p_PaymentReceiptofDebtReceivablePurchaser = new System.Windows.Forms.Panel();
            this.spplyFinancingItemsPanel_Payment = new CommonClient.VisualParts2.SpplyFinancingPayReceiptItemsPanel();
            this.fileOperatePanel24 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter22 = new CommonClient.Controls.SnapSplitter();
            this.panel33 = new System.Windows.Forms.Panel();
            this.spplyFinancing_Payment = new CommonClient.VisualParts2.SpplyFinancingPayReceiptEditor();
            this.dataOperatePanel24 = new CommonClient.VisualParts.DataOperatePanel();
            this.rowIndexPanel_Payment = new CommonClient.VisualParts2.RowIndexPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_PaymentReceiptofDebtReceivablePurchaser.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_PaymentReceiptofDebtReceivablePurchaser
            // 
            this.p_PaymentReceiptofDebtReceivablePurchaser.Controls.Add(this.spplyFinancingItemsPanel_Payment);
            this.p_PaymentReceiptofDebtReceivablePurchaser.Controls.Add(this.fileOperatePanel24);
            this.p_PaymentReceiptofDebtReceivablePurchaser.Controls.Add(this.snapSplitter22);
            this.p_PaymentReceiptofDebtReceivablePurchaser.Controls.Add(this.panel33);
            this.p_PaymentReceiptofDebtReceivablePurchaser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_PaymentReceiptofDebtReceivablePurchaser.Location = new System.Drawing.Point(0, 24);
            this.p_PaymentReceiptofDebtReceivablePurchaser.Name = "p_PaymentReceiptofDebtReceivablePurchaser";
            this.p_PaymentReceiptofDebtReceivablePurchaser.Size = new System.Drawing.Size(1000, 476);
            this.p_PaymentReceiptofDebtReceivablePurchaser.TabIndex = 5;
            // 
            // spplyFinancingItemsPanel_Payment
            // 
            this.spplyFinancingItemsPanel_Payment.AppType = CommonClient.EnumTypes.AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser;
            this.spplyFinancingItemsPanel_Payment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.spplyFinancingItemsPanel_Payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spplyFinancingItemsPanel_Payment.Location = new System.Drawing.Point(0, 0);
            this.spplyFinancingItemsPanel_Payment.Name = "spplyFinancingItemsPanel_Payment";
            this.spplyFinancingItemsPanel_Payment.Size = new System.Drawing.Size(520, 426);
            this.spplyFinancingItemsPanel_Payment.TabIndex = 3;
            // 
            // fileOperatePanel24
            // 
            this.fileOperatePanel24.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel24.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel24.Name = "fileOperatePanel24";
            this.fileOperatePanel24.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel24.TabIndex = 2;
            this.fileOperatePanel24.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel24.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel24.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel24.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel24.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel24.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel24.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter22
            // 
            this.snapSplitter22.AnimationDelay = 20;
            this.snapSplitter22.AnimationStep = 20;
            this.snapSplitter22.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter22.ControlToHide = this.panel33;
            this.snapSplitter22.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter22.ExpandParentForm = false;
            this.snapSplitter22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter22.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter22.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter22.Name = "snapSplitter22";
            this.snapSplitter22.TabIndex = 1;
            this.snapSplitter22.TabStop = false;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.spplyFinancing_Payment);
            this.panel33.Controls.Add(this.dataOperatePanel24);
            this.panel33.Controls.Add(this.rowIndexPanel_Payment);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel33.Location = new System.Drawing.Point(540, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(460, 476);
            this.panel33.TabIndex = 0;
            // 
            // spplyFinancing_Payment
            // 
            this.spplyFinancing_Payment.AppType = CommonClient.EnumTypes.AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser;
            this.spplyFinancing_Payment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.spplyFinancing_Payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spplyFinancing_Payment.Location = new System.Drawing.Point(0, 28);
            this.spplyFinancing_Payment.Name = "spplyFinancing_Payment";
            this.spplyFinancing_Payment.Size = new System.Drawing.Size(460, 398);
            this.spplyFinancing_Payment.TabIndex = 2;
            // 
            // dataOperatePanel24
            // 
            this.dataOperatePanel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel24.HasLock = false;
            this.dataOperatePanel24.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel24.Name = "dataOperatePanel24";
            this.dataOperatePanel24.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel24.TabIndex = 1;
            this.dataOperatePanel24.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel24.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel24.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel24.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // rowIndexPanel_Payment
            // 
            this.rowIndexPanel_Payment.AppType = CommonClient.EnumTypes.AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser;
            this.rowIndexPanel_Payment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_Payment.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_Payment.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_Payment.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_Payment.Name = "rowIndexPanel_Payment";
            this.rowIndexPanel_Payment.Size = new System.Drawing.Size(460, 28);
            this.rowIndexPanel_Payment.TabIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(537, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作收付款信息提交(应收账款保理池融资)功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_PaymentReceiptofDebtReceivablePurchaser);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_PaymentReceiptofDebtReceivablePurchaser.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_PaymentReceiptofDebtReceivablePurchaser;
        private SpplyFinancingPayReceiptItemsPanel spplyFinancingItemsPanel_Payment;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel24;
        private SnapSplitter snapSplitter22;
        private System.Windows.Forms.Panel panel33;
        private SpplyFinancingPayReceiptEditor spplyFinancing_Payment;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel24;
        private RowIndexPanel rowIndexPanel_Payment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
