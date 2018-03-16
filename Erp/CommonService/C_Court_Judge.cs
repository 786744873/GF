using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    public class C_Court_Judge : IC_Court_Judge
    {
        CommonService.BLL.C_Court_Judge bll = new CommonService.BLL.C_Court_Judge();
                
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Court_Judge model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.C_Court_Judge> C_Court_Judges)
        {
            return bll.OperateList(C_Court_Judges);
        }
        /// <summary>
        /// 根据法院Code获取，法院关联法官集合
        /// </summary>
        /// <param name="courtCode">法院Code</param>
        /// <returns></returns>

        public List<CommonService.Model.C_Court_Judge> GetListByCourt(Guid courtCode)
        {
            return bll.GetListByCourt(courtCode);
        }
    }
}
