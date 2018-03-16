using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CommonClient.Types;

namespace CommonClient.EnumTypes
{
    public enum UILang
    {
        [TranslatingKeyAttribute("key0000", "中文", "Chinese Simple", "簡體中文")]
        CHS = 0,
        [TranslatingKeyAttribute("key0001", "英文", "English", "英文")]
        EN = 1,
        [TranslatingKeyAttribute("key0002", "繁体中文", "Chinese Traditional", "繁體中文")]
        CHT = 2
    }

    public enum TransferChanelType
    {
        [TranslatingKeyAttribute("Key0111", "普通", "Common", "普通")]
        Normal = 0,
        [TranslatingKeyAttribute("Key0112", "加急", "Extra Urgent", "加急")]
        Express = 1
    }

    public enum ChargingFeeAccountType
    {
        [TranslatingKeyAttribute("Key1001", "同付款人账号", "Same as Payer Account Number", "同付款人帳號")]
        SameAsPayingAccount = 0
    }

    // 业务类型
    public enum AgentBusinessType
    {
        [TranslatingKeyAttribute("Key1021", "工资", "Salary", "工資")]
        Salary = 0,

        [TranslatingKeyAttribute("Key1022", "其他", "Other", "其他")]
        Other = 1
    }

    // 代收代付目标行类型
    public enum AgentTransferBankType
    {
        [TranslatingKeyAttribute("Key1031", "其他银行", "Other banks", "其他銀行")]
        Other = 0,
        [TranslatingKeyAttribute("Key1032", "中国银行", "Bank of China", "中國銀行")]
        Boc = 1
    }

    // 汇款用途
    public enum AgentTransferUsageType
    {
        [TranslatingKeyAttribute("Key1041", "工资", "Salary", "工資")]
        Salary = 0,

        [TranslatingKeyAttribute("Key1042", "奖金", "Bonus", "獎金")]
        Bonus = 1
    }

    public enum AccountBankType
    {
        [Description("")]
        [TranslatingKeyAttribute("Key1060", "", "", "")]
        Empty = -1,
        [Description("中国银行")]
        [TranslatingKeyAttribute("Key1061", "中国银行", "Bank of China", "中國銀行")]
        BocAccount = 0,
        [Description("工商银行")]
        [TranslatingKeyAttribute("Key1062", "工商银行", "Other banks", "其他銀行")]
        ICBCAccount = 102,
        [Description("农业银行")]
        [TranslatingKeyAttribute("Key1063", "农业银行", "Bank of China", "中國銀行")]
        ABCAccount = 103,
        [Description("建设银行")]
        [TranslatingKeyAttribute("Key1064", "建设银行", "Other banks", "其他銀行")]
        CCBBankAccount = 105,
        //[Description("城市银行")]
        //[TranslatingKeyAttribute("Key1065", "城市银行", "Bank of China", "中國銀行")]
        //BocAccount = 313,
        [Description("农村信用合作社")]
        [TranslatingKeyAttribute("Key1066", "农村信用合作社", "Other banks", "其他銀行")]
        NCXYHZSAccount = 402,
        [Description("招商银行")]
        [TranslatingKeyAttribute("Key1067", "招商银行", "Bank of China", "中國銀行")]
        CMBAccount = 308,
        [Description("交通银行")]
        [TranslatingKeyAttribute("Key1068", "交通银行", "Other banks", "其他銀行")]
        BOCCAccount = 301,
        [Description("农村商业银行")]
        [TranslatingKeyAttribute("Key1069", "农村商业银行", "Bank of China", "中國銀行")]
        NCSYBankAccount = 314,
        [Description("上海浦东发展银行")]
        [TranslatingKeyAttribute("Key1070", "上海浦东发展银行", "Other banks", "其他銀行")]
        SHPDFZBankAccount = 310,
        [Description("中信银行")]
        [TranslatingKeyAttribute("Key1071", "中信银行", "Bank of China", "中國銀行")]
        ZXBankAccount = 302,
        [Description("民生银行")]
        [TranslatingKeyAttribute("Key1072", "民生银行", "Other banks", "其他銀行")]
        CMBCAccount = 305,
        [Description("平安银行")]
        [TranslatingKeyAttribute("Key1073", "平安银行", "Bank of China", "中國銀行")]
        PABankAccount = 307,
        [Description("光大银行")]
        [TranslatingKeyAttribute("Key1074", "光大银行", "Other banks", "其他銀行")]
        GDBankAccount = 303,
        [Description("兴业银行")]
        [TranslatingKeyAttribute("Key1075", "兴业银行", "Bank of China", "中國銀行")]
        XYBankAccount = 309,
        [Description("邮政储蓄银行")]
        [TranslatingKeyAttribute("Key1076", "邮政储蓄银行", "Other banks", "其他銀行")]
        YZCXBankAccount = 403,
        //[Description("广发银行")]
        //[TranslatingKeyAttribute("Key1077", "广发银行", "Bank of China", "中國銀行")]
        //GFBankAccount = 306,
        //[Description("上海农商银行")]
        //[TranslatingKeyAttribute("Key1078", "上海农商银行", "Other banks", "其他銀行")]
        //SHNSBankAccount = 322,
        //[Description("华夏银行")]
        //[TranslatingKeyAttribute("Key1079", "华夏银行", "Bank of China", "中國銀行")]
        //HXBAccount = 304,
        //[Description("汇丰银行")]
        //[TranslatingKeyAttribute("Key1080", "汇丰银行", "Other banks", "其他銀行")]
        //HFBankAccount = 501,
        //[Description("花旗银行")]
        //[TranslatingKeyAttribute("Key1081", "花旗银行", "Bank of China", "中國銀行")]
        //HQBankAccount = 531,
        //[Description("渣打银行")]
        //[TranslatingKeyAttribute("Key1082", "渣打银行", "Other banks", "其他銀行")]
        //ZDBankAccount = 671,
        //[Description("徽商银行")]
        //[TranslatingKeyAttribute("Key1083", "徽商银行", "Bank of China", "中國銀行")]
        //HSBankAccount = 319,
        //[Description("村镇银行")]
        //[TranslatingKeyAttribute("Key1084", "村镇银行", "Other banks", "其他銀行")]
        //CZBankAccount = 320,
        //[Description("三菱东京日联银行")]
        //[TranslatingKeyAttribute("Key1085", "三菱东京日联银行", "Bank of China", "中國銀行")]
        //SLDJRLBankAccount = 561,
        //[Description("农业发展银行")]
        //[TranslatingKeyAttribute("Key1086", "农业发展银行", "Other banks", "其他銀行")]
        //NYFZBankAccount = 203,
        [Description("其他银行")]
        [TranslatingKeyAttribute("Key1086", "其他银行", "Other banks", "其他銀行")]
        OtherBankAccount = 1,
    }

    public enum AccountCategoryType
    {
        [Description("空账号类型")]
        [TranslatingKeyAttribute("Key1070", "", "", "")]
        Empty = -1,

        [Description("对公账号")]
        [TranslatingKeyAttribute("Key1071", "对公账号", "", "對公帳號")]
        Corperation = 0,

        [Description("对私账号")]
        [TranslatingKeyAttribute("Key1072", "对私账号", "", "對私帳號")]
        Personal = 4
    }

    // 证件类型
    public enum AgentExpressCertifyPaperType
    {
        [TranslatingKeyAttribute("Key1100", "", "", "")]
        Empty = 0,
        //居民身份证
        [TranslatingKeyAttribute("Key1101", "居民身份证", "ID Card", "居民身份證")]
        IDCard = 1,

        //临时身份证
        [TranslatingKeyAttribute("Key1102", "临时身份证", "Temporary ID Card", "臨時身份證")]
        TempIDCard = 2,

        //护照
        [TranslatingKeyAttribute("Key1103", "护照", "Passport", "護照")]
        Passport = 3,

        //户口籍
        [TranslatingKeyAttribute("Key1104", "户口簿", "Household registry", "戶口薄")]
        ResidencePaper = 4,

        //军人身份证
        [TranslatingKeyAttribute("Key1105", "军人身份证", "Serviceman identity card", "軍人身份證")]
        SolderPaper = 5,

        //武装武警身份证
        [TranslatingKeyAttribute("Key1106", "武装武警身份证", "Identity certificate of armed police", "武裝武警身份證")]
        ArmedCopPaper = 6,

        //外交人员身份证
        [TranslatingKeyAttribute("Key1107", "外交人员身份证", "ID card of diplomatic", "外交人員身份證")]
        DiplomaticAgentPaper = 8,

        //外国人居留许可证
        [TranslatingKeyAttribute("Key1108", "外国人居留许可证", "Foreign residence permit", "外國人居留許可證")]
        ForeignerStayPermit = 9,

        //边民出入境通行证
        [TranslatingKeyAttribute("Key1109", "边民出入境通行证", "Border resident’s entry & exit pass", "邊民出入境通行證")]
        ConturySidePeoplePassport = 10,

