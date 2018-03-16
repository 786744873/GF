using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户变更记录服务
    /// </summary>
    public class C_Customer_ChangHistory : IC_Customer_ChangHistory
    {
        CommonService.BLL.C_Customer_ChangHistory bll = new CommonService.BLL.C_Customer_ChangHistory();
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.C_Customer_ChangHistory model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Customer_ChangHistory_code"></param>
        /// <returns></returns>
        public bool Delete(Guid C_Customer_ChangHistory_code)
        {
            return bll.Delete(C_Customer_ChangHistory_code);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="customerChangeHistoryList"></param>
        /// <returns></returns>
        public bool OpreateList(List<CommonService.Model.C_Customer_ChangHistory> customerChangeHistoryList)
        {
            return bll.OpreateList(customerChangeHistoryList);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="C_Customer_ChangHistory_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Customer_ChangHistory GetModel(Guid C_Customer_ChangHistory_code)
        {
            return bll.GetModelByCode(C_Customer_ChangHistory_code);
        }
        /// <summary>
        /// 根据客户得到数据列表
        /// </summary>
        /// <param name="C_Customer_ChangHistory_customer"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_Customer_ChangHistory> GetListByCustomer(Guid C_Customer_ChangHistory_customer)
        {
            return bll.GetListByCustomer(C_Customer_ChangHistory_customer);
        }
        /// <summary>
        /// 得到数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.C_Customer_ChangHistory model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_Customer_ChangHistory> GetListByPage(CommonService.Model.C_Customer_ChangHistory model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="CustomerChangHistoryCode">变更Guid</param>
        /// <param name="stateId">审核状态</param>
        /// <returns></returns>
        public bool CheckOpreate(string CustomerChangHistoryCode, Guid CustomerChangHistoryCheckPerson, int? stateId)
        {
            return bll.CheckOpreate(CustomerChangHistoryCode, CustomerChangHistoryCheckPerson,stateId);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Customer_ChangHistory model)
        {
            return bll.Update(model);
        }
    }
}
