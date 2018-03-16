using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using CommonClient.VisualParts;
using System.Drawing;

namespace CommonClient.VisualParts2
{
    public partial class PayerEditor : BaseUc
    {
        private PayerInfo m_payer = null;

        public PayerEditor()
        {
            InitializeComponent();
            CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);

            InitData();
            cmbCashType.SelectedIndexChanged += new EventHandler(cmbCashType_SelectedIndexChanged);
            SetRegex();
        }
        private void SetRegex()
        {
            tbRowIndex.DvRegCode = "reg58";
            tbRowIndex.DvMinLength = 1;
            tbRowIndex.DvMaxLength = 9;
            edtPayerAccount.DvRegCode = "reg666";
            edtPayerAccount.DvMinLength = 1;
            edtPayerAccount.DvMaxLength = 35;
            edtPayerAccount.DvRequired = true;
            edtPayerName.DvRegCode = "Predefined5";
            edtPayerName.DvMinLength = 1;
            edtPayerName.DvMaxLength = 76;
        }
        void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.AppVisiableResolve)
                {
                    ChangeUI();
                }
            }
        }

        void cmbCashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCashType.SelectedIndex < 0) return;
            if (cmbCashType.Tag == null) return;
            if ((cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex] == CashType.CNY)
            {
                cbTransferInd.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv;
                cbTransferEnt.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
                cbExpressAgentIn.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn;
                cbExpressAgentOut.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                cbNormalAgentIn.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn;
                cbNormalAgentOut.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut;
                cbOverBankIn.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn;
                cbOverBankOut.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut;
                cbElecTicketRemit.Enabled = ((SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit || (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange);
                cbElecTicketPayMoney.Enabled = ((SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney || (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote);
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                {
                    cbExpressAgentOutBar.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
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
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                {
                    cbExpressAgentOutBar.Enabled = cbExpressAgentOutBar.Checked = false;
                }
            }
        }

        private void ChangeUI()
        {
            cbTransferInd.Checked = cbTransferInd.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv;
            cbTransferEnt.Checked = cbTransferEnt.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
            cbExpressAgentIn.Checked = cbExpressAgentIn.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn;
            cbExpressAgentOut.Checked = cbExpressAgentOut.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
            cbNormalAgentIn.Checked = cbNormalAgentIn.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn;
            cbNormalAgentOut.Checked = cbNormalAgentOut.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut;
            cbOverBankIn.Checked = cbOverBankIn.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn;
            cbOverBankOut.Checked = cbOverBankOut.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut;
            cbElecTicketRemit.Checked = cbElecTicketRemit.Enabled = ((SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit || (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange);
            cbElecTicketPayMoney.Checked = cbElecTicketPayMoney.Enabled = ((SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney || (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote);
            cbTransferOverCountry.Checked = cbTransferOverCountry.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
            cbTransferForeignMoney.Checked = cbTransferForeignMoney.Enabled = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;

            #region 501排版
            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
            {
                pServiceNet.Dock = DockStyle.Fill;
                pServiceNet.AutoScroll = true;
                cbTransferInd.Visible =
                cbTransferEnt.Visible =
                cbExpressAgentIn.Visible =
                cbExpressAgentOut.Visible =
                cbNormalAgentIn.Visible =
                cbNormalAgentOut.Visible =
                cbOverBankIn.Visible =
                cbOverBankOut.Visible =
                cbElecTicketRemit.Visible =
                cbElecTicketPayMoney.Visible =
                cbTransferOverCountry.Visible =
                cbTransferForeignMoney.Visible = false;

                Point currentLocation = new Point(10, 18);
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp)
                { cbTransferEnt.Visible = true; cbTransferEnt.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv)
                { cbTransferInd.Visible = true; cbTransferInd.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut)
                { cbOverBankOut.Visible = true; cbOverBankOut.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn)
                { cbOverBankIn.Visible = true; cbOverBankIn.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut)
                { cbExpressAgentOut.Visible = true; cbExpressAgentOut.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn)
                { cbExpressAgentIn.Visible = true; cbExpressAgentIn.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut)
                { cbNormalAgentOut.Visible = true; cbNormalAgentOut.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn)
                { cbNormalAgentIn.Visible = true; cbNormalAgentIn.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry)
                { cbTransferOverCountry.Visible = true; cbTransferOverCountry.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if ((SystemSettings.AppliableTypes & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney)
                { cbTransferForeignMoney.Visible = true; cbTransferForeignMoney.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if (((SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit || (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange))
                { cbElecTicketRemit.Visible = true; cbElecTicketRemit.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
                if (((SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney || (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote))
                { cbElecTicketPayMoney.Visible = true; cbElecTicketPayMoney.Location = currentLocation; currentLocation = new Point { X = currentLocation.X, Y = currentLocation.Y + 22 }; }
            }
            #endregion

            #region 403bar
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                cbExpressAgentOutBar.Checked = cbExpressAgentOutBar.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
                cbTransferOverCountyBar.Checked = cbTransferOverCountyBar.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
                cbTransferForeignMoneyBar.Checked = cbTransferForeignMoneyBar.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;
            }
            #endregion

            if (!cbTransferOverCountry.Checked) cbTransferOverCountry.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
            if (!cbTransferEnt.Checked) cbTransferEnt.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
            if (!cbExpressAgentOut.Checked) cbExpressAgentOut.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
            if (!cbTransferForeignMoney.Checked) cbTransferForeignMoney.Enabled = (SystemSettings.AppliableTypes4Bar & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;
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

            cbTransferForeignMoney.Visible = cbTransferOverCountry.Visible = cbElecTicketRemit.Visible = cbElecTicketPayMoney.Visible = (SystemSettings.CurrentVersion & VersionType.v402) == VersionType.v402;
            cbExpressAgentOutBar.Visible = cbTransferForeignMoneyBar.Visible = cbTransferOverCountyBar.Visible = (SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar;

            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                pServiceNet.Visible = false;
                pServiceBar.Visible = true;
            }

            ChangeUI();
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

            if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
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
                functionTypes = cbTransferOverCountry.Checked ? functionTypes | AppliableFunctionType.TransferOverCountry : functionTypes;
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

            if ((SystemSettings.CurrentVersion & VersionType.v307) == VersionType.v307)
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
            if ((SystemSettings.CurrentVersion & VersionType.v402) == VersionType.v402)
            {
                cbElecTicketRemit.Checked = (AppliableFunctionType.ElecTicketRemit & item.ServiceList) == AppliableFunctionType.ElecTicketRemit || (AppliableFunctionType.ElecTicketTipExchange & item.ServiceList) == AppliableFunctionType.ElecTicketTipExchange;
                cbElecTicketPayMoney.Checked = (AppliableFunctionType.ElecTicketPayMoney & item.ServiceList) == AppliableFunctionType.ElecTicketPayMoney || (AppliableFunctionType.ElecTicketBackNote & item.ServiceList) == AppliableFunctionType.ElecTicketBackNote;
                cbTransferOverCountry.Checked = (AppliableFunctionType.TransferOverCountry & item.ServiceList) == AppliableFunctionType.TransferOverCountry;
                cbTransferForeignMoney.Checked = (AppliableFunctionType.TransferForeignMoney & item.ServiceList) == AppliableFunctionType.TransferForeignMoney;
            }
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
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
            if (cmbCashType.Items.Count > 0) cmbCashType.SelectedIndex = 0;
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
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
                cbTransferOverCountry.Checked = cbTransferOverCountry.Enabled;
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
            if (base.CheckValid() && CheckData(false))
            {
                CommandCenter.ResolvePayer(OperatorCommandType.Submit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
                m_payer = null;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearItem();
            this.errorProvider1.Clear();
        }

        private bool CheckData(bool flag)
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (flag)
            //{
            //    rd = DataCheckCenter.CheckRowIndex(tbRowIndex, tbRowIndex.Text, lbrowindex.Text.Substring(0, lbrowindex.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;//{ MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information); return rd.Result; }
            //}
            //rd = DataCheckCenter.CheckPayerAccount(edtPayerAccount, edtPayerAccount.Text, label18.Text.Substring(0, label18.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (!string.IsNullOrEmpty(edtPayerName.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckPayerName(edtPayerName, edtPayerName.Text, label17.Text.Substring(0, label17.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (cmbCashType.SelectedIndex < 0) { MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_PayerMsg_Payer_Select_CashType, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            if (((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar && GetServices(true) == AppliableFunctionType._Empty) || ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar && GetServices(false) == AppliableFunctionType._Empty))
            {
                MessageBoxPrime.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, label19.Text.Substring(0, label19.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                rd.Result = false;
            }
            return rd.Result;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData(true))
            {
                CommandCenter.ResolvePayer(OperatorCommandType.Edit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
                m_payer = null;
            }
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isbar = (SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar;
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
