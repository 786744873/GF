using cn.jpush.api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// O_Article_user文章用户中间表
    /// cyj
    /// 2015年7月24日15:42:51
    /// </summary>
    public partial class O_Article_user
    {
        private readonly CommonService.DAL.OA.O_Article_user dal = new CommonService.DAL.OA.O_Article_user();
        private readonly CommonService.BLL.SysManager.C_Userinfo userbll = new BLL.SysManager.C_Userinfo();
        public O_Article_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Article_user_id)
        {
            return dal.Exists(O_Article_user_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Article_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Article_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Article_user_id)
        {

            return dal.Delete(O_Article_user_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Article_user_idlist)
        {
            return dal.DeleteList(O_Article_user_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article_user GetModel(int O_Article_user_id)
        {

            return dal.GetModel(O_Article_user_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.OA.O_Article_user GetModelByCache(int O_Article_user_id)
        {

            string CacheKey = "O_Article_userModel-" + O_Article_user_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(O_Article_user_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.OA.O_Article_user)objModel;
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
        public List<CommonService.Model.OA.O_Article_user> GetModelList(string strWhere)
        {

            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article_user> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Article_user> modelList = new List<CommonService.Model.OA.O_Article_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Article_user model;
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
        /// 根据文章guid获得已经读取该文章的用户集合获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article_user> GetListByCode(Guid O_Article_code)
        {
            return DataTableToList(dal.GetListByCode(O_Article_code).Tables[0]);
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
        /// 根据文章guid获得未读取该文章的用户集合获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article_user> GetNoreadListByCode(Guid O_Article_code)
        {
            return DataTableToList(dal.GetNoreadListByCode(O_Article_code).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 批量添加用户文章中间表
        /// </summary>
        /// <param name="orgList"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddList(string orgList, CommonService.Model.OA.O_Article model)
        {
            dal.DeleteByACode(model.O_Article_code.Value); //先清除关联用户
            bool flag = true;
            if (!string.IsNullOrEmpty(orgList))
            {
                string[] orglists = orgList.Split(',');
                ArrayList rootUsers = new ArrayList();//根用户集合

                //先去掉可能出现的重复主用户(指的是两个子用户所在不同的组织结构)
                foreach (var org in orglists)
                {                    
                    DataTable userLists = userbll.GetModelByOrgCode(new Guid(org)).Tables[0];//获取该组织机构下的所有主用户code
                    for (int i = 0; i < userLists.Rows.Count; i++)
                    {
                        if (!rootUsers.Contains(userLists.Rows[i][0].ToString()))
                        {
                            rootUsers.Add(userLists.Rows[i][0].ToString());
                        }
                    }
                }
                //给对应组织机构下的根用户发送通知公告
                for (int i = 0; i < rootUsers.Count; i++)
                {
                    CommonService.Model.OA.O_Article_user Articlemodel = new Model.OA.O_Article_user();
                    Articlemodel.C_Userinfo_code = new Guid(rootUsers[i].ToString());
                    Articlemodel.O_Article_user_createTime = model.O_Article_createTime;
                    Articlemodel.O_Article_user_creator = model.O_Article_creator;
                    Articlemodel.O_Article_user_isDelete = 0;
                    Articlemodel.O_Article_user_isRead = false;
                    Articlemodel.O_Article_code = model.O_Article_code;
                    if (!(Add(Articlemodel) > 0))
                    {
                        flag = false;
                    }
                    //推送手机端的信息消息
                    Thread t = new Thread(new ParameterizedThreadStart(PushMessage));
                    t.Start(Articlemodel);
                }
            }
            return flag;
        }

        /// <summary>
        /// 推送信息
        /// </summary>
        /// <param name="m"></param>
        public void PushMessage(object m)
        {
            CommonService.Model.OA.O_Article_user model=(CommonService.Model.OA.O_Article_user)m;
            //推送app消息逻辑
            JPushClient jc = new JPushClient();
            jc.PushObject_android_and_ios(model.C_Userinfo_code.ToString().Replace('-', '_'), "您有一条新的公告消息,请及时查看！", "notice", model.O_Article_code.ToString());
        }


        /// <summary>
        /// 根据文章guid和用户guid得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article_user GetModelByAcodeAndCcode(Guid O_Article_code, Guid C_Userinfo_code)
        {
            return dal.GetModelByAcodeAndCcode(O_Article_code, C_Userinfo_code);
        }
        #endregion  BasicMethod

        #region
        /// <summary>
        /// 根据GUID使公告已读
        /// </summary>
        public bool IsRead(CommonService.Model.OA.O_Article_user model)
        {
            return dal.Update(model);
        }
        #endregion
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
