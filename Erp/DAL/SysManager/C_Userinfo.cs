using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace CommonService.DAL.SysManager
{
    /// <summary>
    /// 数据访问类:用户表
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary>
    public partial class C_Userinfo
    {
        public C_Userinfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Userinfo_id", "C_Userinfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Userinfo_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Userinfo");
            strSql.Append(" where C_Userinfo_id=@C_Userinfo_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Userinfo_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="C_Userinfo_id">用户登录名</param>
        /// <returns>是否存在</returns>
        public bool ExistsByloginID(string C_Userinfo_loginID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Userinfo");
            strSql.Append(" where C_Userinfo_loginID=@C_Userinfo_loginID ");
            strSql.Append("and C_Userinfo_isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar)
			};
            parameters[0].Value = C_Userinfo_loginID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsRolePowerByUserinfoCode(Guid C_Userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Userinfo as U");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code and U.C_Userinfo_isDelete=0 and U.C_Userinfo_state=1 ");
            strSql.Append("and Exists(select 1 from C_Role_Role_Power As CRRP with(nolock) where CRRP.C_Role_Power_id=2 and CRRP.C_Roles_id=U.C_Userinfo_roleID)");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Userinfo_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.SysManager.C_Userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Userinfo(");
            strSql.Append("C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress)");
            strSql.Append(" values (");
            strSql.Append("@C_Userinfo_code,@C_Userinfo_name,@C_Userinfo_loginID,@C_Userinfo_password,@C_Userinfo_roleID,@C_Userinfo_isDelete,@C_Userinfo_parent,@C_Userinfo_description,@C_Userinfo_state,@C_Userinfo_creator,@C_Userinfo_createTime,@C_Userinfo_Organization,@C_Userinfo_post,@C_Userinfo_isDefault,@C_Userinfo_Integral,@C_Userinfo_cellPhoneNumber,@C_Userinfo_mailbox,@C_Userinfo_pictureAddress)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_isDefault", SqlDbType.Bit,1),
                    new SqlParameter("@C_Userinfo_Integral",SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_cellPhoneNumber",SqlDbType.VarChar,20),
                    new SqlParameter("@C_Userinfo_mailbox",SqlDbType.VarChar),
                    new SqlParameter("@C_Userinfo_pictureAddress",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.C_Userinfo_code;
            parameters[1].Value = model.C_Userinfo_name;
            parameters[2].Value = model.C_Userinfo_loginID;
            parameters[3].Value = model.C_Userinfo_password;
            parameters[4].Value = model.C_Userinfo_roleID;
            parameters[5].Value = model.C_Userinfo_isDelete;
            parameters[6].Value = model.C_Userinfo_parent;
            parameters[7].Value = model.C_Userinfo_description;
            parameters[8].Value = model.C_Userinfo_state;
            parameters[9].Value = model.C_Userinfo_creator;
            parameters[10].Value = model.C_Userinfo_createTime;
            parameters[11].Value = model.C_Userinfo_Organization;
            parameters[12].Value = model.C_Userinfo_post;
            parameters[13].Value = model.C_Userinfo_isDefault;
            parameters[14].Value = model.C_Userinfo_Integral;
            parameters[15].Value = model.C_Userinfo_cellPhoneNumber;
            parameters[16].Value = model.C_Userinfo_mailbox;
            parameters[17].Value = model.C_Userinfo_pictureAddress;
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
        public bool Update(CommonService.Model.SysManager.C_Userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set ");
            strSql.Append("C_Userinfo_name=@C_Userinfo_name,");
            strSql.Append("C_Userinfo_loginID=@C_Userinfo_loginID,");
            strSql.Append("C_Userinfo_password=@C_Userinfo_password,");
            strSql.Append("C_Userinfo_roleID=@C_Userinfo_roleID,");
            strSql.Append("C_Userinfo_isDelete=@C_Userinfo_isDelete,");
            strSql.Append("C_Userinfo_parent=@C_Userinfo_parent,");
            strSql.Append("C_Userinfo_description=@C_Userinfo_description,");
            strSql.Append("C_Userinfo_state=@C_Userinfo_state,");
            strSql.Append("C_Userinfo_creator=@C_Userinfo_creator,");
            strSql.Append("C_Userinfo_createTime=@C_Userinfo_createTime,");
            strSql.Append("C_Userinfo_Organization=@C_Userinfo_Organization,");
            strSql.Append("C_Userinfo_post=@C_Userinfo_post, ");
            strSql.Append("C_Userinfo_isDefault=@C_Userinfo_isDefault,");
            strSql.Append("C_Userinfo_Integral=@C_Userinfo_Integral,");
            strSql.Append("C_Userinfo_cellPhoneNumber=@C_Userinfo_cellPhoneNumber, ");
            strSql.Append("C_Userinfo_mailbox=@C_Userinfo_mailbox,");
            strSql.Append("C_Userinfo_pictureAddress=@C_Userinfo_pictureAddress ");
            strSql.Append("where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_isDefault", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_Integral",SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_cellPhoneNumber",SqlDbType.VarChar,20),
                    new SqlParameter("@C_Userinfo_mailbox",SqlDbType.VarChar),
                    new SqlParameter("@C_Userinfo_pictureAddress",SqlDbType.VarChar)
                                        };
            parameters[0].Value = model.C_Userinfo_name;
            parameters[1].Value = model.C_Userinfo_loginID;
            parameters[2].Value = model.C_Userinfo_password;
            parameters[3].Value = model.C_Userinfo_roleID;
            parameters[4].Value = model.C_Userinfo_isDelete;
            parameters[5].Value = model.C_Userinfo_parent;
            parameters[6].Value = model.C_Userinfo_description;
            parameters[7].Value = model.C_Userinfo_state;
            parameters[8].Value = model.C_Userinfo_creator;
            parameters[9].Value = model.C_Userinfo_createTime;
            parameters[10].Value = model.C_Userinfo_Organization;
            parameters[11].Value = model.C_Userinfo_post;
            parameters[12].Value = model.C_Userinfo_isDefault;
            parameters[13].Value = model.C_Userinfo_code;
            parameters[14].Value = model.C_Userinfo_Integral;
            parameters[15].Value = model.C_Userinfo_cellPhoneNumber;
            parameters[16].Value = model.C_Userinfo_mailbox;
            parameters[17].Value = model.C_Userinfo_pictureAddress;

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
        public bool UpdatePass(Guid parentCode, string pass)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set ");
            strSql.Append("C_Userinfo_password=@C_Userinfo_password ");
            strSql.Append("where C_Userinfo_parent=@C_Userinfo_parent");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
                    new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
            };

            parameters[0].Value = pass;
            parameters[1].Value = parentCode;

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
        /// 改变默认状态
        /// </summary>
        /// <param name="childrenUserCode">子用户Guid</param>
        /// <param name="isDefault">是否默认</param>
        /// <returns></returns>
        public bool UpdateDefault(Guid childrenUserCode, bool isDefault)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set ");
            strSql.Append("C_Userinfo_isDefault=@C_Userinfo_isDefault ");
            strSql.Append("where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_isDefault", SqlDbType.Bit,1),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
            };

            parameters[0].Value = isDefault;
            parameters[1].Value = childrenUserCode;

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
        public bool Delete(Guid userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set C_Userinfo_isDelete=1 ");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = userinfo_code;

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
        public bool DeleteList(string C_Userinfo_codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set C_Userinfo_isDelete=1 ");
            strSql.Append(" where C_Userinfo_code in (" + C_Userinfo_codelist + ")  ");
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
        public CommonService.Model.SysManager.C_Userinfo GetModel(int C_Userinfo_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress from C_Userinfo ");
            strSql.Append(" where C_Userinfo_id=@C_Userinfo_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Userinfo_id;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 通过用户Guid，获取用户对象
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByUserCode(Guid userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,a.C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress,f.C_Region_abbreviation,Org.C_Organization_name as 'C_Userinfo_Organization_name',P.C_Post_name as 'C_Userinfo_post_name' from C_Userinfo as a ");
            strSql.Append(" left join (select C_Region_abbreviation,C_Userinfo_code from C_Userinfo_region as b left join C_Region as c on b.C_Region_code=c.C_Region_code) as f on a.C_Userinfo_code=f.C_Userinfo_code ");
            strSql.Append(" left join C_Organization as Org on a.C_Userinfo_Organization=Org.C_Organization_code ");
            strSql.Append(" left join C_Post as P on a.C_Userinfo_post=P.C_Post_code ");
            strSql.Append(" where a.C_Userinfo_code=@C_Userinfo_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = userCode;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 通过用户登录名，获取用户实体
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByLoginName(string loginID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_isDefault,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo  with(nolock)  ");
            strSql.Append("where C_Userinfo_loginID=@C_Userinfo_loginID ");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = loginID;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 通过用户登录名和密码，获取用户实体
        /// </summary>
        /// <param name="loginID">登录名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByLoginNameAndPassword(string loginID, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_isDefault,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo with(nolock) ");
            strSql.Append("where C_Userinfo_loginID=@C_Userinfo_loginID ");
            strSql.Append("and C_Userinfo_password=@C_Userinfo_password and C_Userinfo_isDelete=0 ");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.NVarChar,100),
                    new SqlParameter("@C_Userinfo_password", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = loginID;
            parameters[1].Value = password;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 通过父亲Guid，获取一默认子用户
        /// </summary>
        /// <param name="parentCode">父亲Guid</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetDefaultChildUserByParentCode(Guid parentCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_isDefault,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo As U  with(nolock)  ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on U.C_Userinfo_Organization=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("where C_Userinfo_parent=@C_Userinfo_parent ");
            strSql.Append("and C_Userinfo_isDelete = 0 ");
            strSql.Append("and C_Userinfo_isDefault = 1 ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 通过父亲Guid，获取子用户列表
        /// </summary>
        /// <param name="parentCode">父亲Guid</param>
        /// <returns></returns>
        public DataSet GetChildUserByParentCode(Guid parentCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from C_Userinfo where C_Userinfo_parent=@parentCode");
            SqlParameter[] parameters = {
					new SqlParameter("@parentCode", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = parentCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo GetModelByCode(Guid C_Userinfo_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress from C_Userinfo ");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Userinfo_code;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 根据区域和角色获得数据
        /// </summary>
        /// <param name="C_Region_code">区域Guid</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public CommonService.Model.SysManager.C_Userinfo GetModelByRegionAndRole(Guid C_Region_code, int? roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 T.C_Userinfo_id,T.C_Userinfo_code,T.C_Userinfo_name,T.C_Userinfo_loginID,T.C_Userinfo_password,T.C_Userinfo_roleID,T.C_Userinfo_isDelete,T.C_Userinfo_parent,T.C_Userinfo_description,T.C_Userinfo_state,T.C_Userinfo_creator,T.C_Userinfo_createTime,T.C_Userinfo_Organization,T.C_Userinfo_post,T.C_Userinfo_isDefault,T.C_Userinfo_Integral,T.C_Userinfo_cellPhoneNumber,T.C_Userinfo_mailbox,T.C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo as T ");
            strSql.Append("where T.C_Userinfo_isDelete=0 and T.C_Userinfo_state=1 ");
            strSql.Append("and exists(and exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and C_region_code=@C_Region_code and OPUR.C_User_code=T.C_Userinfo_code)) ");
            strSql.Append("and exists(select 1 from C_Organization_post_user_role as OPUR where OPUR.C_Organization_post_user_role_isDelete=0 and OPUR.C_Role_id=@C_Userinfo_roleID and OPUR.C_User_code=T.C_Userinfo_code)");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_roleID",SqlDbType.Int,4)
			};
            parameters[0].Value = C_Region_code;
            parameters[1].Value = roleId;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 根据组织机构GUID获取所有的主用户
        /// </summary>
        public DataSet GetModelByOrgCode(Guid orgCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(C_Userinfo_parent) from C_Userinfo as u where u.C_Userinfo_parent is not null  and u.C_Userinfo_Organization=@C_Userinfo_Organization");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据组织机构Guid和岗位Guid，获取所有用户
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public DataSet GetUsersByOrgAndPost(Guid? orgCode, Guid? postCode, string userinfoName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("dbo.getUserOrgPostNamesByUserCode(U.C_Userinfo_code) As C_Userinfo_Organization_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("where U.C_Userinfo_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_state=1 ");
            strSql.Append("and U.C_Userinfo_loginID<>'admin'");

            if (orgCode != null)
            {
                strSql.Append("and U.C_Userinfo_Organization=@C_Userinfo_Organization ");
            }
            if (postCode != null)
            {
                strSql.Append("and U.C_Userinfo_post=@C_Userinfo_post ");
            }
            if (userinfoName != string.Empty)
            {
                strSql.Append("and U.C_Userinfo_name like N'%'+@C_Userinfo_name+'%' ");
            }

            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_name",SqlDbType.VarChar)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = postCode;
            parameters[2].Value = userinfoName;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        ///获取所有用户
        public DataSet GetUsersByOrgAndPostAll(List<Guid> orgCode, Guid? postCode, string userinfoName, string regionCodes)
        {
            string codes = "";
            foreach (Guid item in orgCode)
            {
                if (item.ToString() == Guid.Empty.ToString()) continue;
                codes += item + ",";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("Org.C_Organization_name As C_Userinfo_Organization_name,P.C_Post_name As C_Userinfo_post_name,R.C_Region_name As C_Userinfo_Regioncode_Name,R.C_Region_code As C_Userinfo_Regioncode ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization_post_user_region as OPU WITH(NOLOCK) on OPU.C_User_code=U.C_Userinfo_code ");
            strSql.Append("left join C_Organization AS Org WITH(NOLOCK) on OPU.C_Organization_code=Org.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on OPU.C_Post_code=P.C_Post_code ");
            strSql.Append("left join C_Region as R WITH(NOLOCK) on OPU.C_region_code=R.C_Region_code ");
            strSql.Append("where 1=1 ");
            strSql.Append("and U.C_Userinfo_isDelete=0 ");
            strSql.Append("and OPU.C_Organization_post_user_region_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_parent is null ");
            strSql.Append("and R.C_Region_isDelete=0 and P.C_Post_isDelete=0 ");
            if (codes != "")
            {
                strSql.Append("and '" + codes + "' like '%'+convert(varchar(500),OPU.C_Organization_code)+'%'");
            }
            if (postCode != null)
            {
                strSql.Append("and OPU.C_Post_code=@C_Userinfo_post ");
            }
            if (userinfoName != string.Empty)
            {
                strSql.Append("and U.C_Userinfo_name like N'%'+@C_Userinfo_name+'%' ");
            }
            if (regionCodes != Guid.Empty.ToString())
            {
                strSql.Append("and exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and OPUR.C_User_code=U.C_Userinfo_code and charindex(','+cast(OPUR.C_region_code as nvarchar(2000))+',',','+@C_Region_code+',')>0)");
                //strSql.Append(" and exists(select * from C_Userinfo_region where C_Userinfo_code=U.C_Userinfo_code and charindex(','+cast(C_Region_code as nvarchar(2000))+',',','+@C_Region_code+',')>0)");
            }

            SqlParameter[] parameters = {
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_name",SqlDbType.VarChar),
                    new SqlParameter("@C_Region_code",SqlDbType.VarChar)
			};
            parameters[0].Value = postCode;
            parameters[1].Value = userinfoName;
            parameters[2].Value = regionCodes;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据区域获得数据列表
        /// </summary>
        public DataSet GetListByRegionCode(Guid regionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("O.C_Organization_name As C_Userinfo_Organization_name,P.C_Post_name As C_Userinfo_post_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on U.C_Userinfo_Organization=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("where U.C_Userinfo_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_parent IS NOT NULL ");//只取子用户
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append(" and exists(select * from C_Userinfo_region where C_Userinfo_code=U.C_Userinfo_code and C_Region_code=@C_Region_code) ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Region_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = regionCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据组织机构Guid和岗位Guid和主办律师，获取所有用户
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param> 
        /// <returns></returns>
        public DataSet GetUsersByOrgAndPostAndLycode(Guid? orgCode, Guid? postCode, Guid? lawyerCode, string userinfoName, string regionCodes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("O.C_Organization_name As C_Userinfo_Organization_name,P.C_Post_name As C_Userinfo_post_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization_post_user as OPU WITH(NOLOCK) on OPU.C_User_code=U.C_Userinfo_code ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on OPU.C_Organization_code=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on OPU.C_Post_code=P.C_Post_code ");
            strSql.Append("");

            strSql.Append("where U.C_Userinfo_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_parent IS NULL ");//只取子用户
            strSql.Append("and U.C_Userinfo_state=1 ");
            strSql.Append("and OPU.C_Organization_post_user_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            if (orgCode != null)
            {
                strSql.Append("and OPU.C_Organization_code=@C_Userinfo_Organization ");
            }
            if (postCode != null)
            {
                strSql.Append("and OPU.C_Post_code=@C_Userinfo_post ");
            }
            if (lawyerCode != null)
            {
                strSql.Append(" and U.C_Userinfo_code!=@C_Userinfo_code ");
            }
            if (userinfoName != string.Empty)
            {
                strSql.Append("and U.C_Userinfo_name like N'%'+@C_Userinfo_name+'%' ");
            }
            if (regionCodes != Guid.Empty.ToString())
            {
                strSql.Append(" and exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_User_code=U.C_Userinfo_code and charindex(','+cast(C_Region_code as nvarchar(2000))+',',','+@C_Region_code+',')>0)");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_name",SqlDbType.VarChar),
                        new SqlParameter("@C_Region_code",SqlDbType.VarChar)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = postCode;
            parameters[2].Value = lawyerCode;
            parameters[3].Value = userinfoName;
            parameters[4].Value = regionCodes;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据流程Guid和岗位Guid，获取所有用户
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public DataSet GetUsersByFlowAndPost(Guid flowCode, Guid? postCode, string C_Userinfo_name, string regionCodes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("P.C_Post_name As C_Userinfo_post_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization_post_user as OPU on OPU.C_User_code=U.C_Userinfo_code ");
            strSql.Append("left join C_Post as P on P.C_Post_code=OPU.C_Post_code ");
            strSql.Append("where U.C_Userinfo_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_state=1 ");
            strSql.Append("and OPU.C_Organization_post_user_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_parent IS NULL ");
            strSql.Append("and U.C_Userinfo_name like  N'%'+@C_Userinfo_name+'%' ");

            strSql.Append("and Exists(select 1 from P_Flow_post AS FP WITH(NOLOCK) where OPU.C_Post_code=FP.F_Post_code and FP.P_Flow_code=@P_Flow_code and FP.P_Flow_post_isDelete=0) ");

            if (postCode != null && postCode != Guid.Empty)
            {
                strSql.Append("and OPU.C_Post_code=@C_Userinfo_post ");
            }
            if (regionCodes != Guid.Empty.ToString())
            {
                strSql.Append("and exists(select 1 from C_Organization_post_user_region as OPUR where OPUR.C_Organization_post_user_region_isDelete=0 and OPUR.C_User_code=U.C_Userinfo_code and charindex(','+cast(C_Region_code as nvarchar(2000))+',',','+@C_Region_code+',')>0)");
            }

            SqlParameter[] parameters = {			
	                new SqlParameter("@P_Flow_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_name",SqlDbType.VarChar),
                      new SqlParameter("@C_Region_code",SqlDbType.VarChar)
			};
            parameters[0].Value = flowCode;
            parameters[1].Value = postCode;
            parameters[2].Value = C_Userinfo_name;
            parameters[3].Value = regionCodes;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过案件Guid，获取关联权限用户集合
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public DataSet GetPowerUsersByCase(Guid caseCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from C_Userinfo As C with(nolock) ");
            strSql.Append("where C.C_Userinfo_isDelete=0 and C.C_Userinfo_state=1 and ");
            strSql.Append("exists(");
            strSql.Append("select 1 from(");
            strSql.Append("select O.C_Organization_code,OPU.C_Post_code,OPU.C_User_code ");
            strSql.Append("from C_Organization As O with(nolock),B_Case_link As L with(nolock),C_Organization_post_user As OPU,C_Post As P ");
            strSql.Append("where O.C_Organization_Area=L.C_FK_code and O.C_Organization_code=OPU.C_Organization_code and OPU.C_Post_code=P.C_Post_code and L.B_Case_code=@caseCode and L.B_Case_link_type=6 and L.B_Case_link_isDelete=0 ");
            strSql.Append("and O.C_Organization_isDelete=0 and O.C_Organization_state=1 ");
            strSql.Append("and OPU.C_Organization_post_user_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 and P.C_Post_group='94EDA41E-F330-46F6-AF8C-1A3C93402DEE'");
            strSql.Append(") As T ");
            strSql.Append("where C.C_Userinfo_code=T.C_User_code ");
            strSql.Append(") ");

            SqlParameter[] parameters = {			
	                new SqlParameter("@caseCode", SqlDbType.UniqueIdentifier,16)                     
			};
            parameters[0].Value = caseCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户Guid，获取用户所有岗位集合
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetUserPostsByUser(Guid userCode)
        {
            Guid parentUserCode = Guid.Empty;
            CommonService.Model.SysManager.C_Userinfo UserInfo = this.GetModelByCode(userCode);
            if (UserInfo != null)
            {
                parentUserCode = UserInfo.C_Userinfo_parent.Value;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.*,P.C_Post_name As C_Userinfo_post_name,O.C_Organization_name as C_Userinfo_Organization_name ");
            strSql.Append("from C_Userinfo As U with(nolock) ");
            strSql.Append("left join C_Post As P with(nolock) on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("left join C_Organization As O with(nolock) on U.C_Userinfo_organization=O.C_Organization_code ");
            strSql.Append("where U.C_Userinfo_parent=@C_Userinfo_parent ");
            strSql.Append("and U.C_Userinfo_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_state=1 ");
            strSql.Append(" and P.C_Post_isDelete=0 ");
            strSql.Append(" and O.C_Organization_isDelete=0");

            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16)                  
			};
            parameters[0].Value = parentUserCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo DataRowToModel(DataRow row)
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
                }//,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress
                if (row["C_Userinfo_Integral"] != null && row["C_Userinfo_Integral"].ToString() != "")
                {
                    model.C_Userinfo_Integral = Convert.ToInt32(row["C_Userinfo_Integral"].ToString());
                }
                if (row["C_Userinfo_cellPhoneNumber"] != null && row["C_Userinfo_cellPhoneNumber"].ToString() != "")
                {
                    model.C_Userinfo_cellPhoneNumber = row["C_Userinfo_cellPhoneNumber"].ToString();
                }
                if (row["C_Userinfo_mailbox"] != null && row["C_Userinfo_mailbox"].ToString() != "")
                {
                    model.C_Userinfo_mailbox = row["C_Userinfo_mailbox"].ToString();
                }
                if (row["C_Userinfo_pictureAddress"] != null && row["C_Userinfo_pictureAddress"].ToString() != "")
                {
                    model.C_Userinfo_pictureAddress = row["C_Userinfo_pictureAddress"].ToString();
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
                //检查组织机机构岗位名称列，是否存在于table中
                if (row.Table.Columns.Contains("C_Userinfo_Organization_Post_name"))
                {
                    if (row["C_Userinfo_Organization_Post_name"] != null)
                    {
                        model.C_Userinfo_Organization_Post_name = row["C_Userinfo_Organization_Post_name"].ToString();
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

                //检查部门名称列，是否存在于table中，所有子用户的部门名称（专供手机App使用）
                if (row.Table.Columns.Contains("dept"))
                {
                    if (row["dept"] != null)
                    {
                        model.Dept_name = row["dept"].ToString();
                    }
                }

                //检查岗位名称列，是否存在于table中，所有子用户的岗位名称（专供手机App使用）
                if (row.Table.Columns.Contains("post"))
                {
                    if (row["post"] != null)
                    {
                        model.Post_name = row["post"].ToString();
                    }
                }
                //查看用户所在区域是否存在于table中
                if (row.Table.Columns.Contains("C_Userinfo_Regioncode_Name"))
                {
                    if (row["C_Userinfo_Regioncode_Name"] != null && row["C_Userinfo_Regioncode_Name"].ToString() != "")
                    {
                        model.C_Userinfo_Regioncode_Name = row["C_Userinfo_Regioncode_Name"].ToString();
                    }
                }

                //查看用户所在区域是否存在于table中
                if (row.Table.Columns.Contains("C_Userinfo_Regioncode"))
                {
                    if (row["C_Userinfo_Regioncode"] != null && row["C_Userinfo_Regioncode"].ToString() != "")
                    {
                        model.C_Userinfo_Regioncode = new Guid(row["C_Userinfo_Regioncode"].ToString());
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
            strSql.Append("select C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append(" FROM C_Userinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得所有父级用户列表
        /// </summary>
        public DataSet GetParentList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress, ");
            strSql.Append("STUFF((SELECT '/' + C_Organization_name");
            strSql.Append(" FROM C_Organization AS t2");
            strSql.Append(" WHERE t2.C_Organization_code in( select C_Userinfo_organization from C_Userinfo a where a.C_Userinfo_parent=muser.C_Userinfo_code and a.C_Userinfo_isDelete=0)");
            strSql.Append(" ORDER BY C_Organization_name");
            strSql.Append(" FOR XML PATH('')), 1, 1, '') AS dept,");
            strSql.Append(" STUFF((SELECT '/' + C_Post_name");
            strSql.Append(" FROM C_Post AS t2");
            strSql.Append(" WHERE t2.C_Post_code in( select C_Userinfo_post from C_Userinfo b where b.C_Userinfo_parent=muser.C_Userinfo_code and b.C_Userinfo_isDelete=0)");
            strSql.Append(" ORDER BY C_Post_name");
            strSql.Append(" FOR XML PATH('')), 1, 1, '') AS post");
            strSql.Append(" FROM C_Userinfo muser ");
            strSql.Append(" where muser.C_Userinfo_isDelete=0 and muser.C_Userinfo_state=1 and muser.C_Userinfo_parent is null");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得所有子级用户数据列表
        /// </summary>
        /// <param name="type">
        /// 1、查看指挥中心案件
        /// 2、首席专家
        /// </param>
        /// <returns></returns>
        public DataSet GetAllChildList(int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.*,");
            strSql.Append("dbo.getUserOrgNamesByUserCode(U.C_Userinfo_code) As C_Userinfo_Organization_name ");
            //strSql.Append(",Org.C_Organization_name as 'C_Userinfo_Organization_name',P.C_Post_name as 'C_Userinfo_post_name',UR.C_Region_code as C_Userinfo_Regioncode");
            strSql.Append("FROM C_Userinfo as U with(nolock) ");
            //strSql.Append("left join C_Organization as Org on U.C_Userinfo_Organization=Org.C_Organization_code ");
            //strSql.Append("left join C_Post as P on U.C_Userinfo_post=P.C_Post_code ");
            //strSql.Append("left join C_Userinfo_region  as UR on UR.C_Userinfo_code=U.C_Userinfo_code ");
            strSql.Append("where ");
            strSql.Append("U.C_Userinfo_isDelete=0 and U.C_Userinfo_state=1 ");
            if (type == 1)
            {//(专家部长)
                strSql.Append("and Exists(select 1 from C_Organization_post_user As OPU,C_Post As P where OPU.C_Post_code=P.C_Post_code and OPU.C_Organization_post_user_isDelete=0 and P.C_Post_isDelete=0 ");
                strSql.Append("and U.C_Userinfo_code=OPU.C_User_code and P.C_Post_group='A33B44C7-93A0-4520-94D5-C50C8C7AC99F') ");
            }
            else if (type == 2)
            {//(首席)
                strSql.Append("and Exists(select 1 from C_Organization_post_user As OPU,C_Post As P where OPU.C_Post_code=P.C_Post_code and OPU.C_Organization_post_user_isDelete=0 and P.C_Post_isDelete=0 ");
                strSql.Append("and U.C_Userinfo_code=OPU.C_User_code and P.C_Post_group='DA275F5A-4809-4F9D-832E-B213A65A78F5') ");
            }
            else if (type == 3)
            {//首席(不知道这个是做什么的),hety,2016-02-15
                strSql.Append("and Exists(select * from C_Group as R where r.C_Roles_id=9 and r.C_Group_code='DA275F5A-4809-4F9D-832E-B213A65A78F5' and r.C_Roles_id=U.C_Userinfo_roleID and r.C_Group_isDelete=0 and r.C_Roles_id!=1) ");
            }
            else if (type == 4)
            {//部长(不知道这个是做什么的),hety,2016-02-15
                strSql.Append("and exists(select * from C_Group as R where r.C_Roles_id=10 and r.C_Group_code='A33B44C7-93A0-4520-94D5-C50C8C7AC99F' and r.C_Roles_id=U.C_Userinfo_roleID and r.C_Group_isDelete=0)");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得拥有部长权限的用户列表
        /// </summary>
        public DataSet GetMinisterList(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress ");
            strSql.Append("FROM C_Userinfo as U where 1=1 ");
            if (userCode == Guid.Empty)
            {
                strSql.Append("and exists(select * from C_Group as R where r.C_Roles_id=10 and r.C_Group_code='A33B44C7-93A0-4520-94D5-C50C8C7AC99F' and r.C_Roles_id=U.C_Userinfo_roleID and r.C_Group_isDelete=0) ");
            }
            else
            {
                strSql.Append("and exists(select * from C_ChiefExpert_Minister as CM where CM.C_Minister_Code=U.C_Userinfo_code and CM.C_ChiefExpert_Code=@C_ChiefExpert_Code and U.C_Userinfo_isDelete=0) ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_ChiefExpert_Code", SqlDbType.UniqueIdentifier,16)};
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
            strSql.Append(" C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append(" FROM C_Userinfo ");
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
        public int GetRecordCount(Model.SysManager.C_Userinfo user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Userinfo as T ");
            if (user.C_Userinfo_relationType == 2)
            {//法院关联律师页面调用
                strSql.Append("left join C_Court_Lawyer CL on T.C_Userinfo_code=CL.C_Lawyer ");
                strSql.Append("where 1=1 and T.C_Userinfo_isDelete=0 and CL.C_Court_Lawyer_isDelete=0 ");
            }
            else if (user.C_Userinfo_relationType == 3)
            {//首席专家列表
                strSql.Append(" WHERE 1=1 and T.C_Userinfo_state = 1 and exists(select * from C_Group as R where r.C_Roles_id=9 and r.C_Group_code='DA275F5A-4809-4F9D-832E-B213A65A78F5' and r.C_Roles_id=t.C_Userinfo_roleID and r.C_Group_isDelete=0) ");
            }
            else
            {
                strSql.Append("where 1=1 and T.C_Userinfo_isDelete=0 and T.C_Userinfo_parent is null");
            }

            if (user != null)
            {
                if (user.C_Userinfo_code != null)
                {
                    strSql.Append(" and C_Userinfo_code=@C_Userinfo_code");
                }
                if (user.C_Userinfo_createTime != null)
                {
                    strSql.Append(" and C_Userinfo_createTime=@C_Userinfo_createTime");
                }
                if (user.C_Userinfo_creator != null)
                {
                    strSql.Append(" and C_Userinfo_creator=@C_Userinfo_creator");
                }
                if (user.C_Userinfo_name != null && user.C_Userinfo_name != "")
                {
                    strSql.Append(" and C_Userinfo_name like N'%'+@C_Userinfo_name+'%'");
                }
                if (user.C_Userinfo_Organization != null)
                {
                    strSql.Append(" and C_Userinfo_Organization=@C_Userinfo_Organization");
                }
                if (user.C_Userinfo_parent != null)
                {
                    strSql.Append(" and C_Userinfo_parent=@C_Userinfo_parent");
                }
                if (user.C_Userinfo_state != null)
                {
                    strSql.Append(" and C_Userinfo_state=@C_Userinfo_state");
                }
                if (user.C_Userinfo_relationCode != null)
                {
                    strSql.Append(" and CL.C_Court=@C_Court");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = user.C_Userinfo_code;
            parameters[1].Value = user.C_Userinfo_name;
            parameters[2].Value = user.C_Userinfo_loginID;
            parameters[3].Value = user.C_Userinfo_password;
            parameters[4].Value = user.C_Userinfo_roleID;
            parameters[5].Value = user.C_Userinfo_isDelete;
            parameters[6].Value = user.C_Userinfo_parent;
            parameters[7].Value = user.C_Userinfo_description;
            parameters[8].Value = user.C_Userinfo_state;
            parameters[9].Value = user.C_Userinfo_creator;
            parameters[10].Value = user.C_Userinfo_createTime;
            parameters[11].Value = user.C_Userinfo_Organization;
            parameters[12].Value = user.C_Userinfo_id;
            parameters[13].Value = user.C_Userinfo_relationCode;
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
        public DataSet GetListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Userinfo_id desc");
            }
            strSql.Append(")AS Row, T.*,Org.C_Organization_name as 'C_Userinfo_Organization_name',P.C_Post_name as 'C_Userinfo_post_name'  from C_Userinfo T ");
            strSql.Append("left join C_Organization_post_user as OPU on T.C_Userinfo_code=OPU.C_User_code ");
            strSql.Append("left join C_Organization as Org on OPU.C_Organization_code=Org.C_Organization_code ");
            strSql.Append("left join C_Post as P on OPU.C_Post_code=P.C_Post_code ");
            if (user.C_Userinfo_relationType == 2)
            {//法院关联律师页面调用
                strSql.Append("left join C_Court_Lawyer CL on T.C_Userinfo_code=CL.C_Lawyer ");
                strSql.Append(" WHERE 1=1 and T.C_Userinfo_isDelete=0 and CL.C_Court_Lawyer_isDelete=0 ");
            }
            else if (user.C_Userinfo_relationType == 3)
            {//首席专家列表
                strSql.Append(" WHERE 1=1 and C_Userinfo_state = 1 and exists(select * from C_Group as R where r.C_Roles_id=9 and r.C_Group_code='DA275F5A-4809-4F9D-832E-B213A65A78F5' and r.C_Roles_id=t.C_Userinfo_roleID and r.C_Group_isDelete=0) ");
            }
            else
            {
                strSql.Append(" WHERE 1=1 and T.C_Userinfo_isDelete=0 and C_Userinfo_parent is null ");
            }
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append("and Org.C_Organization_isDelete=0 ");
            strSql.Append("and T.C_Userinfo_state=1 ");
            if (user != null)
            {
                if (user.C_Userinfo_code != null)
                {
                    strSql.Append(" and T.C_Userinfo_code=@C_Userinfo_code");
                }
                if (user.C_Userinfo_createTime != null)
                {
                    strSql.Append(" and T.C_Userinfo_createTime=@C_Userinfo_createTime");
                }
                if (user.C_Userinfo_creator != null)
                {
                    strSql.Append(" and T.C_Userinfo_creator=@C_Userinfo_creator");
                }
                if (user.C_Userinfo_name != null && user.C_Userinfo_name != "")
                {
                    strSql.Append(" and T.C_Userinfo_name like N'%'+@C_Userinfo_name+'%'");
                }
                if (user.C_Userinfo_Organization != null)
                {
                    strSql.Append(" and T.C_Userinfo_Organization=@C_Userinfo_Organization");
                }
                if (user.C_Userinfo_parent != null)
                {
                    strSql.Append(" and T.C_Userinfo_parent=@C_Userinfo_parent");
                }
                if (user.C_Userinfo_state != null)
                {
                    strSql.Append(" and T.C_Userinfo_state=@C_Userinfo_state");
                }
                if (user.C_Userinfo_relationCode != null)
                {
                    strSql.Append(" and CL.C_Court=@C_Court");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = user.C_Userinfo_code;
            parameters[1].Value = user.C_Userinfo_name;
            parameters[2].Value = user.C_Userinfo_loginID;
            parameters[3].Value = user.C_Userinfo_password;
            parameters[4].Value = user.C_Userinfo_roleID;
            parameters[5].Value = user.C_Userinfo_isDelete;
            parameters[6].Value = user.C_Userinfo_parent;
            parameters[7].Value = user.C_Userinfo_description;
            parameters[8].Value = user.C_Userinfo_state;
            parameters[9].Value = user.C_Userinfo_creator;
            parameters[10].Value = user.C_Userinfo_createTime;
            parameters[11].Value = user.C_Userinfo_Organization;
            parameters[12].Value = user.C_Userinfo_id;
            parameters[13].Value = user.C_Userinfo_relationCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取用户列表记录总数
        /// </summary>
        public int GetUserListRecordCount(Model.SysManager.C_Userinfo user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Userinfo as T ");
            strSql.Append(" where 1=1 and T.C_Userinfo_isDelete=0 and T.C_Userinfo_parent is null");

            if (user != null)
            {
                if (user.C_Userinfo_name != null && user.C_Userinfo_name != "")
                {
                    strSql.Append(" and T.C_Userinfo_name like N'%'+@C_Userinfo_name+'%' ");
                }
                if (user.C_Userinfo_Organization != null || user.C_Userinfo_post != null)
                {
                    strSql.Append(" and exists(select 1 from C_Organization_post_user as OPU where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=T.C_Userinfo_code");
                    if (user.C_Userinfo_Organization != null)
                    {
                        strSql.Append(" and OPU.C_Organization_code=@C_Userinfo_Organization");
                    }
                    if (user.C_Userinfo_post != null)
                    {
                        strSql.Append(" and C_Post_code=@C_Userinfo_post");
                    }
                    strSql.Append(" )");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = user.C_Userinfo_code;
            parameters[1].Value = user.C_Userinfo_name;
            parameters[2].Value = user.C_Userinfo_loginID;
            parameters[3].Value = user.C_Userinfo_password;
            parameters[4].Value = user.C_Userinfo_roleID;
            parameters[5].Value = user.C_Userinfo_isDelete;
            parameters[6].Value = user.C_Userinfo_parent;
            parameters[7].Value = user.C_Userinfo_description;
            parameters[8].Value = user.C_Userinfo_state;
            parameters[9].Value = user.C_Userinfo_creator;
            parameters[10].Value = user.C_Userinfo_createTime;
            parameters[11].Value = user.C_Userinfo_Organization;
            parameters[12].Value = user.C_Userinfo_id;
            parameters[13].Value = user.C_Userinfo_relationCode;
            parameters[14].Value = user.C_Userinfo_post;
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
        /// 分页获取用户数据列表
        /// </summary>
        public DataSet GetUserListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Userinfo_id desc");
            }
            strSql.Append(")AS Row, T.*,dbo.getOrgPostNameByRootUser(T.C_Userinfo_code) As C_Userinfo_Organization_Post_name from C_Userinfo T ");
            strSql.Append(" WHERE 1=1 and T.C_Userinfo_isDelete=0 and C_Userinfo_parent is null ");

            if (user != null)
            {
                if (user.C_Userinfo_name != null && user.C_Userinfo_name != "")
                {
                    strSql.Append(" and T.C_Userinfo_name like N'%'+@C_Userinfo_name+'%' ");
                }
                if (user.C_Userinfo_Organization != null || user.C_Userinfo_post != null)
                {
                    strSql.Append(" and exists(select 1 from C_Organization_post_user as OPU where OPU.C_Organization_post_user_isDelete=0 and OPU.C_User_code=T.C_Userinfo_code");
                    if (user.C_Userinfo_Organization != null)
                    {
                        strSql.Append(" and OPU.C_Organization_code=@C_Userinfo_Organization");
                    }
                    if (user.C_Userinfo_post != null)
                    {
                        strSql.Append(" and C_Post_code=@C_Userinfo_post");
                    }
                    strSql.Append(" )");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post",SqlDbType.UniqueIdentifier,16)
                                        };
            parameters[0].Value = user.C_Userinfo_code;
            parameters[1].Value = user.C_Userinfo_name;
            parameters[2].Value = user.C_Userinfo_loginID;
            parameters[3].Value = user.C_Userinfo_password;
            parameters[4].Value = user.C_Userinfo_roleID;
            parameters[5].Value = user.C_Userinfo_isDelete;
            parameters[6].Value = user.C_Userinfo_parent;
            parameters[7].Value = user.C_Userinfo_description;
            parameters[8].Value = user.C_Userinfo_state;
            parameters[9].Value = user.C_Userinfo_creator;
            parameters[10].Value = user.C_Userinfo_createTime;
            parameters[11].Value = user.C_Userinfo_Organization;
            parameters[12].Value = user.C_Userinfo_id;
            parameters[13].Value = user.C_Userinfo_relationCode;
            parameters[14].Value = user.C_Userinfo_post;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 根据法院Guid获取关联律师信息
        /// </summary>
        /// <param name="courtCode"></param>
        /// <returns></returns>
        public DataSet GetListByCourtLawyerCourtCode(Guid courtCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault,U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,Org.C_Organization_name as 'C_Userinfo_Organization_name',P.C_Post_name as 'C_Userinfo_post_name' ");
            strSql.Append("FROM C_Userinfo as U ");
            strSql.Append("left join C_Organization as Org on U.C_Userinfo_Organization=Org.C_Organization_code ");
            strSql.Append("left join C_Post as P on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("left join C_Court_Lawyer CL on U.C_Userinfo_code=CL.C_Lawyer ");
            strSql.Append("where CL.C_Court=@C_Court ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Court", SqlDbType.UniqueIdentifier,16)                  
			};
            parameters[0].Value = courtCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取首席数据列表
        /// </summary>
        public DataSet GetFirstUsersList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * from C_Userinfo T ");
            strSql.Append(" WHERE 1=1 and C_Userinfo_state = 1 and exists(select * from C_Group as R where r.C_Roles_id=9 and r.C_Group_code='DA275F5A-4809-4F9D-832E-B213A65A78F5' and r.C_Roles_id=t.C_Userinfo_roleID and r.C_Group_isDelete=0) ");
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
            parameters[0].Value = "C_Userinfo";
            parameters[1].Value = "C_Userinfo_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 根据用户登录名获取用户
        /// </summary>
        public CommonService.Model.SysManager.C_Userinfo GetUserinfoByLoginID(string loginID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post from C_Userinfo,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append(" where C_Userinfo_loginID=@C_Userinfo_loginID and C_Userinfo_parent=0"); //查询的账户只可为主账户即C_Userinfo_parent=0
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar)
			};
            parameters[0].Value = loginID;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 根据用户编码获取用户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <returns>用户实体</returns>
        public Model.SysManager.C_Userinfo GetUserinfoByCode(Guid userinfo_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress from C_Userinfo ");
            strSql.Append(" where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = userinfo_code;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 根据父亲用户，组织机构，岗位获取一个子用户(这种情况下获取的子用户唯一)
        /// </summary>
        /// <param name="parentUserCode">父亲用户Guid</param>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        public Model.SysManager.C_Userinfo GetChildrenUser(Guid parentUserCode, Guid orgCode, Guid postCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo with(nolock) ");
            strSql.Append("where C_Userinfo_parent=@C_Userinfo_parent ");
            strSql.Append("and C_Userinfo_Organization=@C_Userinfo_Organization ");
            strSql.Append("and C_Userinfo_post=@C_Userinfo_post ");
            strSql.Append("and C_Userinfo_isDelete=0 ");
            strSql.Append("and C_Userinfo_state=1");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = parentUserCode;
            parameters[1].Value = orgCode;
            parameters[2].Value = postCode;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 根据父级用户编码和角色ID获取用户
        /// </summary>
        /// <param name="parent_code">用户编码</param>
        /// <param name="roleID">角色ID</param>
        /// <returns>用户实体</returns>
        public Model.SysManager.C_Userinfo GetUserinfoByCodeAndRole(Guid parent_code, int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress from C_Userinfo ");
            strSql.Append(" where C_Userinfo_parent=@C_Userinfo_parent and C_Userinfo_roleID=@C_Userinfo_roleID");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@C_Userinfo_roleID",SqlDbType.Int,4)
			};
            parameters[0].Value = parent_code;
            parameters[1].Value = roleID;

            CommonService.Model.SysManager.C_Userinfo model = new CommonService.Model.SysManager.C_Userinfo();
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
        /// 根据组织架构编码获取用户列表
        /// </summary>
        /// <param name="organizationID">组织架构编码</param>
        /// <returns>用户列表</returns>
        public DataSet GetUserinfosByOrganizationID(Guid organizationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("FROM C_Userinfo CU left join C_Organization_post_user as copu on CU.C_Userinfo_code=copu.C_User_code ");
            strSql.Append("where copu.C_Organization_code=@C_Userinfo_Organization and C_Userinfo_isDelete=0 and C_Userinfo_state=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = organizationID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 启用/禁用账户
        /// </summary>
        /// <param name="userinfo_code">用户编码</param>
        /// <param name="state">状态：1启用0禁用</param>
        /// <returns>是否成功</returns>
        public bool ChangeUserinfoState(Guid userinfo_code, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set C_Userinfo_state=@C_Userinfo_state where C_Userinfo_code=@C_Userinfo_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
                    new SqlParameter("@C_Userinfo_code",SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = state;
            parameters[1].Value = userinfo_code;
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
        /// 根据组织机构Guid和岗位Guid和用户Guid，获取父级用户实体
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetUsersByOrgAndPost(Guid? orgCode, Guid? postCode, Guid? userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault, ");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("O.C_Organization_name As C_Userinfo_Organization_name,P.C_Post_name As C_Userinfo_post_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on U.C_Userinfo_Organization=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("where U.C_Userinfo_parent IS NULL ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_isDelete=0 ");
            if (orgCode != null)
            {
                strSql.Append("and U.C_Userinfo_Organization=@C_Userinfo_Organization ");
            }
            if (postCode != null)
            {
                strSql.Append("and U.C_Userinfo_post=@C_Userinfo_post ");
            }
            if (userCode != null)
            {
                strSql.Append("and U.C_Userinfo_code=@C_Userinfo_code ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = postCode;
            parameters[2].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据用户Guid，获取子级用户实体列表
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetUsersInfoAndOrgAndRoleByUsercode(Guid? userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault, ");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("O.C_Organization_name As C_Userinfo_Organization_name,P.C_Post_name As C_Userinfo_post_name,R.C_Roles_name As C_Userinfo_Roles_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on U.C_Userinfo_Organization=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("left join C_Roles AS R WITH(NOLOCK) on U.C_Userinfo_roleID=R.C_Roles_id ");
            strSql.Append("where U.C_Userinfo_parent IS NOT NULL ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_isDelete=0 ");
            if (userCode != null)
            {
                strSql.Append("and U.C_Userinfo_code=@C_Userinfo_code ");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户Guid，获取子级用户实体列表
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetChildUsersInfoByUsercode(Guid userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo WITH(NOLOCK) ");
            strSql.Append("where C_Userinfo_parent=@C_Userinfo_code and C_Userinfo_isDelete=0 and C_Userinfo_state=1 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取所有子用户
        /// </summary>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public DataSet GetAllChildList(Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Userinfo_id,C_Userinfo_code,C_Userinfo_name,C_Userinfo_loginID,C_Userinfo_password,C_Userinfo_roleID,C_Userinfo_isDelete,C_Userinfo_parent,C_Userinfo_description,C_Userinfo_state,C_Userinfo_creator,C_Userinfo_createTime,C_Userinfo_Organization,C_Userinfo_post,C_Userinfo_isDefault,C_Userinfo_Integral,C_Userinfo_cellPhoneNumber,C_Userinfo_mailbox,C_Userinfo_pictureAddress ");
            strSql.Append("from C_Userinfo WITH(NOLOCK) ");
            strSql.Append("where C_Userinfo_parent=@C_Userinfo_code and C_Userinfo_isDelete=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据组织机构Guid和岗位Guid和用户Guid，获取子级用户实体
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">父级用户Guid</param>
        /// <returns></returns>
        public DataSet GetUsersByOrgAndPostChirld(Guid? orgCode, Guid? postCode, Guid? userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select U.C_Userinfo_id,U.C_Userinfo_code,U.C_Userinfo_name,U.C_Userinfo_loginID,U.C_Userinfo_password,U.C_Userinfo_roleID,U.C_Userinfo_isDelete,U.C_Userinfo_parent,");
            strSql.Append("U.C_Userinfo_description,U.C_Userinfo_state,U.C_Userinfo_creator,U.C_Userinfo_createTime,U.C_Userinfo_Organization,U.C_Userinfo_post,U.C_Userinfo_isDefault, ");
            strSql.Append("U.C_Userinfo_Integral,U.C_Userinfo_cellPhoneNumber,U.C_Userinfo_mailbox,U.C_Userinfo_pictureAddress,");
            strSql.Append("O.C_Organization_name As C_Userinfo_Organization_name,P.C_Post_name As C_Userinfo_post_name,R.C_Roles_name As C_Userinfo_Roles_name ");
            strSql.Append("from C_Userinfo AS U WITH(NOLOCK) ");
            strSql.Append("left join C_Organization AS O WITH(NOLOCK) on U.C_Userinfo_Organization=O.C_Organization_code ");
            strSql.Append("left join C_Post AS P WITH(NOLOCK) on U.C_Userinfo_post=P.C_Post_code ");
            strSql.Append("left join C_Roles AS R WITH(NOLOCK) on U.C_Userinfo_roleID=R.C_Roles_id ");
            strSql.Append("where U.C_Userinfo_parent IS NOT NULL ");
            strSql.Append("and O.C_Organization_isDelete=0 ");
            strSql.Append("and P.C_Post_isDelete=0 ");
            strSql.Append("and U.C_Userinfo_isDelete=0 ");

            if (orgCode != null)
            {
                strSql.Append("and U.C_Userinfo_Organization=@C_Userinfo_Organization ");
            }
            if (postCode != null)
            {
                strSql.Append("and U.C_Userinfo_post=@C_Userinfo_post ");
            }
            if (userCode != null)
            {
                strSql.Append("and U.C_Userinfo_parent=@C_Userinfo_parent ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = orgCode;
            parameters[1].Value = postCode;
            parameters[2].Value = userCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户组织架构岗位删除关联岗位信息
        /// </summary>
        /// <param name="orgCode">组织架构Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public bool DeletePostByUserCodeAndOrgCode(Guid? orgCode, Guid? postCode, Guid? userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Userinfo set ");
            strSql.Append("C_Userinfo_isDelete=1 ");
            strSql.Append("where C_Userinfo_parent=@C_Userinfo_parent ");
            strSql.Append("and C_Userinfo_Organization=@C_Userinfo_Organization ");
            strSql.Append("and C_Userinfo_post=@C_Userinfo_post ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Userinfo_post", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = userCode;
            parameters[1].Value = orgCode;
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
        /// 根据部门GUID获取主用户
        /// </summary>
        /// <param name="guid">部门GUID</param>
        /// <returns>用户列表</returns>
        public DataSet ContactByDept(Guid? guid)
        {
            string sql = "select *,STUFF((SELECT '/' + C_Organization_name";
            sql += " FROM C_Organization AS t2";
            sql += " WHERE t2.C_Organization_code in( select C_Userinfo_organization from C_Userinfo a where a.C_Userinfo_parent=muser.C_Userinfo_code and a.C_Userinfo_isDelete=0 and a.C_Userinfo_state=1)";
            sql += " ORDER BY C_Organization_name";
            sql += " FOR XML PATH('')), 1, 1, '') AS dept,";
            sql += " STUFF((SELECT '/' + C_Post_name";
            sql += " FROM C_Post AS t2";
            sql += " WHERE t2.C_Post_code in( select C_Userinfo_post from C_Userinfo b where b.C_Userinfo_parent=muser.C_Userinfo_code and b.C_Userinfo_isDelete=0 and b.C_Userinfo_state=1)";
            sql += " ORDER BY C_Post_name";
            sql += " FOR XML PATH('')), 1, 1, '') AS post";
            sql += " from C_Userinfo muser where muser.C_Userinfo_isdelete=0 and muser.C_Userinfo_state=1 and muser.C_Userinfo_parent is null and exists(select 1 from C_Userinfo cuser where cuser.C_Userinfo_organization in(select C_Organization_code from DeptTree(@dept)) and cuser.C_Userinfo_parent=muser.C_Userinfo_code)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@dept",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;
            return DbHelperSQL.Query(sql, para);
        }

        /// <summary>
        /// 根据岗位GUID获取主用户
        /// </summary>
        /// <param name="guid">岗位GUID</param>
        /// <returns>用户列表</returns>
        public DataSet ContactByPost(Guid? guid)
        {
            string sql = "select *,STUFF((SELECT '/' + C_Organization_name";
            sql += " FROM C_Organization AS t2";
            sql += " WHERE t2.C_Organization_code in( select C_Userinfo_organization from C_Userinfo a where a.C_Userinfo_parent=muser.C_Userinfo_code and a.C_Userinfo_isDelete=0 and a.C_Userinfo_state=1)";
            sql += " ORDER BY C_Organization_name";
            sql += " FOR XML PATH('')), 1, 1, '') AS dept,";
            sql += " STUFF((SELECT '/' + C_Post_name";
            sql += " FROM C_Post AS t2";
            sql += " WHERE t2.C_Post_code in( select C_Userinfo_post from C_Userinfo b where b.C_Userinfo_parent=muser.C_Userinfo_code and b.C_Userinfo_isDelete=0 and b.C_Userinfo_state=1)";
            sql += " ORDER BY C_Post_name";
            sql += " FOR XML PATH('')), 1, 1, '') AS post";
            sql += " from C_Userinfo muser where muser.C_Userinfo_isdelete=0 and muser.C_Userinfo_state=1 and muser.C_Userinfo_parent is null and exists(select 1 from C_Userinfo cuser where cuser.C_Userinfo_post=@post and cuser.C_Userinfo_parent=muser.C_Userinfo_code)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@post",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;
            return DbHelperSQL.Query(sql, para);
        }

        /// <summary>
        /// 根据主用户GUID获取主用户及子用户列表
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataSet GetParentAndChildren(Guid? guid)
        {
            string sql = "select RU.C_Post_code as C_Userinfo_post,O.C_Organization_code as C_Userinfo_Organization,R.C_Roles_name as C_Userinfo_Roles_name,PO.C_Post_name as C_Userinfo_post_name,O.C_Organization_name as C_Userinfo_Organization_name,R.C_Roles_id as C_Userinfo_roleID,U.*,R.C_Roles_id as C_Userinfo_roleID from C_Userinfo U,C_Organization_post_user_role RU,C_Roles R ,C_Post PO,C_Organization O  where U.C_Userinfo_code=RU.C_User_code and RU.C_Role_id=R.C_Roles_id and PO.C_Post_code=RU.C_Post_code and RU.C_Organization_code=O.C_Organization_code and U.C_Userinfo_code=@guid and C_Userinfo_isDelete=0 and C_Organization_post_user_role_isDelete=0 and C_Post_isDelete=0 and C_Roles_isDelete=0 and C_Organization_isDelete=0 and C_Userinfo_state=1";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = guid;
            return DbHelperSQL.Query(sql, para);
        }


        /// <summary>
        /// 根据一个用户获取他所在部门的部长助理
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public Model.SysManager.C_Userinfo GetZhuLiByUserCode(Guid userCode)
        {
            string sql = "select top 1 * from C_Userinfo u where u.C_Userinfo_organization=(select cu.C_Userinfo_organization from C_Userinfo cu where cu.C_Userinfo_code=@userCode)";
            sql += " and exists(select 1 from C_Role_Role_Power As CRRP with(nolock) where CRRP.C_Role_Power_id=2 and CRRP.C_Roles_id=u.C_Userinfo_roleID) and u.C_Userinfo_isDelete=0 and C_Userinfo_state=1 and C_Userinfo_post='F30D2E30-0238-4294-92D1-CE96C722F380'";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@userCode",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = userCode;
            DataSet ds = DbHelperSQL.Query(sql.ToString(), para);
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
        /// 根据一个用户获取他所在部门的部长
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public Model.SysManager.C_Userinfo GetBuZhangByUserCode(Guid userCode)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select top 1 * from C_Organization_post_user a ");
            sqlStr.Append("left join C_Userinfo u on u.C_Userinfo_code=a.C_User_code and u.C_Userinfo_isDelete=0 and u.C_Userinfo_state=1 ");
            sqlStr.Append("left join C_Post p on p.C_Post_code=a.C_Post_code and p.C_Post_isDelete=0 ");
            sqlStr.Append("where exists(select 1 from C_Organization_post_user b where a.C_Organization_code=b.C_Organization_code and b.C_User_code=@userCode and b.C_Organization_post_user_isDelete=0) ");
            sqlStr.Append("and p.C_Post_group='A33B44C7-93A0-4520-94D5-C50C8C7AC99F' and a.C_Organization_post_user_isDelete=0 ");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@userCode",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = userCode;
            DataSet ds = DbHelperSQL.Query(sqlStr.ToString(), para);
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
        /// 获得首席或者部长列表
        /// </summary>
        /// <param name="type">1.首席，2.部长</param>
        /// <returns></returns>
        //public DataSet GetFirstOrMiniterList(int type)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select u.C_Userinfo_name,o.C_Organization_name as C_Userinfo_Organization_name,po.C_Post_name,* from C_Organization_post_user a  ");
        //    strSql.Append("left join C_Userinfo u on C_userinfo_code=a.C_User_code ");
        //    strSql.Append("left join C_Organization o on o.C_Organization_code=a.C_Organization_code ");
        //    strSql.Append("left join C_Post po on po.C_Post_code=a.C_Post_code ");
        //    strSql.Append("where 1=1 and u.C_Userinfo_isDelete=0 and u.C_Userinfo_state=1");
        //    if (type == 1)
        //    {
        //        strSql.Append("and exists(select 1 from C_Post p where p.C_Post_code=a.C_Post_code and p.C_Post_group='DA275F5A-4809-4F9D-832E-B213A65A78F5') ");
        //    }
        //    else if (type == 2)
        //    {
        //        strSql.Append("and exists(select 1 from C_Post p where p.C_Post_code=a.C_Post_code and p.C_Post_group='A33B44C7-93A0-4520-94D5-C50C8C7AC99F')");
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获得首席或者部长列表
        /// </summary>
        /// <param name="type">1.首席，2.部长</param>
        /// <returns></returns>
        public DataSet GetFirstOrMiniterList(int type)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select U.*,(select top 1 O.C_Organization_name from  C_Organization AS O where O.C_Organization_code=OPU.C_Organization_code) AS C_Userinfo_Organization_name,");
            strSql.Append("(select top 1 POST.C_Post_name from C_Post AS POST where POST.C_Post_code=OPU.C_Post_code) AS C_Post_name,");
            strSql.Append("OPUR.C_region_code AS C_Userinfo_Regioncode ");
            strSql.Append("from C_Userinfo AS U,C_Organization_post_user AS OPU,C_Organization_post_user_region AS OPUR ");
            strSql.Append("where U.C_userinfo_code=OPU.C_User_code and OPU.C_User_code=OPUR.C_User_code and OPU.C_Post_code=OPUR.C_Post_code and OPU.C_Organization_code=OPUR.C_Organization_code ");
            strSql.Append("and U.C_Userinfo_isDelete=0 and U.C_Userinfo_state=1 ");
            strSql.Append("and OPU.C_Organization_post_user_isDelete=0 and OPUR.C_Organization_post_user_region_isDelete=0  ");


            if (type == 1)
            {
                strSql.Append("and exists(select 1 from C_Post p where p.C_Post_code=OPU.C_Post_code and p.C_Post_group='DA275F5A-4809-4F9D-832E-B213A65A78F5') ");
            }
            else if (type == 2)
            {
                strSql.Append("and exists(select 1 from C_Post p where p.C_Post_code=OPU.C_Post_code and p.C_Post_group='A33B44C7-93A0-4520-94D5-C50C8C7AC99F')");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取首席记录总数
        /// </summary>
        public int GetFirsrRecordCount(Model.SysManager.C_Userinfo user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Organization_post_user as a ");
            strSql.Append("left join C_Userinfo as b on a.C_User_code=b.C_Userinfo_code ");
            strSql.Append("where b.C_Userinfo_isDelete=0 and b.C_Userinfo_state=1  ");
            strSql.Append("and exists(select 1 from C_Post p where p.C_Post_code=a.C_Post_code and p.C_Post_group='DA275F5A-4809-4F9D-832E-B213A65A78F5') ");
            if (user != null)
            {
                if (user.C_Userinfo_code != null)
                {
                    strSql.Append(" and C_Userinfo_code=@C_Userinfo_code");
                }
                if (user.C_Userinfo_createTime != null)
                {
                    strSql.Append(" and C_Userinfo_createTime=@C_Userinfo_createTime");
                }
                if (user.C_Userinfo_creator != null)
                {
                    strSql.Append(" and C_Userinfo_creator=@C_Userinfo_creator");
                }
                if (user.C_Userinfo_name != null && user.C_Userinfo_name != "")
                {
                    strSql.Append(" and C_Userinfo_name like N'%'+@C_Userinfo_name+'%'");
                }
                if (user.C_Userinfo_Organization != null)
                {
                    strSql.Append(" and C_Userinfo_Organization=@C_Userinfo_Organization");
                }
                if (user.C_Userinfo_parent != null)
                {
                    strSql.Append(" and C_Userinfo_parent=@C_Userinfo_parent");
                }
                if (user.C_Userinfo_state != null)
                {
                    strSql.Append(" and C_Userinfo_state=@C_Userinfo_state");
                }
                if (user.C_Userinfo_relationCode != null)
                {
                    strSql.Append(" and CL.C_Court=@C_Court");
                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = user.C_Userinfo_code;
            parameters[1].Value = user.C_Userinfo_name;
            parameters[2].Value = user.C_Userinfo_loginID;
            parameters[3].Value = user.C_Userinfo_password;
            parameters[4].Value = user.C_Userinfo_roleID;
            parameters[5].Value = user.C_Userinfo_isDelete;
            parameters[6].Value = user.C_Userinfo_parent;
            parameters[7].Value = user.C_Userinfo_description;
            parameters[8].Value = user.C_Userinfo_state;
            parameters[9].Value = user.C_Userinfo_creator;
            parameters[10].Value = user.C_Userinfo_createTime;
            parameters[11].Value = user.C_Userinfo_Organization;
            parameters[12].Value = user.C_Userinfo_id;
            parameters[13].Value = user.C_Userinfo_relationCode;
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
        /// 获得首席分页获取数据列表
        /// </summary>
        public DataSet GetFirstListByPage(Model.SysManager.C_Userinfo user, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by b." + orderby);
            }
            else
            {
                strSql.Append("order by b.C_Userinfo_id desc");
            }
            strSql.Append(")AS Row, b.* from C_Organization_post_user as a ");
            strSql.Append("left join C_Userinfo as b on a.C_User_code=b.C_Userinfo_code ");
            strSql.Append("where b.C_Userinfo_isDelete=0 and b.C_Userinfo_state=1 ");
            strSql.Append("and exists(select 1 from C_Post p where p.C_Post_code=a.C_Post_code and p.C_Post_group='DA275F5A-4809-4F9D-832E-B213A65A78F5') ");
            if (user != null)
            {
                if (user.C_Userinfo_code != null)
                {
                    strSql.Append(" and T.C_Userinfo_code=@C_Userinfo_code");
                }
                if (user.C_Userinfo_createTime != null)
                {
                    strSql.Append(" and T.C_Userinfo_createTime=@C_Userinfo_createTime");
                }
                if (user.C_Userinfo_creator != null)
                {
                    strSql.Append(" and T.C_Userinfo_creator=@C_Userinfo_creator");
                }
                if (user.C_Userinfo_name != null && user.C_Userinfo_name != "")
                {
                    strSql.Append(" and T.C_Userinfo_name like N'%'+@C_Userinfo_name+'%'");
                }
                if (user.C_Userinfo_Organization != null)
                {
                    strSql.Append(" and T.C_Userinfo_Organization=@C_Userinfo_Organization");
                }
                if (user.C_Userinfo_parent != null)
                {
                    strSql.Append(" and T.C_Userinfo_parent=@C_Userinfo_parent");
                }
                if (user.C_Userinfo_state != null)
                {
                    strSql.Append(" and T.C_Userinfo_state=@C_Userinfo_state");
                }
                if (user.C_Userinfo_relationCode != null)
                {
                    strSql.Append(" and CL.C_Court=@C_Court");
                }
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Userinfo_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_name", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_loginID", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_password", SqlDbType.VarChar,100),
					new SqlParameter("@C_Userinfo_roleID", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@C_Userinfo_parent", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_description", SqlDbType.VarChar,500),
					new SqlParameter("@C_Userinfo_state", SqlDbType.Int,4),
					new SqlParameter("@C_Userinfo_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Userinfo_Organization", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Userinfo_id", SqlDbType.Int,4),
                    new SqlParameter("@C_Court",SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = user.C_Userinfo_code;
            parameters[1].Value = user.C_Userinfo_name;
            parameters[2].Value = user.C_Userinfo_loginID;
            parameters[3].Value = user.C_Userinfo_password;
            parameters[4].Value = user.C_Userinfo_roleID;
            parameters[5].Value = user.C_Userinfo_isDelete;
            parameters[6].Value = user.C_Userinfo_parent;
            parameters[7].Value = user.C_Userinfo_description;
            parameters[8].Value = user.C_Userinfo_state;
            parameters[9].Value = user.C_Userinfo_creator;
            parameters[10].Value = user.C_Userinfo_createTime;
            parameters[11].Value = user.C_Userinfo_Organization;
            parameters[12].Value = user.C_Userinfo_id;
            parameters[13].Value = user.C_Userinfo_relationCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion  ExtensionMethod
    }
}

