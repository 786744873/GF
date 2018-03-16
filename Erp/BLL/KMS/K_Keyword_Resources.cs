using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 关键字和资源中间表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_Keyword_Resources
	{
        private readonly CommonService.DAL.KMS.K_Keyword_Resources dal = new CommonService.DAL.KMS.K_Keyword_Resources();
		public K_Keyword_Resources()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.KMS.K_Keyword_Resources model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.KMS.K_Keyword_Resources model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.KMS.K_Keyword_Resources> modelList)
        {
            foreach(CommonService.Model.KMS.K_Keyword_Resources keywordResources in modelList)
            {
                dal.Add(keywordResources);
            }
            return true;
        }
        /// <summary>
        /// 根据资源Guid删除资源关连关系
        /// </summary>
        /// <param name="resourcesCode"></param>
        /// <returns></returns>
        public bool DeleteByResourcesCode(Guid resourcesCode)
        {
            return dal.DeleteByResourcesCode(resourcesCode);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.KMS.K_Keyword_Resources GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.KMS.K_Keyword_Resources GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "K_Keyword_ResourcesModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.KMS.K_Keyword_Resources)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 根据资源Guid获得关联关键字
        /// </summary>
        /// <param name="resourcesCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Keyword_Resources> GetListByResourcesCode(Guid resourcesCode)
		{
            DataSet ds = dal.GetListByResourcesCode(resourcesCode);
			return DataTableToList(ds.Tables[0]);
		}
        
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Keyword_Resources> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Keyword_Resources> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.KMS.K_Keyword_Resources> modelList = new List<CommonService.Model.KMS.K_Keyword_Resources>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.KMS.K_Keyword_Resources model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

