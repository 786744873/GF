using CommonService.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CustomerForm
{
    /// <summary>
    /// 自定义表单属性表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/05/12
    /// </summary>
    public partial class F_FormProperty
    {
        private readonly CommonService.DAL.CustomerForm.F_FormProperty dal = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单时间声明数据访问层
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormDateDeclare formDateDeclareDAL = new CommonService.DAL.CustomerForm.F_FormDateDeclare();
        /// <summary>
        /// 参数数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Parameters parameterDAL = new CommonService.DAL.C_Parameters();
        /// <summary>
        /// 用户数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Userinfo userDAL = new CommonService.DAL.SysManager.C_Userinfo();

        public F_FormProperty()
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
        public bool Exists(int C_FormProperty_id)
        {
            return dal.Exists(C_FormProperty_id);
        }


        /// <summary>
        /// 检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public bool ExistsFieldName(string fieldName, Guid formCode)
        {
            return dal.ExistsFieldName(fieldName, formCode);
        }

        /// <summary>
        /// 检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public bool ExistsFieldName(string fieldName, Guid formCode, Guid formPropertyCode)
        {
            return dal.ExistsFieldName(fieldName, formCode, formPropertyCode);
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public bool MoveForward(Guid formCode, Guid formPropertyCode)
        {
            /**
             **作者：贺太玉
             **2015/05/15
             **业务说明：1,先获的当前属性的显示顺序号；2,获取向前移动一个顺序单位的属性对象；3,当前需要移动的属性与向前一个单位的属性交互顺序号；4,如果已经移动到第一位，则不可以再继续
             *移动；4,显示属性顺序号不可以重复
             **/
            CommonService.Model.CustomerForm.F_FormProperty thisFormProperty = dal.GetModel(formPropertyCode);
            Guid parentPropertyCode = thisFormProperty.F_FormProperty_parent.Value;
            CommonService.Model.CustomerForm.F_FormProperty forwardFormProperty = dal.GetModel(formCode, parentPropertyCode, ConditonType.小于, thisFormProperty.F_FormProperty_orderBy.Value);
            if (forwardFormProperty != null)
            {
                int thisPropertyOrderBy = thisFormProperty.F_FormProperty_orderBy.Value;
                int forwardPropertyOrderBy = forwardFormProperty.F_FormProperty_orderBy.Value;
                thisFormProperty.F_FormProperty_orderBy = forwardPropertyOrderBy;
                dal.Update(thisFormProperty);
                forwardFormProperty.F_FormProperty_orderBy = thisPropertyOrderBy;
                dal.Update(forwardFormProperty);
            }
            return true;
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public bool MoveBackward(Guid formCode, Guid formPropertyCode)
        {
            /**
             **作者：贺太玉
             **2015/05/15
             **业务说明：1,先获的当前属性的显示顺序号；2,获取向后移动一个顺序单位的属性对象；3,当前需要移动的属性与向后一个单位的属性交互顺序号；4,如果已经移动到最后一位，则不可以再继续
             *移动；4,显示属性顺序号不可以重复
            **/
            CommonService.Model.CustomerForm.F_FormProperty thisFormProperty = dal.GetModel(formPropertyCode);
            Guid parentPropertyCode = thisFormProperty.F_FormProperty_parent.Value;
            CommonService.Model.CustomerForm.F_FormProperty backwardFormProperty = dal.GetModel(formCode, parentPropertyCode, ConditonType.大于, thisFormProperty.F_FormProperty_orderBy.Value);
            if (backwardFormProperty != null)
            {
                int thisPropertyOrderBy = thisFormProperty.F_FormProperty_orderBy.Value;
                int backwardPropertyOrderBy = backwardFormProperty.F_FormProperty_orderBy.Value;
                thisFormProperty.F_FormProperty_orderBy = backwardPropertyOrderBy;
                dal.Update(thisFormProperty);
                backwardFormProperty.F_FormProperty_orderBy = thisPropertyOrderBy;
                dal.Update(backwardFormProperty);
            }
            return true;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            /**
             **作者：贺太玉
             **2015/05/14
             **业务说明：
             **(1)、新增时处理显示顺序，如果新增属性为新建自定义表单时，自动创建的基础属性，则不允许人为操作显示顺序
             **(2)、添加表单属性时，如果此属性为"日期"或"日期时间"类型，则需要在对应时间记录表(F_FormDateDeclare)里插入数据
             *      暂时不考虑"字段名称"和"显示名称"和"属性类型"改变的情况,以后业务确定后再处理...
            **/
            if (!model.F_FormProperty_isBase)
            {
                model.F_FormProperty_orderBy = dal.GetMaxOrderBy(model.F_FormProperty_form.Value);
            }

            if (model.F_FormProperty_uiType.Value == Convert.ToInt32(UiControlType.日期框) || model.F_FormProperty_uiType.Value == Convert.ToInt32(UiControlType.日期时间框))
            {
                CommonService.Model.CustomerForm.F_FormDateDeclare formDateDeclare = new CommonService.Model.CustomerForm.F_FormDateDeclare();
                formDateDeclare.F_FormDateDeclare_code = Guid.NewGuid();
                formDateDeclare.F_FormDateDeclare_formCode = model.F_FormProperty_form;
                formDateDeclare.F_FormDateDeclare_column = model.F_FormProperty_fieldName;
                formDateDeclare.F_FormDateDeclare_name = model.F_FormProperty_showName;
                formDateDeclare.F_FormDateDeclare_type = Convert.ToInt32(TimeBelongTypeEnum.表单);

                formDateDeclareDAL.Add(formDateDeclare);
            }

            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_FormProperty_code)
        {

            return dal.Delete(F_FormProperty_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_FormProperty_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_FormProperty_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormProperty GetModel(Guid F_FormProperty_code)
        {

            return dal.GetModel(F_FormProperty_code);
        }

        /// <summary>
        /// 通过表单属性值Id，得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormProperty GetModelById(int F_FormProperty_id)
        {

            return dal.GetModelById(F_FormProperty_id);
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
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取基础属性列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetBaseModelList()
        {
            DataSet ds = dal.GetBaseList();
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyParent">父亲属性Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetModelList(Guid formCode, Guid formPropertyParent)
        {
            DataSet ds = dal.GetList(formCode, formPropertyParent);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据表单Guid，UI属性类型，获取属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="uIType">UI属性类型</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetListByFormAndUiType(Guid formCode, int uIType)
        {
            DataSet ds = dal.GetListByFormAndUiType(formCode, uIType);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetModelList(Guid formCode)
        {
            DataSet ds = dal.GetList(formCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据协同办公表单Guid，获取编辑协同办公表单属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetOAEditFormPropertyValueList(Guid fFormCode, Guid oFormCode)
        {
            DataSet ds = dal.GetOAEditFormPropertyValueList(fFormCode, oFormCode);
            List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys = DataTableToList(ds.Tables[0]);

            HandleShowName(F_FormPropertys);

            return F_FormPropertys;
        }

        /// <summary>
        /// 根据协同办公表单Guid，获取主子表协同办公表单编辑属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetOAHeadEditFormPropertyValueList(Guid fFormCode, Guid oFormCode)
        {
            DataSet ds = dal.GetOAHeadEditFormPropertyValueList(fFormCode, oFormCode);
            List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys = DataTableToList(ds.Tables[0]);

            HandleShowName(F_FormPropertys);

            return F_FormPropertys;
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode)
        {
            DataSet ds = dal.GetEditFormPropertyValueList(formCode, businessFlowFormCode);
            List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys = DataTableToList(ds.Tables[0]);

            HandleShowName(F_FormPropertys);

            return F_FormPropertys;
        }

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetEditFormHistorRecord(Guid businessFlowCode, Guid formCode)
        {
            DataSet ds = dal.GetEditFormHistorRecord(businessFlowCode, formCode);
            List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys = DataTableToList(ds.Tables[0]);

            SwitchShowNameToValue(F_FormPropertys);

            return F_FormPropertys;
        }

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetHeadEditFormHistoryRecord(Guid businessFlowCode, Guid formCode)
        {
            DataSet ds = dal.GetHeadEditFormHistoryRecord(businessFlowCode, formCode);
            List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys = DataTableToList(ds.Tables[0]);

            SwitchShowNameToValue(F_FormPropertys);

            return F_FormPropertys;
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取tab编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="parentFormPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetTabEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode, Guid parentFormPropertyCode)
        {
            DataSet ds = dal.GetTabEditFormPropertyValueList(formCode, businessFlowFormCode, parentFormPropertyCode);
            List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys = DataTableToList(ds.Tables[0]);

            HandleShowName(F_FormPropertys);

            return F_FormPropertys;
        }

        /// <summary>
        /// 处理关联其它数据源的表单属性名称显示
        /// </summary>
        /// <param name="F_FormPropertys"></param>
        public void HandleShowName(List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys)
        {
            #region 处理表单属性关联数据源后，取显示名称的逻辑

            foreach (CommonService.Model.CustomerForm.F_FormProperty formProperty in F_FormPropertys)
            {
                if (formProperty.F_FormProperty_dataSource_type != null)
                {
                    if (formProperty.F_FormProperty_dataSource_type.Value == 118)
                    {//数据源类型：参数表
                        if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value) && formProperty.F_FormProperty_code != new Guid("4222E22E-8CB9-4617-8C39-F317E801AB5D")) //排除特殊“确定诉讼请求”
                        {
                            formProperty.V_FormPropertyValue_Value_Name = parameterDAL.GetModel(Convert.ToInt32(formProperty.V_FormPropertyValue_Value)) == null ? "" : parameterDAL.GetModel(Convert.ToInt32(formProperty.V_FormPropertyValue_Value)).C_Parameters_name;
                        }
                    }
                    else if (formProperty.F_FormProperty_dataSource_type.Value == 119)
                    {//数据源类型：资料库表
                        switch (formProperty.F_FormProperty_uiType.Value)
                        {
                            case 136://单选弹出框
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    formProperty.V_FormPropertyValue_Value_Name = dal.GetSingleEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                                }
                                break;
                            case 138://单选弹出树
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    formProperty.V_FormPropertyValue_Value_Name = dal.GetSingleEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                                }
                                break;
                            case 137://多选弹出框
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    formProperty.V_FormPropertyValue_Value_Name = dal.GetMulityEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                                }
                                break;
                            default://其它UI类型，用到的时候再扩展
                                break;
                        }
                    }
                    else if (formProperty.F_FormProperty_dataSource_type.Value == 186)
                    {//数据源类型：自定义表单，如有需要以后扩展

                    }
                }

                if(!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value)&&(formProperty.F_FormProperty_code == Guid.Parse("A191678E-D8E2-4CEE-B163-2679E88A3D89")||formProperty.F_FormProperty_code == Guid.Parse("ED4A185A-76DC-4DD3-BCF1-D6000CD8BF64")||formProperty.F_FormProperty_code==Guid.Parse("6CDA7B58-B098-4597-8847-14D2DE3D2956"))) //预期收益计算的审核人名称处理
                {
                    BLL.SysManager.C_Userinfo userBLL = new SysManager.C_Userinfo();
                    Model.SysManager.C_Userinfo user = userBLL.GetUserinfoByCode(Guid.Parse(formProperty.V_FormPropertyValue_Value));
                    formProperty.V_FormPropertyValue_Value_Name = user.C_Userinfo_name;
                }
            }

            #endregion
        }

        /// <summary>
        /// 在表单属性关联其它数据源的时候，转化显示值到属性值中
        /// </summary>
        /// <param name="F_FormPropertys">表单属性及其值集合</param>
        private void SwitchShowNameToValue(List<CommonService.Model.CustomerForm.F_FormProperty> F_FormPropertys)
        {
            foreach (CommonService.Model.CustomerForm.F_FormProperty formProperty in F_FormPropertys)
            {
                #region 处理个性化自定义表单属性

                #region 个性化"预期收益计算"表单
                if (formProperty.F_FormProperty_form.Value.ToString().ToLower() == "128ebf60-f58e-4ae2-b3b7-826dd62a0960")
                {
                    if (formProperty.F_FormProperty_code.Value.ToString().ToLower() == "a191678e-d8e2-4cee-b163-2679e88a3d89"
                        || formProperty.F_FormProperty_code.Value.ToString().ToLower() == "ed4a185a-76dc-4dd3-bcf1-d6000cd8bf64"
                        || formProperty.F_FormProperty_code.Value.ToString().ToLower() == "6cda7b58-b098-4597-8847-14d2de3d2956")
                    {//审核人转换
                        if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                        {
                            CommonService.Model.SysManager.C_Userinfo checkUser = userDAL.GetModelByCode(new Guid(formProperty.V_FormPropertyValue_Value));
                            formProperty.V_FormPropertyValue_Value = checkUser == null ? "" : checkUser.C_Userinfo_name;
                        }
                        continue;
                    }
                }
                #endregion

                #region 个性化"诉讼方案"表单
                if (formProperty.F_FormProperty_form.Value.ToString().ToLower() == "d20a4ff3-6063-456d-8656-28382923029a")
                {
                    if (formProperty.F_FormProperty_code.Value.ToString().ToLower() == "4222e22e-8cb9-4617-8c39-f317e801ab5d")
                    {//确定诉讼请求转换
                        if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                        {
                            string ssqqValue = String.Empty;
                            //拆分诉讼请求值
                            string[] valueGroup = formProperty.V_FormPropertyValue_Value.Split('&');
                            for (int i = 0; i < valueGroup.Length; i++)
                            {
                                string tempValue = valueGroup[i];
                                string[] tempValueGroup = tempValue.Split('_');
                                CommonService.Model.C_Parameters parameter = parameterDAL.GetModel(Convert.ToInt32(tempValueGroup[0]));
                                if (parameter != null)
                                {
                                    ssqqValue += "" + parameter.C_Parameters_name + ":" + tempValueGroup[1] + ",";
                                }
                            }
                            if (!String.IsNullOrEmpty(ssqqValue))
                            {
                                ssqqValue = ssqqValue.Substring(0, ssqqValue.Length - 1);
                            }
                            formProperty.V_FormPropertyValue_Value = ssqqValue;
                        }
                        continue;
                    }
                }
                #endregion

                #region 个性化"庭审情况"表单
                if (formProperty.F_FormProperty_form.Value.ToString().ToLower() == "b53cab9d-a6e6-4279-a4ef-d8198926a3c7")
                {
                    if (formProperty.F_FormProperty_code.Value.ToString().ToLower() == "949b2c01-9ba1-4089-8e1d-437acb72a2ad")
                    {//人员转换
                        if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                        {
                            string tempValue = String.Empty;
                            string[] keyValueGroup = formProperty.V_FormPropertyValue_Value.Split('&');
                            string[] keyGroup = keyValueGroup[0].Split(',');//键组
                            string[] valueGroup = keyValueGroup[1].Split(',');//值组
                            //键组长度=值组长度
                            for (int i = 0; i < keyGroup.Length; i++)
                            {
                                if (keyGroup[i] == "uibox_39E00F28-D32A-431C-A33F-E236689CDBC3")
                                {//审判长
                                    tempValue += "审判长:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_22B6899B-8961-4153-84B2-2DDB63EAA34B")
                                {//其他合议庭人员
                                    tempValue += "其他合议庭人员:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_CE5F2CFC-0FB2-4192-9456-C4773B28B237")
                                {//原告
                                    tempValue += "原告:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_4A905826-5E4D-43EE-9992-F04D6A778B63")
                                {//原告法人
                                    tempValue += "原告法人:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_9D33AA39-0CE2-41E5-9A50-35BA6C2B1C6A")
                                {//原告其他代理人
                                    tempValue += "原告其他代理人:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_D6914E65-663B-412D-97BE-E0031C6A2FD0")
                                {//被告法人
                                    tempValue += "被告法人:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_A6ACC31B-01A9-48FA-AD02-CF29F2F6A8FC")
                                {//其他诉讼参与人
                                    tempValue += "其他诉讼参与人:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_6F808910-01BC-45FD-B824-470EFC1DBC90")
                                {//承办人
                                    tempValue += "承办人:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_8C044BCC-3D62-4156-A69D-A3962D12F209")
                                {//书记员
                                    tempValue += "书记员:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_B606DF9D-E06F-4B2D-AD5D-4A0647EF3B2E")
                                {//我方代理律师
                                    tempValue += "我方代理律师:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_26287EE9-2D9A-49FB-B7C1-34DF6ACF5733")
                                {//证人
                                    tempValue += "证人:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_B59BD138-B23F-4CC9-9825-37C66D4AA6B0")
                                {//被告
                                    tempValue += "被告:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_CF6ED390-1290-491B-88D9-DBD3879261A7")
                                {//被告代理律师
                                    tempValue += "被告代理律师:" + valueGroup[i] + ",";
                                }
                                else if (keyGroup[i] == "uibox_AFC857AF-9DB3-485F-B9E3-3D4B38D509D9")
                                {//被告其他代理人
                                    tempValue += "被告其他代理人:" + valueGroup[i] + ",";
                                }
                            }
                            if (!string.IsNullOrEmpty(tempValue))
                            {
                                tempValue = tempValue.Substring(0, tempValue.Length - 1);
                            }
                            formProperty.V_FormPropertyValue_Value = tempValue;
                        }
                        continue;
                    }
                }
                #endregion

                #endregion

                if (formProperty.F_FormProperty_dataSource_type != null)
                {
                    if (formProperty.F_FormProperty_dataSource_type.Value == 118)
                    {//数据源类型：参数表
                        #region
                        switch (formProperty.F_FormProperty_uiType.Value)
                        {
                            default://其它UI类型，默认
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    CommonService.Model.C_Parameters parameter = parameterDAL.GetModel(Convert.ToInt32(formProperty.V_FormPropertyValue_Value));
                                    formProperty.V_FormPropertyValue_Value = parameter == null ? "" : parameter.C_Parameters_name;
                                }
                                break;
                        }
                        #endregion
                    }
                    else if (formProperty.F_FormProperty_dataSource_type.Value == 119)
                    {//数据源类型：资料库表
                        #region
                        switch (formProperty.F_FormProperty_uiType.Value)
                        {
                            case 136://单选弹出框
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    formProperty.V_FormPropertyValue_Value = dal.GetSingleEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                                }
                                break;
                            case 138://单选弹出树
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    formProperty.V_FormPropertyValue_Value = dal.GetSingleEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                                }
                                break;
                            case 137://多选弹出框
                                if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                                {
                                    formProperty.V_FormPropertyValue_Value = dal.GetMulityEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                                }
                                break;
                            default://其它UI类型，用到的时候再扩展
                                break;
                        }
                        #endregion
                    }
                    else if (formProperty.F_FormProperty_dataSource_type.Value == 186)
                    {//数据源类型：自定义表单，如有需要以后扩展

                    }
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormProperty> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CustomerForm.F_FormProperty> modelList = new List<CommonService.Model.CustomerForm.F_FormProperty>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CustomerForm.F_FormProperty model;
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
        public int GetRecordCount(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormProperty> GetListByPage(CommonService.Model.CustomerForm.F_FormProperty model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
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

        #region App专用
        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录（不包含隐藏控件）
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<Model.CustomerForm.F_FormProperty> GetValuesByBusinessFormCode(Guid? guid)
        {
            List<Model.CustomerForm.F_FormProperty> list = DataTableToList(dal.GetHeadEditFormHistoryRecord(guid.Value).Tables[0]);
            HandleShowName(list);
            return list;
        }
        #endregion
    }
}
