using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class VirtualAccountSelector : BaseUc
    {
        public VirtualAccountSelector()
        {
            InitializeComponent();

            List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
            list.AddRange(SystemSettings.Instance.VirtualAllotAccountList.ToArray());
            if (list.Count > 0)
            {
                cmbAccountOut.Items.AddRange(list.ToArray());
                cmbAccountOut.Tag = list;
                tbAccountIn.Items.AddRange(list.ToArray());
                tbAccountIn.Tag = list;
            }

            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.Instance.OnVirtualAccountEventEventHandler += new EventHandler<VirtualAccountEventArgs>(CommandCenter_OnInitiativeAllotEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnVirtualAccountAllotEventEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAllotAccountEventHandler);

            InitData();
        }

        void CommandCenter_OnVirtualAllotAccountEventHandler(object sender, VirtualAccountAllotEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAllotAccountEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (cmbAccountOut.Items.Count == 0 || (cmbAccountOut.Items.Count > 0 && !(cmbAccountOut.Tag as List<VirtualAccountInfo>).Exists(o => o.Account == e.VirtualAllotAccount.Account)))
                    {
                        List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                        if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<VirtualAccountInfo>;
                        cmbAccountOut.Items.Add(e.VirtualAllotAccount);
                        tbAccountIn.Items.Add(e.VirtualAllotAccount);
                        list.Add(e.VirtualAllotAccount);
                        cmbAccountOut.Tag = list;
                        tbAccountIn.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if (cmbAccountOut.Items.Count == 0 || (cmbAccountOut.Items.Count > 0 && !(cmbAccountOut.Tag as List<VirtualAccountInfo>).Exists(o => o.Account == e.VirtualAllotAccount.Account)))
                    {
                        List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                        if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<VirtualAccountInfo>;
                        //cmbAccountOut.Items.Add(e.VirtualAllotAccount);
                        //list.Add(e.VirtualAllotAccount);
                        list[e.RowIndex - 1] = e.VirtualAllotAccount;
                        cmbAccountOut.Items.Clear();
                        cmbAccountOut.Items.AddRange(list.ToArray());
                        cmbAccountOut.Tag = list;
                        tbAccountIn.Items.Clear();
                        tbAccountIn.Items.AddRange(list.ToArray());
                        tbAccountIn.Tag = list;
                    }
                    else
                    {
                        List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                        if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<VirtualAccountInfo>;
                        int index = list.FindIndex(o => o.Account == e.VirtualAllotAccount.Account);
                        if (index >= 0) list[index] = e.VirtualAllotAccount;
                        cmbAccountOut.Items.Clear();
                        cmbAccountOut.Items.AddRange(list.ToArray());
                        cmbAccountOut.Tag = list;
                        tbAccountIn.Items.Clear();
                        tbAccountIn.Items.AddRange(list.ToArray());
                        tbAccountIn.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    List<VirtualAccountInfo> listOut = new List<VirtualAccountInfo>();
                    if (cmbAccountOut.Tag != null) listOut = cmbAccountOut.Tag as List<VirtualAccountInfo>;
                    int index = listOut.FindIndex(o => o.Account == e.VirtualAllotAccount.Account);
                    if (index >= 0) { listOut.RemoveAt(index); }
                    cmbAccountOut.Items.Clear();
                    cmbAccountOut.Items.AddRange(listOut.ToArray());
                    cmbAccountOut.Tag = listOut;
                    tbAccountIn.Items.Clear();
                    tbAccountIn.Tag = listOut;
                    tbAccountIn.Items.AddRange(listOut.ToArray());
                }
            }
        }

        private void InitData()
        {
            cmbCashType.Items.Clear();
            List<CashType> list = new List<CashType> { CashType.MOP, CashType.NOK, CashType.DKK, CashType.SEK, CashType.NZD, CashType.GBP, CashType.CNY, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.DEM, CashType.FRF, CashType.NLG, CashType.ATS, CashType.BEF, CashType.ITL, CashType.FIM, CashType.PHP, CashType.THB, CashType.KRW, CashType.XHF, CashType.XUB, CashType.GLD };
            foreach (var item in list)
            {
                if (item == CashType.Empty) continue;
                string value = EnumNameHelper<CashType>.GetEnumDescription(item);
                cmbCashType.Items.Add(value);
            }
            cmbCashType.Tag = list;
            cmbCashType.SelectedIndex = 0;
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(VirtualAccountSelector), this);
                InitData();
            }
        }

        void CommandCenter_OnInitiativeAllotEventHandler(object sender, VirtualAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<VirtualAccountEventArgs>(CommandCenter_OnInitiativeAllotEventHandler), sender, e); }
            else
            {
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                { SetItem(e.InitiativeAccount); }
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
                if (AppliableFunctionType.VirtualAccountTransfer == value)
                {
                    m_AppType = value;
                }
            }
        }

        private VirtualAccount m_initiativeAllot;
        /// <summary>
        /// 主动调拨笔信息
        /// </summary>
        public VirtualAccount InitiativeAllot
        {
            get { return m_initiativeAllot; }
            set { m_initiativeAllot = value; }
        }

        public bool CanAddOut { get; set; }
        public bool CanAddIn { get; set; }

        private void SetItem(VirtualAccount item)
        {
            if (null == item)
            {
                cmbAccountOut.Text =
                tbAccountIn.Text =
                tbNameIn.Text =
                tbAmount.Text =
                tdCustomerBusinissNo.Text =
                tbNameOut.Text =
                tbAddition.Text = string.Empty;
                cmbAccountOut.SelectedIndex = -1;
            }
            else
            {
                cmbAccountOut.Text = item.AccountOut;
                tbNameOut.Text = item.NameOut;
                tbAccountIn.Text = item.NameOut;
                tbNameIn.Text = item.NameIn;
                tbAmount.Text = item.Amount.ToString();
                tbAddition.Text = item.Purpose;
                tdCustomerBusinissNo.Text = item.CustomerBusinissNo;
            }
        }

        public void GetItem()
        {
            m_initiativeAllot = new VirtualAccount();
            m_initiativeAllot.AccountOut = cmbAccountOut.Text.Trim();
            m_initiativeAllot.NameOut = tbNameOut.Text.Trim();
            m_initiativeAllot.AccountIn = tbAccountIn.Text.Trim();
            m_initiativeAllot.NameIn = tbNameIn.Text.Trim();
            m_initiativeAllot.Amount = DataConvertHelper.Instance.FormatCash(tbAmount.Text.Trim(), false).Replace(",", "");
            m_initiativeAllot.CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_initiativeAllot.Purpose = tbAddition.Text;
            m_initiativeAllot.CustomerBusinissNo = tdCustomerBusinissNo.Text;

        }

        public bool CheckData()
        {
            ResultData rd = new ResultData() { Result = true };
            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(cmbAccountOut, cmbAccountOut.Text.Trim(), lbAccountOut.Text.Substring(0, lbAccountOut.Text.Length - 1), 35, this.errorProvider1);
            if (!rd.Result) return rd.Result;

            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(tbAccountIn, tbAccountIn.Text.Trim(), lbNameOut.Text.Substring(0, lbNameOut.Text.Length - 1), 35, this.errorProvider1);
            if (!rd.Result) return rd.Result;


            rd = DataCheckCenter.Instance.CheckVirtualAccountName(tbNameIn, tbNameIn.Text.Trim(), lbNameIn.Text.Substring(0, lbNameIn.Text.Length - 1), 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;


            rd = DataCheckCenter.Instance.CheckVirtualAccountName(tbNameOut, tbNameOut.Text.Trim(), label6.Text.Substring(0, label6.Text.Length - 1), 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;

            rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbAddition.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayeeAddtion(tbAddition, tbAddition.Text.Trim(), lbAddition.Text.Substring(0, lbAddition.Text.Length - 1), 200, false, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(tdCustomerBusinissNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(tdCustomerBusinissNo, tdCustomerBusinissNo.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return rd.Result;
        }

        private void cmbAccountOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountOut.SelectedIndex < 0) return;
            List<VirtualAccountInfo> listName = new List<VirtualAccountInfo>();
            listName= SystemSettings.Instance.VirtualAllotAccountList.FindAll(o => o.Account == cmbAccountOut.SelectedItem.ToString());
            tbNameOut.Text = listName[0].Name;
            string[] accountTop = cmbAccountOut.SelectedItem.ToString().Split(new string[] { "VA" }, StringSplitOptions.None);
            string TopStr = accountTop[0];
            List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
            if (cmbAccountOut.Tag != null) list = cmbAccountOut.Tag as List<VirtualAccountInfo>;
            if (!string.IsNullOrEmpty(TopStr) && accountTop.Length >= 2)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string[] accountTopItem = list[i].Account.Split(new string[] { "VA" }, StringSplitOptions.None);
                    if (!(!string.IsNullOrEmpty(accountTopItem[0]) && accountTopItem.Length >= 2 && accountTopItem[0].Equals(TopStr)))
                    {
                        list.Remove(list[i]);
                    }
                }
            }
            tbAccountIn.Items.Clear();
            tbAccountIn.Items.AddRange(list.ToArray());
            tbAccountIn.Tag = list;
        }

        private void tbAccountIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbAccountIn.SelectedIndex < 0) return;
            List<VirtualAccountInfo> listName = new List<VirtualAccountInfo>();
            listName = SystemSettings.Instance.VirtualAllotAccountList.FindAll(o => o.Account == tbAccountIn.SelectedItem.ToString());
            tbNameIn.Text = listName[0].Name;
        }
    }
}