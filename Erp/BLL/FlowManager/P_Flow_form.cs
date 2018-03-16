using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.FlowManager
{
    /// <summary>
    /// 流程----表单中间表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Flow_form
	{
        private readonly CommonService.DAL.FlowManager.P_Flow_form dal = new CommonService.DAL.FlowManager.P_Flow_form();
		public P_Flow_form()
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
        public bool Exists(int P_Flow_form_id)
        {
            return dal.Exists(P_Flow_form_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.FlowManager.P_Flow_form model)
		{
            bool flow=dal.Exists(model.P_Flow_code.Value,model.F_Form_code.Value);
            if(flow)
            {
                return 1;
            }else
            {
                return dal.Add(model);
            }
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Flow_form model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string P_Flow_form_ids)
		{
            string[] flowFormIds = P_Flow_form_ids.Split(',');
            foreach(var flowFormId in flowFormIds)
            {
                if(flowFormId!="")
                {
                    dal.Delete(Convert.ToInt32(flowFormId));
                }
            }
            return true;
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string P_Flow_form_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(P_Flow_form_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow_form GetModel(int P_Flow_form_id)
		{
			
			return dal.GetModel(P_Flow_form_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.FlowManager.P_Flow_form GetModelByCache(int P_Flow_form_id)
		{
			
			string CacheKey = "P_Flow_formModel-" + P_Flow_form_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(P_Flow_form_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.FlowManager.P_Flow_form)objModel;
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
        public List<CommonService.Model.FlowManager.P_Flow_form> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.FlowManager.P_Flow_form> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.FlowManager.P_Flow_form> modelList = new List<CommonService.Model.FlowManager.P_Flow_form>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.FlowManager.P_Flow_form model;
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
        /// 通过固定条件，获取所有表单
        /// </summary>
        /// <param name="flowCode"></param>
        /// <param name="isDefalut"></param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow_form> GetListByFlowCode(Guid flowCode,int isDefalut)
        {
            return DataTableToList(dal.GetListByFlowCode(flowCode, isDefalut).Tables[0]);
        }

        /// <summary>
        /// 通过流程Guid，获取流程关联表单
        /// </summary>
        /// <param name="flowCode">流程Guid</param>       
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Flow_form> GetListByFlowCode(Guid flowCode)
        {
            return DataTableToList(dal.GetListByFlowCode(flowCode).Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(CommonService.Model.FlowManager.P_Flow_form model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.FlowManager.P_Flow_form> GetListByPage(CommonService.Model.FlowManager.P_Flow_form model, string orderby, int startIndex, int endIndex)
		{
            List<CommonService.Model.FlowManager.P_Flow_form> flow_forms=DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
            return flow_forms;
		}
        /// <summary>
        /// 修改是否默认状态
        /// </summary>
        /// <param name="P_Flow_form_idlist">默认表单ID</param>
        /// <param name="P_Flow_code">流程Code</param>
        /// <returns></returns>
        public bool UpdateDefaultByid(string P_Flow_form_idlist, Guid P_Flow_code)
        {
            string[] flow_form_ids = P_Flow_form_idlist.Split(',');
            //根据流程Code得到所有关联表单
            List<CommonService.Model.FlowManager.P_Flow_form> ff = GetListByFlowCode(P_Flow_code);
            string defauleids = "";
            foreach (var item in ff)
            {
                if (item.P_Flow_form_isDefault == 1)
                {
                    defauleids += item.P_Flow_form_id.ToString() + ',';
                }
            }
            defauleids = defauleids != "" ? defauleids.Substring(0, defauleids.Length - 1) : defauleids;//得到所有默认表单的ID

            string[] flowform_ids = defauleids.Split(',');
            string Flowformids = "";
            bool isSuccess = true;
            foreach (var id in flow_form_ids)
            {
                Flowformids+=id+',';
                if(!defauleids.Contains(id))
                {
                    isSuccess = dal.UpdateDefaulttrueByid(int.Parse(id));
                }
            }
            Flowformids = Flowformids != null ? Flowformids.Substring(0, Flowformids.Length - 1) : Flowformids;
            foreach (var id in flowform_ids)
            {
                if (!Flowformids.Contains(id))
                {
                    isSuccess = dal.UpdateDefaultfalseByid(int.Parse(id));
                }
            }
            if(isSuccess)
            {
                return true;
            }else
            {
                return false;
            }
        }

         /// <summary>
        /// 批量操作
        /// </summary>
        public bool OpreateList(List<Model.FlowManager.P_Flow_form> modelList)
        {
            foreach(Model.FlowManager.P_Flow_form flowForm in modelList)
            {
                bool flow = dal.Exists(flowForm.P_Flow_code.Value, flowForm.F_Form_code.Value);
                if(flow==false)
                {
                    dal.Add(flowForm);
                }
            }
            return true;
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

