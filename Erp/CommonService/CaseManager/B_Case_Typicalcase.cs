using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    public class B_Case_Typicalcase : IB_Case_Typicalcase
    {
        private readonly CommonService.BLL.CaseManager.B_Case_Typicalcase bll = new CommonService.BLL.CaseManager.B_Case_Typicalcase();
        public B_Case_Typicalcase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_Typicalcase_id)
        {
            return bll.Exists(B_Case_Typicalcase_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_Typicalcase_id)
        {
            return bll.Delete(B_Case_Typicalcase_id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="typicalcodes"></param>
        /// <returns></returns>
        public bool MutilyDelete(string typicalcodes)
        {
            return bll.MutilyDelete(typicalcodes);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Typicalcase GetModel(int B_Case_Typicalcase_id)
        {

            return bll.GetModel(B_Case_Typicalcase_id);
        }
        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Typicalcase GetModelByCode(Guid B_Case_Typicalcase_code)
        {
            return bll.GetModelByCode(B_Case_Typicalcase_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetList(string strWhere)
        {
            return bll.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetListByPage(CommonService.Model.CaseManager.B_Case_Typicalcase model, string orderby, int startIndex, int endIndex)
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
