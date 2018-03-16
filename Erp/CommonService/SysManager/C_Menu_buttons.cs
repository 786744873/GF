using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Menu_buttons”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Menu_buttons.svc 或 C_Menu_buttons.svc.cs，然后开始调试。
    public class C_Menu_buttons : IC_Menu_buttons
    {
        CommonService.BLL.SysManager.C_Menu_buttons cmbBLL = new CommonService.BLL.SysManager.C_Menu_buttons();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return cmbBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Menu_buttons_id)
        {
            return cmbBLL.Exists(C_Menu_buttons_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Menu_buttons model)
        {
            return cmbBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.SysManager.C_Menu_buttons model)
        {
            return cmbBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Menu_buttons_id)
        {
            return cmbBLL.Delete(C_Menu_buttons_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Menu_buttons GetModel(int C_Menu_buttons_id)
        {
            return cmbBLL.GetModel(C_Menu_buttons_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SysManager.C_Menu_buttons> GetListByMenuId(int menuId)
        {
            return cmbBLL.GetListByMenuId(menuId);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.SysManager.C_Menu_buttons model)
        {
            return cmbBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.SysManager.C_Menu_buttons> GetListByPage(CommonService.Model.SysManager.C_Menu_buttons model, string orderby, int startIndex, int endIndex)
        {
            return cmbBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
