using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_RCProduct
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
        bool Exists(int C_RCProduct_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_RCProduct model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_RCProduct model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_RCProduct_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_RCProduct GetModel(int C_RCProduct_id);

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //[OperationContract]
        //CommonService.Model.C_RCProduct GetModel(Guid C_RCProduct_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_RCProduct model);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_RCProduct> GetListByPage(CommonService.Model.C_RCProduct model, string orderby, int startIndex, int endIndex);
    }
}
