using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Userinfo_case_type”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Userinfo_case_type
    {
           /// <summary>
        /// 查找是否存在实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool Exits(CommonService.Model.SysManager.C_Userinfo_case_type model);
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Userinfo_case_type model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Userinfo_case_type model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="parametersId">案件类型ID</param>
        /// <returns></returns>
         [OperationContract]
        bool Delete(Guid userCode, int parametersId);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Userinfo_case_type model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Userinfo_case_type> GetListByPage(CommonService.Model.SysManager.C_Userinfo_case_type model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据用户编码删除用户和案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool DeleteUserinfoCaseTypeByUserCode(Guid userCode);

        /// <summary>
        /// 批量添加同一用户与多个案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="caseTypeIDs">案件类型ID集合</param>
        //[OperationContract]
        //void AddUserinfoCaseTypes(Guid userCode, List<int> caseTypeIDs);
    }
}
