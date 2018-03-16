using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户联系人关联服务
    /// </summary>
    public class C_Customer_Contacts : IC_Customer_Contacts
    {
        CommonService.BLL.C_Customer_Contacts oBLL = new CommonService.BLL.C_Customer_Contacts();

        /// <summary>
        /// 增添一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.C_Customer_Contacts model)
        {
            return oBLL.Add(model);
        }
    }
}
