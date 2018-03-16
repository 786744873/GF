using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CustomerForm
{
    /// <summary>
    /// 自定义表单契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IF_Form
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
        bool Exists(int F_Form_id);

        /// <summary>
        /// 是否存在表单标识
        /// </summary>
        /// <param name="formIdentification"></param>
        /// <returns></returns>
        [OperationContract]
        bool ExistsFormIdentification(string formIdentification);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CustomerForm.F_Form model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CustomerForm.F_Form model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid F_Form_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="F_Form_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CustomerForm.F_Form Get(Guid F_Form_code);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_Form> GetAllListByFlowType(int FlowType);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CustomerForm.F_Form model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CustomerForm.F_Form> GetListByPage(CommonService.Model.CustomerForm.F_Form model, string orderby, int startIndex, int endIndex);
    }
}
