using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Userinfo_area”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Userinfo_area.svc 或 C_Userinfo_area.svc.cs，然后开始调试。
    public class C_Userinfo_area : IC_Userinfo_area
    {
        CommonService.BLL.SysManager.C_Userinfo_region cuaBLL = new CommonService.BLL.SysManager.C_Userinfo_region();
        /// <summary>
        /// 查找是否存在一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exits(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            return cuaBLL.Exits(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            return cuaBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            return cuaBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Role_id"></param>
        /// <returns></returns>
        public bool Delete(Guid userCode, Guid Region_code)
        {
            return cuaBLL.Delete(userCode, Region_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Userinfo_region model)
        {
            return cuaBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Userinfo_region> GetListByPage(CommonService.Model.SysManager.C_Userinfo_region model, string orderby, int startIndex, int endIndex)
        {
            return cuaBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据用户编码删除所有的用户和区域之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>是否成功</returns>
        public bool DeleteUserinfoAreaByUserCode(Guid userCode)
        {
            return cuaBLL.DeleteUserinfoAreaByUserCode(userCode);
        }

        /// <summary>
        /// 批量添加同一用户与多个区域之间的关系
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="areaIDs">区域ID集合</param>
        //public void AddUserinfoAreas(Guid userCode, List<int> areaIDs)
        //{
        //    cuaBLL.AddUserinfoAreas(userCode, areaIDs);
        //}

        /// <summary>
        /// 根据用户获得关联数据
        /// </summary>
        /// <param name="userCode">用户GUID</param>
        /// <returns></returns>
        public List<Model.SysManager.C_Userinfo_region> GetListByUserinfoCode(Guid userCode)
        {
            return cuaBLL.GetListByUserinfoCode(userCode);
        }
    }
}
