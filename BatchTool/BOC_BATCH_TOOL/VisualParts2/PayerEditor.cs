using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.VisualParts;

namespace BOC_BATCH_TOOL.VisualElements
{
    public partial class PayerEditor : BaseUc
    {
        private PayerInfo m_payer = null;

        public PayerEditor()
        {
            InitializeComponent();
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);

            InitData();
            cmbCashType.SelectedIndexChanged += new EventHandler(cmbCashType_SelectedIndexChanged);
        }

        void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.AppVisiableResolve)
                {
                    cbTransferInd.Checked = cbTransferInd.Enabled = (e.AppVisiable & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv;
                    cbTransferEnt.Checked = cbTransferEnt.Enabled = (e.AppVisiable & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
                    cbExpressAgentIn.Checked = cbExpressAgentIn.Enabled = (e.AppVisiable & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn;
                    cbExpressAgentOut.Checked = cbExpressAgentOut.Enabled = (e.AppVisiable & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                    cbNormalAgentIn.Checked = cbNormalAgentIn.Enabled = (e.AppVisiable & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn;
                    cbNormalAgentOut.Checked = cbNormalAgentOut.Enabled = (e.AppVisiable & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut;
                    cbOverBankIn.Checked = cbOverBankIn.Enabled = (e.AppVisiable & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn;
                    cbOverBankOut.Checked = cbOverBankOut.Enabled = (e.AppVisiable & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut;
                    cbElecTicketRemit.Checked = cbElecTicketRemit.Enabled = ((e.AppVisiable & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit || (e.AppVisiable & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange);
                    cbElecTicketPayMoney.Checked = cbElecTicketPayMoney.Enabled = ((e.AppVisiable & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney || (e.AppVisiable & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote);
                    cbTransferOverCounty.Checked = cbTransferOverCounty.Enabled = (e.AppVisiable & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
                    cbTransferForeignMoney.Checked = cbTransferForeignMoney.Enabled = (e.AppVisiable & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;

                    if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                    {
                        cbExpressAgentOutBar.Checked = cbExpressAgentOutBar.Enabled = (SystemSettings.Instance.AppliableTypes4Bar & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                        cbTransferOverCountyBar.Checked = cbTransferOverCountyBar.Enabled = (SystemSettings.Instance.AppliableTypes4Bar & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
                        cbTransferForeignMoneyBar.Checked = cbTransferForeignMoneyBar.Enabled = (SystemSettings.Instance.AppliableTypes4Bar & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;
                    }

                    if (!cbTransferOverCounty.Checked) cbTransferOverCounty.Enabled = (e.AppVisiableBar & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
                    if (!cbTransferEnt.Checked) cbTransferEnt.Enabled = (e.AppVisiableBar & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
                    if (!cbExpressAgentOut.Checked) cbExpressAgentOut.Enabled = (e.AppVisiableBar & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                    if (!cbTransferForeignMoney.Checked) cbTransferForeignMoney.Enabled = (e.AppVisiableBar & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;
                }
            }
        }

        void cmbCashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCashType.SelectedIndex < 0) return;
            if (cmbCashType.Tag == null) return;
            if ((cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex] == CashType.CNY)
            {
                cbTransferInd.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv;
                cbTransferEnt.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
                cbExpressAgentIn.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn;
                cbExpressAgentOut.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                cbNormalAgentIn.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn;
                cbNormalAgentOut.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut;
                cbOverBankIn.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn;
                cbOverBankOut.Enabled = (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut;
                cbElecTicketRemit.Enabled = ((SystemSettings.Instance.AppliableTypes & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit || (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange);
                cbElecTicketPayMoney.Enabled = ((SystemSettings.Instance.AppliableTypes & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney || (SystemSettings.Instance.AppliableTypes & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote);
                if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                {
                    cbExpressAgentOutBar.Enabled = (SystemSettings.Instance.AppliableTypes4Bar & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                }
            }
            else
            {
                cbTransferInd.Enabled =
                cbTransferEnt.Enabled =
                cbExpressAgentIn.Enabled =
                cbExpressAgentOut.Enabled =
                cbNormalAgentIn.Enabled =
                cbNormalAgentOut.Enabled =
                cbOverBankIn.Enabled =
                cbOverBankOut.Enabled =
                cbElecTicketRemit.Enabled =
                cbElecTicketPayMoney.Enabled =
                cbTransferInd.Checked =
                cbTransferEnt.Checked =
                cbExpressAgentIn.Checked =
                cbExpressAgentOut.Checked =
                cbNormalAgentIn.Checked =
                cbNormalAgentOut.Checked =
                cbOverBankIn.Checked =
                cbOverBankOut.Checked =
                cbElecTicketRemit.Checked =
                cbElecTicketPayMoney.Checked = false;
                if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                {
                    cbExpressAgentOutBar.Enabled = cbExpressAgentOutBar.Checked = false;
                }
            }
        }

        private void InitData()
        {
            cmbCashType.Items.Clear();
            List<CashType> list = new List<CashType> { CashType.CNY, CashType.GBP, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.SEK, CashType.DKK, CashType.NOK, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.MOP, CashType.PHP, CashType.THB, CashType.NZD, CashType.KRW };
            foreach (var item in list)
            {
                if (item == CashType.Empty) continue;
                string value = EnumNameHelper<CashType>.GetEnumDescription(item);
                cmbCashType.Items.Add(value);
            }
            cmbCashType.Tag = list;
            cmbCashType.SelectedIndex = 0;

            cbTransferForeignMoney.Visible = cbTransferOverCounty.Visible = cbElecTicketRemit.Visible = cbElecTicketPayMoney.Visible = (SystemSettings.Instance.CurrentVersion & VersionType.v402) == VersionType.v402;
            cbExpressAgentOutBar.Visible = cbTransferForeignMoneyBar.Visible = cbTransferOverCountyBar.Visible = (SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar;

            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                pServiceNet.Visible = false;
                pServiceBar.Visible = true;
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PayerEditor), this);
                InitData();
            }
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), new object[] { sender, e }); }
            else
            {
                this.errorProvider1.Clear();
                if (OperatorCommandType.View == e.Command)
                {
                    m_payer = e.PayerInfo;
                    SetItem(e.PayerInfo, e.RowIndex);
                }
            }
        }

        public PayerInfo GetItem()
        {
            var item = new PayerInfo { Account = this.edtPayerAccount.Text, Name = this.edtPayerName.Text };
            item.CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];

            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
                item.ServiceList = GetServices(false);
            else
                item.ServiceListBar = GetServices(true);

            return item;
        }

        private AppliableFunctionType GetServices(bool isBar)
        {
            var functionTypes = AppliableFunctionType._Empty;
            if (!isBar)
            {
                functionTypes = cbTransferInd.Checked ? functionTypes | AppliableFunctionType.TransferWithIndiv : functionTypes;
                functionTypes = cbTransferEnt.Checked ? functionTypes | AppliableFunctionType.TransferWithCorp : functionTypes;
                functionTypes = cbExpressAgentOut.Checked ? functionTypes | AppliableFunctionType.AgentExpressOut : functionTypes;
                functionTypes = cbExpressAgentIn.Checked ? functionTypes | AppliableFunctionType.AgentExpressIn : functionTypes;
                functionTypes = cbNormalAgentIn.Checked ? functionTypes | AppliableFunctionType.AgentNormalIn : functionTypes;
                functionTypes = cbNormalAgentOut.Checked ? functionTypes | AppliableFunctionType.AgentNormalOut : functionTypes;
                functionTypes = cbOverBankIn.Checked ? functionTypes | AppliableFunctionType.TransferOverBankIn : functionTypes;
                functionTypes = cbOverBankOut.Checked ? functionTypes | AppliableFunctionType.TransferOverBankOut : functionTypes;
                functionTypes = cbElecTicketRemit.Checked ? functionTypes | AppliableFunctionType.ElecTicketRemit | AppliableFunctionType.ElecTicketTipExchange : functionTypes;
                functionTypes = cbElecTicketPayMoney.Checked ? functionTypes | AppliableFunctionType.ElecTicketPayMoney | AppliableFunctionType.ElecTicketBackNote : functionTypes;
                functionTypes = cbTransferOverCounty.Checked ? functionTypes | AppliableFunctionType.TransferOverCountry : functionTypes;
                functionTypes = cbTransferForeignMoney.Checked ? functionTypes | AppliableFunctionType.TransferForeignMoney : functionTypes;
            }
            else
            {
                functionTypes = cbExpressAgentOutBar.Checked ? functionTypes | AppliableFunctionType.AgentExpressOut : functionTypes;
                functionTypes = cbTransferOverCountyBar.Checked ? functionTypes | AppliableFunctionType.TransferOverCountry : functionTypes;
                functionTypes = cbTransferForeignMoneyBar.Checked ? functionTypes | AppliableFunctionType.TransferForeignMoney : functionTypes;
            }
            return functionTypes;
        }

        public void SetItem(PayerInfo item, int rowindex)
        {
            if (null == item) return;
            this.tbRowIndex.Text = rowindex.ToString();
            this.edtPayerAccount.Text = item.Account;
            this.edtPayerName.Text = item.Name;

            cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);

            if ((SystemSettings.Instance.CurrentVersion & VersionType.v307) == VersionType.v307)
            {
                cbTransferInd.Checked = (AppliableFunctionType.TransferWithIndiv & item.ServiceList) == AppliableFunctionType.TransferWithIndiv;
                cbTransferEnt.Checked = (AppliableFunctionType.TransferWithCorp & item.ServiceList) == AppliableFunctionType.TransferWithCorp;
                cbExpressAgentOut.Checked = (AppliableFunctionType.AgentExpressOut & item.ServiceList) == AppliableFunctionType.AgentExpressOut;
                cbExpressAgentIn.Checked = (AppliableFunctionType.AgentExpressIn & item.ServiceList) == AppliableFunctionType.AgentExpressIn;
                cbNormalAgentOut.Checked = (AppliableFunctionType.AgentNormalOut & item.ServiceList) == AppliableFunctionType.AgentNormalOut;
                cbNormalAgentIn.Checked = (AppliableFunctionType.AgentNormalIn & item.ServiceList) == AppliableFunctionType.AgentNormalIn;
                cbOverBankOut.Checked = (AppliableFunctionType.TransferOverBankOut & item.ServiceList) == AppliableFunctionType.TransferOverBankOut;
                cbOverBankIn.Checked = (AppliableFunctionType.TransferOverBankIn & item.ServiceList) == AppliableFunctionType.TransferOverBankIn;
            }
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v402) == VersionType.v402)
            {
                cbElecTicketRemit.Checked = (AppliableFunctionType.ElecTicketRemit & item.ServiceList) == AppliableFunctionType.ElecTicketRemit || (AppliableFunctionType.ElecTicketTipExchange & item.ServiceList) == AppliableFunctionType.ElecTicketTipExchange;
                cbElecTicketPayMoney.Checked = (AppliableFunctionType.ElecTicketPayMoney & item.ServiceList) == AppliableFunctionType.ElecTicketPayMoney || (AppliableFunctionType.ElecTicketBackNote & item.ServiceList) == AppliableFunctionType.ElecTicketBackNote;
                cbTransferOverCounty.Checked = (AppliableFunctionType.TransferOverCountry & item.ServiceList) == AppliableFunctionType.TransferOverCountry;
                cbTransferForeignMoney.Checked = (AppliableFunctionType.TransferForeignMoney & item.ServiceList) == AppliableFunctionType.TransferForeignMoney;
            }
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                cbExpressAgentOutBar.Checked = (AppliableFunctionType.AgentExpressOut & item.ServiceListBar) == AppliableFunctionType.AgentExpressOut;
                cbTransferOverCountyBar.Checked = (AppliableFunctionType.TransferOverCountry & item.ServiceListBar) == AppliableFunctionType.TransferOverCountry;
                cbTransferForeignMoneyBar.Checked = (AppliableFunctionType.TransferForeignMoney & item.ServiceListBar) == AppliableFunctionType.TransferForeignMoney;
            }
        }

        private void ClearItem()
        {
            this.edtPayerAccount.Text = string.Empty;
            this.edtPayerName.Text = string.Empty;
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                cbTransferEnt.Checked = cbTransferEnt.Enabled;
                cbTransferInd.Checked = cbTransferInd.Enabled;
                cbExpressAgentOut.Checked = cbExpressAgentOut.Enabled;
                cbExpressAgentIn.Checked = cbExpressAgentIn.Enabled;
                cbNormalAgentOut.Checked = cbNormalAgentOut.Enabled;
                cbNormalAgentIn.Checked = cbNormalAgentIn.Enabled;
                cbOverBankIn.Checked = cbOverBankIn.Enabled;
                cbOverBankOut.Checked = cbOverBankOut.Enabled;
                cbElecTicketRemit.Checked = cbElecTicketRemit.Enabled;
                cbElecTicketPayMoney.Checked = cbElecTicketPayMoney.Enabled;
                cbTransferOverCounty.Checked = cbTransferOverCounty.Enabled;
                cbTransferForeignMoney.Checked = cbTransferForeignMoney.Enabled;
            }
            else
            {
                cbExpressAgentOutBar.Checked = cbExpressAgentOutBar.Enabled;
                cbTransferForeignMoneyBar.Checked = cbTransferForeignMoneyBar.Enabled;
                cbTransferOverCountyBar.Checked = cbTransferOverCountyBar.Enabled;
            }
        }

        int GetRowIndex()
        {
            int index = int.MaxValue;
            try
            {
                index = int.Parse(tbRowIndex.Text.Trim());
            }
            catch { }
            return index;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckData(false))
            {
                CommandCenter.Instance.ResolvePayer(OperatorCommandType.Submit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
                m_payer = null;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearItem();
        }

        private bool CheckData(bool flag)
        {
            ResultData rd = new ResultData();
            if (flag)
            {
                rd = DataCheckCenter.Instance.CheckRowIndex(tbRowIndex, tbRowIndex.Text, lbrowindex.Text.Substring(0, lbrowindex.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;//{ MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information); return rd.Result; }
            }
            rd = DataCheckCenter.Instance.CheckPayerAccount(edtPayerAccount, edtPayerAccount.Text, label18.Text.Substring(0, label18.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(edtPayerName.Text.Trim()))
            {
                rd = DataCheckCenter.Instance.CheckPayerName(edtPayerName, edtPayerName.Text, label17.Text.Substring(0, label17.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (cmbCashType.SelectedIndex < 0) { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_PayerMsg_Payer_Select_CashType, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (GetServices(false) == AppliableFunctionType._Empty)
            {
                if (((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar && GetServices(true) == AppliableFunctionType._Empty) || (SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
                {
                    MessageBoxExHelper.Instance.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, label19.Text.Substring(0, label19.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckData(true))
            {
                CommandCenter.Instance.ResolvePayer(OperatorCommandType.Edit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
                m_payer = null;
            }
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isbar = (SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar;
            if (!isbar)
            {
                foreach (var item in pServiceNet.Controls)
                {
                    if (item is CheckBox)
                    {
                        (item as CheckBox).Checked = chbSelectAll.Checked && (item as CheckBox).Enabled && (item as CheckBox).Visible;
                    }
                }
            }
            else
            {
                foreach (var item in pServiceBar.Controls)
                {
                    if (item is CheckBox)
                    {
                        (item as CheckBox).Checked = chbSelectAll.Checked && (item as CheckBox).Enabled && (item as CheckBox).Visible;
                    }
                }
            }
        }
    }
}
