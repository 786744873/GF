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
    /// 数据访问类:R_CourtOfSecondInstanceRow_reporting
    /// </summary>
    public partial class R_CourtOfSecondInstanceRow_reporting
    {
        public R_CourtOfSecondInstanceRow_reporting()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from R_CourtOfSecondInstanceRow_reporting");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Reporting.R_CourtOfSecondInstanceRow_reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into R_CourtOfSecondInstanceRow_reporting(");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_area,R_CourtOfSecondInstanceRow_reporting_host,R_CourtOfSecondInstanceRow_reporting_co,R_CourtOfSecondInstanceRow_reporting_firstCourt,R_CourtOfSecondInstanceRow_reporting_caseNumber,R_CourtOfSecondInstanceRow_reporting_plaintiff,R_CourtOfSecondInstanceRow_reporting_otherParty,R_CourtOfSecondInstanceRow_reporting_project,R_CourtOfSecondInstanceRow_reporting_closedDate,R_CourtOfSecondInstanceRow_reporting_transferTarget,R_CourtOfSecondInstanceRow_reporting_expectedReturn,R_CourtOfSecondInstanceRow_reporting_isExtension,R_CourtOfSecondInstanceRow_reporting_extensionTime,R_CourtOfSecondInstanceRow_reporting_finishedTime,R_CourtOfSecondInstanceRow_reporting_organ,R_CourtOfSecondInstanceRow_reporting_caseCode,R_CourtOfSecondInstanceRow_reporting_mCode,R_CourtOfSecondInstanceRow_reporting_startDate,R_CourtOfSecondInstanceRow_reporting_filingTime)");
            strSql.Append(" values (");
            strSql.Append("@R_CourtOfSecondInstanceRow_reporting_area,@R_CourtOfSecondInstanceRow_reporting_host,@R_CourtOfSecondInstanceRow_reporting_co,@R_CourtOfSecondInstanceRow_reporting_firstCourt,@R_CourtOfSecondInstanceRow_reporting_caseNumber,@R_CourtOfSecondInstanceRow_reporting_plaintiff,@R_CourtOfSecondInstanceRow_reporting_otherParty,@R_CourtOfSecondInstanceRow_reporting_project,@R_CourtOfSecondInstanceRow_reporting_closedDate,@R_CourtOfSecondInstanceRow_reporting_transferTarget,@R_CourtOfSecondInstanceRow_reporting_expectedReturn,@R_CourtOfSecondInstanceRow_reporting_isExtension,@R_CourtOfSecondInstanceRow_reporting_extensionTime,@R_CourtOfSecondInstanceRow_reporting_finishedTime,@R_CourtOfSecondInstanceRow_reporting_organ,@R_CourtOfSecondInstanceRow_reporting_caseCode,@R_CourtOfSecondInstanceRow_reporting_mCode,@R_CourtOfSecondInstanceRow_reporting_startDate,@R_CourtOfSecondInstanceRow_reporting_filingTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_host", SqlDbType.VarChar,20),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_co", SqlDbType.VarChar,500),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_firstCourt", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_plaintiff", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_otherParty", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_project", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDate", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_isExtension", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_extensionTime", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_finishedTime", SqlDbType.VarChar,20),
                    new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_organ",SqlDbType.VarChar,50),
                    new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseCode",SqlDbType.VarChar,50),
                    new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_mCode",SqlDbType.VarChar,50),
                    new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_startDate",SqlDbType.VarChar,20),
                    new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_filingTime",SqlDbType.VarChar,20)
                                        };
            parameters[0].Value = model.R_CourtOfSecondInstanceRow_reporting_area;
            parameters[1].Value = model.R_CourtOfSecondInstanceRow_reporting_host;
            parameters[2].Value = model.R_CourtOfSecondInstanceRow_reporting_co;
            parameters[3].Value = model.R_CourtOfSecondInstanceRow_reporting_firstCourt;
            parameters[4].Value = model.R_CourtOfSecondInstanceRow_reporting_caseNumber;
            parameters[5].Value = model.R_CourtOfSecondInstanceRow_reporting_plaintiff;
            parameters[6].Value = model.R_CourtOfSecondInstanceRow_reporting_otherParty;
            parameters[7].Value = model.R_CourtOfSecondInstanceRow_reporting_project;
            parameters[8].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDate;
            parameters[9].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTarget;
            parameters[10].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturn;
            parameters[11].Value = model.R_CourtOfSecondInstanceRow_reporting_isExtension;
            parameters[12].Value = model.R_CourtOfSecondInstanceRow_reporting_extensionTime;
            parameters[13].Value = model.R_CourtOfSecondInstanceRow_reporting_finishedTime;
            parameters[14].Value = model.R_CourtOfSecondInstanceRow_reporting_organ;
            parameters[15].Value = model.R_CourtOfSecondInstanceRow_reporting_caseCode;
            parameters[16].Value = model.R_CourtOfSecondInstanceRow_reporting_mCode;
            parameters[17].Value = model.R_CourtOfSecondInstanceRow_reporting_startDate;
            parameters[18].Value = model.R_CourtOfSecondInstanceRow_reporting_filingTime;

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
        public bool Update(Model.Reporting.R_CourtOfSecondInstanceRow_reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update R_CourtOfSecondInstanceRow_reporting set ");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_area=@R_CourtOfSecondInstanceRow_reporting_area,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_host=@R_CourtOfSecondInstanceRow_reporting_host,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_co=@R_CourtOfSecondInstanceRow_reporting_co,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_firstCourt=@R_CourtOfSecondInstanceRow_reporting_firstCourt,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_caseNumber=@R_CourtOfSecondInstanceRow_reporting_caseNumber,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_plaintiff=@R_CourtOfSecondInstanceRow_reporting_plaintiff,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_otherParty=@R_CourtOfSecondInstanceRow_reporting_otherParty,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_project=@R_CourtOfSecondInstanceRow_reporting_project,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_closedDate=@R_CourtOfSecondInstanceRow_reporting_closedDate,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_transferTarget=@R_CourtOfSecondInstanceRow_reporting_transferTarget,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_expectedReturn=@R_CourtOfSecondInstanceRow_reporting_expectedReturn,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_isExtension=@R_CourtOfSecondInstanceRow_reporting_isExtension,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_extensionTime=@R_CourtOfSecondInstanceRow_reporting_extensionTime,");
            strSql.Append("R_CourtOfSecondInstanceRow_reporting_finishedTime=@R_CourtOfSecondInstanceRow_reporting_finishedTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_area", SqlDbType.VarChar,20),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_host", SqlDbType.VarChar,20),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_co", SqlDbType.VarChar,500),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_firstCourt", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseNumber", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_plaintiff", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_otherParty", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_project", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDate", SqlDbType.VarChar,50),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTarget", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturn", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_isExtension", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_extensionTime", SqlDbType.VarChar,10),
					new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_finishedTime", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.R_CourtOfSecondInstanceRow_reporting_area;
            parameters[1].Value = model.R_CourtOfSecondInstanceRow_reporting_host;
            parameters[2].Value = model.R_CourtOfSecondInstanceRow_reporting_co;
            parameters[3].Value = model.R_CourtOfSecondInstanceRow_reporting_firstCourt;
            parameters[4].Value = model.R_CourtOfSecondInstanceRow_reporting_caseNumber;
            parameters[5].Value = model.R_CourtOfSecondInstanceRow_reporting_plaintiff;
            parameters[6].Value = model.R_CourtOfSecondInstanceRow_reporting_otherParty;
            parameters[7].Value = model.R_CourtOfSecondInstanceRow_reporting_project;
            parameters[8].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDate;
            parameters[9].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTarget;
            parameters[10].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturn;
            parameters[11].Value = model.R_CourtOfSecondInstanceRow_reporting_isExtension;
            parameters[12].Value = model.R_CourtOfSecondInstanceRow_reporting_extensionTime;
            parameters[13].Value = model.R_CourtOfSecondInstanceRow_reporting_finishedTime;
            parameters[14].Value = model.ID;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_CourtOfSecondInstanceRow_reporting ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_CourtOfSecondInstanceRow_reporting ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Model.Reporting.R_CourtOfSecondInstanceRow_reporting GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,R_CourtOfSecondInstanceRow_reporting_area,R_CourtOfSecondInstanceRow_reporting_host,R_CourtOfSecondInstanceRow_reporting_co,R_CourtOfSecondInstanceRow_reporting_firstCourt,R_CourtOfSecondInstanceRow_reporting_caseNumber,R_CourtOfSecondInstanceRow_reporting_plaintiff,R_CourtOfSecondInstanceRow_reporting_otherParty,R_CourtOfSecondInstanceRow_reporting_project,R_CourtOfSecondInstanceRow_reporting_closedDate,R_CourtOfSecondInstanceRow_reporting_transferTarget,R_CourtOfSecondInstanceRow_reporting_expectedReturn,R_CourtOfSecondInstanceRow_reporting_isExtension,R_CourtOfSecondInstanceRow_reporting_extensionTime,R_CourtOfSecondInstanceRow_reporting_finishedTime from R_CourtOfSecondInstanceRow_reporting ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.Reporting.R_CourtOfSecondInstanceRow_reporting model = new Model.Reporting.R_CourtOfSecondInstanceRow_reporting();
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
        public Model.Reporting.R_CourtOfSecondInstanceRow_reporting DataRowToModel(DataRow row)
        {
            Model.Reporting.R_CourtOfSecondInstanceRow_reporting model = new Model.Reporting.R_CourtOfSecondInstanceRow_reporting();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.ID = int.Parse(row["id"].ToString());
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_area"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_area = row["R_CourtOfSecondInstanceRow_reporting_area"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_host"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_host = row["R_CourtOfSecondInstanceRow_reporting_host"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_co"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_co = row["R_CourtOfSecondInstanceRow_reporting_co"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_firstCourt"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_firstCourt = row["R_CourtOfSecondInstanceRow_reporting_firstCourt"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_caseNumber"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_caseNumber = row["R_CourtOfSecondInstanceRow_reporting_caseNumber"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_plaintiff"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_plaintiff = row["R_CourtOfSecondInstanceRow_reporting_plaintiff"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_otherParty"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_otherParty = row["R_CourtOfSecondInstanceRow_reporting_otherParty"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_project"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_project = row["R_CourtOfSecondInstanceRow_reporting_project"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_closedDate"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_closedDate = row["R_CourtOfSecondInstanceRow_reporting_closedDate"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_transferTarget"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_transferTarget = row["R_CourtOfSecondInstanceRow_reporting_transferTarget"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_expectedReturn"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_expectedReturn = row["R_CourtOfSecondInstanceRow_reporting_expectedReturn"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_isExtension"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_isExtension = row["R_CourtOfSecondInstanceRow_reporting_isExtension"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_extensionTime"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_extensionTime = row["R_CourtOfSecondInstanceRow_reporting_extensionTime"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_finishedTime"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_finishedTime = row["R_CourtOfSecondInstanceRow_reporting_finishedTime"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_organ"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_organ = row["R_CourtOfSecondInstanceRow_reporting_organ"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_caseCode"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_caseCode = row["R_CourtOfSecondInstanceRow_reporting_caseCode"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_mCode"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_mCode = row["R_CourtOfSecondInstanceRow_reporting_mCode"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_organName"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_organName = row["R_CourtOfSecondInstanceRow_reporting_organName"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_startDate"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_startDate = row["R_CourtOfSecondInstanceRow_reporting_startDate"].ToString();
                }
                if (row["R_CourtOfSecondInstanceRow_reporting_filingTime"] != null)
                {
                    model.R_CourtOfSecondInstanceRow_reporting_filingTime = row["R_CourtOfSecondInstanceRow_reporting_filingTime"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.V_CourtOfSecondInstanceRow_reporting DataRowToModel(DataRow row, int type)
        {
            Model.Reporting.V_CourtOfSecondInstanceRow_reporting model = new Model.Reporting.V_CourtOfSecondInstanceRow_reporting();
            if (row != null)
            {
                if (type == 1) //区域
                {
                    if (row["区域"] != null && row["区域"].ToString() != "")
                    {
                        model.统计项 = row["区域"].ToString();
                    }
                }
                else if (type == 2)
                {
                    if (row["部门"] != null && row["部门"].ToString() != "")
                    {
                        model.统计项 = row["部门"].ToString();
                    }
                }
                else if (type == 3)
                {
                    if (row["主办律师"] != null && row["主办律师"].ToString() != "")
                    {
                        model.统计项 = row["主办律师"].ToString();
                    }
                }
                else if (type == 4)
                {
                    if (row["一审管辖法院"] != null && row["一审管辖法院"].ToString() != "")
                    {
                        model.统计项 = row["一审管辖法院"].ToString();
                    }
                }
                if (row["应完成数"] != null)
                {
                    model.应完成数 = row["应完成数"].ToString();
                }
                if (row["移交标的"] != null)
                {
                    model.移交标的 = row["移交标的"].ToString();
                }
                if (row["预期收益"] != null)
                {
                    model.预期收入 = row["预期收益"].ToString();
                }
                if (row["实际完成数"] != null)
                {
                    model.实际完成数 = row["实际完成数"].ToString();
                }
                if (row["实际移交标的"] != null)
                {
                    model.实际移交标的 = row["实际移交标的"].ToString();
                }
                if (row["实际预期收益"] != null)
                {
                    model.实际预期收入 = row["实际预期收益"].ToString();
                }
                if (row["实际完成率"] != null)
                {
                    model.实际完成率 = row["实际完成率"].ToString() == "" ? "" : Convert.ToDecimal(row["实际完成率"].ToString()).ToString("0.00") + "%";
                }
                if (row["超期数"] != null)
                {
                    model.超期数 = row["超期数"].ToString();
                }
                if (row["超期移交标的"] != null)
                {
                    model.超期移交标的 = row["超期移交标的"].ToString();
                }
                if (row["预期收益"] != null)
                {
                    model.超期预期收入 = row["预期收益"].ToString();
                }
                if (row["超期率"] != null)
                {
                    model.超期率 = row["超期率"].ToString() == "" ? "" : Convert.ToDecimal(row["超期率"].ToString()).ToString("0.00") + "%";
                }
                if (row["超期总时长"] != null)
                {
                    model.超期总时长 = row["超期总时长"].ToString();
                }
                if (row["平均超期时长"] != null)
                {
                    model.平均超期时长 = row["平均超期时长"].ToString();
                }
                if (row["最长超期时长"] != null)
                {
                    model.最长超期时长 = row["最长超期时长"].ToString();
                }
                if (row["最短超期时长"] != null)
                {
                    model.最短超期时长 = row["最短超期时长"].ToString();
                }
                if (row["延期数"] != null)
                {
                    model.延期数 = row["延期数"].ToString();
                }
                if (row["延期移交标的"] != null)
                {
                    model.延期移交标的 = row["延期移交标的"].ToString();
                }
                if (row["延期预期收益"] != null)
                {
                    model.延期预期收入 = row["延期预期收益"].ToString();
                }
                //if (row["延期率"] != null)
                //{
                //    model.延期率 = row["延期率"].ToString();
                //}
                if (model.超期数 != null && model.超期数 != "" && model.超期数 != "0" && model.延期数 != null && model.延期数 != "")
                {
                    model.延期率 = (Convert.ToDecimal(model.延期数) / Convert.ToDecimal(model.超期数) * 100).ToString("0.00") + "%";
                }
                if (row["延期总时长"] != null)
                {
                    model.延期总时长 = row["延期总时长"].ToString();
                }
                if (row["平均延期时长"] != null)
                {
                    model.平均延期时长 = row["平均延期时长"].ToString();
                }
                if (row["最长延期时长"] != null)
                {
                    model.最长延期时长 = row["最长延期时长"].ToString();
                }
                if (row["最短延期时长"] != null)
                {
                    model.最短延期时长 = row["最短延期时长"].ToString();
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
            strSql.Append("select id,R_CourtOfSecondInstanceRow_reporting_area,R_CourtOfSecondInstanceRow_reporting_host,R_CourtOfSecondInstanceRow_reporting_co,R_CourtOfSecondInstanceRow_reporting_firstCourt,R_CourtOfSecondInstanceRow_reporting_caseNumber,R_CourtOfSecondInstanceRow_reporting_plaintiff,R_CourtOfSecondInstanceRow_reporting_otherParty,R_CourtOfSecondInstanceRow_reporting_project,R_CourtOfSecondInstanceRow_reporting_closedDate,R_CourtOfSecondInstanceRow_reporting_transferTarget,R_CourtOfSecondInstanceRow_reporting_expectedReturn,R_CourtOfSecondInstanceRow_reporting_isExtension,R_CourtOfSecondInstanceRow_reporting_extensionTime,R_CourtOfSecondInstanceRow_reporting_finishedTime,R_CourtOfSecondInstanceRow_reporting_organ,R_CourtOfSecondInstanceRow_reporting_caseCode,R_CourtOfSecondInstanceRow_reporting_mCode ");
            strSql.Append(" FROM R_CourtOfSecondInstanceRow_reporting ");
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
            strSql.Append(" id,R_CourtOfSecondInstanceRow_reporting_area,R_CourtOfSecondInstanceRow_reporting_host,R_CourtOfSecondInstanceRow_reporting_co,R_CourtOfSecondInstanceRow_reporting_firstCourt,R_CourtOfSecondInstanceRow_reporting_caseNumber,R_CourtOfSecondInstanceRow_reporting_plaintiff,R_CourtOfSecondInstanceRow_reporting_otherParty,R_CourtOfSecondInstanceRow_reporting_project,R_CourtOfSecondInstanceRow_reporting_closedDate,R_CourtOfSecondInstanceRow_reporting_transferTarget,R_CourtOfSecondInstanceRow_reporting_expectedReturn,R_CourtOfSecondInstanceRow_reporting_isExtension,R_CourtOfSecondInstanceRow_reporting_extensionTime,R_CourtOfSecondInstanceRow_reporting_finishedTime,R_CourtOfSecondInstanceRow_reporting_organ,R_CourtOfSecondInstanceRow_reporting_caseCode,R_CourtOfSecondInstanceRow_reporting_mCode ");
            strSql.Append(" FROM R_CourtOfSecondInstanceRow_reporting ");
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
            strSql.Append("select count(1) FROM R_CourtOfSecondInstanceRow_reporting ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from R_CourtOfSecondInstanceRow_reporting T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM R_CourtOfSecondInstanceRow_reporting where 1=1 ");

            #region 查询条件
            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_area)) //区域
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_area like N'%'+@R_CourtOfSecondInstanceRow_reporting_area+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_host)) //主办
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_host like N'%'+@R_CourtOfSecondInstanceRow_reporting_host+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_firstCourt)) //法院
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_firstCourt like N'%'+@R_CourtOfSecondInstanceRow_reporting_firstCourt+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_caseNumber)) //案号
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_caseNumber like N'%'+@R_CourtOfSecondInstanceRow_reporting_caseNumber+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_plaintiff)) //委托人
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_plaintiff like N'%'+@R_CourtOfSecondInstanceRow_reporting_plaintiff+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_otherParty)) //对方当事人
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_otherParty like N'%'+@R_CourtOfSecondInstanceRow_reporting_otherParty+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_project)) //项目
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_project like N'%'+@R_CourtOfSecondInstanceRow_reporting_project+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_organ)) //部门
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_organ in(select convert(varchar(50),C_Organization_code) from C_Organization where C_Organization_name like N'%'+@R_CourtOfSecondInstanceRow_reporting_organ+'%') ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDate)) //接案日期
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_closedDate>=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDate)");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDatez)) //接案日期至
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_closedDate<=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDatez)");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTarget)) //移交标的
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_transferTarget>=@R_CourtOfSecondInstanceRow_reporting_transferTarget");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTargetz)) //移交标的至
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_transferTarget<=@R_CourtOfSecondInstanceRow_reporting_transferTargetz");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturn)) //预期收益
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_expectedReturn>=@R_CourtOfSecondInstanceRow_reporting_expectedReturn");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz)) //预期收益至
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_expectedReturn<=@R_CourtOfSecondInstanceRow_reporting_expectedReturnz");
            }

            #endregion

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_area",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_host",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_firstCourt",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseNumber",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_plaintiff",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_otherParty",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_project",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_organ",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDate",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDatez",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTarget",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTargetz",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturn",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturnz",SqlDbType.VarChar,10)
            };
            para[0].Value = model.R_CourtOfSecondInstanceRow_reporting_area;
            para[1].Value = model.R_CourtOfSecondInstanceRow_reporting_host;
            para[2].Value = model.R_CourtOfSecondInstanceRow_reporting_firstCourt;
            para[3].Value = model.R_CourtOfSecondInstanceRow_reporting_caseNumber;
            para[4].Value = model.R_CourtOfSecondInstanceRow_reporting_plaintiff;
            para[5].Value = model.R_CourtOfSecondInstanceRow_reporting_otherParty;
            para[6].Value = model.R_CourtOfSecondInstanceRow_reporting_project;
            para[7].Value = model.R_CourtOfSecondInstanceRow_reporting_organ;
            para[8].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDate;
            para[9].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDatez;
            para[10].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTarget;
            para[11].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTargetz;
            para[12].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturn;
            para[13].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), para);
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
        public DataSet GetListByPage(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *,(select C_Organization_name from C_Organization where convert(varchar(50),C_Organization_code)=R_CourtOfSecondInstanceRow_reporting_organ) as R_CourtOfSecondInstanceRow_reporting_organName FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from R_CourtOfSecondInstanceRow_reporting T where 1=1 ");

            #region 查询条件
            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_area)) //区域
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_area like N'%'+@R_CourtOfSecondInstanceRow_reporting_area+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_host)) //主办
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_host like N'%'+@R_CourtOfSecondInstanceRow_reporting_host+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_firstCourt)) //法院
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_firstCourt like N'%'+@R_CourtOfSecondInstanceRow_reporting_firstCourt+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_caseNumber)) //案号
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_caseNumber like N'%'+@R_CourtOfSecondInstanceRow_reporting_caseNumber+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_plaintiff)) //委托人
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_plaintiff like N'%'+@R_CourtOfSecondInstanceRow_reporting_plaintiff+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_otherParty)) //对方当事人
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_otherParty like N'%'+@R_CourtOfSecondInstanceRow_reporting_otherParty+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_project)) //项目
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_project like N'%'+@R_CourtOfSecondInstanceRow_reporting_project+'%'");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_organ)) //部门
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_organ in(select convert(varchar(50),C_Organization_code) from C_Organization where C_Organization_name like N'%'+@R_CourtOfSecondInstanceRow_reporting_organ+'%') ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDate)) //接案日期
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_closedDate>=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDate)");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDatez)) //接案日期至
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_closedDate<=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDatez)");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTarget)) //移交标的
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_transferTarget>=@R_CourtOfSecondInstanceRow_reporting_transferTarget");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTargetz)) //移交标的至
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_transferTarget<=@R_CourtOfSecondInstanceRow_reporting_transferTargetz");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturn)) //预期收益
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_expectedReturn>=@R_CourtOfSecondInstanceRow_reporting_expectedReturn");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz)) //预期收益至
            {
                strSql.Append(" and R_CourtOfSecondInstanceRow_reporting_expectedReturn<=@R_CourtOfSecondInstanceRow_reporting_expectedReturnz");
            }

            #endregion

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_area",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_host",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_firstCourt",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseNumber",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_plaintiff",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_otherParty",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_project",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_organ",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDate",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDatez",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTarget",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTargetz",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturn",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturnz",SqlDbType.VarChar,10)
            };
            para[0].Value = model.R_CourtOfSecondInstanceRow_reporting_area;
            para[1].Value = model.R_CourtOfSecondInstanceRow_reporting_host;
            para[2].Value = model.R_CourtOfSecondInstanceRow_reporting_firstCourt;
            para[3].Value = model.R_CourtOfSecondInstanceRow_reporting_caseNumber;
            para[4].Value = model.R_CourtOfSecondInstanceRow_reporting_plaintiff;
            para[5].Value = model.R_CourtOfSecondInstanceRow_reporting_otherParty;
            para[6].Value = model.R_CourtOfSecondInstanceRow_reporting_project;
            para[7].Value = model.R_CourtOfSecondInstanceRow_reporting_organ;
            para[8].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDate;
            para[9].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDatez;
            para[10].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTarget;
            para[11].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTargetz;
            para[12].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturn;
            para[13].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz;
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString(), para);
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
            parameters[0].Value = "R_CourtOfSecondInstanceRow_reporting";
            parameters[1].Value = "id";
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
        /// 删除数据
        /// </summary>
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from R_CourtOfSecondInstanceRow_reporting ");
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
        /// 获取总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetDataListCount(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model, int type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select sum(tt.num) from ");
            sb.Append("(select 1 as num ");
            sb.Append("from R_CourtOfSecondInstanceRow_reporting a ");
            sb.Append("left join M_Entry_Statistics stat on stat.M_Case_number=a.R_CourtOfSecondInstanceRow_reporting_caseNumber ");
            sb.Append("left join B_Case bcase on bcase.B_Case_number=a.R_CourtOfSecondInstanceRow_reporting_caseNumber ");
            #region 四种情况下的join
            if (type == 1)
            {
                sb.Append("right join C_Region region on region.C_Region_name=a.R_CourtOfSecondInstanceRow_reporting_area and region.C_Region_isDelete=0 ");
            }
            else if (type == 2)
            {
                sb.Append("right join C_Organization organ on convert(varchar(50),organ.C_Organization_code)=a.R_CourtOfSecondInstanceRow_reporting_organ ");
            }
            else if (type == 3)
            {
                sb.Append("right join C_Userinfo cuser on cuser.C_Userinfo_name=a.R_CourtOfSecondInstanceRow_reporting_host ");
            }
            else if (type == 4)
            {
                sb.Append("right join C_Court court on court.C_Court_name=a.R_CourtOfSecondInstanceRow_reporting_firstCourt ");
            }
            #endregion

            #region 查询条件
            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_area)) //区域
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_area like N'%'+@R_CourtOfSecondInstanceRow_reporting_area+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_host)) //主办
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_host like N'%'+@R_CourtOfSecondInstanceRow_reporting_host+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_firstCourt)) //法院
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_firstCourt like N'%'+@R_CourtOfSecondInstanceRow_reporting_firstCourt+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_caseNumber)) //案号
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_caseNumber like N'%'+@R_CourtOfSecondInstanceRow_reporting_caseNumber+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_plaintiff)) //委托人
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_plaintiff like N'%'+@R_CourtOfSecondInstanceRow_reporting_plaintiff+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_otherParty)) //对方当事人
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_otherParty like N'%'+@R_CourtOfSecondInstanceRow_reporting_otherParty+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_project)) //项目
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_project like N'%'+@R_CourtOfSecondInstanceRow_reporting_project+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_organ)) //部门
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_organ = @R_CourtOfSecondInstanceRow_reporting_organ ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDate)) //接案日期
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_closedDate>=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDate) ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDatez)) //接案日期至
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_closedDate<=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDatez) ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTarget)) //移交标的
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_transferTarget>=@R_CourtOfSecondInstanceRow_reporting_transferTarget ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTargetz)) //移交标的至
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_transferTarget<=@R_CourtOfSecondInstanceRow_reporting_transferTargetz ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturn)) //预期收益
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_expectedReturn>=@R_CourtOfSecondInstanceRow_reporting_expectedReturn ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz)) //预期收益至
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_expectedReturn<=@R_CourtOfSecondInstanceRow_reporting_expectedReturnz ");
            }

            #endregion

            #region 四种情况下的where
            if (type == 1)
            {
                sb.Append("where region.C_Region_isDelete=0 ");
            }
            else if (type == 2)
            {
                sb.Append("where organ.C_Organization_isDelete=0  and organ.C_Organization_isMarketing=1");
            }
            else if (type == 3)
            {
                sb.Append("where cuser.C_Userinfo_roleID=7 and cuser.C_Userinfo_isDelete=0 and cuser.C_Userinfo_state=1 ");// and (select C_Userinfo_state from C_Userinfo where C_Userinfo_code=cuser.C_Userinfo_parent)=1 已删
            }
            else if (type == 4)
            {
                sb.Append("where court.C_Court_isdelete=0 ");
            }
            #endregion

            #region 四种情况下的group by
            sb.Append("group by ");
            if (type == 1)
            {
                sb.Append("region.C_Region_name");
                //sb.Append(" order by region.C_Region_name");
            }
            else if (type == 2)
            {
                sb.Append("organ.C_Organization_code");
                //sb.Append(" order by (select C_Organization_name from C_Organization where C_Organization_code=organ.C_Organization_code)");
            }
            else if (type == 3)
            {
                sb.Append("cuser.C_Userinfo_code");
                //sb.Append(" order by (select C_Userinfo_name from C_Userinfo where C_Userinfo_code=cuser.C_Userinfo_Code)");
            }
            else if (type == 4)
            {
                sb.Append("court.C_Court_name");
                //sb.Append(" order by court.C_Court_name");
            }
            #endregion
            sb.Append(") as tt");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_area",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_host",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_firstCourt",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseNumber",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_plaintiff",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_otherParty",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_project",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_organ",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDate",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDatez",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTarget",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTargetz",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturn",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturnz",SqlDbType.VarChar,10)
            };
            para[0].Value = model.R_CourtOfSecondInstanceRow_reporting_area;
            para[1].Value = model.R_CourtOfSecondInstanceRow_reporting_host;
            para[2].Value = model.R_CourtOfSecondInstanceRow_reporting_firstCourt;
            para[3].Value = model.R_CourtOfSecondInstanceRow_reporting_caseNumber;
            para[4].Value = model.R_CourtOfSecondInstanceRow_reporting_plaintiff;
            para[5].Value = model.R_CourtOfSecondInstanceRow_reporting_otherParty;
            para[6].Value = model.R_CourtOfSecondInstanceRow_reporting_project;
            para[7].Value = model.R_CourtOfSecondInstanceRow_reporting_organ;
            para[8].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDate;
            para[9].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDatez;
            para[10].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTarget;
            para[11].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTargetz;
            para[12].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturn;
            para[13].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz;
            object obj = DbHelperSQL.GetSingle(sb.ToString(),para);
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
        /// 类型
        /// 1、区域
        /// 2、部门
        /// 3、主办律师
        /// 4、一审管辖法院
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetDataList(CommonService.Model.Reporting.R_CourtOfSecondInstanceRow_reporting model, int type, string orderby, int startIndex, int endIndex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            if (type == 1)
            {
                sb.Append("region.C_Region_name as 区域,'' as 部门,'' as 主办律师,'' as 一审管辖法院,");
            }
            else if (type == 2)
            {
                sb.Append("'' as 区域,(select C_Organization_name from C_Organization where C_Organization_code=organ.C_Organization_code) as 部门,'' as 主办律师,'' as 一审管辖法院,");
            }
            else if (type == 3)
            {
                sb.Append("'' as 区域,'' as 部门,(select C_Userinfo_name from C_Userinfo where C_Userinfo_code=cuser.C_Userinfo_Code) as 主办律师,'' as 一审管辖法院,");
            }
            else if (type == 4)
            {
                sb.Append("'' as 区域,'' as 部门,'' as 主办律师,court.C_Court_name as 一审管辖法院,");
            }
            sb.Append("count(a.id) as 应完成数,sum(bcase.B_Case_transferTargetMoney) as 移交标的,sum(bcase.B_Case_expectedGrant) as 预期收益  ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=471 then 1 when stat.M_Entry_Statistics_HandlingState=772 then 1 when stat.M_Entry_Statistics_HandlingState=773 then 1 else 0 end)  as 实际完成数 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=471 then bcase.B_Case_transferTargetMoney when stat.M_Entry_Statistics_HandlingState=772 then bcase.B_Case_transferTargetMoney when stat.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_transferTargetMoney else 0 end) as 实际移交标的 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=471 then bcase.B_Case_expectedGrant when stat.M_Entry_Statistics_HandlingState=772 then bcase.B_Case_expectedGrant when stat.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_expectedGrant else 0 end) as 实际预期收益 ");
            sb.Append(",convert(decimal(18,2),convert(decimal(18,2),sum(Case when stat.M_Entry_Statistics_HandlingState=471 then 1 when stat.M_Entry_Statistics_HandlingState=772 then 1 when stat.M_Entry_Statistics_HandlingState=773 then 1 else 0 end))/convert(decimal(18,2),case when count(a.id)=0 then 1 else count(a.id) end)*100) as 实际完成率 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=470 then 1 when stat.M_Entry_Statistics_HandlingState=773 then 1 else 0 end)  as 超期数 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=470 then bcase.B_Case_transferTargetMoney when stat.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_transferTargetMoney else 0 end)  as 超期移交标的 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=470 then bcase.B_Case_expectedGrant when stat.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_expectedGrant else 0 end)  as 超期预期收益 ");
            sb.Append(",convert(decimal(18,2),convert(decimal(18,2),sum(Case when stat.M_Entry_Statistics_HandlingState=470 then 1 when stat.M_Entry_Statistics_HandlingState=773 then 1 else 0 end))/convert(decimal(18,2),case when count(a.id)=0 then 1 else count(a.id) end)*100) as 超期率 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_HandlingState=470 then stat.M_Entry_Statistics_Management when stat.M_Entry_Statistics_HandlingState=773 then stat.M_Entry_Statistics_Management else 0 end)*-1  as 超期总时长 ");
            sb.Append(",avg(Case when stat.M_Entry_Statistics_HandlingState=470 then stat.M_Entry_Statistics_Management when stat.M_Entry_Statistics_HandlingState=773 then stat.M_Entry_Statistics_Management end)*-1  as 平均超期时长 ");
            sb.Append(",max(Case when stat.M_Entry_Statistics_HandlingState=470 then stat.M_Entry_Statistics_Management*-1 when stat.M_Entry_Statistics_HandlingState=773 then stat.M_Entry_Statistics_Management*-1 end)  as 最长超期时长 ");
            sb.Append(",min(Case when stat.M_Entry_Statistics_HandlingState=470 then stat.M_Entry_Statistics_Management*-1 when stat.M_Entry_Statistics_HandlingState=773 then stat.M_Entry_Statistics_Management*-1 end)  as 最短超期时长 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_changeDuration is null then 0 when stat.M_Entry_Statistics_changeDuration=0 then 0 else 1 end) as 延期数 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_changeDuration is null then 0 when stat.M_Entry_Statistics_changeDuration=0 then 0 else bcase.B_Case_transferTargetMoney end) as 延期移交标的  ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_changeDuration is null then 0 when stat.M_Entry_Statistics_changeDuration=0 then 0 else bcase.B_Case_expectedGrant end) as 延期预期收益 ");
            sb.Append(",convert(decimal(18,2),convert(decimal(18,2),sum(Case when stat.M_Entry_Statistics_changeDuration is null then 0 when stat.M_Entry_Statistics_changeDuration=0 then 0 else 1 end))/convert(decimal(18,2),case when count(a.id)=0 then 1 else count(a.id) end)*100) as 延期率 ");
            sb.Append(",sum(Case when stat.M_Entry_Statistics_changeDuration is null then 0 when stat.M_Entry_Statistics_changeDuration=0 then 0 else stat.M_Entry_Statistics_changeDuration end) as 延期总时长 ");
            sb.Append(",avg(Case when stat.M_Entry_Statistics_changeDuration is not null then stat.M_Entry_Statistics_changeDuration end) as 平均延期时长 ");
            sb.Append(",max(Case when stat.M_Entry_Statistics_changeDuration is not null then stat.M_Entry_Statistics_changeDuration end) as 最长延期时长 ");
            sb.Append(",min(Case when stat.M_Entry_Statistics_changeDuration is not null then stat.M_Entry_Statistics_changeDuration end) as 最短延期时长 ");
            sb.Append("from R_CourtOfSecondInstanceRow_reporting a ");
            sb.Append("left join M_Entry_Statistics stat on stat.M_Entry_Statistics_code=a.R_CourtOfSecondInstanceRow_reporting_mCode ");
            sb.Append("left join B_Case bcase on bcase.B_Case_code=a.R_CourtOfSecondInstanceRow_reporting_caseCode ");
            #region 四种情况下的join
            if (type == 1)
            {
                sb.Append("right join C_Region region on region.C_Region_name=a.R_CourtOfSecondInstanceRow_reporting_area and region.C_Region_isDelete=0 ");
            }
            else if (type == 2)
            {
                sb.Append("right join C_Organization organ on convert(varchar(50),organ.C_Organization_code)=a.R_CourtOfSecondInstanceRow_reporting_organ ");
            }
            else if (type == 3)
            {
                sb.Append("right join C_Userinfo cuser on cuser.C_Userinfo_name=a.R_CourtOfSecondInstanceRow_reporting_host ");
            }
            else if (type == 4)
            {
                sb.Append("right join C_Court court on court.C_Court_name=a.R_CourtOfSecondInstanceRow_reporting_firstCourt ");
            }
            #endregion

            #region 查询条件
            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_area)) //区域
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_area like N'%'+@R_CourtOfSecondInstanceRow_reporting_area+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_host)) //主办
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_host like N'%'+@R_CourtOfSecondInstanceRow_reporting_host+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_firstCourt)) //法院
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_firstCourt like N'%'+@R_CourtOfSecondInstanceRow_reporting_firstCourt+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_caseNumber)) //案号
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_caseNumber like N'%'+@R_CourtOfSecondInstanceRow_reporting_caseNumber+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_plaintiff)) //委托人
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_plaintiff like N'%'+@R_CourtOfSecondInstanceRow_reporting_plaintiff+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_otherParty)) //对方当事人
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_otherParty like N'%'+@R_CourtOfSecondInstanceRow_reporting_otherParty+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_project)) //项目
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_project like N'%'+@R_CourtOfSecondInstanceRow_reporting_project+'%' ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_organ)) //部门
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_organ = @R_CourtOfSecondInstanceRow_reporting_organ ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDate)) //接案日期
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_closedDate>=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDate) ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_closedDatez)) //接案日期至
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_closedDate<=convert(datetime,@R_CourtOfSecondInstanceRow_reporting_closedDatez) ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTarget)) //移交标的
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_transferTarget>=@R_CourtOfSecondInstanceRow_reporting_transferTarget ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_transferTargetz)) //移交标的至
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_transferTarget<=@R_CourtOfSecondInstanceRow_reporting_transferTargetz ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturn)) //预期收益
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_expectedReturn>=@R_CourtOfSecondInstanceRow_reporting_expectedReturn ");
            }

            if (!string.IsNullOrEmpty(model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz)) //预期收益至
            {
                sb.Append(" and a.R_CourtOfSecondInstanceRow_reporting_expectedReturn<=@R_CourtOfSecondInstanceRow_reporting_expectedReturnz ");
            }

            #endregion

            #region 四种情况下的where
            if (type == 1)
            {
                sb.Append("where region.C_Region_isDelete=0 ");
            }
            else if (type == 2)
            {
                sb.Append("where organ.C_Organization_isDelete=0  and organ.C_Organization_isMarketing=1");
            }
            else if (type == 3)
            {
                sb.Append("where cuser.C_Userinfo_roleID=7 and cuser.C_Userinfo_isDelete=0 and cuser.C_Userinfo_state=1 ");// and (select C_Userinfo_state from C_Userinfo where C_Userinfo_code=cuser.C_Userinfo_parent)=1 已删
            }
            else if (type == 4)
            {
                sb.Append("where court.C_Court_isdelete=0 ");
            }
            #endregion

            #region 四种情况下的group by
            sb.Append("group by ");
            if (type == 1)
            {
                sb.Append("region.C_Region_name");
                sb.Append(" order by region.C_Region_name");
            }
            else if (type == 2)
            {
                sb.Append("organ.C_Organization_code");
                sb.Append(" order by (select C_Organization_name from C_Organization where C_Organization_code=organ.C_Organization_code)");
            }
            else if (type == 3)
            {
                sb.Append("cuser.C_Userinfo_code");
                sb.Append(" order by (select C_Userinfo_name from C_Userinfo where C_Userinfo_code=cuser.C_Userinfo_Code)");
            }
            else if (type == 4)
            {
                sb.Append("court.C_Court_name");
                sb.Append(" order by court.C_Court_name");
            }
            #endregion

            sb.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);


            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_area",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_host",SqlDbType.VarChar,20),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_firstCourt",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_caseNumber",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_plaintiff",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_otherParty",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_project",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_organ",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDate",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_closedDatez",SqlDbType.VarChar,500),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTarget",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_transferTargetz",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturn",SqlDbType.VarChar,10),
                new SqlParameter("@R_CourtOfSecondInstanceRow_reporting_expectedReturnz",SqlDbType.VarChar,10)
            };
            para[0].Value = model.R_CourtOfSecondInstanceRow_reporting_area;
            para[1].Value = model.R_CourtOfSecondInstanceRow_reporting_host;
            para[2].Value = model.R_CourtOfSecondInstanceRow_reporting_firstCourt;
            para[3].Value = model.R_CourtOfSecondInstanceRow_reporting_caseNumber;
            para[4].Value = model.R_CourtOfSecondInstanceRow_reporting_plaintiff;
            para[5].Value = model.R_CourtOfSecondInstanceRow_reporting_otherParty;
            para[6].Value = model.R_CourtOfSecondInstanceRow_reporting_project;
            para[7].Value = model.R_CourtOfSecondInstanceRow_reporting_organ;
            para[8].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDate;
            para[9].Value = model.R_CourtOfSecondInstanceRow_reporting_closedDatez;
            para[10].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTarget;
            para[11].Value = model.R_CourtOfSecondInstanceRow_reporting_transferTargetz;
            para[12].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturn;
            para[13].Value = model.R_CourtOfSecondInstanceRow_reporting_expectedReturnz;
            return DbHelperSQL.Query(sb.ToString(), para);
        }
        #endregion  ExtensionMethod
    }
}
