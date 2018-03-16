using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using System.Text.RegularExpressions;

namespace CommonClient
{
    public partial class frmBarPassword : frmBase
    {
        public frmBarPassword()
        {
            InitializeComponent();
        }

        private string m_password;
        /// <summary>
        /// 加密密码
        /// </summary>
        public string Password
        {
            get { return m_password; }
            protected set { m_password = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCanValidate1.Text.Trim()) || textBoxCanValidate1.Text.Trim().Length != 6 || !Regex.IsMatch(textBoxCanValidate1.Text.Trim(), @"[0-9]{6}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
            {
                MessageBoxPrime.Show(string.Format("{0}6位{1}", MultiLanguageConvertHelper.Information_Please_Input, label1.Text.Substring(0, label1.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_password = textBoxCanValidate1.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
