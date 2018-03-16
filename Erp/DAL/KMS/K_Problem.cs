using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:问题表
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Problem
    {
        public K_Problem()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("K_Problem_id", "K_Problem");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Problem_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Problem");
            strSql.Append(" where K_Problem_id=@K_Problem_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Problem_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Problem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Problem(");
            strSql.Append("K_Problem_code,K_Problem_content,K_Problem_statue,K_Problem_createTime,K_Problem_creator,K_Problem_isDelete,K_Problem_auditStatue,K_Problem_browseCount)");
            strSql.Append(" values (");
            strSql.Append("@K_Problem_code,@K_Problem_content,@K_Problem_statue,@K_Problem_createTime,@K_Problem_creator,@K_Problem_isDelete,@K_Problem_auditStatue,@K_Problem_browseCount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Problem_content", SqlDbType.Text),
					new SqlParameter("@K_Problem_statue", SqlDbType.Int,4),
					new SqlParameter("@K_Problem_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Problem_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Problem_isDelete", SqlDbType.Bit,1),
                    new SqlParameter("@K_Problem_auditStatue",SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_browseCount",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.K_Problem_code;
            parameters[1].Value = model.K_Problem_content;
            parameters[2].Value = model.K_Problem_statue;
            parameters[3].Value = model.K_Problem_createTime;
            parameters[4].Value = model.K_Problem_creator;
            parameters[5].Value = model.K_Problem_isDelete;
            parameters[6].Value = model.K_Problem_auditStatue;
            parameters[7].Value = model.K_Problem_browseCount;

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
        public bool Update(CommonService.Model.KMS.K_Problem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Problem set ");
            strSql.Append("K_Problem_code=@K_Problem_code,");
            strSql.Append("K_Problem_content=@K_Problem_content,");
            strSql.Append("K_Problem_statue=@K_Problem_statue,");
            strSql.Append("K_Problem_createTime=@K_Problem_createTime,");
            strSql.Append("K_Problem_creator=@K_Problem_creator,");
            strSql.Append("K_Problem_isDelete=@K_Problem_isDelete,");
            strSql.Append("K_Problem_auditStatue=@K_Problem_auditStatue,");
            strSql.Append("K_Problem_browseCount=@K_Problem_browseCount ");
            strSql.Append(" where K_Problem_id=@K_Problem_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Problem_content", SqlDbType.Text),
					new SqlParameter("@K_Problem_statue", SqlDbType.Int,4),
					new SqlParameter("@K_Problem_createTime", SqlDbType.DateTime),
					new SqlParameter("@K_Problem_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Problem_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Problem_id", SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_auditStatue",SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_browseCount",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.K_Problem_code;
            parameters[1].Value = model.K_Problem_content;
            parameters[2].Value = model.K_Problem_statue;
            parameters[3].Value = model.K_Problem_createTime;
            parameters[4].Value = model.K_Problem_creator;
            parameters[5].Value = model.K_Problem_isDelete;
            parameters[6].Value = model.K_Problem_id;
            parameters[7].Value = model.K_Problem_auditStatue;
            parameters[8].Value = model.K_Problem_browseCount;

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
        public bool Delete(Guid K_Problem_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Problem set K_Problem_isDelete=1 ");
            strSql.Append(" where K_Problem_code=@K_Problem_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Problem_code;

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
        /// 问题审核
        /// </summary>
        public bool ProblemAudit(Guid problemCode, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Problem set ");
            strSql.Append("K_Problem_auditStatue=@K_Problem_auditStatue ");
            strSql.Append(" where K_Problem_code=@K_Problem_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Problem_auditStatue",SqlDbType.Int,4)
			};
            parameters[0].Value = problemCode;
            parameters[1].Value = state;

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
        public bool DeleteList(string K_Problem_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Problem set K_Problem_isDelete=1 ");
            strSql.Append(" where K_Problem_code in (" + K_Problem_idlist + ")  ");
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
        public CommonService.Model.KMS.K_Problem GetModel(int K_Problem_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Problem_id,K_Problem_code,K_Problem_content,K_Problem_statue,K_Problem_createTime,K_Problem_creator,K_Problem_isDelete,K_Problem_auditStatue,K_Problem_browseCount,dbo.getBrowseCountByUser(K_Problem_code) as 'K_Browse_LogCount' from K_Problem ");
            strSql.Append(" where K_Problem_id=@K_Problem_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_Problem_id;

            CommonService.Model.KMS.K_Problem model = new CommonService.Model.KMS.K_Problem();
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
        public CommonService.Model.KMS.K_Problem GetModel(Guid K_Problem_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Problem_id,K_Problem_code,K_Problem_content,K_Problem_statue,K_Problem_createTime,K_Problem_creator,K_Problem_isDelete,K_Problem_auditStatue,K_Problem_browseCount,dbo.getBrowseCountByUser(K_Problem_code) as 'K_Browse_LogCount',P.C_Parameters_name as 'K_Problem_statueName',U.C_Userinfo_name as 'K_Problem_creatorName',P1.C_Parameters_name as 'K_Problem_auditStatueName' from K_Problem ");
            strSql.Append(" left join C_Parameters as P on K_Problem_statue=P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on K_Problem_creator=U.C_Userinfo_code ");
            strSql.Append(" left join C_Parameters as P1 on K_Problem_auditStatue=P1.C_Parameters_id ");
            strSql.Append(" where K_Problem_isDelete=0 ");
            strSql.Append(" and K_Problem_code=@K_Problem_code");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = K_Problem_code;

            CommonService.Model.KMS.K_Problem model = new CommonService.Model.KMS.K_Problem();
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
        public CommonService.Model.KMS.K_Problem DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Problem model = new CommonService.Model.KMS.K_Problem();
            if (row != null)
            {
                if (row["K_Problem_id"] != null && row["K_Problem_id"].ToString() != "")
                {
                    model.K_Problem_id = int.Parse(row["K_Problem_id"].ToString());
                }
                if (row["K_Problem_code"] != null && row["K_Problem_code"].ToString() != "")
                {
                    model.K_Problem_code = new Guid(row["K_Problem_code"].ToString());
                }
                if (row["K_Problem_content"] != null)
                {
                    model.K_Problem_content = row["K_Problem_content"].ToString();
                }
                if (row["K_Problem_statue"] != null && row["K_Problem_statue"].ToString() != "")
                {
                    model.K_Problem_statue = int.Parse(row["K_Problem_statue"].ToString());
                }
                if (row["K_Problem_createTime"] != null && row["K_Problem_createTime"].ToString() != "")
                {
                    model.K_Problem_createTime = DateTime.Parse(row["K_Problem_createTime"].ToString());
                }
                if (row["K_Problem_creator"] != null && row["K_Problem_creator"].ToString() != "")
                {
                    model.K_Problem_creator = new Guid(row["K_Problem_creator"].ToString());
                }
                if (row["K_Problem_isDelete"] != null && row["K_Problem_isDelete"].ToString() != "")
                {
                    if ((row["K_Problem_isDelete"].ToString() == "1") || (row["K_Problem_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Problem_isDelete = true;
                    }
                    else
                    {
                        model.K_Problem_isDelete = false;
                    }
                }
                if (row.Table.Columns.Contains("K_Problem_statueName"))
                {
                    if (row["K_Problem_statueName"] != null && row["K_Problem_statueName"].ToString() != "")
                    {
                        model.K_Problem_statueName = row["K_Problem_statueName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Problem_creatorName"))
                {
                    if (row["K_Problem_creatorName"] != null && row["K_Problem_creatorName"].ToString() != "")
                    {
                        model.K_Problem_creatorName = row["K_Problem_creatorName"].ToString();
                    }
                }
                if (row["K_Problem_auditStatue"] != null && row["K_Problem_auditStatue"].ToString() != "")
                {
                    model.K_Problem_auditStatue = Convert.ToInt32(row["K_Problem_auditStatue"].ToString());
                }
                if (row.Table.Columns.Contains("K_Problem_auditStatueName"))
                {
                    if (row["K_Problem_auditStatueName"] != null && row["K_Problem_auditStatueName"].ToString() != "")
                    {
                        model.K_Problem_auditStatueName = row["K_Problem_auditStatueName"].ToString();
                    }
                }
                if (row["K_Problem_browseCount"] != null && row["K_Problem_browseCount"].ToString() != "")
                {
                    model.K_Problem_browseCount = Convert.ToInt32(row["K_Problem_browseCount"].ToString());
                }
                if (row.Table.Columns.Contains("K_Problem_Knowledge_code"))
                {
                    if (row["K_Problem_Knowledge_code"] != null && row["K_Problem_Knowledge_code"].ToString() != "")
                    {
                        model.K_Problem_Knowledge_code = new Guid(row["K_Problem_Knowledge_code"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Problem_Knowledge_name"))
                {
                    if (row["K_Problem_Knowledge_name"] != null && row["K_Problem_Knowledge_name"].ToString() != "")
                    {
                        model.K_Problem_Knowledge_name = row["K_Problem_Knowledge_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("K_Problem_AnswerCount"))
                {
                    if (row["K_Problem_AnswerCount"] != null && row["K_Problem_AnswerCount"].ToString() != "")
                    {
                        model.K_Problem_AnswerCount = Convert.ToInt32(row["K_Problem_AnswerCount"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Problem_Knowledge_person"))
                {
                    if (row["K_Problem_Knowledge_person"] != null && row["K_Problem_Knowledge_person"].ToString() != "")
                    {
                        model.K_Problem_Knowledge_person = new Guid(row["K_Problem_Knowledge_person"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("K_Browse_LogCount"))
                {
                    if (row["K_Browse_LogCount"] != null && row["K_Browse_LogCount"].ToString() != "")
                    {
                        model.K_Browse_LogCount = Convert.ToInt32(row["K_Browse_LogCount"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("P_Flow_name"))
                {
                    if (row["P_Flow_name"] != null && row["P_Flow_name"].ToString() != "")
                    {
                        model.P_Flow_name = row["P_Flow_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("F_Form_chineseName"))
                {
                    if (row["F_Form_chineseName"] != null && row["F_Form_chineseName"].ToString() != "")
                    {
                        model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
                    }
                }
            }
            return model;
        }
        /// <summary>
        /// 获取热门问题
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByBrowseCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 5 K_Problem_id,K_Problem_code,K_Problem_content,K_Problem_statue,K_Problem_createTime,K_Problem_creator,K_Problem_isDelete,K_Problem_auditStatue,K_Problem_browseCount,dbo.getBrowseCountByUser(K_Problem_code) as 'K_Browse_LogCount' ");
            strSql.Append(" FROM K_Problem ");
            strSql.Append(" where K_Problem_isDelete=0 and K_Problem_auditStatue=883 order by dbo.getBrowseCountByUser(K_Problem_code) desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Problem_id,K_Problem_code,K_Problem_content,K_Problem_statue,K_Problem_createTime,K_Problem_creator,K_Problem_isDelete,K_Problem_auditStatue,K_Problem_browseCount,dbo.getBrowseCountByUser(K_Problem_code) as 'K_Browse_LogCount',e.P_Flow_name as P_Flow_name,e.F_Form_chineseName as F_Form_chineseName ");
            strSql.Append(" FROM K_Problem as a");
            strSql.Append(" left join (select b.C_FK_code as C_FK_code,c.P_Flow_name as P_Flow_name,d.F_Form_chineseName as F_Form_chineseName from K_PorblemAndResources_LinkCase as b ");
            strSql.Append(" left join P_Flow as c on b.K_ProblemAndResources_LinkCase_BusinessFlowcode=c.P_Flow_code");
            strSql.Append(" left join F_Form as d on b.K_ProblemAndResources_LinkCase_Formcode=d.F_Form_code) as e on a.K_Problem_code=e.C_FK_code");
            strSql.Append(" where K_Problem_isDelete=0 and K_Problem_auditStatue=883");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据code集合获得数据列表
        /// </summary>
        public DataSet GetListByCodeList(string codeList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.*,dbo.getBrowseCountByUser(T.K_Problem_code) as 'K_Browse_LogCount',P.C_Parameters_name as 'K_Problem_statueName',U.C_Userinfo_name as 'K_Problem_creatorName',P1.C_Parameters_name as 'K_Problem_auditStatueName',K.K_Knowledge_name as 'K_Problem_Knowledge_name',K.K_Knowledge_code as 'K_Problem_Knowledge_code',C1.K_Problem_AnswerCount ");
            strSql.Append(" FROM K_Problem T");
            strSql.Append(" left join C_Parameters as P on T.K_Problem_statue=P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on T.K_Problem_creator=U.C_Userinfo_code ");
            strSql.Append(" left join C_Parameters as P1 on T.K_Problem_auditStatue=P1.C_Parameters_id ");
            strSql.Append(" left join K_Knowledge_Resources as KP on T.K_Problem_code=KP.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KP.K_Knowledge_code=K.K_Knowledge_code ");
            strSql.Append(" left join (select count(1) as 'K_Problem_AnswerCount',P_FK_code from K_Comments as C group by P_FK_code) as C1 on T.K_Problem_code=C1.P_FK_code ");
            strSql.Append(" where 1=1 and T.K_Problem_isDelete=0 and P.C_Parameters_isDelete=0 and P1.C_Parameters_isDelete=0 and T.K_Problem_code in (" + codeList + ") ");
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
            strSql.Append(" K_Problem_id,K_Problem_code,K_Problem_content,K_Problem_statue,K_Problem_createTime,K_Problem_creator,K_Problem_isDelete,K_Problem_auditStatue,K_Problem_browseCount,dbo.getBrowseCountByUser(K_Problem_code) as 'K_Browse_LogCount' ");
            strSql.Append(" FROM K_Problem ");
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
        public int GetRecordCount(CommonService.Model.KMS.K_Problem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Problem as T ");
            strSql.Append(" left join K_Knowledge_Resources as KP on T.K_Problem_code=KP.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KP.K_Knowledge_code=K.K_Knowledge_code ");
            strSql.Append(" where 1=1 and K_Problem_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Problem_content != null && model.K_Problem_content.ToString() != "")
                {
                    strSql.Append(" and cast(K_Problem_content as nvarchar) like N'%'+@K_Problem_content+'%' ");
                }
                if (model.K_Problem_statue != null && model.K_Problem_statue.ToString() != "" && model.K_Problem_statue != 840)
                {
                    strSql.Append(" and K_Problem_statue=@K_Problem_statue ");
                }
                if (model.K_Problem_auditStatue != null && model.K_Problem_auditStatue.ToString() != "")
                {
                    strSql.Append(" and K_Problem_auditStatue=@K_Problem_auditStatue ");
                }
                if (model.K_Problem_codeItems != null && model.K_Problem_codeItems != "")
                {
                    strSql.Append(" and ltrim(K_Problem_code) in (" + model.K_Problem_codeItems + ") ");
                }
                if (model.K_Problem_creator != null && model.K_Problem_creator.ToString() != "")
                {
                    strSql.Append(" and K_Problem_creator=@K_Problem_creator ");
                }
                if (model.K_Problem_statue != null && model.K_Problem_statue.ToString() != "" && model.K_Problem_statue == 840)
                {//已回答问题
                    strSql.Append(" and Exists(select * from K_Comments as C where K_Problem_code=C.P_FK_code and C.K_Comments_isDelete=0)");
                }
                if (model.K_Problem_Knowledge_code != null)
                {
                    strSql.Append(" and (KP.K_Knowledge_code=@K_Knowledge_code or K.K_Knowledge_parent=@K_Knowledge_code) ");
                    //strSql.Append(" and KP.K_Knowledge_code=@K_Knowledge_code ");
                }
                if (model.K_Problem_Knowledge_person != null && model.K_Problem_Knowledge_person.ToString() != "")
                {
                    strSql.Append(" and K.K_Knowledge_Person=@K_Knowledge_Person ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_statue", SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_content",SqlDbType.NVarChar),
                    new SqlParameter("@K_Problem_auditStatue",SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Knowledge_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Knowledge_Person",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.K_Problem_statue;
            parameters[1].Value = model.K_Problem_content;
            parameters[2].Value = model.K_Problem_auditStatue;
            parameters[3].Value = model.K_Problem_creator;
            parameters[4].Value = model.K_Problem_Knowledge_code;
            parameters[5].Value = model.K_Problem_Knowledge_person;
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
        public DataSet GetListByPage(CommonService.Model.KMS.K_Problem model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.K_Problem_id desc");
            }
            strSql.Append(")AS Row, T.*,dbo.getBrowseCountByUser(T.K_Problem_code) as 'K_Browse_LogCount',P.C_Parameters_name as 'K_Problem_statueName',U.C_Userinfo_name as 'K_Problem_creatorName',P1.C_Parameters_name as 'K_Problem_auditStatueName',K.K_Knowledge_name as 'K_Problem_Knowledge_name',K.K_Knowledge_code as 'K_Problem_Knowledge_code',C1.K_Problem_AnswerCount  from K_Problem T ");
            strSql.Append(" left join C_Parameters as P on T.K_Problem_statue=P.C_Parameters_id ");
            strSql.Append(" left join C_Userinfo as U on T.K_Problem_creator=U.C_Userinfo_code ");
            strSql.Append(" left join C_Parameters as P1 on T.K_Problem_auditStatue=P1.C_Parameters_id ");
            strSql.Append(" left join K_Knowledge_Resources as KP on T.K_Problem_code=KP.P_FK_code ");
            strSql.Append(" left join K_Knowledge as K on KP.K_Knowledge_code=K.K_Knowledge_code ");
            strSql.Append(" left join (select count(1) as 'K_Problem_AnswerCount',P_FK_code from K_Comments as C group by P_FK_code) as C1 on T.K_Problem_code=C1.P_FK_code ");
            strSql.Append(" where 1=1 and T.K_Problem_isDelete=0 and P.C_Parameters_isDelete=0 and P1.C_Parameters_isDelete=0 ");
            if (model != null)
            {
                if (model.K_Problem_content != null && model.K_Problem_content.ToString() != "")
                {
                    strSql.Append(" and cast(K_Problem_content as nvarchar) like N'%'+@K_Problem_content+'%' ");
                }
                if (model.K_Problem_statue != null && model.K_Problem_statue.ToString() != "")
                {
                    strSql.Append(" and K_Problem_statue=@K_Problem_statue ");
                }
                if (model.K_Problem_auditStatue != null && model.K_Problem_auditStatue.ToString() != "")
                {
                    strSql.Append(" and K_Problem_auditStatue=@K_Problem_auditStatue ");
                }
                if (model.K_Problem_creator != null && model.K_Problem_creator.ToString() != "")
                {
                    strSql.Append(" and K_Problem_creator=@K_Problem_creator ");
                }
                if (model.K_Problem_codeItems != null && model.K_Problem_codeItems != "")
                {
                    strSql.Append(" and ltrim(T.K_Problem_code) in (" + model.K_Problem_codeItems + ") ");
                }
                if (model.K_Problem_statue != null && model.K_Problem_statue.ToString() != "" && model.K_Problem_statue == 840)
                {//已回答问题
                    strSql.Append(" and Exists(select * from K_Comments as C where K_Problem_code=C.P_FK_code and C.K_Comments_isDelete=0)");
                }
                if (model.K_Problem_Knowledge_code != null && model.K_Problem_Knowledge_code.ToString() != "")
                {
                    strSql.Append(" and (KP.K_Knowledge_code=@K_Knowledge_code or K.K_Knowledge_parent=@K_Knowledge_code) ");
                }
                if (model.K_Problem_Knowledge_person != null && model.K_Problem_Knowledge_person.ToString() != "")
                {
                    strSql.Append(" and K.K_Knowledge_Person=@K_Knowledge_Person ");
                }
            }
            strSql.Append("  ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1} ", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_statue", SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_content",SqlDbType.NVarChar),
                    new SqlParameter("@K_Problem_auditStatue",SqlDbType.Int,4),
                    new SqlParameter("@K_Problem_creator",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Knowledge_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_Knowledge_Person",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.K_Problem_statue;
            parameters[1].Value = model.K_Problem_content;
            parameters[2].Value = model.K_Problem_auditStatue;
            parameters[3].Value = model.K_Problem_creator;
            parameters[4].Value = model.K_Problem_Knowledge_code;
            parameters[5].Value = model.K_Problem_Knowledge_person;
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
            parameters[0].Value = "K_Problem";
            parameters[1].Value = "K_Problem_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        public int GetRecordCountByMonth(CommonService.Model.KMS.K_Problem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM K_Problem ");
            strSql.Append(" where 1=1 and K_Problem_isDelete=0 and datediff(Month,K_Problem_createTime,getdate())=0");
            if (model != null)
            {
                if (model.K_Problem_statue != null && model.K_Problem_statue.ToString() != "")
                {
                    strSql.Append(" and K_Problem_statue=@K_Problem_statue ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@K_Problem_statue", SqlDbType.Int,4)};
            parameters[0].Value = model.K_Problem_statue;
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
        /// 获得所有要查询的数据列表
        /// </summary>
        /// <param name="Top">查询前几条数据，为空时默认查询所有</param>
        /// <param name="strWhere">查询条件，可为空</param>
        /// <param name="filedOrder">数据排序，可为空</param>
        /// <returns>数据列表</returns>
        public DataSet GetSearchList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" T.K_Problem_id,T.K_Problem_code,T.K_Problem_content,T.K_Problem_statue,T.K_Problem_createTime,T.K_Problem_creator,T.K_Problem_isDelete,T.K_Problem_auditStatue,T.K_Problem_browseCount,dbo.getBrowseCountByUser(T.K_Problem_code) as 'K_Browse_LogCount',C1.K_Problem_AnswerCount ");
            strSql.Append(" FROM K_Problem as T ");
            strSql.Append(" left join (select count(1) as 'K_Problem_AnswerCount',P.K_Problem_code from K_Comments as C,K_Problem as P where C.P_FK_code=P.K_Problem_code group by P.K_Problem_code) as C1 on T.K_Problem_code=C1.K_Problem_code ");
            strSql.Append(" where K_Problem_isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

