using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件--涉案合同权益分配表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/04
    /// </summary>
	public partial class B_EqAllot
	{
        private readonly CommonService.DAL.CaseManager.B_EqAllot dal = new CommonService.DAL.CaseManager.B_EqAllot();
        private readonly CommonService.DAL.CaseManager.B_Case caseDal = new DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.C_Parameters parDal = new DAL.C_Parameters();
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance bcDal = new DAL.BusinessChanceManager.B_BusinessChance();
		public B_EqAllot()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="B_EqAllot_id"></param>
        /// <returns></returns>
        public bool Exists(int B_EqAllot_id)
        {
            return dal.Exists(B_EqAllot_id);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.CaseManager.B_EqAllot model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.CaseManager.B_EqAllot model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_EqAllot_id)
		{
			
			return dal.Delete(B_EqAllot_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_EqAllot_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_EqAllot_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.CaseManager.B_EqAllot GetModel(Guid B_Case_code, int B_EqAllot_pright)
		{
			
			return dal.GetModel(B_Case_code, B_EqAllot_pright);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.CaseManager.B_EqAllot GetModelByCache(int B_EqAllot_id)
		{
			
			string CacheKey = "B_EqAllotModel-" + B_EqAllot_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_EqAllot_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.CaseManager.B_EqAllot)objModel;
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
        public List<CommonService.Model.CaseManager.B_EqAllot> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_EqAllot> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.CaseManager.B_EqAllot> modelList = new List<CommonService.Model.CaseManager.B_EqAllot>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.CaseManager.B_EqAllot model;
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
        public List<CommonService.Model.CaseManager.B_EqAllot> GetAllList(Guid B_Case_code)
        {
            CommonService.Model.CaseManager.B_Case caseModel = caseDal.GetModel(B_Case_code);
            return DataTableToList(dal.GetAllList(B_Case_code, caseModel.B_Case_type.Value).Tables[0]);
		}

         /// <summary>
        /// 根据关联Guid获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_EqAllot> GetAllListByCaseCode(Guid B_Case_code)
        {
            return DataTableToList(dal.GetAllListByCaseCode(B_Case_code).Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(CommonService.Model.CaseManager.B_EqAllot model, int type)
		{
            int caseType = 0;
            CommonService.Model.CaseManager.B_Case caseModel = caseDal.GetModel(model.B_Case_code.Value);
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChanceModel = bcDal.GetModel(model.B_Case_code.Value);
            if(type==1)
            {
                caseType = caseModel.B_Case_type.Value;
            }else
            {
                caseType = businessChanceModel.B_BusinessChance_type.Value;
            }
            CommonService.Model.C_Parameters parModel = parDal.GetModelByRelationId(caseType, model.B_EqAllot_relationid.Value);
            model.B_Case_type = parModel.C_Parameters_id;
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.CaseManager.B_EqAllot> GetListByPage(CommonService.Model.CaseManager.B_EqAllot model, string orderby, int startIndex, int endIndex, int type)
        {
            int caseType = 0;
            CommonService.Model.CaseManager.B_Case caseModel = caseDal.GetModel(model.B_Case_code.Value);
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChanceModel = bcDal.GetModel(model.B_Case_code.Value);
            if (type == 1)
            {
                caseType = caseModel.B_Case_type.Value;
            }
            else
            {
                caseType = businessChanceModel.B_BusinessChance_type.Value;
            }
            CommonService.Model.C_Parameters parModel = parDal.GetModelByRelationId(caseType, model.B_EqAllot_relationid.Value);
            model.B_Case_type = parModel.C_Parameters_id;
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

