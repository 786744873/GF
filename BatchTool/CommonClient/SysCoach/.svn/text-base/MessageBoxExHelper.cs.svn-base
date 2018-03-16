using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommonClient
{
    public class MessageBoxExHelper
    {
        #region 单例
        static object lock_obj = new object();
        static MessageBoxExHelper m_Instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static MessageBoxExHelper Instance
        {
            get
            {
                if (null == m_Instance)
                {
                    lock (lock_obj)
                    {
                        if (null == m_Instance)
                        {
                            lock (lock_obj)
                            {
                                m_Instance = new MessageBoxExHelper();
                            }
                        }
                    }
                }

                return MessageBoxExHelper.m_Instance;
            }
        }
        #endregion

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
            return MessageBoxPrime.Show(text, caption, buttons, icon, defaultButton);
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
            return MessageBoxPrime.Show(owner, text, caption, buttons, icon, defaultButton);
        }
    }
}
