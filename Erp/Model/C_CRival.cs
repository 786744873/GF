using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// (企业)法律对手信息表表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/04/23
    /// </summary>
    [Serializable]
    public partial class C_CRival
    {
        public C_CRival()
        { }
        #region
        public int _c_crival_id;
        public Guid? _c_crival_code;
        public string _c_crival_number;
        public string _c_crival_name;
        public string _c_crival_iland;
        public string _c_crival_aland;
        public DateTime? _c_crival_fregtime;
        public int? _c_crival_ftype;
        public decimal? _c_crival_rassets;
        public int? _c_crival_corgan;
        public string _c_crival_acase;
        public int? _c_crival_smodel;
        public string _c_crival_mitem;
        public string _c_crival_eitem;
        public string _c_crival_phone;
        public string _c_crival_link;
        public string _c_crival_email;
        public string _c_crival_ehonor;
        public int? _c_crival_isdelete;
        public DateTime? _c_crival_cdate;
        public Guid? _c_crival_cuserid;
        public string _c_crival_region_code;
        public string _c_crival_region_name;
        
        
        /// <summary>
        /// (企业)法律对手内码,主键,自增
        /// </summary>
        public int C_CRival_id
        {
            get { return _c_crival_id; }
            set { _c_crival_id = value; }
        }

        /// <summary>
        /// (企业)法律对手编码,RM过来的用　3位数字，如（001）前台自动生成。如果本系统自建，用 CRIVA+当前时间+4位数字。
        /// </summary>
        public Guid? C_CRival_code
        {
            get { return _c_crival_code; }
            set { _c_crival_code = value; }
        }

        /// <summary>
        /// (企业)法律对手代码
        /// </summary>
        public string C_CRival_number
        {
            get { return _c_crival_number; }
            set { _c_crival_number = value; }
        }
        
        /// <summary>
        /// 企业名称
        /// </summary>
        public string C_CRival_name
        {
            get { return _c_crival_name; }
            set { _c_crival_name = value; }
        }

        /// <summary>
        /// 工商注册地
        /// </summary>
        public string C_CRival_iland
        {
            get { return _c_crival_iland; }
            set { _c_crival_iland = value; }
        }

        /// <summary>
        /// 实际经营地
        /// </summary>
        public string C_CRival_aland
        {
            get { return _c_crival_aland; }
            set { _c_crival_aland = value; }
        }

        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime? C_CRival_fregtime
        {
            get { return _c_crival_fregtime; }
            set { _c_crival_fregtime = value; }
        }

        /// <summary>
        /// 企业类型,1有企业 ②集体所有制企业 ③私营企业 ④股份制企业 ⑤联营企业 ⑥外商投资企业 ⑦港澳台投资企业 ⑧股份合作企业
        /// </summary>
        public int? C_CRival_ftype
        {
            get { return _c_crival_ftype; }
            set { _c_crival_ftype = value; }
        }

        /// <summary>
        /// 注册资本
        /// </summary>
        public decimal? C_CRival_rassets
        {
            get { return _c_crival_rassets; }
            set { _c_crival_rassets = value; }
        }

        /// <summary>
        /// 资本结构,1有资本 ②法人资本 ③个人资本 ④港澳台商资本 ⑤外商资本
        /// </summary>
        public int? C_CRival_corgan
        {
            get { return _c_crival_corgan; }
            set { _c_crival_corgan = value; }
        }

        /// <summary>
        /// 资质情况
        /// </summary>
        public string C_CRival_acase
        {
            get { return _c_crival_acase; }
            set { _c_crival_acase = value; }
        }

        /// <summary>
        /// 经营模式,1纯直营  ②直营为主 ③单纯挂靠 ④挂靠为主
        /// </summary>
        public int? C_CRival_smodel
        {
            get { return _c_crival_smodel; }
            set { _c_crival_smodel = value; }
        }

        /// <summary>
        /// 主营项目
        /// </summary>
        public string C_CRival_mitem
        {
            get { return _c_crival_mitem; }
            set { _c_crival_mitem = value; }
        }

        /// <summary>
        /// 曾经承建的项目
        /// </summary>
        public string C_CRival_eitem
        {
            get { return _c_crival_eitem; }
            set { _c_crival_eitem = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string C_CRival_phone
        {
            get { return _c_crival_phone; }
            set { _c_crival_phone = value; }
        }

        /// <summary>
        /// 网页链接
        /// </summary>
        public string C_CRival_link
        {
            get { return _c_crival_link; }
            set { _c_crival_link = value; }
        }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string C_CRival_email
        {
            get { return _c_crival_email; }
            set { _c_crival_email = value; }
        }

        /// <summary>
        /// 企业荣誉
        /// </summary>
        public string C_CRival_ehonor
        {
            get { return _c_crival_ehonor; }
            set { _c_crival_ehonor = value; }
        }

        /// <summary>
        /// 是否删除，0-否，1-是
        /// </summary>
        public int? C_CRival_isdelete
        {
            get { return _c_crival_isdelete; }
            set { _c_crival_isdelete = value; }
        }
        
        /// <summary>
        /// 创建日期,时间存当期系统时间
        /// </summary>
        public DateTime? C_CRival_cdate
        {
            get { return _c_crival_cdate; }
            set { _c_crival_cdate = value; }
        }

        /// <summary>
        /// 创建人,关联U_user获取当前登录用户
        /// </summary>
        public Guid? C_CRival_cuserid
        {
            get { return _c_crival_cuserid; }
            set { _c_crival_cuserid = value; }
        }
        /// <summary>
        /// 对手关联区域GUID（虚拟字段）
        /// </summary>
        public string C_CRival_region_code
        {
            get { return _c_crival_region_code; }
            set { _c_crival_region_code = value; }
        }
        /// <summary>
        /// 对手关联区域名称（虚拟字段）
        /// </summary>
        public string C_CRival_region_name
        {
            get { return _c_crival_region_name; }
            set { _c_crival_region_name = value; }
        }
        #endregion
    }
}
