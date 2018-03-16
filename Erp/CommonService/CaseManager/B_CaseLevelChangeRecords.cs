using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件级别变更记录服务
    /// </summary>
    public class B_CaseLevelChangeRecords : IB_CaseLevelChangeRecords
    {
        private readonly CommonService.BLL.CaseManager.B_CaseLevelChangeRecords bll = new CommonService.BLL.CaseManager.B_CaseLevelChangeRecords();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_CaseLevelChangeRecords model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_CaseLevelChangeRecords model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_CaseLevelChangeRecords_code"></param>
        /// <returns></returns>
        public bool Delete(Guid B_CaseLevelChangeRecords_code)
        {
            return bll.Delete(B_CaseLevelChangeRecords_code);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="B_CaseLevelChangeRecords_code"></param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModel(Guid B_CaseLevelChangeRecords_code)
        {
            return bll.GetModel(B_CaseLevelChangeRecords_code);
        }
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_CaseLevelChangeRecords model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获得数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_CaseLevelChangeRecords> GetListByPage(Model.CaseManager.B_CaseLevelChangeRecords model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 根据案件Guid获得未审核的记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCodeIsNotAudit(Guid caseCode)
        {
            return bll.GetModelByCaseCodeIsNotAudit(caseCode);
        }

        /// <summary>
        /// 根据案件Guid获得记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCode(Guid caseCode)
        {
            return bll.GetModelByCaseCode(caseCode);
        }

        /// <summary>
        /// 根据案件Guid获得数据
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_CaseLevelChangeRecords> GetListByCaseCode(Guid CaseCode)
        {
            return bll.GetListByCaseCode(CaseCode);
        }
    }
}
