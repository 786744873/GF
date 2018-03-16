using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 角色表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/28
    /// </summary>
	public partial class C_Group
	{
        private readonly CommonService.DAL.SysManager.C_Group dal = new CommonService.DAL.SysManager.C_Group();
		public C_Group()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Group_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Group_id)
        {
            return dal.Exists(C_Group_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.SysManager.C_Group model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.SysManager.C_Group model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid C_Group_code)
		{
            bool isSuccess = dal.Delete(C_Group_code);
            if (isSuccess)
            {
                List<CommonService.Model.SysManager.C_Group> ChildrenGroups = GetListByParentCode(C_Group_code);
                foreach (CommonService.Model.SysManager.C_Group childrenGroup in ChildrenGroups)
                {
                    dal.Delete(childrenGroup.C_Group_code.Value);
                    RecursionDelete(childrenGroup.C_Group_code.Value);
                }
            }
            return isSuccess;
		}
        /// <summary>
        /// 递归删除
        /// </summary>
        /// <returns></returns>
        private void RecursionDelete(Guid parentGroupCode)
        {
            List<CommonService.Model.SysManager.C_Group> ChildrenGroups = GetListByParentCode(parentGroupCode);
            foreach (CommonService.Model.SysManager.C_Group childrenGroup in ChildrenGroups)
            {
                dal.Delete(childrenGroup.C_Group_code.Value);
                RecursionDelete(childrenGroup.C_Group_code.Value);
            }
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Group_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Group_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.SysManager.C_Group GetModel(Guid C_Group_code)
		{

            return dal.GetModel(C_Group_code);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Group GetModel(int C_Group_id)
        {

            return dal.GetModel(C_Group_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Group GetModelByCode(Guid C_Group_code)
        {

            return dal.GetModelByCode(C_Group_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.SysManager.C_Group GetModelByCache(int C_Group_id)
		{
			
			string CacheKey = "C_GroupModel-" + C_Group_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Group_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.SysManager.C_Group)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 根据父级分组获取子集数据集合
        /// </summary>
        /// <param name="C_Group_parent"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Group> GetListByParentCode(Guid C_Group_parent)
        {
            return DataTableToList(dal.GetListByParentCode(C_Group_parent).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SysManager.C_Group> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
        }

        /// <summary>
        /// 根据用户Guid获得用户关联岗位的所属分组
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Group> GetListByUserCode(Guid userCode)
        {
            return DataTableToList(dal.GetListByUserCode(userCode).Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Group> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.SysManager.C_Group> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.SysManager.C_Group> modelList = new List<CommonService.Model.SysManager.C_Group>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.SysManager.C_Group model;
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
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(CommonService.Model.SysManager.C_Group model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<CommonService.Model.SysManager.C_Group> GetListByPage(CommonService.Model.SysManager.C_Group model, string orderby, int startIndex, int endIndex)
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

