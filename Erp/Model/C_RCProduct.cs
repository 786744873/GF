using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 竞争对手_竞争产品表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/04/23
    /// </summary>
    [Serializable]
    public partial class C_RCProduct
    {
        public C_RCProduct()
        { }
        #region Model
        private int _c_rCProduct_id;
        private Guid? _c_rCProduct_code;
        private string _c_rCProduct_number;
        private Guid? _c_rCProduct_competitorCode;
        private string _c_rCProduct_name;
        private DateTime? _c_rCProduct_ctime ;
        private Guid? _c_rCProduct_cuserid;
        private int? _c_rCProduct_isdelete;
        
        
        /// <summary>
        /// 产品内码，主键，自增
        /// </summary>
        public int C_RCProduct_id
        {
            get { return _c_rCProduct_id; }
            set { _c_rCProduct_id = value; }
        }

        /// <summary>
        /// 产品编码，后台自动生成。如果本系统自建，用 BRCP+3位数字
        /// </summary>
        public Guid? C_RCProduct_code
        {
            get { return _c_rCProduct_code; }
            set { _c_rCProduct_code = value; }
        }

        /// <summary>
        /// 产品代码
        /// </summary>
        public string C_RCProduct_number
        {
            get { return _c_rCProduct_number; }
            set { _c_rCProduct_number = value; }
        }
        
        /// <summary>
        /// 对手信息编码,关联对手表，后台自动保存
        /// </summary>
        public Guid? C_RCProduct_competitorCode
        {
            get { return _c_rCProduct_competitorCode; }
            set { _c_rCProduct_competitorCode = value; }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string C_RCProduct_name
        {
            get { return _c_rCProduct_name; }
            set { _c_rCProduct_name = value; }
        }

        /// <summary>
        /// 创建日期,时间存当期系统时间
        /// </summary>
        public DateTime? C_RCProduct_cTime
        {
            get { return _c_rCProduct_ctime; }
            set { _c_rCProduct_ctime = value; }
        }

        /// <summary>
        /// 创建人,关联U_user获取当前登录用户
        /// </summary>
        public Guid? C_RCProduct_cUserID
        {
            get { return _c_rCProduct_cuserid; }
            set { _c_rCProduct_cuserid = value; }
        }

        /// <summary>
        /// 是否删除,0-否，1-是
        /// </summary>
        public int? C_RCProduct_isdelete
        {
            get { return _c_rCProduct_isdelete; }
            set { _c_rCProduct_isdelete = value; }
        }
        #endregion
    }
}
