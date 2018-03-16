using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Reporting
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_LitigationDocuments
    {
        [OperationContract]
        int GetRecordCount(CommonService.Model.Reporting.R_LitigationDocuments model);
        [OperationContract]
        List<CommonService.Model.Reporting.R_LitigationDocuments> GetListByPage(CommonService.Model.Reporting.R_LitigationDocuments model, string orderby, int startIndex, int endIndex);


        [OperationContract]
        List<CommonService.Model.Reporting.R_LitigationDocuments> GetModelList(string strWhere);

        [OperationContract]
        void Statistics();

        /// <summary>
        /// 统计虚拟表数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        int GetDataListCount(CommonService.Model.Reporting.R_LitigationDocuments model, int type);

        /// <summary>
        /// 分页获取虚拟表的值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.V_LitigationDocuments> GetDataList(CommonService.Model.Reporting.R_LitigationDocuments model, int type, string orderby, int startIndex, int endIndex);
    }
}
