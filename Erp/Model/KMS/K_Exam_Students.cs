using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// 考试考生表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class K_Exam_Students
    {
        public K_Exam_Students()
        { }
        #region Model
        private Guid _k_exam_students_code;
        private Guid _k_exam_code;
        private Guid _k_student_code;
        private string _k_exam_student_name;
        private string _k_exam_student_uid;
        private string _k_exam_student_uidname;
        /// <summary>
        /// 编码
        /// </summary>
        public Guid K_Exam_Students_code
        {
            set { _k_exam_students_code = value; }
            get { return _k_exam_students_code; }
        }
        /// <summary>
        /// 试卷编码
        /// </summary>
        public Guid K_Exam_code
        {
            set { _k_exam_code = value; }
            get { return _k_exam_code; }
        }
        /// <summary>
        /// 考生编码（关连用户表）
        /// </summary>
        public Guid K_Student_code
        {
            set { _k_student_code = value; }
            get { return _k_student_code; }
        }
        /// <summary>
        /// 考生姓名
        /// </summary>
        public string K_Exam_Student_name
        {
            set { _k_exam_student_name = value; }
            get { return _k_exam_student_name; }
        }
        /// <summary>
        /// 身份id
        /// </summary>
        public string K_Exam_Student_uid
        {
            set { _k_exam_student_uid = value; }
            get { return _k_exam_student_uid; }
        }
        /// <summary>
        /// 身份id名称
        /// </summary>
        public string K_Exam_Student_uidName
        {
            set { _k_exam_student_uidname = value; }
            get { return _k_exam_student_uidname; }
        }
        #endregion Model

    }
}
