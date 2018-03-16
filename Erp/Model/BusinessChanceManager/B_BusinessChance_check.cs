using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.BusinessChanceManager
{
    /// <summary>
    /// 商机审查表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/10/29
    /// </summary>
    [Serializable]
    public partial class B_BusinessChance_check
    {
        public B_BusinessChance_check()
        { }
        #region Model
        private int _b_businesschance_check_id;
        private Guid? _b_businesschance_check_code;
        private int? _b_businesschance_check_checktype;
        private string _b_businesschance_check_checktype_name;
        private int? _b_businesschance_check_nature;
        private string _b_businesschance_check_nature_name;
        private int? _b_businesschance_check_category;
        private Guid? _b_businesschance_check_confirmperson;
        private string _b_businesschance_check_confirmperson_name;
        private DateTime? _b_businesschance_check_planstarttime;
        private DateTime? _b_businesschance_check_planendtime;
        private string _b_businesschance_check_checkopinion;
        private Guid? _b_businesschance_check_checkperson;
        private string _b_businesschance_check_checkperson_name;
        private DateTime? _b_businesschance_check_checktime;
        private int? _b_businesschance_checkpersontype;
        private Guid? _b_businesschance_check_businesschance_code;
        private bool _b_businesschance_check_ischecked;
        private Guid? _b_businesschance_check_creator;
        private DateTime? _b_businesschance_check_createtime;
        private bool _b_businesschance_check_isdelete;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int B_BusinessChance_check_id
        {
            set { _b_businesschance_check_id = value; }
            get { return _b_businesschance_check_id; }
        }
        /// <summary>
        /// 商机审查GUID
        /// </summary>
        public Guid? B_BusinessChance_check_code
        {
            set { _b_businesschance_check_code = value; }
            get { return _b_businesschance_check_code; }
        }
        /// <summary>
        /// 审查类型，关联parameter表
        /// </summary>
        public int? B_BusinessChance_check_checkType
        {
            set { _b_businesschance_check_checktype = value; }
            get { return _b_businesschance_check_checktype; }
        }

        /// <summary>
        /// 审查类型名称(虚拟属性)，关联parameter表
        /// </summary>
        public string B_BusinessChance_check_checkType_name
        {
            set { _b_businesschance_check_checktype_name = value; }
            get { return _b_businesschance_check_checktype_name; }
        }

        /// <summary>
        /// 案件性质，关联parameter表
        /// </summary>
        public int? B_BusinessChance_check_Nature
        {
            set { _b_businesschance_check_nature = value; }
            get { return _b_businesschance_check_nature; }
        }

        /// <summary>
        /// 案件性质名称(虚拟属性)，关联parameter表
        /// </summary>
        public string B_BusinessChance_check_Nature_name
        {
            set { _b_businesschance_check_nature_name = value; }
            get { return _b_businesschance_check_nature_name; }
        }

        /// <summary>
        /// 案件分类：1为指挥级；2 策划级
        /// </summary>
        public int? B_BusinessChance_check_category
        {
            set { _b_businesschance_check_category = value; }
            get { return _b_businesschance_check_category; }
        }
        /// <summary>
        /// 确认部长
        /// </summary>
        public Guid? B_BusinessChance_check_confirmPerson
        {
            set { _b_businesschance_check_confirmperson = value; }
            get { return _b_businesschance_check_confirmperson; }
        }
        /// <summary>
        /// 确认部长名称(虚拟属性)
        /// </summary>
        public string B_BusinessChance_check_confirmPerson_name
        {
            set { _b_businesschance_check_confirmperson_name = value; }
            get { return _b_businesschance_check_confirmperson_name; }
        }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? B_BusinessChance_check_planStartTime
        {
            set { _b_businesschance_check_planstarttime = value; }
            get { return _b_businesschance_check_planstarttime; }
        }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? B_BusinessChance_check_planEndTime
        {
            set { _b_businesschance_check_planendtime = value; }
            get { return _b_businesschance_check_planendtime; }
        }
        /// <summary>
        /// 审查意见
        /// </summary>
        public string B_BusinessChance_check_checkOpinion
        {
            set { _b_businesschance_check_checkopinion = value; }
            get { return _b_businesschance_check_checkopinion; }
        }
        /// <summary>
        /// 审查人员
        /// </summary>
        public Guid? B_BusinessChance_check_checkPerson
        {
            set { _b_businesschance_check_checkperson = value; }
            get { return _b_businesschance_check_checkperson; }
        }

        /// <summary>
        /// 审查人员名称(虚拟属性)
        /// </summary>
        public string B_BusinessChance_check_checkPerson_name
        {
            set { _b_businesschance_check_checkperson_name = value; }
            get { return _b_businesschance_check_checkperson_name; }
        }

        /// <summary>
        /// 审查时间
        /// </summary>
        public DateTime? B_BusinessChance_check_checkTime
        {
            set { _b_businesschance_check_checktime = value; }
            get { return _b_businesschance_check_checktime; }
        }
        /// <summary>
        /// 审查人员类型：1为部长；2为首席
        /// </summary>
        public int? B_BusinessChance_checkPersonType
        {
            set { _b_businesschance_checkpersontype = value; }
            get { return _b_businesschance_checkpersontype; }
        }
        /// <summary>
        /// 商机Guid
        /// </summary>
        public Guid? B_BusinessChance_check_BusinessChance_code
        {
            set { _b_businesschance_check_businesschance_code = value; }
            get { return _b_businesschance_check_businesschance_code; }
        }
        /// <summary>
        /// 是否已审核;true为已审核；false为未审核
        /// </summary>
        public bool B_BusinessChance_check_isChecked
        {
            set { _b_businesschance_check_ischecked = value; }
            get { return _b_businesschance_check_ischecked; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? B_BusinessChance_check_creator
        {
            set { _b_businesschance_check_creator = value; }
            get { return _b_businesschance_check_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? B_BusinessChance_check_createTime
        {
            set { _b_businesschance_check_createtime = value; }
            get { return _b_businesschance_check_createtime; }
        }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool B_BusinessChance_check_isDelete
        {
            set { _b_businesschance_check_isdelete = value; }
            get { return _b_businesschance_check_isdelete; }
        }
        #endregion Model

    }
}
