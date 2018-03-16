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
    /// 数据访问类:法院表
    /// 作者：崔慧栋
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Court
    {
        public C_Court()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Court_id", "C_Court");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Court_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Court");
            strSql.Append(" where C_Court_id=@C_Court_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Court_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

         /// <summary>
        /// 是否存在该记录(根据名称)
        /// </summary>
        public bool ExistsByName(CommonService.Model.C_Court model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Court");
            strSql.Append(" where C_Court_isdelete=0");
            strSql.Append(" and C_Court_name=@C_Court_name");
            if (model.C_Court_id > 0)
            {
                strSql.Append(" and C_Court_code<>@C_Court_code");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_name", SqlDbType.NVarChar),
                    new SqlParameter("@C_Court_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = model.C_Court_name;
            parameters[1].Value = model.C_Court_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Court model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Court(");
            strSql.Append("C_Court_code,C_Court_number,C_Court_name,C_Court_area,C_Court_url,C_Court_address,C_Court_remark,C_Court_isdelete,C_Court_userid,C_Court_cdate,C_Court_isAllocate)");
            strSql.Append(" values (");
            strSql.Append("@C_Court_code,@C_Court_number,@C_Court_name,@C_Court_area,@C_Court_url,@C_Court_address,@C_Court_remark,@C_Court_isdelete,@C_Court_userid,@C_Court_cdate,@C_Court_isAllocate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Court_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_area", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_url", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_remark", SqlDbType.VarChar,500),
                    new SqlParameter("@C_Court_isdelete",SqlDbType.Int,4),
					new SqlParameter("@C_Court_userid", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Court_cdate",SqlDbType.DateTime),
                    new SqlParameter("@C_Court_isAllocate",SqlDbType.Bit)};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Court_number;
            parameters[2].Value = model.C_Court_name;
            parameters[3].Value = model.C_Court_area;
            parameters[4].Value = model.C_Court_url;
            parameters[5].Value = model.C_Court_address;
            parameters[6].Value = model.C_Court_remark;
            parameters[7].Value = model.C_Court_isdelete;
            parameters[8].Value = model.C_Court_userid;
            parameters[9].Value = model.C_Court_cdate;
            parameters[10].Value = model.C_Court_isAllocate;

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
        public bool Update(CommonService.Model.C_Court model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Court set ");
            strSql.Append("C_Court_code=@C_Court_code,");
            strSql.Append("C_Court_number=@C_Court_number,");
            strSql.Append("C_Court_name=@C_Court_name,");
            strSql.Append("C_Court_area=@C_Court_area,");
            strSql.Append("C_Court_url=@C_Court_url,");
            strSql.Append("C_Court_address=@C_Court_address,");
            strSql.Append("C_Court_remark=@C_Court_remark,");
            strSql.Append("C_Court_isdelete=@C_Court_isdelete,");
            strSql.Append("C_Court_userid=@C_Court_userid,");
            strSql.Append("C_Court_cdate=@C_Court_cdate,");
            strSql.Append("C_Court_isAllocate=@C_Court_isAllocate");
            strSql.Append(" where C_Court_id=@C_Court_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Court_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_area", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_url", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_remark", SqlDbType.VarChar,500),
                    new SqlParameter("@C_Court_isdelete",SqlDbType.Int,4),
					new SqlParameter("@C_Court_userid", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Court_cdate",SqlDbType.DateTime),
                    new SqlParameter("@C_Court_isAllocate",SqlDbType.Bit),
                    new SqlParameter("@C_Court_id",SqlDbType.Int,4)};
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Court_number;
            parameters[2].Value = model.C_Court_name;
            parameters[3].Value = model.C_Court_area;
            parameters[4].Value = model.C_Court_url;
            parameters[5].Value = model.C_Court_address;
            parameters[6].Value = model.C_Court_remark;
            parameters[7].Value = model.C_Court_isdelete;
            parameters[8].Value = model.C_Court_userid;
            parameters[9].Value = model.C_Court_cdate;
            parameters[10].Value = model.C_Court_isAllocate;
            parameters[11].Value = model.C_Court_id;

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
        public bool Delete(Guid C_Court_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Court set C_Court_isdelete=1");
            strSql.Append(" where C_Court_code=@C_Court_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Court_code;

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
        public bool DeleteList(string C_Court_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Court ");
            strSql.Append(" where C_Court_id in (" + C_Court_idlist + ")  ");
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
        public CommonService.Model.C_Court GetModel(int C_Court_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Court_id,C_Court_code,C_Court_number,C_Court_name,C_Court_area,C_Court_url,C_Court_address,C_Court_remark,C_Court_isAllocate,C_Court_isdelete,C_Court_userid,C_Court_cdate from C_Court ");
            strSql.Append(" where C_Court_id=@C_Court_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Court_id;

            CommonService.Model.C_Court model = new CommonService.Model.C_Court();
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
        public CommonService.Model.C_Court GetModel(Guid C_Court_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C.C_Court_id,C.C_Court_code,C.C_Court_number,C.C_Court_name,C.C_Court_area,C.C_Court_url,C.C_Court_address,C.C_Court_remark,C.C_Court_isAllocate,C.C_Court_isdelete,C.C_Court_userid,C.C_Court_cdate,R.C_Region_name as 'C_Court_area_name' ");
            strSql.Append(" from C_Court as C left join C_Region as R on C.C_Court_area=R.C_Region_code ");
            strSql.Append(" where C_Court_code=@C_Court_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = C_Court_code;

            CommonService.Model.C_Court model = new CommonService.Model.C_Court();
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
        public CommonService.Model.C_Court DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Court model = new CommonService.Model.C_Court();
            if (row != null)
            {
                if (row["C_Court_id"] != null && row["C_Court_id"].ToString() != "")
                {
                    model.C_Court_id = int.Parse(row["C_Court_id"].ToString());
                }
                if (row["C_Court_code"] != null)
                {
                    model.C_Court_code = new Guid(row["C_Court_code"].ToString());
                }
                if (row["C_Court_isAllocate"] != null && row["C_Court_isAllocate"].ToString() != "")
                {
                    if ((row["C_Court_isAllocate"].ToString() == "1") || (row["C_Court_isAllocate"].ToString().ToLower() == "true"))
                    {
                        model.C_Court_isAllocate = true;
                    }
                    else
                    {
                        model.C_Court_isAllocate = false;
                    }
                }
                if (row["C_Court_number"] != null)
                {
                    model.C_Court_number = row["C_Court_number"].ToString();
                }
                if (row["C_Court_name"] != null)
                {
                    model.C_Court_name = row["C_Court_name"].ToString();
                }
                if (row["C_Court_area"] != null && row["C_Court_area"].ToString() != "")
                {
                    model.C_Court_area = new Guid(row["C_Court_area"].ToString());
                }
                //判断法院区域名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Court_area_name"))
                {
                    if (row["C_Court_area_name"] != null && row["C_Court_area_name"].ToString() != "")
                    {
                        model.C_Court_area_name = row["C_Court_area_name"].ToString();
                    }
                }
                if (row["C_Court_url"] != null)
                {
                    model.C_Court_url = row["C_Court_url"].ToString();
                }
                if (row["C_Court_address"] != null)
                {
                    model.C_Court_address = row["C_Court_address"].ToString();
                }
                if (row["C_Court_remark"] != null)
                {
                    model.C_Court_remark = row["C_Court_remark"].ToString();
                }
                if (row["C_Court_isdelete"] != null && row["C_Court_isdelete"].ToString() != "")
                {
                    model.C_Court_isdelete = int.Parse(row["C_Court_isdelete"].ToString());
                }
                if (row["C_Court_userid"] != null && row["C_Court_userid"].ToString() != "")
                {
                    model.C_Court_userid = new Guid(row["C_Court_userid"].ToString());
                }
                if (row["C_Court_cdate"] != null && row["C_Court_cdate"].ToString() != "")
                {
                    model.C_Court_cdate = DateTime.Parse(row["C_Court_cdate"].ToString());
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
            strSql.Append("select C_Court_id,C_Court_code,C_Court_number,C_Court_name,C_Court_area,C_Court_url,C_Court_address,C_Court_remark,C_Court_isAllocate,C_Court_isdelete,C_Court_userid,C_Court_cdate ");
            strSql.Append(" FROM C_Court ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Court_id,C_Court_code,C_Court_number,C_Court_name,C_Court_area,C_Court_url,C_Court_address,C_Court_remark,C_Court_isAllocate,C_Court_isdelete,C_Court_userid,C_Court_cdate ");
            strSql.Append(" FROM C_Court where 1=1 and C_Court_isdelete=0 ");
            return DbHelperSQL.Query(strSql.ToString());
        }
          /// <summary>
        /// 获得律师对应区域数据列表
        /// </summary>
        public DataSet GetAllListByUserRegioncode(Guid userregioncode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Court_id,C_Court_code,C_Court_number,C_Court_name,C_Court_area,C_Court_url,C_Court_address,C_Court_remark,C_Court_isAllocate,C_Court_isdelete,C_Court_userid,C_Court_cdate ");
            strSql.Append(" FROM C_Court where 1=1 and C_Court_isdelete=0 and C_Court_area=@C_Court_area");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_area", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userregioncode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 根据律师获得关联数据列表
        /// </summary>
        /// <param name="Lawyer">律师Guid</param>
        /// <returns></returns>
        public DataSet GetAllListByLawyer(Guid Lawyer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C.C_Court_id,C.C_Court_code,C.C_Court_number,C.C_Court_name,C.C_Court_area,C.C_Court_url,C.C_Court_address,C.C_Court_remark,C.C_Court_isAllocate,C.C_Court_isdelete,C.C_Court_userid,C.C_Court_cdate ");
            strSql.Append(" FROM C_Court as C ");
            strSql.Append("left join C_Court_Lawyer CL on C.C_Court_code=CL.C_Court ");
            strSql.Append("where 1=1 and C.C_Court_isdelete=0 ");
            strSql.Append("and CL.C_Lawyer=@C_Lawyer ");
            strSql.Append("and CL.C_Court_Lawyer_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Lawyer", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = Lawyer;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获取法院数据列表
        /// </summary>
        /// <param name="Lawyer">律师Guid</param>
        /// <returns></returns>
        public DataSet GetListBylawyer(Guid lawyerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct T.C_Court_id,T.C_Court_code,T.C_Court_number,T.C_Court_name,T.C_Court_area,T.C_Court_url,T.C_Court_address,T.C_Court_remark,T.C_Court_isAllocate,T.C_Court_isdelete,T.C_Court_userid,T.C_Court_cdate ");
            strSql.Append(" FROM C_Court as T ");
            strSql.Append("left join B_Case as C on T.C_Court_code in (C.B_Case_courtFirst,C.B_Case_courtSecond,C.B_Case_courtExec,C.B_Case_Trial) ");
            strSql.Append("left join P_Business_flow as BF on BF.P_Fk_code=C.B_Case_code ");
            strSql.Append("left join P_Business_flow_form as BFF on BFF.P_Business_flow_code=BF.P_Business_flow_code ");
            strSql.Append("where 1=1 and C.B_Case_isDelete=0 and T.C_Court_isdelete=0 ");
            strSql.Append("and BFF.P_Business_flow_form_person=@C_Lawyer ");
            strSql.Append("or BF.P_Business_person=@C_Lawyer ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Lawyer", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = lawyerCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            strSql.Append(" C_Court_id,C_Court_code,C_Court_number,C_Court_name,C_Court_area,C_Court_url,C_Court_address,C_Court_remark,C_Court_isAllocate,C_Court_isdelete,C_Court_userid,C_Court_cdate ");
            strSql.Append(" FROM C_Court ");
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
        public int GetRecordCount(Model.C_Court model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Court ");
            strSql.Append(" where 1=1 and C_Court_isdelete=0 ");
            if (model != null)
            {

                if (model.C_Court_name != null && model.C_Court_name != "")
                {
                    strSql.Append(" and C_Court_name like N'%'+@C_Court_name+'%' ");
                }
                if (model.C_Court_area != null)
                {
                    strSql.Append(" and C_Court_area=@C_Court_area");
                }
                if (model.C_Court_address != null)
                {
                    strSql.Append(" and C_Court_address=@C_Court_address");
                }
                if (model.C_Court_regions != null)
                {
                    strSql.Append(" and charindex(','+cast(C_Court_area as nvarchar(2000))+',',','+@C_Court_regions+',')>0 ");
                }

            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Court_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_area", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_url", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_remark", SqlDbType.VarChar,500),
					new SqlParameter("@C_Court_userid", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Court_cdate",SqlDbType.DateTime),
                    new SqlParameter("@C_Court_id",SqlDbType.Int,4),
                    new SqlParameter("@C_Court_regions",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Court_number;
            parameters[2].Value = model.C_Court_name;
            parameters[3].Value = model.C_Court_area;
            parameters[4].Value = model.C_Court_url;
            parameters[5].Value = model.C_Court_address;
            parameters[6].Value = model.C_Court_remark;
            parameters[7].Value = model.C_Court_userid;
            parameters[8].Value = model.C_Court_cdate;
            parameters[9].Value = model.C_Court_id;
            parameters[10].Value = model.C_Court_regions;
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
        public DataSet GetListByPage(Model.C_Court model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Court_id desc");
            }
            strSql.Append(")AS Row, T.*,R.C_Region_name as 'C_Court_area_name' from C_Court T left join C_Region as R on T.C_Court_area=R.C_Region_code ");
            strSql.Append(" where 1=1 and C_Court_isdelete=0 ");
            if (model != null)
            {

                if (model.C_Court_name != null && model.C_Court_name != "")
                {
                    strSql.Append("  and C_Court_name like N'%'+@C_Court_name+'%' ");
                }
                if (model.C_Court_area != null)
                {
                    strSql.Append(" and C_Court_area=@C_Court_area");
                }
                if (model.C_Court_address != null)
                {
                    strSql.Append(" and C_Court_address=@C_Court_address");
                }
                if(model.C_Court_regions!=null)
                {
                    strSql.Append(" and charindex(','+cast(C_Court_area as nvarchar(2000))+',',','+@C_Court_regions+',')>0 ");
                }
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Court_number", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Court_area", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Court_url", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_Court_remark", SqlDbType.VarChar,500),
					new SqlParameter("@C_Court_userid", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Court_cdate",SqlDbType.DateTime),
                    new SqlParameter("@C_Court_id",SqlDbType.Int,4),
                    new SqlParameter("@C_Court_regions",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.C_Court_code;
            parameters[1].Value = model.C_Court_number;
            parameters[2].Value = model.C_Court_name;
            parameters[3].Value = model.C_Court_area;
            parameters[4].Value = model.C_Court_url;
            parameters[5].Value = model.C_Court_address;
            parameters[6].Value = model.C_Court_remark;
            parameters[7].Value = model.C_Court_userid;
            parameters[8].Value = model.C_Court_cdate;
            parameters[9].Value = model.C_Court_id;
            parameters[10].Value = model.C_Court_regions;
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
            parameters[0].Value = "C_Court";
            parameters[1].Value = "C_Court_id";
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
