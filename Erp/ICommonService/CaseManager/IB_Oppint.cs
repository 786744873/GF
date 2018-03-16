using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件--担保物约定契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Oppint
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
        bool Exists(int B_Oppint_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Oppint model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Oppint model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_Oppint_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Oppint GetModel(int B_Oppint_id);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_Oppint model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Oppint> GetListByPage(CommonService.Model.CaseManager.B_Oppint model, string orderby, int startIndex, int endIndex);
    }
}
