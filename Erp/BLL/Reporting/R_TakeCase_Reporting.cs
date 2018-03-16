using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    /// <summary>
    /// R_TakeCase_Reporting
    /// </summary>
    public partial class R_TakeCase_Reporting
    {
        private readonly DAL.Reporting.R_TakeCase_Reporting dal = new DAL.Reporting.R_TakeCase_Reporting();

        private readonly BLL.CaseManager.B_Case caseBLL = new CaseManager.B_Case(); //案件业务逻辑

        private readonly BLL.CaseManager.B_Case_link caseLinkBLL = new CaseManager.B_Case_link(); //案件关联业务逻辑

        private readonly BLL.C_Customer customerBLL = new C_Customer(); //客户业务逻辑

        private readonly BLL.C_Region regionBLL = new C_Region(); //区域业务逻辑

        private readonly BLL.SysManager.C_Userinfo userBLL = new SysManager.C_Userinfo(); //用户业务逻辑

        private readonly BLL.C_Parameters paraBLL = new C_Parameters(); //参数业务逻辑

        private readonly BLL.C_Court courtBLL = new C_Court(); //法院业务逻辑

        public R_TakeCase_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_TakeCase_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_TakeCase_Reporting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(IDlist, 0));
        }

        /// <summary>
        /// 清除表，慎重调用
        /// </summary>
        public bool Delete()
        {
            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_TakeCase_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_TakeCase_Reporting GetModelByCache(int ID)
        {

            string CacheKey = "R_TakeCase_ReportingModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.Reporting.R_TakeCase_Reporting)objModel;
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
        public List<Model.Reporting.R_TakeCase_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_TakeCase_Reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_TakeCase_Reporting> modelList = new List<Model.Reporting.R_TakeCase_Reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_TakeCase_Reporting model;
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 统计
        /// </summary>
        public int Statistics()
        {
            Delete(); //清除数据
            //if (row.Table.Columns.Contains("B_Case_type_name"))
            DataSet dsCase = caseBLL.GetAllList(); //获取所有的案件
            int i = 0;
            if (dsCase != null && dsCase.Tables[0] != null && dsCase.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsCase.Tables[0].Rows)
                {
                    Model.C_Customer customer = new Model.C_Customer();
                    List<Model.CaseManager.B_Case_link> lst = caseLinkBLL.GetCaseLinksByCaseAndType(new Guid(dr["B_Case_code"].ToString()), 0); //获取案件客户列表
                    if (lst.Count > 0)
                    {
                        customer = customerBLL.GetModel(lst.FirstOrDefault().C_FK_code.Value); //获取到第一个客户，暂时只取第一个
                    }


                    Model.Reporting.R_TakeCase_Reporting takeCase = new Model.Reporting.R_TakeCase_Reporting();

                    takeCase.R_TakeCase_Reporting_year = dr["B_Case_registerTime"] == DBNull.Value ? "" : Convert.ToDateTime(dr["B_Case_registerTime"]).Year.ToString(); //收案年份

                    takeCase.R_TakeCase_Reporting_month = dr["B_Case_registerTime"] == DBNull.Value ? "" : Convert.ToDateTime(dr["B_Case_registerTime"]).Month.ToString(); //收案月份

                    takeCase.R_TakeCase_Reporting_area = caseLinkBLL.GetStringFK(new Guid(dr["B_Case_code"].ToString()), 6); //地区

                    takeCase.R_TakeCase_Reporting_dept = dr["B_Case_person"] == DBNull.Value ? "" : userBLL.GetDeptNameByUserCode(new Guid(dr["B_Case_person"].ToString())); //部门

                    takeCase.R_TakeCase_Reporting_minister = dr["B_Case_person"] == DBNull.Value ? "" : userBLL.GetModelByUserCode(new Guid(dr["B_Case_person"].ToString())) == null ? "" : userBLL.GetModelByUserCode(new Guid(dr["B_Case_person"].ToString())).C_Userinfo_name; //部长/组长

                    takeCase.B_TakeCase_Reporting_consultant = caseLinkBLL.GetStringFK(new Guid(dr["B_Case_code"].ToString()), 11); //专业顾问

                    takeCase.B_TakeCase_Reporting_customer = customer == null ? "" : customer.C_Customer_name; //客户

                    takeCase.B_TakeCase_Reporting_newOrOld = customer == null ? "" : customer.C_Customer_Category == null ? "" : paraBLL.GetModel(Convert.ToInt32(customer.C_Customer_Category)).C_Parameters_name; //客户类别

                    takeCase.B_TakeCase_Reporting_level = customer == null ? "" : customer.C_Customer_level == null ? "" : paraBLL.GetModel(Convert.ToInt32(customer.C_Customer_level)).C_Parameters_name; //客户级别

                    takeCase.B_TakeCase_Reporting_loyalty = customer == null ? "" : customer.C_Customer_loyalty == null ? "" : paraBLL.GetModel(Convert.ToInt32(customer.C_Customer_loyalty)).C_Parameters_name; //客户忠诚度

                    takeCase.B_TakeCase_Reporting_sect = ""; //客户流派？不知道干吗的

                    takeCase.B_TakeCase_Reporting_caseNumber = dr["B_Case_number"].ToString(); //案号

                    takeCase.B_TakeCase_Reporting_relCustomer = caseLinkBLL.GetStringFK(new Guid(dr["B_Case_code"].ToString()), 1); //委托人

                    string cbeigao = caseLinkBLL.GetStringFK(new Guid(dr["B_Case_code"].ToString()), 2);
                    string pbeigao = caseLinkBLL.GetStringFK(new Guid(dr["B_Case_code"].ToString()), 3);

                    if (cbeigao != "" && pbeigao != "")
                    {
                        cbeigao = cbeigao + "," + pbeigao;
                    }
                    takeCase.B_TakeCase_Reporting_rival = cbeigao == "" ? pbeigao : cbeigao; //被告

                    takeCase.B_TakeCase_Reporting_project = caseLinkBLL.GetStringFK(new Guid(dr["B_Case_code"].ToString()), 7); //工程

                    takeCase.B_TakeCase_Reporting_plate = ""; //版块？不知道干啥的

                    takeCase.B_TakeCase_Reporting_property = dr["B_Case_nature"] == DBNull.Value ? "" : paraBLL.GetModel(Convert.ToInt32(dr["B_Case_nature"])).C_Parameters_name; //案件性质

                    takeCase.B_TakeCase_Reporting_transferTarget = dr["B_Case_transferTargetMoney"] == DBNull.Value ? "" : dr["B_Case_transferTargetMoney"].ToString(); //移交标的

                    takeCase.B_TakeCase_Reporting_expectedReturn = dr["B_Case_expectedGrant"] == DBNull.Value ? "" : dr["B_Case_expectedGrant"].ToString(); //预期收益

                    string courtString = "";
                    if (dr["B_Case_courtFirst"] != null && dr["B_Case_courtFirst"].ToString() != "") //一审法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(dr["B_Case_courtFirst"].ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (dr["B_Case_courtSecond"] != null && dr["B_Case_courtSecond"].ToString() != "") //二审法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(dr["B_Case_courtSecond"].ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (dr["B_Case_courtExec"] != null && dr["B_Case_courtExec"].ToString() != "") //管辖法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(dr["B_Case_courtExec"].ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (dr["B_Case_Trial"] != null && dr["B_Case_Trial"].ToString() != "") //监督法院
                    {
                        Model.C_Court court = courtBLL.GetModel(new Guid(dr["B_Case_Trial"].ToString()));
                        if (court != null)
                        {
                            courtString += court.C_Court_name + ",";
                        }
                    }

                    if (courtString.Length > 0)
                    {
                        courtString = courtString.Substring(0, courtString.Length - 1);
                    }

                    takeCase.B_TakeCase_Reporting_court = courtString; //法院

                    i = Add(takeCase);
                    i = i + 1;

                }
                return i;
            }
            else
            {
                return 0;
            }
        }

        #endregion  ExtensionMethod
    }
}
