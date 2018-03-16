using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    /// <summary>
    /// 角色-角色权限关联服务
    /// </summary>
    public class C_Role_Role_Power : IC_Role_Role_Power
    {
        CommonService.BLL.SysManager.C_Role_Role_Power oBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int roleId, int rolePowerId)
        {
            return oBLL.Exists(roleId, rolePowerId);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Role_Role_Power_id)
        {
            return oBLL.Delete(C_Role_Role_Power_id);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Role_Role_Power_id"></param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Role_Role_Power Get(int C_Role_Role_Power_id)
        {
            return oBLL.GetModel(C_Role_Role_Power_id);
        }

        /// <summary>
        /// 通过角色ID，获取关联所有权限集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByRoleId(int roleId)
        {
            return oBLL.GetRolePowersByRoleId(roleId);
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
            return oBLL.GetRolePowersByOrgPostUserCode(orgCode, userCode, postCode);
        }

        /// <summary>
        /// 根据用户Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>      
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByUserCode(Guid? userCode)
        {
            return oBLL.GetRolePowersByUserCode(userCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Role_Role_Power model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_Role_Power> GetListByPage(CommonService.Model.SysManager.C_Role_Role_Power model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据角色获取权限集合
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="IsPreSetManager"></param>
        /// <returns></returns>
        public string GetRolePowers(int RoleId, bool IsPreSetManager)
        {
            return oBLL.GetRolePowers(RoleId, IsPreSetManager);
        }
    }
}
