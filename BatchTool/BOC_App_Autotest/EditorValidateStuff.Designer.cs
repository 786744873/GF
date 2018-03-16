namespace BOC_App_Autotest
{
    partial class EditorValidateStuff
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
            this.lblElementName = new System.Windows.Forms.Label();
            this.edtValidValues = new System.Windows.Forms.TextBox();
            this.edtInvalidValues = new System.Windows.Forms.TextBox();
            this.lblValidValues = new System.Windows.Forms.Label();
            this.lblValidValueCount = new System.Windows.Forms.Label();
            this.lblInvalidValueCount = new System.Windows.Forms.Label();
            this.lblInValidaValues = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblElementName
            // 
            this.lblElementName.AutoSize = true;
            this.lblElementName.Location = new System.Drawing.Point(12, 8);
            this.lblElementName.Name = "lblElementName";
            this.lblElementName.Size = new System.Drawing.Size(125, 12);
            this.lblElementName.TabIndex = 0;
            this.lblElementName.Text = "元件名<Element Name>";
            // 
            // edtValidValues
            // 
            this.edtValidValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtValidValues.Location = new System.Drawing.Point(8, 48);
            this.edtValidValues.Multiline = true;
            this.edtValidValues.Name = "edtValidValues";
            this.edtValidValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtValidValues.Size = new System.Drawing.Size(376, 220);
            this.edtValidValues.TabIndex = 1;
            this.edtValidValues.TextChanged += new System.EventHandler(this.edtValidValues_TextChanged);
            // 
            // edtInvalidValues
            // 
            this.edtInvalidValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInvalidValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtInvalidValues.Location = new System.Drawing.Point(392, 48);
            this.edtInvalidValues.Multiline = true;
            this.edtInvalidValues.Name = "edtInvalidValues";
            this.edtInvalidValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtInvalidValues.Size = new System.Drawing.Size(376, 220);
            this.edtInvalidValues.TabIndex = 2;
            this.edtInvalidValues.TextChanged += new System.EventHandler(this.edtInvalidValues_TextChanged);
            // 
            // lblValidValues
            // 
            this.lblValidValues.AutoSize = true;
            this.lblValidValues.Location = new System.Drawing.Point(12, 28);
            this.lblValidValues.Name = "lblValidValues";
            this.lblValidValues.Size = new System.Drawing.Size(41, 12);
            this.lblValidValues.TabIndex = 3;
            this.lblValidValues.Text = "合法值";
            // 
            // lblValidValueCount
            // 
            this.lblValidValueCount.AutoSize = true;
            this.lblValidValueCount.Location = new System.Drawing.Point(8, 276);
            this.lblValidValueCount.Name = "lblValidValueCount";
            this.lblValidValueCount.Size = new System.Drawing.Size(17, 12);
            this.lblValidValueCount.TabIndex = 4;
            this.lblValidValueCount.Text = "<>";
            // 
            // lblInvalidValueCount
            // 
            this.lblInvalidValueCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvalidValueCount.AutoSize = true;
            this.lblInvalidValueCount.Location = new System.Drawing.Point(392, 276);
            this.lblInvalidValueCount.Name = "lblInvalidValueCount";
            this.lblInvalidValueCount.Size = new System.Drawing.Size(17, 12);
            this.lblInvalidValueCount.TabIndex = 5;
            this.lblInvalidValueCount.Text = "<>";
            // 
            // lblInValidaValues
            // 
            this.lblInValidaValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInValidaValues.AutoSize = true;
            this.lblInValidaValues.Location = new System.Drawing.Point(388, 28);
            this.lblInValidaValues.Name = "lblInValidaValues";
            this.lblInValidaValues.Size = new System.Drawing.Size(53, 12);
            this.lblInValidaValues.TabIndex = 6;
            this.lblInValidaValues.Text = "非合法值";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(748, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditorValidateStuff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblInValidaValues);
            this.Controls.Add(this.lblInvalidValueCount);
            this.Controls.Add(this.lblValidValueCount);
            this.Controls.Add(this.lblValidValues);
            this.Controls.Add(this.edtInvalidValues);
            this.Controls.Add(this.edtValidValues);
            this.Controls.Add(this.lblElementName);
            this.Name = "EditorValidateStuff";
            this.Size = new System.Drawing.Size(776, 297);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblElementName;
        private System.Windows.Forms.TextBox edtValidValues;
        private System.Windows.Forms.TextBox edtInvalidValues;
        private System.Windows.Forms.Label lblValidValues;
        private System.Windows.Forms.Label lblValidValueCount;
        private System.Windows.Forms.Label lblInvalidValueCount;
        private System.Windows.Forms.Label lblInValidaValues;
        private System.Windows.Forms.Button btnClose;
    }
}
