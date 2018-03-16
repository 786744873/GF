using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 表单审批人契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Form_AuditPerson
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_Form_AuditPerson model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Form_AuditPerson model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_Form_AuditPerson_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Form_AuditPerson_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_Form_AuditPerson Get(Guid O_Form_AuditPerson_code);
        /// <summary>
        /// 通过所属表单审批流程Guid,得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Form_AuditPerson GetModelByFlowCode(Guid O_Form_AuditPerson_formAuditFlow);

        /// <summary>
        /// 通过表单Guid，获取表单审批人集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditPerson> GetFormAuditPersonsByFormCode(Guid formCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.OA.O_Form_AuditPerson model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditPerson> GetListByPage(CommonService.Model.OA.O_Form_AuditPerson model, string orderby, int startIndex, int endIndex);
    }
}