        //对私其它
        [TranslatingKeyAttribute("Key1110", "对私其它", "Personal, other", "對私其它")]
        PersonalOtherPaper = 11,

        //企业法人营业执照
        [TranslatingKeyAttribute("Key1121", "企业法人营业执照", "Corporate Business License", "企業法人營業執照")]
        CorperationDelegateLicense = 21,

        //企业营业执照
        [TranslatingKeyAttribute("Key1122", "企业营业执照", "Enterprise Business License", "企業營業執照")]
        CorperationOpertatingLicense = 22,

        //[TranslatingKeyAttribute("Key1123", "政府人事部门或编制委员会的批文", "", "")]
        //Aecpt23 = 23,
        //[TranslatingKeyAttribute("Key1124", "事业单位法人登记证书", "", "")]
        //Aecpt24 = 24,
        //[TranslatingKeyAttribute("Key1125", "军队、武警部队开户核准通知书", "", "")]
        //Aecpt25 = 25,
        //[TranslatingKeyAttribute("Key1126", "社会团体登记证书", "", "")]
        //Aecpt26 = 26,
        //[TranslatingKeyAttribute("Key1127", "上级主管部门批文或证明", "", "")]
        //Aecpt27 = 27,
        //[TranslatingKeyAttribute("Key1128", "工会法人资格证书", "", "")]
        //Aecpt28 = 28,
        //[TranslatingKeyAttribute("Key1129", "民办非企业登记证书", "", "")]
        //Aecpt29 = 29,

        //驻华机构登记证
        [TranslatingKeyAttribute("Key1130", "驻华机构登记证", "Registration certificate of foreign institution in China", "駐華機構登記證")]
        OrganizeInChinaRegisterPaper = 30,

        //个体工商户营业执照
        [TranslatingKeyAttribute("Key1131", "个体工商户营业执照", "Business license for individual economic establishment", "個體工商戶營業執照")]
        IndividualBusinessOperatingLicense = 31,

        //[TranslatingKeyAttribute("Key1132", "企业名称预先核准通知书", "", "")]
        //Aecpt32 = 32,

        //组织机构代码证
        [TranslatingKeyAttribute("Key1133", "组织机构代码证", "Organization code certificate", "組織機構代碼證")]
        OrganizeCodePaper = 33,

        //[TranslatingKeyAttribute("Key1134", "国税登记证", "", "")]
        //Aecpt34 = 34,
        //[TranslatingKeyAttribute("Key1135", "地税登记证", "", "")]
        //Aecpt35 = 35,
        //[TranslatingKeyAttribute("Key1136", "批准证书", "", "")]
        //Aecpt36 = 36,
        //[TranslatingKeyAttribute("Key1137", "进出口业务资格证书", "", "")]
        //Aecpt37 = 37,
        //[TranslatingKeyAttribute("Key1138", "外贸易经营者备案登记表", "", "")]
        //Aecpt38 = 38,
        //[TranslatingKeyAttribute("Key1139", "金融许可证", "", "")]
        //Aecpt39 = 39,
        //[TranslatingKeyAttribute("Key1140", "外汇业务核准件", "", "")]
        //Aecpt40 = 40,
        //[TranslatingKeyAttribute("Key1141", "外汇登记证", "", "")]
        //Aecpt41 = 41,
        //[TranslatingKeyAttribute("Key1142", "开户许可证", "", "")]
        //Aecpt42 = 42,
        //[TranslatingKeyAttribute("Key1143", "办学许可证", "", "")]
        //Aecpt43 = 43,
        //[TranslatingKeyAttribute("Key1144", "对公其它", "", "")]
        //Aecpt44 = 44,
        //[TranslatingKeyAttribute("Key1145", "各驻华机构编号", "", "")]
        //Aecpt45 = 45,
        //[TranslatingKeyAttribute("Key1146", "宗教事务管理部门批文或证明", "", "")]
        //Aecpt46 = 46,

        //港澳居民来往内地通行证（香港）
        [TranslatingKeyAttribute("Key1147", "港澳居民来往内地通行证（香港）", "Hong Kong & Macau residents pass (Hong Kong)", "港澳台居民來往內地通行證(香港)")]
        HK_PeoplePassport = 47,

        //港澳居民来往内地通行证（澳门）
        [TranslatingKeyAttribute("Key1148", "港澳居民来往内地通行证（澳门）", "Hong Kong & Macau residents pass (Macau)", "港澳台居民來往內地通行證(澳門)")]
        MC_PeoplePassport = 48,

        //台湾居民来往大陆通行证    
        [TranslatingKeyAttribute("Key1149", "台湾居民来往大陆通行证", "Taiwan residents pass", "台灣居民來往大陸通行證")]
        TW_PeoplePassport = 49,

        //[TranslatingKeyAttribute("Key1156", "金融机构编码", "", "")]
        //Aecpt56 = 56,
    }

    // 证件类型
    public enum AgentNormalCertifyPaperType
    {
        Empty = 0,
        //居民身份证
        [TranslatingKeyAttribute("Key1101", "居民身份证", "ID Card", "居民身份證")]
        IDCard = 1,

        //临时身份证
        [TranslatingKeyAttribute("Key1102", "临时身份证", "Temporary ID Card", "臨時身份證")]
        TempIDCard = 2,

        //护照
        [TranslatingKeyAttribute("Key1103", "护照", "Passport", "護照")]
        Passport = 3,

        //户口籍
        [TranslatingKeyAttribute("Key1104", "户口簿", "Household registry", "戶口薄")]
        ResidencePaper = 4,

        //军人身份证
        [TranslatingKeyAttribute("Key1105", "军人身份证", "Serviceman identity card", "軍人身份證")]
        SolderPaper = 5,

        //武装武警身份证
        [TranslatingKeyAttribute("Key1106", "武装武警身份证", "Identity certificate of armed police", "武裝武警身份證")]
        ArmedCopPaper = 6,

        //港澳台居民往来内地通行证
        [TranslatingKeyAttribute("Key1106", "港澳台居民往来内地通行证", "Hong Kong, Macao and Taiwan residents pass", "港澳台居民往來內地通行證")]
        F_PassportPaper = 7,

        //外交人员身份证
        [TranslatingKeyAttribute("Key1107", "外交人员身份证", "ID card of diplomatic", "外交人員身份證")]
        DiplomaticAgentPaper = 8,

        //外国人居留许可证
        [TranslatingKeyAttribute("Key1108", "外国人居留许可证", "Foreign residence permit", "外國人居留許可證")]
        ForeignerStayPermit = 9,

        //边民出入境通行证
        [TranslatingKeyAttribute("Key1109", "边民出入境通行证", "Border resident’s entry & exit pass", "邊民出入境通行證")]
        ConturySidePeoplePassport = 10,

        //对私其它
        [TranslatingKeyAttribute("Key1110", "其他", "Other", "其他")]
        OtherPaper = 11
    }

    // 证件类型
    public enum PayeeCertifyPaperType
    {
        [TranslatingKeyAttribute("Key1100", "", "", "")]
        Empty = 0,
        //居民身份证
        [TranslatingKeyAttribute("Key1101", "居民身份证", "ID Card", "居民身份證")]
        IDCard = 1,

        //临时身份证
        [TranslatingKeyAttribute("Key1102", "临时身份证", "Temporary ID Card", "臨時身份證")]
        TempIDCard = 2,

        //护照
        [TranslatingKeyAttribute("Key1103", "护照", "Passport", "護照")]
        Passport = 8,

        //户口籍
        [TranslatingKeyAttribute("Key1104", "户口簿", "Household registry", "戶口薄")]
        ResidencePaper = 3,

        //军人身份证
        [TranslatingKeyAttribute("Key1105", "军人身份证", "Serviceman identity card", "軍人身份證")]
        SolderPaper = 4,

        //武装武警身份证
        [TranslatingKeyAttribute("Key1106", "武装警察身份证", "Identity certificate of armed police", "武裝武警身份證")]
        ArmedCopPaper = 5,

        //外交人员身份证
        [TranslatingKeyAttribute("Key1107", "外交人员身份证", "ID card of diplomatic", "外交人員身份證")]
        DiplomaticAgentPaper = 11,

        //外国人居留许可证
        [TranslatingKeyAttribute("Key1108", "外国人居留许可证", "Foreign residence permit", "外國人居留許可證")]
        ForeignerStayPermit = 12,

        //边民出入境通行证
        [TranslatingKeyAttribute("Key1109", "边民出入境通行证", "Border resident’s entry & exit pass", "邊民出入境通行證")]
        ConturySidePeoplePassport = 13,

        //对私其它
        [TranslatingKeyAttribute("Key1110", "对私其它", "Personal, other", "對私其它")]
        PersonalOtherPaper = 9,

        //企业法人营业执照
        [TranslatingKeyAttribute("Key1121", "企业法人营业执照", "Corporate Business License", "企業法人營業執照")]
        CorperationDelegateLicense = 21,

