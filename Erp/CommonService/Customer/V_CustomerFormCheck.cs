using ICommonService.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Customer
{
    /// <summary>
    /// 虚拟客户表单审核服务
    /// </summary>
    public class V_CustomerFormCheck : IV_CustomerFormCheck
    {
        CommonService.BLL.Customer.V_CustomerFormCheck oBLL = new CommonService.BLL.Customer.V_CustomerFormCheck();

        /// <summary>
        /// 提交表单审核
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>      
        /// <returns></returns>
        public int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks)
        {
            return oBLL.SubmitForm(formChecks);
        }

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>      
        public int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks)
        {
            return oBLL.CheckForm(formChecks);
        }

    }
}
