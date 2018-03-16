using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户关联区域关系服务
    /// </summary>
    public class C_Customer_Region : IC_Customer_Region
    {
        CommonService.BLL.C_Customer_Region bll = new CommonService.BLL.C_Customer_Region();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Customer_Region model)
        {
            return bll.Add(model);
        }
        //根据客户code删除数据
        public bool DeleteByCustomerCode(Guid C_Customer_Region_customer)
        {
            return bll.DeleteByCustomerCode(C_Customer_Region_customer);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.C_Customer_Region> B_Customer_Regions)
        {
            return bll.OperateList(B_Customer_Regions);
        }
    }
}
