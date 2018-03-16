using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.Utilities;

namespace CommonClient.SysCoach
{
    /// <summary>
    /// 系统设置类
    /// </summary>
    public class SystemSettings
    {
        #region 单例模式
        private static object lock_obj = new object();
        private static SystemSettings m_instance;
        /// <summary>
        /// 系统设置类单一实例
        /// </summary>
        public static SystemSettings Instance
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
                                m_instance = new SystemSettings();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion
        public SystemSettings()
        {
            CommonFieldList = new Dictionary<AppliableFunctionType, CommonFieldType>();
            PayerList = new List<PayerInfo>();
            PayeeList = new List<PayeeInfo>();
            Notices = new Dictionary<AppliableFunctionType, List<NoticeInfo>>();
            BatchMappingSettings = new Dictionary<AppliableFunctionType, MappingsRelationSettings>();
            BatchSettingsMappingSettings = new Dictionary<FunctionInSettingType, MappingsRelationSettings>();
            RegexDescriptions = new Dictionary<AppliableFunctionType, List<string>>();
            BatchRegexDescriptions = new Dictionary<AppliableFunctionType, List<string>>();
            MultiLanguageMsgList = new Dictionary<string, Dictionary<string, string>>();
            ElecTicketRelationAccountList = new List<ElecTicketRelationAccount>();
            PayeeInfo4TransferGlobalList = new List<PayeeInfo4TransferGlobal>();
            InitiativeAllotAccountList = new List<InitiativeAllotAccount>();
            VirtualAllotAccountList = new List<VirtualAccountInfo>();
            AgentExpressPayerList = new List<PayeeInfo>();
            City2ProvinceBar = new List<Types.CNAP>();
            CurrentVersion = CurrentVersion | VersionType.v402 | VersionType.t42 | VersionType.v405;
            //CurrentVersion = VersionType.v403bar;
        }
        /// <summary>
        /// 初始化系统设置
        /// </summary>
        public void Init()
        {
            CommonInformations.Instance.Init();
        }

