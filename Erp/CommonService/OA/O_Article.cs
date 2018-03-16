using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// O_Article文章表
    /// cyj
    /// 2015年7月14日16:44:22
    /// </summary>
    public partial class O_Article : IO_Article
    {
        private readonly CommonService.BLL.OA.O_Article bll = new BLL.OA.O_Article();
        public O_Article()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Article_id)
        {
            return bll.Exists(O_Article_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Article model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Article model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid articleCode)
        {

            return bll.Delete(articleCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Article_idlist)
        {
            return bll.DeleteList(O_Article_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article GetModel(Guid O_Article_code)
        {

            return bll.GetModel(O_Article_code);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> GetModelList(string strWhere)
        {
            DataSet ds = bll.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> DataTableToList(DataTable dt)
        {
            return bll.DataTableToList(dt);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_Article model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> GetListByPage(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 我的文章分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article> GetListByPage2(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage2(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 获取个人文章记录总数
        /// </summary>
        public int GetRecordCount2(CommonService.Model.OA.O_Article model)
        {
            return bll.GetRecordCount2(model);
        }
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
            return bll.AppGetArticle(startIndex, endIndex, orderBy, model);
        }
        #endregion


      

    }

}
