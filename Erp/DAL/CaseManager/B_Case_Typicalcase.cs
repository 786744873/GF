using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.CaseManager
{
    public class B_Case_Typicalcase
    {
        /// <summary>
        /// 数据访问类:B_Case_Typicalcase
        /// </summary>
        public B_Case_Typicalcase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_Case_Typicalcase_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Case_Typicalcase");
            strSql.Append(" where B_Case_Typicalcase_id=@B_Case_Typicalcase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_id", SqlDbType.Int,4)
			    };
            parameters[0].Value = B_Case_Typicalcase_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Case_Typicalcase(");
            strSql.Append("B_Case_Typicalcase_code,B_Case_code,P_Business_flow_code,P_Business_flow_form_code,B_Case_Typicalcase_title,B_Case_Typicalcase_description,B_Case_Typicalcase_creator,B_Case_Typicalcase_createTime,B_Case_Typicalcase_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@B_Case_Typicalcase_code,@B_Case_code,@P_Business_flow_code,@P_Business_flow_form_code,@B_Case_Typicalcase_title,@B_Case_Typicalcase_description,@B_Case_Typicalcase_creator,@B_Case_Typicalcase_createTime,@B_Case_Typicalcase_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Typicalcase_title", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_Typicalcase_description", SqlDbType.Text),
					new SqlParameter("@B_Case_Typicalcase_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Typicalcase_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Typicalcase_isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_Typicalcase_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.P_Business_flow_code;
            parameters[3].Value = model.P_Business_flow_form_code;
            parameters[4].Value = model.B_Case_Typicalcase_title;
            parameters[5].Value = model.B_Case_Typicalcase_description;
            parameters[6].Value = model.B_Case_Typicalcase_creator;
            parameters[7].Value = model.B_Case_Typicalcase_createTime;
            parameters[8].Value = model.B_Case_Typicalcase_isDelete;

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
        public bool Update(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Case_Typicalcase set ");
            strSql.Append("B_Case_Typicalcase_code=@B_Case_Typicalcase_code,");
            strSql.Append("B_Case_code=@B_Case_code,");
            strSql.Append("P_Business_flow_code=@P_Business_flow_code,");
            strSql.Append("P_Business_flow_form_code=@P_Business_flow_form_code,");
            strSql.Append("B_Case_Typicalcase_title=@B_Case_Typicalcase_title,");
            strSql.Append("B_Case_Typicalcase_description=@B_Case_Typicalcase_description,");
            strSql.Append("B_Case_Typicalcase_creator=@B_Case_Typicalcase_creator,");
            strSql.Append("B_Case_Typicalcase_createTime=@B_Case_Typicalcase_createTime,");
            strSql.Append("B_Case_Typicalcase_isDelete=@B_Case_Typicalcase_isDelete");
            strSql.Append(" where B_Case_Typicalcase_id=@B_Case_Typicalcase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@P_Business_flow_form_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Typicalcase_title", SqlDbType.VarChar,500),
					new SqlParameter("@B_Case_Typicalcase_description", SqlDbType.Text),
					new SqlParameter("@B_Case_Typicalcase_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_Case_Typicalcase_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_Case_Typicalcase_isDelete", SqlDbType.Int,4),
					new SqlParameter("@B_Case_Typicalcase_id", SqlDbType.Int,4)};
            parameters[0].Value = model.B_Case_Typicalcase_code;
            parameters[1].Value = model.B_Case_code;
            parameters[2].Value = model.P_Business_flow_code;
            parameters[3].Value = model.P_Business_flow_form_code;
            parameters[4].Value = model.B_Case_Typicalcase_title;
            parameters[5].Value = model.B_Case_Typicalcase_description;
            parameters[6].Value = model.B_Case_Typicalcase_creator;
            parameters[7].Value = model.B_Case_Typicalcase_createTime;
            parameters[8].Value = model.B_Case_Typicalcase_isDelete;
            parameters[9].Value = model.B_Case_Typicalcase_id;

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
        public bool Delete(int B_Case_Typicalcase_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_Typicalcase ");
            strSql.Append(" where B_Case_Typicalcase_id=@B_Case_Typicalcase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_Typicalcase_id;

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
        public bool DeleteByCode(Guid B_Case_Typicalcase_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_Typicalcase ");
            strSql.Append(" where B_Case_Typicalcase_code=@B_Case_Typicalcase_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Typicalcase_code;

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
        public bool DeleteList(string B_Case_Typicalcase_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_Case_Typicalcase ");
            strSql.Append(" where B_Case_Typicalcase_id in (" + B_Case_Typicalcase_idlist + ")  ");
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
        public CommonService.Model.CaseManager.B_Case_Typicalcase GetModel(int B_Case_Typicalcase_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_Typicalcase_id,B_Case_Typicalcase_code,B_Case_code,P_Business_flow_code,P_Business_flow_form_code,B_Case_Typicalcase_title,B_Case_Typicalcase_description,B_Case_Typicalcase_creator,B_Case_Typicalcase_createTime,B_Case_Typicalcase_isDelete from B_Case_Typicalcase ");
            strSql.Append(" where B_Case_Typicalcase_id=@B_Case_Typicalcase_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_Case_Typicalcase_id;

            CommonService.Model.CaseManager.B_Case_Typicalcase model = new CommonService.Model.CaseManager.B_Case_Typicalcase();
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
        public CommonService.Model.CaseManager.B_Case_Typicalcase GetModelByCode(Guid B_Case_Typicalcase_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 B_Case_Typicalcase_id,B_Case_Typicalcase_code,B_Case_code,P_Business_flow_code,P_Business_flow_form_code,B_Case_Typicalcase_title,B_Case_Typicalcase_description,B_Case_Typicalcase_creator,B_Case_Typicalcase_createTime,B_Case_Typicalcase_isDelete from B_Case_Typicalcase");
            strSql.Append(" where B_Case_Typicalcase_code=@B_Case_Typicalcase_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_Case_Typicalcase_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_Case_Typicalcase_code;

            CommonService.Model.CaseManager.B_Case_Typicalcase model = new CommonService.Model.CaseManager.B_Case_Typicalcase();
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
        public CommonService.Model.CaseManager.B_Case_Typicalcase DataRowToModel(DataRow row)
        {
            CommonService.Model.CaseManager.B_Case_Typicalcase model = new CommonService.Model.CaseManager.B_Case_Typicalcase();
            if (row != null)
            {
                if (row["B_Case_Typicalcase_id"] != null && row["B_Case_Typicalcase_id"].ToString() != "")
                {
                    model.B_Case_Typicalcase_id = int.Parse(row["B_Case_Typicalcase_id"].ToString());
                }
                if (row["B_Case_Typicalcase_code"] != null && row["B_Case_Typicalcase_code"].ToString() != "")
                {
                    model.B_Case_Typicalcase_code = new Guid(row["B_Case_Typicalcase_code"].ToString());
                }
                if (row["B_Case_code"] != null && row["B_Case_code"].ToString() != "")
                {
                    model.B_Case_code = new Guid(row["B_Case_code"].ToString());
                }
                if (row["P_Business_flow_code"] != null && row["P_Business_flow_code"].ToString() != "")
                {
                    model.P_Business_flow_code = new Guid(row["P_Business_flow_code"].ToString());
                }
                if (row["P_Business_flow_form_code"] != null && row["P_Business_flow_form_code"].ToString() != "")
                {
                    model.P_Business_flow_form_code = new Guid(row["P_Business_flow_form_code"].ToString());
                }
                if (row["B_Case_Typicalcase_title"] != null)
                {
                    model.B_Case_Typicalcase_title = row["B_Case_Typicalcase_title"].ToString();
                }
                if (row["B_Case_Typicalcase_description"] != null)
                {
                    model.B_Case_Typicalcase_description = row["B_Case_Typicalcase_description"].ToString();
                }
                if (row["B_Case_Typicalcase_creator"] != null && row["B_Case_Typicalcase_creator"].ToString() != "")
                {
                    model.B_Case_Typicalcase_creator = new Guid(row["B_Case_Typicalcase_creator"].ToString());
                }
                if (row["B_Case_Typicalcase_createTime"] != null && row["B_Case_Typicalcase_createTime"].ToString() != "")
                {
                    model.B_Case_Typicalcase_createTime = DateTime.Parse(row["B_Case_Typicalcase_createTime"].ToString());
                }
                if (row["B_Case_Typicalcase_isDelete"] != null && row["B_Case_Typicalcase_isDelete"].ToString() != "")
                {
                    model.B_Case_Typicalcase_isDelete = int.Parse(row["B_Case_Typicalcase_isDelete"].ToString());
                }
                //检查案件名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_Case_name"))
                {
                    if (row["B_Case_name"] != null)
                    {
                        model.B_Case_name = row["B_Case_name"].ToString();
                    }
                }
                //检查流程名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Businessflow_name"))
                {
                    if (row["P_Businessflow_name"] != null)
                    {
                        model.P_Businessflow_name = row["P_Businessflow_name"].ToString();
                    }
                }
                //检查表单名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("P_Businessflow_form_name"))
                {
                    if (row["P_Businessflow_form_name"] != null)
                    {
                        model.P_Businessflow_form_name = row["P_Businessflow_form_name"].ToString();
                    }
                }
                //检查表单名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Region_name"))
                {
                    if (row["Region_name"] != null)
                    {
                        model.Region_name = row["Region_name"].ToString();
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
            strSql.Append("select B_Case_Typicalcase_id,B_Case_Typicalcase_code,B_Case_code,P_Business_flow_code,P_Business_flow_form_code,B_Case_Typicalcase_title,B_Case_Typicalcase_description,B_Case_Typicalcase_creator,B_Case_Typicalcase_createTime,B_Case_Typicalcase_isDelete ");
            strSql.Append(" FROM B_Case_Typicalcase ");
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
            strSql.Append(" B_Case_Typicalcase_id,B_Case_Typicalcase_code,B_Case_code,P_Business_flow_code,P_Business_flow_form_code,B_Case_Typicalcase_title,B_Case_Typicalcase_description,B_Case_Typicalcase_creator,B_Case_Typicalcase_createTime,B_Case_Typicalcase_isDelete ");
            strSql.Append(" FROM B_Case_Typicalcase ");
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
        public int GetRecordCount(CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM B_Case_Typicalcase as T ");

            strSql.Append(" left join B_Case as a on a.B_Case_code=t.B_Case_code");

            strSql.Append(" left join (select c.P_Flow_name,b.P_Business_flow_code from P_Business_flow as b left join P_Flow as c on b.P_Fk_code=c.P_Flow_code) as d on d.P_Business_flow_code=t.P_Business_flow_code");

            strSql.Append(" left join (select e.B_Case_code,f.C_Region_name,f.C_Region_code from B_Case_link as e left join C_Region as f on e.C_FK_code=f.C_Region_code  where B_Case_link_type=6) as g on g.B_Case_code=t.B_Case_code");

            strSql.Append(" left join (select h.P_Business_flow_form_code,i.F_Form_chineseName from P_Business_flow_form as h left join F_Form i on h.F_Form_code=i.F_Form_code) as j on j.P_Business_flow_form_code=t.P_Business_flow_form_code");

            strSql.Append(" left join C_Court as h on h.C_Court_code=a.B_Case_courtFirst");

            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.Region_name != null)
                {
                    strSql.Append(" and g.C_Region_code like N'%'+@Region_name+'%' ");
                }
                if (model.P_Businessflow_name != null)
                {
                    strSql.Append(" and d.P_Flow_name like N'%'+@P_Businessflow_name+'%' ");
                }
                if (model.P_Businessflow_form_name != null)
                {
                    strSql.Append(" and j.F_Form_chineseName like N'%'+@P_Businessflow_form_name+'%' ");
                }
                if (model.P_Business_flow_code != null)
                {
                    strSql.Append(" and t.P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.P_Business_flow_form_code != null)
                {
                    strSql.Append(" and t.P_Business_flow_form_code=@P_Business_flow_form_code");
                }
                if (model.B_Case_court != null)
                {
                    strSql.Append(" and h.C_Court_name like N'%'+@B_Case_court+'%'");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@Region_name", SqlDbType.VarChar),
                    new SqlParameter("@P_Businessflow_name",SqlDbType.VarChar),
                    new SqlParameter("@P_Businessflow_form_name",SqlDbType.VarChar),
                    new SqlParameter("@P_Business_flow_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_court",SqlDbType.VarChar,50)
			};
            parameters[0].Value = model.Region_name;
            parameters[1].Value = model.P_Businessflow_name;
            parameters[2].Value = model.P_Businessflow_form_name;
            parameters[3].Value = model.P_Business_flow_code;
            parameters[4].Value = model.P_Business_flow_form_code;
            parameters[5].Value = model.B_Case_court;
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
        public DataSet GetListByPage(CommonService.Model.CaseManager.B_Case_Typicalcase model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.B_Case_Typicalcase_id desc");
            }
            strSql.Append(")AS Row, T.*,a.B_Case_name as B_Case_name,d.P_Flow_name as P_Businessflow_name,j.F_Form_chineseName as P_Businessflow_form_name from B_Case_Typicalcase T ");

            strSql.Append(" left join B_Case as a on a.B_Case_code=t.B_Case_code");

            strSql.Append(" left join (select c.P_Flow_name as P_Flow_name,b.P_Business_flow_code from P_Business_flow as b left join P_Flow as c on b.P_Flow_code=c.P_Flow_code) as d on d.P_Business_flow_code=t.P_Business_flow_code");

            strSql.Append(" left join (select e.B_Case_code,f.C_Region_name as C_Region_name,f.C_Region_code as C_Region_code  from B_Case_link as e left join C_Region as f on e.C_FK_code=f.C_Region_code where B_Case_link_type=6) as g on g.B_Case_code=t.B_Case_code");

            strSql.Append(" left join (select h.P_Business_flow_form_code,i.F_Form_chineseName as F_Form_chineseName from P_Business_flow_form as h left join F_Form i on h.F_Form_code=i.F_Form_code) as j on j.P_Business_flow_form_code=t.P_Business_flow_form_code");

            strSql.Append(" left join C_Court as h on h.C_Court_code=a.B_Case_courtFirst");

            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.Region_name != null)
                {
                    strSql.Append(" and g.C_Region_code like N'%'+@Region_name+'%' ");
                }
                if (model.P_Businessflow_name != null)
                {
                    strSql.Append(" and d.P_Flow_name like N'%'+@P_Businessflow_name+'%' ");
                }
                if (model.P_Businessflow_form_name != null)
                {
                    strSql.Append(" and j.F_Form_chineseName like N'%'+@P_Businessflow_form_name+'%' ");
                }
                if (model.P_Business_flow_code != null)
                {
                    strSql.Append(" and t.P_Business_flow_code=@P_Business_flow_code");
                }
                if (model.P_Business_flow_form_code != null)
                {
                    strSql.Append(" and t.P_Business_flow_form_code=@P_Business_flow_form_code");
                }
                if (model.B_Case_court != null)
                {
                    strSql.Append(" and h.C_Court_name like N'%'+@B_Case_court+'%'");
                }

            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@Region_name", SqlDbType.VarChar),
                    new SqlParameter("@P_Businessflow_name",SqlDbType.VarChar),
                    new SqlParameter("@P_Businessflow_form_name",SqlDbType.VarChar),
                    new SqlParameter("@P_Business_flow_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@P_Business_flow_form_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_Case_court",SqlDbType.VarChar,50)
			};
            parameters[0].Value = model.Region_name;
            parameters[1].Value = model.P_Businessflow_name;
            parameters[2].Value = model.P_Businessflow_form_name;
            parameters[3].Value = model.P_Business_flow_code;
            parameters[4].Value = model.P_Business_flow_form_code;
            parameters[5].Value = model.B_Case_court;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

