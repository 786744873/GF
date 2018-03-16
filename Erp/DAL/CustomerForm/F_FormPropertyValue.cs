using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.CustomerForm
{
    /// <summary>
    /// 数据访问类:自定义表单属性值表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class F_FormPropertyValue
    {
        public F_FormPropertyValue()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_FormPropertyValue_id", "F_FormPropertyValue");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_FormPropertyValue_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_FormPropertyValue");
            strSql.Append(" where F_FormPropertyValue_id=@F_FormPropertyValue_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_id", SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormPropertyValue_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into F_FormPropertyValue(");
            strSql.Append("F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime,F_FormPropertyValue_group)");
            strSql.Append(" values (");
            strSql.Append("@F_FormPropertyValue_code,@F_FormPropertyValue_form,@F_FormPropertyValue_formProperty,@F_FormPropertyValue_BusinessFlowFormCode,@F_FormPropertyValue_value,@F_FormPropertyValue_isDelete,@F_FormPropertyValue_creator,@F_FormPropertyValue_createTime,@F_FormPropertyValue_group)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_formProperty", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_value", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormPropertyValue_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_FormPropertyValue_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_createTime", SqlDbType.DateTime),
                    new SqlParameter("@F_FormPropertyValue_group", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.F_FormPropertyValue_code;
            parameters[1].Value = model.F_FormPropertyValue_form;
            parameters[2].Value = model.F_FormPropertyValue_formProperty;
            parameters[3].Value = model.F_FormPropertyValue_BusinessFlowFormCode;
            parameters[4].Value = model.F_FormPropertyValue_value;
            parameters[5].Value = model.F_FormPropertyValue_isDelete;
            parameters[6].Value = model.F_FormPropertyValue_creator;
            parameters[7].Value = model.F_FormPropertyValue_createTime;
            parameters[8].Value = model.F_FormPropertyValue_group;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormPropertyValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormPropertyValue set ");
            strSql.Append("F_FormPropertyValue_code=@F_FormPropertyValue_code,");
            strSql.Append("F_FormPropertyValue_form=@F_FormPropertyValue_form,");
            strSql.Append("F_FormPropertyValue_formProperty=@F_FormPropertyValue_formProperty,");
            strSql.Append("F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode,");
            strSql.Append("F_FormPropertyValue_value=@F_FormPropertyValue_value,");
            strSql.Append("F_FormPropertyValue_isDelete=@F_FormPropertyValue_isDelete,");
            strSql.Append("F_FormPropertyValue_creator=@F_FormPropertyValue_creator,");
            strSql.Append("F_FormPropertyValue_createTime=@F_FormPropertyValue_createTime");
            strSql.Append(" where F_FormPropertyValue_id=@F_FormPropertyValue_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_formProperty", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_value", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormPropertyValue_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_FormPropertyValue_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormPropertyValue_createTime", SqlDbType.DateTime),
					new SqlParameter("@F_FormPropertyValue_id", SqlDbType.Int)};
            parameters[0].Value = model.F_FormPropertyValue_code;
            parameters[1].Value = model.F_FormPropertyValue_form;
            parameters[2].Value = model.F_FormPropertyValue_formProperty;
            parameters[3].Value = model.F_FormPropertyValue_BusinessFlowFormCode;
            parameters[4].Value = model.F_FormPropertyValue_value;
            parameters[5].Value = model.F_FormPropertyValue_isDelete;
            parameters[6].Value = model.F_FormPropertyValue_creator;
            parameters[7].Value = model.F_FormPropertyValue_createTime;
            parameters[8].Value = model.F_FormPropertyValue_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据表单属性值Guid，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues">表单属性值(虚拟实体)</param>
        /// <returns></returns>
        public bool UpdateFormPropertyValueByPropertyCode(CommonService.Model.Customer.V_FormPropertyValue V_FormPropertyValues)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormPropertyValue set ");
            strSql.Append("F_FormPropertyValue_value=@F_FormPropertyValue_value ");
            strSql.Append("where F_FormPropertyValue_code=@F_FormPropertyValue_code ");

            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_value", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormPropertyValue_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = V_FormPropertyValues.FormPropertyValue_Value;
            parameters[1].Value = V_FormPropertyValues.FormPropertyValue_Code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  根据表单属性值Id，更改表单属性值
        /// </summary>
        /// <param name="V_FormPropertyValues"></param>
        /// <returns></returns>
        public bool UpdateFormPropertyValueByPropertyId(CommonService.Model.Customer.V_FormPropertyValue V_FormPropertyValues)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormPropertyValue set ");
            strSql.Append("F_FormPropertyValue_value=@F_FormPropertyValue_value ");
            strSql.Append("where F_FormPropertyValue_id=@F_FormPropertyValue_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_value", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormPropertyValue_id", SqlDbType.Int)
			};
            parameters[0].Value = V_FormPropertyValues.FormPropertyValue_Value;
            parameters[1].Value = V_FormPropertyValues.FormPropertyValue_Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormPropertyValue set ");
            strSql.Append("F_FormPropertyValue_value=@F_FormPropertyValue_value ");
            strSql.Append("where F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and F_FormPropertyValue_form=@F_FormPropertyValue_form ");
            strSql.Append("and F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode ");
            strSql.Append("and F_FormPropertyValue_formProperty=@F_FormPropertyValue_formProperty ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_value", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormPropertyValue_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormPropertyValue_formProperty", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = formPropertyValue;
            parameters[1].Value = formCode;
            parameters[2].Value = businessFlowFormCode;
            parameters[3].Value = formPropertyCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 动态加载自定义表单普通子表属性值集合(DataSet中允许包含多个table)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <returns></returns>
        public DataSet DynamicLoadCustmerFormListValues(Guid fFormCode, Guid relCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@relCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = fFormCode;
            parameters[1].Value = relCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_DynamicLoadCustmerFormListValues", parameters, "dynamicDataSet");
            return ds;
        }

        /// <summary>
        /// 动态加载自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int DynamicLoadFeeFormListCount(Guid fFormCode, string condition)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@startIndex", SqlDbType.Int,10),
                    new SqlParameter("@endIndex", SqlDbType.Int,10),
                    new SqlParameter("@condition", SqlDbType.NVarChar,2000),
                    new SqlParameter("@type", SqlDbType.Int,4)
				 };
            parameters[0].Value = fFormCode;
            parameters[1].Value = 0;
            parameters[2].Value = 0;
            parameters[3].Value = condition;
            parameters[4].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("proc_DynamicLoadFinanceFormListValues", parameters, "dynamicDataSet");

            if (ds != null)
            {
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// 动态加载oa自定义表单普通子表属性值总记录数(专指财务报销单和财务借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int DynamicLoadOAFeeFormListCount(Guid fFormCode, string condition)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@startIndex", SqlDbType.Int,10),
                    new SqlParameter("@endIndex", SqlDbType.Int,10),
                    new SqlParameter("@condition", SqlDbType.NVarChar,2000),
                    new SqlParameter("@type", SqlDbType.Int,4)
				 };
            parameters[0].Value = fFormCode;
            parameters[1].Value = 0;
            parameters[2].Value = 0;
            parameters[3].Value = condition;
            parameters[4].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("proc_DynamicLoadOAFinanceFormListValues", parameters, "dynamicDataSet");

            if (ds != null)
            {
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            return 0;
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
            SqlParameter[] parameters = {
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@startIndex", SqlDbType.Int,10),
                    new SqlParameter("@endIndex", SqlDbType.Int,10),
                    new SqlParameter("@condition", SqlDbType.NVarChar,2000),
                    new SqlParameter("@type", SqlDbType.Int,4)
				 };
            parameters[0].Value = fFormCode;
            parameters[1].Value = startIndex;
            parameters[2].Value = endIndex;
            parameters[3].Value = condition;
            parameters[4].Value = 2;

            DataSet ds = DbHelperSQL.RunProcedure("proc_DynamicLoadFinanceFormListValues", parameters, "dynamicDataSet");

            return ds;
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
            SqlParameter[] parameters = {
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@startIndex", SqlDbType.Int,10),
                    new SqlParameter("@endIndex", SqlDbType.Int,10),
                    new SqlParameter("@condition", SqlDbType.NVarChar,2000),
                    new SqlParameter("@type", SqlDbType.Int,4)
				 };
            parameters[0].Value = fFormCode;
            parameters[1].Value = startIndex;
            parameters[2].Value = endIndex;
            parameters[3].Value = condition;
            parameters[4].Value = 2;

            DataSet ds = DbHelperSQL.RunProcedure("proc_DynamicLoadOAFinanceFormListValues", parameters, "dynamicDataSet");

            return ds;
        }

        /// <summary>
        /// 通过业务条件，获取关联自定义表单属性值列表(只针对自定义表单的某一属性关联了另外一个自定义表单的某一属性)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public DataSet GetCustFormPropertyValues(Guid formCode, Guid formPropertyCode, Guid businessFlowFormCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@formCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@formPropertyCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@businessFlowFormCode", SqlDbType.UniqueIdentifier,16)
				 };
            parameters[0].Value = formCode;
            parameters[1].Value = formPropertyCode;
            parameters[2].Value = businessFlowFormCode;

            DataSet ds = DbHelperSQL.RunProcedure("proc_GetCustFormPropertyValues", parameters, "custFormPropertyValues");
            return ds;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int F_FormPropertyValue_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from F_FormPropertyValue ");
            strSql.Append(" where F_FormPropertyValue_id=@F_FormPropertyValue_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_id", SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormPropertyValue_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool Delete(Guid formCode, Guid businessFlowFormCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormPropertyValue set ");
            strSql.Append("F_FormPropertyValue_isDelete=1 ");
            strSql.Append("where F_FormPropertyValue_form=@F_FormPropertyValue_form ");
            strSql.Append("and F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = formCode;
            parameters[1].Value = businessFlowFormCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string F_FormPropertyValue_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from F_FormPropertyValue ");
            strSql.Append(" where F_FormPropertyValue_id in (" + F_FormPropertyValue_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModel(int F_FormPropertyValue_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime,F_FormPropertyValue_group from F_FormPropertyValue ");
            strSql.Append(" where F_FormPropertyValue_id=@F_FormPropertyValue_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_id", SqlDbType.Int)
			};
            parameters[0].Value = F_FormPropertyValue_id;

            CommonService.Model.CustomerForm.F_FormPropertyValue model = new CommonService.Model.CustomerForm.F_FormPropertyValue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModelByCode(Guid F_FormPropertyValue_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime from F_FormPropertyValue ");
            strSql.Append(" where F_FormPropertyValue_code=@F_FormPropertyValue_code");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormPropertyValue_code;

            CommonService.Model.CustomerForm.F_FormPropertyValue model = new CommonService.Model.CustomerForm.F_FormPropertyValue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据表单属性获取最大值
        /// </summary>
        /// <param name="FormCode">表单Guid</param>
        /// <param name="FormPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetMaxModelByFormAndFormProperty(Guid FormCode, Guid FormPropertyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 FPV.* from F_FormPropertyValue As FPV with(nolock) ");
            strSql.Append(" left join F_FormProperty As FP with(nolock) on FPV.F_FormPropertyValue_formProperty=FP.F_FormProperty_code ");
            strSql.Append(" left join F_Form As F with(nolock) on FP.F_FormProperty_form=F.F_Form_code ");
            strSql.Append(" where F.F_Form_code=@F_Form_code and FP.F_FormProperty_code=@F_FormProperty_code ");
            strSql.Append(" and F.F_Form_isDelete=0 ");
            strSql.Append(" and FP.F_FormProperty_isDelete=0 ");
            strSql.Append(" and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append(" order by FPV.F_FormPropertyValue_id desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = FormCode;
            parameters[1].Value = FormPropertyCode;

            CommonService.Model.CustomerForm.F_FormPropertyValue model = new CommonService.Model.CustomerForm.F_FormPropertyValue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModelByFormPropertyValueGroupAndFormProperty(Guid F_FormPropertyValue_group, Guid F_FormPropertyValue_formProperty)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime,F_FormPropertyValue_group from F_FormPropertyValue ");
            strSql.Append(" where F_FormPropertyValue_group=@F_FormPropertyValue_group");
            strSql.Append(" and F_FormPropertyValue_formProperty=@F_FormPropertyValue_formProperty ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_group", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormPropertyValue_formProperty",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormPropertyValue_group;
            parameters[1].Value = F_FormPropertyValue_formProperty;

            CommonService.Model.CustomerForm.F_FormPropertyValue model = new CommonService.Model.CustomerForm.F_FormPropertyValue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue GetModel(Guid formCode, Guid businessFlowFormCode, Guid formPropertyCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime from F_FormPropertyValue ");
            strSql.Append(" where 1=1 and F_FormPropertyValue_isDelete=0 ");
            if (formCode != null)
            {
                strSql.Append("and F_FormPropertyValue_form=@F_FormPropertyValue_form ");
            }
            if (businessFlowFormCode != null)
            {
                strSql.Append("and F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode ");
            }
            if (formPropertyCode != null)
            {
                strSql.Append("and F_FormPropertyValue_formProperty=@F_FormPropertyValue_formProperty ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormPropertyValue_formProperty",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = formCode;
            parameters[1].Value = businessFlowFormCode;
            parameters[2].Value = formPropertyCode;

            CommonService.Model.CustomerForm.F_FormPropertyValue model = new CommonService.Model.CustomerForm.F_FormPropertyValue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormPropertyValue DataRowToModel(DataRow row)
        {
            CommonService.Model.CustomerForm.F_FormPropertyValue model = new CommonService.Model.CustomerForm.F_FormPropertyValue();
            if (row != null)
            {
                if (row["F_FormPropertyValue_id"] != null && row["F_FormPropertyValue_id"].ToString() != "")
                {
                    model.F_FormPropertyValue_id = int.Parse(row["F_FormPropertyValue_id"].ToString());
                }
                if (row["F_FormPropertyValue_code"] != null && row["F_FormPropertyValue_code"].ToString() != "")
                {
                    model.F_FormPropertyValue_code = new Guid(row["F_FormPropertyValue_code"].ToString());
                }
                if (row["F_FormPropertyValue_form"] != null && row["F_FormPropertyValue_form"].ToString() != "")
                {
                    model.F_FormPropertyValue_form = new Guid(row["F_FormPropertyValue_form"].ToString());
                }
                if (row["F_FormPropertyValue_formProperty"] != null && row["F_FormPropertyValue_formProperty"].ToString() != "")
                {
                    model.F_FormPropertyValue_formProperty = new Guid(row["F_FormPropertyValue_formProperty"].ToString());
                }
                //表单属性标识id，外键(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("F_FormPropertyValue_formProperty_id"))
                {
                    if (row["F_FormPropertyValue_formProperty_id"] != null && row["F_FormPropertyValue_formProperty_id"].ToString() != "")
                    {
                        model.F_FormPropertyValue_formProperty_id = int.Parse(row["F_FormPropertyValue_formProperty_id"].ToString());
                    }
                }
                if (row["F_FormPropertyValue_BusinessFlowFormCode"] != null && row["F_FormPropertyValue_BusinessFlowFormCode"].ToString() != "")
                {
                    model.F_FormPropertyValue_BusinessFlowFormCode = new Guid(row["F_FormPropertyValue_BusinessFlowFormCode"].ToString());
                }
                if (row["F_FormPropertyValue_value"] != null)
                {
                    model.F_FormPropertyValue_value = row["F_FormPropertyValue_value"].ToString();
                }
                if (row["F_FormPropertyValue_isDelete"] != null && row["F_FormPropertyValue_isDelete"].ToString() != "")
                {
                    if ((row["F_FormPropertyValue_isDelete"].ToString() == "1") || (row["F_FormPropertyValue_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.F_FormPropertyValue_isDelete = true;
                    }
                    else
                    {
                        model.F_FormPropertyValue_isDelete = false;
                    }
                }
                if (row["F_FormPropertyValue_creator"] != null && row["F_FormPropertyValue_creator"].ToString() != "")
                {
                    model.F_FormPropertyValue_creator = new Guid(row["F_FormPropertyValue_creator"].ToString());
                }
                if (row["F_FormPropertyValue_createTime"] != null && row["F_FormPropertyValue_createTime"].ToString() != "")
                {
                    model.F_FormPropertyValue_createTime = DateTime.Parse(row["F_FormPropertyValue_createTime"].ToString());
                }
                //if(row["F_FormPropertyValue_group"]!=null && row["F_FormPropertyValue_group"].ToString()!="")
                //{
                //    model.F_FormPropertyValue_group = new Guid(row["F_FormPropertyValue_group"].ToString());
                //}

                //
                if (row.Table.Columns.Contains("F_FormPropertyValue_group"))
                {
                    if (row["F_FormPropertyValue_group"] != null && row["F_FormPropertyValue_group"].ToString() != "")
                    {
                        model.F_FormPropertyValue_group = new Guid(row["F_FormPropertyValue_group"].ToString());
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime ");
            strSql.Append(" FROM F_FormPropertyValue ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取普通子表子属性值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="relCode">关联Guid(业务流程表单关联Guid或者协同办公表单Guid)</param>
        /// <param name="type">1代表普通子表子属性值；2代表主子表中普通子表子属性值</param>
        /// <returns></returns>
        public DataSet GetChildrenPropertyValueList(Guid fFormCode, Guid relCode, int type)
        {
            StringBuilder strSql = new StringBuilder();

            if (type == 1)
            {
                strSql.Append("select FPV.* ");
                strSql.Append("FROM F_FormPropertyValue As FPV with(nolock) ");
                strSql.Append("left join F_FormProperty As FP with(nolock) on FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
                strSql.Append("where FPV.F_FormPropertyValue_isDelete=0 ");
                strSql.Append("and FPV.F_FormPropertyValue_form=@fFormCode ");
                strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@relCode ");
                strSql.Append("and FP.F_FormProperty_isDelete=0 ");
                strSql.Append("and FP.F_FormProperty_parent<>'00000000-0000-0000-0000-000000000000' ");
            }
            if (type == 2)
            {
                strSql.Append("select FPV.* ");
                strSql.Append("FROM F_FormPropertyValue As FPV with(nolock) ");
                strSql.Append("left join F_FormProperty As FP with(nolock) on FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
                strSql.Append("where FPV.F_FormPropertyValue_isDelete=0 ");
                strSql.Append("and FPV.F_FormPropertyValue_form=@fFormCode ");
                strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@relCode ");
                strSql.Append("and FP.F_FormProperty_isDelete=0 ");
                strSql.Append("and exists(select 1 from F_FormProperty As S with(nolock) where S.F_FormProperty_form=@fFormCode and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType = 207 and S.F_FormProperty_code = FP.F_FormProperty_parent) ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@fFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@relCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = fFormCode;
            parameters[1].Value = relCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime ");
            strSql.Append(" FROM F_FormPropertyValue ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="F_FormPropertyValue_group"></param>
        /// <returns></returns>
        public DataSet GetListByFormPropertyValueGroup(Guid F_FormPropertyValue_group)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormPropertyValue_id,F_FormPropertyValue_code,F_FormPropertyValue_form,F_FormPropertyValue_formProperty,F_FormPropertyValue_BusinessFlowFormCode,F_FormPropertyValue_value,F_FormPropertyValue_isDelete,F_FormPropertyValue_creator,F_FormPropertyValue_createTime,F_FormPropertyValue_group ");
            strSql.Append(" FROM F_FormPropertyValue ");
            strSql.Append("where F_FormPropertyValue_group=@F_FormPropertyValue_group ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormPropertyValue_group", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormPropertyValue_group;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM F_FormPropertyValue ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.F_FormPropertyValue_id desc");
            }
            strSql.Append(")AS Row, T.*  from F_FormPropertyValue T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "F_FormPropertyValue";
            parameters[1].Value = "F_FormPropertyValue_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        #region App专用
        /// <summary>
        /// 根据业务流程表单中间表获取属性及值（不包含子表）
        /// </summary>
        /// <param name="guid">业务流程表单中间表</param>
        /// <returns>数据集</returns>
        public DataSet GetValuesByBusinessFormCode(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from F_FormPropertyValue fv ");
            strSql.Append("left join F_FormProperty fp on fp.F_FormProperty_code=fv.F_FormPropertyValue_formProperty ");
            strSql.Append("where fp.F_FormProperty_isShow=1 and fp.F_FormProperty_isBase=0 and fp.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and fv.F_FormPropertyValue_BusinessFlowFormCode=@guid ");
            strSql.Append("and not Exists(select 1 from F_FormProperty As S With(Nolock) where S.F_FormProperty_form=fv.F_FormPropertyValue_form and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType=527 and S.F_FormProperty_code = FP.F_FormProperty_parent) ");
            strSql.Append("union all ");
            strSql.Append("select * from F_FormPropertyValue fv ");
            strSql.Append("left join F_FormProperty fp on fp.F_FormProperty_code=fv.F_FormPropertyValue_formProperty ");
            strSql.Append("where fp.F_FormProperty_isDelete=0 and fp.F_FormProperty_form=fv.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=fv.F_FormPropertyValue_formProperty  ");
            strSql.Append("and fv.F_FormPropertyValue_BusinessFlowFormCode=@guid ");
            strSql.Append("and fv.F_FormPropertyValue_isDelete=0  ");
            strSql.Append("and Exists(select 1 from F_FormProperty As S With(Nolock) where S.F_FormProperty_form=fv.F_FormPropertyValue_form and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType=527 and S.F_FormProperty_code = FP.F_FormProperty_parent) ");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;
            return DbHelperSQL.Query(strSql.ToString(),para);
        }

        /// <summary>
        /// 更新表单值
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单GUID</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public int UpdateFormValue(Guid guid,string value)
        {
            string sql = "update F_FormPropertyValue set F_FormPropertyValue_value=@value where F_FormPropertyValue_code=@guid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@value",SqlDbType.VarChar),
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = value;
            para[1].Value = guid;

            object obj = DbHelperSQL.GetSingle(sql, para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新表单值
        /// </summary>
        /// <param name="id">表单值ID</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public int UpdateFormValue(int id, string value)
        {
            string sql = "update F_FormPropertyValue set F_FormPropertyValue_value=@value where F_FormPropertyValue_id=@id";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@value",SqlDbType.VarChar),
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = value;
            para[1].Value = id;

            object obj = DbHelperSQL.GetSingle(sql, para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 根据groupCode删除表单子列表数据
        /// </summary>
        /// <param name="groupCode">分组GUID</param>
        /// <returns></returns>
        public int AppDeleteDetailsByGroupCode(Guid guid)
        {
            string sql = "update F_FormPropertyValue set F_FormPropertyValue_isDelete=1 where F_FormPropertyValue_group=@guid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;

            object obj = DbHelperSQL.GetSingle(sql, para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 根据业务流程表单中间表GUID获取所有值
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单中间表</param>
        /// <returns></returns>
        public DataSet GetPropertyValueByBusinessFormCode(Guid businessFlowFormCode)
        {
            string sql = "select * from F_FormPropertyValue where F_FormPropertyValue_BusinessFlowFormCode=@businessFlowFormCode and F_FormPropertyValue_isDelete=0";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@businessFlowFormCode",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = businessFlowFormCode;

            return DbHelperSQL.Query(sql,para);
        }
        #endregion
    }
}
