using ICommonService.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Flow_post”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Flow_post.svc 或 P_Flow_post.svc.cs，然后开始调试。
    public class P_Flow_post : IP_Flow_post
    {
        CommonService.BLL.FlowManager.P_Flow_post bll = new CommonService.BLL.FlowManager.P_Flow_post();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="P_Business_flow_form_id"></param>
        /// <returns></returns>
        public bool Exists(int P_Flow_post_id)
        {
            return bll.Exists(P_Flow_post_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.FlowManager.P_Flow_post model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.FlowManager.P_Flow_post model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="P_Business_flow_form_id"></param>
        /// <returns></returns>
        public bool Delete(int P_Flow_post_id)
        {
            return bll.Delete(P_Flow_post_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="P_Business_flow_form_id"></param>
        /// <returns></returns>
        public Model.FlowManager.P_Flow_post GetModel(int P_Flow_post_id)
        {
            return bll.GetModel(P_Flow_post_id);
        }
        /// <summary>
        /// 根据流程Code获得数据列表
        /// </summary>
        /// <param name="P_Flow_code"></param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow_post> GetListByFlowcode(Guid P_Flow_code)
        {
            return bll.GetListByFlowcode(P_Flow_code);
        }
        /// <summary>
        /// 获取记录总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.FlowManager.P_Flow_post model)
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
        public List<Model.FlowManager.P_Flow_post> GetListByPage(Model.FlowManager.P_Flow_post model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
