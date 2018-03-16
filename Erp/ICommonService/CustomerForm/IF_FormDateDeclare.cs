using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CustomerForm
{
    /// <summary>
    /// 表单时间声明表契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IF_FormDateDeclare
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
        bool Exists(int F_FormDateDeclare_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.CustomerForm.F_FormDateDeclare model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CustomerForm.F_FormDateDeclare model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int F_FormDateDeclare_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_FormDateDeclare GetModel(int F_FormDateDeclare_id);

        /// <summary>
        /// 根据表单GUID获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormDateDeclare> GetListByFormCode(Guid F_FormDateDeclare_formCode, int F_FormDateDeclare_type);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CustomerForm.F_FormDateDeclare model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_FormDateDeclare> GetListByPage(CommonService.Model.CustomerForm.F_FormDateDeclare model, string orderby, int startIndex, int endIndex);
    }
}
