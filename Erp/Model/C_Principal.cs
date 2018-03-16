using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// C_Principal:实体类(委托人)
    /// </summary>
    [Serializable]
    public partial class C_Principal
    {
        public C_Principal()
        { }
        #region Model
        private int _c_principal_id;
        private Guid? _c_principal_code;
        private string _c_principal_number;
        private int? _c_principal_type;
        private int? _c_principal_level;
        private string _c_principal_name;
        private string _c_principal_shortname;
        private int? _c_principal_region;
        private int? _c_principal_province;
        private int? _c_principal_city;
        private int? _c_principal_industrycode;
        private decimal? _c_principal_yearturnover;
        private int? _c_principal_issignedstate;
        private string _c_principal_companysize;
        private int? _c_principal_source;
        private int? _c_principal_signedstate;
        private string _c_principal_tel;
        private string _c_principal_phone;
        private string _c_principal_fax;
        private string _c_principal_email;
        private string _c_principal_website;
        private string _c_principal_contacter;
        private string _c_principal_maincontactphone;
        private string _c_principal_value;
        private string _c_principal_address;
        private Guid _c_principal_reguser;
        private DateTime? _c_principal_regdate;
        private int? _c_principal_loyalty;
        private DateTime? _c_principal_lastcontactdate;
        private int? _c_principal_businesstype;
        private Guid? _c_principal_consultant;
        private Guid? _c_principal_responsibledept;
        private bool _c_principal_isdelete;
        private Guid? _c_principal_creator;
        private DateTime? _c_principal_createtime;
        private string _c_principal_Region_code;
        private string _c_principal_responsibledept_name;
        private Guid? _c_principal_relcode;
        private string _c_principal_remark;
        private int? _c_principal_reldatatype;

        /// <summary>
        /// 关联数据类型(虚拟属性)(1代表客户关联委托人，2代表委托人关联客户,3代表多客户关联多委托人)
        /// </summary>
        public int? C_Principal_reldatatype
        {
            set { _c_principal_reldatatype = value; }
            get { return _c_principal_reldatatype; }
        }
        public string C_principal_remark
        {
            get { return _c_principal_remark; }
            set { _c_principal_remark = value; }
        }

        /// <summary>
        /// 虚拟字段委托人关联
        /// </summary>
        public Guid? C_principal_relCode
        {
            get { return _c_principal_relcode; }
            set { _c_principal_relcode = value; }
        }
        /// <summary>
        /// 委托人负责部门名（虚拟字段）
        /// </summary>
        public string C_principal_responsibledept_name
        {
            get { return _c_principal_responsibledept_name; }
            set { _c_principal_responsibledept_name = value; }
        }
        /// <summary>
        /// 委托人关联区域名称（虚拟字段）
        /// </summary> 
        private string _c_principal_Region_name;

        public string C_principal_Region_name
        {
            get { return _c_principal_Region_name; }
            set { _c_principal_Region_name = value; }
        }

        /// <summary>
        /// 销售顾问名称（虚拟字段）
        /// </summary>
        private string _c_principal_consultant_name;

        public string C_principal_consultant_name
        {
            get { return _c_principal_consultant_name; }
            set { _c_principal_consultant_name = value; }
        }

        /// <summary>
        /// 虚拟字段委托人关联区域GUID
        /// </summary>
        public string C_principal_Region_code
        {
            get { return _c_principal_Region_code; }
            set { _c_principal_Region_code = value; }
        }
        /// <summary>
        /// 委托人ID，主键，自增
        /// </summary>
        public int C_Principal_id
        {
            set { _c_principal_id = value; }
            get { return _c_principal_id; }
        }
        /// <summary>
        /// 委托人GUID
        /// </summary>
        public Guid? C_Principal_code
        {
            set { _c_principal_code = value; }
            get { return _c_principal_code; }
        }
        /// <summary>
        /// 委托人代码：CRM过来的用　CUST+5数字，如（00012）后台自动生成。如果本系统自建，用 CILT+5为数字。
        /// </summary>
        public string C_Principal_number
        {
            set { _c_principal_number = value; }
            get { return _c_principal_number; }
        }
        /// <summary>
        /// 委托人类型：0-单位1-个体户2-自然人
        /// </summary>
        public int? C_Principal_type
        {
            set { _c_principal_type = value; }
            get { return _c_principal_type; }
        }
        /// <summary>
        /// 委托人级别
        /// </summary>
        public int? C_Principal_level
        {
            set { _c_principal_level = value; }
            get { return _c_principal_level; }
        }
        /// <summary>
        /// 委托人名称
        /// </summary>
        public string C_Principal_name
        {
            set { _c_principal_name = value; }
            get { return _c_principal_name; }
        }
        /// <summary>
        /// 委托人简称
        /// </summary>
        public string C_Principal_shortName
        {
            set { _c_principal_shortname = value; }
            get { return _c_principal_shortname; }
        }
        /// <summary>
        /// 委托人区域
        /// </summary>
        public int? C_Principal_region
        {
            set { _c_principal_region = value; }
            get { return _c_principal_region; }
        }
        /// <summary>
        /// 委托人省份
        /// </summary>
        public int? C_Principal_province
        {
            set { _c_principal_province = value; }
            get { return _c_principal_province; }
        }
        /// <summary>
        /// 委托人城市
        /// </summary>
        public int? C_Principal_city
        {
            set { _c_principal_city = value; }
            get { return _c_principal_city; }
        }
        /// <summary>
        /// 行业代码：钢材、架管等，可选择
        /// </summary>
        public int? C_Principal_industryCode
        {
            set { _c_principal_industrycode = value; }
            get { return _c_principal_industrycode; }
        }
        /// <summary>
        /// 年营业额
        /// </summary>
        public decimal? C_Principal_yearTurnover
        {
            set { _c_principal_yearturnover = value; }
            get { return _c_principal_yearturnover; }
        }
        /// <summary>
        /// 是否签约状态：0-签约，1-未签约
        /// </summary>
        public int? C_Principal_isSignedState
        {
            set { _c_principal_issignedstate = value; }
            get { return _c_principal_issignedstate; }
        }
        /// <summary>
        /// 公司规模
        /// </summary>
        public string C_Principal_companySize
        {
            set { _c_principal_companysize = value; }
            get { return _c_principal_companysize; }
        }
        /// <summary>
        /// 委托人来源：老委托人推荐、等多种方式，可勾选
        /// </summary>
        public int? C_Principal_source
        {
            set { _c_principal_source = value; }
            get { return _c_principal_source; }
        }
        /// <summary>
        /// 签约委托人状态：正常、流失、死亡，可勾选
        /// </summary>
        public int? C_Principal_signedState
        {
            set { _c_principal_signedstate = value; }
            get { return _c_principal_signedstate; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string C_Principal_tel
        {
            set { _c_principal_tel = value; }
            get { return _c_principal_tel; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string C_Principal_phone
        {
            set { _c_principal_phone = value; }
            get { return _c_principal_phone; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string C_Principal_fax
        {
            set { _c_principal_fax = value; }
            get { return _c_principal_fax; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string C_Principal_email
        {
            set { _c_principal_email = value; }
            get { return _c_principal_email; }
        }
        /// <summary>
        /// 网站
        /// </summary>
        public string C_Principal_website
        {
            set { _c_principal_website = value; }
            get { return _c_principal_website; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string C_Principal_contacter
        {
            set { _c_principal_contacter = value; }
            get { return _c_principal_contacter; }
        }
        /// <summary>
        /// 主联系人手机号
        /// </summary>
        public string C_Principal_mainContactPhone
        {
            set { _c_principal_maincontactphone = value; }
            get { return _c_principal_maincontactphone; }
        }
        /// <summary>
        /// 委托人价值
        /// </summary>
        public string C_Principal_value
        {
            set { _c_principal_value = value; }
            get { return _c_principal_value; }
        }
        /// <summary>
        /// 营业地址
        /// </summary>
        public string C_Principal_address
        {
            set { _c_principal_address = value; }
            get { return _c_principal_address; }
        }
        /// <summary>
        /// 登记人
        /// </summary>
        public Guid C_Principal_reguser
        {
            set { _c_principal_reguser = value; }
            get { return _c_principal_reguser; }
        }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? C_Principal_regdate
        {
            set { _c_principal_regdate = value; }
            get { return _c_principal_regdate; }
        }
        /// <summary>
        /// 委托人忠诚度：高、中、低
        /// </summary>
        public int? C_Principal_loyalty
        {
            set { _c_principal_loyalty = value; }
            get { return _c_principal_loyalty; }
        }
        /// <summary>
        /// 最后接触日期
        /// </summary>
        public DateTime? C_Principal_lastContactDate
        {
            set { _c_principal_lastcontactdate = value; }
            get { return _c_principal_lastcontactdate; }
        }
        /// <summary>
        /// 0-委托人，1-客户,2-既是客户又是委托人
        /// </summary>
        public int? C_Principal_businessType
        {
            set { _c_principal_businesstype = value; }
            get { return _c_principal_businesstype; }
        }
        /// <summary>
        /// 开拓顾问
        /// </summary>
        public Guid? C_Principal_consultant
        {
            set { _c_principal_consultant = value; }
            get { return _c_principal_consultant; }
        }
        /// <summary>
        /// 负责部门
        /// </summary>
        public Guid? C_Principal_responsibleDept
        {
            set { _c_principal_responsibledept = value; }
            get { return _c_principal_responsibledept; }
        }
        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool C_Principal_isDelete
        {
            set { _c_principal_isdelete = value; }
            get { return _c_principal_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Principal_creator
        {
            set { _c_principal_creator = value; }
            get { return _c_principal_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Principal_createTime
        {
            set { _c_principal_createtime = value; }
            get { return _c_principal_createtime; }
        }
        #endregion Model

    }
}
