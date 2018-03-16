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
    public class CommandCenter
    {
        #region 单例
        private static object lock_obj = new object();
        private static CommandCenter m_instance;
        public static CommandCenter Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (lock_obj)
                    {
                        if (null == m_instance)
                        {
                            lock (lock_obj)
                            {
                                m_instance = new CommandCenter();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        #region 公共事件
        /// <summary>
        /// 收款人事件
        /// </summary>
        public event EventHandler<PayeeEventArgs> OnPayeeInfoEventHandler
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
        public event EventHandler<PayerEventArgs> OnPayerInfoEventHandler
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
        public event EventHandler<TransferEventArgs> OnTransferAccountEventHandler
        {
            add { m_TransferEvent += value; }
            remove { m_TransferEvent -= value; }
        }
        /// <summary>
        /// 功能设置事件
        /// </summary>
        public event EventHandler<AppliableEventArgs> OnAppliableEventHandler
        {
            add { m_AppliableEvent += value; }
            remove { m_AppliableEvent -= value; }
        }
        /// <summary>
        /// 附言及用途事件
        /// </summary>
        public event EventHandler<NoticeEventArgs> OnNoticeEventHandler
        {
            add { m_NoticeEvent += value; }
            remove { m_NoticeEvent -= value; }
        }
        /// <summary>
        /// 快捷代收、代发事件
        /// </summary>
        public event EventHandler<AgentExpressEventArgs> OnAgentExpressEventHandler
        {
            add { m_AgentExpressEvent += value; }
            remove { m_AgentExpressEvent -= value; }
        }
        /// <summary>
        /// 普通代收、代发事件
        /// </summary>
        public event EventHandler<AgentNormalEventArgs> OnAgentNormalEventHandler
        {
            add { m_AgentNormalEvent += value; }
            remove { m_AgentNormalEvent -= value; }
        }
        /// <summary>
        /// 操作数据行事件
        /// </summary>
        public event EventHandler<RowIndexEventArgs> OnRwoIndexEventHandler
        {
            add { m_RowIndexEvent += value; }
            remove { m_RowIndexEvent -= value; }
        }
        /// <summary>
        /// 操作公共数据事件
        /// </summary>
        public event EventHandler<CommonDataEventArgs> OnCommonDataEventHandler
        {
            add { m_CommonDataEvent += value; }
            remove { m_CommonDataEvent -= value; }
        }
        /// <summary>
        /// 文件加密事件
        /// </summary>
        public event EventHandler<EncryptionEventArgs> OnEncryptionEventHandler
        {
            add { m_EncryptionEvent += value; }
            remove { m_EncryptionEvent -= value; }
        }
        /// <summary>
        /// 批量参数事件
        /// </summary>
        public event EventHandler<FieldMappingEventArgs> OnFieldMappingEventHandler
        {
            add { m_FieldMappingEvent += value; }
            remove { m_FieldMappingEvent -= value; }
        }
        /// <summary>
        /// 功能模块控制事件
        /// </summary>
        public event EventHandler<ShowPanelEventArgs> OnShowPanelEventHandler
        {
            add { m_ShowPanelEvent += value; }
            remove { m_ShowPanelEvent -= value; }
        }
        /// <summary>
        /// 用途变化事件
        /// </summary>
        public event EventHandler<UseTypeChangedEventArgs> OnUseTypeChangedEventHandler
        {
            add { m_UseTypeChangedEvent += value; }
            remove { m_UseTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 代发卡类型变化事件
        /// </summary>
        public event EventHandler<CardTypeChangedEventArgs> OnCardTypeChangedEventHandler
        {
            add { m_CardTypeChangedEvent += value; }
            remove { m_CardTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 菜单移动控制事件
        /// </summary>
        public event EventHandler<MoveMenuEventArgs> OnMoveMenuEventHandler
        {
            add { m_MoveMenuEvent += value; }
            remove { m_MoveMenuEvent -= value; }
        }
        /// <summary>
        /// 数据查询事件
        /// </summary>
        public event EventHandler<QueryByRowIndexEventArgs> OnQueryByRowIndexEventHandler
        {
            add { m_QueryByRowIndexEvent += value; }
            remove { m_QueryByRowIndexEvent -= value; }
        }
        /// <summary>
        /// 银行类型变更事件
        /// </summary>
        public event EventHandler<BankTypeChangedEventArgs> OnBankTypeChangedEventHandler
        {
            add { m_BankTypeChangedEvent += value; }
            remove { m_BankTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 编辑请求事件
        /// </summary>
        public event EventHandler<EditEventArgs> OnEditEventHandler
        {
            add { m_EditEvent += value; }
            remove { m_EditEvent -= value; }
        }
        /// <summary>
        /// 批量出票事件
        /// </summary>
        public event EventHandler<ElecTicketRemitEventArgs> OnElecTicketRemitEvenHnadler
        {
            add { m_ElecTicketRemitEvent += value; }
            remove { m_ElecTicketRemitEvent -= value; }
        }
        /// <summary>
        /// 关系人维护事件
        /// </summary>
        public event EventHandler<ElecTicketRelateAccountEventArgs> OnElecTicketRelateAccountEventHandler
        {
            add { m_ElecTicketRelateAccountEvent += value; }
            remove { m_ElecTicketRelateAccountEvent -= value; }
        }
        /// <summary>
        /// 票据类型变更事件
        /// </summary>
        public event EventHandler<ElecTicketTypeChangedEventArgs> OnElecTicketTypeChangedEventHandler
        {
            add { m_ElecTicketTypeChangeEvent += value; }
            remove { m_ElecTicketTypeChangeEvent -= value; }
        }
        /// <summary>
        /// 批量电票自动提示承兑事件
        /// </summary>
        public event EventHandler<ElecTicketAutoTipExchangeEventArgs> OnElecTicketAutoTipExchangeEventHandler
        {
            add { m_ElecTicketAutoTipExchangeEvent += value; }
            remove { m_ElecTicketAutoTipExchangeEvent -= value; }
        }
        /// <summary>
        /// 批量电票背书事件
        /// </summary>
        public event EventHandler<ElecTicketBackNoteEventArgs> OnElecTicketBackNoteEventHandler
        {
            add { m_ElecTicketBackNoteEvent += value; }
            remove { m_ElecTicketBackNoteEvent -= value; }
        }
        /// <summary>
        /// 批量电票贴现事件
        /// </summary>
        public event EventHandler<ElecTicketPayMoneyEventArgs> OnElecTicketPayMoneyEventHandler
        {
            add { m_ElecTicketPayMoneyEvent += value; }
            remove { m_ElecTicketPayMoneyEvent -= value; }
        }
        /// <summary>
        /// 批量票据池事件
        /// </summary>
        public event EventHandler<ElecTicketPoolEventArgs> OnElecTicketPoolEventHandler
        {
            add { m_ElecTicketPoolEvent += value; }
            remove { m_ElecTicketPoolEvent -= value; }
        }
        /// <summary>
        /// 批量国际结算事件
        /// </summary>
        public event EventHandler<TransferGlobalEventArgs> OnTransferGlobalEventHandler
        {
            add { m_TransferGlobalEvent += value; }
            remove { m_TransferGlobalEvent -= value; }
        }
        /// <summary>
        /// 国际结算币种类型变更事件
        /// </summary>
        public event EventHandler<CashTypeChangedEventArgs> OnCashTypeChangedEventHandler
        {
            add { m_CashTypeChangedEvent += value; }
            remove { m_CashTypeChangedEvent -= value; }
        }
        /// <summary>
        /// 国际结算收款人事件
        /// </summary>
        public event EventHandler<Payee4TransferGlobalEventArgs> OnPayeeInfo4TransferGlobalEventHandler
        {
            add { m_Payee4TransferGlobalEvent += value; }
            remove { m_Payee4TransferGlobalEvent -= value; }
        }
        /// <summary>
        /// 供应链-经销商融资申请事件
        /// </summary>
        public event EventHandler<SpplyFinancingApplyEventArgs> OnSpplyFinancingApplyEventHandler
        {
            add { m_SpplyFinancingApplyEvent += value; }
            remove { m_SpplyFinancingApplyEvent -= value; }
        }
        /// <summary>
        /// 供应链-应收账款卖/卖方发票事件
        /// </summary>
        public event EventHandler<SpplyFinancingBillEventArgs> OnSpplyFinancingBillEventHandler
        {
            add { m_SpplyFinancingBillEvent += value; }
            remove { m_SpplyFinancingBillEvent -= value; }
        }
        /// <summary>
        /// 供应链-应收账款卖/卖方收/付款事件
        /// </summary>
        public event EventHandler<SpplyFinancingPayOrReceiptEventArgs> OnSpplyFinancingPayOrReceiptEventHandler
        {
            add { m_SpplyFinancingPayOrReceiptEvent += value; }
            remove { m_SpplyFinancingPayOrReceiptEvent -= value; }
        }
        /// <summary>
        /// 供应链-应收账款卖/卖方订单事件
        /// </summary>
        public event EventHandler<SpplyFinancingOrderEventArgs> OnSpplyFinancingOrderEventHandler
        {
            add { m_SpplyFinancingOrderEvent += value; }
            remove { m_SpplyFinancingOrderEvent -= value; }
        }
        /// <summary>
        /// 快捷代收付款人事件
        /// </summary>
        public event EventHandler<PayeeEventArgs> OnAgentExpressPayerEventHandler
        {
            add { m_AgentExpressPayerEvent += value; }
            remove { m_AgentExpressPayerEvent -= value; }
        }
        /// <summary>
        /// 主动调拨事件
        /// </summary>
        public event EventHandler<InitiativeAllotEventArgs> OnInitiativeAllotEventHandler
        {
            add { m_InitiativeAllotEvent += value; }
            remove { m_InitiativeAllotEvent -= value; }
        }
        /// <summary>
        /// 主动调拨账户事件
        /// </summary>
        public event EventHandler<InitiativeAllotAccountEventArgs> OnInitiativeAllotAccountEventHandler
        {
            add { m_InitiativeAllotAccountEvent += value; }
            remove { m_InitiativeAllotAccountEvent -= value; }
        }
        /// <summary>
        /// 多语言变更事件
        /// </summary>
        public event EventHandler<LanguageChangedEventArgs> OnLanguageChangedEventHandler
        {
            add { m_LanguageChangedEvent += value; }
            remove { m_LanguageChangedEvent -= value; }
        }
        /// <summary>
        /// 设置中的操作事件
        /// 用于全选、反选、批量删除
        /// </summary>
        public event EventHandler<SettingsOperateEventArgs> OnSettingsOperateEventHandler
        {
            add { m_SettingsOperateEvent += value; }
            remove { m_SettingsOperateEvent -= value; }
        }
        /// <summary>
        /// 快捷代发中批用途变更事件
        /// </summary>
        public event EventHandler<AgentExpressPurposeEventArgs> OnAgentExpressPurposeEventHandler
        {
            add { m_AgentExpressPurposeEvent += value; }
            remove { m_AgentExpressPurposeEvent -= value; }
        }
        /// <summary>
        /// 贴入人银行号变更事件
        /// </summary>
        public event EventHandler<StickOnBankInfoEventArgs> OnStickOnBankInfoEventHandler
        {
            add { m_StickOnBankInfoEvent += value; }
            remove { m_StickOnBankInfoEvent -= value; }
        }
        /// <summary>
        /// 人民币统一支付事件
        /// </summary>
        public event EventHandler<UnitivePaymentRMBEventArgs> OnUnitivePaymentRMBEventHandler
        {
            add { m_UnitivePaymentRMBEvent += value; }
            remove { m_UnitivePaymentRMBEvent -= value; }
        }
        /// <summary>
        /// 外币统一支付事件
        /// </summary>
        public event EventHandler<UnitivePaymentFCEventArgs> OnUnitivePaymentFCEventHandler
        {
            add { m_UnitivePaymentFCEvent += value; }
            remove { m_UnitivePaymentFCEvent -= value; }
        }
        /// <summary>
        /// 外币统一支付收款人账号类型变更事件
        /// </summary>
        public event EventHandler<OverCountryPayeeAccountTypeEventArgs> OnOverCountryPayeeAccountTypeEventHandler
        {
            add { m_OverCountryPayeeAccountTypeEvent += value; }
            remove { m_OverCountryPayeeAccountTypeEvent -= value; }
        }
        /// <summary>
        /// 内部账户转账事件
        /// </summary>
        public event EventHandler<VirtualAccountEventArgs> OnVirtualAccountEventEventHandler
        {
            add { m_VirtualAccountEvent += value; }
            remove { m_VirtualAccountEvent -= value; }
        }
        public event EventHandler<VirtualAccountAllotEventArgs> OnVirtualAccountAllotEventEventHandler
        {
            add { m_VirtualAccountAllotEvent += value; }
            remove { m_VirtualAccountAllotEvent -= value; }
        }
        #endregion

        #region 私有事件
        private event EventHandler<PayerEventArgs> m_PayerInfoEvent;
        private event EventHandler<PayeeEventArgs> m_PayeeInfoEvent;
        private event EventHandler<TransferEventArgs> m_TransferEvent;
        private event EventHandler<AppliableEventArgs> m_AppliableEvent;
        private event EventHandler<NoticeEventArgs> m_NoticeEvent;
        private event EventHandler<AgentExpressEventArgs> m_AgentExpressEvent;
        private event EventHandler<AgentNormalEventArgs> m_AgentNormalEvent;
        private event EventHandler<RowIndexEventArgs> m_RowIndexEvent;
        private event EventHandler<CommonDataEventArgs> m_CommonDataEvent;
        private event EventHandler<EncryptionEventArgs> m_EncryptionEvent;
        private event EventHandler<FieldMappingEventArgs> m_FieldMappingEvent;
        private event EventHandler<ShowPanelEventArgs> m_ShowPanelEvent;
        private event EventHandler<UseTypeChangedEventArgs> m_UseTypeChangedEvent;
        private event EventHandler<CardTypeChangedEventArgs> m_CardTypeChangedEvent;
        private event EventHandler<MoveMenuEventArgs> m_MoveMenuEvent;
        private event EventHandler<QueryByRowIndexEventArgs> m_QueryByRowIndexEvent;
        private event EventHandler<BankTypeChangedEventArgs> m_BankTypeChangedEvent;
        private event EventHandler<EditEventArgs> m_EditEvent;
        private event EventHandler<ElecTicketRemitEventArgs> m_ElecTicketRemitEvent;
        private event EventHandler<ElecTicketRelateAccountEventArgs> m_ElecTicketRelateAccountEvent;
        private event EventHandler<ElecTicketTypeChangedEventArgs> m_ElecTicketTypeChangeEvent;
        private event EventHandler<ElecTicketAutoTipExchangeEventArgs> m_ElecTicketAutoTipExchangeEvent;
        private event EventHandler<ElecTicketBackNoteEventArgs> m_ElecTicketBackNoteEvent;
        private event EventHandler<ElecTicketPayMoneyEventArgs> m_ElecTicketPayMoneyEvent;
        private event EventHandler<ElecTicketPoolEventArgs> m_ElecTicketPoolEvent;
        private event EventHandler<TransferGlobalEventArgs> m_TransferGlobalEvent;
        private event EventHandler<CashTypeChangedEventArgs> m_CashTypeChangedEvent;
        private event EventHandler<Payee4TransferGlobalEventArgs> m_Payee4TransferGlobalEvent;
        private event EventHandler<SpplyFinancingApplyEventArgs> m_SpplyFinancingApplyEvent;
        private event EventHandler<SpplyFinancingBillEventArgs> m_SpplyFinancingBillEvent;
        private event EventHandler<SpplyFinancingPayOrReceiptEventArgs> m_SpplyFinancingPayOrReceiptEvent;
        private event EventHandler<SpplyFinancingOrderEventArgs> m_SpplyFinancingOrderEvent;
        private event EventHandler<PayeeEventArgs> m_AgentExpressPayerEvent;
        private event EventHandler<InitiativeAllotEventArgs> m_InitiativeAllotEvent;
        private event EventHandler<InitiativeAllotAccountEventArgs> m_InitiativeAllotAccountEvent;
        private event EventHandler<LanguageChangedEventArgs> m_LanguageChangedEvent;
        private event EventHandler<SettingsOperateEventArgs> m_SettingsOperateEvent;
        private event EventHandler<AgentExpressPurposeEventArgs> m_AgentExpressPurposeEvent;
        private event EventHandler<StickOnBankInfoEventArgs> m_StickOnBankInfoEvent;
        private event EventHandler<UnitivePaymentRMBEventArgs> m_UnitivePaymentRMBEvent;
        private event EventHandler<UnitivePaymentFCEventArgs> m_UnitivePaymentFCEvent;
        private event EventHandler<OverCountryPayeeAccountTypeEventArgs> m_OverCountryPayeeAccountTypeEvent;
        private event EventHandler<VirtualAccountEventArgs> m_VirtualAccountEvent;
        private event EventHandler<VirtualAccountAllotEventArgs> m_VirtualAccountAllotEvent;
        #endregion

        #region 处理业务方法
        /// <summary>
        /// 处理收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolvePayee(OperatorCommandType ct, PayeeInfo payee, AppliableFunctionType aft, int rowindex)
        {
            if (m_PayeeInfoEvent != null)
                m_PayeeInfoEvent(this, new PayeeEventArgs { Command = ct, PayeeInfo = payee.Clone() as PayeeInfo, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolvePayee(OperatorCommandType ct, List<PayeeInfo> payeeList, AppliableFunctionType aft)
        {
            if (m_PayeeInfoEvent != null)
                m_PayeeInfoEvent(this, new PayeeEventArgs { Command = ct, PayeeInfo = null, PayeeList = payeeList, OwnerType = aft });
        }
        /// <summary>
        /// 处理快捷代收付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolveAgentExpressPayer(OperatorCommandType ct, PayeeInfo payee, AppliableFunctionType aft, int rowindex)
        {
            if (m_AgentExpressPayerEvent != null)
                m_AgentExpressPayerEvent(this, new PayeeEventArgs { Command = ct, PayeeInfo = payee.Clone() as PayeeInfo, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理快捷代收付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolveAgentExpressPayer(OperatorCommandType ct, List<PayeeInfo> payeeList, AppliableFunctionType aft)
        {
            if (m_AgentExpressPayerEvent != null)
                m_AgentExpressPayerEvent(this, new PayeeEventArgs { Command = ct, PayeeInfo = null, PayeeList = payeeList, OwnerType = aft });
        }
        /// <summary>
        /// 处理付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payer">付款人信息</param>
        public void ResolvePayer(OperatorCommandType ct, List<PayerInfo> payerList, AppliableFunctionType aft)
        {
            if (m_PayerInfoEvent != null)
                m_PayerInfoEvent(this, new PayerEventArgs { Command = ct, PayerInfo = null, PayerList = payerList, OwnerType = aft });
        }
        /// <summary>
        /// 处理付款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payer">付款人信息</param>
        public void ResolvePayer(OperatorCommandType ct, PayerInfo payer, AppliableFunctionType aft, int rowindex)
        {
            if (m_PayerInfoEvent != null)
                m_PayerInfoEvent(this, new PayerEventArgs { Command = ct, PayerInfo = payer, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理转账汇款业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public void ResolveTransferAccount(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveTransferAccount(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理转账汇款业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public void ResolveTransferAccount(OperatorCommandType ct, TransferAccount transfer, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_TransferEvent)
                m_TransferEvent(this, new TransferEventArgs { Command = ct, TransferAccount = transfer, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理转账汇款业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="transfer">转账汇款信息</param>
        public void ResolveTransferAccount(OperatorCommandType ct, List<TransferAccount> transferList, AppliableFunctionType aft)
        {
            if (null != m_TransferEvent)
                m_TransferEvent(this, new TransferEventArgs { Command = ct, TransferAccountList = transferList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理功能可视化业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="type">功能可视化信息</param>
        public void ResolveAppliableFunction(OperatorCommandType ct, AppliableFunctionType type, AppliableFunctionType typeBar)
        {
            if (null != m_AppliableEvent)
                m_AppliableEvent(this, new AppliableEventArgs { Command = ct, AppVisiable = type, AppVisiableBar = typeBar });
        }
        /// <summary>
        /// 处理附言和用途业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="notice">附言及用途信息</param>
        public void ResolveNotice(OperatorCommandType ct, NoticeInfo notice, AppliableFunctionType aft)
        {
            if (null != m_NoticeEvent)
                m_NoticeEvent(this, new NoticeEventArgs { Command = ct, Notice = notice, OwnerType = aft });
        }
        /// <summary>
        /// 处理附言和用途业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="notice">附言及用途信息</param>
        public void ResolveNotice(OperatorCommandType ct, List<NoticeInfo> list, AppliableFunctionType aft)
        {
            if (null != m_NoticeEvent)
                m_NoticeEvent(this, new NoticeEventArgs { Command = ct, Notice = null, NoticeList = list, OwnerType = aft });
        }
        /// <summary>
        /// 处理快捷代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveAgentExpress(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveAgentExpress(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理快捷代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveAgentExpress(OperatorCommandType ct, AgentExpress ae, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_AgentExpressEvent)
                m_AgentExpressEvent(this, new AgentExpressEventArgs { AgentExpress = ae, Command = ct, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理快捷代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveAgentExpress(OperatorCommandType ct, List<AgentExpress> aelist, BatchHeader batch, AppliableFunctionType aft)
        {
            if (null != m_AgentExpressEvent)
                m_AgentExpressEvent(this, new AgentExpressEventArgs { AgentExpressList = aelist, BatchInfo = batch, Command = ct, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理普通代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveAgentNormal(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveAgentNormal(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理普通代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveAgentNormal(OperatorCommandType ct, AgentNormal ae, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_AgentNormalEvent)
                m_AgentNormalEvent(this, new AgentNormalEventArgs { AgentNormal = ae, Command = ct, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理普通代收、代发业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveAgentNormal(OperatorCommandType ct, List<AgentNormal> aeList, BatchHeader batch, AppliableFunctionType aft)
        {
            if (null != m_AgentNormalEvent)
                m_AgentNormalEvent(this, new AgentNormalEventArgs { AgentNormalList = aeList, BatchInfo = batch, Command = ct, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理主动调拨业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveInitiativeAllot(OperatorCommandType ct, AppliableFunctionType aft)
        {
            ResolveInitiativeAllot(ct, null, aft, -1);
        }
        /// <summary>
        /// 处理主动调拨业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveInitiativeAllot(OperatorCommandType ct, InitiativeAllot ae, AppliableFunctionType aft, int rowindex)
        {
            if (null != m_InitiativeAllotEvent)
                m_InitiativeAllotEvent(this, new InitiativeAllotEventArgs { InitiativeAllot = ae, Command = ct, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理主动调拨业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="ae"></param>
        /// <param name="aft"></param>
        public void ResolveInitiativeAllot(OperatorCommandType ct, List<InitiativeAllot> aelist, BatchHeader batch, AppliableFunctionType aft)
        {
            if (null != m_InitiativeAllotEvent)
                m_InitiativeAllotEvent(this, new InitiativeAllotEventArgs { InitiativeAllotList = aelist, BatchInfo = batch, Command = ct, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理操作数据航业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="rowindex"></param>
        /// <param name="aft"></param>
        public void ResolveRowIndex(OperatorCommandType ct, int rowindex, AppliableFunctionType aft)
        {
            if (null != m_RowIndexEvent)
                m_RowIndexEvent(this, new RowIndexEventArgs { RowIndex = rowindex, AppType = aft, Command = ct });
        }
        /// <summary>
        /// 处理公共数据业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="cft">公共数据信息</param>
        public void ResolveCommonData(OperatorCommandType ct, Dictionary<AppliableFunctionType, CommonFieldType> cftList)
        {
            if (null != m_CommonDataEvent)
                m_CommonDataEvent(this, new CommonDataEventArgs { Command = ct, CommonFields = cftList });
        }
        /// <summary>
        /// 处理快捷代发文件加密业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="isSetPwd">是否设置密码</param>
        /// <param name="password">加密密码</param>
        public void ResolveEncryption(OperatorCommandType ct, bool isSetPwd, string password, AppliableFunctionType aft)
        {
            if (null != m_EncryptionEvent)
                m_EncryptionEvent(this, new EncryptionEventArgs { IsSetPassword = isSetPwd, Password = password, Command = ct, AppType = aft });
        }
        /// <summary>
        /// 处理批量设置业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="aft">功能模块</param>
        /// <param name="mrs">设置信息</param>
        public void ResolveFieldMapping(OperatorCommandType ct, AppliableFunctionType aft, MappingsRelationSettings mrs, FunctionInSettingType batchAppType, FunctionInSettingType fst)
        {
            if (null != m_FieldMappingEvent)
                m_FieldMappingEvent(this, new FieldMappingEventArgs { AppType = aft, Command = ct, Mappings = mrs, BatchAppType = batchAppType, FunType = fst });
        }
        /// <summary>
        /// 处理打开中行格式文件业务
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        public ResultData ResolveOpenFile(string filepath, OperatorCommandType command, AppliableFunctionType aft, bool isBOC, string pwd)
        {
            ResultData rd = new ResultData() { Result = true };
            bool isPWDFile = false;
            if (filepath.ToLower().EndsWith(".sef"))
            {
                isPWDFile = true;
                try
                {
                    filepath = MatchFile.FileDataPasswordHelper.Instance.MakeFromPWD(filepath, SystemSettings.Instance.ShortProxyOutPassword);
                    if (!System.IO.File.Exists(filepath)) throw new Exception();
                }
                catch { rd = new ResultData { Result = false, Message = "解密失败" }; }
            }
            else if (filepath.ToLower().EndsWith(".dat"))
            {
                isPWDFile = true;
                string targetPath = DataConvertHelper.Instance.FormatFileName(filepath, ".bar");
                try
                {
                    ResultData rdt = MatchFile.FileDataPasswordBarHelper.Instance.DecodeAndUnzip(filepath, targetPath, pwd);
                    if (!rdt.Result) return rdt;
                    filepath = targetPath;
                }
                catch { rd = new ResultData { Result = false, Message = "解密失败" }; }
            }
            rd = !rd.Result ? rd : TemplateHelper.BatchConsignDataTemplateHelper.Instance.LoadBOCDocument(aft, command, filepath, isBOC);

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
        public void ResolveShowPanel(OperatorCommandType command, AppliableFunctionType aft, FunctionInSettingType fst)
        {
            if (null != m_ShowPanelEvent)
                m_ShowPanelEvent(this, new ShowPanelEventArgs { AppType = aft, Command = command, BatchAppType = fst });
        }
        /// <summary>
        /// 处理用途变更业务
        /// </summary>
        /// <param name="useType"></param>
        /// <param name="aft"></param>
        public void ResolveUseTypeChanged(OperatorCommandType command, AgentBusinessType useType, AppliableFunctionType aft, bool isRollBank)
        {
            if (null != m_UseTypeChangedEvent)
                m_UseTypeChangedEvent(this, new UseTypeChangedEventArgs { AppType = aft, UseType = useType, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理代发卡类型变更业务
        /// </summary>
        /// <param name="act"></param>
        /// <param name="aft"></param>
        public void ResolveCardTypeChanged(OperatorCommandType command, AppliableFunctionType aft, AgentCardType act, bool isRollBank)
        {
            if (null != m_CardTypeChangedEvent)
                m_CardTypeChangedEvent(this, new CardTypeChangedEventArgs { AppType = aft, CardType = act, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理外币统一支付中的收款人账号类型变更业务
        /// </summary>
        /// <param name="act"></param>
        /// <param name="aft"></param>
        public void ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType command, AppliableFunctionType aft, OverCountryPayeeAccountType act, bool isRollBank)
        {
            if (null != m_OverCountryPayeeAccountTypeEvent)
                m_OverCountryPayeeAccountTypeEvent(this, new OverCountryPayeeAccountTypeEventArgs { AppType = aft, AccountType = act, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理菜单控制业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="showIndex"></param>
        /// <param name="showCount"></param>
        public void ResolveMoveMenu(OperatorCommandType command, int showIndex, int showCount, int showmaxwidth, int startposition, int endposition, OperatorCommandType batchcommand)
        {
            if (null != m_MoveMenuEvent)
                m_MoveMenuEvent(this, new MoveMenuEventArgs { Command = command, ShowIndex = showIndex, ShowCount = showCount, ShowMaxWidth = showmaxwidth, Startposition = startposition, Endposition = endposition, BatchCommand = batchcommand });
        }
        /// <summary>
        /// 处理数据查询业务
        /// </summary>
        /// <param name="rowindex"></param>
        /// <param name="aft"></param>
        public void ResolveQueryData(int rowindex, AppliableFunctionType aft)
        {
            if (null != m_QueryByRowIndexEvent)
                m_QueryByRowIndexEvent(this, new QueryByRowIndexEventArgs { RowIndex = rowindex - 1, AppType = aft });
        }
        /// <summary>
        /// 处理银行类型变更业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="bankType"></param>
        /// <param name="isRollBank"></param>
        public void ResolveBankTypeChanged(OperatorCommandType command, AppliableFunctionType aft, AgentTransferBankType bankType, bool isRollBank)
        {
            if (null != m_BankTypeChangedEvent)
                m_BankTypeChangedEvent(this, new BankTypeChangedEventArgs { AppType = aft, BankType = bankType, Command = command, IsRollBack = isRollBank });
        }
        /// <summary>
        /// 处理编辑操作业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveEditOperator(OperatorCommandType command, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_EditEvent)
                m_EditEvent(this, new EditEventArgs { Command = command, AppType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量出票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketRemit(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveElecTicketRemit(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量出票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketRemit(OperatorCommandType command, ElecTicketRemit ett, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketRemitEvent)
                m_ElecTicketRemitEvent(this, new ElecTicketRemitEventArgs { Command = command, ElecTicketRemit = ett, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量出票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketRemit(OperatorCommandType command, List<ElecTicketRemit> ettList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketRemitEvent)
                m_ElecTicketRemitEvent(this, new ElecTicketRemitEventArgs { Command = command, ElecTicketRemitList = ettList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理关系人维护业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ra"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketRelateAccount(OperatorCommandType command, ElecTicketRelationAccount ra, int rowIndex)
        {
            if (null != m_ElecTicketRelateAccountEvent)
                m_ElecTicketRelateAccountEvent(this, new ElecTicketRelateAccountEventArgs { Command = command, RelationAccount = ra, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理关系人维护业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ra"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketRelateAccount(OperatorCommandType command, List<ElecTicketRelationAccount> raList)
        {
            if (null != m_ElecTicketRelateAccountEvent)
                m_ElecTicketRelateAccountEvent(this, new ElecTicketRelateAccountEventArgs { Command = command, RelationAccountList = raList });
        }
        /// <summary>
        /// 处理票据类型变更业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="ett"></param>
        /// <param name="rpt"></param>
        public void ResolveElecTicketTypeChanged(OperatorCommandType command, AppliableFunctionType aft, ElecTicketType ett, RelatePersonType rpt)
        {
            if (null != m_ElecTicketTypeChangeEvent)
                m_ElecTicketTypeChangeEvent(this, new ElecTicketTypeChangedEventArgs { OwnerType = aft, TicketType = ett, RelateAccountType = rpt, Command = command });
        }
        /// <summary>
        /// 处理批量电票自动提示承兑业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketAutoTipExchange(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveElecTicketAutoTipExchange(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量电票自动提示承兑业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketAutoTipExchange(OperatorCommandType command, ElecTicketAutoTipExchange etate, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketAutoTipExchangeEvent)
                m_ElecTicketAutoTipExchangeEvent(this, new ElecTicketAutoTipExchangeEventArgs { Command = command, ElecTicketAutoTipExchange = etate, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量电票自动提示承兑业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketAutoTipExchange(OperatorCommandType command, List<ElecTicketAutoTipExchange> etateList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketAutoTipExchangeEvent)
                m_ElecTicketAutoTipExchangeEvent(this, new ElecTicketAutoTipExchangeEventArgs { Command = command, ElecTicketAutoTipExchangeList = etateList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量电票背书业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketBackNote(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveElecTicketBackNote(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量电票背书业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketBackNote(OperatorCommandType command, ElecTicketBackNote etate, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketBackNoteEvent)
                m_ElecTicketBackNoteEvent(this, new ElecTicketBackNoteEventArgs { Command = command, ElecTicketBackNote = etate, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量电票背书业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketBackNote(OperatorCommandType command, List<ElecTicketBackNote> etateList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketBackNoteEvent)
                m_ElecTicketBackNoteEvent(this, new ElecTicketBackNoteEventArgs { Command = command, ElecTicketBackNoteList = etateList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量电票贴现业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketPayMoney(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveElecTicketPayMoney(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量电票贴现业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketPayMoney(OperatorCommandType command, ElecTicketPayMoney etate, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_ElecTicketPayMoneyEvent(this, new ElecTicketPayMoneyEventArgs { Command = command, ElecTicketPayMoney = etate, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量电票贴现业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketPayMoney(OperatorCommandType command, List<ElecTicketPayMoney> etateList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_ElecTicketPayMoneyEvent(this, new ElecTicketPayMoneyEventArgs { Command = command, ElecTicketPayMoneyList = etateList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量票据池业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketPool(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveElecTicketPool(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量票据池业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketPool(OperatorCommandType command, ElecTicketPool etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketPoolEvent)
                m_ElecTicketPoolEvent(this, new ElecTicketPoolEventArgs { Command = command, ElecTicketPool = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量票据池业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveElecTicketPool(OperatorCommandType command, List<ElecTicketPool> etpList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_ElecTicketPoolEvent(this, new ElecTicketPoolEventArgs { Command = command, ElecTicketPoolList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量国际结算业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveTransferGlobal(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveTransferGlobal(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量国际结算业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveTransferGlobal(OperatorCommandType command, TransferGlobal etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_TransferGlobalEvent(this, new TransferGlobalEventArgs { Command = command, TransferGlobal = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量国际结算业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveTransferGlobal(OperatorCommandType command, List<TransferGlobal> etpList, AppliableFunctionType aft)
        {
            if (null != m_ElecTicketPayMoneyEvent)
                m_TransferGlobalEvent(this, new TransferGlobalEventArgs { Command = command, TransferGlobalList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理币种类型变更业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="aft"></param>
        public void ResolveCashTypeChanged(OperatorCommandType command, CashType ct, AppliableFunctionType aft, bool isrollback)
        {
            if (null != m_CashTypeChangedEvent)
                m_CashTypeChangedEvent(this, new CashTypeChangedEventArgs { Command = command, CashType = ct, AppType = aft, IsRollBack = isrollback });
        }
        /// <summary>
        /// 处理国际结算收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolvePayee4TransferGlobal(OperatorCommandType ct, PayeeInfo4TransferGlobal payee, AppliableFunctionType aft, int rowindex)
        {
            if (m_Payee4TransferGlobalEvent != null)
                m_Payee4TransferGlobalEvent(this, new Payee4TransferGlobalEventArgs { Command = ct, PayeeInfo = payee, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理国际结算收款人信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolvePayee4TransferGlobal(OperatorCommandType ct, List<PayeeInfo4TransferGlobal> payeeList, AppliableFunctionType aft)
        {
            if (m_Payee4TransferGlobalEvent != null)
                m_Payee4TransferGlobalEvent(this, new Payee4TransferGlobalEventArgs { Command = ct, PayeeInfo = null, PayeeList = payeeList, OwnerType = aft });
        }
        /// <summary>
        /// 处理批量经销商融资申请业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingApply(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveSpplyFinancingApply(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量经销商融资申请业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingApply(OperatorCommandType command, SpplyFinancingApply etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingApplyEvent)
                m_SpplyFinancingApplyEvent(this, new SpplyFinancingApplyEventArgs { Command = command, SpplyFinancingApply = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量经销商融资申请业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingApply(OperatorCommandType command, List<SpplyFinancingApply> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingApplyEvent)
                m_SpplyFinancingApplyEvent(this, new SpplyFinancingApplyEventArgs { Command = command, SpplyFinancingApplyList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/买方发票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingBill(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveSpplyFinancingBill(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/买方发票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingBill(OperatorCommandType command, SpplyFinancingBill etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingBillEvent)
                m_SpplyFinancingBillEvent(this, new SpplyFinancingBillEventArgs { Command = command, SpplyFinancingBill = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/买方发票业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingBill(OperatorCommandType command, List<SpplyFinancingBill> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingBillEvent)
                m_SpplyFinancingBillEvent(this, new SpplyFinancingBillEventArgs { Command = command, SpplyFinancingBillList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/卖方收/付款业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingPayOrReceipt(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveSpplyFinancingPayOrReceipt(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/卖方收/付款业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingPayOrReceipt(OperatorCommandType command, SpplyFinancingPayOrReceipt etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingPayOrReceiptEvent)
                m_SpplyFinancingPayOrReceiptEvent(this, new SpplyFinancingPayOrReceiptEventArgs { Command = command, SpplyFinancingPayOrReceipt = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量供应链-应收账款卖/卖方收/付款业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingPayOrReceipt(OperatorCommandType command, List<SpplyFinancingPayOrReceipt> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingPayOrReceiptEvent)
                m_SpplyFinancingPayOrReceiptEvent(this, new SpplyFinancingPayOrReceiptEventArgs { Command = command, SpplyFinancingPayOrReceiptList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量卖/买方订单提交业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingOrder(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveSpplyFinancingOrder(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量卖/买方订单提交业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingOrder(OperatorCommandType command, SpplyFinancingOrder etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_SpplyFinancingOrderEvent)
                m_SpplyFinancingOrderEvent(this, new SpplyFinancingOrderEventArgs { Command = command, SpplyFinancingOrder = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量卖/买方订单提交业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveSpplyFinancingOrder(OperatorCommandType command, List<SpplyFinancingOrder> etpList, AppliableFunctionType aft)
        {
            if (null != m_SpplyFinancingOrderEvent)
                m_SpplyFinancingOrderEvent(this, new SpplyFinancingOrderEventArgs { Command = command, SpplyFinancingOrderList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理主动调拨账户信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="initiativeAllotAccount">收款人信息</param>
        public void ResolveInitiativeAllotAccount(OperatorCommandType ct, InitiativeAllotAccount initiativeAllotAccount, AppliableFunctionType aft, int rowindex)
        {
            if (m_InitiativeAllotAccountEvent != null)
                m_InitiativeAllotAccountEvent(this, new InitiativeAllotAccountEventArgs { Command = ct, InitiativeAllotAccount = initiativeAllotAccount, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理主动调拨账户信息业务
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">收款人信息</param>
        public void ResolveInitiativeAllotAccount(OperatorCommandType ct, List<InitiativeAllotAccount> initiativeAllotAccountList, AppliableFunctionType aft)
        {
            if (m_InitiativeAllotAccountEvent != null)
                m_InitiativeAllotAccountEvent(this, new InitiativeAllotAccountEventArgs { Command = ct, InitiativeAllotAccount = null, InitiativeAllotAccountList = initiativeAllotAccountList, OwnerType = aft });
        }
        /// <summary>
        /// 处理多语言变更业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="lang"></param>
        public void ResolveLanguageChanged(OperatorCommandType ct, UILang lang)
        {
            if (m_LanguageChangedEvent != null)
                m_LanguageChangedEvent(this, new LanguageChangedEventArgs { Language = lang, Command = ct });
        }
        /// <summary>
        /// 处理设置中的操作业务
        /// 用于全选、反选、批量删除
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="aft"></param>
        public void ResolveSettingsOperate(OperatorCommandType ct, FunctionInSettingType fst)
        {
            if (m_SettingsOperateEvent != null)
                m_SettingsOperateEvent(this, new SettingsOperateEventArgs { FunctionType = fst, Command = ct });
        }
        /// <summary>
        /// 处理快捷代发中批用途变更业务
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="fst"></param>
        public void ResolveAgentExpressPurpose(OperatorCommandType ct, AppliableFunctionType aft, AgentExpressFunctionType aeft, bool isrollback)
        {
            if (m_AgentExpressPurposeEvent != null)
                m_AgentExpressPurposeEvent(this, new AgentExpressPurposeEventArgs { Owner = aft, Command = ct, Purpose = aeft, IsRollBack = isrollback });
        }
        /// <summary>
        /// 处理贴入人银行信息变更业务
        /// </summary>
        /// <param name="bankname"></param>
        /// <param name="bankno"></param>
        public void ResolveStickOnBankInfo(string bankname, string bankno)
        {
            if (null != m_StickOnBankInfoEvent)
                m_StickOnBankInfoEvent(this, new StickOnBankInfoEventArgs { BankName = bankname, BankNo = bankno });
        }
        /// <summary>
        /// 处理批量人民币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveUnitivePaymentRMB(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveUnitivePaymentRMB(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量人民币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveUnitivePaymentRMB(OperatorCommandType command, UnitivePaymentRMB etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_UnitivePaymentRMBEvent)
                m_UnitivePaymentRMBEvent(this, new UnitivePaymentRMBEventArgs { Command = command, UnitivePaymentRMB = etp, OwnerType = aft, RowIndex = rowIndex });
        }
        /// <summary>
        /// 处理批量人民币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveUnitivePaymentRMB(OperatorCommandType command, List<UnitivePaymentRMB> etpList, AppliableFunctionType aft)
        {
            if (null != m_UnitivePaymentRMBEvent)
                m_UnitivePaymentRMBEvent(this, new UnitivePaymentRMBEventArgs { Command = command, UnitivePaymentRMBList = etpList, OwnerType = aft, RowIndex = -1 });
        }
        /// <summary>
        /// 处理批量外币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveUnitivePaymentFC(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveUnitivePaymentFC(command, null, aft, -1, OverCountryPayeeAccountType.Empty);
        }
        /// <summary>
        /// 处理批量外币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveUnitivePaymentFC(OperatorCommandType command, UnitivePaymentForeignMoney etp, AppliableFunctionType aft, int rowIndex, OverCountryPayeeAccountType at)
        {
            if (null != m_UnitivePaymentFCEvent)
                m_UnitivePaymentFCEvent(this, new UnitivePaymentFCEventArgs { Command = command, UnitivePaymentFC = etp, OwnerType = aft, RowIndex = rowIndex, AccountType = at });
        }
        /// <summary>
        /// 处理批量外币统一支付业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveUnitivePaymentFC(OperatorCommandType command, List<UnitivePaymentForeignMoney> etpList, AppliableFunctionType aft, OverCountryPayeeAccountType at)
        {
            if (null != m_UnitivePaymentFCEvent)
                m_UnitivePaymentFCEvent(this, new UnitivePaymentFCEventArgs { Command = command, UnitivePaymentFCList = etpList, OwnerType = aft, RowIndex = -1, AccountType = at });
        }
        /// <summary>
        /// 处理批量内部账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveVirtualAccount(OperatorCommandType command, AppliableFunctionType aft)
        {
            this.ResolveVirtualAccount(command, null, aft, -1);
        }
        /// <summary>
        /// 处理批量内部账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveVirtualAccount(OperatorCommandType command, VirtualAccount etp, AppliableFunctionType aft, int rowIndex)
        {
            if (null != m_VirtualAccountEvent)
                m_VirtualAccountEvent(this, new VirtualAccountEventArgs { Command = command, InitiativeAccount = etp, OwnerType = aft, RowIndex = rowIndex});
        }
        /// <summary>
        /// 处理批量内部账户转账业务
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aft"></param>
        /// <param name="rowIndex"></param>
        public void ResolveVirtualAccount(OperatorCommandType command, List<VirtualAccount> etpList, AppliableFunctionType aft)
        {
            if (null != m_VirtualAccountEvent)
                m_VirtualAccountEvent(this, new VirtualAccountEventArgs { Command = command, VirtualAccountList = etpList, OwnerType = aft, RowIndex = -1});
        }
        /// <summary>
        /// 处理内部账户转账信息
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="initiativeAllotAccount">账户信息</param>
        public void ResolveVirtualAllotAccount(OperatorCommandType ct, VirtualAccountInfo initiativeAllotAccount, AppliableFunctionType aft, int rowindex)
        {
            if (m_VirtualAccountAllotEvent != null)
                m_VirtualAccountAllotEvent(this, new VirtualAccountAllotEventArgs { Command = ct, VirtualAllotAccount = initiativeAllotAccount, OwnerType = aft, RowIndex = rowindex });
        }
        /// <summary>
        /// 处理内部账户转账信息
        /// </summary>
        /// <param name="ct">操作类型</param>
        /// <param name="payee">账户信息</param>
        public void ResolveVirtualAllotAccount(OperatorCommandType ct, List<VirtualAccountInfo> initiativeAllotAccountList, AppliableFunctionType aft)
        {
            if (m_VirtualAccountAllotEvent != null)
                m_VirtualAccountAllotEvent(this, new VirtualAccountAllotEventArgs { Command = ct, VirtualAllotAccount = null, VirtualAllotAccountList = initiativeAllotAccountList, OwnerType = aft });
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
        public PayerInfo PayerInfo
        {
            get
            {
                return m_PayerInfo;
            }
            set
            {
                m_PayerInfo = value;
            }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get
            {
                return m_command;
            }
            set
            {
                m_command = value;
            }
        }
        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get
            {
                return m_BatchCommand;
            }
            set
            {
                m_BatchCommand = value;
            }
        }
        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenerType; }
            set { m_OwenerType = value; }
        }
        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowindex; }
            set { m_rowindex = value; }
        }
        /// <summary>
        /// 付款人列表
        /// </summary>
        public List<PayerInfo> PayerList
        {
            get { return m_PayerList; }
            set { m_PayerList = value; }
        }

        private List<PayerInfo> m_PayerList;
        private PayerInfo m_PayerInfo;
        private OperatorCommandType m_command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenerType;
        private int m_rowindex;

        public PayerEventArgs()
        {
            m_PayerInfo = null;
            m_command = m_BatchCommand = OperatorCommandType.Empty;
            m_PayerList = new List<PayerInfo>();
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
        public PayeeInfo PayeeInfo
        {
            get
            {
                return m_PayeeInfo;
            }
            set
            {
                m_PayeeInfo = value;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get
            {
                return m_Command;
            }
            set
            {
                m_Command = value;
            }
        }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get
            {
                return m_BatchCommand;
            }
            set
            {
                m_BatchCommand = value;
            }
        }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenType; }
            set { m_OwenType = value; }
        }

        /// <summary>
        /// 收款人信息
        /// </summary>
        public List<PayeeInfo> PayeeList
        {
            get { return m_PayeeList; }
            set { m_PayeeList = value; }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        private PayeeInfo m_PayeeInfo;
        private List<PayeeInfo> m_PayeeList;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenType;
        private int m_RowIndex;

        public PayeeEventArgs()
        {
            m_PayeeInfo = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenType = AppliableFunctionType._Empty;
            m_PayeeList = new List<PayeeInfo>();
            m_RowIndex = 0;
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
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        /// <summary>
        /// 收款人信息
        /// </summary>
        public TransferAccount TransferAccount
        {
            get
            {
                return m_TransferAccount;
            }
            set
            {
                m_TransferAccount = value;
            }
        }

        /// <summary>
        /// 转账列表
        /// </summary>
        public List<TransferAccount> TransferAccountList
        {
            get { return m_TransferAccountList; }
            set { m_TransferAccountList = value; }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get
            {
                return m_Command;
            }
            set
            {
                m_Command = value;
            }
        }

        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenerType; }
            set { m_OwenerType = value; }
        }

        private int m_RowIndex;
        private TransferAccount m_TransferAccount;
        private OperatorCommandType m_Command;
        private AppliableFunctionType m_OwenerType;
        private List<TransferAccount> m_TransferAccountList;

        public TransferEventArgs()
        {
            m_RowIndex = -1;
            m_Command = OperatorCommandType.Empty;
            m_TransferAccount = null;
            m_TransferAccountList = new List<TransferAccount>();
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
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        /// <summary>
        /// 功能可视化参数
        /// </summary>
        public AppliableFunctionType AppVisiable
        {
            get { return m_AppVisiable; }
            set { m_AppVisiable = value; }
        }
        /// <summary>
        /// 柜台功能可视化参数
        /// </summary>
        public AppliableFunctionType AppVisiableBar
        {
            get { return m_AppVisiableBar; }
            set { m_AppVisiableBar = value; }
        }

        private OperatorCommandType m_Command;
        private AppliableFunctionType m_AppVisiable;
        private AppliableFunctionType m_AppVisiableBar;

        public AppliableEventArgs()
        {
            m_Command = OperatorCommandType.Empty;
            m_AppVisiable = m_AppVisiableBar = AppliableFunctionType._Empty;
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
        public OperatorCommandType Command
        {
            get
            {
                return m_Command;
            }
            set
            {
                m_Command = value;
            }
        }
        /// <summary>
        /// 附言和用途
        /// </summary>
        public NoticeInfo Notice
        {
            get
            {
                return m_Notice;
            }
            set
            {
                m_Notice = value;
            }
        }
        /// <summary>
        /// 附言和用途
        /// </summary>
        public List<NoticeInfo> NoticeList
        {
            get { return m_NoticeList; }
            set { m_NoticeList = value; }
        }
        /// <summary>
        /// 本次操作所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenerType; }
            set { m_OwenerType = value; }
        }

        private OperatorCommandType m_Command;
        private NoticeInfo m_Notice;
        private AppliableFunctionType m_OwenerType;
        private List<NoticeInfo> m_NoticeList;

        public NoticeEventArgs()
        {
            m_Command = OperatorCommandType.Empty;
            m_Notice = null;
            m_NoticeList = new List<NoticeInfo>();
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
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        /// <summary>
        /// 快捷代收、代发信息
        /// </summary>
        public AgentExpress AgentExpress
        {
            get
            { return m_AgentExpress; }
            set { m_AgentExpress = value; }
        }
        /// <summary>
        /// 快捷代收、代发信息
        /// </summary>
        public List<AgentExpress> AgentExpressList
        {
            get
            {
                return m_AgentExpressList;
            }
            set { m_AgentExpressList = value; }
        }
        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader BatchInfo
        {
            get { return m_BatchInfo; }
            set { m_BatchInfo = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get { return m_BatchCommand; }
            set { m_BatchCommand = value; }
        }
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenerType; }
            set { m_OwenerType = value; }
        }
        private int m_RowIndex;
        private AgentExpress m_AgentExpress;
        private List<AgentExpress> m_AgentExpressList;
        private BatchHeader m_BatchInfo;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenerType;

        public AgentExpressEventArgs()
        {
            m_RowIndex = -1;
            m_AgentExpress = null;
            m_AgentExpressList = new List<Entities.AgentExpress>();
            m_BatchInfo = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenerType = AppliableFunctionType._Empty;
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
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        /// <summary>
        /// 普通代收、代发信息
        /// </summary>
        public AgentNormal AgentNormal
        {
            get
            {
                return m_AgentNormal;
            }
            set { m_AgentNormal = value; }
        }
        /// <summary>
        /// 普通代收、代发信息
        /// </summary>
        public List<AgentNormal> AgentNormalList
        {
            get
            {
                return m_AgentNormalList;
            }
            set { m_AgentNormalList = value; }
        }
        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader BatchInfo
        {
            get { return m_BatchInfo; }
            set { m_BatchInfo = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get { return m_BatchCommand; }
            set { m_BatchCommand = value; }
        }
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenerType; }
            set { m_OwenerType = value; }
        }

        private int m_RowIndex;
        private AgentNormal m_AgentNormal;
        private List<AgentNormal> m_AgentNormalList;
        private BatchHeader m_BatchInfo;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenerType;

        public AgentNormalEventArgs()
        {
            m_RowIndex = -1;
            m_AgentNormal = null;
            m_AgentNormalList = new List<Entities.AgentNormal>();
            m_BatchInfo = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenerType = AppliableFunctionType._Empty;
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
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        /// <summary>
        /// 主动调拨信息
        /// </summary>
        public InitiativeAllot InitiativeAllot
        {
            get
            { return m_InitiativeAllot; }
            set { m_InitiativeAllot = value; }
        }
        /// <summary>
        /// 主动调拨信息
        /// </summary>
        public List<InitiativeAllot> InitiativeAllotList
        {
            get
            {
                return m_InitiativeAllotList;
            }
            set { m_InitiativeAllotList = value; }
        }
        /// <summary>
        /// 批信息
        /// </summary>
        public BatchHeader BatchInfo
        {
            get { return m_BatchInfo; }
            set { m_BatchInfo = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get { return m_BatchCommand; }
            set { m_BatchCommand = value; }
        }
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenerType; }
            set { m_OwenerType = value; }
        }
        private int m_RowIndex;
        private InitiativeAllot m_InitiativeAllot;
        private List<InitiativeAllot> m_InitiativeAllotList;
        private BatchHeader m_BatchInfo;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenerType;

        public InitiativeAllotEventArgs()
        {
            m_RowIndex = -1;
            m_InitiativeAllot = null;
            m_InitiativeAllotList = new List<Entities.InitiativeAllot>();
            m_BatchInfo = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenerType = AppliableFunctionType._Empty;
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
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        /// <summary>
        /// 所属功能模块类型
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        private int m_RowIndex;
        private OperatorCommandType m_Command;
        private AppliableFunctionType m_AppType;

        public RowIndexEventArgs()
        {
            m_RowIndex = -1;
            m_Command = OperatorCommandType.Empty;
            m_AppType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 公共数据参数
    /// </summary>
    public class CommonDataEventArgs : EventArgs
    {
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
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
            m_Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 文件加密密码参数
    /// </summary>
    public class EncryptionEventArgs : EventArgs
    {
        private bool m_IsSetPassword;
        /// <summary>
        /// 是否设置快捷代发加密密码
        /// </summary>
        public bool IsSetPassword
        {
            get { return m_IsSetPassword; }
            set { m_IsSetPassword = value; }
        }
        private string m_Password;
        /// <summary>
        /// 加密密码
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        public EncryptionEventArgs()
        {
            m_IsSetPassword = false;
            m_Password = string.Empty;
            m_AppType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 批量设置参数
    /// </summary>
    public class FieldMappingEventArgs : EventArgs
    {
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操纵类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private MappingsRelationSettings m_Mappings;
        /// <summary>
        /// 数据项映射关系
        /// </summary>
        public MappingsRelationSettings Mappings
        {
            get { return m_Mappings; }
            set { m_Mappings = value; }
        }
        private FunctionInSettingType m_BatchAppType;
        /// <summary>
        /// 子功能信息
        /// </summary>
        public FunctionInSettingType BatchAppType
        {
            get { return m_BatchAppType; }
            set { m_BatchAppType = value; }
        }
        private FunctionInSettingType m_funType;
        /// <summary>
        /// 设置中的菜单
        /// 默认填写批量转换设置选项
        /// </summary>
        public FunctionInSettingType FunType
        {
            get { return m_funType; }
            set { m_funType = value; }
        }

        public FieldMappingEventArgs()
        {
            m_AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            m_Mappings = new MappingsRelationSettings();
            m_BatchAppType = FunctionInSettingType.Empty;
            m_funType = FunctionInSettingType.Empty;
        }
    }
    /// <summary>
    /// 模块控制参数
    /// </summary>
    public class ShowPanelEventArgs : EventArgs
    {
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 命令类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private FunctionInSettingType m_BatchAppType;
        /// <summary>
        /// 子功能类型
        /// </summary>
        public FunctionInSettingType BatchAppType
        {
            get { return m_BatchAppType; }
            set { m_BatchAppType = value; }
        }
        public ShowPanelEventArgs()
        {
            m_AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            m_BatchAppType = FunctionInSettingType.Empty;
        }
    }
    /// <summary>
    /// 用途类型变化参数
    /// </summary>
    public class UseTypeChangedEventArgs : EventArgs
    {
        private AgentBusinessType m_useTypeStr;
        /// <summary>
        /// 用途
        /// </summary>
        public AgentBusinessType UseType
        {
            get { return m_useTypeStr; }
            set { m_useTypeStr = value; }
        }
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private bool m_isRollBack;
        /// <summary>
        /// 是否回滚操作
        /// </summary>
        public bool IsRollBack
        {
            get { return m_isRollBack; }
            set { m_isRollBack = value; }
        }
        public UseTypeChangedEventArgs()
        {
            m_useTypeStr = AgentBusinessType.Salary;
            m_AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            m_isRollBack = false;
        }
    }
    /// <summary>
    /// 代发卡类型变化参数
    /// </summary>
    public class CardTypeChangedEventArgs : EventArgs
    {
        private AgentCardType m_CardType;
        /// <summary>
        /// 代发卡类型
        /// </summary>
        public AgentCardType CardType
        {
            get { return m_CardType; }
            set { m_CardType = value; }
        }
        /// <summary>
        /// 代发卡类型
        /// </summary>
        public string CardTypeString
        {
            get { return EnumNameHelper<AgentCardType>.GetEnumDescription(m_CardType); }
        }
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private bool m_IsRollBack;
        /// <summary>
        /// 是否回滚
        /// </summary>
        public bool IsRollBack
        {
            get { return m_IsRollBack; }
            set { m_IsRollBack = value; }
        }
        public CardTypeChangedEventArgs()
        {
            m_CardType = AgentCardType.Empty;
            m_AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            m_IsRollBack = false;
        }
    }
    /// <summary>
    /// 菜单滚动控制参数
    /// </summary>
    public class MoveMenuEventArgs : EventArgs
    {
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作命令
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private int m_ShowIndex;
        /// <summary>
        /// 当前选中的索引
        /// </summary>
        public int ShowIndex
        {
            get { return m_ShowIndex; }
            set { m_ShowIndex = value; }
        }
        private int m_ShowCount;
        /// <summary>
        /// 当前显示的数量
        /// </summary>
        public int ShowCount
        {
            get { return m_ShowCount; }
            set { m_ShowCount = value; }
        }
        private int m_startposition;
        /// <summary>
        /// 最左端位置
        /// </summary>
        public int Startposition
        {
            get { return m_startposition; }
            set { m_startposition = value; }
        }
        private int m_emdposition;
        /// <summary>
        /// 最右端位置
        /// </summary>
        public int Endposition
        {
            get { return m_emdposition; }
            set { m_emdposition = value; }
        }
        private int m_showMaxWidth;
        /// <summary>
        /// 最大需要显示的宽度
        /// </summary>
        public int ShowMaxWidth
        {
            get { return m_showMaxWidth; }
            set { m_showMaxWidth = value; }
        }
        private OperatorCommandType m_BatchCommand;
        /// <summary>
        /// 子操作
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get { return m_BatchCommand; }
            set { m_BatchCommand = value; }
        }
        public MoveMenuEventArgs()
        {
            m_Command = OperatorCommandType.Empty;
            m_ShowCount = m_ShowIndex = 0;
            m_BatchCommand = OperatorCommandType.MoveMenuRaise;
        }
    }
    /// <summary>
    /// 行号查询参数
    /// </summary>
    public class QueryByRowIndexEventArgs : EventArgs
    {
        private int m_rowIndex;
        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        public QueryByRowIndexEventArgs()
        {
            m_rowIndex = -1;
            m_AppType = AppliableFunctionType._Empty;
        }
    }
    /// <summary>
    /// 银行类型变更参数
    /// </summary>
    public class BankTypeChangedEventArgs : EventArgs
    {
        private AgentTransferBankType m_BankType;
        /// <summary>
        /// 银行类型
        /// </summary>
        public AgentTransferBankType BankType
        {
            get { return m_BankType; }
            set { m_BankType = value; }
        }
        private bool m_IsRollBack;
        /// <summary>
        /// 是否回滚操作
        /// </summary>
        public bool IsRollBack
        {
            get { return m_IsRollBack; }
            set { m_IsRollBack = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private AppliableFunctionType m_AppType;
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        public BankTypeChangedEventArgs()
        {
            m_AppType = AppliableFunctionType._Empty;
            m_BankType = AgentTransferBankType.Boc;
            m_Command = OperatorCommandType.Empty;
            m_IsRollBack = false;
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
        private int m_RowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        public EditEventArgs()
        {
            m_AppType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            m_RowIndex = -1;
        }
    }
    /// <summary>
    /// 系统多语言参数
    /// </summary>
    public class LanguageChangedEventArgs : EventArgs
    {
        private UILang m_language;
        /// <summary>
        /// 当前系统语言
        /// </summary>
        public UILang Language
        {
            get { return m_language; }
            set { m_language = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        public LanguageChangedEventArgs()
        {
            m_Command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 电票出票业务参数
    /// </summary>
    public class ElecTicketRemitEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private ElecTicketRemit m_elecTicketRemit;
        /// <summary>
        /// 出票信息
        /// </summary>
        public ElecTicketRemit ElecTicketRemit
        {
            get { return m_elecTicketRemit; }
            set { m_elecTicketRemit = value; }
        }
        private List<ElecTicketRemit> m_elecTicketRemitList;
        /// <summary>
        /// 出票信息列表
        /// </summary>
        public List<ElecTicketRemit> ElecTicketRemitList
        {
            get { return m_elecTicketRemitList; }
            set { m_elecTicketRemitList = value; }
        }
        public ElecTicketRemitEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_elecTicketRemit = null;
            m_elecTicketRemitList = new List<ElecTicketRemit>();
        }
    }
    /// <summary>
    /// 关系人业务参数
    /// </summary>
    public class ElecTicketRelateAccountEventArgs : EventArgs
    {
        OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        ElecTicketRelationAccount m_RelationAccount;
        /// <summary>
        /// 关系人信息
        /// </summary>
        public ElecTicketRelationAccount RelationAccount
        {
            get { return m_RelationAccount; }
            set { m_RelationAccount = value; }
        }
        List<ElecTicketRelationAccount> m_relationAccountList;
        /// <summary>
        /// 关系人列表
        /// </summary>
        public List<ElecTicketRelationAccount> RelationAccountList
        {
            get { return m_relationAccountList; }
            set { m_relationAccountList = value; }
        }
        int m_rowindex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowindex; }
            set { m_rowindex = value; }
        }
        public ElecTicketRelateAccountEventArgs()
        {
            m_rowindex = 0;
            m_RelationAccount = null;
            m_command = OperatorCommandType.Empty;
            m_relationAccountList = new List<ElecTicketRelationAccount>();
        }
    }
    /// <summary>
    /// 票据类型变更参数
    /// </summary>
    public class ElecTicketTypeChangedEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_ownerType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_ownerType; }
            set { m_ownerType = value; }
        }
        private ElecTicketType m_ticketType;
        /// <summary>
        /// 票据类型
        /// </summary>
        public ElecTicketType TicketType
        {
            get { return m_ticketType; }
            set { m_ticketType = value; }
        }
        private RelatePersonType m_relateAccountType;
        /// <summary>
        /// 接收关系人类型
        /// </summary>
        public RelatePersonType RelateAccountType
        {
            get { return m_relateAccountType; }
            set { m_relateAccountType = value; }
        }
        public ElecTicketTypeChangedEventArgs()
        {
            m_command = OperatorCommandType.Empty;
            m_ownerType = AppliableFunctionType._Empty;
            m_ticketType = ElecTicketType.Empty;
            m_relateAccountType = RelatePersonType.Empty;
        }
    }
    /// <summary>
    /// 电票自动提示承兑参数
    /// </summary>
    public class ElecTicketAutoTipExchangeEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private ElecTicketAutoTipExchange m_ElecTicketAutoTipExchange;
        /// <summary>
        /// 自动提示承兑信息
        /// </summary>
        public ElecTicketAutoTipExchange ElecTicketAutoTipExchange
        {
            get { return m_ElecTicketAutoTipExchange; }
            set { m_ElecTicketAutoTipExchange = value; }
        }
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
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_ElecTicketAutoTipExchange = null;
            m_ElecTicketAutoTipExchangeList = new List<ElecTicketAutoTipExchange>();
        }
    }
    /// <summary>
    /// 电票背书参数
    /// </summary>
    public class ElecTicketBackNoteEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private ElecTicketBackNote m_ElecTicketBackNote;
        /// <summary>
        /// 背书信息
        /// </summary>
        public ElecTicketBackNote ElecTicketBackNote
        {
            get { return m_ElecTicketBackNote; }
            set { m_ElecTicketBackNote = value; }
        }
        private List<ElecTicketBackNote> m_ElecTicketBackNoteList;
        /// <summary>
        /// 背书信息列表
        /// </summary>
        public List<ElecTicketBackNote> ElecTicketBackNoteList
        {
            get { return m_ElecTicketBackNoteList; }
            set { m_ElecTicketBackNoteList = value; }
        }
        public ElecTicketBackNoteEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_ElecTicketBackNote = null;
            m_ElecTicketBackNoteList = new List<ElecTicketBackNote>();
        }
    }
    /// <summary>
    /// 电票贴现参数
    /// </summary>
    public class ElecTicketPayMoneyEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private ElecTicketPayMoney m_ElecTicketPayMoney;
        /// <summary>
        /// 贴现信息
        /// </summary>
        public ElecTicketPayMoney ElecTicketPayMoney
        {
            get { return m_ElecTicketPayMoney; }
            set { m_ElecTicketPayMoney = value; }
        }
        private List<ElecTicketPayMoney> m_ElecTicketPayMoneyList;
        /// <summary>
        /// 贴现信息列表
        /// </summary>
        public List<ElecTicketPayMoney> ElecTicketPayMoneyList
        {
            get { return m_ElecTicketPayMoneyList; }
            set { m_ElecTicketPayMoneyList = value; }
        }
        public ElecTicketPayMoneyEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_ElecTicketPayMoney = null;
            m_ElecTicketPayMoneyList = new List<ElecTicketPayMoney>();
        }
    }
    /// <summary>
    /// 票据池参数
    /// </summary>
    public class ElecTicketPoolEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private ElecTicketPool m_ElecTicketPool;
        /// <summary>
        /// 票据池信息
        /// </summary>
        public ElecTicketPool ElecTicketPool
        {
            get { return m_ElecTicketPool; }
            set { m_ElecTicketPool = value; }
        }
        private List<ElecTicketPool> m_ElecTicketPoolList;
        /// <summary>
        /// 票据池信息列表
        /// </summary>
        public List<ElecTicketPool> ElecTicketPoolList
        {
            get { return m_ElecTicketPoolList; }
            set { m_ElecTicketPoolList = value; }
        }
        public ElecTicketPoolEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_ElecTicketPool = null;
            m_ElecTicketPoolList = new List<ElecTicketPool>();
        }
    }
    /// <summary>
    /// 国际结算参数
    /// </summary>
    public class TransferGlobalEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private TransferGlobal m_TransferGlobal;
        /// <summary>
        /// 票据池信息
        /// </summary>
        public TransferGlobal TransferGlobal
        {
            get { return m_TransferGlobal; }
            set { m_TransferGlobal = value; }
        }
        private List<TransferGlobal> m_TransferGlobalList;
        /// <summary>
        /// 票据池信息列表
        /// </summary>
        public List<TransferGlobal> TransferGlobalList
        {
            get { return m_TransferGlobalList; }
            set { m_TransferGlobalList = value; }
        }
        public TransferGlobalEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_TransferGlobal = null;
            m_TransferGlobalList = new List<TransferGlobal>();
        }
    }
    /// <summary>
    /// 币种类型变更参数
    /// </summary>
    public class CashTypeChangedEventArgs : EventArgs
    {
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属功能类型
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private CashType m_cashType;
        /// <summary>
        /// 币种类型
        /// </summary>
        public CashType CashType
        {
            get { return m_cashType; }
            set { m_cashType = value; }
        }
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private bool m_isRollBack = false;
        /// <summary>
        /// 是否回滚
        /// </summary>
        public bool IsRollBack
        {
            get { return m_isRollBack; }
            set { m_isRollBack = value; }
        }
        public CashTypeChangedEventArgs()
        {
            m_appType = AppliableFunctionType._Empty;
            m_cashType = EnumTypes.CashType.Empty;
            m_command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 国际结算收款人业务参数
    /// </summary>
    public class Payee4TransferGlobalEventArgs : EventArgs
    {
        OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_ownerType;
        /// <summary>
        /// 所属功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_ownerType; }
            set { m_ownerType = value; }
        }
        PayeeInfo4TransferGlobal m_PayeeInfo;
        /// <summary>
        /// 收款人信息
        /// </summary>
        public PayeeInfo4TransferGlobal PayeeInfo
        {
            get { return m_PayeeInfo; }
            set { m_PayeeInfo = value; }
        }
        List<PayeeInfo4TransferGlobal> m_payeeInfoList;
        /// <summary>
        /// 收款人列表
        /// </summary>
        public List<PayeeInfo4TransferGlobal> PayeeList
        {
            get { return m_payeeInfoList; }
            set { m_payeeInfoList = value; }
        }
        int m_rowindex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowindex; }
            set { m_rowindex = value; }
        }
        public Payee4TransferGlobalEventArgs()
        {
            m_rowindex = 0;
            m_PayeeInfo = null;
            m_ownerType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_payeeInfoList = new List<PayeeInfo4TransferGlobal>();
        }
    }
    /// <summary>
    /// 供应链--经销商融资申请参数
    /// </summary>
    public class SpplyFinancingApplyEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private SpplyFinancingApply m_SpplyFinancingApply;
        /// <summary>
        /// 融资申请信息
        /// </summary>
        public SpplyFinancingApply SpplyFinancingApply
        {
            get { return m_SpplyFinancingApply; }
            set { m_SpplyFinancingApply = value; }
        }
        private List<SpplyFinancingApply> m_SpplyFinancingApplyList;
        /// <summary>
        /// 融资申请信息列表
        /// </summary>
        public List<SpplyFinancingApply> SpplyFinancingApplyList
        {
            get { return m_SpplyFinancingApplyList; }
            set { m_SpplyFinancingApplyList = value; }
        }
        public SpplyFinancingApplyEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_SpplyFinancingApply = null;
            m_SpplyFinancingApplyList = new List<SpplyFinancingApply>();
        }
    }
    /// <summary>
    /// 供应链--卖/买方订单提交参数
    /// </summary>
    public class SpplyFinancingBillEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private SpplyFinancingBill m_SpplyFinancingBill;
        /// <summary>
        /// 发票信息
        /// </summary>
        public SpplyFinancingBill SpplyFinancingBill
        {
            get { return m_SpplyFinancingBill; }
            set { m_SpplyFinancingBill = value; }
        }
        private List<SpplyFinancingBill> m_SpplyFinancingBillList;
        /// <summary>
        /// 发票信息列表
        /// </summary>
        public List<SpplyFinancingBill> SpplyFinancingBillList
        {
            get { return m_SpplyFinancingBillList; }
            set { m_SpplyFinancingBillList = value; }
        }
        public SpplyFinancingBillEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_SpplyFinancingBill = null;
            m_SpplyFinancingBillList = new List<SpplyFinancingBill>();
        }
    }
    /// <summary>
    /// 供应链--应收账款卖/买方收/付款参数
    /// </summary>
    public class SpplyFinancingPayOrReceiptEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private SpplyFinancingPayOrReceipt m_SpplyFinancingPayOrReceipt;
        /// <summary>
        /// 收/付款信息
        /// </summary>
        public SpplyFinancingPayOrReceipt SpplyFinancingPayOrReceipt
        {
            get { return m_SpplyFinancingPayOrReceipt; }
            set { m_SpplyFinancingPayOrReceipt = value; }
        }
        private List<SpplyFinancingPayOrReceipt> m_SpplyFinancingPayOrReceiptList;
        /// <summary>
        /// 收/付款信息列表
        /// </summary>
        public List<SpplyFinancingPayOrReceipt> SpplyFinancingPayOrReceiptList
        {
            get { return m_SpplyFinancingPayOrReceiptList; }
            set { m_SpplyFinancingPayOrReceiptList = value; }
        }
        public SpplyFinancingPayOrReceiptEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_SpplyFinancingPayOrReceipt = null;
            m_SpplyFinancingPayOrReceiptList = new List<SpplyFinancingPayOrReceipt>();
        }
    }
    /// <summary>
    /// 供应链--应收账款卖/买方订单参数
    /// </summary>
    public class SpplyFinancingOrderEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private SpplyFinancingOrder m_SpplyFinancingOrder;
        /// <summary>
        /// 订单信息
        /// </summary>
        public SpplyFinancingOrder SpplyFinancingOrder
        {
            get { return m_SpplyFinancingOrder; }
            set { m_SpplyFinancingOrder = value; }
        }
        private List<SpplyFinancingOrder> m_SpplyFinancingOrderList;
        /// <summary>
        /// 订单信息列表
        /// </summary>
        public List<SpplyFinancingOrder> SpplyFinancingOrderList
        {
            get { return m_SpplyFinancingOrderList; }
            set { m_SpplyFinancingOrderList = value; }
        }
        public SpplyFinancingOrderEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_SpplyFinancingOrder = null;
            m_SpplyFinancingOrderList = new List<SpplyFinancingOrder>();
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
        public InitiativeAllotAccount InitiativeAllotAccount
        {
            get
            {
                return m_InitiativeAllotAccount;
            }
            set
            {
                m_InitiativeAllotAccount = value;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get
            {
                return m_Command;
            }
            set
            {
                m_Command = value;
            }
        }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get
            {
                return m_BatchCommand;
            }
            set
            {
                m_BatchCommand = value;
            }
        }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenType; }
            set { m_OwenType = value; }
        }

        /// <summary>
        /// 账户信息
        /// </summary>
        public List<InitiativeAllotAccount> InitiativeAllotAccountList
        {
            get { return m_InitiativeAllotAccountList; }
            set { m_InitiativeAllotAccountList = value; }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        private InitiativeAllotAccount m_InitiativeAllotAccount;
        private List<InitiativeAllotAccount> m_InitiativeAllotAccountList;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenType;
        private int m_RowIndex;

        public InitiativeAllotAccountEventArgs()
        {
            m_InitiativeAllotAccount = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenType = AppliableFunctionType._Empty;
            m_InitiativeAllotAccountList = new List<InitiativeAllotAccount>();
            m_RowIndex = 0;
        }
    }
    /// <summary>
    /// 设置中的操作参数
    /// 用于全选、反选、批量删除等
    /// </summary>
    public class SettingsOperateEventArgs : EventArgs
    {
        FunctionInSettingType m_fst;
        /// <summary>
        /// 所属业务
        /// </summary>
        public FunctionInSettingType FunctionType
        {
            get { return m_fst; }
            set { m_fst = value; }
        }
        OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }

        public SettingsOperateEventArgs()
        {
            m_fst = FunctionInSettingType.Empty;
            m_command = OperatorCommandType.Empty;
        }
    }
    /// <summary>
    /// 快捷代发用途变更参数
    /// </summary>
    public class AgentExpressPurposeEventArgs : EventArgs
    {
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务
        /// </summary>
        public AppliableFunctionType Owner
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private AgentExpressFunctionType m_Purpose;
        /// <summary>
        /// 批用途
        /// </summary>
        public AgentExpressFunctionType Purpose
        {
            get { return m_Purpose; }
            set { m_Purpose = value; }
        }
        private OperatorCommandType m_Command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }
        private bool m_isRollBack;
        /// <summary>
        /// 是否需要回滚
        /// </summary>
        public bool IsRollBack
        {
            get { return m_isRollBack; }
            set { m_isRollBack = value; }
        }
        public AgentExpressPurposeEventArgs()
        {
            m_appType = AppliableFunctionType._Empty;
            m_Command = OperatorCommandType.Empty;
            m_Purpose = AgentExpressFunctionType.Empty;
        }
    }
    /// <summary>
    /// 贴入人开户行信息变更参数
    /// </summary>
    public class StickOnBankInfoEventArgs : EventArgs
    {
        private string m_bankName;
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            get { return m_bankName; }
            set { m_bankName = value; }
        }
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
            m_bankName = m_bankNo = string.Empty;
        }
    }
    /// <summary>
    /// 统一支付--人民币提交参数
    /// </summary>
    public class UnitivePaymentRMBEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private UnitivePaymentRMB m_UnitivePaymentRMB;
        /// <summary>
        /// 人民币统一支付信息
        /// </summary>
        public UnitivePaymentRMB UnitivePaymentRMB
        {
            get { return m_UnitivePaymentRMB; }
            set { m_UnitivePaymentRMB = value; }
        }
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
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_UnitivePaymentRMB = null;
            m_UnitivePaymentRMBList = new List<UnitivePaymentRMB>();
        }
    }
    /// <summary>
    /// 统一支付--外币提交参数
    /// </summary>
    public class UnitivePaymentFCEventArgs : EventArgs
    {
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private int m_rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private UnitivePaymentForeignMoney m_UnitivePaymentFC;
        /// <summary>
        /// 外币统一支付信息
        /// </summary>
        public UnitivePaymentForeignMoney UnitivePaymentFC
        {
            get { return m_UnitivePaymentFC; }
            set { m_UnitivePaymentFC = value; }
        }
        private OverCountryPayeeAccountType m_AccountType;
        /// <summary>
        /// 收款人类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType
        {
            get { return m_AccountType; }
            set { m_AccountType = value; }
        }
        private List<UnitivePaymentForeignMoney> m_UnitivePaymentFCList;
        /// <summary>
        /// 外币统一支付信息列表
        /// </summary>
        public List<UnitivePaymentForeignMoney> UnitivePaymentFCList
        {
            get { return m_UnitivePaymentFCList; }
            set { m_UnitivePaymentFCList = value; }
        }
        public UnitivePaymentFCEventArgs()
        {
            m_rowIndex = 0;
            m_appType = AppliableFunctionType._Empty;
            m_command = OperatorCommandType.Empty;
            m_AccountType = OverCountryPayeeAccountType.Empty;
            m_UnitivePaymentFC = null;
            m_UnitivePaymentFCList = new List<UnitivePaymentForeignMoney>();
        }
    }

    public class OverCountryPayeeAccountTypeEventArgs : EventArgs
    {
        private AppliableFunctionType m_appType;
        /// <summary>
        /// 所属功能类型
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set { m_appType = value; }
        }
        private OverCountryPayeeAccountType m_AccountType;
        /// <summary>
        /// 币种类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType
        {
            get { return m_AccountType; }
            set { m_AccountType = value; }
        }
        private OperatorCommandType m_command;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get { return m_command; }
            set { m_command = value; }
        }
        private bool m_isRollBack = false;
        /// <summary>
        /// 是否回滚
        /// </summary>
        public bool IsRollBack
        {
            get { return m_isRollBack; }
            set { m_isRollBack = value; }
        }
        public OverCountryPayeeAccountTypeEventArgs()
        {
            m_appType = AppliableFunctionType._Empty;
            m_AccountType = EnumTypes.OverCountryPayeeAccountType.Empty;
            m_command = OperatorCommandType.Empty;
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
        public VirtualAccount InitiativeAccount
        {
            get
            {
                return m_VirtualAccount;
            }
            set
            {
                m_VirtualAccount = value;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get
            {
                return m_Command;
            }
            set
            {
                m_Command = value;
            }
        }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get
            {
                return m_BatchCommand;
            }
            set
            {
                m_BatchCommand = value;
            }
        }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenType; }
            set { m_OwenType = value; }
        }

        /// <summary>
        /// 账户信息
        /// </summary>
        public List<VirtualAccount> VirtualAccountList
        {
            get { return m_VirtualAccountList; }
            set { m_VirtualAccountList = value; }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        private VirtualAccount m_VirtualAccount;
        private List<VirtualAccount> m_VirtualAccountList;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenType;
        private int m_RowIndex;

        public VirtualAccountEventArgs()
        {
            m_VirtualAccount = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenType = AppliableFunctionType._Empty;
            m_VirtualAccountList = new List<VirtualAccount>();
            m_RowIndex = 0;
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
        public VirtualAccountInfo VirtualAllotAccount
        {
            get
            {
                return m_VirtualAllotAccount;
            }
            set
            {
                m_VirtualAllotAccount = value;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperatorCommandType Command
        {
            get
            {
                return m_Command;
            }
            set
            {
                m_Command = value;
            }
        }

        /// <summary>
        /// 子操作类型
        /// </summary>
        public OperatorCommandType BatchCommand
        {
            get
            {
                return m_BatchCommand;
            }
            set
            {
                m_BatchCommand = value;
            }
        }

        /// <summary>
        /// 功能类型
        /// </summary>
        public AppliableFunctionType OwnerType
        {
            get { return m_OwenType; }
            set { m_OwenType = value; }
        }

        /// <summary>
        /// 账户信息
        /// </summary>
        public List<VirtualAccountInfo> VirtualAllotAccountList
        {
            get { return m_VirtualAllotAccountList; }
            set { m_VirtualAllotAccountList = value; }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        private VirtualAccountInfo m_VirtualAllotAccount;
        private List<VirtualAccountInfo> m_VirtualAllotAccountList;
        private OperatorCommandType m_Command;
        private OperatorCommandType m_BatchCommand;
        private AppliableFunctionType m_OwenType;
        private int m_RowIndex;

        public VirtualAccountAllotEventArgs()
        {
            m_VirtualAllotAccount = null;
            m_Command = OperatorCommandType.Empty;
            m_BatchCommand = OperatorCommandType.Empty;
            m_OwenType = AppliableFunctionType._Empty;
            m_VirtualAllotAccountList = new List<VirtualAccountInfo>();
            m_RowIndex = 0;
        }
    }
}
