using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 接口层O_Chats聊天表
    /// cyj
    /// 2015年7月14日17:11:45
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Chats
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]

        bool Exists(int O_Chats_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]

        int Add(CommonService.Model.OA.O_Chats model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]

        bool Update(CommonService.Model.OA.O_Chats model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]

        bool Delete(int O_Chats_id);
        [OperationContract]

        bool DeleteList(string O_Chats_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]

        CommonService.Model.OA.O_Chats GetModel(int O_Chats_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]

        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]

        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]

        int GetRecordCount(string strWhere);
        [OperationContract]

        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
