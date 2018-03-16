using ICommonService.KMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Business_flow”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Business_flow.svc 或 P_Business_flow.svc.cs，然后开始调试。
    public class K_Keyword_Resources : IK_Keyword_Resources
    {
        CommonService.BLL.KMS.K_Keyword_Resources bll = new CommonService.BLL.KMS.K_Keyword_Resources();
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(CommonService.Model.KMS.K_Keyword_Resources model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.KMS.K_Keyword_Resources> modelList)
        {
            return bll.OperateList(modelList);
        }

        /// <summary>
        /// 根据资源Guid删除资源关连关系
        /// </summary>
        /// <param name="resourcesCode"></param>
        /// <returns></returns>
        public bool DeleteByResourcesCode(Guid resourcesCode)
        {
            return bll.DeleteByResourcesCode(resourcesCode);
        }
    }
}
