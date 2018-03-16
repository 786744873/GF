using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 流程契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Flow
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_Flow model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Flow model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_Flow_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_Flow Get(Guid O_Flow_code);
        /// <summary>
        /// 根据code获取数据对象
        /// </summary>
        /// <param name="flowcode"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_Flow GetModel(Guid flowcode);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.OA.O_Flow model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Flow> GetListByPage(CommonService.Model.OA.O_Flow model, string orderby, int startIndex, int endIndex);
    }
}
