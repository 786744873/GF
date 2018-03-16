using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 担保物约定表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/06
    /// </summary>
	public partial class B_Oppint
	{
        private readonly CommonService.DAL.CaseManager.B_Oppint dal = new CommonService.DAL.CaseManager.B_Oppint();
		public B_Oppint()
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
        public bool Exists(int B_Oppint_id)
        {
            return dal.Exists(B_Oppint_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_Oppint model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Oppint model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_Oppint_id)
		{
			
			return dal.Delete(B_Oppint_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_Oppint_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_Oppint_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_Oppint GetModel(int B_Oppint_id)
		{
			
			return dal.GetModel(B_Oppint_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CaseManager.B_Oppint GetModelByCache(int B_Oppint_id)
		{
			
			string CacheKey = "B_OppintModel-" + B_Oppint_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_Oppint_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CaseManager.B_Oppint)objModel;
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
        public List<CommonService.Model.CaseManager.B_Oppint> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_Oppint> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CaseManager.B_Oppint> modelList = new List<CommonService.Model.CaseManager.B_Oppint>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CaseManager.B_Oppint model;
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
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Oppint> GetListByCaseCode(Guid B_Case_code)
        {
            return DataTableToList(dal.GetListByCaseCode(B_Case_code).Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(CommonService.Model.CaseManager.B_Oppint model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<CommonService.Model.CaseManager.B_Oppint> GetListByPage(CommonService.Model.CaseManager.B_Oppint model, string orderby, int startIndex, int endIndex)
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

