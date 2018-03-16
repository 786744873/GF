using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    /// <summary>
    /// 用户-部门-岗位关系(虚拟实体)
    /// </summary>
    public class V_User_Org_Post
    {
        /// <summary>
        /// 部门Guid
        /// </summary>
        public Guid? OrgCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 部门所属区域Guid
        /// </summary>
        public Guid? OrgRegionCode { get; set; }

        /// <summary>
        /// 部门所属区域名称
        /// </summary>
        public string OrgRegionName { get; set; }

        /// <summary>
        /// 岗位Guid
        /// </summary>
        public Guid? PostCode { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// 岗位组Guid
        /// </summary>
        public Guid? PostGroupCode { get; set; }

        /// <summary>
        /// 岗位组名称
        /// </summary>
        public string PostGroupName { get; set; }

    }
}
