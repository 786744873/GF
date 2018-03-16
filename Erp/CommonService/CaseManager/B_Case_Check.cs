using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    ///  案件结案审核服务
    /// </summary>
    public class B_Case_Check : IB_Case_Check
    {
        CommonService.BLL.CaseManager.B_Case_Check bll = new CommonService.BLL.CaseManager.B_Case_Check();
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.CaseManager.B_Case_Check model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.CaseManager.B_Case_Check model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_Case_Check_code"></param>
        /// <returns></returns>
        public bool Delete(Guid B_Case_Check_code)
        {
            return bll.Delete(B_Case_Check_code);
        }
        /// <summary>
        /// 获得一个实体
        /// </summary>
        /// <param name="B_Case_Check_code"></param>
        /// <returns></returns>
        public Model.CaseManager.B_Case_Check GetModel(Guid B_Case_Check_code)
        {
            return bll.GetModel(B_Case_Check_code);
        }
        /// <summary>
        /// 根据案件结案确认Guid获得数据
        /// </summary>
        /// <param name="B_Case_Confirm_code">结案确认Guid</param>
        /// <returns></returns>
        public List<Model.CaseManager.B_Case_Check> GetListByConfirmCode(Guid B_Case_Confirm_code)
        {
            return bll.GetListByConfirmCode(B_Case_Confirm_code);
        }
    }
}
