using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.FlowManager
{
    /// <summary>
    /// 业务流程申请记录表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/10/22
    /// </summary>
    public partial class P_Business_flow_applyRecord
    {
        private readonly CommonService.DAL.FlowManager.P_Business_flow_applyRecord dal = new CommonService.DAL.FlowManager.P_Business_flow_applyRecord();
        public P_Business_flow_applyRecord()
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
        public bool Exists(int P_Business_flow_applyRecord_id)
        {
            return dal.Exists(P_Business_flow_applyRecord_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_applyRecord model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_applyRecord model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid businessFlowApplyRecordCode)
        {
            return dal.Delete(businessFlowApplyRecordCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string P_Business_flow_applyRecord_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(P_Business_flow_applyRecord_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.FlowManager.P_Business_flow_applyRecord GetModel(Guid businessFlowApplyRecordCode)
        {
            return dal.GetModel(businessFlowApplyRecordCode);
        }

        /// <summary>
        /// 根据业务Guid(商机Guid)，获取业务流程申请记录集合
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> GetListByKpCode(Guid pkCode)
        {
            DataSet ds = dal.GetListByKpCode(pkCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据业务流程Guid和记录类型，获取尚未审查的业务流程申请记录集合
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="recordType">记录类型</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> GetUnAuditList(Guid businessFlowCode, int recordType)
        {
            DataSet ds = dal.GetUnAuditList(businessFlowCode, recordType);
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
        public List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> modelList = new List<CommonService.Model.FlowManager.P_Business_flow_applyRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.FlowManager.P_Business_flow_applyRecord model;
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
