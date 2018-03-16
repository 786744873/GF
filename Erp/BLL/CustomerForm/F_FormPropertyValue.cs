using CommonService.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CustomerForm
{
    /// <summary>
    /// 自定义表单属性值表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/05/12
    /// </summary>
    public partial class F_FormPropertyValue
    {
        private readonly CommonService.DAL.CustomerForm.F_FormPropertyValue dal = new CommonService.DAL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 表单属性数据访问对象
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单属性业务访问对象
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormProperty formPropertyBLL = new CommonService.BLL.CustomerForm.F_FormProperty();
        public F_FormPropertyValue()
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
        public bool Exists(int C_FormPropertyValue_id)
        {
            return dal.Exists(C_FormPropertyValue_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 初始化表单属性值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关系Guid</param>
        /// <returns></returns>
        public bool InitializationFormPropertyValue(Guid formCode, Guid businessFlowFormCode, Guid userCode)
        {
            /**
             **作者：贺太玉
             **2015/05/14
             **业务说明：在表单属性值初始化的时候，先删除关联表单属性值数据，然后插入关联表单属性值空数据
             **/

            dal.Delete(formCode, businessFlowFormCode);
            int customerType = formPropertyDAL.GetFormCustomerType(formCode);
            switch (customerType)
            {
                case 1://普通编辑表单
                    this.InitializationEditFormPropertyValue(formCode, businessFlowFormCode, userCode);
                    break;
                case 2://主子表单，仅仅不初始化子属性，其余表单属性均初始化
                    //先初始化 父亲属性为'00000000-0000-0000-0000-000000000000'的属性值
                    this.InitializationOAItemsFormPropertyValue(formCode, businessFlowFormCode, userCode);
                    //再初始化 主表编辑属性值以及子表属性值
                    this.InitializationOAHeadItemsPropertyValue(formCode, businessFlowFormCode, userCode);
                    break;
                case 3://明细子表，仅仅不初始化子属性，其余表单属性均初始化
                    this.InitializationOAItemsFormPropertyValue(formCode, businessFlowFormCode, userCode);
                    break;
                case 4://tab 容器
                    break;
            }


            return true;
        }

        /// <summary>
        /// 初始化编辑表单属性值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关系Guid</param>
        /// <returns></returns>
        public bool InitializationEditFormPropertyValue(Guid formCode, Guid businessFlowFormCode, Guid userCode)
        {
            DateTime now = DateTime.Now;
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = formPropertyBLL.GetModelList(formCode);
            foreach (var formProperty in formPropertys)
            {
                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = new Model.CustomerForm.F_FormPropertyValue();
                formPropertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                formPropertyValue.F_FormPropertyValue_form = formCode;
                formPropertyValue.F_FormPropertyValue_BusinessFlowFormCode = businessFlowFormCode;
                formPropertyValue.F_FormPropertyValue_formProperty = formProperty.F_FormProperty_code;
                formPropertyValue.F_FormPropertyValue_isDelete = false;
                formPropertyValue.F_FormPropertyValue_creator = userCode;
                formPropertyValue.F_FormPropertyValue_createTime = now;

                this.Add(formPropertyValue);
            }

            return true;
        }

        /// <summary>
        /// 初始化协同办公表单属性值(只有普通编辑的页面)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public bool InitializationOAFormPropertyValue(Guid fFormCode, Guid oFormCode, Guid userCode)
        {
            /**
             **作者：贺太玉
             **2015/08/07
             **业务说明：在表单属性值初始化的时候，插入关联表单属性值空数据(如果存在子表信息，在这里先不插入)
             **/
            DateTime now = DateTime.Now;
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = formPropertyBLL.GetModelList(fFormCode);
            foreach (var formProperty in formPropertys)
            {
                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = new Model.CustomerForm.F_FormPropertyValue();
                formPropertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                formPropertyValue.F_FormPropertyValue_form = fFormCode;
                formPropertyValue.F_FormPropertyValue_BusinessFlowFormCode = oFormCode;
                formPropertyValue.F_FormPropertyValue_formProperty = formProperty.F_FormProperty_code;
                formPropertyValue.F_FormPropertyValue_isDelete = false;
                formPropertyValue.F_FormPropertyValue_creator = userCode;
                formPropertyValue.F_FormPropertyValue_createTime = now;

                this.Add(formPropertyValue);
            }
            return true;
        }

        /// <summary>
        /// 初始化协同办公表单属性值(只有普通子表的页面，并且不初始化子属性)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public bool InitializationOAItemsFormPropertyValue(Guid fFormCode, Guid oFormCode, Guid userCode)
        {
            /**
             **作者：贺太玉
             **2015/08/12
             **业务说明：在表单属性值初始化的时候，插入关联表单属性值空数据
             **/
            DateTime now = DateTime.Now;
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = formPropertyBLL.GetModelList(fFormCode, Guid.Empty);
            foreach (var formProperty in formPropertys)
            {
                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = new Model.CustomerForm.F_FormPropertyValue();
                formPropertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                formPropertyValue.F_FormPropertyValue_form = fFormCode;
                formPropertyValue.F_FormPropertyValue_BusinessFlowFormCode = oFormCode;
                formPropertyValue.F_FormPropertyValue_formProperty = formProperty.F_FormProperty_code;
                formPropertyValue.F_FormPropertyValue_isDelete = false;
                formPropertyValue.F_FormPropertyValue_creator = userCode;
                formPropertyValue.F_FormPropertyValue_createTime = now;

                this.Add(formPropertyValue);
            }
            return true;
        }

        /// <summary>
        /// 初始化协同办公表单属性值(主子表的页面，并且只初始化主表编辑属性值以及子表属性值)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public bool InitializationOAHeadItemsPropertyValue(Guid fFormCode, Guid oFormCode, Guid userCode)
        {
            /**
             **作者：贺太玉
             **2015/08/14
             **业务说明：
             **/
            DateTime now = DateTime.Now;
            List<CommonService.Model.CustomerForm.F_FormProperty> parentFormPropertys = formPropertyBLL.GetListByFormAndUiType(fFormCode, Convert.ToInt32(UiControlType.主子表));
            foreach (var parentFormProperty in parentFormPropertys)
            {
                List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = formPropertyBLL.GetModelList(fFormCode, parentFormProperty.F_FormProperty_code.Value);
                foreach (var formProperty in formPropertys)
                {
                    CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = new Model.CustomerForm.F_FormPropertyValue();
                    formPropertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                    formPropertyValue.F_FormPropertyValue_form = fFormCode;
                    formPropertyValue.F_FormPropertyValue_BusinessFlowFormCode = oFormCode;
                    formPropertyValue.F_FormPropertyValue_formProperty = formProperty.F_FormProperty_code;
                    formPropertyValue.F_FormPropertyValue_isDelete = false;
                    formPropertyValue.F_FormPropertyValue_creator = userCode;
                    formPropertyValue.F_FormPropertyValue_createTime = now;

                    this.Add(formPropertyValue);
                }
            }
            return true;
        }

        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(DataSet中允许包含多个table)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>
        public DataSet DynamicLoadCustmerFormListValues(Guid fFormCode, Guid relCode)
        {
            return dal.DynamicLoadCustmerFormListValues(fFormCode, relCode);
        }

        /// <summary>
        /// 动态加载自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int DynamicLoadFeeFormListCount(Guid fFormCode, string condition)
        {
            return dal.DynamicLoadFeeFormListCount(fFormCode, condition);
        }
        /// <summary>
        /// 动态加载oa自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int DynamicLoadOAFeeFormListCount(Guid fFormCode, string condition)
        {
            return dal.DynamicLoadOAFeeFormListCount(fFormCode, condition);
        }
        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public DataSet DynamicLoadFeeFormListValues(Guid fFormCode, int startIndex, int endIndex, string condition)
        {
            return dal.DynamicLoadFeeFormListValues(fFormCode, startIndex, endIndex, condition);
        }
        /// <summary>
        /// 动态加载OA自定义表单普通子表属性值集合(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public DataSet DynamicLoadOAFeeFormListValues(Guid fFormCode, int startIndex, int endIndex, string condition)
        {
            return dal.DynamicLoadOAFeeFormListValues(fFormCode, startIndex, endIndex, condition);
        }
        /// <summary>
        /// 通过业务条件，获取关联自定义表单属性值列表(只针对自定义表单的某一属性关联了另外一个自定义表单的某一属性)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetCustFormPropertyValues(Guid formCode, Guid formPropertyCode, Guid businessFlowFormCode)
        {
            DataSet ds = dal.GetCustFormPropertyValues(formCode, formPropertyCode, businessFlowFormCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 根据表单属性值Guid，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>
        public bool UpdateFormPropertyValueByPropertyCode(List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues)
        {
            bool isUpdateSuccess = true;
            foreach (CommonService.Model.Customer.V_FormPropertyValue vFormPropertyValue in V_FormPropertyValues)
            {
                if (!dal.UpdateFormPropertyValueByPropertyCode(vFormPropertyValue))
                {
                    isUpdateSuccess = false;//这里只是用来标识执行是否完全成功，如果有一条 update 语句没有执行成功，则代表整个执行失败，这里只是用来提示作用
                }
            }
            return isUpdateSuccess;
        }

        /// <summary>
        /// 根据表单属性值Id，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>
        public bool UpdateFormPropertyValueByPropertyId(List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues)
        {
            bool isUpdateSuccess = true;
            foreach (CommonService.Model.Customer.V_FormPropertyValue vFormPropertyValue in V_FormPropertyValues)
            {
                if (!dal.UpdateFormPropertyValueByPropertyId(vFormPropertyValue))
                {
                    isUpdateSuccess = false;//这里只是用来标识执行是否完全成功，如果有一条 update 语句没有执行成功，则代表整个执行失败，这里只是用来提示作用
                }
            }
            return isUpdateSuccess;
        }

        /// <summary>
        /// 处理ERP主子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        ///  <param name="V_HeadFormPropertyValues">主表表单属性值集合</param>
        /// <param name="ItemFormPropertyValues">子表表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>       
        public bool SaveHeadItemsFormPropertyValue(List<CommonService.Model.Customer.V_FormPropertyValue> V_HeadFormPropertyValues, List<CommonService.Model.CustomerForm.F_FormPropertyValue> ItemFormPropertyValues, Guid fFormCode, Guid relCode)
        {
            bool isSuccess = this.UpdateFormPropertyValueByPropertyCode(V_HeadFormPropertyValues);

            if (isSuccess)
            {
                this.SaveItemsFormPropertyValue(ItemFormPropertyValues, fFormCode, relCode, 2);
            }

            return isSuccess;
        }

        /// <summary>
        /// 处理ERP普通子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        /// <param name="FormPropertyValues">表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <param name="type">1代表普通子表子属性值；2代表主子表中普通子表子属性值</param>
        /// <returns></returns>
        public bool SaveItemsFormPropertyValue(List<CommonService.Model.CustomerForm.F_FormPropertyValue> FormPropertyValues, Guid fFormCode, Guid relCode, int type)
        {
            /**
             * author:hety
             * date:2015-08-12
             * description:协同办公系统普通子表属性值保存，修改，删除业务逻辑
             * 
             ***/
            ArrayList propertyValueCodeArray = new ArrayList();//当前已处理表单属性值Guid
            foreach (CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue in FormPropertyValues)
            {
                if (formPropertyValue.F_FormPropertyValue_id <= 0)
                {
                    #region 新增
                    dal.Add(formPropertyValue);
                    propertyValueCodeArray.Add(formPropertyValue.F_FormPropertyValue_code.Value);
                    #endregion
                }
                else
                {
                    #region 修改
                    CommonService.Model.CustomerForm.F_FormPropertyValue updateFormPropertyValue = dal.GetModel(formPropertyValue.F_FormPropertyValue_id);
                    if (updateFormPropertyValue != null)
                    {
                        updateFormPropertyValue.F_FormPropertyValue_value = formPropertyValue.F_FormPropertyValue_value;
                        dal.Update(updateFormPropertyValue);
                        propertyValueCodeArray.Add(updateFormPropertyValue.F_FormPropertyValue_code.Value);
                    }
                    #endregion
                }
            }

            #region 处理已删除表单属性
            //当前表单关联所有子属性值集合
            List<CommonService.Model.CustomerForm.F_FormPropertyValue> AllFormPropertyValues = this.GetChildrenPropertyValueList(fFormCode, relCode, type);
            foreach (CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue in AllFormPropertyValues)
            {
                if (!propertyValueCodeArray.Contains(formPropertyValue.F_FormPropertyValue_code.Value))
                {//不存在，代表已删除
                    formPropertyValue.F_FormPropertyValue_isDelete = true;
                    dal.Update(formPropertyValue);
                }
            }
            #endregion

            return true;
        }


        /// <summary>
        /// 处理OA主子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        ///  <param name="V_HeadFormPropertyValues">主表表单属性值集合</param>
        /// <param name="ItemFormPropertyValues">子表表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>       
        public bool SaveOAHeadItemsFormPropertyValue(List<CommonService.Model.Customer.V_FormPropertyValue> V_HeadFormPropertyValues, List<CommonService.Model.CustomerForm.F_FormPropertyValue> ItemFormPropertyValues, Guid fFormCode, Guid relCode)
        {
            bool isSuccess = this.UpdateFormPropertyValueByPropertyId(V_HeadFormPropertyValues);

            if (isSuccess)
            {
                this.SaveOAItemsFormPropertyValue(ItemFormPropertyValues, fFormCode, relCode, 2);
            }

            return isSuccess;
        }

        /// <summary>
        /// 处理OA普通子表表单属性值("新增"或"修改"或"删除"逻辑)
        /// </summary>
        /// <param name="FormPropertyValues">表单属性值集合</param>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <param name="type">1代表普通子表子属性值；2代表主子表中普通子表子属性值</param>
        /// <returns></returns>
        public bool SaveOAItemsFormPropertyValue(List<CommonService.Model.CustomerForm.F_FormPropertyValue> FormPropertyValues, Guid fFormCode, Guid relCode, int type)
        {
            /**
             * author:hety
             * date:2015-08-12
             * description:协同办公系统普通子表属性值保存，修改，删除业务逻辑
             * 
             ***/
            ArrayList propertyValueCodeArray = new ArrayList();//当前已处理表单属性值Guid
            foreach (CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue in FormPropertyValues)
            {
                if (formPropertyValue.F_FormPropertyValue_id <= 0)
                {
                    #region 新增
                    CommonService.Model.CustomerForm.F_FormProperty formProperty = formPropertyBLL.GetModelById(formPropertyValue.F_FormPropertyValue_formProperty_id.Value);
                    if (formProperty != null)
                    {
                        formPropertyValue.F_FormPropertyValue_formProperty = formProperty.F_FormProperty_code;
                    }
                    dal.Add(formPropertyValue);
                    propertyValueCodeArray.Add(formPropertyValue.F_FormPropertyValue_code.Value);
                    #endregion
                }
                else
                {
                    #region 修改
                    CommonService.Model.CustomerForm.F_FormPropertyValue updateFormPropertyValue = dal.GetModel(formPropertyValue.F_FormPropertyValue_id);
                    if (updateFormPropertyValue != null)
                    {
                        updateFormPropertyValue.F_FormPropertyValue_value = formPropertyValue.F_FormPropertyValue_value;
                        dal.Update(updateFormPropertyValue);
                        propertyValueCodeArray.Add(updateFormPropertyValue.F_FormPropertyValue_code.Value);
                    }
                    #endregion
                }
            }

            #region 处理已删除表单属性
            //当前表单关联所有子属性值集合
            List<CommonService.Model.CustomerForm.F_FormPropertyValue> AllFormPropertyValues = this.GetChildrenPropertyValueList(fFormCode, relCode, type);
            foreach (CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue in AllFormPropertyValues)
            {
                if (!propertyValueCodeArray.Contains(formPropertyValue.F_FormPropertyValue_code.Value))
                {//不存在，代表已删除
                    formPropertyValue.F_FormPropertyValue_isDelete = true;
                    dal.Update(formPropertyValue);
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// 更改属性值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>        
        /// <param name="formPropertyValue">表单属性值</param>
        /// <returns></returns>
        public bool Update(Guid formCode, Guid businessFlowFormCode, Guid formPropertyCode, string formPropertyValue)
        {
            return dal.Update(formCode, businessFlowFormCode, formPropertyCode, formPropertyValue);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_FormPropertyValue_id)
        {

            return dal.Delete(C_FormPropertyValue_id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关系Guid</param>
        /// <returns></returns>
        public bool Delete(Guid formCode, Guid businessFlowFormCode)
        {
            return dal.Delete(formCode, businessFlowFormCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_FormPropertyValue_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_FormPropertyValue_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModel(int C_FormPropertyValue_id)
        {
            return dal.GetModel(C_FormPropertyValue_id);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModelByCode(Guid F_FormPropertyValue_code)
        {
            return dal.GetModelByCode(F_FormPropertyValue_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModel(Guid formCode, Guid businessFlowFormCode, Guid formPropertyCode)
        {

            return dal.GetModel(formCode, businessFlowFormCode, formPropertyCode);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModelByCache(int C_FormPropertyValue_id)
        {

            string CacheKey = "C_FormPropertyValueModel-" + C_FormPropertyValue_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_FormPropertyValue_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.CustomerForm.F_FormPropertyValue)objModel;
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
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取普通子表子属性值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <param name="type">1代表普通子表子属性值；2代表主子表中普通子表子属性值</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetChildrenPropertyValueList(Guid fFormCode, Guid relCode, int type)
        {
            DataSet ds = dal.GetChildrenPropertyValueList(fFormCode, relCode, type);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CustomerForm.F_FormPropertyValue> modelList = new List<CommonService.Model.CustomerForm.F_FormPropertyValue>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CustomerForm.F_FormPropertyValue model;
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
        /// 获得数据列表
        /// </summary>
        /// <param name="F_FormPropertyValue_group"></param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormPropertyValue> GetListByFormPropertyValueGroup(Guid F_FormPropertyValue_group)
        {
            return DataTableToList(dal.GetListByFormPropertyValueGroup(F_FormPropertyValue_group).Tables[0]);
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModelByFormPropertyValueGroupAndFormProperty(Guid F_FormPropertyValue_group, Guid F_FormPropertyValue_formProperty)
        {
            return dal.GetModelByFormPropertyValueGroupAndFormProperty(F_FormPropertyValue_group, F_FormPropertyValue_formProperty);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="F_FormPropertyValues"></param>
        /// <returns></returns>
        public bool OperateUpdate(List<CommonService.Model.CustomerForm.F_FormPropertyValue> F_FormPropertyValues)
        {
            foreach (CommonService.Model.CustomerForm.F_FormPropertyValue F_FormPropertyValue in F_FormPropertyValues)
            {
                dal.Update(F_FormPropertyValue);
            }
            return true;
        }

        /// <summary>
        /// 根据表单属性获取最大值
        /// </summary>
        /// <param name="FormCode">表单Guid</param>
        /// <param name="FormPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetMaxModelByFormAndFormProperty(Guid FormCode, Guid FormPropertyCode)
        {
            return dal.GetMaxModelByFormAndFormProperty(FormCode, FormPropertyCode);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        #region App专用

        /// <summary>
        /// 处理关联其它数据源的表单属性名称显示
        /// </summary>
        /// <param name="F_FormPropertys"></param>
        public void HandleShowName(CommonService.Model.CustomerForm.F_FormProperty formProperty)
        {

            #region 处理表单属性关联数据源后，取显示名称的逻辑
            DAL.C_Parameters parameterDAL = new DAL.C_Parameters();
            DAL.CustomerForm.F_FormProperty propertyDAL = new DAL.CustomerForm.F_FormProperty();
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
                                formProperty.V_FormPropertyValue_Value_Name = propertyDAL.GetSingleEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                            }
                            break;
                        case 138://单选弹出树
                            if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                            {
                                formProperty.V_FormPropertyValue_Value_Name = propertyDAL.GetSingleEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                            }
                            break;
                        case 137://多选弹出框
                            if (!String.IsNullOrEmpty(formProperty.V_FormPropertyValue_Value))
                            {
                                formProperty.V_FormPropertyValue_Value_Name = propertyDAL.GetMulityEntityShowName(formProperty.F_FormProperty_dataSource, formProperty.F_FormProperty_dataSource_mappingFieldName, formProperty.F_FormProperty_dataSource_mappingField, formProperty.V_FormPropertyValue_Value);
                            }
                            break;
                        default://其它UI类型，用到的时候再扩展
                            break;
                    }
                }
                else if (formProperty.F_FormProperty_dataSource_type.Value == 186)
                {//数据源类型：自定义表单
                    if (formProperty.V_FormPropertyValue_Value != "")
                    {
                        Model.CustomerForm.F_FormPropertyValue fv = GetModelByCode(new Guid(formProperty.V_FormPropertyValue_Value));
                        formProperty.V_FormPropertyValue_Value_Name = fv.F_FormPropertyValue_value;
                    }
                }
            }


            #endregion
        }

        /// <summary>
        /// 获取表单中子列表的数据（手机专用）
        /// </summary>
        /// <param name="FormCode">表单GUID</param>
        /// <param name="FormPropertyValueCode">业务流程表单中间表GUID</param>
        /// <returns>数据列表</returns>
        public List<List<Model.CustomerForm.F_FormProperty>> GetAppDetailsList(Guid? FormCode, Guid? FormPropertyValueCode, Guid? FormPropertyCode)
        {
            List<List<Model.CustomerForm.F_FormProperty>> resultList = new List<List<Model.CustomerForm.F_FormProperty>>();

            DataSet ds = DynamicLoadCustmerFormListValues(FormCode.Value, FormPropertyValueCode.Value); //获取到表单中所有列表数据

            DataTable dt = new DataTable();
            foreach (DataTable item in ds.Tables)
            {
                Model.CustomerForm.F_FormProperty property = formPropertyBLL.GetModel(new Guid(item.Columns[0].ColumnName)); //获取到每个table中父级属性GUID
                if (property.F_FormProperty_parent == FormPropertyCode)
                {
                    dt = item;
                    break;
                }
            }


            foreach (DataRow item in dt.Rows) //循环行
            {
                List<Model.CustomerForm.F_FormProperty> lst = new List<Model.CustomerForm.F_FormProperty>();
                foreach (DataColumn var in dt.Columns) //循环列
                {
                    //Model.CustomModel.KeyValueModel keyValue = new Model.CustomModel.KeyValueModel();
                    Model.CustomerForm.F_FormProperty fp = formPropertyBLL.GetModel(new Guid(var.ColumnName)); //拿到属性
                    fp.V_FormPropertyValue_Value = item[var].ToString().Substring(item[var].ToString().IndexOf(']') + 1, item[var].ToString().Length - item[var].ToString().IndexOf(']') - 1);
                    fp.V_FormPropertyValue_Value_Name = fp.V_FormPropertyValue_Value;
                    fp.V_FormPropertyValue_Id = Convert.ToInt32(item[var].ToString().Substring(item[var].ToString().IndexOf('[') + 1, item[var].ToString().IndexOf(']') - 1));
                    HandleShowName(fp);

                    //keyValue.Id = item[var].ToString().Substring(item[var].ToString().IndexOf('[') + 1, item[var].ToString().IndexOf(']') - 1);
                    //keyValue.Key = fp.F_FormProperty_showName;
                    //keyValue.Value = fp.V_FormPropertyValue_Value_Name;
                    //lst.Add(keyValue);
                    lst.Add(fp);
                }
                resultList.Add(lst);
            }

            return resultList;
        }

        /// <summary>
        /// 获取自定义数据列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public List<Model.CustomModel.KeyValueModel> GetParameters(string tableName, string searchName, string startIndex, string endIndex)
        {
            List<Model.CustomModel.KeyValueModel> lstResult = new List<Model.CustomModel.KeyValueModel>();
            C_Entity entryBLL = new C_Entity();
            Model.C_Entity model = null;
            if (tableName == "c_userinfo_main_lawyer")
            {
                model = entryBLL.GetModelByName("c_userinfo");
            }
            else 
            {
               model = entryBLL.GetModelByName(tableName);
            }

            DataSet ds = entryBLL.GetCustomTable(model.C_Entity_business_relFieldName, model.C_Entity_business_showFieldName, tableName, searchName, startIndex, endIndex);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Model.CustomModel.KeyValueModel kv = new Model.CustomModel.KeyValueModel();
                kv.Key = item[0].ToString();
                kv.Value = item[1].ToString();
                lstResult.Add(kv);
            }
            return lstResult;
        }

        /// <summary>
        /// 通过表单获取关联数据（App专用）
        /// </summary>
        /// <param name="formCode">表单GUID</param>
        /// <param name="formPropertyCode">表单属性GUID</param>
        /// <param name="businessFlowFormCode">业务流程表单关联GUID</param>
        /// <returns></returns>
        public List<Model.CustomModel.KeyValueModel> GetParametersByForm(string formCode, string formPropertyCode, string businessFlowFormCode)
        {
            List<Model.CustomerForm.F_FormPropertyValue> lst = GetCustFormPropertyValues(new Guid(formCode), new Guid(formPropertyCode), new Guid(businessFlowFormCode));
            List<Model.CustomModel.KeyValueModel> lstResult = new List<Model.CustomModel.KeyValueModel>();
            foreach (var item in lst)
            {
                Model.CustomModel.KeyValueModel kv = new Model.CustomModel.KeyValueModel();
                kv.Key = item.F_FormPropertyValue_code.ToString();
                kv.Value = item.F_FormPropertyValue_value;
                lstResult.Add(kv);
            }
            return lstResult;
        }

        /// <summary>
        /// 更新表单值
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单GUID</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public bool UpdateFormValue(Guid guid, string value)
        {
            return dal.UpdateFormValue(guid, value) > 0 ? true : false;
        }

        /// <summary>
        /// 更新表单值
        /// </summary>
        /// <param name="id">表单值ID</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public bool UpdateFormValue(int id, string value)
        {
            return dal.UpdateFormValue(id, value) > 0 ? true : false;
        }

        /// <summary>
        /// 根据groupCode删除表单子列表数据
        /// </summary>
        /// <param name="groupCode">分组GUID</param>
        /// <returns></returns>
        public int AppDeleteDetailsByGroupCode(int id)
        {
            Model.CustomerForm.F_FormPropertyValue fpv = dal.GetModel(id);
            if (fpv == null)
            {
                return 0;
            }
            return dal.AppDeleteDetailsByGroupCode(fpv.F_FormPropertyValue_group.Value);
        }

        /// <summary>
        /// 根据业务流程表单中间表GUID获取所有值
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单中间表</param>
        /// <returns></returns>
        public List<Model.CustomerForm.F_FormPropertyValue> GetPropertyValueByBusinessFormCode(Guid businessFlowFormCode)
        {
            return DataTableToList(dal.GetPropertyValueByBusinessFormCode(businessFlowFormCode).Tables[0]);
        }


        /// <summary>
        /// 更新预期收益计算接口
        /// </summary>
        /// <param name="list"></param>
        public bool UpdateExpectedReturnPropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list, int type)
        {
            #region 先更新数据

            int count = 0;
            foreach (var item in list)
            {
                UpdateFormValue(item.F_FormPropertyValue_id, item.F_FormPropertyValue_value);
                count++;
            }

            #endregion

            #region 相关业务层声明

            CommonService.BLL.FlowManager.P_Business_flow_form pffBLL = new CommonService.BLL.FlowManager.P_Business_flow_form(); //业务流程表单中间表业务
            CommonService.BLL.FlowManager.P_Business_flow pbfBLL = new CommonService.BLL.FlowManager.P_Business_flow(); //业务流程表业务
            CommonService.BLL.CaseManager.B_Case caseBLL = new CommonService.BLL.CaseManager.B_Case(); //案件业务
            CommonService.BLL.CaseManager.B_CaseLevelchange changeBLL = new CommonService.BLL.CaseManager.B_CaseLevelchange(); //案件级别变更业务
            CommonService.BLL.CaseManager.B_CaseLevelChangeRecords changeRecordsBLL = new CommonService.BLL.CaseManager.B_CaseLevelChangeRecords(); //案件级别变更记录业务

            #endregion

            #region 获取相关列表数据及实体数据

            List<CommonService.Model.CustomerForm.F_FormPropertyValue> allList = GetPropertyValueByBusinessFormCode(list[0].F_FormPropertyValue_BusinessFlowFormCode.Value);
            CommonService.Model.FlowManager.P_Business_flow_form pff = pffBLL.Get(list[0].F_FormPropertyValue_BusinessFlowFormCode.Value);
            CommonService.Model.FlowManager.P_Business_flow pbf = pbfBLL.GetModel(pff.P_Business_flow_code.Value);
            CommonService.Model.CaseManager.B_Case bcase = caseBLL.GetModel(pbf.P_Fk_code.Value);

            #endregion

            #region 消息及其他业务处理

            DateTime now = DateTime.Now; //当前时间
            //更新完数据之后的处理
            switch (type)
            {
                case 1: //专业顾问裁定

                    //1专业顾问裁定后给表单负责人发消息
                    SendMessage(bcase.B_Case_code.Value, pff.P_Business_flow_form_person.Value, Convert.ToInt32(MessageTinyTypeEnum.审核通过), now);


                    //2专业顾问裁定后给部长发消息，让部长审核
                    SendMessage(pff.P_Business_flow_form_code.Value, bcase.B_Case_person.Value, Convert.ToInt32(MessageTinyTypeEnum.预期收益), now);

                    break;
                case 2: //专家部长裁定

                    //1专家部长裁定后给专业顾问和表单负责人发消息
                    SendMessage(bcase.B_Case_code.Value, pff.P_Business_flow_form_person.Value, Convert.ToInt32(MessageTinyTypeEnum.审核通过), now);
                    SendMessage(bcase.B_Case_code.Value, new Guid(allList.Where(p => p.F_FormPropertyValue_formProperty == new Guid("A191678E-D8E2-4CEE-B163-2679E88A3D89")).FirstOrDefault().F_FormPropertyValue_value), Convert.ToInt32(MessageTinyTypeEnum.审核通过), now);

                    //2判断金额是否大于10W，大于10W给首席发消息
                    decimal money = Convert.ToDecimal(allList.Where(p => p.F_FormPropertyValue_formProperty == new Guid("7B13CA2B-1B19-44CD-8259-D9C473A4D06C")).FirstOrDefault().F_FormPropertyValue_value);
                    if (money >= 100000)
                    {
                        SendMessage(pff.P_Business_flow_form_code.Value, bcase.B_Case_firstClassResponsiblePerson.Value, Convert.ToInt32(MessageTinyTypeEnum.预期收益), now);
                    }

                    break;
                case 3: //首席专家裁定

                    //1首席裁定后给专家部长、专业顾问、表单负责人发消息
                    SendMessage(bcase.B_Case_code.Value, pff.P_Business_flow_form_person.Value, Convert.ToInt32(MessageTinyTypeEnum.审核通过), now);
                    SendMessage(bcase.B_Case_code.Value, new Guid(allList.Where(p => p.F_FormPropertyValue_formProperty == new Guid("A191678E-D8E2-4CEE-B163-2679E88A3D89")).FirstOrDefault().F_FormPropertyValue_value), Convert.ToInt32(MessageTinyTypeEnum.审核通过), now);
                    SendMessage(bcase.B_Case_code.Value, bcase.B_Case_person.Value, Convert.ToInt32(MessageTinyTypeEnum.审核通过), now);

                    //2判断首席裁定金额是否大于20W，大于20W就给案件添加“大案”属性
                    decimal sxMoney = Convert.ToDecimal(allList.Where(p => p.F_FormPropertyValue_formProperty == new Guid("E16EC45B-E0E6-40CC-8F8D-1FCAD9D54CAB")).FirstOrDefault().F_FormPropertyValue_value);
                    if (sxMoney >= 200000)
                    {
                        bool IsMajorAdjustment = changeBLL.IsHardToAdjust(bcase.B_Case_code.Value, Convert.ToInt32(CaseLevelEnum.大案));//案件是否进行大案调整
                        if (!IsMajorAdjustment)
                        {
                            #region 变更记录表中插入数据
                            CommonService.Model.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecords = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
                            caseLevelChangeRecords.B_CaseLevelChangeRecords_code = Guid.NewGuid();
                            caseLevelChangeRecords.B_Case_code = bcase.B_Case_code;
                            caseLevelChangeRecords.B_CaseLevelChangeRecords_type = Convert.ToInt32(CaseLevelChangeRecordTypeEnum.自动);
                            caseLevelChangeRecords.B_CaseLevelChangeRecords_applicationData = DateTime.Now;
                            caseLevelChangeRecords.B_CaseLevelChangeRecords_createTime = DateTime.Now;
                            caseLevelChangeRecords.B_CaseLevelChangeRecords_isDelete = false;
                            caseLevelChangeRecords.B_CaseLevelChangeRecords_isAudit = true;

                            changeRecordsBLL.Add(caseLevelChangeRecords);
                            #endregion

                            #region 案件级别变更表插入数据
                            CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange = new CommonService.Model.CaseManager.B_CaseLevelchange();
                            caseLevelChange.B_CaseLevelchange_code = Guid.NewGuid();
                            caseLevelChange.B_Case_code = bcase.B_Case_code;
                            caseLevelChange.B_CaseLevelchange_type = Convert.ToInt32(CaseLevelEnum.大案);
                            caseLevelChange.B_CaseLevelchange_changeRecord = caseLevelChangeRecords.B_CaseLevelChangeRecords_code.Value;
                            caseLevelChange.B_CaseLevelchange_state = Convert.ToInt32(CaseLevelChangeStateEnum.通过);
                            caseLevelChange.B_CaseLevelchange_IsValid = true;
                            caseLevelChange.B_CaseLevelchange_createTime = DateTime.Now;
                            caseLevelChange.B_CaseLevelchange_isDelete = false;

                            changeBLL.Add(caseLevelChange);
                            #endregion
                        }
                    }
                    break;
            }

            #endregion

            return count > 0 ? true : false;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="caseCode"></param>
        /// <param name="person"></param>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        public void SendMessage(Guid caseCode, Guid person, int type, DateTime dt)
        {
            CommonService.BLL.C_Messages messageBLL = new CommonService.BLL.C_Messages();
            CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.财务消息);
            message.C_Messages_type = type;
            message.C_Messages_link = caseCode;
            message.C_Messages_createTime = dt;
            message.C_Messages_person = person;
            message.C_Messages_isRead = 0;
            message.C_Messages_content = "";
            message.C_Messages_isValidate = 1;
            messageBLL.Add(message);
        }
        #endregion
    }
}
