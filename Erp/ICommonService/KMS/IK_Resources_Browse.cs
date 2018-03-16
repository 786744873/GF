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
    /// 接口层K_Resources_Browse
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Resources_Browse
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int K_Resources_Browse_id);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Resources_Browse ExistsBrowse(Guid Userinfo_code, Guid K_Resources_code);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Resources_Browse model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Resources_Browse model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int K_Resources_Browse_id);
        [OperationContract]
        bool DeleteList(string K_Resources_Browse_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Resources_Browse GetModel(int K_Resources_Browse_id);
        /// <summary>
        /// 最近浏览
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources_Browse> GetListByCreatorTime(Guid Userinfo_code, int pageSize);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]
        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Resources_Browse model);
        [OperationContract]
        List<CommonService.Model.KMS.K_Resources_Browse> GetListByPage(CommonService.Model.KMS.K_Resources_Browse model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
