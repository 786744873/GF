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
    /// 数据访问类:C_Files 附件表
    /// 作者：陈永俊
    /// 时间：2015年6月8日15:47:17
    /// </summary>
    public partial class C_Files
    {
        public C_Files()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Files_id", "C_Files");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Files_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Files");
            strSql.Append(" where C_Files_id=@C_Files_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_Files_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.C_Files model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Files(");
            strSql.Append("C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link)");
            strSql.Append(" values (");
            strSql.Append("@C_Files_code,@C_Files_viewName,@C_Files_name,@C_Files_size,@C_Files_creator,@C_Files_createDate,@C_Files_type,@C_Files_isDelete,@C_Files_cate,@C_Files_link)");
            SqlParameter[] parameters = {				 
					new SqlParameter("@C_Files_code", SqlDbType.UniqueIdentifier,500),
					new SqlParameter("@C_Files_viewName", SqlDbType.VarChar,50),
					new SqlParameter("@C_Files_name", SqlDbType.VarChar,500),
					new SqlParameter("@C_Files_size", SqlDbType.Decimal,9),
					new SqlParameter("@C_Files_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Files_createDate", SqlDbType.DateTime),
					new SqlParameter("@C_Files_type", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Files_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Files_cate", SqlDbType.Int,4),
					new SqlParameter("@C_Files_link", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.C_Files_code;
            parameters[1].Value = model.C_Files_viewName;
            parameters[2].Value = model.C_Files_name;
            parameters[3].Value = model.C_Files_size;
            parameters[4].Value = model.C_Files_creator;
            parameters[5].Value = model.C_Files_createDate;
            parameters[6].Value = model.C_Files_type;
            parameters[7].Value = model.C_Files_isDelete;
            parameters[8].Value = model.C_Files_cate;
            parameters[9].Value = model.C_Files_link;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Files model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Files set ");
            strSql.Append("C_Files_code=@C_Files_code,");
            strSql.Append("C_Files_viewName=@C_Files_viewName,");
            strSql.Append("C_Files_name=@C_Files_name,");
            strSql.Append("C_Files_size=@C_Files_size,");
            strSql.Append("C_Files_creator=@C_Files_creator,");
            strSql.Append("C_Files_createDate=@C_Files_createDate,");
            strSql.Append("C_Files_type=@C_Files_type,");
            strSql.Append("C_Files_isDelete=@C_Files_isDelete,");
            strSql.Append("C_Files_cate=@C_Files_cate,");
            strSql.Append("C_Files_link=@C_Files_link");
            strSql.Append(" where C_Files_id=@C_Files_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Files_viewName", SqlDbType.VarChar,500),
					new SqlParameter("@C_Files_name", SqlDbType.VarChar,500),
					new SqlParameter("@C_Files_size", SqlDbType.Decimal,9),
					new SqlParameter("@C_Files_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Files_createDate", SqlDbType.DateTime),
					new SqlParameter("@C_Files_type", SqlDbType.VarChar,50),
					new SqlParameter("@C_Files_isDelete", SqlDbType.Int,4),
					new SqlParameter("@C_Files_cate", SqlDbType.Int,4),
					new SqlParameter("@C_Files_link", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Files_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Files_code;
            parameters[1].Value = model.C_Files_viewName;
            parameters[2].Value = model.C_Files_name;
            parameters[3].Value = model.C_Files_size;
            parameters[4].Value = model.C_Files_creator;
            parameters[5].Value = model.C_Files_createDate;
            parameters[6].Value = model.C_Files_type;
            parameters[7].Value = model.C_Files_isDelete;
            parameters[8].Value = model.C_Files_cate;
            parameters[9].Value = model.C_Files_link;
            parameters[10].Value = model.C_Files_id;

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
        public bool Delete(Guid fileCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Files set C_Files_isDelete=1 ");
            strSql.Append("where C_Files_code=@C_Files_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_code", SqlDbType.UniqueIdentifier,16)			
            };
            parameters[0].Value = fileCode;

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
        public bool DeleteList(string C_Files_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Files ");
            strSql.Append(" where C_Files_id in (" + C_Files_idlist + ")  ");
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
        public CommonService.Model.C_Files GetModel(int C_Files_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link from C_Files ");
            strSql.Append(" where C_Files_id=@C_Files_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_id", SqlDbType.Int,4)			};
            parameters[0].Value = C_Files_id;

            CommonService.Model.C_Files model = new CommonService.Model.C_Files();
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
        /// 根据code得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModelByCode(Guid C_Files_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link from C_Files ");
            strSql.Append(" where C_Files_code=@C_Files_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = C_Files_code;

            CommonService.Model.C_Files model = new CommonService.Model.C_Files();
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
        /// 根据文件名得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files GetModelByName(string  fileName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link from C_Files ");
            strSql.Append(" where C_Files_name like N'%'+@C_Files_name+'%' ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_name", SqlDbType.VarChar,200)			};
            parameters[0].Value = fileName;

            CommonService.Model.C_Files model = new CommonService.Model.C_Files();
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
        /// 根据文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        public DataSet GetFilesByBelongTypeAndRelationCode(int belongType,Guid relationCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F.C_Files_id,F.C_Files_code,F.C_Files_viewName,F.C_Files_name,F.C_Files_size,F.C_Files_creator,F.C_Files_createDate,F.C_Files_type,F.C_Files_isDelete,F.C_Files_cate,F.C_Files_link,U.C_Userinfo_name as 'C_Files_creator_name',P.C_Parameters_name as 'C_Files_cateName' ");
            strSql.Append("from C_Files as F left join C_Userinfo as U on F.C_Files_creator=U.C_Userinfo_code ");
            strSql.Append("left join C_Parameters as P on F.C_Files_cate=P.C_Parameters_id ");
            strSql.Append("where C_Files_cate=@C_Files_cate ");
            strSql.Append("and C_Files_link=@C_Files_link ");
            strSql.Append("and C_Files_isDelete=0 order by F.C_Files_createDate desc");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Files_cate", SqlDbType.Int,4),
                    new SqlParameter("@C_Files_link", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = belongType;
            parameters[1].Value = relationCode;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }

        /// <summary>
        /// 根据父级文件所属类型和关联业务Guid，获取对应附件
        /// </summary>
        /// <param name="belongType">文件所属类型</param>
        /// <param name="relationCode">关联业务Guid</param>
        /// <returns></returns>
        public DataSet GetChildenFilesByBelongTypeAndRelationCode(int belongType, Guid relationCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link,P.C_Parameters_name As C_Files_Parameters_name,U.C_Userinfo_name as 'C_Files_creator_name' ");
            strSql.Append("from C_Files As F  left join C_Parameters As P on F.C_Files_cate=P.C_Parameters_id ");
            strSql.Append("left join C_Userinfo as U on F.C_Files_creator=U.C_Userinfo_code ");
            strSql.Append(" where ");
            strSql.Append(" C_Files_link=@C_Files_link ");
            strSql.Append(" and C_Files_isDelete=0 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Files_link", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = relationCode;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            return ds;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Files DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Files model = new CommonService.Model.C_Files();
            if (row != null)
            {
                if (row["C_Files_id"] != null && row["C_Files_id"].ToString() != "")
                {
                    model.C_Files_id = int.Parse(row["C_Files_id"].ToString());
                }
                if (row["C_Files_code"] != null && row["C_Files_code"].ToString() != "")
                {
                    model.C_Files_code = new Guid(row["C_Files_code"].ToString());
                }
                if (row["C_Files_viewName"] != null)
                {
                    model.C_Files_viewName = row["C_Files_viewName"].ToString();
                }
                if (row["C_Files_name"] != null)
                {
                    model.C_Files_name = row["C_Files_name"].ToString();
                }
                if (row["C_Files_size"] != null && row["C_Files_size"].ToString() != "")
                {
                    model.C_Files_size = decimal.Parse(row["C_Files_size"].ToString());
                }
                if (row["C_Files_creator"] != null && row["C_Files_creator"].ToString() != "")
                {
                    model.C_Files_creator = new Guid(row["C_Files_creator"].ToString());
                }
                //判断上传人名称（虚拟字段）是否存在
                if (row.Table.Columns.Contains("C_Files_creator_name"))
                {
                    if(row["C_Files_creator_name"]!=null && row["C_Files_creator_name"].ToString()!="")
                    {
                        model.C_Files_creator_name = row["C_Files_creator_name"].ToString();
                    }
                }
                if (row["C_Files_createDate"] != null && row["C_Files_createDate"].ToString() != "")
                {
                    model.C_Files_createDate = DateTime.Parse(row["C_Files_createDate"].ToString());
                }
                if (row["C_Files_type"] != null)
                {
                    model.C_Files_type = row["C_Files_type"].ToString();
                }
                if (row["C_Files_isDelete"] != null && row["C_Files_isDelete"].ToString() != "")
                {
                    model.C_Files_isDelete = int.Parse(row["C_Files_isDelete"].ToString());
                }
                if (row["C_Files_cate"] != null && row["C_Files_cate"].ToString() != "")
                {
                    model.C_Files_cate = int.Parse(row["C_Files_cate"].ToString());
                }
                if (row["C_Files_link"] != null && row["C_Files_link"].ToString() != "")
                {
                    model.C_Files_link = new Guid(row["C_Files_link"].ToString());
                }
                //检查子级类型名称，是否存在于table中
                if (row.Table.Columns.Contains("C_Files_Parameters_name"))
                {
                    if (row["C_Files_Parameters_name"] != null)
                    {
                        model.C_Files_Parameters_name = row["C_Files_Parameters_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("C_Files_cateName"))
                {
                    if (row["C_Files_cateName"] != null && row["C_Files_cateName"].ToString() != "")
                    {
                        model.C_Files_cateName = row["C_Files_cateName"].ToString();
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
            strSql.Append("select C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link ");
            strSql.Append(" FROM C_Files ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByFileLink(Guid relationCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link ");
            strSql.Append(" FROM C_Files ");
            strSql.Append("where C_Files_link=@C_Files_link ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Files_link", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = relationCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            strSql.Append(" C_Files_id,C_Files_code,C_Files_viewName,C_Files_name,C_Files_size,C_Files_creator,C_Files_createDate,C_Files_type,C_Files_isDelete,C_Files_cate,C_Files_link ");
            strSql.Append(" FROM C_Files ");
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
            strSql.Append("select count(1) FROM C_Files ");
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
        public DataSet GetListByPage(Model.C_Files files, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Files_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Files T ");
            strSql.Append(" WHERE 1=1 AND C_Files_isDelete=0 ");
            if (files != null)
            {
                if (files.C_Files_code != null)
                {
                    strSql.Append(" and C_Files_code=@C_Files_code");
                }
                if (files.C_Files_viewName != null)
                {
                    strSql.Append(" and C_Files_viewName=@C_Files_viewName");
                }
                if (files.C_Files_name != null)
                {
                    strSql.Append(" and C_Files_name=@C_Files_name");
                }
                if (files.C_Files_size != null)
                {
                    strSql.Append(" and C_Files_size=@C_Files_size");
                }
                if (files.C_Files_creator != null)
                {
                    strSql.Append(" and C_Files_creator=@C_Files_creator");
                }
                if (files.C_Files_createDate != null)
                {
                    strSql.Append(" and C_Files_createDate=@C_Files_createDate");
                }
                if (files.C_Files_type != null)
                {
                    strSql.Append(" and C_Files_type=@C_Files_type");
                }
                if (files.C_Files_cate != null)
                {
                    strSql.Append(" and C_Files_cate=@C_Files_cate");
                }
                if (files.C_Files_link != null)
                {
                    strSql.Append(" and C_Files_link=@C_Files_link");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters ={
                           new SqlParameter("@C_Files_code", SqlDbType.UniqueIdentifier,16),       
                           new SqlParameter("@C_Files_viewName", SqlDbType.VarChar,50),  
                           new SqlParameter("@C_Files_name", SqlDbType.VarChar,50),       
                           new SqlParameter("@C_Files_size", SqlDbType.Decimal,9),  
                           new SqlParameter("@C_Files_creator", SqlDbType.UniqueIdentifier,16),       
                           new SqlParameter("@C_Files_createDate", SqlDbType.DateTime),  
                           new SqlParameter("@C_Files_type", SqlDbType.VarChar,50),
                           new SqlParameter("@C_Files_cate", SqlDbType.Int),
                           new SqlParameter("@C_Files_link", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = files.C_Files_code;
            parameters[1].Value = files.C_Files_viewName;
            parameters[2].Value = files.C_Files_name;
            parameters[3].Value = files.C_Files_size;
            parameters[4].Value = files.C_Files_creator;
            parameters[5].Value = files.C_Files_createDate;
            parameters[6].Value = files.C_Files_type;
            parameters[7].Value = files.C_Files_cate;
            parameters[8].Value = files.C_Files_link;
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
            parameters[0].Value = "C_Files";
            parameters[1].Value = "C_Files_id";
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
