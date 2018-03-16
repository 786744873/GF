using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CommonClient;
using CommonClient.Contract;
using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;


namespace BOC_BATCH_TOOL
{

    public partial class frmMain : Form, IModuleWorkSpaceHost
    {
        private static IModuleWorkSpaceHost _workSpaceMainHost;
        public static IModuleWorkSpaceHost WorkSpaceMainHost { get { return _workSpaceMainHost; } }

        public frmMain()
        {
            _workSpaceMainHost = this;
            InitializeComponent();
            this.DoubleBuffered = true;
            tsmiCHT.Visible =
            tsmiEN.Visible = false;
            frmModuleSelector.ChangebtMore += new frmModuleSelector.ChangebtMore_imgeHandle(ChangebtMore);
            //CommandCenter.OnShowPanelEventHandler += new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler);
            helpProvider1.HelpNamespace = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.mht");
        }

        public void LoadModuleWorkSpace(IModuleWorkSpace autoTestModule)
        {
            pnlContainer.Controls.Add(autoTestModule as Control);
            (autoTestModule as Control).Parent = pnlContainer;
            (autoTestModule as Control).Dock = System.Windows.Forms.DockStyle.Fill;
            (autoTestModule as Control).BringToFront();
            (autoTestModule as Control).Show();
        }

        IModuleWorkSpace m_ActivingModule;
        public IModuleWorkSpace ActivingModule { get { return m_ActivingModule; } set { m_ActivingModule = value; if ((SystemSettings.CurrentVersion & VersionType.v501) != VersionType.v501) SettingCurrentBusinessModuleMenu(); } }

        public delegate IModuleWorkSpace CreateModuleWorkSpaceDelegate(Type type, ModuleWorkSpaceInfoAttribute attribute);
        public IModuleWorkSpace CreateModuleWorkSpace(Type type, ModuleWorkSpaceInfoAttribute attribute)
        {
            if (this.InvokeRequired)
                return (IModuleWorkSpace)this.Invoke(new CreateModuleWorkSpaceDelegate(CreateModuleWorkSpace), type, attribute);
            SplashFormController.StatusText = "Loading " + attribute.BusinessName + "   " + attribute.ModuleName + " ... ";
            var plugIn = (IModuleWorkSpace)Activator.CreateInstance(type);
            return plugIn;
        }

