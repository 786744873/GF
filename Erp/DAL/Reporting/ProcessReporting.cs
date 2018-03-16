using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DAL.Reporting
{
    /// <summary>
    /// 进程管理统计报表
    /// 作者：张东洋
    /// 日期：2015-11-30
    /// </summary>
    public partial class ProcessReporting
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Reporting.ProcessReporting DataRowToModel(DataRow row)
        {
            Model.Reporting.ProcessReporting model = new Model.Reporting.ProcessReporting();
            if (row != null)
            {
                if (row["区域"] != null)
                {
                    model.区域 = row["区域"].ToString();
                }
                if (row.Table.Columns.Contains("律师"))
                {
                    if (row["律师"] != null)
                    {
                        model.律师 = row["律师"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("营销部门"))
                {
                    if (row["营销部门"] != null)
                    {
                        model.营销部门 = row["营销部门"].ToString();
                    }
                }
                if (row["监控项"] != null)
                {
                    model.监控项 = row["监控项"].ToString();
                }
                if (row["应完成数"] != null)
                {
                    model.应完成数 = row["应完成数"].ToString();
                }
                if (row["实际完成数"] != null)
                {
                    model.实际完成数 = row["实际完成数"].ToString();
                }
                if (row["完成率"] != null)
                {
                    model.完成率 = row["完成率"].ToString() == "" ? "" : Convert.ToDecimal(row["完成率"].ToString()).ToString("0.00") + "%";
                }
                if (row["超期数"] != null)
                {
                    model.超期数 = row["超期数"].ToString();
                }
                if (row["超期率"] != null)
                {
                    model.超期率 = row["超期率"].ToString() == "" ? "" : Convert.ToDecimal(row["超期率"].ToString()).ToString("0.00") + "%";
                }
                if (row["延期数"] != null)
                {
                    model.延期数 = row["延期数"].ToString();
                }
                if (row["延期率"] != null)
                {
                    model.延期率 = row["延期率"].ToString() == "" ? "" : Convert.ToDecimal(row["延期率"].ToString()).ToString("0.00") + "%";
                }
                if (row["平均超期时长"] != null)
                {
                    model.平均超期时长 = row["平均超期时长"].ToString();
                }
                if (row["平均延期时长"] != null)
                {
                    model.平均延期时长 = row["平均延期时长"].ToString();
                }
                if (row["超期预期收益"] != null)
                {
                    model.超期预期收益 = row["超期预期收益"].ToString();
                }
                if (row["超期预期收益"] != null)
                {
                    model.超期预期收益 = row["超期预期收益"].ToString();
                }
                if (row["超期移交标的"] != null)
                {
                    model.超期移交标的 = row["超期移交标的"].ToString();
                }
                if (row["延期预期收益"] != null)
                {
                    model.延期预期收益 = row["延期预期收益"].ToString();
                }
                if (row["延期移交标的"] != null)
                {
                    model.延期移交标的 = row["延期移交标的"].ToString();
                }
                if (row["实际预期收益"] != null)
                {
                    model.实际预期收益 = row["实际预期收益"].ToString();
                }
                if (row["实际移交标的"] != null)
                {
                    model.实际移交标的 = row["实际移交标的"].ToString();
                }
                if (row["Query_area"] != null && row["Query_area"].ToString() != "")
                {
                    model.Query_area = row["Query_area"].ToString();
                }
                if (row.Table.Columns.Contains("Query_laywerCode"))
                {
                    if (row["Query_laywerCode"] != null)
                    {
                        model.Query_laywerCode = row["Query_laywerCode"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("Query_department"))
                {
                    if (row["Query_department"] != null)
                    {
                        model.Query_department = row["Query_department"].ToString();
                    }
                }
                if (row["Query_entry"] != null)
                {
                    model.Query_entry = row["Query_entry"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获取统计报表总数
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="type">类型：1 根据区域统计  2 根据区域、律师统计</param>
        /// <returns>数量</returns>
        public int GetProcessReportingCount(Model.Reporting.ProcessReporting model, int startIndex, int endIndex, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(tt.cc) from (");
            strSql.Append("select 1 as cc ");
            strSql.Append(" from M_Entry_Statistics a  ");
            strSql.Append("left join B_Case bcase on bcase.B_Case_code=a.M_Case_code ");
            strSql.Append("right join M_Entry mentry on a.M_Entry_code=mentry.M_Entry_code and mentry.M_Entry_parent is null and mentry.M_Entry_isDelete=0  ");
            strSql.Append("left join B_Case_link bcl on bcl.B_Case_code=a.M_Case_code and bcl.B_Case_link_type=6 and bcl.B_Case_link_isDelete=0 ");
            strSql.Append("left join P_Business_flow pbf on pbf.P_Business_flow_id=(select top 1 P_Business_flow_id from P_Business_flow pbff where pbff.P_Fk_code=a.M_Case_code and pbff.P_Business_isdelete=0 and pbff.P_Flow_code=mentry.M_Entry_sFlow) ");
            strSql.Append("left join (select copu.C_Organization_code,bcasec.B_Case_code as caseCode from C_Userinfo as cu left join C_Organization_post_user as copu on cu.C_Userinfo_code=copu.C_User_code right join B_Case_link as bcasec on bcasec.C_FK_code=cu.C_Userinfo_code and  bcasec.B_Case_link_type=11 and bcasec.B_Case_link_isDelete=0  and bcasec.C_FK_code is not null) as org on org.caseCode=a.M_Case_code  ");
            strSql.Append("where M_Entry_Statistics_isDelete=0 and bcase.B_Case_isDelete=0  and pbf.P_Business_person is not null and pbf.P_Business_person<>'00000000-0000-0000-0000-000000000000' and bcl.C_FK_code is not null and org.C_Organization_code is not null");

            #region 查询条件
            if (!string.IsNullOrEmpty(model.Query_area)) //地区
            {
                strSql.Append(" and bcl.C_FK_Code=@Query_area");
            }

            if (!string.IsNullOrEmpty(model.Query_organ)) //部门
            {
                strSql.Append(" and (select C_Organization_code from C_Organization_post_user where C_User_code=pbf.P_Business_person) in(select C_Organization_code from C_Organization where C_Organization_name like N'%'+@Query_organ+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_laywer)) //律师
            {
                strSql.Append(" and (select C_Userinfo_name from C_Userinfo where C_Userinfo_code=pbf.P_Business_person) like N'%'+@Query_laywer+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_caseNum)) //案件编码 
            {
                strSql.Append(" and bcase.B_Case_number like N'%'+@Query_caseNum+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_project)) //工程名称
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=7 and bl.B_Case_code=a.M_Case_code) in(select C_Involved_project_code from C_Involved_project where C_Involved_project_name like N'%'+@Query_project+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_court)) //法院
            {
                strSql.Append(" and bcase.B_Case_courtFirst in(select C_Court_code from C_Court where C_Court_name like N'%'+@Query_court+'%') ");
            }

            if (!string.IsNullOrEmpty(model.Query_deleger)) //委托人
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=1 and bl.B_Case_code=a.M_Case_code) in(select C_Customer_code from C_Customer where C_Customer_name like N'%'+@Query_deleger+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_party)) //对方当事人
            {
                strSql.Append(" and ((select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_PRival_code from C_PRival where C_PRival_name like N'%'+@Query_party+'%')");
                strSql.Append(" or (select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_CRival_code from C_CRival where C_CRival_name like N'%'+@Query_party+'%'))");
            }

            if (!string.IsNullOrEmpty(model.Query_income)) //预期收益
            {
                strSql.Append(" and bcase.B_Case_expectedGrant>=@Query_income");
            }

            if (!string.IsNullOrEmpty(model.Query_incomeZ)) //预期收益至
            {
                strSql.Append(" and bcase.B_Case_expectedGrant<=@Query_incomeZ");
            }

            if (!string.IsNullOrEmpty(model.Query_subject)) //移交标的
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney>=@Query_subject");
            }

            if (!string.IsNullOrEmpty(model.Query_subjectZ)) //移交标的至
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney<=@Query_subjectZ");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDate)) //收案时间
            {
                strSql.Append(" and bcase.B_Case_registerTime>=@Query_closedDate");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDateZ)) //收案时间至
            {
                strSql.Append(" and bcase.B_Case_registerTime<=@Query_closedDateZ");
            }

            if (!string.IsNullOrEmpty(model.Query_customDate)) //自定义时间
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)>=@Query_customDate");
            }

            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)<=@Query_customDateZ");
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                strSql.Append(" and (select C_Organization_name from C_Organization where C_Organization_code=org.C_Organization_code) like N'%'+@Query_department+'%' ");
            }
            #endregion

            strSql.Append(" group by mentry.M_Entry_code,bcl.C_FK_code ");
            if (type == 2)
            {
                strSql.Append(",pbf.P_Business_person  ");
            }
            if (type == 3)
            {
                strSql.Append(",org.C_Organization_code ");
            }
            strSql.Append(") tt");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Query_area",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_organ",SqlDbType.VarChar),
                new SqlParameter("@Query_laywer",SqlDbType.VarChar),
                new SqlParameter("@Query_caseNum",SqlDbType.VarChar),
                new SqlParameter("@Query_project",SqlDbType.VarChar),
                new SqlParameter("@Query_court",SqlDbType.VarChar),
                new SqlParameter("@Query_deleger",SqlDbType.VarChar),
                new SqlParameter("@Query_party",SqlDbType.VarChar),
                new SqlParameter("@Query_income",SqlDbType.Decimal),
                new SqlParameter("@Query_incomeZ",SqlDbType.Decimal),
                new SqlParameter("@Query_subject",SqlDbType.Decimal),
                new SqlParameter("@Query_subjectZ",SqlDbType.Decimal),
                new SqlParameter("@Query_closedDate",SqlDbType.DateTime),
                new SqlParameter("@Query_closedDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_customDate",SqlDbType.DateTime),
                new SqlParameter("@Query_customDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_department",SqlDbType.VarChar)
            };

            if (!string.IsNullOrEmpty(model.Query_area))
            {
                para[0].Value = new Guid(model.Query_area);
            }
            para[1].Value = model.Query_organ;
            para[2].Value = model.Query_laywer;
            para[3].Value = model.Query_caseNum;
            para[4].Value = model.Query_project;
            para[5].Value = model.Query_court;
            para[6].Value = model.Query_deleger;
            para[7].Value = model.Query_party;
            if (!string.IsNullOrEmpty(model.Query_income))
            {
                para[8].Value = Convert.ToDecimal(model.Query_income);
            }
            if (!string.IsNullOrEmpty(model.Query_incomeZ))
            {
                para[9].Value = Convert.ToDecimal(model.Query_incomeZ);
            }
            if (!string.IsNullOrEmpty(model.Query_subject))
            {
                para[10].Value = Convert.ToDecimal(model.Query_subject);
            }
            if (!string.IsNullOrEmpty(model.Query_subjectZ))
            {
                para[11].Value = Convert.ToDecimal(model.Query_subjectZ);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDate))
            {
                para[12].Value = Convert.ToDateTime(model.Query_closedDate);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDateZ))
            {
                para[13].Value = Convert.ToDateTime(model.Query_closedDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_customDate))
            {
                para[14].Value = Convert.ToDateTime(model.Query_customDate);
            }
            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                para[15].Value = Convert.ToDateTime(model.Query_customDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                para[16].Value = model.Query_department;
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), para);
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
        /// 获取统计报表
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="type">类型：1 根据区域统计  2 根据区域、律师统计  3 根据区域、部门统计</param>
        /// <returns>数据集</returns>
        public DataSet GetProcessReporting(Model.Reporting.ProcessReporting model, int startIndex, int endIndex, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (select C_Region_name from C_region where C_Region_code=bcl.C_FK_code) as '区域' ");
            strSql.Append(",bcl.C_FK_code as Query_area ");
            if (type == 2)
            {
                strSql.Append(",(select C_Userinfo_name from C_Userinfo where C_Userinfo_code=pbf.P_Business_person) as '律师' ");
                strSql.Append(",pbf.P_Business_person as Query_laywerCode");
            }
            if (type == 3)
            {
                strSql.Append(",(select C_Organization_name from C_Organization where C_Organization_code=org.C_Organization_code) as '营销部门'");
                strSql.Append(",org.C_Organization_code as Query_department ");
            }
            strSql.Append(",(select M_entry_name from M_Entry where M_Entry_code=mentry.M_Entry_code) as '监控项' ");
            strSql.Append(",mentry.M_Entry_code as Query_entry,");
            strSql.Append("count(1) as '应完成数', ");
            strSql.Append("sum(Case when a.M_Entry_Statistics_HandlingState=471 then 1 when a.M_Entry_Statistics_HandlingState=772 then 1 when a.M_Entry_Statistics_HandlingState=773 then 1 else 0 end)  as '实际完成数', ");
            strSql.Append("convert(decimal(18,2),convert(decimal(18,2),sum(Case when a.M_Entry_Statistics_HandlingState=471 then 1 when a.M_Entry_Statistics_HandlingState=772 then 1 when a.M_Entry_Statistics_HandlingState=773 then 1 else 0 end))/convert(decimal(18,2),case when count(1)=0 then 1 else count(1) end)*100) as '完成率', ");
            strSql.Append("sum(Case when a.M_Entry_Statistics_HandlingState=470 then 1 when a.M_Entry_Statistics_HandlingState=773 then 1 else 0 end)  as '超期数', ");
            strSql.Append("convert(decimal(18,2),convert(decimal(18,2),sum(Case when a.M_Entry_Statistics_HandlingState=470 then 1 when a.M_Entry_Statistics_HandlingState=773 then 1 else 0 end))/convert(decimal(18,2),case when count(1)=0 then 1 else count(1) end)*100) as '超期率', ");
            strSql.Append("sum(Case when a.M_Entry_Statistics_changeDuration is null then 0 when a.M_Entry_Statistics_changeDuration=0 then 0 else 1 end) as '延期数', ");
            strSql.Append("convert(decimal(18,2),convert(decimal(18,2),sum(Case when a.M_Entry_Statistics_changeDuration is null then 0 when a.M_Entry_Statistics_changeDuration=0 then 0 else 1 end))/convert(decimal(18,2),case when sum(Case when a.M_Entry_Statistics_HandlingState=470 then 1 when a.M_Entry_Statistics_HandlingState=773 then 1 else 0 end)=0 then 1 else sum(Case when a.M_Entry_Statistics_HandlingState=470 then 1 when a.M_Entry_Statistics_HandlingState=773 then 1 else 0 end) end)*100) as '延期率', ");
            strSql.Append("avg(Case when a.M_Entry_Statistics_HandlingState=470 then a.M_Entry_Statistics_Management*-1 when a.M_Entry_Statistics_HandlingState=773 then a.M_Entry_Statistics_Management*-1 end) as '平均超期时长',");
            strSql.Append("avg(Case when a.M_Entry_Statistics_changeDuration is not null then a.M_Entry_Statistics_changeDuration end) as '平均延期时长',");
            strSql.Append("sum(Case when a.M_Entry_Statistics_HandlingState=470 then bcase.B_Case_expectedGrant when a.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_expectedGrant else 0 end)  as '超期预期收益',");
            strSql.Append("sum(Case when a.M_Entry_Statistics_HandlingState=470 then bcase.B_Case_transferTargetMoney when a.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_transferTargetMoney else 0 end)  as '超期移交标的',");
            strSql.Append("sum(Case when a.M_Entry_Statistics_changeDuration is null then 0 when a.M_Entry_Statistics_changeDuration=0 then 0 else bcase.B_Case_expectedGrant end) as '延期预期收益',");
            strSql.Append("sum(Case when a.M_Entry_Statistics_changeDuration is null then 0 when a.M_Entry_Statistics_changeDuration=0 then 0 else bcase.B_Case_transferTargetMoney end) as '延期移交标的',");
            strSql.Append("sum(Case when a.M_Entry_Statistics_HandlingState=471 then bcase.B_Case_expectedGrant when a.M_Entry_Statistics_HandlingState=772 then bcase.B_Case_expectedGrant when a.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_expectedGrant else 0 end)  as '实际预期收益',");
            strSql.Append("sum(Case when a.M_Entry_Statistics_HandlingState=471 then bcase.B_Case_transferTargetMoney when a.M_Entry_Statistics_HandlingState=772 then bcase.B_Case_transferTargetMoney when a.M_Entry_Statistics_HandlingState=773 then bcase.B_Case_transferTargetMoney else 0 end)  as '实际移交标的' ");
            strSql.Append(" from M_Entry_Statistics a  ");
            strSql.Append("left join B_Case bcase on bcase.B_Case_code=a.M_Case_code and bcase.B_Case_isDelete=0 ");
            strSql.Append("right join M_Entry mentry on a.M_Entry_code=mentry.M_Entry_code and mentry.M_Entry_parent is null and mentry.M_Entry_isDelete=0 ");
            strSql.Append("left join B_Case_link bcl on bcl.B_Case_code=a.M_Case_code and bcl.B_Case_link_type=6 and bcl.B_Case_link_isDelete=0 ");
            strSql.Append("left join P_Business_flow pbf on pbf.P_Business_flow_id=(select top 1 P_Business_flow_id from P_Business_flow pbff where pbff.P_Fk_code=a.M_Case_code and pbff.P_Business_isdelete=0 and pbff.P_Flow_code=mentry.M_Entry_sFlow) ");
            strSql.Append("left join (select copu.C_Organization_code,bcasec.B_Case_code as caseCode from C_Userinfo as cu left join C_Organization_post_user as copu on cu.C_Userinfo_code=copu.C_User_code right join B_Case_link as bcasec on bcasec.C_FK_code=cu.C_Userinfo_code and  bcasec.B_Case_link_type=11 and bcasec.B_Case_link_isDelete=0  and bcasec.C_FK_code is not null) as org on org.caseCode=a.M_Case_code  ");
            strSql.Append("where M_Entry_Statistics_isDelete=0 and bcase.B_Case_isDelete=0  and pbf.P_Business_person is not null and pbf.P_Business_person<>'00000000-0000-0000-0000-000000000000' and bcl.C_FK_code is not null and org.C_Organization_code is not null");
            
            #region 查询条件
            if (!string.IsNullOrEmpty(model.Query_area)) //地区
            {
                strSql.Append(" and bcl.C_FK_Code=@Query_area");
            }

            if (!string.IsNullOrEmpty(model.Query_organ)) //部门
            {
                strSql.Append(" and (select C_Organization_code from C_Organization_post_user where C_Userinfo_code=pbf.P_Business_person) in(select C_Organization_code from C_Organization where C_Organization_name like N'%'+@Query_organ+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_laywer)) //律师
            {
                strSql.Append(" and (select C_Userinfo_name from C_Userinfo where C_User_code=pbf.P_Business_person) like N'%'+@Query_laywer+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_caseNum)) //案件编码 
            {
                strSql.Append(" and bcase.B_Case_number like N'%'+@Query_caseNum+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_project)) //工程名称
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=7 and bl.B_Case_code=a.M_Case_code) in(select C_Involved_project_code from C_Involved_project where C_Involved_project_name like N'%'+@Query_project+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_court)) //法院
            {
                strSql.Append(" and bcase.B_Case_courtFirst in(select C_Court_code from C_Court where C_Court_name like N'%'+@Query_court+'%') ");
            }

            if (!string.IsNullOrEmpty(model.Query_deleger)) //委托人
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=1 and bl.B_Case_code=a.M_Case_code) in(select C_Customer_code from C_Customer where C_Customer_name like N'%'+@Query_deleger+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_party)) //对方当事人
            {
                strSql.Append(" and ((select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_PRival_code from C_PRival where C_PRival_name like N'%'+@Query_party+'%')");
                strSql.Append(" or (select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_CRival_code from C_CRival where C_CRival_name like N'%'+@Query_party+'%'))");
            }

            if (!string.IsNullOrEmpty(model.Query_income)) //预期收益
            {
                strSql.Append(" and bcase.B_Case_expectedGrant>=@Query_income");
            }

            if (!string.IsNullOrEmpty(model.Query_incomeZ)) //预期收益至
            {
                strSql.Append(" and bcase.B_Case_expectedGrant<=@Query_incomeZ");
            }

            if (!string.IsNullOrEmpty(model.Query_subject)) //移交标的
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney>=@Query_subject");
            }

            if (!string.IsNullOrEmpty(model.Query_subjectZ)) //移交标的至
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney<=@Query_subjectZ");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDate)) //收案时间
            {
                strSql.Append(" and bcase.B_Case_registerTime>=@Query_closedDate");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDateZ)) //收案时间至
            {
                strSql.Append(" and bcase.B_Case_registerTime<=@Query_closedDateZ");
            }

            if (!string.IsNullOrEmpty(model.Query_customDate)) //自定义时间
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)>=@Query_customDate");
            }

            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)<=@Query_customDateZ");
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                strSql.Append(" and (select C_Organization_name from C_Organization where C_Organization_code=org.C_Organization_code) like N'%'+@Query_department+'%' ");
            }
            #endregion

            strSql.Append(" group by mentry.M_Entry_code,bcl.C_FK_code ");
            if (type == 2)
            {
                strSql.Append(",pbf.P_Business_person  ");
            }
            if (type == 3)
            {
                strSql.Append(",org.C_Organization_code ");
            }
            strSql.Append(" order by (select C_Region_name from C_region where C_Region_code=bcl.C_FK_code)");
            if(type==2)
            {
                strSql.Append(",pbf.P_Business_person");
            }
            if (type == 3)
            {
                strSql.Append(",org.C_Organization_code");
            }
            strSql.Append(",mentry.M_Entry_code ");
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Query_area",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_organ",SqlDbType.VarChar),
                new SqlParameter("@Query_laywer",SqlDbType.VarChar),
                new SqlParameter("@Query_caseNum",SqlDbType.VarChar),
                new SqlParameter("@Query_project",SqlDbType.VarChar),
                new SqlParameter("@Query_court",SqlDbType.VarChar),
                new SqlParameter("@Query_deleger",SqlDbType.VarChar),
                new SqlParameter("@Query_party",SqlDbType.VarChar),
                new SqlParameter("@Query_income",SqlDbType.Decimal),
                new SqlParameter("@Query_incomeZ",SqlDbType.Decimal),
                new SqlParameter("@Query_subject",SqlDbType.Decimal),
                new SqlParameter("@Query_subjectZ",SqlDbType.Decimal),
                new SqlParameter("@Query_closedDate",SqlDbType.DateTime),
                new SqlParameter("@Query_closedDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_customDate",SqlDbType.DateTime),
                new SqlParameter("@Query_customDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_department",SqlDbType.VarChar)
            };

            if (!string.IsNullOrEmpty(model.Query_area))
            {
                para[0].Value = new Guid(model.Query_area);
            }
            para[1].Value = model.Query_organ;
            para[2].Value = model.Query_laywer;
            para[3].Value = model.Query_caseNum;
            para[4].Value = model.Query_project;
            para[5].Value = model.Query_court;
            para[6].Value = model.Query_deleger;
            para[7].Value = model.Query_party;
            if (!string.IsNullOrEmpty(model.Query_income))
            {
                para[8].Value = Convert.ToDecimal(model.Query_income);
            }
            if (!string.IsNullOrEmpty(model.Query_incomeZ))
            {
                para[9].Value = Convert.ToDecimal(model.Query_incomeZ);
            }
            if (!string.IsNullOrEmpty(model.Query_subject))
            {
                para[10].Value = Convert.ToDecimal(model.Query_subject);
            }
            if (!string.IsNullOrEmpty(model.Query_subjectZ))
            {
                para[11].Value = Convert.ToDecimal(model.Query_subjectZ);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDate))
            {
                para[12].Value = Convert.ToDateTime(model.Query_closedDate);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDateZ))
            {
                para[13].Value = Convert.ToDateTime(model.Query_closedDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_customDate))
            {
                para[14].Value = Convert.ToDateTime(model.Query_customDate);
            }
            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                para[15].Value = Convert.ToDateTime(model.Query_customDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                para[16].Value = model.Query_department;
            }
            return DbHelperSQL.Query(strSql.ToString(), para);
        }


         /// <summary>
        /// 查询详细统计信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetProcessDetails(Model.Reporting.ProcessReporting model, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,mentry.M_Entry_name,mentry.M_Entry_Duration,mentry.M_Entry_warningType,mentry.M_Entry_warningDuration from M_Entry_Statistics  a ");
            strSql.Append("left join B_Case bcase on bcase.B_Case_code=a.M_Case_code ");
            strSql.Append("right join M_Entry mentry on a.M_Entry_code=mentry.M_Entry_code and mentry.M_Entry_parent is null ");
            strSql.Append("left join B_Case_link bcl on bcl.B_Case_code=a.M_Case_code and bcl.B_Case_link_type=6 and bcl.B_Case_link_isDelete=0 ");
            strSql.Append("left join P_Business_flow pbf on pbf.P_Business_flow_id=(select top 1 P_Business_flow_id from P_Business_flow pbff where pbff.P_Fk_code=a.M_Case_code and pbff.P_Business_isdelete=0 and pbff.P_Flow_code=mentry.M_Entry_sFlow) ");
            strSql.Append("left join (select copu.C_Organization_code,bcasec.B_Case_code as caseCode from C_Userinfo as cu left join C_Organization_post_user as copu on cu.C_Userinfo_code=copu.C_User_code right join B_Case_link as bcasec on bcasec.C_FK_code=cu.C_Userinfo_code and  bcasec.B_Case_link_type=11 and bcasec.B_Case_link_isDelete=0  and bcasec.C_FK_code is not null) as org on org.caseCode=a.M_Case_code  ");
            strSql.Append("where M_Entry_Statistics_isDelete=0 and bcase.B_Case_isDelete=0  and pbf.P_Business_person is not null and pbf.P_Business_person<>'00000000-0000-0000-0000-000000000000' and bcl.C_FK_code is not null and org.C_Organization_code is not null ");
            #region 查询条件
            if (!string.IsNullOrEmpty(model.Query_area)) //地区
            {
                strSql.Append(" and bcl.C_FK_Code=@Query_area");
            }

            if (!string.IsNullOrEmpty(model.Query_organ)) //部门
            {
                strSql.Append(" and (select C_Organization_code from C_Organization_post_user where C_User_code=pbf.P_Business_person) in(select C_Organization_code from C_Organization where C_Organization_name like N'%'+@Query_organ+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_laywer)) //律师
            {
                strSql.Append(" and (select C_Userinfo_name from C_Userinfo where C_Userinfo_code=pbf.P_Business_person) like N'%'+@Query_laywer+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_caseNum)) //案件编码 
            {
                strSql.Append(" and bcase.B_Case_number like N'%'+@Query_caseNum+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_project)) //工程名称
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=7 and bl.B_Case_code=a.M_Case_code) in(select C_Involved_project_code from C_Involved_project where C_Involved_project_name like N'%'+@Query_project+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_court)) //法院
            {
                strSql.Append(" and bcase.B_Case_courtFirst in(select C_Court_code from C_Court where C_Court_name like N'%'+@Query_court+'%') ");
            }

            if (!string.IsNullOrEmpty(model.Query_deleger)) //委托人
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=1 and bl.B_Case_code=a.M_Case_code) in(select C_Customer_code from C_Customer where C_Customer_name like N'%'+@Query_deleger+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_party)) //对方当事人
            {
                strSql.Append(" and ((select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_PRival_code from C_PRival where C_PRival_name like N'%'+@Query_party+'%')");
                strSql.Append(" or (select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_CRival_code from C_CRival where C_CRival_name like N'%'+@Query_party+'%'))");
            }

            if (!string.IsNullOrEmpty(model.Query_income)) //预期收益
            {
                strSql.Append(" and bcase.B_Case_expectedGrant>=@Query_income");
            }

            if (!string.IsNullOrEmpty(model.Query_incomeZ)) //预期收益至
            {
                strSql.Append(" and bcase.B_Case_expectedGrant<=@Query_incomeZ");
            }

            if (!string.IsNullOrEmpty(model.Query_subject)) //移交标的
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney>=@Query_subject");
            }

            if (!string.IsNullOrEmpty(model.Query_subjectZ)) //移交标的至
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney<=@Query_subjectZ");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDate)) //收案时间
            {
                strSql.Append(" and bcase.B_Case_registerTime>=@Query_closedDate");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDateZ)) //收案时间至
            {
                strSql.Append(" and bcase.B_Case_registerTime<=@Query_closedDateZ");
            }

            if (!string.IsNullOrEmpty(model.Query_customDate)) //自定义时间
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)>=@Query_customDate");
            }

            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)<=@Query_customDateZ");
            }

            if (!string.IsNullOrEmpty(model.Query_entry))
            {
                strSql.Append(" and a.M_Entry_code=@Query_entry");
            }

            if(!string.IsNullOrEmpty(model.Query_laywerCode))
            {
                strSql.Append(" and pbf.P_Business_person=@Query_laywerCode");
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                strSql.Append(" and org.C_Organization_code=@Query_department");
            }
            #endregion
            strSql.Append(" order by M_Entry_Statistics_id desc");
            strSql.AppendFormat(" offset {0} row fetch next {1} rows only", startIndex - 1, endIndex - startIndex + 1);
            #region 参数
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Query_area",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_organ",SqlDbType.VarChar),
                new SqlParameter("@Query_laywer",SqlDbType.VarChar),
                new SqlParameter("@Query_caseNum",SqlDbType.VarChar),
                new SqlParameter("@Query_project",SqlDbType.VarChar),
                new SqlParameter("@Query_court",SqlDbType.VarChar),
                new SqlParameter("@Query_deleger",SqlDbType.VarChar),
                new SqlParameter("@Query_party",SqlDbType.VarChar),
                new SqlParameter("@Query_income",SqlDbType.Decimal),
                new SqlParameter("@Query_incomeZ",SqlDbType.Decimal),
                new SqlParameter("@Query_subject",SqlDbType.Decimal),
                new SqlParameter("@Query_subjectZ",SqlDbType.Decimal),
                new SqlParameter("@Query_closedDate",SqlDbType.DateTime),
                new SqlParameter("@Query_closedDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_customDate",SqlDbType.DateTime),
                new SqlParameter("@Query_customDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_entry",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_laywerCode",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_department",SqlDbType.UniqueIdentifier)
            };

            if (!string.IsNullOrEmpty(model.Query_area))
            {
                para[0].Value = new Guid(model.Query_area);
            }
            para[1].Value = model.Query_organ;
            para[2].Value = model.Query_laywer;
            para[3].Value = model.Query_caseNum;
            para[4].Value = model.Query_project;
            para[5].Value = model.Query_court;
            para[6].Value = model.Query_deleger;
            para[7].Value = model.Query_party;
            if (!string.IsNullOrEmpty(model.Query_income))
            {
                para[8].Value = Convert.ToDecimal(model.Query_income);
            }
            if (!string.IsNullOrEmpty(model.Query_incomeZ))
            {
                para[9].Value = Convert.ToDecimal(model.Query_incomeZ);
            }
            if (!string.IsNullOrEmpty(model.Query_subject))
            {
                para[10].Value = Convert.ToDecimal(model.Query_subject);
            }
            if (!string.IsNullOrEmpty(model.Query_subjectZ))
            {
                para[11].Value = Convert.ToDecimal(model.Query_subjectZ);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDate))
            {
                para[12].Value = Convert.ToDateTime(model.Query_closedDate);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDateZ))
            {
                para[13].Value = Convert.ToDateTime(model.Query_closedDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_customDate))
            {
                para[14].Value = Convert.ToDateTime(model.Query_customDate);
            }
            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                para[15].Value = Convert.ToDateTime(model.Query_customDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_entry))
            {
                para[16].Value = new Guid(model.Query_entry);
            }
            if (!string.IsNullOrEmpty(model.Query_laywerCode))
            {
                para[17].Value = new Guid(model.Query_laywerCode);
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                para[18].Value = new Guid(model.Query_department);
            }
            #endregion

            return DbHelperSQL.Query(strSql.ToString(), para);
        }

        /// <summary>
        /// 查询详细统计信息总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetProcessDetailsCount(Model.Reporting.ProcessReporting model, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from M_Entry_Statistics  a ");
            strSql.Append("left join B_Case bcase on bcase.B_Case_code=a.M_Case_code ");
            strSql.Append("right join M_Entry mentry on a.M_Entry_code=mentry.M_Entry_code and mentry.M_Entry_parent is null and mentry.M_Entry_isDelete=0  ");
            strSql.Append("left join B_Case_link bcl on bcl.B_Case_code=a.M_Case_code and bcl.B_Case_link_type=6 and bcl.B_Case_link_isDelete=0 ");
            strSql.Append("left join P_Business_flow pbf on pbf.P_Business_flow_id=(select top 1 P_Business_flow_id from P_Business_flow pbff where pbff.P_Fk_code=a.M_Case_code and pbff.P_Business_isdelete=0 and pbff.P_Flow_code=mentry.M_Entry_sFlow) ");
            strSql.Append("left join (select copu.C_Organization_code,bcasec.B_Case_code as caseCode from C_Userinfo as cu left join C_Organization_post_user as copu on cu.C_Userinfo_code=copu.C_User_code right join B_Case_link as bcasec on bcasec.C_FK_code=cu.C_Userinfo_code and  bcasec.B_Case_link_type=11 and bcasec.B_Case_link_isDelete=0  and bcasec.C_FK_code is not null) as org on org.caseCode=a.M_Case_code  ");
            strSql.Append("where M_Entry_Statistics_isDelete=0 and bcase.B_Case_isDelete=0 and pbf.P_Business_person is not null and pbf.P_Business_person<>'00000000-0000-0000-0000-000000000000' and bcl.C_FK_code is not null and org.C_Organization_code is not null ");
            #region 查询条件
            if (!string.IsNullOrEmpty(model.Query_area)) //地区
            {
                strSql.Append(" and bcl.C_FK_Code=@Query_area");
            }

            if (!string.IsNullOrEmpty(model.Query_organ)) //部门
            {
                strSql.Append(" and (select C_Organization_code from C_Organization_post_user where C_User_code=pbf.P_Business_person) in(select C_Organization_code from C_Organization where C_Organization_name like N'%'+@Query_organ+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_laywer)) //律师
            {
                strSql.Append(" and (select C_Userinfo_name from C_Userinfo where C_Userinfo_code=pbf.P_Business_person) like N'%'+@Query_laywer+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_caseNum)) //案件编码 
            {
                strSql.Append(" and bcase.B_Case_number like N'%'+@Query_caseNum+'%' ");
            }

            if (!string.IsNullOrEmpty(model.Query_project)) //工程名称
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=7 and bl.B_Case_code=a.M_Case_code) in(select C_Involved_project_code from C_Involved_project where C_Involved_project_name like N'%'+@Query_project+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_court)) //法院
            {
                strSql.Append(" and bcase.B_Case_courtFirst in(select C_Court_code from C_Court where C_Court_name like N'%'+@Query_court+'%') ");
            }

            if (!string.IsNullOrEmpty(model.Query_deleger)) //委托人
            {
                strSql.Append(" and (select top 1 C_FK_Code from B_Case_link bl where bl.B_Case_link_type=1 and bl.B_Case_code=a.M_Case_code) in(select C_Customer_code from C_Customer where C_Customer_name like N'%'+@Query_deleger+'%')");
            }

            if (!string.IsNullOrEmpty(model.Query_party)) //对方当事人
            {
                strSql.Append(" and ((select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_PRival_code from C_PRival where C_PRival_name like N'%'+@Query_party+'%')");
                strSql.Append(" or (select top 1 C_FK_Code from B_Case_link bl where (bl.B_Case_link_type=2 or bl.B_Case_link_type=3) and bl.B_Case_code=a.M_Case_code) in(select C_CRival_code from C_CRival where C_CRival_name like N'%'+@Query_party+'%'))");
            }

            if (!string.IsNullOrEmpty(model.Query_income)) //预期收益
            {
                strSql.Append(" and bcase.B_Case_expectedGrant>=@Query_income");
            }

            if (!string.IsNullOrEmpty(model.Query_incomeZ)) //预期收益至
            {
                strSql.Append(" and bcase.B_Case_expectedGrant<=@Query_incomeZ");
            }

            if (!string.IsNullOrEmpty(model.Query_subject)) //移交标的
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney>=@Query_subject");
            }

            if (!string.IsNullOrEmpty(model.Query_subjectZ)) //移交标的至
            {
                strSql.Append(" and bcase.B_Case_transferTargetMoney<=@Query_subjectZ");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDate)) //收案时间
            {
                strSql.Append(" and bcase.B_Case_registerTime>=@Query_closedDate");
            }

            if (!string.IsNullOrEmpty(model.Query_closedDateZ)) //收案时间至
            {
                strSql.Append(" and bcase.B_Case_registerTime<=@Query_closedDateZ");
            }

            if (!string.IsNullOrEmpty(model.Query_customDate)) //自定义时间
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)>=@Query_customDate");
            }

            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                strSql.Append(" and dateadd(hour,mentry.M_Entry_Duration,a.M_Entry_Statistics_entrySTime)<=@Query_customDateZ");
            }
            if (!string.IsNullOrEmpty(model.Query_entry))
            {
                strSql.Append(" and a.M_Entry_code=@Query_entry");
            }

            if (!string.IsNullOrEmpty(model.Query_laywerCode))
            {
                strSql.Append(" and pbf.P_Business_person=@Query_laywerCode");
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                strSql.Append(" and org.C_Organization_code=@Query_department");
            }
            #endregion

            #region 参数
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Query_area",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_organ",SqlDbType.VarChar),
                new SqlParameter("@Query_laywer",SqlDbType.VarChar),
                new SqlParameter("@Query_caseNum",SqlDbType.VarChar),
                new SqlParameter("@Query_project",SqlDbType.VarChar),
                new SqlParameter("@Query_court",SqlDbType.VarChar),
                new SqlParameter("@Query_deleger",SqlDbType.VarChar),
                new SqlParameter("@Query_party",SqlDbType.VarChar),
                new SqlParameter("@Query_income",SqlDbType.Decimal),
                new SqlParameter("@Query_incomeZ",SqlDbType.Decimal),
                new SqlParameter("@Query_subject",SqlDbType.Decimal),
                new SqlParameter("@Query_subjectZ",SqlDbType.Decimal),
                new SqlParameter("@Query_closedDate",SqlDbType.DateTime),
                new SqlParameter("@Query_closedDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_customDate",SqlDbType.DateTime),
                new SqlParameter("@Query_customDateZ",SqlDbType.DateTime),
                new SqlParameter("@Query_entry",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_laywerCode",SqlDbType.UniqueIdentifier),
                new SqlParameter("@Query_department",SqlDbType.UniqueIdentifier)
            };

            if (!string.IsNullOrEmpty(model.Query_area))
            {
                para[0].Value = new Guid(model.Query_area);
            }
            para[1].Value = model.Query_organ;
            para[2].Value = model.Query_laywer;
            para[3].Value = model.Query_caseNum;
            para[4].Value = model.Query_project;
            para[5].Value = model.Query_court;
            para[6].Value = model.Query_deleger;
            para[7].Value = model.Query_party;
            if (!string.IsNullOrEmpty(model.Query_income))
            {
                para[8].Value = Convert.ToDecimal(model.Query_income);
            }
            if (!string.IsNullOrEmpty(model.Query_incomeZ))
            {
                para[9].Value = Convert.ToDecimal(model.Query_incomeZ);
            }
            if (!string.IsNullOrEmpty(model.Query_subject))
            {
                para[10].Value = Convert.ToDecimal(model.Query_subject);
            }
            if (!string.IsNullOrEmpty(model.Query_subjectZ))
            {
                para[11].Value = Convert.ToDecimal(model.Query_subjectZ);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDate))
            {
                para[12].Value = Convert.ToDateTime(model.Query_closedDate);
            }
            if (!string.IsNullOrEmpty(model.Query_closedDateZ))
            {
                para[13].Value = Convert.ToDateTime(model.Query_closedDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_customDate))
            {
                para[14].Value = Convert.ToDateTime(model.Query_customDate);
            }
            if (!string.IsNullOrEmpty(model.Query_customDateZ))
            {
                para[15].Value = Convert.ToDateTime(model.Query_customDateZ);
            }
            if (!string.IsNullOrEmpty(model.Query_entry))
            {
                para[16].Value = new Guid(model.Query_entry);
            }
            if (!string.IsNullOrEmpty(model.Query_laywerCode))
            {
                para[17].Value = new Guid(model.Query_laywerCode);
            }
            if (!string.IsNullOrEmpty(model.Query_department))
            {
                para[18].Value = new Guid(model.Query_department);
            }
            #endregion
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

    }
}
