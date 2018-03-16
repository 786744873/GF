using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    /// <summary>
    /// 组织机构-人员-岗位服务
    /// </summary>
    public class C_Organization_post_user : IC_Organization_post_user
    {

        CommonService.BLL.SysManager.C_Organization_post_user thisBLL = new CommonService.BLL.SysManager.C_Organization_post_user();
        
        /// <summary>
        /// 根据部门Guid，人员Guid，获取所分配岗位
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">人员Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post_user> GetHasDisbutedPosts(Guid? orgCode, Guid? userCode)
        {
            return thisBLL.GetHasDisbutedPosts(orgCode, userCode);
        }

        /// <summary>
        /// 根据人员Guid，获取人员所属岗位集合
        /// </summary>
        /// <param name="userCode">人员Guid</param>
        /// <returns></returns>      
        public List<CommonService.Model.SysManager.C_Organization_post_user> GetHasDisbutedPostsByUser(Guid? userCode)
        {
            return thisBLL.GetHasDisbutedPostsByUser(userCode);
        }

    }
}
