using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace BOC_APPLY_TOOL.Controls
{
    public class GradingProgressBar : Control
    {
        public GradingProgressBar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            this.TabStop = false;
            this.Interval = 3;
            this.BackColor = SystemColors.Control;
            this._blendColor1 = SystemColors.Control;
            this._blendColor2 = Color.Navy;
            this._borderColor = SystemColors.ControlDark;
            this._borderPen = new Pen(_borderColor);
        }

        [Browsable(false)]
        public override Color BackColor { get; set; }

        [Browsable(false)]
        public override Color ForeColor { get; set; }

        private Color _blendColor1;
        public Color BlendColor1
        {
            get { return _blendColor1; }
            set
            {
                if (_blendColor1 != value)
                {
                    _blendColor1 = value;
                    this.Invalidate();
                }
            }
        }

        private Color _blendColor2;
        public Color BlendColor2
        {
            get { return _blendColor2; }
            set
            {
                if (_blendColor2 != value)
                {
                    _blendColor2 = value;
                    this.Invalidate();
                }
            }
        }

        private Pen _borderPen;
        private Color _borderColor;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    if (_borderPen != null)
                    {
                        _borderPen.Dispose();
                        _borderPen = null;
                    }
                    _borderPen = new Pen(value);
                    this.Invalidate();
                }
            }
        }

        public ushort Interval { get; set; }

        public bool Paused { get; set; }


        private Rectangle _labelRect1;
        private Rectangle _labelRect2;

        private Thread _workerThread;

        protected override void OnSizeChanged(EventArgs e)
        {
            _labelRect1 = new Rectangle(0, 0, this.ClientRectangle.Width * 2 / 3, this.ClientRectangle.Height);
            _labelRect2 = new Rectangle(this.ClientRectangle.Width + this.ClientRectangle.Width * 1 / 3, 0, this.ClientRectangle.Width * 2 / 3, this.ClientRectangle.Height);

            if (_workerThread != null && _workerThread.IsAlive)
                _workerThread.Abort();

            _workerThread = null;
            _workerThread = new Thread(DoSpinWork);
            _workerThread.Start();
        }

        private void DoSpinWork()
        {
            var reverseMet = false;
            do
            {
                Thread.Sleep(Interval);

                _labelRect1.X++;
                if (_labelRect1.X + _labelRect1.Width == this.Width && !reverseMet)
                {
                    _labelRect2.X = this.Width;
                    reverseMet = true;
                }

                if (reverseMet)
                    _labelRect2.X--;

                if (_labelRect2.X == 0)
                    _labelRect1.X = 0 - _labelRect1.Width;

                if (_labelRect2.X == 0 - _labelRect2.Width)
                    reverseMet = false;

                this.Invalidate();
            } while (!this.IsDisposed && !this.DesignMode);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Paused)
                return;

            const int cornerRadius = 5;
            var aRectangle = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            var borderGraphicPath = CreateGraphicPathByRectangleAndRadius(aRectangle, cornerRadius);
            e.Graphics.DrawPath(this._borderPen, borderGraphicPath);
            e.Graphics.SetClip(borderGraphicPath);

            var xRectangle = new Rectangle(e.ClipRectangle.X + 2, e.ClipRectangle.Y + 2, e.ClipRectangle.Width - 4, e.ClipRectangle.Height - 4);
            var labelClipGraphicPath = CreateGraphicPathByRectangleAndRadius(xRectangle, cornerRadius);
            e.Graphics.SetClip(labelClipGraphicPath);

            using (LinearGradientBrush gradientBrush1 = new LinearGradientBrush(_labelRect1, this.BlendColor1, this.BlendColor2, LinearGradientMode.Horizontal),
             gradientBrush2 = new LinearGradientBrush(_labelRect2, this.BlendColor2, this.BlendColor1, LinearGradientMode.Horizontal))
            {
                if (_labelRect1.X > 0 && _labelRect1.X < this.Width)
                {
                    e.Graphics.FillRectangle(gradientBrush1, _labelRect1);
                    e.Graphics.FillRectangle(gradientBrush2, _labelRect2);
                }
                else
                {
                    e.Graphics.FillRectangle(gradientBrush2, _labelRect2);
                    e.Graphics.FillRectangle(gradientBrush1, _labelRect1);
                }
            }
        }

        private static GraphicsPath CreateGraphicPathByRectangleAndRadius(Rectangle rectangle, int cornerRadius)
        {
            var result = new GraphicsPath();
            result.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            result.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            result.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            result.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            result.CloseAllFigures();
            return result;
        }

        private Color Mix(Color from, Color to, float percent)
        {
            float amountFrom = 1.0f - percent;
            var result = Color.FromArgb((int)(from.A * amountFrom + to.A * percent), (int)(from.R * amountFrom + to.R * percent), (int)(from.G * amountFrom + to.G * percent), (int)(from.B * amountFrom + to.B * percent));
            return result;
        }

    }

}
