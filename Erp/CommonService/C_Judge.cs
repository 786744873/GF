using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    public class C_Judge : IC_Judge
    {
        CommonService.BLL.C_Judge juBLL = new CommonService.BLL.C_Judge();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return juBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid C_Judge_contactscode)
        {
            return juBLL.Exists(C_Judge_contactscode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.C_Judge model)
        {
            return juBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.C_Judge model)
        {
            return juBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid C_Judge_contactscode)
        {
            return juBLL.Delete(C_Judge_contactscode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(Model.C_Judge model)
        {
            return juBLL.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Judge> GetListByPage(Model.C_Judge model, string orderby, int startIndex, int endIndex)
        {
            return juBLL.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 根据法官Code得到一个对象实体
        /// </summary>
        /// <param name="judge_code"></param>
        /// <returns></returns>
        public Model.C_Judge GetModelByJudgeCode(Guid judge_code)
        {
            return juBLL.GetModelByJudgeCode(judge_code);
        }
    }
}
