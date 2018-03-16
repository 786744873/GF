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
    public class C_SearchConditionRecord : IC_SearchConditionRecord
    {
        CommonService.BLL.C_SearchConditionRecord bll = new CommonService.BLL.C_SearchConditionRecord();
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="C_SearchConditionRecord"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.C_SearchConditionRecord> C_SearchConditionRecord)
        {
            return bll.OperateList(C_SearchConditionRecord);
        }
        /// <summary>
        /// 根据所属分组获得数据列表
        /// </summary>
        /// <param name="C_SearchConditionRecord_group">所属分组Guid</param>
        /// <returns></returns>
        public List<Model.C_SearchConditionRecord> GetListByGroup(Guid C_SearchConditionRecord_group)
        {
            return bll.GetListByGroup(C_SearchConditionRecord_group);
        }
    }
}
