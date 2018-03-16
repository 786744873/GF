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
    public class K_study : IK_study
    {
        CommonService.BLL.KMS.K_study bll = new CommonService.BLL.KMS.K_study();
        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条数据
        /// </summary>
        /// <param name="K_study_id"></param>
        /// <returns></returns>
        public bool Exists(int K_study_id)
        {
            return bll.Exists(K_study_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_study model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_study_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_study GetModel(Guid K_study_code)
        {
            return bll.GetModel(K_study_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_study model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_study_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_study_code)
        {
            return bll.Delete(K_study_code);
        }
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_study model)
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
        public List<CommonService.Model.KMS.K_study> GetListByPage(CommonService.Model.KMS.K_study model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 最近收藏
        /// </summary>
        /// <param name="K_study_creator">用户Guid</param>
        /// <param name="pageSize">展示数量</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_study> GetListByCreatorTime(Guid K_study_creator, int pageSize)
        {
            return bll.GetListByCreatorTime(K_study_creator, pageSize);
        }

        /// <summary>
        /// 是否存在该数据
        /// </summary>
        /// <param name="K_study_creator"></param>
        /// <param name="K_Resources_code"></param>
        /// <returns></returns>
        public bool ExistsStudy(Guid K_study_creator, Guid K_Resources_code)
        {
            return bll.ExistsStudy(K_study_creator,K_Resources_code);
        }
    }
}
