using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using CommonService.Common;
namespace CommonService.BLL.BusinessChanceManager
{
    /// <summary>
    /// 商机关联表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/07/27
    /// </summary>
	public partial class B_BusinessChance_link
	{
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance_link dal = new CommonService.DAL.BusinessChanceManager.B_BusinessChance_link();
        private readonly CommonService.DAL.C_Customer clientDal = new CommonService.DAL.C_Customer();
		public B_BusinessChance_link()
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
		public bool Exists(int B_BusinessChance_link_id)
		{
			return dal.Exists(B_BusinessChance_link_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_BusinessChance_links"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.BusinessChanceManager.B_BusinessChance_link> B_BusinessChance_links)
        {
            foreach (CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChanceLink in B_BusinessChance_links)
            {
                dal.Delete(businessChanceLink.B_BusinessChance_code.Value,businessChanceLink.B_BusinessChance_link_type.Value);
                if (businessChanceLink.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.客户))
                {
                    dal.Delete(businessChanceLink.B_BusinessChance_code.Value, Convert.ToInt32(BusinessChancelinkEnum.销售顾问));
                }
            }
            foreach (CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChanceLink in B_BusinessChance_links)
            {
                dal.Add(businessChanceLink);
                if (businessChanceLink.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.客户))
                {
                    CommonService.Model.C_Customer client = clientDal.GetModel(businessChanceLink.C_FK_code.Value);
                    CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChance_link = new Model.BusinessChanceManager.B_BusinessChance_link();
                    businessChance_link.B_BusinessChance_code = businessChanceLink.B_BusinessChance_code;
                    businessChance_link.C_FK_code = client.C_Customer_consultant;
                    businessChance_link.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.销售顾问);
                    businessChance_link.B_BusinessChance_link_creator = businessChanceLink.B_BusinessChance_link_creator;
                    businessChance_link.B_BusinessChance_link_createTime = businessChanceLink.B_BusinessChance_link_createTime;
                    businessChance_link.B_BusinessChance_link_isDelete = 0;

                    dal.Add(businessChance_link);
                }
            }
            return true;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int B_BusinessChance_link_id)
		{

            return true;
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string B_BusinessChance_link_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_BusinessChance_link_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_link GetModel(int B_BusinessChance_link_id)
		{
			
			return dal.GetModel(B_BusinessChance_link_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_link GetModelByCache(int B_BusinessChance_link_id)
		{
			
			string CacheKey = "B_BusinessChance_linkModel-" + B_BusinessChance_link_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(B_BusinessChance_link_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.BusinessChanceManager.B_BusinessChance_link)objModel;
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
        /// 根据商机Guid，类型值，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="linkType">类型值</param>
        /// <returns></returns>     
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetBusinessChanceLinks(Guid businessChanceCode, int linkType)
        {
            DataSet ds = dal.GetBusinessChanceLinks(businessChanceCode, linkType);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据商机Guid，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param> 
        /// <returns></returns>     
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetBusinessChanceAllLinks(Guid businessChanceCode)
        {
            DataSet ds = dal.GetBusinessChanceAllLinks(businessChanceCode);
            return DataTableToList(ds.Tables[0]);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> modelList = new List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.BusinessChanceManager.B_BusinessChance_link model;
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
		public int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model, string orderby, int startIndex, int endIndex)
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

