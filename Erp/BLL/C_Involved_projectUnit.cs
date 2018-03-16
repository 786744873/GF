using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 涉案项目关联单位
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	public partial class C_Involved_projectUnit
	{
        private readonly CommonService.DAL.C_Involved_projectUnit dal = new CommonService.DAL.C_Involved_projectUnit();
		public C_Involved_projectUnit()
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
        public bool Exists(int C_Involved_projectUnit_id)
        {
            return dal.Exists(C_Involved_projectUnit_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Involved_projectUnit model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Involved_projectUnit model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid Involved_projectUnit_code)
		{

            return dal.Delete(Involved_projectUnit_code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Involved_projectUnit_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Involved_projectUnit_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Involved_projectUnit GetModel(int C_Involved_projectUnit_id)
		{
			
			return dal.GetModel(C_Involved_projectUnit_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Involved_projectUnit GetModel(Guid C_Involved_projectUnit_code)
        {

            return dal.GetModel(C_Involved_projectUnit_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Involved_projectUnit GetModelByCache(int C_Involved_projectUnit_id)
		{
			
			string CacheKey = "C_Involved_projectUnitModel-" + C_Involved_projectUnit_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Involved_projectUnit_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Involved_projectUnit)objModel;
		}

        /// <summary>
		/// 获得负责人数据列表
		/// </summary>
        public List<Model.C_Involved_projectUnit> GetChargerList()
		{
            return DataTableToList(dal.GetChargerList().Tables[0]);
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
        //public List<CommonService.Model.C_Involved_projectUnit> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList();
        //    return DataTableToList(ds.Tables[0]);
        //}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Involved_projectUnit> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Involved_projectUnit> modelList = new List<CommonService.Model.C_Involved_projectUnit>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Involved_projectUnit model;
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
		public int GetRecordCount(Model.C_Involved_projectUnit model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<Model.C_Involved_projectUnit> GetListByPage(Model.C_Involved_projectUnit model, string orderby, int startIndex, int endIndex)
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

