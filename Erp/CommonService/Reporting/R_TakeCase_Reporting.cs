using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
  public class R_TakeCase_Reporting:IR_TakeCase_Reporting
    {
      private readonly BLL.Reporting.R_TakeCase_Reporting dal = new BLL.Reporting.R_TakeCase_Reporting();
       /// <summary>
        /// 获得数据列表
        /// </summary>
      public R_TakeCase_Reporting()
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
        public int Add(Model.Reporting.R_TakeCase_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_TakeCase_Reporting model)
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
        public Model.Reporting.R_TakeCase_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        public int Statistics() { 
       return  dal.Statistics();
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_TakeCase_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_TakeCase_Reporting> DataTableToList(DataTable dt)
        {
            return dal.DataTableToList(dt);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetListCount(string strwhere)
        {
            return dal.GetRecordCount(strwhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.Reporting.R_TakeCase_Reporting> GetList(int Top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetList(Top, strWhere, filedOrder).Tables[0]);
            
           
        }
        public List<CommonService.Model.Reporting.R_TakeCase_Reporting> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
            
           
        }
   

        #endregion  BasicMethod

    }
}
