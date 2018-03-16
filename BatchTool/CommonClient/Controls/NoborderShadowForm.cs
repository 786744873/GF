using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CommonClient.Controls
{
    public partial class NoborderShadowForm : Form
    {
        protected const int CS_DROPSHADOW = 0x20000;
        protected const int GCL_STYLE = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public NoborderShadowForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DROPSHADOW);
        }
    }
}
