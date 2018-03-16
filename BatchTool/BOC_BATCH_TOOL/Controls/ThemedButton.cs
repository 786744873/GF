using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BOC_BATCH_TOOL.Properties;

namespace BOC_BATCH_TOOL.Controls
{
    public sealed partial class ThemedButton : Button
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

        public ThemeName _themeName;
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

                _predefinedThemes.Add(defaultTheme);
                _predefinedThemes.Add(aTheme);
                _predefinedThemes.Add(bTheme);
            }
        }

        public Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = Image;
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
        Corp_Gray = 2
    }

}
