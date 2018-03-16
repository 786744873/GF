using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 联系人工作经历表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/04/29
    /// </summary>
	public partial class C_Contacts_experience
	{
        private readonly CommonService.DAL.C_Contacts_experience dal = new CommonService.DAL.C_Contacts_experience();
		public C_Contacts_experience()
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
        public bool Exists(int C_Contacts_experience_id)
        {
            return dal.Exists(C_Contacts_experience_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CommonService.Model.C_Contacts_experience model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CommonService.Model.C_Contacts_experience model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int C_Contacts_experience_id)
		{

            return dal.Delete(C_Contacts_experience_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Contacts_experience_idlist )
		{
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Contacts_experience_idlist, 0));
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CommonService.Model.C_Contacts_experience GetModel(int C_Contacts_experience_id)
		{
			
			return dal.GetModel(C_Contacts_experience_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Contacts_experience GetModel(Guid C_Contacts_code)
        {

            return dal.GetModel(C_Contacts_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CommonService.Model.C_Contacts_experience GetModelByCache(int C_Contacts_experience_id)
		{
			
			string CacheKey = "C_Contacts_experienceModel-" + C_Contacts_experience_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Contacts_experience_id);
					if (objModel != null)
					{
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CommonService.Model.C_Contacts_experience)objModel;
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
		public List<CommonService.Model.C_Contacts_experience> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CommonService.Model.C_Contacts_experience> DataTableToList(DataTable dt)
		{
			List<CommonService.Model.C_Contacts_experience> modelList = new List<CommonService.Model.C_Contacts_experience>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CommonService.Model.C_Contacts_experience model;
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
        public int GetRecordCount(Model.C_Contacts_experience model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<Model.C_Contacts_experience> GetListByPage(Model.C_Contacts_experience model, string orderby, int startIndex, int endIndex)
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

