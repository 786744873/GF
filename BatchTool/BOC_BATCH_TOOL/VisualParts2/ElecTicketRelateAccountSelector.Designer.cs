namespace BOC_BATCH_TOOL.VisualParts
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
            this.tbName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblName = new System.Windows.Forms.Label();
            this.lbOpenBankName = new System.Windows.Forms.Label();
            this.tbOpenBankName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblOpenBankName = new System.Windows.Forms.Label();
            this.lbOpenBankNo = new System.Windows.Forms.Label();
            this.tbOpenBankNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblOpenBankNo = new System.Windows.Forms.Label();
            this.btnQueryAccount = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.btnOpenBank = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.cmbAccount = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.pbTip = new System.Windows.Forms.PictureBox();
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
            this.tbName.EditorValueChanged = false;
            this.tbName.ErrorProvider = null;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.ValidateEnabled = true;
            this.tbName.ValidateRule.MaxLength = 0;
            this.tbName.ValidateRule.MinLength = 0;
            this.tbName.ValidateRule.RegexValue = null;
            this.tbName.ValidateRule.Required = false;
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
            this.tbOpenBankName.EditorValueChanged = false;
            this.tbOpenBankName.ErrorProvider = null;
            resources.ApplyResources(this.tbOpenBankName, "tbOpenBankName");
            this.tbOpenBankName.Name = "tbOpenBankName";
            this.tbOpenBankName.ValidateEnabled = true;
            this.tbOpenBankName.ValidateRule.MaxLength = 0;
            this.tbOpenBankName.ValidateRule.MinLength = 0;
            this.tbOpenBankName.ValidateRule.RegexValue = null;
            this.tbOpenBankName.ValidateRule.Required = false;
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
            this.tbOpenBankNo.EditorValueChanged = false;
            this.tbOpenBankNo.ErrorProvider = null;
            resources.ApplyResources(this.tbOpenBankNo, "tbOpenBankNo");
            this.tbOpenBankNo.Name = "tbOpenBankNo";
            this.tbOpenBankNo.ValidateEnabled = true;
            this.tbOpenBankNo.ValidateRule.MaxLength = 0;
            this.tbOpenBankNo.ValidateRule.MinLength = 0;
            this.tbOpenBankNo.ValidateRule.RegexValue = null;
            this.tbOpenBankNo.ValidateRule.Required = false;
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
            this.cmbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccount.EditorValueChanged = false;
            this.cmbAccount.ErrorProvider = null;
            resources.ApplyResources(this.cmbAccount, "cmbAccount");
            this.cmbAccount.MatchStrFlag = true;
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.ValidateEnabled = true;
            this.cmbAccount.ValidateRule.MaxLength = 0;
            this.cmbAccount.ValidateRule.MinLength = 0;
            this.cmbAccount.ValidateRule.RegexValue = null;
            this.cmbAccount.ValidateRule.Required = false;
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
            this.pbTip.Image = global::BOC_BATCH_TOOL.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.Click += new System.EventHandler(this.pbTip_Click);
            // 
            // ElecTicketRelateAccountSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pbTip);
            this.Controls.Add(this.chbSave);
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
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lbOpenBankName;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbOpenBankName;
        private System.Windows.Forms.Label lblOpenBankName;
        private System.Windows.Forms.Label lbOpenBankNo;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbOpenBankNo;
        private System.Windows.Forms.Label lblOpenBankNo;
        private Controls.ThemedButton btnQueryAccount;
        private Controls.ThemedButton btnOpenBank;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbAccount;
        private System.Windows.Forms.CheckBox chbSave;
        private System.Windows.Forms.PictureBox pbTip;
    }
}
