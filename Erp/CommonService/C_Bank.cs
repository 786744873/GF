using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户银行服务
    /// </summary>
    public class C_Bank : IC_Bank
    {
        CommonService.BLL.C_Bank oBLL = new CommonService.BLL.C_Bank();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return oBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Bank_id)
        {
            return oBLL.Exists(C_Bank_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Bank model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Bank model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Bank_code)
        {
            return oBLL.Delete(C_Bank_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Bank_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Bank Get(Guid C_Bank_code)
        {
            return oBLL.GetModel(C_Bank_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Bank model)
        {
             return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Bank> GetListByPage(CommonService.Model.C_Bank model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
