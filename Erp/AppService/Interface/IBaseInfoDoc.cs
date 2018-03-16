using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace AppService
{
    [ServiceContract]
    public interface IBaseInfoDoc
    {
        #region App专用

        /// <summary>
        /// 根据父级ID获取子集参数
        /// </summary>
        /// <param name="id">父级ID</param>
        /// <returns>参数列表</returns>
        [WebInvoke(UriTemplate = "GetParametersByParentID/{id}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Parameters> GetParametersByParentID(string id);

        /// <summary>
        /// 获取所有特殊区域集合
        /// </summary>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetAllSpecialRegions", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Region> GetAllSpecialRegions();

        #endregion
    }
}