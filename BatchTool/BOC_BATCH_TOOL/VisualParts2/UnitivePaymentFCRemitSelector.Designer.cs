namespace BOC_BATCH_TOOL.VisualParts
{
    partial class UnitivePaymentFCRemitSelector
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
            this.tbRemitAmount = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbRemitAmount = new System.Windows.Forms.Label();
            this.tbCustomerRef = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbCustomerRef = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpRemitDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRemitDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbOrgEnd = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.tbOrgPre = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbOrgCode = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblOrgCode = new System.Windows.Forms.Label();
            this.rbExpress = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.lbSendPriority = new System.Windows.Forms.Label();
            this.tbRemittorAddress = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.lbRemittorAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRemitAmount
            // 
            this.tbRemitAmount.EditorValueChanged = false;
            this.tbRemitAmount.ErrorProvider = null;
            this.tbRemitAmount.Location = new System.Drawing.Point(105, 30);
            this.tbRemitAmount.Name = "tbRemitAmount";
            this.tbRemitAmount.Size = new System.Drawing.Size(135, 21);
            this.tbRemitAmount.TabIndex = 22;
            this.tbRemitAmount.ValidateEnabled = true;
            this.tbRemitAmount.ValidateRule.MaxLength = 0;
            this.tbRemitAmount.ValidateRule.MinLength = 0;
            this.tbRemitAmount.ValidateRule.RegexValue = null;
            this.tbRemitAmount.ValidateRule.Required = true;
            // 
            // lbRemitAmount
            // 
            this.lbRemitAmount.AutoSize = true;
            this.lbRemitAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbRemitAmount.Location = new System.Drawing.Point(40, 34);
            this.lbRemitAmount.Name = "lbRemitAmount";
            this.lbRemitAmount.Size = new System.Drawing.Size(65, 12);
            this.lbRemitAmount.TabIndex = 25;
            this.lbRemitAmount.Text = "汇款金额：";
            // 
            // tbCustomerRef
            // 
            this.tbCustomerRef.EditorValueChanged = false;
            this.tbCustomerRef.ErrorProvider = null;
            this.tbCustomerRef.Location = new System.Drawing.Point(105, 57);
            this.tbCustomerRef.Name = "tbCustomerRef";
            this.tbCustomerRef.Size = new System.Drawing.Size(135, 21);
            this.tbCustomerRef.TabIndex = 15;
            this.tbCustomerRef.ValidateEnabled = false;
            this.tbCustomerRef.ValidateRule.MaxLength = 0;
            this.tbCustomerRef.ValidateRule.MinLength = 0;
            this.tbCustomerRef.ValidateRule.RegexValue = null;
            this.tbCustomerRef.ValidateRule.Required = false;
            // 
            // lbCustomerRef
            // 
            this.lbCustomerRef.AutoSize = true;
            this.lbCustomerRef.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCustomerRef.Location = new System.Drawing.Point(16, 61);
            this.lbCustomerRef.Name = "lbCustomerRef";
            this.lbCustomerRef.Size = new System.Drawing.Size(89, 12);
            this.lbCustomerRef.TabIndex = 16;
            this.lbCustomerRef.Text = "客户业务编码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(29, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "*";
            // 
            // dtpRemitDate
            // 
            this.dtpRemitDate.CustomFormat = "yyyy/MM/dd";
            this.dtpRemitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRemitDate.Location = new System.Drawing.Point(105, 3);
            this.dtpRemitDate.Name = "dtpRemitDate";
            this.dtpRemitDate.Size = new System.Drawing.Size(135, 21);
            this.dtpRemitDate.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "*";
            // 
            // lbRemitDate
            // 
            this.lbRemitDate.AutoSize = true;
            this.lbRemitDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbRemitDate.Location = new System.Drawing.Point(16, 7);
            this.lbRemitDate.Name = "lbRemitDate";
            this.lbRemitDate.Size = new System.Drawing.Size(89, 12);
            this.lbRemitDate.TabIndex = 10;
            this.lbRemitDate.Text = "指定付款日期：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbOrgEnd);
            this.panel1.Controls.Add(this.tbOrgPre);
            this.panel1.Controls.Add(this.lbOrgCode);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.lblOrgCode);
            this.panel1.Controls.Add(this.rbExpress);
            this.panel1.Controls.Add(this.rbNormal);
            this.panel1.Controls.Add(this.lbSendPriority);
            this.panel1.Controls.Add(this.tbRemittorAddress);
            this.panel1.Controls.Add(this.lbRemittorAddress);
            this.panel1.Location = new System.Drawing.Point(240, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 90);
            this.panel1.TabIndex = 26;
            this.panel1.Visible = false;
            // 
            // tbOrgEnd
            // 
            this.tbOrgEnd.EditorValueChanged = false;
            this.tbOrgEnd.ErrorProvider = null;
            this.tbOrgEnd.Location = new System.Drawing.Point(207, 57);
            this.tbOrgEnd.MaxLength = 1;
            this.tbOrgEnd.Name = "tbOrgEnd";
            this.tbOrgEnd.Size = new System.Drawing.Size(30, 21);
            this.tbOrgEnd.TabIndex = 51;
            this.tbOrgEnd.ValidateEnabled = true;
            this.tbOrgEnd.ValidateRule.MaxLength = 0;
            this.tbOrgEnd.ValidateRule.MinLength = 0;
            this.tbOrgEnd.ValidateRule.RegexValue = null;
            this.tbOrgEnd.ValidateRule.Required = true;
            // 
            // tbOrgPre
            // 
            this.tbOrgPre.EditorValueChanged = false;
            this.tbOrgPre.ErrorProvider = null;
            this.tbOrgPre.Location = new System.Drawing.Point(105, 57);
            this.tbOrgPre.MaxLength = 8;
            this.tbOrgPre.Name = "tbOrgPre";
            this.tbOrgPre.Size = new System.Drawing.Size(91, 21);
            this.tbOrgPre.TabIndex = 50;
            this.tbOrgPre.ValidateEnabled = true;
            this.tbOrgPre.ValidateRule.MaxLength = 0;
            this.tbOrgPre.ValidateRule.MinLength = 0;
            this.tbOrgPre.ValidateRule.RegexValue = null;
            this.tbOrgPre.ValidateRule.Required = true;
            // 
            // lbOrgCode
            // 
            this.lbOrgCode.AutoSize = true;
            this.lbOrgCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbOrgCode.Location = new System.Drawing.Point(16, 61);
            this.lbOrgCode.Name = "lbOrgCode";
            this.lbOrgCode.Size = new System.Drawing.Size(89, 12);
            this.lbOrgCode.TabIndex = 49;
            this.lbOrgCode.Text = "组织机构代码：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(196, 61);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 47;
            this.label22.Text = "-";
            // 
            // lblOrgCode
            // 
            this.lblOrgCode.AutoSize = true;
            this.lblOrgCode.ForeColor = System.Drawing.Color.Red;
            this.lblOrgCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOrgCode.Location = new System.Drawing.Point(5, 61);
            this.lblOrgCode.Name = "lblOrgCode";
            this.lblOrgCode.Size = new System.Drawing.Size(11, 12);
            this.lblOrgCode.TabIndex = 48;
            this.lblOrgCode.Text = "*";
            // 
            // rbExpress
            // 
            this.rbExpress.AutoSize = true;
            this.rbExpress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbExpress.Location = new System.Drawing.Point(183, 6);
            this.rbExpress.Name = "rbExpress";
            this.rbExpress.Size = new System.Drawing.Size(47, 16);
            this.rbExpress.TabIndex = 45;
            this.rbExpress.Text = "加急";
            this.rbExpress.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbNormal.Location = new System.Drawing.Point(105, 6);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(47, 16);
            this.rbNormal.TabIndex = 44;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "普通";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // lbSendPriority
            // 
            this.lbSendPriority.AutoSize = true;
            this.lbSendPriority.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSendPriority.Location = new System.Drawing.Point(40, 8);
            this.lbSendPriority.Name = "lbSendPriority";
            this.lbSendPriority.Size = new System.Drawing.Size(65, 12);
            this.lbSendPriority.TabIndex = 46;
            this.lbSendPriority.Text = "发电等级：";
            // 
            // tbRemittorAddress
            // 
            this.tbRemittorAddress.EditorValueChanged = false;
            this.tbRemittorAddress.ErrorProvider = null;
            this.tbRemittorAddress.Location = new System.Drawing.Point(105, 30);
            this.tbRemittorAddress.Name = "tbRemittorAddress";
            this.tbRemittorAddress.Size = new System.Drawing.Size(135, 21);
            this.tbRemittorAddress.TabIndex = 43;
            this.tbRemittorAddress.ValidateEnabled = false;
            this.tbRemittorAddress.ValidateRule.MaxLength = 0;
            this.tbRemittorAddress.ValidateRule.MinLength = 0;
            this.tbRemittorAddress.ValidateRule.RegexValue = null;
            this.tbRemittorAddress.ValidateRule.Required = false;
            // 
            // lbRemittorAddress
            // 
            this.lbRemittorAddress.AutoSize = true;
            this.lbRemittorAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbRemittorAddress.Location = new System.Drawing.Point(4, 34);
            this.lbRemittorAddress.Name = "lbRemittorAddress";
            this.lbRemittorAddress.Size = new System.Drawing.Size(101, 12);
            this.lbRemittorAddress.TabIndex = 42;
            this.lbRemittorAddress.Text = "实际付款人地址：";
            // 
            // UnitivePaymentFCRemitSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tbRemitAmount);
            this.Controls.Add(this.lbRemitAmount);
            this.Controls.Add(this.tbCustomerRef);
            this.Controls.Add(this.lbCustomerRef);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpRemitDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbRemitDate);
            this.Controls.Add(this.panel1);
            this.Name = "UnitivePaymentFCRemitSelector";
            this.Size = new System.Drawing.Size(485, 88);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxCanValidate tbRemitAmount;
        private System.Windows.Forms.Label lbRemitAmount;
        private Controls.TextBoxCanValidate tbCustomerRef;
        private System.Windows.Forms.Label lbCustomerRef;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpRemitDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRemitDate;
        private System.Windows.Forms.Panel panel1;
        private Controls.TextBoxCanValidate tbOrgEnd;
        private Controls.TextBoxCanValidate tbOrgPre;
        private System.Windows.Forms.Label lbOrgCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblOrgCode;
        private System.Windows.Forms.RadioButton rbExpress;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.Label lbSendPriority;
        private Controls.TextBoxCanValidate tbRemittorAddress;
        private System.Windows.Forms.Label lbRemittorAddress;
    }
}
