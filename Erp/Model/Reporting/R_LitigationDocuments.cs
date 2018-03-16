using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// 立案报表统计:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class R_LitigationDocuments
    {
        public R_LitigationDocuments()
        { }
        #region Model
        private int _id;
        private string _r_litigationdocuments_area;
        private string _r_litigationdocuments_host;
        private string _r_litigationdocuments_co;
        private string _r_litigationdocuments_firstcourt;
        private string _r_litigationdocuments_casenumber;
        private string _r_litigationdocuments_plaintiff;
        private string _r_litigationdocuments_otherparty;
        private string _r_litigationdocuments_project;
        private string _r_litigationdocuments_closeddate;
        private string _r_litigationdocuments_transfertarget;
        private string _r_litigationdocuments_expectedreturn;
        private string _r_litigationdocuments_isextension;
        private string _r_litigationdocuments_extensiontime;
        private string _r_litigationdocuments_finishedtime;
        private string _r_LitigationDocuments_organ;
        private string _r_LitigationDocuments_caseCode;
        private string _r_LitigationDocuments_mCode;
        private string _r_LitigationDocuments_closedDatez;
        private string _r_LitigationDocuments_transferTargetz;
        private string _r_LitigationDocuments_expectedReturnz;
        private string _r_LitigationDocuments_organName;

        public string R_LitigationDocuments_organName
        {
            get { return _r_LitigationDocuments_organName; }
            set { _r_LitigationDocuments_organName = value; }
        }

        public string R_LitigationDocuments_expectedReturnz
        {
            get { return _r_LitigationDocuments_expectedReturnz; }
            set { _r_LitigationDocuments_expectedReturnz = value; }
        }

        public string R_LitigationDocuments_transferTargetz
        {
            get { return _r_LitigationDocuments_transferTargetz; }
            set { _r_LitigationDocuments_transferTargetz = value; }
        }

        public string R_LitigationDocuments_closedDatez
        {
            get { return _r_LitigationDocuments_closedDatez; }
            set { _r_LitigationDocuments_closedDatez = value; }
        }

        /// <summary>
        /// 进程编码
        /// </summary>
        public string R_LitigationDocuments_mCode
        {
            get { return _r_LitigationDocuments_mCode; }
            set { _r_LitigationDocuments_mCode = value; }
        }


        /// <summary>
        /// 案件编码
        /// </summary>
        public string R_LitigationDocuments_caseCode
        {
            get { return _r_LitigationDocuments_caseCode; }
            set { _r_LitigationDocuments_caseCode = value; }
        }

        /// <summary>
        /// 部门
        /// </summary>
        public string R_LitigationDocuments_organ
        {
            get { return _r_LitigationDocuments_organ; }
            set { _r_LitigationDocuments_organ = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string R_LitigationDocuments_area
        {
            set { _r_litigationdocuments_area = value; }
            get { return _r_litigationdocuments_area; }
        }
        /// <summary>
        /// 主办律师
        /// </summary>
        public string R_LitigationDocuments_host
        {
            set { _r_litigationdocuments_host = value; }
            get { return _r_litigationdocuments_host; }
        }
        /// <summary>
        /// 协办律师
        /// </summary>
        public string R_LitigationDocuments_co
        {
            set { _r_litigationdocuments_co = value; }
            get { return _r_litigationdocuments_co; }
        }
        /// <summary>
        /// 一审管辖法院
        /// </summary>
        public string R_LitigationDocuments_firstCourt
        {
            set { _r_litigationdocuments_firstcourt = value; }
            get { return _r_litigationdocuments_firstcourt; }
        }
        /// <summary>
        /// 案号
        /// </summary>
        public string R_LitigationDocuments_caseNumber
        {
            set { _r_litigationdocuments_casenumber = value; }
            get { return _r_litigationdocuments_casenumber; }
        }
        /// <summary>
        /// 委托人
        /// </summary>
        public string R_LitigationDocuments_plaintiff
        {
            set { _r_litigationdocuments_plaintiff = value; }
            get { return _r_litigationdocuments_plaintiff; }
        }
        /// <summary>
        /// 对方当事人
        /// </summary>
        public string R_LitigationDocuments_otherParty
        {
            set { _r_litigationdocuments_otherparty = value; }
            get { return _r_litigationdocuments_otherparty; }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public string R_LitigationDocuments_project
        {
            set { _r_litigationdocuments_project = value; }
            get { return _r_litigationdocuments_project; }
        }
        /// <summary>
        /// 收案时间
        /// </summary>
        public string R_LitigationDocuments_closedDate
        {
            set { _r_litigationdocuments_closeddate = value; }
            get { return _r_litigationdocuments_closeddate; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string R_LitigationDocuments_transferTarget
        {
            set { _r_litigationdocuments_transfertarget = value; }
            get { return _r_litigationdocuments_transfertarget; }
        }
        /// <summary>
        /// 预期收益
        /// </summary>
        public string R_LitigationDocuments_expectedReturn
        {
            set { _r_litigationdocuments_expectedreturn = value; }
            get { return _r_litigationdocuments_expectedreturn; }
        }
        /// <summary>
        /// 是否延期
        /// </summary>
        public string R_LitigationDocuments_isExtension
        {
            set { _r_litigationdocuments_isextension = value; }
            get { return _r_litigationdocuments_isextension; }
        }
        /// <summary>
        /// 延期时长
        /// </summary>
        public string R_LitigationDocuments_extensionTime
        {
            set { _r_litigationdocuments_extensiontime = value; }
            get { return _r_litigationdocuments_extensiontime; }
        }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string R_LitigationDocuments_finishedTime
        {
            set { _r_litigationdocuments_finishedtime = value; }
            get { return _r_litigationdocuments_finishedtime; }
        }
        #endregion Model

    }

    [Serializable]
    public partial class V_LitigationDocuments
    {
        public V_LitigationDocuments()
        { }
        public string 地区 { get; set; }

        public string 统计项 { get; set; }

        public string 应完成数 { get; set; }

        public string 移交标的 { get; set; }

        public string 预期收入 { get; set; }

        public string 实际完成数 { get; set; }

        public string 实际移交标的 { get; set; }

        public string 实际预期收入 { get; set; }

        public string 实际完成率 { get; set; }

        public string 超期数 { get; set; }

        public string 超期移交标的 { get; set; }

        public string 超期预期收入 { get; set; }

        public string 超期率 { get; set; }

        public string 超期总时长 { get; set; }

        public string 平均超期时长 { get; set; }

        public string 最长超期时长 { get; set; }

        public string 最短超期时长 { get; set; }

        public string 延期数 { get; set; }

        public string 延期移交标的 { get; set; }

        public string 延期预期收入 { get; set; }

        public string 延期率 { get; set; }

        public string 延期总时长 { get; set; }

        public string 平均延期时长 { get; set; }

        public string 最长延期时长 { get; set; }

        public string 最短延期时长 { get; set; }
    }
}
