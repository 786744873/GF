using ICommonService.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Flow_form”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Flow_form.svc 或 P_Flow_form.svc.cs，然后开始调试。
    public class P_Flow_form : IP_Flow_form
    {
        CommonService.BLL.FlowManager.P_Flow_form bll = new CommonService.BLL.FlowManager.P_Flow_form();
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
        /// <param name="P_Flow_form_id"></param>
        /// <returns></returns>
        public bool Exists(int P_Flow_form_id)
        {
            return bll.Exists(P_Flow_form_id);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.FlowManager.P_Flow_form model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.FlowManager.P_Flow_form model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="P_Flow_form_id"></param>
        /// <returns></returns>
        public bool Delete(string P_Flow_form_ids)
        {
            return bll.Delete(P_Flow_form_ids);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="P_Flow_form_id"></param>
        /// <returns></returns>
        public Model.FlowManager.P_Flow_form GetModel(int P_Flow_form_id)
        {
            return bll.GetModel(P_Flow_form_id);
        }

        /// <summary>
        /// 根据流程Guid，获取流程关联所有表单
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow_form> GetListByFlowCode(Guid flowCode)
        {
            return bll.GetListByFlowCode(flowCode);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.FlowManager.P_Flow_form model)
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
        public List<Model.FlowManager.P_Flow_form> GetListByPage(Model.FlowManager.P_Flow_form model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        public bool UpdateDefaultByid(string P_Flow_form_idlist,Guid P_Flow_code)
        {
            return bll.UpdateDefaultByid(P_Flow_form_idlist, P_Flow_code);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        public bool OpreateList(List<Model.FlowManager.P_Flow_form> modelList)
        {
            return bll.OpreateList(modelList);
        }
    }
}
