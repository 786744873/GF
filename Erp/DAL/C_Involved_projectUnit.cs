using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:涉案项目关联单位
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	public partial class C_Involved_projectUnit
	{
		public C_Involved_projectUnit()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Involved_projectUnit_id", "C_Involved_projectUnit");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Involved_projectUnit_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Involved_projectUnit");
            strSql.Append(" where C_Involved_projectUnit_id=@C_Involved_projectUnit_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Involved_projectUnit_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_Involved_projectUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Involved_projectUnit(");
			strSql.Append("C_Involved_projectUnit_code,C_Involved_project_code,C_Involved_projectUnit_Child,C_Involved_projectUnit_rival_type,C_Involved_projectUnit_rival,C_Involved_projectUnit_type,C_Involved_projectUnit_fundsSource,C_Involved_projectUnit_charger,C_Involved_projectUnit_chargerIdentity,C_Involved_projectUnit_chargerOrgan,C_Involved_projectUnit_chargerFundsSource,C_Involved_projectUnit_startTime,C_Involved_projectUnit_acceptanceTime,C_Involved_projectUnit_process,C_Involved_projectUnit_accidents,C_Involved_projectUnit_qualityAccidents,C_Involved_projectUnit_litigation,C_Involved_projectUnit_lossOrProfit,C_Involved_projectUnit_lossReason,C_Involved_projectUnit_creator,C_Involved_projectUnit_createTime,C_Involved_projectUnit_isDelete)");
			strSql.Append(" values (");
			strSql.Append("@C_Involved_projectUnit_code,@C_Involved_project_code,@C_Involved_projectUnit_Child,@C_Involved_projectUnit_rival_type,@C_Involved_projectUnit_rival,@C_Involved_projectUnit_type,@C_Involved_projectUnit_fundsSource,@C_Involved_projectUnit_charger,@C_Involved_projectUnit_chargerIdentity,@C_Involved_projectUnit_chargerOrgan,@C_Involved_projectUnit_chargerFundsSource,@C_Involved_projectUnit_startTime,@C_Involved_projectUnit_acceptanceTime,@C_Involved_projectUnit_process,@C_Involved_projectUnit_accidents,@C_Involved_projectUnit_qualityAccidents,@C_Involved_projectUnit_litigation,@C_Involved_projectUnit_lossOrProfit,@C_Involved_projectUnit_lossReason,@C_Involved_projectUnit_creator,@C_Involved_projectUnit_createTime,@C_Involved_projectUnit_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_Child", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_projectUnit_rival_type", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_rival", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_type", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_fundsSource", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_charger", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_chargerIdentity", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_projectUnit_chargerOrgan", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_chargerFundsSource", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_startTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_projectUnit_acceptanceTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_projectUnit_process", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_accidents", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_projectUnit_qualityAccidents", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_projectUnit_litigation", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_projectUnit_lossOrProfit", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_lossReason", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_projectUnit_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Involved_projectUnit_code;
            parameters[1].Value = model.C_Involved_project_code;
			parameters[2].Value = model.C_Involved_projectUnit_Child;
			parameters[3].Value = model.C_Involved_projectUnit_rival_type;
            parameters[4].Value = model.C_Involved_projectUnit_rival;
			parameters[5].Value = model.C_Involved_projectUnit_type;
			parameters[6].Value = model.C_Involved_projectUnit_fundsSource;
            parameters[7].Value = model.C_Involved_projectUnit_charger;
			parameters[8].Value = model.C_Involved_projectUnit_chargerIdentity;
			parameters[9].Value = model.C_Involved_projectUnit_chargerOrgan;
			parameters[10].Value = model.C_Involved_projectUnit_chargerFundsSource;
			parameters[11].Value = model.C_Involved_projectUnit_startTime;
			parameters[12].Value = model.C_Involved_projectUnit_acceptanceTime;
			parameters[13].Value = model.C_Involved_projectUnit_process;
			parameters[14].Value = model.C_Involved_projectUnit_accidents;
			parameters[15].Value = model.C_Involved_projectUnit_qualityAccidents;
			parameters[16].Value = model.C_Involved_projectUnit_litigation;
			parameters[17].Value = model.C_Involved_projectUnit_lossOrProfit;
			parameters[18].Value = model.C_Involved_projectUnit_lossReason;
            parameters[19].Value = model.C_Involved_projectUnit_creator;
			parameters[20].Value = model.C_Involved_projectUnit_createTime;
			parameters[21].Value = model.C_Involved_projectUnit_isDelete;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
        public bool Update(CommonService.Model.C_Involved_projectUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Involved_projectUnit set ");
			strSql.Append("C_Involved_projectUnit_code=@C_Involved_projectUnit_code,");
			strSql.Append("C_Involved_project_code=@C_Involved_project_code,");
			strSql.Append("C_Involved_projectUnit_Child=@C_Involved_projectUnit_Child,");
			strSql.Append("C_Involved_projectUnit_rival_type=@C_Involved_projectUnit_rival_type,");
			strSql.Append("C_Involved_projectUnit_rival=@C_Involved_projectUnit_rival,");
			strSql.Append("C_Involved_projectUnit_type=@C_Involved_projectUnit_type,");
			strSql.Append("C_Involved_projectUnit_fundsSource=@C_Involved_projectUnit_fundsSource,");
			strSql.Append("C_Involved_projectUnit_charger=@C_Involved_projectUnit_charger,");
			strSql.Append("C_Involved_projectUnit_chargerIdentity=@C_Involved_projectUnit_chargerIdentity,");
			strSql.Append("C_Involved_projectUnit_chargerOrgan=@C_Involved_projectUnit_chargerOrgan,");
			strSql.Append("C_Involved_projectUnit_chargerFundsSource=@C_Involved_projectUnit_chargerFundsSource,");
			strSql.Append("C_Involved_projectUnit_startTime=@C_Involved_projectUnit_startTime,");
			strSql.Append("C_Involved_projectUnit_acceptanceTime=@C_Involved_projectUnit_acceptanceTime,");
			strSql.Append("C_Involved_projectUnit_process=@C_Involved_projectUnit_process,");
			strSql.Append("C_Involved_projectUnit_accidents=@C_Involved_projectUnit_accidents,");
			strSql.Append("C_Involved_projectUnit_qualityAccidents=@C_Involved_projectUnit_qualityAccidents,");
			strSql.Append("C_Involved_projectUnit_litigation=@C_Involved_projectUnit_litigation,");
			strSql.Append("C_Involved_projectUnit_lossOrProfit=@C_Involved_projectUnit_lossOrProfit,");
			strSql.Append("C_Involved_projectUnit_lossReason=@C_Involved_projectUnit_lossReason,");
			strSql.Append("C_Involved_projectUnit_creator=@C_Involved_projectUnit_creator,");
			strSql.Append("C_Involved_projectUnit_createTime=@C_Involved_projectUnit_createTime,");
			strSql.Append("C_Involved_projectUnit_isDelete=@C_Involved_projectUnit_isDelete");
			strSql.Append(" where C_Involved_projectUnit_id=@C_Involved_projectUnit_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_Child", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_projectUnit_rival_type", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_rival", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_type", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_fundsSource", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_charger", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_chargerIdentity", SqlDbType.VarChar,50),
					new SqlParameter("@C_Involved_projectUnit_chargerOrgan", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_chargerFundsSource", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_startTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_projectUnit_acceptanceTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_projectUnit_process", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_accidents", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_projectUnit_qualityAccidents", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_projectUnit_litigation", SqlDbType.VarChar,100),
					new SqlParameter("@C_Involved_projectUnit_lossOrProfit", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_lossReason", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_projectUnit_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Involved_projectUnit_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Involved_projectUnit_id", SqlDbType.Int,4)};
			parameters[0].Value = model.C_Involved_projectUnit_code;
			parameters[1].Value = model.C_Involved_project_code;
			parameters[2].Value = model.C_Involved_projectUnit_Child;
			parameters[3].Value = model.C_Involved_projectUnit_rival_type;
			parameters[4].Value = model.C_Involved_projectUnit_rival;
			parameters[5].Value = model.C_Involved_projectUnit_type;
			parameters[6].Value = model.C_Involved_projectUnit_fundsSource;
			parameters[7].Value = model.C_Involved_projectUnit_charger;
			parameters[8].Value = model.C_Involved_projectUnit_chargerIdentity;
			parameters[9].Value = model.C_Involved_projectUnit_chargerOrgan;
			parameters[10].Value = model.C_Involved_projectUnit_chargerFundsSource;
			parameters[11].Value = model.C_Involved_projectUnit_startTime;
			parameters[12].Value = model.C_Involved_projectUnit_acceptanceTime;
			parameters[13].Value = model.C_Involved_projectUnit_process;
			parameters[14].Value = model.C_Involved_projectUnit_accidents;
			parameters[15].Value = model.C_Involved_projectUnit_qualityAccidents;
			parameters[16].Value = model.C_Involved_projectUnit_litigation;
			parameters[17].Value = model.C_Involved_projectUnit_lossOrProfit;
			parameters[18].Value = model.C_Involved_projectUnit_lossReason;
			parameters[19].Value = model.C_Involved_projectUnit_creator;
			parameters[20].Value = model.C_Involved_projectUnit_createTime;
			parameters[21].Value = model.C_Involved_projectUnit_isDelete;
			parameters[22].Value = model.C_Involved_projectUnit_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Delete(Guid Involved_projectUnit_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_Involved_projectUnit set C_Involved_projectUnit_isDelete=1 ");
            strSql.Append(" where C_Involved_projectUnit_code=@C_Involved_projectUnit_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = Involved_projectUnit_code;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string C_Involved_projectUnit_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Involved_projectUnit ");
			strSql.Append(" where C_Involved_projectUnit_id in ("+C_Involved_projectUnit_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public CommonService.Model.C_Involved_projectUnit GetModel(int C_Involved_projectUnit_id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_Involved_projectUnit_id,C_Involved_projectUnit_code,C_Involved_project_code,C_Involved_projectUnit_Child,C_Involved_projectUnit_rival_type,C_Involved_projectUnit_rival,C_Involved_projectUnit_type,C_Involved_projectUnit_fundsSource,C_Involved_projectUnit_charger,C_Involved_projectUnit_chargerIdentity,C_Involved_projectUnit_chargerOrgan,C_Involved_projectUnit_chargerFundsSource,C_Involved_projectUnit_startTime,C_Involved_projectUnit_acceptanceTime,C_Involved_projectUnit_process,C_Involved_projectUnit_accidents,C_Involved_projectUnit_qualityAccidents,C_Involved_projectUnit_litigation,C_Involved_projectUnit_lossOrProfit,C_Involved_projectUnit_lossReason,C_Involved_projectUnit_creator,C_Involved_projectUnit_createTime,C_Involved_projectUnit_isDelete from C_Involved_projectUnit ");
			strSql.Append(" where C_Involved_projectUnit_id=@C_Involved_projectUnit_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_id", SqlDbType.Int,4)
			};
			parameters[0].Value = C_Involved_projectUnit_id;

            CommonService.Model.C_Involved_projectUnit model = new CommonService.Model.C_Involved_projectUnit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public CommonService.Model.C_Involved_projectUnit GetModel(Guid C_Involved_projectUnit_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *,");
            strSql.Append("case when C_Involved_projectUnit_rival_type=0 then (select C_CRival_name from C_CRival where C_CRival_code=C_Involved_projectUnit_rival) ");
            strSql.Append("when C_Involved_projectUnit_rival_type=1 then (select C_PRival_name from C_PRival where C_PRival_code=C_Involved_projectUnit_rival) ");
            strSql.Append("end as C_Involved_projectUnit_rivalname ");
            strSql.Append("from C_Involved_projectUnit ");
            strSql.Append(" where C_Involved_projectUnit_code=@C_Involved_projectUnit_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Involved_projectUnit_code;

            CommonService.Model.C_Involved_projectUnit model = new CommonService.Model.C_Involved_projectUnit();
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
        public CommonService.Model.C_Involved_projectUnit DataRowToModel(DataRow row)
		{
            CommonService.Model.C_Involved_projectUnit model = new CommonService.Model.C_Involved_projectUnit();
			if (row != null)
			{
				if(row["C_Involved_projectUnit_id"]!=null && row["C_Involved_projectUnit_id"].ToString()!="")
				{
					model.C_Involved_projectUnit_id=int.Parse(row["C_Involved_projectUnit_id"].ToString());
				}
				if(row["C_Involved_projectUnit_code"]!=null && row["C_Involved_projectUnit_code"].ToString()!="")
				{
					model.C_Involved_projectUnit_code= new Guid(row["C_Involved_projectUnit_code"].ToString());
				}
				if(row["C_Involved_project_code"]!=null && row["C_Involved_project_code"].ToString()!="")
				{
					model.C_Involved_project_code= new Guid(row["C_Involved_project_code"].ToString());
				}
				if(row["C_Involved_projectUnit_Child"]!=null)
				{
					model.C_Involved_projectUnit_Child=row["C_Involved_projectUnit_Child"].ToString();
				}
				if(row["C_Involved_projectUnit_rival_type"]!=null && row["C_Involved_projectUnit_rival_type"].ToString()!="")
				{
					model.C_Involved_projectUnit_rival_type=int.Parse(row["C_Involved_projectUnit_rival_type"].ToString());
				}
				if(row["C_Involved_projectUnit_rival"]!=null && row["C_Involved_projectUnit_rival"].ToString()!="")
				{
					model.C_Involved_projectUnit_rival= new Guid(row["C_Involved_projectUnit_rival"].ToString());
				}
                //判断投标单位名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Involved_projectUnit_rivalname"))
                {
                    if (row["C_Involved_projectUnit_rivalname"] != null && row["C_Involved_projectUnit_rivalname"].ToString() != "")
                    {
                        model.C_Involved_projectUnit_rivalname = row["C_Involved_projectUnit_rivalname"].ToString();
                    }
                }               
				if(row["C_Involved_projectUnit_type"]!=null && row["C_Involved_projectUnit_type"].ToString()!="")
				{
					model.C_Involved_projectUnit_type=int.Parse(row["C_Involved_projectUnit_type"].ToString());
				}
				if(row["C_Involved_projectUnit_fundsSource"]!=null && row["C_Involved_projectUnit_fundsSource"].ToString()!="")
				{
					model.C_Involved_projectUnit_fundsSource=int.Parse(row["C_Involved_projectUnit_fundsSource"].ToString());
				}
				if(row["C_Involved_projectUnit_charger"]!=null && row["C_Involved_projectUnit_charger"].ToString()!="")
				{
					model.C_Involved_projectUnit_charger= new Guid(row["C_Involved_projectUnit_charger"].ToString());
				}
                //判断实际负责人名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Involved_projectUnit_chargername"))
                {
                    if (row["C_Involved_projectUnit_chargername"] != null && row["C_Involved_projectUnit_chargername"].ToString() != "")
                    {
                        model.C_Involved_projectUnit_chargername = row["C_Involved_projectUnit_chargername"].ToString();
                    }
                }               
				if(row["C_Involved_projectUnit_chargerIdentity"]!=null)
				{
					model.C_Involved_projectUnit_chargerIdentity=row["C_Involved_projectUnit_chargerIdentity"].ToString();
				}
				if(row["C_Involved_projectUnit_chargerOrgan"]!=null && row["C_Involved_projectUnit_chargerOrgan"].ToString()!="")
				{
					model.C_Involved_projectUnit_chargerOrgan=int.Parse(row["C_Involved_projectUnit_chargerOrgan"].ToString());
				}
				if(row["C_Involved_projectUnit_chargerFundsSource"]!=null && row["C_Involved_projectUnit_chargerFundsSource"].ToString()!="")
				{
					model.C_Involved_projectUnit_chargerFundsSource=int.Parse(row["C_Involved_projectUnit_chargerFundsSource"].ToString());
				}
				if(row["C_Involved_projectUnit_startTime"]!=null && row["C_Involved_projectUnit_startTime"].ToString()!="")
				{
					model.C_Involved_projectUnit_startTime=DateTime.Parse(row["C_Involved_projectUnit_startTime"].ToString());
				}
				if(row["C_Involved_projectUnit_acceptanceTime"]!=null && row["C_Involved_projectUnit_acceptanceTime"].ToString()!="")
				{
					model.C_Involved_projectUnit_acceptanceTime=DateTime.Parse(row["C_Involved_projectUnit_acceptanceTime"].ToString());
				}
				if(row["C_Involved_projectUnit_process"]!=null && row["C_Involved_projectUnit_process"].ToString()!="")
				{
					model.C_Involved_projectUnit_process=int.Parse(row["C_Involved_projectUnit_process"].ToString());
				}
				if(row["C_Involved_projectUnit_accidents"]!=null)
				{
					model.C_Involved_projectUnit_accidents=row["C_Involved_projectUnit_accidents"].ToString();
				}
				if(row["C_Involved_projectUnit_qualityAccidents"]!=null)
				{
					model.C_Involved_projectUnit_qualityAccidents=row["C_Involved_projectUnit_qualityAccidents"].ToString();
				}
				if(row["C_Involved_projectUnit_litigation"]!=null)
				{
					model.C_Involved_projectUnit_litigation=row["C_Involved_projectUnit_litigation"].ToString();
				}
				if(row["C_Involved_projectUnit_lossOrProfit"]!=null && row["C_Involved_projectUnit_lossOrProfit"].ToString()!="")
				{
					model.C_Involved_projectUnit_lossOrProfit=int.Parse(row["C_Involved_projectUnit_lossOrProfit"].ToString());
				}
				if(row["C_Involved_projectUnit_lossReason"]!=null && row["C_Involved_projectUnit_lossReason"].ToString()!="")
				{
					model.C_Involved_projectUnit_lossReason=int.Parse(row["C_Involved_projectUnit_lossReason"].ToString());
				}
				if(row["C_Involved_projectUnit_creator"]!=null && row["C_Involved_projectUnit_creator"].ToString()!="")
				{
					model.C_Involved_projectUnit_creator= new Guid(row["C_Involved_projectUnit_creator"].ToString());
				}
				if(row["C_Involved_projectUnit_createTime"]!=null && row["C_Involved_projectUnit_createTime"].ToString()!="")
				{
					model.C_Involved_projectUnit_createTime=DateTime.Parse(row["C_Involved_projectUnit_createTime"].ToString());
				}
				if(row["C_Involved_projectUnit_isDelete"]!=null && row["C_Involved_projectUnit_isDelete"].ToString()!="")
				{
					model.C_Involved_projectUnit_isDelete=int.Parse(row["C_Involved_projectUnit_isDelete"].ToString());
				}
			}
			return model;
		}


        /// <summary>
        /// 获得负责人数据列表
        /// </summary>
        public DataSet GetChargerList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Involved_projectUnit.*,C_Contacts_code as C_Involved_projectUnit_charger,C_Contacts_name as C_Involved_projectUnit_chargername from C_Contacts left join C_Involved_projectUnit on C_Contacts.C_Contacts_code=C_Involved_projectUnit.C_Involved_projectUnit_charger where C_Contacts_isDelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" C_Involved_projectUnit_id,C_Involved_projectUnit_code,C_Involved_project_code,C_Involved_projectUnit_Child,C_Involved_projectUnit_rival_type,C_Involved_projectUnit_rival,C_Involved_projectUnit_type,C_Involved_projectUnit_fundsSource,C_Involved_projectUnit_charger,C_Involved_projectUnit_chargerIdentity,C_Involved_projectUnit_chargerOrgan,C_Involved_projectUnit_chargerFundsSource,C_Involved_projectUnit_startTime,C_Involved_projectUnit_acceptanceTime,C_Involved_projectUnit_process,C_Involved_projectUnit_accidents,C_Involved_projectUnit_qualityAccidents,C_Involved_projectUnit_litigation,C_Involved_projectUnit_lossOrProfit,C_Involved_projectUnit_lossReason,C_Involved_projectUnit_creator,C_Involved_projectUnit_createTime,C_Involved_projectUnit_isDelete ");
			strSql.Append(" FROM C_Involved_projectUnit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(Model.C_Involved_projectUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Involved_projectUnit ");
            strSql.Append(" where 1=1 and C_Involved_projectUnit_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Involved_projectUnit_code != null)
                {
                    strSql.Append("and C_Involved_projectUnit_code=@C_Involved_projectUnit_code");
                }
                if (model.C_Involved_project_code != null)
                {
                    strSql.Append("and C_Involved_project_code=@C_Involved_project_code");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Involved_projectUnit_code;
            parameters[1].Value = model.C_Involved_project_code;
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public DataSet GetListByPage(Model.C_Involved_projectUnit model, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.C_Involved_projectUnit_id desc");
			}
            strSql.Append(")AS Row, T.*,case when C_Involved_projectUnit_rival_type=0 then (select C_CRival_name from C_CRival where C_CRival_code=C_Involved_projectUnit_rival) ");
            strSql.Append("when C_Involved_projectUnit_rival_type=1 then (select C_PRival_name from C_PRival where C_PRival_code=C_Involved_projectUnit_rival) ");
            strSql.Append("end as C_Involved_projectUnit_rivalname ");
            strSql.Append("from C_Involved_projectUnit T ");
            strSql.Append(" where 1=1 and C_Involved_projectUnit_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Involved_projectUnit_code != null)
                {
                    strSql.Append("and C_Involved_projectUnit_code=@C_Involved_projectUnit_code");
                }
                if (model.C_Involved_project_code != null)
                {
                    strSql.Append("and C_Involved_project_code=@C_Involved_project_code");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Involved_projectUnit_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Involved_project_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Involved_projectUnit_code;
            parameters[1].Value = model.C_Involved_project_code;
			return DbHelperSQL.Query(strSql.ToString(),parameters);
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
			parameters[0].Value = "C_Involved_projectUnit";
			parameters[1].Value = "C_Involved_projectUnit_id";
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

