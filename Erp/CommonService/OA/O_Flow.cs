using ICommonService.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.OA
{
    /// <summary>
    /// 流程服务
    /// </summary>
    public class O_Flow : IO_Flow
    {
        CommonService.BLL.OA.O_Flow oBLL = new CommonService.BLL.OA.O_Flow();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Flow model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Flow model)
        {
            return oBLL.Update(model);
        }
        /// <summary>
        /// 根据code获得数据对象
        /// </summary>
        /// <param name="flowcode"></param>
        /// <returns></returns>
        public CommonService.Model.OA.O_Flow GetModel(Guid flowcode)
        {
            return oBLL.GetModel(flowcode);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Flow_code)
        {
            return oBLL.Delete(O_Flow_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Flow_code"></param>
        /// <returns></returns>
        public CommonService.Model.OA.O_Flow Get(Guid O_Flow_code)
        {
            return oBLL.GetModel(O_Flow_code);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_Flow model)
        {
            return oBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Flow> GetListByPage(CommonService.Model.OA.O_Flow model, string orderby, int startIndex, int endIndex)
        {
            return oBLL.GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
