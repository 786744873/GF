using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    public class C_Court_Lawyer : IC_Court_Lawyer
    {
        CommonService.BLL.C_Court_Lawyer bll = new CommonService.BLL.C_Court_Lawyer();

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.Customer.V_Lawyer model)
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
        public List<Model.Customer.V_Lawyer> GetListByPage(Model.Customer.V_Lawyer model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="C_Court_Lawyers"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.C_Court_Lawyer> C_Court_Lawyers)
        {
            return bll.OperateList(C_Court_Lawyers);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lawyerCode">律师Guid</param>
        /// <param name="courtCodes">法院Guid</param>
        /// <returns></returns>
        public bool Delete(Guid lawyerCode, Guid courtCodes)
        {
            return bll.Delete(lawyerCode,courtCodes);
        }
    }
}
