using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件级别变更服务
    /// </summary>
    public class B_CaseLevelchange : IB_CaseLevelchange
    {
        private readonly CommonService.BLL.CaseManager.B_CaseLevelchange bll = new CommonService.BLL.CaseManager.B_CaseLevelchange();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_CaseLevelchange model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="CaseLevelchangeList"></param>
        /// <returns></returns>
        public int OpreateList(List<Model.CaseManager.B_CaseLevelchange> CaseLevelchangeList)
        {
            return bll.OpreateList(CaseLevelchangeList);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_CaseLevelchange model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_CaseLevelchange_code"></param>
        /// <returns></returns>
        public bool Delete(Guid B_CaseLevelchange_code)
        {
            return bll.Delete(B_CaseLevelchange_code);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="B_CaseLevelchange_code"></param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseLevelchange GetModel(Guid B_CaseLevelchange_code)
        {
            return bll.GetModel(B_CaseLevelchange_code);
        }
        /// <summary>
        /// 根据变更记录Guid获得数据
        /// </summary>
        /// <param name="B_CaseLevelchange_changeRecord"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_CaseLevelchange> GetListByChangeRecord(Guid B_CaseLevelchange_changeRecord)
        {
            return bll.GetListByChangeRecord(B_CaseLevelchange_changeRecord);
        }
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_CaseLevelchange model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_CaseLevelchange> GetListByPage(Model.CaseManager.B_CaseLevelchange model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 根据案件Guid查询是否有未审核的变更数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public bool IsNotAudited(Guid caseCode)
        {
            return bll.IsNotAudited(caseCode);
        }

        /// <summary>
        /// 根据案件Guid获得数据列表
        /// </summary>
        public List<Model.CaseManager.B_CaseLevelchange> GetListByCaseCode(Guid B_Case_code,int type)
        {
            return bll.GetListByCaseCode(B_Case_code,type);
        }

        /// <summary>
        /// 根据案件Guid查询是否有变更记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public bool IsChange(Guid caseCode)
        {
            return bll.IsChange(caseCode);
        }

         /// <summary>
        /// 根据案件Guid查询是否有调整记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="B_CaseLevelchange_type">案件级别变更类型</param>
        /// <returns></returns>
        public bool IsHardToAdjust(Guid caseCode, int B_CaseLevelchange_type)
        {
            return bll.IsHardToAdjust(caseCode, B_CaseLevelchange_type);
        }
    }
}
