using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// 考试表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：陈盼盼
    /// 时间：2016-2-29
    /// </summary>
    [Serializable]
    public partial class K_Exam
    {
        public K_Exam()
        { }
        #region Model
        private int _k_exam_id;
        private Guid _k_exam_code;
        private string _k_exam_paperid;
        private string _k_exam_name;
        private DateTime? _k_exam_starttime;
        private DateTime? _k_exam_endtime;
        private string _k_exam_examiner;
        private Guid _k_exam_category;
        private Guid _k_exam_type;
        private string _k_exam_img;
        private string _k_exam_url;
        private string _k_exam_pwd;
        private string _k_exam_address;
        private int? _k_exam_usercount;
        private DateTime? _k_exam_createtime;
        private bool _k_exam_isdelete;
        /// <summary>
        /// 考试id(自增)
        /// </summary>
        public int K_Exam_id
        {
            set { _k_exam_id = value; }
            get { return _k_exam_id; }
        }
        /// <summary>
        /// 考试编码
        /// </summary>
        public Guid K_Exam_code
        {
            set { _k_exam_code = value; }
            get { return _k_exam_code; }
        }
        /// <summary>
        /// 试卷ID（百一测获取）
        /// </summary>
        public string K_Exam_paperId
        {
            set { _k_exam_paperid = value; }
            get { return _k_exam_paperid; }
        }
        /// <summary>
        /// 考试名称（同百一测）
        /// </summary>
        public string K_Exam_name
        {
            set { _k_exam_name = value; }
            get { return _k_exam_name; }
        }
        /// <summary>
        /// 考试开始时间（同百一测）
        /// </summary>
        public DateTime? K_Exam_startTime
        {
            set { _k_exam_starttime = value; }
            get { return _k_exam_starttime; }
        }
        /// <summary>
        /// 考试结束时间（同百一测）
        /// </summary>
        public DateTime? K_Exam_endTime
        {
            set { _k_exam_endtime = value; }
            get { return _k_exam_endtime; }
        }
        /// <summary>
        /// 考试负责人（考官）
        /// </summary>
        public string K_Exam_examiner
        {
            set { _k_exam_examiner = value; }
            get { return _k_exam_examiner; }
        }
        /// <summary>
        /// 所属分类
        /// </summary>
        public Guid K_Exam_category
        {
            set { _k_exam_category = value; }
            get { return _k_exam_category; }
        }
        /// <summary>
        /// 考试方式（PC/移动/PC+移动）
        /// </summary>
        public Guid K_Exam_type
        {
            set { _k_exam_type = value; }
            get { return _k_exam_type; }
        }
        /// <summary>
        /// 二维码图片（百一测获取）
        /// </summary>
        public string K_Exam_img
        {
            set { _k_exam_img = value; }
            get { return _k_exam_img; }
        }
        /// <summary>
        /// 考试链接（百一测获取）
        /// </summary>
        public string K_Exam_url
        {
            set { _k_exam_url = value; }
            get { return _k_exam_url; }
        }
        /// <summary>
        /// 考试口令（百一测获取）
        /// </summary>
        public string K_Exam_pwd
        {
            set { _k_exam_pwd = value; }
            get { return _k_exam_pwd; }
        }
        /// <summary>
        /// 考试地址
        /// </summary>
        public string K_Exam_address
        {
            set { _k_exam_address = value; }
            get { return _k_exam_address; }
        }
        /// <summary>
        /// 预计人数
        /// </summary>
        public int? K_Exam_userCount
        {
            set { _k_exam_usercount = value; }
            get { return _k_exam_usercount; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? K_Exam_createtime
        {
            set { _k_exam_createtime = value; }
            get { return _k_exam_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool K_Exam_isDelete
        {
            set { _k_exam_isdelete = value; }
            get { return _k_exam_isdelete; }
        }
        #endregion Model

    }
}
