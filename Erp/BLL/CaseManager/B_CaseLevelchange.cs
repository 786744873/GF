using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件级别变更表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/12/16
    /// </summary>
	public partial class B_CaseLevelchange
	{
        private readonly CommonService.DAL.CaseManager.B_CaseLevelchange dal = new CommonService.DAL.CaseManager.B_CaseLevelchange();
		public B_CaseLevelchange()
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
		public bool Exists(int B_CaseLevelchange_id)
		{
			return dal.Exists(B_CaseLevelchange_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseLevelchange model)
		{
			return dal.Add(model);
		}

        public int OpreateList(List<CommonService.Model.CaseManager.B_CaseLevelchange> CaseLevelchangeList)
        {
            int isSuccess = 0;
            foreach (CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange in CaseLevelchangeList)
            {
                isSuccess = dal.Add(caseLevelChange);
            }
            return isSuccess;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CaseManager.B_CaseLevelchange model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 根据案件Guid查询是否有未审核的变更数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public bool IsNotAudited(Guid caseCode)
        {
            return dal.IsNotAudited(caseCode);
        }

         /// <summary>
        /// 根据案件Guid查询是否有变更记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public bool IsChange(Guid caseCode)
        {
            return dal.IsChange(caseCode);
        }
        /// <summary>
        /// 根据案件Guid查询是否有调整记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="B_CaseLevelchange_type">案件级别变更类型</param>
        /// <returns></returns>
        public bool IsHardToAdjust(Guid caseCode, int B_CaseLevelchange_type)
        {
            return dal.IsHardToAdjust(caseCode, B_CaseLevelchange_type);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_CaseLevelchange_id)
		{
			
			return dal.Delete(B_CaseLevelchange_id);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_CaseLevelchange_code)
        {

            return dal.Delete(B_CaseLevelchange_code);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_CaseLevelchange_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_CaseLevelchange_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelchange GetModel(int B_CaseLevelchange_id)
		{
			
			return dal.GetModel(B_CaseLevelchange_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelchange GetModel(Guid B_CaseLevelchange_code)
        {

            return dal.GetModel(B_CaseLevelchange_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CaseManager.B_CaseLevelchange GetModelByCache(int B_CaseLevelchange_id)
		{
			
			string CacheKey = "B_CaseLevelchangeModel-" + B_CaseLevelchange_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_CaseLevelchange_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CaseManager.B_CaseLevelchange)objModel;
		}

         /// <summary>
        /// 根据变更记录Guid获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_CaseLevelchange> GetListByChangeRecord(Guid B_CaseLevelchange_changeRecord)
        {
            return DataTableToList(dal.GetListByChangeRecord(B_CaseLevelchange_changeRecord).Tables[0]);
        }

        /// <summary>
        /// 根据案件Guid获得数据列表
        /// </summary>
        public List<Model.CaseManager.B_CaseLevelchange> GetListByCaseCode(Guid B_Case_code,int type)
        {
            return DataTableToList(dal.GetListByCaseCode(B_Case_code, type).Tables[0]);
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
        public List<CommonService.Model.CaseManager.B_CaseLevelchange> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_CaseLevelchange> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CaseManager.B_CaseLevelchange> modelList = new List<CommonService.Model.CaseManager.B_CaseLevelchange>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CaseManager.B_CaseLevelchange model;
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_CaseLevelchange model)
		{
            return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_CaseLevelchange> GetListByPage(CommonService.Model.CaseManager.B_CaseLevelchange model, string orderby, int startIndex, int endIndex)
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

