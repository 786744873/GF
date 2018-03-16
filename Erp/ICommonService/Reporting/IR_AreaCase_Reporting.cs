using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Reporting
{
    /// <summary>
    /// 接口层IR_AreaCase_Reporting
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_AreaCase_Reporting
    {
        [OperationContract]
        bool Exists(int ID);
        [OperationContract]
        int Add(CommonService.Model.Reporting.R_AreaCase_Reporting model);
        [OperationContract]
        bool Update(CommonService.Model.Reporting.R_AreaCase_Reporting model);
        [OperationContract]
        bool Delete(int ID);
        [OperationContract]
        CommonService.Model.Reporting.R_AreaCase_Reporting GetModel(int ID);
        [OperationContract]
        CommonService.Model.Reporting.R_AreaCase_Reporting GetModelByCache(int ID);
        [OperationContract]

        List<CommonService.Model.Reporting.R_AreaCase_Reporting> GetList(string strWhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_AreaCase_Reporting> GetModelList(string strWhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_AreaCase_Reporting> DataTableToList(DataTable dt);
        [OperationContract]
        List<CommonService.Model.Reporting.R_AreaCase_Reporting> GetAllList();
        [OperationContract]
        int GetRecordCount(CommonService.Model.Reporting.R_AreaCase_Reporting model);
        [OperationContract]

        List<CommonService.Model.Reporting.R_AreaCase_Reporting> GetListByPage(CommonService.Model.Reporting.R_AreaCase_Reporting model, string orderby, int startIndex, int endIndex);
        [OperationContract]
        void Statistics();

    }
}
