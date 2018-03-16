using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Organization_post”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Organization_post
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
        bool Exists(int C_Organization_post_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Organization_post model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Organization_post model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Organization_post_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Organization_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.SysManager.C_Organization_post GetModel(int C_Organization_post_id);

        /// <summary>
        /// 根据组织机构Guid，获取关联岗位列表
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByOrg(Guid orgCode);
        //根据组织架构guid和子级的guid，获取关联岗位列表
               [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByOrgList(List<Guid> orgCode);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Organization_post model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post> GetListByPage(CommonService.Model.SysManager.C_Organization_post model, string orderby, int startIndex, int endIndex);
        ///// <summary>
        ///// 通过权限id，获取关联岗位集合
        ///// </summary>
        ///// <param name="orgCode">权限</param>
        ///// <returns></returns>
        //[OperationContract]
        //List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByPowerid(int powerId);
    }
}
