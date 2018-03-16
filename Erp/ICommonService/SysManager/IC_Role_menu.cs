using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Role_menu”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Role_menu
    {
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Role_menu model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Role_menu model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_id">菜单ID</param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(int C_Roles_id, int C_Menu_id);

         /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_Roles_id"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_menu> GetListByRoleId(int C_Roles_id);


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Role_menu model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_menu> GetListByPage(CommonService.Model.SysManager.C_Role_menu model, string orderby, int startIndex, int endIndex);


        /// <summary>
        /// 根据角色ID删除所有角色与菜单之间的关系
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteRoleMenuByRoleID(int roleID);

        /// <summary>
        /// 批量添加同一角色与多个菜单之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="menus">菜单ID集合</param>
        [OperationContract]
        void AddUserinfoAreas(int roleID, List<int> menus);

    }
}
