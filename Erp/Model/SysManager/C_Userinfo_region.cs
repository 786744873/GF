using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
    /// 用户----区域中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Userinfo_region
	{
        public C_Userinfo_region()
		{}
		#region Model
        private Guid? _c_userinfo_code;
        private Guid? _c_region_code;
        private string _c_userinfo_name;
        private string  _c_region_name;
        
        
        /// <summary>
        /// 用户Guid
        /// </summary>
        public Guid? C_Userinfo_code
        {
            get { return _c_userinfo_code; }
            set { _c_userinfo_code = value; }
        }
        /// <summary>
        /// 区域编码
        /// </summary>
        public Guid? C_Region_code
        {
            get { return _c_region_code; }
            set { _c_region_code = value; }
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
        /// 区域名称
        /// </summary>
        public string C_Region_name
        {
            get { return _c_region_name; }
            set { _c_region_name = value; }
        }
		#endregion Model

	}
}

