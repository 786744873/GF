using System;
namespace CommonService.Model
{
	/// <summary>
	/// 对手公司变更:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/05
	/// </summary>
	[Serializable]
	public partial class C_CRival_change
	{
		public C_CRival_change()
		{}
		#region Model
		private int _c_crival_change_id;
		private Guid? _c_crival_code;
		private string _c_crival_change_matter;
		private DateTime? _c_crival_change_date;
		private string _c_crival_change_content;
		private Guid? _c_crival_change_creator;
		private DateTime? _c_crival_change_createtime;
		private int? _c_crival_change_isdelete;
		/// <summary>
		/// 对手公司变更ID
		/// </summary>
		public int C_CRival_change_id
		{
			set{ _c_crival_change_id=value;}
			get{return _c_crival_change_id;}
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
		/// 车辆财产线索所属，比如联系人GUID、法官GUID等
		/// </summary>
		public string C_CRival_change_matter
		{
			set{ _c_crival_change_matter=value;}
			get{return _c_crival_change_matter;}
		}
		/// <summary>
		/// 变更时间
		/// </summary>
		public DateTime? C_CRival_change_date
		{
			set{ _c_crival_change_date=value;}
			get{return _c_crival_change_date;}
		}
		/// <summary>
		/// 变更内容
		/// </summary>
		public string C_CRival_change_content
		{
			set{ _c_crival_change_content=value;}
			get{return _c_crival_change_content;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_CRival_change_creator
		{
			set{ _c_crival_change_creator=value;}
			get{return _c_crival_change_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_CRival_change_createTime
		{
			set{ _c_crival_change_createtime=value;}
			get{return _c_crival_change_createtime;}
		}
		/// <summary>
		/// 是否 删除
		/// </summary>
		public int? C_CRival_change_isDelete
		{
			set{ _c_crival_change_isdelete=value;}
			get{return _c_crival_change_isdelete;}
		}
		#endregion Model

	}
}

