using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class TransferEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferEditor));
            this.edtPayAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblOperatorOrder = new System.Windows.Forms.Label();
            this.lblAddtion = new System.Windows.Forms.Label();
            this.lblPayeeBankName = new System.Windows.Forms.Label();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFeeChargingAccountType = new CommonClient.Controls.ComboBoxCanValidate();
            this.cmbAdditionalComment = new CommonClient.Controls.ComboBoxCanValidate();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbExpress = new System.Windows.Forms.RadioButton();
            this.lblPayeeEmail = new System.Windows.Forms.Label();
            this.tbEmail = new CommonClient.Controls.TextBoxCanValidate();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new CommonClient.Controls.TextBoxCanValidate();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pOverBankIn = new System.Windows.Forms.Panel();
            this.cmbBusinessType = new CommonClient.Controls.ComboBoxCanValidate();
            this.label7 = new System.Windows.Forms.Label();
            this.tbProtecol = new CommonClient.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.tbCustomerRef = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAmountDesc = new System.Windows.Forms.Label();
            this.pDateTime = new System.Windows.Forms.Panel();
            this.p_lockPayeFeeNo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkContent = new System.Windows.Forms.LinkLabel();
            this.p_lockOperateOrder = new System.Windows.Forms.Panel();
            this.p_lockPayDate = new System.Windows.Forms.Panel();
            this.dtDesignedPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblpurpose = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pOverBankIn.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.pDateTime.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtPayAmount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.edtPayAmount, null);
            this.edtPayAmount.DvDataField = null;
            this.edtPayAmount.DvEditorValueChanged = false;
            this.edtPayAmount.DvErrorProvider = this.errorProvider1;
            this.edtPayAmount.DvFixLength = false;
            this.edtPayAmount.DvLinkedLabel = this.lblAmount;
            this.edtPayAmount.DvMaxLength = 0;
            this.edtPayAmount.DvMinLength = 0;
            this.edtPayAmount.DvRegCode = null;
            this.edtPayAmount.DvRequired = false;
            this.edtPayAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayAmount.DvValidateEnabled = true;
            this.edtPayAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtPayAmount, "edtPayAmount");
            this.edtPayAmount.Name = "edtPayAmount";
            this.edtPayAmount.TextChanged += new System.EventHandler(this.edtPayAmount_TextChanged);
            // 
            // lblAmount
            // 
            resources.ApplyResources(this.lblAmount, "lblAmount");
            this.lblAmount.Name = "lblAmount";
            // 
            // lblOperatorOrder
            // 
            resources.ApplyResources(this.lblOperatorOrder, "lblOperatorOrder");
            this.lblOperatorOrder.Name = "lblOperatorOrder";
            // 
            // lblAddtion
            // 
            resources.ApplyResources(this.lblAddtion, "lblAddtion");
            this.lblAddtion.Name = "lblAddtion";
            // 
            // lblPayeeBankName
            // 
            resources.ApplyResources(this.lblPayeeBankName, "lblPayeeBankName");
            this.lblPayeeBankName.Name = "lblPayeeBankName";
            // 
            // lblPayeeAccount
            // 
            resources.ApplyResources(this.lblPayeeAccount, "lblPayeeAccount");
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmbFeeChargingAccountType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbFeeChargingAccountType, this.ambiguityInputAgent1);
            this.cmbFeeChargingAccountType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbFeeChargingAccountType.DvDataField = null;
            this.cmbFeeChargingAccountType.DvEditorValueChanged = false;
            this.cmbFeeChargingAccountType.DvErrorProvider = this.errorProvider1;
            this.cmbFeeChargingAccountType.DvFixLength = false;
            this.cmbFeeChargingAccountType.DvLinkedLabel = null;
            this.cmbFeeChargingAccountType.DvMaxLength = 0;
            this.cmbFeeChargingAccountType.DvMinLength = 0;
            this.cmbFeeChargingAccountType.DvRegCode = null;
            this.cmbFeeChargingAccountType.DvRequired = true;
            this.cmbFeeChargingAccountType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbFeeChargingAccountType.DvValidateEnabled = true;
            this.cmbFeeChargingAccountType.DvValidator = this.validatorList1;
            this.cmbFeeChargingAccountType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbFeeChargingAccountType, "cmbFeeChargingAccountType");
            this.cmbFeeChargingAccountType.Name = "cmbFeeChargingAccountType";
            // 
            // cmbAdditionalComment
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbAdditionalComment, null);
            this.cmbAdditionalComment.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAdditionalComment.DvDataField = null;
            this.cmbAdditionalComment.DvEditorValueChanged = false;
            this.cmbAdditionalComment.DvErrorProvider = this.errorProvider1;
            this.cmbAdditionalComment.DvFixLength = false;
            this.cmbAdditionalComment.DvLinkedLabel = this.lblAddtion;
            this.cmbAdditionalComment.DvMaxLength = 0;
            this.cmbAdditionalComment.DvMinLength = 0;
            this.cmbAdditionalComment.DvRegCode = null;
            this.cmbAdditionalComment.DvRequired = false;
            this.cmbAdditionalComment.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbAdditionalComment.DvValidateEnabled = true;
            this.cmbAdditionalComment.DvValidator = this.validatorList1;
            this.cmbAdditionalComment.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAdditionalComment, "cmbAdditionalComment");
            this.cmbAdditionalComment.Name = "cmbAdditionalComment";
            // 
            // rbNormal
            // 
            resources.ApplyResources(this.rbNormal, "rbNormal");
            this.rbNormal.Checked = true;
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.TabStop = true;
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbExpress
            // 
            resources.ApplyResources(this.rbExpress, "rbExpress");
            this.rbExpress.Name = "rbExpress";
            this.rbExpress.UseVisualStyleBackColor = true;
            // 
            // lblPayeeEmail
            // 
            resources.ApplyResources(this.lblPayeeEmail, "lblPayeeEmail");
            this.lblPayeeEmail.Name = "lblPayeeEmail";
            // 
            // tbEmail
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbEmail, null);
            this.tbEmail.DvDataField = null;
            this.tbEmail.DvEditorValueChanged = false;
            this.tbEmail.DvErrorProvider = this.errorProvider1;
            this.tbEmail.DvFixLength = false;
            this.tbEmail.DvLinkedLabel = this.lblPayeeEmail;
            this.tbEmail.DvMaxLength = 0;
            this.tbEmail.DvMinLength = 0;
            this.tbEmail.DvRegCode = null;
            this.tbEmail.DvRequired = false;
            this.tbEmail.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbEmail.DvValidateEnabled = true;
            this.tbEmail.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbEmail, "tbEmail");
            this.tbEmail.Name = "tbEmail";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // textBox1
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.textBox1, null);
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.DvDataField = null;
            this.textBox1.DvEditorValueChanged = false;
            this.textBox1.DvErrorProvider = this.errorProvider1;
            this.textBox1.DvFixLength = false;
            this.textBox1.DvLinkedLabel = null;
            this.textBox1.DvMaxLength = 0;
            this.textBox1.DvMinLength = 0;
            this.textBox1.DvRegCode = null;
            this.textBox1.DvRequired = false;
            this.textBox1.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.textBox1.DvValidateEnabled = true;
            this.textBox1.DvValidator = null;
            this.textBox1.Name = "textBox1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pOverBankIn);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.pDateTime);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // pOverBankIn
            // 
            this.pOverBankIn.Controls.Add(this.cmbBusinessType);
            this.pOverBankIn.Controls.Add(this.tbProtecol);
            this.pOverBankIn.Controls.Add(this.label4);
            this.pOverBankIn.Controls.Add(this.label7);
            this.pOverBankIn.Controls.Add(this.label8);
            this.pOverBankIn.Controls.Add(this.label6);
            resources.ApplyResources(this.pOverBankIn, "pOverBankIn");
            this.pOverBankIn.Name = "pOverBankIn";
            // 
            // cmbBusinessType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbBusinessType, null);
            this.cmbBusinessType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusinessType.DvDataField = null;
            this.cmbBusinessType.DvEditorValueChanged = false;
            this.cmbBusinessType.DvErrorProvider = this.errorProvider1;
            this.cmbBusinessType.DvFixLength = false;
            this.cmbBusinessType.DvLinkedLabel = this.label7;
            this.cmbBusinessType.DvMaxLength = 0;
            this.cmbBusinessType.DvMinLength = 0;
            this.cmbBusinessType.DvRegCode = null;
            this.cmbBusinessType.DvRequired = true;
            this.cmbBusinessType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbBusinessType.DvValidateEnabled = true;
            this.cmbBusinessType.DvValidator = this.validatorList1;
            this.cmbBusinessType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbBusinessType, "cmbBusinessType");
            this.cmbBusinessType.Name = "cmbBusinessType";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tbProtecol
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbProtecol, null);
            this.tbProtecol.DvDataField = null;
            this.tbProtecol.DvEditorValueChanged = false;
            this.tbProtecol.DvErrorProvider = this.errorProvider1;
            this.tbProtecol.DvFixLength = false;
            this.tbProtecol.DvLinkedLabel = this.label4;
            this.tbProtecol.DvMaxLength = 0;
            this.tbProtecol.DvMinLength = 0;
            this.tbProtecol.DvRegCode = null;
            this.tbProtecol.DvRequired = false;
            this.tbProtecol.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbProtecol.DvValidateEnabled = true;
            this.tbProtecol.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbProtecol, "tbProtecol");
            this.tbProtecol.Name = "tbProtecol";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbTip);
            this.panel1.Controls.Add(this.tbCustomerRef);
            this.panel1.Controls.Add(this.edtPayAmount);
            this.panel1.Controls.Add(this.lblPayeeAccount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbAmountDesc);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            // tbCustomerRef
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbCustomerRef, null);
            this.tbCustomerRef.DvDataField = null;
            this.tbCustomerRef.DvEditorValueChanged = false;
            this.tbCustomerRef.DvErrorProvider = this.errorProvider1;
            this.tbCustomerRef.DvFixLength = false;
            this.tbCustomerRef.DvLinkedLabel = this.lblPayeeAccount;
            this.tbCustomerRef.DvMaxLength = 0;
            this.tbCustomerRef.DvMinLength = 0;
            this.tbCustomerRef.DvRegCode = null;
            this.tbCustomerRef.DvRequired = false;
            this.tbCustomerRef.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCustomerRef.DvValidateEnabled = true;
            this.tbCustomerRef.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbCustomerRef, "tbCustomerRef");
            this.tbCustomerRef.Name = "tbCustomerRef";
            // 
            // lbAmountDesc
            // 
            resources.ApplyResources(this.lbAmountDesc, "lbAmountDesc");
            this.lbAmountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDesc.Name = "lbAmountDesc";
            // 
            // pDateTime
            // 
            this.pDateTime.Controls.Add(this.p_lockPayeFeeNo);
            this.pDateTime.Controls.Add(this.cmbFeeChargingAccountType);
            this.pDateTime.Controls.Add(this.lblPayeeBankName);
            resources.ApplyResources(this.pDateTime, "pDateTime");
            this.pDateTime.Name = "pDateTime";
            // 
            // p_lockPayeFeeNo
            // 
            this.p_lockPayeFeeNo.BackgroundImage = global::CommonClient.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockPayeFeeNo, "p_lockPayeFeeNo");
            this.p_lockPayeFeeNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockPayeFeeNo.Name = "p_lockPayeFeeNo";
            this.p_lockPayeFeeNo.Click += new System.EventHandler(this.p_lock_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.linkContent);
            this.panel3.Controls.Add(this.p_lockOperateOrder);
            this.panel3.Controls.Add(this.p_lockPayDate);
            this.panel3.Controls.Add(this.dtDesignedPaymentDate);
            this.panel3.Controls.Add(this.lblDateTime);
            this.panel3.Controls.Add(this.lblpurpose);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbAdditionalComment);
            this.panel3.Controls.Add(this.lblAddtion);
            this.panel3.Controls.Add(this.rbNormal);
            this.panel3.Controls.Add(this.tbEmail);
            this.panel3.Controls.Add(this.lblOperatorOrder);
            this.panel3.Controls.Add(this.rbExpress);
            this.panel3.Controls.Add(this.lblPayeeEmail);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // linkContent
            // 
            resources.ApplyResources(this.linkContent, "linkContent");
            this.linkContent.Name = "linkContent";
            this.linkContent.TabStop = true;
            this.linkContent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConent_LinkClicked);
            // 
            // p_lockOperateOrder
            // 
            this.p_lockOperateOrder.BackgroundImage = global::CommonClient.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockOperateOrder, "p_lockOperateOrder");
            this.p_lockOperateOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockOperateOrder.Name = "p_lockOperateOrder";
            this.p_lockOperateOrder.Click += new System.EventHandler(this.p_lock_Click);
            // 
            // p_lockPayDate
            // 
            this.p_lockPayDate.BackgroundImage = global::CommonClient.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockPayDate, "p_lockPayDate");
            this.p_lockPayDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockPayDate.Name = "p_lockPayDate";
            this.p_lockPayDate.Click += new System.EventHandler(this.p_lock_Click);
            // 
            // dtDesignedPaymentDate
            // 
            resources.ApplyResources(this.dtDesignedPaymentDate, "dtDesignedPaymentDate");
            this.dtDesignedPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDesignedPaymentDate.Name = "dtDesignedPaymentDate";
            // 
            // lblDateTime
            // 
            resources.ApplyResources(this.lblDateTime, "lblDateTime");
            this.lblDateTime.Name = "lblDateTime";
            // 
            // lblpurpose
            // 
            resources.ApplyResources(this.lblpurpose, "lblpurpose");
            this.lblpurpose.ForeColor = System.Drawing.Color.Red;
            this.lblpurpose.Name = "lblpurpose";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
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
            // TransferEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "TransferEditor";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pOverBankIn.ResumeLayout(false);
            this.pOverBankIn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.pDateTime.ResumeLayout(false);
            this.pDateTime.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxCanValidate edtPayAmount;
        private System.Windows.Forms.Label lblOperatorOrder;
        private System.Windows.Forms.Label lblAddtion;
        private System.Windows.Forms.Label lblPayeeBankName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label label1;
        private ComboBoxCanValidate cmbFeeChargingAccountType;
        private ComboBoxCanValidate cmbAdditionalComment;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbExpress;
        private System.Windows.Forms.Label lblPayeeEmail;
        private TextBoxCanValidate tbEmail;
        private System.Windows.Forms.Label label3;
        private TextBoxCanValidate textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pOverBankIn;
        private ComboBoxCanValidate cmbBusinessType;
        private TextBoxCanValidate tbProtecol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pDateTime;
        private System.Windows.Forms.Panel panel3;
        private TextBoxCanValidate tbCustomerRef;
        private System.Windows.Forms.DateTimePicker dtDesignedPaymentDate;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel p_lockPayDate;
        private System.Windows.Forms.Panel p_lockPayeFeeNo;
        private System.Windows.Forms.Panel p_lockOperateOrder;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.Label lbAmountDesc;
        private AmbiguityInputAgent ambiguityInputAgent1;
        private System.Windows.Forms.Label lblpurpose;
        private System.Windows.Forms.LinkLabel linkContent;
    }
}
