using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Region”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Region
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
        bool Exists(int C_Region_Id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Region model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Region model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Region_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Region GetModel(int C_Region_Id);
         /// <summary>
        /// 根据GUID得到一个对象实体
        /// </summary>
        /// <param name="C_Region_code"></param>
        /// <returns></returns>
         [OperationContract]
        CommonService.Model.C_Region GetModelByCode(Guid C_Region_code);
         /// <summary>
        /// 得到全部数据列表
        /// </summary>
        /// <returns></returns>
         [OperationContract]
         List<CommonService.Model.C_Region> GetAllList();

         /// <summary>
         /// 获取所有区域，并且根据组织机构Guid，用户Guid，岗位Guid设置关联区域状态值
         /// </summary>
         /// <param name="orgCode">织机构Guid</param>
         /// <param name="userCode">用户Guid</param>
         /// <param name="postCode">岗位Guid</param>
         /// <returns></returns>
         [OperationContract]
         List<CommonService.Model.C_Region> GetAllRegion(Guid? orgCode, Guid? userCode, Guid? postCode);
         
         /// <summary>
        /// 获得全部特殊区域数据列表
        /// </summary>
        [OperationContract]
         List<CommonService.Model.C_Region> GetAllSpecialList();

         /// <summary>
        /// 获得选中的律师code获取对应区域的法院
        /// </summary>
        [OperationContract]
         Guid  GetRegionCodeByUsercode(Guid usercode );
      
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Region model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Region> GetListByPage(CommonService.Model.C_Region model, string orderby, int startIndex, int endIndex);
    }
}
