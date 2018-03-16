using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.BusinessChanceManager
{
    /// <summary>
    /// 商机关联表契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_BusinessChance_link
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
        bool Exists(int B_BusinessChance_link_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model);

        /// <summary>
        /// 批量插入,修改，或删除
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> B_BusinessChance_links);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_BusinessChance_link_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.BusinessChanceManager.B_BusinessChance_link GetModel(int B_BusinessChance_link_id);

        /// <summary>
        /// 根据商机Guid，类型值，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="linkType">类型值</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetBusinessChanceLinks(Guid businessChanceCode, int linkType);

        /// <summary>
        /// 根据商机Guid，获取商机关联所有数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param> 
        /// <returns></returns>     
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetBusinessChanceAllLinks(Guid businessChanceCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance_link model, string orderby, int startIndex, int endIndex);
    }
}
