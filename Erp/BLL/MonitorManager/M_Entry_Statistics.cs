using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.MonitorManager
{
    /// <summary>
    /// 条目统计表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/11
    /// </summary>
	public partial class M_Entry_Statistics
	{
        private readonly CommonService.DAL.MonitorManager.M_Entry_Statistics dal = new CommonService.DAL.MonitorManager.M_Entry_Statistics();

        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
		public M_Entry_Statistics()
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
        public bool Exists(int M_Entry_Statistics_id)
        {
            return dal.Exists(M_Entry_Statistics_id);
        }

        /// <summary>
        /// 根据案件Guid，检查是否有延期条目统计信息
        /// </summary>
        /// <param name="pkCode">案件guid</param>
        /// <returns></returns>
        public bool ExistsDelayByPkCode(Guid pkCode)
        {
            return dal.ExistsDelayByPkCode(pkCode);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.MonitorManager.M_Entry_Statistics model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.MonitorManager.M_Entry_Statistics model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 修改办案状态(手工结束)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHandlingState(Guid M_Entry_Statistics_code)
        {
            return dal.UpdateHandlingState(M_Entry_Statistics_code);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int M_Entry_Statistics_id)
		{
			
			return dal.Delete(M_Entry_Statistics_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string M_Entry_Statistics_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(M_Entry_Statistics_idlist,0) );
		}

		/// <summary>
        /// 得到一个对象实体
		/// </summary>
        public CommonService.Model.MonitorManager.M_Entry_Statistics GetModel(int M_Entry_Statistics_id)
		{
			
			return dal.GetModel(M_Entry_Statistics_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.MonitorManager.M_Entry_Statistics GetModel(Guid M_Entry_Statistics_code)
        {

            return dal.GetModel(M_Entry_Statistics_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.MonitorManager.M_Entry_Statistics GetModelByCache(int M_Entry_Statistics_id)
		{
			
			string CacheKey = "M_Entry_StatisticsModel-" + M_Entry_Statistics_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(M_Entry_Statistics_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.MonitorManager.M_Entry_Statistics)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
         /// <summary>
        /// 根据预警情况获得'非预警'数据列表
        /// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetListByWarningSituation()
        {
            return DataTableToList(dal.GetListByWarningSituation().Tables[0]);
        }
         /// <summary>
        /// 根据办案状态获得非'已结束'数据列表
        /// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetListByHandlingState()
        {
            return DataTableToList(dal.GetListByHandlingState().Tables[0]);
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
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.MonitorManager.M_Entry_Statistics> modelList = new List<CommonService.Model.MonitorManager.M_Entry_Statistics>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.MonitorManager.M_Entry_Statistics model;
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
        public int GetRecordCount(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
		{
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }
            return dal.GetRecordCount(model, casemodel, orderby, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetListByPage(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode,string tj)
		{
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            return DataTableToList(dal.GetListByPage(model, casemodel, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode).Tables[0]);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  App专用

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> AppGetListByPage(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersByRoleId(RoleId.Value);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            return DataTableToList(dal.AppGetListByPage(model, casemodel, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode).Tables[0]);
        }

		#endregion
	}
}

