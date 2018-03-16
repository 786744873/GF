using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    /// <summary>
    /// 接口层IK_Browse_Log
    /// </summary>
    /// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Browse_Log
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int K_Browse_Log_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Browse_Log model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Browse_Log model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int K_Browse_Log_id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Browse_Log GetModel(int K_Browse_Log_id);
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
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool IsExists(CommonService.Model.KMS.K_Browse_Log model);
        /// <summary>
        /// 根据ip或用户获取资源浏览量
        /// </summary>
        [OperationContract]
        int GetBrowseCount(Guid P_FK_code, string groupBy);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
