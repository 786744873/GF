﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.KMS
{
    /// <summary>
    /// K_Resources_Browse
    /// </summary>
    public partial class K_Resources_Browse
    {
        private readonly CommonService.DAL.KMS.K_Resources_Browse dal = new CommonService.DAL.KMS.K_Resources_Browse();
        public K_Resources_Browse()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Resources_Browse_id)
        {
            return dal.Exists(K_Resources_Browse_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Userinfo_code"></param>
        /// <param name="K_Resources_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Resources_Browse ExistsBrowse(Guid Userinfo_code, Guid K_Resources_code)
        {
            return dal.ExistsBrowse(Userinfo_code, K_Resources_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources_Browse model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Resources_Browse model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int K_Resources_Browse_id)
        {

            return dal.Delete(K_Resources_Browse_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string K_Resources_Browse_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(K_Resources_Browse_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources_Browse GetModel(int K_Resources_Browse_id)
        {

            return dal.GetModel(K_Resources_Browse_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_Resources_Browse GetModelByCache(int K_Resources_Browse_id)
        {

            string CacheKey = "K_Resources_BrowseModel-" + K_Resources_Browse_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_Resources_Browse_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_Resources_Browse)objModel;
        }

        /// <summary>
        /// 最近浏览
        /// </summary>
        /// <param name="Userinfo_code"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources_Browse> GetListByCreatorTime(Guid Userinfo_code, int pageSize)
        {
            return DataTableToList(dal.GetListByCreatorTime(Userinfo_code, pageSize).Tables[0]);
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
        public List<CommonService.Model.KMS.K_Resources_Browse> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources_Browse> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_Resources_Browse> modelList = new List<CommonService.Model.KMS.K_Resources_Browse>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_Resources_Browse model;
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
        public int GetRecordCount(CommonService.Model.KMS.K_Resources_Browse model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources_Browse> GetListByPage(CommonService.Model.KMS.K_Resources_Browse model, string orderby, int startIndex, int endIndex)
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
    }
}