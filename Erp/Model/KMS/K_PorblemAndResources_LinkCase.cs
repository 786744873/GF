using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// 问题/文档/视频 关联业务流程表单表 
    /// cyj
    /// 2016年1月13日10:17:10
    /// </summary>
    public class K_PorblemAndResources_LinkCase
    {
        public K_PorblemAndResources_LinkCase()
        { }
        #region Model
        private int _k_problemandresources_linkcase_id;
        private Guid? _k_problemandresources_linkcase_code;
        private Guid? _c_fk_code;
        private Guid? _k_problemandresources_linkcase_courtcode;
        private Guid? _k_problemandresources_linkcase_businessflowcode;
        private Guid? _k_problemandresources_linkcase_formcode;
        private int? _k_problemAndResources_linkcase_type;
        private string _k_problemandresources_linkcase_courtlistcode;
        private string _k_problemandresources_linkcase_courtname;
        private string _k_problemandresources_linkcase_businessflowname;
        private string _k_problemandresources_linkcase_formname;
        private Guid? _k_problemandresources_linkcase_region;
        /// <summary>
        /// 虚拟字段（法院集合）
        /// </summary>
        public string K_ProblemAndResources_LinkCase_CourtListcode
        {
            set { _k_problemandresources_linkcase_courtlistcode = value; }
            get { return _k_problemandresources_linkcase_courtlistcode; }
        }
        /// <summary>
        /// 虚拟字段（法院名称）
        /// </summary>
        public string C_Court_name
        {
            set { _k_problemandresources_linkcase_courtname = value; }
            get { return _k_problemandresources_linkcase_courtname; }
        }
        /// <summary>
        /// 虚拟字段（流程名称）
        /// </summary>
        public string P_Flow_name
        {
            set { _k_problemandresources_linkcase_businessflowname = value; }
            get { return _k_problemandresources_linkcase_businessflowname; }
        }
        /// <summary>
        /// 虚拟字段（表单名称）
        /// </summary>
        public string F_Form_chineseName
        {
            set { _k_problemandresources_linkcase_formname = value; }
            get { return _k_problemandresources_linkcase_formname; }
        }
        /// <summary>
        /// id
        /// </summary>
        public int K_ProblemAndResources_LinkCase_id
        {
            set { _k_problemandresources_linkcase_id = value; }
            get { return _k_problemandresources_linkcase_id; }
        }
        /// <summary>
        /// code
        /// </summary>
        public Guid? K_ProblemAndResources_LinkCase_code
        {
            set { _k_problemandresources_linkcase_code = value; }
            get { return _k_problemandresources_linkcase_code; }
        }
        /// <summary>
        /// 外键问题code
        /// </summary>
        public Guid? C_FK_code
        {
            set { _c_fk_code = value; }
            get { return _c_fk_code; }
        }
        /// <summary>
        /// 法院code
        /// </summary>
        public Guid? K_ProblemAndResources_LinkCase_Courtcode
        {
            set { _k_problemandresources_linkcase_courtcode = value; }
            get { return _k_problemandresources_linkcase_courtcode; }
        }
        /// <summary>
        /// 业务流程code
        /// </summary>
        public Guid? K_ProblemAndResources_LinkCase_BusinessFlowcode
        {
            set { _k_problemandresources_linkcase_businessflowcode = value; }
            get { return _k_problemandresources_linkcase_businessflowcode; }
        }
        /// <summary>
        /// 表单code
        /// </summary>
        public Guid? K_ProblemAndResources_LinkCase_Formcode
        {
            set { _k_problemandresources_linkcase_formcode = value; }
            get { return _k_problemandresources_linkcase_formcode; }
        }
        /// <summary>
        /// 类型1.资源文档，2问题，3视频
        /// </summary>
        public int? K_ProblemAndResources_LinkCase_type
        {
            set { _k_problemAndResources_linkcase_type = value; }
            get { return _k_problemAndResources_linkcase_type; }
        }
        /// <summary>
        /// （虚拟字段）所属区域
        /// </summary>
        public Guid? K_ProblemAndResources_LinkCase_region
        {
            set { _k_problemandresources_linkcase_region = value; }
            get { return _k_problemandresources_linkcase_region; }
        }
        #endregion Model
    }
}
