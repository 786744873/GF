using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using CommonService.Model;
using System.Collections;
using ICommonService.Milepost;
namespace CommonService.Milepost
{
    /// <summary>
    /// J_No_Milepost
    /// </summary>
    public class J_No_Milepost : IJ_No_Milepost
    {
        private readonly CommonService.BLL.Milepost.J_No_Milepost dal = new CommonService.BLL.Milepost.J_No_Milepost();
        public J_No_Milepost()
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
        public bool Exists(int J_No_Milepost_id)
        {
            return dal.Exists(J_No_Milepost_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.Milepost.J_No_Milepost model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.Milepost.J_No_Milepost model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int J_No_Milepost_id)
        {

            return dal.Delete(J_No_Milepost_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string J_No_Milepost_idlist)
        {
            return dal.DeleteList(J_No_Milepost_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Milepost.J_No_Milepost GetModel(int J_No_Milepost_id)
        {

            return dal.GetModel(J_No_Milepost_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>


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
        public DataSet GetAllList()
        {
            return GetList("");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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


        public Model.Milepost.J_No_Milepost DataRowToModel(DataRow row)
        {
            throw new NotImplementedException();
        }


        public int GetRecordCount(Model.Milepost.J_No_Milepost model, bool IsPreSetManager,Guid? userCode,List<Guid?> depts)
        {
            return dal.GetRecordCount(model, IsPreSetManager, userCode, depts);
        }

        public List<Model.Milepost.J_No_Milepost> GetListByPage(Model.Milepost.J_No_Milepost model, string orderby, int startIndex, int endIndex, bool IsPreSetManager,Guid? userCode, List<Guid?> depts)
        {
            return dal.GetListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, userCode, depts);
        }
    }
}

