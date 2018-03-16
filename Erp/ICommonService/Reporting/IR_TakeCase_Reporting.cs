using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ICommonService.Reporting
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_TakeCase_Reporting
    {
        [OperationContract]
        bool Exists(int ID);
        [OperationContract]
        int Add(CommonService.Model.Reporting.R_TakeCase_Reporting model);
        [OperationContract]
        bool Update(CommonService.Model.Reporting.R_TakeCase_Reporting model);
        [OperationContract]
        bool Delete(int ID);
        [OperationContract]
        bool DeleteList(string IDlist);
        [OperationContract]
        CommonService.Model.Reporting.R_TakeCase_Reporting GetModel(int ID);
        [OperationContract]
        List<CommonService.Model.Reporting.R_TakeCase_Reporting> GetModelList(string strWhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_TakeCase_Reporting> DataTableToList(DataTable dt);
        [OperationContract]
        int GetListCount(string strwhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_TakeCase_Reporting> GetList(int Top, string strWhere, string filedOrder);
          [OperationContract]
        List<CommonService.Model.Reporting.R_TakeCase_Reporting> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
          [OperationContract]
          int Statistics();
    }
}
