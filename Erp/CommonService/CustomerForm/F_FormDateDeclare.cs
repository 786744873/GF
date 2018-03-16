using ICommonService.CustomerForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CustomerForm
{
    /// <summary>
    /// 表单时间声明服务
    /// </summary>
    public class F_FormDateDeclare : IF_FormDateDeclare
    {
        CommonService.BLL.CustomerForm.F_FormDateDeclare bll = new CommonService.BLL.CustomerForm.F_FormDateDeclare();
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
        /// <param name="F_FormDateDeclare_id"></param>
        /// <returns></returns>
        public bool Exists(int F_FormDateDeclare_id)
        {
            return bll.Exists(F_FormDateDeclare_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.CustomerForm.F_FormDateDeclare model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CustomerForm.F_FormDateDeclare model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="F_FormDateDeclare_id"></param>
        /// <returns></returns>
        public bool Delete(int F_FormDateDeclare_id)
        {
            return bll.Delete(F_FormDateDeclare_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="F_FormDateDeclare_id"></param>
        /// <returns></returns>
        public Model.CustomerForm.F_FormDateDeclare GetModel(int F_FormDateDeclare_id)
        {
            return bll.GetModel(F_FormDateDeclare_id);
        }
        /// <summary>
        /// 根据表单GUID获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormDateDeclare> GetListByFormCode(Guid F_FormDateDeclare_formCode, int F_FormDateDeclare_type)
        {
            return bll.GetListByFormCode(F_FormDateDeclare_formCode, F_FormDateDeclare_type);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.CustomerForm.F_FormDateDeclare model)
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
        public List<Model.CustomerForm.F_FormDateDeclare> GetListByPage(Model.CustomerForm.F_FormDateDeclare model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }
    }
}
