using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// (企业)法律对手信息表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/04/24
    /// </summary>
    public partial class C_CRival
    {
        private readonly CommonService.DAL.C_CRival dal = new CommonService.DAL.C_CRival();
        private readonly CommonService.BLL.C_Rival_Region rrBll = new C_Rival_Region();
        private readonly CommonService.DAL.C_Region regDal = new DAL.C_Region();
        public C_CRival()
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
        public bool Exists(int C_CRival_id)
        {
            return dal.Exists(C_CRival_id);
        }

         /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(CommonService.Model.C_CRival model)
        {
            return dal.ExistsByName(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_CRival model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_CRival model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_CRival_code)
        {

            return dal.Delete(C_CRival_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_CRival_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_CRival_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_CRival GetModel(int C_CRival_id)
        {

            return dal.GetModel(C_CRival_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_CRival GetModel(Guid C_CRival_code)
        {
            CommonService.Model.C_CRival crival = dal.GetModel(C_CRival_code);
            List<CommonService.Model.C_Rival_Region> rivalRegions = rrBll.GetListByRivalCode(crival.C_CRival_code.Value);
            string regionCodeStr = "";
            string regionNameStr = "";
            foreach(CommonService.Model.C_Rival_Region rivalRegion in rivalRegions)
            {
                regionCodeStr += rivalRegion.C_Rival_Region_relRegion + ",";
                CommonService.Model.C_Region region = regDal.GetModelByCode(rivalRegion.C_Rival_Region_relRegion.Value);
                regionNameStr += region.C_Region_name + ",";
            }
            crival.C_CRival_region_code = regionCodeStr == "" ? regionCodeStr : regionCodeStr.Substring(0,regionCodeStr.Length-1);
            crival.C_CRival_region_name = regionNameStr == "" ? regionNameStr : regionNameStr.Substring(0,regionNameStr.Length-1);

            return crival;
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_CRival GetModelByCache(int C_CRival_id)
        {

            string CacheKey = "C_CRivalModel-" + C_CRival_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_CRival_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_CRival)objModel;
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
        public List<CommonService.Model.C_CRival> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_CRival> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_CRival> modelList = new List<CommonService.Model.C_CRival>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_CRival model;
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
        public DataSet GetAllList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.C_CRival model)
        {
            return dal.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_CRival> GetListByPage(Model.C_CRival model, string orderby, int startIndex, int endIndex)
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
