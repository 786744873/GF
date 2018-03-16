using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class InitiativeAllotEditor : BaseUc
    {
        public InitiativeAllotEditor()
        {
            InitializeComponent();

            List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
            list.AddRange(SystemSettings.Instance.InitiativeAllotAccountList.ToArray());
            if (list.Count > 0)
            {
                cmbAccountOut.Items.AddRange(list.ToArray());
                cmbAccountIn.Items.AddRange(list.ToArray());
                cmbAccountOut.Tag =
                cmbAccountIn.Tag = list;
            }

            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.Instance.OnInitiativeAllotEventHandler += new EventHandler<InitiativeAllotEventArgs>(CommandCenter_OnInitiativeAllotEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnInitiativeAllotAccountEventHandler += new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);

            InitData();
        }

        void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, InitiativeAllotAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (cmbAccountIn.Items.Count == 0 || (cmbAccountIn.Items.Count > 0 && !(cmbAccountIn.Tag as List<InitiativeAllotAccount>).Exists(o => o.Account == e.InitiativeAllotAccount.Account)))
                    {
                        List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                        if (cmbAccountIn.Tag != null) list = cmbAccountIn.Tag as List<InitiativeAllotAccount>;
                        cmbAccountIn.Items.Add(e.InitiativeAllotAccount);
                        list.Add(e.InitiativeAllotAccount);
                        cmbAccountIn.Tag = list;
                    }
                    if (cmbAccountOut.Items.Count == 0 || (cmbAccountOut.Items.Count > 0 && !(cmbAccountOut.Tag as List<InitiativeAllotAccount>).Exists(o => o.Account == e.InitiativeAllotAccount.Account)))
                    {
                        List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                        if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<InitiativeAllotAccount>;
                        cmbAccountOut.Items.Add(e.InitiativeAllotAccount);
                        list.Add(e.InitiativeAllotAccount);
                        cmbAccountOut.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if (cmbAccountIn.Items.Count == 0 || (cmbAccountIn.Items.Count > 0 && !(cmbAccountIn.Tag as List<InitiativeAllotAccount>).Exists(o => o.Account == e.InitiativeAllotAccount.Account)))
                    {
                        List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                        if (cmbAccountIn.Tag != null) list = cmbAccountIn.Tag as List<InitiativeAllotAccount>;
                        cmbAccountIn.Items.Add(e.InitiativeAllotAccount);
                        list.Add(e.InitiativeAllotAccount);
                        cmbAccountIn.Tag = list;
                    }
                    else
                    {
                        List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                        if (cmbAccountIn.Tag != null) list = cmbAccountIn.Tag as List<InitiativeAllotAccount>;
                        int index = list.FindIndex(o => o.Account == e.InitiativeAllotAccount.Account);
                        if (index >= 0) list[index] = e.InitiativeAllotAccount;
                        cmbAccountIn.Tag = list;
                    }
                    if (cmbAccountOut.Items.Count == 0 || (cmbAccountOut.Items.Count > 0 && !(cmbAccountOut.Tag as List<InitiativeAllotAccount>).Exists(o => o.Account == e.InitiativeAllotAccount.Account)))
                    {
                        List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                        if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<InitiativeAllotAccount>;
                        cmbAccountOut.Items.Add(e.InitiativeAllotAccount);
                        list.Add(e.InitiativeAllotAccount);
                        cmbAccountOut.Tag = list;
                    }
                    else
                    {
                        List<InitiativeAllotAccount> list = new List<InitiativeAllotAccount>();
                        if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<InitiativeAllotAccount>;
                        int index = list.FindIndex(o => o.Account == e.InitiativeAllotAccount.Account);
                        if (index >= 0) list[index] = e.InitiativeAllotAccount;
                        cmbAccountOut.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    List<InitiativeAllotAccount> listIn = new List<InitiativeAllotAccount>();
                    if (cmbAccountIn.Tag != null) listIn = cmbAccountIn.Tag as List<InitiativeAllotAccount>;
                    int index = listIn.FindIndex(o => o.Account == e.InitiativeAllotAccount.Account);
                    if (index >= 0) listIn.RemoveAt(index);
                    cmbAccountIn.Tag = listIn;
                    List<InitiativeAllotAccount> listOut = new List<InitiativeAllotAccount>();
                    if (cmbAccountOut.Tag != null) listOut = cmbAccountOut.Tag as List<InitiativeAllotAccount>;
                    index = listOut.FindIndex(o => o.Account == e.InitiativeAllotAccount.Account);
                    if (index >= 0) listOut.RemoveAt(index);
                    cmbAccountOut.Tag = listOut;
                }
            }
        }

        private void InitData()
        {
            cmbCashType.Items.Clear();
            cmbCashType.Text = EnumNameHelper<CashType>.GetEnumDescription(CashType.CNY);
            cmbCashType.DropDownStyle = ComboBoxStyle.Simple;
            cmbCashType.Enabled = false;
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(InitiativeAllotEditor), this);
                InitData();
            }
        }

        void CommandCenter_OnInitiativeAllotEventHandler(object sender, InitiativeAllotEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<InitiativeAllotEventArgs>(CommandCenter_OnInitiativeAllotEventHandler), sender, e); }
            else
            {
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                { SetItem(e.InitiativeAllot); }
                else if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                tbAmount.Text = DataConvertHelper.Instance.FormatCash(tbAmount.Text.Trim(), false);
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// 
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.InitiativeAllot == value)
                {
                    m_AppType = value;
                }
            }
        }

        private InitiativeAllot m_initiativeAllot;
        /// <summary>
        /// 主动调拨笔信息
        /// </summary>
        public InitiativeAllot InitiativeAllot
        {
            get { return m_initiativeAllot; }
            set { m_initiativeAllot = value; }
        }

        public bool CanAddOut { get; set; }
        public bool CanAddIn { get; set; }

        private void SetItem(InitiativeAllot item)
        {
            if (null == item)
            {
                cmbAccountOut.Text =
                tbNameOut.Text =
                cmbAccountIn.Text =
                tbNameIn.Text =
                tbAmount.Text =
                tbAddition.Text = string.Empty;
                cmbAccountOut.SelectedIndex =
                cmbAccountIn.SelectedIndex = -1;
            }
            else
            {
                cmbAccountOut.Text = item.AccountOut;
                tbNameOut.Text = item.NameOut;
                cmbAccountIn.Text = item.AccountIn;
                tbNameIn.Text = item.NameIn;
                tbAmount.Text = item.Amount.ToString();
                tbAddition.Text = item.Addition;
            }
            chbIn.Checked = chbOut.Checked = false;
        }

        public void GetItem()
        {
            m_initiativeAllot = new InitiativeAllot();
            m_initiativeAllot.AccountOut = cmbAccountOut.Text.Trim();
            m_initiativeAllot.AccountIn = cmbAccountIn.Text.Trim();
            m_initiativeAllot.NameOut = tbNameOut.Text.Trim();
            m_initiativeAllot.NameIn = tbNameIn.Text.Trim();
            m_initiativeAllot.Amount = DataConvertHelper.Instance.FormatCash(tbAmount.Text.Trim(), false).Replace(",", "");
            m_initiativeAllot.Addition = tbAddition.Text.Trim();
            m_initiativeAllot.CashType = CashType.CNY;
            CanAddOut = chbOut.Checked;
            CanAddIn = chbIn.Checked;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData() { Result = true };
            rd = DataCheckCenter.Instance.CheckAccountExIA(cmbAccountOut, cmbAccountOut.Text.Trim(), lbAccountOut.Text.Substring(0, lbAccountOut.Text.Length - 1), 22, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbNameOut.Text))
            {
                rd = DataCheckCenter.Instance.CheckNameExIA(tbNameOut, tbNameOut.Text.Trim(), lbNameOut.Text.Substring(0, lbNameOut.Text.Length - 1), 76, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckAccountExIA(cmbAccountIn, cmbAccountIn.Text.Trim(), lbAccountIn.Text.Substring(0, lbAccountIn.Text.Length - 1), 22, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbNameIn.Text))
            {
                rd = DataCheckCenter.Instance.CheckNameExIA(tbNameIn, tbNameIn.Text.Trim(), lbNameIn.Text.Substring(0, lbNameIn.Text.Length - 1), 76, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbAddition.Text))
            {
                rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(tbAddition, tbAddition.Text.Trim(), lbAddition.Text.Substring(0, lbAddition.Text.Length - 1), 200, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return rd.Result;
        }
    }
}
