using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Utilities;

namespace CommonClient
{
    public partial class MessageBoxPrime : frmBase
    {
        public MessageBoxPrime()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private static MessageBoxPrime _instance;

        private static MessageBoxPrime EnsuredInstance
        {
            get
            {
                if (_instance != null && _instance.IsDisposed)
                    _instance = null;

                if (_instance == null)
                    _instance = new MessageBoxPrime();
                return _instance;
            }
        }

        public string LangKey { get; set; }

        private static void ArrangeButtons(MessageBoxButtonsEx buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtonsEx.AbortRetryIgnore:
                    EnsuredInstance.btnAbort.Visible = true;
                    EnsuredInstance.btnRetry.Visible = true;
                    EnsuredInstance.btnIgnore.Visible = true;
                    EnsuredInstance.btnOk.Visible = false;
                    EnsuredInstance.btnCancel.Visible = false;
                    EnsuredInstance.btnNo.Visible = false;
                    EnsuredInstance.btnYes.Visible = false;
                    EnsuredInstance.btnCombine.Visible = false;
                    EnsuredInstance.btnOver.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnIgnore;
                    break;
                case MessageBoxButtonsEx.OKCancel:
                    EnsuredInstance.btnOk.Visible = true;
                    EnsuredInstance.btnCancel.Visible = true;
                    EnsuredInstance.btnAbort.Visible = false;
                    EnsuredInstance.btnRetry.Visible = false;
                    EnsuredInstance.btnIgnore.Visible = false;
                    EnsuredInstance.btnNo.Visible = false;
                    EnsuredInstance.btnYes.Visible = false;
                    EnsuredInstance.btnCombine.Visible = false;
                    EnsuredInstance.btnOver.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnCancel;
                    break;
                case MessageBoxButtonsEx.OK:
                    EnsuredInstance.btnOk.Visible = true;
                    EnsuredInstance.btnCancel.Visible = false;
                    EnsuredInstance.btnAbort.Visible = false;
                    EnsuredInstance.btnRetry.Visible = false;
                    EnsuredInstance.btnIgnore.Visible = false;
                    EnsuredInstance.btnNo.Visible = false;
                    EnsuredInstance.btnYes.Visible = false;
                    EnsuredInstance.btnCombine.Visible = false;
                    EnsuredInstance.btnOver.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnOk;
                    break;
                case MessageBoxButtonsEx.RetryCancel:
                    EnsuredInstance.btnRetry.Visible = true;
                    EnsuredInstance.btnCancel.Visible = true;
                    EnsuredInstance.btnOk.Visible = false;
                    EnsuredInstance.btnAbort.Visible = false;
                    EnsuredInstance.btnIgnore.Visible = false;
                    EnsuredInstance.btnNo.Visible = false;
                    EnsuredInstance.btnYes.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnCancel;
                    break;
                case MessageBoxButtonsEx.YesNo:
                    EnsuredInstance.btnYes.Visible = true;
                    EnsuredInstance.btnNo.Visible = true;
                    EnsuredInstance.btnRetry.Visible = false;
                    EnsuredInstance.btnCancel.Visible = false;
                    EnsuredInstance.btnOk.Visible = false;
                    EnsuredInstance.btnAbort.Visible = false;
                    EnsuredInstance.btnIgnore.Visible = false;
                    EnsuredInstance.btnCombine.Visible = false;
                    EnsuredInstance.btnOver.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnNo;
                    break;
                case MessageBoxButtonsEx.YesNoCancel:
                    EnsuredInstance.btnYes.Visible = true;
                    EnsuredInstance.btnNo.Visible = true;
                    EnsuredInstance.btnCancel.Visible = true;
                    EnsuredInstance.btnRetry.Visible = false;
                    EnsuredInstance.btnOk.Visible = false;
                    EnsuredInstance.btnAbort.Visible = false;
                    EnsuredInstance.btnIgnore.Visible = false;
                    EnsuredInstance.btnCombine.Visible = false;
                    EnsuredInstance.btnOver.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnCancel;
                    break;
                case MessageBoxButtonsEx.OverCombineCancel:
                    EnsuredInstance.btnCombine.Visible = true;
                    EnsuredInstance.btnOver.Visible = true;
                    EnsuredInstance.btnCancel.Visible = true;
                    EnsuredInstance.btnYes.Visible = false;
                    EnsuredInstance.btnNo.Visible = false;
                    EnsuredInstance.btnRetry.Visible = false;
                    EnsuredInstance.btnOk.Visible = false;
                    EnsuredInstance.btnAbort.Visible = false;
                    EnsuredInstance.btnIgnore.Visible = false;
                    EnsuredInstance.CancelButton = EnsuredInstance.btnCancel;
                    break;
            }
        }

