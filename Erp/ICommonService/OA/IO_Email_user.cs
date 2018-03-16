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
    /// 接口层O_Email_user邮件用户中间表
    /// cyj 
    /// 2015年7月14日16:36:44
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Email_user
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]

        bool Exists(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]

        bool Add(CommonService.Model.OA.O_Email_user model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]

        bool Update(CommonService.Model.OA.O_Email_user model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]

        bool Delete(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        /// <summary>
        /// 根据邮件guid和收件人guid获取数据
        /// </summary>
        CommonService.Model.OA.O_Email_user GetModelByEcodeAndUcode(Guid O_Email_code, Guid C_Userinfo_code);
        [OperationContract]
        CommonService.Model.OA.O_Email_user GetModel(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]

        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]

        int GetRecordCount(CommonService.Model.OA.O_Email_user model);
        [OperationContract]

        List<CommonService.Model.OA.O_Email_user> GetListByPage(CommonService.Model.OA.O_Email_user model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        /// <summary>
        /// 根据邮件的code和收件人code删除一条数据
        /// </summary>
        [OperationContract]
        bool DeleteByCode(Guid O_Email_code, Guid userCode);

        /// <summary>
        /// 根据邮件code获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Email_user> GetListByEmailCode(Guid emailCode);
        /// <summary>
        /// 根据收件人code获得未读邮件的数据列表
        /// </summary>
        [OperationContract]

        List<CommonService.Model.OA.O_Email_user> GetNoReadListUserCode(Guid C_Userinfo_code);
        /// <summary>
        /// 根据收件人code获得所有的邮件数据列表以及邮件的消息信息
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Email_user> GetListByUserCode(Guid C_Userinfo_code);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
