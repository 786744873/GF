using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    /// <summary>
    /// 接口层K_Exam_Students
    /// </summary>
    /// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Exam_Students
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(Guid K_Exam_Students_code);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.KMS.K_Exam_Students model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Exam_Students model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Exam_Students_code);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Exam_Students GetModel(Guid K_Exam_Students_code);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Exam_Students> GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Exam_Students> GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]
        int GetRecordCount(string strWhere);
        [OperationContract]
        List<CommonService.Model.KMS.K_Exam_Students> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
