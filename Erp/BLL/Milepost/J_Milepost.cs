using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
using System.Collections;
namespace CommonService.BLL.Milepost
{
    /// <summary>
    /// J_Milepost
    /// </summary>
    public partial class J_Milepost
    {
        private readonly CommonService.DAL.Milepost.J_Milepost dal = new CommonService.DAL.Milepost.J_Milepost();
        private readonly CommonService.BLL.SysManager.C_Organization Odal = new CommonService.BLL.SysManager.C_Organization();

        private readonly CommonService.BLL.SysManager.C_Userinfo Udal = new CommonService.BLL.SysManager.C_Userinfo();
        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        public J_Milepost()
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
        public bool Exists(int J_Milepost_id)
        {
            return dal.Exists(J_Milepost_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.Milepost.J_Milepost model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.Milepost.J_Milepost model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int J_Milepost_id)
        {

            return dal.Delete(J_Milepost_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string J_Milepost_idlist)
        {
            return dal.DeleteList(J_Milepost_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Milepost.J_Milepost GetModel(int J_Milepost_id)
        {

            return dal.GetModel(J_Milepost_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.Milepost.J_Milepost GetModelByCache(int J_Milepost_id)
        {

            string CacheKey = "J_MilepostModel-" + J_Milepost_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(J_Milepost_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.Milepost.J_Milepost)objModel;
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
        public List<CommonService.Model.Milepost.J_Milepost> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.Milepost.J_Milepost> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.Milepost.J_Milepost> modelList = new List<CommonService.Model.Milepost.J_Milepost>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.Milepost.J_Milepost model;
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
        public int GetRecordCount(CommonService.Model.Milepost.J_Milepost model, bool IsPreSetManager, Guid? userCode,List<Guid?> depts)
        {
            //权限判断
            System.Text.StringBuilder but = new System.Text.StringBuilder();

            //如果不为内置系统管理员
            if (!IsPreSetManager)
            {
                List<Guid?> glist = new List<Guid?>();
                //遍历用户所部门集合(可能会属于多个部门)
                foreach (var dept in depts)
                {
                    glist.Add(dept.Value);
                    //根据当前组织机构找出所有子组织机构
                    var oplist = Odal.GetModelByParent(dept.Value);
                    foreach (var item in oplist)
                    {
                        glist.Add(item.C_Organization_code);
                        BindChiOd(item.C_Organization_code, glist);
                    }
                }

                List<Model.SysManager.C_Userinfo> Uinfo = new List<Model.SysManager.C_Userinfo>();
                //找出所有用户
                foreach (var item in glist)
                {
                    var Ulist = Udal.GetUsersByOrgAndPost(item.Value, null, "");
                    if (Ulist.Count > 0)
                        Uinfo.AddRange(Ulist);
                }

                foreach (var item in Uinfo)
                {
                    but.Append(item.C_Userinfo_code + ",");
                }
            }

            return dal.GetRecordCount(model, but.ToString(), userCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.Milepost.J_Milepost> GetListByPage(CommonService.Model.Milepost.J_Milepost model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, List<Guid?> depts)
        {

            //权限判断
            System.Text.StringBuilder but = new System.Text.StringBuilder();

            //如果不为内置系统管理员
            if (!IsPreSetManager)
            {
                List<Guid?> glist = new List<Guid?>();
                //遍历用户所部门集合(可能会属于多个部门)
                foreach (var dept in depts)
                {
                    glist.Add(dept.Value);
                    //根据当前组织机构找出所有子组织机构
                    var oplist = Odal.GetModelByParent(dept.Value);
                    foreach (var item in oplist)
                    {
                        glist.Add(item.C_Organization_code);
                        BindChiOd(item.C_Organization_code, glist);
                    }
                }

                List<Model.SysManager.C_Userinfo> Uinfo = new List<Model.SysManager.C_Userinfo>();

                //找出所有用户
                foreach (var item in glist)
                {
                    var Ulist = Udal.GetUsersByOrgAndPost(item.Value, null, "");
                    if (Ulist.Count > 0)
                        Uinfo.AddRange(Ulist);
                }

                foreach (var item in Uinfo)
                {
                    but.Append(item.C_Userinfo_code + ",");
                }
            }


            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex, but.ToString(), userCode).Tables[0]);
        }
        private void BindChiOd(Guid? nullable, List<Guid?> glist)
        {
            //根据当前组织机构找出所有子组织机构
            var oplist = Odal.GetModelByParent(nullable.Value);
            foreach (var item in oplist)
            {
                glist.Add(item.C_Organization_code);
                BindChiOd(item.C_Organization_code, glist);
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

