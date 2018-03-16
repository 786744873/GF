using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    /// <summary>
    /// 角色-角色权限关联契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Role_Role_Power
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="rolePowerId">角色权限Id</param>
        /// <returns></returns>
        [OperationContract]
        bool Exists(int roleId, int rolePowerId);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Role_Role_Power model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Role_Role_Power model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Role_Role_Power_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Role_Role_Power_id"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.SysManager.C_Role_Role_Power Get(int C_Role_Role_Power_id);

        /// <summary>
        /// 通过角色ID，获取关联所有权限集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByRoleId(int roleId);

        /// <summary>
        /// 根据部门Guid、用户Guid、岗位Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByOrgPostUserCode(Guid? orgCode,Guid? userCode,Guid? postCode);

        /// <summary>
        /// 根据用户Guid，获取关联所有权限集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_Role_Power> GetRolePowersByUserCode(Guid? userCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Role_Role_Power model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_Role_Power> GetListByPage(CommonService.Model.SysManager.C_Role_Role_Power model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据角色ID 获取权限集合
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="IsPreSetManager"></param>
        /// <returns></returns>
        [OperationContract]
        string GetRolePowers(int RoleId, bool IsPreSetManager);
    }
}
