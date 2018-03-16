using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 角色-角色权限关联表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/07/09
    /// </summary>
    public partial class C_Role_Role_Power
    {
        private readonly CommonService.DAL.SysManager.C_Role_Role_Power dal = new CommonService.DAL.SysManager.C_Role_Role_Power();
        public C_Role_Role_Power()
        { }
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
        public bool Exists(int roleId, int rolePowerId)
        {
            return dal.Exists(roleId, rolePowerId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Role_Role_Power_id)
        {

            return dal.Delete(C_Role_Role_Power_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Role_Role_Power_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Role_Role_Power_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Role_Role_Power GetModel(int C_Role_Role_Power_id)
        {

            return dal.GetModel(C_Role_Role_Power_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.DAL.SysManager.C_Role_Role_Power GetModelByCache(int C_Role_Role_Power_id)
        {

            string CacheKey = "C_Role_Role_PowerModel-" + C_Role_Role_Power_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Role_Role_Power_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.DAL.SysManager.C_Role_Role_Power)objModel;
        }

        /// <summary>
        /// 通过角色ID，获取关联所有权限集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByRoleId(int roleId)
        {
            DataSet ds = dal.GetRolePowersByRoleId(roleId);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据部门Guid、用户Guid、岗位Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>       
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByOrgPostUserCode(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            DataSet ds = dal.GetRolePowersByOrgPostUserCode(orgCode, userCode, postCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据用户Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>      
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByUserCode(Guid? userCode)
        {
            DataSet ds = dal.GetRolePowersByUserCode(userCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过组织机构Guid、用户Guid、岗位Guid，获取关联角色，关联数据权限集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersOrgUserPostCode(Guid? orgCode,Guid? userCode,Guid? postCode)
        {
            DataSet ds = dal.GetRolePowersOrgUserPostCode(orgCode, userCode, postCode);
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
        /// 根据首席专家获得关联部长权限数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetListByChiefExpertCode(Guid C_ChiefExpert_Code)
        {
            return DataTableToList(dal.GetListByChiefExpertCode(C_ChiefExpert_Code).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Role_Role_Power> modelList = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Role_Role_Power model;
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
        public int GetRecordCount(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            // return dal.GetRecordCount(strWhere);
            return 0;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetListByPage(CommonService.Model.SysManager.C_Role_Role_Power model, string orderby, int startIndex, int endIndex)
        {
            // return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
            return null;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        public string GetRolePowers(int RoleId, bool IsPreSetManager)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = DataTableToList(dal.GetRolePowersByRoleId(RoleId).Tables[0]);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            else
            {
                return ",22,";
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            return rolePowerIds;
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
