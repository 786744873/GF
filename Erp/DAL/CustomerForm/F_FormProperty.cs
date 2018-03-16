using CommonService.Common;
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
    /// 数据访问类:自定义表单属性表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class F_FormProperty
    {
        public F_FormProperty()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_FormProperty_id", "F_FormProperty");
        }

        /// <summary>
        /// 得到最大的显示顺序
        /// </summary>
        /// <param name="formId">表单Id</param>
        /// <returns></returns>
        public int GetMaxOrderBy(Guid formId)
        {
            /**
             **作者：贺太玉
             **2015/05/14
             **业务说明：默认创建的基础属性，显示顺序均大于 1000
            **/
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(F_FormProperty_orderBy) +1 FROM F_FormProperty With(nolock) ");
            strSql.Append(" where 1=1 ");
            strSql.Append("and F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("and F_FormProperty_orderBy<1000 ");

            SqlParameter[] parameters = {				 
                    new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = formId;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_FormProperty_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_FormProperty");
            strSql.Append(" where F_FormProperty_id=@F_FormProperty_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_id", SqlDbType.Int,4)
			};
            parameters[0].Value = F_FormProperty_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查字段名称是否存在
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public bool ExistsFieldName(string fieldName, Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_FormProperty WITH(NOLOCK) ");
            strSql.Append("where F_FormProperty_fieldName=@F_FormProperty_fieldName and F_FormProperty_form = @F_FormProperty_form ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_fieldName", SqlDbType.NVarChar,50),
			        new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = fieldName;
            parameters[1].Value = formCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_FormProperty WITH(NOLOCK) ");
            strSql.Append("where F_FormProperty_fieldName=@F_FormProperty_fieldName and F_FormProperty_form = @F_FormProperty_form ");
            strSql.Append("and F_FormProperty_code !=@F_FormProperty_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_fieldName", SqlDbType.NVarChar,50),
			        new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_code", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = fieldName;
            parameters[1].Value = formCode;
            parameters[2].Value = formPropertyCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据表单Guid，获取表单自定义类型(如普通编辑表单，单头明细行表单，明细行表单)(返回1代表普通编辑表单;2代表主子表单;3代表明细子表;4代表tab容器)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回代表普通编辑表单;2代表主子表单;3代表明细子表;4代表tab容器</returns>
        public int GetFormCustomerType(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append("case ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form = F.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=527) then 2 ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form =F.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=207) then 3 ");
            strSql.Append("when exists(select 1 from F_FormProperty As FP WITH(NOLOCK) where FP.F_FormProperty_form =F.F_Form_code and FP.F_FormProperty_isDelete=0 and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and FP.F_FormProperty_uiType=208) then 4 ");
            strSql.Append("else 1 ");
            strSql.Append("end ");
            strSql.Append("from F_Form AS F WITH(NOLOCK) ");
            strSql.Append("where F.F_Form_code = @F_Form_code ");

            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = formCode;

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
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into F_FormProperty(");
            strSql.Append("F_FormProperty_code,F_FormProperty_parent,F_FormProperty_form,F_FormProperty_showName,F_FormProperty_fieldName,F_FormProperty_fieldLength,F_FormProperty_uiType,F_FormProperty_isOnlyRead,F_FormProperty_isShow,F_FormProperty_isRequire,F_FormProperty_validationMessage,F_FormProperty_targetUrl,F_FormProperty_orderBy,F_FormProperty_isBase,F_FormProperty_dataSource_type,F_FormProperty_dataSource,F_FormProperty_dataSource_mappingField,F_FormProperty_dataSource_mappingFieldName,F_FormProperty_dataSource_conditionField,F_FormProperty_dataSource_conditionValue,F_FormProperty_dataSource_conditionType,F_FormProperty_remark,F_FormProperty_isDelete,F_FormProperty_isSum,F_FormProperty_triggerEvent_Type,F_FormProperty_triggerEvent_dynamicJs,F_FormProperty_defaultValue,F_FormProperty_isShowInHistory,F_FormProperty_creator,F_FormProperty_createTime)");
            strSql.Append(" values (");
            strSql.Append("@F_FormProperty_code,@F_FormProperty_parent,@F_FormProperty_form,@F_FormProperty_showName,@F_FormProperty_fieldName,@F_FormProperty_fieldLength,@F_FormProperty_uiType,@F_FormProperty_isOnlyRead,@F_FormProperty_isShow,@F_FormProperty_isRequire,@F_FormProperty_validationMessage,@F_FormProperty_targetUrl,@F_FormProperty_orderBy,@F_FormProperty_isBase,@F_FormProperty_dataSource_type,@F_FormProperty_dataSource,@F_FormProperty_dataSource_mappingField,@F_FormProperty_dataSource_mappingFieldName,@F_FormProperty_dataSource_conditionField,@F_FormProperty_dataSource_conditionValue,@F_FormProperty_dataSource_conditionType,@F_FormProperty_remark,@F_FormProperty_isDelete,@F_FormProperty_isSum,@F_FormProperty_triggerEvent_Type,@F_FormProperty_triggerEvent_dynamicJs,@F_FormProperty_defaultValue,@F_FormProperty_isShowInHistory,@F_FormProperty_creator,@F_FormProperty_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_showName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_fieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_fieldLength", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_uiType", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_isOnlyRead", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_isShow", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_isRequire", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_validationMessage", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormProperty_targetUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@F_FormProperty_orderBy", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_isBase", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_dataSource_type", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_dataSource", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_mappingField", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormProperty_dataSource_mappingFieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_conditionField", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_conditionValue", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_conditionType", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormProperty_isSum", SqlDbType.Bit,1),
                    new SqlParameter("@F_FormProperty_triggerEvent_Type", SqlDbType.Int,4),
                    new SqlParameter("@F_FormProperty_triggerEvent_dynamicJs", SqlDbType.NVarChar,3000),
                    new SqlParameter("@F_FormProperty_defaultValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormProperty_isShowInHistory", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.F_FormProperty_code;
            parameters[1].Value = model.F_FormProperty_parent;
            parameters[2].Value = model.F_FormProperty_form;
            parameters[3].Value = model.F_FormProperty_showName;
            parameters[4].Value = model.F_FormProperty_fieldName;
            parameters[5].Value = model.F_FormProperty_fieldLength;
            parameters[6].Value = model.F_FormProperty_uiType;
            parameters[7].Value = model.F_FormProperty_isOnlyRead;
            parameters[8].Value = model.F_FormProperty_isShow;
            parameters[9].Value = model.F_FormProperty_isRequire;
            parameters[10].Value = model.F_FormProperty_validationMessage;
            parameters[11].Value = model.F_FormProperty_targetUrl;
            parameters[12].Value = model.F_FormProperty_orderBy;
            parameters[13].Value = model.F_FormProperty_isBase;
            parameters[14].Value = model.F_FormProperty_dataSource_type;
            parameters[15].Value = model.F_FormProperty_dataSource;
            parameters[16].Value = model.F_FormProperty_dataSource_mappingField;
            parameters[17].Value = model.F_FormProperty_dataSource_mappingFieldName;
            parameters[18].Value = model.F_FormProperty_dataSource_conditionField;
            parameters[19].Value = model.F_FormProperty_dataSource_conditionValue;
            parameters[20].Value = model.F_FormProperty_dataSource_conditionType;
            parameters[21].Value = model.F_FormProperty_remark;
            parameters[22].Value = model.F_FormProperty_isSum;
            parameters[23].Value = model.F_FormProperty_triggerEvent_Type;
            parameters[24].Value = model.F_FormProperty_triggerEvent_dynamicJs;
            parameters[25].Value = model.F_FormProperty_defaultValue;
            parameters[26].Value = model.F_FormProperty_isShowInHistory;
            parameters[27].Value = model.F_FormProperty_isDelete;
            parameters[28].Value = model.F_FormProperty_creator;
            parameters[29].Value = model.F_FormProperty_createTime;

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
        public bool Update(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormProperty set ");
            strSql.Append("F_FormProperty_code=@F_FormProperty_code,");
            strSql.Append("F_FormProperty_parent=@F_FormProperty_parent,");
            strSql.Append("F_FormProperty_form=@F_FormProperty_form,");
            strSql.Append("F_FormProperty_showName=@F_FormProperty_showName,");
            strSql.Append("F_FormProperty_fieldName=@F_FormProperty_fieldName,");
            strSql.Append("F_FormProperty_fieldLength=@F_FormProperty_fieldLength,");
            strSql.Append("F_FormProperty_uiType=@F_FormProperty_uiType,");
            strSql.Append("F_FormProperty_isOnlyRead=@F_FormProperty_isOnlyRead,");
            strSql.Append("F_FormProperty_isShow=@F_FormProperty_isShow,");
            strSql.Append("F_FormProperty_isRequire=@F_FormProperty_isRequire,");
            strSql.Append("F_FormProperty_validationMessage=@F_FormProperty_validationMessage,");
            strSql.Append("F_FormProperty_targetUrl=@F_FormProperty_targetUrl,");
            strSql.Append("F_FormProperty_orderBy=@F_FormProperty_orderBy,");
            strSql.Append("F_FormProperty_isBase=@F_FormProperty_isBase,");
            strSql.Append("F_FormProperty_dataSource_type=@F_FormProperty_dataSource_type,");
            strSql.Append("F_FormProperty_dataSource=@F_FormProperty_dataSource,");
            strSql.Append("F_FormProperty_dataSource_mappingField=@F_FormProperty_dataSource_mappingField,");
            strSql.Append("F_FormProperty_dataSource_mappingFieldName=@F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("F_FormProperty_dataSource_conditionField=@F_FormProperty_dataSource_conditionField,");
            strSql.Append("F_FormProperty_dataSource_conditionValue=@F_FormProperty_dataSource_conditionValue,");
            strSql.Append("F_FormProperty_dataSource_conditionType=@F_FormProperty_dataSource_conditionType,");
            strSql.Append("F_FormProperty_remark=@F_FormProperty_remark,");
            strSql.Append("F_FormProperty_isSum=@F_FormProperty_isSum,");
            strSql.Append("F_FormProperty_triggerEvent_Type=@F_FormProperty_triggerEvent_Type,");
            strSql.Append("F_FormProperty_triggerEvent_dynamicJs=@F_FormProperty_triggerEvent_dynamicJs,");
            strSql.Append("F_FormProperty_defaultValue=@F_FormProperty_defaultValue,");
            strSql.Append("F_FormProperty_isShowInHistory=@F_FormProperty_isShowInHistory,");
            strSql.Append("F_FormProperty_isDelete=@F_FormProperty_isDelete,");
            strSql.Append("F_FormProperty_creator=@F_FormProperty_creator,");
            strSql.Append("F_FormProperty_createTime=@F_FormProperty_createTime");
            strSql.Append(" where F_FormProperty_id=@F_FormProperty_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_showName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_fieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_fieldLength", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_uiType", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_isOnlyRead", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_isShow", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_isRequire", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_validationMessage", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormProperty_targetUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@F_FormProperty_orderBy", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_isBase", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_dataSource_type", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_dataSource", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_mappingField", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormProperty_dataSource_mappingFieldName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_conditionField", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_conditionValue", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FormProperty_dataSource_conditionType", SqlDbType.Int,4),
					new SqlParameter("@F_FormProperty_remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@F_FormProperty_isSum", SqlDbType.Bit,1),
                    new SqlParameter("@F_FormProperty_triggerEvent_Type", SqlDbType.Int,4),
                    new SqlParameter("@F_FormProperty_triggerEvent_dynamicJs", SqlDbType.NVarChar,3000),
                    new SqlParameter("@F_FormProperty_defaultValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_FormProperty_isShowInHistory", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_FormProperty_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_FormProperty_createTime", SqlDbType.DateTime),
					new SqlParameter("@F_FormProperty_id", SqlDbType.Int,4)};
            parameters[0].Value = model.F_FormProperty_code;
            parameters[1].Value = model.F_FormProperty_parent;
            parameters[2].Value = model.F_FormProperty_form;
            parameters[3].Value = model.F_FormProperty_showName;
            parameters[4].Value = model.F_FormProperty_fieldName;
            parameters[5].Value = model.F_FormProperty_fieldLength;
            parameters[6].Value = model.F_FormProperty_uiType;
            parameters[7].Value = model.F_FormProperty_isOnlyRead;
            parameters[8].Value = model.F_FormProperty_isShow;
            parameters[9].Value = model.F_FormProperty_isRequire;
            parameters[10].Value = model.F_FormProperty_validationMessage;
            parameters[11].Value = model.F_FormProperty_targetUrl;
            parameters[12].Value = model.F_FormProperty_orderBy;
            parameters[13].Value = model.F_FormProperty_isBase;
            parameters[14].Value = model.F_FormProperty_dataSource_type;
            parameters[15].Value = model.F_FormProperty_dataSource;
            parameters[16].Value = model.F_FormProperty_dataSource_mappingField;
            parameters[17].Value = model.F_FormProperty_dataSource_mappingFieldName;
            parameters[18].Value = model.F_FormProperty_dataSource_conditionField;
            parameters[19].Value = model.F_FormProperty_dataSource_conditionValue;
            parameters[20].Value = model.F_FormProperty_dataSource_conditionType;
            parameters[21].Value = model.F_FormProperty_remark;
            parameters[22].Value = model.F_FormProperty_isSum;
            parameters[23].Value = model.F_FormProperty_triggerEvent_Type;
            parameters[24].Value = model.F_FormProperty_triggerEvent_dynamicJs;
            parameters[25].Value = model.F_FormProperty_defaultValue;
            parameters[26].Value = model.F_FormProperty_isShowInHistory;
            parameters[27].Value = model.F_FormProperty_isDelete;
            parameters[28].Value = model.F_FormProperty_creator;
            parameters[29].Value = model.F_FormProperty_createTime;
            parameters[30].Value = model.F_FormProperty_id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_FormProperty_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_FormProperty set ");
            strSql.Append("F_FormProperty_isDelete=1 ");
            strSql.Append("where F_FormProperty_code=@F_FormProperty_code;");
            strSql.Append("update F_FormProperty set ");
            strSql.Append("F_FormProperty_isDelete=1 ");
            strSql.Append("where F_FormProperty_parent=@F_FormProperty_parent ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormProperty_code;
            parameters[1].Value = F_FormProperty_code;

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
        public bool DeleteList(string F_FormProperty_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from F_FormProperty ");
            strSql.Append(" where F_FormProperty_id in (" + F_FormProperty_idlist + ")  ");
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
        public CommonService.Model.CustomerForm.F_FormProperty GetModel(Guid F_FormProperty_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from F_FormProperty With(Nolock) ");
            strSql.Append(" where F_FormProperty_code=@F_FormProperty_code");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = F_FormProperty_code;

            CommonService.Model.CustomerForm.F_FormProperty model = new CommonService.Model.CustomerForm.F_FormProperty();
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
        /// 通过表单属性值Id，得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormProperty GetModelById(int F_FormProperty_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from F_FormProperty With(Nolock) ");
            strSql.Append(" where F_FormProperty_id=@F_FormProperty_id");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_id", SqlDbType.Int)
			};
            parameters[0].Value = F_FormProperty_id;

            CommonService.Model.CustomerForm.F_FormProperty model = new CommonService.Model.CustomerForm.F_FormProperty();
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
        /// 得到一个表单属性
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="parentPropertyCode">父亲表单属性Guid</param>
        /// <param name="uiType">UI类型</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormProperty GetModel(Guid formCode, Guid parentPropertyCode, int uiType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append("from F_FormProperty With(Nolock) ");
            strSql.Append(" where F_FormProperty_parent=@F_FormProperty_parent ");
            strSql.Append("and F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("and F_FormProperty_uiType=@F_FormProperty_uiType ");
            strSql.Append("and F_FormProperty_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_uiType", SqlDbType.Int,4)
			};
            parameters[0].Value = parentPropertyCode;
            parameters[1].Value = formCode;
            parameters[2].Value = uiType;

            CommonService.Model.CustomerForm.F_FormProperty model = new CommonService.Model.CustomerForm.F_FormProperty();
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
        /// 根据表单和属性字段名称，获取属性
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyFieldName">属性名</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormProperty GetModelByFormAndPropertyFieldName(Guid formCode, string formPropertyFieldName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append("FROM F_FormProperty With(Nolock) ");
            strSql.Append("Where F_FormProperty_isDelete=0 ");
            strSql.Append("and F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("and F_FormProperty_fieldName=@F_FormProperty_fieldName ");

            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_fieldName", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = formCode;
            parameters[1].Value = formPropertyFieldName;

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
        /// 得到一个对象实体(不包含已删除的)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="orderBy">显示顺序号</param>
        /// <param name="parentPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormProperty GetModel(Guid formCode, Guid parentPropertyCode, ConditonType conditionType, int orderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_FormProperty_id,F_FormProperty_code,F_FormProperty_parent,F_FormProperty_form,F_FormProperty_showName,F_FormProperty_fieldName,F_FormProperty_fieldLength,F_FormProperty_uiType,F_FormProperty_isOnlyRead,F_FormProperty_isShow,F_FormProperty_isRequire,F_FormProperty_validationMessage,F_FormProperty_targetUrl,F_FormProperty_orderBy,F_FormProperty_isBase,F_FormProperty_dataSource_type,F_FormProperty_dataSource,F_FormProperty_dataSource_mappingField,F_FormProperty_dataSource_mappingFieldName,F_FormProperty_dataSource_conditionField,F_FormProperty_dataSource_conditionValue,F_FormProperty_dataSource_conditionType,F_FormProperty_remark,F_FormProperty_isSum,F_FormProperty_triggerEvent_Type,F_FormProperty_triggerEvent_dynamicJs,F_FormProperty_defaultValue,F_FormProperty_isShowInHistory,F_FormProperty_isDelete,F_FormProperty_creator,F_FormProperty_createTime ");
            strSql.Append("from F_FormProperty With(Nolock) ");
            strSql.Append("where F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("and F_FormProperty_parent=@F_FormProperty_parent ");
            strSql.Append("and F_FormProperty_isDelete=0 ");
            switch (conditionType)
            {
                case ConditonType.小于:
                    strSql.Append("and F_FormProperty_orderBy<@F_FormProperty_orderBy ");
                    strSql.Append("order by F_FormProperty_orderBy Desc ");
                    break;
                case ConditonType.大于:
                    strSql.Append("and F_FormProperty_orderBy>@F_FormProperty_orderBy ");
                    strSql.Append("order by F_FormProperty_orderBy Asc ");
                    break;
            }

            SqlParameter[] parameters = {
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_orderBy", SqlDbType.Int,4)
			};
            parameters[0].Value = formCode;
            parameters[1].Value = parentPropertyCode;
            parameters[2].Value = orderBy;

            CommonService.Model.CustomerForm.F_FormProperty model = new CommonService.Model.CustomerForm.F_FormProperty();
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
        public CommonService.Model.CustomerForm.F_FormProperty DataRowToModel(DataRow row)
        {
            CommonService.Model.CustomerForm.F_FormProperty model = new CommonService.Model.CustomerForm.F_FormProperty();
            if (row != null)
            {
                if (row["F_FormProperty_id"] != null && row["F_FormProperty_id"].ToString() != "")
                {
                    model.F_FormProperty_id = int.Parse(row["F_FormProperty_id"].ToString());
                }
                if (row["F_FormProperty_code"] != null && row["F_FormProperty_code"].ToString() != "")
                {
                    model.F_FormProperty_code = new Guid(row["F_FormProperty_code"].ToString());
                }
                if (row["F_FormProperty_parent"] != null && row["F_FormProperty_parent"].ToString() != "")
                {
                    model.F_FormProperty_parent = new Guid(row["F_FormProperty_parent"].ToString());
                }
                //父亲属性名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("F_FormProperty_parent_name"))
                {
                    if (row["F_FormProperty_parent_name"] != null)
                    {
                        model.F_FormProperty_parent_name = row["F_FormProperty_parent_name"].ToString();
                    }
                }
                if (row["F_FormProperty_form"] != null && row["F_FormProperty_form"].ToString() != "")
                {
                    model.F_FormProperty_form = new Guid(row["F_FormProperty_form"].ToString());
                }
                //表单中文名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("F_FormProperty_form_chineseName"))
                {
                    if (row["F_FormProperty_form_chineseName"] != null)
                    {
                        model.F_FormProperty_form_chineseName = row["F_FormProperty_form_chineseName"].ToString();
                    }
                }
                if (row["F_FormProperty_showName"] != null)
                {
                    model.F_FormProperty_showName = row["F_FormProperty_showName"].ToString();
                }
                if (row["F_FormProperty_fieldName"] != null)
                {
                    model.F_FormProperty_fieldName = row["F_FormProperty_fieldName"].ToString();
                }
                if (row["F_FormProperty_fieldLength"] != null && row["F_FormProperty_fieldLength"].ToString() != "")
                {
                    model.F_FormProperty_fieldLength = int.Parse(row["F_FormProperty_fieldLength"].ToString());
                }
                if (row["F_FormProperty_uiType"] != null && row["F_FormProperty_uiType"].ToString() != "")
                {
                    model.F_FormProperty_uiType = int.Parse(row["F_FormProperty_uiType"].ToString());
                }
                //控件UI类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("F_FormProperty_uiTypeName"))
                {
                    if (row["F_FormProperty_uiTypeName"] != null)
                    {
                        model.F_FormProperty_uiTypeName = row["F_FormProperty_uiTypeName"].ToString();
                    }
                }

                if (row["F_FormProperty_isOnlyRead"] != null && row["F_FormProperty_isOnlyRead"].ToString() != "")
                {
                    if ((row["F_FormProperty_isOnlyRead"].ToString() == "1") || (row["F_FormProperty_isOnlyRead"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isOnlyRead = true;
                    }
                    else
                    {
                        model.F_FormProperty_isOnlyRead = false;
                    }
                }
                if (row["F_FormProperty_isShow"] != null && row["F_FormProperty_isShow"].ToString() != "")
                {
                    if ((row["F_FormProperty_isShow"].ToString() == "1") || (row["F_FormProperty_isShow"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isShow = true;
                    }
                    else
                    {
                        model.F_FormProperty_isShow = false;
                    }
                }
                if (row["F_FormProperty_isRequire"] != null && row["F_FormProperty_isRequire"].ToString() != "")
                {
                    if ((row["F_FormProperty_isRequire"].ToString() == "1") || (row["F_FormProperty_isRequire"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isRequire = true;
                    }
                    else
                    {
                        model.F_FormProperty_isRequire = false;
                    }
                }
                if (row["F_FormProperty_validationMessage"] != null)
                {
                    model.F_FormProperty_validationMessage = row["F_FormProperty_validationMessage"].ToString();
                }
                if (row["F_FormProperty_targetUrl"] != null)
                {
                    model.F_FormProperty_targetUrl = row["F_FormProperty_targetUrl"].ToString();
                }
                if (row["F_FormProperty_orderBy"] != null && row["F_FormProperty_orderBy"].ToString() != "")
                {
                    model.F_FormProperty_orderBy = int.Parse(row["F_FormProperty_orderBy"].ToString());
                }
                if (row["F_FormProperty_isBase"] != null && row["F_FormProperty_isBase"].ToString() != "")
                {
                    if ((row["F_FormProperty_isBase"].ToString() == "1") || (row["F_FormProperty_isBase"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isBase = true;
                    }
                    else
                    {
                        model.F_FormProperty_isBase = false;
                    }
                }
                if (row["F_FormProperty_dataSource_type"] != null && row["F_FormProperty_dataSource_type"].ToString() != "")
                {
                    model.F_FormProperty_dataSource_type = int.Parse(row["F_FormProperty_dataSource_type"].ToString());
                }
                if (row["F_FormProperty_dataSource"] != null)
                {
                    model.F_FormProperty_dataSource = row["F_FormProperty_dataSource"].ToString();
                }
                if (row["F_FormProperty_dataSource_mappingField"] != null)
                {
                    model.F_FormProperty_dataSource_mappingField = row["F_FormProperty_dataSource_mappingField"].ToString();
                }
                if (row["F_FormProperty_dataSource_mappingFieldName"] != null)
                {
                    model.F_FormProperty_dataSource_mappingFieldName = row["F_FormProperty_dataSource_mappingFieldName"].ToString();
                }
                if (row["F_FormProperty_dataSource_conditionField"] != null)
                {
                    model.F_FormProperty_dataSource_conditionField = row["F_FormProperty_dataSource_conditionField"].ToString();
                }
                if (row["F_FormProperty_dataSource_conditionValue"] != null)
                {
                    model.F_FormProperty_dataSource_conditionValue = row["F_FormProperty_dataSource_conditionValue"].ToString();
                }
                if (row["F_FormProperty_dataSource_conditionType"] != null && row["F_FormProperty_dataSource_conditionType"].ToString() != "")
                {
                    model.F_FormProperty_dataSource_conditionType = int.Parse(row["F_FormProperty_dataSource_conditionType"].ToString());
                }
                if (row["F_FormProperty_isDelete"] != null && row["F_FormProperty_isDelete"].ToString() != "")
                {
                    if ((row["F_FormProperty_isDelete"].ToString() == "1") || (row["F_FormProperty_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isDelete = true;
                    }
                    else
                    {
                        model.F_FormProperty_isDelete = false;
                    }
                }
                if (row["F_FormProperty_isSum"] != null && row["F_FormProperty_isSum"].ToString() != "")
                {
                    if ((row["F_FormProperty_isSum"].ToString() == "1") || (row["F_FormProperty_isSum"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isSum = true;
                    }
                    else
                    {
                        model.F_FormProperty_isSum = false;
                    }
                }
                if (row["F_FormProperty_triggerEvent_Type"] != null && row["F_FormProperty_triggerEvent_Type"].ToString() != "")
                {
                    model.F_FormProperty_triggerEvent_Type = int.Parse(row["F_FormProperty_triggerEvent_Type"].ToString());
                }
                if (row["F_FormProperty_triggerEvent_dynamicJs"] != null)
                {
                    model.F_FormProperty_triggerEvent_dynamicJs = row["F_FormProperty_triggerEvent_dynamicJs"].ToString();
                }
                if (row["F_FormProperty_defaultValue"] != null)
                {
                    model.F_FormProperty_defaultValue = row["F_FormProperty_defaultValue"].ToString();
                }
                if (row["F_FormProperty_isShowInHistory"] != null && row["F_FormProperty_isShowInHistory"].ToString() != "")
                {
                    if ((row["F_FormProperty_isShowInHistory"].ToString() == "1") || (row["F_FormProperty_isShowInHistory"].ToString().ToLower() == "true"))
                    {
                        model.F_FormProperty_isShowInHistory = true;
                    }
                    else
                    {
                        model.F_FormProperty_isShowInHistory = false;
                    }
                }
                if (row["F_FormProperty_creator"] != null && row["F_FormProperty_creator"].ToString() != "")
                {
                    model.F_FormProperty_creator = new Guid(row["F_FormProperty_creator"].ToString());
                }
                if (row["F_FormProperty_createTime"] != null && row["F_FormProperty_createTime"].ToString() != "")
                {
                    model.F_FormProperty_createTime = DateTime.Parse(row["F_FormProperty_createTime"].ToString());
                }
                //表单属性值Id(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("V_FormPropertyValue_Id"))
                {
                    if (row["V_FormPropertyValue_Id"] != null && row["V_FormPropertyValue_Id"].ToString() != "")
                    {
                        model.V_FormPropertyValue_Id = int.Parse(row["V_FormPropertyValue_Id"].ToString());
                    }
                }
                //表单属性值Guid(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("V_FormPropertyValue_Code"))
                {
                    if (row["V_FormPropertyValue_Code"] != null && row["V_FormPropertyValue_Code"].ToString() != "")
                    {
                        model.V_FormPropertyValue_Code = new Guid(row["V_FormPropertyValue_Code"].ToString());
                    }
                }
                //业务流程表单关联Guid(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("V_BusinessFlowForm_Code"))
                {
                    if (row["V_BusinessFlowForm_Code"] != null && row["V_BusinessFlowForm_Code"].ToString() != "")
                    {
                        model.V_BusinessFlowForm_Code = new Guid(row["V_BusinessFlowForm_Code"].ToString());
                    }
                }
                //表单属性值(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("V_FormPropertyValue_Value"))
                {
                    if (row["V_FormPropertyValue_Value"] != null)
                    {
                        model.V_FormPropertyValue_Value = row["V_FormPropertyValue_Value"].ToString();
                    }
                }

                //表单属性值(虚拟属性)是否存在于列集合中(App专用,以前有此属性，但App中所有字段均需赋值)
                if (row.Table.Columns.Contains("V_FormPropertyValue_Value_Name"))
                {
                    if (row["V_FormPropertyValue_Value_Name"] != null)
                    {
                        model.V_FormPropertyValue_Value_Name = row["V_FormPropertyValue_Value_Name"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM F_FormProperty ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得基础属性列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetBaseList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormProperty_id,F_FormProperty_code,F_FormProperty_parent,F_FormProperty_form,F_FormProperty_showName,F_FormProperty_fieldName,F_FormProperty_fieldLength,F_FormProperty_uiType,F_FormProperty_isOnlyRead,F_FormProperty_isShow,F_FormProperty_isRequire,F_FormProperty_validationMessage,F_FormProperty_targetUrl,F_FormProperty_orderBy,F_FormProperty_isBase,F_FormProperty_dataSource_type,F_FormProperty_dataSource,F_FormProperty_dataSource_mappingField,F_FormProperty_dataSource_mappingFieldName,F_FormProperty_dataSource_conditionField,F_FormProperty_dataSource_conditionValue,F_FormProperty_dataSource_conditionType,F_FormProperty_remark,F_FormProperty_isSum,F_FormProperty_triggerEvent_Type,F_FormProperty_triggerEvent_dynamicJs,F_FormProperty_defaultValue,F_FormProperty_isShowInHistory,F_FormProperty_isDelete,F_FormProperty_creator,F_FormProperty_createTime ");
            strSql.Append("FROM F_FormProperty With(Nolock) ");
            strSql.Append("Where F_FormProperty_isDelete=0 and F_FormProperty_isBase=1 ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyParent">父亲属性Guid</param>
        /// <returns></returns>
        public DataSet GetList(Guid formCode, Guid formPropertyParent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("F.F_Form_chineseName As F_FormProperty_form_chineseName ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock) ");
            strSql.Append("left join F_Form As F With(Nolock) on F.F_Form_code=FP.F_FormProperty_form ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("and FP.F_FormProperty_parent=@F_FormProperty_parent ");
            strSql.Append("Order by FP.F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = formCode;
            parameters[1].Value = formPropertyParent;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public DataSet GetList(Guid formCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormProperty_id,F_FormProperty_code,F_FormProperty_parent,F_FormProperty_form,F_FormProperty_showName,F_FormProperty_fieldName,F_FormProperty_fieldLength,F_FormProperty_uiType,F_FormProperty_isOnlyRead,F_FormProperty_isShow,F_FormProperty_isRequire,F_FormProperty_validationMessage,F_FormProperty_targetUrl,F_FormProperty_orderBy,F_FormProperty_isBase,F_FormProperty_dataSource_type,F_FormProperty_dataSource,F_FormProperty_dataSource_mappingField,F_FormProperty_dataSource_mappingFieldName,F_FormProperty_dataSource_conditionField,F_FormProperty_dataSource_conditionValue,F_FormProperty_dataSource_conditionType,F_FormProperty_remark,F_FormProperty_isSum,F_FormProperty_triggerEvent_Type,F_FormProperty_triggerEvent_dynamicJs,F_FormProperty_defaultValue,F_FormProperty_isShowInHistory,F_FormProperty_isDelete,F_FormProperty_creator,F_FormProperty_createTime ");
            strSql.Append("FROM F_FormProperty With(Nolock) ");
            strSql.Append("Where F_FormProperty_isDelete=0 ");
            strSql.Append("and F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16)                     
            };
            parameters[0].Value = formCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据表单Guid，UI属性类型，获取属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="uIType">UI属性类型</param>
        /// <returns></returns>
        public DataSet GetListByFormAndUiType(Guid formCode, int uIType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_FormProperty_id,F_FormProperty_code,F_FormProperty_parent,F_FormProperty_form,F_FormProperty_showName,F_FormProperty_fieldName,F_FormProperty_fieldLength,F_FormProperty_uiType,F_FormProperty_isOnlyRead,F_FormProperty_isShow,F_FormProperty_isRequire,F_FormProperty_validationMessage,F_FormProperty_targetUrl,F_FormProperty_orderBy,F_FormProperty_isBase,F_FormProperty_dataSource_type,F_FormProperty_dataSource,F_FormProperty_dataSource_mappingField,F_FormProperty_dataSource_mappingFieldName,F_FormProperty_dataSource_conditionField,F_FormProperty_dataSource_conditionValue,F_FormProperty_dataSource_conditionType,F_FormProperty_remark,F_FormProperty_isSum,F_FormProperty_triggerEvent_Type,F_FormProperty_triggerEvent_dynamicJs,F_FormProperty_defaultValue,F_FormProperty_isShowInHistory,F_FormProperty_isDelete,F_FormProperty_creator,F_FormProperty_createTime ");
            strSql.Append("FROM F_FormProperty With(Nolock) ");
            strSql.Append("Where F_FormProperty_isDelete=0 ");
            strSql.Append("and F_FormProperty_form=@F_FormProperty_form ");
            strSql.Append("and F_FormProperty_uiType=@F_FormProperty_uiType ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_uiType", SqlDbType.Int) 
            };
            parameters[0].Value = formCode;
            parameters[1].Value = uIType;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 获取资料库属性单个显示名称
        /// </summary>
        /// <param name="table">表名称</param>    
        /// <param name="showFieldName">显示字段</param>
        /// <param name="conditionFieldName">条件字段</param>
        /// <param name="conditionFieldValue">条件值</param>
        /// <returns></returns>
        public string GetSingleEntityShowName(string table, string showFieldName, string conditionFieldName, string conditionFieldValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ");
            strSql.Append(showFieldName);
            strSql.Append(" FROM ");
            strSql.Append(table);
            strSql.Append(" With(Nolock) ");
            strSql.Append("Where ");
            strSql.Append(conditionFieldName);
            strSql.Append("=@conditionFieldValue ");

            SqlParameter[] parameters = {					                   
					new SqlParameter("@conditionFieldValue", SqlDbType.UniqueIdentifier,16)                   
            };
            parameters[0].Value = new Guid(conditionFieldValue);

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取资料库属性多个显示名称
        /// </summary>
        /// <param name="table">表名称</param>    
        /// <param name="showFieldName">显示字段</param>
        /// <param name="conditionFieldName">条件字段</param>
        /// <param name="conditionFieldValue">条件值</param>
        /// <returns></returns>
        public string GetMulityEntityShowName(string table, string showFieldName, string conditionFieldName, string conditionFieldValue)
        {
            string showNames = String.Empty;
            StringBuilder strSql = new StringBuilder();

            if (conditionFieldValue != "")
            {
                string[] condFieldValueGroup = conditionFieldValue.Split(',');
                for (int i = 0; i < condFieldValueGroup.Length; i++)
                {
                    strSql.Clear();
                    strSql.Append("select top 1 ");
                    strSql.Append(showFieldName);
                    strSql.Append(" FROM ");
                    strSql.Append(table);
                    strSql.Append(" With(Nolock) ");
                    strSql.Append("Where ");
                    strSql.Append(conditionFieldName);
                    strSql.Append("=@conditionFieldValue ");

                    DataSet ds = null;
                    if (table.ToLower() == "c_parameters")
                    {//参数表单独处理(因为它没有标识Guid列)
                        SqlParameter[] parameters = {			          
					       new SqlParameter("@conditionFieldValue", SqlDbType.Int)                   
                        };
                        parameters[0].Value = condFieldValueGroup[i];
                        ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                    }
                    else
                    {//其它为Guid列标识
                        SqlParameter[] parameters = {			          
					       new SqlParameter("@conditionFieldValue", SqlDbType.UniqueIdentifier,16)                   
                        };
                        parameters[0].Value = new Guid(condFieldValueGroup[i]);
                        ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        showNames += ds.Tables[0].Rows[0][0].ToString() + ",";
                    }
                }
            }
            if (!String.IsNullOrEmpty(showNames))
            {
                showNames = showNames.Substring(0, showNames.Length - 1);
            }
            return showNames;
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode"></param>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        public DataSet GetEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode)
        {
            /*
             * author:hety
             * date:2015-06-04
             * description:实际上只通过业务流程表单关联Guid即可确定唯一表单属性值
             * 
             * */
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16)                     
            };
            parameters[0].Value = businessFlowFormCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public DataSet GetEditFormHistorRecord(Guid businessFlowCode, Guid formCode)
        {
            /*
             * author:hety
             * date:2015-10-12
             * description:根据业务流程Guid，表单Guid，获取编辑表单自定义属性值历史记录
             * 
            * */
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock),P_Business_flow_form As BFF With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_isShowInHistory=1 ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=BFF.P_Business_flow_form_code ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and BFF.P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and BFF.F_Form_code=@F_Form_code ");
            strSql.Append("and BFF.P_Business_flow_form_isdelete=0 ");
            strSql.Append("Order by BFF.P_Business_flow_form_createTime Desc, F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16) 
            };
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = formCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        public DataSet GetHeadEditFormHistoryRecord(Guid businessFlowCode, Guid formCode)
        {
            /*
             * author:hety
             * date:2015-10-14
             * description: 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录
             * 
             * */
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select T.* from(");

            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,BFF.P_Business_flow_form_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_id As V_FormPropertyValue_Id,FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock),P_Business_flow_form As BFF With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FP.F_FormProperty_isShowInHistory=1 ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=BFF.P_Business_flow_form_code ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' ");
            strSql.Append("and FP.F_FormProperty_uiType<>527 ");
            strSql.Append("and BFF.P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and BFF.F_Form_code=@F_Form_code ");
            strSql.Append("and BFF.P_Business_flow_form_isdelete=0 ");

            strSql.Append("union all ");

            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,BFF.P_Business_flow_form_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_id As V_FormPropertyValue_Id,FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock),P_Business_flow_form As BFF With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FP.F_FormProperty_isShowInHistory=1 ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=BFF.P_Business_flow_form_code ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and BFF.P_Business_flow_code=@P_Business_flow_code ");
            strSql.Append("and BFF.F_Form_code=@F_Form_code ");
            strSql.Append("and BFF.P_Business_flow_form_isdelete=0 ");
            strSql.Append("and Exists(select 1 from F_FormProperty As S With(Nolock) where S.F_FormProperty_form=@F_Form_code and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType=527 and S.F_FormProperty_code = FP.F_FormProperty_parent) ");

            strSql.Append(") As T ");
            strSql.Append("Order by P_Business_flow_form_createTime Desc, F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16) 
            };
            parameters[0].Value = businessFlowCode;
            parameters[1].Value = formCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 根据协同办公表单Guid，获取编辑协同办公表单属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public DataSet GetOAEditFormPropertyValueList(Guid fFormCode, Guid oFormCode)
        {
            /*
             * author:hety
             * date:2015-08-05
             * description:实际上只通过协同办公表单Guid即可确定唯一表单属性值
             * 
             * */
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_id As V_FormPropertyValue_Id,FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@oFormCode ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@oFormCode", SqlDbType.UniqueIdentifier,16)                     
            };
            parameters[0].Value = oFormCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据协同办公表单Guid，获取主子表协同办公表单编辑属性及其值
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public DataSet GetOAHeadEditFormPropertyValueList(Guid fFormCode, Guid oFormCode)
        {
            /*
             * author:hety
             * date:2015-08-05
             * description:实际上只通过协同办公表单Guid即可确定唯一表单属性值
             * 
             * */
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select T.* from(");

            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_id As V_FormPropertyValue_Id,FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@oFormCode ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' ");
            strSql.Append("and FP.F_FormProperty_uiType<>527 ");

            strSql.Append("union all ");

            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_id As V_FormPropertyValue_Id,FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@oFormCode ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and Exists(select 1 from F_FormProperty As S With(Nolock) where S.F_FormProperty_form=@fFormCode and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType=527 and S.F_FormProperty_code = FP.F_FormProperty_parent) ");

            strSql.Append(") As T ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@oFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@fFormCode", SqlDbType.UniqueIdentifier,16)  
            };
            parameters[0].Value = oFormCode;
            parameters[1].Value = fFormCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 根据业务流程表单关联Guid，获取tab编辑自定义表单属性及其值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="parentFormPropertyCode">父亲表单属性Guid</param>
        /// <returns></returns>
        public DataSet GetTabEditFormPropertyValueList(Guid formCode, Guid businessFlowFormCode, Guid parentFormPropertyCode)
        {
            /*
             * author:hety
             * date:2015-06-04
             * description:实际上只通过业务流程表单关联Guid即可确定唯一表单属性值
             * 
             * */
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FP.F_FormProperty_id,FP.F_FormProperty_code,FP.F_FormProperty_parent,FP.F_FormProperty_form,FP.F_FormProperty_showName,FP.F_FormProperty_fieldName,FP.F_FormProperty_fieldLength,");
            strSql.Append("FP.F_FormProperty_uiType,FP.F_FormProperty_isOnlyRead,FP.F_FormProperty_isShow,FP.F_FormProperty_isRequire,FP.F_FormProperty_validationMessage,FP.F_FormProperty_targetUrl,FP.F_FormProperty_orderBy,");
            strSql.Append("FP.F_FormProperty_isBase,FP.F_FormProperty_dataSource_type,FP.F_FormProperty_dataSource,FP.F_FormProperty_dataSource_mappingField,FP.F_FormProperty_dataSource_mappingFieldName,");
            strSql.Append("FP.F_FormProperty_dataSource_conditionField,FP.F_FormProperty_dataSource_conditionValue,FP.F_FormProperty_dataSource_conditionType,FP.F_FormProperty_remark,FP.F_FormProperty_isSum,");
            strSql.Append("FP.F_FormProperty_triggerEvent_Type,FP.F_FormProperty_triggerEvent_dynamicJs,FP.F_FormProperty_defaultValue,FP.F_FormProperty_isShowInHistory,");
            strSql.Append("FP.F_FormProperty_isDelete,FP.F_FormProperty_creator,FP.F_FormProperty_createTime,");
            strSql.Append("FPV.F_FormPropertyValue_code As V_FormPropertyValue_Code,FPV.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,FPV.F_FormPropertyValue_value As V_FormPropertyValue_Value ");
            strSql.Append("FROM F_FormProperty As FP With(Nolock),F_FormPropertyValue As FPV With(Nolock) ");
            strSql.Append("Where FP.F_FormProperty_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_form=FPV.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=FPV.F_FormPropertyValue_formProperty ");
            strSql.Append("and FPV.F_FormPropertyValue_BusinessFlowFormCode=@F_FormPropertyValue_BusinessFlowFormCode ");
            strSql.Append("and FPV.F_FormPropertyValue_isDelete=0 ");
            strSql.Append("and FP.F_FormProperty_parent=@F_FormProperty_parent ");
            strSql.Append("Order by F_FormProperty_orderBy Asc ");

            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormPropertyValue_BusinessFlowFormCode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier,16)  
            };
            parameters[0].Value = businessFlowFormCode;
            parameters[1].Value = parentFormPropertyCode;

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
            strSql.Append(" * ");
            strSql.Append(" FROM F_FormProperty ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_FormProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM F_FormProperty With(nolock) ");
            strSql.Append(" where 1=1 and F_FormProperty_isDelete=0 ");
            if (model != null)
            {
                if (model.F_FormProperty_showName != null)
                {
                    strSql.Append("and F_FormProperty_showName=@F_FormProperty_showName ");
                }
                if (model.F_FormProperty_form != null)
                {
                    strSql.Append("and F_FormProperty_form=@F_FormProperty_form ");
                }
                if (model.F_FormProperty_parent != null)
                {
                    strSql.Append("and F_FormProperty_parent=@F_FormProperty_parent ");
                }
            }
            SqlParameter[] parameters = {					
					new SqlParameter("@F_FormProperty_showName", SqlDbType.VarChar,50),
                    new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier, 16)
            };
            parameters[0].Value = model.F_FormProperty_showName;
            parameters[1].Value = model.F_FormProperty_form;
            parameters[2].Value = model.F_FormProperty_parent;

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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(CommonService.Model.CustomerForm.F_FormProperty model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.F_FormProperty_orderBy desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name As F_FormProperty_uiTypeName,PF.F_FormProperty_showName As F_FormProperty_parent_name ");
            strSql.Append("from F_FormProperty AS T With(nolock) ");
            strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.F_FormProperty_uiType = P.C_Parameters_id ");
            strSql.Append("left join F_FormProperty AS PF WITH(NOLOCK) on T.F_FormProperty_parent = PF.F_FormProperty_code ");
            strSql.Append(" where 1=1 and T.F_FormProperty_isDelete=0 ");
            if (model != null)
            {
                if (model.F_FormProperty_showName != null)
                {
                    strSql.Append("and T.F_FormProperty_showName=@F_FormProperty_showName ");
                }
                if (model.F_FormProperty_form != null)
                {
                    strSql.Append("and T.F_FormProperty_form=@F_FormProperty_form ");
                }
                if (model.F_FormProperty_parent != null)
                {
                    strSql.Append("and T.F_FormProperty_parent=@F_FormProperty_parent ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = { 
                                           new SqlParameter("@F_FormProperty_showName", SqlDbType.VarChar, 50),
                                           new SqlParameter("@F_FormProperty_form", SqlDbType.UniqueIdentifier, 16),
                                           new SqlParameter("@F_FormProperty_parent", SqlDbType.UniqueIdentifier, 16)
                                        };

            parameters[0].Value = model.F_FormProperty_showName;
            parameters[1].Value = model.F_FormProperty_form;
            parameters[2].Value = model.F_FormProperty_parent;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            parameters[0].Value = "F_FormProperty";
            parameters[1].Value = "F_FormProperty_id";
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
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录（不包含隐藏控件）
        /// </summary>
        /// <param name="businessFlowCode">业务流程表单Guid</param>
        /// <returns></returns>
        public DataSet GetHeadEditFormHistoryRecord(Guid businessFlowFormCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,fv.F_FormPropertyValue_code As V_FormPropertyValue_Code,fv.F_FormPropertyValue_id As V_FormPropertyValue_Id,fv.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,fv.F_FormPropertyValue_value As V_FormPropertyValue_Value,fv.F_FormPropertyValue_value As V_FormPropertyValue_Value_Name from F_FormPropertyValue fv ");
            strSql.Append("left join F_FormProperty fp on fp.F_FormProperty_code=fv.F_FormPropertyValue_formProperty ");
            strSql.Append("where fp.F_FormProperty_isShow=1 and fp.F_FormProperty_isBase=0 and fp.F_FormProperty_parent='00000000-0000-0000-0000-000000000000' and fv.F_FormPropertyValue_BusinessFlowFormCode=@P_Business_flow_form_code ");
            strSql.Append("and not Exists(select 1 from F_FormProperty As S With(Nolock) where S.F_FormProperty_form=fv.F_FormPropertyValue_form and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType=527 and S.F_FormProperty_code = FP.F_FormProperty_parent) ");
            strSql.Append("union all ");
            strSql.Append("select *,fv.F_FormPropertyValue_code As V_FormPropertyValue_Code,fv.F_FormPropertyValue_id As V_FormPropertyValue_Id,fv.F_FormPropertyValue_BusinessFlowFormCode As V_BusinessFlowForm_Code,fv.F_FormPropertyValue_value As V_FormPropertyValue_Value,fv.F_FormPropertyValue_value As V_FormPropertyValue_Value_Name from F_FormPropertyValue fv ");
            strSql.Append("left join F_FormProperty fp on fp.F_FormProperty_code=fv.F_FormPropertyValue_formProperty ");
            strSql.Append("where fp.F_FormProperty_isDelete=0 and fp.F_FormProperty_form=fv.F_FormPropertyValue_form ");
            strSql.Append("and FP.F_FormProperty_code=fv.F_FormPropertyValue_formProperty  ");
            strSql.Append("and fv.F_FormPropertyValue_BusinessFlowFormCode=@P_Business_flow_form_code ");
            strSql.Append("and fv.F_FormPropertyValue_isDelete=0  ");
            strSql.Append("and Exists(select 1 from F_FormProperty As S With(Nolock) where S.F_FormProperty_form=fv.F_FormPropertyValue_form and S.F_FormProperty_isDelete=0 and S.F_FormProperty_uiType=527 and S.F_FormProperty_code = FP.F_FormProperty_parent) order by F_FormProperty_orderBy");


            SqlParameter[] parameters = {					
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = businessFlowFormCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion
    }
}
