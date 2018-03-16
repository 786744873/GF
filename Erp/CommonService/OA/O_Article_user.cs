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
    /// O_Article_user文章用户中间表
    /// cyj
    /// 2015年7月24日15:46:03
    /// </summary>
    public partial class O_Article_user : IO_Article_user
    {
        private readonly CommonService.BLL.OA.O_Article_user bll = new CommonService.BLL.OA.O_Article_user();
        
        public O_Article_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_Article_user_id)
        {
            return bll.Exists(O_Article_user_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Article_user model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Article_user model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int O_Article_user_id)
        {

            return bll.Delete(O_Article_user_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Article_user_idlist)
        {
            return bll.DeleteList(O_Article_user_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article_user GetModel(int O_Article_user_id)
        {

            return bll.GetModel(O_Article_user_id);
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
        public DataSet GetAllList()
        {
            return GetList("");
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
        /// 根据组织机构的GUID   向表中添加数据
        /// </summary>
        /// <param name="orgList"></param>
        /// <returns></returns>
        public bool AddList(string orgList, CommonService.Model.OA.O_Article model)
        {
            return bll.AddList(orgList, model);
        }
        /// <summary>
        /// 根据文章guid获得已经读取该文章的用户集合获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article_user> GetListByCode(Guid O_Article_code)
        {
            return bll.GetListByCode(O_Article_code);
        }
        /// <summary>
        /// 根据文章guid获得未读取该文章的用户集合获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Article_user> GetNoreadListByCode(Guid O_Article_code)
        {
            return bll.GetNoreadListByCode(O_Article_code);
        }
        /// <summary>
        /// 根据文章guid和用户guid得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Article_user GetModelByAcodeAndCcode(Guid O_Article_code, Guid C_Userinfo_code)
        {
            return bll.GetModelByAcodeAndCcode(O_Article_code, C_Userinfo_code);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod


       
    }

}
