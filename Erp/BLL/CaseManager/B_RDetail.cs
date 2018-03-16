using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 收款明细表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/06
    /// </summary>
	public partial class B_RDetail
	{
        private readonly CommonService.DAL.CaseManager.B_RDetail dal = new CommonService.DAL.CaseManager.B_RDetail();
        private readonly CommonService.DAL.CaseManager.B_Case caseDal = new DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.C_Parameters parDal = new DAL.C_Parameters();
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance bcDal = new DAL.BusinessChanceManager.B_BusinessChance();
		public B_RDetail()
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
        public bool Exists(int B_RDetail_id)
        {
            return dal.Exists(B_RDetail_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_RDetail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CaseManager.B_RDetail model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_RDetail_id)
		{
			
			return dal.Delete(B_RDetail_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_RDetail_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_RDetail_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_RDetail GetModel(int B_RDetail_id)
		{
			
			return dal.GetModel(B_RDetail_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CaseManager.B_RDetail GetModelByCache(int B_RDetail_id)
		{
			
			string CacheKey = "B_RDetailModel-" + B_RDetail_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_RDetail_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CaseManager.B_RDetail)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 根据关联Guid获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_RDetail> GetListByRelationCode(Guid relationCode)
        {
            return DataTableToList(dal.GetListByRelationCode(relationCode).Tables[0]);
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
        public List<CommonService.Model.CaseManager.B_RDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_RDetail> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CaseManager.B_RDetail> modelList = new List<CommonService.Model.CaseManager.B_RDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CaseManager.B_RDetail model;
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
		public int GetRecordCount(CommonService.Model.CaseManager.B_RDetail model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<CommonService.Model.CaseManager.B_RDetail> GetListByPage(CommonService.Model.CaseManager.B_RDetail model, string orderby, int startIndex, int endIndex)
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

        /// <summary>
        /// 根据案件GUID得到收款分类关联par实体对象
        /// </summary>
        /// <param name="B_Case_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Parameters GetModelByCaseCode(Guid B_Case_code, int type)
        {
            int caseType = 0;
            if(type==1)
            {
                CommonService.Model.CaseManager.B_Case caseModel = caseDal.GetModel(B_Case_code);
                caseType = caseModel.B_Case_type.Value;
            }else
            {
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessCHanceModel = bcDal.GetModel(B_Case_code);
                caseType = businessCHanceModel.B_BusinessChance_type.Value;
            }

            CommonService.Model.C_Parameters parModel = parDal.GetModelByRelationId(caseType, 2);
            return parModel;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

