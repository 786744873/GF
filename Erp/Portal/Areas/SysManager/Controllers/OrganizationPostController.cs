using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 组织机构岗位关系控制器
    /// </summary>
    public class OrganizationPostController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Organization_post _organizationPostWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        public OrganizationPostController()
        {
            #region 服务初始化
            _organizationPostWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post>("OrganizationPostWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            #endregion
        }

        //
        // GET: /SysManager/OrganizationPost/
        public override ActionResult Index()
        {
            return View();
        }

        public ActionResult DefaultLayout(string organizationCode)
        {
            ViewBag.OrganizationCode = organizationCode;
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string organizationCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //组织机构岗位关系查询模型
            CommonService.Model.SysManager.C_Organization_post orgConditon = new CommonService.Model.SysManager.C_Organization_post();

            if (!String.IsNullOrEmpty(organizationCode))
            {//组织机构名称查询条件
                if (organizationCode == "{organizationCode}")
                {
                    orgConditon.C_Organization_code = Guid.Empty;
                }
                else
                {
                    orgConditon.C_Organization_code = new Guid(organizationCode);
                }
            }

            //组织机构岗位关系查询模型传递到前端视图中
            ViewBag.OrgConditon = orgConditon;

            #endregion

            //获取组织机构岗位关系总记录数
            this.TotalRecordCount = _organizationPostWCF.GetRecordCount(orgConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取组织机构岗位关系数据信息
            List<CommonService.Model.SysManager.C_Organization_post> organizations = _organizationPostWCF.GetListByPage(orgConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(organizations);
        }

        /// <summary>
        /// 组织机构关联岗位Action
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <returns></returns>
        public ActionResult OrgRelationPostList(string orgCode,string isChecked ,int? otype,int? powerId)
        {
            Guid orginzationCode = Guid.Empty;
            List<Guid> DepIds = new List<Guid>();//存取当前选中的组织架构以及子级的组织架构
            if (!orgCode.Equals("{orgCode}"))
            {
                orginzationCode = new Guid(orgCode);
                DepIds.Add(orginzationCode);
                var OrganizationList = _organizationWCF.GetModelByParent(orginzationCode);
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);

                }
            }else
            {//取当前用户区域内的组织架构
                if (isChecked != "0")
                {
                    List<CommonService.Model.SysManager.C_Organization> organizationList = _organizationWCF.GetContainLawyerOrAdvisorList(Context.UIContext.Current.UserCode.Value, otype);
                    if (organizationList.Count() != 0)
                    {
                        foreach (CommonService.Model.SysManager.C_Organization organization in organizationList)
                        {
                            if (isChecked != "0")
                            {
                                DepIds.Add(organization.C_Organization_code.Value);
                            }
                            else
                            {
                                DepIds.Add(organization.C_Organization_code.Value);
                            }
                            //DepIds.Add(organization.C_Organization_code.Value);
                        }
                    }
                    else
                    {
                        DepIds.Add(orginzationCode);
                    }
                }
            }
            //区分专业顾问
            if (powerId != null)
            {

                ViewBag.PostName = "专业顾问";
            }
            else {
                ViewBag.PostName = null;
            }
            List<CommonService.Model.SysManager.C_Organization_post> OrgPosts = new List<CommonService.Model.SysManager.C_Organization_post>();
            //if (powerId != null)
            //{
            //    //根据powerId(权限ID)查询对应的角色，再根据角色去查询对应的人，再根据人去查找对应的岗位
            //    OrgPosts = _organizationPostWCF.GetRelationPostsByPowerid(Convert.ToInt32(powerId));
            //}
            //else
            //{
            OrgPosts = _organizationPostWCF.GetRelationPostsByOrgList(DepIds);
            //}
            return View(OrgPosts);
        }
        private void SetDep(Guid guid, List<Guid> DepIds)
        {
            var OrganizationList = _organizationWCF.GetModelByParent(guid);
            if (OrganizationList.Count > 0)
            {
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Organization_post_id)
        {
            bool isSuccess = _organizationPostWCF.Delete(Organization_post_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联岗位信息成功！", "iframe_allocatedPostList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联岗位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}