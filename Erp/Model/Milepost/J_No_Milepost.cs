
using System;
namespace CommonService.Model.Milepost
{
    /// <summary>
    /// J_No_Milepost:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class J_No_Milepost
    {
        public J_No_Milepost()
        { }
        #region Model
        private int _j_no_milepost_id;
        private Guid _j_no_milepost_code;
        private DateTime _j_no_milepost_jtime = DateTime.Now;
        private Guid _j_no_milepost_zuserinfo_code;
        private Guid _j_no_milepost_depuserinfo_code;
        private Guid _j_no_milepost_generuserinfo_code;
        private string _j_no_milepost_casenumber;
        private string _j_no_milepost_documentpo;
        private string _j_no_milepost_filing;
        private string _j_no_milepost_preservation;
        private Guid _j_no_milepost_auditor;
        private string _j_no_milepost_tjmessagetype;
        private string _j_no_milepost_tjmessagecontent;
        private string _j_no_milepost_admessagetype;
        private string _j_no_milepost_admessagecontent;
        private int _j_no_milepost_adstatus;
        private DateTime _j_no_milepost_createtime = DateTime.Now;
        private bool _j_no_milepost_isdelete = false;
        private DateTime? _j_no_milepost_jtime1;
        private string _j_no_milepost_clientCrival;
        private string _j_project;


        public string J_No_Milepost_Z_TJMessageType { get; set; }

        public string J_No_Milepost_Z_TJMessageContent { get; set; }

        public string J_No_Milepost_Dep_TJMessageType { get; set; }

        public string J_No_Milepost_Dep_TJMessageContent { get; set; }


        public string J_No_Milepost_Z_AdMessageType { get; set; }

        public string J_No_Milepost_Z_AdMessageContent { get; set; }


        public int J_No_Milepost_Z_AdStatus { get; set; }

        public string J_No_Milepost_Dep_AdMessageType { get; set; }

        public string J_No_Milepost_Dep_AdMessageContent { get; set; }

        public int J_No_Milepost_Dep_AdStatus { get; set; }

        public string J_No_Milepost_AuditorName { get; set; }


        public string J_No_Milepost_ZUserinfo_codeName { get; set; }

        public string J_No_Milepost_DepUserinfo_codeName { get; set; }


        public string J_No_Milepost_GenerUserinfo_codeName { get; set; }


        public string C_Customer_yg { get; set; }

        public string C_Customer_BG_1 { get; set; }

        public string C_Customer_BG_2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int J_No_Milepost_id
        {
            set { _j_no_milepost_id = value; }
            get { return _j_no_milepost_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_No_Milepost_code
        {
            set { _j_no_milepost_code = value; }
            get { return _j_no_milepost_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime J_No_Milepost_JTime
        {
            set { _j_no_milepost_jtime = value; }
            get { return _j_no_milepost_jtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_No_Milepost_ZUserinfo_code
        {
            set { _j_no_milepost_zuserinfo_code = value; }
            get { return _j_no_milepost_zuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_No_Milepost_DepUserinfo_code
        {
            set { _j_no_milepost_depuserinfo_code = value; }
            get { return _j_no_milepost_depuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_No_Milepost_GenerUserinfo_code
        {
            set { _j_no_milepost_generuserinfo_code = value; }
            get { return _j_no_milepost_generuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_CaseNumber
        {
            set { _j_no_milepost_casenumber = value; }
            get { return _j_no_milepost_casenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_DocumentPo
        {
            set { _j_no_milepost_documentpo = value; }
            get { return _j_no_milepost_documentpo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_Filing
        {
            set { _j_no_milepost_filing = value; }
            get { return _j_no_milepost_filing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_Preservation
        {
            set { _j_no_milepost_preservation = value; }
            get { return _j_no_milepost_preservation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_No_Milepost_Auditor
        {
            set { _j_no_milepost_auditor = value; }
            get { return _j_no_milepost_auditor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_TJMessageType
        {
            set { _j_no_milepost_tjmessagetype = value; }
            get { return _j_no_milepost_tjmessagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_TJMessageContent
        {
            set { _j_no_milepost_tjmessagecontent = value; }
            get { return _j_no_milepost_tjmessagecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_AdMessageType
        {
            set { _j_no_milepost_admessagetype = value; }
            get { return _j_no_milepost_admessagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_No_Milepost_AdMessageContent
        {
            set { _j_no_milepost_admessagecontent = value; }
            get { return _j_no_milepost_admessagecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int J_No_Milepost_AdStatus
        {
            set { _j_no_milepost_adstatus = value; }
            get { return _j_no_milepost_adstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime J_No_Milepost_createTime
        {
            set { _j_no_milepost_createtime = value; }
            get { return _j_no_milepost_createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool J_No_Milepost_isDelete
        {
            set { _j_no_milepost_isdelete = value; }
            get { return _j_no_milepost_isdelete; }
        }
        /// <summary>
        /// 稽查时间1（虚拟字段，列表查询用到）
        /// </summary>
        public DateTime? J_No_Milepost_JTime1
        {
            get { return _j_no_milepost_jtime1; }
            set { _j_no_milepost_jtime1 = value; }
        }
        /// <summary>
        /// 委托人/对方当事人（虚拟字段，列表查询用到）
        /// </summary>
        public string J_No_Milepost_clientCrival
        {
            get { return _j_no_milepost_clientCrival; }
            set { _j_no_milepost_clientCrival = value; }
        }
        public string ProjectName
        {
            get { return _j_project; }
            set { _j_project = value; }
        }
        #endregion Model

    }
}

