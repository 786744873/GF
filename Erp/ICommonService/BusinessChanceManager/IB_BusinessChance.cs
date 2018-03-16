using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.BusinessChanceManager
{
    /// <summary>
    /// 商机契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_BusinessChance
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
        bool Exists(int B_BusinessChance_id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByName(CommonService.Model.BusinessChanceManager.B_BusinessChance model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid B_BusinessChance_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.BusinessChanceManager.B_BusinessChance GetModel(Guid B_BusinessChance_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 修改商机进行状态
        /// </summary>
        /// <param name="B_BusinessChance_code">商机Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateState(Guid B_BusinessChance_code,Guid startPersonCode);
        /// <summary>
        /// 商机转案件
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool BusinessChanceConvertCase(Guid businessChanceCode, string levelType);

        /// <summary>
        /// 分页获取权限数据总记录
        /// </summary>
        [OperationContract]
        int GetPowerRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);

        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance> GetPowerListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);

    }
}
