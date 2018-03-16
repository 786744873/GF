using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.FlowManager
{
    /// <summary>
    /// 业务流程--表单--用户中间表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/05/28
    /// </summary>
    public partial class P_Business_flow_form_user
    {
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form_user dal = new CommonService.DAL.FlowManager.P_Business_flow_form_user();
        public P_Business_flow_form_user()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Business_flow_form_user_id)
        {
            return dal.Exists(P_Business_flow_form_user_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_form_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_form_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid P_Business_flow_form_user_code)
        {
            return dal.Delete(P_Business_flow_form_user_code);
        }

        /// <summary>
        /// 根据业务流程关联表单Guid删除人员
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool DeleteByBusinessFlowFormCode(Guid businessFlowFormCode)
        {
            return dal.DeleteByBusinessFlowFormCode(businessFlowFormCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string P_Business_flow_form_user_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(P_Business_flow_form_user_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.FlowManager.P_Business_flow_form_user GetModel(int P_Business_flow_form_user_id)
        {

            return dal.GetModel(P_Business_flow_form_user_id);
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取所有协办律师集合
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form_user> GetListByBusinessFlowFormCode(Guid businessFlowFormCode)
        {
            DataSet ds = dal.GetListByBusinessFlowFormCode(businessFlowFormCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form_user> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form_user> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form_user> modelList = new List<CommonService.Model.FlowManager.P_Business_flow_form_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.FlowManager.P_Business_flow_form_user model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
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
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
