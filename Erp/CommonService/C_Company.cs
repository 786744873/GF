using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户公司服务
    /// </summary>
    public class C_Company : IC_Company
    {
        CommonService.BLL.C_Company oBLL = new CommonService.BLL.C_Company();
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
        public bool Exists(int C_Company_id)
        {
            return oBLL.Exists(C_Company_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Company model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Company model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Company_code)
        {
            return oBLL.Delete(C_Company_code);           
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Company_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Company Get(Guid C_Company_code)
        {
            return oBLL.GetModel(C_Company_code);          
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Company model)
        {
             return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Company> GetListByPage(CommonService.Model.C_Company model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);            
        }
    }
}
