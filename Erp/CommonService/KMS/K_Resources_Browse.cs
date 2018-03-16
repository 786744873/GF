using ICommonService.KMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.KMS
{
    /// <summary>
    /// K_Resources_Browse
    /// </summary>
    public partial class K_Resources_Browse : IK_Resources_Browse
    {
        CommonService.BLL.KMS.K_Resources_Browse bll = new CommonService.BLL.KMS.K_Resources_Browse();
        public K_Resources_Browse()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Resources_Browse_id)
        {
            return bll.Exists(K_Resources_Browse_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Userinfo_code"></param>
        /// <param name="K_Resources_code"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Resources_Browse ExistsBrowse(Guid Userinfo_code, Guid K_Resources_code)
        {
            return bll.ExistsBrowse(Userinfo_code, K_Resources_code);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources_Browse model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Resources_Browse model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int K_Resources_Browse_id)
        {

            return bll.Delete(K_Resources_Browse_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string K_Resources_Browse_idlist)
        {
            return bll.DeleteList(K_Resources_Browse_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources_Browse GetModel(int K_Resources_Browse_id)
        {

            return bll.GetModel(K_Resources_Browse_id);
        }
        /// <summary>
        /// 最近浏览
        /// </summary>
        /// <param name="Userinfo_code"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources_Browse> GetListByCreatorTime(Guid Userinfo_code, int pageSize)
        {
            return bll.GetListByCreatorTime(Userinfo_code, pageSize);
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
            return bll.GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.KMS.K_Resources_Browse model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources_Browse> GetListByPage(CommonService.Model.KMS.K_Resources_Browse model, string orderby, int startIndex, int endIndex)
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
