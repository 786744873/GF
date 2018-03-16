using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class InitiativeAllotAccountEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitiativeAllotAccountEditor));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonReset = new CommonClient.Controls.ThemedButton();
            this.btnEdit = new CommonClient.Controls.ThemedButton();
            this.buttonSubmit = new CommonClient.Controls.ThemedButton();
            this.tbRowIndex = new CommonClient.Controls.TextBoxCanValidate();
            this.label5 = new System.Windows.Forms.Label();
            this.edtName = new CommonClient.Controls.TextBoxCanValidate();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtAccount = new CommonClient.Controls.TextBoxCanValidate();
            this.lblAccount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
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
            // tbRowIndex
            // 
            this.tbRowIndex.BackColor = System.Drawing.SystemColors.Control;
            this.tbRowIndex.DvDataField = null;
            this.tbRowIndex.DvEditorValueChanged = false;
            this.tbRowIndex.DvErrorProvider = this.errorProvider1;
            this.tbRowIndex.DvLinkedLabel = this.label5;
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // edtName
            // 
            this.edtName.BackColor = System.Drawing.SystemColors.Window;
            this.edtName.DvDataField = null;
            this.edtName.DvEditorValueChanged = false;
            this.edtName.DvErrorProvider = this.errorProvider1;
            this.edtName.DvLinkedLabel = this.lblName;
            this.edtName.DvMaxLength = 0;
            this.edtName.DvMinLength = 0;
            this.edtName.DvRegCode = null;
            this.edtName.DvRequired = false;
            this.edtName.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtName.DvValidateEnabled = true;
            this.edtName.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtName, "edtName");
            this.edtName.Name = "edtName";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // edtAccount
            // 
            this.edtAccount.BackColor = System.Drawing.SystemColors.Window;
            this.edtAccount.DvDataField = null;
            this.edtAccount.DvEditorValueChanged = false;
            this.edtAccount.DvErrorProvider = this.errorProvider1;
            this.edtAccount.DvLinkedLabel = this.lblAccount;
            this.edtAccount.DvMaxLength = 0;
            this.edtAccount.DvMinLength = 0;
            this.edtAccount.DvRegCode = null;
            this.edtAccount.DvRequired = false;
            this.edtAccount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtAccount.DvValidateEnabled = true;
            this.edtAccount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.edtAccount, "edtAccount");
            this.edtAccount.Name = "edtAccount";
            // 
            // lblAccount
            // 
            resources.ApplyResources(this.lblAccount, "lblAccount");
            this.lblAccount.Name = "lblAccount";
            // 
            // InitiativeAllotAccountEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.edtAccount);
            this.Controls.Add(this.tbRowIndex);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.label5);
            this.Name = "InitiativeAllotAccountEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private ThemedButton buttonReset;
        private ThemedButton btnEdit;
        private ThemedButton buttonSubmit;
        private Controls.TextBoxCanValidate tbRowIndex;
        private System.Windows.Forms.Label label5;
        private Controls.TextBoxCanValidate edtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private Controls.TextBoxCanValidate edtAccount;
        private System.Windows.Forms.Label lblAccount;
    }
}
