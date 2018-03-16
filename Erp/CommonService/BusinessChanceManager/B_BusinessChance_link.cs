using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService.BusinessChanceManager;

namespace CommonService.BusinessChanceManager
{
    /// <summary>
    /// 商机关联表服务
    /// </summary>
    public class B_BusinessChance_link : IB_BusinessChance_link
    {
        CommonService.BLL.BusinessChanceManager.B_BusinessChance_link bll = new CommonService.BLL.BusinessChanceManager.B_BusinessChance_link();
        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="B_BusinessChance_link_id"></param>
        /// <returns></returns>
        public bool Exists(int B_BusinessChance_link_id)
        {
            return bll.Exists(B_BusinessChance_link_id);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.BusinessChanceManager.B_BusinessChance_link model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_BusinessChance_links"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.BusinessChanceManager.B_BusinessChance_link> B_BusinessChance_links)
        {
            return bll.OperateList(B_BusinessChance_links);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.BusinessChanceManager.B_BusinessChance_link model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_BusinessChance_link_id"></param>
        /// <returns></returns>
        public bool Delete(int B_BusinessChance_link_id)
        {
            return bll.Delete(B_BusinessChance_link_id);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="B_BusinessChance_link_id"></param>
        /// <returns></returns>
        public Model.BusinessChanceManager.B_BusinessChance_link GetModel(int B_BusinessChance_link_id)
        {
            return bll.GetModel(B_BusinessChance_link_id);
        }

        /// <summary>
        /// 根据商机Guid，类型值，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="linkType">类型值</param>
        /// <returns></returns>     
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetBusinessChanceLinks(Guid businessChanceCode, int linkType)
        {
            return bll.GetBusinessChanceLinks(businessChanceCode, linkType);
        }

        /// <summary>
        /// 根据商机Guid，获取商机关联数据集合
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param> 
        /// <returns></returns>     
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> GetBusinessChanceAllLinks(Guid businessChanceCode)
        {
            return bll.GetBusinessChanceAllLinks(businessChanceCode);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.BusinessChanceManager.B_BusinessChance_link model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.BusinessChanceManager.B_BusinessChance_link> GetListByPage(Model.BusinessChanceManager.B_BusinessChance_link model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
