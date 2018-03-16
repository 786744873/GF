using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 消息分类关系服务
    /// </summary>
    public class C_Messages_Category : IC_Messages_Category
    {
        CommonService.BLL.C_Messages_Category oBLL = new CommonService.BLL.C_Messages_Category();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.C_Messages_Category model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 根据消息大类型，消息级别，获取消息头集合
        /// </summary>
        /// <param name="messageCategoryBigClass">消息大类型</param>
        /// <param name="messageCategoryLevel">消息级别</param>
        /// <param name="isPreSetManager">是否内置系统管理员</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Messages_Category> GetMessageHeads(int messageCategoryBigClass, int messageCategoryLevel, bool isPreSetManager, Guid? loginChildrenUser)
        {
            return oBLL.GetMessageHeads(messageCategoryBigClass, messageCategoryLevel, isPreSetManager, loginChildrenUser);
        }

    }
}
