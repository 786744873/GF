using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL
{
	/// <summary>
    ///  法官表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/04
	/// </summary>
	public partial class C_Judge
	{
        private readonly CommonService.DAL.C_Judge dal = new CommonService.DAL.C_Judge();
		public C_Judge()
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
        public bool Exists(Guid C_Judge_contactscode)
        {
            return dal.Exists(C_Judge_contactscode);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Judge model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Judge model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid C_Judge_contactscode)
		{

            return dal.Delete(C_Judge_contactscode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Judge_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Judge_idlist,0) );
		}

		/// <summary>
		/// 根据法官Code得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Judge GetModelByJudgeCode(Guid judge_code)
		{

            return dal.GetModelByJudgeCode(judge_code);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Judge GetModelByCache(int C_Judge_id)
		{
			
			string CacheKey = "C_JudgeModel-" + C_Judge_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Judge_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Judge)objModel;
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
        public List<CommonService.Model.C_Judge> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Judge> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Judge> modelList = new List<CommonService.Model.C_Judge>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Judge model;
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
		public int GetRecordCount(Model.C_Judge model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<Model.C_Judge> GetListByPage(Model.C_Judge model, string orderby, int startIndex, int endIndex)
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

