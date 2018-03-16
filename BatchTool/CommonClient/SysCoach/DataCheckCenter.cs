using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using System.IO;
using CommonClient.ConvertHelper;
using System.Windows.Forms;
using CommonClient.Controls;

namespace CommonClient.SysCoach
{
    public static class DataCheckCenter
    {
        /// <summary>
        /// 校验客户业务编号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCustomerReferenceNo(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            string description = MultiLanguageConvertHelper.Transfer_Mappings_CustomerRef;
            return CheckData(ctl, data, description, string.Format("{0}最多允许输入16位字符", description), string.Empty, 0, 16, false, false, errorProvider);
        }

        /// <summary>
        /// 校验客户自定义编号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCustomerRefNo(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            string description = MultiLanguageConvertHelper.ElecTicketPool_CustomerRef;
            return CheckData(ctl, data, description, string.Format("{0}{1},最多14位", description, RegexHelper.Regex718_Tip), RegexHelper.Regex718, 0, 14, false, false, errorProvider);
        }

        /// <summary>
        /// 校验客户业务编号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCustomerRefNoGJOrUPEx(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            string description = MultiLanguageConvertHelper.Transfer_Mappings_CustomerRef;
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最多16位", description, RegexHelper.Regex8_Tip), RegexHelper.Regex8, 1, 16, false, false, errorProvider);
        }

        /// <summary>
        /// 校验实际付款人地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData ChecktbRemittorAddress(Control ctl, string data, ErrorProviderExt errorProvider, OverCountryPayeeAccountType oct = OverCountryPayeeAccountType.OtherAccount)
        {
            string description = MultiLanguageConvertHelper.UnitivePaymentFC_realPayAddress;
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最多280位", description, oct == OverCountryPayeeAccountType.ForeignAccount ? RegexHelper.Regex702_Tip : RegexHelper.Regex630_Tip), oct == OverCountryPayeeAccountType.ForeignAccount ? RegexHelper.Regex702 : RegexHelper.Regex630, 1, 280, false, false, errorProvider);
        }
        /// <summary>
        /// 校验主动调拨客户业务编号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ResultData CheckCustomerNoInitiativeAllot(Control ctl, string data, string description, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最多16位", description, RegexHelper.Regex8_Tip), RegexHelper.Regex8, 0, 16, false, false, errorProvider);
        }

        /// <summary>
        /// 校验卖方银行客户号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckBankCustomerNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最多{2}位", description, RegexHelper.Regex697_Tip, length), RegexHelper.Regex697, 0, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验客户名称--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCustomerName(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最多允许输入{1}位字符,不能包含[]',^$\\~:;!@?#%&<>'\"", description, length), RegexHelper.Regex721, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验买方客户名称--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCustomerNamePurchase(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最多{2}位", description, RegexHelper.Regex717_Tip, length), RegexHelper.Regex717, 0, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验证件号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCertifyCardNo(Control ctl, string data, string datadescription, ErrorProviderExt errorProvider)
        {
            return CheckCertifyCardNo(ctl, data, datadescription, 25, errorProvider);
        }

        /// <summary>
        /// 校验证件号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCertifyCardNoEx(Control ctl, string data, string datadescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, datadescription, string.Format("{0}{1},{2}", datadescription, RegexHelper.Regex8_Tip, 32), RegexHelper.Regex8, 1, 32, false, false, errorProvider);
        }

        /// <summary>
        /// 校验证件号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCertifyCardNo(Control ctl, string data, string datadescription, bool isCertifyCard, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, datadescription, "身份证号码最多允许输入15位数字或者18位（数字或者最多包含一个x字符）", RegexHelper.Regex579, 15, 18, false, true, errorProvider);
        }

        /// <summary>
        /// 校验证件号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="maxlength"></param>
        /// <returns></returns>
        public static ResultData CheckCertifyCardNo(Control ctl, string data, string datadescription, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, datadescription, string.Format("{0}最多允许输入{1}位字符", datadescription, maxlength), RegexHelper.Regex614, 1, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验金额
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAllCash(double data, int maxlength)
        {
            ResultData rd = new ResultData();
            string[] str = new string[2];
            if (!data.ToString().Contains("."))
            {
                str[0] = data.ToString();
                str[1] = "00";
            }
            else
                str = data.ToString("F2").Split('.');

            if (data < 0 || (str[0].Length > maxlength - 2 || str[1].Length > 2))
            {
                rd.Result = false;
                rd.Message = string.Format("总金额最长{0}位数字，其中包含两位小数", maxlength);
            }
            else rd.Result = true;
            return rd;
        }

        /// <summary>
        /// 校验金额
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAllCash(string data, int maxlength)
        {
            ResultData rd = new ResultData();
            string[] str = new string[2];

            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = "总金额不能为空";
            }
            else
            {
                try
                {
                    rd = CheckAllCash(double.Parse(data), maxlength);
                }
                catch
                {
                    rd.Result = false;
                    rd.Message = string.Format("总金额最长{0}位数字，其中包含两位小数", maxlength);
                }
            }

            return rd;
        }

        /// <summary>
        /// 校验金额
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCash(Control ctl, double data, int maxlength, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            string[] str = new string[2];
            if (!data.ToString().Contains("."))
            {
                str[0] = data.ToString();
                str[1] = "00";
            }
            else
                str = DataConvertHelper.FormatNum(data.ToString()).Split('.');

            if (data < 0 || (str[0].Length > maxlength - 2 || str[1].Length > 2) || data == 0.0d)
            {
                rd.Result = false;
                rd.Message = string.Format("金额最长{0}位数字，其中包含两位小数,且大于0", maxlength);
            }
            else rd.Result = true;
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验金额
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCash(Control ctl, string data, string description, int maxlength, bool isJAP, ErrorProviderExt errorProvider, bool negative = false)
        {
            ResultData rd = new ResultData() { Result = true };
            string[] str = new string[2];

            data = data.Replace(",", "");

            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, description);
            }
            else
            {
                try
                {
                    if (isJAP)
                    {
                        if (!Regex.IsMatch(data, RegexHelper.Regex719, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                            throw new Exception();
                    }
                    //else if (maxlength == 14)
                    //{
                    //    if (!Regex.IsMatch(data, RegexHelper.Regex87, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    //        throw new Exception();
                    //}
                    //else if (maxlength == 15)
                    //{
                    //    if (!Regex.IsMatch(data, RegexHelper.Regex43, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    //        throw new Exception();
                    //}
                    //else if (maxlength == 17)
                    //{
                    //    if (!Regex.IsMatch(data, RegexHelper.Regex45, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    //        throw new Exception();
                    //}
                    //else if (maxlength == 18)
                    //{
                    //    if (!Regex.IsMatch(data, RegexHelper.Regex637, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    //        throw new Exception();
                    //}
                    else
                    {
                        string[] strTemp = new string[2];
                        if (!data.ToString().Contains("."))
                        {
                            strTemp[0] = data;
                            strTemp[1] = "00";
                        }
                        else
                            strTemp = data.Split('.');
                        if ((strTemp[0].Length > maxlength - 2 || strTemp[1].Length > 2) || double.Parse(data) <= 0.0d || double.Parse(data) < 0)
                        {
                            rd.Result = false;
                            rd.Message = string.Format("金额\r\n必输\r\n最长{0}位数字，其中包含两位小数{1}", maxlength, negative ? string.Empty : ",且大于0");
                        }
                    }
                }
                catch
                {
                    rd.Result = false;
                    rd.Message = isJAP ? string.Format("{0}\r\n必输\r\n{1}", description, RegexHelper.Regex719_Tip) : string.Format("{0}\r\n必输\r\n最长{1}位数字,其中包含两位小数{2}", description, maxlength, negative ? string.Empty : ",且大于0");
                }
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                {
                    errorProvider.SetError(ctl, rd.Message);
                    ((IDataValidateEditor)ctl).DvUpdateErrorFrame();
                }
                else
                    errorProvider.SetError(ctl, string.Empty); ;
            }

            return rd;
        }

        /// <summary>
        /// 校验开户行所属省份
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckProvince(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData() { Result = true };

            string matchStr = @"^\d{2}$";
            if (Regex.IsMatch(data.Trim(), matchStr))
            {
                try
                {
                    string str = EnumNameHelper<ChinaProvinceType>.GetEnumDescription((ChinaProvinceType)int.Parse(data));
                    if (string.IsNullOrEmpty(str)) rd = new ResultData { Result = false, Message = "省份标示错误" };
                }
                catch
                {
                    rd.Result = false;
                    rd.Message = "省份标示错误";
                }
            }
            else
            {
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验CNAPS行号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCNAPSNo(Control ctl, string data, ErrorProviderExt errorProvider)
        { return CheckCNAPSNo(ctl, data, MultiLanguageConvertHelper.Transfer_Mappings_CNAPSNo, errorProvider); }

        /// <summary>
        /// 校验CNAPS行号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckCNAPSNo(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}12位数字", dataDescription), @"^\d{12}$", 12, 12, true, true, errorProvider);
        }

        /// <summary>
        /// 校验交易编号码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataDescription"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckDealSerialNo(Control ctl, string data, string dataDescription, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}只允许输入{1}位数字", dataDescription, length), @"^\d{6}$", 6, 6, false, true, errorProvider);
        }

        /// <summary>
        /// 校验付款日期
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayDatetime(Control ctl, DateTime data, string dataDescription, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            if (data.Date < DateTime.Today.Date || data.Date > DateTime.Today.Date.AddMonths(1))
            {
                rd.Result = false;
                rd.Message = string.Format("{0}只能选择未来一个月内的日期", dataDescription);
            }
            else rd.Result = true;
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startdate"></param>
        /// <param name="dataDescription"></param>
        /// <returns></returns>
        public static ResultData CheckEndDatetime(Control ctl, string data, string startdate, string dataDescription, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            try
            {
                DateTime edt = DateTime.Parse(DataConvertHelper.FormatDateTimeFromInt(data));
                DateTime sdt = DateTime.Parse(DataConvertHelper.FormatDateTimeFromInt(startdate));
                if (edt.Date <= sdt.Date || edt.Date > sdt.Date.AddYears(1))
                {
                    rd.Result = false;
                    rd.Message = string.Format("{0}只能选择出票日期后一年内的日期", dataDescription);
                }
                else rd.Result = true;
            }
            catch
            {
                rd.Result = false;
                rd.Message = "日期格式有误";
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验付款日期
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayDatetime(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckPayDatetime(ctl, data, MultiLanguageConvertHelper.Transfer_Mappings_PayDate, errorProvider);
        }

        /// <summary>
        /// 校验付款日期
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayDatetime(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            try
            {
                DateTime dt = DateTime.Parse(DataConvertHelper.FormatDateTimeFromInt(data));
                if (dt.Date < DateTime.Today.Date || dt.Date > DateTime.Today.Date.AddMonths(1))
                {
                    rd.Result = false;
                    rd.Message = string.Format("{0}只能选择未来一个月内的日期", dataDescription);
                }
                else rd.Result = true;
            }
            catch
            {
                rd.Result = false;
                rd.Message = "日期格式有误";
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static ResultData CheckUseType_NormalOut(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = "用途不能为空";
            }
            else
            {
                switch (data)
                {
                    case "工资类":
                    case "其他类":
                    case "0":
                    case "1":
                        rd.Result = true;
                        break;
                    default:
                        rd.Result = false;
                        rd.Message = "用途内容不符";
                        break;
                }
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static ResultData CheckUseType_NormalIn(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = "用途不能为空";
            }
            else
            {
                switch (data)
                {
                    case "代收类":
                    case "0":
                        rd.Result = true;
                        break;
                    default:
                        rd.Result = false;
                        rd.Message = "用途内容不符";
                        break;
                }
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckUseType(Control ctl, string data, bool isNormalOut, ErrorProviderExt errorProvider)
        {
            return isNormalOut ? CheckUseType_NormalOut(ctl, data, errorProvider) : CheckUseType_NormalIn(ctl, data, errorProvider);
        }

        /// <summary>
        /// 校验附言及用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAddtion(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckAddtion(ctl, data, 200, errorProvider);
        }

        /// <summary>
        /// 校验附言及用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAddtion(Control ctl, string data, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckAddtion(ctl, data, MultiLanguageConvertHelper.Transfer_Mappings_Addtion, maxlength, errorProvider);
        }

        /// <summary>
        /// 校验附言及用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAddtion(Control ctl, string data, string description, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最多{2}个字符", description, RegexHelper.Regex667_Tip, maxlength), RegexHelper.Regex667, 0, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验交易附言   --外币统一支付跨境
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAddtionFCForeign(Control ctl, string data, string description, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最多{2}个字符", description, RegexHelper.Regex108_Tip, maxlength), RegexHelper.Regex108, 1, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验附言及用途
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAddtionExIAOrUPOrBR(Control ctl, string data, string description, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},不能超过{2}个字符,", description, RegexHelper.Regex641_Tip, maxlength), RegexHelper.Regex641, 0, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验付款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerAccount(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckPayerAccount(ctl, data, MultiLanguageConvertHelper.Transfer_Mappings_PayerAccount, errorProvider);
        }

        /// <summary>
        /// 校验付款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerAccount(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}格式不符,可12到18位数字", dataDescription), @"^[0-9]{12,18}$", 12, 18, true, false, errorProvider);
        }

        /// <summary>
        /// 校验付款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerAccount(Control ctl, string data, int maxLength, ErrorProviderExt errorProvider)
        {
            return CheckPayerAccount(ctl, data, MultiLanguageConvertHelper.Transfer_Mappings_PayerAccount, maxLength, errorProvider);
        }

        /// <summary>
        /// 校验付款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerAccount(Control ctl, string data, string dataDescription, int maxLength, ErrorProviderExt errorProvider)
        {
            return CheckPayerAccount(ctl, data, dataDescription, maxLength, string.Empty, errorProvider);
        }

        /// <summary>
        /// 校验付款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerAccount(Control ctl, string data, string dataDescription, int maxLength, string matchstr, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}最长{1}位字符", dataDescription, maxLength), matchstr, 1, maxLength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验实际付款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerAccountUP(Control ctl, string data, string dataDescription, int minlength, int maxLength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}{1}-{2}位数字", dataDescription, minlength, maxLength), RegexHelper.Regex57, minlength, maxLength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验账号--主动调拨
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAccountExIA(Control ctl, string data, string dataDescription, int maxLength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}{2},最多{1}位", dataDescription, RegexHelper.Regex646_Tip, maxLength), RegexHelper.Regex646, 1, maxLength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验名义付款人账号--人民币统一支付
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAccountUP(Control ctl, string data, string dataDescription, int maxLength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}{1},最多{2}位", dataDescription, RegexHelper.Regex766_Tip, maxLength), RegexHelper.Regex766, 1, maxLength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验账号户名称--主动调拨
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckNameExIA(Control ctl, string data, string dataDescription, int maxLength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}最多允许输入{1}位,{2}", dataDescription, maxLength, RegexHelper.Regex641_Tip), RegexHelper.Regex641, 0, maxLength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerName(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckPayerName(ctl, data, MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerName, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerName(Control ctl, string data, string description, ErrorProviderExt errorProvider)
        {
            return CheckPayerName(ctl, data, description, 76, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerName(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长{1}位字符", description, length), string.Empty, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验实际付款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayerNameOrBankNameUP(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex661_Tip, length), RegexHelper.Regex661, 1, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAccount(Control ctl, string data, string description, ErrorProviderExt errorProvider)
        {
            return CheckPayeeOrElecTicketPersonAccount(ctl, data, description, 35, errorProvider);
        }

        /// <summary>
        /// 校验收款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeOrElecTicketPersonAccount(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckPayeeAccount(ctl, data, description, length, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAccount(Control ctl, string data, string description, int length, bool isFix, ErrorProviderExt errorProvider)
        {
            string matchstr = isFix ? "^[0-9a-zA-Z*/_-]{" + length + "}$" : "^[0-9a-zA-Z*/_-]{1," + length + "}$";
            return CheckData(ctl, data, description, string.Format("{0}请输入字母数字和“*/_-”,{1}{2}位字符", description, isFix ? string.Empty : "最长", length), matchstr, isFix ? length : 1, length, true, isFix, errorProvider);
        }

        /// <summary>
        /// 校验收款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckElecTicketPersonAccount(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex629_Tip, length), RegexHelper.Regex629, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人账号   --统一支付外币本行
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckElecTicketPersonAccountFC(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex648_Tip, length), RegexHelper.Regex648, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验国际结算-境外收款人账号（修改校验规则后境外收款人信息做统一校验）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAccountGJ(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex705_Tip, length), RegexHelper.Regex705, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验统一支付-收款人账号（修改校验规则后境外收款人信息做统一校验）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAccountUP(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex688_Tip, length), RegexHelper.Regex688, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验国际结算-境内收款人账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAccountGJEx(Control ctl, string data, string description, int length, bool isBOC, ErrorProviderExt errorProvider)
        {
            string matchstr = isBOC ? RegexHelper.Regex687 : RegexHelper.Regex688;
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, isBOC ? RegexHelper.Regex687_Tip : RegexHelper.Regex688_Tip, length), matchstr, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeName(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckPayeeOrElecTicketPersonName(ctl, data, MultiLanguageConvertHelper.Transfer_Mappings_PayeeName, 30, errorProvider);
        }

        /// <summary>
        /// 校验附言--外币统一支付
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAddtion(Control ctl, string data, string description, int length, bool isBOC, ErrorProviderExt errorProvider)
        {
            string matchstr = isBOC ? RegexHelper.Regex108 : RegexHelper.Regex641;
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, isBOC ? RegexHelper.Regex108_Tip : RegexHelper.Regex641_Tip, length), matchstr, 1, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeNameAgentInOrUP(Control ctl, string data, string descriptrion, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, descriptrion, string.Format("{0}{1},最长{2}位", descriptrion, RegexHelper.Regex685_Tip, maxlength), RegexHelper.Regex685, 1, maxlength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeOrElecTicketPersonName(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位字符", description, length), string.Empty, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckElecTicketPersonNameOrBankName(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex667_Tip, length), RegexHelper.Regex667, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验国际结算-收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeNameOrAddressGJ(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex662_Tip, length), RegexHelper.Regex662, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验外币统一支付-名义付款人地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckNominalAddressFC(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex702_Tip, length), RegexHelper.Regex702, 1, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验国际结算-收款人名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeNameOrAddressGJEx(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0} {1},最长{2}位", description, RegexHelper.Regex702_Tip, length), RegexHelper.Regex702, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验国际结算-收款人开户行在其代理行账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAccountInCorrespondentBankGJ(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位字符,{2}", description, length, RegexHelper.Regex648_Tip), RegexHelper.Regex648, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验名称与地址总长度
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="datadesc1"></param>
        /// <param name="datadesc2"></param>
        /// <param name="maxlength"></param>
        /// <returns></returns>
        public static ResultData CheckNameAndAddressLengthGJ(Control ctl, string data1, string data2, string datadesc1, string datadesc2, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data1 + data2, string.Format("{0} {1} ", datadesc1, datadesc2), string.Format(MultiLanguageConvertHelper.DesignMain_Name_And_Address_MaxLength, datadesc1, datadesc2, maxlength), string.Empty, 1, 140, true, false, errorProvider);
        }

        /// <summary>
        /// 校验收款行名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckOpenBankName(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckOpenBankName(ctl, data, "付款行名称", errorProvider);
        }

        /// <summary>
        /// 校验收款行名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckOpenBankName(Control ctl, string data, string description, ErrorProviderExt errorProvider)
        {
            return CheckOpenBankName(ctl, data, description, 70, errorProvider);
        }

        /// <summary>
        /// 校验收款行名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckOpenBankName(Control ctl, string data, string description, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位字符", description, RegexHelper.Regex667_Tip, maxlength), RegexHelper.Regex667, 1, maxlength, true, false, errorProvider);
        }

        /// <summary>
        /// 校验清算行名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckClearBankName(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位字符", description, length), string.Empty, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeAddress(Control ctl, string data, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, "收款人地址", string.Format("收款人地址{0},最长{1}位字符", RegexHelper.Regex686_Tip, maxlength), RegexHelper.Regex686, 0, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验支付手续费账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayFeeNo(Control ctl, string data, bool flag, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, "支付手续费账号", "支付手续费账号长度位12到18位", string.Empty, 12, 18, !flag, false, errorProvider);
        }

        /// <summary>
        /// 校验Email长度
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckEmail(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckEmail(ctl, data, 40, errorProvider);
        }

        /// <summary>
        /// 校验Email长度
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckEmail(Control ctl, string data, int length, ErrorProviderExt errorProvider)
        {
            return CheckEmail(ctl, data, "Email", length, errorProvider);
        }

        /// <summary>
        /// 校验Email长度
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckEmail(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("Email最长{0}位字符,{1}", length, RegexHelper.Regex539_Tip), RegexHelper.Regex539, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验Email长度
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckEmailGJ(Control ctl, string data, string description, int minlength, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("Email{0},{1}-{2}位字符", RegexHelper.Regex539_Tip, minlength, maxlength), RegexHelper.Regex539, minlength, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验是否中行标志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckBOCSingal(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, "是否中行标志", "是否中行标志为必填项", @"^0$", 1, 1, true, true, errorProvider);
        }

        /// <summary>
        /// 校验清算行行号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckClearBankNo(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, "清算行行号", "清算行行号只允许输入12位数字", @"^[0-9]{12}$", 12, 12, true, true, errorProvider);
        }

        /// <summary>
        /// 校验联行号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckLinkBankNo(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckLinkBankNo(ctl, data, "付款行联行号", errorProvider);
        }

        /// <summary>
        /// 校验联行号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckLinkBankNo(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}只允许输入4开头的5位数字", dataDescription), @"^4[0-9]{4}$", 5, 5, true, true, errorProvider);
        }

        /// <summary>
        /// 校验机构号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckOrg(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}只允许输入5位数字", dataDescription), @"^[0-9]{5}$", 5, 5, true, true, errorProvider);
        }

        /// <summary>
        /// 校验柜台客户号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckBarCustomerNo(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}最长允许输入8位的大写字母或数字", dataDescription), RegexHelper.Regex24, 1, 8, true, true, errorProvider);
        }

        /// <summary>
        /// 校验柜台批次号
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="data"></param>
        /// <param name="dataDescription"></param>
        /// <param name="errorProvider"></param>
        /// <returns></returns>
        public static ResultData CheckBarSerilNo(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}请输入001到999", dataDescription), @"^(([0-9]{2}[1-9])|([0-9][1-9][0-9])|([1-9][0-9]{2}))$", 3, 3, true, true, errorProvider);
        }

        /// <summary>
        /// 校验swift code
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckSwiftCode(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}最长允许输入18位的大写字母或数字", dataDescription), RegexHelper.Regex24, 1, 18, true, false, errorProvider);
        }

        /// <summary>
        /// 校验swift code
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckSwiftCodeFMBar(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}最长允许输入11位的大写字母或数字", dataDescription), RegexHelper.Regex24, 11, 11, true, true, errorProvider);
        }

        /// <summary>
        /// 校验外币统一支付跨境swift code
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckSwiftCodeFC(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}请输入8位或者11位的大写字母或数字", dataDescription), RegexHelper.Regex24, 8, 11, true, true, errorProvider);
        }
        /// <summary>
        /// 校验代发卡类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAgentCardType(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckAgentCardType(ctl, data, "代发卡类型", errorProvider);
        }

        /// <summary>
        /// 校验代发卡类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAgentCardType(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = string.Format("{0}为必填项", dataDescription);
            }
            else
            {
                switch (data)
                {
                    case "借记卡":
                    case "存折":
                    case "QCC卡":
                    case "信用卡":
                    case "他行卡":
                        rd.Result = true; break;
                    default:
                        rd.Result = false;
                        rd.Message = string.Format("{0}格式不符,请重新输入", dataDescription);
                        break;
                }
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验代发卡类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckAgentCardType(Control ctl, string data, string dataDescription, bool isAgentOut, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = string.Format("{0}为必填项", dataDescription);
            }
            else
            {
                switch (data)
                {
                    case "借记卡":
                    case "存折":
                        rd.Result = true; break;
                    case "QCC卡":
                    case "信用卡":
                        if (!isAgentOut)
                        {
                            rd.Result = false;
                            rd.Message = "代收款类型错误";
                        }
                        else rd.Result = true;
                        break;
                    case "他行卡":
                        rd.Result = true; break;
                    default:
                        rd.Result = false;
                        rd.Message = string.Format("{0}格式不符,请重新输入", dataDescription);
                        break;
                }
            }
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验行号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataDescription"></param>
        /// <returns></returns>
        public static ResultData CheckRowIndex(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, dataDescription, string.Format("{0}只允许输入正整数", dataDescription), @"^\d{1,}$", 1, Int32.MaxValue.ToString().Length, true, false, errorProvider);
        }

        /// <summary>
        /// 检查快速查找内容
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataDescription"></param>
        /// <returns></returns>
        public static ResultData CheckQuickQeuryContent(Control ctl, string data, string dataDescription, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            if (string.IsNullOrEmpty(data))
            {
                rd.Result = false;
                rd.Message = string.Format("请填写{0}的内容", dataDescription);
            }
            else rd.Result = true;

            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验每批次最大笔数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckMaxCountPreOperator(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            try
            {
                if (int.Parse(data) <= 0)
                {
                    rd.Result = false;
                    rd.Message = "每批次最大笔数不能为零";
                }
                else
                { rd.Result = true; }
            }
            catch { rd = new ResultData { Result = false, Message = "请输入每批次最大笔数" }; }

            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验分隔符
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckSeparator(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            ResultData rd = new ResultData();
            int length = GetByteLength(data);
            if (length > 2)
            { rd = new ResultData { Result = false, Message = "分隔符为必填项，且长度不能超过2位" }; }
            else rd.Result = true;
            if (ctl != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                    errorProvider.SetError(ctl, rd.Message);
                else
                    errorProvider.Clear();
            }
            return rd;
        }

        /// <summary>
        /// 校验协议号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckProtecolNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位", description, length), string.Empty, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验关系人编号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckRelateSerialNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}位", description, RegexHelper.Regex634_Tip, length), RegexHelper.Regex634, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验业务种类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckBusinessType(BusinessType data)
        {
            ResultData rd = new ResultData();
            if (data == BusinessType.Empty)
            {
                rd.Result = false;
                rd.Message = "业务种类为必填项";
            }
            else
            {
                try
                {
                    string str = EnumNameHelper<BusinessType>.GetEnumDescription(data);
                    rd.Result = true;
                }
                catch
                {
                    rd.Result = false;
                    rd.Message = "业务种类格式错误";
                }
            }
            return rd;
        }

        /// <summary>
        /// 校验支付手续费账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayFeeNo(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckPayFeeNo(ctl, data, 0, 35, errorProvider);
        }

        /// <summary>
        /// 校验支付手续费账号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayFeeNo(Control ctl, string data, int minlength, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, "支付手续费账号", string.Format("支付手续费账号允许输入{0}到{1}位", minlength, maxlength), string.Empty, minlength, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验传真号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeFax(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0},{1},最长{2}位", description, RegexHelper.Regex612_Tip, length), RegexHelper.Regex612, 6, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验传真号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckPayeeFaxGJ(Control ctl, string data, string description, int minlength, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1},最长{2}-{3}位", description, RegexHelper.Regex612_Tip, minlength, maxlength), RegexHelper.Regex612, minlength, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验手机号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultData CheckPayeePhone(Control ctl, string data, ErrorProviderExt errorProvider)
        {
            return CheckPayeePhone(ctl, data, 1, 20, errorProvider);
        }

        /// <summary>
        /// 校验手机号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="maxlength"></param>
        /// <returns></returns>
        public static ResultData CheckPayeePhone(Control ctl, string data, int minlength, int maxlength, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, "手机号", string.Format("{0}最长允许输入{1}-{2}位数字", "手机号", minlength, maxlength), RegexHelper.Regex57, minlength, maxlength, false, false, errorProvider);
        }

        /// <summary>
        /// 校验手机号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckPayeePhone(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位数字", description, length), length == 11 ? @"^[0-9]{1,11}$" : @"^[0-9]{1,15}$", 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验票据号码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckElecTicketSerialNo(Control ctl, string data, string description, int length, bool isFix, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位数字", description, length), @"^[0-9]{1,30}$", 1, length, true, isFix, errorProvider);
        }

        /// <summary>
        /// 校验发票号码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckBillSerialNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位数字", description, length), @"^[0-9]{1," + length + "}$", 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验发票号码--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckBillSerialNoSF(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1}最长{2}位", description, RegexHelper.Regex720Ex_Tip, length), RegexHelper.Regex720Ex, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验发票号码--外币统一支付跨境发票号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckBillSerialNoFC(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}{1}最长{2}位", description, RegexHelper.Regex702_Tip, length), RegexHelper.Regex702, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验合同编号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckContractNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckContractNo(ctl, data, description, string.Format("{0}最长允许输入{1}位数字", description, length), @"^[0-9]{1," + length + "}$", length, errorProvider);
        }

        /// <summary>
        /// 校验合同号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckContractNoEx(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckContractNo(ctl, data, description, string.Format("{0}最长允许输入{1}位,{2}", description, length, RegexHelper.Regex641_Tip), RegexHelper.Regex641, length, errorProvider);
        }

        /// <summary>
        /// 校验合同号  --统一支付外币本行
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckContractNoExFC(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckContractNo(ctl, data, description, string.Format("{0}最长允许输入{1}位,{2}", description, length, RegexHelper.Regex164_Tip), RegexHelper.Regex164, length, errorProvider);
        }

        /// <summary>
        /// 校验合同编号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckContractNo(Control ctl, string data, string description, string tipStr, string matchStr, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, tipStr, matchStr, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验贴现利率
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="isPercent"></param>
        /// <returns></returns>
        public static ResultData CheckPayMoneyPercent(Control ctl, string data, string description, bool isPercent, ErrorProviderExt errorProvider)
        {
            string matchstr = isPercent ? @"^((\d{1,2}(\.\d{1,4})?)||(100(\.0{1,4})?))$" : @"^((0(\.\d{1,6})?)||(1(\.0{1,6})?))$";
            int length = 8;//isPercent ? 8 : 10;
            return CheckData(ctl, data, description, string.Format("{0}请输入整数不超过100，小数不超过4位的数字", description), matchstr, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验协议付息比例
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="isPercent"></param>
        /// <returns></returns>
        public static ResultData CheckProtocolPercent(Control ctl, string data, string description, ErrorProviderExt errorProvider, bool ispercent = true)
        {
            string matchstr = ispercent ? @"^((0\.[1-9])|([1-9][0-9]?(\.[0-9])?)|(100(\.0)?))$" : @"^((0\.[0-9]{1,3})|(1(\.0{1,3})?))$";
            return CheckData(ctl, data, description, string.Format("{0}最多允许输入1位小数,且不大于100", description), matchstr, 1, 5, true, false, errorProvider);
        }

        /// <summary>
        /// 校验前一收背书人
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="maxlenght"></param>
        /// <returns></returns>
        public static ResultData CheckPreBackNotedPerson(Control ctl, string data, string description, int maxlenght, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}允许输入字母、数字、汉字和“',.-/()”等,最多120个字符", description), RegexHelper.Regex540, 0, 120, false, false, errorProvider);
        }

        /// <summary>
        /// 校验申请人姓名
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="maxlenght"></param>
        /// <returns></returns>
        public static ResultData CheckProposerName(Control ctl, string data, string description, int maxlenght, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format(@"{0} {1},最多{2}位", description, RegexHelper.Regex540_Tip, maxlenght), RegexHelper.Regex540, 1, maxlenght, true, false, errorProvider);
        }

        /// <summary>
        /// 校验外汇局批件/备案表号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="maxlenght"></param>
        /// <returns></returns>
        public static ResultData CheckSerialNoEx(Control ctl, string data, string description, int maxlenght, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最多允许输入{1}位文本", description, maxlenght), string.Empty, 0, maxlenght, false, false, errorProvider);
        }

        /// <summary>
        /// 校验收款人编号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="maxlenght"></param>
        /// <returns></returns>
        public static ResultData CheckSerialNoGJ(Control ctl, string data, string description, int maxlenght, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最多允许输入{1}位,半角英文,半角数字", description, maxlenght), RegexHelper.Regex8, 0, maxlenght, false, false, errorProvider);
        }

        /// <summary>
        /// 校验国际结算手机号
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="maxlenght"></param>
        /// <returns></returns>
        public static ResultData CheckTelePhone(Control ctl, string data, string description, int maxlenght, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0} {1},最多{2}位", description, RegexHelper.Regex699_Tip, maxlenght), RegexHelper.Regex699, 1, 15, true, false, errorProvider);
        }
        /// <summary>
        /// 校验账号名称--内部账户转账
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="maxlenght"></param>
        /// <returns></returns>
        public static ResultData CheckVirtualAccountName(Control ctl, string data, string description, int maxlenght, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0} {1},最多{2}位", description, RegexHelper.Regex585_Tip, maxlenght), RegexHelper.Regex585, 0, maxlenght, true, false, errorProvider);
        }
        /// <summary>
        /// 校验组织机构代码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ResultData CheckOrgCode(Control ctl, string data, string description, ErrorProviderExt errorProvider)
        { return CheckData(ctl, data, description, string.Format("{0}格式为XXXXXXXX-X", description), @"^[A-Z0-9a-z]{8}-[A-Z0-9a-z]$", 10, 10, true, true, errorProvider); }

        /// <summary>
        /// 校验合同/订单号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckContractOrOrderNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex641_Tip, length), RegexHelper.Regex641, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验订单编号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckOrderNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}字符", description, RegexHelper.Regex717_Tip, length), RegexHelper.Regex717, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验ERP代码--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckERPCode(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex717_Tip, length), RegexHelper.Regex717, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验税务发票号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckTaxBillSerialNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex641_Tip, length), RegexHelper.Regex641, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验收货单号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckReceiptNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex641_Tip, length), RegexHelper.Regex641, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验风险承担函号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckRiskTakingLetterNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex641_Tip, length), RegexHelper.Regex641, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验货物描述--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckGoodsDesc(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex641_Tip, length), RegexHelper.Regex641, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验货物描述--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckApplyDays(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex714_Tip, length), RegexHelper.Regex714, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验起始数据行数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckStartRowIndex(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, "请输入数字", length), @"[1-9]\d*", 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验协议文本号--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckAgrementNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex641_Tip, length), RegexHelper.Regex641, 0, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验协议号--快捷代收付款人名册
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckAgrementNoEx(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex666_Tip, length), RegexHelper.Regex666, 1, length, true, false, errorProvider);
        }

        /// <summary>
        /// 校验利率浮动比例--供应链
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckInterestFloatingPercent(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}\r\n{1},最长{2}位", description, RegexHelper.Regex9103_Tip, length), RegexHelper.Regex9103, 1, length, false, false, errorProvider);
        }

        /// <summary>
        /// 校验常驻国家名称-国际结算
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckCountryName(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        { return CheckData(ctl, data, description, string.Format("{0}{1},最长允许输入{2}位", description, RegexHelper.Regex630_Tip, length), RegexHelper.Regex630, 1, length, true, false, errorProvider); }
        /// <summary>
        /// 长度校验
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <param name="errorProvider"></param>
        /// <returns></returns>
        public static ResultData CheckLength(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        {
            return CheckData(ctl, data, description, string.Format("{0}最长允许输入{1}位", description, length), string.Empty, 1, length, false, false, errorProvider);
        }
        /// <summary>
        /// 校验常驻国家代码-国际结算
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckCountryCode(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        { return CheckData(ctl, data, description, string.Format("{0}允许输入{1}位数字", description, length), RegexHelper.Regex690, length, length, true, true, errorProvider); }

        /// <summary>
        /// 财政服务类-批量报销卡号校验
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <param name="errorProvider"></param>
        /// <returns></returns>
        public static ResultData CheckCardNo(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        { return CheckData(ctl, data, description, string.Format("{0}允许输入{1}位数字", description, length), RegexHelper.Regex57, length, length, true, true, errorProvider); }

        /// <summary>
        /// 财政服务类-批量报销支付令校验
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <param name="errorProvider"></param>
        /// <returns></returns>
        public static ResultData CheckPayPassword(Control ctl, string data, string description, int minlength, int maxlength, ErrorProviderExt errorProvider)
        { return CheckData(ctl, data, description, string.Format("{0}{1}", description, "1开头可输入13位数字，2开头可输入16位数字"), RegexHelper.Regex57, minlength, maxlength, true, true, errorProvider); }

        /// <summary>
        /// 校验常驻国家代码-国际结算-柜台
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ResultData CheckCountryCodeBar(Control ctl, string data, string description, int length, ErrorProviderExt errorProvider)
        { return CheckData(ctl, data, description, string.Format("{0}允许输入{1}位大写字母", description, length), RegexHelper.Regex9104, length, length, true, true, errorProvider); }

        static ResultData CheckData(string data, string datadescription, string tipmsg, string regmatchstr, int minlength, int maxlength, bool isMust, bool isFix)
        {
            ResultData rd = new ResultData { Result = true };
            if (isMust)
            {
                if (string.IsNullOrEmpty(data))
                {
                    return new ResultData { Result = false, Message = string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, datadescription) };
                }
            }
            if (!string.IsNullOrEmpty(regmatchstr))
            {
                if ((!isMust && !string.IsNullOrEmpty(data)) || isMust)
                {
                    RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
                    if (!Regex.IsMatch(data, regmatchstr, options))
                    {
                        return new ResultData { Result = false, Message = tipmsg };
                    }
                }
            }
            #region 校验长度
            int datalength = 0;
            if (!string.IsNullOrEmpty(data)) datalength = GetByteLength(data);
            if (datalength != 0)
            {
                if (isFix)
                {
                    if (datalength != maxlength && datalength != minlength)
                    {
                        rd = new ResultData { Result = false, Message = tipmsg };
                        return rd;
                    }
                }
                else
                {
                    if ((minlength == 0 && datalength > maxlength) || (minlength > 0 && (datalength < minlength || datalength > maxlength)))
                    {
                        rd = new ResultData { Result = false, Message = tipmsg };
                        return rd;
                    }
                }
            }
            #endregion

            if (!string.IsNullOrEmpty(data) && data.Contains("|"))
            {
                rd.Result = false;
                rd.Message = string.Format("{0}中不能包含'|'", datadescription);
            }
            return rd;
        }

        static ResultData CheckData(Control editor, string editorValueAlt, string datadescription, string tipmsg, string regmatchstr, int minlength, int maxlength, bool isMust, bool isFix, ErrorProviderExt errorProvider)
        {
            //if (errorProvider.ResultData != null)
            //{
            //    //MessageBoxPrime.Show("请检查: " + errorProvider.ResultData.Message);
            //    return errorProvider.ResultData;
            //}

            var errorMessages = new List<string>();
            var rd = new ResultData { Result = true };
            if (isMust && string.IsNullOrEmpty(editorValueAlt))
            {
                rd.Result = false;
                errorMessages.Add(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, datadescription));
            }
            var data = editorValueAlt;
            if (!string.IsNullOrEmpty(regmatchstr))
            {
                if ((!isMust && !string.IsNullOrEmpty(data)) || isMust)
                {
                    var options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
                    if (string.IsNullOrEmpty(data) || !Regex.IsMatch(data, regmatchstr, options))
                    {
                        rd.Result = false;
                        errorMessages.Add(tipmsg);
                    }
                }
            }

            #region 校验长度
            int datalength = 0;
            if (!string.IsNullOrEmpty(data)) datalength = GetByteLength(data);
            if (isFix)
            {
                if (datalength != maxlength && datalength != minlength)
                    if (!errorMessages.Contains(tipmsg))
                    {
                        rd.Result = false;
                        errorMessages.Add(tipmsg);
                    }
            }
            else
            {
                if ((minlength == 0 && datalength > maxlength) || (minlength > 0 && (datalength < minlength || datalength > maxlength)))
                    if (!errorMessages.Contains(tipmsg))
                    {
                        rd.Result = false;
                        errorMessages.Add(tipmsg);
                    }
            }
            #endregion

            if (!string.IsNullOrEmpty(data) && data.Contains("|"))
            {
                rd.Result = false;
                errorMessages.Add(string.Format("{0}中不能包含'|'", datadescription));
            }

            foreach (string errorMessage in errorMessages)
                rd.Message = rd.Message + "\r\n" + errorMessage;
            rd.Message += "\r\n";
            if (editor != null && errorProvider != null)
            {
                errorProvider.ResultData = rd;
                if (!rd.Result)
                {
                    errorProvider.SetError(editor, rd.Message);
                    ((IDataValidateEditor)editor).DvUpdateErrorFrame();
                }
                else
                    errorProvider.SetError(editor, string.Empty);
            }
            return rd;
        }

        private static int GetByteLength(string data)
        {
            return Encoding.Default.GetBytes(data).Length;
        }
    }


    public static class EntityChecker
    {
        // 根据正则，必填，最小长度，最大长度校验字段值是否合法
        public static bool CheckValueIsValid(string fieldValue, string regValue, bool required, int minLength, int maxLength)
        {
            var regex = new Regex(regValue);
            var textLength = string.IsNullOrEmpty(fieldValue) ? 0 : System.Text.Encoding.UTF8.GetBytes(fieldValue).Length;
            var isValid = (((string.IsNullOrEmpty(fieldValue) && !required)) ? true : regex.IsMatch(fieldValue)) && ((required ? (!string.IsNullOrEmpty(fieldValue) && required) : true) && (textLength >= minLength) && (textLength <= maxLength));
            return isValid;
        }

    }
}
