using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
    public class R_LitigationDocuments : IR_LitigationDocuments
    {
        private readonly BLL.Reporting.R_LitigationDocuments dal = new BLL.Reporting.R_LitigationDocuments();
        public int GetRecordCount(Model.Reporting.R_LitigationDocuments model)
        {
            return dal.GetRecordCount(model);
        }

        public List<Model.Reporting.R_LitigationDocuments> GetListByPage(Model.Reporting.R_LitigationDocuments model, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(model, orderby, startIndex, endIndex);
        }

        public List<Model.Reporting.R_LitigationDocuments> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        public void Statistics()
        {
            dal.Statistics();
        }

        public int GetDataListCount(Model.Reporting.R_LitigationDocuments model, int type)
        {
            return dal.GetDataListCount(model, type);
        }

        public List<Model.Reporting.V_LitigationDocuments> GetDataList(Model.Reporting.R_LitigationDocuments model, int type, string orderby, int startIndex, int endIndex)
        {
            return dal.GetDataList(model,type,orderby,startIndex,endIndex);
        }
    }
}
