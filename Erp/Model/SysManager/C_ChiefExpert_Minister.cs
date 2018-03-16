using System;
namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 首席专家--部长关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/09/14
    /// </summary>
	[Serializable]
	public partial class C_ChiefExpert_Minister
	{
		public C_ChiefExpert_Minister()
		{}
		#region Model
		private int _c_chiefexpert_minister_id;
		private Guid? _c_chiefexpert_code;
		private Guid? _c_minister_code;
		/// <summary>
		/// 
		/// </summary>
		public int C_ChiefExpert_Minister_id
		{
			set{ _c_chiefexpert_minister_id=value;}
			get{return _c_chiefexpert_minister_id;}
		}
		/// <summary>
		/// 首席专家GUID
		/// </summary>
		public Guid? C_ChiefExpert_Code
		{
			set{ _c_chiefexpert_code=value;}
			get{return _c_chiefexpert_code;}
		}
		/// <summary>
		/// 部长GUID
		/// </summary>
		public Guid? C_Minister_Code
		{
			set{ _c_minister_code=value;}
			get{return _c_minister_code;}
		}
		#endregion Model

	}
}

