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
    public class K_Knowledge_Resources : IK_Knowledge_Resources
    {
        CommonService.BLL.KMS.K_Knowledge_Resources bll = new CommonService.BLL.KMS.K_Knowledge_Resources();
        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="K_Knowledge_Resources_id"></param>
        /// <returns></returns>
        public bool Exists(int K_Knowledge_Resources_id)
        {
            return bll.Exists(K_Knowledge_Resources_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_Knowledge_Resources model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_Knowledge_Resources_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModel(Guid K_Knowledge_Resources_code)
        {
            return bll.GetModel(K_Knowledge_Resources_code);
        }
        /// <summary>
        /// 根据关联Guid获取一条数据
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Knowledge_Resources GetModelByFkCode(Guid P_FK_code)
        {
            return bll.GetModelByFkCode(P_FK_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_Knowledge_Resources model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_Knowledge_Resources_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_Knowledge_Resources_code)
        {
            return bll.Delete(K_Knowledge_Resources_code);
        }
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_Knowledge_Resources model)
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
        public List<CommonService.Model.KMS.K_Knowledge_Resources> GetListByPage(CommonService.Model.KMS.K_Knowledge_Resources model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 根据关联Guid删除一条数据
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public bool DeleteByFkCode(Guid P_FK_code)
        {
            return bll.DeleteByFkCode(P_FK_code);
        }
    }
}
