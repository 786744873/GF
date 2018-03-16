using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Notes:实体类(属性说明自动提取数据库字段的描述信息)3.	便签表
    /// cyj
    /// 2015年7月14日15:37:08
    /// </summary>
    [Serializable]
    public partial class O_Notes
    {
        public O_Notes()
        { }
        #region Model
        private int _o_notes_id;
        private Guid? _o_notes_code;
        private Guid? _o_notes_person;
        private Guid? _o_notes_creator;
        private DateTime? _o_notes_createtime;
        private bool _o_notes_isdelete;
        private string _o_notes_content;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int O_Notes_id
        {
            set { _o_notes_id = value; }
            get { return _o_notes_id; }
        }
        /// <summary>
        /// 便签GUID 
        /// </summary>
        public Guid? O_Notes_code
        {
            set { _o_notes_code = value; }
            get { return _o_notes_code; }
        }
        /// <summary>
        /// 所属人员 
        /// </summary>
        public Guid? O_Notes_person
        {
            set { _o_notes_person = value; }
            get { return _o_notes_person; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Notes_creator
        {
            set { _o_notes_creator = value; }
            get { return _o_notes_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Notes_createTime
        {
            set { _o_notes_createtime = value; }
            get { return _o_notes_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Notes_isDelete
        {
            set { _o_notes_isdelete = value; }
            get { return _o_notes_isdelete; }
        }
        /// <summary>
        /// 便签内容
        /// </summary>
        public string O_Notes_content
        {
            set { _o_notes_content = value; }
            get { return _o_notes_content; }
        }
        #endregion Model

    }
}
