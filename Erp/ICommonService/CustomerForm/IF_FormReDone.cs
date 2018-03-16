using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CustomerForm
{
    /// <summary>
    /// 重做表单契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IF_FormReDone
    {
        /// <summary>
        /// 确认重做表单
        /// </summary>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="newBusinessFlowFormCode">新生成的业务流程表单关联Guid</param>
        /// <returns></returns>
        [OperationContract]
        int ReDoneForm(int fkType, Guid formCode, Guid businessFlowCode, Guid businessFlowFormCode, Guid newBusinessFlowFormCode, Guid operateUserCode);
    }
}
