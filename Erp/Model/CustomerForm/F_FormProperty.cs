using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CustomerForm
{
    /// <summary>
    /// 自定义表单属性表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/12
    /// </summary>
    public partial class F_FormProperty
    {
        public F_FormProperty()
        { }
        #region Model
        public int _f_formproperty_id;
        public Guid? _f_formproperty_code;
        public Guid? _f_formproperty_parent;
        public string _f_formproperty_parent_name;
        public Guid? _f_formproperty_form;
        public string _f_formproperty_form_chineseName;
        public string _f_formproperty_showname;
        public string _f_formproperty_fieldname;
        public int? _f_formproperty_fieldlength;
        public int? _f_formproperty_uitype;
        public string _f_formproperty_uitypename;
        public bool _f_formproperty_isonlyread;
        public bool _f_formproperty_isshow;
        public bool _f_formproperty_isrequire;
        public string _f_formproperty_validationmessage;
        public string _f_formproperty_targeturl;
        public int? _f_formproperty_orderby;
        public bool _f_formproperty_isbase;
        public int? _f_formproperty_datasource_type;
        public string _f_formproperty_datasource;
        public string _f_formproperty_datasource_mappingfield;
        public string _f_formproperty_datasource_mappingfieldname;
        public string _f_formproperty_datasource_conditionfield;
        public string _f_formproperty_datasource_conditionvalue;
        public int? _f_formproperty_datasource_conditiontype;
        public string _f_formproperty_remark;
        public bool _f_formproperty_issum;
        public int? _f_formproperty_triggerevent_type;
        public string _f_formproperty_triggerevent_dynamicJs;
        public string _f_formproperty_defaultvalue;
        public bool _f_formproperty_isshowinhistory;
        public bool _f_formproperty_isdelete;
        public Guid? _f_formproperty_creator;
        public DateTime? _f_formproperty_createtime;
        public int? _v_formpropertyvalue_id;
        public Guid? _v_formpropertyvalue_code;
        public Guid? _v_businessflowform_code;
        public string _v_formpropertyvalue_value;
        public string _v_formpropertyvalue_value_name;
        /// <summary>
        /// 表单属性Id,自动增长，流水号
        /// </summary>
        public int F_FormProperty_id
        {
            set { _f_formproperty_id = value; }
            get { return _f_formproperty_id; }
        }
        /// <summary>
        /// 表单属性Code，唯一业务标识
        /// </summary>
        public Guid? F_FormProperty_code
        {
            set { _f_formproperty_code = value; }
            get { return _f_formproperty_code; }
        }
        /// <summary>
        /// 父亲属性
        /// </summary>
        public Guid? F_FormProperty_parent
        {
            set { _f_formproperty_parent = value; }
            get { return _f_formproperty_parent; }
        }
        /// <summary>
        /// 父亲属性名称(虚拟属性)
        /// </summary>
        public string F_FormProperty_parent_name
        {
            set { _f_formproperty_parent_name = value; }
            get { return _f_formproperty_parent_name; }
        }

        /// <summary>
        /// 表单标识，外键
        /// </summary>
        public Guid? F_FormProperty_form
        {
            set { _f_formproperty_form = value; }
            get { return _f_formproperty_form; }
        }
        /// <summary>
        /// 表单中文名称(虚拟属性)
        /// </summary>
        public string F_FormProperty_form_chineseName
        {
            set { _f_formproperty_form_chineseName = value; }
            get { return _f_formproperty_form_chineseName; }
        }

        /// <summary>
        /// 属性显示名称
        /// </summary>
        public string F_FormProperty_showName
        {
            set { _f_formproperty_showname = value; }
            get { return _f_formproperty_showname; }
        }
        /// <summary>
        /// 属性字段名称
        /// </summary>
        public string F_FormProperty_fieldName
        {
            set { _f_formproperty_fieldname = value; }
            get { return _f_formproperty_fieldname; }
        }
        /// <summary>
        /// 属性字段长度
        /// </summary>
        public int? F_FormProperty_fieldLength
        {
            set { _f_formproperty_fieldlength = value; }
            get { return _f_formproperty_fieldlength; }
        }
        /// <summary>
        /// 控件UI类型，对应参数表
        /// </summary>
        public int? F_FormProperty_uiType
        {
            set { _f_formproperty_uitype = value; }
            get { return _f_formproperty_uitype; }
        }

        /// <summary>
        ///  控件UI类型名称(虚拟属性)
        /// </summary>
        public string F_FormProperty_uiTypeName
        {
            set { _f_formproperty_uitypename = value; }
            get { return _f_formproperty_uitypename; }
        }

        /// <summary>
        /// 属性是否只读(1为只读，0为否)
        /// </summary>
        public bool F_FormProperty_isOnlyRead
        {
            set { _f_formproperty_isonlyread = value; }
            get { return _f_formproperty_isonlyread; }
        }
        /// <summary>
        /// 属性是否显示(1为显示，0为不显示)
        /// </summary>
        public bool F_FormProperty_isShow
        {
            set { _f_formproperty_isshow = value; }
            get { return _f_formproperty_isshow; }
        }
        /// <summary>
        /// 属性是否必填(1为必填，0为不必填)
        /// </summary>
        public bool F_FormProperty_isRequire
        {
            set { _f_formproperty_isrequire = value; }
            get { return _f_formproperty_isrequire; }
        }
        /// <summary>
        /// 属性验证信息
        /// </summary>
        public string F_FormProperty_validationMessage
        {
            set { _f_formproperty_validationmessage = value; }
            get { return _f_formproperty_validationmessage; }
        }
        /// <summary>
        /// 打开目标url，如单选弹出框的连接地址
        /// </summary>
        public string F_FormProperty_targetUrl
        {
            set { _f_formproperty_targeturl = value; }
            get { return _f_formproperty_targeturl; }
        }

        /// <summary>
        /// 属性显示顺序
        /// </summary>
        public int? F_FormProperty_orderBy
        {
            set { _f_formproperty_orderby = value; }
            get { return _f_formproperty_orderby; }
        }
        /// <summary>
        /// 是否基础属性(1为是，0为否)，如果为基础属性，其余表单属性必须继承这些属性，基础属性不允许用户自建，应由DB管理员处理
        /// </summary>
        public bool F_FormProperty_isBase
        {
            set { _f_formproperty_isbase = value; }
            get { return _f_formproperty_isbase; }
        }
        /// <summary>
        /// 关联自定义表单数据源类型，关联数据源类型参数表(数据库表类型和自定义表单类型)
        /// </summary>
        public int? F_FormProperty_dataSource_type
        {
            set { _f_formproperty_datasource_type = value; }
            get { return _f_formproperty_datasource_type; }
        }
        /// <summary>
        /// 关联数据源(表名或者表单名)
        /// </summary>
        public string F_FormProperty_dataSource
        {
            set { _f_formproperty_datasource = value; }
            get { return _f_formproperty_datasource; }
        }
        /// <summary>
        /// 关联数据源(表或者表单)映射字段名，这个字段要映射到表单属性值表中
        /// </summary>
        public string F_FormProperty_dataSource_mappingField
        {
            set { _f_formproperty_datasource_mappingfield = value; }
            get { return _f_formproperty_datasource_mappingfield; }
        }
        /// <summary>
        /// 关联数据源(表或者表单)映射显示字段名
        /// </summary>
        public string F_FormProperty_dataSource_mappingFieldName
        {
            set { _f_formproperty_datasource_mappingfieldname = value; }
            get { return _f_formproperty_datasource_mappingfieldname; }
        }

        /// <summary>
        /// 关联数据源(表或者表单)条件字段名
        /// </summary>
        public string F_FormProperty_dataSource_conditionField
        {
            set { _f_formproperty_datasource_conditionfield = value; }
            get { return _f_formproperty_datasource_conditionfield; }
        }
        /// <summary>
        /// 关联数据源(表或者表单)条件值
        /// </summary>
        public string F_FormProperty_dataSource_conditionValue
        {
            set { _f_formproperty_datasource_conditionvalue = value; }
            get { return _f_formproperty_datasource_conditionvalue; }
        }
        /// <summary>
        /// 关联数据源(表或者表单)条件类型，关联参数表，默认等于
        /// </summary>
        public int? F_FormProperty_dataSource_conditionType
        {
            set { _f_formproperty_datasource_conditiontype = value; }
            get { return _f_formproperty_datasource_conditiontype; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_FormProperty_remark
        {
            set { _f_formproperty_remark = value; }
            get { return _f_formproperty_remark; }
        }

        /// <summary>
        /// 是否合计求和(1为是；0为否)
        /// </summary>
        public bool F_FormProperty_isSum
        {
            get { return _f_formproperty_issum; }
            set { _f_formproperty_issum = value; }
        }
        /// <summary>
        /// 触发事件类型,C_Parameters表
        /// </summary>
        public int? F_FormProperty_triggerEvent_Type
        {
            set { _f_formproperty_triggerevent_type = value; }
            get { return _f_formproperty_triggerevent_type; }
        }
        /// <summary>
        /// 触发事件后的动态javascript代码
        /// </summary>
        public string F_FormProperty_triggerEvent_dynamicJs
        {
            set { _f_formproperty_triggerevent_dynamicJs = value; }
            get { return _f_formproperty_triggerevent_dynamicJs; }
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public string F_FormProperty_defaultValue
        {
            set { _f_formproperty_defaultvalue = value; }
            get { return _f_formproperty_defaultvalue; }
        }

        /// <summary>
        /// 是否显示在历史记录中(true为是；false为否)
        /// </summary>
        public bool F_FormProperty_isShowInHistory
        {
            get { return _f_formproperty_isshowinhistory; }
            set { _f_formproperty_isshowinhistory = value; }
        }

        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool F_FormProperty_isDelete
        {
            set { _f_formproperty_isdelete = value; }
            get { return _f_formproperty_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? F_FormProperty_creator
        {
            set { _f_formproperty_creator = value; }
            get { return _f_formproperty_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_FormProperty_createTime
        {
            set { _f_formproperty_createtime = value; }
            get { return _f_formproperty_createtime; }
        }
        /// <summary>
        /// 表单属性值Id(虚拟属性)
        /// </summary>
        public int? V_FormPropertyValue_Id
        {
            set { _v_formpropertyvalue_id = value; }
            get { return _v_formpropertyvalue_id; }
        }
        /// <summary>
        /// 表单属性值Guid(虚拟属性)
        /// </summary>
        public Guid? V_FormPropertyValue_Code
        {
            set { _v_formpropertyvalue_code = value; }
            get { return _v_formpropertyvalue_code; }
        }
        /// <summary>
        /// 业务流程表单关联Guid(虚拟属性)
        /// </summary>
        public Guid? V_BusinessFlowForm_Code
        {
            set { _v_businessflowform_code = value; }
            get { return _v_businessflowform_code; }
        }
        /// <summary>
        /// 表单属性值(虚拟属性)
        /// </summary>
        public string V_FormPropertyValue_Value
        {
            set { _v_formpropertyvalue_value = value; }
            get { return _v_formpropertyvalue_value; }
        }
        /// <summary>
        /// 表单属性值显示名称(虚拟属性)
        /// </summary>
        public string V_FormPropertyValue_Value_Name
        {
            set { _v_formpropertyvalue_value_name = value; }
            get { return _v_formpropertyvalue_value_name; }
        }


        #endregion Model

    }
}
