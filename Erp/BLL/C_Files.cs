using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// 附件表业务逻辑
    /// 作者：陈永俊
    /// 日期：2015年6月8日16:09:15
    /// </summary>
    public partial class C_Files
    {
        private readonly CommonService.DAL.C_Files dal = new CommonService.DAL.C_Files();
        public C_Files()
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
        public bool Exists(int C_Files_id)
        {
            return dal.Exists(C_Files_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.C_Files model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModelByCode(Guid C_Files_code)
        {
            return dal.GetModelByCode(C_Files_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Files model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid fileCode)
        {

            return dal.Delete(fileCode);
        }
        /// <summary>
        /// 根据文件名得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModelByName(string fileName)
        {
            return dal.GetModelByName(fileName);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Files_idlist)
        {
            return dal.DeleteList(C_Files_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModel(int C_Files_id)
        {

            return dal.GetModel(C_Files_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Files GetModelByCache(int C_Files_id)
        {

            string CacheKey = "C_FilesModel-" + C_Files_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Files_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Files)objModel;
        }

        /// <summary>
        /// 根据文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Files> GetFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode)
        {
            DataSet ds = dal.GetFilesByBelongTypeAndRelationCode(belongType, relationCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据父级文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Files> GetChildenFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode)
        {
            DataSet ds = dal.GetChildenFilesByBelongTypeAndRelationCode(belongType, relationCode);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Files> GetListByFileLink(Guid relationCode)
        {
            return DataTableToList(dal.GetListByFileLink(relationCode).Tables[0]);
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
        public List<CommonService.Model.C_Files> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Files> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Files> modelList = new List<CommonService.Model.C_Files>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Files model;
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
        public List<Model.C_Files> GetListByPage(CommonService.Model.C_Files files, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(files, orderby, startIndex, endIndex).Tables[0]);
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
