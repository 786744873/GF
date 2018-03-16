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
    /// 数据访问类:客户地址表
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Address
    {
        public C_Address()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Address_id", "C_Address");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Address_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Address");
            strSql.Append(" where C_Address_id=@C_Address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Address_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Address_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Address(");
            strSql.Append("C_Address_code,C_Address_customer,C_Address_shortName,C_Address_detail,C_Address_area,C_Address_postalCode,C_Address_isMainAddress,C_Address_isDelete,C_Address_remark,C_Address_creator,C_Address_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Address_code,@C_Address_customer,@C_Address_shortName,@C_Address_detail,@C_Address_area,@C_Address_postalCode,@C_Address_isMainAddress,@C_Address_isDelete,@C_Address_remark,@C_Address_creator,@C_Address_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Address_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Address_customer", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Address_shortName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Address_detail", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Address_area", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Address_postalCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Address_isMainAddress", SqlDbType.Bit,1),
					new SqlParameter("@C_Address_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Address_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Address_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Address_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Address_code;
            parameters[1].Value = model.C_Address_customer;
            parameters[2].Value = model.C_Address_shortName;
            parameters[3].Value = model.C_Address_detail;
            parameters[4].Value = model.C_Address_area;
            parameters[5].Value = model.C_Address_postalCode;
            parameters[6].Value = model.C_Address_isMainAddress;
            parameters[7].Value = model.C_Address_isDelete;
            parameters[8].Value = model.C_Address_remark;
            parameters[9].Value = model.C_Address_creator;
            parameters[10].Value = model.C_Address_createTime;

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
        public bool Update(CommonService.Model.C_Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Address set ");
            strSql.Append("C_Address_code=@C_Address_code,");
            strSql.Append("C_Address_shortName=@C_Address_shortName,");
            strSql.Append("C_Address_detail=@C_Address_detail,");
            strSql.Append("C_Address_area=@C_Address_area,");
            strSql.Append("C_Address_postalCode=@C_Address_postalCode,");
            strSql.Append("C_Address_isMainAddress=@C_Address_isMainAddress,");
            strSql.Append("C_Address_isDelete=@C_Address_isDelete,");
            strSql.Append("C_Address_remark=@C_Address_remark,");
            strSql.Append("C_Address_creator=@C_Address_creator,");
            strSql.Append("C_Address_createTime=@C_Address_createTime");
            strSql.Append(" where C_Address_id=@C_Address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Address_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Address_shortName", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Address_detail", SqlDbType.NVarChar,200),
					new SqlParameter("@C_Address_area", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Address_postalCode", SqlDbType.NVarChar,20),
					new SqlParameter("@C_Address_isMainAddress", SqlDbType.Bit,1),
					new SqlParameter("@C_Address_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Address_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Address_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Address_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Address_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Address_code;
            parameters[1].Value = model.C_Address_shortName;
            parameters[2].Value = model.C_Address_detail;
            parameters[3].Value = model.C_Address_area;
            parameters[4].Value = model.C_Address_postalCode;
            parameters[5].Value = model.C_Address_isMainAddress;
            parameters[6].Value = model.C_Address_isDelete;
            parameters[7].Value = model.C_Address_remark;
            parameters[8].Value = model.C_Address_creator;
            parameters[9].Value = model.C_Address_createTime;
            parameters[10].Value = model.C_Address_id;

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
        public bool Delete(Guid C_Address_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Address set C_Address_isDelete =1 ");
            strSql.Append(" where C_Address_code=@C_Address_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Address_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Address_code;

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
        public bool DeleteList(string C_Address_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Address ");
            strSql.Append(" where C_Address_id in (" + C_Address_idlist + ")  ");
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
        public CommonService.Model.C_Address GetModel(int C_Address_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Address_id,C_Address_code,C_Address_shortName,C_Address_detail,C_Address_area,C_Address_postalCode,C_Address_isMainAddress,C_Address_isDelete,C_Address_remark,C_Address_creator,C_Address_createTime from C_Address ");
            strSql.Append(" where C_Address_id=@C_Address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Address_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Address_id;

            CommonService.Model.C_Address model = new CommonService.Model.C_Address();
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
        public CommonService.Model.C_Address GetModel(Guid C_Address_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Address_id,C_Address_code,C_Address_customer,C_Address_shortName,C_Address_detail,C_Address_area,C_Address_postalCode,C_Address_isMainAddress,C_Address_isDelete,C_Address_remark,C_Address_creator,C_Address_createTime from C_Address ");
            strSql.Append(" where C_Address_code=@C_Address_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Address_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Address_code;

            CommonService.Model.C_Address model = new CommonService.Model.C_Address();
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
        public CommonService.Model.C_Address DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Address model = new CommonService.Model.C_Address();
            if (row != null)
            {
                if (row["C_Address_id"] != null && row["C_Address_id"].ToString() != "")
                {
                    model.C_Address_id = int.Parse(row["C_Address_id"].ToString());
                }
                if (row["C_Address_code"] != null && row["C_Address_code"].ToString() != "")
                {
                    model.C_Address_code = new Guid(row["C_Address_code"].ToString());
                }
                if (row["C_Address_shortName"] != null)
                {
                    model.C_Address_shortName = row["C_Address_shortName"].ToString();
                }
                if (row["C_Address_detail"] != null)
                {
                    model.C_Address_detail = row["C_Address_detail"].ToString();
                }
                if (row["C_Address_area"] != null)
                {
                    model.C_Address_area = row["C_Address_area"].ToString();
                }
                if (row["C_Address_postalCode"] != null)
                {
                    model.C_Address_postalCode = row["C_Address_postalCode"].ToString();
                }
                if (row["C_Address_isMainAddress"] != null && row["C_Address_isMainAddress"].ToString() != "")
                {
                    if ((row["C_Address_isMainAddress"].ToString() == "1") || (row["C_Address_isMainAddress"].ToString().ToLower() == "true"))
                    {
                        model.C_Address_isMainAddress = true;
                    }
                    else
                    {
                        model.C_Address_isMainAddress = false;
                    }
                }
                if (row["C_Address_isDelete"] != null && row["C_Address_isDelete"].ToString() != "")
                {
                    if ((row["C_Address_isDelete"].ToString() == "1") || (row["C_Address_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Address_isDelete = true;
                    }
                    else
                    {
                        model.C_Address_isDelete = false;
                    }
                }
                if (row["C_Address_remark"] != null)
                {
                    model.C_Address_remark = row["C_Address_remark"].ToString();
                }
                if (row["C_Address_creator"] != null && row["C_Address_creator"].ToString() != "")
                {
                    model.C_Address_creator = new Guid(row["C_Address_creator"].ToString());
                }
                if (row["C_Address_createTime"] != null && row["C_Address_createTime"].ToString() != "")
                {
                    model.C_Address_createTime = DateTime.Parse(row["C_Address_createTime"].ToString());
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
            strSql.Append("select C_Address_id,C_Address_code,C_Address_shortName,C_Address_detail,C_Address_area,C_Address_postalCode,C_Address_isMainAddress,C_Address_isDelete,C_Address_remark,C_Address_creator,C_Address_createTime ");
            strSql.Append(" FROM C_Address ");
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
            strSql.Append(" C_Address_id,C_Address_code,C_Address_shortName,C_Address_detail,C_Address_area,C_Address_postalCode,C_Address_isMainAddress,C_Address_isDelete,C_Address_remark,C_Address_creator,C_Address_createTime ");
            strSql.Append(" FROM C_Address ");
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
            strSql.Append("select count(1) FROM C_Address ");
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(Model.C_Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Address With(nolock) ");
            strSql.Append(" where 1=1 and C_Address_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Address_shortName != null)
                {
                    strSql.Append("and C_Address_shortName=@C_Address_shortName ");
                }
                if (model.C_Address_customer != null)
                {
                    strSql.Append(" and C_Address_customer=@C_Address_customer ");
                }
            }
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Address_shortName", SqlDbType.VarChar,50),
                    new SqlParameter("@C_Address_customer",SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = model.C_Address_shortName;
            parameters[1].Value = model.C_Address_customer;

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
        public DataSet GetListByPage(CommonService.Model.C_Address model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Address_id desc");
            }
            strSql.Append(")AS Row, T.* from C_Address AS T With(nolock) ");

            strSql.Append(" where 1=1 and T.C_Address_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Address_shortName != null)
                {
                    strSql.Append(" and C_Address_shortName=@C_Address_shortName ");
                }
                if(model.C_Address_customer!=null)
                {
                    strSql.Append(" and C_Address_customer=@C_Address_customer ");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = { new SqlParameter("@C_Address_shortName", SqlDbType.VarChar, 50),
                                          new SqlParameter("@C_Address_customer",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = model.C_Address_shortName;
            parameters[1].Value = model.C_Address_customer;

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
                strSql.Append("order by T.C_Address_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Address T ");
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
            parameters[0].Value = "C_Address";
            parameters[1].Value = "C_Address_id";
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
