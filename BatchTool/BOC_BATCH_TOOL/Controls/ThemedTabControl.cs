using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BOC_BATCH_TOOL.Controls
{
 public class ThemedTabControl : TabControl
    {
        private UpDownButtonNativeWindow _upDownButtonNativeWindow;
        private Color _baseColor = Color.FromArgb(166, 222, 255);
        private Color _growColor = Color.FromArgb(23, 169, 254);
        private Color _backColor = Color.Transparent; // Color.FromArgb(234, 247, 254);
        private Color _borderColor = Color.FromArgb(23, 169, 254);
        private Color _arrowColor = Color.FromArgb(0, 79, 125);

        private const string UpDownButtonClassName = "msctls_updown32";
        private int _radius = 1;
        private static readonly object EventPaintUpDownButton = new object();


        public ThemedTabControl()
            : base()
        {
            SetStyles();
        }


        public event UpDownButtonPaintEventHandler PaintUpDownButton
        {
            add { base.Events.AddHandler(EventPaintUpDownButton, value); }
            remove { base.Events.RemoveHandler(EventPaintUpDownButton, value); }
        }


        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color BaseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "234, 247, 254")]
        public Color GrowColor
        {
            get { return _growColor; }
            set
            {
                _growColor = value;
                base.Invalidate(true);
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(Color), "234, 247, 254")]
        public override Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "23, 169, 254")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "0, 95, 152")]
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set
            {
                _arrowColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(int), "1")]
        public int CornerRadius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                base.Invalidate(true);
            }
        }


        internal IntPtr UpDownButtonHandle
        {
            get { return FindUpDownButton(); }
        }


        protected virtual void OnPaintUpDownButton(UpDownButtonPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;

            Color upButtonBaseColor = _baseColor;
            Color upButtonBorderColor = _borderColor;
            Color upButtonArrowColor = _arrowColor;

            Color downButtonBaseColor = _baseColor;
            Color downButtonBorderColor = _borderColor;
            Color downButtonArrowColor = _arrowColor;

            Rectangle upButtonRect = rect;
            upButtonRect.X += 4;
            upButtonRect.Y += 4;
            upButtonRect.Width = rect.Width / 2 - 8;
            upButtonRect.Height -= 8;

            Rectangle downButtonRect = rect;
            downButtonRect.X = upButtonRect.Right + 2;
            downButtonRect.Y += 4;
            downButtonRect.Width = rect.Width / 2 - 8;
            downButtonRect.Height -= 8;

            if (Enabled)
            {
                if (e.MouseOver)
                {
                    if (e.MousePress)
                    {
                        if (e.MouseInUpButton)
                            upButtonBaseColor = GetColor(_baseColor, 0, -35, -24, -9);
                        else
                            downButtonBaseColor = GetColor(_baseColor, 0, -35, -24, -9);
                    }
                    else
                    {
                        if (e.MouseInUpButton)
                            upButtonBaseColor = GetColor(_baseColor, 0, 35, 24, 9);
                        else
                            downButtonBaseColor = GetColor(_baseColor, 0, 35, 24, 9);
                    }
                }
            }
            else
            {
                upButtonBaseColor = SystemColors.Control;
                upButtonBorderColor = SystemColors.ControlDark;
                upButtonArrowColor = SystemColors.ControlDark;

                downButtonBaseColor = SystemColors.Control;
                downButtonBorderColor = SystemColors.ControlDark;
                downButtonArrowColor = SystemColors.ControlDark;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color backColor = Enabled ? _backColor : SystemColors.Control;

            using (SolidBrush brush = new SolidBrush(_backColor))
            {
                rect.Inflate(1, 1);
                g.FillRectangle(brush, rect);
            }

            RenderButton(g, upButtonRect, upButtonBaseColor, upButtonBorderColor, upButtonArrowColor, ArrowDirection.Left);
            RenderButton(g, downButtonRect, downButtonBaseColor, downButtonBorderColor, downButtonArrowColor, ArrowDirection.Right);

            var handler = base.Events[EventPaintUpDownButton] as UpDownButtonPaintEventHandler;
            if (handler != null)
                handler(this, e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            base.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTabContrl(e.Graphics);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (_upDownButtonNativeWindow != null)
                _upDownButtonNativeWindow.Dispose();
            _upDownButtonNativeWindow = null;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
            }
        }


        private IntPtr FindUpDownButton()
        {
            return NativeMethods.FindWindowEx(base.Handle, IntPtr.Zero, UpDownButtonClassName, null);
        }

        private void SetStyles()
        {
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }

        private void DrawTabContrl(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawDrawBackgroundAndHeader(g);
            DrawTabPages(g);
            DrawBorder(g);
        }

        private void DrawDrawBackgroundAndHeader(Graphics g)
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            switch (Alignment)
            {
                case TabAlignment.Top:
                    x = 0;
                    y = 0;
                    width = ClientRectangle.Width;
                    height = ClientRectangle.Height - DisplayRectangle.Height;
                    break;
                case TabAlignment.Bottom:
                    x = 0;
                    y = DisplayRectangle.Height;
                    width = ClientRectangle.Width;
                    height = ClientRectangle.Height - DisplayRectangle.Height;
                    break;
                case TabAlignment.Left:
                    x = 0;
                    y = 0;
                    width = ClientRectangle.Width - DisplayRectangle.Width;
                    height = ClientRectangle.Height;
                    break;
                case TabAlignment.Right:
                    x = DisplayRectangle.Width;
                    y = 0;
                    width = ClientRectangle.Width - DisplayRectangle.Width;
                    height = ClientRectangle.Height;
                    break;
            }

            var headerRect = new Rectangle(x, y, width, height);
            var backColor = Enabled ? _backColor : SystemColors.Control;
            using (var brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, ClientRectangle);
                g.FillRectangle(brush, headerRect);
            }
        }

        private void DrawTabPages(Graphics g)
        {
            Rectangle tabRect;
            Point cusorPoint = PointToClient(MousePosition);
            bool hover;
            bool selected;
            bool hasSetClip = false;

            IntPtr upDownButtonHandle = UpDownButtonHandle;
            bool hasUpDown = upDownButtonHandle != IntPtr.Zero;
            if (hasUpDown)
            {
                if (NativeMethods.IsWindowVisible(upDownButtonHandle))
                {
                    var upDownButtonRect = new NativeMethods.RECT();
                    NativeMethods.GetWindowRect(upDownButtonHandle, ref upDownButtonRect);
                    Rectangle upDownRect = Rectangle.FromLTRB(upDownButtonRect.Left, upDownButtonRect.Top, upDownButtonRect.Right, upDownButtonRect.Bottom);
                    upDownRect = RectangleToClient(upDownRect);

                    switch (Alignment)
                    {
                        case TabAlignment.Top:
                            upDownRect.Y = 0;
                            break;
                        case TabAlignment.Bottom:
                            upDownRect.Y = ClientRectangle.Height - DisplayRectangle.Height;
                            break;
                    }
                    upDownRect.Height = ClientRectangle.Height;
                    g.SetClip(upDownRect, CombineMode.Exclude);
                    hasSetClip = true;
                }
            }

            for (int index = 0; index < base.TabCount; index++)
            {
                TabPage page = TabPages[index];

                tabRect = GetTabRect(index);
                hover = tabRect.Contains(cusorPoint);
                selected = SelectedIndex == index;

                var baseColor = Color.LightGray;
                var borderColor = _borderColor;

                if (selected)
                    baseColor = GetColor(_growColor, 0, -45, -30, -14);
                else if (hover)
                    baseColor = GetColor(_growColor, 0, 35, 24, 9);

                RenderTabBackgroundInternal(g, tabRect, baseColor, borderColor, .45F, LinearGradientMode.Vertical);

                bool hasImage = false;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                if (ImageList != null)
                {
                    Image image = null;
                    if (page.ImageIndex != -1)
                        image = ImageList.Images[page.ImageIndex];
                    else if (page.ImageKey != null)
                        image = ImageList.Images[page.ImageKey];

                    if (image != null)
                    {
                        hasImage = true;
                        g.DrawImage(image, new Rectangle(tabRect.X + _radius / 2 + 2, tabRect.Y + 2, tabRect.Height - 4, tabRect.Height - 4), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                    }
                }

                Rectangle textRect = tabRect;

                if (hasImage)
                {
                    textRect.X = tabRect.X + _radius / 2 + tabRect.Height - 2;
                    textRect.Width = tabRect.Width - _radius - tabRect.Height;
                }

                TextRenderer.DrawText(g, page.Text, page.Font, textRect, page.ForeColor);
            }
            if (hasSetClip)
                g.ResetClip();
        }

        private void DrawBorder(Graphics g)
        {
            if (SelectedIndex > -1 && SelectedIndex < this.TabPages.Count) // (SelectedIndex != -1)
            {
                var tabRect = GetTabRect(SelectedIndex);
                var clipRect = ClientRectangle;
                var points = new Point[6];

                IntPtr upDownButtonHandle = UpDownButtonHandle;
                bool hasUpDown = upDownButtonHandle != IntPtr.Zero;
                if (hasUpDown)
                {
                    if (NativeMethods.IsWindowVisible(upDownButtonHandle))
                    {
                        var upDownButtonRect = new NativeMethods.RECT();
                        NativeMethods.GetWindowRect(upDownButtonHandle, ref upDownButtonRect);
                        var upDownRect = Rectangle.FromLTRB(upDownButtonRect.Left, upDownButtonRect.Top, upDownButtonRect.Right, upDownButtonRect.Bottom);
                        upDownRect = RectangleToClient(upDownRect);

                        tabRect.X = tabRect.X > upDownRect.X ? upDownRect.X : tabRect.X;
                        tabRect.Width = tabRect.Right > upDownRect.X ? upDownRect.X - tabRect.X : tabRect.Width;
                    }
                }

                switch (Alignment)
                {
                    case TabAlignment.Top:
                        points[0] = new Point(tabRect.X, tabRect.Bottom);
                        points[1] = new Point(clipRect.X, tabRect.Bottom);
                        points[2] = new Point(clipRect.X, clipRect.Bottom - 1);
                        points[3] = new Point(clipRect.Right - 1, clipRect.Bottom - 1);
                        points[4] = new Point(clipRect.Right - 1, tabRect.Bottom);
                        points[5] = new Point(tabRect.Right, tabRect.Bottom);
                        break;
                    case TabAlignment.Bottom:
                        points[0] = new Point(tabRect.X, tabRect.Y);
                        points[1] = new Point(clipRect.X, tabRect.Y);
                        points[2] = new Point(clipRect.X, clipRect.Y);
                        points[3] = new Point(clipRect.Right - 1, clipRect.Y);
                        points[4] = new Point(clipRect.Right - 1, tabRect.Y);
                        points[5] = new Point(tabRect.Right, tabRect.Y);
                        break;
                }
                using (var pen = new Pen(_borderColor))
                {
                    g.DrawLines(pen, points);
                }
            }
        }

        internal void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
        {
            var point = new Point(dropDownRect.Left + (dropDownRect.Width / 2), dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { 
                        new Point(point.X + 1, point.Y - 4), 
                        new Point(point.X + 1, point.Y + 4), 
                        new Point(point.X - 2, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { 
                        new Point(point.X - 3, point.Y + 1), 
                        new Point(point.X + 3, point.Y + 1), 
                        new Point(point.X, point.Y - 1) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - 1, point.Y - 4), 
                        new Point(point.X - 1, point.Y + 4), 
                        new Point(point.X + 2, point.Y) };
                    break;

                default:
                    points = new Point[] {
                        new Point(point.X - 3, point.Y - 1), 
                        new Point(point.X + 3, point.Y - 1), 
                        new Point(point.X, point.Y + 1) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal void RenderButton(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color arrowColor, ArrowDirection direction)
        {
            RenderBackgroundInternal(g, rect, baseColor, borderColor, 0.45f, true, LinearGradientMode.Vertical);
            using (var brush = new SolidBrush(arrowColor))
            {
                RenderArrowInternal(g, rect, direction, brush);
            }
        }

        internal void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, float basePosition, bool drawBorder, LinearGradientMode mode)
        {
            using (var brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
            {
                var colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                var blend = new ColorBlend { Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f }, Colors = colors };
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                else
                    rectTop.Width = (int)(rect.Width * basePosition);
                using (SolidBrush brushAlpha = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }

            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        internal void RenderTabBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, float basePosition, LinearGradientMode mode)
        {
            using (var path = CreateTabPath(rect))
            {
                using (var brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
                {
                    var colors = new Color[4];
                    colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                    colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                    colors[2] = baseColor;
                    colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                    var blend = new ColorBlend();
                    blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                    blend.Colors = colors;
                    brush.InterpolationColors = blend;
                    g.FillPath(brush, path);
                }

                if (baseColor.A > 80)
                {
                    Rectangle rectTop = rect;
                    if (mode == LinearGradientMode.Vertical)
                        rectTop.Height = (int)(rectTop.Height * basePosition);
                    else
                        rectTop.Width = (int)(rect.Width * basePosition);
                    using (SolidBrush brushAlpha = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                    {
                        g.FillRectangle(brushAlpha, rectTop);
                    }
                }

                //g.DrawRectangle(new Pen(Color.Red), rect);

                rect.Inflate(-1, -1);
                using (GraphicsPath path1 = CreateTabPath(rect))
                {
                    using (Pen pen = new Pen(Color.FromArgb(255, 255, 255)))
                    {
                        g.DrawLines(pen, path1.PathPoints);
                    }
                }

                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawLines(pen, path.PathPoints);
                }
            }
        }

        private GraphicsPath CreateTabPath(Rectangle rect)
        {
            var path = new GraphicsPath();
            switch (Alignment)
            {
                case TabAlignment.Top:
                    path.AddArc(rect.X - _radius / 2, rect.Bottom - _radius, _radius, _radius, 90F, -90F);
                    path.AddArc(rect.X + _radius / 2, rect.Y, _radius, _radius, 180F, 90F);
                    path.AddArc(rect.Right - _radius - _radius / 2, rect.Y, _radius, _radius, 270F, 90F);
                    path.AddArc(rect.Right - _radius / 2, rect.Bottom - _radius, _radius, _radius, 180F, -90F);
                    break;
                case TabAlignment.Bottom:
                    path.AddArc(rect.X - _radius / 2, rect.Y, _radius, _radius, 270, 90);
                    path.AddArc(rect.X + _radius / 2, rect.Bottom - _radius, _radius, _radius, 180, -90);
                    path.AddArc(rect.Right - _radius - _radius / 2, rect.Bottom - _radius, _radius, _radius, 90, -90);
                    path.AddArc(rect.Right - _radius / 2, rect.Y, _radius, _radius, 180, 90);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }


        private class UpDownButtonNativeWindow : NativeWindow, IDisposable
        {
            private ThemedTabControl _owner;
            private bool _bPainting;

            public UpDownButtonNativeWindow(ThemedTabControl owner)
                : base()
            {
                _owner = owner;
                base.AssignHandle(owner.UpDownButtonHandle);
            }

            private bool LeftKeyPressed()
            {
                if (SystemInformation.MouseButtonsSwapped)
                    return (NativeMethods.GetKeyState(NativeMethods.VK_RBUTTON) < 0);
                return (NativeMethods.GetKeyState(NativeMethods.VK_LBUTTON) < 0);
            }

            private void DrawUpDownButton()
            {
                bool mouseOver = false;
                bool mousePress = LeftKeyPressed();
                bool mouseInUpButton = false;

                var rect = new NativeMethods.RECT();

                NativeMethods.GetClientRect(base.Handle, ref rect);

                var clipRect = Rectangle.FromLTRB(rect.Top, rect.Left, rect.Right, rect.Bottom);

                var cursorPoint = new Point();
                NativeMethods.GetCursorPos(ref cursorPoint);
                NativeMethods.GetWindowRect(base.Handle, ref rect);

                mouseOver = NativeMethods.PtInRect(ref rect, cursorPoint);

                cursorPoint.X -= rect.Left;
                cursorPoint.Y -= rect.Top;

                mouseInUpButton = cursorPoint.X < clipRect.Width / 2;

                using (Graphics g = Graphics.FromHwnd(base.Handle))
                {
                    var e = new UpDownButtonPaintEventArgs(g, clipRect, mouseOver, mousePress, mouseInUpButton);
                    _owner.OnPaintUpDownButton(e);
                }
            }

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case NativeMethods.WM_PAINT:
                        if (!_bPainting)
                        {
                            var ps = new NativeMethods.PAINTSTRUCT();
                            _bPainting = true;
                            NativeMethods.BeginPaint(m.HWnd, ref ps);
                            DrawUpDownButton();
                            NativeMethods.EndPaint(m.HWnd, ref ps);
                            _bPainting = false;
                            m.Result = NativeMethods.TRUE;
                        }
                        else
                            base.WndProc(ref m);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }


            public void Dispose()
            {
                _owner = null;
                base.ReleaseHandle();
            }

        }

    }

    public delegate void UpDownButtonPaintEventHandler(object sender, UpDownButtonPaintEventArgs e);

    public class UpDownButtonPaintEventArgs : PaintEventArgs
    {
        private bool _mouseOver;
        private bool _mousePress;
        private bool _mouseInUpButton;

        public UpDownButtonPaintEventArgs(Graphics graphics, Rectangle clipRect, bool mouseOver, bool mousePress, bool mouseInUpButton)
            : base(graphics, clipRect)
        {
            _mouseOver = mouseOver;
            _mousePress = mousePress;
            _mouseInUpButton = mouseInUpButton;
        }

        public bool MouseOver
        {
            get { return _mouseOver; }
        }

        public bool MousePress
        {
            get { return _mousePress; }
        }

        public bool MouseInUpButton
        {
            get { return _mouseInUpButton; }
        }
    }

    internal class NativeMethods
    {
        public const int WM_PAINT = 0xF;

        public const int VK_LBUTTON = 0x1;
        public const int VK_RBUTTON = 0x2;

        private const int TCM_FIRST = 0x1300;
        public const int TCM_GETITEMRECT = (TCM_FIRST + 10);

        public static readonly IntPtr TRUE = new IntPtr(1);

        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            internal IntPtr hdc;
            internal int fErase;
            internal RECT rcPaint;
            internal int fRestore;
            internal int fIncUpdate;
            internal int Reserved1;
            internal int Reserved2;
            internal int Reserved3;
            internal int Reserved4;
            internal int Reserved5;
            internal int Reserved6;
            internal int Reserved7;
            internal int Reserved8;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            internal RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(
            IntPtr hwndParent,
            IntPtr hwndChildAfter,
            string lpszClass,
            string lpszWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            IntPtr hWnd, int Msg, int wParam, ref RECT lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        public extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(IntPtr hwnd);
    }
}
