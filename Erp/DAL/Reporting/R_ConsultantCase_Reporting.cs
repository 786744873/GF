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
    /// 数据访问类:R_ConsultantCase_Reporting
    /// </summary>
    public partial class R_ConsultantCase_Reporting
    {
        public R_ConsultantCase_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_ConsultantCase_Reporting");
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
        public int Add(Model.Reporting.R_ConsultantCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_ConsultantCase_Reporting(");
            strSql.Append("R_ConsultantCase_Reporting_year,R_ConsultantCase_Reporting_month,R_ConsultantCase_Reporting_area,R_ConsultantCase_Reporting_allCount,R_ConsultantCase_Reporting_typeCount,R_ConsultantCase_Reporting_unTypeCount,R_ConsultantCase_Reporting_customerCount,R_ConsultantCase_Reporting_newCustomer,R_ConsultantCase_Reporting_oldCustomer,R_ConsultantCase_Reporting_transferTarget,R_ConsultantCase_Reporting_typeTransferTarget,R_ConsultantCase_Reporting_unTypeTransferTarget,R_ConsultantCase_Reporting_expectedReturn,R_ConsultantCase_Reporting_typeExpectedReturn,R_ConsultantCase_Reporting_unTypeExpectedReturn,R_ConsultantCase_Reporting_monthCount,R_ConsultantCase_Reporting_cCompletion,R_ConsultantCase_Reporting_nextMonthCount,R_ConsultantCase_Reporting_monthExpected,R_ConsultantCase_Reporting_eCompletion,R_ConsultantCase_Reporting_nextMonthExpected)");
            strSql.Append(" values (");
            strSql.Append("@R_ConsultantCase_Reporting_year,@R_ConsultantCase_Reporting_month,@R_ConsultantCase_Reporting_area,@R_ConsultantCase_Reporting_allCount,@R_ConsultantCase_Reporting_typeCount,@R_ConsultantCase_Reporting_unTypeCount,@R_ConsultantCase_Reporting_customerCount,@R_ConsultantCase_Reporting_newCustomer,@R_ConsultantCase_Reporting_oldCustomer,@R_ConsultantCase_Reporting_transferTarget,@R_ConsultantCase_Reporting_typeTransferTarget,@R_ConsultantCase_Reporting_unTypeTransferTarget,@R_ConsultantCase_Reporting_expectedReturn,@R_ConsultantCase_Reporting_typeExpectedReturn,@R_ConsultantCase_Reporting_unTypeExpectedReturn,@R_ConsultantCase_Reporting_monthCount,@R_ConsultantCase_Reporting_cCompletion,@R_ConsultantCase_Reporting_nextMonthCount,@R_ConsultantCase_Reporting_monthExpected,@R_ConsultantCase_Reporting_eCompletion,@R_ConsultantCase_Reporting_nextMonthExpected)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@R_ConsultantCase_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_ConsultantCase_Reporting_month", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_ConsultantCase_Reporting_allCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_typeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_unTypeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_customerCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_newCustomer", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_oldCustomer", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_transferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_typeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_unTypeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_expectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_typeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_unTypeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_monthCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_cCompletion", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_nextMonthCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_monthExpected", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_eCompletion", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_nextMonthExpected", SqlDbType.VarChar,10)};
            parameters[0].Value = model.R_ConsultantCase_Reporting_year;
            parameters[1].Value = model.R_ConsultantCase_Reporting_month;
            parameters[2].Value = model.R_ConsultantCase_Reporting_area;
            parameters[3].Value = model.R_ConsultantCase_Reporting_allCount;
            parameters[4].Value = model.R_ConsultantCase_Reporting_typeCount;
            parameters[5].Value = model.R_ConsultantCase_Reporting_unTypeCount;
            parameters[6].Value = model.R_ConsultantCase_Reporting_customerCount;
            parameters[7].Value = model.R_ConsultantCase_Reporting_newCustomer;
            parameters[8].Value = model.R_ConsultantCase_Reporting_oldCustomer;
            parameters[9].Value = model.R_ConsultantCase_Reporting_transferTarget;
            parameters[10].Value = model.R_ConsultantCase_Reporting_typeTransferTarget;
            parameters[11].Value = model.R_ConsultantCase_Reporting_unTypeTransferTarget;
            parameters[12].Value = model.R_ConsultantCase_Reporting_expectedReturn;
            parameters[13].Value = model.R_ConsultantCase_Reporting_typeExpectedReturn;
            parameters[14].Value = model.R_ConsultantCase_Reporting_unTypeExpectedReturn;
            parameters[15].Value = model.R_ConsultantCase_Reporting_monthCount;
            parameters[16].Value = model.R_ConsultantCase_Reporting_cCompletion;
            parameters[17].Value = model.R_ConsultantCase_Reporting_nextMonthCount;
            parameters[18].Value = model.R_ConsultantCase_Reporting_monthExpected;
            parameters[19].Value = model.R_ConsultantCase_Reporting_eCompletion;
            parameters[20].Value = model.R_ConsultantCase_Reporting_nextMonthExpected;

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
        public bool Update(Model.Reporting.R_ConsultantCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_ConsultantCase_Reporting set ");
            strSql.Append("R_ConsultantCase_Reporting_year=@R_ConsultantCase_Reporting_year,");
            strSql.Append("R_ConsultantCase_Reporting_month=@R_ConsultantCase_Reporting_month,");
            strSql.Append("R_ConsultantCase_Reporting_area=@R_ConsultantCase_Reporting_area,");
            strSql.Append("R_ConsultantCase_Reporting_allCount=@R_ConsultantCase_Reporting_allCount,");
            strSql.Append("R_ConsultantCase_Reporting_typeCount=@R_ConsultantCase_Reporting_typeCount,");
            strSql.Append("R_ConsultantCase_Reporting_unTypeCount=@R_ConsultantCase_Reporting_unTypeCount,");
            strSql.Append("R_ConsultantCase_Reporting_customerCount=@R_ConsultantCase_Reporting_customerCount,");
            strSql.Append("R_ConsultantCase_Reporting_newCustomer=@R_ConsultantCase_Reporting_newCustomer,");
            strSql.Append("R_ConsultantCase_Reporting_oldCustomer=@R_ConsultantCase_Reporting_oldCustomer,");
            strSql.Append("R_ConsultantCase_Reporting_transferTarget=@R_ConsultantCase_Reporting_transferTarget,");
            strSql.Append("R_ConsultantCase_Reporting_typeTransferTarget=@R_ConsultantCase_Reporting_typeTransferTarget,");
            strSql.Append("R_ConsultantCase_Reporting_unTypeTransferTarget=@R_ConsultantCase_Reporting_unTypeTransferTarget,");
            strSql.Append("R_ConsultantCase_Reporting_expectedReturn=@R_ConsultantCase_Reporting_expectedReturn,");
            strSql.Append("R_ConsultantCase_Reporting_typeExpectedReturn=@R_ConsultantCase_Reporting_typeExpectedReturn,");
            strSql.Append("R_ConsultantCase_Reporting_unTypeExpectedReturn=@R_ConsultantCase_Reporting_unTypeExpectedReturn,");
            strSql.Append("R_ConsultantCase_Reporting_monthCount=@R_ConsultantCase_Reporting_monthCount,");
            strSql.Append("R_ConsultantCase_Reporting_cCompletion=@R_ConsultantCase_Reporting_cCompletion,");
            strSql.Append("R_ConsultantCase_Reporting_nextMonthCount=@R_ConsultantCase_Reporting_nextMonthCount,");
            strSql.Append("R_ConsultantCase_Reporting_monthExpected=@R_ConsultantCase_Reporting_monthExpected,");
            strSql.Append("R_ConsultantCase_Reporting_eCompletion=@R_ConsultantCase_Reporting_eCompletion,");
            strSql.Append("R_ConsultantCase_Reporting_nextMonthExpected=@R_ConsultantCase_Reporting_nextMonthExpected");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@R_ConsultantCase_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_ConsultantCase_Reporting_month", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_ConsultantCase_Reporting_allCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_typeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_unTypeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_customerCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_newCustomer", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_oldCustomer", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_transferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_typeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_unTypeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_expectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_typeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_unTypeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_monthCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_cCompletion", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_nextMonthCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_monthExpected", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_eCompletion", SqlDbType.VarChar,10),
					new SqlParameter("@R_ConsultantCase_Reporting_nextMonthExpected", SqlDbType.VarChar,10),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.R_ConsultantCase_Reporting_year;
            parameters[1].Value = model.R_ConsultantCase_Reporting_month;
            parameters[2].Value = model.R_ConsultantCase_Reporting_area;
            parameters[3].Value = model.R_ConsultantCase_Reporting_allCount;
            parameters[4].Value = model.R_ConsultantCase_Reporting_typeCount;
            parameters[5].Value = model.R_ConsultantCase_Reporting_unTypeCount;
            parameters[6].Value = model.R_ConsultantCase_Reporting_customerCount;
            parameters[7].Value = model.R_ConsultantCase_Reporting_newCustomer;
            parameters[8].Value = model.R_ConsultantCase_Reporting_oldCustomer;
            parameters[9].Value = model.R_ConsultantCase_Reporting_transferTarget;
            parameters[10].Value = model.R_ConsultantCase_Reporting_typeTransferTarget;
            parameters[11].Value = model.R_ConsultantCase_Reporting_unTypeTransferTarget;
            parameters[12].Value = model.R_ConsultantCase_Reporting_expectedReturn;
            parameters[13].Value = model.R_ConsultantCase_Reporting_typeExpectedReturn;
            parameters[14].Value = model.R_ConsultantCase_Reporting_unTypeExpectedReturn;
            parameters[15].Value = model.R_ConsultantCase_Reporting_monthCount;
            parameters[16].Value = model.R_ConsultantCase_Reporting_cCompletion;
            parameters[17].Value = model.R_ConsultantCase_Reporting_nextMonthCount;
            parameters[18].Value = model.R_ConsultantCase_Reporting_monthExpected;
            parameters[19].Value = model.R_ConsultantCase_Reporting_eCompletion;
            parameters[20].Value = model.R_ConsultantCase_Reporting_nextMonthExpected;
            parameters[21].Value = model.ID;

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
            strSql.Append("delete from R_ConsultantCase_Reporting ");
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
            strSql.Append("delete from R_ConsultantCase_Reporting ");
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
        public Model.Reporting.R_ConsultantCase_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,R_ConsultantCase_Reporting_year,R_ConsultantCase_Reporting_month,R_ConsultantCase_Reporting_area,R_ConsultantCase_Reporting_allCount,R_ConsultantCase_Reporting_typeCount,R_ConsultantCase_Reporting_unTypeCount,R_ConsultantCase_Reporting_customerCount,R_ConsultantCase_Reporting_newCustomer,R_ConsultantCase_Reporting_oldCustomer,R_ConsultantCase_Reporting_transferTarget,R_ConsultantCase_Reporting_typeTransferTarget,R_ConsultantCase_Reporting_unTypeTransferTarget,R_ConsultantCase_Reporting_expectedReturn,R_ConsultantCase_Reporting_typeExpectedReturn,R_ConsultantCase_Reporting_unTypeExpectedReturn,R_ConsultantCase_Reporting_monthCount,R_ConsultantCase_Reporting_cCompletion,R_ConsultantCase_Reporting_nextMonthCount,R_ConsultantCase_Reporting_monthExpected,R_ConsultantCase_Reporting_eCompletion,R_ConsultantCase_Reporting_nextMonthExpected from R_ConsultantCase_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_ConsultantCase_Reporting model = new Model.Reporting.R_ConsultantCase_Reporting();
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
        public Model.Reporting.R_ConsultantCase_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_ConsultantCase_Reporting model = new Model.Reporting.R_ConsultantCase_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["R_ConsultantCase_Reporting_year"] != null)
                {
                    model.R_ConsultantCase_Reporting_year = row["R_ConsultantCase_Reporting_year"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_month"] != null)
                {
                    model.R_ConsultantCase_Reporting_month = row["R_ConsultantCase_Reporting_month"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_area"] != null)
                {
                    model.R_ConsultantCase_Reporting_area = row["R_ConsultantCase_Reporting_area"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_allCount"] != null)
                {
                    model.R_ConsultantCase_Reporting_allCount = row["R_ConsultantCase_Reporting_allCount"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_typeCount"] != null)
                {
                    model.R_ConsultantCase_Reporting_typeCount = row["R_ConsultantCase_Reporting_typeCount"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_unTypeCount"] != null)
                {
                    model.R_ConsultantCase_Reporting_unTypeCount = row["R_ConsultantCase_Reporting_unTypeCount"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_customerCount"] != null)
                {
                    model.R_ConsultantCase_Reporting_customerCount = row["R_ConsultantCase_Reporting_customerCount"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_newCustomer"] != null)
                {
                    model.R_ConsultantCase_Reporting_newCustomer = row["R_ConsultantCase_Reporting_newCustomer"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_oldCustomer"] != null)
                {
                    model.R_ConsultantCase_Reporting_oldCustomer = row["R_ConsultantCase_Reporting_oldCustomer"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_transferTarget"] != null)
                {
                    model.R_ConsultantCase_Reporting_transferTarget = row["R_ConsultantCase_Reporting_transferTarget"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_typeTransferTarget"] != null)
                {
                    model.R_ConsultantCase_Reporting_typeTransferTarget = row["R_ConsultantCase_Reporting_typeTransferTarget"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_unTypeTransferTarget"] != null)
                {
                    model.R_ConsultantCase_Reporting_unTypeTransferTarget = row["R_ConsultantCase_Reporting_unTypeTransferTarget"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_expectedReturn"] != null)
                {
                    model.R_ConsultantCase_Reporting_expectedReturn = row["R_ConsultantCase_Reporting_expectedReturn"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_typeExpectedReturn"] != null)
                {
                    model.R_ConsultantCase_Reporting_typeExpectedReturn = row["R_ConsultantCase_Reporting_typeExpectedReturn"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_unTypeExpectedReturn"] != null)
                {
                    model.R_ConsultantCase_Reporting_unTypeExpectedReturn = row["R_ConsultantCase_Reporting_unTypeExpectedReturn"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_monthCount"] != null)
                {
                    model.R_ConsultantCase_Reporting_monthCount = row["R_ConsultantCase_Reporting_monthCount"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_cCompletion"] != null)
                {
                    model.R_ConsultantCase_Reporting_cCompletion = row["R_ConsultantCase_Reporting_cCompletion"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_nextMonthCount"] != null)
                {
                    model.R_ConsultantCase_Reporting_nextMonthCount = row["R_ConsultantCase_Reporting_nextMonthCount"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_monthExpected"] != null)
                {
                    model.R_ConsultantCase_Reporting_monthExpected = row["R_ConsultantCase_Reporting_monthExpected"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_eCompletion"] != null)
                {
                    model.R_ConsultantCase_Reporting_eCompletion = row["R_ConsultantCase_Reporting_eCompletion"].ToString();
                }
                if (row["R_ConsultantCase_Reporting_nextMonthExpected"] != null)
                {
                    model.R_ConsultantCase_Reporting_nextMonthExpected = row["R_ConsultantCase_Reporting_nextMonthExpected"].ToString();
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
            strSql.Append("select ID,R_ConsultantCase_Reporting_year,R_ConsultantCase_Reporting_month,R_ConsultantCase_Reporting_area,R_ConsultantCase_Reporting_allCount,R_ConsultantCase_Reporting_typeCount,R_ConsultantCase_Reporting_unTypeCount,R_ConsultantCase_Reporting_customerCount,R_ConsultantCase_Reporting_newCustomer,R_ConsultantCase_Reporting_oldCustomer,R_ConsultantCase_Reporting_transferTarget,R_ConsultantCase_Reporting_typeTransferTarget,R_ConsultantCase_Reporting_unTypeTransferTarget,R_ConsultantCase_Reporting_expectedReturn,R_ConsultantCase_Reporting_typeExpectedReturn,R_ConsultantCase_Reporting_unTypeExpectedReturn,R_ConsultantCase_Reporting_monthCount,R_ConsultantCase_Reporting_cCompletion,R_ConsultantCase_Reporting_nextMonthCount,R_ConsultantCase_Reporting_monthExpected,R_ConsultantCase_Reporting_eCompletion,R_ConsultantCase_Reporting_nextMonthExpected ");
            strSql.Append(" FROM R_ConsultantCase_Reporting ");
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
            strSql.Append(" ID,R_ConsultantCase_Reporting_year,R_ConsultantCase_Reporting_month,R_ConsultantCase_Reporting_area,R_ConsultantCase_Reporting_allCount,R_ConsultantCase_Reporting_typeCount,R_ConsultantCase_Reporting_unTypeCount,R_ConsultantCase_Reporting_customerCount,R_ConsultantCase_Reporting_newCustomer,R_ConsultantCase_Reporting_oldCustomer,R_ConsultantCase_Reporting_transferTarget,R_ConsultantCase_Reporting_typeTransferTarget,R_ConsultantCase_Reporting_unTypeTransferTarget,R_ConsultantCase_Reporting_expectedReturn,R_ConsultantCase_Reporting_typeExpectedReturn,R_ConsultantCase_Reporting_unTypeExpectedReturn,R_ConsultantCase_Reporting_monthCount,R_ConsultantCase_Reporting_cCompletion,R_ConsultantCase_Reporting_nextMonthCount,R_ConsultantCase_Reporting_monthExpected,R_ConsultantCase_Reporting_eCompletion,R_ConsultantCase_Reporting_nextMonthExpected ");
            strSql.Append(" FROM R_ConsultantCase_Reporting ");
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
            strSql.Append("select count(1) FROM R_ConsultantCase_Reporting ");
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
            strSql.Append(")AS Row, T.*  from R_ConsultantCase_Reporting T ");
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
            parameters[0].Value = "R_ConsultantCase_Reporting";
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
        /// 获取报表
        /// </summary>
        /// <returns></returns>
        public DataSet GetReporting()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select year(a.B_Case_registerTime) as R_ConsultantCase_Reporting_year,month(a.B_Case_registerTime) as R_ConsultantCase_Reporting_month,[dbo].[GetConsultantCode](a.B_Case_code),(select C_Userinfo_name from C_Userinfo where C_Userinfo_code=[dbo].[GetConsultantCode](a.B_Case_code)) as R_ConsultantCase_Reporting_area,count(1) as R_ConsultantCase_Reporting_allCount,");
            sb.Append("(select count(1) from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and t.B_Case_nature=147) as R_ConsultantCase_Reporting_typeCount,");
            sb.Append("(select count(1) from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and t.B_Case_nature=148) as R_ConsultantCase_Reporting_unTypeCount,");
            sb.Append("(select isnull((sum(u.num)),0) from ");
            sb.Append("(select dbo.[GetCustomerCode](t.B_Case_code) as code,1 as num from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) ");
            sb.Append("and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) group by dbo.[GetCustomerCode](t.B_Case_code))");
            sb.Append(" as u) as R_ConsultantCase_Reporting_customerCount,");
            sb.Append(" (select isnull((sum(u.num)),0) from ");
            sb.Append("(select dbo.[GetCustomerCode](t.B_Case_code) as code,1 as num from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) ");
            sb.Append("and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and (select count(1) from B_Case c where ((year(c.B_Case_registerTime))+month(c.B_Case_registerTime))<(year(t.B_Case_registerTime))+month(t.B_Case_registerTime) and c.B_Case_code in(select B_Case_code from B_Case_link where C_FK_code=dbo.[GetCustomerCode](t.B_Case_code)))<=0 group by dbo.[GetCustomerCode](t.B_Case_code))");
            sb.Append(" as u) as R_ConsultantCase_Reporting_newCustomer,");
            sb.Append("  (select isnull((sum(u.num)),0) from ");
            sb.Append("(select dbo.[GetCustomerCode](t.B_Case_code) as code,1 as num from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) ");
            sb.Append("and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and (select count(1) from B_Case c where ((year(c.B_Case_registerTime))+month(c.B_Case_registerTime))<(year(t.B_Case_registerTime))+month(t.B_Case_registerTime) and c.B_Case_code in(select B_Case_code from B_Case_link where C_FK_code=dbo.[GetCustomerCode](t.B_Case_code)))>0 group by dbo.[GetCustomerCode](t.B_Case_code))");
            sb.Append(" as u) as R_ConsultantCase_Reporting_oldCustomer,");
            sb.Append(" isnull(sum(a.B_Case_transferTargetMoney),0) as R_ConsultantCase_Reporting_transferTarget,");
            sb.Append(" (select isnull(sum(t.B_Case_transferTargetMoney),0) from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and t.B_Case_nature=147) as R_ConsultantCase_Reporting_typeTransferTarget,");
            sb.Append("(select isnull(sum(t.B_Case_transferTargetMoney),0) from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and t.B_Case_nature=148) as R_ConsultantCase_Reporting_unTypeTransferTarget,");
            sb.Append(" isnull(sum(a.B_Case_expectedGrant),0) as R_ConsultantCase_Reporting_expectedReturn,");
            sb.Append(" (select isnull(sum(t.B_Case_expectedGrant),0) from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and t.B_Case_nature=147) as R_ConsultantCase_Reporting_typeExpectedReturn,");
            sb.Append("(select isnull(sum(t.B_Case_expectedGrant),0) from B_Case As t ");
            sb.Append("where year(t.B_Case_registerTime)=year(a.B_Case_registerTime) and month(t.B_Case_registerTime)=month(a.B_Case_registerTime) and [dbo].[GetConsultantCode](t.B_Case_code) =[dbo].[GetConsultantCode](a.B_Case_code) and t.B_Case_nature=148) as R_ConsultantCase_Reporting_unTypeExpectedReturn");
            sb.Append(" from B_Case a where a.B_Case_isDelete=0");
            sb.Append("group by year(a.B_Case_registerTime),month(a.B_Case_registerTime),[dbo].[GetConsultantCode](a.B_Case_code) ");
            return DbHelperSQL.Query(sb.ToString());
        }

        /// <summary>
        /// 清除表
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            string sql = "delete from R_ConsultantCase_Reporting";
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
        #endregion  ExtensionMethod
    }
}
