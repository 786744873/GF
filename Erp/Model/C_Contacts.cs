using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 联系人表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/04/28
    /// </summary>   
    public partial class C_Contacts
    {
        public C_Contacts()
        { }
        #region Model
        public int _c_contacts_id;
        public Guid? _c_contacts_code;
        public int? _c_contacts_type;
        public string _c_contacts_number;
        public int? _c_contacts_is_main;
        public string _c_contacts_name;
        public int? _c_contacts_sex;
        public string _c_contacts_post;
        public string _c_contacts_phone;
        public string _c_contacts_role;
        public string _c_contacts_mobile;
        public string _c_contacts_email;
        public string _c_contacts_hometown;
        public Guid? _c_contacts_creator;
        public DateTime? _c_contacts_createTime;
        public int? _c_contacts_isDelete;
        public DateTime? _c_contacts_birthday;
        public int? _c_contacts_nation;
        public string _c_contacts_nation_name;
        public int? _c_contacts_political;
        public string _c_contacts_political_name;
        public string _c_contacts_address;
        public string _c_contacts_contact_number;
        public string _c_contacts_id_number;
        public string _c_contacts_character;
        public string _c_contacts_hobby;
        public Guid? _c_contacts_relationcode;

        /// <summary>
        /// 联系人ID
        /// </summary>
        public int C_Contacts_id
        {
            get { return _c_contacts_id; }
            set { _c_contacts_id = value; }
        }

        /// <summary>
        /// 联系人GUID
        /// </summary>
        public Guid? C_Contacts_code
        {
            get { return _c_contacts_code; }
            set { _c_contacts_code = value; }
        }

        /// <summary>
        /// 联系人类型，比如：客户联系人，外键，关联C_Parameter（参数）表
        /// </summary>
        public int? C_Contacts_type
        {
            get { return _c_contacts_type; }
            set { _c_contacts_type = value; }
        }

        /// <summary>
        /// 联系人编码，可定义规则添加
        /// </summary>
        public string C_Contacts_number
        {
            get { return _c_contacts_number; }
            set { _c_contacts_number = value; }
        }

        /// <summary>
        /// 是否主联系人
        /// </summary>
        public int? C_Contacts_is_main
        {
            get { return _c_contacts_is_main; }
            set { _c_contacts_is_main = value; }
        }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public string C_Contacts_name
        {
            get { return _c_contacts_name; }
            set { _c_contacts_name = value; }
        }

        /// <summary>
        /// 性别1-男，0-女
        /// </summary>
        public int? C_Contacts_sex
        {
            get { return _c_contacts_sex; }
            set { _c_contacts_sex = value; }
        }

        /// <summary>
        /// 职务
        /// </summary>
        public string C_Contacts_post
        {
            get { return _c_contacts_post; }
            set { _c_contacts_post = value; }
        }

        /// <summary>
        /// 办公电话
        /// </summary>
        public string C_Contacts_phone
        {
            get { return _c_contacts_phone; }
            set { _c_contacts_phone = value; }
        }

        /// <summary>
        /// 联系人角色
        /// </summary>
        public string C_Contacts_role
        {
            get { return _c_contacts_role; }
            set { _c_contacts_role = value; }
        }

        /// <summary>
        /// 联系人手机
        /// </summary>
        public string C_Contacts_mobile
        {
            get { return _c_contacts_mobile; }
            set { _c_contacts_mobile = value; }
        }

        /// <summary>
        /// 联系人电子邮箱
        /// </summary>
        public string C_Contacts_email
        {
            get { return _c_contacts_email; }
            set { _c_contacts_email = value; }
        }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string C_Contacts_hometown
        {
            get { return _c_contacts_hometown; }
            set { _c_contacts_hometown = value; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Contacts_creator
        {
            get { return _c_contacts_creator; }
            set { _c_contacts_creator = value; }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? C_Contacts_createTime
        {
            get { return _c_contacts_createTime; }
            set { _c_contacts_createTime = value; }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int? C_Contacts_isDelete
        {
            get { return _c_contacts_isDelete; }
            set { _c_contacts_isDelete = value; }
        }

        /// <summary>
        /// 出身日期
        /// </summary>
        public DateTime? C_Contacts_birthday
        {
            get { return _c_contacts_birthday; }
            set { _c_contacts_birthday = value; }
        }

        /// <summary>
        /// 民族,外键，关联parameter
        /// </summary>
        public int? C_Contacts_nation
        {
            get { return _c_contacts_nation; }
            set { _c_contacts_nation = value; }
        }

        /// <summary>
        /// 民族名称(虚拟属性)
        /// </summary>
        public string C_Contacts_nation_name
        {
            get { return _c_contacts_nation_name; }
            set { _c_contacts_nation_name = value; }
        }

        /// <summary>
        /// 政治面貌,外键，关联parameter
        /// </summary>
        public int? C_Contacts_political
        {
            get { return _c_contacts_political; }
            set { _c_contacts_political = value; }
        }
        /// <summary>
        /// 政治面貌名称(虚拟属性)
        /// </summary>
        public string C_Contacts_political_name
        {
            get { return _c_contacts_political_name; }
            set { _c_contacts_political_name = value; }
        }

        /// <summary>
        /// 住址
        /// </summary>
        public string C_Contacts_address
        {
            get { return _c_contacts_address; }
            set { _c_contacts_address = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string C_Contacts_contact_number
        {
            get { return _c_contacts_contact_number; }
            set { _c_contacts_contact_number = value; }
        }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public string C_Contacts_id_number
        {
            get { return _c_contacts_id_number; }
            set { _c_contacts_id_number = value; }
        }

        /// <summary>
        /// 性格特征
        /// </summary>
        public string C_Contacts_character
        {
            get { return _c_contacts_character; }
            set { _c_contacts_character = value; }
        }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        public string C_Contacts_hobby
        {
            get { return _c_contacts_hobby; }
            set { _c_contacts_hobby = value; }
        }

        /// <summary>
        /// 关联Guid(虚拟属性)
        /// </summary>
        public Guid? C_Contacts_relationCode
        {
            set { _c_contacts_relationcode = value; }
            get { return _c_contacts_relationcode; }
        }
        
        #endregion
    }
}
