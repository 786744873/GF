using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件关联契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_link
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
        bool Exists(int B_Case_link_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_link model);

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.CaseManager.B_Case_link> B_Case_links);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_link model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid B_Case_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_link GetModel(int B_Case_link_id);
        /// <summary>
        /// 根据外键code和类型得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_link GetModelByFkCodeAndType(Guid? fk_code, int? type);
        /// <summary>
        /// 获取案件关联集合
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="type">关联类型</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_link> GetCaseLinksByCaseAndType(Guid caseCode, int type);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_Case_link model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_link> GetListByPage(CommonService.Model.CaseManager.B_Case_link model, string orderby, int startIndex, int endIndex);
    }
}
