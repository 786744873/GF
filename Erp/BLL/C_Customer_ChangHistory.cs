using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Maticsoft.Common;
using Maticsoft.Model;
using CommonService.Common;
using System.Text;
namespace CommonService.BLL
{
    /// <summary>
    /// 客户变更记录表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/11/24
    /// </summary>
	public partial class C_Customer_ChangHistory
	{
        private readonly CommonService.DAL.C_Customer_ChangHistory dal = new CommonService.DAL.C_Customer_ChangHistory();
        private readonly CommonService.DAL.C_Messages messageDal = new CommonService.DAL.C_Messages();
        private readonly CommonService.DAL.C_Customer customerDal = new CommonService.DAL.C_Customer();
        private readonly CommonService.BLL.C_Parameters parametersBll = new CommonService.BLL.C_Parameters();
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power rolepowerbll = new SysManager.C_Role_Role_Power();
        private readonly CommonService.BLL.SysManager.C_Organization organizationbll = new SysManager.C_Organization();
        private readonly CommonService.BLL.SysManager.C_Userinfo_region userregDal = new BLL.SysManager.C_Userinfo_region();
        private readonly CommonService.BLL.SysManager.C_Userinfo userDal = new BLL.SysManager.C_Userinfo();
        private readonly CommonService.BLL.BusinessChanceManager.B_BusinessChance businessChanceBll = new CommonService.BLL.BusinessChanceManager.B_BusinessChance();
        private readonly CommonService.BLL.BusinessChanceManager.B_BusinessChance_link businessChanceLinkBll = new CommonService.BLL.BusinessChanceManager.B_BusinessChance_link();
        private readonly CommonService.BLL.C_Customer_Region cusRegBll = new BLL.C_Customer_Region();
		public C_Customer_ChangHistory()
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
		public bool Exists(int C_Customer_ChangHistory_id)
		{
			return dal.Exists(C_Customer_ChangHistory_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Customer_ChangHistory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Customer_ChangHistory model)
		{
			return dal.Update(model);
		}

         /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="customerChangeHistoryList"></param>
        /// <returns></returns>
        public bool OpreateList(List<CommonService.Model.C_Customer_ChangHistory> customerChangeHistoryList)
        {
            foreach (CommonService.Model.C_Customer_ChangHistory customerChangHistory in customerChangeHistoryList)
            {
                dal.Add(customerChangHistory);
            }
            return true;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid C_Customer_ChangHistory_code)
		{

            return dal.Delete(C_Customer_ChangHistory_code);
		}
         /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="CustomerChangHistoryCode">变更Guid</param>
        /// <param name="stateId">审核状态</param>
        /// <returns></returns>
        public bool CheckOpreate(string CustomerChangHistoryCode, Guid CustomerChangHistoryCheckPerson, int? stateId)
        {
            bool isSuccess = false;
            string[] CustomerChangHistoryCodes = CustomerChangHistoryCode.Split(',');
            foreach(string item in CustomerChangHistoryCodes)
            {
                isSuccess = dal.CheckOpreate(new Guid(item), stateId);
                CommonService.Model.C_Customer_ChangHistory customerChangHistory = dal.GetModelByCode(new Guid(item));                

                if (isSuccess)
                {
                    //审核人赋值
                    customerChangHistory.C_Customer_ChangHistory_checkPerson = CustomerChangHistoryCheckPerson;
                    customerChangHistory.C_Customer_ChangHistory_checkDate = DateTime.Now;
                    dal.Update(customerChangHistory);

                    #region 给提交人发送消息
                    int? ftype = null;
                    int? type = null;
                    if(customerChangHistory.C_Customer_ChangHistory_type==Convert.ToInt32(ChangHistoryTypeEnum.客户))
                    {
                        ftype = Convert.ToInt32(MessageBigTypeEnum.客户);
                        type = stateId == Convert.ToInt32(CustomerChangHistoryStateEnum.已通过) ? Convert.ToInt32(MessageTinyTypeEnum.客户变更通过) : Convert.ToInt32(MessageTinyTypeEnum.客户变更驳回);
                    }
                    else if (customerChangHistory.C_Customer_ChangHistory_type == Convert.ToInt32(ChangHistoryTypeEnum.商机))
                    {
                        ftype = Convert.ToInt32(MessageBigTypeEnum.商机);
                        type = stateId == Convert.ToInt32(CustomerChangHistoryStateEnum.已通过) ? Convert.ToInt32(MessageTinyTypeEnum.商机变更通过) : Convert.ToInt32(MessageTinyTypeEnum.商机变更驳回);
                    }
                    CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                    message.C_Messages_fType = ftype;
                    message.C_Messages_type = type;
                    message.C_Messages_link = customerChangHistory.C_Customer_ChangHistory_customer;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = customerChangHistory.C_Customer_ChangHistory_submitPerson;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDal.Add(message);
                    #endregion

                    //审核通过-
                    if (stateId == Convert.ToInt32(CustomerChangHistoryStateEnum.已通过))
                    {
                        saveChangHistory(customerChangHistory);
                    }
                }
            }

            return isSuccess;
        }
        /// <summary>
        /// 保存变更信息
        /// </summary>
        /// <param name="customerChangHistory"></param>
        private void saveChangHistory(CommonService.Model.C_Customer_ChangHistory customerChangHistory)
        {
            if(customerChangHistory.C_Customer_ChangHistory_type == Convert.ToInt32(ChangHistoryTypeEnum.客户))
            {
                #region 修改客户信息
                CommonService.Model.C_Customer customer = customerDal.GetModel(customerChangHistory.C_Customer_ChangHistory_customer.Value);
                switch (customerChangHistory.C_Customer_ChangHistory_field)
                {
                    case "C_Customer_name":
                        customer.C_Customer_name = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_type":
                        customer.C_Customer_type = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_Category":
                        customer.C_Customer_Category = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_State":
                        customer.C_Customer_State = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_industryCode":
                        customer.C_Customer_industryCode = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_yearTurnover":
                        customer.C_Customer_yearTurnover = Convert.ToDecimal(customerChangHistory.C_Customer_ChangHistory_newValue);
                        break;
                    case "C_Customer_companySize":
                        customer.C_Customer_companySize = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_source":
                        customer.C_Customer_source = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_level":
                        customer.C_Customer_level = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_tel":
                        customer.C_Customer_tel = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_fax":
                        customer.C_Customer_fax = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_shortName":
                        customer.C_Customer_shortName = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_email":
                        customer.C_Customer_email = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_mainContactPhone":
                        customer.C_Customer_mainContactPhone = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_isSignedState":
                        customer.C_Customer_isSignedState = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_address":
                        customer.C_Customer_address = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_signedState":
                        customer.C_Customer_signedState = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_consultant"://专业顾问
                        customer.C_Customer_consultant = new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        //根据专业顾问修改客户关联区域
                        CommonService.Model.SysManager.C_Userinfo userinfoChilds = userDal.GetModelByUserCode(new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification));
                        CommonService.Model.SysManager.C_Userinfo_region userinfoRegion = userregDal.GetModelByUserinfoCode(userinfoChilds.C_Userinfo_code.Value);
                        if (userinfoRegion != null)
                        {
                            CommonService.Model.C_Customer_Region customerRegion = new CommonService.Model.C_Customer_Region();
                            customerRegion.C_Customer_Region_customer = customer.C_Customer_code.Value;
                            customerRegion.C_Customer_Region_relRegion = userinfoRegion.C_Region_code.Value;
                            customerRegion.C_Customer_Region_isDelete = 0;
                            customerRegion.C_Customer_Region_creator = customerChangHistory.C_Customer_ChangHistory_submitPerson;
                            customerRegion.C_Customer_Region_createTime = customerChangHistory.C_Customer_ChangHistory_submitDate;

                            cusRegBll.DeleteByCustomerCode(customer.C_Customer_code.Value);
                            cusRegBll.Add(customerRegion);
                        }
                        break;
                    case "C_Customer_contacter":
                        customer.C_Customer_contacter = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_website":
                        customer.C_Customer_website = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_lastContactDate":
                        customer.C_Customer_lastContactDate = Convert.ToDateTime(customerChangHistory.C_Customer_ChangHistory_newValue);
                        break;
                    case "C_Customer_responsibleDept":
                        customer.C_Customer_responsibleDept = new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_value":
                        customer.C_Customer_value = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                    case "C_Customer_loyalty":
                        customer.C_Customer_loyalty = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification);
                        break;
                    case "C_Customer_remark":
                        customer.C_Customer_remark = customerChangHistory.C_Customer_ChangHistory_newValue;
                        break;
                }

                customerDal.Update(customer);
                #endregion
            }else if(customerChangHistory.C_Customer_ChangHistory_type == Convert.ToInt32(ChangHistoryTypeEnum.商机))
            {
                #region 修改商机信息
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceBll.GetModel(customerChangHistory.C_Customer_ChangHistory_customer.Value);
                List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> BusinessChanceLinks = new List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link>();
                switch (customerChangHistory.C_Customer_ChangHistory_field)
                {
                    case "B_BusinessChance_name": businessChance.B_BusinessChance_name = customerChangHistory.C_Customer_ChangHistory_newValue; break;
                    case "B_BusinessChance_type": businessChance.B_BusinessChance_type = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_customerType": businessChance.B_BusinessChance_customerType = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_registerTime": businessChance.B_BusinessChance_registerTime = Convert.ToDateTime(customerChangHistory.C_Customer_ChangHistory_newValue); break;
                    case "B_BusinessChance_expectedTarget": businessChance.B_BusinessChance_expectedTarget = Convert.ToDecimal(customerChangHistory.C_Customer_ChangHistory_newValue); break;
                    case "B_BusinessChance_successProbability": businessChance.B_BusinessChance_successProbability = customerChangHistory.C_Customer_ChangHistory_newValue; break;
                    case "B_BusinessChance_obtainTime": businessChance.B_BusinessChance_obtainTime = Convert.ToDateTime(customerChangHistory.C_Customer_ChangHistory_newValue); break;
                    case "B_BusinessChance_Case_nature": businessChance.B_BusinessChance_Case_nature = Convert.ToInt32(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_courtFirst": businessChance.B_BusinessChance_courtFirst = new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_courtSecond": businessChance.B_BusinessChance_courtSecond = new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_courtExec": businessChance.B_BusinessChance_courtExec = new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_transferTargetMoney": businessChance.B_BusinessChance_transferTargetMoney = Convert.ToDecimal(customerChangHistory.C_Customer_ChangHistory_newValue); break;
                    case "B_BusinessChance_transferTargetOther": businessChance.B_BusinessChance_transferTargetOther = customerChangHistory.C_Customer_ChangHistory_newValue; break;
                    case "B_BusinessChance_expectedGrant": businessChance.B_BusinessChance_expectedGrant = Convert.ToDecimal(customerChangHistory.C_Customer_ChangHistory_newValue); break;
                    case "B_BusinessChance_execMoney": businessChance.B_BusinessChance_execMoney = Convert.ToDecimal(customerChangHistory.C_Customer_ChangHistory_newValue); break;
                    case "B_BusinessChance_execOther": businessChance.B_BusinessChance_execOther = customerChangHistory.C_Customer_ChangHistory_newValue; break;
                    case "B_BusinessChance_Outline": businessChance.B_BusinessChance_Outline = customerChangHistory.C_Customer_ChangHistory_newValue; break;
                    case "B_BusinessChance_remark": businessChance.B_BusinessChance_remark = customerChangHistory.C_Customer_ChangHistory_newValue; break;
                    case "B_BusinessChance_Competitor": businessChance.B_BusinessChance_Competitor = new Guid(customerChangHistory.C_Customer_ChangHistory_newLdentification); break;
                    case "B_BusinessChance_Customer_code":
                        string[] customerCodes = customerChangHistory.C_Customer_ChangHistory_newLdentification.Split(',');
                        foreach (var customer_code in customerCodes)
                        {
                            CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChancelink = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                            businessChancelink.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                            businessChancelink.C_FK_code = new Guid(customer_code);
                            businessChancelink.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.客户);
                            businessChancelink.B_BusinessChance_link_creator = customerChangHistory.C_Customer_ChangHistory_creator;
                            businessChancelink.B_BusinessChance_link_createTime = DateTime.Now;
                            businessChancelink.B_BusinessChance_link_isDelete = 0;

                            BusinessChanceLinks.Add(businessChancelink);
                        }
                        break;
                    case "B_BusinessChance_Project_code":
                        string[] projectCodes = customerChangHistory.C_Customer_ChangHistory_newLdentification.Split(',');
                        foreach (var project_code in projectCodes)
                        {
                            CommonService.Model.BusinessChanceManager.B_BusinessChance_link project = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                            project.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                            project.C_FK_code = new Guid(project_code);
                            project.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.工程);
                            project.B_BusinessChance_link_creator = customerChangHistory.C_Customer_ChangHistory_creator;
                            project.B_BusinessChance_link_createTime = DateTime.Now;
                            project.B_BusinessChance_link_isDelete = 0;

                            BusinessChanceLinks.Add(project);
                        }
                        break;
                    case "B_BusinessChance_Region_code":
                        string[] regionCodes = customerChangHistory.C_Customer_ChangHistory_newLdentification.Split(',');
                        foreach (var region_code in regionCodes)
                        {
                            CommonService.Model.BusinessChanceManager.B_BusinessChance_link region = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                            region.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                            region.C_FK_code = new Guid(region_code);
                            region.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.区域);
                            region.B_BusinessChance_link_creator = customerChangHistory.C_Customer_ChangHistory_creator;
                            region.B_BusinessChance_link_createTime = DateTime.Now;
                            region.B_BusinessChance_link_isDelete = 0;

                            BusinessChanceLinks.Add(region);
                        }
                        break;
                    case "B_BusinessChance_Client_code":
                        string[] clientCodes = customerChangHistory.C_Customer_ChangHistory_newLdentification.Split(',');
                        foreach (var client_code in clientCodes)
                        {
                            CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChancelink = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                            businessChancelink.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                            businessChancelink.C_FK_code = new Guid(client_code);
                            businessChancelink.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.委托人);
                            businessChancelink.B_BusinessChance_link_creator = customerChangHistory.C_Customer_ChangHistory_creator;
                            businessChancelink.B_BusinessChance_link_createTime = DateTime.Now;
                            businessChancelink.B_BusinessChance_link_isDelete = 0;
                            BusinessChanceLinks.Add(businessChancelink);
                        }
                        break;
                    case "B_BusinessChance_Person_code":
                        string[] newLdentification = customerChangHistory.C_Customer_ChangHistory_newLdentification.Split('+');
                        string[] partyCodes = newLdentification[0].Split(',');
                        string[] partyType = newLdentification[1].Split(',');
                        int i = 0;
                        if (partyCodes[0] != "")
                        {
                            foreach (var party_code in partyCodes)
                            {
                                CommonService.Model.BusinessChanceManager.B_BusinessChance_link thisPerson = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                                thisPerson.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                                thisPerson.C_FK_code = new Guid(party_code);
                                thisPerson.B_BusinessChance_link_type = Convert.ToInt32(partyType[i]);
                                thisPerson.B_BusinessChance_link_creator = customerChangHistory.C_Customer_ChangHistory_creator;
                                thisPerson.B_BusinessChance_link_createTime = DateTime.Now;
                                thisPerson.B_BusinessChance_link_isDelete = 0;
                                BusinessChanceLinks.Add(thisPerson);
                                i++;
                            }
                        }
                        break;
                }
                businessChanceBll.Update(businessChance);
                if(BusinessChanceLinks.Count() > 0)
                {
                    businessChanceLinkBll.OperateList(BusinessChanceLinks);
                }
                #endregion
            }
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Customer_ChangHistory_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Customer_ChangHistory_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Customer_ChangHistory GetModel(int C_Customer_ChangHistory_id)
		{
			
			return dal.GetModel(C_Customer_ChangHistory_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Customer_ChangHistory GetModelByCode(Guid C_Customer_ChangHistory_code)
        {

            return dal.GetModelByCode(C_Customer_ChangHistory_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Customer_ChangHistory GetModelByCache(int C_Customer_ChangHistory_id)
		{
			
			string CacheKey = "C_Customer_ChangHistoryModel-" + C_Customer_ChangHistory_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Customer_ChangHistory_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Customer_ChangHistory)objModel;
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
        public List<CommonService.Model.C_Customer_ChangHistory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Customer_ChangHistory> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Customer_ChangHistory> modelList = new List<CommonService.Model.C_Customer_ChangHistory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Customer_ChangHistory model;
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
        /// 根据客户Guid获得数据列表
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Customer_ChangHistory> GetListByCustomer(Guid customerCode)
        {
            return DataTableToList(dal.GetListByCustomer(customerCode).Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(CommonService.Model.C_Customer_ChangHistory model)
		{
            return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.C_Customer_ChangHistory> GetListByPage(CommonService.Model.C_Customer_ChangHistory model, string orderby, int startIndex, int endIndex)
		{
			return DataTableToList(dal.GetListByPage( model,  orderby,  startIndex,  endIndex).Tables[0]);
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

