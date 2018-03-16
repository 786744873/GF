using System;
using System.Collections.Generic;
namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 流程表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
    public partial class P_Flow
    {
        public P_Flow()
        { }
        #region Model
        public int _p_flow_id;
        public Guid? _p_flow_code;
        public string _p_flow_name;
        public int? _p_flow_type;
        public Guid? _p_flow_parent;
        public string _p_flow_parent_name;
        public int? _p_flow_level;
        public Guid? _p_flow_creator;
        public DateTime? _p_flow_createtime;
        public int? _p_flow_isdelete;
        public string _p_flow_require;
        public int? _p_flow_order;
        public int? _p_flow_defaultDuration;
        public bool _p_flow_IsCrossForm;
        public bool _p_flow_IsChiefCheck;
        public bool _p_flow_IsMonitor;
        public List<Model.SysManager.C_Post> _c_posts;

        public int P_Flow_ManagerType { get; set; }
        /// <summary>
        /// 流程ID，主键，自增
        /// </summary>
        public int P_Flow_id
        {
            set { _p_flow_id = value; }
            get { return _p_flow_id; }
        }
        /// <summary>
        /// GUID
        /// </summary>
        public Guid? P_Flow_code
        {
            set { _p_flow_code = value; }
            get { return _p_flow_code; }
        }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string P_Flow_name
        {
            set { _p_flow_name = value; }
            get { return _p_flow_name; }
        }
        /// <summary>
        /// 流程类型，外键，parameter表，目前包含：案件、商机
        /// </summary>
        public int? P_Flow_type
        {
            set { _p_flow_type = value; }
            get { return _p_flow_type; }
        }
        /// <summary>
        /// 父级流程
        /// </summary>
        public Guid? P_Flow_parent
        {
            set { _p_flow_parent = value; }
            get { return _p_flow_parent; }
        }
        /// <summary>
        /// 父级流程名称（虚拟字段）
        /// </summary>
        public string P_Flow_parent_name
        {
            get { return _p_flow_parent_name; }
            set { _p_flow_parent_name = value; }
        }

        /// <summary>
        /// 流程级别
        /// </summary>
        public int? P_Flow_level
        {
            set { _p_flow_level = value; }
            get { return _p_flow_level; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? P_Flow_creator
        {
            set { _p_flow_creator = value; }
            get { return _p_flow_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? P_Flow_createTime
        {
            set { _p_flow_createtime = value; }
            get { return _p_flow_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? P_Flow_isDelete
        {
            set { _p_flow_isdelete = value; }
            get { return _p_flow_isdelete; }
        }
        /// <summary>
        /// 流程要求
        /// </summary>
        public string P_Flow_require
        {
            set { _p_flow_require = value; }
            get { return _p_flow_require; }
        }
        /// <summary>
        /// 流程顺序
        /// </summary>
        public int? P_Flow_order
        {
            set { _p_flow_order = value; }
            get { return _p_flow_order; }
        }
        /// <summary>
        /// 默认时长
        /// </summary>
        public int? P_Flow_defaultDuration
        {
            get { return _p_flow_defaultDuration; }
            set { _p_flow_defaultDuration = value; }
        }
        /// <summary>
        /// 是否交单
        /// </summary>
        public bool P_Flow_IsCrossForm
        {
            get { return _p_flow_IsCrossForm; }
            set { _p_flow_IsCrossForm = value; }
        }
        /// <summary>
        /// 是否首席必审
        /// </summary>
        public bool P_Flow_IsChiefCheck
        {
            get { return _p_flow_IsChiefCheck; }
            set { _p_flow_IsChiefCheck = value; }
        }
        /// <summary>
        /// 是否监控
        /// </summary>
        public bool P_Flow_IsMonitor
        {
            get { return _p_flow_IsMonitor; }
            set { _p_flow_IsMonitor = value; }
        }
        /// <summary>
        /// 岗位集合（虚拟字段）
        /// </summary>
        public List<Model.SysManager.C_Post> C_Posts
        {
            get { return _c_posts; }
            set { _c_posts = value; }
        }
        #endregion Model

    }
}

