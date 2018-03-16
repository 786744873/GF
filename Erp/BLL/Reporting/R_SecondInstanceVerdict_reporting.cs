using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    /// <summary>
    /// R_SecondInstanceVerdict_reporting
    /// </summary>
    public partial class R_SecondInstanceVerdict_reporting
    {
        private readonly DAL.Reporting.R_SecondInstanceVerdict_reporting dal = new DAL.Reporting.R_SecondInstanceVerdict_reporting();
        public R_SecondInstanceVerdict_reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_SecondInstanceVerdict_reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_SecondInstanceVerdict_reporting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_SecondInstanceVerdict_reporting GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_SecondInstanceVerdict_reporting GetModelByCache(int id)
        {

            string CacheKey = "R_SecondInstanceVerdict_reportingModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.Reporting.R_SecondInstanceVerdict_reporting)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_SecondInstanceVerdict_reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_SecondInstanceVerdict_reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_SecondInstanceVerdict_reporting> modelList = new List<Model.Reporting.R_SecondInstanceVerdict_reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_SecondInstanceVerdict_reporting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.V_SecondInstanceVerdict_reporting> DataTableToList(DataTable dt, int type)
        {
            List<Model.Reporting.V_SecondInstanceVerdict_reporting> modelList = new List<Model.Reporting.V_SecondInstanceVerdict_reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.V_SecondInstanceVerdict_reporting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n], type);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.Reporting.R_SecondInstanceVerdict_reporting> GetListByPage(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetDataListCount(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model, int type)
        {
            return dal.GetDataListCount(model, type);
        }

        /// <summary>
        /// 类型
        /// 1、区域
        /// 2、部门
        /// 3、主办律师
        /// 4、一审管辖法院
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Model.Reporting.V_SecondInstanceVerdict_reporting> GetDataList(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model, int type, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetDataList(model, type, orderby, startIndex, endIndex).Tables[0], type);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 生成报表
        /// </summary>
        public void Statistics()
        {
            dal.Delete(); //清除数据

            DAL.MonitorManager.M_Entry_Statistics statistics = new DAL.MonitorManager.M_Entry_Statistics();
            BLL.CaseManager.B_Case_link linkBLL = new CaseManager.B_Case_link();
            BLL.CustomerForm.F_FormPropertyValue fpvBLL = new CustomerForm.F_FormPropertyValue();
            BLL.FlowManager.P_Business_flow_form pbfBLL = new FlowManager.P_Business_flow_form();

            DataSet ds = statistics.GetStatisticsByEntry(new Guid("19287E9C-39DB-4182-BC7E-39CC1534C4F7"), new Guid("C5C8DD70-0411-46AC-8CFA-051B4E84F0F0")); //获取二审判决条目下的统计信息及立案阶段下负责人

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Model.Reporting.R_SecondInstanceVerdict_reporting fiv = new Model.Reporting.R_SecondInstanceVerdict_reporting();
                    fiv.R_SecondInstanceVerdict_reporting_area = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 6); //案件区域
                    fiv.R_SecondInstanceVerdict_reporting_caseNumber = item["M_Case_number"].ToString(); //案件编码
                    fiv.R_SecondInstanceVerdict_reporting_host = item["主办律师"] == DBNull.Value ? "" : item["主办律师"].ToString(); //主办律师
                    fiv.R_SecondInstanceVerdict_reporting_co = item["协办律师"] == DBNull.Value ? "" : item["协办律师"].ToString(); //协办律师
                    fiv.R_SecondInstanceVerdict_reporting_firstCourt = item["二审管辖法院"] == DBNull.Value ? "" : item["二审管辖法院"].ToString(); //二审管辖法院
                    fiv.R_SecondInstanceVerdict_reporting_plaintiff = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 1); //委托人

                    string cbeigao = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 2);
                    string pbeigao = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 3);

                    if (cbeigao != "" && pbeigao != "")
                    {
                        cbeigao = cbeigao + "," + pbeigao;
                    }
                    fiv.R_SecondInstanceVerdict_reporting_otherParty = cbeigao == "" ? pbeigao : cbeigao; //被告

                    fiv.R_SecondInstanceVerdict_reporting_project = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 7); //项目

                    fiv.R_SecondInstanceVerdict_reporting_closedDate = item["B_Case_sureDate"] == DBNull.Value ? "" : item["B_Case_sureDate"].ToString(); //收案时间(首席确认时间)

                    fiv.R_SecondInstanceVerdict_reporting_transferTarget = item["B_Case_transferTargetMoney"] == DBNull.Value ? "" : item["B_Case_transferTargetMoney"].ToString(); //移交标的

                    fiv.R_SecondInstanceVerdict_reporting_expectedReturn = item["B_Case_expectedGrant"] == DBNull.Value ? "" : item["B_Case_expectedGrant"].ToString(); //预期收入

                    fiv.R_SecondInstanceVerdict_reporting_isExtension = item["M_Entry_Statistics_changeDuration"] == DBNull.Value ? "否" : item["M_Entry_Statistics_changeDuration"].ToString() == "0" ? "否" : "是"; //是否延期

                    fiv.R_SecondInstanceVerdict_reporting_extensionTime = item["M_Entry_Statistics_changeDuration"] == DBNull.Value ? "" : item["M_Entry_Statistics_changeDuration"].ToString(); //延期时长

                    fiv.R_SecondInstanceVerdict_reporting_finishedTime = item["M_Entry_Statistics_entryETime"] == DBNull.Value ? "" : item["M_Entry_Statistics_entryETime"].ToString(); //实际结束时间

                    fiv.R_SecondInstanceVerdict_reporting_startDate = item["M_Entry_Statistics_entrySTime"] == DBNull.Value ? "" : item["M_Entry_Statistics_entrySTime"].ToString(); //二审开始时间（进程开始结点）

                    fiv.R_SecondInstanceVerdict_reporting_organ = item["部门"] == DBNull.Value ? "" : item["部门"].ToString(); //部门

                    DataSet bqds = pbfBLL.GetList(" F_Form_code='2E091784-C303-4BA5-99E6-DB33C29E48B2' and P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code='" + item["M_Case_code"] + "') and P_Business_flow_form_isdelete=0 and P_Business_flow_form_status<>766"); //获取该案件下的诉讼办案小结表单
                    if (bqds != null && bqds.Tables[0] != null && bqds.Tables[0].Rows.Count > 0)
                    {
                        List<Model.CustomerForm.F_FormPropertyValue> lstValue = fpvBLL.GetModelList(" F_FormPropertyValue_isDelete=0 and F_FormPropertyValue_BusinessFlowFormCode='" + bqds.Tables[0].Rows[0]["P_Business_flow_form_code"] + "'"); //获取诉讼办案小结下的所有属性值
                        Model.CustomerForm.F_FormPropertyValue value = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("88E67A38-EA67-483F-BC9B-5FD45913177E")).FirstOrDefault(); //文书类型


                        Model.CustomerForm.F_FormPropertyValue value1 = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("D207A151-97CF-4CCD-93C7-BB7397C561EC")).FirstOrDefault(); //是否生效

                        Model.CustomerForm.F_FormPropertyValue value2 = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("F04A72FE-A444-430B-96B1-57E4B1E50041")).FirstOrDefault(); //文书收入
                        Model.CustomerForm.F_FormPropertyValue value3 = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("66162E19-5A49-4026-8763-44D66643EEBB")).FirstOrDefault(); //文书结果
                        Model.CustomerForm.F_FormPropertyValue value4 = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("177D4E51-ECF0-4FD8-B9E0-40DBD2E4C8F2")).FirstOrDefault(); //文书生效时间
                        Model.CustomerForm.F_FormPropertyValue value5 = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("8BFF8A7E-6440-47AE-82B7-309E76F85C3F")).FirstOrDefault(); //文书生效时间
                        if (value != null)
                        {
                            switch (value.F_FormPropertyValue_value)
                            {
                                case "441":
                                    fiv.R_SecondInstanceVerdict_reporting_InstrumentsType = "判决书";
                                    break;
                                case "442":
                                    fiv.R_SecondInstanceVerdict_reporting_InstrumentsType = "调解书";
                                    break;
                                case "443":
                                    fiv.R_SecondInstanceVerdict_reporting_InstrumentsType = "和解协议";
                                    break;
                                case "444":
                                    fiv.R_SecondInstanceVerdict_reporting_InstrumentsType = "仲裁裁定";
                                    break;
                            }
                            //preser.R_Preservation_reporting_saveMoney = value1.F_FormPropertyValue_value; //实际保全金额
                        }

                        if (value1 != null)
                        {
                            fiv.R_SecondInstanceVerdict_reporting_isValidate = value1.F_FormPropertyValue_value == "843" ? "是" : value1.F_FormPropertyValue_value == "844" ? "否" : "";
                        }

                        if (value2 != null)
                        {
                            fiv.R_SecondInstanceVerdict_reporting_InstrumentsMoney = value2.F_FormPropertyValue_value;
                        }

                        if (value3 != null)
                        {
                            fiv.R_SecondInstanceVerdict_reporting_result = value3.F_FormPropertyValue_value == "446" ? "胜诉" : value3.F_FormPropertyValue_value == "447" ? "败诉" : "";
                        }

                        if (value4 != null)
                        {
                            fiv.R_SecondInstanceVerdict_reporting_isClosed = value4.F_FormPropertyValue_value == null || value4.F_FormPropertyValue_value == "" ? "否" : "是";
                        }

                        if (value5 != null)
                        {
                            fiv.R_SecondInstanceVerdict_reporting_iswei = value1.F_FormPropertyValue_value == "843" ? "是" : value1.F_FormPropertyValue_value == "844" ? "否" : "";
                        }
                    }

                    DataSet bqds1 = pbfBLL.GetList(" F_Form_code='12222B71-E609-401D-A9B7-4368999D4AAA' and P_Business_flow_code in(select P_Business_flow_code from P_Business_flow where P_Fk_code='" + item["M_Case_code"] + "') and P_Business_flow_form_isdelete=0 and P_Business_flow_form_status<>766"); //获取该案件下的诉讼办案小结表单
                    if (bqds1 != null && bqds1.Tables[0] != null && bqds1.Tables[0].Rows.Count > 0)
                    {
                        List<Model.CustomerForm.F_FormPropertyValue> lstValue = fpvBLL.GetModelList(" F_FormPropertyValue_isDelete=0 and F_FormPropertyValue_BusinessFlowFormCode='" + bqds1.Tables[0].Rows[0]["P_Business_flow_form_code"] + "'"); //获取诉讼办案小结下的所有属性值
                        Model.CustomerForm.F_FormPropertyValue value = lstValue.Where(p => p.F_FormPropertyValue_formProperty == new Guid("E8423058-0094-4891-9FDC-ADAD2B91C51E")).FirstOrDefault(); //受理时间
                        if (value != null)
                        {
                            fiv.R_SecondInstanceVerdict_reporting_fitingTime = value.F_FormPropertyValue_value;
                        }
                    }


                    fiv.R_SecondInstanceVerdict_reporting_caseCode = item["M_Case_code"] == DBNull.Value ? "" : item["M_Case_code"].ToString(); //案件编码

                    fiv.R_SecondInstanceVerdict_reporting_mCode = item["M_Entry_Statistics_code"].ToString();
                    dal.Add(fiv);
                }
            }
        }
        #endregion  ExtensionMethod
    }
}
