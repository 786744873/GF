using System;
using System.Text;
using System.Windows.Forms;
using CommonClient;
using CommonClient.Utilities;

namespace BOC_BATCH_TOOL
{
    public partial class frmException : Form
    {
        public frmException()
        {
            InitializeComponent();
        }

        public void SetErrorMessage(Exception ex, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【主版本号】：" + ClientUtilities.MainAssemblyFileVersion);
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + message);
            }
            sb.AppendLine("***************************************************************");
            this.edtContent.Text = sb.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetData(DataFormats.Text, this.edtContent.Text);
                MessageBoxPrime.Show("信息已复制到剪切板", "成功", MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxPrime.Show("设置剪切板信息出错：" + ex.Message, "错误", MessageBoxButtonsEx.OK, MessageBoxIcon.Hand);
            }
        }



    }
}
