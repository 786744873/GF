using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_PRival”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_PRival.svc 或 C_PRival.svc.cs，然后开始调试。
    public class C_PRival : IC_PRival
    {
        CommonService.BLL.C_PRival bll = new CommonService.BLL.C_PRival();

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
        /// <param name="C_PRival_id"></param>
        /// <returns></returns>
        public bool Exists(int C_PRival_id)
        {
            return bll.Exists(C_PRival_id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.C_PRival model)
        {
            return bll.ExistsByName(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_PRival model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_PRival model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_PRival_code"></param>
        /// <returns></returns>
        public bool Delete(Guid C_PRival_code)
        {
            return bll.Delete(C_PRival_code);
        }

        /// <summary>
        /// 根据父级GUID得到子集集合
        /// </summary>
        public CommonService.Model.C_PRival GetModelByPcode(Guid C_PRival_code)
        {
            return bll.GetModelByPcode(C_PRival_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_PRival_id"></param>
        /// <returns></returns>
        public Model.C_PRival GetModel(Guid C_PRival_code)
        {
            return bll.GetModel(C_PRival_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_PRival model)
        {
            return bll.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_PRival> GetListByPage(Model.C_PRival model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
