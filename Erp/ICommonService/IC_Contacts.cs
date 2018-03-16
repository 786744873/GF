using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Contacts”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Contacts
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_Contacts_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Contacts model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Contacts model);

        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="C_Contacts_code">联系人Guid</param>
        /// <param name="RelationCode">关联表Guid</param>
        /// <param name="ContactType">联系人类型</param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid C_Contacts_code, Guid RelationCode, int ContactType);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Contacts GetModel(int C_Contacts_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Contacts Get(Guid C_Contacts_code);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Contacts> GetModelList();

          /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Contacts> GetListByRelationAndType(CommonService.Model.C_Contacts model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Contacts model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Contacts> GetListByPage(CommonService.Model.C_Contacts model, string orderby, int startIndex, int endIndex);

    }
}
