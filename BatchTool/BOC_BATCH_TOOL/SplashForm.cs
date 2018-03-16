using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CommonClient.Controls;


namespace BOC_BATCH_TOOL
{
    public partial class SplashForm : NoborderShadowForm
    {
        private delegate void LabelTextUpdateDeltegate(Label label, string text);

        private string _statusInfo = string.Empty;
        private string _versionInfo = string.Empty;
        private string _publishTime = string.Empty;
        private bool _friendlyClosing = false;

        public SplashForm()
        {
            InitializeComponent();

            var workArea = Screen.FromControl(this).WorkingArea;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point((workArea.Width - this.Width) / 2, (workArea.Height - this.Height) / 2);
        }

        public string StatusInfo
        {
            set
            {
                _statusInfo = value;
                UpdateLabelText(lblStatus, _statusInfo);
            }
            get { return _statusInfo; }
        }

        public string VersionInfo
        {
            set
            {
                _versionInfo = value;
                UpdateLabelText(lblVersion, _versionInfo);
            }
            get { return _versionInfo; }
        }

        public string PublishTime
        {
            set
            {
                _publishTime = value;
                UpdateLabelText(lblPublishTime, _publishTime);
            }
            get { return _publishTime; }
        }

        private void UpdateLabelText(Label label, string text)
        {
            if (this.InvokeRequired)
                this.Invoke(new LabelTextUpdateDeltegate(this.UpdateLabelText), label, text);
            else
                label.Text = text;
        }

        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !this._friendlyClosing)
                e.Cancel = true;
        }

        public void FriendlyClose()
        {
            Program.MainForm.Visible = true;
            Program.MainForm.Enabled = true;
            Program.MainForm.WindowState = FormWindowState.Maximized;
            Application.DoEvents();
            Program.MainForm.BringToFront();
            _friendlyClosing = true;
            Close();
        }
    }

    public enum SplashFormState
    {
        NotInitialized = 0,
        Running = 1,
        Finished = 2
    }

    public class SplashFormController
    {
        private static SplashForm _splashForm = null;
        private static Thread _splashThread = null;
        public static SplashFormState SplashFormState { get; private set; }

        private static void ShowSplashForm()
        {
            _splashForm = new SplashForm() { TopMost = true };
            SplashFormState = SplashFormState.Running;
            Application.Run(_splashForm);
            Application.DoEvents();
        }

        public static void Startup()
        {
            if (Debugger.IsAttached)
                return;
            if (_splashThread != null)
                return;

            _splashThread = new Thread(ShowSplashForm) { IsBackground = true };
            _splashThread.SetApartmentState(ApartmentState.STA);
            _splashThread.Start();

            while (SplashFormState == SplashFormState.NotInitialized)
            {
                Thread.Sleep(10);
            }
        }

        public static void Closeup()
        {
            if (Debugger.IsAttached)
                return;
            if (_splashThread == null || _splashForm == null)
                return;
            SplashFormState = SplashFormState.Finished;
            _splashForm.Invoke(new MethodInvoker(_splashForm.FriendlyClose));
            _splashThread = null;
            _splashForm = null;
        }

        public static string StatusText
        {
            set
            {
                if (Debugger.IsAttached)
                    return;
                _splashForm.StatusInfo = value;
            }
        }

        public static string VersionInfo
        {
            set
            {
                if (Debugger.IsAttached)
                    return;
                _splashForm.VersionInfo = value;
            }
        }

        public static string PublishTime
        {
            set
            {
                if (Debugger.IsAttached)
                    return;
                _splashForm.PublishTime = value;
            }
        }
    }
}