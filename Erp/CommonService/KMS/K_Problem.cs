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
    public class K_Problem : IK_Problem
    {
        CommonService.BLL.KMS.K_Problem bll = new CommonService.BLL.KMS.K_Problem();
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
        /// <param name="K_Problem_id"></param>
        /// <returns></returns>
        public bool Exists(int K_Problem_id)
        {
            return bll.Exists(K_Problem_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_Problem model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_Problem_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Problem GetModel(Guid K_Problem_code)
        {
            return bll.GetModel(K_Problem_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_Problem model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_Problem_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_Problem_code)
        {
            return bll.Delete(K_Problem_code);
        }
        /// <summary>
        /// 根据code集合获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Problem> GetListByCodeList(string codeList)
        {
            return bll.GetListByCodeList(codeList);
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="K_Problem_idlist"></param>
        /// <returns></returns>
        public bool DeleteList(string K_Problem_idlist)
        {
            return bll.DeleteList(K_Problem_idlist);
        }
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_Problem model)
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
        public List<CommonService.Model.KMS.K_Problem> GetListByPage(CommonService.Model.KMS.K_Problem model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        public int GetRecordCountByMonth(CommonService.Model.KMS.K_Problem model)
        {
            return bll.GetRecordCountByMonth(model);
        }

        /// <summary>
        /// 问题审核
        /// </summary>
        /// <param name="problemCode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ProblemAudit(Guid problemCode, int state)
        {
            return bll.ProblemAudit(problemCode, state);
        }

        /// <summary>
        /// 获取热门问题
        /// </summary>
        /// <returns></returns>
        public List<Model.KMS.K_Problem> GetListByBrowseCount()
        {
            return bll.GetListByBrowseCount();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Problem> SearchResources(string path, string keyWord, int Top, string strWhere, string filedOrder)
        {
            return bll.SearchResources(path, keyWord, Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得要查询的数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Problem> GetSearchList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetSearchList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 查询数据返回对应的问题code集合
        /// </summary>
        /// <param name="path">索引路径</param>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public string GetProblemCodeItems(string path, string keyWord)
        {
            return bll.GetProblemCodeItems(path, keyWord);
        }
    }
}
