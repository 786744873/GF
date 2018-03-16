using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Userinfo_case_type”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Userinfo_case_type.svc 或 C_Userinfo_case_type.svc.cs，然后开始调试。
    public class C_Userinfo_case_type : IC_Userinfo_case_type
    {
        CommonService.BLL.SysManager.C_Userinfo_case_type ctBLL = new CommonService.BLL.SysManager.C_Userinfo_case_type();
        /// <summary>
        /// 查找是否存在实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exits(CommonService.Model.SysManager.C_Userinfo_case_type model)
        {
            return ctBLL.Exits(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Userinfo_case_type model)
        {
            return ctBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Userinfo_case_type model)
        {
            return ctBLL.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="parametersId">案件类型ID</param>
        /// <returns></returns>
        public bool Delete(Guid userCode, int parametersId)
        {
            return ctBLL.Delete(userCode, parametersId);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Userinfo_case_type model)
        {
            return ctBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo_case_type> GetListByPage(CommonService.Model.SysManager.C_Userinfo_case_type model, string orderby, int startIndex, int endIndex)
        {
            return ctBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据用户编码删除用户和案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        public bool DeleteUserinfoCaseTypeByUserCode(Guid userCode)
        {
            return ctBLL.DeleteUserinfoCaseTypeByUserCode(userCode);
        }

        /// <summary>
        /// 批量添加同一用户与多个案件类型之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="caseTypeIDs">案件类型ID集合</param>
        //public void AddUserinfoCaseTypes(Guid userCode, List<int> caseTypeIDs)
        //{
        //    ctBLL.AddUserinfoCaseTypes(userCode, caseTypeIDs);
        //}
    }
}
