using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
namespace CommonService.BLL.MonitorManager
{
    /// <summary>
    /// 条目变更表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/12
    /// </summary>
    public partial class M_Entry_Change
    {
        private readonly CommonService.DAL.MonitorManager.M_Entry_Change dal = new CommonService.DAL.MonitorManager.M_Entry_Change();
        private readonly CommonService.DAL.MonitorManager.M_Entry_Statistics esDal = new CommonService.DAL.MonitorManager.M_Entry_Statistics();
        private readonly CommonService.DAL.CaseManager.B_Case caseDal = new CommonService.DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        /// <summary>
        /// 参数业务访问层
        /// </summary>
        private readonly CommonService.BLL.C_Parameters parameterBLL = new CommonService.BLL.C_Parameters();
        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        public M_Entry_Change()
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
        public bool Exists(int M_Entry_Change_id)
        {
            return dal.Exists(M_Entry_Change_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.MonitorManager.M_Entry_Change model)
        {
            CommonService.Model.MonitorManager.M_Entry_Statistics entryStatistics = esDal.GetModel(model.M_Entry_Statistics_code.Value);
            CommonService.Model.CaseManager.B_Case bcase = caseDal.GetModel(entryStatistics.M_Case_code.Value);
            if(model.M_Entry_Change_Applicant==bcase.B_Case_person)
            {
                model.M_Entry_Change_IsThrough = Convert.ToInt32(EntryChangeIsThroughlEnum.通过);
                esDal.UpdateChangeDuration(model.M_Entry_Statistics_code.Value, model.M_Entry_Change_applicationDuration.Value);
            }else
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.进程管理);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.条目变更);
                message.C_Messages_link = entryStatistics.M_Case_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = bcase.B_Case_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = model.M_Entry_Change_code.ToString() + "," + model.M_Entry_Statistics_code.ToString();
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.MonitorManager.M_Entry_Change model)
        {
            bool isSuccess = true;
            isSuccess = dal.Update(model);
            CommonService.Model.MonitorManager.M_Entry_Statistics entryStatistics = esDal.GetModel(model.M_Entry_Statistics_code.Value);
            if (model.M_Entry_Change_IsThrough == Convert.ToInt32(EntryChangeIsThroughlEnum.通过))
            {
                isSuccess = esDal.UpdateChangeDuration(model.M_Entry_Statistics_code.Value, model.M_Entry_Change_approvalDuration.Value);
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.进程管理);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过条目变更);
                message.C_Messages_link = entryStatistics.M_Case_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.M_Entry_Change_Applicant;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = model.M_Entry_Change_code.ToString() + "," + model.M_Entry_Statistics_code.ToString();
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }else
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.进程管理);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核驳回条目变更);
                message.C_Messages_link = entryStatistics.M_Case_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.M_Entry_Change_Applicant;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = model.M_Entry_Change_code.ToString() + "," + model.M_Entry_Statistics_code.ToString();
                message.C_Messages_isValidate = 1;
                
                messageDAL.Add(message);
            }

            return isSuccess;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int M_Entry_Change_id)
        {

            return dal.Delete(M_Entry_Change_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string M_Entry_Change_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(M_Entry_Change_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.MonitorManager.M_Entry_Change GetModel(Guid M_Entry_Change_code)
        {

            return dal.GetModel(M_Entry_Change_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.MonitorManager.M_Entry_Change GetModelByCache(int M_Entry_Change_id)
        {

            string CacheKey = "M_Entry_ChangeModel-" + M_Entry_Change_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(M_Entry_Change_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.MonitorManager.M_Entry_Change)objModel;
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
        public List<CommonService.Model.MonitorManager.M_Entry_Change> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Change> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.MonitorManager.M_Entry_Change> modelList = new List<CommonService.Model.MonitorManager.M_Entry_Change>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.MonitorManager.M_Entry_Change model;
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
        /// 根据案件Guid，获取条目变更记录
        /// </summary>
        /// <param name="pkCode">案件Guid</param>
        /// <returns></returns>        
        public List<CommonService.Model.MonitorManager.M_Entry_Change> GetEntryChangeRecordByPkCode(Guid pkCode)
        {
            DataSet ds = dal.GetEntryChangeRecordByPkCode(pkCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.MonitorManager.M_Entry_Change model, string orderby, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {

            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            return dal.GetRecordCount(model, orderby, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.MonitorManager.M_Entry_Change> GetListByPage(CommonService.Model.MonitorManager.M_Entry_Change model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {        //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode).Tables[0]);
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

        #region app 专用

        /// <summary>
        /// 根据条目变更编码，条目统计编码，来源类型，获取条目统计信息
        /// </summary>
        /// <param name="entryChangeCode">条目变更编码</param>
        /// <param name="entryStatisticsCode">条目统计编码</param>
        /// <param name="fromSourceType">来源类型(1代表来源申请变更；2代表来源变更审核)</param>
        /// <returns></returns>      
        public List<CommonService.Model.CustomModel.KeyValueModel> GetEntryStatistics(string entryChangeCode, string entryStatisticsCode, string fromSourceType)
        {
            /**
             * author:hety
             * date:2015-12-29
             * description:组装条目变更，统计信息
             **/

            List<CommonService.Model.CustomModel.KeyValueModel> keyValues = new List<Model.CustomModel.KeyValueModel>();

            if (fromSourceType.Equals("1"))
                return keyValues;

            CommonService.Model.MonitorManager.M_Entry_Statistics entryStatistics = esDal.GetModel(new Guid(entryStatisticsCode));
            if (entryStatistics != null)
            {
                CommonService.Model.CustomModel.KeyValueModel bzscKeyValue = new Model.CustomModel.KeyValueModel();
                bzscKeyValue.Key = "标准时长";
                bzscKeyValue.Value = entryStatistics.M_Entry_Duration + "小时";
                keyValues.Add(bzscKeyValue);

                int? Duration = 0;
                List<CommonService.Model.MonitorManager.M_Entry_Change> entry_changeList = this.GetModelList("M_Entry_Statistics_code=" + "'" + entryStatisticsCode + "'");
                foreach (CommonService.Model.MonitorManager.M_Entry_Change entryChange in entry_changeList)
                {
                    if (entryChange.M_Entry_Change_IsThrough == 327)
                    {//审核通过
                        Duration += entryChange.M_Entry_Change_approvalDuration;
                    }
                }

                CommonService.Model.CustomModel.KeyValueModel ybgscKeyValue = new Model.CustomModel.KeyValueModel();
                ybgscKeyValue.Key = "已变更时长";
                ybgscKeyValue.Value = Duration + "";
                keyValues.Add(ybgscKeyValue);

                CommonService.Model.CustomModel.KeyValueModel zscKeyValue = new Model.CustomModel.KeyValueModel();
                zscKeyValue.Key = "总时长";
                zscKeyValue.Value = entryStatistics.M_Entry_Duration + "小时";
                keyValues.Add(zscKeyValue);

                CommonService.Model.CustomModel.KeyValueModel tmksKeyValue = new Model.CustomModel.KeyValueModel();
                tmksKeyValue.Key = "条目开始  ";
                tmksKeyValue.Value = entryStatistics.M_Entry_Statistics_entrySTime + "";
                keyValues.Add(tmksKeyValue);


                CommonService.Model.CustomModel.KeyValueModel tmjsKeyValue = new Model.CustomModel.KeyValueModel();
                tmjsKeyValue.Key = "条目结束   ";
                tmjsKeyValue.Value = entryStatistics.M_Entry_Statistics_entryETime + "";
                keyValues.Add(tmjsKeyValue);

                CommonService.Model.CustomModel.KeyValueModel blqkKeyValue = new Model.CustomModel.KeyValueModel();
                blqkKeyValue.Key = "办理情况     ";
                blqkKeyValue.Value = entryStatistics.M_Entry_Statistics_Management + "";
                keyValues.Add(blqkKeyValue);

                string handlingStateName = String.Empty;
                List<CommonService.Model.C_Parameters> handlingStates = parameterBLL.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.监控状态));
                foreach (var handingState in handlingStates)
                {
                    if (entryStatistics.M_Entry_Statistics_HandlingState != null)
                    {
                        if (handingState.C_Parameters_id == entryStatistics.M_Entry_Statistics_HandlingState.Value)
                        {
                            handlingStateName = handingState.C_Parameters_name;
                            break;
                        }
                    }
                }
               
                CommonService.Model.CustomModel.KeyValueModel blztKeyValue = new Model.CustomModel.KeyValueModel();
                blztKeyValue.Key = "办理状态";
                blztKeyValue.Value = handlingStateName;
                keyValues.Add(blztKeyValue);

                string warningName = String.Empty;
                List<CommonService.Model.C_Parameters> warningSituations = parameterBLL.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警情况));
                foreach (var waring in warningSituations)
                {
                    if (entryStatistics.M_Entry_Statistics_warningSituation != null)
                    {
                        if (waring.C_Parameters_id == entryStatistics.M_Entry_Statistics_warningSituation.Value)
                        {
                            warningName = waring.C_Parameters_name;
                            break;
                        }
                    }
                }

                CommonService.Model.CustomModel.KeyValueModel yjqkKeyValue = new Model.CustomModel.KeyValueModel();
                yjqkKeyValue.Key = "预警情况";
                yjqkKeyValue.Value = warningName;
                keyValues.Add(yjqkKeyValue);

            }

            return keyValues;
        }

        /// <summary>
        /// 根据条目变更标识，获取条目变更信息
        /// </summary>
        /// <param name="entryChangeCode">条目变更标识</param>
        /// <returns></returns>    
        public CommonService.Model.MonitorManager.M_Entry_Change GetEntryChange(string entryChangeCode)
        {           
            return this.GetModel(new Guid(entryChangeCode));
        }

        /// <summary>
        /// 审批变更时长业务
        /// </summary>
        /// <param name="entryChangeCode">条目变更标识</param>
        /// <param name="approvalDuration">变更审批时长</param>
        /// <param name="approvalReaso">变更审批理由</param>
        /// <param name="IsThrough">变更类型</param>
        /// <param name="operateChildrenUserCode">操作子用户标识</param>
        /// <param name="operateChildrenUserName">操作子用户名称</param>
        /// <returns></returns>    
        public int AproveEntryChange(string entryChangeCode,string approvalDuration, string approvalReaso, string IsThrough, string operateChildrenUserCode, string operateChildrenUserName)
        {
            int status = 0;//代表审批失败
 
            CommonService.Model.MonitorManager.M_Entry_Change entryChange = this.GetModel(new Guid(entryChangeCode));
            if (entryChange == null)
                return status;


            if (entryChange.M_Entry_Change_IsThrough != Convert.ToInt32(EntryChangeIsThroughlEnum.未审批))
            {
                status = -1;//代表此变更已审批过
                return status;
            }
     

            //执行条目变更业务
            bool isSuccess = false;
            entryChange.M_Entry_Change_approvalPerson = operateChildrenUserName;
            entryChange.M_Entry_Change_Approval = new Guid(operateChildrenUserCode);
            entryChange.M_Entry_Change_approvalTime = DateTime.Now;
            entryChange.M_Entry_Change_IsThrough = Convert.ToInt32(IsThrough);
            int _approvalDuration=0;
            if (int.TryParse(approvalDuration, out _approvalDuration))
            {
            }
            entryChange.M_Entry_Change_approvalDuration = _approvalDuration;
            entryChange.M_Entry_Change_approvalReason = approvalReaso;

            isSuccess = this.Update(entryChange);

            if (isSuccess)
                status = 1;//代表审批成功
            else
                status = 0;

            return status;
        }

        #endregion

    }
}

