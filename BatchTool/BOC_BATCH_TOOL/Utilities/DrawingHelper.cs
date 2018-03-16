using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BOC_BATCH_TOOL.Utilities
{
    public class DrawingHelper
    {
        // sample code
        //protected void Test()
        //{
        //    Bitmap bm = new Bitmap(800, 600);
        //    Graphics g = Graphics.FromImage(bm);
        //    g.FillRectangle(Brushes.White, new Rectangle(0, 0, 800, 600));
        //    FillRoundRectangle(g, Brushes.Plum, new Rectangle(100, 100, 100, 100), 8);
        //    DrawRoundRectangle(g, Pens.Yellow, new Rectangle(100, 100, 100, 100), 8);
        //    bm.Save(Response.OutputStream, ImageFormat.Jpeg);
        //    g.Dispose();
        //    bm.Dispose();
        //}

        public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }

        public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            var roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        public static Icon GetFileIcon(string fileName, bool largeIcon)
        {
            var info = new SHFILEINFO(true);
            int cbFileInfo = Marshal.SizeOf(info);
            SHGFI flags;
            if (largeIcon)
                flags = SHGFI.Icon | SHGFI.LargeIcon | SHGFI.UseFileAttributes;
            else
                flags = SHGFI.Icon | SHGFI.SmallIcon | SHGFI.UseFileAttributes;

            SHGetFileInfo(fileName, 256, out info, (uint)cbFileInfo, flags);
            if (info.hIcon.ToInt32() > 0)
                return Icon.FromHandle(info.hIcon);
            else
                return null;
        }

        public static Image GetSnapshotFromControl(Control control, ImageFormat imageFormat)
        {
            ////Graphics graphics = Graphics.FromHwnd(control.Handle);
            ////graphics.Flush(FlushIntention.Flush);
            ////graphics.Save();
            ////Bitmap bitmap = new Bitmap(control.Bounds.Width, control.Bounds.Height);
            ////bitmap.Clone(control.ClientRectangle, PixelFormat.Format16bppArgb1555);
            ////bitmap.Save("c:\\abc.gif");
            //control.Invalidate();
            //Image image = new Bitmap(control.ClientRectangle.Width, control.ClientRectangle.Height);
            //using (Graphics graphics = Graphics.FromImage(image))
            //{
            //    Point ZeroLocation = new Point(0, 0);
            //    Point ScrLocation = control.PointToScreen(ZeroLocation);
            //    graphics.CopyFromScreen(ScrLocation, ZeroLocation, control.ClientRectangle.Size, CopyPixelOperation.SourcePaint);
            //    IntPtr dc = graphics.GetHdc();
            //    graphics.ReleaseHdc(dc);
            //}
            //MemoryStream stream = new MemoryStream();
            //image.Save(stream, ImageCodecInfo.GetImageEncoders().);
            //stream.Seek(0, SeekOrigin.Begin);
            //Image result = new Bitmap(stream);
            //return result;

            control.Refresh();
            Graphics grpScreen = Graphics.FromHwnd(control.Handle);
            Bitmap bitmap = new Bitmap(control.Bounds.Width, control.Bounds.Height, grpScreen);
            Graphics grpBitmap = Graphics.FromImage(bitmap);
            IntPtr hdcScreen = grpScreen.GetHdc();
            IntPtr hdcBitmap = grpBitmap.GetHdc();
            BitBlt(hdcBitmap, 0, 0, bitmap.Width, bitmap.Height, hdcScreen, 0, 0, 0x00CC0020);
            grpBitmap.ReleaseHdc(hdcBitmap);
            grpScreen.ReleaseHdc(hdcScreen);
            grpBitmap.Dispose();
            grpScreen.Dispose();

            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, imageFormat);
            stream.Seek(0, SeekOrigin.Begin);
            Image result = new Bitmap(stream);
            return result;
        }


        [DllImport("Gdi32.dll")]
        public static extern bool BitBlt(
         IntPtr hdcDest,
         int nXDest,
         int nYDest,
         int nWidth,
         int nHeight,
         IntPtr hdcSrc,
         int nXSrc,
         int nYSrc,
         System.Int32 dwRop
         );

        [DllImport("Shell32.dll")]
        private static extern int SHGetFileInfo
          (
          string pszPath,
          uint dwFileAttributes,
          out   SHFILEINFO psfi,
          uint cbfileInfo,
          SHGFI uFlags
          );

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero;
                iIcon = 0;
                dwAttributes = 0;
                szDisplayName = string.Empty;
                szTypeName = string.Empty;
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
            public string szTypeName;
        };

        private enum SHGFI
        {
            SmallIcon = 0x00000001,
            LargeIcon = 0x00000000,
            Icon = 0x00000100,
            DisplayName = 0x00000200,
            Typename = 0x00000400,
            SysIconIndex = 0x00004000,
            UseFileAttributes = 0x00000010
        }
    }
}
