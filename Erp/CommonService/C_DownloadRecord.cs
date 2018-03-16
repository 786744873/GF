using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonService;

namespace CommonService
{
    /// <summary>
    /// 下载记录
    /// </summary>
    public class C_DownloadRecord : IC_DownloadRecord
    {
        CommonService.BLL.C_DownloadRecord oBLL = new BLL.C_DownloadRecord();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return oBLL.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_DownloadRecord_id"></param>
        /// <returns></returns>
        public bool Exists(int C_DownloadRecord_id)
        {
            return oBLL.Exists(C_DownloadRecord_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_DownloadRecord model)
        {
            return oBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_DownloadRecord model)
        {
            return oBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        public bool Delete(Guid C_DownloadRecord_code)
        {
            return oBLL.Delete(C_DownloadRecord_code);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        public Model.C_DownloadRecord Get(Guid C_DownloadRecord_code)
        {
            return oBLL.GetModel(C_DownloadRecord_code);
        }

        /// <summary>
        /// 获得下载记录条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_DownloadRecord model)
        {
            return oBLL.GetRecordCount(model);

        }
        /// <summary>
        /// 获得文件的数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<CommonService.Model.C_DownloadRecord> GetListByfileCode(Guid fileCode)
        {
            return oBLL.GetListByfileCode(fileCode);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_DownloadRecord> GetListByPage(Model.C_DownloadRecord model, string orderby, int startIndex, int endIndex)
        {
            return GetListByPage(model, orderby, startIndex, endIndex);
        }
    }
}
