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
    /// 2.	日程----用户中间表
    /// cyj
    /// 2015年7月14日15:33:25
    /// </summary>
    public partial class O_Schedule_user : IO_Schedule_user
    {
        private readonly CommonService.BLL.OA.O_Schedule_user bll = new BLL.OA.O_Schedule_user();
        public O_Schedule_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {
            return bll.Exists(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Schedule_user model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Schedule_user model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            return bll.Delete(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 根据日程Guid删除关联数据数据
        /// </summary>        
        public bool DeleteByScheduleCode(Guid O_Schedule_code)
        {
            return bll.DeleteByScheduleCode(O_Schedule_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Schedule_user GetModel(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {

            return bll.GetModel(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.OA.O_Schedule_user GetModelByCache(Guid O_Schedule_code, Guid C_userinfo_code, Guid O_Schedule_creator, DateTime O_Schedule_createTime, bool O_Schedule_isDelete)
        {
            return bll.GetModelByCache(O_Schedule_code, C_userinfo_code, O_Schedule_creator, O_Schedule_createTime, O_Schedule_isDelete);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule_user> GetModelList(string strWhere)
        {

            return bll.GetModelList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule_user> DataTableToList(DataTable dt)
        {
            return bll.DataTableToList(dt);
        }
        /// <summary>
        /// 获得参与者数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule_user> GetUserList(Guid O_Schedule_code)
        {
            return bll.GetUserList(O_Schedule_code);
        }

        /// <summary>
        /// 通过日程Guid，获取日程用户集合
        /// </summary>
        /// <param name="scheduleCode">日程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Schedule_user> GetScheduleUsersByScheduleCode(Guid scheduleCode)
        {
            return bll.GetScheduleUsersByScheduleCode(scheduleCode);
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
