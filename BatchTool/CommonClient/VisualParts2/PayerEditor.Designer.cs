using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class PayerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayerEditor));
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pServiceBar = new System.Windows.Forms.Panel();
            this.cbExpressAgentOutBar = new System.Windows.Forms.CheckBox();
            this.cbTransferOverCountyBar = new System.Windows.Forms.CheckBox();
            this.cbTransferForeignMoneyBar = new System.Windows.Forms.CheckBox();
            this.pServiceNet = new System.Windows.Forms.Panel();
            this.cbTransferEnt = new System.Windows.Forms.CheckBox();
            this.cbTransferInd = new System.Windows.Forms.CheckBox();
            this.cbTransferForeignMoney = new System.Windows.Forms.CheckBox();
            this.cbExpressAgentIn = new System.Windows.Forms.CheckBox();
            this.cbNormalAgentOut = new System.Windows.Forms.CheckBox();
            this.cbTransferOverCountry = new System.Windows.Forms.CheckBox();
            this.cbElecTicketRemit = new System.Windows.Forms.CheckBox();
            this.cbOverBankIn = new System.Windows.Forms.CheckBox();
            this.cbExpressAgentOut = new System.Windows.Forms.CheckBox();
            this.cbNormalAgentIn = new System.Windows.Forms.CheckBox();
            this.cbOverBankOut = new System.Windows.Forms.CheckBox();
            this.cbElecTicketPayMoney = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lbrowindex = new System.Windows.Forms.Label();
            this.edtPayerName = new CommonClient.Controls.TextBoxCanValidate();
            this.tbRowIndex = new CommonClient.Controls.TextBoxCanValidate();
            this.edtPayerAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.btnReset = new CommonClient.Controls.ThemedButton();
            this.btnEdit = new CommonClient.Controls.ThemedButton();
            this.btnSubmit = new CommonClient.Controls.ThemedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCashType = new CommonClient.Controls.ComboBoxCanValidate();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pServiceBar.SuspendLayout();
            this.pServiceNet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.pServiceBar);
            this.groupBox3.Controls.Add(this.pServiceNet);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // pServiceBar
            // 
            this.pServiceBar.Controls.Add(this.cbExpressAgentOutBar);
            this.pServiceBar.Controls.Add(this.cbTransferOverCountyBar);
            this.pServiceBar.Controls.Add(this.cbTransferForeignMoneyBar);
            resources.ApplyResources(this.pServiceBar, "pServiceBar");
            this.pServiceBar.Name = "pServiceBar";
            // 
            // cbExpressAgentOutBar
            // 
            resources.ApplyResources(this.cbExpressAgentOutBar, "cbExpressAgentOutBar");
            this.cbExpressAgentOutBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbExpressAgentOutBar.Name = "cbExpressAgentOutBar";
            this.cbExpressAgentOutBar.UseVisualStyleBackColor = true;
            // 
            // cbTransferOverCountyBar
            // 
            resources.ApplyResources(this.cbTransferOverCountyBar, "cbTransferOverCountyBar");
            this.cbTransferOverCountyBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTransferOverCountyBar.Name = "cbTransferOverCountyBar";
            this.cbTransferOverCountyBar.UseVisualStyleBackColor = true;
            // 
            // cbTransferForeignMoneyBar
            // 
            resources.ApplyResources(this.cbTransferForeignMoneyBar, "cbTransferForeignMoneyBar");
            this.cbTransferForeignMoneyBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTransferForeignMoneyBar.Name = "cbTransferForeignMoneyBar";
            this.cbTransferForeignMoneyBar.UseVisualStyleBackColor = true;
            // 
            // pServiceNet
            // 
            this.pServiceNet.Controls.Add(this.cbTransferEnt);
            this.pServiceNet.Controls.Add(this.cbTransferInd);
            this.pServiceNet.Controls.Add(this.cbTransferForeignMoney);
            this.pServiceNet.Controls.Add(this.cbExpressAgentIn);
            this.pServiceNet.Controls.Add(this.cbNormalAgentOut);
            this.pServiceNet.Controls.Add(this.cbTransferOverCountry);
            this.pServiceNet.Controls.Add(this.cbElecTicketRemit);
            this.pServiceNet.Controls.Add(this.cbOverBankIn);
            this.pServiceNet.Controls.Add(this.cbExpressAgentOut);
            this.pServiceNet.Controls.Add(this.cbNormalAgentIn);
            this.pServiceNet.Controls.Add(this.cbOverBankOut);
            this.pServiceNet.Controls.Add(this.cbElecTicketPayMoney);
            resources.ApplyResources(this.pServiceNet, "pServiceNet");
            this.pServiceNet.Name = "pServiceNet";
            // 
            // cbTransferEnt
            // 
            resources.ApplyResources(this.cbTransferEnt, "cbTransferEnt");
            this.cbTransferEnt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTransferEnt.Name = "cbTransferEnt";
            this.cbTransferEnt.UseVisualStyleBackColor = true;
            // 
            // cbTransferInd
            // 
            resources.ApplyResources(this.cbTransferInd, "cbTransferInd");
            this.cbTransferInd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTransferInd.Name = "cbTransferInd";
            this.cbTransferInd.UseVisualStyleBackColor = true;
            // 
            // cbTransferForeignMoney
            // 
            resources.ApplyResources(this.cbTransferForeignMoney, "cbTransferForeignMoney");
            this.cbTransferForeignMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTransferForeignMoney.Name = "cbTransferForeignMoney";
            this.cbTransferForeignMoney.UseVisualStyleBackColor = true;
            // 
            // cbExpressAgentIn
            // 
            resources.ApplyResources(this.cbExpressAgentIn, "cbExpressAgentIn");
            this.cbExpressAgentIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbExpressAgentIn.Name = "cbExpressAgentIn";
            this.cbExpressAgentIn.UseVisualStyleBackColor = true;
            // 
            // cbNormalAgentOut
            // 
            resources.ApplyResources(this.cbNormalAgentOut, "cbNormalAgentOut");
            this.cbNormalAgentOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbNormalAgentOut.Name = "cbNormalAgentOut";
            this.cbNormalAgentOut.UseVisualStyleBackColor = true;
            // 
            // cbTransferOverCountry
            // 
            resources.ApplyResources(this.cbTransferOverCountry, "cbTransferOverCountry");
            this.cbTransferOverCountry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTransferOverCountry.Name = "cbTransferOverCountry";
            this.cbTransferOverCountry.UseVisualStyleBackColor = true;
            // 
            // cbElecTicketRemit
            // 
            resources.ApplyResources(this.cbElecTicketRemit, "cbElecTicketRemit");
            this.cbElecTicketRemit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbElecTicketRemit.Name = "cbElecTicketRemit";
            this.cbElecTicketRemit.UseVisualStyleBackColor = true;
            // 
            // cbOverBankIn
            // 
            resources.ApplyResources(this.cbOverBankIn, "cbOverBankIn");
            this.cbOverBankIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbOverBankIn.Name = "cbOverBankIn";
            this.cbOverBankIn.UseVisualStyleBackColor = true;
            // 
            // cbExpressAgentOut
            // 
            resources.ApplyResources(this.cbExpressAgentOut, "cbExpressAgentOut");
            this.cbExpressAgentOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbExpressAgentOut.Name = "cbExpressAgentOut";
            this.cbExpressAgentOut.UseVisualStyleBackColor = true;
            // 
            // cbNormalAgentIn
            // 
            resources.ApplyResources(this.cbNormalAgentIn, "cbNormalAgentIn");
            this.cbNormalAgentIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbNormalAgentIn.Name = "cbNormalAgentIn";
            this.cbNormalAgentIn.UseVisualStyleBackColor = true;
            // 
            // cbOverBankOut
            // 
            resources.ApplyResources(this.cbOverBankOut, "cbOverBankOut");
            this.cbOverBankOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbOverBankOut.Name = "cbOverBankOut";
            this.cbOverBankOut.UseVisualStyleBackColor = true;
            // 
            // cbElecTicketPayMoney
            // 
            resources.ApplyResources(this.cbElecTicketPayMoney, "cbElecTicketPayMoney");
            this.cbElecTicketPayMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbElecTicketPayMoney.Name = "cbElecTicketPayMoney";
            this.cbElecTicketPayMoney.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // lbrowindex
            // 
            resources.ApplyResources(this.lbrowindex, "lbrowindex");
            this.lbrowindex.Name = "lbrowindex";
            // 
            // edtPayerName
            // 
            this.edtPayerName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayerName.DvDataField = null;
            this.edtPayerName.DvEditorValueChanged = false;
            this.edtPayerName.DvErrorProvider = this.errorProvider1;
            this.edtPayerName.DvLinkedLabel = this.label17;
            this.edtPayerName.DvMaxLength = 76;
            this.edtPayerName.DvMinLength = 0;
            this.edtPayerName.DvRegCode = "";
            this.edtPayerName.DvRequired = false;
            this.edtPayerName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayerName.DvValidateEnabled = true;
            this.edtPayerName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayerName, "edtPayerName");
            this.edtPayerName.Name = "edtPayerName";
            // 
            // tbRowIndex
            // 
            this.tbRowIndex.BackColor = System.Drawing.SystemColors.Control;
            this.tbRowIndex.DvDataField = null;
            this.tbRowIndex.DvEditorValueChanged = false;
            this.tbRowIndex.DvErrorProvider = this.errorProvider1;
            this.tbRowIndex.DvLinkedLabel = this.lbrowindex;
            this.tbRowIndex.DvMaxLength = 9;
            this.tbRowIndex.DvMinLength = 0;
            this.tbRowIndex.DvRegCode = "reg57";
            this.tbRowIndex.DvRequired = false;
            this.tbRowIndex.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRowIndex.DvValidateEnabled = true;
            this.tbRowIndex.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRowIndex, "tbRowIndex");
            this.tbRowIndex.Name = "tbRowIndex";
            this.tbRowIndex.ReadOnly = true;
            // 
            // edtPayerAccount
            // 
            this.edtPayerAccount.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayerAccount.DvDataField = null;
            this.edtPayerAccount.DvEditorValueChanged = false;
            this.edtPayerAccount.DvErrorProvider = this.errorProvider1;
            this.edtPayerAccount.DvLinkedLabel = this.label18;
            this.edtPayerAccount.DvMaxLength = 18;
            this.edtPayerAccount.DvMinLength = 12;
            this.edtPayerAccount.DvRegCode = "reg57";
            this.edtPayerAccount.DvRequired = true;
            this.edtPayerAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayerAccount.DvValidateEnabled = true;
            this.edtPayerAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayerAccount, "edtPayerAccount");
            this.edtPayerAccount.Name = "edtPayerAccount";
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ThemeName = CommonClient.Controls.ThemeName.Corp_Red;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.ThemeName = CommonClient.Controls.ThemeName.Corp_Red;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // cmbCashType
            // 
            this.cmbCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashType.DvDataField = null;
            this.cmbCashType.DvEditorValueChanged = false;
            this.cmbCashType.DvErrorProvider = this.errorProvider1;
            this.cmbCashType.DvLinkedLabel = this.label1;
            this.cmbCashType.DvMaxLength = 0;
            this.cmbCashType.DvMinLength = 0;
            this.cmbCashType.DvRegCode = "";
            this.cmbCashType.DvRequired = true;
            this.cmbCashType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbCashType.DvValidateEnabled = true;
            this.cmbCashType.DvValidator = this.validatorList1;
            this.cmbCashType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCashType, "cmbCashType");
            this.cmbCashType.Name = "cmbCashType";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnReset);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // chbSelectAll
            // 
            resources.ApplyResources(this.chbSelectAll, "chbSelectAll");
            this.chbSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // PayerEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.chbSelectAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbCashType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtPayerName);
            this.Controls.Add(this.tbRowIndex);
            this.Controls.Add(this.edtPayerAccount);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbrowindex);
            this.MinimumSize = new System.Drawing.Size(370, 460);
            this.Name = "PayerEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.pServiceBar.ResumeLayout(false);
            this.pServiceBar.PerformLayout();
            this.pServiceNet.ResumeLayout(false);
            this.pServiceNet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbNormalAgentIn;
        private System.Windows.Forms.CheckBox cbExpressAgentOut;
        private System.Windows.Forms.CheckBox cbNormalAgentOut;
        private System.Windows.Forms.CheckBox cbTransferEnt;
        private System.Windows.Forms.CheckBox cbExpressAgentIn;
        private System.Windows.Forms.CheckBox cbTransferInd;
        private TextBoxCanValidate edtPayerName;
        private System.Windows.Forms.Label label19;
        private TextBoxCanValidate edtPayerAccount;
        private ThemedButton btnSubmit;
        private ThemedButton btnReset;
        private System.Windows.Forms.CheckBox cbOverBankIn;
        private System.Windows.Forms.CheckBox cbOverBankOut;
        private TextBoxCanValidate tbRowIndex;
        private System.Windows.Forms.Label lbrowindex;
        private ThemedButton btnEdit;
        private System.Windows.Forms.CheckBox cbElecTicketPayMoney;
        private System.Windows.Forms.CheckBox cbElecTicketRemit;
        private System.Windows.Forms.CheckBox cbTransferOverCountry;
        private System.Windows.Forms.CheckBox cbTransferForeignMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ComboBoxCanValidate cmbCashType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbTransferForeignMoneyBar;
        private System.Windows.Forms.CheckBox cbTransferOverCountyBar;
        private System.Windows.Forms.CheckBox cbExpressAgentOutBar;
        private System.Windows.Forms.Panel pServiceNet;
        private System.Windows.Forms.Panel pServiceBar;
    }
}
