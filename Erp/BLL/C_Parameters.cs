using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 参数表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Parameters
    {
        private readonly CommonService.DAL.C_Parameters dal = new CommonService.DAL.C_Parameters();
        public C_Parameters()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Parameters_id)
        {
            return dal.Exists(C_Parameters_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Parameters model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Parameters model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Parameters_id)
        {

            return dal.Delete(C_Parameters_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Parameters_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Parameters_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Parameters GetModel(int C_Parameters_id)
        {

            return dal.GetModel(C_Parameters_id);
        }
        /// <summary>
        /// 得到一个对象实体,
        /// <param name="relationId">根据父级ID和名称会的对象实体</param>
        /// </summary>
        public CommonService.Model.C_Parameters GetModelByParmentname(int C_Parameters_id, string C_parmeters_name)
        {
            return dal.GetModelByParmentname(C_Parameters_id, C_parmeters_name);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Parameters GetModelByCache(int C_Parameters_id)
        {

            string CacheKey = "C_ParametersModel-" + C_Parameters_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Parameters_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Parameters)objModel;
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
        /// 通过父级ID，获取子集集合
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Parameters> GetChildrenByParentId(int parentId)
        {
            DataSet ds = dal.GetChildrenByParentId(parentId);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Parameters> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Parameters> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Parameters> modelList = new List<CommonService.Model.C_Parameters>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Parameters model;
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
        public int GetRecordCount(Model.C_Parameters model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Parameters> GetListByPage(Model.C_Parameters model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
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

        #endregion  ExtensionMethod

        #region App专用

        /// <summary>
        /// 根据父级ID获取所有子集参数
        /// </summary>
        /// <param name="parentID">父级ID</param>
        /// <returns>所有子集参数</returns>
        public List<Model.C_Parameters> GetParametersByParentID(int parentID)
        {
            return DataTableToList(dal.GetParametersByParentID(parentID).Tables[0]);
        }

        #endregion
    }
}

