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
    /// 数据访问类:自定义表单表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class F_Form
    {
        public F_Form()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_Form_id", "F_Form");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_Form_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_Form");
            strSql.Append(" where F_Form_id=@F_Form_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_id", SqlDbType.Int,4)			};
            parameters[0].Value = F_Form_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在表单标识
        /// </summary>
        /// <param name="formIdentification">表单标识</param>
        /// <returns></returns>
        public bool ExistsFormIdentification(string formIdentification)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from F_Form WITH(NOLOCK) ");
            strSql.Append(" where F_Form_englishName=@F_Form_englishName ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_englishName", SqlDbType.NVarChar,50)			
            };
            parameters[0].Value = formIdentification;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_Form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into F_Form(");
            strSql.Append("F_Form_code,F_Form_englishName,F_Form_chineseName,F_Form_type,F_Form_remark,F_Form_isDelete,F_Form_creator,F_Form_createTime,F_Form_IsChiefCheck)");
            strSql.Append(" values (");
            strSql.Append("@F_Form_code,@F_Form_englishName,@F_Form_chineseName,@F_Form_type,@F_Form_remark,@F_Form_isDelete,@F_Form_creator,@F_Form_createTime,@F_Form_IsChiefCheck)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {				 
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_englishName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_Form_chineseName", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_Form_type", SqlDbType.Int,4),
					new SqlParameter("@F_Form_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@F_Form_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_Form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_createTime", SqlDbType.DateTime),
                    new SqlParameter("@F_Form_IsChiefCheck",SqlDbType.Bit)                    
                                        };        
            parameters[0].Value = model.F_Form_code;
            parameters[1].Value = model.F_Form_englishName;
            parameters[2].Value = model.F_Form_chineseName;
            parameters[3].Value = model.F_Form_type;
            parameters[4].Value = model.F_Form_remark;
            parameters[5].Value = model.F_Form_isDelete;
            parameters[6].Value = model.F_Form_creator;
            parameters[7].Value = model.F_Form_createTime;
            parameters[8].Value = model.F_Form_IsChiefCheck;

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
        public bool Update(CommonService.Model.CustomerForm.F_Form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_Form set ");
            strSql.Append("F_Form_code=@F_Form_code,");
            strSql.Append("F_Form_englishName=@F_Form_englishName,");
            strSql.Append("F_Form_chineseName=@F_Form_chineseName,");
            strSql.Append("F_Form_type=@F_Form_type,");
            strSql.Append("F_Form_remark=@F_Form_remark,");
            strSql.Append("F_Form_isDelete=@F_Form_isDelete,");
            strSql.Append("F_Form_creator=@F_Form_creator,");
            strSql.Append("F_Form_createTime=@F_Form_createTime,");
            strSql.Append("F_Form_IsChiefCheck=@F_Form_IsChiefCheck ");
            strSql.Append(" where F_Form_id=@F_Form_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_englishName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_Form_chineseName", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_Form_type", SqlDbType.Int,4),
					new SqlParameter("@F_Form_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@F_Form_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_Form_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_createTime", SqlDbType.DateTime),
					new SqlParameter("@F_Form_id", SqlDbType.Int,4),
                    new SqlParameter("@F_Form_IsChiefCheck",SqlDbType.Bit)                    
                                        };
            parameters[0].Value = model.F_Form_code;
            parameters[1].Value = model.F_Form_englishName;
            parameters[2].Value = model.F_Form_chineseName;
            parameters[3].Value = model.F_Form_type;
            parameters[4].Value = model.F_Form_remark;
            parameters[5].Value = model.F_Form_isDelete;
            parameters[6].Value = model.F_Form_creator;
            parameters[7].Value = model.F_Form_createTime;
            parameters[8].Value = model.F_Form_id;
            parameters[9].Value = model.F_Form_IsChiefCheck;

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
        public bool Delete(Guid F_Form_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update F_Form set ");
            strSql.Append("F_Form_isDelete=1 ");
            strSql.Append(" where F_Form_code=@F_Form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = F_Form_code;

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
        public bool DeleteList(string F_Form_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from F_Form ");
            strSql.Append(" where F_Form_id in (" + F_Form_idlist + ")  ");
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
        public CommonService.Model.CustomerForm.F_Form GetModel(Guid F_Form_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_Form_id,F_Form_code,F_Form_englishName,F_Form_chineseName,F_Form_type,F_Form_remark,F_Form_isDelete,F_Form_creator,F_Form_createTime,F_Form_IsChiefCheck from F_Form ");
            strSql.Append(" where F_Form_code=@F_Form_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = F_Form_code;

            CommonService.Model.CustomerForm.F_Form model = new CommonService.Model.CustomerForm.F_Form();
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
        public CommonService.Model.CustomerForm.F_Form DataRowToModel(DataRow row)
        {
            CommonService.Model.CustomerForm.F_Form model = new CommonService.Model.CustomerForm.F_Form();
            if (row != null)
            {
                if (row["F_Form_id"] != null && row["F_Form_id"].ToString() != "")
                {
                    model.F_Form_id = int.Parse(row["F_Form_id"].ToString());
                }
                if (row["F_Form_code"] != null && row["F_Form_code"].ToString() != "")
                {
                    model.F_Form_code = new Guid(row["F_Form_code"].ToString());
                }
                if (row["F_Form_englishName"] != null)
                {
                    model.F_Form_englishName = row["F_Form_englishName"].ToString();
                }
                if (row["F_Form_chineseName"] != null)
                {
                    model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
                }
                if (row["F_Form_type"] != null && row["F_Form_type"].ToString() != "")
                {
                    model.F_Form_type = int.Parse(row["F_Form_type"].ToString());
                }
                if (row["F_Form_remark"] != null)
                {
                    model.F_Form_remark = row["F_Form_remark"].ToString();
                }
                if (row["F_Form_isDelete"] != null && row["F_Form_isDelete"].ToString() != "")
                {
                    if ((row["F_Form_isDelete"].ToString() == "1") || (row["F_Form_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.F_Form_isDelete = true;
                    }
                    else
                    {
                        model.F_Form_isDelete = false;
                    }
                }
                if (row["F_Form_creator"] != null && row["F_Form_creator"].ToString() != "")
                {
                    model.F_Form_creator = new Guid(row["F_Form_creator"].ToString());
                }
                //判断创建人名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("F_Form_creator_name"))
                {
                    if(row["F_Form_creator_name"]!=null && row["F_Form_creator_name"].ToString()!="")
                    {
                        model.F_Form_creator_name = row["F_Form_creator_name"].ToString();
                    }
                }
                if (row["F_Form_createTime"] != null && row["F_Form_createTime"].ToString() != "")
                {
                    model.F_Form_createTime = DateTime.Parse(row["F_Form_createTime"].ToString());
                }
                if (row["F_Form_IsChiefCheck"] != null && row["F_Form_IsChiefCheck"].ToString() != "")
                {
                    if ((row["F_Form_IsChiefCheck"].ToString() == "1") || (row["F_Form_IsChiefCheck"].ToString().ToLower() == "true"))
                    {
                        model.F_Form_IsChiefCheck = true;
                    }
                    else
                    {
                        model.F_Form_IsChiefCheck = false;
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
            strSql.Append("select F_Form_id,F_Form_code,F_Form_englishName,F_Form_chineseName,F_Form_type,F_Form_remark,F_Form_isDelete,F_Form_creator,F_Form_createTime,F_Form_IsChiefCheck ");
            strSql.Append(" FROM F_Form ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllListByForm_type(int F_Form_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_Form_id,F_Form_code,F_Form_englishName,F_Form_chineseName,F_Form_type,F_Form_remark,F_Form_isDelete,F_Form_creator,F_Form_createTime,F_Form_IsChiefCheck ");
            strSql.Append(" FROM F_Form ");
            strSql.Append("where F_Form_isDelete=0 ");
            if (F_Form_type != 0)
            {
                strSql.Append("and F_Form_type=@F_Form_type ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_type", SqlDbType.Int,4)};
            parameters[0].Value = F_Form_type;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            strSql.Append(" F_Form_id,F_Form_code,F_Form_englishName,F_Form_chineseName,F_Form_type,F_Form_remark,F_Form_isDelete,F_Form_creator,F_Form_createTime,F_Form_IsChiefCheck ");
            strSql.Append(" FROM F_Form ");
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
        public int GetRecordCount(CommonService.Model.CustomerForm.F_Form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM F_Form With(nolock) ");
            strSql.Append(" where 1=1 and F_Form_isDelete=0 ");
            if (model != null)
            {
                if (model.F_Form_chineseName != null)
                {
                    strSql.Append("and F_Form_chineseName like N'%'+@F_Form_chineseName+'%' ");
                }
                if (model.F_Form_englishName != null)
                {
                    strSql.Append(" and F_Form_englishName=@F_Form_englishName ");
                }         

            }
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_chineseName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_Form_englishName", SqlDbType.NVarChar,50)
					};
            parameters[0].Value = model.F_Form_chineseName;                                                                                                                                                        
            parameters[1].Value = model.F_Form_englishName;
             
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
        public DataSet GetListByPage(CommonService.Model.CustomerForm.F_Form model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.F_Form_id desc");
            }
            strSql.Append(")AS Row, T.*,U.C_Userinfo_name as 'F_Form_creator_name' from F_Form AS T With(nolock) left join C_Userinfo as U With(nolock) on T.F_Form_creator=U.C_Userinfo_code ");
            strSql.Append(" where 1=1 and T.F_Form_isDelete=0 ");
            if (model != null)
            {
                if (model.F_Form_chineseName != null)
                {
                    strSql.Append("and F_Form_chineseName like N'%'+@F_Form_chineseName+'%' ");
                }
                if (model.F_Form_englishName != null)
                {
                    strSql.Append(" and F_Form_englishName=@F_Form_englishName ");
                }
                if (model.F_Form_type != null)
                {
                    strSql.Append(" and F_Form_type=@F_Form_type");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@F_Form_chineseName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_Form_englishName", SqlDbType.NVarChar,50),
                    new SqlParameter("@F_Form_type", SqlDbType.Int,4)
					};
            parameters[0].Value = model.F_Form_chineseName;
            parameters[1].Value = model.F_Form_englishName;
            parameters[2].Value = model.F_Form_type;
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
            parameters[0].Value = "F_Form";
            parameters[1].Value = "F_Form_id";
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
    }
}
