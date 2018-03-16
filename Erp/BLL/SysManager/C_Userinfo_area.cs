using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 用户--区域中间表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Userinfo_region
    {
        private readonly CommonService.DAL.SysManager.C_Userinfo_region dal = new CommonService.DAL.SysManager.C_Userinfo_region();
        public C_Userinfo_region()
        { }
        #region  BasicMethod
        /// <summary>
        /// 查找是否存在一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exits(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            return dal.Exits(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            bool isSuccess = true;
            isSuccess = dal.Delete(model.C_Userinfo_code.Value,model.C_Region_code.Value);
            isSuccess = dal.Add(model);
            
            return isSuccess;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid userCode ,Guid Region_code)
        {
            return dal.Delete(userCode, Region_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo_region GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
        }

        /// <summary>
        /// 根据用户Guid得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo_region GetModelByUserinfoCode(Guid UserinfoCode)
        {
            return dal.GetModelByUserinfoCode(UserinfoCode);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo_region GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "C_Userinfo_areaModel-";
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
            return (CommonService.Model.SysManager.C_Userinfo_region)objModel;
        }

         /// <summary>
        /// 根据用户获得关联数据
        /// </summary>
        /// <param name="userCode">用户GUID</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo_region> GetListByUserinfoCode(Guid userCode)
        {
            return DataTableToList(dal.GetListByUserinfoCode(userCode).Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Userinfo_region> GetListByRoleId(Guid? userCode)
        {
            return DataTableToList(dal.GetListByRoleId(userCode).Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Userinfo_region> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo_region> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Userinfo_region> modelList = new List<CommonService.Model.SysManager.C_Userinfo_region>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Userinfo_region model;
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
        public int GetRecordCount(Model.SysManager.C_Userinfo_region model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Userinfo_region> GetListByPage(Model.SysManager.C_Userinfo_region model, string orderby, int startIndex, int endIndex)
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
        /// 根据用户编码删除所有的用户和区域之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        public bool DeleteUserinfoAreaByUserCode(Guid userCode)
        {
            return dal.DeleteUserinfoAreaByUserCode(userCode);
        }
        
        /// <summary>
        /// 批量添加同一用户与多个区域之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="areaIDs">区域ID集合</param>
        //public void AddUserinfoAreas(int userCode,List<> areaIDs)
        //{
        //    foreach (int item in areaIDs)
        //    {
        //        Model.C_Role_region model = new Model.C_Role_region();
        //        model.C_Roles_id = userCode;
        //        model.C_Region_code = item;
        //        Add(model);
        //    }
        //}
        #endregion  ExtensionMethod
    }
}

