using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class ElecTicketPoolRelateAccountSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketPoolRelateAccountSelector));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbExchange = new System.Windows.Forms.CheckBox();
            this.chbSaveRemit = new System.Windows.Forms.CheckBox();
            this.btnQueryExchange = new CommonClient.Controls.ThemedButton();
            this.btnQueryRemit = new CommonClient.Controls.ThemedButton();
            this.cmbExchangeAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbExchangeAccount = new System.Windows.Forms.Label();
            this.cmbRemitAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExcahngeName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbExchangeName = new System.Windows.Forms.Label();
            this.tbRemitName = new CommonClient.Controls.TextBoxCanValidate();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbExchangeOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.tbExchangeOpenBankNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbExchangeOpenBankNo = new System.Windows.Forms.Label();
            this.btnQueryExchangeOpenBank = new CommonClient.Controls.ThemedButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chbSavePayee = new System.Windows.Forms.CheckBox();
            this.btnQueryPayeeOpenBank = new CommonClient.Controls.ThemedButton();
            this.btnQueryPayee = new CommonClient.Controls.ThemedButton();
            this.tbPayeeOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPayeeOpenBankNo = new CommonClient.Controls.TextBoxCanValidate();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPayeeAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent2 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent3 = new CommonClient.Controls.AmbiguityInputAgent();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbExchange);
            this.panel1.Controls.Add(this.chbSaveRemit);
            this.panel1.Controls.Add(this.btnQueryExchange);
            this.panel1.Controls.Add(this.btnQueryRemit);
            this.panel1.Controls.Add(this.cmbExchangeAccount);
            this.panel1.Controls.Add(this.cmbRemitAccount);
            this.panel1.Controls.Add(this.tbExcahngeName);
            this.panel1.Controls.Add(this.tbRemitName);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbExchangeName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbExchangeAccount);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // chbExchange
            // 
            resources.ApplyResources(this.chbExchange, "chbExchange");
            this.chbExchange.Checked = true;
            this.chbExchange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbExchange.Name = "chbExchange";
            this.chbExchange.UseVisualStyleBackColor = true;
            // 
            // chbSaveRemit
            // 
            resources.ApplyResources(this.chbSaveRemit, "chbSaveRemit");
            this.chbSaveRemit.Checked = true;
            this.chbSaveRemit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSaveRemit.Name = "chbSaveRemit";
            this.chbSaveRemit.UseVisualStyleBackColor = true;
            // 
            // btnQueryExchange
            // 
            resources.ApplyResources(this.btnQueryExchange, "btnQueryExchange");
            this.btnQueryExchange.Name = "btnQueryExchange";
            this.btnQueryExchange.UseVisualStyleBackColor = false;
            this.btnQueryExchange.Click += new System.EventHandler(this.btnQueryExchange_Click);
            // 
            // btnQueryRemit
            // 
            resources.ApplyResources(this.btnQueryRemit, "btnQueryRemit");
            this.btnQueryRemit.Name = "btnQueryRemit";
            this.btnQueryRemit.UseVisualStyleBackColor = false;
            this.btnQueryRemit.Click += new System.EventHandler(this.btnQueryRemit_Click);
            // 
            // cmbExchangeAccount
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbExchangeAccount, this.ambiguityInputAgent2);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbExchangeAccount, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbExchangeAccount, null);
            this.cmbExchangeAccount.DvDataField = null;
            this.cmbExchangeAccount.DvEditorValueChanged = false;
            this.cmbExchangeAccount.DvErrorProvider = this.errorProvider1;
            this.cmbExchangeAccount.DvLinkedLabel = this.lbExchangeAccount;
            this.cmbExchangeAccount.DvMaxLength = 0;
            this.cmbExchangeAccount.DvMinLength = 0;
            this.cmbExchangeAccount.DvRegCode = null;
            this.cmbExchangeAccount.DvRequired = true;
            this.cmbExchangeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbExchangeAccount.DvValidateEnabled = true;
            this.cmbExchangeAccount.DvValidator = this.validatorList1;
            this.cmbExchangeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbExchangeAccount, "cmbExchangeAccount");
            this.cmbExchangeAccount.Name = "cmbExchangeAccount";
            this.cmbExchangeAccount.SelectedIndexChanged += new System.EventHandler(this.cmbExchangeAccount_SelectedIndexChanged);
            // 
            // lbExchangeAccount
            // 
            resources.ApplyResources(this.lbExchangeAccount, "lbExchangeAccount");
            this.lbExchangeAccount.Name = "lbExchangeAccount";
            // 
            // cmbRemitAccount
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbRemitAccount, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbRemitAccount, this.ambiguityInputAgent1);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbRemitAccount, null);
            this.cmbRemitAccount.DvDataField = null;
            this.cmbRemitAccount.DvEditorValueChanged = false;
            this.cmbRemitAccount.DvErrorProvider = this.errorProvider1;
            this.cmbRemitAccount.DvLinkedLabel = this.label1;
            this.cmbRemitAccount.DvMaxLength = 0;
            this.cmbRemitAccount.DvMinLength = 0;
            this.cmbRemitAccount.DvRegCode = null;
            this.cmbRemitAccount.DvRequired = true;
            this.cmbRemitAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbRemitAccount.DvValidateEnabled = true;
            this.cmbRemitAccount.DvValidator = this.validatorList1;
            this.cmbRemitAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbRemitAccount, "cmbRemitAccount");
            this.cmbRemitAccount.Name = "cmbRemitAccount";
            this.cmbRemitAccount.SelectedIndexChanged += new System.EventHandler(this.cmbRemitAccount_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbExcahngeName
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbExcahngeName, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbExcahngeName, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbExcahngeName, null);
            this.tbExcahngeName.DvDataField = null;
            this.tbExcahngeName.DvEditorValueChanged = false;
            this.tbExcahngeName.DvErrorProvider = this.errorProvider1;
            this.tbExcahngeName.DvLinkedLabel = this.lbExchangeName;
            this.tbExcahngeName.DvMaxLength = 0;
            this.tbExcahngeName.DvMinLength = 0;
            this.tbExcahngeName.DvRegCode = null;
            this.tbExcahngeName.DvRequired = true;
            this.tbExcahngeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbExcahngeName.DvValidateEnabled = true;
            this.tbExcahngeName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbExcahngeName, "tbExcahngeName");
            this.tbExcahngeName.Name = "tbExcahngeName";
            // 
            // lbExchangeName
            // 
            resources.ApplyResources(this.lbExchangeName, "lbExchangeName");
            this.lbExchangeName.Name = "lbExchangeName";
            // 
            // tbRemitName
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbRemitName, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbRemitName, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbRemitName, null);
            this.tbRemitName.DvDataField = null;
            this.tbRemitName.DvEditorValueChanged = false;
            this.tbRemitName.DvErrorProvider = this.errorProvider1;
            this.tbRemitName.DvLinkedLabel = this.label2;
            this.tbRemitName.DvMaxLength = 0;
            this.tbRemitName.DvMinLength = 0;
            this.tbRemitName.DvRegCode = null;
            this.tbRemitName.DvRequired = true;
            this.tbRemitName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRemitName.DvValidateEnabled = true;
            this.tbRemitName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRemitName, "tbRemitName");
            this.tbRemitName.Name = "tbRemitName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Name = "label11";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbExchangeOpenBankName);
            this.panel2.Controls.Add(this.tbExchangeOpenBankNo);
            this.panel2.Controls.Add(this.btnQueryExchangeOpenBank);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbExchangeOpenBankNo);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tbExchangeOpenBankName
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbExchangeOpenBankName, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbExchangeOpenBankName, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbExchangeOpenBankName, null);
            this.tbExchangeOpenBankName.DvDataField = null;
            this.tbExchangeOpenBankName.DvEditorValueChanged = false;
            this.tbExchangeOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbExchangeOpenBankName.DvLinkedLabel = null;
            this.tbExchangeOpenBankName.DvMaxLength = 0;
            this.tbExchangeOpenBankName.DvMinLength = 0;
            this.tbExchangeOpenBankName.DvRegCode = null;
            this.tbExchangeOpenBankName.DvRequired = false;
            this.tbExchangeOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbExchangeOpenBankName.DvValidateEnabled = true;
            this.tbExchangeOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbExchangeOpenBankName, "tbExchangeOpenBankName");
            this.tbExchangeOpenBankName.Name = "tbExchangeOpenBankName";
            this.tbExchangeOpenBankName.ReadOnly = true;
            // 
            // tbExchangeOpenBankNo
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbExchangeOpenBankNo, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbExchangeOpenBankNo, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbExchangeOpenBankNo, null);
            this.tbExchangeOpenBankNo.DvDataField = null;
            this.tbExchangeOpenBankNo.DvEditorValueChanged = false;
            this.tbExchangeOpenBankNo.DvErrorProvider = this.errorProvider1;
            this.tbExchangeOpenBankNo.DvLinkedLabel = this.lbExchangeOpenBankNo;
            this.tbExchangeOpenBankNo.DvMaxLength = 0;
            this.tbExchangeOpenBankNo.DvMinLength = 0;
            this.tbExchangeOpenBankNo.DvRegCode = null;
            this.tbExchangeOpenBankNo.DvRequired = true;
            this.tbExchangeOpenBankNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbExchangeOpenBankNo.DvValidateEnabled = true;
            this.tbExchangeOpenBankNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbExchangeOpenBankNo, "tbExchangeOpenBankNo");
            this.tbExchangeOpenBankNo.Name = "tbExchangeOpenBankNo";
            // 
            // lbExchangeOpenBankNo
            // 
            resources.ApplyResources(this.lbExchangeOpenBankNo, "lbExchangeOpenBankNo");
            this.lbExchangeOpenBankNo.Name = "lbExchangeOpenBankNo";
            // 
            // btnQueryExchangeOpenBank
            // 
            resources.ApplyResources(this.btnQueryExchangeOpenBank, "btnQueryExchangeOpenBank");
            this.btnQueryExchangeOpenBank.Name = "btnQueryExchangeOpenBank";
            this.btnQueryExchangeOpenBank.UseVisualStyleBackColor = false;
            this.btnQueryExchangeOpenBank.Click += new System.EventHandler(this.btnQueryExchangeOpenBank_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Name = "label15";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chbSavePayee);
            this.panel3.Controls.Add(this.btnQueryPayeeOpenBank);
            this.panel3.Controls.Add(this.btnQueryPayee);
            this.panel3.Controls.Add(this.tbPayeeOpenBankName);
            this.panel3.Controls.Add(this.tbPayeeOpenBankNo);
            this.panel3.Controls.Add(this.tbPayeeName);
            this.panel3.Controls.Add(this.cmbPayeeAccount);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label7);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // chbSavePayee
            // 
            resources.ApplyResources(this.chbSavePayee, "chbSavePayee");
            this.chbSavePayee.Checked = true;
            this.chbSavePayee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSavePayee.Name = "chbSavePayee";
            this.chbSavePayee.UseVisualStyleBackColor = true;
            // 
            // btnQueryPayeeOpenBank
            // 
            resources.ApplyResources(this.btnQueryPayeeOpenBank, "btnQueryPayeeOpenBank");
            this.btnQueryPayeeOpenBank.Name = "btnQueryPayeeOpenBank";
            this.btnQueryPayeeOpenBank.UseVisualStyleBackColor = false;
            this.btnQueryPayeeOpenBank.Click += new System.EventHandler(this.btnQueryPayeeOpenBank_Click);
            // 
            // btnQueryPayee
            // 
            resources.ApplyResources(this.btnQueryPayee, "btnQueryPayee");
            this.btnQueryPayee.Name = "btnQueryPayee";
            this.btnQueryPayee.UseVisualStyleBackColor = false;
            this.btnQueryPayee.Click += new System.EventHandler(this.btnQueryPayee_Click);
            // 
            // tbPayeeOpenBankName
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbPayeeOpenBankName, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeOpenBankName, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbPayeeOpenBankName, null);
            this.tbPayeeOpenBankName.DvDataField = null;
            this.tbPayeeOpenBankName.DvEditorValueChanged = false;
            this.tbPayeeOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbPayeeOpenBankName.DvLinkedLabel = this.label10;
            this.tbPayeeOpenBankName.DvMaxLength = 0;
            this.tbPayeeOpenBankName.DvMinLength = 0;
            this.tbPayeeOpenBankName.DvRegCode = null;
            this.tbPayeeOpenBankName.DvRequired = true;
            this.tbPayeeOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeOpenBankName.DvValidateEnabled = true;
            this.tbPayeeOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeOpenBankName, "tbPayeeOpenBankName");
            this.tbPayeeOpenBankName.Name = "tbPayeeOpenBankName";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tbPayeeOpenBankNo
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbPayeeOpenBankNo, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeOpenBankNo, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbPayeeOpenBankNo, null);
            this.tbPayeeOpenBankNo.DvDataField = null;
            this.tbPayeeOpenBankNo.DvEditorValueChanged = false;
            this.tbPayeeOpenBankNo.DvErrorProvider = this.errorProvider1;
            this.tbPayeeOpenBankNo.DvLinkedLabel = this.label9;
            this.tbPayeeOpenBankNo.DvMaxLength = 0;
            this.tbPayeeOpenBankNo.DvMinLength = 0;
            this.tbPayeeOpenBankNo.DvRegCode = null;
            this.tbPayeeOpenBankNo.DvRequired = true;
            this.tbPayeeOpenBankNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeOpenBankNo.DvValidateEnabled = true;
            this.tbPayeeOpenBankNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeOpenBankNo, "tbPayeeOpenBankNo");
            this.tbPayeeOpenBankNo.Name = "tbPayeeOpenBankNo";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tbPayeeName
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbPayeeName, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPayeeName, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.tbPayeeName, null);
            this.tbPayeeName.DvDataField = null;
            this.tbPayeeName.DvEditorValueChanged = false;
            this.tbPayeeName.DvErrorProvider = this.errorProvider1;
            this.tbPayeeName.DvLinkedLabel = this.label8;
            this.tbPayeeName.DvMaxLength = 0;
            this.tbPayeeName.DvMinLength = 0;
            this.tbPayeeName.DvRegCode = null;
            this.tbPayeeName.DvRequired = true;
            this.tbPayeeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeName.DvValidateEnabled = true;
            this.tbPayeeName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeName, "tbPayeeName");
            this.tbPayeeName.Name = "tbPayeeName";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cmbPayeeAccount
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbPayeeAccount, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbPayeeAccount, null);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.cmbPayeeAccount, this.ambiguityInputAgent3);
            this.cmbPayeeAccount.DvDataField = null;
            this.cmbPayeeAccount.DvEditorValueChanged = false;
            this.cmbPayeeAccount.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccount.DvLinkedLabel = this.label7;
            this.cmbPayeeAccount.DvMaxLength = 0;
            this.cmbPayeeAccount.DvMinLength = 0;
            this.cmbPayeeAccount.DvRegCode = null;
            this.cmbPayeeAccount.DvRequired = true;
            this.cmbPayeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccount.DvValidateEnabled = true;
            this.cmbPayeeAccount.DvValidator = this.validatorList1;
            this.cmbPayeeAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccount, "cmbPayeeAccount");
            this.cmbPayeeAccount.Name = "cmbPayeeAccount";
            this.cmbPayeeAccount.SelectedIndexChanged += new System.EventHandler(this.cmbPayeeAccount_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Name = "label16";
            // 
            // ambiguityInputAgent1
            // 
            this.ambiguityInputAgent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent1.ImageList = null;
            this.ambiguityInputAgent1.Items = new string[0];
            this.ambiguityInputAgent1.MaximumSize = new System.Drawing.Size(200, 180);
            this.ambiguityInputAgent1.TargetControlPacker = null;
            // 
            // ambiguityInputAgent2
            // 
            this.ambiguityInputAgent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent2.ImageList = null;
            this.ambiguityInputAgent2.Items = new string[0];
            this.ambiguityInputAgent2.MaximumSize = new System.Drawing.Size(200, 180);
            this.ambiguityInputAgent2.TargetControlPacker = null;
            // 
            // ambiguityInputAgent3
            // 
            this.ambiguityInputAgent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent3.ImageList = null;
            this.ambiguityInputAgent3.Items = new string[0];
            this.ambiguityInputAgent3.MaximumSize = new System.Drawing.Size(200, 180);
            this.ambiguityInputAgent3.TargetControlPacker = null;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // ElecTicketPoolRelateAccountSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ElecTicketPoolRelateAccountSelector";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ComboBoxCanValidate cmbRemitAccount;
        private TextBoxCanValidate tbRemitName;
        private System.Windows.Forms.Label lbExchangeName;
        private System.Windows.Forms.Label label2;
        private ComboBoxCanValidate cmbExchangeAccount;
        private System.Windows.Forms.Label lbExchangeAccount;
        private TextBoxCanValidate tbExcahngeName;
        private TextBoxCanValidate tbExchangeOpenBankName;
        private System.Windows.Forms.Label label6;
        private TextBoxCanValidate tbExchangeOpenBankNo;
        private System.Windows.Forms.Label lbExchangeOpenBankNo;
        private TextBoxCanValidate tbPayeeOpenBankName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private TextBoxCanValidate tbPayeeOpenBankNo;
        private TextBoxCanValidate tbPayeeName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private ComboBoxCanValidate cmbPayeeAccount;
        private ThemedButton btnQueryRemit;
        private ThemedButton btnQueryExchange;
        private ThemedButton btnQueryPayee;
        private System.Windows.Forms.CheckBox chbExchange;
        private System.Windows.Forms.CheckBox chbSaveRemit;
        private System.Windows.Forms.CheckBox chbSavePayee;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private ThemedButton btnQueryExchangeOpenBank;
        private ThemedButton btnQueryPayeeOpenBank;
        private AmbiguityInputAgent ambiguityInputAgent3;
        private AmbiguityInputAgent ambiguityInputAgent1;
        private AmbiguityInputAgent ambiguityInputAgent2;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}
