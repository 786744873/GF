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
    /// 数据访问类:组织机构—岗位—人员中间表
    /// 作者：贺太玉
    /// 日期：2016/01/20
    /// </summary>
    public class C_Organization_post_user
    {
        public C_Organization_post_user()
        { }
   

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Organization_post_user_id", "C_Organization_post_user");
        }

        /// <summary>
        /// 检查是否存在记录
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">人员Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public bool Exists(Guid orgCode, Guid userCode, Guid postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Organization_post_user with(nolock) ");
            strSql.Append("where C_Organization_code=@C_Organization_code ");         
            strSql.Append("and C_User_code=@C_User_code ");
            strSql.Append("and C_Post_code=@C_Post_code ");
            strSql.Append("and C_Organization_post_user_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("C_User_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("C_Post_code", SqlDbType.UniqueIdentifier,16)                    
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization_post_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Organization_post_user(");
            strSql.Append("C_Organization_code,C_Post_code,C_User_code,C_Organization_post_user_isDelete,C_Organization_post_user_deleteTime,C_Organization_post_user_creator,C_Organization_post_user_createTime)");
            strSql.Append(" values (");
            strSql.Append("@C_Organization_code,@C_Post_code,@C_User_code,@C_Organization_post_user_isDelete,@C_Organization_post_user_deleteTime,@C_Organization_post_user_creator,@C_Organization_post_user_createTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_user_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_post_user_deleteTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_user_createTime", SqlDbType.DateTime)};
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Post_code;
            parameters[2].Value = model.C_User_code;
            parameters[3].Value = model.C_Organization_post_user_isDelete;
            parameters[4].Value = model.C_Organization_post_user_deleteTime;
            parameters[5].Value = model.C_Organization_post_user_creator;
            parameters[6].Value = model.C_Organization_post_user_createTime;

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
        public bool Update(CommonService.Model.SysManager.C_Organization_post_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post_user set ");
            strSql.Append("C_Organization_code=@C_Organization_code,");
            strSql.Append("C_Post_code=@C_Post_code,");
            strSql.Append("C_User_code=@C_User_code,");
            strSql.Append("C_Organization_post_user_isDelete=@C_Organization_post_user_isDelete,");
            strSql.Append("C_Organization_post_user_deleteTime=@C_Organization_post_user_deleteTime,");
            strSql.Append("C_Organization_post_user_creator=@C_Organization_post_user_creator,");
            strSql.Append("C_Organization_post_user_createTime=@C_Organization_post_user_createTime");
            strSql.Append(" where C_Organization_post_user_id=@C_Organization_post_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_user_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_post_user_deleteTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_user_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_post_user_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_post_user_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Post_code;
            parameters[2].Value = model.C_User_code;
            parameters[3].Value = model.C_Organization_post_user_isDelete;
            parameters[4].Value = model.C_Organization_post_user_deleteTime;
            parameters[5].Value = model.C_Organization_post_user_creator;
            parameters[6].Value = model.C_Organization_post_user_createTime;
            parameters[7].Value = model.C_Organization_post_user_id;

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
        /// 删除关联组织机构-用户-岗位-数据
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public bool Delete(Guid orgCode,Guid userCode,Guid postCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization_post_user set ");
            strSql.Append("C_Organization_post_user_isDelete=1,C_Organization_post_user_deleteTime=getdate() ");
            strSql.Append("where C_Organization_code=@C_Organization_code ");
            strSql.Append("and C_User_code=@C_User_code ");
            strSql.Append("and C_Post_code=@C_Post_code ");
            strSql.Append("and C_Organization_post_user_isDelete=0");
           
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;
            parameters[2].Value = postCode;

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
        public bool Delete(int C_Organization_post_user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Organization_post_user ");
            strSql.Append(" where C_Organization_post_user_id=SQL2012C_Organization_post_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012C_Organization_post_user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_post_user_id;

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
        public bool DeleteList(string C_Organization_post_user_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Organization_post_user ");
            strSql.Append(" where C_Organization_post_user_id in (" + C_Organization_post_user_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Organization_post_user GetModel(int C_Organization_post_user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Organization_post_user_id,C_Organization_code,C_Post_code,C_User_code,C_Organization_post_user_isDelete,C_Organization_post_user_deleteTime,C_Organization_post_user_creator,C_Organization_post_user_createTime from C_Organization_post_user ");
            strSql.Append(" where C_Organization_post_user_id=@C_Organization_post_user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_post_user_id", SqlDbType.Int)
			};
            parameters[0].Value = C_Organization_post_user_id;

            CommonService.Model.SysManager.C_Organization_post_user model = new CommonService.Model.SysManager.C_Organization_post_user();
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
        public CommonService.Model.SysManager.C_Organization_post_user GetModelByPostAndUser(Guid postCode,Guid userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Organization_post_user_id,C_Organization_code,C_Post_code,C_User_code,C_Organization_post_user_isDelete,C_Organization_post_user_deleteTime,C_Organization_post_user_creator,C_Organization_post_user_createTime from C_Organization_post_user ");
            strSql.Append(" where C_Organization_post_user_isDelete=0");
            strSql.Append(" and C_Post_code=@C_Post_code");
            strSql.Append(" and C_User_code=@C_User_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = postCode;
            parameters[1].Value = userCode;

            CommonService.Model.SysManager.C_Organization_post_user model = new CommonService.Model.SysManager.C_Organization_post_user();
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
        public CommonService.Model.SysManager.C_Organization_post_user GetModelByOrgAndPostAndUser(Guid organizationCode,Guid postCode, Guid userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Organization_post_user_id,C_Organization_code,C_Post_code,C_User_code,C_Organization_post_user_isDelete,C_Organization_post_user_deleteTime,C_Organization_post_user_creator,C_Organization_post_user_createTime from C_Organization_post_user ");
            strSql.Append(" where C_Organization_post_user_isDelete=0");
            strSql.Append(" and C_Organization_code=@C_Organization_code");
            strSql.Append(" and C_Post_code=@C_Post_code");
            strSql.Append(" and C_User_code=@C_User_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Post_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Organization_code",SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = postCode;
            parameters[1].Value = userCode;
            parameters[2].Value = organizationCode;

            CommonService.Model.SysManager.C_Organization_post_user model = new CommonService.Model.SysManager.C_Organization_post_user();
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
        public CommonService.Model.SysManager.C_Organization_post_user DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Organization_post_user model = new CommonService.Model.SysManager.C_Organization_post_user();
            if (row != null)
            {
                if (row["C_Organization_post_user_id"] != null && row["C_Organization_post_user_id"].ToString() != "")
                {
                    model.C_Organization_post_user_id = int.Parse(row["C_Organization_post_user_id"].ToString());
                }
                if (row["C_Organization_code"] != null && row["C_Organization_code"].ToString() != "")
                {
                    model.C_Organization_code = new Guid(row["C_Organization_code"].ToString());
                }
                //检查组织机构名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Org_name"))
                {
                    if (row["Org_name"] != null)
                    {
                        model.Org_name = row["Org_name"].ToString();
                    }
                }
                //检查组织机构所属区域Code(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Org_region_code"))
                {
                    if (row["Org_region_code"] != null && row["Org_region_code"].ToString() != "")
                    {
                        model.Org_region_code = new Guid(row["Org_region_code"].ToString());
                    }
                }
                //检查组织机构所属区域名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("Org_region_name"))
                {
                    if (row["Org_region_name"] != null)
                    {
                        model.Org_region_name = row["Org_region_name"].ToString();
                    }
                }

                if (row["C_Post_code"] != null && row["C_Post_code"].ToString() != "")
                {
                    model.C_Post_code = new Guid(row["C_Post_code"].ToString());
                }

                //检查岗位名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Post_name"))
                {
                    if (row["C_Post_name"] != null)
                    {
                        model.C_Post_name = row["C_Post_name"].ToString();
                    }
                }

                //检查岗位组Code(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Post_group_code"))
                {
                    if (row["C_Post_group_code"] != null && row["C_Post_group_code"].ToString() != "")
                    {
                        model.C_Post_group_code = new Guid(row["C_Post_group_code"].ToString());
                    }
                }

                //检查岗位组名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Post_group_name"))
                {
                    if (row["C_Post_group_name"] != null)
                    {
                        model.C_Post_group_name = row["C_Post_group_name"].ToString();
                    }
                }

                if (row["C_User_code"] != null && row["C_User_code"].ToString() != "")
                {
                    model.C_User_code = new Guid(row["C_User_code"].ToString());
                }
                if (row["C_Organization_post_user_isDelete"] != null && row["C_Organization_post_user_isDelete"].ToString() != "")
                {
                    if ((row["C_Organization_post_user_isDelete"].ToString() == "1") || (row["C_Organization_post_user_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Organization_post_user_isDelete = true;
                    }
                    else
                    {
                        model.C_Organization_post_user_isDelete = false;
                    }
                }
                if (row["C_Organization_post_user_deleteTime"] != null && row["C_Organization_post_user_deleteTime"].ToString() != "")
                {
                    model.C_Organization_post_user_deleteTime = DateTime.Parse(row["C_Organization_post_user_deleteTime"].ToString());
                }
                if (row["C_Organization_post_user_creator"] != null && row["C_Organization_post_user_creator"].ToString() != "")
                {
                    model.C_Organization_post_user_creator = new Guid(row["C_Organization_post_user_creator"].ToString());
                }
                if (row["C_Organization_post_user_createTime"] != null && row["C_Organization_post_user_createTime"].ToString() != "")
                {
                    model.C_Organization_post_user_createTime = DateTime.Parse(row["C_Organization_post_user_createTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 根据部门Guid，人员Guid，获取所分配岗位
        /// </summary>
        /// <param name="orgCode">部门Guid</param>
        /// <param name="userCode">人员Guid</param>
        /// <returns></returns>
        public DataSet GetHasDisbutedPosts(Guid? orgCode,Guid? userCode)
        {             
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OPU.*,P.C_Post_name As C_Post_name ");
            strSql.Append("from C_Organization_post_user As OPU with(nolock),C_Post As P with(nolock) ");
            strSql.Append("where OPU.C_Post_code=P.C_Post_code ");
            strSql.Append("and OPU.C_Organization_post_user_isDelete=0 and P.C_Post_isDelete=0 ");
            if (orgCode != null)
            {
                strSql.Append("and OPU.C_Organization_code=@C_Organization_code ");
            }
            if (userCode != null)
            {
                strSql.Append("and OPU.C_User_code=@C_User_code ");
            }            
           
            SqlParameter[] parameters = {					
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16)  
            };
            parameters[0].Value = orgCode;
            parameters[1].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据人员Guid，获取人员所属岗位集合
        /// </summary>
        /// <param name="userCode">人员Guid</param>
        /// <returns></returns>      
        public DataSet GetHasDisbutedPostsByUser(Guid? userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,R.C_Region_code As Org_region_code,R.C_Region_name As Org_region_name,G.C_Group_code As C_Post_group_code,G.C_Group_name As C_Post_group_name from");
            strSql.Append("(");
            strSql.Append("select OPU.*,P.C_Post_name As C_Post_name,O.C_Organization_name As Org_name,O.C_Organization_Area,P.C_Post_group ");              
            strSql.Append("from C_Organization_post_user As OPU with(nolock),C_Post As P with(nolock),C_Organization As O with(nolock) ");               
            strSql.Append("where OPU.C_Post_code=P.C_Post_code and OPU.C_Organization_code=O.C_Organization_code ");
            strSql.Append("and O.C_Organization_isDelete=0 and O.C_Organization_state=1 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append("and OPU.C_Organization_post_user_isDelete=0 ");
           
            if (userCode != null)
            {
                strSql.Append("and OPU.C_User_code=@C_User_code ");
            }

            strSql.Append(") As T ");
            strSql.Append("left join C_Region As R with(nolock) on T.C_Organization_Area=R.C_Region_code and R.C_Region_isDelete=0 ");
            strSql.Append("inner join C_Group As G with(nolock) on T.C_Post_group=G.C_Group_code and G.C_Group_isDelete=0");

            SqlParameter[] parameters = {				
                    new SqlParameter("@C_User_code", SqlDbType.UniqueIdentifier,16)  
            };
            parameters[0].Value = userCode;         

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_post_user_id,C_Organization_code,C_Post_code,C_User_code,C_Organization_post_user_isDelete,C_Organization_post_user_deleteTime,C_Organization_post_user_creator,C_Organization_post_user_createTime ");
            strSql.Append(" FROM C_Organization_post_user ");
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
            strSql.Append(" C_Organization_post_user_id,C_Organization_code,C_Post_code,C_User_code,C_Organization_post_user_isDelete,C_Organization_post_user_deleteTime,C_Organization_post_user_creator,C_Organization_post_user_createTime ");
            strSql.Append(" FROM C_Organization_post_user ");
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
            strSql.Append("select count(1) FROM C_Organization_post_user ");
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
                strSql.Append("order by T.C_Organization_post_user_id desc");
            }
            strSql.Append(")AS Row, T.*  from C_Organization_post_user T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
 
    }
}
