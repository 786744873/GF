using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CustomerForm
{
    /// <summary>
    /// 自定义表单表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/12
    /// </summary>
    [Serializable]
    public partial class F_Form
    {
        public F_Form()
        { }
        #region Model
        private int _f_form_id;
        private Guid? _f_form_code;
        private string _f_form_englishname;
        private string _f_form_chinesename;
        private int? _f_form_type;
        private string _f_form_remark;
        private bool _f_form_isdelete;
        private Guid? _f_form_creator;
        private string _f_form_creator_name;        
        private DateTime? _f_form_createtime;
        private bool _f_form_IsChiefCheck;
        /// <summary>
        /// 表单ID，自动增长，流水号
        /// </summary>
        public int F_Form_id
        {
            set { _f_form_id = value; }
            get { return _f_form_id; }
        }
        /// <summary>
        /// 表单Code，业务唯一标识
        /// </summary>
        public Guid? F_Form_code
        {
            set { _f_form_code = value; }
            get { return _f_form_code; }
        }
        /// <summary>
        /// 表单字母标识(唯一)
        /// </summary>
        public string F_Form_englishName
        {
            set { _f_form_englishname = value; }
            get { return _f_form_englishname; }
        }
        /// <summary>
        /// 表单中文名称(显示名称)
        /// </summary>
        public string F_Form_chineseName
        {
            set { _f_form_chinesename = value; }
            get { return _f_form_chinesename; }
        }
        /// <summary>
        /// 表单类型
        /// </summary>
        public int? F_Form_type
        {
            set { _f_form_type = value; }
            get { return _f_form_type; }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string F_Form_remark
        {
            set { _f_form_remark = value; }
            get { return _f_form_remark; }
        }
        /// <summary>
        /// 是否已删除(1为已删除，0为未删除)
        /// </summary>
        public bool F_Form_isDelete
        {
            set { _f_form_isdelete = value; }
            get { return _f_form_isdelete; }
        }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid? F_Form_creator
        {
            set { _f_form_creator = value; }
            get { return _f_form_creator; }
        }
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string F_Form_creator_name
        {
            get { return _f_form_creator_name; }
            set { _f_form_creator_name = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_Form_createTime
        {
            set { _f_form_createtime = value; }
            get { return _f_form_createtime; }
        }
        /// <summary>
        /// 是否首席必审
        /// </summary>
        public bool F_Form_IsChiefCheck
        {
            get { return _f_form_IsChiefCheck; }
            set { _f_form_IsChiefCheck = value; }
        }
        
        #endregion Model

    }
}
