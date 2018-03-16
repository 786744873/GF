using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Menu”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Menu
    {

        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_Menu_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Menu model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Menu model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Menu_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Menu GetModel(int C_Menu_id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Menu> GetAllList();
        /// <summary>
        /// 根据用户角色获得用户菜单集合
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="isSysManager"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Menu> GetMenuListByRoles(Guid userCode, bool isSysManager);

        /// <summary>
        /// 通过角色，获取角色管理所有菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="isSysManager">是否内置系统管理员</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Menu> GetModelListByRole(int? roleId, bool isSysManager);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Menu model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Menu> GetListByPage(CommonService.Model.SysManager.C_Menu model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据角色获取菜单
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>菜单列表</returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Menu> GetMenusByRoleID(int roleID);

        ///<summary>
        ///向前移动
        ///</summary>
        ///<returns></returns>
        [OperationContract]
        bool MoveForward(int menuId);

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool MoveBackward(int menuId);
    }
}
