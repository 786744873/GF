using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Involved_project”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Involved_project.svc 或 C_Involved_project.svc.cs，然后开始调试。
    public class C_Involved_project : IC_Involved_project
    {
        CommonService.BLL.C_Involved_project bll = new CommonService.BLL.C_Involved_project();

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
        /// <param name="C_Involved_project_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Involved_project_id)
        {
            return bll.Exists(C_Involved_project_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.C_Involved_project model)
        {
            return bll.ExistsByName(model);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Involved_project model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Involved_project model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Involved_project_id"></param>
        /// <returns></returns>
        public bool Delete(Guid C_Involved_project_code)
        {
            return bll.Delete(C_Involved_project_code);
        }
        /// <summary>
        /// 根据Code得到一个对象实体
        /// </summary>
        /// <param name="C_Involved_project_code"></param>
        /// <returns></returns>
        public Model.C_Involved_project GetModelByCode(Guid C_Involved_project_code)
        {
            return bll.GetModel(C_Involved_project_code);
        }
        /// <summary>
        /// 根据ID得到一个实体对象
        /// </summary>
        /// <param name="C_Involved_project_id"></param>
        /// <returns></returns>
        public Model.C_Involved_project GetModel(int C_Involved_project_id)
        {
            return bll.GetModel(C_Involved_project_id);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.C_Involved_project> GetAllList()
        {
            return bll.GetAllList();
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_Involved_project model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_Involved_project> GetListByPage(Model.C_Involved_project model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
