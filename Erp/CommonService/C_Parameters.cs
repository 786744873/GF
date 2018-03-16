using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Parameters”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Parameters.svc 或 C_Parameters.svc.cs，然后开始调试。
    public class C_Parameters : IC_Parameters
    {
        CommonService.BLL.C_Parameters paraBLL = new CommonService.BLL.C_Parameters();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return paraBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Parameters_id)
        {
            return paraBLL.Exists(C_Parameters_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Parameters model)
        {
            return paraBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Parameters model)
        {
            return paraBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Parameters_id)
        {
            return paraBLL.Delete(C_Parameters_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Parameters GetModel(int C_Parameters_id)
        {
            return paraBLL.GetModel(C_Parameters_id);
        }
        /// <summary>
        /// 得到一个对象实体,
        /// <param name="relationId">根据父级ID和名称会的对象实体</param>
        /// </summary>
        public CommonService.Model.C_Parameters GetModelByParmentname(int C_Parameters_id, string C_parmeters_name)
        {
            return paraBLL.GetModelByParmentname(C_Parameters_id, C_parmeters_name);
        }
        /// <summary>
        /// 通过父级ID，获取子集集合
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Parameters> GetChildrenByParentId(int parentId)
        {
            return paraBLL.GetChildrenByParentId(parentId);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Parameters model)
        {
            return paraBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Parameters> GetListByPage(CommonService.Model.C_Parameters model, string orderby, int startIndex, int endIndex)
        {
            return paraBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据父级ID获取所有子集参数
        /// </summary>
        /// <param name="parentID">父级ID</param>
        /// <returns>所有子集参数</returns>
        public List<Model.C_Parameters> AppGetParametersByParentID(int parentID)
        {
            return paraBLL.GetChildrenByParentId(parentID);
        }
    }
}
