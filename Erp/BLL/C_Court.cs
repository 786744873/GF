using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// 法院表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Court
    {
        private readonly CommonService.DAL.C_Court dal = new CommonService.DAL.C_Court();
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        public C_Court()   
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
		public bool Exists(int C_Court_id)
		{
			return dal.Exists(C_Court_id);
		}

        /// <summary>
        /// 是否存在该记录(根据名称)
        /// </summary>
        public bool ExistsByName(CommonService.Model.C_Court model)
        {
            return dal.ExistsByName(model);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CommonService.Model.C_Court model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CommonService.Model.C_Court model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid C_Court_code)
		{

            return dal.Delete(C_Court_code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Court_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Court_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CommonService.Model.C_Court GetModel(int C_Court_id)
		{
			
			return dal.GetModel(C_Court_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Court GetModel(Guid C_Court_code)
        {

            return dal.GetModel(C_Court_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CommonService.Model.C_Court GetModelByCache(int C_Court_id)
		{
			
			string CacheKey = "C_CourtModel-" + C_Court_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Court_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CommonService.Model.C_Court)objModel;
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
		public List<CommonService.Model.C_Court> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CommonService.Model.C_Court> DataTableToList(DataTable dt)
		{
			List<CommonService.Model.C_Court> modelList = new List<CommonService.Model.C_Court>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CommonService.Model.C_Court model;
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
		public List<Model.C_Court> GetAllList()
		{
            DataSet ds = dal.GetAllList();
            return DataTableToList(ds.Tables[0]);
		}
        	/// <summary>
		/// 获得律师对应区域code
		/// </summary>
        public List<Model.C_Court> GetAllListByUserRegioncode(Guid userregioncode)
		{
            DataSet ds = dal.GetAllListByUserRegioncode(userregioncode);
            return DataTableToList(ds.Tables[0]);
		}
      
        /// <summary>
        /// 根据律师获得数据列表
        /// </summary>
        /// <param name="Lawyer"></param>
        /// <returns></returns>
        public List<Model.C_Court> GetAllListByLawyer(Guid Lawyer)
        {
            return DataTableToList(dal.GetAllListByLawyer(Lawyer).Tables[0]);
        }

        /// <summary>
        /// 获得法院数据列表
        /// </summary>, bool IsPreSetManager, int? RoleId
        /// <param name="Lawyer"></param>
        /// <returns></returns>
        public List<Model.C_Court> GetListBylawyer(Guid lawyerCode)
        {
            #region ...
            //如果为内置系统管理员，则不允许查关联角色权限
            //string rolePowerIds = String.Empty;
            //if (!IsPreSetManager)
            //{
            //    List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersByRoleId(RoleId.Value);
            //    foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
            //    {
            //        rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
            //    }
            //}
            //if (rolePowerIds != "")
            //{
            //    rolePowerIds = "," + rolePowerIds;
            //}
            #endregion

            return DataTableToList(dal.GetListBylawyer(lawyerCode).Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(Model.C_Court model)
		{
			return dal.GetRecordCount(model);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<Model.C_Court> GetListByPage(Model.C_Court model, string orderby, int startIndex, int endIndex)
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
