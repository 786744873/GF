using System.Windows.Forms;
using CommonClient.Controls;
using System.ComponentModel;
using CommonClient.EnumTypes;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using CommonClient.Utilities;
using CommonClient.Entities;

namespace CommonClient.VisualParts
{
    public partial class BaseUc : UserControl
    {
        private object _lockObject = new object();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case NativeHelper.WM_CTLCOLOREDIT:
                    break;
            }
        }

        public BaseUc()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles();
            this.errorProvider1.Clear();
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

        public virtual void ChangeLanguage(LangCode langCode)
        {
            LanguageList.LangCode = langCode;
            this.languageList1.UpdateTranslations();
        }

        public static string GetNameValueObjectNameFromValue(List<NameValueObject> list, int id)
        {
            if (id > -1 && id < list.Count)
                return list[id].Name;
            else
                return string.Empty;
        }

        // 检查模块是否其内部editor的值被改变过
        public bool CheckChanged()
        {
            foreach (Control control in this.Controls)
            {
                var realControl = (IDataValidateEditor)control;
                if (realControl != null)
                {
                    if (realControl.DvEditorValueChanged)
                        return true;
                }
            }
            return false;
        }

        // 检查模块其内部editor值是否合法
        public virtual bool CheckValid()
        {
            this.errorProvider1.Clear();
            var validThrough = true;

            var allEditorsAndRadioChecks = new List<IDataValidateControl>();
            allEditorsAndRadioChecks.AddRange(this.DataValidatorEditors);
            allEditorsAndRadioChecks.AddRange(this.DataValidatorButtons);
            allEditorsAndRadioChecks.Sort(new TabIndexComparer());

            // 不区分各种TextBoxCanValidate、ComboBoxCanValidate、RadioButtonCanValidate和CheckBoxCanValidate，按照他们的TabOrder做统一校验；
            foreach (IDataValidateControl controlItem in allEditorsAndRadioChecks)
            {
                if (controlItem is TextBoxCanValidate)
                {
                    var editor = controlItem as TextBoxCanValidate;
                    validThrough = EditorCustomizer.ValidateEditor(editor, editor.DvDataValue as string) && validThrough;
                }
                else if (controlItem is ComboBoxCanValidate)
                {
                    var editor = controlItem as ComboBoxCanValidate;
                    if (editor.DvRequired)
                    {
                        var comboBoxEditor = editor as ComboBox;
                        switch (comboBoxEditor.DropDownStyle)
                        {
                            case ComboBoxStyle.Simple:
                                validThrough = EditorCustomizer.ValidateEditor(editor, editor.DvDataValue as string) && validThrough;
                                break;
                            case ComboBoxStyle.DropDown:
                                validThrough = EditorCustomizer.ValidateEditor(editor, editor.DvDataValue as string) && validThrough;
                                break;
                            case ComboBoxStyle.DropDownList:
                                //当检查项为下拉列表框时，如果必选项没有选择 将提示错误信息 2014年8月8日14:29:08 陈永俊
                                if (comboBoxEditor.SelectedIndex < 0)
                                {
                                    string promptMessage = "请选择";
                                    promptMessage += "" + (editor.DvLinkedLabel == null ? string.Empty : editor.DvLinkedLabel.Text.Substring(0, editor.DvLinkedLabel.Text.Length - 1)) + "";
                                    editor.DvErrorProvider.SetError(editor as Control, promptMessage);
                                }
                                validThrough = (comboBoxEditor.SelectedIndex > -1) && validThrough;
                                break;
                        }
                    }
                    else
                    {
                        validThrough = EditorCustomizer.ValidateEditor(editor, editor.DvDataValue as string) && validThrough;
                    }
                }
                else if (controlItem is IDataValidateButton)
                {
                    var button = controlItem as IDataValidateButton;
                    validThrough = EditorCustomizer.ValidateEditor(button) && validThrough;
                }
            }
            return validThrough;
        }

        private List<IDataValidateControl> _dataValidatorEditors;
        [Browsable(false)]
        public List<IDataValidateControl> DataValidatorEditors
        {
            get
            {
                if (_dataValidatorEditors == null)
                    _dataValidatorEditors = new List<IDataValidateControl>();
                if (_dataValidatorEditors.Count == 0)
                {
                    FindDataValidateEditors(this);
                    _dataValidatorEditors.Sort(new TabIndexComparer());
                }
                return _dataValidatorEditors;
            }
        }

        private void FindDataValidateEditors(Control control)
        {
            if (control is IDataValidateEditor)
                _dataValidatorEditors.Add(control as IDataValidateEditor);
            else
            {
                if (control.HasChildren)
                {
                    foreach (Control aControl in control.Controls)
                    {
                        FindDataValidateEditors(aControl);
                    }
                }
            }
        }

        private List<IDataValidateControl> _dataValidatorButtons;
        [Browsable(false)]
        public List<IDataValidateControl> DataValidatorButtons
        {
            get
            {
                if (_dataValidatorButtons == null)
                    _dataValidatorButtons = new List<IDataValidateControl>();
                if (_dataValidatorButtons.Count == 0)
                {
                    FindDataValidateButtons(this);
                    _dataValidatorButtons.Sort(new TabIndexComparer());
                }
                return _dataValidatorButtons;
            }
        }

        private void FindDataValidateButtons(Control control)
        {
            if (control is IDataValidateButton)
                _dataValidatorButtons.Add(control as IDataValidateButton);
            else
            {
                if (control.HasChildren)
                {
                    foreach (Control aControl in control.Controls)
                    {
                        FindDataValidateButtons(aControl);
                    }
                }
            }
        }

        // 通过给定的实体类型和实体实例，从窗体控件（...CanValidate..)上取值并设置给对应的实体属性
        public void GetEntityObjectFromUI(Type type, object entityObject)
        {
            lock (_lockObject)
            {
                var fields = type.GetProperties();
                foreach (PropertyInfo fieldInfo in fields)
                {
                    foreach (IDataValidateEditor editor in this.DataValidatorEditors)
                    {
                        if (string.Equals(fieldInfo.Name, editor.DvDataField, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (fieldInfo.PropertyType.Name.IndexOf("int", StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                int parsedResult = 0;
                                int.TryParse(editor.DvDataValue.ToString(), out parsedResult);
                                fieldInfo.SetValue(entityObject, parsedResult, null);
                            }
                            else
                                fieldInfo.SetValue(entityObject, editor.DvDataValue, null);
                        }
                    }
                    foreach (IDataValidateButton button in this.DataValidatorButtons)
                    {
                        if (string.Equals(fieldInfo.Name, button.DvDataField, StringComparison.CurrentCultureIgnoreCase) && ((button is CheckBox) || (button is RadioButton && button.Checked)))
                        {
                            if (fieldInfo.PropertyType.Name.IndexOf("enum", StringComparison.CurrentCultureIgnoreCase) > -1)
                                fieldInfo.SetValue(entityObject, Enum.ToObject(fieldInfo.PropertyType, button.DvDataValue), null);
                            else if (fieldInfo.PropertyType.Name.IndexOf("bool", StringComparison.CurrentCultureIgnoreCase) > -1)
                                fieldInfo.SetValue(entityObject, button.DvDataValue != 0, null);
                            else if (fieldInfo.PropertyType.Name.IndexOf("int", StringComparison.CurrentCultureIgnoreCase) > -1)
                                fieldInfo.SetValue(entityObject, button.DvDataValue, null);
                        }
                    }
                }

            }
        }

        // 通过给定的实体类型和实体实例，读取其各可能属性的值并设置给窗台控件(...CanValidate...)
        public void SetEntityObjectToUI(Type type, object entityObject)
        {
            lock (_lockObject)
            {
                var fields = type.GetProperties();
                foreach (PropertyInfo fieldInfo in fields)
                {
                    foreach (IDataValidateEditor editor in this.DataValidatorEditors)
                    {
                        if (string.Equals(fieldInfo.Name, editor.DvDataField, StringComparison.CurrentCultureIgnoreCase))
                        {
                            var xValue = fieldInfo.GetValue(entityObject, null);
                            if (xValue != null)
                                editor.DvDataValue = xValue;
                        }
                    }
                    foreach (IDataValidateButton button in this.DataValidatorButtons)
                    {
                        if (string.Equals(fieldInfo.Name, button.DvDataField, StringComparison.CurrentCultureIgnoreCase))
                        {
                            var xValue = fieldInfo.GetValue(entityObject, null);
                            if (xValue != null)
                                button.DvDataValue = (int)xValue;
                        }
                    }
                }
            }
        }

        public void SaveDataValidateEditorsAndDataValidateButtonsInfoToDisk()
        {
            var sb = new List<string>();
            foreach (IDataValidateEditor dataValidatorEditor in this.DataValidatorEditors)
            {
                sb.Add(string.Format("名称： {0}； 字段名： {1}； 字段值：  {2}； 最小长度： {3}； 最大长度： {4}； 必填？： {5}；  正则： {6}； 正则说明： {7}",
                                            dataValidatorEditor.DvLinkedLabel != null ? dataValidatorEditor.DvLinkedLabel.Text : (dataValidatorEditor as Control).Name,
                                            dataValidatorEditor.DvDataField,
                                            dataValidatorEditor.DvDataValue,
                                            dataValidatorEditor.DvMinLength,
                                            dataValidatorEditor.DvMaxLength,
                                            dataValidatorEditor.DvRequired,
                                            dataValidatorEditor.DvRegValue,
                                            dataValidatorEditor.DvRegDescription));
            }
            foreach (IDataValidateButton dataValidatorButton in this.DataValidatorButtons)
            {
                sb.Add(string.Format("名称： {0}； 字段名： {1}； 字段值：  {2}",
                                            dataValidatorButton.DvLinkedLabel != null ? dataValidatorButton.DvLinkedLabel.Text : (dataValidatorButton as Control).Name,
                                            dataValidatorButton.DvDataField,
                                            dataValidatorButton.DvDataValue));
            }
            File.WriteAllLines(@"c:\_editorcanvalidate_list" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt", sb.ToArray(), Encoding.UTF8);
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

    public class TabIndexComparer : IComparer<IDataValidateControl>
    {
        public int Compare(IDataValidateControl x, IDataValidateControl y)
        {
            return x.TabIndex.CompareTo(y.TabIndex);
        }
    }
}
