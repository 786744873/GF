using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// O_Email 邮件表
    /// cyj
    /// 2015年7月14日16:18:28
    /// </summary>
    public partial class O_Email
    {
        private readonly CommonService.DAL.OA.O_Email dal = new DAL.OA.O_Email();
        private readonly CommonService.BLL.OA.O_Email_user bllemail_user = new O_Email_user();
        private readonly CommonService.DAL.OA.O_Email_user dal_emailuser = new DAL.OA.O_Email_user();
        private readonly CommonService.BLL.SysManager.C_Userinfo blluserinfo = new CommonService.BLL.SysManager.C_Userinfo();
        public O_Email()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Email_id)
        {
            return dal.Exists(O_Email_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Email model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Email model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Email_id)
        {

            return dal.Delete(O_Email_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Email_idlist)
        {
            return dal.DeleteList(O_Email_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email GetModel(int O_Email_id)
        {

            return dal.GetModel(O_Email_id);
        }
        /// <summary>
        /// 根据emailcode得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email GetModelByCode(Guid emailCode)
        {
            return dal.GetModelByCode(emailCode);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.OA.O_Email GetModelByCache(int O_Email_id)
        {

            string CacheKey = "O_EmailModel-" + O_Email_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(O_Email_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.OA.O_Email)objModel;
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
        public List<CommonService.Model.OA.O_Email> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Email> modelList = new List<CommonService.Model.OA.O_Email>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Email model;
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
        public int GetRecordCount(CommonService.Model.OA.O_Email model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email> GetListByPage(CommonService.Model.OA.O_Email model, string orderby, int startIndex, int endIndex)
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
        /// <summary>
        /// 发送邮件多条添加
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public bool MutilyAddEmail(CommonService.Model.OA.O_Email email, string userList)
        {
            CommonService.Model.OA.O_Email emailModel = new Model.OA.O_Email();
            CommonService.Model.OA.O_Email_user emailUserModel = new Model.OA.O_Email_user();
            //根据邮件model  获取是否是草稿箱 或者更改草稿箱内容并且发送
            CommonService.Model.OA.O_Email model = dal.GetModelByCode(new Guid(email.O_Email_code.ToString()));
            if (model != null)
            { //草稿箱 转发送   先修改邮件状态
                if (email.O_Email_state == 489 && model.O_Email_state == 490)
                    model.O_Email_state = 489;
                if (!this.Update(model))
                    return false;
                //然后删除草稿箱中的邮件收件人
                List<CommonService.Model.OA.O_Email_user> userlists = bllemail_user.GetListByEmailCode(new Guid(email.O_Email_code.ToString()));
                if (userlists.Count() > 0)
                {
                    if (!dal_emailuser.DeleteByEmailCodeD(new Guid(email.O_Email_code.ToString())))
                        return false;
                }

                if (!string.IsNullOrEmpty(userList))
                {
                    if (userList.Contains("-1"))
                    {
                        List<CommonService.Model.SysManager.C_Userinfo> userinfoList = blluserinfo.GetParentList();
                        foreach (var useremail in userinfoList)
                        {//向邮件收件人中间表中添加数据
                            if (useremail.C_Userinfo_code == email.O_Email_sender)
                                continue;
                            emailUserModel.O_Email_code = email.O_Email_code;
                            emailUserModel.C_Userinfo_code = useremail.C_Userinfo_code.Value;
                            emailUserModel.O_Email_user_isRead = false;
                            emailUserModel.O_Email_user_type = 503;
                            emailUserModel.O_Email_creator = email.O_Email_creator;
                            emailUserModel.O_Email_createTime = email.O_Email_createTime;
                            emailUserModel.O_Email_isDelete = false;
                            if (!(bllemail_user.Add(emailUserModel)))
                                return false;
                        }
                    }
                    else
                    {
                        string[] userLists = userList.Split(',');
                        foreach (var useremail in userLists)
                        {//向邮件收件人中间表中添加数据
                            emailUserModel.O_Email_code = email.O_Email_code;
                            emailUserModel.C_Userinfo_code = new Guid(useremail);
                            emailUserModel.O_Email_user_isRead = false;
                            emailUserModel.O_Email_user_type = 503;
                            emailUserModel.O_Email_creator = email.O_Email_creator;
                            emailUserModel.O_Email_createTime = email.O_Email_createTime;
                            emailUserModel.O_Email_isDelete = false;
                            if (!(bllemail_user.Add(emailUserModel)))
                                return false;
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(userList))
                {//如果邮件中包含收件人
                    emailModel = email;
                    emailModel.O_Email_createTime = DateTime.Now;
                    emailModel.O_Email_isDelete = false;
                    emailModel.O_Email_sendTime = DateTime.Now;
                    if (!(this.Add(emailModel) > 0))
                        return false;
                    if (userList.Contains("-1"))
                    {
                        List<CommonService.Model.SysManager.C_Userinfo> userinfoList = blluserinfo.GetParentList();
                        foreach (var useremail in userinfoList)
                        {//向邮件收件人中间表中添加数据
                            if (useremail.C_Userinfo_code == email.O_Email_sender)
                                continue;
                            emailUserModel.O_Email_code = email.O_Email_code;
                            emailUserModel.C_Userinfo_code = useremail.C_Userinfo_code.Value;
                            emailUserModel.O_Email_user_isRead = false;
                            emailUserModel.O_Email_user_type = 503;
                            emailUserModel.O_Email_creator = email.O_Email_creator;
                            emailUserModel.O_Email_createTime = email.O_Email_createTime;
                            emailUserModel.O_Email_isDelete = false;
                            if (!(bllemail_user.Add(emailUserModel)))
                                return false;
                        }
                    }
                    else
                    {
                        string[] userLists = userList.Split(',');
                        foreach (var useremail in userLists)
                        {//向邮件收件人中间表中添加数据
                            emailUserModel.O_Email_code = email.O_Email_code;
                            emailUserModel.C_Userinfo_code = new Guid(useremail);
                            emailUserModel.O_Email_user_isRead = false;
                            emailUserModel.O_Email_user_type = 503;
                            emailUserModel.O_Email_creator = email.O_Email_creator;
                            emailUserModel.O_Email_createTime = email.O_Email_createTime;
                            emailUserModel.O_Email_isDelete = false;
                            if (!(bllemail_user.Add(emailUserModel)))
                                return false;
                        }
                    }
                }
                else
                { //邮件中不包含收件人
                    emailModel.O_Email_code = email.O_Email_code;
                    emailModel.O_Email_title = email.O_Email_title;
                    emailModel.O_Email_content = email.O_Email_content;
                    emailModel.O_Email_sender = email.O_Email_sender;
                    emailModel.O_Email_state = email.O_Email_state;
                    emailModel.O_Email_creator = email.O_Email_creator;
                    emailModel.O_Email_createTime = DateTime.Now;
                    emailModel.O_Email_isDelete = false;
                    if (!(this.Add(emailModel) > 0))
                        return false;
                }

            }
            return true;
        }
        /// <summary>
        /// 根据邮件guid删除相应草稿箱的信息
        /// </summary>
        /// <param name="emailCode"></param>
        /// <returns></returns>
        public bool MutilyDelete(Guid emailCode)
        {
            Guid emailGuid = emailCode;
            if (!dal.DeleteByCode(emailCode))
                return false;
            List<CommonService.Model.OA.O_Email_user> list = bllemail_user.GetListByEmailCode(emailCode);
            if (list.Count() > 0)
            {
                if (!dal_emailuser.DeleteByemailCode(emailCode))
                    return false;
            }
            return true;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
