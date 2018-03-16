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
    public class K_Keyword : IK_Keyword
    {
        CommonService.BLL.KMS.K_Keyword bll = new CommonService.BLL.KMS.K_Keyword();
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
        /// <param name="K_Keyword_id"></param>
        /// <returns></returns>
        public bool Exists(int K_Keyword_id)
        {
            return bll.Exists(K_Keyword_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_Keyword model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_Keyword_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Keyword GetModel(Guid K_Keyword_code)
        {
            return bll.GetModel(K_Keyword_code);
        }
        /// <summary>
        /// 根据关键字得到一个对象Guid
        /// </summary>
        public string GetModelByKey(string K_Keyword_name)
        {
            return bll.GetModelByKey(K_Keyword_name);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_Keyword model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_Keyword_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_Keyword_code)
        {
            return bll.Delete(K_Keyword_code);
        }
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_Keyword model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获得数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Keyword> GetListByPage(CommonService.Model.KMS.K_Keyword model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.KMS.K_Keyword> modelList)
        {
            return bll.OperateList(modelList);
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<Model.KMS.K_Keyword> GetAllList()
        {
            return bll.GetAllList();
        }
        /// <summary>
        /// 根据资源guid获得资源的关键字列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Keyword> GetKeywordList(Guid K_Resources_code)
        {
            return bll.GetKeywordList(K_Resources_code);
        }
        /// <summary>
        /// 获得热门标签前10条数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Keyword> GetTagList()
        {
            return bll.GetTagList();
        }
    }
}
