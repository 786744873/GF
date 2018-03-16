using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{   /// <summary>
    /// 附件表接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Files
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
        bool Exists(int C_Files_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.C_Files model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Files model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid fileCode);
        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Files GetModelByCode(Guid C_Files_code);

        [OperationContract]
        bool DeleteList(string C_Files_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Files GetModel(int C_Files_id);
        /// <summary>
        /// 根据文件名得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Files GetModelByName(string fileName);

        /// <summary>
        /// 根据文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Files> GetFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode);
        /// <summary>
        /// 根据父级文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Files> GetChildenFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]
        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]
        int GetRecordCount(string strWhere);
        [OperationContract]
        List<CommonService.Model.C_Files> GetListByPage(CommonService.Model.C_Files files, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
