using ICommonService.MonitorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.MonitorManager
{
    /// <summary>
    /// 条目服务
    /// </summary>
    public class M_Entry : IM_Entry
    {
        CommonService.BLL.MonitorManager.M_Entry bll = new CommonService.BLL.MonitorManager.M_Entry();
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
        /// <param name="M_Entry_id"></param>
        /// <returns></returns>
        public bool Exists(int M_Entry_id)
        {
            return bll.Exists(M_Entry_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.MonitorManager.M_Entry model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.MonitorManager.M_Entry model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="M_Entry_id"></param>
        /// <returns></returns>
        public bool Delete(int M_Entry_id)
        {
            return bll.Delete(M_Entry_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="M_Entry_id"></param>
        /// <returns></returns>
        public Model.MonitorManager.M_Entry GetModel(int M_Entry_id)
        {
            return bll.GetModel(M_Entry_id);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.MonitorManager.M_Entry model)
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
        public List<Model.MonitorManager.M_Entry> GetListByPage(Model.MonitorManager.M_Entry model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<Model.MonitorManager.M_Entry> GetAllList()
        {
            return bll.GetAllList();
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="M_Entry_code"></param>
        /// <returns></returns>
        public Model.MonitorManager.M_Entry GetModelByCode(Guid M_Entry_code)
        {
            return bll.GetModelByCode(M_Entry_code);
        }
    }
}
