using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 知识分类和（资源，问吧）中间表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_Knowledge_Resources
	{
        private readonly CommonService.DAL.KMS.K_Knowledge_Resources dal = new CommonService.DAL.KMS.K_Knowledge_Resources();
		public K_Knowledge_Resources()
		{}
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
		public bool Exists(int K_Knowledge_Resources_id)
		{
			return dal.Exists(K_Knowledge_Resources_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.KMS.K_Knowledge_Resources model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.KMS.K_Knowledge_Resources model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid K_Knowledge_Resources_code)
		{
            return dal.Delete(K_Knowledge_Resources_code);
		}

        /// <summary>
        /// 根据关联Guid删除一条数据
        /// </summary>
        public bool DeleteByFkCode(Guid P_FK_code)
        {
            return dal.DeleteByFkCode(P_FK_code);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.KMS.K_Knowledge_Resources> modelList)
        {
            return true;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string K_Knowledge_Resources_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(K_Knowledge_Resources_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModel(int K_Knowledge_Resources_id)
		{
			
			return dal.GetModel(K_Knowledge_Resources_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModel(Guid K_Knowledge_Resources_code)
        {

            return dal.GetModel(K_Knowledge_Resources_code);
        }
        /// <summary>
        /// 根据关联Guid获取一条数据
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModelByFkCode(Guid P_FK_code)
        {
            return dal.GetModelByFkCode(P_FK_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModelByCache(int K_Knowledge_Resources_id)
		{
			
			string CacheKey = "K_Knowledge_ResourcesModel-" + K_Knowledge_Resources_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(K_Knowledge_Resources_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.KMS.K_Knowledge_Resources)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Knowledge_Resources> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Knowledge_Resources> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.KMS.K_Knowledge_Resources> modelList = new List<CommonService.Model.KMS.K_Knowledge_Resources>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.KMS.K_Knowledge_Resources model;
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
		public int GetRecordCount(CommonService.Model.KMS.K_Knowledge_Resources model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Knowledge_Resources> GetListByPage(CommonService.Model.KMS.K_Knowledge_Resources model, string orderby, int startIndex, int endIndex)
		{
			return DataTableToList(dal.GetListByPage( model,  orderby,  startIndex,  endIndex).Tables[0]);
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

