using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL
{
    public partial class MessageBoxEx : Form
    {
        public MessageBoxEx()
        {
            InitializeComponent();
        }

        int labelMinWidth = 85;
        int labelMinHeight = 12;
        int OneButtonMinWidth = 180;
        int TwoButtonsMinWidth = 210;
        int ThreeButtonsMinWidth = 300;

        // 摘要:
        //     显示具有指定文本的消息框。
        //
        // 参数:
        //   text:
        //     要在消息框中显示的文本。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        public DialogResult Show(string text)
        {
            return Show(text, string.Empty);
        }

        // 摘要:
        //     在指定对象的前面显示具有指定文本的消息框。
        //
        // 参数:
        //   owner:
        //
        //   text:
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        public DialogResult Show(IWin32Window owner, string text)
        {
            return Show(owner, text, string.Empty);
        }

        // 摘要:
        //     显示具有指定文本和标题的消息框。
        //
        // 参数:
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //     要在消息框的标题栏中显示的文本。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        public DialogResult Show(string text, string caption)
        {
            return Show(text, caption, MessageBoxButtons.OK);
        }

        // 摘要:
        //     在指定对象的前面显示具有指定文本和标题的消息框。
        //
        // 参数:
        //   owner:
        //     将拥有模式对话框的 System.Windows.Forms.IWin32Window 的一个实现。
        //
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //     要在消息框的标题栏中显示的文本。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        public DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, MessageBoxButtons.OK);
        }

        // 摘要:
        //     显示具有指定文本、标题和按钮的消息框。
        //
        // 参数:
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //     要在消息框的标题栏中显示的文本。
        //
        //   buttons:
        //     System.Windows.Forms.MessageBoxButtons 值之一，可指定在消息框中显示哪些按钮。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        //
        // 异常:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     指定的 buttons 参数不是 System.Windows.Forms.MessageBoxButtons 的成员。
        //
        //   System.InvalidOperationException:
        //     试图在运行模式不是用户交互模式的进程中显示 System.Windows.Forms.MessageBox。这是由 System.Windows.Forms.SystemInformation.UserInteractive
        //     属性指定的。
        public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(text, caption, buttons, MessageBoxIcon.None);
        }

        // 摘要:
        //     在指定对象的前面显示具有指定文本、标题和按钮的消息框。
        //
        // 参数:
        //   owner:
        //
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //
        //   buttons:
        //     System.Windows.Forms.MessageBoxButtons 值之一，可指定在消息框中显示哪些按钮。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        //
        // 异常:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons 不是 System.Windows.Forms.MessageBoxButtons 的成员。
        //
        //   System.InvalidOperationException:
        //     试图在运行模式不是用户交互模式的进程中显示 System.Windows.Forms.MessageBox。这是由 System.Windows.Forms.SystemInformation.UserInteractive
        //     属性指定的。
        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return Show(owner, text, caption, buttons, MessageBoxIcon.None);
        }

        // 摘要:
        //     显示具有指定文本、标题、按钮和图标的消息框。
        //
        // 参数:
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //     要在消息框的标题栏中显示的文本。
        //
        //   buttons:
        //     System.Windows.Forms.MessageBoxButtons 值之一，可指定在消息框中显示哪些按钮。
        //
        //   icon:
        //     System.Windows.Forms.MessageBoxIcon 值之一，它指定在消息框中显示哪个图标。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        //
        // 异常:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     指定的 buttons 参数不是 System.Windows.Forms.MessageBoxButtons 的成员。- 或 - 指定的 icon
        //     参数不是 System.Windows.Forms.MessageBoxIcon 的成员。
        //
        //   System.InvalidOperationException:
        //     试图在运行模式不是用户交互模式的进程中显示 System.Windows.Forms.MessageBox。这是由 System.Windows.Forms.SystemInformation.UserInteractive
        //     属性指定的。
        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        { return Show(text, caption, buttons, icon, MessageBoxDefaultButton.Button3); }

        // 摘要:
        //     在指定对象的前面显示具有指定文本、标题、按钮和图标的消息框。
        //
        // 参数:
        //   owner:
        //
        //   text:
        //
        //   caption:
        //
        //   buttons:
        //
        //   icon:
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        //
        // 异常:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons 不是 System.Windows.Forms.MessageBoxButtons 的成员。- 或 - icon 不是 System.Windows.Forms.MessageBoxIcon
        //     的成员。
        //
        //   System.InvalidOperationException:
        //     试图在运行模式不是用户交互模式的进程中显示 System.Windows.Forms.MessageBox。这是由 System.Windows.Forms.SystemInformation.UserInteractive
        //     属性指定的。
        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button3);
        }

        // 摘要:
        //     显示具有指定文本、标题、按钮、图标和默认按钮的消息框。
        //
        // 参数:
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //     要在消息框的标题栏中显示的文本。
        //
        //   buttons:
        //     System.Windows.Forms.MessageBoxButtons 值之一，可指定在消息框中显示哪些按钮。
        //
        //   icon:
        //     System.Windows.Forms.MessageBoxIcon 值之一，它指定在消息框中显示哪个图标。
        //
        //   defaultButton:
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        //
        // 异常:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons 不是 System.Windows.Forms.MessageBoxButtons 的成员。- 或 - icon 不是 System.Windows.Forms.MessageBoxIcon
        //     的成员。- 或 - defaultButton 不是 System.Windows.Forms.MessageBoxDefaultButton 的成员。
        //
        //   System.InvalidOperationException:
        //     试图在运行模式不是用户交互模式的进程中显示 System.Windows.Forms.MessageBox。这是由 System.Windows.Forms.SystemInformation.UserInteractive
        //     属性指定的。
        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            this.label1.Text = text;
            this.Text = caption;
            int lw = this.label1.Width - labelMinWidth > 0 ? this.label1.Width - labelMinWidth : 0;
            this.Height += this.label1.Height - labelMinHeight > 0 ? this.label1.Height - labelMinHeight : 0;
            int buttonCount = 0;

            //buttons
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    if (OneButtonMinWidth + lw > ThreeButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = ThreeButtonsMinWidth;
                    //set button's name
                    this.button1.Text = MultiLanguageConvertHelper.Instance.Information_Abort;
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Retry;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Ignore;
                    this.button1.Tag = DialogResult.Abort;
                    this.button2.Tag = DialogResult.Retry;
                    this.button3.Tag = DialogResult.Ignore;
                    buttonCount = 3;
                    break;
                case MessageBoxButtons.OK:
                    if (OneButtonMinWidth + lw > OneButtonMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = OneButtonMinWidth;
                    //set button's name
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Ok;
                    //hide other buttons
                    this.button1.Visible =
                    this.button2.Visible = false;
                    this.button3.Tag = DialogResult.OK;
                    buttonCount = 1;
                    break;
                case MessageBoxButtons.OKCancel:
                    if (OneButtonMinWidth + lw > TwoButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = TwoButtonsMinWidth;
                    //set button's name
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Ok;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Cancel;
                    //hide other buttons
                    this.button1.Visible = false;
                    this.button2.Tag = DialogResult.OK;
                    this.button3.Tag = DialogResult.Cancel;
                    buttonCount = 2;
                    break;
                case MessageBoxButtons.RetryCancel:
                    if (OneButtonMinWidth + lw > TwoButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = TwoButtonsMinWidth;
                    //set button's name
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Retry;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Cancel;
                    //hide other buttons
                    this.button1.Visible = false;
                    this.button2.Tag = DialogResult.Retry;
                    this.button3.Tag = DialogResult.Cancel;
                    buttonCount = 2;
                    break;
                case MessageBoxButtons.YesNo:
                    if (OneButtonMinWidth + lw > TwoButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = TwoButtonsMinWidth;
                    //set button's name
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Yes;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_No;
                    //hide other buttons
                    this.button1.Visible = false;
                    this.button2.Tag = DialogResult.Yes;
                    this.button3.Tag = DialogResult.No;
                    buttonCount = 2;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    if (OneButtonMinWidth + lw > ThreeButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = ThreeButtonsMinWidth;
                    //set button's name
                    this.button1.Text = MultiLanguageConvertHelper.Instance.Information_Yes;
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_No;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Cancel;
                    this.button1.Tag = DialogResult.Yes;
                    this.button2.Tag = DialogResult.No;
                    this.button3.Tag = DialogResult.Cancel;
                    buttonCount = 2;
                    break;
            }

            //icons
            switch ((int)icon)
            {
                case (int)MessageBoxIcon.Asterisk:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.information;
                    break;
                case (int)MessageBoxIcon.Error:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.Error;
                    break;
                case (int)MessageBoxIcon.Exclamation:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.warning;
                    break;
                case (int)MessageBoxIcon.Question:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.question;
                    break;
                case (int)MessageBoxIcon.None:
                    this.panel1.BackgroundImage = null;
                    break;
            }

            //defaultbutton
            if (buttonCount > 0)
            {
                switch (defaultButton)
                {
                    case MessageBoxDefaultButton.Button1:
                        this.CancelButton = this.AcceptButton = buttonCount == 1 ? this.button3 :
                            buttonCount == 2 ? this.button2 : this.button1;
                        break;
                    case MessageBoxDefaultButton.Button2:
                        this.CancelButton = this.AcceptButton = buttonCount == 3 ? this.button2 : this.button3;
                        break;
                    case MessageBoxDefaultButton.Button3:
                        this.CancelButton = this.AcceptButton = this.button3;
                        break;
                }
            }
            else
                this.CancelButton = this.AcceptButton = this.button3;

            return this.ShowDialog();
        }

        // 摘要:
        //     在指定对象的前面显示具有指定文本、标题、按钮、图标和默认按钮的消息框。
        //
        // 参数:
        //   owner:
        //
        //   text:
        //     要在消息框中显示的文本。
        //
        //   caption:
        //
        //   buttons:
        //     System.Windows.Forms.MessageBoxButtons 值之一，可指定在消息框中显示哪些按钮。
        //
        //   icon:
        //
        //   defaultButton:
        //     System.Windows.Forms.MessageBoxDefaultButton 值之一，可指定消息框中的默认按钮。
        //
        // 返回结果:
        //     System.Windows.Forms.DialogResult 值之一。
        //
        // 异常:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons 不是 System.Windows.Forms.MessageBoxButtons 的成员。- 或 - icon 不是 System.Windows.Forms.MessageBoxIcon
        //     的成员。- 或 - defaultButton 不是 System.Windows.Forms.MessageBoxDefaultButton 的成员。
        //
        //   System.InvalidOperationException:
        //     试图在运行模式不是用户交互模式的进程中显示 System.Windows.Forms.MessageBox。这是由 System.Windows.Forms.SystemInformation.UserInteractive
        //     属性指定的。
        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            this.label1.Text = text;
            this.Text = caption;
            int lw = this.label1.Width - labelMinWidth > 0 ? this.label1.Width - labelMinWidth : 0;
            this.Height += this.label1.Height - labelMinHeight > 0 ? this.label1.Height - labelMinHeight : 0;
            int buttonCount = 0;

            //buttons
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    if (OneButtonMinWidth + lw > ThreeButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = ThreeButtonsMinWidth;
                    //set button's name
                    this.button1.Text = MultiLanguageConvertHelper.Instance.Information_Abort;
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Retry;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Ignore;
                    this.button1.Tag = DialogResult.Abort;
                    this.button2.Tag = DialogResult.Retry;
                    this.button3.Tag = DialogResult.Ignore;
                    buttonCount = 3;
                    break;
                case MessageBoxButtons.OK:
                    if (OneButtonMinWidth + lw > OneButtonMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = OneButtonMinWidth;
                    //set button's name
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Ok;
                    //hide other buttons
                    this.button1.Visible =
                    this.button2.Visible = false;
                    this.button3.Tag = DialogResult.OK;
                    buttonCount = 1;
                    break;
                case MessageBoxButtons.OKCancel:
                    if (OneButtonMinWidth + lw > TwoButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = TwoButtonsMinWidth;
                    //set button's name
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Ok;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Cancel;
                    //hide other buttons
                    this.button1.Visible = false;
                    this.button2.Tag = DialogResult.OK;
                    this.button3.Tag = DialogResult.Cancel;
                    buttonCount = 2;
                    break;
                case MessageBoxButtons.RetryCancel:
                    if (OneButtonMinWidth + lw > TwoButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = TwoButtonsMinWidth;
                    //set button's name
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Retry;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Cancel;
                    //hide other buttons
                    this.button1.Visible = false;
                    this.button2.Tag = DialogResult.Retry;
                    this.button3.Tag = DialogResult.Cancel;
                    buttonCount = 2;
                    break;
                case MessageBoxButtons.YesNo:
                    if (OneButtonMinWidth + lw > TwoButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = TwoButtonsMinWidth;
                    //set button's name
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_Yes;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_No;
                    //hide other buttons
                    this.button1.Visible = false;
                    this.button2.Tag = DialogResult.Yes;
                    this.button3.Tag = DialogResult.No;
                    buttonCount = 2;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    if (OneButtonMinWidth + lw > ThreeButtonsMinWidth)
                        this.Width = OneButtonMinWidth + lw;
                    else this.Width = ThreeButtonsMinWidth;
                    //set button's name
                    this.button1.Text = MultiLanguageConvertHelper.Instance.Information_Yes;
                    this.button2.Text = MultiLanguageConvertHelper.Instance.Information_No;
                    this.button3.Text = MultiLanguageConvertHelper.Instance.Information_Cancel;
                    this.button1.Tag = DialogResult.Yes;
                    this.button2.Tag = DialogResult.No;
                    this.button3.Tag = DialogResult.Cancel;
                    buttonCount = 2;
                    break;
            }

            //icons
            switch ((int)icon)
            {
                case (int)MessageBoxIcon.Asterisk:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.information;
                    break;
                case (int)MessageBoxIcon.Error:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.Error;
                    break;
                case (int)MessageBoxIcon.Exclamation:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.warning;
                    break;
                case (int)MessageBoxIcon.Question:
                    this.panel1.BackgroundImage = global::BOC_BATCH_TOOL.Properties.Resources.question;
                    break;
                case (int)MessageBoxIcon.None:
                    this.panel1.BackgroundImage = null;
                    break;
            }

            //defaultbutton
            if (buttonCount > 0)
            {
                switch (defaultButton)
                {
                    case MessageBoxDefaultButton.Button1:
                        this.CancelButton = this.AcceptButton = buttonCount == 1 ? this.button3 :
                            buttonCount == 2 ? this.button2 : this.button1;
                        break;
                    case MessageBoxDefaultButton.Button2:
                        this.CancelButton = this.AcceptButton = buttonCount == 3 ? this.button2 : this.button3;
                        break;
                    case MessageBoxDefaultButton.Button3:
                        this.CancelButton = this.AcceptButton = this.button3;
                        break;
                }
            }
            else
                this.CancelButton = this.AcceptButton = this.button3;

            this.Parent = (Control)owner;
            return this.ShowDialog();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Tag != null)
            {
                this.DialogResult = (DialogResult)((sender as Button).Tag);
            }
        }
    }
}
