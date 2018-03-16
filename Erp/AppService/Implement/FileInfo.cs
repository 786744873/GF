using AppService.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace AppService.Implement
{
    /// <summary>
    /// 文件管理接口实现类
    /// </summary>
    public class FileInfo : IFileInfo
    {
        CommonService.BLL.C_Files fileBLL = new CommonService.BLL.C_Files();

        /// <summary>
        /// 根据业务流程表单GUID获取文件列表
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单GUID</param>
        /// <returns>文件列表</returns>
        public List<CommonService.Model.C_Files> AppGetFilesByBusinessFlowFormCode(string businessFlowFormCode)
        {
            return fileBLL.GetFilesByBelongTypeAndRelationCode(602, new Guid(businessFlowFormCode)); //602是自定义表单类型的附件
        }

        /// <summary>
        /// 获取表单附件数量
        /// </summary>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        public int AppGetFilesByBusinessFlowFormCodeCount(string businessFlowFormCode)
        {
            return fileBLL.GetFilesByBelongTypeAndRelationCode(602, new Guid(businessFlowFormCode)).Count; //602是自定义表单类型的附件
        }

        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="model">附件实体</param>
        /// <returns>是否成功</returns>
        public bool AppAddFileInfo(CommonService.Model.C_Files model)
        {
            return fileBLL.Add(model);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="guid">附件GUID</param>
        /// <returns>是否成功</returns>
        public bool AppDeleteFileInfo(string guid)
        {
            return fileBLL.Delete(new Guid(guid));
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="stream">文件流</param>
        /// <returns>是否成功</returns>
        public bool UploadFile(string fileName, string savePath, System.IO.Stream stream)
        {
            string path = ConfigurationManager.AppSettings["AttachmentStoreMainPath"]; //服务器的绝对路径
            savePath = path +savePath;

            if (!Directory.Exists(savePath))//地图存放的默认文件夹是否存在
            {
                Directory.CreateDirectory(savePath);//不存在则创建
            }

            string fileFullPath = Path.Combine(savePath, fileName); //合并路径

            if (stream == null)
            {
                return false;
            }

            if (!stream.CanRead)
            {
                return false;
            }

            using (FileStream fs = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                try
                {
                    const int bufferLength = 4096;
                    byte[] myBuffer = new byte[bufferLength];//数据缓冲区
                    int count;
                    while ((count = stream.Read(myBuffer, 0, bufferLength)) > 0)
                    {
                        fs.Write(myBuffer, 0, count);
                    }
                    fs.Close();
                    stream.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}