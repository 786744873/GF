using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace CommonClient.Utilities
{
    public static class ClientUtilities
    {
        public static string MainAssemblyFileVersion
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                if (attributes.Length == 0)
                    return string.Empty;
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public Size ptReserved;
        public Size ptMaxSize;
        public Point ptMaxPosition;
        public Size ptMinTrackSize;
        public Size ptMaxTrackSize;
    }

    public class NativeHelper
    {
        public class TrackMouseEvent
        {
            public int CbSize = Marshal.SizeOf(typeof(TrackMouseEvent));
            public int DwFlags;
            public IntPtr HwndTrack;
            public int DwHoverTime = 100;
            public TrackMouseEvent()
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Input
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        public class INPUT
        {
            public const int MOUSE = 0;
            public const int KEYBOARD = 1;
            public const int HARDWARE = 2;
        }

        public static class KeyboardConstaint
        {
            public static readonly short VK_F1 = 0x70;
            public static readonly short VK_F2 = 0x71;
            public static readonly short VK_F3 = 0x72;
            public static readonly short VK_F4 = 0x73;
            public static readonly short VK_F5 = 0x74;
            public static readonly short VK_F6 = 0x75;
            public static readonly short VK_F7 = 0x76;
            public static readonly short VK_F8 = 0x77;
            public static readonly short VK_F9 = 0x78;
            public static readonly short VK_F10 = 0x79;
            public static readonly short VK_F11 = 0x7A;
            public static readonly short VK_F12 = 0x7B;

            public static readonly short VK_LEFT = 0x25;
            public static readonly short VK_UP = 0x26;
            public static readonly short VK_RIGHT = 0x27;
            public static readonly short VK_DOWN = 0x28;

            public static readonly short VK_NONE = 0x00;
            public static readonly short VK_ESCAPE = 0x1B;
            public static readonly short VK_EXECUTE = 0x2B;
            public static readonly short VK_CANCEL = 0x03;
            public static readonly short VK_RETURN = 0x0D;
            public static readonly short VK_ACCEPT = 0x1E;
            public static readonly short VK_BACK = 0x08;
            public static readonly short VK_TAB = 0x09;
            public static readonly short VK_DELETE = 0x2E;
            public static readonly short VK_CAPITAL = 0x14;
            public static readonly short VK_NUMLOCK = 0x90;
            public static readonly short VK_SPACE = 0x20;
            public static readonly short VK_DECIMAL = 0x6E;
            public static readonly short VK_SUBTRACT = 0x6D;

            public static readonly short VK_ADD = 0x6B;
            public static readonly short VK_DIVIDE = 0x6F;
            public static readonly short VK_MULTIPLY = 0x6A;
            public static readonly short VK_INSERT = 0x2D;

            public static readonly short VK_OEM_1 = 0xBA;  // ';:' for US
            public static readonly short VK_OEM_PLUS = 0xBB;  // '+' any country

            public static readonly short VK_OEM_MINUS = 0xBD;  // '-' any country

            public static readonly short VK_OEM_2 = 0xBF;  // '/?' for US
            public static readonly short VK_OEM_3 = 0xC0;  // '`~' for US
            public static readonly short VK_OEM_4 = 0xDB;  //  '[{' for US
            public static readonly short VK_OEM_5 = 0xDC;  //  '/|' for US
            public static readonly short VK_OEM_6 = 0xDD;  //  ']}' for US
            public static readonly short VK_OEM_7 = 0xDE;  //  ''"' for US
            public static readonly short VK_OEM_PERIOD = 0xBE;  // '.>' any country
            public static readonly short VK_OEM_COMMA = 0xBC;  // ',<' any country
            public static readonly short VK_SHIFT = 0x10;
            public static readonly short VK_CONTROL = 0x11;
            public static readonly short VK_MENU = 0x12;
            public static readonly short VK_LWIN = 0x5B;
            public static readonly short VK_RWIN = 0x5C;
            public static readonly short VK_APPS = 0x5D;

            public static readonly short VK_LSHIFT = 0xA0;
            public static readonly short VK_RSHIFT = 0xA1;
            public static readonly short VK_LCONTROL = 0xA2;
            public static readonly short VK_RCONTROL = 0xA3;
            public static readonly short VK_LMENU = 0xA4;
            public static readonly short VK_RMENU = 0xA5;

            public static readonly short VK_SNAPSHOT = 0x2C;
            public static readonly short VK_SCROLL = 0x91;
            public static readonly short VK_PAUSE = 0x13;
            public static readonly short VK_HOME = 0x24;

            public static readonly short VK_NEXT = 0x22;
            public static readonly short VK_PRIOR = 0x21;
            public static readonly short VK_END = 0x23;

            public static readonly short VK_NUMPAD0 = 0x60;
            public static readonly short VK_NUMPAD1 = 0x61;
            public static readonly short VK_NUMPAD2 = 0x62;
            public static readonly short VK_NUMPAD3 = 0x63;
            public static readonly short VK_NUMPAD4 = 0x64;
            public static readonly short VK_NUMPAD5 = 0x65;
            public static readonly short VK_NUMPAD5NOTHING = 0x0C;
            public static readonly short VK_NUMPAD6 = 0x66;
            public static readonly short VK_NUMPAD7 = 0x67;
            public static readonly short VK_NUMPAD8 = 0x68;
            public static readonly short VK_NUMPAD9 = 0x69;

            public static readonly short KEYEVENTF_EXTENDEDKEY = 0x0001;
            public static readonly short KEYEVENTF_KEYUP = 0x0002;

            public static readonly int GWL_EXSTYLE = -20;
            public static readonly int WS_DISABLED = 0X8000000;
            public static readonly int WM_SETFOCUS = 0X0007;
        }

        public static void SendKeyDown(short key)
        {
            var input = new Input[1];
            input[0].type = INPUT.KEYBOARD;
            input[0].ki.wVk = key;
            input[0].ki.time = GetTickCount();

            if (SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public static void SendKeyUp(short key)
        {
            var input = new Input[1];
            input[0].type = INPUT.KEYBOARD;
            input[0].ki.wVk = key;
            input[0].ki.dwFlags = KeyboardConstaint.KEYEVENTF_KEYUP;
            input[0].ki.time = GetTickCount();

            if (SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        [DllImport("comctl32.dll", CharSet = CharSet.None, ExactSpelling = true)]
        public static extern bool _TrackMouseEvent(TrackMouseEvent tme);

        [DllImport("Kernel32.dll", EntryPoint = "GetTickCount", CharSet = CharSet.Auto)]
        public static extern int GetTickCount();

        [DllImport("User32.dll", EntryPoint = "GetKeyState", CharSet = CharSet.Auto)]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern UInt32 SendInput(UInt32 nInputs, Input[] pInputs, Int32 cbSize);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetCapture(IntPtr h);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetCapture();

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ReleaseCapture();

        public const int GWL_STYLE = -20;

        public static int LOWORD(int n)
        {
            return n & 0xffff;
        }

        public static int HIWORD(int n)
        {
            return n >> 16 & 0xffff;
        }

       
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static int SendMessage(IntPtr hwnd, int wMsg, int wParam, string lParam);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, [MarshalAs(UnmanagedType.LPTStr)]string lpszClass, [MarshalAs(UnmanagedType.LPTStr)]string lpszWindow);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static int GetWindowLong(IntPtr hWnd, int dwStyle);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static int GetClientRect(IntPtr hwnd, ref Rectangle rc);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static int GetWindowRect(IntPtr hwnd, ref Rectangle rc);

        public const int EC_LEFTMARGIN = 0x1;
        public const int EC_RIGHTMARGIN = 0x2;
        public const int EC_USEFONTINFO = 0xFFFF;
        public const int EM_SETMARGINS = 0xD3;
        public const int EM_GETMARGINS = 0xD4;

        public const int WM_ACTIVATE = 0x0006;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_AFXFIRST = 0x0360;
        public const int WM_AFXLAST = 0x037F;
        public const int WM_APP = 0x8000;
        public const int WM_ASKCBFORMATNAME = 0x030C;
        public const int WM_CANCELJOURNAL = 0x004B;
        public const int WM_CANCELMODE = 0x001F;
        public const int WM_CAPTURECHANGED = 0x0215;
        public const int WM_CHANGECBCHAIN = 0x030D;
        public const int WM_CHANGEUISTATE = 0x0127;
        public const int WM_CHAR = 0x0102;
        public const int WM_CHARTOITEM = 0x002F;
        public const int WM_CHILDACTIVATE = 0x0022;
        public const int WM_CLEAR = 0x0303;
        public const int WM_CLOSE = 0x0010;
        public const int WM_COMMAND = 0x0111;
        public const int WM_COMPACTING = 0x0041;
        public const int WM_COMPAREITEM = 0x0039;
        public const int WM_CONTEXTMENU = 0x007B;
        public const int WM_COPY = 0x0301;
        public const int WM_COPYDATA = 0x004A;
        public const int WM_CREATE = 0x0001;
        public const int WM_CTLCOLORBTN = 0x0135;
        public const int WM_CTLCOLORDLG = 0x0136;
        public const int WM_CTLCOLOREDIT = 0x0133;
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        public const int WM_CTLCOLORMSGBOX = 0x0132;
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        public const int WM_CTLCOLORSTATIC = 0x0138;
        public const int WM_CUT = 0x0300;
        public const int WM_DEADCHAR = 0x0103;
        public const int WM_DELETEITEM = 0x002D;
        public const int WM_DESTROY = 0x0002;
        public const int WM_DESTROYCLIPBOARD = 0x0307;
        public const int WM_DEVICECHANGE = 0x0219;
        public const int WM_DEVMODECHANGE = 0x001B;
        public const int WM_DISPLAYCHANGE = 0x007E;
        public const int WM_DRAWCLIPBOARD = 0x0308;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_DROPFILES = 0x0233;
        public const int WM_ENABLE = 0x000A;
        public const int WM_ENDSESSION = 0x0016;
        public const int WM_ENTERIDLE = 0x0121;
        public const int WM_ENTERMENULOOP = 0x0211;
        public const int WM_ENTERSIZEMOVE = 0x0231;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_EXITMENULOOP = 0x0212;
        public const int WM_EXITSIZEMOVE = 0x0232;
        public const int WM_FONTCHANGE = 0x001D;
        public const int WM_GETDLGCODE = 0x0087;
        public const int WM_GETFONT = 0x0031;
        public const int WM_GETHOTKEY = 0x0033;
        public const int WM_GETICON = 0x007F;
        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_GETOBJECT = 0x003D;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_HANDHELDFIRST = 0x0358;
        public const int WM_HANDHELDLAST = 0x035F;
        public const int WM_HELP = 0x0053;
        public const int WM_HOTKEY = 0x0312;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_HSCROLLCLIPBOARD = 0x030E;
        public const int WM_ICONERASEBKGND = 0x0027;
        public const int WM_IME_CHAR = 0x0286;
        public const int WM_IME_COMPOSITION = 0x010F;
        public const int WM_IME_COMPOSITIONFULL = 0x0284;
        public const int WM_IME_CONTROL = 0x0283;
        public const int WM_IME_ENDCOMPOSITION = 0x010E;
        public const int WM_IME_KEYDOWN = 0x0290;
        public const int WM_IME_KEYLAST = 0x010F;
        public const int WM_IME_KEYUP = 0x0291;
        public const int WM_IME_NOTIFY = 0x0282;
        public const int WM_IME_REQUEST = 0x0288;
        public const int WM_IME_SELECT = 0x0285;
        public const int WM_IME_SETCONTEXT = 0x0281;
        public const int WM_IME_STARTCOMPOSITION = 0x010D;
        public const int WM_INITDIALOG = 0x0110;
        public const int WM_INITMENU = 0x0116;
        public const int WM_INITMENUPOPUP = 0x0117;
        public const int WM_INPUTLANGCHANGE = 0x0051;
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYFIRST = 0x0100;
        public const int WM_KEYLAST = 0x0108;
        public const int WM_KEYUP = 0x0101;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MDIACTIVATE = 0x0222;
        public const int WM_MDICASCADE = 0x0227;
        public const int WM_MDICREATE = 0x0220;
        public const int WM_MDIDESTROY = 0x0221;
        public const int WM_MDIGETACTIVE = 0x0229;
        public const int WM_MDIICONARRANGE = 0x0228;
        public const int WM_MDIMAXIMIZE = 0x0225;
        public const int WM_MDINEXT = 0x0224;
        public const int WM_MDIREFRESHMENU = 0x0234;
        public const int WM_MDIRESTORE = 0x0223;
        public const int WM_MDISETMENU = 0x0230;
        public const int WM_MDITILE = 0x0226;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_MENUCHAR = 0x0120;
        public const int WM_MENUCOMMAND = 0x0126;
        public const int WM_MENUDRAG = 0x0123;
        public const int WM_MENUGETOBJECT = 0x0124;
        public const int WM_MENURBUTTONUP = 0x0122;
        public const int WM_MENUSELECT = 0x011F;
        public const int WM_MOUSEACTIVATE = 0x0021;
        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELAST = 0x020D;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_MOUSEHWHEEL = 0x020E;
        public const int WM_MOVE = 0x0003;
        public const int WM_MOVING = 0x0216;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCDESTROY = 0x0082;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        public const int WM_NCMBUTTONUP = 0x00A8;
        public const int WM_NCMOUSEMOVE = 0x00A0;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        public const int WM_NCRBUTTONUP = 0x00A5;
        public const int WM_NEXTDLGCTL = 0x0028;
        public const int WM_NEXTMENU = 0x0213;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_NOTIFYFORMAT = 0x0055;
        public const int WM_NULL = 0x0000;
        public const int WM_PAINT = 0x000F;
        public const int WM_PAINTCLIPBOARD = 0x0309;
        public const int WM_PAINTICON = 0x0026;
        public const int WM_PALETTECHANGED = 0x0311;
        public const int WM_PALETTEISCHANGING = 0x0310;
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_PASTE = 0x0302;
        public const int WM_PENWINFIRST = 0x0380;
        public const int WM_PENWINLAST = 0x038F;
        public const int WM_POWER = 0x0048;
        public const int WM_POWERBROADCAST = 0x0218;
        public const int WM_PRINT = 0x0317;
        public const int WM_PRINTCLIENT = 0x0318;
        public const int WM_QUERYDRAGICON = 0x0037;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_QUERYNEWPALETTE = 0x030F;
        public const int WM_QUERYOPEN = 0x0013;
        public const int WM_QUEUESYNC = 0x0023;
        public const int WM_QUIT = 0x0012;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RENDERALLFORMATS = 0x0306;
        public const int WM_RENDERFORMAT = 0x0305;
        public const int WM_SETCURSOR = 0x0020;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_SETFONT = 0x0030;
        public const int WM_SETHOTKEY = 0x0032;
        public const int WM_SETICON = 0x0080;
        public const int WM_SETREDRAW = 0x000B;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int WM_SIZE = 0x0005;
        public const int WM_SIZECLIPBOARD = 0x030B;
        public const int WM_SIZING = 0x0214;
        public const int WM_SPOOLERSTATUS = 0x002A;
        public const int WM_STYLECHANGED = 0x007D;
        public const int WM_STYLECHANGING = 0x007C;
        public const int WM_SYNCPAINT = 0x0088;
        public const int WM_SYSCHAR = 0x0106;
        public const int WM_SYSCOLORCHANGE = 0x0015;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int WM_TCARD = 0x0052;
        public const int WM_TIMECHANGE = 0x001E;
        public const int WM_TIMER = 0x0113;
        public const int WM_UNDO = 0x0304;
        public const int WM_UNINITMENUPOPUP = 0x0125;
        public const int WM_USER = 0x0400;
        public const int WM_USERCHANGED = 0x0054;
        public const int WM_VKEYTOITEM = 0x002E;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_VSCROLLCLIPBOARD = 0x030A;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        public const int WM_WININICHANGE = 0x001A;
        public const int WM_XBUTTONDBLCLK = 0x020D;
        public const int WM_XBUTTONDOWN = 0x020B;
        public const int WM_XBUTTONUP = 0x020C;
    }

    [Flags]
    enum WindowStyles : uint
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,

        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,

        WS_CAPTION = WS_BORDER | WS_DLGFRAME,
        WS_TILED = WS_OVERLAPPED,
        WS_ICONIC = WS_MINIMIZE,
        WS_SIZEBOX = WS_THICKFRAME,
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_CHILDWINDOW = WS_CHILD,

        //Extended Window Styles
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,

        //#if(WINVER >= 0x0400)
        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,

        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,

        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,

        WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
        WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),
        //#endif /* WINVER >= 0x0400 */

        //#if(WIN32WINNT >= 0x0500)
        WS_EX_LAYERED = 0x00080000,
        //#endif /* WIN32WINNT >= 0x0500 */

        //#if(WINVER >= 0x0500)
        WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
        WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring
        //#endif /* WINVER >= 0x0500 */

        //#if(WIN32WINNT >= 0x0500)
        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000
        //#endif /* WIN32WINNT >= 0x0500 */
    }

    public static class EnvironmentReader
    {
        [DllImport("shell32.dll")]
        static extern int SHGetFolderPath(IntPtr hwndOwner, SpecialFolderCSIDL nFolder, IntPtr hToken, uint dwFlags, [Out] StringBuilder pszPath);

        private const int MAX_PATH = 260;

        public enum SpecialFolderCSIDL : int
        {
            CSIDL_DESKTOP = 0x0000,    // <desktop>  
            CSIDL_INTERNET = 0x0001,    // Internet Explorer (icon on desktop)  
            CSIDL_PROGRAMS = 0x0002,    // Start Menu\Programs  
            CSIDL_CONTROLS = 0x0003,    // My Computer\Control Panel  
            CSIDL_PRINTERS = 0x0004,    // My Computer\Printers  
            CSIDL_PERSONAL = 0x0005,    // My Documents  
            CSIDL_FAVORITES = 0x0006,    // <user name>\Favorites  
            CSIDL_STARTUP = 0x0007,    // Start Menu\Programs\Startup  
            CSIDL_RECENT = 0x0008,    // <user name>\Recent  
            CSIDL_SENDTO = 0x0009,    // <user name>\SendTo  
            CSIDL_BITBUCKET = 0x000a,    // <desktop>\Recycle Bin  
            CSIDL_STARTMENU = 0x000b,    // <user name>\Start Menu  
            CSIDL_MYMUSIC = 0x000d, //  
            CSIDL_DESKTOPDIRECTORY = 0x0010,    // <user name>\Desktop  
            CSIDL_DRIVES = 0x0011,    // My Computer  
            CSIDL_NETWORK = 0x0012,    // Network Neighborhood  
            CSIDL_NETHOOD = 0x0013,    // <user name>\nethood  
            CSIDL_FONTS = 0x0014,    // windows\fonts  
            CSIDL_TEMPLATES = 0x0015,
            CSIDL_COMMON_STARTMENU = 0x0016,    // All Users\Start Menu  
            CSIDL_COMMON_PROGRAMS = 0x0017,    // All Users\Programs  
            CSIDL_COMMON_STARTUP = 0x0018,    // All Users\Startup  
            CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,    // All Users\Desktop  
            CSIDL_APPDATA = 0x001a,    // <user name>\Application Data  
            CSIDL_PRINTHOOD = 0x001b,    // <user name>\PrintHood  
            CSIDL_LOCAL_APPDATA = 0x001c,    // <user name>\Local Settings\Applicaiton Data (non roaming)  
            CSIDL_ALTSTARTUP = 0x001d,    // non localized startup  
            CSIDL_COMMON_ALTSTARTUP = 0x001e,    // non localized common startup  
            CSIDL_COMMON_FAVORITES = 0x001f,
            CSIDL_INTERNET_CACHE = 0x0020,
            CSIDL_COOKIES = 0x0021,
            CSIDL_HISTORY = 0x0022,
            CSIDL_COMMON_APPDATA = 0x0023,    // All Users\Application Data  
            CSIDL_WINDOWS = 0x0024,    // GetWindowsDirectory()  
            CSIDL_SYSTEM = 0x0025,    // GetSystemDirectory()  
            CSIDL_PROGRAM_FILES = 0x0026,    // C:\Program Files  
            CSIDL_MYPICTURES = 0x0027,    // C:\Program Files\My Pictures  
            CSIDL_PROFILE = 0x0028,    // USERPROFILE  
            CSIDL_SYSTEMX86 = 0x0029,    // x86 system directory on RISC  
            CSIDL_PROGRAM_FILESX86 = 0x002a,    // x86 C:\Program Files on RISC  
            CSIDL_PROGRAM_FILES_COMMON = 0x002b,    // C:\Program Files\Common  
            CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,    // x86 Program Files\Common on RISC  
            CSIDL_COMMON_TEMPLATES = 0x002d,    // All Users\Templates  
            CSIDL_COMMON_DOCUMENTS = 0x002e,    // All Users\Documents  
            CSIDL_COMMON_ADMINTOOLS = 0x002f,    // All Users\Start Menu\Programs\Administrative Tools  
            CSIDL_ADMINTOOLS = 0x0030,    // <user name>\Start Menu\Programs\Administrative Tools  
            CSIDL_CONNECTIONS = 0x0031,    // Network and Dial-up Connections  
        };

        public static string GetAllUsersFolderPath(SpecialFolderCSIDL csidl)
        {
            var path = new StringBuilder(MAX_PATH);
            SHGetFolderPath(IntPtr.Zero, csidl, IntPtr.Zero, 0, path);
            return path.ToString();
        }

        public static string GetAllUsersFolderPath(System.Environment.SpecialFolder specialFolder)
        {
            SpecialFolderCSIDL csidl;

            switch (specialFolder)
            {
                case System.Environment.SpecialFolder.ApplicationData:
                    csidl = SpecialFolderCSIDL.CSIDL_APPDATA;
                    break;
                case System.Environment.SpecialFolder.CommonApplicationData:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_APPDATA;
                    break;
                case System.Environment.SpecialFolder.CommonProgramFiles:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_PROGRAMS;
                    break;
                case System.Environment.SpecialFolder.Cookies:
                    csidl = SpecialFolderCSIDL.CSIDL_COOKIES;
                    break;
                case System.Environment.SpecialFolder.Desktop:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_DESKTOPDIRECTORY;
                    break;
                case System.Environment.SpecialFolder.DesktopDirectory:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_DESKTOPDIRECTORY;
                    break;
                case System.Environment.SpecialFolder.Favorites:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_FAVORITES;
                    break;
                case System.Environment.SpecialFolder.History:
                    csidl = SpecialFolderCSIDL.CSIDL_HISTORY;
                    break;
                case System.Environment.SpecialFolder.InternetCache:
                    csidl = SpecialFolderCSIDL.CSIDL_INTERNET_CACHE;
                    break;
                case System.Environment.SpecialFolder.LocalApplicationData:
                    csidl = SpecialFolderCSIDL.CSIDL_LOCAL_APPDATA;
                    break;
                case System.Environment.SpecialFolder.MyComputer:
                    csidl = SpecialFolderCSIDL.CSIDL_DRIVES;
                    break;
                case System.Environment.SpecialFolder.MyDocuments:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_DOCUMENTS;
                    break;
                case System.Environment.SpecialFolder.MyMusic:
                    csidl = SpecialFolderCSIDL.CSIDL_MYMUSIC;
                    break;
                case System.Environment.SpecialFolder.MyPictures:
                    csidl = SpecialFolderCSIDL.CSIDL_MYPICTURES;
                    break;
                case System.Environment.SpecialFolder.ProgramFiles:
                    csidl = SpecialFolderCSIDL.CSIDL_PROGRAM_FILES;
                    break;
                case System.Environment.SpecialFolder.Programs:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_PROGRAMS;
                    break;
                case System.Environment.SpecialFolder.Recent:
                    csidl = SpecialFolderCSIDL.CSIDL_RECENT;
                    break;
                case System.Environment.SpecialFolder.SendTo:
                    csidl = SpecialFolderCSIDL.CSIDL_SENDTO;
                    break;
                case System.Environment.SpecialFolder.StartMenu:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_STARTMENU;
                    break;
                case System.Environment.SpecialFolder.Startup:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_STARTUP;
                    break;
                case System.Environment.SpecialFolder.System:
                    csidl = SpecialFolderCSIDL.CSIDL_SYSTEM;
                    break;
                case System.Environment.SpecialFolder.Templates:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_TEMPLATES;
                    break;
                default:
                    csidl = SpecialFolderCSIDL.CSIDL_COMMON_DOCUMENTS;
                    break;
            }

            return GetAllUsersFolderPath(csidl);
        }
    }
}