        //企业营业执照
        [TranslatingKeyAttribute("Key1122", "企业营业执照", "Enterprise Business License", "企業營業執照")]
        CorperationOpertatingLicense = 22,

        [TranslatingKeyAttribute("Key1123", "政府人事部门或编制委员会的批文", "", "")]
        Aecpt23 = 23,
        [TranslatingKeyAttribute("Key1124", "事业单位法人登记证书", "", "")]
        Aecpt24 = 24,
        [TranslatingKeyAttribute("Key1125", "军队、武警部队开户核准通知书", "", "")]
        Aecpt25 = 25,
        [TranslatingKeyAttribute("Key1126", "社会团体登记证书", "", "")]
        Aecpt26 = 26,
        [TranslatingKeyAttribute("Key1127", "上级主管部门批文或证明", "", "")]
        Aecpt27 = 27,
        [TranslatingKeyAttribute("Key1128", "工会法人资格证书", "", "")]
        Aecpt28 = 28,
        [TranslatingKeyAttribute("Key1129", "民办非企业登记证书", "", "")]
        Aecpt29 = 29,

        //驻华机构登记证
        [TranslatingKeyAttribute("Key1130", "驻华机构登记证", "Registration certificate of foreign institution in China", "駐華機構登記證")]
        OrganizeInChinaRegisterPaper = 30,

        //个体工商户营业执照
        [TranslatingKeyAttribute("Key1131", "个体工商户营业执照", "Business license for individual economic establishment", "個體工商戶營業執照")]
        IndividualBusinessOperatingLicense = 31,

        [TranslatingKeyAttribute("Key1132", "企业名称预先核准通知书", "", "")]
        Aecpt32 = 32,

        //组织机构代码证
        [TranslatingKeyAttribute("Key1133", "组织机构代码证", "Organization code certificate", "組織機構代碼證")]
        OrganizeCodePaper = 33,

        [TranslatingKeyAttribute("Key1134", "国税登记证", "", "")]
        Aecpt34 = 34,
        [TranslatingKeyAttribute("Key1135", "地税登记证", "", "")]
        Aecpt35 = 35,
        [TranslatingKeyAttribute("Key1136", "批准证书", "", "")]
        Aecpt36 = 36,
        [TranslatingKeyAttribute("Key1137", "进出口业务资格证书", "", "")]
        Aecpt37 = 37,
        [TranslatingKeyAttribute("Key1138", "外贸易经营者备案登记表", "", "")]
        Aecpt38 = 38,
        [TranslatingKeyAttribute("Key1139", "金融许可证", "", "")]
        Aecpt39 = 39,
        [TranslatingKeyAttribute("Key1140", "外汇业务核准件", "", "")]
        Aecpt40 = 40,
        [TranslatingKeyAttribute("Key1141", "外汇登记证", "", "")]
        Aecpt41 = 41,
        [TranslatingKeyAttribute("Key1142", "开户许可证", "", "")]
        Aecpt42 = 42,
        [TranslatingKeyAttribute("Key1143", "办学许可证", "", "")]
        Aecpt43 = 43,
        [TranslatingKeyAttribute("Key1144", "对公其它", "", "")]
        Aecpt44 = 44,
        [TranslatingKeyAttribute("Key1145", "各驻华机构编号", "", "")]
        Aecpt45 = 45,
        [TranslatingKeyAttribute("Key1146", "宗教事务管理部门批文或证明", "", "")]
        Aecpt46 = 46,

        //港澳居民来往内地通行证（香港）
        [TranslatingKeyAttribute("Key1147", "港澳居民来往内地通行证（香港）", "Hong Kong & Macau residents pass (Hong Kong)", "港澳台居民來往內地通行證(香港)")]
        HK_PeoplePassport = 47,

        //港澳居民来往内地通行证（澳门）
        [TranslatingKeyAttribute("Key1148", "港澳居民来往内地通行证（澳门）", "Hong Kong & Macau residents pass (Macau)", "港澳台居民來往內地通行證(澳門)")]
        MC_PeoplePassport = 48,

        //台湾居民来往大陆通行证    
        [TranslatingKeyAttribute("Key1149", "台湾居民来往大陆通行证", "Taiwan residents pass", "台灣居民來往大陸通行證")]
        TW_PeoplePassport = 49,

        //[TranslatingKeyAttribute("Key1156", "金融机构编码", "", "")]
        //Aecpt56 = 56,
    }

    //[Flags]
    public enum AppliableFunctionType : long
    {
        #region 柜台用
        [TranslatingKeyAttribute("Key1245", "境内人民币汇划", "", "")]
        AgentExpressOut4Bar = -16,
        [TranslatingKeyAttribute("Key1255", "跨境汇款", "Cross-Border Remittance", "跨境匯款")]
        TransferOverCountry4Bar = -16384,
        [TranslatingKeyAttribute("Key1256", "境内外币汇划", "Domestic Foreign Currency Remittance", "境內外幣匯劃")]
        TransferForeignMoney4Bar = -32768,
        #endregion
        _Empty = 0,

        [TranslatingKeyAttribute("Key1201", "对公汇款", "Corporate Remittance", "對公匯款")]
        TransferWithCorp = 1,

        [TranslatingKeyAttribute("Key1202", "对私汇款", "Personal Remittance", "對私匯款")]
        TransferWithIndiv = 2,

        [TranslatingKeyAttribute("Key1203", "跨行速汇(付款)", "Interbank Quick Batch Payment", "跨行速匯(付款)")]
        TransferOverBankOut = 4,

        [TranslatingKeyAttribute("Key1204", "跨行速汇(收款)", "Interbank Quick Batch Collection", "跨行速匯(收款)")]
        TransferOverBankIn = 8,

        [TranslatingKeyAttribute("Key1205", "快捷代发", "Quick Agency Payment", "快捷代收")]
        AgentExpressOut = 16,

        [TranslatingKeyAttribute("Key1206", "快捷代收", "Quick Agency Collection", "快捷代發")]
        AgentExpressIn = 32,

        [TranslatingKeyAttribute("Key1207", "普通代发", "Common Agency Payment", "普通代發")]
        AgentNormalOut = 64,

        [TranslatingKeyAttribute("Key1208", "普通代收", "Common Agency Collection", "普通代收")]
        AgentNormalIn = 128,

        [TranslatingKeyAttribute("Key1209", "批量主动调拨", "Active Transfer", "主動調撥")]
        InitiativeAllot = 256,

        [TranslatingKeyAttribute("Key1210", "电票出票", "Draw E-draft", "電票出票")]
        ElecTicketRemit = 512,

        [TranslatingKeyAttribute("Key1211", "电票提示承兑", "Batch Presentation for Acceptance", "電票提示承兌")]
        ElecTicketTipExchange = 1024,

        [TranslatingKeyAttribute("Key1212", "电票背书", "E-draft Endorsement", "電票背書")]
        ElecTicketBackNote = 2048,

        [TranslatingKeyAttribute("Key1213", "电票贴现", "E-draft Discount", "電票貼現")]
        ElecTicketPayMoney = 4096,

        [TranslatingKeyAttribute("Key1214", "票据池", "Bill Pool", "票據池")]
        ElecTicketPool = 8192,

        [TranslatingKeyAttribute("Key1215", "跨境汇款", "Cross-Border Remittance", "跨境匯款")]
        TransferOverCountry = 16384,

        [TranslatingKeyAttribute("Key1216", "境内外币汇款", "Domestic Foreign Currency Remittance", "境內外幣匯款")]
        TransferForeignMoney = 32768,

        [TranslatingKeyAttribute("Key1217", "买方订单提交(订单融资)", "", "買方訂單提交")]
        PurchaserOrder = 65536,

        [TranslatingKeyAttribute("Key1218", "卖方订单提交(订单融资)", "", "賣方訂單提交")]
        SellerOrder = 131072,

        [TranslatingKeyAttribute("Key1219", "买方订单管理(订单融资)", "", "賣方訂單管理")]
        PurchaserOrderMgr = 262144,

        [TranslatingKeyAttribute("Key1220", "卖方订单管理(订单融资)", "", "賣方訂單管理")]
        SellerOrderMgr = 524288,

        [TranslatingKeyAttribute("Key1221", "应收账款买方发票(应收账款保理池融资)", "", "應收賬款買方發票")]
        BillofDebtReceivablePurchaser = 1048576,

        [TranslatingKeyAttribute("Key1222", "应收账款卖方发票(应收账款保理池融资)", "", "應收賬款賣方發票")]
        BillofDebtReceivableSeller = 2097152,

        [TranslatingKeyAttribute("Key1223", "收付款信息提交(应收账款保理池融资)", "", "收付款信息")]
        PaymentOrReceiptofDebtReceivablePurchaser = 4194304,

        [TranslatingKeyAttribute("Key1224", "融资申请(经销商融资)", "DealersFinancing", "經銷商融資申請")]
        ApplyofFranchiserFinancing = 8388608,

