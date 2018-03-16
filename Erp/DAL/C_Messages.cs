using cn.jpush.api;
using CommonService.Common;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CommonService.DAL
{
    /// <summary>
    /// 数据访问类:C_Messages 消息表
    /// 作者：陈永俊
    /// 时间：2015年6月8日16:37:26
    /// </summary>
    public partial class C_Messages
    {
        public C_Messages()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_Messages_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from C_Messages");
            strSql.Append(" where C_Messages_id=@C_Messages_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Messages_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据关联guid和用户guid查看是否存在该记录
        /// </summary>
        public bool ExistsBylinkCodeAnduserCode(Guid linkCode, Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from C_Messages");
            strSql.Append(" where C_Messages_link=@C_Messages_link and C_Messages_person=@C_Messages_person");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = linkCode;
            parameters[1].Value = userCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Messages model)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into C_Messages(");
            strSql.Append("C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate)");
            strSql.Append(" values (");
            strSql.Append("@C_Messages_fType,@C_Messages_type,@C_Messages_link,@C_Messages_createTime,@C_Messages_person,@C_Messages_isRead,@C_Messages_content,@C_Messages_isValidate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_fType", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_type", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_isRead", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_content", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Messages_isValidate", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Messages_fType;
            parameters[1].Value = model.C_Messages_type;
            parameters[2].Value = model.C_Messages_link;
            parameters[3].Value = model.C_Messages_createTime;
            parameters[4].Value = model.C_Messages_person;
            parameters[5].Value = model.C_Messages_isRead;
            parameters[6].Value = model.C_Messages_content;
            parameters[7].Value = model.C_Messages_isValidate;
            

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                //消息推送线程逻辑
                model._c_messages_id = Convert.ToInt32(obj);
                if (model._c_messages_ftype == 426 || model._c_messages_ftype == 509 || model._c_messages_ftype == 765 || model._c_messages_ftype == 810)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(PushMessage));
                    t.Start(model);
                }
                return Convert.ToInt32(obj);
            }
        }

        public void PushMessage(object m)
        {
            CommonService.Model.C_Messages model = (CommonService.Model.C_Messages)m;
            //推送app消息逻辑
            C_Parameters cp = new C_Parameters();
            string bigname = cp.GetModel(model.C_Messages_fType.Value).C_Parameters_name;
            string smallname = cp.GetModel(model.C_Messages_type.Value).C_Parameters_name;
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //string json = jss.Serialize(model);
            JPushClient jc = new JPushClient();
            jc.PushObject_android_and_ios(model.C_Messages_person.ToString().Replace('-', '_'), "您的" + bigname + "中，有一条新的" + smallname + ",请及时查看！", "message", model._c_messages_id.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Messages set ");
            strSql.Append("C_Messages_fType=@C_Messages_fType,");
            strSql.Append("C_Messages_type=@C_Messages_type,");
            strSql.Append("C_Messages_link=@C_Messages_link,");
            strSql.Append("C_Messages_createTime=@C_Messages_createTime,");
            strSql.Append("C_Messages_person=@C_Messages_person,");
            strSql.Append("C_Messages_isRead=@C_Messages_isRead,");
            strSql.Append("C_Messages_content=@C_Messages_content,");
            strSql.Append("C_Messages_isValidate=@C_Messages_isValidate");
            strSql.Append(" where C_Messages_id=@C_Messages_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_fType", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_type", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_createTime", SqlDbType.DateTime),
					new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@C_Messages_isRead", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_content", SqlDbType.NVarChar,500),
					new SqlParameter("@C_Messages_isValidate", SqlDbType.Int,4),
					new SqlParameter("@C_Messages_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_Messages_fType;
            parameters[1].Value = model.C_Messages_type;
            parameters[2].Value = model.C_Messages_link;
            parameters[3].Value = model.C_Messages_createTime;
            parameters[4].Value = model.C_Messages_person;
            parameters[5].Value = model.C_Messages_isRead;
            parameters[6].Value = model.C_Messages_content;
            parameters[7].Value = model.C_Messages_isValidate;
            parameters[8].Value = model.C_Messages_id;

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
        public bool Delete(int C_Messages_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Messages ");
            strSql.Append(" where C_Messages_id=@C_Messages_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Messages_id;

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
        public bool DeleteByLink(Guid C_Messages_link)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Messages ");
            strSql.Append(" where C_Messages_link=@C_Messages_link");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Messages_link;

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
        /// 根据消息大类，消息小类，内容Id删除一条数据(这里采用物理删除，这个方法目前主要针对稽查)
        /// </summary>
        public bool DeleteByTypeContent(int messagesBigType, int messagesSmallType, string contentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Messages ");
            strSql.Append("where C_Messages_fType=@C_Messages_fType and C_Messages_type=@C_Messages_type and C_Messages_content=@C_Messages_content ");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_fType", SqlDbType.Int),
                    new SqlParameter("@C_Messages_type", SqlDbType.Int),
                    new SqlParameter("@C_Messages_content", SqlDbType.VarChar,50)
			};
            parameters[0].Value = messagesBigType;
            parameters[1].Value = messagesSmallType;
            parameters[2].Value = contentId;

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
        /// 读消息
        /// </summary>
        /// <param name="messageId">消息Id</param>
        /// <returns></returns>
        public bool ReadMessage(int messageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Messages set C_Messages_isRead=1 ");
            strSql.Append(" where C_Messages_id=@C_Messages_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_id", SqlDbType.Int,4)
			};
            parameters[0].Value = messageId;

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
        public bool DeleteList(string C_Messages_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from C_Messages ");
            strSql.Append(" where C_Messages_id in (" + C_Messages_idlist + ")  ");
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
        public CommonService.Model.C_Messages GetModel(int C_Messages_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Messages_id,C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate from C_Messages ");
            strSql.Append(" where C_Messages_id=@C_Messages_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_id", SqlDbType.Int,4)
			};
            parameters[0].Value = C_Messages_id;

            CommonService.Model.C_Messages model = new CommonService.Model.C_Messages();
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
        /// 根据关联GUID得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModelByLinkCode(Guid C_Messages_link)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Messages_id,C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate from C_Messages ");
            strSql.Append(" where C_Messages_link=@C_Messages_link");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Messages_link;

            CommonService.Model.C_Messages model = new CommonService.Model.C_Messages();
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
        /// 根据关联GUID和消息接收人guid得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Messages GetModelByLinkCodeUserCodeModel(Guid C_Messages_link, Guid userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_Messages_id,C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate from C_Messages ");
            strSql.Append(" where C_Messages_link=@C_Messages_link and C_Messages_person=@C_Messages_person and C_Messages_isRead=0");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16)
			};
            parameters[0].Value = C_Messages_link;
            parameters[1].Value = userCode;
            CommonService.Model.C_Messages model = new CommonService.Model.C_Messages();
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
        public CommonService.Model.C_Messages DataRowToModel(DataRow row)
        {
            CommonService.Model.C_Messages model = new CommonService.Model.C_Messages();
            if (row != null)
            {
                //虚拟字段是否存于表中
                if (row.Table.Columns.Contains("C_Messages_link_2"))
                {
                    if (row["C_Messages_link_2"] != null && row["C_Messages_link_2"].ToString() != "")
                    {
                        model.C_Messages_link_2 = row["C_Messages_link_2"].ToString();
                    }
                }
                if (row["C_Messages_id"] != null && row["C_Messages_id"].ToString() != "")
                {
                    model.C_Messages_id = int.Parse(row["C_Messages_id"].ToString());
                }
                if (row["C_Messages_fType"] != null && row["C_Messages_fType"].ToString() != "")
                {
                    model.C_Messages_fType = int.Parse(row["C_Messages_fType"].ToString());
                }
                if (row["C_Messages_type"] != null && row["C_Messages_type"].ToString() != "")
                {
                    model.C_Messages_type = int.Parse(row["C_Messages_type"].ToString());
                }
                if (row["C_Messages_link"] != null && row["C_Messages_link"].ToString() != "")
                {
                    model.C_Messages_link = new Guid(row["C_Messages_link"].ToString());
                }
                if (row["C_Messages_createTime"] != null && row["C_Messages_createTime"].ToString() != "")
                {
                    model.C_Messages_createTime = DateTime.Parse(row["C_Messages_createTime"].ToString());
                }
                if (row["C_Messages_person"] != null && row["C_Messages_person"].ToString() != "")
                {
                    model.C_Messages_person = new Guid(row["C_Messages_person"].ToString());
                }
                if (row["C_Messages_isRead"] != null && row["C_Messages_isRead"].ToString() != "")
                {
                    model.C_Messages_isRead = int.Parse(row["C_Messages_isRead"].ToString());
                }
                if (row["C_Messages_content"] != null)
                {
                    model.C_Messages_content = row["C_Messages_content"].ToString();
                }
                if (row["C_Messages_isValidate"] != null && row["C_Messages_isValidate"].ToString() != "")
                {
                    model.C_Messages_isValidate = int.Parse(row["C_Messages_isValidate"].ToString());
                }
                //消息小类名称(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Messages_type_name"))
                {
                    if (row["C_Messages_type_name"] != null)
                    {
                        model.C_Messages_type_name = row["C_Messages_type_name"].ToString();
                    }
                }
                //消息分类类型(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Messages_Category_type"))
                {
                    model.C_Messages_Category_type = int.Parse(row["C_Messages_Category_type"].ToString());
                }

                //消息分类类型(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Messages_code"))
                {
                    model.C_Messages_code = row["C_Messages_code"].ToString();
                }

                //关联业务标识(虚拟属性)是否存在于列集合中
                if (row.Table.Columns.Contains("C_Messages_relationBusiness"))
                {
                    model.C_Messages_relationBusiness = row["C_Messages_relationBusiness"].ToString();
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
            strSql.Append("select C_Messages_id,C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate ");
            strSql.Append(" FROM C_Messages ");
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
            strSql.Append(" C_Messages_id,C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate ");
            strSql.Append(" FROM C_Messages ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据消息模型条件，获取所有消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>         
        public int GetAllMessageCount(CommonService.Model.C_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Messages With(nolock) ");
            strSql.Append(" where 1=1 ");
            if (model != null)
            {
                if (model.C_Messages_person != null)
                {
                    strSql.Append("and C_Messages_person=@C_Messages_person ");
                }
                if (model.C_Messages_isRead != null)
                {
                    strSql.Append(" and C_Messages_isRead=@C_Messages_isRead ");
                }
            }
            SqlParameter[] parameters = { 
					new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Messages_isRead", SqlDbType.Int,4)
		    };
            parameters[0].Value = model.C_Messages_person;
            parameters[1].Value = model.C_Messages_isRead; 

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
        /// 根据消息模型条件，获取所有ERP消息数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>        
        public int GetAllERPMessageCount(CommonService.Model.C_Messages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Messages With(nolock) ");
            strSql.Append(" where 1=1 and (C_Messages_fType=426 or C_Messages_fType=427 or C_Messages_fType=428 or C_Messages_fType=765 or C_Messages_fType=810) ");
            if (model != null)
            {
                if (model.C_Messages_person != null)
                {
                    strSql.Append("and C_Messages_person=@C_Messages_person ");
                }
                if (model.C_Messages_isRead != null)
                {
                    strSql.Append(" and C_Messages_isRead=@C_Messages_isRead ");
                }
            }
            SqlParameter[] parameters = { 
					new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@C_Messages_isRead", SqlDbType.Int,4)
		    };
            parameters[0].Value = model.C_Messages_person;
            parameters[1].Value = model.C_Messages_isRead;

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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(CommonService.Model.C_Messages model)
        {             
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM C_Messages With(nolock) ");
            strSql.Append("where C_Messages_isValidate=1 ");
            if (model != null)
            {
                if (model.C_Messages_isRead != null)
                {
                    strSql.Append(" and C_Messages_isRead=@C_Messages_isRead ");
                }
                if (model.C_Messages_fType != null)
                {
                    strSql.Append("and C_Messages_fType=@C_Messages_fType ");
                }        
                if (model.C_Messages_person != null)
                {
                    strSql.Append("and C_Messages_person=@C_Messages_person ");
                }
                if (model.C_Messages_Category_type != null)
                {
                    strSql.Append(" and exists(");
                    strSql.Append("select 1 from C_Messages_Category AS MC with(nolock) ");
                    strSql.Append("where MC.C_Messages_Category_isDelete=0 and MC.C_Messages_Category_isLeaf=1 ");
                    strSql.Append("and MC.C_Messages_Category_type=@messageCategoryType ");
                    strSql.Append("and MC.C_Messages_Category_bigClass=C_Messages_fType and MC.C_Messages_Category_smallClass=C_Messages_type");
                    strSql.Append(") ");
                }
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Messages_isRead", SqlDbType.Bit,1),   
					new SqlParameter("@C_Messages_fType", SqlDbType.Int,4),  
                    new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@messageCategoryType", SqlDbType.Int,4)              
				};
 
            parameters[0].Value = model.C_Messages_isRead;
            parameters[1].Value = model.C_Messages_fType;
            parameters[2].Value = model.C_Messages_person; 
            parameters[3].Value = model.C_Messages_Category_type;
 
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
        public DataSet GetListByPage(Model.C_Messages message, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.C_Messages_id desc");
            }
            if (message.C_Messages_fType == null)
            {
                strSql.Append(")AS Row, T.*,P.C_Parameters_name As C_Messages_type_name from C_Messages T with(nolock) ");
                strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
            }
            else
            {
                if (message.C_Messages_fType == Convert.ToInt32(MessageBigTypeEnum.案件))
                {//如果消息为大类时，消息内容用案件名称代替
                    strSql.Append(")AS Row, T.C_Messages_id,T.C_Messages_fType,T.C_Messages_type,T.C_Messages_link,T.C_Messages_createTime,T.C_Messages_person,T.C_Messages_isRead,T.C_Messages_isValidate,T.C_Messages_content as C_Messages_link_2 ,");
                    strSql.Append("BC.B_case_name As C_Messages_content,BC.B_Case_number As C_Messages_code,P.C_Parameters_name As C_Messages_type_name ");
                    strSql.Append("from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                    strSql.Append("left join B_Case As BC WITH(NOLOCK) on T.C_Messages_link=BC.B_Case_code ");
                }
                else if (message.C_Messages_fType == Convert.ToInt32(MessageBigTypeEnum.商机))
                {//如果消息为大类时，消息内容用商机名称代替
                    strSql.Append(")AS Row, T.C_Messages_id,T.C_Messages_fType,T.C_Messages_type,T.C_Messages_link,T.C_Messages_createTime,T.C_Messages_person,T.C_Messages_isRead,T.C_Messages_isValidate,");
                    strSql.Append("BC.B_BusinessChance_name As C_Messages_content,BC.B_BusinessChance_code As C_Messages_code,P.C_Parameters_name As C_Messages_type_name ");
                    strSql.Append("from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                    strSql.Append("left join B_BusinessChance As BC WITH(NOLOCK) on T.C_Messages_link=BC.B_BusinessChance_code ");
                }
                else if (message.C_Messages_fType == Convert.ToInt32(MessageBigTypeEnum.日程))
                {
                    strSql.Append(")AS Row, T.C_Messages_id,T.C_Messages_fType,T.C_Messages_type,T.C_Messages_link,T.C_Messages_createTime,T.C_Messages_person,T.C_Messages_isRead,T.C_Messages_isValidate,");
                    strSql.Append("OS.O_Schedule_title As C_Messages_content,P.C_Parameters_name As C_Messages_type_name ");
                    strSql.Append("from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                    strSql.Append("left join O_Schedule As OS WITH(NOLOCK) on T.C_Messages_link=OS.O_Schedule_code ");
                }
                else if (message.C_Messages_fType == Convert.ToInt32(MessageBigTypeEnum.进程管理))
                {
                    strSql.Append(")AS Row, T.C_Messages_id,T.C_Messages_fType,T.C_Messages_type,T.C_Messages_link,T.C_Messages_createTime,T.C_Messages_person,T.C_Messages_isRead,T.C_Messages_isValidate,T.C_Messages_content as C_Messages_link_2 ,T.C_Messages_content as C_Messages_relationBusiness,");
                    strSql.Append("BC.B_case_name As C_Messages_content,BC.B_Case_number As C_Messages_code,P.C_Parameters_name As C_Messages_type_name ");
                    strSql.Append("from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                    strSql.Append("left join B_Case As BC WITH(NOLOCK) on T.C_Messages_link=BC.B_Case_code ");
                }
                else if (message.C_Messages_fType == Convert.ToInt32(MessageBigTypeEnum.财务消息))
                {//如果消息为大类时，消息内容用案件名称代替
                    strSql.Append(")AS Row, T.C_Messages_id,T.C_Messages_fType,T.C_Messages_type,T.C_Messages_link,T.C_Messages_createTime,T.C_Messages_person,T.C_Messages_isRead,T.C_Messages_isValidate,T.C_Messages_content as C_Messages_link_2 ,");
                    strSql.Append("dbo.getBusinessNameByBusinessFlowFormCode(BFF.P_Business_flow_form_code) As C_Messages_content,(select B_Case_number from B_Case where B_Case_code=(select P_FK_Code from P_Business_flow where P_Business_flow_code=(select P_Business_flow_code from P_Business_flow_form where P_Business_flow_form_code=T.C_Messages_link))) as C_Messages_code,P.C_Parameters_name As C_Messages_type_name ");
                    strSql.Append("from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                    strSql.Append("left join P_Business_flow_form As BFF WITH(NOLOCK) on T.C_Messages_link=BFF.P_Business_flow_form_code ");                  
                }
                else if (message.C_Messages_fType == Convert.ToInt32(MessageBigTypeEnum.客户))
                {//如果消息为大类时，消息内容用客户名称代替
                    strSql.Append(")AS Row, T.C_Messages_id,T.C_Messages_fType,T.C_Messages_type,T.C_Messages_link,T.C_Messages_createTime,T.C_Messages_person,T.C_Messages_isRead,T.C_Messages_isValidate,");
                    strSql.Append("C.C_Customer_name As C_Messages_content,P.C_Parameters_name As C_Messages_type_name ");
                    strSql.Append("from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                    strSql.Append("left join C_Customer As C WITH(NOLOCK) on T.C_Messages_link=C.C_Customer_code ");
                }
                else
                {
                    strSql.Append(")AS Row, T.*,P.C_Parameters_name As C_Messages_type_name from C_Messages T with(nolock) ");
                    strSql.Append("left join C_Parameters AS P WITH(NOLOCK) on T.C_Messages_type = P.C_Parameters_id ");
                }
            }

            strSql.Append(" where C_Messages_isValidate=1 ");
            if (message != null)
            {
                if (message.C_Messages_isRead != null)
                {
                    strSql.Append(" and C_Messages_isRead=@C_Messages_isRead ");
                }
                if (message.C_Messages_fType != null)
                {
                    strSql.Append("and C_Messages_fType=@C_Messages_fType ");
                }
                if (message.C_Messages_person != null)
                {
                    strSql.Append("and C_Messages_person=@C_Messages_person ");
                }
                if (message.C_Messages_Category_type != null)
                {
                    strSql.Append(" and exists(");
                    strSql.Append("select 1 from C_Messages_Category AS MC with(nolock) ");
                    strSql.Append("where MC.C_Messages_Category_isDelete=0 and MC.C_Messages_Category_isLeaf=1 ");
                    strSql.Append("and MC.C_Messages_Category_type=@messageCategoryType ");
                    strSql.Append("and MC.C_Messages_Category_bigClass=C_Messages_fType and MC.C_Messages_Category_smallClass=C_Messages_type");
                    strSql.Append(") ");
                }
            }
            strSql.Append(" ) TT ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters ={
                    new SqlParameter("@C_Messages_isRead", SqlDbType.Bit,1),   
					new SqlParameter("@C_Messages_fType", SqlDbType.Int,4),  
                    new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@messageCategoryType", SqlDbType.Int,4)   
                                       };

            parameters[0].Value = message.C_Messages_isRead;
            parameters[1].Value = message.C_Messages_fType;
            parameters[2].Value = message.C_Messages_person;
            parameters[3].Value = message.C_Messages_Category_type;
       
   
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
            parameters[0].Value = "C_Messages";
            parameters[1].Value = "C_Messages_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        /// <summary>
        /// 根据外键guid和用户guid获得未读取的日程信息数据列表
        /// </summary>
        public DataSet GetListByLinkcodeAndUsercode(Guid? linkCode, Guid? userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_Messages_id,C_Messages_fType,C_Messages_type,C_Messages_link,C_Messages_createTime,C_Messages_person,C_Messages_isRead,C_Messages_content,C_Messages_isValidate ");
            strSql.Append(" FROM C_Messages ");
            strSql.Append(" where 1=1 and C_Messages_isRead=0 and C_Messages_type=510 ");
            if (linkCode != null && linkCode.ToString() != "")
            {
                strSql.Append(" and C_Messages_link=@C_Messages_link ");
            }
            if (userCode != null && userCode.ToString() != "")
            {
                strSql.Append(" and C_Messages_person=@C_Messages_person ");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@C_Messages_link", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@C_Messages_person", SqlDbType.UniqueIdentifier, 16)
                    };
            parameters[0].Value = linkCode;
            parameters[1].Value = userCode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        #region App专用

        /// <summary>
        /// 根据消息大类型，获取所有消息及子级的未读消息数量和
        /// </summary>
        /// <param name="type">消息大类型</param>
        /// <param name="guid">用户GUID</param>
        /// <returns>消息数量和</returns>
        public int GetCountByParentID(int type, Guid? guid)
        {
            string sql = "select count(1) from C_Messages where C_Messages_isRead=0 and C_Messages_fType=@type";
            if (guid != null)
            {
                sql += " and C_Messages_person=@guid";
            }

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = type;
            para[1].Value = guid;

            object obj = DbHelperSQL.GetSingle(sql, para);
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
        /// 根据消息小类型，获取所有消息及子级的未读消息数量和
        /// </summary>
        /// <param name="type">消息小类型</param>
        /// <param name="guid">用户GUID</param>
        /// <returns>消息数量和</returns>
        public int GetSCountByParentID(int type, Guid? guid)
        {
            string sql = "select count(1) from C_Messages where C_Messages_isRead=0 and C_Messages_type=@type";
            if (guid != null)
            {
                sql += " and C_Messages_person=@guid";
            }

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@guid",SqlDbType.UniqueIdentifier,16)
            };
            para[0].Value = type;
            para[1].Value = guid;

            object obj = DbHelperSQL.GetSingle(sql, para);
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
        /// 将未读消息改为已读
        /// </summary>
        /// <param name="messageID">消息ID</param>
        /// <returns>是否成功</returns>
        public int AppUpdateMessagesIsRead(int messageID)
        {
            string sql = "update C_Messages set C_Messages_isRead=1 where C_Messages_id=@messageID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@messageID",SqlDbType.Int)
            };
            para[0].Value = messageID;
            object obj = DbHelperSQL.GetSingle(sql, para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion
    }
}
