using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Group”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Group.svc 或 C_Group.svc.cs，然后开始调试。
    public class C_Group : IC_Group
    {
        CommonService.BLL.SysManager.C_Group bll = new CommonService.BLL.SysManager.C_Group();


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
        /// <param name="C_Group_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Group_id)
        {
            return bll.Exists(C_Group_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SysManager.C_Group model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.SysManager.C_Group model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        public bool Delete(Guid C_Group_code)
        {
            return bll.Delete(C_Group_code);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="C_Group_id"></param>
        /// <returns></returns>
        public Model.SysManager.C_Group GetModel(int C_Group_id)
        {
            return bll.GetModel(C_Group_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="C_Group_id"></param>
        /// <returns></returns>
        public Model.SysManager.C_Group GetModelByCode(Guid C_Group_code)
        {
            return bll.GetModelByCode(C_Group_code);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.SysManager.C_Group> GetAllList()
        {
            return bll.GetAllList();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.SysManager.C_Group model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Group> GetListByPage(Model.SysManager.C_Group model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
