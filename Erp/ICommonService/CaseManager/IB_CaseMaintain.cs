using CommonService.Model.CaseManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;




namespace ICommonService.CaseManager
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_CaseMaintain
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
        bool Exists(int B_CaseMaintain_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_CaseMaintain model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_CaseMaintain model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_CaseMaintain_id);
        //删除多条数据
        [OperationContract]
        bool DeleteCase(string caseCode);
        [OperationContract]
        bool DeleteList(string B_CaseMaintain_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_CaseMaintain GetModel(int B_CaseMaintain_id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        DataSet GetList(string strWhere);
    
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_CaseMaintain strWhere);
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseMaintain> GetListByPage(CommonService.Model.CaseManager.B_CaseMaintain strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
