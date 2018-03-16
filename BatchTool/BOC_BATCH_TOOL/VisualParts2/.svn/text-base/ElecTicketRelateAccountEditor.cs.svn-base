using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketRelateAccountEditor : BaseUc
    {
        public ElecTicketRelateAccountEditor()
        {
            InitializeComponent();
            CommandCenter.Instance.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
            if (CheckData())
                CommandCenter.Instance.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, GetItem(), GetRowIndex());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckData())
                CommandCenter.Instance.ResolveElecTicketRelateAccount(OperatorCommandType.Edit, GetItem(), GetRowIndex());
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
            ResultData rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbPersonName, tbPersonName.Text.Trim(), lbPersonName.Text.Substring(0, lbPersonName.Text.Length - 1), 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(tbPersonAccount, tbPersonAccount.Text.Trim(), lbPersonAccount.Text.Substring(0, lbPersonAccount.Text.Length - 1), 32, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbOpenBankName, tbOpenBankName.Text.Trim(), lbOpenBankName.Text.Substring(0, lbOpenBankName.Text.Length - 1), 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCNAPSNo(tbOpenBankNo, tbOpenBankNo.Text.Trim(), lbOpenBankNo.Text.Substring(0, lbOpenBankNo.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (GetRelateType() == RelatePersonType.Empty)
            {
                MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_RelateAccountMsg_Select_PersonType, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            rd = DataCheckCenter.Instance.CheckRelateSerialNo(tbSerialNo, tbSerialNo.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 10, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayeePhone(tbTel1, tbTel1.Text.Trim(), lbTelF.Text.Substring(0, lbTelF.Text.Length - 1), 15, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckEmail(tbEmailF, tbEmailF.Text.Trim(), lbEmailF.Text.Substring(0, lbEmailF.Text.Length - 1), 60, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayeePhone(tbTel2, tbTel2.Text.Trim(), lbTelS.Text.Substring(0, lbTelS.Text.Length - 1), 15, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckEmail(tbEmailS, tbEmailS.Text.Trim(), lbEmailS.Text.Substring(0, lbEmailS.Text.Length - 1), 60, this.errorProvider1);
            if (!rd.Result) return rd.Result;
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
            wndOpenBankQuery frm = new wndOpenBankQuery();
            frm.IsOpenBank = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbOpenBankName.Text = frm.QueryDialogResult.Name;
                tbOpenBankNo.Text = frm.QueryDialogResult.Code;
            }
            if (frm != null)
                frm.Close();
        }
    }
}
