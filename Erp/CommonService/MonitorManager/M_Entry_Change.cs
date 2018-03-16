using ICommonService.MonitorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.MonitorManager
{
    /// <summary>
    /// 条目变更服务
    /// </summary>
    public class M_Entry_Change : IM_Entry_Change
    {
        CommonService.BLL.MonitorManager.M_Entry_Change bll = new CommonService.BLL.MonitorManager.M_Entry_Change();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }

        public List<CommonService.Model.MonitorManager.M_Entry_Change> GetModelList(string strWhere) {
            return bll.GetModelList(strWhere);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="M_Entry_Change_id"></param>
        /// <returns></returns>
        public bool Exists(int M_Entry_Change_id)
        {
            return bll.Exists(M_Entry_Change_id);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.MonitorManager.M_Entry_Change model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.MonitorManager.M_Entry_Change model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="M_Entry_Change_id"></param>
        /// <returns></returns>
        public bool Delete(int M_Entry_Change_id)
        {
            return bll.Delete(M_Entry_Change_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="M_Entry_Change_id"></param>
        /// <returns></returns>
        public Model.MonitorManager.M_Entry_Change GetModel(Guid M_Entry_Change_code)
        {
            return bll.GetModel(M_Entry_Change_code);
        }

        /// <summary>
        /// 根据案件Guid，获取条目变更记录
        /// </summary>
        /// <param name="pkCode">案件Guid</param>
        /// <returns></returns>        
        public List<CommonService.Model.MonitorManager.M_Entry_Change> GetEntryChangeRecordByPkCode(Guid pkCode)
        {
            return bll.GetEntryChangeRecordByPkCode(pkCode);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.MonitorManager.M_Entry_Change model, string orderby, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetRecordCount(model, orderby, IsPreSetManager, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.MonitorManager.M_Entry_Change> GetListByPage(Model.MonitorManager.M_Entry_Change model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, userCode, postCode, deptCode);
        }
       
        
    }
}
