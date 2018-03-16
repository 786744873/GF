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
    /// 登录日志统计报表
    /// 陈盼盼  2016/1/15
    /// </summary>
    public partial class R_SystemLog_Reporting
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.R_SystemLog_Reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_SystemLog_Reporting model = new Model.Reporting.R_SystemLog_Reporting();
            if (row != null)
            {
                if (row.Table.Columns.Contains("Area"))
                {
                    if (row["Area"] != null)
                    {
                        model.Area = row["Area"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("Organization"))
                {
                    if (row["Organization"] != null)
                    {
                        model.Organization = row["Organization"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("Userinfo"))
                {
                    if (row["Userinfo"] != null)
                    {
                        model.Userinfo = row["Userinfo"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("TotalTimes"))
                {
                    if (row["TotalTimes"] != null)
                    {
                        model.TotalTimes = Convert.ToInt32(row["TotalTimes"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("TotalDays"))
                {
                    if (row["TotalDays"] != null)
                    {
                        model.TotalDays = Convert.ToInt32(row["TotalDays"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("AppTotalTimes"))
                {
                    if (row["AppTotalTimes"] != null)
                    {
                        model.AppTotalTimes = Convert.ToInt32(row["AppTotalTimes"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("AppTotalDays"))
                {
                    if (row["AppTotalDays"] != null)
                    {
                        model.AppTotalDays = Convert.ToInt32(row["AppTotalDays"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("PCTotalTimes"))
                {
                    if (row["PCTotalTimes"] != null)
                    {
                        model.PCTotalTimes = Convert.ToInt32(row["PCTotalTimes"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("PCTotalDays"))
                {
                    if (row["PCTotalDays"] != null)
                    {
                        model.PCTotalDays = Convert.ToInt32(row["PCTotalDays"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("KmsTotalTimes"))
                {
                    if (row["KmsTotalTimes"] != null)
                    {
                        model.KmsTotalTimes = Convert.ToInt32(row["KmsTotalTimes"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("KmsTotalDays"))
                {
                    if (row["KmsTotalDays"] != null)
                    {
                        model.KmsTotalDays = Convert.ToInt32(row["KmsTotalDays"].ToString());
                    }
                }

            }
            return model;
        }

        /// <summary>
        /// 根据人员统计列表数量(默认去掉 IP为 114.66.197.35的数据) and l.C_Log_ip <> '114.66.197.35'
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public int GetReportByUserCount(DateTime dateFrom, DateTime dateTo, string organization, string userName, string area)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select count(1) from (select 
                            (select C_region_name from C_region where C_Region_code=(select top 1 C_region_code from C_Organization_post_user_region as copur where copur.C_User_code=u.C_Userinfo_code))  
                            as Area,
                            (select C_Organization_name from C_Organization where C_Organization_code=(select top 1 C_Organization_code from C_Organization_post_user b where C_User_code=u.C_Userinfo_code)) as Organization
                            ,C_Userinfo_name as Userinfo
                            ,(select count(1) from C_log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code) as TotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code) as TotalDays
                            ,(select count(1) from C_Log l where l.C_Userinfo_code=u.C_Userinfo_code and l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_type=973) as AppTotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code and l.C_Log_type=973) as AppTotalDays
                            ,(select count(1) from C_Log l where l.C_Userinfo_code=u.C_Userinfo_code and l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_type=972) as PCTotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code and l.C_Log_type=972) as PCTotalDays
                            ,(select count(1) from C_Log l where l.C_Userinfo_code=u.C_Userinfo_code and l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and (l.C_Log_type=976 or l.C_Log_type=979)) as KmsTotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code and (l.C_Log_type=976 or l.C_Log_type=979)) as KmsTotalDays
                             from C_Userinfo u 
                             where C_Userinfo_isDelete=0 and C_Userinfo_state=1 and C_Userinfo_name<>'管理员') as baobiao where 1=1 ");
            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(" and baobiao.Organization like '%" + organization + "%' ");
            }
            if (!string.IsNullOrEmpty(userName))
            {
                strSql.Append(" and baobiao.Userinfo like '%" + userName + "%' ");
            }
            if (!string.IsNullOrEmpty(area))
            {
                strSql.Append(" and baobiao.Area=@area ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@dateFrom", SqlDbType.DateTime),
                    new SqlParameter("@dateTo", SqlDbType.DateTime),
                    new SqlParameter("@organization", SqlDbType.NVarChar),
                    new SqlParameter("@userName", SqlDbType.NVarChar),
                    new SqlParameter("@area", SqlDbType.NVarChar)
                                        };
            parameters[0].Value = dateFrom;
            parameters[1].Value = dateTo;
            parameters[2].Value = organization;
            parameters[3].Value = userName;
            parameters[4].Value = area;
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
        /// 根据人员统计系统使用情况
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public DataSet GetReportByUser(DateTime dateFrom, DateTime dateTo, string organization, string userName, string area, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (order by baobiao.TotalDays desc)AS Row, * from (select 
                            (select C_region_name from C_region where C_Region_code=(select top 1 C_region_code from C_Organization_post_user_region as copur where copur.C_User_code=u.C_Userinfo_code)) 
                            as Area,
                            (select C_Organization_name from C_Organization where C_Organization_code=(select top 1 C_Organization_code from C_Organization_post_user b where C_User_code=u.C_Userinfo_code)) as Organization
                            ,C_Userinfo_name as Userinfo
                            ,(select count(1) from C_log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code) as TotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code) as TotalDays
                            ,(select count(1) from C_Log l where l.C_Userinfo_code=u.C_Userinfo_code and l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_type=973) as AppTotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code and l.C_Log_type=973) as AppTotalDays
                            ,(select count(1) from C_Log l where l.C_Userinfo_code=u.C_Userinfo_code and l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Log_type=972) as PCTotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code and l.C_Log_type=972) as PCTotalDays
                            ,(select count(1) from C_Log l where l.C_Userinfo_code=u.C_Userinfo_code and l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and (l.C_Log_type=976 or l.C_Log_type=979)) as KmsTotalTimes
                            ,(select count(distinct convert(varchar(10),C_datatime,120)) from C_Log l where l.C_Datatime>=@dateFrom and l.C_Datatime<=@dateTo and l.C_Userinfo_code=u.C_Userinfo_code and (l.C_Log_type=976 or l.C_Log_type=979)) as KmsTotalDays
                             from C_Userinfo u 
                             where C_Userinfo_isDelete=0 and C_Userinfo_state=1 and C_Userinfo_name<>'管理员') as baobiao where 1=1 ");
            if (!string.IsNullOrEmpty(organization))
            {
                strSql.Append(" and baobiao.Organization like '%" + organization + "%' ");
            }
            if (!string.IsNullOrEmpty(userName))
            {
                strSql.Append(" and baobiao.Userinfo like '%" + userName + "%' ");
            }
            if (!string.IsNullOrEmpty(area))
            {
                strSql.Append(" and baobiao.Area=@area ");
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@dateFrom", SqlDbType.DateTime),
                    new SqlParameter("@dateTo", SqlDbType.DateTime),
                    new SqlParameter("@organization", SqlDbType.NVarChar),
                    new SqlParameter("@userName", SqlDbType.NVarChar),
                    new SqlParameter("@area", SqlDbType.NVarChar)
                                        };
            parameters[0].Value = dateFrom;
            parameters[1].Value = dateTo;
            parameters[2].Value = organization;
            parameters[3].Value = userName;
            parameters[4].Value = area;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

    }
}
