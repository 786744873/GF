using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;
using CommonClient.Entities;
using CommonClient.Utilities;

namespace CommonClient.Controls
{
    [ProvideProperty("AmbiguityInputAgent", typeof(Control))]
    public class AmbiguityInputAgent : Component, IExtenderProvider
    {
        private readonly Dictionary<Control, AmbiguityInputAgent> _ambiguityInputAgentByControls = new Dictionary<Control, AmbiguityInputAgent>();
        private readonly Dictionary<Control, ITextBoxPacker> _packerBycontrols = new Dictionary<Control, ITextBoxPacker>();
        private ITextBoxPacker _targetControlPacker;
        private readonly Timer _timer = new Timer();
        private List<AmbiguityInfoItem> _sourceItems = new List<AmbiguityInfoItem>();
        private Size _maximumSize;

        [Browsable(false)]
        public List<AmbiguityInfoItem> VisibleItems { get { return Host.ListView.VisibleItems; } private set { Host.ListView.VisibleItems = value; } }

        public AmbiguityInputAgent()
        {
            Host = new AmbiguityInputAgentHost(this);
            Host.ListView.ItemSelected += ListViewItemSelected;
            VisibleItems = new List<AmbiguityInfoItem>();
            Enabled = true;
            AppearInterval = 500;
            _timer.Tick += TimerTick;
            MaximumSize = new Size(200, 180);

            SearchPattern = @"[0-9a-zA-Z]";
            MinFragmentLength = 2;
        }

        void ListViewItemSelected(object sender, EventArgs e)
        {
            OnSelecting();
        }

        [Browsable(false)]
        public int SelectedItemIndex
        {
            get { return Host.ListView.SelectedItemIndex; }
            internal set { Host.ListView.SelectedItemIndex = value; }
        }

        [Browsable(false)]
        public EntityBase SelectedEntity
        {
            get
            {
                return this.Host.ListView.VisibleItems[SelectedItemIndex].Entity;
            }
        }

        internal AmbiguityInputAgentHost Host { get; set; }

        public event EventHandler<PackerNeededEventParameter> WrapperNeeded;

        protected void OnWrapperNeeded(PackerNeededEventParameter parameter)
        {
            if (WrapperNeeded != null)
                WrapperNeeded(this, parameter);
            if (parameter.Packer == null)
                parameter.Packer = TextBoxPacker.Create(parameter.TargetControl);
        }

        ITextBoxPacker CreateWrapper(Control control)
        {
            if (_packerBycontrols.ContainsKey(control))
                return _packerBycontrols[control];

            var args = new PackerNeededEventParameter(control);
            OnWrapperNeeded(args);
            if (args.Packer != null)
                _packerBycontrols[control] = args.Packer;

            return args.Packer;
        }

        [Browsable(false)]
        public ITextBoxPacker TargetControlPacker
        {
            get { return _targetControlPacker; }
            set
            {
                _targetControlPacker = value;
                if (value != null && !_packerBycontrols.ContainsKey(value.TargetControl))
                {
                    _packerBycontrols[value.TargetControl] = value;
                    SetAmbiguityInputAgent(value.TargetControl, this);
                }
            }
        }

        [DefaultValue(typeof(Size), "200, 180")]
        public Size MaximumSize
        {
            get { return _maximumSize; }
            set
            {
                _maximumSize = value;
                (Host.ListView as Control).MaximumSize = _maximumSize;
                (Host.ListView as Control).Size = _maximumSize;
                Host.CalcSize();
            }
        }

        public Font Font
        {
            get { return (Host.ListView as Control).Font; }
            set { (Host.ListView as Control).Font = value; }
        }

        [DefaultValue(false)]
        public bool CaptureFocus { get; set; }

        [DefaultValue(typeof(RightToLeft), "No")]
        public RightToLeft RightToLeft
        {
            get { return Host.RightToLeft; }
            set { Host.RightToLeft = value; }
        }

        public ImageList ImageList
        {
            get { return Host.ListView.ImageList; }
            set { Host.ListView.ImageList = value; }
        }

        [Browsable(false)]
        public Range Fragment { get; internal set; }

        [DefaultValue(@"[\w\.]")]
        public string SearchPattern { get; set; }

        [DefaultValue(1)]
        public int MinFragmentLength { get; set; }

        [DefaultValue(false)]
        public bool AllowsTabKey { get; set; }

        [DefaultValue(500)]
        public int AppearInterval { get; set; }

        [DefaultValue(null)]
        public string[] Items
        {
            get
            {
                if (_sourceItems == null)
                    return null;
                var list = new List<string>();
                foreach (AmbiguityInfoItem item in _sourceItems)
                    list.Add(item.ToString());
                return list.ToArray();
            }
            set { SetAmbiguityInputInfoItems(value); }
        }

