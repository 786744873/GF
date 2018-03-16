using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
    /// 用户----案件类型中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Userinfo_case_type
	{
        public C_Userinfo_case_type()
		{}
		#region Model
        private Guid? _c_userinfo_code;
        private string _c_userinfo_name;
        
        private int? _c_parameters_id;
        private string _c_parameters_name;
        /// <summary>
        /// 用户Guid
        /// </summary>
        public Guid? C_Userinfo_code
        {
            get { return _c_userinfo_code; }
            set { _c_userinfo_code = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string C_Userinfo_name
        {
            get { return _c_userinfo_name; }
            set { _c_userinfo_name = value; }
        }
        /// <summary>
        /// 案件类型ID
        /// </summary>
        public int? C_Parameters_id
        {
            get { return _c_parameters_id; }
            set { _c_parameters_id = value; }
        }
        /// <summary>
        /// 案件类型名称(虚拟属性)
        /// </summary>
        public string C_Parameters_name
        {
            get { return _c_parameters_name; }
            set { _c_parameters_name = value; }
        }
		#endregion Model

	}
}

