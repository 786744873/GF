using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 客户银行表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    [Serializable]
    public partial class C_Bank
    {
        public C_Bank()
        { }
        #region Model
        private int _c_bank_id;
        private Guid? _c_bank_code;
        private Guid? _c_bank_customer;
        private string _c_bank_openbank;
        private string _c_bank_account;
        private string _c_bank_accountno;
        private bool _c_bank_isdefault;
        private bool _c_bank_isdelete;
        private string _c_bank_remark;
        private Guid? _c_bank_creator;
        private DateTime? _c_bank_createtime;
        /// <summary>
        /// 客户银行ID，主键，自增长
        /// </summary>
        public int C_Bank_id
        {
            set { _c_bank_id = value; }
            get { return _c_bank_id; }
        }
        /// <summary>
        /// 客户银行编码GUID
        /// </summary>
        public Guid? C_Bank_code
        {
            set { _c_bank_code = value; }
            get { return _c_bank_code; }
        }
        /// <summary>
        /// 客户Id：关联客户表Guid字段
        /// </summary>
        public Guid? C_Bank_customer
        {
            set { _c_bank_customer = value; }
            get { return _c_bank_customer; }
        }
        /// <summary>
        /// 开户行
        /// </summary>
        public string C_Bank_openBank
        {
            set { _c_bank_openbank = value; }
            get { return _c_bank_openbank; }
        }
        /// <summary>
        /// 账户
        /// </summary>
        public string C_Bank_account
        {
            set { _c_bank_account = value; }
            get { return _c_bank_account; }
        }
        /// <summary>
        /// 账户号
        /// </summary>
        public string C_Bank_accountNo
        {
            set { _c_bank_accountno = value; }
            get { return _c_bank_accountno; }
        }
        /// <summary>
        /// 是否默认：0 - 不默认、1 - 默认
        /// </summary>
        public bool C_Bank_isDefault
        {
            set { _c_bank_isdefault = value; }
            get { return _c_bank_isdefault; }
        }
        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool C_Bank_isDelete
        {
            set { _c_bank_isdelete = value; }
            get { return _c_bank_isdelete; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Bank_remark
        {
            set { _c_bank_remark = value; }
            get { return _c_bank_remark; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Bank_creator
        {
            set { _c_bank_creator = value; }
            get { return _c_bank_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Bank_createTime
        {
            set { _c_bank_createtime = value; }
            get { return _c_bank_createtime; }
        }
        #endregion Model

    }
}
