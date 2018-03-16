using ICommonService.FinanceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FinanceManager
{
    /// <summary>
    /// 凭证信息服务
    /// </summary>
    public class C_Voucher : IC_Voucher
    {
        CommonService.BLL.FinanceManager.C_Voucher bll = new CommonService.BLL.FinanceManager.C_Voucher();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Voucher_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Voucher_id)
        {
            return bll.Exists(C_Voucher_id);
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.FinanceManager.C_Voucher model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.FinanceManager.C_Voucher model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="C_Voucher_code"></param>
        /// <returns></returns>
        public bool Delete(Guid C_Voucher_code)
        {
            return bll.Delete(C_Voucher_code);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="C_Voucher_code"></param>
        /// <returns></returns>
        public Model.FinanceManager.C_Voucher GetModel(Guid C_Voucher_code)
        {
            return bll.GetModel(C_Voucher_code);
        }
         /// <summary>
        /// 获取所有数据列表
        /// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher> GetAllList()
        {
            return bll.GetAllList();
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.FinanceManager.C_Voucher model, string rolePowerIds)
        {
            return bll.GetRecordCount(model, rolePowerIds);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.FinanceManager.C_Voucher> GetListByPage(Model.FinanceManager.C_Voucher model, string rolePowerIds, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, rolePowerIds,orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获取最新一条数据
        /// </summary>
        /// <returns></returns>
        public Model.FinanceManager.C_Voucher GetNewestModel(Guid creatorCode)
        {
            return bll.GetNewestModel(creatorCode);
        }
    }
}
