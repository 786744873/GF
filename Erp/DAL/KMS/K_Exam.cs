using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace CommonService.DAL.KMS
{
    /// <summary>
    /// 数据访问类:K_Exam
    /// 作者：cpp
    /// 日期：2016-2-29
    /// </summary>
    public partial class K_Exam
    {
        public K_Exam()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid K_Exam_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_Exam");
            strSql.Append(" where K_Exam_code=@K_Exam_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_Exam_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CommonService.Model.KMS.K_Exam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_Exam(");
            strSql.Append("K_Exam_code,K_Exam_paperId,K_Exam_name,K_Exam_startTime,K_Exam_endTime,K_Exam_examiner,K_Exam_category,K_Exam_type,K_Exam_img,K_Exam_url,K_Exam_pwd,K_Exam_address,K_Exam_userCount,K_Exam_createtime,K_Exam_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@K_Exam_code,@K_Exam_paperId,@K_Exam_name,@K_Exam_startTime,@K_Exam_endTime,@K_Exam_examiner,@K_Exam_category,@K_Exam_type,@K_Exam_img,@K_Exam_url,@K_Exam_pwd,@K_Exam_address,@K_Exam_userCount,@K_Exam_createtime,@K_Exam_isDelete)");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_paperId", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Exam_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_startTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_endTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_examiner", SqlDbType.NVarChar,200),
					new SqlParameter("@K_Exam_category", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_type", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_img", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_url", SqlDbType.NVarChar,100),
                    new SqlParameter("@K_Exam_pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_address", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_userCount", SqlDbType.Int,4),
					new SqlParameter("@K_Exam_createtime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.K_Exam_paperId;
            parameters[2].Value = model.K_Exam_name;
            parameters[3].Value = model.K_Exam_startTime;
            parameters[4].Value = model.K_Exam_endTime;
            parameters[5].Value = model.K_Exam_examiner;
            parameters[6].Value = model.K_Exam_category;
            parameters[7].Value = model.K_Exam_type;
            parameters[8].Value = model.K_Exam_img;
            parameters[9].Value = model.K_Exam_url;
            parameters[10].Value = model.K_Exam_pwd;
            parameters[11].Value = model.K_Exam_address;
            parameters[12].Value = model.K_Exam_userCount;
            parameters[13].Value = model.K_Exam_createtime;
            parameters[14].Value = model.K_Exam_isDelete;

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
        public bool Update(CommonService.Model.KMS.K_Exam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Exam set ");
            strSql.Append("K_Exam_paperId=@K_Exam_paperId,");
            strSql.Append("K_Exam_name=@K_Exam_name,");
            strSql.Append("K_Exam_startTime=@K_Exam_startTime,");
            strSql.Append("K_Exam_endTime=@K_Exam_endTime,");
            strSql.Append("K_Exam_examiner=@K_Exam_examiner,");
            strSql.Append("K_Exam_category=@K_Exam_category,");
            strSql.Append("K_Exam_type=@K_Exam_type,");
            strSql.Append("K_Exam_img=@K_Exam_img,");
            strSql.Append("K_Exam_url=@K_Exam_url,");
            strSql.Append("K_Exam_pwd=@K_Exam_pwd,");
            strSql.Append("K_Exam_address=@K_Exam_address,");
            strSql.Append("K_Exam_userCount=@K_Exam_userCount,");
            strSql.Append("K_Exam_createtime=@K_Exam_createtime,");
            strSql.Append("K_Exam_isDelete=@K_Exam_isDelete");
            strSql.Append(" where K_Exam_code=@K_Exam_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_paperId", SqlDbType.NVarChar,50),
					new SqlParameter("@K_Exam_name", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_startTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_endTime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_examiner", SqlDbType.NVarChar,200),
					new SqlParameter("@K_Exam_category", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_type", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_Exam_img", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_url", SqlDbType.NVarChar,100),
                    new SqlParameter("@K_Exam_pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_address", SqlDbType.NVarChar,100),
					new SqlParameter("@K_Exam_userCount", SqlDbType.Int,4),
					new SqlParameter("@K_Exam_createtime", SqlDbType.DateTime),
					new SqlParameter("@K_Exam_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.K_Exam_paperId;
            parameters[1].Value = model.K_Exam_name;
            parameters[2].Value = model.K_Exam_startTime;
            parameters[3].Value = model.K_Exam_endTime;
            parameters[4].Value = model.K_Exam_examiner;
            parameters[5].Value = model.K_Exam_category;
            parameters[6].Value = model.K_Exam_type;
            parameters[7].Value = model.K_Exam_img;
            parameters[8].Value = model.K_Exam_url;
            parameters[9].Value = model.K_Exam_pwd;
            parameters[10].Value = model.K_Exam_address;
            parameters[11].Value = model.K_Exam_userCount;
            parameters[12].Value = model.K_Exam_createtime;
            parameters[13].Value = model.K_Exam_isDelete;
            parameters[14].Value = model.K_Exam_code;

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
        public bool Delete(Guid K_Exam_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_Exam set K_Exam_isDelete=1  ");
            strSql.Append(" where K_Exam_code=@K_Exam_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_Exam_code;

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
        public bool DeleteList(string K_Exam_codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_Exam ");
            strSql.Append(" where K_Exam_code in (" + K_Exam_codelist + ")  ");
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
        public CommonService.Model.KMS.K_Exam GetModel(Guid K_Exam_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_Exam_id,K_Exam_code,K_Exam_paperId,K_Exam_name,K_Exam_startTime,K_Exam_endTime,K_Exam_examiner,K_Exam_category,K_Exam_type,K_Exam_img,K_Exam_url,K_Exam_pwd,K_Exam_address,K_Exam_userCount,K_Exam_createtime,K_Exam_isDelete from K_Exam ");
            strSql.Append(" where K_Exam_code=@K_Exam_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@K_Exam_code", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = K_Exam_code;

            CommonService.Model.KMS.K_Exam model = new CommonService.Model.KMS.K_Exam();
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
        public CommonService.Model.KMS.K_Exam DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_Exam model = new CommonService.Model.KMS.K_Exam();
            if (row != null)
            {
                if (row["K_Exam_id"] != null && row["K_Exam_id"].ToString() != "")
                {
                    model.K_Exam_id = int.Parse(row["K_Exam_id"].ToString());
                }
                if (row["K_Exam_code"] != null && row["K_Exam_code"].ToString() != "")
                {
                    model.K_Exam_code = new Guid(row["K_Exam_code"].ToString());
                }
                if (row["K_Exam_paperId"] != null)
                {
                    model.K_Exam_paperId = row["K_Exam_paperId"].ToString();
                }
                if (row["K_Exam_name"] != null)
                {
                    model.K_Exam_name = row["K_Exam_name"].ToString();
                }
                if (row["K_Exam_startTime"] != null && row["K_Exam_startTime"].ToString() != "")
                {
                    model.K_Exam_startTime = DateTime.Parse(row["K_Exam_startTime"].ToString());
                }
                if (row["K_Exam_endTime"] != null && row["K_Exam_endTime"].ToString() != "")
                {
                    model.K_Exam_endTime = DateTime.Parse(row["K_Exam_endTime"].ToString());
                }
                if (row["K_Exam_examiner"] != null)
                {
                    model.K_Exam_examiner = row["K_Exam_examiner"].ToString();
                }
                if (row["K_Exam_category"] != null && row["K_Exam_category"].ToString() != "")
                {
                    model.K_Exam_category = new Guid(row["K_Exam_category"].ToString());
                }
                if (row["K_Exam_type"] != null && row["K_Exam_type"].ToString() != "")
                {
                    model.K_Exam_type = new Guid(row["K_Exam_type"].ToString());
                }
                if (row["K_Exam_img"] != null)
                {
                    model.K_Exam_img = row["K_Exam_img"].ToString();
                }
                if (row["K_Exam_url"] != null)
                {
                    model.K_Exam_url = row["K_Exam_url"].ToString();
                }
                if (row["K_Exam_pwd"] != null)
                {
                    model.K_Exam_pwd = row["K_Exam_pwd"].ToString();
                }
                if (row["K_Exam_address"] != null)
                {
                    model.K_Exam_address = row["K_Exam_address"].ToString();
                }
                if (row["K_Exam_userCount"] != null && row["K_Exam_userCount"].ToString() != "")
                {
                    model.K_Exam_userCount = int.Parse(row["K_Exam_userCount"].ToString());
                }
                if (row["K_Exam_createtime"] != null && row["K_Exam_createtime"].ToString() != "")
                {
                    model.K_Exam_createtime = DateTime.Parse(row["K_Exam_createtime"].ToString());
                }
                if (row["K_Exam_isDelete"] != null && row["K_Exam_isDelete"].ToString() != "")
                {
                    if ((row["K_Exam_isDelete"].ToString() == "1") || (row["K_Exam_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.K_Exam_isDelete = true;
                    }
                    else
                    {
                        model.K_Exam_isDelete = false;
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
            strSql.Append("select K_Exam_code,K_Exam_paperId,K_Exam_name,K_Exam_startTime,K_Exam_endTime,K_Exam_examiner,K_Exam_category,K_Exam_type,K_Exam_img,K_Exam_url,K_Exam_pwd,K_Exam_address,K_Exam_userCount,K_Exam_createtime,K_Exam_isDelete ");
            strSql.Append(" FROM K_Exam ");
            strSql.Append(" where K_Exam_isDelete = 0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据分类查询数据列表
        /// </summary>
        /// <param name="categoryList"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetListByCategory(string categoryList, CommonService.Model.KMS.K_Exam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select K_Exam_id,K_Exam_code,K_Exam_paperId,K_Exam_name,K_Exam_startTime,K_Exam_endTime,K_Exam_examiner,K_Exam_category,K_Exam_type,K_Exam_img,K_Exam_url,K_Exam_pwd,K_Exam_address,K_Exam_userCount,K_Exam_createtime,K_Exam_isDelete ");
            strSql.Append(" FROM K_Exam ");
            strSql.Append(" where K_Exam_name like '%" + model.K_Exam_name + "%' and K_Exam_isDelete = 0 ");
            if (categoryList.Trim() != "")
            {
                strSql.Append(" and K_Exam_category in (" + categoryList + ") ");
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
            strSql.Append(" K_Exam_code,K_Exam_paperId,K_Exam_name,K_Exam_startTime,K_Exam_endTime,K_Exam_examiner,K_Exam_category,K_Exam_type,K_Exam_img,K_Exam_url,K_Exam_pwd,K_Exam_address,K_Exam_userCount,K_Exam_createtime,K_Exam_isDelete ");
            strSql.Append(" FROM K_Exam ");
            strSql.Append(" where K_Exam_isDelete = 0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
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
            strSql.Append("select count(1) FROM K_Exam ");
            strSql.Append(" where K_Exam_isDelete = 0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
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
                strSql.Append("order by T.K_Exam_code desc");
            }
            strSql.Append(")AS Row, T.*  from K_Exam T ");
            strSql.Append(" where K_Exam_isDelete = 0 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
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
            parameters[0].Value = "K_Exam";
            parameters[1].Value = "K_Exam_code";
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
