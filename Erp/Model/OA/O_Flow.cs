using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// 流程表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    [Serializable]
    public partial class O_Flow
    {
        public O_Flow()
        { }
        #region Model
        private int _o_flow_id;
        private Guid? _o_flow_code;
        private string _o_flow_name;
        private bool _o_flow_isfree;
        private bool _o_flow_isdelete;
        private Guid? _o_flow_creator;
        private DateTime? _o_flow_createtime;
        /// <summary>
        /// ID,标识列,自动增长
        /// </summary>
        public int O_Flow_id
        {
            set { _o_flow_id = value; }
            get { return _o_flow_id; }
        }
        /// <summary>
        /// 流程GUID
        /// </summary>
        public Guid? O_Flow_code
        {
            set { _o_flow_code = value; }
            get { return _o_flow_code; }
        }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string O_Flow_name
        {
            set { _o_flow_name = value; }
            get { return _o_flow_name; }
        }
        /// <summary>
        /// 是否自由流程,1为自由流程,0为非自由流程
        /// </summary>
        public bool O_Flow_isFree
        {
            set { _o_flow_isfree = value; }
            get { return _o_flow_isfree; }
        }
        /// <summary>
        /// 是否删除,1为已删除,0为未删除
        /// </summary>
        public bool O_Flow_isDelete
        {
            set { _o_flow_isdelete = value; }
            get { return _o_flow_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Flow_creator
        {
            set { _o_flow_creator = value; }
            get { return _o_flow_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Flow_createTime
        {
            set { _o_flow_createtime = value; }
            get { return _o_flow_createtime; }
        }
        #endregion Model

    }
}
