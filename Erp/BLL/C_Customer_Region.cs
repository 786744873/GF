using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 客户区域关系表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/24
    /// </summary>
	public partial class C_Customer_Region
	{
        private readonly CommonService.DAL.C_Customer_Region dal = new CommonService.DAL.C_Customer_Region();
		public C_Customer_Region()
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
		public bool Exists(int C_Customer_Region_Id)
		{
			return dal.Exists(C_Customer_Region_Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Customer_Region model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.C_Customer_Region> B_Customer_Regions)
        {
            //根据案件Guid删除关联所有数据
            foreach (CommonService.Model.C_Customer_Region customerRegion in B_Customer_Regions)
            {
                dal.Delete(new Guid(customerRegion.C_Customer_Region_customer.ToString()), new Guid(customerRegion.C_Customer_Region_relRegion.ToString()));
            }
            foreach (CommonService.Model.C_Customer_Region customerRegion in B_Customer_Regions)
            {
                dal.Add(customerRegion);
            }
            return true;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Customer_Region model)
		{
			return dal.Update(model);
		}

          /// <summary>
        /// 根据客户Guid删除数据
        /// </summary>
        public bool DeleteByCustomerCode(Guid C_Customer_Region_customer)
        {
            return dal.DeleteByCustomerCode(C_Customer_Region_customer);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public bool Delete(int C_Customer_Region_Id)
        //{
			
        //    return dal.Delete(C_Customer_Region_Id);
        //}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Customer_Region_Idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Customer_Region_Idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Customer_Region GetModel(int C_Customer_Region_Id)
		{
			
			return dal.GetModel(C_Customer_Region_Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Customer_Region GetModelByCache(int C_Customer_Region_Id)
		{
			
			string CacheKey = "C_Customer_RegionModel-" + C_Customer_Region_Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Customer_Region_Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Customer_Region)objModel;
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
        public List<CommonService.Model.C_Customer_Region> GetListByCustomerCode(Guid C_Customer_Region_customer)
		{
            return DataTableToList(dal.GetListByCustomerCode(C_Customer_Region_customer).Tables[0]);
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
        public List<CommonService.Model.C_Customer_Region> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Customer_Region> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Customer_Region> modelList = new List<CommonService.Model.C_Customer_Region>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Customer_Region model;
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
		public int GetRecordCount(CommonService.Model.C_Customer_Region model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.C_Customer_Region> GetListByPage(CommonService.Model.C_Customer_Region model, string orderby, int startIndex, int endIndex)
		{
			return DataTableToList(dal.GetListByPage( model,  orderby,  startIndex,  endIndex).Tables[0]);
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

