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
    /// 问题/文档/视频 关联业务流程表单表
    /// cyj
    /// 2016年1月13日10:25:51
    /// </summary>
    public class K_PorblemAndResources_LinkCase : IK_PorblemAndResources_LinkCase
    {
        private readonly CommonService.BLL.KMS.K_PorblemAndResources_LinkCase bll = new CommonService.BLL.KMS.K_PorblemAndResources_LinkCase();
        public K_PorblemAndResources_LinkCase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_ProblemAndResources_LinkCase_id)
        {
            return bll.Exists(K_ProblemAndResources_LinkCase_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int K_ProblemAndResources_LinkCase_id)
        {

            return bll.Delete(K_ProblemAndResources_LinkCase_id);
        }
        /// <summary>
        /// 根据实体得到数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> GetListByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL)
        {
            return bll.GetListByModel(modelL);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModel(int K_ProblemAndResources_LinkCase_id)
        {

            return bll.GetModel(K_ProblemAndResources_LinkCase_id);
        }
        /// <summary>
        /// 根据实体得到对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModelByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL)
        {
            return bll.GetModelByModel(modelL);
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
        /// 批量增加
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        public bool MutilyAdd(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return bll.MutilyAdd(model);
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        public bool MutilyUpdate(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return bll.MutilyUpdate(model);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        public bool MutilyDelete(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return bll.MutilyDelete(model);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

    }
}
