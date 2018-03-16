using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class UnitivePaymentRMBPayerSelector
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
            this.lbPayerAccount = new System.Windows.Forms.Label();
            this.tbPayerAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbPayerName = new System.Windows.Forms.Label();
            this.tbPayerName = new CommonClient.Controls.TextBoxCanValidate();
            this.lbBankLinkNo = new System.Windows.Forms.Label();
            this.tbBankLinkNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lbOpenBank = new System.Windows.Forms.Label();
            this.tbOpenBank = new CommonClient.Controls.TextBoxCanValidate();
            this.btnBankLinkNo = new CommonClient.Controls.ThemedButton();
            this.btnOpenBank = new CommonClient.Controls.ThemedButton();
            this.lblAccount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPayerAccount
            // 
            this.lbPayerAccount.AutoSize = true;
            this.lbPayerAccount.Location = new System.Drawing.Point(42, 7);
            this.lbPayerAccount.Name = "lbPayerAccount";
            this.lbPayerAccount.Size = new System.Drawing.Size(101, 12);
            this.lbPayerAccount.TabIndex = 0;
            this.lbPayerAccount.Text = "名义付款人账号：";
            // 
            // tbPayerAccount
            // 
            this.tbPayerAccount.DvDataField = null;
            this.tbPayerAccount.DvEditorValueChanged = true;
            this.tbPayerAccount.DvErrorProvider = this.errorProvider1;
            this.tbPayerAccount.DvLinkedLabel = this.lbPayerAccount;
            this.tbPayerAccount.DvMaxLength = 0;
            this.tbPayerAccount.DvMinLength = 0;
            this.tbPayerAccount.DvRegCode = null;
            this.tbPayerAccount.DvRequired = false;
            this.tbPayerAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayerAccount.DvValidateEnabled = true;
            this.tbPayerAccount.DvValidator = this.validatorList1;
            this.tbPayerAccount.Location = new System.Drawing.Point(143, 3);
            this.tbPayerAccount.Name = "tbPayerAccount";
            this.tbPayerAccount.Size = new System.Drawing.Size(200, 21);
            this.tbPayerAccount.TabIndex = 1;
            // 
            // lbPayerName
            // 
            this.lbPayerName.AutoSize = true;
            this.lbPayerName.Location = new System.Drawing.Point(42, 34);
            this.lbPayerName.Name = "lbPayerName";
            this.lbPayerName.Size = new System.Drawing.Size(101, 12);
            this.lbPayerName.TabIndex = 0;
            this.lbPayerName.Text = "名义付款人名称：";
            // 
            // tbPayerName
            // 
            this.tbPayerName.DvDataField = null;
            this.tbPayerName.DvEditorValueChanged = true;
            this.tbPayerName.DvErrorProvider = this.errorProvider1;
            this.tbPayerName.DvLinkedLabel = this.lbPayerName;
            this.tbPayerName.DvMaxLength = 0;
            this.tbPayerName.DvMinLength = 0;
            this.tbPayerName.DvRegCode = null;
            this.tbPayerName.DvRequired = false;
            this.tbPayerName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbPayerName.DvValidateEnabled = true;
            this.tbPayerName.DvValidator = this.validatorList1;
            this.tbPayerName.Location = new System.Drawing.Point(143, 30);
            this.tbPayerName.Name = "tbPayerName";
            this.tbPayerName.Size = new System.Drawing.Size(200, 21);
            this.tbPayerName.TabIndex = 1;
            // 
            // lbBankLinkNo
            // 
            this.lbBankLinkNo.AutoSize = true;
            this.lbBankLinkNo.Location = new System.Drawing.Point(30, 61);
            this.lbBankLinkNo.Name = "lbBankLinkNo";
            this.lbBankLinkNo.Size = new System.Drawing.Size(113, 12);
            this.lbBankLinkNo.TabIndex = 0;
            this.lbBankLinkNo.Text = "名义付款人联行号：";
            this.lbBankLinkNo.Visible = false;
            // 
            // tbBankLinkNo
            // 
            this.tbBankLinkNo.DvDataField = null;
            this.tbBankLinkNo.DvEditorValueChanged = true;
            this.tbBankLinkNo.DvErrorProvider = this.errorProvider1;
            this.tbBankLinkNo.DvLinkedLabel = this.lbBankLinkNo;
            this.tbBankLinkNo.DvMaxLength = 0;
            this.tbBankLinkNo.DvMinLength = 0;
            this.tbBankLinkNo.DvRegCode = null;
            this.tbBankLinkNo.DvRequired = false;
            this.tbBankLinkNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbBankLinkNo.DvValidateEnabled = true;
            this.tbBankLinkNo.DvValidator = this.validatorList1;
            this.tbBankLinkNo.Location = new System.Drawing.Point(143, 57);
            this.tbBankLinkNo.Name = "tbBankLinkNo";
            this.tbBankLinkNo.Size = new System.Drawing.Size(200, 21);
            this.tbBankLinkNo.TabIndex = 1;
            this.tbBankLinkNo.Visible = false;
            // 
            // lbOpenBank
            // 
            this.lbOpenBank.AutoSize = true;
            this.lbOpenBank.Location = new System.Drawing.Point(30, 88);
            this.lbOpenBank.Name = "lbOpenBank";
            this.lbOpenBank.Size = new System.Drawing.Size(113, 12);
            this.lbOpenBank.TabIndex = 0;
            this.lbOpenBank.Text = "名义付款人开户行：";
            this.lbOpenBank.Visible = false;
            // 
            // tbOpenBank
            // 
            this.tbOpenBank.DvDataField = null;
            this.tbOpenBank.DvEditorValueChanged = true;
            this.tbOpenBank.DvErrorProvider = this.errorProvider1;
            this.tbOpenBank.DvLinkedLabel = this.lbOpenBank;
            this.tbOpenBank.DvMaxLength = 0;
            this.tbOpenBank.DvMinLength = 0;
            this.tbOpenBank.DvRegCode = null;
            this.tbOpenBank.DvRequired = false;
            this.tbOpenBank.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOpenBank.DvValidateEnabled = true;
            this.tbOpenBank.DvValidator = this.validatorList1;
            this.tbOpenBank.Location = new System.Drawing.Point(143, 84);
            this.tbOpenBank.Name = "tbOpenBank";
            this.tbOpenBank.Size = new System.Drawing.Size(200, 21);
            this.tbOpenBank.TabIndex = 1;
            this.tbOpenBank.Visible = false;
            // 
            // btnBankLinkNo
            // 
            this.btnBankLinkNo.Image = null;
            this.btnBankLinkNo.Location = new System.Drawing.Point(343, 56);
            this.btnBankLinkNo.Name = "btnBankLinkNo";
            this.btnBankLinkNo.Size = new System.Drawing.Size(45, 23);
            this.btnBankLinkNo.TabIndex = 2;
            this.btnBankLinkNo.Text = "查询";
            this.btnBankLinkNo.UseVisualStyleBackColor = false;
            this.btnBankLinkNo.Visible = false;
            this.btnBankLinkNo.Click += new System.EventHandler(this.btnBankLinkNo_Click);
            // 
            // btnOpenBank
            // 
            this.btnOpenBank.Image = null;
            this.btnOpenBank.Location = new System.Drawing.Point(343, 83);
            this.btnOpenBank.Name = "btnOpenBank";
            this.btnOpenBank.Size = new System.Drawing.Size(45, 23);
            this.btnOpenBank.TabIndex = 2;
            this.btnOpenBank.Text = "查询";
            this.btnOpenBank.UseVisualStyleBackColor = false;
            this.btnOpenBank.Visible = false;
            this.btnOpenBank.Click += new System.EventHandler(this.btnOpenBank_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.ForeColor = System.Drawing.Color.Red;
            this.lblAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAccount.Location = new System.Drawing.Point(31, 7);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(11, 12);
            this.lblAccount.TabIndex = 18;
            this.lblAccount.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "*";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(19, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "*";
            this.label3.Visible = false;
            // 
            // UnitivePaymentRMBPayerSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.btnOpenBank);
            this.Controls.Add(this.btnBankLinkNo);
            this.Controls.Add(this.tbOpenBank);
            this.Controls.Add(this.lbOpenBank);
            this.Controls.Add(this.tbBankLinkNo);
            this.Controls.Add(this.lbBankLinkNo);
            this.Controls.Add(this.tbPayerName);
            this.Controls.Add(this.lbPayerName);
            this.Controls.Add(this.tbPayerAccount);
            this.Controls.Add(this.lbPayerAccount);
            this.Name = "UnitivePaymentRMBPayerSelector";
            this.Size = new System.Drawing.Size(390, 111);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPayerAccount;
        private Controls.TextBoxCanValidate tbPayerAccount;
        private System.Windows.Forms.Label lbPayerName;
        private Controls.TextBoxCanValidate tbPayerName;
        private System.Windows.Forms.Label lbBankLinkNo;
        private Controls.TextBoxCanValidate tbBankLinkNo;
        private System.Windows.Forms.Label lbOpenBank;
        private Controls.TextBoxCanValidate tbOpenBank;
        private ThemedButton btnBankLinkNo;
        private ThemedButton btnOpenBank;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
