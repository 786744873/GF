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
    /// 岗位控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/28
    /// </summary>
    public class PostController : BaseController
    {
         private readonly ICommonService.SysManager.IC_Post _postWCF;
         private readonly ICommonService.SysManager.IC_Group _groupWCF;
         private readonly ICommonService.SysManager.IC_Organization_post _organizationPostWCF;
         private readonly ICommonService.SysManager.IC_Userinfo _userInfoWCF;
         public PostController()
        {
            #region 服务初始化
            _postWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Post>("PostWCF");
            _groupWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Group>("GroupWCF");
            _organizationPostWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post>("OrganizationPostWCF");
            _userInfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            #endregion
        }
        //
        // GET: /SysManager/Post/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            //创建初始化岗位实体
            CommonService.Model.SysManager.C_Post post = new CommonService.Model.SysManager.C_Post();
            List<CommonService.Model.SysManager.C_Group> groups = _groupWCF.GetAllList();
            ViewBag.Groups = groups;
            post.C_Post_code = Guid.NewGuid();
            post.C_Post_isDelete = 0;
            post.C_Post_creator = Context.UIContext.Current.UserCode;
            post.C_Post_createTime = DateTime.Now;
            return View(post);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int Post_id)
        {
            CommonService.Model.SysManager.C_Post post = _postWCF.GetModel(Post_id); 
            List<CommonService.Model.SysManager.C_Group> groups = _groupWCF.GetAllList();
            ViewBag.Groups = groups;
            return View("Create", post);
        }

        /// <summary>
        /// 设置岗位角色区域关系Action
        /// </summary>
        /// <returns></returns>
        public ActionResult SetPostRoleAreaRelation(string Userinfo_code)
        {
            Guid Userinfo_Code = Guid.Empty;//用户Guid
            if (!Userinfo_code.Equals("{sid_Iterm}"))
            {
                Userinfo_Code = new Guid(Userinfo_code);
            }
            ViewBag.UserCode = Userinfo_code;
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //岗位查询模型
            CommonService.Model.SysManager.C_Post postConditon = new CommonService.Model.SysManager.C_Post();

            if (!String.IsNullOrEmpty(form["C_Post_name"]))
            {//岗位名称查询条件
                postConditon.C_Post_name = form["C_Post_name"].Trim();
            }

            //岗位查询模型传递到前端视图中
            ViewBag.PostConditon = postConditon;

            #endregion

            //获取岗位总记录数
            this.TotalRecordCount = _postWCF.GetRecordCount(postConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取岗位数据信息
            List<CommonService.Model.SysManager.C_Post> menus = _postWCF.GetListByPage(postConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(menus);
        }
        /// <summary>
        /// 根据组织机构获取对应的岗位信息并进行多选
        /// </summary>
        /// <param name="form"></param>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        public ActionResult GetPostListForOrg(string orgCode)
        {
            Guid orginzationCode = Guid.Empty;
            List<CommonService.Model.SysManager.C_Organization_post> posts;
            if (!orgCode.Equals("{orgCode}"))
            {
                orginzationCode = new Guid(orgCode);
                posts = _organizationPostWCF.GetRelationPostsByOrg(orginzationCode);
            }
            else
                posts = new List<CommonService.Model.SysManager.C_Organization_post>();
 
           
            return View(posts);
        }
        /// <summary>
        /// 多选全部岗位Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefList(FormCollection form, string organizationCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //岗位查询模型
            CommonService.Model.SysManager.C_Post postConditon = new CommonService.Model.SysManager.C_Post();
            if (!String.IsNullOrEmpty(form["C_Post_name"]))
            {//岗位名称查询条件
                postConditon.C_Post_name = form["C_Post_name"].Trim();
            }
            //岗位查询模型传递到前端视图中
            ViewBag.PostConditon = postConditon;
            ViewBag.organizationCode = organizationCode;

            List<CommonService.Model.SysManager.C_Organization_post> orgposts = _organizationPostWCF.GetRelationPostsByOrg(new Guid(organizationCode));
            string orgPostCodeStr = "";
            foreach (CommonService.Model.SysManager.C_Organization_post Organization_post in orgposts)
            {
                orgPostCodeStr += Organization_post.C_Post_code+",";
            }
            ViewBag.orgPostCodeStr = orgPostCodeStr=="" ? orgPostCodeStr : orgPostCodeStr.Substring(0,orgPostCodeStr.Length-1);

            #endregion

            //获取岗位总记录数
            this.TotalRecordCount = _postWCF.GetRecordCount(postConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.SysManager.C_Post> posts = _postWCF.GetListByPage(postConditon, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(posts);
        }

        /// <summary>
        /// 无分页多选全部岗位Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefListNoPage(string organizationCode)
        {
            if(organizationCode=="" || organizationCode=="{organizationCode}")
            {
                organizationCode = Guid.Empty.ToString();
            }
            List<CommonService.Model.SysManager.C_Organization_post> orgposts = _organizationPostWCF.GetRelationPostsByOrg(new Guid(organizationCode));
            string orgPostCodeStr = "";
            foreach (CommonService.Model.SysManager.C_Organization_post Organization_post in orgposts)
            {
                orgPostCodeStr += Organization_post.C_Post_code + ",";
            }
            ViewBag.orgPostCodeStr = orgPostCodeStr == "" ? orgPostCodeStr : orgPostCodeStr.Substring(0, orgPostCodeStr.Length - 1);

            List<CommonService.Model.SysManager.C_Post> posts = _postWCF.GetList();
            return View(posts);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.SysManager.C_Post post)
        {
            //服务方法调用
            int postId = 0;

            if (post.C_Post_id > 0)
            {//修改
                bool isUpdateSuccess = _postWCF.Update(post);
                if (isUpdateSuccess)
                {
                    postId = post.C_Post_id;
                }
            }
            else
            {//添加
                postId = _postWCF.Add(post);
            }

            if (postId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存岗位信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存岗位信息成功", "/sysmanager/post/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存岗位信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存岗位信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int Post_id)
        {
            bool isSuccess = _postWCF.Delete(Post_id);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除岗位信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除岗位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        /// 关联岗位添加
        /// </summary>
        /// <returns></returns>
        public ActionResult RelationContact(string postCodes, string organizationCode)
        {
            bool isSuccess = false;
            string[] post_codes = postCodes.Split(',');
            if (organizationCode != Guid.Empty.ToString())
            {//关联岗位
                for (int i = 0; i < post_codes.Length; i++)
                {
                    if (!String.IsNullOrEmpty(post_codes[i]))
                    {
                        CommonService.Model.SysManager.C_Organization_post organizationPost = new CommonService.Model.SysManager.C_Organization_post();
                        organizationPost.C_Organization_post_code = Guid.NewGuid();
                        organizationPost.C_Organization_code = new Guid(organizationCode);
                        organizationPost.C_Post_code = new Guid(post_codes[i]);
                        organizationPost.C_Organization_post_isDelete = 0;
                        organizationPost.C_Organization_post_creator = Guid.NewGuid();
                        organizationPost.C_Organization_post_createTime = DateTime.Now;
                        _organizationPostWCF.Add(organizationPost);
                        isSuccess = true;
                    }
                }
            }


            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联岗位信息成功！", "iframe_allocatedPostList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联岗位信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 提交表单设置默认岗位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveIsDefault(string orgcodeAndpostCodeAndrolecode, string userCode)
        {
            //服务方法调用
            bool flag=false;
            string[] items = orgcodeAndpostCodeAndrolecode.Split(',');
            Guid org = new Guid(items[0]);
            Guid post = new Guid(items[1]);
            Guid user = new Guid(userCode);
            List<CommonService.Model.SysManager.C_Userinfo> UserInfosp = _userInfoWCF.GetUsersByOrgAndPostChirld(null, null, user);
            foreach (CommonService.Model.SysManager.C_Userinfo UserInfo in UserInfosp)
            {
                if (UserInfo.C_Userinfo_isDefault)
                {
                    UserInfo.C_Userinfo_isDefault = false;
                    _userInfoWCF.Update(UserInfo);
                }   
            }
            CommonService.Model.SysManager.C_Userinfo isdefault = _userInfoWCF.GetUsersByOrgAndPostChirld(org, post, user)[0];
            isdefault.C_Userinfo_isDefault = true;
            if (_userInfoWCF.Update(isdefault))
                flag=true;
            if (flag)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存岗位信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存岗位信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        public ActionResult Test()
        {
            return View();
        }
	}
}