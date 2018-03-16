using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Types;
using CommonClient.VisualParts;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;

namespace CommonClient.VisualParts2
{
    public partial class PayeeEditor : BaseUc
    {
        private PayeeInfo m_payee = new PayeeInfo();

        public PayeeEditor()
        {
            InitializeComponent();

            cmbCertifyType.DropDownStyle = ComboBoxStyle.DropDownList;
            InitData();
            cmbCertifyType.SelectedIndex = 0;

            this.rbIsBocAccount.Tag = AccountBankType.BocAccount;
            this.rbIsOtherAccount.Tag = AccountBankType.OtherBankAccount;
            CommandCenter.OnPayeeInfoEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            cmbCertifyType.SelectedIndex = -1;
            SetRegex();
        }
        private void SetRegex()
        {
            edtPayeeSerial.DvRegCode = "reg8";
            edtPayeeSerial.DvMinLength = 1;
            edtPayeeSerial.DvMaxLength = 10;
            edtPayeeSerial.DvRequired = false;
            edtPayeeAccount.DvRegCode = "Predefined4";
            edtPayeeAccount.DvMinLength = 1;
            edtPayeeAccount.DvMaxLength = 35;
            edtPayeeAccount.DvRequired = true;
            edtPayeeName.DvRegCode = "Predefined5";
            edtPayeeName.DvMinLength = 1;
            edtPayeeName.DvMaxLength = 76;
            edtPayeeName.DvRequired = true;
            if (this.rbIsOtherAccount.Checked)
            {
                edtPayeeBankName.DvRegCode = "reg667";
                edtPayeeBankName.DvMinLength = 0;
                edtPayeeBankName.DvMaxLength = 70;
                edtPayeeBankName.DvRequired = false;
                edtPayeeClearBank.DvRegCode = "Predefined5";
                edtPayeeClearBank.DvMinLength = 0;
                edtPayeeClearBank.DvMaxLength = 70;
                edtPayeeClearBank.DvRequired = false;
            }
            //if (rbIsBocAccount.Checked)
            //{
            //    if (cmbCertifyType.SelectedIndex >= 0)
            //    {
            //        tbCertifyNo.DvRegCode = "reg579";
            //        tbCertifyNo.DvMinLength = 15;
            //        tbCertifyNo.DvMaxLength = 18;
            //        tbCertifyNo.DvRequired = true;
            //    }
            //}
            edtPayeeEmail.DvRegCode = "reg539";
            edtPayeeEmail.DvMinLength = 0;
            edtPayeeEmail.DvMaxLength = 30;
            edtPayeeEmail.DvRequired = false;
            edtPayeeAddress.DvRegCode = "reg686";
            edtPayeeAddress.DvMinLength = 0;
            edtPayeeAddress.DvMaxLength = 70;
            edtPayeeAddress.DvRequired = false;
            edtPayeeFax.DvRegCode = "reg612";
            edtPayeeFax.DvMinLength = 6;
            edtPayeeFax.DvMaxLength = 20;
            edtPayeeFax.DvRequired = false;
            edtPayeePhone.DvRegCode = "reg57";
            edtPayeePhone.DvMinLength = 11;
            edtPayeePhone.DvMaxLength = 15;
            edtPayeePhone.DvRequired = false;

        }
        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PayeeEditor), this);
                InitData();
            }
        }

        private void InitData()
        {
            cmbCertifyType.Items.Clear();
            cmbPayeeAccountCategoryType.Items.Clear();
            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
            {
                foreach (var act in PrequisiteDataProvideNode.InitialProvide.PayeeCertifyPaperTypeList)
                {
                    if (act == PayeeCertifyPaperType.Empty) continue;
                    cmbCertifyType.Items.Add(EnumNameHelper<PayeeCertifyPaperType>.GetEnumDescription(act));
                }
                cmbCertifyType.Tag = PrequisiteDataProvideNode.InitialProvide.PayeeCertifyPaperTypeList.FindAll(o => o != PayeeCertifyPaperType.Empty);
            }
            else
            {
                cmbCertifyType.Items.Add(EnumNameHelper<PayeeCertifyPaperType>.GetEnumDescription(PayeeCertifyPaperType.IDCard));
                cmbCertifyType.Tag = new List<PayeeCertifyPaperType> { PayeeCertifyPaperType.IDCard };
            }
            foreach (AccountCategoryType accountCategoryType in PrequisiteDataProvideNode.InitialProvide.AccountCategoryTypeList)
            {
                if (accountCategoryType == AccountCategoryType.Empty) continue;
                cmbPayeeAccountCategoryType.Items.Add(EnumNameHelper<AccountCategoryType>.GetEnumDescription(accountCategoryType));
            }
            cmbPayeeAccountCategoryType.Tag = PrequisiteDataProvideNode.InitialProvide.AccountCategoryTypeList.FindAll(o => o != AccountCategoryType.Empty);
            cmbPayeeAccountProvince.Items.Clear();
            foreach (ChinaProvinceType chinaProvinceType in PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList)
            {
                if (chinaProvinceType == ChinaProvinceType.B0) continue;
                var value = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(chinaProvinceType);
                this.cmbPayeeAccountProvince.Items.Add(value);
            }
            cmbPayeeAccountProvince.Tag = PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList.FindAll(o => o != ChinaProvinceType.B0);

        }

        void CommandCenter_OnPayeeInfoEventHandler(object sender, PayeeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler), new object[] { sender, e }); }
            else
            {
                this.errorProvider1.Clear();
                if (OperatorCommandType.Delete == e.Command)
                {
                    if (null != m_payee)
                    {
                        m_payee = null;
                        ClearItem();
                    }
                }
                else if (OperatorCommandType.View == e.Command)
                {
                    m_payee = e.PayeeInfo;
                    SetItem(e.PayeeInfo, e.RowIndex);
                }
            }
        }

        /// <summary>
        /// 获取收款人信息
        /// </summary>
        /// <returns></returns>
        public PayeeInfo GetItem()
        {
            var item = new PayeeInfo();
            item.Address = this.edtPayeeAddress.Text;
            item.SerialNo = this.edtPayeeSerial.Text;
            item.Account = this.edtPayeeAccount.Text;
            item.AccountType = (cmbPayeeAccountCategoryType.Tag as List<AccountCategoryType>)[cmbPayeeAccountCategoryType.SelectedIndex];
            item.ProvinceType = cmbPayeeAccountProvince.SelectedIndex != -1 ? (cmbPayeeAccountProvince.Tag as List<ChinaProvinceType>)[cmbPayeeAccountProvince.SelectedIndex] : ChinaProvinceType.B0;
            item.Name = this.edtPayeeName.Text;
            item.BankType = rbIsBocAccount.Checked ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount;
            item.Fax = this.edtPayeeFax.Text;
            item.Telephone = this.edtPayeePhone.Text;
            item.Email = this.edtPayeeEmail.Text;
            if (AccountBankType.OtherBankAccount == item.BankType)
            {
                CNAP c = edtPayeeBankName.Tag as CNAP;
                if (c != null)
                {
                    item.OpenBankName = c.Name;
                    item.CNAPSNo = c.Code;
                }
                else item.OpenBankName = edtPayeeBankName.Text.Trim();

                c = edtPayeeClearBank.Tag as CNAP;
                if (c != null)
                {
                    item.ClearBankName = c.Name;
                    item.CNAPSNoR = c.Code;
                }
                else item.ClearBankName = edtPayeeClearBank.Text.Trim();
            }
            else if (AccountBankType.BocAccount == item.BankType)
            {
                item.OpenBankName = MultiLanguageConvertHelper.Settings_PayeeMsg_BOCName;
                if (cmbCertifyType.SelectedIndex >= 0)
                    item.CertifyPaperType = (cmbCertifyType.Tag as List<PayeeCertifyPaperType>)[cmbCertifyType.SelectedIndex];
                item.CertifyPaperNo = tbCertifyNo.Text;
            }

            return item;
        }

        /// <summary>
        /// 设置收款人信息
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(PayeeInfo item, int rowindex)
        {
            if (null == item) return;
            edtPayeeBankName.Tag = null;
            edtPayeeClearBank.Tag = null;
            this.tbRowIndex.Text = rowindex.ToString();
            this.rbIsBocAccount.Checked = item.BankType == AccountBankType.BocAccount;
            this.rbIsOtherAccount.Checked = !this.rbIsBocAccount.Checked;
            this.edtPayeeAddress.Text = item.Address;
            this.edtPayeeSerial.Text = item.SerialNo;
            this.edtPayeeAccount.Text = item.Account;
            this.edtPayeeName.Text = item.Name;
            this.cmbPayeeAccountProvince.SelectedIndex = (cmbPayeeAccountProvince.Tag as List<ChinaProvinceType>).FindIndex(o => item.ProvinceType == o);
            this.cmbPayeeAccountCategoryType.SelectedIndex = item.AccountType == AccountCategoryType.Empty ? -1
                                                            : item.AccountType == AccountCategoryType.Corperation ? 0
                                                            : item.AccountType == AccountCategoryType.Personal ? 1 : -1;
            this.edtPayeeFax.Text = item.Fax;
            this.edtPayeePhone.Text = item.Telephone;
            this.edtPayeeEmail.Text = item.Email;
            if (item.BankType != AccountBankType.BocAccount)
            {
                this.edtPayeeBankName.Text = item.OpenBankName;
                this.edtPayeeClearBank.Text = item.ClearBankName;
                edtPayeeBankName.Tag = new CNAP { Code = item.CNAPSNo, Name = item.OpenBankName };
                edtPayeeClearBank.Tag = new CNAP { Code = item.CNAPSNoR, Name = item.ClearBankName };
            }
            if ((SystemSettings.CurrentVersion & VersionType.v501) != VersionType.v501)
            {
                if (item.CertifyPaperType != PayeeCertifyPaperType.IDCard)
                    this.cmbCertifyType.SelectedIndex = -1;
                else this.cmbCertifyType.SelectedIndex = 0;
            }
            else
            {
                this.cmbCertifyType.SelectedIndex = (this.cmbCertifyType.Tag as List<PayeeCertifyPaperType>).FindIndex(o => o != PayeeCertifyPaperType.Empty && o == item.CertifyPaperType);
            }
            if (!string.IsNullOrEmpty(item.CertifyPaperNo))
            { this.tbCertifyNo.Text = item.CertifyPaperNo; }
        }

        /// <summary>
        /// 重置收款人信息
        /// </summary>
        public void ClearItem()
        {
            this.tbCertifyNo.Text =
            this.edtPayeeAddress.Text = string.Empty; ;
            this.edtPayeeSerial.Text = string.Empty; ;
            this.edtPayeeAccount.Text = string.Empty; ;
            this.edtPayeeName.Text = string.Empty; ;
            this.cmbPayeeAccountCategoryType.SelectedIndex = -1;
            this.edtPayeeFax.Text = string.Empty; ;
            this.edtPayeePhone.Text = string.Empty; ;
            this.edtPayeeEmail.Text = string.Empty; ;
            this.edtPayeeBankName.Text = string.Empty;
            this.edtPayeeClearBank.Text = string.Empty;
            this.tbCertifyNo.Text = string.Empty;
            this.cmbPayeeAccountProvince.SelectedIndex =
            cmbCertifyType.SelectedIndex = -1;
            edtPayeeBankName.Tag = null;
            edtPayeeClearBank.Tag = null;
        }

        private void PayeeEditor_Load(object sender, EventArgs e)
        {
            this.cmbPayeeAccountCategoryType.SelectedIndex = -1;
            SelectBoccAccount(false);
        }

        private void rbIsBoccAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbIsOtherAccount.Checked)
            {
                edtPayeeBankName.DvRegCode = "reg667";
                edtPayeeBankName.DvMinLength = 0;
                edtPayeeBankName.DvMaxLength = 70;
                edtPayeeBankName.DvRequired = false;
                edtPayeeClearBank.DvRegCode = "Predefined5";
                edtPayeeClearBank.DvMinLength = 0;
                edtPayeeClearBank.DvMaxLength = 70;
                edtPayeeClearBank.DvRequired = false;
            }
            if (rbIsBocAccount.Checked)
            {
                if (cmbCertifyType.SelectedIndex >= 0)
                {
                    tbCertifyNo.DvRegCode = "reg579";
                    tbCertifyNo.DvMinLength = 15;
                    tbCertifyNo.DvMaxLength = 18;
                    tbCertifyNo.DvRequired = true;
                }
            }
            bool flag = (sender as RadioButton).Name != rbIsBocAccount.Name;
            SelectBoccAccount(flag);
        }

        public void SelectBoccAccount(bool flag)
        {
            panelOtherBank.Visible = flag;
            pCertify.Visible = !flag;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolvePayee(OperatorCommandType.Submit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());

            edtPayeeBankName.Tag = null;
            edtPayeeClearBank.Tag = null;
        }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd.Result = base.CheckValid();
            rd.Result = rd.Result && DataCheckCenter.CheckSerialNoGJ(edtPayeeSerial, edtPayeeSerial.Text.Trim(), lblPayeeSerial.Text.Substring(0, lblPayeeSerial.Text.Length - 1), 10, this.errorProvider1).Result;
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeeAccount(edtPayeeAccount, edtPayeeAccount.Text.Trim(), lblPayeeAccount.Text.Trim().Substring(0, lblPayeeAccount.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeeOrElecTicketPersonName(edtPayeeName, edtPayeeName.Text, lblPayeeName.Text.Substring(0, lblPayeeName.Text.Length - 1), 76, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (cmbPayeeAccountCategoryType.SelectedIndex < 0)
            //{ MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_PayeeMsg_Select_AccountType, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //if (this.rbIsOtherAccount.Checked)
            //{
            //    if (!string.IsNullOrEmpty(edtPayeeBankName.Text))
            //    {
            //        rd = DataCheckCenter.CheckOpenBankName(edtPayeeBankName, edtPayeeBankName.Text, lblPayeeBankName.Text.Substring(0, lblPayeeBankName.Text.Length - 1), this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //    if (!string.IsNullOrEmpty(edtPayeeClearBank.Text))
            //    {
            //        rd = DataCheckCenter.CheckClearBankName(edtPayeeClearBank, edtPayeeClearBank.Text.Trim(), lblPayeeClearBank.Text.Substring(0, lblPayeeClearBank.Text.Length - 1), 70, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            //if (rbIsBocAccount.Checked)
            //{
            //    if (cmbCertifyType.SelectedIndex >= 0)
            //    {
            //        if (!string.IsNullOrEmpty(tbCertifyNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckCertifyCardNo(tbCertifyNo, tbCertifyNo.Text.Trim(), label4.Text.Substring(0, label4.Text.Length - 1), true, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //    }
            //}
            //if (!string.IsNullOrEmpty(this.edtPayeeEmail.Text))
            //{
            //    rd = DataCheckCenter.CheckEmail(edtPayeeEmail, edtPayeeEmail.Text, 30, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(edtPayeeAddress.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeeAddress(edtPayeeAddress, edtPayeeAddress.Text, 70, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(edtPayeeFax.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeeFax(edtPayeeFax, edtPayeeFax.Text, lblPayeeFax.Text.Substring(0, lblPayeeFax.Text.Length - 1), 20, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //} if (!string.IsNullOrEmpty(edtPayeePhone.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeePhone(edtPayeePhone, edtPayeePhone.Text, 11, 15, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
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
            this.errorProvider1.Clear();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(edtPayeeBankName.Text);
            bool isOpenBank = (sender as Button).Name == buttonQueryO.Name;
            frm.IsOpenBank = isOpenBank;
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                frm.AppType = AppliableFunctionType.AgentExpressOut4Bar;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (isOpenBank)
                {
                    edtPayeeBankName.Text = frm.QueryDialogResult.Name;
                    edtPayeeBankName.Tag = frm.QueryDialogResult;

                    edtPayeeBankName.ManualValidate();
                }
                else
                {
                    edtPayeeClearBank.Text = frm.QueryDialogResult.Name;
                    edtPayeeClearBank.Tag = frm.QueryDialogResult;

                    edtPayeeClearBank.ManualValidate();
                }
            }

            if (null != frm)
                frm.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolvePayee(OperatorCommandType.Edit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("用于自定义收款人顺序,便于查找,年内不可重复", pbTip);
        }

        private void cmbCertifyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbIsBocAccount.Checked)
            {
                if (cmbCertifyType.SelectedIndex >= 0)
                {
                    tbCertifyNo.DvRegCode = "reg579";
                    tbCertifyNo.DvMinLength = 15;
                    tbCertifyNo.DvMaxLength = 18;
                    tbCertifyNo.DvRequired = true;
                    if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                    {
                        tbCertifyNo.DvRegCode = "reg8";
                        tbCertifyNo.DvMinLength = 1;
                        tbCertifyNo.DvMaxLength = 32;
                        tbCertifyNo.DvRequired = true;
                    }
                }
                else
                {
                    tbCertifyNo.DvRegCode = string.Empty;
                    tbCertifyNo.DvRequired = false;
                }
            }
        }
    }
}
