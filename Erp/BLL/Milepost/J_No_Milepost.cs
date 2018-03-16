using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
using System.Collections;
namespace CommonService.BLL.Milepost
{
    /// <summary>
    /// J_No_Milepost
    /// </summary>
    public partial class J_No_Milepost
    {
        private readonly CommonService.DAL.Milepost.J_No_Milepost dal = new CommonService.DAL.Milepost.J_No_Milepost();

        private readonly CommonService.BLL.SysManager.C_Organization Odal = new CommonService.BLL.SysManager.C_Organization();

        private readonly CommonService.BLL.SysManager.C_Userinfo Udal = new CommonService.BLL.SysManager.C_Userinfo();
        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        /// <summary>
        /// 案件业务访问层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_Case caseBLL = new CommonService.BLL.CaseManager.B_Case();

        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();

        public J_No_Milepost()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int J_No_Milepost_id)
        {
            return dal.Exists(J_No_Milepost_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.Milepost.J_No_Milepost model)
        {
            /**
             * author:hety
             * modytime:2015-11-12
             * descrption:根据稽查事项进行分割，转化为多条稽查记录
             **/
            int last_j_No_Milepost_id = 0;//最后插入稽查的Id值
            if (!String.IsNullOrEmpty(model.J_No_Milepost_DocumentPo))
            {
                string[] noMilePostDocumentPoGroup = model.J_No_Milepost_DocumentPo.Split(',');
                for (int i = 0; i < noMilePostDocumentPoGroup.Length; i++)
                {
                    if (!String.IsNullOrEmpty(noMilePostDocumentPoGroup[i]))
                    {
                        model.J_No_Milepost_code = Guid.NewGuid();
                        model.J_No_Milepost_DocumentPo = noMilePostDocumentPoGroup[i];
                        last_j_No_Milepost_id = dal.Add(model);

                        #region 发送消息

                        var caseModel = caseBLL.GetModelList(" B_Case_number='" + model.J_No_Milepost_CaseNumber + "'")[0];

                        //根据级别选择不同接收人
                        if (model.J_No_Milepost_ZUserinfo_code != null && model.J_No_Milepost_ZUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            //先向消息表中添加消息
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.非里程碑稽查消息);
                            msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                            msgModel.C_Messages_content = last_j_No_Milepost_id.ToString();
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = model.J_No_Milepost_ZUserinfo_code;
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            messageDAL.Add(msgModel);
                        }
                        if (model.J_No_Milepost_DepUserinfo_code != null && model.J_No_Milepost_DepUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                        {    //先向消息表中添加消息
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.非里程碑稽查消息);
                            msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                            msgModel.C_Messages_content = last_j_No_Milepost_id.ToString();
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = model.J_No_Milepost_DepUserinfo_code;
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            messageDAL.Add(msgModel);
                        }
                        if (model.J_No_Milepost_GenerUserinfo_code != null && model.J_No_Milepost_GenerUserinfo_code.ToString() != "00000000-0000-0000-0000-000000000000")
                        {   //先向消息表中添加消息
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.非里程碑稽查消息);
                            msgModel.C_Messages_link = caseModel.B_Case_code.Value;
                            msgModel.C_Messages_content = last_j_No_Milepost_id.ToString();
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = model.J_No_Milepost_GenerUserinfo_code;
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            messageDAL.Add(msgModel);
                        }
                        #endregion
                    }
                }
            }
            return last_j_No_Milepost_id;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.Milepost.J_No_Milepost model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int J_No_Milepost_id)
        {
            //this.SplitMulityCheckItem();这里只是用来执行临时的拆分稽查项逻辑，正常情况必须关闭,hety,2015-11-20
            /***
             * author:hety 
             * modytime:2015-11-13
             * descrpion:删除的时候，把未读的消息删除
             **/
            bool isSuccess = false;
            isSuccess = dal.Delete(J_No_Milepost_id);
            messageDAL.DeleteByTypeContent(Convert.ToInt32(MessageBigTypeEnum.案件), Convert.ToInt32(MessageTinyTypeEnum.非里程碑稽查消息), J_No_Milepost_id.ToString());
            return isSuccess;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string J_No_Milepost_idlist)
        {
            return dal.DeleteList(J_No_Milepost_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.Milepost.J_No_Milepost GetModel(int J_No_Milepost_id)
        {

            return dal.GetModel(J_No_Milepost_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.Milepost.J_No_Milepost GetModelByCache(int J_No_Milepost_id)
        {

            string CacheKey = "J_No_MilepostModel-" + J_No_Milepost_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(J_No_Milepost_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.Milepost.J_No_Milepost)objModel;
        }

        /// <summary>
        /// 拆分多个稽查项目(临时用)
        /// </summary>
        public void SplitMulityCheckItem()
        {
            /**
             * author:hety
             * date:2015-11-16
             * descption:这里只是为了按照稽查项目拆分非里程碑数据
             * 
             **/
            string strWhere = " J_No_Milepost_DocumentPo like '%,%' ";
            DataSet ds = dal.GetList(strWhere);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string[] documentGroup = dr["J_No_Milepost_DocumentPo"].ToString().Split(',');//稽查项目
                for (int i = 0; i < documentGroup.Length; i++)
                {
                    if (i == 0)
                    {//默认第一项为更改
                        dal.UploadDocumentPro(Convert.ToInt32(dr["J_No_Milepost_id"].ToString()), documentGroup[i]);
                    }
                    else
                    {//其余为新增
                        dal.InsertByMilePostIdAndDocumentPro(Convert.ToInt32(dr["J_No_Milepost_id"].ToString()), documentGroup[i]);
                    }
                }
            }
            //foreach (CommonService.Model.Milepost.J_No_Milepost milepost in J_No_Mileposts)
            //{
            //    string[] documentGroup = milepost.J_No_Milepost_DocumentPo.Split(',');//稽查项目
            //    for (int i = 0; i < documentGroup.Length; i++)
            //    {
            //        if (i == 0)
            //        {//默认第一项为更改
            //            dal.UploadDocumentPro(milepost.J_No_Milepost_id, documentGroup[i]);
            //        }
            //        else
            //        {//其余为新增
            //            dal.InsertByMilePostIdAndDocumentPro(milepost.J_No_Milepost_id, documentGroup[i]);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.Milepost.J_No_Milepost> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.Milepost.J_No_Milepost> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.Milepost.J_No_Milepost> modelList = new List<CommonService.Model.Milepost.J_No_Milepost>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.Milepost.J_No_Milepost model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.Milepost.J_No_Milepost model, bool IsPreSetManager, Guid? userCode, List<Guid?> depts)
        {
            //权限判断
            System.Text.StringBuilder but = new System.Text.StringBuilder();

            //如果不为内置系统管理员
            if (!IsPreSetManager)
            {
                List<Guid?> glist = new List<Guid?>();
                //遍历用户所部门集合(可能会属于多个部门)
                foreach (var dept in depts)
                {
                    glist.Add(dept.Value);
                    //根据当前组织机构找出所有子组织机构
                    var oplist = Odal.GetModelByParent(dept.Value);
                    foreach (var item in oplist)
                    {
                        glist.Add(item.C_Organization_code);
                        BindChiOd(item.C_Organization_code, glist);
                    }
                }

                List<Model.SysManager.C_Userinfo> Uinfo = new List<Model.SysManager.C_Userinfo>();

                //找出所有用户
                foreach (var item in glist)
                {
                    var Ulist = Udal.GetUsersByOrgAndPost(item.Value, null, "");
                    if (Ulist.Count > 0)
                        Uinfo.AddRange(Ulist);
                }

                foreach (var item in Uinfo)
                {
                    but.Append(item.C_Userinfo_code + ",");
                }
            }


            return dal.GetRecordCount(model, but.ToString(), userCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.Milepost.J_No_Milepost> GetListByPage(CommonService.Model.Milepost.J_No_Milepost model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, List<Guid?> depts)
        {

            //权限判断
            System.Text.StringBuilder but = new System.Text.StringBuilder();

            //如果不为内置系统管理员
            if (!IsPreSetManager)
            {
                List<Guid?> glist = new List<Guid?>();

                //遍历用户所部门集合(可能会属于多个部门)
                foreach (var dept in depts)
                {
                    glist.Add(dept.Value);
                    //根据当前组织机构找出所有子组织机构
                    var oplist = Odal.GetModelByParent(dept.Value);
                    foreach (var item in oplist)
                    {
                        glist.Add(item.C_Organization_code);
                        BindChiOd(item.C_Organization_code, glist);
                    }
                }


                List<Model.SysManager.C_Userinfo> Uinfo = new List<Model.SysManager.C_Userinfo>();

                //找出所有用户
                foreach (var item in glist)
                {
                    var Ulist = Udal.GetUsersByOrgAndPost(item.Value, null, "");
                    if (Ulist.Count > 0)
                        Uinfo.AddRange(Ulist);
                }

                foreach (var item in Uinfo)
                {
                    but.Append(item.C_Userinfo_code + ",");
                }
            }



            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex, but.ToString(), userCode).Tables[0]);
        }

        private void BindChiOd(Guid? nullable, List<Guid?> glist)
        {
            //根据当前组织机构找出所有子组织机构
            var oplist = Odal.GetModelByParent(nullable.Value);
            foreach (var item in oplist)
            {
                glist.Add(item.C_Organization_code);
                BindChiOd(item.C_Organization_code, glist);
            }
        }
    }
}

