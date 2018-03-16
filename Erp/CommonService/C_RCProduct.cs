using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_RCProduct”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_RCProduct.svc 或 C_RCProduct.svc.cs，然后开始调试。
    public class C_RCProduct:IC_RCProduct
    {
        CommonService.BLL.C_RCProduct rcBLL = new CommonService.BLL.C_RCProduct();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return rcBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_RCProduct_id)
        {
            return rcBLL.Exists(C_RCProduct_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_RCProduct model)
        {
            return rcBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.C_RCProduct model)
        {
            return rcBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_RCProduct_id)
        {
            return rcBLL.Delete(C_RCProduct_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.C_RCProduct GetModel(int C_RCProduct_id)
        {
            return rcBLL.GetModel(C_RCProduct_id);
        }

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Model.C_RCProduct GetModel(Guid C_RCProduct_code)
        //{
        //    return rcBLL.GetModel(C_RCProduct_code);
        //}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.C_RCProduct model)
        {
            return rcBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_RCProduct> GetListByPage(Model.C_RCProduct model, string orderby, int startIndex, int endIndex)
        {
            return rcBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }


       
    }
}
