using System;
namespace CommonService.Model.FinanceManager
{
    /// <summary>
    /// 凭证信息-子表单中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/08/25
    /// </summary>
	[Serializable]
	public partial class C_Voucher_Form
	{
		public C_Voucher_Form()
		{}
		#region Model
		private Guid? _f_form_code;
		private Guid? _c_voucher_code;
		/// <summary>
		/// 表单Guid
		/// </summary>
		public Guid? F_Form_code
		{
			set{ _f_form_code=value;}
			get{return _f_form_code;}
		}
		/// <summary>
		/// 凭证信息Guid
		/// </summary>
		public Guid? C_Voucher_code
		{
			set{ _c_voucher_code=value;}
			get{return _c_voucher_code;}
		}
		#endregion Model

	}
}

