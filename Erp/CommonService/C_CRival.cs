using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_CRival”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_CRival.svc 或 C_CRival.svc.cs，然后开始调试。
    public class C_CRival : IC_CRival
    {
        CommonService.BLL.C_CRival crBLL = new CommonService.BLL.C_CRival();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return crBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_CRival_id"></param>
        /// <returns></returns>
        public bool Exists(int C_CRival_id)
        {
            return crBLL.Exists(C_CRival_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.C_CRival model)
        {
            return crBLL.ExistsByName(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_CRival model)
        {
            return crBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_CRival model)
        {
            return crBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_CRival_id"></param>
        /// <returns></returns>
        public bool Delete(Guid C_CRival_code)
        {
            return crBLL.Delete(C_CRival_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_CRival model)
        {
            return crBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_CRival> GetListByPage(Model.C_CRival model, string orderby, int startIndex, int endIndex)
        {
            return crBLL.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_CRival_code"></param>
        /// <returns></returns>
        public Model.C_CRival GetModel(Guid C_CRival_code)
        {
            return crBLL.GetModel(C_CRival_code);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_CRival_id"></param>
        /// <returns></returns>
        public Model.C_CRival Get(int C_CRival_id)
        {
            return crBLL.GetModel(C_CRival_id);
        }
    }
}
