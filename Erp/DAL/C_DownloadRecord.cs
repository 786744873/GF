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
    public partial class C_DownloadRecord
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_DownloadRecord_id", "C_DownloadRecord");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_DownloadRecord_id"></param>
        /// <returns></returns>
        public bool Exists(int C_DownloadRecord_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_DownloadRecord");
            strSql.Append(" where C_DownloadRecord_id=@C_DownloadRecord_id");
            SqlParameter[] parameters ={
                                          new SqlParameter("C_DownloadRecord_id",SqlDbType.Int,4)
                                      };
            parameters[0].Value = C_DownloadRecord_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条下载数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.C_DownloadRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_DownloadRecord(");
            strSql.Append("C_DownloadRecord_code,C_DownloadRecord_attachmentCode,C_DownloadRecord_creator,C_DownloadRecord_createTime,C_DownloadRecord_isDelete)");
            strSql.Append(" values(");
            strSql.Append("@C_DownloadRecord_code,@C_DownloadRecord_attachmentCode,@C_DownloadRecord_creator,@C_DownloadRecord_createTime,@C_DownloadRecord_isDelete)");

            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters ={
                                        new SqlParameter("@C_DownloadRecord_code",SqlDbType.UniqueIdentifier,16),
                                        new SqlParameter("@C_DownloadRecord_attachmentCode",SqlDbType.UniqueIdentifier,16),
                                        new SqlParameter("@C_DownloadRecord_creator",SqlDbType.UniqueIdentifier,16),
                                        new SqlParameter("@C_DownloadRecord_createTime" ,SqlDbType.DateTime),
                                        new SqlParameter("@C_DownloadRecord_isDelete",SqlDbType.Bit,1)
                                      };
            parameters[0].Value = model.C_DownloadRecord_code;
            parameters[1].Value = model.C_DownloadRecord_attachmentCode;
            parameters[2].Value = model.C_DownloadRecord_creator;
            parameters[3].Value = model.C_DownloadRecord_createTime;
            parameters[4].Value = model.C_DownloadRecord_isDelete;
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
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.C_DownloadRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_DownloadRecord set");
            strSql.Append("C_DownloadRecord_code=@C_DownloadRecord_code");
            strSql.Append("C_DownloadRecord_attachmentCode=@C_DownloadRecord_attachmentCode");
            strSql.Append("C_DownloadRecord_creator=@C_DownloadRecord_creator");
            strSql.Append("C_DownloadRecord_createTime=@C_DownloadRecord_createTime");
            strSql.Append("C_DownloadRecord_isDelete=@C_DownloadRecord_isDelete");
            strSql.Append(" where C_DownloadRecord_id=@C_DownloadRecord_id");
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_code",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_attachmentCode",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_creator",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_createTime",SqlDbType.DateTime),
                                          new SqlParameter("@C_DownloadRecord_isDelete",SqlDbType.Bit,1)
                                      };
            parameters[0].Value = model.C_DownloadRecord_code;
            parameters[1].Value = model.C_DownloadRecord_attachmentCode;
            parameters[2].Value = model.C_DownloadRecord_creator;
            parameters[3].Value = model.C_DownloadRecord_createTime;
            parameters[4].Value = model.C_DownloadRecord_isDelete;
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
        /// 假删除一条数据
        /// </summary>
        /// <param name="C_DownloadRecord_code">下载记录的GUID</param>
        /// <returns></returns>
        public bool Delete(Guid C_DownloadRecord_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_DownloadRecord set C_DownloadRecord_isDelete=1");
            strSql.Append(" where C_DownloadRecord_code=@C_DownloadRecord_code");
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_code",SqlDbType.UniqueIdentifier,16)
                                      };
            parameters[0].Value = C_DownloadRecord_code;
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
        /// 根据ID获得对象实体
        /// </summary>
        /// <param name="C_DownloadRecord_id"></param>
        /// <returns></returns>
        public CommonService.Model.C_DownloadRecord GetModel(int C_DownloadRecord_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_DownloadRecord_id,C_DownloadRecord_code,C_DownloadRecord_attachmentCode,C_DownloadRecord_creator,C_DownloadRecord_createTime,C_DownloadRecord_isDelete from C_DownloadRecord");
            strSql.Append(" where C_DownloadRecord_id=@C_DownloadRecord_id");
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_id",SqlDbType.Int,4)
                                      };
            parameters[0].Value = C_DownloadRecord_id;

            CommonService.Model.C_DownloadRecord model = new Model.C_DownloadRecord();
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
        /// 根据下载记录guid获得对象实体
        /// </summary>
        /// <param name="C_DownloadRecord_code"></param>
        /// <returns></returns>
        public CommonService.Model.C_DownloadRecord GetModel(Guid C_DownloadRecord_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_DownloadRecord_id,C_DownloadRecord_code,C_DownloadRecord_attachmentCode,C_DownloadRecord_creator,C_DownloadRecord_createTime,C_DownloadRecord_isDelete from C_DownloadRecord");
            strSql.Append(" where C_DownloadRecord_code=@C_DownloadRecord_code");
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_code",SqlDbType.UniqueIdentifier,16)
                                      };
            parameters[0].Value = C_DownloadRecord_code;

            CommonService.Model.C_DownloadRecord model = new Model.C_DownloadRecord();
            DataSet dt = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (dt.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(dt.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 将DataRow转化为对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public CommonService.Model.C_DownloadRecord DataRowToModel(DataRow row)
        {
            CommonService.Model.C_DownloadRecord model = new Model.C_DownloadRecord();
            if (row != null)
            {
                if (row["C_DownloadRecord_id"] != null && row["C_DownloadRecord_id"].ToString() != "")
                {
                    model.C_DownloadRecord_id = int.Parse(row["C_DownloadRecord_id"].ToString());
                }
                if (row["C_DownloadRecord_code"] != null && row["C_DownloadRecord_code"].ToString() != "")
                {
                    model.C_DownloadRecord_code = new Guid(row["C_DownloadRecord_code"].ToString());
                }
                if (row["C_DownloadRecord_attachmentCode"] != null && row["C_DownloadRecord_attachmentCode"].ToString() != "")
                {
                    model.C_DownloadRecord_attachmentCode = new Guid(row["C_DownloadRecord_attachmentCode"].ToString());
                }
                if (row["C_DownloadRecord_creator"] != null && row["C_DownloadRecord_creator"].ToString() != "")
                {
                    model.C_DownloadRecord_creator = new Guid(row["C_DownloadRecord_creator"].ToString());
                }
                if (row["C_DownloadRecord_createTime"] != null && row["C_DownloadRecord_createTime"].ToString() != "")
                {
                    model.C_DownloadRecord_createTime = DateTime.Parse(row["C_DownloadRecord_createTime"].ToString());
                }
                if (row["C_DownloadRecord_isDelete"] != null && row["C_DownloadRecord_isDelete"].ToString() != "")
                {
                    if ((row["C_DownloadRecord_isDelete"].ToString() == "1") || (row["C_DownloadRecord_isDelete"].ToString() == "true"))
                    {
                        model.C_DownloadRecord_isDelete = true;
                    }
                    else
                    {
                        model.C_DownloadRecord_isDelete = false;
                    }
                }
                if (row.Table.Columns.Contains("C_Userinfo_name"))
                { 
                    if(row["C_Userinfo_name"] != null && row["C_Userinfo_name"].ToString() != "")
                    {
                        model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                    }
                }

            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_DownloadRecord_id,C_DownloadRecord_code,C_DownloadRecord_attachmentCode,C_DownloadRecord_creator,C_DownloadRecord_createTime,C_DownloadRecord_isDelete");
            strSql.Append(" from C_DownloadRecord");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得文件的数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByfileCode(Guid fileCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_DownloadRecord_id,C_DownloadRecord_code,C_DownloadRecord_attachmentCode,C_DownloadRecord_creator,C_DownloadRecord_createTime,C_DownloadRecord_isDelete,b.C_Userinfo_name as C_Userinfo_name");
            strSql.Append(" from C_DownloadRecord as a left join C_Userinfo as b on a.C_DownloadRecord_creator=b.C_Userinfo_code where C_DownloadRecord_attachmentCode=@C_DownloadRecord_attachmentCode and C_DownloadRecord_isDelete=0");
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_attachmentCode",SqlDbType.UniqueIdentifier,16)
                                      };
            parameters[0].Value = fileCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" C_DownloadRecord_id,C_DownloadRecord_code,C_DownloadRecord_attachmentCode,C_DownloadRecord_creator,C_DownloadRecord_createTime,C_DownloadRecord_isDelete");
            strSql.Append(" from C_DownloadRecord");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得下载记录数目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.C_DownloadRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_DownloadRecord With(nolock) ");
            strSql.Append(" where 1=1 and C_DownloadRecord_isDelete=0");
            if (model != null)
            {

                if (model.C_DownloadRecord_attachmentCode != null)
                {
                    strSql.Append(" and C_DownloadRecord_attachmentCode=@C_DownloadRecord_attachmentCode");
                }
                if (model.C_DownloadRecord_creator != null)
                {
                    strSql.Append(" and C_DownloadRecord_creator=@C_DownloadRecord_creator");
                }
                if (model.C_DownloadRecord_createTime != null)
                {
                    strSql.Append(" and C_DownloadRecord_createTime=@C_DownloadRecord_createTime");
                }
            }
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_attachmentCode",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_creator",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_createTime",SqlDbType.DateTime)
                                      };
            parameters[0].Value = model.C_DownloadRecord_attachmentCode;
            parameters[1].Value = model.C_DownloadRecord_creator;
            parameters[2].Value = model.C_DownloadRecord_createTime;
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
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(CommonService.Model.C_DownloadRecord model, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.C_Organization_id desc");
            }
            strSql.Append(")AS ROW,T.* from C_DownloadRecord AS T With(nolock) ");
            strSql.Append(" where 1=1 and T.C_DownloadRecord_isDelete=0 ");
            if (model != null)
            {
                if (model.C_DownloadRecord_attachmentCode != null)
                {
                    strSql.Append("and C_DownloadRecord_attachmentCode=@C_DownloadRecord_attachmentCode");
                }
                if (model.C_DownloadRecord_creator != null)
                {
                    strSql.Append(" and C_DownloadRecord_creator=@C_DownloadRecord_creator");
                }
                if (model.C_DownloadRecord_createTime != null)
                {
                    strSql.Append(" and C_DownloadRecord_createTime=@C_DownloadRecord_createTime");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.ROW between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters ={
                                          new SqlParameter("@C_DownloadRecord_attachmentCode",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_creator",SqlDbType.UniqueIdentifier,16),
                                          new SqlParameter("@C_DownloadRecord_createTime",SqlDbType.DateTime)
                                      };
            parameters[0].Value = model.C_DownloadRecord_attachmentCode;
            parameters[1].Value = model.C_DownloadRecord_creator;
            parameters[2].Value = model.C_DownloadRecord_createTime;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
    }
}
