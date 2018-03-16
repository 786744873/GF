using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CommonService.Reporting
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“R_CustomerCase_Reporting”。
    public class R_CustomerCase_Reporting : IR_CustomerCase_Reporting
    {
        private readonly BLL.Reporting.R_CustomerCase_Reporting dal = new BLL.Reporting.R_CustomerCase_Reporting();
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_CustomerCase_Reporting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Reporting.R_CustomerCase_Reporting model)
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
        public Model.Reporting.R_CustomerCase_Reporting GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Reporting.R_CustomerCase_Reporting GetModelByCache(int ID)
        {


            return dal.GetModelByCache(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CustomerCase_Reporting> GetList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Model.Reporting.R_CustomerCase_Reporting> GetListfirst(int Top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetList(Top, strWhere, filedOrder).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CustomerCase_Reporting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CustomerCase_Reporting> DataTableToList(DataTable dt)
        {
            return dal.DataTableToList(dt);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_CustomerCase_Reporting> GetAllList()
        {
            return DataTableToList(dal.GetAllList().Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.Reporting.R_CustomerCase_Reporting> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}


        #region  ExtensionMethod
        /// <summary>
        /// 报表数据处理
        /// </summary>
        public void Statistics()
        {
            dal.Statistics();


        }



        #endregion  ExtensionMethod

    }
}
