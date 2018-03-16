using CommonService.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件结案确认表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/09/22
    /// </summary>
    public partial class B_Case_Confirm
    {
        private readonly CommonService.DAL.CaseManager.B_Case_Confirm dal = new CommonService.DAL.CaseManager.B_Case_Confirm();
        private readonly CommonService.BLL.C_Parameters parametersBLL = new CommonService.BLL.C_Parameters();
        private readonly CommonService.DAL.CaseManager.B_Case_Check caseCheckDAL = new CommonService.DAL.CaseManager.B_Case_Check();
        /// <summary>
        /// 案件数据访问层
        /// </summary>
        private readonly CommonService.DAL.CaseManager.B_Case caseDAL = new CommonService.DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.CaseManager.B_Case_link caseLinkDAL = new CommonService.DAL.CaseManager.B_Case_link();
        private readonly CommonService.DAL.SysManager.C_Userinfo userinfoDAL = new CommonService.DAL.SysManager.C_Userinfo();
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();

        public B_Case_Confirm()
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
        public bool Exists(int B_Case_Confirm_id)
        {
            return dal.Exists(B_Case_Confirm_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Confirm model)
        {
            int caseConfirmId = 0;
            caseConfirmId = dal.Add(model);

            CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(model.B_Case_code.Value);//关联案件
            List<CommonService.Model.CaseManager.B_Case_link> caseLinkList = caseLinkDAL.GetRegionListByCasecode(model.B_Case_code.Value);//案件所在区域
            //List<CommonService.Model.SysManager.C_Userinfo> userinfoList = userinfoBLL.GetListByRegionCode(caseLinkList.FirstOrDefault().C_FK_code.Value);//区域下的人员

            #region 添加结案审核信息
            List<CommonService.Model.C_Parameters> parameterList = parametersBLL.GetChildrenByParentId(Convert.ToInt32(EndCaseEnum.结案审核意见类型));
            foreach (CommonService.Model.C_Parameters parameter in parameterList)
            {
                CommonService.Model.CaseManager.B_Case_Check caseCheck = new Model.CaseManager.B_Case_Check();
                caseCheck.B_Case_Check_code = Guid.NewGuid();
                caseCheck.B_Case_Confirm_code = model.B_Case_Confirm_code;
                switch(parameter.C_Parameters_name)
                {
                    case "部长意见":
                        caseCheck.B_Case_Check_Type = Convert.ToInt32(EndCaseSuggestTypeEnum.部长意见);
                        caseCheck.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.已开始);
                        if (bcase.B_Case_person!=null)
                            caseCheck.B_Case_Check_checkPerson = bcase.B_Case_person;
                        caseCheck.B_Case_Check_order = 1;
                        break;
                    case "首席意见":
                        caseCheck.B_Case_Check_Type = Convert.ToInt32(EndCaseSuggestTypeEnum.首席意见);
                        caseCheck.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.未开始);
                        if (bcase.B_Case_firstClassResponsiblePerson!=null)
                            caseCheck.B_Case_Check_checkPerson = bcase.B_Case_firstClassResponsiblePerson;
                        caseCheck.B_Case_Check_order = 2;
                        break;
                    case "行政意见":
                        CommonService.Model.SysManager.C_Userinfo userinfo = userinfoDAL.GetModelByRegionAndRole(caseLinkList.FirstOrDefault().C_FK_code.Value, 1028);//1028：行政
                        caseCheck.B_Case_Check_Type = Convert.ToInt32(EndCaseSuggestTypeEnum.行政意见);
                        caseCheck.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.未开始);
                        if (userinfo != null)
                            caseCheck.B_Case_Check_checkPerson = userinfo.C_Userinfo_code;
                        caseCheck.B_Case_Check_order = 3;
                        break;
                    case "财务意见":
                        CommonService.Model.SysManager.C_Userinfo userinfoFinance = userinfoDAL.GetModelByRegionAndRole(caseLinkList.FirstOrDefault().C_FK_code.Value, 15);//15：财务会计
                        caseCheck.B_Case_Check_Type = Convert.ToInt32(EndCaseSuggestTypeEnum.财务意见);
                        caseCheck.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.未开始);
                        if (userinfoFinance != null)
                            caseCheck.B_Case_Check_checkPerson = userinfoFinance.C_Userinfo_code;
                        caseCheck.B_Case_Check_order = 4;
                        break;
                    case "人资意见":
                        CommonService.Model.SysManager.C_Userinfo userinfoHR = userinfoDAL.GetModelByRegionAndRole(caseLinkList.FirstOrDefault().C_FK_code.Value, 16);//16：人力资源
                        caseCheck.B_Case_Check_Type = Convert.ToInt32(EndCaseSuggestTypeEnum.人资意见);
                        caseCheck.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.未开始);
                        if (userinfoHR != null)
                            caseCheck.B_Case_Check_checkPerson = userinfoHR.C_Userinfo_code;
                        caseCheck.B_Case_Check_order = 5;
                        break;
                }
                caseCheck.B_Case_Check_creator = model.B_Case_Confirm_creator;
                caseCheck.B_Case_Check_createTime = model.B_Case_Confirm_createTime;
                caseCheck.B_Case_Check_isDelete = false;

                caseCheckDAL.Add(caseCheck);
            }
            #endregion

            #region 给部长发送结案确认审核消息
            if (bcase.B_Case_person!=null)
            {
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.结案确认审核);
                message.C_Messages_link = bcase.B_Case_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = bcase.B_Case_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            return caseConfirmId;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_Confirm model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_Confirm_code)
        {
            return dal.Delete(B_Case_Confirm_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_Confirm_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_Case_Confirm_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Confirm GetModel(Guid B_Case_Confirm_code)
        {
            return dal.GetModel(B_Case_Confirm_code);
        }
          /// <summary>
        /// 当前用户是否有“确认结案”按钮权限
        /// </summary>
        /// <param name="B_Case_code">案件Guid</param>
        /// <param name="personCode">当前用户Guid</param>
        /// <returns></returns>
        public CommonService.Model.CaseManager.B_Case_Confirm GetModelByCaseAndPerson(Guid B_Case_code, Guid personCode)
        {
            return dal.GetModelByCaseAndPerson(B_Case_code,personCode);
        }

          /// <summary>
        /// 根据案件Guid和业务流程Guid得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Confirm GetModelByCaseAndBusinessFlow(Guid B_Case_code, Guid P_Business_Flow_code)
        {
            return dal.GetModelByCaseAndBusinessFlow(B_Case_code, P_Business_Flow_code);
        }

        /// <summary>
        /// 根据案件Guid和业务流程Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case_Confirm> GetListByCaseAndBusinessFlow(Guid caseCode, Guid businessFlowCode)
        {
            DataSet ds = dal.GetListByCaseAndBusinessFlow(caseCode, businessFlowCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据案件Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public List<Model.CaseManager.B_Case_Confirm> GetListByCaseCode(Guid caseCode)
        {
            DataSet ds = dal.GetListByCaseCode(caseCode);
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
        public List<CommonService.Model.CaseManager.B_Case_Confirm> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Confirm> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_Case_Confirm> modelList = new List<CommonService.Model.CaseManager.B_Case_Confirm>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case_Confirm model;
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
 
    }

}
