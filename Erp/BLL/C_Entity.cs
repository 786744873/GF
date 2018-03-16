using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// 实体表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/06/03
    /// </summary>
    public partial class C_Entity
    {
        private readonly CommonService.DAL.C_Entity dal = new CommonService.DAL.C_Entity();
        public C_Entity()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Entity_Id)
        {
            return dal.Exists(C_Entity_Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Entity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Entity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Entity_code)
        {
            return dal.Delete(C_Entity_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Entity_Idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Entity_Idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Entity GetModel(Guid C_Entity_code)
        {
            return dal.GetModel(C_Entity_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Entity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Entity> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Entity> modelList = new List<CommonService.Model.C_Entity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Entity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Entity model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Entity> GetListByPage(CommonService.Model.C_Entity model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
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
        /// <summary>
        /// 根据名称得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Entity GetModelByName(string tableName)
        {
            return dal.GetModelByName(tableName);
        }

        /// <summary>
        /// 获取自定义数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetCustomTable(string id, string name, string tableName, string searchName,string startIndex,string endIndex)
        {
            return dal.GetCustomTable(id, name, tableName, searchName,Convert.ToInt32(startIndex),Convert.ToInt32(endIndex));
        }

        #endregion  ExtensionMethod
    }
}
