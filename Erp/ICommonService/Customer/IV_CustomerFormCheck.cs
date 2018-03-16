using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Customer
{
    /// <summary>
    /// 虚拟客户表单审核契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IV_CustomerFormCheck
    {
        /// <summary>
        /// 提交表单审核
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>     
        /// <returns></returns>
        [OperationContract]
        int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks);

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        [OperationContract]
        int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks);
    }
}
