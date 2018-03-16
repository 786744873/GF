using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_PRival”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_PRival
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
        bool Exists(int C_PRival_id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByName(CommonService.Model.C_PRival model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_PRival model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_PRival model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_PRival_code);

        /// <summary>
        /// 根据父级GUID得到子集集合
        /// </summary>
        [OperationContract]
        CommonService.Model.C_PRival GetModelByPcode(Guid C_PRival_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_PRival GetModel(Guid C_PRival_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_PRival model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_PRival> GetListByPage(CommonService.Model.C_PRival model, string orderby, int startIndex, int endIndex);
    }
}
