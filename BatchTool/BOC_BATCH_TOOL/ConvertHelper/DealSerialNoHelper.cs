using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.ConvertHelper
{
    public class DealSerialNoListHelper
    {
        #region 单例
        private static object Lock_obj = new object();
        private static DealSerialNoListHelper m_instance;
        //单例
        public static DealSerialNoListHelper Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (Lock_obj)
                    {
                        if (null == m_instance)
                        {
                            lock (Lock_obj)
                            {
                                m_instance = new DealSerialNoListHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        //public CNAP Dsnh_一般贸易收入 { get { return GetCNAP(1001); } }
        //public CNAP Dsnh_补偿贸易收入 { get { return GetCNAP(1002); } }
        //public CNAP Dsnh_寄售代销贸易收入 { get { return GetCNAP(1003); } }
        //public CNAP Dsnh_边境贸易收入 { get { return GetCNAP(1004); } }
        //public CNAP Dsnh_对外承包工程货物出口收入 { get { return GetCNAP(1005); } }
        //public CNAP Dsnh_水_电_煤气_天然气等出口收入 { get { return GetCNAP(1006); } }
        //public CNAP Dsnh_出售运输工具_天然气石油井架_工作台和其他活动设备收入 { get { return GetCNAP(1007); } }
        //public CNAP Dsnh_易货贸易收入 { get { return GetCNAP(1008); } }
        //public CNAP Dsnh_远洋渔业_石油_矿产销售收入 { get { return GetCNAP(1009); } }
        //public CNAP Dsnh_来料加工装配贸易出口 { get { return GetCNAP(1010); } }
        //public CNAP Dsnh_进料加工贸易项下的成品出口 { get { return GetCNAP(1011); } }
        //public CNAP Dsnh_出料加工贸易出口 { get { return GetCNAP(1012); } }
        //public CNAP Dsnh_为修理提供货物所得收入 { get { return GetCNAP(1013); } }
        //public CNAP Dsnh_在港口为运输工具提供货物的收入 { get { return GetCNAP(1014); } }
        //public CNAP Dsnh_非货币黄金进出口收入 { get { return GetCNAP(1015); } }
        //public CNAP Dsnh_其他收入_1016 { get { return GetCNAP(1016); } }
        //public CNAP Dsnh_客运收入 { get { return GetCNAP(1017); } }
        //public CNAP Dsnh_为货物出口提供运输的收入 { get { return GetCNAP(1018); } }
        //public CNAP Dsnh_为货物进口提供运输的收入 { get { return GetCNAP(1019); } }
        //public CNAP Dsnh_港口服务收入 { get { return GetCNAP(1020); } }
        //public CNAP Dsnh_其他收入_1021 { get { return GetCNAP(1021); } }
        //public CNAP Dsnh_客运收入_1022 { get { return GetCNAP(1022); } }
        //public CNAP Dsnh_为货物出口提供运输的收入_1023 { get { return GetCNAP(1023); } }
        //public CNAP Dsnh_为货物进口提供运输的收入_1024 { get { return GetCNAP(1024); } }
        //public CNAP Dsnh_港口服务收入_1025 { get { return GetCNAP(1025); } }
        //public CNAP Dsnh_其他收入_1026 { get { return GetCNAP(1026); } }
        //public CNAP Dsnh_客运收入_1027 { get { return GetCNAP(1027); } }
        //public CNAP Dsnh_为货物出口提供运输的收入_1028 { get { return GetCNAP(1028); } }
        //public CNAP Dsnh_为货物进口提供运输的收入_1029 { get { return GetCNAP(1029); } }
        //public CNAP Dsnh_港口服务收入_1030 { get { return GetCNAP(1030); } }
        //public CNAP Dsnh_其他收入_1031 { get { return GetCNAP(1031); } }
        //public CNAP Dsnh_运输佣金_代理费收入 { get { return GetCNAP(1032); } }
        //public CNAP Dsnh_旅游企业团费收入 { get { return GetCNAP(1033); } }
        //public CNAP Dsnh_公务及商务差旅收入 { get { return GetCNAP(1034); } }
        //public CNAP Dsnh_因私旅游收入 { get { return GetCNAP(1035); } }
        //public CNAP Dsnh_医疗_保健收入 { get { return GetCNAP(1036); } }
        //public CNAP Dsnh_电信服务收入 { get { return GetCNAP(1037); } }
        //public CNAP Dsnh_邮政_邮递服务收入 { get { return GetCNAP(1038); } }
        //public CNAP Dsnh_建筑_安装服务收入 { get { return GetCNAP(1039); } }
        //public CNAP Dsnh_劳务承包收入 { get { return GetCNAP(1040); } }
        //public CNAP Dsnh_责任险收入 { get { return GetCNAP(1041); } }
        //public CNAP Dsnh_信用保证险收入 { get { return GetCNAP(1042); } }
        //public CNAP Dsnh_进出口货运险收入 { get { return GetCNAP(1043); } }
        //public CNAP Dsnh_其他险收入 { get { return GetCNAP(1044); } }
        //public CNAP Dsnh_人身险收入 { get { return GetCNAP(1045); } }
        //public CNAP Dsnh_再保险收入 { get { return GetCNAP(1046); } }
        //public CNAP Dsnh_保险中介服务收入 { get { return GetCNAP(1047); } }
        //public CNAP Dsnh_其他保险收入 { get { return GetCNAP(1048); } }
        //public CNAP Dsnh_金融服务中介费_手续费_担保费_承诺费收入 { get { return GetCNAP(1049); } }
        //public CNAP Dsnh_与计算机有关的其他服务收入 { get { return GetCNAP(1050); } }
        //public CNAP Dsnh_书刊_杂志和电子出版物以及新闻_信息服务收入 { get { return GetCNAP(1051); } }
        //public CNAP Dsnh_专利特许权收入 { get { return GetCNAP(1052); } }
        //public CNAP Dsnh_非专利发明或专有技术收入 { get { return GetCNAP(1053); } }
        //public CNAP Dsnh_经营权_经销权收入 { get { return GetCNAP(1054); } }
        //public CNAP Dsnh_商标_制作方法收入 { get { return GetCNAP(1055); } }
        //public CNAP Dsnh_版权_著作权_稿费收入 { get { return GetCNAP(1056); } }
        //public CNAP Dsnh_电影_音像服务收入 { get { return GetCNAP(1057); } }
        //public CNAP Dsnh_体育_健身及其他文化_娱乐服务收入 { get { return GetCNAP(1058); } }
        //public CNAP Dsnh_签证认证费收入 { get { return GetCNAP(1059); } }
        //public CNAP Dsnh_使领馆经费收入 { get { return GetCNAP(1060); } }
        //public CNAP Dsnh_转口贸易收入 { get { return GetCNAP(1061); } }
        //public CNAP Dsnh_转口贸易价差收入 { get { return GetCNAP(1062); } }
        //public CNAP Dsnh_进出口佣金收入 { get { return GetCNAP(1063); } }
        //public CNAP Dsnh_带料加工贸易加工费收入 { get { return GetCNAP(1064); } }
        //public CNAP Dsnh_经营性租赁服务收入 { get { return GetCNAP(1065); } }
        //public CNAP Dsnh_法律服务_仲裁收入 { get { return GetCNAP(1066); } }
        //public CNAP Dsnh_会计服务收入 { get { return GetCNAP(1067); } }
        //public CNAP Dsnh_管理咨询服务收入 { get { return GetCNAP(1068); } }
        //public CNAP Dsnh_认证_公证服务收入 { get { return GetCNAP(1069); } }
        //public CNAP Dsnh_其他收入_1070 { get { return GetCNAP(1070); } }
        //public CNAP Dsnh_广告_展览收入 { get { return GetCNAP(1071); } }
        //public CNAP Dsnh_市场调研收入 { get { return GetCNAP(1072); } }
        //public CNAP Dsnh_工业_技术研究与发展收入 { get { return GetCNAP(1073); } }
        //public CNAP Dsnh_理论_科学研究与发展收入 { get { return GetCNAP(1074); } }
        //public CNAP Dsnh_建筑_工程技术服务收入 { get { return GetCNAP(1075); } }
        //public CNAP Dsnh_其他收入_1076 { get { return GetCNAP(1076); } }
        //public CNAP Dsnh_驻华机构办公经费 { get { return GetCNAP(1077); } }
        //public CNAP Dsnh_会费收入 { get { return GetCNAP(1078); } }
        //public CNAP Dsnh_其他收入_1079 { get { return GetCNAP(1079); } }
        //public CNAP Dsnh_职工报酬__一年以下雇员汇款收入 { get { return GetCNAP(1080); } }
        //public CNAP Dsnh_利润汇回 { get { return GetCNAP(1081); } }
        //public CNAP Dsnh_建筑物租金收入 { get { return GetCNAP(1082); } }
        //public CNAP Dsnh_对母_分公司_附属及关联方贷款利息收入 { get { return GetCNAP(1083); } }
        //public CNAP Dsnh_股票投资收益收入 { get { return GetCNAP(1084); } }
        //public CNAP Dsnh_债券投资收益收入 { get { return GetCNAP(1085); } }
        //public CNAP Dsnh_其他投资收益_贷款及其他债权利息收入 { get { return GetCNAP(1086); } }
        //public CNAP Dsnh_接受与固定资产无关的捐赠及无偿援助 { get { return GetCNAP(1087); } }
        //public CNAP Dsnh_保险赔偿收入 { get { return GetCNAP(1088); } }
        //public CNAP Dsnh_其他赔偿收入 { get { return GetCNAP(1089); } }
        //public CNAP Dsnh_税收收入_如所得税_财产税_社会福利_运输工具注册费等 { get { return GetCNAP(1090); } }
        //public CNAP Dsnh_罚款_追缴款收入 { get { return GetCNAP(1091); } }
        //public CNAP Dsnh_国际组织会费收入 { get { return GetCNAP(1092); } }
        //public CNAP Dsnh_一年以上雇员汇款收入 { get { return GetCNAP(1093); } }
        //public CNAP Dsnh_偶然性收入 { get { return GetCNAP(1094); } }
        //public CNAP Dsnh_其他收入_1095 { get { return GetCNAP(1095); } }
        //public CNAP Dsnh_接受与固定资产有关的捐赠及无偿援助 { get { return GetCNAP(1096); } }
        //public CNAP Dsnh_国外支付的赔偿 { get { return GetCNAP(1097); } }
        //public CNAP Dsnh_税收收入 { get { return GetCNAP(1098); } }
        //public CNAP Dsnh_移民的转移收入 { get { return GetCNAP(1099); } }
        //public CNAP Dsnh_其他收入_1100 { get { return GetCNAP(1100); } }
        //public CNAP Dsnh_土地批租_租赁收入 { get { return GetCNAP(1101); } }
        //public CNAP Dsnh_商标_专利的所有权转让收入 { get { return GetCNAP(1102); } }
        //public CNAP Dsnh_其他无形资产的所有权转让收入 { get { return GetCNAP(1103); } }
        //public CNAP Dsnh_境外投资企业清算_终止等撤资 { get { return GetCNAP(1104); } }
        //public CNAP Dsnh_筹备资金撤回 { get { return GetCNAP(1105); } }
        //public CNAP Dsnh_直接投资者境外投资企业减资 { get { return GetCNAP(1106); } }
        //public CNAP Dsnh_将境外投资企业中方股权转让给外方 { get { return GetCNAP(1107); } }
        //public CNAP Dsnh_将境外投资企业中方股权转让给其他中方 { get { return GetCNAP(1108); } }
        //public CNAP Dsnh_中方先行收回投资 { get { return GetCNAP(1109); } }
        //public CNAP Dsnh_中国境外投资企业对境内直接投资者的股本投资收入 { get { return GetCNAP(1110); } }
        //public CNAP Dsnh_其他投资资本金撤回 { get { return GetCNAP(1111); } }
        //public CNAP Dsnh_对直接投资企业_附属或关联方收回贷款 { get { return GetCNAP(1112); } }
        //public CNAP Dsnh_对直接投资企业_附属或关联方得到的贷款 { get { return GetCNAP(1113); } }
        //public CNAP Dsnh_与直接投资企业_附属或关联方的其他资金往来的收入 { get { return GetCNAP(1114); } }
        //public CNAP Dsnh_境内资产变现收入 { get { return GetCNAP(1115); } }
        //public CNAP Dsnh_出售境外建筑物 { get { return GetCNAP(1116); } }
        //public CNAP Dsnh_投资资本金汇入 { get { return GetCNAP(1117); } }
        //public CNAP Dsnh_筹备资金汇入 { get { return GetCNAP(1118); } }
        //public CNAP Dsnh_外商投资企业增资 { get { return GetCNAP(1119); } }
        //public CNAP Dsnh_中方向外方转让股权 { get { return GetCNAP(1120); } }
        //public CNAP Dsnh_红筹股项下资产减持对价收入 { get { return GetCNAP(1121); } }
        //public CNAP Dsnh_非法人投资款收入 { get { return GetCNAP(1122); } }
        //public CNAP Dsnh_其他投资资本金收入 { get { return GetCNAP(1123); } }
        //public CNAP Dsnh_外国母公司_附属或关联方对国内外商投资企业贷款 { get { return GetCNAP(1124); } }
        //public CNAP Dsnh_对外国母公司_附属及关联方贷款的收回 { get { return GetCNAP(1125); } }
        //public CNAP Dsnh_外国母公司_附属或关联方与国内外商投资企业之间的其他资金往来 { get { return GetCNAP(1126); } }
        //public CNAP Dsnh_出售境内建筑物 { get { return GetCNAP(1127); } }
        //public CNAP Dsnh_卖出境外企业股票或其他形式股本证券 { get { return GetCNAP(1128); } }
        //public CNAP Dsnh_卖出境内机构在境外上市的股票或其他形式股本证券 { get { return GetCNAP(1129); } }
        //public CNAP Dsnh_卖出境外机构发行的_中_长期债券 { get { return GetCNAP(1130); } }
        //public CNAP Dsnh_卖出境内机构在境外发行_中_长期债券 { get { return GetCNAP(1131); } }
        //public CNAP Dsnh_卖出境外货币市场工具 { get { return GetCNAP(1132); } }
        //public CNAP Dsnh_赎回境外投资基金 { get { return GetCNAP(1133); } }
        //public CNAP Dsnh_卖出境外衍生金融工具 { get { return GetCNAP(1134); } }
        //public CNAP Dsnh_在境外市场发行股票及配股 { get { return GetCNAP(1135); } }
        //public CNAP Dsnh_在境内市场向境外投资者发行外币股票及配股 { get { return GetCNAP(1136); } }
        //public CNAP Dsnh_在境内市场向境外投资者发行本币股票及配股 { get { return GetCNAP(1137); } }
        //public CNAP Dsnh_在境外向境外投资者发行_中_长期债券 { get { return GetCNAP(1138); } }
        //public CNAP Dsnh_在境内向境外投资者发行_中_长期债券 { get { return GetCNAP(1139); } }
        //public CNAP Dsnh_在境内向境外投资者发行货币市场工具 { get { return GetCNAP(1140); } }
        //public CNAP Dsnh_在境内向境外投资者发行衍生金融工具 { get { return GetCNAP(1141); } }
        //public CNAP Dsnh_境外投资者投资境内的投资基金 { get { return GetCNAP(1142); } }
        //public CNAP Dsnh_清算资金汇入 { get { return GetCNAP(1143); } }
        //public CNAP Dsnh_证券经营机构清算备用金撤回 { get { return GetCNAP(1144); } }
        //public CNAP Dsnh_政府贷款本金的收回 { get { return GetCNAP(1145); } }
        //public CNAP Dsnh_对外非政府贷款本金的收回 { get { return GetCNAP(1146); } }
        //public CNAP Dsnh_国际金融租赁融资本金的收回 { get { return GetCNAP(1147); } }
        //public CNAP Dsnh_收回其他贷款 { get { return GetCNAP(1148); } }
        //public CNAP Dsnh_收回或调回存放境外存款本金 { get { return GetCNAP(1149); } }
        //public CNAP Dsnh_保证金调回 { get { return GetCNAP(1150); } }
        //public CNAP Dsnh_其他债权减少 { get { return GetCNAP(1151); } }
        //public CNAP Dsnh_获得外国政府贷款本金 { get { return GetCNAP(1152); } }
        //public CNAP Dsnh_获得国际金融组织贷款本金 { get { return GetCNAP(1153); } }
        //public CNAP Dsnh_获得国外银行及其他金融机构贷款本金 { get { return GetCNAP(1154); } }
        //public CNAP Dsnh_获得买方信贷本金 { get { return GetCNAP(1155); } }
        //public CNAP Dsnh_获得国外企业及个人借款本金 { get { return GetCNAP(1156); } }
        //public CNAP Dsnh_国际金融租赁融资 { get { return GetCNAP(1157); } }
        //public CNAP Dsnh_获得其他贷款本金 { get { return GetCNAP(1158); } }
        //public CNAP Dsnh_境外存入款项 { get { return GetCNAP(1159); } }
        //public CNAP Dsnh_境外存入保证金 { get { return GetCNAP(1160); } }
        //public CNAP Dsnh_认缴非货币性国际组织股本金 { get { return GetCNAP(1161); } }

        public CNAP GetCNAP(int code)
        {
            CNAP item = new CNAP();
            string str = string.Empty;
            try { str = EnumNameHelper<DealSerialNoListStringHelper>.GetEnumDescription((DealSerialNoListStringHelper)code); }
            catch { }
            if (!string.IsNullOrEmpty(str))
            {
                string[] list = str.Split(',');
                item.Code = list[0];
                try
                {
                    if (!string.IsNullOrEmpty(list[0]))
                        item.Name = EnumNameHelper<DealSerialNoStringHelper>.GetEnumDescription((DealSerialNoStringHelper)int.Parse(list[0]));
                    if (!string.IsNullOrEmpty(list[1]))
                        item.Usage = EnumNameHelper<DealSerialNoStringHelper>.GetEnumDescription((DealSerialNoStringHelper)int.Parse(list[1]));
                    if (!string.IsNullOrEmpty(list[2]))
                        item.Group = EnumNameHelper<DealSerialNoStringHelper>.GetEnumDescription((DealSerialNoStringHelper)int.Parse(list[2]));
                }
                catch { }
            }
            return item;
        }
    }

    public enum DealSerialNoListStringHelper
    {
        [TranslatingKeyAttribute("DsnhCNAP1", "101010,1301,1401", "101010,1301,1401", "101010,1301,1401")]
        DsnhCNAP1 = 1001,
        [TranslatingKeyAttribute("DsnhCNAP2", "101020,1301,1401", "101020,1301,1401", "101020,1301,1401")]
        DsnhCNAP2 = 1002,
        [TranslatingKeyAttribute("DsnhCNAP3", "101030,1301,1401", "101030,1301,1401", "101030,1301,1401")]
        DsnhCNAP3 = 1003,
        [TranslatingKeyAttribute("DsnhCNAP4", "101040,1301,1401", "101040,1301,1401", "101040,1301,1401")]
        DsnhCNAP4 = 1004,
        [TranslatingKeyAttribute("DsnhCNAP5", "101050,1301,1401", "101050,1301,1401", "101050,1301,1401")]
        DsnhCNAP5 = 1005,
        [TranslatingKeyAttribute("DsnhCNAP6", "101080,1301,1401", "101080,1301,1401", "101080,1301,1401")]
        DsnhCNAP6 = 1006,
        [TranslatingKeyAttribute("DsnhCNAP7", "101090,1301,1401", "101090,1301,1401", "101090,1301,1401")]
        DsnhCNAP7 = 1007,
        [TranslatingKeyAttribute("DsnhCNAP8", "101100,1301,1401", "101100,1301,1401", "101100,1301,1401")]
        DsnhCNAP8 = 1008,
        [TranslatingKeyAttribute("DsnhCNAP9", "101140,1301,1401", "101140,1301,1401", "101140,1301,1401")]
        DsnhCNAP9 = 1009,
        [TranslatingKeyAttribute("DsnhCNAP10", "102010,1302,1401", "102010,1302,1401", "102010,1302,1401")]
        DsnhCNAP10 = 1010,
        [TranslatingKeyAttribute("DsnhCNAP11", "102030,1302,1401", "102030,1302,1401", "102030,1302,1401")]
        DsnhCNAP11 = 1011,
        [TranslatingKeyAttribute("DsnhCNAP12", "102040,1302,1401", "102040,1302,1401", "102040,1302,1401")]
        DsnhCNAP12 = 1012,
        [TranslatingKeyAttribute("DsnhCNAP13", "103010,1302,1401", "103010,1302,1401", "103010,1302,1401")]
        DsnhCNAP13 = 1013,
        [TranslatingKeyAttribute("DsnhCNAP14", "104010,1302,1401", "104010,1302,1401", "104010,1302,1401")]
        DsnhCNAP14 = 1014,
        [TranslatingKeyAttribute("DsnhCNAP15", "105010,1302,1401", "105010,1302,1401", "105010,1302,1401")]
        DsnhCNAP15 = 1015,
        [TranslatingKeyAttribute("DsnhCNAP16", "109000,1302,1401", "109000,1302,1401", "109000,1302,1401")]
        DsnhCNAP16 = 1016,
        [TranslatingKeyAttribute("DsnhCNAP17", "201011,1303,1402", "201011,1303,1402", "201011,1303,1402")]
        DsnhCNAP17 = 1017,
        [TranslatingKeyAttribute("DsnhCNAP18", "201012,1303,1402", "201012,1303,1402", "201012,1303,1402")]
        DsnhCNAP18 = 1018,
        [TranslatingKeyAttribute("DsnhCNAP19", "201013,1303,1402 ", "201013,1303,1402", "201013,1303,1402")]
        DsnhCNAP19 = 1019,
        [TranslatingKeyAttribute("DsnhCNAP20", "201014,1303,1402", "201014,1303,1402", "201014,1303,1402")]
        DsnhCNAP20 = 1020,
        [TranslatingKeyAttribute("DsnhCNAP21", "201019,1303,1402", "201019,1303,1402", "201019,1303,1402")]
        DsnhCNAP21 = 1021,
        [TranslatingKeyAttribute("DsnhCNAP22", "201021,1304,1402", "201021,1304,1402", "201021,1304,1402")]
        DsnhCNAP22 = 1022,
        [TranslatingKeyAttribute("DsnhCNAP23", "201022,1304,1402", "201022,1304,1402", "201022,1304,1402")]
        DsnhCNAP23 = 1023,
        [TranslatingKeyAttribute("DsnhCNAP24", "201023,1304,1402", "201023,1304,1402", "201023,1304,1402")]
        DsnhCNAP24 = 1024,
        [TranslatingKeyAttribute("DsnhCNAP25", "201024,1304,1402", "201024,1304,1402", "201024,1304,1402")]
        DsnhCNAP25 = 1025,
        [TranslatingKeyAttribute("DsnhCNAP26", "201029,1304,1402", "201029,1304,1402", "201029,1304,1402")]
        DsnhCNAP26 = 1026,
        [TranslatingKeyAttribute("DsnhCNAP27", "201031,1305,1402", "201031,1305,1402", "201031,1305,1402")]
        DsnhCNAP27 = 1027,
        [TranslatingKeyAttribute("DsnhCNAP28", "201032,1305,1402", "201032,1305,1402", "201032,1305,1402")]
        DsnhCNAP28 = 1028,
        [TranslatingKeyAttribute("DsnhCNAP29", "201033,1305,1402", "201033,1305,1402", "201033,1305,1402")]
        DsnhCNAP29 = 1029,
        [TranslatingKeyAttribute("DsnhCNAP30", "201034,1305,1402", "201034,1305,1402", "201034,1305,1402")]
        DsnhCNAP30 = 1030,
        [TranslatingKeyAttribute("DsnhCNAP31", "201039,1305,1402", "201039,1305,1402", "201039,1305,1402")]
        DsnhCNAP31 = 1031,
        [TranslatingKeyAttribute("DsnhCNAP32", "201040,1305,1402", "201040,1305,1402", "201040,1305,1402")]
        DsnhCNAP32 = 1032,
        [TranslatingKeyAttribute("DsnhCNAP33", "202010,1306,1402", "202010,1306,1402", "202010,1306,1402")]
        DsnhCNAP33 = 1033,
        [TranslatingKeyAttribute("DsnhCNAP34", "202020,1306,1402", "202020,1306,1402", "202020,1306,1402")]
        DsnhCNAP34 = 1034,
        [TranslatingKeyAttribute("DsnhCNAP35", "202030,1306,1402", "202030,1306,1402", "202030,1306,1402")]
        DsnhCNAP35 = 1035,
        [TranslatingKeyAttribute("DsnhCNAP36", "202040,1306,1402", "202040,1306,1402", "202040,1306,1402")]
        DsnhCNAP36 = 1036,
        [TranslatingKeyAttribute("DsnhCNAP37", "203010,1307,1402", "203010,1307,1402", "203010,1307,1402")]
        DsnhCNAP37 = 1037,
        [TranslatingKeyAttribute("DsnhCNAP38", "203020,1307,1402", "203020,1307,1402", "203020,1307,1402")]
        DsnhCNAP38 = 1038,
        [TranslatingKeyAttribute("DsnhCNAP39", "204010,1308,1402", "204010,1308,1402", "204010,1308,1402")]
        DsnhCNAP39 = 1039,
        [TranslatingKeyAttribute("DsnhCNAP40", "204020,1308,1402", "204020,1308,1402", "204020,1308,1402")]
        DsnhCNAP40 = 1040,
        [TranslatingKeyAttribute("DsnhCNAP41", "205011,1309,1402", "205011,1309,1402", "205011,1309,1402")]
        DsnhCNAP41 = 1041,
        [TranslatingKeyAttribute("DsnhCNAP42", "205012,1309,1402", "205012,1309,1402", "205012,1309,1402")]
        DsnhCNAP42 = 1042,
        [TranslatingKeyAttribute("DsnhCNAP43", "205013,1309,1402", "205013,1309,1402", "205013,1309,1402")]
        DsnhCNAP43 = 1043,
        [TranslatingKeyAttribute("DsnhCNAP44", "205019,1309,1402", "205019,1309,1402", "205019,1309,1402")]
        DsnhCNAP44 = 1044,
        [TranslatingKeyAttribute("DsnhCNAP45", "205020,1309,1402", "205020,1309,1402", "205020,1309,1402")]
        DsnhCNAP45 = 1045,
        [TranslatingKeyAttribute("DsnhCNAP46", "205030,1309,1402", "205030,1309,1402", "205030,1309,1402")]
        DsnhCNAP46 = 1046,
        [TranslatingKeyAttribute("DsnhCNAP47", "205040,1309,1402", "205040,1309,1402", "205040,1309,1402")]
        DsnhCNAP47 = 1047,
        [TranslatingKeyAttribute("DsnhCNAP48", "205090,1309,1402", "205090,1309,1402", "205090,1309,1402")]
        DsnhCNAP48 = 1048,
        [TranslatingKeyAttribute("DsnhCNAP49", "206010,1310,1402", "206010,1310,1402", "206010,1310,1402")]
        DsnhCNAP49 = 1049,
        [TranslatingKeyAttribute("DsnhCNAP50", "207010,1310,1402", "207010,1310,1402", "207010,1310,1402")]
        DsnhCNAP50 = 1050,
        [TranslatingKeyAttribute("DsnhCNAP51", "207020,1311,1402", "207020,1311,1402", "207020,1311,1402")]
        DsnhCNAP51 = 1051,
        [TranslatingKeyAttribute("DsnhCNAP52", "208010,1311,1402", "208010,1311,1402", "208010,1311,1402")]
        DsnhCNAP52 = 1052,
        [TranslatingKeyAttribute("DsnhCNAP53", "208020,1311,1402", "208020,1311,1402", "208020,1311,1402")]
        DsnhCNAP53 = 1053,
        [TranslatingKeyAttribute("DsnhCNAP54", "208030,1311,1402", "208030,1311,1402", "208030,1311,1402")]
        DsnhCNAP54 = 1054,
        [TranslatingKeyAttribute("DsnhCNAP55", "208040,1311,1402", "208040,1311,1402", "208040,1311,1402")]
        DsnhCNAP55 = 1055,
        [TranslatingKeyAttribute("DsnhCNAP56", "208050,1311,1402", "208050,1311,1402", "208050,1311,1402")]
        DsnhCNAP56 = 1056,
        [TranslatingKeyAttribute("DsnhCNAP57", "209010,1312,1402", "209010,1312,1402", "209010,1312,1402")]
        DsnhCNAP57 = 1057,
        [TranslatingKeyAttribute("DsnhCNAP58", "209090,1312,1402", "209090,1312,1402", "209090,1312,1402")]
        DsnhCNAP58 = 1058,
        [TranslatingKeyAttribute("DsnhCNAP59", "210010,1313,1402", "210010,1313,1402", "210010,1313,1402")]
        DsnhCNAP59 = 1059,
        [TranslatingKeyAttribute("DsnhCNAP60", "210020,1313,1402", "210020,1313,1402", "210020,1313,1402")]
        DsnhCNAP60 = 1060,
        [TranslatingKeyAttribute("DsnhCNAP61", "211011,1314,1402", "211011,1314,1402", "211011,1314,1402")]
        DsnhCNAP61 = 1061,
        [TranslatingKeyAttribute("DsnhCNAP62", "211012,1314,1402", "211012,1314,1402", "211012,1314,1402")]
        DsnhCNAP62 = 1062,
        [TranslatingKeyAttribute("DsnhCNAP63", "211013,1314,1402", "211013,1314,1402", "211013,1314,1402")]
        DsnhCNAP63 = 1063,
        [TranslatingKeyAttribute("DsnhCNAP64", "211014,1314,1402", "211014,1314,1402", "211014,1314,1402")]
        DsnhCNAP64 = 1064,
        [TranslatingKeyAttribute("DsnhCNAP65", "211020,1314,1402", "211020,1314,1402", "211020,1314,1402")]
        DsnhCNAP65 = 1065,
        [TranslatingKeyAttribute("DsnhCNAP66", "211031,1315,1402", "211031,1315,1402", "211031,1315,1402")]
        DsnhCNAP66 = 1066,
        [TranslatingKeyAttribute("DsnhCNAP67", "211032,1315,1402", "211032,1315,1402", "211032,1315,1402")]
        DsnhCNAP67 = 1067,
        [TranslatingKeyAttribute("DsnhCNAP68", "211033,1315,1402", "211033,1315,1402", "211033,1315,1402")]
        DsnhCNAP68 = 1068,
        [TranslatingKeyAttribute("DsnhCNAP69", "211034,1315,1402", "211034,1315,1402", "211034,1315,1402")]
        DsnhCNAP69 = 1069,
        [TranslatingKeyAttribute("DsnhCNAP70", "211039,1315,1402", "211039,1315,1402", "211039,1315,1402")]
        DsnhCNAP70 = 1070,
        [TranslatingKeyAttribute("DsnhCNAP71", "211041,1316,1402", "211041,1316,1402", "211041,1316,1402")]
        DsnhCNAP71 = 1071,
        [TranslatingKeyAttribute("DsnhCNAP72", "211042,1316,1402", "211042,1316,1402", "211042,1316,1402")]
        DsnhCNAP72 = 1072,
        [TranslatingKeyAttribute("DsnhCNAP73", "211051,1317,1402", "211051,1317,1402", "211051,1317,1402")]
        DsnhCNAP73 = 1073,
        [TranslatingKeyAttribute("DsnhCNAP74", "211052,1317,1402", "211052,1317,1402", "211052,1317,1402")]
        DsnhCNAP74 = 1074,
        [TranslatingKeyAttribute("DsnhCNAP75", "211053,1317,1402", "211053,1317,1402", "211053,1317,1402")]
        DsnhCNAP75 = 1075,
        [TranslatingKeyAttribute("DsnhCNAP76", "211054,1317,1402", "211054,1317,1402", "211054,1317,1402")]
        DsnhCNAP76 = 1076,
        [TranslatingKeyAttribute("DsnhCNAP77", "211060,1317,1402", "211060,1317,1402", "211060,1317,1402")]
        DsnhCNAP77 = 1077,
        [TranslatingKeyAttribute("DsnhCNAP78", "211070,1317,1402", "211070,1317,1402", "211070,1317,1402")]
        DsnhCNAP78 = 1078,
        [TranslatingKeyAttribute("DsnhCNAP79", "211090,1317,1402", "211090,1317,1402", "211090,1317,1402")]
        DsnhCNAP79 = 1079,
        [TranslatingKeyAttribute("DsnhCNAP80", "301010,,1403", "301010,,1403", "301010,,1403")]
        DsnhCNAP80 = 1080,
        [TranslatingKeyAttribute("DsnhCNAP81", "302011,,1403", "302011,,1403", "302011,,1403")]
        DsnhCNAP81 = 1081,
        [TranslatingKeyAttribute("DsnhCNAP82", "302012,,1403", "302012,,1403", "302012,,1403")]
        DsnhCNAP82 = 1082,
        [TranslatingKeyAttribute("DsnhCNAP83", "302013,,1403", "302013,,1403", "302013,,1403")]
        DsnhCNAP83 = 1083,
        [TranslatingKeyAttribute("DsnhCNAP84", "302021,,1403", "302021,,1403", "302021,,1403")]
        DsnhCNAP84 = 1084,
        [TranslatingKeyAttribute("DsnhCNAP85", "302022,,1403", "302022,,1403", "302022,,1403")]
        DsnhCNAP85 = 1085,
        [TranslatingKeyAttribute("DsnhCNAP86", "302031,,1403", "302031,,1403", "302031,,1403")]
        DsnhCNAP86 = 1086,
        [TranslatingKeyAttribute("DsnhCNAP87", "401000,1318,1404", "401000,1318,1404", "401000,1318,1404")]
        DsnhCNAP87 = 1087,
        [TranslatingKeyAttribute("DsnhCNAP88", "402010,1318,1404", "402010,1318,1404", "402010,1318,1404")]
        DsnhCNAP88 = 1088,
        [TranslatingKeyAttribute("DsnhCNAP89", "402020,1318,1404", "402020,1318,1404", "402020,1318,1404")]
        DsnhCNAP89 = 1089,
        [TranslatingKeyAttribute("DsnhCNAP90", "403000,1318,1404", "403000,1318,1404", "403000,1318,1404")]
        DsnhCNAP90 = 1090,
        [TranslatingKeyAttribute("DsnhCNAP91", "404000,1318,1404", "404000,1318,1404", "404000,1318,1404")]
        DsnhCNAP91 = 1091,
        [TranslatingKeyAttribute("DsnhCNAP92", "405000,1318,1404", "405000,1318,1404", "405000,1318,1404")]
        DsnhCNAP92 = 1092,
        [TranslatingKeyAttribute("DsnhCNAP93", "406000,1318,1404", "406000,1318,1404", "406000,1318,1404")]
        DsnhCNAP93 = 1093,
        [TranslatingKeyAttribute("DsnhCNAP94", "407000,1318,1404", "407000,1318,1404", "407000,1318,1404")]
        DsnhCNAP94 = 1094,
        [TranslatingKeyAttribute("DsnhCNAP95", "408000,1318,1404", "408000,1318,1404", "408000,1318,1404")]
        DsnhCNAP95 = 1095,
        [TranslatingKeyAttribute("DsnhCNAP96", "501020,1319,1405", "501020,1319,1405", "501020,1319,1405")]
        DsnhCNAP96 = 1096,
        [TranslatingKeyAttribute("DsnhCNAP97", "501030,1319,1405", "501030,1319,1405", "501030,1319,1405")]
        DsnhCNAP97 = 1097,
        [TranslatingKeyAttribute("DsnhCNAP98", "501040,1319,1405", "501040,1319,1405", "501040,1319,1405")]
        DsnhCNAP98 = 1098,
        [TranslatingKeyAttribute("DsnhCNAP99", "501050,1319,1405", "501050,1319,1405", "501050,1319,1405")]
        DsnhCNAP99 = 1099,
        [TranslatingKeyAttribute("DsnhCNAP100", "501090,1319,1405", "501090,1319,1405", "501090,1319,1405")]
        DsnhCNAP100 = 1100,
        [TranslatingKeyAttribute("DsnhCNAP101", "502010,1320,1405", "502010,1320,1405", "502010,1320,1405")]
        DsnhCNAP101 = 1101,
        [TranslatingKeyAttribute("DsnhCNAP102", "502020,1320,1405", "502020,1320,1405", "502020,1320,1405")]
        DsnhCNAP102 = 1102,
        [TranslatingKeyAttribute("DsnhCNAP103", "502030,1320,1405", "502030,1320,1405", "502030,1320,1405")]
        DsnhCNAP103 = 1103,
        [TranslatingKeyAttribute("DsnhCNAP104", "601011,1321,1406", "601011,1321,1406", "601011,1321,1406")]
        DsnhCNAP104 = 1104,
        [TranslatingKeyAttribute("DsnhCNAP105", "601012,1321,1406", "601012,1321,1406", "601012,1321,1406")]
        DsnhCNAP105 = 1105,
        [TranslatingKeyAttribute("DsnhCNAP106", "601013,1321,1406", "601013,1321,1406", "601013,1321,1406")]
        DsnhCNAP106 = 1106,
        [TranslatingKeyAttribute("DsnhCNAP107", "601014,1321,1406", "601014,1321,1406", "601014,1321,1406")]
        DsnhCNAP107 = 1107,
        [TranslatingKeyAttribute("DsnhCNAP108", "601015,1321,1406", "601015,1321,1406", "601015,1321,1406")]
        DsnhCNAP108 = 1108,
        [TranslatingKeyAttribute("DsnhCNAP109", "601016,1321,1406", "601016,1321,1406", "601016,1321,1406")]
        DsnhCNAP109 = 1109,
        [TranslatingKeyAttribute("DsnhCNAP110", "601017,1321,1406", "601017,1321,1406", "601017,1321,1406")]
        DsnhCNAP110 = 1110,
        [TranslatingKeyAttribute("DsnhCNAP111", "601019,1321,1406", "601019,1321,1406", "601019,1321,1406")]
        DsnhCNAP111 = 1111,
        [TranslatingKeyAttribute("DsnhCNAP112", "601021,1322,1406", "601021,1322,1406", "601021,1322,1406")]
        DsnhCNAP112 = 1112,
        [TranslatingKeyAttribute("DsnhCNAP113", "601022,1322,1406", "601022,1322,1406", "601022,1322,1406")]
        DsnhCNAP113 = 1113,
        [TranslatingKeyAttribute("DsnhCNAP114", "601023,1322,1406", "601023,1322,1406", "601023,1322,1406")]
        DsnhCNAP114 = 1114,
        [TranslatingKeyAttribute("DsnhCNAP115", "601040,1322,1406", "601040,1322,1406", "601040,1322,1406")]
        DsnhCNAP115 = 1115,
        [TranslatingKeyAttribute("DsnhCNAP116", "601080,1322,1406", "601080,1322,1406", "601080,1322,1406")]
        DsnhCNAP116 = 1116,
        [TranslatingKeyAttribute("DsnhCNAP117", "602011,1323,1406", "602011,1323,1406", "602011,1323,1406")]
        DsnhCNAP117 = 1117,
        [TranslatingKeyAttribute("DsnhCNAP118", "602012,1323,1406", "602012,1323,1406", "602012,1323,1406")]
        DsnhCNAP118 = 1118,
        [TranslatingKeyAttribute("DsnhCNAP119", "602013,1323,1406", "602013,1323,1406", "602013,1323,1406")]
        DsnhCNAP119 = 1119,
        [TranslatingKeyAttribute("DsnhCNAP120", "602014,1323,1406", "602014,1323,1406", "602014,1323,1406")]
        DsnhCNAP120 = 1120,
        [TranslatingKeyAttribute("DsnhCNAP121", "602015,1323,1406", "602015,1323,1406", "602015,1323,1406")]
        DsnhCNAP121 = 1121,
        [TranslatingKeyAttribute("DsnhCNAP122", "602018,1323,1406", "602018,1323,1406", "602018,1323,1406")]
        DsnhCNAP122 = 1122,
        [TranslatingKeyAttribute("DsnhCNAP123", "602019,1323,1406", "602019,1323,1406", "602019,1323,1406")]
        DsnhCNAP123 = 1123,
        [TranslatingKeyAttribute("DsnhCNAP124", "602021,1324,1406", "602021,1324,1406", "602021,1324,1406")]
        DsnhCNAP124 = 1124,
        [TranslatingKeyAttribute("DsnhCNAP125", "602022,1324,1406", "602022,1324,1406", "602022,1324,1406")]
        DsnhCNAP125 = 1125,
        [TranslatingKeyAttribute("DsnhCNAP126", "602023,1324,1406", "602023,1324,1406", "602023,1324,1406")]
        DsnhCNAP126 = 1126,
        [TranslatingKeyAttribute("DsnhCNAP127", "602050,1324,1406", "602050,1324,1406", "602050,1324,1406")]
        DsnhCNAP127 = 1127,
        [TranslatingKeyAttribute("DsnhCNAP128", "701011,1325,1407", "701011,1325,1407", "701011,1325,1407")]
        DsnhCNAP128 = 1128,
        [TranslatingKeyAttribute("DsnhCNAP129", "701012,1325,1407", "701012,1325,1407", "701012,1325,1407")]
        DsnhCNAP129 = 1129,
        [TranslatingKeyAttribute("DsnhCNAP130", "701021,1326,1407", "701021,1326,1407", "701021,1326,1407")]
        DsnhCNAP130 = 1130,
        [TranslatingKeyAttribute("DsnhCNAP131", "701022,1326,1407", "701022,1326,1407", "701022,1326,1407")]
        DsnhCNAP131 = 1131,
        [TranslatingKeyAttribute("DsnhCNAP132", "701023,1326,1407", "701023,1326,1407", "701023,1326,1407")]
        DsnhCNAP132 = 1132,
        [TranslatingKeyAttribute("DsnhCNAP133", "701024,1326,1407", "701024,1326,1407", "701024,1326,1407")]
        DsnhCNAP133 = 1133,
        [TranslatingKeyAttribute("DsnhCNAP134", "701025,1326,1407", "701025,1326,1407", "701025,1326,1407")]
        DsnhCNAP134 = 1134,
        [TranslatingKeyAttribute("DsnhCNAP135", "702011,1325,1407", "702011,1325,1407", "702011,1325,1407")]
        DsnhCNAP135 = 1135,
        [TranslatingKeyAttribute("DsnhCNAP136", "702012,1325,1407", "702012,1325,1407", "702012,1325,1407")]
        DsnhCNAP136 = 1136,
        [TranslatingKeyAttribute("DsnhCNAP137", "702014,1325,1407", "702014,1325,1407", "702014,1325,1407")]
        DsnhCNAP137 = 1137,
        [TranslatingKeyAttribute("DsnhCNAP138", "702021,1326,1407", "702021,1326,1407", "702021,1326,1407")]
        DsnhCNAP138 = 1138,
        [TranslatingKeyAttribute("DsnhCNAP139", "702022,1326,1407", "702022,1326,1407", "702022,1326,1407")]
        DsnhCNAP139 = 1139,
        [TranslatingKeyAttribute("DsnhCNAP140", "702024,1326,1407", "702024,1326,1407", "702024,1326,1407")]
        DsnhCNAP140 = 1140,
        [TranslatingKeyAttribute("DsnhCNAP141", "702026,1326,1407", "702026,1326,1407", "702026,1326,1407")]
        DsnhCNAP141 = 1141,
        [TranslatingKeyAttribute("DsnhCNAP142", "702028,1326,1407", "702028,1326,1407", "702028,1326,1407")]
        DsnhCNAP142 = 1142,
        [TranslatingKeyAttribute("DsnhCNAP143", "703010,1327,1407", "703010,1327,1407", "703010,1327,1407")]
        DsnhCNAP143 = 1143,
        [TranslatingKeyAttribute("DsnhCNAP144", "703020,1327,1407", "703020,1327,1407", "703020,1327,1407")]
        DsnhCNAP144 = 1144,
        [TranslatingKeyAttribute("DsnhCNAP145", "801021,1328,1408", "801021,1328,1408", "801021,1328,1408")]
        DsnhCNAP145 = 1145,
        [TranslatingKeyAttribute("DsnhCNAP146", "801022,1328,1408", "801022,1328,1408", "801022,1328,1408")]
        DsnhCNAP146 = 1146,
        [TranslatingKeyAttribute("DsnhCNAP147", "801023,1328,1408", "801023,1328,1408", "801023,1328,1408")]
        DsnhCNAP147 = 1147,
        [TranslatingKeyAttribute("DsnhCNAP148", "801024,1328,1408", "801024,1328,1408", "801024,1328,1408")]
        DsnhCNAP148 = 1148,
        [TranslatingKeyAttribute("DsnhCNAP149", "801031,1329,1408", "801031,1329,1408", "801031,1329,1408")]
        DsnhCNAP149 = 1149,
        [TranslatingKeyAttribute("DsnhCNAP150", "801032,1329,1408", "801032,1329,1408", "801032,1329,1408")]
        DsnhCNAP150 = 1150,
        [TranslatingKeyAttribute("DsnhCNAP151", "801040,1329,1408", "801040,1329,1408", "801040,1329,1408")]
        DsnhCNAP151 = 1151,
        [TranslatingKeyAttribute("DsnhCNAP152", "802021,1330,1408", "802021,1330,1408", "802021,1330,1408")]
        DsnhCNAP152 = 1152,
        [TranslatingKeyAttribute("DsnhCNAP153", "802022,1330,1408", "802022,1330,1408", "802022,1330,1408")]
        DsnhCNAP153 = 1153,
        [TranslatingKeyAttribute("DsnhCNAP154", "802023,1330,1408", "802023,1330,1408", "802023,1330,1408")]
        DsnhCNAP154 = 1154,
        [TranslatingKeyAttribute("DsnhCNAP155", "802024,1330,1408", "802024,1330,1408", "802024,1330,1408")]
        DsnhCNAP155 = 1155,
        [TranslatingKeyAttribute("DsnhCNAP156", "802025,1330,1408", "802025,1330,1408", "802025,1330,1408")]
        DsnhCNAP156 = 1156,
        [TranslatingKeyAttribute("DsnhCNAP157", "802026,1330,1408", "802026,1330,1408", "802026,1330,1408")]
        DsnhCNAP157 = 1157,
        [TranslatingKeyAttribute("DsnhCNAP158", "802027,1330,1408", "802027,1330,1408", "802027,1330,1408")]
        DsnhCNAP158 = 1158,
        [TranslatingKeyAttribute("DsnhCNAP159", "802031,1331,1408", "802031,1331,1408", "802031,1331,1408")]
        DsnhCNAP159 = 1159,
        [TranslatingKeyAttribute("DsnhCNAP160", "802032,1331,1408", "802032,1331,1408", "802032,1331,1408")]
        DsnhCNAP160 = 1160,
        [TranslatingKeyAttribute("DsnhCNAP161", "802041,1332,1408", "802041,1332,1408", "802041,1332,1408")]
        DsnhCNAP161 = 1161,
        [TranslatingKeyAttribute("DsnhCNAP162", "802042,1332,1408", "802042,1332,1408", "802042,1332,1408")]
        DsnhCNAP162 = 1162,
    }

    public class DealSerialNoHelper
    {
        public string Dsnh_Name_101010 { get { return GetMessage(101010); } }
        public string Dsnh_Name_101020 { get { return GetMessage(101020); } }
        public string Dsnh_Name_101030 { get { return GetMessage(101030); } }
        public string Dsnh_Name_边境贸易收入 { get { return GetMessage(101040); } }
        public string Dsnh_Name_对外承包工程货物出口收入 { get { return GetMessage(101050); } }
        public string Dsnh_Name_水_电_煤气_天然气等出口收入 { get { return GetMessage(101080); } }
        public string Dsnh_Name_出售运输工具_天然气石油井架_工作台和其他活动设备收入 { get { return GetMessage(101090); } }
        public string Dsnh_Name_易货贸易收入 { get { return GetMessage(101100); } }
        public string Dsnh_Name_远洋渔业_石油_矿产销售收入 { get { return GetMessage(101140); } }
        public string Dsnh_Name_来料加工装配贸易出口 { get { return GetMessage(102010); } }
        public string Dsnh_Name_进料加工贸易项下的成品出口 { get { return GetMessage(102030); } }
        public string Dsnh_Name_出料加工贸易出口 { get { return GetMessage(102040); } }
        public string Dsnh_Name_为修理提供货物所得收入 { get { return GetMessage(103010); } }
        public string Dsnh_Name_在港口为运输工具提供货物的收入 { get { return GetMessage(104010); } }
        public string Dsnh_Name_非货币黄金进出口收入 { get { return GetMessage(105010); } }
        public string Dsnh_Name_其他收入 { get { return GetMessage(109000); } }
        public string Dsnh_Name_客运收入 { get { return GetMessage(201011); } }
        public string Dsnh_Name_为货物出口提供运输的收入 { get { return GetMessage(201012); } }
        public string Dsnh_Name_为货物进口提供运输的收入_201013 { get { return GetMessage(201013); } }
        public string Dsnh_Name_港口服务收入 { get { return GetMessage(201014); } }
        public string Dsnh_Name_其他收入_201019 { get { return GetMessage(201019); } }
        public string Dsnh_Name_客运收入_201021 { get { return GetMessage(201021); } }
        public string Dsnh_Name_为货物出口提供运输的收入_201022 { get { return GetMessage(201022); } }
        public string Dsnh_Name_为货物进口提供运输的收入_201023 { get { return GetMessage(201023); } }
        public string Dsnh_Name_港口服务收入_201024 { get { return GetMessage(201024); } }
        public string Dsnh_Name_其他收入_201029 { get { return GetMessage(201029); } }
        public string Dsnh_Name_客运收入_201031 { get { return GetMessage(201031); } }
        public string Dsnh_Name_为货物出口提供运输的收入_201032 { get { return GetMessage(201032); } }
        public string Dsnh_Name_为货物进口提供运输的收入_201033 { get { return GetMessage(201033); } }
        public string Dsnh_Name_港口服务收入_201034 { get { return GetMessage(201034); } }
        public string Dsnh_Name_其他收入_201039 { get { return GetMessage(201039); } }
        public string Dsnh_Name_运输佣金_代理费收入 { get { return GetMessage(201040); } }
        public string Dsnh_Name_旅游企业团费收入 { get { return GetMessage(202010); } }
        public string Dsnh_Name_公务及商务差旅收入 { get { return GetMessage(202020); } }
        public string Dsnh_Name_因私旅游收入 { get { return GetMessage(202030); } }
        public string Dsnh_Name_医疗_保健收入 { get { return GetMessage(202040); } }
        public string Dsnh_Name_电信服务收入 { get { return GetMessage(203010); } }
        public string Dsnh_Name_邮政_邮递服务收入 { get { return GetMessage(203020); } }
        public string Dsnh_Name_建筑_安装服务收入 { get { return GetMessage(204010); } }
        public string Dsnh_Name_劳务承包收入 { get { return GetMessage(204020); } }
        public string Dsnh_Name_责任险收入 { get { return GetMessage(205011); } }
        public string Dsnh_Name_信用保证险收入 { get { return GetMessage(205012); } }
        public string Dsnh_Name_进出口货运险收入 { get { return GetMessage(205013); } }
        public string Dsnh_Name_其他险收入 { get { return GetMessage(205019); } }
        public string Dsnh_Name_人身险收入 { get { return GetMessage(205020); } }
        public string Dsnh_Name_再保险收入 { get { return GetMessage(205030); } }
        public string Dsnh_Name_保险中介服务收入 { get { return GetMessage(205040); } }
        public string Dsnh_Name_其他保险收入 { get { return GetMessage(205090); } }
        public string Dsnh_Name_金融服务中介费_手续费_担保费_承诺费收入 { get { return GetMessage(206010); } }
        public string Dsnh_Name_与计算机有关的其他服务收入 { get { return GetMessage(207010); } }
        public string Dsnh_Name_书刊_杂志和电子出版物以及新闻_信息服务收入 { get { return GetMessage(207020); } }
        public string Dsnh_Name_专利特许权收入 { get { return GetMessage(208010); } }
        public string Dsnh_Name_非专利发明或专有技术收入 { get { return GetMessage(208020); } }
        public string Dsnh_Name_经营权_经销权收入 { get { return GetMessage(208030); } }
        public string Dsnh_Name_商标_制作方法收入 { get { return GetMessage(208040); } }
        public string Dsnh_Name_版权_著作权_稿费收入 { get { return GetMessage(208050); } }
        public string Dsnh_Name_电影_音像服务收入 { get { return GetMessage(209010); } }
        public string Dsnh_Name_体育_健身及其他文化_娱乐服务收入 { get { return GetMessage(209090); } }
        public string Dsnh_Name_签证认证费收入 { get { return GetMessage(210010); } }
        public string Dsnh_Name_使领馆经费收入 { get { return GetMessage(210020); } }
        public string Dsnh_Name_转口贸易收入 { get { return GetMessage(211011); } }
        public string Dsnh_Name_转口贸易价差收入 { get { return GetMessage(211012); } }
        public string Dsnh_Name_进出口佣金收入 { get { return GetMessage(211013); } }
        public string Dsnh_Name_带料加工贸易加工费收入 { get { return GetMessage(211014); } }
        public string Dsnh_Name_经营性租赁服务收入 { get { return GetMessage(211020); } }
        public string Dsnh_Name_法律服务_仲裁收入 { get { return GetMessage(211031); } }
        public string Dsnh_Name_会计服务收入 { get { return GetMessage(211032); } }
        public string Dsnh_Name_管理咨询服务收入 { get { return GetMessage(211033); } }
        public string Dsnh_Name_认证_公证服务收入 { get { return GetMessage(211034); } }
        public string Dsnh_Name_其他收入_211039 { get { return GetMessage(211039); } }
        public string Dsnh_Name_广告_展览收入 { get { return GetMessage(211041); } }
        public string Dsnh_Name_市场调研收入 { get { return GetMessage(211042); } }
        public string Dsnh_Name_工业_技术研究与发展收入 { get { return GetMessage(211051); } }
        public string Dsnh_Name_理论_科学研究与发展收入 { get { return GetMessage(211052); } }
        public string Dsnh_Name_建筑_工程技术服务收入 { get { return GetMessage(211053); } }
        public string Dsnh_Name_其他收入_211054 { get { return GetMessage(211054); } }
        public string Dsnh_Name_驻华机构办公经费 { get { return GetMessage(211060); } }
        public string Dsnh_Name_会费收入 { get { return GetMessage(211070); } }
        public string Dsnh_Name_其他收入_211090 { get { return GetMessage(211090); } }
        public string Dsnh_Name_职工报酬_一年以下雇员汇款收入 { get { return GetMessage(301010); } }
        public string Dsnh_Name_利润汇回 { get { return GetMessage(302011); } }
        public string Dsnh_Name_建筑物租金收入 { get { return GetMessage(302012); } }
        public string Dsnh_Name_对母_分公司_附属及关联方贷款利息收入 { get { return GetMessage(302013); } }
        public string Dsnh_Name_股票投资收益收入 { get { return GetMessage(302021); } }
        public string Dsnh_Name_债券投资收益收入 { get { return GetMessage(302022); } }
        public string Dsnh_Name_其他投资收益_贷款及其他债权利息收入 { get { return GetMessage(302031); } }
        public string Dsnh_Name_接受与固定资产无关的捐赠及无偿援助 { get { return GetMessage(401000); } }
        public string Dsnh_Name_保险赔偿收入 { get { return GetMessage(402010); } }
        public string Dsnh_Name_其他赔偿收入 { get { return GetMessage(402020); } }
        public string Dsnh_Name_税收收入_如所得税_财产税_社会福利_运输工具注册费等_ { get { return GetMessage(403000); } }
        public string Dsnh_Name_罚款_追缴款收入 { get { return GetMessage(404000); } }
        public string Dsnh_Name_国际组织会费收入 { get { return GetMessage(405000); } }
        public string Dsnh_Name_一年以上雇员汇款收入 { get { return GetMessage(406000); } }
        public string Dsnh_Name_偶然性收入 { get { return GetMessage(407000); } }
        public string Dsnh_Name_其他收入_408000 { get { return GetMessage(408000); } }
        public string Dsnh_Name_接受与固定资产有关的捐赠及无偿援助 { get { return GetMessage(501020); } }
        public string Dsnh_Name_国外支付的赔偿 { get { return GetMessage(501030); } }
        public string Dsnh_Name_税收收入 { get { return GetMessage(501040); } }
        public string Dsnh_Name_移民的转移收入 { get { return GetMessage(501050); } }
        public string Dsnh_Name_其他收入_501090 { get { return GetMessage(501090); } }
        public string Dsnh_Name_土地批租_租赁收入 { get { return GetMessage(502010); } }
        public string Dsnh_Name_商标_专利的所有权转让收入 { get { return GetMessage(502020); } }
        public string Dsnh_Name_其他无形资产的所有权转让收入 { get { return GetMessage(502030); } }
        public string Dsnh_Name_境外投资企业清算_终止等撤资 { get { return GetMessage(601011); } }
        public string Dsnh_Name_筹备资金撤回 { get { return GetMessage(601012); } }
        public string Dsnh_Name_直接投资者境外投资企业减资 { get { return GetMessage(601013); } }
        public string Dsnh_Name_将境外投资企业中方股权转让给外方 { get { return GetMessage(601014); } }
        public string Dsnh_Name_将境外投资企业中方股权转让给其他中方 { get { return GetMessage(601015); } }
        public string Dsnh_Name_中方先行收回投资 { get { return GetMessage(601016); } }
        public string Dsnh_Name_中国境外投资企业对境内直接投资者的股本投资收入 { get { return GetMessage(601017); } }
        public string Dsnh_Name_其他投资资本金撤回 { get { return GetMessage(601019); } }
        public string Dsnh_Name_对直接投资企业_附属或关联方收回贷款 { get { return GetMessage(601021); } }
        public string Dsnh_Name_对直接投资企业_附属或关联方得到的贷款 { get { return GetMessage(601022); } }
        public string Dsnh_Name_与直接投资企业_附属或关联方的其他资金往来的收入 { get { return GetMessage(601023); } }
        public string Dsnh_Name_境内资产变现收入 { get { return GetMessage(601040); } }
        public string Dsnh_Name_出售境外建筑物 { get { return GetMessage(601080); } }
        public string Dsnh_Name_投资资本金汇入 { get { return GetMessage(602011); } }
        public string Dsnh_Name_筹备资金汇入 { get { return GetMessage(602012); } }
        public string Dsnh_Name_外商投资企业增资 { get { return GetMessage(602013); } }
        public string Dsnh_Name_中方向外方转让股权 { get { return GetMessage(602014); } }
        public string Dsnh_Name_红筹股项下资产减持对价收入 { get { return GetMessage(602015); } }
        public string Dsnh_Name_非法人投资款收入 { get { return GetMessage(602018); } }
        public string Dsnh_Name_其他投资资本金收入 { get { return GetMessage(602019); } }
        public string Dsnh_Name_外国母公司_附属或关联方对国内外商投资企业贷款 { get { return GetMessage(602021); } }
        public string Dsnh_Name_对外国母公司_附属及关联方贷款的收回 { get { return GetMessage(602022); } }
        public string Dsnh_Name_外国母公司_附属或关联方与国内外商投资企业之间的其他资金往来 { get { return GetMessage(602023); } }
        public string Dsnh_Name_出售境内建筑物 { get { return GetMessage(602050); } }
        public string Dsnh_Name_卖出境外企业股票或其他形式股本证券 { get { return GetMessage(701011); } }
        public string Dsnh_Name_卖出境内机构在境外上市的股票或其他形式股本证券 { get { return GetMessage(701012); } }
        public string Dsnh_Name_卖出境外机构发行的_中_长期债券 { get { return GetMessage(701021); } }
        public string Dsnh_Name_卖出境内机构在境外发行_中_长期债券 { get { return GetMessage(701022); } }
        public string Dsnh_Name_卖出境外货币市场工具 { get { return GetMessage(701023); } }
        public string Dsnh_Name_赎回境外投资基金 { get { return GetMessage(701024); } }
        public string Dsnh_Name_卖出境外衍生金融工具 { get { return GetMessage(701025); } }
        public string Dsnh_Name_在境外市场发行股票及配股 { get { return GetMessage(702011); } }
        public string Dsnh_Name_在境内市场向境外投资者发行外币股票及配股 { get { return GetMessage(702012); } }
        public string Dsnh_Name_在境内市场向境外投资者发行本币股票及配股 { get { return GetMessage(702014); } }
        public string Dsnh_Name_在境外向境外投资者发行_中_长期债券 { get { return GetMessage(702021); } }
        public string Dsnh_Name_在境内向境外投资者发行_中_长期债券 { get { return GetMessage(702022); } }
        public string Dsnh_Name_在境内向境外投资者发行货币市场工具 { get { return GetMessage(702024); } }
        public string Dsnh_Name_在境内向境外投资者发行衍生金融工具 { get { return GetMessage(702026); } }
        public string Dsnh_Name_境外投资者投资境内的投资基金 { get { return GetMessage(702028); } }
        public string Dsnh_Name_清算资金汇入 { get { return GetMessage(703010); } }
        public string Dsnh_Name_证券经营机构清算备用金撤回 { get { return GetMessage(703020); } }
        public string Dsnh_Name_政府贷款本金的收回 { get { return GetMessage(801021); } }
        public string Dsnh_Name_对外非政府贷款本金的收回 { get { return GetMessage(801022); } }
        public string Dsnh_Name_国际金融租赁融资本金的收回 { get { return GetMessage(801023); } }
        public string Dsnh_Name_收回其他贷款 { get { return GetMessage(801024); } }
        public string Dsnh_Name_收回或调回存放境外存款本金 { get { return GetMessage(801031); } }
        public string Dsnh_Name_保证金调回 { get { return GetMessage(801032); } }
        public string Dsnh_Name_其他债权减少 { get { return GetMessage(801040); } }
        public string Dsnh_Name_获得外国政府贷款本金 { get { return GetMessage(802021); } }
        public string Dsnh_Name_获得国际金融组织贷款本金 { get { return GetMessage(802022); } }
        public string Dsnh_Name_获得国外银行及其他金融机构贷款本金 { get { return GetMessage(802023); } }
        public string Dsnh_Name_获得买方信贷本金 { get { return GetMessage(802024); } }
        public string Dsnh_Name_获得国外企业及个人借款本金 { get { return GetMessage(802025); } }
        public string Dsnh_Name_国际金融租赁融资 { get { return GetMessage(802026); } }
        public string Dsnh_Name_获得其他贷款本金 { get { return GetMessage(802027); } }
        public string Dsnh_Name_境外存入款项 { get { return GetMessage(802031); } }
        public string Dsnh_Name_境外存入保证金 { get { return GetMessage(802032); } }
        public string Dsnh_Name_认缴非货币性国际组织股本金 { get { return GetMessage(802041); } }
        public string Dsnh_Name_借入其他债务 { get { return GetMessage(802042); } }
        public string Dsnh_Purpose_一般货物 { get { return GetMessage(1301); } }
        public string Dsnh_Purpose_用于加工的货物 { get { return GetMessage(1302); } }
        public string Dsnh_Purpose_海运收入 { get { return GetMessage(1303); } }
        public string Dsnh_Purpose_空运收入 { get { return GetMessage(1304); } }
        public string Dsnh_Purpose_其他运输收入 { get { return GetMessage(1305); } }
        public string Dsnh_Purpose_旅游 { get { return GetMessage(1306); } }
        public string Dsnh_Purpose_通信服务 { get { return GetMessage(1307); } }
        public string Dsnh_Purpose_建筑_安装及劳务承包服务 { get { return GetMessage(1308); } }
        public string Dsnh_Purpose_财产险收入 { get { return GetMessage(1309); } }
        public string Dsnh_Purpose_计算机和信息服务 { get { return GetMessage(1310); } }
        public string Dsnh_Purpose_专有权利使用费和特许费 { get { return GetMessage(1311); } }
        public string Dsnh_Purpose_体育_文化和娱乐服务 { get { return GetMessage(1312); } }
        public string Dsnh_Purpose_别处未提及的政府服务 { get { return GetMessage(1313); } }
        public string Dsnh_Purpose_转口贸易及贸易佣金 { get { return GetMessage(1314); } }
        public string Dsnh_Purpose_法律_会计_管理咨询和公共关系服务 { get { return GetMessage(1315); } }
        public string Dsnh_Purpose_广告_展览_市场调研 { get { return GetMessage(1316); } }
        public string Dsnh_Purpose_技术服务 { get { return GetMessage(1317); } }
        public string Dsnh_Purpose_国外支付的赔偿 { get { return GetMessage(1318); } }
        public string Dsnh_Purpose_资本转移 { get { return GetMessage(1319); } }
        public string Dsnh_Purpose_非生产_非金融资产的收买_放弃 { get { return GetMessage(1320); } }
        public string Dsnh_Purpose_投资资本金 { get { return GetMessage(1321); } }
        public string Dsnh_Purpose_直接投资者与直接投资企业之间借贷及其他往来的收入 { get { return GetMessage(1322); } }
        public string Dsnh_Purpose_投资资本金汇入 { get { return GetMessage(1323); } }
        public string Dsnh_Purpose_直接投资企业与直接投资者之间借贷及其他往来 { get { return GetMessage(1324); } }
        public string Dsnh_Purpose_股本证券 { get { return GetMessage(1325); } }
        public string Dsnh_Purpose_债务证券 { get { return GetMessage(1326); } }
        public string Dsnh_Purpose_与证券买卖有关的资金跨境流动 { get { return GetMessage(1327); } }
        public string Dsnh_Purpose_对外贷款收回 { get { return GetMessage(1328); } }
        public string Dsnh_Purpose_货币和存款收回 { get { return GetMessage(1329); } }
        public string Dsnh_Purpose_获得外国贷款 { get { return GetMessage(1330); } }
        public string Dsnh_Purpose_货币和存款 { get { return GetMessage(1331); } }
        public string Dsnh_Purpose_其他 { get { return GetMessage(1332); } }
        public string Dsnh_Purpose_海运支出 { get { return GetMessage(1333); } }
        public string Dsnh_Purpose_空运支出 { get { return GetMessage(1334); } }
        public string Dsnh_Purpose_其它运输支出 { get { return GetMessage(1335); } }
        public string Dsnh_Purpose_财产险支出 { get { return GetMessage(1336); } }
        public string Dsnh_Purpose_职工报酬 { get { return GetMessage(1337); } }
        public string Dsnh_Purpose_对国外支付的赔偿 { get { return GetMessage(1338); } }
        public string Dsnh_Purpose_投资资本金撤回_清算等 { get { return GetMessage(1339); } }
        public string Dsnh_Purpose_对外贷款 { get { return GetMessage(1340); } }
        public string Dsnh_Purpose_向金融性国际组织认缴的份额 { get { return GetMessage(1341); } }
        public string Dsnh_Purpose_偿还国外贷款 { get { return GetMessage(1342); } }
        public string Dsnh_Purpose_直接投资收益 { get { return GetMessage(1343); } }
        public string Dsnh_Purpose_证券投资收益 { get { return GetMessage(1344); } }
        public string Dsnh_Purpose_其他投资收益 { get { return GetMessage(1345); } }
        public string Dsnh_Purpose_其他负债 { get { return GetMessage(1346); } }
        public string Dsnh_Group_货物贸易 { get { return GetMessage(1401); } }
        public string Dsnh_Group_服务 { get { return GetMessage(1402); } }
        public string Dsnh_Group_收益 { get { return GetMessage(1403); } }
        public string Dsnh_Group_经常转移 { get { return GetMessage(1404); } }
        public string Dsnh_Group_资本账户 { get { return GetMessage(1405); } }
        public string Dsnh_Group_直接投资 { get { return GetMessage(1406); } }
        public string Dsnh_Group_证券投资 { get { return GetMessage(1407); } }
        public string Dsnh_Group_其他投资 { get { return GetMessage(1408); } }

        private string GetMessage(int code)
        {
            string result = string.Empty;
            //判断多语言
            try { result = BOC_BATCH_TOOL.Utilities.EnumNameHelper<DealSerialNoStringHelper>.GetEnumDescription((DealSerialNoStringHelper)code); }
            catch { }
            return result;
        }

    }
    public enum DealSerialNoStringHelper
    {
        [TranslatingKeyAttribute("DsnhN1", "一般贸易收入", "", "")]
        DsnhN1 = 101010,
        [TranslatingKeyAttribute("DsnhN2", "补偿贸易收入", "", "")]
        DsnhN2 = 101020,
        [TranslatingKeyAttribute("DsnhN3", "寄售代销贸易收入", "", "")]
        DsnhN3 = 101030,
        [TranslatingKeyAttribute("DsnhN4", "边境贸易收入", "", "")]
        DsnhN4 = 101040,
        [TranslatingKeyAttribute("DsnhN5", "对外承包工程货物出口收入", "", "")]
        DsnhN5 = 101050,
        [TranslatingKeyAttribute("DsnhN6", "水，电，煤气、天然气等出口收入", "", "")]
        DsnhN6 = 101080,
        [TranslatingKeyAttribute("DsnhN7", "出售运输工具、天然气石油井架、工作台和其他活动设备收入", "", "")]
        DsnhN7 = 101090,
        [TranslatingKeyAttribute("DsnhN8", "易货贸易收入", "", "")]
        DsnhN8 = 101100,
        [TranslatingKeyAttribute("DsnhN9", "远洋渔业、石油、矿产销售收入", "", "")]
        DsnhN9 = 101140,
        [TranslatingKeyAttribute("DsnhN10", "来料加工装配贸易出口 ", "", "")]
        DsnhN10 = 102010,
        [TranslatingKeyAttribute("DsnhN11", "进料加工贸易项下的成品出口 ", "", "")]
        DsnhN11 = 102030,
        [TranslatingKeyAttribute("DsnhN12", "出料加工贸易出口", "", "")]
        DsnhN12 = 102040,
        [TranslatingKeyAttribute("DsnhN13", "为修理提供货物所得收入", "", "")]
        DsnhN13 = 103010,
        [TranslatingKeyAttribute("DsnhN14", "在港口为运输工具提供货物的收入", "", "")]
        DsnhN14 = 104010,
        [TranslatingKeyAttribute("DsnhN15", "非货币黄金进出口收入", "", "")]
        DsnhN15 = 105010,
        [TranslatingKeyAttribute("DsnhN16", "其他收入", "", "")]
        DsnhN16 = 109000,
        [TranslatingKeyAttribute("DsnhN17", "客运收入 ", "", "")]
        DsnhN17 = 201011,
        [TranslatingKeyAttribute("DsnhN18", "为货物出口提供运输的收入", "", "")]
        DsnhN18 = 201012,
        [TranslatingKeyAttribute("DsnhN19", "为货物进口提供运输的收入 ", "", "")]
        DsnhN19 = 201013,
        [TranslatingKeyAttribute("DsnhN20", "港口服务收入", "", "")]
        DsnhN20 = 201014,
        [TranslatingKeyAttribute("DsnhN21", "其他收入", "", "")]
        DsnhN21 = 201019,
        [TranslatingKeyAttribute("DsnhN22", "客运收入", "", "")]
        DsnhN22 = 201021,
        [TranslatingKeyAttribute("DsnhN23", "为货物出口提供运输的收入 ", "", "")]
        DsnhN23 = 201022,
        [TranslatingKeyAttribute("DsnhN24", "为货物进口提供运输的收入", "", "")]
        DsnhN24 = 201023,
        [TranslatingKeyAttribute("DsnhN25", "港口服务收入", "", "")]
        DsnhN25 = 201024,
        [TranslatingKeyAttribute("DsnhN26", "其他收入", "", "")]
        DsnhN26 = 201029,
        [TranslatingKeyAttribute("DsnhN27", "客运收入", "", "")]
        DsnhN27 = 201031,
        [TranslatingKeyAttribute("DsnhN28", "为货物出口提供运输的收入", "", "")]
        DsnhN28 = 201032,
        [TranslatingKeyAttribute("DsnhN29", "为货物进口提供运输的收入 ", "", "")]
        DsnhN29 = 201033,
        [TranslatingKeyAttribute("DsnhN30", "港口服务收入", "", "")]
        DsnhN30 = 201034,
        [TranslatingKeyAttribute("DsnhN31", "其他收入", "", "")]
        DsnhN31 = 201039,
        [TranslatingKeyAttribute("DsnhN32", "运输佣金、代理费收入", "", "")]
        DsnhN32 = 201040,
        [TranslatingKeyAttribute("DsnhN33", "旅游企业团费收入", "", "")]
        DsnhN33 = 202010,
        [TranslatingKeyAttribute("DsnhN34", "公务及商务差旅收入", "", "")]
        DsnhN34 = 202020,
        [TranslatingKeyAttribute("DsnhN35", "因私旅游收入", "", "")]
        DsnhN35 = 202030,
        [TranslatingKeyAttribute("DsnhN36", "医疗、保健收入 ", "", "")]
        DsnhN36 = 202040,
        [TranslatingKeyAttribute("DsnhN37", "电信服务收入 ", "", "")]
        DsnhN37 = 203010,
        [TranslatingKeyAttribute("DsnhN38", "邮政、邮递服务收入", "", "")]
        DsnhN38 = 203020,
        [TranslatingKeyAttribute("DsnhN39", "建筑、安装服务收入", "", "")]
        DsnhN39 = 204010,
        [TranslatingKeyAttribute("DsnhN40", "劳务承包收入", "", "")]
        DsnhN40 = 204020,
        [TranslatingKeyAttribute("DsnhN41", "责任险收入 ", "", "")]
        DsnhN41 = 205011,
        [TranslatingKeyAttribute("DsnhN42", "信用保证险收入", "", "")]
        DsnhN42 = 205012,
        [TranslatingKeyAttribute("DsnhN43", "进出口货运险收入 ", "", "")]
        DsnhN43 = 205013,
        [TranslatingKeyAttribute("DsnhN44", "其他险收入 ", "", "")]
        DsnhN44 = 205019,
        [TranslatingKeyAttribute("DsnhN45", "人身险收入", "", "")]
        DsnhN45 = 205020,
        [TranslatingKeyAttribute("DsnhN46", "再保险收入", "", "")]
        DsnhN46 = 205030,
        [TranslatingKeyAttribute("DsnhN47", "保险中介服务收入", "", "")]
        DsnhN47 = 205040,
        [TranslatingKeyAttribute("DsnhN48", "其他保险收入", "", "")]
        DsnhN48 = 205090,
        [TranslatingKeyAttribute("DsnhN49", "6.金融服务中介费、手续费 、担保费、承诺费收入", "", "")]
        DsnhN49 = 206010,
        [TranslatingKeyAttribute("DsnhN50", "与计算机有关的其他服务收入 ", "", "")]
        DsnhN50 = 207010,
        [TranslatingKeyAttribute("DsnhN51", "书刊、杂志和电子出版物以及新闻、信息服务收入", "", "")]
        DsnhN51 = 207020,
        [TranslatingKeyAttribute("DsnhN52", "专利特许权收入 ", "", "")]
        DsnhN52 = 208010,
        [TranslatingKeyAttribute("DsnhN53", "非专利发明或专有技术收入", "", "")]
        DsnhN53 = 208020,
        [TranslatingKeyAttribute("DsnhN54", "经营权、经销权收入 ", "", "")]
        DsnhN54 = 208030,
        [TranslatingKeyAttribute("DsnhN55", "商标、制作方法收入 ", "", "")]
        DsnhN55 = 208040,
        [TranslatingKeyAttribute("DsnhN56", "版权、著作权、稿费收入", "", "")]
        DsnhN56 = 208050,
        [TranslatingKeyAttribute("DsnhN57", "电影、音像服务收入", "", "")]
        DsnhN57 = 209010,
        [TranslatingKeyAttribute("DsnhN58", "体育、健身及其他文化、娱乐服务收入 ", "", "")]
        DsnhN58 = 209090,
        [TranslatingKeyAttribute("DsnhN59", "签证认证费收入 ", "", "")]
        DsnhN59 = 210010,
        [TranslatingKeyAttribute("DsnhN60", "使领馆经费收入", "", "")]
        DsnhN60 = 210020,
        [TranslatingKeyAttribute("DsnhN61", "转口贸易收入 ", "", "")]
        DsnhN61 = 211011,
        [TranslatingKeyAttribute("DsnhN62", "转口贸易价差收入", "", "")]
        DsnhN62 = 211012,
        [TranslatingKeyAttribute("DsnhN63", "进出口佣金收入 ", "", "")]
        DsnhN63 = 211013,
        [TranslatingKeyAttribute("DsnhN64", "带料加工贸易加工费收入", "", "")]
        DsnhN64 = 211014,
        [TranslatingKeyAttribute("DsnhN65", "经营性租赁服务收入", "", "")]
        DsnhN65 = 211020,
        [TranslatingKeyAttribute("DsnhN66", "法律服务、仲裁收入 ", "", "")]
        DsnhN66 = 211031,
        [TranslatingKeyAttribute("DsnhN67", "会计服务收入 ", "", "")]
        DsnhN67 = 211032,
        [TranslatingKeyAttribute("DsnhN68", "管理咨询服务收入", "", "")]
        DsnhN68 = 211033,
        [TranslatingKeyAttribute("DsnhN69", "认证、公证服务收入 ", "", "")]
        DsnhN69 = 211034,
        [TranslatingKeyAttribute("DsnhN70", "其他收入 ", "", "")]
        DsnhN70 = 211039,
        [TranslatingKeyAttribute("DsnhN71", "广告、展览收入 ", "", "")]
        DsnhN71 = 211041,
        [TranslatingKeyAttribute("DsnhN72", "市场调研收入 ", "", "")]
        DsnhN72 = 211042,
        [TranslatingKeyAttribute("DsnhN73", "工业、技术研究与发展收入", "", "")]
        DsnhN73 = 211051,
        [TranslatingKeyAttribute("DsnhN74", "理论、科学研究与发展收入 ", "", "")]
        DsnhN74 = 211052,
        [TranslatingKeyAttribute("DsnhN75", "建筑、工程技术服务收入 ", "", "")]
        DsnhN75 = 211053,
        [TranslatingKeyAttribute("DsnhN76", "其他收入 ", "", "")]
        DsnhN76 = 211054,
        [TranslatingKeyAttribute("DsnhN77", "驻华机构办公经费", "", "")]
        DsnhN77 = 211060,
        [TranslatingKeyAttribute("DsnhN78", "会费收入", "", "")]
        DsnhN78 = 211070,
        [TranslatingKeyAttribute("DsnhN79", "其他收入", "", "")]
        DsnhN79 = 211090,
        [TranslatingKeyAttribute("DsnhN80", "职工报酬--一年以下雇员汇款收入", "", "")]
        DsnhN80 = 301010,
        [TranslatingKeyAttribute("DsnhN81", "利润汇回 ", "", "")]
        DsnhN81 = 302011,
        [TranslatingKeyAttribute("DsnhN82", "建筑物租金收入", "", "")]
        DsnhN82 = 302012,
        [TranslatingKeyAttribute("DsnhN83", "对母/分公司、附属及关联方贷款利息收入 ", "", "")]
        DsnhN83 = 302013,
        [TranslatingKeyAttribute("DsnhN84", "股票投资收益收入 ", "", "")]
        DsnhN84 = 302021,
        [TranslatingKeyAttribute("DsnhN85", "债券投资收益收入 ", "", "")]
        DsnhN85 = 302022,
        [TranslatingKeyAttribute("DsnhN86", "其他投资收益--贷款及其他债权利息收入", "", "")]
        DsnhN86 = 302031,
        [TranslatingKeyAttribute("DsnhN87", "接受与固定资产无关的捐赠及无偿援助", "", "")]
        DsnhN87 = 401000,
        [TranslatingKeyAttribute("DsnhN88", "保险赔偿收入", "", "")]
        DsnhN88 = 402010,
        [TranslatingKeyAttribute("DsnhN89", "其他赔偿收入 ", "", "")]
        DsnhN89 = 402020,
        [TranslatingKeyAttribute("DsnhN90", "税收收入（如所得税、财产税；社会福利；运输工具注册费等）", "", "")]
        DsnhN90 = 403000,
        [TranslatingKeyAttribute("DsnhN91", "罚款、追缴款收入", "", "")]
        DsnhN91 = 404000,
        [TranslatingKeyAttribute("DsnhN92", "国际组织会费收入", "", "")]
        DsnhN92 = 405000,
        [TranslatingKeyAttribute("DsnhN93", "一年以上雇员汇款收入", "", "")]
        DsnhN93 = 406000,
        [TranslatingKeyAttribute("DsnhN94", "偶然性收入", "", "")]
        DsnhN94 = 407000,
        [TranslatingKeyAttribute("DsnhN95", "其他收入", "", "")]
        DsnhN95 = 408000,
        [TranslatingKeyAttribute("DsnhN96", "接受与固定资产有关的捐赠及无偿援助 ", "", "")]
        DsnhN96 = 501020,
        [TranslatingKeyAttribute("DsnhN97", "国外支付的赔偿 ", "", "")]
        DsnhN97 = 501030,
        [TranslatingKeyAttribute("DsnhN98", "税收收入 ", "", "")]
        DsnhN98 = 501040,
        [TranslatingKeyAttribute("DsnhN99", "移民的转移收入 ", "", "")]
        DsnhN99 = 501050,
        [TranslatingKeyAttribute("DsnhN100", "其他收入 ", "", "")]
        DsnhN100 = 501090,
        [TranslatingKeyAttribute("DsnhN101", "土地批租、租赁收入 ", "", "")]
        DsnhN101 = 502010,
        [TranslatingKeyAttribute("DsnhN102", "商标、专利的所有权转让收入", "", "")]
        DsnhN102 = 502020,
        [TranslatingKeyAttribute("DsnhN103", "其他无形资产的所有权转让收入 ", "", "")]
        DsnhN103 = 502030,
        [TranslatingKeyAttribute("DsnhN104", "境外投资企业清算、终止等撤资 ", "", "")]
        DsnhN104 = 601011,
        [TranslatingKeyAttribute("DsnhN105", "筹备资金撤回 ", "", "")]
        DsnhN105 = 601012,
        [TranslatingKeyAttribute("DsnhN106", "直接投资者境外投资企业减资 ", "", "")]
        DsnhN106 = 601013,
        [TranslatingKeyAttribute("DsnhN107", "将境外投资企业中方股权转让给外方 ", "", "")]
        DsnhN107 = 601014,
        [TranslatingKeyAttribute("DsnhN108", "将境外投资企业中方股权转让给其他中方 ", "", "")]
        DsnhN108 = 601015,
        [TranslatingKeyAttribute("DsnhN109", "中方先行收回投资", "", "")]
        DsnhN109 = 601016,
        [TranslatingKeyAttribute("DsnhN110", "中国境外投资企业对境内直接投资者的股本投资收入", "", "")]
        DsnhN110 = 601017,
        [TranslatingKeyAttribute("DsnhN111", "其他投资资本金撤回 ", "", "")]
        DsnhN111 = 601019,
        [TranslatingKeyAttribute("DsnhN112", "对直接投资企业、附属或关联方收回贷款", "", "")]
        DsnhN112 = 601021,
        [TranslatingKeyAttribute("DsnhN113", "对直接投资企业、附属或关联方得到的贷款 ", "", "")]
        DsnhN113 = 601022,
        [TranslatingKeyAttribute("DsnhN114", "与直接投资企业、附属或关联方的其他资金往来的收入 ", "", "")]
        DsnhN114 = 601023,
        [TranslatingKeyAttribute("DsnhN115", "境内资产变现收入", "", "")]
        DsnhN115 = 601040,
        [TranslatingKeyAttribute("DsnhN116", "出售境外建筑物 ", "", "")]
        DsnhN116 = 601080,
        [TranslatingKeyAttribute("DsnhN117", "投资资本金汇入", "", "")]
        DsnhN117 = 602011,
        [TranslatingKeyAttribute("DsnhN118", "筹备资金汇入 ", "", "")]
        DsnhN118 = 602012,
        [TranslatingKeyAttribute("DsnhN119", "外商投资企业增资 ", "", "")]
        DsnhN119 = 602013,
        [TranslatingKeyAttribute("DsnhN120", "中方向外方转让股权 ", "", "")]
        DsnhN120 = 602014,
        [TranslatingKeyAttribute("DsnhN121", "红筹股项下资产减持对价收入", "", "")]
        DsnhN121 = 602015,
        [TranslatingKeyAttribute("DsnhN122", "非法人投资款收入", "", "")]
        DsnhN122 = 602018,
        [TranslatingKeyAttribute("DsnhN123", "其他投资资本金收入", "", "")]
        DsnhN123 = 602019,
        [TranslatingKeyAttribute("DsnhN124", "外国母公司、附属或关联方对国内外商投资企业贷款 ", "", "")]
        DsnhN124 = 602021,
        [TranslatingKeyAttribute("DsnhN125", "对外国母公司、附属及关联方贷款的收回", "", "")]
        DsnhN125 = 602022,
        [TranslatingKeyAttribute("DsnhN126", "外国母公司、附属或关联方与国内外商投资企业之间的其他资金往来 ", "", "")]
        DsnhN126 = 602023,
        [TranslatingKeyAttribute("DsnhN127", "出售境内建筑物", "", "")]
        DsnhN127 = 602050,
        [TranslatingKeyAttribute("DsnhN128", "卖出境外企业股票或其他形式股本证券 ", "", "")]
        DsnhN128 = 701011,
        [TranslatingKeyAttribute("DsnhN129", "卖出境内机构在境外上市的股票或其他形式股本证券 ", "", "")]
        DsnhN129 = 701012,
        [TranslatingKeyAttribute("DsnhN130", "卖出境外机构发行的(中)长期债券 ", "", "")]
        DsnhN130 = 701021,
        [TranslatingKeyAttribute("DsnhN131", "卖出境内机构在境外发行(中)长期债券 ", "", "")]
        DsnhN131 = 701022,
        [TranslatingKeyAttribute("DsnhN132", "卖出境外货币市场工具 ", "", "")]
        DsnhN132 = 701023,
        [TranslatingKeyAttribute("DsnhN133", "赎回境外投资基金 ", "", "")]
        DsnhN133 = 701024,
        [TranslatingKeyAttribute("DsnhN134", "卖出境外衍生金融工具 ", "", "")]
        DsnhN134 = 701025,
        [TranslatingKeyAttribute("DsnhN135", "在境外市场发行股票及配股 ", "", "")]
        DsnhN135 = 702011,
        [TranslatingKeyAttribute("DsnhN136", "在境内市场向境外投资者发行外币股票及配股 ", "", "")]
        DsnhN136 = 702012,
        [TranslatingKeyAttribute("DsnhN137", "在境内市场向境外投资者发行本币股票及配股 ", "", "")]
        DsnhN137 = 702014,
        [TranslatingKeyAttribute("DsnhN138", "在境外向境外投资者发行(中)长期债券 ", "", "")]
        DsnhN138 = 702021,
        [TranslatingKeyAttribute("DsnhN139", "在境内向境外投资者发行(中)长期债券 ", "", "")]
        DsnhN139 = 702022,
        [TranslatingKeyAttribute("DsnhN140", "在境内向境外投资者发行货币市场工具 ", "", "")]
        DsnhN140 = 702024,
        [TranslatingKeyAttribute("DsnhN141", "在境内向境外投资者发行衍生金融工具 ", "", "")]
        DsnhN141 = 702026,
        [TranslatingKeyAttribute("DsnhN142", "境外投资者投资境内的投资基金 ", "", "")]
        DsnhN142 = 702028,
        [TranslatingKeyAttribute("DsnhN143", "清算资金汇入 ", "", "")]
        DsnhN143 = 703010,
        [TranslatingKeyAttribute("DsnhN144", "证券经营机构清算备用金撤回 ", "", "")]
        DsnhN144 = 703020,
        [TranslatingKeyAttribute("DsnhN145", "政府贷款本金的收回 ", "", "")]
        DsnhN145 = 801021,
        [TranslatingKeyAttribute("DsnhN146", "对外非政府贷款本金的收回", "", "")]
        DsnhN146 = 801022,
        [TranslatingKeyAttribute("DsnhN147", "国际金融租赁融资本金的收回 ", "", "")]
        DsnhN147 = 801023,
        [TranslatingKeyAttribute("DsnhN148", "收回其他贷款 ", "", "")]
        DsnhN148 = 801024,
        [TranslatingKeyAttribute("DsnhN149", "收回或调回存放境外存款本金 ", "", "")]
        DsnhN149 = 801031,
        [TranslatingKeyAttribute("DsnhN150", "保证金调回 ", "", "")]
        DsnhN150 = 801032,
        [TranslatingKeyAttribute("DsnhN151", "其他债权减少 ", "", "")]
        DsnhN151 = 801040,
        [TranslatingKeyAttribute("DsnhN152", "获得外国政府贷款本金 ", "", "")]
        DsnhN152 = 802021,
        [TranslatingKeyAttribute("DsnhN153", "获得国际金融组织贷款本金 ", "", "")]
        DsnhN153 = 802022,
        [TranslatingKeyAttribute("DsnhN154", "获得国外银行及其他金融机构贷款本金 ", "", "")]
        DsnhN154 = 802023,
        [TranslatingKeyAttribute("DsnhN155", "获得买方信贷本金 ", "", "")]
        DsnhN155 = 802024,
        [TranslatingKeyAttribute("DsnhN156", "获得国外企业及个人借款本金 ", "", "")]
        DsnhN156 = 802025,
        [TranslatingKeyAttribute("DsnhN157", "国际金融租赁融资 ", "", "")]
        DsnhN157 = 802026,
        [TranslatingKeyAttribute("DsnhN158", "获得其他贷款本金 ", "", "")]
        DsnhN158 = 802027,
        [TranslatingKeyAttribute("DsnhN159", "境外存入款项 ", "", "")]
        DsnhN159 = 802031,
        [TranslatingKeyAttribute("DsnhN160", "境外存入保证金 ", "", "")]
        DsnhN160 = 802032,
        [TranslatingKeyAttribute("DsnhN161", "认缴非货币性国际组织股本金 ", "", "")]
        DsnhN161 = 802041,
        [TranslatingKeyAttribute("DsnhN162", "借入其他债务 ", "", "")]
        DsnhN162 = 802042,
        [TranslatingKeyAttribute("DsnhU1", "一般货物", "", "")]
        DsnhU1 = 1301,
        [TranslatingKeyAttribute("DsnhU2", "用于加工的货物", "", "")]
        DsnhU2 = 1302,
        [TranslatingKeyAttribute("DsnhU3", "海运收入 ", "", "")]
        DsnhU3 = 1303,
        [TranslatingKeyAttribute("DsnhU4", "空运收入", "", "")]
        DsnhU4 = 1304,
        [TranslatingKeyAttribute("DsnhU5", "其他运输收入", "", "")]
        DsnhU5 = 1305,
        [TranslatingKeyAttribute("DsnhU6", "旅游", "", "")]
        DsnhU6 = 1306,
        [TranslatingKeyAttribute("DsnhU7", "通信服务 ", "", "")]
        DsnhU7 = 1307,
        [TranslatingKeyAttribute("DsnhU8", "建筑、安装及劳务承包服务", "", "")]
        DsnhU8 = 1308,
        [TranslatingKeyAttribute("DsnhU9", "财产险收入 ", "", "")]
        DsnhU9 = 1309,
        [TranslatingKeyAttribute("DsnhU10", "计算机和信息服务", "", "")]
        DsnhU10 = 1310,
        [TranslatingKeyAttribute("DsnhU11", "专有权利使用费和特许费", "", "")]
        DsnhU11 = 1311,
        [TranslatingKeyAttribute("DsnhU12", "体育、文化和娱乐服务 ", "", "")]
        DsnhU12 = 1312,
        [TranslatingKeyAttribute("DsnhU13", "别处未提及的政府服务 ", "", "")]
        DsnhU13 = 1313,
        [TranslatingKeyAttribute("DsnhU14", "转口贸易及贸易佣金 ", "", "")]
        DsnhU14 = 1314,
        [TranslatingKeyAttribute("DsnhU15", "法律、会计、管理咨询和公共关系服务", "", "")]
        DsnhU15 = 1315,
        [TranslatingKeyAttribute("DsnhU16", "广告、展览、市场调研", "", "")]
        DsnhU16 = 1316,
        [TranslatingKeyAttribute("DsnhU17", "技术服务", "", "")]
        DsnhU17 = 1317,
        [TranslatingKeyAttribute("DsnhU18", "国外支付的赔偿", "", "")]
        DsnhU18 = 1318,
        [TranslatingKeyAttribute("DsnhU19", "资本转移 ", "", "")]
        DsnhU19 = 1319,
        [TranslatingKeyAttribute("DsnhU20", "非生产、非金融资产的收买/放弃 ", "", "")]
        DsnhU20 = 1320,
        [TranslatingKeyAttribute("DsnhU21", "投资资本金", "", "")]
        DsnhU21 = 1321,
        [TranslatingKeyAttribute("DsnhU22", "直接投资者与直接投资企业之间借贷及其他往来的收入", "", "")]
        DsnhU22 = 1322,
        [TranslatingKeyAttribute("DsnhU23", "投资资本金汇入 ", "", "")]
        DsnhU23 = 1323,
        [TranslatingKeyAttribute("DsnhU24", "直接投资企业与直接投资者之间借贷及其他往来", "", "")]
        DsnhU24 = 1324,
        [TranslatingKeyAttribute("DsnhU25", "股本证券", "", "")]
        DsnhU25 = 1325,
        [TranslatingKeyAttribute("DsnhU26", "债务证券 ", "", "")]
        DsnhU26 = 1326,
        [TranslatingKeyAttribute("DsnhU27", "与证券买卖有关的资金跨境流动", "", "")]
        DsnhU27 = 1327,
        [TranslatingKeyAttribute("DsnhU28", "对外贷款收回", "", "")]
        DsnhU28 = 1328,
        [TranslatingKeyAttribute("DsnhU29", "货币和存款收回", "", "")]
        DsnhU29 = 1329,
        [TranslatingKeyAttribute("DsnhU30", "获得外国贷款", "", "")]
        DsnhU30 = 1330,
        [TranslatingKeyAttribute("DsnhU31", "货币和存款", "", "")]
        DsnhU31 = 1331,
        [TranslatingKeyAttribute("DsnhU32", "其他", "", "")]
        DsnhU32 = 1332,
        [TranslatingKeyAttribute("DsnhU33", "海运支出", "", "")]
        DsnhU33 = 1333,
        [TranslatingKeyAttribute("DsnhU34", "空运支出", "", "")]
        DsnhU34 = 1334,
        [TranslatingKeyAttribute("DsnhU35", "其它运输支出", "", "")]
        DsnhU35 = 1335,
        [TranslatingKeyAttribute("DsnhU36", "财产险支出", "", "")]
        DsnhU36 = 1336,
        [TranslatingKeyAttribute("DsnhU37", "职工报酬", "", "")]
        DsnhU37 = 1337,
        [TranslatingKeyAttribute("DsnhU38", "对国外支付的赔偿", "", "")]
        DsnhU38 = 1338,
        [TranslatingKeyAttribute("DsnhU39", "投资资本金撤回、清算等", "", "")]
        DsnhU39 = 1339,
        [TranslatingKeyAttribute("DsnhU40", "对外贷款", "", "")]
        DsnhU40 = 1340,
        [TranslatingKeyAttribute("DsnhU41", "向金融性国际组织认缴的份额", "", "")]
        DsnhU41 = 1341,
        [TranslatingKeyAttribute("DsnhU42", "偿还国外贷款", "", "")]
        DsnhU42 = 1342,
        [TranslatingKeyAttribute("DsnhU43", "直接投资收益", "", "")]
        DsnhU43 = 1343,
        [TranslatingKeyAttribute("DsnhU44", "证券投资收益", "", "")]
        DsnhU44 = 1344,
        [TranslatingKeyAttribute("DsnhU45", "其他投资收益", "", "")]
        DsnhU45 = 1345,
        [TranslatingKeyAttribute("DsnhU46", "其他负债", "", "")]
        DsnhU46 = 1346,
        [TranslatingKeyAttribute("DsnhG1", "货物贸易", "", "")]
        DsnhG1 = 1401,
        [TranslatingKeyAttribute("DsnhG2", "服务贸易", "", "")]
        DsnhG2 = 1402,
        [TranslatingKeyAttribute("DsnhG3", "初次收入（收益）", "", "")]
        DsnhG3 = 1403,
        [TranslatingKeyAttribute("DsnhG4", "二次收入（经常转移）", "", "")]
        DsnhG4 = 1404,
        [TranslatingKeyAttribute("DsnhG5", "资本账户", "", "")]
        DsnhG5 = 1405,
        [TranslatingKeyAttribute("DsnhG6", "直接投资", "", "")]
        DsnhG6 = 1406,
        [TranslatingKeyAttribute("DsnhG7", "证券投资及金融衍生工具", "", "")]
        DsnhG7 = 1407,
        [TranslatingKeyAttribute("DsnhG8", "其他投资", "", "")]
        DsnhG8 = 1408,
        [TranslatingKeyAttribute("DsnhG9", "境内外汇收支交易及其他特殊交易", "", "")]
        DsnhG9 = 1409,
    }
}