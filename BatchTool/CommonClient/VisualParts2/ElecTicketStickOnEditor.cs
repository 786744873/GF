using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class ElecTicketStickOnEditor : BaseUc
    {
        public ElecTicketStickOnEditor()
        {
            InitializeComponent();
            CommandCenter.OnElecTicketPayMoneyEventHandler += new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnStickOnBankInfoEventHandler += new EventHandler<StickOnBankInfoEventArgs>(CommandCenter_OnStickOnBankInfoEventHandler);

            dtpPayMoney.MinDate = DateTime.Today;
            dtpPayMoney.MaxDate = DateTime.Today.AddMonths(1);

            tbMoneyPercent.LostFocus += new EventHandler(tbMoneyPercent_LostFocus);
            tbProtocolPercent.LostFocus += new EventHandler(tbProtocolPercent_LostFocus);
            tbPayMoneyOpenBankNo.LostFocus += new EventHandler(tbPayMoneyOpenBankNo_LostFocus);
            SetRegex();
        }
        private void SetRegex()
        {
            if (rbIsContainYes.Checked)
            {
                //利率校验
                //tbProtocolPercent.DvRegCode = "reg724";
                //tbProtocolPercent.DvMinLength = 1;
                //tbProtocolPercent.DvMaxLength=5;
                //rd = DataCheckCenter.CheckProtocolPercent(tbProtocolPercent, tbProtocolPercent.Text.Trim(), lbProtocolPercent.Text.Substring(0, lbProtocolPercent.Text.Length - 1), this.errorProvider1);
                //if (!rd.Result) return rd.Result;
            }
            //利率校验
            //tbMoneyPercent.DvRegCode = "reg724";
            //tbMoneyPercent.DvMinLength = 1;
            //tbMoneyPercent.DvMaxLength=4;
            //rd = DataCheckCenter.CheckPayMoneyPercent(tbMoneyPercent, tbMoneyPercent.Text.Trim(), lbPercent.Text.Substring(0, lbPercent.Text.Length - 1), true, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            tbPayMoneyAccount.DvRegCode = "reg629";
            tbPayMoneyAccount.DvMinLength = 1;
            tbPayMoneyAccount.DvMaxLength = 32;
            tbPayMoneyAccount.DvRequired = true;
            tbPayMoneyOpenBankName.DvRegCode = "reg667";
            tbPayMoneyOpenBankName.DvMinLength = 1;
            tbPayMoneyOpenBankName.DvMaxLength = 120;
            tbPayMoneyOpenBankName.DvRequired = true;
            tbPayMoneyOpenBankNo.DvRegCode = "reg57";
            tbPayMoneyOpenBankNo.DvMinLength = 12;
            tbPayMoneyOpenBankNo.DvMaxLength = 12;
            tbPayMoneyOpenBankNo.DvRequired = true;

        }
        void CommandCenter_OnStickOnBankInfoEventHandler(object sender, StickOnBankInfoEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<StickOnBankInfoEventArgs>(CommandCenter_OnStickOnBankInfoEventHandler), sender, e); }
            else
            {
                m_bankInfo = new List<string>();
                m_bankInfo.Add(e.BankName);
                m_bankInfo.Add(e.BankNo);

                if (e.BankNo.StartsWith("104"))
                {
                    if (!tbPayMoneyOpenBankNo.Text.Trim().StartsWith("104"))
                    {
                        tbPayMoneyOpenBankName.Text = e.BankName;
                        tbPayMoneyOpenBankNo.Text = e.BankNo;
                    }

                    //tbPayMoneyOpenBankName.ReadOnly =
                    //tbPayMoneyOpenBankNo.ReadOnly = true;
                    //btnQueryBank.Enabled = false;
                    rbClearTypeUnder.Checked = true;
                    rbClearTypeOn.Checked = !rbClearTypeUnder.Checked;
                    rbClearTypeOn.Enabled = false;
                }
                else
                {
                    //tbPayMoneyOpenBankName.ReadOnly =
                    //tbPayMoneyOpenBankNo.ReadOnly = false;
                    //btnQueryBank.Enabled = true;
                    rbClearTypeOn.Enabled = true;
                }
            }
        }

        void tbPayMoneyOpenBankNo_LostFocus(object sender, EventArgs e)
        {
            ChangeClearType();
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketStickOnEditor), this);

                tbPayMoneyType.Text = MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_Buyout;
            }
        }

        void tbProtocolPercent_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbProtocolPercent.Text))
            {
                string str = DataConvertHelper.FormatProtocolPercent(tbProtocolPercent.Text.Trim());
                tbProtocolPercent.Text = string.IsNullOrEmpty(str) ? "0" : str;
            }
        }

        void tbMoneyPercent_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMoneyPercent.Text))
            {
                string str = DataConvertHelper.FormatPayMoneyPercent(tbMoneyPercent.Text.Trim(), true);
                tbMoneyPercent.Text = string.IsNullOrEmpty(str.Trim()) ? "0" : str;
            }
        }

        void CommandCenter_OnElecTicketPayMoneyEventHandler(object sender, ElecTicketPayMoneyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != EnumTypes.AppliableFunctionType.ElecTicketPayMoney) return;
                if (e.Command == EnumTypes.OperatorCommandType.View)
                { SetItem(e.ElecTicketPayMoney); }
                else if (e.Command == EnumTypes.OperatorCommandType.Reset)
                { SetItem(null); }
            }
        }

        private ElecTicketPayMoney m_PayMoney;
        /// <summary>
        /// 贴现信息
        /// </summary>
        public ElecTicketPayMoney PayMoney
        {
            get { return m_PayMoney; }
            protected set { m_PayMoney = value; }
        }
        List<string> m_bankInfo = new List<string>();

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (rbIsContainYes.Checked)
            //{
            //    rd = DataCheckCenter.CheckProtocolPercent(tbProtocolPercent, tbProtocolPercent.Text.Trim(), lbProtocolPercent.Text.Substring(0, lbProtocolPercent.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            // rd = DataCheckCenter.CheckPayMoneyPercent(tbMoneyPercent, tbMoneyPercent.Text.Trim(), lbPercent.Text.Substring(0, lbPercent.Text.Length - 1), true, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckElecTicketPersonAccount(tbPayMoneyAccount, tbPayMoneyAccount.Text.Trim(), lbAccount.Text.Substring(0, lbAccount.Text.Length - 1), 32, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckOpenBankName(tbPayMoneyOpenBankName, tbPayMoneyOpenBankName.Text.Trim(), lbOpenBankName.Text.Substring(0, lbOpenBankName.Text.Length - 1), 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCNAPSNo(tbPayMoneyOpenBankNo, tbPayMoneyOpenBankNo.Text.Trim(), lbOpenBankNo.Text.Substring(0, lbOpenBankNo.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            return rd.Result;
        }

        public void GetItem()
        {
            if (CheckData())
            {
                m_PayMoney = new ElecTicketPayMoney();
                m_PayMoney.PayMoneyType = tbPayMoneyType.Text.Trim();
                m_PayMoney.ClearType = rbClearTypeOn.Checked ? ClearMoneyType.SM00 : ClearMoneyType.SM01;
                DateTime dt = dtpPayMoney.Value.Date;
                m_PayMoney.PayMoneyDate = dt.Year.ToString().PadLeft(4, '0') + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Day.ToString().PadLeft(2, '0');
                m_PayMoney.PayMoneyPercent = double.Parse(tbMoneyPercent.Text.Trim()) / 100;
                m_PayMoney.PayMoneyAccount = tbPayMoneyAccount.Text.Trim();
                m_PayMoney.PayMoneyOpenBankName = tbPayMoneyOpenBankName.Text.Trim();
                m_PayMoney.PayMoneyOpenBankNo = tbPayMoneyOpenBankNo.Text.Trim();
                m_PayMoney.ProtocolMoneyType = rbIsContainNo.Checked ? ProtocolMoneyType.ByDiscountApplicant : ProtocolMoneyType.NegotiatedInterestPayment;
                m_PayMoney.ProtocolMoneyPercent = double.Parse(tbProtocolPercent.Text.Trim());
            }
        }

        public void SetItem(ElecTicketPayMoney etpm)
        {
            if (null == etpm)
            {
                rbClearTypeOn.Checked = false;
                rbClearTypeUnder.Checked = !rbClearTypeOn.Checked;
                rbClearTypeOn.Enabled = true;
                dtpPayMoney.Value = DateTime.Today;
                tbMoneyPercent.Text = string.Empty;
                tbPayMoneyAccount.Text = string.Empty;
                tbPayMoneyOpenBankName.Text = string.Empty;
                tbPayMoneyOpenBankNo.Text = string.Empty;
                rbIsContainNo.Checked = true;
                tbPayMoneyOpenBankName.ReadOnly =
                tbPayMoneyOpenBankNo.ReadOnly = false;
                btnQueryBank.Enabled = true;
                this.errorProvider1.Clear();
            }
            else
            {
                rbClearTypeOn.Checked = etpm.ClearType == EnumTypes.ClearMoneyType.SM00;
                rbClearTypeUnder.Checked = !rbClearTypeOn.Checked;
                try
                {
                    dtpPayMoney.Value = DateTime.Parse(etpm.PayMoneyDate);
                }
                catch { }
                tbMoneyPercent.Text = (etpm.PayMoneyPercent * 100).ToString();//DataConvertHelper.FormatPayMoneyPercent(etpm.PayMoneyPercent.ToString(), false);
                tbPayMoneyAccount.Text = etpm.PayMoneyAccount;
                rbIsContainYes.Checked = etpm.ProtocolMoneyType == ProtocolMoneyType.NegotiatedInterestPayment;
                rbIsContainNo.Checked = !rbIsContainYes.Checked;
                tbProtocolPercent.Text = etpm.ProtocolMoneyPercent.ToString();
                tbPayMoneyOpenBankNo.Text = etpm.PayMoneyOpenBankNo;
                tbPayMoneyOpenBankName.Text = etpm.PayMoneyOpenBankName;
            }
        }

        private void btnQueryBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(tbPayMoneyOpenBankName.Text, tbPayMoneyOpenBankNo.Text);
            frm.IsOpenBank = true;
            frm.IsElecTicket = true;
            if (frm.ShowDialog() != DialogResult.OK) return;
            if (m_bankInfo.Count > 0)
            {
                if (m_bankInfo[1].StartsWith("104") && !frm.QueryDialogResult.Code.StartsWith("104"))
                {
                    MessageBoxPrime.Show("请选择中行开户行", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                }
            }
            tbPayMoneyOpenBankName.Text = frm.QueryDialogResult.Name;
            tbPayMoneyOpenBankNo.Text = frm.QueryDialogResult.Code;

            tbPayMoneyOpenBankName.ManualValidate();
            tbPayMoneyOpenBankNo.ManualValidate();

            if (frm != null)
                frm.Close();
        }

        private void rbIsContain_CheckedChanged(object sender, EventArgs e)
        {
            //lblProtocolPercent.Visible 
            tbProtocolPercent.DvRequired = rbIsContainYes.Checked;
            ChangeClearType();
            if (rbIsContainYes.Checked)
            {
                //利率校验
                tbProtocolPercent.DvRegCode = "reg724";
                tbProtocolPercent.DvMinLength = 1;
                tbProtocolPercent.DvMaxLength = 5;
                tbProtocolPercent.DvRequired = true;
                //rd = DataCheckCenter.CheckProtocolPercent(tbProtocolPercent, tbProtocolPercent.Text.Trim(), lbProtocolPercent.Text.Substring(0, lbProtocolPercent.Text.Length - 1), this.errorProvider1);
                //if (!rd.Result) return rd.Result;
            }
        }

        void ChangeClearType()
        {
            if (rbIsContainNo.Checked)
            {
                tbProtocolPercent.Text = "0";
            }
            tbProtocolPercent.ReadOnly = rbIsContainNo.Checked;
            tbProtocolPercent.DvRequired = !tbProtocolPercent.ReadOnly;

            //bool flag = rbIsContainYes.Checked && !string.IsNullOrEmpty(tbProtocolPercent.Text) && (double.Parse(tbProtocolPercent.Text.Trim()) != 0d) && !string.IsNullOrEmpty(tbPayMoneyOpenBankNo.Text) && (tbPayMoneyOpenBankNo.Text.Trim().StartsWith("104"));

            //rbClearTypeUnder.Checked = flag;
            //rbClearTypeOn.Checked = !rbClearTypeUnder.Checked;
            //rbClearTypeOn.Enabled = !flag;
        }
    }
}
