using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 实体表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/03
    /// </summary>
    [Serializable]
    public partial class C_Entity
    {
        public C_Entity()
        { }
        #region Model
        private int _c_entity_id;
        private Guid? _c_entity_code;
        private string _c_entity_identityname;
        private string _c_entity_showname;
        private string _c_entity_tablename;
        private string _c_entity_business_relfieldname;
        private string _c_entity_business_showfieldname;
        private bool _c_entity_isdelete;
        private Guid? _c_entity_creator;
        private DateTime? _c_entity_createtime;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int C_Entity_Id
        {
            set { _c_entity_id = value; }
            get { return _c_entity_id; }
        }
        /// <summary>
        /// 实体GUID
        /// </summary>
        public Guid? C_Entity_code
        {
            set { _c_entity_code = value; }
            get { return _c_entity_code; }
        }
        /// <summary>
        /// 实体标识名称
        /// </summary>
        public string C_Entity_identityName
        {
            set { _c_entity_identityname = value; }
            get { return _c_entity_identityname; }
        }
        /// <summary>
        /// 实体显示名称
        /// </summary>
        public string C_Entity_showName
        {
            set { _c_entity_showname = value; }
            get { return _c_entity_showname; }
        }
        /// <summary>
        /// 实体表名
        /// </summary>
        public string C_Entity_tableName
        {
            set { _c_entity_tablename = value; }
            get { return _c_entity_tablename; }
        }
        /// <summary>
        /// 实体业务关联字段名称
        /// </summary>
        public string C_Entity_business_relFieldName
        {
            set { _c_entity_business_relfieldname = value; }
            get { return _c_entity_business_relfieldname; }
        }
        /// <summary>
        /// 实体业务显示字段名称
        /// </summary>
        public string C_Entity_business_showFieldName
        {
            set { _c_entity_business_showfieldname = value; }
            get { return _c_entity_business_showfieldname; }
        }
        /// <summary>
        /// 是否删除(1为已删除；0为未删除)
        /// </summary>
        public bool C_Entity_isDelete
        {
            set { _c_entity_isdelete = value; }
            get { return _c_entity_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Entity_creator
        {
            set { _c_entity_creator = value; }
            get { return _c_entity_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Entity_createTime
        {
            set { _c_entity_createtime = value; }
            get { return _c_entity_createtime; }
        }
        #endregion Model

    }
}
