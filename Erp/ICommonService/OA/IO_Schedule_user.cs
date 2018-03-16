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
    /// 接口层O_Schedule_user2.	日程----用户中间表
    /// cyj
    /// 2015年7月14日15:33:37
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Schedule_user
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.OA.O_Schedule_user model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Schedule_user model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete);


        /// <summary>
        /// 根据日程Guid删除关联数据数据
        /// </summary>
        [OperationContract]
        bool DeleteByScheduleCode(Guid O_Schedule_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Schedule_user GetModel(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete);

        /// <summary>
        /// 通过日程Guid，获取日程用户集合
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.OA.O_Schedule_user> GetScheduleUsersByScheduleCode(Guid scheduleCode);


        [OperationContract]
        int GetRecordCount(string strWhere);

        [OperationContract]
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 获得参与者数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Schedule_user> GetUserList(Guid O_Schedule_code);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
