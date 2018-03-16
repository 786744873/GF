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
    public class K_Resources : IK_Resources
    {
        CommonService.BLL.KMS.K_Resources bll = new CommonService.BLL.KMS.K_Resources();
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
        /// <param name="K_Resources_id"></param>
        /// <returns></returns>
        public bool Exists(int K_Resources_id)
        {
            return bll.Exists(K_Resources_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_Resources model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_Resources_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Resources GetModel(Guid K_Resources_code)
        {
            return bll.GetModel(K_Resources_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_Resources model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_Resources_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_Resources_code)
        {
            return bll.Delete(K_Resources_code);
        }
        /// <summary>
        /// 删除数据列表
        /// </summary>
        /// <param name="K_Resources_idlist">code列表</param>
        /// <returns></returns>
        public bool DeleteList(string K_Resources_idlist)
        {
            return bll.DeleteList(K_Resources_idlist);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code">K_Resources_code数据集</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByCode(string code)
        {
            return bll.GetListByCode(code);
        }
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_Resources model)
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
        public List<CommonService.Model.KMS.K_Resources> GetListByPage(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 根据资源code集合获得资源集合
        /// </summary>
        /// <param name="codeList"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByCodeList(string codeList, string type)
        {
            return bll.GetListByCodeList(codeList,type);
        }
        /// <summary>
        /// 根据资源类型获取前几条最热的数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByzambiaCount(int count, string K_Knowledge_name, int? K_Knowledge_Resources_type)
        {
            return bll.GetListByzambiaCount(count, K_Knowledge_name, K_Knowledge_Resources_type);
        }
        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        public int GetRecordCountByMonth(CommonService.Model.KMS.K_Resources model)
        {
            return bll.GetRecordCountByMonth(model);
        }
        /// <summary>
        /// 根据浏览量和资源类型获取前几天数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByBrowseCount(int count, Guid? K_Knowledge_code, int? K_Resources_type)
        {
            return bll.GetListByBrowseCount(count, K_Knowledge_code, K_Resources_type);
        }

        /// <summary>
        /// 资源审核
        /// </summary>
        /// <param name="resourcesCode">资源Guid</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool ResourcesAudit(string resourcesCode, int state)
        {
            return bll.ResourcesAudit(resourcesCode, state);
        }
        /// <summary>
        /// 资源下载权限
        /// </summary>
        /// <param name="resourcesCode">资源Guid(以逗号隔开，多个处理)</param>
        /// <returns></returns>
        public bool ResourcesPermissions(string resourcesCode, int permissions)
        {
            return bll.ResourcesPermissions(resourcesCode, permissions);
        }
        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources> GetSearchList()
        {
            return bll.GetSearchList();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> SearchResources(string path, string keyWord)
        {
            return bll.SearchResources(path, keyWord);
        }

        /// <summary>
        /// 我的文档/视频
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Model.KMS.K_Resources> MyDocumentAndVideoList(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex, int type)
        {
            return bll.MyDocumentAndVideoList(model, orderby, startIndex, endIndex, type);
        }

        /// <summary>
        /// 我的文档/视频数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int MyDocumentAndVideoListCount(Model.KMS.K_Resources model, int type)
        {
            return bll.MyDocumentAndVideoListCount(model, type);
        }

        /// <summary>
        /// 获取最近上传几条数据
        /// </summary>
        /// <param name="K_Resources_creator">用户Guid</param>
        /// <param name="pageSize">展示条数</param>
        /// <returns></returns>
        public List<Model.KMS.K_Resources> GetListByRecentUpload(Guid K_Resources_creator, int pageSize)
        {
            return bll.GetListByRecentUpload(K_Resources_creator, pageSize);
        }

        /// <summary>
        /// 根据视频Id获得一条数据
        /// </summary>
        /// <param name="K_Resources_url"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Resources GetModelByUrl(string K_Resources_url)
        {
            return bll.GetModelByUrl(K_Resources_url);
        }
        /// <summary>
        /// 根据查询关键字，返回查询到的数据code
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public string GetResourcesCodelist(string path, string keyWord)
        {
            return bll.GetResourcesCodelist(path, keyWord);
        }
    }
}
