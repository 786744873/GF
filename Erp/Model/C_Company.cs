using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 客户公司表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    [Serializable]
    public partial class C_Company
    {
        public C_Company()
        { }
        #region Model
        private int _c_company_id;
        private Guid? _c_company_code;
        private string _c_company_name;
        private Guid? _c_company_customer;
        private int? _c_company_property;
        private string _c_company_property_name;
        private string _c_company_legalperson;
        private DateTime? _c_company_establishmentdate;
        private decimal? _c_company_registeredcapital;
        private string _c_company_licensecode;
        private string _c_company_organizationcode;
        private string _c_company_taxcode;
        private string _c_company_address;
        private bool _c_company_isdefault;
        private bool _c_company_isdelete;
        private string _c_company_remark;
        private Guid? _c_company_creator;
        private DateTime? _c_company_createtime;
        /// <summary>
        /// 客户公司ID，主键，自增长
        /// </summary>
        public int C_Company_id
        {
            set { _c_company_id = value; }
            get { return _c_company_id; }
        }
        /// <summary>
        /// 客户公司编码GUID
        /// </summary>
        public Guid? C_Company_code
        {
            set { _c_company_code = value; }
            get { return _c_company_code; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string C_Company_name
        {
            set { _c_company_name = value; }
            get { return _c_company_name; }
        }
        /// <summary>
        /// 客户Id：关联客户表Guid字段
        /// </summary>
        public Guid? C_Company_customer
        {
            set { _c_company_customer = value; }
            get { return _c_company_customer; }
        }
        /// <summary>
        /// 公司性质：国有、民营、外企…
        /// </summary>
        public int? C_Company_property
        {
            set { _c_company_property = value; }
            get { return _c_company_property; }
        }
        /// <summary>
        /// 公司性质名称
        /// </summary>
        public string C_Company_property_name
        {
            set { _c_company_property_name = value; }
            get { return _c_company_property_name; }
        }

        /// <summary>
        /// 企业法人
        /// </summary>
        public string C_Company_legalPerson
        {
            set { _c_company_legalperson = value; }
            get { return _c_company_legalperson; }
        }
        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime? C_Company_establishmentDate
        {
            set { _c_company_establishmentdate = value; }
            get { return _c_company_establishmentdate; }
        }
        /// <summary>
        /// 注册资金
        /// </summary>
        public decimal? C_Company_registeredCapital
        {
            set { _c_company_registeredcapital = value; }
            get { return _c_company_registeredcapital; }
        }
        /// <summary>
        /// 营业执照注册号
        /// </summary>
        public string C_Company_licenseCode
        {
            set { _c_company_licensecode = value; }
            get { return _c_company_licensecode; }
        }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string C_Company_organizationCode
        {
            set { _c_company_organizationcode = value; }
            get { return _c_company_organizationcode; }
        }
        /// <summary>
        /// 纳税号
        /// </summary>
        public string C_Company_taxCode
        {
            set { _c_company_taxcode = value; }
            get { return _c_company_taxcode; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string C_Company_address
        {
            set { _c_company_address = value; }
            get { return _c_company_address; }
        }
        /// <summary>
        /// 是否默认：0 - 不默认、1 - 默认
        /// </summary>
        public bool C_Company_isDefault
        {
            set { _c_company_isdefault = value; }
            get { return _c_company_isdefault; }
        }
        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool C_Company_isDelete
        {
            set { _c_company_isdelete = value; }
            get { return _c_company_isdelete; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Company_remark
        {
            set { _c_company_remark = value; }
            get { return _c_company_remark; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Company_creator
        {
            set { _c_company_creator = value; }
            get { return _c_company_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Company_createTime
        {
            set { _c_company_createtime = value; }
            get { return _c_company_createtime; }
        }
        #endregion Model

    }
}
