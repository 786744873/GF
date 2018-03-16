using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Roles”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Roles
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
        bool Exists(int C_Roles_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Roles model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Roles model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Roles_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Roles GetModel(int C_Roles_id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
         [OperationContract]
        List<CommonService.Model.SysManager.C_Roles> GetAllList();

         /// <summary>
         /// 获取所有角色，并且根据组织机构Guid，用户Guid，岗位Guid设置关联角色状态值
         /// </summary>
         /// <param name="orgCode">织机构Guid</param>
         /// <param name="userCode">用户Guid</param>
         /// <param name="postCode">岗位Guid</param>
         /// <returns></returns>
         [OperationContract]
         List<CommonService.Model.SysManager.C_Roles> GetAllRoles(Guid? orgCode, Guid? userCode, Guid? postCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Roles model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Roles> GetListByPage(CommonService.Model.SysManager.C_Roles model, string orderby, int startIndex, int endIndex);
    }
}
