using ICommonService.KMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“K_Resources_Cover”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 K_Resources_Cover.svc 或 K_Resources_Cover.svc.cs，然后开始调试。
    public class K_Resources_Cover : IK_Resources_Cover
    {
        CommonService.BLL.KMS.K_Resources_Cover bll = new CommonService.BLL.KMS.K_Resources_Cover();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Resources_cover_id)
        {
            return bll.Exists(K_Resources_cover_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources_Cover model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Resources_Cover model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int K_Resources_cover_id)
        {

            return bll.Delete(K_Resources_cover_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string K_Resources_cover_idlist)
        {
            return bll.DeleteList(K_Resources_cover_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources_Cover GetModel(int K_Resources_cover_id)
        {

            return bll.GetModel(K_Resources_cover_id);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return bll.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.KMS.K_Resources_Cover> GetAllList()
        {
            return bll.GetAllList();
        }

        /// <summary>
        /// 获得数据列表(已启用)
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources_Cover> GetStartList()
        {
            return bll.GetStartList();
        }

        /// <summary>
        /// 分页获取数据列表
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
    }
}
