using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.BusinessChanceManager
{
    /// <summary>
    /// 数据访问类:商机审查表
    /// 作者：贺太玉
    /// 日期：2015/10/29
    /// </summary>
    public partial class B_BusinessChance_check
    {
        public B_BusinessChance_check()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("B_BusinessChance_check_id", "B_BusinessChance_check");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_BusinessChance_check_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_BusinessChance_check");
            strSql.Append(" where B_BusinessChance_check_id=@B_BusinessChance_check_id");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_id", SqlDbType.Int,4)
			};
            parameters[0].Value = B_BusinessChance_check_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_BusinessChance_check(");
            strSql.Append("B_BusinessChance_check_code,B_BusinessChance_check_checkType,B_BusinessChance_check_Nature,B_BusinessChance_check_category,B_BusinessChance_check_confirmPerson,B_BusinessChance_check_planStartTime,B_BusinessChance_check_planEndTime,B_BusinessChance_check_checkOpinion,B_BusinessChance_check_checkPerson,B_BusinessChance_check_checkTime,B_BusinessChance_checkPersonType,B_BusinessChance_check_BusinessChance_code,B_BusinessChance_check_isChecked,B_BusinessChance_check_creator,B_BusinessChance_check_createTime,B_BusinessChance_check_isDelete)");
            strSql.Append(" values (");
            strSql.Append("@B_BusinessChance_check_code,@B_BusinessChance_check_checkType,@B_BusinessChance_check_Nature,@B_BusinessChance_check_category,@B_BusinessChance_check_confirmPerson,@B_BusinessChance_check_planStartTime,@B_BusinessChance_check_planEndTime,@B_BusinessChance_check_checkOpinion,@B_BusinessChance_check_checkPerson,@B_BusinessChance_check_checkTime,@B_BusinessChance_checkPersonType,@B_BusinessChance_check_BusinessChance_code,@B_BusinessChance_check_isChecked,@B_BusinessChance_check_creator,@B_BusinessChance_check_createTime,@B_BusinessChance_check_isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_checkType", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_Nature", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_category", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_confirmPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_planStartTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_check_planEndTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_check_checkOpinion", SqlDbType.NVarChar,500),
					new SqlParameter("@B_BusinessChance_check_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_checkTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_checkPersonType", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_isChecked", SqlDbType.Bit,1),
					new SqlParameter("@B_BusinessChance_check_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_check_isDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.B_BusinessChance_check_code;
            parameters[1].Value = model.B_BusinessChance_check_checkType;
            parameters[2].Value = model.B_BusinessChance_check_Nature;
            parameters[3].Value = model.B_BusinessChance_check_category;
            parameters[4].Value = model.B_BusinessChance_check_confirmPerson;
            parameters[5].Value = model.B_BusinessChance_check_planStartTime;
            parameters[6].Value = model.B_BusinessChance_check_planEndTime;
            parameters[7].Value = model.B_BusinessChance_check_checkOpinion;
            parameters[8].Value = model.B_BusinessChance_check_checkPerson;
            parameters[9].Value = model.B_BusinessChance_check_checkTime;
            parameters[10].Value = model.B_BusinessChance_checkPersonType;
            parameters[11].Value = model.B_BusinessChance_check_BusinessChance_code;
            parameters[12].Value = model.B_BusinessChance_check_isChecked;
            parameters[13].Value = model.B_BusinessChance_check_creator;
            parameters[14].Value = model.B_BusinessChance_check_createTime;
            parameters[15].Value = model.B_BusinessChance_check_isDelete;

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
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_BusinessChance_check set ");        
            strSql.Append("B_BusinessChance_check_checkType=@B_BusinessChance_check_checkType,");
            strSql.Append("B_BusinessChance_check_Nature=@B_BusinessChance_check_Nature,");
            strSql.Append("B_BusinessChance_check_category=@B_BusinessChance_check_category,");
            strSql.Append("B_BusinessChance_check_confirmPerson=@B_BusinessChance_check_confirmPerson,");
            strSql.Append("B_BusinessChance_check_planStartTime=@B_BusinessChance_check_planStartTime,");
            strSql.Append("B_BusinessChance_check_planEndTime=@B_BusinessChance_check_planEndTime,");
            strSql.Append("B_BusinessChance_check_checkOpinion=@B_BusinessChance_check_checkOpinion,");
            strSql.Append("B_BusinessChance_check_checkPerson=@B_BusinessChance_check_checkPerson,");
            strSql.Append("B_BusinessChance_check_checkTime=@B_BusinessChance_check_checkTime,");
            strSql.Append("B_BusinessChance_checkPersonType=@B_BusinessChance_checkPersonType,");
            strSql.Append("B_BusinessChance_check_BusinessChance_code=@B_BusinessChance_check_BusinessChance_code,");
            strSql.Append("B_BusinessChance_check_isChecked=@B_BusinessChance_check_isChecked,");
            strSql.Append("B_BusinessChance_check_creator=@B_BusinessChance_check_creator,");
            strSql.Append("B_BusinessChance_check_createTime=@B_BusinessChance_check_createTime,");
            strSql.Append("B_BusinessChance_check_isDelete=@B_BusinessChance_check_isDelete");
            strSql.Append(" where B_BusinessChance_check_code=@B_BusinessChance_check_code ");
            SqlParameter[] parameters = {					
					new SqlParameter("@B_BusinessChance_check_checkType", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_Nature", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_category", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_confirmPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_planStartTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_check_planEndTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_check_checkOpinion", SqlDbType.NVarChar,500),
					new SqlParameter("@B_BusinessChance_check_checkPerson", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_checkTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_checkPersonType", SqlDbType.Int,4),
					new SqlParameter("@B_BusinessChance_check_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_isChecked", SqlDbType.Bit,1),
					new SqlParameter("@B_BusinessChance_check_creator", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_BusinessChance_check_createTime", SqlDbType.DateTime),
					new SqlParameter("@B_BusinessChance_check_isDelete", SqlDbType.Bit,1),
					new SqlParameter("@B_BusinessChance_check_code", SqlDbType.UniqueIdentifier,16)
            };
        
            parameters[0].Value = model.B_BusinessChance_check_checkType;
            parameters[1].Value = model.B_BusinessChance_check_Nature;
            parameters[2].Value = model.B_BusinessChance_check_category;
            parameters[3].Value = model.B_BusinessChance_check_confirmPerson;
            parameters[4].Value = model.B_BusinessChance_check_planStartTime;
            parameters[5].Value = model.B_BusinessChance_check_planEndTime;
            parameters[6].Value = model.B_BusinessChance_check_checkOpinion;
            parameters[7].Value = model.B_BusinessChance_check_checkPerson;
            parameters[8].Value = model.B_BusinessChance_check_checkTime;
            parameters[9].Value = model.B_BusinessChance_checkPersonType;
            parameters[10].Value = model.B_BusinessChance_check_BusinessChance_code;
            parameters[11].Value = model.B_BusinessChance_check_isChecked;
            parameters[12].Value = model.B_BusinessChance_check_creator;
            parameters[13].Value = model.B_BusinessChance_check_createTime;
            parameters[14].Value = model.B_BusinessChance_check_isDelete;
            parameters[15].Value = model.B_BusinessChance_check_code;

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
        public bool Delete(Guid B_BusinessChance_checkCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_BusinessChance_check set B_BusinessChance_check_isDelete=1 ");
            strSql.Append("where B_BusinessChance_check_code=@B_BusinessChance_check_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_checkCode;

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
        public bool DeleteList(string B_BusinessChance_check_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_BusinessChance_check ");
            strSql.Append(" where B_BusinessChance_check_id in (" + B_BusinessChance_check_idlist + ")  ");
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetModel(Guid B_BusinessChance_checkCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 B_BusinessChance_check_id,B_BusinessChance_check_code,B_BusinessChance_check_checkType,B_BusinessChance_check_Nature,B_BusinessChance_check_category,B_BusinessChance_check_confirmPerson,B_BusinessChance_check_planStartTime,B_BusinessChance_check_planEndTime,B_BusinessChance_check_checkOpinion,B_BusinessChance_check_checkPerson,B_BusinessChance_check_checkTime,B_BusinessChance_checkPersonType,B_BusinessChance_check_BusinessChance_code,B_BusinessChance_check_isChecked,B_BusinessChance_check_creator,B_BusinessChance_check_createTime,B_BusinessChance_check_isDelete from B_BusinessChance_check ");
            strSql.Append(" where B_BusinessChance_check_code=@B_BusinessChance_check_code");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_code", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = B_BusinessChance_checkCode;

            CommonService.Model.BusinessChanceManager.B_BusinessChance_check model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_check();
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
        /// 根据商机Guid，审查人员类型获取最近一条没有审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetUnCheckedChanceCheck(Guid businessChanceCode, int checkPersonType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 B_BusinessChance_check_id,B_BusinessChance_check_code,B_BusinessChance_check_checkType,B_BusinessChance_check_Nature,B_BusinessChance_check_category,B_BusinessChance_check_confirmPerson,B_BusinessChance_check_planStartTime,B_BusinessChance_check_planEndTime,B_BusinessChance_check_checkOpinion,B_BusinessChance_check_checkPerson,B_BusinessChance_check_checkTime,B_BusinessChance_checkPersonType,B_BusinessChance_check_BusinessChance_code,B_BusinessChance_check_isChecked,B_BusinessChance_check_creator,B_BusinessChance_check_createTime,B_BusinessChance_check_isDelete ");
            strSql.Append("from B_BusinessChance_check ");
            strSql.Append("where B_BusinessChance_check_BusinessChance_code=@B_BusinessChance_check_BusinessChance_code ");
            strSql.Append("and B_BusinessChance_checkPersonType=@B_BusinessChance_checkPersonType ");
            strSql.Append("and B_BusinessChance_check_isDelete=0 ");
            strSql.Append("and B_BusinessChance_check_isChecked=0 ");
            strSql.Append("order by B_BusinessChance_check_createTime Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_checkPersonType", SqlDbType.Int,4)
			};
            parameters[0].Value = businessChanceCode;
            parameters[1].Value = checkPersonType;

            CommonService.Model.BusinessChanceManager.B_BusinessChance_check model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_check();
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
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheck(Guid businessChanceCode, int checkPersonType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BCC.*,checkType.C_Parameters_name As B_BusinessChance_check_checkType_name,nature.C_Parameters_name As B_BusinessChance_check_Nature_name,");
            strSql.Append("checkPerson.C_Userinfo_name As B_BusinessChance_check_checkPerson_name ");
            strSql.Append("from B_BusinessChance_check As BCC with(nolock) ");
            strSql.Append("left join C_Parameters As checkType with(nolock) on BCC.B_BusinessChance_check_checkType=checkType.C_Parameters_id ");
            strSql.Append("left join C_Parameters As nature with(nolock) on BCC.B_BusinessChance_check_Nature=nature.C_Parameters_id ");
            strSql.Append("left join C_Userinfo As checkPerson on BCC.B_BusinessChance_check_checkPerson=checkPerson.C_Userinfo_code ");
            strSql.Append("where BCC.B_BusinessChance_check_BusinessChance_code=@B_BusinessChance_check_BusinessChance_code ");
            strSql.Append("and BCC.B_BusinessChance_checkPersonType=@B_BusinessChance_checkPersonType ");
            strSql.Append("and BCC.B_BusinessChance_check_isDelete=0 ");
            strSql.Append("and BCC.B_BusinessChance_check_isChecked=1 ");
            strSql.Append("order by B_BusinessChance_check_checkTime Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_BusinessChance_code", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@B_BusinessChance_checkPersonType", SqlDbType.Int,4)
			};
            parameters[0].Value = businessChanceCode;
            parameters[1].Value = checkPersonType;

            CommonService.Model.BusinessChanceManager.B_BusinessChance_check model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_check();
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
        /// 根据商机Guid获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>      
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheckByBusinessChance(Guid businessChanceCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BCC.*,checkType.C_Parameters_name As B_BusinessChance_check_checkType_name,nature.C_Parameters_name As B_BusinessChance_check_Nature_name,");
            strSql.Append("checkPerson.C_Userinfo_name As B_BusinessChance_check_checkPerson_name,confirmPerson.C_Userinfo_name As B_BusinessChance_check_confirmPerson_name ");
            strSql.Append("from B_BusinessChance_check As BCC with(nolock) ");
            strSql.Append("left join C_Parameters As checkType with(nolock) on BCC.B_BusinessChance_check_checkType=checkType.C_Parameters_id ");
            strSql.Append("left join C_Parameters As nature with(nolock) on BCC.B_BusinessChance_check_Nature=nature.C_Parameters_id ");
            strSql.Append("left join C_Userinfo As checkPerson on BCC.B_BusinessChance_check_checkPerson=checkPerson.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo As confirmPerson on BCC.B_BusinessChance_check_confirmPerson=confirmPerson.C_Userinfo_code ");
            strSql.Append("where BCC.B_BusinessChance_check_BusinessChance_code=@B_BusinessChance_check_BusinessChance_code ");            
            strSql.Append("and BCC.B_BusinessChance_check_isDelete=0 ");
            strSql.Append("and BCC.B_BusinessChance_check_isChecked=1 ");
            strSql.Append("order by B_BusinessChance_check_checkTime Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_BusinessChance_code", SqlDbType.UniqueIdentifier,16)                     
			};
            parameters[0].Value = businessChanceCode;
           
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_check();
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
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check DataRowToModel(DataRow row)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_check();
            if (row != null)
            {
                if (row["B_BusinessChance_check_id"] != null && row["B_BusinessChance_check_id"].ToString() != "")
                {
                    model.B_BusinessChance_check_id = int.Parse(row["B_BusinessChance_check_id"].ToString());
                }
                if (row["B_BusinessChance_check_code"] != null && row["B_BusinessChance_check_code"].ToString() != "")
                {
                    model.B_BusinessChance_check_code = new Guid(row["B_BusinessChance_check_code"].ToString());
                }
                if (row["B_BusinessChance_check_checkType"] != null && row["B_BusinessChance_check_checkType"].ToString() != "")
                {
                    model.B_BusinessChance_check_checkType = int.Parse(row["B_BusinessChance_check_checkType"].ToString());
                }
                //审查类型名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_BusinessChance_check_checkType_name"))
                {
                    if (row["B_BusinessChance_check_checkType_name"] != null)
                    {
                        model.B_BusinessChance_check_checkType_name = row["B_BusinessChance_check_checkType_name"].ToString();
                    }
                }
                if (row["B_BusinessChance_check_Nature"] != null && row["B_BusinessChance_check_Nature"].ToString() != "")
                {
                    model.B_BusinessChance_check_Nature = int.Parse(row["B_BusinessChance_check_Nature"].ToString());
                }
                //案件性质名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_BusinessChance_check_Nature_name"))
                {
                    if (row["B_BusinessChance_check_Nature_name"] != null)
                    {
                        model.B_BusinessChance_check_Nature_name = row["B_BusinessChance_check_Nature_name"].ToString();
                    }
                }
                if (row["B_BusinessChance_check_category"] != null && row["B_BusinessChance_check_category"].ToString() != "")
                {
                    model.B_BusinessChance_check_category = int.Parse(row["B_BusinessChance_check_category"].ToString());
                }
                if (row["B_BusinessChance_check_confirmPerson"] != null && row["B_BusinessChance_check_confirmPerson"].ToString() != "")
                {
                    model.B_BusinessChance_check_confirmPerson = new Guid(row["B_BusinessChance_check_confirmPerson"].ToString());
                }
                //确认部长名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_BusinessChance_check_confirmPerson_name"))
                {
                    if (row["B_BusinessChance_check_confirmPerson_name"] != null)
                    {
                        model.B_BusinessChance_check_confirmPerson_name = row["B_BusinessChance_check_confirmPerson_name"].ToString();
                    }
                }
                if (row["B_BusinessChance_check_planStartTime"] != null && row["B_BusinessChance_check_planStartTime"].ToString() != "")
                {
                    model.B_BusinessChance_check_planStartTime = DateTime.Parse(row["B_BusinessChance_check_planStartTime"].ToString());
                }
                if (row["B_BusinessChance_check_planEndTime"] != null && row["B_BusinessChance_check_planEndTime"].ToString() != "")
                {
                    model.B_BusinessChance_check_planEndTime = DateTime.Parse(row["B_BusinessChance_check_planEndTime"].ToString());
                }
                if (row["B_BusinessChance_check_checkOpinion"] != null)
                {
                    model.B_BusinessChance_check_checkOpinion = row["B_BusinessChance_check_checkOpinion"].ToString();
                }
                if (row["B_BusinessChance_check_checkPerson"] != null && row["B_BusinessChance_check_checkPerson"].ToString() != "")
                {
                    model.B_BusinessChance_check_checkPerson = new Guid(row["B_BusinessChance_check_checkPerson"].ToString());
                }
                //审查人员名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("B_BusinessChance_check_checkPerson_name"))
                {
                    if (row["B_BusinessChance_check_checkPerson_name"] != null)
                    {
                        model.B_BusinessChance_check_checkPerson_name = row["B_BusinessChance_check_checkPerson_name"].ToString();
                    }
                }
                if (row["B_BusinessChance_check_checkTime"] != null && row["B_BusinessChance_check_checkTime"].ToString() != "")
                {
                    model.B_BusinessChance_check_checkTime = DateTime.Parse(row["B_BusinessChance_check_checkTime"].ToString());
                }
                if (row["B_BusinessChance_checkPersonType"] != null && row["B_BusinessChance_checkPersonType"].ToString() != "")
                {
                    model.B_BusinessChance_checkPersonType = int.Parse(row["B_BusinessChance_checkPersonType"].ToString());
                }
                if (row["B_BusinessChance_check_BusinessChance_code"] != null && row["B_BusinessChance_check_BusinessChance_code"].ToString() != "")
                {
                    model.B_BusinessChance_check_BusinessChance_code = new Guid(row["B_BusinessChance_check_BusinessChance_code"].ToString());
                }
                if (row["B_BusinessChance_check_isChecked"] != null && row["B_BusinessChance_check_isChecked"].ToString() != "")
                {
                    if ((row["B_BusinessChance_check_isChecked"].ToString() == "1") || (row["B_BusinessChance_check_isChecked"].ToString().ToLower() == "true"))
                    {
                        model.B_BusinessChance_check_isChecked = true;
                    }
                    else
                    {
                        model.B_BusinessChance_check_isChecked = false;
                    }
                }
                if (row["B_BusinessChance_check_creator"] != null && row["B_BusinessChance_check_creator"].ToString() != "")
                {
                    model.B_BusinessChance_check_creator = new Guid(row["B_BusinessChance_check_creator"].ToString());
                }
                if (row["B_BusinessChance_check_createTime"] != null && row["B_BusinessChance_check_createTime"].ToString() != "")
                {
                    model.B_BusinessChance_check_createTime = DateTime.Parse(row["B_BusinessChance_check_createTime"].ToString());
                }
                if (row["B_BusinessChance_check_isDelete"] != null && row["B_BusinessChance_check_isDelete"].ToString() != "")
                {
                    if ((row["B_BusinessChance_check_isDelete"].ToString() == "1") || (row["B_BusinessChance_check_isDelete"].ToString().ToLower() == "true"))
                    {
                        model.B_BusinessChance_check_isDelete = true;
                    }
                    else
                    {
                        model.B_BusinessChance_check_isDelete = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 根据商机Guid，获取全部已审查记录
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        public DataSet GetChekedBusinessChanceChecks(Guid businessChanceCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BCC.*,checkType.C_Parameters_name As B_BusinessChance_check_checkType_name,nature.C_Parameters_name As B_BusinessChance_check_Nature_name,");
            strSql.Append("checkPerson.C_Userinfo_name As B_BusinessChance_check_checkPerson_name,confirmPerson.C_Userinfo_name As B_BusinessChance_check_confirmPerson_name ");
            strSql.Append("from B_BusinessChance_check As BCC with(nolock) ");
            strSql.Append("left join C_Parameters As checkType with(nolock) on BCC.B_BusinessChance_check_checkType=checkType.C_Parameters_id ");
            strSql.Append("left join C_Parameters As nature with(nolock) on BCC.B_BusinessChance_check_Nature=nature.C_Parameters_id ");
            strSql.Append("left join C_Userinfo As checkPerson on BCC.B_BusinessChance_check_checkPerson=checkPerson.C_Userinfo_code ");
            strSql.Append("left join C_Userinfo As confirmPerson on BCC.B_BusinessChance_check_confirmPerson=confirmPerson.C_Userinfo_code ");
            strSql.Append("where BCC.B_BusinessChance_check_BusinessChance_code=@B_BusinessChance_check_BusinessChance_code ");
            strSql.Append("and BCC.B_BusinessChance_check_isDelete=0 ");
            strSql.Append("and BCC.B_BusinessChance_check_isChecked=1 ");
            strSql.Append("order by B_BusinessChance_check_checkTime Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_BusinessChance_check_BusinessChance_code", SqlDbType.UniqueIdentifier,16)                     
			};
            parameters[0].Value = businessChanceCode;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select B_BusinessChance_check_id,B_BusinessChance_check_code,B_BusinessChance_check_checkType,B_BusinessChance_check_Nature,B_BusinessChance_check_category,B_BusinessChance_check_confirmPerson,B_BusinessChance_check_planStartTime,B_BusinessChance_check_planEndTime,B_BusinessChance_check_checkOpinion,B_BusinessChance_check_checkPerson,B_BusinessChance_check_checkTime,B_BusinessChance_checkPersonType,B_BusinessChance_check_BusinessChance_code,B_BusinessChance_check_isChecked,B_BusinessChance_check_creator,B_BusinessChance_check_createTime,B_BusinessChance_check_isDelete ");
            strSql.Append(" FROM B_BusinessChance_check ");
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
            strSql.Append(" B_BusinessChance_check_id,B_BusinessChance_check_code,B_BusinessChance_check_checkType,B_BusinessChance_check_Nature,B_BusinessChance_check_category,B_BusinessChance_check_confirmPerson,B_BusinessChance_check_planStartTime,B_BusinessChance_check_planEndTime,B_BusinessChance_check_checkOpinion,B_BusinessChance_check_checkPerson,B_BusinessChance_check_checkTime,B_BusinessChance_checkPersonType,B_BusinessChance_check_BusinessChance_code,B_BusinessChance_check_isChecked,B_BusinessChance_check_creator,B_BusinessChance_check_createTime,B_BusinessChance_check_isDelete ");
            strSql.Append(" FROM B_BusinessChance_check ");
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
            strSql.Append("select count(1) FROM B_BusinessChance_check ");
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
                strSql.Append("order by T.B_BusinessChance_check_id desc");
            }
            strSql.Append(")AS Row, T.*  from B_BusinessChance_check T ");
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
            parameters[0].Value = "B_BusinessChance_check";
            parameters[1].Value = "B_BusinessChance_check_id";
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
