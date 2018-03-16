using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.FlowManager
{
    /// <summary>
    /// 流程表----岗位表中间表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Flow_post
	{
        private readonly CommonService.DAL.FlowManager.P_Flow_post dal = new CommonService.DAL.FlowManager.P_Flow_post();
		public P_Flow_post()
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
        public bool Exists(int P_Business_flow_id)
        {
            return dal.Exists(P_Business_flow_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow_post model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Flow_post model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int P_Flow_post_id)
		{
            return dal.Delete(P_Flow_post_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow_post GetModel(int P_Flow_post_id)
		{
            return dal.GetModel(P_Flow_post_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow_post GetModelByCache(int P_Flow_post_id)
		{
			string CacheKey = "P_Flow_postModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(P_Flow_post_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.FlowManager.P_Flow_post)objModel;
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
        /// 根据流程Code获得数据列表
        /// </summary>
        /// <param name="P_Flow_code"></param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow_post> GetListByFlowcode(Guid P_Flow_code)
        {
            return DataTableToList(dal.GetListByFlowcode(P_Flow_code).Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CommonService.Model.FlowManager.P_Flow_post> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.FlowManager.P_Flow_post> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.FlowManager.P_Flow_post> modelList = new List<CommonService.Model.FlowManager.P_Flow_post>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.FlowManager.P_Flow_post model;
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
		public int GetRecordCount(CommonService.Model.FlowManager.P_Flow_post model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<CommonService.Model.FlowManager.P_Flow_post> GetListByPage(CommonService.Model.FlowManager.P_Flow_post model, string orderby, int startIndex, int endIndex)
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

