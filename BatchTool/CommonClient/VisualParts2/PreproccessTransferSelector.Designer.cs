namespace CommonClient.VisualParts2
{
    partial class PreproccessTransferSelector
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
            this.tbPreproccessName = new CommonClient.Controls.TextBoxCanValidate();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCashType = new CommonClient.Controls.ComboBoxCanValidate();
            this.tbMainAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTradeSerialNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAddition = new System.Windows.Forms.Label();
            this.tbAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAmount = new System.Windows.Forms.Label();
            this.cmbVirtualAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbNameOut = new System.Windows.Forms.Label();
            this.lbNameIn = new System.Windows.Forms.Label();
            this.lbAccountOut = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPreproccessAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBatchTradeSerialNo = new CommonClient.Controls.TextBoxCanValidate();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbInvolvedName = new CommonClient.Controls.TextBoxCanValidate();
            this.tbPreproccessAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.tbInvolvedAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.dtpTradeDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbContent = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAmountDesc = new System.Windows.Forms.Label();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPreproccessName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPreproccessName, null);
            this.tbPreproccessName.DvDataField = null;
            this.tbPreproccessName.DvEditorValueChanged = false;
            this.tbPreproccessName.DvErrorProvider = this.errorProvider1;
            this.tbPreproccessName.DvFixLength = false;
            this.tbPreproccessName.DvLinkedLabel = this.label6;
            this.tbPreproccessName.DvMaxLength = 0;
            this.tbPreproccessName.DvMinLength = 0;
            this.tbPreproccessName.DvRegCode = "";
            this.tbPreproccessName.DvRequired = false;
            this.tbPreproccessName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPreproccessName.DvValidateEnabled = true;
            this.tbPreproccessName.DvValidator = this.validatorList1;
            this.tbPreproccessName.Enabled = false;
            this.tbPreproccessName.Location = new System.Drawing.Point(156, 6);
            this.tbPreproccessName.Name = "tbPreproccessName";
            this.tbPreproccessName.Size = new System.Drawing.Size(200, 20);
            this.tbPreproccessName.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(55, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "待处理账户名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(104, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(56, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "*";
            // 
            // cmbCashType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbCashType, null);
            this.cmbCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashType.DvDataField = null;
            this.cmbCashType.DvEditorValueChanged = false;
            this.cmbCashType.DvErrorProvider = this.errorProvider1;
            this.cmbCashType.DvFixLength = false;
            this.cmbCashType.DvLinkedLabel = null;
            this.cmbCashType.DvMaxLength = 0;
            this.cmbCashType.DvMinLength = 0;
            this.cmbCashType.DvRegCode = "";
            this.cmbCashType.DvRequired = true;
            this.cmbCashType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbCashType.DvValidateEnabled = true;
            this.cmbCashType.DvValidator = this.validatorList1;
            this.cmbCashType.Enabled = false;
            this.cmbCashType.FormattingEnabled = true;
            this.cmbCashType.Location = new System.Drawing.Point(156, 61);
            this.cmbCashType.Name = "cmbCashType";
            this.cmbCashType.Size = new System.Drawing.Size(200, 21);
            this.cmbCashType.TabIndex = 46;
            // 
            // tbMainAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbMainAccount, null);
            this.tbMainAccount.DvDataField = null;
            this.tbMainAccount.DvEditorValueChanged = false;
            this.tbMainAccount.DvErrorProvider = this.errorProvider1;
            this.tbMainAccount.DvFixLength = false;
            this.tbMainAccount.DvLinkedLabel = this.label4;
            this.tbMainAccount.DvMaxLength = 0;
            this.tbMainAccount.DvMinLength = 0;
            this.tbMainAccount.DvRegCode = "";
            this.tbMainAccount.DvRequired = false;
            this.tbMainAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbMainAccount.DvValidateEnabled = true;
            this.tbMainAccount.DvValidator = this.validatorList1;
            this.tbMainAccount.Enabled = false;
            this.tbMainAccount.Location = new System.Drawing.Point(156, 116);
            this.tbMainAccount.Name = "tbMainAccount";
            this.tbMainAccount.Size = new System.Drawing.Size(200, 20);
            this.tbMainAccount.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(79, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "主账户账号：";
            // 
            // tbTradeSerialNo
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbTradeSerialNo, null);
            this.tbTradeSerialNo.DvDataField = null;
            this.tbTradeSerialNo.DvEditorValueChanged = false;
            this.tbTradeSerialNo.DvErrorProvider = this.errorProvider1;
            this.tbTradeSerialNo.DvFixLength = false;
            this.tbTradeSerialNo.DvLinkedLabel = this.lbAddition;
            this.tbTradeSerialNo.DvMaxLength = 0;
            this.tbTradeSerialNo.DvMinLength = 0;
            this.tbTradeSerialNo.DvRegCode = "";
            this.tbTradeSerialNo.DvRequired = false;
            this.tbTradeSerialNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbTradeSerialNo.DvValidateEnabled = true;
            this.tbTradeSerialNo.DvValidator = this.validatorList1;
            this.tbTradeSerialNo.Enabled = false;
            this.tbTradeSerialNo.Location = new System.Drawing.Point(156, 143);
            this.tbTradeSerialNo.Name = "tbTradeSerialNo";
            this.tbTradeSerialNo.Size = new System.Drawing.Size(200, 20);
            this.tbTradeSerialNo.TabIndex = 45;
            // 
            // lbAddition
            // 
            this.lbAddition.AutoSize = true;
            this.lbAddition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAddition.Location = new System.Drawing.Point(79, 147);
            this.lbAddition.Name = "lbAddition";
            this.lbAddition.Size = new System.Drawing.Size(79, 13);
            this.lbAddition.TabIndex = 34;
            this.lbAddition.Text = "交易流水号：";
            // 
            // tbAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbAmount, null);
            this.tbAmount.DvDataField = null;
            this.tbAmount.DvEditorValueChanged = false;
            this.tbAmount.DvErrorProvider = this.errorProvider1;
            this.tbAmount.DvFixLength = false;
            this.tbAmount.DvLinkedLabel = this.lbAmount;
            this.tbAmount.DvMaxLength = 0;
            this.tbAmount.DvMinLength = 0;
            this.tbAmount.DvRegCode = "";
            this.tbAmount.DvRequired = true;
            this.tbAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbAmount.DvValidateEnabled = true;
            this.tbAmount.DvValidator = this.validatorList1;
            this.tbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbAmount.Location = new System.Drawing.Point(156, 333);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(200, 20);
            this.tbAmount.TabIndex = 43;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAmount.Location = new System.Drawing.Point(115, 337);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(43, 13);
            this.lbAmount.TabIndex = 39;
            this.lbAmount.Text = "金额：";
            // 
            // cmbVirtualAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbVirtualAccount, this.ambiguityInputAgent1);
            this.cmbVirtualAccount.BackColor = System.Drawing.SystemColors.Window;
            this.cmbVirtualAccount.DvDataField = null;
            this.cmbVirtualAccount.DvEditorValueChanged = true;
            this.cmbVirtualAccount.DvErrorProvider = this.errorProvider1;
            this.cmbVirtualAccount.DvFixLength = false;
            this.cmbVirtualAccount.DvLinkedLabel = this.lbNameOut;
            this.cmbVirtualAccount.DvMaxLength = 0;
            this.cmbVirtualAccount.DvMinLength = 0;
            this.cmbVirtualAccount.DvRegCode = "reg766";
            this.cmbVirtualAccount.DvRequired = true;
            this.cmbVirtualAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbVirtualAccount.DvValidateEnabled = true;
            this.cmbVirtualAccount.DvValidator = this.validatorList1;
            this.cmbVirtualAccount.FormattingEnabled = true;
            this.cmbVirtualAccount.Location = new System.Drawing.Point(156, 305);
            this.cmbVirtualAccount.Name = "cmbVirtualAccount";
            this.cmbVirtualAccount.Size = new System.Drawing.Size(200, 21);
            this.cmbVirtualAccount.TabIndex = 41;
            // 
            // lbNameOut
            // 
            this.lbNameOut.AutoSize = true;
            this.lbNameOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNameOut.Location = new System.Drawing.Point(67, 310);
            this.lbNameOut.Name = "lbNameOut";
            this.lbNameOut.Size = new System.Drawing.Size(91, 13);
            this.lbNameOut.TabIndex = 37;
            this.lbNameOut.Text = "虚拟账户账号：";
            // 
            // lbNameIn
            // 
            this.lbNameIn.AutoSize = true;
            this.lbNameIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNameIn.Location = new System.Drawing.Point(91, 255);
            this.lbNameIn.Name = "lbNameIn";
            this.lbNameIn.Size = new System.Drawing.Size(67, 13);
            this.lbNameIn.TabIndex = 35;
            this.lbNameIn.Text = "交易日期：";
            // 
            // lbAccountOut
            // 
            this.lbAccountOut.AutoSize = true;
            this.lbAccountOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAccountOut.Location = new System.Drawing.Point(79, 36);
            this.lbAccountOut.Name = "lbAccountOut";
            this.lbAccountOut.Size = new System.Drawing.Size(79, 13);
            this.lbAccountOut.TabIndex = 36;
            this.lbAccountOut.Text = "待处理账号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(115, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "币种：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(79, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "待处理金额：";
            // 
            // tbPreproccessAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPreproccessAmount, null);
            this.tbPreproccessAmount.DvDataField = null;
            this.tbPreproccessAmount.DvEditorValueChanged = false;
            this.tbPreproccessAmount.DvErrorProvider = this.errorProvider1;
            this.tbPreproccessAmount.DvFixLength = false;
            this.tbPreproccessAmount.DvLinkedLabel = this.label8;
            this.tbPreproccessAmount.DvMaxLength = 0;
            this.tbPreproccessAmount.DvMinLength = 0;
            this.tbPreproccessAmount.DvRegCode = "";
            this.tbPreproccessAmount.DvRequired = true;
            this.tbPreproccessAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPreproccessAmount.DvValidateEnabled = true;
            this.tbPreproccessAmount.DvValidator = this.validatorList1;
            this.tbPreproccessAmount.Enabled = false;
            this.tbPreproccessAmount.Location = new System.Drawing.Point(156, 89);
            this.tbPreproccessAmount.Name = "tbPreproccessAmount";
            this.tbPreproccessAmount.Size = new System.Drawing.Size(200, 20);
            this.tbPreproccessAmount.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(67, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "交易流水子号：";
            // 
            // tbBatchTradeSerialNo
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbBatchTradeSerialNo, null);
            this.tbBatchTradeSerialNo.DvDataField = null;
            this.tbBatchTradeSerialNo.DvEditorValueChanged = false;
            this.tbBatchTradeSerialNo.DvErrorProvider = this.errorProvider1;
            this.tbBatchTradeSerialNo.DvFixLength = false;
            this.tbBatchTradeSerialNo.DvLinkedLabel = this.label10;
            this.tbBatchTradeSerialNo.DvMaxLength = 0;
            this.tbBatchTradeSerialNo.DvMinLength = 0;
            this.tbBatchTradeSerialNo.DvRegCode = "";
            this.tbBatchTradeSerialNo.DvRequired = false;
            this.tbBatchTradeSerialNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbBatchTradeSerialNo.DvValidateEnabled = true;
            this.tbBatchTradeSerialNo.DvValidator = this.validatorList1;
            this.tbBatchTradeSerialNo.Enabled = false;
            this.tbBatchTradeSerialNo.Location = new System.Drawing.Point(156, 170);
            this.tbBatchTradeSerialNo.Name = "tbBatchTradeSerialNo";
            this.tbBatchTradeSerialNo.Size = new System.Drawing.Size(200, 20);
            this.tbBatchTradeSerialNo.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(91, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "对方账号：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(67, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "对方账户名称：";
            // 
            // tbInvolvedName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbInvolvedName, null);
            this.tbInvolvedName.DvDataField = null;
            this.tbInvolvedName.DvEditorValueChanged = false;
            this.tbInvolvedName.DvErrorProvider = this.errorProvider1;
            this.tbInvolvedName.DvFixLength = false;
            this.tbInvolvedName.DvLinkedLabel = this.label12;
            this.tbInvolvedName.DvMaxLength = 0;
            this.tbInvolvedName.DvMinLength = 0;
            this.tbInvolvedName.DvRegCode = "";
            this.tbInvolvedName.DvRequired = false;
            this.tbInvolvedName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbInvolvedName.DvValidateEnabled = true;
            this.tbInvolvedName.DvValidator = this.validatorList1;
            this.tbInvolvedName.Enabled = false;
            this.tbInvolvedName.Location = new System.Drawing.Point(156, 197);
            this.tbInvolvedName.Name = "tbInvolvedName";
            this.tbInvolvedName.Size = new System.Drawing.Size(200, 20);
            this.tbInvolvedName.TabIndex = 50;
            // 
            // tbPreproccessAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbPreproccessAccount, null);
            this.tbPreproccessAccount.DvDataField = null;
            this.tbPreproccessAccount.DvEditorValueChanged = false;
            this.tbPreproccessAccount.DvErrorProvider = this.errorProvider1;
            this.tbPreproccessAccount.DvFixLength = false;
            this.tbPreproccessAccount.DvLinkedLabel = this.lbAccountOut;
            this.tbPreproccessAccount.DvMaxLength = 0;
            this.tbPreproccessAccount.DvMinLength = 0;
            this.tbPreproccessAccount.DvRegCode = "";
            this.tbPreproccessAccount.DvRequired = false;
            this.tbPreproccessAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPreproccessAccount.DvValidateEnabled = true;
            this.tbPreproccessAccount.DvValidator = this.validatorList1;
            this.tbPreproccessAccount.Enabled = false;
            this.tbPreproccessAccount.Location = new System.Drawing.Point(156, 33);
            this.tbPreproccessAccount.Name = "tbPreproccessAccount";
            this.tbPreproccessAccount.Size = new System.Drawing.Size(200, 20);
            this.tbPreproccessAccount.TabIndex = 50;
            // 
            // tbInvolvedAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbInvolvedAccount, null);
            this.tbInvolvedAccount.DvDataField = null;
            this.tbInvolvedAccount.DvEditorValueChanged = false;
            this.tbInvolvedAccount.DvErrorProvider = this.errorProvider1;
            this.tbInvolvedAccount.DvFixLength = false;
            this.tbInvolvedAccount.DvLinkedLabel = this.label11;
            this.tbInvolvedAccount.DvMaxLength = 0;
            this.tbInvolvedAccount.DvMinLength = 0;
            this.tbInvolvedAccount.DvRegCode = "";
            this.tbInvolvedAccount.DvRequired = false;
            this.tbInvolvedAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbInvolvedAccount.DvValidateEnabled = true;
            this.tbInvolvedAccount.DvValidator = this.validatorList1;
            this.tbInvolvedAccount.Enabled = false;
            this.tbInvolvedAccount.Location = new System.Drawing.Point(156, 224);
            this.tbInvolvedAccount.Name = "tbInvolvedAccount";
            this.tbInvolvedAccount.Size = new System.Drawing.Size(200, 20);
            this.tbInvolvedAccount.TabIndex = 50;
            // 
            // dtpTradeDate
            // 
            this.dtpTradeDate.CustomFormat = "yyyy/MM/dd";
            this.dtpTradeDate.Enabled = false;
            this.dtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTradeDate.Location = new System.Drawing.Point(156, 251);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTradeDate.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(115, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "摘要：";
            // 
            // tbContent
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbContent, null);
            this.tbContent.DvDataField = null;
            this.tbContent.DvEditorValueChanged = false;
            this.tbContent.DvErrorProvider = this.errorProvider1;
            this.tbContent.DvFixLength = false;
            this.tbContent.DvLinkedLabel = this.label2;
            this.tbContent.DvMaxLength = 0;
            this.tbContent.DvMinLength = 0;
            this.tbContent.DvRegCode = "";
            this.tbContent.DvRequired = false;
            this.tbContent.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbContent.DvValidateEnabled = true;
            this.tbContent.DvValidator = this.validatorList1;
            this.tbContent.Enabled = false;
            this.tbContent.Location = new System.Drawing.Point(156, 278);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(200, 20);
            this.tbContent.TabIndex = 50;
            // 
            // lbAmountDesc
            // 
            this.lbAmountDesc.AutoSize = true;
            this.lbAmountDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAmountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAmountDesc.Location = new System.Drawing.Point(55, 364);
            this.lbAmountDesc.Name = "lbAmountDesc";
            this.lbAmountDesc.Size = new System.Drawing.Size(0, 13);
            this.lbAmountDesc.TabIndex = 37;
            // 
            // ambiguityInputAgent1
            // 
            this.ambiguityInputAgent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent1.ImageList = null;
            this.ambiguityInputAgent1.Items = new string[0];
            this.ambiguityInputAgent1.MinFragmentLength = 2;
            this.ambiguityInputAgent1.SearchPattern = "[0-9a-zA-Z]";
            this.ambiguityInputAgent1.TargetControlPacker = null;
            // 
            // PreproccessTransferSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpTradeDate);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.tbInvolvedAccount);
            this.Controls.Add(this.tbInvolvedName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbPreproccessAccount);
            this.Controls.Add(this.tbPreproccessName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCashType);
            this.Controls.Add(this.tbMainAccount);
            this.Controls.Add(this.tbBatchTradeSerialNo);
            this.Controls.Add(this.tbTradeSerialNo);
            this.Controls.Add(this.tbPreproccessAmount);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.cmbVirtualAccount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.lbAddition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNameIn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbAmountDesc);
            this.Controls.Add(this.lbNameOut);
            this.Controls.Add(this.lbAccountOut);
            this.Controls.Add(this.label1);
            this.Name = "PreproccessTransferSelector";
            this.Size = new System.Drawing.Size(430, 439);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxCanValidate tbPreproccessName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Controls.ComboBoxCanValidate cmbCashType;
        private Controls.TextBoxCanValidate tbMainAccount;
        private Controls.TextBoxCanValidate tbTradeSerialNo;
        private Controls.TextBoxCanValidate tbAmount;
        private Controls.ComboBoxCanValidate cmbVirtualAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbAddition;
        private System.Windows.Forms.Label lbNameIn;
        private System.Windows.Forms.Label lbNameOut;
        private System.Windows.Forms.Label lbAccountOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private Controls.TextBoxCanValidate tbPreproccessAmount;
        private System.Windows.Forms.Label label10;
        private Controls.TextBoxCanValidate tbBatchTradeSerialNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Controls.TextBoxCanValidate tbInvolvedName;
        private Controls.TextBoxCanValidate tbPreproccessAccount;
        private Controls.TextBoxCanValidate tbInvolvedAccount;
        private System.Windows.Forms.DateTimePicker dtpTradeDate;
        private System.Windows.Forms.Label label2;
        private Controls.TextBoxCanValidate tbContent;
        private System.Windows.Forms.Label lbAmountDesc;
        private Controls.AmbiguityInputAgent ambiguityInputAgent1;
    }
}
