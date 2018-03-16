using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Teams:实体类(属性说明自动提取数据库字段的描述信息)5.	分组表
    /// cyj
    /// 2015年7月14日15:57:25
    /// </summary>
    [Serializable]
    public partial class O_Teams
    {
        public O_Teams()
        { }
        #region Model
        private int _o_teams_id;
        private Guid _o_teams_code;
        private string _o_teams_name;
        private Guid _o_teams_creator;
        private DateTime? _o_teams_createtime;
        private bool _o_teams_isdelete;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int O_Teams_id
        {
            set { _o_teams_id = value; }
            get { return _o_teams_id; }
        }
        /// <summary>
        /// GUID  
        /// </summary>
        public Guid O_Teams_code
        {
            set { _o_teams_code = value; }
            get { return _o_teams_code; }
        }
        /// <summary>
        /// 组名 
        /// </summary>
        public string O_Teams_name
        {
            set { _o_teams_name = value; }
            get { return _o_teams_name; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid O_Teams_creator
        {
            set { _o_teams_creator = value; }
            get { return _o_teams_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Teams_createTime
        {
            set { _o_teams_createtime = value; }
            get { return _o_teams_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Teams_isDelete
        {
            set { _o_teams_isdelete = value; }
            get { return _o_teams_isdelete; }
        }
        #endregion Model

    }
}
