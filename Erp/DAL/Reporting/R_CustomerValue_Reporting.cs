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
    /// 数据访问类:R_CustomerValue_Reporting
    /// </summary>
    public partial class R_CustomerValue_Reporting
    {
        public R_CustomerValue_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_CustomerValue_Reporting");
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
        public int Add(Model.Reporting.R_CustomerValue_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_CustomerValue_Reporting(");
            strSql.Append("R_CustomerValue_Reporting_year,R_CustomerValue_Reporting_month,R_CustomerValue_Reporting_area,R_CustomerValue_Reporting_customerName,R_CustomerValue_Reporting_type,R_CustomerValue_Reporting_newOrOld,R_CustomerValue_Reporting_sect,R_CustomerValue_Reporting_level,R_CustomerValue_Reporting_loyalty,R_CustomerValue_Reporting_fTakeTime,R_CustomerValue_Reporting_nTakeTime,R_CustomerValue_Reporting_monthTakeCount,R_CustomerValue_Reporting_monthExpected,R_CustomerValue_Reporting_takeCount,R_CustomerValue_Reporting_Expected)");
            strSql.Append(" values (");
            strSql.Append("@R_CustomerValue_Reporting_year,@R_CustomerValue_Reporting_month,@R_CustomerValue_Reporting_area,@R_CustomerValue_Reporting_customerName,@R_CustomerValue_Reporting_type,@R_CustomerValue_Reporting_newOrOld,@R_CustomerValue_Reporting_sect,@R_CustomerValue_Reporting_level,@R_CustomerValue_Reporting_loyalty,@R_CustomerValue_Reporting_fTakeTime,@R_CustomerValue_Reporting_nTakeTime,@R_CustomerValue_Reporting_monthTakeCount,@R_CustomerValue_Reporting_monthExpected,@R_CustomerValue_Reporting_takeCount,@R_CustomerValue_Reporting_Expected)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@R_CustomerValue_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_month", SqlDbType.NChar,5),
					new SqlParameter("@R_CustomerValue_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_customerName", SqlDbType.VarChar,50),
					new SqlParameter("@R_CustomerValue_Reporting_type", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_newOrOld", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_sect", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_level", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_loyalty", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_fTakeTime", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_nTakeTime", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_monthTakeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_monthExpected", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_takeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_Expected", SqlDbType.VarChar,10)};
            parameters[0].Value = model.R_CustomerValue_Reporting_year;
            parameters[1].Value = model.R_CustomerValue_Reporting_month;
            parameters[2].Value = model.R_CustomerValue_Reporting_area;
            parameters[3].Value = model.R_CustomerValue_Reporting_customerName;
            parameters[4].Value = model.R_CustomerValue_Reporting_type;
            parameters[5].Value = model.R_CustomerValue_Reporting_newOrOld;
            parameters[6].Value = model.R_CustomerValue_Reporting_sect;
            parameters[7].Value = model.R_CustomerValue_Reporting_level;
            parameters[8].Value = model.R_CustomerValue_Reporting_loyalty;
            parameters[9].Value = model.R_CustomerValue_Reporting_fTakeTime;
            parameters[10].Value = model.R_CustomerValue_Reporting_nTakeTime;
            parameters[11].Value = model.R_CustomerValue_Reporting_monthTakeCount;
            parameters[12].Value = model.R_CustomerValue_Reporting_monthExpected;
            parameters[13].Value = model.R_CustomerValue_Reporting_takeCount;
            parameters[14].Value = model.R_CustomerValue_Reporting_Expected;

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
        public bool Update(Model.Reporting.R_CustomerValue_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_CustomerValue_Reporting set ");
            strSql.Append("R_CustomerValue_Reporting_year=@R_CustomerValue_Reporting_year,");
            strSql.Append("R_CustomerValue_Reporting_month=@R_CustomerValue_Reporting_month,");
            strSql.Append("R_CustomerValue_Reporting_area=@R_CustomerValue_Reporting_area,");
            strSql.Append("R_CustomerValue_Reporting_customerName=@R_CustomerValue_Reporting_customerName,");
            strSql.Append("R_CustomerValue_Reporting_type=@R_CustomerValue_Reporting_type,");
            strSql.Append("R_CustomerValue_Reporting_newOrOld=@R_CustomerValue_Reporting_newOrOld,");
            strSql.Append("R_CustomerValue_Reporting_sect=@R_CustomerValue_Reporting_sect,");
            strSql.Append("R_CustomerValue_Reporting_level=@R_CustomerValue_Reporting_level,");
            strSql.Append("R_CustomerValue_Reporting_loyalty=@R_CustomerValue_Reporting_loyalty,");
            strSql.Append("R_CustomerValue_Reporting_fTakeTime=@R_CustomerValue_Reporting_fTakeTime,");
            strSql.Append("R_CustomerValue_Reporting_nTakeTime=@R_CustomerValue_Reporting_nTakeTime,");
            strSql.Append("R_CustomerValue_Reporting_monthTakeCount=@R_CustomerValue_Reporting_monthTakeCount,");
            strSql.Append("R_CustomerValue_Reporting_monthExpected=@R_CustomerValue_Reporting_monthExpected,");
            strSql.Append("R_CustomerValue_Reporting_takeCount=@R_CustomerValue_Reporting_takeCount,");
            strSql.Append("R_CustomerValue_Reporting_Expected=@R_CustomerValue_Reporting_Expected");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@R_CustomerValue_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_month", SqlDbType.NChar,5),
					new SqlParameter("@R_CustomerValue_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_customerName", SqlDbType.VarChar,50),
					new SqlParameter("@R_CustomerValue_Reporting_type", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_newOrOld", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_sect", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_level", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_loyalty", SqlDbType.VarChar,20),
					new SqlParameter("@R_CustomerValue_Reporting_fTakeTime", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_nTakeTime", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_monthTakeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_monthExpected", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_takeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_CustomerValue_Reporting_Expected", SqlDbType.VarChar,10),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.R_CustomerValue_Reporting_year;
            parameters[1].Value = model.R_CustomerValue_Reporting_month;
            parameters[2].Value = model.R_CustomerValue_Reporting_area;
            parameters[3].Value = model.R_CustomerValue_Reporting_customerName;
            parameters[4].Value = model.R_CustomerValue_Reporting_type;
            parameters[5].Value = model.R_CustomerValue_Reporting_newOrOld;
            parameters[6].Value = model.R_CustomerValue_Reporting_sect;
            parameters[7].Value = model.R_CustomerValue_Reporting_level;
            parameters[8].Value = model.R_CustomerValue_Reporting_loyalty;
            parameters[9].Value = model.R_CustomerValue_Reporting_fTakeTime;
            parameters[10].Value = model.R_CustomerValue_Reporting_nTakeTime;
            parameters[11].Value = model.R_CustomerValue_Reporting_monthTakeCount;
            parameters[12].Value = model.R_CustomerValue_Reporting_monthExpected;
            parameters[13].Value = model.R_CustomerValue_Reporting_takeCount;
            parameters[14].Value = model.R_CustomerValue_Reporting_Expected;
            parameters[15].Value = model.ID;

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
            strSql.Append("delete from R_CustomerValue_Reporting ");
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
            strSql.Append("delete from R_CustomerValue_Reporting ");
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
        public Model.Reporting.R_CustomerValue_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,R_CustomerValue_Reporting_year,R_CustomerValue_Reporting_month,R_CustomerValue_Reporting_area,R_CustomerValue_Reporting_customerName,R_CustomerValue_Reporting_type,R_CustomerValue_Reporting_newOrOld,R_CustomerValue_Reporting_sect,R_CustomerValue_Reporting_level,R_CustomerValue_Reporting_loyalty,R_CustomerValue_Reporting_fTakeTime,R_CustomerValue_Reporting_nTakeTime,R_CustomerValue_Reporting_monthTakeCount,R_CustomerValue_Reporting_monthExpected,R_CustomerValue_Reporting_takeCount,R_CustomerValue_Reporting_Expected from R_CustomerValue_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_CustomerValue_Reporting model = new Model.Reporting.R_CustomerValue_Reporting();
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
        public Model.Reporting.R_CustomerValue_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_CustomerValue_Reporting model = new Model.Reporting.R_CustomerValue_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["R_CustomerValue_Reporting_year"] != null)
                {
                    model.R_CustomerValue_Reporting_year = row["R_CustomerValue_Reporting_year"].ToString();
                }
                if (row["R_CustomerValue_Reporting_month"] != null)
                {
                    model.R_CustomerValue_Reporting_month = row["R_CustomerValue_Reporting_month"].ToString();
                }
                if (row["R_CustomerValue_Reporting_area"] != null)
                {
                    model.R_CustomerValue_Reporting_area = row["R_CustomerValue_Reporting_area"].ToString();
                }
                if (row["R_CustomerValue_Reporting_customerName"] != null)
                {
                    model.R_CustomerValue_Reporting_customerName = row["R_CustomerValue_Reporting_customerName"].ToString();
                }
                if (row["R_CustomerValue_Reporting_type"] != null)
                {
                    model.R_CustomerValue_Reporting_type = row["R_CustomerValue_Reporting_type"].ToString();
                }
                if (row["R_CustomerValue_Reporting_newOrOld"] != null)
                {
                    model.R_CustomerValue_Reporting_newOrOld = row["R_CustomerValue_Reporting_newOrOld"].ToString();
                }
                if (row["R_CustomerValue_Reporting_sect"] != null)
                {
                    model.R_CustomerValue_Reporting_sect = row["R_CustomerValue_Reporting_sect"].ToString();
                }
                if (row["R_CustomerValue_Reporting_level"] != null)
                {
                    model.R_CustomerValue_Reporting_level = row["R_CustomerValue_Reporting_level"].ToString();
                }
                if (row["R_CustomerValue_Reporting_loyalty"] != null)
                {
                    model.R_CustomerValue_Reporting_loyalty = row["R_CustomerValue_Reporting_loyalty"].ToString();
                }
                if (row["R_CustomerValue_Reporting_fTakeTime"] != null)
                {
                    model.R_CustomerValue_Reporting_fTakeTime = row["R_CustomerValue_Reporting_fTakeTime"].ToString();
                }
                if (row["R_CustomerValue_Reporting_nTakeTime"] != null)
                {
                    model.R_CustomerValue_Reporting_nTakeTime = row["R_CustomerValue_Reporting_nTakeTime"].ToString();
                }
                if (row["R_CustomerValue_Reporting_monthTakeCount"] != null)
                {
                    model.R_CustomerValue_Reporting_monthTakeCount = row["R_CustomerValue_Reporting_monthTakeCount"].ToString();
                }
                if (row["R_CustomerValue_Reporting_monthExpected"] != null)
                {
                    model.R_CustomerValue_Reporting_monthExpected = row["R_CustomerValue_Reporting_monthExpected"].ToString();
                }
                if (row["R_CustomerValue_Reporting_takeCount"] != null)
                {
                    model.R_CustomerValue_Reporting_takeCount = row["R_CustomerValue_Reporting_takeCount"].ToString();
                }
                if (row["R_CustomerValue_Reporting_Expected"] != null)
                {
                    model.R_CustomerValue_Reporting_Expected = row["R_CustomerValue_Reporting_Expected"].ToString();
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
            strSql.Append("select ID,R_CustomerValue_Reporting_year,R_CustomerValue_Reporting_month,R_CustomerValue_Reporting_area,R_CustomerValue_Reporting_customerName,R_CustomerValue_Reporting_type,R_CustomerValue_Reporting_newOrOld,R_CustomerValue_Reporting_sect,R_CustomerValue_Reporting_level,R_CustomerValue_Reporting_loyalty,R_CustomerValue_Reporting_fTakeTime,R_CustomerValue_Reporting_nTakeTime,R_CustomerValue_Reporting_monthTakeCount,R_CustomerValue_Reporting_monthExpected,R_CustomerValue_Reporting_takeCount,R_CustomerValue_Reporting_Expected ");
            strSql.Append(" FROM R_CustomerValue_Reporting ");
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
            strSql.Append(" ID,R_CustomerValue_Reporting_year,R_CustomerValue_Reporting_month,R_CustomerValue_Reporting_area,R_CustomerValue_Reporting_customerName,R_CustomerValue_Reporting_type,R_CustomerValue_Reporting_newOrOld,R_CustomerValue_Reporting_sect,R_CustomerValue_Reporting_level,R_CustomerValue_Reporting_loyalty,R_CustomerValue_Reporting_fTakeTime,R_CustomerValue_Reporting_nTakeTime,R_CustomerValue_Reporting_monthTakeCount,R_CustomerValue_Reporting_monthExpected,R_CustomerValue_Reporting_takeCount,R_CustomerValue_Reporting_Expected ");
            strSql.Append(" FROM R_CustomerValue_Reporting ");
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
            strSql.Append("select count(1) FROM R_CustomerValue_Reporting ");
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
            strSql.Append(")AS Row, T.*  from R_CustomerValue_Reporting T ");
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
            parameters[0].Value = "R_CustomerValue_Reporting";
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
        /// <summary>
        /// 清理表
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string sql = "delete from R_CustomerValue_Reporting";
            object obj = DbHelperSQL.GetSingle(sql);
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
        /// 获取报表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetCustomerReporting()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select year(a.B_Case_registerTime) as R_CustomerValue_Reporting_year,month(a.B_Case_registerTime) as R_CustomerValue_Reporting_month,[dbo].[GetAreaCode](a.B_Case_code),(select C_Region_name from C_Region where C_Region_code=[dbo].[GetAreaCode](a.B_Case_code)) as R_CustomerValue_Reporting_area,dbo.[GetCustomerCode](a.B_Case_code)");
            sb.Append(",(select C_Customer_name from C_Customer where C_customer_code=dbo.[GetCustomerCode](a.B_Case_code)) as R_CustomerValue_Reporting_customerName");
            sb.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=(select C_Customer_industryCode from C_Customer where C_Customer_code=dbo.[GetCustomerCode](a.B_Case_code))) as R_CustomerValue_Reporting_type");
            sb.Append(",(select count(1) from B_Case k where (year(k.B_Case_registerTime)+month(k.B_Case_registerTime))<(year(a.B_Case_registerTime)+month(a.B_Case_registerTime)) and k.B_Case_code in(select l.B_Case_code from B_Case_link l where l.C_FK_code=[dbo].[GetCustomerCode](a.B_Case_code) and l.B_Case_link_type=0 and l.B_Case_link_isDelete=0)) as R_CustomerValue_Reporting_newOrOld");
            sb.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=(select C_Customer_level from C_Customer where C_Customer_code=dbo.[GetCustomerCode](a.B_Case_code))) as R_CustomerValue_Reporting_level");
            sb.Append(",(select C_Parameters_name from C_Parameters where C_Parameters_id=(select C_Customer_loyalty from C_Customer where C_Customer_code=dbo.[GetCustomerCode](a.B_Case_code))) as R_CustomerValue_Reporting_loyalty");
            sb.Append(",(select top 1 B_Case_registerTime from B_Case where B_Case_code in (select B_Case_code from B_Case_link where C_FK_code=dbo.[GetCustomerCode](a.B_Case_code) and B_Case_link_type=0) order by B_Case_registerTime) as R_CustomerValue_Reporting_fTakeTime");
            sb.Append(",(select top 1 B_Case_registerTime from B_Case where B_Case_code in (select B_Case_code from B_Case_link where C_FK_code=dbo.[GetCustomerCode](a.B_Case_code) and B_Case_link_type=0) order by B_Case_registerTime desc) as R_CustomerValue_Reporting_nTakeTime");
            sb.Append(",count(1) as R_CustomerValue_Reporting_monthTakeCount");
            sb.Append(",sum(B_Case_expectedGrant) as R_CustomerValue_Reporting_monthExpected");
            sb.Append(",(select count(1) from B_Case h where h.B_Case_code in(select l.B_Case_code from B_Case_link l where l.C_FK_code=[dbo].[GetCustomerCode](a.B_Case_code) and l.B_Case_link_type=0 and l.B_Case_link_isDelete=0)) as R_CustomerValue_Reporting_takeCount");
            sb.Append(",(select sum(B_Case_expectedGrant) from B_Case h where h.B_Case_code in(select l.B_Case_code from B_Case_link l where l.C_FK_code=[dbo].[GetCustomerCode](a.B_Case_code) and l.B_Case_link_type=0 and l.B_Case_link_isDelete=0)) as R_CustomerValue_Reporting_Expected");
            sb.Append("from B_Case a where a.B_Case_isDelete=0");
            sb.Append("group by year(a.B_Case_registerTime),month(a.B_Case_registerTime),[dbo].[GetAreaCode](a.B_Case_code),dbo.[GetCustomerCode](a.B_Case_code)");
            return DbHelperSQL.Query(sb.ToString());
        }
        #endregion  ExtensionMethod
    }
}
