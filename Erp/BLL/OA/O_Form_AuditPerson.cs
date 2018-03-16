using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// 表单审批人表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Form_AuditPerson
    {
        private readonly CommonService.DAL.OA.O_Form_AuditPerson dal = new DAL.OA.O_Form_AuditPerson();
        public O_Form_AuditPerson()
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
        public bool Exists(int O_Form_AuditPerson_id)
        {
            return dal.Exists(O_Form_AuditPerson_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Form_AuditPerson_code)
        {

            return dal.Delete(O_Form_AuditPerson_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Form_AuditPerson_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(O_Form_AuditPerson_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditPerson GetModel(Guid O_Form_AuditPerson_code)
        {

            return dal.GetModel(O_Form_AuditPerson_code);
        }
        /// <summary>
        /// 通过所属表单审批流程Guid,得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditPerson GetModelByFlowCode(Guid O_Form_AuditPerson_formAuditFlow)
        {
            return dal.GetModelByFlowCode(O_Form_AuditPerson_formAuditFlow);
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
        public List<CommonService.Model.OA.O_Form_AuditPerson> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过表单Guid，获取表单审批人集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Form_AuditPerson> GetFormAuditPersonsByFormCode(Guid formCode)
        {
            DataSet ds = dal.GetFormAuditPersonsByFormCode(formCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过表单审批流程Guid，获取表单审批人集合
        /// </summary>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Form_AuditPerson> GetFormAuditPersonsByFormAuditFlowCode(Guid formAuditFlowCode)
        {
            DataSet ds = dal.GetFormAuditPersonsByFormAuditFlowCode(formAuditFlowCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditPerson> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Form_AuditPerson> modelList = new List<CommonService.Model.OA.O_Form_AuditPerson>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Form_AuditPerson model;
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
        public int GetRecordCount(CommonService.Model.OA.O_Form_AuditPerson model)
        {
            return 0;
            //  return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditPerson> GetListByPage(CommonService.Model.OA.O_Form_AuditPerson model, string orderby, int startIndex, int endIndex)
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
