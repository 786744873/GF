using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 业务流程--表单--用户中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/05/28
    /// </summary>
    [Serializable]
    public partial class P_Business_flow_form_user
    {
        public P_Business_flow_form_user()
        { }
        #region Model
        private int _p_business_flow_form_user_id;
        private Guid? _p_business_flow_form_user_code;
        private Guid? _p_business_flow_form_code;
        private Guid? _p_business_flow_form_user_user;
        private bool _p_business_flow_form_user_isdelete;
        private Guid? _p_business_flow_form_user_creator;
        private DateTime? _p_business_flow_form_user_createtime;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int P_Business_flow_form_user_id
        {
            set { _p_business_flow_form_user_id = value; }
            get { return _p_business_flow_form_user_id; }
        }
        /// <summary>
        /// 业务流程表单用户关联Guid
        /// </summary>
        public Guid? P_Business_flow_form_user_code
        {
            set { _p_business_flow_form_user_code = value; }
            get { return _p_business_flow_form_user_code; }
        }
        /// <summary>
        /// 业务流程表单GUID，外键
        /// </summary>
        public Guid? P_Business_flow_form_code
        {
            set { _p_business_flow_form_code = value; }
            get { return _p_business_flow_form_code; }
        }

        /// <summary>
        /// 用户Guid，外键
        /// </summary>
        public Guid? P_Business_flow_form_user_user
        {
            set { _p_business_flow_form_user_user = value; }
            get { return _p_business_flow_form_user_user; }
        }

        /// <summary>
        /// 是否删除，1为已删除；0为未删除
        /// </summary>
        public bool P_Business_flow_form_user_isdelete
        {
            set { _p_business_flow_form_user_isdelete = value; }
            get { return _p_business_flow_form_user_isdelete; }
        }
        /// <summary>
        /// 创建人Guid
        /// </summary>
        public Guid? P_Business_flow_form_user_creator
        {
            set { _p_business_flow_form_user_creator = value; }
            get { return _p_business_flow_form_user_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? P_Business_flow_form_user_createTime
        {
            set { _p_business_flow_form_user_createtime = value; }
            get { return _p_business_flow_form_user_createtime; }
        }
        #endregion Model

    }
}
