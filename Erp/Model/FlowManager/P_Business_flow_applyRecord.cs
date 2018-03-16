using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 业务流程申请记录表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/10/22
    /// </summary>
    [Serializable]
    public partial class P_Business_flow_applyRecord
    {
        public P_Business_flow_applyRecord()
        { }
        #region Model
        private int _p_business_flow_applyrecord_id;
        private Guid? _p_business_flow_applyrecord_code;
        private Guid? _p_business_flow_applyrecord_applyuser;
        private string _p_business_flow_applyrecord_applyuser_name;
        private DateTime? _p_business_flow_applyrecord_applytime;
        private string _p_business_flow_applyrecord_applydetail;
        private Guid? _p_business_flow_applyrecord_audituser;
        private string _p_business_flow_applyrecord_audituser_name;
        private DateTime? _p_business_flow_applyrecord_audittime;
        private string _p_business_flow_applyrecord_auditdetail;
        private int? _p_business_flow_applyrecord_recordtype;
        private Guid? _p_business_flow_applyrecord_businessflow;
        private bool _p_business_flow_applyrecord_isdelete;
        private Guid? _p_business_flow_applyrecord_creator;
        private DateTime? _p_business_flow_applyrecord_createtime;
        /// <summary>
        /// 业务流程申请将id，自动增长
        /// </summary>
        public int P_Business_flow_applyRecord_id
        {
            set { _p_business_flow_applyrecord_id = value; }
            get { return _p_business_flow_applyrecord_id; }
        }
        /// <summary>
        /// 业务流程申请记录GUID
        /// </summary>
        public Guid? P_Business_flow_applyRecord_code
        {
            set { _p_business_flow_applyrecord_code = value; }
            get { return _p_business_flow_applyrecord_code; }
        }
        /// <summary>
        /// 申请人GUID
        /// </summary>
        public Guid? P_Business_flow_applyRecord_applyUser
        {
            set { _p_business_flow_applyrecord_applyuser = value; }
            get { return _p_business_flow_applyrecord_applyuser; }
        }
        /// <summary>
        /// 申请人名称(虚拟属性)
        /// </summary>
        public string P_Business_flow_applyRecord_applyUser_name
        {
            set { _p_business_flow_applyrecord_applyuser_name = value; }
            get { return _p_business_flow_applyrecord_applyuser_name; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? P_Business_flow_applyRecord_applyTime
        {
            set { _p_business_flow_applyrecord_applytime = value; }
            get { return _p_business_flow_applyrecord_applytime; }
        }
        /// <summary>
        /// 申请详情
        /// </summary>
        public string P_Business_flow_applyRecord_applyDetail
        {
            set { _p_business_flow_applyrecord_applydetail = value; }
            get { return _p_business_flow_applyrecord_applydetail; }
        }
        /// <summary>
        /// 审查人Guid
        /// </summary>
        public Guid? P_Business_flow_applyRecord_auditUser
        {
            set { _p_business_flow_applyrecord_audituser = value; }
            get { return _p_business_flow_applyrecord_audituser; }
        }

        /// <summary>
        /// 审查人名称(虚拟属性)
        /// </summary>
        public string P_Business_flow_applyRecord_auditUser_name
        {
            set { _p_business_flow_applyrecord_audituser_name = value; }
            get { return _p_business_flow_applyrecord_audituser_name; }
        }

        /// <summary>
        /// 审查时间
        /// </summary>
        public DateTime? P_Business_flow_applyRecord_auditTime
        {
            set { _p_business_flow_applyrecord_audittime = value; }
            get { return _p_business_flow_applyrecord_audittime; }
        }
        /// <summary>
        /// 审查详情
        /// </summary>
        public string P_Business_flow_applyRecord_auditDetail
        {
            set { _p_business_flow_applyrecord_auditdetail = value; }
            get { return _p_business_flow_applyrecord_auditdetail; }
        }
        /// <summary>
        /// 记录类型，针对parameter表
        /// </summary>
        public int? P_Business_flow_applyRecord_recordType
        {
            set { _p_business_flow_applyrecord_recordtype = value; }
            get { return _p_business_flow_applyrecord_recordtype; }
        }
        /// <summary>
        /// 业务流程Guid
        /// </summary>
        public Guid? P_Business_flow_applyRecord_businessFlow
        {
            set { _p_business_flow_applyrecord_businessflow = value; }
            get { return _p_business_flow_applyrecord_businessflow; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool P_Business_flow_applyRecord_isDelete
        {
            set { _p_business_flow_applyrecord_isdelete = value; }
            get { return _p_business_flow_applyrecord_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? P_Business_flow_applyRecord_creator
        {
            set { _p_business_flow_applyrecord_creator = value; }
            get { return _p_business_flow_applyrecord_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? P_Business_flow_applyRecord_createTime
        {
            set { _p_business_flow_applyrecord_createtime = value; }
            get { return _p_business_flow_applyrecord_createtime; }
        }
        #endregion Model

    }
}
