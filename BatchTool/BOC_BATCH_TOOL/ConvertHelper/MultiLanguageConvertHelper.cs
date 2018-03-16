using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL.ConvertHelper
{
    public class MultiLanguageConvertHelper
    {
        #region 单例
        private static object Lock_obj = new object();
        private static MultiLanguageConvertHelper m_instance;
        //单例
        public static MultiLanguageConvertHelper Instance
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
                                m_instance = new MultiLanguageConvertHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        #region 提示框 1***

        #region 标题  10**
        public string MessageBoxTitle_Waring { get { return GetMessage(1001); } }
        public string MessageBoxTitle_Question { get { return GetMessage(1002); } }
        public string MessageBoxTitle_Information { get { return GetMessage(1003); } }
        #endregion

        #region 内容  11**
        public string Information_Select_BusinessType { get { return GetMessage(1100); } }
        public string Information_DataFieldMissing_OpenFile_Fail { get { return GetMessage(1101); } }
        public string Information_OpenFile_Fail { get { return GetMessage(1102); } }
        public string Information_SomeInvalidData_InRow { get { return GetMessage(1103); } }
        public string Information_Please_Input { get { return GetMessage(1104); } }
        public string Information_Please_Select { get { return GetMessage(1105); } }
        public string Information_Or { get { return GetMessage(1106); } }
        public string Information_Sum_Must_Equal_AllAmount { get { return GetMessage(1107); } }
        public string Information_Ok { get { return GetMessage(1108); } }
        public string Information_Cancel { get { return GetMessage(1109); } }
        public string Information_Retry { get { return GetMessage(1110); } }
        public string Information_Yes { get { return GetMessage(1111); } }
        public string Information_No { get { return GetMessage(1112); } }
        public string Information_Abort { get { return GetMessage(1113); } }
        public string Information_Ignore { get { return GetMessage(1114); } }
        public string Information_Field_InvalidData_InRow { get { return GetMessage(1115); } }
        #endregion

        #endregion

        #region 界面  19**-99**

        #region 界面公共信息
        public string DesignMain_Submit_Succeed { get { return GetMessage(1900); } }
        public string DesignMain_Submit_Fail { get { return GetMessage(1901); } }
        public string DesignMain_MakeFile_Fail { get { return GetMessage(1902); } }
        public string DesignMain_Record_Not_Exist { get { return GetMessage(1903); } }
        public string DesignMain_Whether_Save_Record { get { return GetMessage(1904); } }
        public string DesignMain_Over_MaxCount_Whether_Continue { get { return GetMessage(1905); } }
        public string DesignMain_FileType_TXT { get { return GetMessage(1906); } }
        public string DesignMain_FileType_Excel { get { return GetMessage(1907); } }
        public string DesignMain_FileType_CSV { get { return GetMessage(1908); } }
        public string DesignMain_FileType_SEF { get { return GetMessage(1909); } }
        public string DesignMain_FileType_Zip { get { return GetMessage(1910); } }
        public string DesignMain_ErrorFile_NotMatch_SourceFile { get { return GetMessage(1911); } }
        public string DesignMain_NullErrorFile_Or_InvalidData { get { return GetMessage(1912); } }
        public string DesignMain_Over_MaxCount_Only_View_Some_Record { get { return GetMessage(1913); } }
        public string DesignMain_MakeSure_Delete_Record { get { return GetMessage(1914); } }
        public string DesignMain_Reach_MaxCount_CanNot_Add { get { return GetMessage(1915); } }
        public string DesignMain_NoMatch_Record { get { return GetMessage(1916); } }
        public string DesignMain_Reach_DocumentEnd { get { return GetMessage(1917); } }
        public string DesignMain_Gather_AllCount_And_AllAmount { get { return GetMessage(1918); } }
        public string DesignMain_Gather_AllCount { get { return GetMessage(1919); } }
        public string DesignMain_InvalidDta_ChangeFile_Fail { get { return GetMessage(1920); } }
        public string DesignMain_Open_SourceFile_Then_Match_ErrorFile { get { return GetMessage(1921); } }
        public string DesignMain_Addition_Is_Full { get { return GetMessage(1922); } }
        public string DesignMain_Usege_Is_Full { get { return GetMessage(1923); } }
        public string DesignMain_NoData_Save { get { return GetMessage(1924); } }
        public string DesignMain_MakeSure_Delete_AllRecord { get { return GetMessage(1925); } }
        public string DesignMain_Select_File_Agent { get { return GetMessage(1926); } }

        public string DesignMain_PayerAccount { get { return GetMessage(1927); } }
        public string DesignMain_PayeeAccount { get { return GetMessage(1928); } }
        public string DesignMain_PayerName { get { return GetMessage(1929); } }
        public string DesignMain_PayeeName { get { return GetMessage(1930); } }
        public string DesignMain_RemitAccount { get { return GetMessage(1931); } }
        public string DesignMain_Account { get { return GetMessage(1932); } }
        public string DesignMain_ElecTicket_SerialNo { get { return GetMessage(1933); } }
        public string DesignMain_TransferGlobal_PayeeAccountDescription { get { return GetMessage(1934); } }
        public string DesignMain_TransferGlobal_RemitAddressDescription { get { return GetMessage(1935); } }
        public string DesignMain_FileType_DIF { get { return GetMessage(1936); } }
        public string DesignMain_FileType_Unknow { get { return GetMessage(1937); } }
        public string DesignMain_Unknow_AppType { get { return GetMessage(1938); } }
        public string DesignMain_Has_NoData_ChangeFile { get { return GetMessage(1939); } }
        public string DesignMain_Data_Changing_Error { get { return GetMessage(1940); } }
        public string DesignMain_Please_Selection { get { return GetMessage(1975); } }
        public string DesignMain_Set_Password { get { return GetMessage(1978); } }
        public string DesignMain_OrderNo_Exist { get { return GetMessage(1979); } }
        public string DesignMain_Name_And_Address_MaxLength { get { return GetMessage(1980); } }
        public string DesignMain_Swift_Code { get { return GetMessage(1981); } }
        public string DesignMain_PayerAccount_Real { get { return GetMessage(1982); } }
        public string DesignMain_PayerName_Real { get { return GetMessage(1983); } }
        public string DesignMain_MakeSure_Delete_Record_By_ID { get { return GetMessage(1984); } }
        public string DesignMain_Gather_AllCount_And_AllAmount_And_CashType { get { return GetMessage(1985); } }
        #endregion

        #region 主界面 20**
        public string FrmMain_Text { get { return GetMessage(2000); } }
        public string FrmMain_Bar_Text { get { return GetMessage(2017); } }
        public string FrmMain_LoginOff_System { get { return GetMessage(2001); } }
        public string FrmMain_Bar_LoginOff_System { get { return GetMessage(2018); } }
        public string FrmMain_HelpFile_Missing { get { return GetMessage(2002); } }
        public string FrmMain_Goto_E_Net { get { return GetMessage(2003); } }
        public string FrmMain_Change_Language { get { return GetMessage(2004); } }
        public string FrmMain_CHS { get { return GetMessage(2005); } }
        public string FrmMain_EN { get { return GetMessage(2006); } }
        public string FrmMain_CHT { get { return GetMessage(2007); } }
        public string FrmMain_Help { get { return GetMessage(2008); } }
        public string FrmMain_Update { get { return GetMessage(2009); } }
        public string FrmMain_Update_File_OpenBankCode { get { return GetMessage(2011); } }
        public string FrmMain_Update_File_ClearBankCode { get { return GetMessage(2012); } }
        public string FrmMain_Update_File_BankLinkNo { get { return GetMessage(2010); } }
        public string FrmMain_Update_File_Soft { get { return GetMessage(2013); } }
        public string FrmMain_LoginOff { get { return GetMessage(2014); } }
        public string FrmMain_Help_About { get { return GetMessage(2015); } }
        public string FrmMain_Help_OperationDescription { get { return GetMessage(2016); } }
        #endregion

        #region 对公汇款    21**
        public string Transfer_CustomerRef_Exist { get { return GetMessage(2100); } }
        public string Transfer_Mappings_Amount { get { return GetMessage(1947); } }
        public string Transfer_Mappings_PayeeName { get { return GetMessage(1930); } }
        public string Transfer_Mappings_PayeeAccount { get { return GetMessage(1928); } }
        public string Transfer_Mappings_PayeeOpenBankName { get { return GetMessage(1949); } }
        public string Transfer_Mappings_CNAPSNo { get { return GetMessage(2174); } }
        public string Transfer_Mappings_PayerAccount { get { return GetMessage(1927); } }
        public string Transfer_Mappings_PayFeeAccount { get { return GetMessage(1941); } }
        public string Transfer_Mappings_PayDate { get { return GetMessage(1946); } }
        public string Transfer_Mappings_Addtion { get { return GetMessage(1943); } }
        public string Transfer_Mappings_OperateOrder { get { return GetMessage(1945); } }
        public string Transfer_Mappings_Email { get { return GetMessage(1950); } }
        public string Transfer_Mappings_IsBOCFlag { get { return GetMessage(2181); } }
        public string Transfer_Mappings_CustomerRef { get { return GetMessage(1942); } }
        #endregion

        #region 对私汇款    22**
        public string Transfer_Mappings_Amount_RegexDescription { get { return GetMessage(2270); } }
        public string Transfer_Mappings_PayeeName_RegexDescription { get { return GetMessage(2271); } }
        public string Transfer_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2272); } }
        public string Transfer_Mappings_PayeeOpenBankName_RegexDescription { get { return GetMessage(2273); } }
        public string Transfer_Mappings_CNAPSNo_RegexDescription { get { return GetMessage(2274); } }
        public string Transfer_Mappings_PayerAccount_RegexDescription { get { return GetMessage(2275); } }
        public string Transfer_Mappings_PayFeeAccount_RegexDescription { get { return GetMessage(2276); } }
        public string Transfer_Mappings_PayDate_RegexDescription { get { return GetMessage(2277); } }
        public string Transfer_Mappings_Addtion_RegexDescription { get { return GetMessage(2278); } }
        public string Transfer_Mappings_OperateOrder_RegexDescription { get { return GetMessage(2279); } }
        public string Transfer_Mappings_Email_RegexDescription { get { return GetMessage(2280); } }
        public string Transfer_Mappings_IsBOCFlag_RegexDescription { get { return GetMessage(2281); } }
        public string Transfer_Mappings_CustomerRef_RegexDescription { get { return GetMessage(2282); } }
        #endregion

        #region 快捷代发    23**
        public string AgentExpressOut_Mappings_PayeeAccountProvince { get { return GetMessage(2300); } }
        public string AgentExpressOut_Mappings_PayeeOpenBankName { get { return GetMessage(2301); } }
        public string AgentExpressOut_Mappings_PayeeOpenBankNo { get { return GetMessage(2302); } }
        public string AgentExpressOut_Mappings_Batch_PayeeBankName { get { return GetMessage(2350); } }
        public string AgentExpressOut_Mappings_Batch_PayerName { get { return GetMessage(1929); } }
        public string AgentExpressOut_Mappings_Batch_PayerAccount { get { return GetMessage(1927); } }
        public string AgentExpressOut_Mappings_Batch_Usege { get { return GetMessage(2353); } }
        public string AgentExpressOut_Mappings_Batch_PayDate { get { return GetMessage(1946); } }
        public string AgentExpressOut_Mappings_Batch_CutomerRef { get { return GetMessage(1942); } }
        public string AgentExpressOut_Mappings_Batch_Addtion { get { return GetMessage(1944); } }
        public string AgentExpressOut_Mappings_Amount { get { return GetMessage(1947); } }
        public string AgentExpressOut_Mappings_PayeeName { get { return GetMessage(1930); } }
        public string AgentExpressOut_Mappings_PayeeAccount { get { return GetMessage(1928); } }
        public string AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo { get { return GetMessage(2360); } }
        public string AgentExpressOut_Mappings_PayeeCertifyCardType { get { return GetMessage(2361); } }
        public string AgentExpressOut_Mappings_PayeeCertifyNo { get { return GetMessage(2362); } }
        public string AgentExpressOut_Mappings_Usage { get { return GetMessage(1973); } }
        //public string AgentExpressOut_Mappings_Batch_PayeeBankName_RegexDescription { get { return GetMessage(2375); } }
        //public string AgentExpressOut_Mappings_Batch_PayerName_RegexDescription { get { return GetMessage(2376); } }
        //public string AgentExpressOut_Mappings_Batch_PayerAccount_RegexDescription { get { return GetMessage(2377); } }
        //public string AgentExpressOut_Mappings_Batch_Usege_RegexDescription { get { return GetMessage(2378); } }
        //public string AgentExpressOut_Mappings_Batch_PayDate_RegexDescription { get { return GetMessage(2379); } }
        //public string AgentExpressOut_Mappings_Batch_CutomerRef_RegexDescription { get { return GetMessage(2380); } }
        //public string AgentExpressOut_Mappings_Batch_Addtion_RegexDescription { get { return GetMessage(2381); } }
        public string AgentExpressOut_Mappings_Amount_RegexDescription { get { return GetMessage(2382); } }
        public string AgentExpressOut_Mappings_PayeeName_RegexDescription { get { return GetMessage(2383); } }
        public string AgentExpressOut_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2384); } }
        public string AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo_RegexDescription { get { return GetMessage(2385); } }
        public string AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription { get { return GetMessage(2386); } }
        public string AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription { get { return GetMessage(2387); } }
        public string AgentExpressOut_Mappings_Usage_RegexDescription { get { return GetMessage(2388); } }
        public string AgentExpressOut_Mappings_PayeeOpenBankName_RegexDescription { get { return GetMessage(2389); } }
        public string AgentExpressOut_Mappings_PayeeAccountProvince_RegexDescription { get { return GetMessage(2399); } }
        public string AgentExpressOut_Mappings_Business { get { return GetMessage(2349); } }
        #endregion

        #region 快捷代收    24**
        public string AgentExpressIn_Mappings_PayerAccountProvince { get { return GetMessage(2400); } }
        public string AgentExpressIn_Mappings_PayerOpenBankName { get { return GetMessage(2401); } }
        public string AgentExpressIn_Mappings_PayerOpenBankNo { get { return GetMessage(2402); } }
        public string AgentExpressIn_Mappings_Batch_PayerBankName { get { return GetMessage(2450); } }
        public string AgentExpressIn_Mappings_Batch_PayeeName { get { return GetMessage(1930); } }
        public string AgentExpressIn_Mappings_Batch_PayeeAccount { get { return GetMessage(1928); } }
        public string AgentExpressIn_Mappings_Batch_Usege { get { return GetMessage(2453); } }
        public string AgentExpressIn_Mappings_Batch_PayDate { get { return GetMessage(2454); } }
        public string AgentExpressIn_Mappings_Batch_CutomerRef { get { return GetMessage(1942); } }
        public string AgentExpressIn_Mappings_Batch_Addtion { get { return GetMessage(1944); } }
        public string AgentExpressIn_Mappings_Amount { get { return GetMessage(1948); } }
        public string AgentExpressIn_Mappings_PayerName { get { return GetMessage(1929); } }
        public string AgentExpressIn_Mappings_PayerAccount { get { return GetMessage(1927); } }
        public string AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo { get { return GetMessage(2460); } }
        public string AgentExpressIn_Mappings_PayerCertifyCardType { get { return GetMessage(2461); } }
        public string AgentExpressIn_Mappings_PayerCertifyNo { get { return GetMessage(2462); } }
        public string AgentExpressIn_Mappings_SerialNo { get { return GetMessage(2463); } }
        public string AgentExpressIn_Mappings_Usage { get { return GetMessage(1973); } }
        //public string AgentExpressIn_Mappings_Batch_PayerBankName_RegexDescription { get { return GetMessage(2475); } }
        //public string AgentExpressIn_Mappings_Batch_PayeeName_RegexDescription { get { return GetMessage(2476); } }
        //public string AgentExpressIn_Mappings_Batch_PayeeAccount_RegexDescription { get { return GetMessage(2477); } }
        //public string AgentExpressIn_Mappings_Batch_Usege_RegexDescription { get { return GetMessage(2478); } }
        //public string AgentExpressIn_Mappings_Batch_PayDate_RegexDescription { get { return GetMessage(2479); } }
        //public string AgentExpressIn_Mappings_Batch_CutomerRef_RegexDescription { get { return GetMessage(2480); } }
        //public string AgentExpressIn_Mappings_Batch_Addtion_RegexDescription { get { return GetMessage(2481); } }
        public string AgentExpressIn_Mappings_Amount_RegexDescription { get { return GetMessage(2382); } }
        public string AgentExpressIn_Mappings_PayerName_RegexDescription { get { return GetMessage(2383); } }
        public string AgentExpressIn_Mappings_PayerAccount_RegexDescription { get { return GetMessage(2384); } }
        public string AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo_RegexDescription { get { return GetMessage(2385); } }
        public string AgentExpressIn_Mappings_PayerCertifyCardType_RegexDescription { get { return GetMessage(2386); } }
        public string AgentExpressIn_Mappings_PayerCertifyNo_RegexDescription { get { return GetMessage(2387); } }
        public string AgentExpressIn_Mappings_SerialNo_RegexDescription { get { return GetMessage(2488); } }
        public string AgentExpressIn_Mappings_Usage_RegexDescription { get { return GetMessage(2388); } }
        #endregion

        #region 普通代发    25**
        public string AgentNormalOut_Mappings_PayeeBankLinkNo { get { return GetMessage(1976); } }
        public string AgentNormalOut_Mappings_PayeeOpenBankNo { get { return GetMessage(2500); } }
        public string AgentNormalOut_Mappings_Batch_PayerName { get { return GetMessage(1929); } }
        public string AgentNormalOut_Mappings_Batch_PayerAccount { get { return GetMessage(1927); } }
        public string AgentNormalOut_Mappings_Batch_CustomerRef { get { return GetMessage(1942); } }
        public string AgentNormalOut_Mappings_Batch_PayDate { get { return GetMessage(1946); } }
        public string AgentNormalOut_Mappings_Batch_CardType { get { return GetMessage(2554); } }
        public string AgentNormalOut_Mappings_Batch_BankLinkNo { get { return GetMessage(1977); } }
        public string AgentNormalOut_Mappings_Batch_Usege { get { return GetMessage(1943); } }
        public string AgentNormalOut_Mappings_Batch_Addtion { get { return GetMessage(1944); } }
        public string AgentNormalOut_Mappings_Amount { get { return GetMessage(1947); } }
        public string AgentNormalOut_Mappings_PayeeName { get { return GetMessage(1930); } }
        public string AgentNormalOut_Mappings_PayeeAccount { get { return GetMessage(1928); } }
        public string AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo { get { return GetMessage(2561); } }
        public string AgentNormalOut_Mappings_PayeeBankName { get { return GetMessage(2562); } }
        public string AgentNormalOut_Mappings_PayeeCertifyCardType { get { return GetMessage(2563); } }
        public string AgentNormalOut_Mappings_PayeeCertifyNo { get { return GetMessage(2564); } }
        public string AgentNormalOut_Mappings_Usege { get { return GetMessage(1943); } }
        //public string AgentNormalOut_Mappings_Batch_PayerName_RegexDescription { get { return GetMessage(2575); } }
        //public string AgentNormalOut_Mappings_Batch_PayerAccount_RegexDescription { get { return GetMessage(2576); } }
        //public string AgentNormalOut_Mappings_Batch_CustomerRef_RegexDescription { get { return GetMessage(2577); } }
        //public string AgentNormalOut_Mappings_Batch_PayDate_RegexDescription { get { return GetMessage(2578); } }
        //public string AgentNormalOut_Mappings_Batch_CardType_RegexDescription { get { return GetMessage(2579); } }
        //public string AgentNormalOut_Mappings_Batch_BankLinkNo_RegexDescription { get { return GetMessage(2580); } }
        //public string AgentNormalOut_Mappings_Batch_Usege_RegexDescription { get { return GetMessage(2581); } }
        //public string AgentNormalOut_Mappings_Batch_Addtion_RegexDescription { get { return GetMessage(2528); } }
        public string AgentNormalOut_Mappings_Amount_RegexDescription { get { return GetMessage(2382); } }
        public string AgentNormalOut_Mappings_PayeeName_RegexDescription { get { return GetMessage(2383); } }
        public string AgentNormalOut_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2585); } }
        public string AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo_RegexDescription { get { return GetMessage(2586); } }
        public string AgentNormalOut_Mappings_PayeeBankName_RegexDescription { get { return GetMessage(2587); } }
        public string AgentNormalOut_Mappings_PayeeCertifyCardType_RegexDescription { get { return GetMessage(2588); } }
        public string AgentNormalOut_Mappings_PayeeCertifyNo_RegexDescription { get { return GetMessage(2589); } }
        public string AgentNormalOut_Mappings_Usege_RegexDescription { get { return GetMessage(2590); } }
        #endregion

        #region 普通代收    26**
        public string AgentNormalIn_Mappings_PayerBankLinkNo { get { return GetMessage(1977); } }
        public string AgentNormalIn_Mappings_PayerOpenBankNo { get { return GetMessage(2600); } }
        public string AgentNormalIn_Mappings_Batch_PayeeName { get { return GetMessage(1930); } }
        public string AgentNormalIn_Mappings_Batch_PayeeAccount { get { return GetMessage(1928); } }
        public string AgentNormalIn_Mappings_Batch_CustomerRef { get { return GetMessage(1942); } }
        public string AgentNormalIn_Mappings_Batch_PayDate { get { return GetMessage(2653); } }
        public string AgentNormalIn_Mappings_Batch_CardType { get { return GetMessage(2654); } }
        public string AgentNormalIn_Mappings_Batch_BankLinkNo { get { return GetMessage(1976); } }
        public string AgentNormalIn_Mappings_Batch_Addtion { get { return GetMessage(1944); } }
        public string AgentNormalIn_Mappings_Amount { get { return GetMessage(1948); } }
        public string AgentNormalIn_Mappings_PayerName { get { return GetMessage(1929); } }
        public string AgentNormalIn_Mappings_PayerAccount { get { return GetMessage(1927); } }
        public string AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo { get { return GetMessage(2660); } }
        public string AgentNormalIn_Mappings_PayerBankName { get { return GetMessage(2661); } }
        public string AgentNormalIn_Mappings_PayerCertifyCardType { get { return GetMessage(2662); } }
        public string AgentNormalIn_Mappings_PayerCertifyNo { get { return GetMessage(2663); } }
        public string AgentNormalIn_Mappings_Usege { get { return GetMessage(1943); } }
        public string AgentNormalIn_Mappings_SerialNo { get { return GetMessage(2665); } }
        //public string AgentNormalIn_Mappings_Batch_PayeeName_RegexDescription { get { return GetMessage(2675); } }
        //public string AgentNormalIn_Mappings_Batch_PayeeAccount_RegexDescription { get { return GetMessage(2676); } }
        //public string AgentNormalIn_Mappings_Batch_CustomerRef_RegexDescription { get { return GetMessage(2677); } }
        //public string AgentNormalIn_Mappings_Batch_PayDate_RegexDescription { get { return GetMessage(2678); } }
        //public string AgentNormalIn_Mappings_Batch_CardType_RegexDescription { get { return GetMessage(2679); } }
        //public string AgentNormalIn_Mappings_Batch_BankLinkNo_RegexDescription { get { return GetMessage(2680); } }
        //public string AgentNormalIn_Mappings_Batch_Addtion_RegexDescription { get { return GetMessage(2681); } }
        public string AgentNormalIn_Mappings_Amount_RegexDescription { get { return GetMessage(2382); } }
        public string AgentNormalIn_Mappings_PayeeName_RegexDescription { get { return GetMessage(2683); } }
        public string AgentNormalIn_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2585); } }
        public string AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo_RegexDescription { get { return GetMessage(2586); } }
        public string AgentNormalIn_Mappings_PayeeBankName_RegexDescription { get { return GetMessage(2587); } }
        public string AgentNormalIn_Mappings_PayerCertifyCardType_RegexDescription { get { return GetMessage(2588); } }
        public string AgentNormalIn_Mappings_PayerCertifyNo_RegexDescription { get { return GetMessage(2589); } }
        public string AgentNormalIn_Mappings_Usege_RegexDescription { get { return GetMessage(2590); } }
        public string AgentNormalIn_Mappings_SerialNo_RegexDescription { get { return GetMessage(2690); } }
        #endregion

        #region 跨行速汇（付款）    27**
        public string Transfer_OverBankOut_Mappings_Amount { get { return GetMessage(1974); } }
        public string Transfer_OverBankOut_Mappings_PayeeName { get { return GetMessage(1930); } }
        public string Transfer_OverBankOut_Mappings_PayeeAccount { get { return GetMessage(1928); } }
        public string Transfer_OverBankOut_Mappings_PayeeBankName { get { return GetMessage(2753); } }
        public string Transfer_OverBankOut_Mappings_PayeeClearBankNo { get { return GetMessage(2754); } }
        public string Transfer_OverBankOut_Mappings_PayerAccount { get { return GetMessage(1927); } }
        public string Transfer_OverBankOut_Mappings_CutomerRef { get { return GetMessage(1942); } }
        public string Transfer_OverBankOut_Mappings_PayFeeAccount { get { return GetMessage(1941); } }
        public string Transfer_OverBankOut_Mappings_Addtion { get { return GetMessage(1943); } }
        public string Transfer_OverBankOut_Mappings_PayDate { get { return GetMessage(1946); } }
        public string Transfer_OverBankOut_Mappings_Email { get { return GetMessage(1950); } }
        public string Transfer_OverBankOut_Mappings_OperateOrder { get { return GetMessage(1945); } }
        public string Transfer_OverBankOut_Mappings_Amount_RegexDescription { get { return GetMessage(2270); } }
        public string Transfer_OverBankOut_Mappings_PayeeName_RegexDescription { get { return GetMessage(2271); } }
        public string Transfer_OverBankOut_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2272); } }
        public string Transfer_OverBankOut_Mappings_PayeeBankName_RegexDescription { get { return GetMessage(2778); } }
        public string Transfer_OverBankOut_Mappings_PayeeClearBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string Transfer_OverBankOut_Mappings_PayerAccount_RegexDescription { get { return GetMessage(2780); } }
        public string Transfer_OverBankOut_Mappings_CutomerRef_RegexDescription { get { return GetMessage(2282); } }
        public string Transfer_OverBankOut_Mappings_PayFeeAccount_RegexDescription { get { return GetMessage(2782); } }
        public string Transfer_OverBankOut_Mappings_Addtion_RegexDescription { get { return GetMessage(2783); } }
        public string Transfer_OverBankOut_Mappings_PayDate_RegexDescription { get { return GetMessage(2977); } }
        public string Transfer_OverBankOut_Mappings_Email_RegexDescription { get { return GetMessage(2785); } }
        public string Transfer_OverBankOut_Mappings_OperateOrder_RegexDescription { get { return GetMessage(2786); } }
        #endregion

        #region 跨行速汇（收款）    28**
        public string Transfer_OverBankIn_Mappings_Amount { get { return GetMessage(1974); } }
        public string Transfer_OverBankIn_Mappings_PayProtecolNo { get { return GetMessage(2851); } }
        public string Transfer_OverBankIn_Mappings_BusinessType { get { return GetMessage(1951); } }
        public string Transfer_OverBankIn_Mappings_PayerName { get { return GetMessage(1929); } }
        public string Transfer_OverBankIn_Mappings_PayerAccount { get { return GetMessage(1927); } }
        public string Transfer_OverBankIn_Mappings_PayerBankName { get { return GetMessage(2855); } }
        public string Transfer_OverBankIn_Mappings_PayerBank { get { return GetMessage(2860); } }
        public string Transfer_OverBankIn_Mappings_PayeeAccount { get { return GetMessage(1928); } }
        public string Transfer_OverBankIn_Mappings_CutomerRef { get { return GetMessage(1942); } }
        public string Transfer_OverBankIn_Mappings_Addtion { get { return GetMessage(1943); } }
        public string Transfer_OverBankIn_Mappings_PayDateTime { get { return GetMessage(2861); } }
        public string Transfer_OverBankIn_Mappings_Amount_RegexDescription { get { return GetMessage(2270); } }
        public string Transfer_OverBankIn_Mappings_PaySerialNo_RegexDescription { get { return GetMessage(2876); } }
        public string Transfer_OverBankIn_Mappings_BusinessType_RegexDescription { get { return GetMessage(2877); } }
        public string Transfer_OverBankIn_Mappings_PayerName_RegexDescription { get { return GetMessage(2878); } }
        public string Transfer_OverBankIn_Mappings_PayerAccount_RegexDescription { get { return GetMessage(2272); } }
        public string Transfer_OverBankIn_Mappings_PayerBankName_RegexDescription { get { return GetMessage(2880); } }
        public string Transfer_OverBankIn_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2780); } }
        public string Transfer_OverBankIn_Mappings_CutomerRef_RegexDescription { get { return GetMessage(2282); } }
        public string Transfer_OverBankIn_Mappings_Addtion_RegexDescription { get { return GetMessage(2884); } }
        public string Transfer_OverBankIn_Mappings_PayDateTime_RegexDescription { get { return GetMessage(2977); } }
        #endregion

        #region 电票出票    29**
        public string ElecTicket_Remit_Mappings_TicketType { get { return GetMessage(2950); } }
        public string ElecTicket_Remit_Mappings_Amount { get { return GetMessage(1952); } }
        public string ElecTicket_Remit_Mappings_RemitDate { get { return GetMessage(1953); } }
        public string ElecTicket_Remit_Mappings_EndDate { get { return GetMessage(2953); } }
        public string ElecTicket_Remit_Mappings_RemitAccount { get { return GetMessage(1931); } }
        public string ElecTicket_Remit_Mappings_ExchangeName { get { return GetMessage(1954); } }
        public string ElecTicket_Remit_Mappings_ExchangeAccount { get { return GetMessage(1955); } }
        public string ElecTicket_Remit_Mappings_ExchangeOpenBankName { get { return GetMessage(1956); } }
        public string ElecTicket_Remit_Mappings_ExchangeOpenBankNo { get { return GetMessage(1957); } }
        public string ElecTicket_Remit_Mappings_PayeeName { get { return GetMessage(1930); } }
        public string ElecTicket_Remit_Mappings_PayeeAccount { get { return GetMessage(1928); } }
        public string ElecTicket_Remit_Mappings_PayeeOpenBankName { get { return GetMessage(1949); } }
        public string ElecTicket_Remit_Mappings_PayeeOpenBankNo { get { return GetMessage(1958); } }
        public string ElecTicket_Remit_Mappings_CanChange { get { return GetMessage(2963); } }
        public string ElecTicket_Remit_Mappings_CanAutoTipExchange { get { return GetMessage(2964); } }
        public string ElecTicket_Remit_Mappings_CanAutoReceiveTicket { get { return GetMessage(2965); } }
        public string ElecTicket_Remit_Mappings_Note { get { return GetMessage(1959); } }
        public string ElecTicket_Remit_Mappings_TicketType_RegexDescription { get { return GetMessage(2975); } }
        public string ElecTicket_Remit_Mappings_Amount_RegexDescription { get { return GetMessage(2976); } }
        public string ElecTicket_Remit_Mappings_RemitDate_RegexDescription { get { return GetMessage(2977); } }
        public string ElecTicket_Remit_Mappings_EndDate_RegexDescription { get { return GetMessage(2978); } }
        public string ElecTicket_Remit_Mappings_RemitAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_Remit_Mappings_ExchangeName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_Remit_Mappings_ExchangeAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_Remit_Mappings_ExchangeOpenBankName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_Remit_Mappings_ExchangeOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicket_Remit_Mappings_PayeeName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_Remit_Mappings_PayeeAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_Remit_Mappings_PayeeOpenBankName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_Remit_Mappings_PayeeOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicket_Remit_Mappings_CanChange_RegexDescription { get { return GetMessage(2975); } }
        public string ElecTicket_Remit_Mappings_CanAutoTipExchange_RegexDescription { get { return GetMessage(2989); } }
        public string ElecTicket_Remit_Mappings_CanAutoReceiveTicket_RegexDescription { get { return GetMessage(2989); } }
        public string ElecTicket_Remit_Mappings_Note_RegexDescription { get { return GetMessage(2991); } }
        #endregion

        #region 电票背书    30**
        public string ElecTicket_BackNoted_Mappings_Account { get { return GetMessage(1932); } }
        public string ElecTicket_BackNoted_Mappings_TicketSerialNo { get { return GetMessage(1933); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedName { get { return GetMessage(3052); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedAccount { get { return GetMessage(3053); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedOpenBankName { get { return GetMessage(3054); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo { get { return GetMessage(3055); } }
        public string ElecTicket_BackNoted_Mappings_Note { get { return GetMessage(1959); } }
        public string ElecTicket_BackNoted_Mappings_Account_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_BackNoted_Mappings_TicketSerialNo_RegexDescription { get { return GetMessage(3076); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedName_RegexDescription { get { return GetMessage(3077); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedAccount_RegexDescription { get { return GetMessage(3078); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedOpenBankName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicket_BackNoted_Mappings_Note_RegexDescription { get { return GetMessage(2991); } }
        #endregion

        #region 电票自动提示承兑    31**
        public string ElecTicket_AutoTipExchange_Mappings_Account { get { return GetMessage(1932); } }
        public string ElecTicket_AutoTipExchange_Mappings_TicketSerialNo { get { return GetMessage(1933); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeName { get { return GetMessage(1954); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeAccount { get { return GetMessage(1955); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName { get { return GetMessage(1956); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo { get { return GetMessage(1957); } }
        public string ElecTicket_AutoTipExchange_Mappings_BillSerialNo { get { return GetMessage(1960); } }
        public string ElecTicket_AutoTipExchange_Mappings_ContactNo { get { return GetMessage(1961); } }
        public string ElecTicket_AutoTipExchange_Mappings_Note { get { return GetMessage(1959); } }
        public string ElecTicket_AutoTipExchange_Mappings_Account_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_AutoTipExchange_Mappings_TicketSerialNo_RegexDescription { get { return GetMessage(3076); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicket_AutoTipExchange_Mappings_BillSerialNo_RegexDescription { get { return GetMessage(3076); } }
        public string ElecTicket_AutoTipExchange_Mappings_ContactNo_RegexDescription { get { return GetMessage(3076); } }
        public string ElecTicket_AutoTipExchange_Mappings_Note_RegexDescription { get { return GetMessage(2991); } }
        #endregion

        #region 电票贴现    32**
        public string ElecTicket_PayMoney_Mappings_Account { get { return GetMessage(1932); } }
        public string ElecTicket_PayMoney_Mappings_TicketSerialNo { get { return GetMessage(1933); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyType { get { return GetMessage(3252); } }
        public string ElecTicket_PayMoney_Mappings_ClearType { get { return GetMessage(3253); } }
        public string ElecTicket_PayMoney_Mappings_PayDate { get { return GetMessage(3254); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyPercent { get { return GetMessage(3255); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyAccount { get { return GetMessage(3256); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName { get { return GetMessage(3257); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo { get { return GetMessage(3258); } }
        public string ElecTicket_PayMoney_Mappings_StickOnName { get { return GetMessage(3259); } }
        public string ElecTicket_PayMoney_Mappings_StickOnccount { get { return GetMessage(3260); } }
        public string ElecTicket_PayMoney_Mappings_StickOnOpenBankName { get { return GetMessage(3261); } }
        public string ElecTicket_PayMoney_Mappings_StickOnOpenBankNo { get { return GetMessage(3262); } }
        public string ElecTicket_PayMoney_Mappings_IsContainMoney { get { return GetMessage(3263); } }
        public string ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent { get { return GetMessage(3264); } }
        public string ElecTicket_PayMoney_Mappings_BillSerialNo { get { return GetMessage(1960); } }
        public string ElecTicket_PayMoney_Mappings_ContactNo { get { return GetMessage(1961); } }
        public string ElecTicket_PayMoney_Mappings_Note { get { return GetMessage(1959); } }
        public string ElecTicket_PayMoney_Mappings_Buyout { get { return GetMessage(3265); } }
        public string ElecTicket_PayMoney_Mappings_Account_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_PayMoney_Mappings_TicketSerialNo_RegexDescription { get { return GetMessage(3076); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyType_RegexDescription { get { return GetMessage(3277); } }
        public string ElecTicket_PayMoney_Mappings_ClearType_RegexDescription { get { return GetMessage(3278); } }
        public string ElecTicket_PayMoney_Mappings_PayDate_RegexDescription { get { return GetMessage(2977); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyPercent_RegexDescription { get { return GetMessage(3280); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName_RegexDescription { get { return GetMessage(3282); } }
        public string ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicket_PayMoney_Mappings_StickOnName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_PayMoney_Mappings_StickOnccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicket_PayMoney_Mappings_StickOnOpenBankName_RegexDescription { get { return GetMessage(2980); } }
        public string ElecTicket_PayMoney_Mappings_StickOnOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicket_PayMoney_Mappings_IsContainMoney_RegexDescription { get { return GetMessage(2989); } }
        public string ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent_RegexDescription { get { return GetMessage(3289); } }
        public string ElecTicket_PayMoney_Mappings_BillSerialNo_RegexDescription { get { return GetMessage(3290); } }
        public string ElecTicket_PayMoney_Mappings_ContactNo_RegexDescription { get { return GetMessage(3290); } }
        public string ElecTicket_PayMoney_Mappings_Note_RegexDescription { get { return GetMessage(2991); } }
        #endregion

        #region 票据池(银承) 33**
        public string ElecTicketPool_CustomerRef_Exist { get { return GetMessage(3300); } }
        public string ElecTicketPool_RemitDate_Must_be_Early_ExchangeDate { get { return GetMessage(3301); } }
        public string ElecTicketPool_RemitDate_Must_Not_be_Early_EndDate_Harf_Year { get { return GetMessage(3302); } }

        public string ElecTicketPool_CustomerRef { get { return GetMessage(3370); } }
        public string ElecTicketPool_ExchangeBank { get { return GetMessage(3371); } }
        public string ElecTicketPool_ElecTicketSerialNo { get { return GetMessage(1933); } }
        public string ElecTicketPool_Amount { get { return GetMessage(1952); } }
        public string ElecTicketPool_RemitDate { get { return GetMessage(1953); } }
        public string ElecTicketPool_EndDate { get { return GetMessage(3375); } }
        public string ElecTicketPool_RemitName { get { return GetMessage(3376); } }
        public string ElecTicketPool_RemitAccount { get { return GetMessage(1931); } }
        public string ElecTicketPool_ExchangeBankName { get { return GetMessage(3378); } }
        public string ElecTicketPool_ExchangeName { get { return GetMessage(1954); } }
        public string ElecTicketPool_ExchangeAccount { get { return GetMessage(1955); } }
        public string ElecTicketPool_ExchangeBankNo { get { return GetMessage(3381); } }
        public string ElecTicketPool_ExchangeOpenBankName { get { return GetMessage(1956); } }
        public string ElecTicketPool_ExchangeOpenBankNo { get { return GetMessage(3383); } }
        public string ElecTicketPool_ExchangeDate { get { return GetMessage(3384); } }
        public string ElecTicketPool_PayeeName { get { return GetMessage(1930); } }
        public string ElecTicketPool_PayeeAccount { get { return GetMessage(1928); } }
        public string ElecTicketPool_PayeeOpenBankName { get { return GetMessage(1949); } }
        public string ElecTicketPool_PayeeOpenBankNo { get { return GetMessage(1958); } }
        public string ElecTicketPool_PreBackNotedPerson { get { return GetMessage(3389); } }
        public string ElecTicketPool_EndDateOperate { get { return GetMessage(3390); } }
        public string ElecTicketPool_BusinessType { get { return GetMessage(1951); } }
        public string ElecTicketPool_ElecTicketType { get { return GetMessage(3392); } }

        public string ElecTicketPool_CustomerRef_RegexDescription { get { return GetMessage(3340); } }
        public string ElecTicketPool_ExchangeBank_RegexDescription { get { return GetMessage(3341); } }
        public string ElecTicketPool_ElecTicketSerialNo_RegexDescription { get { return GetMessage(3076); } }
        public string ElecTicketPool_Amount_RegexDescription { get { return GetMessage(2976); } }
        public string ElecTicketPool_RemitDate_RegexDescription { get { return GetMessage(3344); } }
        public string ElecTicketPool_EndDate_RegexDescription { get { return GetMessage(3345); } }
        public string ElecTicketPool_RemitName_RegexDescription { get { return GetMessage(3346); } }
        public string ElecTicketPool_RemitAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicketPool_ExchangeBankName_RegexDescription { get { return GetMessage(3348); } }
        public string ElecTicketPool_ExchangeName_RegexDescription { get { return GetMessage(3349); } }
        public string ElecTicketPool_ExchangeAccount_RegexDescription { get { return GetMessage(3350); } }
        public string ElecTicketPool_ExchangeBankNo_RegexDescription { get { return GetMessage(3351); } }
        public string ElecTicketPool_ExchangeOpenBankName_RegexDescription { get { return GetMessage(3352); } }
        public string ElecTicketPool_ExchangeOpenBankNo_RegexDescription { get { return GetMessage(3353); } }
        public string ElecTicketPool_ExchangeDate_RegexDescription { get { return GetMessage(3354); } }
        public string ElecTicketPool_PayeeName_RegexDescription { get { return GetMessage(3346); } }
        public string ElecTicketPool_PayeeAccount_RegexDescription { get { return GetMessage(2979); } }
        public string ElecTicketPool_PayeeOpenBankName_RegexDescription { get { return GetMessage(3346); } }
        public string ElecTicketPool_PayeeOpenBankNo_RegexDescription { get { return GetMessage(2779); } }
        public string ElecTicketPool_PreBackNotedPerson_RegexDescription { get { return GetMessage(3359); } }
        public string ElecTicketPool_EndDateOperate_RegexDescription { get { return GetMessage(3360); } }
        public string ElecTicketPool_BusinessType_RegexDescription { get { return GetMessage(3361); } }
        #endregion

        #region 国际结算--跨境汇款/跨内外币汇款 34**
        public string TransferGlobal_PayDate { get { return GetMessage(3400); } }
        public string TransferGlobal_PaymentType { get { return GetMessage(3401); } }
        public string TransferGlobal_SendPriority { get { return GetMessage(3402); } }
        public string TransferGlobal_PaymentCashType { get { return GetMessage(3403); } }
        public string TransferGlobal_RemitAmount { get { return GetMessage(3404); } }
        public string TransferGlobal_SpotAccount { get { return GetMessage(3405); } }
        public string TransferGlobal_SpotAmount { get { return GetMessage(3406); } }
        public string TransferGlobal_PurchaseAccount { get { return GetMessage(3407); } }
        public string TransferGlobal_PurchaseAmount { get { return GetMessage(3408); } }
        public string TransferGlobal_OtherAccount { get { return GetMessage(3409); } }
        public string TransferGlobal_OtherAmount { get { return GetMessage(3410); } }
        public string TransferGlobal_PayFeeAccount { get { return GetMessage(3411); } }
        public string TransferGlobal_OrgCode { get { return GetMessage(3412); } }
        public string TransferGlobal_RemitName { get { return GetMessage(3413); } }
        public string TransferGlobal_RemitAddress { get { return GetMessage(3414); } }
        public string TransferGlobal_CutomerRef { get { return GetMessage(1942); } }
        public string TransferGlobal_PayeeAccount { get { return GetMessage(1928); } }
        public string TransferGlobal_PayeeName { get { return GetMessage(1930); } }
        public string TransferGlobal_PayeeAddress { get { return GetMessage(3418); } }
        public string TransferGlobal_PayeeCodeofCountry { get { return GetMessage(3419); } }
        public string TransferGlobal_PayeeNameofCountry { get { return GetMessage(3420); } }
        public string TransferGlobal_PayeeOpenBankType { get { return GetMessage(1949); } }
        public string TransferGlobal_PayeeOpenBankSwiftCode { get { return GetMessage(4174); } }
        public string TransferGlobal_PayeeOpenBankName { get { return GetMessage(1949); } }
        public string TransferGlobal_PayeeOpenBankAddress { get { return GetMessage(3422); } }
        public string TransferGlobal_CorrespondentBankName { get { return GetMessage(3423); } }
        public string TransferGlobal_CorrespondentBankSwiftCode { get { return GetMessage(4176); } }
        public string TransferGlobal_CorrespondentBankAddress { get { return GetMessage(3424); } }
        public string TransferGlobal_PayeeAccountInCorrespondentBank { get { return GetMessage(3425); } }
        public string TransferGlobal_RemitNote { get { return GetMessage(3426); } }
        public string TransferGlobal_AssumeFeeType { get { return GetMessage(3427); } }
        public string TransferGlobal_PayFeeType { get { return GetMessage(3428); } }
        public string TransferGlobal_DealSerialNoF { get { return GetMessage(3429); } }
        public string TransferGlobal_AmountF { get { return GetMessage(3430); } }
        public string TransferGlobal_DealNoteF { get { return GetMessage(3431); } }
        public string TransferGlobal_DealSerialNoS { get { return GetMessage(3432); } }
        public string TransferGlobal_AmountS { get { return GetMessage(3433); } }
        public string TransferGlobal_DealNoteS { get { return GetMessage(3434); } }
        public string TransferGlobal_IsPayOffLine { get { return GetMessage(3435); } }
        public string TransferGlobal_ContactNo { get { return GetMessage(1962); } }
        public string TransferGlobal_BillSerialNo { get { return GetMessage(1963); } }
        public string TransferGlobal_BatchNoOrTNoOrSerialNo { get { return GetMessage(3438); } }
        public string TransferGlobal_ProposerName { get { return GetMessage(3439); } }
        public string TransferGlobal_Telephone { get { return GetMessage(3440); } }
        public string TransferGlobal_PaymentPropertyType { get { return GetMessage(3441); } }
        public string TransferGlobal_PayeeCountry { get { return GetMessage(3442); } }
        public string TransferGlobal_Select_One_of_Three_Account { get { return GetMessage(3443); } }
        public string TransferGlobal_BarBusinessType { get { return GetMessage(3444); } }
        public string TransferGlobal_BarApplyFlagType { get { return GetMessage(3445); } }
        public string TransferGlobal_PayDate_RegexDescription { get { return GetMessage(2977); } }
        public string TransferGlobal_PaymentType_RegexDescription { get { return GetMessage(3451); } }
        public string TransferGlobal_SendPriority_RegexDescription { get { return GetMessage(3452); } }
        public string TransferGlobal_PaymentCashType_RegexDescription { get { return GetMessage(3453); } }
        public string TransferGlobal_RemitAmount_RegexDescription { get { return GetMessage(2270); } }
        public string TransferGlobal_SpotAccount_RegexDescription { get { return GetMessage(3455); } }
        public string TransferGlobal_SpotAmount_RegexDescription { get { return GetMessage(3456); } }
        public string TransferGlobal_PurchaseAccount_RegexDescription { get { return GetMessage(3455); } }
        public string TransferGlobal_PurchaseAmount_RegexDescription { get { return GetMessage(3458); } }
        public string TransferGlobal_OtherAccount_RegexDescription { get { return GetMessage(3455); } }
        public string TransferGlobal_OtherAmount_RegexDescription { get { return GetMessage(3460); } }
        public string TransferGlobal_PayFeeAccount_RegexDescription { get { return GetMessage(3461); } }
        public string TransferGlobal_OrgCode_RegexDescription { get { return GetMessage(3462); } }
        public string TransferGlobal_RemitName_RegexDescription { get { return GetMessage(3463); } }
        public string TransferGlobal_RemitAddress_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CutomerRef_RegexDescription { get { return GetMessage(3465); } }
        public string TransferGlobal_PayeeAccount_RegexDescription { get { return GetMessage(3466); } }
        public string TransferGlobal_PayeeName_RegexDescription { get { return GetMessage(3463); } }
        public string TransferGlobal_PayeeAddress_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeCodeofCountry_RegexDescription { get { return GetMessage(3469); } }
        public string TransferGlobal_PayeeNameofCountry_RegexDescription { get { return GetMessage(3470); } }
        public string TransferGlobal_PayeeOpenBankName_RegexDescription { get { return GetMessage(3463); } }
        public string TransferGlobal_PayeeOpenBankSwiftCode_RegexDescription { get { return GetMessage(3497); } }
        public string TransferGlobal_PayeeOpenBankAddress_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CorrespondentBankName_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CorrespondentBankSwiftCode_RegexDescription { get { return GetMessage(3497); } }
        public string TransferGlobal_CorrespondentBankAddress_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeAccountInCorrespondentBank_RegexDescription { get { return GetMessage(3475); } }
        public string TransferGlobal_RemitNote_RegexDescription { get { return GetMessage(3476); } }
        public string TransferGlobal_AssumeFeeType_RegexDescription { get { return GetMessage(3477); } }
        public string TransferGlobal_PayFeeType_RegexDescription { get { return GetMessage(3478); } }
        public string TransferGlobal_DealSerialNoF_RegexDescription { get { return GetMessage(3479); } }
        public string TransferGlobal_AmountF_RegexDescription { get { return GetMessage(3480); } }
        public string TransferGlobal_DealNoteF_RegexDescription { get { return GetMessage(3481); } }
        public string TransferGlobal_DealSerialNoS_RegexDescription { get { return GetMessage(3479); } }
        public string TransferGlobal_AmountS_RegexDescription { get { return GetMessage(3483); } }
        public string TransferGlobal_DealNoteS_RegexDescription { get { return GetMessage(3481); } }
        public string TransferGlobal_IsPayOffLine_RegexDescription { get { return GetMessage(3485); } }
        public string TransferGlobal_ContactNo_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_BillSerialNo_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_BatchNoOrTNoOrSerialNo_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_ProposerName_RegexDescription { get { return GetMessage(3489); } }
        public string TransferGlobal_Telephone_RegexDescription { get { return GetMessage(3490); } }
        public string TransferGlobal_PayeeOpenBankType_RegexDescription { get { return GetMessage(3491); } }
        public string TransferGlobal_PaymentPropertyType_RegexDescription { get { return GetMessage(3492); } }
        public string TransferGlobal_BarBusinessType_RegexDescription { get { return GetMessage(3493); } }
        public string TransferGlobal_BarApplyFlagType_RegexDescription { get { return GetMessage(3494); } }
        public string TransferGlobal_AssumeFeeType_Country_RegexDescription { get { return GetMessage(3495); } }
        public string TransferGlobal_PayFeeType_Country_RegexDescription { get { return GetMessage(3496); } }
        public string TransferGlobal_PayeeAccountInCorrespondentBank_FM_RegexDescription { get { return GetMessage(3498); } }
        #endregion

        #region 供应链--订单信息   35**
        public string SpplyFinancingOrder_OrderNo { get { return GetMessage(3570); } }
        public string SpplyFinancingOrder_CashType { get { return GetMessage(3571); } }
        public string SpplyFinancingOrder_Amount { get { return GetMessage(1964); } }
        public string SpplyFinancingOrder_ERPCode_Seller { get { return GetMessage(3573); } }
        public string SpplyFinancingOrder_CustomerNo_Seller { get { return GetMessage(3574); } }
        public string SpplyFinancingOrder_PayDate_Seller { get { return GetMessage(3575); } }
        public string SpplyFinancingOrder_CustomerName_Purchase { get { return GetMessage(1965); } }
        public string SpplyFinancingOrder_PayDate_Purchase { get { return GetMessage(3577); } }
        public string SpplyFinancingOrderMgr_PayAmountForThisTime { get { return GetMessage(3578); } }
        public string SpplyFinancingOrder_OrderNo_RegexDescription { get { return GetMessage(3585); } }
        public string SpplyFinancingOrder_CashType_RegexDescription { get { return GetMessage(3586); } }
        public string SpplyFinancingOrder_Amount_RegexDescription { get { return GetMessage(2270); } }
        public string SpplyFinancingOrder_ERPCode_Seller_RegexDescription { get { return GetMessage(3588); } }
        public string SpplyFinancingOrder_CustomerNo_Seller_RegexDescription { get { return GetMessage(3589); } }
        public string SpplyFinancingOrder_PayDate_RegexDescription { get { return GetMessage(3344); } }
        public string SpplyFinancingOrder_CustomerName_Purchase_RegexDescription { get { return GetMessage(3591); } }
        #endregion

        #region 供应链--应收账款发票 36**
        public string SpplyFinancingBill_BillSerialNo_Exist_Add_Failed { get { return GetMessage(3601); } }
        public string SpplyFinancingBill_BillSerialNo_Exist_Edit_Failed { get { return GetMessage(3602); } }
        public string SpplyFinancingBill_BillSerialNo { get { return GetMessage(1963); } }
        public string SpplyFinancingBill_ContractNo { get { return GetMessage(1962); } }
        public string SpplyFinancingBill_CustomerNo_Seller { get { return GetMessage(1966); } }
        public string SpplyFinancingBill_CustomerName_Seller { get { return GetMessage(1967); } }
        public string SpplyFinancingBill_CashType { get { return GetMessage(1968); } }
        public string SpplyFinancingBill_Amount { get { return GetMessage(1969); } }
        public string SpplyFinancingBill_BillDate { get { return GetMessage(1970); } }
        public string SpplyFinancingBill_StartDate { get { return GetMessage(3677); } }
        public string SpplyFinancingBill_EndDate { get { return GetMessage(1972); } }
        public string SpplyFinancingBill_CustomerNo_Purchase { get { return GetMessage(1971); } }
        public string SpplyFinancingBill_CustomerName_Purchase { get { return GetMessage(1965); } }
        public string SpplyFinancingBill_BillSerialNo_RegexDescription { get { return GetMessage(3685); } }
        public string SpplyFinancingBill_ContractNo_RegexDescription { get { return GetMessage(3686); } }
        public string SpplyFinancingBill_CustomerNo_RegexDescription { get { return GetMessage(3687); } }
        public string SpplyFinancingBill_CustomerName_RegexDescription { get { return GetMessage(3688); } }
        public string SpplyFinancingBill_CashType_RegexDescription { get { return GetMessage(3586); } }
        public string SpplyFinancingBill_Amount_RegexDescription { get { return GetMessage(2270); } }
        public string SpplyFinancingBill_BillDate_RegexDescription { get { return GetMessage(3691); } }
        public string SpplyFinancingBill_StartDate_RegexDescription { get { return GetMessage(3691); } }
        public string SpplyFinancingBill_EndDate_RegexDescription { get { return GetMessage(3691); } }
        #endregion

        #region 供应链--应收账款收付款    37**
        public string SpplyFinancingPayOrReceipt_BillSerialNo_Exist_Add_Failed { get { return GetMessage(3601); } }
        public string SpplyFinancingPayOrReceipt_BillSerialNo_Exist_Edit_Failed { get { return GetMessage(3602); } }
        public string SpplyFinancingPayOrReceipt_BillSerialNo { get { return GetMessage(1963); } }
        public string SpplyFinancingPayOrReceipt_CustomerNo { get { return GetMessage(3780); } }
        public string SpplyFinancingPayOrReceipt_CustomerName { get { return GetMessage(3781); } }
        public string SpplyFinancingPayOrReceipt_CashType { get { return GetMessage(1968); } }
        public string SpplyFinancingPayOrReceipt_AmountThisTime { get { return GetMessage(3782); } }
        public string SpplyFinancingPayOrReceipt_BillSerialNo_RegexDescription { get { return GetMessage(3685); } }
        public string SpplyFinancingPayOrReceipt_CustomerNo_RegexDescription { get { return GetMessage(3685); } }
        public string SpplyFinancingPayOrReceipt_CustomerName_RegexDescription { get { return GetMessage(3688); } }
        public string SpplyFinancingPayOrReceipt_CashType_RegexDescription { get { return GetMessage(3586); } }
        public string SpplyFinancingPayOrReceipt_AmountThisTime_RegexDescription { get { return GetMessage(3789); } }

        #endregion

        #region 供应链--经销商融资申请    38**
        public string SpplyFinancingApply_ContractOrOrderNo { get { return GetMessage(3870); } }
        public string SpplyFinancingApply_OrderDate { get { return GetMessage(3871); } }
        public string SpplyFinancingApply_CashType { get { return GetMessage(3872); } }
        public string SpplyFinancingApply_OrderAmount { get { return GetMessage(1964); } }
        public string SpplyFinancingApply_DeliveryDate { get { return GetMessage(3874); } }
        public string SpplyFinancingApply_SettlementType { get { return GetMessage(3875); } }
        public string SpplyFinancingApply_TaxInvoiceNo { get { return GetMessage(3876); } }
        public string SpplyFinancingApply_ReceiptNo { get { return GetMessage(3877); } }
        public string SpplyFinancingApply_RiskTakingLetterNo { get { return GetMessage(3878); } }
        public string SpplyFinancingApply_GoodsDesc { get { return GetMessage(3879); } }
        public string SpplyFinancingApply_ApplyAmount { get { return GetMessage(3880); } }
        public string SpplyFinancingApply_ApplyDays { get { return GetMessage(3881); } }
        public string SpplyFinancingApply_AgrementNo { get { return GetMessage(3882); } }
        public string SpplyFinancingApply_InterestFloatType { get { return GetMessage(3883); } }
        public string SpplyFinancingApply_InterestFloatingPercent { get { return GetMessage(3884); } }
        public string SpplyFinancingApply_ContractOrOrderNo_RegexDescription { get { return GetMessage(3885); } }
        public string SpplyFinancingApply_OrderDate_RegexDescription { get { return GetMessage(2277); } }
        public string SpplyFinancingApply_CashType_RegexDescription { get { return GetMessage(3586); } }
        public string SpplyFinancingApply_OrderAmount_RegexDescription { get { return GetMessage(2270); } }
        public string SpplyFinancingApply_DeliveryDate_RegexDescription { get { return GetMessage(2277); } }
        public string SpplyFinancingApply_SettlementType_RegexDescription { get { return GetMessage(3890); } }
        public string SpplyFinancingApply_TaxInvoiceNo_RegexDescription { get { return GetMessage(3885); } }
        public string SpplyFinancingApply_ReceiptNo_RegexDescription { get { return GetMessage(3686); } }
        public string SpplyFinancingApply_RiskTakingLetterNo_RegexDescription { get { return GetMessage(3885); } }
        public string SpplyFinancingApply_GoodsDesc_RegexDescription { get { return GetMessage(3894); } }
        public string SpplyFinancingApply_ApplyAmount_RegexDescription { get { return GetMessage(2270); } }
        public string SpplyFinancingApply_ApplyDays_RegexDescription { get { return GetMessage(3896); } }
        public string SpplyFinancingApply_AgrementNo_RegexDescription { get { return GetMessage(3885); } }
        public string SpplyFinancingApply_InterestFloatType_RegexDescription { get { return GetMessage(3898); } }
        public string SpplyFinancingApply_InterestFloatingPercent_RegexDescription { get { return GetMessage(3899); } }
        #endregion

        #region 主动调拨    39**
        public string InitiativeAllot_AccountOut { get { return GetMessage(3970); } }
        public string InitiativeAllot_NameOut { get { return GetMessage(3971); } }
        public string InitiativeAllot_AccountIn { get { return GetMessage(3972); } }
        public string InitiativeAllot_NameIn { get { return GetMessage(3973); } }
        public string InitiativeAllot_CashType { get { return GetMessage(3974); } }
        public string InitiativeAllot_Amount { get { return GetMessage(1974); } }
        public string InitiativeAllot_Addition { get { return GetMessage(1944); } }
        public string InitiativeAllot_Batch_ProtecolNo { get { return GetMessage(1942); } }
        public string InitiativeAllot_Batch_PayDate { get { return GetMessage(1946); } }
        public string InitiativeAllot_AccountOut_RegexDescription { get { return GetMessage(3985); } }
        public string InitiativeAllot_NameOut_RegexDescription { get { return GetMessage(3986); } }
        public string InitiativeAllot_AccountIn_RegexDescription { get { return GetMessage(3985); } }
        public string InitiativeAllot_NameIn_RegexDescription { get { return GetMessage(3986); } }
        public string InitiativeAllot_CashType_RegexDescription { get { return GetMessage(3586); } }
        public string InitiativeAllot_Amount_RegexDescription { get { return GetMessage(2270); } }
        public string InitiativeAllot_Addition_RegexDescription { get { return GetMessage(3991); } }
        public string InitiativeAllot_Batch_ProtecolNo_RegexDescription { get { return GetMessage(3992); } }
        public string InitiativeAllot_Batch_PayDate_RegexDescription { get { return GetMessage(2277); } }
        #endregion

        #region 人民币统一支付 40**
        public string UnitivePaymentRMB_PayerAccount { get { return GetMessage(4024); } }
        public string UnitivePaymentRMB_PayerName { get { return GetMessage(4025); } }
        public string UnitivePaymentRMB_PayeeAccount { get { return GetMessage(1928); } }
        public string UnitivePaymentRMB_PayeeName { get { return GetMessage(1930); } }
        public string UnitivePaymentRMB_BankType { get { return GetMessage(4028); } }
        public string UnitivePaymentRMB_PayeeCNAPS { get { return GetMessage(4029); } }
        public string UnitivePaymentRMB_PayeeOpenBankName { get { return GetMessage(1949); } }
        public string UnitivePaymentRMB_NominalPayerAccount { get { return GetMessage(4031); } }
        public string UnitivePaymentRMB_NominalPayerName { get { return GetMessage(4032); } }
        public string UnitivePaymentRMB_Amount { get { return GetMessage(4033); } }
        public string UnitivePaymentRMB_Purpose { get { return GetMessage(4034); } }
        public string UnitivePaymentRMB_UnitivePaymentType { get { return GetMessage(3428); } }
        public string UnitivePaymentRMB_OrderPayDate { get { return GetMessage(1946); } }
        public string UnitivePaymentRMB_CustomerBusinissNo { get { return GetMessage(1942); } }
        public string UnitivePaymentRMB_TransferChanelType { get { return GetMessage(4038); } }
        public string UnitivePaymentRMB_IsTipPayee { get { return GetMessage(4039); } }
        public string UnitivePaymentRMB_TipPayeePhone { get { return GetMessage(4040); } }

        public string UnitivePaymentRMB_PayerAccount_RegexDescription { get { return GetMessage(4041); } }
        public string UnitivePaymentRMB_PayerName_RegexDescription { get { return GetMessage(4042); } }
        public string UnitivePaymentRMB_PayeeAccount_RegexDescription { get { return GetMessage(4043); } }
        public string UnitivePaymentRMB_PayeeName_RegexDescription { get { return GetMessage(4044); } }
        public string UnitivePaymentRMB_BankType_RegexDescription { get { return GetMessage(4045); } }
        public string UnitivePaymentRMB_PayeeCNAPS_RegexDescription { get { return GetMessage(4046); } }
        public string UnitivePaymentRMB_PayeeOpenBankName_RegexDescription { get { return GetMessage(4047); } }
        public string UnitivePaymentRMB_NominalPayerAccount_RegexDescription { get { return GetMessage(4048); } }
        public string UnitivePaymentRMB_NominalPayerName_RegexDescription { get { return GetMessage(4049); } }
        public string UnitivePaymentRMB_Amount_RegexDescription { get { return GetMessage(4050); } }
        public string UnitivePaymentRMB_Purpose_RegexDescription { get { return GetMessage(4051); } }
        public string UnitivePaymentRMB_UnitivePaymentType_RegexDescription { get { return GetMessage(4052); } }
        public string UnitivePaymentRMB_OrderPayDate_RegexDescription { get { return GetMessage(4053); } }
        public string UnitivePaymentRMB_CustomerBusinissNo_RegexDescription { get { return GetMessage(4054); } }
        public string UnitivePaymentRMB_TransferChanelType_RegexDescription { get { return GetMessage(4055); } }
        public string UnitivePaymentRMB_IsTipPayee_RegexDescription { get { return GetMessage(4056); } }
        public string UnitivePaymentRMB_TipPayeePhone_RegexDescription { get { return GetMessage(4057); } }
        #endregion

        #region 外币统一支付  41**
        public string UnitivePaymentFC_PayerAccount { get { return GetMessage(4158); } }
        public string UnitivePaymentFC_PayerName { get { return GetMessage(4159); } }
        public string UnitivePaymentFC_NominalPayerName { get { return GetMessage(4160); } }
        public string UnitivePaymentFC_NominalPayerAccount { get { return GetMessage(4161); } }
        public string UnitivePaymentFC_CashType { get { return GetMessage(3974); } }
        public string UnitivePaymentFC_OrderPayDate { get { return GetMessage(1946); } }
        public string UnitivePaymentFC_SendPriority { get { return GetMessage(3402); } }
        public string UnitivePaymentFC_Amount { get { return GetMessage(3404); } }
        public string UnitivePaymentFC_OrgCode { get { return GetMessage(3412); } }
        public string UnitivePaymentFC_CustomerBusinissNo { get { return GetMessage(1942); } }
        public string UnitivePaymentFC_Addtion { get { return GetMessage(1944); } }
        public string UnitivePaymentFC_PayeeAccount { get { return GetMessage(1928); } }
        public string UnitivePaymentFC_PayeeName { get { return GetMessage(1930); } }
        public string UnitivePaymentFC_Address { get { return GetMessage(3418); } }
        public string UnitivePaymentFC_PayeeOpenBankName { get { return GetMessage(1949); } }
        public string UnitivePaymentFC_OpenBankAddress { get { return GetMessage(3422); } }
        public string UnitivePaymentFC_PayeeOpenBankSwiftCode { get { return GetMessage(4174); } }
        public string UnitivePaymentFC_CorrespondentBankName { get { return GetMessage(3423); } }
        public string UnitivePaymentFC_CorrespondentBankSwiftCode { get { return GetMessage(4176); } }
        public string UnitivePaymentFC_PayeeAccountInCorrespondentBank { get { return GetMessage(3425); } }
        public string UnitivePaymentFC_CorrespondentBankAddress { get { return GetMessage(3424); } }
        public string UnitivePaymentFC_CodeofCountry { get { return GetMessage(4179); } }
        public string UnitivePaymentFC_IsNoSavePay { get { return GetMessage(4180); } }
        public string UnitivePaymentFC_UnitivePaymentType { get { return GetMessage(3428); } }
        public string UnitivePaymentFC_PaymentNature { get { return GetMessage(4182); } }
        public string UnitivePaymentFC_TransactionCode1 { get { return GetMessage(3429); } }
        public string UnitivePaymentFC_TransactionCode2 { get { return GetMessage(3432); } }
        public string UnitivePaymentFC_IPPSMoneyTypeAmount1 { get { return GetMessage(4185); } }
        public string UnitivePaymentFC_IPPSMoneyTypeAmount2 { get { return GetMessage(4186); } }
        public string UnitivePaymentFC_TransactionAddtion1 { get { return GetMessage(4187); } }
        public string UnitivePaymentFC_TransactionAddtion2 { get { return GetMessage(4188); } }
        public string UnitivePaymentFC_IsPayOffLineString { get { return GetMessage(4189); } }
        public string UnitivePaymentFC_ContractNo { get { return GetMessage(4190); } }
        public string UnitivePaymentFC_InvoiceNo { get { return GetMessage(4191); } }
        public string UnitivePaymentFC_BatchNoOrTNoOrSerialNo { get { return GetMessage(4192); } }
        public string UnitivePaymentFC_ApplicantName { get { return GetMessage(4193); } }
        public string UnitivePaymentFC_Contactnumber { get { return GetMessage(4194); } }
        public string UnitivePaymentFC_Purpose { get { return GetMessage(4195); } }
        public string UnitivePaymentFC_realPayAddress { get { return GetMessage(4196); } }
        public string UnitivePaymentFC_AccountBankType { get { return GetMessage(4197); } }
        public string UnitivePaymentFC_PaymentCountryOrArea { get { return GetMessage(4198); } }
        public string UnitivePaymentFC_PayeeAccountType { get { return GetMessage(4316); } }
        public string UnitivePaymentFC_FCPayeeAccountType { get { return GetMessage(4319); } }

        public string UnitivePaymentFC_PayerAccount_RegexDescription { get { return GetMessage(4199); } }
        public string UnitivePaymentFC_PayerName_RegexDescription { get { return GetMessage(4100); } }
        public string UnitivePaymentFC_NominalPayerName_RegexDescription { get { return GetMessage(4101); } }
        public string UnitivePaymentFC_NominalPayerAccount_RegexDescription { get { return GetMessage(4102); } }
        public string UnitivePaymentFC_CashType_RegexDescription { get { return GetMessage(4103); } }
        public string UnitivePaymentFC_OrderPayDate_RegexDescription { get { return GetMessage(4104); } }
        public string UnitivePaymentFC_SendPriority_RegexDescription { get { return GetMessage(4106); } }
        public string UnitivePaymentFC_Amount_RegexDescription { get { return GetMessage(4107); } }
        public string UnitivePaymentFC_OrgCode_RegexDescription { get { return GetMessage(4108); } }
        public string UnitivePaymentFC_CustomerBusinissNo_RegexDescription { get { return GetMessage(4109); } }
        public string UnitivePaymentFC_Addtion_RegexDescription { get { return GetMessage(4110); } }
        public string UnitivePaymentFC_PayeeAccount_RegexDescription { get { return GetMessage(4111); } }
        public string UnitivePaymentFC_PayeeName_RegexDescription { get { return GetMessage(4112); } }
        public string UnitivePaymentFC_Address_RegexDescription { get { return GetMessage(4113); } }
        public string UnitivePaymentFC_PayeeOpenBankName_RegexDescription { get { return GetMessage(4114); } }
        public string UnitivePaymentFC_OpenBankAddress_RegexDescription { get { return GetMessage(4115); } }
        public string UnitivePaymentFC_PayeeOpenBankSwiftCode_RegexDescription { get { return GetMessage(4116); } }
        public string UnitivePaymentFC_CorrespondentBankName_RegexDescription { get { return GetMessage(4117); } }
        public string UnitivePaymentFC_CorrespondentBankSwiftCode_RegexDescription { get { return GetMessage(4116); } }
        public string UnitivePaymentFC_PayeeAccountInCorrespondentBank_RegexDescription { get { return GetMessage(4119); } }
        public string UnitivePaymentFC_CorrespondentBankAddress_RegexDescription { get { return GetMessage(4120); } }
        public string UnitivePaymentFC_CodeofCountry_RegexDescription { get { return GetMessage(4121); } }
        public string UnitivePaymentFC_IsNoSavePay_RegexDescription { get { return GetMessage(4122); } }
        public string UnitivePaymentFC_UnitivePaymentType_RegexDescription { get { return GetMessage(4123); } }
        public string UnitivePaymentFC_PaymentNature_RegexDescription { get { return GetMessage(4124); } }
        public string UnitivePaymentFC_TransactionCode1_RegexDescription { get { return GetMessage(4125); } }
        public string UnitivePaymentFC_TransactionCode2_RegexDescription { get { return GetMessage(4125); } }
        public string UnitivePaymentFC_IPPSMoneyTypeAmount1_RegexDescription { get { return GetMessage(4127); } }
        public string UnitivePaymentFC_IPPSMoneyTypeAmount2_RegexDescription { get { return GetMessage(4128); } }
        public string UnitivePaymentFC_TransactionAddtion1_RegexDescription { get { return GetMessage(4129); } }
        public string UnitivePaymentFC_TransactionAddtion2_RegexDescription { get { return GetMessage(4130); } }
        public string UnitivePaymentFC_IsPayOffLineString_RegexDescription { get { return GetMessage(4131); } }
        public string UnitivePaymentFC_ContractNo_RegexDescription { get { return GetMessage(4132); } }
        public string UnitivePaymentFC_InvoiceNo_RegexDescription { get { return GetMessage(4133); } }
        public string UnitivePaymentFC_BatchNoOrTNoOrSerialNo_RegexDescription { get { return GetMessage(4134); } }
        public string UnitivePaymentFC_ApplicantName_RegexDescription { get { return GetMessage(4135); } }
        public string UnitivePaymentFC_Contactnumber_RegexDescription { get { return GetMessage(4136); } }
        public string UnitivePaymentFC_Purpose_RegexDescription { get { return GetMessage(4137); } }
        public string UnitivePaymentFC_realPayAddress_RegexDescription { get { return GetMessage(4138); } }
        public string UnitivePaymentFC_AccountBankType_RegexDescription { get { return GetMessage(4139); } }
        public string UnitivePaymentFC_PaymentCountryOrArea_RegexDescription { get { return GetMessage(4140); } }
        public string UnitivePaymentFC_PayeeAccountType_RegexDescription { get { return GetMessage(4317); } }
        public string UnitivePaymentFC_FCPayeeAccountType_RegexDescription { get { return GetMessage(4318); } }
        #endregion

        #region 境内外币汇款/跨境汇款（柜台）  42**
        public string TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC { get { return GetMessage(4207); } }
        public string TransferGlobal_CorrespondentBankSwiftCode_Bar_OC { get { return GetMessage(4208); } }
        public string TransferGlobal_PaymentType_Bar_FM_RegexDescription { get { return GetMessage(3451); } }
        public string TransferGlobal_SendPriority_Bar_FM_RegexDescription { get { return GetMessage(3452); } }
        public string TransferGlobal_PaymentCashType_Bar_FM_RegexDescription { get { return GetMessage(4202); } }
        public string TransferGlobal_RemitAmount_Bar_FM_RegexDescription { get { return GetMessage(2270); } }
        public string TransferGlobal_SpotAccount_Bar_FM_RegexDescription { get { return GetMessage(4204); } }
        public string TransferGlobal_SpotAmount_Bar_FM_RegexDescription { get { return GetMessage(3456); } }
        public string TransferGlobal_PayFeeAccount_Bar_FM_RegexDescription { get { return GetMessage(4206); } }
        public string TransferGlobal_OrgCode_Bar_FM_RegexDescription { get { return GetMessage(3462); } }
        public string TransferGlobal_RemitAddress_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CutomerRef_Bar_FM_RegexDescription { get { return GetMessage(3465); } }
        public string TransferGlobal_PayeeAccount_Bar_FM_RegexDescription { get { return GetMessage(3466); } }
        public string TransferGlobal_PayeeName_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeAddress_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeCodeofCountry_Bar_FM_RegexDescription { get { return GetMessage(3469); } }
        public string TransferGlobal_PayeeNameofCountry_Bar_FM_RegexDescription { get { return GetMessage(3470); } }
        public string TransferGlobal_PayeeOpenBankName_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeOpenBankSwiftCode_Bar_FM_RegexDescription { get { return GetMessage(4200); } }
        public string TransferGlobal_PayeeOpenBankAddress_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CorrespondentBankName_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CorrespondentBankAddress_Bar_FM_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeAccountInCorrespondentBank_Bar_FM_RegexDescription { get { return GetMessage(3498); } }
        public string TransferGlobal_RemitNote_Bar_FM_RegexDescription { get { return GetMessage(3476); } }
        public string TransferGlobal_AssumeFeeType_Bar_FM_RegexDescription { get { return GetMessage(3495); } }
        public string TransferGlobal_PayFeeType_Bar_FM_RegexDescription { get { return GetMessage(3496); } }
        public string TransferGlobal_PaymentPropertyType_Bar_FM_RegexDescription { get { return GetMessage(4201); } }
        public string TransferGlobal_DealSerialNoF_Bar_FM_RegexDescription { get { return GetMessage(3479); } }
        public string TransferGlobal_AmountF_Bar_FM_RegexDescription { get { return GetMessage(3480); } }
        public string TransferGlobal_DealNoteF_Bar_FM_RegexDescription { get { return GetMessage(3481); } }
        public string TransferGlobal_DealSerialNoS_Bar_FM_RegexDescription { get { return GetMessage(3479); } }
        public string TransferGlobal_AmountS_Bar_FM_RegexDescription { get { return GetMessage(3483); } }
        public string TransferGlobal_DealNoteS_Bar_FM_RegexDescription { get { return GetMessage(3481); } }
        public string TransferGlobal_IsPayOffLine_Bar_FM_RegexDescription { get { return GetMessage(3485); } }
        public string TransferGlobal_ContactNo_Bar_FM_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_BillSerialNo_Bar_FM_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_BatchNoOrTNoOrSerialNo_Bar_FM_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_ProposerName_Bar_FM_RegexDescription { get { return GetMessage(3489); } }
        public string TransferGlobal_Telephone_Bar_FM_RegexDescription { get { return GetMessage(3490); } }
        public string TransferGlobal_PaymentType_Bar_OC_RegexDescription { get { return GetMessage(3451); } }
        public string TransferGlobal_SendPriority_Bar_OC_RegexDescription { get { return GetMessage(3452); } }
        public string TransferGlobal_PaymentCashType_Bar_OC_RegexDescription { get { return GetMessage(4203); } }
        public string TransferGlobal_RemitAmount_Bar_OC_RegexDescription { get { return GetMessage(2270); } }
        public string TransferGlobal_SpotAccount_Bar_OC_RegexDescription { get { return GetMessage(4204); } }
        public string TransferGlobal_SpotAmount_Bar_OC_RegexDescription { get { return GetMessage(3456); } }
        public string TransferGlobal_PurchaseAccount_Bar_OC_RegexDescription { get { return GetMessage(4204); } }
        public string TransferGlobal_PurchaseAmount_Bar_OC_RegexDescription { get { return GetMessage(3458); } }
        public string TransferGlobal_PayFeeAccount_Bar_OC_RegexDescription { get { return GetMessage(4205); } }
        public string TransferGlobal_OrgCode_Bar_OC_RegexDescription { get { return GetMessage(3462); } }
        public string TransferGlobal_RemitName_Bar_OC_RegexDescription { get { return GetMessage(3463); } }
        public string TransferGlobal_RemitAddress_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeAccount_Bar_OC_RegexDescription { get { return GetMessage(3466); } }
        public string TransferGlobal_PayeeName_Bar_OC_RegexDescription { get { return GetMessage(3463); } }
        public string TransferGlobal_PayeeAddress_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeCodeofCountry_Bar_OC_RegexDescription { get { return GetMessage(3469); } }
        public string TransferGlobal_PayeeNameofCountry_Bar_OC_RegexDescription { get { return GetMessage(3470); } }
        public string TransferGlobal_PayeeOpenBankName_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC_RegexDescription { get { return GetMessage(4200); } }
        public string TransferGlobal_PayeeOpenBankAddress_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CorrespondentBankName_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_CorrespondentBankSwiftCode_Bar_OC_RegexDescription { get { return GetMessage(3497); } }
        public string TransferGlobal_CorrespondentBankAddress_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_PayeeAccountInCorrespondentBank_Bar_OC_RegexDescription { get { return GetMessage(3475); } }
        public string TransferGlobal_RemitNote_Bar_OC_RegexDescription { get { return GetMessage(3464); } }
        public string TransferGlobal_AssumeFeeType_Bar_OC_RegexDescription { get { return GetMessage(3495); } }
        public string TransferGlobal_PayFeeType_Bar_OC_RegexDescription { get { return GetMessage(3496); } }
        public string TransferGlobal_PaymentPropertyType_Bar_OC_RegexDescription { get { return GetMessage(4201); } }
        public string TransferGlobal_DealSerialNoF_Bar_OC_RegexDescription { get { return GetMessage(3479); } }
        public string TransferGlobal_AmountF_Bar_OC_RegexDescription { get { return GetMessage(3480); } }
        public string TransferGlobal_DealNoteF_Bar_OC_RegexDescription { get { return GetMessage(3481); } }
        public string TransferGlobal_DealSerialNoS_Bar_OC_RegexDescription { get { return GetMessage(3479); } }
        public string TransferGlobal_AmountS_Bar_OC_RegexDescription { get { return GetMessage(3483); } }
        public string TransferGlobal_DealNoteS_Bar_OC_RegexDescription { get { return GetMessage(3481); } }
        public string TransferGlobal_IsPayOffLine_Bar_OC_RegexDescription { get { return GetMessage(3485); } }
        public string TransferGlobal_ContactNo_Bar_OC_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_BillSerialNo_Bar_OC_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_BatchNoOrTNoOrSerialNo_Bar_OC_RegexDescription { get { return GetMessage(3486); } }
        public string TransferGlobal_ProposerName_Bar_OC_RegexDescription { get { return GetMessage(3489); } }
        public string TransferGlobal_Telephone_Bar_OC_RegexDescription { get { return GetMessage(3490); } }
        #endregion

        #region 内部账户转账    43**
        public string Virtual_AccountOut { get { return GetMessage(4300); } }
        public string Virtual_NameOut { get { return GetMessage(4301); } }
        public string Virtual_AccountIn { get { return GetMessage(4302); } }
        public string Virtual_NameIn { get { return GetMessage(4303); } }
        public string Virtual_CashType { get { return GetMessage(4304); } }
        public string Virtual_Amount { get { return GetMessage(4305); } }
        public string Virtual_Pursion { get { return GetMessage(4306); } }
        public string Virtual_CustomerBusinissNo { get { return GetMessage(4307); } }
        public string Virtual_AccountOut_RegexDescription { get { return GetMessage(4308); } }
        public string Virtual_NameOut_RegexDescription { get { return GetMessage(4309); } }
        public string Virtual_AccountIn_RegexDescription { get { return GetMessage(4310); } }
        public string Virtual_NameIn_RegexDescription { get { return GetMessage(4311); } }
        public string Virtual_CashType_RegexDescription { get { return GetMessage(4312); } }
        public string Virtual_Amount_RegexDescription { get { return GetMessage(4313); } }
        public string Virtual_Pursion_RegexDescription { get { return GetMessage(4314); } }
        public string Virtual_CustomerBusinissNo_RegexDescription { get { return GetMessage(4315); } }

        #endregion

        #region 待处理转账   44*
        public string Preproccess_PreproccessName { get { return GetMessage(4400); } }
        public string Preproccess_PreproccessAccount { get { return GetMessage(4401); } }
        public string Preproccess_CashType { get { return GetMessage(4402); } }
        public string Preproccess_PreproccessAmount { get { return GetMessage(4403); } }
        public string Preproccess_MainAccount { get { return GetMessage(4404); } }
        public string Preproccess_TradeSerialNo { get { return GetMessage(4405); } }
        public string Preproccess_BatchTradeSerialNo { get { return GetMessage(4406); } }
        public string Preproccess_InvolvedName { get { return GetMessage(4407); } }
        public string Preproccess_InvolvedAccount { get { return GetMessage(4408); } }
        public string Preproccess_TradeDate { get { return GetMessage(4409); } }
        public string Preproccess_Content { get { return GetMessage(4410); } }
        public string Preproccess_VirtualAccount { get { return GetMessage(4411); } }
        public string Preproccess_TradeAmount { get { return GetMessage(4412); } }
        public string Preproccess_PreproccessAccount_RegexDescription { get { return GetMessage(4426); } }
        public string Preproccess_PreproccessName_RegexDescription { get { return GetMessage(4427); } }
        public string Preproccess_CashType_RegexDescription { get { return GetMessage(4312); } }
        public string Preproccess_PreproccessAmount_RegexDescription { get { return GetMessage(2270); } }
        public string Preproccess_MainAccount_RegexDescription { get { return GetMessage(4430); } }
        public string Preproccess_TradeSerialNo_RegexDescription { get { return GetMessage(4431); } }
        public string Preproccess_BatchTradeSerialNo_RegexDescription { get { return GetMessage(4432); } }
        public string Preproccess_InvolvedName_RegexDescription { get { return GetMessage(4433); } }
        public string Preproccess_InvolvedAccount_RegexDescription { get { return GetMessage(4434); } }
        public string Preproccess_TradeDate_RegexDescription { get { return GetMessage(4435); } }
        public string Preproccess_Content_RegexDescription { get { return GetMessage(4436); } }
        public string Preproccess_VirtualAccount_RegexDescription { get { return GetMessage(4437); } }
        public string Preproccess_TradeAmount_RegexDescription { get { return GetMessage(2270); } }
        #endregion

        #region 设置  80**
        public string Settings_Convert_Data_Type { get { return GetMessage(8000); } }
        public string Settings_Convert_Data_File { get { return GetMessage(8001); } }
        public string Settings_Set_No_Mapping { get { return GetMessage(8002); } }
        public string Settings_Convert_Succeed { get { return GetMessage(8003); } }
        public string Settings_Convert_Fail { get { return GetMessage(8004); } }
        public string Settings_Make_Sure_Delete_Selected_Records { get { return GetMessage(8005); } }
        public string Settings_No_Selected_Records { get { return GetMessage(8006); } }
        #region 功能设置
        public string Settings_AppliableFunction_Wheathe_Setting_Password { get { return GetMessage(8100); } }
        #endregion
        #region 文件加密
        public string Settings_FileEncryption_Input_Password { get { return GetMessage(8200); } }
        public string Settings_FileEncryption_Password_Different { get { return GetMessage(8201); } }
        #endregion
        #region 付款人名册
        public string Settings_PayerMsg_Payer_Exist_Add_Fail { get { return GetMessage(8300); } }
        public string Settings_PayerMsg_Payer_Exist_Update_Fail { get { return GetMessage(8301); } }
        public string Settings_PayerMsg_Payer_Select_CashType { get { return GetMessage(8302); } }
        #endregion
        #region 收款人名册
        public string Settings_PayeeMsg_Payee_Exist_Add_Fail { get { return GetMessage(8400); } }
        public string Settings_PayeeMsg_Payee_Exist_Update_Fail { get { return GetMessage(8401); } }
        public string Settings_PayeeMsg_BOCName { get { return GetMessage(8402); } }
        public string Settings_PayeeMsg_Select_AccountType { get { return GetMessage(8403); } }
        public string Settings_PayeeMsg_Payee_SerialNo_Exist_Add_Fail { get { return GetMessage(8404); } }
        public string Settings_PayeeMsg_Payee_SerialNo_Exist_Update_Fail { get { return GetMessage(8405); } }
        public string Settings_PayeeMsg_Payee_SerialNo { get { return GetMessage(8420); } }
        public string Settings_PayeeMsg_Payee_Account { get { return GetMessage(1928); } }
        public string Settings_PayeeMsg_Payee_Name { get { return GetMessage(1930); } }
        public string Settings_PayeeMsg_Payee_OpenBankName { get { return GetMessage(1949); } }
        public string Settings_PayeeMsg_Payee_ClearBankName { get { return GetMessage(8421); } }
        public string Settings_PayeeMsg_Payee_CertifyCardType { get { return GetMessage(2361); } }
        public string Settings_PayeeMsg_Payee_CertifyCardNo { get { return GetMessage(2362); } }
        public string Settings_PayeeMsg_Payee_Address { get { return GetMessage(3418); } }
        public string Settings_PayeeMsg_Payee_Email { get { return GetMessage(1950); } }
        public string Settings_PayeeMsg_Payee_Telephone { get { return GetMessage(8407); } }
        public string Settings_PayeeMsg_Payee_Fax { get { return GetMessage(8406); } }
        public string Settings_PayeeMsg_Payee_BankType { get { return GetMessage(8422); } }

        public string Settings_PayeeMsg_Payee_SerialNo_RegexDescription { get { return GetMessage(8408); } }
        public string Settings_PayeeMsg_Select_AccountType_RegexDescription { get { return GetMessage(8410); } }
        public string Settings_PayeeMsg_Payee_Account_RegexDescription { get { return GetMessage(8409); } }
        public string Settings_PayeeMsg_Payee_Name_RegexDescription { get { return GetMessage(8411); } }
        public string Settings_PayeeMsg_Payee_OpenBankName_RegexDescription { get { return GetMessage(8412); } }
        public string Settings_PayeeMsg_Payee_ClearBankName_RegexDescription { get { return GetMessage(8413); } }
        public string Settings_PayeeMsg_Payee_CadeType_RegexDescription { get { return GetMessage(8414); } }
        public string Settings_PayeeMsg_Payee_CadeNumber_RegexDescription { get { return GetMessage(8415); } }
        public string Settings_PayeeMsg_Payee_Address_RegexDescription { get { return GetMessage(8416); } }
        public string Settings_PayeeMsg_Payee_Email_RegexDescription { get { return GetMessage(8417); } }
        public string Settings_PayeeMsg_Payee_Telephone_RegexDescription { get { return GetMessage(8418); } }
        public string Settings_PayeeMsg_Payee_Fax_RegexDescription { get { return GetMessage(8419); } }
        public string Settings_PayeeMsg_Payee_BankType_RegexDescription { get { return GetMessage(8423); } }
        #endregion

        #region 关系人名册
        public string Settings_RelateAccountMsg_Select_PersonType { get { return GetMessage(8500); } }
        public string Settings_RelateAccountMsg_Person_Exist_Add_Fail { get { return GetMessage(8501); } }
        public string Settings_RelateAccountMsg_Person_Exist_Update_Fail { get { return GetMessage(8502); } }
        #endregion
        #region
        public string Settings_AgentExpressInPayerMg_Payee_Exist_Add_Fail { get { return GetMessage(9001); } }
        public string Settings_AgentExpressInPayerMg_Payee_Exist_Update_Fail { get { return GetMessage(9002); } }
        public string Settings_AgentExpressInPayerMg_Payee_SerialNo_Exist_Add_Fail { get { return GetMessage(9003); } }
        public string Settings_AgentExpressInPayerMg_Payee_SerialNo_Exist_Update_Fail { get { return GetMessage(9004); } }
        #endregion
        #region 主动调拨账户名册
        public string Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Add_Fail { get { return GetMessage(9101); } }
        public string Settings_InitiativeAllotAccountMsg_InitiativeAllotAccount_Exist_Update_Fail { get { return GetMessage(9102); } }
        #endregion
        #region 用途或附言
        #endregion
        #region 批量转换设置
        public string Settings_Mappings_Select_Business_Type { get { return GetMessage(8700); } }
        public string Settings_Mappings_File_Is_Open_Please_Close_First { get { return GetMessage(8701); } }
        public string Settings_Mappings_MakeSure_SeparaterChar_First { get { return GetMessage(8702); } }
        public string Settings_Mappings_No_Table_Header { get { return GetMessage(8702); } }
        #endregion
        #region 批量公用数据
        public string Settings_CommonData_Select_BusinessType { get { return GetMessage(8800); } }
        #endregion
        #endregion

        #region
        public string Tips_Pyaee_6NumbersEx { get { return GetMessage(11000); } }
        public string Tips_OpenBank_Inquire_Button { get { return GetMessage(11001); } }
        public string Tips_CustomerNo { get { return GetMessage(11002); } }
        public string Tips_Pyaee_6Numbers { get { return GetMessage(11003); } }
        public string Tips_Field_Allow_Null { get { return GetMessage(11004); } }
        public string Tips_TransferAddress_Needed { get { return GetMessage(11005); } }
        public string Tips_ForeignCount_Needed { get { return GetMessage(11006); } }
        public string Tips_For_Inquire { get { return GetMessage(11007); } }
        public string Tips_For_Inquire_Or_Input { get { return GetMessage(11008); } }
        public string Tips_No_More_Than_100 { get { return GetMessage(11009); } }
        public string Tips_Select_Exchanger_Can_AutoShowData { get { return GetMessage(11010); } }
        public string Tips_Select_Exchanger_OpenBank_Can_AutoShowData { get { return GetMessage(11011); } }
        public string Tips_Select_Payee_OpenBank_Can_AutoShowData { get { return GetMessage(11012); } }
        //public string Tips_test13 { get { return GetMessage(11013); } }
        public string Tips_Input_Multi_KeyChars { get { return GetMessage(11014); } }
        //public string Tips_test15 { get { return GetMessage(11015); } }
        #endregion
        #endregion

        #region 弹出框 100**
        #region 标题  100**
        public string Dialogs_Convert_BatchInfo_HeadText { get { return GetMessage(10000); } }
        public string Dialogs_Query_Country_HeadText { get { return GetMessage(10001); } }
        public string Dialogs_Query_DealCode_HeadText { get { return GetMessage(10002); } }
        public string Dialogs_Query_OpenBankOrClearBank_HeadText { get { return GetMessage(10003); } }
        public string Dialogs_Query_RelateAccount_HeadText { get { return GetMessage(10004); } }
        public string Dialogs_Query_LinkBankNo_HeadText { get { return GetMessage(10005); } }
        public string Dialogs_Query_OpenBankOrClearBank_TransferGlobal_HeadText { get { return GetMessage(10006); } }
        public string Dialogs_Query_Payee_HeadText { get { return GetMessage(10007); } }
        public string Dialogs_Import_HeadText { get { return GetMessage(10008); } }
        public string Dialogs_Version_HeadText { get { return GetMessage(10009); } }
        #endregion
        #region ……
        #endregion
        #endregion

        private string GetMessage(int code)
        {
            string result = string.Empty;
            //判断多语言
            try { result = BOC_BATCH_TOOL.Utilities.EnumNameHelper<MultiLanguageDataHelper>.GetEnumDescription((MultiLanguageDataHelper)code); }
            catch (Exception ex) { }
            return result;
        }

    }
}
