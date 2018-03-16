using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Organization”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Organization.svc 或 C_Organization.svc.cs，然后开始调试。
    public class C_Organization : IC_Organization
    {
        CommonService.BLL.SysManager.C_Organization oBLL = new CommonService.BLL.SysManager.C_Organization();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return oBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Organization_id)
        {
            return oBLL.Exists(C_Organization_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization model, Guid oldguid)
        {
            return oBLL.Update(model, oldguid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Organization_code)
        {
            return oBLL.Delete(C_Organization_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Organization_code"></param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Organization Get(Guid C_Organization_code)
        {
            return oBLL.GetModel(C_Organization_code);
        }

        public List<CommonService.Model.SysManager.C_Organization> GetAllList()
        {
            return oBLL.GetAllList();
        }

        /// <summary>
        /// 根据用户Guid获得关联部门
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetListByUserCode(Guid userCode)
        {
            return oBLL.GetListByUserCode(userCode);
        }
        /// <summary>
        /// 根据组织架构code获得列表
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetChirldAllList(Guid? orgCode)
        {
            return oBLL.GetChirldAllList(orgCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Organization model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization> GetListByPage(CommonService.Model.SysManager.C_Organization model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 通过父级GUID获取子集
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetModelByParent(Guid parentCode)
        {
            return oBLL.GetModelByParent(parentCode);
        }
        /// <summary>
        /// 根据用户获得用户关联区域下包含（type=1、律师 2、专业顾问）的组织架构
        /// </summary>
        /// <param name="userinfoCode">用户Guid</param>
        /// <param name="type">type=1、包含律师的组织架构 2、包含专业顾问的组织架构</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Organization> GetContainLawyerOrAdvisorList(Guid userinfoCode, int? type)
        {
            return oBLL.GetContainLawyerOrAdvisorList(userinfoCode, type);
        }
        /// <summary>
        /// orgParentCode所有子集是否包含orgCode
        /// </summary>
        /// <param name="orgParentCode"></param>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public bool isHeadOrganizationCode(Guid orgParentCode, Guid orgCode)
        {
            return oBLL.isHeadOrganizationCode(orgParentCode, orgCode);
        }

        #region App专用
        /// <summary>
        /// App端根据权限获取组织架构列表（紧获取二级）
        /// </summary>
        /// <returns>组织架构列表</returns>
        public List<Model.SysManager.C_Organization> AppGetDepartments()
        {
            return oBLL.AppGetDepartments();
        }
        #endregion
    }
}
