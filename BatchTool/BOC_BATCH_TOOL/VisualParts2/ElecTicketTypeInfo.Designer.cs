namespace BOC_BATCH_TOOL.VisualParts
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
            this.cmbElecTicketType = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRemitDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRemitDate = new System.Windows.Forms.DateTimePicker();
            this.lbRemitAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbElecTicketEndDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpElecTicketEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbRemitAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
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
            this.cmbElecTicketType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbElecTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElecTicketType.EditorValueChanged = false;
            this.cmbElecTicketType.ErrorProvider = null;
            this.cmbElecTicketType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbElecTicketType, "cmbElecTicketType");
            this.cmbElecTicketType.MatchStrFlag = false;
            this.cmbElecTicketType.Name = "cmbElecTicketType";
            this.cmbElecTicketType.ValidateEnabled = true;
            this.cmbElecTicketType.ValidateRule.MaxLength = 0;
            this.cmbElecTicketType.ValidateRule.MinLength = 0;
            this.cmbElecTicketType.ValidateRule.RegexValue = null;
            this.cmbElecTicketType.ValidateRule.Required = true;
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
            this.tbRemitAmount.EditorValueChanged = false;
            this.tbRemitAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbRemitAmount, "tbRemitAmount");
            this.tbRemitAmount.Name = "tbRemitAmount";
            this.tbRemitAmount.ValidateEnabled = true;
            this.tbRemitAmount.ValidateRule.MaxLength = 0;
            this.tbRemitAmount.ValidateRule.MinLength = 0;
            this.tbRemitAmount.ValidateRule.RegexValue = null;
            this.tbRemitAmount.ValidateRule.Required = true;
            // 
            // ElecTicketTypeInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tbRemitAmount);
            this.Controls.Add(this.dtpElecTicketEndDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpRemitDate);
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
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbElecTicketType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRemitDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRemitDate;
        private System.Windows.Forms.Label lbRemitAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbElecTicketEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpElecTicketEndDate;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbRemitAmount;
    }
}
