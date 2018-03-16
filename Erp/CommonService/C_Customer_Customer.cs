using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户关联委托人关系服务
    /// </summary>
    public class C_Customer_Customer : IC_Customer_Customer
    {
        CommonService.BLL.C_Customer_Customer oBLL = new CommonService.BLL.C_Customer_Customer();

        /// <summary>
        /// 增添一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.C_Customer_Customer model)
        {
            return oBLL.Add(model);
        }
         /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="relationCode">客户Guid</param>
        /// <param name="clientCode">关联委托人Guid</param>
        /// <returns></returns>
        public bool Delete(Guid relationCode, Guid clientCode)
        {
            return oBLL.Delete(relationCode,clientCode);
        }
    }
}
