using ICommonService.CustomerForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CustomerForm
{
    /// <summary>
    /// 重做表单服务
    /// </summary>
    public class F_FormReDone : IF_FormReDone
    {
        CommonService.BLL.CustomerForm.F_FormReDone oBLL = new CommonService.BLL.CustomerForm.F_FormReDone();
        
        /// <summary>
        /// 确认重做表单
        /// </summary>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="newBusinessFlowFormCode">新生成的业务流程表单关联Guid</param>
        /// <returns></returns>
        public int ReDoneForm(int fkType, Guid formCode, Guid businessFlowCode, Guid businessFlowFormCode, Guid newBusinessFlowFormCode, Guid operateUserCode)
        {
            return oBLL.ReDoneForm(fkType, formCode, businessFlowCode, businessFlowFormCode, newBusinessFlowFormCode, operateUserCode);
        }
    }
}
