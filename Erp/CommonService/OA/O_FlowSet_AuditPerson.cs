using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// 流程预设审批人服务
    /// </summary>
    public class O_FlowSet_AuditPerson : IO_FlowSet_AuditPerson
    {
        CommonService.BLL.OA.O_FlowSet_AuditPerson oBLL = new CommonService.BLL.OA.O_FlowSet_AuditPerson();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_FlowSet_auditPerson_code)
        {
            return oBLL.Delete(O_FlowSet_auditPerson_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_FlowSet_auditPerson_code"></param>
        /// <returns></returns>
        public CommonService.Model.OA.O_FlowSet_AuditPerson Get(Guid O_FlowSet_auditPerson_code)
        {
            return oBLL.GetModel(O_FlowSet_auditPerson_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            return oBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 根据预设流程GUID获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByflowSetCode(Guid flowsetCode)
        {
            return oBLL.GetListByflowSetCode(flowsetCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByPage(CommonService.Model.OA.O_FlowSet_AuditPerson model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 根据所属流程GUID获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByflowCode(Guid flowCode)
        {
            return oBLL.GetListByflowCode(flowCode);
        }
    }
}
