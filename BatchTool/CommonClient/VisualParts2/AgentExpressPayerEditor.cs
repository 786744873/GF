using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.Types;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class AgentExpressPayerEditor : BaseUc
    {
        public AgentExpressPayerEditor()
        {
            InitializeComponent();

            lblProtecolNo.Visible = false;
            cmbCertifyType.DropDownStyle = ComboBoxStyle.DropDownList;
            InitData();
            cmbCertifyType.SelectedIndex = 0;
            cmbPayeeAccountProvince.SelectedIndex = -1;

            this.rbIsBocAccount.Tag = AccountBankType.BocAccount;
            this.rbIsOtherAccount.Tag = AccountBankType.OtherBankAccount;
            CommandCenter.OnAgentExpressPayerEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            cmbCertifyType.SelectedIndex = -1;
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
            }
        }

        private void InitData()
        {
            cmbCertifyType.Items.Clear();
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.PayeeCertifyPaperTypeList)
            {
                if (item == PayeeCertifyPaperType.Empty) continue;
                cmbCertifyType.Items.Add(EnumNameHelper<PayeeCertifyPaperType>.GetEnumDescription(item));
            }
            cmbCertifyType.Tag = PrequisiteDataProvideNode.InitialProvide.PayeeCertifyPaperTypeList.FindAll(o => o != PayeeCertifyPaperType.Empty);
            cmbPayeeAccountProvince.Items.Clear();
            foreach (ChinaProvinceType chinaProvinceType in PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList)
            {
                if (chinaProvinceType == ChinaProvinceType.B0) continue;
                var value = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(chinaProvinceType);
                this.cmbPayeeAccountProvince.Items.Add(value);
            }
            cmbPayeeAccountProvince.Tag = PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList.FindAll(o => o != ChinaProvinceType.B0);

            SetRegex();
        }
        private void SetRegex()
        {
            edtPayeeSerial.DvRegCode = "reg8";
            edtPayeeSerial.DvMinLength = 0;
            edtPayeeSerial.DvMaxLength = 10;
            edtPayeeSerial.DvRequired = false;
            edtPayeeAccount.DvRegCode = rbIsBocAccount.Checked ? "reg687" : "reg688";
            edtPayeeAccount.DvMinLength = 1;
            edtPayeeAccount.DvMaxLength = rbIsBocAccount.Checked ? 20 : 25;
            edtPayeeAccount.DvRequired = true;
            edtPayeeName.DvRegCode = "reg685";
            edtPayeeName.DvMinLength = 1;
            edtPayeeName.DvMaxLength = 58;
            edtPayeeName.DvRequired = true;
            if (this.rbIsOtherAccount.Checked)
            {

                edtPayeeBankName.DvRegCode = "reg667";
                edtPayeeBankName.DvMinLength = 1;
                edtPayeeBankName.DvMaxLength = 70;
                edtPayeeBankName.DvRequired = true;

            }
            edtPayeeEmail.DvRegCode = "reg539";
            edtPayeeEmail.DvMinLength = 3;
            edtPayeeEmail.DvMaxLength = 40;
            edtPayeeEmail.DvRequired = false;

            edtPayeeAddress.DvRegCode = "reg686";
            edtPayeeAddress.DvMinLength = 0;
            edtPayeeAddress.DvMaxLength = 76;
            edtPayeeAddress.DvRequired = false;

            edtPayeeFax.DvRegCode = "reg612";
            edtPayeeFax.DvMinLength = 6;
            edtPayeeFax.DvMaxLength = 20;
            edtPayeeFax.DvRequired = false;

            edtPayeePhone.DvRegCode = "reg57";
            edtPayeePhone.DvMinLength = 11;
            edtPayeePhone.DvMaxLength = 15;
            edtPayeePhone.DvRequired = false;

            tbProtecolNo.DvRegCode = "reg666";
            tbProtecolNo.DvMinLength = 0;
            tbProtecolNo.DvMaxLength = 60;
            tbProtecolNo.DvRequired = false;

        }

        void CommandCenter_OnAgentExpressPayerEventHandler(object sender, PayeeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler), new object[] { sender, e }); }
            else
            {
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
        /// 获取付款人信息
        /// </summary>
        /// <returns></returns>
        public PayeeInfo GetItem()
        {
            var item = new PayeeInfo();
            item.Address = this.edtPayeeAddress.Text;
            item.SerialNo = this.edtPayeeSerial.Text;
            item.Account = this.edtPayeeAccount.Text;
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
            }
            else if (AccountBankType.BocAccount == item.BankType)
            {
                item.OpenBankName = MultiLanguageConvertHelper.Settings_PayeeMsg_BOCName;
                item.ProvinceType = (cmbPayeeAccountProvince.Tag as List<ChinaProvinceType>)[cmbPayeeAccountProvince.SelectedIndex];
            }
            if (cmbCertifyType.SelectedIndex >= 0)
                item.CertifyPaperType = (cmbCertifyType.Tag as List<PayeeCertifyPaperType>)[cmbCertifyType.SelectedIndex];
            item.CertifyPaperNo = tbCertifyNo.Text;
            item.ProtecolNo = tbProtecolNo.Text.Trim();

            return item;
        }

        /// <summary>
        /// 设置付款人信息
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(PayeeInfo item, int rowindex)
        {
            if (null == item) return;
            edtPayeeBankName.Tag = null;
            this.tbRowIndex.Text = rowindex.ToString();
            this.rbIsBocAccount.Checked = item.BankType == AccountBankType.BocAccount;
            this.rbIsOtherAccount.Checked = !this.rbIsBocAccount.Checked;
            this.edtPayeeAddress.Text = item.Address;
            this.edtPayeeSerial.Text = item.SerialNo;
            this.edtPayeeAccount.Text = item.Account;
            this.edtPayeeName.Text = item.Name;
            this.edtPayeeFax.Text = item.Fax;
            this.edtPayeePhone.Text = item.Telephone;
            this.edtPayeeEmail.Text = item.Email;
            if (item.BankType != AccountBankType.BocAccount)
            {
                this.edtPayeeBankName.Text = item.OpenBankName;
                edtPayeeBankName.Tag = new CNAP { Code = item.CNAPSNo, Name = item.OpenBankName };
            }
            else
            {
                if (item.ProvinceType == ChinaProvinceType.B0) cmbPayeeAccountProvince.SelectedIndex = -1;
                else cmbPayeeAccountProvince.SelectedItem = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(item.ProvinceType);
            }
            this.cmbCertifyType.SelectedIndex = cmbCertifyType.Items.Count == 0 ? -1 : (cmbCertifyType.Tag as List<PayeeCertifyPaperType>).FindIndex(o => o == item.CertifyPaperType);
            if (!string.IsNullOrEmpty(item.CertifyPaperNo))
            { this.tbCertifyNo.Text = item.CertifyPaperNo; }
            tbProtecolNo.Text = item.ProtecolNo;
        }

        /// <summary>
        /// 重置付款人信息
        /// </summary>
        public void ClearItem()
        {
            this.edtPayeeAddress.Text = string.Empty; ;
            this.edtPayeeSerial.Text = string.Empty; ;
            this.edtPayeeAccount.Text = string.Empty; ;
            this.edtPayeeName.Text = string.Empty; ;
            this.edtPayeeFax.Text = string.Empty; ;
            this.edtPayeePhone.Text = string.Empty; ;
            this.edtPayeeEmail.Text = string.Empty; ;
            this.edtPayeeBankName.Text = string.Empty;
            this.tbProtecolNo.Text = string.Empty;
            this.tbCertifyNo.Text = string.Empty;
            cmbCertifyType.SelectedIndex = -1;
            edtPayeeBankName.Tag = null;
            this.cmbPayeeAccountProvince.SelectedIndex = -1;
            this.errorProvider1.Clear();
        }

        private void PayeeEditor_Load(object sender, EventArgs e)
        {
            SelectBoccAccount(false);
            lblProtecolNo.Visible = false;
        }

        private void rbIsBoccAccount_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                bool flag = (sender as RadioButton).Name != rbIsBocAccount.Name;
                SelectBoccAccount(flag);
                lblProtecolNo.Visible = flag;
                edtPayeeBankName.DvRegCode = "reg667";
                edtPayeeBankName.DvMinLength = 0;
                edtPayeeBankName.DvMaxLength = 70;
                edtPayeeBankName.DvRequired = false;
                edtPayeeAccount.DvRegCode = rbIsBocAccount.Checked ? "reg687" : "reg688";
                edtPayeeAccount.DvMinLength = 1;
                edtPayeeAccount.DvMaxLength = rbIsBocAccount.Checked ? 20 : 25;
                edtPayeeAccount.DvRequired = true;
            }
        }

        public void SelectBoccAccount(bool flag)
        {
            panelOtherBank.Visible = flag;
            panel5.Visible = !flag;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Submit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());

            edtPayeeBankName.Tag = null;
        }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeeAccountGJEx(edtPayeeAccount, edtPayeeAccount.Text.Trim(), lblPayeeAccount.Text.Trim().Substring(0, lblPayeeAccount.Text.Length - 1), rbIsBocAccount.Checked ? 20 : 25, rbIsBocAccount.Checked, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeeNameAgentInOrUP(edtPayeeName, edtPayeeName.Text, lblPayeeName.Text.Substring(0, lblPayeeName.Text.Length - 1), 58, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (this.rbIsOtherAccount.Checked)
            //{
            //    if (!string.IsNullOrEmpty(edtPayeeBankName.Text))
            //    {
            //        rd = DataCheckCenter.CheckOpenBankName(edtPayeeBankName, edtPayeeBankName.Text, lblPayeeBankName.Text.Substring(0, lblPayeeBankName.Text.Length - 1), this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            //if (cmbCertifyType.SelectedIndex >= 0)
            //{
            //    rd = DataCheckCenter.CheckCertifyCardNoEx(tbCertifyNo, tbCertifyNo.Text.Trim(), label4.Text.Substring(0, label4.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(this.edtPayeeEmail.Text))
            //{
            //    rd = DataCheckCenter.CheckEmailGJ(edtPayeeEmail, edtPayeeEmail.Text, lblPayeeEmail.Text.Substring(0, lblPayeeEmail.Text.Length - 1), 3, 40, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(edtPayeeAddress.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeeAddress(edtPayeeAddress, edtPayeeAddress.Text, 76, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(edtPayeeFax.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeeFax(edtPayeeFax, edtPayeeFax.Text, lblPayeeFax.Text.Substring(0, lblPayeeFax.Text.Length - 1), 20, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(edtPayeePhone.Text))
            //{
            //    rd = DataCheckCenter.CheckPayeePhone(edtPayeePhone, edtPayeePhone.Text, 11, 15, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (rbIsOtherAccount.Checked || (rbIsBocAccount.Checked && !string.IsNullOrEmpty(tbProtecolNo.Text)))
            //{
            //    rd = DataCheckCenter.CheckAgrementNoEx(tbProtecolNo, tbProtecolNo.Text.Trim(), lbProtecolNo.Text.Substring(0, lbProtecolNo.Text.Length - 1), 60, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearItem();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(edtPayeeBankName.Text.Trim());
            bool isOpenBank = (sender as Button).Name == buttonQueryO.Name;
            frm.IsOpenBank = isOpenBank;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                edtPayeeBankName.Text = frm.QueryDialogResult.Name;
                edtPayeeBankName.Tag = frm.QueryDialogResult;

                edtPayeeBankName.ManualValidate();
            }

            if (null != frm)
                frm.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Edit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(AgentExpressPayerEditor), this);

            InitData();
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("用于自定义付款人顺序，便于查找，年内不可重复", pbTip);
        }

        private void cmbCertifyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCertifyType.SelectedIndex >= 0)
            {
                tbCertifyNo.DvRegCode = "reg8";
                tbCertifyNo.DvMinLength = 1;
                tbCertifyNo.DvMaxLength = 32;
            }
        }

    }
}
