using System;
using System.Collections.Generic;
using System.Text;

namespace BOC_BATCH_TOOL.ConvertHelper
{
    public class RegexHelper
    {
        #region 单例
        private static object Lock_obj = new object();
        private static RegexHelper m_instance;
        //单例
        public static RegexHelper Instance
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
                                m_instance = new RegexHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        public string Regex1 { get { return @"^([0-9]{1,16}[\,|\-]{1})*[0-9]{1,16}$"; } }//"^(\d{1,16}[\,|\-]{1})*\d{1,16}$"
        public string Regex1_Name { get { return "1-10,4,90-100"; } }
        public string Regex1_Tip { get { return GetMessage(20001); } }

        public string Regex2 { get { return @"^((?!.{4}CN.*)[A-Z0-9]{8})$|^((?!.{4}CN.*)[A-Z0-9]{11})$"; } }
        public string Regex2_Name { get { return "8位或11位半角英文大写，半角数字，5、6位不为CN"; } }
        public string Regex2_Tip { get { return GetMessage(20002); } }

        public string Regex3 { get { return @"^([0-9a-zA-Z]{1,16}[\,|\-]{1})*[0-9a-zA-Z]{1,16}$"; } }
        public string Regex3_Name { get { return "A1-B10，C4,D90-D100"; } }
        public string Regex3_Tip { get { return GetMessage(20003); } }

        //public string Regex4 { get { return @"^[0-9\u2E80-\u9FFF_]*$"; } }
        //public string Regex4_Name { get { return "半角数字，中文，特殊字符_"; } }
        //public string Regex4_Tip { get { return GetMessage(20004); } }

        public string Regex5 { get { return @"^[0-9()\-+ ]*$"; } }
        public string Regex5_Name { get { return "半角数字，特殊字符()-+空格"; } }
        public string Regex5_Tip { get { return GetMessage(20005); } }

        public string Regex6 { get { return @"^[A-Za-z]*$"; } }
        public string Regex6_Name { get { return "半角英文"; } }
        public string Regex6_Tip { get { return GetMessage(20006); } }

        public string Regex7 { get { return @"^[A-Za-z0-9().,\[\]'?\s\-+]*$"; } }
        public string Regex7_Name { get { return "半角英文，半角标点"; } }
        public string Regex7_Tip { get { return GetMessage(20006); } }

        public string Regex8 { get { return @"^[0-9A-Za-z]*$"; } }
        public string Regex8_Name { get { return "半角英文，半角数字"; } }
        public string Regex8_Tip { get { return GetMessage(20008); } }

        public string Regex9 { get { return @"^[a-zA-Z0-9-]*$"; } }
        public string Regex9_Name { get { return "半角英文，半角数字，特殊字符-"; } }
        public string Regex9_Tip { get { return GetMessage(20008); } }

        public string Regex10 { get { return @"^[A-Za-z0-9. ]+$"; } }
        public string Regex10_Name { get { return "半角英文，半角数字，特殊字符.空格"; } }
        public string Regex10_Tip { get { return GetMessage(20010); } }

        public string Regex11 { get { return @"^[A-Za-z0-9\/\[\]+]*$"; } }
        public string Regex11_Name { get { return "半角英文，半角数字，特殊字符/[]+"; } }
        public string Regex11_Tip { get { return GetMessage(20011); } }

        public string Regex12 { get { return @"^[a-zA-Z]+[0-9]+([_,]*)$"; } }
        public string Regex12_Name { get { return "半角英文，半角数字，特殊字符_，半角标点，必有半角英文，半角数字"; } }
        public string Regex12_Tip { get { return GetMessage(20012); } }

        public string Regex13 { get { return @"(?=.*[a-zA-Z])^[0-9a-zA-Z_]*$"; } }
        public string Regex13_Name { get { return "半角英文，半角数字，特殊字符_，必有半角英文"; } }
        public string Regex13_Tip { get { return GetMessage(20013); } }

