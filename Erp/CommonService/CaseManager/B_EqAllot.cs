using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件--涉案合同权益分配服务
    /// </summary>
    public class B_EqAllot : IB_EqAllot
    {
        CommonService.BLL.CaseManager.B_EqAllot bll = new CommonService.BLL.CaseManager.B_EqAllot();

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
        /// <param name="B_EqAllot_id"></param>
        /// <returns></returns>
        public bool Exists(int B_EqAllot_id)
        {
            return bll.Exists(B_EqAllot_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_EqAllot model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_EqAllot model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_EqAllot_id"></param>
        /// <returns></returns>
        public bool Delete(int B_EqAllot_id)
        {
            return bll.Delete(B_EqAllot_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="B_EqAllot_id"></param>
        /// <returns></returns>
        public Model.CaseManager.B_EqAllot GetModel(Guid B_Case_code, int B_EqAllot_pright)
        {
            return bll.GetModel(B_Case_code, B_EqAllot_pright);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_EqAllot> GetAllList(Guid B_Case_code)
        {
            return bll.GetAllList(B_Case_code);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_EqAllot model, int type)
        {
            return bll.GetRecordCount(model,type);
        }
        /// <summary>
        /// 分页获取全部数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_EqAllot> GetListByPage(Model.CaseManager.B_EqAllot model, string orderby, int startIndex, int endIndex, int type)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex,type);
        }
    }
}
