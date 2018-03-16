using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 角色权限表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/07/09
    /// </summary>
    public partial class C_Role_Power
    {
        public C_Role_Power()
        { }
        #region Model
        public int _c_role_power_id;
        public string _c_role_power_name;
        public string _c_role_power_remark;
        public bool _c_role_power_isdelete;
        public Guid? _c_role_power_creator;
        public DateTime? _c_role_power_createtime;
        public int? _c_role_power_type;
        /// <summary>
        /// 角色权限ID,自动增长
        /// </summary>
        public int C_Role_Power_id
        {
            set { _c_role_power_id = value; }
            get { return _c_role_power_id; }
        }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string C_Role_Power_name
        {
            set { _c_role_power_name = value; }
            get { return _c_role_power_name; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Role_Power_remark
        {
            set { _c_role_power_remark = value; }
            get { return _c_role_power_remark; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool C_Role_Power_isDelete
        {
            set { _c_role_power_isdelete = value; }
            get { return _c_role_power_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Role_Power_creator
        {
            set { _c_role_power_creator = value; }
            get { return _c_role_power_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Role_Power_createTime
        {
            set { _c_role_power_createtime = value; }
            get { return _c_role_power_createtime; }
        }
        /// <summary>
        /// 角色权限类型
        /// </summary>
        public int? C_Role_Power_type
        {
            set { _c_role_power_type= value; }
            get { return _c_role_power_type; }
        }
        #endregion Model

    }
}
