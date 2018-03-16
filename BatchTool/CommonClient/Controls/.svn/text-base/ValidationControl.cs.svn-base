using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.Design;
using CommonClient.Properties;
using CommonClient.Utilities;
using System.Drawing.Drawing2D;

namespace CommonClient.Controls
{
    public class ComboBoxCanValidate : ComboBox, IDataValidateEditor
    {
        public ComboBoxCanValidate()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.MeasureItem += new MeasureItemEventHandler(ComboBoxCanValidate_MeasureItem);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            this.DvUpdateAttach();
            this.Leave += new EventHandler(ComboBoxCanValidate_Leave);
        }

        void ComboBoxCanValidate_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index > -1)
            {
                SizeF textSizeF = e.Graphics.MeasureString(this.Items[e.Index].ToString(), this.Font, (int)e.Graphics.VisibleClipBounds.Width - EditorCustomizer.RequireFlagLabelSize.Width - 3);
                if (textSizeF.Height > e.ItemHeight) e.ItemHeight = (int)textSizeF.Height;
            }
        }

        void ComboBoxCanValidate_Leave(object sender, EventArgs e)
        {
            ManualValidate();
        }

        [Browsable(false)]
        public bool DvValidatePassed { get { return EditorCustomizer.ValidateEditor(this, this.Text); } }

        private RequiredFlagStyle _dvRequiredFlagStyle;
        public RequiredFlagStyle DvRequiredFlagStyle
        {
            get { return this._dvRequiredFlagStyle; }
            set
            {
                this._dvRequiredFlagStyle = value;
                this.Refresh();
            }
        }

        public Label DvLinkedLabel { get; set; }
        public string DvDataField { get; set; }

        public new bool DesignMode { get { return base.DesignMode; } }

        private Label _requiredLabel = new Label() { ForeColor = Color.Red, Text = "*", Visible = false, Width = 9 };

        private IntPtr InnerEditorHandler
        {
            get
            {
                var result = NativeHelper.FindWindowEx(this.Handle, IntPtr.Zero, string.Empty, string.Empty);
                return result;
            }
        }

        public virtual Point GetPositionFromCharIndex(int index)
        {
            if (index < 0 || index >= this.Text.Length)
            {
                return Point.Empty;
            }
            var num = (int)NativeHelper.SendMessage(InnerEditorHandler, 214, index, 0);
            return new Point(NativeHelper.LOWORD(num), NativeHelper.HIWORD(num));
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public object DvDataValue
        {
            get
            {
                switch (this.DropDownStyle)
                {
                    case ComboBoxStyle.Simple:
                        return this.Text.Trim();
                    case ComboBoxStyle.DropDown:
                        return this.Text.Trim();
                    case ComboBoxStyle.DropDownList:
                        return this.SelectedIndex;
                }
                return string.Empty;
            }
            set
            {
                switch (this.DropDownStyle)
                {
                    case ComboBoxStyle.Simple:
                        this.Text = value.ToString();
                        break;
                    case ComboBoxStyle.DropDown:
                        this.Text = value.ToString();
                        break;
                    case ComboBoxStyle.DropDownList:
                        this.SelectedIndex = -1;
                        var passedInValue = (int)value;
                        if (passedInValue > -1 && passedInValue < this.Items.Count)
                            this.SelectedIndex = passedInValue;
                        break;
                }
            }
        }

        private bool _dvRequired = false;
        public bool DvRequired
        {
            get { return _dvRequired; }
            set
            {
                if (_dvRequired != value)
                {
                    _dvRequired = value;
                    //EditorCustomizer.MakeRequiredLabelReplacement(this, this._requiredLabel, this.DvRequired && this.DvValidateEnabled);
                    this.Refresh();
                }
            }
        }

        public int DvMinLength { get; set; }
        public int DvMaxLength { get; set; }
        private ValidatorList _dvValidator;
        public ValidatorList DvValidator
        {
            get
            {
                return _dvValidator;
            }
            set
            {
                _dvValidator = value;
            }
        }

        [Browsable(true)]
        [Editor(typeof(ValidatorRegexCodeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DvRegCode { get; set; }

        public string DvRegValue
        {
            get
            {
                if (!string.IsNullOrEmpty(DvRegCode) && DvValidator != null)
                {
                    var foundItem = ValidatorList.Validators.Find(item => string.Equals(item.Code, DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                    return foundItem != null ? foundItem.Regex : string.Empty;
                }
                return string.Empty;
            }
        }

        public string DvRegDescription
        {
            get
            {
                if (this.DvValidator != null && !string.IsNullOrEmpty(this.DvRegCode))
                {
                    var foundItem = ValidatorList.Validators.Find(item => string.Equals(item.Code, this.DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                    return foundItem != null ? foundItem.Description : string.Empty;
                }
                return string.Empty;
            }
        }

        private bool _dvValidateEnabled;
        public bool DvValidateEnabled
        {
            get { return _dvValidateEnabled; }
            set
            {
                if (_dvValidateEnabled != value)
                {
                    _dvValidateEnabled = value;
                    //EditorCustomizer.MakeRequiredLabelReplacement(this, this._requiredLabel, this.DvRequired && this.DvValidateEnabled);
                    this.Refresh();
                }
            }
        }

        public ErrorProvider DvErrorProvider { get; set; }

        public string DvTranslateValidationMessage()
        {
            throw new NotImplementedException();
        }

        [Browsable(false)]
        public bool DvEditorValueChanged { get; set; }

        bool _dvFixLength = false;
        [Browsable(true)]
        [Editor(typeof(ValidatorRegexCodeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool DvFixLength { get { return _dvFixLength; } set { _dvFixLength = value; } }

        private readonly EditorCustomizer _customizer = new EditorCustomizer();

        [Browsable(false)]
        public EditorCustomizer EditorCustomizer
        {
            get { return _customizer; }
        }

        public void DvUpdateAttach()
        {
            _customizer.Attach(this);
            //EditorCustomizer.MakeRequiredLabelReplacement(this, this._requiredLabel, this.DvRequired && this.DvValidateEnabled);
        }

        public void DvUpdateErrorFrame()
        { _customizer.UpdateErrorFrame(); }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case NativeHelper.WM_PAINT:
                    this._customizer.DrawRequiredFlag();
                    this._customizer.UpdateErrorFrame();
                    break;
            }
        }

        public bool ManualValidate()
        {
            var result = true;
            switch (this.DropDownStyle)
            {
                case ComboBoxStyle.Simple:
                    result = EditorCustomizer.ValidateEditor(this, this.Text);
                    break;
                case ComboBoxStyle.DropDown:
                    result = EditorCustomizer.ValidateEditor(this, this.Text);
                    break;
                case ComboBoxStyle.DropDownList:
                    result = EditorCustomizer.ValidateComboBox(this);
                    break;
            }
            return result;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.DrawBackground();

            var prequesit = (e.State | DrawItemState.ComboBoxEdit) == e.State; ;

            if (prequesit)
            {
                var inflatedRect1 = e.Bounds;
                //inflatedRect1.Offset(/*EditorCustomizer.RequireFlagLabelSize.Width +*/ 2, 0);
                //inflatedRect1.Width -= /*EditorCustomizer.RequireFlagLabelSize.Width +*/ 3;
                //inflatedRect1.Height -= 1;
                if (e.Index > -1)
                {
                    SizeF textSizeF = e.Graphics.MeasureString(this.Items[e.Index].ToString(), this.Font, inflatedRect1.Width);
                    if (textSizeF.Height > inflatedRect1.Height) inflatedRect1.Height = (int)textSizeF.Height;
                }
                using (var linearBrush = new LinearGradientBrush(inflatedRect1, SystemColors.Control, SystemColors.Control, 90))
                {
                    e.Graphics.FillRectangle(linearBrush, inflatedRect1);
                }
                e.Graphics.DrawRectangle(SystemPens.Control, inflatedRect1);
            }

            if (e.Index > -1)
            {
                using (var backgroundBrush = new SolidBrush(SystemColors.Highlight))
                {
                    using (var textBrush = new SolidBrush(this.ForeColor))
                    {
                        var itembound = e.Bounds;
                        var textBound = e.Bounds;
                        //textBound.Y += 2;
                        //textBound.X += 12;
                        //textBound.Width -= 12;
                        SizeF textSizeF = e.Graphics.MeasureString(this.Items[e.Index].ToString(), this.Font, e.Bounds.Width /*- EditorCustomizer.RequireFlagLabelSize.Width - 3*/);
                        if ((int)textSizeF.Height > textBound.Height) textBound.Height = (int)textSizeF.Height;
                        if ((int)textSizeF.Height > itembound.Height) itembound.Height = (int)textSizeF.Height;
                        if ((e.State & DrawItemState.HotLight) == DrawItemState.HotLight || (e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        {
                            e.Graphics.FillRectangle(backgroundBrush, itembound);
                            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), textBound);
                        }
                        else
                            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, textBrush, textBound);
                    }
                }
            }

            if (prequesit && !EditorCustomizer.RequireFlagLabelSize.IsEmpty)
            {
                //var rcClient = new Rectangle();
                //NativeHelper.GetClientRect(this.Handle, ref rcClient);
                //var rightToLeft = EditorCustomizer.IsRightToLeft(this.Handle);

                //var itemSize = EditorCustomizer.RequireFlagLabelSize.Height;
                //var pt = new Point(0, rcClient.Top + (rcClient.Bottom - rcClient.Top - itemSize) / 2);
                //if (rightToLeft)
                //    pt.X = rcClient.Right - itemSize - 2;
                //else
                //    pt.X = 3;
                //var flagRect = new Rectangle(pt.X, pt.Y + 4, EditorCustomizer.RequireFlagLabelSize.Width, EditorCustomizer.RequireFlagLabelSize.Height - 8);
                //if (this.ShowRequiredFlag)
                //    e.Graphics.DrawImage(Properties.Resources.star1, flagRect.Left + 1, flagRect.Top + 1, flagRect.Width - 1, flagRect.Height - 1);
                //else
                //e.Graphics.DrawRectangle(SystemPens.Control, flagRect);
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            // 2014-05-29 为了适应企业现有校验风格，这里不自动校验，而是使用ManualValidate统一校验
            ManualValidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.DvEditorValueChanged = true;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.DvEditorValueChanged = true;
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


    public class TextBoxCanValidate : TextBox, IDataValidateEditor
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.DvUpdateAttach();
        }

        public bool DvValidatePassed { get { return EditorCustomizer.ValidateEditor(this, this.Text); } }

        private RequiredFlagStyle _dvRequiredFlagStyle;
        public RequiredFlagStyle DvRequiredFlagStyle
        {
            get { return this._dvRequiredFlagStyle; }
            set
            {
                this._dvRequiredFlagStyle = value;
                this.Refresh();
            }
        }

        public Label DvLinkedLabel { get; set; }
        public string DvDataField { get; set; }

        public new bool DesignMode { get { return base.DesignMode; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public object DvDataValue
        {
            get { return this.Text.Trim(); }
            set { this.Text = value != null ? value.ToString() : string.Empty; }
        }

        private Label _requiredLabel = new Label() { ForeColor = Color.Red, Text = "*", Visible = false, Width = 9 };
        private bool _dvRequired;
        public bool DvRequired
        {
            get { return _dvRequired; }
            set
            {
                if (_dvRequired != value)
                {
                    _dvRequired = value;
                    //EditorCustomizer.MakeRequiredLabelReplacement(this, this._requiredLabel, this.DvRequired && this.DvValidateEnabled);
                    this.Refresh();
                }
            }
        }

        public int DvMinLength { get; set; }
        public int DvMaxLength { get; set; }
        public ValidatorList DvValidator { get; set; }

        [Browsable(true)]
        [Editor(typeof(ValidatorRegexCodeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DvRegCode { get; set; }

        public string DvRegValue
        {
            get
            {
                if (!string.IsNullOrEmpty(DvRegCode) && DvValidator != null)
                {
                    var foundItem = ValidatorList.Validators.Find(item => string.Equals(item.Code, DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                    return foundItem != null ? foundItem.Regex : string.Empty;
                }
                return string.Empty;
            }
        }

        public string DvRegDescription
        {
            get
            {
                if (this.DvValidator != null && !string.IsNullOrEmpty(this.DvRegCode))
                {
                    var foundItem = ValidatorList.Validators.Find(item => string.Equals(item.Code, this.DvRegCode, StringComparison.CurrentCultureIgnoreCase));
                    return foundItem != null ? foundItem.Description : string.Empty;
                }
                return string.Empty;
            }
        }

        private bool _dvValidateEnabled;
        public bool DvValidateEnabled
        {
            get { return _dvValidateEnabled; }
            set
            {
                _dvValidateEnabled = value;
                //EditorCustomizer.MakeRequiredLabelReplacement(this, this._requiredLabel, this.DvRequired && this.DvValidateEnabled);
                this.Refresh();
            }
        }

        public ErrorProvider DvErrorProvider { get; set; }
        public string DvTranslateValidationMessage()
        {
            throw new NotImplementedException();
        }

        [Browsable(false)]
        public bool DvEditorValueChanged { get; set; }

        bool _dvFixLength = false;
        [Browsable(true)]
        [Editor(typeof(ValidatorRegexCodeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool DvFixLength { get { return _dvFixLength; } set { _dvFixLength = value; } }

        private readonly EditorCustomizer _customizer = new EditorCustomizer();


        public void DvUpdateAttach()
        {
            _customizer.Attach(this);
            //EditorCustomizer.MakeRequiredLabelReplacement(this, this._requiredLabel, this.DvRequired && this.DvValidateEnabled);
        }

        public void DvUpdateErrorFrame()
        {
            _customizer.UpdateErrorFrame();
            this.Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case NativeHelper.WM_CTLCOLOREDIT:
                case NativeHelper.WM_PAINT:
                    this._customizer.DrawRequiredFlag();
                    this._customizer.UpdateErrorFrame();
                    break;
            }
        }

        public bool ManualValidate()
        {
            var result = EditorCustomizer.ValidateEditor(this, this.Text);
            return result;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Refresh();
            ManualValidate();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            // 2014-05-29 为了适应企业现有校验风格，这里不自动校验，而是使用ManualValidate统一校验
            ManualValidate();
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.DvEditorValueChanged = true;
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
        public static Size RequireFlagLabelSize { get { return new Size(9, 21); } }

        public static void MakeRequiredLabelReplacement(Control editor, Label requiredLabel, bool visible)
        {
            if (editor as IDataValidateEditor != null && (editor as IDataValidateEditor).DesignMode)
                return;

            if (editor.Parent != null)
            {
                requiredLabel.Parent = editor.Parent;
                requiredLabel.Left = editor.Left - requiredLabel.Width - 2;
                requiredLabel.Top = editor.Top + (editor.Height - requiredLabel.Height) / 2;
                requiredLabel.Visible = visible;
            }
        }
        public static string GetObjectTextValueByMemberName(object inputObject, string memberName)
        {
            if (inputObject == null)
                return string.Empty;
            var property = inputObject.GetType().GetProperty(memberName);
            var result = property.GetValue(inputObject, null);
            return result == null ? string.Empty : result as string;
        }

        public static void SetObjectTextValueByMemberName(object inputObject, string memberName, string memberValue)
        {
            if (inputObject == null)
                return;
            var property = inputObject.GetType().GetProperty(memberName);
            property.SetValue(inputObject, memberValue, null);
        }

        public static bool ValidateEditor(IDataValidateEditor editor, string editorText)
        {
            if (editor.DesignMode)
                return true;
            string editorTextStr = string.Empty;
            if (!string.IsNullOrEmpty(editorText))
                editorTextStr = editorText.Trim();
            if (editor.DvValidateEnabled && editor.DvValidator != null && !string.IsNullOrEmpty(editor.DvRegValue))
            {
                var regex = new Regex(editor.DvRegValue);
                var textLength = string.IsNullOrEmpty(editorTextStr) ? 0 : System.Text.Encoding.Default.GetBytes(editorTextStr).Length;
                var valid = string.IsNullOrEmpty(editorTextStr) ? !editor.DvRequired : regex.IsMatch(editorTextStr) && ((!editor.DvFixLength && (textLength >= editor.DvMinLength) && (textLength <= editor.DvMaxLength)) || (editor.DvFixLength && (textLength == editor.DvMaxLength || textLength == editor.DvMinLength)));
                if ((editor as Control).Enabled && editor.DvErrorProvider != null)
                {
                    if (!valid)
                    {
                        var promptMessage = string.Empty;
                        if (editor.DvLinkedLabel != null)
                            promptMessage = editor.DvLinkedLabel.Text;
                        promptMessage += string.Format("{0}{1};", string.IsNullOrEmpty(promptMessage) ? string.Empty : "\r\n", editor.DvRequired ? "必输" : "非必输");
                        promptMessage += string.Format("{0}{1}", string.IsNullOrEmpty(promptMessage) ? string.Empty : "\r\n", editor.DvRegDescription);
                        promptMessage += string.Format("{0}长度：{1}", string.IsNullOrEmpty(promptMessage) ? string.Empty : "\r\n", editor.DvMinLength == editor.DvMaxLength ? editor.DvMaxLength.ToString() : (editor.DvMinLength + (editor.DvFixLength ? "或" : " - ") + editor.DvMaxLength));

                        editor.DvErrorProvider.SetError(editor as Control, promptMessage);
                        (editor as Control).Refresh();
                        return false;
                    }
                    editor.DvErrorProvider.SetError(editor as Control, string.Empty);
                }
            }

            return true;
        }

        public static bool ValidateEditor(IDataValidateButton button)
        {
            if (button.DesignMode)
                return true;

            // CheckBox 不做校验
            if (button is CheckBox)
                return true;

            //var groupedButtons = new List<IDataValidateButton>();
            var checkedStatusHit = false;
            foreach (Control control in (button as Control).Parent.Controls)
            {
                if (control is IDataValidateButton)
                {
                    var xButton = (control as RadioButton);
                    checkedStatusHit = (xButton.Enabled && xButton.Checked) || checkedStatusHit;
                }
            }

            if (!checkedStatusHit && button.DvErrorProvider != null)
            {
                var promptMessage = string.Empty;
                if (button.DvLinkedLabel != null)
                    promptMessage = button.DvLinkedLabel.Text;
                else
                    promptMessage = (button as Control).Text;

                button.DvErrorProvider.SetError(button as Control, promptMessage);
                return false;
            }
            return true;
        }

        public static bool ValidateComboBox(ComboBoxCanValidate editor)
        {
            if (editor.DvValidateEnabled && editor.DvValidator != null && !string.IsNullOrEmpty(editor.DvRegValue))
            {
                var regex = new Regex(editor.DvRegValue);
                var valid = editor.SelectedIndex != -1 && editor.SelectedItem != null;
                if (editor.DvErrorProvider != null)
                {
                    if (!valid && editor.DvRequired)
                    {
                        var promptMessage = string.Empty;
                        if (editor.DvLinkedLabel != null)
                            promptMessage = editor.DvLinkedLabel.Text;
                        if (!string.IsNullOrEmpty(promptMessage))
                            promptMessage += "\r\n" + "Please Select";
                        else
                            promptMessage = "Please Select";
                        editor.DvErrorProvider.SetError(editor as Control, promptMessage);
                        (editor as Control).Refresh();
                        return false;
                    }
                    editor.DvErrorProvider.Clear();
                    return true;
                }
            }
            return true;
        }

        public static IntPtr ComboEditWnd(IntPtr handle)
        {
            handle = NativeHelper.FindWindowEx(handle, IntPtr.Zero, "EDIT", "\0");
            return handle;
        }

        public void Attach(ComboBox comboBox)
        {
            this.HostEditor = comboBox as IDataValidateEditor;
            if (!this.Handle.Equals(IntPtr.Zero))
                this.ReleaseHandle();
            var handle = ComboEditWnd(comboBox.Handle);
            this.AssignHandle(handle);
        }

        public void Attach(TextBox textBox)
        {
            this.HostEditor = textBox as IDataValidateEditor;
            if (!this.Handle.Equals(IntPtr.Zero))
                this.ReleaseHandle();
            this.AssignHandle(textBox.Handle);
        }

        public IDataValidateEditor HostEditor { get; private set; }

        public void DrawRequiredFlag()
        {
            return; // 暂时使用实体label表示必填项
            //if (this.HostEditor != null && this.HostEditor.DvValidateEnabled && this.HostEditor.DvRequired && !RequireFlagLabelSize.IsEmpty)
            //{
            //    var hostEditor = this.HostEditor as Control;
            //    var hdc = NativeHelper.GetDC(hostEditor.Parent.Handle);
            //    var gfx = Graphics.FromHdc(hdc);
            //    var imgToDraw = Properties.Resources.star1;
            //    imgToDraw.MakeTransparent(Color.White);

            //    Point drawingPoint;
            //    switch (this.HostEditor.DvRequiredFlagStyle)
            //    {
            //        case RequiredFlagStyle.Left:
            //            drawingPoint = new Point(hostEditor.Left - imgToDraw.Width, hostEditor.Top + (hostEditor.Height - imgToDraw.Height) / 2);
            //            gfx.DrawImage(imgToDraw, new Rectangle(drawingPoint.X, drawingPoint.Y, imgToDraw.Width, imgToDraw.Height));
            //            break;
            //        case RequiredFlagStyle.Right:
            //            drawingPoint = new Point(hostEditor.Left + hostEditor.Width, hostEditor.Top + (hostEditor.Height - imgToDraw.Height) / 2);
            //            gfx.DrawImage(imgToDraw, new Rectangle(drawingPoint.X, drawingPoint.Y, imgToDraw.Width, imgToDraw.Height));
            //            break;
            //        case RequiredFlagStyle.Bottom:
            //            var yyy = hostEditor.Top + hostEditor.Height + 0;
            //            gfx.DrawLine(Pens.Tomato, hostEditor.Left + 1, yyy, hostEditor.Left + hostEditor.Width - 1, yyy);
            //            break;
            //        case RequiredFlagStyle.Around:
            //            gfx.DrawRectangle(Pens.Tomato, new Rectangle(hostEditor.Left - 1, hostEditor.Top - 1, hostEditor.Width + 1, hostEditor.Height + 1));
            //            break;
            //    }
            //    gfx.Dispose();
            //    NativeHelper.ReleaseDC(hostEditor.Parent.Handle, hdc);
            //}
        }

        public void UpdateErrorFrame()
        {
            var hostEditor = this.HostEditor as TextBox;
            if (hostEditor != null && this.HostEditor.DvErrorProvider != null)
            {
                var errorMsg = this.HostEditor.DvErrorProvider.GetError(hostEditor);
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    var hdc = NativeHelper.GetDC(this.Handle);
                    var gfx = Graphics.FromHdc(hdc);
                    gfx.DrawRectangle(Pens.Tomato, new Rectangle(0, 0, hostEditor.Width - 6, hostEditor.Height - 6));
                    gfx.Dispose();
                    NativeHelper.ReleaseDC(this.Handle, hdc);
                }
            }
        }
    }

    public class RadioButtonCanValidate : RadioButton, IDataValidateButton
    {
        public Label DvLinkedLabel { get; set; }
        public string DvDataField { get; set; }

        public new bool DesignMode { get { return base.DesignMode; } }
        public ErrorProvider DvErrorProvider { get; set; }

        private int _dvDataValue;
        public int DvDataValue
        {
            get
            {
                return this.Checked ? -Math.Abs(_dvDataValue) : Math.Abs(_dvDataValue);
            }
            set
            {
                if (Math.Abs(this.DvDataValue) == Math.Abs(value) || this._dvDataValue == 0 || this.DesignMode)
                    this._dvDataValue = value;
                this.Checked = value < 0 && (Math.Abs(this._dvDataValue) == Math.Abs(value));
                this.Invalidate();

                // update DvCheckedDataValue for a group of RadioButtons
                var parentContainer = this.Parent;
                if (this.Parent != null)
                {
                    foreach (Control control in parentContainer.Controls)
                    {
                        if (control is RadioButtonCanValidate)
                        {
                            var aRadio = (control as RadioButtonCanValidate);
                            if (aRadio != this && string.Equals(aRadio.DvDataField, this.DvDataField) && (aRadio != this))
                            {
                                aRadio._dvDataValue = Math.Abs(aRadio._dvDataValue);
                                aRadio.Checked = value < 0 && (Math.Abs(aRadio._dvDataValue) == Math.Abs(value));
                                aRadio.Invalidate();
                            }
                        }
                    }

                }
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

    }

    public class CheckBoxCanValidate : CheckBox, IDataValidateButton
    {
        public Label DvLinkedLabel { get; set; }
        public string DvDataField { get; set; }
        public ErrorProvider DvErrorProvider { get; set; }

        public new bool DesignMode { get { return base.DesignMode; } }

        public int DvDataValue
        {
            get { return this.Checked ? -1 : 1; }
            set { this.Checked = value == -1; this.Invalidate(); }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

    }

    public class ValidatorRegexCodeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object currentCode)
        {
            var editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (editorService != null)
            {
                var selectionControl = new ValidatorRegCodeEditor(currentCode as string, editorService, context.Instance as IDataValidateEditor);
                if (editorService.ShowDialog(selectionControl) == DialogResult.OK)
                    return selectionControl.ValidatorRegCode;
                return currentCode;
            }
            return currentCode;
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
    public class ValidatorRegCodeEditor : Form
    {
        private readonly IWindowsFormsEditorService _editorService;
        private ListBox _lblValidatorItems;
        private readonly Container _components;

        public ValidatorRegCodeEditor(string currentRegCode, IWindowsFormsEditorService editorService, IDataValidateEditor editor)
        {
            InitializeComponent();
            this.ValidatorRegCode = currentRegCode;
            this._editorService = editorService;
            //this._components = _components;
            if (editor.DvValidator != null)
            {
                this._lblValidatorItems.Items.AddRange(ValidatorList.Validators.ToArray());
            }
            else
                MessageBoxPrime.Show("Please assign 'dvValidator' property first before you can change the 'dvValidatorIndex' property", "Error", MessageBoxButtonsEx.OK, MessageBoxIcon.Hand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string ValidatorRegCode { get; private set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.DoubleBuffered = true;
            this.Text = "DV控件正则表达式编辑";
            this.Name = "ValidatorIndexEditorControl";
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;
            this.SizeChanged += ValidatorRegCodeEditor_SizeChanged;

            this._lblValidatorItems = new ListBox();
            this.SuspendLayout();
            // 
            // _lblValidatorItems
            // 
            this._lblValidatorItems.Dock = DockStyle.Fill;
            this._lblValidatorItems.DrawMode = DrawMode.OwnerDrawFixed;
            this._lblValidatorItems.FormattingEnabled = true;
            this._lblValidatorItems.ItemHeight = 54;
            this._lblValidatorItems.Location = new Point(0, 0);
            this._lblValidatorItems.Name = "_lblValidatorItems";
            this._lblValidatorItems.Size = new Size(720, 540);
            this._lblValidatorItems.TabIndex = 0;
            this._lblValidatorItems.Click += this.LblValidatorItemsClick;
            this._lblValidatorItems.DrawItem += this.LblValidatorItemsDrawItem;
            // 
            // ValidatorIndexEditorControl
            // 
            this.Controls.Add(this._lblValidatorItems);
            this.Size = new Size(720, 540);
            this.ResumeLayout(false);

        }

        void ValidatorRegCodeEditor_SizeChanged(object sender, EventArgs e)
        {
            this._lblValidatorItems.Refresh();
        }

        private void LblValidatorItemsDrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index > -1)
                {
                    var validator = this._lblValidatorItems.Items[e.Index] as ValidatorItem;
                    var frameBound = e.Bounds;
                    var textBound = e.Bounds;
                    textBound.Inflate(-32, -5);
                    textBound.Offset(9 + 3, 1);

                    frameBound.Inflate(-9, -1);
                    Brush brush1 = null;
                    DrawingHelper.DrawRoundRectangle(e.Graphics, new Pen(Brushes.LightGray), frameBound, 3);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        DrawingHelper.FillRoundRectangle(e.Graphics, Brushes.SteelBlue, frameBound, 3);
                        brush1 = Brushes.White;
                    }
                    else
                    {
                        DrawingHelper.FillRoundRectangle(e.Graphics, Brushes.White, frameBound, 3);
                        brush1 = Brushes.Navy;
                    }
                    if (Resources.business != null)
                        e.Graphics.DrawImage(Resources.settingred, 12, frameBound.Y + 12, (int)this._lblValidatorItems.ItemHeight - 24, (int)this._lblValidatorItems.ItemHeight - 24);
                    var format = new StringFormat { Trimming = StringTrimming.EllipsisPath };
                    e.Graphics.DrawString("Code: " + validator.Code, e.Font, brush1, new RectangleF(frameBound.X + 40, frameBound.Y + 2, frameBound.Width - 45, 18), format);
                    e.Graphics.DrawString("Id: " + validator.Id, e.Font, brush1, new RectangleF(frameBound.X + 186, frameBound.Y + 2, frameBound.Width - 45, 18), format);

                    e.Graphics.DrawString(validator.Regex, e.Font, brush1, new RectangleF(frameBound.X + 40, frameBound.Y + 18, frameBound.Width - 45, 18), format);
                    e.Graphics.DrawString(validator.Description, e.Font, brush1, new RectangleF(frameBound.X + 40, frameBound.Y + 32, frameBound.Width - 45, 18), format);
                }
            }
            catch (Exception)
            {
                MessageBoxPrime.Show("Please assign 'dvValidator' property first, before you can change the 'dvValidatorIndex' property", "Error", MessageBoxButtonsEx.OK, MessageBoxIcon.Hand);
            }
        }

        private void LblValidatorItemsClick(object sender, EventArgs e)
        {
            this.ValidatorRegCode = this._lblValidatorItems.SelectedIndex < 0 ? string.Empty : ValidatorList.Validators[this._lblValidatorItems.SelectedIndex].Code;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }




}

