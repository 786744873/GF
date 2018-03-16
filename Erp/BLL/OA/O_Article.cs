using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// O_Article文章表
    /// cyj
    /// 2015年7月14日16:44:04
    /// </summary>
    public partial class O_Article
    {
        private readonly CommonService.DAL.OA.O_Article dal = new DAL.OA.O_Article();
        public O_Article()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Article_id)
        {
            return dal.Exists(O_Article_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Article model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Article model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid articleCode)
        {

            return dal.Delete(articleCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Article_idlist)
        {
            return dal.DeleteList(O_Article_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article GetModel(Guid O_Article_code)
        {

            return dal.GetModel(O_Article_code);
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
        public List<CommonService.Model.OA.O_Article> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Article> modelList = new List<CommonService.Model.OA.O_Article>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Article model;
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
        public int GetRecordCount(CommonService.Model.OA.O_Article model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> GetListByPage(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 我的文章分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> GetListByPage2(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage2(model, orderby, startIndex, endIndex).Tables[0]);

        }
        /// <summary>
        /// 获取个人文章记录总数
        /// </summary>
        public int GetRecordCount2(CommonService.Model.OA.O_Article model)
        {
            return dal.GetRecordCount2(model);
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

        #region App专用
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="startIndex">开始条数</param>
        /// <param name="endIndex">结尾条数</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="model">文章实体（查询条件）</param>
        /// <returns>返回值通知公告列表</returns>
        public List<Model.OA.O_Article> AppGetArticle(int startIndex, int endIndex, string orderBy, Model.OA.O_Article model)
        {
            return GetListByPage2(model, orderBy, startIndex, endIndex);
        }

         /// <summary>
        /// 根据用户GUID获取该用户未读的公告
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>未读数量</returns>
        public int GetUnReadCount(Guid? guid)
        {
            return dal.GetUnReadCount(guid);
        }
        #endregion
    }
}
