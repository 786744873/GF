using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    /// <summary>
    /// 案件--担保物约定服务
    /// 作者:崔慧栋
    /// 日期:2015/06/06
    /// </summary>
    public class B_Oppint : IB_Oppint
    {
        CommonService.BLL.CaseManager.B_Oppint bll = new CommonService.BLL.CaseManager.B_Oppint();

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
        /// <param name="B_Oppint_id"></param>
        /// <returns></returns>
        public bool Exists(int B_Oppint_id)
        {
            return bll.Exists(B_Oppint_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.CaseManager.B_Oppint model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CaseManager.B_Oppint model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_Oppint_id"></param>
        /// <returns></returns>
        public bool Delete(int B_Oppint_id)
        {
            return bll.Delete(B_Oppint_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="B_Oppint_id"></param>
        /// <returns></returns>
        public Model.CaseManager.B_Oppint GetModel(int B_Oppint_id)
        {
            return bll.GetModel(B_Oppint_id);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CaseManager.B_Oppint model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.CaseManager.B_Oppint> GetListByPage(Model.CaseManager.B_Oppint model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
