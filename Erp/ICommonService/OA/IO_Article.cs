using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 接口层O_Article文章表
    /// cyj
    /// 2015年7月14日16:46:13
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Article
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]

        bool Exists(int O_Article_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]

        int Add(CommonService.Model.OA.O_Article model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]

        bool Update(CommonService.Model.OA.O_Article model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]

        bool Delete(Guid articleCode);
        [OperationContract]

        bool DeleteList(string O_Article_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]

        CommonService.Model.OA.O_Article GetModel(Guid O_Article_code);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]

        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]

        int GetRecordCount(CommonService.Model.OA.O_Article model);
        [OperationContract]

        List<CommonService.Model.OA.O_Article> GetListByPage(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere)
        /// <summary>
        /// 我的文章分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Article> GetListByPage2(CommonService.Model.OA.O_Article model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 获取个人文章记录总数
        /// </summary>
        [OperationContract]
        int GetRecordCount2(CommonService.Model.OA.O_Article model);

        #endregion  成员方法


        #region  App专用

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="startIndex">开始条数</param>
        /// <param name="endIndex">结尾条数</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="model">文章实体（查询条件）</param>
        /// <returns>返回值通知公告列表</returns>
        [WebInvoke(UriTemplate = "AppGetArticle", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.OA.O_Article> AppGetArticle( int startIndex, int endIndex, string orderBy, CommonService.Model.OA.O_Article model);
        
        #endregion
       

    }
}
