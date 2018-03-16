using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    /// <summary>
    /// 接口层C_Log
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Log
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
       [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Log model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_id);
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="C_idlist"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteList(string C_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Log GetModel(int C_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        DataSet GetList(string strWhere);
       /// <summary>
        /// 获得前几行数据
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
        [OperationContract]
        int GetRecordCount(string strWhere);
        /// <summary>
        /// 获得最近上次登录时间
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Log> GetListDate(Guid strguid);
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
         [OperationContract]
        List<CommonService.Model.SysManager.C_Log> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  登录日志报表

        /// <summary>
        /// 根据区域统计使用人数
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetReportByArea(DateTime dateFrom, DateTime dateTo, string organization);

        /// <summary>
        /// 根据区域统计使用次数
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetReportByAreaCount(DateTime dateFrom, DateTime dateTo, string organization);

        #endregion 
    } 
}
