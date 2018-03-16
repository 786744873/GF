using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 客户变更记录表契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Customer_ChangHistory
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Customer_ChangHistory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Customer_ChangHistory model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Customer_ChangHistory_code);
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="customerChangeHistoryList"></param>
        /// <returns></returns>
        [OperationContract]
        bool OpreateList(List<CommonService.Model.C_Customer_ChangHistory> customerChangeHistoryList);
        /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="CustomerChangHistoryCode">变更Guid</param>
        /// <param name="CustomerChangHistoryCheckPerson">审核人</param>
        /// <param name="stateId">审核状态</param>
        /// <returns></returns>
        [OperationContract]
        bool CheckOpreate(string CustomerChangHistoryCode,Guid CustomerChangHistoryCheckPerson,int? stateId);
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Customer_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_Customer_ChangHistory GetModel(Guid C_Customer_ChangHistory_code);
        /// <summary>
        /// 根据客户得到数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Customer_ChangHistory> GetListByCustomer(Guid C_Customer_ChangHistory_customer);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Customer_ChangHistory model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Customer_ChangHistory> GetListByPage(CommonService.Model.C_Customer_ChangHistory model, string orderby, int startIndex, int endIndex);
    }
}
