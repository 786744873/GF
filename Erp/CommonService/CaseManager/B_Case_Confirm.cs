using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    ///  案件结案确认服务
    /// </summary>
    public class B_Case_Confirm : IB_Case_Confirm
    {
        CommonService.BLL.CaseManager.B_Case_Confirm bll = new CommonService.BLL.CaseManager.B_Case_Confirm();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Confirm model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_Confirm model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_Confirm_code)
        {
            return bll.Delete(B_Case_Confirm_code);
        }
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        public CommonService.Model.CaseManager.B_Case_Confirm GetModel(Guid B_Case_Confirm_code)
        {
            return bll.GetModel(B_Case_Confirm_code);
        }

        /// <summary>
        /// 根据案件Guid和业务流程Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case_Confirm> GetListByCaseAndBusinessFlow(Guid caseCode, Guid businessFlowCode)
        {
            return bll.GetListByCaseAndBusinessFlow(caseCode, businessFlowCode);
        }

        /// <summary>
        /// 当前用户是否有“确认结案”按钮权限
        /// </summary>
        /// <param name="B_Case_code">案件Guid</param>
        /// <param name="personCode">当前用户Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_Case_Confirm GetModelByCaseAndPerson(Guid B_Case_code, Guid personCode)
        {
            return bll.GetModelByCaseAndPerson(B_Case_code,personCode);
        }

        /// <summary>
        /// 根据案件Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public List<Model.CaseManager.B_Case_Confirm> GetListByCaseCode(Guid caseCode)
        {
            return bll.GetListByCaseCode(caseCode);
        }
    }
}