        [Browsable(false)]
        public IAmbiguityListView ListView
        {
            get { return Host.ListView; }
            set
            {
                if (ListView != null)
                {
                    var ctrl = value as Control;
                    value.ImageList = ImageList;
                    ctrl.RightToLeft = RightToLeft;
                    ctrl.Font = Font;
                    ctrl.MaximumSize = ctrl.MaximumSize;
                }
                Host.ListView = value;
                Host.ListView.ItemSelected += ListViewItemSelected;
            }
        }

        [DefaultValue(true)]
        public bool Enabled { get; set; }

        public void Update()
        {
            Host.CalcSize();
        }

        bool IExtenderProvider.CanExtend(object extendee)
        {
            //if (Container != null)
            //    foreach (object comp in Container.Components)
            //        if (comp is AmbiguityInputAgent)
            //            if (comp.GetHashCode() < GetHashCode())
            //                return false;
            if (!(extendee is Control))
                return false;
            var temp = TextBoxPacker.Create(extendee as Control);
            return temp != null;
        }

        public void SetAmbiguityInfoItemsForComboBox(ComboBox comboBox)
        {
            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                foreach (string item in comboBox.Items)
                {
                    var amItem = new MulticolumnAmbiguityInfoItem(new string[] { item, item }, string.Empty, true, true);
                    this.AddItem(amItem);
                }
            }
        }

        public void SetAmbiguityInputAgent(Control control, AmbiguityInputAgent agent)
        {
            if (agent != null)
            {
                var wrapper = agent.CreateWrapper(control);
                if (wrapper == null)
                    return;
                _ambiguityInputAgentByControls[control] = this;
                wrapper.LostFocus += agent.ControlLostFocus;
                wrapper.Scroll += agent.ControlScroll;
                wrapper.KeyDown += agent.ControlKeyDown;
                wrapper.MouseDown += agent.ControlMouseDown;
            }
            else
            {
                _ambiguityInputAgentByControls.TryGetValue(control, out agent);
                _ambiguityInputAgentByControls.Remove(control);
                ITextBoxPacker packer = null;
                _packerBycontrols.TryGetValue(control, out packer);
                _packerBycontrols.Remove(control);
                if (packer != null && agent != null)
                {
                    packer.LostFocus -= agent.ControlLostFocus;
                    packer.Scroll -= agent.ControlScroll;
                    packer.KeyDown -= agent.ControlKeyDown;
                    packer.MouseDown -= agent.ControlMouseDown;
                }
            }
        }

        public event EventHandler<SelectingEventParameter> Selecting;
        public event EventHandler<SelectedEventParameter> Selected;
        public event EventHandler<CancelEventArgs> Opening;

