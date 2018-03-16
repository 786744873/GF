using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using System.Linq;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 组织架构表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Organization
    {
        private readonly CommonService.DAL.SysManager.C_Organization dal = new CommonService.DAL.SysManager.C_Organization();
        private readonly CommonService.DAL.SysManager.C_Userinfo_region dal2 = new CommonService.DAL.SysManager.C_Userinfo_region();


        public C_Organization()
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
        public bool Exists(int C_Organization_id)
        {
            return dal.Exists(C_Organization_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization model)
        {
            if (model.C_Organization_parent == null)
            {//根组织机构添加
                model.C_Organization_level = 1;
                CommonService.Model.SysManager.C_Organization maxOrderModel = dal.GetMaxOrderModelByLevel(model.C_Organization_level.Value);
                model.C_Organization_order = maxOrderModel == null ? 1 : maxOrderModel.C_Organization_order.Value + 1;
            }
            else
            {//子组织机构添加
                CommonService.Model.SysManager.C_Organization parentModel = dal.GetModel(model.C_Organization_parent.Value);
                model.C_Organization_level = parentModel.C_Organization_level + 1;
                if (parentModel.C_Organization_level > 1)
                {
                    model.C_Organization_Area = parentModel.C_Organization_Area;
                }
                CommonService.Model.SysManager.C_Organization maxOrderModel = dal.GetMaxOrderModelByParent(model.C_Organization_parent.Value);
                model.C_Organization_order = maxOrderModel == null ? 1 : maxOrderModel.C_Organization_order.Value + 1;
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Organization model, Guid oldguid)
        {
            if (model.C_Organization_level > 1)
            {
                List<CommonService.Model.SysManager.C_Organization> list = new List<Model.SysManager.C_Organization>();
                var list2 = GetModelByParent(new Guid(model.C_Organization_code.ToString()));
                list.Add(model);
                list.AddRange(list2);
                getChiModel(list2, list);
                //1.先取出当前组织机构下的所有人员
                List<CommonService.Model.SysManager.C_Userinfo> listuserinfor = GetAllUserinfor(list);
                //2.然后判断人员关联的区域是否含有老的组织架构区域，如果有的话删除
                Updateregion(listuserinfor, oldguid);
                //dal.CommonService.Model.SysManager.C_Userinfo_region
                //3.接着把所有当前组织架构的区域更改为新的组织架构区域
                dal.UpdateAll(new Guid(model.C_Organization_Area.ToString()), list);
                //4.最后查看当前组织架构的区域是否含有新的区域没有则加上
                UpdateNewregion(listuserinfor, new Guid(model.C_Organization_Area.ToString()));
                //OK


            }

            return dal.Update(model);
        }
        /// <summary>
        /// 批量把新的区域更改
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newguid"></param>
        public void UpdateNewregion(List<CommonService.Model.SysManager.C_Userinfo> list, Guid newguid)
        {
            foreach (CommonService.Model.SysManager.C_Userinfo item in list)
            {
                dal.UpdateNewregion(new Guid(item.C_Userinfo_code.ToString()), newguid);
            }

        }
        /// <summary>
        /// 批量修改子级组织架构及关联用户的组织架构,把老的组织架构去掉
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public void Updateregion(List<CommonService.Model.SysManager.C_Userinfo> list, Guid oldguid)
        {
            foreach (CommonService.Model.SysManager.C_Userinfo item in list)
            {
                dal.Updateregion(new Guid(item.C_Userinfo_code.ToString()), oldguid);
            }

        }
        private void getChiModel(List<Model.SysManager.C_Organization> list2, List<Model.SysManager.C_Organization> list)
        {
            foreach (var item in list2)
            {
                var list3 = GetModelByParent(new Guid(item.C_Organization_code.ToString()));
                if (list3 == null || list3.Count <= 0) continue;
                list.AddRange(list3);
                getChiModel(list3, list);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Organization_id)
        {

            return dal.Delete(C_Organization_id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="C_Organization_code"></param>
        /// <returns></returns>
        public bool Delete(Guid C_Organization_code)
        {
            bool isSuccess = dal.Delete(C_Organization_code);
            if (isSuccess)
            {
                List<CommonService.Model.SysManager.C_Organization> ChildrenOrganizations = GetModelByParent(C_Organization_code);
                foreach (CommonService.Model.SysManager.C_Organization childrenOrg in ChildrenOrganizations)
                {
                    dal.Delete(childrenOrg.C_Organization_code.Value);
                    RecursionDelete(childrenOrg.C_Organization_code.Value);
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// 递归删除
        /// </summary>
        /// <param name="parentOrgCode">父亲机构Guid</param>
        /// <returns></returns>
        private void RecursionDelete(Guid parentOrgCode)
        {
            List<CommonService.Model.SysManager.C_Organization> ChildrenOrganizations = GetModelByParent(parentOrgCode);
            foreach (CommonService.Model.SysManager.C_Organization childrenOrg in ChildrenOrganizations)
            {
                dal.Delete(childrenOrg.C_Organization_code.Value);
                RecursionDelete(childrenOrg.C_Organization_code.Value);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Organization_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Organization_idlist, 0));
        }
        /// <summary>
        /// orgParentCode所有子集是否包含orgCode
        /// </summary>
        /// <param name="orgParentCode"></param>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public bool isHeadOrganizationCode(Guid orgParentCode, Guid orgCode)
        {
            bool isHead = false;
            List<CommonService.Model.SysManager.C_Organization> organizationList = DataTableToList(dal.GetModelByParent(orgParentCode).Tables[0]);
            isHead = organizationList.Where(o => o.C_Organization_code == orgCode).FirstOrDefault() == null ? false : true;
            if (!isHead)
            {
                foreach (CommonService.Model.SysManager.C_Organization orgItem in organizationList)
                {
                    isHead = isHeadOrganizationCode(orgItem.C_Organization_code.Value, orgCode);
                    if (isHead)
                        break;
                }
            }
            return isHead;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization GetModel(int C_Organization_id)
        {
            return dal.GetModel(C_Organization_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_Organization_code"></param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Organization GetModel(Guid C_Organization_code)
        {
            return dal.GetModel(C_Organization_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Organization GetModelByCache(int C_Organization_id)
        {

            string CacheKey = "C_OrganizationModel-" + C_Organization_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Organization_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Organization)objModel;
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
        /// 根据用户获得用户关联区域下包含（type=1、律师 2、专业顾问）的组织架构
        /// </summary>
        /// <param name="userinfoCode">用户Guid</param>
        /// <param name="type">type=1、包含律师的组织架构 2、包含专业顾问的组织架构</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetContainLawyerOrAdvisorList(Guid userinfoCode, int? type)
        {
            return DataTableToList(dal.GetContainLawyerOrAdvisorList(userinfoCode, type).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过父级机构Guid，获取子集机构集合
        /// </summary>
        /// <param name="parentCode">父级机构Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetModelByParent(Guid parentCode)
        {
            return DataTableToList(dal.GetModelByParent(parentCode).Tables[0]);
        }
        /// <summary>
        /// 根据组织架构code获得列表
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetChirldAllList(Guid? orgCode)
        {
            return DataTableToList(dal.GetChirldAllList(orgCode).Tables[0]);
        }
        /// <summary>
        /// 根据当前组织架构取出当前组织架构下面的所有人员
        /// </summary>
        /// <param name="oldguid"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetAllUserinfor(List<CommonService.Model.SysManager.C_Organization> list)
        {

            return DataTableToList2(dal.GetAllUserinfor(list).Tables[0]);
        }
        public List<CommonService.Model.SysManager.C_Userinfo> DataTableToList2(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Userinfo> modelList = new List<CommonService.Model.SysManager.C_Userinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Userinfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel2(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetAllList()
        {
            DataSet ds = dal.GetAllList();
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据用户Guid获得关联部门
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Organization> GetListByUserCode(Guid userCode)
        {
            DataSet ds = dal.GetListByUserCode(userCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Organization> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Organization> modelList = new List<CommonService.Model.SysManager.C_Organization>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Organization model;
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
        public int GetRecordCount(Model.SysManager.C_Organization model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Organization> GetListByPage(Model.SysManager.C_Organization model, string orderby, int startIndex, int endIndex)
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

        #region App专用
        /// <summary>
        /// 获取部门，只获取二级部门
        /// </summary>
        /// <returns>部门列表</returns>
        public List<Model.SysManager.C_Organization> AppGetDepartments()
        {
            return GetModelList(" C_Organization_level=2 and C_Organization_isDelete=0");
        }
        #endregion
    }
}