        private static void ArrangeIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.None:
                    EnsuredInstance.picIcon.Image = null;
                    break;
                case MessageBoxIcon.Question:
                    EnsuredInstance.picIcon.Image = EnsuredInstance.ilBig.Images["question"];
                    break;
                case MessageBoxIcon.Hand: //case MessageBoxIcon.Error: //case MessageBoxIcon.Stop:
                    EnsuredInstance.picIcon.Image = EnsuredInstance.ilBig.Images["error"];
                    break;
                case MessageBoxIcon.Asterisk: //case MessageBoxIcon.Information:
                    EnsuredInstance.picIcon.Image = EnsuredInstance.ilBig.Images["information"];
                    break;
                case MessageBoxIcon.Warning: //case MessageBoxIcon.Exclamation:
                    EnsuredInstance.picIcon.Image = EnsuredInstance.ilBig.Images["warning"];
                    break;
            }
        }

        private static void MeasureAndReSizeDialog()
        {
            //EnsuredInstance.Text = "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 0\r\n";
            //EnsuredInstance.lblMessage.Text = "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 1\r\n" +
            //                                  "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 2\r\n" +
            //                                  "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 3\r\n" +
            //                                  "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 4\r\n" +
            //                                  "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 5\r\n" +
            //                                  "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 6\r\n" +
            //                                  "labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, \r\nEnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width); 7\r\n";

            //EnsuredInstance.lblMessage.Text = "aaaaaaa";
            using (var labelGraphics = EnsuredInstance.lblMessage.CreateGraphics())
            {
                var sizeNeeded = labelGraphics.MeasureString(EnsuredInstance.lblMessage.Text, EnsuredInstance.lblMessage.Font, EnsuredInstance.lblMessage.Width);
                var targetHeight = EnsuredInstance.Height + (int)sizeNeeded.Height - EnsuredInstance.lblMessage.Height + 20;
                if (sizeNeeded.Height < EnsuredInstance.picIcon.Height) targetHeight += EnsuredInstance.picIcon.Height - (int)sizeNeeded.Height;
                var usingScreen = Screen.FromControl(EnsuredInstance);
                if (targetHeight > usingScreen.Bounds.Height)
                    targetHeight = usingScreen.Bounds.Height;
                EnsuredInstance.lblMessage.Height = (int)sizeNeeded.Height + 20;
                //UIAnimation.Do(EnsuredInstance, "Height", targetHeight, new AnimationTypeLinear(90));
                //UIAnimation.Do(EnsuredInstance, "Opacity", 0.6d, 1d, new AnimationTypeLinear(90));
            }
        }

        private static void ArrangeDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            var index = 0;
            foreach (var control in EnsuredInstance.flowLayoutPanel1.Controls)
            {

                var button = control as Button;
                if (button != null && button.Visible && button.Enabled && button.CanFocus && ((int)defaultButton / 256) == index)
                {
                    index++;
                    button.Focus();
                    break;
                }
            }
        }


        //public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        //{
        //}

        public static DialogResult Show(string text, string caption, MessageBoxButtonsEx buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            ArrangeButtons(buttons);
            ArrangeIcon(icon);
            ArrangeDefaultButton(defaultButton);
            var DialogResult = EnsuredInstance.ShowDialog();
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtonsEx buttons, MessageBoxIcon icon)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            ArrangeButtons(buttons);
            ArrangeIcon(icon);
            var DialogResult = EnsuredInstance.ShowDialog();
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtonsEx buttons)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            ArrangeButtons(buttons);
            var DialogResult = EnsuredInstance.ShowDialog();
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(string text, string caption)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            var DialogResult = EnsuredInstance.ShowDialog();
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(string text)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = string.Empty;

            var DialogResult = EnsuredInstance.ShowDialog();
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtonsEx buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            ArrangeButtons(buttons);
            ArrangeIcon(icon);
            ArrangeDefaultButton(defaultButton);
            var DialogResult = EnsuredInstance.ShowDialog(owner);
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtonsEx buttons, MessageBoxIcon icon)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            ArrangeButtons(buttons);
            ArrangeIcon(icon);
            var DialogResult = EnsuredInstance.ShowDialog(owner);
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtonsEx buttons)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            ArrangeButtons(buttons);
            var DialogResult = EnsuredInstance.ShowDialog(owner);
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = caption;

            var DialogResult = EnsuredInstance.ShowDialog(owner);
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            EnsuredInstance.lblMessage.Text = text;
            EnsuredInstance.Text = string.Empty;

            var DialogResult = EnsuredInstance.ShowDialog(owner);
            EnsuredInstance.Dispose();
            return DialogResult;
        }

        private void MessageBoxPrime_Load(object sender, EventArgs e)
        {
            this.languageList1.UpdateTranslations();
            MeasureAndReSizeDialog();
        }
    }

    public enum MessageBoxButtonsEx
    {
        // 摘要:
        //     消息框包含“确定”按钮。
        OK = 0,
        //
        // 摘要:
        //     消息框包含“确定”和“取消”按钮。
        OKCancel = 1,
        //
        // 摘要:
        //     消息框包含“中止”、“重试”和“忽略”按钮。
        AbortRetryIgnore = 2,
        //
        // 摘要:
        //     消息框包含“是”、“否”和“取消”按钮。
        YesNoCancel = 3,
        //
        // 摘要:
        //     消息框包含“是”和“否”按钮。
        YesNo = 4,
        //
        // 摘要:
        //     消息框包含“重试”和“取消”按钮。
        RetryCancel = 5,
        //
        // 摘要:
        //     消息框包含“替换”、“合并”和“取消”按钮。
        OverCombineCancel = 6,
    }

    //public enum DialogResult
    //{
    //    // 摘要:
    //    //     从对话框返回了 Nothing。这表明有模式对话框继续运行。
    //    None = 0,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 OK（通常从标签为“确定”的按钮发送）。
    //    OK = 1,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Cancel（通常从标签为“取消”的按钮发送）。
    //    Cancel = 2,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Abort（通常从标签为“中止”的按钮发送）。
    //    Abort = 3,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Retry（通常从标签为“重试”的按钮发送）。
    //    Retry = 4,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Ignore（通常从标签为“忽略”的按钮发送）。
    //    Ignore = 5,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Yes（通常从标签为“是”的按钮发送）。
    //    Yes = 6,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 No（通常从标签为“否”的按钮发送）。
    //    No = 7,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Combine（通常从标签为“合并”的按钮发送）。
    //    Combine = 4,
    //    //
    //    // 摘要:
    //    //     对话框的返回值是 Over（通常从标签为“覆盖”的按钮发送）。
    //    Over = 5,
    //}
}
