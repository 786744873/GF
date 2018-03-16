using System;
namespace CommonService.Model
{
    /// <summary>
    /// 查询条件记录表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/12/03
    /// </summary>
	[Serializable]
	public partial class C_SearchConditionRecord
	{
		public C_SearchConditionRecord()
		{}
		#region Model
		private int _c_searchconditionrecord_id;
		private int? _c_searchconditionrecord_belonging;
		private Guid? _c_searchconditionrecord_group;
		private string _c_searchconditionrecord_key;
		private string _c_searchconditionrecord_value;
		/// <summary>
		/// 
		/// </summary>
		public int C_SearchConditionRecord_id
		{
			set{ _c_searchconditionrecord_id=value;}
			get{return _c_searchconditionrecord_id;}
		}
		/// <summary>
		/// 查询条件所属业务，关联C_Parameter表,外键
		/// </summary>
		public int? C_SearchConditionRecord_belonging
		{
			set{ _c_searchconditionrecord_belonging=value;}
			get{return _c_searchconditionrecord_belonging;}
		}
		/// <summary>
		/// 查询条件所属分组
		/// </summary>
		public Guid? C_SearchConditionRecord_group
		{
			set{ _c_searchconditionrecord_group=value;}
			get{return _c_searchconditionrecord_group;}
		}
		/// <summary>
		/// 查询条件Key
		/// </summary>
		public string C_SearchConditionRecord_key
		{
			set{ _c_searchconditionrecord_key=value;}
			get{return _c_searchconditionrecord_key;}
		}
		/// <summary>
		/// 查询条件Value
		/// </summary>
		public string C_SearchConditionRecord_value
		{
			set{ _c_searchconditionrecord_value=value;}
			get{return _c_searchconditionrecord_value;}
		}
		#endregion Model

	}
}

