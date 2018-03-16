using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 知识分类表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
	public partial class K_Knowledge
	{
        private readonly CommonService.DAL.KMS.K_Knowledge dal = new CommonService.DAL.KMS.K_Knowledge();
        private readonly CommonService.DAL.KMS.K_Knowledge_Resources knowledgeResourcesDal = new CommonService.DAL.KMS.K_Knowledge_Resources();
		public K_Knowledge()
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
		public bool Exists(int K_Knowledge_id)
		{
			return dal.Exists(K_Knowledge_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.KMS.K_Knowledge model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.KMS.K_Knowledge model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid K_Knowledge_code)
		{

            return dal.Delete(K_Knowledge_code);
		}

        /// <summary>
        /// 移动资源
        /// </summary>
        /// <param name="knowledgeCode">知识分类Guid</param>
        /// <param name="resourcesCode">资源Guid</param>
        /// <returns></returns>
        public bool MobileResource(Guid knowledgeCode, Guid resourcesCode)
        {
            return knowledgeResourcesDal.MobileResource(knowledgeCode,resourcesCode);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string K_Knowledge_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(K_Knowledge_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.KMS.K_Knowledge GetModel(int K_Knowledge_id)
		{
			
			return dal.GetModel(K_Knowledge_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Knowledge GetModel(Guid K_Knowledge_code)
        {

            return dal.GetModel(K_Knowledge_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.KMS.K_Knowledge GetModelByCache(int K_Knowledge_id)
		{
			
			string CacheKey = "K_KnowledgeModel-" + K_Knowledge_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(K_Knowledge_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.KMS.K_Knowledge)objModel;
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
        public List<CommonService.Model.KMS.K_Knowledge> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Knowledge> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.KMS.K_Knowledge> modelList = new List<CommonService.Model.KMS.K_Knowledge>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.KMS.K_Knowledge model;
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
        public List<CommonService.Model.KMS.K_Knowledge> GetAllList()
		{
            return DataTableToList(dal.GetAllList().Tables[0]);
		}
        /// <summary>
        /// 根据负责人获取全部数据
        /// </summary>
        /// <param name="K_Knowledge_Person">负责人Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Knowledge> GetAllListByPerson(Guid K_Knowledge_Person)
        {
            return DataTableToList(dal.GetAllListByPerson(K_Knowledge_Person).Tables[0]);
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(CommonService.Model.KMS.K_Knowledge model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.KMS.K_Knowledge> GetListByPage(CommonService.Model.KMS.K_Knowledge model, string orderby, int startIndex, int endIndex)
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

