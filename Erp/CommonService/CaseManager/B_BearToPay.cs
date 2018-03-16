using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件--费用承担服务
    /// </summary>
    public class B_BearToPay : IB_BearToPay
    {
        CommonService.BLL.CaseManager.B_BearToPay bll = new CommonService.BLL.CaseManager.B_BearToPay();

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
        /// <param name="B_BearToPay_id"></param>
        /// <returns></returns>
        public bool Exists(int B_BearToPay_id)
        {
            return bll.Exists(B_BearToPay_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_BearToPay model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_BearToPay model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_BearToPay_id"></param>
        /// <returns></returns>
        public bool Delete(int B_BearToPay_id)
        {
            return bll.Delete(B_BearToPay_id);
        }
        /// <summary>
        /// 根据案件GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_BearToPay GetModel(Guid B_Case_code, int B_BearToPay_ctypes)
        {
            return bll.GetModel(B_Case_code, B_BearToPay_ctypes);
        }
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_BearToPay model)
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
        public List<Model.CaseManager.B_BearToPay> GetListByPage(Model.CaseManager.B_BearToPay model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
