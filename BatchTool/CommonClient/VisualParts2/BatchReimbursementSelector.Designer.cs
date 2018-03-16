namespace CommonClient.VisualParts
{
    partial class BatchReimbursementSelector
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
            this.lbCardNo = new System.Windows.Forms.Label();
            this.tbCardNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayAmount = new System.Windows.Forms.Label();
            this.tbPayAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbUsage = new System.Windows.Forms.Label();
            this.cmbUsage = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbPayPassword = new System.Windows.Forms.Label();
            this.tbPayPassword = new CommonClient.Controls.TextBoxCanValidate();
            this.lbReimburseAmount = new System.Windows.Forms.Label();
            this.tbReimburseAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayDate = new System.Windows.Forms.Label();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.lbAmountDescR = new System.Windows.Forms.Label();
            this.lbAmountDescP = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkContent = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCardNo
            // 
            this.lbCardNo.AutoSize = true;
            this.lbCardNo.Location = new System.Drawing.Point(67, 23);
            this.lbCardNo.Name = "lbCardNo";
            this.lbCardNo.Size = new System.Drawing.Size(43, 13);
            this.lbCardNo.TabIndex = 0;
            this.lbCardNo.Text = "卡号：";
            // 
            // tbCardNo
            // 
            this.tbCardNo.DvDataField = null;
            this.tbCardNo.DvEditorValueChanged = true;
            this.tbCardNo.DvErrorProvider = this.errorProvider1;
            this.tbCardNo.DvFixLength = false;
            this.tbCardNo.DvLinkedLabel = this.lbCardNo;
            this.tbCardNo.DvMaxLength = 0;
            this.tbCardNo.DvMinLength = 0;
            this.tbCardNo.DvRegCode = null;
            this.tbCardNo.DvRequired = true;
            this.tbCardNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbCardNo.DvValidateEnabled = true;
            this.tbCardNo.DvValidator = this.validatorList1;
            this.tbCardNo.Location = new System.Drawing.Point(110, 19);
            this.tbCardNo.Name = "tbCardNo";
            this.tbCardNo.Size = new System.Drawing.Size(200, 20);
            this.tbCardNo.TabIndex = 1;
            // 
            // lbPayAmount
            // 
            this.lbPayAmount.AutoSize = true;
            this.lbPayAmount.Location = new System.Drawing.Point(43, 49);
            this.lbPayAmount.Name = "lbPayAmount";
            this.lbPayAmount.Size = new System.Drawing.Size(67, 13);
            this.lbPayAmount.TabIndex = 0;
            this.lbPayAmount.Text = "消费金额：";
            // 
            // tbPayAmount
            // 
            this.tbPayAmount.DvDataField = null;
            this.tbPayAmount.DvEditorValueChanged = true;
            this.tbPayAmount.DvErrorProvider = this.errorProvider1;
            this.tbPayAmount.DvFixLength = false;
            this.tbPayAmount.DvLinkedLabel = this.lbPayAmount;
            this.tbPayAmount.DvMaxLength = 0;
            this.tbPayAmount.DvMinLength = 0;
            this.tbPayAmount.DvRegCode = null;
            this.tbPayAmount.DvRequired = true;
            this.tbPayAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayAmount.DvValidateEnabled = true;
            this.tbPayAmount.DvValidator = null;
            this.tbPayAmount.Location = new System.Drawing.Point(110, 45);
            this.tbPayAmount.Name = "tbPayAmount";
            this.tbPayAmount.Size = new System.Drawing.Size(200, 20);
            this.tbPayAmount.TabIndex = 1;
            // 
            // lbUsage
            // 
            this.lbUsage.AutoSize = true;
            this.lbUsage.Location = new System.Drawing.Point(67, 204);
            this.lbUsage.Name = "lbUsage";
            this.lbUsage.Size = new System.Drawing.Size(43, 13);
            this.lbUsage.TabIndex = 0;
            this.lbUsage.Text = "用途：";
            // 
            // cmbUsage
            // 
            this.cmbUsage.DvDataField = null;
            this.cmbUsage.DvEditorValueChanged = true;
            this.cmbUsage.DvErrorProvider = this.errorProvider1;
            this.cmbUsage.DvFixLength = false;
            this.cmbUsage.DvLinkedLabel = this.lbUsage;
            this.cmbUsage.DvMaxLength = 0;
            this.cmbUsage.DvMinLength = 0;
            this.cmbUsage.DvRegCode = null;
            this.cmbUsage.DvRequired = false;
            this.cmbUsage.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbUsage.DvValidateEnabled = true;
            this.cmbUsage.DvValidator = this.validatorList1;
            this.cmbUsage.Location = new System.Drawing.Point(110, 200);
            this.cmbUsage.Name = "cmbUsage";
            this.cmbUsage.Size = new System.Drawing.Size(200, 21);
            this.cmbUsage.TabIndex = 1;
            // 
            // lbPayPassword
            // 
            this.lbPayPassword.AutoSize = true;
            this.lbPayPassword.Location = new System.Drawing.Point(55, 126);
            this.lbPayPassword.Name = "lbPayPassword";
            this.lbPayPassword.Size = new System.Drawing.Size(55, 13);
            this.lbPayPassword.TabIndex = 0;
            this.lbPayPassword.Text = "支付令：";
            // 
            // tbPayPassword
            // 
            this.tbPayPassword.DvDataField = null;
            this.tbPayPassword.DvEditorValueChanged = true;
            this.tbPayPassword.DvErrorProvider = this.errorProvider1;
            this.tbPayPassword.DvFixLength = false;
            this.tbPayPassword.DvLinkedLabel = this.lbPayPassword;
            this.tbPayPassword.DvMaxLength = 0;
            this.tbPayPassword.DvMinLength = 0;
            this.tbPayPassword.DvRegCode = null;
            this.tbPayPassword.DvRequired = false;
            this.tbPayPassword.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayPassword.DvValidateEnabled = true;
            this.tbPayPassword.DvValidator = this.validatorList1;
            this.tbPayPassword.Location = new System.Drawing.Point(110, 122);
            this.tbPayPassword.Name = "tbPayPassword";
            this.tbPayPassword.Size = new System.Drawing.Size(200, 20);
            this.tbPayPassword.TabIndex = 1;
            // 
            // lbReimburseAmount
            // 
            this.lbReimburseAmount.AutoSize = true;
            this.lbReimburseAmount.Location = new System.Drawing.Point(43, 152);
            this.lbReimburseAmount.Name = "lbReimburseAmount";
            this.lbReimburseAmount.Size = new System.Drawing.Size(67, 13);
            this.lbReimburseAmount.TabIndex = 0;
            this.lbReimburseAmount.Text = "报销金额：";
            // 
            // tbReimburseAmount
            // 
            this.tbReimburseAmount.DvDataField = null;
            this.tbReimburseAmount.DvEditorValueChanged = true;
            this.tbReimburseAmount.DvErrorProvider = this.errorProvider1;
            this.tbReimburseAmount.DvFixLength = false;
            this.tbReimburseAmount.DvLinkedLabel = this.lbReimburseAmount;
            this.tbReimburseAmount.DvMaxLength = 0;
            this.tbReimburseAmount.DvMinLength = 0;
            this.tbReimburseAmount.DvRegCode = null;
            this.tbReimburseAmount.DvRequired = true;
            this.tbReimburseAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbReimburseAmount.DvValidateEnabled = true;
            this.tbReimburseAmount.DvValidator = this.validatorList1;
            this.tbReimburseAmount.Location = new System.Drawing.Point(110, 148);
            this.tbReimburseAmount.Name = "tbReimburseAmount";
            this.tbReimburseAmount.Size = new System.Drawing.Size(200, 20);
            this.tbReimburseAmount.TabIndex = 1;
            // 
            // lbPayDate
            // 
            this.lbPayDate.AutoSize = true;
            this.lbPayDate.Location = new System.Drawing.Point(43, 100);
            this.lbPayDate.Name = "lbPayDate";
            this.lbPayDate.Size = new System.Drawing.Size(67, 13);
            this.lbPayDate.TabIndex = 0;
            this.lbPayDate.Text = "消费日期：";
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpPayDate.CustomFormat = "yyyy/MM/dd";
            this.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayDate.Location = new System.Drawing.Point(110, 96);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(200, 20);
            this.dtpPayDate.TabIndex = 2;
            // 
            // lbAmountDescR
            // 
            this.lbAmountDescR.AutoSize = true;
            this.lbAmountDescR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAmountDescR.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAmountDescR.Location = new System.Drawing.Point(43, 178);
            this.lbAmountDescR.Name = "lbAmountDescR";
            this.lbAmountDescR.Size = new System.Drawing.Size(0, 13);
            this.lbAmountDescR.TabIndex = 38;
            // 
            // lbAmountDescP
            // 
            this.lbAmountDescP.AutoSize = true;
            this.lbAmountDescP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAmountDescP.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDescP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAmountDescP.Location = new System.Drawing.Point(43, 75);
            this.lbAmountDescP.Name = "lbAmountDescP";
            this.lbAmountDescP.Size = new System.Drawing.Size(0, 13);
            this.lbAmountDescP.TabIndex = 39;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAccount.ForeColor = System.Drawing.Color.Red;
            this.lblAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAccount.Location = new System.Drawing.Point(49, 22);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(12, 15);
            this.lblAccount.TabIndex = 40;
            this.lblAccount.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 40;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(31, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 40;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(37, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(25, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(49, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "*";
            // 
            // linkContent
            // 
            this.linkContent.AutoSize = true;
            this.linkContent.Location = new System.Drawing.Point(317, 204);
            this.linkContent.Name = "linkContent";
            this.linkContent.Size = new System.Drawing.Size(31, 13);
            this.linkContent.TabIndex = 41;
            this.linkContent.TabStop = true;
            this.linkContent.Text = "设置";
            this.linkContent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConent_LinkClicked);
            // 
            // BatchReimbursementSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lbAmountDescP);
            this.Controls.Add(this.lbAmountDescR);
            this.Controls.Add(this.dtpPayDate);
            this.Controls.Add(this.tbReimburseAmount);
            this.Controls.Add(this.lbPayDate);
            this.Controls.Add(this.lbReimburseAmount);
            this.Controls.Add(this.tbPayPassword);
            this.Controls.Add(this.lbPayPassword);
            this.Controls.Add(this.cmbUsage);
            this.Controls.Add(this.lbUsage);
            this.Controls.Add(this.tbPayAmount);
            this.Controls.Add(this.lbPayAmount);
            this.Controls.Add(this.tbCardNo);
            this.Controls.Add(this.lbCardNo);
            this.Name = "BatchReimbursementSelector";
            this.Size = new System.Drawing.Size(424, 387);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCardNo;
        private Controls.TextBoxCanValidate tbCardNo;
        private System.Windows.Forms.Label lbPayAmount;
        private Controls.TextBoxCanValidate tbPayAmount;
        private System.Windows.Forms.Label lbUsage;
        private Controls.ComboBoxCanValidate cmbUsage;
        private System.Windows.Forms.Label lbPayPassword;
        private Controls.TextBoxCanValidate tbPayPassword;
        private System.Windows.Forms.Label lbReimburseAmount;
        private Controls.TextBoxCanValidate tbReimburseAmount;
        private System.Windows.Forms.Label lbPayDate;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.Label lbAmountDescR;
        private System.Windows.Forms.Label lbAmountDescP;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkContent;
    }
}
