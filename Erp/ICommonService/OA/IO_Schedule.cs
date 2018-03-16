using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 接口层O_Schedule日程
    /// cyj
    /// 2015年7月14日17:12:08
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Schedule
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int O_Schedule_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_Schedule model);

        /// <summary>
        /// 新增日程和日程用户
        /// </summary>
        /// <param name="schedule">日程实体</param>
        /// <param name="scheduleUsers">日程用户实体</param>
        /// <returns></returns>
        [OperationContract]
        bool AddHeadAndItems(CommonService.Model.OA.O_Schedule schedule, List<CommonService.Model.OA.O_Schedule_user> scheduleUsers);

        /// <summary>
        /// 更新日程和日程用户
        /// </summary>
        /// <param name="schedule">日程实体</param>
        /// <param name="scheduleUsers">日程用户实体</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateHeadAndItems(CommonService.Model.OA.O_Schedule schedule, List<CommonService.Model.OA.O_Schedule_user> scheduleUsers);

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Schedule> GetAllList();

        /// <summary>
        /// 通过根用户，获取所有列表
        /// </summary>
        /// <param name="rootUserCode">根用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.OA.O_Schedule> GetListByRootUserCode(Guid rootUserCode);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Schedule model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid scheduleCode);
        [OperationContract]
        bool DeleteList(string O_Schedule_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Schedule GetModel(Guid scheduleCode);
        [OperationContract]
        int GetRecordCount(string strWhere);
        [OperationContract]
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        /// <summary>
        /// 通过用户guid获得未读取的日程消息全部数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Schedule> GetMsgListByUsercode(Guid userCode);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx

        #region App专用

        /// <summary>
        /// 通过主用户GUID获取日程
        /// </summary>
        /// <param name="userCode">主用户GUID</param>
        /// <returns>日程列表</returns>
        [WebInvoke(UriTemplate = "AppGetSchedule", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.OA.O_Schedule> AppGetSchedule(Guid? userCode);

        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AppAddSchedule", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppAddSchedule(CommonService.Model.OA.O_Schedule model);

        #endregion
    }
}
