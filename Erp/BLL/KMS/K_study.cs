using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 学习表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_study
	{
        private readonly CommonService.DAL.KMS.K_study dal = new CommonService.DAL.KMS.K_study();
		public K_study()
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
		public bool Exists(int K_study_id)
		{
			return dal.Exists(K_study_id);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStudy(Guid K_study_creator, Guid K_Resources_code)
        {
            return dal.ExistsStudy(K_study_creator, K_Resources_code);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.KMS.K_study model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.KMS.K_study model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid K_study_code)
		{

            return dal.Delete(K_study_code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string K_study_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(K_study_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.KMS.K_study GetModel(int K_study_id)
		{
			
			return dal.GetModel(K_study_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_study GetModel(Guid K_study_code)
        {

            return dal.GetModel(K_study_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.KMS.K_study GetModelByCache(int K_study_id)
		{
			
			string CacheKey = "K_studyModel-" + K_study_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(K_study_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.KMS.K_study)objModel;
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
        public List<CommonService.Model.KMS.K_study> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_study> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.KMS.K_study> modelList = new List<CommonService.Model.KMS.K_study>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.KMS.K_study model;
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
        /// 最近收藏
        /// </summary>
        /// <param name="K_study_creator">用户Guid</param>
        /// <param name="pageSize">展示数量</param>
        /// <returns></returns>
        public List<Model.KMS.K_study> GetListByCreatorTime(Guid K_study_creator, int pageSize)
        {
            return DataTableToList(dal.GetListByCreatorTime(K_study_creator,pageSize).Tables[0]);
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
		public int GetRecordCount(CommonService.Model.KMS.K_study model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_study> GetListByPage(CommonService.Model.KMS.K_study model, string orderby, int startIndex, int endIndex)
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

