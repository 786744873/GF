using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.FinanceManager
{
    /// <summary>
    /// 凭证信息契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Voucher
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
        bool Exists(int C_Voucher_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.FinanceManager.C_Voucher model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.FinanceManager.C_Voucher model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Voucher_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Voucher_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.FinanceManager.C_Voucher GetModel(Guid C_Voucher_code);
          /// <summary>
        /// 获取最新的一条数据
        /// </summary>
        [OperationContract]
        CommonService.Model.FinanceManager.C_Voucher GetNewestModel(Guid creatorCode);
        /// <summary>
        /// 获取所有数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FinanceManager.C_Voucher> GetAllList();

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.FinanceManager.C_Voucher model,string rolePowerIds);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FinanceManager.C_Voucher> GetListByPage(CommonService.Model.FinanceManager.C_Voucher model,string rolePowerIds, string orderby, int startIndex, int endIndex);
    }
}
