using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// O_Schedule_user
    /// 日程用户中间表
    /// cyj
    /// 2015年7月14日17:10:42
    /// </summary>
    public partial class O_Schedule_user
    {
        private readonly CommonService.DAL.OA.O_Schedule_user dal = new DAL.OA.O_Schedule_user();
        public O_Schedule_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {
            return dal.Exists(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Schedule_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Schedule_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            return dal.Delete(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 根据日程Guid删除关联数据数据
        /// </summary>        
        public bool DeleteByScheduleCode(Guid O_Schedule_code)
        {
            return dal.DeleteByScheduleCode(O_Schedule_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Schedule_user GetModel(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            return dal.GetModel(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.OA.O_Schedule_user GetModelByCache(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            string CacheKey = "O_Schedule_userModel-" + O_Schedule_code + C_userinfo_code + O_Schedule_creator + O_Schedule_createTime + O_Schedule_isDelete;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.OA.O_Schedule_user)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 通过日程Guid，获取日程用户集合
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Schedule_user> GetScheduleUsersByScheduleCode(Guid scheduleCode)
        {
            DataSet ds = dal.GetScheduleUsersByScheduleCode(scheduleCode);
            return DataTableToList(ds.Tables[0]);
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
        public List<CommonService.Model.OA.O_Schedule_user> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule_user> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Schedule_user> modelList = new List<CommonService.Model.OA.O_Schedule_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Schedule_user model;
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
        /// 获得参与者数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule_user> GetUserList(Guid O_Schedule_code)
        {
            return DataTableToList(dal.GetUserList(O_Schedule_code).Tables[0]) ;
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
    }
}
