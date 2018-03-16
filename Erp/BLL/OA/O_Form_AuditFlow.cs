using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonService.Common;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// 表单审批流程表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Form_AuditFlow
    {
        private readonly CommonService.DAL.OA.O_Form_AuditFlow dal = new DAL.OA.O_Form_AuditFlow();
        /// <summary>
        /// 协同办公表单,数据访问层
        /// </summary>
        private readonly CommonService.DAL.OA.O_Form oFormDAL = new DAL.OA.O_Form();
        /// <summary>
        /// 表单审批人,数据访问层
        /// </summary>
        private readonly CommonService.DAL.OA.O_Form_AuditPerson formAuditPersonDAL = new DAL.OA.O_Form_AuditPerson();
        /// <summary>
        /// 表单审批人,业务访问层
        /// </summary>
        private CommonService.BLL.OA.O_Form_AuditPerson formAuditPersonBLL = new CommonService.BLL.OA.O_Form_AuditPerson();
        public O_Form_AuditFlow()
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
        /// 根据表单Guid，获取表单审批流程最大顺序号
        /// </summary>
        /// <param name="oFormCode">表单Guid</param>
        /// <returns></returns>
        public int GetMaxOrder(Guid oFormCode)
        {
            return dal.GetMaxOrder(oFormCode);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Form_AuditFlow_id)
        {
            return dal.Exists(O_Form_AuditFlow_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Form_AuditFlow_code)
        {

            return dal.Delete(O_Form_AuditFlow_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Form_AuditFlow_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(O_Form_AuditFlow_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditFlow GetModel(Guid O_Form_AuditFlow_code)
        {

            return dal.GetModel(O_Form_AuditFlow_code);
        }
        /// <summary>
        /// 得到一个顺序最大的对象实体
        /// </summary>
        public int GetMaxOrderModel(Guid O_Form_AuditFlow_code)
        {
            return dal.GetMaxOrderModel(O_Form_AuditFlow_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 通过表单guid获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListByFormCode(Guid formCode)
        {
            return DataTableToList(dal.GetListByFormCode(formCode).Tables[0]);
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
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过表单Guid，获取表单审批流程集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetFormAuditFlowsByFormCode(Guid formCode)
        {
            DataSet ds = dal.GetFormAuditFlowsByFormCode(formCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 非自由流程驳回审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="userCode">子用户Guid</param>
        /// <param name="auditContent">审批内容</param>
        /// <returns></returns>
        public bool NotFreeFlowRejectCheck(Guid oFormCode, Guid formAuditFlowCode, Guid userCode, string auditContent)
        {
            /*
             * author:hety
             * date:2015-08-11
             * description:非自由流程驳回审核
             * (1)、改变表单状态为"未通过"
             * (2)、改变表单审批流程状态为"未通过"
             * (3)、改变对应表单审批人状态为"已驳回"
             **/
            bool isSuccess = false;
            //处理(1)
            isSuccess = oFormDAL.UpdateState(oFormCode, Convert.ToInt32(FormApplyTypeEnum.未通过));
            //处理(2)
            DateTime now = DateTime.Now;
            dal.UpdateStateAndTime(formAuditFlowCode, Convert.ToInt32(FormAuditTypeEnum.未通过), now);
            //处理(3)
            List<CommonService.Model.OA.O_Form_AuditPerson> FormAuditPersons = formAuditPersonBLL.GetFormAuditPersonsByFormAuditFlowCode(formAuditFlowCode);
            foreach (CommonService.Model.OA.O_Form_AuditPerson auditPerson in FormAuditPersons)
            {
                if (auditPerson.O_Form_AuditPerson_auditPerson == userCode)
                {//更改自己的审批内容
                    auditPerson.O_Form_AuditPerson_auditTime = now;
                    auditPerson.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已驳回);
                    auditPerson.O_Form_AuditPerson_content = auditContent;

                    formAuditPersonDAL.Update(auditPerson);
                    break;
                }
            }

            return isSuccess;
        }

        /// <summary>
        /// 非自由流程通过审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="userCode">子用户Guid</param>
        /// <param name="auditContent">审批内容</param>
        /// <param name="notShowFormAuditFlowCodes">不满足规则的表单审批流程Guid串</param>
        /// <returns></returns>
        public int NotFreeFlowPassCheck(Guid oFormCode, Guid formAuditFlowCode, Guid userCode, string auditContent, string notShowFormAuditFlowCodes)
        {
            /*
             * author:hety
             * date:2015-08-11
             * description:非自由流程通过审核
             * (1)、改变对应表单审批人状态为"已通过"
             * (2)、如果当前表单审批流程所关联的审批人全部审核通过(并且||或者)，则对应表单审批流程也为未通过
             * (3)、如果当前表单所有审批流程均为已"通过"，则此表单状态也为"已通过";
             **/
            bool flagPer = false;//审批仅仅自己的审批为通过
            bool flagFlow = false;//审批当前流程为通过
            bool flagForm = false;//审批表单为通过
            bool isSuccess = false;
            DateTime now = DateTime.Now;
            CommonService.Model.OA.O_Form_AuditFlow formAuditFlow = dal.GetModel(formAuditFlowCode);
            List<CommonService.Model.OA.O_Form_AuditPerson> FormAuditPersons = formAuditPersonBLL.GetFormAuditPersonsByFormAuditFlowCode(formAuditFlowCode);

            #region 处理(1)
            foreach (CommonService.Model.OA.O_Form_AuditPerson auditPerson in FormAuditPersons)
            {
                if (auditPerson.O_Form_AuditPerson_auditPerson == userCode)
                {//更改自己的审批内容
                    auditPerson.O_Form_AuditPerson_auditTime = now;
                    auditPerson.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已通过);
                    auditPerson.O_Form_AuditPerson_content = auditContent;
                    isSuccess = formAuditPersonDAL.Update(auditPerson);
                    flagPer = true;//审批自己的改为通过
                    break;
                }
            }
            #endregion

            #region 处理(2)
            bool isAllPassAudit = true;//当前表单审批流程关联审批人是否已全部通过了审批
            if (formAuditFlow.O_Form_AuditFlow_flowSet_auditType == Convert.ToInt32(AuditTypeEnum.或者))
            {//"或者"时，只要有一个审批人审批通过，则对应表单审批流程为"已通过"
                dal.UpdateStateAndTime(formAuditFlowCode, Convert.ToInt32(FormAuditTypeEnum.已通过), now);
                flagFlow = true;//当前流程的为通过
            }
            else if (formAuditFlow.O_Form_AuditFlow_flowSet_auditType == Convert.ToInt32(AuditTypeEnum.并且))
            {//"并且"时，必须所有审批人审批通过时，对应表单审批流程状态才为"已通过"，否则为"已开始"               
                foreach (CommonService.Model.OA.O_Form_AuditPerson auditPerson in FormAuditPersons)
                {
                    if (auditPerson.O_Form_AuditPerson_status != Convert.ToInt32(FormApprovalTypeEnum.已通过))
                    {
                        isAllPassAudit = false;
                        break;
                    }
                }
                if (isAllPassAudit)
                {
                    dal.UpdateStateAndTime(formAuditFlowCode, Convert.ToInt32(FormAuditTypeEnum.已通过), now);
                    flagFlow = true;//当前流程的为通过
                }
                else
                {
                    dal.UpdateStateAndTime(formAuditFlowCode, Convert.ToInt32(FormAuditTypeEnum.已开始), now);
                }
            }

            #endregion

            #region 处理(3)
            bool iaAllowChangeFormStatus = true;//是否允许改变表单状态
            if (isAllPassAudit)
            {
                List<CommonService.Model.OA.O_Form_AuditFlow> FormAuditFlows = GetFormAuditFlowsByFormCode(oFormCode);
                if (!String.IsNullOrEmpty(notShowFormAuditFlowCodes))
                {
                    notShowFormAuditFlowCodes = "," + notShowFormAuditFlowCodes + ",";
                }
                foreach (CommonService.Model.OA.O_Form_AuditFlow formAuditFlowItem in FormAuditFlows)
                {
                    if (notShowFormAuditFlowCodes.Contains("," + formAuditFlowItem.O_Form_AuditFlow_code.Value.ToString() + ","))
                        continue;
                    if (formAuditFlowItem.O_Form_AuditFlow_auditStatus != Convert.ToInt32(FormAuditTypeEnum.已通过))
                    {
                        iaAllowChangeFormStatus = false;
                        break;
                    }
                }
            }
            else
            {
                iaAllowChangeFormStatus = false;
            }
            if (iaAllowChangeFormStatus)
            {
                oFormDAL.UpdateState(oFormCode, Convert.ToInt32(FormApplyTypeEnum.已通过));
                flagForm = true;
            }
            #endregion

            #region  根据审核类型返回对应的值
            int type = 0;//审核失败
            if (isSuccess)
            {
                if (flagForm)
                { //表单审核通过返回 1
                    type = 1;
                }
                else if ((!flagForm) && flagFlow)
                { //只有当前流程为通过  返回 2
                    type = 2;
                }
                else if ((!flagForm) && (!flagFlow) && flagPer)
                {//值审核了当前流程的自己审核的 返回 3
                    type = 3;
                }
            }
            #endregion
            return type;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Form_AuditFlow> modelList = new List<CommonService.Model.OA.O_Form_AuditFlow>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Form_AuditFlow model;
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
        public int GetRecordCount(CommonService.Model.OA.O_Form_AuditFlow model)
        {
            return 0;
            //return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListByPage(CommonService.Model.OA.O_Form_AuditFlow model, string orderby, int startIndex, int endIndex)
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
        /// 通过审核人guid获得未审核的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListStatusByuserCode(Guid userCode)
        {
            return DataTableToList(dal.GetListStatusByuserCode(userCode).Tables[0]);
        }
        /// <summary>
        /// 通过流程预设guid获得数据信息
        /// </summary>
        public CommonService.Model.OA.O_Form_AuditFlow GetModelByAuditFlowcode(Guid flowCode, int type)
        {
            return dal.GetModelByAuditFlowcode(flowCode, type);
        }
        /// <summary>
        /// 通过流程预设guid和表单guid和流程顺序获得数据列表获得数据信息
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetModelByAuditFlowcodeAndformCodeAndOrder(int type, Guid formCode, int order)
        {
            return DataTableToList(dal.GetModelByAuditFlowcodeAndformCodeAndOrder(type, formCode, order).Tables[0]);
        }
        /// <summary>
        /// 通过审核人guid获得未审核的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditFlow> GetListByuserCode(Guid userCode)
        {
            return DataTableToList(dal.GetListByuserCode(userCode).Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
