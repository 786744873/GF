using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommonClient.VisualParts
{
    public partial class DataOperatePanel : BaseUc
    {
        public DataOperatePanel()
        {
            InitializeComponent();
            CommonClient.SysCoach.CommandCenter.OnLanguageChangedEventHandler += new EventHandler<SysCoach.LanguageChangedEventArgs>(Instance_OnLanguageChangedEventHandler);
        }

        private bool m_hasLock = false;
        /// <summary>
        /// 是否需要锁定功能
        /// </summary>
        [Browsable(true)]
        public bool HasLock
        {
            get { return m_hasLock; }
            set
            {
                m_hasLock = value;
                btnLock.Visible = m_hasLock;
            }
        }

        void Instance_OnLanguageChangedEventHandler(object sender, SysCoach.LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SysCoach.LanguageChangedEventArgs>(Instance_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
                btnLock.Visible = m_hasLock;
            }
        }

        public event EventHandler ButtonAddClicked;

        public event EventHandler ButtonEditClicked;

        public event EventHandler ButtonResetClicked;

        public event EventHandler ButtonDeleteClicked;

        public event EventHandler ButtonLockClicked;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ButtonAddClicked != null)
                ButtonAddClicked(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.ButtonEditClicked != null)
                ButtonEditClicked(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.ButtonResetClicked != null)
                ButtonResetClicked(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.ButtonDeleteClicked != null)
                ButtonDeleteClicked(sender, e);
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (this.ButtonLockClicked != null)
                ButtonLockClicked(sender, e);
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(DataOperatePanel), this);
        }

        private void btnLock_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("设置笔交易信息中的公用数据项", btnLock);
        }
    }
}
