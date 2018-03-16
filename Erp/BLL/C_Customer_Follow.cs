using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL
{
    /// <summary>
    /// 客户跟进表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/08/7
    /// </summary>
    public partial class C_Customer_Follow
    {
        private readonly CommonService.DAL.C_Customer_Follow dal = new CommonService.DAL.C_Customer_Follow();
        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        /// <summary>
        /// 角色区域中间表逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Userinfo_region regionBLL = new SysManager.C_Userinfo_region();
        /// <summary>
        /// 分组表业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Group groupBLL = new CommonService.BLL.SysManager.C_Group();

        public C_Customer_Follow()
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
        public bool Exists(int C_Customer_Follow_id)
        {
            return dal.Exists(C_Customer_Follow_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer_Follow model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Customer_Follow model)
        {
            return dal.Update(model);
        }

        
        /// <summary>
        /// 保存客户跟踪
        /// </summary>
        /// <param name="model">客户跟踪实体</param>
        /// <returns>返回1代表，成功；0代表失败</returns>     
        public int OperateCustomerFollow(CommonService.Model.C_Customer_Follow model)
        {
            bool isSuccess = false;
            int customerFollowId = 0;
            if (model.C_Customer_Follow_id > 0)
            {
                isSuccess = dal.Update(model);//执行修改
            }
            else
            {
                customerFollowId = dal.Add(model);//执行添加
                if (customerFollowId > 0)
                    isSuccess = true;
            }

            if (isSuccess)
                return 1;
            else return 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Customer_Follow_id)
        {

            return dal.Delete(C_Customer_Follow_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Customer_Follow_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Customer_Follow_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Customer_Follow GetModel(int C_Customer_Follow_id)
        {

            return dal.GetModel(C_Customer_Follow_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Customer_Follow GetModelByCache(int C_Customer_Follow_id)
        {

            string CacheKey = "C_Customer_FollowModel-" + C_Customer_Follow_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Customer_Follow_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Customer_Follow)objModel;
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
        public List<CommonService.Model.C_Customer_Follow> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Customer_Follow> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Customer_Follow> modelList = new List<CommonService.Model.C_Customer_Follow>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Customer_Follow model;
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Customer_Follow model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Customer_Follow> GetListByPage(CommonService.Model.C_Customer_Follow model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 根据客户实体和客户跟进实体获取中记录数
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <returns></returns>
        public int GetRecordCount2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, bool IsPreSetManager, Guid? userCode, Guid? postGroupCode)
        {
            //分总所在区域
            //string areaCodes = String.Empty;
            //if (roleId == 12)
            //{
            //    List<CommonService.Model.SysManager.C_Userinfo_region> lists = regionBLL.GetListByRoleId(userCode);
            //    foreach (CommonService.Model.SysManager.C_Userinfo_region item in lists)
            //    {
            //        areaCodes += item.C_Region_code.ToString() + ",";
            //    }
            //}
            string groupCodes = postGroupCode.ToString();
            //List<CommonService.Model.SysManager.C_Group> GroupList = groupBLL.GetListByUserCode(new Guid(userCode.ToString()));
            //if (GroupList.Count != 0)
            //{
            //    foreach (CommonService.Model.SysManager.C_Group itemGroup in GroupList)
            //    {
            //        groupCodes += itemGroup.C_Group_code.ToString() + ",";
            //    }
            //    groupCodes = groupCodes == string.Empty ? groupCodes : groupCodes.Substring(0, groupCodes.Length - 1);
            //}
            return dal.GetRecordCount2(model, modelc, groupCodes, IsPreSetManager, userCode);
        }
        /// <summary>
        /// 根据客户实体和客户跟进实体获取分页数据
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Customer_Follow> GetListByPage2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, bool IsPreSetManager, string orderby, int startIndex, int endIndex, Guid? userCode, Guid? postGroupCode)
        {
            //分总所在区域
            string groupCodes = postGroupCode.ToString();
            //if (roleId == 12)
            //{
            //    List<CommonService.Model.SysManager.C_Userinfo_region> lists = regionBLL.GetListByRoleId(userCode);
            //    foreach (CommonService.Model.SysManager.C_Userinfo_region item in lists)
            //    {
            //        areaCodes += item.C_Region_code.ToString() + ",";
            //    }
            //}

            //List<CommonService.Model.SysManager.C_Group> GroupList = groupBLL.GetListByUserCode(new Guid(userCode.ToString()));
            //if(GroupList.Count != 0)
            //{
            //    foreach(CommonService.Model.SysManager.C_Group itemGroup in GroupList)
            //    {
            //        groupCodes += itemGroup.C_Group_code.ToString() + ",";
            //    }
            //    groupCodes = groupCodes == string.Empty ? groupCodes : groupCodes.Substring(0, groupCodes.Length - 1);
            //}

            return DataTableToList(dal.GetListByPage2(model, modelc, groupCodes, IsPreSetManager, orderby, startIndex, endIndex, userCode).Tables[0]);
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

