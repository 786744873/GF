using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using System.Text.RegularExpressions;

namespace CommonClient.ConvertHelper
{
    public static class DataConvertHelper
    {
        public static string ConvertA2CN(string amount, int maxlength = 15, CashType ct = CashType.CNY)
        {
            if (string.IsNullOrEmpty(amount) || (!string.IsNullOrEmpty(amount) && !Regex.IsMatch(amount.Replace(",", ""), @"^[0-9,.]{1,}$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))) return string.Empty;
            if ((ct != CashType.JPY && ((amount.Replace(",", "").Contains(".") && amount.Replace(",", "").Length > maxlength + 1) || (!amount.Replace(",", "").Contains(".") && amount.Replace(",", "").Length > maxlength - 2)))
                || (ct == CashType.JPY && amount.Replace(",", "").Replace(",", "").Length > maxlength - 2)) return string.Empty;

            #region params
            //unit of decimal
            var fraction = new string[2];
            //number to Chinese
            var digit = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            //unit of CNY
            var unit = new string[][] { new string[] { "元", "万", "亿", "万亿", "京", "垓" }, new string[] { "", "拾", "佰", "仟" } };
            var str = "";
            //integer
            var inte = "";
            //decimal
            var deci = "";
            #endregion

            #region 027&088 have no decimal
            switch (ct)
            {
                case CashType.AUD:
                case CashType.CAD:
                case CashType.HKD:
                case CashType.MOP:
                case CashType.NZD:
                case CashType.SGD:
                case CashType.USD:
                    fraction = new string[] { "拾", "分" };
                    break;
                //瑞士法郎
                case CashType.CHF:
                    fraction = new string[] { "拾", "分" };
                    unit[0][0] = "法郎";
                    break;
                //丹麦克郎
                case CashType.DKK:
                    fraction = new string[] { "拾", "欧尔" };
                    unit[0][0] = "克朗";
                    break;
                //欧元
                case CashType.EUR:
                    fraction = new string[] { "拾", "生丁" };
                    break;
                //英镑
                case CashType.GBP:
                    fraction = new string[] { "拾", "便士" };
                    unit[0][0] = "镑";
                    break;
                //挪威克郎
                case CashType.NOK:
                //瑞典克郎
                case CashType.SEK:
                    fraction = new string[] { "拾", "欧尔" };
                    unit[0][0] = "克朗";
                    break;
                //菲律宾比索
                case CashType.PHP:
                    unit[0][0] = "比索";
                    break;
                //泰国铢
                case CashType.THB:
                    fraction = new string[] { "拾", "萨当" };
                    unit[0][0] = "铢";
                    break;
                default:
                    fraction = new string[] { "角", "分" };
                    break;
            }
            #endregion

            #region split data
            amount = amount.Replace(",", "");
            if (amount.IndexOf(".") != -1)
            {
                inte = amount.Substring(0, amount.IndexOf(".")).Trim();
                deci = amount.Substring(amount.IndexOf(".") + 1).Trim();
            }
            else
                inte = amount;
            #endregion

            #region decimal handle
            if (!string.IsNullOrEmpty(deci))
            {
                if (deci.Length > 2) { return string.Empty; }
                for (int i = 0, len = deci.Length; i < len; i++)
                {
                    if (deci.Substring(i, 1) != "0")
                    {
                        str += digit[int.Parse(deci.Substring(i, 1))] + fraction[i];
                        if ((len == 1 && ct != CashType.CNY) || (len == 2 && deci.Substring(1, 1) == "0"))
                            str += fraction[1];
                    }
                }
            }
            #endregion
            #region integer handle
            var temp = string.Empty;
            for (int i = 0; i < unit[0].Length && inte.Length > 0; i++)
            {
                if (i == 0)
                {
                    if (string.IsNullOrEmpty(str))
                        str = unit[0][0] + "整";
                }
                temp = string.Empty;
                if (inte.StartsWith("0")) break;
                for (var j = 0; j < unit[1].Length && inte.Length > 0; j++)
                {
                    if (inte.StartsWith("0")) break;
                    if (!long.Parse(inte).ToString().EndsWith("0")) temp = digit[long.Parse(inte) % 10] + unit[1][j] + temp;
                    else if (!temp.StartsWith("零")) temp = temp.Insert(0, "零");
                    inte = Math.Floor(double.Parse(inte) / 10).ToString();
                }
                //if (temp.StartsWith("零")) 
                if (temp.EndsWith("零")) temp = temp.Substring(0, temp.Length - 1);
                if (!string.IsNullOrEmpty(temp)) str = temp + unit[0][i] + str;
                else str = "零" + str;
                str = str.Replace("零零", "零");
            }
            #endregion
            return str.Replace(unit[0][0] + unit[0][0], unit[0][0]).Replace("零零", "零").Replace("零" + unit[0][0] + "整", unit[0][0] + "整").Replace("角分", "角");
        }

        public static ChinaProvinceType GetProvince(string name)
        {
            var result = ChinaProvinceType.B0;
            switch (name)
            {
                case "10":
                case "总行": result = ChinaProvinceType.B10; break;
                case "11":
                case "北京":
                case "北京市": result = ChinaProvinceType.B11; break;
                case "12":
                case "天津":
                case "天津市": result = ChinaProvinceType.B12; break;
                case "13":
                case "河北":
                case "河北省": result = ChinaProvinceType.B13; break;
                case "14":
                case "山西":
                case "山西省": result = ChinaProvinceType.B14; break;
                case "15":
                case "内蒙古自治":
                case "内蒙古自治区": result = ChinaProvinceType.B15; break;
                case "21":
                case "辽宁":
                case "辽宁省": result = ChinaProvinceType.B21; break;
                case "22":
                case "吉林":
                case "吉林省": result = ChinaProvinceType.B22; break;
                case "23":
                case "黑龙江":
                case "黑龙江省": result = ChinaProvinceType.B23; break;
                case "30":
                case "上海自贸区": result = ChinaProvinceType.B30; break;
                case "31":
                case "上海":
                case "上海市": result = ChinaProvinceType.B31; break;
                case "32":
                case "江苏":
                case "江苏省": result = ChinaProvinceType.B32; break;
                case "33":
                case "浙江":
                case "浙江省": result = ChinaProvinceType.B33; break;
                case "34":
                case "安徽":
                case "安徽省": result = ChinaProvinceType.B34; break;
                case "35":
                case "福建":
                case "福建省": result = ChinaProvinceType.B35; break;
                case "36":
                case "江西":
                case "江西省": result = ChinaProvinceType.B36; break;
                case "37":
                case "山东":
                case "山东省": result = ChinaProvinceType.B37; break;
                case "41":
                case "河南":
                case "河南省": result = ChinaProvinceType.B41; break;
                case "42":
                case "湖北":
                case "湖北省": result = ChinaProvinceType.B42; break;
                case "43":
                case "湖南":
                case "湖南省": result = ChinaProvinceType.B43; break;
                case "44":
                case "广东":
                case "广东省": result = ChinaProvinceType.B44; break;
                case "45":
                case "广西":
                case "广西壮族自治区": result = ChinaProvinceType.B45; break;
                case "46":
                case "海南":
                case "海南省": result = ChinaProvinceType.B46; break;
                case "50":
                case "重庆":
                case "重庆市": result = ChinaProvinceType.B50; break;
                case "51":
                case "四川":
                case "四川省": result = ChinaProvinceType.B51; break;
                case "52":
                case "贵州":
                case "贵州省": result = ChinaProvinceType.B52; break;
                case "53":
                case "云南":
                case "云南省": result = ChinaProvinceType.B53; break;
                case "54":
                case "西藏":
                case "西藏自治区": result = ChinaProvinceType.B54; break;
                case "61":
                case "陕西":
                case "陕西省": result = ChinaProvinceType.B61; break;
                case "62":
                case "甘肃":
                case "甘肃省": result = ChinaProvinceType.B62; break;
                case "63":
                case "青海":
                case "青海省": result = ChinaProvinceType.B63; break;
                case "64":
                case "宁夏":
                case "宁夏回族自治区": result = ChinaProvinceType.B64; break;
                case "65":
                case "新疆":
                case "新疆维吾尔自治区": result = ChinaProvinceType.B65; break;
                case "71":
                case "苏州":
                case "苏州市": result = ChinaProvinceType.B71; break;
                case "72":
                case "宁波":
                case "宁波市": result = ChinaProvinceType.B72; break;
                case "99":
                case "深圳":
                case "深圳市": result = ChinaProvinceType.B99; break;
                default: break;
            }
            return result;
        }

        public static AgentExpressCertifyPaperType GetAgentExpressCertifyPaperType(string name)
        {
            var result = AgentExpressCertifyPaperType.Empty;
            switch (name)
            {
                case "01":
                case "居民身份证": result = AgentExpressCertifyPaperType.IDCard; break;
                case "02":
                case "临时身份证": result = AgentExpressCertifyPaperType.TempIDCard; break;
                case "03":
                case "护照": result = AgentExpressCertifyPaperType.Passport; break;
                case "04":
                case "户口簿": result = AgentExpressCertifyPaperType.ResidencePaper; break;
                case "05":
                case "军人身份证": result = AgentExpressCertifyPaperType.SolderPaper; break;
                case "06":
                case "武装武警身份证": result = AgentExpressCertifyPaperType.ArmedCopPaper; break;
                case "08":
                case "外交人员身份证": result = AgentExpressCertifyPaperType.DiplomaticAgentPaper; break;
                case "09":
                case "外国人居留许可证": result = AgentExpressCertifyPaperType.ForeignerStayPermit; break;
                case "10":
                case "边民出入境通行证": result = AgentExpressCertifyPaperType.ConturySidePeoplePassport; break;
                case "11":
                case "对私其它": result = AgentExpressCertifyPaperType.PersonalOtherPaper; break;
                case "21":
                case "企业法人营业执照": result = AgentExpressCertifyPaperType.CorperationDelegateLicense; break;
                case "22":
                case "企业营业执照": result = AgentExpressCertifyPaperType.CorperationOpertatingLicense; break;
                case "30":
                case "驻华机构登记证": result = AgentExpressCertifyPaperType.OrganizeInChinaRegisterPaper; break;
                case "31":
                case "个体工商户营业执照": result = AgentExpressCertifyPaperType.IndividualBusinessOperatingLicense; break;
                case "33":
                case "组织机构代码证": result = AgentExpressCertifyPaperType.OrganizeCodePaper; break;
                case "47":
                case "港澳居民来往内地通行证（香港）": result = AgentExpressCertifyPaperType.HK_PeoplePassport; break;
                case "48":
                case "港澳居民来往内地通行证（澳门）": result = AgentExpressCertifyPaperType.MC_PeoplePassport; break;
                case "49":
                case "台湾居民来往大陆通行证": result = AgentExpressCertifyPaperType.TW_PeoplePassport; break;
            }
            return result;
        }

        public static PayeeCertifyPaperType GetPayeeCertifyPaperType(string name)
        {
            var result = PayeeCertifyPaperType.Empty;
            switch (name)
            {
                case "1":
                case "居民身份证": result = PayeeCertifyPaperType.IDCard; break;
                case "2":
                case "临时身份证": result = PayeeCertifyPaperType.TempIDCard; break;
                case "8":
                case "护照": result = PayeeCertifyPaperType.Passport; break;
                case "3":
                case "户口簿": result = PayeeCertifyPaperType.ResidencePaper; break;
                case "4":
                case "军人身份证": result = PayeeCertifyPaperType.SolderPaper; break;
                case "5":
                case "武装武警身份证": result = PayeeCertifyPaperType.ArmedCopPaper; break;
                case "11":
                case "外交人员身份证": result = PayeeCertifyPaperType.DiplomaticAgentPaper; break;
                case "12":
                case "外国人居留许可证": result = PayeeCertifyPaperType.ForeignerStayPermit; break;
                case "13":
                case "边民出入境通行证": result = PayeeCertifyPaperType.ConturySidePeoplePassport; break;
                case "9":
                case "对私其它": result = PayeeCertifyPaperType.PersonalOtherPaper; break;
                case "21":
                case "企业法人营业执照": result = PayeeCertifyPaperType.CorperationDelegateLicense; break;
                case "22":
                case "企业营业执照": result = PayeeCertifyPaperType.CorperationOpertatingLicense; break;
                case "30":
                case "驻华机构登记证": result = PayeeCertifyPaperType.OrganizeInChinaRegisterPaper; break;
                case "31":
                case "个体工商户营业执照": result = PayeeCertifyPaperType.IndividualBusinessOperatingLicense; break;
                case "33":
                case "组织机构代码证": result = PayeeCertifyPaperType.OrganizeCodePaper; break;
                case "47":
                case "港澳居民来往内地通行证（香港）": result = PayeeCertifyPaperType.HK_PeoplePassport; break;
                case "48":
                case "港澳居民来往内地通行证（澳门）": result = PayeeCertifyPaperType.MC_PeoplePassport; break;
                case "49":
                case "台湾居民来往大陆通行证": result = PayeeCertifyPaperType.TW_PeoplePassport; break;
                case "23":
                case "政府人事部门或编制委员会的批文": result = PayeeCertifyPaperType.Aecpt23; break;
                case "24":
                case "事业单位法人登记证书": result = PayeeCertifyPaperType.Aecpt24; break;
                case "25":
                case "军队、武警部队开户核准通知书": result = PayeeCertifyPaperType.Aecpt25; break;
                case "26":
                case "社会团体登记证书": result = PayeeCertifyPaperType.Aecpt26; break;
                case "27":
                case "上级主管部门批文或证明": result = PayeeCertifyPaperType.Aecpt27; break;
                case "28":
                case "工会法人资格证书": result = PayeeCertifyPaperType.Aecpt28; break;
                case "29":
                case "民办非企业登记证书": result = PayeeCertifyPaperType.Aecpt29; break;
                case "32":
                case "企业名称预先核准通知书": result = PayeeCertifyPaperType.Aecpt32; break;
                case "34":
                case "国税登记证": result = PayeeCertifyPaperType.Aecpt34; break;
                case "35":
                case "地税登记证": result = PayeeCertifyPaperType.Aecpt35; break;
                case "36":
                case "批准证书": result = PayeeCertifyPaperType.Aecpt36; break;
                case "37":
                case "进出口业务资格证书": result = PayeeCertifyPaperType.Aecpt37; break;
                case "38":
                case "外贸易经营者备案登记表": result = PayeeCertifyPaperType.Aecpt38; break;
                case "39":
                case "金融许可证": result = PayeeCertifyPaperType.Aecpt39; break;
                case "40":
                case "外汇业务核准件": result = PayeeCertifyPaperType.Aecpt40; break;
                case "41":
                case "外汇登记证": result = PayeeCertifyPaperType.Aecpt41; break;
                case "42":
                case "开户许可证": result = PayeeCertifyPaperType.Aecpt42; break;
                case "43":
                case "办学许可证": result = PayeeCertifyPaperType.Aecpt43; break;
                case "44":
                case "对公其它": result = PayeeCertifyPaperType.Aecpt44; break;
                case "45":
                case "各驻华机构编号": result = PayeeCertifyPaperType.Aecpt45; break;
                case "46":
                case "宗教事务管理部门批文或证明": result = PayeeCertifyPaperType.Aecpt46; break;
                //case "56":
                //case "金融机构编码": result = PayeeCertifyPaperType.Aecpt56; break;
            }
            return result;
        }

        public static AgentNormalCertifyPaperType GetAgentNormalCertifyPaperType(string name)
        {
            var result = AgentNormalCertifyPaperType.IDCard;
            switch (name)
            {
                case "01":
                case "居民身份证": result = AgentNormalCertifyPaperType.IDCard; break;
                case "02":
                case "临时身份证": result = AgentNormalCertifyPaperType.TempIDCard; break;
                case "03":
                case "护照": result = AgentNormalCertifyPaperType.Passport; break;
                case "04":
                case "户口簿": result = AgentNormalCertifyPaperType.ResidencePaper; break;
                case "05":
                case "军人身份证": result = AgentNormalCertifyPaperType.SolderPaper; break;
                case "06":
                case "武装武警身份证": result = AgentNormalCertifyPaperType.ArmedCopPaper; break;
                case "07":
                case "港澳台居民往来内地通行证": result = AgentNormalCertifyPaperType.F_PassportPaper; break;
                case "08":
                case "外交人员身份证": result = AgentNormalCertifyPaperType.DiplomaticAgentPaper; break;
                case "09":
                case "外国人居留许可证": result = AgentNormalCertifyPaperType.ForeignerStayPermit; break;
                case "10":
                case "边民出入境通行证": result = AgentNormalCertifyPaperType.ConturySidePeoplePassport; break;
                case "11":
                case "其他": result = AgentNormalCertifyPaperType.OtherPaper; break;
            }
            return result;
        }

        public static AgentNormalFunctionType GetAgentNormalFunctionType(string name)
        {
            AgentNormalFunctionType anft = AgentNormalFunctionType.Empty;
            switch (name)
            {
                case "A10":
                case "工资": anft = AgentNormalFunctionType.A10; break;
                case "A11":
                case "稿费、演出费等劳务收入": anft = AgentNormalFunctionType.A11; break;
                case "A12":
                case "债卷、期货、信托等投资的本金和收益": anft = AgentNormalFunctionType.A12; break;
                case "A13":
                case "个人债权或产权转让收益": anft = AgentNormalFunctionType.A13; break;
                case "A14":
                case "个人贷款转存": anft = AgentNormalFunctionType.A14; break;
                case "A15":
                case "报销": anft = AgentNormalFunctionType.A15; break;
                case "A16":
                case "继承、赠与款项": anft = AgentNormalFunctionType.A16; break;
                case "A17":
                case "保险理赔、保费退还等款项": anft = AgentNormalFunctionType.A17; break;
                case "A18":
                case "纳税退还": anft = AgentNormalFunctionType.A18; break;
                case "A19":
                case "农、福、矿产品销售收入": anft = AgentNormalFunctionType.A19; break;
                case "A20":
                case "其他合法款项": anft = AgentNormalFunctionType.A20; break;
            }
            return anft;
        }

        public static BusinessType GetBusinessType(string name)
        {
            var result = BusinessType.Other;
            name = name.PadLeft(5, '0');
            switch (name)
            {
                case "00100":
                case "电费": result = BusinessType.EnergyFee; break;
                case "00200":
                case "水暖费": result = BusinessType.WaterFee; break;
                case "00300":
                case "煤气费": result = BusinessType.GasFee; break;
                case "00400":
                case "电话费": result = BusinessType.PhoneFee; break;
                case "00500":
                case "通讯费": result = BusinessType.CommunicationFee; break;
                case "00600":
                case "保险费": result = BusinessType.SecureFee; break;
                case "00700":
                case "房屋管理费": result = BusinessType.HouseMgFee; break;
                case "00800":
                case "代理服务费": result = BusinessType.AgentServiceFee; break;
                case "00900":
                case "学教费": result = BusinessType.TechingFee; break;
                case "01000":
                case "有线电视费": result = BusinessType.TVFee; break;
                case "01100":
                case "企业管理费": result = BusinessType.CropMgFee; break;
                case "01200":
                case "薪金报酬": result = BusinessType.Salary; break;
                case "02025":
                case "贷款还房贷类": result = BusinessType.PayForHouse; break;
                case "02026":
                case "贷款还车贷类": result = BusinessType.PayForCar; break;
                case "02027":
                case "贷款还信用卡类": result = BusinessType.PayForCreditCard; break;
                case "09001":
                case "其他": result = BusinessType.Other; break;
            }
            return result;
        }

        public static TransferChanelType GetTransferChanelType(string data)
        {
            TransferChanelType tct = TransferChanelType.Normal;
            try
            {
                tct = (TransferChanelType)int.Parse(data);
            }
            catch
            {
                if ("普通" == data)
                    tct = TransferChanelType.Normal;
                else if ("加急" == data)
                    tct = TransferChanelType.Express;
            }
            return tct;
        }

        public static AgentExpressFunctionType GetAgentExpressFunctionType(string data)
        {
            AgentExpressFunctionType aeft = AgentExpressFunctionType.Empty;
            int index = PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList.FindIndex(o => o.ToString() == data || EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(o) == data);
            if (index >= 0) aeft = PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList[index];
            if ((SysCoach.SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar && aeft == AgentExpressFunctionType.JS) aeft = AgentExpressFunctionType.Empty;
            return aeft;
        }

        public static string FormatCash(string data, bool isJPY)
        {
            return FormatCash(data, isJPY, true);
        }

        public static string FormatCash(string data, bool isJPY, bool canCut)
        {
            string result = string.Empty;
            data = data.Replace(",", "").Trim();
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
            if (Regex.IsMatch(data, @"^00*$", options))
            {
                result = "0.00";
            }
            else if (Regex.IsMatch(data, @"^00*\.\d*$", options))
            {
                int index = data.IndexOf('.');
                string temp = data.Substring(index + 1);
                result = string.Format("0.{0}", temp.Length > 2 ? (canCut ? temp.Substring(0, 2) : temp) : temp.PadRight(2, '0'));
            }
            else
            {
                data = data.TrimStart('0');
                if (!Regex.IsMatch(data, @"^(\-?([1-9][0-9]*[\.\d]?\d*)|(\-?[0-9]\.\d*))$", options))
                { result = string.Empty; }
                else
                {
                    string[] array = data.Split('.');
                    if (array.Length < 2)
                    { result = InsertKPosition(array[0]) + ".00"; }
                    else if (array.Length == 2)
                    {
                        if (array[1].Length <= 2)
                            result = InsertKPosition(array[0]) + "." + array[1].PadRight(2, '0');
                        else if (array[1].Length > 2)
                            result = InsertKPosition(array[0]) + "." + (canCut ? array[1].Substring(0, 2) : array[1]);
                    }
                    else if (array.Length > 2)
                        result = string.Empty;
                }
            }

            if (isJPY)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    int index = result.IndexOf('.');
                    result = result.Substring(0, index);
                }
            }
            return result.Replace("-,", "-");
        }

        private static string InsertKPosition(string data)
        {
            string result = data;
            int index = data.Length;
            for (int i = index - 3; i > 0; i++)
            {
                result = result.Insert(i, ",");
                i -= 4;
            }
            return result;
        }

        public static string FormatNum(string data)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                if (data.ToLower().Contains("e+"))
                {
                    try
                    {
                        string[] tempList = data.Split(new string[] { "e+", "E+" }, StringSplitOptions.None);
                        if (tempList.Length > 0)
                        {
                            str = tempList[0].Replace(".", "");
                            str = str.PadRight(int.Parse(tempList[1]) + 1, '0');
                        }
                    }
                    catch { str = data.ToLower().Replace("e+", ""); }
                }
                else
                    str = data;
            }
            return str;
        }

