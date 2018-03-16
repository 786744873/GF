using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// B_Case_plan_Evidence
    /// 办案方案和提交的证据中间表
    /// 作者：陈永俊
    /// 2015年6月16日
    /// </summary>
    public partial class B_Case_plan_Evidence
    {
        private readonly CommonService.DAL.CaseManager.B_Case_plan_Evidence dal = new CommonService.DAL.CaseManager.B_Case_plan_Evidence();
        public B_Case_plan_Evidence()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_plan_Evidence_id)
        {
            return dal.Exists(B_Case_plan_Evidence_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan_Evidence model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_plan_Evidence model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_plan_Evidence_id)
        {

            return dal.Delete(B_Case_plan_Evidence_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_plan_Evidence_idlist)
        {
            return dal.DeleteList(B_Case_plan_Evidence_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Evidence GetModel(int B_Case_plan_Evidence_id)
        {

            return dal.GetModel(B_Case_plan_Evidence_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Evidence GetModelByCache(int B_Case_plan_Evidence_id)
        {

            string CacheKey = "B_Case_plan_EvidenceModel-" + B_Case_plan_Evidence_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(B_Case_plan_Evidence_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.CaseManager.B_Case_plan_Evidence)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetModelList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_Case_plan_Evidence> modelList = new List<CommonService.Model.CaseManager.B_Case_plan_Evidence>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case_plan_Evidence model;
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
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.CaseManager.B_Case_plan_Evidence> B_Case_plan_Evidences)
        {
            //根据案件Guid删除关联所有数据
            foreach (CommonService.Model.CaseManager.B_Case_plan_Evidence caseEvidences in B_Case_plan_Evidences)
            {
                dal.Delete(new Guid(caseEvidences.B_Case_plan_code.ToString()));
            }
            foreach (CommonService.Model.CaseManager.B_Case_plan_Evidence caseEvidences in B_Case_plan_Evidences)
            {
                dal.Add(caseEvidences);
            }
            return true;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Evidence> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
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
