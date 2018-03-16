using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;
using System.IO;

namespace CommonClient.SysCoach
{
    /// <summary>
    /// 命令操作中心类
    /// </summary>
    public static class CommandCenter
    {
        #region 公共事件
        /// <summary>
        /// 收款人事件
        /// </summary>
        public static event EventHandler<PayeeEventArgs> OnPayeeInfoEventHandler
        {
            add
            {
                m_PayeeInfoEvent += value;
            }
            remove
            {
                m_PayeeInfoEvent -= value;
            }
        }
        /// <summary>
        /// 付款人事件
        /// </summary>
        public static event EventHandler<PayerEventArgs> OnPayerInfoEventHandler
        {
            add
            {
                m_PayerInfoEvent += value;
            }
            remove
            {
                m_PayerInfoEvent -= value;
                if (m_PayeeInfoEvent != null)
                { }
            }
        }
        /// <summary>
        /// 转账汇款事件
        /// </summary>
        public static event EventHandler<TransferEventArgs> OnTransferAccountEventHandler
        {
            add { m_TransferEvent += value; }
            remove { m_TransferEvent -= value; }
        }
        /// <summary>
        /// 功能设置事件
        /// </summary>
        public static event EventHandler<AppliableEventArgs> OnAppliableEventHandler
        {
            add { m_AppliableEvent += value; }
            remove { m_AppliableEvent -= value; }
        }
        /// <summary>
        /// 附言及用途事件
        /// </summary>
        public static event EventHandler<NoticeEventArgs> OnNoticeEventHandler
        {
            add { m_NoticeEvent += value; }
            remove { m_NoticeEvent -= value; }
        }
        /// <summary>
        /// 快捷代收、代发事件
        /// </summary>
        public static event EventHandler<AgentExpressEventArgs> OnAgentExpressEventHandler
        {
            add { m_AgentExpressEvent += value; }
            remove { m_AgentExpressEvent -= value; }
        }
        /// <summary>
        /// 普通代收、代发事件
        /// </summary>
        public static event EventHandler<AgentNormalEventArgs> OnAgentNormalEventHandler
        {
            add { m_AgentNormalEvent += value; }
            remove { m_AgentNormalEvent -= value; }
        }
        /// <summary>
        /// 操作数据行事件
        /// </summary>
        public static event EventHandler<RowIndexEventArgs> OnRwoIndexEventHandler
        {
            add { m_RowIndexEvent += value; }
            remove { m_RowIndexEvent -= value; }
        }
        /// <summary>
        /// 操作公共数据事件
        /// </summary>
        public static event EventHandler<CommonDataEventArgs> OnCommonDataEventHandler
        {
            add { m_CommonDataEvent += value; }
            remove { m_CommonDataEvent -= value; }
        }
        /// <summary>
        /// 文件加密事件
        /// </summary>
        public static event EventHandler<EncryptionEventArgs> OnEncryptionEventHandler
        {
            add { m_EncryptionEvent += value; }
            remove { m_EncryptionEvent -= value; }
        }
        /// <summary>
        /// 批量参数事件
        /// </summary>
        public static event EventHandler<FieldMappingEventArgs> OnFieldMappingEventHandler
        {
            add { m_FieldMappingEvent += value; }
            remove { m_FieldMappingEvent -= value; }
        }
        /// <summary>
        /// 功能模块控制事件
        /// </summary>
        public static event EventHandler<ShowPanelEventArgs> OnShowPanelEventHandler
        {
            add { m_ShowPanelEvent += value; }
            remove { m_ShowPanelEvent -= value; }
        }
        /// <summary>
        /// 用途变化事件
        /// </summary>
        public static event EventHandler<UseTypeChangedEventArgs> OnUseTypeChangedEventHandler
        {
            add { m_UseTypeChangedEvent += value; }
            remove { m_UseTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 代发卡类型变化事件
        /// </summary>
        public static event EventHandler<CardTypeChangedEventArgs> OnCardTypeChangedEventHandler
        {
            add { m_CardTypeChangedEvent += value; }
            remove { m_CardTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 菜单移动控制事件
        /// </summary>
        //public static event EventHandler<MoveMenuEventArgs> OnMoveMenuEventHandler
        //{
        //    add { m_MoveMenuEvent += value; }
        //    remove { m_MoveMenuEvent -= value; }
        //}
        /// <summary>
        /// 数据查询事件
        /// </summary>
        public static event EventHandler<QueryByRowIndexEventArgs> OnQueryByRowIndexEventHandler
        {
            add { m_QueryByRowIndexEvent += value; }
            remove { m_QueryByRowIndexEvent -= value; }
        }
        /// <summary>
        /// 银行类型变更事件
        /// </summary>
        public static event EventHandler<BankTypeChangedEventArgs> OnBankTypeChangedEventHandler
        {
            add { m_BankTypeChangedEvent += value; }
            remove { m_BankTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 编辑请求事件
        /// </summary>
        public static event EventHandler<EditEventArgs> OnEditEventHandler
        {
            add { m_EditEvent += value; }
            remove { m_EditEvent -= value; }
        }
        /// <summary>
        /// 批量出票事件
        /// </summary>
        public static event EventHandler<ElecTicketRemitEventArgs> OnElecTicketRemitEvenHnadler
        {
            add { m_ElecTicketRemitEvent += value; }
            remove { m_ElecTicketRemitEvent -= value; }
        }
        /// <summary>
        /// 关系人维护事件
        /// </summary>
        public static event EventHandler<ElecTicketRelateAccountEventArgs> OnElecTicketRelateAccountEventHandler
        {
            add { m_ElecTicketRelateAccountEvent += value; }
            remove { m_ElecTicketRelateAccountEvent -= value; }
        }
        /// <summary>
        /// 票据类型变更事件
        /// </summary>
        public static event EventHandler<ElecTicketTypeChangedEventArgs> OnElecTicketTypeChangedEventHandler
        {
            add { m_ElecTicketTypeChangeEvent += value; }
            remove { m_ElecTicketTypeChangeEvent -= value; }
        }
        /// <summary>
        /// 批量电票自动提示承兑事件
        /// </summary>
        public static event EventHandler<ElecTicketAutoTipExchangeEventArgs> OnElecTicketAutoTipExchangeEventHandler
        {
            add { m_ElecTicketAutoTipExchangeEvent += value; }
            remove { m_ElecTicketAutoTipExchangeEvent -= value; }
        }
        /// <summary>
        /// 批量电票背书事件
        /// </summary>
        public static event EventHandler<ElecTicketBackNoteEventArgs> OnElecTicketBackNoteEventHandler
        {
            add { m_ElecTicketBackNoteEvent += value; }
            remove { m_ElecTicketBackNoteEvent -= value; }
        }
        /// <summary>
        /// 批量电票贴现事件
        /// </summary>
        public static event EventHandler<ElecTicketPayMoneyEventArgs> OnElecTicketPayMoneyEventHandler
        {
            add { m_ElecTicketPayMoneyEvent += value; }
            remove { m_ElecTicketPayMoneyEvent -= value; }
        }
        /// <summary>
        /// 批量票据池事件
        /// </summary>
        public static event EventHandler<ElecTicketPoolEventArgs> OnElecTicketPoolEventHandler
        {
            add { m_ElecTicketPoolEvent += value; }
            remove { m_ElecTicketPoolEvent -= value; }
        }
        /// <summary>
        /// 批量国际结算事件
        /// </summary>
        public static event EventHandler<TransferGlobalEventArgs> OnTransferGlobalEventHandler
        {
            add { m_TransferGlobalEvent += value; }
            remove { m_TransferGlobalEvent -= value; }
        }
        /// <summary>
        /// 国际结算币种类型变更事件
        /// </summary>
        public static event EventHandler<CashTypeChangedEventArgs> OnCashTypeChangedEventHandler
        {
            add { m_CashTypeChangedEvent += value; }
            remove { m_CashTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 国际结算收款人事件
        /// </summary>
        public static event EventHandler<Payee4TransferGlobalEventArgs> OnPayeeInfo4TransferGlobalEventHandler
        {
            add { m_Payee4TransferGlobalEvent += value; }
            remove { m_Payee4TransferGlobalEvent -= value; }
        }
        /// <summary>
        /// 供应链-经销商融资申请事件
        /// </summary>
        public static event EventHandler<SpplyFinancingApplyEventArgs> OnSpplyFinancingApplyEventHandler
        {
            add { m_SpplyFinancingApplyEvent += value; }
            remove { m_SpplyFinancingApplyEvent -= value; }
        }
        /// <summary>
        /// 供应链-应收账款卖/卖方发票事件
        /// </summary>
        public static event EventHandler<SpplyFinancingBillEventArgs> OnSpplyFinancingBillEventHandler
        {
            add { m_SpplyFinancingBillEvent += value; }
            remove { m_SpplyFinancingBillEvent -= value; }
        }
        /// <summary>
        /// 供应链-应收账款卖/卖方收/付款事件
        /// </summary>
        public static event EventHandler<SpplyFinancingPayOrReceiptEventArgs> OnSpplyFinancingPayOrReceiptEventHandler
        {
            add { m_SpplyFinancingPayOrReceiptEvent += value; }
            remove { m_SpplyFinancingPayOrReceiptEvent -= value; }
        }
        /// <summary>
        /// 供应链-应收账款卖/卖方订单事件
        /// </summary>
        public static event EventHandler<SpplyFinancingOrderEventArgs> OnSpplyFinancingOrderEventHandler
        {
            add { m_SpplyFinancingOrderEvent += value; }
            remove { m_SpplyFinancingOrderEvent -= value; }
        }
        /// <summary>
        /// 快捷代收付款人事件
        /// </summary>
        public static event EventHandler<PayeeEventArgs> OnAgentExpressPayerEventHandler
        {
            add { m_AgentExpressPayerEvent += value; }
            remove { m_AgentExpressPayerEvent -= value; }
        }
        /// <summary>
        /// 主动调拨事件
        /// </summary>
        public static event EventHandler<InitiativeAllotEventArgs> OnInitiativeAllotEventHandler
        {
            add { m_InitiativeAllotEvent += value; }
            remove { m_InitiativeAllotEvent -= value; }
        }
        /// <summary>
        /// 主动调拨账户事件
        /// </summary>
        public static event EventHandler<InitiativeAllotAccountEventArgs> OnInitiativeAllotAccountEventHandler
        {
            add { m_InitiativeAllotAccountEvent += value; }
            remove { m_InitiativeAllotAccountEvent -= value; }
        }
        /// <summary>
        /// 多语言变更事件
        /// </summary>
        public static event EventHandler<LanguageChangedEventArgs> OnLanguageChangedEventHandler
        {
            add { m_LanguageChangedEvent += value; }
            remove { m_LanguageChangedEvent -= value; }
        }
        /// <summary>
        /// 设置中的操作事件
        /// 用于全选、反选、批量删除
        /// </summary>
        public static event EventHandler<SettingsOperateEventArgs> OnSettingsOperateEventHandler
        {
            add { m_SettingsOperateEvent += value; }
            remove { m_SettingsOperateEvent -= value; }
        }
        /// <summary>
        /// 快捷代发中批用途变更事件
        /// </summary>
        public static event EventHandler<AgentExpressPurposeEventArgs> OnAgentExpressPurposeEventHandler
        {
            add { m_AgentExpressPurposeEvent += value; }
            remove { m_AgentExpressPurposeEvent -= value; }
        }
        /// <summary>
        /// 贴入人银行号变更事件
        /// </summary>
        public static event EventHandler<StickOnBankInfoEventArgs> OnStickOnBankInfoEventHandler
        {
            add { m_StickOnBankInfoEvent += value; }
            remove { m_StickOnBankInfoEvent -= value; }
        }
        /// <summary>
        /// 人民币统一支付事件
        /// </summary>
        public static event EventHandler<UnitivePaymentRMBEventArgs> OnUnitivePaymentRMBEventHandler
        {
            add { m_UnitivePaymentRMBEvent += value; }
            remove { m_UnitivePaymentRMBEvent -= value; }
        }
        /// <summary>
        /// 外币统一支付事件
        /// </summary>
        public static event EventHandler<UnitivePaymentFCEventArgs> OnUnitivePaymentFCEventHandler
        {
            add { m_UnitivePaymentFCEvent += value; }
            remove { m_UnitivePaymentFCEvent -= value; }
        }
        /// <summary>
        /// 外币统一支付收款人账号类型变更事件
        /// </summary>
        public static event EventHandler<OverCountryPayeeAccountTypeEventArgs> OnOverCountryPayeeAccountTypeEventHandler
        {
            add { m_OverCountryPayeeAccountTypeEvent += value; }
            remove { m_OverCountryPayeeAccountTypeEvent -= value; }
        }
        /// <summary>
        /// 内部账户转账事件
        /// </summary>
        public static event EventHandler<VirtualAccountEventArgs> OnVirtualAccountEventHandler
        {
            add { m_VirtualAccountEvent += value; }
            remove { m_VirtualAccountEvent -= value; }
        }
        /// <summary>
        /// 内部转账处理事件
        /// </summary>
        public static event EventHandler<VirtualAccountAllotEventArgs> OnVirtualAccountAllotEventHandler
        {
            add { m_VirtualAccountAllotEvent += value; }
            remove { m_VirtualAccountAllotEvent -= value; }
        }
        /// <summary>
        /// 待处理转账处理事件
        /// </summary>
        public static event EventHandler<PreproccessTransferEventArgs> OnPreproccessTransferEventHandler
        {
            add { m_PreproccessTransferEvent += value; }
            remove { m_PreproccessTransferEvent -= value; }
        }
        /// <summary>
        /// 财政公务卡-批量报销处理事件
        /// </summary>
        public static event EventHandler<BatchReimbursementEventArgs> OnBatchReimbursementEventHandler
        {
            add { m_BatchReimbursementEvent += value; }
            remove { m_BatchReimbursementEvent -= value; }
        }
        /// <summary>
        /// 中央财政授权支付批量委托
        /// </summary>
        public static event EventHandler<GovermentEventArgs> OnGovermentEventHandler
        {
            add { m_GovermentEvent += value; }
            remove { m_GovermentEvent -= value; }
        }
        #endregion

        #region 私有事件
        private static event EventHandler<PayerEventArgs> m_PayerInfoEvent;
        private static event EventHandler<PayeeEventArgs> m_PayeeInfoEvent;
        private static event EventHandler<TransferEventArgs> m_TransferEvent;
        private static event EventHandler<AppliableEventArgs> m_AppliableEvent;
        private static event EventHandler<NoticeEventArgs> m_NoticeEvent;
        private static event EventHandler<AgentExpressEventArgs> m_AgentExpressEvent;
        private static event EventHandler<AgentNormalEventArgs> m_AgentNormalEvent;
        private static event EventHandler<RowIndexEventArgs> m_RowIndexEvent;
        private static event EventHandler<CommonDataEventArgs> m_CommonDataEvent;
        private static event EventHandler<EncryptionEventArgs> m_EncryptionEvent;
        private static event EventHandler<FieldMappingEventArgs> m_FieldMappingEvent;
        private static event EventHandler<ShowPanelEventArgs> m_ShowPanelEvent;
        private static event EventHandler<UseTypeChangedEventArgs> m_UseTypeChangedEvent;
        private static event EventHandler<CardTypeChangedEventArgs> m_CardTypeChangedEvent;
        //private static event EventHandler<MoveMenuEventArgs> m_MoveMenuEvent;
        private static event EventHandler<QueryByRowIndexEventArgs> m_QueryByRowIndexEvent;
        private static event EventHandler<BankTypeChangedEventArgs> m_BankTypeChangedEvent;
        private static event EventHandler<EditEventArgs> m_EditEvent;
        private static event EventHandler<ElecTicketRemitEventArgs> m_ElecTicketRemitEvent;
        private static event EventHandler<ElecTicketRelateAccountEventArgs> m_ElecTicketRelateAccountEvent;
        private static event EventHandler<ElecTicketTypeChangedEventArgs> m_ElecTicketTypeChangeEvent;
        private static event EventHandler<ElecTicketAutoTipExchangeEventArgs> m_ElecTicketAutoTipExchangeEvent;
        private static event EventHandler<ElecTicketBackNoteEventArgs> m_ElecTicketBackNoteEvent;
        private static event EventHandler<ElecTicketPayMoneyEventArgs> m_ElecTicketPayMoneyEvent;
        private static event EventHandler<ElecTicketPoolEventArgs> m_ElecTicketPoolEvent;
        private static event EventHandler<TransferGlobalEventArgs> m_TransferGlobalEvent;
        private static event EventHandler<CashTypeChangedEventArgs> m_CashTypeChangedEvent;
        private static event EventHandler<Payee4TransferGlobalEventArgs> m_Payee4TransferGlobalEvent;
        private static event EventHandler<SpplyFinancingApplyEventArgs> m_SpplyFinancingApplyEvent;
        private static event EventHandler<SpplyFinancingBillEventArgs> m_SpplyFinancingBillEvent;
        private static event EventHandler<SpplyFinancingPayOrReceiptEventArgs> m_SpplyFinancingPayOrReceiptEvent;
        private static event EventHandler<SpplyFinancingOrderEventArgs> m_SpplyFinancingOrderEvent;
        private static event EventHandler<PayeeEventArgs> m_AgentExpressPayerEvent;
        private static event EventHandler<InitiativeAllotEventArgs> m_InitiativeAllotEvent;
        private static event EventHandler<InitiativeAllotAccountEventArgs> m_InitiativeAllotAccountEvent;
        private static event EventHandler<LanguageChangedEventArgs> m_LanguageChangedEvent;
        private static event EventHandler<SettingsOperateEventArgs> m_SettingsOperateEvent;
        private static event EventHandler<AgentExpressPurposeEventArgs> m_AgentExpressPurposeEvent;
        private static event EventHandler<StickOnBankInfoEventArgs> m_StickOnBankInfoEvent;
        private static event EventHandler<UnitivePaymentRMBEventArgs> m_UnitivePaymentRMBEvent;
        private static event EventHandler<UnitivePaymentFCEventArgs> m_UnitivePaymentFCEvent;
        private static event EventHandler<OverCountryPayeeAccountTypeEventArgs> m_OverCountryPayeeAccountTypeEvent;
        private static event EventHandler<VirtualAccountEventArgs> m_VirtualAccountEvent;
        private static event EventHandler<VirtualAccountAllotEventArgs> m_VirtualAccountAllotEvent;
        private static event EventHandler<PreproccessTransferEventArgs> m_PreproccessTransferEvent;
        private static event EventHandler<BatchReimbursementEventArgs> m_BatchReimbursementEvent;
        private static event EventHandler<GovermentEventArgs> m_GovermentEvent;
        #endregion

        #region 处理业务方法
        /// <summary>
        /// 处理收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolvePayee(OperatorCommandType ct, PayeeInfo payee, AppliableFunctionType aft, int rowindex)
        {
            if (m_PayeeInfoEvent != null)
                m_PayeeInfoEvent(null, new PayeeEventArgs { Command = ct, PayeeInfo = payee.Clone() as PayeeInfo, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolvePayee(OperatorCommandType ct, List<PayeeInfo> payeeList, AppliableFunctionType aft)
        {
            if (m_PayeeInfoEvent != null)
                m_PayeeInfoEvent(null, new PayeeEventArgs { Command = ct, PayeeInfo = null, PayeeList = payeeList, OwnerType = aft });
        }
        /// <summary>
        /// 处理快捷代收付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolveAgentExpressPayer(OperatorCommandType ct, PayeeInfo payee, AppliableFunctionType aft, int rowindex)
        {
            if (m_AgentExpressPayerEvent != null)
                m_AgentExpressPayerEvent(null, new PayeeEventArgs { Command = ct, PayeeInfo = payee.Clone() as PayeeInfo, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理快捷代收付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolveAgentExpressPayer(OperatorCommandType ct, List<PayeeInfo> payeeList, AppliableFunctionType aft)
        {
            if (m_AgentExpressPayerEvent != null)
                m_AgentExpressPayerEvent(null, new PayeeEventArgs { Command = ct, PayeeInfo = null, PayeeList = payeeList, OwnerType = aft });
        }
        /// <summary>
        /// 处理付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payer">付款人信息</param>
        public static void ResolvePayer(OperatorCommandType ct, List<PayerInfo> payerList, AppliableFunctionType aft)
        {
            if (m_PayerInfoEvent != null)
                m_PayerInfoEvent(null, new PayerEventArgs { Command = ct, PayerInfo = null, PayerList = payerList, OwnerType = aft });
        }
        /// <summary>
        /// 处理付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payer">付款人信息</param>
        public static void ResolvePayer(OperatorCommandType ct, PayerInfo payer, AppliableFunctionType aft, int rowindex)
        {
            if (m_PayerInfoEvent != null)
                m_PayerInfoEvent(null, new PayerEventArgs { Command = ct, PayerInfo = payer, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理转账汇款业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public static void ResolveTransferAccount(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveTransferAccount(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理转账汇款业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public static void ResolveTransferAccount(OperatorCommandType ct, TransferAccount transfer, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_TransferEvent)
                m_TransferEvent(null, new TransferEventArgs { Command = ct, TransferAccount = transfer, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理转账汇款业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public static void ResolveTransferAccount(OperatorCommandType ct, List<TransferAccount> transferList, AppliableFunctionType aft)
        {
            if (null != m_TransferEvent)
                m_TransferEvent(null, new TransferEventArgs { Command = ct, TransferAccountList = transferList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理功能可视化业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="type">功能可视化信息</param>
        public static void ResolveAppliableFunction(OperatorCommandType ct, AppliableFunctionType type, AppliableFunctionType typeBar)
        {
            if (null != m_AppliableEvent)
                m_AppliableEvent(null, new AppliableEventArgs { Command = ct, AppVisiable = type, AppVisiableBar = typeBar });
        }
        /// <summary>
        /// 处理附言和用途业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="notice">附言及用途信息</param>
        public static void ResolveNotice(OperatorCommandType ct, NoticeInfo notice, AppliableFunctionType aft)
        {
            if (null != m_NoticeEvent)
                m_NoticeEvent(null, new NoticeEventArgs { Command = ct, Notice = notice, OwnerType = aft });
        }
        /// <summary>
        /// 处理附言和用途业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="notice">附言及用途信息</param>
        public static void ResolveNotice(OperatorCommandType ct, List<NoticeInfo> list, AppliableFunctionType aft)
        {
            if (null != m_NoticeEvent)
                m_NoticeEvent(null, new NoticeEventArgs { Command = ct, Notice = null, NoticeList = list, OwnerType = aft });
        }
        /// <summary>
        /// 处理快捷代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveAgentExpress(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveAgentExpress(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理快捷代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveAgentExpress(OperatorCommandType ct, AgentExpress ae, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_AgentExpressEvent)
                m_AgentExpressEvent(null, new AgentExpressEventArgs { AgentExpress = ae, Command = ct, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理快捷代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveAgentExpress(OperatorCommandType ct, List<AgentExpress> aelist, BatchHeader batch, AppliableFunctionType aft)
        {
            if (null != m_AgentExpressEvent)
                m_AgentExpressEvent(null, new AgentExpressEventArgs { AgentExpressList = aelist, BatchInfo = batch, Command = ct, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理普通代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveAgentNormal(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveAgentNormal(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理普通代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveAgentNormal(OperatorCommandType ct, AgentNormal ae, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_AgentNormalEvent)
                m_AgentNormalEvent(null, new AgentNormalEventArgs { AgentNormal = ae, Command = ct, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理普通代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveAgentNormal(OperatorCommandType ct, List<AgentNormal> aeList, BatchHeader batch, AppliableFunctionType aft)
        {
            if (null != m_AgentNormalEvent)
                m_AgentNormalEvent(null, new AgentNormalEventArgs { AgentNormalList = aeList, BatchInfo = batch, Command = ct, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理主动调拨业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveInitiativeAllot(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveInitiativeAllot(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理主动调拨业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveInitiativeAllot(OperatorCommandType ct, InitiativeAllot ae, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_InitiativeAllotEvent)
                m_InitiativeAllotEvent(null, new InitiativeAllotEventArgs { InitiativeAllot = ae, Command = ct, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理主动调拨业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public static void ResolveInitiativeAllot(OperatorCommandType ct, List<InitiativeAllot> aelist, BatchHeader batch, AppliableFunctionType aft)
        {
            if (null != m_InitiativeAllotEvent)
                m_InitiativeAllotEvent(null, new InitiativeAllotEventArgs { InitiativeAllotList = aelist, BatchInfo = batch, Command = ct, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理操作数据航业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="rowindex"></param>
        /// <param name="aft"></param>
        public static void ResolveRowIndex(OperatorCommandType ct, int rowindex, AppliableFunctionType aft)
        {
            if (null != m_RowIndexEvent)
                m_RowIndexEvent(null, new RowIndexEventArgs { RowIndex = rowindex, AppType = aft, Command = ct });
        }
        /// <summary>
        /// 处理公共数据业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="cft">公共数据信息</param>
        public static void ResolveCommonData(OperatorCommandType ct, Dictionary<AppliableFunctionType, CommonFieldType> cftList)
        {
            if (null != m_CommonDataEvent)
                m_CommonDataEvent(null, new CommonDataEventArgs { Command = ct, CommonFields = cftList });
        }
        /// <summary>
        /// 处理快捷代发文件加密业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="isSetPwd">是否设置密码</param>
        /// <param name="password">加密密码</param>
        public static void ResolveEncryption(OperatorCommandType ct, bool isSetPwd, string password, AppliableFunctionType aft)
        {
            if (null != m_EncryptionEvent)
                m_EncryptionEvent(null, new EncryptionEventArgs { IsSetPassword = isSetPwd, Password = password, Command = ct, AppType = aft });
        }
        /// <summary>
        /// 处理批量设置业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="aft">功能模块</param>
        /// <param name="mrs">设置信息</param>
        public static void ResolveFieldMapping(OperatorCommandType ct, AppliableFunctionType aft, MappingsRelationSettings mrs, FunctionInSettingType batchAppType, FunctionInSettingType fst)
        {
            if (null != m_FieldMappingEvent)
                m_FieldMappingEvent(null, new FieldMappingEventArgs { AppType = aft, Command = ct, Mappings = mrs, BatchAppType = batchAppType, FunType = fst });
        }
        /// <summary>
        /// 处理打开中行格式文件业务
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        public static ResultData ResolveOpenFile(string filepath, OperatorCommandType command, AppliableFunctionType aft, bool isBOC, string pwd)
        {
            ResultData rd = new ResultData() { Result = true };
            bool isPWDFile = false;
            if (filepath.ToLower().EndsWith(".sef"))
            {
                isPWDFile = true;
                try
                {
                    filepath = MatchFile.FileDataPasswordHelper.MakeFromPWD(filepath, SystemSettings.ShortProxyOutPassword);
                    if (!System.IO.File.Exists(filepath)) throw new Exception();
                }
                catch { rd = new ResultData { Result = false, Message = "解密失败" }; }
            }
            else if (filepath.ToLower().EndsWith(".dat"))
            {
                isPWDFile = true;
                string targetPath = DataConvertHelper.FormatFileName(filepath, ".bar");
                try
                {
                    ResultData rdt = MatchFile.FileDataPasswordBarHelper.DecodeAndUnzip(filepath, targetPath, pwd);
                    if (!rdt.Result) return rdt;
                    filepath = targetPath;
                }
                catch { rd = new ResultData { Result = false, Message = "解密失败" }; }
            }
            rd = !rd.Result ? rd : TemplateHelper.BatchConsignDataTemplateHelper.LoadBOCDocument(aft, command, filepath, isBOC);

            //删除解密文件
            try
            {
                if (isPWDFile)
                    if (File.Exists(filepath))
                        File.Delete(filepath);
            }
            catch { }
            return rd;
        }
        /// <summary>
        /// 处理模块控制业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        public static void ResolveShowPanel(OperatorCommandType command, AppliableFunctionType aft, FunctionInSettingType fst)
        {
            if (null != m_ShowPanelEvent)
                m_ShowPanelEvent(null, new ShowPanelEventArgs { AppType = aft, Command = command, BatchAppType = fst });
        }
        /// <summary>
        /// 处理用途变更业务
        /// </summary>
        /// <param name="useType"></param>
        /// <param name="aft"></param>
        public static void ResolveUseTypeChanged(OperatorCommandType command, AgentBusinessType useType, AppliableFunctionType aft, bool isRollBank)
        {
            if (null != m_UseTypeChangedEvent)
                m_UseTypeChangedEvent(null, new UseTypeChangedEventArgs { AppType = aft, UseType = useType, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理代发卡类型变更业务
        /// </summary>
        /// <param name="act"></param>
        /// <param name="aft"></param>
        public static void ResolveCardTypeChanged(OperatorCommandType command, AppliableFunctionType aft, AgentCardType act, bool isRollBank)
        {
            if (null != m_CardTypeChangedEvent)
                m_CardTypeChangedEvent(null, new CardTypeChangedEventArgs { AppType = aft, CardType = act, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理外币统一支付中的收款人账号类型变更业务
        /// </summary>
        /// <param name="act"></param>
        /// <param name="aft"></param>
        public static void ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType command, AppliableFunctionType aft, OverCountryPayeeAccountType act, bool isRollBank)
        {
            if (null != m_OverCountryPayeeAccountTypeEvent)
                m_OverCountryPayeeAccountTypeEvent(null, new OverCountryPayeeAccountTypeEventArgs { AppType = aft, AccountType = act, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理菜单控制业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="showIndex"></param>
        /// <param name="showCount"></param>
        //public static void ResolveMoveMenu(OperatorCommandType command, int showIndex, int showCount, int showmaxwidth, int startposition, int endposition, OperatorCommandType batchcommand)
        //{
        //    if (null != m_MoveMenuEvent)
        //        m_MoveMenuEvent(null, new MoveMenuEventArgs { Command = command, ShowIndex = showIndex, ShowCount = showCount, ShowMaxWidth = showmaxwidth, Startposition = startposition, Endposition = endposition, BatchCommand = batchcommand });
        //}
        /// <summary>
        /// 处理数据查询业务
        /// </summary>
        /// <param name="rowindex"></param>
        /// <param name="aft"></param>
        public static void ResolveQueryData(int rowindex, AppliableFunctionType aft)
        {
            if (null != m_QueryByRowIndexEvent)
                m_QueryByRowIndexEvent(null, new QueryByRowIndexEventArgs { RowIndex = rowindex - 1, AppType = aft });
        }
        /// <summary>
        /// 处理银行类型变更业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="bankType"></param>
        /// <param name="isRollBank"></param>
        public static void ResolveBankTypeChanged(OperatorCommandType command, AppliableFunctionType aft, AgentTransferBankType bankType, bool isRollBank)
        {
            if (null != m_BankTypeChangedEvent)
                m_BankTypeChangedEvent(null, new BankTypeChangedEventArgs { AppType = aft, BankType = bankType, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理编辑操作业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveEditOperator(OperatorCommandType command, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_EditEvent)
                m_EditEvent(null, new EditEventArgs { Command = command, AppType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量出票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketRemit(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveElecTicketRemit(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量出票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketRemit(OperatorCommandType command, ElecTicketRemit ett, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketRemitEvent)
                m_ElecTicketRemitEvent(null, new ElecTicketRemitEventArgs { Command = command, ElecTicketRemit = ett, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量出票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketRemit(OperatorCommandType command, List<ElecTicketRemit> ettList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketRemitEvent)
                m_ElecTicketRemitEvent(null, new ElecTicketRemitEventArgs { Command = command, ElecTicketRemitList = ettList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理关系人维护业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ra"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketRelateAccount(OperatorCommandType command, ElecTicketRelationAccount ra, int rowIndex)
        {
            if (null != m_ElecTicketRelateAccountEvent)
                m_ElecTicketRelateAccountEvent(null, new ElecTicketRelateAccountEventArgs { Command = command, RelationAccount = ra, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理关系人维护业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ra"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketRelateAccount(OperatorCommandType command, List<ElecTicketRelationAccount> raList)
        {
            if (null != m_ElecTicketRelateAccountEvent)
                m_ElecTicketRelateAccountEvent(null, new ElecTicketRelateAccountEventArgs { Command = command, RelationAccountList = raList });
        }
        /// <summary>
        /// 处理票据类型变更业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="ett"></param>
        /// <param name="rpt"></param>
        public static void ResolveElecTicketTypeChanged(OperatorCommandType command, AppliableFunctionType aft, ElecTicketType ett, RelatePersonType rpt)
        {
            if (null != m_ElecTicketTypeChangeEvent)
                m_ElecTicketTypeChangeEvent(null, new ElecTicketTypeChangedEventArgs { OwnerType = aft, TicketType = ett, RelateAccountType = rpt, Command = command });
        }
        /// <summary>
        /// 处理批量电票自动提示承兑业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketAutoTipExchange(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveElecTicketAutoTipExchange(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量电票自动提示承兑业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketAutoTipExchange(OperatorCommandType command, ElecTicketAutoTipExchange etate, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketAutoTipExchangeEvent)
                m_ElecTicketAutoTipExchangeEvent(null, new ElecTicketAutoTipExchangeEventArgs { Command = command, ElecTicketAutoTipExchange = etate, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量电票自动提示承兑业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketAutoTipExchange(OperatorCommandType command, List<ElecTicketAutoTipExchange> etateList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketAutoTipExchangeEvent)
                m_ElecTicketAutoTipExchangeEvent(null, new ElecTicketAutoTipExchangeEventArgs { Command = command, ElecTicketAutoTipExchangeList = etateList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量电票背书业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketBackNote(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveElecTicketBackNote(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量电票背书业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketBackNote(OperatorCommandType command, ElecTicketBackNote etate, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketBackNoteEvent)
                m_ElecTicketBackNoteEvent(null, new ElecTicketBackNoteEventArgs { Command = command, ElecTicketBackNote = etate, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量电票背书业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketBackNote(OperatorCommandType command, List<ElecTicketBackNote> etateList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketBackNoteEvent)
                m_ElecTicketBackNoteEvent(null, new ElecTicketBackNoteEventArgs { Command = command, ElecTicketBackNoteList = etateList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量电票贴现业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketPayMoney(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveElecTicketPayMoney(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量电票贴现业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketPayMoney(OperatorCommandType command, ElecTicketPayMoney etate, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_ElecTicketPayMoneyEvent(null, new ElecTicketPayMoneyEventArgs { Command = command, ElecTicketPayMoney = etate, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量电票贴现业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketPayMoney(OperatorCommandType command, List<ElecTicketPayMoney> etateList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_ElecTicketPayMoneyEvent(null, new ElecTicketPayMoneyEventArgs { Command = command, ElecTicketPayMoneyList = etateList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量票据池业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketPool(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveElecTicketPool(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量票据池业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketPool(OperatorCommandType command, ElecTicketPool etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketPoolEvent)
                m_ElecTicketPoolEvent(null, new ElecTicketPoolEventArgs { Command = command, ElecTicketPool = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量票据池业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveElecTicketPool(OperatorCommandType command, List<ElecTicketPool> etpList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_ElecTicketPoolEvent(null, new ElecTicketPoolEventArgs { Command = command, ElecTicketPoolList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量国际结算业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveTransferGlobal(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveTransferGlobal(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量国际结算业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveTransferGlobal(OperatorCommandType command, TransferGlobal etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_TransferGlobalEvent(null, new TransferGlobalEventArgs { Command = command, TransferGlobal = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量国际结算业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveTransferGlobal(OperatorCommandType command, List<TransferGlobal> etpList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_TransferGlobalEvent(null, new TransferGlobalEventArgs { Command = command, TransferGlobalList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理币种类型变更业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="aft"></param>
        public static void ResolveCashTypeChanged(OperatorCommandType command, CashType ct, AppliableFunctionType aft, bool isrollback)
        {
            if (null != m_CashTypeChangedEvent)
                m_CashTypeChangedEvent(null, new CashTypeChangedEventArgs { Command = command, CashType = ct, AppType = aft, IsRollBack = isrollback });
        }
        /// <summary>
        /// 处理国际结算收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolvePayee4TransferGlobal(OperatorCommandType ct, PayeeInfo4TransferGlobal payee, AppliableFunctionType aft, int rowindex)
        {
            if (m_Payee4TransferGlobalEvent != null)
                m_Payee4TransferGlobalEvent(null, new Payee4TransferGlobalEventArgs { Command = ct, PayeeInfo = payee, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理国际结算收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolvePayee4TransferGlobal(OperatorCommandType ct, List<PayeeInfo4TransferGlobal> payeeList, AppliableFunctionType aft)
        {
            if (m_Payee4TransferGlobalEvent != null)
                m_Payee4TransferGlobalEvent(null, new Payee4TransferGlobalEventArgs { Command = ct, PayeeInfo = null, PayeeList = payeeList, OwnerType = aft });
        }
        /// <summary>
        /// 处理批量经销商融资申请业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingApply(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveSpplyFinancingApply(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量经销商融资申请业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingApply(OperatorCommandType command, SpplyFinancingApply etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingApplyEvent)
                m_SpplyFinancingApplyEvent(null, new SpplyFinancingApplyEventArgs { Command = command, SpplyFinancingApply = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量经销商融资申请业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingApply(OperatorCommandType command, List<SpplyFinancingApply> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingApplyEvent)
                m_SpplyFinancingApplyEvent(null, new SpplyFinancingApplyEventArgs { Command = command, SpplyFinancingApplyList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/买方发票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingBill(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveSpplyFinancingBill(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/买方发票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingBill(OperatorCommandType command, SpplyFinancingBill etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingBillEvent)
                m_SpplyFinancingBillEvent(null, new SpplyFinancingBillEventArgs { Command = command, SpplyFinancingBill = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/买方发票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingBill(OperatorCommandType command, List<SpplyFinancingBill> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingBillEvent)
                m_SpplyFinancingBillEvent(null, new SpplyFinancingBillEventArgs { Command = command, SpplyFinancingBillList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/卖方收/付款业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingPayOrReceipt(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveSpplyFinancingPayOrReceipt(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/卖方收/付款业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingPayOrReceipt(OperatorCommandType command, SpplyFinancingPayOrReceipt etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingPayOrReceiptEvent)
                m_SpplyFinancingPayOrReceiptEvent(null, new SpplyFinancingPayOrReceiptEventArgs { Command = command, SpplyFinancingPayOrReceipt = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/卖方收/付款业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingPayOrReceipt(OperatorCommandType command, List<SpplyFinancingPayOrReceipt> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingPayOrReceiptEvent)
                m_SpplyFinancingPayOrReceiptEvent(null, new SpplyFinancingPayOrReceiptEventArgs { Command = command, SpplyFinancingPayOrReceiptList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量卖/买方订单提交业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingOrder(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveSpplyFinancingOrder(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量卖/买方订单提交业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingOrder(OperatorCommandType command, SpplyFinancingOrder etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingOrderEvent)
                m_SpplyFinancingOrderEvent(null, new SpplyFinancingOrderEventArgs { Command = command, SpplyFinancingOrder = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量卖/买方订单提交业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveSpplyFinancingOrder(OperatorCommandType command, List<SpplyFinancingOrder> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingOrderEvent)
                m_SpplyFinancingOrderEvent(null, new SpplyFinancingOrderEventArgs { Command = command, SpplyFinancingOrderList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理主动调拨账户信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="initiativeAllotAccount">收款人信息</param>
        public static void ResolveInitiativeAllotAccount(OperatorCommandType ct, InitiativeAllotAccount initiativeAllotAccount, AppliableFunctionType aft, int rowindex)
        {
            if (m_InitiativeAllotAccountEvent != null)
                m_InitiativeAllotAccountEvent(null, new InitiativeAllotAccountEventArgs { Command = ct, InitiativeAllotAccount = initiativeAllotAccount, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理主动调拨账户信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public static void ResolveInitiativeAllotAccount(OperatorCommandType ct, List<InitiativeAllotAccount> initiativeAllotAccountList, AppliableFunctionType aft)
        {
            if (m_InitiativeAllotAccountEvent != null)
                m_InitiativeAllotAccountEvent(null, new InitiativeAllotAccountEventArgs { Command = ct, InitiativeAllotAccount = null, InitiativeAllotAccountList = initiativeAllotAccountList, OwnerType = aft });
        }
        /// <summary>
        /// 处理多语言变更业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="lang"></param>
        public static void ResolveLanguageChanged(OperatorCommandType ct, UILang lang)
        {
            if (m_LanguageChangedEvent != null)
                m_LanguageChangedEvent(null, new LanguageChangedEventArgs { Language = lang, Command = ct });
        }
        /// <summary>
        /// 处理设置中的操作业务
        /// 用于全选、反选、批量删除
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="aft"></param>
        public static void ResolveSettingsOperate(OperatorCommandType ct, FunctionInSettingType fst)
        {
            if (m_SettingsOperateEvent != null)
                m_SettingsOperateEvent(null, new SettingsOperateEventArgs { FunctionType = fst, Command = ct });
        }
        /// <summary>
        /// 处理快捷代发中批用途变更业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="fst"></param>
        public static void ResolveAgentExpressPurpose(OperatorCommandType ct, AppliableFunctionType aft, AgentExpressFunctionType aeft, bool isrollback)
        {
            if (m_AgentExpressPurposeEvent != null)
                m_AgentExpressPurposeEvent(null, new AgentExpressPurposeEventArgs { Owner = aft, Command = ct, Purpose = aeft, IsRollBack = isrollback });
        }
        /// <summary>
        /// 处理贴入人银行信息变更业务
        /// </summary>
        /// <param name="bankname"></param>
        /// <param name="bankno"></param>
        public static void ResolveStickOnBankInfo(string bankname, string bankno)
        {
            if (null != m_StickOnBankInfoEvent)
                m_StickOnBankInfoEvent(null, new StickOnBankInfoEventArgs { BankName = bankname, BankNo = bankno });
        }
        /// <summary>
        /// 处理批量人民币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveUnitivePaymentRMB(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveUnitivePaymentRMB(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量人民币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveUnitivePaymentRMB(OperatorCommandType command, UnitivePaymentRMB etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_UnitivePaymentRMBEvent)
                m_UnitivePaymentRMBEvent(null, new UnitivePaymentRMBEventArgs { Command = command, UnitivePaymentRMB = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量人民币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveUnitivePaymentRMB(OperatorCommandType command, List<UnitivePaymentRMB> etpList, AppliableFunctionType aft)
        {
            if (null != m_UnitivePaymentRMBEvent)
                m_UnitivePaymentRMBEvent(null, new UnitivePaymentRMBEventArgs { Command = command, UnitivePaymentRMBList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量外币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveUnitivePaymentFC(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveUnitivePaymentFC(command, null, aft, -1, OverCountryPayeeAccountType.Empty);
        }
        /// <summary>
        /// 处理批量外币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveUnitivePaymentFC(OperatorCommandType command, UnitivePaymentForeignMoney etp, AppliableFunctionType aft, int rowIndex, OverCountryPayeeAccountType at)
        {
            if (null != m_UnitivePaymentFCEvent)
                m_UnitivePaymentFCEvent(null, new UnitivePaymentFCEventArgs { Command = command, UnitivePaymentFC = etp, OwnerType = aft, RowIndex = rowIndex, AccountType = at });
        }
        /// <summary>
        /// 处理批量外币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveUnitivePaymentFC(OperatorCommandType command, List<UnitivePaymentForeignMoney> etpList, AppliableFunctionType aft, OverCountryPayeeAccountType at)
        {
            if (null != m_UnitivePaymentFCEvent)
                m_UnitivePaymentFCEvent(null, new UnitivePaymentFCEventArgs { Command = command, UnitivePaymentFCList = etpList, OwnerType = aft, RowIndex = -1, AccountType = at });
        }
        /// <summary>
        /// 处理批量内部账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveVirtualAccount(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveVirtualAccount(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量内部账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveVirtualAccount(OperatorCommandType command, VirtualAccount etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_VirtualAccountEvent)
                m_VirtualAccountEvent(null, new VirtualAccountEventArgs { Command = command, InitiativeAccount = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量内部账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveVirtualAccount(OperatorCommandType command, List<VirtualAccount> etpList, AppliableFunctionType aft)
        {
            if (null != m_VirtualAccountEvent)
                m_VirtualAccountEvent(null, new VirtualAccountEventArgs { Command = command, VirtualAccountList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理内部账户转账信息
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="initiativeAllotAccount">账户信息</param>
        public static void ResolveVirtualAllotAccount(OperatorCommandType ct, VirtualAccountInfo initiativeAllotAccount, AppliableFunctionType aft, int rowindex)
        {
            if (m_VirtualAccountAllotEvent != null)
                m_VirtualAccountAllotEvent(null, new VirtualAccountAllotEventArgs { Command = ct, VirtualAllotAccount = initiativeAllotAccount, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理内部账户转账信息
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">账户信息</param>
        public static void ResolveVirtualAllotAccount(OperatorCommandType ct, List<VirtualAccountInfo> initiativeAllotAccountList, AppliableFunctionType aft)
        {
            if (m_VirtualAccountAllotEvent != null)
                m_VirtualAccountAllotEvent(null, new VirtualAccountAllotEventArgs { Command = ct, VirtualAllotAccount = null, VirtualAllotAccountList = initiativeAllotAccountList, OwnerType = aft });
        }
        /// <summary>
        /// 处理待处理账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolvePreproccessTransfer(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolvePreproccessTransfer(command, null, aft, -1);
        }
        /// <summary>
        /// 处理待处理账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolvePreproccessTransfer(OperatorCommandType command, PreproccessTransfer etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_PreproccessTransferEvent)
                m_PreproccessTransferEvent(null, new PreproccessTransferEventArgs { Command = command, PreproccessTransfer = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理待处理账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolvePreproccessTransfer(OperatorCommandType command, List<PreproccessTransfer> etpList, AppliableFunctionType aft)
        {
            if (null != m_PreproccessTransferEvent)
                m_PreproccessTransferEvent(null, new PreproccessTransferEventArgs { Command = command, PreproccessTransferList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理财政公务卡-批量报销业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveBatchReimbursement(OperatorCommandType command, AppliableFunctionType aft)
        {
            ResolveBatchReimbursement(command, null, aft, -1);
        }
        /// <summary>
        /// 处理财政公务卡-批量报销业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveBatchReimbursement(OperatorCommandType command, BatchReimbursement etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_BatchReimbursementEvent)
                m_BatchReimbursementEvent(null, new BatchReimbursementEventArgs { Command = command, BatchReimbursement = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理财政公务卡-批量报销业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public static void ResolveBatchReimbursement(OperatorCommandType command, List<BatchReimbursement> etpList, AppliableFunctionType aft)
        {
            if (null != m_BatchReimbursementEvent)
                m_BatchReimbursementEvent(null, new BatchReimbursementEventArgs { Command = command, BatchReimbursementList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理中央财政授权支付批量委托业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public static void ResolveGoverment(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveGoverment(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理中央财政授权支付批量委托
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public static void ResolveGoverment(OperatorCommandType ct, GovermentInfo transfer, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_GovermentEvent)
                m_GovermentEvent(null, new GovermentEventArgs { Command = ct,  GovermentInfo= transfer, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理中央财政授权支付批量委托
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="transferList"></param>
        /// <param name="aft"></param>
        public static void ResolveGoverment(OperatorCommandType ct, List<GovermentInfo> transferList, AppliableFunctionType aft)
        {
            if (null != m_GovermentEvent)
                m_GovermentEvent(null, new GovermentEventArgs { Command = ct, GovermentInfoList = transferList, OwnerType = aft, RowIndex = -1 });
        }
        #endregion
    }

    /// <summary>
    /// 付款人信息参数类
    /// </summary>
    public class PayerEventArgs : EventArgs
    {
        /// <summary>
        /// 付款人信息
        /// </summary>
        public PayerInfo PayerInfo { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 付款人列表
        /// </summary>
        public List<PayerInfo> PayerList { get; set; }

        public PayerEventArgs()
        {
            PayerInfo = null;
            Command = BatchCommand = OperatorCommandType.Empty;
            PayerList = new List<PayerInfo>();
        }
    }
    /// <summary>
    /// 收款人信息参数类
    /// </summary>
    public class PayeeEventArgs : EventArgs
    {
        /// <summary>
        /// 收款人信息
        /// </summary>
        public PayeeInfo PayeeInfo { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 收款人信息
        /// </summary>
        public List<PayeeInfo> PayeeList { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        public PayeeEventArgs()
        {
            PayeeInfo = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
            PayeeList = new List<PayeeInfo>();
            RowIndex = 0;
        }
    }
    /// <summary>
    /// 转账汇款信息参数类
    /// </summary>
    public class TransferEventArgs : EventArgs
    {
        /// <summary>
        /// 选中的行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 收款人信息
        /// </summary>
        public TransferAccount TransferAccount { get; set; }

        /// <summary>
        /// 转账列表
        /// </summary>
        public List<TransferAccount> TransferAccountList { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        public TransferEventArgs()
        {
            RowIndex = -1;
            Command = OperatorCommandType.Empty;
            TransferAccount = null;
            TransferAccountList = new List<TransferAccount>();
        }
    }
    /// <summary>
    /// 功能可视化参数
    /// </summary>
    public class AppliableEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 功能可视化参数
        /// </summary>
        public AppliableFunctionType AppVisiable { get; set; }

        /// <summary>
        /// 柜台功能可视化参数
        /// </summary>
        public AppliableFunctionType AppVisiableBar { get; set; }

        public AppliableEventArgs()
        {
            Command = OperatorCommandType.Empty;
            AppVisiable = AppVisiableBar = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 附言和用途参数
    /// </summary>
    public class NoticeEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 附言和用途
        /// </summary>
        public NoticeInfo Notice { get; set; }

        /// <summary>
        /// 附言和用途
        /// </summary>
        public List<NoticeInfo> NoticeList { get; set; }

        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        public NoticeEventArgs()
        {
            Command = OperatorCommandType.Empty;
            Notice = null;
            NoticeList = new List<NoticeInfo>();
        }
    }
    /// <summary>
    /// 快捷代发、代收参数
    /// </summary>
    public class AgentExpressEventArgs : EventArgs
    {
        /// <summary>
        /// 选中的行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 快捷代收、代发信息
        /// </summary>
        public AgentExpress AgentExpress { get; set; }

        /// <summary>
        /// 快捷代收、代发信息
        /// </summary>
        public List<AgentExpress> AgentExpressList { get; set; }

        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader BatchInfo { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        public AgentExpressEventArgs()
        {
            RowIndex = -1;
            AgentExpress = null;
            AgentExpressList = new List<Entities.AgentExpress>();
            BatchInfo = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 普通代发、代收参数
    /// </summary>
    public class AgentNormalEventArgs : EventArgs
    {
        /// <summary>
        /// 选中的行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 普通代收、代发信息
        /// </summary>
        public AgentNormal AgentNormal { get; set; }

        /// <summary>
        /// 普通代收、代发信息
        /// </summary>
        public List<AgentNormal> AgentNormalList { get; set; }

        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader BatchInfo { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        public AgentNormalEventArgs()
        {
            RowIndex = -1;
            AgentNormal = null;
            AgentNormalList = new List<Entities.AgentNormal>();
            BatchInfo = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 主动调拨参数
    /// </summary>
    public class InitiativeAllotEventArgs : EventArgs
    {
        /// <summary>
        /// 选中的行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 主动调拨信息
        /// </summary>
        public InitiativeAllot InitiativeAllot { get; set; }

        /// <summary>
        /// 主动调拨信息
        /// </summary>
        public List<InitiativeAllot> InitiativeAllotList { get; set; }

        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader BatchInfo { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        public InitiativeAllotEventArgs()
        {
            RowIndex = -1;
            InitiativeAllot = null;
            InitiativeAllotList = new List<Entities.InitiativeAllot>();
            BatchInfo = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 处理数据航业务
    /// </summary>
    public class RowIndexEventArgs : EventArgs
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属功能模块类型
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        public RowIndexEventArgs()
        {
            RowIndex = -1;
            Command = OperatorCommandType.Empty;
            AppType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 公共数据参数
    /// </summary>
    public class CommonDataEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        private Dictionary<AppliableFunctionType, CommonFieldType> m_CommonFields;
        /// <summary>
        /// 公共数据信息
        /// </summary>
        public Dictionary<AppliableFunctionType, CommonFieldType> CommonFields
        {
            get { return m_CommonFields; }
            set { m_CommonFields = value; }
        }
        public CommonDataEventArgs()
        {
            m_CommonFields = new Dictionary<AppliableFunctionType, CommonFieldType>();
            Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 文件加密密码参数
    /// </summary>
    public class EncryptionEventArgs : EventArgs
    {
        /// <summary>
        /// 是否设置快捷代发加密密码
        /// </summary>
        public bool IsSetPassword { get; set; }

        /// <summary>
        /// 加密密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 功能模块
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        public EncryptionEventArgs()
        {
            IsSetPassword = false;
            Password = string.Empty;
            AppType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 批量设置参数
    /// </summary>
    public class FieldMappingEventArgs : EventArgs
    {
        /// <summary>
        /// 功能模块
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        private OperatorCommandType m_Command;
        /// <summary>
        /// 操纵类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        /// <summary>
        /// 数据项映射关系
        /// </summary>
        public MappingsRelationSettings Mappings { get; set; }

        private FunctionInSettingType m_BatchAppType;
        /// <summary>
        /// 子功能信息
        /// </summary>
        public FunctionInSettingType BatchAppType
        {
            get { return m_BatchAppType; }
            set { m_BatchAppType = value; }
        }

        /// <summary>
        /// 设置中的菜单
        /// 默认填写批量转换设置选项
        /// </summary>
        public FunctionInSettingType FunType { get; set; }

        public FieldMappingEventArgs()
        {
            AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            Mappings = new MappingsRelationSettings();
            m_BatchAppType = FunctionInSettingType.Empty;
            FunType = FunctionInSettingType.Empty;
        }
    }
    /// <summary>
    /// 模块控制参数
    /// </summary>
    public class ShowPanelEventArgs : EventArgs
    {
        /// <summary>
        /// 功能模块
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        private OperatorCommandType m_Command;
        /// <summary>
        /// 命令类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        /// <summary>
        /// 子功能类型
        /// </summary>
        public FunctionInSettingType BatchAppType { get; set; }

        public ShowPanelEventArgs()
        {
            AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            BatchAppType = FunctionInSettingType.Empty;
        }
    }
    /// <summary>
    /// 用途类型变化参数
    /// </summary>
    public class UseTypeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 用途
        /// </summary>
        public AgentBusinessType UseType { get; set; }

        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 是否回滚操作
        /// </summary>
        public bool IsRollBack { get; set; }

        public UseTypeChangedEventArgs()
        {
            UseType = AgentBusinessType.Salary;
            m_AppType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            IsRollBack = false;
        }
    }
    /// <summary>
    /// 代发卡类型变化参数
    /// </summary>
    public class CardTypeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 代发卡类型
        /// </summary>
        public AgentCardType CardType { get; set; }

        /// <summary>
        /// 代发卡类型
        /// </summary>
        public string CardTypeString
        {
            get { return EnumNameHelper<AgentCardType>.GetEnumDescription(CardType); }
        }

        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 是否回滚
        /// </summary>
        public bool IsRollBack { get; set; }

        public CardTypeChangedEventArgs()
        {
            CardType = AgentCardType.Empty;
            AppType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            IsRollBack = false;
        }
    }
    /// <summary>
    /// 菜单滚动控制参数
    /// </summary>
    //public class MoveMenuEventArgs : EventArgs
    //{
    //    /// <summary>
    //    /// 操作命令
    //    /// </summary>
    //    public OperatorCommandType Command { get; set; }

    //    /// <summary>
    //    /// 当前选中的索引
    //    /// </summary>
    //    public int ShowIndex { get; set; }

    //    /// <summary>
    //    /// 当前显示的数量
    //    /// </summary>
    //    public int ShowCount { get; set; }

    //    private int m_startposition;
    //    /// <summary>
    //    /// 最左端位置
    //    /// </summary>
    //    public int Startposition
    //    {
    //        get { return m_startposition; }
    //        set { m_startposition = value; }
    //    }

    //    /// <summary>
    //    /// 最右端位置
    //    /// </summary>
    //    public int Endposition { get; set; }

    //    /// <summary>
    //    /// 最大需要显示的宽度
    //    /// </summary>
    //    public int ShowMaxWidth { get; set; }

    //    /// <summary>
    //    /// 子操作
    //    /// </summary>
    //    public OperatorCommandType BatchCommand { get; set; }

    //    public MoveMenuEventArgs()
    //    {
    //        Command = OperatorCommandType.Empty;
    //        ShowCount = ShowIndex = 0;
    //        BatchCommand = OperatorCommandType.MoveMenuRaise;
    //    }
    //}
    /// <summary>
    /// 行号查询参数
    /// </summary>
    public class QueryByRowIndexEventArgs : EventArgs
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        public QueryByRowIndexEventArgs()
        {
            RowIndex = -1;
            AppType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 银行类型变更参数
    /// </summary>
    public class BankTypeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 银行类型
        /// </summary>
        public AgentTransferBankType BankType { get; set; }

        /// <summary>
        /// 是否回滚操作
        /// </summary>
        public bool IsRollBack { get; set; }

        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        public BankTypeChangedEventArgs()
        {
            AppType = AppliableFunctionType._Empty;
            BankType = AgentTransferBankType.Boc;
            m_Command = OperatorCommandType.Empty;
            IsRollBack = false;
        }
    }
    /// <summary>
    /// 编辑业务参数
    /// </summary>
    public class EditEventArgs : EventArgs
    {
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        public EditEventArgs()
        {
            m_AppType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            RowIndex = -1;
        }
    }
    /// <summary>
    /// 系统多语言参数
    /// </summary>
    public class LanguageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 当前系统语言
        /// </summary>
        public UILang Language { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        public LanguageChangedEventArgs()
        {
            Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 电票出票业务参数
    /// </summary>
    public class ElecTicketRemitEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }

        /// <summary>
        /// 出票信息
        /// </summary>
        public ElecTicketRemit ElecTicketRemit { get; set; }

        /// <summary>
        /// 出票信息列表
        /// </summary>
        public List<ElecTicketRemit> ElecTicketRemitList { get; set; }

        public ElecTicketRemitEventArgs()
        {
            m_rowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            ElecTicketRemit = null;
            ElecTicketRemitList = new List<ElecTicketRemit>();
        }
    }
    /// <summary>
    /// 关系人业务参数
    /// </summary>
    public class ElecTicketRelateAccountEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 关系人信息
        /// </summary>
        public ElecTicketRelationAccount RelationAccount { get; set; }

        /// <summary>
        /// 关系人列表
        /// </summary>
        public List<ElecTicketRelationAccount> RelationAccountList { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        public ElecTicketRelateAccountEventArgs()
        {
            RowIndex = 0;
            RelationAccount = null;
            Command = OperatorCommandType.Empty;
            RelationAccountList = new List<ElecTicketRelationAccount>();
        }
    }
    /// <summary>
    /// 票据类型变更参数
    /// </summary>
    public class ElecTicketTypeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        private ElecTicketType m_ticketType;
        /// <summary>
        /// 票据类型
        /// </summary>
        public ElecTicketType TicketType
        {
            get { return m_ticketType; }
            set { m_ticketType = value; }
        }

        /// <summary>
        /// 接收关系人类型
        /// </summary>
        public RelatePersonType RelateAccountType { get; set; }

        public ElecTicketTypeChangedEventArgs()
        {
            Command = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
            m_ticketType = ElecTicketType.Empty;
            RelateAccountType = RelatePersonType.Empty;
        }
    }
    /// <summary>
    /// 电票自动提示承兑参数
    /// </summary>
    public class ElecTicketAutoTipExchangeEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 自动提示承兑信息
        /// </summary>
        public ElecTicketAutoTipExchange ElecTicketAutoTipExchange { get; set; }

        private List<ElecTicketAutoTipExchange> m_ElecTicketAutoTipExchangeList;
        /// <summary>
        /// 自动提示承兑信息列表
        /// </summary>
        public List<ElecTicketAutoTipExchange> ElecTicketAutoTipExchangeList
        {
            get { return m_ElecTicketAutoTipExchangeList; }
            set { m_ElecTicketAutoTipExchangeList = value; }
        }
        public ElecTicketAutoTipExchangeEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            ElecTicketAutoTipExchange = null;
            m_ElecTicketAutoTipExchangeList = new List<ElecTicketAutoTipExchange>();
        }
    }
    /// <summary>
    /// 电票背书参数
    /// </summary>
    public class ElecTicketBackNoteEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 背书信息
        /// </summary>
        public ElecTicketBackNote ElecTicketBackNote { get; set; }

        /// <summary>
        /// 背书信息列表
        /// </summary>
        public List<ElecTicketBackNote> ElecTicketBackNoteList { get; set; }

        public ElecTicketBackNoteEventArgs()
        {
            RowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            ElecTicketBackNote = null;
            ElecTicketBackNoteList = new List<ElecTicketBackNote>();
        }
    }
    /// <summary>
    /// 电票贴现参数
    /// </summary>
    public class ElecTicketPayMoneyEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 贴现信息
        /// </summary>
        public ElecTicketPayMoney ElecTicketPayMoney { get; set; }

        /// <summary>
        /// 贴现信息列表
        /// </summary>
        public List<ElecTicketPayMoney> ElecTicketPayMoneyList { get; set; }

        public ElecTicketPayMoneyEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            ElecTicketPayMoney = null;
            ElecTicketPayMoneyList = new List<ElecTicketPayMoney>();
        }
    }
    /// <summary>
    /// 票据池参数
    /// </summary>
    public class ElecTicketPoolEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 票据池信息
        /// </summary>
        public ElecTicketPool ElecTicketPool { get; set; }

        /// <summary>
        /// 票据池信息列表
        /// </summary>
        public List<ElecTicketPool> ElecTicketPoolList { get; set; }

        public ElecTicketPoolEventArgs()
        {
            RowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            ElecTicketPool = null;
            ElecTicketPoolList = new List<ElecTicketPool>();
        }
    }
    /// <summary>
    /// 国际结算参数
    /// </summary>
    public class TransferGlobalEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 票据池信息
        /// </summary>
        public TransferGlobal TransferGlobal { get; set; }

        /// <summary>
        /// 票据池信息列表
        /// </summary>
        public List<TransferGlobal> TransferGlobalList { get; set; }

        public TransferGlobalEventArgs()
        {
            RowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            TransferGlobal = null;
            TransferGlobalList = new List<TransferGlobal>();
        }
    }
    /// <summary>
    /// 币种类型变更参数
    /// </summary>
    public class CashTypeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 所属功能类型
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        /// <summary>
        /// 币种类型
        /// </summary>
        public CashType CashType { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 是否回滚
        /// </summary>
        public bool IsRollBack { get; set; }

        public CashTypeChangedEventArgs()
        {
            IsRollBack = false;
            AppType = AppliableFunctionType._Empty;
            CashType = EnumTypes.CashType.Empty;
            Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 国际结算收款人业务参数
    /// </summary>
    public class Payee4TransferGlobalEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 收款人信息
        /// </summary>
        public PayeeInfo4TransferGlobal PayeeInfo { get; set; }

        /// <summary>
        /// 收款人列表
        /// </summary>
        public List<PayeeInfo4TransferGlobal> PayeeList { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        public Payee4TransferGlobalEventArgs()
        {
            RowIndex = 0;
            PayeeInfo = null;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            PayeeList = new List<PayeeInfo4TransferGlobal>();
        }
    }
    /// <summary>
    /// 供应链--经销商融资申请参数
    /// </summary>
    public class SpplyFinancingApplyEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 融资申请信息
        /// </summary>
        public SpplyFinancingApply SpplyFinancingApply { get; set; }

        /// <summary>
        /// 融资申请信息列表
        /// </summary>
        public List<SpplyFinancingApply> SpplyFinancingApplyList { get; set; }

        public SpplyFinancingApplyEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            SpplyFinancingApply = null;
            SpplyFinancingApplyList = new List<SpplyFinancingApply>();
        }
    }
    /// <summary>
    /// 供应链--卖/买方订单提交参数
    /// </summary>
    public class SpplyFinancingBillEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 发票信息
        /// </summary>
        public SpplyFinancingBill SpplyFinancingBill { get; set; }

        /// <summary>
        /// 发票信息列表
        /// </summary>
        public List<SpplyFinancingBill> SpplyFinancingBillList { get; set; }

        public SpplyFinancingBillEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            SpplyFinancingBill = null;
            SpplyFinancingBillList = new List<SpplyFinancingBill>();
        }
    }
    /// <summary>
    /// 供应链--应收账款卖/买方收/付款参数
    /// </summary>
    public class SpplyFinancingPayOrReceiptEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 收/付款信息
        /// </summary>
        public SpplyFinancingPayOrReceipt SpplyFinancingPayOrReceipt { get; set; }

        /// <summary>
        /// 收/付款信息列表
        /// </summary>
        public List<SpplyFinancingPayOrReceipt> SpplyFinancingPayOrReceiptList { get; set; }

        public SpplyFinancingPayOrReceiptEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            SpplyFinancingPayOrReceipt = null;
            SpplyFinancingPayOrReceiptList = new List<SpplyFinancingPayOrReceipt>();
        }
    }
    /// <summary>
    /// 供应链--应收账款卖/买方订单参数
    /// </summary>
    public class SpplyFinancingOrderEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public SpplyFinancingOrder SpplyFinancingOrder { get; set; }

        /// <summary>
        /// 订单信息列表
        /// </summary>
        public List<SpplyFinancingOrder> SpplyFinancingOrderList { get; set; }

        public SpplyFinancingOrderEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            SpplyFinancingOrder = null;
            SpplyFinancingOrderList = new List<SpplyFinancingOrder>();
        }
    }
    /// <summary>
    /// 主动调拨账户信息参数类
    /// </summary>
    public class InitiativeAllotAccountEventArgs : EventArgs
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public InitiativeAllotAccount InitiativeAllotAccount { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 账户信息
        /// </summary>
        public List<InitiativeAllotAccount> InitiativeAllotAccountList { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        public InitiativeAllotAccountEventArgs()
        {
            InitiativeAllotAccount = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
            InitiativeAllotAccountList = new List<InitiativeAllotAccount>();
            RowIndex = 0;
        }
    }
    /// <summary>
    /// 设置中的操作参数
    /// 用于全选、反选、批量删除等
    /// </summary>
    public class SettingsOperateEventArgs : EventArgs
    {
        /// <summary>
        /// 所属业务
        /// </summary>
        public FunctionInSettingType FunctionType { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        public SettingsOperateEventArgs()
        {
            FunctionType = FunctionInSettingType.Empty;
            Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 快捷代发用途变更参数
    /// </summary>
    public class AgentExpressPurposeEventArgs : EventArgs
    {
        /// <summary>
        /// 所属业务
        /// </summary>
        public AppliableFunctionType Owner { get; set; }

        /// <summary>
        /// 批用途
        /// </summary>
        public AgentExpressFunctionType Purpose { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 是否需要回滚
        /// </summary>
        public bool IsRollBack { get; set; }

        public AgentExpressPurposeEventArgs()
        {
            Owner = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            Purpose = AgentExpressFunctionType.Empty;
        }
    }
    /// <summary>
    /// 贴入人开户行信息变更参数
    /// </summary>
    public class StickOnBankInfoEventArgs : EventArgs
    {
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        private string m_bankNo;
        /// <summary>
        /// 银行行号
        /// </summary>
        public string BankNo
        {
            get { return m_bankNo; }
            set { m_bankNo = value; }
        }
        public StickOnBankInfoEventArgs()
        {
            BankName = m_bankNo = string.Empty;
        }
    }
    /// <summary>
    /// 统一支付--人民币提交参数
    /// </summary>
    public class UnitivePaymentRMBEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 人民币统一支付信息
        /// </summary>
        public UnitivePaymentRMB UnitivePaymentRMB { get; set; }

        private List<UnitivePaymentRMB> m_UnitivePaymentRMBList;
        /// <summary>
        /// 人民币统一支付信息列表
        /// </summary>
        public List<UnitivePaymentRMB> UnitivePaymentRMBList
        {
            get { return m_UnitivePaymentRMBList; }
            set { m_UnitivePaymentRMBList = value; }
        }
        public UnitivePaymentRMBEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            UnitivePaymentRMB = null;
            m_UnitivePaymentRMBList = new List<UnitivePaymentRMB>();
        }
    }
    /// <summary>
    /// 统一支付--外币提交参数
    /// </summary>
    public class UnitivePaymentFCEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 外币统一支付信息
        /// </summary>
        public UnitivePaymentForeignMoney UnitivePaymentFC { get; set; }

        /// <summary>
        /// 收款人类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType { get; set; }

        /// <summary>
        /// 外币统一支付信息列表
        /// </summary>
        public List<UnitivePaymentForeignMoney> UnitivePaymentFCList { get; set; }

        public UnitivePaymentFCEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            AccountType = OverCountryPayeeAccountType.Empty;
            UnitivePaymentFC = null;
            UnitivePaymentFCList = new List<UnitivePaymentForeignMoney>();
        }
    }
    /// <summary>
    /// 统一支付-支付类型参数
    /// </summary>
    public class OverCountryPayeeAccountTypeEventArgs : EventArgs
    {
        /// <summary>
        /// 所属功能类型
        /// </summary>
        public AppliableFunctionType AppType { get; set; }

        /// <summary>
        /// 币种类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 是否回滚
        /// </summary>
        public bool IsRollBack { get; set; }

        public OverCountryPayeeAccountTypeEventArgs()
        {
            IsRollBack = false;
            AppType = AppliableFunctionType._Empty;
            AccountType = EnumTypes.OverCountryPayeeAccountType.Empty;
            Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 内部转账信息参数类
    /// </summary>
    public class VirtualAccountEventArgs : EventArgs
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public VirtualAccount InitiativeAccount { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 账户信息
        /// </summary>
        public List<VirtualAccount> VirtualAccountList { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        public VirtualAccountEventArgs()
        {
            InitiativeAccount = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
            VirtualAccountList = new List<VirtualAccount>();
            RowIndex = 0;
        }
    }
    /// <summary>
    /// 内部转账账户信息
    /// </summary>
    public class VirtualAccountAllotEventArgs : EventArgs
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public VirtualAccountInfo VirtualAllotAccount { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand { get; set; }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 账户信息
        /// </summary>
        public List<VirtualAccountInfo> VirtualAllotAccountList { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        public VirtualAccountAllotEventArgs()
        {
            VirtualAllotAccount = null;
            Command = OperatorCommandType.Empty;
            BatchCommand = OperatorCommandType.Empty;
            OwnerType = AppliableFunctionType._Empty;
            VirtualAllotAccountList = new List<VirtualAccountInfo>();
            RowIndex = 0;
        }
    }
    /// <summary>
    /// 待处理转账提交参数
    /// </summary>
    public class PreproccessTransferEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 待处理转账信息
        /// </summary>
        public PreproccessTransfer PreproccessTransfer { get; set; }

        private List<PreproccessTransfer> m_PreproccessTransferList;
        /// <summary>
        /// 待处理转账信息列表
        /// </summary>
        public List<PreproccessTransfer> PreproccessTransferList
        {
            get { return m_PreproccessTransferList; }
            set { m_PreproccessTransferList = value; }
        }
        public PreproccessTransferEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            PreproccessTransfer = null;
            m_PreproccessTransferList = new List<PreproccessTransfer>();
        }
    }
    /// <summary>
    /// 财政公务卡-批量报销提交数据
    /// </summary>
    public class BatchReimbursementEventArgs : EventArgs
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 财政公务卡-批量报销信息
        /// </summary>
        public BatchReimbursement BatchReimbursement { get; set; }

        private List<BatchReimbursement> m_BatchReimbursementList;
        /// <summary>
        /// 财政公务卡-批量报销信息列表
        /// </summary>
        public List<BatchReimbursement> BatchReimbursementList
        {
            get { return m_BatchReimbursementList; }
            set { m_BatchReimbursementList = value; }
        }
        public BatchReimbursementEventArgs()
        {
            RowIndex = 0;
            OwnerType = AppliableFunctionType._Empty;
            Command = OperatorCommandType.Empty;
            BatchReimbursement = null;
            m_BatchReimbursementList = new List<BatchReimbursement>();
        }
    }
    /// <summary>
    /// 中央财政授权支付网上支付批量委托
    /// </summary>
    public class GovermentEventArgs : EventArgs
    {
        /// <summary>
        /// 选中的行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 收款人信息
        /// </summary>
        public GovermentInfo GovermentInfo { get; set; }

        /// <summary>
        /// 转账列表
        /// </summary>
        public List<GovermentInfo> GovermentInfoList { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command { get; set; }

        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType { get; set; }

        public GovermentEventArgs()
        {
            RowIndex = -1;
            Command = OperatorCommandType.Empty;
            GovermentInfo = null;
            GovermentInfoList = new List<GovermentInfo>();
        }
    }
}
