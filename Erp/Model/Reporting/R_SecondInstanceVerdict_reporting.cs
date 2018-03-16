using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// R_SecondInstanceVerdict_reporting:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class R_SecondInstanceVerdict_reporting
    {
        public R_SecondInstanceVerdict_reporting()
        { }
        #region Model
        private int _id;
        private string _r_secondinstanceverdict_reporting_area;
        private string _r_secondinstanceverdict_reporting_organ;
        private string _r_secondinstanceverdict_reporting_host;
        private string _r_secondinstanceverdict_reporting_co;
        private string _r_secondinstanceverdict_reporting_firstcourt;
        private string _r_secondinstanceverdict_reporting_casenumber;
        private string _r_secondinstanceverdict_reporting_plaintiff;
        private string _r_secondinstanceverdict_reporting_otherparty;
        private string _r_secondinstanceverdict_reporting_project;
        private string _r_secondinstanceverdict_reporting_closeddate;
        private string _r_secondinstanceverdict_reporting_transfertarget;
        private string _r_secondinstanceverdict_reporting_expectedreturn;
        private string _r_secondinstanceverdict_reporting_fitingtime;
        private string _r_secondinstanceverdict_reporting_startdate;
        private string _r_secondinstanceverdict_reporting_isextension;
        private string _r_secondinstanceverdict_reporting_extensiontime;
        private string _r_secondinstanceverdict_reporting_finishedtime;
        private string _r_secondinstanceverdict_reporting_casecode;
        private string _r_secondinstanceverdict_reporting_mcode;
        private string _r_secondinstanceverdict_reporting_instrumentstype;
        private string _r_secondinstanceverdict_reporting_isvalidate;
        private string _r_secondinstanceverdict_reporting_instrumentsmoney;
        private string _r_secondinstanceverdict_reporting_result;
        private string _r_secondinstanceverdict_reporting_isclosed;
        private string _r_secondinstanceverdict_reporting_iswei;

        public string R_SecondInstanceVerdict_reporting_expectedReturnz { get; set; }
        public string R_SecondInstanceVerdict_reporting_transferTargetz { get; set; }
        public string  R_SecondInstanceVerdict_reporting_closedDatez { get; set; }
        public string R_SecondInstanceVerdict_reporting_organName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_area
        {
            set { _r_secondinstanceverdict_reporting_area = value; }
            get { return _r_secondinstanceverdict_reporting_area; }
        }
        /// <summary>
        /// 组织架构
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_organ
        {
            set { _r_secondinstanceverdict_reporting_organ = value; }
            get { return _r_secondinstanceverdict_reporting_organ; }
        }
        /// <summary>
        /// 主办律师
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_host
        {
            set { _r_secondinstanceverdict_reporting_host = value; }
            get { return _r_secondinstanceverdict_reporting_host; }
        }
        /// <summary>
        /// 协办律师
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_co
        {
            set { _r_secondinstanceverdict_reporting_co = value; }
            get { return _r_secondinstanceverdict_reporting_co; }
        }
        /// <summary>
        /// 一审法院
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_firstCourt
        {
            set { _r_secondinstanceverdict_reporting_firstcourt = value; }
            get { return _r_secondinstanceverdict_reporting_firstcourt; }
        }
        /// <summary>
        /// 案号
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_caseNumber
        {
            set { _r_secondinstanceverdict_reporting_casenumber = value; }
            get { return _r_secondinstanceverdict_reporting_casenumber; }
        }
        /// <summary>
        /// 委托人
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_plaintiff
        {
            set { _r_secondinstanceverdict_reporting_plaintiff = value; }
            get { return _r_secondinstanceverdict_reporting_plaintiff; }
        }
        /// <summary>
        /// 对方当事人
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_otherParty
        {
            set { _r_secondinstanceverdict_reporting_otherparty = value; }
            get { return _r_secondinstanceverdict_reporting_otherparty; }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_project
        {
            set { _r_secondinstanceverdict_reporting_project = value; }
            get { return _r_secondinstanceverdict_reporting_project; }
        }
        /// <summary>
        /// 收案时间
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_closedDate
        {
            set { _r_secondinstanceverdict_reporting_closeddate = value; }
            get { return _r_secondinstanceverdict_reporting_closeddate; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_transferTarget
        {
            set { _r_secondinstanceverdict_reporting_transfertarget = value; }
            get { return _r_secondinstanceverdict_reporting_transfertarget; }
        }
        /// <summary>
        /// 预期收益
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_expectedReturn
        {
            set { _r_secondinstanceverdict_reporting_expectedreturn = value; }
            get { return _r_secondinstanceverdict_reporting_expectedreturn; }
        }
        /// <summary>
        /// 立案时间
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_fitingTime
        {
            set { _r_secondinstanceverdict_reporting_fitingtime = value; }
            get { return _r_secondinstanceverdict_reporting_fitingtime; }
        }
        /// <summary>
        /// 二审开始时间
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_startDate
        {
            set { _r_secondinstanceverdict_reporting_startdate = value; }
            get { return _r_secondinstanceverdict_reporting_startdate; }
        }
        /// <summary>
        /// 是否延期
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_isExtension
        {
            set { _r_secondinstanceverdict_reporting_isextension = value; }
            get { return _r_secondinstanceverdict_reporting_isextension; }
        }
        /// <summary>
        /// 延期时长
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_extensionTime
        {
            set { _r_secondinstanceverdict_reporting_extensiontime = value; }
            get { return _r_secondinstanceverdict_reporting_extensiontime; }
        }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_finishedTime
        {
            set { _r_secondinstanceverdict_reporting_finishedtime = value; }
            get { return _r_secondinstanceverdict_reporting_finishedtime; }
        }
        /// <summary>
        /// 案件编码
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_caseCode
        {
            set { _r_secondinstanceverdict_reporting_casecode = value; }
            get { return _r_secondinstanceverdict_reporting_casecode; }
        }
        /// <summary>
        /// 进程编码
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_mCode
        {
            set { _r_secondinstanceverdict_reporting_mcode = value; }
            get { return _r_secondinstanceverdict_reporting_mcode; }
        }
        /// <summary>
        /// 文书类型
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_InstrumentsType
        {
            set { _r_secondinstanceverdict_reporting_instrumentstype = value; }
            get { return _r_secondinstanceverdict_reporting_instrumentstype; }
        }
        /// <summary>
        /// 文书是否生效
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_isValidate
        {
            set { _r_secondinstanceverdict_reporting_isvalidate = value; }
            get { return _r_secondinstanceverdict_reporting_isvalidate; }
        }
        /// <summary>
        /// 文书收入
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_InstrumentsMoney
        {
            set { _r_secondinstanceverdict_reporting_instrumentsmoney = value; }
            get { return _r_secondinstanceverdict_reporting_instrumentsmoney; }
        }
        /// <summary>
        /// 文书结果（胜诉败诉）
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_result
        {
            set { _r_secondinstanceverdict_reporting_result = value; }
            get { return _r_secondinstanceverdict_reporting_result; }
        }
        /// <summary>
        /// 是否结案
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_isClosed
        {
            set { _r_secondinstanceverdict_reporting_isclosed = value; }
            get { return _r_secondinstanceverdict_reporting_isclosed; }
        }
        /// <summary>
        /// 是否维持原判
        /// </summary>
        public string R_SecondInstanceVerdict_reporting_iswei
        {
            set { _r_secondinstanceverdict_reporting_iswei = value; }
            get { return _r_secondinstanceverdict_reporting_iswei; }
        }
        #endregion Model

    }

    [Serializable]
    public partial class V_SecondInstanceVerdict_reporting
    {
        public V_SecondInstanceVerdict_reporting()
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

        public string 判决数 { get; set; }

        public string 判决率 { get; set; }

        public string 调解数 { get; set; }

        public string 调解率 { get; set; }

        public string 维持原判数 { get; set; }

        public string 维持原判率 { get; set; }

        public string 结案数 { get; set; }

        public string 结案率 { get; set; }

        public string 文书收入 { get; set; }
    }
}
