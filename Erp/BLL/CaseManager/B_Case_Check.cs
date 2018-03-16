using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using CommonService.Common;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件结案审核表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/12/24
    /// </summary>
	public partial class B_Case_Check
	{
        private readonly CommonService.DAL.CaseManager.B_Case_Check dal = new CommonService.DAL.CaseManager.B_Case_Check();
        private readonly CommonService.DAL.CaseManager.B_Case_Confirm caseConfirmDal = new CommonService.DAL.CaseManager.B_Case_Confirm();
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        private readonly CommonService.DAL.FlowManager.P_Business_flow businessFlowDAL = new CommonService.DAL.FlowManager.P_Business_flow();
        private readonly CommonService.BLL.FlowManager.P_Business_flow businessFlowBLL = new CommonService.BLL.FlowManager.P_Business_flow();
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form businessFlowFormBLL = new CommonService.BLL.FlowManager.P_Business_flow_form();
        private readonly CommonService.DAL.CaseManager.B_Case caseDAL = new CommonService.DAL.CaseManager.B_Case();
		public B_Case_Check()
		{}
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
		public bool Exists(int B_Case_Check_id)
		{
			return dal.Exists(B_Case_Check_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Check model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_Check model)
		{
            bool isSuccess = false;
            isSuccess = dal.Update(model);

            CommonService.Model.CaseManager.B_Case_Confirm caseConfirm = caseConfirmDal.GetModel(model.B_Case_Confirm_code.Value);
            List<CommonService.Model.CaseManager.B_Case_Check> caseCheckList = GetListByConfirmCode(model.B_Case_Confirm_code.Value);
            //如果状态为"未通过"，则重新提交结案，并给结案阶段负责人和之前的审核人发送消息，
            if (model.B_Case_Check_State == Convert.ToInt32(EndCaseCheckStateEnum.未通过))
            {
                //修改关联案件确认信息状态为"未通过"
                caseConfirm.B_Case_Confirm_checkState = Convert.ToInt32(CaseConfirmStateEnum.未通过);
                caseConfirmDal.Update(caseConfirm);

                #region 给前面的审核人发送"审核未通过"消息
                foreach (CommonService.Model.CaseManager.B_Case_Check check in caseCheckList)
                {
                    if(check.B_Case_Check_order<model.B_Case_Check_order)
                    {
                        CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.结案确认审核未通过);
                        message.C_Messages_link = caseConfirm.B_Case_code;
                        message.C_Messages_createTime = DateTime.Now;
                        message.C_Messages_person = check.B_Case_Check_checkPerson;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }
                #endregion

                #region 处理相关案件审核信息
                foreach (CommonService.Model.CaseManager.B_Case_Check item in caseCheckList)
                {
                    item.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.未通过);
                    dal.Update(model);
                }
                #endregion

                #region 给结案阶段负责人发送消息，重新提交结案
                CommonService.Model.C_Messages messageModel = new CommonService.Model.C_Messages();
                messageModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                messageModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.结案确认审核未通过);
                messageModel.C_Messages_link = caseConfirm.B_Case_code;
                messageModel.C_Messages_createTime = DateTime.Now;
                messageModel.C_Messages_person = caseConfirm.B_Case_Confirm_creator;
                messageModel.C_Messages_isRead = 0;
                messageModel.C_Messages_content = "";
                messageModel.C_Messages_isValidate = 1;

                messageDAL.Add(messageModel);
                #endregion
            }
            else if(model.B_Case_Check_State==Convert.ToInt32(EndCaseCheckStateEnum.已通过))
            {//给下一个审核人发送消息
                CommonService.Model.CaseManager.B_Case_Check caseCheck = dal.GetModelByConfirmAndOrder(model.B_Case_Confirm_code.Value);
                if(caseCheck!=null)
                {
                    caseCheck.B_Case_Check_State = Convert.ToInt32(EndCaseCheckStateEnum.已开始);
                    dal.Update(caseCheck);

                    #region 发送消息
                    if (caseCheck.B_Case_Check_checkPerson != null)
                    {
                        CommonService.Model.C_Messages messageModel = new CommonService.Model.C_Messages();
                        messageModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        messageModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.结案确认审核);
                        messageModel.C_Messages_link = caseConfirm.B_Case_code;
                        messageModel.C_Messages_createTime = DateTime.Now;
                        messageModel.C_Messages_person = caseCheck.B_Case_Check_checkPerson;
                        messageModel.C_Messages_isRead = 0;
                        messageModel.C_Messages_content = "";
                        messageModel.C_Messages_isValidate = 1;

                        messageDAL.Add(messageModel);
                    }
                    #endregion
                }
                else
                {//表示全部审核通过，
                    //修改关联案件确认信息状态为"未通过"
                    caseConfirm.B_Case_Confirm_checkState = Convert.ToInt32(CaseConfirmStateEnum.已通过);
                    caseConfirmDal.Update(caseConfirm);
                    //将结案流程的状态改为已结束
                    CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(caseConfirm.P_Business_Flow_code.Value);
                    businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    businessFlow.P_Business_flow_factEndTime = DateTime.Now;
                    businessFlowDAL.Update(businessFlow);
                    //根据业务流程"实际结束时间"更新关联条目统计信息时间值
                    businessFlowDAL.UpdateEntryStatisticsByBusinessFlowTime(businessFlow.P_Business_flow_code.Value, "factEndTime", DateTime.Now);

                    //发送队列消息
                    MSMQ.SendMessage();

                    #region 案件下所有的业务流程及表单全部结束
                    List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList = businessFlowBLL.GetListByFkCode(caseConfirm.B_Case_code.Value);
                    foreach(CommonService.Model.FlowManager.P_Business_flow businessFlowItem in businessFlowList)
                    {//结束业务流程
                        if (businessFlowItem.P_Business_flow_code == businessFlow.P_Business_flow_code)
                            continue;
                        businessFlowItem.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        businessFlowDAL.Update(businessFlowItem);
                        //根据业务流程"实际结束时间"更新关联条目统计信息时间值
                        businessFlowDAL.UpdateEntryStatisticsByBusinessFlowTime(businessFlowItem.P_Business_flow_code.Value, "factEndTime", DateTime.Now);
                        //发送队列消息
                        MSMQ.SendMessage();

                        List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowFormList = businessFlowFormBLL.GetBusinessFlowForms(businessFlowItem.P_Business_flow_code.Value);
                        foreach(CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowFormList)
                        {//结束表单
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                            businessFlowFormBLL.Update(businessFlowForm);
                        }
                    }
                    #endregion

                    //将案件的状态改为已结束
                    CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(caseConfirm.B_Case_code.Value);
                    bcase.B_Case_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    bcase.B_Case_factEndTime = DateTime.Now;
                    caseDAL.Update(bcase);

                    #region 给结案阶段负责人发送消息
                    CommonService.Model.C_Messages messageModel = new CommonService.Model.C_Messages();
                    messageModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    messageModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.结案确认审核通过);
                    messageModel.C_Messages_link = caseConfirm.B_Case_code;
                    messageModel.C_Messages_createTime = DateTime.Now;
                    messageModel.C_Messages_person = caseConfirm.B_Case_Confirm_creator;
                    messageModel.C_Messages_isRead = 0;
                    messageModel.C_Messages_content = "";
                    messageModel.C_Messages_isValidate = 1;

                    messageDAL.Add(messageModel);
                    #endregion

                    #region 给所有审核确认人员发送'审核通过'消息
                    foreach(CommonService.Model.CaseManager.B_Case_Check item in caseCheckList)
                    {
                        if (item.B_Case_Check_checkPerson != model.B_Case_Check_checkPerson)
                        {
                            CommonService.Model.C_Messages messageItem = new CommonService.Model.C_Messages();
                            messageItem.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            messageItem.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.结案确认审核通过);
                            messageItem.C_Messages_link = caseConfirm.B_Case_code;
                            messageItem.C_Messages_createTime = DateTime.Now;
                            messageItem.C_Messages_person = item.B_Case_Check_checkPerson;
                            messageItem.C_Messages_isRead = 0;
                            messageItem.C_Messages_content = "";
                            messageItem.C_Messages_isValidate = 1;

                            messageDAL.Add(messageItem);
                        }
                    }
                    #endregion
                }
            }
            return isSuccess;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_Case_Check_id)
		{
			
			return dal.Delete(B_Case_Check_id);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_Check_code)
        {

            return dal.Delete(B_Case_Check_code);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_Case_Check_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_Case_Check_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_Case_Check GetModel(int B_Case_Check_id)
		{
			
			return dal.GetModel(B_Case_Check_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Check GetModel(Guid B_Case_Check_code)
        {

            return dal.GetModel(B_Case_Check_code);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CaseManager.B_Case_Check GetModelByCache(int B_Case_Check_id)
		{
			
			string CacheKey = "B_Case_CheckModel-" + B_Case_Check_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_Case_Check_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CaseManager.B_Case_Check)objModel;
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Check> GetListByConfirmCode(Guid B_Case_Confirm_code)
        {
            DataSet ds = dal.GetListByConfirmCode(B_Case_Confirm_code);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Check> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Check> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CaseManager.B_Case_Check> modelList = new List<CommonService.Model.CaseManager.B_Case_Check>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CaseManager.B_Case_Check model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

