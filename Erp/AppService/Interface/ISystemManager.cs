using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace AppService
{
    [ServiceContract]
    public interface  ISystemManager
    {
        /// <summary>
        /// App端登陆
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="ip">Base64加密后的IP</param>
        /// <returns>登陆后的默认岗位用户实体</returns>
        [WebInvoke(UriTemplate = "AppLogin/{name}/{password}", Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Userinfo> AppLogin(string name, string password);

        /// <summary>
        /// 获取联系人（获取所有主用户）
        /// </summary>
        /// <returns>用户列表</returns>
        [WebInvoke(UriTemplate = "AppGetContact", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Userinfo> AppGetContact();

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="rootUserCode">主用户Guid</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "UpdatePass/{rootUserCode}/{oldPassword}/{newPassword}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int UpdatePass(string rootUserCode,string oldPassword,string newPassword);

        /// <summary>
        /// 根据类型查询主用户列表
        /// </summary>
        /// <param name="type">类型：1.部门 2.岗位</param>
        /// <param name="guid">类型关联GUID</param>
        /// <returns>用户列表</returns>
        [WebInvoke(UriTemplate = "AppContactByModel/{type}/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Userinfo> AppContactByModel(string type, string guid);//只改了第二个操作数

        /// <summary>
        /// 根据主用户GUID获取所有子用户
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>返回所有子用户</returns>
        [WebInvoke(UriTemplate = "AppGetRote", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Userinfo> AppGetRote(Guid guid);
        #region App专用 获取部门

        /// <summary>
        /// App端根据权限获取组织架构列表（紧获取二级）
        /// </summary>
        /// <returns>组织架构列表</returns>
        [WebInvoke(UriTemplate = "AppGetDepartments", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Organization> AppGetDepartments();
        #endregion
        #region App专用 获取岗位
        /// <summary>
        /// 获取所有岗位
        /// </summary>
        /// <returns>岗位列表</returns>
        [WebInvoke(UriTemplate = "AppGetPosition", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Post> AppGetPosition();
        #endregion

        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetRegion", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Region> GetRegion();

        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetButtonsByRoleId/{roleId}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Role_button> GetButtonsByRoleId(string roleId);

        /// <summary>
        /// 根据用户Guid，获取用户关联按钮集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetButtonsByUserCode/{userCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Role_button> GetButtonsByUserCode(string userCode);

         /// <summary>
        /// 根据角色Id，获取角色关联权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetRolePowers/{roleId}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Role_Power> GetRolePowers(string roleId);
    }
}