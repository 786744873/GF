using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model.CaseManager;
using CommonService.Common;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件关联表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
    public partial class B_Case_link
    {
        private readonly CommonService.DAL.CaseManager.B_Case_link dal = new CommonService.DAL.CaseManager.B_Case_link();
        private readonly CommonService.DAL.C_Customer clientDal = new CommonService.DAL.C_Customer();
        public B_Case_link()
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
        public bool Exists(int B_Case_link_id)
        {
            return dal.Exists(B_Case_link_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_link model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.CaseManager.B_Case_link> B_Case_links)
        {
            foreach (CommonService.Model.CaseManager.B_Case_link caseLink in B_Case_links)
            {
                dal.Delete(new Guid(caseLink.B_Case_code.ToString()), caseLink.B_Case_link_type);//根据案件Guid删除关联所有数据
                if (caseLink.B_Case_link_type == Convert.ToInt32(CaselinkEnum.客户))
                {
                    dal.Delete(new Guid(caseLink.B_Case_code.ToString()), Convert.ToInt32(CaselinkEnum.销售顾问));
                }
            }
            foreach (CommonService.Model.CaseManager.B_Case_link caseLink in B_Case_links)
            {
                dal.Add(caseLink);

                if (caseLink.B_Case_link_type == Convert.ToInt32(CaselinkEnum.客户))
                {
                    CommonService.Model.C_Customer client = clientDal.GetModel(caseLink.C_FK_code.Value);
                    CommonService.Model.CaseManager.B_Case_link bcaselink = new Model.CaseManager.B_Case_link();
                    bcaselink.B_Case_code = caseLink.B_Case_code;
                    bcaselink.C_FK_code = client.C_Customer_consultant;
                    bcaselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.销售顾问);
                    bcaselink.B_Case_link_creator = caseLink.B_Case_link_creator;
                    bcaselink.B_Case_link_createTime = caseLink.B_Case_link_createTime;
                    bcaselink.B_Case_link_isDelete = 0;

                    dal.Add(bcaselink);
                }
            }
            return true;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case_link model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_code)
        {

            return dal.Delete(B_Case_code);
        }
        /// <summary>
        /// 删除一条数据通过类型和案件GUID
        /// </summary>
        public bool Delete(Guid B_Case_code, int? B_Case_link_type)
        {
            return dal.Delete(B_Case_code, B_Case_link_type);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_link_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_Case_link_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_link GetModel(int B_Case_link_id)
        {

            return dal.GetModel(B_Case_link_id);
        }
        /// <summary>
        /// 根据外键code和类型得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_link GetModelByFkCodeAndType(Guid? fk_code, int? type)
        {
            return dal.GetModelByFkCodeAndType(fk_code, type);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.CaseManager.B_Case_link GetModelByCache(int B_Case_link_id)
        {

            string CacheKey = "B_Case_linkModel-" + B_Case_link_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(B_Case_link_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.CaseManager.B_Case_link)objModel;
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
        public List<CommonService.Model.CaseManager.B_Case_link> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_link> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_Case_link> modelList = new List<CommonService.Model.CaseManager.B_Case_link>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case_link model;
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
        /// 获取案件关联集合
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="type">关联类型</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case_link> GetCaseLinksByCaseAndType(Guid caseCode, int type)
        {
            return DataTableToList(dal.GetCaseLinksByCaseAndType(caseCode, type).Tables[0]);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CaseManager.B_Case_link model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case_link> GetListByPage(CommonService.Model.CaseManager.B_Case_link model, string orderby, int startIndex, int endIndex)
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

        /// <summary>
        /// 根据案件GUID和类型获取对应名称，如有多个，以逗号隔开
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetStringFK(Guid caseCode, int type)
        {
            List<CommonService.Model.CaseManager.B_Case_link> lst = DataTableToList(dal.GetCaseLinksByCaseAndType(caseCode, type).Tables[0]);
            BLL.C_Customer customerBLL = new C_Customer(); //客户业务逻辑
            BLL.C_CRival cRivalBLL = new C_CRival(); //公司对手业务逻辑
            BLL.C_PRival pRivalBLL = new C_PRival(); //个人对手业务逻辑
            BLL.C_Region regionBLL = new C_Region(); //区域业务逻辑
            BLL.C_Involved_project projectBLL = new C_Involved_project(); //涉案项目业务逻辑
            BLL.SysManager.C_Userinfo userinfoBLL = new SysManager.C_Userinfo(); //用户业务逻辑

            string result = "";
            foreach (var item in lst)
            {
                if (type == 0 || type == 1 || type == 8) //客户或委托人
                {
                    Model.C_Customer customer = customerBLL.GetModel(item.C_FK_code.Value);
                    if (customer == null)
                    {
                        continue;
                    }
                    result += customer.C_Customer_name;
                }
                else if (type == 2 || type == 4 || type == 9) //公司对手
                {
                    Model.C_CRival cRival = cRivalBLL.GetModel(item.C_FK_code.Value);
                    if (cRival == null)
                    {
                        continue;
                    }
                    result += cRival.C_CRival_name;
                }
                else if (type == 3 || type == 5 || type == 10) //个人对手
                {
                    Model.C_PRival pRival = pRivalBLL.GetModel(item.C_FK_code.Value);
                    if (pRival == null)
                    {
                        continue;
                    }
                    result += pRival.C_PRival_name;
                }
                else if (type == 6) //区域
                {
                    Model.C_Region region = regionBLL.GetModelByCode(item.C_FK_code.Value);
                    if (region == null)
                    {
                        continue;
                    }
                    result += region.C_Region_name;
                }
                else if (type == 7) //工程
                {
                    Model.C_Involved_project project = projectBLL.GetModel(item.C_FK_code.Value);
                    if (project == null)
                    {
                        continue;
                    }
                    result += project.C_Involved_project_name;
                }
                else if (type == 11) //专业顾问
                {
                    Model.SysManager.C_Userinfo userinfo = userinfoBLL.GetModelByUserCode(item.C_FK_code.Value);
                    if (userinfo == null)
                    {
                        continue;
                    }
                    result += userinfo.C_Userinfo_name;
                }

                result += ",";
            }

            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        #endregion  ExtensionMethod
    }
}

