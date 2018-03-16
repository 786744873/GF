using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class PreproccessTransferSelector : BaseUc
    {
        public PreproccessTransferSelector()
        {
            InitializeComponent();

            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbPreproccessAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.OnPreproccessTransferEventHandler += new EventHandler<PreproccessTransferEventArgs>(CommandCenter_OnPreproccessTransferEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnVirtualAccountAllotEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAccountAllotEventHandler);
            InitData();
            SetRegex();
        }
        private void SetRegex()
        {
            cmbVirtualAccount.DvRegCode = "reg766";
            cmbVirtualAccount.DvMinLength = 1;
            cmbVirtualAccount.DvMaxLength = 35;
        }
        void CommandCenter_OnVirtualAccountAllotEventHandler(object sender, VirtualAccountAllotEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAccountAllotEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (cmbVirtualAccount.Items.Count == 0 || (cmbVirtualAccount.Items.Count > 0 && !(cmbVirtualAccount.Tag as List<VirtualAccountInfo>).Exists(o => o.Account == e.VirtualAllotAccount.Account)))
                    {
                        List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                        if (cmbVirtualAccount.Tag != null) list = cmbVirtualAccount.Tag as List<VirtualAccountInfo>;
                        cmbVirtualAccount.Items.Add(e.VirtualAllotAccount);
                        list.Add(e.VirtualAllotAccount);
                        cmbVirtualAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if (cmbVirtualAccount.Items.Count == 0 || (cmbVirtualAccount.Items.Count > 0 && !(cmbVirtualAccount.Tag as List<VirtualAccountInfo>).Exists(o => o.Account == e.VirtualAllotAccount.Account)))
                    {
                        List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                        if (cmbVirtualAccount.Tag != null) list = cmbVirtualAccount.Tag as List<VirtualAccountInfo>;
                        list[e.RowIndex - 1] = e.VirtualAllotAccount;
                        cmbVirtualAccount.Items.AddRange(list.ToArray());
                        cmbVirtualAccount.Tag = list;
                    }
                    else
                    {
                        List<VirtualAccountInfo> list = new List<VirtualAccountInfo>();
                        if (cmbVirtualAccount.Tag != null) list = cmbVirtualAccount.Tag as List<VirtualAccountInfo>;
                        int index = list.FindIndex(o => o.Account == e.VirtualAllotAccount.Account);
                        if (index >= 0) list[index] = e.VirtualAllotAccount;
                        cmbVirtualAccount.Items.Clear();
                        cmbVirtualAccount.Items.AddRange(list.ToArray());
                        cmbVirtualAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    List<VirtualAccountInfo> listOut = new List<VirtualAccountInfo>();
                    if (cmbVirtualAccount.Tag != null) listOut = cmbVirtualAccount.Tag as List<VirtualAccountInfo>;
                    int index = listOut.FindIndex(o => o.Account == e.VirtualAllotAccount.Account);
                    if (index >= 0) { listOut.RemoveAt(index); }
                    cmbVirtualAccount.Items.Clear();
                    cmbVirtualAccount.Items.AddRange(listOut.ToArray());
                    cmbVirtualAccount.Tag = listOut;
                }

                ambiguityInputAgent1.ClearItems();
                if (cmbVirtualAccount.Items.Count > 0)
                    (cmbVirtualAccount.Tag as List<VirtualAccountInfo>).ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }
        }

        private void InitData()
        {
            cmbVirtualAccount.Items.Clear();
            List<VirtualAccountInfo> lista = new List<VirtualAccountInfo>();
            lista.AddRange(SystemSettings.VirtualAllotAccountList.ToArray());
            if (lista.Count > 0)
            {
                cmbVirtualAccount.Items.AddRange(lista.ToArray());
                cmbVirtualAccount.Tag = lista;
                ambiguityInputAgent1.ClearItems();
                lista.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }

            cmbCashType.Items.Clear();
            List<CashType> listc = new List<CashType> { CashType.MOP, CashType.NOK, CashType.DKK, CashType.SEK, CashType.NZD, CashType.GBP, CashType.CNY, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.DEM, CashType.FRF, CashType.NLG, CashType.ATS, CashType.BEF, CashType.ITL, CashType.FIM, CashType.PHP, CashType.THB, CashType.KRW, CashType.XHF, CashType.XUB, CashType.GLD };
            foreach (var item in listc)
            {
                if (item == CashType.Empty) continue;
                string value = EnumNameHelper<CashType>.GetEnumDescription(item);
                cmbCashType.Items.Add(value);
            }
            cmbCashType.Tag = listc;
            cmbCashType.SelectedIndex = 0;
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PreproccessTransferSelector), this);
                InitData();
            }
        }

        void CommandCenter_OnPreproccessTransferEventHandler(object sender, PreproccessTransferEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PreproccessTransferEventArgs>(CommandCenter_OnPreproccessTransferEventHandler), sender, e); }
            else
            {
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                { SetItem(e.PreproccessTransfer); }
                else if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!(sender is Controls.TextBoxCanValidate)) return;
            var ctl = sender as Controls.TextBoxCanValidate;
            if (string.IsNullOrEmpty(ctl.Text.Trim())) return;
            bool isjpy = cmbCashType.SelectedIndex < 0 ? false : cmbCashType.Tag != null ? (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex] == CashType.JPY : false;
            bool flag = ctl.Text.Trim().StartsWith("-");
            ResultData rd = DataCheckCenter.CheckCash(ctl, ctl.Text.Trim().Substring(flag ? 1 : 0), "", 16, isjpy, this.errorProvider1, true);
            if (!rd.Result) return;
            ctl.Text = DataConvertHelper.FormatCash(ctl.Text.Trim(), isjpy);
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
                if (AppliableFunctionType.PreproccessTransfer == value)
                {
                    m_AppType = value;
                }
            }
        }

        private PreproccessTransfer m_PreproccessTransfer;
        /// <summary>
        /// 主动调拨笔信息
        /// </summary>
        public PreproccessTransfer PreproccessTransfer
        {
            get { return m_PreproccessTransfer; }
            set { m_PreproccessTransfer = value; }
        }

        public bool CanAddOut { get; set; }
        public bool CanAddIn { get; set; }

        private void SetItem(PreproccessTransfer item)
        {
            if (null == item)
            {
                cmbVirtualAccount.Text =
                tbPreproccessAccount.Text =
                tbPreproccessName.Text =
                tbAmount.Text =
                tbPreproccessAmount.Text =
                cmbCashType.Text =
                tbMainAccount.Text =
                tbTradeSerialNo.Text =
                tbBatchTradeSerialNo.Text =
                tbInvolvedAccount.Text =
                tbInvolvedName.Text =
                tbContent.Text = string.Empty;
                cmbCashType.SelectedIndex = cmbCashType.Items.Count == 0 ? -1 : 0;
                cmbVirtualAccount.SelectedIndex = -1;
                dtpTradeDate.Value = DateTime.Today;
            }
            else
            {
                cmbVirtualAccount.Text = item.VirtualAccount;
                tbPreproccessAccount.Text = item.PreproccessAccount;
                tbPreproccessName.Text = item.PreproccessName;
                tbAmount.Text = item.Amount;
                tbPreproccessAmount.Text = item.PreproccessAmount;
                tbMainAccount.Text = item.MainAccount;
                tbTradeSerialNo.Text = item.TradeSerialNo;
                tbBatchTradeSerialNo.Text = item.BatchTradeSerialNo;
                tbInvolvedAccount.Text = item.InvolvedAccount;
                tbInvolvedName.Text = item.InvolvedName;
                tbContent.Text = item.Content;
                cmbCashType.SelectedIndex = cmbCashType.Items.Count == 0 ? -1 : (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
                try
                {
                    dtpTradeDate.Value = DateTime.Parse(item.TradeDate);
                }
                catch { }
            }
        }

        public void GetItem()
        {
            m_PreproccessTransfer = new PreproccessTransfer();
            m_PreproccessTransfer.PreproccessAccount = tbPreproccessAccount.Text.Trim();
            m_PreproccessTransfer.PreproccessName = tbPreproccessName.Text.Trim();
            m_PreproccessTransfer.CashType = cmbCashType.SelectedIndex < 0 ? CashType.Empty : (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_PreproccessTransfer.PreproccessAmount = tbPreproccessAmount.Text.Trim().Replace(",", "");
            m_PreproccessTransfer.MainAccount = tbMainAccount.Text.Trim();
            m_PreproccessTransfer.TradeSerialNo = tbTradeSerialNo.Text.Trim();
            m_PreproccessTransfer.BatchTradeSerialNo = tbBatchTradeSerialNo.Text.Trim();
            m_PreproccessTransfer.InvolvedAccount = tbInvolvedAccount.Text.Trim();
            m_PreproccessTransfer.InvolvedName = tbInvolvedName.Text.Trim();
            m_PreproccessTransfer.TradeDate = DataConvertHelper.FormatDateTimeFromInt(dtpTradeDate.Value.Date.ToString("yyyy/MM/dd"));
            m_PreproccessTransfer.Content = tbContent.Text.Trim();
            m_PreproccessTransfer.VirtualAccount = cmbVirtualAccount.Text.Trim();
            m_PreproccessTransfer.Amount = DataConvertHelper.FormatCash(tbAmount.Text.Trim(),  m_PreproccessTransfer.CashType==CashType.JPY ).Replace(",", "");
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData() { Result = true };
            rd.Result = base.CheckValid();
            //rd = DataCheckCenter.CheckElecTicketPersonAccountFC(cmbVirtualAccount, cmbVirtualAccount.Text.Trim(), lbAccountOut.Text.Substring(0, lbAccountOut.Text.Length - 1), 35, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            bool isjpy = cmbCashType.SelectedIndex < 0 ? false : cmbCashType.Tag != null ? (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex] == CashType.JPY : false;
            //rd = DataCheckCenter.CheckCash(tbPreproccessAmount, tbPreproccessAmount.Text.Trim(), "", 16, isjpy, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim().Replace("-", ""), "", 16, isjpy, this.errorProvider1, true).Result;
            //rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 14, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            return rd.Result;
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbAmount.Text.Trim(), 16, cmbCashType.SelectedIndex == -1 ? CashType.CNY : (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex]);
        }
    }
}
