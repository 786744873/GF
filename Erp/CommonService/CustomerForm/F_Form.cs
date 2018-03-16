using ICommonService.CustomerForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CustomerForm
{
    /// <summary>
    /// 自定义表单服务
    /// </summary>
    public class F_Form : IF_Form
    {
        CommonService.BLL.CustomerForm.F_Form oBLL = new CommonService.BLL.CustomerForm.F_Form();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return oBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_Form_id)
        {
            return oBLL.Exists(F_Form_id);
        }

        /// <summary>
        /// 是否存在表单标识
        /// </summary>
        /// <param name="formIdentification">表单标识</param>
        /// <returns>存在返回true;不存在返回false</returns>
        public bool ExistsFormIdentification(string formIdentification)
        {
            return oBLL.ExistsFormIdentification(formIdentification);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_Form model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_Form model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_Form_code)
        {
            return oBLL.Delete(F_Form_code);           
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_Form_code"></param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_Form Get(Guid F_Form_code)
        {
            return oBLL.GetModel(F_Form_code);             
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_Form> GetAllListByFlowType(int FlowType)
        {
            return oBLL.GetAllListByFlowType(FlowType);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_Form model)
        {
            return oBLL.GetRecordCount(model);            
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_Form> GetListByPage(CommonService.Model.CustomerForm.F_Form model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);           
        }
    }
}
