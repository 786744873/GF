using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;

namespace CommonClient
{
    public partial class frmBatchHeader : frmBase
    {
        public frmBatchHeader()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public frmBatchHeader(AppliableFunctionType aft)
            : this()
        {
            m_AppType = aft;
            Init();
        }

        private AppliableFunctionType m_AppType;

        private BatchHeader m_Batch;
        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader Batch
        {
            get { return m_Batch; }
            set { m_Batch = value; }
        }

        void Init()
        {
            if (m_AppType == AppliableFunctionType.AgentExpressIn
                || m_AppType == AppliableFunctionType.AgentExpressOut
                || m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
            {
                batchAgentExpressHeader1.IsFileConvert = true;
                batchAgentExpressHeader1.AppType = m_AppType;
                batchAgentExpressHeader1.DisplayBankType(m_AppType != AppliableFunctionType.AgentExpressOut4Bar);
                batchAgentExpressHeader1.IsFileConvert = true;
                batchAgentExpressHeader1.BringToFront();
            }
            else if (m_AppType == AppliableFunctionType.AgentNormalIn
                || m_AppType == AppliableFunctionType.AgentNormalOut)
            {
                batchAgentNormalHeader1.AppType = m_AppType;
                batchAgentNormalHeader1.IsFileConvert = true;
                batchAgentNormalHeader1.BringToFront();
            }
            else if (m_AppType == AppliableFunctionType.InitiativeAllot)
            {
                batchInitiativeAllotHeader1.IsFileConvert = true;
                batchInitiativeAllotHeader1.BringToFront();
            }
            else { m_Batch = null; this.DialogResult = DialogResult.OK; }
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            if (m_AppType == AppliableFunctionType.AgentExpressIn
                || m_AppType == AppliableFunctionType.AgentExpressOut
                || m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
            {
                if (batchAgentExpressHeader1.CheckData())
                {
                    batchAgentExpressHeader1.GetItem();
                    m_Batch = batchAgentExpressHeader1.BatchInfo;
                }
            }
            else if (m_AppType == AppliableFunctionType.AgentNormalIn
                || m_AppType == AppliableFunctionType.AgentNormalOut)
            {
                if (batchAgentNormalHeader1.CheckData())
                {
                    batchAgentNormalHeader1.GetItem();
                    m_Batch = batchAgentNormalHeader1.BatchInfo;
                    if ((m_Batch.CardType == AgentCardType.OtherBankCard) && CommonInformations.GetFunctionMaximum(m_AppType) > 500)
                    {
                        MessageBoxPrime.Show("他行数据每次最多转换500笔", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (m_AppType == AppliableFunctionType.InitiativeAllot)
            {
                if (batchInitiativeAllotHeader1.CheckData())
                {
                    batchInitiativeAllotHeader1.GetItem();
                    m_Batch = batchInitiativeAllotHeader1.BatchInfo;
                }
            }
            if (null != m_Batch) { this.DialogResult = DialogResult.OK; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
