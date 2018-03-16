using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class AdditionalCommentItemsPanel : BaseUc
    {
        public AdditionalCommentItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.Instance.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            this.Load += new EventHandler(AdditionalCommentItemsPanel_Load);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
            }
        }

        void AdditionalCommentItemsPanel_Load(object sender, EventArgs e)
        {
            dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        bool moveFlag = false;

        void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler), new object[] { sender, e }); }
            else
            {
                if (OperatorCommandType.View == e.Command)
                {
                    dgv.Rows.Clear();
                    List<NoticeInfo> list = new List<NoticeInfo>();
                    //if (AppliableFunctionType._Empty == m_AppType) m_AppType = e.OwnerType;
                    //else
                    //{
                    //    list = dgv.DataSource as List<NoticeInfo>;
                    //    CommandCenter.Instance.ResolveNotice(OperatorCommandType.Submit, list, m_AppType);
                    //}
                    m_AppType = e.OwnerType;
                    if (SystemSettings.Instance.Notices.ContainsKey(e.OwnerType))
                        list = SystemSettings.Instance.Notices[e.OwnerType];
                    int count = 10;
                    if (list.Count > 0 && list.Count > 10) count = list.Count;
                    dgv.Rows.Add(count);
                    if (list.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(list[list.Count - 1].Content))
                            dgv.Rows.Add(1);
                    }

                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        //dgv.Rows[i].Cells[0].Value = i + 1;
                        if (i < list.Count)
                            dgv.Rows[i].Cells[1].Value = list[i];
                    }
                    //dgv.DataSource = null;
                    //dgv.DataSource = list;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (m_AppType == AppliableFunctionType._Empty) return;
            List<NoticeInfo> list = new List<NoticeInfo>();//dgv.DataSource as List<NoticeInfo>;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[1].Value == null || string.IsNullOrEmpty(dgv.Rows[i].Cells[1].Value.ToString().Trim())) continue;
                list.Add(new NoticeInfo { Content = dgv.Rows[i].Cells[1].Value.ToString() });
            }
            CommandCenter.Instance.ResolveNotice(OperatorCommandType.Submit, list, m_AppType);
            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Submit_Succeed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_AppType == AppliableFunctionType._Empty) return;
            //if (dgv.SelectedCells.Count == 0) return;
            for (int i = dgv.RowCount - 1; i >= 0; i--)
            {
                if (dgv.Rows[i].Cells[0].Value != null && ((bool)dgv.Rows[i].Cells[0].Value))
                {
                    dgv.Rows[i].Cells[1].Value = string.Empty;
                }
            }

            // dgv.Refresh();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            moveFlag = true;
            if (m_AppType == AppliableFunctionType._Empty) return;
            if (dgv.SelectedCells.Count < 0) return;
            int index = dgv.SelectedCells[0].RowIndex;
            if (index == 0) return;
            //List<NoticeInfo> list = dgv.DataSource as List<NoticeInfo>;
            object content = dgv.Rows[index - 1].Cells[1].Value;
            dgv.Rows[index - 1].Cells[1].Value = dgv.Rows[index].Cells[1].Value;
            dgv.Rows[index].Cells[1].Value = content;
            //dgv.DataSource = null;
            //dgv.DataSource = list;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Selected)
                    dgv.Rows[i].Selected = false;
            }
            dgv.Rows[index - 1].Selected = true;
            //dgv.Refresh();
            moveFlag = false;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            moveFlag = true;
            if (m_AppType == AppliableFunctionType._Empty) return;
            if (dgv.SelectedCells.Count < 0) return;
            int index = dgv.SelectedCells[0].RowIndex;
            if (index == dgv.RowCount - 1) return;
            //List<NoticeInfo> list = dgv.DataSource as List<NoticeInfo>;
            object content = dgv.Rows[index + 1].Cells[1].Value;
            dgv.Rows[index + 1].Cells[1].Value = dgv.Rows[index].Cells[1].Value;
            dgv.Rows[index].Cells[1].Value = content;
            //dgv.DataSource = null;
            //dgv.DataSource = list;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Selected)
                    dgv.Rows[i].Selected = false;
            }
            if (index < dgv.RowCount)
                dgv.Rows[index + 1].Selected = true;
            //dgv.Refresh();
            moveFlag = false;
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(AdditionalCommentItemsPanel), this);
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (moveFlag) return;
            if (e.RowIndex == dgv.RowCount - 1 && dgv.Rows[e.RowIndex].Cells[1].Value != null)
            {
                //List<NoticeInfo> list = new List<NoticeInfo>();
                //if (dgv.DataSource != null) list.AddRange(dgv.DataSource as List<NoticeInfo>);
                if (string.IsNullOrEmpty(dgv.Rows[e.RowIndex].Cells[1].Value.ToString())) return;
                dgv.Rows.Add(1);
                //if (dgv.RowCount == list.Count)
                //list.Add(new NoticeInfo());
                //dgv.DataSource = null;
                //dgv.DataSource = list;
                //dgv.Refresh();
            }
            else if (e.RowIndex != dgv.RowCount - 1)
            {
                int i = 0;
                for (; i < dgv.RowCount - 1; i++)
                {
                    if (dgv.Rows[i].Cells[1].Value == null || string.IsNullOrEmpty(dgv.Rows[i].Cells[1].Value.ToString()))
                        break;
                }
                if (i == dgv.RowCount - 1)
                    dgv.Rows.Add(1);
            }
        }
    }
}
