using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Resources
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
        bool Exists(int K_Resources_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Resources model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Resources GetModel(Guid K_Resources_code);
        /// <summary>
        /// 根据视频Id得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Resources GetModelByUrl(string K_Resources_url);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Resources model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Resources_code);
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <param name="K_Resources_idlist">code列表</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteList(string K_Resources_idlist);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code">K_Resources_code数据集</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetListByCode(string code);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Resources model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetListByPage(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据资源类型获取前几条最热的数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetListByzambiaCount(int count, string K_Knowledge_name, int? K_Knowledge_Resources_type);
        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        [OperationContract]
        int GetRecordCountByMonth(CommonService.Model.KMS.K_Resources model);
        /// <summary>
        /// 根据浏览量和资源类型获取前几天数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetListByBrowseCount(int count, Guid? K_Knowledge_code, int? K_Resources_type);
        /// <summary>
        /// 资源审核
        /// </summary>
        /// <param name="resourcesCode">资源Guid(多个，以逗号隔开)</param>
        /// <param name="state">审核状态</param>
        /// <returns></returns>
        [OperationContract]
        bool ResourcesAudit(string resourcesCode, int state);
        /// <summary>
        /// 资源下载权限
        /// </summary>
        /// <param name="resourcesCode">资源Guid(以逗号隔开，多个处理)</param>
        /// <returns></returns>
        [OperationContract]
        bool ResourcesPermissions(string resourcesCode, int permissions);
        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetSearchList();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> SearchResources(string path, string keyWord);
        /// <summary>
        /// 我的文档/视屏
        /// </summary>
        /// <param name="createCode">用户Guid</param>
        /// <param name="type">1、文档；2、视频</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> MyDocumentAndVideoList(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex, int type);
        /// <summary>
        /// 我的文档/视屏数量
        /// </summary>
        [OperationContract]
        int MyDocumentAndVideoListCount(CommonService.Model.KMS.K_Resources model, int type);
        /// <summary>
        /// 获取最近上传几条数据
        /// </summary>
        /// <param name="K_Resources_creator">用户Guid</param>
        /// <param name="pageSize">获取几条数据</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetListByRecentUpload(Guid K_Resources_creator, int pageSize);
        /// <summary>
        /// 根据查询关键字，返回查询到的数据code
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        [OperationContract]
        string GetResourcesCodelist(string path, string keyWord);
                /// <summary>
        /// 根据资源code集合获得资源集合
        /// </summary>
        /// <param name="codeList"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources> GetListByCodeList(string codeList, string type);

    }
}
