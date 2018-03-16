using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BOC_BATCH_TOOL
{
    public partial class frmtxtSeparactor : Form
    {
        public frmtxtSeparactor()
        {
            InitializeComponent();
            this.ShowIcon = false;
        }

        List<string> separactorCharList = new List<string> { ",", "|", ";", "&" };

        private string m_txtSeparactor;
        /// <summary>
        /// 分隔符
        /// </summary>
        public string TxtSeparactor
        {
            get { return m_txtSeparactor; }
            set { m_txtSeparactor = value; }
        }

        private string m_filepath;
        /// <summary>
        /// txt文件路径
        /// </summary>
        public string Filepath
        {
            get { return m_filepath; }
            set { m_filepath = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSeparactor.Text))
            {
                m_txtSeparactor = tbSeparactor.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", BOC_BATCH_TOOL.ConvertHelper.MultiLanguageConvertHelper.Instance.Information_Please_Input, label1.Text.Substring(0, label1.Text.Length - 1)), BOC_BATCH_TOOL.ConvertHelper.MultiLanguageConvertHelper.Instance.FrmMain_Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_filepath.Trim())) return;

            List<string> filecontent = BOC_BATCH_TOOL.FileIO.FileRWHelper.Instance.ReadTXTDocument(m_filepath);

            if (filecontent.Count == 0)
            { tbFileContent.Text = "文件中无数据"; }
            else
            {
                for (int i = 0; i < filecontent.Count && i < 3; i++)
                {
                    tbFileContent.Text += filecontent[i] + Environment.NewLine;
                }

                AnalysisData();
            }
        }

        void AnalysisData()
        {
            List<char> list = new List<char>();
            list.AddRange(tbFileContent.Text.Trim().ToCharArray());
            int index = 0;
            int maxcount = 0;
            for (int i = 0; i < separactorCharList.Count; i++)
            {
                int count = list.FindAll(o => o.ToString() == separactorCharList[i]).Count;
                if (count > maxcount)
                {
                    maxcount = count;
                    index = i;
                }
            }

            if (maxcount > 0)
                tbSeparactor.Text = separactorCharList[index];
            else tbFileContent.Text = string.Empty;
        }
    }
}
