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
    /// 自定义表单表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/05/12
    /// </summary>
    public partial class F_Form
    {
        private readonly CommonService.DAL.CustomerForm.F_Form dal = new CommonService.DAL.CustomerForm.F_Form();
        private readonly CommonService.BLL.CustomerForm.F_FormProperty dalFormProperty = new CommonService.BLL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单时间声明数据访问层
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormDateDeclare formDateDeclareDAL = new CommonService.DAL.CustomerForm.F_FormDateDeclare();
        private readonly CommonService.DAL.FlowManager.P_Flow flowDal = new CommonService.DAL.FlowManager.P_Flow();
        public F_Form()
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
        public bool Exists(int C_Form_id)
        {
            return dal.Exists(C_Form_id);
        }

        /// <summary>
        /// 是否存在表单标识
        /// </summary>
        /// <param name="formIdentification">表单标识</param>
        /// <returns>存在返回true;不存在返回false</returns>
        public bool ExistsFormIdentification(string formIdentification)
        {
            return dal.ExistsFormIdentification(formIdentification);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_Form model)
        {
            /**
             **作者：贺太玉
             **2015/05/14
             **业务说明：(一)、在新增表单数据时，应该自动在表单属性表中插入表单基础属性数据
             * (二)、如果表单属性为日期类型，则插入时间记录表
             **/
            int formId = dal.Add(model);
            if (formId > 0)
            {
               List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = dalFormProperty.GetBaseModelList();
               foreach (var formProperty in formPropertys)
               {
                   formProperty.F_FormProperty_code = Guid.NewGuid();                   
                   formProperty.F_FormProperty_form = model.F_Form_code;                    
                   formProperty.F_FormProperty_creator = model.F_Form_creator;
                   formProperty.F_FormProperty_createTime = DateTime.Now;
                   formProperty.F_FormProperty_isBase = false;

                   dalFormProperty.Add(formProperty);
               }
            }
            return formId;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_Form model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_Form_code)
        {

            return dal.Delete(F_Form_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Form_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Form_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_Form GetModel(Guid F_Form_code)
        {

            return dal.GetModel(F_Form_code);
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
        public List<CommonService.Model.CustomerForm.F_Form> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_Form> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CustomerForm.F_Form> modelList = new List<CommonService.Model.CustomerForm.F_Form>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CustomerForm.F_Form model;
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
        public List<CommonService.Model.CustomerForm.F_Form> GetAllListByFlowType(int FlowType)
        {
            int F_Form_type = 0;
            if (FlowType != 0)
            {
                if (FlowType == Convert.ToInt32(FlowTypeEnum.案件))
                {
                    F_Form_type = Convert.ToInt32(FormTypeEnum.案件表单);
                }
                else if (FlowType == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    F_Form_type = Convert.ToInt32(FormTypeEnum.商机表单);
                }
                else if (FlowType == Convert.ToInt32(FlowTypeEnum.客户))
                {
                    F_Form_type = Convert.ToInt32(FormTypeEnum.客户表单);
                }
                else
                {
                    F_Form_type = Convert.ToInt32(FormTypeEnum.协同办公表单);
                }
            }
            return DataTableToList(dal.GetAllListByForm_type(F_Form_type).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_Form model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_Form> GetListByPage(CommonService.Model.CustomerForm.F_Form model, string orderby, int startIndex, int endIndex)
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
    }
}
