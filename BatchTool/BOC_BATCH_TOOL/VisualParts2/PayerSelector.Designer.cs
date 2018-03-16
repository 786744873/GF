using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualElements
{
    partial class PayerSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayerSelector));
            this.lbPayerAccount = new System.Windows.Forms.Label();
            this.cbAccount = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.lbPayerName = new System.Windows.Forms.Label();
            this.tbName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblPayerName = new System.Windows.Forms.Label();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.p_lockPayerAccount = new System.Windows.Forms.Panel();
            this.p_lockPayerName = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPayerAccount
            // 
            resources.ApplyResources(this.lbPayerAccount, "lbPayerAccount");
            this.lbPayerAccount.Name = "lbPayerAccount";
            // 
            // cbAccount
            // 
            this.cbAccount.BackColor = System.Drawing.SystemColors.Window;
            this.cbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAccount.EditorValueChanged = false;
            this.cbAccount.ErrorProvider = null;
            this.cbAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cbAccount, "cbAccount");
            this.cbAccount.MatchStrFlag = true;
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.ValidateEnabled = true;
            this.cbAccount.ValidateRule.MaxLength = 0;
            this.cbAccount.ValidateRule.MinLength = 0;
            this.cbAccount.ValidateRule.RegexValue = null;
            this.cbAccount.ValidateRule.Required = true;
            this.cbAccount.SelectedIndexChanged += new System.EventHandler(this.cbAccount_SelectedIndexChanged);
            // 
            // chbSave
            // 
            resources.ApplyResources(this.chbSave, "chbSave");
            this.chbSave.Checked = true;
            this.chbSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSave.Name = "chbSave";
            this.chbSave.UseVisualStyleBackColor = true;
            this.chbSave.CheckedChanged += new System.EventHandler(this.chbSave_CheckedChanged);
            // 
            // lbPayerName
            // 
            resources.ApplyResources(this.lbPayerName, "lbPayerName");
            this.lbPayerName.Name = "lbPayerName";
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
            // lblAccount
            // 
            resources.ApplyResources(this.lblAccount, "lblAccount");
            this.lblAccount.ForeColor = System.Drawing.Color.Red;
            this.lblAccount.Name = "lblAccount";
            // 
            // lblPayerName
            // 
            resources.ApplyResources(this.lblPayerName, "lblPayerName");
            this.lblPayerName.ForeColor = System.Drawing.Color.Red;
            this.lblPayerName.Name = "lblPayerName";
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::BOC_BATCH_TOOL.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.MouseHover += new System.EventHandler(this.pbTip_MouseHover);
            // 
            // p_lockPayerAccount
            // 
            this.p_lockPayerAccount.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockPayerAccount, "p_lockPayerAccount");
            this.p_lockPayerAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockPayerAccount.Name = "p_lockPayerAccount";
            this.p_lockPayerAccount.Click += new System.EventHandler(this.p_lockPayer_Click);
            // 
            // p_lockPayerName
            // 
            this.p_lockPayerName.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockPayerName, "p_lockPayerName");
            this.p_lockPayerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockPayerName.Name = "p_lockPayerName";
            this.p_lockPayerName.Click += new System.EventHandler(this.p_lockPayer_Click);
            // 
            // PayerSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.p_lockPayerName);
            this.Controls.Add(this.p_lockPayerAccount);
            this.Controls.Add(this.pbTip);
            this.Controls.Add(this.lblPayerName);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.chbSave);
            this.Controls.Add(this.cbAccount);
            this.Controls.Add(this.lbPayerName);
            this.Controls.Add(this.lbPayerAccount);
            resources.ApplyResources(this, "$this");
            this.Name = "PayerSelector";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPayerAccount;
        private ComboBoxCanValidate cbAccount;
        private System.Windows.Forms.CheckBox chbSave;
        private System.Windows.Forms.Label lbPayerName;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbName;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblPayerName;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.Panel p_lockPayerAccount;
        private System.Windows.Forms.Panel p_lockPayerName;
    }
}
