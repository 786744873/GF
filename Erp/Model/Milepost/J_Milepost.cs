
using System;
namespace CommonService.Model.Milepost
{
    /// <summary>
    /// J_Milepost:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class J_Milepost
    {
        public J_Milepost()
        { }
        #region Model
        private int _j_milepost_id;
        private Guid _j_milepost_code;
        private DateTime _j_milepost_jtime = DateTime.Now;
        private Guid _j_milepost_organization_code;
        private Guid _j_milepost_zuserinfo_code;
        private Guid _j_milepost_xuserinfo_code;
        private Guid _j_milepost_depuserinfo_code;
        private Guid _j_milepost_generuserinfo_code;
        private string _j_milepost_casenumber;
        private string _j_milepost_documentpo;
        private string _j_milepost_filing;
        private string _j_milepost_preservation;
        private string _j_milepost_firstcomplete;
        private string _j_milepost_firstinstance;
        private string _j_milepost_conciliation;
        private string _j_milepost_prosecution;
        private string _j_milepost_verdict;
        private string _j_milepost_programscorey;
        private string _j_milepost_programscores;
        private string _j_milepost_entityscore;
        private string _j_milepost_casescore;
        private Guid _j_milepost_auditor;
        private string _j_milepost_tjmessagetype;
        private string _j_milepost_tjmessagecontent;
        private string _j_milepost_admessagetype;
        private string _j_milepost_admessagecontent;
        private int _j_milepost_adstatus;
        private DateTime _j_milepost_createtime = DateTime.Now;
        private bool _j_milepost_isdelete = false;
        private DateTime? _j_milepost_jtime1;
        private string _j_milepost_clientRival;
        private string _j_milepost_sponsorlawyer;
        private string _j_milepost_colawyer;
        private string _projectname;
        public string J_Milepost_AuditorName { get; set; }


        public string J_Milepost_ZUserinfo_codeName { get; set; }
        public string J_Milepost_XUserinfo_codeName { get; set; }

        public string J_Milepost_DepUserinfo_codeName { get; set; }


        public string J_Milepost_GenerUserinfo_codeName { get; set; }



        public string J_Milepost_Z_TJMessageType { get; set; }

        public string J_Milepost_Z_TJMessageContent { get; set; }

        public string J_Milepost_Dep_TJMessageType { get; set; }

        public string J_Milepost_Dep_TJMessageContent { get; set; }


        public string J_Milepost_Z_AdMessageType { get; set; }

        public string J_Milepost_Z_AdMessageContent { get; set; }


        public int J_Milepost_Z_AdStatus { get; set; }

        public string J_Milepost_Dep_AdMessageType { get; set; }

        public string J_Milepost_Dep_AdMessageContent { get; set; }

        public int J_Milepost_Dep_AdStatus { get; set; }




        public int J_Milepost_Type { get; set; }

        public string C_Customer_yg { get; set; }

        public string C_Customer_BG_1 { get; set; }

        public string C_Customer_BG_2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int J_Milepost_id
        {
            set { _j_milepost_id = value; }
            get { return _j_milepost_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_code
        {
            set { _j_milepost_code = value; }
            get { return _j_milepost_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime J_Milepost_JTime
        {
            set { _j_milepost_jtime = value; }
            get { return _j_milepost_jtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_Organization_code
        {
            set { _j_milepost_organization_code = value; }
            get { return _j_milepost_organization_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_ZUserinfo_code
        {
            set { _j_milepost_zuserinfo_code = value; }
            get { return _j_milepost_zuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_XUserinfo_code
        {
            set { _j_milepost_xuserinfo_code = value; }
            get { return _j_milepost_xuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_DepUserinfo_code
        {
            set { _j_milepost_depuserinfo_code = value; }
            get { return _j_milepost_depuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_GenerUserinfo_code
        {
            set { _j_milepost_generuserinfo_code = value; }
            get { return _j_milepost_generuserinfo_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_CaseNumber
        {
            set { _j_milepost_casenumber = value; }
            get { return _j_milepost_casenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_DocumentPo
        {
            set { _j_milepost_documentpo = value; }
            get { return _j_milepost_documentpo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Filing
        {
            set { _j_milepost_filing = value; }
            get { return _j_milepost_filing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Preservation
        {
            set { _j_milepost_preservation = value; }
            get { return _j_milepost_preservation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Firstcomplete
        {
            set { _j_milepost_firstcomplete = value; }
            get { return _j_milepost_firstcomplete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Firstinstance
        {
            set { _j_milepost_firstinstance = value; }
            get { return _j_milepost_firstinstance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Conciliation
        {
            set { _j_milepost_conciliation = value; }
            get { return _j_milepost_conciliation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Prosecution
        {
            set { _j_milepost_prosecution = value; }
            get { return _j_milepost_prosecution; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_Verdict
        {
            set { _j_milepost_verdict = value; }
            get { return _j_milepost_verdict; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_ProgramScoreY
        {
            set { _j_milepost_programscorey = value; }
            get { return _j_milepost_programscorey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_ProgramScoreS
        {
            set { _j_milepost_programscores = value; }
            get { return _j_milepost_programscores; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_EntityScore
        {
            set { _j_milepost_entityscore = value; }
            get { return _j_milepost_entityscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_CaseScore
        {
            set { _j_milepost_casescore = value; }
            get { return _j_milepost_casescore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid J_Milepost_Auditor
        {
            set { _j_milepost_auditor = value; }
            get { return _j_milepost_auditor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_TJMessageType
        {
            set { _j_milepost_tjmessagetype = value; }
            get { return _j_milepost_tjmessagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_TJMessageContent
        {
            set { _j_milepost_tjmessagecontent = value; }
            get { return _j_milepost_tjmessagecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_AdMessageType
        {
            set { _j_milepost_admessagetype = value; }
            get { return _j_milepost_admessagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string J_Milepost_AdMessageContent
        {
            set { _j_milepost_admessagecontent = value; }
            get { return _j_milepost_admessagecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int J_Milepost_AdStatus
        {
            set { _j_milepost_adstatus = value; }
            get { return _j_milepost_adstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime J_Milepost_createTime
        {
            set { _j_milepost_createtime = value; }
            get { return _j_milepost_createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool J_Milepost_isDelete
        {
            set { _j_milepost_isdelete = value; }
            get { return _j_milepost_isdelete; }
        }
        /// <summary>
        /// 稽核时间1（虚拟字段，列表查询用到）
        /// </summary>
        public DateTime? J_Milepost_JTime1
        {
            get { return _j_milepost_jtime1; }
            set { _j_milepost_jtime1 = value; }
        }
        /// <summary>
        /// 委托人/对方当事人（虚拟字段，列表查询用到）
        /// </summary>
        public string J_Milepost_clientRival
        {
            get { return _j_milepost_clientRival; }
            set { _j_milepost_clientRival = value; }
        }
        /// <summary>
        /// 主办律师（虚拟字段，列表查询用到）
        /// </summary>
        public string J_Milepost_sponsorlawyer
        {
            get { return _j_milepost_sponsorlawyer; }
            set { _j_milepost_sponsorlawyer = value; }
        }
        /// <summary>
        /// 协办律师（虚拟字段，列表查询用到）
        /// </summary>
        public string J_Milepost_Colawyer
        {
            get { return _j_milepost_colawyer; }
            set { _j_milepost_colawyer = value; }
        }

        public string ProjectName
        {
            get { return _projectname; }
            set { _projectname = value; }
        }
        #endregion Model

    }
}

