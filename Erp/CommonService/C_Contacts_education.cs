using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Contacts_education”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Contacts_education.svc 或 C_Contacts_education.svc.cs，然后开始调试。
    public class C_Contacts_education : IC_Contacts_education
    {
        CommonService.BLL.C_Contacts_education ceBLL = new CommonService.BLL.C_Contacts_education();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return ceBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Contacts_education_id)
        {
            return ceBLL.Exists(C_Contacts_education_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_Contacts_education model)
        {
            return ceBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.C_Contacts_education model)
        {
            return ceBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_Contacts_education_id)
        {
            return ceBLL.Delete(C_Contacts_education_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.C_Contacts_education GetModel(int C_Contacts_education_id)
        {
            return ceBLL.GetModel(C_Contacts_education_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.C_Contacts_education Get(Guid C_Contacts_code)
        {
            return ceBLL.GetModel(C_Contacts_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.C_Contacts_education model)
        {
            return ceBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Contacts_education> GetListByPage(Model.C_Contacts_education model, string orderby, int startIndex, int endIndex)
        {
            return ceBLL.GetListByPage(model,orderby,startIndex,endIndex);
        }

        
    }
}
