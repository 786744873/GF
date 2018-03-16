using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 评论（回答）表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Comments
    {
        private readonly CommonService.DAL.KMS.K_Comments dal = new CommonService.DAL.KMS.K_Comments();
        public K_Comments()
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
        public bool Exists(int K_Comments_id)
        {
            return dal.Exists(K_Comments_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Comments model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Comments model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Comments_code)
        {
            dal.Delete(K_Comments_code);
            deleteChild(K_Comments_code);//删除子级评论
            return true;
        }
        /// <summary>
        /// 删除子级评论
        /// </summary>
        /// <param name="parentCode">父级评论Guid</param>
        private void deleteChild(Guid parentCode)
        {
            List<CommonService.Model.KMS.K_Comments> commentChilds = GetListByParent(parentCode);
            foreach (CommonService.Model.KMS.K_Comments comment in commentChilds)
            {
                Delete(comment.K_Comments_code.Value);
                deleteChild(comment.K_Comments_code.Value);
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        public bool DeleteList(string K_Comments_idlist)
        {
            K_Comments_idlist = "'" + K_Comments_idlist + "'";
            bool result = dal.DeleteList(K_Comments_idlist);
            if (result)
            {
                string[] code = K_Comments_idlist.Split(',');
                foreach (var item in code)
                {
                    string resCode = item.Substring(1, item.Length - 2);
                    deleteChild(new Guid(resCode));//删除子级评论
                }
            }
            
            return result;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Comments GetModel(int K_Comments_id)
        {

            return dal.GetModel(K_Comments_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Comments GetModel(Guid K_Comments_code)
        {

            return dal.GetModel(K_Comments_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_Comments GetModelByCache(int K_Comments_id)
        {

            string CacheKey = "K_CommentsModel-" + K_Comments_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_Comments_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_Comments)objModel;
        }
        /// <summary>
        /// 获得子集数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Comments> GetListByParent(Guid K_Comments_parent)
        {
            return DataTableToList(dal.GetListByParent(K_Comments_parent).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Comments> GetListByHelpfulCount(int K_Comments_type)
        {
            return DataTableToList(dal.GetListByHelpfulCount(K_Comments_type).Tables[0]);
        }
        /// <summary>
        /// 用户未读评论列表
        /// </summary>
        /// <param name="K_Comments_creator">用户Guid</param>
        /// <param name="K_Comments_type">评论类型</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetUnreadList(Guid K_Comments_creator, int K_Comments_type)
        {
            return DataTableToList(dal.GetUnreadList(K_Comments_creator, K_Comments_type).Tables[0]);
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
        public List<CommonService.Model.KMS.K_Comments> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Comments> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_Comments> modelList = new List<CommonService.Model.KMS.K_Comments>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_Comments model;
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
        public int GetRecordCount(CommonService.Model.KMS.K_Comments model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 获取最大楼层数
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public int GetFloors(Guid P_FK_code)
        {
            return dal.GetFloors(P_FK_code);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Comments> GetListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取资源评论列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetResourcesCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetResourcesCommentListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取问答回答列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetProblemCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetProblemCommentListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 根据外键guid获得评论列表
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetCommentsListByCode(Guid P_FK_code)
        {
            return DataTableToList(dal.GetCommentsListByCode(P_FK_code).Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

