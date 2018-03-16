using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件--费用承担表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/05
    /// </summary>
	[Serializable]
	public partial class B_BearToPay
	{
		public B_BearToPay()
		{}
		#region Model
		private int _b_beartopay_id;
		private Guid? _b_beartopay_code;
		private Guid? _b_case_code;
		private int? _b_beartopay_ctypes;
		private int? _b_beartopay_pmethod;
        private string _b_beartopay_pmethod_name;
		private decimal? _b_beartopay_figure;
		private string _b_beartopay_explain;
		private Guid? _b_beartopay_creator;
		private DateTime? _b_beartopay_createtime;
		private int? _b_beartopay_isdelete;
        private string _b_beartopay_ctypes_name;
        private int? _b_beartopay_ctypes_id;
        
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_BearToPay_id
		{
			set{ _b_beartopay_id=value;}
			get{return _b_beartopay_id;}
		}
		/// <summary>
		/// 编码GUID
		/// </summary>
		public Guid? B_BearToPay_code
		{
			set{ _b_beartopay_code=value;}
			get{return _b_beartopay_code;}
		}
		/// <summary>
		/// 所关联案件GUID
		/// </summary>
		public Guid? B_Case_code
		{
			set{ _b_case_code=value;}
			get{return _b_case_code;}
		}
		/// <summary>
		/// 费用类型，关联parameter表
		/// </summary>
		public int? B_BearToPay_ctypes
		{
			set{ _b_beartopay_ctypes=value;}
			get{return _b_beartopay_ctypes;}
		}
		/// <summary>
		/// 支付方式，关联parameter表
		/// </summary>
		public int? B_BearToPay_pmethod
		{
			set{ _b_beartopay_pmethod=value;}
			get{return _b_beartopay_pmethod;}
		}
        /// <summary>
        /// 支付方式名称（虚拟字段）
        /// </summary>
        public string B_BearToPay_pmethod_name
        {
            get { return _b_beartopay_pmethod_name; }
            set { _b_beartopay_pmethod_name = value; }
        }
        
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? B_BearToPay_figure
		{
			set{ _b_beartopay_figure=value;}
			get{return _b_beartopay_figure;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string B_BearToPay_explain
		{
			set{ _b_beartopay_explain=value;}
			get{return _b_beartopay_explain;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_BearToPay_creator
		{
			set{ _b_beartopay_creator=value;}
			get{return _b_beartopay_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_BearToPay_createTime
		{
			set{ _b_beartopay_createtime=value;}
			get{return _b_beartopay_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_BearToPay_isDelete
		{
			set{ _b_beartopay_isdelete=value;}
			get{return _b_beartopay_isdelete;}
		}
        /// <summary>
        /// 费用类型名称（虚拟字段）
        /// </summary>
        public string B_BearToPay_ctypes_name
        {
            get { return _b_beartopay_ctypes_name; }
            set { _b_beartopay_ctypes_name = value; }
        }
        /// <summary>
        /// 费用类型关联parameter表ID（虚拟字段）
        /// </summary>
        public int? B_BearToPay_ctypes_id
        {
            get { return _b_beartopay_ctypes_id; }
            set { _b_beartopay_ctypes_id = value; }
        }
		#endregion Model

	}
}

