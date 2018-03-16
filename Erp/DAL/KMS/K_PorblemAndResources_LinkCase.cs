using Maticsoft.DBUtility;
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
    /// 问题/文档/视频 关联业务流程表单表
    /// cyj
    /// 2016年1月13日10:21:11
    /// </summary>
    public class K_PorblemAndResources_LinkCase
    {
        public K_PorblemAndResources_LinkCase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_ProblemAndResources_LinkCase_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from K_PorblemAndResources_LinkCase");
            strSql.Append(" where K_ProblemAndResources_LinkCase_id=@K_ProblemAndResources_LinkCase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ProblemAndResources_LinkCase_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_ProblemAndResources_LinkCase_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into K_PorblemAndResources_LinkCase(");
            strSql.Append("K_ProblemAndResources_LinkCase_code,C_FK_code,K_ProblemAndResources_LinkCase_Courtcode,K_ProblemAndResources_LinkCase_BusinessFlowcode,K_ProblemAndResources_LinkCase_Formcode,K_ProblemAndResources_LinkCase_type)");
            strSql.Append(" values (");
            strSql.Append("@K_ProblemAndResources_LinkCase_code,@C_FK_code,@K_ProblemAndResources_LinkCase_Courtcode,@K_ProblemAndResources_LinkCase_BusinessFlowcode,@K_ProblemAndResources_LinkCase_Formcode,@K_ProblemAndResources_LinkCase_type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ProblemAndResources_LinkCase_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_Courtcode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_BusinessFlowcode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_Formcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_type", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.K_ProblemAndResources_LinkCase_code;
            parameters[1].Value = model.C_FK_code;
            parameters[2].Value = model.K_ProblemAndResources_LinkCase_Courtcode;
            parameters[3].Value = model.K_ProblemAndResources_LinkCase_BusinessFlowcode;
            parameters[4].Value = model.K_ProblemAndResources_LinkCase_Formcode;
            parameters[5].Value = model.K_ProblemAndResources_LinkCase_type;
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
        public bool Update(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update K_PorblemAndResources_LinkCase set ");
            strSql.Append("K_ProblemAndResources_LinkCase_code=@K_ProblemAndResources_LinkCase_code,");
            strSql.Append("C_FK_code=@C_FK_code,");
            strSql.Append("K_ProblemAndResources_LinkCase_Courtcode=@K_ProblemAndResources_LinkCase_Courtcode,");
            strSql.Append("K_ProblemAndResources_LinkCase_BusinessFlowcode=@K_ProblemAndResources_LinkCase_BusinessFlowcode,");
            strSql.Append("K_ProblemAndResources_LinkCase_Formcode=@K_ProblemAndResources_LinkCase_Formcode,");
            strSql.Append("K_ProblemAndResources_LinkCase_type=@K_ProblemAndResources_LinkCase_type");
            strSql.Append(" where K_ProblemAndResources_LinkCase_id=@K_ProblemAndResources_LinkCase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ProblemAndResources_LinkCase_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_Courtcode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_BusinessFlowcode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_Formcode", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@K_ProblemAndResources_LinkCase_id", SqlDbType.Int,4),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_type", SqlDbType.Int,4)};
            parameters[0].Value = model.K_ProblemAndResources_LinkCase_code;
            parameters[1].Value = model.C_FK_code;
            parameters[2].Value = model.K_ProblemAndResources_LinkCase_Courtcode;
            parameters[3].Value = model.K_ProblemAndResources_LinkCase_BusinessFlowcode;
            parameters[4].Value = model.K_ProblemAndResources_LinkCase_Formcode;
            parameters[5].Value = model.K_ProblemAndResources_LinkCase_id;
            parameters[6].Value = model.K_ProblemAndResources_LinkCase_type;
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
        public bool Delete(int K_ProblemAndResources_LinkCase_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_PorblemAndResources_LinkCase ");
            strSql.Append(" where K_ProblemAndResources_LinkCase_id=@K_ProblemAndResources_LinkCase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ProblemAndResources_LinkCase_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_ProblemAndResources_LinkCase_id;

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
        public bool DeleteByFK_code(Guid C_FK_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_PorblemAndResources_LinkCase ");
            strSql.Append(" where C_FK_code=@C_FK_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_FK_code;

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
        public bool DeleteList(string K_ProblemAndResources_LinkCase_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from K_PorblemAndResources_LinkCase ");
            strSql.Append(" where K_ProblemAndResources_LinkCase_id in (" + K_ProblemAndResources_LinkCase_idlist + ")  ");
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
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModel(int K_ProblemAndResources_LinkCase_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_ProblemAndResources_LinkCase_id,K_ProblemAndResources_LinkCase_code,C_FK_code,K_ProblemAndResources_LinkCase_Courtcode,K_ProblemAndResources_LinkCase_BusinessFlowcode,K_ProblemAndResources_LinkCase_Formcode,K_ProblemAndResources_LinkCase_type from K_PorblemAndResources_LinkCase ");
            strSql.Append(" where K_ProblemAndResources_LinkCase_id=@K_ProblemAndResources_LinkCase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@K_ProblemAndResources_LinkCase_id", SqlDbType.Int,4)
			};
            parameters[0].Value = K_ProblemAndResources_LinkCase_id;

            CommonService.Model.KMS.K_PorblemAndResources_LinkCase model = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
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
        /// 根据实体得到对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModelByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 K_ProblemAndResources_LinkCase_id,K_ProblemAndResources_LinkCase_code,C_FK_code,K_ProblemAndResources_LinkCase_Courtcode,K_ProblemAndResources_LinkCase_BusinessFlowcode,K_ProblemAndResources_LinkCase_Formcode,K_ProblemAndResources_LinkCase_type,b.C_Court_name as C_Court_name,c.P_Flow_name as P_Flow_name,d.F_Form_chineseName as F_Form_chineseName from K_PorblemAndResources_LinkCase as a ");
            strSql.Append("left join C_Court as b on a.K_ProblemAndResources_LinkCase_Courtcode=b.C_Court_code ");
            strSql.Append("left join P_Flow as c on c.P_Flow_code=a.K_ProblemAndResources_LinkCase_BusinessFlowcode ");
            strSql.Append("left join F_Form as d on d.F_Form_code=a.K_ProblemAndResources_LinkCase_Formcode ");
            strSql.Append(" where 1=1 ");
            if (modelL != null)
            {
                if (modelL.K_ProblemAndResources_LinkCase_code != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_code=@K_ProblemAndResources_LinkCase_code");
                }
                if (modelL.C_FK_code != null)
                {
                    strSql.Append(" and C_FK_code=@C_FK_code");
                }
                if (modelL.K_ProblemAndResources_LinkCase_Courtcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_Courtcode=@K_ProblemAndResources_LinkCase_Courtcode");
                }
                if (modelL.K_ProblemAndResources_LinkCase_BusinessFlowcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_BusinessFlowcode=@K_ProblemAndResources_LinkCase_BusinessFlowcode");
                }
                if (modelL.K_ProblemAndResources_LinkCase_Formcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_Formcode=@K_ProblemAndResources_LinkCase_Formcode");
                }
                if (modelL.K_ProblemAndResources_LinkCase_type != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_type=@K_ProblemAndResources_LinkCase_type");
                }
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@K_ProblemAndResources_LinkCase_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_Courtcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_BusinessFlowcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_Formcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_type", SqlDbType.Int,4)
			};
            parameters[0].Value = modelL.K_ProblemAndResources_LinkCase_code;
            parameters[1].Value = modelL.C_FK_code;
            parameters[2].Value = modelL.K_ProblemAndResources_LinkCase_Courtcode;
            parameters[3].Value = modelL.K_ProblemAndResources_LinkCase_BusinessFlowcode;
            parameters[4].Value = modelL.K_ProblemAndResources_LinkCase_Formcode;
            parameters[5].Value = modelL.K_ProblemAndResources_LinkCase_type;
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase model = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
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
        /// 根据实体得到数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type">1.资源文档，2问吧，3视频</param>
        /// <returns></returns>
        public DataSet GetListByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  K_ProblemAndResources_LinkCase_id,K_ProblemAndResources_LinkCase_code,C_FK_code,K_ProblemAndResources_LinkCase_Courtcode,K_ProblemAndResources_LinkCase_BusinessFlowcode,K_ProblemAndResources_LinkCase_Formcode,K_ProblemAndResources_LinkCase_type from K_PorblemAndResources_LinkCase ");
            strSql.Append(" where 1=1 ");
            if (modelL != null)
            {
                if (modelL.K_ProblemAndResources_LinkCase_code != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_code=@K_ProblemAndResources_LinkCase_code");
                }
                if (modelL.C_FK_code != null)
                {
                    strSql.Append(" and C_FK_code=@C_FK_code");
                }
                if (modelL.K_ProblemAndResources_LinkCase_Courtcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_Courtcode =@K_ProblemAndResources_LinkCase_Courtcode");
                }
                if (modelL.K_ProblemAndResources_LinkCase_CourtListcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_Courtcode in ("+modelL.K_ProblemAndResources_LinkCase_CourtListcode+")");
                }
                if (modelL.K_ProblemAndResources_LinkCase_BusinessFlowcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_BusinessFlowcode=@K_ProblemAndResources_LinkCase_BusinessFlowcode");
                }
                if (modelL.K_ProblemAndResources_LinkCase_Formcode != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_Formcode=@K_ProblemAndResources_LinkCase_Formcode");
                }
                if (modelL.K_ProblemAndResources_LinkCase_type != null)
                {
                    strSql.Append(" and K_ProblemAndResources_LinkCase_type=@K_ProblemAndResources_LinkCase_type");
                }
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@K_ProblemAndResources_LinkCase_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_FK_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_Courtcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_BusinessFlowcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_Formcode", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@K_ProblemAndResources_LinkCase_type", SqlDbType.Int,4)
			};
            parameters[0].Value = modelL.K_ProblemAndResources_LinkCase_code;
            parameters[1].Value = modelL.C_FK_code;
            parameters[2].Value = modelL.K_ProblemAndResources_LinkCase_Courtcode;
            parameters[3].Value = modelL.K_ProblemAndResources_LinkCase_BusinessFlowcode;
            parameters[4].Value = modelL.K_ProblemAndResources_LinkCase_Formcode;
            parameters[5].Value = modelL.K_ProblemAndResources_LinkCase_type;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase DataRowToModel(DataRow row)
        {
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase model = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            if (row != null)
            {
                if (row["K_ProblemAndResources_LinkCase_id"] != null && row["K_ProblemAndResources_LinkCase_id"].ToString() != "")
                {
                    model.K_ProblemAndResources_LinkCase_id = int.Parse(row["K_ProblemAndResources_LinkCase_id"].ToString());
                }
                if (row["K_ProblemAndResources_LinkCase_code"] != null && row["K_ProblemAndResources_LinkCase_code"].ToString() != "")
                {
                    model.K_ProblemAndResources_LinkCase_code = new Guid(row["K_ProblemAndResources_LinkCase_code"].ToString());
                }
                if (row["C_FK_code"] != null && row["C_FK_code"].ToString() != "")
                {
                    model.C_FK_code = new Guid(row["C_FK_code"].ToString());
                }
                if (row["K_ProblemAndResources_LinkCase_Courtcode"] != null && row["K_ProblemAndResources_LinkCase_Courtcode"].ToString() != "")
                {
                    model.K_ProblemAndResources_LinkCase_Courtcode = new Guid(row["K_ProblemAndResources_LinkCase_Courtcode"].ToString());
                }
                if (row["K_ProblemAndResources_LinkCase_BusinessFlowcode"] != null && row["K_ProblemAndResources_LinkCase_BusinessFlowcode"].ToString() != "")
                {
                    model.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(row["K_ProblemAndResources_LinkCase_BusinessFlowcode"].ToString());
                }
                if (row["K_ProblemAndResources_LinkCase_Formcode"] != null && row["K_ProblemAndResources_LinkCase_Formcode"].ToString() != "")
                {
                    model.K_ProblemAndResources_LinkCase_Formcode = new Guid(row["K_ProblemAndResources_LinkCase_Formcode"].ToString());
                }
                if (row["K_ProblemAndResources_LinkCase_type"] != null && row["K_ProblemAndResources_LinkCase_type"].ToString() != "")
                {
                    model.K_ProblemAndResources_LinkCase_type = int.Parse(row["K_ProblemAndResources_LinkCase_type"].ToString());
                }
                if (row.Table.Columns.Contains("C_Court_name"))
                {
                    if (row["C_Court_name"] != null && row["C_Court_name"].ToString() != "")
                    {
                        model.C_Court_name = row["C_Court_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("P_Flow_name"))
                {
                    if (row["P_Flow_name"] != null && row["P_Flow_name"].ToString() != "")
                    {
                        model.P_Flow_name = row["P_Flow_name"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("F_Form_chineseName"))
                {
                    if (row["F_Form_chineseName"] != null && row["F_Form_chineseName"].ToString() != "")
                    {
                        model.F_Form_chineseName = row["F_Form_chineseName"].ToString();
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
            strSql.Append("select K_ProblemAndResources_LinkCase_id,K_ProblemAndResources_LinkCase_code,C_FK_code,K_ProblemAndResources_LinkCase_Courtcode,K_ProblemAndResources_LinkCase_BusinessFlowcode,K_ProblemAndResources_LinkCase_Formcode,K_ProblemAndResources_LinkCase_type ");
            strSql.Append(" FROM K_PorblemAndResources_LinkCase ");
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
            strSql.Append(" K_ProblemAndResources_LinkCase_id,K_ProblemAndResources_LinkCase_code,C_FK_code,K_ProblemAndResources_LinkCase_Courtcode,K_ProblemAndResources_LinkCase_BusinessFlowcode,K_ProblemAndResources_LinkCase_Formcode ");
            strSql.Append(" FROM K_PorblemAndResources_LinkCase ");
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
            strSql.Append("select count(1) FROM K_PorblemAndResources_LinkCase ");
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
                strSql.Append("order by T.K_ProblemAndResources_LinkCase_id desc");
            }
            strSql.Append(")AS Row, T.*  from K_PorblemAndResources_LinkCase T ");
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
            parameters[0].Value = "K_PorblemAndResources_LinkCase";
            parameters[1].Value = "K_ProblemAndResources_LinkCase_id";
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
