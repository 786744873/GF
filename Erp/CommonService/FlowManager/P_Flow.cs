using ICommonService.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Flow”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Flow.svc 或 P_Flow.svc.cs，然后开始调试。
    public class P_Flow : IP_Flow
    {
        CommonService.BLL.FlowManager.P_Flow bll = new CommonService.BLL.FlowManager.P_Flow();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Flow_id)
        {
            return bll.Exists(P_Flow_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Flow model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid P_Flow_code)
        {
            return bll.Delete(P_Flow_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.FlowManager.P_Flow GetModel(Guid P_Flow_code)
        {
            return bll.GetModel(P_Flow_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.FlowManager.P_Flow model)
        {
            return bll.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Flow> GetListByPage(CommonService.Model.FlowManager.P_Flow model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.FlowManager.P_Flow> GetAllList()
        {
            return bll.GetAllList();
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="type">流程类型</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow> GetListByFlowType(int type)
        {
            return bll.GetListByFlowType(type);
        }
    }
}
