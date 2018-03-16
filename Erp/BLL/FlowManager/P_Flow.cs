using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
namespace CommonService.BLL.FlowManager
{
    /// <summary>
    /// 流程表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	public partial class P_Flow
	{
        private readonly CommonService.DAL.FlowManager.P_Flow dal = new CommonService.DAL.FlowManager.P_Flow();
        private readonly CommonService.DAL.FlowManager.P_Flow_post fpDal = new DAL.FlowManager.P_Flow_post();
        private readonly CommonService.DAL.CustomerForm.F_FormDateDeclare fddDal = new DAL.CustomerForm.F_FormDateDeclare();
		public P_Flow()
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
        public bool Exists(int P_Flow_id)
        {
            return dal.Exists(P_Flow_id);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="parentCode">父亲流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow> GetListByParentCode(Guid parentCode)
        {
            return DataTableToList(dal.GetListByParentCode(parentCode).Tables[0]);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow model)
		{
            if (model.P_Flow_parent == null)
            {//根流程添加
                model.P_Flow_level = 1;
                CommonService.Model.FlowManager.P_Flow maxOrderModel = dal.GetMaxOrderModelByLevel(model.P_Flow_level.Value);
                model.P_Flow_order = maxOrderModel == null ? 1 : maxOrderModel.P_Flow_order.Value + 1;
            }
            else
            {//子流程添加
                CommonService.Model.FlowManager.P_Flow parentModel = dal.GetModel(model.P_Flow_parent.Value);
                model.P_Flow_level = parentModel.P_Flow_level + 1;
                CommonService.Model.FlowManager.P_Flow maxOrderModel = dal.GetMaxOrderModelByParent(model.P_Flow_parent.Value);
                model.P_Flow_order = maxOrderModel == null ? 1 : maxOrderModel.P_Flow_order.Value + 1;
            }

            #region 表单时间声明添加

            for (int i = 0; i < 4; i++)
            {
                CommonService.Model.CustomerForm.F_FormDateDeclare formDataDeclare = new Model.CustomerForm.F_FormDateDeclare();
                formDataDeclare.F_FormDateDeclare_code = Guid.NewGuid();
                formDataDeclare.F_FormDateDeclare_formCode = model.P_Flow_code;
                switch(i)
                {
                    case 0: formDataDeclare.F_FormDateDeclare_column = "planStartTime";
                            formDataDeclare.F_FormDateDeclare_name = "计划开始时间";
                            break;
                    case 1: formDataDeclare.F_FormDateDeclare_column = "planEndTime";
                            formDataDeclare.F_FormDateDeclare_name = "计划结束时间";
                            break;
                    case 2: formDataDeclare.F_FormDateDeclare_column = "factStartTime";
                            formDataDeclare.F_FormDateDeclare_name = "实际开始时间";
                            break;
                    case 3: formDataDeclare.F_FormDateDeclare_column = "factEndTime";
                            formDataDeclare.F_FormDateDeclare_name = "实际结束时间";
                            break;
                }
                formDataDeclare.F_FormDateDeclare_type = Convert.ToInt32(TimeBelongTypeEnum.流程);

                fddDal.Add(formDataDeclare);
            }

            #endregion

            foreach (var post in model.C_Posts)
            {
                if(post.C_Post_ischeckted==true)
                {
                    CommonService.Model.FlowManager.P_Flow_post flow_post = new Model.FlowManager.P_Flow_post();
                    flow_post.P_Flow_code = model.P_Flow_code;
                    flow_post.F_Post_code = post.C_Post_code;
                    flow_post.P_Flow_post_creator = Guid.NewGuid();
                    flow_post.P_Flow_post_createTime = DateTime.Now;
                    flow_post.P_Flow_post_isDelete = 0;
                    fpDal.Add(flow_post);
                }
            }

            //如果该流程为交单，则其他流程该为不是交单
            if(model.P_Flow_type==Convert.ToInt32(FlowTypeEnum.商机) && model.P_Flow_IsCrossForm)
            {
                List<CommonService.Model.FlowManager.P_Flow> flows = GetListByFlowType(model.P_Flow_type.Value);
                foreach(CommonService.Model.FlowManager.P_Flow flow in flows)
                {
                    if(flow.P_Flow_code!=model.P_Flow_code)
                    {
                        flow.P_Flow_IsCrossForm = false;
                        dal.Update(flow);
                    }
                }
            }

			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Flow model)
		{
            fpDal.DeleteByFlowcode(model.P_Flow_code.Value);
            foreach (var post in model.C_Posts)
            {
                if (post.C_Post_ischeckted == true)
                {
                    CommonService.Model.FlowManager.P_Flow_post flow_post = new Model.FlowManager.P_Flow_post();
                    flow_post.P_Flow_code = model.P_Flow_code;
                    flow_post.F_Post_code = post.C_Post_code;
                    flow_post.P_Flow_post_creator = Guid.NewGuid();
                    flow_post.P_Flow_post_createTime = DateTime.Now;
                    flow_post.P_Flow_post_isDelete = 0;
                    fpDal.Add(flow_post);
                }
            }

            //如果该流程为交单，则其他流程该为不是交单
            if (model.P_Flow_type==Convert.ToInt32(FlowTypeEnum.商机) && model.P_Flow_IsCrossForm)
            {
                List<CommonService.Model.FlowManager.P_Flow> flows = GetListByFlowType(model.P_Flow_type.Value);
                foreach (CommonService.Model.FlowManager.P_Flow flow in flows)
                {
                    if (flow.P_Flow_code != model.P_Flow_code)
                    {
                        flow.P_Flow_IsCrossForm = false;
                        dal.Update(flow);
                    }
                }
            }

			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid P_Flow_code)
		{
            bool isSuccess = dal.Delete(P_Flow_code);
            fpDal.DeleteByFlowcode(P_Flow_code);
            #region 删除关联子集业务流程
            if (isSuccess)
            {
                List<CommonService.Model.FlowManager.P_Flow> Flows = GetListByParentCode(P_Flow_code);
                foreach (CommonService.Model.FlowManager.P_Flow childrenFlow in Flows)
                {
                    dal.Delete(childrenFlow.P_Flow_code.Value);
                    fpDal.DeleteByFlowcode(childrenFlow.P_Flow_code.Value);
                    RecursionDelete(childrenFlow.P_Flow_code.Value);
                }
            }
            #endregion

            return isSuccess;
		}

        /// <summary>
        /// 递归删除
        /// </summary>
        /// <param name="parentBusinessCode">父亲业务流程Guid</param>
        /// <returns></returns>
        private void RecursionDelete(Guid parentCode)
        {
            List<CommonService.Model.FlowManager.P_Flow> Flows = GetListByParentCode(parentCode);
            foreach (CommonService.Model.FlowManager.P_Flow childrenFlow in Flows)
            {
                dal.Delete(childrenFlow.P_Flow_code.Value);
                fpDal.DeleteByFlowcode(childrenFlow.P_Flow_code.Value);
                RecursionDelete(childrenFlow.P_Flow_code.Value);
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string P_Flow_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(P_Flow_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow GetModel(Guid P_Flow_code)
		{

            return dal.GetModel(P_Flow_code);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow GetModelByCache(int P_Flow_id)
		{
			
			string CacheKey = "P_FlowModel-" + P_Flow_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(P_Flow_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.FlowManager.P_Flow)objModel;
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
        /// 获取所有“是否监控”为“是”的数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow> GetAllListByIsMonitor()
        {
            return DataTableToList(dal.GetAllListByIsMonitor().Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.FlowManager.P_Flow> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.FlowManager.P_Flow> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.FlowManager.P_Flow> modelList = new List<CommonService.Model.FlowManager.P_Flow>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.FlowManager.P_Flow model;
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
		/// 获得全部数据列表
		/// </summary>
        public List<CommonService.Model.FlowManager.P_Flow> GetAllList()
		{
            DataSet ds = dal.GetAllList();
            return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="type">流程类型</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow> GetListByFlowType(int type)
        {
            DataSet ds = dal.GetListByFlowType(type);
            return DataTableToList(ds.Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(Model.FlowManager.P_Flow model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<Model.FlowManager.P_Flow> GetListByPage(Model.FlowManager.P_Flow model, string orderby, int startIndex, int endIndex)
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

