using System;
namespace CommonService.Model
{
    /// <summary>
    /// 对手权力关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_CRival_right
	{
		public C_CRival_right()
		{}
		#region Model
		private int _c_crival_right_id;
		private Guid? _c_crival_code;
		private string _c_crival_right_agency;
		private string _c_crival_right_person;
		private string _c_crival_right_affairs;
		private string _c_crival_right_policy;
		private DateTime? _c_crival_right_createtime;
		private Guid? _c_crival_right_creator;
		private int? _c_crival_right_isdelete;
		/// <summary>
		/// 对手权利关联ID
		/// </summary>
		public int C_CRival_right_id
		{
			set{ _c_crival_right_id=value;}
			get{return _c_crival_right_id;}
		}
		/// <summary>
		/// 外键，公司对手编码
		/// </summary>
		public Guid? C_CRival_code
		{
			set{ _c_crival_code=value;}
			get{return _c_crival_code;}
		}
		/// <summary>
		/// 机构
		/// </summary>
		public string C_CRival_right_agency
		{
			set{ _c_crival_right_agency=value;}
			get{return _c_crival_right_agency;}
		}
		/// <summary>
		/// 人物
		/// </summary>
		public string C_CRival_right_person
		{
			set{ _c_crival_right_person=value;}
			get{return _c_crival_right_person;}
		}
		/// <summary>
		/// 事务
		/// </summary>
		public string C_CRival_right_affairs
		{
			set{ _c_crival_right_affairs=value;}
			get{return _c_crival_right_affairs;}
		}
		/// <summary>
		/// 政策
		/// </summary>
		public string C_CRival_right_Policy
		{
			set{ _c_crival_right_policy=value;}
			get{return _c_crival_right_policy;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_CRival_right_createTime
		{
			set{ _c_crival_right_createtime=value;}
			get{return _c_crival_right_createtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_CRival_right_creator
		{
			set{ _c_crival_right_creator=value;}
			get{return _c_crival_right_creator;}
		}
		/// <summary>
		/// 是否删除 
		/// </summary>
		public int? C_CRival_right_isDelete
		{
			set{ _c_crival_right_isdelete=value;}
			get{return _c_crival_right_isdelete;}
		}
		#endregion Model

	}
}

