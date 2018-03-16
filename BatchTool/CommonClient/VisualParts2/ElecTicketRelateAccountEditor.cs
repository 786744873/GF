using System;
using System.Windows.Forms;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class ElecTicketRelateAccountEditor : BaseUc
    {
        public ElecTicketRelateAccountEditor()
        {
            InitializeComponent();
            CommandCenter.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            SetRegex();
        }
        private void SetRegex()
        {
            tbPersonName.DvRegCode = "reg667";
            tbPersonName.DvMinLength = 1;
            tbPersonName.DvMaxLength = 120;
            tbPersonName.DvRequired = true;
            tbPersonAccount.DvRegCode = "reg629";
            tbPersonAccount.DvMinLength = 1;
            tbPersonAccount.DvMaxLength = 32;
            tbPersonAccount.DvRequired = true;
            tbOpenBankNo.DvRegCode = "reg57";
            tbOpenBankNo.DvMinLength = 12;
            tbOpenBankNo.DvMaxLength = 12;
            tbOpenBankNo.DvRequired = true;
            //if (GetRelateType() == RelatePersonType.Empty)
            //{
            //    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_RelateAccountMsg_Select_PersonType, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            //    return ;
            //}
            tbSerialNo.DvRegCode = "reg634";
            tbSerialNo.DvMinLength = 0;
            tbSerialNo.DvMaxLength = 10;
            tbSerialNo.DvRequired = false;
            tbTel1.DvRegCode = "reg574";
            tbTel1.DvMinLength = 0;
            tbTel1.DvMaxLength = 15;
            tbTel1.DvRequired = false;
            tbEmailF.DvRegCode = "reg539";
            tbEmailF.DvMinLength = 0;
            tbEmailF.DvMaxLength = 60;
            tbEmailF.DvRequired = false;
            tbTel2.DvRegCode = "reg574";
            tbTel2.DvMinLength = 0;
            tbTel2.DvMaxLength = 15;
            tbTel2.DvRequired = false;
            tbEmailS.DvRegCode = "reg539";
            tbEmailS.DvMinLength = 0;
            tbEmailS.DvMaxLength = 60;
            tbEmailS.DvRequired = false;
        }
        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketRelateAccountEditor), this);
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler), sender, e); }
            else
            {
                if (e.Command != OperatorCommandType.View) return;
                SetItem(e.RelationAccount, e.RowIndex);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, GetItem(), GetRowIndex());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (base.CheckValid() && CheckData())
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Edit, GetItem(), GetRowIndex());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            SetItem(null, 0);
        }

        ElecTicketRelationAccount GetItem()
        {
            ElecTicketRelationAccount etra = null;
            if (CheckData())
            {
                etra = new ElecTicketRelationAccount();
                etra.Account = tbPersonAccount.Text.Trim();
                etra.Name = tbPersonName.Text.Trim();
                etra.OpenBankName = tbOpenBankName.Text.Trim();
                etra.OpenBankNo = tbOpenBankNo.Text.Trim();//null != tbOpenBankName.Tag ? (tbOpenBankName.Text.Trim().Equals((tbOpenBankName.Tag as CNAP).Name) ? (tbOpenBankName.Tag as CNAP).Code : string.Empty) : string.Empty;
                etra.PersonType = GetRelateType();
                etra.SerialNo = tbSerialNo.Text.Trim();
                etra.Tel_First = tbTel1.Text.Trim();
                etra.Tel_Second = tbTel2.Text.Trim();
                etra.Email_First = tbEmailF.Text.Trim();
                etra.Email_Second = tbEmailS.Text.Trim();
            }
            return etra;
        }

        void SetItem(ElecTicketRelationAccount etra, int rowindex)
        {
            if (null == etra)
            {
                tbRowNo.Text =
                tbPersonAccount.Text =
                tbPersonName.Text =
                tbOpenBankName.Text =
                tbOpenBankNo.Text =
                tbSerialNo.Text =
                tbTel1.Text =
                tbTel2.Text =
                tbEmailF.Text =
                tbEmailS.Text = string.Empty;
                tbOpenBankName.Tag = null;
                SetRelateType(RelatePersonType.Empty);
                this.errorProvider1.Clear();
            }
            else
            {
                tbRowNo.Text = rowindex > 0 ? rowindex.ToString() : string.Empty;
                tbPersonAccount.Text = etra.Account;
                tbPersonName.Text = etra.Name;
                tbOpenBankName.Text = etra.OpenBankName;
                tbOpenBankNo.Text = etra.OpenBankNo;
                tbSerialNo.Text = etra.SerialNo;
                tbTel1.Text = etra.Tel_First;
                tbTel2.Text = etra.Tel_Second;
                tbEmailF.Text = etra.Email_First;
                tbEmailS.Text = etra.Email_Second;
                SetRelateType(etra.PersonType);
            }
        }

        int GetRowIndex()
        {
            int rowindex = int.MaxValue - 1;
            try
            {
                rowindex = int.Parse(tbRowNo.Text.Trim());
                if (rowindex < 1) rowindex = int.MaxValue - 1;
            }
            catch { }
            return rowindex;
        }

        bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckElecTicketPersonAccount(tbPersonAccount, tbPersonAccount.Text.Trim(), lbPersonAccount.Text.Substring(0, lbPersonAccount.Text.Length - 1), 32, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckElecTicketPersonNameOrBankName(tbOpenBankName, tbOpenBankName.Text.Trim(), lbOpenBankName.Text.Substring(0, lbOpenBankName.Text.Length - 1), 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCNAPSNo(tbOpenBankNo, tbOpenBankNo.Text.Trim(), lbOpenBankNo.Text.Substring(0, lbOpenBankNo.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            if (GetRelateType() == RelatePersonType.Empty)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_RelateAccountMsg_Select_PersonType, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return false;
            }
            //rd = DataCheckCenter.CheckRelateSerialNo(tbSerialNo, tbSerialNo.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 10, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeePhone(tbTel1, tbTel1.Text.Trim(), lbTelF.Text.Substring(0, lbTelF.Text.Length - 1), 15, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckEmail(tbEmailF, tbEmailF.Text.Trim(), lbEmailF.Text.Substring(0, lbEmailF.Text.Length - 1), 60, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeePhone(tbTel2, tbTel2.Text.Trim(), lbTelS.Text.Substring(0, lbTelS.Text.Length - 1), 15, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckEmail(tbEmailS, tbEmailS.Text.Trim(), lbEmailS.Text.Substring(0, lbEmailS.Text.Length - 1), 60, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            return rd.Result;
        }

        RelatePersonType GetRelateType()
        {
            RelatePersonType types = RelatePersonType.Empty;
            types = chbExchange.Checked ? (types | RelatePersonType.Exchange) : types;
            types = chbGuarantor.Checked ? (types | RelatePersonType.Guarantor) : types;
            types = chbNoted.Checked ? (types | RelatePersonType.BackNoted) : types;
            types = chbPayee.Checked ? (types | RelatePersonType.Payee) : types;
            types = chbQRigth.Checked ? (types | RelatePersonType.QRigth) : types;
            types = chbRecoursed.Checked ? (types | RelatePersonType.Recoursed) : types;
            types = chbRemittor.Checked ? (types | RelatePersonType.Remittor) : types;
            types = chbStickOn.Checked ? (types | RelatePersonType.StickOn) : types;
            types = chbViewElecTicket.Checked ? (types | RelatePersonType.ViewElecTicket) : types;
            return types;
        }

        void SetRelateType(RelatePersonType types)
        {
            chbExchange.Checked = (types & RelatePersonType.Exchange) == RelatePersonType.Exchange;
            chbGuarantor.Checked = (types & RelatePersonType.Guarantor) == RelatePersonType.Guarantor;
            chbNoted.Checked = (types & RelatePersonType.BackNoted) == RelatePersonType.BackNoted;
            chbPayee.Checked = (types & RelatePersonType.Payee) == RelatePersonType.Payee;
            chbQRigth.Checked = (types & RelatePersonType.QRigth) == RelatePersonType.QRigth;
            chbRecoursed.Checked = (types & RelatePersonType.Recoursed) == RelatePersonType.Recoursed;
            chbRemittor.Checked = (types & RelatePersonType.Remittor) == RelatePersonType.Remittor;
            chbStickOn.Checked = (types & RelatePersonType.StickOn) == RelatePersonType.StickOn;
            chbViewElecTicket.Checked = (types & RelatePersonType.ViewElecTicket) == RelatePersonType.ViewElecTicket;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(tbOpenBankName.Text, tbOpenBankNo.Text);
            frm.IsElecTicket = true;
            frm.IsOpenBank = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbOpenBankName.Text = frm.QueryDialogResult.Name;
                tbOpenBankNo.Text = frm.QueryDialogResult.Code;

                tbOpenBankName.ManualValidate();
                tbOpenBankNo.ManualValidate();
            }
            if (frm != null)
                frm.Close();
        }
    }
}
