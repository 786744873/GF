using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 表单契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Form
    {
        /// <summary>
        /// 根据表单Guid，获取表单自定义类型(如普通编辑表单，单头明细行表单，明细行表单)(返回1代表普通编辑表单;2代表主子表单;3代表明细子表)
        /// </summary>
        /// <param name="formCode">表单Guid(ERP系统表单GUID)</param>
        /// <returns>返回1代表普通编辑表单;2代表主子表单;3代表明细子表</returns>
        [OperationContract]
        int GetFormCustomerType(Guid formCode);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_Form model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Form model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_Form_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Form_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_Form Get(Guid O_Form_code);

        /// <summary>
        /// 通过业务流程表单关联Guid，得到一条数据
        /// </summary>
        /// <param name="businessFlowform">业务流程表单关联Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_Form GetByBusinessFlowformCode(Guid businessFlowform);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.OA.O_Form model);

        /// <summary>
        ///  获取代办任务总记录数
        /// </summary>
        /// <param name="model">查询模型数据</param>
        /// <param name="isPreSetManager">是否为内置系统管理员账号</param>
        /// <param name="userCode">当前登录子用户</param>
        /// <returns></returns>
        [OperationContract]
        int GetMyTaskRecordCount(CommonService.Model.OA.O_Form model, bool isPreSetManager, Guid? userCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Form> GetListByPage(CommonService.Model.OA.O_Form model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 获取代办任务数据
        /// </summary>
        /// <param name="model">查询模型数据</param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="isPreSetManager">是否为内置系统管理员账号</param>
        /// <param name="userCode">当前登录子用户</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.OA.O_Form> GetMyTaskListByPage(CommonService.Model.OA.O_Form model, string orderby, int startIndex, int endIndex, bool isPreSetManager, Guid? userCode);

        /// <summary>
        /// 增加或者修改表单时多条数据操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateOrAddList(CommonService.Model.OA.O_Form model, int type);

        /// <summary>
        /// 提交财务表单(专指费用报销单和费用借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="submitUserCode">提交用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool SubmitFinanceForm(Guid fFormCode, Guid oFormCode, Guid businessFlowFormCode, Guid submitUserCode);
        /// <summary>
        /// 通过业务流程表单关联Guid，得到未提交的数据
        /// </summary>
        /// <param name="businessFlowform">业务流程表单关联Guid</param>
        /// <returns></returns> 
        [OperationContract]

        CommonService.Model.OA.O_Form GetModelByBusinessFlowformCode(Guid businessFlowform, Guid fForm, Guid O_Form_creator);
    }
}
