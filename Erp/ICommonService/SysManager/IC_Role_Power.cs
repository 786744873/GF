using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    /// <summary>
    /// 角色权限契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Role_Power
    {
        /// <summary>
        /// 获取所有角色权限集合
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_Power> GetAllList();
        /// <summary>
        /// 根据权限类型获取所有角色权限集合
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Role_Power> GetListByType(int? type);

    }
}
