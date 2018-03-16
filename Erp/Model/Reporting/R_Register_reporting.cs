using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// 立案统计报表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class R_Register_reporting
    {
        public R_Register_reporting()
        { }
        #region Model
        private int _id;
        private string _r_register_reporting_area;
        private string _r_register_reporting_host;
        private string _r_register_reporting_co;
        private string _r_register_reporting_firstcourt;
        private string _r_register_reporting_casenumber;
        private string _r_register_reporting_plaintiff;
        private string _r_register_reporting_otherparty;
        private string _r_register_reporting_project;
        private string _r_register_reporting_closeddate;
        private string _r_register_reporting_transfertarget;
        private string _r_register_reporting_expectedreturn;
        private string _r_register_reporting_isextension;
        private string _r_register_reporting_extensiontime;
        private string _r_register_reporting_finishedtime;
        private string _r_Register_reporting_organ;
        private string _r_Register_reporting_organName;
        private string _r_Register_reporting_caseCode;
        private string _r_Register_reporting_mCode;

        public string R_Register_reporting_mCode
        {
            get { return _r_Register_reporting_mCode; }
            set { _r_Register_reporting_mCode = value; }
        }

        public string R_Register_reporting_caseCode
        {
            get { return _r_Register_reporting_caseCode; }
            set { _r_Register_reporting_caseCode = value; }
        }

        /// <summary>
        /// 组织架构名称
        /// </summary>
        public string R_Register_reporting_organName
        {
            get { return _r_Register_reporting_organName; }
            set { _r_Register_reporting_organName = value; }
        }

        /// <summary>
        /// 所属组织架构
        /// </summary>

        public string R_Register_reporting_organ
        {
            get { return _r_Register_reporting_organ; }
            set { _r_Register_reporting_organ = value; }
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
        public string R_Register_reporting_area
        {
            set { _r_register_reporting_area = value; }
            get { return _r_register_reporting_area; }
        }
        /// <summary>
        /// 主办律师
        /// </summary>
        public string R_Register_reporting_host
        {
            set { _r_register_reporting_host = value; }
            get { return _r_register_reporting_host; }
        }
        /// <summary>
        /// 协办律师
        /// </summary>
        public string R_Register_reporting_co
        {
            set { _r_register_reporting_co = value; }
            get { return _r_register_reporting_co; }
        }
        /// <summary>
        /// 一审管辖法院
        /// </summary>
        public string R_Register_reporting_firstCourt
        {
            set { _r_register_reporting_firstcourt = value; }
            get { return _r_register_reporting_firstcourt; }
        }
        /// <summary>
        /// 案号
        /// </summary>
        public string R_Register_reporting_caseNumber
        {
            set { _r_register_reporting_casenumber = value; }
            get { return _r_register_reporting_casenumber; }
        }
        /// <summary>
        /// 委托人
        /// </summary>
        public string R_Register_reporting_plaintiff
        {
            set { _r_register_reporting_plaintiff = value; }
            get { return _r_register_reporting_plaintiff; }
        }
        /// <summary>
        /// 对方当事人
        /// </summary>
        public string R_Register_reporting_otherParty
        {
            set { _r_register_reporting_otherparty = value; }
            get { return _r_register_reporting_otherparty; }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public string R_Register_reporting_project
        {
            set { _r_register_reporting_project = value; }
            get { return _r_register_reporting_project; }
        }
        /// <summary>
        /// 收案时间
        /// </summary>
        public string R_Register_reporting_closedDate
        {
            set { _r_register_reporting_closeddate = value; }
            get { return _r_register_reporting_closeddate; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string R_Register_reporting_transferTarget
        {
            set { _r_register_reporting_transfertarget = value; }
            get { return _r_register_reporting_transfertarget; }
        }
        /// <summary>
        /// 预期收益
        /// </summary>
        public string R_Register_reporting_expectedReturn
        {
            set { _r_register_reporting_expectedreturn = value; }
            get { return _r_register_reporting_expectedreturn; }
        }
        /// <summary>
        /// 是否延期
        /// </summary>
        public string R_Register_reporting_isExtension
        {
            set { _r_register_reporting_isextension = value; }
            get { return _r_register_reporting_isextension; }
        }
        /// <summary>
        /// 延期时长
        /// </summary>
        public string R_Register_reporting_extensionTime
        {
            set { _r_register_reporting_extensiontime = value; }
            get { return _r_register_reporting_extensiontime; }
        }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string R_Register_reporting_finishedTime
        {
            set { _r_register_reporting_finishedtime = value; }
            get { return _r_register_reporting_finishedtime; }
        }
        #endregion Model

    }

    [Serializable]
    public partial class V_Register_reporting
    {
        public V_Register_reporting()
        { }
        #region Model
        private int _id;
        private string _r_register_reporting_area;
        private string _r_register_reporting_host;
        private string _r_register_reporting_co;
        private string _r_register_reporting_firstcourt;
        private string _r_register_reporting_casenumber;
        private string _r_register_reporting_plaintiff;
        private string _r_register_reporting_otherparty;
        private string _r_register_reporting_project;
        private string _r_register_reporting_closeddate;
        private string _r_register_reporting_transfertarget;
        private string _r_register_reporting_expectedreturn;
        private string _r_register_reporting_isextension;
        private string _r_register_reporting_extensiontime;
        private string _r_register_reporting_finishedtime;
        private string _r_Register_reporting_organ;
        private string _r_Register_reporting_transferTargetz;
        private string _r_Register_reporting_expectedReturnz;
        private string _r_Register_reporting_closedDatez;


        /// <summary>
        /// 收案时间至
        /// </summary>
        public string R_Register_reporting_closedDatez
        {
            get { return _r_Register_reporting_closedDatez; }
            set { _r_Register_reporting_closedDatez = value; }
        }


        /// <summary>
        /// 预期收益至
        /// </summary>
        public string R_Register_reporting_expectedReturnz
        {
            get { return _r_Register_reporting_expectedReturnz; }
            set { _r_Register_reporting_expectedReturnz = value; }
        }


        /// <summary>
        /// 移交标的至
        /// </summary>
        public string R_Register_reporting_transferTargetz
        {
            get { return _r_Register_reporting_transferTargetz; }
            set { _r_Register_reporting_transferTargetz = value; }
        }

        /// <summary>
        /// 所属组织架构
        /// </summary>

        public string R_Register_reporting_organ
        {
            get { return _r_Register_reporting_organ; }
            set { _r_Register_reporting_organ = value; }
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
        public string R_Register_reporting_area
        {
            set { _r_register_reporting_area = value; }
            get { return _r_register_reporting_area; }
        }
        /// <summary>
        /// 主办律师
        /// </summary>
        public string R_Register_reporting_host
        {
            set { _r_register_reporting_host = value; }
            get { return _r_register_reporting_host; }
        }
        /// <summary>
        /// 协办律师
        /// </summary>
        public string R_Register_reporting_co
        {
            set { _r_register_reporting_co = value; }
            get { return _r_register_reporting_co; }
        }
        /// <summary>
        /// 一审管辖法院
        /// </summary>
        public string R_Register_reporting_firstCourt
        {
            set { _r_register_reporting_firstcourt = value; }
            get { return _r_register_reporting_firstcourt; }
        }
        /// <summary>
        /// 案号
        /// </summary>
        public string R_Register_reporting_caseNumber
        {
            set { _r_register_reporting_casenumber = value; }
            get { return _r_register_reporting_casenumber; }
        }
        /// <summary>
        /// 委托人
        /// </summary>
        public string R_Register_reporting_plaintiff
        {
            set { _r_register_reporting_plaintiff = value; }
            get { return _r_register_reporting_plaintiff; }
        }
        /// <summary>
        /// 对方当事人
        /// </summary>
        public string R_Register_reporting_otherParty
        {
            set { _r_register_reporting_otherparty = value; }
            get { return _r_register_reporting_otherparty; }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public string R_Register_reporting_project
        {
            set { _r_register_reporting_project = value; }
            get { return _r_register_reporting_project; }
        }
        /// <summary>
        /// 收案时间
        /// </summary>
        public string R_Register_reporting_closedDate
        {
            set { _r_register_reporting_closeddate = value; }
            get { return _r_register_reporting_closeddate; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string R_Register_reporting_transferTarget
        {
            set { _r_register_reporting_transfertarget = value; }
            get { return _r_register_reporting_transfertarget; }
        }
        /// <summary>
        /// 预期收益
        /// </summary>
        public string R_Register_reporting_expectedReturn
        {
            set { _r_register_reporting_expectedreturn = value; }
            get { return _r_register_reporting_expectedreturn; }
        }
        /// <summary>
        /// 是否延期
        /// </summary>
        public string R_Register_reporting_isExtension
        {
            set { _r_register_reporting_isextension = value; }
            get { return _r_register_reporting_isextension; }
        }
        /// <summary>
        /// 延期时长
        /// </summary>
        public string R_Register_reporting_extensionTime
        {
            set { _r_register_reporting_extensiontime = value; }
            get { return _r_register_reporting_extensiontime; }
        }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string R_Register_reporting_finishedTime
        {
            set { _r_register_reporting_finishedtime = value; }
            get { return _r_register_reporting_finishedtime; }
        }
        #endregion Model
    }


    [Serializable]
    public partial class V_Register_statistics
    {
        public V_Register_statistics()
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
