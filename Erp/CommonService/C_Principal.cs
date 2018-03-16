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
    public class C_Principal : IC_Principal
    {
        CommonService.BLL.C_Principal oBLL = new CommonService.BLL.C_Principal();
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
        public bool Exists(CommonService.Model.C_Principal model)
        {
            return oBLL.Exists(model);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByPrincipalName(string C_Customer_name, int C_Customer_businessType)
        {
            return oBLL.ExistsByPrincipalName(C_Customer_name, C_Customer_businessType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Principal model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Principal model)
        {
            return oBLL.Update(model);
        }

       

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Principal_code)
        {
            return oBLL.Delete(C_Principal_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Customer_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Principal Get(Guid C_Principal_code)
        {
            return oBLL.GetModel(C_Principal_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Principal> GetAllList()
        {
            return oBLL.GetAllList();
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Principal model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Principal> GetListByPage(CommonService.Model.C_Principal model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
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
       


        public bool ExistsByPrincipalNameAndCode(string C_Customer_name, Guid C_Customer_code, int C_Customer_businessType)
        {
            return oBLL.ExistsByPrincipalNameAndCode(C_Customer_name, C_Customer_code, C_Customer_businessType);
        }


        /// <summary>
        /// 委托联系人
        /// </summary>
        /// <param name="principalCode"></param>
        /// <returns></returns>

        public List<Model.C_Contacts> GetContactsListByPrincipalCode(Guid principalCode)
        {
            return contactsBLL.GetListByCustomerCode(principalCode);
        }


       
    }
}
