using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{

    /// <summary>
    /// 办案方案和提交的证据中间表
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_plan_Evidence
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int B_Case_plan_Evidence_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_plan_Evidence model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_plan_Evidence model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_Case_plan_Evidence_id);
        [OperationContract]
        bool DeleteList(string B_Case_plan_Evidence_idlist);
        [OperationContract]
        bool OperateList(List<CommonService.Model.CaseManager.B_Case_plan_Evidence> B_Case_plan_Evidences);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_plan_Evidence GetModel(int B_Case_plan_Evidence_id);
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
