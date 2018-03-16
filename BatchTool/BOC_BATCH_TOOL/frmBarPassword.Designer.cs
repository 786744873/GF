namespace BOC_BATCH_TOOL
{
    partial class frmBarPassword
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCanValidate1 = new BOC_BATCH_TOOL.Controls.TextBoxCanValidate();
            this.btnOk = new BOC_BATCH_TOOL.Controls.ThemedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "加密密码：";
            // 
            // textBoxCanValidate1
            // 
            this.textBoxCanValidate1.EditorValueChanged = true;
            this.textBoxCanValidate1.ErrorProvider = null;
            this.textBoxCanValidate1.Location = new System.Drawing.Point(98, 26);
            this.textBoxCanValidate1.MaxLength = 6;
            this.textBoxCanValidate1.Name = "textBoxCanValidate1";
            this.textBoxCanValidate1.PasswordChar = '*';
            this.textBoxCanValidate1.Size = new System.Drawing.Size(100, 21);
            this.textBoxCanValidate1.TabIndex = 1;
            this.textBoxCanValidate1.UseSystemPasswordChar = true;
            this.textBoxCanValidate1.ValidateEnabled = false;
            this.textBoxCanValidate1.ValidateRule.MaxLength = 0;
            this.textBoxCanValidate1.ValidateRule.MinLength = 0;
            this.textBoxCanValidate1.ValidateRule.RegexValue = null;
            this.textBoxCanValidate1.ValidateRule.Required = false;
            // 
            // btnOk
            // 
            this.btnOk.Image = null;
            this.btnOk.Location = new System.Drawing.Point(153, 66);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(45, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmBarPassword
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(239, 101);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBoxCanValidate1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入加密密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.TextBoxCanValidate textBoxCanValidate1;
        private Controls.ThemedButton btnOk;
    }
}