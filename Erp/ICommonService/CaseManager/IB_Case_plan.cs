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
    /// 办案方案接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_plan
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(Guid? B_Case_plan_code);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_plan model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_plan model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_Case_plan_id);
        [OperationContract]
        bool DeleteList(string B_Case_plan_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_plan GetModel(int B_Case_plan_id);
        /// <summary>
        /// 得到一个对象实体 通过案件GUID
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_plan GetModelByCode(Guid B_Case_plan_id);

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
        /// 向数据库添加或者修改一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddOrUpdate(CommonService.Model.CaseManager.B_Case_plan model);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
