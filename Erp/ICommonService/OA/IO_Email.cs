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
    /// 接口层O_Email邮件
    /// cyj
    /// 2015年7月14日16:20:33
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Email
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]

        bool Exists(int O_Email_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]

        int Add(CommonService.Model.OA.O_Email model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]

        bool Update(CommonService.Model.OA.O_Email model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]

        bool Delete(int O_Email_id);
        [OperationContract]

        bool DeleteList(string O_Email_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]

        CommonService.Model.OA.O_Email GetModel(int O_Email_id);
        /// <summary>
        /// 根据emailcode得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Email GetModelByCode(Guid emailCode);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]

        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]

        int GetRecordCount(CommonService.Model.OA.O_Email model);
        [OperationContract]

        List<CommonService.Model.OA.O_Email> GetListByPage(CommonService.Model.OA.O_Email model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        /// <summary>
        /// 多条添加
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        [OperationContract]
        bool MutilyAddEmail(CommonService.Model.OA.O_Email email, string userList);

        /// <summary>
        /// 根据邮件guid删除相应草稿箱的信息
        /// </summary>
        /// <param name="emailCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MutilyDelete(Guid emailCode);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
