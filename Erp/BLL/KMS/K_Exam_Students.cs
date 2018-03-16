using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 考生考试表数据逻辑
    /// </summary>
    public partial class K_Exam_Students
    {
        private readonly CommonService.DAL.KMS.K_Exam_Students dal = new CommonService.DAL.KMS.K_Exam_Students();
        public K_Exam_Students()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Exam_Students_code)
        {
            return dal.Exists(K_Exam_Students_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.KMS.K_Exam_Students model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Exam_Students model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Exam_Students_code)
        {

            return dal.Delete(K_Exam_Students_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string K_Exam_Students_codelist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(K_Exam_Students_codelist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Exam_Students GetModel(Guid K_Exam_Students_code)
        {

            return dal.GetModel(K_Exam_Students_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_Exam_Students GetModelByCache(Guid K_Exam_Students_code)
        {

            string CacheKey = "K_Exam_StudentsModel-" + K_Exam_Students_code;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_Exam_Students_code);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_Exam_Students)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Students> GetList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Students> GetList(int Top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetList(Top, strWhere, filedOrder).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Students> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Students> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_Exam_Students> modelList = new List<CommonService.Model.KMS.K_Exam_Students>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_Exam_Students model;
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
        public List<CommonService.Model.KMS.K_Exam_Students> GetAllList()
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
        public List<CommonService.Model.KMS.K_Exam_Students> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
