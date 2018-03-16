using ICommonService.MonitorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.MonitorManager
{
    /// <summary>
    /// 条目统计服务
    /// </summary>
    public class M_Entry_Statistics : IM_Entry_Statistics
    {
        CommonService.BLL.MonitorManager.M_Entry_Statistics bll = new CommonService.BLL.MonitorManager.M_Entry_Statistics();
        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="M_Entry_Statistics_id"></param>
        /// <returns></returns>
        public bool Exists(int M_Entry_Statistics_id)
        {
            return bll.Exists(M_Entry_Statistics_id);
        }

        /// <summary>
        /// 根据案件Guid，检查是否有延期条目统计信息
        /// </summary>
        /// <param name="pkCode">案件guid</param>
        /// <returns></returns>
        public bool ExistsDelayByPkCode(Guid pkCode)
        {
            return bll.ExistsDelayByPkCode(pkCode);
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.MonitorManager.M_Entry_Statistics model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.MonitorManager.M_Entry_Statistics model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 修改办案状态(手工结束)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHandlingState(Guid M_Entry_Statistics_code)
        {
            return bll.UpdateHandlingState(M_Entry_Statistics_code);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="M_Entry_id"></param>
        /// <returns></returns>
        public bool Delete(int M_Entry_Statistics_id)
        {
            return bll.Delete(M_Entry_Statistics_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="M_Entry_Statistics_id"></param>
        /// <returns></returns>
        public Model.MonitorManager.M_Entry_Statistics GetModel(Guid M_Entry_Statistics_code)
        {
            return bll.GetModel(M_Entry_Statistics_code);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.MonitorManager.M_Entry_Statistics model, Model.CaseManager.B_Case casemodel, string orderby, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            return bll.GetRecordCount(model, casemodel, orderby, IsPreSetManager, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.MonitorManager.M_Entry_Statistics> GetListByPage(Model.MonitorManager.M_Entry_Statistics model, Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            return bll.GetListByPage(model, casemodel, orderby, startIndex, endIndex, IsPreSetManager, userCode, postCode, deptCode,tj);
        }
    }
}
