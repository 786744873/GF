using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 组织机构—岗位—人员表业务逻辑层
    /// 作者：贺太玉
    /// 日期：2016/01/21
    /// </summary>
    public partial class C_Organization_post_user
    {
        private readonly CommonService.DAL.SysManager.C_Organization_post_user dal = new CommonService.DAL.SysManager.C_Organization_post_user();
        public C_Organization_post_user()
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
        /// 检查是否存在记录
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">人员Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public bool Exists(Guid orgCode,Guid userCode,Guid postCode)
        {
            return dal.Exists(orgCode, userCode, postCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization_post_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization_post_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Organization_post_user_id)
        {

            return dal.Delete(C_Organization_post_user_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Organization_post_user_idlist)
        {
            return dal.DeleteList(C_Organization_post_user_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user GetModel(int C_Organization_post_user_id)
        {

            return dal.GetModel(C_Organization_post_user_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user GetModelByCache(int C_Organization_post_user_id)
        {

            string CacheKey = "C_Organization_post_userModel-" + C_Organization_post_user_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Organization_post_user_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Organization_post_user)objModel;
        }

        /// <summary>
        /// 根据部门Guid，人员Guid，获取所分配岗位
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">人员Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post_user> GetHasDisbutedPosts(Guid? orgCode, Guid? userCode)
        {
            DataSet ds = dal.GetHasDisbutedPosts(orgCode, userCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据人员Guid，获取人员所属岗位集合
        /// </summary>
        /// <param name="userCode">人员Guid</param>
        /// <returns></returns>      
        public List<CommonService.Model.SysManager.C_Organization_post_user> GetHasDisbutedPostsByUser(Guid? userCode)
        {
            DataSet ds = dal.GetHasDisbutedPostsByUser(userCode);
            return DataTableToList(ds.Tables[0]);
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
        public List<CommonService.Model.SysManager.C_Organization_post_user> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization_post_user> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Organization_post_user> modelList = new List<CommonService.Model.SysManager.C_Organization_post_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Organization_post_user model;
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
