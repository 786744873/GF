using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 组织机构—岗位—人员-区域表业务逻辑层
    /// 作者：贺太玉
    /// 日期：2016/01/21
    /// </summary>
    public partial class C_Organization_post_user_region
    {
        private readonly CommonService.DAL.SysManager.C_Organization_post_user_region dal = new CommonService.DAL.SysManager.C_Organization_post_user_region();
        public C_Organization_post_user_region()
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
        public bool Exists(int C_Organization_post_user_region_id)
        {
            return dal.Exists(C_Organization_post_user_region_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization_post_user_region model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization_post_user_region model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Organization_post_user_region_id)
        {

            return dal.Delete(C_Organization_post_user_region_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Organization_post_user_region_idlist)
        {
            return dal.DeleteList(C_Organization_post_user_region_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user_region GetModel(int C_Organization_post_user_region_id)
        {

            return dal.GetModel(C_Organization_post_user_region_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Organization_post_user_region GetModelByCache(int C_Organization_post_user_region_id)
        {

            string CacheKey = "C_Organization_post_user_regionModel-" + C_Organization_post_user_region_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Organization_post_user_region_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Organization_post_user_region)objModel;
        }

                /// <summary>
        /// 根据组织机构Guid，用户Guid，岗位Guid,获取关联区域关系数据集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization_post_user_region> GetOrgUserPostRegions(Guid orgCode, Guid userCode, Guid postCode)
        {
            DataSet ds = dal.GetOrgUserPostRegions(orgCode, userCode, postCode);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 根据用户获取数据
        /// </summary>
        /// <param name="UserinfoCode"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Organization_post_user_region> GetListByUserinfoCode(Guid UserinfoCode)
        {
            DataSet ds = dal.GetListByUserinfoCode(UserinfoCode);
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
        public List<CommonService.Model.SysManager.C_Organization_post_user_region> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization_post_user_region> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Organization_post_user_region> modelList = new List<CommonService.Model.SysManager.C_Organization_post_user_region>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Organization_post_user_region model;
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
