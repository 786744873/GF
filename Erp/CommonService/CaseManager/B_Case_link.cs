using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件关联服务
    /// </summary>
    public class B_Case_link : IB_Case_link
    {
        CommonService.BLL.CaseManager.B_Case_link bll = new CommonService.BLL.CaseManager.B_Case_link();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="B_Case_link_id"></param>
        /// <returns></returns>
        public bool Exists(int B_Case_link_id)
        {
            return Exists(B_Case_link_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_Case_link model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.CaseManager.B_Case_link> B_Case_links)
        {
            return bll.OperateList(B_Case_links);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_Case_link model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_Case_link_id"></param>
        /// <returns></returns>
        public bool Delete(Guid B_Case_code)
        {
            return bll.Delete(B_Case_code);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="B_Case_link_id"></param>
        /// <returns></returns>
        public Model.CaseManager.B_Case_link GetModel(int B_Case_link_id)
        {
            return bll.GetModel(B_Case_link_id);
        }
        /// <summary>
        /// 根据外键code和类型得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_link GetModelByFkCodeAndType(Guid? fk_code, int? type)
        {
            return bll.GetModelByFkCodeAndType(fk_code, type);
        }
        /// <summary>
        /// 获取案件关联集合
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="type">关联类型</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case_link> GetCaseLinksByCaseAndType(Guid caseCode, int type)
        {
            return bll.GetCaseLinksByCaseAndType(caseCode, type);
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_Case_link model)
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
        public List<Model.CaseManager.B_Case_link> GetListByPage(Model.CaseManager.B_Case_link model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
