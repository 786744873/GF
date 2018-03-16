using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using System.Collections;
using CommonService.Common;
namespace CommonService.BLL.SysManager
{
    /// <summary>
    /// 用户表逻辑
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Userinfo
    {
        private readonly CommonService.DAL.SysManager.C_Userinfo dal = new CommonService.DAL.SysManager.C_Userinfo();
        /// <summary>
        /// 组织机构数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Organization orgDal = new CommonService.DAL.SysManager.C_Organization();
        /// <summary>
        /// 岗位数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Post postDAL = new CommonService.DAL.SysManager.C_Post();
        /// <summary>
        /// 岗位组数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Group groupDAL = new CommonService.DAL.SysManager.C_Group();
        /// <summary>
        /// 组织机构-用户-岗位数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Organization_post_user orgPostUserDAL = new CommonService.DAL.SysManager.C_Organization_post_user();
        /// <summary>
        /// 组织机构-用户-岗位-区域数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Organization_post_user_region orgPostUserRegionDAL = new CommonService.DAL.SysManager.C_Organization_post_user_region();
        /// <summary>
        /// 组织机构-用户-岗位-角色数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Organization_post_user_role orgPostUserRoleDAL = new CommonService.DAL.SysManager.C_Organization_post_user_role();

        /// <summary>
        /// 组织机构-用户-岗位-角色关系业务访问层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Organization_post_user_role orgUserPostRoleBLL = new CommonService.BLL.SysManager.C_Organization_post_user_role();
        /// <summary>
        /// 组织机构-人员-岗位-区域业务访问层
        /// </summary>
        CommonService.BLL.SysManager.C_Organization_post_user_region orgUserPostRegionBLL = new CommonService.BLL.SysManager.C_Organization_post_user_region();

        private readonly CommonService.BLL.SysManager.C_Post bll_post = new CommonService.BLL.SysManager.C_Post();
        private readonly CommonService.BLL.SysManager.C_Group bll_group = new CommonService.BLL.SysManager.C_Group();
        private readonly CommonService.DAL.FlowManager.P_Business_flow businessFloeDal = new CommonService.DAL.FlowManager.P_Business_flow();
        private readonly CommonService.DAL.CaseManager.B_Case caseDal = new CommonService.DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance businessChanceDal = new CommonService.DAL.BusinessChanceManager.B_BusinessChance();
        private readonly CommonService.DAL.C_Customer customerDal = new CommonService.DAL.C_Customer();
        private readonly CommonService.BLL.C_Court_Lawyer courtlawyerBll = new CommonService.BLL.C_Court_Lawyer();

        private readonly CommonService.DAL.SysManager.C_Userinfo_region userinfoRegionDal = new CommonService.DAL.SysManager.C_Userinfo_region();
        public C_Userinfo()
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
        public bool Exists(int C_Userinfo_id)
        {
            return dal.Exists(C_Userinfo_id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Userinfo_id">用户登录名</param>
        /// <returns>是否存在</returns>
        public bool ExistsByloginID(string C_Userinfo_loginID)
        {
            return dal.ExistsByloginID(C_Userinfo_loginID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Userinfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Userinfo model)
        {
            bool isSuccess = false;

            isSuccess = dal.Update(model);
            List<CommonService.Model.SysManager.C_Userinfo> userinfoList = GetChildUsersInfoByUsercode(model.C_Userinfo_code.Value);//获取所有子用户
            foreach (CommonService.Model.SysManager.C_Userinfo userinfo in userinfoList)
            {
                userinfo.C_Userinfo_name = model.C_Userinfo_name;
                userinfo.C_Userinfo_loginID = model.C_Userinfo_loginID;
                userinfo.C_Userinfo_password = model.C_Userinfo_password;
                userinfo.C_Userinfo_cellPhoneNumber = model.C_Userinfo_cellPhoneNumber;
                userinfo.C_Userinfo_mailbox = model.C_Userinfo_mailbox;
                userinfo.C_Userinfo_Integral = model.C_Userinfo_Integral;

                isSuccess = dal.Update(userinfo);
            }
            return isSuccess;
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePass(CommonService.Model.SysManager.C_Userinfo model)
        {
            bool flag = true;
            if (!dal.Update(model))
            {
                flag = false;
            }
            if (!dal.UpdatePass(new Guid(model.C_Userinfo_code.ToString()), model.C_Userinfo_password))
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid userinfo_code)
        {
            //判断是否包含子用户，如果包含则删除
            List<CommonService.Model.SysManager.C_Userinfo> childrenList = DataTableToList(dal.GetChildUserByParentCode(userinfo_code).Tables[0]);
            string childrenCode = "";
            if (childrenList.Count > 0)
            {
                foreach (var children in childrenList)
                {
                    childrenCode += "'" + children.C_Userinfo_code + "',";
                }
                childrenCode = childrenCode.Substring(0, childrenCode.Length - 1);
                dal.DeleteList(childrenCode);
            }
            return dal.Delete(userinfo_code);
        }

        /// <summary>
        /// 删除子用户
        /// </summary>
        /// <param name="childrenUserCode">子用户Guid</param>
        /// <returns></returns>        
        public bool DeleteChildren(Guid childrenUserCode)
        {
            /**
             * author:hety
             * date:2015-11-12
             * description:删除子用户
             * 子用户删除后，检查子用户的根用户下是否有默认子用户，如果没有的话，自动设置一子用户，为默认子用户
             ***/
            bool isDeleteSucess = false;
            isDeleteSucess = dal.Delete(childrenUserCode);
            //已删除子用户对象
            CommonService.Model.SysManager.C_Userinfo deletedChildrenUser = dal.GetModelByCode(childrenUserCode);
            if (deletedChildrenUser != null && deletedChildrenUser.C_Userinfo_parent != null)
            {
                bool isHasDefaultChildren = false;//是否存在默认子用户
                Guid newDefaultChildrenCode = Guid.Empty;//可能新的默认子用户Guid
                List<CommonService.Model.SysManager.C_Userinfo> ChildrenUsers = this.GetChildUsersInfoByUsercode(deletedChildrenUser.C_Userinfo_parent.Value);
                foreach (CommonService.Model.SysManager.C_Userinfo child in ChildrenUsers)
                {
                    newDefaultChildrenCode = child.C_Userinfo_code.Value;
                    if (child.C_Userinfo_isDefault)
                    {
                        isHasDefaultChildren = true;
                        break;
                    }
                }
                if (!isHasDefaultChildren)
                {
                    if (newDefaultChildrenCode != Guid.Empty)
                    {//重新设置默认子用户
                        dal.UpdateDefault(newDefaultChildrenCode, true);
                    }
                }
            }

            return isDeleteSucess;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo GetModel(int C_Userinfo_id)
        {

            return dal.GetModel(C_Userinfo_id);
        }

        /// <summary>
        /// 通过用户登录名，获取用户实体
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByLoginName(string loginID)
        {
            return dal.GetModelByLoginName(loginID);
        }

        /// <summary>
        /// 通过用户登录名和密码，获取用户实体
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByLoginNameAndPassword(string loginID, string password)
        {
            return dal.GetModelByLoginNameAndPassword(loginID, password);
        }

        /// <summary>
        /// 通过父亲Guid，获取一默认子用户
        /// </summary>
        /// <param name="parentCode">父亲Guid</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetDefaultChildUserByParentCode(Guid parentCode)
        {
            return dal.GetDefaultChildUserByParentCode(parentCode);
        }

        /// <summary>
        /// 通过用户Guid，获取用户对象
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByUserCode(Guid userCode)
        {
            return dal.GetModelByUserCode(userCode);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo GetModelByCache(int C_Userinfo_id)
        {

            string CacheKey = "C_UserinfoModel-" + C_Userinfo_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Userinfo_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.SysManager.C_Userinfo)objModel;
        }
        /// <summary>
        /// 根据组织机构GUID获取所有的主用户
        /// </summary>
        public DataSet GetModelByOrgCode(Guid orgCode)
        {
            return dal.GetModelByOrgCode(orgCode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得所有父级用户列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetParentList()
        {
            return DataTableToList(dal.GetParentList().Tables[0]);
        }
        /// <summary>
        /// 根据区域获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetListByRegionCode(Guid regionCode)
        {
            return DataTableToList(dal.GetListByRegionCode(regionCode).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得所有子级用户数据列表
        /// </summary>
        /// <param name="type">
        /// 1、查看指挥中心案件
        /// 2、首席专家
        /// </param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetAllChildList(int type)
        {
            return DataTableToList(dal.GetAllChildList(type).Tables[0]);
        }
        /// <summary>
        /// 获得拥有部长权限的用户列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetMinisterList(Guid userCode)
        {
            return DataTableToList(dal.GetMinisterList(userCode).Tables[0]); ;
        }
        /// <summary>
        /// 根据用户Guid，获取用户所有岗位集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUserPostsByUser(Guid userCode)
        {
            DataSet ds = dal.GetUserPostsByUser(userCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.SysManager.C_Userinfo> modelList = new List<CommonService.Model.SysManager.C_Userinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.SysManager.C_Userinfo model;
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
        /// 根据组织机构Guid和岗位Guid，获取所有用户
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPost(Guid? orgCode, Guid? postCode, string userinfoName)
        {
            Guid? newOrgCode = null;
            Guid? newPostCode = null;

            if (!orgCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                newOrgCode = orgCode;
            }
            if (!postCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                newPostCode = postCode;
            }

            return DataTableToList(dal.GetUsersByOrgAndPost(newOrgCode, newPostCode, userinfoName).Tables[0]);
        }
        //获取所有用户
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPostAll(List<Guid> orgCode, Guid? postCode, string userinfoName, string regionCodes)
        {

            Guid? newPostCode = null;


            if (!postCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                newPostCode = postCode;
            }

            return DataTableToList(dal.GetUsersByOrgAndPostAll(orgCode, newPostCode, userinfoName, regionCodes).Tables[0]);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid和主办律师，获取所有用户
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPostAndLycode(Guid? orgCode, Guid? postCode, Guid? lawyerCode, string userinfoName, string regioncodes)
        {
            Guid? newOrgCode = null;
            Guid? newPostCode = null;
            Guid? newLawyerCode = null;
            if (!orgCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                newOrgCode = orgCode;
            }
            if (!postCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                newPostCode = postCode;
            }
            if (!lawyerCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                newLawyerCode = lawyerCode;
            }
            return DataTableToList(dal.GetUsersByOrgAndPostAndLycode(newOrgCode, newPostCode, newLawyerCode, userinfoName, regioncodes).Tables[0]);

        }
        /// <summary>
        /// 根据流程Guid和岗位Guid，获取所有用户
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByFlowAndPost(Guid flowCode, Guid postCode, string C_Userinfo_name, string fkCode, string type, string regionCodes)
        {
            Guid? newPostCode = null;
            List<CommonService.Model.SysManager.C_Userinfo> userinfos = new List<Model.SysManager.C_Userinfo>();

            newPostCode = postCode;
            userinfos = DataTableToList(dal.GetUsersByFlowAndPost(flowCode, newPostCode, C_Userinfo_name, regionCodes).Tables[0]);

            #region
            //CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFloeDal.GetModel(new Guid(businessFlowCode));
            List<string> courts = new List<string>();
            ArrayList courtArraylist = new ArrayList();//法院集合
            ArrayList userinfoArraylist = new ArrayList();//律师集合
            if (Convert.ToInt32(type) == 1)
            {//案件
                CommonService.Model.CaseManager.B_Case bcase = caseDal.GetModel(new Guid(fkCode));
                courts.Add(bcase.B_Case_courtFirst.ToString());
                courts.Add(bcase.B_Case_courtSecond.ToString());
                courts.Add(bcase.B_Case_courtExec.ToString());
                courts.Add(bcase.B_Case_Trial.ToString());
            }
            //}else
            //{//商机
            //    CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDal.GetModel(new Guid(fkCode));
            //    courts.Add(businessChance.B_BusinessChance_courtFirst.ToString());
            //    courts.Add(businessChance.B_BusinessChance_courtSecond.ToString());
            //    courts.Add(businessChance.B_BusinessChance_courtExec.ToString());
            //}
            foreach (string court in courts)
            {
                if (court != "")
                {
                    if (!courtArraylist.Contains(court))
                    {
                        courtArraylist.Add(court);
                        List<CommonService.Model.C_Court_Lawyer> courtLawyers = courtlawyerBll.GetListByCourt(new Guid(court));
                        if (courtLawyers != null)
                        {
                            foreach (CommonService.Model.C_Court_Lawyer courtLawyer in courtLawyers)
                            {
                                CommonService.Model.SysManager.C_Userinfo userinfo = dal.GetModelByCode(courtLawyer.C_Lawyer.Value);
                                userinfo.C_Userinfo_post_name = "法院律师";
                                if (!userinfoArraylist.Contains(userinfo.C_Userinfo_code))
                                {
                                    userinfoArraylist.Add(userinfo.C_Userinfo_code);
                                    userinfos.Add(userinfo);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //if (!postCode.ToString().ToLower().Equals(Guid.Empty.ToString().ToLower()))
            //{
            //    newPostCode = postCode;
            //    userinfos = DataTableToList(dal.GetUsersByFlowAndPost(flowCode, newPostCode, C_Userinfo_name, regionCodes).Tables[0]);
            //}
            //else
            //{
            //    #region
            //    //CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFloeDal.GetModel(new Guid(businessFlowCode));
            //    List<string> courts = new List<string>();
            //    ArrayList courtArraylist = new ArrayList();//法院集合
            //    ArrayList userinfoArraylist = new ArrayList();//律师集合
            //    if (Convert.ToInt32(type) == 1)
            //    {//案件
            //        CommonService.Model.CaseManager.B_Case bcase = caseDal.GetModel(new Guid(fkCode));
            //        courts.Add(bcase.B_Case_courtFirst.ToString());
            //        courts.Add(bcase.B_Case_courtSecond.ToString());
            //        courts.Add(bcase.B_Case_courtExec.ToString());
            //        courts.Add(bcase.B_Case_Trial.ToString());
            //    }
            //    //}else
            //    //{//商机
            //    //    CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDal.GetModel(new Guid(fkCode));
            //    //    courts.Add(businessChance.B_BusinessChance_courtFirst.ToString());
            //    //    courts.Add(businessChance.B_BusinessChance_courtSecond.ToString());
            //    //    courts.Add(businessChance.B_BusinessChance_courtExec.ToString());
            //    //}
            //    foreach (string court in courts)
            //    {
            //        if (court != "")
            //        {
            //            if (!courtArraylist.Contains(court))
            //            {
            //                courtArraylist.Add(court);
            //                List<CommonService.Model.C_Court_Lawyer> courtLawyers = courtlawyerBll.GetListByCourt(new Guid(court));
            //                if (courtLawyers != null)
            //                {
            //                    foreach (CommonService.Model.C_Court_Lawyer courtLawyer in courtLawyers)
            //                    {
            //                        CommonService.Model.SysManager.C_Userinfo userinfo = dal.GetModelByCode(courtLawyer.C_Lawyer.Value);
            //                        userinfo.C_Userinfo_post_name = "法院律师";
            //                        if (!userinfoArraylist.Contains(userinfo.C_Userinfo_code))
            //                        {
            //                            userinfoArraylist.Add(userinfo.C_Userinfo_code);
            //                            userinfos.Add(userinfo);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    #endregion
            //}

            return userinfos;
        }

        /// <summary>
        /// 通过案件Guid，获取关联权限用户集合
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetPowerUsersByCase(Guid caseCode)
        {
            return DataTableToList(dal.GetPowerUsersByCase(caseCode).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.SysManager.C_Userinfo model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.SysManager.C_Userinfo> GetListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(user, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取用户数据列表
        /// </summary>
        public int GetUserListRecordCount(Model.SysManager.C_Userinfo model)
        {
            return dal.GetUserListRecordCount(model);
        }

        /// <summary>
        /// 分页获取用户数据列表
        /// </summary>
        public List<Model.SysManager.C_Userinfo> GetUserListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetUserListByPage(user, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 处理岗位分配事件
        /// </summary>
        /// <param name="post_codeItem"></param>
        /// <param name="orgCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public bool UserDistributionPost(string post_codeItem, string orgCode, string userCode)
        {
            bool isSuccess = true;
            string[] post_codes = null;
            if (!string.IsNullOrEmpty(post_codeItem))
                post_codes = post_codeItem.Split(',');
            Guid Userinfo_Code = Guid.Empty;//用户Guid
            Guid OrgInfo_Code = Guid.Empty;//用户Guid
            //根据用户code和组织机构code查找该用户在该组织机构已经存在的全部岗位信息
            if ((!Userinfo_Code.Equals("{userCode}")) && !OrgInfo_Code.Equals("{orgCode}"))
            {
                Userinfo_Code = new Guid(userCode);
                OrgInfo_Code = new Guid(orgCode);
            }
            //根据用户code组织机构code和岗位信息来向表中修改添加数据
            for (int i = 0; i < post_codes.Length; i++)
            {
                Guid Postinfo_Code = new Guid(post_codes[i]);
                //先查询表中是否存在该条信息

                if (this.GetUsersByOrgAndPostChirld(OrgInfo_Code, Postinfo_Code, Userinfo_Code).Count < 1)//不存在
                {
                    CommonService.Model.SysManager.C_Userinfo userInfo = this.GetUserinfoByCode(Userinfo_Code);
                    //CommonService.Model.SysManager.C_Post postInfo = _postWCF.GetListWhere(" C_Post_code='" + Postinfo_Code + "'")[0];
                    CommonService.Model.SysManager.C_Post postInfo = bll_post.GetLinkRolesModel(Postinfo_Code);//得到岗位的
                    CommonService.Model.SysManager.C_Organization organization = orgDal.GetModel(OrgInfo_Code);//得到组织架构的
                    if (postInfo.C_Post_group != null)
                    {
                        int? c_Roles_id = bll_group.GetModel(postInfo.C_Post_group.Value).C_Roles_id;
                        userInfo.C_Userinfo_roleID = c_Roles_id;
                    }
                    userInfo.C_Userinfo_Organization = OrgInfo_Code;
                    userInfo.C_Userinfo_post = Postinfo_Code;
                    userInfo.C_Userinfo_isDelete = false;
                    userInfo.C_Userinfo_parent = Userinfo_Code;
                    userInfo.C_Userinfo_createTime = DateTime.Now;
                    userInfo.C_Userinfo_code = Guid.NewGuid();
                    userInfo.C_Userinfo_roleID = postInfo.C_Post_Roles_id;
                    if (!(this.Add(userInfo) > 0))
                        isSuccess = false;

                    //添加用户关联区域
                    CommonService.Model.SysManager.C_Userinfo_region userinfoRegion = new CommonService.Model.SysManager.C_Userinfo_region();
                    userinfoRegion.C_Region_code = organization.C_Organization_Area;
                    userinfoRegion.C_Userinfo_code = userInfo.C_Userinfo_code;
                    userinfoRegionDal.Add(userinfoRegion);
                }
            }
            int flag = 0;
            List<CommonService.Model.SysManager.C_Userinfo> UserInfosp = this.GetUsersByOrgAndPostChirld(null, null, Userinfo_Code);
            foreach (CommonService.Model.SysManager.C_Userinfo UserInfo in UserInfosp)
            {
                if (UserInfo.C_Userinfo_isDefault)
                {
                    flag++;
                }
            }
            if (flag == 0)
            {
                CommonService.Model.SysManager.C_Userinfo userInfos = this.GetUsersByOrgAndPostChirld(OrgInfo_Code, null, Userinfo_Code)[0];

                userInfos.C_Userinfo_isDefault = true;
                if (!this.Update(userInfos))
                    isSuccess = false;
            }
            return isSuccess;

        }

        /// <summary>
        /// 人员分配岗位
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCodes">岗位Guids(多个岗位标识，逗号隔开)</param>
        /// <returns></returns>
        public bool PersonDistributionPost(string orgCode, string userCode, string postCodes, Guid thisUserCode)
        {
            bool isSuccess = false;

            /*
             * author:hety
             * date:2016-01-21
             * description:人员分配部门岗位业务(按业务顺序号，逐次处理)
             * (1)、以部门，人员，岗位为维度检查表中是否有相关记录，如果存在的话，不可以重复添加
             * (2)、在部门，人员，岗位关联表中插入数据
             * (3)、在部门，人员，岗位，区域中间表中，默认插入部门所属区域的数据
             * (4)、在部门，人员，岗位，角色中间表，默认插入数据。插入条件：岗位所属分组关联角色
             **/

            int operateCount = 0;
            Guid _orgCode = new Guid(orgCode);
            Guid _userCode = new Guid(userCode);
            string[] posts = postCodes.Split(',');
            DateTime now = DateTime.Now;

            for (int i = 0; i < posts.Length; i++)
            {
                Guid _postCode = new Guid(posts[i]);

                #region 处理业务(1)
                if (orgPostUserDAL.Exists(_orgCode, _userCode, _postCode))
                {
                    continue;
                }
                #endregion

                #region 处理业务(2)
                CommonService.Model.SysManager.C_Organization_post_user orgPostUser = new Model.SysManager.C_Organization_post_user();
                orgPostUser.C_Organization_code = _orgCode;
                orgPostUser.C_User_code = _userCode;
                orgPostUser.C_Post_code = _postCode;
                orgPostUser.C_Organization_post_user_isDelete = false;
                orgPostUser.C_Organization_post_user_creator = thisUserCode;
                orgPostUser.C_Organization_post_user_createTime = now;

                orgPostUserDAL.Add(orgPostUser);

                #endregion

                #region 处理业务(3)
                //获取组织机构实体
                CommonService.Model.SysManager.C_Organization org = orgDal.GetModel(_orgCode);

                CommonService.Model.SysManager.C_Organization_post_user_region orgPostUserRegion = new Model.SysManager.C_Organization_post_user_region();
                orgPostUserRegion.C_Organization_code = _orgCode;
                orgPostUserRegion.C_User_code = _userCode;
                orgPostUserRegion.C_Post_code = _postCode;
                if (org != null)
                {
                    orgPostUserRegion.C_region_code = org.C_Organization_Area;
                }
                orgPostUserRegion.C_Organization_post_user_region_isDelete = false;
                orgPostUserRegion.C_Organization_post_user_region_creator = thisUserCode;
                orgPostUserRegion.C_Organization_post_user_region_createTime = now;

                orgPostUserRegionDAL.Add(orgPostUserRegion);


                #endregion

                #region 处理业务(4)

                //默认角色Id
                int? roleId = null;

                //获取岗位
                CommonService.Model.SysManager.C_Post post = postDAL.GetModelByPostCode(_postCode);
                if (post != null)
                {
                    if (post.C_Post_group != null)
                    {
                        //获取岗位组
                        CommonService.Model.SysManager.C_Group group = groupDAL.GetModel(post.C_Post_group.Value);
                        if (group != null)
                        {
                            roleId = group.C_Roles_id;
                        }
                    }
                }

                CommonService.Model.SysManager.C_Organization_post_user_role orgPostUserRole = new Model.SysManager.C_Organization_post_user_role();
                orgPostUserRole.C_Organization_code = _orgCode;
                orgPostUserRole.C_User_code = _userCode;
                orgPostUserRole.C_Post_code = _postCode;
                orgPostUserRole.C_Role_id = roleId;
                orgPostUserRole.C_Organization_post_user_role_isDelete = false;
                orgPostUserRole.C_Organization_post_user_role_creator = thisUserCode;
                orgPostUserRole.C_Organization_post_user_role_createTime = now;

                orgPostUserRoleDAL.Add(orgPostUserRole);

                #endregion

                operateCount++;
            }

            if (operateCount > 0)
            {
                isSuccess = true;
            }

            return isSuccess;
        }

        /// <summary>
        /// 根据用户组织架构岗位删除关联岗位信息
        /// </summary>
        /// <param name="orgCode">组织架构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public bool DeletePostByUserCodeAndOrgCode(Guid? orgCode, Guid? postCode, Guid? userCode)
        {
            //return dal.DeletePostByUserCodeAndOrgCode(orgCode, postCode, userCode);
            bool isSussess = false;
            CommonService.Model.SysManager.C_Userinfo user = dal.GetChildrenUser(userCode.Value, orgCode.Value, postCode.Value);

            if (user != null)
            {
                isSussess = this.DeleteChildren(user.C_Userinfo_code.Value);
            }

            return isSussess;
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="orgUserPostRelatedId">组织机构-用户-岗位关联Id</param>  
        /// <returns></returns>       
        public bool DeletePost(int orgUserPostRelatedId)
        {
            bool isSuccess = false;
            //获取组织机构-人员-岗位关联实体
            CommonService.Model.SysManager.C_Organization_post_user orgUserPost = orgPostUserDAL.GetModel(orgUserPostRelatedId);
            if (orgUserPost == null)
                return isSuccess;

            Guid orgCode = orgUserPost.C_Organization_code.Value;
            Guid userCode = orgUserPost.C_User_code.Value;
            Guid postCode = orgUserPost.C_Post_code.Value;

            /*
             * 删除岗位业务逻辑
             * (1)、以组织机构、用户、岗位为维度，删除组织机构-用户-岗位关联表数据
             * (2)、以组织机构、用户、岗位为维度，删除组织机构-用户-岗位-区域关联表数据
             * (3)、以组织机构、用户、岗位为维度，删除组织机构-用户-岗位-角色关联表数据
             * 
             **/

            //处理业务(1)
            isSuccess = orgPostUserDAL.Delete(orgCode, userCode, postCode);
            //处理业务(2)
            orgPostUserRegionDAL.Delete(orgCode, userCode, postCode);
            //处理业务(3)
            orgPostUserRoleDAL.Delete(orgCode, userCode, postCode);

            return isSuccess;
        }

        /// <summary>
        /// 重新设置组织机构-人员-岗位-区域关系，组织机构-人员-岗位-角色关系
        /// </summary>
        /// <param name="orgUserPostRelatedId">组织机构-用户-岗位关联Id</param>
        /// <param name="areaCodes">区域串</param>
        /// <param name="roleId">角色Id</param>
        /// <param name="thisUserCode">当前操作用户Guid</param>
        /// <returns></returns>
        public bool RelatePostAreaRoles(int orgUserPostRelatedId, string areaCodes, int roleId, Guid thisUserCode)
        {
            bool isSuccess = true;
            DateTime now = DateTime.Now;

            //获取组织机构-人员-岗位关联实体
            CommonService.Model.SysManager.C_Organization_post_user orgUserPost = orgPostUserDAL.GetModel(orgUserPostRelatedId);
            if (orgUserPost == null)
                return isSuccess;

            Guid orgCode = orgUserPost.C_Organization_code.Value;//关联组织机构Guid
            Guid userCode = orgUserPost.C_User_code.Value;//关联用户Guid
            Guid postCode = orgUserPost.C_Post_code.Value;//关联岗位Guid

            #region 关联角色(如果组织机构-人员-岗位，三维度中存在此角色数据，则不做任何处理；如果不存在，则重新插入关联)(目前按这三个维度，只可以关联一个角色处理)
            List<CommonService.Model.SysManager.C_Organization_post_user_role> OrgUserPostRoles = orgUserPostRoleBLL.GetOrgUserPostRoles(orgCode, userCode, postCode);
            if (OrgUserPostRoles.Find(p => p.C_Role_id == roleId) == null)
            {
                //不存在关联，则先删除原有关联，再插入新的关联
                //删除
                orgPostUserRoleDAL.Delete(orgCode, userCode, postCode);
                //插入
                CommonService.Model.SysManager.C_Organization_post_user_role orgPostUserRole = new Model.SysManager.C_Organization_post_user_role();
                orgPostUserRole.C_Organization_code = orgCode;
                orgPostUserRole.C_User_code = userCode;
                orgPostUserRole.C_Post_code = postCode;
                orgPostUserRole.C_Role_id = roleId;
                orgPostUserRole.C_Organization_post_user_role_isDelete = false;
                orgPostUserRole.C_Organization_post_user_role_creator = thisUserCode;
                orgPostUserRole.C_Organization_post_user_role_createTime = now;

                orgPostUserRoleDAL.Add(orgPostUserRole);
            }
            #endregion

            #region 关联区域(如果组织机构-人员-岗位，三维度中存在此区域数据，则不做任何处理；如果不存在，则重新插入关联)(注意考虑需要删除的关联)
            string[] areaGroup = areaCodes.Split(',');
            List<CommonService.Model.SysManager.C_Organization_post_user_region> OrgUserPostRegions = orgUserPostRegionBLL.GetOrgUserPostRegions(orgCode, userCode, postCode);

            #region 处理需要删除的关联
            ArrayList needRemoveOrgPostUserRegionIdArray = new ArrayList();//需要删除的关联集合
            bool isNeedRemove = true;//是否需要移除关联
            foreach (CommonService.Model.SysManager.C_Organization_post_user_region orgUserPostRegion in OrgUserPostRegions)
            {
                isNeedRemove = true;
                for (int i = 0; i < areaGroup.Length; i++)
                {
                    if (orgUserPostRegion.C_region_code == new Guid(areaGroup[i]))
                    {
                        isNeedRemove = false;
                        break;
                    }
                }
                if (isNeedRemove)
                {//需要移除
                    needRemoveOrgPostUserRegionIdArray.Add(orgUserPostRegion.C_Organization_post_user_region_id);
                }
            }
            for (int i = 0; i < needRemoveOrgPostUserRegionIdArray.Count; i++)
            {
                orgPostUserRegionDAL.Delete(Convert.ToInt32(needRemoveOrgPostUserRegionIdArray[i]));
            }
            #endregion

            #region 处理新插入的关联(已存在的关联，不做任何处理)
            for (int i = 0; i < areaGroup.Length; i++)
            {
                if (OrgUserPostRegions.Find(p => p.C_region_code == new Guid(areaGroup[i])) == null)
                {
                    CommonService.Model.SysManager.C_Organization_post_user_region orgPostUserRegion = new Model.SysManager.C_Organization_post_user_region();
                    orgPostUserRegion.C_Organization_code = orgCode;
                    orgPostUserRegion.C_User_code = userCode;
                    orgPostUserRegion.C_Post_code = postCode;
                    orgPostUserRegion.C_region_code = new Guid(areaGroup[i]);
                    orgPostUserRegion.C_Organization_post_user_region_isDelete = false;
                    orgPostUserRegion.C_Organization_post_user_region_creator = thisUserCode;
                    orgPostUserRegion.C_Organization_post_user_region_createTime = now;

                    orgPostUserRegionDAL.Add(orgPostUserRegion);
                }
            }
            #endregion

            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 根据法院Guid获取关联律师信息
        /// </summary>
        /// <param name="courtCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetListByCourtLawyerCourtCode(Guid courtCode)
        {
            return DataTableToList(dal.GetListByCourtLawyerCourtCode(courtCode).Tables[0]);
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="userinfo_code"></param>
        /// <returns></returns>
        public bool ModifyUserStatus(Guid userinfo_code, int? userinfoState)
        {
            dal.ChangeUserinfoState(userinfo_code, Convert.ToInt32(userinfoState));
            List<CommonService.Model.SysManager.C_Userinfo> userinfoList = GetAllChildList(userinfo_code);
            foreach (CommonService.Model.SysManager.C_Userinfo userinfoItem in userinfoList)
            {
                userinfoItem.C_Userinfo_state = userinfoState;
                dal.ChangeUserinfoState(userinfoItem.C_Userinfo_code.Value, userinfoItem.C_Userinfo_state.Value);
            }
            return true;
        }
        /// <summary>
        /// 获取首席数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetFirstUsersList()
        {
            return DataTableToList(dal.GetFirstUsersList().Tables[0]);
        }
        /// <summary>
        /// 获得首席或者部长列表
        /// </summary>
        /// <param name="type">1.首席，2.部长</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetFirstOrMiniterList(int type)
        {
            return DataTableToList(dal.GetFirstOrMiniterList(type).Tables[0]);
        }
        /// <summary>
        /// 获得首席分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetFirstListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetFirstListByPage(user, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 获取首席记录总数
        /// </summary>
        public int GetFirsrRecordCount(Model.SysManager.C_Userinfo user)
        {
            return dal.GetFirsrRecordCount(user);
        }

        #region 用户调整部门
        /// <summary>
        /// 用户调整部门
        /// </summary>
        /// <param name="Organization_post_user"></param>
        /// <param name="organizationCode">组织架构Guid</param>
        /// <returns></returns>
        public bool SectorAdjustment(string Organization_post_user, Guid organizationCode)
        {
            bool isSuccess = false;
            string[] Opus = Organization_post_user.Split(',');
            //组织架构Guid
            Guid orgaCode = new Guid(Opus[0]);
            //岗位Guid
            Guid postCode = new Guid(Opus[1]);
            //用户Guid
            Guid userCode = new Guid(Opus[2]);

            CommonService.Model.SysManager.C_Organization_post_user organization_post_user = orgPostUserDAL.GetModelByOrgAndPostAndUser(orgaCode, postCode, userCode);
            if (organization_post_user!=null)
            {
                organization_post_user.C_Organization_code = organizationCode;
                isSuccess = orgPostUserDAL.Update(organization_post_user);
            }
            CommonService.Model.SysManager.C_Organization_post_user_region organization_post_user_region = orgPostUserRegionDAL.GetModelByOrgAndPostAndUser(orgaCode, postCode, userCode);
            if (organization_post_user_region != null)
            {
                organization_post_user_region.C_Organization_code = organizationCode;
                isSuccess = orgPostUserRegionDAL.Update(organization_post_user_region);
            }
            CommonService.Model.SysManager.C_Organization_post_user_role organization_post_user_role = orgPostUserRoleDAL.GetModelByOrgAndPostAndUser(orgaCode, postCode, userCode);
            if (organization_post_user_role != null)
            {
                organization_post_user_role.C_Organization_code = organizationCode;
                isSuccess = orgPostUserRoleDAL.Update(organization_post_user_role);
            }
            if (isSuccess)
            {
                if (postCode.ToString() == "c5e154c7-d8fe-46d4-9fa6-07084403a88e")
                {//岗位为专业顾问--将该专业顾问所负责的客户、商机、案件的部长以及首席，更改成新调整的组织架构里的部长、首席
                    BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                    Model.SysManager.C_Userinfo buzhang = dal.GetBuZhangByUserCode(userCode); //直接找部长
                    Model.SysManager.C_ChiefExpert_Minister ccm = new Model.SysManager.C_ChiefExpert_Minister();
                    if (buzhang != null)
                    {
                        ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                    }
                    #region 客户处理
                    List<CommonService.Model.C_Customer> customers = GetCusListByConsultant(userCode);
                    if (customers.Count != 0)
                    {
                        foreach (CommonService.Model.C_Customer item in customers)
                        {
                            item.C_Customer_responsiblePerson = buzhang.C_Userinfo_code;
                            item.C_Customer_chiefResponsiblePerson = ccm.C_ChiefExpert_Code;
                            customerDal.Update(item);
                        }
                    }
                    #endregion

                    #region 商机处理
                    List<CommonService.Model.BusinessChanceManager.B_BusinessChance> businessChances = GetBusinessChanceListByConsultant(userCode);
                    if (businessChances.Count != 0)
                    {
                        foreach (CommonService.Model.BusinessChanceManager.B_BusinessChance item in businessChances)
                        {
                            item.B_BusinessChance_person = buzhang.C_Userinfo_code;
                            item.B_BusinessChance_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code;
                            businessChanceDal.Update(item);
                        }
                    }
                    #endregion

                    #region 案件处理
                    List<CommonService.Model.CaseManager.B_Case> cases = GetCaseListByConsultant(userCode);
                    if(cases.Count != 0)
                    {
                        foreach(CommonService.Model.CaseManager.B_Case item in cases)
                        {
                            item.B_Case_person = buzhang.C_Userinfo_code;
                            item.B_Case_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code;
                            caseDal.Update(item);
                        }
                    }
                    #endregion
                }
            }
            return isSuccess;
        }

        public List<CommonService.Model.CaseManager.B_Case> GetCaseListByConsultant(Guid consultantCode)
        {
            List<CommonService.Model.CaseManager.B_Case> modelList = new List<CommonService.Model.CaseManager.B_Case>();
            DataSet CaseDs = caseDal.GetListByConsultant(consultantCode);
            int rowsCount = CaseDs.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = caseDal.DataRowToModel(CaseDs.Tables[0].Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public List<CommonService.Model.C_Customer> GetCusListByConsultant(Guid consultantCode)
        {
            List<CommonService.Model.C_Customer> modelList = new List<CommonService.Model.C_Customer>();
            DataSet CusDs = customerDal.GetListByConsultant(consultantCode);
            int rowsCount = CusDs.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Customer model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = customerDal.DataRowToModel(CusDs.Tables[0].Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance> GetBusinessChanceListByConsultant(Guid consultantCode)
        {
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance> modelList = new List<CommonService.Model.BusinessChanceManager.B_BusinessChance>();
            DataSet BusinessChanceDs = businessChanceDal.GetListByConsultant(consultantCode);
            int rowsCount = BusinessChanceDs.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.BusinessChanceManager.B_BusinessChance model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = businessChanceDal.DataRowToModel(BusinessChanceDs.Tables[0].Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        #endregion

        #endregion  BasicMethod
        #region  ExtensionMethod



        /// <summary>
        /// 根据用户登陆名获取主用户
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <returns>用户实体</returns>
        public Model.SysManager.C_Userinfo GetUserinfoByLoginID(string loginID)
        {
            return dal.GetUserinfoByLoginID(loginID);
        }


        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="password">密码</param>
        /// <returns>是否登陆成功</returns>
        public bool Login(string loginid, string password, out Model.SysManager.C_Userinfo user)
        {
            C_Userinfo userBLL = new C_Userinfo();
            Model.SysManager.C_Userinfo userinfo = userBLL.GetModelByLoginName(loginid);
            if (userinfo != null && userinfo.C_Userinfo_password == password)
            {
                user = userinfo;
                return true;
            }
            else
            {
                user = null;
                return false;
            }
        }

        /// <summary>
        /// 根据用户编码获取用户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <returns>用户实体</returns>
        public Model.SysManager.C_Userinfo GetUserinfoByCode(Guid userinfo_code)
        {
            return dal.GetUserinfoByCode(userinfo_code);
        }

        /// <summary>
        /// 根据父级用户编码和角色ID获取子级用户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        public Model.SysManager.C_Userinfo GetUserinfoByCodeAndRole(Guid userinfo_code, int roleID)
        {
            return dal.GetUserinfoByCodeAndRole(userinfo_code, roleID);
        }

        /// <summary>
        /// 根据组织架构编码获取用户列表
        /// </summary>
        /// <param name="organizationID">组织架构编码</param>
        /// <returns>用户列表</returns>
        public List<Model.SysManager.C_Userinfo> GetUserinfosByOrganizationID(Guid organizationID)
        {
            DataSet ds = dal.GetUserinfosByOrganizationID(organizationID);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 启用/禁用账户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <param name="state">状态：1启用2禁用</param>
        /// <returns>是否成功</returns>
        public bool ChangeUserinfoState(Guid userinfo_code, int state)
        {
            return dal.ChangeUserinfoState(userinfo_code, state);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid和用户Guid，获取用户实体
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPost(Guid? orgCode, Guid? postCode, Guid? userCode)
        {
            return DataTableToList(dal.GetUsersByOrgAndPost(orgCode, postCode, userCode).Tables[0]);
        }
        /// <summary>
        /// 根据用户Guid，获取用户实体
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUsersInfoAndOrgAndRoleByUsercode(Guid? userCode)
        {
            return DataTableToList(dal.GetUsersInfoAndOrgAndRoleByUsercode(userCode).Tables[0]);
        }
        /// <summary>
        /// 根据根用户Guid，获取子级用户实体列表
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetChildUsersInfoByUsercode(Guid userCode)
        {
            return DataTableToList(dal.GetChildUsersInfoByUsercode(userCode).Tables[0]);
        }
        /// <summary>
        /// 获取所有子用户
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetAllChildList(Guid userCode)
        {
            return DataTableToList(dal.GetAllChildList(userCode).Tables[0]);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid和用户Guid，获取用户实体
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPostChirld(Guid? orgCode, Guid? postCode, Guid? userCode)
        {
            return DataTableToList(dal.GetUsersByOrgAndPostChirld(orgCode, postCode, userCode).Tables[0]);
        }

        /// <summary>
        /// 根据用户编码获取其所属组织架构名称
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public string GetDeptNameByUserCode(Guid userCode)
        {
            C_Organization organBLL = new C_Organization();
            Model.SysManager.C_Userinfo user = GetModelByUserCode(userCode);
            Model.SysManager.C_Organization organ = organBLL.GetModel(user.C_Userinfo_Organization.Value);
            if (organ == null)
            {
                return "";
            }
            else
            {
                return organ.C_Organization_name;
            }
        }

        /// <summary>
        /// 根据一个用户获取他所在部门的部长助理
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public Model.SysManager.C_Userinfo GetZhuLiByUserCode(Guid userCode)
        {
            return dal.GetZhuLiByUserCode(userCode);
        }

        /// <summary>
        /// 根据一个用户获取他所在部门的部长
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public Model.SysManager.C_Userinfo GetBuZhangByUserCode(Guid userCode)
        {
            return dal.GetBuZhangByUserCode(userCode);
        }
        #endregion  ExtensionMethod

        #region App专用
        /// <summary>
        /// App端登陆
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码（非加密）</param>
        /// <returns>登陆后的默认岗位用户实体</returns>
        public List<Model.SysManager.C_Userinfo> AppLogin(string name, string password, string ip)
        {
            password = Encryption.GetMd5(password);

            Model.SysManager.C_Userinfo mainUser = new Model.SysManager.C_Userinfo(); //用于记录主用户信息

            List<Model.SysManager.C_Userinfo> resultUser = new List<Model.SysManager.C_Userinfo>(); //用于记录返回的用户信息（默认子用户）

            bool isLogin = Login(name, password, out mainUser); //登陆是否成功

            if (isLogin) //登陆成功
            {
                resultUser = DataTableToList(dal.GetParentAndChildren(mainUser.C_Userinfo_code.Value).Tables[0]); //获取主用户及子用户
                if (resultUser.Count > 1)
                {
                    SysManager.C_Log logBLL = new C_Log();
                     
                    CommonService.Model.SysManager.C_Log clogmodel = new CommonService.Model.SysManager.C_Log();
                    clogmodel.C_Userinfo_name = mainUser.C_Userinfo_name;
                    clogmodel.C_Userinfo_code = mainUser.C_Userinfo_code.Value;
                    clogmodel.C_Userinfo_post = mainUser.C_Userinfo_post.ToString();
                    clogmodel.C_Log_code = Guid.NewGuid();
                    clogmodel.C_Datatime = DateTime.Now;
                    clogmodel.C_Log_Type = Convert.ToInt32(LoginTypeEnum.北斗云APP);
                    clogmodel.C_Log_ip = ip;  //取得Base64解密后的IP
                    clogmodel.C_Operate = "登陆成功";
                    logBLL.Add(clogmodel);
                }
                //if (resultUser.Count <= 0) //如果没有子用户
                //{
                //    resultUser = new Model.SysManager.C_Userinfo();
                //    resultUser.C_Userinfo_loginState = 3; //您的账户未设定默认岗位，请联系管理员处理
                //}
                //else
                //{
                //    resultUser.C_Userinfo_loginState = 1; //登陆成功
                //}
            }
            else //登陆不成功
            {
                //resultUser.C_Userinfo_loginState = 2; //用户名或密码错误
                return null;
            }

            return resultUser;
        }

        /// <summary>
        /// 根据类型查询主用户列表
        /// </summary>
        /// <param name="type">类型：1.部门 2.岗位</param>
        /// <param name="guid">类型关联GUID</param>
        /// <returns>用户列表</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> AppContactByModel(int type, Guid? guid)
        {
            if (type == 1) //根据部门查询
            {
                return DataTableToList(dal.ContactByDept(guid).Tables[0]);
            }
            else if (type == 2) //根据岗位查询
            {
                return DataTableToList(dal.ContactByPost(guid.Value).Tables[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="rootUserCode">主用户Guid</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public int AppUpdatePass(string rootUserCode, string oldPassword, string newPassword)
        {
            int isUpdateSuccess = 0;

            Guid _rootUserCode = new Guid(rootUserCode);
            string _oldPassword = Encryption.GetMd5(oldPassword);
            string _newPassword = Encryption.GetMd5(newPassword);

            //获取主用户实体对象
            CommonService.Model.SysManager.C_Userinfo userInfo = dal.GetModelByCode(_rootUserCode);
            if (userInfo == null)
                return isUpdateSuccess;
            //检查主用户数据库密码是否与用户输入旧密码一致
            if (!userInfo._c_userinfo_password.Equals(_oldPassword))
            {
                isUpdateSuccess = -1;
                return isUpdateSuccess;
            }
            //更新用户密码
            userInfo.C_Userinfo_password = _newPassword;
            this.UpdatePass(userInfo);
            isUpdateSuccess = 1;

            return isUpdateSuccess;
        }

        #endregion
    }
}

