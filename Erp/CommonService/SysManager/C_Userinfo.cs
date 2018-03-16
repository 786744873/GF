using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Userinfo”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Userinfo.svc 或 Userinfo.svc.cs，然后开始调试。
    public class C_Userinfo : IC_Userinfo
    {
        private CommonService.BLL.SysManager.C_Userinfo userBLL = new CommonService.BLL.SysManager.C_Userinfo();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return userBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Userinfo_id">用户ID</param>
        /// <returns>是否存在</returns>
        public bool Exists(int C_Userinfo_id)
        {
            return userBLL.Exists(C_Userinfo_id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Userinfo_id">用户登录名</param>
        /// <returns>是否存在</returns>
        public bool ExistsByloginID(string C_Userinfo_loginID)
        {
            return userBLL.ExistsByloginID(C_Userinfo_loginID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns>是否成功</returns>
        public int Add(CommonService.Model.SysManager.C_Userinfo model)
        {
            return userBLL.Add(model);
        }

        /// <summary>
        /// 更新一条用户信息
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns>是否成功</returns>
        public bool Update(CommonService.Model.SysManager.C_Userinfo model)
        {
            return userBLL.Update(model);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePass(CommonService.Model.SysManager.C_Userinfo model)
        {
            return userBLL.UpdatePass(model);
        }
        /// <summary>
        /// 根据用户编码删除用户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <returns>是否成功</returns>
        public bool Delete(Guid userinfo_code)
        {
            return userBLL.Delete(userinfo_code);
        }

        /// <summary>
        /// 删除子用户
        /// </summary>
        /// <param name="childrenUserCode">子用户Guid</param>
        /// <returns></returns>        
        public bool DeleteChildren(Guid childrenUserCode)
        {
            return userBLL.DeleteChildren(childrenUserCode);
        }

        /// <summary>
        /// 根据用户ID获取用户实体
        /// </summary>
        /// <param name="C_Userinfo_id">用户ID</param>
        /// <returns>用户实体</returns>
        public CommonService.Model.SysManager.C_Userinfo GetModel(int C_Userinfo_id)
        {
            return userBLL.GetModel(C_Userinfo_id);
        }

        /// <summary>
        /// 通过用户登录名，获取用户实体
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByLoginName(string loginID)
        {
            return userBLL.GetModelByLoginName(loginID);
        }

        /// <summary>
        /// 通过用户登录名和密码，获取用户实体
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <param name="password">密码</param> 
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByLoginNameAndPassword(string loginID, string password)
        {
            return userBLL.GetModelByLoginNameAndPassword(loginID, password);
        }

        /// <summary>
        /// 通过父亲Guid，获取一默认子用户
        /// </summary>
        /// <param name="parentCode">父亲Guid</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetDefaultChildUserByParentCode(Guid parentCode)
        {
            return userBLL.GetDefaultChildUserByParentCode(parentCode);
        }

        /// <summary>
        /// 根据组织机构Guid和岗位Guid，获取所有用户
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPost(Guid? orgCode, Guid? postCode, string userinfoName)
        {
            return userBLL.GetUsersByOrgAndPost(orgCode, postCode, userinfoName);
        }
        //获取所有用户
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPostAll(List<Guid> orgCode, Guid? postCode, string userinfoName, string regionCodes)
        {
            return userBLL.GetUsersByOrgAndPostAll(orgCode, postCode, userinfoName, regionCodes);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid和主办律师，获取所有用户
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetUsersByOrgAndPostAndLycode(Guid? orgCode, Guid? postCode, Guid? lawyerCode, string userinfoName, string regioncodes)
        {
            return userBLL.GetUsersByOrgAndPostAndLycode(orgCode, postCode, lawyerCode, userinfoName, regioncodes);
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
            return userBLL.RelatePostAreaRoles(orgUserPostRelatedId, areaCodes, roleId, thisUserCode);
        }

        /// <summary>
        /// 根据流程Guid和岗位Guid，获取所有用户
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUsersByFlowAndPost(Guid flowCode, Guid postCode, string C_Userinfo_name, string fkCode, string type, string regionCodes)
        {
            return userBLL.GetUsersByFlowAndPost(flowCode, postCode, C_Userinfo_name, fkCode, type, regionCodes);
        }
        /// <summary>
        /// 根据组织机构GUID获取所有的主用户
        /// </summary>
        public DataSet GetModelByOrgCode(Guid orgCode)
        {
            return userBLL.GetModelByOrgCode(orgCode);
        }
        /// <summary>
        /// 通过用户Guid，获取用户对象
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByUserCode(Guid userCode)
        {
            return userBLL.GetModelByUserCode(userCode);
        }

        /// <summary>
        /// 根据条件获取分页时的总条数
        /// </summary>
        /// <param name="model">实体条件</param>
        /// <returns>总条数</returns>
        public int GetRecordCount(CommonService.Model.SysManager.C_Userinfo model)
        {
            return userBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetModelList(string strWhere)
        {
            return userBLL.GetModelList(strWhere);
        }
        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <param name="user">用户实体条件</param>
        /// <param name="orderby">排序的列</param>
        /// <param name="startIndex">从第几条</param>
        /// <param name="endIndex">到第几条</param>
        /// <returns>用户列表</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetListByPage(CommonService.Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            return userBLL.GetListByPage(user, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取用户数据列表
        /// </summary>
        public int GetUserListRecordCount(Model.SysManager.C_Userinfo model)
        {
            return userBLL.GetUserListRecordCount(model);
        }

        /// <summary>
        /// 分页获取用户数据列表
        /// </summary>
        public List<Model.SysManager.C_Userinfo> GetUserListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            return userBLL.GetUserListByPage(user, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据用户登陆名获取主用户
        /// </summary>
        /// <param name="loginID">用户登录名</param>
        /// <returns>用户实体</returns>
        public CommonService.Model.SysManager.C_Userinfo GetUserinfoByLoginID(string loginID)
        {
            return userBLL.GetUserinfoByLoginID(loginID);
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="user">out用户实体</param>
        /// <returns>是否成功</returns>
        public bool Login(string loginid, string password, out CommonService.Model.SysManager.C_Userinfo user)
        {
            return userBLL.Login(loginid, password, out user);
        }

        /// <summary>
        /// 根据用户编码获取用户实体
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <returns>用户实体</returns>
        public CommonService.Model.SysManager.C_Userinfo GetUserinfoByCode(Guid userinfo_code)
        {
            return userBLL.GetUserinfoByCode(userinfo_code);
        }

        /// <summary>
        /// 根据父级用户编码和角色ID获取子级用户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <param name="roleID">角色ID</param>
        /// <returns>用户实体</returns>
        public CommonService.Model.SysManager.C_Userinfo GetUserinfoByCodeAndRole(Guid userinfo_code, int roleID)
        {
            return userBLL.GetUserinfoByCodeAndRole(userinfo_code, roleID);
        }

        /// <summary>
        /// 根据组织架构编码获取用户列表
        /// </summary>
        /// <param name="organizationID">组织架构编码</param>
        /// <returns>用户列表</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUserinfosByOrganizationID(Guid organizationID)
        {
            return userBLL.GetUserinfosByOrganizationID(organizationID);
        }

        /// <summary>
        /// 启用/禁用账户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <param name="state">状态：1启用2禁用（请勿传其他值进来）</param>
        /// <returns>是否成功</returns>
        public bool ChangeUserinfoState(Guid userinfo_code, int state)
        {
            return userBLL.ChangeUserinfoState(userinfo_code, state);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid和用户Guid，获取用户实体
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUsersByOrgAndPostAndUser(Guid? orgCode, Guid? postCode, Guid? userCode)
        {
            return userBLL.GetUsersByOrgAndPost(orgCode, postCode, userCode);
        }
        /// <summary>
        /// 根据用户Guid，获取用户实体
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUsersInfoAndOrgAndRoleByUsercode(Guid? userCode)
        {
            return userBLL.GetUsersInfoAndOrgAndRoleByUsercode(userCode);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid和用户Guid，获取用户实体
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUsersByOrgAndPostChirld(Guid? orgCode, Guid? postCode, Guid? userCode)
        {
            return userBLL.GetUsersByOrgAndPostChirld(orgCode, postCode, userCode);
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
            return userBLL.GetAllChildList(type);
        }

        /// <summary>
        /// 根据用户Guid，获取用户所有岗位集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetUserPostsByUser(Guid userCode)
        {
            return userBLL.GetUserPostsByUser(userCode);
        }
        /// <summary>
        /// 获得所有父级用户列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetParentList()
        {
            return userBLL.GetParentList();
        }
        /// <summary>
        /// 处理岗位分配
        /// </summary>
        /// <param name="post_codeItem"></param>
        /// <param name="orgCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public bool UserDistributionPost(string post_codeItem, string orgCode, string userCode)
        {
            return userBLL.UserDistributionPost(post_codeItem, orgCode, userCode);
        }

        /// <summary>
        /// 人员分配岗位
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="userCode"></param>
        /// <param name="postCodes"></param>
        /// <param name="thisUserCode"></param>
        /// <returns></returns>
        public bool PersonDistributionPost(string orgCode, string userCode, string postCodes, Guid thisUserCode)
        {
            return userBLL.PersonDistributionPost(orgCode, userCode, postCodes, thisUserCode);
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
            return userBLL.DeletePostByUserCodeAndOrgCode(orgCode, postCode, userCode);
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="orgUserPostRelatedId">组织机构-用户-岗位关联Id</param>  
        /// <returns></returns>       
        public bool DeletePost(int orgUserPostRelatedId)
        {
            return userBLL.DeletePost(orgUserPostRelatedId);
        }

        /// <summary>
        /// 通过案件Guid，获取关联权限用户集合
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetPowerUsersByCase(Guid caseCode)
        {
            return userBLL.GetPowerUsersByCase(caseCode);
        }

        /// <summary>
        /// 获得拥有部长权限的用户列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetMinisterList(Guid userCode)
        {
            return userBLL.GetMinisterList(userCode);
        }
        /// 根据法院Guid获取关联律师信息
        /// </summary>
        /// <param name="courtCode"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetListByCourtLawyerCourtCode(Guid courtCode)
        {
            return userBLL.GetListByCourtLawyerCourtCode(courtCode);
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="userinfo_code"></param>
        /// <returns></returns>
        public bool ModifyUserStatus(Guid userinfo_code, int? userinfoState)
        {
            return userBLL.ModifyUserStatus(userinfo_code, userinfoState);
        }

        /// <summary>
        /// 根据区域取用户
        /// </summary>
        /// <param name="regionCode"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo> GetListByRegionCode(Guid regionCode)
        {
            return userBLL.GetListByRegionCode(regionCode);
        }
        /// <summary>
        /// 获取首席数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetFirstUsersList()
        {
            return userBLL.GetFirstUsersList();
        }
        /// <summary>
        /// 获得首席或者部长列表
        /// </summary>
        /// <param name="type">1.首席，2.部长</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Userinfo> GetFirstOrMiniterList(int type)
        {
            return userBLL.GetFirstOrMiniterList(type);
        }
        /// <summary>
        /// 获得首席分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo> GetFirstListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            return userBLL.GetFirstListByPage(user, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 获取首席记录总数
        /// </summary>
        public int GetFirsrRecordCount(Model.SysManager.C_Userinfo user)
        {
            return userBLL.GetFirsrRecordCount(user);
        }

        /// <summary>
        /// 用户调整部门
        /// </summary>
        /// <param name="Organization_post_user"></param>
        /// <param name="organizationCode">组织架构Guid</param>
        /// <returns></returns>
        public bool SectorAdjustment(string Organization_post_user, Guid organizationCode)
        {
            return userBLL.SectorAdjustment(Organization_post_user, organizationCode);
        }
    }
}
