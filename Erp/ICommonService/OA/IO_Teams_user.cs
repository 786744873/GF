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
    /// 接口层O_Teams_user分组用户中间表
    /// cyj
    /// 2015年7月14日16:10:54
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Teams_user
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.OA.O_Teams_user model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Teams_user model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Teams_user GetModel(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete);
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
