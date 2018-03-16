using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace CommonClient.Controls
{
    public class ForbiddenLayer : Form
    {
        [DllImport("user32.dll")]
        private static extern int SetParent(IntPtr hWndChild, IntPtr hWndParent); 
        
        private bool _transparentBackground = true;
        private int _alpha = 125;

        private readonly Container _components = new Container();

        private static ForbiddenLayer _forbiddenLayer = null;

        public static void ShowLayer(ContainerControl control, int alpha, bool isShowLoadingImage)
        {
            if (_forbiddenLayer == null)
            {
                _forbiddenLayer = new ForbiddenLayer(alpha, isShowLoadingImage) {FormBorderStyle = FormBorderStyle.None, WindowState = FormWindowState.Maximized, Dock = DockStyle.Fill};
                SetParent(_forbiddenLayer.Handle, control.Handle);
            }
            _forbiddenLayer.BringToFront();
            _forbiddenLayer.Enabled = true;
            _forbiddenLayer.Visible = true;
            Application.DoEvents();
        }

        public static void HideLayer()
        {
            if (_forbiddenLayer != null)
            {
                _forbiddenLayer.Visible = false;
                _forbiddenLayer.Enabled = false;
            }
            Application.DoEvents();
        }

        public ForbiddenLayer(int alpha, bool isShowLoadingImage)
        {
            SetStyle(ControlStyles.Opaque, true);
            CreateControl();

            this._alpha = alpha;
            if (isShowLoadingImage)
            {
                var picLoading = new PictureBox { BackColor = Color.White, Image = Properties.Resources.loading, Name = "pictureBox_Loading", Size = new Size(48, 48), SizeMode = PictureBoxSizeMode.AutoSize };
                picLoading.Location = new Point(this.Location.X + (this.Width - picLoading.Width) / 2, this.Location.Y - picLoading.Size.Height + (this.Height - picLoading.Height) / 2);
                picLoading.Anchor = AnchorStyles.None;
                this.Controls.Add(picLoading);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && _components != null)
            {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var labelBorderPen = new Pen(Color.Transparent))
            {
                using (var labelBackColorBrush = new SolidBrush(Color.Transparent))
                {
                    if (_transparentBackground)
                    {
                        var drawColor = Color.FromArgb(this._alpha, this.BackColor);
                        labelBorderPen.Color = drawColor;
                        labelBorderPen.Width = 0;
                        labelBackColorBrush.Color = drawColor;
                    }
                    else
                    {
                        labelBorderPen.Color = this.BackColor;
                        labelBorderPen.Width = 0;
                        labelBackColorBrush.Color = this.BackColor;
                    }
                    base.OnPaint(e);
                    e.Graphics.DrawRectangle(labelBorderPen, 0, 0, this.Size.Width, this.Size.Height);
                    e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, this.Size.Width, this.Size.Height);
                }
            }
        }



        public bool TransparentBackground
        {
            get
            {
                return _transparentBackground;
            }
            set
            {
                _transparentBackground = value;
                this.Invalidate();
            }
        }

        public int Alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                _alpha = value;
                this.Invalidate();
            }
        }
    }


}
