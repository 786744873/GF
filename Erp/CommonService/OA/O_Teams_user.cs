using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// O_Teams_user分组用户中间表
    /// cyj
    /// 2015年7月14日16:09:11
    /// </summary>
    public partial class O_Teams_user : IO_Teams_user
    {
        private readonly CommonService.BLL.OA.O_Teams_user bll = new BLL.OA.O_Teams_user();
        public O_Teams_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete)
        {
            return bll.Exists(O_Teams_user_id, O_Teams_code, C_Userinfo_code, O_Teams_user_isManager, O_Teams_user_inTime, O_Teams_user_creator, O_Teams_user_createTime, O_Teams_user_isDelete);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Teams_user model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Teams_user model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete)
        {

            return bll.Delete(O_Teams_user_id, O_Teams_code, C_Userinfo_code, O_Teams_user_isManager, O_Teams_user_inTime, O_Teams_user_creator, O_Teams_user_createTime, O_Teams_user_isDelete);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Teams_user GetModel(int O_Teams_user_id, Guid O_Teams_code, Guid C_Userinfo_code, bool O_Teams_user_isManager, DateTime O_Teams_user_inTime, Guid O_Teams_user_creator, DateTime O_Teams_user_createTime, bool O_Teams_user_isDelete)
        {

            return bll.GetModel(O_Teams_user_id, O_Teams_code, C_Userinfo_code, O_Teams_user_isManager, O_Teams_user_inTime, O_Teams_user_creator, O_Teams_user_createTime, O_Teams_user_isDelete);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return bll.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Teams_user> GetModelList(string strWhere)
        {
            DataSet ds = bll.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Teams_user> DataTableToList(DataTable dt)
        {
            return bll.DataTableToList(dt);
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
            return bll.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }

}
