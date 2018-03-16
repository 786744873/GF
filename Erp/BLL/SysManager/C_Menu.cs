using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 菜单表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Menu
    {
        private readonly CommonService.DAL.SysManager.C_Menu dal = new CommonService.DAL.SysManager.C_Menu();
        private readonly CommonService.DAL.SysManager.C_Menu_buttons butDal = new DAL.SysManager.C_Menu_buttons();
        public C_Menu()
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
        public bool Exists(int C_Menu_id)
        {
            return dal.Exists(C_Menu_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Menu model)
        {
            if (model.C_Menu_parent == 0)
            {
                CommonService.Model.SysManager.C_Menu menu = dal.GetMaxOrderModel();
                model.C_Menu_order = menu == null ? 1 : menu.C_Menu_order.Value + 1;
            }
            else
            {
                CommonService.Model.SysManager.C_Menu menu = dal.GetMaxOrderModelByParent(model.C_Menu_parent.Value);
                model.C_Menu_order = menu == null ? 1 : menu.C_Menu_order.Value + 1;
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Menu model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Menu_id)
        {
            bool isSuccess = dal.Delete(C_Menu_id);
            butDal.DeleteByMenuId(C_Menu_id);
            if (isSuccess)
            {
                List<CommonService.Model.SysManager.C_Menu> ChildrenMenus = GetModelByParent(C_Menu_id);
                foreach (CommonService.Model.SysManager.C_Menu childrenMenu in ChildrenMenus)
                {
                    dal.Delete(childrenMenu.C_Menu_id);
                    butDal.DeleteByMenuId(childrenMenu.C_Menu_id);
                    RecursionDelete(childrenMenu.C_Menu_id);
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// 递归删除
        /// </summary>
        /// <returns></returns>
        private void RecursionDelete(int parentMenuId)
        {
            List<CommonService.Model.SysManager.C_Menu> ChildrenMenus = GetModelByParent(parentMenuId);
            foreach (CommonService.Model.SysManager.C_Menu childrenMenu in ChildrenMenus)
            {
                dal.Delete(childrenMenu.C_Menu_id);
                butDal.DeleteByMenuId(childrenMenu.C_Menu_id);
                RecursionDelete(childrenMenu.C_Menu_id);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Menu_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Menu_idlist, 0));
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <returns></returns>
        public bool MoveForward(int menuId)
        {
            CommonService.Model.SysManager.C_Menu thisMenu = dal.GetModel(menuId);
            CommonService.Model.SysManager.C_Menu forwardMenu = dal.GetModel(ConditonType.小于, thisMenu.C_Menu_order.Value, thisMenu.C_Menu_parent.Value);
            if (forwardMenu != null)
            {
                int thisMenuOrderBy = thisMenu.C_Menu_order.Value;
                int forwardMenuOrderBy = forwardMenu.C_Menu_order.Value;
                thisMenu.C_Menu_order = forwardMenuOrderBy;
                dal.Update(thisMenu);
                forwardMenu.C_Menu_order = thisMenuOrderBy;
                dal.Update(forwardMenu);
            }
            return true;
        }

        /// <summary>
        /// 向后移动
        /// </summary>      
        /// <returns></returns>
        public bool MoveBackward(int menuId)
        {
            CommonService.Model.SysManager.C_Menu thisMenu = dal.GetModel(menuId);
            CommonService.Model.SysManager.C_Menu backwardMenu = dal.GetModel(ConditonType.大于, thisMenu.C_Menu_order.Value, thisMenu.C_Menu_parent.Value);
            if (backwardMenu != null)
            {
                int thisMenuOrderBy = thisMenu.C_Menu_order.Value;
                int backwardMenuOrderBy = backwardMenu.C_Menu_order.Value;
                thisMenu.C_Menu_order = backwardMenuOrderBy;
                dal.Update(thisMenu);
                backwardMenu.C_Menu_order = thisMenuOrderBy;
                dal.Update(backwardMenu);
            }
            return true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Menu GetModel(int C_Menu_id)
        {

            return dal.GetModel(C_Menu_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Menu GetModelByCache(int C_Menu_id)
        {

            string CacheKey = "C_MenuModel-" + C_Menu_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Menu_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Menu)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 通过父级机构Guid，获取子集机构集合
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Menu> GetModelByParent(int parentId)
        {
            return DataTableToList(dal.GetModelByParent(parentId).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SysManager.C_Menu> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过角色，获取角色管理所有菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// param name="isSysManager">是否内置系统管理员</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Menu> GetModelListByRole(int? roleId, bool isSysManager)
        {
            DataSet ds = dal.GetModelListByRole(roleId, isSysManager);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 根据用户角色获得用户菜单集合
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="isSysManager"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Menu> GetMenuListByRoles(Guid userCode, bool isSysManager)
        {
            return DataTableToList(dal.GetMenuListByRoles(userCode, isSysManager).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Menu> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Menu> modelList = new List<CommonService.Model.SysManager.C_Menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Menu model;
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
        public int GetRecordCount(Model.SysManager.C_Menu model)
        {
            return dal.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Menu> GetListByPage(Model.SysManager.C_Menu model, string orderby, int startIndex, int endIndex)
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
        /// 根据角色获取菜单
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>菜单列表</returns>
        public List<Model.SysManager.C_Menu> GetMenusByRoleID(int roleID)
        {
            return DataTableToList(dal.GetMenusByRoleID(roleID).Tables[0]);
        }
        #endregion  ExtensionMethod
    }
}

