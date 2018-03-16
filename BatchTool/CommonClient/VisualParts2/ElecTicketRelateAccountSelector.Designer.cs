using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class ElecTicketRelateAccountSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketRelateAccountSelector));
            this.lbAccount = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblName = new System.Windows.Forms.Label();
            this.lbOpenBankName = new System.Windows.Forms.Label();
            this.tbOpenBankName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblOpenBankName = new System.Windows.Forms.Label();
            this.lbOpenBankNo = new System.Windows.Forms.Label();
            this.tbOpenBankNo = new CommonClient.Controls.TextBoxCanValidate();
            this.lblOpenBankNo = new System.Windows.Forms.Label();
            this.btnQueryAccount = new CommonClient.Controls.ThemedButton();
            this.btnOpenBank = new CommonClient.Controls.ThemedButton();
            this.cmbAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAccount
            // 
            resources.ApplyResources(this.lbAccount, "lbAccount");
            this.lbAccount.Name = "lbAccount";
            // 
            // lblAccount
            // 
            resources.ApplyResources(this.lblAccount, "lblAccount");
            this.lblAccount.ForeColor = System.Drawing.Color.Red;
            this.lblAccount.Name = "lblAccount";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // tbName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbName, null);
            this.tbName.DvDataField = null;
            this.tbName.DvEditorValueChanged = false;
            this.tbName.DvErrorProvider = this.errorProvider1;
            this.tbName.DvLinkedLabel = this.lbName;
            this.tbName.DvMaxLength = 0;
            this.tbName.DvMinLength = 0;
            this.tbName.DvRegCode = "";
            this.tbName.DvRequired = false;
            this.tbName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbName.DvValidateEnabled = true;
            this.tbName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Name = "lblName";
            // 
            // lbOpenBankName
            // 
            resources.ApplyResources(this.lbOpenBankName, "lbOpenBankName");
            this.lbOpenBankName.Name = "lbOpenBankName";
            // 
            // tbOpenBankName
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbOpenBankName, null);
            this.tbOpenBankName.DvDataField = null;
            this.tbOpenBankName.DvEditorValueChanged = false;
            this.tbOpenBankName.DvErrorProvider = this.errorProvider1;
            this.tbOpenBankName.DvLinkedLabel = this.lbOpenBankName;
            this.tbOpenBankName.DvMaxLength = 0;
            this.tbOpenBankName.DvMinLength = 0;
            this.tbOpenBankName.DvRegCode = "";
            this.tbOpenBankName.DvRequired = false;
            this.tbOpenBankName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOpenBankName.DvValidateEnabled = true;
            this.tbOpenBankName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOpenBankName, "tbOpenBankName");
            this.tbOpenBankName.Name = "tbOpenBankName";
            // 
            // lblOpenBankName
            // 
            resources.ApplyResources(this.lblOpenBankName, "lblOpenBankName");
            this.lblOpenBankName.ForeColor = System.Drawing.Color.Red;
            this.lblOpenBankName.Name = "lblOpenBankName";
            // 
            // lbOpenBankNo
            // 
            resources.ApplyResources(this.lbOpenBankNo, "lbOpenBankNo");
            this.lbOpenBankNo.Name = "lbOpenBankNo";
            // 
            // tbOpenBankNo
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbOpenBankNo, null);
            this.tbOpenBankNo.DvDataField = null;
            this.tbOpenBankNo.DvEditorValueChanged = false;
            this.tbOpenBankNo.DvErrorProvider = this.errorProvider1;
            this.tbOpenBankNo.DvLinkedLabel = this.lbOpenBankNo;
            this.tbOpenBankNo.DvMaxLength = 0;
            this.tbOpenBankNo.DvMinLength = 0;
            this.tbOpenBankNo.DvRegCode = "";
            this.tbOpenBankNo.DvRequired = false;
            this.tbOpenBankNo.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbOpenBankNo.DvValidateEnabled = true;
            this.tbOpenBankNo.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbOpenBankNo, "tbOpenBankNo");
            this.tbOpenBankNo.Name = "tbOpenBankNo";
            // 
            // lblOpenBankNo
            // 
            resources.ApplyResources(this.lblOpenBankNo, "lblOpenBankNo");
            this.lblOpenBankNo.ForeColor = System.Drawing.Color.Red;
            this.lblOpenBankNo.Name = "lblOpenBankNo";
            // 
            // btnQueryAccount
            // 
            resources.ApplyResources(this.btnQueryAccount, "btnQueryAccount");
            this.btnQueryAccount.Name = "btnQueryAccount";
            this.btnQueryAccount.UseVisualStyleBackColor = true;
            this.btnQueryAccount.Click += new System.EventHandler(this.btnQueryAccount_Click);
            // 
            // btnOpenBank
            // 
            resources.ApplyResources(this.btnOpenBank, "btnOpenBank");
            this.btnOpenBank.Name = "btnOpenBank";
            this.btnOpenBank.UseVisualStyleBackColor = true;
            this.btnOpenBank.Click += new System.EventHandler(this.btnOpenBank_Click);
            // 
            // cmbAccount
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbAccount, this.ambiguityInputAgent1);
            this.cmbAccount.DvDataField = null;
            this.cmbAccount.DvEditorValueChanged = false;
            this.cmbAccount.DvErrorProvider = this.errorProvider1;
            this.cmbAccount.DvLinkedLabel = this.lbAccount;
            this.cmbAccount.DvMaxLength = 0;
            this.cmbAccount.DvMinLength = 0;
            this.cmbAccount.DvRegCode = "";
            this.cmbAccount.DvRequired = true;
            this.cmbAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbAccount.DvValidateEnabled = true;
            this.cmbAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.cmbAccount, "cmbAccount");
            this.cmbAccount.Name = "cmbAccount";
            // 
            // chbSave
            // 
            resources.ApplyResources(this.chbSave, "chbSave");
            this.chbSave.Checked = true;
            this.chbSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSave.Name = "chbSave";
            this.chbSave.UseVisualStyleBackColor = true;
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::CommonClient.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.Click += new System.EventHandler(this.pbTip_Click);
            // 
            // ambiguityInputAgent1
            // 
            this.ambiguityInputAgent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent1.ImageList = null;
            this.ambiguityInputAgent1.Items = new string[0];
            this.ambiguityInputAgent1.MaximumSize = new System.Drawing.Size(200, 180);
            this.ambiguityInputAgent1.MinFragmentLength = 2;
            this.ambiguityInputAgent1.TargetControlPacker = null;
            // 
            // ElecTicketRelateAccountSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pbTip);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.btnOpenBank);
            this.Controls.Add(this.btnQueryAccount);
            this.Controls.Add(this.lblOpenBankNo);
            this.Controls.Add(this.lblOpenBankName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.tbOpenBankNo);
            this.Controls.Add(this.lbOpenBankNo);
            this.Controls.Add(this.tbOpenBankName);
            this.Controls.Add(this.lbOpenBankName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbAccount);
            this.Controls.Add(this.chbSave);
            this.Name = "ElecTicketRelateAccountSelector";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lbName;
        private TextBoxCanValidate tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lbOpenBankName;
        private TextBoxCanValidate tbOpenBankName;
        private System.Windows.Forms.Label lblOpenBankName;
        private System.Windows.Forms.Label lbOpenBankNo;
        private TextBoxCanValidate tbOpenBankNo;
        private System.Windows.Forms.Label lblOpenBankNo;
        private ThemedButton btnQueryAccount;
        private ThemedButton btnOpenBank;
        private ComboBoxCanValidate cmbAccount;
        private System.Windows.Forms.CheckBox chbSave;
        private System.Windows.Forms.PictureBox pbTip;
        private AmbiguityInputAgent ambiguityInputAgent1;
    }
}
