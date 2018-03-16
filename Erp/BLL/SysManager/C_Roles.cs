using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 角色表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Roles
    {
        private readonly CommonService.DAL.SysManager.C_Roles dal = new CommonService.DAL.SysManager.C_Roles();
        /// <summary>
        /// 组织机构-用户-岗位-角色关系业务访问层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Organization_post_user_role orgUserPostRoleBLL = new CommonService.BLL.SysManager.C_Organization_post_user_role();

        public C_Roles()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Roles_id)
        {
            return dal.Exists(C_Roles_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Roles model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Roles model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Roles_id)
        {

            return dal.Delete(C_Roles_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Roles_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Roles_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Roles GetModel(int C_Roles_id)
        {

            return dal.GetModel(C_Roles_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Roles GetModelByCache(int C_Roles_id)
        {

            string CacheKey = "C_RolesModel-" + C_Roles_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Roles_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Roles)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SysManager.C_Roles> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
        }

        /// <summary>
        /// 获取所有角色，并且根据组织机构Guid，用户Guid，岗位Guid设置关联角色状态值
        /// </summary>
        /// <param name="orgCode">织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>        
        public List<CommonService.Model.SysManager.C_Roles> GetAllRoles(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            List<CommonService.Model.SysManager.C_Roles> Roles = DataTableToList(dal.GetAllList().Tables[0]);
            if (orgCode != null && userCode != null && postCode != null)
            {
                //获取关联数据集合
                List<CommonService.Model.SysManager.C_Organization_post_user_role> OrgUserPostRoles = orgUserPostRoleBLL.GetOrgUserPostRoles(orgCode.Value, userCode.Value, postCode.Value);
                //设置关联角色状态
                foreach (CommonService.Model.SysManager.C_Roles role in Roles)
                {
                    if (OrgUserPostRoles.Find(p => p.C_Role_id == role.C_Roles_id) != null)
                    {
                        role.C_Roles_isRelated = true;
                    }
                }
            }

            return Roles;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Roles> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Roles> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Roles> modelList = new List<CommonService.Model.SysManager.C_Roles>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Roles model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.SysManager.C_Roles model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Roles> GetListByPage(Model.SysManager.C_Roles model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

