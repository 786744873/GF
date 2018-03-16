using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
	/// <summary>
	/// 用户--案件中间表
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	public partial class C_Userinfo_case_type
	{
        private readonly CommonService.DAL.SysManager.C_Userinfo_case_type dal = new CommonService.DAL.SysManager.C_Userinfo_case_type();
        public C_Userinfo_case_type()
		{}
		#region  BasicMethod
        /// <summary>
        /// 查找是否存在实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exits(CommonService.Model.SysManager.C_Userinfo_case_type model)
        {
            return dal.Exits(model);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.SysManager.C_Userinfo_case_type model)
		{
            bool isSuccess = true;
            isSuccess=dal.Delete(model.C_Userinfo_code.Value,model.C_Parameters_id.Value);
            isSuccess = dal.Add(model);
            
            return isSuccess;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.SysManager.C_Userinfo_case_type model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid userCode, int parametersId)
		{
            return dal.Delete(userCode, parametersId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.SysManager.C_Userinfo_case_type GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.SysManager.C_Userinfo_case_type GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "C_Userinfo_case_typeModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.SysManager.C_Userinfo_case_type)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public List<CommonService.Model.SysManager.C_Userinfo_case_type> GetListByRoleId(int roleId)
        {
            return DataTableToList(dal.GetListByRoleId(roleId).Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Userinfo_case_type> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo_case_type> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.SysManager.C_Userinfo_case_type> modelList = new List<CommonService.Model.SysManager.C_Userinfo_case_type>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.SysManager.C_Userinfo_case_type model;
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
        public int GetRecordCount(Model.SysManager.C_Userinfo_case_type model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<Model.SysManager.C_Userinfo_case_type> GetListByPage(Model.SysManager.C_Userinfo_case_type model, string orderby, int startIndex, int endIndex)
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

        /// <summary>
        /// 根据用户编码删除用户和案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        public bool DeleteUserinfoCaseTypeByUserCode(Guid userCode)
        {
            return dal.DeleteUserinfoCaseTypeByUserCode(userCode);
        }

        /// <summary>
        /// 批量添加同一用户与多个案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="caseTypeIDs">案件类型ID集合</param>
        //public void AddUserinfoCaseTypes(int userCode, List<int> caseTypeIDs)
        //{
        //    foreach (int item in caseTypeIDs)
        //    {
        //        Model.C_Role_case_type model = new Model.C_Role_case_type();
        //        model.C_Roles_id = userCode;
        //        model.C_Parameters_id = item;
        //        Add(model);
        //    }
        //}
		#endregion  ExtensionMethod
	}
}