        public static string FormatPayMoneyPercent(string data, bool ispercent)
        {
            string result = string.Empty;
            //string matchstr = ispercent ? @"^((\d{1,2}(\.\d{1,4})?)|(100(\.0{1,4})?))$" : @"^((0(\.\d{1,6})?)|(1(\.0{1,6})?))$";
            //RegexOptions options = RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase;
            //if (Regex.IsMatch(data, matchstr, options))
            //{
            try
            {
                string[] temp = data.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length == 1) result = string.Format("{0}.{1}", temp[0], string.Empty.PadRight(ispercent ? 4 : 6, '0'));
                else if (temp.Length == 2) result = string.Format("{0}.{1}", temp[0], temp[1].PadRight(ispercent ? 4 : 6, '0'));

                if (double.Parse(result) == 0.0d) result = string.Empty;
            }
            catch { result = string.Empty; }
            //}
            return result;
        }

        public static string FormatProtocolPercent(string data)
        {
            string result = string.Empty;
            //string matchstr = @"((0\.[1-9])|([1-9][0-9]?(\.[0-9])?)|(100(\.0)?))";
            //RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
            //if (Regex.IsMatch(data, matchstr, options))
            //{
            try
            {
                string[] temp = data.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length == 1) result = string.Format("{0}.0", int.Parse(temp[0]));
                else if (temp.Length == 2) result = string.Format("{0}.{1}", temp[0], temp[1].Substring(0, 1));

                if (double.Parse(result) == 0.0d) result = string.Empty;
            }
            catch { }
            //}
            return result;
        }

        public static string FormatFileName(string data, string desc)
        {
            string result = data;
            if (!data.ToLower().EndsWith(desc.ToLower())) result += desc;
            return result;
        }

        public static string SetNewFileName(string data)
        {
            string result = data;
            string bocflag = "[boc]";
            result = data.Insert(data.Length - 4, bocflag);
            return result;
        }

        public static string FormatDateTimeFromInt(string data)
        {
            string result = data;
            string matchStr5 = @"^\d{5}$";
            string matchStr8 = @"^\d{8}$";
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
            if (Regex.IsMatch(data, matchStr5, options))
            {
                DateTime dt = DateTime.FromOADate(Convert.ToInt32(data));
                result = dt.Year.ToString().PadLeft(4, '0') + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Day.ToString().PadLeft(2, '0');
            }
            else if (Regex.IsMatch(data, matchStr8, options))
            {
                result = data.Insert(6, "/").Insert(4, "/");
            }
            else
            {
                try
                {
                    DateTime dt = DateTime.Parse(data);
                    result = dt.Year.ToString().PadLeft(4, '0') + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Day.ToString().PadLeft(2, '0');
                }
                catch { }
            }
            return result;
        }

        public static string FormatTime(string data)
        {
            string str = string.Empty;
            if (Regex.IsMatch(data, @"[0-9]{2}(:00){1,2}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
            {
                if (data.Length >= 5) str = data.Substring(0, 5);
            }
            return str;
        }

        public static AppliableFunctionType GetAppliableFunctionType(string aftStr)
        {
            AppliableFunctionType aft = AppliableFunctionType._Empty;

            switch (aftStr)
            {
                case "AgentExpressIn": aft = AppliableFunctionType.AgentExpressIn; break;
                case "AgentExpressOut": aft = AppliableFunctionType.AgentExpressOut; break;
                case "AgentNormalIn": aft = AppliableFunctionType.AgentNormalIn; break;
                case "AgentNormalOut": aft = AppliableFunctionType.AgentNormalOut; break;
                case "TransferOverBankIn": aft = AppliableFunctionType.TransferOverBankIn; break;
                case "TransferOverBankOut": aft = AppliableFunctionType.TransferOverBankOut; break;
                case "TransferWithCorp": aft = AppliableFunctionType.TransferWithCorp; break;
                case "TransferWithIndiv": aft = AppliableFunctionType.TransferWithIndiv; break;
                case "ElecTicketRemit": aft = AppliableFunctionType.ElecTicketRemit; break;
                case "ElecTicketTipExchange": aft = AppliableFunctionType.ElecTicketTipExchange; break;
                case "ElecTicketBackNote": aft = AppliableFunctionType.ElecTicketBackNote; break;
                case "ElecTicketPayMoney": aft = AppliableFunctionType.ElecTicketPayMoney; break;
                case "ElecTicketPool": aft = AppliableFunctionType.ElecTicketPool; break;
                case "TransferOverCountry": aft = AppliableFunctionType.TransferOverCountry; break;
                case "TransferForeignMoney": aft = AppliableFunctionType.TransferForeignMoney; break;
                case "InitiativeAllot": aft = AppliableFunctionType.InitiativeAllot; break;
                case "PurchaserOrder": aft = AppliableFunctionType.PurchaserOrder; break;
                case "SellerOrder": aft = AppliableFunctionType.SellerOrder; break;
                case "PurchaserOrderMgr": aft = AppliableFunctionType.PurchaserOrderMgr; break;
                case "SellerOrderMgr": aft = AppliableFunctionType.SellerOrderMgr; break;
                case "BillofDebtReceivablePurchaser": aft = AppliableFunctionType.BillofDebtReceivablePurchaser; break;
                case "BillofDebtReceivableSeller": aft = AppliableFunctionType.BillofDebtReceivableSeller; break;
                case "PaymentOrReceiptofDebtReceivablePurchaser": aft = AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser; break;
                case "ApplyofFranchiserFinancing": aft = AppliableFunctionType.ApplyofFranchiserFinancing; break;
                case "UnitivePaymentRMB": aft = AppliableFunctionType.UnitivePaymentRMB; break;
                case "UnitivePaymentFC": aft = AppliableFunctionType.UnitivePaymentFC; break;
                case "AgentExpressOut4Bar": aft = AppliableFunctionType.AgentExpressOut4Bar; break;
                case "TransferForeignMoney4Bar": aft = AppliableFunctionType.TransferForeignMoney4Bar; break;
                case "TransferOverCountry4Bar": aft = AppliableFunctionType.TransferOverCountry4Bar; break;
                case "BatchReimbursement": aft = AppliableFunctionType.BatchReimbursement; break;
                default: break;
            }

            return aft;
        }

        public static string GetAppliableFunctionTypeString(AppliableFunctionType aft)
        {
            return aft.ToString();
        }

        public static AccountCategoryType GetAccountCategoryTypeObject(int data)
        {
            AccountCategoryType act = AccountCategoryType.Empty;
            int index = PrequisiteDataProvideNode.InitialProvide.AccountCategoryTypeList.FindIndex(o => (int)o == data);
            if (index >= 0)
                act = PrequisiteDataProvideNode.InitialProvide.AccountCategoryTypeList[index];
            return act;
        }

        public static AccountCategoryType GetAccountCategoryTypeObject(string data)
        {
            AccountCategoryType act = AccountCategoryType.Empty;
            switch (data)
            {
                case "0":
                case "对公账户": act = AccountCategoryType.Corperation; break;
                case "4":
                case "对私账户": act = AccountCategoryType.Personal; break;
            }
            return act;
        }

        public static AccountBankType GetAccountBankTypeObject(int data)
        {
            AccountBankType act = AccountBankType.Empty;
            int index = PrequisiteDataProvideNode.InitialProvide.AccountBankTypeList.FindIndex(o => (int)o == data);
            if (index >= 0)
                act = PrequisiteDataProvideNode.InitialProvide.AccountBankTypeList[index];
            return act;
        }

        public static AccountBankType GetAccountBankTypeObject(string data, AppliableFunctionType aft)
        {
            AccountBankType act = AccountBankType.Empty;
            if (aft == AppliableFunctionType.TransferWithIndiv
                || aft == AppliableFunctionType.TransferWithCorp
                || aft == AppliableFunctionType.TransferForeignMoney
                || aft == AppliableFunctionType.TransferForeignMoney4Bar
                || aft == AppliableFunctionType.UnitivePaymentRMB)
            {
                #region
                switch (data)
                {
                    case "1":
                    case "是":
                    case "中行":
                    case "中国银行": act = AccountBankType.BocAccount; break;
                    case "0":
                    case "否":
                    case "他行":
                    case "其他银行": act = AccountBankType.OtherBankAccount; break;
                    default: act = AccountBankType.Empty; break;
                }
                if (aft == AppliableFunctionType.TransferForeignMoney4Bar && act == AccountBankType.Empty)
                {
                    if (!string.IsNullOrEmpty(data))
                    {
                        if (data.Contains("中行") || data.Contains("中国银行"))
                            act = AccountBankType.BocAccount;
                        else act = AccountBankType.OtherBankAccount;
                    }
                }
                #endregion
            }
            else if (aft == AppliableFunctionType.ElecTicketPool)
            {
                #region
                switch (data)
                {
                    case "1":
                    case "是":
                    case "中行":
                    case "中国银行": act = AccountBankType.BocAccount; break;
                    case "2":
                    case "否":
                    case "他行":
                    case "其他银行": act = AccountBankType.OtherBankAccount; break;
                    default: act = AccountBankType.Empty; break;
                }
                #endregion
            }
            return act;
        }

        public static AccountBankType GetAccountBankTypeObject(string data, FunctionInSettingType fst)
        {
            AccountBankType act = AccountBankType.Empty;
            if (FunctionInSettingType.PayeeMg == fst)
            {
                #region
                switch (data)
                {
                    case "0":
                    case "是":
                    case "中行":
                    case "中国银行": act = AccountBankType.BocAccount; break;
                    case "1":
                    case "否":
                    case "他行":
                    case "其他银行": act = AccountBankType.OtherBankAccount; break;
                    default: act = AccountBankType.Empty; break;
                }
                #endregion
            }
            return act;
        }

        public static AgentTransferBankType GetAgentTransferBankType(string data)
        {
            AgentTransferBankType bankType = AgentTransferBankType.Other;
            if (!string.IsNullOrEmpty(data))
            {
                if (data.Contains("中行") || data.Contains("中国银行"))
                    bankType = AgentTransferBankType.Boc;
            }
            return bankType;
        }

        public static RelatePersonType GetPersonType(string data)
        {
            RelatePersonType rpt = RelatePersonType.Empty;
            switch (data)
            {
                case "1":
                case "承兑人": rpt = RelatePersonType.Exchange; break;
                case "2":
                case "贴入人": rpt = RelatePersonType.StickOn; break;
                case "4":
                case "收款人": rpt = RelatePersonType.Payee; break;
                case "8":
                case "被背书人": rpt = RelatePersonType.BackNoted; break;
                case "16":
                case "保证人": rpt = RelatePersonType.Guarantor; break;
                case "32":
                case "被追索人": rpt = RelatePersonType.Recoursed; break;
                case "64":
                case "质权人": rpt = RelatePersonType.QRigth; break;
                case "128":
                case "看票人": rpt = RelatePersonType.ViewElecTicket; break;
                case "256":
                case "出票人": rpt = RelatePersonType.Remittor; break;
                default: break;
            }
            return rpt;
        }

        public static ElecTicketType GetElecTicketType(string data, AppliableFunctionType aft)
        {
            ElecTicketType ett = ElecTicketType.Empty;
            if (aft == AppliableFunctionType.ElecTicketRemit)
            {
                switch (data)
                {
                    case "AC01":
                    case "银承": ett = ElecTicketType.AC01; break;
                    case "AC02":
                    case "商承": ett = ElecTicketType.AC02; break;
                    default: break;
                }
            }
            else if (aft == AppliableFunctionType.ElecTicketPool)
            {
                switch (data)
                {
                    case "01":
                    case "银承": ett = ElecTicketType.AC01; break;
                    case "03":
                    case "商承": ett = ElecTicketType.AC02; break;
                    default: break;
                }
            }
            return ett;
        }

        public static CanChangeType GetCanChangeType(string data)
        {
            CanChangeType cct = CanChangeType.Empty;
            switch (data)
            {
                case "EM00":
                case "可以转让": cct = CanChangeType.EM00; break;
                case "EM01":
                case "禁止转让": cct = CanChangeType.EM01; break;
                default: break;
            }
            return cct;
        }

        public static bool GetAutoTipExchange(string data)
        {
            bool flag = false;
            switch (data.ToLower())
            {
                case "0":
                case "no":
                case "false":
                case "否": flag = false; break;
                case "1":
                case "yes":
                case "true":
                case "是": flag = true; break;
                default: break;
            }
            return flag;
        }

        public static bool GetAutoReceiveTicket(string data)
        {
            bool flag = false;
            switch (data.ToLower())
            {
                case "0":
                case "no":
                case "false":
                case "否": flag = false; break;
                case "1":
                case "yes":
                case "true":
                case "是": flag = true; break;
                default: break;
            }
            return flag;
        }

        public static bool GetIsPayOffLine(string data)
        {
            bool flag = false;
            switch (data.ToLower())
            {
                case "0":
                case "n":
                case "no":
                case "false":
                case "否": flag = false; break;
                case "1":
                case "y":
                case "yes":
                case "true":
                case "是": flag = true; break;
                default: break;
            }
            return flag;
        }

        public static bool GetIsTipPayee(string data)
        {
            bool flag = false;
            switch (data.ToLower())
            {
                case "1":
                case "n":
                case "no":
                case "false":
                case "不提醒": flag = false; break;
                case "0":
                case "y":
                case "yes":
                case "true":
                case "提醒": flag = true; break;
                default: break;
            }
            return flag;
        }

        public static ClearMoneyType GetClearType(string data)
        {
            ClearMoneyType cmt = ClearMoneyType.Empty;
            switch (data)
            {
                case "1":
                case "SM00":
                case "线上清算": cmt = ClearMoneyType.SM00; break;
                case "2":
                case "SM01":
                case "线下清算": cmt = ClearMoneyType.SM01; break;
                default: break;
            }
            return cmt;
        }

        public static EndDateOperateType GetEndDateOperateType(string data)
        {
            EndDateOperateType edot = EndDateOperateType.Empty;
            switch (data)
            {
                case "1":
                case "自动托收": edot = EndDateOperateType.AutoReceive; break;
                case "2":
                case "自动提醒": edot = EndDateOperateType.AutoTip; break;
            }
            return edot;
        }

        public static ElecTicketPoolBusinessType GetElecTicketPoolBusinessType(string data)
        {
            ElecTicketPoolBusinessType etpbt = ElecTicketPoolBusinessType.Empty;
            switch (data)
            {
                case "6":
                case "入池托管": etpbt = ElecTicketPoolBusinessType.InPool2Struste; break;
                case "4":
                case "入池质押": etpbt = ElecTicketPoolBusinessType.InPool2Mortgage; break;
            }
            return etpbt;
        }

        public static CashType GetCashType(string data)
        {
            CashType ct = CashType.Empty;
            switch (data)
            {
                case "1":
                case "01":
                case "001":
                case "CNY":
                case "人民币":
                case "人民币元": ct = CashType.CNY; break;
                case "12":
                case "012":
                case "GBP":
                case "英镑": ct = CashType.GBP; break;
                case "13":
                case "013":
                case "HKD":
                case "港元": ct = CashType.HKD; break;
                case "14":
                case "014":
                case "USD":
                case "美元": ct = CashType.USD; break;
                case "15":
                case "015":
                case "CHF":
                case "瑞士法郎": ct = CashType.CHF; break;
                case "16":
                case "016":
                case "DEM":
                case "德国马克": ct = CashType.DEM; break;
                case "17":
                case "017":
                case "FRF":
                case "法国法郎": ct = CashType.FRF; break;
                case "18":
                case "018":
                case "SGD":
                case "新加坡元": ct = CashType.SGD; break;
                case "20":
                case "020":
                case "NLG":
                case "荷兰盾": ct = CashType.NLG; break;
                case "21":
                case "021":
                case "SEK":
                case "瑞典克朗": ct = CashType.SEK; break;
                case "22":
                case "022":
                case "DKK":
                case "丹麦克朗": ct = CashType.DKK; break;
                case "23":
                case "023":
                case "NOK":
                case "挪威克朗": ct = CashType.NOK; break;
                case "24":
                case "024":
                case "ATS":
                case "奥地利先令": ct = CashType.ATS; break;
                case "25":
                case "025":
                case "BEF":
                case "比利时法郎": ct = CashType.BEF; break;
                case "26":
                case "026":
                case "ITL":
                case "意大利里拉": ct = CashType.ITL; break;
                case "27":
                case "027":
                case "JPY":
                case "日元": ct = CashType.JPY; break;
                case "28":
                case "028":
                case "CAD":
                case "加拿大元": ct = CashType.CAD; break;
                case "29":
                case "029":
                case "AUD":
                case "澳大利亚元": ct = CashType.AUD; break;
                case "34":
                case "034":
                case "XAU":
                case "外币金": ct = CashType.XAU; break;
                case "35":
                case "035":
                case "GLD":
                case "本币金": ct = CashType.GLD; break;
                case "36":
                case "036":
                case "XAG":
                case "美元银": ct = CashType.XAG; break;
                case "68":
                case "068":
                case "SLV":
                case "人民币银": ct = CashType.SLV; break;
                case "38":
                case "038":
                case "EUR":
                case "欧元": ct = CashType.EUR; break;
                case "42":
                case "042":
                case "FIM":
                case "芬兰马克": ct = CashType.FIM; break;
                case "81":
                case "081":
                case "MOP":
                case "澳门元": ct = CashType.MOP; break;
                case "82":
                case "082":
                case "PHP":
                case "菲律宾比索": ct = CashType.PHP; break;
                case "84":
                case "084":
                case "THB":
                case "泰国铢": ct = CashType.THB; break;
                case "87":
                case "087":
                case "NZD":
                case "新西兰元": ct = CashType.NZD; break;
                case "88":
                case "088":
                case "KRW":
                case "韩元": ct = CashType.KRW; break;
                case "94":
                case "094":
                case "CLL":
                case "记账美元": ct = CashType.CLL; break;
                case "95":
                case "095":
                case "XHF":
                case "清算瑞士法郎": ct = CashType.XHF; break;
                case "56":
                case "056":
                case "IDR":
                case "印尼盾": ct = CashType.IDR; break;
                case "64":
                case "064":
                case "VND":
                case "越南盾": ct = CashType.VND; break;
                case "777":
                case "AED":
                case "阿联酋拉姆": ct = CashType.AED; break;
                case "126":
                case "ARS":
                case "阿根廷比索": ct = CashType.ARS; break;
                case "134":
                case "BRL":
                case "雷亚尔": ct = CashType.BRL; break;
                case "53":
                case "053":
                case "EGP":
                case "埃及镑": ct = CashType.EGP; break;
                case "85":
                case "085":
                case "INR":
                case "印度卢比": ct = CashType.INR; break;
                case "57":
                case "057":
                case "JOD":
                case "约旦第纳尔": ct = CashType.JOD; break;
                case "197":
                case "MNT":
                case "蒙古图格里克": ct = CashType.MNT; break;
                case "32":
                case "032":
                case "MYR":
                case "马来西亚林吉特": ct = CashType.MYR; break;
                case "76":
                case "076":
                case "NGN":
                case "尼日利亚奈拉": ct = CashType.NGN; break;
                case "62":
                case "062":
                case "ROL":
                case "罗马尼亚列伊": ct = CashType.ROL; break;
                case "93":
                case "093":
                case "TRY":
                case "土耳其里拉": ct = CashType.TRY; break;
                case "246":
                case "UAH":
                case "乌克兰格里夫纳": ct = CashType.UAH; break;
                case "70":
                case "070":
                case "ZAR":
                case "南非兰特": ct = CashType.ZAR; break;
                case "39":
                case "039":
                case "BWP":
                case "博茨瓦纳普拉": ct = CashType.BWP; break;
                case "101":
                case "KZT":
                case "哈萨克斯坦坚戈": ct = CashType.KZT; break;
                case "80":
                case "080":
                case "ZMK":
                case "赞比亚克瓦查": ct = CashType.ZMK; break;
                case "65":
                case "065":
                case "HUF":
                case "福林": ct = CashType.HUF; break;
                case "72":
                case "072":
                case "XUB":
                case "卢布": ct = CashType.XUB; break;
                case "253":
                case "ZMW":
                case "赞比亚新克瓦查": ct = CashType.ZMW; break;
                case "196":
                case "RUB":
                case "俄罗斯卢布": ct = CashType.RUB; break;
                case "843":
                case "XPT":
                case "白金": ct = CashType.XPT; break;
                case "131":
                case "BND":
                case "文莱币": ct = CashType.BND; break;
                case "166":
                case "KHR":
                case "柬埔寨瑞尔": ct = CashType.KHR; break;
            }
            return ct;
        }

        public static AssumeFeeType GetAssumeFeeType(string data)
        {
            AssumeFeeType aft = AssumeFeeType.Empty;
            switch (data)
            {
                case "0":
                case "SHA":
                case "共同":
                case "共同SHA": aft = AssumeFeeType.SHA; break;
                case "1":
                case "OUR":
                case "汇款人":
                case "汇款人OUR": aft = AssumeFeeType.OUR; break;
                case "2":
                case "BEN":
                case "收款人":
                case "收款人BEN": aft = AssumeFeeType.BEN; break;
            }
            return aft;
        }

        public static PayFeeType GetPayFeeType(string data)
        {
            PayFeeType pft = PayFeeType.Empty;
            switch (data)
            {
                case "1":
                case "A":
                case "预付货款": pft = PayFeeType.A; break;
                case "2":
                case "P":
                case "货到付款": pft = PayFeeType.P; break;
                case "3":
                case "R":
                case "退款": pft = PayFeeType.R; break;
                case "4":
                case "O":
                case "其他": pft = PayFeeType.O; break;
            }
            return pft;
        }

        public static PaymentPropertyType GetPaymentPropertyType(string data)
        {
            PaymentPropertyType ppt = PaymentPropertyType.Empty;
            switch (data)
            {
                case "0":
                case "保税区": ppt = PaymentPropertyType.FreeArea; break;
                case "1":
                case "出口加工区": ppt = PaymentPropertyType.ExportFabricationPlant; break;
                case "2":
                case "钻石交易所": ppt = PaymentPropertyType.DiamondBourse; break;
                case "4":
                case "深加工结转": ppt = PaymentPropertyType.IntensifyCarryForword; break;
                case "6":
                case "其他特殊经济区域": ppt = PaymentPropertyType.OtherSpecialArea; break;
                case "5":
                case "其他": ppt = PaymentPropertyType.Other; break;
            }
            return ppt;
        }

        public static PaymentPropertyType GetPaymentPropertyTypeBar(string data)
        {
            PaymentPropertyType ppt = PaymentPropertyType.Empty;
            switch (data)
            {
                case "1":
                case "保税区": ppt = PaymentPropertyType.FreeArea; break;
                case "2":
                case "出口加工区": ppt = PaymentPropertyType.ExportFabricationPlant; break;
                case "3":
                case "钻石交易所": ppt = PaymentPropertyType.DiamondBourse; break;
                case "4":
                case "深加工结转": ppt = PaymentPropertyType.IntensifyCarryForword; break;
                case "5":
                case "其他特殊经济区域": ppt = PaymentPropertyType.OtherSpecialArea; break;
                case "6":
                case "其他": ppt = PaymentPropertyType.Other; break;
            }
            return ppt;
        }

        public static string GetPaymentPropertyTypeBarValue(PaymentPropertyType data)
        {
            string iv = " ";
            switch (data)
            {
                case PaymentPropertyType.FreeArea: iv = "1"; break;
                case PaymentPropertyType.ExportFabricationPlant: iv = "2"; break;
                case PaymentPropertyType.DiamondBourse: iv = "3"; break;
                case PaymentPropertyType.IntensifyCarryForword: iv = "4"; break;
                case PaymentPropertyType.OtherSpecialArea: iv = "5"; break;
                case PaymentPropertyType.Other: iv = "6"; break;
            }
            return iv;
        }

        public static OverCountryPayeeAccountType GetOverCountryPayeeAccountTypeObject(int data)
        {
            OverCountryPayeeAccountType ocpat = OverCountryPayeeAccountType.Empty;
            int index = PrequisiteDataProvideNode.InitialProvide.OverCountryPayeeAccountTypeList.FindIndex(o => (int)o == data);
            if (index >= 0)
                ocpat = PrequisiteDataProvideNode.InitialProvide.OverCountryPayeeAccountTypeList[index];
            return ocpat;
        }

        public static InterestFloatType GetInterestFloatType(string data)
        {
            InterestFloatType ift = InterestFloatType.Empty;
            switch (data)
            {
                case "1":
                case "上浮": ift = InterestFloatType.Up; break;
                case "2":
                case "下浮": ift = InterestFloatType.Down; break;
                case "3":
                case "不浮动": ift = InterestFloatType.No; break;
            }
            return ift;
        }

        public static SettlementType GetSettlementType(string data)
        {
            SettlementType st = SettlementType.Empty;
            switch (data)
            {
                case "1":
                case "货到付款": st = SettlementType.PayAfter; break;
                case "2":
                case "款到发货": st = SettlementType.PayFirst; break;
                case "3":
                case "赊账": st = SettlementType.PayNo; break;
            }
            return st;
        }

        public static ProtocolMoneyType GetProtocolMoneyType(string data)
        {
            ProtocolMoneyType pmt = ProtocolMoneyType.Empty;
            switch (data)
            {
                case "1":
                case "协议付息": pmt = ProtocolMoneyType.NegotiatedInterestPayment; break;
                case "2":
                case "贴现申请人付息": pmt = ProtocolMoneyType.ByDiscountApplicant; break;
            }
            return pmt;
        }

        public static RelatePersonType GetRelatePersonType(string data)
        {
            RelatePersonType rpt = RelatePersonType.Empty;
            if (Regex.IsMatch(data, @"\d{1,3}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
            {
                rpt = (RelatePersonType)int.Parse(data);
            }
            else
            {
                if (!string.IsNullOrEmpty(data))
                {
                    string[] strlist = data.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in strlist)
                    {
                        switch (item)
                        {
                            case "承兑人": rpt = rpt | RelatePersonType.Exchange; break;
                            case "收款人": rpt = rpt | RelatePersonType.Payee; break;
                            case "保证人": rpt = rpt | RelatePersonType.Guarantor; break;
                            case "质权人": rpt = rpt | RelatePersonType.QRigth; break;
                            case "贴入人": rpt = rpt | RelatePersonType.StickOn; break;
                            case "被背书人": rpt = rpt | RelatePersonType.BackNoted; break;
                            case "被追索人": rpt = rpt | RelatePersonType.Recoursed; break;
                            case "看票人": rpt = rpt | RelatePersonType.ViewElecTicket; break;
                            case "出票人": rpt = rpt | RelatePersonType.Remittor; break;
                        }
                    }
                }
            }
            return rpt;
        }

        public static UnitivePaymentType GetUnitivePaymentType(string data)
        {
            UnitivePaymentType pmt = UnitivePaymentType.Empty;
            switch (data)
            {
                case "0":
                case "实时": pmt = UnitivePaymentType.ActualTime; break;
                case "1":
                case "预约": pmt = UnitivePaymentType.Order; break;
            }
            return pmt;
        }

        public static BarBusinessType GetBarBusinessType(string data)
        {
            BarBusinessType bbt = BarBusinessType.Empty;
            try
            {
                bbt = (BarBusinessType)int.Parse(data);
                EnumNameHelper<BarBusinessType>.GetEnumDescription(bbt);
            }
            catch { bbt = BarBusinessType.Empty; }
            switch (data)
            {
                case "01":
                case "支付运保费": bbt = BarBusinessType.BBT01; break;
                case "02":
                case "代理进出口": bbt = BarBusinessType.BBT02; break;
                case "03":
                case "与特殊经济区企业资金往来": bbt = BarBusinessType.BBT03; break;
                case "04":
                case "同一企业不同账户资金划转": bbt = BarBusinessType.BBT04; break;
                case "05":
                case "归还国内外贷款或转贷款": bbt = BarBusinessType.BBT05; break;
                case "06":
                case "贸易深加工结转业务": bbt = BarBusinessType.BBT06; break;
                case "07":
                case "贸易融资业务": bbt = BarBusinessType.BBT07; break;
                case "08":
                case "其它": bbt = BarBusinessType.BBT08; break;
            }
            return bbt;
        }

        public static BarApplyFlagType GetBarApplyFlagType(string data)
        {
            BarApplyFlagType baft = BarApplyFlagType.Empty;
            switch (data)
            {
                case "N":
                case "不申报": baft = BarApplyFlagType.N; break;
                case "E":
                case "境内汇款": baft = BarApplyFlagType.E; break;
            }
            return baft;
        }

        public static Transfer2CountryType GetTransfer2CountryType(string data)
        {
            Transfer2CountryType item = Transfer2CountryType.Empty;
            switch (data)
            {
                case "AU":
                case "澳洲": item = Transfer2CountryType.AU; break;
                case "BR":
                case "巴西": item = Transfer2CountryType.BR; break;
                case "CA":
                case "加拿大": item = Transfer2CountryType.CA; break;
                case "EU":
                case "欧洲": item = Transfer2CountryType.EU; break;
                case "GB":
                case "英国": item = Transfer2CountryType.GB; break;
                case "HK":
                case "香港": item = Transfer2CountryType.HK; break;
                case "IN":
                case "印度": item = Transfer2CountryType.IN; break;
                case "JP":
                case "日本": item = Transfer2CountryType.JP; break;
                case "KR":
                case "韩国": item = Transfer2CountryType.KR; break;
                case "MO":
                case "澳门": item = Transfer2CountryType.MO; break;
                case "NZ":
                case "新西兰": item = Transfer2CountryType.NZ; break;
                case "SG":
                case "新加坡": item = Transfer2CountryType.SG; break;
                case "TW":
                case "台湾": item = Transfer2CountryType.TW; break;
                case "US":
                case "美国": item = Transfer2CountryType.US; break;
                case "ZZ":
                case "其他地区": item = Transfer2CountryType.ZZ; break;
            }
            return item;
        }

        public static IsImportCancelAfterVerificationType GetIsImportCancelAfterVerificationType(string data)
        {
            IsImportCancelAfterVerificationType item = IsImportCancelAfterVerificationType.Empty;
            switch (data)
            {
                case "Y":
                case "是":
                    item = IsImportCancelAfterVerificationType.Y; break;
                case "N":
                case "否":
                    item = IsImportCancelAfterVerificationType.N; break;
            }
            return item;
        }

        public static UnitiveFCPayeeAccountType GetUnitiveFCPayeeAccountType(string data)
        {
            UnitiveFCPayeeAccountType item = UnitiveFCPayeeAccountType.Empty;
            switch (data)
            {
                case "A":
                case "普通账号": item = UnitiveFCPayeeAccountType.A; break;
                case "B":
                case "IBAN账号": item = UnitiveFCPayeeAccountType.B; break;
            }
            return item;
        }

        public static ChinaProvinceType GetProvinceFOpenBankName(string data)
        {
            ChinaProvinceType item = ChinaProvinceType.B0;
            Types.CNAP c = SysCoach.SystemSettings.City2ProvinceBar.Find(o => data.Contains(o.Name));
            if (c != null) item = GetProvince(c.Code);
            return item;
        }

        public static ChinaProvinceType GetProvinceFOpenBankNameEx(string data)
        {
            ChinaProvinceType item = ChinaProvinceType.B0;
            List<Types.CNAP> c = SysCoach.SystemSettings.City2ProvinceBar.FindAll(o => data.Contains(RemoveAreaExName(o.Name)));
            if (c != null)
            {
                if (c.Count == 1) item = GetProvince(c[0].Code);
                else
                {
                    List<int> list = new List<int>();
                    foreach (var t in c)
                        list.Add(data.IndexOf(RemoveAreaExName(t.Name)));
                    int index = 0;
                    for (int i = 1; i < list.Count; i++)
                        if (list[index] > list[i]) index = i;
                    item = GetProvince(c[index].Code);
                }
            }
            return item;
        }

        static string RemoveAreaExName(string data)
        {
            string result = data;
            List<string> list = new List<string> { "省", "市", "自治区", "自治县", "自治州", "县", "区", "镇", "地区" };
            int index = list.FindIndex(o => data.Contains(o));
            if (index >= 0) result = data.Replace(list[index], string.Empty);
            if (result.Length == 1) result = data;
            return result;
        }
    }
}
