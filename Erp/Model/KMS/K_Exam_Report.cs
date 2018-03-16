using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// 考试报告表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：cpp
    /// 日期：2016-2-29
    /// </summary>
    [Serializable]
    public partial class K_Exam_Report
    {
        public K_Exam_Report()
        { }
        #region Model
        private Guid _k_exam_report_code;
        private Guid _k_exam_students_code;
        private Guid _k_exam_code;
        private string _k_exam_report_title;
        private string _k_exam_report_testid;
        private string _k_exam_report_paperid;
        private DateTime? _k_exam_report_begintime;
        private DateTime? _k_exam_report_endtime;
        private string _k_exam_report_elapsedtime;
        private Guid _k_extinfos_code;
        private decimal? _k_exam_report_score;
        private decimal? _k_exam_report_points;
        private int? _k_exam_report_switchtimes;
        /// <summary>
        /// 编码
        /// </summary>
        public Guid K_Exam_Report_code
        {
            set { _k_exam_report_code = value; }
            get { return _k_exam_report_code; }
        }
        /// <summary>
        /// 考生编码（关连考生表）
        /// </summary>
        public Guid K_Exam_Students_code
        {
            set { _k_exam_students_code = value; }
            get { return _k_exam_students_code; }
        }
        /// <summary>
        /// 考试编码（关连考试）
        /// </summary>
        public Guid K_Exam_code
        {
            set { _k_exam_code = value; }
            get { return _k_exam_code; }
        }
        /// <summary>
        /// 报告标题
        /// </summary>
        public string K_Exam_Report_title
        {
            set { _k_exam_report_title = value; }
            get { return _k_exam_report_title; }
        }
        /// <summary>
        /// 测试ID
        /// </summary>
        public string K_Exam_Report_testId
        {
            set { _k_exam_report_testid = value; }
            get { return _k_exam_report_testid; }
        }
        /// <summary>
        /// 试卷ID
        /// </summary>
        public string K_Exam_Report_paperId
        {
            set { _k_exam_report_paperid = value; }
            get { return _k_exam_report_paperid; }
        }
        /// <summary>
        /// 考试开始时间
        /// </summary>
        public DateTime? K_Exam_Report_beginTime
        {
            set { _k_exam_report_begintime = value; }
            get { return _k_exam_report_begintime; }
        }
        /// <summary>
        /// 考试结束时间
        /// </summary>
        public DateTime? K_Exam_Report_endTime
        {
            set { _k_exam_report_endtime = value; }
            get { return _k_exam_report_endtime; }
        }
        /// <summary>
        /// 考试使用时长
        /// </summary>
        public string K_Exam_Report_elapsedTime
        {
            set { _k_exam_report_elapsedtime = value; }
            get { return _k_exam_report_elapsedtime; }
        }
        /// <summary>
        /// 采集信息（采集表）
        /// </summary>
        public Guid K_ExtInfos_code
        {
            set { _k_extinfos_code = value; }
            get { return _k_extinfos_code; }
        }
        /// <summary>
        /// 得分
        /// </summary>
        public decimal? K_Exam_Report_score
        {
            set { _k_exam_report_score = value; }
            get { return _k_exam_report_score; }
        }
        /// <summary>
        /// 总分
        /// </summary>
        public decimal? K_Exam_Report_points
        {
            set { _k_exam_report_points = value; }
            get { return _k_exam_report_points; }
        }
        /// <summary>
        /// 切换次数
        /// </summary>
        public int? K_Exam_Report_switchTimes
        {
            set { _k_exam_report_switchtimes = value; }
            get { return _k_exam_report_switchtimes; }
        }
        #endregion Model

    }
}
