using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.Feedback
{
    /// <summary>
    /// 意见反馈表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/14
    /// </summary>
	public partial class C_Feedback
	{
        private readonly CommonService.DAL.Feedback.C_Feedback dal = new CommonService.DAL.Feedback.C_Feedback();
		public C_Feedback()
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
		public bool Exists(int C_Feedback_id)
		{
			return dal.Exists(C_Feedback_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.Feedback.C_Feedback model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.Feedback.C_Feedback model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="FeedbackList"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.Feedback.C_Feedback> FeedbackList)
        {
            bool isSuccess = false;
            foreach(CommonService.Model.Feedback.C_Feedback feedback in FeedbackList)
            {
                isSuccess = dal.Update(feedback);
            }

            return isSuccess;
        }

           /// <summary>
        /// 根据申请人获得数据
        /// </summary>
        /// <param name="C_Feedback_applicant"></param>
        /// <returns></returns>
        public List<Model.Feedback.C_Feedback> GetListByApplicant(Guid C_Feedback_applicant)
        {
            return DataTableToList(dal.GetListByApplicant(C_Feedback_applicant).Tables[0]);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int C_Feedback_id)
		{
			
			return dal.Delete(C_Feedback_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Feedback_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Feedback_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.Feedback.C_Feedback GetModel(int C_Feedback_id)
		{
			
			return dal.GetModel(C_Feedback_id);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Feedback.C_Feedback GetModel(Guid C_Feedback_code)
        {

            return dal.GetModel(C_Feedback_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.Feedback.C_Feedback GetModelByCache(int C_Feedback_id)
		{
			
			string CacheKey = "C_FeedbackModel-" + C_Feedback_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Feedback_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.Feedback.C_Feedback)objModel;
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
        public List<CommonService.Model.Feedback.C_Feedback> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.Feedback.C_Feedback> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.Feedback.C_Feedback> modelList = new List<CommonService.Model.Feedback.C_Feedback>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.Feedback.C_Feedback model;
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
        public List<CommonService.Model.Feedback.C_Feedback> GetAllList()
		{
            return DataTableToList(dal.GetAllList().Tables[0]);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(CommonService.Model.Feedback.C_Feedback model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.Feedback.C_Feedback> GetListByPage(CommonService.Model.Feedback.C_Feedback model, string orderby, int startIndex, int endIndex)
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

