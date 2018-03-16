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
    public static class SystemSettings
    {
        static SystemSettings()
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
            CurrentVersion = CurrentVersion | VersionType.v402 | VersionType.t42 | VersionType.t43 | VersionType.v405 | VersionType.t51 | VersionType.v501|VersionType.v502;
            //CurrentVersion = VersionType.v403bar;

            FilterChars.AddRange(new string[] { "\t", "\n", "\r\n" });
        }
        /// <summary>
        /// 初始化系统设置
        /// </summary>
        public static void Init()
        {
            CommonInformations.Init();
        }

        public static void CheckInit()
        {
            //if (AppliableTypes == AppliableFunctionType._Empty && (SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar) AppliableTypes = AppliableFunctionType.TransferWithCorp | AppliableFunctionType.AgentExpressOut;
            SystemInit.InitMappingRelation();

            foreach (AppliableFunctionType aft in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (aft == AppliableFunctionType._Empty) continue;
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                { if ((int)aft > 0) continue; }
                else { if ((int)aft < 0)continue; }
                if (!SystemSettings.Notices.ContainsKey(aft))
                {
                    SystemSettings.Notices.Add(aft, new List<NoticeInfo>());
                }
                for (int i = SystemSettings.Notices[aft].Count; i < 10; i++)
                {
                    SystemSettings.Notices[aft].Add(new NoticeInfo() { RowIndex = i + 1, Content = string.Empty });
                }
            }
        }
        #region 参数
        #region 多语言参数
        /// <summary>
        /// 系统当前语言
        /// </summary>
        public static UILang CurrentLanguage = UILang.CHS;
        /// <summary>
        /// 多语言信息列表
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> MultiLanguageMsgList;
        #endregion
        #region 功能设置
        /// <summary>
        /// 功能设置数据
        /// </summary>
        public static AppliableFunctionType AppliableTypes = AppliableFunctionType._Empty;
        public static AppliableFunctionType AppliableTypes4Bar = AppliableFunctionType._Empty;
        public static CommonClient.Types.CNAP CustomerInfo = new Types.CNAP();
        public static List<string> ForbiddenChars = new List<string>();
        public static List<string> FilterChars = new List<string>();
        #endregion
        #region 文件加密
        /// <summary>
        /// 是否设置快捷代发加密密码
        /// </summary>
        public static bool IsMatchPassword4ShortProxyOut;
        /// <summary>
        /// 快捷代发加密密码
        /// </summary>
        public static string ShortProxyOutPassword;
        /// <summary>
        /// 是否设置跨境汇款加密密码
        /// </summary>
        public static bool IsMatchPassword4TransferOverCountry;
        /// <summary>
        /// 跨境汇款加密密码
        /// </summary>
        public static string TransferOverCountryPassword;
        /// <summary>
        /// 是否设置境内外币汇款加密密码
        /// </summary>
        public static bool IsMatchPassword4TransferForeignMoney;
        /// <summary>
        /// 境内外币汇款加密密码
        /// </summary>
        public static string TransferForeignMoneyPassword;
        #endregion
        #region 附言及用途
        public static Dictionary<AppliableFunctionType, List<NoticeInfo>> Notices;
        #endregion
        #region 批量转换设置
        /// <summary>
        /// 批量转换映射关系
        /// </summary>
        public static Dictionary<AppliableFunctionType, MappingsRelationSettings> BatchMappingSettings;
        public static Dictionary<FunctionInSettingType, MappingsRelationSettings> BatchSettingsMappingSettings;
        public static string BOCSeparator = "|";
        /// <summary>
        /// 每批次默认最大笔数
        /// </summary>
        public static int DefaultMaxCountPerOperation = 1000;
        /// <summary>
        /// 校验规则描述
        /// </summary>
        public static Dictionary<AppliableFunctionType, List<string>> RegexDescriptions;
        public static Dictionary<FunctionInSettingType, List<string>> RegexSettingsDescriptions;
        /// <summary>
        /// 批信息校验规则描述
        /// </summary>
        public static Dictionary<AppliableFunctionType, List<string>> BatchRegexDescriptions;
        /// <summary>
        /// 用于将市县名称转换为省标识--柜台
        /// </summary>
        public static List<CommonClient.Types.CNAP> City2ProvinceBar;
        #endregion
        #region 批量公用数据
        /// <summary>
        /// 批量公用数据
        /// </summary>
        public static Dictionary<AppliableFunctionType, CommonFieldType> CommonFieldList;
        #endregion
        #region 付款人、收款人、电票关系人、国际结算收款人、主动调拨账户、快捷代收付款人名册、内部账户转账
        /// <summary>
        /// 付款人名册
        /// </summary>
        public static List<PayerInfo> PayerList;
        /// <summary>
        /// 收款人名册
        /// </summary>
        public static List<PayeeInfo> PayeeList;
        /// <summary>
        /// 电票关系人名称
        /// </summary>
        public static List<ElecTicketRelationAccount> ElecTicketRelationAccountList;
        /// <summary>
        /// 国际结算收款人名册
        /// </summary>
        public static List<PayeeInfo4TransferGlobal> PayeeInfo4TransferGlobalList;
        /// <summary>
        /// 主动调拨账户名册
        /// </summary>
        public static List<InitiativeAllotAccount> InitiativeAllotAccountList;
        /// <summary>
        /// 快捷代收付款人名册
        /// </summary>
        public static List<PayeeInfo> AgentExpressPayerList;
        /// <summary>
        /// 内部账户转账
        /// </summary>
        public static List<VirtualAccountInfo> VirtualAllotAccountList;
        #endregion
        #region 操作记录上限
        /// <summary>
        /// 设置中的名册类默认最大单次操作记录数
        /// </summary>
        public static int DefaultBaseDataMaxCountPerOperation = 200;
        public static int DefaultMaxCountPayeeMgr = 200;
        public static int DefaultMaxCountTransfer = 3000;
        public static int DefaultMaxCountAgentExpress = 40000;
        public static int DefaultMaxCountAgentNormal = 500;
        public static int DefaultMaxCountAgentNormalInBOC = 1000;
        public static int DefaultMaxCountAgentNormalOutBOC = 5000;
        public static int DefaultMaxCountOverBank = 3000;
        public static int DefaultMaxCountElecTicket = 500;
        public static int DefaultMaxCountElecTicketPool = 1000;
        public static int DefaultMaxCountTransferGlobal = 1000;
        public static int DefaultMaxCountSpplyFinancing = 1000;
        public static int DefaultMaxCountApply = 50;
        public static int DefaultMaxCountPayeeTransferGlobalMgr = 1000;
        public static int DefaultMaxCountInitiativeAllot = 1000;
        public static int DefaultMaxCountUnitivePayment = 1000;
        public static int DefaultMaxCountVirtualTransfer = 1000;
        public static int DefaultMaxCountPreproccessTransfer = 25000;
        public static int DefaultMaxCountBatchReimbursement = 500;
        #endregion
        #region 版本控制参数
        public static VersionType CurrentVersion = VersionType.v307;
        #endregion
        #endregion
    }
}
