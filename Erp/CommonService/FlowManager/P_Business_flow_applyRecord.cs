using ICommonService.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FlowManager
{
    /// <summary>
    /// 业务流程申请记录服务
    /// </summary>
    public class P_Business_flow_applyRecord : IP_Business_flow_applyRecord
    {
        CommonService.BLL.FlowManager.P_Business_flow_applyRecord bll = new CommonService.BLL.FlowManager.P_Business_flow_applyRecord();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_applyRecord model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_applyRecord model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="businessFlowApplyRecordCode"></param>
        /// <returns></returns>
        public bool Delete(Guid businessFlowApplyRecordCode)
        {
            return bll.Delete(businessFlowApplyRecordCode);
        }

        public CommonService.Model.FlowManager.P_Business_flow_applyRecord Get(Guid businessFlowApplyRecordCode)
        {
            return bll.GetModel(businessFlowApplyRecordCode);
        }

        /// <summary>
        /// 根据业务Guid(商机Guid)，获取业务流程申请记录集合
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> GetListByKpCode(Guid pkCode)
        {
            return bll.GetListByKpCode(pkCode);
        }

    }
}
