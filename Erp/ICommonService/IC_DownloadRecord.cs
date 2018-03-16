using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 下载列表契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_DownloadRecord
    {
        /// <summary>
        /// 获得最大值
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 根据ID检查是否存在该记录
        /// </summary>
        /// <param name="C_DownloadRecord_id"></param>
        /// <returns></returns>
        [OperationContract]
        bool Exists(int C_DownloadRecord_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int Add(CommonService.Model.C_DownloadRecord model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool Update(CommonService.Model.C_DownloadRecord model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid C_DownloadRecord_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_DownloadRecord Get(Guid C_DownloadRecord_code);

        /// <summary>
        /// 获得下载记录数目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_DownloadRecord model);
        /// <summary>
        /// 获得文件的数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_DownloadRecord> GetListByfileCode(Guid fileCode);

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_DownloadRecord> GetListByPage(CommonService.Model.C_DownloadRecord model, string orderby, int startIndex, int endIndex);
    }
}
