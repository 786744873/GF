using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.FinanceManager
{
    /// <summary>
    /// 凭证信息表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/08/25
    /// </summary>
	public partial class C_Voucher
	{
        private readonly CommonService.DAL.FinanceManager.C_Voucher dal = new CommonService.DAL.FinanceManager.C_Voucher();
		public C_Voucher()
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
		public bool Exists(int C_Voucher_id)
		{
			return dal.Exists(C_Voucher_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FinanceManager.C_Voucher model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.FinanceManager.C_Voucher model)
		{
            if (dal.Update(model))
            {
                dal.UpdateState();
                return true;
            }
            else {
                return false;
            }
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid C_Voucher_code)
		{
			
			return dal.Delete(C_Voucher_code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Voucher_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Voucher_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FinanceManager.C_Voucher GetModel(Guid C_Voucher_code)
		{

            return dal.GetModel(C_Voucher_code);
		}

         /// <summary>
        /// 获取最新的一条数据
        /// </summary>
        public CommonService.Model.FinanceManager.C_Voucher GetNewestModel(Guid creatorCode)
        {
            return dal.GetNewestModel(creatorCode);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.FinanceManager.C_Voucher GetModelByCache(int C_Voucher_id)
		{
			
			string CacheKey = "C_VoucherModel-" + C_Voucher_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Voucher_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.FinanceManager.C_Voucher)objModel;
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
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.FinanceManager.C_Voucher> modelList = new List<CommonService.Model.FinanceManager.C_Voucher>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.FinanceManager.C_Voucher model;
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
        public List<CommonService.Model.FinanceManager.C_Voucher> GetAllList()
		{
            return DataTableToList(dal.GetAllList().Tables[0]);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(CommonService.Model.FinanceManager.C_Voucher model, string rolePowerIds)
		{
			return dal.GetRecordCount(model, rolePowerIds);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher> GetListByPage(CommonService.Model.FinanceManager.C_Voucher model, string rolePowerIds, string orderby, int startIndex, int endIndex)
		{
			return DataTableToList(dal.GetListByPage( model,rolePowerIds,  orderby,  startIndex,  endIndex).Tables[0]);
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

