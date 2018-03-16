using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using System.Collections;
namespace CommonService.BLL
{
    /// <summary>
    /// 法院法官关联表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/08
    /// </summary>
	public partial class C_Court_Judge
	{
        private readonly CommonService.DAL.C_Court_Judge dal = new CommonService.DAL.C_Court_Judge();
		public C_Court_Judge()
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
        public bool Exists(int C_Court_Judge_id)
        {
            return dal.Exists(C_Court_Judge_id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Court_Judge model)
		{
            int i = 0;
            //根据职务获取数据列表
            List<CommonService.Model.C_Court_Judge> courtJudges = GetListByDuty(model);
            string judgeCodeStr = "";
            foreach (CommonService.Model.C_Court_Judge courtJudge in courtJudges)
            {
                judgeCodeStr += courtJudge.C_Judge_code + ",";
            }
            judgeCodeStr = judgeCodeStr == "" ? judgeCodeStr : judgeCodeStr.Substring(0,judgeCodeStr.Length-1);//该职务下关联所有法官的Code
            if(!judgeCodeStr.Contains(model.C_Judge_code.ToString()))
            {

            }
            dal.Delete(model);
			return dal.Add(model);
		}

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.C_Court_Judge> C_Court_Judges)
        {
            bool isSuccess = true;

            List<CommonService.Model.C_Court_Judge> courtJudges = GetListByDuty(C_Court_Judges[0]);
            string judgeCodeStr = "";
            foreach (CommonService.Model.C_Court_Judge courtJudge in courtJudges)
            {
                judgeCodeStr += courtJudge.C_Judge_code + ",";
            }
            judgeCodeStr = judgeCodeStr == "" ? judgeCodeStr : judgeCodeStr.Substring(0, judgeCodeStr.Length - 1);//该职务下关联所有法官的Code
            string[] judge_CodeStr=judgeCodeStr.Split(',');

            string judgeCodes = "";
            foreach (CommonService.Model.C_Court_Judge courtJudge in C_Court_Judges)
            {
                judgeCodes += courtJudge.C_Judge_code + ",";
            }
            judgeCodes = judgeCodes == "" ? judgeCodes : judgeCodes.Substring(0, judgeCodes.Length - 1);//页面选中的法官
            string[] judge_Codes = judgeCodes.Split(',');
            string judges = "";
            
            foreach (var court_judge in C_Court_Judges)
            {
                judges += court_judge.C_Judge_code.ToString() + ",";
                if (!judgeCodeStr.Contains(court_judge.C_Judge_code.ToString()))
                {
                    if(dal.Add(court_judge)>0)
                    {
                        isSuccess = true;
                    }
                }
            }
            judges = judges == "" ? judges : judges.Substring(0,judges.Length-1);

            foreach (var judgeCode in judge_CodeStr)
            {
                if (!judges.Contains(judgeCode))
                {
                    CommonService.Model.C_Court_Judge C_Court_Judge = C_Court_Judges[0];
                    C_Court_Judge.C_Judge_code = new Guid(judgeCode);
                    isSuccess = dal.Delete(C_Court_Judge);
                }
            }

            return isSuccess;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(CommonService.Model.C_Court_Judge model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_Court_Judge_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Court_Judge_idlist,0) );
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Court_Judge GetModel(int C_Court_Judge_id)
        {

            return dal.GetModel(C_Court_Judge_id);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public CommonService.Model.C_Court_Judge GetModelByCache(int C_Court_Judge_id)
		{
			
			string CacheKey = "C_Court_JudgeModel-" + C_Court_Judge_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_Court_Judge_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (CommonService.Model.C_Court_Judge)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 根据职务获得数据列表
        /// </summary>
        public List<Model.C_Court_Judge> GetListByDuty(Model.C_Court_Judge model)
        {
            return DataTableToList(dal.GetListByDuty(model).Tables[0]);
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
        public List<CommonService.Model.C_Court_Judge> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CommonService.Model.C_Court_Judge> DataTableToList(DataTable dt)
		{
            List<CommonService.Model.C_Court_Judge> modelList = new List<CommonService.Model.C_Court_Judge>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                CommonService.Model.C_Court_Judge model;
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
		public int GetRecordCount(Model.C_Court_Judge model)
		{
			return dal.GetRecordCount(model);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public List<Model.C_Court_Judge> GetListByPage(Model.C_Court_Judge model, string orderby, int startIndex, int endIndex)
		{
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
		}

        /// <summary>
        /// 根据法院Code获取，法院关联法官集合
        /// </summary>
        /// <param name="courtCode"></param>
        /// <returns></returns>
        public List<Model.C_Court_Judge> GetListByCourt(Guid courtCode)
        {
            return DataTableToList(dal.GetListByCourt(courtCode).Tables[0]);
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

