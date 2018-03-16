﻿using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class AgentExpressPayerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentExpressPayerEditor));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonReset = new CommonClient.Controls.ThemedButton();
            this.btnEdit = new CommonClient.Controls.ThemedButton();
            this.buttonSubmit = new CommonClient.Controls.ThemedButton();
            this.panelOtherBank = new System.Windows.Forms.Panel();
            this.edtPayeeBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.buttonQueryO = new CommonClient.Controls.ThemedButton();
            this.lblPayeeBankName = new System.Windows.Forms.Label();
            this.lblRequired3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.lblPayeeSerial = new System.Windows.Forms.Label();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.edtPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeName = new System.Windows.Forms.Label();
            this.edtPayeeAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.tbRowIndex = new CommonClient.Controls.TextBoxCanValidate();
            this.label5 = new System.Windows.Forms.Label();
            this.edtPayeeSerial = new CommonClient.Controls.TextBoxCanValidate();
            this.lblRequired2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSeperator1 = new System.Windows.Forms.Label();
            this.rbIsBocAccount = new System.Windows.Forms.RadioButton();
            this.rbIsOtherAccount = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbPayeeAccountProvince = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbProvince = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbProtecolNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lblProtecolNo = new System.Windows.Forms.Label();
            this.lbProtecolNo = new System.Windows.Forms.Label();
            this.cmbCertifyType = new CommonClient.Controls.ComboBoxCanValidate();
            this.tbCertifyNo = new CommonClient.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.edtPayeeEmail = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeEmail = new System.Windows.Forms.Label();
            this.edtPayeePhone = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeePhone = new System.Windows.Forms.Label();
            this.edtPayeeAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeAddress = new System.Windows.Forms.Label();
            this.edtPayeeFax = new CommonClient.Controls.TextBoxCanValidate();
            this.lblPayeeFax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelOtherBank.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            // panelOtherBank
            // 
            this.panelOtherBank.Controls.Add(this.edtPayeeBankName);
            this.panelOtherBank.Controls.Add(this.buttonQueryO);
            this.panelOtherBank.Controls.Add(this.lblPayeeBankName);
            this.panelOtherBank.Controls.Add(this.lblRequired3);
            resources.ApplyResources(this.panelOtherBank, "panelOtherBank");
            this.panelOtherBank.Name = "panelOtherBank";
            // 
            // edtPayeeBankName
            // 
            this.edtPayeeBankName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeBankName.DvDataField = null;
            this.edtPayeeBankName.DvEditorValueChanged = false;
            this.edtPayeeBankName.DvErrorProvider = this.errorProvider1;
            this.edtPayeeBankName.DvLinkedLabel = null;
            this.edtPayeeBankName.DvMaxLength = 0;
            this.edtPayeeBankName.DvMinLength = 0;
            this.edtPayeeBankName.DvRegCode = "";
            this.edtPayeeBankName.DvRequired = false;
            this.edtPayeeBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeBankName.DvValidateEnabled = true;
            this.edtPayeeBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeBankName, "edtPayeeBankName");
            this.edtPayeeBankName.Name = "edtPayeeBankName";
            // 
            // buttonQueryO
            // 
            resources.ApplyResources(this.buttonQueryO, "buttonQueryO");
            this.buttonQueryO.Name = "buttonQueryO";
            this.buttonQueryO.UseVisualStyleBackColor = true;
            this.buttonQueryO.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // lblPayeeBankName
            // 
            resources.ApplyResources(this.lblPayeeBankName, "lblPayeeBankName");
            this.lblPayeeBankName.Name = "lblPayeeBankName";
            // 
            // lblRequired3
            // 
            resources.ApplyResources(this.lblRequired3, "lblRequired3");
            this.lblRequired3.ForeColor = System.Drawing.Color.Red;
            this.lblRequired3.Name = "lblRequired3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblPayeeAccount);
            this.panel2.Controls.Add(this.lblPayeeSerial);
            this.panel2.Controls.Add(this.pbTip);
            this.panel2.Controls.Add(this.edtPayeeName);
            this.panel2.Controls.Add(this.edtPayeeAccount);
            this.panel2.Controls.Add(this.tbRowIndex);
            this.panel2.Controls.Add(this.edtPayeeSerial);
            this.panel2.Controls.Add(this.lblPayeeName);
            this.panel2.Controls.Add(this.lblRequired2);
            this.panel2.Controls.Add(this.label5);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // lblPayeeAccount
            // 
            resources.ApplyResources(this.lblPayeeAccount, "lblPayeeAccount");
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            // 
            // lblPayeeSerial
            // 
            resources.ApplyResources(this.lblPayeeSerial, "lblPayeeSerial");
            this.lblPayeeSerial.Name = "lblPayeeSerial";
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
            // edtPayeeName
            // 
            this.edtPayeeName.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeName.DvDataField = null;
            this.edtPayeeName.DvEditorValueChanged = false;
            this.edtPayeeName.DvErrorProvider = this.errorProvider1;
            this.edtPayeeName.DvLinkedLabel = this.lblPayeeName;
            this.edtPayeeName.DvMaxLength = 0;
            this.edtPayeeName.DvMinLength = 0;
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
            // edtPayeeAccount
            // 
            this.edtPayeeAccount.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeAccount.DvDataField = null;
            this.edtPayeeAccount.DvEditorValueChanged = false;
            this.edtPayeeAccount.DvErrorProvider = this.errorProvider1;
            this.edtPayeeAccount.DvLinkedLabel = this.lblPayeeAccount;
            this.edtPayeeAccount.DvMaxLength = 0;
            this.edtPayeeAccount.DvMinLength = 0;
            this.edtPayeeAccount.DvRegCode = "";
            this.edtPayeeAccount.DvRequired = false;
            this.edtPayeeAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeAccount.DvValidateEnabled = true;
            this.edtPayeeAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeAccount, "edtPayeeAccount");
            this.edtPayeeAccount.Name = "edtPayeeAccount";
            // 
            // tbRowIndex
            // 
            this.tbRowIndex.BackColor = System.Drawing.SystemColors.Control;
            this.tbRowIndex.DvDataField = null;
            this.tbRowIndex.DvEditorValueChanged = false;
            this.tbRowIndex.DvErrorProvider = this.errorProvider1;
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
            // edtPayeeSerial
            // 
            this.edtPayeeSerial.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeSerial.DvDataField = null;
            this.edtPayeeSerial.DvEditorValueChanged = false;
            this.edtPayeeSerial.DvErrorProvider = this.errorProvider1;
            this.edtPayeeSerial.DvLinkedLabel = this.lblPayeeSerial;
            this.edtPayeeSerial.DvMaxLength = 0;
            this.edtPayeeSerial.DvMinLength = 0;
            this.edtPayeeSerial.DvRegCode = "";
            this.edtPayeeSerial.DvRequired = false;
            this.edtPayeeSerial.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayeeSerial.DvValidateEnabled = true;
            this.edtPayeeSerial.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayeeSerial, "edtPayeeSerial");
            this.edtPayeeSerial.Name = "edtPayeeSerial";
            // 
            // lblRequired2
            // 
            resources.ApplyResources(this.lblRequired2, "lblRequired2");
            this.lblRequired2.ForeColor = System.Drawing.Color.Red;
            this.lblRequired2.Name = "lblRequired2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSeperator1);
            this.panel1.Controls.Add(this.rbIsBocAccount);
            this.panel1.Controls.Add(this.rbIsOtherAccount);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lblSeperator1
            // 
            resources.ApplyResources(this.lblSeperator1, "lblSeperator1");
            this.lblSeperator1.ForeColor = System.Drawing.Color.Silver;
            this.lblSeperator1.Name = "lblSeperator1";
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
            // rbIsOtherAccount
            // 
            resources.ApplyResources(this.rbIsOtherAccount, "rbIsOtherAccount");
            this.rbIsOtherAccount.Name = "rbIsOtherAccount";
            this.rbIsOtherAccount.UseVisualStyleBackColor = true;
            this.rbIsOtherAccount.CheckedChanged += new System.EventHandler(this.rbIsBoccAccount_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbPayeeAccountProvince);
            this.panel5.Controls.Add(this.lbProvince);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // cmbPayeeAccountProvince
            // 
            this.cmbPayeeAccountProvince.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPayeeAccountProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeeAccountProvince.DvDataField = null;
            this.cmbPayeeAccountProvince.DvEditorValueChanged = false;
            this.cmbPayeeAccountProvince.DvErrorProvider = this.errorProvider1;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.tbProtecolNo);
            this.panel4.Controls.Add(this.lbProtecolNo);
            this.panel4.Controls.Add(this.cmbCertifyType);
            this.panel4.Controls.Add(this.tbCertifyNo);
            this.panel4.Controls.Add(this.edtPayeeEmail);
            this.panel4.Controls.Add(this.edtPayeePhone);
            this.panel4.Controls.Add(this.edtPayeeAddress);
            this.panel4.Controls.Add(this.edtPayeeFax);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblPayeeFax);
            this.panel4.Controls.Add(this.lblPayeePhone);
            this.panel4.Controls.Add(this.lblPayeeEmail);
            this.panel4.Controls.Add(this.lblPayeeAddress);
            this.panel4.Controls.Add(this.lblProtecolNo);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // tbProtecolNo
            // 
            this.tbProtecolNo.BackColor = System.Drawing.SystemColors.Window;
            this.tbProtecolNo.DvDataField = null;
            this.tbProtecolNo.DvEditorValueChanged = false;
            this.tbProtecolNo.DvErrorProvider = this.errorProvider1;
            this.tbProtecolNo.DvLinkedLabel = this.lblProtecolNo;
            this.tbProtecolNo.DvMaxLength = 0;
            this.tbProtecolNo.DvMinLength = 0;
            this.tbProtecolNo.DvRegCode = "";
            this.tbProtecolNo.DvRequired = false;
            this.tbProtecolNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbProtecolNo.DvValidateEnabled = true;
            this.tbProtecolNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbProtecolNo, "tbProtecolNo");
            this.tbProtecolNo.Name = "tbProtecolNo";
            // 
            // lblProtecolNo
            // 
            resources.ApplyResources(this.lblProtecolNo, "lblProtecolNo");
            this.lblProtecolNo.ForeColor = System.Drawing.Color.Red;
            this.lblProtecolNo.Name = "lblProtecolNo";
            // 
            // lbProtecolNo
            // 
            resources.ApplyResources(this.lbProtecolNo, "lbProtecolNo");
            this.lbProtecolNo.Name = "lbProtecolNo";
            // 
            // cmbCertifyType
            // 
            this.cmbCertifyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCertifyType.DvDataField = null;
            this.cmbCertifyType.DvEditorValueChanged = false;
            this.cmbCertifyType.DvErrorProvider = this.errorProvider1;
            this.cmbCertifyType.DvLinkedLabel = null;
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
            // 
            // tbCertifyNo
            // 
            this.tbCertifyNo.BackColor = System.Drawing.SystemColors.Window;
            this.tbCertifyNo.DvDataField = null;
            this.tbCertifyNo.DvEditorValueChanged = false;
            this.tbCertifyNo.DvErrorProvider = this.errorProvider1;
            this.tbCertifyNo.DvLinkedLabel = this.label4;
            this.tbCertifyNo.DvMaxLength = 0;
            this.tbCertifyNo.DvMinLength = 0;
            this.tbCertifyNo.DvRegCode = "";
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
            // edtPayeeEmail
            // 
            this.edtPayeeEmail.BackColor = System.Drawing.SystemColors.Window;
            this.edtPayeeEmail.DvDataField = null;
            this.edtPayeeEmail.DvEditorValueChanged = false;
            this.edtPayeeEmail.DvErrorProvider = this.errorProvider1;
            this.edtPayeeEmail.DvLinkedLabel = this.lblPayeeEmail;
            this.edtPayeeEmail.DvMaxLength = 0;
            this.edtPayeeEmail.DvMinLength = 0;
            this.edtPayeeEmail.DvRegCode = "";
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
            this.edtPayeePhone.DvLinkedLabel = this.lblPayeePhone;
            this.edtPayeePhone.DvMaxLength = 0;
            this.edtPayeePhone.DvMinLength = 0;
            this.edtPayeePhone.DvRegCode = "";
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
            this.edtPayeeAddress.DvLinkedLabel = this.lblPayeeAddress;
            this.edtPayeeAddress.DvMaxLength = 0;
            this.edtPayeeAddress.DvMinLength = 0;
            this.edtPayeeAddress.DvRegCode = "";
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
            this.edtPayeeFax.DvLinkedLabel = this.lblPayeeFax;
            this.edtPayeeFax.DvMaxLength = 0;
            this.edtPayeeFax.DvMinLength = 0;
            this.edtPayeeFax.DvRegCode = "";
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // AgentExpressPayerEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelOtherBank);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AgentExpressPayerEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panelOtherBank.ResumeLayout(false);
            this.panelOtherBank.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private ThemedButton buttonReset;
        private ThemedButton btnEdit;
        private ThemedButton buttonSubmit;
        private System.Windows.Forms.Panel panelOtherBank;
        private ThemedButton buttonQueryO;
        private Controls.TextBoxCanValidate edtPayeeBankName;
        private System.Windows.Forms.Label lblPayeeBankName;
        private System.Windows.Forms.Label lblRequired3;
        private System.Windows.Forms.Panel panel2;
        private Controls.TextBoxCanValidate edtPayeeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPayeeName;
        private System.Windows.Forms.Label lblRequired2;
        private Controls.TextBoxCanValidate edtPayeeAccount;
        private Controls.TextBoxCanValidate tbRowIndex;
        private Controls.TextBoxCanValidate edtPayeeSerial;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPayeeSerial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSeperator1;
        private System.Windows.Forms.RadioButton rbIsBocAccount;
        private System.Windows.Forms.RadioButton rbIsOtherAccount;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.Panel panel5;
        private ComboBoxCanValidate cmbPayeeAccountProvince;
        private System.Windows.Forms.Label lbProvince;
        private System.Windows.Forms.Panel panel4;
        private TextBoxCanValidate tbProtecolNo;
        private System.Windows.Forms.Label lblProtecolNo;
        private System.Windows.Forms.Label lbProtecolNo;
        private ComboBoxCanValidate cmbCertifyType;
        private TextBoxCanValidate tbCertifyNo;
        private System.Windows.Forms.Label label4;
        private TextBoxCanValidate edtPayeeEmail;
        private System.Windows.Forms.Label lblPayeeEmail;
        private TextBoxCanValidate edtPayeePhone;
        private System.Windows.Forms.Label lblPayeePhone;
        private TextBoxCanValidate edtPayeeAddress;
        private System.Windows.Forms.Label lblPayeeAddress;
        private TextBoxCanValidate edtPayeeFax;
        private System.Windows.Forms.Label lblPayeeFax;
        private System.Windows.Forms.Label label3;
    }
}
