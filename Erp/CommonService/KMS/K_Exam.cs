using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService.KMS;

namespace CommonService.KMS
{
    public class K_Exam : IK_Exam
    {
        CommonService.BLL.KMS.K_Exam bll = new CommonService.BLL.KMS.K_Exam();
        public K_Exam()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Exam_code)
        {
            return bll.Exists(K_Exam_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.KMS.K_Exam model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Exam model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Exam_code)
        {

            return bll.Delete(K_Exam_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Exam GetModel(Guid K_Exam_code)
        {

            return bll.GetModel(K_Exam_code);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam> GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam> GetModelList(string strWhere)
        {
            return bll.GetModelList(strWhere);
        }
        /// <summary>
        /// 根据分类获取数据列表
        /// </summary>
        /// <param name="categoryList"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Exam> GetListByCategory(string categoryList, CommonService.Model.KMS.K_Exam model)
        {
            return bll.GetListByCategory(categoryList, model);
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
        public List<CommonService.Model.KMS.K_Exam> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
