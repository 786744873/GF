using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// C_Messages消息表
    /// </summary>
    public partial class C_Messages
    {
        private readonly CommonService.DAL.C_Messages dal = new CommonService.DAL.C_Messages();
        public C_Messages()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Messages_id)
        {
            return dal.Exists(C_Messages_id);
        }

        /// <summary>
        /// 根据关联guid和用户guid查看是否存在该记录
        /// </summary>
        public bool ExistsBylinkCodeAnduserCode(Guid linkCode, Guid userCode)
        {
            return dal.ExistsBylinkCodeAnduserCode(linkCode, userCode);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Messages model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Messages model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Messages_id)
        {

            return dal.Delete(C_Messages_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Messages_idlist)
        {
            return dal.DeleteList(C_Messages_idlist);
        }

        /// <summary>
        /// 读消息
        /// </summary>
        /// <param name="messageId">消息Id</param>
        /// <returns></returns>
        public bool ReadMessage(int messageId)
        {
            return dal.ReadMessage(messageId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModel(int C_Messages_id)
        {

            return dal.GetModel(C_Messages_id);
        }
        /// <summary>
        /// 根据关联GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModelByLinkCode(Guid C_Messages_link)
        {
            return dal.GetModelByLinkCode(C_Messages_link);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Messages GetModelByCache(int C_Messages_id)
        {

            string CacheKey = "C_MessagesModel-" + C_Messages_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Messages_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Messages)objModel;
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
        public List<CommonService.Model.C_Messages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Messages> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Messages> modelList = new List<CommonService.Model.C_Messages>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Messages model;
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
        public int GetRecordCount(CommonService.Model.C_Messages model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Messages> GetListByPage(Model.C_Messages message, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(message, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 根据外键guid和用户guid获得数据列表
        /// </summary>
        public List<Model.C_Messages> GetListByLinkcodeAndUsercode(Guid? linkCode, Guid? userCode)
        {
            return DataTableToList(dal.GetListByLinkcodeAndUsercode(linkCode, userCode).Tables[0]);
        }
        /// <summary>
        /// 根据关联GUID和消息接收人guid得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModelByLinkCodeUserCodeModel(Guid C_Messages_link, Guid userCode)
        {
            return dal.GetModelByLinkCodeUserCodeModel(C_Messages_link, userCode);
        }

        /// <summary>
        /// 根据消息模型条件，获取所有消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>         
        public int GetAllMessageCount(CommonService.Model.C_Messages model)
        {
            return dal.GetAllMessageCount(model);
        }

        /// <summary>
        /// 根据消息模型条件，获取所有ERP消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>        
        public int GetAllERPMessageCount(CommonService.Model.C_Messages model)
        {
            return dal.GetAllERPMessageCount(model);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod


        #region App专用

        /// <summary>
        /// 根据用户GUID获取该用户的消息数量
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>消息数量集合</returns>
        public List<Model.CustomModel.KeyValueModel> GetMessageList(Guid? guid)
        {
            BLL.OA.O_Article articleBLL = new OA.O_Article();
            BLL.OA.O_Schedule_user osuBLL = new OA.O_Schedule_user();

            List<Model.CustomModel.KeyValueModel> resultList = new List<Model.CustomModel.KeyValueModel>(); //返回集合

            Model.CustomModel.KeyValueModel caseMessages = new Model.CustomModel.KeyValueModel(); //案件消息数量
            caseMessages.Key = "案件消息";
            caseMessages.Value = dal.GetCountByParentID(426, guid).ToString();
            resultList.Add(caseMessages);

            Model.CustomModel.KeyValueModel processMessages = new Model.CustomModel.KeyValueModel(); //进程消息数量
            processMessages.Key = "进程消息";
            processMessages.Value = dal.GetCountByParentID(765, guid).ToString();
            resultList.Add(processMessages);

            Model.CustomModel.KeyValueModel financeMessages = new Model.CustomModel.KeyValueModel(); //财务消息数量
            financeMessages.Key = "财务消息";
            financeMessages.Value = dal.GetCountByParentID(810,guid).ToString();
            resultList.Add(financeMessages);

            Model.CustomModel.KeyValueModel announcementMessages = new Model.CustomModel.KeyValueModel(); //公告消息数量
            announcementMessages.Key = "通知公告";
            announcementMessages.Value = articleBLL.GetUnReadCount(guid).ToString();
            resultList.Add(announcementMessages);

            Model.CustomModel.KeyValueModel schMessages = new Model.CustomModel.KeyValueModel(); //日程消息数量
            schMessages.Key = "日程消息";
            schMessages.Value = dal.GetSCountByParentID(510, guid).ToString(); 
            resultList.Add(schMessages);
            return resultList;
        }

        /// <summary>
        /// 将未读消息改为已读
        /// </summary>
        /// <param name="messageID">消息ID</param>
        /// <returns>是否成功</returns>
        public int AppUpdateMessagesIsRead(int messageID)
        {
            return dal.AppUpdateMessagesIsRead(messageID);
        }
        #endregion
    }
}
