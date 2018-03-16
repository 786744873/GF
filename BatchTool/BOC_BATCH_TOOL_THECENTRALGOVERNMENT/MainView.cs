using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Contract;
using CommonClient;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using System.IO;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_TRANSFER_CORPORATION
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_THECENTRALGOVERNMENT", false, 33, "中央财政", AppliableFunctionType.TheCentralGoverment)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }

        bool m_lockState = false;

        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.TheCentralGoverment) return;
                if (e.Command == OperatorCommandType.EditOperatorCallBack)
                    SubmitData(OperatorCommandType.Edit);
            }
        }
        /// <summary>
        /// 新建 打开
        /// </summary>
        /// <param name="command"></param>
        private void OpenOrCreateData(OperatorCommandType command)
        {
            #region
            if (!govermentPanel1.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveGoverment(command, AppliableFunctionType.TheCentralGoverment);
                CommandCenter.ResolveGoverment(OperatorCommandType.Reset, AppliableFunctionType.TheCentralGoverment);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.TheCentralGoverment, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            PayerInfo payer = null;
            if (payerPnl_Ent.CheckData())
            {
                payerPnl_Ent.GetItem();
                payer = payerPnl_Ent.CurrentPayer;
            }

            PayeeInfo payee = null;
            if (payeePnl_E.CheckData())
            {
                payeePnl_E.GetItem();
                payee = payeePnl_E.CurrentPayee;
            }

            GovermentInfo transfer = null;
            if (theCentralGoverment1.CheckData())
            {
                theCentralGoverment1.GetItem();
                transfer = theCentralGoverment1.Goverment;
            }
            if (null == payer) return;
            if (null == payee) return;
            if (null == transfer) return;

            //合并数据
            transfer.PayerAccount = payer.Account;
            transfer.PayeeName = payee.Name;
            transfer.PayeeAccount = payee.Account;
            transfer.PayeeOpenBank = payee.OpenBankName;
            transfer.CNAPSNo = payee.CNAPSNo;
            transfer.AccountBankType = payee.BankType;
            TransferOperation(payer, payee, transfer, rowIndexPanel_Crop.RowIndex, payerPnl_Ent.CanAdd, payeePnl_E.isNew, theCentralGoverment1.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TheCentralGoverment, command);
            payerPnl_Ent.CurrentPayer = null;
            payeePnl_E.CurrentPayee = null;
            theCentralGoverment1.Goverment = null;

        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.TheCentralGoverment, rowIndexPanel_Crop.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveGoverment(command, null, AppliableFunctionType.TheCentralGoverment, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.govermentPanel1.HasData;
                if (flag) this.govermentPanel1.SaveData(true);
                if (!flag)
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoData_Save, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 匹配错误文件
        /// </summary>
        private void MergErrorFileClicked(object sender, EventArgs e)
        {
            if (!govermentPanel1.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.TheCentralGoverment, true);
        }
        private void TransferOperation(PayerInfo payer, PayeeInfo payee, GovermentInfo transfer, int rowindex, bool payerAdd, bool payeeAdd, bool noticeAdd, OperatorCommandType oc, AppliableFunctionType aft, OperatorCommandType batchCommand)
        {
            //转账汇款
            CommandCenter.ResolveGoverment(batchCommand, transfer, aft, rowindex);


            //付款人信息
            if (null != payer)//&& payerAdd)
            {
                payer.CashType = CashType.CNY;
                CommandCenter.ResolvePayer(oc, payer, aft, int.MaxValue);
            }

            //收款人信息
            if (null != payee)//&& payeeAdd)
            {
                CommandCenter.ResolvePayee(oc, payee, aft, int.MaxValue);
            }


            //用途
            if (null != transfer && noticeAdd)
            {
                //if (SystemSettings.Notices.ContainsKey(aft) && SystemSettings.Notices[aft].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                //    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Usege_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                //else
                CommandCenter.ResolveNotice(oc, new NoticeInfo { Content = transfer.Addition }, aft);
            }
        }
        private void dataOperatePanel1_ButtonAddClicked(object sender, EventArgs e)
        {
            SubmitData(OperatorCommandType.Submit);
        }

        private void dataOperatePanel1_ButtonEditClicked(object sender, EventArgs e)
        {
            EditOperatorRequest();
        }

        private void dataOperatePanel1_ButtonDeleteClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.Delete);
        }

        private void dataOperatePanel1_ButtonResetClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.Reset);
        }

        private void fileOperatePanel1_ButtonNewClicked(object sender, EventArgs e)
        {
            OpenOrCreateData(OperatorCommandType.New);
        }

        private void fileOperatePanel1_ButtonOpenClicked(object sender, EventArgs e)
        {
            OpenOrCreateData(OperatorCommandType.Open);
        }

        private void fileOperatePanel1_ButtonSaveClicked(object sender, EventArgs e)
        {
            SaveTXTFile();
        }

        private void fileOperatePanel1_ButtonMergFromFileClicked(object sender, EventArgs e)
        {
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.TheCentralGoverment, true);
        }

        private void dataOperatePanel1_ButtonLockClicked(object sender, EventArgs e)
        {
            m_lockState = !m_lockState;
            CommandCenter.ResolveCommonData(m_lockState ? OperatorCommandType.CommonFieldLockShow : OperatorCommandType.CommonFieldLockHide, new Dictionary<AppliableFunctionType, CommonFieldType>() { { AppliableFunctionType.TheCentralGoverment, CommonFieldType.Empty } });
        }
        private void fileOperatePanel1_ButtonUpClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.DataMoveUp);
        }

        private void fileOperatePanel1_ButtonDownClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.DataMoveDown);
        }
    }
}
