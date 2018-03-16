using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.Reporting
{
    /// <summary>
    /// 数据访问类:R_TakeCase_Reporting
    /// </summary>
    public partial class R_TakeCase_Reporting
    {
        public R_TakeCase_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_TakeCase_Reporting");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_TakeCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_TakeCase_Reporting(");
            strSql.Append("R_TakeCase_Reporting_year,R_TakeCase_Reporting_month,R_TakeCase_Reporting_area,R_TakeCase_Reporting_dept,R_TakeCase_Reporting_minister,B_TakeCase_Reporting_consultant,B_TakeCase_Reporting_customer,B_TakeCase_Reporting_newOrOld,B_TakeCase_Reporting_level,B_TakeCase_Reporting_loyalty,B_TakeCase_Reporting_sect,B_TakeCase_Reporting_caseNumber,B_TakeCase_Reporting_relCustomer,B_TakeCase_Reporting_rival,B_TakeCase_Reporting_project,B_TakeCase_Reporting_plate,B_TakeCase_Reporting_property,B_TakeCase_Reporting_transferTarget,B_TakeCase_Reporting_expectedReturn,B_TakeCase_Reporting_court)");
            strSql.Append(" values (");
            strSql.Append("@R_TakeCase_Reporting_year,@R_TakeCase_Reporting_month,@R_TakeCase_Reporting_area,@R_TakeCase_Reporting_dept,@R_TakeCase_Reporting_minister,@B_TakeCase_Reporting_consultant,@B_TakeCase_Reporting_customer,@B_TakeCase_Reporting_newOrOld,@B_TakeCase_Reporting_level,@B_TakeCase_Reporting_loyalty,@B_TakeCase_Reporting_sect,@B_TakeCase_Reporting_caseNumber,@B_TakeCase_Reporting_relCustomer,@B_TakeCase_Reporting_rival,@B_TakeCase_Reporting_project,@B_TakeCase_Reporting_plate,@B_TakeCase_Reporting_property,@B_TakeCase_Reporting_transferTarget,@B_TakeCase_Reporting_expectedReturn,@B_TakeCase_Reporting_court)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@R_TakeCase_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_TakeCase_Reporting_month", SqlDbType.VarChar,5),
					new SqlParameter("@R_TakeCase_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_TakeCase_Reporting_minister", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_consultant", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_customer", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_newOrOld", SqlDbType.VarChar,10),
					new SqlParameter("@B_TakeCase_Reporting_level", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_loyalty", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_sect", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_caseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_relCustomer", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_rival", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_project", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_plate", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_property", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_transferTarget", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_expectedReturn", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_court", SqlDbType.VarChar,50),
                    new SqlParameter("@R_TakeCase_Reporting_dept",SqlDbType.VarChar,20)};
            parameters[0].Value = model.R_TakeCase_Reporting_year;
            parameters[1].Value = model.R_TakeCase_Reporting_month;
            parameters[2].Value = model.R_TakeCase_Reporting_area;
            parameters[3].Value = model.R_TakeCase_Reporting_minister;
            parameters[4].Value = model.B_TakeCase_Reporting_consultant;
            parameters[5].Value = model.B_TakeCase_Reporting_customer;
            parameters[6].Value = model.B_TakeCase_Reporting_newOrOld;
            parameters[7].Value = model.B_TakeCase_Reporting_level;
            parameters[8].Value = model.B_TakeCase_Reporting_loyalty;
            parameters[9].Value = model.B_TakeCase_Reporting_sect;
            parameters[10].Value = model.B_TakeCase_Reporting_caseNumber;
            parameters[11].Value = model.B_TakeCase_Reporting_relCustomer;
            parameters[12].Value = model.B_TakeCase_Reporting_rival;
            parameters[13].Value = model.B_TakeCase_Reporting_project;
            parameters[14].Value = model.B_TakeCase_Reporting_plate;
            parameters[15].Value = model.B_TakeCase_Reporting_property;
            parameters[16].Value = model.B_TakeCase_Reporting_transferTarget;
            parameters[17].Value = model.B_TakeCase_Reporting_expectedReturn;
            parameters[18].Value = model.B_TakeCase_Reporting_court;
            parameters[19].Value = model.R_TakeCase_Reporting_dept;

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
        public bool Update(Model.Reporting.R_TakeCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_TakeCase_Reporting set ");
            strSql.Append("R_TakeCase_Reporting_year=@R_TakeCase_Reporting_year,");
            strSql.Append("R_TakeCase_Reporting_month=@R_TakeCase_Reporting_month,");
            strSql.Append("R_TakeCase_Reporting_area=@R_TakeCase_Reporting_area,");
            strSql.Append("R_TakeCase_Reporting_dept=@R_TakeCase_Reporting_dept,");
            strSql.Append("R_TakeCase_Reporting_minister=@R_TakeCase_Reporting_minister,");
            strSql.Append("B_TakeCase_Reporting_consultant=@B_TakeCase_Reporting_consultant,");
            strSql.Append("B_TakeCase_Reporting_customer=@B_TakeCase_Reporting_customer,");
            strSql.Append("B_TakeCase_Reporting_newOrOld=@B_TakeCase_Reporting_newOrOld,");
            strSql.Append("B_TakeCase_Reporting_level=@B_TakeCase_Reporting_level,");
            strSql.Append("B_TakeCase_Reporting_loyalty=@B_TakeCase_Reporting_loyalty,");
            strSql.Append("B_TakeCase_Reporting_sect=@B_TakeCase_Reporting_sect,");
            strSql.Append("B_TakeCase_Reporting_caseNumber=@B_TakeCase_Reporting_caseNumber,");
            strSql.Append("B_TakeCase_Reporting_relCustomer=@B_TakeCase_Reporting_relCustomer,");
            strSql.Append("B_TakeCase_Reporting_rival=@B_TakeCase_Reporting_rival,");
            strSql.Append("B_TakeCase_Reporting_project=@B_TakeCase_Reporting_project,");
            strSql.Append("B_TakeCase_Reporting_plate=@B_TakeCase_Reporting_plate,");
            strSql.Append("B_TakeCase_Reporting_property=@B_TakeCase_Reporting_property,");
            strSql.Append("B_TakeCase_Reporting_transferTarget=@B_TakeCase_Reporting_transferTarget,");
            strSql.Append("B_TakeCase_Reporting_expectedReturn=@B_TakeCase_Reporting_expectedReturn,");
            strSql.Append("B_TakeCase_Reporting_court=@B_TakeCase_Reporting_court");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@R_TakeCase_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_TakeCase_Reporting_month", SqlDbType.VarChar,5),
					new SqlParameter("@R_TakeCase_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_TakeCase_Reporting_minister", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_consultant", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_customer", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_newOrOld", SqlDbType.VarChar,10),
					new SqlParameter("@B_TakeCase_Reporting_level", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_loyalty", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_sect", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_caseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_relCustomer", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_rival", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_project", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_plate", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_property", SqlDbType.VarChar,50),
					new SqlParameter("@B_TakeCase_Reporting_transferTarget", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_expectedReturn", SqlDbType.VarChar,20),
					new SqlParameter("@B_TakeCase_Reporting_court", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@R_TakeCase_Reporting_dept",SqlDbType.VarChar,20)};
            parameters[0].Value = model.R_TakeCase_Reporting_year;
            parameters[1].Value = model.R_TakeCase_Reporting_month;
            parameters[2].Value = model.R_TakeCase_Reporting_area;
            parameters[3].Value = model.R_TakeCase_Reporting_minister;
            parameters[4].Value = model.B_TakeCase_Reporting_consultant;
            parameters[5].Value = model.B_TakeCase_Reporting_customer;
            parameters[6].Value = model.B_TakeCase_Reporting_newOrOld;
            parameters[7].Value = model.B_TakeCase_Reporting_level;
            parameters[8].Value = model.B_TakeCase_Reporting_loyalty;
            parameters[9].Value = model.B_TakeCase_Reporting_sect;
            parameters[10].Value = model.B_TakeCase_Reporting_caseNumber;
            parameters[11].Value = model.B_TakeCase_Reporting_relCustomer;
            parameters[12].Value = model.B_TakeCase_Reporting_rival;
            parameters[13].Value = model.B_TakeCase_Reporting_project;
            parameters[14].Value = model.B_TakeCase_Reporting_plate;
            parameters[15].Value = model.B_TakeCase_Reporting_property;
            parameters[16].Value = model.B_TakeCase_Reporting_transferTarget;
            parameters[17].Value = model.B_TakeCase_Reporting_expectedReturn;
            parameters[18].Value = model.B_TakeCase_Reporting_court;
            parameters[19].Value = model.ID;
            parameters[20].Value = model.R_TakeCase_Reporting_dept;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_TakeCase_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_TakeCase_Reporting ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Model.Reporting.R_TakeCase_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,R_TakeCase_Reporting_year,R_TakeCase_Reporting_month,R_TakeCase_Reporting_area,R_TakeCase_Reporting_dept,R_TakeCase_Reporting_minister,B_TakeCase_Reporting_consultant,B_TakeCase_Reporting_customer,B_TakeCase_Reporting_newOrOld,B_TakeCase_Reporting_level,B_TakeCase_Reporting_loyalty,B_TakeCase_Reporting_sect,B_TakeCase_Reporting_caseNumber,B_TakeCase_Reporting_relCustomer,B_TakeCase_Reporting_rival,B_TakeCase_Reporting_project,B_TakeCase_Reporting_plate,B_TakeCase_Reporting_property,B_TakeCase_Reporting_transferTarget,B_TakeCase_Reporting_expectedReturn,B_TakeCase_Reporting_court from R_TakeCase_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_TakeCase_Reporting model = new Model.Reporting.R_TakeCase_Reporting();
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
        public Model.Reporting.R_TakeCase_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_TakeCase_Reporting model = new Model.Reporting.R_TakeCase_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["R_TakeCase_Reporting_year"] != null)
                {
                    model.R_TakeCase_Reporting_year = row["R_TakeCase_Reporting_year"].ToString();
                }
                if (row["R_TakeCase_Reporting_month"] != null)
                {
                    model.R_TakeCase_Reporting_month = row["R_TakeCase_Reporting_month"].ToString();
                }
                if (row["R_TakeCase_Reporting_area"] != null)
                {
                    model.R_TakeCase_Reporting_area = row["R_TakeCase_Reporting_area"].ToString();
                }
                if (row["R_TakeCase_Reporting_dept"] != null)
                {
                    model.R_TakeCase_Reporting_dept = row["R_TakeCase_Reporting_dept"].ToString();
                }
                if (row["R_TakeCase_Reporting_minister"] != null)
                {
                    model.R_TakeCase_Reporting_minister = row["R_TakeCase_Reporting_minister"].ToString();
                }
                if (row["B_TakeCase_Reporting_consultant"] != null)
                {
                    model.B_TakeCase_Reporting_consultant = row["B_TakeCase_Reporting_consultant"].ToString();
                }
                if (row["B_TakeCase_Reporting_customer"] != null)
                {
                    model.B_TakeCase_Reporting_customer = row["B_TakeCase_Reporting_customer"].ToString();
                }
                if (row["B_TakeCase_Reporting_newOrOld"] != null)
                {
                    model.B_TakeCase_Reporting_newOrOld = row["B_TakeCase_Reporting_newOrOld"].ToString();
                }
                if (row["B_TakeCase_Reporting_level"] != null)
                {
                    model.B_TakeCase_Reporting_level = row["B_TakeCase_Reporting_level"].ToString();
                }
                if (row["B_TakeCase_Reporting_loyalty"] != null)
                {
                    model.B_TakeCase_Reporting_loyalty = row["B_TakeCase_Reporting_loyalty"].ToString();
                }
                if (row["B_TakeCase_Reporting_sect"] != null)
                {
                    model.B_TakeCase_Reporting_sect = row["B_TakeCase_Reporting_sect"].ToString();
                }
                if (row["B_TakeCase_Reporting_caseNumber"] != null)
                {
                    model.B_TakeCase_Reporting_caseNumber = row["B_TakeCase_Reporting_caseNumber"].ToString();
                }
                if (row["B_TakeCase_Reporting_relCustomer"] != null)
                {
                    model.B_TakeCase_Reporting_relCustomer = row["B_TakeCase_Reporting_relCustomer"].ToString();
                }
                if (row["B_TakeCase_Reporting_rival"] != null)
                {
                    model.B_TakeCase_Reporting_rival = row["B_TakeCase_Reporting_rival"].ToString();
                }
                if (row["B_TakeCase_Reporting_project"] != null)
                {
                    model.B_TakeCase_Reporting_project = row["B_TakeCase_Reporting_project"].ToString();
                }
                if (row["B_TakeCase_Reporting_plate"] != null)
                {
                    model.B_TakeCase_Reporting_plate = row["B_TakeCase_Reporting_plate"].ToString();
                }
                if (row["B_TakeCase_Reporting_property"] != null)
                {
                    model.B_TakeCase_Reporting_property = row["B_TakeCase_Reporting_property"].ToString();
                }
                if (row["B_TakeCase_Reporting_transferTarget"] != null)
                {
                    model.B_TakeCase_Reporting_transferTarget = row["B_TakeCase_Reporting_transferTarget"].ToString();
                }
                if (row["B_TakeCase_Reporting_expectedReturn"] != null)
                {
                    model.B_TakeCase_Reporting_expectedReturn = row["B_TakeCase_Reporting_expectedReturn"].ToString();
                }
                if (row["B_TakeCase_Reporting_court"] != null)
                {
                    model.B_TakeCase_Reporting_court = row["B_TakeCase_Reporting_court"].ToString();
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
            strSql.Append("select ID,R_TakeCase_Reporting_year,R_TakeCase_Reporting_month,R_TakeCase_Reporting_area,R_TakeCase_Reporting_dept,R_TakeCase_Reporting_minister,B_TakeCase_Reporting_consultant,B_TakeCase_Reporting_customer,B_TakeCase_Reporting_newOrOld,B_TakeCase_Reporting_level,B_TakeCase_Reporting_loyalty,B_TakeCase_Reporting_sect,B_TakeCase_Reporting_caseNumber,B_TakeCase_Reporting_relCustomer,B_TakeCase_Reporting_rival,B_TakeCase_Reporting_project,B_TakeCase_Reporting_plate,B_TakeCase_Reporting_property,B_TakeCase_Reporting_transferTarget,B_TakeCase_Reporting_expectedReturn,B_TakeCase_Reporting_court ");
            strSql.Append(" FROM R_TakeCase_Reporting ");
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
            strSql.Append(" ID,R_TakeCase_Reporting_year,R_TakeCase_Reporting_month,R_TakeCase_Reporting_area,R_TakeCase_Reporting_dept,R_TakeCase_Reporting_minister,B_TakeCase_Reporting_consultant,B_TakeCase_Reporting_customer,B_TakeCase_Reporting_newOrOld,B_TakeCase_Reporting_level,B_TakeCase_Reporting_loyalty,B_TakeCase_Reporting_sect,B_TakeCase_Reporting_caseNumber,B_TakeCase_Reporting_relCustomer,B_TakeCase_Reporting_rival,B_TakeCase_Reporting_project,B_TakeCase_Reporting_plate,B_TakeCase_Reporting_property,B_TakeCase_Reporting_transferTarget,B_TakeCase_Reporting_expectedReturn,B_TakeCase_Reporting_court ");
            strSql.Append(" FROM R_TakeCase_Reporting ");
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
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM R_TakeCase_Reporting ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from R_TakeCase_Reporting T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 清除表，慎重调用
        /// </summary>
        public bool Delete()
        {
            string sql = "delete from R_TakeCase_Reporting";
            int rows = DbHelperSQL.ExecuteSql(sql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            parameters[0].Value = "R_TakeCase_Reporting";
            parameters[1].Value = "ID";
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
