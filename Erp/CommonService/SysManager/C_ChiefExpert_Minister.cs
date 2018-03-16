using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Userinfo”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Userinfo.svc 或 Userinfo.svc.cs，然后开始调试。
    public class C_ChiefExpert_Minister : IC_ChiefExpert_Minister
    {
        private CommonService.BLL.SysManager.C_ChiefExpert_Minister bll = new CommonService.BLL.SysManager.C_ChiefExpert_Minister();
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="C_ChiefExpert_Minister_id"></param>
        /// <returns></returns>
        public bool Exists(int C_ChiefExpert_Minister_id)
        {
            return bll.Exists(C_ChiefExpert_Minister_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SysManager.C_ChiefExpert_Minister model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.SysManager.C_ChiefExpert_Minister model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="C_ChiefExpert_Minister_id">ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(Guid ChiefExpert_Code, Guid Minister_Code)
        {
            return bll.Delete(ChiefExpert_Code, Minister_Code);
        }

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.SysManager.C_ChiefExpert_Minister> C_ChiefExpert_Ministers)
        {
            return bll.OperateList(C_ChiefExpert_Ministers);
        }
        /// <summary>
        /// 根据部长guid得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_ChiefExpert_Minister GetModelByMinister(Guid C_Minister_Code)
        {
            return bll.GetModelByMinister(C_Minister_Code);
        }
    }
}
