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
    /// 接口层K_Resources_Cover
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Resources_Cover
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int K_Resources_cover_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Resources_Cover model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Resources_Cover model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int K_Resources_cover_id);
        [OperationContract]
        bool DeleteList(string K_Resources_cover_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Resources_Cover GetModel(int K_Resources_cover_id);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]
        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获取全部数据
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources_Cover> GetAllList();
        /// <summary>
        /// 获得数据列表（已启用）
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources_Cover> GetStartList();

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
