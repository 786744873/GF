using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 法院表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/04/28
    /// </summary>
    [Serializable]
    public partial class C_Court
    {
        public C_Court()
        { }
        #region Model
        private int _c_court_id;
        private Guid? _c_court_code;
        private string _c_court_number;
        private string _c_court_name;
        private Guid? _c_court_area;
        private string _c_court_url;
        private string _c_court_address;
        private string _c_court_remark;
        private int? _c_court_isdelete;
        private Guid? _c_court_userid;
        private DateTime? _c_court_cdate;
        private string _c_court_area_name;
        private bool? _c_court_isAllocate;
        private string _c_court_regions;
        /// <summary>
        /// 法院内码, 主键，自增
        /// </summary>
        public int C_Court_id
        {
            get { return _c_court_id; }
            set { _c_court_id = value; }
        }

        /// <summary>
        /// 法院编码
        /// </summary>
        public Guid? C_Court_code
        {
            get { return _c_court_code; }
            set { _c_court_code = value; }
        }

        /// <summary>
        /// 法院代码
        /// </summary>
        public string C_Court_number
        {
            get { return _c_court_number; }
            set { _c_court_number = value; }
        }

        /// <summary>
        /// 法院名称
        /// </summary>
        public string C_Court_name
        {
            get { return _c_court_name; }
            set { _c_court_name = value; }
        }

        /// <summary>
        /// 法院区域GUID
        /// </summary>
        public Guid? C_Court_area
        {
            get { return _c_court_area; }
            set { _c_court_area = value; }
        }

        /// <summary>
        /// 法院网址
        /// </summary>
        public string C_Court_url
        {
            get { return _c_court_url; }
            set { _c_court_url = value; }
        }

        /// <summary>
        /// 法院地址
        /// </summary>
        public string C_Court_address
        {
            get { return _c_court_address; }
            set { _c_court_address = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string C_Court_remark
        {
            get { return _c_court_remark; }
            set { _c_court_remark = value; }
        }

        /// <summary>
        /// 是否删除0-否，1-是
        /// </summary>
        public int? C_Court_isdelete
        {
            get { return _c_court_isdelete; }
            set { _c_court_isdelete = value; }
        }

        /// <summary>
        /// 创建人,外键，关联用户ID
        /// </summary>
        public Guid? C_Court_userid
        {
            get { return _c_court_userid; }
            set { _c_court_userid = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Court_cdate
        {
            get { return _c_court_cdate; }
            set { _c_court_cdate = value; }
        }
        /// <summary>
        /// 虚拟字段（区域名称）
        /// </summary>
        public string C_Court_area_name
        {
            get { return _c_court_area_name; }
            set { _c_court_area_name = value; }
        }
        /// <summary>
        /// 是否分配
        /// </summary>
        public bool? C_Court_isAllocate
        {
            get { return _c_court_isAllocate; }
            set { _c_court_isAllocate = value; }
        }

        /// <summary>
        /// 区域（虚拟字段）
        /// </summary>
        public string C_Court_regions
        {
            get { return _c_court_regions; }
            set { _c_court_regions = value; }
        }
        
        #endregion
    }
}
