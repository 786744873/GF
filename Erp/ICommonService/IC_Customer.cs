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
    public interface IC_Customer
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
        bool Exists(CommonService.Model.C_Customer model);

          /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByCustomerName(string C_Customer_name, int C_Customer_businessType);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByCustomerNameAndCode(string C_Customer_name, Guid C_Customer_code, int C_Customer_businessType);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Customer model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Customer model);

        /// <summary>
        /// 设置客户计划
        /// </summary>
        /// <param name="model">客户数据模型</param>
        /// <returns></returns>
        [OperationContract]
        bool SetCustomerPlan(CommonService.Model.C_Customer model);

        /// <summary>
        /// 启动客户任务
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool StartTask(Guid customerCode, Guid startPersonCode);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Customer_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Customer_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_Customer Get(Guid C_Customer_code);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Customer> GetAllList();

        /// <summary>
        /// 客户联系人
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Contacts> GetContactsListByCustomerCode(Guid customerCode);

        [OperationContract]
        int GetListByPageCount(string strWhere);
        [OperationContract]
        List<CommonService.Model.C_Customer> GetListByPageAll(string where, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据客户guid，来查看客户的部长和首席专家是否为空，如果为空则为部长和首席专家添加数据   ---cyj
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        [OperationContract]
        void SetMinisterAndChiefResponsible(string customerCode,Guid? userOrgCode);
        /// <summary>
        /// 获取客户总数
        /// </summary>
        [OperationContract]
        int  GetCustomerListCount(CommonService.Model.C_Customer model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);
        /// <summary>
        /// 分页获取客户列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Customer> GetCustomerListByPage(CommonService.Model.C_Customer model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);
    }
}
