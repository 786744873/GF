using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 实体表接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Entity
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Entity model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Entity model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Entity_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Entity_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_Entity Get(Guid C_Entity_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Entity model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Entity> GetListByPage(CommonService.Model.C_Entity model, string orderby, int startIndex, int endIndex);
    } 
}
