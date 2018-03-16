using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.Contract;
using CommonClient.Controls;
using CommonClient.EnumTypes;

namespace CommonClient.VisualParts
{
    [DesignTimeVisibleAttribute(false)]
    public partial class _BaseModule : BaseUc, IModuleWorkSpace
    {
        public _BaseModule()
        {
            InitializeComponent();
        }

        public virtual IModuleWorkSpaceHost FormLoader { get; set; }

        public virtual ModuleWorkSpaceInfoAttribute ModuleWorkSpaceInfoAttribute
        {
            get
            {
                var attributes = this.GetType().GetCustomAttributes(typeof(ModuleWorkSpaceInfoAttribute), false);
                foreach (object attribute in attributes)
                {
                    var xAttribute = attribute as ModuleWorkSpaceInfoAttribute;
                    if (xAttribute != null)
                        return xAttribute;
                }
                return null;
            }
        }

        public virtual void LoadModuleWorkSpace()
        {
            FormLoader.LoadModuleWorkSpace(this);
        }

        public virtual void Run(object parameter)
        {
        }

        public override void ChangeLanguage(LangCode langCode)
        {
            base.ChangeLanguage(langCode);
            // change datasource langeuage here
        }

        public virtual void BringToFrontEx(string plugName, FunctionInSettingType fst, AppliableFunctionType aft)
        {

        }
    }
}
