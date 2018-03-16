using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// 表单审批人服务
    /// </summary>
    public class O_Form_AuditPerson : IO_Form_AuditPerson
    {
        CommonService.BLL.OA.O_Form_AuditPerson oBLL = new CommonService.BLL.OA.O_Form_AuditPerson();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Form_AuditPerson_code)
        {
            return oBLL.Delete(O_Form_AuditPerson_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Form_AuditPerson_code"></param>
        /// <returns></returns>
        public CommonService.Model.OA.O_Form_AuditPerson Get(Guid O_Form_AuditPerson_code)
        {
            return oBLL.GetModel(O_Form_AuditPerson_code);
        }
        /// <summary>
        /// 通过所属表单审批流程Guid,得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditPerson GetModelByFlowCode(Guid O_Form_AuditPerson_formAuditFlow)
        {
            return oBLL.GetModelByFlowCode(O_Form_AuditPerson_formAuditFlow);
        }

        /// <summary>
        /// 通过表单Guid，获取表单审批人集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Form_AuditPerson> GetFormAuditPersonsByFormCode(Guid formCode)
        {
            return oBLL.GetFormAuditPersonsByFormCode(formCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditPerson> GetListByPage(CommonService.Model.OA.O_Form_AuditPerson model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
