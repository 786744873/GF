using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class PayeeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayeeEditor));
            this.lblSeperator1 = new System.Windows.Forms.Label();
            this.rbIsOtherAccount = new System.Windows.Forms.RadioButton();
            this.rbIsBocAccount = new System.Windows.Forms.RadioButton();
            this.lblPayeeAccountType = new System.Windows.Forms.Label();
            this.edtPayeeSerial = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeSerial = new System.Windows.Forms.Label();
            this.edtPayeeAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.edtPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeName = new System.Windows.Forms.Label();
            this.lblPayeeBankName = new System.Windows.Forms.Label();
            this.lblPayeeClearBank = new System.Windows.Forms.Label();
            this.edtPayeeClearBank = new CommonClient.Controls.TextBoxCanValidate();
            this.edtPayeeBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.cmbPayeeAccountCategoryType = new CommonClient.Controls.ComboBoxCanValidate();
            this.lblRequired3 = new System.Windows.Forms.Label();
            this.lblRequired1 = new System.Windows.Forms.Label();
            this.lblRequired2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.tbRowIndex = new CommonClient.Controls.TextBoxCanValidate();
            this.label5 = new System.Windows.Forms.Label();
            this.panelOtherBank = new System.Windows.Forms.Panel();
            this.buttonQueryC = new CommonClient.Controls.ThemedButton();
            this.buttonQueryO = new CommonClient.Controls.ThemedButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonReset = new CommonClient.Controls.ThemedButton();
            this.btnEdit = new CommonClient.Controls.ThemedButton();
            this.buttonSubmit = new CommonClient.Controls.ThemedButton();
            this.pCertify = new System.Windows.Forms.Panel();
            this.cmbPayeeAccountProvince = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbProvince = new System.Windows.Forms.Label();
            this.cmbCertifyType = new CommonClient.Controls.ComboBoxCanValidate();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCertifyNo = new CommonClient.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.edtPayeeEmail = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeEmail = new System.Windows.Forms.Label();
            this.edtPayeePhone = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeePhone = new System.Windows.Forms.Label();
            this.edtPayeeAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeAddress = new System.Windows.Forms.Label();
            this.edtPayeeFax = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeFax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.panelOtherBank.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pCertify.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSeperator1
            // 
            resources.ApplyResources(this.lblSeperator1, "lblSeperator1");
            this.lblSeperator1.ForeColor = System.Drawing.Color.Silver;
            this.lblSeperator1.Name = "lblSeperator1";
            // 
            // rbIsOtherAccount
            // 
            resources.ApplyResources(this.rbIsOtherAccount, "rbIsOtherAccount");
            this.rbIsOtherAccount.Name = "rbIsOtherAccount";
            this.rbIsOtherAccount.UseVisualStyleBackColor = true;
            this.rbIsOtherAccount.CheckedChanged += new System.EventHandler(this.rbIsBoccAccount_CheckedChanged);
            // 
            // rbIsBocAccount
            // 
            resources.ApplyResources(this.rbIsBocAccount, "rbIsBocAccount");
            this.rbIsBocAccount.Checked = true;
            this.rbIsBocAccount.Name = "rbIsBocAccount";
            this.rbIsBocAccount.TabStop = true;
            this.rbIsBocAccount.UseVisualStyleBackColor = true;
            this.rbIsBocAccount.CheckedChanged += new System.EventHandler(this.rbIsBoccAccount_CheckedChanged);
            // 
            // lblPayeeAccountType
            // 
            resources.ApplyResources(this.lblPayeeAccountType, "lblPayeeAccountType");
            this.lblPayeeAccountType.Name = "lblPayeeAccountType";
            // 
            // edtPayeeSerial
            // 
            this.edtPayeeSerial.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeSerial.DvDataField = null;
            this.edtPayeeSerial.DvEditorValueChanged = false;
            this.edtPayeeSerial.DvErrorProvider = this.errorProvider1;
            this.edtPayeeSerial.DvFixLength = false;
            this.edtPayeeSerial.DvLinkedLabel = this.lblPayeeSerial;
            this.edtPayeeSerial.DvMaxLength = 10;
            this.edtPayeeSerial.DvMinLength = 0;
            this.edtPayeeSerial.DvRegCode = "reg8";
            this.edtPayeeSerial.DvRequired = false;
            this.edtPayeeSerial.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeSerial.DvValidateEnabled = true;
            this.edtPayeeSerial.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeSerial, "edtPayeeSerial");
            this.edtPayeeSerial.Name = "edtPayeeSerial";
            // 
            // lblPayeeSerial
            // 
            resources.ApplyResources(this.lblPayeeSerial, "lblPayeeSerial");
            this.lblPayeeSerial.Name = "lblPayeeSerial";
            // 
            // edtPayeeAccount
            // 
            this.edtPayeeAccount.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeAccount.DvDataField = null;
            this.edtPayeeAccount.DvEditorValueChanged = false;
            this.edtPayeeAccount.DvErrorProvider = this.errorProvider1;
            this.edtPayeeAccount.DvFixLength = false;
            this.edtPayeeAccount.DvLinkedLabel = this.lblPayeeAccount;
            this.edtPayeeAccount.DvMaxLength = 35;
            this.edtPayeeAccount.DvMinLength = 1;
            this.edtPayeeAccount.DvRegCode = "Predefined4";
            this.edtPayeeAccount.DvRequired = false;
            this.edtPayeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeAccount.DvValidateEnabled = true;
            this.edtPayeeAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeAccount, "edtPayeeAccount");
            this.edtPayeeAccount.Name = "edtPayeeAccount";
            // 
            // lblPayeeAccount
            // 
            resources.ApplyResources(this.lblPayeeAccount, "lblPayeeAccount");
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            // 
            // edtPayeeName
            // 
            this.edtPayeeName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeName.DvDataField = null;
            this.edtPayeeName.DvEditorValueChanged = false;
            this.edtPayeeName.DvErrorProvider = this.errorProvider1;
            this.edtPayeeName.DvFixLength = false;
            this.edtPayeeName.DvLinkedLabel = this.lblPayeeName;
            this.edtPayeeName.DvMaxLength = 76;
            this.edtPayeeName.DvMinLength = 1;
            this.edtPayeeName.DvRegCode = "";
            this.edtPayeeName.DvRequired = false;
            this.edtPayeeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeName.DvValidateEnabled = true;
            this.edtPayeeName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeName, "edtPayeeName");
            this.edtPayeeName.Name = "edtPayeeName";
            // 
            // lblPayeeName
            // 
            resources.ApplyResources(this.lblPayeeName, "lblPayeeName");
            this.lblPayeeName.Name = "lblPayeeName";
            // 
            // lblPayeeBankName
            // 
            resources.ApplyResources(this.lblPayeeBankName, "lblPayeeBankName");
            this.lblPayeeBankName.Name = "lblPayeeBankName";
            // 
            // lblPayeeClearBank
            // 
            resources.ApplyResources(this.lblPayeeClearBank, "lblPayeeClearBank");
            this.lblPayeeClearBank.Name = "lblPayeeClearBank";
            // 
            // edtPayeeClearBank
            // 
            this.edtPayeeClearBank.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeClearBank.DvDataField = null;
            this.edtPayeeClearBank.DvEditorValueChanged = false;
            this.edtPayeeClearBank.DvErrorProvider = this.errorProvider1;
            this.edtPayeeClearBank.DvFixLength = false;
            this.edtPayeeClearBank.DvLinkedLabel = this.lblPayeeClearBank;
            this.edtPayeeClearBank.DvMaxLength = 70;
            this.edtPayeeClearBank.DvMinLength = 0;
            this.edtPayeeClearBank.DvRegCode = "";
            this.edtPayeeClearBank.DvRequired = false;
            this.edtPayeeClearBank.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeClearBank.DvValidateEnabled = true;
            this.edtPayeeClearBank.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeClearBank, "edtPayeeClearBank");
            this.edtPayeeClearBank.Name = "edtPayeeClearBank";
            // 
            // edtPayeeBankName
            // 
            this.edtPayeeBankName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeBankName.DvDataField = null;
            this.edtPayeeBankName.DvEditorValueChanged = false;
            this.edtPayeeBankName.DvErrorProvider = this.errorProvider1;
            this.edtPayeeBankName.DvFixLength = false;
            this.edtPayeeBankName.DvLinkedLabel = this.lblPayeeBankName;
            this.edtPayeeBankName.DvMaxLength = 70;
            this.edtPayeeBankName.DvMinLength = 0;
            this.edtPayeeBankName.DvRegCode = "reg667";
            this.edtPayeeBankName.DvRequired = false;
            this.edtPayeeBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeBankName.DvValidateEnabled = true;
            this.edtPayeeBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeBankName, "edtPayeeBankName");
            this.edtPayeeBankName.Name = "edtPayeeBankName";
            // 
            // cmbPayeeAccountCategoryType
            // 
            this.cmbPayeeAccountCategoryType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccountCategoryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPayeeAccountCategoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeAccountCategoryType.DvDataField = null;
            this.cmbPayeeAccountCategoryType.DvEditorValueChanged = false;
            this.cmbPayeeAccountCategoryType.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccountCategoryType.DvFixLength = false;
            this.cmbPayeeAccountCategoryType.DvLinkedLabel = this.lblPayeeAccountType;
            this.cmbPayeeAccountCategoryType.DvMaxLength = 0;
            this.cmbPayeeAccountCategoryType.DvMinLength = 0;
            this.cmbPayeeAccountCategoryType.DvRegCode = "";
            this.cmbPayeeAccountCategoryType.DvRequired = true;
            this.cmbPayeeAccountCategoryType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccountCategoryType.DvValidateEnabled = true;
            this.cmbPayeeAccountCategoryType.DvValidator = this.validatorList1;
            this.cmbPayeeAccountCategoryType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccountCategoryType, "cmbPayeeAccountCategoryType");
            this.cmbPayeeAccountCategoryType.Name = "cmbPayeeAccountCategoryType";
            // 
            // lblRequired3
            // 
            resources.ApplyResources(this.lblRequired3, "lblRequired3");
            this.lblRequired3.ForeColor = System.Drawing.Color.Red;
            this.lblRequired3.Name = "lblRequired3";
            // 
            // lblRequired1
            // 
            resources.ApplyResources(this.lblRequired1, "lblRequired1");
            this.lblRequired1.ForeColor = System.Drawing.Color.Red;
            this.lblRequired1.Name = "lblRequired1";
            // 
            // lblRequired2
            // 
            resources.ApplyResources(this.lblRequired2, "lblRequired2");
            this.lblRequired2.ForeColor = System.Drawing.Color.Red;
            this.lblRequired2.Name = "lblRequired2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSeperator1);
            this.panel1.Controls.Add(this.rbIsBocAccount);
            this.panel1.Controls.Add(this.rbIsOtherAccount);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbTip);
            this.panel2.Controls.Add(this.edtPayeeName);
            this.panel2.Controls.Add(this.cmbPayeeAccountCategoryType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblPayeeName);
            this.panel2.Controls.Add(this.lblRequired1);
            this.panel2.Controls.Add(this.lblRequired2);
            this.panel2.Controls.Add(this.edtPayeeAccount);
            this.panel2.Controls.Add(this.tbRowIndex);
            this.panel2.Controls.Add(this.edtPayeeSerial);
            this.panel2.Controls.Add(this.lblPayeeAccount);
            this.panel2.Controls.Add(this.lblPayeeAccountType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblPayeeSerial);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::CommonClient.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.MouseHover += new System.EventHandler(this.pbTip_MouseHover);
            // 
            // tbRowIndex
            // 
            this.tbRowIndex.BackColor = System.Drawing.SystemColors.Control;
            this.tbRowIndex.DvDataField = null;
            this.tbRowIndex.DvEditorValueChanged = false;
            this.tbRowIndex.DvErrorProvider = this.errorProvider1;
            this.tbRowIndex.DvFixLength = false;
            this.tbRowIndex.DvLinkedLabel = this.label5;
            this.tbRowIndex.DvMaxLength = 0;
            this.tbRowIndex.DvMinLength = 0;
            this.tbRowIndex.DvRegCode = "";
            this.tbRowIndex.DvRequired = false;
            this.tbRowIndex.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRowIndex.DvValidateEnabled = true;
            this.tbRowIndex.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRowIndex, "tbRowIndex");
            this.tbRowIndex.Name = "tbRowIndex";
            this.tbRowIndex.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panelOtherBank
            // 
            this.panelOtherBank.Controls.Add(this.buttonQueryC);
            this.panelOtherBank.Controls.Add(this.buttonQueryO);
            this.panelOtherBank.Controls.Add(this.edtPayeeClearBank);
            this.panelOtherBank.Controls.Add(this.edtPayeeBankName);
            this.panelOtherBank.Controls.Add(this.lblPayeeClearBank);
            this.panelOtherBank.Controls.Add(this.label2);
            this.panelOtherBank.Controls.Add(this.lblPayeeBankName);
            this.panelOtherBank.Controls.Add(this.lblRequired3);
            resources.ApplyResources(this.panelOtherBank, "panelOtherBank");
            this.panelOtherBank.Name = "panelOtherBank";
            // 
            // buttonQueryC
            // 
            resources.ApplyResources(this.buttonQueryC, "buttonQueryC");
            this.buttonQueryC.Name = "buttonQueryC";
            this.buttonQueryC.UseVisualStyleBackColor = true;
            this.buttonQueryC.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonQueryO
            // 
            resources.ApplyResources(this.buttonQueryO, "buttonQueryO");
            this.buttonQueryO.Name = "buttonQueryO";
            this.buttonQueryO.UseVisualStyleBackColor = true;
            this.buttonQueryO.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonReset);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.buttonSubmit);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ThemeName = CommonClient.Controls.ThemeName.Corp_Red;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // buttonSubmit
            // 
            resources.ApplyResources(this.buttonSubmit, "buttonSubmit");
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.ThemeName = CommonClient.Controls.ThemeName.Corp_Red;
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // pCertify
            // 
            this.pCertify.Controls.Add(this.cmbPayeeAccountProvince);
            this.pCertify.Controls.Add(this.lbProvince);
            this.pCertify.Controls.Add(this.cmbCertifyType);
            this.pCertify.Controls.Add(this.tbCertifyNo);
            this.pCertify.Controls.Add(this.label4);
            this.pCertify.Controls.Add(this.label3);
            resources.ApplyResources(this.pCertify, "pCertify");
            this.pCertify.Name = "pCertify";
            // 
            // cmbPayeeAccountProvince
            // 
            this.cmbPayeeAccountProvince.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccountProvince.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPayeeAccountProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeAccountProvince.DvDataField = null;
            this.cmbPayeeAccountProvince.DvEditorValueChanged = false;
            this.cmbPayeeAccountProvince.DvErrorProvider = this.errorProvider1;
            this.cmbPayeeAccountProvince.DvFixLength = false;
            this.cmbPayeeAccountProvince.DvLinkedLabel = this.lbProvince;
            this.cmbPayeeAccountProvince.DvMaxLength = 0;
            this.cmbPayeeAccountProvince.DvMinLength = 0;
            this.cmbPayeeAccountProvince.DvRegCode = "";
            this.cmbPayeeAccountProvince.DvRequired = false;
            this.cmbPayeeAccountProvince.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbPayeeAccountProvince.DvValidateEnabled = true;
            this.cmbPayeeAccountProvince.DvValidator = this.validatorList1;
            this.cmbPayeeAccountProvince.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPayeeAccountProvince, "cmbPayeeAccountProvince");
            this.cmbPayeeAccountProvince.Name = "cmbPayeeAccountProvince";
            // 
            // lbProvince
            // 
            resources.ApplyResources(this.lbProvince, "lbProvince");
            this.lbProvince.Name = "lbProvince";
            // 
            // cmbCertifyType
            // 
            this.cmbCertifyType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCertifyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCertifyType.DvDataField = null;
            this.cmbCertifyType.DvEditorValueChanged = false;
            this.cmbCertifyType.DvErrorProvider = this.errorProvider1;
            this.cmbCertifyType.DvFixLength = false;
            this.cmbCertifyType.DvLinkedLabel = this.label3;
            this.cmbCertifyType.DvMaxLength = 0;
            this.cmbCertifyType.DvMinLength = 0;
            this.cmbCertifyType.DvRegCode = "";
            this.cmbCertifyType.DvRequired = false;
            this.cmbCertifyType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbCertifyType.DvValidateEnabled = true;
            this.cmbCertifyType.DvValidator = this.validatorList1;
            this.cmbCertifyType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCertifyType, "cmbCertifyType");
            this.cmbCertifyType.Name = "cmbCertifyType";
            this.cmbCertifyType.SelectedIndexChanged += new System.EventHandler(this.cmbCertifyType_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbCertifyNo
            // 
            this.tbCertifyNo.BackColor = System.Drawing.SystemColors.Window;
            this.tbCertifyNo.DvDataField = null;
            this.tbCertifyNo.DvEditorValueChanged = false;
            this.tbCertifyNo.DvErrorProvider = this.errorProvider1;
            this.tbCertifyNo.DvFixLength = false;
            this.tbCertifyNo.DvLinkedLabel = this.label4;
            this.tbCertifyNo.DvMaxLength = 18;
            this.tbCertifyNo.DvMinLength = 15;
            this.tbCertifyNo.DvRegCode = "reg579";
            this.tbCertifyNo.DvRequired = false;
            this.tbCertifyNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCertifyNo.DvValidateEnabled = true;
            this.tbCertifyNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCertifyNo, "tbCertifyNo");
            this.tbCertifyNo.Name = "tbCertifyNo";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.edtPayeeEmail);
            this.panel5.Controls.Add(this.edtPayeePhone);
            this.panel5.Controls.Add(this.edtPayeeAddress);
            this.panel5.Controls.Add(this.edtPayeeFax);
            this.panel5.Controls.Add(this.lblPayeeFax);
            this.panel5.Controls.Add(this.lblPayeePhone);
            this.panel5.Controls.Add(this.lblPayeeEmail);
            this.panel5.Controls.Add(this.lblPayeeAddress);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // edtPayeeEmail
            // 
            this.edtPayeeEmail.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeEmail.DvDataField = null;
            this.edtPayeeEmail.DvEditorValueChanged = false;
            this.edtPayeeEmail.DvErrorProvider = this.errorProvider1;
            this.edtPayeeEmail.DvFixLength = false;
            this.edtPayeeEmail.DvLinkedLabel = this.lblPayeeEmail;
            this.edtPayeeEmail.DvMaxLength = 30;
            this.edtPayeeEmail.DvMinLength = 0;
            this.edtPayeeEmail.DvRegCode = "reg539";
            this.edtPayeeEmail.DvRequired = false;
            this.edtPayeeEmail.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeEmail.DvValidateEnabled = true;
            this.edtPayeeEmail.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeEmail, "edtPayeeEmail");
            this.edtPayeeEmail.Name = "edtPayeeEmail";
            // 
            // lblPayeeEmail
            // 
            resources.ApplyResources(this.lblPayeeEmail, "lblPayeeEmail");
            this.lblPayeeEmail.Name = "lblPayeeEmail";
            // 
            // edtPayeePhone
            // 
            this.edtPayeePhone.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeePhone.DvDataField = null;
            this.edtPayeePhone.DvEditorValueChanged = false;
            this.edtPayeePhone.DvErrorProvider = this.errorProvider1;
            this.edtPayeePhone.DvFixLength = false;
            this.edtPayeePhone.DvLinkedLabel = this.lblPayeePhone;
            this.edtPayeePhone.DvMaxLength = 15;
            this.edtPayeePhone.DvMinLength = 11;
            this.edtPayeePhone.DvRegCode = "reg57";
            this.edtPayeePhone.DvRequired = false;
            this.edtPayeePhone.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeePhone.DvValidateEnabled = true;
            this.edtPayeePhone.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeePhone, "edtPayeePhone");
            this.edtPayeePhone.Name = "edtPayeePhone";
            // 
            // lblPayeePhone
            // 
            resources.ApplyResources(this.lblPayeePhone, "lblPayeePhone");
            this.lblPayeePhone.Name = "lblPayeePhone";
            // 
            // edtPayeeAddress
            // 
            this.edtPayeeAddress.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeAddress.DvDataField = null;
            this.edtPayeeAddress.DvEditorValueChanged = false;
            this.edtPayeeAddress.DvErrorProvider = this.errorProvider1;
            this.edtPayeeAddress.DvFixLength = false;
            this.edtPayeeAddress.DvLinkedLabel = this.lblPayeeAddress;
            this.edtPayeeAddress.DvMaxLength = 70;
            this.edtPayeeAddress.DvMinLength = 0;
            this.edtPayeeAddress.DvRegCode = "reg686";
            this.edtPayeeAddress.DvRequired = false;
            this.edtPayeeAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeAddress.DvValidateEnabled = true;
            this.edtPayeeAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeAddress, "edtPayeeAddress");
            this.edtPayeeAddress.Name = "edtPayeeAddress";
            // 
            // lblPayeeAddress
            // 
            resources.ApplyResources(this.lblPayeeAddress, "lblPayeeAddress");
            this.lblPayeeAddress.Name = "lblPayeeAddress";
            // 
            // edtPayeeFax
            // 
            this.edtPayeeFax.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeFax.DvDataField = null;
            this.edtPayeeFax.DvEditorValueChanged = false;
            this.edtPayeeFax.DvErrorProvider = this.errorProvider1;
            this.edtPayeeFax.DvFixLength = false;
            this.edtPayeeFax.DvLinkedLabel = this.lblPayeeFax;
            this.edtPayeeFax.DvMaxLength = 12;
            this.edtPayeeFax.DvMinLength = 6;
            this.edtPayeeFax.DvRegCode = "reg612";
            this.edtPayeeFax.DvRequired = false;
            this.edtPayeeFax.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeFax.DvValidateEnabled = true;
            this.edtPayeeFax.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeFax, "edtPayeeFax");
            this.edtPayeeFax.Name = "edtPayeeFax";
            // 
            // lblPayeeFax
            // 
            resources.ApplyResources(this.lblPayeeFax, "lblPayeeFax");
            this.lblPayeeFax.Name = "lblPayeeFax";
            // 
            // PayeeEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pCertify);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelOtherBank);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            resources.ApplyResources(this, "$this");
            this.Name = "PayeeEditor";
            this.Load += new System.EventHandler(this.PayeeEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.panelOtherBank.ResumeLayout(false);
            this.panelOtherBank.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pCertify.ResumeLayout(false);
            this.pCertify.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSeperator1;
        private System.Windows.Forms.RadioButton rbIsOtherAccount;
        private System.Windows.Forms.RadioButton rbIsBocAccount;
        private System.Windows.Forms.Label lblPayeeAccountType;
        private TextBoxCanValidate edtPayeeSerial;
        private System.Windows.Forms.Label lblPayeeSerial;
        private TextBoxCanValidate edtPayeeAccount;
        private TextBoxCanValidate edtPayeeName;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label lblPayeeName;
        private System.Windows.Forms.Label lblPayeeBankName;
        private System.Windows.Forms.Label lblPayeeClearBank;
        private TextBoxCanValidate edtPayeeClearBank;
        private TextBoxCanValidate edtPayeeBankName;
        private ComboBoxCanValidate cmbPayeeAccountCategoryType;
        private System.Windows.Forms.Label lblRequired3;
        private System.Windows.Forms.Label lblRequired1;
        private System.Windows.Forms.Label lblRequired2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelOtherBank;
        private ThemedButton buttonQueryC;
        private ThemedButton buttonQueryO;
        private System.Windows.Forms.Panel panel3;
        private ThemedButton buttonSubmit;
        private System.Windows.Forms.Panel pCertify;
        private ThemedButton buttonReset;
        private ComboBoxCanValidate cmbCertifyType;
        private TextBoxCanValidate tbCertifyNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ThemedButton btnEdit;
        private System.Windows.Forms.Label label5;
        private TextBoxCanValidate tbRowIndex;
        private System.Windows.Forms.Panel panel5;
        private TextBoxCanValidate edtPayeeEmail;
        private TextBoxCanValidate edtPayeePhone;
        private TextBoxCanValidate edtPayeeAddress;
        private TextBoxCanValidate edtPayeeFax;
        private System.Windows.Forms.Label lblPayeeFax;
        private System.Windows.Forms.Label lblPayeePhone;
        private System.Windows.Forms.Label lblPayeeEmail;
        private System.Windows.Forms.Label lblPayeeAddress;
        private System.Windows.Forms.PictureBox pbTip;
        private ComboBoxCanValidate cmbPayeeAccountProvince;
        private System.Windows.Forms.Label lbProvince;
    }
}
