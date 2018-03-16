using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 客户表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/04/28
    public partial class C_Customer
    {
        public C_Customer()
        { }
        #region Model
        public int _c_customer_id;
        public Guid? _c_customer_code;
        public string _c_customer_number;
        public int? _c_customer_type;
        public int? _c_customer_level;
        public string _c_customer_name;
        public string _c_customer_shortname;
        public int? _c_customer_province;
        public int? _c_customer_city;
        public int? _c_customer_industrycode;
        public decimal? _c_customer_yearturnover;
        public int? _c_customer_issignedstate;
        public string _c_customer_companysize;
        public int? _c_customer_source;
        public int? _c_customer_signedstate;
        public string _c_customer_tel;
        public string _c_customer_phone;
        public string _c_customer_fax;
        public string _c_customer_email;
        public string _c_customer_website;
        public string _c_customer_contacter;
        public string _c_customer_maincontactphone;
        public string _c_customer_value;
        public string _c_customer_address;
        public Guid? _c_customer_reguser;
        public DateTime? _c_customer_regdate;
        public int? _c_customer_loyalty;
        public DateTime? _c_customer_lastcontactdate;
        public int? _c_customer_businesstype;
        public Guid? _c_customer_consultant;
        public Guid? _c_customer_responsibledept;
        public string _c_customer_responsibledept_name;
        public int? _c_customer_goingstatus;
        public string _c_customer_goingstatusName;
        public Guid? _c_customer_responsibleperson;
        public Guid? _c_customer_chiefresponsibleperson;
        public DateTime? _c_customer_planstarttime;
        public DateTime? _c_customer_planendtime;
        public DateTime? _c_customer_factstarttime;
        public DateTime? _c_customer_factendtime;
        public bool _c_customer_isdelete;
        public string _c_customer_remark;
        public Guid? _c_customer_creator;
        public DateTime? _c_customer_createtime;
        public int? _c_customer_Category;
        public int? _c_customer_State;
        public DateTime? _c_customer_Follow_time;//虚拟字段
        public int? _c_customer_Follow_time_type;
        public string _c_customer_Region;
        public Guid? _c_customer_Open;//虚拟字段
        public string _c_customer_industrycode_name;//客户行业名称（虚拟字段）
        /// <summary>
        /// 关联Guid字符串(虚拟属性)
        /// </summary>
        public string _c_customer_relcodes;
        /// <summary>
        /// 关联数据类型(虚拟属性)
        /// </summary>
        public int? _c_customer_reldatatype;
        /// <summary>
        /// 关联Guid(虚拟属性)
        /// </summary>
        public Guid? _c_customer_relcode;
        /// <summary>
        /// 客户关联区域GUID（虚拟字段）
        /// </summary>
        public string _c_customer_Region_code;
        /// <summary>
        /// 客户关联区域名称（虚拟字段）
        /// </summary> 
        public string _c_customer_Region_name;
        /// <summary>
        /// 销售顾问名称（虚拟字段）
        /// </summary>
        public string _c_customer_consultant_name;
        /// <summary>
        /// 最后接触时间2(虚拟字段)
        /// </summary>
        public DateTime? _c_customer_lastcontactEnddate;
        /// <summary>
        /// 客户跟进日期 
        /// </summary> 
        public DateTime? C_Customer_Follow_time
        {
            set { _c_customer_Follow_time = value; }
            get { return _c_customer_Follow_time; }
        }
        /// <summary>
        /// 客户跟进查询类型
        /// </summary>
        public int? C_Customer_Follow_time_type
        {
            set { _c_customer_Follow_time_type = value; }
            get { return _c_customer_Follow_time_type; }
        }
        /// <summary>
        /// 客户ID，主键，自增长
        /// </summary>
        public int C_Customer_id
        {
            set { _c_customer_id = value; }
            get { return _c_customer_id; }
        }
        /// <summary>
        /// 客户编码GUID
        /// </summary>
        public Guid? C_Customer_code
        {
            set { _c_customer_code = value; }
            get { return _c_customer_code; }
        }
        /// <summary>
        /// 客户代码：CRM过来的用　CUST+5数字，如（00012）后台自动生成。如果本系统自建，用 CILT+5为数字。
        /// </summary>
        public string C_Customer_number
        {
            set { _c_customer_number = value; }
            get { return _c_customer_number; }
        }
        /// <summary>
        /// 客户类型
        /// </summary>
        public int? C_Customer_type
        {
            set { _c_customer_type = value; }
            get { return _c_customer_type; }
        }
        /// <summary>
        /// 客户级别
        /// </summary>
        public int? C_Customer_level
        {
            set { _c_customer_level = value; }
            get { return _c_customer_level; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_Customer_name
        {
            set { _c_customer_name = value; }
            get { return _c_customer_name; }
        }
        /// <summary>
        /// 客户简称
        /// </summary>
        public string C_Customer_shortName
        {
            set { _c_customer_shortname = value; }
            get { return _c_customer_shortname; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public int? C_Customer_province
        {
            set { _c_customer_province = value; }
            get { return _c_customer_province; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public int? C_Customer_city
        {
            set { _c_customer_city = value; }
            get { return _c_customer_city; }
        }
        /// <summary>
        /// 行业代码：钢材、架管等，可选择
        /// </summary>
        public int? C_Customer_industryCode
        {
            set { _c_customer_industrycode = value; }
            get { return _c_customer_industrycode; }
        }
        /// <summary>
        /// (虚拟字段)行业代码名称：钢材、架管等，可选择
        /// </summary>
        public string C_Customer_industrycode_name
        {
            set { _c_customer_industrycode_name = value; }
            get { return _c_customer_industrycode_name; }
        }
        /// <summary>
        /// 年营业额
        /// </summary>
        public decimal? C_Customer_yearTurnover
        {
            set { _c_customer_yearturnover = value; }
            get { return _c_customer_yearturnover; }
        }
        /// <summary>
        /// 是否签约状态
        /// </summary>
        public int? C_Customer_isSignedState
        {
            set { _c_customer_issignedstate = value; }
            get { return _c_customer_issignedstate; }
        }
        /// <summary>
        /// 公司规模
        /// </summary>
        public string C_Customer_companySize
        {
            set { _c_customer_companysize = value; }
            get { return _c_customer_companysize; }
        }
        /// <summary>
        /// 客户来源：老客户推荐、等多种方式，可勾选
        /// </summary>
        public int? C_Customer_source
        {
            set { _c_customer_source = value; }
            get { return _c_customer_source; }
        }
        /// <summary>
        /// 签约客户状态：正常、流失、死亡，可勾选
        /// </summary>
        public int? C_Customer_signedState
        {
            set { _c_customer_signedstate = value; }
            get { return _c_customer_signedstate; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string C_Customer_tel
        {
            set { _c_customer_tel = value; }
            get { return _c_customer_tel; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string C_Customer_phone
        {
            set { _c_customer_phone = value; }
            get { return _c_customer_phone; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string C_Customer_fax
        {
            set { _c_customer_fax = value; }
            get { return _c_customer_fax; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string C_Customer_email
        {
            set { _c_customer_email = value; }
            get { return _c_customer_email; }
        }
        /// <summary>
        /// 公司网址
        /// </summary>
        public string C_Customer_website
        {
            set { _c_customer_website = value; }
            get { return _c_customer_website; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string C_Customer_contacter
        {
            set { _c_customer_contacter = value; }
            get { return _c_customer_contacter; }
        }
        /// <summary>
        /// 主联系人手机号
        /// </summary>
        public string C_Customer_mainContactPhone
        {
            set { _c_customer_maincontactphone = value; }
            get { return _c_customer_maincontactphone; }
        }
        /// <summary>
        /// 客户价值
        /// </summary>
        public string C_Customer_value
        {
            set { _c_customer_value = value; }
            get { return _c_customer_value; }
        }
        /// <summary>
        /// 营业地址
        /// </summary>
        public string C_Customer_address
        {
            set { _c_customer_address = value; }
            get { return _c_customer_address; }
        }
        /// <summary>
        /// 登记人
        /// </summary>
        public Guid? C_Customer_reguser
        {
            set { _c_customer_reguser = value; }
            get { return _c_customer_reguser; }
        }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? C_Customer_regdate
        {
            set { _c_customer_regdate = value; }
            get { return _c_customer_regdate; }
        }
        /// <summary>
        /// 客户忠诚度：高、中、低
        /// </summary>
        public int? C_Customer_loyalty
        {
            set { _c_customer_loyalty = value; }
            get { return _c_customer_loyalty; }
        }
        /// <summary>
        /// 最后接触日期
        /// </summary>
        public DateTime? C_Customer_lastContactDate
        {
            set { _c_customer_lastcontactdate = value; }
            get { return _c_customer_lastcontactdate; }
        }
        /// <summary>
        /// （虚拟字段）最后接触日期2
        /// </summary>
        public DateTime? C_Customer_lastContactEndDate
        {
            set { _c_customer_lastcontactEnddate = value; }
            get { return _c_customer_lastcontactEnddate; }
        }
        /// <summary>
        /// 客户业务类型枚举
        /// </summary>
        public int? C_Customer_businessType
        {
            set { _c_customer_businesstype = value; }
            get { return _c_customer_businesstype; }
        }
        /// <summary>
        /// 开拓顾问
        /// </summary>
        public Guid? C_Customer_consultant
        {
            set { _c_customer_consultant = value; }
            get { return _c_customer_consultant; }
        }
        /// <summary>
        /// 负责部门
        /// </summary>
        public Guid? C_Customer_responsibleDept
        {
            set { _c_customer_responsibledept = value; }
            get { return _c_customer_responsibledept; }
        }

        /// <summary>
        /// 负责部门名称(虚拟属性)
        /// </summary>
        public string C_Customer_responsibleDept_Name
        {
            set { _c_customer_responsibledept_name = value; }
            get { return _c_customer_responsibledept_name; }
        }
        /// <summary>
        /// 客户进行状态
        /// </summary>
        public int? C_Customer_goingStatus
        {
            set { _c_customer_goingstatus = value; }
            get { return _c_customer_goingstatus; }
        }
        /// <summary>
        /// 客户进行状态名称（虚拟字段）
        /// </summary>
        public string C_Customer_goingstatusName
        { 
            get { return _c_customer_goingstatusName; }
            set { _c_customer_goingstatusName = value; }
        }        
        /// <summary>
        /// 客户负责人
        /// </summary>
        public Guid? C_Customer_responsiblePerson
        {
            set { _c_customer_responsibleperson = value; }
            get { return _c_customer_responsibleperson; }
        }
        /// <summary>
        /// 客户首席负责人
        /// </summary>
        public Guid? C_Customer_chiefResponsiblePerson
        {
            set { _c_customer_chiefresponsibleperson = value; }
            get { return _c_customer_chiefresponsibleperson; }
        }
        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? C_Customer_planStartTime
        {
            set { _c_customer_planstarttime = value; }
            get { return _c_customer_planstarttime; }
        }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? C_Customer_planEndTime
        {
            set { _c_customer_planendtime = value; }
            get { return _c_customer_planendtime; }
        }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? C_Customer_factStartTime
        {
            set { _c_customer_factstarttime = value; }
            get { return _c_customer_factstarttime; }
        }
        /// <summary>
        /// 时间结束时间
        /// </summary>
        public DateTime? C_Customer_factEndTime
        {
            set { _c_customer_factendtime = value; }
            get { return _c_customer_factendtime; }
        }

        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool C_Customer_isDelete
        {
            set { _c_customer_isdelete = value; }
            get { return _c_customer_isdelete; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Customer_remark
        {
            set { _c_customer_remark = value; }
            get { return _c_customer_remark; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Customer_creator
        {
            set { _c_customer_creator = value; }
            get { return _c_customer_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Customer_createTime
        {
            set { _c_customer_createtime = value; }
            get { return _c_customer_createtime; }
        }
        /// <summary>
        /// 客户类别
        /// </summary>
        public int? C_Customer_Category
        {
            get { return _c_customer_Category; }
            set { _c_customer_Category = value; }
        }
        /// <summary>
        /// 客户状态
        /// </summary>
        public int? C_Customer_State
        {
            get { return _c_customer_State; }
            set { _c_customer_State = value; }
        }
        
        /// <summary>
        /// 关联数据类型(虚拟属性)(1代表客户关联委托人，2代表委托人关联客户,3代表多客户关联多委托人)
        /// </summary>
        public int? C_Customer_reldatatype
        {
            set { _c_customer_reldatatype = value; }
            get { return _c_customer_reldatatype; }
        }
        /// <summary>
        /// 关联表Guid(虚拟属性)
        /// </summary>
        public Guid? C_Customer_relcode
        {
            set { _c_customer_relcode = value; }
            get { return _c_customer_relcode; }
        }

        /// <summary>
        /// 关联Guid串(虚拟属性)
        /// </summary>
        public string C_Customer_relcodes
        {
            set { _c_customer_relcodes = value; }
            get { return _c_customer_relcodes; }
        }
        /// <summary>
        /// 客户关联区域GUID（虚拟字段）
        /// </summary>
        public string C_Customer_Region_code
        {
            get { return _c_customer_Region_code; }
            set { _c_customer_Region_code = value; }
        }
        /// <summary>
        /// 客户关联区域名称（虚拟字段）
        /// </summary>
        public string C_Customer_Region_name
        {
            get { return _c_customer_Region_name; }
            set { _c_customer_Region_name = value; }
        }
        /// <summary>
        /// 销售顾问名称（虚拟字段）
        /// </summary>
        public string C_Customer_consultant_name
        {
            get { return _c_customer_consultant_name; }
            set { _c_customer_consultant_name = value; }
        }
        /// <summary>
        /// 客户区域名称
        /// </summary>
        public string C_Customer_Region
        {
            set { _c_customer_Region = value; }
            get { return _c_customer_Region; }
        }
        /// <summary>
        /// 客户开发阶段(虚拟字段)
        /// </summary>
        public Guid? C_Customer_Open
        {
            set { _c_customer_Open = value; }
            get { return _c_customer_Open; }
        }
        #endregion Model

        #region App专用
        public string _c_customer_type_name; //客户类型名称
        public string _c_customer_category_name; //客户类别名称
        public string _c_customer_state_name; //客户状态名称
        public string _c_customer_level_name;//客户级别
        public string _c_customer_source_name; //客户来源名称
        public string _c_customer_signedState_name; //签约客户状态名称
        public string _c_customer_loyalty_name; //客户忠诚度名称

        /// <summary>
        /// 客户忠诚度名称
        /// </summary>
        public string C_customer_loyalty_name
        {
            get { return _c_customer_loyalty_name; }
            set { _c_customer_loyalty_name = value; }
        }

        /// <summary>
        /// 签约客户状态名称
        /// </summary>
        public string C_customer_signedState_name
        {
            get { return _c_customer_signedState_name; }
            set { _c_customer_signedState_name = value; }
        }

        //客户来源名称
        public string C_customer_source_name
        {
            get { return _c_customer_source_name; }
            set { _c_customer_source_name = value; }
        }


        /// <summary>
        /// 客户级别
        /// </summary>
        public string C_customer_level_name
        {
            get { return _c_customer_level_name; }
            set { _c_customer_level_name = value; }
        }

        /// <summary>
        /// 客户状态名称
        /// </summary>
        public string C_customer_state_name
        {
            get { return _c_customer_state_name; }
            set { _c_customer_state_name = value; }
        }

        /// <summary>
        /// 客户类型名称
        /// </summary>
        public string C_customer_type_name
        {
            get { return _c_customer_type_name; }
            set { _c_customer_type_name = value; }
        }
        /// <summary>
        /// 客户类别名称
        /// </summary>
        public string C_customer_category_name
        {
            get { return _c_customer_category_name; }
            set { _c_customer_category_name = value; }
        }


        #endregion
    }
}
