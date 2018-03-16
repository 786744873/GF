using AppService.Model;
using CommonService.Common;
using CommonService.Model.CustomModel;
using ICommonService.CaseManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    /// <summary>
    /// 案件服务
    /// </summary>
    public class Case : ICase
    {
        /// <summary>
        /// 案件业务逻辑层
        /// </summary>
        CommonService.BLL.CaseManager.B_Case bll = new CommonService.BLL.CaseManager.B_Case();
        CommonService.BLL.FlowManager.P_Flow bllflow = new CommonService.BLL.FlowManager.P_Flow();
        CommonService.BLL.FlowManager.P_Business_flow bllbusflow = new CommonService.BLL.FlowManager.P_Business_flow();
        CommonService.BLL.FlowManager.P_Business_flow_form bllbusflowfom = new CommonService.BLL.FlowManager.P_Business_flow_form();
        CommonService.BLL.FlowManager.P_Flow_form bllflowfom = new CommonService.BLL.FlowManager.P_Flow_form();
        CommonService.BLL.Customer.V_User oBLL = new CommonService.BLL.Customer.V_User();
        CommonService.BLL.CustomerForm.F_FormProperty propertyBLL = new CommonService.BLL.CustomerForm.F_FormProperty();
        CommonService.BLL.CustomerForm.F_FormPropertyValue propertyValueBLL = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        CommonService.BLL.CustomerForm.F_FormCheck fcBLL = new CommonService.BLL.CustomerForm.F_FormCheck();
        private CommonService.BLL.CaseManager.B_CaseMaintain bllcasemantain = new CommonService.BLL.CaseManager.B_CaseMaintain();

        #region App专用 我的案件 添加案件信息
        /// <summary>
        /// App端根据权限获取案件列表
        /// </summary>
        /// <param name="user">子用户实体</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">截止位置</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="bcase">案件实体（查询条件）</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case> AppMyCase(CommonService.Model.SysManager.C_Userinfo user, int startIndex, int endIndex, string orderBy, CommonService.Model.CaseManager.B_Case bcase)
        {
            return bll.AppMyCase(user, startIndex, endIndex, orderBy, bcase);
        }

        /// <summary>
        /// App端根据权限获取案件数量
        /// </summary>
        /// <param name="user">子用户实体</param>
        /// <param name="bcase">案件实体（查询条件）</param>
        /// <returns></returns>
        public int AppMyCaseCount(CommonService.Model.SysManager.C_Userinfo user, CommonService.Model.CaseManager.B_Case bcase)
        {
            return bll.AppMyCaseCount(user, bcase);
        }

        /// <summary>
        /// 添加案件
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        public int AddCaseInfo(CommonService.Model.CaseManager.B_Case bcase)
        {
            return bll.Add(bcase);
        }

        /// <summary>
        /// 添加案件
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        public bool UpdateCaseInfo(CommonService.Model.CaseManager.B_Case bcase)
        {
            return bll.Update(bcase);
        }

        /// <summary>
        /// 案件分解添加的业务流程
        /// </summary>
        /// <param name="guid">案件code</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> DecomposeCaseLevelList(string guid)
        {
            return bllbusflow.GetListByFkCode(Guid.Parse(guid));
        }

        /// <summary>
        /// 获取任务分解业务流程中的每个阶段的所有表单未配置的
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Flow_form> DecomposeCaseLevelFormNoneSelectList(string businessFlowCode, string flowCode)
        {
            List<CommonService.Model.FlowManager.P_Flow_form> flowForms;
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms;
            flowForms = bllflowfom.GetListByFlowCode(new Guid(flowCode));
            if (!String.IsNullOrEmpty(businessFlowCode))
            {
                ArrayList flowformsArrays = new ArrayList();
                businessFlowForms = bllbusflowfom.GetBusinessFlowForms(new Guid(businessFlowCode));
                for (int i = 0; i < flowForms.Count(); i++)
                {
                    for (int j = 0; j < businessFlowForms.Count(); j++)
                    {
                        //去掉"已作废"的表单
                        if (businessFlowForms[j].P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.已作废))
                        {
                            continue;
                        }
                        if (flowForms[i].F_Form_code == businessFlowForms[j].F_Form_code)
                        {
                            flowformsArrays.Add(flowForms[i]);
                        }
                    }
                }
                if (flowformsArrays != null)
                {
                    foreach (CommonService.Model.FlowManager.P_Flow_form flowform in flowformsArrays)
                    {
                        flowForms.Remove(flowform);
                    }
                }
            }

            return flowForms;
        }

        /// <summary>
        /// 获取任务分解业务流程中的每个阶段的所有表单已经配置的
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> DecomposeCaseLevelFormHadSelectList(string businessFlowCode, string flowCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = bllbusflowfom.GetBusinessFlowForms(new Guid(businessFlowCode));
            for (int j = 0; j < businessFlowForms.Count(); j++)
            {
                //去掉"已作废"的表单
                if (businessFlowForms[j].P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.已作废))
                {
                    businessFlowForms.RemoveAt(j);
                    j--;
                }
            }

            return businessFlowForms;
        }


        /// <summary>
        /// 将表单添加到阶段中
        /// </summary>
        public int FormToAddBusinessFlowForm(string businessFlowCode, string item, string isDefault, string type, string usercode)
        {
            bool isSuccess = bllbusflowfom.ExistsByBusinessflowCodeAndFormCode(new Guid(businessFlowCode), new Guid(item));
            if (isSuccess)
            {
                return 1;
            }
            else
            {
                //排序列在业务访问层中处理
                CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = new CommonService.Model.FlowManager.P_Business_flow_form();
                businessFlowForm.P_Business_flow_form_code = Guid.NewGuid();
                businessFlowForm.P_Business_flow_code = new Guid(businessFlowCode);
                businessFlowForm.F_Form_code = new Guid(item);
                businessFlowForm.P_Business_flow_form_isDefault = isDefault == "1" ? 1 : 0;
                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.未开始);
                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未提交);
                businessFlowForm.P_Business_flow_form_isdelete = 0;
                businessFlowForm.P_Business_flow_form_creator = Guid.Parse(usercode);
                businessFlowForm.P_Business_flow_form_createTime = DateTime.Now;
                businessFlowForm.P_Business_flow_form_isPlan = false;

                return bllbusflowfom.Add(businessFlowForm, Convert.ToInt32(type));
            }
        }

        /// <summary>
        /// 更新表单的顺序
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int UpdateBusinessFlowFormOrder(List<KeyValueModel> list)
        {
            int i = 0;
            foreach (KeyValueModel item in list)
            {
                bllbusflowfom.UpdateOrder(Guid.Parse(item.Key), Convert.ToInt32(item.Value));
            }
            return i;
        }

        /// <summary>
        /// 获取表单计划
        /// </summary>
        public CommonService.Model.Customer.V_FormPlan GetPlanSet(string businessFlowCode, string businessFlowFormCode)
        {
            return bllbusflowfom.GetPlanSet(Guid.Parse(businessFlowCode), Guid.Parse(businessFlowFormCode));
        }

        /// <summary>
        /// 添加表单计划
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool OperateSavePlanSet(CommonService.Model.Customer.V_FormPlan v_FormPlan, string type)
        {
            return bllbusflowfom.OperateSavePlanSet(v_FormPlan, type);
        }



        /// <summary>
        /// 删除已经添加到阶段中的表单
        /// </summary>
        public int DeleteBusinessFlowForm(string businessFlowFormCode, string type)
        {
            if (!bllbusflowfom.GetisNoDefault(businessFlowFormCode))
            { //必填表单不能删除
                return 1;
            }
            else
            {
                bool flag = bllbusflowfom.Delete(businessFlowFormCode, int.Parse(type));
                if (flag)
                {//成功
                    return 2;
                }
                else
                {//失败
                    return 3;
                }
            }
        }

        /// <summary>
        /// 获取未选择的所有阶段信息
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Flow> GetAllNoneSelectFlow(string caseguid)
        {
            List<CommonService.Model.FlowManager.P_Flow> flows = bllflow.GetAllList();

            var businessList = bllbusflow.GetListByFkCode(Guid.Parse(caseguid));
            foreach (var item in businessList)
            {
                var mf = flows.Where(p => p.P_Flow_code == item.P_Flow_code).FirstOrDefault();
                flows.Remove(mf);
            }

            var topFlowCaseList = from allList in flows
                                  where allList.P_Flow_level == 1 && allList.P_Flow_type == Convert.ToInt32(FlowTypeEnum.案件)
                                  orderby allList.P_Flow_order ascending
                                  select allList;
            List<CommonService.Model.FlowManager.P_Flow> flowlist = new List<CommonService.Model.FlowManager.P_Flow>();
            foreach (CommonService.Model.FlowManager.P_Flow item in topFlowCaseList)
            {
                flowlist.Add(item);
            }

            return flowlist;
        }

        /// <summary>
        /// 添加案件阶段
        /// </summary>
        public int AddBusinessFlow(CommonService.Model.FlowManager.P_Business_flow bf, int type)
        {
            return bllbusflow.Add(bf, type);
        }

        /// <summary>
        /// 修改案件阶段
        /// </summary>
        public bool UpdateBusinessFlow(CommonService.Model.FlowManager.P_Business_flow bf, int type)
        {
            return bllbusflow.Update(bf, type);
        }
        /// <summary>
        /// 删除案件阶段
        /// </summary>
        public bool DeleteBusinessFlow(string guid)
        {
            return bllbusflow.Delete(Guid.Parse(guid));
        }



        /// <summary>
        /// 根据阶段与表单的中间表guid获取中间表与阶段表
        /// </summary>
        public FlowFormAndFlowEntity GetFlowFormAndFlowEntity(string guid)
        {
            CommonService.Model.FlowManager.P_Business_flow_form pff = bllbusflowfom.Get(Guid.Parse(guid));
            CommonService.Model.FlowManager.P_Business_flow businessFlow = bllbusflow.GetModel(pff.P_Business_flow_code.Value);
            FlowFormAndFlowEntity entity = new FlowFormAndFlowEntity();
            entity.setPBF(businessFlow);
            entity.setPBFF(pff);
            return entity;
        }

        #endregion







        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录（不包含隐藏控件）
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetValuesByBusinessFormCode(string guid)
        {
            return propertyBLL.GetValuesByBusinessFormCode(Guid.Parse(guid));
        }

        /// <summary>
        /// 获取表单中子列表的数据（手机专用）
        /// </summary>
        /// <param name="FormCode">表单GUID</param>
        /// <param name="FormPropertyValueCode">业务流程表单中间表GUID</param>
        /// <returns>数据列表</returns>
        public List<List<CommonService.Model.CustomerForm.F_FormProperty>> GetAppDetailsList(string FormCode, string FormPropertyValueCode, string FormPropertyCode)
        {
            return propertyValueBLL.GetAppDetailsList(new Guid(FormCode), new Guid(FormPropertyValueCode), new Guid(FormPropertyCode)); 
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="formChecks">根据表单生成的审核表数据</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <returns>1代表成功 0代表代表没有符合条件可以提交的表单 -1代表提交表单所属业务流程及其父级业务流程线上的业务负责人尚未设置</returns>
        public int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType)
        {
            return fcBLL.SubmitForm(formChecks, fkType);
        }

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">根据表单生成的审核表数据</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <returns>1代表成功 0代表没有符合条件可以审核的表单 -1代表提交表单所属业务流程及其父级业务流程线上的业务负责人尚未设置</returns>
        public int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType)
        {
            return fcBLL.CheckForm(formChecks, fkType);
        }





        public List<CommonService.Model.CustomModel.KeyValueModel> GetFactAndPlanTime(string formCode, string businessFlowFormCode)
        {
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = propertyBLL.GetEditFormPropertyValueList(new Guid(formCode), new Guid(businessFlowFormCode));
            List<CommonService.Model.CustomModel.KeyValueModel> kmlist = new List<KeyValueModel>();
            if (formPropertys != null && formPropertys.Count > 0)
            {
                //计划开始时间
                var jhmodel_1 = formPropertys.Where(p => p.F_FormProperty_showName == "计划开始时间").FirstOrDefault();
                if (jhmodel_1 != null)
                {
                    KeyValueModel kvm = new KeyValueModel();
                    kvm.Key = "planstart";
                    if (!String.IsNullOrEmpty(jhmodel_1.V_FormPropertyValue_Value))
                    {
                        kvm.values=DateTime.Parse(jhmodel_1.V_FormPropertyValue_Value).ToString("yyyy/MM/dd HH:mm");
                    }
                    else
                    {
                        kvm.values="";
                    }
                    kmlist.Add(kvm);
                } 


                //计划结束时间
                var jhmodel_2 = formPropertys.Where(p => p.F_FormProperty_showName == "计划结束时间").FirstOrDefault();
                if (jhmodel_2 != null)
                {
                    KeyValueModel kvm = new KeyValueModel();
                    kvm.Key = "planend";
                    if (!String.IsNullOrEmpty(jhmodel_2.V_FormPropertyValue_Value))
                    {
                        kvm.values = DateTime.Parse(jhmodel_2.V_FormPropertyValue_Value).ToString("yyyy/MM/dd HH:mm");
                    }
                    else
                    {
                        kvm.values = "";
                    }
                    kmlist.Add(kvm);
                }
                //实际开始时间
                var jhmodel_3 = formPropertys.Where(p => p.F_FormProperty_showName == "实际开始时间").FirstOrDefault();
                if (jhmodel_3 != null)
                {
                    KeyValueModel kvm = new KeyValueModel();
                    kvm.Key = "factstart";
                    if (!String.IsNullOrEmpty(jhmodel_3.V_FormPropertyValue_Value))
                    {
                        kvm.values = DateTime.Parse(jhmodel_3.V_FormPropertyValue_Value).ToString("yyyy/MM/dd HH:mm");
                    }
                    else
                    {
                        kvm.values = "";
                    }
                    kmlist.Add(kvm);
                }

                //实际结束时间
                var jhmodel_4 = formPropertys.Where(p => p.F_FormProperty_showName == "实际结束时间").FirstOrDefault();
                if (jhmodel_4 != null)
                {
                    KeyValueModel kvm = new KeyValueModel();
                    kvm.Key = "factend";
                    if (!String.IsNullOrEmpty(jhmodel_4.V_FormPropertyValue_Value))
                    {
                        kvm.values = DateTime.Parse(jhmodel_4.V_FormPropertyValue_Value).ToString("yyyy/MM/dd HH:mm");
                    }
                    else
                    {
                        kvm.values = "";
                    }
                    kmlist.Add(kvm);
                }
            }
            else
            {
                KeyValueModel kvm = new KeyValueModel();
                kvm.values = "";
                kvm.Key = "planstart";
                kmlist.Add(kvm);
                kvm = new KeyValueModel();
                kvm.values = "";
                kvm.Key = "planend";
                kmlist.Add(kvm);
                kvm = new KeyValueModel();
                kvm.values = "";
                kvm.Key = "factstart";
                kmlist.Add(kvm);
                kvm = new KeyValueModel();
                kvm.values = "";
                kvm.Key = "factend";
                kmlist.Add(kvm);
            }

            return kmlist;

        }




        /// <summary>
        /// 根据业务流程表单关联Guid，获取提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecord(string businessFlowFormCode)
        {
            return fcBLL.GetFirstTimeFormCheckRecord(Guid.Parse(businessFlowFormCode));
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取审核记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFormCheckRecord(string businessFlowFormCode)
        {
            return fcBLL.GetFormCheckRecord(Guid.Parse(businessFlowFormCode));
        }

        /// <summary>
        /// 获取监控中心横向列表数量
        /// </summary>
        /// <param name="userGuid">用户GUID</param>
        /// <param name="RoleId">用户角色</param>
        /// <param name="deptCode">用户部门ID</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomModel.KeyValueModel> GetMonitorCase(string userGuid, string RoleId, string deptCode)
        {
            return bll.GetMonitorCase(new Guid(userGuid), Convert.ToInt32(RoleId), new Guid(deptCode));
        }


        /// <summary>
        /// 根据用户GUID获取他应该审核的案件
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns>案件列表</returns>
        public List<CommonService.Model.CaseManager.B_Case> GetPendingCase(CommonService.Model.SysManager.C_Userinfo user, string startIndex, string endIndex, CommonService.Model.CaseManager.B_Case bcase)
        {
            return bll.GetPendingCase(bcase, user.C_Userinfo_code, Convert.ToInt32(startIndex), Convert.ToInt32(endIndex));
        }

        /// <summary>
        /// 根据用户GUID获取他应该审核的案件
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns>案件列表</returns>
        public int GetPendingCaseCount(CommonService.Model.SysManager.C_Userinfo user, string startIndex, string endIndex, CommonService.Model.CaseManager.B_Case bcase)
        {
            return bll.GetPendingCase(bcase, user.C_Userinfo_code, 0, 0).Count;
        }




        /// <summary>
        /// 获取自定义数据列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomModel.KeyValueModel> GetParameters(string tableName, string searchName, string startIndex, string endIndex)
        {
            return propertyValueBLL.GetParameters(tableName, searchName, startIndex, endIndex);
        }

        /// <summary>
        /// 通过表单获取关联数据（App专用）
        /// </summary>
        /// <param name="formCode">表单GUID</param>
        /// <param name="formPropertyCode">表单属性GUID</param>
        /// <param name="businessFlowFormCode">业务流程表单关联GUID</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomModel.KeyValueModel> GetParametersByForm(string formCode, string formPropertyCode, string businessFlowFormCode)
        {
            return propertyValueBLL.GetParametersByForm(formCode, formPropertyCode, businessFlowFormCode);
        }

        /// <summary>
        /// 更新表单值
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单GUID</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public bool UpdateFormValue(CommonService.Model.CustomModel.KeyValueModel keyvalue)
        {
            string businessFlowFormCode = keyvalue.Key;
            string value = keyvalue.Value;
            string type = keyvalue.Id;
            if (type.Equals("1"))
            {
                byte[] bpath = Convert.FromBase64String(value);
                string strPath = System.Text.ASCIIEncoding.Default.GetString(bpath);
                return propertyValueBLL.UpdateFormValue(Guid.Parse(businessFlowFormCode), strPath);
            }
            else
            {
                return propertyValueBLL.UpdateFormValue(Guid.Parse(businessFlowFormCode), value);
            }

        }

        /// <summary>
        /// 获得属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyParent">父亲属性Guid</param>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetPropertyByParent(string formCode, string formPropertyParent)
        {
            return propertyBLL.GetModelList(new Guid(formCode), new Guid(formPropertyParent));
        }

        /// <summary>
        /// 添加属性值
        /// </summary>
        /// <param name="list"></param>
        public bool AddPropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                propertyValueBLL.Add(item);
                count++;
            }
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 更新属性值
        /// </summary>
        /// <param name="list"></param>
        public bool UpdatePropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                propertyValueBLL.UpdateFormValue(item.F_FormPropertyValue_id, item.F_FormPropertyValue_value);
                count++;
            }

            return count > 0 ? true : false;
        }

        /// <summary>
        /// 启动案件
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns>-2代表此案件沒有配置阶段，无法启动;-1代表已启动，不可以重复启动;0代表案件启动失败;1代表案件启动成功</returns>
        public int AppStartCase(string caseCode, string startPersonCode)
        {
            return bll.AppStartCase(caseCode, startPersonCode);
        }

        /// <summary>
        /// 开启单个业务流程
        /// </summary>     
        /// <param name="fkType">业务类型：153、案件 154、商机</param>
        /// <param name="fkCode">业务Guid：案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns>1代表成功 0代表没有符合条件可以开启的业务流程</returns>       
        public int StartSingleBusinessFlow(string fkType, string fkCode, string businessFlowCode, string loginChildrenUser)
        {
            return bll.AppStartSingleBusinessFlow(fkType, fkCode, businessFlowCode, loginChildrenUser);
        }

        /// <summary>
        /// 根据groupCode删除表单子列表数据
        /// </summary>
        /// <param name="groupCode">分组GUID</param>
        /// <returns></returns>
        public int AppDeleteDetailsById(string id)
        {
            return propertyValueBLL.AppDeleteDetailsByGroupCode(Convert.ToInt32(id));
        }


        /// <summary>
        /// 更新预期收益计算接口
        /// </summary>
        /// <param name="list"></param>
        public bool UpdateExpectedReturnPropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list, int type)
        {
            return propertyValueBLL.UpdateExpectedReturnPropertyValues(list, type);
        }


        /// <summary>
        /// 根据案件编码获取专业顾问、专家部长、首席专家
        /// </summary>
        /// <param name="caseCode">案件GUID</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomModel.KeyValueModel> GetPersonByCaseCode(string caseCode)
        {
            return bll.GetPersonByCaseCode(caseCode);
        }

        /// <summary>
        /// 根据案件编码获取案件详细信息
        /// </summary>
        /// <param name="caseCode">案件GUID</param>
        /// <returns></returns>
        public CommonService.Model.CaseManager.B_Case GetCaseByCaseCode(string caseCode)
        {
            return bll.GetModel(Guid.Parse(caseCode));
        }

        /// <summary>
        /// 获取最后一次提交的审核列表
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> AppGetCheckList(string guid)
        {
            return fcBLL.AppGetCheckList(Guid.Parse(guid));
        }




        //查询案件的维护信息
        public List<CommonService.Model.CaseManager.B_CaseMaintain> GetCaseMaintainInfoList(CommonService.Model.CaseManager.B_CaseMaintain model,int startindex,int endindex,string orderby)
        {
            List<CommonService.Model.CaseManager.B_CaseMaintain> bank = bllcasemantain.GetListByPage(model, orderby, startindex, endindex);
            return bank;
        }

        /// <summary>
        /// 新增案件维护信息
        /// </summary>
        /// <param name="model2">案件维护实体</param>
        /// <returns></returns>
        public int AddCaseMaintainInfo(CommonService.Model.CaseManager.B_CaseMaintain model2)
        {
            return bllcasemantain.Add(model2);
        }

        /// <summary>
        /// 删除案件维护信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool CaseMaintainDelete(string id)
        {
            return bllcasemantain.Delete(Convert.ToInt32(id));
        }

        /// <summary>
        /// 修改案件维护信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool CaseMaintainUpdate(CommonService.Model.CaseManager.B_CaseMaintain model)
        {
            return bllcasemantain.Update(model);
        }

    }
}
