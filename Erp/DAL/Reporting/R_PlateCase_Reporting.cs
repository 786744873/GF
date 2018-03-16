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
    /// 数据访问类:R_PlateCase_Reporting
    /// </summary>
    public partial class R_PlateCase_Reporting
    {
        public R_PlateCase_Reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_PlateCase_Reporting");
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
        public int Add(Model.Reporting.R_PlateCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_PlateCase_Reporting(");
            strSql.Append("R_PlateCase_Reporting_year,R_PlateCase_Reporting_month,R_PlateCase_Reporting_area,R_PlateCase_Reporting_plate,R_PlateCase_Reporting_allCount,R_PlateCase_Reporting_typeCount,R_PlateCase_Reporting_unTypeCount,R_PlateCase_Reporting_transferTarget,R_PlateCase_Reporting_typeTransferTarget,R_PlateCase_Reporting_unTypeTransferTarget,R_PlateCase_Reporting_expectedReturn,R_PlateCase_Reporting_typeExpectedReturn,R_PlateCase_Reporting_unTypeExpectedReturn)");
            strSql.Append(" values (");
            strSql.Append("@R_PlateCase_Reporting_year,@R_PlateCase_Reporting_month,@R_PlateCase_Reporting_area,@R_PlateCase_Reporting_plate,@R_PlateCase_Reporting_allCount,@R_PlateCase_Reporting_typeCount,@R_PlateCase_Reporting_unTypeCount,@R_PlateCase_Reporting_transferTarget,@R_PlateCase_Reporting_typeTransferTarget,@R_PlateCase_Reporting_unTypeTransferTarget,@R_PlateCase_Reporting_expectedReturn,@R_PlateCase_Reporting_typeExpectedReturn,@R_PlateCase_Reporting_unTypeExpectedReturn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@R_PlateCase_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_PlateCase_Reporting_month", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_PlateCase_Reporting_plate", SqlDbType.VarChar,50),
					new SqlParameter("@R_PlateCase_Reporting_allCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_typeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_unTypeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_transferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_typeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_unTypeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_expectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_typeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_unTypeExpectedReturn", SqlDbType.VarChar,10)};
            parameters[0].Value = model.R_PlateCase_Reporting_year;
            parameters[1].Value = model.R_PlateCase_Reporting_month;
            parameters[2].Value = model.R_PlateCase_Reporting_area;
            parameters[3].Value = model.R_PlateCase_Reporting_plate;
            parameters[4].Value = model.R_PlateCase_Reporting_allCount;
            parameters[5].Value = model.R_PlateCase_Reporting_typeCount;
            parameters[6].Value = model.R_PlateCase_Reporting_unTypeCount;
            parameters[7].Value = model.R_PlateCase_Reporting_transferTarget;
            parameters[8].Value = model.R_PlateCase_Reporting_typeTransferTarget;
            parameters[9].Value = model.R_PlateCase_Reporting_unTypeTransferTarget;
            parameters[10].Value = model.R_PlateCase_Reporting_expectedReturn;
            parameters[11].Value = model.R_PlateCase_Reporting_typeExpectedReturn;
            parameters[12].Value = model.R_PlateCase_Reporting_unTypeExpectedReturn;

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
        public bool Update(Model.Reporting.R_PlateCase_Reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_PlateCase_Reporting set ");
            strSql.Append("R_PlateCase_Reporting_year=@R_PlateCase_Reporting_year,");
            strSql.Append("R_PlateCase_Reporting_month=@R_PlateCase_Reporting_month,");
            strSql.Append("R_PlateCase_Reporting_area=@R_PlateCase_Reporting_area,");
            strSql.Append("R_PlateCase_Reporting_plate=@R_PlateCase_Reporting_plate,");
            strSql.Append("R_PlateCase_Reporting_allCount=@R_PlateCase_Reporting_allCount,");
            strSql.Append("R_PlateCase_Reporting_typeCount=@R_PlateCase_Reporting_typeCount,");
            strSql.Append("R_PlateCase_Reporting_unTypeCount=@R_PlateCase_Reporting_unTypeCount,");
            strSql.Append("R_PlateCase_Reporting_transferTarget=@R_PlateCase_Reporting_transferTarget,");
            strSql.Append("R_PlateCase_Reporting_typeTransferTarget=@R_PlateCase_Reporting_typeTransferTarget,");
            strSql.Append("R_PlateCase_Reporting_unTypeTransferTarget=@R_PlateCase_Reporting_unTypeTransferTarget,");
            strSql.Append("R_PlateCase_Reporting_expectedReturn=@R_PlateCase_Reporting_expectedReturn,");
            strSql.Append("R_PlateCase_Reporting_typeExpectedReturn=@R_PlateCase_Reporting_typeExpectedReturn,");
            strSql.Append("R_PlateCase_Reporting_unTypeExpectedReturn=@R_PlateCase_Reporting_unTypeExpectedReturn");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@R_PlateCase_Reporting_year", SqlDbType.VarChar,20),
					new SqlParameter("@R_PlateCase_Reporting_month", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_PlateCase_Reporting_plate", SqlDbType.VarChar,50),
					new SqlParameter("@R_PlateCase_Reporting_allCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_typeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_unTypeCount", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_transferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_typeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_unTypeTransferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_expectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_typeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_PlateCase_Reporting_unTypeExpectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.R_PlateCase_Reporting_year;
            parameters[1].Value = model.R_PlateCase_Reporting_month;
            parameters[2].Value = model.R_PlateCase_Reporting_area;
            parameters[3].Value = model.R_PlateCase_Reporting_plate;
            parameters[4].Value = model.R_PlateCase_Reporting_allCount;
            parameters[5].Value = model.R_PlateCase_Reporting_typeCount;
            parameters[6].Value = model.R_PlateCase_Reporting_unTypeCount;
            parameters[7].Value = model.R_PlateCase_Reporting_transferTarget;
            parameters[8].Value = model.R_PlateCase_Reporting_typeTransferTarget;
            parameters[9].Value = model.R_PlateCase_Reporting_unTypeTransferTarget;
            parameters[10].Value = model.R_PlateCase_Reporting_expectedReturn;
            parameters[11].Value = model.R_PlateCase_Reporting_typeExpectedReturn;
            parameters[12].Value = model.R_PlateCase_Reporting_unTypeExpectedReturn;
            parameters[13].Value = model.ID;

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
            strSql.Append("delete from R_PlateCase_Reporting ");
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
            strSql.Append("delete from R_PlateCase_Reporting ");
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
        public Model.Reporting.R_PlateCase_Reporting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,R_PlateCase_Reporting_year,R_PlateCase_Reporting_month,R_PlateCase_Reporting_area,R_PlateCase_Reporting_plate,R_PlateCase_Reporting_allCount,R_PlateCase_Reporting_typeCount,R_PlateCase_Reporting_unTypeCount,R_PlateCase_Reporting_transferTarget,R_PlateCase_Reporting_typeTransferTarget,R_PlateCase_Reporting_unTypeTransferTarget,R_PlateCase_Reporting_expectedReturn,R_PlateCase_Reporting_typeExpectedReturn,R_PlateCase_Reporting_unTypeExpectedReturn from R_PlateCase_Reporting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Reporting.R_PlateCase_Reporting model = new Model.Reporting.R_PlateCase_Reporting();
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
        public Model.Reporting.R_PlateCase_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_PlateCase_Reporting model = new Model.Reporting.R_PlateCase_Reporting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["R_PlateCase_Reporting_year"] != null)
                {
                    model.R_PlateCase_Reporting_year = row["R_PlateCase_Reporting_year"].ToString();
                }
                if (row["R_PlateCase_Reporting_month"] != null)
                {
                    model.R_PlateCase_Reporting_month = row["R_PlateCase_Reporting_month"].ToString();
                }
                if (row["R_PlateCase_Reporting_area"] != null)
                {
                    model.R_PlateCase_Reporting_area = row["R_PlateCase_Reporting_area"].ToString();
                }
                if (row["R_PlateCase_Reporting_plate"] != null)
                {
                    model.R_PlateCase_Reporting_plate = row["R_PlateCase_Reporting_plate"].ToString();
                }
                if (row["R_PlateCase_Reporting_allCount"] != null)
                {
                    model.R_PlateCase_Reporting_allCount = row["R_PlateCase_Reporting_allCount"].ToString();
                }
                if (row["R_PlateCase_Reporting_typeCount"] != null)
                {
                    model.R_PlateCase_Reporting_typeCount = row["R_PlateCase_Reporting_typeCount"].ToString();
                }
                if (row["R_PlateCase_Reporting_unTypeCount"] != null)
                {
                    model.R_PlateCase_Reporting_unTypeCount = row["R_PlateCase_Reporting_unTypeCount"].ToString();
                }
                if (row["R_PlateCase_Reporting_transferTarget"] != null)
                {
                    model.R_PlateCase_Reporting_transferTarget = row["R_PlateCase_Reporting_transferTarget"].ToString();
                }
                if (row["R_PlateCase_Reporting_typeTransferTarget"] != null)
                {
                    model.R_PlateCase_Reporting_typeTransferTarget = row["R_PlateCase_Reporting_typeTransferTarget"].ToString();
                }
                if (row["R_PlateCase_Reporting_unTypeTransferTarget"] != null)
                {
                    model.R_PlateCase_Reporting_unTypeTransferTarget = row["R_PlateCase_Reporting_unTypeTransferTarget"].ToString();
                }
                if (row["R_PlateCase_Reporting_expectedReturn"] != null)
                {
                    model.R_PlateCase_Reporting_expectedReturn = row["R_PlateCase_Reporting_expectedReturn"].ToString();
                }
                if (row["R_PlateCase_Reporting_typeExpectedReturn"] != null)
                {
                    model.R_PlateCase_Reporting_typeExpectedReturn = row["R_PlateCase_Reporting_typeExpectedReturn"].ToString();
                }
                if (row["R_PlateCase_Reporting_unTypeExpectedReturn"] != null)
                {
                    model.R_PlateCase_Reporting_unTypeExpectedReturn = row["R_PlateCase_Reporting_unTypeExpectedReturn"].ToString();
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
            strSql.Append("select ID,R_PlateCase_Reporting_year,R_PlateCase_Reporting_month,R_PlateCase_Reporting_area,R_PlateCase_Reporting_plate,R_PlateCase_Reporting_allCount,R_PlateCase_Reporting_typeCount,R_PlateCase_Reporting_unTypeCount,R_PlateCase_Reporting_transferTarget,R_PlateCase_Reporting_typeTransferTarget,R_PlateCase_Reporting_unTypeTransferTarget,R_PlateCase_Reporting_expectedReturn,R_PlateCase_Reporting_typeExpectedReturn,R_PlateCase_Reporting_unTypeExpectedReturn ");
            strSql.Append(" FROM R_PlateCase_Reporting ");
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
            strSql.Append(" ID,R_PlateCase_Reporting_year,R_PlateCase_Reporting_month,R_PlateCase_Reporting_area,R_PlateCase_Reporting_plate,R_PlateCase_Reporting_allCount,R_PlateCase_Reporting_typeCount,R_PlateCase_Reporting_unTypeCount,R_PlateCase_Reporting_transferTarget,R_PlateCase_Reporting_typeTransferTarget,R_PlateCase_Reporting_unTypeTransferTarget,R_PlateCase_Reporting_expectedReturn,R_PlateCase_Reporting_typeExpectedReturn,R_PlateCase_Reporting_unTypeExpectedReturn ");
            strSql.Append(" FROM R_PlateCase_Reporting ");
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
            strSql.Append("select count(1) FROM R_PlateCase_Reporting ");
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
            strSql.Append(")AS Row, T.*  from R_PlateCase_Reporting T ");
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
            parameters[0].Value = "R_PlateCase_Reporting";
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
