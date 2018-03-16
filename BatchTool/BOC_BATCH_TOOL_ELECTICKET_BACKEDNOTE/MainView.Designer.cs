using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_ELECTICKET_BACKEDNOTE
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
            this.p_ElecTicketBackNote = new System.Windows.Forms.Panel();
            this.elecTicketBackNoteItemsPanel = new CommonClient.VisualParts2.ElecTicketBackNoteItemsPanel();
            this.fileOperatePanel11 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter3 = new CommonClient.Controls.SnapSplitter();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.rowIndexPanel_BackNote = new CommonClient.VisualParts2.RowIndexPanel();
            this.payerPnl_BackNote = new CommonClient.VisualParts2.PayerSelector();
            this.elecTicketRealteAccount_BackNote = new CommonClient.VisualParts2.ElecTicketRelateAccountSelector();
            this.elecTicketOtherEditor_BackNote = new CommonClient.VisualParts2.ElecTicketOtherPanel();
            this.dataOperatePanel11 = new CommonClient.VisualParts.DataOperatePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_ElecTicketBackNote.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_ElecTicketBackNote
            // 
            this.p_ElecTicketBackNote.Controls.Add(this.elecTicketBackNoteItemsPanel);
            this.p_ElecTicketBackNote.Controls.Add(this.fileOperatePanel11);
            this.p_ElecTicketBackNote.Controls.Add(this.snapSplitter3);
            this.p_ElecTicketBackNote.Controls.Add(this.panel11);
            this.p_ElecTicketBackNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_ElecTicketBackNote.Location = new System.Drawing.Point(0, 24);
            this.p_ElecTicketBackNote.Name = "p_ElecTicketBackNote";
            this.p_ElecTicketBackNote.Size = new System.Drawing.Size(1000, 476);
            this.p_ElecTicketBackNote.TabIndex = 5;
            // 
            // elecTicketBackNoteItemsPanel
            // 
            this.elecTicketBackNoteItemsPanel.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketBackNote;
            this.elecTicketBackNoteItemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketBackNoteItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketBackNoteItemsPanel.Location = new System.Drawing.Point(0, 0);
            this.elecTicketBackNoteItemsPanel.Name = "elecTicketBackNoteItemsPanel";
            this.elecTicketBackNoteItemsPanel.Size = new System.Drawing.Size(520, 426);
            this.elecTicketBackNoteItemsPanel.TabIndex = 1;
            // 
            // fileOperatePanel11
            // 
            this.fileOperatePanel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel11.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel11.Name = "fileOperatePanel11";
            this.fileOperatePanel11.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel11.TabIndex = 2;
            this.fileOperatePanel11.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel11.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel11.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel11.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel11.ButtonMergErrorFileClicked += new System.EventHandler(this.MergErrorFileClicked);
            this.fileOperatePanel11.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel11.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel11.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter3
            // 
            this.snapSplitter3.AnimationDelay = 20;
            this.snapSplitter3.AnimationStep = 20;
            this.snapSplitter3.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter3.ControlToHide = this.panel11;
            this.snapSplitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter3.ExpandParentForm = false;
            this.snapSplitter3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter3.Location = new System.Drawing.Point(520, 0);
            this.snapSplitter3.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter3.Name = "snapSplitter3";
            this.snapSplitter3.TabIndex = 1;
            this.snapSplitter3.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tableLayoutPanel10);
            this.panel11.Controls.Add(this.dataOperatePanel11);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(540, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(460, 476);
            this.panel11.TabIndex = 3;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.96F));
            this.tableLayoutPanel10.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.rowIndexPanel_BackNote, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.payerPnl_BackNote, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.elecTicketRealteAccount_BackNote, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.elecTicketOtherEditor_BackNote, 1, 3);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 4;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(460, 426);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(3, 208);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 215);
            this.label17.TabIndex = 5;
            this.label17.Text = "其他信息";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(3, 96);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 106);
            this.label16.TabIndex = 3;
            this.label16.Text = "被背书人";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowIndexPanel_BackNote
            // 
            this.rowIndexPanel_BackNote.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketBackNote;
            this.rowIndexPanel_BackNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel10.SetColumnSpan(this.rowIndexPanel_BackNote, 2);
            this.rowIndexPanel_BackNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowIndexPanel_BackNote.Location = new System.Drawing.Point(4, 4);
            this.rowIndexPanel_BackNote.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_BackNote.Name = "rowIndexPanel_BackNote";
            this.rowIndexPanel_BackNote.Size = new System.Drawing.Size(452, 27);
            this.rowIndexPanel_BackNote.TabIndex = 0;
            // 
            // payerPnl_BackNote
            // 
            this.payerPnl_BackNote.AccountType = CommonClient.EnumTypes.AccountCategoryType.Empty;
            this.payerPnl_BackNote.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketBackNote;
            this.payerPnl_BackNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel10.SetColumnSpan(this.payerPnl_BackNote, 2);
            this.payerPnl_BackNote.CurrentPayer = null;
            this.payerPnl_BackNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payerPnl_BackNote.Location = new System.Drawing.Point(4, 39);
            this.payerPnl_BackNote.Margin = new System.Windows.Forms.Padding(4);
            this.payerPnl_BackNote.Name = "payerPnl_BackNote";
            this.payerPnl_BackNote.Size = new System.Drawing.Size(452, 50);
            this.payerPnl_BackNote.TabIndex = 2;
            // 
            // elecTicketRealteAccount_BackNote
            // 
            this.elecTicketRealteAccount_BackNote.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketBackNote;
            this.elecTicketRealteAccount_BackNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketRealteAccount_BackNote.CurrentRelateAccount = null;
            this.elecTicketRealteAccount_BackNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketRealteAccount_BackNote.Location = new System.Drawing.Point(62, 96);
            this.elecTicketRealteAccount_BackNote.Name = "elecTicketRealteAccount_BackNote";
            this.elecTicketRealteAccount_BackNote.RelateType = CommonClient.EnumTypes.RelatePersonType.BackNoted;
            this.elecTicketRealteAccount_BackNote.Size = new System.Drawing.Size(395, 106);
            this.elecTicketRealteAccount_BackNote.TabIndex = 4;
            // 
            // elecTicketOtherEditor_BackNote
            // 
            this.elecTicketOtherEditor_BackNote.AppType = CommonClient.EnumTypes.AppliableFunctionType.ElecTicketBackNote;
            this.elecTicketOtherEditor_BackNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.elecTicketOtherEditor_BackNote.BackNote = null;
            this.elecTicketOtherEditor_BackNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecTicketOtherEditor_BackNote.Location = new System.Drawing.Point(62, 208);
            this.elecTicketOtherEditor_BackNote.Name = "elecTicketOtherEditor_BackNote";
            this.elecTicketOtherEditor_BackNote.PayMoney = null;
            this.elecTicketOtherEditor_BackNote.Remit = null;
            this.elecTicketOtherEditor_BackNote.Size = new System.Drawing.Size(395, 215);
            this.elecTicketOtherEditor_BackNote.TabIndex = 6;
            this.elecTicketOtherEditor_BackNote.TipExchange = null;
            // 
            // dataOperatePanel11
            // 
            this.dataOperatePanel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel11.HasLock = false;
            this.dataOperatePanel11.Location = new System.Drawing.Point(0, 426);
            this.dataOperatePanel11.Name = "dataOperatePanel11";
            this.dataOperatePanel11.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel11.TabIndex = 2;
            this.dataOperatePanel11.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel11.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel11.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel11.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
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
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作电票背书功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_ElecTicketBackNote);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_ElecTicketBackNote.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_ElecTicketBackNote;
        private ElecTicketBackNoteItemsPanel elecTicketBackNoteItemsPanel;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel11;
        private SnapSplitter snapSplitter3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private RowIndexPanel rowIndexPanel_BackNote;
        private PayerSelector payerPnl_BackNote;
        private ElecTicketRelateAccountSelector elecTicketRealteAccount_BackNote;
        private ElecTicketOtherPanel elecTicketOtherEditor_BackNote;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;

    }
}
