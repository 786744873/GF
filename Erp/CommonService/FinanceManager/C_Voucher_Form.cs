using ICommonService.FinanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FinanceManager
{
    /// <summary>
    /// 凭证信息-子表单中间表服务
    /// </summary>
    public class C_Voucher_Form : IC_Voucher_Form
    {
        CommonService.BLL.FinanceManager.C_Voucher_Form bll = new CommonService.BLL.FinanceManager.C_Voucher_Form();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.FinanceManager.C_Voucher_Form model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="F_Form_code"></param>
        /// <param name="C_Voucher_code"></param>
        /// <returns></returns>
        public bool Delete(Guid F_Form_code, Guid C_Voucher_code)
        {
            return bll.Delete(F_Form_code,C_Voucher_code);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="C_Vouchers"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.FinanceManager.C_Voucher_Form> C_Voucher_Forms)
        {
            return bll.OperateList(C_Voucher_Forms);
        }
          /// <summary>
        /// 根据凭证信息Code获得数据列表
        /// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher_Form> GetListByVoucherCode(Guid C_Voucher_code)
        {
            return bll.GetListByVoucherCode(C_Voucher_code);
        }
    }
}
