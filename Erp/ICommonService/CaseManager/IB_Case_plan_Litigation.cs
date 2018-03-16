using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 接口层B_Case_plan_Litigation
    /// </summary>
    /// <summary>
    /// 办案方案和提交的证据中间表
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_plan_Litigation
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int B_Case_plan_Litigation_id);
        /// 根据参数ID 和案件GUID查找是否存在记录
        /// </summary>
        /// <param name="parameterid"></param>
        /// <param name="casecode"></param>
        /// <returns></returns>
        [OperationContract]
        bool ExitsByParameteridAndCasecode(int parameterid, Guid casecode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_plan_Litigation model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_plan_Litigation model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_Case_plan_Litigation_id);
        [OperationContract]
        bool DeleteList(string B_Case_plan_Litigation_idlist);
        /// <summary>
        /// 通过参数ID和案件GUID得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_plan_Litigation GetModelByParameterAndCasecode(int parameterid, Guid casecode);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_plan_Litigation GetModel(int B_Case_plan_Litigation_id);
        /// <summary>
        /// 根据父级ParameterID和案件编码获取列表
        /// </summary>
        /// <param name="C_Parameters_id">父级ID</param>
        /// <param name="casecode">案件编码</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_plan_Litigation> GetListByCasecodeAndParameterId(int C_Parameters_id, Guid casecode);

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


    }
}
