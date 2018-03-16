using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService.SysManager;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Roles”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Roles.svc 或 C_Roles.svc.cs，然后开始调试。
    public class C_Roles : IC_Roles
    {
        private CommonService.BLL.SysManager.C_Roles crBLL = new CommonService.BLL.SysManager.C_Roles();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return crBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Roles_id)
        {
            return crBLL.Exists(C_Roles_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Roles model)
        {
            return crBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Roles model)
        {
            return crBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Roles_id)
        {
            return crBLL.Delete(C_Roles_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Roles GetModel(int C_Roles_id)
        {
            return crBLL.GetModel(C_Roles_id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SysManager.C_Roles> GetAllList()
        {
            return crBLL.GetAllList();
        }

        /// <summary>
        /// 获取所有角色，并且根据组织机构Guid，用户Guid，岗位Guid设置关联角色状态值
        /// </summary>
        /// <param name="orgCode">织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>        
        public List<CommonService.Model.SysManager.C_Roles> GetAllRoles(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            return crBLL.GetAllRoles(orgCode, userCode, postCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Roles model)
        {
            return crBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Roles> GetListByPage(CommonService.Model.SysManager.C_Roles model, string orderby, int startIndex, int endIndex)
        {
            return crBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
