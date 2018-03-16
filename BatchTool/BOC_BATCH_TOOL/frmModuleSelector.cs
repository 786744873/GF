using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Contract;
using CommonClient.Controls;
using CommonClient.Utilities;

namespace BOC_BATCH_TOOL
{
    public partial class frmModuleSelector : Form
    {
        private static frmModuleSelector _instance;
        public frmModuleSelector()
        {
            InitializeComponent();
        }

        public static frmModuleSelector Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmModuleSelector();
                return _instance;
            }
        }

        public static void ClearEntranceButtons()
        {
            //Instance.flowLayoutPanel1.Controls.Clear();
        }

        public static void AddEntranceButton(string buttonText, IModuleWorkSpace linkedPlugin)
        {
            if (linkedPlugin.ModuleWorkSpaceInfoAttribute.ModuleWorkSpaceType != ModuleWorkSpaceType.BusinessModule)
                return;
            CommonClient.EnumTypes.AppliableFunctionType aft = CommonClient.EnumTypes.AppliableFunctionType._Empty;
            if (linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag != null)
                aft = (CommonClient.EnumTypes.AppliableFunctionType)linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag;
            bool flag = (((long)aft > 0 && (CommonClient.SysCoach.SystemSettings.AppliableTypes & aft) == aft) || ((long)aft < 0 && (CommonClient.SysCoach.SystemSettings.AppliableTypes4Bar & (CommonClient.EnumTypes.AppliableFunctionType)Math.Abs((long)aft)) == (CommonClient.EnumTypes.AppliableFunctionType)Math.Abs((long)aft)));
            var aButton = new ThemedButton { Text = linkedPlugin.ModuleWorkSpaceInfoAttribute.BusinessName, ThemeName = ThemeName.Corp_Blue, Width = 138, Height = 50, Tag = linkedPlugin.ModuleWorkSpaceInfoAttribute.Tag };
            aButton.Click += (sender1, e1) =>
            {
                linkedPlugin.LoadModuleWorkSpace();
                linkedPlugin.FormLoader.ActivingModule = linkedPlugin;
                Instance.Hide();
            };
            aButton.Parent = Instance.flowLayoutPanel1;
            Instance.flowLayoutPanel1.Controls.Add(aButton);
            aButton.Visible = flag;
            if (flag)
                aButton.Show();
        }

        public void FilterEntranceButtons()
        {
            if (Instance.flowLayoutPanel1.Controls.Count == 0) return;
            foreach (var item in Instance.flowLayoutPanel1.Controls)
            {
                if (item is ThemedButton)
                    (item as ThemedButton).Visible = PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList.Exists(o =>
                        ((((long)o > 0 && (CommonClient.SysCoach.SystemSettings.AppliableTypes & o) == o) || ((long)o < 0 && (CommonClient.SysCoach.SystemSettings.AppliableTypes4Bar & (CommonClient.EnumTypes.AppliableFunctionType)Math.Abs((long)o)) == (CommonClient.EnumTypes.AppliableFunctionType)Math.Abs((long)o))))
                        && (CommonClient.EnumTypes.AppliableFunctionType)o == (CommonClient.EnumTypes.AppliableFunctionType)(item as ThemedButton).Tag);
            }

        }
        public delegate void ChangebtMore_imgeHandle();
        public static event ChangebtMore_imgeHandle ChangebtMore;
        private void frmModuleSelector_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
            if (ChangebtMore != null)
                ChangebtMore();
        }
        private void frmModuleSelector_Shown(object sender, EventArgs e)
        {
        }
    }
}
