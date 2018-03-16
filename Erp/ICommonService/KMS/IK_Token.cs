using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IK_Token”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Token
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
        bool Exists(int K_Token_id);


        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Token model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Token model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int K_Token_id);
        /// <summary>
        /// 批量删除数据
        /// </summary>
        [OperationContract]
        bool DeleteList(string K_Token_idlist);


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Token GetModel(int K_Token_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Token GetDateModel(string filedOrder);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Token> GetModelList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]
        DataSet GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获取记录总数
        /// </summary>
        [OperationContract]
        int GetRecordCount(string strWhere);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
    }
}

