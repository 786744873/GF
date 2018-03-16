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
    /// O_Schedule日程表
    /// cyj
    /// 2015年7月14日17:11:27
    /// </summary>
    public partial class O_Schedule : IO_Schedule
    {
        private readonly CommonService.BLL.OA.O_Schedule bll = new CommonService.BLL.OA.O_Schedule();
        public O_Schedule()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Schedule_id)
        {
            return bll.Exists(O_Schedule_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Schedule model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Schedule model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 新增日程和日程用户
        /// </summary>
        /// <param name="schedule">日程实体</param>
        /// <param name="scheduleUsers">日程用户实体</param>
        /// <returns></returns>        
        public bool AddHeadAndItems(CommonService.Model.OA.O_Schedule schedule, List<CommonService.Model.OA.O_Schedule_user> scheduleUsers)
        {
            return bll.AddHeadAndItems(schedule, scheduleUsers);
        }

        /// <summary>
        /// 更新日程和日程用户
        /// </summary>
        /// <param name="schedule">日程实体</param>
        /// <param name="scheduleUsers">日程用户实体</param>
        /// <returns></returns>       
        public bool UpdateHeadAndItems(CommonService.Model.OA.O_Schedule schedule, List<CommonService.Model.OA.O_Schedule_user> scheduleUsers)
        {
            return bll.UpdateHeadAndItems(schedule, scheduleUsers);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid scheduleCode)
        {

            return bll.Delete(scheduleCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Schedule_idlist)
        {
            return bll.DeleteList(O_Schedule_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Schedule GetModel(Guid scheduleCode)
        {

            return bll.GetModel(scheduleCode);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule> DataTableToList(DataTable dt)
        {
            return bll.DataTableToList(dt);
        }

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule> GetAllList()
        {
            return bll.GetAllList();
        }

        /// <summary>
        /// 通过根用户，获取所有列表
        /// </summary>
        /// <param name="rootUserCode">根用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Schedule> GetListByRootUserCode(Guid rootUserCode)
        {
            return bll.GetListByRootUserCode(rootUserCode);
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
        /// <summary>
        /// 通过用户guid获得未读取的日程消息全部数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule> GetMsgListByUsercode(Guid userCode)
        {
            return bll.GetMsgListByUsercode(userCode);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        #region App专用

        /// <summary>
        /// 通过主用户GUID获取日程
        /// </summary>
        /// <param name="userCode">主用户GUID</param>
        /// <returns>日程列表</returns>
        public List<Model.OA.O_Schedule> AppGetSchedule(Guid? userCode)
        {
            return bll.GetListByRootUserCode(userCode.Value);
        }

        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <returns>是否成功</returns>
        public int AppAddSchedule(Model.OA.O_Schedule model)
        {
            return bll.Add(model);
        }

        #endregion


        
    }

}
