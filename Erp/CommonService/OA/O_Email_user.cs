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
    /// O_Email_user8.	邮件----收件人中间表	
    /// cyj
    /// 2015年7月14日16:33:11
    /// </summary>
    public partial class O_Email_user : IO_Email_user
    {
        private readonly CommonService.BLL.OA.O_Email_user bll = new BLL.OA.O_Email_user();
        public O_Email_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {
            return bll.Exists(O_Email_user_id, O_Email_code, C_Userinfo_code, O_Email_user_isRead, O_Email_user_type, O_Email_creator, O_Email_createTime, O_Email_isDelete);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.OA.O_Email_user model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Email_user model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {

            return bll.Delete(O_Email_user_id, O_Email_code, C_Userinfo_code, O_Email_user_isRead, O_Email_user_type, O_Email_creator, O_Email_createTime, O_Email_isDelete);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email_user GetModel(int O_Email_user_id, Guid O_Email_code, Guid C_Userinfo_code, bool O_Email_user_isRead, int O_Email_user_type, Guid O_Email_creator, DateTime O_Email_createTime, bool O_Email_isDelete)
        {

            return bll.GetModel(O_Email_user_id, O_Email_code, C_Userinfo_code, O_Email_user_isRead, O_Email_user_type, O_Email_creator, O_Email_createTime, O_Email_isDelete);
        }
        /// <summary>
        /// 根据邮件guid和收件人guid获取数据
        /// </summary>
        public CommonService.Model.OA.O_Email_user GetModelByEcodeAndUcode(Guid O_Email_code, Guid C_Userinfo_code)
        {
            return bll.GetModelByEcodeAndUcode(O_Email_code, C_Userinfo_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return bll.GetList(strWhere);
        }
        /// <summary>
        /// 根据邮件code获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetListByEmailCode(Guid emailCode)
        {
            return bll.GetListByEmailCode(emailCode);
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
        public List<CommonService.Model.OA.O_Email_user> GetModelList(string strWhere)
        {
            return bll.GetModelList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> DataTableToList(DataTable dt)
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
        public int GetRecordCount(CommonService.Model.OA.O_Email_user model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetListByPage(CommonService.Model.OA.O_Email_user model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 根据邮件的code和收件人code删除一条数据
        /// </summary>
        public bool DeleteByCode(Guid O_Email_code, Guid userCode)
        {
            return bll.DeleteByCode(O_Email_code, userCode);
        }
        /// <summary>
        /// 根据收件人code获得未读邮件的数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetNoReadListUserCode(Guid C_Userinfo_code)
        {
            return bll.GetNoReadListUserCode(C_Userinfo_code);
        }
        /// <summary>
        /// 根据收件人code获得所有的邮件数据列表以及邮件的消息信息
        /// </summary>
        public List<CommonService.Model.OA.O_Email_user> GetListByUserCode(Guid C_Userinfo_code)
        {
            return bll.GetListByUserCode(C_Userinfo_code);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }

}
