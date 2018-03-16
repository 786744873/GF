﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class ElecTicketPoolEditor : BaseUc
    {
        public ElecTicketPoolEditor()
        {
            InitializeComponent();
            dtpRemitDate.MinDate =
            dtpExchangeDate.MinDate = DateTime.Today.AddMonths(-6);
            dtpRemitDate.MaxDate =
            dtpExchangeDate.MaxDate = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today.AddDays(1);
            dtpEndDate.MaxDate = DateTime.Today.AddMonths(6);
            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
        }

        void CommandCenter_OnElecTicketPoolEventHandler(object sender, ElecTicketPoolEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != AppliableFunctionType.ElecTicketPool) return;
                if (e.Command == OperatorCommandType.View)
                {
                    SetItem(e.ElecTicketPool);
                }
                else if (e.Command == OperatorCommandType.Reset)
                {
                    SetItem(null);
                }
                this.errorProvider1.Clear();
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketPoolEditor), this);
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 18, false, this.errorProvider1);
                if (!rd.Result) return;
                string data = tbAmount.Text.Trim().Replace(",", "");
                tbAmount.Text = DataConvertHelper.FormatCash(data, false, false);
            }
        }

        private ElecTicketType m_ElecTicketType = ElecTicketType.Empty;
        /// <summary>
        /// 所属功能模块
        /// ElecTicketPoolBank-票据池(银承)，ElecTicketPoolBusiness-票据池(商承)
        /// </summary>
        [Browsable(true)]
        public ElecTicketType ElecTicketType
        {
            get { return m_ElecTicketType; }
            set
            {
                m_ElecTicketType = value;
                Init();
            }
        }
        private ElecTicketPool m_elecTicketPool;
        /// <summary>
        /// 票据池信息
        /// </summary>
        public ElecTicketPool ElecTicketPool
        {
            get
            {
                return m_elecTicketPool;
            }
        }

        void Init()
        {
            pBankExchange.Visible =
            lbExchangeBank.Visible =
            rbBOCBank.Visible =
            rbOtherBank.Visible = m_ElecTicketType == ElecTicketType.AC01;
            SetRegex();
        }
        private void SetRegex()
        {

            tbCustomerRef.DvRegCode = "reg718";
            tbCustomerRef.DvMinLength = 0;
            tbCustomerRef.DvMaxLength = 14;
            tbCustomerRef.DvRequired = false;
            tbElecTicketSerialNo.DvRegCode = "reg57";
            tbElecTicketSerialNo.DvMinLength = 1;
            tbElecTicketSerialNo.DvMaxLength = 30;
            tbElecTicketSerialNo.DvRequired = true;
            //金额校验
            //tbAmount.DvRegCode = "reg43";
            //tbAmount.DvMinLength = 1;
            //tbAmount.DvMaxLength = 18;
            //rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 18, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (dtpRemitDate.Value.Date > dtpExchangeDate.Value.Date)
            //{ MessageBoxPrime.Show(MultiLanguageConvertHelper.ElecTicketPool_RemitDate_Must_be_Early_ExchangeDate, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return ; }
            //if (dtpEndDate.Value.Date > dtpRemitDate.Value.Date.AddMonths(6).Date)
            //{ MessageBoxPrime.Show(MultiLanguageConvertHelper.ElecTicketPool_RemitDate_Must_Not_be_Early_EndDate_Harf_Year, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }

        }
        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (!string.IsNullOrEmpty(tbCustomerRef.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckCustomerRefNo(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //rd = DataCheckCenter.CheckElecTicketSerialNo(tbElecTicketSerialNo, tbElecTicketSerialNo.Text.Trim(), lbElecTicketSerialNo.Text.Substring(0, lbElecTicketSerialNo.Text.Length - 1), 30, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 18, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            if (dtpRemitDate.Value.Date > dtpExchangeDate.Value.Date)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.ElecTicketPool_RemitDate_Must_be_Early_ExchangeDate, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
            if (dtpEndDate.Value.Date > dtpRemitDate.Value.Date.AddMonths(6).Date)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.ElecTicketPool_RemitDate_Must_Not_be_Early_EndDate_Harf_Year, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
            rd.Result = rd.Result & DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 18, false, this.errorProvider1).Result;
            return rd.Result;
        }

        public void GetItem()
        {
            m_elecTicketPool = new ElecTicketPool();
            m_elecTicketPool.ElecTicketSerialNo = tbElecTicketSerialNo.Text.Trim();
            m_elecTicketPool.ElecTicketType = m_ElecTicketType;
            m_elecTicketPool.CustomerRef = tbCustomerRef.Text.Trim();
            m_elecTicketPool.ElecTicketSerialNo = tbElecTicketSerialNo.Text.Trim();
            m_elecTicketPool.RemitDate = dtpRemitDate.Text;
            m_elecTicketPool.ExchangeDate = dtpExchangeDate.Text;
            m_elecTicketPool.EndDate = dtpEndDate.Text;
            if (m_ElecTicketType == ElecTicketType.AC01)
                m_elecTicketPool.BankType = rbBOCBank.Checked ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount;
            else if (m_ElecTicketType == ElecTicketType.AC02)
                m_elecTicketPool.BankType = AccountBankType.Empty;
            m_elecTicketPool.Amount = tbAmount.Text.Trim().Replace(",", "");
        }

        void SetItem(ElecTicketPool item)
        {
            if (null == item)
            {
                tbCustomerRef.Text = string.Empty;
                tbElecTicketSerialNo.Text = string.Empty;
                tbAmount.Text = string.Empty;
                dtpRemitDate.Value = DateTime.Today;
                dtpExchangeDate.Value = dtpRemitDate.Value;
                dtpEndDate.Value = dtpEndDate.MinDate;
                if (m_ElecTicketType == ElecTicketType.AC01)
                {
                    rbBOCBank.Checked = true;
                    rbOtherBank.Checked = !rbBOCBank.Checked;
                }
                this.errorProvider1.Clear();
            }
            else
            {
                tbCustomerRef.Text = item.CustomerRef;
                tbElecTicketSerialNo.Text = item.ElecTicketSerialNo;
                tbAmount.Text = item.Amount;
                try
                {
                    dtpRemitDate.Value = DateTime.Parse(item.RemitDate);
                }
                catch { dtpRemitDate.Value = dtpRemitDate.MinDate; }
                try
                {
                    dtpExchangeDate.Value = DateTime.Parse(item.ExchangeDate);
                }
                catch { dtpExchangeDate.Value = dtpExchangeDate.MinDate; }
                try
                {
                    dtpEndDate.Value = DateTime.Parse(item.EndDate);
                }
                catch { dtpEndDate.Value = dtpEndDate.MinDate; }
                if (m_ElecTicketType == ElecTicketType.AC01)
                {
                    rbBOCBank.Checked = item.BankType == AccountBankType.BocAccount;
                    rbOtherBank.Checked = !rbBOCBank.Checked;
                }
            }
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbAmount.Text.Trim(), 18);
        }
    }
}