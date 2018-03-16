using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// B_Case_plan
    /// </summary>
    public partial class B_Case_plan
    {
        private readonly CommonService.DAL.CaseManager.B_Case_plan dal = new CommonService.DAL.CaseManager.B_Case_plan();
        private readonly CommonService.DAL.CaseManager.B_Case bdal = new CommonService.DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.CaseManager.B_Case_link clDal = new DAL.CaseManager.B_Case_link();
        private readonly CommonService.DAL.CaseManager.B_Case_plan_Evidence cpDal = new DAL.CaseManager.B_Case_plan_Evidence();
        public B_Case_plan()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid? B_Case_plan_code)
        {
            return dal.Exists(B_Case_plan_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_plan model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_plan model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_Case_plan_id)
        {

            return dal.Delete(B_Case_plan_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_plan_idlist)
        {
            return dal.DeleteList(B_Case_plan_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan GetModel(int B_Case_plan_id)
        {

            return dal.GetModel(B_Case_plan_id);
        }
        /// <summary>
        /// 得到一个对象实体 通过案件GUID
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan GetModelByCode(Guid B_Case_code)
        {
            CommonService.Model.CaseManager.B_Case_plan caseModel = dal.GetModelByCode(B_Case_code);
            if (caseModel == null)
            {
                caseModel = new Model.CaseManager.B_Case_plan();
            }

            #region 变量
            string customerCodeStr = "";
            string customerNameStr = "";

            string personCodeStr = "";
            string personNameStr = "";
            string personTypeStr = "";

            string Evidencesubmitted_nameStr = "";
            string Evidencesubmitted_codeStr = "";

            string Proceedings_nameStr = "";
            string Proceedings_codeStr = "";

            string Evidence_Parameters_nameStr = "";
            string Evidence_Parameters_codeStr = "";
            #endregion

            #region
            List<Model.CaseManager.B_Case_link> Customers = clDal.GetCustomerListByCasecode(B_Case_code);
            foreach (var customer in Customers)
            {
                if (customer.B_Case_link_type == 8)
                { //客户
                    customerCodeStr += customer.C_FK_code.ToString() + ',';
                    customerNameStr += customer.C_Customer_name + ',';
                }
            }

            List<Model.CaseManager.B_Case_link> CRivals = clDal.GetCRivalListByCasecode(B_Case_code);
            foreach (var crival in CRivals)
            {
                if (crival.B_Case_link_type == 9)
                {//被告（公司）
                    personCodeStr += crival.C_FK_code.ToString() + ',';
                    personNameStr += crival.C_CRival_name + ',';
                    personTypeStr += crival.B_Case_link_type.ToString() + ',';
                }
            }
            List<Model.CaseManager.B_Case_link> PRivals = clDal.GetPRivalListByCasecode(B_Case_code);
            foreach (var prival in PRivals)
            {
                if (prival.B_Case_link_type == 10)
                {//被告（个人）
                    personCodeStr += prival.C_FK_code.ToString() + ',';
                    personNameStr += prival.C_PRival_name + ',';
                    personTypeStr += prival.B_Case_link_type.ToString() + ',';
                }
            }
            List<Model.CaseManager.B_Case_plan_Evidence> Evidencesubmitteds = cpDal.GetList(" B_Case_plan_code='" + B_Case_code + "' and B_Case_paln_Evidence_type=1 ");
            foreach (var Evidencesubmitted in Evidencesubmitteds)
            {//立案提交的证据
                Evidencesubmitted_codeStr += Evidencesubmitted.B_Case_plan_Evidence_file_code.ToString() + ',';
                Evidencesubmitted_nameStr += Evidencesubmitted.B_Case_plan_Evidence_name.ToString() + ',';
            }
            List<Model.CaseManager.B_Case_plan_Evidence> Proceedings = cpDal.GetList(" B_Case_plan_code='" + B_Case_code + "' and B_Case_paln_Evidence_type=2 ");
            foreach (var Proceeding in Proceedings)
            {//诉讼提交的证据
                Proceedings_codeStr += Proceeding.B_Case_plan_Evidence_file_code.ToString() + ',';
                Proceedings_nameStr += Proceeding.B_Case_plan_Evidence_name.ToString() + ',';
            }
            List<Model.CaseManager.B_Case_plan_Evidence> Evidence_Parameters = cpDal.GetList(" B_Case_plan_code='" + B_Case_code + "' and B_Case_paln_Evidence_type=3 ");
            foreach (var Evidence_Parameter in Evidence_Parameters)
            {//诉讼提交的证据
                Evidence_Parameters_codeStr += Evidence_Parameter.B_Case_plan_Evidence_Parameters_id.ToString() + ',';
                Evidence_Parameters_nameStr += Evidence_Parameter.B_Case_plan_Evidence_Parameters_name.ToString() + ',';
            }
            #endregion

            #region 虚拟字段赋值
            caseModel.B_Case_plan_plaintiff_Customer_code = customerCodeStr == "" ? customerCodeStr : customerCodeStr.Substring(0, customerCodeStr.Length - 1);
            caseModel.B_Case_plan_plaintiff_Customer_name = customerNameStr == "" ? customerNameStr : customerNameStr.Substring(0, customerNameStr.Length - 1);
            caseModel.B_Case_plan_defendant_Customer_code = personCodeStr == "" ? personCodeStr : personCodeStr.Substring(0, personCodeStr.Length - 1);
            caseModel.B_Case_plan_defendant_Customer_name = personNameStr == "" ? personNameStr : personNameStr.Substring(0, personNameStr.Length - 1);
            caseModel.B_Case_plan_defendant_Customer_type = personTypeStr == "" ? personTypeStr : personTypeStr.Substring(0, personTypeStr.Length - 1);
            caseModel.B_Case_plan_Evidencesubmitted_code = Evidencesubmitted_codeStr == "" ? Evidencesubmitted_codeStr : Evidencesubmitted_codeStr.Substring(0, Evidencesubmitted_codeStr.Length - 1);
            caseModel.B_Case_plan_Evidencesubmitted_name = Evidencesubmitted_nameStr == "" ? Evidencesubmitted_nameStr : Evidencesubmitted_nameStr.Substring(0, Evidencesubmitted_nameStr.Length - 1);
            caseModel.B_Case_plan_Proceedings_code = Proceedings_codeStr == "" ? Proceedings_codeStr : Proceedings_codeStr.Substring(0, Proceedings_codeStr.Length - 1);
            caseModel.B_Case_plan_Proceedings_name = Proceedings_nameStr == "" ? Proceedings_nameStr : Proceedings_nameStr.Substring(0, Proceedings_nameStr.Length - 1);
            caseModel.B_Case_plan_Evidence_Parameters_code = Evidence_Parameters_codeStr == "" ? Evidence_Parameters_codeStr : Evidence_Parameters_codeStr.Substring(0, Evidence_Parameters_codeStr.Length - 1);
            caseModel.B_Case_plan_Evidence_Parameters_name = Evidence_Parameters_nameStr == "" ? Evidence_Parameters_nameStr : Evidence_Parameters_nameStr.Substring(0, Evidence_Parameters_nameStr.Length - 1);
            #endregion
            return caseModel;
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_plan GetModelByCache(int B_Case_plan_id)
        {

            string CacheKey = "B_Case_planModel-" + B_Case_plan_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(B_Case_plan_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.CaseManager.B_Case_plan)objModel;
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
        /// <summary>
        /// 向数据库添加或者修改一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdate(CommonService.Model.CaseManager.B_Case_plan model)
        {
            if (this.Exists(model.B_Case_plan_code))
            {
                if (this.Update(model))
                    return true;
                else
                    return false;
            }
            else
            {
                if (this.Add(model) >= 1)
                    return true;
                else
                    return false;
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
