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
    public interface IC_Court_Judge
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Court_Judge model);

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.C_Court_Judge> C_Court_Judges);
        
        /// <summary>
        /// 根据法院Code获取，法院关联法官集合
        /// </summary>
        /// <param name="courtCode">法院Code</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Court_Judge> GetListByCourt(Guid courtCode);
    }
}
