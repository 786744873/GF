using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    /// <summary>
    /// R_CourtOfSecondInstanceRow_reporting
    /// </summary>
    public partial class R_CourtOfSecondInstanceRow_reporting
    {
        private readonly DAL.Reporting.R_CourtOfSecondInstanceRow_reporting dal = new DAL.Reporting.R_CourtOfSecondInstanceRow_reporting();
        public R_CourtOfSecondInstanceRow_reporting()
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
        public int Add(Model.Reporting.R_CourtOfSecondInstanceRow_reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_CourtOfSecondInstanceRow_reporting model)
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
        public Model.Reporting.R_CourtOfSecondInstanceRow_reporting GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_CourtOfSecondInstanceRow_reporting GetModelByCache(int id)
        {

            string CacheKey = "R_CourtOfSecondInstanceRow_reportingModel-" + id;
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
            return (Model.Reporting.R_CourtOfSecondInstanceRow_reporting)objModel;
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
        public List<Model.Reporting.R_CourtOfSecondInstanceRow_reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CourtOfSecondInstanceRow_reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_CourtOfSecondInstanceRow_reporting> modelList = new List<Model.Reporting.R_CourtOfSecondInstanceRow_reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_CourtOfSecondInstanceRow_reporting model;
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
        public List<Model.Reporting.V_CourtOfSecondInstanceRow_reporting> DataTableToList(DataTable dt, int type)
        {
            List<Model.Reporting.V_CourtOfSecondInstanceRow_reporting> modelList = new List<Model.Reporting.V_CourtOfSecondInstanceRow_reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.V_CourtOfSecondInstanceRow_reporting model;
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
        public int GetRecordCount(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.Reporting.R_CourtOfSecondInstanceRow_reporting> GetListByPage(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetDataListCount(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model, int type)
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
        public List<Model.Reporting.V_CourtOfSecondInstanceRow_reporting> GetDataList(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model, int type, string orderby, int startIndex, int endIndex)
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

            DataSet ds = statistics.GetStatisticsByEntry(new Guid("二审排庭"), new Guid("3EC0174E-5BFB-4E7D-B8E2-4EC34D26E7EF")); //获取二审排庭条目下的统计信息及立案阶段下负责人

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Model.Reporting.R_CourtOfSecondInstanceRow_reporting cot = new Model.Reporting.R_CourtOfSecondInstanceRow_reporting();
                    cot.R_CourtOfSecondInstanceRow_reporting_area = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 6); //案件区域
                    cot.R_CourtOfSecondInstanceRow_reporting_caseNumber = item["M_Case_number"].ToString(); //案件编码
                    cot.R_CourtOfSecondInstanceRow_reporting_host = item["主办律师"] == DBNull.Value ? "" : item["主办律师"].ToString(); //主办律师
                    cot.R_CourtOfSecondInstanceRow_reporting_co = item["协办律师"] == DBNull.Value ? "" : item["协办律师"].ToString(); //协办律师
                    cot.R_CourtOfSecondInstanceRow_reporting_firstCourt = item["一审管辖法院"] == DBNull.Value ? "" : item["一审管辖法院"].ToString(); //一审管辖法院
                    cot.R_CourtOfSecondInstanceRow_reporting_plaintiff = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 1); //委托人

                    string cbeigao = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 2);
                    string pbeigao = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 3);

                    if (cbeigao != "" && pbeigao != "")
                    {
                        cbeigao = cbeigao + "," + pbeigao;
                    }
                    cot.R_CourtOfSecondInstanceRow_reporting_otherParty = cbeigao == "" ? pbeigao : cbeigao; //被告

                    cot.R_CourtOfSecondInstanceRow_reporting_project = linkBLL.GetStringFK(new Guid(item["M_Case_code"].ToString()), 7); //项目

                    cot.R_CourtOfSecondInstanceRow_reporting_closedDate = item["B_Case_sureDate"] == DBNull.Value ? "" : item["B_Case_sureDate"].ToString(); //收案时间(首席确认时间)

                    cot.R_CourtOfSecondInstanceRow_reporting_transferTarget = item["B_Case_transferTargetMoney"] == DBNull.Value ? "" : item["B_Case_transferTargetMoney"].ToString(); //移交标的

                    cot.R_CourtOfSecondInstanceRow_reporting_expectedReturn = item["B_Case_expectedGrant"] == DBNull.Value ? "" : item["B_Case_expectedGrant"].ToString(); //预期收入

                    cot.R_CourtOfSecondInstanceRow_reporting_isExtension = item["M_Entry_Statistics_changeDuration"] == DBNull.Value ? "否" : item["M_Entry_Statistics_changeDuration"].ToString() == "0" ? "否" : "是"; //是否延期

                    cot.R_CourtOfSecondInstanceRow_reporting_extensionTime = item["M_Entry_Statistics_changeDuration"] == DBNull.Value ? "" : item["M_Entry_Statistics_changeDuration"].ToString(); //延期时长

                    cot.R_CourtOfSecondInstanceRow_reporting_finishedTime = item["M_Entry_Statistics_entryETime"] == DBNull.Value ? "" : item["M_Entry_Statistics_entryETime"].ToString(); //实际结束时间

                    cot.R_CourtOfSecondInstanceRow_reporting_organ = item["部门"] == DBNull.Value ? "" : item["部门"].ToString(); //部门

                    cot.R_CourtOfSecondInstanceRow_reporting_startDate = item["M_Entry_Statistics_entrySTime"] == DBNull.Value ? "" : item["M_Entry_Statistics_entrySTime"].ToString(); //二审开始时间（开始结点）

                    //立案时间

                    cot.R_CourtOfSecondInstanceRow_reporting_caseCode = item["M_Case_code"] == DBNull.Value ? "" : item["M_Case_code"].ToString(); //案件编码

                    cot.R_CourtOfSecondInstanceRow_reporting_mCode = item["M_Entry_Statistics_code"].ToString();

                    dal.Add(cot);
                }
            }
        }
        #endregion  ExtensionMethod
    }
}
