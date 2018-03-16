using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class TransferGlobalPayeeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferGlobalPayeeEditor));
            this.tbPayeeAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPayeeName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeName = new System.Windows.Forms.Label();
            this.lbPayeeAccount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSeperator1 = new System.Windows.Forms.Label();
            this.rbBocAccount = new System.Windows.Forms.RadioButton();
            this.rbForeignAccount = new System.Windows.Forms.RadioButton();
            this.rbOtherAccount = new System.Windows.Forms.RadioButton();
            this.lbSerialNo = new System.Windows.Forms.Label();
            this.tbSerialNo = new CommonClient.Controls.TextBoxCanValidate();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.tbRowIndex = new CommonClient.Controls.TextBoxCanValidate();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.pAccountDesc = new System.Windows.Forms.Panel();
            this.lbAccountDesc = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbTips = new System.Windows.Forms.PictureBox();
            this.pAddressDesc = new System.Windows.Forms.Panel();
            this.lbAddressDesc = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonReset = new CommonClient.Controls.ThemedButton();
            this.btnEdit = new CommonClient.Controls.ThemedButton();
            this.buttonSubmit = new CommonClient.Controls.ThemedButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbCountry = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCountry = new System.Windows.Forms.Label();
            this.btnQueryCorrespondentBank = new CommonClient.Controls.ThemedButton();
            this.btnQueryCountry = new CommonClient.Controls.ThemedButton();
            this.tbPayeeOpenBankAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeOpenBankAddress = new System.Windows.Forms.Label();
            this.tbPayeeOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeOpenBankName = new System.Windows.Forms.Label();
            this.lbFax = new System.Windows.Forms.Label();
            this.btnQueryOpenBank = new CommonClient.Controls.ThemedButton();
            this.tbFax = new CommonClient.Controls.TextBoxCanValidate();
            this.tbCorrespondentBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCorrespondentBankName = new System.Windows.Forms.Label();
            this.tbTel = new CommonClient.Controls.TextBoxCanValidate();
            this.lbTel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCorrespondentBankAddress = new CommonClient.Controls.TextBoxCanValidate();
            this.lbCorrespondentBankAddress = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEamil = new CommonClient.Controls.TextBoxCanValidate();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPayeeAccountInCorrespondentBank = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayeeAccountInCorrespondentBank = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.pAccountDesc.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTips)).BeginInit();
            this.pAddressDesc.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPayeeAddress
            // 
            this.tbPayeeAddress.DvDataField = null;
            this.tbPayeeAddress.DvEditorValueChanged = false;
            this.tbPayeeAddress.DvErrorProvider = this.errorProvider1;
            this.tbPayeeAddress.DvLinkedLabel = this.lbPayeeAddress;
            this.tbPayeeAddress.DvMaxLength = 0;
            this.tbPayeeAddress.DvMinLength = 0;
            this.tbPayeeAddress.DvRegCode = null;
            this.tbPayeeAddress.DvRequired = false;
            this.tbPayeeAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeAddress.DvValidateEnabled = true;
            this.tbPayeeAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeAddress, "tbPayeeAddress");
            this.tbPayeeAddress.Name = "tbPayeeAddress";
            // 
            // lbPayeeAddress
            // 
            resources.ApplyResources(this.lbPayeeAddress, "lbPayeeAddress");
            this.lbPayeeAddress.Name = "lbPayeeAddress";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // tbPayeeName
            // 
            this.tbPayeeName.DvDataField = null;
            this.tbPayeeName.DvEditorValueChanged = false;
            this.tbPayeeName.DvErrorProvider = this.errorProvider1;
            this.tbPayeeName.DvLinkedLabel = this.lbPayeeName;
            this.tbPayeeName.DvMaxLength = 0;
            this.tbPayeeName.DvMinLength = 0;
            this.tbPayeeName.DvRegCode = null;
            this.tbPayeeName.DvRequired = false;
            this.tbPayeeName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeName.DvValidateEnabled = true;
            this.tbPayeeName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeName, "tbPayeeName");
            this.tbPayeeName.Name = "tbPayeeName";
            // 
            // lbPayeeName
            // 
            resources.ApplyResources(this.lbPayeeName, "lbPayeeName");
            this.lbPayeeName.Name = "lbPayeeName";
            // 
            // lbPayeeAccount
            // 
            resources.ApplyResources(this.lbPayeeAccount, "lbPayeeAccount");
            this.lbPayeeAccount.Name = "lbPayeeAccount";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSeperator1);
            this.panel1.Controls.Add(this.rbBocAccount);
            this.panel1.Controls.Add(this.rbForeignAccount);
            this.panel1.Controls.Add(this.rbOtherAccount);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lblSeperator1
            // 
            resources.ApplyResources(this.lblSeperator1, "lblSeperator1");
            this.lblSeperator1.ForeColor = System.Drawing.Color.Silver;
            this.lblSeperator1.Name = "lblSeperator1";
            // 
            // rbBocAccount
            // 
            resources.ApplyResources(this.rbBocAccount, "rbBocAccount");
            this.rbBocAccount.Checked = true;
            this.rbBocAccount.Name = "rbBocAccount";
            this.rbBocAccount.TabStop = true;
            this.rbBocAccount.UseVisualStyleBackColor = true;
            this.rbBocAccount.CheckedChanged += new System.EventHandler(this.rbAccount_CheckedChanged);
            // 
            // rbForeignAccount
            // 
            resources.ApplyResources(this.rbForeignAccount, "rbForeignAccount");
            this.rbForeignAccount.Name = "rbForeignAccount";
            this.rbForeignAccount.UseVisualStyleBackColor = true;
            this.rbForeignAccount.CheckedChanged += new System.EventHandler(this.rbAccount_CheckedChanged);
            // 
            // rbOtherAccount
            // 
            resources.ApplyResources(this.rbOtherAccount, "rbOtherAccount");
            this.rbOtherAccount.Name = "rbOtherAccount";
            this.rbOtherAccount.UseVisualStyleBackColor = true;
            this.rbOtherAccount.CheckedChanged += new System.EventHandler(this.rbAccount_CheckedChanged);
            // 
            // lbSerialNo
            // 
            resources.ApplyResources(this.lbSerialNo, "lbSerialNo");
            this.lbSerialNo.Name = "lbSerialNo";
            // 
            // tbSerialNo
            // 
            this.tbSerialNo.DvDataField = null;
            this.tbSerialNo.DvEditorValueChanged = false;
            this.tbSerialNo.DvErrorProvider = this.errorProvider1;
            this.tbSerialNo.DvLinkedLabel = this.lbSerialNo;
            this.tbSerialNo.DvMaxLength = 0;
            this.tbSerialNo.DvMinLength = 0;
            this.tbSerialNo.DvRegCode = null;
            this.tbSerialNo.DvRequired = false;
            this.tbSerialNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbSerialNo.DvValidateEnabled = true;
            this.tbSerialNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbSerialNo, "tbSerialNo");
            this.tbSerialNo.Name = "tbSerialNo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbTip);
            this.panel2.Controls.Add(this.tbRowIndex);
            this.panel2.Controls.Add(this.tbAccount);
            this.panel2.Controls.Add(this.tbSerialNo);
            this.panel2.Controls.Add(this.lbPayeeAccount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbSerialNo);
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
            this.tbRowIndex.DvDataField = null;
            this.tbRowIndex.DvEditorValueChanged = false;
            this.tbRowIndex.DvErrorProvider = this.errorProvider1;
            this.tbRowIndex.DvLinkedLabel = this.label6;
            this.tbRowIndex.DvMaxLength = 0;
            this.tbRowIndex.DvMinLength = 0;
            this.tbRowIndex.DvRegCode = null;
            this.tbRowIndex.DvRequired = false;
            this.tbRowIndex.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRowIndex.DvValidateEnabled = true;
            this.tbRowIndex.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRowIndex, "tbRowIndex");
            this.tbRowIndex.Name = "tbRowIndex";
            this.tbRowIndex.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbAccount
            // 
            this.tbAccount.DvDataField = null;
            this.tbAccount.DvEditorValueChanged = false;
            this.tbAccount.DvErrorProvider = this.errorProvider1;
            this.tbAccount.DvLinkedLabel = this.lbPayeeAccount;
            this.tbAccount.DvMaxLength = 0;
            this.tbAccount.DvMinLength = 0;
            this.tbAccount.DvRegCode = null;
            this.tbAccount.DvRequired = false;
            this.tbAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbAccount.DvValidateEnabled = true;
            this.tbAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbAccount, "tbAccount");
            this.tbAccount.Name = "tbAccount";
            // 
            // pAccountDesc
            // 
            this.pAccountDesc.Controls.Add(this.lbAccountDesc);
            resources.ApplyResources(this.pAccountDesc, "pAccountDesc");
            this.pAccountDesc.Name = "pAccountDesc";
            // 
            // lbAccountDesc
            // 
            resources.ApplyResources(this.lbAccountDesc, "lbAccountDesc");
            this.lbAccountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAccountDesc.Name = "lbAccountDesc";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbTips);
            this.panel4.Controls.Add(this.tbPayeeName);
            this.panel4.Controls.Add(this.tbPayeeAddress);
            this.panel4.Controls.Add(this.lbPayeeName);
            this.panel4.Controls.Add(this.lbPayeeAddress);
            this.panel4.Controls.Add(this.label5);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // pbTips
            // 
            this.pbTips.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTips.Image = global::CommonClient.Properties.Resources.tips;
            resources.ApplyResources(this.pbTips, "pbTips");
            this.pbTips.Name = "pbTips";
            this.pbTips.TabStop = false;
            this.pbTips.MouseHover += new System.EventHandler(this.pbTips_MouseHover);
            // 
            // pAddressDesc
            // 
            this.pAddressDesc.Controls.Add(this.lbAddressDesc);
            resources.ApplyResources(this.pAddressDesc, "pAddressDesc");
            this.pAddressDesc.Name = "pAddressDesc";
            // 
            // lbAddressDesc
            // 
            resources.ApplyResources(this.lbAddressDesc, "lbAddressDesc");
            this.lbAddressDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAddressDesc.Name = "lbAddressDesc";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.buttonReset);
            this.panel7.Controls.Add(this.btnEdit);
            this.panel7.Controls.Add(this.buttonSubmit);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
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
            // panel6
            // 
            this.panel6.Controls.Add(this.tbCountry);
            this.panel6.Controls.Add(this.btnQueryCorrespondentBank);
            this.panel6.Controls.Add(this.btnQueryCountry);
            this.panel6.Controls.Add(this.tbPayeeOpenBankAddress);
            this.panel6.Controls.Add(this.tbPayeeOpenBankName);
            this.panel6.Controls.Add(this.lbFax);
            this.panel6.Controls.Add(this.btnQueryOpenBank);
            this.panel6.Controls.Add(this.tbFax);
            this.panel6.Controls.Add(this.tbCorrespondentBankName);
            this.panel6.Controls.Add(this.tbTel);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.tbCorrespondentBankAddress);
            this.panel6.Controls.Add(this.lbEmail);
            this.panel6.Controls.Add(this.lbCountry);
            this.panel6.Controls.Add(this.tbEamil);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.tbPayeeAccountInCorrespondentBank);
            this.panel6.Controls.Add(this.lbPayeeOpenBankName);
            this.panel6.Controls.Add(this.lbPayeeOpenBankAddress);
            this.panel6.Controls.Add(this.lbCorrespondentBankName);
            this.panel6.Controls.Add(this.lbCorrespondentBankAddress);
            this.panel6.Controls.Add(this.lbPayeeAccountInCorrespondentBank);
            this.panel6.Controls.Add(this.lbTel);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // tbCountry
            // 
            this.tbCountry.DvDataField = null;
            this.tbCountry.DvEditorValueChanged = false;
            this.tbCountry.DvErrorProvider = this.errorProvider1;
            this.tbCountry.DvLinkedLabel = this.lbCountry;
            this.tbCountry.DvMaxLength = 0;
            this.tbCountry.DvMinLength = 0;
            this.tbCountry.DvRegCode = null;
            this.tbCountry.DvRequired = false;
            this.tbCountry.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCountry.DvValidateEnabled = true;
            this.tbCountry.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCountry, "tbCountry");
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.ReadOnly = true;
            // 
            // lbCountry
            // 
            resources.ApplyResources(this.lbCountry, "lbCountry");
            this.lbCountry.Name = "lbCountry";
            // 
            // btnQueryCorrespondentBank
            // 
            resources.ApplyResources(this.btnQueryCorrespondentBank, "btnQueryCorrespondentBank");
            this.btnQueryCorrespondentBank.Name = "btnQueryCorrespondentBank";
            this.btnQueryCorrespondentBank.UseVisualStyleBackColor = true;
            this.btnQueryCorrespondentBank.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // btnQueryCountry
            // 
            resources.ApplyResources(this.btnQueryCountry, "btnQueryCountry");
            this.btnQueryCountry.Name = "btnQueryCountry";
            this.btnQueryCountry.UseVisualStyleBackColor = true;
            this.btnQueryCountry.Click += new System.EventHandler(this.btnQueryCountry_Click);
            // 
            // tbPayeeOpenBankAddress
            // 
            this.tbPayeeOpenBankAddress.DvDataField = null;
            this.tbPayeeOpenBankAddress.DvEditorValueChanged = false;
            this.tbPayeeOpenBankAddress.DvErrorProvider = this.errorProvider1;
            this.tbPayeeOpenBankAddress.DvLinkedLabel = this.lbPayeeOpenBankAddress;
            this.tbPayeeOpenBankAddress.DvMaxLength = 0;
            this.tbPayeeOpenBankAddress.DvMinLength = 0;
            this.tbPayeeOpenBankAddress.DvRegCode = null;
            this.tbPayeeOpenBankAddress.DvRequired = false;
            this.tbPayeeOpenBankAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeOpenBankAddress.DvValidateEnabled = true;
            this.tbPayeeOpenBankAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeOpenBankAddress, "tbPayeeOpenBankAddress");
            this.tbPayeeOpenBankAddress.Name = "tbPayeeOpenBankAddress";
            // 
            // lbPayeeOpenBankAddress
            // 
            resources.ApplyResources(this.lbPayeeOpenBankAddress, "lbPayeeOpenBankAddress");
            this.lbPayeeOpenBankAddress.Name = "lbPayeeOpenBankAddress";
            // 
            // tbPayeeOpenBankName
            // 
            this.tbPayeeOpenBankName.DvDataField = null;
            this.tbPayeeOpenBankName.DvEditorValueChanged = false;
            this.tbPayeeOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbPayeeOpenBankName.DvLinkedLabel = this.lbPayeeOpenBankName;
            this.tbPayeeOpenBankName.DvMaxLength = 0;
            this.tbPayeeOpenBankName.DvMinLength = 0;
            this.tbPayeeOpenBankName.DvRegCode = null;
            this.tbPayeeOpenBankName.DvRequired = false;
            this.tbPayeeOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeOpenBankName.DvValidateEnabled = true;
            this.tbPayeeOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeOpenBankName, "tbPayeeOpenBankName");
            this.tbPayeeOpenBankName.Name = "tbPayeeOpenBankName";
            this.tbPayeeOpenBankName.ReadOnly = true;
            // 
            // lbPayeeOpenBankName
            // 
            resources.ApplyResources(this.lbPayeeOpenBankName, "lbPayeeOpenBankName");
            this.lbPayeeOpenBankName.Name = "lbPayeeOpenBankName";
            // 
            // lbFax
            // 
            resources.ApplyResources(this.lbFax, "lbFax");
            this.lbFax.Name = "lbFax";
            // 
            // btnQueryOpenBank
            // 
            resources.ApplyResources(this.btnQueryOpenBank, "btnQueryOpenBank");
            this.btnQueryOpenBank.Name = "btnQueryOpenBank";
            this.btnQueryOpenBank.UseVisualStyleBackColor = true;
            this.btnQueryOpenBank.Click += new System.EventHandler(this.btnQueryBank_Click);
            // 
            // tbFax
            // 
            this.tbFax.DvDataField = null;
            this.tbFax.DvEditorValueChanged = false;
            this.tbFax.DvErrorProvider = this.errorProvider1;
            this.tbFax.DvLinkedLabel = this.lbFax;
            this.tbFax.DvMaxLength = 0;
            this.tbFax.DvMinLength = 0;
            this.tbFax.DvRegCode = null;
            this.tbFax.DvRequired = false;
            this.tbFax.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbFax.DvValidateEnabled = true;
            this.tbFax.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbFax, "tbFax");
            this.tbFax.Name = "tbFax";
            // 
            // tbCorrespondentBankName
            // 
            this.tbCorrespondentBankName.DvDataField = null;
            this.tbCorrespondentBankName.DvEditorValueChanged = false;
            this.tbCorrespondentBankName.DvErrorProvider = this.errorProvider1;
            this.tbCorrespondentBankName.DvLinkedLabel = this.lbCorrespondentBankName;
            this.tbCorrespondentBankName.DvMaxLength = 0;
            this.tbCorrespondentBankName.DvMinLength = 0;
            this.tbCorrespondentBankName.DvRegCode = null;
            this.tbCorrespondentBankName.DvRequired = false;
            this.tbCorrespondentBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCorrespondentBankName.DvValidateEnabled = true;
            this.tbCorrespondentBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCorrespondentBankName, "tbCorrespondentBankName");
            this.tbCorrespondentBankName.Name = "tbCorrespondentBankName";
            // 
            // lbCorrespondentBankName
            // 
            resources.ApplyResources(this.lbCorrespondentBankName, "lbCorrespondentBankName");
            this.lbCorrespondentBankName.Name = "lbCorrespondentBankName";
            // 
            // tbTel
            // 
            this.tbTel.DvDataField = null;
            this.tbTel.DvEditorValueChanged = false;
            this.tbTel.DvErrorProvider = this.errorProvider1;
            this.tbTel.DvLinkedLabel = this.lbTel;
            this.tbTel.DvMaxLength = 0;
            this.tbTel.DvMinLength = 0;
            this.tbTel.DvRegCode = null;
            this.tbTel.DvRequired = false;
            this.tbTel.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbTel.DvValidateEnabled = true;
            this.tbTel.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbTel, "tbTel");
            this.tbTel.Name = "tbTel";
            // 
            // lbTel
            // 
            resources.ApplyResources(this.lbTel, "lbTel");
            this.lbTel.Name = "lbTel";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // tbCorrespondentBankAddress
            // 
            this.tbCorrespondentBankAddress.DvDataField = null;
            this.tbCorrespondentBankAddress.DvEditorValueChanged = false;
            this.tbCorrespondentBankAddress.DvErrorProvider = this.errorProvider1;
            this.tbCorrespondentBankAddress.DvLinkedLabel = this.lbCorrespondentBankAddress;
            this.tbCorrespondentBankAddress.DvMaxLength = 0;
            this.tbCorrespondentBankAddress.DvMinLength = 0;
            this.tbCorrespondentBankAddress.DvRegCode = null;
            this.tbCorrespondentBankAddress.DvRequired = false;
            this.tbCorrespondentBankAddress.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCorrespondentBankAddress.DvValidateEnabled = true;
            this.tbCorrespondentBankAddress.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCorrespondentBankAddress, "tbCorrespondentBankAddress");
            this.tbCorrespondentBankAddress.Name = "tbCorrespondentBankAddress";
            // 
            // lbCorrespondentBankAddress
            // 
            resources.ApplyResources(this.lbCorrespondentBankAddress, "lbCorrespondentBankAddress");
            this.lbCorrespondentBankAddress.Name = "lbCorrespondentBankAddress";
            // 
            // lbEmail
            // 
            resources.ApplyResources(this.lbEmail, "lbEmail");
            this.lbEmail.Name = "lbEmail";
            // 
            // tbEamil
            // 
            this.tbEamil.DvDataField = null;
            this.tbEamil.DvEditorValueChanged = false;
            this.tbEamil.DvErrorProvider = this.errorProvider1;
            this.tbEamil.DvLinkedLabel = this.lbEmail;
            this.tbEamil.DvMaxLength = 0;
            this.tbEamil.DvMinLength = 0;
            this.tbEamil.DvRegCode = null;
            this.tbEamil.DvRequired = false;
            this.tbEamil.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbEamil.DvValidateEnabled = true;
            this.tbEamil.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbEamil, "tbEamil");
            this.tbEamil.Name = "tbEamil";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // tbPayeeAccountInCorrespondentBank
            // 
            this.tbPayeeAccountInCorrespondentBank.DvDataField = null;
            this.tbPayeeAccountInCorrespondentBank.DvEditorValueChanged = false;
            this.tbPayeeAccountInCorrespondentBank.DvErrorProvider = this.errorProvider1;
            this.tbPayeeAccountInCorrespondentBank.DvLinkedLabel = this.lbPayeeAccountInCorrespondentBank;
            this.tbPayeeAccountInCorrespondentBank.DvMaxLength = 0;
            this.tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
            this.tbPayeeAccountInCorrespondentBank.DvRegCode = null;
            this.tbPayeeAccountInCorrespondentBank.DvRequired = false;
            this.tbPayeeAccountInCorrespondentBank.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayeeAccountInCorrespondentBank.DvValidateEnabled = true;
            this.tbPayeeAccountInCorrespondentBank.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbPayeeAccountInCorrespondentBank, "tbPayeeAccountInCorrespondentBank");
            this.tbPayeeAccountInCorrespondentBank.Name = "tbPayeeAccountInCorrespondentBank";
            // 
            // lbPayeeAccountInCorrespondentBank
            // 
            resources.ApplyResources(this.lbPayeeAccountInCorrespondentBank, "lbPayeeAccountInCorrespondentBank");
            this.lbPayeeAccountInCorrespondentBank.Name = "lbPayeeAccountInCorrespondentBank";
            // 
            // TransferGlobalPayeeEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.pAddressDesc);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pAccountDesc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TransferGlobalPayeeEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.pAccountDesc.ResumeLayout(false);
            this.pAccountDesc.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTips)).EndInit();
            this.pAddressDesc.ResumeLayout(false);
            this.pAddressDesc.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxCanValidate tbPayeeAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPayeeAddress;
        private TextBoxCanValidate tbPayeeName;
        private System.Windows.Forms.Label lbPayeeName;
        private System.Windows.Forms.Label lbPayeeAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSeperator1;
        private System.Windows.Forms.RadioButton rbBocAccount;
        private System.Windows.Forms.RadioButton rbOtherAccount;
        private System.Windows.Forms.RadioButton rbForeignAccount;
        private System.Windows.Forms.Label lbSerialNo;
        private TextBoxCanValidate tbSerialNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pAccountDesc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pAddressDesc;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private TextBoxCanValidate tbCountry;
        private ThemedButton btnQueryCorrespondentBank;
        private ThemedButton btnQueryCountry;
        private System.Windows.Forms.Label lbPayeeOpenBankName;
        private System.Windows.Forms.Label lbPayeeOpenBankAddress;
        private TextBoxCanValidate tbPayeeOpenBankAddress;
        private TextBoxCanValidate tbPayeeOpenBankName;
        private System.Windows.Forms.Label lbCorrespondentBankName;
        private ThemedButton btnQueryOpenBank;
        private TextBoxCanValidate tbCorrespondentBankName;
        private System.Windows.Forms.Label lbCorrespondentBankAddress;
        private System.Windows.Forms.Label label9;
        private TextBoxCanValidate tbCorrespondentBankAddress;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label lbPayeeAccountInCorrespondentBank;
        private System.Windows.Forms.Label label7;
        private TextBoxCanValidate tbPayeeAccountInCorrespondentBank;
        private System.Windows.Forms.Label lbFax;
        private TextBoxCanValidate tbFax;
        private System.Windows.Forms.Label lbTel;
        private TextBoxCanValidate tbTel;
        private System.Windows.Forms.Label lbEmail;
        private TextBoxCanValidate tbEamil;
        private ThemedButton buttonReset;
        private ThemedButton btnEdit;
        private ThemedButton buttonSubmit;
        private TextBoxCanValidate tbRowIndex;
        private System.Windows.Forms.Label label6;
        private TextBoxCanValidate tbAccount;
        private System.Windows.Forms.Label lbAccountDesc;
        private System.Windows.Forms.Label lbAddressDesc;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.PictureBox pbTips;
    }
}