        private void TimerTick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (TargetControlPacker != null)
                if (!_forcedOpened)
                    ShowAmbiguityInputAgent(false);
        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }

        ITextBoxPacker FindWrapper(Control sender)
        {
            while (sender != null)
            {
                if (_packerBycontrols.ContainsKey(sender))
                    return _packerBycontrols[sender];

                sender = sender.Parent;
            }

            return null;
        }

        internal void ControlKeyDown(object sender, KeyEventArgs e)
        {
            TargetControlPacker = FindWrapper(sender as Control);
            var backspaceORdel = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete;

            if (Host.Visible)
            {
                if (ProcessKey((char)e.KeyCode, Control.ModifierKeys))
                    e.SuppressKeyPress = true;
                else
                    if (!backspaceORdel)
                        ResetTimer(1);
                    else
                        StopTimer();

                return;
            }

            if (!Host.Visible)
                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Space)
                {
                    ShowAmbiguityInputAgent();
                    e.SuppressKeyPress = true;
                    return;
                }

            ResetTimer((uint)this.AppearInterval);
        }

        internal void StopTimer()
        {
            _timer.Stop();
            _timer.Interval = AppearInterval;
        }

        internal void ResetTimer(uint interval)
        {
            _timer.Interval = (int)interval;
            _timer.Stop();
            _timer.Start();
        }

        private void ControlScroll(object sender, ScrollEventArgs e)
        {
            Close();
        }

        private void ControlLostFocus(object sender, EventArgs e)
        {
            if (!Host.Focused)
                Close();
        }

        public AmbiguityInputAgent GetAmbiguityInputAgent(Control control)
        {
            if (_ambiguityInputAgentByControls.ContainsKey(control))
                return _ambiguityInputAgentByControls[control];
            return null;
        }

        internal void ShowAmbiguityInputAgent()
        {
            ShowAmbiguityInputAgent(false);
        }

        bool _forcedOpened = false;

        internal void ShowAmbiguityInputAgent(bool forced)
        {
            if (forced)
                _forcedOpened = true;

            if (!Enabled)
            {
                Close();
                return;
            }

            BuildAmbiguityInfoItemsList(forced);

            if (VisibleItems.Count > 0)
                ShowMenu();
            else
            {
                if (!_forcedOpened)
                    Close();
                var text = this.TargetControlPacker.Text;
                this.TargetControlPacker.SelectionStart = text.Length;
                this.TargetControlPacker.SelectionLength = 0;
            }
        }

        private void ShowMenu()
        {
            if (!Host.Visible)
            {
                var args = new CancelEventArgs();
                OnOpening(args);
                if (!args.Cancel)
                {
                    var point = TargetControlPacker.GetPositionFromCharIndex(Fragment.Start);
                    if (DrawingHelper.PointOutRect(Screen.FromControl(Host).Bounds, point))
                        point = new Point(0, TargetControlPacker.TargetControl.Height + 1);
                    else
                        point.Offset(0, TargetControlPacker.TargetControl.Height + 1);
                    Host.Show(TargetControlPacker.TargetControl, point);
                    if (CaptureFocus && (Host.ListView as Control).CanFocus)
                    {
                        (Host.ListView as Control).Focus();
                        //ProcessKey((char) Keys.Down, Keys.None);
                    }
                }
            }
            else
                (Host.ListView as Control).Invalidate();
        }

        private void BuildAmbiguityInfoItemsList(bool forced)
        {
            var visibleItems = new List<AmbiguityInfoItem>();

            bool foundSelected = false;
            int selectedIndex = -1;
            Range fragment = GetFragment(SearchPattern);
            string text = fragment.Text;
            if (_sourceItems != null)
                if (forced || (text.Length >= MinFragmentLength /* && tb.Selection.Start == tb.Selection.End*/))
                {
                    Fragment = fragment;
                    //build popup agent
                    foreach (AmbiguityInfoItem item in _sourceItems)
                    {
                        item.Parent = this;
                        CompareResult res = item.Compare(text);
                        if (res != CompareResult.Hidden)
                            visibleItems.Add(item);
                        if (res == CompareResult.VisibleAndSelected && !foundSelected)
                        {
                            foundSelected = true;
                            selectedIndex = visibleItems.Count - 1;
                        }
                    }
                }

            VisibleItems = visibleItems;

            if (foundSelected)
                SelectedItemIndex = selectedIndex;
            else
                SelectedItemIndex = 0;

            Host.CalcSize();
        }

        internal void OnOpening(CancelEventArgs args)
        {
            if (Opening != null)
                Opening(this, args);
        }

        private Range GetFragment(string searchPattern)
        {
            if (TargetControlPacker.SelectionLength > 0)
                return new Range(TargetControlPacker);

            string text = TargetControlPacker.Text;
            var regex = new Regex(searchPattern);
            var result = new Range(TargetControlPacker);

            int startPos = TargetControlPacker.SelectionStart;
            int i = startPos;
            while (i >= 0 && i < text.Length)
            {
                if (!regex.IsMatch(text[i].ToString()))
                    break;
                i++;
            }
            result.End = i;

            i = startPos;
            while (i > 0 && (i - 1) < text.Length)
            {
                if (!regex.IsMatch(text[i - 1].ToString()))
                    break;
                i--;
            }
            result.Start = i;

            return result;
        }

        public void Close()
        {
            Host.Close();
            _forcedOpened = false;
        }

        public void SetAmbiguityInputInfoItems(IEnumerable<string> items)
        {
            var list = new List<AmbiguityInfoItem>();
            if (items == null)
            {
                _sourceItems = null;
                return;
            }
            foreach (string item in items)
                list.Add(new AmbiguityInfoItem(item));
            SetAmbiguityInputInfoItems(list);
        }

        public void SetAmbiguityInputInfoItems(List<AmbiguityInfoItem> items)
        {
            _sourceItems = items;
        }

        public void AddItem(string item)
        {
            AddItem(new AmbiguityInfoItem(item));
        }

        public void AddItem(AmbiguityInfoItem item)
        {
            if (_sourceItems == null)
                _sourceItems = new List<AmbiguityInfoItem>();

            _sourceItems.Add(item);
        }

        public void ClearItems()
        {
            if (_sourceItems != null)
                _sourceItems.Clear();
            if (VisibleItems != null)
                VisibleItems.Clear();
        }

        public void Show(Control control, bool forced)
        {
            SetAmbiguityInputAgent(control, this);
            this.TargetControlPacker = FindWrapper(control);
            ShowAmbiguityInputAgent(forced);
        }

        internal virtual void OnSelecting()
        {
            if (SelectedItemIndex < 0 || SelectedItemIndex >= VisibleItems.Count)
                return;

            AmbiguityInfoItem item = VisibleItems[SelectedItemIndex];
            var args = new SelectingEventParameter { Item = item, SelectedIndex = SelectedItemIndex };
            OnSelecting(args);

            if (args.Cancel)
            {
                SelectedItemIndex = args.SelectedIndex;
                (Host.ListView as Control).Invalidate(true);
                return;
            }

            if (!args.Handled)
            {
                Range fragment = Fragment;
                ApplyAmbiguityInputAgent(item, fragment);
            }

            Close();
            var args2 = new SelectedEventParameter { Item = item, Control = TargetControlPacker.TargetControl };
            item.OnSelected(args2);
            OnSelected(args2);
        }

        private void ApplyAmbiguityInputAgent(AmbiguityInfoItem item, Range fragment)
        {
            string newText = item.GetTextForReplace();
            fragment.Text = newText;
            fragment.TargetPacker.TargetControl.Focus();
        }

        internal void OnSelecting(SelectingEventParameter parameter)
        {
            if (Selecting != null)
                Selecting(this, parameter);
        }

        public void OnSelected(SelectedEventParameter parameter)
        {
            if (Selected != null)
                Selected(this, parameter);
        }

        public void SelectNext(int shift)
        {
            SelectedItemIndex = Math.Max(0, Math.Min(SelectedItemIndex + shift, VisibleItems.Count - 1));
            (Host.ListView as Control).Invalidate();
        }

        internal bool ProcessKey(char c, Keys keyModifiers)
        {
            var page = Host.Height / (Font.Height + 4);
            if (keyModifiers == Keys.None)
                switch ((Keys)c)
                {
                    case Keys.Down:
                        SelectNext(+1);
                        return true;
                    case Keys.PageDown:
                        SelectNext(+page);
                        return true;
                    case Keys.Up:
                        SelectNext(-1);
                        return true;
                    case Keys.PageUp:
                        SelectNext(-page);
                        return true;
                    case Keys.Enter:
                        OnSelecting();
                        return true;
                    case Keys.Tab:
                        if (!AllowsTabKey)
                            break;
                        OnSelecting();
                        return true;
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Escape:
                        {
                            this.StopTimer();
                            this.Close();
                        }
                        return true;
                }

            return false;
        }
    }

    [ToolboxItem(false)]
    internal class AmbiguityInputAgentHost : ToolStripDropDown
    {
        private IAmbiguityListView _listView;
        public ToolStripControlHost ToolStripControlHost { get; set; }
        public readonly AmbiguityInputAgent Agent;

        public IAmbiguityListView ListView
        {
            get
            {
                return _listView;
            }
            set
            {
                _listView = value;
                base.Items.Clear();
                ToolStripControlHost = new ToolStripControlHost(_listView as Control) { Margin = new Padding(2, 2, 2, 2), Padding = Padding.Empty, AutoSize = false, AutoToolTip = true };
                base.Items.Add(ToolStripControlHost);
                (_listView as Control).MaximumSize = Agent.MaximumSize;
                (_listView as Control).Size = Agent.MaximumSize;
                CalcSize();
            }
        }

        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            if ((int)keyData > 95 && (int)keyData < 106) keyData = (Keys)((int)keyData - 48);
            var keyChar = (char)keyData;
            var escape = false;
            if (Char.IsLetterOrDigit(keyChar) || char.IsSeparator(keyChar))
                this.Agent.TargetControlPacker.TargetControl.Text += keyChar;
            else if (keyData == Keys.Back)
            {
                var text = this.Agent.TargetControlPacker.Text.Trim();
                if (text.Length > 1)
                    this.Agent.TargetControlPacker.TargetControl.Text = text.Substring(0, text.Length - 1);
                else
                    this.Agent.TargetControlPacker.TargetControl.Text = string.Empty;
            }
            else if (keyData == Keys.Escape)
            {
                escape = true;
                this.Agent.StopTimer();
                this.Agent.Close();
            }
            if (!escape)
                this.Agent.ResetTimer(100);
            return base.ProcessCmdKey(ref m, keyData);
        }

        public AmbiguityInputAgentHost(AmbiguityInputAgent agent)
        {
            AutoClose = true;
            AutoSize = false;
            Margin = Padding.Empty;
            Padding = Padding.Empty;

            Agent = agent;
            ListView = new AmbiguityListView { OwnerAgent = agent };
        }

        internal void CalcSize()
        {
            ToolStripControlHost.Size = (ListView as Control).Size;
            Size = new Size((ListView as Control).Size.Width + 4, (ListView as Control).Size.Height + 4);
        }

        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                (ListView as Control).RightToLeft = value;
            }
        }
    }

    public class AmbiguityInfoItem
    {
        public object Tag;
        public AmbiguityInputAgent Parent { get; internal set; }
        public string Text { get; set; }
        public int ImageIndex { get; set; }
        public virtual string ToolTipTitle { get; set; }
        public virtual string ToolTipText { get; set; }
        public virtual string MenuText { get; set; }
        public Entities.EntityBase Entity { get; set; }

        public AmbiguityInfoItem()
        {
            ImageIndex = -1;
        }

        public AmbiguityInfoItem(string text)
            : this()
        {
            Text = text;
        }

        public AmbiguityInfoItem(string text, int imageIndex)
            : this(text)
        {
            this.ImageIndex = imageIndex;
        }

        public AmbiguityInfoItem(string text, int imageIndex, string menuText)
            : this(text, imageIndex)
        {
            this.MenuText = menuText;
        }

        public AmbiguityInfoItem(string text, int imageIndex, string menuText, string toolTipTitle, string toolTipText)
            : this(text, imageIndex, menuText)
        {
            this.ToolTipTitle = toolTipTitle;
            this.ToolTipText = toolTipText;
        }

        public virtual string GetTextForReplace()
        {
            return Text;
        }

        public virtual CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) && Text != fragmentText)
                return CompareResult.VisibleAndSelected;
            return CompareResult.Hidden;
        }

        public override string ToString()
        {
            return MenuText ?? Text;
        }

        public virtual void OnSelected(SelectedEventParameter e)
        {
        }

        public virtual void OnPaint(PaintItemEventParameter e)
        {
            var wholeText = ToString();
            TextRenderer.DrawText(e.Graphics, wholeText, e.Font, new Point((int)e.TextRect.Left, (int)e.TextRect.Top), Color.Black);
            var foundIndex = wholeText.IndexOf(e.SearchingText, StringComparison.CurrentCultureIgnoreCase);
            using (var aBrush = new SolidBrush(Color.FromArgb(96, Color.Red)))
            {
                while (foundIndex > -1)
                {
                    var prefixString = wholeText.Substring(0, foundIndex);
                    var prefixStringSize = TextRenderer.MeasureText(e.Graphics, prefixString, e.Font, new Size(255, 255), TextFormatFlags.NoPadding);
                    var matchStringSize = TextRenderer.MeasureText(e.Graphics, e.SearchingText, e.Font, new Size(255, 255), TextFormatFlags.NoPadding);
                    e.Graphics.FillRectangle(aBrush, e.TextRect.Left + prefixStringSize.Width + 3, e.TextRect.Top, (int)(matchStringSize.Width), e.TextRect.Height);
                    foundIndex = wholeText.IndexOf(e.SearchingText, foundIndex + e.SearchingText.Length, StringComparison.CurrentCultureIgnoreCase);
                    if (foundIndex == 0)
                        break;
                }
            }
        }
    }

    public enum CompareResult
    {
        Hidden,
        Visible,
        VisibleAndSelected
    }

    public class MethodAmbiguityInfoItem : AmbiguityInfoItem
    {
        string _firstPart;
        string lowercaseText;

        public MethodAmbiguityInfoItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');
            if (i < 0)
                return CompareResult.Hidden;
            string lastPart = fragmentText.Substring(i + 1);
            _firstPart = fragmentText.Substring(0, i);

            if (string.IsNullOrEmpty(lastPart))
                return CompareResult.Visible;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            return _firstPart + "." + Text;
        }
    }

    public class SnippetAmbiguityInfoItem : AmbiguityInfoItem
    {
        public SnippetAmbiguityInfoItem(string snippet)
        {
            Text = snippet.Replace("\r", string.Empty);
            ToolTipTitle = "Code snippet:";
            ToolTipText = Text;
        }

        public override string ToString()
        {
            return MenuText ?? Text.Replace("\n", " ").Replace("^", string.Empty);
        }

        public override string GetTextForReplace()
        {
            return Text;
        }

        public override void OnSelected(SelectedEventParameter e)
        {
            var tb = Parent.TargetControlPacker;
            if (!Text.Contains("^"))
                return;
            var text = tb.Text;
            for (int i = Parent.Fragment.Start; i < text.Length; i++)
                if (text[i] == '^')
                {
                    tb.SelectionStart = i;
                    tb.SelectionLength = 1;
                    tb.SelectedText = string.Empty;
                    return;
                }
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.Visible;
            return CompareResult.Hidden;
        }
    }

    public class SubstringAmbiguityInfoItem : AmbiguityInfoItem
    {
        protected readonly string LowercaseText;
        protected readonly bool IgnoreCase;

        public SubstringAmbiguityInfoItem(string text, bool ignoreCase = true)
            : base(text)
        {
            this.IgnoreCase = ignoreCase;
            if (ignoreCase)
                LowercaseText = text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (IgnoreCase)
            {
                if (LowercaseText.Contains(fragmentText.ToLower()))
                    return CompareResult.Visible;
            }
            else
            {
                if (Text.Contains(fragmentText))
                    return CompareResult.Visible;
            }

            return CompareResult.Hidden;
        }
    }

    public class MulticolumnAmbiguityInfoItem : SubstringAmbiguityInfoItem
    {
        public bool CompareBySubstring { get; set; }
        public string[] MenuTextByColumns { get; set; }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int[] ColumnWidth { get; set; }

        public MulticolumnAmbiguityInfoItem(string[] menuTextByColumns, string insertingText, bool compareBySubstring = true, bool ignoreCase = true)
            : base(insertingText, ignoreCase)
        {
            this.CompareBySubstring = compareBySubstring;
            this.MenuTextByColumns = menuTextByColumns;
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (CompareBySubstring)
                return base.Compare(fragmentText);

            if (IgnoreCase)
            {
                if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase))
                    return CompareResult.VisibleAndSelected;
            }
            else
                if (Text.StartsWith(fragmentText))
                    return CompareResult.VisibleAndSelected;

            return CompareResult.Hidden;
        }

        public override void OnPaint(PaintItemEventParameter e)
        {
            if (ColumnWidth != null && ColumnWidth.Length != MenuTextByColumns.Length)
                throw new Exception("ColumnWidth.Length miss match with MenuTextByColumns.Length");

            int[] columnWidth = ColumnWidth;
            if (columnWidth == null)
            {
                columnWidth = new int[MenuTextByColumns.Length];
                float step = e.TextRect.Width / MenuTextByColumns.Length;
                for (int i = 0; i < MenuTextByColumns.Length; i++)
                    columnWidth[i] = (int)step;
            }

            Pen pen = Pens.Silver;
            Brush brush = Brushes.Black;
            float x = e.TextRect.X;
            e.StringFormat.FormatFlags = e.StringFormat.FormatFlags | StringFormatFlags.NoWrap;

            for (int i = 0; i < MenuTextByColumns.Length; i++)
            {
                var width = columnWidth[i];
                var rect = new RectangleF(x, e.TextRect.Top, width, e.TextRect.Height);
                e.Graphics.DrawLine(pen, new PointF(x, e.TextRect.Top), new PointF(x, e.TextRect.Bottom));
                e.Graphics.DrawString(MenuTextByColumns[i], e.Font, brush, rect, e.StringFormat);
                x += width;
            }
        }
    }

    [DesignTimeVisibleAttribute(false)]
    public class AmbiguityListView : UserControl, IAmbiguityListView
    {
        private readonly ToolTip _toolTip = new ToolTip();
        private int _hoveredItemIndex = -1;
        private int _selectedItemIndex = -1;
        private int _oldItemCount;
        private List<AmbiguityInfoItem> _visibleItems;

        public event EventHandler ItemSelected;

        internal AmbiguityListView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            base.Font = new Font(FontFamily.GenericSansSerif, 9);
            ItemHeight = Font.Height + 2;
            VerticalScroll.SmallChange = ItemHeight;
            BackColor = SystemColors.Info;
        }

        private int _itemHeight;

        public int ItemHeight
        {
            get { return _itemHeight; }
            set
            {
                _itemHeight = value;
                VerticalScroll.SmallChange = value;
                _oldItemCount = -1;
                AdjustScroll();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                ItemHeight = Font.Height + 2;
            }
        }

        public AmbiguityInputAgent OwnerAgent { get; set; }

        public ImageList ImageList { get; set; }

        public List<AmbiguityInfoItem> VisibleItems
        {
            get { return _visibleItems; }
            set
            {
                _visibleItems = value;
                SelectedItemIndex = -1;
                AdjustScroll();
                Invalidate();
            }
        }

        public int SelectedItemIndex
        {
            get { return _selectedItemIndex; }
            set
            {
                _selectedItemIndex = value;
                _hoveredItemIndex = value;
                if (SelectedItemIndex >= 0 && SelectedItemIndex < VisibleItems.Count)
                {
                    SetToolTip(VisibleItems[SelectedItemIndex]);
                    ScrollToSelected();
                }

                Invalidate();
            }
        }

        private void AdjustScroll()
        {
            if (VisibleItems == null)
                return;
            if (_oldItemCount == VisibleItems.Count)
                return;

            int needHeight = ItemHeight * VisibleItems.Count + 1;
            Height = Math.Min(needHeight, MaximumSize.Height);
            AutoScrollMinSize = new Size(0, needHeight);
            _oldItemCount = VisibleItems.Count;
        }


        private void ScrollToSelected()
        {
            int y = SelectedItemIndex * ItemHeight - VerticalScroll.Value;
            if (y < 0)
                VerticalScroll.Value = SelectedItemIndex * ItemHeight;
            if (y > ClientSize.Height - ItemHeight)
                VerticalScroll.Value = Math.Min(VerticalScroll.Maximum, SelectedItemIndex * ItemHeight - ClientSize.Height + ItemHeight);
            AutoScrollMinSize -= new Size(1, 0);
            AutoScrollMinSize += new Size(1, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rtl = RightToLeft == RightToLeft.Yes;
            AdjustScroll();
            var startI = VerticalScroll.Value / ItemHeight - 1;
            var finishI = (VerticalScroll.Value + ClientSize.Height) / ItemHeight + 1;
            startI = Math.Max(startI, 0);
            finishI = Math.Min(finishI, VisibleItems.Count);
            const int leftPadding = 18;
            for (int iii = startI; iii < finishI; iii++)
            {
                var y = iii * ItemHeight - VerticalScroll.Value;

                if (ImageList != null && VisibleItems[iii].ImageIndex >= 0)
                    if (rtl)
                        e.Graphics.DrawImage(ImageList.Images[VisibleItems[iii].ImageIndex], Width - 1 - leftPadding, y);
                    else
                        e.Graphics.DrawImage(ImageList.Images[VisibleItems[iii].ImageIndex], 1, y);

                var textRect = new Rectangle(leftPadding, y, ClientSize.Width - 1 - leftPadding, ItemHeight - 1);
                if (rtl)
                    textRect = new Rectangle(1, y, ClientSize.Width - 1 - leftPadding, ItemHeight - 1);

                var paintRect = new Rectangle(0, y, ClientSize.Width - 1, _itemHeight);

                if (iii == SelectedItemIndex || iii == _hoveredItemIndex)
                {
                    Brush selectedBrush = new LinearGradientBrush(new Point(0, y - 3), new Point(0, y + ItemHeight), Color.Yellow, Color.Orange);
                    e.Graphics.FillRectangle(selectedBrush, paintRect);
                    e.Graphics.DrawRectangle(Pens.Orange, paintRect);
                }

                var sf = new StringFormat();
                if (rtl)
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                var args = new PaintItemEventParameter(e.Graphics, e.ClipRectangle) { Font = Font, TextRect = new RectangleF(textRect.Location, textRect.Size), StringFormat = sf, IsSelected = iii == SelectedItemIndex, IsHovered = iii == _hoveredItemIndex, SearchingText = this.OwnerAgent.TargetControlPacker.TargetControl.Text };
                VisibleItems[iii].OnPaint(args);
            }
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate(true);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                SelectedItemIndex = PointToItemIndex(e.Location);
                ScrollToSelected();
                Invalidate();
                OnItemSelected();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var position = this.PointToClient(Control.MousePosition);
            _hoveredItemIndex = PointToItemIndex(position);
            SelectedItemIndex = _hoveredItemIndex;
            Invalidate(true);
        }

        private void OnItemSelected()
        {
            if (ItemSelected != null)
                ItemSelected(this, EventArgs.Empty);
        }


        private int PointToItemIndex(Point p)
        {
            return (p.Y + VerticalScroll.Value) / ItemHeight;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var host = Parent as AmbiguityInputAgentHost;
            if (host != null)
                if (host.Agent.ProcessKey((char)keyData, Keys.None))
                    return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void SelectItem(int itemIndex)
        {
            SelectedItemIndex = itemIndex;
            ScrollToSelected();
            Invalidate();
        }

        public void SetItems(List<AmbiguityInfoItem> items)
        {
            VisibleItems = items;
            SelectedItemIndex = -1;
            AdjustScroll();
            Invalidate();
        }

        public void SetToolTip(AmbiguityInfoItem ambiguityInfoItem)
        {
            string title = VisibleItems[SelectedItemIndex].ToolTipTitle;
            string text = VisibleItems[SelectedItemIndex].ToolTipText;

            if (string.IsNullOrEmpty(title))
            {
                _toolTip.ToolTipTitle = null;
                _toolTip.SetToolTip(this, null);
                return;
            }

            if (string.IsNullOrEmpty(text))
            {
                _toolTip.ToolTipTitle = null;
                _toolTip.Show(title, this, Width + 3, 0, 3000);
            }
            else
            {
                _toolTip.ToolTipTitle = title;
                _toolTip.Show(text, this, Width + 3, 0, 3000);
            }
        }
    }

    public class SelectingEventParameter : EventArgs
    {
        public AmbiguityInfoItem Item { get; internal set; }
        public bool Cancel { get; set; }
        public int SelectedIndex { get; set; }
        public bool Handled { get; set; }
    }

    public class SelectedEventParameter : EventArgs
    {
        public AmbiguityInfoItem Item { get; internal set; }
        public Control Control { get; set; }
    }


    public class PaintItemEventParameter : PaintEventArgs
    {
        public RectangleF TextRect { get; internal set; }
        public StringFormat StringFormat { get; internal set; }
        public string SearchingText { get; internal set; }
        public Font Font { get; internal set; }
        public bool IsSelected { get; internal set; }
        public bool IsHovered { get; internal set; }

        public PaintItemEventParameter(Graphics graphics, Rectangle clipRect)
            : base(graphics, clipRect)
        {
        }
    }

    public class PackerNeededEventParameter : EventArgs
    {
        public Control TargetControl { get; private set; }
        public ITextBoxPacker Packer { get; set; }

        public PackerNeededEventParameter(Control targetControl)
        {
            this.TargetControl = targetControl;
        }
    }

    public class Range
    {
        public ITextBoxPacker TargetPacker { get; private set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Range(ITextBoxPacker targetPacker)
        {
            this.TargetPacker = targetPacker;
        }

        public string Text
        {
            get
            {
                var text = TargetPacker.Text;

                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                if (Start >= text.Length)
                    return string.Empty;
                if (End > text.Length)
                    return string.Empty;

                return TargetPacker.Text.Substring(Start, End - Start);
            }

            set
            {
                TargetPacker.SelectionStart = Start;
                TargetPacker.SelectionLength = End - Start;
                TargetPacker.SelectedText = value;
            }
        }
    }

    public interface IAmbiguityListView
    {
        AmbiguityInputAgent OwnerAgent { get; set; }
        ImageList ImageList { get; set; }
        int SelectedItemIndex { get; set; }
        List<AmbiguityInfoItem> VisibleItems { get; set; }
        event EventHandler ItemSelected;
    }

    public interface ITextBoxPacker
    {
        Control TargetControl { get; }
        string Text { get; }
        string SelectedText { get; set; }
        int SelectionLength { get; set; }
        int SelectionStart { get; set; }
        Point GetPositionFromCharIndex(int pos);
        event EventHandler LostFocus;
        event ScrollEventHandler Scroll;
        event KeyEventHandler KeyDown;
        event MouseEventHandler MouseDown;
    }

    public class TextBoxPacker : ITextBoxPacker
    {
        private readonly Control _target;
        private PropertyInfo _selectionStart;
        private PropertyInfo _selectionLength;
        private PropertyInfo _selectedText;
        private MethodInfo _getPositionFromCharIndex;
        private event ScrollEventHandler RtbScroll;

        private TextBoxPacker(Control targetControl)
        {
            this._target = targetControl;
            Init();
        }

        protected virtual void Init()
        {
            var t = _target.GetType();
            _selectedText = t.GetProperty("SelectedText");
            _selectionLength = t.GetProperty("SelectionLength");
            _selectionStart = t.GetProperty("SelectionStart");
            _getPositionFromCharIndex = t.GetMethod("GetPositionFromCharIndex") ?? t.GetMethod("PositionToPoint");
            //if (!(_target is ContainerControl))
            //    MessageBox.Show(_target.GetType().ToString() + "  _selectedText: " + _selectedText + " ;  _selectionLength: " + _selectionLength + " ;  _selectionStart: " + _selectionStart + " ;  _getPositionFromCharIndex: " + _getPositionFromCharIndex);
            if (_target is RichTextBox)
                (_target as RichTextBox).VScroll += TextBoxWrapperVScroll;
        }

        void TextBoxWrapperVScroll(object sender, EventArgs e)
        {
            if (RtbScroll != null)
                RtbScroll(sender, new ScrollEventArgs(ScrollEventType.EndScroll, 0, 1));
        }

        public static TextBoxPacker Create(Control targetControl)
        {
            var result = new TextBoxPacker(targetControl);

            if (result._selectedText == null || result._selectionLength == null || result._selectionStart == null)// || result._getPositionFromCharIndex == null)
                return null;

            return result;
        }

        public virtual string Text
        {
            get { return _target.Text; }
            set { _target.Text = value; }
        }

        public virtual string SelectedText
        {
            get { return (string)_selectedText.GetValue(_target, null); }
            set { _selectedText.SetValue(_target, value, null); }
        }

        public virtual int SelectionLength
        {
            get { return (int)_selectionLength.GetValue(_target, null); }
            set { _selectionLength.SetValue(_target, value, null); }
        }

        public virtual int SelectionStart
        {
            get { return (int)_selectionStart.GetValue(_target, null); }
            set { _selectionStart.SetValue(_target, value, null); }
        }

        public virtual Point GetPositionFromCharIndex(int pos)
        {
            return (Point)_getPositionFromCharIndex.Invoke(_target, new object[] { pos });
        }

        public virtual event EventHandler LostFocus
        {
            add { _target.LostFocus += value; }
            remove { _target.LostFocus -= value; }
        }

        public virtual event ScrollEventHandler Scroll
        {
            add
            {
                if (_target is RichTextBox)
                    RtbScroll += value;
                else
                    if (_target is ScrollableControl) (_target as ScrollableControl).Scroll += value;

            }
            remove
            {
                if (_target is RichTextBox)
                    RtbScroll -= value;
                else
                    if (_target is ScrollableControl) (_target as ScrollableControl).Scroll -= value;
            }
        }

        public virtual event KeyEventHandler KeyDown
        {
            add { _target.KeyDown += value; }
            remove { _target.KeyDown -= value; }
        }

        public virtual event MouseEventHandler MouseDown
        {
            add { _target.MouseDown += value; }
            remove { _target.MouseDown -= value; }
        }

        public virtual Control TargetControl
        {
            get { return _target; }
        }
    }
}