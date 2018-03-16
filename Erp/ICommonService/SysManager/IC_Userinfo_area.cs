using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Userinfo_area”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Userinfo_area
    {
        /// <summary>
        /// 查找是否存在一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       [OperationContract]
        bool Exits(CommonService.Model.SysManager.C_Userinfo_region model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Userinfo_region model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Userinfo_region model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Role_id">角色ID</param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid userCode, Guid Region_code);

        /// <summary>
        /// 根据用户获得关联数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Userinfo_region> GetListByUserinfoCode(Guid userCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Userinfo_region model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Userinfo_region> GetListByPage(CommonService.Model.SysManager.C_Userinfo_region model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据用户编码删除所有的用户和区域之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool DeleteUserinfoAreaByUserCode(Guid userCode);

        /// <summary>
        /// 批量添加同一用户与多个区域之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="areaIDs">区域ID集合</param>
        //[OperationContract]
        //void AddUserinfoAreas(Guid userCode, List<int> areaIDs);
    }
}
