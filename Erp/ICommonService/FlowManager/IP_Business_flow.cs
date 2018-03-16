using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IP_Business_flow
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
        bool Exists(int P_Business_flow_id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByFkCodeAndFlowCode(Guid P_Fk_code, Guid P_Flow_code,int type);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.FlowManager.P_Business_flow model, int flowType);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.FlowManager.P_Business_flow Get(Guid P_Business_flow_code);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.FlowManager.P_Business_flow model, int type);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid businessFlowCode);

        /// <summary>
        /// 同意业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool AgreeBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser);

        /// <summary>
        /// 拒绝业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool UnAgreeBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser);

        /// <summary>
        /// 申请开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool ApplyOpenBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser);


        /// <summary>
        /// 驳回已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool RejectAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser);
        /// <summary>
        /// 获取客户正在进行的流程
        /// </summary>
        /// <param name="flowType">流程类型(案件或者商机或者客户)</param>
        /// <param name="pkCode">案件Guid或者商机Guid或者客户guid</param>
        /// <param name="pkCode">流程状态</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.FlowManager.P_Business_flow GetCustomerIngBusinessFlow(int flowType, Guid pkCode, int P_Business_state);
        /// <summary>
        /// 开启下一级流程
        /// </summary>
        /// <param name="P_Fk_code">外键(商机/案件/客户（guid）)</param>
        /// <param name="nextOrder">要开启的流程的顺序</param>
        /// <returns></returns>
        [OperationContract]
        bool StarNextFlow(Guid P_Fk_code, int nextOrder);
        /// <summary>
        /// 开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool StartAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser);

        /// <summary>
        /// 更改负责人
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessPersonCode">负责人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdatePerson(Guid businessFlowCode, Guid businessPersonCode);

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="fkCode"></param>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MoveForward(Guid fkCode, Guid businessFlowCode);

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="fkCode"></param>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MoveBackward(Guid fkCode, Guid businessFlowCode);

        /// <summary>
        /// 启动业务流程
        /// </summary>
        /// <param name="businessFlows">需要启动的业务流程集合</param>
        /// <param name="fkType">关联Guid类型：案件=153，商机=154</param>
        /// <returns></returns>
        [OperationContract]
        int StartBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlows, string fkType);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="fkCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow> GetListByFkCode(Guid fkCode);

        /// <summary>
        /// 根据业务Guid(案件Guid或者商机Guid)，获取所有存粹的业务流程集合
        /// </summary>
        /// <param name="fkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow> GetPureListByFkCode(Guid fkCode);

        /// <summary>
        /// 根据流程Guid获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow> GetListByFlowCode(Guid P_Flow_code);
        /// <summary>
        /// 通过案件Guid或商机Guid，业务流程级别获取集合
        /// </summary>
        /// <param name="fkCode">案件Guid或商机Guid</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow> GetListByFkCodeAndLevel(Guid fkCode, int level);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.FlowManager.P_Business_flow model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow> GetListByPage(CommonService.Model.FlowManager.P_Business_flow model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据案件编号获取流程
        /// </summary>
        /// <param name="fkCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow> GetListByCaseNumber(string caseNumber);
        /// <summary>
        /// 根据案件Guid和用户Guid获得可提交结案业务流程
        /// </summary>
        /// <param name="CaseCode">案件Guid</param>
        /// <param name="businessFlowPerson">当前用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.FlowManager.P_Business_flow GetModelIsCrossForm(Guid CaseCode,Guid businessFlowPerson);
    }
}
