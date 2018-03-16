using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CommonClient.Types;

namespace CommonClient.Controls
{
    [ProvideProperty("DvLangId", typeof(Control))]
    [ProvideProperty("DvLangText", typeof(Control))]
    public partial class LanguageList : Component, IExtenderProvider
    {

        public LanguageList()
        {
            LangCode = LangCode.C;
            InitializeComponent();
            this.PopulateLanguages();
        }

        public LanguageList(IContainer container)
        {
            LangCode = LangCode.C;
            container.Add(this);
            InitializeComponent();
            this.PopulateLanguages();
        }

        internal static readonly List<TranslatingKeyAttribute> LangList = new List<TranslatingKeyAttribute>();

        private void PopulateLanguages()
        {
            LangList.Clear();
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a101", C = "是", E = "Yes", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a102", C = "否", E = "No", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a103", C = "取消", E = "Cancel", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a104", C = "确定", E = "Ok", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a105", C = "重试", E = "Retry", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a106", C = "忽略", E = "Ignore", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
            LangList.Add(new TranslatingKeyAttribute { LanKey = "a107", C = "终止", E = "Abort", J = "", K = "", R = "", F = "", D = "", T = "", P = "" });
        }

        [DefaultValue(typeof(LangCode), "C")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public static LangCode LangCode { get; set; }

        private static readonly Hashtable ControlItems = new Hashtable();

        [Browsable(true)]
        [Editor(typeof(LanguageKeyEditorRegister), typeof(UITypeEditor))]
        public string GetDvLangId(Control control)
        {
            var result = ControlItems[control] as string;
            return result;
        }

        [Browsable(true)]
        [Editor(typeof(LanguageKeyEditorRegister), typeof(UITypeEditor))]
        public void SetDvLangId(Control control, string langId)
        {
            this.EnsureControlItem(control, langId);
        }

        [Browsable(true)]
        public string GetDvLangText(Control control)
        {
            var langKey = GetLangKey(control);
            var foundItem = LangList.Find(item => string.Equals(langKey, item.LanKey, StringComparison.CurrentCultureIgnoreCase));
            if (foundItem == null)
                return string.Empty;

            switch (LangCode)
            {
                case LangCode.C:
                    return foundItem.C;
                case LangCode.E:
                    return foundItem.E;
                case LangCode.J:
                    return foundItem.J;
                case LangCode.K:
                    return foundItem.K;
                case LangCode.R:
                    return foundItem.R;
                case LangCode.F:
                    return foundItem.F;
                case LangCode.D:
                    return foundItem.D;
                case LangCode.T:
                    return foundItem.T;
                case LangCode.P:
                    return foundItem.P;
            }
            return "*-*-*";
        }

        public static string GetLangText(string langId, string langCode)
        {
            var foundItem = LangList.Find(item => string.Equals(langId, item.LanKey, StringComparison.CurrentCultureIgnoreCase));
            if (foundItem == null)
                return string.Empty;
            return foundItem.GetText(langCode);
        }

        public static string GetLangText(string langId)
        {
            var foundItem = LangList.Find(item => string.Equals(langId, item.LanKey, StringComparison.CurrentCultureIgnoreCase));
            if (foundItem == null)
                return string.Empty;
            return foundItem.GetText(LangCode.ToString());
        }

        public static string GetLangKey(Control control)
        {
            if (control == null)
                throw new ArgumentNullException("control is emtpy");
            var result = ControlItems[control] as string;
            return result;
        }

        private void EnsureControlItem(Control control, string langId)
        {
            if (control == null)
                throw new ArgumentNullException("control is emtpy");
            (ControlItems[control]) = langId;
        }

        public void UpdateTranslations()
        {
            foreach (DictionaryEntry dictionaryEntry in ControlItems)
            {
                var hostControl = dictionaryEntry.Key as Control;
                var langId = dictionaryEntry.Value as string;
                var keyAttribute = LangList.Find(item => string.Equals(item.LanKey, langId, StringComparison.CurrentCultureIgnoreCase));
                if (keyAttribute != null)
                    hostControl.Text = this.GetDvLangText(hostControl);
            }
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is Form || extendee is Label || extendee is RadioButton || extendee is CheckBox
                || extendee is Button || extendee is GroupBox || extendee is TabPage || extendee is MenuItem
                || extendee is ToolStripMenuItem);
        }
    }

    [Flags]
    public enum LangCode
    {
        C = 1,
        E = 2,
        J = 3,
        K = 4,
        R = 5,
        F = 6,
        D = 7,
        T = 8,
        P = 9
    }

    internal class LanguageKeyEditorRegister : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object currentIndex)
        {
            var editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (editorService != null)
            {
                var hostControl = context.Instance as Control;
                var editorWindow = new LanguageListEditor(editorService, context.Instance as Control);

                var langKey = LanguageList.GetLangKey(hostControl);
                var langText = hostControl.Text.Trim();

                if (!string.IsNullOrEmpty(langKey))
                    editorWindow.FindAndSelectItemByLangKey(langKey);
                else
                    editorWindow.FindAndSelectItemByCnText(langText);
                if (editorService.ShowDialog(editorWindow) == DialogResult.OK)
                    return editorWindow.SelectedLanId;
                return currentIndex;
            }
            return string.Empty;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            base.PaintValue(e);
            //using (Pen p = Pens.Black)
            //{
            //    e.Graphics.DrawEllipse(p, e.Bounds);
            //}
        }
    }

}
