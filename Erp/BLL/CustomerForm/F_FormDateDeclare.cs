using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.CustomerForm
{
    /// <summary>
    /// 表单时间声明表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/08
    /// </summary>
	public partial class F_FormDateDeclare
	{
        private readonly CommonService.DAL.CustomerForm.F_FormDateDeclare dal = new CommonService.DAL.CustomerForm.F_FormDateDeclare();
		public F_FormDateDeclare()
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
        public bool Exists(int F_FormDateDeclare_id)
        {
            return dal.Exists(F_FormDateDeclare_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.CustomerForm.F_FormDateDeclare model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormDateDeclare model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int F_FormDateDeclare_id)
		{
            return dal.Delete(F_FormDateDeclare_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CustomerForm.F_FormDateDeclare GetModel(int F_FormDateDeclare_id)
		{
            return dal.GetModel(F_FormDateDeclare_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CustomerForm.F_FormDateDeclare GetModelByCache(int F_FormDateDeclare_id)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "F_FormDateDeclareModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(F_FormDateDeclare_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CustomerForm.F_FormDateDeclare)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
        /// <summary>
        /// 根据表单GUID获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormDateDeclare> GetListByFormCode(Guid F_FormDateDeclare_formCode, int F_FormDateDeclare_type)
        {
            return DataTableToList(dal.GetListByFormCode(F_FormDateDeclare_formCode, F_FormDateDeclare_type).Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CustomerForm.F_FormDateDeclare> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CustomerForm.F_FormDateDeclare> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CustomerForm.F_FormDateDeclare> modelList = new List<CommonService.Model.CustomerForm.F_FormDateDeclare>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CustomerForm.F_FormDateDeclare model;
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
		public int GetRecordCount(CommonService.Model.CustomerForm.F_FormDateDeclare model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.CustomerForm.F_FormDateDeclare> GetListByPage(CommonService.Model.CustomerForm.F_FormDateDeclare model, string orderby, int startIndex, int endIndex)
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

