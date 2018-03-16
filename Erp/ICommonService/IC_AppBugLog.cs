using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    [ServiceContract]
    public interface IC_AppBugLog
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [WebInvoke(UriTemplate = "AddAppBugLog",Method="POST",RequestFormat=WebMessageFormat.Json,ResponseFormat=WebMessageFormat.Json,BodyStyle=WebMessageBodyStyle.Bare)]
        int AddAppBugLog(CommonService.Model.C_AppBugLog model);
    }
}
