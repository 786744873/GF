using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Contacts”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Contacts.svc 或 C_Contacts.svc.cs，然后开始调试。
    public class C_Contacts : IC_Contacts
    {
        CommonService.BLL.C_Contacts conBLL = new CommonService.BLL.C_Contacts();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return conBLL.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Contacts_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Contacts_id)
        {
            return conBLL.Exists(C_Contacts_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Contacts model)
        {
            return conBLL.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Contacts model)
        {
            return conBLL.Update(model);
        }

        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="C_Contacts_code">联系人Guid</param>
        /// <param name="RelationCode">关联表Guid</param>
        /// <param name="ContactType">联系人类型</param>
        /// <returns></returns>
        public bool Delete(Guid C_Contacts_code, Guid RelationCode, int ContactType)
        {
            return conBLL.Delete(C_Contacts_code, RelationCode, ContactType);
        }
        /// <summary>
        /// 根据ID得到一个实体对象
        /// </summary>
        /// <param name="C_Contacts_id"></param>
        /// <returns></returns>
        public Model.C_Contacts GetModel(int C_Contacts_id)
        {
            return conBLL.GetModel(C_Contacts_id);
        }
        /// <summary>
        /// 根据Code得到一个实体对象
        /// </summary>
        /// <param name="C_Contacts_code"></param>
        /// <returns></returns>
        public Model.C_Contacts Get(Guid C_Contacts_code)
        {
            return conBLL.GetModel(C_Contacts_code);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.C_Contacts> GetListByRelationAndType(CommonService.Model.C_Contacts model)
        {
            return conBLL.GetListByRelationAndType(model);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_Contacts model)
        {
            return conBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_Contacts> GetListByPage(Model.C_Contacts model, string orderby, int startIndex, int endIndex)
        {
            return conBLL.GetListByPage(model,orderby,startIndex,endIndex);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Model.C_Contacts> GetModelList()
        {
            return conBLL.GetModelList();
        }
    }
}
