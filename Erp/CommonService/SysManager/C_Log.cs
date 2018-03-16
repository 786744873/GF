using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Log”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Log.svc 或 C_Log.svc.cs，然后开始调试。
    public class C_Log : IC_Log
    {
        CommonService.BLL.SysManager.C_Log bll = new CommonService.BLL.SysManager.C_Log();
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
        public bool Exists(int C_id)
        {
            return bll.Exists(C_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Log model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_id)
        {

            return bll.Delete(C_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_idlist)
        {
            return bll.DeleteList(C_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Log GetModel(int C_id)
        {

            return bll.GetModel(C_id);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return bll.GetList(strWhere);
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
        public DataSet GetAllList()
        {
            return GetList("");
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
        public List<CommonService.Model.SysManager.C_Log> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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


        public List<Model.SysManager.C_Log> GetListDate(Guid strguid)
        {
            return bll.GetListDate(strguid);
        }

        #region 登录日志报表

        /// <summary>
        /// 根据区域统计使用人数
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        public DataSet GetReportByArea(DateTime dateFrom, DateTime dateTo, string organization)
        {
            return bll.GetReportByArea(dateFrom, dateTo, organization);
        }

        /// <summary>
        /// 根据区域统计使用次数
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        public DataSet GetReportByAreaCount(DateTime dateFrom, DateTime dateTo, string organization)
        {
            return bll.GetReportByAreaCount(dateFrom, dateTo, organization);
        }

        #endregion
    }
}
