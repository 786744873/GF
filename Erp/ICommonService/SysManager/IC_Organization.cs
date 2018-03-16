using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Organization”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Organization
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
        bool Exists(int C_Organization_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Organization model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Organization model, Guid oldguid);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Organization_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Organization_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.SysManager.C_Organization Get(Guid C_Organization_code);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization> GetAllList();
        /// <summary>
        /// 根据组织架构code获得列表
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization> GetChirldAllList(Guid? orgCode);

        /// <summary>
        /// 根据用户Guid获得关联部门
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization> GetListByUserCode(Guid userCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Organization model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization> GetListByPage(CommonService.Model.SysManager.C_Organization model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 通过父级GUID获取子集
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization> GetModelByParent(Guid parentCode);
        /// <summary>
        /// 根据用户获得用户关联区域下包含（type=1、律师 2、专业顾问）的组织架构
        /// </summary>
        /// <param name="userinfoCode">用户Guid</param>
        /// <param name="type">type=1、包含律师的组织架构 2、包含专业顾问的组织架构</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization> GetContainLawyerOrAdvisorList(Guid userinfoCode, int? type);
        /// <summary>
        /// orgParentCode所有子集是否包含orgCode
        /// </summary>
        /// <param name="orgParentCode"></param>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool isHeadOrganizationCode(Guid orgParentCode, Guid orgCode);
        #region App专用

        /// <summary>
        /// App端根据权限获取组织架构列表（紧获取二级）
        /// </summary>
        /// <returns>组织架构列表</returns>
        [WebInvoke(UriTemplate = "AppGetDepartments", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Organization> AppGetDepartments();
        #endregion


    }
}
