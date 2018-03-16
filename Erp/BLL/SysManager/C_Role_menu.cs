using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 角色--菜单中间表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Role_menu
    {
        private readonly CommonService.DAL.SysManager.C_Role_menu dal = new CommonService.DAL.SysManager.C_Role_menu();
        private readonly CommonService.DAL.SysManager.C_Role_button butDal = new DAL.SysManager.C_Role_button();
        private readonly CommonService.DAL.SysManager.C_Menu mDal = new DAL.SysManager.C_Menu();
        private readonly CommonService.BLL.SysManager.C_Menu mBll = new BLL.SysManager.C_Menu();
        public C_Role_menu()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Role_menu model)
        {
            List<int> menuParent = new List<int>();
            CommonService.Model.SysManager.C_Menu menu = mDal.GetModel(model.C_Menu_id.Value);
            List<CommonService.Model.SysManager.C_Role_menu> role_menus=GetListByRoleId(model.C_Roles_id.Value);
            foreach (var role_menu in role_menus)
            {
                menuParent.Add(role_menu.C_Menu_id.Value);
            }
            if(!menuParent.Contains(menu.C_Menu_parent.Value))
            {
                CommonService.Model.SysManager.C_Role_menu rmModel = new Model.SysManager.C_Role_menu();
                rmModel.C_Roles_id = model.C_Roles_id;
                rmModel.C_Menu_id = menu.C_Menu_parent;
                dal.Add(rmModel);
            }
            dal.Delete(model.C_Roles_id.Value,model.C_Menu_id.Value);
            
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Role_menu model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Roles_id, int C_Menu_id)
        {
            bool isSuccess = true;
            isSuccess = dal.Delete(C_Roles_id, C_Menu_id);
            List<CommonService.Model.SysManager.C_Menu> menus = mBll.GetModelByParent(C_Menu_id);
            foreach(CommonService.Model.SysManager.C_Menu menu in menus)
            {
                isSuccess = dal.Delete(C_Roles_id,menu.C_Menu_id);
            }
            isSuccess = butDal.DeleteByMenuId(C_Roles_id,C_Menu_id);
            return isSuccess;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Role_menu GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Role_menu GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "C_Role_menuModel-";
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
            return (CommonService.Model.SysManager.C_Role_menu)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public List<CommonService.Model.SysManager.C_Role_menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Role_menu> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Role_menu> modelList = new List<CommonService.Model.SysManager.C_Role_menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Role_menu model;
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
        /// 获得数据列表
        /// </summary>
        /// <param name="C_Roles_id"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_menu> GetListByRoleId(int C_Roles_id)
        {
            return DataTableToList(dal.GetListByRoleId(C_Roles_id).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.SysManager.C_Role_menu model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Role_menu> GetListByPage(Model.SysManager.C_Role_menu model, string orderby, int startIndex, int endIndex)
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
        /// 根据角色ID删除所有角色与菜单之间的关系
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool DeleteRoleMenuByRoleID(int roleID)
        {
            return dal.DeleteRoleMenuByRoleID(roleID);
        }

        /// <summary>
        /// 批量添加同一角色与多个菜单之间的关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="menus">菜单ID集合</param>
        public void AddUserinfoAreas(int roleID, List<int> menus)
        {
            foreach (int item in menus)
            {
                Model.SysManager.C_Role_menu model = new Model.SysManager.C_Role_menu();
                model.C_Roles_id = roleID;
                model.C_Menu_id = item;
                Add(model);
            }
        }

        #endregion  ExtensionMethod
    }
}

