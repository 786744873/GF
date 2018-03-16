using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace AppService.Interface
{
    /// <summary>
    /// 文件管理接口
    /// </summary>
    [ServiceContract]
    public interface IFileInfo
    {
        /// <summary>
        /// 根据业务流程表单GUID获取文件列表
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单GUID</param>
        /// <returns>文件列表</returns>
        [WebInvoke(UriTemplate = "AppGetFilesByBusinessFlowFormCode/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Files> AppGetFilesByBusinessFlowFormCode(string businessFlowFormCode);

        /// <summary>
        /// 获取表单附件数量
        /// </summary>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AppGetFilesByBusinessFlowFormCodeCount/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppGetFilesByBusinessFlowFormCodeCount(string businessFlowFormCode);


        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="model">附件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AppAddFileInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool AppAddFileInfo(CommonService.Model.C_Files model);

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="guid">附件GUID</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AppDeleteFileInfo/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool AppDeleteFileInfo(string guid);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="stream">文件流</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "UploadFile/{fileName}/{savePath}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UploadFile(string fileName, string savePath, Stream stream);
    }
}