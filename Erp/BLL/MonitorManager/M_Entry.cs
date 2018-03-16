using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
namespace CommonService.BLL.MonitorManager
{
    /// <summary>
    /// 条目表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/08
    /// </summary>
	public partial class M_Entry
	{
        private readonly CommonService.DAL.MonitorManager.M_Entry dal = new CommonService.DAL.MonitorManager.M_Entry();
        /// <summary>
        /// 条目统计数据访问层
        /// </summary>
        private readonly CommonService.DAL.MonitorManager.M_Entry_Statistics statisticsDAL = new CommonService.DAL.MonitorManager.M_Entry_Statistics();
        private readonly CommonService.DAL.C_Court courtDAL = new CommonService.DAL.C_Court();
		public M_Entry()
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
        public bool Exists(int M_Entry_id)
        {
            return dal.Exists(M_Entry_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.MonitorManager.M_Entry model)
		{
            /**
             *author:hety
             *date:2015-06-26
             *description:
             *(1)、增加条目时，插入关联条目维度的统计信息
             **/
            bool isSucess = dal.Add(model);
            statisticsDAL.GenerateEntryStatisticsByEntryCode(model.M_Entry_code.Value, Convert.ToInt32(FlowTypeEnum.案件), model.M_Entry_creator.Value);

            return isSucess;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.MonitorManager.M_Entry model)
		{
            /**
             * author:hety
             * date:2015-06-26
             * description:
             * (1)、修改条目时，只要条目的维度发生了改变，会新增一条条目信息，并且按新条目执行关联条目维度的统计信息
             **/
            bool isSuccess = false;

            CommonService.Model.MonitorManager.M_Entry OriginalEntry = dal.GetModel(model.M_Entry_id);
            if (OriginalEntry.M_Entry_sFlow != model.M_Entry_sFlow || OriginalEntry.M_Entry_eFlow != model.M_Entry_eFlow ||
                OriginalEntry.M_Entry_sForm != model.M_Entry_sForm || OriginalEntry.M_Entry_eForm != model.M_Entry_eForm ||
                OriginalEntry.M_Entry_sTime != model.M_Entry_sTime || OriginalEntry.M_Entry_eTime != model.M_Entry_eTime ||
                OriginalEntry.M_Entry_court != model.M_Entry_court)
            {
                Guid? parentCode = model.M_Entry_code;
                CommonService.Model.MonitorManager.M_Entry newEntry = model;
                newEntry.M_Entry_code = Guid.NewGuid();
                newEntry.M_Entry_parent = parentCode;

                isSuccess = dal.Add(newEntry);

                statisticsDAL.GenerateEntryStatisticsByEntryCode(newEntry.M_Entry_code.Value, Convert.ToInt32(FlowTypeEnum.案件), model.M_Entry_creator.Value);
            }
            else
            {
                isSuccess = dal.Update(model);
            }

            return isSuccess;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int M_Entry_id)
		{
            return dal.Delete(M_Entry_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.MonitorManager.M_Entry GetModel(int M_Entry_id)
		{
            CommonService.Model.MonitorManager.M_Entry entry = dal.GetModel(M_Entry_id);
            if (entry.M_Entry_court != null)
            {
                string[] entryCourts = entry.M_Entry_court.Split(',');
                foreach(string entryCourt in entryCourts)
                {
                    CommonService.Model.C_Court court = courtDAL.GetModel(new Guid(entryCourt));
                    entry.M_Entry_courtName += court.C_Court_name + ",";
                }
                entry.M_Entry_courtName = entry.M_Entry_courtName != "" ? entry.M_Entry_courtName.Substring(0, entry.M_Entry_courtName.Length - 1) : "";
            }else
            {
                entry.M_Entry_courtName = "全部法院";
            }

            return entry;
		}

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CommonService.Model.MonitorManager.M_Entry GetModelByCode(Guid M_Entry_code)
        {
            return dal.GetModelByCode(M_Entry_code);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.MonitorManager.M_Entry GetModelByCache(int M_Entry_id)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "M_EntryModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(M_Entry_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.MonitorManager.M_Entry)objModel;
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
        public List<CommonService.Model.MonitorManager.M_Entry> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.MonitorManager.M_Entry> modelList = new List<CommonService.Model.MonitorManager.M_Entry>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.MonitorManager.M_Entry model;
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
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<Model.MonitorManager.M_Entry> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(CommonService.Model.MonitorManager.M_Entry model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry> GetListByPage(CommonService.Model.MonitorManager.M_Entry model, string orderby, int startIndex, int endIndex)
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

