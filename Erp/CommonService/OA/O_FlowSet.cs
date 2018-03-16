using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// 流程预设服务
    /// </summary>
    public class O_FlowSet : IO_FlowSet
    {
        CommonService.BLL.OA.O_FlowSet oBLL = new CommonService.BLL.OA.O_FlowSet();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_FlowSet model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_FlowSet model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_FlowSet_code)
        {
            return oBLL.Delete(O_FlowSet_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_FlowSet_code"></param>
        /// <returns></returns>
        public CommonService.Model.OA.O_FlowSet Get(Guid O_FlowSet_code)
        {
            return oBLL.GetModel(O_FlowSet_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_FlowSet model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet> GetListByPage(CommonService.Model.OA.O_FlowSet model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 修改或者添加流程预设和预审审批人信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateFlowSetAndAuditPerson(CommonService.Model.OA.O_FlowSet model, string userlists, int type)
        {
            return oBLL.UpdateFlowSetAndAuditPerson(model, userlists, type);
        }
    }
}
