using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Serialization;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Controls
{
    internal class NativeHelper
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);


        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, [MarshalAs(UnmanagedType.LPTStr)]string lpszClass, [MarshalAs(UnmanagedType.LPTStr)]string lpszWindow);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int GetWindowLong(IntPtr hWnd, int dwStyle);

        [DllImport("user32")]
        public extern static IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32")]
        public extern static int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32")]
        public extern static int GetClientRect(IntPtr hwnd, ref Rectangle rc);

        [DllImport("user32")]
        public extern static int GetWindowRect(IntPtr hwnd, ref Rectangle rc);

        public const int EC_LEFTMARGIN = 0x1;
        public const int EC_RIGHTMARGIN = 0x2;
        public const int EC_USEFONTINFO = 0xFFFF;
        public const int EM_SETMARGINS = 0xD3;
        public const int EM_GETMARGINS = 0xD4;

        public const int WM_PAINT = 0xF;

        public const int WM_SETFOCUS = 0x7;
        public const int WM_KILLFOCUS = 0x8;

        public const int WM_SETFONT = 0x30;

        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_MBUTTONUP = 0x208;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_MBUTTONDBLCLK = 0x209;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;

        public const int GWL_EXSTYLE = (-20);
        public const int WS_EX_RIGHT = 0x00001000;
        public const int WS_EX_LEFT = 0x00000000;
        public const int WS_EX_RTLREADING = 0x00002000;
        public const int WS_EX_LTRREADING = 0x00000000;
        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
    }

    internal class ValidatingRegexs : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { 
                "",
                @"^[1-9]\d{0,7}(\.\d{1,2})?$|^0\.[1-9]\d?$|^0\.0[1-9]$",
                @"^[0-9]*$",
                @"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$",
                @"^[0-9()\-]+$",
                @"^[a-zA-Z0-9]+$",
                @"(?=^[0-9a-zA-Z]{8,20}$)(?=.*[0-9])(?=.*[a-zA-Z]).*$",
                @"(?!^[-]?[0]*(\.0{1,4})?$)^[-]?(([1-9]\d*)|0)(\.\d{1,4})?$",
            });
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    [Serializable]
    public class RegexValidationItem
    {
        private string _Regex;
        [XmlElement("Regex")]
        public XmlNode Regex
        {
            get { return new XmlDocument().CreateCDataSection(this._Regex); }
            set { this._Regex = value.Value; }
        }
        [XmlIgnore]
        public string RegexValue { get { return _Regex; } set { _Regex = value; } }
        public string MessageZhcn { get; set; }
        public string MessageEnus { get; set; }

        public override string ToString()
        {
            return this.Regex + "\t" + this.MessageZhcn + "\t" + this.MessageEnus;
        }
    }


    [Serializable]
    public class RegexValidationItems
    {
        [XmlElement("RegexValidationItem")]
        public List<RegexValidationItem> Items { get; set; }

        public RegexValidationItems()
        {
            this.Items = new List<RegexValidationItem>();
        }
    }


    public class DialogEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var md = new ValidationControlRegexEditor();
            var oldRule = (EditorValidateRule)value;
            if (oldRule != null)
                md.LoadInitData(oldRule);
            if (md.ShowDialog() == DialogResult.OK)
                value = ValidationControlRegexEditor.Result;
            return value;
        }
    }


    public class ComboBoxCanValidate : ComboBox, IRegValidator
    {
        public bool ValidPassed { get { return EditorCustomizer.ValidateEditor(this, this.Text); } }

        private EditorValidateRule _validateRule;
        [Browsable(true)]
        [Editor(typeof(DialogEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public EditorValidateRule ValidateRule
        {
            get { return _validateRule; }
            set
            {
                _validateRule = value;
                _validateRule.OnRequiredChanged += delegate() { this.ShowRequiredFlag = (ValidateRule.Required && this.ValidateEnabled); this.Refresh(); };
                this.Refresh();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateAttach();
        }

        private bool _validateEnabled;
        public bool ValidateEnabled
        {
            get { return _validateEnabled; }
            set
            {
                if (_validateEnabled != value)
                {
                    _validateEnabled = value;
                    this.ShowRequiredFlag = (ValidateRule.Required && this.ValidateEnabled);
                    this.Refresh();
                }
            }
        }

        public ErrorProvider ErrorProvider { get; set; }

        public string TranslateValidationMessage()
        {
            return EditorCustomizer.TranslateValidationMessage(this);
        }

        public bool EditorValueChanged { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowRequiredFlag { get; private set; }

        private readonly EditorCustomizer _customizer = new EditorCustomizer();
        public EditorCustomizer EditorCustomizer
        {
            get { return _customizer; }
        }

        public void UpdateAttach()
        {
            _customizer.Attach(this);
        }

        public ComboBoxCanValidate()
        {
            this.ValidateRule = new EditorValidateRule();
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.DrawBackground();

            //var prequesit = (e.State | DrawItemState.ComboBoxEdit) == e.State; ;

            //if (prequesit)
            //{
            //    var inflatedRect1 = e.Bounds;
            //    inflatedRect1.Offset(EditorCustomizer.RequireFlagLabelSize.Width + 2, 0);
            //    inflatedRect1.Width -= EditorCustomizer.RequireFlagLabelSize.Width + 3;
            //    inflatedRect1.Height -= 1;
            //    using (var linearBrush = new LinearGradientBrush(inflatedRect1, SystemColors.ControlLightLight, SystemColors.ControlLight, 90))
            //    {
            //        e.Graphics.FillRectangle(linearBrush, inflatedRect1);
            //    }
            //    e.Graphics.DrawRectangle(SystemPens.ControlLight, inflatedRect1);
            //}

            if (e.Index > -1)
            {
                using (var backgroundBrush = new SolidBrush(SystemColors.Highlight))
                {
                    using (var textBrush = new SolidBrush(this.ForeColor))
                    {
                        var textBound = e.Bounds;
                        //textBound.Y += 2;
                        //textBound.X += 12;
                        //textBound.Width -= 12;
                        if ((e.State & DrawItemState.HotLight) == DrawItemState.HotLight || (e.State & DrawItemState.Selected) == DrawItemState.Selected)
                            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                        e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, textBrush, textBound);
                    }
                }
            }

            //if (prequesit && !EditorCustomizer.RequireFlagLabelSize.IsEmpty)
            //{
            //    var rcClient = new Rectangle();
            //    NativeHelper.GetClientRect(this.Handle, ref rcClient);
            //    var rightToLeft = EditorCustomizer.IsRightToLeft(this.Handle);

            //    var itemSize = EditorCustomizer.RequireFlagLabelSize.Height;
            //    var pt = new Point(0, rcClient.Top + (rcClient.Bottom - rcClient.Top - itemSize) / 2);
            //    if (rightToLeft)
            //        pt.X = rcClient.Right - itemSize - 2;
            //    else
            //        pt.X = 3;
            //    var flagRect = new Rectangle(pt.X, pt.Y + 4, EditorCustomizer.RequireFlagLabelSize.Width, EditorCustomizer.RequireFlagLabelSize.Height - 8);
            //    if (this.ShowRequiredFlag)
            //        e.Graphics.DrawImage(Properties.Resources.star1, flagRect.Left + 1, flagRect.Top + 1, flagRect.Width - 1, flagRect.Height - 1);
            //    else
            //        e.Graphics.DrawRectangle(SystemPens.Control, flagRect);
            //}
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            EditorCustomizer.ValidateEditor(this, this.Text);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.EditorValueChanged = true;
            if (isBackSpace) isBackSpace = false;
            else
            {
                //if (flagMatchStr && this.Text.Trim().Length >= 2)
                //    Matchstr();
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.EditorValueChanged = true;
        }

        bool isBackSpace = false;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if ((int)e.KeyChar == 0x08) isBackSpace = true;
            var xAlt = ((int)e.KeyChar & (int)Keys.Alt) == (int)Keys.Alt;
            var xControl = ((int)e.KeyChar & (int)Keys.Control) == (int)Keys.Control;
            var xShift = ((int)e.KeyChar & (int)Keys.Shift) == (int)Keys.Shift;
            var xReturn = (!(((int)e.KeyChar >= 0x61 && (int)e.KeyChar <= 0x7A) || ((int)e.KeyChar >= 0x41 && (int)e.KeyChar <= 0x5A))) && (((xAlt || xControl || xShift) && ((int)e.KeyChar & (int)Keys.Return) == (int)Keys.Return) || (!xAlt && !xControl && !xShift && (int)e.KeyChar == (int)Keys.Return));

            if (!xAlt && !xControl && xReturn && this.CanFocus)
            {
                if (!xShift)
                    base.ProcessDialogKey(Keys.Tab);
                else
                    base.ProcessDialogKey(Keys.Shift | Keys.Tab);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (flagMatchStr)
            {
                if (lbox.Visible && !lbox.ContainsFocus)
                {
                    lbox.Visible = false;
                }
            }
        }

        private ListBox lbox = new ListBox();

        bool flagMatchStr = false;

        [Browsable(true)]
        public bool MatchStrFlag
        {
            get { return flagMatchStr; }
            set { flagMatchStr = value; }
        }

        bool flag = false;

        void Matchstr()
        {
            if (Items.Count > 0)
            {
                if (this.Parent != null)
                {
                    string matchstr = this.Text.Trim();
                    List<object> list = new List<object>();
                    foreach (var item in Items)
                    {
                        list.Add(item);
                    }
                    if (string.IsNullOrEmpty(matchstr) || list.FindIndex(o => o.ToString().Equals(matchstr)) == 0)
                    {
                        lbox.SendToBack();
                        lbox.Visible = false;
                        return;
                    }
                    if (!flag)
                    {
                        this.TopLevelControl.Controls.Add(lbox);
                        this.Parent.MouseClick += new MouseEventHandler(Parent_MouseClick);
                        lbox.SelectedIndexChanged += new EventHandler(lbox_SelectedIndexChanged);
                        lbox.MouseClick += new MouseEventHandler(lbox_MouseClick);
                        lbox.Width = this.Width;
                        flag = true;
                    }
                    lbox.BringToFront();
                    lbox.Items.Clear();
                    lbox.Visible = true;
                    lbox.Items.AddRange(list.FindAll(o => o.ToString().Contains(matchstr)).ToArray());
                    Point p = this.PointToClient(this.Location);
                    lbox.Location = new Point { X = Math.Abs(p.X) + this.Location.X, Y = Math.Abs(p.Y) + this.Location.Y };
                    if (lbox.Items.Count == 0)
                    {
                        lbox.SendToBack();
                        lbox.Visible = false;
                    }
                    //else if (lbox.Items.Count == 1)
                    //{ lbox.SelectedIndex = 0; }
                }
            }
        }

        void lbox_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            Rectangle rect = this.lbox.RectangleToScreen(this.lbox.ClientRectangle);
            if (!(p.X >= rect.Left && p.X <= rect.Left + rect.Width) || !(p.Y >= rect.Top && p.Y <= rect.Top + rect.Height))
                lbox.Visible = false;
        }

        void lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbox.SelectedIndex >= 0)
            {
                string matchstr = this.Text.Trim();
                object obj = lbox.SelectedItem;
                int index = lbox.SelectedIndex;
                lbox.Visible = false;
                this.Text = obj.ToString();
                int tempindex = 0;
                int m_index = 0;
                foreach (var item in Items)
                {
                    if (item.ToString().Contains(matchstr))
                    {
                        if (item.ToString().Equals(obj.ToString()))
                        {
                            if (tempindex.Equals(index)) break;
                        }
                        tempindex++;
                    }
                    m_index++;
                }
                if (m_index == Items.Count) m_index = -1;
                this.Text = m_index == -1 ? string.Empty : Items[m_index].ToString();

                if (m_index == -1) this.Text = obj.ToString();
                lbox.Visible = false;
            }
        }

        void Parent_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            Rectangle rect = this.RectangleToScreen(this.ClientRectangle);
            if (!(p.X >= rect.Left && p.X <= rect.Left + rect.Width) || !(p.Y >= rect.Top && p.Y <= rect.Top + rect.Height))
            {
                rect = this.lbox.RectangleToScreen(this.lbox.ClientRectangle);
                if (!(p.X >= rect.Left && p.X <= rect.Left + rect.Width) || !(p.Y >= rect.Top && p.Y <= rect.Top + rect.Height))
                    lbox.Visible = false;
            }
        }
    }


    public class TextBoxCanValidate : TextBox, IRegValidator
    {
        public bool ValidPassed { get { return EditorCustomizer.ValidateEditor(this, this.Text); } }

        private EditorValidateRule _validateRule;
        [Browsable(true)]
        [Editor(typeof(DialogEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public EditorValidateRule ValidateRule
        {
            get { return _validateRule; }
            set
            {
                _validateRule = value;
                _validateRule.OnRequiredChanged += delegate() { this.ShowRequiredFlag = (ValidateRule.Required && this.ValidateEnabled); this.Refresh(); };
                this.Refresh();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.UpdateAttach();
        }

        private bool _validateEnabled;
        public bool ValidateEnabled
        {
            get { return _validateEnabled; }
            set
            {
                _validateEnabled = value;
                this.Refresh();
            }
        }

        public ErrorProvider ErrorProvider { get; set; }

        public string TranslateValidationMessage()
        {
            return EditorCustomizer.TranslateValidationMessage(this);
        }

        public bool EditorValueChanged { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowRequiredFlag { get; private set; }

        private readonly EditorCustomizer _customizer = new EditorCustomizer();

        public void UpdateAttach()
        {
            _customizer.Attach(this);
        }

        public TextBoxCanValidate()
        {
            this.ValidateRule = new EditorValidateRule();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            EditorCustomizer.ValidateEditor(this, this.Text);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.EditorValueChanged = true;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            var xAlt = ((int)e.KeyChar & (int)Keys.Alt) == (int)Keys.Alt;
            var xControl = ((int)e.KeyChar & (int)Keys.Control) == (int)Keys.Control;
            var xShift = ((int)e.KeyChar & (int)Keys.Shift) == (int)Keys.Shift;
            var xReturn = (!(((int)e.KeyChar >= 0x61 && (int)e.KeyChar <= 0x7A) || ((int)e.KeyChar >= 0x41 && (int)e.KeyChar <= 0x5A))) && (((xAlt || xControl || xShift) && ((int)e.KeyChar & (int)Keys.Return) == (int)Keys.Return) || ((int)e.KeyChar == (int)Keys.Return));

            if (!xAlt && !xControl && xReturn && this.CanFocus)
            {
                if (!xShift)
                    base.ProcessDialogKey(Keys.Tab);
                else
                    base.ProcessDialogKey(Keys.Shift | Keys.Tab);
            }
        }
    }


    public class EditorCustomizer : NativeWindow
    {
        public static Size RequireFlagLabelSize { get { return new Size(0, 21); } }

        public static string TranslateValidationMessage(IRegValidator validator)
        {
            if (validator.ValidateRule != null)
            {
                var found = ConsistDefine.PreDefinedValidationItems().Find(item => item.RegexValue == validator.ValidateRule.RegexValue);
                if (ConsistDefine.Language == UILang.CHS)
                    return found.MessageZhcn;
                else if (ConsistDefine.Language == UILang.EN)
                    return found.MessageEnus;
            }
            return string.Empty;
        }

        public static bool ValidateEditor(IRegValidator validator, string editorText)
        {
            if (validator.ValidateEnabled && validator.ValidateRule != null && !string.IsNullOrEmpty(validator.ValidateRule.RegexValue))
            {
                var regex = new Regex(validator.ValidateRule.RegexValue);
                var textLength = editorText.Length;
                var valid = regex.IsMatch(editorText) && ((!string.IsNullOrEmpty(editorText) && validator.ValidateRule.Required) || (textLength >= validator.ValidateRule.MinLength) && (textLength <= validator.ValidateRule.MaxLength));
                if (validator.ErrorProvider != null)
                {
                    if (!valid)
                    {
                        var promptMessage = TranslateValidationMessage(validator);
                        if (validator.ValidateRule.Required)
                            promptMessage += "\r\n" + "Length should between " + validator.ValidateRule.MinLength + " and " + validator.ValidateRule.MaxLength;
                        validator.ErrorProvider.SetError(validator as Control, promptMessage);
                        return false;
                    }
                    validator.ErrorProvider.Clear();
                    return true;
                }
            }
            return true;
        }


        public static bool IsRightToLeft(IntPtr handle)
        {
            int style = NativeHelper.GetWindowLong(handle, NativeHelper.GWL_EXSTYLE);
            return (
                ((style & NativeHelper.WS_EX_RIGHT) == NativeHelper.WS_EX_RIGHT) ||
                ((style & NativeHelper.WS_EX_RTLREADING) == NativeHelper.WS_EX_RTLREADING) ||
                ((style & NativeHelper.WS_EX_LEFTSCROLLBAR) == NativeHelper.WS_EX_LEFTSCROLLBAR));
        }

        public static int FarMargin(Control ctl)
        {
            var handle = ctl.Handle;
            if (ctl is ComboBox)
                handle = ComboEdithWnd(handle);
            return FarMargin(handle);
        }

        public static int FarMargin(IntPtr handle)
        {
            int farMargin = NativeHelper.SendMessage(handle, NativeHelper.EM_GETMARGINS, 0, 0);
            if (IsRightToLeft(handle))
                farMargin = farMargin & 0xFFFF;
            else
                farMargin = (farMargin / 0x10000);
            return farMargin;
        }


        public static void FarMargin(Control ctl, int margin)
        {
            var handle = ctl.Handle;
            if (ctl is ComboBox)
                handle = ComboEdithWnd(handle);
            FarMargin(handle, margin);
        }

        private static void FarMargin(IntPtr handle, int margin)
        {
            int message = IsRightToLeft(handle) ? NativeHelper.EC_LEFTMARGIN : NativeHelper.EC_RIGHTMARGIN;
            if (message == NativeHelper.EC_LEFTMARGIN)
                margin = margin & 0xFFFF;
            else
                margin = margin * 0x10000;
            NativeHelper.SendMessage(handle, NativeHelper.EM_SETMARGINS, message, margin);
        }

        public static int NearMargin(Control ctl)
        {
            var handle = ctl.Handle;
            if (ctl is ComboBox)
                handle = ComboEdithWnd(handle);
            return NearMargin(handle);
        }

        private static int NearMargin(IntPtr handle)
        {
            var nearMargin = NativeHelper.SendMessage(handle, NativeHelper.EM_GETMARGINS, 0, 0);
            if (IsRightToLeft(handle))
                nearMargin = nearMargin / 0x10000;
            else
                nearMargin = nearMargin & 0xFFFF;
            return nearMargin;
        }

        public static void NearMargin(Control ctl, int margin)
        {
            var handle = ctl.Handle;
            if (ctl is ComboBox)
                handle = ComboEdithWnd(handle);
            NearMargin(handle, margin);
        }

        private static void NearMargin(IntPtr handle, int margin)
        {
            int message = IsRightToLeft(handle) ? NativeHelper.EC_RIGHTMARGIN : NativeHelper.EC_LEFTMARGIN;
            if (message == NativeHelper.EC_LEFTMARGIN)
                margin = margin & 0xFFFF;
            else
                margin = margin * 0x10000;
            NativeHelper.SendMessage(handle, NativeHelper.EM_SETMARGINS, message, margin);
        }

        public static IntPtr ComboEdithWnd(IntPtr handle)
        {
            handle = NativeHelper.FindWindowEx(handle, IntPtr.Zero, "EDIT", "\0");
            return handle;
        }

        public void Attach(ComboBox comboBox)
        {
            this.HostEditor = comboBox as IRegValidator;
            if (!this.Handle.Equals(IntPtr.Zero))
                this.ReleaseHandle();
            var handle = ComboEdithWnd(comboBox.Handle);
            this.AssignHandle(handle);
            SetMargin();
        }

        public void Attach(TextBox textBox)
        {
            this.HostEditor = textBox as IRegValidator;
            if (!this.Handle.Equals(IntPtr.Zero))
                this.ReleaseHandle();
            this.AssignHandle(textBox.Handle);
            SetMargin();
        }

        public IRegValidator HostEditor { get; private set; }


        private void SetMargin()
        {
            if (!this.Handle.Equals(IntPtr.Zero))
            {
                if (!RequireFlagLabelSize.IsEmpty)
                    NearMargin(this.Handle, RequireFlagLabelSize.Width);// + 4);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case NativeHelper.WM_SETFONT:
                    SetMargin();
                    break;
                case NativeHelper.WM_PAINT:
                    RePaint();
                    break;
                case NativeHelper.WM_SETFOCUS:
                case NativeHelper.WM_KILLFOCUS:
                    RePaint();
                    break;
                case NativeHelper.WM_LBUTTONDOWN:
                case NativeHelper.WM_RBUTTONDOWN:
                case NativeHelper.WM_MBUTTONDOWN:
                    RePaint();
                    break;
                case NativeHelper.WM_LBUTTONUP:
                case NativeHelper.WM_RBUTTONUP:
                case NativeHelper.WM_MBUTTONUP:
                    RePaint();
                    break;
                case NativeHelper.WM_LBUTTONDBLCLK:
                case NativeHelper.WM_RBUTTONDBLCLK:
                case NativeHelper.WM_MBUTTONDBLCLK:
                    RePaint();
                    break;
                case NativeHelper.WM_KEYDOWN:
                case NativeHelper.WM_CHAR:
                case NativeHelper.WM_KEYUP:
                    RePaint();
                    break;
                case NativeHelper.WM_MOUSEMOVE:
                    if (!m.WParam.Equals(IntPtr.Zero))
                        RePaint();
                    break;
            }
        }

        private void RePaint()
        {
            if (!RequireFlagLabelSize.IsEmpty)
            {
                var rcClient = new Rectangle();
                NativeHelper.GetClientRect(this.Handle, ref rcClient);
                var rightToLeft = IsRightToLeft(this.Handle);

                var handle = this.Handle;
                var hdc = NativeHelper.GetDC(handle);
                var gfx = Graphics.FromHdc(hdc);

                int itemSize = RequireFlagLabelSize.Height;
                var pt = new Point(0, rcClient.Top + (rcClient.Bottom - rcClient.Top - itemSize) / 2);
                if (rightToLeft)
                    pt.X = rcClient.Right - itemSize - 2;
                else
                    pt.X = 0;
                var flagRect = new Rectangle(pt.X, pt.Y + 3, RequireFlagLabelSize.Width, RequireFlagLabelSize.Height - 8);
                gfx.DrawRectangle(SystemPens.Control, flagRect);
                if (this.HostEditor != null && this.HostEditor.ShowRequiredFlag)
                    gfx.DrawImage(Properties.Resources.star1, flagRect.Left + 1, flagRect.Top + 1, flagRect.Width - 1, flagRect.Height - 1);

                gfx.Dispose();
                NativeHelper.ReleaseDC(handle, hdc);
            }
        }
    }
}
