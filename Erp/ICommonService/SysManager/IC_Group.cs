using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Group”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Group
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
        bool Exists(int C_Group_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Group model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Group model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Group_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Group GetModel(int C_Group_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Group GetModelByCode(Guid C_Group_code);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Group> GetAllList();

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Group model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Group> GetListByPage(CommonService.Model.SysManager.C_Group model, string orderby, int startIndex, int endIndex);
    }
}
