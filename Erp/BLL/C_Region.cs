using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 区域表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class C_Region
	{
        private readonly CommonService.DAL.C_Region dal = new CommonService.DAL.C_Region();
        /// <summary>
        /// 组织机构-人员-岗位-区域业务访问层
        /// </summary>
        CommonService.BLL.SysManager.C_Organization_post_user_region orgUserPostRegionBLL = new CommonService.BLL.SysManager.C_Organization_post_user_region();

		public C_Region()
		{}
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
        public bool Exists(int C_Region_Id)
        {
            return dal.Exists(C_Region_Id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Region model)
		{
            if (model.C_Region_parent == null)
            {//根区域添加
                model.C_Region_level = 1;
            }
            else
            {//子区域添加
                CommonService.Model.C_Region parentModel = dal.GetModelByCode(model.C_Region_parent.Value);
                model.C_Region_level = parentModel.C_Region_level + 1;
            }
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Region model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid C_Region_code)
		{
            bool isSuccess = dal.Delete(C_Region_code);
            if (isSuccess)
            {
                List<CommonService.Model.C_Region> Childrenregions = GetModelByParent(C_Region_code);
                foreach (CommonService.Model.C_Region childrenregion in Childrenregions)
                {
                    dal.Delete(childrenregion.C_Region_code.Value);
                    RecursionDelete(childrenregion.C_Region_code.Value);
                }
            }
            return dal.Delete(C_Region_code);
		}

        /// <summary>
        /// 递归删除
        /// </summary>
        /// <returns></returns>
        private void RecursionDelete(Guid C_Region_code)
        {
            List<CommonService.Model.C_Region> ChildrenRegions = GetModelByParent(C_Region_code);
            foreach (CommonService.Model.C_Region childrenRegion in ChildrenRegions)
            {
                dal.Delete(childrenRegion.C_Region_code.Value);
                RecursionDelete(childrenRegion.C_Region_code.Value);
            }
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Region_Idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Region_Idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Region GetModel(int C_Region_Id)
		{
			
			return dal.GetModel(C_Region_Id);
		}

        /// <summary>
        /// 根据GUID得到一个对象实体
        /// </summary>
        /// <param name="C_Region_code">区域guid</param>
        /// <returns></returns>
        public CommonService.Model.C_Region GetModelByCode(Guid C_Region_code)
        {
            return dal.GetModelByCode(C_Region_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Region GetModelByCache(int C_Region_Id)
		{
			
			string CacheKey = "C_RegionModel-" + C_Region_Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Region_Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Region)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 通过父级GUID获取子集集合
        /// </summary>
        public List<CommonService.Model.C_Region> GetModelByParent(Guid C_Region_parent)
        {
            return DataTableToList(dal.GetModelByParent(C_Region_parent).Tables[0]);
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Region> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Region> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Region> modelList = new List<CommonService.Model.C_Region>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Region model;
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
		public List<CommonService.Model.C_Region> GetAllList()
		{
            return DataTableToList(dal.GetAllList().Tables[0]);
		}

        /// <summary>
        /// 获取所有区域，并且根据组织机构Guid，用户Guid，岗位Guid设置关联区域状态值
        /// </summary>
        /// <param name="orgCode">织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>     
        public List<CommonService.Model.C_Region> GetAllRegion(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            List<CommonService.Model.C_Region> Regions = DataTableToList(dal.GetAllList().Tables[0]);//获取所有区域

            if (orgCode != null && userCode != null && postCode != null)
            {
                //获取关联数据集合
                List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgUserPostRegions = orgUserPostRegionBLL.GetOrgUserPostRegions(orgCode.Value, userCode.Value, postCode.Value);
                //设置关联区域状态
                foreach(CommonService.Model.C_Region reg in Regions)
                {
                    if (OrgUserPostRegions.Find(p => p.C_region_code == reg.C_Region_code) != null)
                    {
                        reg.C_Region_isRelated = true;
                    }
                }
            }
            
            return Regions;
        }

         /// <summary>
        /// 获得全部特殊区域数据列表
        /// </summary>
        public List<CommonService.Model.C_Region> GetAllSpecialList()
        {
            return DataTableToList(dal.GetAllSpecialList().Tables[0]);
        }
         /// <summary>
        /// 获得全部律师对应区域的法院
        /// </summary>
        public Guid GetRegionCodeByUsercode(Guid guid)
        {
            return dal.GetRegionCodeByUsercode(guid);
        }
        
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(CommonService.Model.C_Region model)
		{
            return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.C_Region> GetListByPage(CommonService.Model.C_Region model, string orderby, int startIndex, int endIndex)
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

