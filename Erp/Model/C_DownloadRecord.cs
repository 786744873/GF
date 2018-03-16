using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    [Serializable]
    public partial class C_DownloadRecord
    {
        /// <summary>
        /// 下载记录ID，主键，自增长
        /// </summary>
        private int _c_downloadrecord_id;

        public int C_DownloadRecord_id
        {
            get { return _c_downloadrecord_id; }
            set { _c_downloadrecord_id = value; }
        }

        
        /// <summary>
        /// 下载记录GUID
        /// </summary>
        private Guid? _c_downloadrecord_code;

        public Guid? C_DownloadRecord_code
        {
            get { return _c_downloadrecord_code; }
            set { _c_downloadrecord_code = value; }
        }

       
        /// <summary>
        /// 附件GUID
        /// </summary>
        private Guid? _c_downloadrecord_attachmentcode;

        public Guid? C_DownloadRecord_attachmentCode
        {
            get { return _c_downloadrecord_attachmentcode; }
            set { _c_downloadrecord_attachmentcode = value; }
        }

        
        /// <summary>
        /// 创建人GUID
        /// </summary>
        private Guid? _c_downloadrecord_creator;

        public Guid? C_DownloadRecord_creator
        {
            get { return _c_downloadrecord_creator; }
            set { _c_downloadrecord_creator = value; }
        }

        
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime? _c_downloadrecord_createtime;

        public DateTime? C_DownloadRecord_createTime
        {
            get { return _c_downloadrecord_createtime; }
            set { _c_downloadrecord_createtime = value; }
        }
        /// <summary>
        /// 是否删除 1为已删除 0为未删除
        /// </summary>
        private bool? c_downloadrecord_isdelete;

        public bool? C_DownloadRecord_isDelete
        {
            get { return c_downloadrecord_isdelete; }
            set { c_downloadrecord_isdelete = value; }
        }
        /// <summary>
        /// 虚拟属性（下载人）
        /// </summary>
        private string _c_userinfo_name;
        public string C_Userinfo_name
        {
            get { return _c_userinfo_name; }
            set { _c_userinfo_name = value; }
        }
    }
}
