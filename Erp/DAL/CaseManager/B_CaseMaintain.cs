using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references

namespace CommonService.DAL.CaseManager
{
    public class B_CaseMaintain
    {
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_CaseMaintain_id", "B_CaseMaintain");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_CaseMaintain_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CaseMaintain");
            strSql.Append(" where B_CaseMaintain_id=B_CaseMaintain_id");
            SqlParameter[] parameters = {
					new SqlParameter("B_CaseMaintain_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_CaseMaintain_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseMaintain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CaseMaintain(");
            strSql.Append("B_CaseMaintain_code,B_Case_code,B_Flow_code,F_Form_code,B_CaseMaintain_Date,B_CaseMaintain_Name,B_CaseMaintain_Content,B_CaseMaintain_Suggest,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@B_CaseMaintain_code,@B_Case_code,@B_Flow_code,@F_Form_code,@B_CaseMaintain_Date,@B_CaseMaintain_Name,@B_CaseMaintain_Content,@B_CaseMaintain_Suggest,@B_CaseCost_remarks,@B_CaseCost_creator,@B_CaseCost_createTime,@B_CaseCost_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseMaintain_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseMaintain_Date", SqlDbType.DateTime),
					new SqlParameter("@B_CaseMaintain_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@B_CaseMaintain_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseMaintain_Suggest", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseCost_remarks", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseCost_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseCost_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Flow_code;
            parameters[3].Value = model.F_Form_code;
            parameters[4].Value = model.B_CaseMaintain_Date;
            parameters[5].Value = model.B_CaseMaintain_Name;
            parameters[6].Value = model.B_CaseMaintain_Content;
            parameters[7].Value = model.B_CaseMaintain_Suggest;
            parameters[8].Value = model.B_CaseCost_remarks;
            parameters[9].Value = model.B_CaseCost_creator;
            parameters[10].Value = model.B_CaseCost_createTime;
            parameters[11].Value = model.B_CaseCost_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_CaseMaintain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CaseMaintain set ");
            strSql.Append("B_CaseMaintain_code=@B_CaseMaintain_code,");
            strSql.Append("B_Case_code=@B_Case_code,");
            strSql.Append("B_Flow_code=@B_Flow_code,");
            strSql.Append("F_Form_code=@F_Form_code,");
            strSql.Append("B_CaseMaintain_Date=@B_CaseMaintain_Date,");
            strSql.Append("B_CaseMaintain_Name=@B_CaseMaintain_Name,");
            strSql.Append("B_CaseMaintain_Content=@B_CaseMaintain_Content,");
            strSql.Append("B_CaseMaintain_Suggest=@B_CaseMaintain_Suggest,");
            strSql.Append("B_CaseCost_remarks=@B_CaseCost_remarks,");
            strSql.Append("B_CaseCost_creator=@B_CaseCost_creator,");
            strSql.Append("B_CaseCost_createTime=@B_CaseCost_createTime,");
            strSql.Append("B_CaseCost_isDelete=@B_CaseCost_isDelete");
            strSql.Append(" where B_CaseMaintain_id=@B_CaseMaintain_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseMaintain_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@F_Form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseMaintain_Date", SqlDbType.DateTime),
					new SqlParameter("@B_CaseMaintain_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@B_CaseMaintain_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseMaintain_Suggest", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseCost_remarks", SqlDbType.NVarChar,500),
					new SqlParameter("@B_CaseCost_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_CaseCost_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_CaseCost_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_CaseMaintain_id", SqlDbType.Int,4)};
            parameters[0].Value = model.B_CaseMaintain_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.B_Flow_code;
            parameters[3].Value = model.F_Form_code;
            parameters[4].Value = model.B_CaseMaintain_Date;
            parameters[5].Value = model.B_CaseMaintain_Name;
            parameters[6].Value = model.B_CaseMaintain_Content;
            parameters[7].Value = model.B_CaseMaintain_Suggest;
            parameters[8].Value = model.B_CaseCost_remarks;
            parameters[9].Value = model.B_CaseCost_creator;
            parameters[10].Value = model.B_CaseCost_createTime;
            parameters[11].Value = model.B_CaseCost_isDelete;
            parameters[12].Value = model.B_CaseMaintain_id;

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
        public bool Delete(int B_CaseMaintain_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_CaseMaintain ");
            strSql.Append(" where B_CaseMaintain_id=@B_CaseMaintain_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseMaintain_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_CaseMaintain_id;

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


        public bool DeleteCase(string B_CaseMaintain_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_CaseMaintain ");
            strSql.Append(" where B_Case_code=" + "'" + @B_CaseMaintain_id + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseMaintain_id", SqlDbType.NVarChar)
			};
            parameters[0].Value = B_CaseMaintain_id;

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
        public bool DeleteList(string B_CaseMaintain_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_CaseMaintain ");
            strSql.Append(" where B_CaseMaintain_id in (" + B_CaseMaintain_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_CaseMaintain GetModel(int B_CaseMaintain_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_CaseMaintain_id,B_CaseMaintain_code,B_Case_code,B_Flow_code,F_Form_code,B_CaseMaintain_Date,B_CaseMaintain_Name,B_CaseMaintain_Content,B_CaseMaintain_Suggest,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete from B_CaseMaintain ");
            strSql.Append(" where B_CaseMaintain_id=@B_CaseMaintain_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_CaseMaintain_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_CaseMaintain_id;

            CommonService.Model.CaseManager.B_CaseMaintain model = new CommonService.Model.CaseManager.B_CaseMaintain();
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
        public CommonService.Model.CaseManager.B_CaseMaintain DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_CaseMaintain model = new CommonService.Model.CaseManager.B_CaseMaintain();
            if (row != null)
            {
                if (row["B_CaseMaintain_id"] != null && row["B_CaseMaintain_id"].ToString() != "")
                {
                    model.B_CaseMaintain_id = int.Parse(row["B_CaseMaintain_id"].ToString());
                }
                if (row["B_CaseMaintain_code"] != null && row["B_CaseMaintain_code"].ToString() != "")
                {
                    model.B_CaseMaintain_code = new Guid(row["B_CaseMaintain_code"].ToString());
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row["B_Flow_code"] != null && row["B_Flow_code"].ToString() != "")
                {
                    model.B_Flow_code = new Guid(row["B_Flow_code"].ToString());
                }
                if (row["F_Form_code"] != null && row["F_Form_code"].ToString() != "")
                {
                    model.F_Form_code = new Guid(row["F_Form_code"].ToString());
                }
                if (row["B_CaseMaintain_Date"] != null && row["B_CaseMaintain_Date"].ToString() != "")
                {
                    model.B_CaseMaintain_Date = DateTime.Parse(row["B_CaseMaintain_Date"].ToString());
                }
                if (row["B_CaseMaintain_Name"] != null)
                {
                    model.B_CaseMaintain_Name = row["B_CaseMaintain_Name"].ToString();
                }
                if (row["B_CaseMaintain_Content"] != null)
                {
                    model.B_CaseMaintain_Content = row["B_CaseMaintain_Content"].ToString();
                }
                if (row["B_CaseMaintain_Suggest"] != null)
                {
                    model.B_CaseMaintain_Suggest = row["B_CaseMaintain_Suggest"].ToString();
                }
                if (row["B_CaseCost_remarks"] != null)
                {
                    model.B_CaseCost_remarks = row["B_CaseCost_remarks"].ToString();
                }
                if (row["B_CaseCost_creator"] != null && row["B_CaseCost_creator"].ToString() != "")
                {
                    model.B_CaseCost_creator = new Guid(row["B_CaseCost_creator"].ToString());
                }
                if (row["B_CaseCost_createTime"] != null && row["B_CaseCost_createTime"].ToString() != "")
                {
                    model.B_CaseCost_createTime = DateTime.Parse(row["B_CaseCost_createTime"].ToString());
                }
                if (row["B_CaseCost_isDelete"] != null && row["B_CaseCost_isDelete"].ToString() != "")
                {
                    model.B_CaseCost_isDelete = int.Parse(row["B_CaseCost_isDelete"].ToString());
                }
                //是否包含关联流程名称（虚拟字段）
                if (row.Table.Columns.Contains("B_Flow_name"))
                {
                    if (row["B_Flow_name"] != null && row["B_Flow_name"].ToString() != "")
                    {
                        model.B_Flow_name = row["B_Flow_name"].ToString();
                    }
                }
                //是否包含关联表单名称（虚拟字段）
                if (row.Table.Columns.Contains("F_Form_name"))
                {
                    if (row["F_Form_name"] != null && row["F_Form_name"].ToString() != "")
                    {
                        model.F_Form_name = row["F_Form_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("B_Case_name"))
                {
                    if (row["B_Case_name"] != null && row["B_Case_name"].ToString() != "")
                    {
                        model.B_Case_Name = row["B_Case_name"].ToString();
                    }
                }

                //是否包含创建人名称（虚拟字段）
                if (row.Table.Columns.Contains("B_CaseCost_creatorName"))
                {
                    if (row["B_CaseCost_creatorName"] != null && row["B_CaseCost_creatorName"].ToString() != "")
                    {
                        model.B_CaseCost_creatorName = row["B_CaseCost_creatorName"].ToString();
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
            strSql.Append("select B_CaseMaintain_id,B_CaseMaintain_code,B_Case_code,B_Flow_code,F_Form_code,B_CaseMaintain_Date,B_CaseMaintain_Name,B_CaseMaintain_Content,B_CaseMaintain_Suggest,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete ");
            strSql.Append(" FROM B_CaseMaintain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" B_CaseMaintain_id,B_CaseMaintain_code,B_Case_code,B_Flow_code,F_Form_code,B_CaseMaintain_Date,B_CaseMaintain_Name,B_CaseMaintain_Content,B_CaseMaintain_Suggest,B_CaseCost_remarks,B_CaseCost_creator,B_CaseCost_createTime,B_CaseCost_isDelete ");
            strSql.Append(" FROM B_CaseMaintain ");
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
        public int GetRecordCount(CommonService.Model.CaseManager.B_CaseMaintain strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM B_CaseMaintain ");
            if (strWhere.B_CaseMaintain_Name != null && strWhere.B_CaseMaintain_Name.Trim() != "")
            {
                strSql.Append(" where " + strWhere.B_CaseMaintain_Name);
            }
            if (strWhere.B_Case_code != null)
            {
                strSql.Append(" WHERE B_Case_code=" + "'" + strWhere.B_Case_code + "'");
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
        public DataSet GetListByPage(CommonService.Model.CaseManager.B_CaseMaintain strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.B_CaseMaintain_id desc");
            }
            strSql.Append(")AS Row, T.*,BF.P_Business_flow_name as 'B_Flow_name',BC.B_Case_name,");
            strSql.Append("(select F_Form_chineseName from F_Form where F_Form_code=(select top 1 F_Form_code from P_Business_flow_form where P_Business_flow_form_code=T.F_Form_code)) as 'F_Form_name' ");
            strSql.Append(",U.C_Userinfo_name as 'B_CaseCost_creatorName'  from B_CaseMaintain T ");
            strSql.Append("left join B_Case as BC on T.B_Case_code=BC.B_Case_code ");
            strSql.Append("left join P_Business_flow as BF on T.B_Flow_code=BF.P_Business_flow_code ");
            strSql.Append("left join P_Business_flow_form as F on T.F_Form_code=F.P_Business_flow_form_code ");
            strSql.Append("left join C_Userinfo U on T.B_CaseCost_creator=U.C_Userinfo_code ");
            if (strWhere.B_CaseMaintain_Name != null && strWhere.B_CaseMaintain_Name.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere.B_CaseMaintain_Name);
            }
            if (strWhere.B_Case_code != null && strWhere.B_Case_code.ToString()!= "00000000-0000-0000-0000-000000000000")
            {
                strSql.Append(" WHERE T.B_Case_code=" + "'" + strWhere.B_Case_code + "'");
            }
            if (strWhere.B_Flow_code != null && strWhere.B_Flow_code.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                strSql.Append(" WHERE T.B_Flow_code=" + "'" + strWhere.B_Flow_code + "'");
            }
            if (strWhere.F_Form_code != null && strWhere.F_Form_code.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                strSql.Append(" WHERE T.F_Form_code=" + "'" + strWhere.F_Form_code + "'");
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
                    new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012PageSize", SqlDbType.Int),
                    new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
                    new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
                    new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
                    new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "B_CaseMaintain";
            parameters[1].Value = "B_CaseMaintain_id";
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
