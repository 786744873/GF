using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 客户契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Principal
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
        bool Exists(CommonService.Model.C_Principal model);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByPrincipalName(string C_Principal_name, int C_Principal_businessType);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByPrincipalNameAndCode(string C_Principal_name, Guid C_Principal_code, int C_Principal_businessType);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Principal model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Principal model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Principal_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Customer_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_Principal Get(Guid C_Principal_code);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Principal> GetAllList();

        /// <summary>
        /// 委托联系人
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Contacts> GetContactsListByPrincipalCode(Guid principalCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Principal model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Principal> GetListByPage(CommonService.Model.C_Principal model, string orderby, int startIndex, int endIndex);

    }
}
