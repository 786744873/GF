using System;
namespace CommonService.Model
{
    /// <summary>
    /// 涉案项目关联单位表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	[Serializable]
	public partial class C_Involved_projectUnit
	{
		public C_Involved_projectUnit()
		{}
		#region Model
		private int _c_involved_projectunit_id;
		private Guid? _c_involved_projectunit_code;
		private Guid? _c_involved_project_code;
		private string _c_involved_projectunit_child;
		private int? _c_involved_projectunit_rival_type;
        private Guid? _c_involved_projectunit_rival;
        private string _c_involved_projectunit_rivalname;
		private int? _c_involved_projectunit_type;
		private int? _c_involved_projectunit_fundssource;
		private Guid? _c_involved_projectunit_charger;
        private string _c_involved_projectunit_chargername;
		private string _c_involved_projectunit_chargeridentity;
		private int? _c_involved_projectunit_chargerorgan;
		private int? _c_involved_projectunit_chargerfundssource;
		private DateTime? _c_involved_projectunit_starttime;
		private DateTime? _c_involved_projectunit_acceptancetime;
		private int? _c_involved_projectunit_process;
		private string _c_involved_projectunit_accidents;
		private string _c_involved_projectunit_qualityaccidents;
		private string _c_involved_projectunit_litigation;
		private int? _c_involved_projectunit_lossorprofit;
		private int? _c_involved_projectunit_lossreason;
		private Guid? _c_involved_projectunit_creator;
		private DateTime? _c_involved_projectunit_createtime;
		private int? _c_involved_projectunit_isdelete;
		/// <summary>
		/// 主键，自增长，ID
		/// </summary>
		public int C_Involved_projectUnit_id
		{
			set{ _c_involved_projectunit_id=value;}
			get{return _c_involved_projectunit_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Involved_projectUnit_code
		{
			set{ _c_involved_projectunit_code=value;}
			get{return _c_involved_projectunit_code;}
		}
		/// <summary>
		/// 所属涉案项目，关联涉案项目表
		/// </summary>
		public Guid? C_Involved_project_code
		{
			set{ _c_involved_project_code=value;}
			get{return _c_involved_project_code;}
		}
		/// <summary>
		/// 工程子项目
		/// </summary>
		public string C_Involved_projectUnit_Child
		{
			set{ _c_involved_projectunit_child=value;}
			get{return _c_involved_projectunit_child;}
		}
		/// <summary>
		/// 投标单位类型，0-公司 1-个人
		/// </summary>
		public int? C_Involved_projectUnit_rival_type
		{
			set{ _c_involved_projectunit_rival_type=value;}
			get{return _c_involved_projectunit_rival_type;}
		}
		/// <summary>
		/// 关联投标单位，对手表
		/// </summary>
		public Guid? C_Involved_projectUnit_rival
		{
			set{ _c_involved_projectunit_rival=value;}
			get{return _c_involved_projectunit_rival;}
        }
        /// <summary>
        /// 对手名称(虚拟字段)
        /// </summary>
        public string C_Involved_projectUnit_rivalname
        {
            get { return _c_involved_projectunit_rivalname; }
            set { _c_involved_projectunit_rivalname = value; }
        }
        
		/// <summary>
		/// 承包形式，外键，parameter表，包含业主自营、挂靠、项目承包、不详
		/// </summary>
		public int? C_Involved_projectUnit_type
		{
			set{ _c_involved_projectunit_type=value;}
			get{return _c_involved_projectunit_type;}
		}
		/// <summary>
		/// 资金来源，外键，parameter表，包含自筹、合资、国有投资、外资
		/// </summary>
		public int? C_Involved_projectUnit_fundsSource
		{
			set{ _c_involved_projectunit_fundssource=value;}
			get{return _c_involved_projectunit_fundssource;}
		}
		/// <summary>
		/// 实际负责人，关联联系人表
		/// </summary>
		public Guid? C_Involved_projectUnit_charger
		{
			set{ _c_involved_projectunit_charger=value;}
			get{return _c_involved_projectunit_charger;}
		}
        /// <summary>
        /// 负责人名称
        /// </summary>
        public string C_Involved_projectUnit_chargername
        {
            get { return _c_involved_projectunit_chargername; }
            set { _c_involved_projectunit_chargername = value; }
        }
		/// <summary>
		/// 实际负责人身份定位
		/// </summary>
		public string C_Involved_projectUnit_chargerIdentity
		{
			set{ _c_involved_projectunit_chargeridentity=value;}
			get{return _c_involved_projectunit_chargeridentity;}
		}
		/// <summary>
		/// 组织形式，parameter表，外键，目前包含自营、合伙
		/// </summary>
		public int? C_Involved_projectUnit_chargerOrgan
		{
			set{ _c_involved_projectunit_chargerorgan=value;}
			get{return _c_involved_projectunit_chargerorgan;}
		}
		/// <summary>
		/// 资金来源，外键，parameter表，包含自筹、合资、国有投资、外资
		/// </summary>
		public int? C_Involved_projectUnit_chargerFundsSource
		{
			set{ _c_involved_projectunit_chargerfundssource=value;}
			get{return _c_involved_projectunit_chargerfundssource;}
		}
		/// <summary>
		/// 实际开工时间
		/// </summary>
		public DateTime? C_Involved_projectUnit_startTime
		{
			set{ _c_involved_projectunit_starttime=value;}
			get{return _c_involved_projectunit_starttime;}
		}
		/// <summary>
		/// 竣工验收时间
		/// </summary>
		public DateTime? C_Involved_projectUnit_acceptanceTime
		{
			set{ _c_involved_projectunit_acceptancetime=value;}
			get{return _c_involved_projectunit_acceptancetime;}
		}
		/// <summary>
		/// 外键，parameter表，工程进度，包含：基础以下，主体，封顶，装修拆架，综合验收，竣工验收
		/// </summary>
		public int? C_Involved_projectUnit_process
		{
			set{ _c_involved_projectunit_process=value;}
			get{return _c_involved_projectunit_process;}
		}
		/// <summary>
		/// 施工安全事故
		/// </summary>
		public string C_Involved_projectUnit_accidents
		{
			set{ _c_involved_projectunit_accidents=value;}
			get{return _c_involved_projectunit_accidents;}
		}
		/// <summary>
		/// 施工质量事故
		/// </summary>
		public string C_Involved_projectUnit_qualityAccidents
		{
			set{ _c_involved_projectunit_qualityaccidents=value;}
			get{return _c_involved_projectunit_qualityaccidents;}
		}
		/// <summary>
		/// 工程涉诉情况
		/// </summary>
		public string C_Involved_projectUnit_litigation
		{
			set{ _c_involved_projectunit_litigation=value;}
			get{return _c_involved_projectunit_litigation;}
		}
		/// <summary>
		/// 实际负责人亏盈状态，外键，parameter表，包含：盈利、亏损、齐平
		/// </summary>
		public int? C_Involved_projectUnit_lossOrProfit
		{
			set{ _c_involved_projectunit_lossorprofit=value;}
			get{return _c_involved_projectunit_lossorprofit;}
		}
		/// <summary>
		/// 亏损原因，外键，parameter表，包含：无亏损、经营不善、合同价格低
		/// </summary>
		public int? C_Involved_projectUnit_lossReason
		{
			set{ _c_involved_projectunit_lossreason=value;}
			get{return _c_involved_projectunit_lossreason;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Involved_projectUnit_creator
		{
			set{ _c_involved_projectunit_creator=value;}
			get{return _c_involved_projectunit_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Involved_projectUnit_createTime
		{
			set{ _c_involved_projectunit_createtime=value;}
			get{return _c_involved_projectunit_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Involved_projectUnit_isDelete
		{
			set{ _c_involved_projectunit_isdelete=value;}
			get{return _c_involved_projectunit_isdelete;}
		}
		#endregion Model

	}
}

