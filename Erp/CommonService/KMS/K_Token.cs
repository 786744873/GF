using ICommonService.KMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Business_flow”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Business_flow.svc 或 P_Business_flow.svc.cs，然后开始调试。
    public class K_Token : IK_Token
    {
        CommonService.BLL.KMS.K_Token bll = new CommonService.BLL.KMS.K_Token();

        public K_Token()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Token_id)
        {
            return bll.Exists(K_Token_id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.KMS.K_Token model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.KMS.K_Token model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int K_Token_id)
        {

            return bll.Delete(K_Token_id);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string K_Token_idlist)
        {
            return bll.DeleteList(K_Token_idlist);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Token GetModel(int K_Token_id)
        {
            return bll.GetModel(K_Token_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public Model.KMS.K_Token GetDateModel(string filedOrder)
        {
            return bll.GetDateModel(filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Token> GetModelList(string strWhere)
        {
            return bll.GetModelList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return bll.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
