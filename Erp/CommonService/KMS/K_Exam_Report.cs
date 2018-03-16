using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService.KMS;

namespace CommonService.KMS
{
    public partial class K_Exam_Report : IK_Exam_Report
    {
        CommonService.BLL.KMS.K_Exam_Report bll = new CommonService.BLL.KMS.K_Exam_Report();
        public K_Exam_Report()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Exam_Report_code)
        {
            return bll.Exists(K_Exam_Report_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.KMS.K_Exam_Report model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Exam_Report model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Exam_Report_code)
        {

            return bll.Delete(K_Exam_Report_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Exam_Report GetModel(Guid K_Exam_Report_code)
        {

            return bll.GetModel(K_Exam_Report_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Report> GetList(string strWhere)
        {
            return bll.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Report> GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Report> GetModelList(string strWhere)
        {
            return bll.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Exam_Report> GetAllList()
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
        public List<CommonService.Model.KMS.K_Exam_Report> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
