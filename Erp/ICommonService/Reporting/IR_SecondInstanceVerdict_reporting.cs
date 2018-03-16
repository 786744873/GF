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
    public interface IR_SecondInstanceVerdict_reporting
    {
        [OperationContract]
        int GetRecordCount(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model);
        [OperationContract]
        List<CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting> GetListByPage(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model, string orderby, int startIndex, int endIndex);


        [OperationContract]
        List<CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting> GetModelList(string strWhere);

        [OperationContract]
        void Statistics();

        /// <summary>
        /// 统计虚拟表数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        int GetDataListCount(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model, int type);

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
        List<CommonService.Model.Reporting.V_SecondInstanceVerdict_reporting> GetDataList(CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting model, int type, string orderby, int startIndex, int endIndex);
    }
}
