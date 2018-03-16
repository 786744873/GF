using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// 流程预设表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    [Serializable]
    public partial class O_FlowSet
    {
        public O_FlowSet()
        { }
        #region Model
        private int _o_flowset_id;
        private Guid? _o_flowset_code;
        private string _o_flowset_name;
        private Guid? _o_flowset_flow;
        private int? _o_flowset_order;
        private int? _o_flowset_audittype;
        private string _o_flowset_audit_personcodes;
        private string _o_flowset_audit_personnames;
        private string _o_flowset_rule;
        private bool _o_flowset_isdelete;
        private Guid? _o_flowset_creator;
        private DateTime? _o_flowset_createtime;
        private string _o_flowset_audittypename;
        private string _o_flowset_personNames_Lists;
        /// <summary>
        /// ID,标识列,自动增长
        /// </summary>
        public int O_FlowSet_id
        {
            set { _o_flowset_id = value; }
            get { return _o_flowset_id; }
        }
        /// <summary>
        /// 虚拟字段（审核人名称集合）
        /// </summary>
        public string O_Flowset_personNames_Lists
        {
            set { _o_flowset_personNames_Lists = value; }
            get { return _o_flowset_personNames_Lists; }
        }
        /// <summary>
        /// 流程预设GUID
        /// </summary>
        public Guid? O_FlowSet_code
        {
            set { _o_flowset_code = value; }
            get { return _o_flowset_code; }
        }
        /// <summary>
        /// 流程预设名称(暂时没有用到)
        /// </summary>
        public string O_FlowSet_name
        {
            set { _o_flowset_name = value; }
            get { return _o_flowset_name; }
        }
        /// <summary>
        /// 所属流程Guid,外键
        /// </summary>
        public Guid? O_FlowSet_flow
        {
            set { _o_flowset_flow = value; }
            get { return _o_flowset_flow; }
        }
        /// <summary>
        /// 顺序
        /// </summary>
        public int? O_FlowSet_order
        {
            set { _o_flowset_order = value; }
            get { return _o_flowset_order; }
        }
        /// <summary>
        /// 多人审核类型，对应C_Parameters表，值为”并且”或”或者”
        /// </summary>
        public int? O_FlowSet_auditType
        {
            set { _o_flowset_audittype = value; }
            get { return _o_flowset_audittype; }
        }
        /// <summary>
        /// 审核类型名称（虚拟字段）
        /// </summary>
        public string O_FlowSet_auditTypename
        {
            set { _o_flowset_audittypename = value; }
            get { return _o_flowset_audittypename; }
        }
        /// <summary>
        /// 审核人Guids(虚拟属性)
        /// </summary>
        public string O_FlowSet_audit_personCodes
        {
            set { _o_flowset_audit_personcodes = value; }
            get { return _o_flowset_audit_personcodes; }
        }

        /// <summary>
        /// 审核人名称(虚拟属性)
        /// </summary>
        public string O_FlowSet_audit_personNames
        {
            set { _o_flowset_audit_personnames = value; }
            get { return _o_flowset_audit_personnames; }
        }

        /// <summary>
        /// 规则
        /// </summary>
        public string O_FlowSet_rule
        {
            set { _o_flowset_rule = value; }
            get { return _o_flowset_rule; }
        }
        /// <summary>
        /// 是否删除,1为已删除,0为未删除
        /// </summary>
        public bool O_FlowSet_isDelete
        {
            set { _o_flowset_isdelete = value; }
            get { return _o_flowset_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_FlowSet_creator
        {
            set { _o_flowset_creator = value; }
            get { return _o_flowset_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_FlowSet_createTime
        {
            set { _o_flowset_createtime = value; }
            get { return _o_flowset_createtime; }
        }
        #endregion Model

    }
}
