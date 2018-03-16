using System;
namespace CommonService.Model
{
    /// <summary>
    /// 法律管理水平表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_CRival_legal_management_level
	{
		public C_CRival_legal_management_level()
		{}
		#region Model
		private int _c_crival_legal_management_level_id;
		private Guid? _c_crival_code;
		private int? _c_crival_legal_management_level_tf;
		private string _c_crival_legal_management_level_nt;
		private int? _c_crival_legal_management_level_ms;
		private int? _c_crival_legal_management_level_habit;
		private int? _c_crival_legal_management_level_sduty;
		private int? _c_crival_legal_management_level_am;
		private DateTime? _c_crival_legal_management_level_craetetime;
		private Guid? _c_crival_legal_management_level_creator;
		private int? _c_crival_legal_management_level_isdelete;
		/// <summary>
		/// 管理水平ID
		/// </summary>
		public int C_CRival_legal_management_level_id
		{
			set{ _c_crival_legal_management_level_id=value;}
			get{return _c_crival_legal_management_level_id;}
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
		/// 格式文本，外键，关联parameter表
		/// </summary>
		public int? C_CRival_legal_management_level_tf
		{
			set{ _c_crival_legal_management_level_tf=value;}
			get{return _c_crival_legal_management_level_tf;}
		}
		/// <summary>
		/// 协商文本
		/// </summary>
		public string C_CRival_legal_management_level_nt
		{
			set{ _c_crival_legal_management_level_nt=value;}
			get{return _c_crival_legal_management_level_nt;}
		}
		/// <summary>
		/// 管理风格，外键，关联parameter表
		/// </summary>
		public int? C_CRival_legal_management_level_ms
		{
			set{ _c_crival_legal_management_level_ms=value;}
			get{return _c_crival_legal_management_level_ms;}
		}
		/// <summary>
		/// 使用习惯，外键，关联parameter表
		/// </summary>
		public int? C_CRival_legal_management_level_habit
		{
			set{ _c_crival_legal_management_level_habit=value;}
			get{return _c_crival_legal_management_level_habit;}
		}
		/// <summary>
		/// 印章责任规避，外键，关联parameter表
		/// </summary>
		public int? C_CRival_legal_management_level_sduty
		{
			set{ _c_crival_legal_management_level_sduty=value;}
			get{return _c_crival_legal_management_level_sduty;}
		}
		/// <summary>
		/// 诉讼管理，外键，关联parameter表
		/// </summary>
		public int? C_CRival_legal_management_level_am
		{
			set{ _c_crival_legal_management_level_am=value;}
			get{return _c_crival_legal_management_level_am;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_CRival_legal_management_level_craeteTime
		{
			set{ _c_crival_legal_management_level_craetetime=value;}
			get{return _c_crival_legal_management_level_craetetime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_CRival_legal_management_level_creator
		{
			set{ _c_crival_legal_management_level_creator=value;}
			get{return _c_crival_legal_management_level_creator;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_CRival_legal_management_level_isDelete
		{
			set{ _c_crival_legal_management_level_isdelete=value;}
			get{return _c_crival_legal_management_level_isdelete;}
		}
		#endregion Model

	}
}

