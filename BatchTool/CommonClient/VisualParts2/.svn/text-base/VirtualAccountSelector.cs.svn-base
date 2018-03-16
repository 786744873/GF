using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class VirtualAccountSelector : BaseUc
    {
        public VirtualAccountSelector()
        {
            InitializeComponent();

            List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
            list.AddRange(SystemSettings.VirtualAllotAccountList.ToArray());
            if (list.Count > 0)
            {
                cmbAccountOut.Items.AddRange(list.ToArray());
                cmbAccountOut.Tag = list;
                cmbAccountIn.Items.AddRange(list.ToArray());
                cmbAccountIn.Tag = list;
                list.ForEach(o =>
                {
                    ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o });
                    ambiguityInputAgent2.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o });
                });
            }

            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            ambiguityInputAgent1.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent1_Selected);
            ambiguityInputAgent2.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent2_Selected);
            CommandCenter.OnVirtualAccountEventHandler += new EventHandler<VirtualAccountEventArgs>(CommandCenter_OnInitiativeAllotEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnVirtualAccountAllotEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAllotAccountEventHandler);

            InitData();
            SetRegex();
        }

        void ambiguityInputAgent2_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent2.SelectedItemIndex < 0) return;
            tbNameIn.Text = (ambiguityInputAgent2.SelectedEntity as VirtualAccountInfo).Name;
        }

        void ambiguityInputAgent1_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent1.SelectedItemIndex < 0) return;
            tbNameOut.Text = (ambiguityInputAgent1.SelectedEntity as VirtualAccountInfo).Name;
            string[] accountTop = cmbAccountOut.Text.Trim().Split(new string[] { "VA" }, StringSplitOptions.None);
            string TopStr = accountTop[0];
            List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
            list.AddRange(SystemSettings.VirtualAllotAccountList.ToArray());
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
            cmbAccountIn.Items.Clear();
            cmbAccountIn.Items.AddRange(list.ToArray());
            cmbAccountIn.Tag = list;
            ambiguityInputAgent2.ClearItems();
            list.ForEach(o => ambiguityInputAgent2.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
        }
        private void SetRegex()
        {
            cmbAccountOut.DvRegCode = "reg766";
            cmbAccountOut.DvMinLength = 1;
            cmbAccountOut.DvMaxLength = 35;
            cmbAccountOut.DvRequired = true;
            cmbAccountIn.DvRegCode = "reg766";
            cmbAccountIn.DvMinLength = 1;
            cmbAccountIn.DvMaxLength = 35;
            cmbAccountIn.DvRequired = true;
            tbNameIn.DvRegCode = "reg585";
            tbNameIn.DvMinLength = 1;
            tbNameIn.DvMaxLength = 120;
            tbNameIn.DvRequired = true;
            tbNameOut.DvRegCode = "reg585";
            tbNameOut.DvMinLength = 1;
            tbNameOut.DvMaxLength = 120;
            tbNameOut.DvRequired = true;
            //金额校验
            //tbAmount.DvRegCode = "reg43";
            //tbAmount.DvMinLength = 1;
            //tbAmount.DvMaxLength = 15;
            //rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            tbAddition.DvRegCode = "reg641";
            tbAddition.DvMinLength = 0;
            tbAddition.DvMaxLength = 200;
            tbAddition.DvRequired = false;
            tdCustomerBusinissNo.DvRegCode = "reg8";
            tdCustomerBusinissNo.DvMinLength = 0;
            tdCustomerBusinissNo.DvMaxLength = 16;
            tdCustomerBusinissNo.DvRequired = false;
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
                        cmbAccountIn.Items.Add(e.VirtualAllotAccount);
                        list.Add(e.VirtualAllotAccount);
                        cmbAccountOut.Tag = list;
                        cmbAccountIn.Tag = list;
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
                        cmbAccountIn.Items.Clear();
                        cmbAccountIn.Items.AddRange(list.ToArray());
                        cmbAccountIn.Tag = list;
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
                        cmbAccountIn.Items.Clear();
                        cmbAccountIn.Items.AddRange(list.ToArray());
                        cmbAccountIn.Tag = list;
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
                    cmbAccountIn.Items.Clear();
                    cmbAccountIn.Tag = listOut;
                    cmbAccountIn.Items.AddRange(listOut.ToArray());
                }
                ambiguityInputAgent1.ClearItems();
                ambiguityInputAgent2.ClearItems();
                if (cmbAccountOut.Items.Count > 0) (cmbAccountOut.Tag as List<VirtualAccountInfo>).ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                if (cmbAccountIn.Items.Count > 0) (cmbAccountIn.Tag as List<VirtualAccountInfo>).ForEach(o => ambiguityInputAgent2.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
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
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1);
                if (!rd.Result) return;
                tbAmount.Text = DataConvertHelper.FormatCash(tbAmount.Text.Trim(), false);
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
                cmbAccountIn.Text =
                tbNameIn.Text =
                tbAmount.Text =
                tdCustomerBusinissNo.Text =
                tbNameOut.Text =
                tbAddition.Text = string.Empty;
                cmbCashType.SelectedIndex = cmbCashType.Items.Count == 0 ? -1 : 0;
                cmbAccountOut.SelectedIndex = -1;
            }
            else
            {
                cmbAccountOut.Text = item.AccountOut;
                cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
                tbNameOut.Text = item.NameOut;
                cmbAccountIn.Text = item.AccountIn;
                tbNameIn.Text = item.NameIn;
                tbAmount.Text = item.Amount.ToString();
                tbAddition.Text = item.Purpose;
                tdCustomerBusinissNo.Text = item.CustomerBusinissNo;
                cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
            }
        }

        public void GetItem()
        {
            m_initiativeAllot = new VirtualAccount();
            m_initiativeAllot.AccountOut = cmbAccountOut.Text.Trim();
            m_initiativeAllot.NameOut = tbNameOut.Text.Trim();
            m_initiativeAllot.AccountIn = cmbAccountIn.Text.Trim();
            m_initiativeAllot.NameIn = tbNameIn.Text.Trim();
            m_initiativeAllot.CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_initiativeAllot.Amount = DataConvertHelper.FormatCash(tbAmount.Text.Trim(), m_initiativeAllot.CashType == CashType.JPY).Replace(",", "");
            m_initiativeAllot.Purpose = tbAddition.Text;
            m_initiativeAllot.CustomerBusinissNo = tdCustomerBusinissNo.Text;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData() { Result = true };
            rd.Result = base.CheckValid();
            //rd = DataCheckCenter.CheckElecTicketPersonAccountFC(cmbAccountOut, cmbAccountOut.Text.Trim(), lbAccountOut.Text.Substring(0, lbAccountOut.Text.Length - 1), 35, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            //rd = DataCheckCenter.CheckElecTicketPersonAccountFC(tbAccountIn, tbAccountIn.Text.Trim(), lbNameOut.Text.Substring(0, lbNameOut.Text.Length - 1), 35, this.errorProvider1);
            //if (!rd.Result) return rd.Result;


            //rd = DataCheckCenter.CheckVirtualAccountName(tbNameIn, tbNameIn.Text.Trim(), lbNameIn.Text.Substring(0, lbNameIn.Text.Length - 1), 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;


            //rd = DataCheckCenter.CheckVirtualAccountName(tbNameOut, tbNameOut.Text.Trim(), label6.Text.Substring(0, label6.Text.Length - 1), 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1).Result;
            //if (!rd.Result) return rd.Result;
            //if (!string.IsNullOrEmpty(tbAddition.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeeAddtion(tbAddition, tbAddition.Text.Trim(), lbAddition.Text.Substring(0, lbAddition.Text.Length - 1), 200, false, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(tdCustomerBusinissNo.Text))
            //{
            //    rd = DataCheckCenter.CheckCustomerRefNoGJOrUPEx(tdCustomerBusinissNo, tdCustomerBusinissNo.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            return rd.Result;
        }

        private void cmbAccountOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountOut.SelectedIndex < 0) return;
            List<VirtualAccountInfo> listName = new List<VirtualAccountInfo>();
            listName = SystemSettings.VirtualAllotAccountList.FindAll(o => o.Account == cmbAccountOut.SelectedItem.ToString());
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
            cmbAccountIn.Items.Clear();
            cmbAccountIn.Items.AddRange(list.ToArray());
            cmbAccountIn.Tag = list;
        }

        private void tbAccountIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountIn.SelectedIndex < 0) return;
            tbNameIn.Text = (cmbAccountIn.Tag as List<VirtualAccountInfo>)[cmbAccountIn.SelectedIndex].Name;
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbAmount.Text.Trim(), 14, cmbCashType.SelectedIndex == -1 ? CashType.CNY : (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex]);
        }
    }
}