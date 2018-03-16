using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 法院律师关联表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/08/22
    /// </summary>
	public partial class C_Court_Lawyer
	{
        private readonly CommonService.DAL.C_Court_Lawyer dal = new CommonService.DAL.C_Court_Lawyer();
        private readonly CommonService.DAL.C_Court courtDal = new CommonService.DAL.C_Court();
		public C_Court_Lawyer()
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
        //public bool Exists(int C_Court_Lawyer_id)
        //{
        //    return dal.Exists(C_Court_Lawyer_id);
        //}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Court_Lawyer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Court_Lawyer model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid lawyerCode, Guid courtCodes)
		{
			
			return dal.Delete(lawyerCode, courtCodes);
		}
         /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="C_Court_Lawyers"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.C_Court_Lawyer> C_Court_Lawyers)
        {
            bool isSuccess=false;
            foreach(CommonService.Model.C_Court_Lawyer C_Court_Lawyer in C_Court_Lawyers)
            {
                if (!dal.Exists(C_Court_Lawyer.C_Lawyer.Value, C_Court_Lawyer.C_Court.Value))
                {
                    if (dal.Add(C_Court_Lawyer) > 0)
                    {
                        CommonService.Model.C_Court court = courtDal.GetModel(C_Court_Lawyer.C_Court.Value);
                        court.C_Court_isAllocate = true;
                        courtDal.Update(court);//将该法院是否分配改为已分配
                        isSuccess = true;
                    }
                }
            }
            return isSuccess;
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Court_Lawyer_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Court_Lawyer_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.C_Court_Lawyer GetModel(int C_Court_Lawyer_id)
		{
			
			return dal.GetModel(C_Court_Lawyer_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Court_Lawyer GetModelByCache(int C_Court_Lawyer_id)
		{
			
			string CacheKey = "C_Court_LawyerModel-" + C_Court_Lawyer_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Court_Lawyer_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Court_Lawyer)objModel;
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
        /// 根据法院获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Court_Lawyer> GetListByCourt(Guid C_Court)
        {
            return DataTableToList(dal.GetListByCourt(C_Court).Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Court_Lawyer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Court_Lawyer> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Court_Lawyer> modelList = new List<CommonService.Model.C_Court_Lawyer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Court_Lawyer model;
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
        public List<CommonService.Model.Customer.V_Lawyer> DataTableToListLawyer(DataTable dt)
        {
            List<CommonService.Model.Customer.V_Lawyer> modelList = new List<CommonService.Model.Customer.V_Lawyer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.Customer.V_Lawyer model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToLawyerModel(dt.Rows[n]);
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
		public int GetRecordCount(CommonService.Model.Customer.V_Lawyer model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.Customer.V_Lawyer> GetListByPage(CommonService.Model.Customer.V_Lawyer model, string orderby, int startIndex, int endIndex)
		{
            return DataTableToListLawyer(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
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

