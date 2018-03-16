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
    /// 数据访问类:(企业)法律对手信息表
    /// 作者：崔慧栋
    /// 日期：2015/04/24
    /// </summary>
    public partial class C_CRival
    {
        public C_CRival()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_CRival_id", "C_CRival");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_CRival_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_CRival");
            strSql.Append(" where C_CRival_id=@C_CRival_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_CRival_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

          /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(CommonService.Model.C_CRival model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_CRival");
            strSql.Append(" where C_CRival_name=@C_CRival_name");
            strSql.Append(" and C_CRival_isdelete=0");
            if(model.C_CRival_id > 0)
            {
                strSql.Append(" and C_CRival_code<>@C_CRival_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_name", SqlDbType.NVarChar),
                    new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_CRival_name;
            parameters[1].Value = model.C_CRival_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_CRival model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_CRival(");
            strSql.Append("C_CRival_code,C_CRival_number,C_CRival_name,C_CRival_iland,C_CRival_aland,C_CRival_fregtime,C_CRival_ftype,C_CRival_rassets,C_CRival_corgan,C_CRival_acase,C_CRival_smodel,C_CRival_mitem,");
            strSql.Append("C_CRival_eitem,C_CRival_phone,C_CRival_link,C_CRival_email,C_CRival_ehonor,C_CRival_isdelete,C_CRival_cdate,C_CRival_cuserid)");
            strSql.Append(" values (");
            strSql.Append("@C_CRival_code,@C_CRival_number,@C_CRival_name,@C_CRival_iland,@C_CRival_aland,@C_CRival_fregtime,@C_CRival_ftype,@C_CRival_rassets,@C_CRival_corgan,@C_CRival_acase,@C_CRival_smodel,@C_CRival_mitem,");
            strSql.Append("@C_CRival_eitem,@C_CRival_phone,@C_CRival_link,@C_CRival_email,@C_CRival_ehonor,@C_CRival_isdelete,@C_CRival_cdate,@C_CRival_cuserid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_iland", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_aland", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_fregtime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_ftype", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_rassets", SqlDbType.Decimal,100),
					new SqlParameter("@C_CRival_corgan", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_acase", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_smodel", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_mitem", SqlDbType.VarChar,200),
                                        
                    new SqlParameter("@C_CRival_eitem", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_phone", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_link", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_email", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_ehonor", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_isdelete", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_cdate", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_cuserid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_CRival_code;
            parameters[1].Value = model.C_CRival_number;
            parameters[2].Value = model.C_CRival_name;
            parameters[3].Value = model.C_CRival_iland;
            parameters[4].Value = model.C_CRival_aland;
            parameters[5].Value = model.C_CRival_fregtime;
            parameters[6].Value = model.C_CRival_ftype;
            parameters[7].Value = model.C_CRival_rassets;
            parameters[8].Value = model.C_CRival_corgan;
            parameters[9].Value = model.C_CRival_acase;
            parameters[10].Value = model.C_CRival_smodel;
            parameters[11].Value = model.C_CRival_mitem;
            parameters[12].Value = model.C_CRival_eitem;
            parameters[13].Value = model.C_CRival_phone;
            parameters[14].Value = model.C_CRival_link;
            parameters[15].Value = model.C_CRival_email;
            parameters[16].Value = model.C_CRival_ehonor;
            parameters[17].Value = model.C_CRival_isdelete;
            parameters[18].Value = model.C_CRival_cdate;
            parameters[19].Value = model.C_CRival_cuserid;

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
        public bool Update(CommonService.Model.C_CRival model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_CRival set ");
            strSql.Append("C_CRival_code=@C_CRival_code,");
            strSql.Append("C_CRival_number=@C_CRival_number,");
            strSql.Append("C_CRival_name=@C_CRival_name,");
            strSql.Append("C_CRival_iland=@C_CRival_iland,");
            strSql.Append("C_CRival_aland=@C_CRival_aland,");
            strSql.Append("C_CRival_fregtime=@C_CRival_fregtime,");
            strSql.Append("C_CRival_ftype=@C_CRival_ftype,");
            strSql.Append("C_CRival_rassets=@C_CRival_rassets,");
            strSql.Append("C_CRival_corgan=@C_CRival_corgan,");
            strSql.Append("C_CRival_acase=@C_CRival_acase,");
            strSql.Append("C_CRival_smodel=@C_CRival_smodel,");

            strSql.Append("C_CRival_mitem=@C_CRival_mitem,");
            strSql.Append("C_CRival_eitem=@C_CRival_eitem,");
            strSql.Append("C_CRival_phone=@C_CRival_phone,");
            strSql.Append("C_CRival_link=@C_CRival_link,");
            strSql.Append("C_CRival_email=@C_CRival_email,");
            strSql.Append("C_CRival_ehonor=@C_CRival_ehonor,");
            strSql.Append("C_CRival_isdelete=@C_CRival_isdelete,");
            strSql.Append("C_CRival_cdate=@C_CRival_cdate,");
            strSql.Append("C_CRival_cuserid=@C_CRival_cuserid");
            strSql.Append(" where C_CRival_id=@C_CRival_id");
           SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_iland", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_aland", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_fregtime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_ftype", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_rassets", SqlDbType.Decimal,100),
					new SqlParameter("@C_CRival_corgan", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_acase", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_smodel", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_mitem", SqlDbType.VarChar,200),
                                        
                    new SqlParameter("@C_CRival_eitem", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_phone", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_link", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_email", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_ehonor", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_isdelete", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_cdate", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_cuserid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_CRival_id",SqlDbType.Int,4)};
            parameters[0].Value = model.C_CRival_code;
            parameters[1].Value = model.C_CRival_number;
            parameters[2].Value = model.C_CRival_name;
            parameters[3].Value = model.C_CRival_iland;
            parameters[4].Value = model.C_CRival_aland;
            parameters[5].Value = model.C_CRival_fregtime;
            parameters[6].Value = model.C_CRival_ftype;
            parameters[7].Value = model.C_CRival_rassets;
            parameters[8].Value = model.C_CRival_corgan;
            parameters[9].Value = model.C_CRival_acase;
            parameters[10].Value = model.C_CRival_smodel;
            parameters[11].Value = model.C_CRival_mitem;
            parameters[12].Value = model.C_CRival_eitem;
            parameters[13].Value = model.C_CRival_phone;
            parameters[14].Value = model.C_CRival_link;
            parameters[15].Value = model.C_CRival_email;
            parameters[16].Value = model.C_CRival_ehonor;
            parameters[17].Value = model.C_CRival_isdelete;
            parameters[18].Value = model.C_CRival_cdate;
            parameters[19].Value = model.C_CRival_cuserid;
            parameters[20].Value = model.C_CRival_id;

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
        public bool Delete(Guid C_CRival_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_CRival set C_CRival_isdelete=1");
            strSql.Append(" where C_CRival_code=@C_CRival_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_CRival_code;

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
        public bool DeleteList(string C_CRival_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_CRival ");
            strSql.Append(" where C_CRival_id in (" + C_CRival_idlist + ")  ");
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
        public CommonService.Model.C_CRival GetModel(int C_CRival_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_CRival_id,C_CRival_code,C_CRival_number,C_CRival_name,C_CRival_iland,C_CRival_aland,C_CRival_fregtime,C_CRival_ftype,C_CRival_rassets,C_CRival_corgan,C_CRival_acase,C_CRival_smodel,C_CRival_mitem,");
            strSql.Append("C_CRival_eitem,C_CRival_phone,C_CRival_link,C_CRival_email,C_CRival_ehonor,C_CRival_isdelete,C_CRival_cdate,C_CRival_cuserid from C_CRival");
            strSql.Append(" where C_CRival_id=@C_CRival_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_CRival_id;

            CommonService.Model.C_CRival model = new CommonService.Model.C_CRival();
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
        public CommonService.Model.C_CRival GetModel(Guid C_CRival_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_CRival_id,C_CRival_code,C_CRival_number,C_CRival_name,C_CRival_iland,C_CRival_aland,C_CRival_fregtime,C_CRival_ftype,C_CRival_rassets,C_CRival_corgan,C_CRival_acase,C_CRival_smodel,C_CRival_mitem,");
            strSql.Append("C_CRival_eitem,C_CRival_phone,C_CRival_link,C_CRival_email,C_CRival_ehonor,C_CRival_isdelete,C_CRival_cdate,C_CRival_cuserid from C_CRival");
            strSql.Append(" where C_CRival_code=@C_CRival_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_CRival_code;

            CommonService.Model.C_CRival model = new CommonService.Model.C_CRival();
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
        public CommonService.Model.C_CRival DataRowToModel(DataRow row)
        {
            CommonService.Model.C_CRival model = new CommonService.Model.C_CRival();
            if (row != null)
            {
                if (row["C_CRival_id"] != null && row["C_CRival_id"].ToString() != "")
                {
                    model.C_CRival_id = int.Parse(row["C_CRival_id"].ToString());
                }
                if (row["C_CRival_code"] != null && row["C_CRival_code"].ToString() != "")
                {
                    model.C_CRival_code = new Guid(row["C_CRival_code"].ToString());
                }
                if (row["C_CRival_number"] != null)
                {
                    model.C_CRival_number = row["C_CRival_number"].ToString();
                }
                if (row["C_CRival_name"] != null)
                {
                    model.C_CRival_name = row["C_CRival_name"].ToString();
                }
                if (row["C_CRival_iland"] != null)
                {
                    model.C_CRival_iland = row["C_CRival_iland"].ToString();
                }
                if (row["C_CRival_aland"] != null)
                {
                    model.C_CRival_aland = row["C_CRival_aland"].ToString();
                }
                if (row["C_CRival_fregtime"] != null && row["C_CRival_fregtime"].ToString()!="")
                {
                    model.C_CRival_fregtime =DateTime.Parse(row["C_CRival_fregtime"].ToString());
                }
                if (row["C_CRival_ftype"] != null && row["C_CRival_ftype"].ToString()!="")
                {
                    model.C_CRival_ftype =int.Parse(row["C_CRival_ftype"].ToString());
                }
                if (row["C_CRival_rassets"] != null && row["C_CRival_rassets"].ToString()!="")
                {
                    model.C_CRival_rassets =decimal.Parse(row["C_CRival_rassets"].ToString());
                }
                if (row["C_CRival_corgan"] != null && row["C_CRival_corgan"].ToString()!="")
                {
                    model.C_CRival_corgan =int.Parse(row["C_CRival_corgan"].ToString());
                }
                if (row["C_CRival_acase"] != null)
                {
                    model.C_CRival_acase = row["C_CRival_acase"].ToString();
                }
                if (row["C_CRival_smodel"] != null && row["C_CRival_smodel"].ToString() != "")
                {
                    model.C_CRival_smodel = int.Parse(row["C_CRival_smodel"].ToString());
                }
                if (row["C_CRival_mitem"] != null)
                {
                    model.C_CRival_mitem = row["C_CRival_mitem"].ToString();
                }
                if (row["C_CRival_eitem"] != null)
                {
                    model.C_CRival_eitem = row["C_CRival_eitem"].ToString();
                }
                if (row["C_CRival_phone"] != null)
                {
                    model.C_CRival_phone = row["C_CRival_phone"].ToString();
                }
                if (row["C_CRival_link"] != null)
                {
                    model.C_CRival_link = row["C_CRival_link"].ToString();
                }
                if (row["C_CRival_email"] != null)
                {
                    model.C_CRival_email = row["C_CRival_email"].ToString();
                }
                if (row["C_CRival_ehonor"] != null)
                {
                    model.C_CRival_ehonor = row["C_CRival_ehonor"].ToString();
                }
                if (row["C_CRival_isdelete"] != null)
                {
                    model.C_CRival_isdelete = int.Parse(row["C_CRival_isdelete"].ToString());
                }
                if (row["C_CRival_cdate"] != null && row["C_CRival_cdate"].ToString() != "")
                {
                    model.C_CRival_cdate = DateTime.Parse(row["C_CRival_cdate"].ToString());
                }
                if (row["C_CRival_cuserid"] != null && row["C_CRival_cuserid"].ToString() != "")
                {
                    model.C_CRival_cuserid = new Guid(row["C_CRival_cuserid"].ToString());
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
            strSql.Append("select C_CRival_id,C_CRival_code,C_CRival_number,C_CRival_name,C_CRival_iland,C_CRival_aland,C_CRival_fregtime,C_CRival_ftype,C_CRival_rassets,C_CRival_corgan,C_CRival_acase,C_CRival_smodel,C_CRival_mitem,");
            strSql.Append("C_CRival_eitem,C_CRival_phone,C_CRival_link,C_CRival_email,C_CRival_ehonor,C_CRival_isdelete,C_CRival_cdate,C_CRival_cuserid");
            strSql.Append(" FROM C_CRival ");
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
            strSql.Append("C_CRival_id,C_CRival_code,C_CRival_number,C_CRival_name,C_CRival_iland,C_CRival_aland,C_CRival_fregtime,C_CRival_ftype,C_CRival_rassets,C_CRival_corgan,C_CRival_acase,C_CRival_smodel,C_CRival_mitem,");
            strSql.Append("C_CRival_eitem,C_CRival_phone,C_CRival_link,C_CRival_email,C_CRival_ehonor,C_CRival_isdelete,C_CRival_cdate,C_CRival_cuserid");
            strSql.Append(" FROM C_CRival ");
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
        public int GetRecordCount(Model.C_CRival model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_CRival ");
            strSql.Append(" where 1=1 and C_CRival_isdelete=0 ");
            if (model != null)
            {
                if (model.C_CRival_code != null)
                {
                    strSql.Append("and C_CRival_code=@C_CRival_code");
                }
                if (model.C_CRival_name != null)
                {
                    strSql.Append("and C_CRival_name like N'%'+@C_CRival_name+'%' ");
                }
                if (model.C_CRival_fregtime != null)
                {
                    strSql.Append("and C_CRival_fregtime=@C_CRival_fregtime");
                }
                if (model.C_CRival_ftype != null)
                {
                    strSql.Append("and C_CRival_ftype=@C_CRival_ftype");
                }
                if (model.C_CRival_rassets != null)
                {
                    strSql.Append("and C_CRival_rassets=@C_CRival_rassets");
                }
                if (model.C_CRival_corgan != null)
                {
                    strSql.Append("and C_CRival_corgan=@C_CRival_corgan");
                }
                if (model.C_CRival_smodel != null)
                {
                    strSql.Append("and C_CRival_smodel=@C_CRival_smodel");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_iland", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_aland", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_fregtime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_ftype", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_rassets", SqlDbType.Decimal,100),
					new SqlParameter("@C_CRival_corgan", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_smodel", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_mitem", SqlDbType.VarChar,200),
                    new SqlParameter("@C_CRival_eitem", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_cdate", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_cuserid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_CRival_code;
            parameters[1].Value = model.C_CRival_number;
            parameters[2].Value = model.C_CRival_name;
            parameters[3].Value = model.C_CRival_iland;
            parameters[4].Value = model.C_CRival_aland;
            parameters[5].Value = model.C_CRival_fregtime;
            parameters[6].Value = model.C_CRival_ftype;
            parameters[7].Value = model.C_CRival_rassets;
            parameters[8].Value = model.C_CRival_corgan;
            parameters[9].Value = model.C_CRival_smodel;
            parameters[10].Value = model.C_CRival_mitem;
            parameters[11].Value = model.C_CRival_eitem;
            parameters[12].Value = model.C_CRival_cdate;
            parameters[13].Value = model.C_CRival_cuserid;
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
        public DataSet GetListByPage(Model.C_CRival model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_CRival_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_CRival T ");
            strSql.Append(" where 1=1 and C_CRival_isdelete=0 ");
            if (model != null)
            {
                if (model.C_CRival_code != null)
                {
                    strSql.Append(" and C_CRival_code=@C_CRival_code");
                }
                if (model.C_CRival_name != null)
                {
                    strSql.Append(" and C_CRival_name like N'%'+@C_CRival_name+'%' ");
                }
                if (model.C_CRival_fregtime != null)
                {
                    strSql.Append(" and C_CRival_fregtime=@C_CRival_fregtime");
                }
                if (model.C_CRival_ftype != null)
                {
                    strSql.Append(" and C_CRival_ftype=@C_CRival_ftype");
                }
                if (model.C_CRival_rassets != null)
                {
                    strSql.Append(" and C_CRival_rassets=@C_CRival_rassets");
                }
                if (model.C_CRival_corgan != null)
                {
                    strSql.Append(" and C_CRival_corgan=@C_CRival_corgan");
                }
                if (model.C_CRival_smodel != null)
                {
                    strSql.Append(" and C_CRival_smodel=@C_CRival_smodel");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_CRival_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_iland", SqlDbType.VarChar,200),
					new SqlParameter("@C_CRival_aland", SqlDbType.VarChar,100),
					new SqlParameter("@C_CRival_fregtime", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_ftype", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_rassets", SqlDbType.Decimal,100),
					new SqlParameter("@C_CRival_corgan", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_smodel", SqlDbType.Int,4),
					new SqlParameter("@C_CRival_mitem", SqlDbType.VarChar,200),
                    new SqlParameter("@C_CRival_eitem", SqlDbType.VarChar,200),
                    new SqlParameter("@C_CRival_phone", SqlDbType.VarChar,50),
					new SqlParameter("@C_CRival_cdate", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_cuserid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_CRival_udate", SqlDbType.DateTime),
					new SqlParameter("@C_CRival_uuserid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_CRival_code;
            parameters[1].Value = model.C_CRival_number;
            parameters[2].Value = model.C_CRival_name;
            parameters[3].Value = model.C_CRival_iland;
            parameters[4].Value = model.C_CRival_aland;
            parameters[5].Value = model.C_CRival_fregtime;
            parameters[6].Value = model.C_CRival_ftype;
            parameters[7].Value = model.C_CRival_rassets;
            parameters[8].Value = model.C_CRival_corgan;
            parameters[9].Value = model.C_CRival_smodel;
            parameters[10].Value = model.C_CRival_mitem;
            parameters[11].Value = model.C_CRival_eitem;
            parameters[12].Value = model.C_CRival_phone;
            parameters[13].Value = model.C_CRival_cdate;
            parameters[14].Value = model.C_CRival_cuserid;
            
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
            parameters[0].Value = "C_CRival";
            parameters[1].Value = "C_CRival_id";
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
