using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Court”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Court_Lawyer
    {
        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.C_Court_Lawyer> C_Court_Lawyers);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lawyerCode">律师Guid</param>
        /// <param name="courtCodes">法院Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid lawyerCode, Guid courtCodes);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.Customer.V_Lawyer model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.Customer.V_Lawyer> GetListByPage(CommonService.Model.Customer.V_Lawyer model, string orderby, int startIndex, int endIndex);
    }
}
