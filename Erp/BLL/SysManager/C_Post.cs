using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 岗位表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class C_Post
	{
        private readonly CommonService.DAL.SysManager.C_Post dal = new CommonService.DAL.SysManager.C_Post();
		public C_Post()
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
        public bool Exists(int C_Post_id)
        {
            return dal.Exists(C_Post_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.SysManager.C_Post model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.SysManager.C_Post model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int C_Post_id)
		{
			
			return dal.Delete(C_Post_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Post_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Post_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.SysManager.C_Post GetModel(int C_Post_id)
		{			
			return dal.GetModel(C_Post_id);
		}

        /// <summary>
        /// 通过岗位Guid，得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Post GetModelByPostCode(Guid postCode)
        {
            return dal.GetModelByPostCode(postCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Post GetLinkRolesModel(Guid C_Post_code)
        {

            return dal.GetLinkRolesModel(C_Post_code);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.SysManager.C_Post GetModelByCache(int C_Post_id)
		{
			
			string CacheKey = "C_PostModel-" + C_Post_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Post_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.SysManager.C_Post)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Model.SysManager.C_Post> GetList(string strWhere)
		{
			return DataTableToList((dal.GetList(strWhere).Tables[0]));
		}

        /// <summary>
        /// 得到所有岗位集合
        /// </summary>
        /// <returns></returns>        
        public List<CommonService.Model.SysManager.C_Post> GetAllPosts()
        {
            return DataTableToList((dal.GetAllPosts().Tables[0]));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.SysManager.C_Post> GetList()
        {
            return DataTableToList(dal.GetList().Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Post> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.SysManager.C_Post> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.SysManager.C_Post> modelList = new List<CommonService.Model.SysManager.C_Post>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.SysManager.C_Post model;
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
        public List<Model.SysManager.C_Post> GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(Model.SysManager.C_Post model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<Model.SysManager.C_Post> GetListByPage(Model.SysManager.C_Post model, string orderby, int startIndex, int endIndex)
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
	}
}

