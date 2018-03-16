using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CaseManager
{
    public class B_Case_Typicalcase
    {
        private readonly CommonService.DAL.CaseManager.B_Case_Typicalcase dal = new CommonService.DAL.CaseManager.B_Case_Typicalcase();
        public B_Case_Typicalcase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_Typicalcase_id)
        {
            return dal.Exists(B_Case_Typicalcase_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_Typicalcase_id)
        {

            return dal.Delete(B_Case_Typicalcase_id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="typicalcodes"></param>
        /// <returns></returns>
        public bool MutilyDelete(string typicalcodes)
        {
            string[] codes = typicalcodes.Split(',');
            for (int i = 0; i < codes.Count(); i++)
            {
                if (!dal.DeleteByCode(new Guid(codes[i])))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Typicalcase GetModel(int B_Case_Typicalcase_id)
        {

            return dal.GetModel(B_Case_Typicalcase_id);
        }

        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_Typicalcase GetModelByCode(Guid B_Case_Typicalcase_code)
        {
            return dal.GetModelByCode(B_Case_Typicalcase_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetList(int Top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetList(Top, strWhere, filedOrder).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_Case_Typicalcase> modelList = new List<CommonService.Model.CaseManager.B_Case_Typicalcase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case_Typicalcase model;
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetListByPage(CommonService.Model.CaseManager.B_Case_Typicalcase model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
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
