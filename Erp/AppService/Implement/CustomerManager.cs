using CommonService.Model.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService
{
    public class CustomerManager:ICustomerManager
    {        
        private readonly CommonService.BLL.OA.O_Schedule bll = new CommonService.BLL.OA.O_Schedule();
        private readonly CommonService.BLL.C_Customer customerBLL = new CommonService.BLL.C_Customer();
        private readonly CommonService.BLL.OA.O_Schedule_user osuBLL = new CommonService.BLL.OA.O_Schedule_user();
        private readonly CommonService.BLL.C_AppBugLog bugBLL = new CommonService.BLL.C_AppBugLog();
        private readonly CommonService.BLL.C_PRival prBLL = new CommonService.BLL.C_PRival();
        private readonly CommonService.BLL.C_CRival crBLL = new CommonService.BLL.C_CRival();
        private readonly CommonService.BLL.C_Customer_Follow customerFollowBLL = new CommonService.BLL.C_Customer_Follow();
        private readonly CommonService.BLL.C_Contacts contactBLL = new CommonService.BLL.C_Contacts();
        

        #region App专用 查询我的行程

        /// <summary>
        /// 通过主用户GUID获取日程
        /// </summary>
        /// <param name="userCode">主用户GUID</param>
        /// <returns>日程列表</returns>
        public List<CommonService.Model.OA.O_Schedule> AppGetSchedule(string userCode)
        {
            return bll.GetListByRootUserCode(Guid.Parse(userCode));
        }

        /// <summary>
        /// 通过GUID获取日程
        /// </summary>
        /// <param name="userCode">GUID</param>
        /// <returns>日程</returns>
        public CommonService.Model.OA.O_Schedule GetScheduleByCode(string SchCode)
        {
            return bll.GetModel(Guid.Parse(SchCode));
        }

        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <returns>是否成功</returns>
        public int AppAddSchedule(CommonService.Model.OA.O_Schedule model, List<CommonService.Model.OA.O_Schedule_user> lst)
        {
            return bll.Add(model,lst);
        }

        /// <summary>
        /// 更新日程
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <param name="lst">人员列表</param>
        /// <returns>是否成功</returns>
        public int AppUpdateSchedule(CommonService.Model.OA.O_Schedule model, List<CommonService.Model.OA.O_Schedule_user> lst)
        {
            return bll.Update(model, lst);
        }

        /// <summary>
        /// 根据用户GUID和日期获取日程
        /// </summary>
        /// <param name="userCode">用户GUID</param>
        /// <param name="dt">日期</param>
        /// <returns>日程列表</returns>
        public List<CommonService.Model.OA.O_Schedule> GetListByDateAndUser(string userCode, string dt)
        {
            return bll.GetListByDateAndUser(new Guid(userCode), Convert.ToDateTime(dt));
        }

        /// <summary>
        /// 根据日程GUID获取该日程关联所有用户
        /// </summary>
        /// <param name="guid">日程GUID</param>
        /// <returns>用户日程关联列表</returns>
        public List<CommonService.Model.OA.O_Schedule_user> GetUserListByScheduleCode(string guid)
        {
            return osuBLL.GetScheduleUsersByScheduleCode(Guid.Parse(guid));
        }


        /// <summary>
        /// 获取日程列表（未读在上）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Schedule> GetListByUserAndMessages(string userCode, string startIndex, string endIndex)
        {
            return bll.GetListByUserAndMessages(Guid.Parse(userCode), Convert.ToInt32(startIndex), Convert.ToInt32(endIndex));
        }

        /// <summary>
        /// 新增Bug记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddAppBugLog(CommonService.Model.C_AppBugLog model)
        {
            return bugBLL.Add(model);
        }
        #endregion
        #region App专用 客户

        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <param name="model">客户实体条件</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns>客户列表</returns>
        public List<CommonService.Model.C_Customer> GetCustomerList(CommonService.Model.C_Customer model, int startIndex, int endIndex, C_Userinfo user, int type)
        {
            return customerBLL.AppGetListByPage(model, "", startIndex, endIndex, false, user.C_Userinfo_roleID, user.C_Userinfo_code, user.C_Userinfo_post, user.C_Userinfo_Organization,type);
        }

        /// <summary>
        /// 获取客户跟踪数据
        /// </summary>
        /// <param name="model">客户跟踪实体条件</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Customer_Follow> GetFollowUpsByCustCode(CommonService.Model.C_Customer_Follow model, int startIndex, int endIndex)
        {
            List<CommonService.Model.C_Customer_Follow> customerFollowUps = customerFollowBLL.GetListByPage(model, "", startIndex, endIndex);
            return customerFollowUps;
        }

        /// <summary>
        /// 获取客户联系人数据
        /// </summary>
        /// <param name="model">客户联系人实体条件</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <returns></returns>    
        public List<CommonService.Model.C_Contacts> GetContactsByCustCode(CommonService.Model.C_Contacts model, int startIndex, int endIndex)
        {
            List<CommonService.Model.C_Contacts> contacts = contactBLL.GetListByPage(model, "", startIndex, endIndex);
            return contacts;
        }

        public CommonService.Model.C_Customer GetCustomer(string guid)
        {
            return customerBLL.GetModel(Guid.Parse(guid));
        }

        public CommonService.Model.C_PRival GetPerson(string guid)
        {
            return prBLL.GetModel(Guid.Parse(guid));
        }

        public CommonService.Model.C_CRival GetCompany(string guid)
        {
            return crBLL.GetModel(Guid.Parse(guid));
        }


        /// <summary>
        /// 获取客户总数
        /// </summary>
        /// <param name="model">客户实体条件</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="userCode">用户GUID</param>
        /// <param name="postCode">岗位GUID</param>
        /// <param name="deptCode">部门GUID</param>
        /// <returns></returns>
        public int GetCustomerCount(CommonService.Model.C_Customer model,C_Userinfo user)
        {
            return customerBLL.GetCustomerListCount(model, false, user.C_Userinfo_code, user.C_Userinfo_post, user.C_Userinfo_Organization);
        }

        /// <summary>
        /// 根据客户跟踪Id，获取客户跟踪实体
        /// </summary>
        /// <param name="customerFollowId">客户跟踪Id</param>
        /// <returns></returns>     
        public CommonService.Model.C_Customer_Follow GetCustomerFollow(string customerFollowId)
        {
            return customerFollowBLL.GetModel(int.Parse(customerFollowId));
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model">客户实体</param>
        /// <returns>是否成功</returns>
        public int AddCustomer(CommonService.Model.C_Customer model)
        {
            return customerBLL.Add(model);
        }

        /// <summary>
        /// 操作客户联系人
        /// </summary>
        /// <param name="model">客户联系人实体</param>
        /// <returns>是否成功</returns>
        public int OperateCustomerContact(CommonService.Model.C_Contacts model)
        {
            return contactBLL.OperateCustomerContact(model);
        }

        /// <summary>
        /// 根据联系人Guid，获取联系人实体
        /// </summary>
        /// <param name="contactCode">联系人Code</param>
        /// <returns></returns>       
        public CommonService.Model.C_Contacts GetCustomerContact(string contactCode)
        {
            return contactBLL.GetModel(new Guid(contactCode));
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="guid">客户GUID</param>
        /// <returns>0 不成功 1 成功 2 该客户的添加日期不是当天 3 未知错误</returns>
        public int DeleteCustomer(string guid)
        {
            return customerBLL.DeleteCustomer(Guid.Parse(guid));
        }

        /// <summary>
        /// 删除客户联系人
        /// </summary>
        /// <param name="customerCode">客户GUID</param>
        /// <param name="contactCode">联系人GUID</param>
        /// <returns>0 删除失败， 1 删除成功， 2 该联系人有客户跟进，不可以删除</returns>       
        public int DeleteCustomerContact(string customerCode, string contactCode)
        {
            return contactBLL.DeleteCustomerContact(Guid.Parse(customerCode), Guid.Parse(contactCode));
        }

        /// <summary>
        /// 删除客户跟踪
        /// </summary>     
        /// <param name="customerFollowId">客户跟踪ID</param>
        /// <returns>0 删除失败， 1 删除成功</returns>    
        public int DeleteCustomerFollow(string customerFollowId)
        {
            bool deleteStatus = customerFollowBLL.Delete(int.Parse(customerFollowId));
            if (deleteStatus)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 保存客户跟踪
        /// </summary>
        /// <param name="model">客户跟踪实体</param>
        /// <returns>返回1代表，成功；0代表失败</returns>     
        public int SaveCustomerFollow(CommonService.Model.C_Customer_Follow model)
        {
            return customerFollowBLL.OperateCustomerFollow(model);
        }

        #endregion



      
    }
}