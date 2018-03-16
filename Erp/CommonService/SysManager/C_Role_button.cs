using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Role_button”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Role_button.svc 或 C_Role_button.svc.cs，然后开始调试。
    public class C_Role_button : IC_Role_button
    {
        CommonService.BLL.SysManager.C_Role_button rbBLL = new CommonService.BLL.SysManager.C_Role_button();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Role_button model)
        {
            return rbBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_button model)
        {
            return rbBLL.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_buttons_id">按钮ID</param>
        /// <returns></returns>
        public bool Delete(int C_Roles_id, int C_Menu_buttons_id)
        {
            return rbBLL.Delete(C_Roles_id, C_Menu_buttons_id);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_id">菜单ID</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetListByMenuId(int C_Roles_id, int C_Menu_id)
        {
            return rbBLL.GetListByMenuId(C_Roles_id, C_Menu_id);
        }

        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsByRoleId(int roleId)
        {
            return rbBLL.GetButtonsByRoleId(roleId);
        }
        /// <summary>
        /// 根据角色Id集合，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsListByRolesId(string rolesId)
        {
            return rbBLL.GetButtonsListByRolesId(rolesId);
        }

        /// <summary>
        /// 根据组织机构Guid、用户Guid、岗位Guid，获取关联角色关联按钮集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>    
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsListByOrgUserPostCode(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            return rbBLL.GetButtonsListByOrgUserPostCode(orgCode, userCode, postCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Role_button model)
        {
            return rbBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_button> GetListByPage(CommonService.Model.SysManager.C_Role_button model, string orderby, int startIndex, int endIndex)
        {
            return rbBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据角色ID删除所有角色与按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>是否成功</returns>
        public bool DeleteRoleButtonByRoleID(int roleID)
        {
            return rbBLL.DeleteRoleButtonByRoleID(roleID);
        }

        /// <summary>
        /// 批量添加同一角色与多个按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="buttons">按钮ID集合</param>
        public void AddUserinfoAreas(int roleID, List<int> buttons)
        {
            rbBLL.AddUserinfoAreas(roleID, buttons);
        }
    }
}
