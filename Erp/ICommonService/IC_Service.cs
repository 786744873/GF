using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace ICommonService
{
    [ServiceContract]
    public interface IC_Service
    {/// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetMaxId", ResponseFormat = WebMessageFormat.Json)]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Exists?C_Address_id={C_Address_id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Exists(int C_Address_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int Add(CommonService.Model.C_Address model);

        /// <summary>
        /// 更新一条数据
        /// </summary>

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool Update(CommonService.Model.C_Address model);

        /// <summary>
        /// 删除一条数据
        /// </summary>

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Delete(Guid C_Address_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Address_code"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Get", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_Address Get(Guid C_Address_code);
        //
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetRecordCount", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int GetRecordCount(CommonService.Model.C_Address model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]

        List<CommonService.Model.C_Address> GetListByPage(CommonService.Model.C_Address model, string orderby, int startIndex, int endIndex);
    }
}