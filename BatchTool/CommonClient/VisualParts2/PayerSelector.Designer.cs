using CommonClient.Controls;

namespace CommonClient.VisualParts2
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
            this.cbAccount = new CommonClient.Controls.ComboBoxCanValidate();
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.lbPayerName = new System.Windows.Forms.Label();
            this.tbName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblPayerName = new System.Windows.Forms.Label();
            this.pbTip = new System.Windows.Forms.PictureBox();
            this.p_lockPayerAccount = new System.Windows.Forms.Panel();
            this.p_lockPayerName = new System.Windows.Forms.Panel();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
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
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cbAccount, this.ambiguityInputAgent1);
            this.cbAccount.BackColor = System.Drawing.SystemColors.Window;
            this.cbAccount.DvDataField = null;
            this.cbAccount.DvEditorValueChanged = false;
            this.cbAccount.DvErrorProvider = this.errorProvider1;
            this.cbAccount.DvLinkedLabel = this.lbPayerAccount;
            this.cbAccount.DvMaxLength = 0;
            this.cbAccount.DvMinLength = 0;
            this.cbAccount.DvRegCode = "reg10";
            this.cbAccount.DvRequired = true;
            this.cbAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cbAccount.DvValidateEnabled = true;
            this.cbAccount.DvValidator = this.validatorList1;
            this.cbAccount.FormattingEnabled = true;
            resources.ApplyResources(this.cbAccount, "cbAccount");
            this.cbAccount.Name = "cbAccount";
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
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbName, null);
            this.tbName.DvDataField = null;
            this.tbName.DvEditorValueChanged = false;
            this.tbName.DvErrorProvider = this.errorProvider1;
            this.tbName.DvLinkedLabel = this.lbPayerName;
            this.tbName.DvMaxLength = 0;
            this.tbName.DvMinLength = 0;
            this.tbName.DvRegCode = "Predefined";
            this.tbName.DvRequired = false;
            this.tbName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbName.DvValidateEnabled = true;
            this.tbName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
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
            this.pbTip.Image = global::CommonClient.Properties.Resources.tips;
            resources.ApplyResources(this.pbTip, "pbTip");
            this.pbTip.Name = "pbTip";
            this.pbTip.TabStop = false;
            this.pbTip.MouseHover += new System.EventHandler(this.pbTip_MouseHover);
            // 
            // p_lockPayerAccount
            // 
            this.p_lockPayerAccount.BackgroundImage = global::CommonClient.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockPayerAccount, "p_lockPayerAccount");
            this.p_lockPayerAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockPayerAccount.Name = "p_lockPayerAccount";
            this.p_lockPayerAccount.Click += new System.EventHandler(this.p_lockPayer_Click);
            // 
            // p_lockPayerName
            // 
            this.p_lockPayerName.BackgroundImage = global::CommonClient.Properties.Resources.unlocked;
            resources.ApplyResources(this.p_lockPayerName, "p_lockPayerName");
            this.p_lockPayerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_lockPayerName.Name = "p_lockPayerName";
            this.p_lockPayerName.Click += new System.EventHandler(this.p_lockPayer_Click);
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
        private TextBoxCanValidate tbName;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblPayerName;
        private System.Windows.Forms.PictureBox pbTip;
        private System.Windows.Forms.Panel p_lockPayerAccount;
        private System.Windows.Forms.Panel p_lockPayerName;
        private AmbiguityInputAgent ambiguityInputAgent1;
    }
}
