using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:C_Log登陆记录表
    /// 作者：陈永俊
    /// 时间：2015-06-03 14:45:20
    /// </summary>
    public partial class C_Log
    {
        public C_Log()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_id", "C_Log");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Log");
            strSql.Append(" where C_id=@C_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.SysManager.C_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Log(");
            strSql.Append("C_Log_code,C_Userinfo_post,C_Operate,C_Log_ip,C_Datatime,C_Userinfo_name,C_Userinfo_code,C_Log_Type)");
            strSql.Append(" values (");
            strSql.Append("@C_Log_code,@C_Userinfo_post,@C_Operate,@C_Log_ip,@C_Datatime,@C_Userinfo_name,@C_Userinfo_code,@C_Log_Type)");
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Log_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_post", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Operate", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Log_ip", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Datatime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_name", SqlDbType.NVarChar,100),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Log_Type",SqlDbType.Int,4)
                    };

            parameters[0].Value = new Guid(model.C_Log_code.ToString());
            parameters[1].Value = model.C_Userinfo_post;
            parameters[2].Value = model.C_Operate;
            parameters[3].Value = model.C_Log_ip;
            parameters[4].Value = model.C_Datatime;
            parameters[5].Value = model.C_Userinfo_name;
            parameters[6].Value = new Guid(model.C_Userinfo_code.ToString());
            parameters[7].Value = int.Parse(model.C_Log_Type.ToString());

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
        public bool Delete(int C_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Log ");
            strSql.Append(" where C_id=@C_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_id;

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
        public bool DeleteList(string C_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Log ");
            strSql.Append(" where C_id in (" + C_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Log GetModel(int C_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_id,C_Log_code,C_Userinfo_post,C_Operate,C_Log_ip,C_Datatime,C_Userinfo_name,C_Userinfo_code,C_Log_Type from C_Log ");
            strSql.Append(" where C_id=@C_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_id;

            CommonService.Model.SysManager.C_Log model = new CommonService.Model.SysManager.C_Log();
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
        public CommonService.Model.SysManager.C_Log DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Log model = new CommonService.Model.SysManager.C_Log();
            if (row != null)
            {
                if (row["C_id"] != null && row["C_id"].ToString() != "")
                {
                    model.C_id = int.Parse(row["C_id"].ToString());
                }
                if (row["C_Log_code"] != null && row["C_Log_code"].ToString() != "")
                {
                    model.C_Log_code = new Guid(row["C_Log_code"].ToString());
                }
                if (row["C_Userinfo_post"] != null && row["C_Userinfo_post"].ToString() != "")
                {
                    model.C_Userinfo_post = row["C_Userinfo_post"].ToString();
                }
                if (row["C_Operate"] != null)
                {
                    model.C_Operate = row["C_Operate"].ToString();
                }
                if (row["C_Log_ip"] != null)
                {
                    model.C_Log_ip = row["C_Log_ip"].ToString();
                }
                if (row["C_Datatime"] != null && row["C_Datatime"].ToString() != "")
                {
                    model.C_Datatime = DateTime.Parse(row["C_Datatime"].ToString());
                }
                if (row["C_Userinfo_name"] != null)
                {
                    model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                }
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
                {
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
                }
                if (row["C_Log_Type"] != null && row["C_Log_Type"].ToString() != "")
                {
                    model.C_Log_Type = int.Parse(row["C_Log_Type"].ToString());
                }
                if (row.Table.Columns.Contains("C_Log_Typename"))
                {
                    if (row["C_Log_Typename"] != null)
                    {
                        model.C_Log_Typename = row["C_Log_Typename"].ToString();
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
            strSql.Append("select C_id,C_Log_code,C_Userinfo_post,C_Operate,C_Log_ip,C_Datatime,C_Userinfo_name,C_Userinfo_code,C_Log_Type ");
            strSql.Append(" FROM C_Log ");
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
            strSql.Append(" C_id,C_Log_code,C_Userinfo_post,C_Operate,C_Log_ip,C_Datatime,C_Userinfo_name,C_Userinfo_code,C_Log_Type ");
            strSql.Append(" FROM C_Log ");
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
            strSql.Append("select count(1) FROM C_Log ");
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

        public DataSet GetListDate(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_id,C_Log_code,C_Userinfo_post,C_Operate,C_Log_ip,C_Datatime,C_Userinfo_name,C_Userinfo_code,C_Log_Type ");
            strSql.Append(" FROM C_Log ");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code ");
            strSql.Append(" order by C_id desc");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = guid;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
                strSql.Append("order by T.C_Datatime desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Parameters_name as C_Log_Typename from C_Log T ");
            strSql.Append(" left join C_Parameters P on P.C_Parameters_id=T.C_Log_Type ");
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
            parameters[0].Value = "C_Log";
            parameters[1].Value = "C_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  登录日志报表

        /// <summary>
        /// 根据区域统计使用人数
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportByArea(DateTime dateFrom, DateTime dateTo, string organization)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select 
                        C_Region_name as 区域,
                        (select count(DISTINCT l.C_Userinfo_code) from C_Log l where  l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");
            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }
            strSql.Append(@" )) as 登陆人数,
                        (select count(DISTINCT l.C_Userinfo_code) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_Type=973 and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");

            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }

            strSql.Append(@" )) as App人数,

                        (select count(DISTINCT l.C_Userinfo_code) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_Type=972 and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");

            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }

            strSql.Append(@" )) as PC人数,

                        (select count(DISTINCT l.C_Userinfo_code) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and (l.C_Log_Type=976 or l.C_Log_Type=979) and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");

            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }

            strSql.Append(@" )) as 云学堂人数
                        from C_Region a where C_Region_isDelete=0 ");

            SqlParameter[] parameters = {
					new SqlParameter("@dateFrom", SqlDbType.DateTime),
                    new SqlParameter("@dateTo", SqlDbType.DateTime),
                    new SqlParameter("@organization", SqlDbType.NVarChar)
                                        };
            parameters[0].Value = dateFrom;
            parameters[1].Value = dateTo;
            parameters[2].Value = organization;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据区域统计使用次数
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportByAreaCount(DateTime dateFrom, DateTime dateTo, string organization)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select 
                        C_Region_name as 区域,
                        (select count(1) from C_Log l where  l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");
            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }
            strSql.Append(@" ))) as 登陆次数,
                        (select count(1) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_Type=973 and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");

            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }

            strSql.Append(@" ))) as App次数,

                        (select count(1) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_Type=972 and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");

            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }

            strSql.Append(@" ))) as PC次数,

                        (select count(1) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and (l.C_Log_Type=976 or l.C_Log_Type=979) and l.C_Userinfo_code in(select C_Userinfo_code from C_Userinfo u right join C_Organization_post_user_region as copur on u.C_Userinfo_code=copur.C_User_code where copur.C_region_code=a.C_Region_code ");

            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(@" and copur.C_Organization_code in(select C_Organization_code from dbo.DeptTree
                        ((select top 1 C_Organization_code from C_Organization organ1 where organ1.C_Organization_Area=a.C_region_code and organ1.C_Organization_name=@organization))) ");
            }

            strSql.Append(@" ))) as 云学堂次数
                        from C_Region a where C_Region_isDelete=0 ");

            SqlParameter[] parameters = {
					new SqlParameter("@dateFrom", SqlDbType.DateTime),
                    new SqlParameter("@dateTo", SqlDbType.DateTime),
                    new SqlParameter("@organization", SqlDbType.NVarChar)
                                        };
            parameters[0].Value = dateFrom;
            parameters[1].Value = dateTo;
            parameters[2].Value = organization;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion
    }
}

