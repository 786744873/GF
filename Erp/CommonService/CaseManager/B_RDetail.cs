using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件--担保物约定服务
    /// 作者:崔慧栋
    /// 日期:2015/06/06
    /// </summary>
    public class B_RDetail : IB_RDetail
    {
        CommonService.BLL.CaseManager.B_RDetail bll = new CommonService.BLL.CaseManager.B_RDetail();

        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="B_RDetail_id"></param>
        /// <returns></returns>
        public bool Exists(int B_RDetail_id)
        {
            return bll.Exists(B_RDetail_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_RDetail model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_RDetail model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_RDetail_id"></param>
        /// <returns></returns>
        public bool Delete(int B_RDetail_id)
        {
            return bll.Delete(B_RDetail_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="B_RDetail_id"></param>
        /// <returns></returns>
        public Model.CaseManager.B_RDetail GetModel(int B_RDetail_id)
        {
            return bll.GetModel(B_RDetail_id);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_RDetail model)
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
        public List<Model.CaseManager.B_RDetail> GetListByPage(Model.CaseManager.B_RDetail model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

         /// <summary>
        /// 根据案件GUID得到收款分类关联par实体对象
        /// </summary>
        /// <param name="B_Case_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Parameters GetModelByCaseCode(Guid B_Case_code, int type)
        {
            return bll.GetModelByCaseCode(B_Case_code,type);
        }
    }
}
