using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
    public class R_Register_reporting : IR_Register_reporting
    {
        private readonly BLL.Reporting.R_Register_reporting dal = new BLL.Reporting.R_Register_reporting();
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        public int Add(Model.Reporting.R_Register_reporting model)
        {
            return dal.Add(model);
        }

        public bool Update(Model.Reporting.R_Register_reporting model)
        {
            return dal.Update(model);
        }

        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }


        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        public Model.Reporting.R_Register_reporting GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public int GetRecordCount(Model.Reporting.V_Register_reporting model)
        {
            return dal.GetRecordCount(model);
        }

        public List<Model.Reporting.R_Register_reporting> GetListByPage(Model.Reporting.V_Register_reporting model, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(model,orderby,startIndex,endIndex);
        }

        public List<Model.Reporting.V_Register_reporting> GetModelList(string strWhere)
        {
            return null;
        }

        public void Statistics()
        {
            dal.Statistics();
        }



        public int GetDataListCount(Model.Reporting.V_Register_reporting model, int type)
        {
            return dal.GetDataListCount(model, type);
        }

        public List<Model.Reporting.V_Register_statistics> GetDataList(Model.Reporting.V_Register_reporting model, int type, string orderby, int startIndex, int endIndex)
        {
            return dal.GetDataList(model, type, orderby, startIndex, endIndex);
        }
    }
}
