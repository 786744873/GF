using System;
using System.ComponentModel;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class ElecTicketOtherPanel : BaseUc
    {
        public ElecTicketOtherPanel()
        {
            InitializeComponent();
            CommandCenter.OnElecTicketRemitEvenHnadler += new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler);
            CommandCenter.OnElecTicketBackNoteEventHandler += new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler);
            CommandCenter.OnElecTicketAutoTipExchangeEventHandler += new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler);
            CommandCenter.OnElecTicketPayMoneyEventHandler += new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketOtherPanel), this);
            }
        }

        void CommandCenter_OnElecTicketPayMoneyEventHandler(object sender, ElecTicketPayMoneyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler), sender, e); }
            else
            {
                if (m_appType != e.OwnerType) return;
                if (OperatorCommandType.View == e.Command)
                { SetItem(e.ElecTicketPayMoney); }
                else if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
            }
        }

        void CommandCenter_OnElecTicketAutoTipExchangeEventHandler(object sender, ElecTicketAutoTipExchangeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler), sender, e); }
            else
            {
                if (m_appType != e.OwnerType) return;
                if (OperatorCommandType.View == e.Command)
                { SetItem(e.ElecTicketAutoTipExchange); }
                else if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
            }
        }

        void CommandCenter_OnElecTicketBackNoteEventHandler(object sender, ElecTicketBackNoteEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler), sender, e); }
            else
            {
                if (m_appType != e.OwnerType) return;
                if (OperatorCommandType.View == e.Command)
                { SetItem(e.ElecTicketBackNote); }
                else if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
            }
        }

        void CommandCenter_OnElecTicketRemitEvenHnadler(object sender, ElecTicketRemitEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler), sender, e); }
            else
            {
                if (m_appType != e.OwnerType) return;
                if (OperatorCommandType.View == e.Command)
                { SetItem(e.ElecTicketRemit); }
                else if (OperatorCommandType.Reset == e.Command)
                { SetItem(null); }
            }
        }

        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set
            {
                m_appType = value;
                Init();
            }
        }

        private ElecTicketRemit m_Remit;
        /// <summary>
        /// 出票信息
        /// </summary>
        [Browsable(false)]
        public ElecTicketRemit Remit
        {
            get { return m_Remit; }
            set { m_Remit = value; }
        }

        private ElecTicketBackNote m_BackNote;
        /// <summary>
        /// 背书信息
        /// </summary>
        [Browsable(false)]
        public ElecTicketBackNote BackNote
        {
            get { return m_BackNote; }
            set { m_BackNote = value; }
        }

        private ElecTicketPayMoney m_PayMoney;
        /// <summary>
        /// 贴现信息
        /// </summary>
        [Browsable(false)]
        public ElecTicketPayMoney PayMoney
        {
            get { return m_PayMoney; }
            set { m_PayMoney = value; }
        }

        private ElecTicketAutoTipExchange m_TipExchange;
        /// <summary>
        /// 自动提示承兑信息
        /// </summary>
        [Browsable(false)]
        public ElecTicketAutoTipExchange TipExchange
        {
            get { return m_TipExchange; }
            set { m_TipExchange = value; }
        }

        void Init()
        {
            if (m_appType == AppliableFunctionType.ElecTicketRemit)
            {
                pSelection.Visible = true;
                pCode.Visible = false;
            }
            else if (m_appType == AppliableFunctionType.ElecTicketBackNote)
            {
                pSelection.Visible = false;
                pCode.Visible = false;
            }
            else if (m_appType == AppliableFunctionType.ElecTicketPayMoney)
            {
                pSelection.Visible = false;
                pCode.Visible = true;
            }
            else if (m_appType == AppliableFunctionType.ElecTicketTipExchange)
            {
                pSelection.Visible = false;
                pCode.Visible = true;
            }
            SetRegex();
        }

        private void SetRegex()
        {
            if (m_appType == AppliableFunctionType.ElecTicketPayMoney
       || m_appType == AppliableFunctionType.ElecTicketTipExchange)
            {

                tbBillSerialNo.DvRegCode = "reg57";
                tbBillSerialNo.DvMinLength = 0;
                tbBillSerialNo.DvMaxLength = 60;

                tbContractNo.DvRegCode = "reg57";
                tbContractNo.DvMinLength = 0;
                tbContractNo.DvMaxLength = 60;

            }

            tbNote.DvRegCode = "reg667";
            tbNote.DvMinLength = 0;
            tbNote.DvMaxLength = 512;


        }
        public void GetItem()
        {
            if (CheckData())
            {
                if (m_appType == AppliableFunctionType.ElecTicketRemit)
                {
                    m_Remit = new ElecTicketRemit();
                    m_Remit.CanChange = rbCanChangeYes.Checked ? CanChangeType.EM00 : CanChangeType.EM01;
                    m_Remit.AutoTipExchange = rbTipExchangeYes.Checked;
                    m_Remit.AutoTipReceiveTicket = rbTipReceiveTicketYes.Checked;
                    m_Remit.Note = tbNote.Text.Trim();
                }
                else if (m_appType == AppliableFunctionType.ElecTicketBackNote)
                {
                    m_BackNote = new ElecTicketBackNote();
                    m_BackNote.Note = tbNote.Text.Trim();
                }
                else if (m_appType == AppliableFunctionType.ElecTicketPayMoney)
                {
                    m_PayMoney = new ElecTicketPayMoney();
                    m_PayMoney.BillSerialNo = tbBillSerialNo.Text.Trim();
                    m_PayMoney.ContractNo = tbContractNo.Text.Trim();
                    m_PayMoney.Note = tbNote.Text.Trim();
                }
                else if (m_appType == AppliableFunctionType.ElecTicketTipExchange)
                {
                    m_TipExchange = new ElecTicketAutoTipExchange();
                    m_TipExchange.BillSerialNo = tbBillSerialNo.Text.Trim();
                    m_TipExchange.ContractNo = tbContractNo.Text.Trim();
                    m_TipExchange.Note = tbNote.Text.Trim();
                }
            }
        }

        private void SetItem(object obj)
        {
            if (obj == null)
            {
                rbCanChangeYes.Checked =
                rbTipExchangNo.Checked =
                rbTipReceiveTicketNo.Checked = true;
                tbBillSerialNo.Text =
                tbContractNo.Text =
                tbNote.Text = string.Empty;
            }
            else if (obj is ElecTicketRemit)
            {
                rbCanChangeYes.Checked = (obj as ElecTicketRemit).CanChange == CanChangeType.EM00;
                rbCanChangeNo.Checked = !rbCanChangeYes.Checked;
                rbTipExchangeYes.Checked = (obj as ElecTicketRemit).AutoTipExchange;
                rbTipExchangNo.Checked = !rbTipExchangeYes.Checked;
                rbTipReceiveTicketYes.Checked = (obj as ElecTicketRemit).AutoTipReceiveTicket;
                rbTipReceiveTicketNo.Checked = !rbTipReceiveTicketYes.Checked;
                tbNote.Text = (obj as ElecTicketRemit).Note;
            }
            else if (obj is ElecTicketBackNote)
            {
                tbNote.Text = (obj as ElecTicketBackNote).Note;
            }
            else if (obj is ElecTicketPayMoney)
            {
                tbBillSerialNo.Text = (obj as ElecTicketPayMoney).BillSerialNo;
                tbContractNo.Text = (obj as ElecTicketPayMoney).ContractNo;
                tbNote.Text = (obj as ElecTicketPayMoney).Note;
            }
            else if (obj is ElecTicketAutoTipExchange)
            {
                tbBillSerialNo.Text = (obj as ElecTicketAutoTipExchange).BillSerialNo;
                tbContractNo.Text = (obj as ElecTicketAutoTipExchange).ContractNo;
                tbNote.Text = (obj as ElecTicketAutoTipExchange).Note;
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (m_appType == AppliableFunctionType.ElecTicketPayMoney
            //    || m_appType == AppliableFunctionType.ElecTicketTipExchange)
            //{
            //    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckBillSerialNo(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 60, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //    if (!string.IsNullOrEmpty(tbContractNo.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckContractNo(tbContractNo, tbContractNo.Text.Trim(), lbContractNo.Text.Substring(0, lbContractNo.Text.Length - 1), 60, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            //if (!string.IsNullOrEmpty(tbNote.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckAddtion(tbNote, tbNote.Text.Trim(), lbNote.Text.Substring(0, lbNote.Text.Length - 1), 512, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            return rd.Result;
        }
    }
}
