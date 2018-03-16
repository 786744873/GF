using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 首席专家--部长关联表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/09/14
    /// </summary>
    public partial class C_ChiefExpert_Minister
    {
        private readonly CommonService.DAL.SysManager.C_ChiefExpert_Minister dal = new CommonService.DAL.SysManager.C_ChiefExpert_Minister();
        public C_ChiefExpert_Minister()
        { }
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
        public bool Exists(int C_ChiefExpert_Minister_id)
        {
            return dal.Exists(C_ChiefExpert_Minister_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_ChiefExpert_Minister model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_ChiefExpert_Minister model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="C_ChiefExpert_Minister_id">ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(Guid ChiefExpert_Code, Guid Minister_Code)
        {
            return dal.Delete(ChiefExpert_Code, Minister_Code);
        }

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.SysManager.C_ChiefExpert_Minister> C_ChiefExpert_Ministers)
        {
            foreach (CommonService.Model.SysManager.C_ChiefExpert_Minister ChiefExpert_Minister in C_ChiefExpert_Ministers)
            {
                bool flag = dal.Exists(ChiefExpert_Minister.C_ChiefExpert_Code.Value, ChiefExpert_Minister.C_Minister_Code.Value);
                if (!flag)
                {
                    dal.Add(ChiefExpert_Minister);
                }
            }
            return true;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_ChiefExpert_Minister_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_ChiefExpert_Minister_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_ChiefExpert_Minister GetModel(int C_ChiefExpert_Minister_id)
        {

            return dal.GetModel(C_ChiefExpert_Minister_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_ChiefExpert_Minister GetModelByCache(int C_ChiefExpert_Minister_id)
        {

            string CacheKey = "C_ChiefExpert_MinisterModel-" + C_ChiefExpert_Minister_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_ChiefExpert_Minister_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_ChiefExpert_Minister)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_ChiefExpert_Minister> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_ChiefExpert_Minister> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_ChiefExpert_Minister> modelList = new List<CommonService.Model.SysManager.C_ChiefExpert_Minister>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_ChiefExpert_Minister model;
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
        /// 根据首席专家获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_ChiefExpert_Minister> GetListByChiefExpertCode(Guid C_ChiefExpert_Code)
        {
            return DataTableToList(dal.GetListByChiefExpertCode(C_ChiefExpert_Code).Tables[0]);
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
        /// <summary>
        /// 根据部长guid得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_ChiefExpert_Minister GetModelByMinister(Guid C_Minister_Code)
        {
            return dal.GetModelByMinister(C_Minister_Code);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

