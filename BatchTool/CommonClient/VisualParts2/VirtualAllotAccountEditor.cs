using System;
using System.Collections.Generic;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.Utilities;
using CommonClient.EnumTypes;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class VirtualAllotAccountEditor : BaseUc
    {
        public VirtualAllotAccountEditor()
        {
            InitializeComponent();
            CommandCenter.OnVirtualAccountAllotEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            InitData();
            SetRegex();
        }
        private void SetRegex()
        {
            edtAccount.DvRegCode = "reg766";
            edtAccount.DvMinLength = 1;
            edtAccount.DvMaxLength = 35;
            edtAccount.DvRequired = true;
            edtName.DvRegCode = "reg585";
            edtName.DvMinLength = 1;
            edtName.DvMaxLength = 120;
            edtName.DvRequired = true;
        }
        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(VirtualAllotAccountEditor), this);
            }
        }

        void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, VirtualAccountAllotEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler), sender, e); }
            else
            {
                this.errorProvider1.Clear();
                if (e.Command == EnumTypes.OperatorCommandType.View)
                {
                    tbRowIndex.Text = e.RowIndex.ToString();
                    edtAccount.Text = e.VirtualAllotAccount.Account;
                    edtName.Text = e.VirtualAllotAccount.Name;
                    tbOpenBankName.Text = e.VirtualAllotAccount.OpenBankName;
                    cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == e.VirtualAllotAccount.CashType);
                }
                else if (e.Command == EnumTypes.OperatorCommandType.Delete
                    || e.Command == EnumTypes.OperatorCommandType.Reset)
                {
                    edtAccount.Text =
                    edtName.Text = string.Empty;
                }
            }
        }
        public void InitData()
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
        bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = this.CheckValid();
            //rd = DataCheckCenter.CheckElecTicketPersonAccountFC(edtAccount, edtAccount.Text.Trim(), lblAccount.Text.Substring(0, lblAccount.Text.Length - 1), 35, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            //rd = DataCheckCenter.CheckVirtualAccountName(edtName, edtName.Text.Trim(), lblName.Text.Substring(0, lblName.Text.Length - 1), 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            return rd.Result;
        }

        private int GetRowIndex()
        {
            int index = 0;
            try
            {
                if (string.IsNullOrEmpty(tbRowIndex.Text)) index = int.MaxValue;
                index = int.Parse(tbRowIndex.Text.Trim());
                if (index < 0) index = int.MaxValue;
            }
            catch { index = int.MaxValue; }
            return index;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid()&&CheckData())
                CommandCenter.ResolveVirtualAllotAccount(EnumTypes.OperatorCommandType.Submit, new VirtualAccountInfo { Account = edtAccount.Text.Trim(), Name = edtName.Text.Trim(), CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex], OpenBankName = tbOpenBankName.Text.Trim() }, EnumTypes.AppliableFunctionType._Empty, GetRowIndex());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid()&&CheckData())
                CommandCenter.ResolveVirtualAllotAccount(EnumTypes.OperatorCommandType.Edit, new VirtualAccountInfo { Account = edtAccount.Text.Trim(), Name = edtName.Text.Trim(), CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex], OpenBankName = tbOpenBankName.Text.Trim() }, EnumTypes.AppliableFunctionType._Empty, GetRowIndex());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            tbOpenBankName.Text =
            edtAccount.Text =
            edtName.Text = string.Empty;
            this.errorProvider1.Clear();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
    }
}
