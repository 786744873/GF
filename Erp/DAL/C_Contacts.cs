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
    /// 数据访问类:联系人表
    /// 作者：崔慧栋
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Contacts
    {
        public C_Contacts()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("C_Contacts_id", "C_Contacts");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Contacts_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Contacts");
            strSql.Append(" where C_Contacts_id=@C_Contacts_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Contacts_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Contacts(");
            strSql.Append("C_Contacts_code,C_Contacts_type,C_Contacts_number,C_Contacts_is_main,C_Contacts_name,C_Contacts_sex,C_Contacts_post,C_Contacts_phone,C_Contacts_role,C_Contacts_mobile,");
            strSql.Append("C_Contacts_email,C_Contacts_hometown,C_Contacts_creator,C_Contacts_createTime,C_Contacts_isDelete,C_Contacts_birthday,C_Contacts_nation,C_Contacts_political,C_Contacts_address,");
            strSql.Append("C_Contacts_contact_number,C_Contacts_id_number,C_Contacts_character,C_Contacts_hobby)");
            strSql.Append(" values (");
            strSql.Append("@C_Contacts_code,@C_Contacts_type,@C_Contacts_number,@C_Contacts_is_main,@C_Contacts_name,@C_Contacts_sex,@C_Contacts_post,@C_Contacts_phone,@C_Contacts_role,@C_Contacts_mobile,");
            strSql.Append("@C_Contacts_email,@C_Contacts_hometown,@C_Contacts_creator,@C_Contacts_createTime,@C_Contacts_isDelete,@C_Contacts_birthday,@C_Contacts_nation,@C_Contacts_political,@C_Contacts_address,");
            strSql.Append("@C_Contacts_contact_number,@C_Contacts_id_number,@C_Contacts_character,@C_Contacts_hobby)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_type", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_is_main", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_sex", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_post", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_phone", SqlDbType.VarChar,20),
                    new SqlParameter("@C_Contacts_role", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_email", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_hometown", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_creator", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Contacts_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_nation", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_political", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_address", SqlDbType.VarChar,200),
                    new SqlParameter("@C_Contacts_contact_number",SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_id_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_character", SqlDbType.VarChar,200),
					new SqlParameter("@C_Contacts_hobby", SqlDbType.VarChar,200)};
            parameters[0].Value = model.C_Contacts_code;
            parameters[1].Value = model.C_Contacts_type;
            parameters[2].Value = model.C_Contacts_number;
            parameters[3].Value = model.C_Contacts_is_main;
            parameters[4].Value = model.C_Contacts_name;
            parameters[5].Value = model.C_Contacts_sex;
            parameters[6].Value = model.C_Contacts_post;
            parameters[7].Value = model.C_Contacts_phone;
            parameters[8].Value = model.C_Contacts_role;
            parameters[9].Value = model.C_Contacts_mobile;
            parameters[10].Value = model.C_Contacts_email;
            parameters[11].Value = model.C_Contacts_hometown;
            parameters[12].Value = model.C_Contacts_creator;
            parameters[13].Value = model.C_Contacts_createTime;
            parameters[14].Value = model.C_Contacts_isDelete;
            parameters[15].Value = model.C_Contacts_birthday;
            parameters[16].Value = model.C_Contacts_nation;
            parameters[17].Value = model.C_Contacts_political;
            parameters[18].Value = model.C_Contacts_address;
            parameters[19].Value = model.C_Contacts_contact_number;
            parameters[20].Value = model.C_Contacts_id_number;
            parameters[21].Value = model.C_Contacts_character;
            parameters[22].Value = model.C_Contacts_hobby;

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
        public bool Update(CommonService.Model.C_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Contacts set ");
            strSql.Append("C_Contacts_code=@C_Contacts_code,");
            strSql.Append("C_Contacts_type=@C_Contacts_type,");
            strSql.Append("C_Contacts_number=@C_Contacts_number,");
            strSql.Append("C_Contacts_is_main=@C_Contacts_is_main,");
            strSql.Append("C_Contacts_name=@C_Contacts_name,");
            strSql.Append("C_Contacts_sex=@C_Contacts_sex,");
            strSql.Append("C_Contacts_post=@C_Contacts_post,");
            strSql.Append("C_Contacts_phone=@C_Contacts_phone,");
            strSql.Append("C_Contacts_role=@C_Contacts_role,");
            strSql.Append("C_Contacts_mobile=@C_Contacts_mobile,");
            strSql.Append("C_Contacts_email=@C_Contacts_email,");
            strSql.Append("C_Contacts_hometown=@C_Contacts_hometown,");
            strSql.Append("C_Contacts_creator=@C_Contacts_creator,");
            strSql.Append("C_Contacts_createTime=@C_Contacts_createTime,");
            strSql.Append("C_Contacts_isDelete=@C_Contacts_isDelete,");
            strSql.Append("C_Contacts_birthday=@C_Contacts_birthday,");
            strSql.Append("C_Contacts_nation=@C_Contacts_nation,");
            strSql.Append("C_Contacts_political=@C_Contacts_political,");
            strSql.Append("C_Contacts_address=@C_Contacts_address,");
            strSql.Append("C_Contacts_contact_number=@C_Contacts_contact_number,");
            strSql.Append("C_Contacts_id_number=@C_Contacts_id_number,");
            strSql.Append("C_Contacts_character=@C_Contacts_character,");
            strSql.Append("C_Contacts_hobby=@C_Contacts_hobby");
            strSql.Append(" where C_Contacts_id=@C_Contacts_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_type", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_is_main", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_sex", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_post", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_phone", SqlDbType.VarChar,20),
                    new SqlParameter("@C_Contacts_role", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_email", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_hometown", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_creator", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Contacts_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_nation", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_political", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_address", SqlDbType.VarChar,200),
                    new SqlParameter("@C_Contacts_contact_number",SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_id_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_character", SqlDbType.VarChar,200),
					new SqlParameter("@C_Contacts_hobby", SqlDbType.VarChar,200),
                    new SqlParameter("@C_Contacts_id",SqlDbType.Int)};
            parameters[0].Value = model.C_Contacts_code;
            parameters[1].Value = model.C_Contacts_type;
            parameters[2].Value = model.C_Contacts_number;
            parameters[3].Value = model.C_Contacts_is_main;
            parameters[4].Value = model.C_Contacts_name;
            parameters[5].Value = model.C_Contacts_sex;
            parameters[6].Value = model.C_Contacts_post;
            parameters[7].Value = model.C_Contacts_phone;
            parameters[8].Value = model.C_Contacts_role;
            parameters[9].Value = model.C_Contacts_mobile;
            parameters[10].Value = model.C_Contacts_email;
            parameters[11].Value = model.C_Contacts_hometown;
            parameters[12].Value = model.C_Contacts_creator;
            parameters[13].Value = model.C_Contacts_createTime;
            parameters[14].Value = model.C_Contacts_isDelete;
            parameters[15].Value = model.C_Contacts_birthday;
            parameters[16].Value = model.C_Contacts_nation;
            parameters[17].Value = model.C_Contacts_political;
            parameters[18].Value = model.C_Contacts_address;
            parameters[19].Value = model.C_Contacts_contact_number;
            parameters[20].Value = model.C_Contacts_id_number;
            parameters[21].Value = model.C_Contacts_character;
            parameters[22].Value = model.C_Contacts_hobby;
            parameters[23].Value = model.C_Contacts_id;

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
        public bool Delete(Guid C_Contacts_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Contacts set C_Contacts_isDelete=1");
            strSql.Append(" where C_Contacts_code=@C_Contacts_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Contacts_code;

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
        public bool DeleteList(string C_Contacts_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Contacts ");
            strSql.Append(" where C_Contacts_id in (" + C_Contacts_idlist + ")  ");
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
        public CommonService.Model.C_Contacts GetModel(int C_Contacts_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Contacts_id,C_Contacts_code,C_Contacts_type,C_Contacts_number,C_Contacts_is_main,C_Contacts_name,C_Contacts_sex,C_Contacts_post,C_Contacts_phone,C_Contacts_role,C_Contacts_mobile,");
            strSql.Append("C_Contacts_email,C_Contacts_hometown,C_Contacts_creator,C_Contacts_createTime,C_Contacts_isDelete,C_Contacts_birthday,C_Contacts_nation,C_Contacts_political,C_Contacts_address,");
            strSql.Append("C_Contacts_contact_number,C_Contacts_id_number,C_Contacts_character,C_Contacts_hobby,newid() as C_Contacts_relationCode from C_Contacts");
            strSql.Append(" where C_Contacts_id=@C_Contacts_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Contacts_id;

            CommonService.Model.C_Contacts model = new CommonService.Model.C_Contacts();
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
        public CommonService.Model.C_Contacts GetModel(Guid C_Contacts_code)
        {

            StringBuilder strSql = new StringBuilder();
 
            strSql.Append("select top 1 C.*,Nation.C_Parameters_name As C_Contacts_nation_name,Political.C_Parameters_name As C_Contacts_political_name,newid() as C_Contacts_relationCode ");
            strSql.Append("from C_Contacts As C ");
            strSql.Append("left join C_Parameters As Nation on C.C_Contacts_nation=Nation.C_Parameters_id ");
            strSql.Append("left join C_Parameters As Political on C.C_Contacts_political=Political.C_Parameters_id ");
            strSql.Append("where C.C_Contacts_code=@C_Contacts_code");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Contacts_code;

            CommonService.Model.C_Contacts model = new CommonService.Model.C_Contacts();
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
        public CommonService.Model.C_Contacts DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Contacts model = new CommonService.Model.C_Contacts();
            if (row != null)
            {
                if (row["C_Contacts_id"] != null && row["C_Contacts_id"].ToString() != "")
                {
                    model.C_Contacts_id = int.Parse(row["C_Contacts_id"].ToString());
                }
                if (row["C_Contacts_code"] != null && row["C_Contacts_code"].ToString() != "")
                {
                    model.C_Contacts_code =new Guid(row["C_Contacts_code"].ToString());
                }
                if (row["C_Contacts_type"] != null && row["C_Contacts_type"].ToString() != "")
                {
                    model.C_Contacts_type = int.Parse(row["C_Contacts_type"].ToString());
                }
                if (row["C_Contacts_number"] != null)
                {
                    model.C_Contacts_number = row["C_Contacts_number"].ToString();
                }
                if (row["C_Contacts_is_main"] != null && row["C_Contacts_is_main"].ToString() != "")
                {
                    model.C_Contacts_is_main =int.Parse(row["C_Contacts_is_main"].ToString());
                }
                if (row["C_Contacts_name"] != null)
                {
                    model.C_Contacts_name = row["C_Contacts_name"].ToString();
                }
                if (row["C_Contacts_sex"] != null && row["C_Contacts_sex"].ToString() != "")
                {
                    model.C_Contacts_sex = int.Parse(row["C_Contacts_sex"].ToString());
                }
                if (row["C_Contacts_post"] != null)
                {
                    model.C_Contacts_post = row["C_Contacts_post"].ToString();
                }
                if (row["C_Contacts_phone"] != null)
                {
                    model.C_Contacts_phone =row["C_Contacts_phone"].ToString();
                }
                if (row["C_Contacts_role"] != null)
                {
                    model.C_Contacts_role = row["C_Contacts_role"].ToString();
                }
                if (row["C_Contacts_mobile"] != null)
                {
                    model.C_Contacts_mobile = row["C_Contacts_mobile"].ToString();
                }
                if (row["C_Contacts_email"] != null)
                {
                    model.C_Contacts_email =row["C_Contacts_email"].ToString();
                }
                if (row["C_Contacts_hometown"] != null)
                {
                    model.C_Contacts_hometown = row["C_Contacts_hometown"].ToString();
                }
                if (row["C_Contacts_creator"] != null && row["C_Contacts_creator"].ToString()!="")
                {
                    model.C_Contacts_creator =new Guid(row["C_Contacts_creator"].ToString());
                }
                if (row["C_Contacts_createTime"] != null)
                {
                    model.C_Contacts_createTime =DateTime.Parse(row["C_Contacts_createTime"].ToString());
                }
                if (row["C_Contacts_isDelete"] != null && row["C_Contacts_isDelete"].ToString() != "")
                {
                    model.C_Contacts_isDelete = int.Parse(row["C_Contacts_isDelete"].ToString());
                }

                if (row["C_Contacts_birthday"] != null && row["C_Contacts_birthday"].ToString() != "")
                {
                    model.C_Contacts_birthday =DateTime.Parse(row["C_Contacts_birthday"].ToString());
                }
                if (row["C_Contacts_nation"] != null && row["C_Contacts_nation"].ToString() != "")
                {
                    model.C_Contacts_nation =int.Parse(row["C_Contacts_nation"].ToString());
                }
                //民族名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Contacts_nation_name"))
                {
                    if (row["C_Contacts_nation_name"] != null)
                    {
                        model.C_Contacts_nation_name = row["C_Contacts_nation_name"].ToString();
                    }
                }
                if (row["C_Contacts_political"] != null && row["C_Contacts_political"].ToString() != "")
                {
                    model.C_Contacts_political =int.Parse(row["C_Contacts_political"].ToString());
                }
                //政治面貌名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Contacts_political_name"))
                {
                    if (row["C_Contacts_political_name"] != null)
                    {
                        model.C_Contacts_political_name = row["C_Contacts_political_name"].ToString();
                    }
                }
                if (row["C_Contacts_address"] != null)
                {
                    model.C_Contacts_address = row["C_Contacts_address"].ToString();
                }
                if (row["C_Contacts_contact_number"] != null)
                {
                    model.C_Contacts_contact_number = row["C_Contacts_contact_number"].ToString();
                }
                if (row["C_Contacts_id_number"] != null)
                {
                    model.C_Contacts_id_number = row["C_Contacts_id_number"].ToString();
                }
                if (row["C_Contacts_character"] != null)
                {
                    model.C_Contacts_character =row["C_Contacts_character"].ToString();
                }
                if (row["C_Contacts_hobby"] != null)
                {
                    model.C_Contacts_hobby =row["C_Contacts_hobby"].ToString();
                }
                if (row["C_Contacts_relationCode"] != null)
                {
                    model.C_Contacts_relationCode =new Guid(row["C_Contacts_relationCode"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Contacts_id,C_Contacts_code,C_Contacts_type,C_Contacts_number,C_Contacts_is_main,C_Contacts_name,C_Contacts_sex,C_Contacts_post,C_Contacts_phone,C_Contacts_role,C_Contacts_mobile,");
            strSql.Append("C_Contacts_email,C_Contacts_hometown,C_Contacts_creator,C_Contacts_createTime,C_Contacts_isDelete,C_Contacts_birthday,C_Contacts_nation,C_Contacts_political,C_Contacts_address,");
            strSql.Append("C_Contacts_contact_number,C_Contacts_id_number,C_Contacts_character,C_Contacts_hobby,newid() as C_Contacts_relationCode ");
            strSql.Append(" FROM C_Contacts where C_Contacts_isDelete=0");
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
            strSql.Append(" C_Contacts_id,C_Contacts_code,C_Contacts_type,C_Contacts_number,C_Contacts_is_main,C_Contacts_name,C_Contacts_sex,C_Contacts_post,C_Contacts_phone,C_Contacts_role,C_Contacts_mobile,");
            strSql.Append("C_Contacts_email,C_Contacts_hometown,C_Contacts_creator,C_Contacts_createTime,C_Contacts_isDelete,C_Contacts_birthday,C_Contacts_nation,C_Contacts_political,C_Contacts_address,");
            strSql.Append("C_Contacts_contact_number,C_Contacts_id_number,C_Contacts_character,C_Contacts_hobby");
            strSql.Append(" FROM C_Contacts ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 客户联系人
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public DataSet GetListByCustomerCode(Guid customerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T.*,newid() as C_Contacts_relationCode  from C_Contacts T ");
            strSql.Append("where exists(select 1 from C_Customer_Contacts AS CCR with(nolock) where CCR.C_Customer_Contacts_isDelete=0 and CCR.C_Customer_Contacts_contact=C_Contacts_code ");
            strSql.Append("and CCR.C_Customer_Contacts_customer=@C_Contacts_relationCode) ");
            strSql.Append("and C_Contacts_isDelete=0 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Contacts_relationCode", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = customerCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByRelationAndType(CommonService.Model.C_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            if (model.C_Contacts_type==2)
            {//客户联系人
                strSql.Append("select T.*,newid() as C_Contacts_relationCode  from C_Contacts T ");
                strSql.Append("where exists(select 1 from C_Customer_Contacts AS CCR with(nolock) where CCR.C_Customer_Contacts_isDelete=0 and CCR.C_Customer_Contacts_contact=C_Contacts_code ");
                strSql.Append("and CCR.C_Customer_Contacts_customer=@C_Contacts_relationCode) ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }
            else if (model.C_Contacts_type==4)
            {//法官联系人
                strSql.Append("select T.*,CCR.C_Judge_code as C_Contacts_relationCode  from C_Contacts T ");
                strSql.Append("join  C_Judge CCR on T.C_Contacts_code=CCR.C_Judge_contactscode where CCR.C_Judge_isdelete=0 ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }
            else if (model.C_Contacts_type==5)
            {//涉案工程人
                strSql.Append("select T.*,newid() as C_Contacts_relationCode  from C_Contacts T join C_Involved_projectUnit_person P on T.C_Contacts_code=P.C_Involved_projectUnit_person_contacts ");
                strSql.Append("where P.C_Involved_projectUnit_person_isDelete=0 and P.C_Involved_projectUnit_code=@C_Contacts_relationCode ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }
            else if (model.C_Contacts_type == 6)
            {//商机联系人
                strSql.Append("select T.*,BCL.B_BusinessChance_code as C_Contacts_relationCode from C_Contacts as T join B_BusinessChance_link as BCL on T.C_Contacts_code=BCL.C_FK_code ");
                strSql.Append("where BCL.B_BusinessChance_code=@C_Contacts_relationCode ");
                strSql.Append("and T.C_Contacts_isDelete=0 ");
            }
            else
            {
                strSql.Append("select T.*,newid() as C_Contacts_relationCode  from C_Contacts T ");
                strSql.Append("where 1=1 and C_Contacts_isDelete=0 ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_relationCode", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.C_Contacts_relationCode;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(Model.C_Contacts model)
        {
            StringBuilder strSql = new StringBuilder();
            if (model.C_Contacts_type == 2)
            {//客户联系人
                strSql.Append("select count(1) FROM C_Contacts with(nolock) ");
                strSql.Append("where exists(select 1 from C_Customer_Contacts AS CCR with(nolock) where CCR.C_Customer_Contacts_isDelete=0 and CCR.C_Customer_Contacts_contact=C_Contacts_code ");
                strSql.Append("and CCR.C_Customer_Contacts_customer=@C_Contacts_relationCode) ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }
            else if (model.C_Contacts_type == 4)
            {//法官联系人
                strSql.Append("select count(1) FROM C_Contacts with(nolock) ");
                strSql.Append("where exists(select 1 from C_Judge AS CCR with(nolock) where CCR.C_Judge_isdelete=0 and CCR.C_Judge_contactscode=C_Contacts_code )");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }else if(model.C_Contacts_type == 5)
            {//涉案工程人
                strSql.Append("select count(1) from C_Contacts as T join C_Involved_projectUnit_person P on T.C_Contacts_code=P.C_Involved_projectUnit_person_contacts ");
                strSql.Append("where P.C_Involved_projectUnit_person_isDelete=0 and P.C_Involved_projectUnit_code=@C_Contacts_relationCode ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }else if (model.C_Contacts_type == 6)
            {//商机联系人
                strSql.Append("select count(1) from C_Contacts as T join B_BusinessChance_link as BCL on T.C_Contacts_code=BCL.C_FK_code ");
                strSql.Append("where BCL.B_BusinessChance_code=@C_Contacts_relationCode ");
                strSql.Append("and T.C_Contacts_isDelete=0 ");
            }
            else
            {
                strSql.Append("select count(1) FROM C_Contacts ");
                strSql.Append(" where 1=1 and C_Contacts_isDelete=0 ");
            }

            if (model != null)
            {
                if (model.C_Contacts_type == 3)
                {
                    strSql.Append(" and C_Contacts_type=@C_Contacts_type");
                }
                if (model.C_Contacts_name != null && model.C_Contacts_name != "")
                {
                    strSql.Append(" and C_Contacts_name like N'%'+@C_Contacts_name+'%' ");
                }
                if (model.C_Contacts_sex != null)
                {
                    strSql.Append(" and C_Contacts_sex=@C_Contacts_sex");
                }
                if (model.C_Contacts_post != null)
                {
                    strSql.Append(" and C_Contacts_post=@C_Contacts_post");
                }
                if (model.C_Contacts_phone != null)
                {
                    strSql.Append(" and C_Contacts_phone=@C_Contacts_phone");
                }
                if (model.C_Contacts_role != null)
                {
                    strSql.Append(" and C_Contacts_role=@C_Contacts_role");
                }
                if (model.C_Contacts_mobile != null)
                {
                    strSql.Append(" and C_Contacts_mobile like N'%'+@C_Contacts_mobile+'%' ");
                }

                if (model.C_Contacts_id_number != null)
                {
                    strSql.Append(" and C_Contacts_id_number=@C_Contacts_id_number");
                }
                if (model.C_Contacts_contact_number != null)
                {
                    strSql.Append(" and C_Contacts_contact_number like N'%'+@C_Contacts_contact_number+'%' ");
                }
                if (model.C_Contacts_relationCode != null)
                {

                }
            }
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_type", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_is_main", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_sex", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_post", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_phone", SqlDbType.VarChar,20),
                    new SqlParameter("@C_Contacts_role", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_email", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_hometown", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_creator", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Contacts_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_nation", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_political", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_Contacts_id_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_character", SqlDbType.VarChar,200),
					new SqlParameter("@C_Contacts_hobby", SqlDbType.VarChar,200),
                    new SqlParameter("@C_Contacts_contact_number",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Contacts_id",SqlDbType.Int),
                    new SqlParameter("@C_Contacts_relationCode", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = model.C_Contacts_code;
            parameters[1].Value = model.C_Contacts_type;
            parameters[2].Value = model.C_Contacts_number;
            parameters[3].Value = model.C_Contacts_is_main;
            parameters[4].Value = model.C_Contacts_name;
            parameters[5].Value = model.C_Contacts_sex;
            parameters[6].Value = model.C_Contacts_post;
            parameters[7].Value = model.C_Contacts_phone;
            parameters[8].Value = model.C_Contacts_role;
            parameters[9].Value = model.C_Contacts_mobile;
            parameters[10].Value = model.C_Contacts_email;
            parameters[11].Value = model.C_Contacts_hometown;
            parameters[12].Value = model.C_Contacts_creator;
            parameters[13].Value = model.C_Contacts_createTime;
            parameters[14].Value = model.C_Contacts_isDelete;
            parameters[15].Value = model.C_Contacts_birthday;
            parameters[16].Value = model.C_Contacts_nation;
            parameters[17].Value = model.C_Contacts_political;
            parameters[18].Value = model.C_Contacts_address;
            parameters[19].Value = model.C_Contacts_id_number;
            parameters[20].Value = model.C_Contacts_character;
            parameters[21].Value = model.C_Contacts_hobby;
            parameters[22].Value = model.C_Contacts_contact_number;
            parameters[23].Value = model.C_Contacts_id;
            parameters[24].Value = model.C_Contacts_relationCode;
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
        public DataSet GetListByPage(Model.C_Contacts model, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Contacts_id desc");
            }
            
            if (model.C_Contacts_type == 2)
            {//客户联系人               
                strSql.Append(")AS Row, T.*,newid() as C_Contacts_relationCode  from C_Contacts T ");
                strSql.Append("where exists(select 1 from C_Customer_Contacts AS CCR with(nolock) where CCR.C_Customer_Contacts_isDelete=0 and CCR.C_Customer_Contacts_contact=C_Contacts_code ");
                strSql.Append("and CCR.C_Customer_Contacts_customer=@C_Contacts_relationCode) ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }
            else if (model.C_Contacts_type == 4)
            {//法官联系人
                strSql.Append(")AS Row, T.*,CCR.C_Judge_code as C_Contacts_relationCode  from C_Contacts T ");
                strSql.Append("join  C_Judge CCR on T.C_Contacts_code=CCR.C_Judge_contactscode where CCR.C_Judge_isdelete=0 ");
                //strSql.Append("and CCR.C_Judge_code=@C_Contacts_relationCode) ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }
            else if(model.C_Contacts_type==5)
            {//涉案工程人
                strSql.Append(")AS Row, T.*,newid() as C_Contacts_relationCode  from C_Contacts T join C_Involved_projectUnit_person P on T.C_Contacts_code=P.C_Involved_projectUnit_person_contacts ");
                strSql.Append("where P.C_Involved_projectUnit_person_isDelete=0 and P.C_Involved_projectUnit_code=@C_Contacts_relationCode ");
                strSql.Append("and C_Contacts_isDelete=0 ");
            }else if(model.C_Contacts_type==6)
            {//商机联系人
                strSql.Append(")AS Row, T.*,BCL.B_BusinessChance_code as C_Contacts_relationCode from C_Contacts as T join B_BusinessChance_link as BCL on T.C_Contacts_code=BCL.C_FK_code ");
                strSql.Append("where BCL.B_BusinessChance_code=@C_Contacts_relationCode ");
                strSql.Append("and T.C_Contacts_isDelete=0 ");
            }
            else
            {
                strSql.Append(")AS Row, T.*,newid() as C_Contacts_relationCode  from C_Contacts T ");
                strSql.Append("where 1=1 and C_Contacts_isDelete=0 ");
            }
           
            if (model != null)
            {
                if(model.C_Contacts_type==3)
                {
                    strSql.Append(" and C_Contacts_type=@C_Contacts_type");
                }
                if (model.C_Contacts_name != null && model.C_Contacts_name != "")
                {
                    strSql.Append(" and C_Contacts_name like N'%'+@C_Contacts_name+'%' ");
                }
                if (model.C_Contacts_sex != null)
                {
                    strSql.Append(" and C_Contacts_sex=@C_Contacts_sex");
                }
                if (model.C_Contacts_post != null)
                {
                    strSql.Append(" and C_Contacts_post=@C_Contacts_post");
                }
                if (model.C_Contacts_phone != null)
                {
                    strSql.Append(" and C_Contacts_phone=@C_Contacts_phone");
                }
                if (model.C_Contacts_role != null)
                {
                    strSql.Append(" and C_Contacts_role=@C_Contacts_role");
                }
                if (model.C_Contacts_mobile != null)
                {
                    strSql.Append(" and C_Contacts_mobile like N'%'+@C_Contacts_mobile+'%' ");
                }
                if (model.C_Contacts_id_number != null)
                {
                    strSql.Append(" and C_Contacts_id_number=@C_Contacts_id_number");
                }
                if (model.C_Contacts_contact_number != null)
                {
                    strSql.Append(" and C_Contacts_contact_number like N'%'+@C_Contacts_contact_number+'%' ");
                }
            }

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@C_Contacts_code", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_type", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_is_main", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_name", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_sex", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_post", SqlDbType.VarChar,100),
					new SqlParameter("@C_Contacts_phone", SqlDbType.VarChar,20),
                    new SqlParameter("@C_Contacts_role", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_email", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_hometown", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_creator", SqlDbType.UniqueIdentifier),
					new SqlParameter("@C_Contacts_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_isDelete", SqlDbType.Int,4),
                    new SqlParameter("@C_Contacts_birthday", SqlDbType.DateTime),
					new SqlParameter("@C_Contacts_nation", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_political", SqlDbType.Int,4),
					new SqlParameter("@C_Contacts_address", SqlDbType.VarChar,200),
					new SqlParameter("@C_Contacts_id_number", SqlDbType.VarChar,50),
					new SqlParameter("@C_Contacts_character", SqlDbType.VarChar,200),
					new SqlParameter("@C_Contacts_hobby", SqlDbType.VarChar,200),
                    new SqlParameter("@C_Contacts_contact_number",SqlDbType.VarChar,50),
                    new SqlParameter("@C_Contacts_id",SqlDbType.Int),
                    new SqlParameter("@C_Contacts_relationCode", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.C_Contacts_code;
            parameters[1].Value = model.C_Contacts_type;
            parameters[2].Value = model.C_Contacts_number;
            parameters[3].Value = model.C_Contacts_is_main;
            parameters[4].Value = model.C_Contacts_name;
            parameters[5].Value = model.C_Contacts_sex;
            parameters[6].Value = model.C_Contacts_post;
            parameters[7].Value = model.C_Contacts_phone;
            parameters[8].Value = model.C_Contacts_role;
            parameters[9].Value = model.C_Contacts_mobile;
            parameters[10].Value = model.C_Contacts_email;
            parameters[11].Value = model.C_Contacts_hometown;
            parameters[12].Value = model.C_Contacts_creator;
            parameters[13].Value = model.C_Contacts_createTime;
            parameters[14].Value = model.C_Contacts_isDelete;
            parameters[15].Value = model.C_Contacts_birthday;
            parameters[16].Value = model.C_Contacts_nation;
            parameters[17].Value = model.C_Contacts_political;
            parameters[18].Value = model.C_Contacts_address;
            parameters[19].Value = model.C_Contacts_id_number;
            parameters[20].Value = model.C_Contacts_character;
            parameters[21].Value = model.C_Contacts_hobby;
            parameters[22].Value = model.C_Contacts_contact_number;
            parameters[23].Value = model.C_Contacts_id;
            parameters[24].Value = model.C_Contacts_relationCode;
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
            parameters[0].Value = "C_Contacts";
            parameters[1].Value = "C_Contacts_id";
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
