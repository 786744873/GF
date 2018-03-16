using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    /// <summary>
    /// 角色权限服务
    /// </summary>
    public class C_Role_Power : IC_Role_Power
    {
        CommonService.BLL.SysManager.C_Role_Power oBLL = new CommonService.BLL.SysManager.C_Role_Power();

        /// <summary>
        /// 获取所有角色权限集合
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_Power> GetAllList()
        {
            return oBLL.GetAllList();
        }
        /// <summary>
        /// 根据权限类型获取所有角色权限集合
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_Power> GetListByType(int? type)
        {
            return oBLL.GetListByType(type);
        }
    }
}
