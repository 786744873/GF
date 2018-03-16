using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Contract;
using CommonClient.EnumTypes;

namespace BOC_BATCH_TOOL
{
    public partial class frmPopupModuleContainer : Form, IModuleWorkSpaceHost
    {
        public frmPopupModuleContainer()
        {
            InitializeComponent();
        }

        private static IModuleWorkSpaceHost _instance;
        public static IModuleWorkSpaceHost EnsuredInstance
        {
            get
            {
                if (_instance != null && (_instance as ContainerControl).IsDisposed)
                    _instance = null;
                if (_instance == null)
                    _instance = new frmPopupModuleContainer();
                return _instance;
            }
        }

        public IModuleWorkSpaceHost WorkSpaceHost { get; set; }

        public void LoadModuleWorkSpace(IModuleWorkSpace autoTestModule)
        {
            this.Controls.Clear();
            autoTestModule.FormLoader = this;
            this.ActivingModule = autoTestModule;
            var moduleControl = autoTestModule as Control;
            this.Controls.Add(moduleControl);
            moduleControl.Parent = this;
            moduleControl.Dock = DockStyle.Fill;
            moduleControl.Show();

            autoTestModule.Run(frmMain.WorkSpaceMainHost.ActivingModule);
        }

        public IModuleWorkSpace ActivingModule { get; set; }

        public IModuleWorkSpace CreateModuleWorkSpace(Type type, ModuleWorkSpaceInfoAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public delegate void ActiveButtonDelegate(FunctionInSettingType fst);
        public void ActiveButton(object fst)
        {
        }

        public void ClearEntranceButtons()
        {
            throw new NotImplementedException();
        }

        public void AddEntranceButton(string buttonText, IModuleWorkSpace linkedPlugin)
        {
            throw new NotImplementedException();
        }

        public void LoadFinish() { throw new NotImplementedException(); }

        // 如：自动化测试模块

        private void frmPopupModuleContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
    }
}
