using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Common
{
    /**
     * 业务枚举
     ****/

    /// <summary>
    /// 客户业务枚举
    /// </summary>
    public enum CustomerEnum
    {
        客户类型 = 16,
        行业 = 17,
        客户来源 = 18,
        客户级别 = 19,
        是否签约客户 = 20,
        签约客户状态 = 21,
        客户忠诚度 = 22,
        客户业务类型 = 80,
        客户类别 = 560,
        客户状态 = 568,
        稽查事项 = 774,
        客户变更审核状态 = 903,
        变更记录类型 = 929
    }

    /// <summary>
    /// 客户跟进枚举
    /// </summary>
    public enum CustomerFollowEnum
    {
        联系方式 = 542,
        跟进阶段 = 548
    }

    /// <summary>
    /// 公司业务枚举
    /// </summary>
    public enum CompanyEnum
    {
        公司性质 = 75
    }

    /// <summary>
    /// 竞争对手枚举
    /// </summary>
    public enum CompetitorEnum
    {
        状态 = 46
    }
    /// <summary>
    /// 法律对手枚举
    /// </summary>
    public enum CRivalEnum
    {
        企业类型 = 50,
        资本结构 = 59,
        经营模式 = 65
    }
    /// <summary>
    /// 联系人枚举
    /// </summary>
    public enum ContactsEnum
    {
        民族 = 70,
        政治面貌 = 72,
        联系人类型 = 1
    }
    /// <summary>
    /// 财产线索银行枚举
    /// </summary>
    public enum Property_trail_bankEnum
    {
        账号类型 = 88
    }
    /// <summary>
    /// 法律管理水平枚举
    /// </summary>
    public enum legal_management_levelEnum
    {
        格式文本 = 93,
        管理风格 = 98,
        使用习惯 = 101,
        印章责任规避 = 106,
        诉讼管理 = 109
    }
    /// <summary>
    /// 案件枚举
    /// </summary>
    public enum CaseEnum
    {
        案件类型 = 141,
        案件性质 = 146,
        客户类型 = 149,
        钢材财产权利 = 263,
        架管财产权利 = 265,
        混凝土财产权利 = 267,
        其它财产权利 = 269,
        结案意见 = 759,
        案件级别 = 939,
        案件级别变更类型 = 943,
        案件级别变更状态 = 946,
        结案确认审核状态 = 954
    }
    /// <summary>
    /// 流程枚举
    /// </summary>
    public enum FlowEnum
    {
        流程类型 = 152,
        流程所属类型 = 805
    }
    /// <summary>
    /// 表单枚举
    /// </summary>
    public enum FormEnum
    {
        控件类型 = 128,
        表单状态 = 258,
        表单审核状态 = 314,
        表单类型 = 520
    }
    /// <summary>
    /// 涉案项目枚举
    /// </summary>
    public enum Involved_projectEnum
    {
        报建情况 = 155,
        发包形式 = 158,
        建设资金来源 = 163,
        组织形式 = 168,
        工程进度 = 171,
        实际负责人亏盈状态 = 178,
        亏损原因 = 182
    }

    /// <summary>
    /// 业务流程枚举
    /// </summary>
    public enum BusinessFlowEnum
    {
        业务流程状态 = 198,
        业务流程审核类型 = 202,
        业务流程审核状态 = 511
    }

    /// <summary>
    /// 费用类型枚举
    /// </summary>
    public enum BearToPayCtypesEnum
    {
        费用类型 = 254
    }

    /// <summary>
    /// 费用承担枚举
    /// </summary>
    public enum BearToPayEnum
    {
        支付方式 = 250
    }


    /// <summary>
    /// 担保物约定枚举
    /// </summary>
    public enum OppintEnum
    {
        担保物 = 254
    }

    /// <summary>
    /// 收款明细枚举
    /// </summary>
    public enum RDetailEnum
    {
        付款方式 = 309
    }

    /// <summary>
    /// 条目枚举
    /// </summary>
    public enum EntrylEnum
    {
        预警类型 = 318,
        预警情况 = 463,
        监控状态 = 467,
        进程类型 = 767
    }
    /// <summary>
    /// 条目统计状态
    /// </summary>
    public enum EntryStatisticsEnum
    {
        条目统计状态 = 396
    }

    /// <summary>
    /// 条目变更枚举
    /// </summary>
    public enum EntryChangelEnum
    {
        变更情况 = 325
    }

    /// <summary>
    /// 收入类型枚举
    /// </summary>
    public enum CaseRevenuelEnum
    {
        收入类型 = 347
    }

    /// <summary>
    /// 消息枚举
    /// </summary>
    public enum MessageEnum
    {
        消息大类 = 424,
        消息小类 = 425
    }

    /// <summary>
    /// 商机枚举
    /// </summary>
    public enum BusinessChanceEnum
    {
        商机类型 = 493,
        商机审查意见类型 = 865,
        商机审查状态 = 869
    }
    /// <summary>
    /// 意见反馈枚举
    /// </summary>
    public enum FeedbackEnum
    {
        功能类型 = 795,
        意见反馈状态 = 800
    }
    /// <summary>
    /// 转移类型
    /// </summary>
    public enum CaseTransferType
    {
        转移类型 = 935,
    }
    /// <summary>
    /// 结案审核枚举
    /// </summary>
    public enum EndCaseEnum
    {
        结案审核意见类型 = 959,
        结案审核状态 = 965
    }
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum PowerTypeEnum
    {
        权限类型 = 983
    }

    #region OA相关

    /// <summary>
    /// 日程枚举
    /// </summary>
    public enum ScheduleEnum
    {
        提醒类型 = 474,
        重复类型 = 498,
        结束条件 = 505
    }

    /// <summary>
    /// 文章枚举
    /// </summary>
    public enum ArticleEnum
    {
        文章状态 = 483
    }
    /// <summary>
    /// 邮件状态
    /// </summary>
    public enum EmailEnum
    {
        邮件状态 = 488
    }
    /// <summary>
    /// 收件人类型
    /// </summary>
    public enum EmailUserTypeEnum
    {
        收件人类型 = 502
    }
    /// <summary>
    /// 流程预设-多人审核类型
    /// </summary>
    public enum FlowSetAuditTypeEnum
    {
        多人审核类型 = 524
    }
    /// <summary>
    /// 表单审核状态
    /// </summary>
    public enum FormAuditStatuesEnum
    {
        审核状态 = 528
    }
    /// <summary>
    /// 表单申请状态
    /// </summary>
    public enum FormApplyStatuesEnum
    {
        申请状态 = 533
    }
    /// <summary>
    /// 表单审批状态
    /// </summary>
    public enum FormApprovalStatuesEnum
    {
        表单审批状态 = 538
    }
    #endregion

    #region 自定义表单相关
    public enum CustomerFormEnum
    {
        付款状态 = 596,
        费用种类 = 245,
        费用类型 = 246,
        垫付款类型 = 247,
        发票种类 = 587,
        触发事件类型 = 683
    }
    #endregion

    #region KMS相关
    /// <summary>
    /// 资源枚举
    /// </summary>
    public enum ResourcesEnum
    {
        资源类型 = 824,
        资源状态 = 831
    }
    /// <summary>
    /// 问题枚举
    /// </summary>
    public enum ProblemEnum
    {
        问题状态 = 837,
        问题审核状态 = 881
    }
    /// <summary>
    /// 评论枚举
    /// </summary>
    public enum CommentsEunm
    {
        评论类型 = 874
    }
    #endregion

    #region 登录

    public enum LoginEnum
    {
        登录类型 = 971
    }

    #endregion
}
