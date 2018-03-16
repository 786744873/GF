using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_PRival_education”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_PRival_education.svc 或 C_PRival_education.svc.cs，然后开始调试。
    public class C_PRival_education : IC_PRival_education
    {
        CommonService.BLL.C_PRival_education bll = new CommonService.BLL.C_PRival_education();

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
        public bool Exists(int C_PRival_education_id)
        {
            return bll.Exists(C_PRival_education_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_PRival_education model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_PRival_education model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_PRival_code"></param>
        /// <returns></returns>
        public bool Delete(int C_PRival_education_id)
        {
            return bll.Delete(C_PRival_education_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_PRival_id"></param>
        /// <returns></returns>
        public Model.C_PRival_education GetModel(int C_PRival_education_id)
        {
            return bll.GetModel(C_PRival_education_id);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_PRival_education model)
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
        public List<Model.C_PRival_education> GetListByPage(Model.C_PRival_education model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
