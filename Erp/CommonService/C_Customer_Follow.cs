using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 客户跟进服务
    /// </summary>
    public class C_Customer_Follow : IC_Customer_Follow
    {
        private readonly CommonService.BLL.C_Customer_Follow bll = new CommonService.BLL.C_Customer_Follow();
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Customer_Follow model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Customer_Follow model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Customer_Follow_id"></param>
        /// <returns></returns>
        public bool Delete(int C_Customer_Follow_id)
        {
            return bll.Delete(C_Customer_Follow_id);
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="C_Customer_Follow_id"></param>
        /// <returns></returns>
        public Model.C_Customer_Follow GetModel(int C_Customer_Follow_id)
        {
            return bll.GetModel(C_Customer_Follow_id);
        }
        /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_Customer_Follow model)
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
        public List<Model.C_Customer_Follow> GetListByPage(Model.C_Customer_Follow model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
        /// <summary>
        /// 根据客户实体和客户跟进实体获取中记录数
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <returns></returns>
        public int GetRecordCount2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, bool IsPreSetManager, Guid? userCode, Guid? postGroupCode)
        {
            return bll.GetRecordCount2(model, modelc, IsPreSetManager, userCode, postGroupCode);
        }
        /// <summary>
        /// 根据客户实体和客户跟进实体获取分页数据
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Customer_Follow> GetListByPage2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, bool IsPreSetManager, string orderby, int startIndex, int endIndex, Guid? userCode, Guid? postGroupCode)
        {
            return bll.GetListByPage2(model, modelc, IsPreSetManager, orderby, startIndex, endIndex, userCode, postGroupCode);
        }
    }
}
