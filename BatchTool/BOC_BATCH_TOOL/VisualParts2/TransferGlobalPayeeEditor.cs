using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class TransferGlobalPayeeEditor : BaseUc
    {
        public TransferGlobalPayeeEditor()
        {
            InitializeComponent();

            CommandCenter.Instance.OnPayeeInfo4TransferGlobalEventHandler += new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            lbAccountDesc.Text = MultiLanguageConvertHelper.Instance.DesignMain_TransferGlobal_PayeeAccountDescription;
            lbAddressDesc.Text = MultiLanguageConvertHelper.Instance.DesignMain_TransferGlobal_RemitAddressDescription;
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TransferGlobalPayeeEditor), this);
                tbPayeeOpenBankName.Text = BOC_BATCH_TOOL.Utilities.EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.BocAccount);
            }
        }

        void CommandCenter_OnPayeeInfo4TransferGlobalEventHandler(object sender, Payee4TransferGlobalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler), new object[] { sender, e }); }
            else
            {
                this.errorProvider1.Clear();
                if (OperatorCommandType.Delete == e.Command)
                {
                    ClearItem();
                }
                else if (OperatorCommandType.View == e.Command)
                {
                    SetItem(e.PayeeInfo, e.RowIndex);
                }
            }
        }

        /// <summary>
        /// 获取收款人信息
        /// </summary>
        /// <returns></returns>
        public PayeeInfo4TransferGlobal GetItem()
        {
            var item = new PayeeInfo4TransferGlobal();
            item.AccountType = rbBocAccount.Checked ? OverCountryPayeeAccountType.BocAccount
                                : rbOtherAccount.Checked ? OverCountryPayeeAccountType.OtherAccount
                                : rbForeignAccount.Checked ? OverCountryPayeeAccountType.ForeignAccount
                                : OverCountryPayeeAccountType.Empty;
            item.Account = tbAccount.Text.Trim();
            item.SerialNo = tbSerialNo.Text.Trim();
            item.Name = tbPayeeName.Text.Trim();
            item.Address = tbPayeeAddress.Text.Trim();
            if (!string.IsNullOrEmpty(tbCountry.Text.Trim()))
            {
                string str = tbCountry.Text.Trim();
                int index = str.LastIndexOf(" ");
                if (index >= 0)
                {
                    item.NameofCountry = str.Substring(0, index);
                    item.CodeofCountry = str.Substring(index + 1, str.Length - index - 1);
                }
            }
            item.OpenBankName = tbPayeeOpenBankName.Text.Trim();
            item.OpenBankAddress = tbPayeeOpenBankAddress.Text.Trim();
            if (!rbForeignAccount.Checked)
                item.OpenBankType = rbBocAccount.Checked ? AccountBankType.BocAccount : rbOtherAccount.Checked ? AccountBankType.OtherBankAccount : AccountBankType.Empty;
            item.CorrespondentBankName = tbCorrespondentBankName.Text.Trim();
            item.CorrespondentBankAddress = tbCorrespondentBankAddress.Text.Trim();
            item.AccountInCorrespondentBank = tbPayeeAccountInCorrespondentBank.Text.Trim();
            item.Fax = tbFax.Text.Trim();
            item.Telephone = tbTel.Text.Trim();
            item.Email = tbEamil.Text.Trim();
            return item;
        }

        /// <summary>
        /// 设置收款人信息
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(PayeeInfo4TransferGlobal item, int rowindex)
        {
            if (null == item)
            {
                return;
            }
            rbBocAccount.Checked = item.AccountType == OverCountryPayeeAccountType.BocAccount || item.AccountType == OverCountryPayeeAccountType.Empty;
            rbOtherAccount.Checked = item.AccountType == OverCountryPayeeAccountType.OtherAccount;
            rbForeignAccount.Checked = item.AccountType == OverCountryPayeeAccountType.ForeignAccount;
            tbRowIndex.Text = rowindex.ToString();
            tbSerialNo.Text = item.SerialNo;
            tbAccount.Text = item.Account;
            tbPayeeName.Text = item.Name;
            tbCountry.Text = item.NameofCountry + " " + item.CodeofCountry;
            tbPayeeAddress.Text = item.Address;
            tbPayeeOpenBankName.Text = item.OpenBankName;
            tbPayeeOpenBankAddress.Text = item.OpenBankAddress;
            tbCorrespondentBankName.Text = item.CorrespondentBankName;
            tbCorrespondentBankAddress.Text = item.CorrespondentBankAddress;
            tbPayeeAccountInCorrespondentBank.Text = item.AccountInCorrespondentBank;
            tbFax.Text = item.Fax;
            tbTel.Text = item.Telephone;
            tbEamil.Text = item.Email;
        }

        /// <summary>
        /// 重置收款人信息
        /// </summary>
        public void ClearItem()
        {
            tbRowIndex.Text =
            tbSerialNo.Text =
            tbAccount.Text =
            tbPayeeName.Text =
            tbPayeeAddress.Text =
            tbCountry.Text =
            tbPayeeOpenBankName.Text =
            tbPayeeOpenBankAddress.Text =
            tbCorrespondentBankAddress.Text =
            tbCorrespondentBankName.Text =
            tbPayeeAccountInCorrespondentBank.Text =
            tbFax.Text =
            tbTel.Text =
            tbEamil.Text = string.Empty;
            rbBocAccount.Checked = true;
            SelectAccount(true);
        }

        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                bool flag = (sender as RadioButton).Name == rbBocAccount.Name;
                SelectAccount(flag);
            }
        }

        public void SelectAccount(bool flag)
        {
            btnQueryOpenBank.Visible = !flag;
            tbPayeeOpenBankName.ReadOnly = flag;
            tbPayeeOpenBankName.Text = flag ? BOC_BATCH_TOOL.Utilities.EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.BocAccount) : string.Empty;
            pAccountDesc.Visible = pbTips.Visible = rbForeignAccount.Checked;//pAddressDesc.Visible = flag;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (CheckData())
                CommandCenter.Instance.ResolvePayee4TransferGlobal(OperatorCommandType.Submit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
        }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        public bool CheckData()
        {
            ResultData rd = new ResultData();
            if (rbForeignAccount.Checked)
            {
                rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbAccount, tbAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 34, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbPayeeAddress, tbPayeeAddress.Text.Trim(), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(tbPayeeName, tbPayeeName.Text.Trim(), tbPayeeAddress.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbCorrespondentBankAddress, tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim() + tbCorrespondentBankAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbPayeeAccountInCorrespondentBank.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(tbPayeeAccountInCorrespondentBank, tbPayeeAccountInCorrespondentBank.Text.Trim(), lbPayeeAccountInCorrespondentBank.Text.Substring(0, lbPayeeAccountInCorrespondentBank.Text.Length - 1), 34, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            else
            {
                if (rbBocAccount.Checked)
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(tbAccount, tbAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 20, true, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                else if (rbOtherAccount.Checked)
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(tbAccount, tbAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 32, false, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), 70, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbPayeeAddress, tbPayeeAddress.Text.Trim(), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), 70, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbCorrespondentBankAddress, tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbPayeeAccountInCorrespondentBank.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(tbPayeeAccountInCorrespondentBank, tbPayeeAccountInCorrespondentBank.Text.Trim(), lbPayeeAccountInCorrespondentBank.Text.Substring(0, lbPayeeAccountInCorrespondentBank.Text.Length - 1), 32, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
            { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCountry), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!string.IsNullOrEmpty(tbSerialNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckSerialNoGJ(tbSerialNo, tbSerialNo.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 10, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(tbTel.Text))
            {
                rd = DataCheckCenter.Instance.CheckTelePhone(tbTel, tbTel.Text.Trim(), lbTel.Text.Substring(0, lbTel.Text.Length - 1), 15, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(tbFax.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayeeFaxGJ(tbFax, tbFax.Text.Trim(), lbFax.Text.Substring(0, lbFax.Text.Length - 1), 6, 20, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(tbEamil.Text))
            {
                rd = DataCheckCenter.Instance.CheckEmailGJ(tbEamil, tbEamil.Text.Trim(), lbEmail.Text.Substring(0, lbEmail.Text.Length - 1), 3, 40, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return true;
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearItem();
            rbBocAccount.Checked = true;
            rbOtherAccount.Checked =
            rbForeignAccount.Checked = false;
            SelectAccount(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckData())
                CommandCenter.Instance.ResolvePayee4TransferGlobal(OperatorCommandType.Edit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
        }

        private void btnQueryCountry_Click(object sender, EventArgs e)
        {
            frmCountryQuery frm = new frmCountryQuery();
            if (frm.ShowDialog() != DialogResult.OK) return;
            tbCountry.Text = string.Format("{0} {1}", frm.QueryResult.Name, frm.QueryResult.Code);

            if (null != frm)
                frm.Close();
        }

        private void btnQueryBank_Click(object sender, EventArgs e)
        {
            frmOpenBankQuery frm = new frmOpenBankQuery();
            if (frm.ShowDialog() != DialogResult.OK) return;
            if (((BOC_BATCH_TOOL.Controls.ThemedButton)sender).Name.Equals(btnQueryOpenBank.Name))
            {
                tbPayeeOpenBankName.Text = frm.QueryDialogResult.Name;
                tbPayeeOpenBankAddress.Text = frm.QueryDialogResult.Addr;
            }
            else if (((BOC_BATCH_TOOL.Controls.ThemedButton)sender).Name.Equals(btnQueryCorrespondentBank.Name))
            {
                tbCorrespondentBankName.Text = frm.QueryDialogResult.Name;
                tbCorrespondentBankAddress.Text = frm.QueryDialogResult.Addr;
            }

            if (null != frm)
                frm.Close();
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show(MultiLanguageConvertHelper.Instance.Tips_ForeignCount_Needed, pbTip);
        }

        private void pbTips_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show(MultiLanguageConvertHelper.Instance.Tips_ForeignCount_Needed, pbTips);
        }
    }
}
