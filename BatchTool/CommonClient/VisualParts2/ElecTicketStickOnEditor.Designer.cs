using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class ElecTicketStickOnEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketStickOnEditor));
            this.lbPayMoneyType = new System.Windows.Forms.Label();
            this.tbPayMoneyType = new CommonClient.Controls.TextBoxCanValidate();
            this.lbClearType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbClearTypeUnder = new System.Windows.Forms.RadioButton();
            this.rbClearTypeOn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPayMoney = new System.Windows.Forms.DateTimePicker();
            this.lbPercent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAccount = new System.Windows.Forms.Label();
            this.tbPayMoneyAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOpenBankName = new System.Windows.Forms.Label();
            this.tbPayMoneyOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.tbPayMoneyOpenBankNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOpenBankNo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnQueryBank = new CommonClient.Controls.ThemedButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMoneyPercent = new CommonClient.Controls.TextBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbIsContainYes = new System.Windows.Forms.RadioButton();
            this.rbIsContainNo = new System.Windows.Forms.RadioButton();
            this.tbProtocolPercent = new CommonClient.Controls.TextBoxCanValidate();
            this.lbProtocolPercent = new System.Windows.Forms.Label();
            this.lblProtocolPercent = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPayMoneyType
            // 
            resources.ApplyResources(this.lbPayMoneyType, "lbPayMoneyType");
            this.lbPayMoneyType.Name = "lbPayMoneyType";
            // 
            // tbPayMoneyType
            // 
            this.tbPayMoneyType.DvDataField = null;
            this.tbPayMoneyType.DvEditorValueChanged = true;
            this.tbPayMoneyType.DvErrorProvider = this.errorProvider1;
            this.tbPayMoneyType.DvLinkedLabel = null;
            this.tbPayMoneyType.DvMaxLength = 0;
            this.tbPayMoneyType.DvMinLength = 0;
            this.tbPayMoneyType.DvRegCode = null;
            this.tbPayMoneyType.DvRequired = false;
            this.tbPayMoneyType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayMoneyType.DvValidateEnabled = true;
            this.tbPayMoneyType.DvValidator = null;
            resources.ApplyResources(this.tbPayMoneyType, "tbPayMoneyType");
            this.tbPayMoneyType.Name = "tbPayMoneyType";
            this.tbPayMoneyType.ReadOnly = true;
            // 
            // lbClearType
            // 
            resources.ApplyResources(this.lbClearType, "lbClearType");
            this.lbClearType.Name = "lbClearType";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbClearTypeUnder);
            this.panel1.Controls.Add(this.rbClearTypeOn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // rbClearTypeUnder
            // 
            resources.ApplyResources(this.rbClearTypeUnder, "rbClearTypeUnder");
            this.rbClearTypeUnder.Checked = true;
            this.rbClearTypeUnder.Name = "rbClearTypeUnder";
            this.rbClearTypeUnder.TabStop = true;
            this.rbClearTypeUnder.UseVisualStyleBackColor = true;
            // 
            // rbClearTypeOn
            // 
            resources.ApplyResources(this.rbClearTypeOn, "rbClearTypeOn");
            this.rbClearTypeOn.Name = "rbClearTypeOn";
            this.rbClearTypeOn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // dtpPayMoney
            // 
            resources.ApplyResources(this.dtpPayMoney, "dtpPayMoney");
            this.dtpPayMoney.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayMoney.Name = "dtpPayMoney";
            // 
            // lbPercent
            // 
            resources.ApplyResources(this.lbPercent, "lbPercent");
            this.lbPercent.Name = "lbPercent";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lbAccount
            // 
            resources.ApplyResources(this.lbAccount, "lbAccount");
            this.lbAccount.Name = "lbAccount";
            // 
            // tbPayMoneyAccount
            // 
            this.tbPayMoneyAccount.DvDataField = null;
            this.tbPayMoneyAccount.DvEditorValueChanged = false;
            this.tbPayMoneyAccount.DvErrorProvider = this.errorProvider1;
            this.tbPayMoneyAccount.DvLinkedLabel = this.lbAccount;
            this.tbPayMoneyAccount.DvMaxLength = 0;
            this.tbPayMoneyAccount.DvMinLength = 0;
            this.tbPayMoneyAccount.DvRegCode = null;
            this.tbPayMoneyAccount.DvRequired = true;
            this.tbPayMoneyAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayMoneyAccount.DvValidateEnabled = true;
            this.tbPayMoneyAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayMoneyAccount, "tbPayMoneyAccount");
            this.tbPayMoneyAccount.Name = "tbPayMoneyAccount";
            // 
            // lbOpenBankName
            // 
            resources.ApplyResources(this.lbOpenBankName, "lbOpenBankName");
            this.lbOpenBankName.Name = "lbOpenBankName";
            // 
            // tbPayMoneyOpenBankName
            // 
            this.tbPayMoneyOpenBankName.DvDataField = null;
            this.tbPayMoneyOpenBankName.DvEditorValueChanged = false;
            this.tbPayMoneyOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbPayMoneyOpenBankName.DvLinkedLabel = this.lbOpenBankName;
            this.tbPayMoneyOpenBankName.DvMaxLength = 0;
            this.tbPayMoneyOpenBankName.DvMinLength = 0;
            this.tbPayMoneyOpenBankName.DvRegCode = null;
            this.tbPayMoneyOpenBankName.DvRequired = true;
            this.tbPayMoneyOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayMoneyOpenBankName.DvValidateEnabled = true;
            this.tbPayMoneyOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayMoneyOpenBankName, "tbPayMoneyOpenBankName");
            this.tbPayMoneyOpenBankName.Name = "tbPayMoneyOpenBankName";
            // 
            // tbPayMoneyOpenBankNo
            // 
            this.tbPayMoneyOpenBankNo.DvDataField = null;
            this.tbPayMoneyOpenBankNo.DvEditorValueChanged = false;
            this.tbPayMoneyOpenBankNo.DvErrorProvider = this.errorProvider1;
            this.tbPayMoneyOpenBankNo.DvLinkedLabel = this.lbOpenBankNo;
            this.tbPayMoneyOpenBankNo.DvMaxLength = 0;
            this.tbPayMoneyOpenBankNo.DvMinLength = 0;
            this.tbPayMoneyOpenBankNo.DvRegCode = null;
            this.tbPayMoneyOpenBankNo.DvRequired = true;
            this.tbPayMoneyOpenBankNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayMoneyOpenBankNo.DvValidateEnabled = true;
            this.tbPayMoneyOpenBankNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayMoneyOpenBankNo, "tbPayMoneyOpenBankNo");
            this.tbPayMoneyOpenBankNo.Name = "tbPayMoneyOpenBankNo";
            // 
            // lbOpenBankNo
            // 
            resources.ApplyResources(this.lbOpenBankNo, "lbOpenBankNo");
            this.lbOpenBankNo.Name = "lbOpenBankNo";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // btnQueryBank
            // 
            resources.ApplyResources(this.btnQueryBank, "btnQueryBank");
            this.btnQueryBank.Name = "btnQueryBank";
            this.btnQueryBank.UseVisualStyleBackColor = true;
            this.btnQueryBank.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Name = "label15";
            // 
            // tbMoneyPercent
            // 
            this.tbMoneyPercent.DvDataField = null;
            this.tbMoneyPercent.DvEditorValueChanged = false;
            this.tbMoneyPercent.DvErrorProvider = this.errorProvider1;
            this.tbMoneyPercent.DvLinkedLabel = this.lbPercent;
            this.tbMoneyPercent.DvMaxLength = 8;
            this.tbMoneyPercent.DvMinLength = 1;
            this.tbMoneyPercent.DvRegCode = "Predefined7";
            this.tbMoneyPercent.DvRequired = true;
            this.tbMoneyPercent.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbMoneyPercent.DvValidateEnabled = true;
            this.tbMoneyPercent.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbMoneyPercent, "tbMoneyPercent");
            this.tbMoneyPercent.Name = "tbMoneyPercent";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbIsContainYes);
            this.panel2.Controls.Add(this.rbIsContainNo);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // rbIsContainYes
            // 
            resources.ApplyResources(this.rbIsContainYes, "rbIsContainYes");
            this.rbIsContainYes.Name = "rbIsContainYes";
            this.rbIsContainYes.TabStop = true;
            this.rbIsContainYes.UseVisualStyleBackColor = true;
            this.rbIsContainYes.CheckedChanged += new System.EventHandler(this.rbIsContain_CheckedChanged);
            // 
            // rbIsContainNo
            // 
            resources.ApplyResources(this.rbIsContainNo, "rbIsContainNo");
            this.rbIsContainNo.Checked = true;
            this.rbIsContainNo.Name = "rbIsContainNo";
            this.rbIsContainNo.TabStop = true;
            this.rbIsContainNo.UseVisualStyleBackColor = true;
            this.rbIsContainNo.CheckedChanged += new System.EventHandler(this.rbIsContain_CheckedChanged);
            // 
            // tbProtocolPercent
            // 
            this.tbProtocolPercent.DvDataField = null;
            this.tbProtocolPercent.DvEditorValueChanged = true;
            this.tbProtocolPercent.DvErrorProvider = this.errorProvider1;
            this.tbProtocolPercent.DvLinkedLabel = null;
            this.tbProtocolPercent.DvMaxLength = 8;
            this.tbProtocolPercent.DvMinLength = 1;
            this.tbProtocolPercent.DvRegCode = "Predefined7";
            this.tbProtocolPercent.DvRequired = true;
            this.tbProtocolPercent.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbProtocolPercent.DvValidateEnabled = true;
            this.tbProtocolPercent.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbProtocolPercent, "tbProtocolPercent");
            this.tbProtocolPercent.Name = "tbProtocolPercent";
            this.tbProtocolPercent.ReadOnly = true;
            // 
            // lbProtocolPercent
            // 
            resources.ApplyResources(this.lbProtocolPercent, "lbProtocolPercent");
            this.lbProtocolPercent.Name = "lbProtocolPercent";
            // 
            // lblProtocolPercent
            // 
            resources.ApplyResources(this.lblProtocolPercent, "lblProtocolPercent");
            this.lblProtocolPercent.ForeColor = System.Drawing.Color.Red;
            this.lblProtocolPercent.Name = "lblProtocolPercent";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // ElecTicketStickOnEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnQueryBank);
            this.Controls.Add(this.lblProtocolPercent);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOpenBankName);
            this.Controls.Add(this.tbProtocolPercent);
            this.Controls.Add(this.tbPayMoneyOpenBankNo);
            this.Controls.Add(this.tbPayMoneyOpenBankName);
            this.Controls.Add(this.tbMoneyPercent);
            this.Controls.Add(this.tbPayMoneyAccount);
            this.Controls.Add(this.lbAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbPercent);
            this.Controls.Add(this.dtpPayMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbClearType);
            this.Controls.Add(this.tbPayMoneyType);
            this.Controls.Add(this.lbPayMoneyType);
            this.Controls.Add(this.lbOpenBankNo);
            this.Controls.Add(this.lbProtocolPercent);
            this.Name = "ElecTicketStickOnEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPayMoneyType;
        private TextBoxCanValidate tbPayMoneyType;
        private System.Windows.Forms.Label lbClearType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbClearTypeUnder;
        private System.Windows.Forms.RadioButton rbClearTypeOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPayMoney;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbAccount;
        private TextBoxCanValidate tbPayMoneyAccount;
        private System.Windows.Forms.Label lbOpenBankName;
        private TextBoxCanValidate tbPayMoneyOpenBankName;
        private TextBoxCanValidate tbPayMoneyOpenBankNo;
        private System.Windows.Forms.Label lbOpenBankNo;
        private System.Windows.Forms.Label label9;
        private Controls.ThemedButton btnQueryBank;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private TextBoxCanValidate tbMoneyPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbIsContainYes;
        private System.Windows.Forms.RadioButton rbIsContainNo;
        private TextBoxCanValidate tbProtocolPercent;
        private System.Windows.Forms.Label lbProtocolPercent;
        private System.Windows.Forms.Label lblProtocolPercent;
        private System.Windows.Forms.Label label7;
    }
}
