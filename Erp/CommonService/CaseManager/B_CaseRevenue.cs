using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 收入信息服务
    /// </summary>
    public class B_CaseRevenue : IB_CaseRevenue
    {
        private readonly CommonService.BLL.CaseManager.B_CaseRevenue bll = new BLL.CaseManager.B_CaseRevenue();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="B_CaseRevenue_id"></param>
        /// <returns></returns>
        public bool Exists(int B_CaseRevenue_id)
        {
            return bll.Exists(B_CaseRevenue_id);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_CaseRevenue model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_CaseRevenue model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="B_CaseRevenue_id"></param>
        /// <returns></returns>
        public bool Delete(int B_CaseRevenue_id)
        {
            return bll.Delete(B_CaseRevenue_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="B_CaseRevenue_id"></param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseRevenue GetModel(int B_CaseRevenue_id)
        {
            return bll.GetModel(B_CaseRevenue_id);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_CaseRevenue model)
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
        public List<Model.CaseManager.B_CaseRevenue> GetListByPage(Model.CaseManager.B_CaseRevenue model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
