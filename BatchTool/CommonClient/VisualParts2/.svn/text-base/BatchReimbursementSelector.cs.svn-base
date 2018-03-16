using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.Controls;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Entities;
using CommonClient.Contract;
using CommonClient.EnumTypes;

namespace CommonClient.VisualParts
{
    public partial class BatchReimbursementSelector : BaseUc
    {
        public BatchReimbursementSelector()
        {
            InitializeComponent();
            dtpPayDate.MinDate = DateTime.Today.AddYears(-1).AddDays(1);
            dtpPayDate.MaxDate = DateTime.Today;
            SetRegex();
            InitData();
            tbPayAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbReimburseAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbPayAmount.TextChanged += new EventHandler(tbPayAmount_TextChanged);
            tbReimburseAmount.TextChanged += new EventHandler(tbReimburseAmount_TextChanged);
            CommandCenter.OnBatchReimbursementEventHandler += new EventHandler<BatchReimbursementEventArgs>(CommandCenter_OnBatchReimbursementEventHandler);
            CommandCenter.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
        }

        void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler), sender, e); }
            else
            {
                if (e.Command == EnumTypes.OperatorCommandType.Submit || e.Command == EnumTypes.OperatorCommandType.Edit)
                {
                    cmbUsage.Items.Clear();
                    SystemSettings.Notices[EnumTypes.AppliableFunctionType.BatchReimbursement].ForEach(o => cmbUsage.Items.Add(o.Content));
                }
            }
        }

        void tbReimburseAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescR.Text = DataConvertHelper.ConvertA2CN(tbReimburseAmount.Text.Trim());
        }

        void tbPayAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescP.Text = DataConvertHelper.ConvertA2CN(tbPayAmount.Text.Trim());
        }

        void CommandCenter_OnBatchReimbursementEventHandler(object sender, BatchReimbursementEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BatchReimbursementEventArgs>(CommandCenter_OnBatchReimbursementEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != EnumTypes.AppliableFunctionType.BatchReimbursement) return;
                if (e.Command == EnumTypes.OperatorCommandType.View) SetItem(e.BatchReimbursement);
                else if (e.Command == EnumTypes.OperatorCommandType.Reset) SetItem(null);
                this.errorProvider1.Clear();
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!(sender is Controls.TextBoxCanValidate)) return;
            var ctl = sender as Controls.TextBoxCanValidate;
            if (string.IsNullOrEmpty(ctl.Text.Trim())) return;
            bool flag = ctl.Text.Trim().StartsWith("-");
            ResultData rd = DataCheckCenter.CheckCash(ctl, ctl.Text.Trim().Substring(flag ? 1 : 0), ctl.DvLinkedLabel.Text.Substring(0, ctl.DvLinkedLabel.Text.Length - 1), 15, false, this.errorProvider1, true);
            if (!rd.Result) return;
            ctl.Text = DataConvertHelper.FormatCash(ctl.Text.Trim(), false);
        }

        void SetRegex()
        {
            tbCardNo.DvRegCode = "reg57";
            tbCardNo.DvMinLength =
            tbCardNo.DvMaxLength = 16;
            tbCardNo.DvRequired = true;
            tbPayPassword.DvRegCode = "Predefined9";
            tbPayPassword.DvMinLength = 13;
            tbPayPassword.DvMaxLength = 16;
            tbPayPassword.DvFixLength = true;
            tbPayPassword.DvRequired = true;
            cmbUsage.DvRegCode = "reg641";
            cmbUsage.DvMinLength = 1;
            cmbUsage.DvMaxLength = 50;
            cmbUsage.DvRequired = true;
        }

        void InitData()
        {
            linkContent.Visible = (SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501;
            cmbUsage.Items.Clear();
            if (SystemSettings.Notices.ContainsKey(EnumTypes.AppliableFunctionType.BatchReimbursement))
                SystemSettings.Notices[EnumTypes.AppliableFunctionType.BatchReimbursement].ForEach(o => cmbUsage.Items.Add(o.Content));
        }

        BatchReimbursement m_Reimburse;
        /// <summary>
        /// 批量报销
        /// </summary>
        public BatchReimbursement Reimbursement
        {
            get { return m_Reimburse; }
            set { m_Reimburse = value; }
        }

        void SetItem(BatchReimbursement item)
        {
            if (null == item)
            {
                tbCardNo.Text =
                tbPayAmount.Text =
                tbPayPassword.Text =
                tbReimburseAmount.Text =
                cmbUsage.Text = string.Empty;
                dtpPayDate.Value = DateTime.Today;
            }
            else
            {
                tbCardNo.Text = item.CardNo;
                tbPayAmount.Text = item.PayAmount;
                tbPayPassword.Text = item.PayPassword;
                tbReimburseAmount.Text = item.ReimburseAmount;
                cmbUsage.Text = item.Usage;
                try { dtpPayDate.Value = DateTime.Parse(item.PayDateTime); }
                catch { }
            }
        }

        public void GetItem()
        {
            m_Reimburse = new BatchReimbursement();
            m_Reimburse.CardNo = tbCardNo.Text.Trim();
            m_Reimburse.PayAmount = tbPayAmount.Text.Trim().Replace(",", "");
            DateTime dt = dtpPayDate.Value;
            m_Reimburse.PayDateTime = dt.Year.ToString() + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Day.ToString().PadLeft(2, '0');
            m_Reimburse.PayPassword = tbPayPassword.Text.Trim();
            m_Reimburse.ReimburseAmount = tbReimburseAmount.Text.Trim().Replace(",", "");
            m_Reimburse.Usage = cmbUsage.Text.Trim();
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd.Result = base.CheckValid();
            rd.Result = rd.Result & DataCheckCenter.CheckCash(tbPayAmount, tbPayAmount.Text.Trim(), lbPayAmount.Text.Substring(0, lbPayAmount.Text.Length - 1), 15, false, this.errorProvider1).Result;
            rd.Result = rd.Result & DataCheckCenter.CheckCash(tbReimburseAmount, tbReimburseAmount.Text.Trim(), lbReimburseAmount.Text.Substring(0, lbReimburseAmount.Text.Length - 1), 15, false, this.errorProvider1).Result;
            return rd.Result;
        }

        private void linkConent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleWorkSpaceLoader.BroadcastApplicationBringToFront("BOC_BATCH_TOOL_SETTINGS", FunctionInSettingType.AddtionMg, AppliableFunctionType.BatchReimbursement);
        }

    }
}
