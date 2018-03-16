using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Contract;
using CommonClient.EnumTypes;

namespace BOC_BATCH_TOOL_Converter
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_Converter", false, 0, "批量转换", FunctionInSettingType.MapSetting, ModuleWorkSpaceType.SettingsModule)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
