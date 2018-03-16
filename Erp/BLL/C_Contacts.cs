using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// 联系人表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Contacts
    {
        private readonly CommonService.DAL.C_Contacts dal = new CommonService.DAL.C_Contacts();
        /// <summary>
        /// 客户--联系人关系数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Customer_Contacts customerContactDal = new CommonService.DAL.C_Customer_Contacts();
        private readonly CommonService.DAL.C_Judge judgeDal = new CommonService.DAL.C_Judge();
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance_link businessChanceLinkDal = new DAL.BusinessChanceManager.B_BusinessChance_link();
        /// <summary>
        /// 客户跟进数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Customer_Follow customerFollowDAL = new CommonService.DAL.C_Customer_Follow();
        public C_Contacts()
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
        public bool Exists(int C_Contacts_id)
        {
            return dal.Exists(C_Contacts_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Contacts model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 操作客户联系人数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int OperateCustomerContact(CommonService.Model.C_Contacts contact)
        {
            int contactId = 0;
            if (contact.C_Contacts_id > 0)
            {//修改联系人
                bool isUpdateSuccess = dal.Update(contact);
                if (isUpdateSuccess)
                {
                    contactId = contact.C_Contacts_id;
                }
            }
            else
            {//添加联系人
                contactId = dal.Add(contact);
                if (contactId > 0)
                {//添加联系人--客户关系
                    CommonService.Model.C_Customer_Contacts customerContact = new CommonService.Model.C_Customer_Contacts();
                    customerContact.C_Customer_Contacts_contact = contact.C_Contacts_code;
                    customerContact.C_Customer_Contacts_customer = contact.C_Contacts_relationCode;
                    customerContact.C_Customer_Contacts_creator = contact._c_contacts_creator;
                    customerContact.C_Customer_Contacts_createTime = DateTime.Now;
                    customerContact.C_Customer_Contacts_isDelete = false;

                    customerContactDal.Add(customerContact);
                }
            }
            return contactId;
        }

        /// <summary>
        /// 删除客户联系人
        /// </summary>
        /// <param name="customerCode">客户GUID</param>
        /// <param name="customerCode">联系人GUID</param>
        /// <returns>0 删除失败， 1 删除成功， 2 该联系人有客户跟进，不可以删除</returns>       
        public int DeleteCustomerContact(Guid customerCode, Guid contactCode)
        {
            int deleteStatus = 0;

            /*
             * author:hety
             * date:2016-02-26
             * description:如果此客户联系人，已关联了正常的客户跟进，则不可以删除
             * 
             * */

            if (customerFollowDAL.Exists(customerCode, contactCode))
            {
                deleteStatus = 2;
                return deleteStatus;
            }

            //删除联系人
            bool isDeleteSuccess = dal.Delete(contactCode);
            //删除客户联系人关系
            if (isDeleteSuccess)
            {
                deleteStatus = 1;
                customerContactDal.Delete(customerCode, contactCode);
            }

            return deleteStatus;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Contacts model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Contacts_code, Guid relationCode, int ContactType)
        {
            if (ContactType == 2)
            {//客户联系人删除(只删除客户关联联系人信息表)
                return customerContactDal.Delete(relationCode,C_Contacts_code);
            }
            else if (ContactType == 4)
            {//法官联系人删除
                return judgeDal.Delete(C_Contacts_code);
            }else if(ContactType == 6)
            {//商机联系人删除
                return businessChanceLinkDal.Delete(relationCode,C_Contacts_code);
            }
            else
            {//默认联系人删除(只删除联系人信息表)
                return dal.Delete(C_Contacts_code);
            }            
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Contacts_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Contacts_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Contacts GetModel(int C_Contacts_id)
        {

            return dal.GetModel(C_Contacts_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Contacts GetModel(Guid C_Contacts_code)
        {

            return dal.GetModel(C_Contacts_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Contacts GetModelByCache(int C_Contacts_id)
        {

            string CacheKey = "C_ContactsModel-" + C_Contacts_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Contacts_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Contacts)objModel;
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
        public List<CommonService.Model.C_Contacts> GetModelList()
        {
            DataSet ds = dal.GetList();
            return DataTableToList(ds.Tables[0]);
        }
          /// <summary>
        /// 客户联系人
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Contacts> GetListByCustomerCode(Guid customerCode)
        {
            return DataTableToList(dal.GetListByCustomerCode(customerCode).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Contacts> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Contacts> modelList = new List<CommonService.Model.C_Contacts>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Contacts model;
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
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.C_Contacts> GetListByRelationAndType(CommonService.Model.C_Contacts model)
        {
            return DataTableToList(dal.GetListByRelationAndType(model).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.C_Contacts model)
        {
            return dal.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Contacts> GetListByPage(Model.C_Contacts model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
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
