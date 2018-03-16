using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "")]
    /// <summary>
    /// 客户地址服务
    /// </summary>
    public class C_ADemo : IC_ADemo
    {
        CommonService.BLL.C_Address oBLL = new CommonService.BLL.C_Address();
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
        public bool Exists(int C_Address_id)
        {
            return oBLL.Exists(C_Address_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Address model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Address model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Address_code)
        {
            return oBLL.Delete(C_Address_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Address_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Address Get(Guid C_Address_code)
        {
            return oBLL.GetModel(C_Address_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Address model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Address> GetListByPage(CommonService.Model.C_Address model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
