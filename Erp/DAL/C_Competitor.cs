using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:竞争对手表
    /// 作者：崔慧栋
    /// 日期：2015/04/23
    /// </summary>
    public partial class C_Competitor
    {
        public C_Competitor()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Competitor_id", "C_Competitor");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Competitor_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Competitor");
            strSql.Append(" where C_Competitor_id=@C_Competitor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Competitor_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

         /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(CommonService.Model.C_Competitor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Competitor");
            strSql.Append(" where C_Competitor_name=@C_Competitor_name");
            strSql.Append(" and C_Competitor_deleted=0");
            if(model.C_Competitor_id>0)
            {
                strSql.Append(" and C_Competitor_code<>@C_Competitor_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_name", SqlDbType.NVarChar),
                    new SqlParameter("@C_Competitor_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Competitor_name;
            parameters[1].Value = model.C_Competitor_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Competitor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Competitor(");
            strSql.Append("C_Competitor_code,C_Competitor_number,C_Competitor_name,C_Competitor_empNumber,C_Competitor_country,C_Competitor_area,C_Competitor_province,C_Competitor_City,C_Competitor_Address,");
            strSql.Append("C_Competitor_Url,C_Competitor_levelRisk,C_Competitor_Status,C_Competitor_mainProject,C_Competitor_advantageThat,C_Competitor_FailureMarks,C_Competitor_majorClient,");
            strSql.Append("C_Competitor_deleted,C_Competitor_cTime,C_Competitor_cUserID,C_Competitor_region)");
            strSql.Append(" values (");
            strSql.Append("@C_Competitor_code,@C_Competitor_number,@C_Competitor_name,@C_Competitor_empNumber,@C_Competitor_country,@C_Competitor_area,@C_Competitor_province,@C_Competitor_City,@C_Competitor_Address,");
            strSql.Append("@C_Competitor_Url,@C_Competitor_levelRisk,@C_Competitor_Status,@C_Competitor_mainProject,@C_Competitor_advantageThat,@C_Competitor_FailureMarks,@C_Competitor_majorClient,");
            strSql.Append("@C_Competitor_deleted,@C_Competitor_cTime,@C_Competitor_cUserID,@C_Competitor_region)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_number",SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_empNumber", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Competitor_country", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_area", SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_province", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_City", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_Address", SqlDbType.VarChar,100),
                    new SqlParameter("@C_Competitor_Url",SqlDbType.VarChar,100),
                    new SqlParameter("@C_Competitor_levelRisk",SqlDbType.VarChar,30),
                    new SqlParameter("@C_Competitor_Status",SqlDbType.Int,4),
                    new SqlParameter("@C_Competitor_mainProject",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Competitor_advantageThat",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Competitor_FailureMarks",SqlDbType.Int,4),
                    new SqlParameter("@C_Competitor_majorClient",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Competitor_deleted",SqlDbType.Int,4),
                    new SqlParameter("@C_Competitor_cTime",SqlDbType.DateTime),
                    new SqlParameter("@C_Competitor_cUserID",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_region",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Competitor_code;
            parameters[1].Value = model.C_Competitor_number;
            parameters[2].Value = model.C_Competitor_name;
            parameters[3].Value = model.C_Competitor_empNumber;
            parameters[4].Value = model.C_Competitor_country;
            parameters[5].Value = model.C_Competitor_area;
            parameters[6].Value = model.C_Competitor_province;
            parameters[7].Value = model.C_Competitor_City;
            parameters[8].Value = model.C_Competitor_Address;

            parameters[9].Value = model.C_Competitor_Url;
            parameters[10].Value = model.C_Competitor_levelRisk;
            parameters[11].Value = model.C_Competitor_Status;
            parameters[12].Value = model.C_Competitor_mainProject;
            parameters[13].Value = model.C_Competitor_advantageThat;
            parameters[14].Value = model.C_Competitor_FailureMarks;
            parameters[15].Value = model.C_Competitor_majorClient;

            parameters[16].Value = model.C_Competitor_deleted;
            parameters[17].Value = model.C_Competitor_cTime;
            parameters[18].Value = model.C_Competitor_cUserID;
            parameters[19].Value = model.C_Competitor_region;

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
        public bool Update(CommonService.Model.C_Competitor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Competitor set ");
            strSql.Append("C_Competitor_code=@C_Competitor_code,");
            strSql.Append("C_Competitor_number=@C_Competitor_number,");
            strSql.Append("C_Competitor_name=@C_Competitor_name,");
            strSql.Append("C_Competitor_empNumber=@C_Competitor_empNumber,");
            strSql.Append("C_Competitor_country=@C_Competitor_country,");
            strSql.Append("C_Competitor_area=@C_Competitor_area,");
            strSql.Append("C_Competitor_province=@C_Competitor_province,");
            strSql.Append("C_Competitor_City=@C_Competitor_City,");
            strSql.Append("C_Competitor_Address=@C_Competitor_Address,");
            strSql.Append("C_Competitor_Url=@C_Competitor_Url,");
            strSql.Append("C_Competitor_levelRisk=@C_Competitor_levelRisk,");
            strSql.Append("C_Competitor_Status=@C_Competitor_Status,");
            strSql.Append("C_Competitor_mainProject=@C_Competitor_mainProject,");
            strSql.Append("C_Competitor_advantageThat=@C_Competitor_advantageThat,");
            strSql.Append("C_Competitor_FailureMarks=@C_Competitor_FailureMarks,");
            strSql.Append("C_Competitor_majorClient=@C_Competitor_majorClient,");
            strSql.Append("C_Competitor_deleted=@C_Competitor_deleted,");
            strSql.Append("C_Competitor_cTime=@C_Competitor_cTime,");
            strSql.Append("C_Competitor_cUserID=@C_Competitor_cUserID,");
            strSql.Append("C_Competitor_region=@C_Competitor_region ");
            strSql.Append(" where C_Competitor_id=@C_Competitor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_number",SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_empNumber", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Competitor_country", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_area", SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_province", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_City", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_Address", SqlDbType.VarChar,100),
                    new SqlParameter("@C_Competitor_Url",SqlDbType.VarChar,100),
                    new SqlParameter("@C_Competitor_levelRisk",SqlDbType.VarChar,30),
                    new SqlParameter("@C_Competitor_Status",SqlDbType.Int,4),
                    new SqlParameter("@C_Competitor_mainProject",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Competitor_advantageThat",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Competitor_FailureMarks",SqlDbType.Int,4),
                    new SqlParameter("@C_Competitor_majorClient",SqlDbType.VarChar,200),
                    new SqlParameter("@C_Competitor_deleted",SqlDbType.Int,4),
                    new SqlParameter("@C_Competitor_cTime",SqlDbType.DateTime),
                    new SqlParameter("@C_Competitor_cUserID",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_region",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_id",SqlDbType.Int,4)};
            parameters[0].Value = model.C_Competitor_code;
            parameters[1].Value = model.C_Competitor_number;
            parameters[2].Value = model.C_Competitor_name;
            parameters[3].Value = model.C_Competitor_empNumber;
            parameters[4].Value = model.C_Competitor_country;
            parameters[5].Value = model.C_Competitor_area;
            parameters[6].Value = model.C_Competitor_province;
            parameters[7].Value = model.C_Competitor_City;
            parameters[8].Value = model.C_Competitor_Address;
            parameters[9].Value = model.C_Competitor_Url;
            parameters[10].Value = model.C_Competitor_levelRisk;
            parameters[11].Value = model.C_Competitor_Status;
            parameters[12].Value = model.C_Competitor_mainProject;
            parameters[13].Value = model.C_Competitor_advantageThat;
            parameters[14].Value = model.C_Competitor_FailureMarks;
            parameters[15].Value = model.C_Competitor_majorClient;
            parameters[16].Value = model.C_Competitor_deleted;
            parameters[17].Value = model.C_Competitor_cTime;
            parameters[18].Value = model.C_Competitor_cUserID;
            parameters[19].Value = model.C_Competitor_region;
            parameters[20].Value = model.C_Competitor_id;

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
        public bool Delete(Guid C_Competitor_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Competitor set C_Competitor_deleted=1");
            strSql.Append(" where C_Competitor_code=@C_Competitor_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Competitor_code;

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
        public bool DeleteList(string C_Competitor_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Competitor ");
            strSql.Append(" where C_Competitor_id in (" + C_Competitor_idlist + ")  ");
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
        public CommonService.Model.C_Competitor GetModel(int C_Competitor_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Competitor_id,C_Competitor_code,C_Competitor_number,C_Competitor_name,C_Competitor_empNumber,C_Competitor_country,C_Competitor_area,C_Competitor_province,C_Competitor_City,C_Competitor_Address,");
            strSql.Append("C_Competitor_Url,C_Competitor_levelRisk,C_Competitor_Status,C_Competitor_mainProject,C_Competitor_advantageThat,C_Competitor_FailureMarks,C_Competitor_majorClient,C_Competitor_deleted,");
            strSql.Append("C_Competitor_cTime,C_Competitor_cUserID,C_Competitor_region from C_Competitor");
            strSql.Append(" where C_Competitor_id=@C_Competitor_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Competitor_id;

            CommonService.Model.C_Competitor model = new CommonService.Model.C_Competitor();
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
        public CommonService.Model.C_Competitor GetModel(Guid C_Competitor_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C.*,U.C_Userinfo_name as 'C_Competitor_empNumber_name' ");
            strSql.Append("from C_Competitor as C left join C_Userinfo as U on C.C_Competitor_empNumber=U.C_Userinfo_code ");
            strSql.Append(" where C.C_Competitor_code=@C_Competitor_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Competitor_code;

            CommonService.Model.C_Competitor model = new CommonService.Model.C_Competitor();
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
        public CommonService.Model.C_Competitor DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Competitor model = new CommonService.Model.C_Competitor();
            if (row != null)
            {
                if (row["C_Competitor_id"] != null && row["C_Competitor_id"].ToString() != "")
                {
                    model.C_Competitor_id = int.Parse(row["C_Competitor_id"].ToString());
                }
                if (row["C_Competitor_code"] != null)
                {
                    model.C_Competitor_code = new Guid(row["C_Competitor_code"].ToString());
                }
                //if (row["C_Menu_isDelete"] != null && row["C_Menu_isDelete"].ToString() != "")
                //{
                //    if ((row["C_Menu_isDelete"].ToString() == "1") || (row["C_Menu_isDelete"].ToString().ToLower() == "true"))
                //    {
                //        model.C_Menu_isDelete = true;
                //    }
                //    else
                //    {
                //        model.C_Menu_isDelete = false;
                //    }
                //}
                if (row["C_Competitor_number"] != null)
                {
                    model.C_Competitor_number =row["C_Competitor_number"].ToString();
                }
                if (row["C_Competitor_name"] != null)
                {
                    model.C_Competitor_name =row["C_Competitor_name"].ToString();
                }
                if (row["C_Competitor_empNumber"] != null)
                {
                    model.C_Competitor_empNumber =new Guid(row["C_Competitor_empNumber"].ToString());
                }
                //判断专业顾问名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Competitor_empNumber_name"))
                {
                    if (row["C_Competitor_empNumber_name"] != null && row["C_Competitor_empNumber_name"].ToString() != "")
                    {
                        model.C_Competitor_empNumber_name = row["C_Competitor_empNumber_name"].ToString();
                    }
                }
                if (row["C_Competitor_country"] != null)
                {
                    model.C_Competitor_country = row["C_Competitor_country"].ToString();
                }
                if (row["C_Competitor_area"] != null)
                {
                    model.C_Competitor_area = row["C_Competitor_area"].ToString();
                }
                if (row["C_Competitor_province"] != null)
                {
                    model.C_Competitor_province = row["C_Competitor_province"].ToString();
                }
                if (row["C_Competitor_City"] != null)
                {
                    model.C_Competitor_City = row["C_Competitor_City"].ToString();
                }
                if (row["C_Competitor_Address"] != null)
                {
                    model.C_Competitor_Address = row["C_Competitor_Address"].ToString();
                }
                if (row["C_Competitor_Url"] != null)
                {
                    model.C_Competitor_Url = row["C_Competitor_Url"].ToString();
                }
                if (row["C_Competitor_levelRisk"] != null)
                {
                    model.C_Competitor_levelRisk = row["C_Competitor_levelRisk"].ToString();
                }
                if (row["C_Competitor_Status"] != null && row["C_Competitor_Status"].ToString() != "")
                {
                    model.C_Competitor_Status =int.Parse(row["C_Competitor_Status"].ToString());
                }
                if (row["C_Competitor_mainProject"] != null)
                {
                    model.C_Competitor_mainProject = row["C_Competitor_mainProject"].ToString();
                }
                if (row["C_Competitor_advantageThat"] != null)
                {
                    model.C_Competitor_advantageThat = row["C_Competitor_advantageThat"].ToString();
                }
                if (row["C_Competitor_FailureMarks"] != null && row["C_Competitor_FailureMarks"].ToString() != "")
                {
                    model.C_Competitor_FailureMarks = int.Parse(row["C_Competitor_FailureMarks"].ToString());
                }
                if (row["C_Competitor_majorClient"] != null)
                {
                    model.C_Competitor_majorClient = row["C_Competitor_majorClient"].ToString();
                }
                if (row["C_Competitor_deleted"] != null && row["C_Competitor_deleted"].ToString() != "")
                {
                    model.C_Competitor_deleted = int.Parse(row["C_Competitor_deleted"].ToString());
                }
                if (row["C_Competitor_cTime"] != null)
                {
                    model.C_Competitor_cTime = DateTime.Parse(row["C_Competitor_cTime"].ToString());
                }
                if (row["C_Competitor_cUserID"] != null && row["C_Competitor_cUserID"].ToString() != "")
                {
                    model.C_Competitor_cUserID = new Guid(row["C_Competitor_cUserID"].ToString());
                }
                if(row["C_Competitor_region"]!=null && row["C_Competitor_region"].ToString()!="")
                {
                    model.C_Competitor_region =new Guid(row["C_Competitor_region"].ToString());
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
            strSql.Append("select C_Competitor_id,C_Competitor_code,C_Competitor_number,C_Competitor_name,C_Competitor_empNumber,C_Competitor_country,C_Competitor_area,C_Competitor_province,C_Competitor_City,C_Competitor_Address,");
            strSql.Append("C_Competitor_Url,C_Competitor_levelRisk,C_Competitor_Status,C_Competitor_mainProject,C_Competitor_advantageThat,C_Competitor_FailureMarks,C_Competitor_majorClient,C_Competitor_deleted,");
            strSql.Append("C_Competitor_cTime,C_Competitor_cUserID,C_Competitor_region FROM C_Competitor");
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
            strSql.Append("C_Competitor_id,C_Competitor_code,C_Competitor_number,C_Competitor_name,C_Competitor_empNumber,C_Competitor_country,C_Competitor_area,C_Competitor_province,C_Competitor_City,C_Competitor_Address,");
            strSql.Append("C_Competitor_Url,C_Competitor_levelRisk,C_Competitor_Status,C_Competitor_mainProject,C_Competitor_advantageThat,C_Competitor_FailureMarks,C_Competitor_majorClient,C_Competitor_deleted,");
            strSql.Append("C_Competitor_cTime,C_Competitor_cUserID,C_Competitor_region FROM C_Competitor");
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
        public int GetRecordCount(Model.C_Competitor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Competitor ");
            strSql.Append(" where 1=1 and C_Competitor_deleted=0 ");
            if (model != null)
            {
                if (model.C_Competitor_code != null)
                {
                    strSql.Append(" and C_Competitor_code=@C_Competitor_code");
                }
                if (model.C_Competitor_name != null)
                {
                    strSql.Append(" and C_Competitor_name like N'%'+@C_Competitor_name+'%'");
                }
                if (model.C_Competitor_empNumber != null)
                {
                    strSql.Append(" and C_Competitor_empNumber=@C_Competitor_empNumber");
                }
                if (model.C_Competitor_region != null && model.C_Competitor_region != Guid.Empty)
                {
                    strSql.Append(" and C_Competitor_region=@C_Competitor_region");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_code", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_empNumber", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_region",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Competitor_code;
            parameters[1].Value = model.C_Competitor_name;
            parameters[2].Value = model.C_Competitor_empNumber;
            parameters[3].Value = model.C_Competitor_region;
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
        public DataSet GetListByPage(Model.C_Competitor model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Competitor_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Competitor T ");
            strSql.Append(" where 1=1 and C_Competitor_deleted=0 ");
            if (model != null)
            {
                if (model.C_Competitor_code != null)
                {
                    strSql.Append(" and C_Competitor_code=@C_Competitor_code");
                }
                if (model.C_Competitor_name != null)
                {
                    strSql.Append(" and C_Competitor_name like N'%'+@C_Competitor_name+'%'");
                }
                if (model.C_Competitor_empNumber != null)
                {
                    strSql.Append(" and C_Competitor_empNumber=@C_Competitor_empNumber");
                }
                if(model.C_Competitor_region!=null && model.C_Competitor_region!=Guid.Empty)
                {
                    strSql.Append(" and C_Competitor_region=@C_Competitor_region");
                }

            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Competitor_code", SqlDbType.VarChar,50),
					new SqlParameter("@C_Competitor_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Competitor_empNumber", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Competitor_region",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Competitor_code;
            parameters[1].Value = model.C_Competitor_name;
            parameters[2].Value = model.C_Competitor_empNumber;
            parameters[3].Value = model.C_Competitor_region;
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
            parameters[0].Value = "C_Menu";
            parameters[1].Value = "C_Menu_id";
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
