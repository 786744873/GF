using CommonService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CustomerForm
{
    /// <summary>
    /// 表单重做业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/10/09
    /// </summary>
    public partial class F_FormReDone
    {

        private readonly CommonService.DAL.CustomerForm.F_FormReDone dal = new CommonService.DAL.CustomerForm.F_FormReDone();

        /// <summary>
        /// 确认重做表单
        /// </summary>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="newBusinessFlowFormCode">新生成的业务流程表单关联Guid</param>
        /// <param name="operateUserCode">操作人Guid</param>
        /// <returns></returns>
        public int ReDoneForm(int fkType, Guid formCode, Guid businessFlowCode, Guid businessFlowFormCode, Guid newBusinessFlowFormCode, Guid operateUserCode)
        {
            int status = 1;//代表重做成功

            dal.ReDoneForm(fkType, formCode, businessFlowCode, businessFlowFormCode, newBusinessFlowFormCode, operateUserCode);

            MSMQ.SendMessage();

            return status;
        }
    }
}
