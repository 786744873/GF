using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    /// <summary>
    /// R_CustomerValue_Reporting
    /// </summary>
    public partial class R_CustomerValue_Reporting
    {
        private readonly DAL.Reporting.R_CustomerValue_Reporting dal = new DAL.Reporting.R_CustomerValue_Reporting();
        public R_CustomerValue_Reporting()
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
        public int Add(Model.Reporting.R_CustomerValue_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_CustomerValue_Reporting model)
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
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_CustomerValue_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_CustomerValue_Reporting GetModelByCache(int ID)
        {

            string CacheKey = "R_CustomerValue_ReportingModel-" + ID;
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
            return (Model.Reporting.R_CustomerValue_Reporting)objModel;
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
        public List<Model.Reporting.R_CustomerValue_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CustomerValue_Reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_CustomerValue_Reporting> modelList = new List<Model.Reporting.R_CustomerValue_Reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_CustomerValue_Reporting model;
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
        public void Statistics()
        {
            dal.Delete(); //清除数据

            DataSet ds = dal.GetCustomerReporting(); //获取报表数据

            if(ds!=null&&ds.Tables[0]!=null&&ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Model.Reporting.R_CustomerValue_Reporting customerValue = new Model.Reporting.R_CustomerValue_Reporting();
                    customerValue.R_CustomerValue_Reporting_year = item["R_CustomerValue_Reporting_year"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_year"].ToString();
                    customerValue.R_CustomerValue_Reporting_month = item["R_CustomerValue_Reporting_month"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_month"].ToString();
                    customerValue.R_CustomerValue_Reporting_area = item["R_CustomerValue_Reporting_area"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_area"].ToString();
                    customerValue.R_CustomerValue_Reporting_customerName = item["R_CustomerValue_Reporting_customerName"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_customerName"].ToString();
                    customerValue.R_CustomerValue_Reporting_type = item["R_CustomerValue_Reporting_type"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_type"].ToString();
                    customerValue.R_CustomerValue_Reporting_newOrOld = item["R_CustomerValue_Reporting_newOrOld"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_newOrOld"].ToString() == "0" ? "新客户" : "老客户";
                    customerValue.R_CustomerValue_Reporting_sect = "";
                    customerValue.R_CustomerValue_Reporting_level = item["R_CustomerValue_Reporting_level"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_level"].ToString();
                    customerValue.R_CustomerValue_Reporting_loyalty = item["R_CustomerValue_Reporting_loyalty"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_loyalty"].ToString();
                    customerValue.R_CustomerValue_Reporting_fTakeTime = item["R_CustomerValue_Reporting_fTakeTime"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_fTakeTime"].ToString();
                    customerValue.R_CustomerValue_Reporting_nTakeTime = item["R_CustomerValue_Reporting_nTakeTime"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_nTakeTime"].ToString();
                    customerValue.R_CustomerValue_Reporting_monthTakeCount = item["R_CustomerValue_Reporting_monthTakeCount"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_monthTakeCount"].ToString();
                    customerValue.R_CustomerValue_Reporting_monthExpected = item["R_CustomerValue_Reporting_monthExpected"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_monthExpected"].ToString();
                    customerValue.R_CustomerValue_Reporting_takeCount = item["R_CustomerValue_Reporting_takeCount"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_takeCount"].ToString();
                    customerValue.R_CustomerValue_Reporting_Expected = item["R_CustomerValue_Reporting_Expected"] == DBNull.Value ? "" : item["R_CustomerValue_Reporting_Expected"].ToString();
                    Add(customerValue);
                }
            }
            
        }
        #endregion  ExtensionMethod
    }
}
