using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件级别变更记录表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/12/16
    /// </summary>
	public partial class B_CaseLevelChangeRecords
	{
        private readonly CommonService.DAL.CaseManager.B_CaseLevelChangeRecords dal = new CommonService.DAL.CaseManager.B_CaseLevelChangeRecords();
		public B_CaseLevelChangeRecords()
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
		public bool Exists(int B_CaseLevelChangeRecords_id)
		{
			return dal.Exists(B_CaseLevelChangeRecords_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_CaseLevelChangeRecords_id)
		{
			
			return dal.Delete(B_CaseLevelChangeRecords_id);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_CaseLevelChangeRecords_code)
        {

            return dal.Delete(B_CaseLevelChangeRecords_code);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_CaseLevelChangeRecords_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_CaseLevelChangeRecords_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModel(int B_CaseLevelChangeRecords_id)
		{
			
			return dal.GetModel(B_CaseLevelChangeRecords_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModel(Guid B_CaseLevelChangeRecords_code)
        {

            return dal.GetModel(B_CaseLevelChangeRecords_code);
        }
        /// <summary>
        /// 根据案件Guid获得记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCode(Guid caseCode)
        {
            return dal.GetModelByCaseCode(caseCode);
        }

         /// <summary>
        /// 根据案件Guid获得未审核的记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCodeIsNotAudit(Guid caseCode)
        {
            return dal.GetModelByCaseCodeIsNotAudit(caseCode);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModelByCache(int B_CaseLevelChangeRecords_id)
		{
			
			string CacheKey = "B_CaseLevelChangeRecordsModel-" + B_CaseLevelChangeRecords_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_CaseLevelChangeRecords_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CaseManager.B_CaseLevelChangeRecords)objModel;
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
        public List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 根据案件Guid获得数据
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_CaseLevelChangeRecords> GetListByCaseCode(Guid CaseCode)
        {
            return DataTableToList(dal.GetListByCaseCode(CaseCode).Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> modelList = new List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CaseManager.B_CaseLevelChangeRecords model;
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> GetListByPage(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model, string orderby, int startIndex, int endIndex)
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

