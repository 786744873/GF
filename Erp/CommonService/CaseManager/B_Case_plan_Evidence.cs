using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// B_Case_plan_Evidence
    /// </summary>
    public class B_Case_plan_Evidence : IB_Case_plan_Evidence
    {
        private readonly CommonService.BLL.CaseManager.B_Case_plan_Evidence bll = new CommonService.BLL.CaseManager.B_Case_plan_Evidence();
        public B_Case_plan_Evidence()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_plan_Evidence_id)
        {
            return bll.Exists(B_Case_plan_Evidence_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan_Evidence model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_plan_Evidence model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_plan_Evidences"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.CaseManager.B_Case_plan_Evidence> B_Case_plan_Evidences)
        {
            return bll.OperateList(B_Case_plan_Evidences);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_plan_Evidence_id)
        {

            return bll.Delete(B_Case_plan_Evidence_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_plan_Evidence_idlist)
        {
            return bll.DeleteList(B_Case_plan_Evidence_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Evidence GetModel(int B_Case_plan_Evidence_id)
        {

            return bll.GetModel(B_Case_plan_Evidence_id);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return bll.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }

}
