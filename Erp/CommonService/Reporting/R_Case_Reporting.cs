using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService;
using ICommonService.Reporting;
using System.Data;

namespace CommonService.Reporting
{
    public class R_Case_Reporting : IR_Case_Reporting
    {
        private readonly BLL.Reporting.R_Case_Reporting dal = new BLL.Reporting.R_Case_Reporting();
        public R_Case_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_Case_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_Case_Reporting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }

        public bool DeleteAll()
        {
            return dal.DeleteAll();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_Case_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }




        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.V_Case_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.V_Case_Reporting> DataTableToList(DataTable dt)
        {
            return dal.DataTableToList(dt);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.Reporting.V_Case_Reporting model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.Reporting.V_Case_Reporting> GetListByPage(CommonService.Model.Reporting.V_Case_Reporting model, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod



        public void Statistics()
        {
             dal.Statistics();
        }
    }
}

