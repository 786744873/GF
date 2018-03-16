using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Competitor”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Competitor.svc 或 C_Competitor.svc.cs，然后开始调试。
    public class C_Competitor:IC_Competitor
    {
        CommonService.BLL.C_Competitor cmBLL = new CommonService.BLL.C_Competitor();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return cmBLL.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Competitor_id)
        {
            return cmBLL.Exists(C_Competitor_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.C_Competitor model)
        {
            return cmBLL.ExistsByName(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_Competitor model)
        {
            return cmBLL.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.C_Competitor model)
        {
            return cmBLL.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Competitor_code)
        {
            return cmBLL.Delete(C_Competitor_code);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.C_Competitor GetModel(int C_Competitor_id)
        {
            return cmBLL.GetModel(C_Competitor_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.C_Competitor Get(Guid C_Competitor_code)
        {
            return cmBLL.GetModel(C_Competitor_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.C_Competitor model)
        {
            return cmBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Competitor> GetListByPage(Model.C_Competitor model, string orderby, int startIndex, int endIndex)
        {
            return cmBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
