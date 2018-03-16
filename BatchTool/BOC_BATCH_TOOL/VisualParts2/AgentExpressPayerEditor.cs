using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
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

            this.rbIsBocAccount.Tag = AccountBankType.BocAccount;
            this.rbIsOtherAccount.Tag = AccountBankType.OtherBankAccount;
            CommandCenter.Instance.OnAgentExpressPayerEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.AgentExpressCertifyPaperTypeList)
            {
                if (item == AgentExpressCertifyPaperType.Empty) continue;
                cmbCertifyType.Items.Add(EnumNameHelper<AgentExpressCertifyPaperType>.GetEnumDescription(item));
            }
            cmbCertifyType.Tag = PrequisiteDataProvideNode.InitialProvide.AgentExpressCertifyPaperTypeList.FindAll(o => o != AgentExpressCertifyPaperType.Empty);
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
                item.OpenBankName = MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_BOCName;
            }
            if (cmbCertifyType.SelectedIndex >= 0)
                item.CertifyPaperType = (cmbCertifyType.Tag as List<AgentExpressCertifyPaperType>)[cmbCertifyType.SelectedIndex];
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
            if (item.CertifyPaperType != AgentExpressCertifyPaperType.IDCard)
            {
                this.cmbCertifyType.SelectedIndex = -1;
            }
            else this.cmbCertifyType.SelectedIndex = 0;
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
            }
        }

        public void SelectBoccAccount(bool flag)
        {
            panelOtherBank.Visible = flag;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (CheckData())
                CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.Submit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());

            edtPayeeBankName.Tag = null;
        }

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        public bool CheckData()
        {
            ResultData rd = DataCheckCenter.Instance.CheckSerialNoGJ(edtPayeeSerial, edtPayeeSerial.Text.Trim(), lblPayeeSerial.Text.Substring(0, lblPayeeSerial.Text.Length - 1), 10, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(edtPayeeAccount, edtPayeeAccount.Text.Trim(), lblPayeeAccount.Text.Trim().Substring(0, lblPayeeAccount.Text.Length - 1), rbIsBocAccount.Checked ? 20 : 25, rbIsBocAccount.Checked, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(edtPayeeName, edtPayeeName.Text, lblPayeeName.Text.Substring(0, lblPayeeName.Text.Length - 1), 58, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (this.rbIsOtherAccount.Checked)
            {
                if (!string.IsNullOrEmpty(edtPayeeBankName.Text))
                {
                    rd = DataCheckCenter.Instance.CheckOpenBankName(edtPayeeBankName, edtPayeeBankName.Text, lblPayeeBankName.Text.Substring(0, lblPayeeBankName.Text.Length - 1), this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            if (cmbCertifyType.SelectedIndex >= 0)
            {
                rd = DataCheckCenter.Instance.CheckCertifyCardNoEx(tbCertifyNo, tbCertifyNo.Text.Trim(), label4.Text.Substring(0, label4.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(this.edtPayeeEmail.Text))
            {
                rd = DataCheckCenter.Instance.CheckEmailGJ(edtPayeeEmail, edtPayeeEmail.Text, lblPayeeEmail.Text.Substring(0, lblPayeeEmail.Text.Length - 1), 3, 40, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(edtPayeeAddress.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayeeAddress(edtPayeeAddress, edtPayeeAddress.Text, 76, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(edtPayeeFax.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayeeFax(edtPayeeFax, edtPayeeFax.Text, lblPayeeFax.Text.Substring(0, lblPayeeFax.Text.Length - 1), 20, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(edtPayeePhone.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayeePhone(edtPayeePhone, edtPayeePhone.Text, 11, 15, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (rbIsOtherAccount.Checked || (rbIsBocAccount.Checked && !string.IsNullOrEmpty(tbProtecolNo.Text)))
            {
                rd = DataCheckCenter.Instance.CheckAgrementNoEx(tbProtecolNo, tbProtecolNo.Text.Trim(), lbProtecolNo.Text.Substring(0, lbProtecolNo.Text.Length - 1), 60, this.errorProvider1);
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
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery();
            bool isOpenBank = (sender as Button).Name == buttonQueryO.Name;
            frm.IsOpenBank = isOpenBank;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                edtPayeeBankName.Text = frm.QueryDialogResult.Name;
                edtPayeeBankName.Tag = frm.QueryDialogResult;
            }

            if (null != frm)
                frm.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckData())
                CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.Edit, GetItem(), AppliableFunctionType._Empty, GetRowIndex());
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
    }
}
