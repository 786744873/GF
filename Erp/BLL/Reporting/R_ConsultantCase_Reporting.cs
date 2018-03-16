﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    /// <summary>
    /// R_ConsultantCase_Reporting
    /// </summary>
    public partial class R_ConsultantCase_Reporting
    {
        private readonly DAL.Reporting.R_ConsultantCase_Reporting dal = new DAL.Reporting.R_ConsultantCase_Reporting();
        public R_ConsultantCase_Reporting()
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
        public int Add(Model.Reporting.R_ConsultantCase_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_ConsultantCase_Reporting model)
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
        public Model.Reporting.R_ConsultantCase_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_ConsultantCase_Reporting GetModelByCache(int ID)
        {

            string CacheKey = "R_ConsultantCase_ReportingModel-" + ID;
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
            return (Model.Reporting.R_ConsultantCase_Reporting)objModel;
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
        public List<Model.Reporting.R_ConsultantCase_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_ConsultantCase_Reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_ConsultantCase_Reporting> modelList = new List<Model.Reporting.R_ConsultantCase_Reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_ConsultantCase_Reporting model;
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
            dal.Delete();
            DataSet ds = dal.GetReporting();
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Model.Reporting.R_ConsultantCase_Reporting areaReporting = new Model.Reporting.R_ConsultantCase_Reporting();

                    areaReporting.R_ConsultantCase_Reporting_year = item["R_ConsultantCase_Reporting_year"] == DBNull.Value ? "" : item["R_ConsultantCase_Reporting_year"].ToString(); //接案年份

                    areaReporting.R_ConsultantCase_Reporting_month = item["R_ConsultantCase_Reporting_month"] == DBNull.Value ? "" : item["R_ConsultantCase_Reporting_month"].ToString(); //接案月份

                    areaReporting.R_ConsultantCase_Reporting_area = item["R_ConsultantCase_Reporting_area"] == DBNull.Value ? "" : item["R_ConsultantCase_Reporting_area"].ToString(); //地区

                    areaReporting.R_ConsultantCase_Reporting_allCount = item["R_ConsultantCase_Reporting_allCount"].ToString(); //接案总数

                    areaReporting.R_ConsultantCase_Reporting_typeCount = item["R_ConsultantCase_Reporting_typeCount"].ToString(); //案件类型数量

                    areaReporting.R_ConsultantCase_Reporting_unTypeCount = item["R_ConsultantCase_Reporting_unTypeCount"].ToString(); //非案件类型数量

                    areaReporting.R_ConsultantCase_Reporting_customerCount = item["R_ConsultantCase_Reporting_customerCount"].ToString(); //客户总数

                    areaReporting.R_ConsultantCase_Reporting_newCustomer = item["R_ConsultantCase_Reporting_newCustomer"].ToString(); //新客户数量

                    areaReporting.R_ConsultantCase_Reporting_oldCustomer = item["R_ConsultantCase_Reporting_oldCustomer"].ToString(); //老客户数量

                    areaReporting.R_ConsultantCase_Reporting_transferTarget = item["R_ConsultantCase_Reporting_transferTarget"].ToString(); //移交总标的

                    areaReporting.R_ConsultantCase_Reporting_typeTransferTarget = item["R_ConsultantCase_Reporting_typeTransferTarget"].ToString(); //类型移交标的

                    areaReporting.R_ConsultantCase_Reporting_unTypeTransferTarget = item["R_ConsultantCase_Reporting_unTypeTransferTarget"].ToString(); //非类型移交标的

                    areaReporting.R_ConsultantCase_Reporting_expectedReturn = item["R_ConsultantCase_Reporting_expectedReturn"].ToString(); //预期总收益

                    areaReporting.R_ConsultantCase_Reporting_typeExpectedReturn = item["R_ConsultantCase_Reporting_typeExpectedReturn"].ToString(); //类型预期收益

                    areaReporting.R_ConsultantCase_Reporting_unTypeExpectedReturn = item["R_ConsultantCase_Reporting_unTypeExpectedReturn"].ToString(); //非类型预期收益

                    areaReporting.R_ConsultantCase_Reporting_monthCount = ""; //本月计划接案数

                    areaReporting.R_ConsultantCase_Reporting_cCompletion = "";//完成率

                    areaReporting.R_ConsultantCase_Reporting_nextMonthCount = ""; //下月计划接案数

                    areaReporting.R_ConsultantCase_Reporting_monthExpected = ""; //本月计划预期收益

                    areaReporting.R_ConsultantCase_Reporting_eCompletion = ""; //完成率

                    areaReporting.R_ConsultantCase_Reporting_nextMonthExpected = ""; //下月计划预期收益

                    Add(areaReporting);


                }
            }
        }
        #endregion  ExtensionMethod
    }
}