using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// 流程预设审批人表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_FlowSet_AuditPerson
    {
        private readonly CommonService.DAL.OA.O_FlowSet_AuditPerson dal = new DAL.OA.O_FlowSet_AuditPerson();
        public O_FlowSet_AuditPerson()
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
        public bool Exists(int O_FlowSet_auditPerson_id)
        {
            return dal.Exists(O_FlowSet_auditPerson_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_FlowSet_auditPerson_code)
        {

            return dal.Delete(O_FlowSet_auditPerson_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_FlowSet_auditPerson_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(O_FlowSet_auditPerson_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_FlowSet_AuditPerson GetModel(Guid O_FlowSet_auditPerson_code)
        {

            return dal.GetModel(O_FlowSet_auditPerson_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_FlowSet_AuditPerson> modelList = new List<CommonService.Model.OA.O_FlowSet_AuditPerson>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_FlowSet_AuditPerson model;
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
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 根据预设流程GUID获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByflowSetCode(Guid flowsetCode)
        {
            return DataTableToList(dal.GetListByflowSetCode(flowsetCode).Tables[0]);
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
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
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
        public int GetRecordCount(CommonService.Model.OA.O_FlowSet_AuditPerson model)
        {
            return 0;
            //return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByPage(CommonService.Model.OA.O_FlowSet_AuditPerson model, string orderby, int startIndex, int endIndex)
        {
            return null;
            //return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 根据所属流程GUID获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByflowCode(Guid flowCode)
        {
            return DataTableToList(dal.GetListByflowCode(flowCode).Tables[0]);
        }
        /// <summary>
        /// 根据所属流程GUID获得流程审批人数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetApplyListByflowCode(Guid flowCode)
        {
            return DataTableToList(dal.GetApplyListByflowCode(flowCode).Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