        public string Regex14 { get { return @"^[A-Za-z0-9\/\-\[\]+.,?()']*$"; } }
        public string Regex14_Name { get { return "半角英文，半角数字，特殊字符/-[]+.,?()'"; } }
        public string Regex14_Tip { get { return GetMessage(20014); } }

        public string Regex15 { get { return @"^[A-Za-z0-9\/\-+?().,' ]+$"; } }
        public string Regex15_Name { get { return "半角英文，半角数字，特殊字符/-+?().,'"; } }
        public string Regex15_Tip { get { return GetMessage(20015); } }

        public string Regex16 { get { return @"^[a-zA-Z0-9\s]*$"; } }
        public string Regex16_Name { get { return "半角英文，半角数字，空白字符"; } }
        public string Regex16_Tip { get { return GetMessage(20016); } }

        public string Regex17 { get { return @"^[a-zA-Z0-9 ]*$"; } }
        public string Regex17_Name { get { return "半角英文，半角数字，空格"; } }
        public string Regex17_Tip { get { return GetMessage(20017); } }

        public string Regex18 { get { return @"^[A-Za-z0-9\s\-]+$"; } }
        public string Regex18_Name { get { return "半角英文，半角数字，特殊字符-空格"; } }
        public string Regex18_Tip { get { return GetMessage(20018); } }

        public string Regex19 { get { return @"^[A-Za-z0-9\s\/\[\]+]{1,140}$"; } }
        public string Regex19_Name { get { return "半角英文，半角数字，特殊字符/[]+空格"; } }
        public string Regex19_Tip { get { return GetMessage(20019); } }

        public string Regex20 { get { return @"^[a-zA-Z0-9\u4E00-\u9FFF]*$"; } }
        public string Regex20_Name { get { return "半角英文，半角数字，中文"; } }
        public string Regex20_Tip { get { return GetMessage(20020); } }

        public string Regex21 { get { return @"^[a-zA-Z0-9\u2E80-\u9FFF\-\(\)]*$"; } }
        public string Regex21_Name { get { return "半角英文，半角数字，中文，特殊字符()-"; } }
        public string Regex21_Tip { get { return GetMessage(20021); } }

