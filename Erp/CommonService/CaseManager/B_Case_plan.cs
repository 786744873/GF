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
    /// B_Case_plan办案方案
    /// </summary>
    public class B_Case_plan:IB_Case_plan
    {
        private CommonService.BLL.CaseManager.B_Case_plan bll = new CommonService.BLL.CaseManager.B_Case_plan();
        public B_Case_plan()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid? B_Case_plan_code)
        {
            return bll.Exists(B_Case_plan_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_plan model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_plan_id)
        {

            return bll.Delete(B_Case_plan_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_plan_idlist)
        {
            return bll.DeleteList(B_Case_plan_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan GetModel(int B_Case_plan_id)
        {

            return bll.GetModel(B_Case_plan_id);
        }

        /// <summary>
        /// 得到一个对象实体 通过案件GUID
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan GetModelByCode(Guid B_Case_code)
        {
            return bll.GetModelByCode(B_Case_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return bll.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
        /// <summary>
        /// 向数据库添加或者修改一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdate(CommonService.Model.CaseManager.B_Case_plan model)
        {
            return bll.AddOrUpdate(model);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
