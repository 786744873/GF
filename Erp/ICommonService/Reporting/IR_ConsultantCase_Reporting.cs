using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ICommonService.Reporting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IR_ConsultantCase_Reporting”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_ConsultantCase_Reporting
    {
        [OperationContract]
        bool Exists(int ID);
        [OperationContract]
        int Add(CommonService.Model.Reporting.R_ConsultantCase_Reporting model);
        [OperationContract]
        bool Update(CommonService.Model.Reporting.R_ConsultantCase_Reporting model);
        [OperationContract]
        bool Delete(int ID);
        [OperationContract]
        bool DeleteList(string IDlist);
        [OperationContract]
        CommonService.Model.Reporting.R_ConsultantCase_Reporting GetModel(int ID);
        [OperationContract]
        CommonService.Model.Reporting.R_ConsultantCase_Reporting GetModelByCache(int ID);
        [OperationContract]
        List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> GetList(string strWhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> GetListfirst(int Top, string strWhere, string filedOrder);
        [OperationContract]
        List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> GetModelList(string strWhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> DataTableToList(DataTable dt);
        [OperationContract]
        List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> GetAllList();
        [OperationContract]
        int GetRecordCount(string strWhere);
        [OperationContract]
        List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        [OperationContract]
        void Statistics();
    }
}
