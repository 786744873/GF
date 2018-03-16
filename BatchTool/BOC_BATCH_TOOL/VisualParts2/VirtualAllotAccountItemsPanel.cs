using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class VirtualAllotAccountItemsPanel : BaseUc
    {
        public VirtualAllotAccountItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            this.Load += new EventHandler(InitiativeAllotAccountItemsPanel_Load);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
            CommandCenter.Instance.OnVirtualAccountAllotEventEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
        }

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType._Empty) return;
                if (e.RowIndex < 0 || e.RowIndex > dgv.Rows.Count)
                {
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_NoMatch_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.Instance.ResolveVirtualAllotAccount(OperatorCommandType.View, (dgv.DataSource as List<VirtualAccountInfo>)[e.RowIndex], e.AppType, e.RowIndex);
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(VirtualAllotAccountItemsPanel), this);
            }
        }

        void InitiativeAllotAccountItemsPanel_Load(object sender, EventArgs e)
        {
            List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
            list.AddRange(SystemSettings.Instance.VirtualAllotAccountList.ToArray());
            if (list != null && list.Count > 0)
            {
                dgv.DataSource = list;
                dgv.Refresh();
                SetIndex();
            }
        }

        void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, VirtualAccountAllotEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler), sender, e); }
            else
            {

                List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<VirtualAccountInfo>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (null == list) list = new List<VirtualAccountInfo>();
                    if (list.Exists(o => o.Account == e.VirtualAllotAccount.Account))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Add_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (e.RowIndex > 0 && e.RowIndex < list.Count)
                    {
                        list.Insert(e.RowIndex - 1, e.VirtualAllotAccount);
                    }
                    else
                    {
                        list.Add(e.VirtualAllotAccount);
                    }
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (dgv.Rows.Count == 0 || (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.Account == e.VirtualAllotAccount.Account);
                    if (index != e.RowIndex - 1 && index != -1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Update_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    list[e.RowIndex - 1] = e.VirtualAllotAccount;
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < list.Count)
                    {
                        list.RemoveAt(e.RowIndex);
                    }
                }
                else if (OperatorCommandType.Load == e.Command)
                { list = e.VirtualAllotAccountList; }
                else return;
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                SetIndex();
            }
        }

        void SetIndex()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = i + 1;
            }
            dgv.Refresh();
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<VirtualAccountInfo> list = dgv.DataSource as List<VirtualAccountInfo>;
            VirtualAccountInfo payee = list[e.RowIndex];

            CommandCenter.Instance.ResolveVirtualAllotAccount(OperatorCommandType.Delete, payee, AppliableFunctionType.VirtualAccountTransfer, e.RowIndex);
        }

        void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            VirtualAccountInfo payee = (dgv.DataSource as List<VirtualAccountInfo>)[hitInfo.RowIndex];
            CommandCenter.Instance.ResolveVirtualAllotAccount(OperatorCommandType.View, payee, AppliableFunctionType.VirtualAccountTransfer, hitInfo.RowIndex + 1);
        }
    }
}
