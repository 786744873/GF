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
    public interface IC_Court
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
        bool Exists(int C_Court_id);

        /// <summary>
        /// 是否存在该记录(根据名称)
        /// </summary>
        [OperationContract]
        bool ExistsByName(CommonService.Model.C_Court model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Court model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Court model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Court_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Court GetModel(int C_Court_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Court Get(Guid C_Court_code);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Court> GetAllList();
        /// <summary>
        /// 获得对应律师区域的法院
        /// </summary>
        /// <param name="regioncode"></param>
        /// <returns></returns>
 
        [OperationContract]
        List<CommonService.Model.C_Court> GetAllListByUserRegioncode(Guid regioncode);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Court> GetAllListByLawyer(Guid Lawyer);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Court model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Court> GetListByPage(CommonService.Model.C_Court model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 获取法院信息
        /// </summary>, bool IsPreSetManager, int? RoleId
        /// <param name="lawyerCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Court> GetListBylawyer(Guid lawyerCode);
    }
}
