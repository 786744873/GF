using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 角色--按钮中间表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Role_button
    {
        private readonly CommonService.DAL.SysManager.C_Role_button dal = new CommonService.DAL.SysManager.C_Role_button();
        public C_Role_button()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Role_button model)
        {
            dal.Delete(model.C_Roles_id.Value, model.C_Menu_buttons_id.Value);
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_button model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Roles_id, int C_Menu_buttons_id)
        {
            return dal.Delete(C_Roles_id, C_Menu_buttons_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Role_button GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Role_button GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "C_Role_buttonModel-";
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel();
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Role_button)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="C_Roles_id">角色ID</param>
        /// <param name="C_Menu_id">菜单ID</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetListByMenuId(int C_Roles_id, int C_Menu_id)
        {
            return DataTableToList(dal.GetListByMenuId(C_Roles_id, C_Menu_id).Tables[0]);
        }


        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsByRoleId(int roleId)
        {
            return DataTableToList(dal.GetButtonsByRoleId(roleId).Tables[0]);
        }

        /// <summary>
        /// 根据用户Code，获取用户关联按钮集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsByUserCode(Guid userCode)
        {
            return DataTableToList(dal.GetButtonsByUserCode(userCode).Tables[0]);
        }

        /// <summary>
        /// 根据角色Id集合，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsListByRolesId(string rolesId)
        {
            return DataTableToList(dal.GetButtonsListByRolesId(rolesId).Tables[0]);
        }

        // <summary>
        /// 根据组织机构Guid、用户Guid、岗位Guid，获取关联角色关联按钮集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>    
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsListByOrgUserPostCode(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            return DataTableToList(dal.GetButtonsListByOrgUserPostCode(orgCode, userCode, postCode).Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Role_button> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_button> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Role_button> modelList = new List<CommonService.Model.SysManager.C_Role_button>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Role_button model;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.SysManager.C_Role_button model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Role_button> GetListByPage(Model.SysManager.C_Role_button model, string orderby, int startIndex, int endIndex)
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

        /// <summary>
        /// 根据角色ID删除所有角色与按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>是否成功</returns>
        public bool DeleteRoleButtonByRoleID(int roleID)
        {
            return dal.DeleteRoleButtonByRoleID(roleID);
        }

        /// <summary>
        /// 批量添加同一角色与多个按钮之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="buttons">按钮ID集合</param>
        public void AddUserinfoAreas(int roleID, List<int> buttons)
        {
            foreach (int item in buttons)
            {
                Model.SysManager.C_Role_button model = new Model.SysManager.C_Role_button();
                model.C_Roles_id = roleID;
                model.C_Menu_buttons_id = item;
                Add(model);
            }
        }
        #endregion  ExtensionMethod
    }
}

