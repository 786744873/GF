using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserinfo”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_ChiefExpert_Minister
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_ChiefExpert_Minister_id">ID</param>
        /// <returns>是否存在</returns>
        [OperationContract]
        bool Exists(int C_ChiefExpert_Minister_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_ChiefExpert_Minister model);

        /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_ChiefExpert_Minister model);

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="C_ChiefExpert_Minister_id">ID</param>
        /// <returns>是否成功</returns>
        [OperationContract]
        bool Delete(Guid ChiefExpert_Code, Guid Minister_Code);

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.SysManager.C_ChiefExpert_Minister> C_ChiefExpert_Ministers);
        /// <summary>
        /// 根据部长guid得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_ChiefExpert_Minister GetModelByMinister(Guid C_Minister_Code);
    }
}
