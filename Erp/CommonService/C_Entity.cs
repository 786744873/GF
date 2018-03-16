using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    /// <summary>
    /// 实体服务
    /// </summary>
    public class C_Entity : IC_Entity
    {
        CommonService.BLL.C_Entity oBLL = new CommonService.BLL.C_Entity();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Entity model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Entity model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Entity_code)
        {
            return oBLL.Delete(C_Entity_code);         
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Entity_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_Entity Get(Guid C_Entity_code)
        {
            return oBLL.GetModel(C_Entity_code);          
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Entity model)
        {
            return oBLL.GetRecordCount(model);           
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.C_Entity> GetListByPage(CommonService.Model.C_Entity model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);          
        }
    }
}
