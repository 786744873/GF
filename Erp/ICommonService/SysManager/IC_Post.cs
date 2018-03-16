using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Post”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Post
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_Post_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.SysManager.C_Post model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Post model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Post_id);


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Post GetModel(int C_Post_id);

        /// <summary>
        /// 通过岗位Guid，得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Post GetModelByPostCode(Guid postCode);

          /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Post GetLinkRolesModel(Guid C_Post_code);
        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Post> GetList();
        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Post> GetListWhere(string strWhere);

        /// <summary>
        /// 得到所有岗位集合
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Post> GetAllPosts();

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.SysManager.C_Post model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Post> GetListByPage(CommonService.Model.SysManager.C_Post model, string orderby, int startIndex, int endIndex);

        #region App专用
        /// <summary>
        /// 获取所有岗位
        /// </summary>
        /// <returns>岗位列表</returns>
        [WebInvoke(UriTemplate = "AppGetPosition", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.SysManager.C_Post> AppGetPosition();
        #endregion
    }
}
