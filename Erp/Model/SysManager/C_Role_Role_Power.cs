using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 角色-角色权限关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/07/09
    /// </summary>
    [Serializable]
    public partial class C_Role_Role_Power
    {
        public C_Role_Role_Power()
        { }
        #region Model
        private int _c_role_role_power_id;
        private int? _c_roles_id;
        private int? _c_role_power_id;
        string _c_role_power_name;
        /// <summary>
        /// 角色---角色权限关联ID，自动增长
        /// </summary>
        public int C_Role_Role_Power_id
        {
            set { _c_role_role_power_id = value; }
            get { return _c_role_role_power_id; }
        }
        /// <summary>
        /// 角色ID,角色表外键
        /// </summary>
        public int? C_Roles_id
        {
            set { _c_roles_id = value; }
            get { return _c_roles_id; }
        }
        /// <summary>
        /// 角色权限ID,角色权限表外键
        /// </summary>
        public int? C_Role_Power_id
        {
            set { _c_role_power_id = value; }
            get { return _c_role_power_id; }
        }
        /// <summary>
        /// 角色权限名称(虚拟属性)
        /// </summary>
        public string C_Role_Power_name
        {
            set { _c_role_power_name = value; }
            get { return _c_role_power_name; }
        }

        #endregion Model

    }
}
