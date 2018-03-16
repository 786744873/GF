using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 客户联系人关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/04
    /// </summary>
    [Serializable]
    public partial class C_Customer_Contacts
    {
        public C_Customer_Contacts()
        { }
        #region Model
        private int _c_customer_contacts_id;
        private Guid? _c_customer_contacts_customer;
        private Guid? _c_customer_contacts_contact;
        private bool _c_customer_contacts_isdelete;
        private Guid? _c_customer_contacts_creator;
        private DateTime? _c_customer_contacts_createtime;
        /// <summary>
        /// 客户联系人关系自动增长Id
        /// </summary>
        public int C_Customer_Contacts_Id
        {
            set { _c_customer_contacts_id = value; }
            get { return _c_customer_contacts_id; }
        }
        /// <summary>
        /// 客户Guid
        /// </summary>
        public Guid? C_Customer_Contacts_customer
        {
            set { _c_customer_contacts_customer = value; }
            get { return _c_customer_contacts_customer; }
        }
        /// <summary>
        /// 联系人Guid
        /// </summary>
        public Guid? C_Customer_Contacts_contact
        {
            set { _c_customer_contacts_contact = value; }
            get { return _c_customer_contacts_contact; }
        }
        /// <summary>
        /// 是否删除(1为已删除，0为未删除)
        /// </summary>
        public bool C_Customer_Contacts_isDelete
        {
            set { _c_customer_contacts_isdelete = value; }
            get { return _c_customer_contacts_isdelete; }
        }
        /// <summary>
        /// 添加人Guid
        /// </summary>
        public Guid? C_Customer_Contacts_creator
        {
            set { _c_customer_contacts_creator = value; }
            get { return _c_customer_contacts_creator; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? C_Customer_Contacts_createTime
        {
            set { _c_customer_contacts_createtime = value; }
            get { return _c_customer_contacts_createtime; }
        }
        #endregion Model

    }
}
