using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService.SysManager;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Role_menu”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Role_menu.svc 或 C_Role_menu.svc.cs，然后开始调试。
    public class C_Role_menu : IC_Role_menu
    {
        CommonService.BLL.SysManager.C_Role_menu rmBLL = new CommonService.BLL.SysManager.C_Role_menu();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Role_menu model)
        {
            return rmBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_menu model)
        {
            return rmBLL.Update(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_Roles_id"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_menu> GetListByRoleId(int C_Roles_id)
        {
            return rmBLL.GetListByRoleId(C_Roles_id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_id">菜单ID</param>
        /// <returns></returns>
        public bool Delete(int C_Roles_id, int C_Menu_id)
        {
            return rmBLL.Delete(C_Roles_id, C_Menu_id);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Role_menu model)
        {
            return rmBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_menu> GetListByPage(CommonService.Model.SysManager.C_Role_menu model, string orderby, int startIndex, int endIndex)
        {
            return rmBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据角色ID删除所有角色与菜单之间的关系
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool DeleteRoleMenuByRoleID(int roleID)
        {
            return rmBLL.DeleteRoleMenuByRoleID(roleID);
        }

        /// <summary>
        /// 批量添加同一角色与多个菜单之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="menus">菜单ID集合</param>
        public void AddUserinfoAreas(int roleID, List<int> menus)
        {
            rmBLL.AddUserinfoAreas(roleID, menus);
        }
    }
}
