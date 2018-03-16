﻿using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:K_Exam_ExtInfos
    /// author:cpp
    /// date:2016-3-1
    /// </summary>
    public partial class K_Exam_ExtInfos
    {
        public K_Exam_ExtInfos()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_ExtInfos_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Exam_ExtInfos");
            strSql.Append(" where K_ExtInfos_code=@K_ExtInfos_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_ExtInfos_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.KMS.K_Exam_ExtInfos model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Exam_ExtInfos(");
            strSql.Append("K_ExtInfos_code,K_ExtInfos_id,K_ExtInfos_name,K_ExtInfos_value,K_ExtInfos_realValue)");
            strSql.Append(" values (");
            strSql.Append("@K_ExtInfos_code,@K_ExtInfos_id,@K_ExtInfos_name,@K_ExtInfos_value,@K_ExtInfos_realValue)");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ExtInfos_id", SqlDbType.Int,4),
					new SqlParameter("@K_ExtInfos_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_ExtInfos_value", SqlDbType.NVarChar,50),
					new SqlParameter("@K_ExtInfos_realValue", SqlDbType.NVarChar,50)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.K_ExtInfos_id;
            parameters[2].Value = model.K_ExtInfos_name;
            parameters[3].Value = model.K_ExtInfos_value;
            parameters[4].Value = model.K_ExtInfos_realValue;

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
        public bool Update(CommonService.Model.KMS.K_Exam_ExtInfos model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Exam_ExtInfos set ");
            strSql.Append("K_ExtInfos_id=@K_ExtInfos_id,");
            strSql.Append("K_ExtInfos_name=@K_ExtInfos_name,");
            strSql.Append("K_ExtInfos_value=@K_ExtInfos_value,");
            strSql.Append("K_ExtInfos_realValue=@K_ExtInfos_realValue");
            strSql.Append(" where K_ExtInfos_code=@K_ExtInfos_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ExtInfos_id", SqlDbType.Int,4),
					new SqlParameter("@K_ExtInfos_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_ExtInfos_value", SqlDbType.NVarChar,50),
					new SqlParameter("@K_ExtInfos_realValue", SqlDbType.NVarChar,50),
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_ExtInfos_id;
            parameters[1].Value = model.K_ExtInfos_name;
            parameters[2].Value = model.K_ExtInfos_value;
            parameters[3].Value = model.K_ExtInfos_realValue;
            parameters[4].Value = model.K_ExtInfos_code;

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
        public bool Delete(Guid K_ExtInfos_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Exam_ExtInfos ");
            strSql.Append(" where K_ExtInfos_code=@K_ExtInfos_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_ExtInfos_code;

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
        public bool DeleteList(string K_ExtInfos_codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Exam_ExtInfos ");
            strSql.Append(" where K_ExtInfos_code in (" + K_ExtInfos_codelist + ")  ");
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
        public CommonService.Model.KMS.K_Exam_ExtInfos GetModel(Guid K_ExtInfos_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_ExtInfos_code,K_ExtInfos_id,K_ExtInfos_name,K_ExtInfos_value,K_ExtInfos_realValue from K_Exam_ExtInfos ");
            strSql.Append(" where K_ExtInfos_code=@K_ExtInfos_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ExtInfos_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_ExtInfos_code;

            CommonService.Model.KMS.K_Exam_ExtInfos model = new CommonService.Model.KMS.K_Exam_ExtInfos();
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
        public CommonService.Model.KMS.K_Exam_ExtInfos DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Exam_ExtInfos model = new CommonService.Model.KMS.K_Exam_ExtInfos();
            if (row != null)
            {
                if (row["K_ExtInfos_code"] != null && row["K_ExtInfos_code"].ToString() != "")
                {
                    model.K_ExtInfos_code = new Guid(row["K_ExtInfos_code"].ToString());
                }
                if (row["K_ExtInfos_id"] != null && row["K_ExtInfos_id"].ToString() != "")
                {
                    model.K_ExtInfos_id = int.Parse(row["K_ExtInfos_id"].ToString());
                }
                if (row["K_ExtInfos_name"] != null)
                {
                    model.K_ExtInfos_name = row["K_ExtInfos_name"].ToString();
                }
                if (row["K_ExtInfos_value"] != null)
                {
                    model.K_ExtInfos_value = row["K_ExtInfos_value"].ToString();
                }
                if (row["K_ExtInfos_realValue"] != null)
                {
                    model.K_ExtInfos_realValue = row["K_ExtInfos_realValue"].ToString();
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
            strSql.Append("select K_ExtInfos_code,K_ExtInfos_id,K_ExtInfos_name,K_ExtInfos_value,K_ExtInfos_realValue ");
            strSql.Append(" FROM K_Exam_ExtInfos ");
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
            strSql.Append(" K_ExtInfos_code,K_ExtInfos_id,K_ExtInfos_name,K_ExtInfos_value,K_ExtInfos_realValue ");
            strSql.Append(" FROM K_Exam_ExtInfos ");
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
            strSql.Append("select count(1) FROM K_Exam_ExtInfos ");
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
                strSql.Append("order by T.K_ExtInfos_code desc");
            }
            strSql.Append(")AS Row, T.*  from K_Exam_ExtInfos T ");
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
            parameters[0].Value = "K_Exam_ExtInfos";
            parameters[1].Value = "K_ExtInfos_code";
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
