using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Customer
{
    /// <summary>
    /// 虚拟稽查业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/11/19
    /// </summary>
    public partial class V_CheckAuthority
    {
        private readonly CommonService.DAL.Customer.V_CheckAuthority dal = new CommonService.DAL.Customer.V_CheckAuthority();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.Customer.V_CheckAuthority> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.Customer.V_CheckAuthority> modelList = new List<CommonService.Model.Customer.V_CheckAuthority>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.Customer.V_CheckAuthority model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 根据业务Guid，获取简要稽查信息
        /// </summary>
        /// <param name="pkCode">业务Guid,比如案件Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_CheckAuthority> GetBriefCheckAuthorityByPkCode(Guid pkCode)
        {
            return DataTableToList(dal.GetBriefCheckAuthorityByPkCode(pkCode).Tables[0]);
        }
    }
}
