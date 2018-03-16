using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件--收款明细契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_RDetail
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
        bool Exists(int B_RDetail_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_RDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_RDetail model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_RDetail_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_RDetail GetModel(int B_RDetail_id);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_RDetail model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_RDetail> GetListByPage(CommonService.Model.CaseManager.B_RDetail model, string orderby, int startIndex, int endIndex);
         /// <summary>
        /// 根据案件GUID得到收款分类关联par实体对象
        /// </summary>
        /// <param name="B_Case_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_Parameters GetModelByCaseCode(Guid B_Case_code, int type);
    }
}
