using System;
namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 流程表--岗位表中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	[Serializable]
	public partial class P_Flow_post
	{
		public P_Flow_post()
		{}
		#region Model
        private int _p_flow_post_id;
		private Guid? _p_flow_code;
		private Guid? _f_post_code;
        private string _c_post_name;
		private int? _p_flow_post_isdelete;
		private Guid? _p_flow_post_creator;
        private DateTime? _p_flow_post_createtime;
        /// <summary>
        /// 主键ＩＤ
        /// </summary>
        public int P_Flow_post_id
        {
            get { return _p_flow_post_id; }
            set { _p_flow_post_id = value; }
        }
		/// <summary>
		/// 流程GUID
		/// </summary>
		public Guid? P_Flow_code
		{
			set{ _p_flow_code=value;}
			get{return _p_flow_code;}
		}
		/// <summary>
		/// 岗位GUID
		/// </summary>
        public Guid? F_Post_code
		{
			set{ _f_post_code=value;}
			get{return _f_post_code;}
		}
        /// <summary>
        /// 岗位名称(虚拟属性)
        /// </summary>
        public string C_Post_name
        {
            get { return _c_post_name; }
            set { _c_post_name = value; }
        }
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? P_Flow_post_isDelete
		{
			set{ _p_flow_post_isdelete=value;}
			get{return _p_flow_post_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? P_Flow_post_creator
		{
			set{ _p_flow_post_creator=value;}
			get{return _p_flow_post_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? P_Flow_post_createTime
		{
			set{ _p_flow_post_createtime=value;}
			get{return _p_flow_post_createtime;}
		}
		#endregion Model

	}
}

