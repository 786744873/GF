using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 客户跟进契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Customer_Follow
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Customer_Follow model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Customer_Follow model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Customer_Follow_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.C_Customer_Follow GetModel(int C_Customer_Follow_id);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Customer_Follow model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Customer_Follow> GetListByPage(CommonService.Model.C_Customer_Follow model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据客户实体和客户跟进实体获取中记录数
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <returns></returns>
        [OperationContract]
        int GetRecordCount2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, bool IsPreSetManager, Guid? userCode, Guid? postGroupCode);
        /// <summary>
        /// 根据客户实体和客户跟进实体获取分页数据
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Customer_Follow> GetListByPage2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, bool IsPreSetManager, string orderby, int startIndex, int endIndex, Guid? userCode, Guid? postGroupCode);

    }
}
