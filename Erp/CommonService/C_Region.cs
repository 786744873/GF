using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Region”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Region.svc 或 C_Region.svc.cs，然后开始调试。
    public class C_Region : IC_Region
    {
        CommonService.BLL.C_Region bll = new CommonService.BLL.C_Region();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Region_Id"></param>
        /// <returns></returns>
        public bool Exists(int C_Region_Id)
        {
            return bll.Exists(C_Region_Id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Region model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Region model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Region_Id"></param>
        /// <returns></returns>
        public bool Delete(Guid C_Region_code)
        {
            return bll.Delete(C_Region_code);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="C_Region_Id"></param>
        /// <returns></returns>
        public Model.C_Region GetModel(int C_Region_Id)
        {
            return bll.GetModel(C_Region_Id);
        }
        /// <summary>
        /// 根据GUID得到一个对象实体
        /// </summary>
        /// <param name="C_Region_code"></param>
        /// <returns></returns>
        public Model.C_Region GetModelByCode(Guid C_Region_code)
        {
            return bll.GetModelByCode(C_Region_code);
        }
        /// <summary>
        /// 得到全部数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.C_Region> GetAllList()
        {
            return bll.GetAllList();
        }

        /// <summary>
        /// 获取所有区域，并且根据组织机构Guid，用户Guid，岗位Guid设置关联区域状态值
        /// </summary>
        /// <param name="orgCode">织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>     
        public List<CommonService.Model.C_Region> GetAllRegion(Guid? orgCode, Guid? userCode, Guid? postCode)
        {
            return bll.GetAllRegion(orgCode, userCode, postCode);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_Region model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_Region> GetListByPage(Model.C_Region model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 获取全部特殊区域数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.C_Region> GetAllSpecialList()
        {
            return bll.GetAllSpecialList();
        }

        /// <summary>
        /// 根据选中的律师的usercode获取对应的区域的所有法院
        /// </summary>
        /// <param name="usercode"></param>
        /// <returns></returns>
        public Guid GetRegionCodeByUsercode(Guid usercode)
        {
            return bll.GetRegionCodeByUsercode(usercode);
        }
    }
}
