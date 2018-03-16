using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.ConvertHelper;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
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
            CommandCenter.OnVirtualAccountAllotEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            //this.Load += new EventHandler(VirtualAllotAccountItemsPanel_Load);

            if (SystemSettings.VirtualAllotAccountList.Count > 0)
            {
                List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                list.AddRange(SystemSettings.VirtualAllotAccountList.GetRange(0, SystemSettings.VirtualAllotAccountList.Count));
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = list;
                dgv.Refresh();
            }

        }

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType._Empty) return;
                if (e.RowIndex < 0 || e.RowIndex > dgv.Rows.Count)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.ResolveVirtualAllotAccount(OperatorCommandType.View, (dgv.DataSource as List<VirtualAccountInfo>)[e.RowIndex], e.AppType, e.RowIndex);
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
            list.AddRange(SystemSettings.VirtualAllotAccountList.ToArray());
            if (list != null && list.Count > 0)
            {
                dgv.DataSource = list;
                dgv.Refresh();
                //SetIndex();
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
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (e.RowIndex > 0 && e.RowIndex < list.Count)
                    //    list.Insert(e.RowIndex - 1, e.VirtualAllotAccount);
                    //else
                        list.Add(e.VirtualAllotAccount);
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (dgv.Rows.Count == 0 || (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.Account == e.VirtualAllotAccount.Account);
                    if (index != e.RowIndex - 1 && index != -1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
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
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (e.Command == OperatorCommandType.Submit)
                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
            }
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<VirtualAccountInfo> list = dgv.DataSource as List<VirtualAccountInfo>;
            VirtualAccountInfo payee = list[e.RowIndex];

            CommandCenter.ResolveVirtualAllotAccount(OperatorCommandType.Delete, payee, AppliableFunctionType.VirtualAccountTransfer, e.RowIndex);
        }

        void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            VirtualAccountInfo payee = (dgv.DataSource as List<VirtualAccountInfo>)[hitInfo.RowIndex];
            CommandCenter.ResolveVirtualAllotAccount(OperatorCommandType.View, payee, AppliableFunctionType.VirtualAccountTransfer, hitInfo.RowIndex + 1);
        }
    }
}
