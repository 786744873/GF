using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Role_button”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Role_button
    {


        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Role_button model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Role_button model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_buttons_id">按钮ID</param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(int C_Roles_id, int C_Menu_buttons_id);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_id">菜单ID</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_button> GetListByMenuId(int C_Roles_id, int C_Menu_id);

        [OperationContract]
        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        List<CommonService.Model.SysManager.C_Role_button> GetButtonsByRoleId(int roleId);
        /// <summary>
        /// 根据角色Id集合，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_button> GetButtonsListByRolesId(string rolesId);

        /// <summary>
        /// 根据组织机构Guid、用户Guid、岗位Guid，获取关联角色关联按钮集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_button> GetButtonsListByOrgUserPostCode(Guid? orgCode,Guid? userCode,Guid? postCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Role_button model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_button> GetListByPage(CommonService.Model.SysManager.C_Role_button model, string orderby, int startIndex, int endIndex);


        /// <summary>
        /// 根据角色ID删除所有角色与按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool DeleteRoleButtonByRoleID(int roleID);

        /// <summary>
        /// 批量添加同一角色与多个按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="buttons">按钮ID集合</param>
        [OperationContract]
        void AddUserinfoAreas(int roleID, List<int> buttons);
    }
}
