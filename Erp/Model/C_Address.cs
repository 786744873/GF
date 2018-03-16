using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 客户地址表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    [Serializable]
    public partial class C_Address
    {
        public C_Address()
        { }
        #region Model
        private int _c_address_id;
        private Guid? _c_address_code;
        private Guid? _c_address_customer;
        private string _c_address_shortname;
        private string _c_address_detail;
        private string _c_address_area;
        private string _c_address_postalcode;
        private bool _c_address_ismainaddress;
        private bool _c_address_isdelete;
        private string _c_address_remark;
        private Guid? _c_address_creator;
        private DateTime? _c_address_createtime;
        /// <summary>
        /// 客户地址ID，主键，自增长
        /// </summary>
        public int C_Address_id
        {
            set { _c_address_id = value; }
            get { return _c_address_id; }
        }
        /// <summary>
        /// 客户地址编码GUID
        /// </summary>
        public Guid? C_Address_code
        {
            set { _c_address_code = value; }
            get { return _c_address_code; }
        }

        /// <summary>
        /// 客户Id：关联客户表Guid字段
        /// </summary>
        public Guid? C_Address_customer
        {
            set { _c_address_customer = value; }
            get { return _c_address_customer; }
        }

        /// <summary>
        /// 地址简称
        /// </summary>
        public string C_Address_shortName
        {
            set { _c_address_shortname = value; }
            get { return _c_address_shortname; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string C_Address_detail
        {
            set { _c_address_detail = value; }
            get { return _c_address_detail; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_Address_area
        {
            set { _c_address_area = value; }
            get { return _c_address_area; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string C_Address_postalCode
        {
            set { _c_address_postalcode = value; }
            get { return _c_address_postalcode; }
        }
        /// <summary>
        /// 是否主要地点：1为是，0为不是
        /// </summary>
        public bool C_Address_isMainAddress
        {
            set { _c_address_ismainaddress = value; }
            get { return _c_address_ismainaddress; }
        }
        /// <summary>
        /// 是否删除：1为已删除；0为未删除
        /// </summary>
        public bool C_Address_isDelete
        {
            set { _c_address_isdelete = value; }
            get { return _c_address_isdelete; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Address_remark
        {
            set { _c_address_remark = value; }
            get { return _c_address_remark; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Address_creator
        {
            set { _c_address_creator = value; }
            get { return _c_address_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Address_createTime
        {
            set { _c_address_createtime = value; }
            get { return _c_address_createtime; }
        }
        #endregion Model

    }
}
