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
    public class K_Knowledge : IK_Knowledge
    {
        CommonService.BLL.KMS.K_Knowledge bll = new CommonService.BLL.KMS.K_Knowledge();
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
        /// <param name="K_Knowledge_id"></param>
        /// <returns></returns>
        public bool Exists(int K_Knowledge_id)
        {
            return bll.Exists(K_Knowledge_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_Knowledge model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_Knowledge_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Knowledge GetModel(Guid K_Knowledge_code)
        {
            return bll.GetModel(K_Knowledge_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_Knowledge model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_Knowledge_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_Knowledge_code)
        {
            return bll.Delete(K_Knowledge_code);
        }
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_Knowledge model)
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
        public List<CommonService.Model.KMS.K_Knowledge> GetListByPage(CommonService.Model.KMS.K_Knowledge model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<Model.KMS.K_Knowledge> GetAllList()
        {
            return bll.GetAllList();
        }

        /// <summary>
        /// 根据负责人获取全部数据
        /// </summary>
        /// <param name="K_Knowledge_Person">负责人Guid</param>
        /// <returns></returns>
        public List<Model.KMS.K_Knowledge> GetAllListByPerson(Guid K_Knowledge_Person)
        {
            return bll.GetAllListByPerson(K_Knowledge_Person);
        }

        /// <summary>
        /// 移动资源
        /// </summary>
        /// <param name="knowledgeCode">知识分类Guid</param>
        /// <param name="resourcesCode">资源Guid</param>
        /// <returns></returns>
        public bool MobileResource(Guid knowledgeCode, Guid resourcesCode)
        {
            return bll.MobileResource(knowledgeCode, resourcesCode);
        }
    }
}
