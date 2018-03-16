using System;
namespace CommonService.Model
{
    /// <summary>
    /// 法院律师关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/08/22
    /// </summary>
	[Serializable]
	public partial class C_Court_Lawyer
	{
		public C_Court_Lawyer()
		{}
		#region Model
		private int _c_court_lawyer_id;
		private Guid? _c_court_lawyer_code;
		private Guid? _c_lawyer;
		private Guid? _c_court;
		private bool _c_court_lawyer_isdelete;
		private Guid? _c_court_lawyer_creator;
		private DateTime? _c_court_lawyer_creattime;
		/// <summary>
		/// ID
		/// </summary>
		public int C_Court_Lawyer_id
		{
			set{ _c_court_lawyer_id=value;}
			get{return _c_court_lawyer_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Court_Lawyer_code
		{
			set{ _c_court_lawyer_code=value;}
			get{return _c_court_lawyer_code;}
		}
		/// <summary>
		/// 律师GUID（子用户GUID）
		/// </summary>
		public Guid? C_Lawyer
		{
			set{ _c_lawyer=value;}
			get{return _c_lawyer;}
		}
		/// <summary>
		/// 法院GUID
		/// </summary>
		public Guid? C_Court
		{
			set{ _c_court=value;}
			get{return _c_court;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool C_Court_Lawyer_isDelete
		{
			set{ _c_court_lawyer_isdelete=value;}
			get{return _c_court_lawyer_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Court_Lawyer_creator
		{
			set{ _c_court_lawyer_creator=value;}
			get{return _c_court_lawyer_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Court_Lawyer_creatTime
		{
			set{ _c_court_lawyer_creattime=value;}
			get{return _c_court_lawyer_creattime;}
		}
		#endregion Model

	}
}

