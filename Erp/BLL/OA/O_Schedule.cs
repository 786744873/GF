using CommonService.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// O_Schedule日程表
    /// cyj
    /// 2015年7月14日17:11:04
    /// </summary>
    public partial class O_Schedule
    {
        private readonly CommonService.DAL.OA.O_Schedule dal = new CommonService.DAL.OA.O_Schedule();

        /// <summary>
        /// 日程-用户关联数据访问层
        /// </summary>
        private readonly CommonService.DAL.OA.O_Schedule_user scheduleUserDAL = new DAL.OA.O_Schedule_user();

        public O_Schedule()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Schedule_id)
        {
            return dal.Exists(O_Schedule_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Schedule model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Schedule model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 新增日程和日程用户
        /// </summary>
        /// <param name="schedule">日程实体</param>
        /// <param name="scheduleUsers">日程用户实体</param>
        /// <returns></returns>        
        public bool AddHeadAndItems(CommonService.Model.OA.O_Schedule schedule, List<CommonService.Model.OA.O_Schedule_user> scheduleUsers)
        {
            int sheduleId = dal.Add(schedule);
            bool isSuccess = false;
            if (sheduleId > 0)
            {
                isSuccess = true;
            }
            if (isSuccess)
            {
                if (scheduleUsers.Count != 0)
                {
                    foreach (CommonService.Model.OA.O_Schedule_user scheduleUser in scheduleUsers)
                    {
                        scheduleUserDAL.Add(scheduleUser);
                    }
                }
            }

            return isSuccess;
        }

        /// <summary>
        /// 更新日程和日程用户
        /// </summary>
        /// <param name="schedule">日程实体</param>
        /// <param name="scheduleUsers">日程用户实体</param>
        /// <returns></returns>       
        public bool UpdateHeadAndItems(CommonService.Model.OA.O_Schedule schedule, List<CommonService.Model.OA.O_Schedule_user> scheduleUsers)
        {
            /*
             * 更新时：需要把日程关联用户先删除掉，然后重新插入新数据
             * author:hety
             * date:2015-07-29
             ***/
            bool isSuccess = dal.Update(schedule);
            if (isSuccess)
            {
                scheduleUserDAL.DeleteByScheduleCode(schedule.O_Schedule_code.Value);
                if (scheduleUsers.Count != 0)
                {
                    foreach (CommonService.Model.OA.O_Schedule_user scheduleUser in scheduleUsers)
                    {
                        scheduleUserDAL.Add(scheduleUser);
                    }
                }
            }

            return isSuccess;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid scheduleCode)
        {

            return dal.Delete(scheduleCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Schedule_idlist)
        {
            return dal.DeleteList(O_Schedule_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Schedule GetModel(Guid scheduleCode)
        {

            return dal.GetModel(scheduleCode);
        }

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule> GetAllList()
        {
            DataSet ds = dal.GetAllList();
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得全部提醒的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule> GetAllremindList()
        {
            return DataTableToList(dal.GetAllremindList().Tables[0]);
        }
        /// <summary>
        /// 通过根用户，获取所有列表
        /// </summary>
        /// <param name="rootUserCode">根用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Schedule> GetListByRootUserCode(Guid rootUserCode)
        {
            DataSet ds = dal.GetListByRootUserCode(rootUserCode);
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
        public List<CommonService.Model.OA.O_Schedule> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Schedule> modelList = new List<CommonService.Model.OA.O_Schedule>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Schedule model;
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
        /// <summary>
        /// 通过用户guid获得未读取的日程消息全部数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Schedule> GetMsgListByUsercode(Guid userCode)
        {
            return DataTableToList(dal.GetMsgListByUsercode(userCode).Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        #region App专用
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Schedule model, List<CommonService.Model.OA.O_Schedule_user> lst)
        {
            foreach (var item in lst) //添加日程关联人员
            {
                scheduleUserDAL.Add(item);
            }
            int count = dal.Add(model);
            MSMQ.SendScheduleMessage();//发送日程消息
            return count;
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <param name="lst">人员列表</param>
        /// <returns>是否成功</returns>
        public int Update(CommonService.Model.OA.O_Schedule model, List<CommonService.Model.OA.O_Schedule_user> lst)
        {
            scheduleUserDAL.DeleteByScheduleCode(model.O_Schedule_code.Value); //删除日程关联人员
            foreach (var item in lst) //添加日程关联人员
            {
                scheduleUserDAL.Add(item);
            }
            int count = dal.Update(model) ? 1 : 0;
            MSMQ.SendScheduleMessage();//发送日程消息
            return count;
        }

        /// <summary>
        /// 根据用户GUID和日期获取日程
        /// </summary>
        /// <param name="userCode">用户GUID</param>
        /// <param name="dt">日期</param>
        /// <returns>日程列表</returns>
        public List<Model.OA.O_Schedule> GetListByDateAndUser(Guid? userCode, DateTime dt)
        {
            return DataTableToList(dal.GetListByDateAndUser(userCode, dt).Tables[0]);
        }

        /// <summary>
        /// 获取所有日程（包含已读未读属性）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.OA.O_Schedule> GetListByUserAndMessages(Guid? userCode, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByUserAndMessages(userCode, startIndex, endIndex).Tables[0]);
        }
        #endregion
    }
}
