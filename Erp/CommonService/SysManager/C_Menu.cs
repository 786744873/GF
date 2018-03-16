using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Menu”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Menu.svc 或 C_Menu.svc.cs，然后开始调试。
    public class C_Menu : IC_Menu
    {
        CommonService.BLL.SysManager.C_Menu cmBLL = new CommonService.BLL.SysManager.C_Menu();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return cmBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Menu_id)
        {
            return cmBLL.Exists(C_Menu_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Menu model)
        {
            return cmBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Menu model)
        {
            return cmBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Menu_id)
        {
            return cmBLL.Delete(C_Menu_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Menu GetModel(int C_Menu_id)
        {
            return cmBLL.GetModel(C_Menu_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SysManager.C_Menu> GetAllList()
        {
            return cmBLL.GetAllList();
        }

        /// <summary>
        /// 通过角色，获取角色管理所有菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="isSysManager">是否内置系统管理员</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Menu> GetModelListByRole(int? roleId, bool isSysManager)
        {
            return cmBLL.GetModelListByRole(roleId, isSysManager);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Menu model)
        {
            return cmBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Menu> GetListByPage(CommonService.Model.SysManager.C_Menu model, string orderby, int startIndex, int endIndex)
        {
            return cmBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据角色获取菜单
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>菜单列表</returns>
        public List<CommonService.Model.SysManager.C_Menu> GetMenusByRoleID(int roleID)
        {
            return cmBLL.GetMenusByRoleID(roleID);
        }
        /// <summary>
        /// 根据用户角色获得用户菜单集合
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="isSysManager"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Menu> GetMenuListByRoles(Guid userCode, bool isSysManager)
        {
            return cmBLL.GetMenuListByRoles(userCode, isSysManager);
        }
        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool MoveForward(int menuId)
        {
            return cmBLL.MoveForward(menuId);
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool MoveBackward(int menuId)
        {
            return cmBLL.MoveBackward(menuId);
        }
    }
}
