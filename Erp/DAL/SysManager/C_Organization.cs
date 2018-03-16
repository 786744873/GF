using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:组织架构表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Organization
    {
        public C_Organization()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Organization_id", "C_Organization");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Organization_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Organization");
            strSql.Append(" where C_Organization_id=@C_Organization_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查新的组织架构是否存在
        /// </summary>
        /// <param name="userguid"></param>
        /// <param name="newguid"></param>
        /// <returns></returns>
        public int SelectRegion(Guid userguid, Guid newguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from C_Userinfo_region where C_Userinfo_code=@Userguid and C_Region_code=@Oldguid ");

            SqlParameter[] parameters = {
                new SqlParameter("@Userguid",SqlDbType.UniqueIdentifier),
                   new SqlParameter("@Oldguid",SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = userguid;
            parameters[1].Value = newguid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 批量更新新的组织架构
        /// </summary>
        /// <param name="userguid"></param>
        /// <param name="oldguid"></param>
        /// <returns></returns>
        public void UpdateNewregion(Guid userguid, Guid newguid)
        {
            int isupdate = SelectRegion(userguid, newguid);
            if (isupdate <= 0)
            {

                //该表无主键信息，请自定义主键/条件字段
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO C_Userinfo_region (");
                strSql.Append("C_Userinfo_code ,C_Region_code) ");
                strSql.Append("VALUES(");
                strSql.Append("@Userguid, @Newguid)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                new SqlParameter("@Userguid",SqlDbType.UniqueIdentifier),
                   new SqlParameter("@Newguid",SqlDbType.UniqueIdentifier)
			};
                parameters[0].Value = userguid;
                parameters[1].Value = newguid;

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            }


        }
        /// <summary>
        /// 批量修改老的组织架构
        /// </summary>
        /// <param name="userguid"></param>
        /// <param name="oldguid"></param>
        /// <returns></returns>
        public int Updateregion(Guid userguid, Guid oldguid)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Userinfo_region  ");
            strSql.Append(" where C_Userinfo_code=@Userguid and C_Region_code=@Oldguid");
            SqlParameter[] parameters = {
                new SqlParameter("@Userguid",SqlDbType.UniqueIdentifier),
                   new SqlParameter("@Oldguid",SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = userguid;
            parameters[1].Value = oldguid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Organization(");
            strSql.Append("C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_isMarketing,C_Organization_Area)");
            strSql.Append(" values (");
            strSql.Append("@C_Organization_code,@C_Organization_name,@C_Organization_isDelete,@C_Organization_parent,@C_Organization_creator,@C_Organization_createTime,@C_Organization_phone,@C_Organization_fax,@C_Organization_address,@C_Organization_remark,@C_Organization_order,@C_Organization_level,@C_Organization_state,@C_Organization_isMarketing,@C_Organization_Area)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Organization_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_phone", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_fax", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_address", SqlDbType.VarChar,100),
					new SqlParameter("@C_Organization_remark", SqlDbType.VarChar,500),
					new SqlParameter("@C_Organization_order", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_level", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_state", SqlDbType.Int,4),
                    new SqlParameter("@C_Organization_isMarketing", SqlDbType.Bit,1),
                              	new SqlParameter("@C_Organization_Area", SqlDbType.UniqueIdentifier,16),};

            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Organization_name;
            parameters[2].Value = model.C_Organization_isDelete;
            parameters[3].Value = model.C_Organization_parent;
            parameters[4].Value = model.C_Organization_creator;
            parameters[5].Value = model.C_Organization_createTime;
            parameters[6].Value = model.C_Organization_phone;
            parameters[7].Value = model.C_Organization_fax;
            parameters[8].Value = model.C_Organization_address;
            parameters[9].Value = model.C_Organization_remark;
            parameters[10].Value = model.C_Organization_order;
            parameters[11].Value = model.C_Organization_level;
            parameters[12].Value = model.C_Organization_state;
            parameters[13].Value = model.C_Organization_isMarketing;
            parameters[14].Value = model.C_Organization_Area;
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
        public bool UpdateAll(Guid areaguid, List<CommonService.Model.SysManager.C_Organization> list)
        {
            int rows = 0;
            foreach (CommonService.Model.SysManager.C_Organization item in list)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update C_Organization set ");
                strSql.Append("C_Organization_Area=@C_Organization_Area");
                strSql.Append(" where C_Organization_id=@C_Organization_id");
                SqlParameter[] parameters = {				
                    	new SqlParameter("@C_Organization_Area", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4)};

                parameters[0].Value = areaguid;
                parameters[1].Value = item.C_Organization_id;

                int rows2 = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                rows += rows2;
            }
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
        public bool Update(CommonService.Model.SysManager.C_Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization set ");
            strSql.Append("C_Organization_code=@C_Organization_code,");
            strSql.Append("C_Organization_name=@C_Organization_name,");
            strSql.Append("C_Organization_isDelete=@C_Organization_isDelete,");
            strSql.Append("C_Organization_parent=@C_Organization_parent,");
            strSql.Append("C_Organization_creator=@C_Organization_creator,");
            strSql.Append("C_Organization_createTime=@C_Organization_createTime,");
            strSql.Append("C_Organization_phone=@C_Organization_phone,");
            strSql.Append("C_Organization_fax=@C_Organization_fax,");
            strSql.Append("C_Organization_address=@C_Organization_address,");
            strSql.Append("C_Organization_remark=@C_Organization_remark,");
            strSql.Append("C_Organization_order=@C_Organization_order,");
            strSql.Append("C_Organization_level=@C_Organization_level,");
            strSql.Append("C_Organization_state=@C_Organization_state,");
            strSql.Append("C_Organization_Area=@C_Organization_Area,");

            strSql.Append("C_Organization_isMarketing=@C_Organization_isMarketing ");
            strSql.Append(" where C_Organization_id=@C_Organization_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Organization_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_phone", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_fax", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_address", SqlDbType.VarChar,100),
					new SqlParameter("@C_Organization_remark", SqlDbType.VarChar,500),
					new SqlParameter("@C_Organization_order", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_level", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_state", SqlDbType.Int,4),
                    	new SqlParameter("@C_Organization_Area", SqlDbType.UniqueIdentifier,16),
                        	new SqlParameter("@C_Organization_isMarketing", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Organization_name;
            parameters[2].Value = model.C_Organization_isDelete;
            parameters[3].Value = model.C_Organization_parent;
            parameters[4].Value = model.C_Organization_creator;
            parameters[5].Value = model.C_Organization_createTime;
            parameters[6].Value = model.C_Organization_phone;
            parameters[7].Value = model.C_Organization_fax;
            parameters[8].Value = model.C_Organization_address;
            parameters[9].Value = model.C_Organization_remark;
            parameters[10].Value = model.C_Organization_order;
            parameters[11].Value = model.C_Organization_level;
            parameters[12].Value = model.C_Organization_state;
            parameters[13].Value = model.C_Organization_Area;
            parameters[14].Value = model.C_Organization_isMarketing;
            parameters[15].Value = model.C_Organization_id;

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
        public bool Delete(int C_Organization_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization set C_Organization_isDelete=1 ");
            strSql.Append("where C_Organization_id=@C_Organization_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_id;

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
        public bool Delete(Guid C_Organization_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Organization set C_Organization_isDelete=1 ");
            strSql.Append(" where C_Organization_code=@C_Organization_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = C_Organization_code;

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
        public bool DeleteList(string C_Organization_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Organization ");
            strSql.Append(" where C_Organization_id in (" + C_Organization_idlist + ")  ");
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
        public CommonService.Model.SysManager.C_Organization GetModel(int C_Organization_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_isMarketing from C_Organization ");
            strSql.Append(" where C_Organization_id=@C_Organization_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Organization_id;

            CommonService.Model.SysManager.C_Organization model = new CommonService.Model.SysManager.C_Organization();
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
        ///  得到一个对象实体
        /// </summary>
        /// <param name="C_Organization_id"></param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Organization GetModel(Guid C_Organization_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_Area,'' As C_Organization_parent_name,C_Organization_isMarketing from C_Organization ");
            strSql.Append(" where C_Organization_code=@C_Organization_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = C_Organization_code;

            CommonService.Model.SysManager.C_Organization model = new CommonService.Model.SysManager.C_Organization();
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
        /// 通过级别获取级别下排序列最大的实体对象
        /// </summary>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Organization GetMaxOrderModelByLevel(int level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,'' As C_Organization_parent_name,C_Organization_isMarketing from C_Organization ");
            strSql.Append(" where C_Organization_level=@C_Organization_level ");
            strSql.Append("order by C_Organization_order Desc");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_level", SqlDbType.Int,4)
			};
            parameters[0].Value = level;

            CommonService.Model.SysManager.C_Organization model = new CommonService.Model.SysManager.C_Organization();
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
        /// 通过父级机构Guid，获取子集机构集合
        /// </summary>
        /// <param name="parentCode">父级机构Guid</param>
        /// <returns></returns>
        public DataSet GetModelByParent(Guid parentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,'' As C_Organization_parent_name,C_Organization_isMarketing ");
            strSql.Append("from C_Organization WITH(NOLOCK) ");
            strSql.Append("where C_Organization_parent=@C_Organization_parent ");
            strSql.Append("and C_Organization_isDelete=0 and C_Organization_state=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
        /// <summary>
        /// 根据老的组织架构取出当前组织架构下面的所有人员
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public DataSet GetAllUserinfor(List<CommonService.Model.SysManager.C_Organization> list)
        {
            string ss = "";
            foreach (CommonService.Model.SysManager.C_Organization item in list)
            {
                ss = ss + item.C_Organization_code + ",";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_Userinfo_id ,C_Userinfo_code ,C_Userinfo_name,C_Userinfo_loginID ,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent ,C_Userinfo_description,C_Userinfo_state ,C_Userinfo_isDefault,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization ,C_Userinfo_post,FUserID ,FEmpID FROM C_Userinfo ");

            strSql.Append("where @C_Organization_parent like N'%'+convert(varchar(50),C_Userinfo_Organization)+'%'  ");
            strSql.Append("and C_Userinfo_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_parent", SqlDbType.VarChar,1000)
			};
            parameters[0].Value = ss;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
        /// <summary>
        /// 通过父亲获取父亲下排序列最大的实体对象
        /// </summary>
        /// <param name="parentCode">级别</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Organization GetMaxOrderModelByParent(Guid parentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,'' As C_Organization_parent_name,C_Organization_isMarketing from C_Organization ");
            strSql.Append(" where C_Organization_parent=@C_Organization_parent ");
            strSql.Append("order by C_Organization_order Desc");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

            CommonService.Model.SysManager.C_Organization model = new CommonService.Model.SysManager.C_Organization();
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
        public CommonService.Model.SysManager.C_Userinfo DataRowToModel2(DataRow row)
        {
            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
            if (row != null)
            {
                if (row["C_Userinfo_id"] != null && row["C_Userinfo_id"].ToString() != "")
                {
                    model.C_Userinfo_id = int.Parse(row["C_Userinfo_id"].ToString());
                }
                if (row["C_Userinfo_code"] != null && row["C_Userinfo_code"].ToString() != "")
                {
                    model.C_Userinfo_code = new Guid(row["C_Userinfo_code"].ToString());
                }
                if (row["C_Userinfo_name"] != null)
                {
                    model.C_Userinfo_name = row["C_Userinfo_name"].ToString();
                }
                if (row["C_Userinfo_loginID"] != null)
                {
                    model.C_Userinfo_loginID = row["C_Userinfo_loginID"].ToString();
                }
                if (row["C_Userinfo_password"] != null)
                {
                    model.C_Userinfo_password = row["C_Userinfo_password"].ToString();
                }
                if (row["C_Userinfo_roleID"] != null && row["C_Userinfo_roleID"].ToString() != "")
                {
                    model.C_Userinfo_roleID = int.Parse(row["C_Userinfo_roleID"].ToString());
                }
                if (row["C_Userinfo_isDelete"] != null && row["C_Userinfo_isDelete"].ToString() != "")
                {
                    if ((row["C_Userinfo_isDelete"].ToString() == "1") || (row["C_Userinfo_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Userinfo_isDelete = true;
                    }
                    else
                    {
                        model.C_Userinfo_isDelete = false;
                    }
                }
                if (row["C_Userinfo_parent"] != null && row["C_Userinfo_parent"].ToString() != "")
                {
                    model.C_Userinfo_parent = new Guid(row["C_Userinfo_parent"].ToString());
                }
                if (row["C_Userinfo_description"] != null)
                {
                    model.C_Userinfo_description = row["C_Userinfo_description"].ToString();
                }
                if (row["C_Userinfo_state"] != null && row["C_Userinfo_state"].ToString() != "")
                {
                    model.C_Userinfo_state = int.Parse(row["C_Userinfo_state"].ToString());
                }
                if (row["C_Userinfo_creator"] != null && row["C_Userinfo_creator"].ToString() != "")
                {
                    model.C_Userinfo_creator = new Guid(row["C_Userinfo_creator"].ToString());
                }
                if (row["C_Userinfo_createTime"] != null && row["C_Userinfo_createTime"].ToString() != "")
                {
                    model.C_Userinfo_createTime = DateTime.Parse(row["C_Userinfo_createTime"].ToString());
                }
                if (row["C_Userinfo_Organization"] != null && row["C_Userinfo_Organization"].ToString() != "")
                {
                    model.C_Userinfo_Organization = new Guid(row["C_Userinfo_Organization"].ToString());
                }
                if (row["C_Userinfo_post"] != null && row["C_Userinfo_post"].ToString() != "")
                {
                    model.C_Userinfo_post = new Guid(row["C_Userinfo_post"].ToString());
                }


                //检查岗位名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Userinfo_post_name"))
                {
                    if (row["C_Userinfo_post_name"] != null)
                    {
                        model.C_Userinfo_post_name = row["C_Userinfo_post_name"].ToString();
                    }
                }
                //检查组织机构名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Userinfo_Organization_name"))
                {
                    if (row["C_Userinfo_Organization_name"] != null)
                    {
                        model.C_Userinfo_Organization_name = row["C_Userinfo_Organization_name"].ToString();
                    }
                }
                //检查角色名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Userinfo_Roles_name"))
                {
                    if (row["C_Userinfo_Roles_name"] != null)
                    {
                        model.C_Userinfo_Roles_name = row["C_Userinfo_Roles_name"].ToString();
                    }
                }
                if (row["C_Userinfo_isDefault"] != null && row["C_Userinfo_isDefault"].ToString() != "")
                {
                    if ((row["C_Userinfo_isDefault"].ToString() == "1") || (row["C_Userinfo_isDefault"].ToString().ToLower() == "true"))
                    {
                        model.C_Userinfo_isDefault = true;
                    }
                    else
                    {
                        model.C_Userinfo_isDefault = false;
                    }
                }
                //检查区域名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Region_abbreviation"))
                {
                    if (row["C_Region_abbreviation"] != null)
                    {
                        model.C_Region_abbreviation = row["C_Region_abbreviation"].ToString();
                    }
                }
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Organization DataRowToModel(DataRow row)
        {
            CommonService.Model.SysManager.C_Organization model = new CommonService.Model.SysManager.C_Organization();
            if (row != null)
            {
                if (row["C_Organization_id"] != null && row["C_Organization_id"].ToString() != "")
                {
                    model.C_Organization_id = int.Parse(row["C_Organization_id"].ToString());
                }
                if (row["C_Organization_code"] != null && row["C_Organization_code"].ToString() != "")
                {
                    model.C_Organization_code = new Guid(row["C_Organization_code"].ToString());
                }
                if (row["C_Organization_name"] != null)
                {
                    model.C_Organization_name = row["C_Organization_name"].ToString();
                }
                if (row["C_Organization_isDelete"] != null && row["C_Organization_isDelete"].ToString() != "")
                {
                    if ((row["C_Organization_isDelete"].ToString() == "1") || (row["C_Organization_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.C_Organization_isDelete = true;
                    }
                    else
                    {
                        model.C_Organization_isDelete = false;
                    }
                }
                if (row["C_Organization_isMarketing"] != null && row["C_Organization_isMarketing"].ToString() != "")
                {
                    if ((row["C_Organization_isMarketing"].ToString() == "1") || (row["C_Organization_isMarketing"].ToString().ToLower() == "true"))
                    {
                        model.C_Organization_isMarketing = true;
                    }
                    else
                    {
                        model.C_Organization_isMarketing = false;
                    }
                }
                if (row["C_Organization_parent"] != null && row["C_Organization_parent"].ToString() != "")
                {
                    model.C_Organization_parent = new Guid(row["C_Organization_parent"].ToString());
                }
                //父亲机构名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Organization_parent_name"))
                {
                    model.C_Organization_parent_name = row["C_Organization_parent_name"].ToString();
                }
                if (row["C_Organization_creator"] != null && row["C_Organization_creator"].ToString() != "")
                {
                    model.C_Organization_creator = new Guid(row["C_Organization_creator"].ToString());
                }
                if (row["C_Organization_createTime"] != null && row["C_Organization_createTime"].ToString() != "")
                {
                    model.C_Organization_createTime = DateTime.Parse(row["C_Organization_createTime"].ToString());
                }
                if (row["C_Organization_phone"] != null)
                {
                    model.C_Organization_phone = row["C_Organization_phone"].ToString();
                }
                if (row["C_Organization_fax"] != null)
                {
                    model.C_Organization_fax = row["C_Organization_fax"].ToString();
                }
                if (row["C_Organization_address"] != null)
                {
                    model.C_Organization_address = row["C_Organization_address"].ToString();
                }
                if (row["C_Organization_remark"] != null)
                {
                    model.C_Organization_remark = row["C_Organization_remark"].ToString();
                }
                if (row["C_Organization_order"] != null && row["C_Organization_order"].ToString() != "")
                {
                    model.C_Organization_order = int.Parse(row["C_Organization_order"].ToString());
                }
                if (row["C_Organization_level"] != null && row["C_Organization_level"].ToString() != "")
                {
                    model.C_Organization_level = int.Parse(row["C_Organization_level"].ToString());
                }
                if (row["C_Organization_state"] != null && row["C_Organization_state"].ToString() != "")
                {
                    model.C_Organization_state = int.Parse(row["C_Organization_state"].ToString());
                }
                if (row.Table.Columns.Contains("C_Organization_Area"))
                {
                    if (row["C_Organization_Area"] != null && row["C_Organization_Area"].ToString() != "")
                    {
                        model.C_Organization_Area = new Guid(row["C_Organization_Area"].ToString());
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 根据用户获得用户关联区域下包含（type=1、律师 2、专业顾问）的组织架构
        /// </summary>
        /// <param name="userinfoCode">用户Guid</param>
        /// <param name="type">type=1、包含律师的组织架构 2、包含专业顾问的组织架构</param>
        /// <returns></returns>
        public DataSet GetContainLawyerOrAdvisorList(Guid userinfoCode, int? type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_isMarketing ");
            strSql.Append(" FROM C_Organization as T");
            strSql.Append(" where 1=1");
            strSql.Append(" and exists(select 1 from C_Organization_post_user_region as OPUR where T.C_Organization_Area=OPUR.C_region_code and OPUR.C_User_code=@C_Userinfo_code)");
            if (type == 1)
            {
                strSql.Append(" and exists(select 1 from C_Organization_post as OP where T.C_Organization_code=OP.C_Organization_code and OP.C_Organization_post_isDelete=0 and OP.C_Post_code in ('a605ab84-c55c-4dbd-bbc8-e9884ef2db32','bb69a900-1906-446d-a8c5-08c6d1e798ee','e7db1ad6-f51f-4f5e-a400-d5e442b4742f','AEAE4D40-4E65-4694-BA3D-0BF4D4777617'))");
            }
            else
            {
                strSql.Append(" and exists(select 1 from C_Organization_post as OP where T.C_Organization_code=OP.C_Organization_code and OP.C_Organization_post_isDelete=0 and OP.C_Post_code = 'c5e154c7-d8fe-46d4-9fa6-07084403a88e')");
            }
            strSql.Append(" and T.C_Organization_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = userinfoCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_isMarketing ");
            strSql.Append(" FROM C_Organization ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得全部数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_Area,C_Organization_isMarketing ");
            strSql.Append("FROM C_Organization WITH(NOLOCK) ");
            strSql.Append("where C_Organization_isDelete=0 ");

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据组织架构code获得列表
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public DataSet GetChirldAllList(Guid? orgCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.DeptTreeDec('"+orgCode+"') ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据用户Guid获得关联部门
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByUserCode(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_isMarketing ");
            strSql.Append(" FROM C_Organization as T");
            strSql.Append(" where 1=1");
            strSql.Append(" and T.C_Organization_isDelete=0");
            strSql.Append(" and exists(select 1 from C_Organization_post_user as OPU where OPU.C_Organization_post_user_isDelete=0 and OPU.C_Organization_code=T.C_Organization_code and OPU.C_User_code=@C_Userinfo_code)");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = userCode;
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
            strSql.Append(" C_Organization_id,C_Organization_code,C_Organization_name,C_Organization_isDelete,C_Organization_parent,C_Organization_creator,C_Organization_createTime,C_Organization_phone,C_Organization_fax,C_Organization_address,C_Organization_remark,C_Organization_order,C_Organization_level,C_Organization_state,C_Organization_isMarketing ");
            strSql.Append(" FROM C_Organization ");
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
        public int GetRecordCount(Model.SysManager.C_Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Organization ");
            strSql.Append(" where 1=1 and C_Organization_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Organization_creator != null)
                {
                    strSql.Append("and C_Organization_creator=@C_Organization_creator");
                }
                if (model.C_Organization_createTime != null)
                {
                    strSql.Append("and C_Organization_createTime=@C_Organization_createTime");
                }
                if (model.C_Organization_level != null)
                {
                    strSql.Append("and C_Organization_level=@C_Organization_level");
                }
                if (model.C_Organization_name != null)
                {
                    strSql.Append("and C_Organization_name=@C_Organization_name");
                }
                if (model.C_Organization_parent != null)
                {
                    strSql.Append("and C_Organization_parent=@C_Organization_parent");
                }
                if (model.C_Organization_state != null)
                {
                    strSql.Append("and C_Organization_state=@C_Organization_state");
                }
                if (model.C_Organization_isMarketing != null)
                {
                    strSql.Append("and T.C_Organization_isMarketing=@C_Organization_isMarketing");
                }

            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Organization_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_phone", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_fax", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_address", SqlDbType.VarChar,100),
					new SqlParameter("@C_Organization_remark", SqlDbType.VarChar,500),
					new SqlParameter("@C_Organization_order", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_level", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_state", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4),
                                          new SqlParameter("@C_Organization_isMarketing", SqlDbType.Bit,1)};
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Organization_name;
            parameters[2].Value = model.C_Organization_isDelete;
            parameters[3].Value = model.C_Organization_parent;
            parameters[4].Value = model.C_Organization_creator;
            parameters[5].Value = model.C_Organization_createTime;
            parameters[6].Value = model.C_Organization_phone;
            parameters[7].Value = model.C_Organization_fax;
            parameters[8].Value = model.C_Organization_address;
            parameters[9].Value = model.C_Organization_remark;
            parameters[10].Value = model.C_Organization_order;
            parameters[11].Value = model.C_Organization_level;
            parameters[12].Value = model.C_Organization_state;
            parameters[13].Value = model.C_Organization_id;
            parameters[14].Value = model.C_Organization_isMarketing;
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
        public DataSet GetListByPage(Model.SysManager.C_Organization model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Organization_id desc");
            }
            strSql.Append(")AS Row, T.*,P.C_Organization_name AS C_Organization_parent_name from C_Organization T ");
            strSql.Append("left join C_Organization AS P with(nolock) on T.C_Organization_parent = P.C_Organization_code ");
            strSql.Append(" where 1=1 and T.C_Organization_isDelete=0 ");
            if (model != null)
            {
                if (model.C_Organization_creator != null)
                {
                    strSql.Append("and T.C_Organization_creator=@C_Organization_creator");
                }
                if (model.C_Organization_createTime != null)
                {
                    strSql.Append("and T.C_Organization_createTime=@C_Organization_createTime");
                }
                if (model.C_Organization_level != null)
                {
                    strSql.Append("and T.C_Organization_level=@C_Organization_level");
                }
                if (model.C_Organization_name != null)
                {
                    strSql.Append("and T.C_Organization_name=@C_Organization_name");
                }
                if (model.C_Organization_parent != null)
                {
                    strSql.Append("and T.C_Organization_parent=@C_Organization_parent");
                }
                if (model.C_Organization_state != null)
                {
                    strSql.Append("and T.C_Organization_state=@C_Organization_state");
                }


            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Organization_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Organization_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Organization_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Organization_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Organization_phone", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_fax", SqlDbType.VarChar,20),
					new SqlParameter("@C_Organization_address", SqlDbType.VarChar,100),
					new SqlParameter("@C_Organization_remark", SqlDbType.VarChar,500),
					new SqlParameter("@C_Organization_order", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_level", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_state", SqlDbType.Int,4),
					new SqlParameter("@C_Organization_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Organization_isMarketing", SqlDbType.Bit,1)};
            parameters[0].Value = model.C_Organization_code;
            parameters[1].Value = model.C_Organization_name;
            parameters[2].Value = model.C_Organization_isDelete;
            parameters[3].Value = model.C_Organization_parent;
            parameters[4].Value = model.C_Organization_creator;
            parameters[5].Value = model.C_Organization_createTime;
            parameters[6].Value = model.C_Organization_phone;
            parameters[7].Value = model.C_Organization_fax;
            parameters[8].Value = model.C_Organization_address;
            parameters[9].Value = model.C_Organization_remark;
            parameters[10].Value = model.C_Organization_order;
            parameters[11].Value = model.C_Organization_level;
            parameters[12].Value = model.C_Organization_state;
            parameters[13].Value = model.C_Organization_id;
            parameters[14].Value = model.C_Organization_isMarketing;
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
            parameters[0].Value = "C_Organization";
            parameters[1].Value = "C_Organization_id";
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

