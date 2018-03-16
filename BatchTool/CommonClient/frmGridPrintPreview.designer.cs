using CommonClient.Controls;

namespace CommonClient
{
    partial class FrmGridPrintPreview
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
            this.rbHorizontal = new System.Windows.Forms.RadioButton();
            this.rbVertical = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDocumentTitle = new System.Windows.Forms.Label();
            this.edtDocumentTitle = new System.Windows.Forms.TextBox();
            this.cbPrintDocumentTitle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbColumns = new System.Windows.Forms.CheckedListBox();
            this.cbPrintAllColumns = new System.Windows.Forms.CheckBox();
            this.cbFitPaperWidth = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new ThemedButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbHorizontal
            // 
            this.rbHorizontal.AutoSize = true;
            this.rbHorizontal.Location = new System.Drawing.Point(245, 20);
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.Size = new System.Drawing.Size(83, 16);
            this.rbHorizontal.TabIndex = 1;
            this.rbHorizontal.Text = "Horizontal";
            this.rbHorizontal.UseVisualStyleBackColor = true;
            // 
            // rbVertical
            // 
            this.rbVertical.AutoSize = true;
            this.rbVertical.Checked = true;
            this.rbVertical.Location = new System.Drawing.Point(168, 20);
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.Size = new System.Drawing.Size(71, 16);
            this.rbVertical.TabIndex = 2;
            this.rbVertical.TabStop = true;
            this.rbVertical.Text = "Vertical";
            this.rbVertical.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Print Direction";
            // 
            // lblDocumentTitle
            // 
            this.lblDocumentTitle.AutoSize = true;
            this.lblDocumentTitle.Enabled = false;
            this.lblDocumentTitle.Location = new System.Drawing.Point(156, 34);
            this.lblDocumentTitle.Name = "lblDocumentTitle";
            this.lblDocumentTitle.Size = new System.Drawing.Size(89, 12);
            this.lblDocumentTitle.TabIndex = 2;
            this.lblDocumentTitle.Text = "Document Title";
            // 
            // edtDocumentTitle
            // 
            this.edtDocumentTitle.Enabled = false;
            this.edtDocumentTitle.Location = new System.Drawing.Point(251, 31);
            this.edtDocumentTitle.Name = "edtDocumentTitle";
            this.edtDocumentTitle.Size = new System.Drawing.Size(224, 21);
            this.edtDocumentTitle.TabIndex = 3;
            // 
            // cbPrintDocumentTitle
            // 
            this.cbPrintDocumentTitle.AutoSize = true;
            this.cbPrintDocumentTitle.Location = new System.Drawing.Point(21, 33);
            this.cbPrintDocumentTitle.Name = "cbPrintDocumentTitle";
            this.cbPrintDocumentTitle.Size = new System.Drawing.Size(90, 16);
            this.cbPrintDocumentTitle.TabIndex = 1;
            this.cbPrintDocumentTitle.Text = "Print Title";
            this.cbPrintDocumentTitle.UseVisualStyleBackColor = true;
            this.cbPrintDocumentTitle.Click += new System.EventHandler(this.cbPrintDocumentTitle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbColumns);
            this.groupBox1.Controls.Add(this.cbPrintAllColumns);
            this.groupBox1.Controls.Add(this.cbPrintDocumentTitle);
            this.groupBox1.Controls.Add(this.edtDocumentTitle);
            this.groupBox1.Controls.Add(this.lblDocumentTitle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 302);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Document Settings";
            // 
            // clbColumns
            // 
            this.clbColumns.CheckOnClick = true;
            this.clbColumns.ColumnWidth = 224;
            this.clbColumns.Enabled = false;
            this.clbColumns.FormattingEnabled = true;
            this.clbColumns.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.clbColumns.Location = new System.Drawing.Point(21, 81);
            this.clbColumns.MultiColumn = true;
            this.clbColumns.Name = "clbColumns";
            this.clbColumns.Size = new System.Drawing.Size(644, 212);
            this.clbColumns.TabIndex = 8;
            // 
            // cbPrintAllColumns
            // 
            this.cbPrintAllColumns.AutoSize = true;
            this.cbPrintAllColumns.Checked = true;
            this.cbPrintAllColumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrintAllColumns.Location = new System.Drawing.Point(21, 59);
            this.cbPrintAllColumns.Name = "cbPrintAllColumns";
            this.cbPrintAllColumns.Size = new System.Drawing.Size(126, 16);
            this.cbPrintAllColumns.TabIndex = 7;
            this.cbPrintAllColumns.Text = "Print All Columns";
            this.cbPrintAllColumns.UseVisualStyleBackColor = true;
            this.cbPrintAllColumns.CheckedChanged += new System.EventHandler(this.cbPrintAllColumns_CheckedChanged);
            // 
            // cbFitPaperWidth
            // 
            this.cbFitPaperWidth.AutoSize = true;
            this.cbFitPaperWidth.Checked = true;
            this.cbFitPaperWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFitPaperWidth.Location = new System.Drawing.Point(168, 43);
            this.cbFitPaperWidth.Name = "cbFitPaperWidth";
            this.cbFitPaperWidth.Size = new System.Drawing.Size(132, 16);
            this.cbFitPaperWidth.TabIndex = 9;
            this.cbFitPaperWidth.Text = "Fit to Paper Width";
            this.cbFitPaperWidth.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbHorizontal);
            this.groupBox2.Controls.Add(this.cbFitPaperWidth);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rbVertical);
            this.groupBox2.Location = new System.Drawing.Point(12, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 63);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Page Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size Opition";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = null;
            this.btnPrint.Location = new System.Drawing.Point(624, 386);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 26);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmGridPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 433);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGridPrintPreview";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grid Print";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbVertical;
        private System.Windows.Forms.RadioButton rbHorizontal;
        private System.Windows.Forms.TextBox edtDocumentTitle;
        private System.Windows.Forms.Label lblDocumentTitle;
        private ThemedButton btnPrint;
        private System.Windows.Forms.CheckBox cbPrintDocumentTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbColumns;
        private System.Windows.Forms.CheckBox cbPrintAllColumns;
        private System.Windows.Forms.CheckBox cbFitPaperWidth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
    }
}