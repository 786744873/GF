using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:客户跟进表
    /// 作者：崔慧栋
    /// 日期：2015/08/7
    /// </summary>
    public partial class C_Customer_Follow
    {
        public C_Customer_Follow()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Customer_Follow_id", "C_Customer_Follow");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Customer_Follow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer_Follow");
            strSql.Append(" where C_Customer_Follow_id=@C_Customer_Follow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Follow_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查是否存在客户跟进记录
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="contactCode">联系人Guid</param>
        /// <returns></returns>
        public bool Exists(Guid customerCode, Guid contactCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Customer_Follow ");
            strSql.Append("where C_Customer_code=@C_Customer_code and C_Customer_Follow_contacter=@C_Customer_Follow_contacter and C_Customer_Follow_isDelete=0 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contacter", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = customerCode;
            parameters[1].Value = contactCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer_Follow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Customer_Follow(");
            strSql.Append("C_Customer_Follow_code,C_Customer_code,C_Customer_Follow_contacter,C_Customer_Follow_contactInformation,C_Customer_Follow_time,C_Customer_Follow_Result,C_Customer_Follow_Stage,C_Customer_Follow_isDelete,C_Customer_Follow_creator,C_Customer_Follow_createTime,C_Customer_Business_Flow)");
            strSql.Append(" values (");
            strSql.Append("@C_Customer_Follow_code,@C_Customer_code,@C_Customer_Follow_contacter,@C_Customer_Follow_contactInformation,@C_Customer_Follow_time,@C_Customer_Follow_Result,@C_Customer_Follow_Stage,@C_Customer_Follow_isDelete,@C_Customer_Follow_creator,@C_Customer_Follow_createTime,@C_Customer_Business_Flow)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contacter", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contactInformation", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Follow_time", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_Follow_Result", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Customer_Follow_Stage", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Follow_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Follow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_createTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Customer_Business_Flow", SqlDbType.UniqueIdentifier,16),
                                        };
            parameters[0].Value = model.C_Customer_Follow_code;
            parameters[1].Value = model.C_Customer_code;
            parameters[2].Value = model.C_Customer_Follow_contacter;
            parameters[3].Value = model.C_Customer_Follow_contactInformation;
            parameters[4].Value = model.C_Customer_Follow_time;
            parameters[5].Value = model.C_Customer_Follow_Result;
            parameters[6].Value = model.C_Customer_Follow_Stage;
            parameters[7].Value = model.C_Customer_Follow_isDelete;
            parameters[8].Value = model.C_Customer_Follow_creator;
            parameters[9].Value = model.C_Customer_Follow_createTime;
            parameters[10].Value = model.C_Customer_Business_Flow;
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
        public bool Update(CommonService.Model.C_Customer_Follow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_Follow set ");
            strSql.Append("C_Customer_Follow_code=@C_Customer_Follow_code,");
            strSql.Append("C_Customer_code=@C_Customer_code,");
            strSql.Append("C_Customer_Follow_contacter=@C_Customer_Follow_contacter,");
            strSql.Append("C_Customer_Follow_contactInformation=@C_Customer_Follow_contactInformation,");
            strSql.Append("C_Customer_Follow_time=@C_Customer_Follow_time,");
            strSql.Append("C_Customer_Follow_Result=@C_Customer_Follow_Result,");
            strSql.Append("C_Customer_Follow_Stage=@C_Customer_Follow_Stage,");
            strSql.Append("C_Customer_Follow_isDelete=@C_Customer_Follow_isDelete,");
            strSql.Append("C_Customer_Follow_creator=@C_Customer_Follow_creator,");
            strSql.Append("C_Customer_Follow_createTime=@C_Customer_Follow_createTime,");
            strSql.Append("C_Customer_Business_Flow=@C_Customer_Business_Flow");
            strSql.Append(" where C_Customer_Follow_id=@C_Customer_Follow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contacter", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contactInformation", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Follow_time", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_Follow_Result", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Customer_Follow_Stage", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Follow_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_Follow_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Customer_Follow_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Business_Flow", SqlDbType.UniqueIdentifier,16)              
                                        };
            parameters[0].Value = model.C_Customer_Follow_code;
            parameters[1].Value = model.C_Customer_code;
            parameters[2].Value = model.C_Customer_Follow_contacter;
            parameters[3].Value = model.C_Customer_Follow_contactInformation;
            parameters[4].Value = model.C_Customer_Follow_time;
            parameters[5].Value = model.C_Customer_Follow_Result;
            parameters[6].Value = model.C_Customer_Follow_Stage;
            parameters[7].Value = model.C_Customer_Follow_isDelete;
            parameters[8].Value = model.C_Customer_Follow_creator;
            parameters[9].Value = model.C_Customer_Follow_createTime;
            parameters[10].Value = model.C_Customer_Follow_id;
            parameters[11].Value = model.C_Customer_Business_Flow;

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
        public bool Delete(int C_Customer_Follow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Customer_Follow set C_Customer_Follow_isDelete=1 ");
            strSql.Append(" where C_Customer_Follow_id=@C_Customer_Follow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_id", SqlDbType.Int)
			};
            parameters[0].Value = C_Customer_Follow_id;

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
        public bool DeleteList(string C_Customer_Follow_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Customer_Follow ");
            strSql.Append(" where C_Customer_Follow_id in (" + C_Customer_Follow_idlist + ")  ");
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
        public CommonService.Model.C_Customer_Follow GetModel(int C_Customer_Follow_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Customer_Follow_id,C_Customer_Follow_code,a.C_Customer_code as C_Customer_code,C_Customer_Follow_contacter,C_Customer_Follow_contactInformation,C_Customer_Follow_time,C_Customer_Follow_Result,C_Customer_Follow_Stage,C_Customer_Follow_isDelete,C_Customer_Follow_creator,C_Customer_Follow_createTime,C_Customer_Business_Flow,b.C_Customer_name as C_Customer_name,c.C_Contacts_name as C_Customer_follow_contacter_name,");
            strSql.Append("P.C_Parameters_name as 'C_Customer_Follow_contactinformationName',P1.C_Parameters_name as 'C_Customer_Follow_stageName',U.C_Userinfo_name as 'C_Customer_Follow_creatorName' ");
            strSql.Append("from C_Customer_Follow as a ");
            strSql.Append("left join C_Customer as b on a.C_Customer_code=b.C_Customer_code ");
            strSql.Append("left join C_Parameters as P on a.C_Customer_Follow_contactInformation=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters as P1 on a.C_Customer_Follow_Stage=P1.C_Parameters_id ");
            strSql.Append("left join C_Userinfo as U on a.C_Customer_Follow_creator=U.C_Userinfo_code ");
            strSql.Append("left join C_Contacts as c on a.C_Customer_Follow_contacter=c.C_Contacts_code ");
            strSql.Append(" where C_Customer_Follow_id=@C_Customer_Follow_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Customer_Follow_id;

            CommonService.Model.C_Customer_Follow model = new CommonService.Model.C_Customer_Follow();
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
        public CommonService.Model.C_Customer_Follow DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Customer_Follow model = new CommonService.Model.C_Customer_Follow();
            if (row != null)
            {
                if (row["C_Customer_Follow_id"] != null && row["C_Customer_Follow_id"].ToString() != "")
                {
                    model.C_Customer_Follow_id = int.Parse(row["C_Customer_Follow_id"].ToString());
                }
                if (row["C_Customer_Follow_code"] != null && row["C_Customer_Follow_code"].ToString() != "")
                {
                    model.C_Customer_Follow_code = new Guid(row["C_Customer_Follow_code"].ToString());
                }
                if (row["C_Customer_code"] != null && row["C_Customer_code"].ToString() != "")
                {
                    model.C_Customer_code = new Guid(row["C_Customer_code"].ToString());
                }
                if (row["C_Customer_Follow_contacter"] != null && row["C_Customer_Follow_contacter"].ToString() != "")
                {
                    model.C_Customer_Follow_contacter = new Guid(row["C_Customer_Follow_contacter"].ToString());
                }
                if (row["C_Customer_Follow_contactInformation"] != null && row["C_Customer_Follow_contactInformation"].ToString() != "")
                {
                    model.C_Customer_Follow_contactInformation = int.Parse(row["C_Customer_Follow_contactInformation"].ToString());
                }
                if (row["C_Customer_Follow_time"] != null && row["C_Customer_Follow_time"].ToString() != "")
                {
                    model.C_Customer_Follow_time = DateTime.Parse(row["C_Customer_Follow_time"].ToString());
                }
                if (row["C_Customer_Follow_Result"] != null)
                {
                    model.C_Customer_Follow_Result = row["C_Customer_Follow_Result"].ToString();
                }
                if (row["C_Customer_Follow_Stage"] != null && row["C_Customer_Follow_Stage"].ToString() != "")
                {
                    model.C_Customer_Follow_Stage = int.Parse(row["C_Customer_Follow_Stage"].ToString());
                }
                if (row["C_Customer_Follow_isDelete"] != null && row["C_Customer_Follow_isDelete"].ToString() != "")
                {
                    model.C_Customer_Follow_isDelete = int.Parse(row["C_Customer_Follow_isDelete"].ToString());
                }
                if (row["C_Customer_Follow_creator"] != null && row["C_Customer_Follow_creator"].ToString() != "")
                {
                    model.C_Customer_Follow_creator = new Guid(row["C_Customer_Follow_creator"].ToString());
                }
                if (row["C_Customer_Follow_createTime"] != null && row["C_Customer_Follow_createTime"].ToString() != "")
                {
                    model.C_Customer_Follow_createTime = DateTime.Parse(row["C_Customer_Follow_createTime"].ToString());
                }
                if (row["C_Customer_Business_Flow"] != null && row["C_Customer_Business_Flow"].ToString() != "")
                {
                    model.C_Customer_Business_Flow = new Guid(row["C_Customer_Business_Flow"].ToString());
                }
                //判断客户名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Customer_name"))
                {
                    if (row["C_Customer_name"] != null && row["C_Customer_name"].ToString() != "")
                    {
                        model.C_Customer_name = row["C_Customer_name"].ToString();
                    }
                }
                //判断联系人名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Customer_follow_contacter_name"))
                {
                    if (row["C_Customer_follow_contacter_name"] != null && row["C_Customer_follow_contacter_name"].ToString() != "")
                    {
                        model.C_Customer_follow_contacter_name = row["C_Customer_follow_contacter_name"].ToString();
                    }
                }
                //判断客户创建时间（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Customer_createTime"))
                {
                    if (row["C_Customer_createTime"] != null && row["C_Customer_createTime"].ToString() != "")
                    {
                        model.C_Customer_createTime = DateTime.Parse(row["C_Customer_createTime"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_Follow_contactinformationName"))
                {
                    if (row["C_Customer_Follow_contactinformationName"] != null && row["C_Customer_Follow_contactinformationName"].ToString() != "")
                    {
                        model.C_Customer_Follow_contactinformationName = row["C_Customer_Follow_contactinformationName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_Follow_stageName"))
                {
                    if (row["C_Customer_Follow_stageName"] != null && row["C_Customer_Follow_stageName"].ToString() != "")
                    {
                        model.C_Customer_Follow_stageName = row["C_Customer_Follow_stageName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Customer_Follow_creatorName"))
                {
                    if (row["C_Customer_Follow_creatorName"] != null && row["C_Customer_Follow_creatorName"].ToString() != "")
                    {
                        model.C_Customer_Follow_creatorName = row["C_Customer_Follow_creatorName"].ToString();
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
            strSql.Append("select C_Customer_Follow_id,C_Customer_Follow_code,C_Customer_code,C_Customer_Follow_contacter,C_Customer_Follow_contactInformation,C_Customer_Follow_time,C_Customer_Follow_Result,C_Customer_Follow_Stage,C_Customer_Follow_isDelete,C_Customer_Follow_creator,C_Customer_Follow_createTime,C_Customer_Business_Flow ");
            strSql.Append(" FROM C_Customer_Follow ");
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
            strSql.Append(" C_Customer_Follow_id,C_Customer_Follow_code,C_Customer_code,C_Customer_Follow_contacter,C_Customer_Follow_contactInformation,C_Customer_Follow_time,C_Customer_Follow_Result,C_Customer_Follow_Stage,C_Customer_Follow_isDelete,C_Customer_Follow_creator,C_Customer_Follow_createTime,C_Customer_Business_Flow ");
            strSql.Append(" FROM C_Customer_Follow ");
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
        public int GetRecordCount(CommonService.Model.C_Customer_Follow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Customer_Follow");
            strSql.Append(" where 1=1 and C_Customer_Follow_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Customer_Follow_code != null && model.C_Customer_Follow_code.ToString() != "")
                {
                    strSql.Append(" and C_Customer_Follow.C_Customer_Follow_code=@C_Customer_Follow_code");
                }
                if (model.C_Customer_code != null && model.C_Customer_code.ToString() != "")
                {
                    strSql.Append(" and C_Customer_Follow.C_Customer_code=@C_Customer_code");
                }
                if (model.C_Customer_Follow_contacter != null && model.C_Customer_Follow_contacter.ToString() != "")
                {
                    strSql.Append(" and C_Customer_Follow.C_Customer_Follow_contacter=@C_Customer_Follow_contacter");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contacter", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Customer_Follow_code;
            parameters[1].Value = model.C_Customer_code;
            parameters[2].Value = model.C_Customer_Follow_contacter;
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
        public DataSet GetListByPage(CommonService.Model.C_Customer_Follow model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Customer_Follow_id desc");
            }
            strSql.Append(")AS Row, T.*,CM.C_Parameters_name as C_Customer_Follow_StageName,CUS.C_Customer_name as 'C_Customer_name',CON.C_Contacts_name as 'C_Customer_follow_contacter_name',CUS.C_Customer_createTime as C_Customer_createTime ");
            strSql.Append("from C_Customer_Follow T ");
            strSql.Append("left join C_Customer as CUS on T.C_Customer_code=CUS.C_Customer_code ");
            strSql.Append("left join C_Contacts as CON on T.C_Customer_Follow_contacter=CON.C_Contacts_code ");
            strSql.Append("left join C_Parameters as CM on T.C_Customer_Follow_Stage=CM.C_Parameters_id ");
            strSql.Append(" where 1=1 and C_Customer_Follow_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Customer_Follow_code != null && model.C_Customer_Follow_code.ToString() != "")
                {
                    strSql.Append(" and T.C_Customer_Follow_code=@C_Customer_Follow_code");
                }
                if (model.C_Customer_code != null && model.C_Customer_code.ToString() != "")
                {
                    strSql.Append(" and T.C_Customer_code=@C_Customer_code");
                }
                if (model.C_Customer_Follow_contacter != null && model.C_Customer_Follow_contacter.ToString() != "")
                {
                    strSql.Append(" and T.C_Customer_Follow_contacter=@C_Customer_Follow_contacter");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_Follow_contacter", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Customer_Follow_code;
            parameters[1].Value = model.C_Customer_code;
            parameters[2].Value = model.C_Customer_Follow_contacter;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据客户实体和客户跟进实体获取中记录数
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <returns></returns>
        public int GetRecordCount2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, string groupCodes, bool IsPreSetManager, Guid? userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Customer_Follow as T");
            strSql.Append(" where 1=1 and C_Customer_Follow_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Customer_Follow_contactInformation != null)
                {
                    strSql.Append(" and T.C_Customer_Follow_contactInformation=@C_Customer_Follow_contactInformation");
                }
            }
            #region 客户实体查询条件
            if (modelc != null)
            { //根据客户实体条件添加查询条件
                strSql.Append(" and exists( select 1 from C_Customer as a where C_Customer_isDelete=0 and a.C_Customer_code=T.C_Customer_code ");
                //客户名称
                if (!String.IsNullOrEmpty(modelc.C_Customer_name))
                {
                    strSql.Append(" and a.C_Customer_name like N'%'+convert(varchar(100),@C_Customer_name)+'%' ");
                }
                //客户级别
                if (modelc.C_Customer_level != null)
                {
                    strSql.Append(" and C_Customer_level=@C_Customer_level");
                }
                if (modelc.C_Customer_lastContactDate != null && modelc.C_Customer_lastContactEndDate != null)
                {
                    strSql.Append(" and C_Customer_lastContactDate between convert(datetime,@C_Customer_lastContactDate,120) and convert(datetime,@C_Customer_lastContactEndDate,120) ");
                }
                //专业顾问的过滤
                if (modelc.C_Customer_consultant != null)
                {
                    strSql.Append(" and C_Customer_consultant=@C_Customer_consultant ");
                }
                //客户类别
                if (modelc.C_Customer_Category != null)
                {
                    strSql.Append(" and C_Customer_Category=@C_Customer_Category");
                }
                //客户开发阶段
                if (modelc.C_Customer_Open != null)
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Fk_code=C_Customer_code and P_Flow_code=@C_Customer_Open)");
                }
                //客户来源
                if (modelc.C_Customer_source != null)
                {
                    strSql.Append(" and C_Customer_source=@C_Customer_source");
                }
                //客户忠诚度
                if (modelc.C_Customer_loyalty != null)
                {
                    strSql.Append(" and C_Customer_loyalty=@C_Customer_loyalty");
                }
                //是否签约
                if (modelc.C_Customer_isSignedState != null)
                {
                    strSql.Append(" and C_Customer_isSignedState=@C_Customer_isSignedState");
                }
                //签约状态
                if (modelc.C_Customer_signedState != null)
                {
                    strSql.Append(" and C_Customer_signedState=@C_Customer_signedState");
                }
                strSql.Append(" )");
            }
            #endregion
            #region 数据权限
            if (!IsPreSetManager)
            {
                strSql.Append(" and (1<>1 ");
                //数据权限处理   除了内置管理员外 都要进行数据权限控制
                //数据权限 暂且根据客户表里面的字段进行区分
                if (groupCodes.Contains("6645a6c7-b5c8-4f78-9440-0c12d4b7195c"))
                {//专业顾问权限只能查看自己下面的客户跟踪
                    strSql.Append(" or exists(select 1 from C_Customer as c where c.C_Customer_code=T.C_Customer_code and C_Customer_consultant=@userCode and C_Customer_isDelete=0)");
                }
                if (groupCodes.Contains("a33b44c7-93a0-4520-94d5-c50c8c7ac99f"))
                {//部长可以看部长下面的所有的专业顾问的客户跟踪
                    strSql.Append(" or exists(select 1 from C_Customer as c  where c.C_Customer_code=T.C_Customer_code and C_Customer_responsiblePerson=@userCode and C_Customer_isDelete=0)");
                }
                if (groupCodes.Contains("da275f5a-4809-4f9d-832e-b213a65a78f5"))
                {//首席专家可以看部长下面的所有的专业顾问的客户跟踪
                    //strSql.Append(" or exists(select 1 from C_Customer as c  where c.C_Customer_code=T.C_Customer_code and C_Customer_chiefResponsiblePerson=@userCode and C_Customer_isDelete=0)");
                    strSql.Append(" or exists(select 1 from C_ChiefExpert_Minister as CM,C_Customer as CUS where T.C_Customer_code=CUS.C_Customer_code and CM.C_ChiefExpert_Code=@userCode and CM.C_Minister_Code=CUS.C_Customer_responsiblePerson and CUS.C_Customer_isDelete=0)");
                }
                if (groupCodes.Contains("a7ad8acf-2462-4187-a4ee-d2e4573c765a"))
                {//分总可以看本区域下面的所有的专业顾问的客户跟踪
                    strSql.Append(" or exists(select 1 from C_Customer as c ");
                    strSql.Append("left join C_Customer_Region as d on d.C_Customer_Region_customer=c.C_Customer_code ");
                    strSql.Append("where c.C_Customer_isDelete=0 ");
                    strSql.Append("and d.C_Customer_Region_isDelete=0 ");
                    strSql.Append("and exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and OPUR.C_region_code=d.C_Customer_Region_relRegion and OPUR.C_User_code=@usercode) ");
                    strSql.Append("and c.C_Customer_code=T.C_Customer_code) ");
                }
                strSql.Append(")");
            }
            #endregion
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_contactInformation", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_level",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_lastContactDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_lastContactEndDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_Category",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Open",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_source",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_loyalty",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_isSignedState",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_signedState",SqlDbType.Int,4),
                    new SqlParameter("@usercode", SqlDbType.UniqueIdentifier,16),
                                        };
            parameters[0].Value = model.C_Customer_Follow_contactInformation;
            parameters[1].Value = modelc.C_Customer_name;
            parameters[2].Value = modelc.C_Customer_consultant;
            parameters[3].Value = modelc.C_Customer_level;
            parameters[4].Value = modelc.C_Customer_lastContactDate;
            parameters[5].Value = modelc.C_Customer_lastContactEndDate;
            parameters[6].Value = modelc.C_Customer_Category;
            parameters[7].Value = modelc.C_Customer_Open;
            parameters[8].Value = modelc.C_Customer_source;
            parameters[9].Value = modelc.C_Customer_loyalty;
            parameters[10].Value = modelc.C_Customer_isSignedState;
            parameters[11].Value = modelc.C_Customer_signedState;
            parameters[12].Value = userCode;
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
        /// 根据客户实体和客户跟进实体获取分页数据
        /// </summary>
        /// <param name="model">客户跟进实体</param>
        /// <param name="modelc">客户实体</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        public DataSet GetListByPage2(CommonService.Model.C_Customer_Follow model, CommonService.Model.C_Customer modelc, string groupCodes, bool IsPreSetManager, string orderby, int startIndex, int endIndex, Guid? userCode)
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
                strSql.Append("order by T.C_Customer_Follow_id desc");
            }
            strSql.Append(")AS Row, T.*,CUS.C_Customer_name as 'C_Customer_name',CON.C_Contacts_name as 'C_Customer_follow_contacter_name',P.C_Parameters_name as 'C_Customer_Follow_contactinformationName',P1.C_Parameters_name as 'C_Customer_Follow_stageName',U.C_Userinfo_name as 'C_Customer_Follow_creatorName'  from C_Customer_Follow T ");
            strSql.Append("left join C_Customer as CUS on T.C_Customer_code=CUS.C_Customer_code ");
            strSql.Append("left join C_Contacts as CON on T.C_Customer_Follow_contacter=CON.C_Contacts_code ");
            strSql.Append("left join C_Parameters as P on T.C_Customer_Follow_contactInformation=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters as P1 on T.C_Customer_Follow_Stage=P1.C_Parameters_id ");
            strSql.Append("left join C_Userinfo as U on T.C_Customer_Follow_creator=U.C_Userinfo_code ");
            strSql.Append(" where 1=1 and C_Customer_Follow_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Customer_Follow_contactInformation != null)
                {
                    strSql.Append(" and C_Customer_Follow_contactInformation=@C_Customer_Follow_contactInformation");
                }
            }
            #region 客户实体查询条件
            if (modelc != null)
            { //根据客户实体条件添加查询条件
                strSql.Append(" and exists( select 1 from C_Customer as a where C_Customer_isDelete=0 and a.C_Customer_code=T.C_Customer_code ");
                //客户名称
                if (!String.IsNullOrEmpty(modelc.C_Customer_name))
                {
                    strSql.Append(" and a.C_Customer_name like N'%'+convert(varchar(100),@C_Customer_name)+'%' ");
                }
                //客户级别
                if (modelc.C_Customer_level != null)
                {
                    strSql.Append(" and C_Customer_level=@C_Customer_level");
                }
                if (modelc.C_Customer_lastContactDate != null && modelc.C_Customer_lastContactEndDate != null)
                {
                    strSql.Append(" and C_Customer_lastContactDate between convert(datetime,@C_Customer_lastContactDate,120) and convert(datetime,@C_Customer_lastContactEndDate,120) ");
                }
                //专业顾问的过滤
                if (modelc.C_Customer_consultant != null)
                {
                    strSql.Append(" and C_Customer_consultant=@C_Customer_consultant ");
                }
                //客户类别
                if (modelc.C_Customer_Category != null)
                {
                    strSql.Append(" and C_Customer_Category=@C_Customer_Category");
                }
                //客户开发阶段
                if (modelc.C_Customer_Open != null)
                {
                    strSql.Append(" and exists(select 1 from P_Business_flow where P_Fk_code=C_Customer_code and P_Flow_code=@C_Customer_Open)");
                }
                //客户来源
                if (modelc.C_Customer_source != null)
                {
                    strSql.Append(" and C_Customer_source=@C_Customer_source");
                }
                //客户忠诚度
                if (modelc.C_Customer_loyalty != null)
                {
                    strSql.Append(" and C_Customer_loyalty=@C_Customer_loyalty");
                }
                //是否签约
                if (modelc.C_Customer_isSignedState != null)
                {
                    strSql.Append(" and C_Customer_isSignedState=@C_Customer_isSignedState");
                }
                //签约状态
                if (modelc.C_Customer_signedState != null)
                {
                    strSql.Append(" and C_Customer_signedState=@C_Customer_signedState");
                }
                strSql.Append(" )");
            }
            #endregion
            #region 数据权限
            if (!IsPreSetManager)
            {
                strSql.Append(" and (1<>1 ");
                //数据权限处理   除了内置管理员外 都要进行数据权限控制
                //数据权限 暂且根据客户表里面的字段进行区分
                if (groupCodes.Contains("6645a6c7-b5c8-4f78-9440-0c12d4b7195c"))
                {//专业顾问权限只能查看自己下面的客户跟踪
                    strSql.Append(" or exists(select 1 from C_Customer as c where c.C_Customer_code=T.C_Customer_code and C_Customer_consultant=@userCode and C_Customer_isDelete=0)");
                }
                if (groupCodes.Contains("a33b44c7-93a0-4520-94d5-c50c8c7ac99f"))
                {//部长可以看部长下面的所有的专业顾问的客户跟踪
                    strSql.Append(" or exists(select 1 from C_Customer as c  where c.C_Customer_code=T.C_Customer_code and C_Customer_responsiblePerson=@userCode and C_Customer_isDelete=0)");
                }
                if (groupCodes.Contains("da275f5a-4809-4f9d-832e-b213a65a78f5"))
                {//首席专家可以看部长下面的所有的专业顾问的客户跟踪
                    //strSql.Append(" or exists(select 1 from C_Customer as c  where c.C_Customer_code=T.C_Customer_code and C_Customer_chiefResponsiblePerson=@userCode and C_Customer_isDelete=0)");
                    strSql.Append(" or exists(select 1 from C_ChiefExpert_Minister as CM,C_Customer as CUS where T.C_Customer_code=CUS.C_Customer_code and CM.C_ChiefExpert_Code=@userCode and CM.C_Minister_Code=CUS.C_Customer_responsiblePerson and CUS.C_Customer_isDelete=0)");
                }
                if (groupCodes.Contains("a7ad8acf-2462-4187-a4ee-d2e4573c765a"))
                {//分总可以看本区域下面的所有的专业顾问的客户跟踪
                    strSql.Append(" or exists(select 1 from C_Customer as c ");
                    strSql.Append("left join C_Customer_Region as d on d.C_Customer_Region_customer=c.C_Customer_code ");
                    strSql.Append("where c.C_Customer_isDelete=0 ");
                    strSql.Append("and d.C_Customer_Region_isDelete=0 ");
                    strSql.Append("and exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and OPUR.C_region_code=d.C_Customer_Region_relRegion and OPUR.C_User_code=@usercode) ");
                    strSql.Append("and c.C_Customer_code=T.C_Customer_code) ");
                }
                strSql.Append(")");
            }
            #endregion

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Customer_Follow_contactInformation", SqlDbType.Int,4),
					new SqlParameter("@C_Customer_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Customer_consultant", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Customer_level",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_lastContactDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_lastContactEndDate",SqlDbType.DateTime,50),
                    new SqlParameter("@C_Customer_Category",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_Open",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Customer_source",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_loyalty",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_isSignedState",SqlDbType.Int,4),
                    new SqlParameter("@C_Customer_signedState",SqlDbType.Int,4),
                    new SqlParameter("@usercode", SqlDbType.UniqueIdentifier,16),
                                        };
            parameters[0].Value = model.C_Customer_Follow_contactInformation;
            parameters[1].Value = modelc.C_Customer_name;
            parameters[2].Value = modelc.C_Customer_consultant;
            parameters[3].Value = modelc.C_Customer_level;
            parameters[4].Value = modelc.C_Customer_lastContactDate;
            parameters[5].Value = modelc.C_Customer_lastContactEndDate;
            parameters[6].Value = modelc.C_Customer_Category;
            parameters[7].Value = modelc.C_Customer_Open;
            parameters[8].Value = modelc.C_Customer_source;
            parameters[9].Value = modelc.C_Customer_loyalty;
            parameters[10].Value = modelc.C_Customer_isSignedState;
            parameters[11].Value = modelc.C_Customer_signedState;
            parameters[12].Value = userCode;
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
            parameters[0].Value = "C_Customer_Follow";
            parameters[1].Value = "C_Customer_Follow_id";
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

