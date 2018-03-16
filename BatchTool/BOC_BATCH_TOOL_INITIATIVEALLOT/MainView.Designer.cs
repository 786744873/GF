using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace BOC_BATCH_TOOL_INITIATIVEALLOT
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
            this.p_InitiativeAllot = new System.Windows.Forms.Panel();
            this.initiativeAllotItemsPanel = new CommonClient.VisualParts2.InitiativeAllotItemsPanel();
            this.fileOperatePanel17 = new CommonClient.VisualParts.FileOperatePanel();
            this.snapSplitter15 = new CommonClient.Controls.SnapSplitter();
            this.panel26 = new System.Windows.Forms.Panel();
            this.initiativeAllotEditor = new CommonClient.VisualParts2.InitiativeAllotEditor();
            this.rowIndexPanel_InitiativeAllot = new CommonClient.VisualParts2.RowIndexPanel();
            this.dataOperatePanel17 = new CommonClient.VisualParts.DataOperatePanel();
            this.batchInitiativeAllotHeader = new CommonClient.VisualParts2.BatchInitiativeAllotHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.p_InitiativeAllot.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_InitiativeAllot
            // 
            this.p_InitiativeAllot.Controls.Add(this.initiativeAllotItemsPanel);
            this.p_InitiativeAllot.Controls.Add(this.fileOperatePanel17);
            this.p_InitiativeAllot.Controls.Add(this.snapSplitter15);
            this.p_InitiativeAllot.Controls.Add(this.panel26);
            this.p_InitiativeAllot.Controls.Add(this.batchInitiativeAllotHeader);
            this.p_InitiativeAllot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_InitiativeAllot.Location = new System.Drawing.Point(0, 24);
            this.p_InitiativeAllot.Name = "p_InitiativeAllot";
            this.p_InitiativeAllot.Size = new System.Drawing.Size(1000, 476);
            this.p_InitiativeAllot.TabIndex = 5;
            // 
            // initiativeAllotItemsPanel
            // 
            this.initiativeAllotItemsPanel.AppType = CommonClient.EnumTypes.AppliableFunctionType.InitiativeAllot;
            this.initiativeAllotItemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.initiativeAllotItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initiativeAllotItemsPanel.Location = new System.Drawing.Point(0, 88);
            this.initiativeAllotItemsPanel.Name = "initiativeAllotItemsPanel";
            this.initiativeAllotItemsPanel.Size = new System.Drawing.Size(520, 338);
            this.initiativeAllotItemsPanel.TabIndex = 7;
            // 
            // fileOperatePanel17
            // 
            this.fileOperatePanel17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileOperatePanel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileOperatePanel17.Location = new System.Drawing.Point(0, 426);
            this.fileOperatePanel17.Name = "fileOperatePanel17";
            this.fileOperatePanel17.Size = new System.Drawing.Size(520, 50);
            this.fileOperatePanel17.TabIndex = 6;
            this.fileOperatePanel17.ButtonNewClicked += new System.EventHandler(this.fileOperatePanel1_ButtonNewClicked);
            this.fileOperatePanel17.ButtonOpenClicked += new System.EventHandler(this.fileOperatePanel1_ButtonOpenClicked);
            this.fileOperatePanel17.ButtonSaveClicked += new System.EventHandler(this.fileOperatePanel1_ButtonSaveClicked);
            this.fileOperatePanel17.ButtonMergFromFileClicked += new System.EventHandler(this.fileOperatePanel1_ButtonMergFromFileClicked);
            this.fileOperatePanel17.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            this.fileOperatePanel17.ButtonUpClicked += new System.EventHandler(this.fileOperatePanel1_ButtonUpClicked);
            this.fileOperatePanel17.ButtonDownClicked += new System.EventHandler(this.fileOperatePanel1_ButtonDownClicked);
            // 
            // snapSplitter15
            // 
            this.snapSplitter15.AnimationDelay = 20;
            this.snapSplitter15.AnimationStep = 20;
            this.snapSplitter15.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter15.ControlToHide = this.panel26;
            this.snapSplitter15.Dock = System.Windows.Forms.DockStyle.Right;
            this.snapSplitter15.ExpandParentForm = false;
            this.snapSplitter15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.snapSplitter15.Location = new System.Drawing.Point(520, 88);
            this.snapSplitter15.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter15.Name = "snapSplitter15";
            this.snapSplitter15.TabIndex = 5;
            this.snapSplitter15.TabStop = false;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.initiativeAllotEditor);
            this.panel26.Controls.Add(this.rowIndexPanel_InitiativeAllot);
            this.panel26.Controls.Add(this.dataOperatePanel17);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel26.Location = new System.Drawing.Point(540, 88);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(460, 388);
            this.panel26.TabIndex = 4;
            // 
            // initiativeAllotEditor
            // 
            this.initiativeAllotEditor.AppType = CommonClient.EnumTypes.AppliableFunctionType.InitiativeAllot;
            this.initiativeAllotEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.initiativeAllotEditor.CanAddIn = false;
            this.initiativeAllotEditor.CanAddOut = false;
            this.initiativeAllotEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initiativeAllotEditor.InitiativeAllot = null;
            this.initiativeAllotEditor.Location = new System.Drawing.Point(0, 28);
            this.initiativeAllotEditor.Name = "initiativeAllotEditor";
            this.initiativeAllotEditor.Size = new System.Drawing.Size(460, 310);
            this.initiativeAllotEditor.TabIndex = 2;
            // 
            // rowIndexPanel_InitiativeAllot
            // 
            this.rowIndexPanel_InitiativeAllot.AppType = CommonClient.EnumTypes.AppliableFunctionType.InitiativeAllot;
            this.rowIndexPanel_InitiativeAllot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.rowIndexPanel_InitiativeAllot.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowIndexPanel_InitiativeAllot.Location = new System.Drawing.Point(0, 0);
            this.rowIndexPanel_InitiativeAllot.Margin = new System.Windows.Forms.Padding(4);
            this.rowIndexPanel_InitiativeAllot.Name = "rowIndexPanel_InitiativeAllot";
            this.rowIndexPanel_InitiativeAllot.Size = new System.Drawing.Size(460, 28);
            this.rowIndexPanel_InitiativeAllot.TabIndex = 1;
            // 
            // dataOperatePanel17
            // 
            this.dataOperatePanel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dataOperatePanel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOperatePanel17.HasLock = false;
            this.dataOperatePanel17.Location = new System.Drawing.Point(0, 338);
            this.dataOperatePanel17.Name = "dataOperatePanel17";
            this.dataOperatePanel17.Size = new System.Drawing.Size(460, 50);
            this.dataOperatePanel17.TabIndex = 0;
            this.dataOperatePanel17.ButtonAddClicked += new System.EventHandler(this.dataOperatePanel1_ButtonAddClicked);
            this.dataOperatePanel17.ButtonEditClicked += new System.EventHandler(this.dataOperatePanel1_ButtonEditClicked);
            this.dataOperatePanel17.ButtonResetClicked += new System.EventHandler(this.dataOperatePanel1_ButtonResetClicked);
            this.dataOperatePanel17.ButtonDeleteClicked += new System.EventHandler(this.dataOperatePanel1_ButtonDeleteClicked);
            // 
            // batchInitiativeAllotHeader
            // 
            this.batchInitiativeAllotHeader.AppType = CommonClient.EnumTypes.AppliableFunctionType.InitiativeAllot;
            this.batchInitiativeAllotHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.batchInitiativeAllotHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.batchInitiativeAllotHeader.IsFileConvert = false;
            this.batchInitiativeAllotHeader.Location = new System.Drawing.Point(0, 0);
            this.batchInitiativeAllotHeader.Name = "batchInitiativeAllotHeader";
            this.batchInitiativeAllotHeader.Size = new System.Drawing.Size(1000, 88);
            this.batchInitiativeAllotHeader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 24);
            this.panel1.TabIndex = 8;
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
            this.label1.Size = new System.Drawing.Size(411, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "通过该功能您可以逐笔填写的方式，制作批量主动调拨功能批量交易信息文件";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_InitiativeAllot);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.p_InitiativeAllot.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_InitiativeAllot;
        private InitiativeAllotItemsPanel initiativeAllotItemsPanel;
        private CommonClient.VisualParts.FileOperatePanel fileOperatePanel17;
        private SnapSplitter snapSplitter15;
        private System.Windows.Forms.Panel panel26;
        private InitiativeAllotEditor initiativeAllotEditor;
        private RowIndexPanel rowIndexPanel_InitiativeAllot;
        private CommonClient.VisualParts.DataOperatePanel dataOperatePanel17;
        private BatchInitiativeAllotHeader batchInitiativeAllotHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
