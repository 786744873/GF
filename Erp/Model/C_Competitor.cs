using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 竞争对手表表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/04/23
    /// </summary>
    [Serializable]
    public partial class C_Competitor
    {
        public C_Competitor()
        { }
        #region Model
        private int _c_competitor_id;
        private Guid? _c_competitor_code;
        private string _c_competitor_number;
        private string _c_competitor_name;
        private Guid? _c_competitor_empNumber;
        private string _c_competitor_empNumber_name;
        private string _c_competitor_country;
        private string _c_competitor_area;
        private string _c_competitor_province;
        private string _c_competitor_city;
        private string _c_competitor_address;
        private string _c_competitor_url;
        private string _c_competitor_levelRisk;
        private int? _c_competitor_status;
        private string _c_competitor_mainProject;
        private string _c_competitor_advantageThat;
        private int? _c_competitor_failureMarks;
        private string _c_competitor_majorClient;
        private int? _c_competitor_deleted;
        private DateTime? _c_competitor_cTime;
        private Guid? _c_competitor_cUserID;
        private Guid? _c_competitor_region;

        /// <summary>
        /// 对手内码，主键，自增
        /// </summary>
        public int C_Competitor_id
        {
            get { return _c_competitor_id; }
            set { _c_competitor_id = value; }
        }

        /// <summary>
        /// 对手编码
        /// </summary>
        public Guid? C_Competitor_code
        {
            get { return _c_competitor_code; }
            set { _c_competitor_code = value; }
        }

        /// <summary>
        /// 对手代码
        /// </summary>
        public string C_Competitor_number
        {
            get { return _c_competitor_number; }
            set { _c_competitor_number = value; }
        }
        
        /// <summary>
        /// 对手名称
        /// </summary>
        public string C_Competitor_name
        {
            get { return _c_competitor_name; }
            set { _c_competitor_name = value; }
        }

        /// <summary>
        /// 专业顾问，外键
        /// </summary>
        public Guid? C_Competitor_empNumber
        {
            get { return _c_competitor_empNumber; }
            set { _c_competitor_empNumber = value; }
        }
        /// <summary>
        /// 专业顾问名称（虚拟字段）
        /// </summary>
        public string C_Competitor_empNumber_name
        {
            get { return _c_competitor_empNumber_name; }
            set { _c_competitor_empNumber_name = value; }
        }
        /// <summary>
        /// 国家
        /// </summary>
        public string C_Competitor_country
        {
            get { return _c_competitor_country; }
            set { _c_competitor_country = value; }
        }

        /// <summary>
        /// 地区
        /// </summary>
        public string C_Competitor_area
        {
            get { return _c_competitor_area; }
            set { _c_competitor_area = value; }
        }

        /// <summary>
        /// 省份
        /// </summary>
        public string C_Competitor_province
        {
            get { return _c_competitor_province; }
            set { _c_competitor_province = value; }
        }

        /// <summary>
        /// 城市
        /// </summary>
        public string C_Competitor_City
        {
            get { return _c_competitor_city; }
            set { _c_competitor_city = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string C_Competitor_Address
        {
            get { return _c_competitor_address; }
            set { _c_competitor_address = value; }
        }

        /// <summary>
        /// 公司网址
        /// </summary>
        public string C_Competitor_Url
        {
            get { return _c_competitor_url; }
            set { _c_competitor_url = value; }
        }

        /// <summary>
        /// 威胁程度，0-高,1-中,2-低
        /// </summary>
        public string C_Competitor_levelRisk
        {
            get { return _c_competitor_levelRisk; }
            set { _c_competitor_levelRisk = value; }
        }

        /// <summary>
        /// 状态，0-活跃，1—一般，2—不活跃
        /// </summary>
        public int? C_Competitor_Status
        {
            get { return _c_competitor_status; }
            set { _c_competitor_status = value; }
        }

        /// <summary>
        /// 主要产品
        /// </summary>
        public string C_Competitor_mainProject
        {
            get { return _c_competitor_mainProject; }
            set { _c_competitor_mainProject = value; }
        }

        /// <summary>
        /// 优势说明
        /// </summary>
        public string C_Competitor_advantageThat
        {
            get { return _c_competitor_advantageThat; }
            set { _c_competitor_advantageThat = value; }
        }

        /// <summary>
        /// 失效标志，0-失效，1-反失效
        /// </summary>
        public int? C_Competitor_FailureMarks
        {
            get { return _c_competitor_failureMarks; }
            set { _c_competitor_failureMarks = value; }
        }

        /// <summary>
        /// 主要客户，文本，手工录入
        /// </summary>
        public string C_Competitor_majorClient
        {
            get { return _c_competitor_majorClient; }
            set { _c_competitor_majorClient = value; }
        }

        /// <summary>
        /// 是否删除,0 - 否，1 - 是
        /// </summary>
        public int? C_Competitor_deleted
        {
            get { return _c_competitor_deleted; }
            set { _c_competitor_deleted = value; }
        }

        /// <summary>
        /// 创建日期,时间存当期系统时间
        /// </summary>
        public DateTime? C_Competitor_cTime
        {
            get { return _c_competitor_cTime; }
            set { _c_competitor_cTime = value; }
        }

        /// <summary>
        /// 创建人,关联U_user获取当前登录用户
        /// </summary>
        public Guid? C_Competitor_cUserID
        {
            get { return _c_competitor_cUserID; }
            set { _c_competitor_cUserID = value; }
        }
        /// <summary>
        /// 所属区域
        /// </summary>
        public Guid? C_Competitor_region
        {
            get { return _c_competitor_region; }
            set { _c_competitor_region = value; }
        }
        
        #endregion
    }
}
