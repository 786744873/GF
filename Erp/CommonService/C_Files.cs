using ICommonService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Userinfo”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Files.svc 或 C_Files.svc.cs，然后开始调试。
    /// <summary>
    /// 附件表服务层
    /// </summary>
    public class C_Files : IC_Files
    {
        private CommonService.BLL.C_Files filesBLL = new CommonService.BLL.C_Files();
        public C_Files()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return filesBLL.GetMaxId();
        }
        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModelByCode(Guid C_Files_code)
        {
            return filesBLL.GetModelByCode(C_Files_code);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Files_id)
        {
            return filesBLL.Exists(C_Files_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.C_Files model)
        {
            return filesBLL.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Files model)
        {
            return filesBLL.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid fileCode)
        {

            return filesBLL.Delete(fileCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Files_idlist)
        {
            return filesBLL.DeleteList(C_Files_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModel(int C_Files_id)
        {

            return filesBLL.GetModel(C_Files_id);
        }
        /// <summary>
        /// 根据文件名得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModelByName(string fileName)
        {
            return filesBLL.GetModelByName(fileName);
        }
        /// <summary>
        /// 根据文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Files> GetFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode)
        {
            return filesBLL.GetFilesByBelongTypeAndRelationCode(belongType, relationCode);
        }
        /// <summary>
        /// 根据父级文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.C_Files> GetChildenFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode)
        {
            return filesBLL.GetChildenFilesByBelongTypeAndRelationCode(belongType, relationCode);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return filesBLL.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return filesBLL.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Files> GetListByPage(Model.C_Files files, string orderby, int startIndex, int endIndex)
        {
            return filesBLL.GetListByPage(files, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return filesBLL.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
