using CommonClient.Controls;

namespace CommonClient
{
    partial class frmImportLocalFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportLocalFiles));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFileType = new CommonClient.Controls.ComboBoxCanValidate();
            this.tbFilePath = new CommonClient.Controls.TextBoxCanValidate();
            this.btnClose = new CommonClient.Controls.ThemedButton();
            this.btnImport = new CommonClient.Controls.ThemedButton();
            this.btnSelectedFile = new CommonClient.Controls.ThemedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmbFileType
            // 
            resources.ApplyResources(this.cmbFileType, "cmbFileType");
            this.cmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileType.DvDataField = null;
            this.cmbFileType.DvEditorValueChanged = false;
            this.cmbFileType.DvErrorProvider = null;
            this.cmbFileType.DvLinkedLabel = null;
            this.cmbFileType.DvMaxLength = 0;
            this.cmbFileType.DvMinLength = 0;
            this.cmbFileType.DvRegCode = "Predefined";
            this.cmbFileType.DvRequired = false;
            this.cmbFileType.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.cmbFileType.DvValidateEnabled =true;
            this.cmbFileType.DvValidator = null;
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Name = "cmbFileType";
            // 
            // tbFilePath
            // 
            resources.ApplyResources(this.tbFilePath, "tbFilePath");
            this.tbFilePath.DvDataField = null;
            this.tbFilePath.DvEditorValueChanged = false;
            this.tbFilePath.DvErrorProvider = null;
            this.tbFilePath.DvLinkedLabel = null;
            this.tbFilePath.DvMaxLength = 0;
            this.tbFilePath.DvMinLength = 0;
            this.tbFilePath.DvRegCode = "Predefined";
            this.tbFilePath.DvRequired = false;
            this.tbFilePath.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.tbFilePath.DvValidateEnabled =true;
            this.tbFilePath.DvValidator = null;
            this.tbFilePath.Name = "tbFilePath";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSelectedFile
            // 
            resources.ApplyResources(this.btnSelectedFile, "btnSelectedFile");
            this.btnSelectedFile.Name = "btnSelectedFile";
            this.btnSelectedFile.UseVisualStyleBackColor = false;
            this.btnSelectedFile.Click += new System.EventHandler(this.btnSelectedFile_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Name = "label3";
            // 
            // frmImportLocalFiles
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSelectedFile);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.cmbFileType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportLocalFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ComboBoxCanValidate cmbFileType;
        private TextBoxCanValidate tbFilePath;
        private ThemedButton btnSelectedFile;
        private ThemedButton btnImport;
        private ThemedButton btnClose;
        private System.Windows.Forms.Label label3;
    }
}