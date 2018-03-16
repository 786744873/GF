using System;
namespace CommonService.Model
{
    /// <summary>
    /// 涉案项目表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	[Serializable]
	public partial class C_Involved_project
	{
		public C_Involved_project()
		{}
		#region Model
		private int _c_involved_project_id;
		private Guid? _c_involved_project_code;
		private string _c_involved_project_number;
		private string _c_involved_project_name;
		private string _c_involved_project_address;
		private string _c_involved_project_type;
		private decimal? _c_involved_project_scale;
		private decimal? _c_involved_project_investment;
		private Guid? _c_involved_project_creator;
		private DateTime? _c_involved_project_createtime;
		private int? _c_involved_project_isdelete;
		/// <summary>
		/// 主键，自增长，涉案项目ID
		/// </summary>
		public int C_Involved_project_id
		{
			set{ _c_involved_project_id=value;}
			get{return _c_involved_project_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Involved_project_code
		{
			set{ _c_involved_project_code=value;}
			get{return _c_involved_project_code;}
		}
		/// <summary>
		/// 涉案项目编码，可自定义
		/// </summary>
		public string C_Involved_project_number
		{
			set{ _c_involved_project_number=value;}
			get{return _c_involved_project_number;}
		}
		/// <summary>
		/// 涉案项目名称
		/// </summary>
		public string C_Involved_project_name
		{
			set{ _c_involved_project_name=value;}
			get{return _c_involved_project_name;}
		}
		/// <summary>
		/// 地点
		/// </summary>
		public string C_Involved_project_address
		{
			set{ _c_involved_project_address=value;}
			get{return _c_involved_project_address;}
		}
		/// <summary>
		/// 工程类别
		/// </summary>
		public string C_Involved_project_type
		{
			set{ _c_involved_project_type=value;}
			get{return _c_involved_project_type;}
		}
		/// <summary>
		/// 工程建设规模，单位：㎡
		/// </summary>
		public decimal? C_Involved_project_scale
		{
			set{ _c_involved_project_scale=value;}
			get{return _c_involved_project_scale;}
		}
		/// <summary>
		/// 工程建设投资
		/// </summary>
		public decimal? C_Involved_project_Investment
		{
			set{ _c_involved_project_investment=value;}
			get{return _c_involved_project_investment;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Involved_project_creator
		{
			set{ _c_involved_project_creator=value;}
			get{return _c_involved_project_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Involved_project_createTime
		{
			set{ _c_involved_project_createtime=value;}
			get{return _c_involved_project_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Involved_project_isDelete
		{
			set{ _c_involved_project_isdelete=value;}
			get{return _c_involved_project_isdelete;}
		}
		#endregion Model

	}
}

