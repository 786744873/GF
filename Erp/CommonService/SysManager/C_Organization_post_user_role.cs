using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    public class C_Organization_post_user_role : IC_Organization_post_user_role
    {
        private readonly CommonService.BLL.SysManager.C_Organization_post_user_role bll = new CommonService.BLL.SysManager.C_Organization_post_user_role();
        public C_Organization_post_user_role()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Organization_post_user_role_id)
        {
            return bll.Exists(C_Organization_post_user_role_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Organization_post_user_role model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization_post_user_role model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Organization_post_user_role_id)
        {

            return bll.Delete(C_Organization_post_user_role_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Organization_post_user_role_idlist)
        {
            return bll.DeleteList(C_Organization_post_user_role_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user_role GetModel(int C_Organization_post_user_role_id)
        {

            return bll.GetModel(C_Organization_post_user_role_id);
        }


        /// <summary>
        /// 根据组织机构Guid，用户Guid，岗位Guid,获取关联角色关系数据集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post_user_role> GetOrgUserPostRoles(Guid orgCode, Guid userCode, Guid postCode)
        {
            return bll.GetOrgUserPostRoles(orgCode, userCode, postCode);
        }
        /// <summary>
        /// 根据用户code获得集合
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post_user_role> GetListByUserCode(Guid userCode)
        {
            return bll.GetListByUserCode(userCode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization_post_user_role> GetModelList(string strWhere)
        {
            return bll.GetList(strWhere);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return bll.GetRecordCount(strWhere);
        }        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
