using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 关键字表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Keyword
    {
        private readonly CommonService.DAL.KMS.K_Keyword dal = new CommonService.DAL.KMS.K_Keyword();
        public K_Keyword()
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
        public bool Exists(int K_Keyword_id)
        {
            return dal.Exists(K_Keyword_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Keyword model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Keyword model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Keyword_code)
        {

            return dal.Delete(K_Keyword_code);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.KMS.K_Keyword> modelList)
        {
            foreach (CommonService.Model.KMS.K_Keyword model in modelList)
            {
                dal.Add(model);
            }
            return true;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string K_Keyword_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(K_Keyword_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Keyword GetModel(int K_Keyword_id)
        {

            return dal.GetModel(K_Keyword_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Keyword GetModel(Guid K_Keyword_code)
        {

            return dal.GetModel(K_Keyword_code);
        }
        /// <summary>
        /// 根据关键字得到一个对象Guid
        /// </summary>
        public string GetModelByKey(string K_Keyword_name)
        {
            return dal.GetModelByKey(K_Keyword_name);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_Keyword GetModelByCache(int K_Keyword_id)
        {

            string CacheKey = "K_KeywordModel-" + K_Keyword_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_Keyword_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_Keyword)objModel;
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
        public List<CommonService.Model.KMS.K_Keyword> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Keyword> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_Keyword> modelList = new List<CommonService.Model.KMS.K_Keyword>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_Keyword model;
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
        public List<CommonService.Model.KMS.K_Keyword> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.KMS.K_Keyword model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Keyword> GetListByPage(CommonService.Model.KMS.K_Keyword model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 根据资源guid获得资源的关键字列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Keyword> GetKeywordList(Guid K_Resources_code)
        {
            return DataTableToList(dal.GetKeywordList(K_Resources_code).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 获得热门标签前10条数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Keyword> GetTagList()
        {
            return DataTableToList(dal.GetTagList().Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

