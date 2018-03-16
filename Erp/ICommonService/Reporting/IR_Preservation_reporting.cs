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
    public interface IR_Preservation_reporting
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.Reporting.R_Preservation_reporting model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.Reporting.R_Preservation_reporting> GetListByPage(CommonService.Model.Reporting.R_Preservation_reporting model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 生成报表
        /// </summary>
        [OperationContract]
        void Statistics();

        /// <summary>
        /// 获取总数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        int GetDataListCount(CommonService.Model.Reporting.R_Preservation_reporting model, int type);

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.V_Preservation_reporting> GetDataList(CommonService.Model.Reporting.R_Preservation_reporting model, int type, string orderby, int startIndex, int endIndex);
    }
}
