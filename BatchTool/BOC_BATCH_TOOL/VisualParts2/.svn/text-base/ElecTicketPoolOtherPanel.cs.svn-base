using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketPoolOtherPanel : BaseUc
    {
        public ElecTicketPoolOtherPanel()
        {
            InitializeComponent();
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
            rbInPool2Mortgage.CheckedChanged += new EventHandler(rbInPool2Mortgage_CheckedChanged);
        }

        void rbInPool2Mortgage_CheckedChanged(object sender, EventArgs e)
        {
            rbAutoTip.Enabled = !rbInPool2Mortgage.Checked;
            if (rbInPool2Mortgage.Checked)
                rbAutoReceive.Checked = true;
        }

        void CommandCenter_OnElecTicketPoolEventHandler(object sender, ElecTicketPoolEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler), sender, e); }
            else
            {
                if (AppliableFunctionType.ElecTicketPool != e.OwnerType) return;
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.ElecTicketPool);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
                this.errorProvider1.Clear();
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketPoolOtherPanel), this);
            }
        }

        private ElecTicketType m_ElecTicketType = ElecTicketType.Empty;
        /// <summary>
        /// 所属功能模块
        /// ElecTicketPoolBank-票据池(银承)，ElecTicketPoolBusiness-票据池(商承)
        /// </summary>
        [Browsable(true)]
        public ElecTicketType ElecTicketType
        {
            get { return m_ElecTicketType; }
            set
            {
                m_ElecTicketType = value;
                Init();
            }
        }
        private ElecTicketPool m_elecTicketPool;
        /// <summary>
        /// 票据池信息
        /// </summary>
        public ElecTicketPool ElecTicketPool
        {
            get
            {
                if (CheckData())
                    GetItem();
                return m_elecTicketPool;
            }
        }

        private void Init()
        {
            rbInPool2Mortgage.Visible = m_ElecTicketType == ElecTicketType.AC01;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            if (!string.IsNullOrEmpty(tbPreBackNotedPerson.Text.Trim()))
            {
                rd = DataCheckCenter.Instance.CheckPreBackNotedPerson(tbPreBackNotedPerson, tbPreBackNotedPerson.Text.Trim(), lbPreBackNotedPerson.Text.Substring(0, lbPreBackNotedPerson.Text.Length - 1), 120, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return rd.Result;
        }

        public void GetItem()
        {
            m_elecTicketPool = new ElecTicketPool();
            m_elecTicketPool.PreBackNotedPerson = tbPreBackNotedPerson.Text.Trim();
            m_elecTicketPool.EndDateOperate = rbAutoReceive.Checked ? EndDateOperateType.AutoReceive : EndDateOperateType.AutoTip;
            m_elecTicketPool.BusinessType = rbInPool2Truste.Checked ? ElecTicketPoolBusinessType.InPool2Struste : ElecTicketPoolBusinessType.InPool2Mortgage;
        }

        void SetItem(ElecTicketPool item)
        {
            if (null == item)
            {
                tbPreBackNotedPerson.Text = string.Empty;
                rbAutoReceive.Checked = true;
                rbInPool2Truste.Checked = true;
                this.errorProvider1.Clear();
            }
            else
            {
                tbPreBackNotedPerson.Text = item.PreBackNotedPerson;
                rbAutoReceive.Checked = item.EndDateOperate == EndDateOperateType.AutoReceive;
                rbAutoTip.Checked = !rbAutoReceive.Checked;
                if (m_ElecTicketType == ElecTicketType.AC01)
                {
                    rbInPool2Truste.Checked = item.BusinessType == ElecTicketPoolBusinessType.InPool2Struste;
                    rbInPool2Mortgage.Checked = !rbInPool2Truste.Checked;
                }
                else rbInPool2Truste.Checked = true;
            }
        }
    }
}
