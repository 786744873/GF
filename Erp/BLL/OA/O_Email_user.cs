using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// O_Email_user8.	邮件----收件人中间表	
    /// cyj
    /// 2015年7月14日16:33:11
    /// </summary>
    public partial class O_Email_user
    {
        private readonly CommonService.DAL.OA.O_Email_user dal = new DAL.OA.O_Email_user();
        public O_Email_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {
            return dal.Exists(O_Email_user_id, O_Email_code, C_Userinfo_code, O_Email_user_isRead, O_Email_user_type, O_Email_creator, O_Email_createTime, O_Email_isDelete);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Email_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Email_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {

            return dal.Delete(O_Email_user_id, O_Email_code, C_Userinfo_code, O_Email_user_isRead, O_Email_user_type, O_Email_creator, O_Email_createTime, O_Email_isDelete);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email_user GetModel(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {

            return dal.GetModel(O_Email_user_id, O_Email_code, C_Userinfo_code, O_Email_user_isRead, O_Email_user_type, O_Email_creator, O_Email_createTime, O_Email_isDelete);
        }
        /// <summary>
        /// 根据邮件guid和收件人guid获取数据
        /// </summary>
        public CommonService.Model.OA.O_Email_user GetModelByEcodeAndUcode(Guid O_Email_code, Guid C_Userinfo_code)
        {
            return dal.GetModelByEcodeAndUcode(O_Email_code, C_Userinfo_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据邮件code获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetListByEmailCode(Guid emailCode)
        {
            return DataTableToList(dal.GetListByEmailCode(emailCode).Tables[0]);
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
        public List<CommonService.Model.OA.O_Email_user> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Email_user> modelList = new List<CommonService.Model.OA.O_Email_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Email_user model;
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
        public int GetRecordCount(CommonService.Model.OA.O_Email_user model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetListByPage(CommonService.Model.OA.O_Email_user model, string orderby, int startIndex, int endIndex)
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
        /// 根据邮件的code和收件人code删除一条数据
        /// </summary>
        public bool DeleteByCode(Guid O_Email_code, Guid userCode)
        {
            return dal.DeleteByCode(O_Email_code, userCode);
        }
        /// <summary>
        /// 根据收件人code获得未读邮件的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetNoReadListUserCode(Guid C_Userinfo_code)
        {
            return DataTableToList(dal.GetNoReadListUserCode(C_Userinfo_code).Tables[0]);
        }
        /// <summary>
        /// 根据收件人code获得所有的邮件数据列表以及邮件的消息信息
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetListByUserCode(Guid C_Userinfo_code)
        {
            return DataTableToList(dal.GetListByUserCode(C_Userinfo_code).Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
