using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 客户委托人关系表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/06
    [Serializable]
    public partial class C_Customer_Customer
    {
        public C_Customer_Customer()
        { }
        #region Model
        private int _c_customer_customer_id;
        private Guid? _c_customer_customer_customer;
        private Guid? _c_customer_customer_relcustomer;
        private bool _c_customer_customer_isdelete;
        private Guid? _c_customer_customer_creator;
        private DateTime? _c_customer_customer_createtime;
        /// <summary>
        /// 客户委托人关系自动增长Id
        /// </summary>
        public int C_Customer_Customer_Id
        {
            set { _c_customer_customer_id = value; }
            get { return _c_customer_customer_id; }
        }
        /// <summary>
        /// 客户Guid
        /// </summary>
        public Guid? C_Customer_Customer_customer
        {
            set { _c_customer_customer_customer = value; }
            get { return _c_customer_customer_customer; }
        }
        /// <summary>
        /// 关联委托人Guid
        /// </summary>
        public Guid? C_Customer_Customer_relCustomer
        {
            set { _c_customer_customer_relcustomer = value; }
            get { return _c_customer_customer_relcustomer; }
        }
        /// <summary>
        /// 是否删除(1为已删除，0为未删除)
        /// </summary>
        public bool C_Customer_Customer_isDelete
        {
            set { _c_customer_customer_isdelete = value; }
            get { return _c_customer_customer_isdelete; }
        }
        /// <summary>
        /// 添加人Guid
        /// </summary>
        public Guid? C_Customer_Customer_creator
        {
            set { _c_customer_customer_creator = value; }
            get { return _c_customer_customer_creator; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? C_Customer_Customer_createTime
        {
            set { _c_customer_customer_createtime = value; }
            get { return _c_customer_customer_createtime; }
        }
        #endregion Model

    }
}
