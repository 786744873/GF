using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Organization_post”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Organization_post.svc 或 C_Organization_post.svc.cs，然后开始调试。
    public class C_Organization_post : IC_Organization_post
    {
        CommonService.BLL.SysManager.C_Organization_post bll = new CommonService.BLL.SysManager.C_Organization_post();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        ///是否存在该记录
        /// </summary>
        /// <param name="C_Organization_post_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Organization_post_id)
        {
            return bll.Exists(C_Organization_post_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SysManager.C_Organization_post model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.SysManager.C_Organization_post model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Organization_post_id"></param>
        /// <returns></returns>
        public bool Delete(int C_Organization_post_id)
        {
            return bll.Delete(C_Organization_post_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_Organization_post_id"></param>
        /// <returns></returns>
        public Model.SysManager.C_Organization_post GetModel(int C_Organization_post_id)
        {
            return bll.GetModel(C_Organization_post_id);
        }

        /// <summary>
        /// 通过组织机构Guid，获取关联岗位集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByOrg(Guid orgCode)
        {
            return bll.GetRelationPostsByOrg(orgCode);
        }
        ///根据组织结构和子级组织架构获取关联岗位集合
        public List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByOrgList(List<Guid> orgCode)
        {
            return bll.GetRelationPostsByOrgList(orgCode);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.SysManager.C_Organization_post model)
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
        public List<Model.SysManager.C_Organization_post> GetListByPage(Model.SysManager.C_Organization_post model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
        ///// <summary>
        ///// 通过权限id，获取关联岗位集合
        ///// </summary>
        ///// <param name="orgCode">权限</param>
        ///// <returns></returns>
        //public List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByPowerid(int powerId)
        //{
        //    return bll.GetRelationPostsByPowerid(powerId);
        //}
    }
}
