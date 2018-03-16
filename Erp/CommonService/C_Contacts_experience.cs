using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Contacts_experience”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Contacts_experience.svc 或 C_Contacts_experience.svc.cs，然后开始调试。
    public class C_Contacts_experience : IC_Contacts_experience
    {
        CommonService.BLL.C_Contacts_experience ceBLL = new CommonService.BLL.C_Contacts_experience();

        public int GetMaxId()
        {
            return ceBLL.GetMaxId();
        }

        public bool Exists(int C_Contacts_experience_id)
        {
            return ceBLL.Exists(C_Contacts_experience_id);
        }

        public int Add(Model.C_Contacts_experience model)
        {
            return ceBLL.Add(model);
        }

        public bool Update(Model.C_Contacts_experience model)
        {
            return ceBLL.Update(model);
        }

        public bool Delete(int C_Contacts_experience_id)
        {
            return ceBLL.Delete(C_Contacts_experience_id);
        }

        public Model.C_Contacts_experience GetModel(int C_Contacts_experience_id)
        {
            return ceBLL.GetModel(C_Contacts_experience_id);
        }

        public int GetRecordCount(Model.C_Contacts_experience model)
        {
            return ceBLL.GetRecordCount(model);
        }

        public List<Model.C_Contacts_experience> GetListByPage(Model.C_Contacts_experience model, string orderby, int startIndex, int endIndex)
        {
            return ceBLL.GetListByPage(model,orderby,startIndex,endIndex);
        }

        public Model.C_Contacts_experience Get(Guid C_Contacts_code)
        {
            return ceBLL.GetModel(C_Contacts_code);
        }
    }
}
