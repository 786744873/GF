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
    /// O_Email 邮件
    /// cyj
    /// 2015年7月14日16:19:54
    /// </summary>
    public partial class O_Email : IO_Email
    {
        private readonly CommonService.BLL.OA.O_Email bll = new BLL.OA.O_Email();
        public O_Email()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Email_id)
        {
            return bll.Exists(O_Email_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Email model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Email model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Email_id)
        {

            return bll.Delete(O_Email_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Email_idlist)
        {
            return bll.DeleteList(O_Email_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email GetModel(int O_Email_id)
        {

            return bll.GetModel(O_Email_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.OA.O_Email GetModelByCache(int O_Email_id)
        {
            return bll.GetModelByCache(O_Email_id);
        }
        /// <summary>
        /// 根据emailcode得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Email GetModelByCode(Guid emailCode)
        {
            return bll.GetModelByCode(emailCode);
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
        public List<CommonService.Model.OA.O_Email> GetModelList(string strWhere)
        {
            DataSet ds = bll.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email> DataTableToList(DataTable dt)
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
        public int GetRecordCount(CommonService.Model.OA.O_Email model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Email> GetListByPage(CommonService.Model.OA.O_Email model, string orderby, int startIndex, int endIndex)
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
        /// 多条添加
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public bool MutilyAddEmail(CommonService.Model.OA.O_Email email, string userList)
        {
            return bll.MutilyAddEmail(email, userList);
        }
        /// <summary>
        /// 根据邮件guid删除相应草稿箱的信息
        /// </summary>
        /// <param name="emailCode"></param>
        /// <returns></returns>
        public bool MutilyDelete(Guid emailCode)
        {
            return bll.MutilyDelete(emailCode);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
