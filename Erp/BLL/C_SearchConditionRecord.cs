using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 查询条件记录表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/12/03
    /// </summary>
	public partial class C_SearchConditionRecord
	{
        private readonly CommonService.DAL.C_SearchConditionRecord dal = new CommonService.DAL.C_SearchConditionRecord();
		public C_SearchConditionRecord()
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
		public bool Exists(int C_SearchConditionRecord_id)
		{
			return dal.Exists(C_SearchConditionRecord_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_SearchConditionRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_SearchConditionRecord model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="C_SearchConditionRecord"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.C_SearchConditionRecord> C_SearchConditionRecords)
        {
            foreach(CommonService.Model.C_SearchConditionRecord C_SearchConditionRecord in C_SearchConditionRecords)
            {
                dal.Add(C_SearchConditionRecord);
            }
            return true;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int C_SearchConditionRecord_id)
		{
			
			return dal.Delete(C_SearchConditionRecord_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_SearchConditionRecord_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_SearchConditionRecord_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.C_SearchConditionRecord GetModel(int C_SearchConditionRecord_id)
		{
			
			return dal.GetModel(C_SearchConditionRecord_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_SearchConditionRecord GetModelByCache(int C_SearchConditionRecord_id)
		{
			
			string CacheKey = "C_SearchConditionRecordModel-" + C_SearchConditionRecord_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_SearchConditionRecord_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_SearchConditionRecord)objModel;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_SearchConditionRecord> GetListByGroup(Guid C_SearchConditionRecord_group)
        {
            DataSet ds = dal.GetListByGroup(C_SearchConditionRecord_group);
            return DataTableToList(ds.Tables[0]);
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
        public List<CommonService.Model.C_SearchConditionRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_SearchConditionRecord> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_SearchConditionRecord> modelList = new List<CommonService.Model.C_SearchConditionRecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_SearchConditionRecord model;
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