        public void CheckInit()
        {
            if (AppliableTypes == AppliableFunctionType._Empty && (SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar) AppliableTypes = AppliableFunctionType.TransferWithCorp | AppliableFunctionType.AgentExpressOut;
            SystemInit.Instance.InitMappingRelation();

            foreach (AppliableFunctionType aft in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (aft == AppliableFunctionType._Empty) continue;
                if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                { if ((int)aft > 0) continue; }
                else { if ((int)aft < 0)continue; }
                if (!SystemSettings.Instance.Notices.ContainsKey(aft))
                {
                    SystemSettings.Instance.Notices.Add(aft, new List<NoticeInfo>());
                }
                for (int i = SystemSettings.Instance.Notices[aft].Count; i < 10; i++)
                {
                    SystemSettings.Instance.Notices[aft].Add(new NoticeInfo() { RowIndex = i + 1, Content = string.Empty });
                }
            }
        }
        #region 参数
        #region 多语言参数
        /// <summary>
        /// 系统当前语言
        /// </summary>
        public UILang CurrentLanguage = UILang.CHS;
        /// <summary>
        /// 多语言信息列表
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> MultiLanguageMsgList;
        #endregion
        #region 功能设置
        /// <summary>
        /// 功能设置数据
        /// </summary>
        public AppliableFunctionType AppliableTypes = AppliableFunctionType._Empty;
        public AppliableFunctionType AppliableTypes4Bar = AppliableFunctionType._Empty;
        public CommonClient.Types.CNAP CustomerInfo = new Types.CNAP();
        #endregion
        #region 文件加密
        /// <summary>
        /// 是否设置快捷代发加密密码
        /// </summary>
        public bool IsMatchPassword4ShortProxyOut;
        /// <summary>
        /// 快捷代发加密密码
        /// </summary>
        public string ShortProxyOutPassword;
        /// <summary>
        /// 是否设置跨境汇款加密密码
        /// </summary>
        public bool IsMatchPassword4TransferOverCountry;
        /// <summary>
        /// 跨境汇款加密密码
        /// </summary>
        public string TransferOverCountryPassword;
        /// <summary>
        /// 是否设置境内外币汇款加密密码
        /// </summary>
        public bool IsMatchPassword4TransferForeignMoney;
        /// <summary>
        /// 境内外币汇款加密密码
        /// </summary>
        public string TransferForeignMoneyPassword;
        #endregion
        #region 附言及用途
        public Dictionary<AppliableFunctionType, List<NoticeInfo>> Notices;
        #endregion
        #region 批量转换设置
        /// <summary>
        /// 批量转换映射关系
        /// </summary>
        public Dictionary<AppliableFunctionType, MappingsRelationSettings> BatchMappingSettings;
        public Dictionary<FunctionInSettingType, MappingsRelationSettings> BatchSettingsMappingSettings;
        public string BOCSeparator = "|";
        /// <summary>
        /// 每批次默认最大笔数
        /// </summary>
        public int DefaultMaxCountPerOperation = 1000;
        /// <summary>
        /// 校验规则描述
        /// </summary>
        public Dictionary<AppliableFunctionType, List<string>> RegexDescriptions;
        public Dictionary<FunctionInSettingType, List<string>> RegexSettingsDescriptions;
        /// <summary>
        /// 批信息校验规则描述
        /// </summary>
        public Dictionary<AppliableFunctionType, List<string>> BatchRegexDescriptions;
        /// <summary>
        /// 用于将市县名称转换为省标识--柜台
        /// </summary>
        public List<CommonClient.Types.CNAP> City2ProvinceBar;
        #endregion
        #region 批量公用数据
        /// <summary>
        /// 批量公用数据
        /// </summary>
        public Dictionary<AppliableFunctionType, CommonFieldType> CommonFieldList;
        #endregion
        #region 付款人、收款人、电票关系人、国际结算收款人、主动调拨账户、快捷代收付款人名册、内部账户转账
        /// <summary>
        /// 付款人名册
        /// </summary>
        public List<PayerInfo> PayerList;
        /// <summary>
        /// 收款人名册
        /// </summary>
        public List<PayeeInfo> PayeeList;
        /// <summary>
        /// 电票关系人名称
        /// </summary>
        public List<ElecTicketRelationAccount> ElecTicketRelationAccountList;
        /// <summary>
        /// 国际结算收款人名册
        /// </summary>
        public List<PayeeInfo4TransferGlobal> PayeeInfo4TransferGlobalList;
        /// <summary>
        /// 主动调拨账户名册
        /// </summary>
        public List<InitiativeAllotAccount> InitiativeAllotAccountList;
        /// <summary>
        /// 快捷代收付款人名册
        /// </summary>
        public List<PayeeInfo> AgentExpressPayerList;
        /// <summary>
        /// 内部账户转账
        /// </summary>
        public List<VirtualAccountInfo> VirtualAllotAccountList;
        #endregion
        #region 操作记录上限
        /// <summary>
        /// 设置中的名册类默认最大单次操作记录数
        /// </summary>
        public int DefaultBaseDataMaxCountPerOperation = 200;
        public int DefaultMaxCountPayeeMgr = 200;
        public int DefaultMaxCountTransfer = 3000;
        public int DefaultMaxCountAgentExpress = 40000;
        public int DefaultMaxCountAgentNormal = 500;
        public int DefaultMaxCountAgentNormalInBOC = 1000;
        public int DefaultMaxCountAgentNormalOutBOC = 5000;
        public int DefaultMaxCountOverBank = 3000;
        public int DefaultMaxCountElecTicket = 500;
        public int DefaultMaxCountElecTicketPool = 1000;
        public int DefaultMaxCountTransferGlobal = 1000;
        public int DefaultMaxCountSpplyFinancing = 1000;
        public int DefaultMaxCountApply = 50;
        public int DefaultMaxCountPayeeTransferGlobalMgr = 1000;
        public int DefaultMaxCountInitiativeAllot = 1000;
        public int DefaultMaxCountUnitivePayment = 1000;
        #endregion
        #region 版本控制参数
        public VersionType CurrentVersion = VersionType.v307;
        #endregion
        #endregion
    }
}
