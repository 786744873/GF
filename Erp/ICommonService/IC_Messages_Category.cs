using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 消息分类关系契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Messages_Category
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Messages_Category model);

        /// <summary>
        /// 根据消息大类型，消息级别，获取消息头集合
        /// </summary>
        /// <param name="messageCategoryBigClass">消息大类型</param>
        /// <param name="messageCategoryLevel">消息级别</param>
        /// <param name="isPreSetManager">是否内置系统管理员</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Messages_Category> GetMessageHeads(int messageCategoryBigClass, int messageCategoryLevel, bool isPreSetManager,Guid? loginChildrenUser);

    }
}
