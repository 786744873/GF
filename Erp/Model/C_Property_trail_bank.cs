using System;
namespace CommonService.Model
{
    /// <summary>
    /// 财产线索银行表表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_Property_trail_bank
	{
		public C_Property_trail_bank()
		{}
		#region Model
		private int _c_property_trail_bank_id;
		private int? _c_property_trail_bank_type;
		private Guid? _c_property_trail_bank_belongs;
		private string _c_property_trail_bank_code;
		private string _c_property_trail_bank_name;
		private int? _c_property_trail_bank_accounttype;
		private string _c_property_trail_bank_accountnumber;
		private decimal? _c_property_trail_bank_money;
		private DateTime? _c_property_trail_bank_rtime;
		private Guid? _c_property_trail_bank_creator;
		private DateTime? _c_property_trail_bank_createtime;
		private int? _c_property_trail_bank_isdelete;
		/// <summary>
		/// 银行财产线索ID
		/// </summary>
		public int C_Property_trail_bank_id
		{
			set{ _c_property_trail_bank_id=value;}
			get{return _c_property_trail_bank_id;}
		}
		/// <summary>
		/// 银行财产线索类型，外键，关联parameter表，比如对手财产状况、法官财产状况
		/// </summary>
		public int? C_Property_trail_bank_type
		{
			set{ _c_property_trail_bank_type=value;}
			get{return _c_property_trail_bank_type;}
		}
		/// <summary>
		/// 银行财产线索所属，比如联系人GUID、法官GUID等
		/// </summary>
		public Guid? C_Property_trail_bank_belongs
		{
			set{ _c_property_trail_bank_belongs=value;}
			get{return _c_property_trail_bank_belongs;}
		}
		/// <summary>
		/// 银行线索编码
		/// </summary>
		public string C_Property_trail_bank_code
		{
			set{ _c_property_trail_bank_code=value;}
			get{return _c_property_trail_bank_code;}
		}
		/// <summary>
		/// 银行名称
		/// </summary>
		public string C_Property_trail_bank_name
		{
			set{ _c_property_trail_bank_name=value;}
			get{return _c_property_trail_bank_name;}
		}
		/// <summary>
		/// 外键，帐号类型，关联parameter表
		/// </summary>
		public int? C_Property_trail_bank_AccountType
		{
			set{ _c_property_trail_bank_accounttype=value;}
			get{return _c_property_trail_bank_accounttype;}
		}
		/// <summary>
		/// 帐号
		/// </summary>
		public string C_Property_trail_bank_accountNumber
		{
			set{ _c_property_trail_bank_accountnumber=value;}
			get{return _c_property_trail_bank_accountnumber;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? C_Property_trail_bank_money
		{
			set{ _c_property_trail_bank_money=value;}
			get{return _c_property_trail_bank_money;}
		}
		/// <summary>
		/// 调取时间
		/// </summary>
		public DateTime? C_Property_trail_bank_rTime
		{
			set{ _c_property_trail_bank_rtime=value;}
			get{return _c_property_trail_bank_rtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Property_trail_bank_creator
		{
			set{ _c_property_trail_bank_creator=value;}
			get{return _c_property_trail_bank_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Property_trail_bank_createTime
		{
			set{ _c_property_trail_bank_createtime=value;}
			get{return _c_property_trail_bank_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Property_trail_bank_isDelete
		{
			set{ _c_property_trail_bank_isdelete=value;}
			get{return _c_property_trail_bank_isdelete;}
		}
		#endregion Model

	}
}

