using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Region”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Region.svc 或 C_Region.svc.cs，然后开始调试。
    public class C_Rival_Region : IC_Rival_Region
    {
        CommonService.BLL.C_Rival_Region bll = new CommonService.BLL.C_Rival_Region();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(CommonService.Model.C_Rival_Region model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Customer_Regions"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.C_Rival_Region> B_Rival_Regions)
        {
            return bll.OperateList(B_Rival_Regions);
        }
    }
}
