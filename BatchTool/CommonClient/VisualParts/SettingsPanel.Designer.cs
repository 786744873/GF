using CommonClient.Controls;
using CommonClient.VisualParts2;

namespace CommonClient.VisualParts
{
    partial class SettingsPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPanel));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpFunctionSetting = new System.Windows.Forms.TabPage();
            this.visibleTabSwitcher1 = new VisibleTabSwitchSettings();
            this.btnSaveVisibleTabs = new ThemedButton();
            this.tpFilePWD = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.fileEncryptionSettings3 = new FileEncryptionSettings();
            this.fileEncryptionSettings2 = new FileEncryptionSettings();
            this.fileEncryptionSettings1 = new FileEncryptionSettings();
            this.tpPayerManagement = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.payerItemsPanel2 = new PayerItemsPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDeletePayer = new ThemedButton();
            this.btnSelectRePayer = new ThemedButton();
            this.btnSelectAllPayer = new ThemedButton();
            this.snapSplitter1 = new SnapSplitter();
            this.payerEditor1 = new PayerEditor();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tpPayeeManagement = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.payeeItemsPanel2 = new PayeeItemsPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnDeletePayee = new ThemedButton();
            this.btnSelectRePayee = new ThemedButton();
            this.btnSelectAllPayee = new ThemedButton();
            this.btnExport = new ThemedButton();
            this.btnImport = new ThemedButton();
            this.snapSplitter2 = new SnapSplitter();
            this.payeeEditor2 = new PayeeEditor();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tpElecTicketRelateAccount = new System.Windows.Forms.TabPage();
            this.elecTicketRelateAccountItemsPanel1 = new ElecTicketRelateAccountItemsPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeleteElecTicketRelation = new ThemedButton();
            this.btnSelectReElecTicketRelation = new ThemedButton();
            this.btnSelectAllElecTicketRelation = new ThemedButton();
            this.btnElecExport = new ThemedButton();
            this.btnElecImport = new ThemedButton();
            this.snapSplitter5 = new SnapSplitter();
            this.elecTicketRealteAccountEdit1 = new ElecTicketRelateAccountEditor();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tpOverCountryPayeeManagement = new System.Windows.Forms.TabPage();
            this.transferGlobalPayeeItemsPanel1 = new TransferGlobalPayeeItemsPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDeleteGlobalPayee = new ThemedButton();
            this.btnSelectReGlobalPayee = new ThemedButton();
            this.btnSelectAllGlobalPayee = new ThemedButton();
            this.btnExportTransferGlobalPayee = new ThemedButton();
            this.btnImportTransferGlobalPayee = new ThemedButton();
            this.snapSplitter6 = new SnapSplitter();
            this.transferGlobalPayeeEditor1 = new TransferGlobalPayeeEditor();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tpAgentExpressIn = new System.Windows.Forms.TabPage();
            this.agentExpressPayerItemsPanel1 = new AgentExpressPayerItemsPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDeleteExpressOutPayer = new ThemedButton();
            this.btnSelectReExpressOutPayer = new ThemedButton();
            this.btnSelectAllExpressOutPayer = new ThemedButton();
            this.btnExportAgentExpressPayer = new ThemedButton();
            this.btnImportAgentExpressPayer = new ThemedButton();
            this.snapSplitter7 = new SnapSplitter();
            this.agentExpressPayerEditor = new AgentExpressPayerEditor();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tpInitiativeAllot = new System.Windows.Forms.TabPage();
            this.initiativeAllotAccountItemsPanel1 = new InitiativeAllotAccountItemsPanel();
            this.snapSplitter8 = new SnapSplitter();
            this.initiativeAllotAccountEditor = new InitiativeAllotAccountEditor();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tpVirtualAccount = new System.Windows.Forms.TabPage();
            this.virtualAllotAccountItemsPanel1 = new VirtualAllotAccountItemsPanel();
            this.virtualAllotAccountEditor1 = new VirtualAllotAccountEditor();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tpAddition = new System.Windows.Forms.TabPage();
            this.additionalCommentItemsPanel1 = new AdditionalCommentItemsPanel();
            this.snapSplitter3 = new SnapSplitter();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cmbFunctionTypeForComments = new TabStyleListBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tpMapSetting = new System.Windows.Forms.TabPage();
            this.panel17 = new System.Windows.Forms.Panel();
            this.batchMappingItemsPanel1 = new BatchMappingItemsPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMappingSave = new ThemedButton();
            this.snapSplitter4 = new SnapSplitter();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cmbFunctionTypeForBatchMap = new TabStyleListBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tpCommandFields = new System.Windows.Forms.TabPage();
            this.btnSetFixedInfo = new ThemedButton();
            this.batchCommonItemPanel1 = new BatchCommonItemPanel();
            this.p_Settings = new System.Windows.Forms.Panel();
            this.p_FileConvert = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.llOpenMapSetting = new System.Windows.Forms.LinkLabel();
            this.btnSelectFileToConvert = new ThemedButton();
            this.cmbType = new ComboBoxCanValidate();
            this.cmbDataFile = new TextBoxCanValidate();
            this.label20 = new System.Windows.Forms.Label();
            this.lblDataFile = new System.Windows.Forms.Label();
            this.btnTypeConvert = new ThemedButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tpFunctionSetting.SuspendLayout();
            this.tpFilePWD.SuspendLayout();
            this.tpPayerManagement.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tpPayeeManagement.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tpElecTicketRelateAccount.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel19.SuspendLayout();
            this.tpOverCountryPayeeManagement.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel20.SuspendLayout();
            this.tpAgentExpressIn.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel18.SuspendLayout();
            this.tpInitiativeAllot.SuspendLayout();
            this.panel21.SuspendLayout();
            this.tpVirtualAccount.SuspendLayout();
            this.panel22.SuspendLayout();
            this.tpAddition.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tpMapSetting.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tpCommandFields.SuspendLayout();
            this.p_Settings.SuspendLayout();
            this.p_FileConvert.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpFunctionSetting);
            this.tabControl2.Controls.Add(this.tpFilePWD);
            this.tabControl2.Controls.Add(this.tpPayerManagement);
            this.tabControl2.Controls.Add(this.tpPayeeManagement);
            this.tabControl2.Controls.Add(this.tpElecTicketRelateAccount);
            this.tabControl2.Controls.Add(this.tpOverCountryPayeeManagement);
            this.tabControl2.Controls.Add(this.tpAgentExpressIn);
            this.tabControl2.Controls.Add(this.tpInitiativeAllot);
            this.tabControl2.Controls.Add(this.tpVirtualAccount);
            this.tabControl2.Controls.Add(this.tpAddition);
            this.tabControl2.Controls.Add(this.tpMapSetting);
            this.tabControl2.Controls.Add(this.tpCommandFields);
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.MinimumSize = new System.Drawing.Size(0, 500);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tpFunctionSetting
            // 
            this.tpFunctionSetting.Controls.Add(this.visibleTabSwitcher1);
            this.tpFunctionSetting.Controls.Add(this.btnSaveVisibleTabs);
            resources.ApplyResources(this.tpFunctionSetting, "tpFunctionSetting");
            this.tpFunctionSetting.Name = "tpFunctionSetting";
            this.tpFunctionSetting.UseVisualStyleBackColor = true;
            // 
            // visibleTabSwitcher1
            // 
            this.visibleTabSwitcher1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.visibleTabSwitcher1, "visibleTabSwitcher1");
            this.visibleTabSwitcher1.Name = "visibleTabSwitcher1";
            // 
            // btnSaveVisibleTabs
            // 
            resources.ApplyResources(this.btnSaveVisibleTabs, "btnSaveVisibleTabs");
            this.btnSaveVisibleTabs.Name = "btnSaveVisibleTabs";
            this.btnSaveVisibleTabs.ThemeName = ThemeName.Corp_Red;
            this.btnSaveVisibleTabs.UseVisualStyleBackColor = false;
            this.btnSaveVisibleTabs.Click += new System.EventHandler(this.btnSaveVisibleTabs_Click);
            // 
            // tpFilePWD
            // 
            this.tpFilePWD.Controls.Add(this.label12);
            this.tpFilePWD.Controls.Add(this.fileEncryptionSettings3);
            this.tpFilePWD.Controls.Add(this.fileEncryptionSettings2);
            this.tpFilePWD.Controls.Add(this.fileEncryptionSettings1);
            resources.ApplyResources(this.tpFilePWD, "tpFilePWD");
            this.tpFilePWD.Name = "tpFilePWD";
            this.tpFilePWD.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // fileEncryptionSettings3
            // 
            this.fileEncryptionSettings3.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferForeignMoney;
            this.fileEncryptionSettings3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.fileEncryptionSettings3, "fileEncryptionSettings3");
            this.fileEncryptionSettings3.Name = "fileEncryptionSettings3";
            // 
            // fileEncryptionSettings2
            // 
            this.fileEncryptionSettings2.AppType = CommonClient.EnumTypes.AppliableFunctionType.TransferOverCountry;
            this.fileEncryptionSettings2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.fileEncryptionSettings2, "fileEncryptionSettings2");
            this.fileEncryptionSettings2.Name = "fileEncryptionSettings2";
            // 
            // fileEncryptionSettings1
            // 
            this.fileEncryptionSettings1.AppType = CommonClient.EnumTypes.AppliableFunctionType.AgentExpressOut;
            this.fileEncryptionSettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.fileEncryptionSettings1, "fileEncryptionSettings1");
            this.fileEncryptionSettings1.Name = "fileEncryptionSettings1";
            // 
            // tpPayerManagement
            // 
            this.tpPayerManagement.Controls.Add(this.panel7);
            this.tpPayerManagement.Controls.Add(this.panel8);
            resources.ApplyResources(this.tpPayerManagement, "tpPayerManagement");
            this.tpPayerManagement.Name = "tpPayerManagement";
            this.tpPayerManagement.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.payerItemsPanel2);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.snapSplitter1);
            this.panel7.Controls.Add(this.payerEditor1);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
            // 
            // payerItemsPanel2
            // 
            this.payerItemsPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.payerItemsPanel2, "payerItemsPanel2");
            this.payerItemsPanel2.Name = "payerItemsPanel2";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnDeletePayer);
            this.panel6.Controls.Add(this.btnSelectRePayer);
            this.panel6.Controls.Add(this.btnSelectAllPayer);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // btnDeletePayer
            // 
            resources.ApplyResources(this.btnDeletePayer, "btnDeletePayer");
            this.btnDeletePayer.Name = "btnDeletePayer";
            this.btnDeletePayer.UseVisualStyleBackColor = false;
            this.btnDeletePayer.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectRePayer
            // 
            resources.ApplyResources(this.btnSelectRePayer, "btnSelectRePayer");
            this.btnSelectRePayer.Name = "btnSelectRePayer";
            this.btnSelectRePayer.UseVisualStyleBackColor = false;
            this.btnSelectRePayer.Click += new System.EventHandler(this.btnSelectRe_Click);
            // 
            // btnSelectAllPayer
            // 
            resources.ApplyResources(this.btnSelectAllPayer, "btnSelectAllPayer");
            this.btnSelectAllPayer.Name = "btnSelectAllPayer";
            this.btnSelectAllPayer.UseVisualStyleBackColor = false;
            this.btnSelectAllPayer.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // snapSplitter1
            // 
            this.snapSplitter1.AnimationDelay = 20;
            this.snapSplitter1.AnimationStep = 20;
            this.snapSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter1.ControlToHide = this.payerEditor1;
            this.snapSplitter1.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter1, "snapSplitter1");
            this.snapSplitter1.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter1.Name = "snapSplitter1";
            this.snapSplitter1.TabStop = false;
            // 
            // payerEditor1
            // 
            this.payerEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.payerEditor1, "payerEditor1");
            this.payerEditor1.MinimumSize = new System.Drawing.Size(370, 400);
            this.payerEditor1.Name = "payerEditor1";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label1);
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.Name = "panel8";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tpPayeeManagement
            // 
            this.tpPayeeManagement.Controls.Add(this.panel2);
            this.tpPayeeManagement.Controls.Add(this.panel9);
            resources.ApplyResources(this.tpPayeeManagement, "tpPayeeManagement");
            this.tpPayeeManagement.Name = "tpPayeeManagement";
            this.tpPayeeManagement.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.payeeItemsPanel2);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.snapSplitter2);
            this.panel2.Controls.Add(this.payeeEditor2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // payeeItemsPanel2
            // 
            this.payeeItemsPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.payeeItemsPanel2, "payeeItemsPanel2");
            this.payeeItemsPanel2.Name = "payeeItemsPanel2";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnDeletePayee);
            this.panel10.Controls.Add(this.btnSelectRePayee);
            this.panel10.Controls.Add(this.btnSelectAllPayee);
            this.panel10.Controls.Add(this.btnExport);
            this.panel10.Controls.Add(this.btnImport);
            resources.ApplyResources(this.panel10, "panel10");
            this.panel10.Name = "panel10";
            // 
            // btnDeletePayee
            // 
            resources.ApplyResources(this.btnDeletePayee, "btnDeletePayee");
            this.btnDeletePayee.Name = "btnDeletePayee";
            this.btnDeletePayee.UseVisualStyleBackColor = false;
            this.btnDeletePayee.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectRePayee
            // 
            resources.ApplyResources(this.btnSelectRePayee, "btnSelectRePayee");
            this.btnSelectRePayee.Name = "btnSelectRePayee";
            this.btnSelectRePayee.UseVisualStyleBackColor = false;
            this.btnSelectRePayee.Click += new System.EventHandler(this.btnSelectRe_Click);
            // 
            // btnSelectAllPayee
            // 
            resources.ApplyResources(this.btnSelectAllPayee, "btnSelectAllPayee");
            this.btnSelectAllPayee.Name = "btnSelectAllPayee";
            this.btnSelectAllPayee.UseVisualStyleBackColor = false;
            this.btnSelectAllPayee.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            this.btnImport.MouseHover += new System.EventHandler(this.btnImport_MouseHover);
            // 
            // snapSplitter2
            // 
            this.snapSplitter2.AnimationDelay = 20;
            this.snapSplitter2.AnimationStep = 20;
            this.snapSplitter2.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter2.ControlToHide = this.payeeEditor2;
            this.snapSplitter2.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter2, "snapSplitter2");
            this.snapSplitter2.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter2.Name = "snapSplitter2";
            this.snapSplitter2.TabStop = false;
            // 
            // payeeEditor2
            // 
            this.payeeEditor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.payeeEditor2, "payeeEditor2");
            this.payeeEditor2.Name = "payeeEditor2";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label2);
            resources.ApplyResources(this.panel9, "panel9");
            this.panel9.Name = "panel9";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tpElecTicketRelateAccount
            // 
            this.tpElecTicketRelateAccount.Controls.Add(this.elecTicketRelateAccountItemsPanel1);
            this.tpElecTicketRelateAccount.Controls.Add(this.panel3);
            this.tpElecTicketRelateAccount.Controls.Add(this.snapSplitter5);
            this.tpElecTicketRelateAccount.Controls.Add(this.elecTicketRealteAccountEdit1);
            this.tpElecTicketRelateAccount.Controls.Add(this.panel19);
            resources.ApplyResources(this.tpElecTicketRelateAccount, "tpElecTicketRelateAccount");
            this.tpElecTicketRelateAccount.Name = "tpElecTicketRelateAccount";
            this.tpElecTicketRelateAccount.UseVisualStyleBackColor = true;
            // 
            // elecTicketRelateAccountItemsPanel1
            // 
            this.elecTicketRelateAccountItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.elecTicketRelateAccountItemsPanel1, "elecTicketRelateAccountItemsPanel1");
            this.elecTicketRelateAccountItemsPanel1.Name = "elecTicketRelateAccountItemsPanel1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDeleteElecTicketRelation);
            this.panel3.Controls.Add(this.btnSelectReElecTicketRelation);
            this.panel3.Controls.Add(this.btnSelectAllElecTicketRelation);
            this.panel3.Controls.Add(this.btnElecExport);
            this.panel3.Controls.Add(this.btnElecImport);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnDeleteElecTicketRelation
            // 
            resources.ApplyResources(this.btnDeleteElecTicketRelation, "btnDeleteElecTicketRelation");
            this.btnDeleteElecTicketRelation.Name = "btnDeleteElecTicketRelation";
            this.btnDeleteElecTicketRelation.UseVisualStyleBackColor = false;
            this.btnDeleteElecTicketRelation.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectReElecTicketRelation
            // 
            resources.ApplyResources(this.btnSelectReElecTicketRelation, "btnSelectReElecTicketRelation");
            this.btnSelectReElecTicketRelation.Name = "btnSelectReElecTicketRelation";
            this.btnSelectReElecTicketRelation.UseVisualStyleBackColor = false;
            this.btnSelectReElecTicketRelation.Click += new System.EventHandler(this.btnSelectRe_Click);
            // 
            // btnSelectAllElecTicketRelation
            // 
            resources.ApplyResources(this.btnSelectAllElecTicketRelation, "btnSelectAllElecTicketRelation");
            this.btnSelectAllElecTicketRelation.Name = "btnSelectAllElecTicketRelation";
            this.btnSelectAllElecTicketRelation.UseVisualStyleBackColor = false;
            this.btnSelectAllElecTicketRelation.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnElecExport
            // 
            resources.ApplyResources(this.btnElecExport, "btnElecExport");
            this.btnElecExport.Name = "btnElecExport";
            this.btnElecExport.UseVisualStyleBackColor = true;
            this.btnElecExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnElecImport
            // 
            resources.ApplyResources(this.btnElecImport, "btnElecImport");
            this.btnElecImport.Name = "btnElecImport";
            this.btnElecImport.UseVisualStyleBackColor = true;
            this.btnElecImport.Click += new System.EventHandler(this.btnImport_Click);
            this.btnElecImport.MouseHover += new System.EventHandler(this.btnImport_MouseHover);
            // 
            // snapSplitter5
            // 
            this.snapSplitter5.AnimationDelay = 20;
            this.snapSplitter5.AnimationStep = 20;
            this.snapSplitter5.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter5.ControlToHide = this.elecTicketRealteAccountEdit1;
            this.snapSplitter5.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter5, "snapSplitter5");
            this.snapSplitter5.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter5.Name = "snapSplitter5";
            this.snapSplitter5.TabStop = false;
            // 
            // elecTicketRealteAccountEdit1
            // 
            this.elecTicketRealteAccountEdit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.elecTicketRealteAccountEdit1, "elecTicketRealteAccountEdit1");
            this.elecTicketRealteAccountEdit1.MinimumSize = new System.Drawing.Size(380, 410);
            this.elecTicketRealteAccountEdit1.Name = "elecTicketRealteAccountEdit1";
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.label9);
            resources.ApplyResources(this.panel19, "panel19");
            this.panel19.Name = "panel19";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tpOverCountryPayeeManagement
            // 
            this.tpOverCountryPayeeManagement.Controls.Add(this.transferGlobalPayeeItemsPanel1);
            this.tpOverCountryPayeeManagement.Controls.Add(this.panel4);
            this.tpOverCountryPayeeManagement.Controls.Add(this.snapSplitter6);
            this.tpOverCountryPayeeManagement.Controls.Add(this.transferGlobalPayeeEditor1);
            this.tpOverCountryPayeeManagement.Controls.Add(this.panel20);
            resources.ApplyResources(this.tpOverCountryPayeeManagement, "tpOverCountryPayeeManagement");
            this.tpOverCountryPayeeManagement.Name = "tpOverCountryPayeeManagement";
            this.tpOverCountryPayeeManagement.UseVisualStyleBackColor = true;
            // 
            // transferGlobalPayeeItemsPanel1
            // 
            this.transferGlobalPayeeItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.transferGlobalPayeeItemsPanel1, "transferGlobalPayeeItemsPanel1");
            this.transferGlobalPayeeItemsPanel1.Name = "transferGlobalPayeeItemsPanel1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDeleteGlobalPayee);
            this.panel4.Controls.Add(this.btnSelectReGlobalPayee);
            this.panel4.Controls.Add(this.btnSelectAllGlobalPayee);
            this.panel4.Controls.Add(this.btnExportTransferGlobalPayee);
            this.panel4.Controls.Add(this.btnImportTransferGlobalPayee);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // btnDeleteGlobalPayee
            // 
            resources.ApplyResources(this.btnDeleteGlobalPayee, "btnDeleteGlobalPayee");
            this.btnDeleteGlobalPayee.Name = "btnDeleteGlobalPayee";
            this.btnDeleteGlobalPayee.UseVisualStyleBackColor = false;
            this.btnDeleteGlobalPayee.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectReGlobalPayee
            // 
            resources.ApplyResources(this.btnSelectReGlobalPayee, "btnSelectReGlobalPayee");
            this.btnSelectReGlobalPayee.Name = "btnSelectReGlobalPayee";
            this.btnSelectReGlobalPayee.UseVisualStyleBackColor = false;
            this.btnSelectReGlobalPayee.Click += new System.EventHandler(this.btnSelectRe_Click);
            // 
            // btnSelectAllGlobalPayee
            // 
            resources.ApplyResources(this.btnSelectAllGlobalPayee, "btnSelectAllGlobalPayee");
            this.btnSelectAllGlobalPayee.Name = "btnSelectAllGlobalPayee";
            this.btnSelectAllGlobalPayee.UseVisualStyleBackColor = false;
            this.btnSelectAllGlobalPayee.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnExportTransferGlobalPayee
            // 
            resources.ApplyResources(this.btnExportTransferGlobalPayee, "btnExportTransferGlobalPayee");
            this.btnExportTransferGlobalPayee.Name = "btnExportTransferGlobalPayee";
            this.btnExportTransferGlobalPayee.UseVisualStyleBackColor = true;
            this.btnExportTransferGlobalPayee.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImportTransferGlobalPayee
            // 
            resources.ApplyResources(this.btnImportTransferGlobalPayee, "btnImportTransferGlobalPayee");
            this.btnImportTransferGlobalPayee.Name = "btnImportTransferGlobalPayee";
            this.btnImportTransferGlobalPayee.UseVisualStyleBackColor = true;
            this.btnImportTransferGlobalPayee.Click += new System.EventHandler(this.btnImport_Click);
            this.btnImportTransferGlobalPayee.MouseHover += new System.EventHandler(this.btnImport_MouseHover);
            // 
            // snapSplitter6
            // 
            this.snapSplitter6.AnimationDelay = 20;
            this.snapSplitter6.AnimationStep = 20;
            this.snapSplitter6.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter6.ControlToHide = this.transferGlobalPayeeEditor1;
            this.snapSplitter6.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter6, "snapSplitter6");
            this.snapSplitter6.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter6.Name = "snapSplitter6";
            this.snapSplitter6.TabStop = false;
            // 
            // transferGlobalPayeeEditor1
            // 
            this.transferGlobalPayeeEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.transferGlobalPayeeEditor1, "transferGlobalPayeeEditor1");
            this.transferGlobalPayeeEditor1.Name = "transferGlobalPayeeEditor1";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.label10);
            resources.ApplyResources(this.panel20, "panel20");
            this.panel20.Name = "panel20";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tpAgentExpressIn
            // 
            this.tpAgentExpressIn.Controls.Add(this.agentExpressPayerItemsPanel1);
            this.tpAgentExpressIn.Controls.Add(this.panel5);
            this.tpAgentExpressIn.Controls.Add(this.snapSplitter7);
            this.tpAgentExpressIn.Controls.Add(this.agentExpressPayerEditor);
            this.tpAgentExpressIn.Controls.Add(this.panel18);
            resources.ApplyResources(this.tpAgentExpressIn, "tpAgentExpressIn");
            this.tpAgentExpressIn.Name = "tpAgentExpressIn";
            this.tpAgentExpressIn.UseVisualStyleBackColor = true;
            // 
            // agentExpressPayerItemsPanel1
            // 
            this.agentExpressPayerItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.agentExpressPayerItemsPanel1, "agentExpressPayerItemsPanel1");
            this.agentExpressPayerItemsPanel1.Name = "agentExpressPayerItemsPanel1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDeleteExpressOutPayer);
            this.panel5.Controls.Add(this.btnSelectReExpressOutPayer);
            this.panel5.Controls.Add(this.btnSelectAllExpressOutPayer);
            this.panel5.Controls.Add(this.btnExportAgentExpressPayer);
            this.panel5.Controls.Add(this.btnImportAgentExpressPayer);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // btnDeleteExpressOutPayer
            // 
            resources.ApplyResources(this.btnDeleteExpressOutPayer, "btnDeleteExpressOutPayer");
            this.btnDeleteExpressOutPayer.Name = "btnDeleteExpressOutPayer";
            this.btnDeleteExpressOutPayer.UseVisualStyleBackColor = false;
            this.btnDeleteExpressOutPayer.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectReExpressOutPayer
            // 
            resources.ApplyResources(this.btnSelectReExpressOutPayer, "btnSelectReExpressOutPayer");
            this.btnSelectReExpressOutPayer.Name = "btnSelectReExpressOutPayer";
            this.btnSelectReExpressOutPayer.UseVisualStyleBackColor = false;
            this.btnSelectReExpressOutPayer.Click += new System.EventHandler(this.btnSelectRe_Click);
            // 
            // btnSelectAllExpressOutPayer
            // 
            resources.ApplyResources(this.btnSelectAllExpressOutPayer, "btnSelectAllExpressOutPayer");
            this.btnSelectAllExpressOutPayer.Name = "btnSelectAllExpressOutPayer";
            this.btnSelectAllExpressOutPayer.UseVisualStyleBackColor = false;
            this.btnSelectAllExpressOutPayer.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnExportAgentExpressPayer
            // 
            resources.ApplyResources(this.btnExportAgentExpressPayer, "btnExportAgentExpressPayer");
            this.btnExportAgentExpressPayer.Name = "btnExportAgentExpressPayer";
            this.btnExportAgentExpressPayer.UseVisualStyleBackColor = true;
            this.btnExportAgentExpressPayer.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImportAgentExpressPayer
            // 
            resources.ApplyResources(this.btnImportAgentExpressPayer, "btnImportAgentExpressPayer");
            this.btnImportAgentExpressPayer.Name = "btnImportAgentExpressPayer";
            this.btnImportAgentExpressPayer.UseVisualStyleBackColor = true;
            this.btnImportAgentExpressPayer.Click += new System.EventHandler(this.btnImport_Click);
            this.btnImportAgentExpressPayer.MouseHover += new System.EventHandler(this.btnImport_MouseHover);
            // 
            // snapSplitter7
            // 
            this.snapSplitter7.AnimationDelay = 20;
            this.snapSplitter7.AnimationStep = 20;
            this.snapSplitter7.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter7.ControlToHide = this.agentExpressPayerEditor;
            this.snapSplitter7.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter7, "snapSplitter7");
            this.snapSplitter7.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter7.Name = "snapSplitter7";
            this.snapSplitter7.TabStop = false;
            // 
            // agentExpressPayerEditor
            // 
            this.agentExpressPayerEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.agentExpressPayerEditor, "agentExpressPayerEditor");
            this.agentExpressPayerEditor.Name = "agentExpressPayerEditor";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.label8);
            resources.ApplyResources(this.panel18, "panel18");
            this.panel18.Name = "panel18";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tpInitiativeAllot
            // 
            this.tpInitiativeAllot.Controls.Add(this.initiativeAllotAccountItemsPanel1);
            this.tpInitiativeAllot.Controls.Add(this.snapSplitter8);
            this.tpInitiativeAllot.Controls.Add(this.initiativeAllotAccountEditor);
            this.tpInitiativeAllot.Controls.Add(this.panel21);
            resources.ApplyResources(this.tpInitiativeAllot, "tpInitiativeAllot");
            this.tpInitiativeAllot.Name = "tpInitiativeAllot";
            this.tpInitiativeAllot.UseVisualStyleBackColor = true;
            // 
            // initiativeAllotAccountItemsPanel1
            // 
            this.initiativeAllotAccountItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.initiativeAllotAccountItemsPanel1, "initiativeAllotAccountItemsPanel1");
            this.initiativeAllotAccountItemsPanel1.Name = "initiativeAllotAccountItemsPanel1";
            // 
            // snapSplitter8
            // 
            this.snapSplitter8.AnimationDelay = 20;
            this.snapSplitter8.AnimationStep = 20;
            this.snapSplitter8.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter8.ControlToHide = this.initiativeAllotAccountEditor;
            this.snapSplitter8.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter8, "snapSplitter8");
            this.snapSplitter8.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter8.Name = "snapSplitter8";
            this.snapSplitter8.TabStop = false;
            // 
            // initiativeAllotAccountEditor
            // 
            this.initiativeAllotAccountEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.initiativeAllotAccountEditor, "initiativeAllotAccountEditor");
            this.initiativeAllotAccountEditor.Name = "initiativeAllotAccountEditor";
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.label11);
            resources.ApplyResources(this.panel21, "panel21");
            this.panel21.Name = "panel21";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tpVirtualAccount
            // 
            this.tpVirtualAccount.Controls.Add(this.virtualAllotAccountItemsPanel1);
            this.tpVirtualAccount.Controls.Add(this.virtualAllotAccountEditor1);
            this.tpVirtualAccount.Controls.Add(this.panel22);
            resources.ApplyResources(this.tpVirtualAccount, "tpVirtualAccount");
            this.tpVirtualAccount.Name = "tpVirtualAccount";
            this.tpVirtualAccount.UseVisualStyleBackColor = true;
            // 
            // virtualAllotAccountItemsPanel1
            // 
            this.virtualAllotAccountItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.virtualAllotAccountItemsPanel1, "virtualAllotAccountItemsPanel1");
            this.virtualAllotAccountItemsPanel1.Name = "virtualAllotAccountItemsPanel1";
            // 
            // virtualAllotAccountEditor1
            // 
            this.virtualAllotAccountEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.virtualAllotAccountEditor1, "virtualAllotAccountEditor1");
            this.virtualAllotAccountEditor1.Name = "virtualAllotAccountEditor1";
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.label13);
            resources.ApplyResources(this.panel22, "panel22");
            this.panel22.Name = "panel22";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // tpAddition
            // 
            this.tpAddition.Controls.Add(this.additionalCommentItemsPanel1);
            this.tpAddition.Controls.Add(this.snapSplitter3);
            this.tpAddition.Controls.Add(this.panel11);
            this.tpAddition.Controls.Add(this.panel13);
            resources.ApplyResources(this.tpAddition, "tpAddition");
            this.tpAddition.Name = "tpAddition";
            this.tpAddition.UseVisualStyleBackColor = true;
            // 
            // additionalCommentItemsPanel1
            // 
            this.additionalCommentItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.additionalCommentItemsPanel1, "additionalCommentItemsPanel1");
            this.additionalCommentItemsPanel1.Name = "additionalCommentItemsPanel1";
            // 
            // snapSplitter3
            // 
            this.snapSplitter3.AnimationDelay = 20;
            this.snapSplitter3.AnimationStep = 20;
            this.snapSplitter3.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter3.ControlToHide = this.panel11;
            this.snapSplitter3.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter3, "snapSplitter3");
            this.snapSplitter3.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter3.Name = "snapSplitter3";
            this.snapSplitter3.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.cmbFunctionTypeForComments);
            this.panel11.Controls.Add(this.panel12);
            resources.ApplyResources(this.panel11, "panel11");
            this.panel11.Name = "panel11";
            // 
            // cmbFunctionTypeForComments
            // 
            resources.ApplyResources(this.cmbFunctionTypeForComments, "cmbFunctionTypeForComments");
            this.cmbFunctionTypeForComments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFunctionTypeForComments.FormattingEnabled = true;
            this.cmbFunctionTypeForComments.Name = "cmbFunctionTypeForComments";
            this.cmbFunctionTypeForComments.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionTypeForComments_SelectedIndexChanged);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label4);
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label5);
            resources.ApplyResources(this.panel13, "panel13");
            this.panel13.Name = "panel13";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tpMapSetting
            // 
            this.tpMapSetting.Controls.Add(this.panel17);
            this.tpMapSetting.Controls.Add(this.panel16);
            resources.ApplyResources(this.tpMapSetting, "tpMapSetting");
            this.tpMapSetting.Name = "tpMapSetting";
            this.tpMapSetting.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.batchMappingItemsPanel1);
            this.panel17.Controls.Add(this.panel1);
            this.panel17.Controls.Add(this.snapSplitter4);
            this.panel17.Controls.Add(this.panel14);
            resources.ApplyResources(this.panel17, "panel17");
            this.panel17.Name = "panel17";
            // 
            // batchMappingItemsPanel1
            // 
            this.batchMappingItemsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.batchMappingItemsPanel1, "batchMappingItemsPanel1");
            this.batchMappingItemsPanel1.Name = "batchMappingItemsPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMappingSave);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnMappingSave
            // 
            resources.ApplyResources(this.btnMappingSave, "btnMappingSave");
            this.btnMappingSave.Name = "btnMappingSave";
            this.btnMappingSave.ThemeName = ThemeName.Corp_Red;
            this.btnMappingSave.UseVisualStyleBackColor = false;
            this.btnMappingSave.Click += new System.EventHandler(this.btnMappingSave_Click);
            // 
            // snapSplitter4
            // 
            this.snapSplitter4.AnimationDelay = 20;
            this.snapSplitter4.AnimationStep = 20;
            this.snapSplitter4.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.snapSplitter4.ControlToHide = this.panel14;
            this.snapSplitter4.ExpandParentForm = false;
            resources.ApplyResources(this.snapSplitter4, "snapSplitter4");
            this.snapSplitter4.MinimumSize = new System.Drawing.Size(20, 20);
            this.snapSplitter4.Name = "snapSplitter4";
            this.snapSplitter4.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.cmbFunctionTypeForBatchMap);
            this.panel14.Controls.Add(this.panel15);
            resources.ApplyResources(this.panel14, "panel14");
            this.panel14.Name = "panel14";
            // 
            // cmbFunctionTypeForBatchMap
            // 
            resources.ApplyResources(this.cmbFunctionTypeForBatchMap, "cmbFunctionTypeForBatchMap");
            this.cmbFunctionTypeForBatchMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFunctionTypeForBatchMap.FormattingEnabled = true;
            this.cmbFunctionTypeForBatchMap.Name = "cmbFunctionTypeForBatchMap";
            this.cmbFunctionTypeForBatchMap.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionTypeForBatchMap_SelectedIndexChanged);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label6);
            resources.ApplyResources(this.panel15, "panel15");
            this.panel15.Name = "panel15";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label7);
            resources.ApplyResources(this.panel16, "panel16");
            this.panel16.Name = "panel16";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tpCommandFields
            // 
            this.tpCommandFields.Controls.Add(this.btnSetFixedInfo);
            this.tpCommandFields.Controls.Add(this.batchCommonItemPanel1);
            resources.ApplyResources(this.tpCommandFields, "tpCommandFields");
            this.tpCommandFields.Name = "tpCommandFields";
            this.tpCommandFields.UseVisualStyleBackColor = true;
            // 
            // btnSetFixedInfo
            // 
            resources.ApplyResources(this.btnSetFixedInfo, "btnSetFixedInfo");
            this.btnSetFixedInfo.Name = "btnSetFixedInfo";
            this.btnSetFixedInfo.ThemeName = ThemeName.Corp_Red;
            this.btnSetFixedInfo.UseVisualStyleBackColor = false;
            this.btnSetFixedInfo.Click += new System.EventHandler(this.btnSetFixedInfo_Click);
            // 
            // batchCommonItemPanel1
            // 
            this.batchCommonItemPanel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.batchCommonItemPanel1, "batchCommonItemPanel1");
            this.batchCommonItemPanel1.Name = "batchCommonItemPanel1";
            // 
            // p_Settings
            // 
            resources.ApplyResources(this.p_Settings, "p_Settings");
            this.p_Settings.Controls.Add(this.tabControl2);
            this.p_Settings.Name = "p_Settings";
            // 
            // p_FileConvert
            // 
            this.p_FileConvert.Controls.Add(this.label3);
            this.p_FileConvert.Controls.Add(this.groupBox6);
            this.p_FileConvert.Controls.Add(this.btnTypeConvert);
            resources.ApplyResources(this.p_FileConvert, "p_FileConvert");
            this.p_FileConvert.Name = "p_FileConvert";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.llOpenMapSetting);
            this.groupBox6.Controls.Add(this.btnSelectFileToConvert);
            this.groupBox6.Controls.Add(this.cmbType);
            this.groupBox6.Controls.Add(this.cmbDataFile);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.lblDataFile);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // llOpenMapSetting
            // 
            resources.ApplyResources(this.llOpenMapSetting, "llOpenMapSetting");
            this.llOpenMapSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llOpenMapSetting.Name = "llOpenMapSetting";
            this.llOpenMapSetting.TabStop = true;
            this.llOpenMapSetting.Click += new System.EventHandler(this.llOpenMapSetting_Click);
            // 
            // btnSelectFileToConvert
            // 
            resources.ApplyResources(this.btnSelectFileToConvert, "btnSelectFileToConvert");
            this.btnSelectFileToConvert.Name = "btnSelectFileToConvert";
            this.btnSelectFileToConvert.UseVisualStyleBackColor = true;
            this.btnSelectFileToConvert.Click += new System.EventHandler(this.btnSelectFileToConvert_Click);
            // 
            // cmbType
            // 
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.DvEditorValueChanged = false;
            this.cmbType.DvErrorProvider = errorProvider1;
            this.cmbType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbType, "cmbType");
            this.cmbType.Name = "cmbType";
            this.cmbType.DvValidateEnabled =true;
            this.cmbType.DvMaxLength = 0;
            this.cmbType.DvMinLength = 0;
            this.cmbType.DvRequired = false;
            // 
            // cmbDataFile
            // 
            this.cmbDataFile.DvEditorValueChanged = false;
            resources.ApplyResources(this.cmbDataFile, "cmbDataFile");
            this.cmbDataFile.DvErrorProvider = errorProvider1;
            this.cmbDataFile.Name = "cmbDataFile";
            this.cmbDataFile.DvValidateEnabled =true;
            this.cmbDataFile.DvMaxLength = 0;
            this.cmbDataFile.DvMinLength = 0;
            this.cmbDataFile.DvRequired = false;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // lblDataFile
            // 
            resources.ApplyResources(this.lblDataFile, "lblDataFile");
            this.lblDataFile.Name = "lblDataFile";
            // 
            // btnTypeConvert
            // 
            resources.ApplyResources(this.btnTypeConvert, "btnTypeConvert");
            this.btnTypeConvert.Name = "btnTypeConvert";
            this.btnTypeConvert.UseVisualStyleBackColor = true;
            this.btnTypeConvert.Click += new System.EventHandler(this.btnTypeConvert_Click);
            // 
            // SettingsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.p_Settings);
            this.Controls.Add(this.p_FileConvert);
            resources.ApplyResources(this, "$this");
            this.MinimumSize = new System.Drawing.Size(0, 510);
            this.Name = "SettingsPanel";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tpFunctionSetting.ResumeLayout(false);
            this.tpFilePWD.ResumeLayout(false);
            this.tpFilePWD.PerformLayout();
            this.tpPayerManagement.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tpPayeeManagement.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tpElecTicketRelateAccount.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.tpOverCountryPayeeManagement.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.tpAgentExpressIn.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.tpInitiativeAllot.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.tpVirtualAccount.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.tpAddition.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.tpMapSetting.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.tpCommandFields.ResumeLayout(false);
            this.p_Settings.ResumeLayout(false);
            this.p_FileConvert.ResumeLayout(false);
            this.p_FileConvert.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpFunctionSetting;
        private VisibleTabSwitchSettings visibleTabSwitcher1;
        private ThemedButton btnSaveVisibleTabs;
        private System.Windows.Forms.TabPage tpFilePWD;
        private FileEncryptionSettings fileEncryptionSettings1;
        private System.Windows.Forms.TabPage tpPayerManagement;
        private System.Windows.Forms.TabPage tpPayeeManagement;
        private System.Windows.Forms.TabPage tpAddition;
        private System.Windows.Forms.TabPage tpMapSetting;
        private ThemedButton btnSetFixedInfo;
        private BatchCommonItemPanel batchCommonItemPanel1;
        private System.Windows.Forms.Panel p_Settings;
        private System.Windows.Forms.Panel p_FileConvert;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.LinkLabel llOpenMapSetting;
        private ThemedButton btnSelectFileToConvert;
        private ComboBoxCanValidate cmbType;
        private TextBoxCanValidate cmbDataFile;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblDataFile;
        private ThemedButton btnTypeConvert;
        private System.Windows.Forms.TabPage tpElecTicketRelateAccount;
        private System.Windows.Forms.TabPage tpOverCountryPayeeManagement;
        private FileEncryptionSettings fileEncryptionSettings2;
        private FileEncryptionSettings fileEncryptionSettings3;
        private System.Windows.Forms.TabPage tpInitiativeAllot;
        private System.Windows.Forms.TabPage tpAgentExpressIn;
        private System.Windows.Forms.TabPage tpCommandFields;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private ThemedButton btnDeletePayer;
        private ThemedButton btnSelectRePayer;
        private ThemedButton btnSelectAllPayer;
        private SnapSplitter snapSplitter1;
        private PayerEditor payerEditor1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private PayerItemsPanel payerItemsPanel2;
        private System.Windows.Forms.Panel panel2;
        private PayeeItemsPanel payeeItemsPanel2;
        private System.Windows.Forms.Panel panel10;
        private ThemedButton btnDeletePayee;
        private ThemedButton btnSelectRePayee;
        private ThemedButton btnSelectAllPayee;
        private ThemedButton btnExport;
        private ThemedButton btnImport;
        private SnapSplitter snapSplitter2;
        private PayeeEditor payeeEditor2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private AdditionalCommentItemsPanel additionalCommentItemsPanel1;
        private SnapSplitter snapSplitter3;
        private System.Windows.Forms.Panel panel11;
        private TabStyleListBox cmbFunctionTypeForComments;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel14;
        private Controls.TabStyleListBox cmbFunctionTypeForBatchMap;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label8;
        private AgentExpressPayerItemsPanel agentExpressPayerItemsPanel1;
        private System.Windows.Forms.Panel panel5;
        private ThemedButton btnDeleteExpressOutPayer;
        private ThemedButton btnSelectReExpressOutPayer;
        private ThemedButton btnSelectAllExpressOutPayer;
        private ThemedButton btnExportAgentExpressPayer;
        private ThemedButton btnImportAgentExpressPayer;
        private SnapSplitter snapSplitter7;
        private AgentExpressPayerEditor agentExpressPayerEditor;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Label label10;
        private ElecTicketRelateAccountItemsPanel elecTicketRelateAccountItemsPanel1;
        private System.Windows.Forms.Panel panel3;
        private ThemedButton btnDeleteElecTicketRelation;
        private ThemedButton btnSelectReElecTicketRelation;
        private ThemedButton btnSelectAllElecTicketRelation;
        private ThemedButton btnElecExport;
        private ThemedButton btnElecImport;
        private SnapSplitter snapSplitter5;
        private ElecTicketRelateAccountEditor elecTicketRealteAccountEdit1;
        private TransferGlobalPayeeItemsPanel transferGlobalPayeeItemsPanel1;
        private System.Windows.Forms.Panel panel4;
        private ThemedButton btnDeleteGlobalPayee;
        private ThemedButton btnSelectReGlobalPayee;
        private ThemedButton btnSelectAllGlobalPayee;
        private ThemedButton btnExportTransferGlobalPayee;
        private ThemedButton btnImportTransferGlobalPayee;
        private SnapSplitter snapSplitter6;
        private TransferGlobalPayeeEditor transferGlobalPayeeEditor1;
        private InitiativeAllotAccountItemsPanel initiativeAllotAccountItemsPanel1;
        private SnapSplitter snapSplitter8;
        private InitiativeAllotAccountEditor initiativeAllotAccountEditor;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label11;
        private BatchMappingItemsPanel batchMappingItemsPanel1;
        private System.Windows.Forms.Panel panel1;
        private ThemedButton btnMappingSave;
        private SnapSplitter snapSplitter4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tpVirtualAccount;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label label13;
        private VirtualAllotAccountEditor virtualAllotAccountEditor1;
        private VirtualAllotAccountItemsPanel virtualAllotAccountItemsPanel1;
    }
}
