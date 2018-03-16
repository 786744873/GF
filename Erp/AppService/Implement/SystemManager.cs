
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace AppService
{
    public class SystemManager:ISystemManager
    {
        private CommonService.BLL.SysManager.C_Userinfo userBLL = new CommonService.BLL.SysManager.C_Userinfo();
        CommonService.BLL.SysManager.C_Post bll = new CommonService.BLL.SysManager.C_Post();
        CommonService.BLL.SysManager.C_Organization oBLL = new CommonService.BLL.SysManager.C_Organization();
        CommonService.BLL.C_Region regionBLL = new CommonService.BLL.C_Region();
        /// <summary>
        /// 角色按钮业务逻辑层
        /// </summary>
        CommonService.BLL.SysManager.C_Role_button roleButtonBLL = new CommonService.BLL.SysManager.C_Role_button();
        CommonService.BLL.SysManager.C_Role_Power rolePowerBLL = new CommonService.BLL.SysManager.C_Role_Power();
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


        #region App端专用 获取部门 获得联系人

        /// <summary>
        /// App端登陆
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="ip">Base64加密后的IP</param>
        /// <returns>登陆后的默认岗位用户实体</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> AppLogin(string name, string password)
        {
            //提供方法执行的上下文环境
            OperationContext context = OperationContext.Current;
            //获取传进的消息属性
            MessageProperties properties = context.IncomingMessageProperties;
            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
           
            return  userBLL.AppLogin(name, password,endpoint.Address);
        }

        /// <summary>
        /// 获取联系人（获取所有主用户） 
        /// </summary>
        /// <returns>用户列表</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> AppGetContact()
        {
            return GetParentList();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="rootUserCode">主用户Guid</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public int UpdatePass(string rootUserCode,string oldPassword, string newPassword)
        {
            return userBLL.AppUpdatePass(rootUserCode,oldPassword, newPassword);
        }

        /// <summary>
        /// 根据类型查询主用户列表
        /// </summary>
        /// <param name="type">类型：1.部门 2.岗位</param>
        /// <param name="guid">类型关联GUID</param>
        /// <returns>用户列表</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> AppContactByModel(string type, string guid)
        {
            return userBLL.AppContactByModel(Convert.ToInt32(type), Guid.Parse(guid));
        }

        /// <summary>
        /// 根据主用户GUID获取所有子用户
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>返回所有子用户</returns>
        public List<CommonService.Model.SysManager.C_Userinfo> AppGetRote(Guid guid)
        {
            return GetUserPostsByUser(guid);
        }

        #endregion

        #region App专用 获取岗位
        /// <summary>
        /// 获取所有岗位
        /// </summary>
        /// <returns>岗位列表</returns>
        public List<CommonService.Model.SysManager.C_Post> AppGetPosition()
        {
            return bll.GetAllPosts();
        }
        #endregion



        public List<CommonService.Model.SysManager.C_Organization> AppGetDepartments()
        {
            return oBLL.AppGetDepartments();
        }

        #region 地区
        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.C_Region> GetRegion()
        {
            return regionBLL.GetAllSpecialList();
        }
        #endregion 

        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>      
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsByRoleId(string roleId)
        {
            return roleButtonBLL.GetButtonsByRoleId(int.Parse(roleId));
        }

        /// <summary>
        /// 根据用户Code，获取用户关联按钮集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.SysManager.C_Role_button> GetButtonsByUserCode(string userCode)
        {
            return roleButtonBLL.GetButtonsByUserCode(new Guid(userCode));
        }

        /// <summary>
        /// 根据角色Id，获取角色关联按钮集合
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>      
        public List<CommonService.Model.SysManager.C_Role_Power> GetRolePowers(string roleId)
        {
            return rolePowerBLL.GetRolePowers(int.Parse(roleId));
        }

        
    }
}