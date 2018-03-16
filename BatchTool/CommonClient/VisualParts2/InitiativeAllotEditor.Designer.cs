using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class InitiativeAllotEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitiativeAllotEditor));
            this.lbAccountOut = new System.Windows.Forms.Label();
            this.tbNameOut = new CommonClient.Controls.TextBoxCanValidate();
            this.lbNameOut = new System.Windows.Forms.Label();
            this.cmbAccountOut = new CommonClient.Controls.ComboBoxCanValidate();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAccountIn = new System.Windows.Forms.Label();
            this.lbNameIn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNameIn = new CommonClient.Controls.TextBoxCanValidate();
            this.cmbAccountIn = new CommonClient.Controls.ComboBoxCanValidate();
            this.lbAmount = new System.Windows.Forms.Label();
            this.tbAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAddition = new System.Windows.Forms.Label();
            this.tbAddition = new CommonClient.Controls.TextBoxCanValidate();
            this.label9 = new System.Windows.Forms.Label();
            this.chbOut = new System.Windows.Forms.CheckBox();
            this.chbIn = new System.Windows.Forms.CheckBox();
            this.cmbCashType = new CommonClient.Controls.ComboBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAmountDesc = new System.Windows.Forms.Label();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent2 = new CommonClient.Controls.AmbiguityInputAgent();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAccountOut
            // 
            resources.ApplyResources(this.lbAccountOut, "lbAccountOut");
            this.lbAccountOut.Name = "lbAccountOut";
            // 
            // tbNameOut
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbNameOut, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbNameOut, null);
            this.tbNameOut.DvDataField = null;
            this.tbNameOut.DvEditorValueChanged = false;
            this.tbNameOut.DvErrorProvider = this.errorProvider1;
            this.tbNameOut.DvLinkedLabel = this.lbNameOut;
            this.tbNameOut.DvMaxLength = 0;
            this.tbNameOut.DvMinLength = 0;
            this.tbNameOut.DvRegCode = null;
            this.tbNameOut.DvRequired = false;
            this.tbNameOut.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbNameOut.DvValidateEnabled = true;
            this.tbNameOut.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbNameOut, "tbNameOut");
            this.tbNameOut.Name = "tbNameOut";
            // 
            // lbNameOut
            // 
            resources.ApplyResources(this.lbNameOut, "lbNameOut");
            this.lbNameOut.Name = "lbNameOut";
            // 
            // cmbAccountOut
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbAccountOut, this.ambiguityInputAgent1);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbAccountOut, null);
            this.cmbAccountOut.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAccountOut.DvDataField = null;
            this.cmbAccountOut.DvEditorValueChanged = true;
            this.cmbAccountOut.DvErrorProvider = this.errorProvider1;
            this.cmbAccountOut.DvLinkedLabel = this.lbAccountOut;
            this.cmbAccountOut.DvMaxLength = 0;
            this.cmbAccountOut.DvMinLength = 0;
            this.cmbAccountOut.DvRegCode = null;
            this.cmbAccountOut.DvRequired = true;
            this.cmbAccountOut.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbAccountOut.DvValidateEnabled = true;
            this.cmbAccountOut.DvValidator = this.validatorList1;
            this.cmbAccountOut.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAccountOut, "cmbAccountOut");
            this.cmbAccountOut.Name = "cmbAccountOut";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // lbAccountIn
            // 
            resources.ApplyResources(this.lbAccountIn, "lbAccountIn");
            this.lbAccountIn.Name = "lbAccountIn";
            // 
            // lbNameIn
            // 
            resources.ApplyResources(this.lbNameIn, "lbNameIn");
            this.lbNameIn.Name = "lbNameIn";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // tbNameIn
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbNameIn, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbNameIn, null);
            this.tbNameIn.DvDataField = null;
            this.tbNameIn.DvEditorValueChanged = false;
            this.tbNameIn.DvErrorProvider = this.errorProvider1;
            this.tbNameIn.DvLinkedLabel = this.lbNameIn;
            this.tbNameIn.DvMaxLength = 0;
            this.tbNameIn.DvMinLength = 0;
            this.tbNameIn.DvRegCode = null;
            this.tbNameIn.DvRequired = false;
            this.tbNameIn.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbNameIn.DvValidateEnabled = true;
            this.tbNameIn.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbNameIn, "tbNameIn");
            this.tbNameIn.Name = "tbNameIn";
            // 
            // cmbAccountIn
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbAccountIn, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbAccountIn, this.ambiguityInputAgent2);
            this.cmbAccountIn.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAccountIn.DvDataField = null;
            this.cmbAccountIn.DvEditorValueChanged = true;
            this.cmbAccountIn.DvErrorProvider = this.errorProvider1;
            this.cmbAccountIn.DvLinkedLabel = this.lbAccountIn;
            this.cmbAccountIn.DvMaxLength = 0;
            this.cmbAccountIn.DvMinLength = 0;
            this.cmbAccountIn.DvRegCode = null;
            this.cmbAccountIn.DvRequired = true;
            this.cmbAccountIn.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbAccountIn.DvValidateEnabled = true;
            this.cmbAccountIn.DvValidator = this.validatorList1;
            this.cmbAccountIn.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAccountIn, "cmbAccountIn");
            this.cmbAccountIn.Name = "cmbAccountIn";
            // 
            // lbAmount
            // 
            resources.ApplyResources(this.lbAmount, "lbAmount");
            this.lbAmount.Name = "lbAmount";
            // 
            // tbAmount
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbAmount, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbAmount, null);
            this.tbAmount.DvDataField = null;
            this.tbAmount.DvEditorValueChanged = false;
            this.tbAmount.DvErrorProvider = this.errorProvider1;
            this.tbAmount.DvLinkedLabel = this.lbAmount;
            this.tbAmount.DvMaxLength = 0;
            this.tbAmount.DvMinLength = 0;
            this.tbAmount.DvRegCode = null;
            this.tbAmount.DvRequired = false;
            this.tbAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbAmount.DvValidateEnabled = true;
            this.tbAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbAmount, "tbAmount");
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // lbAddition
            // 
            resources.ApplyResources(this.lbAddition, "lbAddition");
            this.lbAddition.Name = "lbAddition";
            // 
            // tbAddition
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.tbAddition, null);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.tbAddition, null);
            this.tbAddition.DvDataField = null;
            this.tbAddition.DvEditorValueChanged = false;
            this.tbAddition.DvErrorProvider = this.errorProvider1;
            this.tbAddition.DvLinkedLabel = null;
            this.tbAddition.DvMaxLength = 0;
            this.tbAddition.DvMinLength = 0;
            this.tbAddition.DvRegCode = null;
            this.tbAddition.DvRequired = false;
            this.tbAddition.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbAddition.DvValidateEnabled = true;
            this.tbAddition.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbAddition, "tbAddition");
            this.tbAddition.Name = "tbAddition";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // chbOut
            // 
            resources.ApplyResources(this.chbOut, "chbOut");
            this.chbOut.Checked = true;
            this.chbOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOut.Name = "chbOut";
            this.chbOut.UseVisualStyleBackColor = true;
            // 
            // chbIn
            // 
            resources.ApplyResources(this.chbIn, "chbIn");
            this.chbIn.Checked = true;
            this.chbIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIn.Name = "chbIn";
            this.chbIn.UseVisualStyleBackColor = true;
            // 
            // cmbCashType
            // 
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.cmbCashType, null);
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.cmbCashType, null);
            this.cmbCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashType.DvDataField = null;
            this.cmbCashType.DvEditorValueChanged = false;
            this.cmbCashType.DvErrorProvider = this.errorProvider1;
            this.cmbCashType.DvLinkedLabel = this.label1;
            this.cmbCashType.DvMaxLength = 0;
            this.cmbCashType.DvMinLength = 0;
            this.cmbCashType.DvRegCode = null;
            this.cmbCashType.DvRequired = true;
            this.cmbCashType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbCashType.DvValidateEnabled = true;
            this.cmbCashType.DvValidator = this.validatorList1;
            this.cmbCashType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCashType, "cmbCashType");
            this.cmbCashType.Name = "cmbCashType";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // lbAmountDesc
            // 
            resources.ApplyResources(this.lbAmountDesc, "lbAmountDesc");
            this.lbAmountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDesc.Name = "lbAmountDesc";
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
            // ambiguityInputAgent2
            // 
            this.ambiguityInputAgent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent2.ImageList = null;
            this.ambiguityInputAgent2.Items = new string[0];
            this.ambiguityInputAgent2.MinFragmentLength = 2;
            this.ambiguityInputAgent2.SearchPattern = "[0-9a-zA-Z]";
            this.ambiguityInputAgent2.TargetControlPacker = null;
            // 
            // InitiativeAllotEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cmbCashType);
            this.Controls.Add(this.cmbAccountIn);
            this.Controls.Add(this.tbAddition);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.tbNameIn);
            this.Controls.Add(this.cmbAccountOut);
            this.Controls.Add(this.tbNameOut);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.lbAddition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbAmountDesc);
            this.Controls.Add(this.lbNameIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbAccountIn);
            this.Controls.Add(this.lbNameOut);
            this.Controls.Add(this.lbAccountOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbOut);
            this.Controls.Add(this.chbIn);
            this.Name = "InitiativeAllotEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAccountOut;
        private TextBoxCanValidate tbNameOut;
        private ComboBoxCanValidate cmbAccountOut;
        private System.Windows.Forms.Label lbNameOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAccountIn;
        private System.Windows.Forms.Label lbNameIn;
        private System.Windows.Forms.Label label6;
        private TextBoxCanValidate tbNameIn;
        private ComboBoxCanValidate cmbAccountIn;
        private System.Windows.Forms.Label lbAmount;
        private TextBoxCanValidate tbAmount;
        private System.Windows.Forms.Label lbAddition;
        private TextBoxCanValidate tbAddition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbOut;
        private System.Windows.Forms.CheckBox chbIn;
        private ComboBoxCanValidate cmbCashType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbAmountDesc;
        private AmbiguityInputAgent ambiguityInputAgent2;
        private AmbiguityInputAgent ambiguityInputAgent1;
    }
}
