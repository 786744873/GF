using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using System.Text.RegularExpressions;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class RowIndexPanel : BaseUc
    {
        public RowIndexPanel()
        {
            InitializeComponent();
            CommandCenter.Instance.OnRwoIndexEventHandler += new EventHandler<RowIndexEventArgs>(CommandCenter_OnRwoIndexEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            txtRowIndex.TextChanged += new EventHandler(txtRowIndex_TextChanged);
            txtRowIndex.Text = "1";
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(RowIndexPanel), this);
            }
        }

        void txtRowIndex_TextChanged(object sender, EventArgs e)
        {
            btnQuery.Enabled = !string.IsNullOrEmpty(txtRowIndex.Text);
        }

        void CommandCenter_OnRwoIndexEventHandler(object sender, RowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<RowIndexEventArgs>(CommandCenter_OnRwoIndexEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (OperatorCommandType.View == e.Command || OperatorCommandType.Edit == e.Command)
                {
                    txtRowIndex.Text = e.RowIndex.ToString();
                }
                else if (OperatorCommandType.Submit == e.Command)
                {
                    txtRowIndex.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;

        /// <summary>
        /// 获取当前序号
        /// </summary>
        public int RowIndex
        {
            get
            {
                GetIndex();
                return m_index;
            }
        }
        private int m_index = -1;

        private void GetIndex()
        {
            if (string.IsNullOrEmpty(txtRowIndex.Text)) m_index = int.MaxValue;
            else
            {
                try
                {
                    m_index = int.Parse(txtRowIndex.Text.Trim());
                }
                catch { m_index = int.MaxValue; }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string matchstr = @"^[0-9]\d{0,4}$";
            RegexOptions options = RegexOptions.Multiline | (RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

            if (!Regex.IsMatch(txtRowIndex.Text, matchstr, options))
            {
                MessageBoxExHelper.Instance.Show("序号只能填写不超过5位的数字", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try {
                int a = 0;
                a = int.Parse(matchstr);
                if (a <= 0)
                {
                    MessageBoxExHelper.Instance.Show("只能输入大于0的数", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }
            catch { }
            CommandCenter.Instance.ResolveQueryData(int.Parse(txtRowIndex.Text.Trim()), m_AppType);
        }
    }
}
