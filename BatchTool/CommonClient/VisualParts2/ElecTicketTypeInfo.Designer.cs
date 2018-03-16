using CommonClient.Controls;

namespace CommonClient.VisualParts2
{
    partial class ElecTicketTypeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketTypeInfo));
            this.lbElecTicketType = new System.Windows.Forms.Label();
            this.cmbElecTicketType = new CommonClient.Controls.ComboBoxCanValidate();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRemitDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRemitDate = new System.Windows.Forms.DateTimePicker();
            this.lbRemitAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbElecTicketEndDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpElecTicketEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbRemitAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAmountDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbElecTicketType
            // 
            resources.ApplyResources(this.lbElecTicketType, "lbElecTicketType");
            this.lbElecTicketType.Name = "lbElecTicketType";
            // 
            // cmbElecTicketType
            // 
            this.cmbElecTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElecTicketType.DvDataField = null;
            this.cmbElecTicketType.DvEditorValueChanged = false;
            this.cmbElecTicketType.DvErrorProvider = this.errorProvider1;
            this.cmbElecTicketType.DvLinkedLabel = this.lbElecTicketType;
            this.cmbElecTicketType.DvMaxLength = 0;
            this.cmbElecTicketType.DvMinLength = 0;
            this.cmbElecTicketType.DvRegCode = null;
            this.cmbElecTicketType.DvRequired = true;
            this.cmbElecTicketType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbElecTicketType.DvValidateEnabled = true;
            this.cmbElecTicketType.DvValidator = this.validatorList1;
            this.cmbElecTicketType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbElecTicketType, "cmbElecTicketType");
            this.cmbElecTicketType.Name = "cmbElecTicketType";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // lbRemitDate
            // 
            resources.ApplyResources(this.lbRemitDate, "lbRemitDate");
            this.lbRemitDate.Name = "lbRemitDate";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // dtpRemitDate
            // 
            resources.ApplyResources(this.dtpRemitDate, "dtpRemitDate");
            this.dtpRemitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRemitDate.Name = "dtpRemitDate";
            // 
            // lbRemitAmount
            // 
            resources.ApplyResources(this.lbRemitAmount, "lbRemitAmount");
            this.lbRemitAmount.Name = "lbRemitAmount";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // lbElecTicketEndDate
            // 
            resources.ApplyResources(this.lbElecTicketEndDate, "lbElecTicketEndDate");
            this.lbElecTicketEndDate.Name = "lbElecTicketEndDate";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Name = "label8";
            // 
            // dtpElecTicketEndDate
            // 
            resources.ApplyResources(this.dtpElecTicketEndDate, "dtpElecTicketEndDate");
            this.dtpElecTicketEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpElecTicketEndDate.Name = "dtpElecTicketEndDate";
            // 
            // tbRemitAmount
            // 
            this.tbRemitAmount.DvDataField = null;
            this.tbRemitAmount.DvEditorValueChanged = false;
            this.tbRemitAmount.DvErrorProvider = this.errorProvider1;
            this.tbRemitAmount.DvLinkedLabel = this.lbRemitAmount;
            this.tbRemitAmount.DvMaxLength = 0;
            this.tbRemitAmount.DvMinLength = 0;
            this.tbRemitAmount.DvRegCode = null;
            this.tbRemitAmount.DvRequired = false;
            this.tbRemitAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbRemitAmount.DvValidateEnabled = true;
            this.tbRemitAmount.DvValidator = this.validatorList1;
            resources.ApplyResources(this.tbRemitAmount, "tbRemitAmount");
            this.tbRemitAmount.Name = "tbRemitAmount";
            this.tbRemitAmount.TextChanged += new System.EventHandler(this.tbRemitAmount_TextChanged);
            // 
            // lbAmountDesc
            // 
            resources.ApplyResources(this.lbAmountDesc, "lbAmountDesc");
            this.lbAmountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDesc.Name = "lbAmountDesc";
            // 
            // ElecTicketTypeInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tbRemitAmount);
            this.Controls.Add(this.dtpElecTicketEndDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpRemitDate);
            this.Controls.Add(this.lbAmountDesc);
            this.Controls.Add(this.lbElecTicketEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRemitAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbRemitDate);
            this.Controls.Add(this.cmbElecTicketType);
            this.Controls.Add(this.lbElecTicketType);
            this.Name = "ElecTicketTypeInfo";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbElecTicketType;
        private ComboBoxCanValidate cmbElecTicketType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRemitDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRemitDate;
        private System.Windows.Forms.Label lbRemitAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbElecTicketEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpElecTicketEndDate;
        private TextBoxCanValidate tbRemitAmount;
        private System.Windows.Forms.Label lbAmountDesc;
    }
}
