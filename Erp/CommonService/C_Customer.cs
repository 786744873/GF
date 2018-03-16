using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客服服务
    /// </summary>
    public class C_Customer : IC_Customer
    {
        CommonService.BLL.C_Customer oBLL = new CommonService.BLL.C_Customer();
        CommonService.BLL.C_Contacts contactsBLL = new CommonService.BLL.C_Contacts();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return oBLL.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(CommonService.Model.C_Customer model)
        {
            return oBLL.Exists(model);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByCustomerName(string C_Customer_name, int C_Customer_businessType)
        {
            return oBLL.ExistsByCustomerName(C_Customer_name, C_Customer_businessType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Customer model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 设置客户计划
        /// </summary>
        /// <param name="model">客户数据模型</param>
        /// <returns></returns>        
        public bool SetCustomerPlan(CommonService.Model.C_Customer model)
        {
            return oBLL.SetCustomerPlan(model);
        }

        /// <summary>
        /// 启动客户任务
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns></returns>       
        public bool StartTask(Guid customerCode, Guid startPersonCode)
        {
            return oBLL.StartTask(customerCode, startPersonCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Customer_code)
        {
            return oBLL.Delete(C_Customer_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Customer_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Customer Get(Guid C_Customer_code)
        {
            return oBLL.GetModel(C_Customer_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Customer> GetAllList()
        {
            return oBLL.GetAllList();
        }

        /// <summary>
        /// 获取客户总数
        /// </summary>
        public int GetCustomerListCount(Model.C_Customer model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return oBLL.GetCustomerListCount(model, IsPreSetManager, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取客户列表
        /// </summary>
        public List<Model.C_Customer> GetCustomerListByPage(Model.C_Customer model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return oBLL.GetCustomerListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, userCode, postCode, deptCode);
        }

        /// <summary>
        /// 客户联系人
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public List<Model.C_Contacts> GetContactsListByCustomerCode(Guid customerCode)
        {
            return contactsBLL.GetListByCustomerCode(customerCode);
        }
        /// <summary>
        /// 根据客户guid，来查看客户的部长和首席专家是否为空，如果为空则为部长和首席专家添加数据   ---cyj
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public void SetMinisterAndChiefResponsible(string customerCode,Guid? userOrgCode)
        {
            oBLL.SetMinisterAndChiefResponsible(customerCode, userOrgCode);
        }

        public int GetListByPageCount(string strWhere)
        {
            return oBLL.GetListByPageCount(strWhere);
        }

        public List<CommonService.Model.C_Customer> GetListByPageAll(string where, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPageAll(where, orderby, startIndex, endIndex);
        }


        public bool ExistsByCustomerNameAndCode(string C_Customer_name, Guid C_Customer_code, int C_Customer_businessType)
        {
            return oBLL.ExistsByCustomerNameAndCode(C_Customer_name, C_Customer_code, C_Customer_businessType);
        }
    }
}
