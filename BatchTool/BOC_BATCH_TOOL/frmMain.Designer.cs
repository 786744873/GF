namespace BOC_BATCH_TOOL
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDecrate = new System.Windows.Forms.Panel();
            this.btnConverter = new CommonClient.Controls.ThemedButton();
            this.btnSettings = new CommonClient.Controls.ThemedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.helperPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiLoginNetBank = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMultiLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCHS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCHT = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLinkBankCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenBankCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearBankCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiElecTicket = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOnLineSoftUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOperatorDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoginOut = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMore = new CommonClient.Controls.ThemedButton();
            this.btnBusiness = new CommonClient.Controls.ThemedButton();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMenuList = new System.Windows.Forms.Panel();
            this.flpMenuList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.helperPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlMenuList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.logobg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pnlDecrate);
            this.panel1.Controls.Add(this.btnConverter);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.helperPanel);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnMore);
            this.panel1.Controls.Add(this.btnBusiness);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 89);
            this.panel1.TabIndex = 0;
            // 
            // pnlDecrate
            // 
            this.pnlDecrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.pnlDecrate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDecrate.Location = new System.Drawing.Point(0, 86);
            this.pnlDecrate.Name = "pnlDecrate";
            this.pnlDecrate.Size = new System.Drawing.Size(1068, 3);
            this.pnlDecrate.TabIndex = 9;
            // 
            // btnConverter
            // 
            this.btnConverter.Image = null;
            this.btnConverter.Location = new System.Drawing.Point(299, 50);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(144, 38);
            this.btnConverter.TabIndex = 8;
            this.btnConverter.Text = "批量转换";
            this.btnConverter.UseVisualStyleBackColor = false;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = null;
            this.btnSettings.Location = new System.Drawing.Point(443, 50);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(144, 38);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "设置";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(192, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "欢迎您使用中行企业服务批量制作工具";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // helperPanel
            // 
            this.helperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helperPanel.BackColor = System.Drawing.Color.Transparent;
            this.helperPanel.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.righttopbg;
            this.helperPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helperPanel.Controls.Add(this.menuStrip1);
            this.helperPanel.Location = new System.Drawing.Point(802, 6);
            this.helperPanel.Margin = new System.Windows.Forms.Padding(2);
            this.helperPanel.Name = "helperPanel";
            this.helperPanel.Size = new System.Drawing.Size(264, 30);
            this.helperPanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoginNetBank,
            this.tsmiMultiLanguage,
            this.tsmiUpdate,
            this.tsmiHelp,
            this.tsmiLoginOut});
            this.menuStrip1.Location = new System.Drawing.Point(29, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(240, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiLoginNetBank
            // 
            this.tsmiLoginNetBank.Name = "tsmiLoginNetBank";
            this.tsmiLoginNetBank.Size = new System.Drawing.Size(89, 20);
            this.tsmiLoginNetBank.Text = "登录网上银行";
            this.tsmiLoginNetBank.Click += new System.EventHandler(this.tsmiLoginNetBank_Click);
            // 
            // tsmiMultiLanguage
            // 
            this.tsmiMultiLanguage.AutoToolTip = true;
            this.tsmiMultiLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCHS,
            this.tsmiEN,
            this.tsmiCHT});
            this.tsmiMultiLanguage.Name = "tsmiMultiLanguage";
            this.tsmiMultiLanguage.Size = new System.Drawing.Size(65, 20);
            this.tsmiMultiLanguage.Text = "切换语言";
            this.tsmiMultiLanguage.Visible = false;
            // 
            // tsmiCHS
            // 
            this.tsmiCHS.Name = "tsmiCHS";
            this.tsmiCHS.Size = new System.Drawing.Size(130, 22);
            this.tsmiCHS.Text = "中文";
            this.tsmiCHS.Click += new System.EventHandler(this.tsmiMultiLanguage_Click);
            // 
            // tsmiEN
            // 
            this.tsmiEN.Name = "tsmiEN";
            this.tsmiEN.Size = new System.Drawing.Size(130, 22);
            this.tsmiEN.Text = "英文";
            this.tsmiEN.Click += new System.EventHandler(this.tsmiMultiLanguage_Click);
            // 
            // tsmiCHT
            // 
            this.tsmiCHT.Name = "tsmiCHT";
            this.tsmiCHT.Size = new System.Drawing.Size(130, 22);
            this.tsmiCHT.Text = "中文(繁体)";
            this.tsmiCHT.Click += new System.EventHandler(this.tsmiMultiLanguage_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.AutoToolTip = true;
            this.tsmiUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLinkBankCode,
            this.tsmiOpenBankCode,
            this.tsmiClearBankCode,
            this.tsmiElecTicket,
            this.tsmiOnLineSoftUpdate});
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(41, 20);
            this.tsmiUpdate.Text = "更新";
            this.tsmiUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsmiUpdate.ToolTipText = "99876";
            // 
            // tsmiLinkBankCode
            // 
            this.tsmiLinkBankCode.Name = "tsmiLinkBankCode";
            this.tsmiLinkBankCode.Size = new System.Drawing.Size(142, 22);
            this.tsmiLinkBankCode.Text = "中行联行号";
            this.tsmiLinkBankCode.Click += new System.EventHandler(this.tsmiCodeUpdate_Click);
            // 
            // tsmiOpenBankCode
            // 
            this.tsmiOpenBankCode.Name = "tsmiOpenBankCode";
            this.tsmiOpenBankCode.Size = new System.Drawing.Size(142, 22);
            this.tsmiOpenBankCode.Text = "CNAPS行号";
            this.tsmiOpenBankCode.Click += new System.EventHandler(this.tsmiCodeUpdate_Click);
            // 
            // tsmiClearBankCode
            // 
            this.tsmiClearBankCode.Name = "tsmiClearBankCode";
            this.tsmiClearBankCode.Size = new System.Drawing.Size(142, 22);
            this.tsmiClearBankCode.Text = "清算行号";
            this.tsmiClearBankCode.Click += new System.EventHandler(this.tsmiCodeUpdate_Click);
            // 
            // tsmiElecTicket
            // 
            this.tsmiElecTicket.Name = "tsmiElecTicket";
            this.tsmiElecTicket.Size = new System.Drawing.Size(142, 22);
            this.tsmiElecTicket.Text = "电子汇票行号";
            this.tsmiElecTicket.Click += new System.EventHandler(this.tsmiCodeUpdate_Click);
            // 
            // tsmiOnLineSoftUpdate
            // 
            this.tsmiOnLineSoftUpdate.Name = "tsmiOnLineSoftUpdate";
            this.tsmiOnLineSoftUpdate.Size = new System.Drawing.Size(142, 22);
            this.tsmiOnLineSoftUpdate.Text = "在线软件更新";
            this.tsmiOnLineSoftUpdate.Click += new System.EventHandler(this.tsmiOnLineSoftUpdate_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout,
            this.tsmiOperatorDesc});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(41, 20);
            this.tsmiHelp.Text = "帮助";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(118, 22);
            this.tsmiAbout.Text = "关于";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiVersion_Click);
            // 
            // tsmiOperatorDesc
            // 
            this.tsmiOperatorDesc.Name = "tsmiOperatorDesc";
            this.tsmiOperatorDesc.Size = new System.Drawing.Size(118, 22);
            this.tsmiOperatorDesc.Text = "操作说明";
            this.tsmiOperatorDesc.Click += new System.EventHandler(this.tsmiOperatorDesc_Click);
            // 
            // tsmiLoginOut
            // 
            this.tsmiLoginOut.Name = "tsmiLoginOut";
            this.tsmiLoginOut.Size = new System.Drawing.Size(65, 20);
            this.tsmiLoginOut.Text = "安全退出";
            this.tsmiLoginOut.Click += new System.EventHandler(this.tsmiLoginOut_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.desclogo;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(884, 42);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(181, 38);
            this.panel4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.Biglogo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(24, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 41);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // btnMore
            // 
            this.btnMore.Image = ((System.Drawing.Image)(resources.GetObject("btnMore.Image")));
            this.btnMore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMore.Location = new System.Drawing.Point(187, 50);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(112, 38);
            this.btnMore.TabIndex = 8;
            this.btnMore.Text = "文件制作";
            this.btnMore.ThemeName = CommonClient.Controls.ThemeName.Corp_Gray;
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnBusiness
            // 
            this.btnBusiness.Image = null;
            this.btnBusiness.Location = new System.Drawing.Point(187, 50);
            this.btnBusiness.Name = "btnBusiness";
            this.btnBusiness.Size = new System.Drawing.Size(264, 38);
            this.btnBusiness.TabIndex = 8;
            this.btnBusiness.Text = "当前业务";
            this.btnBusiness.UseVisualStyleBackColor = false;
            this.btnBusiness.Visible = false;
            this.btnBusiness.Click += new System.EventHandler(this.btnBusiness_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 130);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1068, 570);
            this.pnlContainer.TabIndex = 1;
            // 
            // pnlMenuList
            // 
            this.pnlMenuList.Controls.Add(this.flpMenuList);
            this.pnlMenuList.Controls.Add(this.panel3);
            this.pnlMenuList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuList.Location = new System.Drawing.Point(0, 89);
            this.pnlMenuList.Name = "pnlMenuList";
            this.pnlMenuList.Size = new System.Drawing.Size(1068, 41);
            this.pnlMenuList.TabIndex = 0;
            this.pnlMenuList.Visible = false;
            // 
            // flpMenuList
            // 
            this.flpMenuList.AutoScroll = true;
            this.flpMenuList.AutoSize = true;
            this.flpMenuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenuList.Location = new System.Drawing.Point(0, 0);
            this.flpMenuList.Margin = new System.Windows.Forms.Padding(0);
            this.flpMenuList.Name = "flpMenuList";
            this.flpMenuList.Size = new System.Drawing.Size(1068, 40);
            this.flpMenuList.TabIndex = 11;
            this.flpMenuList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flpMenuList_Scroll);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1068, 1);
            this.panel3.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1068, 700);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenuList);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.helpProvider1.SetHelpKeyword(this, "True");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(770, 700);
            this.Name = "frmMain";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中国银行批量文件制作工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.helperPanel.ResumeLayout(false);
            this.helperPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMenuList.ResumeLayout(false);
            this.pnlMenuList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel helperPanel;
        private System.Windows.Forms.Panel panel4;
        //private VisualParts.SettingsPanel settingsPanel1;
        //private VisualParts.AppFunctionPanel appFunctionPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoginNetBank;
        private System.Windows.Forms.ToolStripMenuItem tsmiMultiLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoginOut;
        //private VisualParts.MenuControlPanel menuControlPanel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCHS;
        private System.Windows.Forms.ToolStripMenuItem tsmiEN;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiOperatorDesc;
        private System.Windows.Forms.ToolStripMenuItem tsmiLinkBankCode;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenBankCode;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearBankCode;
        private System.Windows.Forms.ToolStripMenuItem tsmiOnLineSoftUpdate;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCHT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContainer;
        private CommonClient.Controls.ThemedButton btnSettings;
        private CommonClient.Controls.ThemedButton btnBusiness;
        private CommonClient.Controls.ThemedButton btnConverter;
        private CommonClient.Controls.ThemedButton btnMore;
        private System.Windows.Forms.Panel pnlDecrate;
        private System.Windows.Forms.ToolStripMenuItem tsmiElecTicket;
        private System.Windows.Forms.Panel pnlMenuList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flpMenuList;
    }
}
