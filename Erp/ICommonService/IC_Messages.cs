using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
namespace ICommonService
{
    /// <summary>
    /// 接口层C_Messages消息表
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Messages
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_Messages_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Messages model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Messages model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Messages_id);

        /// <summary>
        /// 读消息
        /// </summary>
        /// <param name="messageId">消息Id</param>
        /// <returns></returns>
        [OperationContract]
        bool ReadMessage(int messageId);

        [OperationContract]
        bool DeleteList(string C_Messages_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Messages GetModel(int C_Messages_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Messages model);

        /// <summary>
        /// 根据消息模型条件，获取所有消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int GetAllMessageCount(CommonService.Model.C_Messages model);

        /// <summary>
        /// 根据消息模型条件，获取所有ERP消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int GetAllERPMessageCount(CommonService.Model.C_Messages model);

        [OperationContract]
        List<CommonService.Model.C_Messages> GetListByPage(CommonService.Model.C_Messages message, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据关联GUID得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Messages GetModelByLinkCode(Guid C_Messages_link);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        /// <summary>
        /// 根据外键guid和用户guid获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Messages> GetListByLinkcodeAndUsercode(Guid? linkCode, Guid? userCode);
        /// <summary>
        /// 根据关联GUID和消息接收人guid得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Messages GetModelByLinkCodeUserCodeModel(Guid C_Messages_link, Guid userCode);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx

      
    }
}