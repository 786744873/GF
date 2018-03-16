using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Common
{
    /**
     * 子业务枚举
     ******/

    /// <summary>
    /// 客户业务类型枚举
    /// </summary>
    public enum CustomerBusiness
    {
        客户 = 81,
        委托人 = 82,
        客户委托人 = 83,
    }

    /// <summary>
    /// 客户类别枚举
    /// </summary>
    public enum CustomerCategoryEnum
    {
        普通客户 = 561,
        VIP客户 = 562,
        老客户 = 563,
        代理商 = 564,
        供货商 = 565,
        合作伙伴 = 566,
        其它 = 567
    }

    /// <summary>
    /// 客户状态枚举
    /// </summary>
    public enum CustomerStateEnum
    {
        潜在客户 = 569,
        意向客户 = 570,
        成交客户 = 571,
        失败客户 = 572,
        已流失客户 = 573,
        忠诚客户 = 574
    }

    /// <summary>
    /// 客户变更审核状态枚举
    /// </summary>
    public enum CustomerChangHistoryStateEnum
    {
        待审核 = 904,
        已通过 = 905,
        未通过 = 906
    }

    /// <summary>
    /// 联系方式枚举
    /// </summary>
    public enum ContactInformationEnum
    {
        电话 = 543,
        传真 = 544,
        登门拜访 = 545,
        邮件 = 546,
        短信 = 547
    }

    /// <summary>
    /// 跟进阶段枚举
    /// </summary>
    public enum CustomerFollowStageEnum
    {
        问卷调查 = 549,
        电话预约 = 550,
        客户回访 = 551,
        服务阶段 = 552,
        客户询价 = 553,
        已送样品 = 554,
        技术谈判 = 555,
        商务谈判中 = 556,
        已订单 = 557,
        已发货未安装 = 558,
        安装完毕 = 559
    }

    /// <summary>
    /// 自定义表单数据源类型枚举
    /// </summary>
    public enum CustomerFormDataSourceType
    {
        参数表 = 118,
        资料库表 = 119,
        自定义表单 = 186
    }
    /// <summary>
    /// 条件类型枚举
    /// </summary>
    public enum ConditonType
    {
        等于 = 121,
        不等于 = 122,
        大于 = 123,
        小于 = 124,
        大于等于 = 125,
        小于等于 = 126,
        两者之间 = 127
    }
    /// <summary>
    /// UI控件类型枚举
    /// </summary>
    public enum UiControlType
    {
        单行文本框 = 129,
        多行文本框 = 130,
        单选框 = 131,
        复选框 = 132,
        下拉框 = 133,
        日期框 = 134,
        日期时间框 = 135,
        单选弹出框 = 136,
        多选弹出框 = 137,
        单选弹出树 = 138,
        多选弹出树 = 139,
        普通树 = 140,
        文本编辑器 = 205,
        附件 = 206,
        普通子表 = 207,
        Tab容器 = 208,
        Tab表单 = 209,
        Tab子表 = 210,
        主子表 = 527,
        时间框 = 578,
        标签 = 604,
        超链接 = 605,
        多选弹出文本框 = 655,
        联动下拉框 = 682,
        不严谨单选弹出框 = 705
    }

    /// <summary>
    /// 表单类型枚举
    /// </summary>
    public enum FormTypeEnum
    {
        案件表单 = 521,
        商机表单 = 522,
        协同办公表单 = 523,
        客户表单 = 902
    }

    /// <summary>
    /// 业务流程状态枚举
    /// </summary>
    public enum BusinessFlowStatus
    {
        未开始 = 199,
        正在进行 = 200,
        已结束 = 201,
        已超时 = 345
    }
    /// <summary>
    /// 业务流程审核类型
    /// </summary>
    public enum BusinessFlowAuditType
    {
        完全监控 = 203,
        仅监控当前预设流程 = 204
    }
    /// <summary>
    /// 业务流程审核状态
    /// </summary>
    public enum BusinessFlowApplicationStatueType
    {
        未提交 = 512,
        已提交 = 513,
        未通过 = 514,
        已通过 = 515,
        申请配置 = 812,
        配置通过 = 813,
        配置未通过 = 814
    }

    /// <summary>
    /// 案件关联表枚举
    /// </summary>
    public enum CaselinkEnum
    {
        客户 = 0,
        委托人 = 1,
        对方当事人公司 = 2,
        对方当事人个人 = 3,
        被执行人公司 = 4,
        被执行人个人 = 5,
        所属区域 = 6,
        工程 = 7,
        原告 = 8,
        被告公司 = 9,
        被告个人 = 10,
        销售顾问 = 11
    }

    /// <summary>
    /// 商机关联表枚举
    /// </summary>
    public enum BusinessChancelinkEnum
    {
        客户 = 0,
        委托人 = 1,
        对方当事人公司 = 2,
        对方当事人个人 = 3,
        工程 = 4,
        销售顾问 = 5,
        联系人 = 6,
        区域 = 7
    }

    /// <summary>
    /// 商机审查意见类型枚举
    /// </summary>
    public enum BusinessChanceCheckOpinionTypeEnum
    {
        通过 = 866,
        不通过 = 867,
        保持现状 = 868
    }

    /// <summary>
    /// 商机审查状态
    /// </summary>
    public enum BusinessChanceCheckEnum
    {
        未审查 = 870,
        审查中 = 871,
        已流失 = 872,
        已转案件 = 873
    }
    /// <summary>
    /// 商机审查人员类型枚举
    /// </summary>
    public enum BusinessChanceCheckPersonTypeEnum
    {
        部长 = 1,
        首席 = 2
    }

    /// <summary>
    /// 竞争对手枚举
    /// </summary>
    public enum CompetitorChildEnum
    {
        活跃 = 47,
        一般 = 48,
        不活跃 = 49
    }

    /// <summary>
    /// 法律对手企业类型枚举
    /// </summary>
    public enum CRivalTypeEnum
    {
        国有企业 = 51,
        集体所有制企业 = 52,
        私营企业 = 53,
        股份制企业 = 54,
        联营企业 = 55,
        外商投资企业 = 56,
        港澳台投资企业 = 57,
        股份合作企业 = 58
    }

    /// <summary>
    /// 法律对手资本结构枚举
    /// </summary>
    public enum CRivalCorganEnum
    {
        国有资本 = 60,
        法人资本 = 61,
        个人资本 = 62,
        港澳台商资本 = 63,
        外商资本 = 64
    }

    /// <summary>
    /// 法律对手经营模式枚举
    /// </summary>
    public enum CRivalSmodelEnum
    {
        纯直营 = 66,
        直营为主 = 67,
        单纯挂靠 = 68,
        挂靠为主 = 69
    }

    /// <summary>
    /// 民族枚举
    /// </summary>
    public enum ContactsNationEnum
    {
        汉族 = 71,
        回族 = 113,
        藏族 = 114,
        土家族 = 115,
        彝族116
    }

    /// <summary>
    /// 政治面貌枚举
    /// </summary>
    public enum ContactsPoliticalEnum
    {
        无党派人士 = 73,
        党员 = 74,
        团员79
    }

    /// <summary>
    /// 公司性质枚举
    /// </summary>
    public enum CompanyPropertyEnum
    {
        国有 = 76,
        民营 = 77,
        外企 = 78
    }

    /// <summary>
    /// 财产线索银行枚举
    /// </summary>
    public enum Property_trail_bankTypeEnum
    {
        法院 = 89,
        政府部门 = 90,
        行政主管机构 = 91,
        其他 = 92
    }

    /// <summary>
    /// 法律管理水平格式文本枚举
    /// </summary>
    public enum TfEnum
    {
        管理条款 = 94,
        结算条款 = 95,
        违约责任条款 = 96,
        其他特殊条款 = 97
    }

    /// <summary>
    /// 法律管理水平管理风格枚举
    /// </summary>
    public enum MsEnum
    {
        严格 = 99,
        宽松 = 100
    }

    /// <summary>
    /// 法律管理水平使用习惯枚举
    /// </summary>
    public enum HabitEnum
    {
        公司公章 = 102,
        项目章 = 103,
        资料专用章 = 104,
        经济合同无效章 = 105
    }

    /// <summary>
    /// 法律管理水平印章责任规避枚举
    /// </summary>
    public enum SdutyEnum
    {
        外签订经济合同无效章 = 107,
        每个项目均刻公章并备案, 但从不使用真项目章 = 108
    }

    /// <summary>
    /// 法律管理水平诉讼管理枚举
    /// </summary>
    public enum AmEnum
    {
        诉讼内包 = 110,
        诉讼外包 = 111
    }

    /// <summary>
    /// 案件类型枚举
    /// </summary>
    public enum CaseTypeEnum
    {
        钢材 = 142,
        架管 = 143,
        混凝土 = 144,
        其它 = 145
    }
    /// <summary>
    /// 案件级别枚举
    /// </summary>
    public enum CaseLevelEnum
    {
        重案 = 940,
        大案 = 941,
        难案 = 942
    }
    /// <summary>
    /// 案件级别变更记录类型
    /// </summary>
    public enum CaseLevelChangeRecordTypeEnum
    {
        手动 = 944,
        自动 = 945
    }
    /// <summary>
    /// 案件级别变更状态
    /// </summary>
    public enum CaseLevelChangeStateEnum
    {
        待审核 = 947,
        通过 = 948,
        未通过 = 949
    }
    /// <summary>
    /// 案件性质枚举
    /// </summary>
    public enum CaseNatureEnum
    {
        类型案件 = 147,
        非类型案件 = 148
    }

    /// <summary>
    /// 案件分类枚举
    /// </summary>
    public enum CaseCategoryEnum
    {
        指挥级 = 1,
        策划级 = 2
    }

    /// <summary>
    /// 案件客户类型枚举
    /// </summary>
    public enum CaseCustomerTypeEnum
    {
        新客户 = 150,
        老客户 = 151
    }
    /// <summary>
    /// 结案意见枚举
    /// </summary>
    public enum EndCaseSuggestEnum
    {
        结案 = 760,
        维持现状 = 761
    }


    /// <summary>
    /// 流程类型枚举
    /// </summary>
    public enum FlowTypeEnum
    {
        案件 = 153,
        商机 = 154,
        客户 = 901
    }

    /// <summary>
    /// 涉案项目报建情况枚举
    /// </summary>
    public enum Involved_projecSituationtEnum
    {
        合法 = 156,
        非法 = 157
    }

    /// <summary>
    /// 涉案项目发包形式枚举
    /// </summary>
    public enum Involved_projecBagStyleEnum
    {
        业主直营 = 159,
        挂靠 = 160,
        项目承包 = 161,
        不详 = 162
    }

    /// <summary>
    /// 涉案项目建设资金来源枚举
    /// </summary>
    public enum Involved_projecFundsSourceEnum
    {
        自筹 = 164,
        合资 = 165,
        国有投资 = 166,
        外资 = 167
    }


    /// <summary>
    /// 涉案项目组织形式枚举
    /// </summary>
    public enum Involved_projecChargerOrganEnum
    {
        自营 = 169,
        合伙 = 170
    }

    /// <summary>
    /// 涉案项目工程进度枚举
    /// </summary>
    public enum Involved_projecProcessEnum
    {
        基础以下 = 172,
        主体 = 173,
        封顶 = 174,
        装修拆架 = 175,
        综合验收 = 176,
        竣工验收 = 177
    }

    /// <summary>
    /// 涉案项目实际负责人亏盈状态枚举
    /// </summary>
    public enum Involved_projecLossOrProfitEnum
    {
        盈利 = 179,
        亏损 = 180,
        齐平 = 181
    }

    /// <summary>
    /// 涉案项目实际负责人亏损原因枚举
    /// </summary>
    public enum Involved_projecLossReasonEnum
    {
        无亏损 = 183,
        经营不善 = 184,
        合同价格低 = 185
    }

    /// <summary>
    /// 费用承担枚举
    /// </summary>
    public enum BearToPayChildEnum
    {
        律所支付 = 251,
        客户支付 = 252,
        律所垫付客户最终承担 = 253
    }
    /// <summary>
    /// 表单状态枚举
    /// </summary>
    public enum FormStatusEnum
    {
        未提交 = 259,
        已提交 = 260,
        未通过 = 261,
        已通过 = 262,
        已作废 = 766
    }
    /// <summary>
    /// 表单审核状态枚举
    /// </summary>
    public enum FormCheckStatusEnum
    {
        未审核 = 315,
        通过 = 316,
        不通过 = 317
    }

    /// <summary>
    /// 收款明细枚举
    /// </summary>
    public enum RDetail_ptypeEnum
    {
        现金 = 310,
        公对公转账 = 311,
        承兑汇票支付 = 312,
        私卡转账 = 313
    }

    /// <summary>
    /// 条目--预警类型枚举
    /// </summary>
    public enum Entry_ChildlEnum
    {
        条目发生前 = 319,
        条目发生后 = 320,
        条目标准时长结束前 = 321,
        条目标准时长结束后 = 322
    }
    /// <summary>
    /// 条目--预警情况枚举
    /// </summary>
    public enum Entry_WarningSituationlEnum
    {
        预警 = 464,
        非预警 = 465,
        手工结束 = 466
    }
    /// <summary>
    /// 条目--监控状态枚举
    /// </summary>
    public enum Entry_HandlingStatelEnum
    {
        未开始 = 468,
        正进行 = 469,
        已超时 = 470,
        已结束 = 471,
        提前完成 = 772,
        超时完成 = 773,
        已作废 = 793
    }
    /// <summary>
    /// 文件归属类型枚举
    /// </summary>
    public enum FileBelongTypeEnum
    {
        客户 = 324,
        法院 = 329,
        公司 = 334,
        个人 = 335,
        联系人 = 336,
        法官 = 337,
        委托人 = 338,
        配偶 = 339,
        案件 = 331,
        商机 = 508,
        自定义表单 = 602,
        意见反馈 = 809
    }

    /// <summary>
    /// 条目变更—变更情况枚举
    /// </summary>
    public enum EntryChangeIsThroughlEnum
    {
        未审批 = 326,
        通过 = 327,
        未通过 = 328
    }
    /// <summary>
    /// 客户类型
    /// </summary>
    public enum CustomertypeEnum
    {
        个体户 = 23,
        单位 = 24,
        自然人 = 25
    }
    /// <summary>
    /// 用户登录状态枚举(虚拟枚举)
    /// </summary>
    public enum UserLoginStateEnum
    {
        未启用 = 0,
        已启用 = 1,
        已禁用 = 2
    }

    /// <summary>
    /// 收入类型枚举
    /// </summary>
    public enum CaseRevenueTypelEnum
    {
        预期收入 = 348,
        文书收入 = 349,
        诉讼实际收入 = 350,
        过期收入 = 351,
        让利给被告金额352,
        实际收入 = 353,
        应回款金额 = 354,
        收款金额 = 355,
        付款金额 = 356,
        转执行前回款金额 = 357,
        垫付款 = 358
    }
    /// <summary>
    /// 时间所属枚举
    /// </summary>
    public enum TimeBelongTypeEnum
    {
        表单 = 0,
        流程 = 1
    }
    /// <summary>
    /// 条目统计状态枚举
    /// </summary>
    public enum EntryStatisticsStatusEnum
    {
        有效 = 397,
        无效 = 398
    }
    /// <summary>
    /// 消息大类枚举
    /// </summary>
    public enum MessageBigTypeEnum
    {
        案件 = 426,
        商机 = 427,
        客户 = 428,
        日程 = 509,
        OA表单消息 = 580,
        OA邮箱消息 = 585,
        进程管理 = 765,
        财务消息 = 810,
        KMS资源评论消息 = 888,
        KMS问吧回答消息 = 889
    }

    /// <summary>
    /// 消息小类枚举
    /// </summary>
    public enum MessageTinyTypeEnum
    {
        新增案件 = 429,
        流程启动 = 430,
        表单启动 = 431,
        表单审核 = 432,
        审核通过 = 433,
        审核未通过 = 434,
        预警消息 = 472,
        超时消息 = 473,
        日程提醒 = 510,
        OA表单提交 = 581,
        进入下一流程 = 582,
        审核通过流程 = 583,
        审核驳回流程 = 584,
        收件箱消息 = 586,
        非里程碑稽查消息 = 706,
        里程碑稽查消息 = 707,
        条目变更 = 762,
        审核通过条目变更 = 763,
        审核驳回条目变更 = 764,
        预期收益 = 811,
        商机配置 = 818,
        配置通过 = 819,
        配置未通过 = 820,
        商机开启 = 821,
        开启流程通过 = 822,
        开启流程驳回 = 823,
        商机审查 = 877,
        保持现状 = 885,
        商机审查通过 = 886,
        商机流失 = 887,
        资源评论 = 890,
        评论回复 = 891,
        问题回答 = 892,
        问题回复 = 893,
        客户变更申请 = 907,
        客户变更通过 = 908,
        客户变更驳回 = 909,
        客户配置 = 910,
        客户配置通过 = 911,
        客户配置未通过 = 912,
        客户开启 = 913,
        开启客户流程通过 = 914,
        开启客户流程驳回 = 915,
        商机变更申请 = 932,
        商机变更通过 = 933,
        商机变更驳回 = 934,
        案件级别变更申请 = 950,
        案件级别变更通过 = 951,
        案件级别变更未通过 = 952,
        可结案 = 953,
        结案确认审核 = 970,
        结案确认审核未通过 = 974,
        结案确认审核通过 = 975
    }

    /// <summary>
    /// 消息类型枚举
    /// </summary>
    public enum MessageTypeEnum
    {
        新增 = 919,
        流程分配 = 920,
        任务分配 = 921,
        待审核 = 922,
        审核通过 = 923,
        审核驳回 = 924,
        稽查消息 = 925,
        预警消息 = 926,
        超时消息 = 927,
        预期收益 = 928
    }

    /// <summary>
    /// 商机类型枚举
    /// </summary>
    public enum BusinessChanceTypeEnum
    {
        钢材 = 494,
        架管 = 495,
        混凝土 = 496,
        其它 = 497
    }
    /// <summary>
    /// 单据类型枚举
    /// </summary>
    public enum DocumentTypeEnum
    {
        报销 = 600,
        借款 = 601
    }
    public enum PaymentMethodEnum
    {
        现金 = 517,
        支票 = 518,
        汇款 = 519
    }

    public enum FeedbackStateEnum
    {
        未操作 = 801,
        已采纳 = 802,
        未采纳 = 803,
        无用信息 = 804
    }

    /// <summary>
    /// 业务流程记录类型枚举
    /// </summary>
    public enum BusinessFlowRecordTypeEnum
    {
        配置 = 816,
        开启 = 817
    }

    /// <summary>
    /// 查询条件记录所属业务枚举
    /// </summary>
    public enum SearchConditionRecordBelongingEnum
    {
        进程管理统计报表 = 917
    }

    /// <summary>
    /// 变更记录类型
    /// </summary>
    public enum ChangHistoryTypeEnum
    {
        客户 = 930,
        商机 = 931
    }
    /// <summary>
    /// 转移类型枚举
    /// </summary>
    public enum TransferType
    {
        全部转移 = 936,
        转移阶段 = 937,
        转移表单 = 938
    }
    /// <summary>
    /// 结案确认审核状态
    /// </summary>
    public enum CaseConfirmStateEnum
    {
        在审核 = 955,
        已通过 = 956,
        未通过 = 957
    }
    /// <summary>
    ///  结案审核意见类型
    /// </summary>
    public enum EndCaseSuggestTypeEnum
    {
        部长意见 = 960,
        首席意见 = 961,
        行政意见 = 962,
        财务意见 = 963,
        人资意见 = 964
    }
    /// <summary>
    /// 结案审核状态
    /// </summary>
    public enum EndCaseCheckStateEnum
    {
        未开始 = 966,
        已开始 = 967,
        已通过 = 968,
        未通过 = 969
    }
    /// <summary>
    /// 角色权限类型
    /// </summary>
    public enum RolePowerTypeEnum
    {
        案件=984,
        商机=985,
        客户=986
    }
    #region OA相关

    /// <summary>
    /// 提醒类型枚举
    /// </summary>
    public enum RemindTypeEnum
    {
        不提醒 = 475,
        准时 = 476,
        提前10分钟 = 477,
        提前30分钟 = 478,
        提前1小时 = 479,
        提前2小时 = 480,
        提前3小时 = 481,
        提前1天 = 482
    }

    /// <summary>
    /// 结束条件枚举
    /// </summary>
    public enum EndConditionEnum
    {
        永不结束 = 506,
        结束日期 = 507
    }

    /// <summary>
    /// 重复类型枚举
    /// </summary>
    public enum RepeatTypeEnum
    {
        每日重复 = 499,
        每周重复 = 500,
        每月重复 = 501
    }

    /// <summary>
    /// 文章状态枚举
    /// </summary>
    public enum ArticleStateEnum
    {
        未提交 = 484,
        已提交 = 485,
        审核通过 = 486,
        审核未通过 = 487
    }
    /// <summary>
    /// 邮件状态枚举
    /// </summary>
    public enum EmailStateEnum
    {
        已发送 = 489,
        草稿 = 490,
    }
    /// <summary>
    /// 收件人类型枚举
    /// </summary>
    public enum EmailSendTypeEnum
    {
        收件人 = 503,
        抄送人 = 504,
    }
    /// <summary>
    /// 多人审核类型
    /// </summary>
    public enum AuditTypeEnum
    {
        并且 = 525,
        或者 = 526,
    }
    /// <summary>
    /// 表单流程审核状态
    /// </summary>
    public enum FormAuditTypeEnum
    {
        未开始 = 529,
        已开始 = 530,
        未通过 = 531,
        已通过 = 532,
    }
    /// <summary>
    /// 表单申请状态
    /// </summary>
    public enum FormApplyTypeEnum
    {
        未提交 = 534,
        已提交 = 535,
        未通过 = 536,
        已通过 = 537,
    }
    /// <summary>
    /// 表单审批人状态
    /// </summary>
    public enum FormApprovalTypeEnum
    {
        未审核 = 539,
        已通过 = 540,
        已驳回 = 541,
    }
    #endregion

    #region 自定义表单相关

    /// <summary>
    /// 保全方式枚举
    /// </summary>
    public enum SecurityMethodEnum
    {
        直接保全 = 593,
        协助保全 = 594,
        间接保全 = 595
    }

    /// <summary>
    /// 审核意见枚举
    /// </summary>
    public enum AuditOpionEnum
    {
        同意 = 680,
        不同意 = 681
    }

    /// <summary>
    /// 触发事件类型枚举
    /// </summary>
    public enum TriggerEventTypeEnum
    {
        无事件 = 684,
        改变事件 = 685
    }

    /// <summary>
    /// 诉讼请求枚举
    /// </summary>
    public enum SsQqEnum
    {
        贷款 = 700,
        诉讼费用 = 701,
        逾期付款损失 = 702,
        违约金 = 703,
        律师费 = 704
    }


    #endregion

    #region KMS相关
    /// <summary>
    /// 资源类型枚举
    /// </summary>
    public enum ResourcesTypeEnum
    {
        图片 = 825,
        word = 826,
        视频 = 827,
        pdf = 828,
        文章 = 829,
        excel = 830,
        ppt = 836
    }
    /// <summary>
    /// 资源状态枚举
    /// </summary>
    public enum ResourcesStateEnum
    {
        未审核 = 832,
        未通过 = 833,
        已发布 = 834,
        隐藏 = 835
    }
    /// <summary>
    /// 问题状态枚举
    /// </summary>
    public enum ProblemStateEnum
    {
        未解决 = 838,
        已解决 = 839,
        已回答 = 840,
        未回答 = 841
    }
    /// <summary>
    /// 问题审核状态枚举
    /// </summary>
    public enum ProblemAuditStateEnum
    {
        未审核 = 882,
        审核通过 = 883,
        未通过 = 884
    }
    /// <summary>
    /// 评论类型枚举
    /// </summary>
    public enum CommentsTypeEunm
    {
        资源评论 = 875,
        问吧回答 = 876
    }
    #endregion

    #region 登录

    public enum LoginTypeEnum
    {
        北斗云PC = 972,
        北斗云APP = 973,
        PC_云学堂 = 976,
        PC_办公协同 = 977,
        PC_报表系统 = 978,
        云学堂 = 979,
        报表系统 = 980,
        办公协同 = 981
    }

    #endregion

}
