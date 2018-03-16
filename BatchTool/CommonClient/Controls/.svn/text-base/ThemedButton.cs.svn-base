using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CommonClient.Controls
{
    public partial class ThemedButton : Button
    {
        private List<Image> _frames;
        private List<ButtonTheme> _predefinedThemes;

        private Color _borderColorInner;
        private Color _borderColorOuter;
        private Color _shineColor;
        private Color _glowColor;
        private Button _imageButton;
        private const int AnimationLength = 300;
        private const int FramesCount = 10;
        private int _currentFrame;
        private int _direction;
        private const int FrameDisabled = 0;
        private const int FramePressed = 1;
        private const int FrameNormal = 2;
        private const int FrameAnimated = 3;
        private bool _isHovered;
        private bool _isFocused;
        private bool _isKeyDown;
        private bool _isMouseDown;
        private bool IsPressed { get { return _isKeyDown || (_isMouseDown && _isHovered); } }
        private Color _backColor;



        public ThemedButton()
        {
            InitializeComponent();
            timer.Interval = AnimationLength / FramesCount;

            this.LoadPredefinedTheme();
            base.BackColor = Color.Transparent;
            this.ThemeName = ThemeName.Default;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);
        }

        private ThemeName _themeName;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(typeof(ThemeName), "Default")]
        public ThemeName ThemeName
        {
            get { return _themeName; }
            set
            {
                _themeName = value;
                var item = _predefinedThemes.Find(aitem => aitem.ThemeName == value);
                this.BackColor = item.BackColor;
                this.ForeColor = item.ForeColor;
                this.BorderColorInner = item.BorderColorInner;
                this.BorderColorOuter = item.BorderColorOuter;
                this.ShineColor = item.ShineColor;
                this.GlowColor = item.GlowColor;
            }
        }

        public void LoadPredefinedTheme()
        {
            if (_predefinedThemes == null)
            {
                _predefinedThemes = new List<ButtonTheme>();
                var defaultTheme = new ButtonTheme { BackColor = SystemColors.Control, ForeColor = SystemColors.WindowText, BorderColorInner = SystemColors.ControlDark, BorderColorOuter = SystemColors.Control, ShineColor = Color.White, GlowColor = SystemColors.ControlDark };
                var aTheme = new ButtonTheme { ThemeName = ThemeName.Corp_Gray, BackColor = Color.LightGray, ForeColor = SystemColors.WindowText, BorderColorOuter = Color.White, BorderColorInner = Color.LightGray, ShineColor = Color.White, GlowColor = Color.Gainsboro };
                var bTheme = new ButtonTheme { ThemeName = ThemeName.Corp_Red, BackColor = Color.FromArgb(189, 7, 45), ForeColor = SystemColors.Info, BorderColorOuter = Color.White, BorderColorInner = Color.Red, ShineColor = Color.FromArgb(239, 19, 91), GlowColor = Color.FromArgb(143, 1, 28) };
                var cTheme = new ButtonTheme { ThemeName = ThemeName.Corp_Blue, BackColor = Color.FromArgb(84, 99, 172), ForeColor = SystemColors.Info, BorderColorOuter = Color.White, BorderColorInner = Color.LightBlue, ShineColor = Color.FromArgb(154, 123, 196), GlowColor = Color.FromArgb(14, 87, 160) };

                _predefinedThemes.Add(defaultTheme);
                _predefinedThemes.Add(aTheme);
                _predefinedThemes.Add(bTheme);
                _predefinedThemes.Add(cTheme);
            }
        }

        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
                this.Invalidate();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get { return _backColor; }
            set
            {
                if (!_backColor.Equals(value))
                {
                    _backColor = value;
                    UseVisualStyleBackColor = false;
                    CreateFrames();
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColorInner
        {
            get { return _borderColorInner; }
            set
            {
                if (_borderColorInner != value)
                {
                    _borderColorInner = value;
                    CreateFrames();
                    if (IsHandleCreated)
                        Invalidate();
                    OnInnerBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColorOuter
        {
            get { return _borderColorOuter; }
            set
            {
                if (_borderColorOuter != value)
                {
                    _borderColorOuter = value;
                    CreateFrames();
                    if (IsHandleCreated)
                        Invalidate();
                    OnOuterBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ShineColor
        {
            get { return _shineColor; }
            set
            {
                if (_shineColor != value)
                {
                    _shineColor = value;
                    CreateFrames();
                    if (IsHandleCreated)
                        Invalidate();
                    OnShineColorChanged(EventArgs.Empty);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GlowColor
        {
            get { return _glowColor; }
            set
            {
                if (_glowColor != value)
                {
                    _glowColor = value;
                    CreateFrames();
                    if (IsHandleCreated)
                        Invalidate();
                    OnGlowColorChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(false)]
        public bool FadeOnFocus { get; set; }

        [Browsable(false)]
        public PushButtonState State
        {
            get
            {
                if (!Enabled)
                    return PushButtonState.Disabled;
                if (IsPressed)
                    return PushButtonState.Pressed;
                if (_isHovered)
                    return PushButtonState.Hot;
                if (_isFocused || IsDefault)
                    return PushButtonState.Default;
                return PushButtonState.Normal;
            }
        }

        public event EventHandler InnerBorderColorChanged;

        private void OnInnerBorderColorChanged(EventArgs e)
        {
            if (InnerBorderColorChanged != null)
                InnerBorderColorChanged(this, e);
        }

        public event EventHandler OuterBorderColorChanged;

        private void OnOuterBorderColorChanged(EventArgs e)
        {
            if (OuterBorderColorChanged != null)
                OuterBorderColorChanged(this, e);
        }

        public event EventHandler ShineColorChanged;

        private void OnShineColorChanged(EventArgs e)
        {
            if (ShineColorChanged != null)
                ShineColorChanged(this, e);
        }

        public event EventHandler GlowColorChanged;

        private void OnGlowColorChanged(EventArgs e)
        {
            if (GlowColorChanged != null)
                GlowColorChanged(this, e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            CreateFrames();
            base.OnSizeChanged(e);
        }

        protected override void OnClick(EventArgs e)
        {
            _isKeyDown = _isMouseDown = false;
            base.OnClick(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            _isFocused = true;
            base.OnEnter(e);
            if (FadeOnFocus)
                FadeIn();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _isFocused = _isKeyDown = _isMouseDown = false;
            Invalidate();
            if (FadeOnFocus)
                FadeOut();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _isKeyDown = true;
                Invalidate();
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (_isKeyDown && e.KeyCode == Keys.Space)
            {
                _isKeyDown = false;
                Invalidate();
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_isMouseDown && e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _isMouseDown = false;
                Invalidate();
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.None)
            {
                if (!ClientRectangle.Contains(e.X, e.Y))
                {
                    if (_isHovered)
                    {
                        _isHovered = false;
                        Invalidate();
                    }
                }
                else if (!_isHovered)
                {
                    _isHovered = true;
                    Invalidate();
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            FadeIn();
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            FadeOut();
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawButtonBackgroundFromBuffer(e.Graphics);
            DrawForegroundFromButton(e);
            DrawButtonForeground(e.Graphics);

            if (Paint != null)
                Paint(this, e);
        }

        public new event PaintEventHandler Paint;

        private void DrawButtonBackgroundFromBuffer(Graphics graphics)
        {
            int frame;
            if (!Enabled)
                frame = FrameDisabled;
            else if (IsPressed)
                frame = FramePressed;
            else if (!IsAnimating && _currentFrame == 0)
                frame = FrameNormal;
            else
            {
                if (!HasAnimationFrames)
                    CreateFrames(true);
                frame = FrameAnimated + _currentFrame;
            }
            if (_frames == null || _frames.Count == 0)
                CreateFrames();
            if (_frames != null)
                graphics.DrawImage(_frames[frame], Point.Empty);
        }

        public Image CreateBackgroundFrame(bool pressed, bool hovered, bool animating, bool enabled, float glowOpacity)
        {
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;
            Image img = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.Clear(Color.Transparent);
                DrawButtonBackground(g, rect, pressed, hovered, animating, enabled, _borderColorOuter, _backColor, _glowColor, _shineColor, _borderColorInner, glowOpacity);
            }
            return img;
        }

        private static void DrawButtonBackground(Graphics g, Rectangle rectangle, bool pressed, bool hovered, bool animating, bool enabled,
            Color outerBorderColor, Color backColor, Color glowColor, Color shineColor, Color innerBorderColor, float glowOpacity)
        {
            var sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = rectangle;
            rect.Width--;
            rect.Height--;
            using (GraphicsPath bw = CreateRoundRectangle(rect, 4))
            {
                using (var p = new Pen(outerBorderColor))
                {
                    g.DrawPath(p, bw);
                }
            }

            rect.X++;
            rect.Y++;
            rect.Width -= 2;
            rect.Height -= 2;
            var rect2 = rect;
            rect2.Height >>= 1;

            using (GraphicsPath bb = CreateRoundRectangle(rect, 2))
            {
                var opacity = pressed ? 0x8f : 0xcc;
                using (Brush br = new SolidBrush(Color.FromArgb(opacity, backColor)))
                {
                    g.FillPath(br, bb);
                }
            }

            if ((hovered || animating) && !pressed)
            {
                using (GraphicsPath clip = CreateRoundRectangle(rect, 2))
                {
                    g.SetClip(clip, CombineMode.Intersect);
                    using (GraphicsPath brad = CreateBottomRadialPath(rect))
                    {
                        using (var pgr = new PathGradientBrush(brad))
                        {
                            unchecked
                            {
                                var opacity = (int)(0xB2 * glowOpacity + .5f);
                                var bounds = brad.GetBounds();
                                pgr.CenterPoint = new PointF((bounds.Left + bounds.Right) / 2f, (bounds.Top + bounds.Bottom) / 2f);
                                pgr.CenterColor = Color.FromArgb(opacity, glowColor);
                                pgr.SurroundColors = new[] { Color.FromArgb(0, glowColor) };
                            }
                            g.FillPath(pgr, brad);
                        }
                    }
                    g.ResetClip();
                }
            }

            if (rect2.Width > 0 && rect2.Height > 0)
            {
                rect2.Height++;
                using (var bh = CreateTopRoundRectangle(rect2, 2))
                {
                    rect2.Height++;
                    var opacity = 0x99;
                    if (pressed | !enabled)
                        opacity = (int)(.4f * opacity + .5f);
                    using (var br = new LinearGradientBrush(rect2, Color.FromArgb(opacity, shineColor), Color.FromArgb(opacity / 3, shineColor), LinearGradientMode.Vertical))
                    {
                        g.FillPath(br, bh);
                    }
                }
                rect2.Height -= 2;
            }

            using (var bb = CreateRoundRectangle(rect, 3))
            {
                using (var p = new Pen(innerBorderColor))
                {
                    g.DrawPath(p, bb);
                }
            }

            g.SmoothingMode = sm;
        }

        private void DrawButtonForeground(Graphics g)
        {
            if (Focused && ShowFocusCues /* && isFocusedByKey*/)
            {
                var rect = ClientRectangle;
                rect.Inflate(-4, -4);
                ControlPaint.DrawFocusRectangle(g, rect);
            }
        }

        private void DrawForegroundFromButton(PaintEventArgs pevent)
        {
            if (_imageButton == null)
            {
                _imageButton = new Button { Parent = new TransparentControl() };
                _imageButton.SuspendLayout();
                _imageButton.BackColor = Color.Transparent;
                _imageButton.FlatAppearance.BorderSize = 0;
                _imageButton.FlatStyle = FlatStyle.Flat;
            }
            else
                _imageButton.SuspendLayout();
            _imageButton.AutoEllipsis = AutoEllipsis;
            if (Enabled)
                _imageButton.ForeColor = ForeColor;
            else
                _imageButton.ForeColor = Color.FromArgb((3 * ForeColor.R + _backColor.R) >> 2, (3 * ForeColor.G + _backColor.G) >> 2, (3 * ForeColor.B + _backColor.B) >> 2);
            _imageButton.Font = Font;
            _imageButton.RightToLeft = RightToLeft;
            if (_imageButton.Image != Image && _imageButton.Image != null)
                _imageButton.Image.Dispose();
            if (Image != null)
            {
                _imageButton.Image = Image;
                if (!Enabled)
                {
                    var size = Image.Size;
                    var newColorMatrix = new float[5][];
                    newColorMatrix[0] = new[] { 0.2315f, 0.4135f, 0.4125f, 0f, 0f };
                    newColorMatrix[1] = new[] { 0.2767f, 0.4587f, 0.4577f, 0f, 0f };
                    newColorMatrix[2] = new[] { 0.0551f, 0.2371f, 0.2361f, 0f, 0f };
                    var arr = new float[5];
                    arr[3] = 1f;
                    newColorMatrix[3] = arr;
                    newColorMatrix[4] = new[] { 0.38f, 0.38f, 0.38f, 0f, 1f };
                    var matrix = new System.Drawing.Imaging.ColorMatrix(newColorMatrix);
                    var disabledImageAttr = new System.Drawing.Imaging.ImageAttributes();
                    disabledImageAttr.ClearColorKey();
                    disabledImageAttr.SetColorMatrix(matrix);
                    _imageButton.Image = new Bitmap(Image.Width, Image.Height);
                    using (Graphics gr = Graphics.FromImage(_imageButton.Image))
                    {
                        gr.DrawImage(Image, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, disabledImageAttr);
                    }
                }
            }
            _imageButton.ImageAlign = ImageAlign;
            _imageButton.ImageIndex = ImageIndex;
            _imageButton.ImageKey = ImageKey;
            _imageButton.ImageList = ImageList;
            _imageButton.Padding = Padding;
            _imageButton.Size = Size;
            _imageButton.Text = Text;
            _imageButton.TextAlign = TextAlign;
            _imageButton.TextImageRelation = TextImageRelation;
            _imageButton.UseCompatibleTextRendering = UseCompatibleTextRendering;
            _imageButton.UseMnemonic = UseMnemonic;
            _imageButton.ResumeLayout();
            InvokePaint(_imageButton, pevent);
        }

        private class TransparentControl : Control
        {
            protected override void OnPaintBackground(PaintEventArgs pevent) { }
            protected override void OnPaint(PaintEventArgs e) { }
        }

        private static GraphicsPath CreateRoundRectangle(Rectangle rectangle, int radius)
        {
            var path = new GraphicsPath();
            var l = rectangle.Left;
            var t = rectangle.Top;
            var w = rectangle.Width;
            var h = rectangle.Height;
            var d = radius << 1;
            path.AddArc(l, t, d, d, 180, 90);
            path.AddLine(l + radius, t, l + w - radius, t);
            path.AddArc(l + w - d, t, d, d, 270, 90);
            path.AddLine(l + w, t + radius, l + w, t + h - radius);
            path.AddArc(l + w - d, t + h - d, d, d, 0, 90);
            path.AddLine(l + w - radius, t + h, l + radius, t + h);
            path.AddArc(l, t + h - d, d, d, 90, 90);
            path.AddLine(l, t + h - radius, l, t + radius);
            path.CloseFigure();
            return path;
        }

        private static GraphicsPath CreateTopRoundRectangle(Rectangle rectangle, int radius)
        {
            var path = new GraphicsPath();
            var l = rectangle.Left;
            var t = rectangle.Top;
            var w = rectangle.Width;
            var h = rectangle.Height;
            var d = radius << 1;
            path.AddArc(l, t, d, d, 180, 90);
            path.AddLine(l + radius, t, l + w - radius, t);
            path.AddArc(l + w - d, t, d, d, 270, 90);
            path.AddLine(l + w, t + radius, l + w, t + h);
            path.AddLine(l + w, t + h, l, t + h);
            path.AddLine(l, t + h, l, t + radius);
            path.CloseFigure();
            return path;
        }

        private static GraphicsPath CreateBottomRadialPath(Rectangle rectangle)
        {
            var path = new GraphicsPath();
            RectangleF rect = rectangle;
            rect.X -= rect.Width * .35f;
            rect.Y -= rect.Height * .15f;
            rect.Width *= 1.7f;
            rect.Height *= 2.3f;
            path.AddEllipse(rect);
            path.CloseFigure();
            return path;
        }


        public new FlatButtonAppearance FlatAppearance
        {
            get { return base.FlatAppearance; }
        }

        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set { base.FlatStyle = value; }
        }

        public new bool UseVisualStyleBackColor
        {
            get { return base.UseVisualStyleBackColor; }
            set { base.UseVisualStyleBackColor = value; }
        }


        private bool HasAnimationFrames
        {
            get
            {
                return _frames != null && _frames.Count > FrameAnimated;
            }
        }

        private void CreateFrames()
        {
            CreateFrames(false);
        }

        private void CreateFrames(bool withAnimationFrames)
        {
            DestroyFrames();
            if (!IsHandleCreated)
                return;
            if (_frames == null)
                _frames = new List<Image>();
            _frames.Add(CreateBackgroundFrame(false, false, false, false, 0));
            _frames.Add(CreateBackgroundFrame(true, true, false, true, 0));
            _frames.Add(CreateBackgroundFrame(false, false, false, true, 0));
            if (!withAnimationFrames)
                return;
            for (int i = 0; i < FramesCount; i++)
            {
                _frames.Add(CreateBackgroundFrame(false, true, true, true, i / (FramesCount - 1F)));
            }
        }

        private void DestroyFrames()
        {
            if (_frames != null)
            {
                while (_frames.Count > 0)
                {
                    _frames[_frames.Count - 1].Dispose();
                    _frames.RemoveAt(_frames.Count - 1);
                }
            }
        }


        private bool IsAnimating
        {
            get
            {
                return _direction != 0;
            }
        }

        private void FadeIn()
        {
            _direction = 1;
            timer.Enabled = true;
        }

        private void FadeOut()
        {
            _direction = -1;
            timer.Enabled = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (!timer.Enabled)
                return;
            Refresh();
            _currentFrame += _direction;
            if (_currentFrame == -1)
            {
                _currentFrame = 0;
                timer.Enabled = false;
                _direction = 0;
                return;
            }
            if (_currentFrame == FramesCount)
            {
                _currentFrame = FramesCount - 1;
                timer.Enabled = false;
                _direction = 0;
            }
        }

    }

    public class ThemedDropdownButton : ThemedButton
    {
        PushButtonState _state;
        const int DropdownSectionWidth = 24;
        static readonly int BorderSize = SystemInformation.Border3DSize.Width * 2 + 3;
        bool _skipNextOpen;
        Rectangle _dropDownRectangle;
        bool _showDropdown;
        bool _isDropdownMenuVisible;
        ContextMenuStrip _mDropdownMenuStrip;
        ContextMenu _mDropdownMenu;
        TextFormatFlags _textFormatFlags = TextFormatFlags.Default;

        public ThemedDropdownButton()
        {
            AutoSize = true;
        }

        public override sealed bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [Browsable(false)]
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return DropdownMenuStrip;
            }
            set
            {
                DropdownMenuStrip = value;
            }
        }

        [DefaultValue(null)]
        public ContextMenu DropdownMenu
        {
            get { return _mDropdownMenu; }
            set
            {
                if (_mDropdownMenu != null)
                    _mDropdownMenu.Popup -= DropdownMenuPopupEventHandler;

                if (value != null)
                {
                    ShowDropdown = true;
                    value.Popup += DropdownMenuPopupEventHandler;
                }
                else
                    ShowDropdown = false;

                _mDropdownMenu = value;
            }
        }

        [DefaultValue(null)]
        public ContextMenuStrip DropdownMenuStrip
        {
            get
            {
                return _mDropdownMenuStrip;
            }
            set
            {
                if (_mDropdownMenuStrip != null)
                {
                    _mDropdownMenuStrip.Closing -= DropdownMenuStripClosingEventHandler;
                    _mDropdownMenuStrip.Opening -= DropdownMenuStripOpeningEventHandler;
                }

                if (value != null)
                {
                    ShowDropdown = true;
                    value.Closing += DropdownMenuStripClosingEventHandler;
                    value.Opening += DropdownMenuStripOpeningEventHandler;
                }
                else
                    ShowDropdown = false;

                _mDropdownMenuStrip = value;
            }
        }

        [DefaultValue(false)]
        public bool ShowDropdown
        {
            set
            {
                if (value != _showDropdown)
                {
                    _showDropdown = value;
                    Invalidate();

                    if (Parent != null)
                        Parent.PerformLayout();
                }
            }
        }

        private new PushButtonState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (!_state.Equals(value))
                {
                    _state = value;
                    Invalidate();
                }
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData.Equals(Keys.Down) && _showDropdown)
                return true;

            return base.IsInputKey(keyData);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (!_showDropdown)
            {
                base.OnGotFocus(e);
                return;
            }

            if (!State.Equals(PushButtonState.Pressed) && !State.Equals(PushButtonState.Disabled))
                State = PushButtonState.Default;
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            if (_showDropdown)
            {
                if (kevent.KeyCode.Equals(Keys.Down) && !_isDropdownMenuVisible)
                    ShowContextMenuStrip();

                else if (kevent.KeyCode.Equals(Keys.Space) && kevent.Modifiers == Keys.None)
                    State = PushButtonState.Pressed;
            }

            base.OnKeyDown(kevent);
        }

        protected override void OnKeyUp(KeyEventArgs kevent)
        {
            if (kevent.KeyCode.Equals(Keys.Space))
            {
                if (MouseButtons == MouseButtons.None)
                    State = PushButtonState.Normal;
            }
            else if (kevent.KeyCode.Equals(Keys.Apps))
            {
                if (MouseButtons == MouseButtons.None && !_isDropdownMenuVisible)
                    ShowContextMenuStrip();
            }

            base.OnKeyUp(kevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            State = Enabled ? PushButtonState.Normal : PushButtonState.Disabled;

            base.OnEnabledChanged(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!_showDropdown)
            {
                base.OnLostFocus(e);
                return;
            }

            if (!State.Equals(PushButtonState.Pressed) && !State.Equals(PushButtonState.Disabled))
                State = PushButtonState.Normal;
        }

        bool _isMouseEntered;

        protected override void OnMouseEnter(EventArgs e)
        {
            if (!_showDropdown)
            {
                base.OnMouseEnter(e);
                return;
            }

            _isMouseEntered = true;

            if (!State.Equals(PushButtonState.Pressed) && !State.Equals(PushButtonState.Disabled))
                State = PushButtonState.Hot;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!_showDropdown)
            {
                base.OnMouseLeave(e);
                return;
            }

            _isMouseEntered = false;

            if (!State.Equals(PushButtonState.Pressed) && !State.Equals(PushButtonState.Disabled))
                State = Focused ? PushButtonState.Default : PushButtonState.Normal;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_showDropdown)
            {
                base.OnMouseDown(e);
                return;
            }

            if (_mDropdownMenu != null && e.Button == MouseButtons.Left && !_isMouseEntered)
                _skipNextOpen = true;

            if (_dropDownRectangle.Contains(e.Location) && !_isDropdownMenuVisible && e.Button == MouseButtons.Left)
                ShowContextMenuStrip();
            else
                State = PushButtonState.Pressed;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (!_showDropdown)
            {
                base.OnMouseUp(mevent);
                return;
            }

            if (mevent.Button == MouseButtons.Right && ClientRectangle.Contains(mevent.Location) && !_isDropdownMenuVisible)
                ShowContextMenuStrip();
            else if (_mDropdownMenuStrip == null && _mDropdownMenu == null || !_isDropdownMenuVisible)
            {
                SetButtonDrawState();

                if (ClientRectangle.Contains(mevent.Location) && !_dropDownRectangle.Contains(mevent.Location))
                    OnClick(new EventArgs());
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (!_showDropdown)
                return;

            var g = pevent.Graphics;
            var bounds = ClientRectangle;

            if (State != PushButtonState.Pressed && IsDefault && !Application.RenderWithVisualStyles)
            {
                var backgroundBounds = bounds;
                backgroundBounds.Inflate(-1, -1);
                ButtonRenderer.DrawButton(g, backgroundBounds, State);

                g.DrawRectangle(SystemPens.WindowFrame, 0, 0, bounds.Width - 1, bounds.Height - 1);
            }
            else
                ButtonRenderer.DrawButton(g, bounds, State);

            _dropDownRectangle = new Rectangle(bounds.Right - DropdownSectionWidth, 0, DropdownSectionWidth, bounds.Height);
            var internalBorder = BorderSize;
            var focusRect = new Rectangle(internalBorder - 1, internalBorder - 1, bounds.Width - _dropDownRectangle.Width - internalBorder, bounds.Height - (internalBorder * 2) + 2);

            var drawSplitLine = (State == PushButtonState.Hot || State == PushButtonState.Pressed || !Application.RenderWithVisualStyles);

            if (RightToLeft == RightToLeft.Yes)
            {
                _dropDownRectangle.X = bounds.Left + 1;
                focusRect.X = _dropDownRectangle.Right;

                if (drawSplitLine)
                {
                    g.DrawLine(SystemPens.ButtonShadow, bounds.Left + DropdownSectionWidth, BorderSize, bounds.Left + DropdownSectionWidth, bounds.Bottom - BorderSize);
                    g.DrawLine(SystemPens.ButtonFace, bounds.Left + DropdownSectionWidth + 1, BorderSize, bounds.Left + DropdownSectionWidth + 1, bounds.Bottom - BorderSize);
                }
            }
            else
            {
                if (drawSplitLine)
                {
                    g.DrawLine(SystemPens.ButtonShadow, bounds.Right - DropdownSectionWidth, BorderSize, bounds.Right - DropdownSectionWidth, bounds.Bottom - BorderSize);
                    g.DrawLine(SystemPens.ButtonFace, bounds.Right - DropdownSectionWidth - 1, BorderSize, bounds.Right - DropdownSectionWidth - 1, bounds.Bottom - BorderSize);
                }
            }

            PaintArrow(g, _dropDownRectangle);

            PaintTextandImage(g, new Rectangle(0, 0, ClientRectangle.Width - DropdownSectionWidth, ClientRectangle.Height));

            if (State != PushButtonState.Pressed && Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(g, focusRect);
        }

        private void PaintTextandImage(Graphics g, Rectangle bounds)
        {
            Rectangle textRectangle;
            Rectangle imageRectangle;

            CalculateButtonTextAndImageLayout(ref bounds, out textRectangle, out imageRectangle);

            if (Image != null)
            {
                if (Enabled)
                    g.DrawImage(Image, imageRectangle.X, imageRectangle.Y, Image.Width, Image.Height);
                else
                    ControlPaint.DrawImageDisabled(g, Image, imageRectangle.X, imageRectangle.Y, BackColor);
            }

            if (!UseMnemonic)
                _textFormatFlags = _textFormatFlags | TextFormatFlags.NoPrefix;
            else if (!ShowKeyboardCues)
                _textFormatFlags = _textFormatFlags | TextFormatFlags.HidePrefix;

            if (!string.IsNullOrEmpty(Text))
            {
                if (Enabled)
                    TextRenderer.DrawText(g, Text, Font, textRectangle, ForeColor, _textFormatFlags);
                else
                    ControlPaint.DrawStringDisabled(g, Text, Font, BackColor, textRectangle, _textFormatFlags);
            }
        }

        private void PaintArrow(Graphics g, Rectangle dropDownRect)
        {
            var middle = new Point(Convert.ToInt32(dropDownRect.Left + dropDownRect.Width / 2), Convert.ToInt32(dropDownRect.Top + dropDownRect.Height / 2));
            middle.X += (dropDownRect.Width % 2);
            var arrow = new[] { new Point(middle.X - 4, middle.Y - 1), new Point(middle.X + 5, middle.Y - 1), new Point(middle.X, middle.Y + 4) };
            g.FillPolygon(Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow, arrow);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var preferredSize = base.GetPreferredSize(proposedSize);
            if (_showDropdown)
            {
                if (AutoSize)
                    return CalculateButtonAutoSize();

                if (!string.IsNullOrEmpty(Text) && TextRenderer.MeasureText(Text, Font).Width + DropdownSectionWidth > preferredSize.Width)
                    return preferredSize + new Size(DropdownSectionWidth + BorderSize * 2, 0);
            }

            return preferredSize;
        }

        private Size CalculateButtonAutoSize()
        {
            var retSize = Size.Empty;
            var textSize = TextRenderer.MeasureText(Text, Font);
            var imageSize = Image == null ? Size.Empty : Image.Size;

            if (Text.Length != 0)
            {
                textSize.Height += 4;
                textSize.Width += 4;
            }

            switch (TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    retSize.Height = Math.Max(Text.Length == 0 ? 0 : textSize.Height, imageSize.Height);
                    retSize.Width = Math.Max(textSize.Width, imageSize.Width);
                    break;
                case TextImageRelation.ImageAboveText:
                case TextImageRelation.TextAboveImage:
                    retSize.Height = textSize.Height + imageSize.Height;
                    retSize.Width = Math.Max(textSize.Width, imageSize.Width);
                    break;
                case TextImageRelation.ImageBeforeText:
                case TextImageRelation.TextBeforeImage:
                    retSize.Height = Math.Max(textSize.Height, imageSize.Height);
                    retSize.Width = textSize.Width + imageSize.Width;
                    break;
            }

            retSize.Height += (Padding.Vertical + 6);
            retSize.Width += (Padding.Horizontal + 6);

            if (_showDropdown)
                retSize.Width += DropdownSectionWidth;

            return retSize;
        }

        private void CalculateButtonTextAndImageLayout(ref Rectangle contentRect, out Rectangle textRectangle, out Rectangle imageRectangle)
        {
            var textSize = TextRenderer.MeasureText(Text, Font, contentRect.Size, _textFormatFlags);
            var imageSize = Image == null ? Size.Empty : Image.Size;

            textRectangle = Rectangle.Empty;
            imageRectangle = Rectangle.Empty;

            switch (TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    textRectangle = OverlayObjectRect(ref contentRect, ref textSize, TextAlign); // Rectangle.Inflate(content_rect, -4, -4);

                    if (_state == PushButtonState.Pressed && !Application.RenderWithVisualStyles)
                        textRectangle.Offset(1, 1);

                    if (Image != null)
                        imageRectangle = OverlayObjectRect(ref contentRect, ref imageSize, ImageAlign);

                    break;
                case TextImageRelation.ImageAboveText:
                    contentRect.Inflate(-4, -4);
                    LayoutTextAboveOrBelowImage(contentRect, false, textSize, imageSize, out textRectangle, out imageRectangle);
                    break;
                case TextImageRelation.TextAboveImage:
                    contentRect.Inflate(-4, -4);
                    LayoutTextAboveOrBelowImage(contentRect, true, textSize, imageSize, out textRectangle, out imageRectangle);
                    break;
                case TextImageRelation.ImageBeforeText:
                    contentRect.Inflate(-4, -4);
                    LayoutTextBeforeOrAfterImage(contentRect, false, textSize, imageSize, out textRectangle, out imageRectangle);
                    break;
                case TextImageRelation.TextBeforeImage:
                    contentRect.Inflate(-4, -4);
                    LayoutTextBeforeOrAfterImage(contentRect, true, textSize, imageSize, out textRectangle, out imageRectangle);
                    break;
            }
        }

        private static Rectangle OverlayObjectRect(ref Rectangle container, ref Size sizeOfObject, System.Drawing.ContentAlignment alignment)
        {
            int x, y;

            switch (alignment)
            {
                case System.Drawing.ContentAlignment.TopLeft:
                    x = 4;
                    y = 4;
                    break;
                case System.Drawing.ContentAlignment.TopCenter:
                    x = (container.Width - sizeOfObject.Width) / 2;
                    y = 4;
                    break;
                case System.Drawing.ContentAlignment.TopRight:
                    x = container.Width - sizeOfObject.Width - 4;
                    y = 4;
                    break;
                case System.Drawing.ContentAlignment.MiddleLeft:
                    x = 4;
                    y = (container.Height - sizeOfObject.Height) / 2;
                    break;
                case System.Drawing.ContentAlignment.MiddleCenter:
                    x = (container.Width - sizeOfObject.Width) / 2;
                    y = (container.Height - sizeOfObject.Height) / 2;
                    break;
                case System.Drawing.ContentAlignment.MiddleRight:
                    x = container.Width - sizeOfObject.Width - 4;
                    y = (container.Height - sizeOfObject.Height) / 2;
                    break;
                case System.Drawing.ContentAlignment.BottomLeft:
                    x = 4;
                    y = container.Height - sizeOfObject.Height - 4;
                    break;
                case System.Drawing.ContentAlignment.BottomCenter:
                    x = (container.Width - sizeOfObject.Width) / 2;
                    y = container.Height - sizeOfObject.Height - 4;
                    break;
                case System.Drawing.ContentAlignment.BottomRight:
                    x = container.Width - sizeOfObject.Width - 4;
                    y = container.Height - sizeOfObject.Height - 4;
                    break;
                default:
                    x = 4;
                    y = 4;
                    break;
            }

            return new Rectangle(x, y, sizeOfObject.Width, sizeOfObject.Height);
        }

        private void LayoutTextBeforeOrAfterImage(Rectangle totalArea, bool textFirst, Size textSize, Size imageSize, out Rectangle textRect, out Rectangle imageRect)
        {
            var elementSpacing = 8;
            var totalWidth = textSize.Width + elementSpacing + imageSize.Width;

            if (!textFirst)
                elementSpacing += 2;

            if (totalWidth > totalArea.Width)
            {
                textSize.Width = totalArea.Width - elementSpacing - imageSize.Width;
                totalWidth = totalArea.Width;
            }

            var excessWidth = totalArea.Width - totalWidth;
            var offset = 12;

            Rectangle finalTextRect;
            Rectangle finalImageRect;

            var hText = GetHorizontalAlignment(TextAlign);
            var hImage = GetHorizontalAlignment(ImageAlign);

            if (hImage == HorizontalAlignment.Left)
                offset = 0;
            else if (hImage == HorizontalAlignment.Right && hText == HorizontalAlignment.Right)
                offset = excessWidth;
            else if (hImage == HorizontalAlignment.Center && (hText == HorizontalAlignment.Left || hText == HorizontalAlignment.Center))
                offset += excessWidth / 3;
            else
                offset += 2 * (excessWidth / 3);

            if (textFirst)
            {
                finalTextRect = new Rectangle(totalArea.Left + offset, AlignInRectangle(totalArea, textSize, TextAlign).Top, textSize.Width, textSize.Height);
                finalImageRect = new Rectangle(finalTextRect.Right + elementSpacing, AlignInRectangle(totalArea, imageSize, ImageAlign).Top, imageSize.Width, imageSize.Height);
            }
            else
            {
                finalImageRect = new Rectangle(totalArea.Left + offset, AlignInRectangle(totalArea, imageSize, ImageAlign).Top, imageSize.Width, imageSize.Height);
                finalTextRect = new Rectangle(finalImageRect.Right + elementSpacing, AlignInRectangle(totalArea, textSize, TextAlign).Top, textSize.Width, textSize.Height);
            }

            textRect = finalTextRect;
            imageRect = finalImageRect;
        }

        private void LayoutTextAboveOrBelowImage(Rectangle totalArea, bool textFirst, Size textSize, Size imageSize, out Rectangle textRect, out Rectangle imageRect)
        {
            var elementSpacing = 0;
            var totalHeight = textSize.Height + elementSpacing + imageSize.Height;

            if (textFirst)
                elementSpacing += 2;

            if (textSize.Width > totalArea.Width)
                textSize.Width = totalArea.Width;

            if (totalHeight > totalArea.Height && textFirst)
            {
                imageSize = Size.Empty;
                totalHeight = totalArea.Height;
            }

            var excessHeight = totalArea.Height - totalHeight;
            var offset = 0;

            Rectangle finalTextRect;
            Rectangle finalImageRect;

            var vText = GetVerticalAlignment(TextAlign);
            var vImage = GetVerticalAlignment(ImageAlign);

            if (vImage == VerticalAlignment.Top)
                offset = 0;
            else if (vImage == VerticalAlignment.Bottom && vText == VerticalAlignment.Bottom)
                offset = excessHeight;
            else if (vImage == VerticalAlignment.Center && (vText == VerticalAlignment.Top || vText == VerticalAlignment.Center))
                offset += excessHeight / 3;
            else
                offset += 2 * (excessHeight / 3);

            if (textFirst)
            {
                finalTextRect = new Rectangle(AlignInRectangle(totalArea, textSize, TextAlign).Left, totalArea.Top + offset, textSize.Width, textSize.Height);
                finalImageRect = new Rectangle(AlignInRectangle(totalArea, imageSize, ImageAlign).Left, finalTextRect.Bottom + elementSpacing, imageSize.Width, imageSize.Height);
            }
            else
            {
                finalImageRect = new Rectangle(AlignInRectangle(totalArea, imageSize, ImageAlign).Left, totalArea.Top + offset, imageSize.Width, imageSize.Height);
                finalTextRect = new Rectangle(AlignInRectangle(totalArea, textSize, TextAlign).Left, finalImageRect.Bottom + elementSpacing, textSize.Width, textSize.Height);

                if (finalTextRect.Bottom > totalArea.Bottom)
                    finalTextRect.Y = totalArea.Top;
            }

            textRect = finalTextRect;
            imageRect = finalImageRect;
        }

        private static HorizontalAlignment GetHorizontalAlignment(System.Drawing.ContentAlignment align)
        {
            switch (align)
            {
                case System.Drawing.ContentAlignment.BottomLeft:
                case System.Drawing.ContentAlignment.MiddleLeft:
                case System.Drawing.ContentAlignment.TopLeft:
                    return HorizontalAlignment.Left;
                case System.Drawing.ContentAlignment.BottomCenter:
                case System.Drawing.ContentAlignment.MiddleCenter:
                case System.Drawing.ContentAlignment.TopCenter:
                    return HorizontalAlignment.Center;
                case System.Drawing.ContentAlignment.BottomRight:
                case System.Drawing.ContentAlignment.MiddleRight:
                case System.Drawing.ContentAlignment.TopRight:
                    return HorizontalAlignment.Right;
            }

            return HorizontalAlignment.Left;
        }

        private static VerticalAlignment GetVerticalAlignment(System.Drawing.ContentAlignment align)
        {
            switch (align)
            {
                case System.Drawing.ContentAlignment.TopLeft:
                case System.Drawing.ContentAlignment.TopCenter:
                case System.Drawing.ContentAlignment.TopRight:
                    return VerticalAlignment.Top;
                case System.Drawing.ContentAlignment.MiddleLeft:
                case System.Drawing.ContentAlignment.MiddleCenter:
                case System.Drawing.ContentAlignment.MiddleRight:
                    return VerticalAlignment.Center;
                case System.Drawing.ContentAlignment.BottomLeft:
                case System.Drawing.ContentAlignment.BottomCenter:
                case System.Drawing.ContentAlignment.BottomRight:
                    return VerticalAlignment.Bottom;
            }

            return VerticalAlignment.Top;
        }

        internal static Rectangle AlignInRectangle(Rectangle outer, Size inner, System.Drawing.ContentAlignment align)
        {
            var x = 0;
            var y = 0;

            if (align == System.Drawing.ContentAlignment.BottomLeft || align == System.Drawing.ContentAlignment.MiddleLeft || align == System.Drawing.ContentAlignment.TopLeft)
                x = outer.X;
            else if (align == System.Drawing.ContentAlignment.BottomCenter || align == System.Drawing.ContentAlignment.MiddleCenter || align == System.Drawing.ContentAlignment.TopCenter)
                x = Math.Max(outer.X + ((outer.Width - inner.Width) / 2), outer.Left);
            else if (align == System.Drawing.ContentAlignment.BottomRight || align == System.Drawing.ContentAlignment.MiddleRight || align == System.Drawing.ContentAlignment.TopRight)
                x = outer.Right - inner.Width;
            if (align == System.Drawing.ContentAlignment.TopCenter || align == System.Drawing.ContentAlignment.TopLeft || align == System.Drawing.ContentAlignment.TopRight)
                y = outer.Y;
            else if (align == System.Drawing.ContentAlignment.MiddleCenter || align == System.Drawing.ContentAlignment.MiddleLeft || align == System.Drawing.ContentAlignment.MiddleRight)
                y = outer.Y + (outer.Height - inner.Height) / 2;
            else if (align == System.Drawing.ContentAlignment.BottomCenter || align == System.Drawing.ContentAlignment.BottomRight || align == System.Drawing.ContentAlignment.BottomLeft)
                y = outer.Bottom - inner.Height;

            return new Rectangle(x, y, Math.Min(inner.Width, outer.Width), Math.Min(inner.Height, outer.Height));
        }

        private void ShowContextMenuStrip()
        {
            if (_skipNextOpen)
            {
                _skipNextOpen = false;
                return;
            }

            State = PushButtonState.Pressed;

            if (_mDropdownMenu != null)
                _mDropdownMenu.Show(this, new Point(0, Height));
            else if (_mDropdownMenuStrip != null)
                _mDropdownMenuStrip.Show(this, new Point(0, Height), ToolStripDropDownDirection.BelowRight);
        }

        void DropdownMenuStripOpeningEventHandler(object sender, CancelEventArgs e)
        {
            _isDropdownMenuVisible = true;
        }

        void DropdownMenuStripClosingEventHandler(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _isDropdownMenuVisible = false;

            SetButtonDrawState();

            if (e.CloseReason == ToolStripDropDownCloseReason.AppClicked)
                _skipNextOpen = (_dropDownRectangle.Contains(PointToClient(Cursor.Position))) && MouseButtons == MouseButtons.Left;
        }


        void DropdownMenuPopupEventHandler(object sender, EventArgs e)
        {
            _isDropdownMenuVisible = true;
        }

        protected override void WndProc(ref Message m)
        {
            //0x0212 == WM_EXITMENULOOP
            if (m.Msg == 0x0212)
            {
                _isDropdownMenuVisible = false;
                SetButtonDrawState();
            }

            base.WndProc(ref m);
        }

        private void SetButtonDrawState()
        {
            if (Bounds.Contains(Parent.PointToClient(Cursor.Position)))
                State = PushButtonState.Hot;
            else if (Focused)
                State = PushButtonState.Default;
            else if (!Enabled)
                State = PushButtonState.Disabled;
            else
                State = PushButtonState.Normal;
        }
    }

    public class ButtonTheme
    {
        public ThemeName ThemeName { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public Color BorderColorOuter { get; set; }
        public Color BorderColorInner { get; set; }
        public Color ShineColor { get; set; }
        public Color GlowColor { get; set; }
    }

    public enum ThemeName
    {
        Default = 0,
        Corp_Red = 1,
        Corp_Gray = 2,
        Corp_Blue = 3,
    }

}
