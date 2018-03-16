using ICommonService.BusinessChanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BusinessChanceManager
{
    /// <summary>
    /// 商机审查服务
    /// </summary>
    public class B_BusinessChance_check : IB_BusinessChance_check
    {
        CommonService.BLL.BusinessChanceManager.B_BusinessChance_check bll = new CommonService.BLL.BusinessChanceManager.B_BusinessChance_check();

        /// <summary>
        /// 增加一条数据
        /// </summary>       
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>        
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>        
        public bool Delete(Guid B_BusinessChance_checkCode)
        {
            return bll.Delete(B_BusinessChance_checkCode);
        }

        /// <summary>
        /// 提交审查
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public bool SubmitCheck(Guid businessChanceCode, Guid userCode)
        {
            return bll.SubmitCheck(businessChanceCode,userCode);
        }

        /// <summary>
        /// 提交部长商机审查
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <returns></returns>        
        public bool SubmitMinisterCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck)
        {
            return bll.SubmitMinisterCheck(businessCheck);
        }

        /// <summary>
        /// 提交首席商机审查
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <returns></returns>
        public bool SubmitChiefCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck)
        {
            return bll.SubmitChiefCheck(businessCheck);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>       
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetModel(Guid B_BusinessChance_checkCode)
        {
            return bll.GetModel(B_BusinessChance_checkCode);
        }

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条没有审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetUnCheckedChanceCheck(Guid businessChanceCode, int checkPersonType)
        {
            return bll.GetUnCheckedChanceCheck(businessChanceCode, checkPersonType);
        }

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheck(Guid businessChanceCode, int checkPersonType)
        {
            return bll.GetLatestChanceCheck(businessChanceCode, checkPersonType);
        }

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>      
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheckByBusinessChance(Guid businessChanceCode)
        {
            return bll.GetLatestChanceCheckByBusinessChance(businessChanceCode);
        }

        /// <summary>
        /// 根据商机Guid，获取全部已审查记录
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetChekedBusinessChanceChecks(Guid businessChanceCode)
        {
            return bll.GetChekedBusinessChanceChecks(businessChanceCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>      
        public int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>       
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
