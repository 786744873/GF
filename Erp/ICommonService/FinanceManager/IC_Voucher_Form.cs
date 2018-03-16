using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.FinanceManager
{
    /// 凭证信息-子表单中间表契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Voucher_Form
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
        [OperationContract]
        bool Add(CommonService.Model.FinanceManager.C_Voucher_Form model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        [OperationContract]
        bool Delete(Guid F_Form_code, Guid C_Voucher_code);
         /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.FinanceManager.C_Voucher_Form> C_Voucher_Forms);
         /// <summary>
        /// 根据凭证信息Code获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FinanceManager.C_Voucher_Form> GetListByVoucherCode(Guid C_Voucher_code);
    }
}
