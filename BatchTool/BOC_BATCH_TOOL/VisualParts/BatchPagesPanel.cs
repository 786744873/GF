using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class BatchPagesPanel : BaseUc
    {
        public BatchPagesPanel()
        {
            InitializeComponent();
            tbPageNo.TextChanged += new EventHandler(tbPageNo_TextChanged);
            ChangeUIStates();
        }

        void tbPageNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int count = int.Parse(tbPageNo.Text.Trim());
                if (count > m_totlePageNo || count <= 0) tbPageNo.Text = string.Empty;
            }
            catch { tbPageNo.Text = string.Empty; }
        }

        public void Init(int totleCount)
        {
            m_totleCount = totleCount;
            tbPageNo.Text = string.Empty;
            tbPageNo.ReadOnly = totleCount == 0;
            if (totleCount == 0)
            {
                m_totlePageNo = 0;
                m_currentPageNo = 0;
            }
            else if (totleCount > 0)
            {
                m_totlePageNo = totleCount % m_perPageCount == 0 ? totleCount / m_perPageCount : totleCount / m_perPageCount + 1;
                m_currentPageNo = 1;
            }
            lbtotlecount.Text = string.Format("共{0}条", m_totleCount);
            ChangeUIStates();
        }

        private int m_perPageCount = 50;
        private int m_totleCount = 0;
        private int m_currentPageNo = 0;
        private int m_totlePageNo = 0;

        public event EventHandler<BatchPageEventArgs> GoToSomePageEventHandeler;

        private void btnGoto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPageNo.Text)) return;
            m_currentPageNo = int.Parse(tbPageNo.Text.Trim());
            ChangeUIStates();
            tbPageNo.Text = string.Empty;
        }

        void ChangeUIStates()
        {
            llNext.Enabled = m_currentPageNo < m_totlePageNo && m_totleCount != 0;
            llPre.Enabled = m_currentPageNo > 1;
            btnGoto.Enabled = m_totleCount > 0;
            label3.Text = string.Format("第{0}页/共{1}页", m_currentPageNo, m_totlePageNo);
            int count = m_totleCount - m_perPageCount * (m_currentPageNo - 1);
            count = count > m_perPageCount ? m_perPageCount : count;
            if (GoToSomePageEventHandeler != null)
                GoToSomePageEventHandeler(this, new BatchPageEventArgs(m_currentPageNo, count, m_perPageCount));
        }

        private void ll_Click(object sender, EventArgs e)
        {
            if ((sender as LinkLabel).Name == llPre.Name)
                m_currentPageNo -= 1;
            else if ((sender as LinkLabel).Name == llNext.Name)
                m_currentPageNo += 1;
            ChangeUIStates();
        }
    }

    public class BatchPageEventArgs : EventArgs
    {
        public int CurrentPageNo { get; set; }
        public int StartRecordNo { get; protected set; }
        public int ShowCount { get; set; }
        public int PerPageRecordCount { get; set; }
        public BatchPageEventArgs()
        {
            CurrentPageNo =
            StartRecordNo =
            ShowCount =
            PerPageRecordCount = 0;
        }
        public BatchPageEventArgs(int currentPageNo, int showCount, int perPageRecordCount)
            : this()
        {
            CurrentPageNo = currentPageNo;
            ShowCount = showCount;
            PerPageRecordCount = perPageRecordCount;
            StartRecordNo = currentPageNo > 0 ? perPageRecordCount * (currentPageNo - 1) : 0;
        }
    }
}
