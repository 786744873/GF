using System.Windows.Forms;
using BOC_BATCH_TOOL.Controls;
using System.ComponentModel;
using BOC_BATCH_TOOL.EnumTypes;
using System;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class BaseUc : UserControl
    {
        public BaseUc()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public string GetLanguageString(UILang lang)
        {
            string str = "zh-cn";
            switch (lang)
            {
                case UILang.CHS:
                    str = "zh-cn";
                    break;
                case UILang.EN:
                    str = "en-us";
                    break;
                case UILang.CHT:
                    break;
                default:
                    break;
            }

            return str;
        }

        public bool CheckChanged()
        {
            foreach (Control control in this.Controls)
            {
                var realControl = (IRegValidator)control;
                if (realControl != null)
                {
                    if (realControl.EditorValueChanged)
                        return true;
                }
            }
            return false;
        }

        public bool CheckValid()
        {
            foreach (Control control in this.Controls)
            {
                var realControl = (IRegValidator)control;
                if (realControl != null)
                {
                    var isValid = EditorCustomizer.ValidateEditor(realControl, control.Text);
                    if (!isValid)
                        return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        public void ApplyResource(Type t, Control ctlObj)
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(t);
            foreach (Control ctl in ctlObj.Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
                ApplyChildResource(ref res, ctl);
            }

            //Caption
            res.ApplyResources(ctlObj, "$this");
        }

        private void ApplyChildResource(ref ComponentResourceManager res, Control ctl)
        {
            if (!ctl.HasChildren) return;
            if (ctl is DataGridView)
            {
                foreach (DataGridViewColumn item in (ctl as DataGridView).Columns)
                {
                    res.ApplyResources(item, item.Name);
                }
            }
            else
            {
                foreach (Control c in ctl.Controls)
                {
                    res.ApplyResources(c, c.Name);
                    if ((c is Panel) || (c is GroupBox) || (c is TableLayoutPanel) || (c is TabControl))
                    {
                        if (c.HasChildren)
                            ApplyChildResource(ref res, c);
                    }
                    else if (c is DataGridView)
                    {
                        ApplyChildResource(ref res, c);
                    }
                }
            }
        }
    }
}
