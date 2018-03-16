using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// 消息--分类中间表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/12/07
    /// </summary>
    public partial class C_Messages_Category
    {
        private readonly CommonService.DAL.C_Messages_Category dal = new CommonService.DAL.C_Messages_Category();

        public C_Messages_Category()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Messages_Category_id)
        {
            return dal.Exists(C_Messages_Category_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Messages_Category model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Messages_Category model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Messages_Category_id)
        {

            return dal.Delete(C_Messages_Category_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Messages_Category_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Messages_Category_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages_Category GetModel(int C_Messages_Category_id)
        {

            return dal.GetModel(C_Messages_Category_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Messages_Category GetModelByCache(int C_Messages_Category_id)
        {

            string CacheKey = "C_Messages_CategoryModel-" + C_Messages_Category_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Messages_Category_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Messages_Category)objModel;
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
        public List<CommonService.Model.C_Messages_Category> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据消息大类型，消息级别，获取消息头集合
        /// </summary>
        /// <param name="messageCategoryBigClass">消息大类型</param>
        /// <param name="messageCategoryLevel">消息级别</param>
        /// <param name="isPreSetManager">是否内置系统管理员</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Messages_Category> GetMessageHeads(int messageCategoryBigClass, int messageCategoryLevel, bool isPreSetManager, Guid? loginChildrenUser)
        {
            DataSet ds = dal.GetMessageHeads(messageCategoryBigClass, messageCategoryLevel, isPreSetManager, loginChildrenUser);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Messages_Category> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Messages_Category> modelList = new List<CommonService.Model.C_Messages_Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Messages_Category model;
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

        #endregion  BasicMethod
       
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
