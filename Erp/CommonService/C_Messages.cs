using ICommonService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// C_Messages
    /// </summary>
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Messages”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Messages.svc 或 C_Messages.svc.cs，然后开始调试。
    public class C_Messages : IC_Messages
    {

        CommonService.BLL.C_Messages messageBLL = new CommonService.BLL.C_Messages();
        public C_Messages()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Messages_id)
        {
            return messageBLL.Exists(C_Messages_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Messages model)
        {
            return messageBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Messages model)
        {
            return messageBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Messages_id)
        {

            return messageBLL.Delete(C_Messages_id);
        }

        /// <summary>
        /// 读消息
        /// </summary>
        /// <param name="messageId">消息Id</param>
        /// <returns></returns>
        public bool ReadMessage(int messageId)
        {
            return messageBLL.ReadMessage(messageId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Messages_idlist)
        {
            return messageBLL.DeleteList(C_Messages_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModel(int C_Messages_id)
        {

            return messageBLL.GetModel(C_Messages_id);
        }

        /// <summary>
        /// 根据关联GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModelByLinkCode(Guid C_Messages_link)
        {
            return messageBLL.GetModelByLinkCode(C_Messages_link);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return messageBLL.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Messages model)
        {
            return messageBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Messages> GetListByPage(Model.C_Messages message, string orderby, int startIndex, int endIndex)
        {
            return messageBLL.GetListByPage(message, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return messageBLL.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 根据外键guid和用户guid获得数据列表
        /// </summary>
        public List<Model.C_Messages> GetListByLinkcodeAndUsercode(Guid? linkCode, Guid? userCode)
        {
            return messageBLL.GetListByLinkcodeAndUsercode(linkCode, userCode);
        }
        /// <summary>
        /// 根据关联GUID和消息接收人guid得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModelByLinkCodeUserCodeModel(Guid C_Messages_link, Guid userCode)
        {
            return messageBLL.GetModelByLinkCodeUserCodeModel(C_Messages_link, userCode);
        }

        /// <summary>
        /// 根据消息模型条件，获取所有消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>         
        public int GetAllMessageCount(CommonService.Model.C_Messages model)
        {
            return messageBLL.GetAllMessageCount(model);
        }

        /// <summary>
        /// 根据消息模型条件，获取所有ERP消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>        
        public int GetAllERPMessageCount(CommonService.Model.C_Messages model)
        {
            return messageBLL.GetAllERPMessageCount(model);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

      
    }
}
