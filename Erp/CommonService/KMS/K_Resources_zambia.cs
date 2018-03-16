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
    public class K_Resources_zambia : IK_Resources_zambia
    {
        CommonService.BLL.KMS.K_Resources_zambia bll = new CommonService.BLL.KMS.K_Resources_zambia();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.KMS.K_Resources_zambia model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="K_Resources_code"></param>
        /// <param name="C_Userinfo_code"></param>
        /// <returns></returns>
        public bool Exists(Guid K_Resources_code, Guid C_Userinfo_code)
        {
            return bll.Exists(K_Resources_code, C_Userinfo_code);
        }
        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources_zambia GetModelByModel(CommonService.Model.KMS.K_Resources_zambia model)
        {
            return bll.GetModelByModel(model);
        }
    }
}
