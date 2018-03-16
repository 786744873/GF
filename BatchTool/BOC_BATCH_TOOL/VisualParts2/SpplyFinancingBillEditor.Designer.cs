namespace BOC_BATCH_TOOL.VisualParts
{
    partial class SpplyFinancingBillEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpplyFinancingBillEditor));
            this.lbBillSerialNo = new System.Windows.Forms.Label();
            this.tbBillSerialNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbContractNo = new System.Windows.Forms.Label();
            this.tbContractNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbCustomerNo = new System.Windows.Forms.Label();
            this.tbCustomerNo = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbCustomerName = new System.Windows.Forms.Label();
            this.tbCustomerName = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbCashType = new System.Windows.Forms.Label();
            this.cmbCashType = new BOC_BATCH_TOOL.Controls.ComboBoxCanValidate();
            this.lbAmount = new System.Windows.Forms.Label();
            this.tbAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lbBillDate = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBillSerialNo
            // 
            resources.ApplyResources(this.lbBillSerialNo, "lbBillSerialNo");
            this.lbBillSerialNo.Name = "lbBillSerialNo";
            // 
            // tbBillSerialNo
            // 
            this.tbBillSerialNo.EditorValueChanged = false;
            this.tbBillSerialNo.ErrorProvider = null;
            resources.ApplyResources(this.tbBillSerialNo, "tbBillSerialNo");
            this.tbBillSerialNo.Name = "tbBillSerialNo";
            this.tbBillSerialNo.ValidateEnabled = false;
            this.tbBillSerialNo.ValidateRule.MaxLength = 0;
            this.tbBillSerialNo.ValidateRule.MinLength = 0;
            this.tbBillSerialNo.ValidateRule.RegexValue = null;
            this.tbBillSerialNo.ValidateRule.Required = false;
            // 
            // lbContractNo
            // 
            resources.ApplyResources(this.lbContractNo, "lbContractNo");
            this.lbContractNo.Name = "lbContractNo";
            // 
            // tbContractNo
            // 
            this.tbContractNo.EditorValueChanged = false;
            this.tbContractNo.ErrorProvider = null;
            resources.ApplyResources(this.tbContractNo, "tbContractNo");
            this.tbContractNo.Name = "tbContractNo";
            this.tbContractNo.ValidateEnabled = false;
            this.tbContractNo.ValidateRule.MaxLength = 0;
            this.tbContractNo.ValidateRule.MinLength = 0;
            this.tbContractNo.ValidateRule.RegexValue = null;
            this.tbContractNo.ValidateRule.Required = false;
            // 
            // lbCustomerNo
            // 
            resources.ApplyResources(this.lbCustomerNo, "lbCustomerNo");
            this.lbCustomerNo.Name = "lbCustomerNo";
            // 
            // tbCustomerNo
            // 
            this.tbCustomerNo.EditorValueChanged = false;
            this.tbCustomerNo.ErrorProvider = null;
            resources.ApplyResources(this.tbCustomerNo, "tbCustomerNo");
            this.tbCustomerNo.Name = "tbCustomerNo";
            this.tbCustomerNo.ValidateEnabled = true;
            this.tbCustomerNo.ValidateRule.MaxLength = 0;
            this.tbCustomerNo.ValidateRule.MinLength = 0;
            this.tbCustomerNo.ValidateRule.RegexValue = null;
            this.tbCustomerNo.ValidateRule.Required = true;
            // 
            // lbCustomerName
            // 
            resources.ApplyResources(this.lbCustomerName, "lbCustomerName");
            this.lbCustomerName.Name = "lbCustomerName";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.EditorValueChanged = false;
            this.tbCustomerName.ErrorProvider = null;
            resources.ApplyResources(this.tbCustomerName, "tbCustomerName");
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.ValidateEnabled = true;
            this.tbCustomerName.ValidateRule.MaxLength = 0;
            this.tbCustomerName.ValidateRule.MinLength = 0;
            this.tbCustomerName.ValidateRule.RegexValue = null;
            this.tbCustomerName.ValidateRule.Required = true;
            // 
            // lbCashType
            // 
            resources.ApplyResources(this.lbCashType, "lbCashType");
            this.lbCashType.Name = "lbCashType";
            // 
            // cmbCashType
            // 
            this.cmbCashType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashType.EditorValueChanged = false;
            this.cmbCashType.ErrorProvider = null;
            this.cmbCashType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCashType, "cmbCashType");
            this.cmbCashType.MatchStrFlag = false;
            this.cmbCashType.Name = "cmbCashType";
            this.cmbCashType.ValidateEnabled = true;
            this.cmbCashType.ValidateRule.MaxLength = 0;
            this.cmbCashType.ValidateRule.MinLength = 0;
            this.cmbCashType.ValidateRule.RegexValue = null;
            this.cmbCashType.ValidateRule.Required = true;
            // 
            // lbAmount
            // 
            resources.ApplyResources(this.lbAmount, "lbAmount");
            this.lbAmount.Name = "lbAmount";
            // 
            // tbAmount
            // 
            this.tbAmount.EditorValueChanged = false;
            this.tbAmount.ErrorProvider = null;
            resources.ApplyResources(this.tbAmount, "tbAmount");
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.ValidateEnabled = true;
            this.tbAmount.ValidateRule.MaxLength = 0;
            this.tbAmount.ValidateRule.MinLength = 0;
            this.tbAmount.ValidateRule.RegexValue = null;
            this.tbAmount.ValidateRule.Required = true;
            // 
            // dtpBillDate
            // 
            resources.ApplyResources(this.dtpBillDate, "dtpBillDate");
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Name = "dtpBillDate";
            // 
            // dtpStartDate
            // 
            resources.ApplyResources(this.dtpStartDate, "dtpStartDate");
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Name = "dtpStartDate";
            // 
            // dtpEndDate
            // 
            resources.ApplyResources(this.dtpEndDate, "dtpEndDate");
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Name = "dtpEndDate";
            // 
            // lbBillDate
            // 
            resources.ApplyResources(this.lbBillDate, "lbBillDate");
            this.lbBillDate.Name = "lbBillDate";
            // 
            // lbStartDate
            // 
            resources.ApplyResources(this.lbStartDate, "lbStartDate");
            this.lbStartDate.Name = "lbStartDate";
            // 
            // lbEndDate
            // 
            resources.ApplyResources(this.lbEndDate, "lbEndDate");
            this.lbEndDate.Name = "lbEndDate";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Name = "label16";
            // 
            // SpplyFinancingBillEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpBillDate);
            this.Controls.Add(this.cmbCashType);
            this.Controls.Add(this.lbCashType);
            this.Controls.Add(this.tbCustomerName);
            this.Controls.Add(this.tbContractNo);
            this.Controls.Add(this.lbCustomerName);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.lbContractNo);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.lbBillDate);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.tbCustomerNo);
            this.Controls.Add(this.lbCustomerNo);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.tbBillSerialNo);
            this.Controls.Add(this.lbBillSerialNo);
            this.Name = "SpplyFinancingBillEditor";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBillSerialNo;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbBillSerialNo;
        private System.Windows.Forms.Label lbContractNo;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbContractNo;
        private System.Windows.Forms.Label lbCustomerNo;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbCustomerNo;
        private System.Windows.Forms.Label lbCustomerName;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbCustomerName;
        private System.Windows.Forms.Label lbCashType;
        private BOC_BATCH_TOOL.Controls.ComboBoxCanValidate cmbCashType;
        private System.Windows.Forms.Label lbAmount;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbAmount;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lbBillDate;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}
