using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Post”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Post.svc 或 C_Post.svc.cs，然后开始调试。
    public class C_Post : IC_Post
    {
        CommonService.BLL.SysManager.C_Post bll = new CommonService.BLL.SysManager.C_Post();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Post_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Post_id)
        {
            return bll.Exists(C_Post_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SysManager.C_Post model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.SysManager.C_Post model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Post_id"></param>
        /// <returns></returns>
        public bool Delete(int C_Post_id)
        {
            return bll.Delete(C_Post_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="C_Post_id"></param>
        /// <returns></returns>
        public Model.SysManager.C_Post GetModel(int C_Post_id)
        {
            return bll.GetModel(C_Post_id);
        }

        /// <summary>
        /// 通过岗位Guid，得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Post GetModelByPostCode(Guid postCode)
        {
            return bll.GetModelByPostCode(postCode);
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="C_Post_id"></param>
        /// <returns></returns>
        public Model.SysManager.C_Post GetLinkRolesModel(Guid C_Post_code)
        {
            return bll.GetLinkRolesModel(C_Post_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.SysManager.C_Post> GetList()
        {
            return bll.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.SysManager.C_Post> GetListWhere(string strWhere)
        {
            return bll.GetList(strWhere);
        }

        /// <summary>
        /// 得到所有岗位集合
        /// </summary>
        /// <returns></returns>        
        public List<CommonService.Model.SysManager.C_Post> GetAllPosts()
        {
            return bll.GetAllPosts();
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.SysManager.C_Post model)
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
        public List<Model.SysManager.C_Post> GetListByPage(Model.SysManager.C_Post model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        #region App专用
        /// <summary>
        /// 获取所有岗位
        /// </summary>
        /// <returns>岗位列表</returns>
        public List<Model.SysManager.C_Post> AppGetPosition()
        {
            return bll.GetAllPosts();
        }
        #endregion
    }
}
