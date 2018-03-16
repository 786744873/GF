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
    public partial class InitiativeAllotAccountItemsPanel : BaseUc
    {
        public InitiativeAllotAccountItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            this.Load += new EventHandler(InitiativeAllotAccountItemsPanel_Load);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
            CommandCenter.OnInitiativeAllotAccountEventHandler += new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
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
                CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.View, (dgv.DataSource as List<InitiativeAllotAccount>)[e.RowIndex], e.AppType, e.RowIndex);
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(InitiativeAllotAccountItemsPanel), this);
            }
        }

        void InitiativeAllotAccountItemsPanel_Load(object sender, EventArgs e)
        {
            List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
            list.AddRange(SystemSettings.InitiativeAllotAccountList.ToArray());
            if (list != null && list.Count > 0)
            {
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = list;
            }
        }

        void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, InitiativeAllotAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler), sender, e); }
            else
            {
                List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<InitiativeAllotAccount>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (null == list) list = new List<InitiativeAllotAccount>();
                    if (list.Exists(o => o.Account == e.InitiativeAllotAccount.Account))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (e.RowIndex > 0 && e.RowIndex < list.Count)
                    //    list.Insert(e.RowIndex - 1, e.InitiativeAllotAccount);
                    //else
                    list.Add(e.InitiativeAllotAccount);
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (dgv.Rows.Count == 0 || (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count))
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.Account == e.InitiativeAllotAccount.Account);
                    if (index != e.RowIndex - 1 && index != -1)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    list[e.RowIndex - 1] = e.InitiativeAllotAccount;
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < list.Count)
                        list.RemoveAt(e.RowIndex);
                }
                else if (OperatorCommandType.Load == e.Command)
                { list = e.InitiativeAllotAccountList; }
                else return;
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
            }
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<InitiativeAllotAccount> list = dgv.DataSource as List<InitiativeAllotAccount>;
            InitiativeAllotAccount payee = list[e.RowIndex];

            CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.Delete, payee, AppliableFunctionType._Empty, e.RowIndex);
        }

        void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            InitiativeAllotAccount payee = (dgv.DataSource as List<InitiativeAllotAccount>)[hitInfo.RowIndex];
            CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.View, payee, AppliableFunctionType._Empty, hitInfo.RowIndex + 1);
        }
    }
}
