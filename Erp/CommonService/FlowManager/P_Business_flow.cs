using ICommonService.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Business_flow”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Business_flow.svc 或 P_Business_flow.svc.cs，然后开始调试。
    public class P_Business_flow : IP_Business_flow
    {
        CommonService.BLL.FlowManager.P_Business_flow bll = new CommonService.BLL.FlowManager.P_Business_flow();
        /// <summary>
        /// 得到最大ID 
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="P_Business_flow_id"></param>
        /// <returns></returns>
        public bool Exists(int P_Business_flow_id)
        {
            return bll.Exists(P_Business_flow_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByFkCodeAndFlowCode(Guid P_Fk_code, Guid P_Flow_code,int type)
        {
            return bll.ExistsByFkCodeAndFlowCode(P_Fk_code, P_Flow_code,type);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.FlowManager.P_Business_flow model, int flowType)
        {
            return bll.Add(model, flowType);
        }
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow Get(Guid P_Business_flow_code)
        {
            return bll.GetModel(P_Business_flow_code);
        }

        /// <summary>
        /// 更改负责人
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessPersonCode">负责人Guid</param>
        /// <returns></returns>
        public bool UpdatePerson(Guid businessFlowCode, Guid businessPersonCode)
        {
            return bll.UpdatePerson(businessFlowCode, businessPersonCode);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.FlowManager.P_Business_flow model, int type)
        {
            return bll.Update(model, type);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        public bool Delete(Guid businessFlowCode)
        {
            return bll.Delete(businessFlowCode);
        }

        /// <summary>
        /// 同意业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>       
        public bool AgreeBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            return bll.AgreeBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
        }

        /// <summary>
        /// 拒绝业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>       
        public bool UnAgreeBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            return bll.UnAgreeBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
        }

        /// <summary>
        /// 申请开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>       
        public bool ApplyOpenBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            return bll.ApplyOpenBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
        }

        /// <summary>
        /// 驳回已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>       
        public bool RejectAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            return bll.RejectAppliedBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
        }

        /// <summary>
        /// 开启已申请业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>       
        public bool StartAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            return bll.StartAppliedBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="fkCode">业务外键Guid</param>          
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public bool MoveForward(Guid fkCode, Guid businessFlowCode)
        {
            return bll.MoveForward(fkCode, businessFlowCode);
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="fkCode">业务外键Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>      
        /// <returns></returns>
        public bool MoveBackward(Guid fkCode, Guid businessFlowCode)
        {
            return bll.MoveBackward(fkCode, businessFlowCode);
        }
        /// <summary>
        /// 启动业务流程
        /// </summary>
        /// <param name="businessFlows">需要启动的业务流程集合</param>
        /// <returns></returns>     
        public int StartBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlows, string fkType)
        {
            return bll.StartBusinessFlow(businessFlows, fkType);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="fkCode">关联案件或商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByFkCode(Guid fkCode)
        {
            return bll.GetListByFkCode(fkCode);
        }

        /// <summary>
        /// 根据业务Guid(案件Guid或者商机Guid)，获取所有存粹的业务流程集合
        /// </summary>
        /// <param name="fkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetPureListByFkCode(Guid fkCode)
        {
            return bll.GetPureListByFkCode(fkCode);
        }

        /// <summary>
        /// 通过案件Guid或商机Guid，业务流程级别获取集合
        /// </summary>
        /// <param name="fkCode">案件Guid或商机Guid</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByFkCodeAndLevel(Guid fkCode, int level)
        {
            return bll.GetListByFkCodeAndLevel(fkCode, level);
        }
        /// <summary>
        /// 根据流程Guid获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByFlowCode(Guid P_Flow_code)
        {
            return bll.GetListByFlowCode(P_Flow_code);
        }
        /// <summary>
        /// 获取客户正在进行的流程
        /// </summary>
        /// <param name="flowType">流程类型(案件或者商机或者客户)</param>
        /// <param name="pkCode">案件Guid或者商机Guid或者客户guid</param>
        /// <param name="pkCode">流程状态</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetCustomerIngBusinessFlow(int flowType, Guid pkCode, int P_Business_state)
        {
            return bll.GetCustomerIngBusinessFlow(flowType, pkCode, P_Business_state);
        }
        /// <summary>
        /// 开启下一级流程
        /// </summary>
        /// <param name="P_Fk_code">外键(商机/案件/客户（guid）)</param>
        /// <param name="nextOrder">要开启的流程的顺序</param>
        /// <returns></returns>
        public bool StarNextFlow(Guid P_Fk_code, int nextOrder)
        {
            return bll.StarNextFlow(P_Fk_code, nextOrder);
        }
        /// <summary>
        /// 获取记录总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.FlowManager.P_Business_flow model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.FlowManager.P_Business_flow> GetListByPage(Model.FlowManager.P_Business_flow model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }


        /// <summary>
        /// 根据案件编号获取流程
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        public List<Model.FlowManager.P_Business_flow> GetListByCaseNumber(string caseNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据案件Guid和用户Guid获得可提交结案业务流程
        /// </summary>
        /// <param name="CaseCode">案件Guid</param>
        /// <param name="businessFlowPerson">当前用户Guid</param>
        /// <returns></returns>
        public Model.FlowManager.P_Business_flow GetModelIsCrossForm(Guid CaseCode, Guid businessFlowPerson)
        {
            return bll.GetModelIsCrossForm(CaseCode,businessFlowPerson);
        }
    }
}
