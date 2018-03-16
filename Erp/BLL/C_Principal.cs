using CommonService.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// C_Principal
    /// </summary>
    public partial class C_Principal
    {
        private readonly DAL.C_Principal dal = new DAL.C_Principal();
        private readonly CommonService.BLL.SysManager.C_Userinfo userDal = new BLL.SysManager.C_Userinfo();
        private readonly CommonService.BLL.SysManager.C_Userinfo_region userregDal = new BLL.SysManager.C_Userinfo_region();
        private readonly CommonService.BLL.C_Customer_Region cusRegBll = new BLL.C_Customer_Region();
        private readonly CommonService.BLL.SysManager.C_Organization organizationbll = new SysManager.C_Organization();
        public C_Principal()
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
        public bool Exists(Model.C_Principal model)
        {
            return dal.Exists(model);
        }
        /// <summary>
        /// 根据委托人姓名查看是否存在该记录
        /// </summary>
        /// <param name="C_Customer_name"></param>
        /// <param name="C_Customer_businessType"></param>
        /// <returns></returns>
        public bool ExistsByPrincipalName(string C_Customer_name, int C_Customer_businessType)
        {
            return dal.ExistsByPrincipalName(C_Customer_name, C_Customer_businessType);
        }
        /// <summary>
        /// 根据委托人姓名和GUID查看是否存在该记录
        /// </summary>
        /// <param name="C_Customer_name"></param>
        /// <param name="C_Customer_code"></param>
        /// <param name="C_Customer_businessType"></param>
        /// <returns></returns>
        public bool ExistsByPrincipalNameAndCode(string C_Customer_name, Guid C_Customer_code, int C_Customer_businessType)
        {
            return dal.ExistsByPrincipalNameAndCode(C_Customer_name, C_Customer_code, C_Customer_businessType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_Principal model)
        {
           return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.C_Principal model)
        {
          return  dal.Update(model);
           
        }

        /// <summary>
        /// 关联区域
        /// </summary>
        /// <param name="model"></param>
        private void relationCustomerRegion(CommonService.Model.C_Principal model)
        {
            CommonService.Model.SysManager.C_Userinfo userinfoChilds = new CommonService.Model.SysManager.C_Userinfo();
            if (model.C_Principal_consultant != null)
            {
                userinfoChilds = userDal.GetModelByUserCode(model.C_Principal_consultant.Value);
            }
            else
            {
                userinfoChilds = userDal.GetModelByUserCode(model.C_Principal_creator.Value);
            }
            if (userinfoChilds != null)
            {
                CommonService.Model.SysManager.C_Userinfo_region userinfoRegion = userregDal.GetModelByUserinfoCode(userinfoChilds.C_Userinfo_code.Value);

                if (userinfoRegion != null)
                {
                    CommonService.Model.C_Customer_Region customerRegion = new CommonService.Model.C_Customer_Region();
                    customerRegion.C_Customer_Region_customer = model.C_Principal_code.Value;
                    customerRegion.C_Customer_Region_relRegion = userinfoRegion.C_Region_code.Value;
                    customerRegion.C_Customer_Region_isDelete = 0;
                    customerRegion.C_Customer_Region_creator = model.C_Principal_creator;
                    customerRegion.C_Customer_Region_createTime = DateTime.Now;

                    cusRegBll.DeleteByCustomerCode(model.C_Principal_code.Value);
                    cusRegBll.Add(customerRegion);
                }
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Principal_code)
        {
            bool isSuccess = false;
            isSuccess = dal.Delete(C_Principal_code);
            if (isSuccess)
            {
                cusRegBll.DeleteByCustomerCode(C_Principal_code);
            }
            return isSuccess;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Principal_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Principal_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.C_Principal GetModel(Guid C_Principal_code)
        {

            return dal.GetModel(C_Principal_code);
           
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.C_Principal GetModelByCache(int C_Principal_id)
        {

            string CacheKey = "C_PrincipalModel-" + C_Principal_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Principal_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.C_Principal)objModel;
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
        public List<Model.C_Principal> GetAllList()
        {
            DataSet ds = dal.GetAllList();
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.C_Principal> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.C_Principal> DataTableToList(DataTable dt)
        {
            List<Model.C_Principal> modelList = new List<Model.C_Principal>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.C_Principal model;
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
        public int GetRecordCount(Model.C_Principal model)
        {
            
            return dal.GetRecordCount(model);
        }
        private void SetDep(Guid guid, List<Guid> DepIds)
        {
            var OrganizationList = organizationbll.GetModelByParent(guid);
            if (OrganizationList.Count > 0)
            {
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);
                }
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Principal> GetListByPage(Model.C_Principal model, string orderby, int startIndex, int endIndex)
        {
            

            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        //}
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
