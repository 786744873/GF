using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:(企业)法律对手个人信息表
    /// 作者：崔慧栋
    /// 日期：2015/05/07
    /// </summary>
	public partial class C_PRival
	{
		public C_PRival()
		{}
		#region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_PRival_id", "C_PRival");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_PRival_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_PRival");
            strSql.Append(" where C_PRival_id=@C_PRival_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_PRival_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

          /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(CommonService.Model.C_PRival model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_PRival");
            strSql.Append(" where C_PRival_name=@C_PRival_name");
            strSql.Append(" and C_PRival_isDelete=0");
            if(model.C_PRival_id > 0)
            {
                strSql.Append(" and C_PRival_code<>@C_PRival_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_name", SqlDbType.NVarChar),
                    new SqlParameter("@C_PRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_PRival_name;
            parameters[1].Value = model.C_PRival_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CommonService.Model.C_PRival model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_PRival(");
            strSql.Append("C_PRival_code,C_PRival_pcode,C_PRival_number,C_PRival_name,C_PRival_sex,C_PRival_birthday,C_PRival_nation,C_PRival_hometown,C_PRival_pa,C_PRival_address,C_PRival_cnumber,C_PRival_phone,C_PRival_traits,C_PRival_hobby,C_PRival_type,C_PRival_creator,C_PRival_createTime,C_PRival_isDelete)");
			strSql.Append(" values (");
            strSql.Append("@C_PRival_code,@C_PRival_pcode,@C_PRival_number,@C_PRival_name,@C_PRival_sex,@C_PRival_birthday,@C_PRival_nation,@C_PRival_hometown,@C_PRival_pa,@C_PRival_address,@C_PRival_cnumber,@C_PRival_phone,@C_PRival_traits,@C_PRival_hobby,@C_PRival_type,@C_PRival_creator,@C_PRival_createTime,@C_PRival_isDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_PRival_pcode",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_PRival_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_sex", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_PRival_nation", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_hometown", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_pa", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_cnumber", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_phone", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_traits", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_hobby", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_type", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_PRival_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_PRival_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.C_PRival_code;
            parameters[1].Value = model.C_PRival_pcode;
			parameters[2].Value = model.C_PRival_number;
			parameters[3].Value = model.C_PRival_name;
			parameters[4].Value = model.C_PRival_sex;
			parameters[5].Value = model.C_PRival_birthday;
			parameters[6].Value = model.C_PRival_nation;
			parameters[7].Value = model.C_PRival_hometown;
			parameters[8].Value = model.C_PRival_pa;
			parameters[9].Value = model.C_PRival_address;
			parameters[10].Value = model.C_PRival_cnumber;
			parameters[11].Value = model.C_PRival_phone;
			parameters[12].Value = model.C_PRival_traits;
			parameters[13].Value = model.C_PRival_hobby;
			parameters[14].Value = model.C_PRival_type;
            parameters[15].Value = model.C_PRival_creator;
			parameters[16].Value = model.C_PRival_createTime;
			parameters[17].Value = model.C_PRival_isDelete;

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
        public bool Update(CommonService.Model.C_PRival model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_PRival set ");
			strSql.Append("C_PRival_code=@C_PRival_code,");
            strSql.Append("C_PRival_pcode=@C_PRival_pcode,");
			strSql.Append("C_PRival_number=@C_PRival_number,");
			strSql.Append("C_PRival_name=@C_PRival_name,");
			strSql.Append("C_PRival_sex=@C_PRival_sex,");
			strSql.Append("C_PRival_birthday=@C_PRival_birthday,");
			strSql.Append("C_PRival_nation=@C_PRival_nation,");
			strSql.Append("C_PRival_hometown=@C_PRival_hometown,");
			strSql.Append("C_PRival_pa=@C_PRival_pa,");
			strSql.Append("C_PRival_address=@C_PRival_address,");
			strSql.Append("C_PRival_cnumber=@C_PRival_cnumber,");
			strSql.Append("C_PRival_phone=@C_PRival_phone,");
			strSql.Append("C_PRival_traits=@C_PRival_traits,");
			strSql.Append("C_PRival_hobby=@C_PRival_hobby,");
			strSql.Append("C_PRival_type=@C_PRival_type,");
			strSql.Append("C_PRival_creator=@C_PRival_creator,");
			strSql.Append("C_PRival_createTime=@C_PRival_createTime,");
			strSql.Append("C_PRival_isDelete=@C_PRival_isDelete");
			strSql.Append(" where C_PRival_id=@C_PRival_id");
			SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_PRival_pcode",SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_PRival_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_sex", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_PRival_nation", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_hometown", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_pa", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_cnumber", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_phone", SqlDbType.VarChar,50),
					new SqlParameter("@C_PRival_traits", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_hobby", SqlDbType.VarChar,200),
					new SqlParameter("@C_PRival_type", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_PRival_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_PRival_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_PRival_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_PRival_code;
            parameters[1].Value = model.C_PRival_pcode;
            parameters[2].Value = model.C_PRival_number;
            parameters[3].Value = model.C_PRival_name;
            parameters[4].Value = model.C_PRival_sex;
            parameters[5].Value = model.C_PRival_birthday;
            parameters[6].Value = model.C_PRival_nation;
            parameters[7].Value = model.C_PRival_hometown;
            parameters[8].Value = model.C_PRival_pa;
            parameters[9].Value = model.C_PRival_address;
            parameters[10].Value = model.C_PRival_cnumber;
            parameters[11].Value = model.C_PRival_phone;
            parameters[12].Value = model.C_PRival_traits;
            parameters[13].Value = model.C_PRival_hobby;
            parameters[14].Value = model.C_PRival_type;
            parameters[15].Value = model.C_PRival_creator;
            parameters[16].Value = model.C_PRival_createTime;
            parameters[17].Value = model.C_PRival_isDelete;
            parameters[18].Value = model.C_PRival_id;

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
        public bool Delete(Guid C_PRival_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update C_PRival set C_PRival_isDelete=1 ");
            strSql.Append(" where C_PRival_code=@C_PRival_code");
			SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_PRival_code;

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
		public bool DeleteList(string C_PRival_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_PRival ");
			strSql.Append(" where C_PRival_id in ("+C_PRival_idlist + ")  ");
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
        public CommonService.Model.C_PRival GetModelByPcode(Guid C_PRival_code)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 C_PRival_id,C_PRival_code,C_PRival_pcode,C_PRival_number,C_PRival_name,C_PRival_sex,C_PRival_birthday,C_PRival_nation,C_PRival_hometown,C_PRival_pa,C_PRival_address,C_PRival_cnumber,C_PRival_phone,C_PRival_traits,C_PRival_hobby,C_PRival_type,C_PRival_creator,C_PRival_createTime,C_PRival_isDelete from C_PRival ");
            strSql.Append(" where C_PRival_pcode=@C_PRival_code and C_PRival_isDelete=0");
			SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_PRival_code;

            CommonService.Model.C_PRival model = new CommonService.Model.C_PRival();
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
        public CommonService.Model.C_PRival GetModel(Guid C_PRival_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PR.C_PRival_id,PR.C_PRival_code,PR.C_PRival_pcode,PR.C_PRival_number,PR.C_PRival_name,PR.C_PRival_sex,PR.C_PRival_birthday,PR.C_PRival_nation,PR.C_PRival_hometown,PR.C_PRival_pa,PR.C_PRival_address,PR.C_PRival_cnumber,PR.C_PRival_phone,PR.C_PRival_traits,PR.C_PRival_hobby,PR.C_PRival_type,PR.C_PRival_creator,PR.C_PRival_createTime,PR.C_PRival_isDelete,P.C_Parameters_name as 'C_PRival_nation_name',P1.C_Parameters_name as 'C_PRival_pa_name' ");
            strSql.Append("from C_PRival as PR left join C_Parameters as P on PR.C_PRival_nation=P.C_Parameters_id ");
            strSql.Append("left join C_Parameters as P1 on PR.C_PRival_pa=P1.C_Parameters_id ");
            strSql.Append(" where PR.C_PRival_code=@C_PRival_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_PRival_code;

            CommonService.Model.C_PRival model = new CommonService.Model.C_PRival();
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
        public CommonService.Model.C_PRival DataRowToModel(DataRow row)
		{
            CommonService.Model.C_PRival model = new CommonService.Model.C_PRival();
			if (row != null)
			{
				if(row["C_PRival_id"]!=null && row["C_PRival_id"].ToString()!="")
				{
					model.C_PRival_id=int.Parse(row["C_PRival_id"].ToString());
				}
				if(row["C_PRival_code"]!=null && row["C_PRival_code"].ToString()!="")
				{
					model.C_PRival_code= new Guid(row["C_PRival_code"].ToString());
				}
                if (row["C_PRival_pcode"] != null && row["C_PRival_pcode"].ToString() != "")
                {
                    model.C_PRival_pcode = new Guid(row["C_PRival_pcode"].ToString());
                }
				if(row["C_PRival_number"]!=null)
				{
					model.C_PRival_number=row["C_PRival_number"].ToString();
				}
				if(row["C_PRival_name"]!=null)
				{
					model.C_PRival_name=row["C_PRival_name"].ToString();
				}
				if(row["C_PRival_sex"]!=null && row["C_PRival_sex"].ToString()!="")
				{
					model.C_PRival_sex=int.Parse(row["C_PRival_sex"].ToString());
				}
				if(row["C_PRival_birthday"]!=null && row["C_PRival_birthday"].ToString()!="")
				{
					model.C_PRival_birthday=DateTime.Parse(row["C_PRival_birthday"].ToString());
				}
				if(row["C_PRival_nation"]!=null && row["C_PRival_nation"].ToString()!="")
				{
					model.C_PRival_nation=int.Parse(row["C_PRival_nation"].ToString());
				}
				if(row["C_PRival_hometown"]!=null)
				{
					model.C_PRival_hometown=row["C_PRival_hometown"].ToString();
				}
				if(row["C_PRival_pa"]!=null && row["C_PRival_pa"].ToString()!="")
				{
					model.C_PRival_pa=int.Parse(row["C_PRival_pa"].ToString());
				}
				if(row["C_PRival_address"]!=null)
				{
					model.C_PRival_address=row["C_PRival_address"].ToString();
				}
				if(row["C_PRival_cnumber"]!=null)
				{
					model.C_PRival_cnumber=row["C_PRival_cnumber"].ToString();
				}
				if(row["C_PRival_phone"]!=null)
				{
					model.C_PRival_phone=row["C_PRival_phone"].ToString();
				}
				if(row["C_PRival_traits"]!=null)
				{
					model.C_PRival_traits=row["C_PRival_traits"].ToString();
				}
				if(row["C_PRival_hobby"]!=null)
				{
					model.C_PRival_hobby=row["C_PRival_hobby"].ToString();
				}
				if(row["C_PRival_type"]!=null && row["C_PRival_type"].ToString()!="")
				{
					model.C_PRival_type=int.Parse(row["C_PRival_type"].ToString());
				}
				if(row["C_PRival_creator"]!=null && row["C_PRival_creator"].ToString()!="")
				{
					model.C_PRival_creator= new Guid(row["C_PRival_creator"].ToString());
				}
				if(row["C_PRival_createTime"]!=null && row["C_PRival_createTime"].ToString()!="")
				{
					model.C_PRival_createTime=DateTime.Parse(row["C_PRival_createTime"].ToString());
				}
				if(row["C_PRival_isDelete"]!=null && row["C_PRival_isDelete"].ToString()!="")
				{
					model.C_PRival_isDelete=int.Parse(row["C_PRival_isDelete"].ToString());
				}
                //判断民族名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_PRival_nation_name"))
                {
                    if (row["C_PRival_nation_name"] != null && row["C_PRival_nation_name"].ToString() != "")
                    {
                        model.C_PRival_nation_name = row["C_PRival_nation_name"].ToString();
                    }
                }
                //判断政治面貌（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_PRival_pa_name"))
                {
                    if (row["C_PRival_pa_name"] != null && row["C_PRival_pa_name"].ToString() != "")
                    {
                        model.C_PRival_pa_name=row["C_PRival_pa_name"].ToString();
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select C_PRival_id,C_PRival_code,C_PRival_pcode,C_PRival_number,C_PRival_name,C_PRival_sex,C_PRival_birthday,C_PRival_nation,C_PRival_hometown,C_PRival_pa,C_PRival_address,C_PRival_cnumber,C_PRival_phone,C_PRival_traits,C_PRival_hobby,C_PRival_type,C_PRival_creator,C_PRival_createTime,C_PRival_isDelete ");
			strSql.Append(" FROM C_PRival ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
            strSql.Append(" C_PRival_id,C_PRival_code,C_PRival_pcode,C_PRival_number,C_PRival_name,C_PRival_sex,C_PRival_birthday,C_PRival_nation,C_PRival_hometown,C_PRival_pa,C_PRival_address,C_PRival_cnumber,C_PRival_phone,C_PRival_traits,C_PRival_hobby,C_PRival_type,C_PRival_creator,C_PRival_createTime,C_PRival_isDelete ");
			strSql.Append(" FROM C_PRival ");
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
		public int GetRecordCount(Model.C_PRival model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_PRival ");
            strSql.Append(" where 1=1 and C_PRival_isDelete=0 ");
            if (model != null)
            {
                if (model.C_PRival_name != null)
                {
                    strSql.Append("and C_PRival_name like N'%'+@C_PRival_name+'%' ");
                }
                if (model.C_PRival_type != null)
                {
                    strSql.Append("and C_PRival_type=@C_PRival_type ");
                }
                if (model.C_PRival_pcode != null)
                {
                    strSql.Append("and C_PRival_pcode=@C_PRival_pcode ");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_PRival_type",SqlDbType.Int,4),
                    new SqlParameter("@C_PRival_pcode",SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.C_PRival_name;
            parameters[1].Value = model.C_PRival_type;
            parameters[2].Value = model.C_PRival_pcode;
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
		public DataSet GetListByPage(Model.C_PRival model, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.C_PRival_id desc");
			}
            strSql.Append(")AS Row, T.*  from C_PRival T ");
            strSql.Append(" where 1=1 and C_PRival_isDelete=0 ");
            if (model != null)
            {
                if (model.C_PRival_name != null)
                {
                    strSql.Append("and C_PRival_name like N'%'+@C_PRival_name+'%' ");
                }
                if (model.C_PRival_type != null)
                {
                    strSql.Append("and C_PRival_type=@C_PRival_type ");
                }
                if (model.C_PRival_pcode != null)
                {
                    strSql.Append("and C_PRival_pcode=@C_PRival_pcode ");
                }
            }
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_PRival_name", SqlDbType.VarChar,50),
                    new SqlParameter("@C_PRival_type",SqlDbType.Int,4),
                    new SqlParameter("@C_PRival_pcode",SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.C_PRival_name;
            parameters[1].Value = model.C_PRival_type;
            parameters[2].Value = model.C_PRival_pcode;
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
			parameters[0].Value = "C_PRival";
			parameters[1].Value = "C_PRival_id";
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

