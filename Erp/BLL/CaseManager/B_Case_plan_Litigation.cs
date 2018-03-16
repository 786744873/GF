using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// B_Case_plan_Litigation
    /// </summary>
    public partial class B_Case_plan_Litigation
    {
        private readonly CommonService.DAL.CaseManager.B_Case_plan_Litigation dal = new CommonService.DAL.CaseManager.B_Case_plan_Litigation();
        public B_Case_plan_Litigation()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_plan_Litigation_id)
        {
            return dal.Exists(B_Case_plan_Litigation_id);
        }
        /// <summary>
        /// 根据参数ID 和案件GUID查找是否存在记录
        /// </summary>
        /// <param name="parameterid"></param>
        /// <param name="casecode"></param>
        /// <returns></returns>
        public bool ExitsByParameteridAndCasecode(int parameterid, Guid casecode)
        {
            return dal.ExitsByParameteridAndCasecode(parameterid, casecode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan_Litigation model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_plan_Litigation model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_plan_Litigation_id)
        {

            return dal.Delete(B_Case_plan_Litigation_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_plan_Litigation_idlist)
        {
            return dal.DeleteList(B_Case_plan_Litigation_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Litigation GetModel(int B_Case_plan_Litigation_id)
        {

            return dal.GetModel(B_Case_plan_Litigation_id);
        }
        /// <summary>
        /// 通过参数ID和案件GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Litigation GetModelByParameterAndCasecode(int parameterid, Guid casecode)
        {
            return dal.GetModelByParameterAndCasecode(parameterid, casecode);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan_Litigation GetModelByCache(int B_Case_plan_Litigation_id)
        {

            string CacheKey = "B_Case_plan_LitigationModel-" + B_Case_plan_Litigation_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(B_Case_plan_Litigation_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.CaseManager.B_Case_plan_Litigation)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据父级ParameterID和案件编码获取列表
        /// </summary>
        /// <param name="C_Parameters_id">父级ID</param>
        /// <param name="casecode">案件编码</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case_plan_Litigation> GetListByCasecodeAndParameterId(int C_Parameters_id, Guid casecode)
        {
            return DataTableToList(dal.GetListByCasecodeAndParameterId(C_Parameters_id, casecode).Tables[0]);
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
        public List<CommonService.Model.CaseManager.B_Case_plan_Litigation> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_plan_Litigation> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_Case_plan_Litigation> modelList = new List<CommonService.Model.CaseManager.B_Case_plan_Litigation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case_plan_Litigation model = new Model.CaseManager.B_Case_plan_Litigation();
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
