using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Parameters”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Parameters
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
        bool Exists(int C_Parameters_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Parameters model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Parameters model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Parameters_id);


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Parameters GetModel(int C_Parameters_id);
        /// <summary>
        /// 得到一个对象实体,
        /// <param name="relationId">根据父级ID和名称会的对象实体</param>
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Parameters GetModelByParmentname(int C_Parameters_id, string C_parmeters_name);

        /// <summary>
        /// 通过父级ID，获取子集集合
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_Parameters> GetChildrenByParentId(int parentId);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Parameters model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Parameters> GetListByPage(CommonService.Model.C_Parameters model, string orderby, int startIndex, int endIndex);


        /// <summary>
        /// 根据父级ID获取所有子集参数
        /// </summary>
        /// <param name="parentID">父级ID</param>
        /// <returns>所有子集参数</returns>
        [WebInvoke(UriTemplate = "AppGetParametersByParentID", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Parameters> AppGetParametersByParentID(int parentID);

    }
}
