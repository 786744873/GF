using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    public partial class C_DownloadRecord
    {
        private readonly DAL.C_DownloadRecord dal = new DAL.C_DownloadRecord();
        /// <summary>
        /// 获得最大的ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_DownloadRecord_id"></param>
        /// <returns></returns>
        public bool Exists(int C_DownloadRecord_id)
        {
            return dal.Exists(C_DownloadRecord_id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.C_DownloadRecord model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.C_DownloadRecord model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        public bool Delete(Guid C_DownloadRecord_code)
        {
            return dal.Delete(C_DownloadRecord_code);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_DownloadRecord GetModel(Guid C_DownloadRecord_code)
        {
            return dal.GetModel(C_DownloadRecord_code);
        }
        /// <summary>
        /// 得到一个对象实体，从缓从中
        /// </summary>
        /// <param name="C_DownloadRecord_id"></param>
        /// <returns></returns>
        public CommonService.Model.C_DownloadRecord GetModelByCache(int C_DownloadRecord_id)
        {
            string CacheKey = "C_DownloadRecordModel-" + C_DownloadRecord_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_DownloadRecord_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }

            return (CommonService.Model.C_DownloadRecord)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得文件的数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_DownloadRecord> GetListByfileCode(Guid fileCode)
        {
            return DataTableToList(dal.GetListByfileCode(fileCode).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="fileOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int top, string strWhere, string fileOrder)
        {
            return dal.GetList(top, strWhere, fileOrder);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_DownloadRecord> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 将DataTable转化为List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_DownloadRecord> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_DownloadRecord> modelList = new List<Model.C_DownloadRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_DownloadRecord model;
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
        /// <returns></returns>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 获得下载记录数目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.C_DownloadRecord model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_DownloadRecord> GetListByPage(CommonService.Model.C_DownloadRecord model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
    }
}
