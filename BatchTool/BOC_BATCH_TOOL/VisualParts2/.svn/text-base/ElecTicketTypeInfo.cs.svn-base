using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketTypeInfo : BaseUc
    {
        public ElecTicketTypeInfo()
        {
            InitializeComponent();

            Init();

            tbRemitAmount.LostFocus += new EventHandler(tbRemitAmount_LostFocus);
            cmbElecTicketType.SelectedIndexChanged += new EventHandler(cmbElecTicketType_SelectedIndexChanged);
            dtpRemitDate.ValueChanged += new EventHandler(dtpRemitDate_ValueChanged);
            CommandCenter.Instance.OnElecTicketRemitEvenHnadler += new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketTypeInfo), this);

                cmbElecTicketType.Items.Clear();
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.ElecTicketTypeList)
                {
                    if (item == ElecTicketType.Empty) continue;
                    cmbElecTicketType.Items.Add(EnumNameHelper<ElecTicketType>.GetEnumDescription(item));
                }
            }
        }

        void dtpRemitDate_ValueChanged(object sender, EventArgs e)
        {
            dtpElecTicketEndDate.MinDate = dtpRemitDate.Value.AddDays(1);
            dtpElecTicketEndDate.MaxDate = dtpRemitDate.Value.AddYears(1);
            dtpElecTicketEndDate.Value = dtpElecTicketEndDate.MaxDate;
        }

        void cmbElecTicketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElecTicketType.SelectedIndex < 0) return;
            ElecTicketType ett = (cmbElecTicketType.Tag as List<ElecTicketType>)[cmbElecTicketType.SelectedIndex];
            CommandCenter.Instance.ResolveElecTicketTypeChanged(OperatorCommandType.TicketTypeChanged, m_appType, ett, RelatePersonType.Exchange);
        }

        void Init()
        {
            dtpRemitDate.MinDate = DateTime.Today;
            dtpRemitDate.MaxDate = DateTime.Today.AddMonths(3);
            dtpElecTicketEndDate.MinDate = dtpRemitDate.Value.AddDays(1);
            dtpElecTicketEndDate.MaxDate = dtpRemitDate.Value.AddYears(1);
            dtpElecTicketEndDate.Value = dtpElecTicketEndDate.MaxDate;

            foreach (var item in PrequisiteDataProvideNode.InitialProvide.ElecTicketTypeList)
            {
                if (item == ElecTicketType.Empty) continue;
                cmbElecTicketType.Items.Add(EnumNameHelper<ElecTicketType>.GetEnumDescription(item));
            }
            cmbElecTicketType.Tag = PrequisiteDataProvideNode.InitialProvide.ElecTicketTypeList.FindAll(o => o != ElecTicketType.Empty);
            cmbElecTicketType.SelectedIndex = 0;
        }

        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private ElecTicketRemit m_Remit;
        /// <summary>
        /// 票据信息
        /// </summary>
        [Browsable(false)]
        public ElecTicketRemit Remit
        {
            get { return m_Remit; }
            set { m_Remit = value; }
        }

        void CommandCenter_OnElecTicketRemitEvenHnadler(object sender, ElecTicketRemitEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler), sender, e); }
            else
            {
                if (e.OwnerType != m_appType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                { SetItem(e.ElecTicketRemit); }
                else if (e.Command == OperatorCommandType.Reset)
                { SetItem(null); }
                else return;
            }
        }

        void tbRemitAmount_LostFocus(object sender, EventArgs e)
        {
            FormatCash();
        }

        private void FormatCash()
        {
            if (!string.IsNullOrEmpty(tbRemitAmount.Text))
            {
                tbRemitAmount.Text = DataConvertHelper.Instance.FormatCash(tbRemitAmount.Text.Trim(), false);
            }
        }

        void SetItem(ElecTicketRemit item)
        {
            if (null == item)
            {
                if (cmbElecTicketType.Items.Count > 0)
                    cmbElecTicketType.SelectedIndex = 0;
                cmbElecTicketType.Text = string.Empty;
                tbRemitAmount.Text = string.Empty;
                dtpRemitDate.Value = DateTime.Today;
                dtpElecTicketEndDate.MinDate = dtpRemitDate.Value.AddDays(1);
                dtpElecTicketEndDate.MaxDate = dtpRemitDate.Value.AddYears(1);
                dtpElecTicketEndDate.Value = dtpElecTicketEndDate.MaxDate;
                this.errorProvider1.Clear();
            }
            else
            {
                try
                {
                    cmbElecTicketType.SelectedIndex = (cmbElecTicketType.Tag as List<ElecTicketType>).FindIndex(o => o == item.TicketType);
                    tbRemitAmount.Text = item.Amount.ToString();

                    if (!string.IsNullOrEmpty(item.RemitDate))
                    {
                        if (DateTime.Parse(item.RemitDate).Date > dtpRemitDate.MaxDate.Date) dtpRemitDate.Value = dtpRemitDate.MaxDate;
                        else if (DateTime.Parse(item.RemitDate).Date < dtpRemitDate.MinDate.Date) dtpRemitDate.Value = dtpRemitDate.MinDate;
                        else dtpRemitDate.Value = DateTime.Parse(item.RemitDate);
                    }
                    else dtpRemitDate.Value = DateTime.Today;

                    dtpElecTicketEndDate.MinDate = dtpRemitDate.Value.AddDays(1);
                    dtpElecTicketEndDate.MaxDate = dtpRemitDate.Value.AddYears(1);

                    if (!string.IsNullOrEmpty(item.EndDate))
                    {
                        if (DateTime.Parse(item.EndDate).Date > dtpElecTicketEndDate.MaxDate.Date) dtpElecTicketEndDate.Value = dtpElecTicketEndDate.MaxDate;
                        else if (DateTime.Parse(item.EndDate).Date < dtpElecTicketEndDate.MinDate.Date) dtpElecTicketEndDate.Value = dtpElecTicketEndDate.MinDate;
                        else dtpElecTicketEndDate.Value = DateTime.Parse(item.EndDate);
                    }
                    else dtpElecTicketEndDate.Value = dtpRemitDate.Value.AddDays(1);
                }
                catch { }
            }
        }

        public void GetItem()
        {
            m_Remit = new ElecTicketRemit();
            if (CheckData())
            {
                try
                {
                    m_Remit.TicketType = (cmbElecTicketType.Tag as List<ElecTicketType>)[cmbElecTicketType.SelectedIndex];
                    m_Remit.Amount = tbRemitAmount.Text.Trim().Replace(",", "");
                    DateTime dtr = dtpRemitDate.Value;
                    m_Remit.RemitDate = dtr.Year.ToString().PadLeft(4, '0') + "/" + dtr.Month.ToString().PadLeft(2, '0') + "/" + dtr.Day.ToString().PadLeft(2, '0');
                    DateTime dte = dtpElecTicketEndDate.Value;
                    m_Remit.EndDate = dte.Year.ToString().PadLeft(4, '0') + "/" + dte.Month.ToString().PadLeft(2, '0') + "/" + dte.Day.ToString().PadLeft(2, '0');
                }
                catch { }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            if (cmbElecTicketType.SelectedIndex < 0) { MessageBoxExHelper.Instance.Show("请选择票据类型", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            rd = DataCheckCenter.Instance.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 18, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            return rd.Result;
        }
    }
}