        public string Regex22 { get { return @"^[0-9A-Za-z,.() \u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex22_Name { get { return "半角英文，半角数字，中文，特殊字符,.()"; } }
        public string Regex22_Tip { get { return GetMessage(20022); } }

        public string Regex23 { get { return @"^[a-zA-Z0-9\u2E80-\u9FFF',\.\-\/\(\)]*$"; } }
        public string Regex23_Name { get { return "半角英文，半角数字，中文，特殊字符',.-/()"; } }
        public string Regex23_Tip { get { return GetMessage(20023); } }

        public string Regex24 { get { return @"^[A-Z0-9]*$"; } }
        public string Regex24_Name { get { return "半角英文大写，半角数字"; } }
        public string Regex24_Tip { get { return GetMessage(20024); } }

        public string Regex25 { get { return @"^[^\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex25_Name { get { return "非半角"; } }
        public string Regex25_Tip { get { return GetMessage(20025); } }

        public string Regex26 { get { return "^[^0-9\\[\\]\\^\\$\\~\\@\\#\\%\\&\\<\\>\\{\\}\'\"]+$"; } }
        public string Regex26_Name { get { return "非半角数字，非全角，非特殊字符[]^$~@#%&<>{}'\""; } }
        public string Regex26_Tip { get { return GetMessage(20026); } }

        public string Regex27 { get { return "^[^\uFF00-\uFFFF]*$"; } }
        public string Regex27_Name { get { return "非全角"; } }
        public string Regex27_Tip { get { return GetMessage(20027); } }

        public string Regex43 { get { return @"^(?!^[0](\.{1}[0]{1,2}){0,1}$)(?:[1-9]{1}[0-9]{0,12}|[0]{1})(\.{1}[0-9]{1,2}){0,1}$"; } }
        public string Regex43_Name { get { return "金额最长13位整数，2位小数可选"; } }
        public string Regex43_Tip { get { return GetMessage(20043); } }

        public string Regex45 { get { return @"^[1-9][0-9]{0,14}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$"; } }//"^[1-9]\d{0,14}\.\d{2}$|^0\.(\d[1-9])$|^0\.([1-9]\d)$"
        public string Regex45_Name { get { return "金额最长13位整数，2位小数可选"; } }
        public string Regex45_Tip { get { return GetMessage(20045); } }

        public string Regex54 { get { return @"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$"; } }
        public string Regex54_Name { get { return "12或24小时到时分"; } }
        public string Regex54_Tip { get { return GetMessage(20054); } }

        public string Regex55 { get { return @"^([1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}[0-9Xx]{1}|[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)$"; } }//"^([1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}[0-9Xx]{1}|[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)$"
        public string Regex55_Name { get { return "身份证（15,18位）"; } }
        public string Regex55_Tip { get { return GetMessage(20055); } }

        public string Regex57 { get { return @"^[0-9]*$"; } }
        public string Regex57_Name { get { return "数字0-9"; } }
        public string Regex57_Tip { get { return GetMessage(20057); } }

        public string Regex61 { get { return @"^[0-9\(\)\-]*$"; } }
        public string Regex61_Name { get { return "电话（0-9（）-组合）"; } }
        public string Regex61_Tip { get { return GetMessage(20061); } }

        public string Regex62 { get { return @"^[0-9 \-\(\)]*$"; } }
        public string Regex62_Name { get { return "电话（0-9空格（）-组合）"; } }
        public string Regex62_Tip { get { return GetMessage(20062); } }

        public string Regex63 { get { return @"^[a-zA-Z0-9\/+\-?()\s.,']*$"; } }
        public string Regex63_Name { get { return "半角英文，半角数字，特殊字符/-+?().,'空白字符"; } }
        public string Regex63_Tip { get { return GetMessage(20063); } }

        public string Regex65 { get { return @"^[\.a-zA-Z\s,0-9]*$"; } }
        public string Regex65_Name { get { return "半角英文，半角数字，特殊字符.空白字符"; } }
        public string Regex65_Tip { get { return GetMessage(20065); } }

        public string Regex66 { get { return @"^[0-9a-zA-Z]*[a-zA-Z]+[0-9a-zA-Z]*$"; } }
        public string Regex66_Name { get { return "半角英文，半角数字，必含英文"; } }
        public string Regex66_Tip { get { return GetMessage(20066); } }

        public string Regex69 { get { return @"[A-Za-z]"; } }
        public string Regex69_Name { get { return "必须包含一个半角英文字母"; } }
        public string Regex69_Tip { get { return GetMessage(20069); } }

        public string Regex70 { get { return @"\d"; } }
        public string Regex70_Name { get { return "必须包含一个数字"; } }
        public string Regex70_Tip { get { return GetMessage(20070); } }

        public string Regex74 { get { return @"^[a-zA-Z0-9\u2E80-\u9FFF_]*$"; } }
        public string Regex74_Name { get { return "半角英文，半角数字，中文，特殊字符_"; } }
        public string Regex74_Tip { get { return GetMessage(20074); } }

        public string Regex79 { get { return @"^[0-9 ]+$"; } }
        public string Regex79_Name { get { return "半角数字和空格"; } }
        public string Regex79_Tip { get { return GetMessage(20079); } }

        public string Regex87 { get { return @"^[1-9]\d{0,11}(\.\d{1,2})?$|^0\.[1-9](\d)?$|^0\.\d[1-9]$"; } }
        public string Regex87_Name { get { return "金额最长12位整数+2位小数可选"; } }
        public string Regex87_Tip { get { return GetMessage(20087); } }

        public string Regex89 { get { return @"^[0-9\u2E80-\u9FFF ]*$"; } }
        public string Regex89_Name { get { return "半角数字，中文，特殊字符空格"; } }
        public string Regex89_Tip { get { return GetMessage(20089); } }

        public string Regex92 { get { return @"^[A-Z0-9\/ ]*$"; } }
        public string Regex92_Name { get { return "半角英文大写，半角数字，空格/"; } }
        public string Regex92_Tip { get { return GetMessage(20092); } }

        public string Regex98 { get { return @"^[0-9\u2E80-\u9FFF ]*$"; } }
        public string Regex98_Name { get { return "半角英文，半角数字，特殊字符-_ "; } }
        public string Regex98_Tip { get { return GetMessage(20098); } }

        public string Regex106 { get { return @"^[A-Za-z0-9]{1,16}(-[A-Za-z0-9]{1,16})?(,[A-Za-z0-9]{1,16}(-[A-Za-z0-9]{1,16})?)*$"; } }
        public string Regex106_Name { get { return "半角英文或半角数字+特殊字符，或-，+半角英文或半角数字（形如1-a或1,a）"; } }
        public string Regex106_Tip { get { return GetMessage(20106); } }

        public string Regex108 { get { return @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex108_Name { get { return "半角英文，半角数字，中文，特殊字符,;!?-./"; } }
        public string Regex108_Tip { get { return GetMessage(20108); } }

        public string Regex110 { get { return @"^\S+@\S+$ "; } }
        public string Regex110_Name { get { return "邮件（企业只校验@不校验 . 和com）"; } }
        public string Regex110_Tip { get { return GetMessage(20110); } }

        public string Regex115 { get { return @"^[a-zA-Z0-9\u2E80-\u9FFF ]*$"; } }
        public string Regex115_Name { get { return "半角英文，半角数字，中文，特殊字符空格"; } }
        public string Regex115_Tip { get { return GetMessage(20115); } }

        public string Regex117 { get { return @"^[-_0-9A-HJ-NP-Za-hj-np-z]*$"; } }
        public string Regex117_Name { get { return "半角英文，半角数字，特殊字符-_，非oOiI"; } }
        public string Regex117_Tip { get { return GetMessage(20117); } }

        public string Regex128 { get { return @"^[a-zA-Zａ-ｚＡ-Ｚ,]*$"; } }
        public string Regex128_Name { get { return "半角全角英文，半角英文逗号"; } }
        public string Regex128_Tip { get { return GetMessage(20128); } }

        public string Regex130 { get { return @"^[A-Z0-9\(\)\+\'\,\.\?\/ ]*$"; } }
        public string Regex130_Name { get { return "半角英文大写，半角数字，特殊字符()+',.?/空格"; } }
        public string Regex130_Tip { get { return GetMessage(20130); } }

        public string Regex135 { get { return @"^[a-zA-Z,]*$"; } }
        public string Regex135_Name { get { return "半角英文，半角英文逗号"; } }
        public string Regex135_Tip { get { return GetMessage(20135); } }

        public string Regex164 { get { return "^[a-zA-Z0-9\u4E00-\u9FFF',\\.\\-\\/\\(\\)’‘，。、（）?!\":;？！“”：； ]*$"; } }
        public string Regex164_Name { get { return "半角英文，半角数字，中文，特殊字符',.-/()’‘，。、（）和空格"; } }
        public string Regex164_Tip { get { return GetMessage(20164); } }

        public string Regex166 { get { return @"^[0-9a-zA-Z\u2E80-\u9FFF\.\-]*[a-zA-Z\u2E80-\u9FFF\.\-]+[0-9a-zA-Z\u2E80-\u9FFF\.\-]*$"; } }
        public string Regex166_Name { get { return "半角英文，半角数字，中文，特殊字符',.-/()"; } }
        public string Regex166_Tip { get { return GetMessage(20166); } }

        public string Regex167 { get { return @"^[a-zA-Z0-9\u2E80-\u9FFF\(\)]*$"; } }
        public string Regex167_Name { get { return "半角英文，半角数字，中文，特殊字符()"; } }
        public string Regex167_Tip { get { return GetMessage(20167); } }

        public string Regex168 { get { return @"^[A-Z0-9\(\)\+:',.\/\? ]*$"; } }
        public string Regex168_Name { get { return "半角英文大写，半角数字，特殊字符()+-:',./?空格"; } }
        public string Regex168_Tip { get { return GetMessage(20168); } }

        public string Regex500 { get { return @"^[!-~]*$"; } }
        public string Regex500_Name { get { return "userIdStyle"; } }
        public string Regex500_Tip { get { return GetMessage(20500); } }

        public string Regex501 { get { return @"^(([0-1]{1}[0-9]{1})|([2]{1}[0-3]{1}))$"; } }
        public string Regex501_Name { get { return "hourDigitStyle"; } }
        public string Regex501_Tip { get { return GetMessage(20501); } }

        public string Regex502 { get { return Regex500; } }
        public string Regex502_Name { get { return "passStyle"; } }
        public string Regex502_Tip { get { return GetMessage(20502); } }

        //public string Regex503 { get { return @"^([0-9A-Za-z+\/=]{28,44})|(.{1,20})$"; } }
        //public string Regex503_Name { get { return "passwordStyle"; } }
        //public string Regex503_Tip { get { return GetMessage(20503); } }

        //public string Regex504 { get { return "^[0-9]{6}$"; } }
        //public string Regex504_Name { get { return "otpStyle"; } }
        //public string Regex504_Tip { get { return GetMessage(20504); } }

        //public string Regex505 { get { return Regex504; } }
        //public string Regex505_Name { get { return "smcStyle"; } }
        //public string Regex505_Tip { get { return GetMessage(20504); } }

        public string Regex516 { get { return @"^(?!^[0](\.{1}[0]{1,2}){0,1}$)(?:[1-9]{1}[0-9]{0,12}|[0]{1})(\.{1}[0-9]{1,2}){0,1}$"; } }
        public string Regex516_Name { get { return "money15d2Style"; } }
        public string Regex516_Tip { get { return GetMessage(20516); } }

        public string Regex539 { get { return @"^\S+@\S+$"; } }
        public string Regex539_Name { get { return "emailStyle"; } }
        public string Regex539_Tip { get { return GetMessage(20539); } }

        public string Regex540 { get { return @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex540_Name { get { return "annuityAddress100Style"; } }
        public string Regex540_Tip { get { return GetMessage(20540); } }

        public string Regex585 { get { return @"^[ A-Za-z0-9',.()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex585_Name { get { return "bankNameStyle"; } }
        public string Regex585_Tip { get { return GetMessage(29104); } }

        public string Regex579 { get { return @"^([0-9]{15}|[0-9]{18}|[0-9]{17}[X|x])$"; } }//"^(\d{15}|\d{18}|\d{17}[X|x])$"
        public string Regex579_Name { get { return "idStyle1"; } }
        public string Regex579_Tip { get { return GetMessage(20579); } }

        public string Regex600 { get { return @"^[A-Z0-9]{8}([A-Z0-9]{3})?$"; } }
        public string Regex600_Name { get { return "swiftStyle"; } }
        public string Regex600_Tip { get { return GetMessage(20600); } }

        public string Regex612 { get { return @"^[0-9]+([ \-][0-9]+)*$"; } }//@"^\d+([ \-]\d+)*$"
        public string Regex612_Name { get { return "faxStyle"; } }
        public string Regex612_Tip { get { return GetMessage(20612); } }

        public string Regex629 { get { return @"^[A-Za-z0-9',.\-\/()]*$"; } }
        public string Regex629_Name { get { return "accountStyle"; } }
        public string Regex629_Tip { get { return GetMessage(20629); } }

        public string Regex630 { get { return @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex630_Name { get { return "person120Style"; } }
        public string Regex630_Tip { get { return GetMessage(20630); } }

        public string Regex634 { get { return Regex630; } }
        public string Regex634_Name { get { return "annuityPlanNoStyle"; } }
        public string Regex634_Tip { get { return GetMessage(20630); } }

        //public string Regex637 { get { return @"^(?!^0*(\.0{1,2})?$)^[0-9]{1,16}(\.[0-9]{1,2})?$"; } }//"^(?!^0*(\.0{1,2})?$)^\d{1,16}(\.\d{1,2})?$"
        //public string Regex637_Name { get { return "zMoney18d2toStringStyle"; } }
        //public string Regex637_Tip { get { return GetMessage(20637); } }

        public string Regex641 { get { return @"^[ A-Za-z0-9,;!\?\-\.\/\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex641_Name { get { return "furinfoStyle"; } }
        public string Regex641_Tip { get { return GetMessage(20641); } }

        public string Regex646 { get { return "^[^{}\\[\\]\\%\\'\"\u0000-\u001F]*$"; } }
        public string Regex646_Name { get { return "furinfoStyle"; } }
        public string Regex646_Tip { get { return GetMessage(20646); } }

        public string Regex648 { get { return "^[^oOiI{}\\[\\]%'\"`~$^_|\\\\:\u0000-\u001F\u0080-\u00FF]*$"; } }
        public string Regex648_Name { get { return "QueryAccountNoStyle32"; } }
        public string Regex648_Tip { get { return GetMessage(20648); } }

        public string Regex661 { get { return "^[ A-Za-z0-9',.()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex661_Name { get { return "ASPbankNameStyle"; } }
        public string Regex661_Tip { get { return GetMessage(20661); } }

        public string Regex662 { get { return "^[^{}\\[\\]%'\"`~$^_|\\\\:\u0000-\u001F\u0080-\u00FF]*$"; } }
        public string Regex662_Name { get { return "toActNameStyle"; } }
        public string Regex662_Tip { get { return GetMessage(20662); } }

        public string Regex666 { get { return @"^[0-9A-Za-z*\/_-]{0,60}$"; } }
        public string Regex666_Name { get { return "agreementNoStyle"; } }
        public string Regex666_Tip { get { return GetMessage(20666); } }

        public string Regex667 { get { return @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex667_Name { get { return "chinese1to120Style"; } }
        public string Regex667_Tip { get { return GetMessage(20667); } }

        public string Regex685 { get { return "^[^{}\\[\\]%'\"`~$^_|\\\\:\u0000-\u001F]*$"; } }
        public string Regex685_Name { get { return "payeeAccountNameNewStyle"; } }
        public string Regex685_Tip { get { return GetMessage(20685); } }

        public string Regex686 { get { return @"^[ A-Za-z0-9',.\-\/()\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex686_Name { get { return "entAddressStyle"; } }
        public string Regex686_Tip { get { return GetMessage(20686); } }

        public string Regex687 { get { return @"^[-_0-9A-HJ-NP-Za-hj-np-z]*$"; } }
        public string Regex687_Name { get { return "payeeAccountNumStyleForGcms"; } }
        public string Regex687_Tip { get { return GetMessage(20687); } }

        public string Regex688 { get { return "^[^oOiI{}\\[\\]%'\"`~$^|\\\\:\u0000-\u001F\u0080-\u00FF]*$"; } }
        public string Regex688_Name { get { return "payeeAccountNum32Style"; } }
        public string Regex688_Tip { get { return GetMessage(20688); } }

        public string Regex690 { get { return @"^[0-9]*$"; } }//"^\d*$"
        public string Regex690_Name { get { return "mobilePhoneStyle"; } }
        public string Regex690_Tip { get { return GetMessage(20690); } }

        public string Regex697 { get { return @"^[A-Za-z0-9]*$"; } }
        public string Regex697_Name { get { return "cusseqStyle"; } }
        public string Regex697_Tip { get { return GetMessage(20697); } }

        public string Regex699 { get { return @"^[A-Za-z0-9',.\-\/()+{}:]*$"; } }
        public string Regex699_Name { get { return "PayerPhone"; } }
        public string Regex699_Tip { get { return GetMessage(20699); } }

        public string Regex702 { get { return @"^[ A-Za-z0-9-(){}:.,'\s\?\+\/]*$"; } }
        public string Regex702_Name { get { return "cbrnameStyle"; } }
        public string Regex702_Tip { get { return GetMessage(20702); } }

        public string Regex705 { get { return @"^[ A-Z0-9-(){}:.,'\s\?\+\/]*$"; } }
        public string Regex705_Name { get { return "cbrnameStyle"; } }
        public string Regex705_Tip { get { return GetMessage(20705); } }

        public string Regex714 { get { return @"^[1-9][0-9]{0,3}$"; } }
        public string Regex714_Name { get { return "SDFApplyDays"; } }
        public string Regex714_Tip { get { return GetMessage(20714); } }

        public string Regex717 { get { return "^[^{}\x26\x3c\\[\\]%'@#\\>\"~$^\\\\:\u0000-\u001F\u0080-\u00FF]*$"; } }
        public string Regex717_Name { get { return "specCharacterStyle"; } }
        public string Regex717_Tip { get { return GetMessage(20717); } }

        public string Regex718 { get { return "^[ A-Za-z0-9\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex718_Name { get { return "custbCodeStyle"; } }
        public string Regex718_Tip { get { return GetMessage(20718); } }

        public string Regex719 { get { return @"^[1-9][0-9]{0,12}$"; } }//"^[1-9]\d{0,12}$"
        public string Regex719_Name { get { return "金额最长13位整数"; } }
        public string Regex719_Tip { get { return GetMessage(20719); } }

        public string Regex720Ex { get { return "^[^`~@#$%^\\<\\>\\[\\]{}\"|\\\\:'\u003C\u003E\u0026\u4E00-\u9FBB\u3400-\u4DBF\uF900-\uFAD9\u3000-\u303F\u2000-\u206F\uFF00-\uFFEF]*$"; } }
        public string Regex720_Name { get { return "InvoiceNOStyle"; } }
        public string Regex720Ex_Tip { get { return GetMessage(20720); } }

        public string Regex721 { get { return "^[^{}\\[\\]%'\"`~$^_|\\\\:\u0000-\u001F\u0080-\u00FF]*$"; } }
        public string Regex721_Name { get { return "buyerOrSellerNameStyle"; } }
        public string Regex721_Tip { get { return GetMessage(20721); } }

        public string Regex766 { get { return @"^[ A-Za-z0-9-_(){}:.,'\s\?/+\\/]*$"; } }
        public string Regex766_Name { get { return "payeeAccountNum35Style"; } }
        public string Regex766_Tip { get { return GetMessage(20766); } }

        public string Regex9102 { get { return @"^[A-Z0-9a-z]{0,16}$"; } }
        public string Regex9102_Name { get { return "16位数字"; } }
        public string Regex9102_Tip { get { return GetMessage(29102); } }

        public string Regex9103 { get { return @"^(([1-9][\d]{0,4})|0).[0-9]{6}$"; } }//"^(([1-9][\d]{0,4})|0).\d{6}$"
        public string Regex9103_Name { get { return "12位数字,包括小数点和6位小数"; } }
        public string Regex9104_Tip { get { return GetMessage(29103); } }

        private string GetMessage(int code)
        {
            string result = string.Empty;
            //判断多语言
            try { result = BOC_BATCH_TOOL.Utilities.EnumNameHelper<MultiLanguageDataHelper>.GetEnumDescription((MultiLanguageDataHelper)code); }
            catch { }
            return result;
        }
    }

    class RegexStringHelper
    { }
}
