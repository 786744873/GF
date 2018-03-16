namespace BOC_BATCH_TOOL.VisualParts
{
    partial class ElecTicketPoolOtherPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElecTicketPoolOtherPanel));
            this.lbPreBackNotedPerson = new System.Windows.Forms.Label();
            this.tbPreBackNotedPerson = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbAutoTip = new System.Windows.Forms.RadioButton();
            this.rbAutoReceive = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbInPool2Mortgage = new System.Windows.Forms.RadioButton();
            this.rbInPool2Truste = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPreBackNotedPerson
            // 
            resources.ApplyResources(this.lbPreBackNotedPerson, "lbPreBackNotedPerson");
            this.lbPreBackNotedPerson.Name = "lbPreBackNotedPerson";
            // 
            // tbPreBackNotedPerson
            // 
            this.tbPreBackNotedPerson.EditorValueChanged = false;
            this.tbPreBackNotedPerson.ErrorProvider = null;
            resources.ApplyResources(this.tbPreBackNotedPerson, "tbPreBackNotedPerson");
            this.tbPreBackNotedPerson.Name = "tbPreBackNotedPerson";
            this.tbPreBackNotedPerson.ValidateEnabled = false;
            this.tbPreBackNotedPerson.ValidateRule.MaxLength = 0;
            this.tbPreBackNotedPerson.ValidateRule.MinLength = 0;
            this.tbPreBackNotedPerson.ValidateRule.RegexValue = null;
            this.tbPreBackNotedPerson.ValidateRule.Required = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbAutoTip);
            this.panel1.Controls.Add(this.rbAutoReceive);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // rbAutoTip
            // 
            resources.ApplyResources(this.rbAutoTip, "rbAutoTip");
            this.rbAutoTip.Name = "rbAutoTip";
            this.rbAutoTip.UseVisualStyleBackColor = true;
            // 
            // rbAutoReceive
            // 
            resources.ApplyResources(this.rbAutoReceive, "rbAutoReceive");
            this.rbAutoReceive.Checked = true;
            this.rbAutoReceive.Name = "rbAutoReceive";
            this.rbAutoReceive.TabStop = true;
            this.rbAutoReceive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbInPool2Mortgage);
            this.panel2.Controls.Add(this.rbInPool2Truste);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // rbInPool2Mortgage
            // 
            resources.ApplyResources(this.rbInPool2Mortgage, "rbInPool2Mortgage");
            this.rbInPool2Mortgage.Name = "rbInPool2Mortgage";
            this.rbInPool2Mortgage.UseVisualStyleBackColor = true;
            // 
            // rbInPool2Truste
            // 
            resources.ApplyResources(this.rbInPool2Truste, "rbInPool2Truste");
            this.rbInPool2Truste.Checked = true;
            this.rbInPool2Truste.Name = "rbInPool2Truste";
            this.rbInPool2Truste.TabStop = true;
            this.rbInPool2Truste.UseVisualStyleBackColor = true;
            // 
            // ElecTicketPoolOtherPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbPreBackNotedPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPreBackNotedPerson);
            this.Name = "ElecTicketPoolOtherPanel";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPreBackNotedPerson;
        private BOC_BATCH_TOOL.Controls.TextBoxCanValidate tbPreBackNotedPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbAutoTip;
        private System.Windows.Forms.RadioButton rbAutoReceive;
        private System.Windows.Forms.RadioButton rbInPool2Mortgage;
        private System.Windows.Forms.RadioButton rbInPool2Truste;
    }
}
