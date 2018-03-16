namespace CommonClient.VisualParts2
{
    partial class TheCentralGoverment
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
            this.edtPayAmount = new CommonClient.Controls.TextBoxCanValidate();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDesignedPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkContent = new System.Windows.Forms.LinkLabel();
            this.lblpurpose = new System.Windows.Forms.Label();
            this.cmbAdditionalComment = new CommonClient.Controls.ComboBoxCanValidate();
            this.lblAddtion = new System.Windows.Forms.Label();
            this.txtcustomer = new CommonClient.Controls.TextBoxCanValidate();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcode = new CommonClient.Controls.TextBoxCanValidate();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtoddnumber = new CommonClient.Controls.TextBoxCanValidate();
            this.lbAmountDesc = new System.Windows.Forms.Label();
            this.pbTip = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).BeginInit();
            this.SuspendLayout();
            // 
            // edtPayAmount
            // 
            this.edtPayAmount.DvDataField = null;
            this.edtPayAmount.DvEditorValueChanged = false;
            this.edtPayAmount.DvErrorProvider = this.errorProvider1;
            this.edtPayAmount.DvFixLength = false;
            this.edtPayAmount.DvLinkedLabel = this.lblAmount;
            this.edtPayAmount.DvMaxLength = 0;
            this.edtPayAmount.DvMinLength = 0;
            this.edtPayAmount.DvRegCode = null;
            this.edtPayAmount.DvRequired = false;
            this.edtPayAmount.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.edtPayAmount.DvValidateEnabled = true;
            this.edtPayAmount.DvValidator = this.validatorList1;
            this.edtPayAmount.Location = new System.Drawing.Point(123, 3);
            this.edtPayAmount.Name = "edtPayAmount";
            this.edtPayAmount.Size = new System.Drawing.Size(200, 20);
            this.edtPayAmount.TabIndex = 37;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAmount.Location = new System.Drawing.Point(58, 6);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(67, 13);
            this.lblAmount.TabIndex = 38;
            this.lblAmount.Text = "付款金额：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(45, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(323, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "元";
            // 
            // dtDesignedPaymentDate
            // 
            this.dtDesignedPaymentDate.CustomFormat = "yyyy/MM/dd";
            this.dtDesignedPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDesignedPaymentDate.Location = new System.Drawing.Point(123, 56);
            this.dtDesignedPaymentDate.Name = "dtDesignedPaymentDate";
            this.dtDesignedPaymentDate.Size = new System.Drawing.Size(200, 20);
            this.dtDesignedPaymentDate.TabIndex = 44;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDateTime.Location = new System.Drawing.Point(34, 62);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(91, 13);
            this.lblDateTime.TabIndex = 45;
            this.lblDateTime.Text = "指定付款日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(23, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "*";
            // 
            // linkContent
            // 
            this.linkContent.AutoSize = true;
            this.linkContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkContent.Location = new System.Drawing.Point(330, 88);
            this.linkContent.Name = "linkContent";
            this.linkContent.Size = new System.Drawing.Size(31, 13);
            this.linkContent.TabIndex = 51;
            this.linkContent.TabStop = true;
            this.linkContent.Text = "设置";
            this.linkContent.Visible = false;
            // 
            // lblpurpose
            // 
            this.lblpurpose.AutoSize = true;
            this.lblpurpose.ForeColor = System.Drawing.Color.Red;
            this.lblpurpose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpurpose.Location = new System.Drawing.Point(68, 87);
            this.lblpurpose.Name = "lblpurpose";
            this.lblpurpose.Size = new System.Drawing.Size(11, 13);
            this.lblpurpose.TabIndex = 50;
            this.lblpurpose.Text = "*";
            // 
            // cmbAdditionalComment
            // 
            this.cmbAdditionalComment.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAdditionalComment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAdditionalComment.DvDataField = null;
            this.cmbAdditionalComment.DvEditorValueChanged = false;
            this.cmbAdditionalComment.DvErrorProvider = this.errorProvider1;
            this.cmbAdditionalComment.DvFixLength = false;
            this.cmbAdditionalComment.DvLinkedLabel = this.lblAddtion;
            this.cmbAdditionalComment.DvMaxLength = 0;
            this.cmbAdditionalComment.DvMinLength = 0;
            this.cmbAdditionalComment.DvRegCode = null;
            this.cmbAdditionalComment.DvRequired = false;
            this.cmbAdditionalComment.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbAdditionalComment.DvValidateEnabled = true;
            this.cmbAdditionalComment.DvValidator = this.validatorList1;
            this.cmbAdditionalComment.FormattingEnabled = true;
            this.cmbAdditionalComment.Location = new System.Drawing.Point(123, 84);
            this.cmbAdditionalComment.Name = "cmbAdditionalComment";
            this.cmbAdditionalComment.Size = new System.Drawing.Size(200, 21);
            this.cmbAdditionalComment.TabIndex = 48;
            // 
            // lblAddtion
            // 
            this.lblAddtion.AutoSize = true;
            this.lblAddtion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAddtion.Location = new System.Drawing.Point(82, 87);
            this.lblAddtion.Name = "lblAddtion";
            this.lblAddtion.Size = new System.Drawing.Size(43, 13);
            this.lblAddtion.TabIndex = 49;
            this.lblAddtion.Text = "用途：";
            // 
            // txtcustomer
            // 
            this.txtcustomer.DvDataField = null;
            this.txtcustomer.DvEditorValueChanged = false;
            this.txtcustomer.DvErrorProvider = this.errorProvider1;
            this.txtcustomer.DvFixLength = false;
            this.txtcustomer.DvLinkedLabel = this.label4;
            this.txtcustomer.DvMaxLength = 0;
            this.txtcustomer.DvMinLength = 0;
            this.txtcustomer.DvRegCode = null;
            this.txtcustomer.DvRequired = false;
            this.txtcustomer.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.txtcustomer.DvValidateEnabled = true;
            this.txtcustomer.DvValidator = this.validatorList1;
            this.txtcustomer.Location = new System.Drawing.Point(123, 111);
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.Size = new System.Drawing.Size(200, 20);
            this.txtcustomer.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(34, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "客户业务编号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(23, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "*";
            // 
            // txtcode
            // 
            this.txtcode.DvDataField = null;
            this.txtcode.DvEditorValueChanged = false;
            this.txtcode.DvErrorProvider = this.errorProvider1;
            this.txtcode.DvFixLength = false;
            this.txtcode.DvLinkedLabel = this.label2;
            this.txtcode.DvMaxLength = 0;
            this.txtcode.DvMinLength = 0;
            this.txtcode.DvRegCode = null;
            this.txtcode.DvRequired = false;
            this.txtcode.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.txtcode.DvValidateEnabled = true;
            this.txtcode.DvValidator = this.validatorList1;
            this.txtcode.Location = new System.Drawing.Point(123, 137);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(200, 20);
            this.txtcode.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(46, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "支付令编码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(34, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(46, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "海关凭单号：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(34, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "*";
            // 
            // txtoddnumber
            // 
            this.txtoddnumber.DvDataField = null;
            this.txtoddnumber.DvEditorValueChanged = false;
            this.txtoddnumber.DvErrorProvider = null;
            this.txtoddnumber.DvFixLength = false;
            this.txtoddnumber.DvLinkedLabel = this.label9;
            this.txtoddnumber.DvMaxLength = 0;
            this.txtoddnumber.DvMinLength = 0;
            this.txtoddnumber.DvRegCode = null;
            this.txtoddnumber.DvRequired = false;
            this.txtoddnumber.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.txtoddnumber.DvValidateEnabled = true;
            this.txtoddnumber.DvValidator = null;
            this.txtoddnumber.Location = new System.Drawing.Point(123, 163);
            this.txtoddnumber.Name = "txtoddnumber";
            this.txtoddnumber.Size = new System.Drawing.Size(200, 20);
            this.txtoddnumber.TabIndex = 56;
            // 
            // lbAmountDesc
            // 
            this.lbAmountDesc.AutoSize = true;
            this.lbAmountDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbAmountDesc.ForeColor = System.Drawing.Color.Red;
            this.lbAmountDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAmountDesc.Location = new System.Drawing.Point(30, 32);
            this.lbAmountDesc.Name = "lbAmountDesc";
            this.lbAmountDesc.Size = new System.Drawing.Size(0, 13);
            this.lbAmountDesc.TabIndex = 61;
            // 
            // pbTip
            // 
            this.pbTip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTip.Image = global::CommonClient.Properties.Resources.tips;
            this.pbTip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbTip.Location = new System.Drawing.Point(8, 114);
            this.pbTip.Name = "pbTip";
            this.pbTip.Size = new System.Drawing.Size(14, 14);
            this.pbTip.TabIndex = 62;
            this.pbTip.TabStop = false;
            // 
            // TheCentralGoverment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbTip);
            this.Controls.Add(this.lbAmountDesc);
            this.Controls.Add(this.txtoddnumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcustomer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkContent);
            this.Controls.Add(this.lblpurpose);
            this.Controls.Add(this.cmbAdditionalComment);
            this.Controls.Add(this.lblAddtion);
            this.Controls.Add(this.dtDesignedPaymentDate);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtPayAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label1);
            this.Name = "TheCentralGoverment";
            this.Size = new System.Drawing.Size(372, 192);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxCanValidate edtPayAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDesignedPaymentDate;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkContent;
        private System.Windows.Forms.Label lblpurpose;
        private Controls.ComboBoxCanValidate cmbAdditionalComment;
        private System.Windows.Forms.Label lblAddtion;
        private Controls.TextBoxCanValidate txtcustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Controls.TextBoxCanValidate txtcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Controls.TextBoxCanValidate txtoddnumber;
        private System.Windows.Forms.Label lbAmountDesc;
        private System.Windows.Forms.PictureBox pbTip;
    }
}
