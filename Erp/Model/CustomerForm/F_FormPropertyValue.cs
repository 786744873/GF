using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CustomerForm
{
    /// <summary>
    /// 自定义表单属性值表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/12
    /// </summary>
    public partial class F_FormPropertyValue
    {
        public F_FormPropertyValue()
        { }
        #region Model
        public int _f_formpropertyvalue_id;
        public Guid? _f_formpropertyvalue_code;
        public Guid? _f_formpropertyvalue_form;
        public Guid? _f_formpropertyvalue_formproperty;
        public int? _f_formpropertyvalue_formproperty_id;
        public Guid? _f_formpropertyvalue_businessflowformcode;
        public string _f_formpropertyvalue_value;
        public bool _f_formpropertyvalue_isdelete;
        public Guid? _f_formpropertyvalue_creator;
        public DateTime? _f_formpropertyvalue_createtime;
        public Guid? _f_formpropertyvalue_group;
        /// <summary>
        /// 表单属性值Id，自动增长，流水号
        /// </summary>
        public int F_FormPropertyValue_id
        {
            set { _f_formpropertyvalue_id = value; }
            get { return _f_formpropertyvalue_id; }
        }
        /// <summary>
        /// 表单属性值Code，业务唯一标识
        /// </summary>
        public Guid? F_FormPropertyValue_code
        {
            set { _f_formpropertyvalue_code = value; }
            get { return _f_formpropertyvalue_code; }
        }
        /// <summary>
        /// 表单标识，外键
        /// </summary>
        public Guid? F_FormPropertyValue_form
        {
            set { _f_formpropertyvalue_form = value; }
            get { return _f_formpropertyvalue_form; }
        }
        /// <summary>
        /// 表单属性标识，外键
        /// </summary>
        public Guid? F_FormPropertyValue_formProperty
        {
            set { _f_formpropertyvalue_formproperty = value; }
            get { return _f_formpropertyvalue_formproperty; }
        }
        /// <summary>
        /// 表单属性标识id，外键(虚拟属性)
        /// </summary>
        public int? F_FormPropertyValue_formProperty_id
        {
            set { _f_formpropertyvalue_formproperty_id = value; }
            get { return _f_formpropertyvalue_formproperty_id; }
        }
        /// <summary>
        /// 业务流程表单中间表Code，外键
        /// </summary>
        public Guid? F_FormPropertyValue_BusinessFlowFormCode
        {
            set { _f_formpropertyvalue_businessflowformcode = value; }
            get { return _f_formpropertyvalue_businessflowformcode; }
        }
        /// <summary>
        /// 属性值
        /// </summary>
        public string F_FormPropertyValue_value
        {
            set { _f_formpropertyvalue_value = value; }
            get { return _f_formpropertyvalue_value; }
        }
        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool F_FormPropertyValue_isDelete
        {
            set { _f_formpropertyvalue_isdelete = value; }
            get { return _f_formpropertyvalue_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? F_FormPropertyValue_creator
        {
            set { _f_formpropertyvalue_creator = value; }
            get { return _f_formpropertyvalue_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_FormPropertyValue_createTime
        {
            set { _f_formpropertyvalue_createtime = value; }
            get { return _f_formpropertyvalue_createtime; }
        }

        /// <summary>
        /// 普通子列表时，用来行转列的分组标识(只针对子列表属性)
        /// </summary>
        public Guid? F_FormPropertyValue_group
        {
            set { _f_formpropertyvalue_group = value; }
            get { return _f_formpropertyvalue_group; }
        }

        #endregion Model

    }
}
