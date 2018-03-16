using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:角色权限表
    /// 作者：贺太玉
    /// 日期：2015/07/09
    /// </summary>
    public partial class C_Role_Power
    {
        public C_Role_Power()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Role_Power_id", "C_Role_Power");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Role_Power_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Role_Power");
            strSql.Append(" where C_Role_Power_id=@C_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Role_Power_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Role_Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Role_Power(");
            strSql.Append("C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type)");
            strSql.Append(" values (");
            strSql.Append("@C_Role_Power_name,@C_Role_Power_remark,@C_Role_Power_isDelete,@C_Role_Power_creator,@C_Role_Power_createTime,@C_Role_Power_type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Power_name", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Role_Power_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Role_Power_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Role_Power_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Role_Power_createTime", SqlDbType.DateTime),
                    new SqlParameter("@C_Role_Power_type", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.C_Role_Power_name;
            parameters[1].Value = model.C_Role_Power_remark;
            parameters[2].Value = model.C_Role_Power_isDelete;
            parameters[3].Value = Guid.NewGuid();
            parameters[4].Value = model.C_Role_Power_createTime;
            parameters[5].Value = model.C_Role_Power_type;
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
        public bool Update(CommonService.Model.SysManager.C_Role_Power model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Role_Power set ");
            strSql.Append("C_Role_Power_name=@C_Role_Power_name,");
            strSql.Append("C_Role_Power_remark=@C_Role_Power_remark,");
            strSql.Append("C_Role_Power_isDelete=@C_Role_Power_isDelete,");
            strSql.Append("C_Role_Power_creator=@C_Role_Power_creator,");
            strSql.Append("C_Role_Power_createTime=@C_Role_Power_createTime");
            strSql.Append("C_Role_Power_type=@C_Role_Power_type");
            strSql.Append(" where C_Role_Power_id=@C_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Power_name", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Role_Power_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Role_Power_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Role_Power_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Role_Power_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Role_Power_type", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.C_Role_Power_name;
            parameters[1].Value = model.C_Role_Power_remark;
            parameters[2].Value = model.C_Role_Power_isDelete;
            parameters[3].Value = model.C_Role_Power_creator;
            parameters[4].Value = model.C_Role_Power_createTime;
            parameters[5].Value = model.C_Role_Power_id;
            parameters[6].Value = model.C_Role_Power_type;
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
        public bool Delete(int C_Role_Power_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_Power ");
            strSql.Append(" where C_Role_Power_id=@C_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Role_Power_id;

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
        public bool DeleteList(string C_Role_Power_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Role_Power ");
            strSql.Append(" where C_Role_Power_id in (" + C_Role_Power_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Role_Power GetModel(int C_Role_Power_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Role_Power_id,C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type from C_Role_Power ");
            strSql.Append(" where C_Role_Power_id=@C_Role_Power_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Power_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Role_Power_id;

            CommonService.Model.SysManager.C_Role_Power model = new CommonService.Model.SysManager.C_Role_Power();
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
        /// 获取所有角色权限集合
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Role_Power_id,C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type ");
            strSql.Append("from C_Role_Power ");
            strSql.Append("where C_Role_Power_isDelete=0");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 获取角色权限集合
        /// </summary>
        /// <returns></returns>
        public DataSet GetRolePowers(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from C_Role_Power RP,C_Role_Role_Power RRP where RP.C_Role_Power_id=RRP.C_Role_Power_id and ");
            strSql.Append(" RRP.C_Roles_id=@roleid");
            SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,8)
			};
            parameters[0].Value = roleid;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
        /// <summary>
        /// 根据权限类型获取所有角色权限集合
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByType(int? type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Role_Power_id,C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type ");
            strSql.Append("from C_Role_Power ");
            strSql.Append("where C_Role_Power_isDelete=0 ");
            if (type != null)
            {
                strSql.Append("and C_Role_Power_type=@C_Role_Power_type");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Role_Power_type", SqlDbType.Int,4)
			};
            parameters[0].Value = type;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Role_Power DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Role_Power model = new CommonService.Model.SysManager.C_Role_Power();
            if (row != null)
            {
                if (row["C_Role_Power_id"] != null && row["C_Role_Power_id"].ToString() != "")
                {
                    model.C_Role_Power_id = int.Parse(row["C_Role_Power_id"].ToString());
                }
                if (row["C_Role_Power_name"] != null)
                {
                    model.C_Role_Power_name = row["C_Role_Power_name"].ToString();
                }
                if (row["C_Role_Power_remark"] != null)
                {
                    model.C_Role_Power_remark = row["C_Role_Power_remark"].ToString();
                }
                if (row["C_Role_Power_isDelete"] != null && row["C_Role_Power_isDelete"].ToString() != "")
                {
                    if ((row["C_Role_Power_isDelete"].ToString() == "1") || (row["C_Role_Power_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Role_Power_isDelete = true;
                    }
                    else
                    {
                        model.C_Role_Power_isDelete = false;
                    }
                }
                if (row["C_Role_Power_creator"] != null && row["C_Role_Power_creator"].ToString() != "")
                {
                    model.C_Role_Power_creator = new Guid(row["C_Role_Power_creator"].ToString());
                }
                if (row["C_Role_Power_createTime"] != null && row["C_Role_Power_createTime"].ToString() != "")
                {
                    model.C_Role_Power_createTime = DateTime.Parse(row["C_Role_Power_createTime"].ToString());
                }
                if (row["C_Role_Power_type"] != null && row["C_Role_Power_type"].ToString() != "")
                {
                    model.C_Role_Power_type = int.Parse(row["C_Role_Power_type"].ToString());
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
            strSql.Append("select C_Role_Power_id,C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type ");
            strSql.Append(" FROM C_Role_Power ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得某用户所拥有的权限
        /// </summary>
        public DataSet GetListByUserinfo(string userinfoCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Role_Power_id,C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type ");
            strSql.Append(" FROM C_Role_Power as RP ");
            strSql.Append("where exists(select * from C_Role_Role_Power as RRP left join C_Userinfo as U on RRP.C_Roles_id=U.C_Userinfo_roleID where RRP.C_Role_Power_id=RP.C_Role_Power_id and U.C_Userinfo_code='@C_Userinfo_code')");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = userinfoCode;
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
            strSql.Append(" C_Role_Power_id,C_Role_Power_name,C_Role_Power_remark,C_Role_Power_isDelete,C_Role_Power_creator,C_Role_Power_createTime,C_Role_Power_type ");
            strSql.Append(" FROM C_Role_Power ");
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
            strSql.Append("select count(1) FROM C_Role_Power ");
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
                strSql.Append("order by T.C_Role_Power_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Role_Power T ");
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
            parameters[0].Value = "C_Role_Power";
            parameters[1].Value = "C_Role_Power_id";
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
