using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
    public class R_AreaCase_Reporting : IR_AreaCase_Reporting
    {
        private readonly BLL.Reporting.R_AreaCase_Reporting dal = new BLL.Reporting.R_AreaCase_Reporting();
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        public int Add(Model.Reporting.R_AreaCase_Reporting model)
        {
            return dal.Add(model);
        }

        public bool Update(Model.Reporting.R_AreaCase_Reporting model)
        {
            return dal.Update(model);
        }

        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        public Model.Reporting.R_AreaCase_Reporting GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public Model.Reporting.R_AreaCase_Reporting GetModelByCache(int ID)
        {
            return dal.GetModelByCache(ID);
        }

        public List<Model.Reporting.R_AreaCase_Reporting> GetList(string strWhere)
        {
            return GetModelList(strWhere);
        }

        public List<Model.Reporting.R_AreaCase_Reporting> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        public List<Model.Reporting.R_AreaCase_Reporting> DataTableToList(System.Data.DataTable dt)
        {
            return dal.DataTableToList(dt);
        }

        public List<Model.Reporting.R_AreaCase_Reporting> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
        }

        public int GetRecordCount(CommonService.Model.Reporting.R_AreaCase_Reporting model)
        {
            return dal.GetRecordCount(model);
        }

        public List<Model.Reporting.R_AreaCase_Reporting> GetListByPage(CommonService.Model.Reporting.R_AreaCase_Reporting model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        public void Statistics()
        {
            dal.Statistics();
        }
    }
}
