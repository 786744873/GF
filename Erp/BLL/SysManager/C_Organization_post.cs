using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 组织架构--岗位中间表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
    public partial class C_Organization_post
    {
        private readonly CommonService.DAL.SysManager.C_Organization_post dal = new CommonService.DAL.SysManager.C_Organization_post();
        private readonly CommonService.DAL.SysManager.C_Role_Role_Power powerDal = new DAL.SysManager.C_Role_Role_Power();
        private readonly CommonService.BLL.SysManager.C_Userinfo userBll = new BLL.SysManager.C_Userinfo();
        public C_Organization_post()
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
        public bool Exists(int C_Organization_post_id)
        {
            return dal.Exists(C_Organization_post_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization_post model)
        {
            object obj = null;
            obj = dal.DeleteByPostCode(model.C_Post_code.Value, model.C_Organization_code.Value);
            obj = dal.Add(model);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization_post model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Organization_post_id)
        {

            return dal.Delete(C_Organization_post_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Organization_post_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Organization_post_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post GetModel(int C_Organization_post_id)
        {

            return dal.GetModel(C_Organization_post_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post GetModelByCache(int C_Organization_post_id)
        {

            string CacheKey = "C_Organization_postModel-" + C_Organization_post_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Organization_post_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Organization_post)objModel;
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
        public List<CommonService.Model.SysManager.C_Organization_post> GetListByOrgCode(Guid organizationCode)
        {
            return DataTableToList(dal.GetListByOrgCode(organizationCode).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 通过组织机构Guid，获取关联岗位集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByOrg(Guid orgCode)
        {
            Guid? organizationCode = null;
            if (!orgCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                organizationCode = orgCode;
            }
            return DataTableToList(dal.GetRelationPostsByOrg(organizationCode).Tables[0]);
        }
        //根据组织架构和子级组织结构获取所有职位
        public List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByOrgList(List<Guid> orgCode)
        {
           
            return DataTableToList(dal.GetRelationPostsByOrgList(orgCode).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization_post> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization_post> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Organization_post> modelList = new List<CommonService.Model.SysManager.C_Organization_post>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Organization_post model;
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
        public int GetRecordCount(Model.SysManager.C_Organization_post model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Organization_post> GetListByPage(Model.SysManager.C_Organization_post model, string orderby, int startIndex, int endIndex)
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
        ///// <summary>
        ///// 通过权限id，获取关联岗位集合
        ///// </summary>
        ///// <param name="orgCode">权限</param>
        ///// <returns></returns>
        //public List<CommonService.Model.SysManager.C_Organization_post> GetRelationPostsByPowerid(int powerId)
        //{
        //    List<CommonService.Model.SysManager.C_Organization_post> list = new List<Model.SysManager.C_Organization_post>();
        //    //先根据权限id获取角色id
        //    CommonService.Model.SysManager.C_Role_Role_Power powerModel = powerDal.GetModel(powerId);
        //    if (powerModel != null)
        //    {
        //        int roleID = Convert.ToInt32(powerModel.C_Roles_id);
        //        //根据角色id去查找所有的用户
        //        List<CommonService.Model.SysManager.C_Userinfo> userList = userBll.GetListByRoleid(roleID);
        //        string postStr = "";
        //        //再根据用户去查询所有的岗位
        //        foreach (var model in userList)
        //        {
        //            if (model.C_Userinfo_post != null && model.C_Userinfo_post.ToString() != "")
        //                postStr += model.C_Userinfo_post.ToString() + ",";
        //        }
        //        list = DataTableToList(dal.GetRelationPostsByPostStr(postStr).Tables[0]);
        //    }
        //    return list;
        //}
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

