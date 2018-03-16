using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Milepost.Controllers
{
    public class MilepostController : BaseController
    {
        private readonly ICommonService.Milepost.IJ_Milepost Imilepost;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;



        public MilepostController()
        {
            #region 服务初始化
            Imilepost = ServiceProxyFactory.Create<ICommonService.Milepost.IJ_Milepost>("MilepostWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            #endregion
        }

        //
        // GET: /Milepost/NoMilepost/
        public ActionResult List(FormCollection form, int? page = 1)
        {


            return View();
        }

        public ActionResult MilepostList(FormCollection form, int J_Milepost_Type, string J_Milepost_AuditorName, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //非里程碑查询模型
            CommonService.Model.Milepost.J_Milepost roleConditon = new CommonService.Model.Milepost.J_Milepost();

            //if (!String.IsNullOrEmpty(form["C_Roles_name"]))
            //{//角色名称查询条件
            //    roleConditon.C_Roles_name = form["C_Roles_name"].Trim(); ;
            //}
            if (!String.IsNullOrEmpty(form["J_Milepost_JTime"]))
            {//稽核时间
                roleConditon.J_Milepost_JTime = Convert.ToDateTime(form["J_Milepost_JTime"]);
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_JTime1"]))
            {//稽核时间1
                roleConditon.J_Milepost_JTime1 = Convert.ToDateTime(form["J_Milepost_JTime1"]);
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_clientRival"]))
            {//委托人/对方当事人
                roleConditon.J_Milepost_clientRival = form["J_Milepost_clientRival"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_CaseNumber"]))
            {//案号
                roleConditon.J_Milepost_CaseNumber = form["J_Milepost_CaseNumber"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_sponsorlawyer"]))
            {//主办律师
                roleConditon.J_Milepost_sponsorlawyer = form["J_Milepost_sponsorlawyer"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_Colawyer"]))
            {//协办律师
                roleConditon.J_Milepost_Colawyer = form["J_Milepost_Colawyer"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_AuditorName"]))
            {//稽核人
                roleConditon.J_Milepost_AuditorName = form["J_Milepost_AuditorName"].Trim();
            }
            if (J_Milepost_Type != null)
            {
                roleConditon.J_Milepost_Type = J_Milepost_Type;
            }
            if (roleConditon.J_Milepost_Type != null)
            {
                this.AddressUrlParameters = "?J_Milepost_Type=" + roleConditon.J_Milepost_Type;
            }
            #region 如果此触发点来自其它快捷方式，(比如从案件列表中，导航过来),需要处理里面的业务逻辑
            if (Request.QueryString["pkCode"] != null)
            {
                var caseModel = _caseWCF.GetModel(Guid.Parse(Request.QueryString["pkCode"]));
                if (caseModel != null)
                {//这里加入案号条件
                    roleConditon.J_Milepost_CaseNumber = caseModel.B_Case_number;
                    this.AddressUrlParameters += "&pkCode=" + Request.QueryString["pkCode"];
                }
            }
            #endregion
            
            roleConditon.J_Milepost_AuditorName = J_Milepost_AuditorName;
            //角色查询模型传递到前端视图中
            ViewBag.RoleConditon = roleConditon;
            ViewBag.J_Milepost_Type = roleConditon.J_Milepost_Type;
            ViewBag.J_Milepost_AuditorName = J_Milepost_AuditorName;
            #endregion

            //获取角色总记录数
            this.TotalRecordCount = Imilepost.GetRecordCount(roleConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, this.SwitchLoginDept());

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 15;

            //获取角色数据信息
            List<CommonService.Model.Milepost.J_Milepost> MilepostList = Imilepost.GetListByPage(roleConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, this.SwitchLoginDept());

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(MilepostList);
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int J_Milepost_Type, string casecode)
        {
            //创建初始化角色实体
            CommonService.Model.Milepost.J_Milepost No_Milepost = new CommonService.Model.Milepost.J_Milepost();
            No_Milepost.J_Milepost_isDelete = false;
            No_Milepost.J_Milepost_AuditorName = Context.UIContext.Current.UserName;
            No_Milepost.J_Milepost_Auditor = Context.UIContext.Current.UserCode.Value;
            No_Milepost.J_Milepost_createTime = DateTime.Now;
            No_Milepost.J_Milepost_Type = J_Milepost_Type;
            ViewBag.IsPreSetManager = UIContext.Current.IsPreSetManager;        
            ViewBag.UserCode = UIContext.Current.UserCode;
            ViewBag.PostCode = UIContext.Current.PostCode;
            ViewBag.OrgCode = UIContext.Current.OrgCode;
            ViewBag.IsMessage = false;

            if (casecode != null && casecode != "")
            {
                var casemodel = _caseWCF.GetModel(Guid.Parse(casecode));
                if (casemodel != null)
                {
                    No_Milepost.J_Milepost_CaseNumber = casemodel.B_Case_number;
                    ViewBag.CaseCode = casemodel.B_Case_code;
                }
            }


            return View(No_Milepost);
        }
        
        public ActionResult edit(int J_Milepost_id)
        {
            var MilepostModel = Imilepost.GetModel(J_Milepost_id);
            ViewBag.IsPreSetManager = UIContext.Current.IsPreSetManager;          
            ViewBag.UserCode = UIContext.Current.UserCode;
            ViewBag.PostCode = UIContext.Current.PostCode;
            ViewBag.OrgCode = UIContext.Current.OrgCode;
            ViewBag.IsMessage = false;
            ViewBag.CaseCode = _caseWCF.GetModelList(" B_Case_number='" + MilepostModel.J_Milepost_CaseNumber + "'")[0].B_Case_code;
            return View("Create", MilepostModel);
        }

        public ActionResult MessageEdit(int J_Milepost_id)
        {
            var MilepostModel = Imilepost.GetModel(J_Milepost_id);
            ViewBag.IsPreSetManager = UIContext.Current.IsPreSetManager;         
            ViewBag.UserCode = UIContext.Current.UserCode;
            ViewBag.PostCode = UIContext.Current.PostCode;
            ViewBag.OrgCode = UIContext.Current.OrgCode;
            ViewBag.IsMessage = true;
            ViewBag.CaseCode = _caseWCF.GetModelList(" B_Case_number='" + MilepostModel.J_Milepost_CaseNumber + "'")[0].B_Case_code;
            return View("Create", MilepostModel);
        }

        /// <summary>
        /// 详细
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultLayout(int J_Milepost_id)
        {
            var MilepostModel = Imilepost.GetModel(J_Milepost_id);
            ViewBag.IsPreSetManager = UIContext.Current.IsPreSetManager;         
            ViewBag.UserCode = UIContext.Current.UserCode;
            ViewBag.PostCode = UIContext.Current.PostCode;
            ViewBag.OrgCode = UIContext.Current.OrgCode;
            ViewBag.IsMessage = true;
            ViewBag.CaseCode = _caseWCF.GetModelList(" B_Case_number='" + MilepostModel.J_Milepost_CaseNumber + "'")[0].B_Case_code;
            return View(MilepostModel);      
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.Milepost.J_Milepost no_Milepost)
        {
            //服务方法调用
            int meno_MilepostnuId = 0;
            //添加稽查
            no_Milepost.J_Milepost_AdStatus = 1;
            no_Milepost.J_Milepost_Z_AdStatus = 1;
            no_Milepost.J_Milepost_Dep_AdStatus = 1;

            if (no_Milepost.J_Milepost_id > 0)
            {//修改
                bool isUpdateSuccess = Imilepost.Update(no_Milepost);
                if (isUpdateSuccess)
                {
                    meno_MilepostnuId = no_Milepost.J_Milepost_id;
                }
            }
            else
            {//添加
                meno_MilepostnuId = Imilepost.Add(no_Milepost);
            }

            if (meno_MilepostnuId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑


                var caseModel = _caseWCF.GetModelList(" B_Case_number='" + no_Milepost.J_Milepost_CaseNumber + "'")[0];





                //根据级别选择不同接收人
                if (no_Milepost.J_Milepost_ZUserinfo_code != null && no_Milepost.J_Milepost_ZUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    //先向消息表中添加消息
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);


                    msgModel.C_Messages_link = caseModel.B_Case_code.Value;

                    msgModel.C_Messages_content = meno_MilepostnuId.ToString();
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = no_Milepost.J_Milepost_ZUserinfo_code;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                }
                if (no_Milepost.J_Milepost_DepUserinfo_code != null && no_Milepost.J_Milepost_DepUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    //先向消息表中添加消息
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);


                    msgModel.C_Messages_link = caseModel.B_Case_code.Value;

                    msgModel.C_Messages_content = meno_MilepostnuId.ToString();
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = no_Milepost.J_Milepost_DepUserinfo_code;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                }
                if (no_Milepost.J_Milepost_GenerUserinfo_code != null && no_Milepost.J_Milepost_GenerUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {  //先向消息表中添加消息
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);


                    msgModel.C_Messages_link = caseModel.B_Case_code.Value;

                    msgModel.C_Messages_content = meno_MilepostnuId.ToString();
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = no_Milepost.J_Milepost_GenerUserinfo_code;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                }











                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存稽查信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存稽查信息成功", "/Milepost/NoMilepost/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存稽查信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存稽查信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        [HttpPost]
        public int TJ_Ck(int J_Milepost_id, string J_Milepost_TJMessageType, string J_Milepost_TJMessageContent, int Number)
        {
            var model = Imilepost.GetModel(J_Milepost_id);

            if (Number == 0)
            {
                model.J_Milepost_Z_TJMessageType = J_Milepost_TJMessageType;
                model.J_Milepost_Z_TJMessageContent = J_Milepost_TJMessageContent;
            }
            else if (Number == 1)
            {
                model.J_Milepost_Dep_TJMessageType = J_Milepost_TJMessageType;
                model.J_Milepost_Dep_TJMessageContent = J_Milepost_TJMessageContent;
            }
            else
            {
                model.J_Milepost_TJMessageType = J_Milepost_TJMessageType;
                model.J_Milepost_TJMessageContent = J_Milepost_TJMessageContent;
            }

            //获取案件
            var caseModelN = _caseWCF.GetModelList(" B_Case_number='" + model.J_Milepost_CaseNumber + "'")[0];
            var caseModel = _caseWCF.GetModel(caseModelN.B_Case_code.Value);
            //确认稽查
            if (model.J_Milepost_Z_TJMessageType == "不同意" || model.J_Milepost_Dep_TJMessageType == "不同意" || model.J_Milepost_TJMessageType == "不同意")
            {
                if (Number == 0)
                {
                    model.J_Milepost_Z_AdStatus = 2;
                }
                else if (Number == 1)
                {
                    model.J_Milepost_Dep_AdStatus = 2;
                }
                model.J_Milepost_AdStatus = 2;

                //判断，当被稽查的人是分公司总经理的时候
                if (model.J_Milepost_GenerUserinfo_code != null && model.J_Milepost_GenerUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    //推送消息给研究院院长
                    var UModel = _userinfoWCF.GetUsersByOrgAndPost(Guid.Parse(NoMilepostController.Y_FrameCode), Guid.Parse(NoMilepostController.Y_PostCode), "")[0];
                    //先向消息表中添加消息
                    if (UModel != null)
                    {
                        CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                        msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);
                        msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                        msgModel.C_Messages_content = model.J_Milepost_id.ToString();
                        msgModel.C_Messages_createTime = DateTime.Now;
                        msgModel.C_Messages_person = UModel.C_Userinfo_code;
                        msgModel.C_Messages_isRead = 0;
                        msgModel.C_Messages_isValidate = 1;
                        _messageWCF.Add(msgModel);
                    }
                }
                else
                {
                    //当稽核对象有多个的时候必须多个人全部发表意见才能消息推送给首席
                    int number1 = 0;
                    int number2 = 0;
                    if (model.J_Milepost_ZUserinfo_code != null && model.J_Milepost_ZUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                    {
                        number1++;
                    } if (model.J_Milepost_DepUserinfo_code != null && model.J_Milepost_DepUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                    {
                        number1++;
                    } if (model.J_Milepost_GenerUserinfo_code != null && model.J_Milepost_GenerUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                    {
                        number1++;
                    }
                    if (model.J_Milepost_Z_TJMessageType != null && model.J_Milepost_Z_TJMessageType != "")
                    {
                        number2++;
                    } if (model.J_Milepost_Dep_TJMessageType != null && model.J_Milepost_Dep_TJMessageType != "")
                    {
                        number2++;
                    } if (model.J_Milepost_TJMessageType != null && model.J_Milepost_TJMessageType != "")
                    {
                        number2++;
                    }

                    if (number1 == number2)
                    {

                        #region 新推送消息给首席专家
                        CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                        msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);
                        msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                        msgModel.C_Messages_content = model.J_Milepost_id.ToString();
                        msgModel.C_Messages_createTime = DateTime.Now;
                        msgModel.C_Messages_person = caseModel.B_Case_firstClassResponsiblePerson;
                        msgModel.C_Messages_isRead = 0;
                        msgModel.C_Messages_isValidate = 1;
                        _messageWCF.Add(msgModel);
                        #endregion
                    }
                }
            }
            else
            {
                //当稽核对象有多个的时候必须多个人全部发表意见才能消息推送给首席
                int number1 = 0;
                int number2 = 0;
                if (model.J_Milepost_ZUserinfo_code != null && model.J_Milepost_ZUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    number1++;
                } if (model.J_Milepost_DepUserinfo_code != null && model.J_Milepost_DepUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    number1++;
                } if (model.J_Milepost_GenerUserinfo_code != null && model.J_Milepost_GenerUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    number1++;
                }
                if (model.J_Milepost_Z_TJMessageType != null && model.J_Milepost_Z_TJMessageType != "")
                {
                    number2++;
                } if (model.J_Milepost_Dep_TJMessageType != null && model.J_Milepost_Dep_TJMessageType != "")
                {
                    number2++;
                } if (model.J_Milepost_TJMessageType != null && model.J_Milepost_TJMessageType != "")
                {
                    number2++;
                }

                if (number1 == number2)
                {
                    ////成功，推送消息给总经理
                    model.J_Milepost_AdStatus = 3;
                    //获得总经理用户
                    #region

                    //判断，当被稽查的人是分公司总经理的时候
                    if (model.J_Milepost_GenerUserinfo_code != null)
                    {
                        ////成功，推送消息给总经理   
                        //获得总经理用户
                        var UModel = _userinfoWCF.GetUsersByOrgAndPost(Guid.Parse(NoMilepostController.Z_FrameCode), Guid.Parse(NoMilepostController.Z_PostCode), "")[0];
                        //先向消息表中添加消息
                        if (UModel != null)
                        {
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);


                            msgModel.C_Messages_link = caseModel.B_Case_code.Value;

                            msgModel.C_Messages_content = model.J_Milepost_id.ToString();
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = UModel.C_Userinfo_code;
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            _messageWCF.Add(msgModel);
                        }

                    }
                    else
                    {
                        #region
                        Guid OrganizationCode = Guid.NewGuid();
                        switch (caseModel.C_Region_name)
                        {
                            case "长沙市":
                                {
                                    //C6790683-7B0E-4DEF-9593-4E24E9325137 湖南省的GUID
                                    OrganizationCode = Guid.Parse(NoMilepostController.F_changsha);
                                }
                                break;

                            case "成都市":
                                {
                                    //49CF1538-167A-4408-BE83-7DA3897621E9
                                    OrganizationCode = Guid.Parse(NoMilepostController.F_chengdu);
                                }
                                break;
                            case "重庆市":
                                {
                                    //315CAD78-36EA-4C63-B135-EF89AA4CA838
                                    OrganizationCode = Guid.Parse(NoMilepostController.F_chongqing);
                                }
                                break;
                            case "北京市":
                                {
                                    //5EE72657-2993-450D-BB65-FDC66C3E4B06
                                    OrganizationCode = Guid.Parse(NoMilepostController.F_beijing);
                                }
                                break;

                        }
                        var UModel = _userinfoWCF.GetUsersByOrgAndPost(OrganizationCode, Guid.Parse(NoMilepostController.F_PostCode), "")[0];
                        //先向消息表中添加消息
                        if (UModel != null)
                        {
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);


                            msgModel.C_Messages_link = caseModel.B_Case_code.Value;

                            msgModel.C_Messages_content = model.J_Milepost_id.ToString();
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = UModel.C_Userinfo_code;
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            _messageWCF.Add(msgModel);
                        }

                        #endregion
                    }
                    #endregion
                }
            }


            bool isUpdateSuccess = Imilepost.Update(model);
            if (isUpdateSuccess)
                return 1;
            else
                return 0;
        }
        
        /// <summary>
        /// 裁决
        /// </summary>
        /// <param name="J_Milepost_id"></param>
        /// <param name="J_Milepost_AdMessageType"></param>
        /// <param name="J_Milepost_AdMessageContent"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int JC_Ck(int Status, CommonService.Model.Milepost.J_Milepost no_Milepost)
        {
            var model = Imilepost.GetModel(no_Milepost.J_Milepost_id);
            model.J_Milepost_AdMessageType = no_Milepost.J_Milepost_AdMessageType;
            model.J_Milepost_AdMessageContent = no_Milepost.J_Milepost_AdMessageContent;
            model.J_Milepost_AdStatus = Status;
            ///裁决修改信息
            if (model.J_Milepost_AdMessageType == "修改稽查信息")
            {
                model.J_Milepost_DocumentPo = no_Milepost.J_Milepost_DocumentPo;
                model.J_Milepost_Filing = no_Milepost.J_Milepost_Filing;
                model.J_Milepost_Preservation = no_Milepost.J_Milepost_Preservation;
                model.J_Milepost_Firstcomplete = no_Milepost.J_Milepost_Firstcomplete;
                model.J_Milepost_Firstinstance = no_Milepost.J_Milepost_Firstinstance;
                model.J_Milepost_Conciliation = no_Milepost.J_Milepost_Conciliation;
                model.J_Milepost_Prosecution = no_Milepost.J_Milepost_Prosecution;
                model.J_Milepost_Verdict = no_Milepost.J_Milepost_Verdict;
                model.J_Milepost_ProgramScoreY = no_Milepost.J_Milepost_ProgramScoreY;
                model.J_Milepost_ProgramScoreS = no_Milepost.J_Milepost_ProgramScoreS;
                model.J_Milepost_EntityScore = no_Milepost.J_Milepost_EntityScore;
                model.J_Milepost_CaseScore = no_Milepost.J_Milepost_CaseScore;

                if (no_Milepost.J_Milepost_ZUserinfo_code.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    //备用
                    model.J_Milepost_Z_AdMessageContent = model.J_Milepost_ZUserinfo_code.ToString();
                    model.J_Milepost_ZUserinfo_code = Guid.Parse("00000000-0000-0000-0000-000000000000");
                }
                else
                {
                    model.J_Milepost_ZUserinfo_code = no_Milepost.J_Milepost_ZUserinfo_code;
                }
                if (no_Milepost.J_Milepost_XUserinfo_code.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    //备用
                    model.J_Milepost_Z_AdMessageType = model.J_Milepost_ZUserinfo_code.ToString();
                    model.J_Milepost_XUserinfo_code = Guid.Parse("00000000-0000-0000-0000-000000000000");
                }
                else
                {
                    model.J_Milepost_XUserinfo_code = no_Milepost.J_Milepost_XUserinfo_code;
                }

                if (no_Milepost.J_Milepost_DepUserinfo_code.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    //备用
                    model.J_Milepost_Dep_AdMessageContent = model.J_Milepost_DepUserinfo_code.ToString();
                    model.J_Milepost_DepUserinfo_code = Guid.Parse("00000000-0000-0000-0000-000000000000");
                }
                else
                {
                    model.J_Milepost_DepUserinfo_code = no_Milepost.J_Milepost_DepUserinfo_code;
                }
            }

            //获取案件
            var caseModelN = _caseWCF.GetModelList(" B_Case_number='" + model.J_Milepost_CaseNumber + "'")[0];
            var caseModel = _caseWCF.GetModel(caseModelN.B_Case_code.Value);

            if (model.J_Milepost_GenerUserinfo_code != null && model.J_Milepost_GenerUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                //获得总经理用户
                var UModel = _userinfoWCF.GetUsersByOrgAndPost(Guid.Parse(NoMilepostController.Z_FrameCode), Guid.Parse(NoMilepostController.Z_PostCode), "")[0];
                //先向消息表中添加消息
                if (UModel != null)
                {
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);
                    msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                    msgModel.C_Messages_content = model.J_Milepost_id.ToString();
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = UModel.C_Userinfo_code;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                }
            }
            else
            {
                //推送给分总
                Guid OrganizationCode = Guid.NewGuid();
                switch (caseModel.C_Region_name)
                {
                    case "长沙市":
                        {
                            //C6790683-7B0E-4DEF-9593-4E24E9325137 湖南省的GUID
                            OrganizationCode = Guid.Parse(NoMilepostController.F_changsha);
                        }
                        break;

                    case "成都市":
                        {
                            //49CF1538-167A-4408-BE83-7DA3897621E9
                            OrganizationCode = Guid.Parse(NoMilepostController.F_chengdu);
                        }
                        break;
                    case "重庆市":
                        {
                            //315CAD78-36EA-4C63-B135-EF89AA4CA838
                            OrganizationCode = Guid.Parse(NoMilepostController.F_chongqing);
                        }
                        break;
                    case "北京市":
                        {
                            //5EE72657-2993-450D-BB65-FDC66C3E4B06
                            OrganizationCode = Guid.Parse(NoMilepostController.F_beijing);
                        }
                        break;

                }
                var UModel = _userinfoWCF.GetUsersByOrgAndPost(OrganizationCode, Guid.Parse(NoMilepostController.F_PostCode), "")[0];
                //先向消息表中添加消息
                if (UModel != null)
                {
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.里程碑稽查消息);
                    msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                    msgModel.C_Messages_content = model.J_Milepost_id.ToString();
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = UModel.C_Userinfo_code;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                }
            }
            
            bool isUpdateSuccess = Imilepost.Update(model);
            if (isUpdateSuccess)
                return 1;
            else
                return 0;
        }

        [HttpPost]
        public ActionResult LikeCase(Guid? UserCode, Guid? PostCode, Guid? OrgCode, int? RoleId, bool IsPreSetManager, string LikeName)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();
            //案件查询模型传递到前端视图中
            caseConditon.B_Case_oprationtype = 1;
            if (LikeName != null && LikeName != "")
            {
                caseConditon.B_Case_number = LikeName;
            }

            #endregion

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> banks = _caseWCF.GetPowerListByPage(null, caseConditon,
                "", 1, 10,UIContext.Current.IsPreSetManager,
                UserCode, PostCode, OrgCode);   

            System.Text.StringBuilder but = new System.Text.StringBuilder();
            but.Append("<table class=\"tablelist\">");

            but.Append("<tbody style=\"cursor:pointer;\">");

            if (banks.Count > 0)
            {
                foreach (var item in banks)
                {
                    if (item.B_Case_firstClassResponsiblePerson == null)
                    {
                        but.Append("<tr target=\"sid_Iterm\" >");
                        but.Append("<td>" + item.B_Case_number + "<br/>（未配置首席专家-无法稽查）</td>");
                        but.Append("<td>" + item.B_Case_name + "</td>");
                        but.Append("</tr>");
                    }
                    else
                    {
                        but.Append("<tr target=\"sid_Iterm\"  onclick=\"SetCaseNumber('" + item.B_Case_number + "','" + item.B_Case_code + "')\">");
                        but.Append("<td>" + item.B_Case_number + "</td>");
                        but.Append("<td>" + item.B_Case_name + "</td>");
                        but.Append("</tr>");
                    }
                }
            }
            else
            {
                but.Append("<tr target=\"sid_Iterm\">");
                but.Append("<td>抱歉没查询到您的条件，建议您模糊匹配...</td>");
                but.Append("</tr>");
            }

            but.Append("</tbody>");
            but.Append(" </table>");

            return Content(but.ToString());
        }

        [HttpPost]
        public string LikeMsg(Guid CaseCode, int type, int msgs, int MilepostID)
        {
            var casemodel = _caseWCF.GetModel(CaseCode);
            //里程碑查询模型
            CommonService.Model.Milepost.J_Milepost roleConditon = new CommonService.Model.Milepost.J_Milepost();
            roleConditon.J_Milepost_Type = type;
            roleConditon.J_Milepost_CaseNumber = casemodel.B_Case_number;
            var list = Imilepost.GetListByPage(roleConditon, "", 1, 10, true, 
                   UIContext.Current.UserCode, this.SwitchLoginDept()).Where(p => p.J_Milepost_id != MilepostID).ToList();

            if (list.Count > 0)
            {
                if (msgs == 1)
                {
                    return "此案件已于" + list[0].J_Milepost_createTime.ToString("yyyy年MM月dd日") + "，" + list[0].J_Milepost_AuditorName + "对(" + list[0].J_Milepost_ZUserinfo_codeName + " " + list[0].J_Milepost_XUserinfo_codeName + " " + list[0].J_Milepost_DepUserinfo_codeName + " " + list[0].J_Milepost_GenerUserinfo_codeName + " " + ")进行了稽查！";
                }
                else
                {
                    System.Text.StringBuilder but = new System.Text.StringBuilder();
                    but.Append(" <table class=\"tablelist\">");
                    but.Append(" <tbody style=\"cursor:pointer;\">");
                    foreach (var item in list)
                    {
                        but.Append("<tr>");
                        but.Append("<td onclick='Dtl(" + item.J_Milepost_id + ")' >" + "此案件已于" + item.J_Milepost_createTime.ToString("yyyy年MM月dd日") + "，" + item.J_Milepost_AuditorName + "对(" + item.J_Milepost_ZUserinfo_codeName + " " + item.J_Milepost_XUserinfo_codeName + " " + item.J_Milepost_DepUserinfo_codeName + " " + item.J_Milepost_GenerUserinfo_codeName + " " + ")进行了稽查！" + "</td>");
                        but.Append("</tr>");
                    }
                    but.Append(" </tbody>");
                    but.Append(" </table>");

                    return but.ToString();
                }
            }
            else
            {
                if (msgs == 1)
                {
                    return "此案件没有被稽查过！";
                }
                else
                {
                    System.Text.StringBuilder but = new System.Text.StringBuilder();
                    but.Append(" <table class=\"tablelist\">");
                    but.Append(" <tbody style=\"cursor:pointer;\">");

                    but.Append("<tr>");
                    but.Append("<td>此案件没有被稽查过！</td>");
                    but.Append("</tr>");

                    but.Append(" </tbody>");
                    but.Append(" </table>");
                    return but.ToString();
                }
            }
        }
        /// <summary>
        /// 主办
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public ActionResult ZUserNames(Guid CaseCode, Guid? zbcode)
        {
            var caseflowlist = _bussinessFlowWCF.GetListByFkCode(CaseCode);

            List<CommonService.Model.SysManager.C_Userinfo> ulist = new List<CommonService.Model.SysManager.C_Userinfo>();

            foreach (var item in caseflowlist)
            {
                if (item.P_Business_person == null) continue;
                var Umodel = _userinfoWCF.GetModelByUserCode(item.P_Business_person.Value);
                if (Umodel != null)
                {
                    if (ulist.Count(p => p.C_Userinfo_id == Umodel.C_Userinfo_id) == 0)
                        ulist.Add(Umodel);
                }
            }
            System.Text.StringBuilder but = new System.Text.StringBuilder();
            if (ulist.Count > 0)
            {
                but.Append("<option value='0'>请选择</option>");
                foreach (var item in ulist)
                {
                    if (zbcode == item.C_Userinfo_code.Value)
                    {
                        but.Append("<option value='" + item.C_Userinfo_code + "' selected='selected'>" + item.C_Userinfo_name + "</option>");
                    }
                    else
                    {
                        but.Append("<option value='" + item.C_Userinfo_code + "'>" + item.C_Userinfo_name + "</option>");
                    }
                }
            }
            else
            {
                but.Append("<option value='0'>无主办负责人</option>");
            }

            return Content(but.ToString());
        }


        /// <summary>
        /// 协办
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public ActionResult XUserNames(Guid CaseCode, Guid? zbcode)
        {
            var caseflowlist = _bussinessFlowWCF.GetListByFkCode(CaseCode);
            List<CommonService.Model.SysManager.C_Userinfo> ulist = new List<CommonService.Model.SysManager.C_Userinfo>();
            foreach (var item in caseflowlist)
            {
                //继续找表单
                var xblist = _businessFlowFormWCF.GetBusinessFlowForms(item.P_Business_flow_code.Value);
                foreach (var item2 in xblist)
                {
                    if (item2.P_Business_flow_form_person == null) continue;
                    var Umodel = _userinfoWCF.GetModelByUserCode(item2.P_Business_flow_form_person.Value);
                    if (Umodel != null)
                    {
                        if (ulist.Count(p => p.C_Userinfo_id == Umodel.C_Userinfo_id) == 0)
                            ulist.Add(Umodel);
                    }
                }
            }
            System.Text.StringBuilder but = new System.Text.StringBuilder();
            if (ulist.Count > 0)
            {
                but.Append("<option value='0'>请选择</option>");
                foreach (var item in ulist)
                {
                    if (zbcode == item.C_Userinfo_code.Value)
                    {
                        but.Append("<option value='" + item.C_Userinfo_code + "' selected='selected'>" + item.C_Userinfo_name + "</option>");
                    }
                    else
                    {
                        but.Append("<option value='" + item.C_Userinfo_code + "'>" + item.C_Userinfo_name + "</option>");
                    }
                }
            }
            else
            {
                but.Append("<option value='0'>无主办负责人</option>");
            }

            return Content(but.ToString());
        }


        /// <summary>
        /// 部长
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public ActionResult DepUserNames(Guid CaseCode, Guid? zbcode)
        {
            System.Text.StringBuilder but = new System.Text.StringBuilder();
            var caseModel = _caseWCF.GetModel(CaseCode);
            if (caseModel.B_Case_person != null && caseModel.B_Case_person.Value != null)
            {
                var Umodel = _userinfoWCF.GetModelByUserCode(caseModel.B_Case_person.Value);
                if (Umodel != null)
                {
                    but.Append("<option value='0'>请选择</option>");
                    if (zbcode == Umodel.C_Userinfo_code.Value)
                    {
                        but.Append("<option value='" + Umodel.C_Userinfo_code + "' selected='selected'>" + Umodel.C_Userinfo_name + "</option>");
                    }
                    else
                    {
                        but.Append("<option value='" + Umodel.C_Userinfo_code + "'>" + Umodel.C_Userinfo_name + "</option>");
                    }
                }
                else
                {
                    but.Append("<option value='0'>该部长用户无效</option>");
                }
            }
            else
            {
                but.Append("<option value='0'>该案件无部长</option>");
            }
            return Content(but.ToString());
        }

        /// <summary>
        /// 分公司总经理
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        public ActionResult FZUserNames(Guid CaseCode, Guid? zbcode)
        {
            //获取案件的地区
            var caseModel = _caseWCF.GetModel(CaseCode);

            Guid GPostCode = Guid.Parse("EF2FDD36-12B1-40E5-9599-23A5800C32BC");    //EF2FDD36-12B1-40E5-9599-23A5800C32BC 分公司总经理GUID
            Guid OrganizationCode = Guid.NewGuid();
            switch (caseModel.C_Region_name)
            {
                case "长沙市":
                    {
                        //C6790683-7B0E-4DEF-9593-4E24E9325137 湖南省的GUID
                        OrganizationCode = Guid.Parse("C6790683-7B0E-4DEF-9593-4E24E9325137");
                    }
                    break;

                case "成都市":
                    {
                        //49CF1538-167A-4408-BE83-7DA3897621E9
                        OrganizationCode = Guid.Parse("49CF1538-167A-4408-BE83-7DA3897621E9");
                    }
                    break;
                case "重庆市":
                    {
                        //315CAD78-36EA-4C63-B135-EF89AA4CA838
                        OrganizationCode = Guid.Parse("315CAD78-36EA-4C63-B135-EF89AA4CA838");
                    }
                    break;
                case "北京市":
                    {
                        //5EE72657-2993-450D-BB65-FDC66C3E4B06
                        OrganizationCode = Guid.Parse("5EE72657-2993-450D-BB65-FDC66C3E4B06");
                    }
                    break;
            }
            System.Text.StringBuilder but = new System.Text.StringBuilder();
            //获取分公司总经理
            var userlist = _userinfoWCF.GetUsersByOrgAndPost(OrganizationCode, GPostCode, "");
            if (userlist.Count > 0)
            {
                but.Append("<option value='0'>请选择</option>");
                foreach (var item in userlist)
                {
                    if (zbcode == item.C_Userinfo_code.Value)
                    {
                        but.Append("<option value='" + item.C_Userinfo_code + "' selected='selected'>" + item.C_Userinfo_name + "</option>");
                    }
                    else
                    {
                        but.Append("<option value='" + item.C_Userinfo_code + "'>" + item.C_Userinfo_name + "</option>");
                    }
                }
            }
            else
            {
                but.Append("<option value='0'>无分公司总经理</option>");
            }

            return Content(but.ToString());
        }


        public ActionResult delete(int J_Milepost_id)
        {
            var model = Imilepost.GetModel(J_Milepost_id);
            model.J_Milepost_isDelete = true;
            bool isSuccess = Imilepost.Update(model);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除里程碑信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除里程碑信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 导出功能
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public FileResult Export(FormCollection form, int J_Milepost_Type, string J_Milepost_AuditorName, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //非里程碑查询模型
            CommonService.Model.Milepost.J_Milepost roleConditon = new CommonService.Model.Milepost.J_Milepost();

            //if (!String.IsNullOrEmpty(form["C_Roles_name"]))
            //{//角色名称查询条件
            //    roleConditon.C_Roles_name = form["C_Roles_name"].Trim(); ;
            //}
            if (!String.IsNullOrEmpty(form["J_Milepost_JTime"]))
            {//稽核时间
                roleConditon.J_Milepost_JTime = Convert.ToDateTime(form["J_Milepost_JTime"]);
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_JTime1"]))
            {//稽核时间1
                roleConditon.J_Milepost_JTime1 = Convert.ToDateTime(form["J_Milepost_JTime1"]);
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_clientRival"]))
            {//委托人/对方当事人
                roleConditon.J_Milepost_clientRival = form["J_Milepost_clientRival"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_CaseNumber"]))
            {//案号
                roleConditon.J_Milepost_CaseNumber = form["J_Milepost_CaseNumber"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_sponsorlawyer"]))
            {//主办律师
                roleConditon.J_Milepost_sponsorlawyer = form["J_Milepost_sponsorlawyer"].Trim();
            }
            if (!String.IsNullOrEmpty(form["J_Milepost_Colawyer"]))
            {//协办律师
                roleConditon.J_Milepost_Colawyer = form["J_Milepost_Colawyer"].Trim();
            }

            if (!String.IsNullOrEmpty(form["J_Milepost_AuditorName"]))
            {//稽核人
                roleConditon.J_Milepost_AuditorName = form["J_Milepost_AuditorName"].Trim();
            }
            roleConditon.J_Milepost_AuditorName = J_Milepost_AuditorName;
            roleConditon.J_Milepost_Type = J_Milepost_Type;

            //角色查询模型传递到前端视图中
            ViewBag.RoleConditon = roleConditon;
            ViewBag.J_Milepost_Type = J_Milepost_Type;
            #endregion

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            //获取角色数据信息
            List<CommonService.Model.Milepost.J_Milepost> MilepostList = Imilepost.GetListByPage(roleConditon,
                "", 1, 1000000, UIContext.Current.IsPreSetManager, 
                UIContext.Current.UserCode, this.SwitchLoginDept());

            #region 权限
            this.InitializationButtonsPower();
            #endregion
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);

            row1.CreateCell(0).SetCellValue("稽核人");
            row1.CreateCell(1).SetCellValue("被稽核人");
            row1.CreateCell(2).SetCellValue("稽核时间");
            row1.CreateCell(3).SetCellValue("案号");
            row1.CreateCell(4).SetCellValue("原告");
            row1.CreateCell(5).SetCellValue("被告");
            if (J_Milepost_Type==1)
            {
                row1.CreateCell(6).SetCellValue("管辖法院");
                row1.CreateCell(7).SetCellValue("文书制作");
                row1.CreateCell(8).SetCellValue("立案");
                row1.CreateCell(9).SetCellValue("保全");
                row1.CreateCell(10).SetCellValue("一审排庭");
                row1.CreateCell(11).SetCellValue("一审完成");
                row1.CreateCell(12).SetCellValue("起诉状");
                row1.CreateCell(13).SetCellValue("调解书");
                row1.CreateCell(14).SetCellValue("判决结果");
            }
            else if (J_Milepost_Type == 2)
            {
                row1.CreateCell(6).SetCellValue("管辖法院");
                row1.CreateCell(7).SetCellValue("二审排庭");
                row1.CreateCell(8).SetCellValue("二审完成");
                row1.CreateCell(9).SetCellValue("起诉状");
                row1.CreateCell(10).SetCellValue("调解书");
                row1.CreateCell(11).SetCellValue("判决结果");
            }else
            {
                row1.CreateCell(6).SetCellValue("执行立案");
                row1.CreateCell(7).SetCellValue("执行措施实施");
                row1.CreateCell(8).SetCellValue("执行程序完结");
                row1.CreateCell(9).SetCellValue("强制执行申请书");
                row1.CreateCell(10).SetCellValue("执行和解协议");
            }
            row1.CreateCell(J_Milepost_Type == 1 ? 15 : (J_Milepost_Type==2 ? 12 : 11)).SetCellValue("程序项应得分");
            row1.CreateCell(J_Milepost_Type == 1 ? 16 : (J_Milepost_Type == 2 ? 13 : 12)).SetCellValue("程序项实得分");
            row1.CreateCell(J_Milepost_Type == 1 ? 17 : (J_Milepost_Type == 2 ? 14 : 13)).SetCellValue("实体项实得分");
            row1.CreateCell(J_Milepost_Type == 1 ? 18 : (J_Milepost_Type == 2 ? 15 : 14)).SetCellValue("案件最终稽核得分");
            row1.CreateCell(J_Milepost_Type == 1 ? 19 : (J_Milepost_Type == 2 ? 16 : 15)).SetCellValue("被稽查人意见");
            //row1.CreateCell(7).SetCellValue("被稽核人原因");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < MilepostList.Count; i++)
            {
                string WascheckedStr = "";//被稽查人
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(MilepostList[i].J_Milepost_AuditorName);
                if (MilepostList[i].J_Milepost_ZUserinfo_codeName != null && MilepostList[i].J_Milepost_ZUserinfo_codeName != "")
                {
                    WascheckedStr += MilepostList[i].J_Milepost_ZUserinfo_codeName + " ";
                }
                if (MilepostList[i].J_Milepost_XUserinfo_codeName != null && MilepostList[i].J_Milepost_XUserinfo_codeName != "")
                {
                    WascheckedStr += MilepostList[i].J_Milepost_XUserinfo_codeName + " ";
                }
                if (MilepostList[i].J_Milepost_DepUserinfo_codeName != null && MilepostList[i].J_Milepost_DepUserinfo_codeName != "")
                {
                    WascheckedStr += MilepostList[i].J_Milepost_DepUserinfo_codeName + " ";
                }
                if (MilepostList[i].J_Milepost_GenerUserinfo_codeName != null && MilepostList[i].J_Milepost_GenerUserinfo_codeName != "")
                {
                    WascheckedStr += MilepostList[i].J_Milepost_GenerUserinfo_codeName + " ";
                }
                rowtemp.CreateCell(1).SetCellValue(WascheckedStr);
                rowtemp.CreateCell(2).SetCellValue(MilepostList[i].J_Milepost_JTime.ToString("yyyy-MM-dd"));
                rowtemp.CreateCell(3).SetCellValue(MilepostList[i].J_Milepost_CaseNumber);
                rowtemp.CreateCell(4).SetCellValue(MilepostList[i].C_Customer_yg);
                rowtemp.CreateCell(5).SetCellValue(MilepostList[i].C_Customer_BG_1 + " " + MilepostList[i].C_Customer_BG_2);
                if (J_Milepost_Type == 1)
                {
                    rowtemp.CreateCell(6).SetCellValue("");
                    rowtemp.CreateCell(7).SetCellValue(MilepostList[i].J_Milepost_DocumentPo);
                    rowtemp.CreateCell(8).SetCellValue(MilepostList[i].J_Milepost_Filing);
                    rowtemp.CreateCell(9).SetCellValue(MilepostList[i].J_Milepost_Firstcomplete);
                    rowtemp.CreateCell(10).SetCellValue(MilepostList[i].J_Milepost_Preservation);
                    rowtemp.CreateCell(11).SetCellValue(MilepostList[i].J_Milepost_Firstinstance);
                    rowtemp.CreateCell(12).SetCellValue(MilepostList[i].J_Milepost_Prosecution);
                    rowtemp.CreateCell(13).SetCellValue(MilepostList[i].J_Milepost_Conciliation);
                    rowtemp.CreateCell(14).SetCellValue(MilepostList[i].J_Milepost_Verdict);
                }
                else if (J_Milepost_Type == 2)
                {
                    rowtemp.CreateCell(6).SetCellValue("");
                    rowtemp.CreateCell(7).SetCellValue(MilepostList[i].J_Milepost_Preservation);
                    rowtemp.CreateCell(8).SetCellValue(MilepostList[i].J_Milepost_Firstinstance);
                    rowtemp.CreateCell(9).SetCellValue(MilepostList[i].J_Milepost_Prosecution);
                    rowtemp.CreateCell(10).SetCellValue(MilepostList[i].J_Milepost_Conciliation);
                    rowtemp.CreateCell(11).SetCellValue(MilepostList[i].J_Milepost_Verdict);
                }else
                {
                    rowtemp.CreateCell(7).SetCellValue(MilepostList[i].J_Milepost_DocumentPo);
                    rowtemp.CreateCell(8).SetCellValue(MilepostList[i].J_Milepost_Filing);
                    rowtemp.CreateCell(9).SetCellValue(MilepostList[i].J_Milepost_Preservation);
                    rowtemp.CreateCell(10).SetCellValue(MilepostList[i].J_Milepost_Firstcomplete);
                    rowtemp.CreateCell(11).SetCellValue(MilepostList[i].J_Milepost_Firstinstance);
                }
                rowtemp.CreateCell(J_Milepost_Type == 1 ? 15 : (J_Milepost_Type == 2 ? 12 : 11)).SetCellValue(MilepostList[i].J_Milepost_ProgramScoreY);
                rowtemp.CreateCell(J_Milepost_Type == 1 ? 16 : (J_Milepost_Type == 2 ? 13 : 12)).SetCellValue(MilepostList[i].J_Milepost_ProgramScoreS);
                rowtemp.CreateCell(J_Milepost_Type == 1 ? 17 : (J_Milepost_Type == 2 ? 14 : 13)).SetCellValue(MilepostList[i].J_Milepost_EntityScore);
                rowtemp.CreateCell(J_Milepost_Type == 1 ? 18 : (J_Milepost_Type == 2 ? 15 : 14)).SetCellValue(MilepostList[i].J_Milepost_CaseScore);
                rowtemp.CreateCell(J_Milepost_Type == 1 ? 19 : (J_Milepost_Type == 2 ? 16 : 15)).SetCellValue(MilepostList[i].J_Milepost_TJMessageType);//被稽查人意见
                //rowtemp.CreateCell(7).SetCellValue(MilepostList[i].J_Milepost_TJMessageContent);//被稽查人原因
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "稽核报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }

        /// <summary>
        /// 转换当前登录人所属部门
        /// </summary>
        /// <returns></returns>
        private List<Guid?> SwitchLoginDept()
        {
            List<Guid?> depts = new List<Guid?>();

            if (!UIContext.Current.IsPreSetManager)
            {
                List<V_User_Org_Post> OrgPosts = UIContext.Current.UserOrgPosts;
                List<Guid?> groupDepts = OrgPosts.GroupBy(r => r.OrgCode).Select(g => g.Key).ToList(); ;
                depts.AddRange(groupDepts);
            }

            return depts;
        }

    }
}