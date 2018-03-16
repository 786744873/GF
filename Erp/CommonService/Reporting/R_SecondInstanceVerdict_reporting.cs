using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
    public class R_SecondInstanceVerdict_reporting : IR_SecondInstanceVerdict_reporting
    {
        private readonly BLL.Reporting.R_SecondInstanceVerdict_reporting dal = new BLL.Reporting.R_SecondInstanceVerdict_reporting();
        public int GetRecordCount(Model.Reporting.R_SecondInstanceVerdict_reporting model)
        {
            return dal.GetRecordCount(model);
        }

        public List<Model.Reporting.R_SecondInstanceVerdict_reporting> GetListByPage(Model.Reporting.R_SecondInstanceVerdict_reporting model, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(model, orderby, startIndex, endIndex);
        }

        public List<Model.Reporting.R_SecondInstanceVerdict_reporting> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        public void Statistics()
        {
            dal.Statistics();
        }

        public int GetDataListCount(Model.Reporting.R_SecondInstanceVerdict_reporting model, int type)
        {
            return dal.GetDataListCount(model, type);
        }

        public List<Model.Reporting.V_SecondInstanceVerdict_reporting> GetDataList(Model.Reporting.R_SecondInstanceVerdict_reporting model, int type, string orderby, int startIndex, int endIndex)
        {
            return dal.GetDataList(model, type, orderby, startIndex, endIndex);
        }
    }
}