        [TranslatingKeyAttribute("Key1225", "人民币统一支付", "", "")]
        UnitivePaymentRMB = 16777216,

        [TranslatingKeyAttribute("Key1226", "外币统一支付", "", "")]
        UnitivePaymentFC = 33554432,

        [TranslatingKeyAttribute("Key1227", "内部转账", "", "")]
        VirtualAccountTransfer = 67108864,

        [TranslatingKeyAttribute("Key1228", "待处理转账", "", "")]
        PreproccessTransfer = 134217728,

        [TranslatingKeyAttribute("Key1229", "批量报销", "", "")]
        BatchReimbursement = 268435456,

        [TranslatingKeyAttribute("Key1230", "中央财政", "", "")]
        TheCentralGoverment = 536870912,
    }

    //设置-功能类型
    public enum FunctionInSettingType
    {
        [TranslatingKeyAttribute("Key1249", "批量转换", "", "批量轉換")]
        BatchConvert = -1,
        [TranslatingKeyAttribute("Key1250", "Empty", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key1251", "功能设置", "", "功能設置")]
        FunctionSetting = 1,
        [TranslatingKeyAttribute("Key1252", "文件加密", "", "文件加密")]
        FilePwd = 2,
        [TranslatingKeyAttribute("Key1253", "本单位账户", "", "付款人名冊")]
        PayerMg = 3,
        [TranslatingKeyAttribute("Key1254", "境内人民币收款人", "", "收款人名冊")]
        PayeeMg = 4,
        [TranslatingKeyAttribute("Key1255", "常用用途", "", "附言")]
        AddtionMg = 5,
        [TranslatingKeyAttribute("Key1256", "批量转换设置", "", "批量轉換設置")]
        MapSetting = 6,
        [TranslatingKeyAttribute("Key1257", "批量公用数据", "", "批量公用數據")]
        CommonInfoMg = 7,
        [TranslatingKeyAttribute("Key1258", "票据关系人", "", "票據關係人")]
        ElecTicketRelateAccountMg = 8,
        [TranslatingKeyAttribute("Key1259", "国际结算收款人", "", "國際結算收款人")]
        OverCountryPayeeMg = 9,
        [TranslatingKeyAttribute("Key1260", "快捷代收付款人", "", "快捷代收付款人")]
        AgentExpressInPayerMg = 10,
        [TranslatingKeyAttribute("Key1261", "主动调拨账户", "", "主動調撥帳戶款人")]
        InitiativeAllotMg = 11,
        [TranslatingKeyAttribute("Key1262", "今日/历史交易", "", "")]
        TodayOrHistoryTransferMg = 12,
        //[TranslatingKeyAttribute("Key1263", "历史交易", "", "")]
        //HistoryTransferMg = 13,
    }

    public enum ChinaProvinceType
    {
        [TranslatingKeyAttribute("Key1300", "Empty", "", "")]
        B0 = 0,
        [TranslatingKeyAttribute("Key1301", "总行", "Head Office", "總行")]
        B10 = 10,
        [TranslatingKeyAttribute("Key1302", "北京", "Beijing", "北京")]
        B11 = 11,
        [TranslatingKeyAttribute("Key1303", "天津", "Tianjin", "天津")]
        B12 = 12,
        [TranslatingKeyAttribute("Key1304", "河北", "Hebei", "河北")]
        B13 = 13,
        [TranslatingKeyAttribute("Key1305", "山西", "Shanxi", "山西")]
        B14 = 14,
        [TranslatingKeyAttribute("Key1306", "内蒙古", "Inner Mongolia", "內蒙古")]
        B15 = 15,
        [TranslatingKeyAttribute("Key1307", "辽宁", "Liaoning", "遼寧")]
        B21 = 21,
        [TranslatingKeyAttribute("Key1308", "吉林", "Jilin", "吉林")]
        B22 = 22,
        [TranslatingKeyAttribute("Key1309", "黑龙江", "Heilongjiang", "黑龍江")]
        B23 = 23,
        [TranslatingKeyAttribute("Key1310", "上海自贸区", "", "上海自贸区")]
        B30 = 30,
        [TranslatingKeyAttribute("Key1311", "上海", "Shanghai", "上海")]
        B31 = 31,
        [TranslatingKeyAttribute("Key1312", "江苏", "Jiangsu", "江蘇")]
        B32 = 32,
        [TranslatingKeyAttribute("Key1313", "浙江", "Zhejiang", "浙江")]
        B33 = 33,
        [TranslatingKeyAttribute("Key1314", "安徽", "Anhui", "安徽")]
        B34 = 34,
        [TranslatingKeyAttribute("Key1315", "福建", "Fujian", "福建")]
        B35 = 35,
        [TranslatingKeyAttribute("Key1316", "江西", "Jiangxi", "江西")]
        B36 = 36,
        [TranslatingKeyAttribute("Key1317", "山东", "Shandong", "山東")]
        B37 = 37,
        [TranslatingKeyAttribute("Key1318", "河南", "Henan", "河南")]
        B41 = 41,
        [TranslatingKeyAttribute("Key1319", "湖北", "Hubei", "湖北")]
        B42 = 42,
        [TranslatingKeyAttribute("Key1320", "湖南", "Hunan", "湖南")]
        B43 = 43,
        [TranslatingKeyAttribute("Key1321", "广东", "Guangdong", "廣東")]
        B44 = 44,
        [TranslatingKeyAttribute("Key1322", "广西", "Guangxi", "廣西")]
        B45 = 45,
        [TranslatingKeyAttribute("Key1323", "海南", "Hainan", "海南")]
        B46 = 46,
        [TranslatingKeyAttribute("Key1324", "重庆", "Chongqing", "重慶")]
        B50 = 50,
        [TranslatingKeyAttribute("Key1325", "四川", "Sichuan", "四川")]
        B51 = 51,
        [TranslatingKeyAttribute("Key1326", "贵州", "Guizhou", "貴州")]
        B52 = 52,
        [TranslatingKeyAttribute("Key1327", "云南", "Yunnan", "雲南")]
        B53 = 53,
        [TranslatingKeyAttribute("Key1328", "西藏", "Tibet", "西藏")]
        B54 = 54,
        [TranslatingKeyAttribute("Key1329", "陕西", "Shaanxi", "陝西")]
        B61 = 61,
        [TranslatingKeyAttribute("Key1330", "甘肃", "Gansu", "甘肅")]
        B62 = 62,
        [TranslatingKeyAttribute("Key1331", "青海", "Qinghai", "青海")]
        B63 = 63,
        [TranslatingKeyAttribute("Key1332", "宁夏", "Ningxia", "寧夏")]
        B64 = 64,
        [TranslatingKeyAttribute("Key1333", "新疆", "Xinjiang", "新疆")]
        B65 = 65,
        [TranslatingKeyAttribute("Key1334", "苏州", "Suzhou", "蘇州")]
        B71 = 71,
        [TranslatingKeyAttribute("Key1335", "宁波", "Ningbo", "寧波")]
        B72 = 72,
        [TranslatingKeyAttribute("Key1336", "深圳", "Shenzhen", "深圳")]
        B99 = 99
    }

    /// <summary>
    /// 货币类型
    /// </summary>
    public enum CashType
    {
        [TranslatingKeyAttribute("Key1400", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key1401", "人民币", "CNY", "人民幣")]
        CNY = 1,
        [TranslatingKeyAttribute("Key1402", "英镑", "GBP", "")]
        GBP = 12,
        [TranslatingKeyAttribute("Key1403", "港元", "Hong Kong Dollar", "")]
        HKD = 13,
        [TranslatingKeyAttribute("Key1404", "美元", "USD", "美元")]
        USD = 14,
        [TranslatingKeyAttribute("Key1405", "瑞士法郎", "CHF", "")]
        CHF = 15,
        [TranslatingKeyAttribute("Key1406", "德国马克", "Germany Deutsche Mark", "")]
        DEM = 16,
        [TranslatingKeyAttribute("Key1407", "法国法郎", "French franc", "")]
        FRF = 17,
        [TranslatingKeyAttribute("Key1408", "新加坡元", "SGD", "")]
        SGD = 18,
        [TranslatingKeyAttribute("Key1409", "荷兰盾", "Dutch Guilder", "")]
        NLG = 20,
        [TranslatingKeyAttribute("Key1410", "瑞典克朗", "Swedish Krona", "")]
        SEK = 21,
        [TranslatingKeyAttribute("Key1411", "丹麦克朗", "Danish Krone", "")]
        DKK = 22,
        [TranslatingKeyAttribute("Key1412", "挪威克朗", "Norwegian Krone", "")]
        NOK = 23,
        [TranslatingKeyAttribute("Key1413", "奥地利先令", "Austria shilling", "")]
        ATS = 24,
        [TranslatingKeyAttribute("Key1414", "比利时法郎", "Belgium Franc", "")]
        BEF = 25,
        [TranslatingKeyAttribute("Key1415", "意大利里拉", "Italian lira", "")]
        ITL = 26,
        [TranslatingKeyAttribute("Key1416", "日元", "JPY", "")]
        JPY = 27,
        [TranslatingKeyAttribute("Key1417", "加拿大元", "CAD", "")]
        CAD = 28,
        [TranslatingKeyAttribute("Key1418", "澳大利亚元", "AUD", "")]
        AUD = 29,
        [TranslatingKeyAttribute("Key1419", "外币金", "Dollar gold", "")]
        XAU = 34,
        [TranslatingKeyAttribute("Key1420", "本币金", "GLD", "")]
        GLD = 35,
        [TranslatingKeyAttribute("Key1421", "美元银", "XAG", "")]
        XAG = 36,
        [TranslatingKeyAttribute("Key1422", "人民币银", "SLV", "")]
        SLV = 68,
        [TranslatingKeyAttribute("Key1423", "欧元", "EUR", "")]
        EUR = 38,
        [TranslatingKeyAttribute("Key1424", "芬兰马克", "Finnmark", "")]
        FIM = 42,
        [TranslatingKeyAttribute("Key1425", "澳门元", "MOP", "")]
        MOP = 81,
        [TranslatingKeyAttribute("Key1426", "菲律宾比索", "Philippines Peso", "")]
        PHP = 82,
        [TranslatingKeyAttribute("Key1427", "泰国铢", "THB", "")]
        THB = 84,
        [TranslatingKeyAttribute("Key1428", "新西兰元", "New Zealand Dollar", "")]
        NZD = 87,
        [TranslatingKeyAttribute("Key1429", "韩元", "Korean Won", "")]
        KRW = 88,
        [TranslatingKeyAttribute("Key1430", "记账美元", "CUS$", "")]
        CLL = 94,
        [TranslatingKeyAttribute("Key1431", "清算瑞士法郎", "Clear Swiss Franc", "")]
        XHF = 95,
        [TranslatingKeyAttribute("Key1432", "印尼盾", "Indonesian rupiah", "")]
        IDR = 56,
        [TranslatingKeyAttribute("Key1433", "越南盾", "Vietnamese Dong", "")]
        VND = 64,
        [TranslatingKeyAttribute("Key1434", "阿联酋拉姆", "UAE Dirham", "")]
        AED = 777,
        [TranslatingKeyAttribute("Key1435", "阿根廷比索", "Argentina Peso", "")]
        ARS = 126,
        [TranslatingKeyAttribute("Key1436", "雷亚尔", "BRL", "")]
        BRL = 134,
        [TranslatingKeyAttribute("Key1437", "埃及镑", "Egyptian pound", "")]
        EGP = 53,
        [TranslatingKeyAttribute("Key1438", "印度卢比", "Indian Rupee", "")]
        INR = 85,
        [TranslatingKeyAttribute("Key1439", "约旦第纳尔", "Jordan Dinar", "")]
        JOD = 57,
        [TranslatingKeyAttribute("Key1440", "蒙古图格里克", "Mongolian Tugrik", "")]
        MNT = 179,
        [TranslatingKeyAttribute("Key1441", "马来西亚林吉特", "Malaysian Ringgit", "")]
        MYR = 32,
        [TranslatingKeyAttribute("Key1442", "尼日利亚奈拉", "Nigerian Naira", "")]
        NGN = 76,
        [TranslatingKeyAttribute("Key1443", "罗马尼亚列伊", "Romanian Leu", "")]
        ROL = 62,
        [TranslatingKeyAttribute("Key1444", "土耳其里拉", "Turkey Lira", "")]
        TRY = 93,
        [TranslatingKeyAttribute("Key1445", "乌克兰格里夫纳", "Ukrainian Hryvna", "")]
        UAH = 246,
        [TranslatingKeyAttribute("Key1446", "南非兰特", "South African rand", "")]
        ZAR = 70,
        [TranslatingKeyAttribute("Key1447", "博茨瓦纳普拉", "Botswana Pula", "")]
        BWP = 39,
        [TranslatingKeyAttribute("Key1448", "哈萨克斯坦坚戈", "Kazakhstani tenge", "")]
        KZT = 101,
        [TranslatingKeyAttribute("Key1449", "赞比亚克瓦查", "Zambian Kwacha", "")]
        ZMK = 80,
        [TranslatingKeyAttribute("Key1450", "福林", "HUF", "")]
        HUF = 65,
        [TranslatingKeyAttribute("Key1451", "卢布", "Ruble", "")]
        XUB = 72,
        [TranslatingKeyAttribute("Key1452", "赞比亚新克瓦查", "ZMW", "")]
        ZMW = 253,
        [TranslatingKeyAttribute("Key1453", "俄罗斯卢布", "Russia Ruble", "")]
        RUB = 196,
        [TranslatingKeyAttribute("Key1454", "白金", "XPT", "")]
        XPT = 843,
        [TranslatingKeyAttribute("Key1455", "文莱币", "BND", "")]
        BND = 131,
        [TranslatingKeyAttribute("Key1456", "柬埔寨瑞尔", "Cambodian Riel", "")]
        KHR = 166
    }

    /// <summary>
    /// 批量公用数据类型
    /// </summary>
    [Flags]
    public enum CommonFieldType
    {
        [TranslatingKeyAttribute("Key1500", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key1501", "付款人信息", "Payer Information", "付款人信息")]
        PayerInfo = 1,
        [TranslatingKeyAttribute("Key1502", "指定付款日期", "Designated Payment Date", "指定付款日期")]
        PaidDate = 2,
        [TranslatingKeyAttribute("Key1503", "处理优先级", "Processing Priority", "處理優先級")]
        OperatorOrder = 4,
        [TranslatingKeyAttribute("Key1504", "付费账号", "Payment account number", "付費帳號")]
        PayFeeNo = 8
    }

    /// <summary>
    /// 命令操作类型
    /// </summary>
    public enum OperatorCommandType
    {
        [TranslatingKeyAttribute("Key1600", "无操作", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key1601", "提交", "", "提交")]
        Submit = 1,
        [TranslatingKeyAttribute("Key1602", "修改", "", "修改")]
        Edit = 2,
        [TranslatingKeyAttribute("Key1603", "删除", "", "刪除")]
        Delete = 3,
        [TranslatingKeyAttribute("Key1604", "查看", "", "查看")]
        View = 4,
        [TranslatingKeyAttribute("Key1605", "重置", "", "重置")]
        Reset = 5,
        [TranslatingKeyAttribute("Key1606", "新建", "", "新建")]
        New = 6,
        [TranslatingKeyAttribute("Key1607", "打开", "", "打開")]
        Open = 7,
        [TranslatingKeyAttribute("Key1608", "请求保存功能设置", "", "請求保存功能設置")]
        AppVisiableRequest = 8,
        [TranslatingKeyAttribute("Key1609", "处理保存功能设置", "", "處理保存功能設置")]
        AppVisiableResolve = 9,
        [TranslatingKeyAttribute("Key1610", "请求保存批量参数设置", "", "請求保存批量參數設置")]
        MappingSettingRequest = 10,
        [TranslatingKeyAttribute("Key1611", "处理保存批量参数设置", "", "處理保存批量參數設置")]
        MappingSettingResolve = 11,
        [TranslatingKeyAttribute("Key1621", "显示匹配正常的数据", "", "顯示匹配正常的數據")]
        RightData = 21,
        [TranslatingKeyAttribute("Key1622", "显示匹配有误的数据", "", "顯示匹配錯誤的數據")]
        ErrorData = 22,
        [TranslatingKeyAttribute("Key1623", "加载所有数据并显示匹配正确的数据", "", "加載所有數據并顯示匹配正確的數據")]
        CombineData = 23,
        [TranslatingKeyAttribute("Key1624", "请求公共数据设置信息", "", "請求公共數據設置信息")]
        CommonFieldRequest = 24,
        [TranslatingKeyAttribute("Key1625", "处理公共数据设置信息", "", "處理公共數據設置信息")]
        CommonFieldResolve = 25,
        [TranslatingKeyAttribute("Key1626", "移动菜单列表", "", "移動菜單列表")]
        MoveMenuRequest = 26,
        [TranslatingKeyAttribute("Key1627", "移动菜单列表回传", "", "移動菜單列表回傳")]
        MoveMenuCallBack = 27,
        [TranslatingKeyAttribute("Key1628", "向左移动菜单列表", "", "向左移動菜單列表")]
        MoveMenuReduce = 28,
        [TranslatingKeyAttribute("Key1629", "向右移动菜单列表", "", "向右移動菜單列表")]
        MoveMenuRaise = 29,
        [TranslatingKeyAttribute("Key1630", "加载数据", "", "加載數據")]
        Load = 30,
        [TranslatingKeyAttribute("Key1631", "请求银行类型变更", "", "請求銀行類型變更")]
        BankTypeRequest = 31,
        [TranslatingKeyAttribute("Key1632", "反馈银行类型变更", "", "反饋銀行類型變更")]
        BankTypeCallBack = 32,
        [TranslatingKeyAttribute("Key1633", "银行类型变更", "", "銀行類型變更")]
        BankTypeChanged = 33,
        [TranslatingKeyAttribute("Key1632", "编辑操作请求", "", "編輯操作請求")]
        EditOperatorRequest = 32,
        [TranslatingKeyAttribute("Key1633", "编辑操作反馈", "", "編輯操作反饋")]
        EditOperatorCallBack = 33,
        [TranslatingKeyAttribute("Key1634", "请求卡类型变更", "", "請求卡類型變更")]
        CardTypeRequest = 34,
        [TranslatingKeyAttribute("Key1635", "反馈卡类型变更", "", "反饋卡類型變更")]
        CardTypeCallBack = 35,
        [TranslatingKeyAttribute("Key1636", "卡类型变更", "", "卡類型變更")]
        CardTypeChanged = 36,
        [TranslatingKeyAttribute("Key1637", "请求用途类型变更", "", "請求用途類型變更")]
        UseTypeRequest = 37,
        [TranslatingKeyAttribute("Key1638", "反馈用途类型变更", "", "反饋用途類型變更")]
        UseTypeCallBack = 38,
        [TranslatingKeyAttribute("Key1639", "用途类型变更", "", "用途類型變更")]
        UseTypeChanged = 39,
        [TranslatingKeyAttribute("Key1640", "票据类型变更", "", "票據類型變更")]
        TicketTypeChanged = 40,
        [TranslatingKeyAttribute("Key1641", "公用数据锁定显示", "", "公用數據鎖定顯示")]
        CommonFieldLockShow = 41,
        [TranslatingKeyAttribute("Key1642", "公用数据锁定隐藏", "", "公用數據鎖定隱藏")]
        CommonFieldLockHide = 42,
        [TranslatingKeyAttribute("Key1643", "全选", "", "")]
        SelectAll = 43,
        [TranslatingKeyAttribute("Key1644", "反选", "", "")]
        SelectRe = 44,
        [TranslatingKeyAttribute("Key1645", "请求收款人账号类型变更", "", "")]
        PayeeAccountTypeRequest = 45,
        [TranslatingKeyAttribute("Key1646", "反馈收款人账号类型变更", "", "")]
        PayeeAccountTypeCallBack = 46,
        [TranslatingKeyAttribute("Key1647", "收款人账号类型变更", "", "")]
        PayeeAccountTypeChanged = 47,
        [TranslatingKeyAttribute("Key1648", "打印", "", "")]
        Print = 48,
        [TranslatingKeyAttribute("Key1649", "上移", "", "")]
        DataMoveUp = 49,
        [TranslatingKeyAttribute("Key1650", "下移", "", "")]
        DataMoveDown = 50,
    }

    //跨行速汇-业务种类
    public enum BusinessType
    {
        [TranslatingKeyAttribute("Key1970", "", "", "")]
        Empty = 0,

        [TranslatingKeyAttribute("Key1971", "电费", "Electricity Bill", "電費")]
        EnergyFee = 100,

        [TranslatingKeyAttribute("Key1972", "水暖费", "Water & heating bill", "水暖費")]
        WaterFee = 200,

        [TranslatingKeyAttribute("Key1973", "煤气费", "Gas bill", "煤氣費")]
        GasFee = 300,

        [TranslatingKeyAttribute("Key1974", "电话费", "Telephone bill", "電話費")]
        PhoneFee = 400,

        [TranslatingKeyAttribute("Key1975", "通讯费", "Phone bill", "通訊費")]
        CommunicationFee = 500,

        [TranslatingKeyAttribute("Key1976", "保险费", "Insurance premium", "保險費")]
        SecureFee = 600,

        [TranslatingKeyAttribute("Key1977", "房屋管理费", "Warehouse management fee", "房屋管理費")]
        HouseMgFee = 700,

        [TranslatingKeyAttribute("Key1978", "代理服务费", "Agency service fee", "代理服務費")]
        AgentServiceFee = 800,

        [TranslatingKeyAttribute("Key1979", "学教费", "Tuition", "學教費")]
        TechingFee = 900,

        [TranslatingKeyAttribute("Key1980", "有线电视费", "Cabled TV bill", "有線電視費")]
        TVFee = 1000,

        [TranslatingKeyAttribute("Key1981", "企业管理费", "Enterprise management expense", "企業管理費")]
        CropMgFee = 1100,

        [TranslatingKeyAttribute("Key1982", "薪金报酬", "Remuneration", "薪金報酬")]
        Salary = 1200,

        [TranslatingKeyAttribute("Key1983", "贷款还房贷类", "Loan repayment–housing loan", "貸款還房貸類")]
        PayForHouse = 2025,

        [TranslatingKeyAttribute("Key1984", "贷款还车贷类", "Loan repayment–car loan", "貸款還車貸類")]
        PayForCar = 2026,

        [TranslatingKeyAttribute("Key1985", "贷款还信用卡类", "Loan repayment–credit card", "貸款還信用卡類")]
        PayForCreditCard = 2027,

        [TranslatingKeyAttribute("Key1986", "其他", "Other", "其他")]
        Other = 9001
    }

    //快捷代发-用途
    public enum AgentExpressFunctionType
    {
        Empty = -1,
        [TranslatingKeyAttribute("Key1900", "话费", "", "")]
        E0 = 0,
        [TranslatingKeyAttribute("Key1901", "还款", "Repayment", "還款")]
        E1 = 1,
        [TranslatingKeyAttribute("Key1902", "奖金", "Bonus", "獎金")]
        E8 = 2,
        [TranslatingKeyAttribute("Key1903", "缴费", "Fee Payment", "繳費")]
        E9 = 3,
        [TranslatingKeyAttribute("Key1904", "医保", "Medical insurance", "醫保")]
        EA = 4,
        [TranslatingKeyAttribute("Key1905", "保险", "Insurance", "保險")]
        EB = 5,
        [TranslatingKeyAttribute("Key1906", "报销", "Reimbursement", "報銷")]
        EC = 6,
        [TranslatingKeyAttribute("Key1907", "补偿", "Compensate", "補償")]
        ED = 7,
        [TranslatingKeyAttribute("Key1908", "补贴", "Subsidy", "補貼")]
        EE = 8,
        [TranslatingKeyAttribute("Key1909", "差旅", "Travel", "差旅")]
        EF = 9,
        [TranslatingKeyAttribute("Key1910", "冲正", "Reverse", "沖正")]
        EG = 10,
        [TranslatingKeyAttribute("Key1911", "代付", "Agency payment", "代發")]
        EH = 11,
        [TranslatingKeyAttribute("Key1912", "电费", "Electricity Bill", "電費")]
        EJ = 12,
        [TranslatingKeyAttribute("Key1913", "电信", "Telecommunications", "電信")]
        EK = 13,
        [TranslatingKeyAttribute("Key1914", "短信", "SMS", "短訊")]
        EL = 14,
        [TranslatingKeyAttribute("Key1915", "房租", "House rent", "房租")]
        ES = 15,
        [TranslatingKeyAttribute("Key1916", "分红", "Dividend", "分紅")]
        ET = 16,
        [TranslatingKeyAttribute("Key1917", "个税", "Personal tax", "個稅")]
        EU = 17,
        [TranslatingKeyAttribute("Key1918", "工资", "Salary", "工資")]
        EV = 18,
        [TranslatingKeyAttribute("Key1919", "公积", "Public provident", "公積")]
        EW = 19,
        [TranslatingKeyAttribute("Key1920", "户费", "Account fee", "戶費")]
        EZ = 20,
        [TranslatingKeyAttribute("Key1921", "有线", "Wired", "有線")]
        F4 = 21,
        [TranslatingKeyAttribute("Key1922", "扣费", "Deduct fee", "扣費")]
        FA = 22,
        [TranslatingKeyAttribute("Key1923", "扣划", "Deduct & transferFB", "扣劃")]
        FB = 23,
        [TranslatingKeyAttribute("Key1924", "理财", "Wealth management", "理財")]
        FD = 24,
        [TranslatingKeyAttribute("Key1925", "年费", "annual feeFK", "年費")]
        FK = 25,
        [TranslatingKeyAttribute("Key1926", "社保", "Social insurance", "社保")]
        FO = 26,
        [TranslatingKeyAttribute("Key1927", "水费", "", "水費")]
        FQ = 27,
        [TranslatingKeyAttribute("Key1928", "税款", "Tax", "稅款")]
        FR = 28,
        [TranslatingKeyAttribute("Key1929", "学费", "Tuition", "學費")]
        FZ = 29,
        [TranslatingKeyAttribute("Key1930", "收费", "Charged", "收費")]
        GB = 30,
        [TranslatingKeyAttribute("Key1931", "捐赠", "Donation", "捐贈")]
        GG = 31,
        [TranslatingKeyAttribute("Key1932", "药费", "Medical expense", "藥費")]
        G1 = 32,
        [TranslatingKeyAttribute("Key1933", "福利", "Welfare", "福利")]
        K4 = 33,
        [TranslatingKeyAttribute("Key1934", "保费", "Insurance Premium", "保費")]
        G8 = 34,
        [TranslatingKeyAttribute("Key1935", "基养", "Infrastructure maintenance", "基養")]
        GH = 35,
        [TranslatingKeyAttribute("Key1936", "过节", "Festival", "過節")]
        KB = 36,
        [TranslatingKeyAttribute("Key1937", "劳保", "Labor protection", "勞保")]
        KD = 37,
        [TranslatingKeyAttribute("Key1938", "电话", "Phone bill", "電話")]
        KK = 38,
        [TranslatingKeyAttribute("Key1939", "安置", "Arrange", "安置")]
        KO = 39,
        [TranslatingKeyAttribute("Key1940", "权益", "", "")]
        KQ = 40,
        [TranslatingKeyAttribute("Key1941", "劳务", "", "")]
        FC = 41,
        [TranslatingKeyAttribute("Key1942", "低保", "", "")]
        NC = 42,
        [TranslatingKeyAttribute("Key1943", "过渡", "", "")]
        Ed = 43,
        [TranslatingKeyAttribute("Key1944", "冬春", "", "")]
        Ec = 44,
        [TranslatingKeyAttribute("Key1945", "退款", "", "")]
        JF = 45,
        [TranslatingKeyAttribute("Key1946", "借款", "", "")]
        f9 = 46,
        [TranslatingKeyAttribute("Key1947", "贷款", "", "")]
        fa = 47,
        [TranslatingKeyAttribute("Key1948", "年金", "", "")]
        IN = 48,
        [TranslatingKeyAttribute("Key1948", "其他", "", "")]
        JS = 999,
    }

    //代发卡类型
    public enum AgentCardType
    {
        [TranslatingKeyAttribute("Key1950", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key1951", "借记卡或存折", "Debit card or passbook", "借記卡或存摺")]
        MemoryCard = 1,
        [TranslatingKeyAttribute("Key1952", "QCC卡(QCC卡及信用卡)", "QCC card (QCC card and credit card)", "QCC卡(QCC卡及信用卡)")]
        QCCCard = 4,
        [TranslatingKeyAttribute("Key1953", "他行卡", "Non-BOC Card", "他行卡")]
        OtherBankCard = 6,
    }

    //普通代发-用途
    public enum AgentNormalFunctionType
    {
        [TranslatingKeyAttribute("Key2011", "Empty", "", "")]
        Empty = -1,
        [TranslatingKeyAttribute("Key2000", "工资", "Salary", "工資")]
        A10 = 0,
        [TranslatingKeyAttribute("Key2001", "稿费、演出费等劳务收入", "Contribution fee, performance fee and other labor income", "稿費、演出費等勞務收入")]
        A11 = 1,
        [TranslatingKeyAttribute("Key2002", "债卷、期货、信托等投资的本金和收益", "Principal and interest of bonds, futures, trusts and other investments", "債卷、期貨、信託等投資的本金和收入")]
        A12 = 2,
        [TranslatingKeyAttribute("Key2003", "个人债权或产权转让收益", "Personal Bond/Property Transfer Income", "個人債務或產權轉讓收益")]
        A13 = 3,
        [TranslatingKeyAttribute("Key2004", "个人贷款转存", "Redeposit Personal Loan", "個人貸款轉存")]
        A14 = 4,
        [TranslatingKeyAttribute("Key2005", "报销", "Reimburse", "報銷")]
        A15 = 5,
        [TranslatingKeyAttribute("Key2006", "继承、赠与款项", "Inherited & Donated Fund", "繼承、贈與款項")]
        A16 = 6,
        [TranslatingKeyAttribute("Key2007", "保险理赔、保费退还等款项", "Insurance claim settlement, premium return and other funds", "保險理賠、保費退還等款項")]
        A17 = 7,
        [TranslatingKeyAttribute("Key2008", "纳税退还", "Tax Rebate", "納稅退還")]
        A18 = 8,
        [TranslatingKeyAttribute("Key2009", "农、福、矿产品销售收入", "Agricultural, Sideline & Mineral Sales Income", "農、福、礦產品銷售收入")]
        A19 = 9,
        [TranslatingKeyAttribute("Key2010", "其他合法款项", "Other legal funds", "其他合法款項")]
        A20 = 10
    }

    //更新文件类型
    public enum UpdateFleType
    {
        [TranslatingKeyAttribute("Key2100", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2101", "中行联行号", "BOC Correspondent Number", "中行聯行號")]
        BankLinkNo = 1,
        [TranslatingKeyAttribute("Key2102", "CNAPS行号", "CNAPS Code", "CNAPS行號")]
        OpenBankInfo = 2,
        [TranslatingKeyAttribute("Key2103", "清算行号", "SWIFT Code", "清算行號")]
        ClearBankInfo = 3,
        [TranslatingKeyAttribute("Key2104", "电子汇票行号", "", "")]
        ElecTicket = 4
    }

    /// <summary>
    /// 票据类型
    /// 212*
    /// </summary>
    public enum ElecTicketType
    {
        [TranslatingKeyAttribute("Key2120", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2121", "银承", "Bank Acceptance Draft", "銀承")]
        AC01 = 1,
        [TranslatingKeyAttribute("Key2122", "商承", "Commercial Acceptance Draft", "商承")]
        AC02 = 2
    }

    /// <summary>
    /// 关系人属性
    /// 214*
    /// </summary>
    [Flags]
    public enum RelatePersonType
    {
        [TranslatingKeyAttribute("Key2140", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2141", "承兑人", "Acceptor", "承兌人")]
        Exchange = 1,
        [TranslatingKeyAttribute("Key2143", "收款人", "Payee", "收款人")]
        Payee = 2,
        [TranslatingKeyAttribute("Key2145", "保证人", "Guarantor", "保證人")]
        Guarantor = 4,
        [TranslatingKeyAttribute("Key2147", "质权人", "Pledgee", "質權人")]
        QRigth = 8,
        [TranslatingKeyAttribute("Key2142", "贴入人", "Discountee", "貼入人")]
        StickOn = 16,
        [TranslatingKeyAttribute("Key2144", "被背书人", "Endorsee", "被背書人")]
        BackNoted = 32,
        [TranslatingKeyAttribute("Key2146", "被追索人", "Recoursee", "被追索人")]
        Recoursed = 64,
        [TranslatingKeyAttribute("Key2148", "看票人", "Checker", "看票人")]
        ViewElecTicket = 128,
        [TranslatingKeyAttribute("Key2149", "出票人", "Drawer", "出票人")]
        Remittor = 256,
    }

    /// <summary>
    /// 可否转让
    /// </summary>
    public enum CanChangeType
    {
        [TranslatingKeyAttribute("Key2170", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2171", "可以转让", "Negotiable", "可以轉讓")]
        EM00 = 1,
        [TranslatingKeyAttribute("Key2172", "禁止转让", "Nonnegotiable", "禁止轉讓")]
        EM01 = 2,
    }

    /// <summary>
    /// 清算方式
    /// </summary>
    public enum ClearMoneyType
    {
        [TranslatingKeyAttribute("Key2180", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2181", "线上清算", "Online Clearing", "線上清算")]
        SM00 = 1,
        [TranslatingKeyAttribute("Key2182", "线下清算", "Offline Clearing", "線下清算")]
        SM01 = 2
    }

    /// <summary>
    /// 票据池-到期操作
    /// </summary>
    public enum EndDateOperateType
    {
        [TranslatingKeyAttribute("Key2190", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2191", "自动托收", "Automatic Collection", "自動托收")]
        AutoReceive = 1,
        [TranslatingKeyAttribute("Key2192", "自动提醒", "Automatic Alert", "自動提醒")]
        AutoTip = 2
    }

    /// <summary>
    /// 票据池-业务种类
    /// </summary>
    public enum ElecTicketPoolBusinessType
    {
        [TranslatingKeyAttribute("Key2200", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2201", "入池托管", "Pool Entry Custody", "入池託管")]
        InPool2Struste = 1,
        [TranslatingKeyAttribute("Key2202", "入池质押", "Pool Entry Pledge", "入池質押")]
        InPool2Mortgage = 2
    }

    /// <summary>
    /// 国际结算--国内外费用承担类型
    /// </summary>
    public enum AssumeFeeType
    {
        [TranslatingKeyAttribute("Key2210", "", "", "")]
        Empty = -1,
        [TranslatingKeyAttribute("Key2211", "共同SHA", "Joint", "")]
        SHA = 0,
        [TranslatingKeyAttribute("Key2212", "汇款人OUR", "Remitter", "")]
        OUR = 1,
        [TranslatingKeyAttribute("Key2213", "收款人BEN", "Payee", "")]
        BEN = 2
    }

    /// <summary>
    /// 国际结算/外币统一支付--付款方式
    /// </summary>
    public enum PayFeeType
    {
        [TranslatingKeyAttribute("Key2220", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2221", "预付货款", "Advance Goods Payment", "")]
        A = 1,
        [TranslatingKeyAttribute("Key2222", "货到付款", "Payment on Delivery", "")]
        P = 2,
        [TranslatingKeyAttribute("Key2223", "退款", "Return", "")]
        R = 3,
        [TranslatingKeyAttribute("Key2224", "其他", "Other", "")]
        O = 4
    }

    /// <summary>
    /// 付汇性质
    /// </summary>
    public enum PaymentPropertyType
    {
        [TranslatingKeyAttribute("Key2230", "", "", "")]
        Empty = -1,
        [TranslatingKeyAttribute("Key2231", "保税区", "Bonded Area", "")]
        FreeArea = 0,
        [TranslatingKeyAttribute("Key2232", "出口加工区", "Export Processing Area", "")]
        ExportFabricationPlant = 1,
        [TranslatingKeyAttribute("Key2233", "钻石交易所", "Diamond Exchange", "")]
        DiamondBourse = 2,
        [TranslatingKeyAttribute("Key2234", "深加工结转", "Deep Processing Carryover", "")]
        IntensifyCarryForword = 4,
        [TranslatingKeyAttribute("Key2235", "其他特殊经济区域", "Other Special Economic Zones", "")]
        OtherSpecialArea = 5,
        [TranslatingKeyAttribute("Key2236", "其他", "Other", "")]
        Other = 6
    }

    /// <summary>
    /// 国际结算-付费账户类型
    /// </summary>
    public enum PayFeeAccountType
    {
        [TranslatingKeyAttribute("Key2240", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2241", "同现汇账户", "Same as spot exchange account", "")]
        SpotAccount = 1,
        [TranslatingKeyAttribute("Key2242", "同购汇账户", "Same as exchange purchase account", "")]
        PurchaseAccount = 2,
        [TranslatingKeyAttribute("Key2243", "同其他账户", "Same as other accounts ", "")]
        OtherAccount = 3,
    }

    /// <summary>
    /// 国际结算收款人账户类型
    /// </summary>
    public enum OverCountryPayeeAccountType
    {
        [TranslatingKeyAttribute("Key2250", "", "", "")]
        Empty = -1,
        [TranslatingKeyAttribute("Key2251", "境内他行收款人", "Domestic non-BOC Payee", "")]
        OtherAccount = 0,
        [TranslatingKeyAttribute("Key2252", "境内中行收款人", "Domestic BOC Payee", "")]
        BocAccount = 1,
        [TranslatingKeyAttribute("Key2253", "境外收款人", "Overseas Payee", "")]
        ForeignAccount = 4,
    }

    /// <summary>
    /// 供应链-结算方式
    /// </summary>
    public enum SettlementType
    {
        [TranslatingKeyAttribute("Key2260", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2261", "货到付款", "Payment on Delivery", "")]
        PayAfter = 1,
        [TranslatingKeyAttribute("Key2262", "款到发货", "Delivery Against Payment", "")]
        PayFirst = 2,
        [TranslatingKeyAttribute("Key2263", "赊销", "Sale on Credit", "")]
        PayNo = 3,
    }

    /// <summary>
    /// 供应链-利率浮动方式
    /// </summary>
    public enum InterestFloatType
    {
        [TranslatingKeyAttribute("Key2270", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2271", "上浮", "Float Upward", "")]
        Up = 1,
        [TranslatingKeyAttribute("Key2272", "下浮", "Float Downward", "")]
        Down = 2,
        [TranslatingKeyAttribute("Key2273", "不浮动", "No Floating", "")]
        No = 3,
    }

    /// <summary>
    /// 付款方式
    /// </summary>
    public enum PaymentType
    {
        [TranslatingKeyAttribute("Key2280", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2281", "电汇", "Telegraphic Transfer", "")]
        Telegraphic = 1,
        [TranslatingKeyAttribute("Key2282", "票汇", "Demand Draft", "")]
        Draft = 2,
        [TranslatingKeyAttribute("Key2283", "信汇", "Mail Transfer", "")]
        Mail = 3,
    }

    /// <summary>
    /// 汇票贴现-付息方式
    /// </summary>
    public enum ProtocolMoneyType
    {
        [TranslatingKeyAttribute("Key2290", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2291", "协议付息", "Negotiated Interest Payment", "")]
        NegotiatedInterestPayment = 1,
        [TranslatingKeyAttribute("Key2292", "贴现申请人付息", "Interest Payment by Discount Applicant", "")]
        ByDiscountApplicant = 2,
    }

    /// <summary>
    /// 统一支付人民币-付款方式
    /// </summary>
    public enum UnitivePaymentType
    {
        [TranslatingKeyAttribute("Key2300", "", "", "")]
        Empty = -1,
        [TranslatingKeyAttribute("Key2301", "实时", "", "")]
        ActualTime = 0,
        [TranslatingKeyAttribute("Key2302", "预约", "", "")]
        Order = 1,
    }

    /// <summary>
    /// 跨行外币的业务类型--柜台
    /// </summary>
    public enum BarBusinessType
    {
        [TranslatingKeyAttribute("Key2350", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2351", "支付运保费", "", "")]
        BBT01 = 1,
        [TranslatingKeyAttribute("Key2352", "代理进出口", "", "")]
        BBT02 = 2,
        [TranslatingKeyAttribute("Key2353", "与特殊经济区企业资金往来", "", "")]
        BBT03 = 3,
        [TranslatingKeyAttribute("Key2354", "同一企业不同账户资金划转", "", "")]
        BBT04 = 4,
        [TranslatingKeyAttribute("Key2355", "归还国内外贷款或转贷款", "", "")]
        BBT05 = 5,
        [TranslatingKeyAttribute("Key2356", "贸易深加工结转业务", "", "")]
        BBT06 = 6,
        [TranslatingKeyAttribute("Key2357", "贸易融资业务", "", "")]
        BBT07 = 7,
        [TranslatingKeyAttribute("Key2358", "其它", "", "")]
        BBT08 = 8,
    }

    /// <summary>
    /// 跨行外币的申报标知--柜台
    /// </summary>
    public enum BarApplyFlagType
    {
        [TranslatingKeyAttribute("Key2400", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2401", "不申报", "", "")]
        N = 1,
        [TranslatingKeyAttribute("Key2402", "境内汇款", "", "")]
        E = 2,
    }

    public enum VersionType
    {
        v307 = 1,
        v402 = 2,
        t42 = 4,
        v403 = 8,
        v403bar = 16,
        t43 = 32,
        v405 = 64,
        t51 = 128,
        v501 = 256,
        v502=512,
    }

    /// <summary>
    /// 外币统一支付-汇往国家
    /// </summary>
    public enum Transfer2CountryType
    {
        [TranslatingKeyAttribute("Key2450", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2451", "美国", "", "")]
        US = 1,
        [TranslatingKeyAttribute("Key2452", "澳洲", "", "")]
        AU = 2,
        [TranslatingKeyAttribute("Key2453", "加拿大", "", "")]
        CA = 3,
        [TranslatingKeyAttribute("Key2454", "欧盟", "", "")]
        EU = 4,
        [TranslatingKeyAttribute("Key2455", "英国", "", "")]
        GB = 5,
        [TranslatingKeyAttribute("Key2456", "日本", "", "")]
        JP = 6,
        [TranslatingKeyAttribute("Key2457", "韩国", "", "")]
        KR = 7,
        [TranslatingKeyAttribute("Key2458", "印度", "", "")]
        IN = 8,
        [TranslatingKeyAttribute("Key2459", "澳门", "", "")]
        MO = 9,
        [TranslatingKeyAttribute("Key2460", "台湾", "", "")]
        TW = 10,
        [TranslatingKeyAttribute("Key2461", "香港", "", "")]
        HK = 11,
        [TranslatingKeyAttribute("Key2462", "新加坡", "", "")]
        SG = 12,
        [TranslatingKeyAttribute("Key2463", "新西兰", "", "")]
        NZ = 13,
        [TranslatingKeyAttribute("Key2464", "巴西", "", "")]
        BR = 14,
        [TranslatingKeyAttribute("Key2465", "其他地区", "", "")]
        ZZ = 15,
    }

    /// <summary>
    /// 是否进口核销
    /// </summary>
    public enum IsImportCancelAfterVerificationType
    {
        [TranslatingKeyAttribute("Key2500", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2501", "是", "", "")]
        Y = 1,
        [TranslatingKeyAttribute("Key2502", "否", "", "")]
        N = 2,
    }

    /// <summary>
    /// 收款人账号类型-外币统一支付（跨境）
    /// </summary>
    public enum UnitiveFCPayeeAccountType
    {
        [TranslatingKeyAttribute("Key2510", "", "", "")]
        Empty = 0,
        [TranslatingKeyAttribute("Key2511", "普通账号", "", "")]
        A = 1,
        [TranslatingKeyAttribute("Key2512", "IBAN账号", "", "")]
        B = 2,
    }
}
