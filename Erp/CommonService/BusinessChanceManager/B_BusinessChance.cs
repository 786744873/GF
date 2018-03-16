using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService.BusinessChanceManager;

namespace CommonService.BusinessChanceManager
{
    /// <summary>
    /// 商机服务
    /// </summary>
    public class B_BusinessChance : IB_BusinessChance
    {
        CommonService.BLL.BusinessChanceManager.B_BusinessChance bll = new CommonService.BLL.BusinessChanceManager.B_BusinessChance();
        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="B_BusinessChance_id"></param>
        /// <returns></returns>
        public bool Exists(int B_BusinessChance_id)
        {
            return bll.Exists(B_BusinessChance_id);
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.BusinessChanceManager.B_BusinessChance model)
        {
            return bll.ExistsByName(model);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.BusinessChanceManager.B_BusinessChance model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.BusinessChanceManager.B_BusinessChance model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_BusinessChance_code"></param>
        /// <returns></returns>
        public bool Delete(Guid B_BusinessChance_code)
        {
            return bll.Delete(B_BusinessChance_code);
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="B_BusinessChance_code"></param>
        /// <returns></returns>
        public Model.BusinessChanceManager.B_BusinessChance GetModel(Guid B_BusinessChance_code)
        {
            return bll.GetModel(B_BusinessChance_code);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.BusinessChanceManager.B_BusinessChance model)
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
        public List<Model.BusinessChanceManager.B_BusinessChance> GetListByPage(Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 修改商机进行状态
        /// </summary>
        /// <param name="B_BusinessChance_code">商机Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns></returns>
        public bool UpdateState(Guid B_BusinessChance_code, Guid startPersonCode)
        {
            return bll.UpdateState(B_BusinessChance_code, startPersonCode);
        }

        /// <summary>
        /// 商机转案件
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        public bool BusinessChanceConvertCase(Guid businessChanceCode, string levelType)
        {
            return bll.BusinessChanceConvertCase(businessChanceCode, levelType);
        }

        /// <summary>
        /// 分页获取权限数据总记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="RoleId"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public int GetPowerRecordCount(Model.BusinessChanceManager.B_BusinessChance model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetPowerRecordCount(model,IsPreSetManager,userCode,postCode,deptCode);
        }
        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="RoleId"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<Model.BusinessChanceManager.B_BusinessChance> GetPowerListByPage(Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            return bll.GetPowerListByPage(model,orderby,startIndex,endIndex,IsPreSetManager,userCode,postCode,deptCode);
        }
    }
}
