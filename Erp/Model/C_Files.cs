using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 作者：陈永俊
    /// 时间：2015年6月8日15:43:56
    /// C_Files:实体类(属性说明自动提取数据库字段的描述信息)附件表
    /// </summary>
    public partial class C_Files
    {
        public C_Files()
        { }
        #region Model
        public int _c_files_id;
        public Guid? _c_files_code;
        public string _c_files_viewname;
        public string _c_files_name;
        public decimal? _c_files_size;
        public Guid? _c_files_creator;
        public string _c_files_creator_name;
        public DateTime? _c_files_createdate;
        public string _c_files_type;
        public int? _c_files_isdelete;
        public int? _c_files_cate;
        public string _c_files_cateName;
        public Guid? _c_files_link;
        public string _c_files_parameters_name;

        /// <summary>
        /// 主键
        /// </summary>
        public int C_Files_id
        {
            set { _c_files_id = value; }
            get { return _c_files_id; }
        }
        /// <summary>
        /// 附件GUID
        /// </summary>
        public Guid? C_Files_code
        {
            set { _c_files_code = value; }
            get { return _c_files_code; }
        }
        /// <summary>
        /// 附件显示名称
        /// </summary>
        public string C_Files_viewName
        {
            set { _c_files_viewname = value; }
            get { return _c_files_viewname; }
        }
        /// <summary>
        /// 文件名称（GUID命名）
        /// </summary>
        public string C_Files_name
        {
            set { _c_files_name = value; }
            get { return _c_files_name; }
        }
        /// <summary>
        /// 文件大小，KB
        /// </summary>
        public decimal? C_Files_size
        {
            set { _c_files_size = value; }
            get { return _c_files_size; }
        }
        /// <summary>
        /// 附件上传人
        /// </summary>
        public Guid? C_Files_creator
        {
            set { _c_files_creator = value; }
            get { return _c_files_creator; }
        }
        /// <summary>
        /// 上传人名称（虚拟字段）
        /// </summary>
        public string C_Files_creator_name
        {
            get { return _c_files_creator_name; }
            set { _c_files_creator_name = value; }
        }
        
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? C_Files_createDate
        {
            set { _c_files_createdate = value; }
            get { return _c_files_createdate; }
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string C_Files_type
        {
            set { _c_files_type = value; }
            get { return _c_files_type; }
        }        
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? C_Files_isDelete
        {
            set { _c_files_isdelete = value; }
            get { return _c_files_isdelete; }
        }
        /// <summary>
        /// 文件所属类型，如：案件等，关联parameter表
        /// </summary>
        public int? C_Files_cate
        {
            set { _c_files_cate = value; }
            get { return _c_files_cate; }
        }
        /// <summary>
        /// 文件所属类型名称（虚拟字段）
        /// </summary>
        public string C_Files_cateName
        {
            get { return _c_files_cateName; }
            set { _c_files_cateName = value; }
        }
        /// <summary>
        /// 所关联GUID
        /// </summary>
        public Guid? C_Files_link
        {
            set { _c_files_link = value; }
            get { return _c_files_link; }
        }
        /// <summary>
        /// 虚拟属性（文件所属名称）
        /// </summary>
        public string C_Files_Parameters_name
        {
            set { _c_files_parameters_name = value; }
            get { return _c_files_parameters_name; }
        }

        #endregion Model

    }
}
