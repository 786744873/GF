using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Property_trail_cars”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Property_trail_cars.svc 或 C_Property_trail_cars.svc.cs，然后开始调试。
    public class C_Property_trail_cars : IC_Property_trail_cars
    {
        CommonService.BLL.C_Property_trail_cars bll = new CommonService.BLL.C_Property_trail_cars();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
        public bool Exists(int C_Property_trail_cars_id)
        {
            return bll.Exists(C_Property_trail_cars_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Property_trail_cars model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Property_trail_cars model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        public bool Delete(int C_Property_trail_cars_id)
        {
            return bll.Delete(C_Property_trail_cars_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <returns></returns>
        public Model.C_Property_trail_cars GetModel(int C_Property_trail_cars_id)
        {
            return bll.GetModel(C_Property_trail_cars_id);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_Property_trail_cars model)
        {
            return bll.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Model.C_Property_trail_cars> GetListByPage(Model.C_Property_trail_cars model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
