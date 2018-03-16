namespace BOC_UNIT_TEST
{
    partial class Main
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
            this.btnEntityCheck = new System.Windows.Forms.Button();
            this.btnEnumName = new System.Windows.Forms.Button();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxCanValidate1 = new CommonClient.Controls.ComboBoxCanValidate();
            this.ambiguityInputAgent1 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent2 = new CommonClient.Controls.AmbiguityInputAgent();
            this.ambiguityInputAgent3 = new CommonClient.Controls.AmbiguityInputAgent();
            this.SuspendLayout();
            // 
            // btnEntityCheck
            // 
            this.btnEntityCheck.Location = new System.Drawing.Point(12, 8);
            this.btnEntityCheck.Name = "btnEntityCheck";
            this.btnEntityCheck.Size = new System.Drawing.Size(88, 40);
            this.btnEntityCheck.TabIndex = 0;
            this.btnEntityCheck.Text = "Entity Check";
            this.btnEntityCheck.UseVisualStyleBackColor = true;
            this.btnEntityCheck.Click += new System.EventHandler(this.btnEntityCheck_Click);
            // 
            // btnEnumName
            // 
            this.btnEnumName.Location = new System.Drawing.Point(104, 8);
            this.btnEnumName.Name = "btnEnumName";
            this.btnEnumName.Size = new System.Drawing.Size(88, 40);
            this.btnEnumName.TabIndex = 1;
            this.btnEnumName.Text = "Enum Name";
            this.btnEnumName.UseVisualStyleBackColor = true;
            this.btnEnumName.Click += new System.EventHandler(this.btnEnumName_Click);
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(196, 8);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(88, 40);
            this.btnAnimate.TabIndex = 2;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(692, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(760, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 40);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.ambiguityInputAgent2.SetAmbiguityInputAgent(this.textBox1, this.ambiguityInputAgent1);
            this.ambiguityInputAgent3.SetAmbiguityInputAgent(this.textBox1, this.ambiguityInputAgent1);
            this.ambiguityInputAgent1.SetAmbiguityInputAgent(this.textBox1, this.ambiguityInputAgent1);
            this.textBox1.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(80, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 31);
            this.textBox1.TabIndex = 6;
            // 
            // comboBoxCanValidate1
            // 
            this.comboBoxCanValidate1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCanValidate1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCanValidate1.DvDataField = null;
            this.comboBoxCanValidate1.DvEditorValueChanged = true;
            this.comboBoxCanValidate1.DvErrorProvider = null;
            this.comboBoxCanValidate1.DvLinkedLabel = null;
            this.comboBoxCanValidate1.DvMaxLength = 0;
            this.comboBoxCanValidate1.DvMinLength = 0;
            this.comboBoxCanValidate1.DvRegCode = null;
            this.comboBoxCanValidate1.DvRequired = false;
            this.comboBoxCanValidate1.DvRequiredFlagStyle = CommonClient.Controls.RequiredFlagStyle.Left;
            this.comboBoxCanValidate1.DvValidateEnabled = false;
            this.comboBoxCanValidate1.DvValidator = null;
            this.comboBoxCanValidate1.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCanValidate1.FormattingEnabled = true;
            this.comboBoxCanValidate1.Items.AddRange(new object[] {
            "23123576",
            "22577529",
            "14273457",
            "52380232",
            "89432084",
            "23123576",
            "22577529",
            "14273457",
            "52380232",
            "89432084"});
            this.comboBoxCanValidate1.Location = new System.Drawing.Point(296, 292);
            this.comboBoxCanValidate1.Name = "comboBoxCanValidate1";
            this.comboBoxCanValidate1.Size = new System.Drawing.Size(280, 32);
            this.comboBoxCanValidate1.TabIndex = 3;
            // 
            // ambiguityInputAgent1
            // 
            this.ambiguityInputAgent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent1.ImageList = null;
            this.ambiguityInputAgent1.Items = new string[0];
            this.ambiguityInputAgent1.TargetControlPacker = null;
            // 
            // ambiguityInputAgent2
            // 
            this.ambiguityInputAgent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent2.ImageList = null;
            this.ambiguityInputAgent2.Items = new string[0];
            this.ambiguityInputAgent2.TargetControlPacker = null;
            // 
            // ambiguityInputAgent3
            // 
            this.ambiguityInputAgent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ambiguityInputAgent3.ImageList = null;
            this.ambiguityInputAgent3.Items = new string[0];
            this.ambiguityInputAgent3.TargetControlPacker = null;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 365);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxCanValidate1);
            this.Controls.Add(this.btnAnimate);
            this.Controls.Add(this.btnEnumName);
            this.Controls.Add(this.btnEntityCheck);
            this.Name = "Main";
            this.Text = "UNIT TEST";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEntityCheck;
        private System.Windows.Forms.Button btnEnumName;
        private System.Windows.Forms.Button btnAnimate;
        private CommonClient.Controls.ComboBoxCanValidate comboBoxCanValidate1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CommonClient.Controls.AmbiguityInputAgent ambiguityInputAgent2;
        private CommonClient.Controls.AmbiguityInputAgent ambiguityInputAgent1;
        private CommonClient.Controls.AmbiguityInputAgent ambiguityInputAgent3;
    }
}

