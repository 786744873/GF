using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.BusinessChanceManager
{
    /// <summary>
    /// 商机审查契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_BusinessChance_check
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid B_BusinessChance_checkCode);

        /// <summary>
        /// 提交审查
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="businessChanceCode">用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool SubmitCheck(Guid businessChanceCode,Guid userCode);

        /// <summary>
        /// 提交部长商机审查
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <returns></returns>
        [OperationContract]
        bool SubmitMinisterCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck);

        /// <summary>
        /// 提交首席商机审查
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <returns></returns>
        [OperationContract]
        bool SubmitChiefCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetModel(Guid B_BusinessChance_checkCode);

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheck(Guid businessChanceCode, int checkPersonType);

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheckByBusinessChance(Guid businessChanceCode);

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条没有审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetUnCheckedChanceCheck(Guid businessChanceCode, int checkPersonType);

        /// <summary>
        /// 根据商机Guid，获取全部已审查记录
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetChekedBusinessChanceChecks(Guid businessChanceCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model, string orderby, int startIndex, int endIndex);
    }
}