        public void ClearEntranceButtons()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(ClearEntranceButtons));
            else
            {
                SplashFormController.Closeup();
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501) ;//flpMenuList.Controls.Clear();
                else frmModuleSelector.ClearEntranceButtons();
            }
        }

        public delegate void AddEntranceButtonDelegate(string buttonText, IModuleWorkSpace linkedPlugin);
        public void AddEntranceButton(string buttonText, IModuleWorkSpace linkedPlugin)
        {
            if (this.InvokeRequired)
                this.Invoke(new AddEntranceButtonDelegate(AddEntranceButton), new object[] { buttonText, linkedPlugin });
            else
            {
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                {
                    if (linkedPlugin.ModuleWorkSpaceInfoAttribute.ModuleWorkSpaceType != ModuleWorkSpaceType.BusinessModule)
                        return;
                    CommonClient.EnumTypes.AppliableFunctionType aft = CommonClient.EnumTypes.AppliableFunctionType._Empty;
                    if (linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag != null)
                        aft = (CommonClient.EnumTypes.AppliableFunctionType)linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag;
                    bool flag = (((long)aft > 0 && (CommonClient.SysCoach.SystemSettings.AppliableTypes & aft) == aft) || ((long)aft < 0 && (CommonClient.SysCoach.SystemSettings.AppliableTypes4Bar & (CommonClient.EnumTypes.AppliableFunctionType)Math.Abs((long)aft)) == (CommonClient.EnumTypes.AppliableFunctionType)Math.Abs((long)aft)));
                    var aButton = new ThemedButton { Text = linkedPlugin.ModuleWorkSpaceInfoAttribute.BusinessName, ThemeName = ThemeName.Corp_Blue, Width = 138, Height = 35, Tag = linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag };
                    int width = (int)this.CreateGraphics().MeasureString(linkedPlugin.ModuleWorkSpaceInfoAttribute.BusinessName, aButton.Font).Width + 15;
                    aButton.Width = width;
                    aButton.Click += (sender1, e1) =>
                    {
                        linkedPlugin.LoadModuleWorkSpace();
                        linkedPlugin.FormLoader.ActivingModule = linkedPlugin;
                        LoadSettingModule((AppliableFunctionType)linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag);
                        SetMenuListStyle((AppliableFunctionType)linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag);
                        m_ActivingModule = linkedPlugin;
                    };
                    aButton.Visible = flag;
                    aButton.Parent = flpMenuList;
                    flpMenuList.Controls.Add(aButton);
                    aButton.Margin = new Padding(1, 3, 1, 3);
                }
                else frmModuleSelector.AddEntranceButton(buttonText, linkedPlugin);
            }
        }

        public delegate void LoadFinishDelegate();
        public void LoadFinish()
        {
            if (this.InvokeRequired)
                this.Invoke(new LoadFinishDelegate(LoadFinish));
            else
            {
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                {
                    //添加如何显示默认页面；已勾选了的显示第一个显示的，没有勾选的显示“设置”
                    if (SystemSettings.AppliableTypes == AppliableFunctionType._Empty) btnSettings.PerformClick();
                    else btnMore.PerformClick();
                }
                else btnSettings.PerformClick();
            }
        }

        public delegate void ActiveButtonDelegate(object fst);
        public void ActiveButton(object fst)
        {
            if (this.InvokeRequired) { this.Invoke(new ActiveButtonDelegate(ActiveButton), fst); }
            else
            {
                FunctionInSettingType tt = (FunctionInSettingType)fst;
                if (tt == FunctionInSettingType.MapSetting)
                    btnConverter.PerformClick();
                else if (tt != FunctionInSettingType.Empty)
                    btnSettings.PerformClick();
            }
        }

        public void SettingCurrentBusinessModuleMenu()
        {
            using (var graphics = btnBusiness.CreateGraphics())
            {
                var textSize = graphics.MeasureString(m_ActivingModule.ModuleWorkSpaceInfoAttribute.BusinessName, btnBusiness.Font);
                var realWidth = (int)textSize.Width + 60;
                if (realWidth < 400)
                    btnBusiness.Width = realWidth;
                else
                    btnBusiness.Width = 400;
            }
            btnBusiness.Location = new Point(187, 50);
            btnBusiness.Text = m_ActivingModule.ModuleWorkSpaceInfoAttribute.BusinessName;
            btnBusiness.Visible = true;
            btnMore.Location = new Point(btnBusiness.Location.X + btnBusiness.Width, btnBusiness.Location.Y);
            btnConverter.Location = new Point(btnMore.Location.X + btnMore.Width, btnMore.Location.Y);
            btnSettings.Location = new Point(btnConverter.Location.X + btnConverter.Width, btnConverter.Location.Y);
            //UIAnimation.Do(btnMore, "Left", btnBusiness.Location.X + btnBusiness.Width, new AnimationTypeDeceleration(300));
            SetMenuListStyle((AppliableFunctionType)m_ActivingModule.ModuleWorkSpaceInfoAttribute.Tag);
        }

        void frmMain_Load(object sender, EventArgs e)
        {
            tsmiUpdate.AutoToolTip = tsmiMultiLanguage.AutoToolTip = true;

            ModuleWorkSpaceLoader.LoadPotentialModuleWorkSpaces(this);

            //CommandCenter.ResolveShowPanel(OperatorCommandType.View, AppliableFunctionType._Empty, FunctionInSettingType.FunctionSetting);
            //CommandCenter.ResolveEncryption(OperatorCommandType.View, SystemSettings.IsMatchPassword4ShortProxyOut, SystemSettings.ShortProxyOutPassword, AppliableFunctionType.AgentExpressOut);
            //CommandCenter.ResolveEncryption(OperatorCommandType.View, SystemSettings.IsMatchPassword4TransferOverCountry, SystemSettings.TransferOverCountryPassword, AppliableFunctionType.TransferOverCountry);
            //CommandCenter.ResolveEncryption(OperatorCommandType.View, SystemSettings.IsMatchPassword4TransferForeignMoney, SystemSettings.TransferForeignMoneyPassword, AppliableFunctionType.TransferForeignMoney);

            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501) btnMore.Image = null;
        }

        void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxPrime.Show(((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar) ? MultiLanguageConvertHelper.FrmMain_LoginOff_System : MultiLanguageConvertHelper.FrmMain_Bar_LoginOff_System, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    ModuleWorkSpaceLoader.BroadCastApplicationQuiting();
                    SystemSettings.CheckInit();
                    CommonInformations.SaveLocationData();
                    CommonInformations.ClearTempFile();
                }
                catch { }
                finally { e.Cancel = false; }
            }
            else
            {
                e.Cancel = true;
            }
        }

        //void CommandCenter_OnShowPanelEventHandler(object sender, ShowPanelEventArgs e)
        //{
        //    if (this.InvokeRequired) { this.Invoke(new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler), sender, e); }
        //    else
        //    {
        //        if (e.AppType != AppliableFunctionType._Empty)
        //            appFunctionPanel1.BringToFront();
        //        else if (e.AppType == AppliableFunctionType._Empty)// && e.BatchAppType != FunctionInSettingType.Empty)
        //            settingsPanel1.BringToFront();
        //    }
        //}

        //private string GetCurrentLanguage()
        //{
        //    string result = string.Empty;
        //    try { result = EnumNameHelper<UILang>.GetEnumDescription(SystemSettings.CurrentLanguage); }
        //    catch { }
        //    return result;
        //}

        //private void SetCurrentLanguage()
        //{
        //    try
        //    {
        //        switch (SystemSettings.CurrentLanguage)
        //        {
        //            case UILang.CHS:
        //                tsmiCHS.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menuredbg;
        //                tsmiEN.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menunormalbg;
        //                tsmiCHT.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menunormalbg;
        //                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-cn");
        //                break;
        //            case UILang.EN:
        //                tsmiCHS.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menunormalbg;
        //                tsmiEN.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menuredbg;
        //                tsmiCHT.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menunormalbg;
        //                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
        //                break;
        //            case UILang.CHT:
        //                tsmiCHS.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menunormalbg;
        //                tsmiEN.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menunormalbg;
        //                tsmiCHT.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.menuredbg;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        CommandCenter.ResolveLanguageChanged(OperatorCommandType.Submit, SystemSettings.CurrentLanguage);
        //        ApplyResource();
        //        menuControlPanel1.Width = this.Width - 373;
        //        CommandCenter.ResolveAppliableFunction(OperatorCommandType.AppVisiableResolve, SystemSettings.AppliableTypes, SystemSettings.AppliableTypes4Bar);
        //        ChangeUIStyle();
        //    }
        //}

        //private void ChangeUIStyle()
        //{
        //    this.Text = CommonInformations.GetFormMainTextByVersion();
        //    tsmiLoginNetBank.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Goto_E_Net;
        //    tsmiMultiLanguage.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Change_Language;
        //    tsmiCHS.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_CHS;
        //    tsmiEN.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_EN;
        //    tsmiCHT.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_CHT;
        //    tsmiUpdate.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Update;
        //    tsmiLinkBankCode.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Update_File_BankLinkNo;
        //    tsmiOpenBankCode.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Update_File_OpenBankCode;
        //    tsmiClearBankCode.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Update_File_ClearBankCode;
        //    tsmiOnLineSoftUpdate.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Update_File_Soft;
        //    tsmiHelp.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Help;
        //    tsmiAbout.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Help_About;
        //    tsmiOperatorDesc.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_Help_OperationDescription;
        //    tsmiLoginOut.Text = ConvertHelper.MultiLanguageConvertHelper.FrmMain_LoginOff;
        //}

        private void helperPanel_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Control ctl in helperPanel.Controls)
            {
                if (ctl is Panel)
                    (ctl as Panel).BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.righttopbgNormal;
            }
            (sender as Panel).BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.righttopbgPress;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            frmVersion frm = new frmVersion();
            frm.ShowDialog(this);
        }

        private void tsmiLoginOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiMultiLanguage_Click(object sender, EventArgs e)
        {
            //UILang lang = SystemSettings.CurrentLanguage;
            //if (((ToolStripMenuItem)sender).Name == tsmiCHS.Name)
            //{
            //    lang = UILang.CHS;
            //    //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-Hans");
            //}
            //else if (((ToolStripMenuItem)sender).Name == tsmiEN.Name)
            //{
            //    lang = UILang.EN;
            //    //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //}
            //else if (((ToolStripMenuItem)sender).Name == tsmiCHT.Name)
            //{
            //    lang = UILang.CHT;
            //    //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //}
            //if (lang != SystemSettings.CurrentLanguage)
            //{
            //    SystemSettings.CurrentLanguage = lang;
            //    SetCurrentLanguage();
            //}
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            //CommandCenter.ResolveMoveMenu(OperatorCommandType.View, 0, 0, 0, 0, 0, OperatorCommandType.View);
        }

        private void tsmiCodeUpdate_Click(object sender, EventArgs e)
        {
            string typeName = ((ToolStripMenuItem)sender).Name;
            UpdateFleType uft = UpdateFleType.Empty;
            if (tsmiLinkBankCode.Name.Equals(typeName))
                uft = UpdateFleType.BankLinkNo;
            else if (typeName == tsmiOpenBankCode.Name)
                uft = UpdateFleType.OpenBankInfo;
            else if (typeName == tsmiClearBankCode.Name)
                uft = UpdateFleType.ClearBankInfo;
            else if (typeName == tsmiElecTicket.Name)
                uft = UpdateFleType.ElecTicket;

            frmImportLocalFiles frm = new frmImportLocalFiles(uft);
            frm.ShowDialog(this);
            if (frm != null)
                frm.Close();
        }

        private void tsmiOnLineSoftUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var app = new System.Diagnostics.Process { StartInfo = { Arguments = "checkupdate", FileName = "BOC_UPDATER.exe", CreateNoWindow = true } };
                app.Start();
            }
            catch { }
        }

        private void tsmiOperatorDesc_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.mht");
            if (!File.Exists(filepath))
            {
                //MessageBoxPrime.Show(MultiLanguageConvertHelper.FrmMain_HelpFile_Missing, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error); return;
            }
            System.Diagnostics.Process.Start("iexplore.exe", filepath);
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            var res = new ComponentResourceManager(typeof(frmMain));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
                ApplyChildResource(ref res, ctl);
            }

            //菜单
            //foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            //{
            //    res.ApplyResources(item, item.Name);
            //    foreach (ToolStripMenuItem subItem in item.DropDownItems)
            //    {
            //        res.ApplyResources(subItem, subItem.Name);
            //    }
            //}

            //Caption
            res.ApplyResources(this, "$this");
        }

        private void ApplyChildResource(ref ComponentResourceManager res, Control ctl)
        {
            if (!ctl.HasChildren) return;
            foreach (Control c in ctl.Controls)
            {
                res.ApplyResources(c, c.Name);
            }
        }

        private void tsmiLoginNetBank_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe", "https://ebsnew.boc.cn/boccp/login.html");
            }
            catch { }//MessageBoxPrime.Show("未找到IE浏览器", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //BOC_BATCH_TOOL.MatchFile.DataFileHelper.SaveAllMappingSettings();
        }
        private void btnMore_Click(object sender, EventArgs e)
        {
            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
            {
                bool flag = SystemSettings.AppliableTypes != AppliableFunctionType._Empty;
                pnlMenuList.Visible = flag;
                if (flag)
                {
                    //添加显示二级菜单区域，并默认显示第一个勾选的业务；如果有已编辑过的且勾选的菜单，则直接显示已编辑过的
                    ThemedButton firstbtn = null;
                    ThemedButton currentbtn = null;
                    AppliableFunctionType curraft = AppliableFunctionType._Empty;
                    if (null != m_ActivingModule) curraft = (AppliableFunctionType)m_ActivingModule.ModuleWorkSpaceInfoAttribute.Tag;
                    //AppliableFunctionType showaft = AppliableFunctionType._Empty;
                    //if ((SystemSettings.AppliableTypes & curraft) == curraft) showaft = curraft;
                    //else showaft = firstaft;
                    //1.显示已勾选功能列表
                    foreach (var item in flpMenuList.Controls)
                    {
                        if (!(item is ThemedButton)) continue;
                        var btn = (ThemedButton)item;
                        AppliableFunctionType aft = AppliableFunctionType._Empty;
                        if (AppliableFunctionType._Empty != (AppliableFunctionType)btn.Tag) aft = (AppliableFunctionType)btn.Tag;
                        btn.Visible = (SystemSettings.AppliableTypes & aft) == aft;
                        if (btn.Visible && firstbtn == null) firstbtn = btn;
                        if (btn.Visible && curraft == aft) currentbtn = btn;
                    }
                    //2.设置当前需要显示的模块
                    if (currentbtn != null) currentbtn.PerformClick();
                    else if (firstbtn != null) firstbtn.PerformClick();
                }
                else
                {
                    btnSettings.PerformClick();
                    ModuleWorkSpaceLoader.BroadcastApplicationBringToFront("BOC_BATCH_TOOL_SETTINGS", FunctionInSettingType.FunctionSetting, AppliableFunctionType._Empty);
                }
            }
            else
            {
                btnMore.Image = Properties.Resources.collapse;
                var position = this.btnMore.Location;
                position.Offset(1, this.btnMore.Height);
                position = btnMore.Parent.PointToScreen(position);
                frmModuleSelector.Instance.FilterEntranceButtons();
                frmModuleSelector.Instance.Location = position;
                frmModuleSelector.Instance.Show();
            }
        }

        void ChangebtMore()
        {
            if (this.InvokeRequired) { this.Invoke(new MethodInvoker(ChangebtMore)); }
            else
            {
                btnMore.Image = Properties.Resources.expand;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadSettingModule(FunctionInSettingType.Empty);
            SetMenuListStyle(FunctionInSettingType.Empty);
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            LoadSettingModule(FunctionInSettingType.MapSetting);
            SetMenuListStyle(FunctionInSettingType.MapSetting);
        }

        private void btnBusiness_Click(object sender, EventArgs e)
        {
            if (!btnBusiness.Visible || null == m_ActivingModule || null == m_ActivingModule.ModuleWorkSpaceInfoAttribute.Tag) return;
            LoadSettingModule((AppliableFunctionType)m_ActivingModule.ModuleWorkSpaceInfoAttribute.Tag);
            SetMenuListStyle((AppliableFunctionType)m_ActivingModule.ModuleWorkSpaceInfoAttribute.Tag);
        }

        void LoadSettingModule(FunctionInSettingType fst)
        {
            foreach (var bm in ModuleWorkSpaceLoader.BusinessModule)
            {
                if (bm.ModuleWorkSpaceInfoAttribute.ModuleWorkSpaceType != ModuleWorkSpaceType.SettingsModule) continue;
                FunctionInSettingType _fst = FunctionInSettingType.Empty;
                if (bm.ModuleWorkSpaceInfoAttribute.Tag == null) continue;
                else _fst = (FunctionInSettingType)bm.ModuleWorkSpaceInfoAttribute.Tag;
                if (_fst == fst)
                    this.LoadModuleWorkSpace(bm);
            }
            pnlMenuList.Visible = false;
        }

        void LoadSettingModule(AppliableFunctionType aft)
        {
            foreach (var bm in ModuleWorkSpaceLoader.BusinessModule)
            {
                if (bm.ModuleWorkSpaceInfoAttribute.ModuleWorkSpaceType != ModuleWorkSpaceType.BusinessModule) continue;
                AppliableFunctionType _aft = AppliableFunctionType._Empty;
                if (bm.ModuleWorkSpaceInfoAttribute.Tag == null) continue;
                else _aft = (AppliableFunctionType)bm.ModuleWorkSpaceInfoAttribute.Tag;
                if (_aft == aft && _aft != AppliableFunctionType._Empty)
                    this.LoadModuleWorkSpace(bm);
            }
        }

        void SetMenuListStyle(object obj)
        {
            btnSettings.ThemeName =
            btnConverter.ThemeName =
            btnBusiness.ThemeName =
            btnMore.ThemeName = ThemeName.Corp_Gray;
            if (obj is AppliableFunctionType)
            {
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                {
                    AppliableFunctionType aft = (AppliableFunctionType)obj;
                    btnMore.ThemeName = ThemeName.Corp_Red;
                    foreach (var item in flpMenuList.Controls)
                    {
                        if (!(item is ThemedButton)) continue;
                        var btn = (ThemedButton)item;
                        if (!btn.Visible) continue;
                        if ((AppliableFunctionType)btn.Tag == aft) btn.ThemeName = ThemeName.Corp_Red;
                        else btn.ThemeName = ThemeName.Corp_Gray;
                    }
                }
                else btnBusiness.ThemeName = ThemeName.Corp_Red;
            }
            else if (obj is FunctionInSettingType)
            {
                FunctionInSettingType fst = (FunctionInSettingType)obj;
                if (fst == FunctionInSettingType.Empty) btnSettings.ThemeName = ThemeName.Corp_Red;
                else if (fst == FunctionInSettingType.MapSetting) btnConverter.ThemeName = ThemeName.Corp_Red;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            //ModuleWorkSpaceLoader.AutoTestingModule.FormLoader = frmPopupModuleContainer.EnsuredInstance;
            if (this.ActivingModule == null)
            {
                MessageBoxPrime.Show("还没有业务模块加载上来，请先加载某个业务模块然后再使用自动测试功能", "自动化测试", MessageBoxButtonsEx.OK, MessageBoxIcon.Hand);
                return;
            }
            frmPopupModuleContainer.EnsuredInstance.LoadModuleWorkSpace(ModuleWorkSpaceLoader.AutoTestingModule);
            (frmPopupModuleContainer.EnsuredInstance as frmPopupModuleContainer).Show(this);
        }

        private void flpMenuList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue == e.OldValue) return;
            bool pdirection = (e.NewValue - e.OldValue) > 0;
            flpMenuList.AutoScrollPosition = new Point(flpMenuList.AutoScrollPosition.X, e.OldValue + 41 * (pdirection ? 1 : -1));
        }
    }
}
