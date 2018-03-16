using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 成本信息服务
    /// </summary>
    public class B_CaseCost : IB_CaseCost
    {
        private readonly CommonService.BLL.CaseManager.B_CaseCost bll = new BLL.CaseManager.B_CaseCost();

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
        /// <param name="B_CaseCost_id"></param>
        /// <returns></returns>
        public bool Exists(int B_CaseCost_id)
        {
            return bll.Exists(B_CaseCost_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_CaseCost model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_CaseCost model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_CaseCost_id"></param>
        /// <returns></returns>
        public bool Delete(int B_CaseCost_id)
        {
            return bll.Delete(B_CaseCost_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="B_CaseCost_id"></param>
        /// <returns></returns>
        public Model.CaseManager.B_CaseCost GetModel(Guid B_Case_code, int B_CaseCost_type)
        {
            return bll.GetModel(B_Case_code,B_CaseCost_type);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_CaseCost model)
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
        public List<Model.CaseManager.B_CaseCost> GetListByPage(Model.CaseManager.B_CaseCost model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
